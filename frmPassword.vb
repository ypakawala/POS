Public Class frmPassword

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TrimStr(Me.TextBox1.Text) = "400800" Then
            Me.DialogResult = Windows.Forms.DialogResult.Yes
        Else
            Me.DialogResult = Windows.Forms.DialogResult.No
        End If
    End Sub

    Private Sub frmPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.Cart_Blue

    End Sub
End Class