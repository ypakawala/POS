Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports POS.FixControls

Public Class frmSalaryPaymentList
    Dim DS As New DataSet

    Private Sub frmSalaryPaymentList_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmSalaryPaymentListIns = Nothing
    End Sub
    Private Sub frmSalaryPaymentList_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MenuStrip1.KeyUp, grdList.KeyUp, Me.KeyUp, DropEmployee.KeyUp
        Select Case e.KeyCode
            Case Keys.End, Keys.Escape
                Me.Close()
        End Select
    End Sub
    Private Sub frmSalaryPaymentList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.txtBalance.InputMask = Mask_Amount5Nagative

            FillDropWithCondition(Me.DropEmployee, "Title", "AccountNum", Table.Account, "Code", "AccountType", , , " WHERE AccountType = " & AccountType.Employee)

        Catch ex As Exception
            MsgBox("frmVoucher_Load" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub DropEmployee_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropEmployee.ValueChanged
        Try
            If IsDBNull(Me.DropEmployee.Value) Or IsNothing(Me.DropEmployee.Value) Then Exit Sub
            If Me.DropEmployee.Value = Nothing Then Exit Sub

            FillGrid(Me.DropEmployee.SelectedRow.Cells("Code").Value)

        Catch ex As Exception
            MsgBox("DropEmployee_ValueChanged" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub FillGrid(ByVal Employee As Integer)
        Try
            DS = New DataSet
            Dim PARA As New ArrayList
            PARA.Add(Employee)
            DS = DBO.ExecuteSP_ReturnDataSet("SalaryPaymentList", PARA)

            Me.grdList.DataSource = DS.Tables(0)
            Me.grdList.DataBind()
            Me.grdList.DisplayLayout.Override.RowAlternateAppearance = RowAlternateAppearance

            Me.grdList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
            Me.grdList.DisplayLayout.Bands(0).Columns("Code").Hidden = True


            Me.grdList.DisplayLayout.Bands(0).Columns("EffectiveDate").MaskInput = "{LOC}dd/mm/yyyy"
            Me.grdList.DisplayLayout.Bands(0).Columns("Amount").MaskInput = Mask_Amount5

            Me.txtBalance.Value = CDec(DS.Tables(1).Rows(0).Item("Balance"))


        Catch ex As Exception
            MsgBox("FillGrid" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Try
            If IsDBNull(Me.DropEmployee.Value) Or IsNothing(Me.DropEmployee.Value) Then
                MsgBox("Select Employee")
                Me.DropEmployee.Focus()
                Exit Sub
            End If
            If Me.DropEmployee.Value = Nothing Then
                MsgBox("Select Employee")
                Me.DropEmployee.Focus()
                Exit Sub
            End If
            Dim FRM As New frmSalaryPayment(CInt(Me.DropEmployee.SelectedRow.Cells("Code").Value), FixControl(Me.txtBalance))
            FRM.ShowDialog()
            FillGrid(Me.DropEmployee.SelectedRow.Cells("Code").Value)

        Catch ex As Exception
            MsgBox("btnNew_Click" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Try
            If IsDBNull(Me.grdList.ActiveRow.Cells("Code").Value) Or IsNothing(Me.grdList.ActiveRow.Cells("Code").Value) Then
                MsgBox("Select Record first")
                Exit Sub
            ElseIf Me.grdList.ActiveRow.Cells("Code").Value = Nothing Then
                MsgBox("Select Record first")
                Exit Sub
            End If

           
            Dim FRM As New frmSalaryPayment(CInt(Me.DropEmployee.SelectedRow.Cells("Code").Value), FixControl(Me.txtBalance), CInt(Me.grdList.ActiveRow.Cells("Code").Value))
            FRM.ShowDialog()
            FillGrid(Me.DropEmployee.SelectedRow.Cells("Code").Value)

        Catch ex As Exception
            MsgBox("btnEdit_Click" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If FixCellNumber(Me.grdList.ActiveRow.Cells("Code")) = Nothing Then
                MsgBox("Select Record first")
                Exit Sub
            End If

            If MsgBox("Are you sure you want to delete the purchase entry?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub

            Dim CLS As New Voucher
            CLS.Code = FixObjectNumber(Me.grdList.ActiveRow.Cells("Code").Value)
            CLS.Delete()

            FillGrid(Me.DropEmployee.SelectedRow.Cells("Code").Value)

        Catch ex As Exception
            MsgBox("btnDelete_Click" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Me.grdList.PrintPreview()
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub grdList_InitializePrintPreview(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelablePrintPreviewEventArgs) Handles grdList.InitializePrintPreview
        Try
            ' Set the zomm level to 100 % in the print preview.
            e.PrintPreviewSettings.Zoom = 1.0

            ' Set the location and size of the print preview dialog.
            e.PrintPreviewSettings.DialogLeft = SystemInformation.WorkingArea.X
            e.PrintPreviewSettings.DialogTop = SystemInformation.WorkingArea.Y
            e.PrintPreviewSettings.DialogWidth = SystemInformation.WorkingArea.Width
            e.PrintPreviewSettings.DialogHeight = SystemInformation.WorkingArea.Height

            ' Horizontally fit everything in a signle page.
            e.DefaultLogicalPageLayoutInfo.FitWidthToPages = 1
            e.PrintDocument.DefaultPageSettings.Landscape = True

            ' Set up the header and the footer.
            e.DefaultLogicalPageLayoutInfo.PageHeader = "Salary Payment for " & Me.DropEmployee.Text
            e.DefaultLogicalPageLayoutInfo.PageHeaderHeight = 40
            e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.FontData.SizeInPoints = 14
            e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.TextHAlign = HAlign.Center
            e.DefaultLogicalPageLayoutInfo.PageHeaderBorderStyle = UIElementBorderStyle.Solid

            ' Use <#> token in the string to designate page numbers.
            e.DefaultLogicalPageLayoutInfo.PageFooter = "Page <#>."
            e.DefaultLogicalPageLayoutInfo.PageFooterHeight = 40
            e.DefaultLogicalPageLayoutInfo.PageFooterAppearance.TextHAlign = HAlign.Right
            e.DefaultLogicalPageLayoutInfo.PageFooterAppearance.FontData.Italic = DefaultableBoolean.True
            e.DefaultLogicalPageLayoutInfo.PageFooterBorderStyle = UIElementBorderStyle.Solid

            ' Set the ClippingOverride to Yes.
            e.DefaultLogicalPageLayoutInfo.ClippingOverride = ClippingOverride.Yes

            ' Set the document name through the PrintDocument which returns a PrintDocument object.
            e.DefaultLogicalPageLayoutInfo.PageHeader = e.DefaultLogicalPageLayoutInfo.PageHeader
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class