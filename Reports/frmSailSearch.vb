Imports System.Math
Imports CrystalDecisions.CrystalReports.Engine
Imports POS.FixControls
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmSailSearch
    Dim DT As New DataTable
    Private Sub frmSailSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, MenuStrip1.KeyUp, txtDateFrom.KeyUp, txtDateTo.KeyUp, UltraExpandableGroupBox1.KeyUp, grdList.KeyUp, CRV_DetailBill.KeyUp, CRV_Receipt.KeyUp
        If e.KeyCode = Keys.End Then
            Me.Close()
        End If
    End Sub
    Private Sub frmSailSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.Cart_Blue
        Try
            Me.txtTotalFrom.InputMask = Mask_Amount5
            Me.txtTotalTo.InputMask = Mask_Amount5


            FillDrop(Me.DropItem, "ItemName", "Code", Table.Item, "CostPrice", "BarCode", "BarCode2")
            FillDropWithCondition(Me.DropCustomer, "Title", "AccountNum", Table.Account, , , , , " WHERE AccountType = " & AccountType.Customer)
            FillDrop(Me.DropUser, "UserName", "Code", Table.P_User)
            FillDrop(Me.DropCounter, "Title", "Code", Table.D_Counter)

            If Not UserClass.Allow_Sale_Edit Then Me.btnEdit.Visible = False
            If Not UserClass.Allow_Sale_Delete Then Me.btnDelete.Visible = False

            Me.txtDateFrom.Value = Now.Date
            Me.txtDateTo.Value = New DateTime(Now.Year, Now.Month, Now.Day, 23, 59, 59)
            Me.txtDateFrom.Focus()

        Catch ex As Exception
            MsgBox("frmSailSearch_Load" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        FillGrid()
    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Try
            If IsDBNull(Me.grdList.ActiveRow) Or IsNothing(Me.grdList.ActiveRow) Then Exit Sub
            If IsDBNull(Me.grdList.ActiveRow.Cells("SaleCode").Value) Or IsNothing(Me.grdList.ActiveRow.Cells("SaleCode").Value) Then Exit Sub
            If Me.grdList.ActiveRow.Cells("SaleCode").Value = Nothing Then Exit Sub

            'If CLS_Config.NewSalesScreen Then
            '    If IsNothing(frmSales2Ins) Then
            '        frmSales2Ins = New frmSales2
            '        frmSales2Ins.MdiParent = Me.MdiParent
            '        frmSales2Ins.Show()
            '    End If

            '    frmSales2Ins.Call_Edit(Me.grdList.ActiveRow.Cells("SaleCode").Value)
            'Else
            Dim local_Printer_On As Boolean = Printer_On

            If IsNothing(frmSalesIns) Then
                frmSalesIns = New frmSales(False)
                frmSalesIns.MdiParent = Me.MdiParent
                frmSalesIns.Show()
            End If

            frmSalesIns.Call_Edit(Me.grdList.ActiveRow.Cells("SaleCode").Value, local_Printer_On)

            'End If

        Catch ex As Exception
            MsgBox("btnEdit_Click" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        'Try
        '    If IsDBNull(Me.grdList.ActiveRow) Or IsNothing(Me.grdList.ActiveRow) Then Exit Sub
        '    If IsDBNull(Me.grdList.ActiveRow.Cells("SaleCode").Value) Or IsNothing(Me.grdList.ActiveRow.Cells("SaleCode").Value) Then Exit Sub
        '    If Me.grdList.ActiveRow.Cells("SaleCode").Value = Nothing Then Exit Sub

        '    If MsgBox("Are you sure you want to completly delete the selected sales entry?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub

        '    Dim CLS As New Sale
        '    CLS.Delete(Me.grdList.ActiveRow.Cells("SaleCode").Value)

        '    FillGrid()

        'Catch ex As Exception
        '    MsgBox("btnDelete_Click" & vbCrLf & ex.Message)
        'End Try

        Try
            If IsDBNull(Me.grdList.ActiveRow) Or IsNothing(Me.grdList.ActiveRow) Then Exit Sub
            Dim SaleCode As Integer = TrimInt(Me.grdList.ActiveRow.Cells("SaleCode").Value)
            If SaleCode = 0 Then Exit Sub
          
            Using CONTEXT = New POSEntities
                If (From q In CONTEXT.Sale_Set Where q.ReturnSaleCode = SaleCode Select q).Count > 0 Then
                    MsgBox("Sales already returned.")
                    Exit Sub
                End If
            End Using

            Dim BillNo As String = TrimStr(Me.grdList.ActiveRow.Cells("BillNo").Value)

            Dim frm As New frmDialogResult("You are about to make a sale return for Bill#." & BillNo & vbCrLf & vbCrLf & "You can not undo this." & vbCrLf & vbCrLf & "Are you sure?")
            If frm.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub

            Dim local_Printer_On As Boolean = Printer_On

            If Not IsNothing(frmSalesIns) Then
                frmSalesIns.Close()
            End If

            frmSalesIns = New frmSales(True)
            frmSalesIns.MdiParent = Me.MdiParent
            frmSalesIns.Show()

            frmSalesIns.Call_Return(Me.grdList.ActiveRow.Cells("SaleCode").Value, local_Printer_On)


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
            Me.txtBillFrom.Value = Nothing
            Me.txtTotalTo.Value = Nothing
            Me.DropCustomer.Value = Nothing
            Me.DropUser.Value = Nothing
            Me.DropItem.Value = Nothing

            Me.grdList.Visible = False

        Catch ex As Exception
            MsgBox("btnClearAll_Click" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    'Private Sub DropItem_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DropItem.KeyDown
    '    Try
    '        If e.KeyCode = Keys.Enter Then

    '            If FixControl(Me.DropItem) = Nothing Then Exit Sub

    '            Dim CLS_Item As New Item
    '            CLS_Item = Get_Item(CStr(Me.DropItem.Value))

    '            If IsNothing(CLS_Item) Then
    '                Me.DropItem.Value = Nothing
    '            Else
    '                Me.DropItem.Value = CLS_Item.Code
    '            End If

    '        End If

    '    Catch ex As Exception
    '        MsgBox("DropItem_ValueChanged" & vbCrLf & ex.Message)
    '    End Try
    'End Sub
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
        Try
            If IsDBNull(Me.grdList.ActiveRow) Or IsNothing(Me.grdList.ActiveRow) Then Exit Sub
            If IsDBNull(Me.grdList.ActiveRow.Cells("SaleCode").Value) Or IsNothing(Me.grdList.ActiveRow.Cells("SaleCode").Value) Then Exit Sub
            If Me.grdList.ActiveRow.Cells("SaleCode").Value = Nothing Then Exit Sub
            LoadReport(CInt(Me.grdList.ActiveRow.Cells("SaleCode").Value))

        Catch ex As Exception
            MsgBox("grdList_DoubleClickRow" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub FillGrid()
        Try

            If Not isValid() Then Exit Sub

            Me.grdList.Visible = True

            DT = New DataTable
            'DT = DBO.ReturnDataTableFromSQL("SELECT  SaleCode,BillNo,TransectionDate,( CASE WHEN TransectionTypeCode IN ( 4, 5 ) THEN TotalBill * -1 ELSE TotalBill END ) AS TotalBill ,Discount,( CASE WHEN TransectionTypeCode IN ( 4, 5 ) THEN NetBill * -1 ELSE NetBill END ) AS NetBill ,AccountName AS [Customer Name],Remark,PONumber,PaymentType,TransectionType,TransectionTypeCode,UserName FROM Sales_Full_View " & Where() & " GROUP BY SaleCode,BillNo,TransectionDate,TotalBill,Discount,NetBill,AccountName ,Remark,PONumber,PaymentType,TransectionType,TransectionTypeCode,UserName ORDER BY TransectionDate DESC")
            DT = DBO.ReturnDataTableFromSQL("SELECT  Code AS SaleCode,BillNo,TransectionDate,( CASE WHEN TransectionTypeCode IN ( 4, 5 ) THEN TotalBill * -1 ELSE TotalBill END ) AS TotalBill ,Discount,( CASE WHEN TransectionTypeCode IN ( 4, 5 ) THEN NetBill * -1 ELSE NetBill END ) AS NetBill ,AccountName AS [Customer Name],Remark,PONumber,PaymentType,TransectionType,TransectionTypeCode,UserName,MemberName,MembershipNumber FROM Sale_View " & Where() & " ORDER BY TransectionDate DESC")

            Me.grdList.DataSource = DT
            'Me.grdList.DataMember = "Table"
            Me.grdList.DataBind()
            Me.grdList.DisplayLayout.Override.RowAlternateAppearance = RowAlternateAppearance


            Me.grdList.DisplayLayout.Bands(0).Columns("MemberName").Hidden = Not CLS_Config.MembershipSystem
            Me.grdList.DisplayLayout.Bands(0).Columns("MembershipNumber").Hidden = Not CLS_Config.MembershipSystem
            Me.grdList.DisplayLayout.Bands(0).Columns("SaleCode").Hidden = True
            Me.grdList.DisplayLayout.Bands(0).Columns("TransectionTypeCode").Hidden = True
            Me.grdList.DisplayLayout.Bands(0).Columns("TransectionDate").MaskInput = "{LOC}dd/mm/yyyy hh:mm"
            Me.grdList.DisplayLayout.Bands(0).Columns("TotalBill").MaskInput = Mask_Amount
            Me.grdList.DisplayLayout.Bands(0).Columns("Discount").MaskInput = Mask_Amount
            Me.grdList.DisplayLayout.Bands(0).Columns("NetBill").MaskInput = Mask_Amount

            Me.grdList.DisplayLayout.Bands(0).Columns("BillNo").Header.VisiblePosition = 0
            Me.grdList.DisplayLayout.Bands(0).Columns("TransectionDate").Header.VisiblePosition = 1
            Me.grdList.DisplayLayout.Bands(0).Columns("TotalBill").Header.VisiblePosition = 2
            Me.grdList.DisplayLayout.Bands(0).Columns("Discount").Header.VisiblePosition = 3
            Me.grdList.DisplayLayout.Bands(0).Columns("NetBill").Header.VisiblePosition = 4
            Me.grdList.DisplayLayout.Bands(0).Columns("Customer Name").Header.VisiblePosition = 5
            Me.grdList.DisplayLayout.Bands(0).Columns("Remark").Header.VisiblePosition = 6
            Me.grdList.DisplayLayout.Bands(0).Columns("PONumber").Header.VisiblePosition = 7
            Me.grdList.DisplayLayout.Bands(0).Columns("PaymentType").Header.VisiblePosition = 8
            Me.grdList.DisplayLayout.Bands(0).Columns("TransectionType").Header.VisiblePosition = 9
            Me.grdList.DisplayLayout.Bands(0).Columns("UserName").Header.VisiblePosition = 10

            Me.grdList.DisplayLayout.Bands(0).Columns("TotalBill").Width = 100
            Me.grdList.DisplayLayout.Bands(0).Columns("Discount").Width = 100
            Me.grdList.DisplayLayout.Bands(0).Columns("NetBill").Width = 100

            Me.UltraTabControl1.Tabs(0).Selected = True


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


            If FixControl(Me.txtBillFrom) <> Nothing And FixControl(Me.txtBillTo) <> Nothing Then
                If CDec(Me.txtBillFrom.Value) > CDec(Me.txtBillTo.Value) Then
                    MSG.ErrorOk("[BILL TO] should be less then [BILL FROM].")
                    Me.txtBillTo.Focus()
                    Me.txtBillTo.SelectAll()
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
            Result = " WHERE (TransectionDate >= '" & FixControlDateToString(Me.txtDateFrom) & "')"

            If FixControl(Me.txtDateTo) <> Null_Date Then Result &= " AND (TransectionDate <= '" & FixControlDateToString(Me.txtDateTo) & "')"

            If FixControl(Me.txtTotalFrom) <> Nothing Then Result &= " AND (NetBill >= " & FixControl(Me.txtTotalFrom) & ") "
            If FixControl(Me.txtTotalTo) <> Nothing Then Result &= " AND (NetBill <= " & FixControl(Me.txtTotalTo) & ") "

            If FixControl(Me.txtBillFrom) <> Nothing Then Result &= " AND (BillNo >= " & FixControl(Me.txtBillFrom) & ") "
            If FixControl(Me.txtBillTo) <> Nothing Then Result &= " AND (BillNo <= " & FixControl(Me.txtBillTo) & ") "
            If FixControl(Me.txtPONumber) <> Nothing Then Result &= " AND (PONumber LIKE '%" & FixControl(Me.txtPONumber) & "%') "
            If FixControl(Me.txtSerailNum) <> Nothing Then Result &= " AND (SerailNum LIKE '%" & FixControl(Me.txtSerailNum) & "%') "

            If IsDBNull(Me.DropCustomer.Value) Or IsNothing(Me.DropCustomer.Value) Then
            ElseIf Me.DropCustomer.Value = Nothing Then
            Else
                Result &= " AND (AccountNum = '" & Me.DropCustomer.Value & "') "
            End If
            If FixControl(Me.DropUser) <> Nothing Then Result &= " AND (UserCode = " & FixControl(Me.DropUser) & ") "
            If FixControl(Me.DropCounter) <> Nothing Then Result &= " AND (CounterCode = " & FixControl(Me.DropCounter) & ") "
            If FixControl(Me.DropItem) <> Nothing Then
                'Result &= " AND ItemCode = " & FixControl(Me.DropItem)
                Result &= " AND (Code IN (SELECT SE.SaleCode FROM   dbo.Sale_Entry AS SE WHERE  SE.ItemCode=" & FixControl(Me.DropItem) & ")) "
            End If

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
    Private Sub LoadReport(ByVal SaleCode As Integer, Optional Print As Boolean = False)
        Try
            Dim DT As New DataTable
            DT = DBO.ReturnDataTable("SELECT * FROM Sales_Full_View Where SaleCode=" & CInt(SaleCode))


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
            report.SetParameterValue("MembershipRedemptionCash", FixObjectBoolean(CLS_Config.MembershipRedemptionCash))


            Using CONTEXT = New POSEntities

                Dim MembershipCode As Integer = TrimInt(DT.Rows(0).Item("MembershipCode"))
                If TrimInt(MembershipCode) = 0 Then
                    report.SetParameterValue("MembershipNumber", FixObjectString(""))
                    report.SetParameterValue("MembershipName", FixObjectString(""))
                    report.SetParameterValue("MembershipPoints", FixObjectString(""))
                    report.SetParameterValue("MembershipPointsAmt", FixObjectString(""))
                Else

                    Dim CLS_Membership As New Membership
                    CLS_Membership = (From q In CONTEXT.Memberships Where q.Code = MembershipCode Select q).ToList().SingleOrDefault()

                    If IsDBNull(CLS_Membership) OrElse IsNothing(CLS_Membership) Then
                        report.SetParameterValue("MembershipNumber", FixObjectString(""))
                        report.SetParameterValue("MembershipName", FixObjectString(""))
                        report.SetParameterValue("MembershipPoints", FixObjectString(""))
                        report.SetParameterValue("MembershipPointsAmt", FixObjectString(""))
                    Else
                        Dim MmebershipPoints As Decimal
                        Dim MmebershipPointsAmt As Decimal

                        Dim Query = (From q In CONTEXT.V_MembershipHistory Where q.Code = CLS_Membership.Code Select q.Debit - q.Credit)
                        If Query.ToList.Count > 0 Then
                            MmebershipPoints = ConvertToString(Query.Sum, True)
                            MmebershipPointsAmt = ConvertToString(Query.Sum * CLS_Config.MembershipPoint2Amt, True)
                        Else
                            MmebershipPoints = "00.000"
                            MmebershipPointsAmt = "00.000"
                        End If

                        report.SetParameterValue("MembershipNumber", FixObjectString(CLS_Membership.MembershipNumber))
                        report.SetParameterValue("MembershipName", FixObjectString(CLS_Membership.MemberName))
                        report.SetParameterValue("MembershipPoints", FixObjectString(MmebershipPoints))
                        report.SetParameterValue("MembershipPointsAmt", FixObjectString(MmebershipPointsAmt))


                    End If
                End If



            End Using



            If Print Then
                report.PrintOptions.PrinterName = CLS_Config.ReceiptPrinter
                report.PrintToPrinter(1, False, 1, 2)
                Exit Sub
            Else
                Me.CRV_Receipt.ReportSource = report
            End If

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
            Select Case CType(DT.Rows(0).Item("TransectionTypeCode"), TransectionType)
                Case TransectionType.CashSaleReturn, TransectionType.CreditSaleReturn
                    report2.SetParameterValue("isSaleReturn", True)
                Case Else
                    report2.SetParameterValue("isSaleReturn", False)
            End Select

            Me.CRV_DetailBill.ReportSource = report2


            If CLS_Config.Company = AbdulHussain Or CLS_Config.Company = RASLANI Then
                Me.UltraTabControl1.Tabs(2).Selected = True
            Else
                Me.UltraTabControl1.Tabs(1).Selected = True
            End If

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
        e.Layout.Override.RowSelectorWidth = 35

        ' Enable the the filter row user interface by setting the FilterUIType to FilterRow.
        e.Layout.Override.FilterUIType = FilterUIType.FilterRow

        ' FilterEvaluationTrigger specifies when UltraGrid applies the filter criteria typed 
        ' into a filter row. Default is OnCellValueChange which will cause the UltraGrid to
        ' re-filter the data as soon as the user modifies the value of a filter cell. This
        ' property is exposed off the the column as well so it can be set on a per column basis.
        e.Layout.Override.FilterEvaluationTrigger = FilterEvaluationTrigger.OnEnterKeyOrLeaveCell
        e.Layout.Bands(0).Columns(0).FilterEvaluationTrigger = FilterEvaluationTrigger.OnEnterKeyOrLeaveCell

        ' By default the UltraGrid selects the type of the filter operand editor based on
        ' the column's DataType. For DateTime and boolean columns it uses the column's editors.
        ' For other column types it uses the Combo. You can explicitly specify the operand
        ' editor style by setting the FilterOperandStyle on the override or the individual
        ' columns. This property is exposed on the column as well.
        e.Layout.Override.FilterOperandStyle = FilterOperandStyle.Combo
        'e.Layout.Bands(0).Columns(0).FilterOperandStyle = FilterOperandStyle.DropDownList

        ' By default UltraGrid displays user interface for selecting the filter operator. 
        ' You can set the FilterOperatorLocation to hide this user interface. This
        ' property is available on column as well so it can be controlled on a per column
        ' basis. Default is WithOperand. This property is exposed off the column as well.
        e.Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand
        e.Layout.Bands(0).Columns(0).FilterOperatorLocation = FilterOperatorLocation.Hidden

        ' By default the UltraGrid uses StartsWith as the filter operator. You use
        ' the FilterOperatorDefaultValue property to specify a different filter operator
        ' to use. This is the default or the initial filter operator value of the cells
        ' in filter row. If filter operator user interface is enabled (FilterOperatorLocation
        ' is not set to Hidden) then that ui will be initialized to the value of this
        ' property. The user can then change the operator via the operator ui. This
        ' property is exposed off the column as well.
        e.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains
        e.Layout.Bands(0).Columns(0).FilterOperatorDefaultValue = FilterOperatorDefaultValue.Equals

        ' FilterOperatorDropDownItems property can be used to control the options provided
        ' to the user for selecting the filter operator. By default UltraGrid bases 
        ' what operator options to provide on the column's data type. This property is
        ' avaibale on the column as well. Note that FilterOperatorDropDownItems is a flagged
        ' enum and thus multiple options can be combined using bitwise or operation.
        e.Layout.Override.FilterOperatorDropDownItems = FilterOperatorDropDownItems.All
        e.Layout.Bands(0).Columns(0).FilterOperatorDropDownItems = FilterOperatorDropDownItems.Equals Or FilterOperatorDropDownItems.NotEquals

        ' By default UltraGrid displays a clear button in each cell of the filter row
        ' as well as in the row selector of the filter row. When the user clicks this
        ' button the associated filter criteria is cleared. You can use the 
        ' FilterClearButtonLocation property to control if and where the filter clear
        ' buttons are displayed.
        e.Layout.Override.FilterClearButtonLocation = FilterClearButtonLocation.RowAndCell

        ' By default the UltraGrid performs case in-sensitive comparisons for filtering. You can 
        ' use the FilterComparisonType property to change this behavior and perform case sensitive
        ' comparisons. This property is exposed off the column as well so it can be set on a
        ' per column basis.
        e.Layout.Override.FilterComparisonType = FilterComparisonType.CaseInsensitive
        e.Layout.Bands(0).Columns(0).FilterComparisonType = FilterComparisonType.CaseInsensitive


    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

        Try
            If IsDBNull(Me.grdList.ActiveRow) Or IsNothing(Me.grdList.ActiveRow) Then Exit Sub
            If IsDBNull(Me.grdList.ActiveRow.Cells("SaleCode").Value) Or IsNothing(Me.grdList.ActiveRow.Cells("SaleCode").Value) Then Exit Sub
            If Me.grdList.ActiveRow.Cells("SaleCode").Value = Nothing Then Exit Sub
            LoadReport(CInt(Me.grdList.ActiveRow.Cells("SaleCode").Value), True)

        Catch ex As Exception
            MsgBox("btnPrint_Click" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Export(Me.grdList)

    End Sub
End Class