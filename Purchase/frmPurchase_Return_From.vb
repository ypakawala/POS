Imports POS.FixControls

Public Class frmPurchase_Return_From

    Dim DT As New DataTable
    Dim SupplierCode As Integer
    Dim Purchase_Code As Integer = 0
    Dim ItemCode As Integer

    Public Sub New(ByVal _SupplierCode As Integer, ByVal _Purchase_Code As Integer, ByVal _ItemCode As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        SupplierCode = _SupplierCode
        Purchase_Code = _Purchase_Code
        ItemCode = _ItemCode


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
            PARA.Add(Purchase_Code)
            PARA.Add(ItemCode)
            DT = DBO.ExecuteSP_ReturnDataTable("PurchaseListReturnFrom", PARA)
            Me.grdList.DataSource = DT
            Me.grdList.DataBind()

            Me.grdList.DisplayLayout.Override.RowAlternateAppearance = RowAlternateAppearance
            Me.grdList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
            Me.grdList.DisplayLayout.Bands(0).Columns("EffectiveDate").MaskInput = Mask_Date
            Me.grdList.DisplayLayout.Bands(0).Columns("Qty").MaskInput = Mask_Qty
            Me.grdList.DisplayLayout.Bands(0).Columns("QtyStock").MaskInput = Mask_Qty
            Me.grdList.DisplayLayout.Bands(0).Columns("QtyReturned").MaskInput = Mask_Qty
            Me.grdList.DisplayLayout.Bands(0).Columns("UnitPrice").MaskInput = Mask_Amount
            Me.grdList.DisplayLayout.Bands(0).Columns("Price").MaskInput = Mask_Amount

            Dim i As Integer = 0
            For i = 0 To Me.grdList.Rows.Count - 1

                Dim Code As Integer = Me.grdList.Rows(i).Cells("Code").Value
                If IsDBNull(frmPurchase_ReturnIns.Arr_Added) Or IsNothing(frmPurchase_ReturnIns.Arr_Added) Then Exit Sub
                Dim j As Integer = 0
                For j = 0 To frmPurchase_ReturnIns.Arr_Added.Count - 1

                    Dim CD As Integer = frmPurchase_ReturnIns.Arr_Added.Item(j)
                    If CD = Code Then
                        Me.grdList.Rows(i).Hidden = True
                        Exit For
                    End If
                Next
            Next
            If Me.grdList.Rows.VisibleRowCount = 1 Then Me.Close()

            Try
                Me.grdList.Rows.GetRowAtVisibleIndex(1).Activated = True
                Me.grdList.Rows.GetRowAtVisibleIndex(1).Selected = True
            Catch ex As Exception
            End Try

        Catch ex As Exception
            MsgBox("FillGrid" & vbCrLf & ex.Message)
        End Try
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

            frmPurchase_ReturnIns.CLS.Code = FixCellNumber(Me.grdList.ActiveRow.Cells("Code"))
            frmPurchase_ReturnIns.CLS.QtyStock = FixCellNumber(Me.grdList.ActiveRow.Cells("QtyStock"))
            frmPurchase_ReturnIns.CLS.UnitPrice = FixCellNumber(Me.grdList.ActiveRow.Cells("UnitPrice"))
            frmPurchase_ReturnIns.CLS.ExpiryDate = FixCellDate(Me.grdList.ActiveRow.Cells("ExpiryDate"))

            Me.Close()

        Catch ex As Exception
            MsgBox("ReturnPurchaseCode" & vbCrLf & ex.Message)
        End Try
    End Sub
End Class