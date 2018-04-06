'Imports ResourceLibrary
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
'Imports Microsoft.Reporting.WinForms

Public Class frmSerialList
    Dim CONTEXT As New POSEntities
    Dim ItemCode As Integer
    Dim SalesReturn As Boolean = False
    Public Sub New(_ItemCode As Integer, ByVal _SalesReturn As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ItemCode = _ItemCode
        SalesReturn = _SalesReturn

    End Sub
    Private Sub frmSerialList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillGrid()
    End Sub

    Private Sub FillGrid()

        'Dim SaleList As IEnumerable(Of Integer?)
        'SaleList = (From q In CONTEXT.Sales_Full_View
        '            Where q.ItemCode = ItemCode _
        '            AndAlso (q.TransectionTypeCode = 1 Or q.TransectionTypeCode = 2) _
        '            Select q.Purchase_EntryCode).ToList


        Dim SaleList As IEnumerable(Of Integer?)
        SaleList = (From SE In CONTEXT.Sale_Entry_Set
                    From S In CONTEXT.Sale_Set
                    Where SE.SaleCode = S.Code _
                    AndAlso SE.ItemCode = ItemCode _
                    AndAlso (S.TransectionType = 1 Or S.TransectionType = 2) _
                    Select SE.Purchase_EntryCode).ToList


        If SalesReturn Then
            Me.grdList.DataSource = From q In CONTEXT.Purchase_Entry_Set _
                        Where Not String.IsNullOrEmpty(q.SerailNum) _
                        AndAlso q.ItemCode = ItemCode _
                        AndAlso SaleList.Contains(q.Code) _
                        AndAlso q.QtyStock = 0 _
                        AndAlso q.Purchase.Posted = True
                        Select q
        Else
            Me.grdList.DataSource = From q In CONTEXT.Purchase_Entry_Set _
                        Where Not String.IsNullOrEmpty(q.SerailNum) _
                        AndAlso q.ItemCode = ItemCode _
                        AndAlso q.QtyStock > 0 _
                        AndAlso q.Purchase.Posted = True
                        Select q
        End If

        Dim i As Integer = 0
        For i = 0 To Me.grdList.Rows.Count - 1

            Dim j As Integer = 0
            For j = 0 To frmSalesIns.grdList.Rows.Count - 1

                If TrimInt(frmSalesIns.grdList.Rows(j).Cells("Purchase_EntryCode").Value) = TrimInt(Me.grdList.Rows(i).Cells("Code").Value) Then
                    Me.grdList.Rows(i).Hidden = True
                    Exit For
                    End If

            Next
        Next

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
        Me.grdList.DisplayLayout.Bands(0).Columns("Code").Hidden = True
        Me.grdList.DisplayLayout.Bands(0).Columns("PurchaseCode").Hidden = True
        Me.grdList.DisplayLayout.Bands(0).Columns("ItemCode").Hidden = True
        Me.grdList.DisplayLayout.Bands(0).Columns("Qty").Hidden = True
        Me.grdList.DisplayLayout.Bands(0).Columns("QtyStock").Hidden = True
        Me.grdList.DisplayLayout.Bands(0).Columns("QtyReturned").Hidden = True
        Me.grdList.DisplayLayout.Bands(0).Columns("UnitPrice").Hidden = True
        Me.grdList.DisplayLayout.Bands(0).Columns("Price").Hidden = True
        Me.grdList.DisplayLayout.Bands(0).Columns("ExpiryDate").Hidden = True
        Me.grdList.DisplayLayout.Bands(0).Columns("UMC").Hidden = True
        Me.grdList.DisplayLayout.Bands(0).Columns("SalesPrice").Hidden = True
        Me.grdList.DisplayLayout.Bands(0).Columns("AvgPrice").Hidden = True
        Me.grdList.DisplayLayout.Bands(0).Columns("SerailNum").Hidden = False
        Me.grdList.DisplayLayout.Bands(0).Columns("Purchase").Hidden = True
        Me.grdList.DisplayLayout.Bands(0).Columns("Sale_Entry").Hidden = True
        Me.grdList.DisplayLayout.Bands(0).Columns("Item").Hidden = True

        Try
            Me.grdList.Rows.GetRowAtVisibleIndex(1).Activated = True
            Me.grdList.Rows.GetRowAtVisibleIndex(1).Selected = True
        Catch ex As Exception
            End Try

    End Sub

    Private Sub grdList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdList.KeyDown
        If e.KeyCode = Keys.Enter Then ReturnRecord()
    End Sub
    Private Sub grdList_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdList.DoubleClickCell
        ReturnRecord()
    End Sub
    Private Sub ReturnRecord()
        If IsDBNull(Me.grdList.ActiveRow) Or IsNothing(Me.grdList.ActiveRow) Then Exit Sub
        If IsDBNull(Me.grdList.ActiveRow.Cells("Code").Value) Or IsNothing(Me.grdList.ActiveRow.Cells("Code").Value) Then Exit Sub
        If Me.grdList.Rows.VisibleRowCount = 1 Then Exit Sub
        Find_Int = TrimInt(Me.grdList.ActiveRow.Cells("Code").Value)
        Me.DialogResult = Windows.Forms.DialogResult.Yes
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
            e.DefaultLogicalPageLayoutInfo.PageHeader = "Serial List"
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

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Find_Int = -1
        Me.DialogResult = Windows.Forms.DialogResult.Yes
        Me.Close()
    End Sub

End Class