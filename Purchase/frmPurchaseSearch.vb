Imports System.Math
Imports CrystalDecisions.CrystalReports.Engine
Imports POS.FixControls
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmPurchaseSearch
    Dim DS As New DataSet
    'Dim DT As New DataTable
    Private Sub frmPurchaseSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, MenuStrip1.KeyUp, txtDateFrom.KeyUp, txtDateTo.KeyUp, UltraExpandableGroupBox1.KeyUp, grdList.KeyUp, CRV_DetailBill.KeyUp, CRV_Receipt.KeyUp
        If e.KeyCode = Keys.End Then
            Me.Close()
        End If
    End Sub
    Private Sub frmPurchaseSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.Cart_Blue
        Try

            If TrimBoolean(CLS_Config.AddPurchaseDetail) Then
                FillDrop(Me.DropItem, "ItemName", "Code", Table.Item, "CostPrice", "BarCode", "BarCode2")
            Else
                DropItem.Visible = False
                txtSerailNum.Visible = False
                UltraLabel2.Visible = False
                UltraLabel10.Visible = False
            End If

            Me.txtTotalFrom.InputMask = Mask_Amount5
            Me.txtTotalTo.InputMask = Mask_Amount5


            FillDropWithCondition(Me.DropSupplier, "Title", "AccountNum", Table.Account, , , , , " WHERE AccountType = " & AccountType.Supplier)
            FillDrop(Me.DropUser, "UserName", "Code", Table.P_User)

            If Not UserClass.Allow_Sale_Edit Then Me.btnEdit.Visible = False

            Me.txtDateFrom.Value = Now.Date
            Me.txtDateTo.Value = New DateTime(Now.Year, Now.Month, Now.Day, 23, 59, 59)
            Me.txtDateFrom.Focus()

        Catch ex As Exception
            MsgBox("frmPurchaseSearch_Load" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        FillGrid()
    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Try
            If IsDBNull(Me.grdList.ActiveRow) Or IsNothing(Me.grdList.ActiveRow) Then Exit Sub
            If IsDBNull(Me.grdList.ActiveRow.Cells("Code").Value) Or IsNothing(Me.grdList.ActiveRow.Cells("Code").Value) Then Exit Sub
            If Me.grdList.ActiveRow.Cells("Code").Value = Nothing Then Exit Sub

            If Not UserClass.Allow_Purchase_Edit Then
                MsgBox("Permission Denied.")
                Me.DropSupplier.Focus()
                Exit Sub
            End If
            If IsDBNull(Me.grdList.ActiveRow.Cells("Code").Value) Or IsNothing(Me.grdList.ActiveRow.Cells("Code").Value) Then
                MsgBox("Select Record first")
                Exit Sub
            ElseIf Me.grdList.ActiveRow.Cells("Code").Value = Nothing Then
                MsgBox("Select Record first")
                Exit Sub
            End If

            If FixCellBoolean(Me.grdList.ActiveRow.Cells("Posted")) = True Then
                MsgBox("Purchase has been posted.Can not be edited.")
                Exit Sub
            End If

            If FixCellNumber(Me.grdList.ActiveRow.Cells("PaidAmount")) > 0 Then
                MsgBox("Payment has been maid for the selected purchase.Can not be edited.")
                Exit Sub
            End If

            frmPurchase_NewIns = New frmPurchase_New(CInt(Me.grdList.ActiveRow.Cells("SupplierCode").Value), CInt(Me.grdList.ActiveRow.Cells("Code").Value))
            frmPurchase_NewIns.ShowDialog()

            FillGrid()


        Catch ex As Exception
            MsgBox("btnEdit_Click" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnClearAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClearAll.Click
        Try
            Me.txtDateFrom.Value = Now.Date
            Me.txtDateTo.Value = Now
            Me.txtTotalFrom.Value = Nothing
            Me.txtTotalTo.Value = Nothing
            Me.txtBill.Value = Nothing
            Me.txtTotalTo.Value = Nothing
            Me.DropSupplier.Value = Nothing
            Me.DropUser.Value = Nothing
            Me.DropItem.Value = Nothing

            Me.grdList.DataSource = Nothing
            Me.grdList.DataBind()

        Catch ex As Exception
            MsgBox("btnClearAll_Click" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub DropItem_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DropItem.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim CLS_Item As New Item

                If IsDBNull(Me.DropItem.Value) Or IsNothing(Me.DropItem.Value) Then
                ElseIf Me.DropItem.Value = Nothing Then
                Else
                    CLS_Item = New Item
                    CLS_Item = Get_Item(CStr(Me.DropItem.Value))
                    If IsNothing(CLS_Item) Then
                        MsgBox("Item Dose Not Exists")
                        Me.DropItem.Focus()
                    Else
                        Me.DropItem.Value = CLS_Item.Code
                        btnSearch_Click(sender, e)
                    End If
                    Exit Sub
                End If


                If IsDBNull(Me.DropItem.Text) Or IsNothing(Me.DropItem.Text) Then
                Else
                    CLS_Item = New Item
                    CLS_Item = Get_Item(CStr(Me.DropItem.Text))
                    If IsNothing(CLS_Item) Then
                        MsgBox("Item Dose Not Exists")
                        Me.DropItem.Focus()
                    Else
                        Me.DropItem.Value = CLS_Item.Code
                        btnSearch_Click(sender, e)
                    End If

                End If


            End If

        Catch ex As Exception
            MsgBox("DropItem_KeyDown" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub grdList_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles grdList.DoubleClickRow
        'Try
        '    If IsDBNull(Me.grdList.ActiveRow) Or IsNothing(Me.grdList.ActiveRow) Then Exit Sub
        '    If IsDBNull(Me.grdList.ActiveRow.Cells("PurchaseCode").Value) Or IsNothing(Me.grdList.ActiveRow.Cells("PurchaseCode").Value) Then Exit Sub
        '    If Me.grdList.ActiveRow.Cells("PurchaseCode").Value = Nothing Then Exit Sub
        '    LoadReport(CInt(Me.grdList.ActiveRow.Cells("PurchaseCode").Value))

        'Catch ex As Exception
        '    MsgBox("grdList_DoubleClickRow" & vbCrLf & ex.Message)
        'End Try
    End Sub
    Private Sub FillGrid()
        Try
            DS = New DataSet
            Dim DT As New DataTable
            'DT = DBO.ReturnDataTableFromSQL("SELECT  rank() OVER ( ORDER BY EffectiveDate DESC,Code ASC ) AS Rec ,Code,AccountNum,SupplierCode,SupplierName,EffectiveDate,InvoiceNum,TotalAmount,PaidAmount,Balance,Posted,UserName,Notes FROM    Purchase_Summary WHERE Code IN (SELECT PurchaseCode FROM  Purchase_Entry_View " & Where() & ")  ORDER BY EffectiveDate DESC")

            If TrimBoolean(CLS_Config.AddPurchaseDetail) Then
                DT = DBO.ReturnDataTableFromSQL("SELECT  Code,AccountNum,SupplierCode,SupplierName,EffectiveDate,InvoiceNum,TotalAmount ,Discount,Returned,PaidAmount,DiscountAtPay ,Balance ,Posted,UserName,Notes FROM    Purchase_Summary WHERE Code IN (SELECT PurchaseCode FROM  Purchase_Entry_View " & Where() & ")  ORDER BY EffectiveDate DESC")

                Dim DT2 As New DataTable
                DT2 = DBO.ReturnDataTableFromSQL("SELECT  Code,PurchaseCode,ItemName,Qty,UnitPrice,Price,ExpiryDate,AvgPrice,SerailNum FROM    Purchase_Entry_View WHERE   PurchaseCode  IN (SELECT PurchaseCode FROM  Purchase_Entry_View " & Where() & ")  ")
                DS.Tables.Add(DT)
                DS.Tables.Add(DT2)

                If DS.Tables(0).Rows.Count > 0 Then
                    'Create the Data Relationship
                    DS.Relations.Add("Child", DS.Tables(0).Columns("Code"), _
                                                DS.Tables(1).Columns("PurchaseCode"))
                End If
            Else
                DT = DBO.ReturnDataTableFromSQL("SELECT  Code,AccountNum,SupplierCode,SupplierName,EffectiveDate,InvoiceNum,TotalAmount ,Discount,Returned,PaidAmount,DiscountAtPay ,Balance ,Posted,UserName,Notes FROM    Purchase_Summary  " & Where() & " ORDER BY EffectiveDate DESC")

                DS.Tables.Add(DT)

            End If
           

            Me.grdList.DataSource = DT
            'Me.grdList.DataMember = "Table1"
            Me.grdList.DataBind()
            Me.grdList.DisplayLayout.Override.RowAlternateAppearance = RowAlternateAppearance
            Me.grdList.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle
            'Exit Sub
            'Set Grid's Columns Order (Arrnage) 
            Me.grdList.DisplayLayout.Bands(0).Columns("AccountNum").Hidden = True
            Me.grdList.DisplayLayout.Bands(0).Columns("SupplierCode").Hidden = True

            'Me.grdList.DisplayLayout.Bands(0).Columns("Rec").Header.VisiblePosition = 0
            Me.grdList.DisplayLayout.Bands(0).Columns("SupplierName").Header.VisiblePosition = 1
            Me.grdList.DisplayLayout.Bands(0).Columns("EffectiveDate").Header.VisiblePosition = 2
            Me.grdList.DisplayLayout.Bands(0).Columns("InvoiceNum").Header.VisiblePosition = 3
            Me.grdList.DisplayLayout.Bands(0).Columns("TotalAmount").Header.VisiblePosition = 4
            Me.grdList.DisplayLayout.Bands(0).Columns("Discount").Header.VisiblePosition = 5
            Me.grdList.DisplayLayout.Bands(0).Columns("Returned").Header.VisiblePosition = 6
            Me.grdList.DisplayLayout.Bands(0).Columns("PaidAmount").Header.VisiblePosition = 7
            Me.grdList.DisplayLayout.Bands(0).Columns("DiscountAtPay").Header.VisiblePosition = 8
            Me.grdList.DisplayLayout.Bands(0).Columns("Balance").Header.VisiblePosition = 9
            Me.grdList.DisplayLayout.Bands(0).Columns("Posted").Header.VisiblePosition = 10
            Me.grdList.DisplayLayout.Bands(0).Columns("UserName").Header.VisiblePosition = 11
            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").Header.VisiblePosition = 12
            Me.grdList.DisplayLayout.Bands(0).Columns("Code").Header.VisiblePosition = 13

            Me.grdList.DisplayLayout.Bands(0).Columns("EffectiveDate").MaskInput = Mask_Date
            Me.grdList.DisplayLayout.Bands(0).Columns("TotalAmount").MaskInput = Mask_Amount
            Me.grdList.DisplayLayout.Bands(0).Columns("Discount").MaskInput = Mask_Amount
            Me.grdList.DisplayLayout.Bands(0).Columns("Returned").MaskInput = Mask_Amount
            Me.grdList.DisplayLayout.Bands(0).Columns("PaidAmount").MaskInput = Mask_Amount
            Me.grdList.DisplayLayout.Bands(0).Columns("DiscountAtPay").MaskInput = Mask_Amount
            Me.grdList.DisplayLayout.Bands(0).Columns("Balance").MaskInput = Mask_Amount

            'Me.grdList.DisplayLayout.Bands(0).Columns("Rec").Width = 50
            Me.grdList.DisplayLayout.Bands(0).Columns("Balance").Width = 100
            Me.grdList.DisplayLayout.Bands(0).Columns("Posted").Width = 50
            Me.grdList.DisplayLayout.Bands(0).Columns("EffectiveDate").Width = 50

            If TrimBoolean(CLS_Config.AddPurchaseDetail) AndAlso DS.Tables(0).Rows.Count > 0 Then
                Me.grdList.DisplayLayout.Bands(1).Columns("Code").Hidden = True
                Me.grdList.DisplayLayout.Bands(1).Columns("PurchaseCode").Hidden = True
                Me.grdList.DisplayLayout.Bands(1).Columns("ItemName").Width = 250

                Me.grdList.DisplayLayout.Bands(1).Columns("ItemName").Header.VisiblePosition = 0
                Me.grdList.DisplayLayout.Bands(1).Columns("Qty").Header.VisiblePosition = 1
                Me.grdList.DisplayLayout.Bands(1).Columns("UnitPrice").Header.VisiblePosition = 2
                Me.grdList.DisplayLayout.Bands(1).Columns("Price").Header.VisiblePosition = 3
                Me.grdList.DisplayLayout.Bands(1).Columns("ExpiryDate").Header.VisiblePosition = 4

            End If

            'Me.grdList.DisplayLayout.Bands(0).ColumnFilters.ClearAllFilters()
            'Me.grdList.DisplayLayout.Bands(0).ColumnFilters("Balance").FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.GreaterThan, 0)


        Catch ex As Exception
            MsgBox("FillGrid" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Function isValid() As Boolean
        Try
            If FixControl(Me.txtDateFrom) = Null_Date Then
                MSG.ErrorOk("[DATE FROM] is missing.")
                Me.txtDateFrom.Focus()
                Me.txtDateFrom.SelectAll()
                Return False
            End If

            If FixControl(Me.txtDateTo) <> Null_Date Then
                If CDate(Me.txtDateFrom.Value) > CDate(Me.txtDateTo.Value) Then
                    MSG.ErrorOk("[DATE TO] should be less then [DATE FROM].")
                    Me.txtDateTo.Focus()
                    Me.txtDateTo.SelectAll()
                    Return False
                End If
            End If

            If FixControl(Me.txtTotalFrom) <> Nothing And FixControl(Me.txtTotalTo) <> Nothing Then
                If CDec(Me.txtTotalFrom.Value) > CDec(Me.txtTotalTo.Value) Then
                    MSG.ErrorOk("[TOTAL TO] should be less then [TOTAL FROM].")
                    Me.txtTotalTo.Focus()
                    Me.txtTotalTo.SelectAll()
                    Return False
                End If
            End If


            Return True
        Catch ex As Exception
            MsgBox("isValid" & vbCrLf & ex.Message)
        End Try
    End Function
    Private Function Where() As String
        Dim Result As String = Nothing
        Try
            Result = " WHERE EffectiveDate >= '" & FixControlDateToString(Me.txtDateFrom) & "'"

            If FixControl(Me.txtDateTo) <> Null_Date Then Result &= " AND EffectiveDate <= '" & FixControlDateToString(Me.txtDateTo) & "'"

            If FixControl(Me.txtTotalFrom) <> Nothing Then Result &= " AND TotalAmount >= " & FixControl(Me.txtTotalFrom)
            If FixControl(Me.txtTotalTo) <> Nothing Then Result &= " AND TotalAmount <= " & FixControl(Me.txtTotalTo)

            If FixControl(Me.txtBill) <> Nothing Then Result &= " AND InvoiceNum = '" & FixControl(Me.txtBill) & "' "
            If TrimBoolean(CLS_Config.AddPurchaseDetail) AndAlso FixControl(Me.txtSerailNum) <> Nothing Then Result &= " AND SerailNum = '" & FixControl(Me.txtSerailNum) & "' "

            If IsDBNull(Me.DropSupplier.Value) Or IsNothing(Me.DropSupplier.Value) Then
            ElseIf Me.DropSupplier.Value = Nothing Then
            Else
                Result &= " AND AccountNum = '" & Me.DropSupplier.Value & "' "
            End If
            If FixControl(Me.DropUser) <> Nothing Then Result &= " AND UserCode = " & FixControl(Me.DropUser)
            If FixControl(Me.DropItem) <> Nothing Then Result &= " AND ItemCode = " & FixControl(Me.DropItem)

        Catch ex As Exception
            MsgBox("Where" & vbCrLf & ex.Message)
        End Try
        Return Result
    End Function
    Private Function Get_Item(ByVal Barcode As String) As Item
        Try
            Dim DT As New DataTable
            DT = Me.DropItem.DataSource

            Dim CLS As New Item
            'IF BARCODE IS NULL RETURN EMPTY CLS
            If FixObjectString(Barcode) = Nothing Then Return Nothing

            'IF BARCODE EXIST IN DS LOAD & RETURN CLS
            Dim dr() As DataRow = DT.Select(" Barcode='" & Barcode & "'")
            If dr.Length > 0 Then
                CLS.Code = IIf(IsDBNull(dr(0).Item("Code")), 0, dr(0).Item("Code"))
                CLS.ItemName = IIf(IsDBNull(dr(0).Item("ItemName")), 0, dr(0).Item("ItemName"))
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
                CLS.Barcode = IIf(IsDBNull(dr2(0).Item("Barcode")), 0, dr2(0).Item("Barcode"))
                CLS.Barcode2 = IIf(IsDBNull(dr2(0).Item("Barcode2")), 0, dr2(0).Item("Barcode2"))
                Return CLS
            End If

            'IF BARCODE IS NOT CODE RETURN EMPTY CLS
            Return Nothing
        Catch ex As Exception
            MSG.ErrorOk("[Get_Item]" & vbCrLf & ex.Message)
            Return Nothing
        End Try
    End Function
    Private Sub LoadReport(ByVal PurchaseCode As Integer)
        Try
            Dim DT As New DataTable
            DT = DBO.ReturnDataTable("SELECT * FROM Sales_Full_View Where PurchaseCode=" & CInt(PurchaseCode))


            Dim report As New ReportDocument
            report.Load(CLS_Config.ReportPath & "Bill Receipt.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)
            report.SetDataSource(DT)

            report.SetParameterValue("AccCashCustomer", FixObjectNumber(CLS_Config.AccCashCustomer))
            report.SetParameterValue("CompanyName", FixObjectString(CLS_Config.CompanyName))
            report.SetParameterValue("Address1", FixObjectString(CLS_Config.Address1))
            report.SetParameterValue("Address2", FixObjectString(CLS_Config.Address2))
            report.SetParameterValue("Address3", FixObjectString(CLS_Config.Address3))
            report.SetParameterValue("Tel", FixObjectString(CLS_Config.Tel))
            report.SetParameterValue("CustomerBalance", 0)
            report.SetParameterValue("CashAmount", 0)

            Me.CRV_Receipt.ReportSource = report



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
            report2.SetParameterValue("isSaleReturn", False)
            'Select Case CLS_Sale.TransectionType
            '    Case TransectionType.CashSaleReturn, TransectionType.CreditSaleReturn
            '        report2.SetParameterValue("isSaleReturn", True)
            '    Case Else
            '        report2.SetParameterValue("isSaleReturn", False)
            'End Select

            Me.CRV_DetailBill.ReportSource = report2



            Me.UltraTabControl1.Tabs(1).Selected = True

        Catch ex As Exception
            MsgBox("LoadReport" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub grdList_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdList.InitializeLayout
        ' Set the RowSelectorNumberStyle to enable the row-numbers.
        e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex

        ' You can control the appearance of the row numbers using the RowSelectorAppearance.
        e.Layout.Override.RowSelectorAppearance.ForeColor = Color.Blue
        e.Layout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

        ' You can explicitly set the width of the row selectors if the default one calculated
        ' by the UltraGrid is not enough.
        e.Layout.Override.RowSelectorWidth = 25


    End Sub
End Class