Imports Infragistics.Win.UltraWinGrid
Imports POS.FixControls
Public Class frmSubscription
    Dim DT As New DataTable

    Private Sub frmSubscription_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, txtStartDate.KeyUp, MenuStrip1.KeyUp, DropNewsPaper.KeyUp
        Select Case e.KeyCode
            Case Keys.End, Keys.Escape
                Me.Close()
        End Select
    End Sub
    Private Sub frmSubscription_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.Cart_Blue
        Try
            Me.Width = Screen.PrimaryScreen.WorkingArea.Width
            Me.Left = 0
            Me.Text = "Subscription"

            FillDropWithCondition(Me.DropNewsPaper, "ItemName", "Code", Table.Item, "CostPrice", "SalesPrice", "BarCode", "BarCode2", " WHERE ItemType = " & ItemType.Subscription_Item)
            FillGrid()

            Me.txtStartDate.Value = New DateTime(Now.Year, Now.Month, 1)
            Me.DropNewsPaper.Focus()

        Catch ex As Exception
            MsgBox("frmSubscription_Load" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub FillGrid()
        Try
            DT.Clear()
            DT = DBO.ReturnDataTableFromSQL("SELECT Code,AccountNum,AccountType,Title,Telephone,Mobile,Notes FROM dbo.Account where AccountType = " & AccountType.Customer & " ORDER BY AccountNum,Title")
            Me.grdList.DataSource = DT
            Me.grdList.DataBind()
            Me.grdList.DisplayLayout.Override.RowAlternateAppearance = RowAlternateAppearance

            Me.grdList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle

            If Not Me.grdList.DisplayLayout.Bands(0).Columns.Exists("Select") Then
                Me.grdList.DisplayLayout.Bands(0).Columns.Add("Select", "Select")
                Me.grdList.DisplayLayout.Bands(0).Columns("Select").Style = ColumnStyle.CheckBox
                Me.grdList.DisplayLayout.Bands(0).Columns("Select").Header.Caption = "Select"
            End If

            Dim i As Integer = 0
            For i = 0 To Me.grdList.Rows.Count - 1
                Me.grdList.Rows(i).Cells("Select").Value = False
                Me.grdList.Rows(i).Update()

            Next

            Me.grdList.DisplayLayout.Bands(0).Columns("Code").Hidden = True
            Me.grdList.DisplayLayout.Bands(0).Columns("AccountType").Hidden = True

            Me.grdList.DisplayLayout.Bands(0).Columns("Select").Header.VisiblePosition = 0
            Me.grdList.DisplayLayout.Bands(0).Columns("AccountNum").Header.VisiblePosition = 1
            Me.grdList.DisplayLayout.Bands(0).Columns("Title").Header.VisiblePosition = 2
            Me.grdList.DisplayLayout.Bands(0).Columns("Telephone").Header.VisiblePosition = 3
            Me.grdList.DisplayLayout.Bands(0).Columns("Mobile").Header.VisiblePosition = 4
            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").Header.VisiblePosition = 5

            'Me.grdList.DisplayLayout.Bands(0).Columns("Title").Width = 150

            Me.grdList.DisplayLayout.Bands(0).Columns("Select").TabStop = True
            Me.grdList.DisplayLayout.Bands(0).Columns("AccountNum").TabStop = False
            Me.grdList.DisplayLayout.Bands(0).Columns("Title").TabStop = False
            Me.grdList.DisplayLayout.Bands(0).Columns("Telephone").TabStop = False
            Me.grdList.DisplayLayout.Bands(0).Columns("Mobile").TabStop = False
            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").TabStop = False

            Me.grdList.DisplayLayout.Bands(0).Columns("AccountNum").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("Title").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("Telephone").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("Mobile").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").Width = 200

            Me.grdList.DisplayLayout.Bands(0).Columns("Code").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("Select").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("AccountNum").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("Title").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("Telephone").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("Mobile").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").PerformAutoResize()


        Catch ex As Exception
            MSG.ErrorOk("[FillGrid]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If Not isValid() Then Exit Sub
            Dim SalesPrice As Decimal = FixObjectNumber(Me.DropNewsPaper.SelectedRow.Cells("SalesPrice").Value)
            Dim CostPrice As Decimal = FixObjectNumber(Me.DropNewsPaper.SelectedRow.Cells("CostPrice").Value)

            Dim SD As Date = CDate(Me.txtStartDate.Value)
            If SD.Day <> 1 Then
                Dim LastDay As Integer = Date.DaysInMonth(SD.Year, SD.Month)
                Dim LastDate As New DateTime(SD.Year, SD.Month, LastDay)
                SalesPrice = Decimal.Round((SalesPrice / LastDay) * ((LastDate.Subtract(SD)).Days + 1), 3)
                CostPrice = Decimal.Round((CostPrice / LastDay) * ((LastDate.Subtract(SD)).Days + 1), 3)
            End If
            Dim FirstDay As New Date

            Dim i As Integer = 0
            For i = 0 To Me.grdList.Rows.Count - 1
                If FixObjectBoolean(Me.grdList.Rows(i).Cells("Select").Value) = True Then

                    Dim CLS_Sale As New Sale
                    CLS_Sale.CustomerCode = FixObjectNumber(Me.grdList.Rows(i).Cells("Code").Value)
                    CLS_Sale.TransectionDate = FixControl(Me.txtStartDate)
                    CLS_Sale.TransectionType = TransectionType.News_Subscription
                    CLS_Sale.BillNo = BillNumber
                    CLS_Sale.UserCode = UserClass.Code
                    CLS_Sale.CounterCode = CLS_Config.Counter
                    CLS_Sale.PaymentType = PaymentType.Credit
                    CLS_Sale.TotalBill = SalesPrice
                    CLS_Sale.Discount = 0
                    CLS_Sale.NetBill = SalesPrice

                    Dim CLS_Sale_Entry As New Sale_Entry
                    CLS_Sale_Entry.ItemCode = FixObjectNumber(Me.DropNewsPaper.SelectedRow.Cells("Code").Value)
                    CLS_Sale_Entry.UnitPrice = SalesPrice
                    CLS_Sale_Entry.Quantity = 1
                    CLS_Sale_Entry.TotalPrice = SalesPrice
                    CLS_Sale_Entry.CostPrice = CostPrice

                    If CLS_Sale.Sale_Sub_Exists(CLS_Sale.CustomerCode, CLS_Sale_Entry.ItemCode, CLS_Sale.TransectionDate.Month) Then
                        MsgBox("Subscription already exists for customer [" & FixObjectString(Me.grdList.Rows(i).Cells("Title").Value) & "]")
                    Else
                        CLS_Sale.Code = CLS_Sale.Add
                        CLS_Sale_Entry.SaleCode = CLS_Sale.Code
                        CLS_Sale_Entry.Add(TransectionType.News_Subscription)

                        BillNumber = BillNumber + 1
                    End If


                End If
            Next

            'If CLS_Config.NewSalesScreen Then
            '    If Not IsNothing(frmSales2Ins) Then frmSales2Ins.txtBillNo.Text = BillNumber
            'Else
            If Not IsNothing(frmSalesIns) Then frmSalesIns.txtBillNo.Text = BillNumber
            'End If

            Me.Close()

        Catch ex As Exception
            MsgBox("btnSave_Click" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Function isValid() As Boolean
        Try
            If FixControl(Me.DropNewsPaper) = Nothing Then
                Me.DropNewsPaper.Focus()
                MsgBox("News Paper / Magzine Name missing.")
                Return False
            End If
            If FixControl(Me.txtStartDate) = Null_Date Then
                Me.txtStartDate.Focus()
                MsgBox("Start Date missing.")
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
                MsgBox("Customer not selected.")
                Return False
            End If

            Return True
        Catch ex As Exception
            MsgBox("isValid" & vbCrLf & ex.Message)
        End Try
    End Function

    Private Sub DropNewsPaper_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStartDate.KeyDown, DropNewsPaper.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub
    Private Sub txtNotes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.Enter
                btnSave_Click(sender, e)
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

End Class