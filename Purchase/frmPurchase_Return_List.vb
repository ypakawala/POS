Imports POS.FixControls
Imports Infragistics.Win.UltraWinGrid

Public Class frmPurchase_Return_List

    Dim SupplierCode As Integer
    Dim PurchaseCode As Integer
    Dim DS As New DataSet

    Public Sub New(ByVal _SupplierCode As Integer, ByVal _PurchaseCode As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        SupplierCode = _SupplierCode
        PurchaseCode = _PurchaseCode

    End Sub
    Private Sub frmPurchase_Return_List_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FillGrid()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub FillGrid()
        Try
            'DS = CLS_PurchaseDB_DB.ListBySupplier(SupplierCode)
            DS = New DataSet
            Dim PARA As New ArrayList
            PARA.Add(PurchaseCode)
            DS = DBO.ExecuteSP_ReturnDataSet("PurchaseReturnList", PARA)

            If DS.Tables(0).Rows.Count > 0 Then
                'Create the Data Relationship
                DS.Relations.Add("Child", DS.Tables(0).Columns("Code"), _
                                            DS.Tables(1).Columns("PurchaseReturnCode"))
            End If

            Me.grdList.DataSource = DS
            Me.grdList.DataMember = "Table"
            Me.grdList.DataBind()
            Me.grdList.DisplayLayout.Override.RowAlternateAppearance = RowAlternateAppearance
            Me.grdList.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle

            'Set Grid's Columns Order (Arrnage) 
            Me.grdList.DisplayLayout.Bands(0).Columns("Code").Header.VisiblePosition = 0
            Me.grdList.DisplayLayout.Bands(0).Columns("EffectiveDate").Header.VisiblePosition = 1
            Me.grdList.DisplayLayout.Bands(0).Columns("InvoiceNum").Header.VisiblePosition = 2
            Me.grdList.DisplayLayout.Bands(0).Columns("Amount").Header.VisiblePosition = 3
            Me.grdList.DisplayLayout.Bands(0).Columns("Posted").Header.VisiblePosition = 4
            Me.grdList.DisplayLayout.Bands(0).Columns("UserName").Header.VisiblePosition = 5
            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").Header.VisiblePosition = 6

            Me.grdList.DisplayLayout.Bands(0).Columns("EffectiveDate").MaskInput = Mask_Date
            Me.grdList.DisplayLayout.Bands(0).Columns("Amount").MaskInput = Mask_Amount

            Me.grdList.DisplayLayout.Bands(0).Columns("Posted").Width = 50
            Me.grdList.DisplayLayout.Bands(0).Columns("EffectiveDate").Width = 50

            If DS.Tables(0).Rows.Count > 0 Then
                Me.grdList.DisplayLayout.Bands(1).Columns("Code").Hidden = True
                Me.grdList.DisplayLayout.Bands(1).Columns("ItemName").Width = 250
            End If
            'Me.grdList.DisplayLayout.Bands(1).CardView = True

        Catch ex As Exception
            MsgBox("FillGrid" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub grdList_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles grdList.DoubleClickRow
        If e.Row.IsDataRow = False Then Exit Sub
        ReturnPurchaseCode()
    End Sub
    Private Sub grdList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdList.KeyDown
        If e.KeyCode = Keys.Enter Then ReturnPurchaseCode()
    End Sub
    Private Sub ReturnPurchaseCode()
        Try
            If IsDBNull(Me.grdList.ActiveRow) Or IsNothing(Me.grdList.ActiveRow) Then Exit Sub
            If IsDBNull(Me.grdList.ActiveRow.Cells("Code").Value) Or IsNothing(Me.grdList.ActiveRow.Cells("Code").Value) Then Exit Sub
            If Me.grdList.Rows.VisibleRowCount = 1 Then Exit Sub


            frmPurchase_ReturnIns = Nothing
            frmPurchase_ReturnIns = New frmPurchase_Return(SupplierCode, PurchaseCode, FixCellNumber(Me.grdList.ActiveRow.Cells("Code")))
            frmPurchase_ReturnIns.ShowDialog()


            Me.Close()

        Catch ex As Exception
            MsgBox("ReturnPurchaseCode" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub frmPurchase_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MenuStrip1.KeyUp, grdList.KeyUp, Me.KeyUp
        Select Case e.KeyCode
            Case Keys.End, Keys.Escape
                Me.Close()
        End Select
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class