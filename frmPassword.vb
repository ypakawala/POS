Public Class frmPassword

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TrimStr(Me.TextBox1.Text) = "400800" Then
            Me.DialogResult = Windows.Forms.DialogResult.Yes
        Else
            Me.DialogResult = Windows.Forms.DialogResult.No
        End If
    End Sub

End Class