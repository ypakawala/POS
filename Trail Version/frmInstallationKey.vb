Imports System.Windows.Forms

Public Class frmInstallationKey

    Public KEY As Boolean

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Me.txtKey.Text = "7412400800" Then
            KEY = True
            'Me.DialogResult = Windows.Forms.DialogResult.Yes
        Else
            KEY = False
            'Me.DialogResult = Windows.Forms.DialogResult.No
        End If
        Me.Close()
    End Sub

    Private Sub btnCancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        KEY = False
        'Me.DialogResult = Windows.Forms.DialogResult.No
        Me.Close()
    End Sub

End Class
