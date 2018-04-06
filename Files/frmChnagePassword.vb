Imports POS.FixControls
Public Class frmChnagePassword
    Private Sub frmChnagePassword_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtCurrentPassword.Focus()
        Me.txtCurrentPassword.SelectAll()
    End Sub
    Private Sub frmChnagePassword_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, MenuStrip1.KeyUp, txtConfirmPassword.KeyUp, txtCurrentPassword.KeyUp, txtNewPassword.KeyUp, UltraGroupBox1.KeyUp
        Select Case e.KeyCode
            Case Keys.End, Keys.Escape
                Me.Close()
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub
    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If Not isValid() Then Exit Sub

            Dim PARA As New ArrayList
            PARA.Add(UserClass.Code)
            PARA.Add(FixControl(Me.txtNewPassword))
            DBO.ExecuteSP("P_UserPass", PARA)

            UserClass.Pass = FixControl(Me.txtNewPassword)

            MsgBox("Current users password has been changed suessfully.")

            Me.Close()

        Catch ex As Exception
            MsgBox("btnSave_Click" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Function isValid() As Boolean
        Try
            If FixControl(Me.txtCurrentPassword) = Nothing Then
                MSG.ErrorOk("Current Password is missing.")
                Me.txtCurrentPassword.Focus()
                Me.txtCurrentPassword.SelectAll()
                Return False
            End If
            If FixControl(Me.txtNewPassword) = Nothing Then
                MSG.ErrorOk("New Password is missing.")
                Me.txtNewPassword.Focus()
                Me.txtNewPassword.SelectAll()
                Return False
            End If
            If FixControl(Me.txtConfirmPassword) = Nothing Then
                MSG.ErrorOk("Confirm Password is missing.")
                Me.txtConfirmPassword.Focus()
                Me.txtConfirmPassword.SelectAll()
                Return False
            End If

            If Me.txtCurrentPassword.Value <> UserClass.Pass Then
                MSG.ErrorOk("Current Password is wrong.")
                Me.txtCurrentPassword.Focus()
                Me.txtCurrentPassword.SelectAll()
                Return False
            End If

            If Me.txtNewPassword.Value <> Me.txtConfirmPassword.Value Then
                MSG.ErrorOk("Confirm Password is wrong.")
                Me.txtConfirmPassword.Focus()
                Me.txtConfirmPassword.SelectAll()
                Return False
            End If

            Return True
        Catch ex As Exception
            MsgBox("isValid" & vbCrLf & ex.Message)
        End Try
    End Function
End Class