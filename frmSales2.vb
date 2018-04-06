Imports POS.FixControls
Imports System.Drawing.Printing
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmSales2
    Dim DS As New DataSet
    Dim CLS_Sale_Entry As New Sale_Entry
    Dim CLS_Sale As New Sale
    Dim LastEnteredItem As Integer = Nothing
    Dim isNewBill As Boolean = True
    Dim Operation As OperationType = OperationType.None
    Dim DY_Price As Boolean = False
    Dim Hold_array As New ArrayList

    Private Sub frmSales_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        BillNumber = BillNumber - 1
        frmSales2Ins = Nothing
    End Sub
    Private Sub frmSales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Me.DropItem.MaxDropDownItems = 25
            FillDropWithCondition(Me.DropCustomer, "Title", "AccountNum", Table.Account, "Code", , , , " WHERE AccountType = " & AccountType.Customer & " AND Code<>" & CLS_Config.AccCashCustomer)
            Me.DropCustomer.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend

            Fill_Dataset()
            SetGridLayout()
            Clear_Bill(False)
            Clear_Bill_Total()

            BillNumber = BillNumber + 1
            Me.txtBillNo.Text = BillNumber

        Catch ex As Exception
            MsgBox("[frmSales_Load]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub txtBarcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBarcode.KeyDown
        Try
            If in_Key_No_List(e.KeyCode) Then
                Me.txtBarcode.Value = Nothing
                Exit Sub
            End If

            Select Case e.KeyCode
                'EDIT BILL
                Case CLS_Config.K_EditBill
                    Dim SalesCode As Integer = CLS_Sale.Get_SalesCode(FixControl(Me.txtBarcode))
                    If FixObjectNumber(SalesCode) <> 0 Then Call_Edit(SalesCode)
                    'CUSTOMER LIST
                Case CLS_Config.K_CustomerList
                    If Me.DropCustomer.Visible = True Then
                        Me.DropCustomer.Value = Nothing
                        Me.DropCustomer.Visible = False
                        Me.txtBarcode.Focus()
                        Me.txtBarcode.Value = Nothing
                    Else
                        Me.DropCustomer.Visible = True
                        Me.DropCustomer.Focus()
                        Me.DropCustomer.Value = Nothing
                    End If
                    'ITEM LIST
                Case CLS_Config.K_ItemList
                    If Me.DropItem.Visible = True Then
                        Me.DropItem.Value = Nothing
                        Me.DropItem.Visible = False
                        Me.txtBarcode.Focus()
                        Me.txtBarcode.Value = Nothing
                    Else
                        Me.DropItem.Visible = True
                        Me.DropItem.Focus()
                        Me.DropItem.Value = Nothing
                    End If
                    'CLOSE
                Case CLS_Config.K_Close
                    If MsgBox("You want to close POS ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        frmMainIns.Close()
                    End If
                    'CLEAR
                Case CLS_Config.K_Clear
                    Clear_Bill()
                    Clear_Bill_Total()
                    'CLEAR BOX
                Case CLS_Config.K_ClearBox
                    Me.txtPrice.Value = Nothing
                    Me.txtQuantity.Value = 1
                    Me.txtNotes.Text = Nothing
                    Me.lblItemName.Text = Nothing
                    '
                    'INFO
                Case CLS_Config.K_Info
                    Operation = OperationType.Info
                    Me.txtNotes.Text = "Type Item Code And Press Enter"
                    '
                    'QUANTITY
                Case CLS_Config.K_Multiply, CLS_Config.K_Multiply2
                    If IsDBNull(Me.txtBarcode.Value) Or IsNothing(Me.txtBarcode.Value) Then Exit Select
                    If Me.txtBarcode.Value = Nothing Then Exit Select
                    If Not IsNumeric(Me.txtBarcode.Value) Then Exit Select
                    Me.txtQuantity.Value = CDec(Me.txtBarcode.Value)
                    Me.txtBarcode.Value = Nothing
                    '
                    'PRICE
                Case CLS_Config.K_Price, CLS_Config.K_Price2
                    Call_Price()
                    Operation = OperationType.None
                    Me.txtBarcode.SelectAll()
                    Me.txtBarcode.Value = Nothing
                    '
                    'DISCOUNT
                Case CLS_Config.K_Discount
                    If IsDBNull(Me.txtBarcode.Value) Or IsNothing(Me.txtBarcode.Value) Then Exit Select
                    If Me.txtBarcode.Value = Nothing Then Exit Select
                    If Not IsNumeric(Me.txtBarcode.Value) Then Exit Select
                    If Me.txtBarcode.Value / 1000 > Me.txtTotalBill.Value Then
                        Me.txtNotes.Text = "Discount Should be less then " & ConvertToString(CDec(Me.txtTotalBill.Value))
                        Exit Select
                    End If

                    Me.txtDiscount.Value = CDec(Me.txtBarcode.Value / 1000)
                    Me.txtBarcode.Value = Nothing
                    '
                    'PRINT
                Case CLS_Config.K_Print
                    If Printer_On = True Then
                        frmMainIns.PrintOnOff(False)
                    Else
                        frmMainIns.PrintOnOff(True)
                    End If
                    '
                    'REPEAT
                Case CLS_Config.K_Repeat
                    Me.txtBarcode.Value = LastEnteredItem
                    Call_Add()
                    Me.txtQuantity.Value = 1
                    '
                    'DELETE
                Case CLS_Config.K_Delete, CLS_Config.K_Delete2
                    Call_Delete()
                    '
                    'Credit_Sale
                Case CLS_Config.K_Credit_Sale, CLS_Config.K_Delete2
                    CLS_Sale.Payment = 0.0
                    CLS_Sale.PaymentType = PaymentType.Credit
                    Call_Tender()
                    '
                    'HOLD
                Case CLS_Config.K_Hold : Call_Hold()
                    '
                    'CASH
                Case CLS_Config.K_Cash, CLS_Config.K_Cash2
                    If IsDBNull(Me.txtBarcode.Value) Or IsNothing(Me.txtBarcode.Value) Then Exit Select
                    If Me.txtBarcode.Value = Nothing Then Exit Select
                    If Not IsNumeric(Me.txtBarcode.Value) Then Exit Select
                    CLS_Sale.Payment = Decimal.Round(CDec(FixControl(Me.txtBarcode)) / 1000, 3)
                    CLS_Sale.PaymentType = PaymentType.Cash
                    Call_Tender()
                    '
                    'KNET
                Case CLS_Config.K_Knet
                    If IsDBNull(Me.txtBarcode.Value) Or IsNothing(Me.txtBarcode.Value) Then Exit Select
                    If Me.txtBarcode.Value = Nothing Then Exit Select
                    If Not IsNumeric(Me.txtBarcode.Value) Then Exit Select
                    CLS_Sale.Payment = Decimal.Round(CDec(FixControl(Me.txtBarcode)) / 1000, 3)
                    CLS_Sale.PaymentType = PaymentType.KNet
                    Call_Tender()
                    '
                    'MASTER VISA
                Case CLS_Config.K_MasterVisa
                    If IsDBNull(Me.txtBarcode.Value) Or IsNothing(Me.txtBarcode.Value) Then Exit Select
                    If Me.txtBarcode.Value = Nothing Then Exit Select
                    If Not IsNumeric(Me.txtBarcode.Value) Then Exit Select
                    CLS_Sale.Payment = Decimal.Round(CDec(FixControl(Me.txtBarcode)) / 1000, 3)
                    CLS_Sale.PaymentType = PaymentType.MasterCard
                    Call_Tender()
                    '
                    'K_Open_Item
                Case CLS_Config.K_Open_Item
                    Operation = OperationType.Open_Item
                    Me.txtNotes.Text = "Type Item Code And Press Enter"
                    '
                    'Balance
                Case CLS_Config.K_Balance : Call_Balance()
                    '
                    'Sales Return
                Case CLS_Config.K_SalesReturn : Call_SalesReturn()
                    '
                    'Payment
                Case CLS_Config.K_Payment : Call_Payment()
            End Select


            Select Case e.KeyCode
                Case CLS_Config.K_Add, CLS_Config.K_Add2
                    Select Case Operation
                        Case OperationType.Info : Call_Info()
                        Case OperationType.Open_Item : Call_Item()
                        Case Else

                            Dim CLS_Item As New Item
                            CLS_Item = Get_Item(CStr(Me.txtBarcode.Value))
                            If IsNothing(CLS_Item) Then
                                MsgBox("Invalid Item.")
                                Me.txtNotes.Text = "Invalid Item."
                            Else
                                Me.lblItemName.Text = CLS_Item.ItemName
                                If Not CostPrice_On Then Me.txtPrice.Value = CLS_Item.SalesPrice * 1000
                                If CostPrice_On Then Me.txtPrice.Value = CLS_Item.CostPrice * 1000
                                Default_Price = Me.txtPrice.Value
                                Me.txtPrice.SelectAll()
                                Me.txtPrice.Focus()
                            End If

                            'Call_Add()
                            'Me.txtQuantity.Value = 1
                    End Select

            End Select


        Catch ex As Exception
            MsgBox("[txtBarcode_KeyDown]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub grdList_AfterRowInsert(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles grdList.AfterRowInsert
        'Initialize The New Record
        Try
            If Me.grdList.Rows.Count = 1 Then
                e.Row.Cells("Sr").Value = 1
            Else
                e.Row.Cells("Sr").Value = Me.grdList.Rows(Me.grdList.Rows.Count - 2).Cells("Sr").Value + 1
            End If
            e.Row.Cells("ItemCode").Value = CLS_Sale_Entry.ItemCode
            e.Row.Cells("Barcode").Value = CLS_Sale_Entry.Barcode
            e.Row.Cells("ItemName").Value = CLS_Sale_Entry.ItemName
            e.Row.Cells("UnitPrice").Value = CLS_Sale_Entry.UnitPrice
            e.Row.Cells("Quantity").Value = CLS_Sale_Entry.Quantity
            e.Row.Cells("TotalPrice").Value = CLS_Sale_Entry.TotalPrice
            e.Row.Cells("CostPrice").Value = CLS_Sale_Entry.CostPrice


            Me.UltraCalcManager1.DirtyAllFormulas()

            LastEnteredItem = CLS_Sale_Entry.ItemCode

            Dim q As String = Me.grdList.Rows.Count
            Select Case q.Length
                Case 0 : q = "00"
                Case 1 : q = "0" & q
            End Select

            'Dim M1 As String = e.Row.Cells("ItemName").Value & ":" & ConvertToString(e.Row.Cells("UnitPrice").Value)
            Dim M1 As String = RTrim(e.Row.Cells("ItemName").Value & ":", 19 - 8) & LTrim(ConvertToString(e.Row.Cells("UnitPrice").Value), 6)
            'Dim M2 As String = "Total:" & ConvertToString(Get_Grid_Total(Me.grdList, "TotalPrice") - CDec(Me.txtDiscount.Value)) & "       "
            Dim M2 As String = RTrim("Total:", 19 - 8) & LTrim(ConvertToString(Get_Grid_Total(Me.grdList, "TotalPrice") - CDec(Me.txtDiscount.Value)), 6)

            Send_To_Port(M1, M2)

            If Printer_On And Not CLS_Config.BigReceiprPrinter Then

                P_ItemName = e.Row.Cells("ItemName").Value
                P_Qty = e.Row.Cells("Quantity").Value.ToString
                If e.Row.Cells("UnitPrice").Value >= 10.0 Then
                    P_Rate = ConvertToString(e.Row.Cells("UnitPrice").Value)
                Else
                    P_Rate = ConvertToString(e.Row.Cells("UnitPrice").Value, False)
                End If
                If e.Row.Cells("TotalPrice").Value >= 10.0 Then
                    P_Price = ConvertToString(e.Row.Cells("TotalPrice").Value)
                Else
                    P_Price = ConvertToString(e.Row.Cells("TotalPrice").Value, False)
                End If


                Dim prndoc As PrintDocument = New PrintDocument()
                If isNewBill Then
                    PrintHeadder()
                    isNewBill = False
                End If
                PrintItem()
            End If


        Catch ex As Exception
            MsgBox("[grdList_AfterRowInsert]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub txtBarcode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBarcode.KeyUp
        If in_Key_List(e.KeyCode) Then Me.txtBarcode.Value = Nothing
        If in_Key_No_List(e.KeyCode) Then Me.txtBarcode.Value = Nothing
    End Sub
    Private Sub txtDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDate.ValueChanged
        Try
            If FixControl(Me.txtDate) = Null_Date Then Exit Sub
            CLS_Sale.TransectionDate = CDate(Me.txtDate.Value)
        Catch ex As Exception
            MsgBox("[txtDate_ValueChanged]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Dim Default_Price As Decimal = 0.0

    Private Sub Call_Info()
        Try
            Dim CLS As New Item
            CLS = Get_Item(CStr(Me.txtBarcode.Value))

            If IsNothing(CLS) Then
                Me.txtNotes.Text = "ITEM NOT FOUNT !!!" & vbCrLf
            Else
                CLS.ItemStock(CLS.Code)

                Me.txtNotes.Text = "ITEM NAME [" & LTrim(CLS.ItemName, 12) & "]" & vbCrLf
                Me.txtNotes.Text &= "ITEM PRICE [" & ConvertToString(CLS.SalesPrice) & "]" & vbCrLf
                Me.txtNotes.Text &= "IN STOCK   [" & ConvertToString(CLS.Stock) & "]"

                Dim M1 As String = LTrim(CLS.ItemName & ":", 19 - 6) & RTrim(ConvertToString(CLS.SalesPrice), 6)
                Send_To_Port(M1, "")

            End If

            Operation = OperationType.None

        Catch ex As Exception
            MsgBox("[Call_Info]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub Call_Price()
        Try
            If IsNumeric(Me.txtBarcode.Value) Then
                If CInt(Me.txtBarcode.Value) Mod 5 <> 0 Or CInt(Me.txtBarcode.Value) < 5 Then
                    Me.txtNotes.Text = "Invaid Price !!!."
                    DY_Price = False
                    'play sound
                    sndPLaySound("notify.wav", SND_ASYNC)
                Else
                    Me.txtPrice.Value = CInt(Me.txtBarcode.Value)
                    Me.txtNotes.Text = Nothing
                    DY_Price = True
                End If
                Me.txtBarcode.SelectAll()
                Me.txtBarcode.Value = Nothing
            End If
        Catch ex As Exception
            MsgBox("[Call_Price]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub Call_Add()
        Try
            CLS_Sale_Entry = New Sale_Entry

            Dim CLS_Item As New Item
            CLS_Item = Get_Item(CStr(Me.txtBarcode.Value))

            If IsNothing(CLS_Item) Then
                Dim br As String = CStr(IIf(IsNothing(Me.txtBarcode.Value), 0, Me.txtBarcode.Value))
                If br.Length = 13 Then
                    'Dim Type As String = br.Substring(0, 4)
                    Dim ItemCode As String = br.Substring(0, 7)
                    CLS_Item = Get_Item(CStr(ItemCode))
                    If IsNothing(CLS_Item) Then
                        'play sound
                        sndPLaySound("notify.wav", SND_ASYNC)
                        Me.txtBarcode.Value = Nothing
                        MsgBox("Item Not Found !!!!!")
                        Send_To_Port("Item Not Found !!!!", "")
                        Exit Try
                    Else
                        Me.txtPrice.Value = CType(br.Substring(7, 5), Decimal)
                        DY_Price = True
                    End If
                Else
                    'play sound
                    sndPLaySound("notify.wav", SND_ASYNC)
                    Me.txtBarcode.Value = Nothing
                    MsgBox("Item Not Found !!!!!")
                    Send_To_Port("Item Not Found !!!!", "")
                    Exit Try
                End If
            End If


            If Not IsNothing(CLS_Item) Then

                If (CLS_Item.SalesPrice < 0.005) And _
                (FixControl(Me.txtPrice) = Nothing Or FixControl(Me.txtPrice) < 5) Then Exit Try

                If (CLS_Item.CostPrice < 0.005) And CostPrice_On Then Exit Try


                'play sound
                sndPLaySound("ding.wav", SND_ASYNC)

                CLS_Sale_Entry.ItemCode = CLS_Item.Code
                If DY_Price Then
                    CLS_Sale_Entry.UnitPrice = Decimal.Round(CDec(Me.txtPrice.Value) / 1000, 3)
                Else
                    If CostPrice_On Then CLS_Sale_Entry.UnitPrice = Decimal.Round(CLS_Item.CostPrice, 3)
                    If Not CostPrice_On Then CLS_Sale_Entry.UnitPrice = Decimal.Round(CLS_Item.SalesPrice, 3)
                End If
                If FixControl(Me.txtQuantity) = Nothing Then Me.txtQuantity.Value = 1
                CLS_Sale_Entry.Quantity = CDec(Me.txtQuantity.Value)
                CLS_Sale_Entry.TotalPrice = Decimal.Round(CDec(CLS_Sale_Entry.UnitPrice * CLS_Sale_Entry.Quantity), 3)
                CLS_Sale_Entry.CostPrice = Decimal.Round(CLS_Item.CostPrice, 3)
                CLS_Sale_Entry.ItemName = CLS_Item.ItemName
                CLS_Sale_Entry.Barcode = CLS_Item.Barcode

                'If IsNothing(CLS_Sale_Entry.ItemCode) Or CLS_Sale_Entry.ItemCode = 0 Or _
                'IsNothing(CLS_Sale_Entry.UnitPrice) Or CLS_Sale_Entry.UnitPrice = 0 Or _
                'IsNothing(CLS_Sale_Entry.Quantity) Or CLS_Sale_Entry.Quantity = 0 Or _
                'IsNothing(CLS_Sale_Entry.TotalPrice) Or CLS_Sale_Entry.TotalPrice = 0 Then
                If IsNothing(CLS_Sale_Entry.ItemCode) Or CLS_Sale_Entry.ItemCode = 0 Or _
               IsNothing(CLS_Sale_Entry.UnitPrice) Or _
               IsNothing(CLS_Sale_Entry.Quantity) Or CLS_Sale_Entry.Quantity = 0 Or _
               IsNothing(CLS_Sale_Entry.TotalPrice) Then

                    'play sound
                    sndPLaySound("notify.wav", SND_ASYNC)
                    Me.txtBarcode.Value = Nothing
                    MsgBox("Invalid Entry !!!")
                    Me.txtNotes.Text = "Invalid Entry !!!"
                    Send_To_Port("Invalid Entry !!!", "")
                    Exit Try
                    Exit Try
                End If

                If isNewBill Then Clear_Bill_Total()

                Me.grdList.DisplayLayout.Bands(0).AddNew()

                isNewBill = False

                ReCalculate()
                New_Entry()

            End If


        Catch ex As Exception
            MsgBox("[Call_Add]" & vbCrLf & ex.Message)
        End Try
        Operation = OperationType.None
    End Sub
    Private Sub Call_Tender()
        Try

            If CLS_Sale.PaymentType = PaymentType.Credit Then
                If FixControl(Me.txtBarcode) = Nothing Then
                    MsgBox("Customer Accout Missing !!!")
                    Me.txtNotes.Text = "Customer Accout Missing !!!"
                    Exit Sub
                End If

                If FixControl(Me.txtNetBill) = Nothing Then
                    MsgBox("Net Amount Missing !!!")
                    Me.txtNotes.Text = "Net Amount Missing !!!"
                    Exit Sub
                End If

                Dim CLS_ACC As New Account
                If Not CLS_ACC.Select_Customer(Me.txtBarcode.Value, Null_Date) Then
                    MsgBox("Invalid Customer Accout !!!")
                    Me.txtNotes.Text = "Invalid Customer Accout !!!"
                    Exit Sub
                End If

                If CLS_Sale.TransectionType = TransectionType.CreditSaleReturn Then
                    If MsgBox("Sale Return of [" & ConvertToString(CDec(Me.txtNetBill.Value)) & "] for CUSTOMER NAME [ " & CLS_ACC.Title & " ]", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub
                    CLS_Sale.CustomerCode = CLS_ACC.Code
                    CLS_Sale.CustomerNum = CLS_ACC.AccountNum
                    CLS_Sale.CustomerName = CLS_ACC.Title
                Else
                    If MsgBox("Credit Transection of [" & ConvertToString(CDec(Me.txtNetBill.Value)) & "] for CUSTOMER NAME [ " & CLS_ACC.Title & " ]", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub
                    CLS_Sale.CustomerCode = CLS_ACC.Code
                    CLS_Sale.CustomerNum = CLS_ACC.AccountNum
                    CLS_Sale.CustomerName = CLS_ACC.Title
                    CLS_Sale.TransectionType = TransectionType.CreditSale
                End If

            End If


            If CLS_Sale.TransectionType = TransectionType.CashSaleReturn Then
                If MsgBox("Cash Sales Return of [" & ConvertToString(CDec(Me.txtNetBill.Value)) & "]", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub
            End If

            Me.UltraCalcManager1.DirtyAllFormulas()

            CLS_Sale.TotalBill = Decimal.Round(CDec(FixControl(Me.txtTotalBill)), 3)
            CLS_Sale.Discount = Decimal.Round(CDec(FixControl(Me.txtDiscount)), 3)
            CLS_Sale.NetBill = Decimal.Round(CDec(FixControl(Me.txtNetBill)), 3)

            If CLS_Sale.Payment < CLS_Sale.NetBill And _
            CLS_Sale.PaymentType <> PaymentType.Credit And _
            CLS_Sale.TransectionType <> TransectionType.CashSaleReturn And _
            CLS_Sale.TransectionType <> TransectionType.CreditSaleReturn And _
            CLS_Sale.TransectionType <> TransectionType.Hold Then
                MsgBox("Invalid amount entered.")
                'MsgBox("Invalid amount entered.")
                Me.txtNotes.Text = "Invalid amount entered."
                Me.txtBarcode.Value = Nothing
                Exit Sub
            End If

            Me.txtPayment.Value = Decimal.Round(CDec(CLS_Sale.Payment), 3)

            Select Case CLS_Sale.TransectionType
                Case TransectionType.CashSale
                    CLS_Sale.Balance = Decimal.Round(CDec(CLS_Sale.Payment - CLS_Sale.NetBill), 3)
                    Me.txtBalance.Value = Decimal.Round(CDec(CLS_Sale.Balance), 3)
                Case Else
                    CLS_Sale.Balance = 0
                    Me.txtBalance.Value = 0
            End Select

            CLS_Sale.BillNo = BillNumber


            If FixObjectNumber(CLS_Sale.NetBill) = 0 Then
                MsgBox("Invalid Transection")
                Me.txtNotes.Text = "Invalid Transection"
                Exit Sub
            End If


            CLS_Sale.Add()
            Dim i As Integer = 0
            For i = 0 To Me.grdList.Rows.Count - 1
                Dim CLS As New Sale_Entry
                CLS.SaleCode = CLS_Sale.Code
                CLS.ItemCode = Me.grdList.Rows(i).Cells("ItemCode").Value
                CLS.UnitPrice = Me.grdList.Rows(i).Cells("UnitPrice").Value
                CLS.Quantity = Me.grdList.Rows(i).Cells("Quantity").Value
                CLS.TotalPrice = Me.grdList.Rows(i).Cells("TotalPrice").Value
                CLS.CostPrice = Me.grdList.Rows(i).Cells("CostPrice").Value
                CLS.Add(CLS_Sale.TransectionType)
            Next

            Select Case CLS_Sale.TransectionType
                Case TransectionType.Hold
                    Hold_array.Add(BillNumber)
                    Me.txtHoldList.Text = "On Hold: " & Convert_Array_To_String(Hold_array)
                    If Printer_On And Not CLS_Config.BigReceiprPrinter Then
                        PrintHold()
                    End If
                Case Else
                    If Printer_On And Not CLS_Config.BigReceiprPrinter Then
                        PrintFooter()
                    End If
            End Select

            If CLS_Config.BigReceiprPrinter And Printer_On And _
            (CLS_Sale.TransectionType = TransectionType.CashSale Or CLS_Sale.TransectionType = TransectionType.CreditSale) Then
                Print_Big_Bill(CLS_Sale.Code)
            End If


            If EDITIGN_BILL <> 0 Then
                CLS_Sale.Delete(EDITIGN_BILL)
                BillNumber = CurrentBillNo - 1
            End If

            Clear_Bill()
            BillNumber = BillNumber + 1
            Me.txtBillNo.Text = BillNumber


        Catch ex As Exception
            MsgBox("[Call_Tender]" & vbCrLf & ex.Message)
        End Try
        Operation = OperationType.None
    End Sub
    Private Sub Call_Delete()
        Try
            If FixControl(Me.txtBarcode) = Nothing Then Exit Sub

            Dim flag As Boolean = False
            Dim i As Integer = 0
            'Dim cls_Card_Details As New CardDetails
            For i = 0 To Me.grdList.Rows.VisibleRowCount - 1
                Dim sr = Me.grdList.Rows(i).Cells("Sr").Value
                If sr = Me.txtBarcode.Value Then
                    If Printer_On And Not CLS_Config.BigReceiprPrinter Then
                        'cls_Card_Details = Get_CardDetails(Me.grdList.Rows(i).Cells("CardID").Value)

                        P_ItemName = Me.grdList.Rows(i).Cells("ItemName").Value
                        P_Qty = "- " & Me.grdList.Rows(i).Cells("Quantity").Value

                        If Me.grdList.Rows(i).Cells("UnitPrice").Value >= 10.0 Then
                            P_Rate = ConvertToString(Me.grdList.Rows(i).Cells("UnitPrice").Value)
                        Else
                            P_Rate = ConvertToString(Me.grdList.Rows(i).Cells("UnitPrice").Value, False)
                        End If
                        If Me.grdList.Rows(i).Cells("TotalPrice").Value >= 10.0 Then
                            P_Price = ConvertToString(Me.grdList.Rows(i).Cells("TotalPrice").Value)
                        Else
                            P_Price = ConvertToString(Me.grdList.Rows(i).Cells("TotalPrice").Value, False)
                        End If

                        Dim prndoc As PrintDocument = New PrintDocument()
                        PrintItem(True)

                    End If

                    Dim M1 As String = "- " & ConvertToString(Me.grdList.Rows(i).Cells("UnitPrice").Value)

                    Me.grdList.Rows(i).Delete(False)
                    ReCalculate()
                    Dim M2 As String = "Total:" & ConvertToString(Me.txtNetBill.Value) & "       "

                    Send_To_Port(M1, M2)
                    flag = True
                    Exit For
                End If
            Next
            If Not flag Then sndPLaySound("notify.wav", SND_ASYNC)

            Me.txtNotes.Text = Nothing
            Me.txtBarcode.SelectAll()
            Me.txtBarcode.Value = Nothing

            ReCalculate()

        Catch ex As Exception
            MsgBox("[Call_Delete]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub Call_Item()
        Try
            Dim Item As String = 0
            If FixControl(Me.txtBarcode) = Nothing Then
                Item = 0
            Else
                Dim CLS As New Item
                CLS = Get_Item(CStr(Me.txtBarcode.Value))
                Item = CLS.Code
            End If

            Dim FRM As New frmItem(Item)
            FRM.Show()

            New_Entry(False)

        Catch ex As Exception
            MsgBox("[Call_Item]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub Call_Balance()
        Try
            If FixControl(Me.txtBarcode) = Nothing Then
                Me.txtNotes.Text = "Invalid Customer Accout !!!"
                sndPLaySound("notify.wav", SND_ASYNC)
                Exit Sub
            End If

            Dim CLS_ACC As New Account
            If Not CLS_ACC.Select_Customer(Me.txtBarcode.Value, Null_Date) Then
                MsgBox("Invalid Customer Accout !!!")
                Me.txtNotes.Text = "Invalid Customer Accout !!!"
                Exit Sub
            End If


            Me.txtNotes.Text = "CUSTOMER [" & CLS_ACC.Title & "]" & vbCrLf
            Me.txtNotes.Text &= "BALANCE     [" & ConvertToString(CLS_ACC.Balance) & "]" & vbCrLf
            Me.txtNotes.Text &= "LAST BILL     [" & ConvertToString(CLS_ACC.LastBill) & "]" & vbCrLf

            'DISPLAY POLE
            Dim M1 As String = CLS_ACC.AccountNum & " " & CLS_ACC.Title
            Dim M2 As String = "ACCOUNT BAL :" & ConvertToString(CLS_ACC.Balance)
            Send_To_Port(M1, M2)

            Operation = OperationType.None

        Catch ex As Exception
            MsgBox("[Call_Balance]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub Call_Hold()
        Try
            If FixControl(Me.txtBarcode) = Nothing Then
                If Me.grdList.Rows.Count = 0 Then
                    MsgBox("No item in bill to hold !!!")
                    Me.txtNotes.Text = "No item in bill to hold !!!"
                    New_Entry()
                    Exit Sub
                End If
                CLS_Sale.Payment = 0.0
                CLS_Sale.PaymentType = PaymentType.Cash
                CLS_Sale.TransectionType = TransectionType.Hold
                Call_Tender()
            Else

                If Me.grdList.Rows.Count > 0 Then
                    If MsgBox("Do you want to cancel current bill and load Hold bill", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                        New_Entry()
                        Exit Sub
                    End If
                End If

                Clear_Grid()


                Dim DT As New DataTable
                DT = CLS_Sale.SelectHold(Me.txtBarcode.Value)

                CLS_Sale.TransectionType = TransectionType.CashSale
                Dim i As Integer = 0
                For i = 0 To DT.Rows.Count - 1
                    CLS_Sale_Entry.ItemCode = DT.Rows(i).Item("ItemCode")
                    CLS_Sale_Entry.Barcode = DT.Rows(i).Item("Barcode")
                    CLS_Sale_Entry.ItemName = DT.Rows(i).Item("ItemName")
                    CLS_Sale_Entry.UnitPrice = DT.Rows(i).Item("UnitPrice")
                    CLS_Sale_Entry.Quantity = DT.Rows(i).Item("Quantity")
                    CLS_Sale_Entry.TotalPrice = DT.Rows(i).Item("TotalPrice")
                    CLS_Sale_Entry.CostPrice = DT.Rows(i).Item("CostPrice")

                    Me.grdList.DisplayLayout.Bands(0).AddNew()

                Next
                'Me.grdList.DataSource = DT
                'Me.grdList.DataBind()


                Dim TempArr As New ArrayList
                Me.txtHoldList.Text = ""
                Dim q As Integer = 0
                For q = 0 To Hold_array.Count - 1
                    Dim str = Hold_array(q)
                    If str = Convert.ToString(Me.txtBarcode.Value).ToUpper Then
                    Else
                        TempArr.Add(Hold_array(q))
                    End If
                Next
                Hold_array = TempArr

                If Hold_array.Count > 0 Then Me.txtHoldList.Text = "On Hold: " & Convert_Array_To_String(Hold_array)


                isNewBill = False
                Clear_Bill_Total()
                ReCalculate()
                New_Entry()

            End If
        Catch ex As Exception
            MsgBox("[Call_Hold]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub Call_SalesReturn()
        Try
            If Me.grdList.Rows.Count = 0 Then
                MsgBox("No item in bill for sales return !!!")
                Me.txtNotes.Text = "No item in bill for sales return !!!"
                New_Entry()
                Exit Sub
            End If


            'If MSG.InfoYesNo("Are you sure you want to make sales return?", 1) <> Windows.Forms.DialogResult.Yes Then
            '    New_Entry()
            '    Exit Sub
            'End If

            CLS_Sale.Payment = 0.0
            If FixControl(Me.txtBarcode) = Nothing Then
                CLS_Sale.PaymentType = PaymentType.Cash
                CLS_Sale.TransectionType = TransectionType.CashSaleReturn
            Else
                CLS_Sale.PaymentType = PaymentType.Credit
                CLS_Sale.TransectionType = TransectionType.CreditSaleReturn
            End If
            Call_Tender()
        Catch ex As Exception
            MsgBox("[Call_SalesReturn]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub Call_Payment()
        Try
            Dim FRM As New frmCustomerPayment
            FRM.ShowDialog()
        Catch ex As Exception
            MsgBox("[Call_Payment]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub Call_Edit(ByVal SalesCode As Integer)
        Try

            If Me.grdList.Rows.Count > 0 Then
                If MsgBox("Do you want to cancel current bill and load editing bill", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                    New_Entry()
                    Exit Sub
                End If
            End If

            Clear_Bill()

            Dim DT As New DataTable
            DT = CLS_Sale.SelectEdit(SalesCode)
            Me.txtDate.Value = CDate(CLS_Sale.TransectionDate)
            CurrentBillNo = BillNumber
            BillNumber = CLS_Sale.BillNo
            Me.txtBillNo.Text = CLS_Sale.BillNo
            EDITIGN_BILL = CLS_Sale.Code

            CLS_Sale.TransectionType = TransectionType.CashSale

            Dim i As Integer = 0
            For i = 0 To DT.Rows.Count - 1
                CLS_Sale_Entry.ItemCode = DT.Rows(i).Item("ItemCode")
                CLS_Sale_Entry.Barcode = DT.Rows(i).Item("Barcode")
                CLS_Sale_Entry.ItemName = DT.Rows(i).Item("ItemName")
                CLS_Sale_Entry.UnitPrice = DT.Rows(i).Item("UnitPrice")
                CLS_Sale_Entry.Quantity = DT.Rows(i).Item("Quantity")
                CLS_Sale_Entry.TotalPrice = DT.Rows(i).Item("TotalPrice")
                CLS_Sale_Entry.CostPrice = Decimal.Round(CLS_Sale_Entry.CostPrice / CLS_Sale_Entry.Quantity, 3)

                Me.grdList.DisplayLayout.Bands(0).AddNew()

            Next

            isNewBill = False
            Clear_Bill_Total()
            ReCalculate()
            New_Entry()

        Catch ex As Exception
            MsgBox("[Call_Edit]" & vbCrLf & ex.Message)
        End Try
    End Sub

    Dim CurrentBillNo As Integer = BillNumber
    Dim EDITIGN_BILL As Integer = 0


    Public Sub Fill_Dataset()
        Try
            DS = New DataSet

            Dim PARA As New ArrayList
            PARA.Add(CLS_Config.Counter)
            DS = DBO.ExecuteSP_ReturnDataSet("POS_Select", PARA)

            Hold_array.Clear()
            Dim i As Integer = 0
            For i = 0 To DS.Tables(4).Rows.Count - 1
                Hold_array.Add(DS.Tables(4).Rows(i).Item("BillNo").ToString)
            Next

            If DS.Tables(4).Rows.Count > 0 Then Me.txtHoldList.Text = "On Hold: " & Convert_Array_To_String(Hold_array)

            If CLS_Config.SearchByBarcode Then
                FillDropByQuery(Me.DropItem, "ItemName", "Code", "SELECT Code, COALESCE(barcode,'') + ' - ' + COALESCE(ItemName,'') AS ItemName FROM ITEM ORDER BY barcode")
            Else
                FillDrop(Me.DropItem, "ItemName", "Code", Table.Item)
            End If
            Me.DropItem.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend

            Me.txtBarcode.SelectAll()
            Me.txtBarcode.Focus()
            Me.txtBarcode.Value = Nothing

        Catch ex As Exception
            MsgBox("[Fill_Dataset]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub SetGridLayout()
        Try
            Me.grdList.DataSource = DS.Tables(0)
            Me.grdList.DataBind()

            For i As Integer = 0 To Me.grdList.DisplayLayout.Bands(0).Columns.Count - 1
                Me.grdList.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Next

            Me.grdList.DisplayLayout.Bands(0).Columns("Sr").Header.VisiblePosition = 0
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemName").Header.VisiblePosition = 1
            Me.grdList.DisplayLayout.Bands(0).Columns("UnitPrice").Header.VisiblePosition = 2
            Me.grdList.DisplayLayout.Bands(0).Columns("Quantity").Header.VisiblePosition = 3
            Me.grdList.DisplayLayout.Bands(0).Columns("TotalPrice").Header.VisiblePosition = 4
            Me.grdList.DisplayLayout.Bands(0).Columns("Barcode").Header.VisiblePosition = 5

            Me.grdList.DisplayLayout.Bands(0).Columns("ItemCode").Hidden = True
            Me.grdList.DisplayLayout.Bands(0).Columns("CostPrice").Hidden = True

            Me.grdList.DisplayLayout.Bands(0).Columns("Sr").Width = 50
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemName").Width = 450
            Me.grdList.DisplayLayout.Bands(0).Columns("UnitPrice").Width = 100
            Me.grdList.DisplayLayout.Bands(0).Columns("Quantity").Width = 100
            Me.grdList.DisplayLayout.Bands(0).Columns("TotalPrice").Width = 100
            Me.grdList.DisplayLayout.Bands(0).Columns("Barcode").Width = 100

            Me.grdList.DisplayLayout.Bands(0).Columns("UnitPrice").MaskInput = Mask_Amount
            'Me.grdList.DisplayLayout.Bands(0).Columns("Quantity").MaskInput = Mask_Amount
            Me.grdList.DisplayLayout.Bands(0).Columns("TotalPrice").MaskInput = Mask_Amount


        Catch ex As Exception
            MsgBox("[SetGridLayout]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub Clear_Bill(Optional ByVal Cut As Boolean = True)
        Try
            CLS_Sale = New Sale
            Me.txtDate.Value = Now.Date
            Me.txtPrice.Value = Nothing
            Me.txtQuantity.Value = 1
            Me.txtBarcode.Value = Nothing
            Me.txtNotes.Text = Nothing
            Me.lblItemName.Text = Nothing
            EDITIGN_BILL = 0

            If Cut And Printer_On And Not CLS_Config.BigReceiprPrinter Then PrintEmptySpace()

            Clear_Grid()

            Me.txtBarcode.Focus()

            Operation = OperationType.None

            CostPrice_On = False
            frmMainIns.MenuStrip.BackColor = System.Drawing.SystemColors.Control


        Catch ex As Exception
            MsgBox("[Clear_Bill]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub Clear_Bill_Total()
        Try
            Me.txtTotalBill.Value = 0.0
            Me.txtDiscount.Value = 0.0
            Me.txtNetBill.Value = 0.0
            Me.txtPayment.Value = 0.0
            Me.txtBalance.Value = 0.0

        Catch ex As Exception
            MsgBox("[Clear_Bill_Total]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub New_Entry(Optional ByVal Focus As Boolean = True)
        Try
            CLS_Sale_Entry = New Sale_Entry
            Me.txtPrice.Value = Nothing
            Me.txtQuantity.Value = 1
            Me.txtNotes.Text = Nothing
            If Focus Then
                Me.txtBarcode.Focus()
                Me.txtBarcode.SelectAll()
            End If
            Me.txtBarcode.Value = Nothing
            DY_Price = False
            Operation = OperationType.None
            Me.lblItemName.Text = Nothing

        Catch ex As Exception
            MsgBox("[New_Entry]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Function Get_Item(ByVal Barcode As String) As Item
        Try
            Dim DT As New DataTable
            DT = DS.Tables(1)

            Dim CLS As New Item
            'IF BARCODE IS NULL RETURN EMPTY CLS
            If FixObjectString(Barcode) = Nothing Then Return Nothing

            'IF BARCODE EXIST IN DS LOAD & RETURN CLS
            Dim dr() As DataRow = DT.Select(" Barcode='" & Barcode & "'")
            If dr.Length > 0 Then
                CLS.Code = IIf(IsDBNull(dr(0).Item("Code")), 0, dr(0).Item("Code"))
                CLS.ItemName = IIf(IsDBNull(dr(0).Item("ItemName")), 0, dr(0).Item("ItemName"))
                CLS.CostPrice = IIf(IsDBNull(dr(0).Item("CostPrice")), 0, dr(0).Item("CostPrice"))
                CLS.SalesPrice = IIf(IsDBNull(dr(0).Item("SalesPrice")), 0, dr(0).Item("SalesPrice"))
                CLS.Barcode = IIf(IsDBNull(dr(0).Item("Barcode")), 0, dr(0).Item("Barcode"))
                CLS.Barcode2 = IIf(IsDBNull(dr(0).Item("Barcode2")), 0, dr(0).Item("Barcode2"))
                Return CLS
            End If
            'IF BARCODE DOSE NOT EXIST CONT...


            'IF BARCODE IS NOT INTEGER SKIP CHECKING BY CODE
            If IsNumeric(Barcode) Then
                'IF CODE IS NUMERIC AND EXIST IN DS LOAD & RETURN CLS
                Dim dr3() As DataRow = DT.Select(" Code=" & Barcode)
                If dr3.Length > 0 Then
                    CLS.Code = IIf(IsDBNull(dr3(0).Item("Code")), 0, dr3(0).Item("Code"))
                    CLS.ItemName = IIf(IsDBNull(dr3(0).Item("ItemName")), 0, dr3(0).Item("ItemName"))
                    CLS.CostPrice = IIf(IsDBNull(dr3(0).Item("CostPrice")), 0, dr3(0).Item("CostPrice"))
                    CLS.SalesPrice = IIf(IsDBNull(dr3(0).Item("SalesPrice")), 0, dr3(0).Item("SalesPrice"))
                    CLS.Barcode = IIf(IsDBNull(dr3(0).Item("Barcode")), 0, dr3(0).Item("Barcode"))
                    CLS.Barcode2 = IIf(IsDBNull(dr3(0).Item("Barcode2")), 0, dr3(0).Item("Barcode2"))
                    Return CLS
                End If
            End If

            'IF BARCODE2 EXIST IN DS LOAD & RETURN CLS
            Dim dr2() As DataRow = DT.Select(" Barcode2='" & Barcode & "'")
            If dr2.Length > 0 Then
                CLS.Code = IIf(IsDBNull(dr2(0).Item("Code")), 0, dr2(0).Item("Code"))
                CLS.ItemName = IIf(IsDBNull(dr2(0).Item("ItemName")), 0, dr2(0).Item("ItemName"))
                CLS.CostPrice = IIf(IsDBNull(dr2(0).Item("CostPrice")), 0, dr2(0).Item("CostPrice"))
                CLS.SalesPrice = IIf(IsDBNull(dr2(0).Item("SalesPrice")), 0, dr2(0).Item("SalesPrice"))
                CLS.Barcode = IIf(IsDBNull(dr2(0).Item("Barcode")), 0, dr2(0).Item("Barcode"))
                CLS.Barcode2 = IIf(IsDBNull(dr2(0).Item("Barcode2")), 0, dr2(0).Item("Barcode2"))
                Return CLS
            End If

            'IF BARCODE IS NOT CODE RETURN EMPTY CLS
            Return Nothing
        Catch ex As Exception
            MsgBox("[Get_Item]" & vbCrLf & ex.Message)
            Return Nothing
        End Try
    End Function
    Private Sub ReCalculate()
        Try
            Me.txtTotalBill.Value = Get_Grid_Total(Me.grdList, "TotalPrice")
            Me.UltraCalcManager1.DirtyAllFormulas()
        Catch ex As Exception
            MsgBox("[ReCalculate]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub Clear_Grid()
        Try

            DS.Tables(0).RejectChanges()
            Me.grdList.DataBind()
            isNewBill = True

            Try
                Dim i As Integer = 0
                For i = 0 To Me.grdList.Rows.Count - 1
                    Me.grdList.Rows(i).Delete(False)
                    i = i - 1
                Next
            Catch ex As Exception
            End Try

        Catch ex As Exception
            MsgBox("[Clear_Grid]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Function Send_To_Port(ByVal Message1 As String, ByVal Message2 As String) As Boolean
        Try
            Message1 = LTrim(Message1, 19)
            Message2 = LTrim(Message2, 19)

            With SerialPort2
                If .IsOpen Then
                    .Close()
                End If
                .PortName = CLS_Config.ComPort
                '.PortName = CLS_Config.ReceiptPrinter
                .Open()
                .Write(vbCrLf & Message2 & vbCrLf & Message1)
                .Close()
            End With

        Catch ex As Exception
            'MsgBox("[Send_To_Port]" & vbCrLf & ex.Message)
        End Try
    End Function

#Region "                   PRINTING                     "

    Dim P_ItemName, P_Qty, P_Rate, P_Price, P_Tran_Type As String
    Dim P_Gap As Integer = 15
    Dim P_Amount_T As Double
    Dim FontStyle_12 As New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))

    Private Sub PrintHeadder()
        Try
            Dim str As String = ""
            Select Case CLS_Config.Company
                Case EDEE
                    str = "          EDEE SUPER MARKET" & vbCrLf
                    str += "   SALMIYA TEL: 25635962,25653370" & vbCrLf
                Case BOOKSHOP
                    str = "              EDEE BOOK SHOP" & vbCrLf
                    str += "       SALMIYA TEL: 25648815" & vbCrLf
                Case ZAHRABAKALA
                    str = "            NOOR AL ZAHRA BAKALA" & vbCrLf
                    str += "              TEL: 224 78 975" & vbCrLf
                    str += "              MOB: 5500 3178" & vbCrLf
                Case CENTURY
                    str = "                 CENTURY BAZAAR" & vbCrLf
                    str += "        TEL: 239 15 844/5" & vbCrLf
            End Select
            str += ConvertSize("BILL # " & BillNumber, 11, False) & ConvertSize("POS # " & CLS_Config.Counter, 29, True) & vbCrLf
            str += "ITEMS                 QTY   RATE  AMOUNT" & vbCrLf
            str += "----------------------------------------" & vbCrLf

            Dim pd As New PrintDialog()
            pd.PrinterSettings.PrinterName = CLS_Config.ReceiptPrinter
            RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, str)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub PrintItem(Optional ByVal Deleting As Boolean = False)
        Try
            Dim str As String = ""
            str = ConvertSize(P_ItemName.ToUpper, 22, False) & " "
            str += ConvertSize(P_Qty.ToUpper, 4, False)
            str += ConvertSize(P_Rate.ToUpper, 6, False)
            If Deleting Then
                str += ConvertSize("-" & P_Price.ToUpper, 7, False) & vbCrLf
            Else
                str += ConvertSize(" " & P_Price.ToUpper, 7, False) & vbCrLf
            End If

            Dim pd As New PrintDialog()
            ' Open the printer dialog box, and then allow the user to select a printer.
            pd.PrinterSettings.PrinterName = CLS_Config.ReceiptPrinter
            RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, str)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub PrintFooter()
        Try

            Dim str As String = ""
            str = "----------------------------------------" & vbCrLf
            str += ConvertSize("TOTAL QTY : ", 22, True) & " "
            str += ConvertSize(Get_Grid_Total(Me.grdList, "Quantity").ToString, 3, False)
            str += ConvertSize("", 7, False)
            str += ConvertSize(ConvertToString(CLS_Sale.TotalBill), 6, False) & vbCrLf




            Select Case CLS_Sale.TransectionType
                Case TransectionType.CashSale
                    Dim Pay_Type As String = Nothing
                    Select Case CLS_Sale.PaymentType
                        Case PaymentType.Cash : Pay_Type = "CASH"
                        Case PaymentType.KNet : Pay_Type = "KNET"
                        Case PaymentType.MasterCard : Pay_Type = "MASTER"
                    End Select

                    str += ConvertSize("CASH SALE", 40, False) & vbCrLf

                    If CDec(Me.txtDiscount.Value) > 0 Then
                        str += ConvertSize("DISCOUNT ", 33, False)
                        str += ConvertSize(ConvertToString(CDec(CLS_Sale.Discount)), 6, True) & vbCrLf
                    End If

                    str += ConvertSize("BILL AMOUNT", 33, False)
                    str += ConvertSize(ConvertToString(CDec(CLS_Sale.NetBill)), 6, True) & vbCrLf

                    str += ConvertSize(Pay_Type & " PAID ", 33, False)
                    str += ConvertSize(ConvertToString(CDec(CLS_Sale.Payment)), 6, True) & vbCrLf


                    str += ConvertSize("BALANCE ", 33, False)
                    str += ConvertSize(ConvertToString(CLS_Sale.Balance), 6, True) & vbCrLf

                Case TransectionType.CreditSale

                    str += ConvertSize("CREDIT SALES ", 40, False) & vbCrLf

                    If CDec(Me.txtDiscount.Value) > 0 Then
                        str += ConvertSize("DISCOUNT ", 33, False)
                        str += ConvertSize(ConvertToString(CDec(CLS_Sale.Discount)), 6, True) & vbCrLf

                        str += ConvertSize("BILL AMOUNT", 33, False)
                        str += ConvertSize(ConvertToString(CDec(CLS_Sale.NetBill)), 6, True) & vbCrLf
                    End If

                    str += ConvertSize("CUSTOMER ID: " & CLS_Sale.CustomerNum, 40, False) & vbCrLf
                    str += ConvertSize("CUSTOMER NAME: " & CLS_Sale.CustomerName, 40, False) & vbCrLf

                    Dim CLS_ACC As New Account
                    CLS_ACC.Select_Customer(CLS_Sale.CustomerNum, Null_Date)
                    str += ConvertSize("BALANCE: " & ConvertToString(CDec(CLS_ACC.Balance)), 40, False) & vbCrLf

                Case TransectionType.CashSaleReturn

                    str += ConvertSize("CASH SALES RETURN", 40, False) & vbCrLf

                Case TransectionType.CreditSaleReturn

                    str += ConvertSize("CREDIT SALES RETURN", 40, False) & vbCrLf

                    str += ConvertSize("CUSTOMER ID: " & CLS_Sale.CustomerNum, 40, False) & vbCrLf
                    str += ConvertSize("CUSTOMER NAME: " & CLS_Sale.CustomerName, 40, False) & vbCrLf

                    Dim CLS_ACC As New Account
                    CLS_ACC.Select_Customer(CLS_Sale.CustomerNum, Null_Date)
                    str += ConvertSize("BALANCE: " & ConvertToString(CDec(CLS_ACC.Balance)), 40, False) & vbCrLf

            End Select


            str += ConvertSize("       CASHIER: " & UserClass.UserName, 30, False) & vbCrLf
            str += ConvertSize("       THANK YOU ! VISIT AGAIN", 30, False) & vbCrLf
            str += ConvertSize("       " & Now.Date.ToString("dd/MMM/yy") & " " & Now.Hour.ToString & ":" & Now.Minute.ToString, 30, False) ' & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf


            Dim pd As New PrintDialog()
            ' Open the printer dialog box, and then allow the user to select a printer.
            pd.PrinterSettings.PrinterName = CLS_Config.ReceiptPrinter
            RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, str)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub PrintHold()
        Try
            Dim str As String = ""
            str = ConvertSize("TOTAL QTY : ", 22, True) & " "
            str += ConvertSize(Get_Grid_Total(Me.grdList, "Quantity").ToString, 3, False)
            str += ConvertSize("", 7, False)
            str += ConvertSize(ConvertToString(Me.txtNetBill.Value), 6, False) & vbCrLf
            str += "------------------HOLD------------------" & vbCrLf

            Dim pd As New PrintDialog()
            ' Open the printer dialog box, and then allow the user to select a printer.
            pd.PrinterSettings.PrinterName = CLS_Config.ReceiptPrinter
            RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, str)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Print_Big_Bill(ByVal SaleCode As Integer)
        Try
            Dim DT As New DataTable
            DT = DBO.ReturnDataTable("SELECT * FROM Sales_Full_View Where SaleCode=" & CInt(SaleCode))

            Dim report2 As New ReportDocument
            report2.Load(CLS_Config.ReportPath & "Bill Detail.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)
            report2.SetDataSource(DT)

            report2.SetParameterValue("AccCashCustomer", FixObjectNumber(CLS_Config.AccCashCustomer))
            report2.SetParameterValue("CompanyName", FixObjectString(CLS_Config.CompanyName))
            report2.SetParameterValue("Address1", FixObjectString(CLS_Config.Address1))
            report2.SetParameterValue("Address2", FixObjectString(CLS_Config.Address2))
            report2.SetParameterValue("Address3", FixObjectString(CLS_Config.Address3))
            report2.SetParameterValue("Tel", FixObjectString(CLS_Config.Tel))
            report2.SetParameterValue("AmountInWords", DollarToString(DT.Rows(0).Item("NetBill")))

            report2.PrintOptions.PrinterName = CLS_Config.ReceiptPrinter
            report2.PrintToPrinter(1, False, 1, 1)

            'Dim CRV As New CrystalDecisions.Windows.Forms.CrystalReportViewer
            'CRV.ReportSource = report2
            'CRV.PrintReport()


        Catch ex As Exception
            MsgBox("Print_Big_Bill" & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region

    Private Sub DropItem_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DropItem.KeyDown
        Select Case e.KeyCode
            Case CLS_Config.K_ItemList
                Me.DropItem.Visible = False
                Me.DropItem.Value = Nothing
                Me.txtBarcode.Value = Nothing
                Me.txtBarcode.Focus()
                Me.txtBarcode.SelectAll()

            Case CLS_Config.K_Add, CLS_Config.K_Add2
                If FixControl(Me.DropItem) <> Nothing Then
                    Operation = OperationType.None
                    Me.txtBarcode.Value = Me.DropItem.Value
                    Me.DropItem.Visible = False
                    Me.DropItem.Value = Nothing

                    Dim CLS_Item As New Item
                    CLS_Item = Get_Item(CStr(Me.txtBarcode.Value))
                    If IsNothing(CLS_Item) Then
                        MsgBox("Invalid Item.")
                        Me.txtNotes.Text = "Invalid Item."
                    Else
                        Me.lblItemName.Text = CLS_Item.ItemName
                        If Not CostPrice_On Then Me.txtPrice.Value = CLS_Item.SalesPrice * 1000
                        If CostPrice_On Then Me.txtPrice.Value = CLS_Item.CostPrice * 1000
                        Default_Price = Me.txtPrice.Value
                        Me.txtPrice.SelectAll()
                        Me.txtPrice.Focus()
                    End If

                End If
            Case Keys.ControlKey + Keys.F1

        End Select
    End Sub
    Private Sub DropCustomer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DropCustomer.KeyDown
        Select Case e.KeyCode
            Case CLS_Config.K_CustomerList
                Me.DropCustomer.Visible = False
                Me.DropCustomer.Value = Nothing
                Me.txtBarcode.Value = Nothing
                Me.txtBarcode.Focus()
                Me.txtBarcode.SelectAll()

            Case CLS_Config.K_Add, CLS_Config.K_Add2
                If IsDBNull(Me.DropCustomer.Value) Or IsNothing(Me.DropCustomer.Value) Then
                ElseIf Me.DropCustomer.Value = Nothing Then
                Else

                    Me.txtBarcode.Value = Me.DropCustomer.Value
                    Me.DropCustomer.Visible = False
                    Me.DropCustomer.Value = Nothing
                    Me.txtBarcode.Focus()
                    Me.txtBarcode.SelectAll()

                    CLS_Sale.Payment = 0.0
                    CLS_Sale.PaymentType = PaymentType.Credit
                    Call_Tender()

                End If
            Case Keys.ControlKey + Keys.F1

        End Select
    End Sub


    Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Call_Add()
    End Sub

    Private Sub txtQuantity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQuantity.KeyDown
        Try
            If FixControl(Me.txtQuantity) = Nothing Then Exit Sub
            If e.KeyCode = Keys.Enter Then Me.btnAdd_Click(sender, e)
        Catch ex As Exception
            MsgBox("[txtQuantity_KeyDown]" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub txtPrice_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPrice.KeyDown
        Try
            'If FixControl(Me.txtPrice) = Nothing Then Exit Sub
            If e.KeyCode = Keys.Enter Then
                If FixControl(Me.txtPrice) <> Default_Price Then DY_Price = True
                Default_Price = Nothing
                Me.txtQuantity.SelectAll()
                Me.txtQuantity.Focus()
            End If
        Catch ex As Exception
            MsgBox("[txtPrice_KeyDown]" & vbCrLf & ex.Message)
        End Try
    End Sub

End Class