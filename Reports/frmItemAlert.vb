Imports System.Math
Imports CrystalDecisions.CrystalReports.Engine
Imports POS.FixControls
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class frmItemAlert
    Dim DT As New DataTable
    Private Sub frmItemAlert_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, grdList.KeyUp
        If e.KeyCode = Keys.End Then
            Me.Close()
        End If
    End Sub
    Private Sub frmItemAlert_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FillGrid()
            Me.txtSearch.Focus()
            Me.txtSearch.SelectAll()

        Catch ex As Exception
            MsgBox("frmItemAlert_Load" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub FillGrid()
        Try

            DT = New DataTable
            DT = DBO.ReturnDataTableFromSQL("SELECT * FROM Item_Alert")

            Me.grdList.DataSource = DT
            Me.grdList.DataBind()


            Me.grdList.DisplayLayout.Override.RowAlternateAppearance = RowAlternateAppearance
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemName").Width = 250
            Me.grdList.DisplayLayout.Bands(0).Columns("Category").Width = 150
            Me.grdList.DisplayLayout.Bands(0).Columns("SubCategory").Width = 100
            'Me.grdList.DisplayLayout.Bands(0).Columns("CostPrice").MaskInput = Mask_Amount
            

        Catch ex As Exception
            MsgBox("FillGrid" & vbCrLf & ex.Message)
        End Try
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
            e.DefaultLogicalPageLayoutInfo.PageHeader = Me.Text & " List"
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
            e.DefaultLogicalPageLayoutInfo.PageHeader = Me.Text & " List"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        Me.grdList.PrintPreview()
    End Sub

#Region " SIMPLE SEARCH "

    Dim srch As Boolean = False


    Private Sub txtSearch_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.ValueChanged
        Try
            Me.grdList.DisplayLayout.Bands(0).ColumnFilters.ClearAllFilters()

            If Me.txtSearch.Value <> Nothing Then
                srch = True
                Me.grdList.DisplayLayout.Bands(0).ColumnFilters("StockMin").FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Contains, txtSearch.Value)
            Else
                srch = False
            End If

        Catch ex As Exception
            MsgBox("Error in [txtSearch_TextChanged] " & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical, My.Application.Info.ProductName)
        End Try
    End Sub
    Private Sub grdList_FilterRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.FilterRowEventArgs) Handles grdList.FilterRow
        Try
            If srch = True Then
                Dim band As UltraGridBand = e.Row.Band

                Dim FC As New FilterCondition
                Dim FCList As New List(Of FilterCondition)

                Dim COL As UltraGridColumn
                For Each COL In Me.grdList.DisplayLayout.Bands(0).Columns
                    If COL.Hidden = False Then
                        FC = New FilterCondition(band.Columns(COL.Key), FilterComparisionOperator.Like, "*" & Me.txtSearch.Value & "*")
                        FCList.Add(FC)
                    End If
                Next


                Dim rowPasses As Boolean = e.Row.MeetsCriteria(FCList.ToArray(), FilterLogicalOperator.Or)

                If Not rowPasses Then
                    e.RowFilteredOut = True
                Else
                    e.RowFilteredOut = False
                End If



            End If

        Catch ex As Exception
            MsgBox("Error in [grdList_FilterRow] " & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical, My.Application.Info.ProductName)
        End Try
    End Sub


#End Region
End Class