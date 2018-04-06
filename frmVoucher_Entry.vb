Imports POS.FixControls
Public Class frmVoucher_Entry
    Dim Transection_Type As TransectionType
    Dim DT As New DataTable
    Dim CLS_Voucher As New Voucher
    Dim Operation As OperationType = OperationType.Add

    Public Sub New(ByVal _TransectionType As TransectionType, Optional ByVal _VoucherCode As Integer = 0)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Try
            Transection_Type = _TransectionType
            If _VoucherCode <> 0 Then
                Operation = OperationType.Edit
                CLS_Voucher.Select(_VoucherCode)

                Me.txtCode.Value = CLS_Voucher.Code
                Me.txtRefNumber.Value = CLS_Voucher.RefNumber
                Me.txtEffectiveDate.Value = CLS_Voucher.EffectiveDate
                Me.DropAccountFrom.Value = CLS_Voucher.AccountFrom
                Me.DropAccountTo.Value = CLS_Voucher.AccountTo
                Me.txtAmount.Value = CLS_Voucher.Amount
                Me.txtNotes.Value = CLS_Voucher.Notes

                Me.lblTitle.Text = "Edit Voucher"
            Else
                Me.lblTitle.Text = "New Voucher"
            End If

        Catch ex As Exception
            MsgBox("New" & vbCrLf & ex.Message)
        End Try
    End Sub

  
    Private Sub frmPurchase_Edit_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, txtAmount.KeyUp, txtCode.KeyUp, txtRefNumber.KeyUp, txtNotes.KeyUp, txtEffectiveDate.KeyUp, MenuStrip1.KeyUp, DropAccountFrom.KeyUp, DropAccountTo.KeyUp
        Select Case e.KeyCode
            Case Keys.End, Keys.Escape
                Me.Close()
        End Select
    End Sub
    Private Sub frmPurchase_New_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.txtAmount.MaskInput = Mask_Amount5

            Select Case Transection_Type
                Case TransectionType.Capital_Investment
                    FillDropWithCondition(Me.DropAccountFrom, "Title", "Code", Table.Account, "AccountNum", "AccountType", , , " WHERE AccountType IN (" & AccountType.Cash & "," & AccountType.Bank & ")")
                    FillDropWithCondition(Me.DropAccountTo, "Title", "Code", Table.Account, "AccountNum", , , , " WHERE AccountType = " & AccountType.Owner)
                    Me.lblAccountFrom.Text = "Cash/Bank Acc:"
                    Me.lblAccountTo.Text = "Owners Acc:"
                Case TransectionType.Drawing
                    FillDropWithCondition(Me.DropAccountFrom, "Title", "Code", Table.Account, "AccountNum", , , , " WHERE AccountType = " & AccountType.Owner)
                    FillDropWithCondition(Me.DropAccountTo, "Title", "Code", Table.Account, "AccountNum", "AccountType", , , " WHERE AccountType IN (" & AccountType.Cash & "," & AccountType.Bank & ")")
                    Me.lblAccountFrom.Text = "Owners Acc:"
                    Me.lblAccountTo.Text = "Cash/Bank Acc:"
                Case TransectionType.Expenses
                    FillDropWithCondition(Me.DropAccountFrom, "Title", "Code", Table.Account, "AccountNum", , , , " WHERE AccountType = " & AccountType.Expenses)
                    FillDropWithCondition(Me.DropAccountTo, "Title", "Code", Table.Account, "AccountNum", "AccountType", , , " WHERE AccountType IN (" & AccountType.Cash & "," & AccountType.Bank & ")")
                    Me.lblAccountFrom.Text = "Expenses Acc:"
                    Me.lblAccountTo.Text = "Cash/Bank Acc:"
                Case TransectionType.Other_Revenue
                    FillDropWithCondition(Me.DropAccountFrom, "Title", "Code", Table.Account, "AccountNum", "AccountType", , , " WHERE AccountType IN (" & AccountType.Cash & "," & AccountType.Bank & ")")
                    FillDropWithCondition(Me.DropAccountTo, "Title", "Code", Table.Account, "AccountNum", , , , " WHERE AccountType = " & AccountType.Other_Revenue)
                    Me.lblAccountFrom.Text = "Cash/Bank Acc:"
                    Me.lblAccountTo.Text = "Other Revenue Acc:"
            End Select

            If Operation = OperationType.Add Then Me.txtEffectiveDate.Value = Now.Date
            Me.txtRefNumber.Focus()

        Catch ex As Exception
            MsgBox("frmPurchase_New_Load" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Function Save(ByVal Posting As Boolean) As Boolean
        Try
            If Not isValid() Then Exit Function

            CLS_Voucher.RefNumber = Me.txtRefNumber.Value
            CLS_Voucher.EffectiveDate = Me.txtEffectiveDate.Value
            CLS_Voucher.Notes = Me.txtNotes.Value
            CLS_Voucher.Posted = Posting
            CLS_Voucher.TransectionType = Transection_Type
            CLS_Voucher.AccountFrom = Me.DropAccountFrom.Value
            CLS_Voucher.AccountTo = Me.DropAccountTo.Value
            CLS_Voucher.Amount = Me.txtAmount.Value
            Select Case Transection_Type
                Case TransectionType.Capital_Investment, TransectionType.Other_Revenue
                    'from
                    If CType(Me.DropAccountFrom.SelectedRow.Cells("AccountType").Value, AccountType) = AccountType.Cash Then
                        CLS_Voucher.PaymentType = PaymentType.Cash
                    Else
                        CLS_Voucher.PaymentType = PaymentType.KNet
                    End If
                Case TransectionType.Drawing, TransectionType.Expenses
                    'to
                    If CType(Me.DropAccountTo.SelectedRow.Cells("AccountType").Value, AccountType) = AccountType.Cash Then
                        CLS_Voucher.PaymentType = PaymentType.Cash
                    Else
                        CLS_Voucher.PaymentType = PaymentType.KNet
                    End If
            End Select

            Select Case Operation
                Case OperationType.Add : CLS_Voucher.Code = CLS_Voucher.Add()
                Case OperationType.Edit
                    CLS_Voucher.Code = CInt(FixControl(Me.txtCode))
                    CLS_Voucher.Update()
            End Select

            Me.Close()

        Catch ex As Exception
            MsgBox("Save" & vbCrLf & ex.Message)
        End Try
    End Function
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Save(False)
        Catch ex As Exception
            MsgBox("btnSave_Click" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        Save(True)
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Function isValid() As Boolean
        Try
            If FixControl(Me.txtRefNumber) = Nothing Then
                Me.txtRefNumber.Focus()
                MsgBox("Ref # Date missing.")
                Return False
            End If
            If FixControl(Me.txtEffectiveDate) = Null_Date Then
                Me.txtEffectiveDate.Focus()
                MsgBox("Ref # Date missing.")
                Return False
            End If
            If FixControl(Me.DropAccountFrom) = Nothing Then
                Me.DropAccountFrom.Focus()
                MsgBox("Account From missing.")
                Return False
            End If
            If FixControl(Me.DropAccountTo) = Nothing Then
                Me.DropAccountTo.Focus()
                MsgBox("Account To missing.")
                Return False
            End If
            If FixControl(Me.txtAmount) = Nothing Then
                Me.txtAmount.Focus()
                MsgBox("Amount missing.")
                Return False
            End If

            Return True
        Catch ex As Exception
            MsgBox("isValid" & vbCrLf & ex.Message)
        End Try
    End Function

    Private Sub txtTransectionDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEffectiveDate.KeyDown, txtRefNumber.KeyDown, txtAmount.KeyDown, DropAccountFrom.KeyDown, DropAccountTo.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub
    Private Sub txtNotes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNotes.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                btnSave_Click(sender, e)
        End Select
    End Sub


    Private Sub DropAccountTo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DropAccountTo.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter

                    If IsDBNull(Me.DropAccountTo.Text) Or IsNothing(Me.DropAccountTo.Text) Then
                    Else
                        Dim dr() As DataRow = CType(Me.DropAccountTo.DataSource, DataTable).Select(" AccountNum='" & Me.DropAccountTo.Text & "'")
                        If dr.Length > 0 Then Me.DropAccountTo.Value = dr(0).Item("Code")
                    End If

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub DropAccountFrom_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DropAccountFrom.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter

                    If IsDBNull(Me.DropAccountFrom.Text) Or IsNothing(Me.DropAccountFrom.Text) Then
                    Else
                        Dim dr() As DataRow = CType(Me.DropAccountFrom.DataSource, DataTable).Select(" AccountNum='" & Me.DropAccountFrom.Text & "'")
                        If dr.Length > 0 Then Me.DropAccountFrom.Value = dr(0).Item("Code")
                    End If

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class