Imports System.Math
Imports CrystalDecisions.CrystalReports.Engine
Imports POS.FixControls
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmItemMovement
    Dim DT As New DataTable
    Private Sub frmItemDrillDownEnquiry_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, MenuStrip1.KeyUp, txtDateFrom.KeyUp, txtDateTo.KeyUp, UltraExpandableGroupBox1.KeyUp, grdList.KeyUp, DropItem.KeyUp
        If e.KeyCode = Keys.End Then Me.Close()
    End Sub
    Private Sub frmItemDrillDownEnquiry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FillDrop(Me.DropItem, "ItemName", "Code", Table.Item, "CostPrice", "BarCode", "BarCode2")
            Me.txtDateFrom.Value = Nothing
            Me.txtDateTo.Value = Nothing
            Me.DropItem.Focus()

        Catch ex As Exception
            MsgBox("frmSailSearch_Load" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        FillGridMovement()
    End Sub
    Private Sub btnClearAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClearAll.Click
        Try
            Me.txtDateFrom.Value = Nothing
            Me.txtDateTo.Value = Nothing
            Me.DropItem.Value = Nothing

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
    Private Sub FillGridMovement()
        Try

            If Not isValid() Then Exit Sub

            Me.grdList.Visible = True

            DT = New DataTable
            DT = DBO.ReturnDataTableFromSQL("SELECT ForeignKey,TransectionDate,TransectionType,TransectionTypeName,Quantity,0.0 as Balance FROM dbo.ItemMovementView " & Where() & "  ORDER BY TransectionDate")


            Dim Balance As Decimal = 0.0

            If TrimDate(Me.txtDateFrom.Value) <> Null_Date Then
                Balance = DBO.GetSingleValue("SELECT SUM(COALESCE(Quantity,0)) FROM dbo.ItemMovementView WHERE ItemCode = " & TrimInt(Me.DropItem.Value) & " AND TransectionDate<'" & TrimDate(Me.txtDateFrom.Value) & "'")
            End If

            For i As Integer = 0 To DT.Rows.Count - 1
                Balance = Balance + TrimDec(DT.Rows(i).Item("Quantity"))
                DT.Rows(i).Item("Balance") = Balance
            Next

            DT.AcceptChanges()

            'For Each row In Me.grdSales.Rows
            '    Balance = Balance + TrimDec(row.Cells("Quantity").Value)
            '    row.Cells("Balance").Value = Balance
            'Next

            Me.grdList.DataSource = DT
            'Me.grdList.DataMember = "Table"
            Me.grdList.DataBind()
            Me.grdList.DisplayLayout.Override.RowAlternateAppearance = RowAlternateAppearance

            Me.grdList.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
            Me.grdList.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False
            Me.grdList.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False


            Me.grdList.DisplayLayout.Bands(0).Columns("TransectionDate").Header.Caption = "Time"
            Me.grdList.DisplayLayout.Bands(0).Columns("TransectionTypeName").Header.Caption = "Transection Type"
            Me.grdList.DisplayLayout.Bands(0).Columns("Quantity").Header.Caption = "Quantity"

            Me.grdList.DisplayLayout.Bands(0).Columns("TransectionType").Hidden = True
            Me.grdList.DisplayLayout.Bands(0).Columns("ForeignKey").Hidden = True

            Me.grdList.DisplayLayout.Bands(0).Columns("TransectionDate").Format = "dd/MMM/yyyy HH:mm"
            Me.grdList.DisplayLayout.Bands(0).Columns("Quantity").MaskInput = Mask_Qty

            Me.grdList.DisplayLayout.Bands(0).Columns("TransectionDate").Width = 150
            Me.grdList.DisplayLayout.Bands(0).Columns("TransectionTypeName").Width = 250
            Me.grdList.DisplayLayout.Bands(0).Columns("Quantity").Width = 100
            Me.grdList.DisplayLayout.Bands(0).Columns("Balance").Width = 100

            Me.UltraTabControl1.Tabs("Sales").Selected = True

        Catch ex As Exception
            MsgBox("FillGrid" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Function isValid() As Boolean
        Try

            If FixControl(Me.DropItem) = Nothing Then
                MSG.ErrorOk("Select Item.")
                Me.DropItem.Focus()
                Return False
            End If


            If FixControl(Me.txtDateTo) <> Null_Date And FixControl(Me.txtDateFrom) <> Null_Date Then
                If CDate(Me.txtDateFrom.Value) > CDate(Me.txtDateTo.Value) Then
                    MSG.ErrorOk("[DATE TO] should be less then [DATE FROM].")
                    Me.txtDateTo.Focus()
                    Me.txtDateTo.SelectAll()
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


            Result = " WHERE ItemCode = " & FixControl(Me.DropItem)

            If FixControl(Me.txtDateFrom) <> Null_Date Then Result &= " AND TransectionDate >= '" & FixControlDateToString(Me.txtDateFrom) & "'"
            If FixControl(Me.txtDateTo) <> Null_Date Then Result &= " AND TransectionDate <= '" & FixControlDateToString(Me.txtDateTo) & "'"


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

    Private Sub grdList_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles grdList.DoubleClickRow
        Try
            If IsDBNull(Me.grdList.ActiveRow) Or IsNothing(Me.grdList.ActiveRow) Then Exit Sub
            Dim ForeignKey As Integer = TrimInt(Me.grdList.ActiveRow.Cells("ForeignKey").Value)
            Dim TransectionTypeCode As TransectionType = TrimInt(Me.grdList.ActiveRow.Cells("TransectionType").Value)
            If ForeignKey = 0 Then Exit Sub
            Select Case TransectionTypeCode
                Case TransectionType.CashSale
                    LoadReportSales(ForeignKey)
                    Me.UltraTabControl1.Tabs("Report").Selected = True
                Case TransectionType.Purchase
                    LoadReportPurchase(ForeignKey)
                    Me.UltraTabControl1.Tabs("Report").Selected = True
                Case 3
            End Select
        Catch ex As Exception
            MsgBox("grdList_DoubleClickRow" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub LoadReportSales(ByVal SaleCode As Integer)
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
            report2.SetParameterValue("DecimalPlace", FixObjectNumber(CLS_Config.DecimalPlace))

            Select Case CType(DT.Rows(0).Item("TransectionTypeCode"), TransectionType)
                Case TransectionType.CashSaleReturn, TransectionType.CreditSaleReturn
                    report2.SetParameterValue("isSaleReturn", True)
                Case Else
                    report2.SetParameterValue("isSaleReturn", False)
            End Select

            Me.CR.ReportSource = report2



        Catch ex As Exception
            MsgBox("LoadReportSales" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub LoadReportPurchase(ByVal PurchaseCode As Integer)
        Try
            Dim DT As New DataTable
            DT = DBO.ReturnDataTable("SELECT * FROM Purchase_Entry_View Where PurchaseCode=" & CInt(PurchaseCode))

            Dim report2 As New ReportDocument
            report2.Load(CLS_Config.ReportPath & "Purchase Detail.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)
            report2.SetDataSource(DT)

            report2.SetParameterValue("AccCashCustomer", FixObjectNumber(CLS_Config.AccCashCustomer))
            report2.SetParameterValue("CompanyName", FixObjectString(CLS_Config.CompanyName))
            report2.SetParameterValue("Address1", FixObjectString(CLS_Config.Address1))
            report2.SetParameterValue("Address2", FixObjectString(CLS_Config.Address2))
            report2.SetParameterValue("Address3", FixObjectString(CLS_Config.Address3))
            report2.SetParameterValue("Tel", FixObjectString(CLS_Config.Tel))
            report2.SetParameterValue("AmountInWords", DollarToString(DT.Rows(0).Item("TotalAmount")))

            Me.CR.ReportSource = report2

        Catch ex As Exception
            MsgBox("LoadReportPurchase" & vbCrLf & ex.Message)
        End Try
    End Sub

End Class