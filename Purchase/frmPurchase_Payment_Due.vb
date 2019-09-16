Imports POS.FixControls

Public Class frmPurchase_Payment_Due

    Dim DT As New DataTable
    Dim SupplierCode As Integer

    Public Sub New(ByVal _SupplierCode As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        SupplierCode = _SupplierCode

    End Sub
    Private Sub frmPurchase_Payment_Due_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FillGrid(SupplierCode)
        Catch ex As Exception

        End Try
    End Sub
   
    Private Sub FillGrid(ByVal SupplierCode As String)
        Try
            Dim PARA As New ArrayList
            PARA.Add(SupplierCode)
            DT = DBO.ExecuteSP_ReturnDataTable("PurchaseListDue", PARA)
            Me.grdList.DataSource = DT
            Me.grdList.DataBind()

            Me.grdList.DisplayLayout.Override.RowAlternateAppearance = RowAlternateAppearance
            Me.grdList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
            Me.grdList.DisplayLayout.Bands(0).Columns("EffectiveDate").MaskInput = Mask_Date
            Me.grdList.DisplayLayout.Bands(0).Columns("TotalAmount").MaskInput = Mask_Amount
            Me.grdList.DisplayLayout.Bands(0).Columns("PaidAmount").MaskInput = Mask_Amount
            Me.grdList.DisplayLayout.Bands(0).Columns("Returned").MaskInput = Mask_Amount
            Me.grdList.DisplayLayout.Bands(0).Columns("Balance").MaskInput = Mask_Amount

            Dim i As Integer = 0
            For i = 0 To Me.grdList.Rows.Count - 1

                Dim Code As Integer = Me.grdList.Rows(i).Cells("Code").Value
                If IsDBNull(frmPurchase_PayIns.Arr_Added) Or IsNothing(frmPurchase_PayIns.Arr_Added) Then Exit Sub
                Dim j As Integer = 0
                For j = 0 To frmPurchase_PayIns.Arr_Added.Count - 1

                    Dim CD As Integer = frmPurchase_PayIns.Arr_Added.Item(j)
                    If CD = Code Then
                        Me.grdList.Rows(i).Hidden = True
                        Exit For
                    End If
                Next
            Next

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
        If e.KeyCode = Keys.Enter Then ReturnPurchaseCode()
    End Sub
    Private Sub grdList_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles grdList.MouseDoubleClick
        ReturnPurchaseCode()
    End Sub
    Private Sub ReturnPurchaseCode()
        Try
            If IsDBNull(Me.grdList.ActiveRow) Or IsNothing(Me.grdList.ActiveRow) Then Exit Sub
            If IsDBNull(Me.grdList.ActiveRow.Cells("Code").Value) Or IsNothing(Me.grdList.ActiveRow.Cells("Code").Value) Then Exit Sub
            If Me.grdList.Rows.VisibleRowCount = 1 Then Exit Sub

            frmPurchase_PayIns.CLS.Code = FixCellNumber(Me.grdList.ActiveRow.Cells("Code"))
            frmPurchase_PayIns.CLS.EffectiveDate = FixCellDate(Me.grdList.ActiveRow.Cells("EffectiveDate"))
            frmPurchase_PayIns.CLS.InvoiceNum = FixCellString(Me.grdList.ActiveRow.Cells("InvoiceNum"))
            frmPurchase_PayIns.CLS.TotalAmount = FixCellNumber(Me.grdList.ActiveRow.Cells("TotalAmount"))
            frmPurchase_PayIns.CLS.PaidAmount = 0
            frmPurchase_PayIns.CLS.Balance = FixCellNumber(Me.grdList.ActiveRow.Cells("Balance"))
            frmPurchase_PayIns.CLS.CurrentBalance = FixCellNumber(Me.grdList.ActiveRow.Cells("Balance"))

            Me.Close()
        Catch ex As Exception
            MsgBox("ReturnPurchaseCode" & vbCrLf & ex.Message)
        End Try
    End Sub
End Class