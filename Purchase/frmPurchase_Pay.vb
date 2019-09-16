Imports POS.FixControls

Public Class frmPurchase_Pay
    Public Arr_Added As New ArrayList
    Public Class Purchase_PaidAmountDetails
        Public Code As System.Int32
        Public EffectiveDate As System.DateTime
        Public InvoiceNum As System.String
        Public TotalAmount As System.Decimal
        Public PaidAmount As System.Decimal
        Public Balance As System.Decimal
        Public CurrentBalance As System.Decimal
    End Class
    Public CLS As Purchase_PaidAmountDetails
    Dim SupplierCode As Integer
    Public Sub New(ByVal _SupplierCode As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        SupplierCode = _SupplierCode

    End Sub

    Private Sub frmPurchase_Pay_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmPurchase_PayIns = Nothing
    End Sub
    Private Sub frmPurchase_Pay_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, txtPaidAmount.KeyUp, txtCheckDate.KeyUp, txtCheckNum.KeyUp, txtNotes.KeyUp, txtPaymentDate.KeyUp, txtRefNum.KeyUp, DropPaymentAccount.KeyUp, txtTotallDueAmount.KeyUp, txtDiscountAtPay.KeyUp
        Select Case e.KeyCode
            Case Keys.End, Keys.Escape
                Me.Close()
        End Select
    End Sub
    Private Sub frmPurchase_Pay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            txtTotallDueAmount.MaskInput = Mask_Amount5
            txtPaidAmount.MaskInput = Mask_Amount5
            txtDiscountAtPay.MaskInput = Mask_Amount5

            'If CLS_Config.Company = EDEE Then
            '    FillDropWithCondition(Me.DropPaymentAccount, "Title", "Code", Table.Account, "AccountType", , , , " WHERE AccountType = " & AccountType.Bank)
            'Else
            FillDropWithCondition(Me.DropPaymentAccount, "Title", "Code", Table.Account, "AccountType", , , , " WHERE AccountType IN ( " & AccountType.Bank & "," & AccountType.Cash & ")")
            'End If
            Dim CLS As New Purchase
            Me.txtTotallDueAmount.Value = CLS.Balance(SupplierCode)
            Me.txtPaymentDate.Value = Now.Date
            Me.txtCheckDate.Value = Nothing
            FillGrid()
            Me.txtPaymentDate.Focus()
        Catch ex As Exception
            MsgBox("frmPurchase_Pay_Load" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub FillGrid()
        Try
            Dim DT As New DataTable
            Dim PARA As New ArrayList
            PARA.Add(0)
            DT = DBO.ExecuteSP_ReturnDataTable("PurchaseListDue", PARA)
            Me.grdList.DataSource = DT
            Me.grdList.DataBind()
            Me.grdList.DisplayLayout.Override.RowAlternateAppearance = RowAlternateAppearance
            Me.grdList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle

            '''''''''''''''''''''Hidden'''''''''''''''''''''
            Me.grdList.DisplayLayout.Bands(0).Columns("Code").Hidden = True
            Me.grdList.DisplayLayout.Bands(0).Columns("EffectiveDate").Hidden = True
            Me.grdList.DisplayLayout.Bands(0).Columns("DiscountAtPay").Hidden = False
            Me.grdList.DisplayLayout.Bands(0).Columns("UserName").Hidden = True
            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").Hidden = True


            '''''''''''''''''''''Cell Activation'''''''''''''''''''''
            Me.grdList.DisplayLayout.Bands(0).Columns("Code").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("EffectiveDate").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("InvoiceNum").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("TotalAmount").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("PaidAmount").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("DiscountAtPay").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("Returned").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("Balance").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("UserName").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            Me.grdList.DisplayLayout.Bands(0).Columns("TotalAmount").MaskInput = Mask_Amount
            Me.grdList.DisplayLayout.Bands(0).Columns("PaidAmount").MaskInput = Mask_Amount
            Me.grdList.DisplayLayout.Bands(0).Columns("DiscountAtPay").MaskInput = Mask_Amount
            Me.grdList.DisplayLayout.Bands(0).Columns("Returned").MaskInput = Mask_Amount
            Me.grdList.DisplayLayout.Bands(0).Columns("Balance").MaskInput = Mask_Amount

        Catch ex As Exception
            MsgBox("FillGrid" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If Not isValid() Then Exit Sub

            Dim ACC As Integer = CLS_Config.AccCash
            If FixControl(Me.DropPaymentAccount) <> Nothing Then
                ACC = Me.DropPaymentAccount.Value
                'ACC = getValueFromDrop(CType(Me.DropPaymentAccount.DataSource, DataTable), "Code", FixControl(Me.DropPaymentAccount), "Code")
            End If

            Dim ActionDate As Date = Me.txtPaymentDate.Value
            If FixControl(Me.txtCheckDate) <> Null_Date Then
                ActionDate = Me.txtCheckDate.Value
            End If

            'Dim PARA2 As New ArrayList
            'PARA2.Add(FixControl(Me.txtRefNum))
            'PARA2.Add(FixControl(Me.txtPaymentDate))
            'PARA2.Add(CLS_Config.Counter)
            'PARA2.Add(ACC)
            'PARA2.Add(UserClass.Code)
            'PARA2.Add(FixControl(Me.txtPaidAmount))
            'PARA2.Add(SupplierCode)
            'Dim VoucherCode As Integer = DBO.ExecuteSP_ReturnInteger("Purchase_PaymentPost", PARA2)

            Dim PARA2 As New ArrayList
            PARA2.Add(FixControl(Me.txtRefNum))
            PARA2.Add(FixControl(Me.txtPaymentDate))
            PARA2.Add(CLS_Config.Counter)
            PARA2.Add(ACC)
            PARA2.Add(UserClass.Code)
            PARA2.Add(FixControl(Me.txtPaidAmount))
            PARA2.Add(FixControl(Me.txtDiscountAtPay))
            PARA2.Add(SupplierCode)
            PARA2.Add(FixControl(Me.txtNotes) & " " & FixControl(Me.txtCheckNum) & " " & FixControl(Me.txtCheckDate))
            Dim VoucherCode As Integer = DBO.ExecuteSP_ReturnInteger("Purchase_PaymentInsert_JV", PARA2)

            Dim PaymentCode As Integer = GetNewCode("PaymentCode", "Purchase_Payment")
            Dim i As Integer = 0
            For i = 0 To Me.grdList.Rows.Count - 1
                Dim PARA As New ArrayList
                PARA.Add(PaymentCode)
                PARA.Add(FixControl(Me.txtRefNum))
                PARA.Add(FixControl(Me.txtPaymentDate))
                PARA.Add(CLS_Config.Counter)
                PARA.Add(ACC)
                PARA.Add(UserClass.Code)
                PARA.Add(FixCellNumber(Me.grdList.Rows(i).Cells("PaidAmount")))
                PARA.Add(FixCellNumber(Me.grdList.Rows(i).Cells("DiscountAtPay")))
                PARA.Add(SupplierCode)

                PARA.Add(FixCellNumber(Me.grdList.Rows(i).Cells("Code")))
                PARA.Add(FixControl(Me.txtCheckNum))
                PARA.Add(FixControl(Me.txtCheckDate))
                PARA.Add(FixControl(Me.txtNotes))
                PARA.Add(VoucherCode)
                DBO.ExecuteSP("Purchase_PaymentInsert", PARA)
            Next

            Me.Close()

        Catch ex As Exception
            MsgBox("btnSave_Click" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub btnSelectPurchase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectPurchase.Click
        Try
            If Not isValid() Then Exit Sub


        Catch ex As Exception
            MsgBox("btnSelectPurchase_Click" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Function isValid() As Boolean
        Try
            If IsDBNull(Me.txtPaymentDate.Value) Or IsNothing(Me.txtPaymentDate.Value) Then
                Me.txtPaymentDate.Focus()
                MsgBox("Payment Date missing.")
                Return False
            ElseIf Me.txtPaymentDate.Value = Nothing Then
                Me.txtPaymentDate.Focus()
                MsgBox("Payment Date missing.")
                Return False
            End If
            If FixControl(Me.txtPaymentDate) > Now.Date Then
                Me.txtPaymentDate.Focus()
                MsgBox("Payment Date can not be greater than today.")
                Return False
            End If
            If IsDBNull(Me.txtRefNum.Value) Or IsNothing(Me.txtRefNum.Value) Then
                Me.txtRefNum.Focus()
                MsgBox("Ref Number missing.")
                Return False
            ElseIf Me.txtRefNum.Value = Nothing Then
                Me.txtRefNum.Focus()
                MsgBox("Ref Number missing.")
                Return False
            End If

            If IsDBNull(Me.txtPaidAmount.Value) Or IsNothing(Me.txtPaidAmount.Value) Then
                Me.txtPaidAmount.Focus()
                MsgBox("Amount missing.")
                Return False
            ElseIf Me.txtPaidAmount.Value = Nothing Then
                Me.txtPaidAmount.Focus()
                MsgBox("Amount missing.")
                Return False
            End If

            If IsDBNull(Me.txtDiscountAtPay.Value) Or IsNothing(Me.txtDiscountAtPay.Value) Then
                Me.txtDiscountAtPay.Value = 0.0
            ElseIf Me.txtDiscountAtPay.Value = Nothing Then
                Me.txtDiscountAtPay.Value = 0.0
            End If

            If IsDBNull(Me.DropPaymentAccount.Value) Or IsNothing(Me.DropPaymentAccount.Value) Then
            ElseIf Me.DropPaymentAccount.Value = Nothing Then
            Else
                Dim AccType As Integer = getValueFromDrop(CType(Me.DropPaymentAccount.DataSource, DataTable), "Code", FixControl(Me.DropPaymentAccount), "AccountType")
                If AccType = AccountType.Bank Then

                    If IsDBNull(Me.txtCheckNum.Value) Or IsNothing(Me.txtCheckNum.Value) Then
                        Me.txtCheckNum.Focus()
                        MsgBox("Check Num missing.")
                        Return False
                    ElseIf Me.txtCheckNum.Value = Nothing Then
                        Me.txtCheckNum.Focus()
                        MsgBox("Check Num missing.")
                        Return False
                    End If

                    If IsDBNull(Me.txtCheckDate.Value) Or IsNothing(Me.txtCheckDate.Value) Then
                        Me.txtCheckDate.Focus()
                        MsgBox("Check Date missing.")
                        Return False
                    ElseIf Me.txtCheckDate.Value = Nothing Then
                        Me.txtCheckDate.Focus()
                        MsgBox("Check Date missing.")
                        Return False
                    End If
                End If
               

            End If


            If Get_Grid_Total(Me.grdList, "PaidAmount") <> FixControl(Me.txtPaidAmount) Then
                MsgBox("Selected Purchase dose not match Payment Amount.")
                Me.txtNotes.Focus()
                Return False
            End If
            If Get_Grid_Total(Me.grdList, "DiscountAtPay") <> FixControl(Me.txtDiscountAtPay) Then
                MsgBox("Please distribute discount correctly.")
                Me.grdList.Focus()
                Me.grdList.Rows(0).Cells("DiscountAtPay").Activate()
                Me.grdList.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, False, False)

                Return False
            End If


            Return True

        Catch ex As Exception
            MsgBox("isValid" & vbCrLf & ex.Message)
        End Try
    End Function
    Private Sub txtAmount_BeforeExitEditMode(ByVal sender As Object, ByVal e As Infragistics.Win.BeforeExitEditModeEventArgs) Handles txtPaidAmount.BeforeExitEditMode, txtTotallDueAmount.BeforeExitEditMode, txtDiscountAtPay.BeforeExitEditMode
        Try
            If FixControl(Me.txtPaidAmount) = Nothing Then Me.txtPaidAmount.Value = 0.0
            If FixControl(Me.txtDiscountAtPay) = Nothing Then Me.txtDiscountAtPay.Value = 0.0


            For i As Integer = 0 To Me.grdList.Rows.Count - 1
                Me.grdList.Rows(i).Selected = True
            Next
            Me.grdList.DeleteSelectedRows(False)

            Arr_Added.Clear()

            'Try
            '    Dim i As Integer = 0
            '    For i = 0 To Me.grdList.Rows.Count - 1
            '        Me.grdList.Rows(i).Delete(False)
            '        i -= 1
            '    Next
            'Catch ex As Exception
            'End Try

            If FixControl(Me.txtPaidAmount) + FixControl(Me.txtDiscountAtPay) > Me.txtTotallDueAmount.Value Then
                MsgBox("Total due amount for supplier is only " & Me.txtTotallDueAmount.Value & " amount field should not' exceed it.")
                e.Cancel = True
            End If
        Catch ex As Exception
            MsgBox("txtAmount_BeforeExitEditMode" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub txtNotes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNotes.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    If FixControl(Me.txtPaidAmount) = Nothing Then Me.txtPaidAmount.Value = 0.0
                    If FixControl(Me.txtDiscountAtPay) = Nothing Then Me.txtDiscountAtPay.Value = 0.0

                    If FixControl(Me.txtPaidAmount) + FixControl(Me.txtDiscountAtPay) > Me.txtTotallDueAmount.Value Then Exit Sub

                    Dim Balance As Decimal = Me.txtPaidAmount.Value - Get_Grid_Total(Me.grdList, "PaidAmount")

                    Balance = Decimal.Round(Balance, 3)
                    Do While Balance > 0

                        CLS = New Purchase_PaidAmountDetails

                        Dim frm As New frmPurchase_Payment_Due(SupplierCode)
                        frm.ShowDialog()

                        If IsDBNull(CLS) Or IsNothing(CLS) Then
                        ElseIf CLS.Code = 0 Then
                            Exit Do
                        Else
                            If Balance < CLS.Balance Then CLS.Balance = Balance
                            Me.grdList.DisplayLayout.Bands(0).AddNew()
                            Balance -= CLS.Balance
                            Balance = Decimal.Round(Balance, 3)
                            Arr_Added.Add(CLS.Code)
                        End If
                    Loop
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub txtTransectionDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPaymentDate.KeyDown, txtRefNum.KeyDown, txtPaidAmount.KeyDown, txtCheckDate.KeyDown, txtCheckNum.KeyDown, DropPaymentAccount.KeyDown, txtDiscountAtPay.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub
    Private Sub txtPaidAmount_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPaidAmount.GotFocus
        Me.txtPaidAmount.SelectAll()
    End Sub
    Private Sub txtDiscountAtPay_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDiscountAtPay.GotFocus
        Me.txtDiscountAtPay.SelectAll()
    End Sub
    Private Sub grdList_AfterRowInsert(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles grdList.AfterRowInsert
        e.Row.Cells("InvoiceNum").Value = CLS.InvoiceNum
        e.Row.Cells("Code").Value = CLS.Code
        e.Row.Cells("EffectiveDate").Value = CLS.EffectiveDate
        e.Row.Cells("TotalAmount").Value = CLS.TotalAmount
        e.Row.Cells("PaidAmount").Value = CLS.Balance
        e.Row.Cells("Balance").Value = CLS.CurrentBalance
        e.Row.Cells("DiscountAtPay").Value = 0
    End Sub
 
End Class