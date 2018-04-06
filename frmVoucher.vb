Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports POS.FixControls

Public Class frmVoucher
    Dim DT As New DataTable
    Private Sub frmVoucher_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MenuStrip1.KeyUp, grdList.KeyUp, Me.KeyUp, DropTransectionType.KeyUp, DropAccount.KeyUp
        Select Case e.KeyCode
            Case Keys.End, Keys.Escape
                Me.Close()
        End Select
    End Sub
    Private Sub frmVoucher_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FillDropWithCondition(Me.DropTransectionType, "Title", "Code", Table.D_TransectionType, , , , , " WHERE Code IN (" & TransectionType.Capital_Investment & "," & TransectionType.Drawing & "," & TransectionType.Other_Revenue & "," & TransectionType.Expenses & ")")
            Me.txtDateFrom.Value = Now.Date
            Me.txtDateTo.Value = New DateTime(Now.Year, Now.Month, Now.Day, 23, 59, 59)
            Me.txtDateFrom.Focus()
            Me.lblAccount.Visible = False
            Me.DropAccount.Visible = False

        Catch ex As Exception
            MsgBox("frmVoucher_Load" & vbCrLf & ex.Message)
        End Try
    End Sub
  
    Private Sub FillGrid()
        Try
            If FixControl(Me.DropTransectionType) = Nothing Then Exit Sub
            If FixControl(Me.txtDateFrom) = Null_Date Then Exit Sub
            If FixControl(Me.txtDateTo) = Null_Date Then Exit Sub
            Dim DateTo As DateTime = FixControl(Me.txtDateTo)

            DT = New DataTable
            Dim PARA As New ArrayList
            PARA.Add(FixControl(Me.DropTransectionType))
            PARA.Add(FixControl(Me.DropAccount))
            PARA.Add(FixControl(Me.txtDateFrom))
            PARA.Add(New DateTime(DateTo.Year, DateTo.Month, DateTo.Day, 23, 59, 59))
            DT = DBO.ExecuteSP_ReturnDataTable("VoucherList", PARA)

            Me.grdList.DataSource = DT
            Me.grdList.DataBind()

            Me.grdList.DisplayLayout.Override.RowAlternateAppearance = RowAlternateAppearance

            Me.grdList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
            Me.grdList.DisplayLayout.Bands(0).Columns("Code").Hidden = True


            Me.grdList.DisplayLayout.Bands(0).Columns("Posted").Width = 50
            Me.grdList.DisplayLayout.Bands(0).Columns("EffectiveDate").MaskInput = "{LOC}dd/mm/yyyy"
            
            Me.grdList.DisplayLayout.Bands(0).Columns("Code").Header.VisiblePosition = 0
            Me.grdList.DisplayLayout.Bands(0).Columns("RefNumber").Header.VisiblePosition = 1
            Me.grdList.DisplayLayout.Bands(0).Columns("EffectiveDate").Header.VisiblePosition = 2
            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").Header.VisiblePosition = 3
            Me.grdList.DisplayLayout.Bands(0).Columns("Amount").Header.VisiblePosition = 4
            Me.grdList.DisplayLayout.Bands(0).Columns("UserName").Header.VisiblePosition = 5
            Me.grdList.DisplayLayout.Bands(0).Columns("Posted").Header.VisiblePosition = 6
            Me.grdList.DisplayLayout.Bands(0).Columns("Account From").Header.VisiblePosition = 7
            Me.grdList.DisplayLayout.Bands(0).Columns("Account To").Header.VisiblePosition = 8


            Me.grdList.DisplayLayout.Bands(0).Columns("Code").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("RefNumber").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("EffectiveDate").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("Account From").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("Account To").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("Amount").Width = 100
            Me.grdList.DisplayLayout.Bands(0).Columns("UserName").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("Posted").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").PerformAutoResize()

            Me.grdList.DisplayLayout.Bands(0).Columns("Amount").MaskInput = Mask_Amount
        Catch ex As Exception
            MsgBox("FillGrid" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Try
            If IsDBNull(Me.DropTransectionType.Value) Or IsNothing(Me.DropTransectionType.Value) Then
                MsgBox("Select Transection Type")
                Me.DropTransectionType.Focus()
                Exit Sub
            End If
            If Me.DropTransectionType.Value = Nothing Then
                MsgBox("Select Transection Type")
                Me.DropTransectionType.Focus()
                Exit Sub
            End If
            Dim FRM As New frmVoucher_Entry(CInt(Me.DropTransectionType.SelectedRow.Cells("Code").Value))
            FRM.ShowDialog()
            FillGrid()

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

            If FixCellBoolean(Me.grdList.ActiveRow.Cells("Posted")) = True Then
                MsgBox("Purchase has been posted.Can not be edited.")
                Exit Sub
            End If

            Dim FRM As New frmVoucher_Entry(CInt(Me.DropTransectionType.SelectedRow.Cells("Code").Value), CInt(Me.grdList.ActiveRow.Cells("Code").Value))
            FRM.ShowDialog()
            FillGrid()

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
            If FixCellBoolean(Me.grdList.ActiveRow.Cells("Posted")) = True Then
                If MsgBox("Purchase has been posted. Are you sure you want to delete the entry.", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub
            End If

            If MsgBox("Are you sure you want to delete the purchase entry?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub

            Dim CLS As New Voucher
            CLS.Code = FixObjectNumber(Me.grdList.ActiveRow.Cells("Code").Value)
            CLS.Delete()

            FillGrid()

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
            e.DefaultLogicalPageLayoutInfo.PageHeader = "Voucher List for " & Me.DropTransectionType.Text
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
            e.DefaultLogicalPageLayoutInfo.PageHeader = "Voucher List for " & Me.DropTransectionType.Text
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        FillGrid()
    End Sub

    Private Sub DropTransectionType_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropTransectionType.ValueChanged
        Try
            Me.lblAccount.Visible = True
            Me.DropAccount.Visible = True
            Select Case CType(FixControl(Me.DropTransectionType), TransectionType)
                Case TransectionType.Capital_Investment
                    FillDropWithCondition(Me.DropAccount, "Title", "Code", Table.Account, "AccountNum", , , , " WHERE AccountType = " & AccountType.Owner)
                    Me.lblAccount.Text = "Owners Acc:"
                Case TransectionType.Drawing
                    FillDropWithCondition(Me.DropAccount, "Title", "Code", Table.Account, "AccountNum", , , , " WHERE AccountType = " & AccountType.Owner)
                    Me.lblAccount.Text = "Owners Acc:"
                Case TransectionType.Expenses
                    FillDropWithCondition(Me.DropAccount, "Title", "Code", Table.Account, "AccountNum", , , , " WHERE AccountType = " & AccountType.Expenses)
                    Me.lblAccount.Text = "Expenses Acc:"
                Case TransectionType.Other_Revenue
                    FillDropWithCondition(Me.DropAccount, "Title", "Code", Table.Account, "AccountNum", , , , " WHERE AccountType = " & AccountType.Other_Revenue)
                    Me.lblAccount.Text = "Other Revenue Acc:"
                Case Else
                    Me.DropAccount.DataSource = Nothing
                    Me.lblAccount.Visible = False
                    Me.DropAccount.Visible = False
            End Select

           
        Catch ex As Exception
            MsgBox("frmPurchase_New_Load" & vbCrLf & ex.Message)
        End Try
    End Sub
End Class