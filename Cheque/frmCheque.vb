Imports System.Data.Odbc
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports Infragistics.Win.UltraWinGrid
Imports System.ComponentModel
Imports POS.FixControls


Public Class frmCheque
    Implements IDataEntry
#Region "Member Variables"

    Private m_tableName As String = DBTable.Cheque
    Private DT As New DataTable
    Private DTOriginal As New DataTable
    Private m_modi As Boolean = False
    'Protected m_canOpen As Boolean = False


#End Region
#Region "Properties"

    Public Property tblName() As String Implements IDataEntry.tblName
        Get
            Return m_tableName
        End Get
        Set(ByVal value As String)
            m_tableName = value
        End Set
    End Property

    Public Property TableName() As String
        Get
            Return m_tableName
        End Get
        Set(ByVal value As String)
            m_tableName = value
        End Set
    End Property

    Public Property Modi() As Boolean Implements IDataEntry.Modi
        Get
            Return m_modi
        End Get
        Set(ByVal value As Boolean)
            m_modi = value
        End Set
    End Property

#End Region
#Region "Methods"
    Private Sub SUM()
        Try

            Dim Total As Decimal = 0.0
            For i As Integer = 0 To Me.grdList.Rows.VisibleRowCount - 1
                Total += FixCellNumber(Me.grdList.Rows.GetRowAtVisibleIndex(i).Cells("Amount"))
                Me.grdList.Rows.GetRowAtVisibleIndex(i).Cells("Total").Value = Total
            Next

        Catch ex As Exception
            'MSG.ErrorOk("[SUM]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub FillGrid(ByVal tDate As Date, ByVal Cleared As Boolean)
        Try
            DT.Clear()
            Dim SQL As String = Nothing
            If FixObjectDate(tDate) = Null_Date And Cleared = False Then
                SQL = "SELECT * FROM ChequeView WHERE (Cleared=0 or Cleared is NULL) ORDER BY tDate,SupplierCode"
            ElseIf FixObjectDate(tDate) = Null_Date And Cleared = True Then
                SQL = "SELECT * FROM ChequeView  ORDER BY tDate,SupplierCode"
            ElseIf FixObjectDate(tDate) <> Null_Date And Cleared = False Then
                SQL = "SELECT * FROM ChequeView WHERE (tDate >= '" & tDate & "') AND (Cleared=0 or Cleared is NULL) ORDER BY tDate,SupplierCode"
            ElseIf FixObjectDate(tDate) <> Null_Date And Cleared = True Then
                SQL = "SELECT * FROM ChequeView  WHERE (tDate >= '" & tDate & "')  ORDER BY tDate,SupplierCode"
            End If
            DT = DBO.ReturnDataTable(SQL)
            DTOriginal = DBO.ReturnDataTable(SQL)

            Me.grdList.DataSource = DT
            Me.grdList.DataBind()

            SUM()
            SetGridLayout()

        Catch ex As Exception
            MSG.ErrorOk("[FillGrid]" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub SetGridLayout()
        Try

            Me.grdList.DisplayLayout.Override.RowAlternateAppearance = RowAlternateAppearance
            Me.grdList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
            Me.grdList.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
            Me.grdList.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
            Me.grdList.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False

            Me.grdList.DisplayLayout.Bands(0).Columns("SupplierCode").Hidden = True

            Me.grdList.DisplayLayout.Bands(0).Columns("tDate").MaskInput = Mask_Date

            For i As Integer = 0 To Me.grdList.DisplayLayout.Bands(0).Columns.Count - 1
                Me.grdList.DisplayLayout.Bands(0).Columns(i).PerformAutoResize()
            Next

        Catch ex As Exception
            MSG.ErrorOk("[SetGridLayout]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Function Edit() As Boolean Implements IDataEntry.Edit
        If IsDBNull(Me.grdList.ActiveRow) Or IsNothing(Me.grdList.ActiveRow) Then Exit Function
        If FixObjectNumber(Me.grdList.ActiveRow.Cells("Code").Value) = Nothing Then Exit Function

        Dim FRM As New frmChequeNew(FixObjectNumber(Me.grdList.ActiveRow.Cells("Code").Value))
        FRM.ShowDialog()
        Me.txtFromDate.Value = Now.Date
        FillGrid(FixControl(Me.txtFromDate), FixObjectBoolean(Me.chkCleared.Checked))

    End Function
    Private Sub Print()
        Try
            Me.grdList.PrintPreview()
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Sub

#End Region
#Region "Events"

    Private Sub frmDynamicList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.grdList.DisplayLayout.Override.RowAlternateAppearance = RowAlternateAppearance
            Me.txtFromDate.Value = Nothing
            Me.chkCleared.Checked = False
            FillGrid(FixControl(Me.txtFromDate), FixObjectBoolean(Me.chkCleared.Checked))

            Dim mapping As New GridKeyActionMapping(Keys.Enter, UltraGridAction.NextCellByTab, DirectCast(0, UltraGridState), UltraGridState.InEdit, SpecialKeys.All, DirectCast(0, SpecialKeys))
            Me.grdList.KeyActionMappings.Add(mapping)

        Catch ex As Exception
            MSG.ErrorOk("[frmDynamicList_Load]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub frmCheque_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            frmChequeIns = Nothing
        Catch ex As Exception
            MSG.ErrorOk("[frmDynamicList_FormClosed]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Print()
    End Sub
    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Dim FRM As New frmChequeNew
        FRM.ShowDialog()
        Me.txtFromDate.Value = Now.Date
        FillGrid(FixControl(Me.txtFromDate), FixObjectBoolean(Me.chkCleared.Checked))
    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If FixControl(Me.txtFromDate) = Null_Date Then Exit Sub
        FillGrid(FixControl(Me.txtFromDate), FixObjectBoolean(Me.chkCleared.Checked))
    End Sub
    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Edit()
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If IsDBNull(Me.grdList.ActiveRow) Or IsNothing(Me.grdList.ActiveRow) Then Exit Sub
        If FixObjectNumber(Me.grdList.ActiveRow.Cells("Code").Value) = Nothing Then Exit Sub

        If MsgBox("Are you sure you want to delete record # " & FixObjectNumber(Me.grdList.ActiveRow.Cells("Code").Value), MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub

        Dim PARA As New ArrayList
        PARA.Add(FixObjectNumber(Me.grdList.ActiveRow.Cells("Code").Value))
        DBO.ExecuteSP("ChequeDelete", PARA)

        FillGrid(FixControl(Me.txtFromDate), FixObjectBoolean(Me.chkCleared.Checked))

    End Sub

    Private Sub txtFromDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFromDate.ValueChanged
        FillGrid(FixControl(Me.txtFromDate), FixObjectBoolean(Me.chkCleared.Checked))
    End Sub
    Private Sub frmCheque_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, grdList.KeyUp
        If e.KeyCode = Keys.End Then btnExit_Click(sender, e)
    End Sub

    Private Sub grdList_AfterRowFilterChanged(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.AfterRowFilterChangedEventArgs) Handles grdList.AfterRowFilterChanged
        SUM()
    End Sub
    Private Sub grdList_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles grdList.DoubleClickRow
        Edit()
    End Sub
    Private Sub grdList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdList.KeyDown
        Try

        Catch ex As Exception
            MSG.ErrorOk("[Save]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub grdList_AfterRowInsert(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles grdList.AfterRowInsert
        Try

        Catch ex As Exception
            MSG.ErrorOk("[grdList_AfterRowInsert]" & vbCrLf & ex.Message)
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

    End Sub


#End Region
#Region "Not Used"

    Public Function Add1() As Boolean Implements IDataEntry.Add

    End Function

    Public Function Adding() As Boolean Implements IDataEntry.Adding

    End Function

    Public Function CanSave() As Boolean Implements IDataEntry.CanSave

    End Function

    Public Sub Clear() Implements IDataEntry.Clear

    End Sub

    Public Sub ComboNavi() Implements IDataEntry.ComboNavi

    End Sub

    Public Sub Counter() Implements IDataEntry.Counter

    End Sub

    Public Sub DataLen() Implements IDataEntry.DataLen

    End Sub

    Public Function Delete1() As Boolean Implements IDataEntry.Delete

    End Function

    Public Function Deleting() As Boolean Implements IDataEntry.Deleting

    End Function


    Public Function Editing() As Boolean Implements IDataEntry.Editing

    End Function

    Public Sub FillDrops() Implements IDataEntry.FillDrops

    End Sub

    Public Sub FillGrid1() Implements IDataEntry.FillGrid

    End Sub

    Public Sub GridNavi() Implements IDataEntry.GridNavi

    End Sub

    Public Sub LoadCodes() Implements IDataEntry.LoadCodes

    End Sub

    Public Sub LoadData(ByVal code As Integer) Implements IDataEntry.LoadData

    End Sub

    Public Sub Loading() Implements IDataEntry.Loading

    End Sub

    Public Sub LoadNew() Implements IDataEntry.LoadNew

    End Sub

    Public Sub Mask() Implements IDataEntry.Mask

    End Sub


    Public Sub NaviBack() Implements IDataEntry.NaviBack

    End Sub

    Public Sub NaviNext() Implements IDataEntry.NaviNext

    End Sub

    Public Sub [New]() Implements IDataEntry.New

    End Sub


    Public Sub ReadOnlyField() Implements IDataEntry.ReadOnlyField

    End Sub

    Public Function Saving() As Boolean Implements IDataEntry.Saving

    End Function

    Public Function SetCode() As Boolean Implements IDataEntry.SetCode

    End Function

    Public Function SetDefault() As Boolean Implements IDataEntry.SetDefault

    End Function



#End Region

    Private Sub chkCleared_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCleared.CheckedChanged
        FillGrid(FixControl(Me.txtFromDate), FixObjectBoolean(Me.chkCleared.Checked))
    End Sub
End Class