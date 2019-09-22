Imports POS.FixControls
Imports System.Drawing.Printing
Imports CrystalDecisions.CrystalReports.Engine
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Imports System.IO
Imports theNext.UC

Public Class frmSales

#Region " LOCAL VARIABLES "

    Dim DS As New DataSet
    Dim CLS_Sale_Entry As New Sale_Entry
    Dim CLS_Sale As New Sale
    Dim LastEnteredItem As Integer = Nothing
    Dim LastEnteredItemPrice As Decimal = Nothing
    Dim isNewBill As Boolean = True
    Dim Operation As OperationType = OperationType.None
    Dim DY_Price As Boolean = False
    Dim Hold_array As New ArrayList
    Dim PrintDelete As Boolean = True
    Dim isSalesReturn As Boolean = False
    Dim Default_Price As Decimal = 0.0
    Dim Delete_Count As Integer = 0
    Dim Delete_Count_Limit As Integer = 2
    Dim EDITIGN_BILL As Integer = 0
    Dim EDITIGN_Old_Amt As Decimal = 0.0
    Dim HOLD_BILL_NO As Integer = 0
    Dim HOLD_BILL_DATE As DateTime

    '' ''Dim LastDisplayText As String = Nothing
    '' ''Dim NewDisplayText As String = Nothing
    Dim Pole As New DisplayPole

#End Region

    Public Sub New(_isSalesReturn As Boolean)

        If CLS_Config.ShowImage Then
            Threading.Thread.CurrentThread.CurrentUICulture = New Globalization.CultureInfo("en-IN")
        Else
            Threading.Thread.CurrentThread.CurrentUICulture = New Globalization.CultureInfo("en")
        End If

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        isSalesReturn = _isSalesReturn
    End Sub

    Private Sub frmSales_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.grdList.Rows.Count > 0 Then
            Call_Cancel(TransectionType.Sales_Cancel, 0)
        End If
        '''If EDITIGN_BILL <> 0 Then BillNumber = CurrentBillNo
        '''BillNumber = BillNumber - 1
        frmSalesIns = Nothing
    End Sub

    Private Sub frmSales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Me.txtBalance.Appearance.BackColor = Color.SteelBlue
            Me.txtNetBill.Appearance.BackColor = Color.Red
            Me.txtBillNo.Appearance.BackColor = Color.Yellow
            Me.txtQuantity.Appearance.BackColor = Color.Chartreuse
            Me.txtTotal.Appearance.BackColor = System.Drawing.Color.Aqua
            Me.txtPrice.Appearance.BackColor = Color.Pink ' System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
            Me.txtBarcode.Appearance.BackColor = System.Drawing.Color.Yellow
            Me.txtNotes.Appearance.ForeColor = System.Drawing.Color.Red
            Me.txtBalance.Appearance.BackColor = System.Drawing.Color.SteelBlue

            Me.grdList.DisplayLayout.Override.RowAlternateAppearance = RowAlternateAppearance

            If isSalesReturn Then
                MenuStrip2.Enabled = False
                MenuStrip1.Enabled = False
                Me.Text = "SALES RETURN"
            Else
                Me.Text = "SALES"
            End If


            'SET DisplayPole
            Select Case CLS_Config.Company
                Case INDIAGATE : Pole.CompanyName = "INDIA GATE"
                Case OsmanSM : Pole.CompanyName = "OSMAN SUPER MARKET"
                Case EDEE : Pole.CompanyName = "EDEE SUPER MARKET"
                Case BOOKSHOP : Pole.CompanyName = "EDEE BOOK SHOP"
                Case ZAHRABAKALA : Pole.CompanyName = "NOOR AL ZAHRA BAKALA"
                Case CENTURY : Pole.CompanyName = "CENTURY BAZAAR"
                Case MoveNPick : Pole.CompanyName = "M & P"
            End Select

            Pole.DisplayMethod = CLS_Config.DisplayPole_Method
            Pole.ComPort = CLS_Config.ComPort
            Pole.PortMax = PortMax

            'Pole.Send_To_Port("frmSales_Load !!!!", "")
            Pole.ClearMessage()

            If CLS_Config.Company = ZAHRABAKALA Then frmMainIns.PrintOnOff(False)
            Me.UltraGroupBox1.Visible = False

            Me.txtTotalBill.InputMask = Mask_Amount5
            Me.txtDiscount.InputMask = Mask_Amount5
            Me.txtPayment.InputMask = Mask_Amount5
            Me.txtNetBill.InputMask = Mask_Amount5
            Me.txtBalance.InputMask = Mask_Amount5

            KPrice.Text = "Price [" & CLS_Config.K_Price_S & "]"
            KMultiply.Text = "Quantity [" & CLS_Config.K_Multiply_S & "]"
            KCash.Text = "Cash [" & CLS_Config.K_Cash_S & "]"
            KKnet.Text = "Knet [" & CLS_Config.K_Knet_S & "]"
            KMaster.Text = "Master [" & CLS_Config.K_MasterVisa_S & "]"
            KCreditSale.Text = "Credit [" & CLS_Config.K_Credit_Sale_S & "]"
            KDelete.Text = "Delete [" & CLS_Config.K_Delete_S & "]"
            KEditBill.Text = "Edit [" & CLS_Config.K_EditBill_S & "]"
            KRemark.Text = "Remark [" & CLS_Config.K_Remark_S & "]"
            KCustomerList.Text = "Customer List [" & CLS_Config.K_CustomerList_S & "]"
            KItemList.Text = "Item List [" & CLS_Config.K_ItemList_S & "]"
            KDiscount.Text = "Discount [" & CLS_Config.K_Discount_S & "]"
            KDiscountPer.Text = "Discount % [" & CLS_Config.K_Discount_Per_S & "]"
            KPrint.Text = "Print [" & CLS_Config.K_Print_S & "]"
            KRepeat.Text = "Repeat [" & CLS_Config.K_Repeat_S & "]"
            KHold.Text = "Hold [" & CLS_Config.K_Hold_S & "]"
            KOpenItem.Text = "OpenItem [" & CLS_Config.K_Open_Item_S & "]"
            KBalance.Text = "Balance [" & CLS_Config.K_Balance_S & "]"
            KSalesReturn.Text = "Sales Return [" & CLS_Config.K_SalesReturn_S & "]"
            KPayment.Text = "Payment [" & CLS_Config.K_Payment_S & "]"
            KClearBox.Text = "Clear Box [" & CLS_Config.K_ClearBox_S & "]"
            KClear.Text = "Clear [" & CLS_Config.K_Clear_S & "]"
            KClose.Text = "Close [" & CLS_Config.K_Close_S & "]"
            KReprint.Text = "Reprint [" & CLS_Config.K_Reprint_S & "]"
            btnShowMenu.Text = "Show/Hide Menu"

            FillDrop(Me.DropPurchase_EntryCode, "SerailNum", "Code", Table.Purchase_Entry)


            Me.DropItem.MaxDropDownItems = 25
            FillDropWithCondition(Me.DropCustomer, "Title", "AccountNum", Table.Account, "Code", , , , " WHERE AccountType = " & AccountType.Customer & " AND Code<>" & CLS_Config.AccCashCustomer)
            Me.DropCustomer.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend


            Select Case CLS_Config.Company
                Case INDIAGATE
                    Me.txtQuantity.InputMask = "nnn"
                Case Else
                    Me.txtQuantity.InputMask = "nnn.nnn"
            End Select

            Fill_Dataset()
            SetGridLayout()
            Clear_Bill(False)
            Clear_Bill_Total()

            If CLS_Config.NewSalesScreen Then
                Me.txtBarcode.TabIndex = 0
                Me.txtPrice.TabIndex = 1
                Me.txtQuantity.TabIndex = 2
                Me.txtTotal.TabIndex = 3


                Me.txtPrice.InputMask = "nnnnnn"
                Me.txtQuantity.InputMask = "nnnnnn"
                Me.txtTotal.InputMask = "nnnnnnnn"


                Me.txtQuantity.ReadOnly = False
                Me.txtQuantity.TabStop = True
                Me.txtPrice.ReadOnly = False
                Me.txtPrice.TabStop = True
                Me.txtTotal.ReadOnly = False
                Me.txtTotal.TabStop = True
                Me.gbxInput.Dock = DockStyle.Top
                Me.gbxInput.Height = 85


                'Me.lblItemName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))


                'Me.txtQuantity.InputMask = "nnnn"
                Me.txtQuantity.Width = 100

                Me.Panel1.Dock = DockStyle.Fill

                Me.txtBarcode.Top = 8
                Me.txtBarcode.Left = 12

                Me.UltraLabel1.Top = 8
                Me.UltraLabel1.Left = 380

                Me.txtPrice.Top = 8
                Me.txtPrice.Left = 450

                Me.UltraLabel2.Top = 8
                Me.UltraLabel2.Left = 556
                If CLS_Config.Company = RASLANI Then Me.UltraLabel2.Text = "Qty/Meter"

                Me.txtQuantity.Top = 8
                Me.txtQuantity.Left = 669 - 50
                If CLS_Config.Company = RASLANI Then Me.txtQuantity.Left = 669

                Me.lblTotal.Top = 8
                Me.lblTotal.Left = 770

                Me.txtTotal.Top = 8
                Me.txtTotal.Left = 830
                Me.txtTotal.Width = 120

                'Me.lblRemarks.Visible = False
                'Me.txtRemarks.Visible = True
                'Me.txtRemarks.Dock = DockStyle.Fill

            Else
                Me.txtQuantity.ReadOnly = True
                Me.txtQuantity.TabStop = False
                Me.txtPrice.ReadOnly = True
                Me.txtPrice.TabStop = False
                Me.txtTotal.Visible = False
                Me.lblTotal.Visible = False

                If CLS_Config.Company = CENTURY Then Me.txtQuantity.InputMask = "nnn.n"

                Me.gbxInput.Dock = DockStyle.Bottom

                'Me.txtRemarks.Visible = False
                'Me.lblRemarks.Visible = True
                'Me.txtRemarks.Dock = DockStyle.Fill

            End If

            Me.lblRemarks.Visible = False
            Me.txtRemarks.Visible = True
            Me.txtRemarks.Dock = DockStyle.Fill

            '''BillNumber = BillNumber + 1
            '''Me.txtBillNo.Text = BillNumber

            'DisplayPole_Message()

            '' ''If CLS_Config.Has_New_Display_Pole Then
            '' ''    Me.Timer1.Interval = 60000
            '' ''    Me.Timer1.Enabled = True
            '' ''End If


            If CLS_Config.ShowImage Then
                gbxItem.Visible = True
                FlowSelectedItem.Visible = True
                GenerateCategory()
            Else
                gbxItem.Visible = False
                FlowSelectedItem.Visible = False
                UltraGroupBox4.Dock = DockStyle.Fill
            End If



        Catch ex As Exception
            MsgBox("[frmSales_Load]" & vbCrLf & ex.Message)
        End Try
    End Sub

#Region " GRID EVENT "

    Private Sub grdList_AfterPerformAction(sender As Object, e As Infragistics.Win.UltraWinGrid.AfterUltraGridPerformActionEventArgs) Handles grdList.AfterPerformAction

    End Sub

    Private Sub grdList_AfterRowActivate(sender As Object, e As EventArgs) Handles grdList.AfterRowActivate
        Try
            If Not CLS_Config.ShowImage Then Exit Sub

            Me.FlowSelectedItem.Controls.Clear()

            Dim ItemCode As Integer = TrimInt(Me.grdList.ActiveRow.Cells("ItemCode").Value)
            Dim ItemName As String = TrimStr(Me.grdList.ActiveRow.Cells("ItemName").Value)

            'BACK BUTTON
            Dim C As New Infragistics.Win.Misc.UltraButton
            C.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007ScrollbarButton
            C.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
            C.Appearance.BackColor = Color.Black
            C.Appearance.ForeColor = Color.White
            C.Name = ItemCode
            C.Width = 120
            C.Height = 120
            C.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            ToolTip1.SetToolTip(C, ItemName)

            Dim ImageName As String = ItemImagePath & ItemCode & ".jpg"
            If IO.File.Exists(ImageName) Then
                C.Text = Nothing
                C.Appearance.ImageBackground = Load_Img(ImageName)
                C.Appearance.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched
                'C.Appearance.ImageBackgroundOrigin = Infragistics.Win.ImageBackgroundOrigin.Client
            Else
                C.Text = ItemName
                C.Appearance.ForeColor = Color.White
                'C.Appearance.ImageBackground = My.Resources.no_picture
                C.Appearance.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched
                'C.Appearance.ImageBackgroundOrigin = Infragistics.Win.ImageBackgroundOrigin.Client
                C.Appearance.BackColor = Color.OrangeRed
                C.Appearance.ForeColor = Color.White
            End If

            AddHandler C.Click, AddressOf ActiveImageClick_Click
            Me.FlowSelectedItem.Controls.Add(C)
            'BACK BUTTON
        Catch ex As Exception
            MsgBox(ex.Message)
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
            e.Row.Cells("Type").Value = CLS_Sale_Entry.Type
            e.Row.Cells("Purchase_EntryCode").Value = CLS_Sale_Entry.Purchase_EntryCode
            e.Row.Cells("Notes").Value = CLS_Sale_Entry.Notes


            Me.UltraCalcManager1.DirtyAllFormulas()

            LastEnteredItem = CLS_Sale_Entry.ItemCode
            LastEnteredItemPrice = CLS_Sale_Entry.UnitPrice

            Dim q As String = Me.grdList.Rows.Count
            Select Case q.Length
                Case 0 : q = "00"
                Case 1 : q = "0" & q
            End Select

            Dim M1 As String = RTrim(e.Row.Cells("ItemName").Value, PortMax - 7) & ":" & LTrim(ConvertToString(e.Row.Cells("TotalPrice").Value), 6)
            Dim M2 As String = RTrim("Total:", PortMax - 6) & LTrim(ConvertToString(Get_Grid_Total(Me.grdList, "TotalPrice") - CDec(Me.txtDiscount.Value)), 6)
            Pole.Send_To_Port(M1, M2)

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

            e.Row.Activate()
            e.Row.Activated = False
            e.Row.Activated = True

        Catch ex As Exception
            MsgBox("[grdList_AfterRowInsert]" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub grdList_AfterRowsDeleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdList.AfterRowsDeleted
        Try

            Me.txtNotes.Text = Nothing
            Me.txtBarcode.SelectAll()
            Me.txtBarcode.Value = Nothing

            ReCalculate()

        Catch ex As Exception
            MsgBox("[grdList_AfterRowsDeleted]" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub grdList_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdList.BeforeRowsDeleted
        Try
            If Not UserClass.Allow_Sale_Detail_Delete And PrintDelete Then
                If Delete_Count >= Delete_Count_Limit Then
                    e.Cancel = True
                    Me.txtBarcode.Value = Nothing
                    Exit Sub
                End If
            End If

            Delete_Count += 1

            If Not PrintDelete Then Exit Sub

            Dim TotalPrice As Decimal = 0.0
            Dim Row As Infragistics.Win.UltraWinGrid.UltraGridRow
            For Each Row In e.Rows


                'cls_Card_Details = Get_CardDetails(Row.Cells("CardID").Value)

                P_ItemName = Row.Cells("ItemName").Value
                P_Qty = "- " & Row.Cells("Quantity").Value

                If Row.Cells("UnitPrice").Value >= 10.0 Then
                    P_Rate = ConvertToString(Row.Cells("UnitPrice").Value)
                Else
                    P_Rate = ConvertToString(Row.Cells("UnitPrice").Value, False)
                End If
                If Row.Cells("TotalPrice").Value >= 10.0 Then
                    P_Price = ConvertToString(Row.Cells("TotalPrice").Value)
                Else
                    P_Price = ConvertToString(Row.Cells("TotalPrice").Value, False)
                End If

                Dim prndoc As PrintDocument = New PrintDocument()
                PrintItem(True)

                TotalPrice += P_Price

                Dim M1 As String = RTrim(Row.Cells("ItemName").Value, PortMax - 8) & ":" & LTrim("-" & ConvertToString(Row.Cells("UnitPrice").Value), 7)
                ReCalculate()
                Dim M2 As String = RTrim("Total:", PortMax - 6) & LTrim(ConvertToString(Get_Grid_Total(Me.grdList, "TotalPrice") - CDec(Me.txtDiscount.Value) - TotalPrice), 6)
                Pole.Send_To_Port(M1, M2)

                PlaySoundFile("notify.wav")

                Me.txtNotes.Text = Nothing
                Me.txtBarcode.SelectAll()
                Me.txtBarcode.Value = Nothing

                ReCalculate()
            Next


        Catch ex As Exception
            MsgBox("[grdList_BeforeRowsDeleted]" & vbCrLf & ex.Message)
        End Try
    End Sub

#End Region

    Private Sub txtBarcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBarcode.KeyDown
        Try


            If in_Key_No_List(e.KeyCode) Then
                Me.txtBarcode.Value = Nothing
                Exit Sub
            End If

            Select Case e.KeyCode
                Case Keys.Decimal, Keys.OemPeriod
                    If TrimStr(Me.txtBarcode.Value) = "." Then
                        Operation = OperationType.Edit
                        Me.txtNotes.Text = "Type/Scan Sales Code And Press Enter"
                    End If
                Case CLS_Config.K_Reprint
                    Call_Reprint()
                Case CLS_Config.K_Remark
                    'Dim Remark As String = InputBox("Remark", "Remarks", CLS_Sale.Remark)
                    'If IsDBNull(Remark) Or IsNothing(Remark) Then
                    'ElseIf Remark = Nothing Then
                    'Else
                    '    CLS_Sale.Remark = Remark
                    '    Me.lblRemarks.Text = CLS_Sale.Remark
                    '    Me.txtRemarks.Text = CLS_Sale.Remark
                    'End If
                    Me.txtRemarks.Focus()
                    'EDIT BILL
                Case CLS_Config.K_EditBill
                    Operation = OperationType.Open_Edit
                    Me.txtBarcode.Value = Nothing
                    Me.txtBarcode.SelectAll()
                    Me.txtBarcode.Focus()
                    Me.txtNotes.Text = "Type Bill# & Press Enter OR scan Bill "
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
                    Call_Cancel(TransectionType.Sales_Cancel, 0)
                    'CLEAR BOX
                Case CLS_Config.K_ClearBox
                    Me.txtPrice.Value = Nothing
                    Me.txtTotal.Value = Nothing
                    Me.txtQuantity.Value = 1
                    Me.txtNotes.Text = Nothing
                    DY_Price = False
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
                    If Me.txtBarcode.Value / CurrencyBase > Me.txtTotalBill.Value Then
                        Me.txtNotes.Text = "Discount Should be less then " & ConvertToString(CDec(Me.txtTotalBill.Value))
                        Exit Select
                    End If

                    Me.txtDiscount.Value = CDec(Me.txtBarcode.Value / CurrencyBase)
                    Me.txtBarcode.Value = Nothing
                    '
                    'DISCOUNT PERCENTAGE
                Case CLS_Config.K_Discount_Per
                    If IsDBNull(Me.txtTotalBill.Value) Or IsNothing(Me.txtTotalBill.Value) Then Exit Select
                    If IsDBNull(Me.txtBarcode.Value) Or IsNothing(Me.txtBarcode.Value) Then Exit Select
                    If Me.txtTotalBill.Value = Nothing Then Exit Select
                    If Me.txtBarcode.Value = Nothing Then Exit Select
                    If Not IsNumeric(Me.txtBarcode.Value) Then Exit Select
                    If Not IsNumeric(Me.txtTotalBill.Value) Then Exit Select
                    If Me.txtBarcode.Value > 100 Then
                        Me.txtNotes.Text = "Discount % Should be less then 100"
                        Exit Select
                    End If

                    Me.txtDiscount.Value = CDec(Me.txtBarcode.Value / 100) * Me.txtTotalBill.Value
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
                    Me.txtPrice.Value = LastEnteredItemPrice * CurrencyBase
                    DY_Price = True
                    Call_Add()
                    Me.txtQuantity.Value = 1
                    '
                    'DELETE
                Case CLS_Config.K_Delete, CLS_Config.K_Delete2
                    Call_Delete()
                    '
                    'Credit_Sale
                Case CLS_Config.K_Credit_Sale
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
                    CLS_Sale.Payment = Decimal.Round(CDec(FixControl(Me.txtBarcode)) / CurrencyBase, 3)
                    CLS_Sale.PaymentType = PaymentType.Cash
                    Call_Tender()
                    '
                    'KNET
                Case CLS_Config.K_Knet
                    If IsDBNull(Me.txtBarcode.Value) Or IsNothing(Me.txtBarcode.Value) Then Exit Select
                    If Me.txtBarcode.Value = Nothing Then Exit Select
                    If Not IsNumeric(Me.txtBarcode.Value) Then Exit Select
                    CLS_Sale.Payment = Decimal.Round(CDec(FixControl(Me.txtBarcode)) / CurrencyBase, 3)
                    CLS_Sale.PaymentType = PaymentType.KNet
                    Call_Tender()
                    '
                    'MASTER VISA
                Case CLS_Config.K_MasterVisa
                    If IsDBNull(Me.txtBarcode.Value) Or IsNothing(Me.txtBarcode.Value) Then Exit Select
                    If Me.txtBarcode.Value = Nothing Then Exit Select
                    If Not IsNumeric(Me.txtBarcode.Value) Then Exit Select
                    CLS_Sale.Payment = Decimal.Round(CDec(FixControl(Me.txtBarcode)) / CurrencyBase, 3)
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
                        Case OperationType.Open_Edit
                            If Not IsNumeric(FixControl(Me.txtBarcode)) Then
                                Me.txtNotes.Text = Nothing
                                MsgBox("Invalid bill #")
                                Me.txtBarcode.Value = Nothing
                                Me.txtBarcode.Focus()
                                Me.txtBarcode.SelectAll()
                                Operation = OperationType.None
                                Exit Sub
                            Else
                                Dim SalesCode As Integer = CLS_Sale.Get_SalesCode(FixControl(Me.txtBarcode))
                                If FixObjectNumber(SalesCode) = 0 Then
                                    Me.txtNotes.Text = Nothing
                                    MsgBox("Invalid bill #")
                                    Me.txtBarcode.Value = Nothing
                                    Me.txtBarcode.Focus()
                                    Me.txtBarcode.SelectAll()
                                    Operation = OperationType.None
                                    Exit Sub
                                End If
                                Call_Edit(SalesCode, Printer_On)
                            End If
                        Case OperationType.Info : Call_Info()
                        Case OperationType.Open_Item : Call_Item()
                        Case OperationType.Edit
                            Dim SalesCode As Integer = FixControl(Me.txtBarcode).Substring(2)
                            If Not IsNumeric(SalesCode) OrElse SalesCode = 0 Then
                                Me.txtNotes.Text = "Invalid Sales Code."
                            Else
                                Call_Edit(SalesCode, Printer_On)
                            End If
                        Case Else

                            If CLS_Config.NewSalesScreen Then
                                Dim CLS_Item As New Item
                                CLS_Item = Get_Item(CStr(Me.txtBarcode.Value))
                                If IsNothing(CLS_Item) Then
                                    MsgBox("Invalid Item.")
                                    Me.txtNotes.Text = "Invalid Item."
                                Else
                                    Me.lblItemName.Text = CLS_Item.CostPrice & " - " & CLS_Item.ItemName & " [" & TrimDec(CLS_Item.Stock) & "]"
                                    Me.lblItemName2.Text = CLS_Item.Notes
                                    If CostPrice_On Then
                                        Me.txtPrice.Value = CLS_Item.CostPrice * CurrencyBase
                                    Else
                                        If TrimBoolean(CLS_Item.onPromo) Then
                                            Me.txtPrice.Value = CLS_Item.PromoPrice * CurrencyBase
                                        Else
                                            Me.txtPrice.Value = CLS_Item.SalesPrice * CurrencyBase
                                        End If
                                    End If

                                    Default_Price = Me.txtPrice.Value
                                    Me.txtPrice.SelectAll()
                                    Me.txtPrice.Focus()
                                End If
                            Else
                                Call_Add()
                                Me.txtQuantity.Value = 1
                            End If

                    End Select

            End Select

        Catch ex As Exception
            MsgBox("[txtBarcode_KeyDown]" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub txtBarcode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBarcode.KeyUp
        If in_Key_List(e.KeyCode) Then Me.txtBarcode.Value = Nothing
        If in_Key_No_List(e.KeyCode) Then Me.txtBarcode.Value = Nothing
        'If e.KeyCode = Keys.Add Then Me.txtBarcode.Value = Nothing
    End Sub

    Private Sub txtDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDate.ValueChanged
        Try
            If FixControl(Me.txtDate) = Null_Date Then Exit Sub
            Dim D As Date = CDate(Me.txtDate.Value)
            'CLS_Sale.TransectionDate = New Date(D.Year, D.Month, D.Day, Now.Hour, Now.Minute, Now.Second)
            If D.Hour = 0 Then
                CLS_Sale.TransectionDate = New Date(D.Year, D.Month, D.Day, Now.Hour, Now.Minute, Now.Second)
            Else
                CLS_Sale.TransectionDate = New Date(D.Year, D.Month, D.Day, D.Hour, D.Minute, D.Second)
            End If




            If CLS_Config.ResetReceiptYearly Then

                Dim f As New DateTime(D.Year, 1, 1, 4, 1, 0)
                Dim t As New DateTime(D.AddYears(1).Year, 1, 1, 4, 0, 0)

                Dim PARA As New ArrayList
                PARA.Add(CLS_Config.Counter)
                PARA.Add(f)
                PARA.Add(t)
                BillNumber = DBO.ExecuteSP_ReturnInteger("D_Counter_New_Bill", PARA)
            Else

                Dim f As New DateTime(D.Year, D.Month, D.Day, 4, 1, 0)
                Dim t As DateTime
                t = f.AddDays(1)
                t = t.AddMinutes(-1)


                Dim PARA As New ArrayList
                PARA.Add(CLS_Config.Counter)
                PARA.Add(f)
                PARA.Add(t)
                BillNumber = DBO.ExecuteSP_ReturnInteger("D_Counter_New_Bill", PARA)
            End If
            Me.txtBillNo.Text = IIf(CLS_Sale.BillNo = Nothing, BillNumber, CLS_Sale.BillNo)


        Catch ex As Exception
            MsgBox("[txtDate_ValueChanged]" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub Call_Info()
        Try
            Dim CLS As New Item
            CLS = Get_Item(CStr(Me.txtBarcode.Value))

            If IsNothing(CLS) Then
                Me.txtNotes.Text = "ITEM NOT FOUNT !!!" & vbCrLf
            Else
                CLS.ItemStock(CLS.Code)

                Me.txtNotes.Text = "ITEM NAME - " & RTrim(CLS.ItemName, 12) & vbCrLf
                Me.txtNotes.Text &= "COST - " & ConvertToString(CLS.CostPrice) & vbCrLf
                Me.txtNotes.Text &= "SALES - " & ConvertToString(CLS.SalesPrice) & vbCrLf

                If CLS.CostPrice = 0 Or CLS.SalesPrice = 0 Then
                Else
                    Me.txtNotes.Text &= "Margin - " & Decimal.Round(CDec(((CLS.SalesPrice - CLS.CostPrice) * 100) / CLS.CostPrice), 3) & " %" & vbCrLf
                End If

                If TrimBoolean(CLS.onPromo) Then
                    Me.txtNotes.Text &= "PROMO - " & ConvertToString(CLS.PromoPrice) & vbCrLf
                End If
                Me.txtNotes.Text &= "IN STOCK - " & ConvertToString(CLS.Stock)

                Dim M1 As String = RTrim(CLS.ItemName & ":", PortMax - 6) & LTrim(ConvertToString(CLS.SalesPrice), 6)
                Pole.Send_To_Port(M1, "")

            End If

            Operation = OperationType.None

        Catch ex As Exception
            MsgBox("[Call_Info]" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub Call_Price()
        Try
            If IsNumeric(Me.txtBarcode.Value) Then
                If (CLS_Config.DecimalPlace = 3 Or CLS_Config.DecimalPlace = 2) And (CInt(Me.txtBarcode.Value) Mod 5 <> 0 Or CInt(Me.txtBarcode.Value) < 5) Then
                    Me.txtNotes.Text = "Invaid Price !!!."
                    DY_Price = False
                    'play sound
                    PlaySoundFile("notify.WAV")
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
                If br.Length = ChrWeightItemBarcodeLength Then
                    'Dim Type As String = br.Substring(0, 4)
                    Dim ItemCode As String = Nothing
                    'Select Case CLS_Config.Company
                    '    Case MoveNPick
                    '        ItemCode = br.Substring(1, 2)
                    '        CLS_Item = Get_Item(CStr(ItemCode), True)
                    '        If IsNothing(CLS_Item) Then
                    '           ItemCode = br.Substring(0, 7)
                    '        End If
                    '    Case Else
                    '        ItemCode = br.Substring(0, 7)
                    'End Select
                    'ItemCode = br.Substring(0, 7)
                    ItemCode = br.Substring(ChrWeightItemStrat, ChrWeightItemLength)

                    CLS_Item = Get_Item(CStr(ItemCode), False)
                    If IsNothing(CLS_Item) Then
                        'play sound
                        PlaySoundFile("notify.wav")
                        Me.txtBarcode.Value = Nothing
                        MsgBox("Item Not Found !!!!!")
                        Pole.Send_To_Port("Item Not Found !!!!", "")
                        Exit Try
                    Else
                        'Me.txtPrice.Value = CType(br.Substring(7, 5), Decimal)
                        Me.txtPrice.Value = CType(br.Substring(ChrWeightPriceStart, ChrWeightPriceLength), Decimal)

                        '1 is in case if they dont consider Sales Price in DB else below formula will work for calculating qty 
                        Me.txtQuantity.Value = 1 'Math.Round((CType(Me.txtPrice.Value, Decimal) / (CLS_Item.SalesPrice * 1000)), 3)
                        DY_Price = True
                    End If
                Else
                    'play sound
                    PlaySoundFile("notify.wav")
                    Me.txtBarcode.Value = Nothing
                    MsgBox("Item Not Found !!!!!")
                    Pole.Send_To_Port("Item Not Found !!!!", "")
                    Exit Try
                End If
            End If


            If Not IsNothing(CLS_Item) Then

                If TrimBoolean(CLS_Item.onPromo) Then
                    If (CLS_Item.PromoPrice <= 0.01) And (FixControl(Me.txtPrice) = Nothing Or FixControl(Me.txtPrice) <= 10) Then Exit Try
                Else
                    If (CLS_Item.SalesPrice <= 0.01) And (FixControl(Me.txtPrice) = Nothing Or FixControl(Me.txtPrice) <= 10) Then Exit Try
                End If


                If (CLS_Item.CostPrice <= 0.01) And CostPrice_On Then Exit Try

                If CLS_Item.ItemType = ItemType.Serail_Item Then

                    Find_Int = Nothing
                    Dim frm As New frmSerialList(CLS_Item.Code, isSalesReturn)
                    If frm.ShowDialog() <> Windows.Forms.DialogResult.Yes Then
                        'play sound
                        PlaySoundFile("notify.wav")
                        Me.txtBarcode.Value = Nothing
                        Me.txtQuantity.Value = 1
                        Me.txtPrice.Value = Nothing
                        Me.txtTotal.Value = Nothing
                        Me.txtBarcode.Focus()
                        MsgBox("Invalid Serial !!!!!")
                        Pole.Send_To_Port("Invalid Serial !!!!", "")
                        Exit Try
                    End If

                    For Each Row In Me.grdList.Rows
                        If Find_Int = TrimInt(Row.Cells("Purchase_EntryCode").Value) Then
                            'play sound
                            PlaySoundFile("notify.wav")
                            Me.txtBarcode.Value = Nothing
                            Me.txtQuantity.Value = 1
                            Me.txtPrice.Value = Nothing
                            Me.txtTotal.Value = Nothing
                            Me.txtBarcode.Focus()
                            MsgBox("Invalid Serial !!!!!")
                            Pole.Send_To_Port("Invalid Serial !!!!", "")
                            Exit Try
                        End If
                    Next
                    If Find_Int <> -1 Then CLS_Sale_Entry.Purchase_EntryCode = Find_Int

                End If


                'play sound
                PlaySoundFile("ding.wav")

                CLS_Sale_Entry.ItemCode = CLS_Item.Code
                If DY_Price Then
                    CLS_Sale_Entry.UnitPrice = Decimal.Round(CDec(Me.txtPrice.Value) / CurrencyBase, 3)
                Else
                    If CostPrice_On Then
                        CLS_Sale_Entry.UnitPrice = Decimal.Round(CLS_Item.CostPrice, 3)
                    Else
                        If TrimBoolean(CLS_Item.onPromo) Then
                            CLS_Sale_Entry.UnitPrice = Decimal.Round(CLS_Item.PromoPrice, 3)
                        Else
                            CLS_Sale_Entry.UnitPrice = Decimal.Round(CLS_Item.SalesPrice, 3)
                        End If
                    End If

                End If
                If FixControl(Me.txtQuantity) = Nothing Then Me.txtQuantity.Value = Me.txtQuantity.Value = 1
                CLS_Sale_Entry.Quantity = CDec(Me.txtQuantity.Value)
                CLS_Sale_Entry.TotalPrice = Decimal.Round(CDec(CLS_Sale_Entry.UnitPrice * CLS_Sale_Entry.Quantity), 3)
                CLS_Sale_Entry.ItemName = CLS_Item.ItemName
                CLS_Sale_Entry.Barcode = CLS_Item.Barcode
                CLS_Sale_Entry.Type = CLS_Item.Type

                If CLS_Item.CostMethod = CostMethod.CostFromMargin And CLS_Item.ProfitMargin > 0 Then
                    CLS_Sale_Entry.CostPrice = Decimal.Round(CDec((CLS_Sale_Entry.UnitPrice / (1 + (CLS_Item.ProfitMargin / 100)))), 3)
                Else
                    CLS_Sale_Entry.CostPrice = Decimal.Round(CLS_Item.CostPrice, 3)
                End If

                If CLS_Config.Company = RASLANI Then
                    If IsNothing(CLS_Sale_Entry.ItemCode) Or CLS_Sale_Entry.ItemCode = 0 Or _
                        IsNothing(CLS_Sale_Entry.UnitPrice) Or _
                        IsNothing(CLS_Sale_Entry.Quantity) Or CLS_Sale_Entry.Quantity = 0 Or _
                        IsNothing(CLS_Sale_Entry.TotalPrice) Then
                        'play sound
                        PlaySoundFile("notify.wav")
                        Me.txtBarcode.Value = Nothing
                        MsgBox("Invalid Entry !!!")
                        Me.txtNotes.Text = "Invalid Entry !!!"
                        Pole.Send_To_Port("Invalid Entry !!!", "")
                        Exit Try
                        Exit Try
                    End If
                Else
                    If IsNothing(CLS_Sale_Entry.ItemCode) Or CLS_Sale_Entry.ItemCode = 0 Or _
                    IsNothing(CLS_Sale_Entry.UnitPrice) Or CLS_Sale_Entry.UnitPrice = 0 Or _
                    IsNothing(CLS_Sale_Entry.Quantity) Or CLS_Sale_Entry.Quantity = 0 Or _
                    IsNothing(CLS_Sale_Entry.TotalPrice) Or CLS_Sale_Entry.TotalPrice = 0 Then
                        'play sound
                        PlaySoundFile("notify.wav")
                        Me.txtBarcode.Value = Nothing
                        MsgBox("Invalid Entry !!!")
                        Me.txtNotes.Text = "Invalid Entry !!!"
                        Pole.Send_To_Port("Invalid Entry !!!", "")
                        Exit Try
                        Exit Try
                    End If
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
    'Private Function getReturnSerialCode(ByVal ItemCode As Integer) As Integer

    '    Find_Int = Nothing
    '    Dim frm As New frmSerialList(ItemCode, True)
    '    If frm.ShowDialog() <> Windows.Forms.DialogResult.Yes Then
    '        getReturnSerialCode(ItemCode)
    '    Else
    '        Return Find_Int
    '    End If
    'End Function

    Private Sub Call_Tender()
        Try

            'Select Case CLS_Sale.TransectionType
            '    Case TransectionType.CreditSale, TransectionType.CreditSaleReturn, TransectionType.Hold
            '    Case Else
            '        Select Case CLS_Config.Company
            '            Case CENTURY
            '                open_cashdrawer()
            '                MsgBox("OPEN CASHDRAW 1st !!!")

            '        End Select
            'End Select

            If TrimInt(HOLD_BILL_NO) <> 0 AndAlso CLS_Sale.TransectionType <> TransectionType.Hold Then

                If HOLD_BILL_DATE.Year = Now.Year AndAlso HOLD_BILL_DATE.Month = Now.Month AndAlso HOLD_BILL_DATE.Day = Now.Day Then
                    Dim BN As Integer = BillNumber
                    CLS_Sale.BillNo = BillNumber
                    Me.txtDate.Value = Now
                    BillNumber = BN
                    Me.txtBillNo.Text = BN
                Else
                    CLS_Sale.BillNo = Nothing
                    Me.txtDate.Value = Now
                End If

            End If

            If Me.grdList.Rows.Count = 0 Then
                MsgBox("Item Missing !!!")
                Me.txtNotes.Text = "Item Missing !!!"
                Exit Sub
            End If


            Select Case CLS_Sale.TransectionType
                Case TransectionType.CashSaleReturn, TransectionType.CreditSaleReturn
                Case Else
                    If isSalesReturn Then
                        MsgBox("Only Sales Return Allowed !!!")
                        Me.txtNotes.Text = "Only Sales Return Allowed !!!"
                        Me.txtBarcode.Value = Nothing
                        Me.txtBarcode.Focus()
                        Exit Sub
                    End If
            End Select

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
                If CLS_Config.CompanyName = ZAHRABAKALA Then
                    If Not CLS_ACC.Select_Customer(Me.txtBarcode.Value, CLS_Sale.TransectionDate) Then
                        MsgBox("Invalid Customer Accout !!!")
                        Me.txtNotes.Text = "Invalid Customer Accout !!!"
                        Exit Sub
                    End If
                Else
                    If Not CLS_ACC.Select(Me.txtBarcode.Value, AccountType.Customer) Then
                        MsgBox("Invalid Customer Accout !!!")
                        Me.txtNotes.Text = "Invalid Customer Accout !!!"
                        Exit Sub
                    End If
                End If


                If CLS_Sale.TransectionType = TransectionType.CreditSaleReturn Then
                    If MsgBox("Sale Return of [" & ConvertToString(CDec(Me.txtNetBill.Value)) & "] for CUSTOMER NAME [ " & CLS_ACC.Title & " ]", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub
                    CLS_Sale.CustomerCode = CLS_ACC.Code
                    CLS_Sale.CustomerNum = CLS_ACC.AccountNum
                    CLS_Sale.CustomerName = CLS_ACC.Title
                Else
                    If CLS_ACC.TimeLimit > -1 Then
                        Dim MonthStart As New DateTime(CLS_Sale.TransectionDate.Year, CLS_Sale.TransectionDate.Month, 1)
                        Dim CurrentLimit As Integer = DateDiff(DateInterval.Day, MonthStart, CLS_Sale.TransectionDate) + 1

                        If CurrentLimit > CLS_ACC.TimeLimit And CLS_ACC.BalancePrvMonth > 0 Then
                            If MessageBox.Show("TIME LIMIT [ " & CLS_ACC.TimeLimit & " ] DAYS " & vbCrLf & vbCrLf & _
                                                "EXCEED BY  [ " & CurrentLimit - CLS_ACC.TimeLimit & " ] DAYS" & vbCrLf & vbCrLf & _
                                                "CUSTOMER NAME [ " & CLS_ACC.Title & " ]" & vbCrLf & vbCrLf & _
                                                "DO YOU STILL WANT TO CONTINUE CREDIT SALE?", _
                                                "TIME LIMIT EXCEED", _
                                                MessageBoxButtons.YesNo, _
                                                MessageBoxIcon.Information, _
                                                MessageBoxDefaultButton.Button2) <> MsgBoxResult.Yes Then Exit Sub
                        End If
                    End If

                    If CLS_ACC.AmountLimit > -1 Then

                        If CLS_ACC.Balance + Decimal.Round(CDec(FixControl(Me.txtNetBill)), 3) > CLS_ACC.AmountLimit Then
                            If MessageBox.Show("AMOUNT LIMIT [ " & ConvertToString(CDec(CLS_ACC.AmountLimit), False) & " KD ]" & vbCrLf & vbCrLf & _
                                                "EXCEED BY [ " & ConvertToString(CDec(CLS_ACC.Balance + Decimal.Round(CDec(FixControl(Me.txtNetBill)), 3) - CLS_ACC.AmountLimit), False) & " KD ]" & vbCrLf & vbCrLf & _
                                                "CUSTOMER NAME [ " & CLS_ACC.Title & " ]" & vbCrLf & vbCrLf & _
                                                "DO YOU STILL WANT TO CONTINUE CREDIT SALE?", "TIME LIMIT EXCEED", _
                                                MessageBoxButtons.YesNo, _
                                                MessageBoxIcon.Information, _
                                                MessageBoxDefaultButton.Button2) <> MsgBoxResult.Yes Then Exit Sub
                        End If
                    End If



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


            If CLS_Sale.TransectionType = TransectionType.CashSale And _
                (CLS_Sale.PaymentType = PaymentType.KNet Or CLS_Sale.PaymentType = PaymentType.MasterCard) Then

                If CLS_Sale.Payment <> FixControl(Me.txtNetBill) Then
                    Dim KNET_Master As Decimal = CLS_Sale.Payment
                    Dim Cash As Decimal = FixControl(Me.txtNetBill) - CLS_Sale.Payment
                    If Cash < 0 Then
                        MsgBox("Invalid Amount !!!")
                        Me.txtNotes.Text = "Invalid Amount !!!"
                        Exit Sub
                    End If
                    If MsgBox("You are about to make a split payment." & vbCrLf & vbCrLf & "K-NET : " & ConvertToString(KNET_Master, False) & vbCrLf & "CASH : " & ConvertToString(Cash, False) & vbCrLf & vbCrLf & "Are you sure?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub

                    CLS_Sale.CashAmount = Cash
                    CLS_Sale.Payment = FixControl(Me.txtNetBill)
                    If CLS_Sale.PaymentType = PaymentType.KNet Then CLS_Sale.PaymentType = PaymentType.KNet_Cash
                    If CLS_Sale.PaymentType = PaymentType.MasterCard Then CLS_Sale.PaymentType = PaymentType.MasterCard_Cash

                End If

            End If

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

            If CLS_Sale.Code = 0 Then CLS_Sale.BillNo = BillNumber

            If TrimInt(HOLD_BILL_NO) <> 0 AndAlso CLS_Sale.TransectionType <> TransectionType.Hold Then CLS_Sale.BillNo = BillNumber


            If FixObjectNumber(CLS_Sale.NetBill) = 0 Then
                MsgBox("Invalid Transection")
                Me.txtNotes.Text = "Invalid Transection"
                Exit Sub
            End If


            Select Case CLS_Sale.TransectionType
                Case TransectionType.CreditSale, TransectionType.CreditSaleReturn, TransectionType.Hold
                Case Else
                    Select Case CLS_Config.Company
                        Case CENTURY
                            'If CLS_Config.Has_Print_Cut Then
                            If CLS_Config.Counter = 2 OrElse CLS_Config.Counter = 3 Then
                                open_cashdrawer()
                            Else
                                'PrintEmptySpace()
                            End If
                            'Else
                            'PrintEmptySpace()
                            'End If
                        Case BOOKSHOP
                            'open_cashdrawer()
                            'PrintEmptySpace() 'in bs by code works good
                        Case Else
                            open_cashdrawer()
                    End Select
                    'open_cashdrawer()
                    'If Printer_On Then PrintEmptySpace() '2/DEC/2013
            End Select

            If EDITIGN_BILL <> 0 Then CLS_Sale.Delete(EDITIGN_BILL)

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
                CLS.Type = Me.grdList.Rows(i).Cells("Type").Value
                CLS.Purchase_EntryCode = TrimInt(Me.grdList.Rows(i).Cells("Purchase_EntryCode").Value)
                CLS.Notes = TrimStr(Me.grdList.Rows(i).Cells("Notes").Value)
                CLS.Add(CLS_Sale.TransectionType)
            Next


            Select Case CLS_Sale.TransectionType
                Case TransectionType.CashSale
                    Dim M1 As String = RTrim("Total:", PortMax - 6) & LTrim(ConvertToString(CDec(Me.txtTotalBill.Value)), 6)
                    Dim M2 As String = RTrim("Balance:", PortMax - 6) & LTrim(ConvertToString(CDec(Me.txtBalance.Value)), 6)
                    Pole.Send_To_Port(M1, M2)
                Case TransectionType.CashSale
                    Dim M1 As String = RTrim("Total:", PortMax - 6) & LTrim(ConvertToString(CDec(Me.txtTotalBill.Value)), 6)
                    Dim M2 As String = ""
                    Pole.Send_To_Port(M1, M2)
            End Select

            Select Case CLS_Sale.TransectionType
                Case TransectionType.Hold
                    'Hold_array.Add(BillNumber)

                    Hold_array.Add(CLS_Sale.BillNo & ": " & CLS_Sale.TransectionDate.Day & "/" & CLS_Sale.TransectionDate.Month & ": " & CLS_Sale.Remark)
                    Me.txtHoldList.Text = "Bill On Hold" & vbCrLf & Convert_Array_To_String(Hold_array)
                    'Call_Cancel(TransectionType.Hold, CLS_Sale.Code)

                    PrintHold()
                Case Else
                    PrintFooter()
            End Select
            Select Case CLS_Sale.TransectionType
                Case TransectionType.CashSale, TransectionType.CreditSale, TransectionType.CashSaleReturn, TransectionType.CreditSaleReturn
                    Print_Big_Bill(CLS_Sale.Code)
            End Select
            'If CLS_Sale.TransectionType = TransectionType.CashSale Or CLS_Sale.TransectionType = TransectionType.CreditSale Then
            '    Print_Big_Bill(CLS_Sale.Code)
            'End If

            'Select Case CLS_Sale.TransectionType
            '    Case TransectionType.CreditSale, TransectionType.CreditSaleReturn, TransectionType.Hold
            '    Case Else
            '        open_cashdrawer()
            '        'If Printer_On Then PrintEmptySpace() '2/DEC/2013
            'End Select



            Clear_Bill(True)
            '''BillNumber = BillNumber + 1
            '''Me.txtBillNo.Text = BillNumber


        Catch ex As Exception
            MsgBox("[Call_Tender]" & vbCrLf & ex.Message)
        End Try
        Operation = OperationType.None
    End Sub

    Private Sub Call_Delete()
        Try
            If FixControl(Me.txtBarcode) = Nothing Then Exit Sub

            PrintDelete = True
            Dim flag As Boolean = False
            Dim i As Integer = 0
            For i = 0 To Me.grdList.Rows.VisibleRowCount - 1
                Dim sr = Me.grdList.Rows(i).Cells("Sr").Value
                If sr = Me.txtBarcode.Value Then
                    Me.grdList.Rows.GetRowAtVisibleIndex(i).Delete(False)
                    Exit For
                End If
            Next

        Catch ex As Exception
            MsgBox("[Call_Delete]" & vbCrLf & ex.Message)
        End Try
    End Sub

    'Private Sub Call_Delete()
    '    Try
    '        If Not UserClass.Allow_Sale_Detail_Delete Then Exit Sub
    '        If FixControl(Me.txtBarcode) = Nothing Then Exit Sub

    '        Dim flag As Boolean = False
    '        Dim i As Integer = 0
    '        'Dim cls_Card_Details As New CardDetails
    '        For i = 0 To Me.grdList.Rows.VisibleRowCount - 1
    '            Dim sr = Me.grdList.Rows(i).Cells("Sr").Value
    '            If sr = Me.txtBarcode.Value Then
    '                If Printer_On And Not CLS_Config.BigReceiprPrinter Then
    '                    'cls_Card_Details = Get_CardDetails(Me.grdList.Rows(i).Cells("CardID").Value)

    '                    P_ItemName = Me.grdList.Rows(i).Cells("ItemName").Value
    '                    P_Qty = "- " & Me.grdList.Rows(i).Cells("Quantity").Value

    '                    If Me.grdList.Rows(i).Cells("UnitPrice").Value >= 10.0 Then
    '                        P_Rate = ConvertToString(Me.grdList.Rows(i).Cells("UnitPrice").Value)
    '                    Else
    '                        P_Rate = ConvertToString(Me.grdList.Rows(i).Cells("UnitPrice").Value, False)
    '                    End If
    '                    If Me.grdList.Rows(i).Cells("TotalPrice").Value >= 10.0 Then
    '                        P_Price = ConvertToString(Me.grdList.Rows(i).Cells("TotalPrice").Value)
    '                    Else
    '                        P_Price = ConvertToString(Me.grdList.Rows(i).Cells("TotalPrice").Value, False)
    '                    End If

    '                    Dim prndoc As PrintDocument = New PrintDocument()
    '                    PrintItem(True)

    '                End If

    '                'Dim M1 As String = "- " & ConvertToString(Me.grdList.Rows(i).Cells("UnitPrice").Value)
    '                Dim M1 As String = RTrim(Me.grdList.Rows(i).Cells("ItemName").Value, PortMax - 8) & ":" & LTrim("-" & ConvertToString(Me.grdList.Rows(i).Cells("UnitPrice").Value), 7)

    '                Me.grdList.Rows(i).Delete(False)
    '                ReCalculate()
    '                'Dim M2 As String = "Total:" & ConvertToString(Me.txtNetBill.Value) & "       "
    '                'Dim M2 As String = RTrim("Total:", PortMax - 6) & LTrim(ConvertToString(Me.txtNetBill.Value), 6)
    '                Dim M2 As String = RTrim("Total:", PortMax - 6) & LTrim(ConvertToString(Get_Grid_Total(Me.grdList, "TotalPrice") - CDec(Me.txtDiscount.Value)), 6)

    '                Pole.Send_To_Port(M1, M2)
    '                flag = True
    '                Exit For
    '            End If
    '        Next
    '        If Not flag Then PlaySoundFile("notify.wav")

    '        Me.txtNotes.Text = Nothing
    '        Me.txtBarcode.SelectAll()
    '        Me.txtBarcode.Value = Nothing

    '        ReCalculate()

    '    Catch ex As Exception
    '        MsgBox("[Call_Delete]" & vbCrLf & ex.Message)
    '    End Try
    'End Sub

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
                PlaySoundFile("notify.wav")
                Exit Sub
            End If

            Dim CLS_ACC As New Account
            If Not CLS_ACC.Select_Customer(Me.txtBarcode.Value, Null_Date) Then
                MsgBox("Invalid Customer Accout !!!")
                Me.txtNotes.Text = "Invalid Customer Accout !!!"
                Exit Sub
            End If

            If CLS_Config.MonthBasePayment Then
                Me.txtNotes.Text = CLS_ACC.Title & vbCrLf
                Me.txtNotes.Text &= "BALANCE----" & ConvertToString(CLS_ACC.FinalBalance) & vbCrLf
                Me.txtNotes.Text &= "LAST MONTH-" & ConvertToString(CLS_ACC.BalancePrvMonth) & vbCrLf
                Me.txtNotes.Text &= "THIS MONTH-" & ConvertToString(CLS_ACC.BalanceCurrentMonth) & vbCrLf
                Me.txtNotes.Text &= "LAST BILL--" & ConvertToString(CLS_ACC.LastBill) & vbCrLf
            Else
                Me.txtNotes.Text = CLS_ACC.Title & vbCrLf
                Me.txtNotes.Text &= "BALANCE..." & ConvertToString(CLS_ACC.Balance) & vbCrLf
                Me.txtNotes.Text &= "LAST BILL.." & ConvertToString(CLS_ACC.LastBill) & vbCrLf
            End If

            'DISPLAY POLE
            Dim M1 As String = CLS_ACC.AccountNum & " " & CLS_ACC.Title
            Dim M2 As String = "ACCOUNT BAL :" & ConvertToString(CLS_ACC.Balance)
            Pole.Send_To_Port(M1, M2)

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
                If EDITIGN_BILL <> Nothing AndAlso CLS_Sale.TransectionType <> TransectionType.Hold Then
                    MsgBox("Edit bill can't be hold !!!" & vbCrLf & vbCrLf & "Save the bill and edit again")
                    Me.txtNotes.Text = "Edit bill can't be hold !!!"
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



                Dim tempDT As DataTable = DBO.ReturnDataTableFromSQL("SELECT Code,TransectionDate,Remark FROM dbo.Sale WHERE BillNo='" & FixControl(Me.txtBarcode) & "' AND TransectionType=3")
                If tempDT.Rows.Count = 1 Then
                    DT = CLS_Sale.SelectHold(Me.txtBarcode.Value, 0)
                Else

                    For t As Integer = 0 To tempDT.Rows.Count - 1
                        Dim Code As Integer = CInt(tempDT.Rows(t).Item("Code"))
                        Dim TransectionDate As Date = CDate(tempDT.Rows(t).Item("TransectionDate"))
                        Dim Remark As String = CStr(tempDT.Rows(t).Item("Remark"))

                        If MsgBox("Bill # " & Me.txtBarcode.Value & vbCrLf & _
                                    "Date : " & TransectionDate & vbCrLf & _
                                    "Remark : " & Remark, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            DT = CLS_Sale.SelectHold(Me.txtBarcode.Value, Code)
                            Exit For
                        End If

                        If t = tempDT.Rows.Count - 1 Then
                            Me.txtBarcode.SelectAll()
                            Exit Sub
                        End If
                    Next
                End If

                Dim HoldStr As String = CLS_Sale.BillNo & ": " & CLS_Sale.TransectionDate.Day & "/" & CLS_Sale.TransectionDate.Month & ": " & CLS_Sale.Remark

                CLS_Sale.TransectionType = TransectionType.CashSale
                'Me.lblRemarks.Text = CLS_Sale.Remark
                Me.txtRemarks.Value = CLS_Sale.Remark
                Me.txtPONumber.Value = CLS_Sale.PONumber
                'Select Case CLS_Config.Company
                '    Case ZAHRABAKALA
                '        Me.txtDate.Value = CLS_Sale.TransectionDate
                '        BillNumber = CLS_Sale.BillNo
                '    Case Else
                '        If CLS_Sale.TransectionDate.Year = Now.Year AndAlso CLS_Sale.TransectionDate.Month = Now.Month AndAlso CLS_Sale.TransectionDate.Day = Now.Day Then
                '            Me.txtDate.Value = Now
                '            BillNumber = CLS_Sale.BillNo
                '        Else
                '            CLS_Sale.BillNo = Nothing
                '            Me.txtDate.Value = Now
                '        End If
                'End Select
                Me.txtDate.Value = CLS_Sale.TransectionDate
                BillNumber = CLS_Sale.BillNo
                HOLD_BILL_NO = CLS_Sale.BillNo
                HOLD_BILL_DATE = CLS_Sale.TransectionDate



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

                Dim BillRemark As String = Nothing

                RemoveFromHold(HoldStr)
                'RemoveFromHold(Me.txtBarcode.Value)

                isNewBill = False
                Clear_Bill_Total()
                ReCalculate()
                New_Entry()

            End If
        Catch ex As Exception
            MsgBox("[Call_Hold]" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub RemoveFromHold(ByVal HoldBillNo As String)
        Dim isRemoved As Boolean = False
        Dim TempArr As New ArrayList
        Me.txtHoldList.Text = ""
        Dim q As Integer = 0
        For q = 0 To Hold_array.Count - 1
            Dim str = Hold_array(q)
            'str = str.ToString.Substring(0, str.ToString.IndexOf(": "))
            If str.ToUpper = Convert.ToString(HoldBillNo).ToUpper And Not isRemoved Then
                isRemoved = True
            Else
                TempArr.Add(Hold_array(q))
            End If
        Next
        Hold_array = TempArr

        If Hold_array.Count > 0 Then Me.txtHoldList.Text = "Bill On Hold" & vbCrLf & Convert_Array_To_String(Hold_array)
    End Sub

    Private Sub Call_SalesReturn()
        Try
            If Me.grdList.Rows.Count = 0 Then
                MsgBox("No item in bill for sales return !!!")
                Me.txtNotes.Text = "No item in bill for sales return !!!"
                New_Entry()
                Exit Sub
            End If

            If isSalesReturn = False Then
                For Each Row In Me.grdList.Rows
                    Dim ItemCode As Integer = TrimInt(Row.Cells("ItemCode").Value)
                    Dim ItemType As ItemType
                    Dim dr() As DataRow = DS.Tables(1).Select(" Code='" & ItemCode & "'")
                    If dr.Length > 0 Then
                        ItemType = IIf(IsDBNull(dr(0).Item("ItemType")), 1, dr(0).Item("ItemType"))
                    Else
                        ItemType = CodeModule.ItemType.StandardItem
                    End If



                    If ItemType = CodeModule.ItemType.Serail_Item AndAlso TrimInt(Row.Cells("Purchase_EntryCode").Value) <> 0 Then
                        'play sound
                        PlaySoundFile("notify.wav")
                        Me.txtBarcode.Value = Nothing
                        Me.txtQuantity.Value = 1
                        Me.txtPrice.Value = Nothing
                        Me.txtTotal.Value = Nothing
                        Me.txtBarcode.Focus()
                        MsgBox("Serail Item can only be returned from sales return from. !!!!!")
                        Pole.Send_To_Port("Invalid Serial !!!!", "")
                        Exit Try
                    End If
                Next
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

            If isSalesReturn Then Me.Close()

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

    Public Sub Call_Edit(ByVal SalesCode As Integer, ByVal local_Printer_On As Boolean)
        Try

            If Me.grdList.Rows.Count > 0 Then
                If MsgBox("Do you want to cancel current bill and load editing bill", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                    New_Entry()
                    Exit Sub
                End If
            End If

            Clear_Bill()

            frmMainIns.PrintOnOff(local_Printer_On)


            Dim DT As New DataTable
            DT = CLS_Sale.SelectEdit(SalesCode)
            Dim temp As New DateTime
            temp = CDate(CLS_Sale.TransectionDate)
            Me.txtDate.Value = CDate(CLS_Sale.TransectionDate)
            CLS_Sale.TransectionDate = temp

            '''CurrentBillNo = BillNumber
            BillNumber = CLS_Sale.BillNo
            Me.txtBillNo.Text = CLS_Sale.BillNo
            EDITIGN_BILL = CLS_Sale.Code
            EDITIGN_Old_Amt = CLS_Sale.NetBill
            'Me.lblRemarks.Text = CLS_Sale.Remark
            Me.txtRemarks.Value = CLS_Sale.Remark
            Me.txtPONumber.Value = CLS_Sale.PONumber

            If CLS_Sale.TransectionType = TransectionType.Hold Then
                RemoveFromHold(CLS_Sale.BillNo & ": " & CLS_Sale.TransectionDate.Day & "/" & CLS_Sale.TransectionDate.Month & ": " & CLS_Sale.Remark)
            Else
                CLS_Sale.TransectionType = TransectionType.CashSale
            End If
            CLS_Sale.CustomerCode = CLS_Config.AccCashCustomer

            Dim i As Integer = 0
            For i = 0 To DT.Rows.Count - 1
                CLS_Sale_Entry.ItemCode = DT.Rows(i).Item("ItemCode")
                CLS_Sale_Entry.Barcode = DT.Rows(i).Item("Barcode")
                CLS_Sale_Entry.ItemName = DT.Rows(i).Item("ItemName")
                CLS_Sale_Entry.UnitPrice = DT.Rows(i).Item("UnitPrice")
                CLS_Sale_Entry.Quantity = DT.Rows(i).Item("Quantity")
                CLS_Sale_Entry.TotalPrice = DT.Rows(i).Item("TotalPrice")
                CLS_Sale_Entry.CostPrice = DT.Rows(i).Item("CostPrice")
                CLS_Sale_Entry.CostPrice = Decimal.Round(CLS_Sale_Entry.CostPrice / CLS_Sale_Entry.Quantity, 3)
                CLS_Sale_Entry.Purchase_EntryCode = TrimInt(DT.Rows(i).Item("Purchase_EntryCode"))
                CLS_Sale_Entry.Notes = TrimStr(DT.Rows(i).Item("Notes"))

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

    Public Sub Call_Reprint()
        Try
            Dim SalesCode As Integer = Nothing

            If Not IsNumeric(FixControl(Me.txtBarcode)) Then
                Me.txtNotes.Text = "ENTER BILL # TO REPRINT"
                Me.txtBarcode.Focus()
                Exit Sub
            Else
                SalesCode = CLS_Sale.Get_SalesCode(FixControl(Me.txtBarcode))
                If FixObjectNumber(SalesCode) = 0 Then
                    Me.txtNotes.Text = "INVALID BILL #"
                    Me.txtBarcode.Focus()
                    Exit Sub
                End If
            End If


            If Me.grdList.Rows.Count > 0 Then
                If MsgBox("Do you want to cancel current bill before reprinting bill", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                    New_Entry()
                    Exit Sub
                End If
            End If

            Clear_Bill()

            frmMainIns.PrintOnOff(True)

            Dim DT As New DataTable
            DT = CLS_Sale.SelectEdit(SalesCode)
            Dim temp As New DateTime
            temp = CDate(CLS_Sale.TransectionDate)
            Me.txtDate.Value = CDate(CLS_Sale.TransectionDate)
            CLS_Sale.TransectionDate = temp

            '''CurrentBillNo = BillNumber
            BillNumber = CLS_Sale.BillNo
            Me.txtBillNo.Text = CLS_Sale.BillNo
            EDITIGN_BILL = CLS_Sale.Code
            EDITIGN_Old_Amt = CLS_Sale.NetBill
            'Me.lblRemarks.Text = CLS_Sale.Remark
            Me.txtRemarks.Value = CLS_Sale.Remark
            Me.txtPONumber.Value = CLS_Sale.PONumber

            'If CLS_Sale.TransectionType = TransectionType.Hold Then
            '    RemoveFromHold(CLS_Sale.BillNo & ": " & CLS_Sale.Remark)
            'Else
            '    CLS_Sale.TransectionType = TransectionType.CashSale
            'End If
            CLS_Sale.CustomerCode = CLS_Config.AccCashCustomer

            Dim i As Integer = 0
            For i = 0 To DT.Rows.Count - 1
                CLS_Sale_Entry.ItemCode = DT.Rows(i).Item("ItemCode")
                CLS_Sale_Entry.Barcode = DT.Rows(i).Item("Barcode")
                CLS_Sale_Entry.ItemName = DT.Rows(i).Item("ItemName")
                CLS_Sale_Entry.UnitPrice = DT.Rows(i).Item("UnitPrice")
                CLS_Sale_Entry.Quantity = DT.Rows(i).Item("Quantity")
                CLS_Sale_Entry.TotalPrice = DT.Rows(i).Item("TotalPrice")
                CLS_Sale_Entry.CostPrice = DT.Rows(i).Item("CostPrice")
                CLS_Sale_Entry.CostPrice = Decimal.Round(CLS_Sale_Entry.CostPrice / CLS_Sale_Entry.Quantity, 3)
                CLS_Sale_Entry.Purchase_EntryCode = TrimInt(DT.Rows(i).Item("Purchase_EntryCode"))
                CLS_Sale_Entry.Notes = TrimStr(DT.Rows(i).Item("Notes"))

                Me.grdList.DisplayLayout.Bands(0).AddNew()

            Next

            isNewBill = False
            Clear_Bill_Total()
            ReCalculate()
            New_Entry()



            Print_Big_Bill(SalesCode)
            PrintFooter()


            Clear_Bill(True)


        Catch ex As Exception
            MsgBox("[Call_Reprint]" & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub Call_Return(ByVal SalesCode As Integer, ByVal local_Printer_On As Boolean)
        Try
            frmMainIns.PrintOnOff(local_Printer_On)

            Dim DT As New DataTable
            DT = CLS_Sale.SelectEdit(SalesCode)
            Dim temp As New DateTime
            temp = CDate(CLS_Sale.TransectionDate)
            Me.txtDate.Value = CDate(CLS_Sale.TransectionDate)
            CLS_Sale.TransectionDate = temp

            Me.txtBillNo.Text = BillNumber 'CLS_Sale.BillNo
            CLS_Sale.BillNo = BillNumber
            CLS_Sale.ReturnSaleCode = SalesCode
            CLS_Sale.TransectionDate = Now

            Dim i As Integer = 0
            For i = 0 To DT.Rows.Count - 1
                CLS_Sale_Entry.ItemCode = DT.Rows(i).Item("ItemCode")
                CLS_Sale_Entry.Barcode = DT.Rows(i).Item("Barcode")
                CLS_Sale_Entry.ItemName = DT.Rows(i).Item("ItemName")
                CLS_Sale_Entry.UnitPrice = DT.Rows(i).Item("UnitPrice")
                CLS_Sale_Entry.Quantity = DT.Rows(i).Item("Quantity")
                CLS_Sale_Entry.TotalPrice = DT.Rows(i).Item("TotalPrice")
                CLS_Sale_Entry.CostPrice = DT.Rows(i).Item("CostPrice")
                CLS_Sale_Entry.CostPrice = Decimal.Round(CLS_Sale_Entry.CostPrice / CLS_Sale_Entry.Quantity, 3)
                CLS_Sale_Entry.Purchase_EntryCode = TrimInt(DT.Rows(i).Item("Purchase_EntryCode"))
                CLS_Sale_Entry.Notes = TrimStr(DT.Rows(i).Item("Notes"))
                Me.grdList.DisplayLayout.Bands(0).AddNew()
            Next

            isNewBill = True
            Clear_Bill_Total()
            ReCalculate()
            New_Entry()

            Me.txtDiscount.Value = CLS_Sale.Discount
            Me.txtNetBill.Value = CLS_Sale.NetBill



            If CLS_Sale.CustomerCode <> CLS_Config.AccCashCustomer Then
                Try
                    Using CONTEXT = New POSEntities
                        Dim A As New Account_
                        A = (From q In CONTEXT.Account_Set Where q.Code = CLS_Sale.CustomerCode Select q).ToList().SingleOrDefault()
                        Me.txtBarcode.Value = A.AccountNum
                    End Using
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Exit Sub
                End Try
            End If

            Call_SalesReturn()

        Catch ex As Exception
            MsgBox("[Call_Return]" & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub Call_Cancel(ByVal Trans_Type As TransectionType, ByVal HoldCode As Integer)
        Try
            CLS_Sale.Cancel(Trans_Type, HoldCode)
            Dim i As Integer = 0
            For i = 0 To Me.grdList.Rows.Count - 1
                Dim CLS As New Sale_Entry
                CLS.SaleCode = CLS_Sale.Code
                CLS.ItemCode = Me.grdList.Rows(i).Cells("ItemCode").Value
                CLS.UnitPrice = Me.grdList.Rows(i).Cells("UnitPrice").Value
                CLS.Quantity = Me.grdList.Rows(i).Cells("Quantity").Value
                CLS.TotalPrice = Me.grdList.Rows(i).Cells("TotalPrice").Value
                CLS.CostPrice = Me.grdList.Rows(i).Cells("CostPrice").Value
                CLS.Cancel(Trans_Type)
            Next

            PrintCancel()
            Clear_Bill(True)
            Clear_Bill_Total()

        Catch ex As Exception
            MsgBox("Call_Cencelled" & vbCrLf & ex.Message)
        End Try
    End Sub

    'Dim CurrentBillNo As Integer = BillNumber

    Public Sub Fill_Dataset()
        Try
            DS = New DataSet

            Dim PARA As New ArrayList
            PARA.Add(CLS_Config.Counter)
            PARA.Add(CLS_Config.Company)
            DS = DBO.ExecuteSP_ReturnDataSet("POS_Select", PARA)

            Hold_array.Clear()
            Dim i As Integer = 0
            For i = 0 To DS.Tables(4).Rows.Count - 1
                Hold_array.Add(DS.Tables(4).Rows(i).Item("BillNo").ToString)
            Next

            Me.txtHoldList.Text = Nothing
            If DS.Tables(4).Rows.Count > 0 Then Me.txtHoldList.Text = "Bill On Hold" & vbCrLf & Convert_Array_To_String(Hold_array)
            If CLS_Config.SearchByBarcode Then
                If CLS_Config.Company = ZAHRABAKALA Then
                    'FillDropByQuery(Me.DropItem, "ItemName", "Code", "SELECT Code, COALESCE(barcode,'') + ' - ' + COALESCE(ItemName,'') AS ItemName FROM ITEM WHERE ItemType <> " & ItemType.Subscription_Item & " AND (COALESCE(CostPrice, 0) > 0)  ORDER BY barcode")
                    FillDropByQuery(Me.DropItem, "ItemName", "Code", "SELECT Code, barcode + ' - ' + ItemName AS ItemName FROM Item_Class_View  WHERE (( CostPrice > 0 AND [Type] = 'Item') OR ( [Type] <> 'Item' )) AND (COALESCE(Discontinued,0)=0) ORDER BY barcode")
                Else
                    'FillDropByQuery(Me.DropItem, "ItemName", "Code", "SELECT Code, COALESCE(barcode,'') + ' - ' + COALESCE(ItemName,'') AS ItemName FROM ITEM WHERE ItemType <> " & ItemType.Subscription_Item & "  ORDER BY barcode")
                    FillDropByQuery(Me.DropItem, "ItemName", "Code", "SELECT Code, barcode + ' - ' + ItemName AS ItemName FROM Item_Class_View WHERE (COALESCE(Discontinued,0)=0) ORDER BY barcode")
                End If
            Else
                If CLS_Config.Company = ZAHRABAKALA Then
                    'FillDropWithCondition(Me.DropItem, "ItemName", "Code", Table.Item, , , , , " WHERE ItemType <> " & ItemType.Subscription_Item & " AND (COALESCE(CostPrice, 0) > 0)")
                    FillDropByQuery(Me.DropItem, "ItemName", "Code", "SELECT Code,ItemName FROM Item_Class_View  WHERE (( CostPrice > 0 AND [Type] = 'Item') OR ( [Type] <> 'Item' )) AND (COALESCE(Discontinued,0)=0)  ORDER BY barcode")
                Else
                    'FillDropWithCondition(Me.DropItem, "ItemName", "Code", Table.Item, , , , , " WHERE ItemType <> " & ItemType.Subscription_Item)
                    FillDropByQuery(Me.DropItem, "ItemName", "Code", "SELECT Code,ItemName FROM Item_Class_View  WHERE (COALESCE(Discontinued,0)=0)  ORDER BY barcode")
                    'FillDropWithCondition(Me.DropItem, "ItemName", "Code", Table.Item_Class_View)
                End If
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
            'Me.grdList.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False
            For i As Integer = 0 To Me.grdList.DisplayLayout.Bands(0).Columns.Count - 1
                If Me.grdList.DisplayLayout.Bands(0).Columns(i).Header.Caption <> "Notes" Then
                    Me.grdList.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                End If
            Next

            Me.grdList.DisplayLayout.Bands(0).Columns("Type").Hidden = True


            Select Case CLS_Config.Company
                Case ZAHRABAKALA

                    Me.grdList.DisplayLayout.Bands(0).Columns("Sr").Header.VisiblePosition = 0
                    Me.grdList.DisplayLayout.Bands(0).Columns("Barcode").Header.VisiblePosition = 1
                    Me.grdList.DisplayLayout.Bands(0).Columns("ItemName").Header.VisiblePosition = 2
                    Me.grdList.DisplayLayout.Bands(0).Columns("UnitPrice").Header.VisiblePosition = 3
                    Me.grdList.DisplayLayout.Bands(0).Columns("Quantity").Header.VisiblePosition = 4
                    Me.grdList.DisplayLayout.Bands(0).Columns("TotalPrice").Header.VisiblePosition = 5
                    Me.grdList.DisplayLayout.Bands(0).Columns("ItemCode").Header.VisiblePosition = 6
                    Me.grdList.DisplayLayout.Bands(0).Columns("Type").Header.VisiblePosition = 7

                Case Else

                    Me.grdList.DisplayLayout.Bands(0).Columns("Sr").Header.VisiblePosition = 0
                    Me.grdList.DisplayLayout.Bands(0).Columns("ItemCode").Header.VisiblePosition = 1
                    Me.grdList.DisplayLayout.Bands(0).Columns("ItemName").Header.VisiblePosition = 2
                    Me.grdList.DisplayLayout.Bands(0).Columns("UnitPrice").Header.VisiblePosition = 3
                    Me.grdList.DisplayLayout.Bands(0).Columns("Quantity").Header.VisiblePosition = 4
                    Me.grdList.DisplayLayout.Bands(0).Columns("TotalPrice").Header.VisiblePosition = 5
                    Me.grdList.DisplayLayout.Bands(0).Columns("Barcode").Header.VisiblePosition = 6
                    Me.grdList.DisplayLayout.Bands(0).Columns("Type").Header.VisiblePosition = 7

            End Select

            'Me.grdList.DisplayLayout.Bands(0).Columns("ItemCode").Hidden = True
            Me.grdList.DisplayLayout.Bands(0).Columns("CostPrice").Hidden = True


            Me.grdList.DisplayLayout.Bands(0).Columns("Sr").Width = 30
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemCode").Width = 75
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemName").Width = 300
            Me.grdList.DisplayLayout.Bands(0).Columns("UnitPrice").Width = 100
            Me.grdList.DisplayLayout.Bands(0).Columns("Quantity").Width = 75
            Me.grdList.DisplayLayout.Bands(0).Columns("TotalPrice").Width = 100
            Me.grdList.DisplayLayout.Bands(0).Columns("Barcode").Width = 100
            Me.grdList.DisplayLayout.Bands(0).Columns("Purchase_EntryCode").Width = 150
            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").Width = 500

            'Me.grdList.DisplayLayout.Bands(0).Columns("Notes").PerformAutoResize()

            Me.grdList.DisplayLayout.Bands(0).Columns("UnitPrice").MaskInput = Mask_Amount
            'Me.grdList.DisplayLayout.Bands(0).Columns("Quantity").MaskInput = Mask_Qty
            Me.grdList.DisplayLayout.Bands(0).Columns("TotalPrice").MaskInput = Mask_Amount

            Me.grdList.DisplayLayout.Bands(0).Columns("Purchase_EntryCode").EditorControl = Me.DropPurchase_EntryCode
            Me.grdList.DisplayLayout.Bands(0).Columns("Purchase_EntryCode").Header.Caption = "Serial"


            If CLS_Config.ShowImage Then
                Me.grdList.DisplayLayout.Bands(0).Columns("ItemCode").Hidden = True
                Me.grdList.DisplayLayout.Bands(0).Columns("UnitPrice").Hidden = True
                Me.grdList.DisplayLayout.Bands(0).Columns("Barcode").Hidden = True
                Me.grdList.DisplayLayout.Bands(0).Columns("Purchase_EntryCode").Hidden = True
                Me.grdList.DisplayLayout.Bands(0).Columns("Notes").Hidden = True

                Me.grdList.DisplayLayout.Bands(0).Columns("Sr").Width = 20
                Me.grdList.DisplayLayout.Bands(0).Columns("ItemName").Width = 150
                Me.grdList.DisplayLayout.Bands(0).Columns("Quantity").Width = 30
                Me.grdList.DisplayLayout.Bands(0).Columns("TotalPrice").Width = 70

                Me.grdList.DisplayLayout.Bands(0).Columns("ItemName").Header.Caption = "Item Name"
                Me.grdList.DisplayLayout.Bands(0).Columns("Quantity").Header.Caption = "Qty"
                Me.grdList.DisplayLayout.Bands(0).Columns("TotalPrice").Header.Caption = "Total"

                Me.grdList.DisplayLayout.Bands(0).Override.CellAppearance.FontData.SizeInPoints = 7


            End If

        Catch ex As Exception
            MsgBox("[SetGridLayout]" & vbCrLf & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' clear all txt, grid.  
    ''' optional to cut & scroll paper or not
    ''' </summary>
    ''' <param name="Cut">cut & Scroll paper</param>
    ''' <remarks></remarks>

    Private Sub Clear_Bill(Optional ByVal Cut As Boolean = True)
        Try
            CLS_Sale = New Sale
            Me.txtDate.Value = Null_Date
            Me.txtDate.Value = Now
            Me.txtPrice.Value = Nothing
            Me.txtTotal.Value = Nothing
            Me.txtQuantity.Value = 1
            Me.txtBarcode.Value = Nothing
            Me.txtNotes.Text = Nothing
            Me.lblItemName.Text = Nothing
            Me.lblItemName2.Text = Nothing
            EDITIGN_BILL = 0
            EDITIGN_Old_Amt = 0.0

            HOLD_BILL_NO = 0
            HOLD_BILL_DATE = Nothing

            DY_Price = False

            'Me.lblRemarks.Text = CLS_Sale.Remark
            Me.txtRemarks.Text = CLS_Sale.Remark
            Me.txtPONumber.Text = CLS_Sale.PONumber

            If Cut And Printer_On Then
                If PrintEmptySpaceType = 2 Then
                    PrintEmptySpace2()
                Else
                    PrintEmptySpace()
                End If
            End If

            Clear_Grid()

            Me.txtBarcode.Focus()

            Operation = OperationType.None

            If CLS_Config.Company = ZAHRABAKALA Then frmMainIns.PrintOnOff(False)

            CostPrice_On = False
            'frmMainIns.MenuStrip1.BackColor = Color.DodgerBlue


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
            Me.txtTotal.Value = Nothing
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
            Me.lblItemName2.Text = Nothing

            If CLS_Config.ShowImage Then GenerateCategory()

        Catch ex As Exception
            MsgBox("[New_Entry]" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Function Get_Item(ByVal Barcode As String, Optional ByVal onlyBarcode As Boolean = False) As Item
        Try

            Dim DT As New DataTable
            DT = DS.Tables(1)

            Dim CLS As New Item
            'IF BARCODE IS NULL RETURN EMPTY CLS
            If FixObjectString(Barcode) = Nothing Then Return Nothing




            If CLS_Config.Company = INDIAGATE _
                AndAlso Barcode.Substring(0, 1).ToString.ToUpper = "G" _
                AndAlso IsNumeric(Barcode.Substring(1)) Then

                Dim dr3() As DataRow = DT.Select(" Code=" & GeneralItemCode)
                If dr3.Length > 0 Then
                    CLS.Code = IIf(IsDBNull(dr3(0).Item("Code")), 0, dr3(0).Item("Code"))
                    CLS.ItemName = IIf(IsDBNull(dr3(0).Item("ItemName")), 0, dr3(0).Item("ItemName"))
                    CLS.CostPrice = IIf(IsDBNull(dr3(0).Item("CostPrice")), 0, dr3(0).Item("CostPrice"))
                    CLS.SalesPrice = CType(Barcode.Substring(1), Decimal) / 1000 'IIf(IsDBNull(dr3(0).Item("SalesPrice")), 0, dr3(0).Item("SalesPrice"))
                    CLS.Barcode = IIf(IsDBNull(dr3(0).Item("Barcode")), 0, dr3(0).Item("Barcode"))
                    CLS.Barcode2 = IIf(IsDBNull(dr3(0).Item("Barcode2")), 0, dr3(0).Item("Barcode2"))
                    CLS.CostMethod = IIf(IsDBNull(dr3(0).Item("CostMethod")), 0, dr3(0).Item("CostMethod"))
                    CLS.ProfitMargin = IIf(IsDBNull(dr3(0).Item("ProfitMargin")), 0, dr3(0).Item("ProfitMargin"))
                    CLS.Type = IIf(IsDBNull(dr3(0).Item("Type")), "Item", dr3(0).Item("Type"))
                    CLS.ItemType = IIf(IsDBNull(dr3(0).Item("ItemType")), "Item", dr3(0).Item("ItemType"))
                    CLS.Stock = IIf(IsDBNull(dr3(0).Item("Stock")), 0, dr3(0).Item("Stock"))
                    CLS.Notes = IIf(IsDBNull(dr3(0).Item("Notes")), 0, dr3(0).Item("Notes"))
                    CLS.onPromo = DBO.GetSingleValue("SELECT COALESCE(onPromo,0) as onPromo FROM Item WHERE Code = " & CLS.Code)
                    CLS.PromoFrom = IIf(IsDBNull(dr3(0).Item("PromoFrom")), 0, dr3(0).Item("PromoFrom"))
                    CLS.PromoTo = IIf(IsDBNull(dr3(0).Item("PromoTo")), 0, dr3(0).Item("PromoTo"))
                    CLS.PromoPrice = IIf(IsDBNull(dr3(0).Item("PromoPrice")), 0, dr3(0).Item("PromoPrice"))
                    CLS.PromoStockLimit = IIf(IsDBNull(dr3(0).Item("PromoStockLimit")), 0, dr3(0).Item("PromoStockLimit"))
                    CLS.PromoStockSold = IIf(IsDBNull(dr3(0).Item("PromoStockSold")), 0, dr3(0).Item("PromoStockSold"))
                    Return CLS
                End If

            End If



            'IF BARCODE EXIST IN DS LOAD & RETURN CLS
            Dim dr() As DataRow = DT.Select(" Barcode='" & Barcode & "'")
            If dr.Length > 0 Then
                CLS.Code = IIf(IsDBNull(dr(0).Item("Code")), 0, dr(0).Item("Code"))
                CLS.ItemName = IIf(IsDBNull(dr(0).Item("ItemName")), 0, dr(0).Item("ItemName"))
                CLS.CostPrice = IIf(IsDBNull(dr(0).Item("CostPrice")), 0, dr(0).Item("CostPrice"))
                CLS.SalesPrice = IIf(IsDBNull(dr(0).Item("SalesPrice")), 0, dr(0).Item("SalesPrice"))
                CLS.Barcode = IIf(IsDBNull(dr(0).Item("Barcode")), 0, dr(0).Item("Barcode"))
                CLS.Barcode2 = IIf(IsDBNull(dr(0).Item("Barcode2")), 0, dr(0).Item("Barcode2"))
                CLS.CostMethod = IIf(IsDBNull(dr(0).Item("CostMethod")), 0, dr(0).Item("CostMethod"))
                CLS.ProfitMargin = IIf(IsDBNull(dr(0).Item("ProfitMargin")), 0, dr(0).Item("ProfitMargin"))
                CLS.Type = IIf(IsDBNull(dr(0).Item("Type")), "Item", dr(0).Item("Type"))
                CLS.ItemType = IIf(IsDBNull(dr(0).Item("ItemType")), "Item", dr(0).Item("ItemType"))
                CLS.Stock = IIf(IsDBNull(dr(0).Item("Stock")), 0, dr(0).Item("Stock"))
                CLS.Notes = IIf(IsDBNull(dr(0).Item("Notes")), 0, dr(0).Item("Notes"))
                CLS.onPromo = DBO.GetSingleValue("SELECT COALESCE(onPromo,0) as onPromo FROM Item WHERE Code = " & CLS.Code)
                CLS.PromoFrom = IIf(IsDBNull(dr(0).Item("PromoFrom")), 0, dr(0).Item("PromoFrom"))
                CLS.PromoTo = IIf(IsDBNull(dr(0).Item("PromoTo")), 0, dr(0).Item("PromoTo"))
                CLS.PromoPrice = IIf(IsDBNull(dr(0).Item("PromoPrice")), 0, dr(0).Item("PromoPrice"))
                CLS.PromoStockLimit = IIf(IsDBNull(dr(0).Item("PromoStockLimit")), 0, dr(0).Item("PromoStockLimit"))
                CLS.PromoStockSold = IIf(IsDBNull(dr(0).Item("PromoStockSold")), 0, dr(0).Item("PromoStockSold"))
                Return CLS
            End If
            'IF BARCODE DOSE NOT EXIST CONT...

            If onlyBarcode Then Return Nothing


            If CLS_Config.Company = INDIAGATE Then


                'IF BARCODE2 EXIST IN DS LOAD & RETURN CLS
                Dim dr2() As DataRow = DT.Select(" Barcode2='" & Barcode & "'")
                If dr2.Length > 0 Then
                    CLS.Code = IIf(IsDBNull(dr2(0).Item("Code")), 0, dr2(0).Item("Code"))
                    CLS.ItemName = IIf(IsDBNull(dr2(0).Item("ItemName")), 0, dr2(0).Item("ItemName"))
                    CLS.CostPrice = IIf(IsDBNull(dr2(0).Item("CostPrice")), 0, dr2(0).Item("CostPrice"))
                    CLS.SalesPrice = IIf(IsDBNull(dr2(0).Item("SalesPrice")), 0, dr2(0).Item("SalesPrice"))
                    CLS.Barcode = IIf(IsDBNull(dr2(0).Item("Barcode")), 0, dr2(0).Item("Barcode"))
                    CLS.Barcode2 = IIf(IsDBNull(dr2(0).Item("Barcode2")), 0, dr2(0).Item("Barcode2"))
                    CLS.CostMethod = IIf(IsDBNull(dr2(0).Item("CostMethod")), 0, dr2(0).Item("CostMethod"))
                    CLS.ProfitMargin = IIf(IsDBNull(dr2(0).Item("ProfitMargin")), 0, dr2(0).Item("ProfitMargin"))
                    CLS.Type = IIf(IsDBNull(dr2(0).Item("Type")), "Item", dr2(0).Item("Type"))
                    CLS.ItemType = IIf(IsDBNull(dr2(0).Item("ItemType")), "Item", dr2(0).Item("ItemType"))
                    CLS.Stock = IIf(IsDBNull(dr2(0).Item("Stock")), 0, dr2(0).Item("Stock"))
                    CLS.Notes = IIf(IsDBNull(dr2(0).Item("Notes")), 0, dr2(0).Item("Notes"))
                    CLS.onPromo = DBO.GetSingleValue("SELECT COALESCE(onPromo,0) as onPromo FROM Item WHERE Code = " & CLS.Code)
                    CLS.PromoFrom = IIf(IsDBNull(dr2(0).Item("PromoFrom")), 0, dr2(0).Item("PromoFrom"))
                    CLS.PromoTo = IIf(IsDBNull(dr2(0).Item("PromoTo")), 0, dr2(0).Item("PromoTo"))
                    CLS.PromoPrice = IIf(IsDBNull(dr2(0).Item("PromoPrice")), 0, dr2(0).Item("PromoPrice"))
                    CLS.PromoStockLimit = IIf(IsDBNull(dr2(0).Item("PromoStockLimit")), 0, dr2(0).Item("PromoStockLimit"))
                    CLS.PromoStockSold = IIf(IsDBNull(dr2(0).Item("PromoStockSold")), 0, dr2(0).Item("PromoStockSold"))
                    Return CLS
                End If


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
                        CLS.CostMethod = IIf(IsDBNull(dr3(0).Item("CostMethod")), 0, dr3(0).Item("CostMethod"))
                        CLS.ProfitMargin = IIf(IsDBNull(dr3(0).Item("ProfitMargin")), 0, dr3(0).Item("ProfitMargin"))
                        CLS.Type = IIf(IsDBNull(dr3(0).Item("Type")), "Item", dr3(0).Item("Type"))
                        CLS.ItemType = IIf(IsDBNull(dr3(0).Item("ItemType")), "Item", dr3(0).Item("ItemType"))
                        CLS.Stock = IIf(IsDBNull(dr3(0).Item("Stock")), 0, dr3(0).Item("Stock"))
                        CLS.Notes = IIf(IsDBNull(dr3(0).Item("Notes")), 0, dr3(0).Item("Notes"))
                        CLS.onPromo = DBO.GetSingleValue("SELECT COALESCE(onPromo,0) as onPromo FROM Item WHERE Code = " & CLS.Code)
                        CLS.PromoFrom = IIf(IsDBNull(dr3(0).Item("PromoFrom")), 0, dr3(0).Item("PromoFrom"))
                        CLS.PromoTo = IIf(IsDBNull(dr3(0).Item("PromoTo")), 0, dr3(0).Item("PromoTo"))
                        CLS.PromoPrice = IIf(IsDBNull(dr3(0).Item("PromoPrice")), 0, dr3(0).Item("PromoPrice"))
                        CLS.PromoStockLimit = IIf(IsDBNull(dr3(0).Item("PromoStockLimit")), 0, dr3(0).Item("PromoStockLimit"))
                        CLS.PromoStockSold = IIf(IsDBNull(dr3(0).Item("PromoStockSold")), 0, dr3(0).Item("PromoStockSold"))
                        Return CLS
                    End If
                End If

            Else

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
                        CLS.CostMethod = IIf(IsDBNull(dr3(0).Item("CostMethod")), 0, dr3(0).Item("CostMethod"))
                        CLS.ProfitMargin = IIf(IsDBNull(dr3(0).Item("ProfitMargin")), 0, dr3(0).Item("ProfitMargin"))
                        CLS.Type = IIf(IsDBNull(dr3(0).Item("Type")), "Item", dr3(0).Item("Type"))
                        CLS.ItemType = IIf(IsDBNull(dr3(0).Item("ItemType")), "Item", dr3(0).Item("ItemType"))
                        CLS.Stock = IIf(IsDBNull(dr3(0).Item("Stock")), 0, dr3(0).Item("Stock"))
                        CLS.Notes = IIf(IsDBNull(dr3(0).Item("Notes")), 0, dr3(0).Item("Notes"))
                        CLS.onPromo = DBO.GetSingleValue("SELECT COALESCE(onPromo,0) as onPromo FROM Item WHERE Code = " & CLS.Code)
                        CLS.PromoFrom = IIf(IsDBNull(dr3(0).Item("PromoFrom")), 0, dr3(0).Item("PromoFrom"))
                        CLS.PromoTo = IIf(IsDBNull(dr3(0).Item("PromoTo")), 0, dr3(0).Item("PromoTo"))
                        CLS.PromoPrice = IIf(IsDBNull(dr3(0).Item("PromoPrice")), 0, dr3(0).Item("PromoPrice"))
                        CLS.PromoStockLimit = IIf(IsDBNull(dr3(0).Item("PromoStockLimit")), 0, dr3(0).Item("PromoStockLimit"))
                        CLS.PromoStockSold = IIf(IsDBNull(dr3(0).Item("PromoStockSold")), 0, dr3(0).Item("PromoStockSold"))
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
                    CLS.CostMethod = IIf(IsDBNull(dr2(0).Item("CostMethod")), 0, dr2(0).Item("CostMethod"))
                    CLS.ProfitMargin = IIf(IsDBNull(dr2(0).Item("ProfitMargin")), 0, dr2(0).Item("ProfitMargin"))
                    CLS.Type = IIf(IsDBNull(dr2(0).Item("Type")), "Item", dr2(0).Item("Type"))
                    CLS.ItemType = IIf(IsDBNull(dr2(0).Item("ItemType")), "Item", dr2(0).Item("ItemType"))
                    CLS.Stock = IIf(IsDBNull(dr2(0).Item("Stock")), 0, dr2(0).Item("Stock"))
                    CLS.Notes = IIf(IsDBNull(dr2(0).Item("Notes")), 0, dr2(0).Item("Notes"))
                    CLS.onPromo = DBO.GetSingleValue("SELECT COALESCE(onPromo,0) as onPromo FROM Item WHERE Code = " & CLS.Code)
                    CLS.PromoFrom = IIf(IsDBNull(dr2(0).Item("PromoFrom")), 0, dr2(0).Item("PromoFrom"))
                    CLS.PromoTo = IIf(IsDBNull(dr2(0).Item("PromoTo")), 0, dr2(0).Item("PromoTo"))
                    CLS.PromoPrice = IIf(IsDBNull(dr2(0).Item("PromoPrice")), 0, dr2(0).Item("PromoPrice"))
                    CLS.PromoStockLimit = IIf(IsDBNull(dr2(0).Item("PromoStockLimit")), 0, dr2(0).Item("PromoStockLimit"))
                    CLS.PromoStockSold = IIf(IsDBNull(dr2(0).Item("PromoStockSold")), 0, dr2(0).Item("PromoStockSold"))
                    Return CLS
                End If

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
            If Not PrintDelete Then Exit Sub

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
                PrintDelete = False
                Dim i As Integer = 0
                For i = 0 To Me.grdList.Rows.Count - 1
                    Me.grdList.Rows(i).Delete(False)
                    i = i - 1
                Next

            Catch ex As Exception
            End Try

            PrintDelete = True
            Delete_Count = 0

            If CLS_Config.ShowImage Then GenerateCategory()

            Me.FlowSelectedItem.Controls.Clear()

        Catch ex As Exception
            MsgBox("[Clear_Grid]" & vbCrLf & ex.Message)
        End Try
    End Sub

#Region "                   PRINTING                     "

    Dim P_ItemName, P_Qty, P_Rate, P_Price, P_Tran_Type As String
    Dim P_Gap As Integer = 15
    Dim P_Amount_T As Double
    Dim FontStyle_12 As New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))

    Private Sub PrintHeadder()
        Try
            If Not Printer_On Or CLS_Config.PrintAtEnd Then Exit Sub

            Dim str As String = ""
            Select Case CLS_Config.Company
                Case MoveNPick
                    str = "          M & P" & vbCrLf
                    str += "   " & vbCrLf
                Case INDIAGATE
                    str = "          INDIA GATE SUPER MARKET" & vbCrLf
                    str += "   " & vbCrLf
                Case OsmanSM
                    str = "          OSMAN SUPER MARKET" & vbCrLf
                    str += "   " & vbCrLf
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
                    str = "             CENTURY BAZAAR" & vbCrLf
                    str += "              TEL: 23915844 / 5" & vbCrLf
            End Select
            str += ConvertSize("BILL # " & BillNumber, 11, False) & ConvertSize("POS # " & CLS_Config.Counter, 29, True) & vbCrLf
            str += "ITEMS                 QTY   RATE  AMOUNT" & vbCrLf
            str += "----------------------------------------" & vbCrLf

            'Printer.Print(str)
            'Printer.EndDoc()

            Dim pd As New PrintDialog()
            pd.PrinterSettings.PrinterName = CLS_Config.ReceiptPrinter
            RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, str)


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub PrintItem(Optional ByVal Deleting As Boolean = False)
        Try
            If Not Printer_On Or CLS_Config.PrintAtEnd Then Exit Sub

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
            If Not Printer_On Or CLS_Config.PrintAtEnd Then Exit Sub

            Dim str As String = ""
            str = "----------------------------------------" & vbCrLf

            Select Case CLS_Config.Company
                Case ZAHRABAKALA
                    str += ConvertSize(Me.grdList.Rows.Count, 3, False)
                    str += ConvertSize(" ITEM /      QTY : ", 20, False)
                    str += ConvertSize(Get_Grid_Total(Me.grdList, "Quantity").ToString, 3, False)
                    str += ConvertSize("", 7, False)
                    str += ConvertSize(ConvertToString(CLS_Sale.TotalBill), 6, False) & vbCrLf
                    str += ConvertSize("", 40, False)

                Case Else
                    str += ConvertSize("TOTAL QTY : ", 22, True) & " "
                    str += ConvertSize(Get_Grid_Total(Me.grdList, "Quantity").ToString, 3, False)
                    str += ConvertSize("", 7, False)
                    str += ConvertSize(ConvertToString(CLS_Sale.TotalBill), 6, False) & vbCrLf

            End Select


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

                    Select Case CLS_Sale.PaymentType
                        Case PaymentType.KNet_Cash
                            str += ConvertSize(Pay_Type & " KNET ", 33, False)
                            str += ConvertSize(ConvertToString(CDec(CLS_Sale.Payment) - CLS_Sale.CashAmount), 6, True) & vbCrLf

                            str += ConvertSize(Pay_Type & " CASH ", 33, False)
                            str += ConvertSize(ConvertToString(CDec(CLS_Sale.CashAmount)), 6, True) & vbCrLf

                        Case PaymentType.MasterCard_Cash
                            str += ConvertSize(Pay_Type & " MASTER ", 33, False)
                            str += ConvertSize(ConvertToString(CDec(CLS_Sale.Payment) - CLS_Sale.CashAmount), 6, True) & vbCrLf

                            str += ConvertSize(Pay_Type & " CASH ", 33, False)
                            str += ConvertSize(ConvertToString(CDec(CLS_Sale.CashAmount)), 6, True) & vbCrLf
                        Case Else
                            str += ConvertSize(Pay_Type & " PAID ", 33, False)
                            str += ConvertSize(ConvertToString(CDec(CLS_Sale.Payment)), 6, True) & vbCrLf
                    End Select



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

                    str += ConvertSize("CUSTOMER ID: ", 15, False)
                    str += ConvertSize(CLS_Sale.CustomerNum, 25, False) & vbCrLf

                    str += ConvertSize("CUSTOMER NAME: ", 15, False)
                    str += ConvertSize(CLS_Sale.CustomerName, 25, False) & vbCrLf

                    'str += ConvertSize("CUSTOMER ID: " & CLS_Sale.CustomerNum, 40, False) & vbCrLf
                    'str += ConvertSize("CUSTOMER NAME: " & CLS_Sale.CustomerName, 40, False) & vbCrLf

                    Dim CLS_ACC As New Account
                    'If EDITIGN_BILL = 0 Then CLS_ACC.Select_Customer(CLS_Sale.CustomerNum, CLS_Sale.TransectionDate)
                    'If EDITIGN_BILL <> 0 Then CLS_ACC.Select_Customer(CLS_Sale.CustomerNum, Null_Date)
                    CLS_ACC.Select_Customer(CLS_Sale.CustomerNum, CLS_Sale.TransectionDate)

                    If CLS_Config.MonthBasePayment Then
                        str += "----------------------------------------" & vbCrLf
                        If CLS_ACC.BalancePrvMonth > 5 Then
                            str += ConvertSize("CURR MTH BAL: ", 15, False)
                            'str += ConvertSize(ConvertToString(CDec(CLS_ACC.BalanceCurrentMonth - EDITIGN_Old_Amt)), 25, False) & vbCrLf
                            'str += ConvertSize(ConvertToString(CDec(CLS_ACC.Balance - CLS_ACC.BalancePrvMonth - EDITIGN_Old_Amt)), 25, False) & vbCrLf
                            str += ConvertSize(ConvertToString(CDec(CLS_ACC.Balance - CLS_ACC.BalancePrvMonth)), 25, False) & vbCrLf

                            str += ConvertSize("PRV MTH BAL: ", 15, False)
                            str += ConvertSize(ConvertToString(CDec(CLS_ACC.BalancePrvMonth)), 25, False) & vbCrLf
                        End If

                        str += ConvertSize("TOTAL BALANCE: ", 15, False)
                        'str += ConvertSize(ConvertToString(CDec(CLS_ACC.FinalBalance - EDITIGN_Old_Amt)), 25, False) & vbCrLf
                        'str += ConvertSize(ConvertToString(CDec(CLS_ACC.Balance - EDITIGN_Old_Amt)), 25, False) & vbCrLf --21 APRIL 2013
                        str += ConvertSize(ConvertToString(CDec(CLS_ACC.Balance)), 25, False) & vbCrLf
                        str += "----------------------------------------" & vbCrLf

                    Else

                        str += ConvertSize("TOTAL BALANCE: ", 15, False)
                        'str += ConvertSize(ConvertToString(CDec(CLS_ACC.Balance - EDITIGN_Old_Amt)), 25, False) & vbCrLf --21 APRIL 2013
                        str += ConvertSize(ConvertToString(CDec(CLS_ACC.Balance)), 25, False) & vbCrLf

                    End If


                    'Dim Bal As Decimal = CDec(Me.txtNetBill.Value) - EDITIGN_Old_Amt
                    'str += ConvertSize("BALANCE: " & ConvertToString(CDec(CLS_ACC.Balance - EDITIGN_Old_Amt)), 40, False) & vbCrLf



                    ''Dim CLS_ACC_PRV As New Account
                    ''CLS_ACC_PRV = New Account
                    ''CLS_ACC_PRV.Select_Customer(CLS_Sale.CustomerNum, New DateTime(CLS_Sale.TransectionDate.Year, CLS_Sale.TransectionDate.Month, 1, 23, 59, 59).AddDays(-1))
                    ' ''str += ConvertSize("PRV MONTH BAL: " & ConvertToString(CDec(CLS_ACC_PRV.Balance)), 40, False) & vbCrLf
                    'str += ConvertSize("PRV MONTH BAL: ", 15, False)
                    'str += ConvertSize(ConvertToString(CDec(CLS_ACC.PrvMonthBalance)), 25, False) & vbCrLf


                    ''Dim CLS_ACC_Current As New Account
                    ''CLS_ACC_Current = New Account
                    ''CLS_ACC_Current.Select_Customer(CLS_Sale.CustomerNum, New DateTime(Now.Year, Now.Month, 1, 23, 59, 59))
                    ''str += ConvertSize("CURRENT MONTH BAL: " & ConvertToString(CDec(CLS_ACC.Balance - CLS_ACC_PRV.Balance)), 40, False) & vbCrLf
                    'str += ConvertSize("MONTHLY BAL: ", 15, False)
                    'str += ConvertSize(ConvertToString(CDec(CLS_ACC.Balance - EDITIGN_Old_Amt - CLS_ACC.PrvMonthBalance)), 25, False) & vbCrLf

                    Dim HasTimeLimitExpiry As Boolean = False
                    If CLS_ACC.TimeLimit > -1 Then
                        Dim MonthStart As New DateTime(CLS_Sale.TransectionDate.Year, CLS_Sale.TransectionDate.Month, 1)
                        Dim CurrentLimit As Integer = DateDiff(DateInterval.Day, MonthStart, CLS_Sale.TransectionDate) + 1

                        If CurrentLimit > CLS_ACC.TimeLimit And CLS_ACC.BalancePrvMonth > 0 Then
                            str += ConvertSize("PLEASE CLEAR YOUR PREVIOUS BALANCE", 40, False) & vbCrLf
                            str += "----------------------------------------" & vbCrLf
                            HasTimeLimitExpiry = True
                        End If
                    End If

                    If CLS_ACC.AmountLimit > -1 Then

                        If CLS_ACC.Balance + Decimal.Round(CDec(FixControl(Me.txtNetBill)), 3) > CLS_ACC.AmountLimit Then
                            If Not HasTimeLimitExpiry Then str += "----------------------------------------" & vbCrLf
                            str += ConvertSize("ACCOUNT EXCEEDS BALANCE LIMIT", 40, False) & vbCrLf
                            str += "----------------------------------------" & vbCrLf
                            'If MessageBox.Show("AMOUNT LIMIT [ " & ConvertToString(CDec(CLS_ACC.AmountLimit), False) & " KD ]" & vbCrLf & vbCrLf & _
                            '                   "EXCEED BY [ " & ConvertToString(CDec(CLS_ACC.Balance + Decimal.Round(CDec(FixControl(Me.txtNetBill)), 3) - CLS_ACC.AmountLimit), False) & " KD ]" & vbCrLf & vbCrLf & _
                            '                   "CUSTOMER NAME [ " & CLS_ACC.Title & " ]" & vbCrLf & vbCrLf & _
                            '                   "DO YOU STILL WANT TO CONTINUE CREDIT SALE?", "TIME LIMIT EXCEED", _
                            '                   MessageBoxButtons.YesNo, _
                            '                   MessageBoxIcon.Information, _
                            '                   MessageBoxDefaultButton.Button2) <> MsgBoxResult.Yes Then Exit Sub
                        End If
                    End If

                Case TransectionType.CashSaleReturn

                    str += ConvertSize("CASH SALES RETURN", 40, False) & vbCrLf

                Case TransectionType.CreditSaleReturn

                    str += ConvertSize("CREDIT SALES RETURN", 40, False) & vbCrLf

                    'str += ConvertSize("CUSTOMER ID: " & CLS_Sale.CustomerNum, 40, False) & vbCrLf
                    'str += ConvertSize("CUSTOMER NAME: " & CLS_Sale.CustomerName, 40, False) & vbCrLf
                    str += ConvertSize("CUSTOMER ID: ", 15, False)
                    str += ConvertSize(CLS_Sale.CustomerNum, 25, False) & vbCrLf

                    str += ConvertSize("CUSTOMER NAME: ", 15, False)
                    str += ConvertSize(CLS_Sale.CustomerName, 25, False) & vbCrLf

                    'Dim CLS_ACC As New Account
                    'CLS_ACC.Select_Customer(CLS_Sale.CustomerNum, Null_Date)
                    'str += ConvertSize("BALANCE: " & ConvertToString(CDec(CLS_ACC.Balance)), 40, False) & vbCrLf
                    Dim CLS_ACC As New Account
                    CLS_ACC.Select_Customer(CLS_Sale.CustomerNum, Null_Date)
                    str += ConvertSize("BALANCE: ", 15, False)
                    str += ConvertSize(ConvertToString(CDec(CLS_ACC.Balance)), 25, False) & vbCrLf


                    ''Dim CLS_ACC_PRV As New Account
                    ''CLS_ACC_PRV = New Account
                    ''CLS_ACC_PRV.Select_Customer(CLS_Sale.CustomerNum, New DateTime(Now.Year, Now.Month, 1, 23, 59, 59).AddDays(-1))
                    'str += ConvertSize("PRV MONTH BAL: ", 15, False)
                    'str += ConvertSize(ConvertToString(CDec(CLS_ACC.PrvMonthBalance)), 25, False) & vbCrLf


                    'str += ConvertSize("MONTHLY BAL: ", 15, False)
                    'str += ConvertSize(ConvertToString(CDec(CLS_ACC.Balance - CLS_ACC.PrvMonthBalance)), 25, False) & vbCrLf

            End Select

            If CLS_Sale.Remark <> Nothing Then
                'str += ConvertSize("REMARK: " & CLS_Sale.Remark, 40, False) & vbCrLf
                str += ConvertSize("REMARK: ", 15, False)
                str += ConvertSize(CLS_Sale.Remark, 25, False) & vbCrLf
                str += "----------------------------------------" & vbCrLf
            End If
            'str += ConvertSize("CASHIER: " & UserClass.UserName, 30, False) & vbCrLf
            str += ConvertSize("CASHIER: ", 15, False)
            str += ConvertSize(UserClass.UserName, 25, False) & vbCrLf

            If CLS_Config.Company = CENTURY Then
                'str += ConvertSize("      Goods once sold will not be", 40, False) & vbCrLf
                str += ConvertSize("      Keep bill for any change", 40, False) & vbCrLf
                'str += ConvertSize("         returned or exchanged.", 40, False) & vbCrLf
            End If
            str += ConvertSize("       THANK YOU ! VISIT AGAIN", 30, False) & vbCrLf
            str += ConvertSize("       " & CDate(Me.txtDate.Value).ToString("dd/MMM/yy HH:mm"), 30, False) ' & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf
            'str += ConvertSize("       " & CDate(Me.txtDate.Value).ToString("dd/MMM/yy") & " " & Now.Hour.ToString & ":" & Now.Minute.ToString, 30, False) ' & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf

            'MsgBox(str)
            'Exit Sub

            Dim pd As New PrintDialog()
            ' Open the printer dialog box, and then allow the user to select a printer.
            pd.PrinterSettings.PrinterName = CLS_Config.ReceiptPrinter
            RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, str)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub PrintCancel()
        Try
            If Not Printer_On Or CLS_Config.PrintAtEnd Then Exit Sub

            Dim str As String = ""
            str = "----------------------------------------" & vbCrLf
            str += "--------------CANCELLED-----------------"

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
            If Not Printer_On Or CLS_Config.PrintAtEnd Then Exit Sub

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
            If Not CLS_Config.PrintAtEnd Then Exit Sub

            Dim frm As New frmDialogResult("Do you want to PRINT the Invoice.")
            If frm.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub

            'If MsgBox("PRINT", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub

            Dim DT As New DataTable
            DT = DBO.ReturnDataTable("SELECT * FROM Sales_Full_View Where SaleCode=" & CInt(SaleCode))

            Select Case CLS_Config.Company
                Case ZAHRABAKALA, MoveNPick, EDEE, CENTURY, OsmanSM, INDIAGATE, BOOKSHOP

                    Dim report As New ReportDocument
                    report.Load(CLS_Config.ReportPath & "Bill Receipt.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)
                    report.SetDataSource(DT)

                    report.SetParameterValue("AccCashCustomer", FixObjectNumber(CLS_Config.AccCashCustomer))
                    report.SetParameterValue("CompanyName", FixObjectString(CLS_Config.CompanyName))
                    report.SetParameterValue("Address1", FixObjectString(CLS_Config.Address1))
                    report.SetParameterValue("Address2", FixObjectString(CLS_Config.Address2))
                    report.SetParameterValue("Address3", FixObjectString(CLS_Config.Address3))
                    report.SetParameterValue("Tel", FixObjectString(CLS_Config.Tel))

                    Select Case CLS_Sale.TransectionType
                        Case TransectionType.CreditSale, TransectionType.CreditSaleReturn
                            Dim CLS_ACC As New Account
                            CLS_ACC.Select_Customer(CLS_Sale.CustomerNum, Null_Date)
                            report.SetParameterValue("CustomerBalance", FixObjectNumber(CLS_ACC.Balance))
                        Case Else
                            report.SetParameterValue("CustomerBalance", 0)
                    End Select
                    report.SetParameterValue("CashAmount", FixObjectNumber(CLS_Sale.CashAmount))

                    report.PrintOptions.PrinterName = CLS_Config.ReceiptPrinter
                    report.PrintToPrinter(1, False, 1, 2)

                Case Else

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
                    report2.SetParameterValue("DecimalPlace", FixObjectNumber(CLS_Config.DecimalPlace))

                    Select Case CLS_Sale.TransectionType
                        Case TransectionType.CashSaleReturn, TransectionType.CreditSaleReturn
                            report2.SetParameterValue("isSaleReturn", True)
                        Case Else
                            report2.SetParameterValue("isSaleReturn", False)
                    End Select

                    report2.PrintOptions.PrinterName = CLS_Config.ReceiptPrinter
                    report2.PrintToPrinter(1, False, 1, 2)

                    report2.Dispose()

            End Select

            'Dim CRV As New CrystalDecisions.Windows.Forms.CrystalReportViewer
            'CRV.ReportSource = report2
            'CRV.PrintReport()


        Catch ex As Exception
            MsgBox("Print_Big_Bill" & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region

    'DROP ITEM
    Private Sub Add_Item_By_Code(ItemCode As Integer)
        Try
            If TrimInt(ItemCode) = Nothing Then Exit Sub

            Operation = OperationType.None
            Me.txtBarcode.Value = ItemCode

            If CLS_Config.NewSalesScreen Then
                Me.DropItem.Visible = False
                Me.DropItem.Value = Nothing

                Dim CLS_Item As New Item
                CLS_Item = Get_Item(CStr(Me.txtBarcode.Value))
                If IsNothing(CLS_Item) Then
                    MsgBox("Invalid Item.")
                    Me.txtNotes.Text = "Invalid Item."
                Else
                    Me.lblItemName.Text = CLS_Item.CostPrice & " - " & CLS_Item.ItemName & " [" & TrimDec(CLS_Item.Stock) & "]"
                    Me.lblItemName2.Text = CLS_Item.Notes

                    If CostPrice_On Then
                        Me.txtPrice.Value = CLS_Item.CostPrice * CurrencyBase
                    Else
                        If TrimBoolean(CLS_Item.onPromo) Then
                            Me.txtPrice.Value = CLS_Item.PromoPrice * CurrencyBase
                        Else
                            Me.txtPrice.Value = CLS_Item.SalesPrice * CurrencyBase
                        End If
                    End If
                    Default_Price = Me.txtPrice.Value
                    Me.txtPrice.SelectAll()
                    Me.txtPrice.Focus()
                End If
            Else
                Call_Add()
                Me.txtQuantity.Value = 1

                Me.DropItem.Visible = False
                Me.DropItem.Value = Nothing
                Me.txtBarcode.Value = Nothing
                Me.txtBarcode.Focus()
                Me.txtBarcode.SelectAll()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub Open_ItemList()
        Try
            Find_Int = Nothing
            Dim FRM As New frmItemList
            FRM.Search = True
            FRM.ShowDialog()


            If Find_Int <> Nothing Then
                Me.DropItem.Value = Find_Int
                Add_Item_By_Code(TrimInt(Me.DropItem.Value))
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub DropItem_EditorButtonClick(sender As Object, e As Infragistics.Win.UltraWinEditors.EditorButtonEventArgs) Handles DropItem.EditorButtonClick
        Open_ItemList()
    End Sub
    Private Sub DropItem_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DropItem.KeyDown
        Select Case e.KeyCode
            Case CLS_Config.K_Info
                Open_ItemList()
            Case CLS_Config.K_ItemList
                Me.DropItem.Visible = False
                Me.DropItem.Value = Nothing
                Me.txtBarcode.Value = Nothing
                Me.txtBarcode.Focus()
                Me.txtBarcode.SelectAll()

            Case CLS_Config.K_Add, CLS_Config.K_Add2
                Add_Item_By_Code(TrimInt(Me.DropItem.Value))
            Case Keys.ControlKey + Keys.F1

        End Select
    End Sub

    'DROP CUSTOMER
    Private Sub Add_From_DropCustomer()
        Try
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
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Open_CustomerList()
        Try
            Find_Str = Nothing

            Dim FRM As New frmDynamicList
            'FRM.MdiParent = Me
            FRM.TableName = Table.Account
            FRM.AccountType = AccountType.Customer
            FRM.ShowDialog()


            FillDropWithCondition(Me.DropCustomer, "Title", "AccountNum", Table.Account, "Code", , , , " WHERE AccountType = " & AccountType.Customer & " AND Code<>" & CLS_Config.AccCashCustomer)
            Me.DropCustomer.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend


            If Find_Str <> Nothing Then
                Me.DropCustomer.Value = Find_Str
                Add_From_DropCustomer()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub DropCustomer_EditorButtonClick(sender As Object, e As Infragistics.Win.UltraWinEditors.EditorButtonEventArgs) Handles DropCustomer.EditorButtonClick
        Open_CustomerList()
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
                Add_From_DropCustomer()
            Case CLS_Config.K_Info
                Open_CustomerList()

        End Select
    End Sub

    Private Sub txtPrice_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPrice.KeyDown
        Try
            'If FixControl(Me.txtPrice) = Nothing Then Exit Sub
            If e.KeyCode = Keys.Enter Then
                If FixControl(Me.txtPrice) <> Default_Price Then DY_Price = True
                'Default_Price = Nothing
                Me.txtQuantity.SelectAll()
                Me.txtQuantity.Focus()
            End If
        Catch ex As Exception
            MsgBox("[txtPrice_KeyDown]" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub txtQuantity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQuantity.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If FixControl(Me.txtQuantity) <> Nothing And FixControl(Me.txtPrice) <> Nothing Then
                    Me.txtTotal.Value = FixControl(Me.txtQuantity) * FixControl(Me.txtPrice)
                End If

                Me.txtTotal.SelectAll()
                Me.txtTotal.Focus()
            End If
        Catch ex As Exception
            MsgBox("[txtPrice_KeyDown]" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub txtTotal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTotal.KeyDown
        Try
            If e.KeyCode <> Keys.Enter Then Exit Sub

            If FixControl(Me.txtQuantity) <> Nothing And FixControl(Me.txtTotal) <> Nothing Then
                Dim UP As Decimal = FixControl(Me.txtTotal) / FixControl(Me.txtQuantity)
                Me.txtPrice.Value = Decimal.Round(UP, 3)
                If FixControl(Me.txtPrice) <> Default_Price Then DY_Price = True
            End If
            If FixControl(Me.txtPrice) = Nothing Or FixControl(Me.txtQuantity) = Nothing Then
                Me.txtPrice.Focus()
                Me.txtPrice.SelectAll()
            Else
                Call_Add()
            End If
        Catch ex As Exception
            MsgBox("[txtQuantity_KeyDown]" & vbCrLf & ex.Message)
        End Try

    End Sub

    'Private Function Send_To_Port(ByVal Message1 As String, ByVal Message2 As String) As Boolean
    '    Try
    '        Message1 = LTrim(Message1, PortMax)
    '        Message2 = LTrim(Message2, PortMax)

    '        If CLS_Config.Has_Display_Pole Then

    '            With SerialPort2
    '                If .IsOpen Then
    '                    .Close()
    '                End If
    '                .PortName = CLS_Config.ComPort
    '                '.PortName = CLS_Config.ReceiptPrinter
    '                .Open()
    '                .Write(vbCrLf & Message2 & vbCrLf & Message1)
    '                .Close()
    '            End With

    '        ElseIf CLS_Config.Has_New_Display_Pole Then


    '            Dim cls As New Display
    '            cls.OpenPort()
    '            cls.Clear()
    '            cls.WritePort(vbCrLf & Message2 & vbCrLf & Message1)
    '            cls.ClosePort()

    '            LastDisplayText = vbCrLf & Message2 & vbCrLf & Message1
    '        End If



    '    Catch ex As Exception
    '        'MsgBox("[Send_To_Port]" & vbCrLf & ex.Message)
    '    End Try
    'End Function

    'Private Sub DisplayPole_Message()
    '    Try
    '        '*** Permanent display after clearing the customer display message
    '        '*** Start up message ie printing company name

    '        Dim DisplayText As String = "EDEE SUPER MARKET"
    '        Select Case CLS_Config.Company
    '            Case EDEE
    '                DisplayText = "EDEE SUPER MARKET"
    '            Case BOOKSHOP
    '                DisplayText = "EDEE BOOK SHOP"
    '            Case ZAHRABAKALA
    '                DisplayText = "NOOR AL ZAHRA BAKALA"
    '            Case CENTURY
    '                DisplayText = "CENTURY BAZAAR"
    '        End Select


    '        If CLS_Config.Has_Display_Pole Then

    '            With SerialPort2
    '                If .IsOpen Then
    '                    .Close()
    '                End If
    '                .PortName = CLS_Config.ComPort
    '                '.PortName = CLS_Config.ReceiptPrinter
    '                .Open()
    '                .Write(Chr(12))
    '                .Write(Chr(27) + Chr(64))
    '                .Write(DisplayText)
    '                .Write(Chr(27) + Chr(83) + "1")
    '                .Write(Chr(27) & Chr(68) + "1" + "3")
    '                .Close()
    '            End With


    '        ElseIf CLS_Config.Has_New_Display_Pole Then

    '            Dim cls As New Display
    '            cls.OpenPort()
    '            cls.ShowScrollText()
    '            cls.ClosePort()

    '            LastDisplayText = DisplayText
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Private Sub txtBarcode_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBarcode.ValueChanged
        If Me.txtBarcode.Value = "+" Then Me.txtBarcode.Value = Nothing
        Try
            If FixObjectString(Me.txtBarcode.Value) = Nothing Then Exit Sub
            If FixObjectString(Me.txtBarcode.Text) = Nothing Then Exit Sub
            If IsNumeric(Me.txtBarcode.Value) Then Exit Sub

            Dim key As Keys = [Enum].Parse(GetType(System.Windows.Forms.Keys), Me.txtBarcode.Value, False)
            If in_Key_List(key) Then Me.txtBarcode.Value = Nothing
            If in_Key_No_List(key) Then Me.txtBarcode.Value = Nothing
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtRemarks_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtRemarks.KeyDown, txtPONumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtBarcode.Focus()
            Me.txtBarcode.SelectAll()
        End If
    End Sub

    Private Sub txtRemarks_ValueChanged(sender As Object, e As System.EventArgs) Handles txtRemarks.ValueChanged
        CLS_Sale.Remark = FixControl(Me.txtRemarks)
    End Sub

    Private Sub txtPONumber_ValueChanged(sender As Object, e As System.EventArgs) Handles txtPONumber.ValueChanged
        CLS_Sale.PONumber = FixControl(Me.txtPONumber)
    End Sub

    Private Sub btnShowMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowMenu.Click
        If Me.UltraGroupBox1.Visible = True Then
            Me.UltraGroupBox1.Visible = False
        Else
            Me.UltraGroupBox1.Visible = True
        End If
    End Sub

    'Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    '    Try


    '        If NewDisplayText = LastDisplayText Then
    '            Dim cls As New Display
    '            cls.OpenPort()
    '            cls.ShowScrollText()
    '            cls.ClosePort()
    '            DisplayPole_Message()
    '        Else
    '            NewDisplayText = LastDisplayText
    '        End If



    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Private Sub txtQuantity_ValueChanged(sender As Object, e As EventArgs) Handles txtQuantity.ValueChanged
        If CLS_Config.NewSalesScreen AndAlso CStr(Me.txtBarcode.Value) <> Nothing Then
            Dim CLS_Item As New Item
            CLS_Item = Get_Item(CStr(Me.txtBarcode.Value))
            If IsNothing(CLS_Item) Then
            Else
                If CLS_Item.ItemType = ItemType.Serail_Item AndAlso TrimInt(Me.txtQuantity.Value) > 1 Then
                    Me.txtQuantity.Value = 1
                End If
            End If
        End If
    End Sub

#Region " MENU "

    Private Sub KPrice_Click(sender As System.Object, e As System.EventArgs) Handles KPrice.Click
        If FixControl(Me.txtBarcode) = Nothing Then
            Me.txtNotes.Text = "Price Missing"
            'MsgBox("Price Missing")
            Me.txtBarcode.Focus()
            Exit Sub
        End If
        If Not IsNumeric(Me.txtBarcode.Value) Then
            Me.txtNotes.Text = "Invalid Price"
            'MsgBox("Invalid Price")
            Me.txtBarcode.Focus()
            Exit Sub
        End If

        Call_Price()
        Operation = OperationType.None
        Me.txtBarcode.SelectAll()
        Me.txtBarcode.Value = Nothing
        Me.txtNotes.Text = Nothing
        Me.txtBarcode.Focus()
    End Sub

    Private Sub KMultiply_Click(sender As System.Object, e As System.EventArgs) Handles KMultiply.Click
        If FixControl(Me.txtBarcode) = Nothing Then
            Me.txtNotes.Text = "Quantity Missing"
            'MsgBox("Quantity Missing")
            Me.txtBarcode.Focus()
            Exit Sub
        End If
        If Not IsNumeric(Me.txtBarcode.Value) Then
            Me.txtNotes.Text = "Invalid Quantity"
            'MsgBox("Invalid Quantity")
            Me.txtBarcode.Focus()
            Exit Sub
        End If

        'If IsDBNull(Me.txtBarcode.Value) Or IsNothing(Me.txtBarcode.Value) Then Exit Sub
        'If Me.txtBarcode.Value = Nothing Then Exit Sub
        'If Not IsNumeric(Me.txtBarcode.Value) Then Exit Sub
        Me.txtQuantity.Value = CDec(Me.txtBarcode.Value)
        Me.txtBarcode.Value = Nothing
        Me.txtNotes.Text = Nothing
        Me.txtBarcode.Focus()
    End Sub

    Private Sub KCash_Click(sender As System.Object, e As System.EventArgs) Handles KCash.Click
        If FixControl(Me.txtBarcode) = Nothing Then
            Me.txtNotes.Text = "Amount Missing"
            'MsgBox("Amount Missing")
            Me.txtBarcode.Focus()
            Exit Sub
        End If
        If Not IsNumeric(Me.txtBarcode.Value) Then
            Me.txtNotes.Text = "Invalid Amount"
            'MsgBox("Invalid Amount")
            Me.txtBarcode.Focus()
            Exit Sub
        End If

        'If IsDBNull(Me.txtBarcode.Value) Or IsNothing(Me.txtBarcode.Value) Then Exit Sub
        'If Me.txtBarcode.Value = Nothing Then Exit Sub
        'If Not IsNumeric(Me.txtBarcode.Value) Then Exit Sub
        CLS_Sale.Payment = Decimal.Round(CDec(FixControl(Me.txtBarcode)) / CurrencyBase, 3)
        CLS_Sale.PaymentType = PaymentType.Cash
        Call_Tender()
    End Sub

    Private Sub KKnet_Click(sender As System.Object, e As System.EventArgs) Handles KKnet.Click
        If FixControl(Me.txtBarcode) = Nothing Then
            Me.txtNotes.Text = "Amount Missing"
            'MsgBox("Amount Missing")
            Me.txtBarcode.Focus()
            Exit Sub
        End If
        If Not IsNumeric(Me.txtBarcode.Value) Then
            Me.txtNotes.Text = "Invalid Amount"
            'MsgBox("Invalid Amount")
            Me.txtBarcode.Focus()
            Exit Sub
        End If
        'If IsDBNull(Me.txtBarcode.Value) Or IsNothing(Me.txtBarcode.Value) Then Exit Sub
        'If Me.txtBarcode.Value = Nothing Then Exit Sub
        'If Not IsNumeric(Me.txtBarcode.Value) Then Exit Sub
        CLS_Sale.Payment = Decimal.Round(CDec(FixControl(Me.txtBarcode)) / CurrencyBase, 3)
        CLS_Sale.PaymentType = PaymentType.KNet
        Call_Tender()
    End Sub

    Private Sub KMaster_Click(sender As System.Object, e As System.EventArgs) Handles KMaster.Click
        If FixControl(Me.txtBarcode) = Nothing Then
            Me.txtNotes.Text = "Amount Missing"
            'MsgBox("Amount Missing")
            Me.txtBarcode.Focus()
            Exit Sub
        End If
        If Not IsNumeric(Me.txtBarcode.Value) Then
            Me.txtNotes.Text = "Invalid Amount"
            'MsgBox("Invalid Amount")
            Me.txtBarcode.Focus()
            Exit Sub
        End If
        'If IsDBNull(Me.txtBarcode.Value) Or IsNothing(Me.txtBarcode.Value) Then Exit Sub
        'If Me.txtBarcode.Value = Nothing Then Exit Sub
        'If Not IsNumeric(Me.txtBarcode.Value) Then Exit Sub
        CLS_Sale.Payment = Decimal.Round(CDec(FixControl(Me.txtBarcode)) / CurrencyBase, 3)
        CLS_Sale.PaymentType = PaymentType.MasterCard
        Call_Tender()
    End Sub

    Private Sub KCreditSale_Click(sender As System.Object, e As System.EventArgs) Handles KCreditSale.Click
        CLS_Sale.Payment = 0.0
        CLS_Sale.PaymentType = PaymentType.Credit
        Call_Tender()
    End Sub

    Private Sub KEditBill_Click(sender As System.Object, e As System.EventArgs) Handles KEditBill.Click
        If Not IsNumeric(FixControl(Me.txtBarcode)) Then
            Me.txtNotes.Text = "ENTER BILL # TO EDIT"
            'MsgBox("ENTER BILL # TO EDIT")
            Me.txtBarcode.Focus()
            Exit Sub
        Else
            Dim SalesCode As Integer = CLS_Sale.Get_SalesCode(FixControl(Me.txtBarcode))
            If FixObjectNumber(SalesCode) <> 0 Then Call_Edit(SalesCode, Printer_On)
            Me.txtBarcode.Value = Nothing
            Me.txtNotes.Text = Nothing
            Me.txtBarcode.Focus()
        End If
    End Sub

    Private Sub KRemark_Click(sender As System.Object, e As System.EventArgs) Handles KRemark.Click
        Me.txtRemarks.Focus()
    End Sub

    Private Sub KCustomerList_Click(sender As System.Object, e As System.EventArgs) Handles KCustomerList.Click
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
    End Sub

    Private Sub KItemList_Click(sender As System.Object, e As System.EventArgs) Handles KItemList.Click
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
    End Sub

    Private Sub KDiscount_Click(sender As System.Object, e As System.EventArgs) Handles KDiscount.Click
        If FixControl(Me.txtBarcode) = Nothing Then
            Me.txtNotes.Text = "Amount Missing"
            'MsgBox("Amount Missing")
            Me.txtBarcode.Focus()
            Exit Sub
        End If
        If Not IsNumeric(Me.txtBarcode.Value) Then
            Me.txtNotes.Text = "Invalid Amount"
            'MsgBox("Invalid Amount")
            Me.txtBarcode.Focus()
            Exit Sub
        End If
        'If IsDBNull(Me.txtBarcode.Value) Or IsNothing(Me.txtBarcode.Value) Then Exit Sub
        'If Me.txtBarcode.Value = Nothing Then Exit Sub
        'If Not IsNumeric(Me.txtBarcode.Value) Then Exit Sub
        If Me.txtBarcode.Value / CurrencyBase > Me.txtTotalBill.Value Then
            Me.txtNotes.Text = "Discount Should be less then " & ConvertToString(CDec(Me.txtTotalBill.Value))
            Exit Sub
        End If

        Me.txtDiscount.Value = CDec(Me.txtBarcode.Value / CurrencyBase)
        Me.txtBarcode.Value = Nothing
        Me.txtNotes.Text = Nothing
        Me.txtBarcode.Focus()
    End Sub

    Private Sub KDiscountPer_Click(sender As System.Object, e As System.EventArgs) Handles KDiscountPer.Click
        If FixControl(Me.txtBarcode) = Nothing Then
            Me.txtNotes.Text = "Amount Missing"
            'MsgBox("Amount Missing")
            Me.txtBarcode.Focus()
            Exit Sub
        End If
        If Not IsNumeric(Me.txtBarcode.Value) Then
            Me.txtNotes.Text = "Invalid Amount"
            'MsgBox("Invalid Amount")
            Me.txtBarcode.Focus()
            Exit Sub
        End If
        If FixControl(Me.txtTotalBill) = Nothing Then
            Me.txtNotes.Text = "Total Bill Missing"
            'MsgBox("Total Bill Missing")
            Me.txtBarcode.Focus()
            Exit Sub
        End If
        'If IsDBNull(Me.txtTotalBill.Value) Or IsNothing(Me.txtTotalBill.Value) Then Exit Sub
        'If IsDBNull(Me.txtBarcode.Value) Or IsNothing(Me.txtBarcode.Value) Then Exit Sub
        'If Me.txtTotalBill.Value = Nothing Then Exit Sub
        'If Me.txtBarcode.Value = Nothing Then Exit Sub
        'If Not IsNumeric(Me.txtBarcode.Value) Then Exit Sub
        'If Not IsNumeric(Me.txtTotalBill.Value) Then Exit Sub
        If Me.txtBarcode.Value > 100 Then
            Me.txtNotes.Text = "Discount % Should be less then 100"
            Exit Sub
        End If

        Me.txtDiscount.Value = CDec(Me.txtBarcode.Value / 100) * Me.txtTotalBill.Value
        Me.txtBarcode.Value = Nothing
        Me.txtNotes.Text = Nothing
        Me.txtBarcode.Focus()
    End Sub

    Private Sub KPrint_Click(sender As System.Object, e As System.EventArgs) Handles KPrint.Click
        If Printer_On = True Then
            frmMainIns.PrintOnOff(False)
        Else
            frmMainIns.PrintOnOff(True)
        End If
    End Sub

    Private Sub KRepeat_Click(sender As System.Object, e As System.EventArgs) Handles KRepeat.Click
        Me.txtBarcode.Value = LastEnteredItem
        Me.txtPrice.Value = LastEnteredItemPrice * CurrencyBase
        DY_Price = True
        Call_Add()
        Me.txtQuantity.Value = 1
    End Sub

    Private Sub KDelete_Click(sender As System.Object, e As System.EventArgs) Handles KDelete.Click
        If FixControl(Me.txtBarcode) = Nothing Then
            Me.txtNotes.Text = "Record Missing"
            'MsgBox("Record Missing")
            Me.txtBarcode.Focus()
            Exit Sub
        End If
        If Not IsNumeric(Me.txtBarcode.Value) Then
            Me.txtNotes.Text = "Invalid Record"
            'MsgBox("Invalid Record")
            Me.txtBarcode.Focus()
            Exit Sub
        End If
        Call_Delete()
        Me.txtBarcode.Value = Nothing
        Me.txtNotes.Text = Nothing
        Me.txtBarcode.Focus()
    End Sub

    Private Sub KHold_Click(sender As System.Object, e As System.EventArgs) Handles KHold.Click
        Call_Hold()
    End Sub

    Private Sub KOpenItem_Click(sender As System.Object, e As System.EventArgs) Handles KOpenItem.Click
        Operation = OperationType.Open_Item
        Me.txtNotes.Text = "Type Item Code And Press Enter"
    End Sub

    Private Sub KBalance_Click(sender As System.Object, e As System.EventArgs) Handles KBalance.Click
        Call_Balance()
    End Sub

    Private Sub KSalesReturn_Click(sender As System.Object, e As System.EventArgs) Handles KSalesReturn.Click
        Call_SalesReturn()
    End Sub

    Private Sub KPayment_Click(sender As System.Object, e As System.EventArgs) Handles KPayment.Click
        Call_Payment()
    End Sub

    Private Sub KClear_Click(sender As System.Object, e As System.EventArgs) Handles KClear.Click
        Call_Cancel(TransectionType.Sales_Cancel, 0)
    End Sub

    Private Sub KClose_Click(sender As System.Object, e As System.EventArgs) Handles KClose.Click
        If MsgBox("You want to close POS ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            frmMainIns.Close()
        End If
    End Sub

    Private Sub KClearBox_Click(sender As System.Object, e As System.EventArgs) Handles KClearBox.Click
        Me.txtPrice.Value = Nothing
        Me.txtTotal.Value = Nothing
        Me.txtQuantity.Value = 1
        Me.txtNotes.Text = Nothing
    End Sub

#End Region

#Region " DYNIAMIC MENU "

    Dim _Category As New D_ItemCategory

    Private Sub GenerateCategory()
        Try

            Me.gbxItem.Text = "CATEGORY"

            Me.FlowItem.Controls.Clear()
            Me.FlowItem.Refresh()

            Using CONTEXT As New POSEntities
                Dim B As New Infragistics.Win.Misc.UltraButton
                For Each Category In (From q In CONTEXT.D_ItemCategory Select q).ToArray
                    B = New Infragistics.Win.Misc.UltraButton
                    B.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007ScrollbarButton
                    B.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
                    B.Appearance.ForeColor = Color.White
                    B.Name = Category.Code
                    B.Width = CategoryWidth
                    B.Height = CategoryHeight
                    'B.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
                    B.Font = New System.Drawing.Font("Arial", ImageFontSize, System.Drawing.FontStyle.Bold)
                    ToolTip1.SetToolTip(B, Category.Title)



                    Dim ImageName As String = CategoryImagePath & Category.Code & ".jpg"
                    If IO.File.Exists(ImageName) Then
                        B.Text = Nothing
                        B.Appearance.ImageBackground = Load_Img(ImageName)
                        B.Appearance.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched
                        'B.Appearance.ImageBackgroundOrigin = Infragistics.Win.ImageBackgroundOrigin.Client
                    Else
                        B.Text = Category.Title
                        B.Appearance.ForeColor = Color.White
                        'B.Appearance.ImageBackground = My.Resources.no_picture
                        B.Appearance.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Centered
                        'B.Appearance.ImageBackgroundOrigin = Infragistics.Win.ImageBackgroundOrigin.Client
                        B.Appearance.BackColor = Color.OrangeRed
                        B.Appearance.ForeColor = Color.White
                    End If

                    'Try
                    '    Dim Colors As String = TrimStr(Category.Colors)
                    '    Dim mycolor As Color = System.Drawing.ColorTranslator.FromHtml(Colors)
                    '    B.Appearance.BackColor = mycolor
                    'Catch ex As Exception
                    'End Try


                    AddHandler B.Click, AddressOf Category_Click
                    Me.FlowItem.Controls.Add(B)
                Next
            End Using


        Catch ex As Exception
            MsgBox("GenerateCategory" & vbCrLf & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub Category_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim CategoryCode As Integer = TryCast(sender, Infragistics.Win.Misc.UltraButton).Name
        Using CONTEXT = New POSEntities
            _Category = New D_ItemCategory
            _Category = Nothing
            _Category = (From obj In CONTEXT.D_ItemCategory _
                Where obj.Code = CategoryCode
                Select obj).ToList().SingleOrDefault()
        End Using

        GenerateItems()
        Me.txtBarcode.Focus()
    End Sub

    Private Sub GenerateItems()
        Try

            Me.gbxItem.Text = "ITEMS"

            Me.FlowItem.Controls.Clear()
            Me.FlowItem.Refresh()

            'BACK BUTTON
            Dim C As New Infragistics.Win.Misc.UltraButton
            C.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007ScrollbarButton
            C.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
            C.Appearance.BackColor = Color.Black
            C.Appearance.ForeColor = Color.White
            C.Name = _Category.Title
            C.Text = _Category.Title
            C.Width = ItemWidth
            C.Height = ItemHeight
            C.Font = New System.Drawing.Font("Arial", ImageFontSize, System.Drawing.FontStyle.Bold)
            ToolTip1.SetToolTip(C, _Category.Title)

            C.Appearance.ForeColor = Color.White
            C.Appearance.ImageBackground = My.Resources.arrow_94_48
            C.Appearance.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Centered

            C.Text = Nothing ' _Category.Name
            C.Appearance.ForeColor = Color.White
            C.Appearance.ImageBackground = My.Resources.arrow_94_48
            C.Appearance.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Centered
            C.Appearance.BackColor = Color.White
            C.Appearance.ForeColor = Color.White
            'End If

            AddHandler C.Click, AddressOf BackToCategory_Click
            Me.FlowItem.Controls.Add(C)
            'BACK BUTTON


            Using CONTEXT As New POSEntities
                For Each Item In (From q In CONTEXT.Item_Set Where q.Category = _Category.Code Select q).ToArray
                    Dim B As New Infragistics.Win.Misc.UltraButton
                    B.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007ScrollbarButton
                    B.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
                    B.Name = Item.Code
                    B.Width = ItemWidth
                    B.Height = ItemHeight
                    B.Font = New System.Drawing.Font("Arial", ImageFontSize, System.Drawing.FontStyle.Bold)
                    ToolTip1.SetToolTip(B, Item.ItemName)

                    Dim ImageName As String = ItemImagePath & Item.Code & ".jpg"
                    If IO.File.Exists(ImageName) Then
                        B.Text = Nothing
                        B.Appearance.ForeColor = Color.White
                        B.Appearance.ImageBackground = Load_Img(ImageName)
                        B.Appearance.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched
                        'B.Appearance.ImageBackgroundOrigin = Infragistics.Win.ImageBackgroundOrigin.Client
                    Else
                        B.Text = Item.ItemName
                        B.Appearance.ForeColor = Color.White
                        'B.Appearance.ImageBackground = My.Resources.no_picture
                        B.Appearance.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Centered
                        'B.Appearance.ImageBackgroundOrigin = Infragistics.Win.ImageBackgroundOrigin.Client
                        B.Appearance.BackColor = Color.OrangeRed
                        B.Appearance.ForeColor = Color.White
                    End If



                    'Try
                    '    Dim Colors As String = TrimStr(Item.Colors)
                    '    Dim mycolor As Color = System.Drawing.ColorTranslator.FromHtml(Colors)
                    '    B.Appearance.BackColor = mycolor
                    'Catch ex As Exception

                    'End Try
                    AddHandler B.Click, AddressOf Item_Click
                    Me.FlowItem.Controls.Add(B)
                Next

            End Using



        Catch ex As Exception
            MsgBox("GenerateItems" & vbCrLf & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub Item_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim Code As Integer = TryCast(sender, Infragistics.Win.Misc.UltraButton).Name
            Add_Item_By_Code(TrimInt(Code))

        Catch ex As Exception
            MsgBox("Item_Click" & vbCrLf & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub BackToCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GenerateCategory()
    End Sub

    Private Sub ActiveImageClick_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim Code As Integer = TryCast(sender, Infragistics.Win.Misc.UltraButton).Name
            If TrimInt(Code) = Nothing Then Exit Sub
            Dim ImageName As String = Nothing
            ImageName = ItemImagePath & Code & ".jpg"
            If Not File.Exists(ImageName) Then Exit Sub
            Process.Start(ImageName)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

    Private Sub KReprint_Click(sender As Object, e As EventArgs) Handles KReprint.Click
        Call_Reprint()
    End Sub
End Class