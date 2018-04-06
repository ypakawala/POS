'Imports ResourceLibrary
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
'Imports Microsoft.Reporting.WinForms

Public Class frmQuotationList

    Dim CONTEXT As New POSEntities

    Private Sub frmQuotationList_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        frmQuotationListIns = Nothing
    End Sub

    Private Sub frmSales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnAllQuote.Checked = True
        FillGrid(False)
    End Sub
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Dim frm As New frmQuotation(0)
        frm.ShowDialog()
        btnAllQuote.Checked = True
        FillGrid(False)
    End Sub
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If IsDBNull(Me.grdList.ActiveRow) OrElse IsNothing(Me.grdList.ActiveRow) Then
            MsgBox("Invalid selection")
            Exit Sub
        End If
        If TrimInt(Me.grdList.ActiveRow.Cells("Code").Value) = 0 Then
            MsgBox("Invalid selection")
            Exit Sub
        End If
        Dim frm As New frmQuotation(TrimInt(Me.grdList.ActiveRow.Cells("Code").Value))
        frm.ShowDialog()
        btnAllQuote.Checked = True
        FillGrid(False)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Me.grdList.PrintPreview()
    End Sub
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Export(Me.grdList)
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub FillGrid(ByVal Quote_Type As QuoteType)

        Using CONTEXT = New POSEntities
            Select Case Quote_Type
                Case QuoteType.Close : Me.grdList.DataSource = From q In CONTEXT.Quotation_View Where q.isClosed = True Select q
                Case QuoteType.Open : Me.grdList.DataSource = From q In CONTEXT.Quotation_View Where q.isClosed = False OrElse q.isClosed Is Nothing Select q
                Case Else : Me.grdList.DataSource = From q In CONTEXT.Quotation_View Select q
            End Select
        End Using
        Me.grdList.DisplayLayout.Override.RowAlternateAppearance = RowAlternateAppearance
        Me.grdList.DisplayLayout.AutoFitStyle = AutoFitStyle.None
        Me.grdList.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        Me.grdList.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
        Me.grdList.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False
        Me.grdList.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        Me.grdList.DisplayLayout.Bands(0).Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains
        Me.grdList.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        Me.grdList.DisplayLayout.Bands(0).PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand)
        Me.grdList.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle
        '''''''''''''''''''''HIDDEN'''''''''''''''''''''
        Me.grdList.DisplayLayout.Bands(0).Columns("CustomerCode").Hidden = True
        Me.grdList.DisplayLayout.Bands(0).Columns("UserCode").Hidden = True
        Me.grdList.DisplayLayout.Bands(0).Columns("CounterCode").Hidden = True
        '''''''''''''''''''''MASK INPUT'''''''''''''''''''''
        Me.grdList.DisplayLayout.Bands(0).Columns("TransectionDate").MaskInput = Mask_Date
        Me.grdList.DisplayLayout.Bands(0).Columns("TransectionDate").Format = "dd/MM/yyyy"
        Me.grdList.DisplayLayout.Bands(0).Columns("TotalBill").MaskInput = Mask_Amount
        Me.grdList.DisplayLayout.Bands(0).Columns("Discount").MaskInput = Mask_Amount
        Me.grdList.DisplayLayout.Bands(0).Columns("NetBill").MaskInput = Mask_Amount

        '''''''''''''''''''''Perform Auto Resize'''''''''''''''''''''
        Me.grdList.DisplayLayout.Bands(0).Columns("Code").PerformAutoResize()
        Me.grdList.DisplayLayout.Bands(0).Columns("CustomerCode").PerformAutoResize()
        Me.grdList.DisplayLayout.Bands(0).Columns("CustomerName").PerformAutoResize()
        Me.grdList.DisplayLayout.Bands(0).Columns("TransectionDate").PerformAutoResize()
        Me.grdList.DisplayLayout.Bands(0).Columns("UserCode").PerformAutoResize()
        Me.grdList.DisplayLayout.Bands(0).Columns("UserName").PerformAutoResize()
        Me.grdList.DisplayLayout.Bands(0).Columns("CounterCode").PerformAutoResize()
        Me.grdList.DisplayLayout.Bands(0).Columns("CounterName").PerformAutoResize()
        Me.grdList.DisplayLayout.Bands(0).Columns("TotalBill").PerformAutoResize()
        Me.grdList.DisplayLayout.Bands(0).Columns("Discount").PerformAutoResize()
        Me.grdList.DisplayLayout.Bands(0).Columns("NetBill").PerformAutoResize()
        Me.grdList.DisplayLayout.Bands(0).Columns("Remark").PerformAutoResize()
        Me.grdList.DisplayLayout.Bands(0).Columns("isClosed").PerformAutoResize()


    End Sub
    Private Sub grdList_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdList.DoubleClickCell
        Me.btnEdit_Click(sender, e)
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
            e.DefaultLogicalPageLayoutInfo.PageHeader = "Quotation List"
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
    Private Sub grdList_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdList.InitializeLayout
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
        e.Layout.Bands(0).Columns(0).FilterOperandStyle = FilterOperandStyle.DropDownList

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



        ' Set the RowSelectorNumberStyle to enable the row-numbers.
        e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex

        ' You can control the appearance of the row numbers using the RowSelectorAppearance.
        e.Layout.Override.RowSelectorAppearance.ForeColor = Color.Black
        e.Layout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.False

        ' You can explicitly set the width of the row selectors if the default one calculated
        ' by the UltraGrid is not enough.
        e.Layout.Override.RowSelectorWidth = 40
        Me.grdList.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True


    End Sub

    Private Sub btnQuotationReport_Click(sender As Object, e As EventArgs)
        'Dim FRM As New frmPurchaseReport
        'FRM.ShowDialog()
    End Sub
    Public Enum QuoteType
        Close = 1
        Open = 2
        All = 3
    End Enum

    Private Sub btnClosedQuote_Click(sender As Object, e As EventArgs) Handles btnClosedQuote.Click
        FillGrid(QuoteType.Close)
    End Sub

    Private Sub btnOpenQuote_Click(sender As Object, e As EventArgs) Handles btnOpenQuote.Click
        FillGrid(QuoteType.Open)
    End Sub
    Private Sub btnShowClosedQuote_Click(sender As Object, e As EventArgs) Handles btnAllQuote.Click
        FillGrid(QuoteType.All)
    End Sub

End Class