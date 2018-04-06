Imports POS.FixControls
Public Class frmSalaryPayment
    Dim EmployeeCode As TransectionType
    Dim DT As New DataTable
    Dim CLS_Voucher As New Voucher
    Dim Operation As OperationType = OperationType.Add

    Public Sub New(ByVal _EmployeeCode As TransectionType, ByVal _Balance As TransectionType, Optional ByVal _VoucherCode As Integer = 0)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Try
            EmployeeCode = _EmployeeCode
            If _VoucherCode <> 0 Then
                Operation = OperationType.Edit
                CLS_Voucher.Select(_VoucherCode)

                Me.txtCode.Value = CLS_Voucher.Code
                Me.txtRefNumber.Value = CLS_Voucher.RefNumber
                Me.txtEffectiveDate.Value = CLS_Voucher.EffectiveDate
                'Me.DropAccountFrom.Value = CLS_Voucher.AccountFrom
                Me.DropAccountTo.Value = CLS_Voucher.AccountTo
                Me.txtAmount.Value = CLS_Voucher.Amount
                Me.txtNotes.Value = CLS_Voucher.Notes

                Me.txtBalance.Value = _Balance + CLS_Voucher.Amount


                Me.lblTitle.Text = "Edit Salary Payment"
            Else
                Me.lblTitle.Text = "New Salary Payment"
                Me.txtBalance.Value = _Balance
                Me.txtAmount.Value = Nothing
            End If

        Catch ex As Exception
            MsgBox("New" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub txtAmount_GotFocus(sender As Object, e As EventArgs) Handles txtAmount.GotFocus
        Me.txtAmount.SelectAll()
    End Sub
    Private Sub frmSalaryPayment_Edit_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, txtAmount.KeyUp, txtCode.KeyUp, txtRefNumber.KeyUp, txtNotes.KeyUp, txtEffectiveDate.KeyUp, MenuStrip1.KeyUp, DropAccountTo.KeyUp, txtBalance.KeyUp
        Select Case e.KeyCode
            Case Keys.End, Keys.Escape
                Me.Close()
        End Select
    End Sub
    Private Sub frmSalaryPayment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.txtAmount.MaskInput = Mask_Amount5
            Me.txtBalance.MaskInput = Mask_Amount5

            FillDropWithCondition(Me.DropAccountTo, "Title", "Code", Table.Account, "AccountNum", "AccountType", , , " WHERE AccountType IN (" & AccountType.Cash & "," & AccountType.Bank & ")")

            'If CLS_Voucher.Code <> 0 Then
            '    Dim dr() As DataRow = CType(Me.DropAccountTo.DataSource, DataTable).Select(" Code=" & CLS_Voucher.AccountTo)
            '    If dr.Length > 0 Then Me.DropAccountTo.Value = dr(0).Item("AccountNum")
            'End If

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
            CLS_Voucher.TransectionType = TransectionType.Salary_Payment
            CLS_Voucher.AccountFrom = EmployeeCode
            CLS_Voucher.AccountTo = Me.DropAccountTo.Value
            CLS_Voucher.Amount = Me.txtAmount.Value
  
            If CType(Me.DropAccountTo.SelectedRow.Cells("AccountType").Value, AccountType) = AccountType.Cash Then
                CLS_Voucher.PaymentType = PaymentType.Cash
            Else
                CLS_Voucher.PaymentType = PaymentType.KNet
            End If

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
            Save(True)
        Catch ex As Exception
            MsgBox("btnSave_Click" & vbCrLf & ex.Message)
        End Try
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
            'If FixControl(Me.txtAmount) > FixControl(Me.txtBalance) Then
            '    Me.txtAmount.Focus()
            '    If MsgBox("Amount should be less than [ " & FixControl(Me.txtBalance) & " ]. Are you sure?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
            '        Return False
            '    End If
            'End If

            Return True
        Catch ex As Exception
            MsgBox("isValid" & vbCrLf & ex.Message)
        End Try
    End Function

    Private Sub txtTransectionDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEffectiveDate.KeyDown, txtRefNumber.KeyDown, txtAmount.KeyDown, DropAccountTo.KeyDown, txtBalance.KeyDown
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

End Class