Imports POS.FixControls

Public Class frmRedemption

    Dim DT As New DataTable

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub
    Private Sub frmRedemption_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.Cart_Blue
        Try
            FillGrid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillGrid()
        Try
            DT = DBO.ReturnDataTable("SELECT     R.Code, R.ItemCode,I.Barcode,I.Barcode2, I.ItemName, R.RewardPoint FROM dbo.Reward AS R INNER JOIN dbo.Item AS I ON R.ItemCode = I.Code WHERE R.RewardPoint <= " & Find_Dec)
            Me.grdList.DataSource = DT
            Me.grdList.DataBind()

            Me.grdList.DisplayLayout.Override.RowAlternateAppearance = RowAlternateAppearance
            Me.grdList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
            Me.grdList.DisplayLayout.Bands(0).Columns("RewardPoint").MaskInput = Mask_Amount

            Me.grdList.DisplayLayout.Bands(0).Columns("Code").Hidden = True
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemName").Width = 250

            'Dim i As Integer = 0
            'For i = 0 To Me.grdList.Rows.Count - 1

            '    Dim Code As Integer = Me.grdList.Rows(i).Cells("Code").Value
            '    If IsDBNull(frmPurchase_PayIns.Arr_Added) Or IsNothing(frmPurchase_PayIns.Arr_Added) Then Exit Sub
            '    Dim j As Integer = 0
            '    For j = 0 To frmPurchase_PayIns.Arr_Added.Count - 1

            '        Dim CD As Integer = frmPurchase_PayIns.Arr_Added.Item(j)
            '        If CD = Code Then
            '            Me.grdList.Rows(i).Hidden = True
            '            Exit For
            '        End If
            '    Next
            'Next

            Try
                Me.grdList.Rows.GetRowAtVisibleIndex(1).Activated = True
                Me.grdList.Rows.GetRowAtVisibleIndex(1).Selected = True
            Catch ex As Exception
            End Try

        Catch ex As Exception
            MsgBox("FillGrid" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub grdList_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdList.InitializeLayout

    End Sub

    Private Sub grdList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdList.KeyDown
        If e.KeyCode = Keys.Enter Then ReturnCode()
    End Sub
    Private Sub grdList_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles grdList.MouseDoubleClick
        ReturnCode()
    End Sub
    Private Sub ReturnCode()
        Try
            If IsDBNull(Me.grdList.ActiveRow) Or IsNothing(Me.grdList.ActiveRow) Then Exit Sub
            If IsDBNull(Me.grdList.ActiveRow.Cells("Code").Value) Or IsNothing(Me.grdList.ActiveRow.Cells("Code").Value) Then Exit Sub
            If Me.grdList.Rows.VisibleRowCount = 1 Then Exit Sub

            Find_Int = FixCellNumber(Me.grdList.ActiveRow.Cells("Code"))
            Me.DialogResult = Windows.Forms.DialogResult.OK

            Me.Close()
        Catch ex As Exception
            MsgBox("ReturnCode" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub btnRedemption_Click(sender As Object, e As EventArgs) Handles btnRedemption.Click, btnRedemtion2.Click
        ReturnCode()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click, btnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub grdList_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles grdList.DoubleClickCell
        ReturnCode()
    End Sub

End Class