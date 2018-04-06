Imports System.Windows.Forms

Public Class frmRegistration
    Dim Cls_RegDB As New COM_Trail.RegDB

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            If Valid() Then
                Dim a As New DriveInfoApp
                Dim key As String = a.DiskInfo
                key = key.Trim


                If Me.txtRegValue.Text = key Then

                    Dim Cls_RegDetails As New COM_Trail.RegDetails
                    Cls_RegDetails.AppID = 1
                    Cls_RegDetails.RegValue = Me.txtRegValue.Text
                    Cls_RegDetails.UserName = Me.txtUserName.Text
                    Cls_RegDB.Add(Cls_RegDetails)

                    MsgBox("Registration done sucessfully!!!")
                    Me.DialogResult = Windows.Forms.DialogResult.Yes
                Else
                    Me.DialogResult = Windows.Forms.DialogResult.No
                End If
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnCancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.No
        Me.Close()
    End Sub

    Private Function Valid() As Boolean
        Try
            If IsDBNull(Me.txtUserName.Text) Or IsNothing(Me.txtUserName.Text) Then
                MsgBox("Please Insert The User Name") ' TO DO
                Me.txtUserName.Focus()
                Return False
            ElseIf Me.txtUserName.Text = Nothing Then
                MsgBox("Please Insert The User Name") ' TO DO
                Me.txtUserName.Focus()
                Return False
            End If

            If IsDBNull(Me.txtRegValue.Text) Or IsNothing(Me.txtRegValue.Text) Then
                MsgBox("Please Insert The Reg Value") ' TO DO
                Me.txtRegValue.Focus()
                Return False
            ElseIf Me.txtRegValue.Text = Nothing Then
                MsgBox("Please Insert The Reg Value") ' TO DO
                Me.txtRegValue.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
End Class