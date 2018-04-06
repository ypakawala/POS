'Imports ResourceLibrary
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
'Imports Microsoft.Reporting.WinForms

Public Class frmSerialAdd
    Dim CONTEXT As New POSEntities
    Dim SerialCount As Integer
    Public Sub New(_SerialCount As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SerialCount = _SerialCount
    End Sub
    Private Sub frmSerialAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim DT As DataTable
        DT = DBO.ReturnDataTable("SELECT SerailNum FROM Purchase_Entry WHERE Code = -1")
        Me.grdList.DataSource = DT

        For i As Integer = 0 To SerialCount - 1
            Me.grdList.DisplayLayout.Bands(0).AddNew()
        Next


        For Each row In Me.grdList.Rows
            row.Update()
        Next

        Me.grdList.Rows(0).Cells("SerailNum").Activate()
        Me.grdList.PerformAction(UltraGridAction.EnterEditMode, False, False)

        Dim mapping As New GridKeyActionMapping(Keys.Enter, UltraGridAction.NextCellByTab, DirectCast(0, UltraGridState), UltraGridState.InEdit, SpecialKeys.All, DirectCast(0, SpecialKeys))
        Me.grdList.KeyActionMappings.Add(mapping)

        Me.grdList.DisplayLayout.Override.RowAlternateAppearance = RowAlternateAppearance

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
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        frmPurchase_NewIns.Serial_Array.Clear()

        For Each row In Me.grdList.Rows
            row.Update()
        Next

        For Each row In Me.grdList.Rows
            Dim SerailNum As String = TrimStr(row.Cells("SerailNum").Value)
            If SerailNum = Nothing Then
                MsgBox("Serial Number Missing")
                row.Cells("SerailNum").Activate()
                Me.grdList.PerformAction(UltraGridAction.EnterEditMode, False, False)
                Exit Sub
            End If

            For Each row2 In Me.grdList.Rows
                If row.Index <> row2.Index Then
                    If SerailNum = TrimStr(row2.Cells("SerailNum").Value) Then
                        MsgBox("Serial # [" & SerailNum & "] duplicated.")
                        row.Cells("SerailNum").Activate()
                        Me.grdList.PerformAction(UltraGridAction.EnterEditMode, False, False)
                        Exit Sub
                    End If
                End If
            Next


            Dim repeat As Integer = DBO.GetSingleValue("SELECT COALESCE(COUNT(*), 0) FROM Purchase_Entry WHERE SerailNum='" & SerailNum & "'")
            If repeat > 0 Then
                MsgBox("Serial # [" & SerailNum & "] already used before.")
                row.Cells("SerailNum").Activate()
                Me.grdList.PerformAction(UltraGridAction.EnterEditMode, False, False)
                Exit Sub
            End If

            frmPurchase_NewIns.Serial_Array.Add(SerailNum)

        Next

        Me.DialogResult = Windows.Forms.DialogResult.Yes

    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.DialogResult = Windows.Forms.DialogResult.No
    End Sub
End Class