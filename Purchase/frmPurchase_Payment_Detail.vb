Public Class frmPurchase_Payment_Detail

    Dim DS As New DataSet
    Dim PurchaseCode As Integer


    Public Sub New(ByVal _PurchaseCode As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        PurchaseCode = _PurchaseCode

    End Sub


    Private Sub frmPurchase_Payment_Detail_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, grdList.KeyUp
        Select Case e.KeyCode
            Case Keys.End, Keys.Escape
                Me.Close()
        End Select
    End Sub
    Private Sub frmPurchase_Payment_Detail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FillGrid(PurchaseCode)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub frmPurchase_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MenuStrip1.KeyUp, grdList.KeyUp, Me.KeyUp
        Select Case e.KeyCode
            Case Keys.End, Keys.Escape
                Me.Close()
        End Select
    End Sub
    Private Sub FillGrid(ByVal PurchaseCode As String)
        Try
            Dim DT As New DataTable
            Dim PARA As New ArrayList
            PARA.Add(PurchaseCode)
            DT = DBO.ExecuteSP_ReturnDataTable("Purchase_PaymentDetails", PARA)
            Me.grdList.DataSource = DT
            Me.grdList.DataBind()
            Me.grdList.DisplayLayout.Override.RowAlternateAppearance = RowAlternateAppearance
            Me.grdList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle

            'Me.grdList.DisplayLayout.Bands(0).Columns("Code").Hidden = True
            Me.grdList.DisplayLayout.Bands(0).Columns("VoucherCode").Hidden = True

            Me.grdList.DisplayLayout.Bands(0).Columns("EffectiveDate").MaskInput = "{LOC}dd/mm/yyyy"
            Me.grdList.DisplayLayout.Bands(0).Columns("TransectionDate").MaskInput = "{LOC}dd/mm/yyyy"
            Me.grdList.DisplayLayout.Bands(0).Columns("PaidAmount").MaskInput = Mask_Amount
            Me.grdList.DisplayLayout.Bands(0).Columns("DiscountAtPay").MaskInput = Mask_Amount

        Catch ex As Exception
            MsgBox("FillGrid" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If IsDBNull(Me.grdList.ActiveRow) OrElse IsNothing(Me.grdList.ActiveRow) OrElse Not Me.grdList.ActiveRow.IsDataRow Then
                MsgBox("Invalid selection")
                Exit Sub
            End If

            Dim VoucherCode As Integer = TrimInt(Me.grdList.ActiveRow.Cells("VoucherCode").Value)
            Dim Code As Integer = TrimInt(Me.grdList.ActiveRow.Cells("Code").Value)

            If MsgBox("You are about to delete payment code : " & Code & vbCrLf & "Voucher Code: " & VoucherCode & vbCrLf & vbCrLf & "Are you sure?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub

        
            DBO.ActionQuery("DELETE FROM dbo.Voucher WHERE Code =" & VoucherCode)
            DBO.ActionQuery("DELETE FROM dbo.Purchase_Payment WHERE VoucherCode =" & VoucherCode)

            FillGrid(PurchaseCode)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class