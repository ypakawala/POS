Imports Infragistics.Win.UltraWinGrid
Imports POS.FixControls
Public Class frmGenerateSalary
    Dim DT As New DataTable
    Private Sub frmGenerateSalary_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmGenerateSalaryIns = Nothing
    End Sub
    Private Sub frmGenerateSalary_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, MenuStrip1.KeyUp, DropMonth.KeyUp, DropYear.KeyUp
        Select Case e.KeyCode
            Case Keys.End, Keys.Escape
                Me.Close()
        End Select
    End Sub
    Private Sub frmGenerateSalary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.Cart_Blue
        Try
            Me.Width = Screen.PrimaryScreen.WorkingArea.Width
            Me.Left = 0
            Me.Text = "Generate Salary"

            FillDrop(Me.DropYear, "Title", "Code", Table.D_Year)
            FillDrop(Me.DropMonth, "Title", "Code", Table.D_Month)
            Me.DropMonth.DisplayLayout.Bands(0).Columns("Code").SortIndicator = SortIndicator.Ascending

            Me.DropMonth.Focus()

            btnCancel_Click(sender, e)

        Catch ex As Exception
            MsgBox("frmSubscription_Load" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If Not isValid() Then Exit Sub

            Dim i As Integer = 0
            For i = 0 To Me.grdList.Rows.Count - 1
                If FixObjectBoolean(Me.grdList.Rows(i).Cells("Select").Value) = True Then

                    Dim CLS As New Salary
                    CLS.Code = FixObjectNumber(Me.grdList.Rows(i).Cells("Code").Value)
                    CLS.EmployeeCode = FixObjectNumber(Me.grdList.Rows(i).Cells("EmployeeCode").Value)
                    CLS.SalaryAmount = FixObjectNumber(Me.grdList.Rows(i).Cells("SalaryAmount").Value)
                    CLS.SalaryMonth = FixObjectNumber(Me.grdList.Rows(i).Cells("SalaryMonth").Value)
                    CLS.SalaryYear = FixObjectNumber(Me.grdList.Rows(i).Cells("SalaryYear").Value)
                    CLS.VoucherCode = FixObjectNumber(Me.grdList.Rows(i).Cells("VoucherCode").Value)
                    CLS.Notes = FixObjectString(Me.grdList.Rows(i).Cells("Notes").Value)
                    CLS.Add()

                End If
            Next

            btnGenerateSalary_Click(sender, e)
            MsgBox("Salary generated sucessfully.")

        Catch ex As Exception
            MsgBox("btnSave_Click" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If Not isValid() Then Exit Sub
            If MsgBox("Are you sure you want to delete selected employees salary?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub

            Dim i As Integer = 0
            For i = 0 To Me.grdList.Rows.Count - 1
                If FixObjectBoolean(Me.grdList.Rows(i).Cells("Select").Value) = True Then

                    Dim CLS As New Salary
                    CLS.Code = FixObjectNumber(Me.grdList.Rows(i).Cells("Code").Value)
                    CLS.VoucherCode = FixObjectNumber(Me.grdList.Rows(i).Cells("VoucherCode").Value)
                    CLS.Delete()

                End If
            Next

            btnGenerateSalary_Click(sender, e)
            MsgBox("Salary deleted sucessfully.")


        Catch ex As Exception
            MsgBox("btnDelete_Click" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnGenerateSalary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateSalary.Click
        Try
            If FixControl(Me.DropYear) = Nothing Then
                Me.DropYear.Focus()
                MsgBox("Year missing.")
                Exit Sub
            End If
            If FixControl(Me.DropMonth) = Nothing Then
                Me.DropMonth.Focus()
                MsgBox("Month missing.")
                Exit Sub
            End If

            FillGrid()

            Me.DropYear.Enabled = False
            Me.DropMonth.Enabled = False
            Me.btnSave.Enabled = True
            Me.btnDelete.Enabled = True

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DropYear.Enabled = True
        Me.DropMonth.Enabled = True
        Me.btnSave.Enabled = False
        Me.btnDelete.Enabled = False
        Me.grdList.DataSource = Nothing
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub FillGrid()
        Try
            DT.Clear()
            Dim PARA As New ArrayList
            PARA.Add(FixControl(Me.DropMonth))
            PARA.Add(FixControl(Me.DropYear))
            'DT = DBO.ReturnDataTableFromSQL("SELECT Code, AccountNum,Title,Salary FROM dbo.Account where AccountType = " & AccountType.Employee & " ORDER BY Code,Title")
            DT = DBO.ExecuteSP_ReturnDataTable("SalarySelect", PARA)

            Me.grdList.DataSource = DT
            Me.grdList.DataBind()

            GridLayout()

        Catch ex As Exception
            MSG.ErrorOk("[FillGrid]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub GridLayout()
        Try
            Me.grdList.DisplayLayout.Override.RowAlternateAppearance = RowAlternateAppearance
            'Me.grdList.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

            Me.grdList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle

            'If Not Me.grdList.DisplayLayout.Bands(0).Columns.Exists("Select") Then
            '    Me.grdList.DisplayLayout.Bands(0).Columns.Add("Select", "Select")
            '    Me.grdList.DisplayLayout.Bands(0).Columns("Select").Style = ColumnStyle.CheckBox
            '    Me.grdList.DisplayLayout.Bands(0).Columns("Select").Header.Caption = "Select"
            'End If

            'Me.grdList.DisplayLayout.Bands(0).Columns("Code").Hidden = True
            Me.grdList.DisplayLayout.Bands(0).Columns("EmployeeCode").Hidden = True
            Me.grdList.DisplayLayout.Bands(0).Columns("SalaryMonth").Hidden = True
            Me.grdList.DisplayLayout.Bands(0).Columns("SalaryYear").Hidden = True
            Me.grdList.DisplayLayout.Bands(0).Columns("VoucherCode").Hidden = True

            Me.grdList.DisplayLayout.Bands(0).Columns("Select").Header.VisiblePosition = 0
            Me.grdList.DisplayLayout.Bands(0).Columns("Code").Header.VisiblePosition = 1
            Me.grdList.DisplayLayout.Bands(0).Columns("AccountNum").Header.VisiblePosition = 2
            Me.grdList.DisplayLayout.Bands(0).Columns("Title").Header.VisiblePosition = 3
            Me.grdList.DisplayLayout.Bands(0).Columns("SalaryAmount").Header.VisiblePosition = 4
            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").Header.VisiblePosition = 5

            Me.grdList.DisplayLayout.Bands(0).Columns("Code").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("Select").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("AccountNum").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("Title").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("SalaryAmount").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit

            Me.grdList.DisplayLayout.Bands(0).Columns("Code").Width = 100
            Me.grdList.DisplayLayout.Bands(0).Columns("Select").Width = 100
            Me.grdList.DisplayLayout.Bands(0).Columns("AccountNum").Width = 100
            Me.grdList.DisplayLayout.Bands(0).Columns("Title").Width = 250
            Me.grdList.DisplayLayout.Bands(0).Columns("SalaryAmount").Width = 100
            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").Width = 250

            'Me.grdList.DisplayLayout.Bands(0).Columns("Code").PerformAutoResize()
            'Me.grdList.DisplayLayout.Bands(0).Columns("Select").PerformAutoResize()
            'Me.grdList.DisplayLayout.Bands(0).Columns("AccountNum").PerformAutoResize()
            'Me.grdList.DisplayLayout.Bands(0).Columns("Title").PerformAutoResize()
            'Me.grdList.DisplayLayout.Bands(0).Columns("SalaryAmount").PerformAutoResize()
            'Me.grdList.DisplayLayout.Bands(0).Columns("Notes").PerformAutoResize()

            Me.grdList.DisplayLayout.Bands(0).Columns("Code").TabStop = False
            Me.grdList.DisplayLayout.Bands(0).Columns("Select").TabStop = False
            Me.grdList.DisplayLayout.Bands(0).Columns("AccountNum").TabStop = False
            Me.grdList.DisplayLayout.Bands(0).Columns("Title").TabStop = False
            Me.grdList.DisplayLayout.Bands(0).Columns("SalaryAmount").TabStop = True
            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").TabStop = True

            Me.grdList.DisplayLayout.Bands(0).Columns("SalaryAmount").MaskInput = Mask_Amount5Nagative


        Catch ex As Exception
            MSG.ErrorOk("[GridLayout]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Function isValid() As Boolean
        Try
            If FixControl(Me.DropYear) = Nothing Then
                Me.DropYear.Focus()
                MsgBox("Year missing.")
                Return False
            End If
            If FixControl(Me.DropMonth) = Nothing Then
                Me.DropMonth.Focus()
                MsgBox("Month missing.")
                Return False
            End If

            Me.grdList.UpdateData()
            Me.grdList.Update()

            Dim i As Integer = 0
            Dim Found As Boolean = False
            For i = 0 To Me.grdList.Rows.Count - 1
                If FixObjectBoolean(Me.grdList.Rows(i).Cells("Select").Value) = True Then
                    Found = True
                    Exit For
                End If
            Next

            If Not Found Then
                MsgBox("Employee not selected.")
                Return False
            End If

            Return True
        Catch ex As Exception
            MsgBox("isValid" & vbCrLf & ex.Message)
        End Try
    End Function

    Private Sub KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DropMonth.KeyDown, DropYear.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub grdList_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdList.LostFocus
        Me.grdList.UpdateData()
        Me.grdList.Update()
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


    Private Sub btnSelectAll_Click(sender As Object, e As EventArgs) Handles btnSelectAll.Click
        Dim i As Integer = 0
        For i = 0 To Me.grdList.Rows.Count - 1
            Me.grdList.Rows(i).Cells("Select").Value = True
        Next
    End Sub

    Private Sub btnSelectNone_Click(sender As Object, e As EventArgs) Handles btnSelectNone.Click
        Dim i As Integer = 0
        For i = 0 To Me.grdList.Rows.Count - 1
            Me.grdList.Rows(i).Cells("Select").Value = False
        Next
    End Sub
End Class