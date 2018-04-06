
Imports System
Imports System.Windows.Forms
Imports System.Drawing

Public Class EnLv
	Private ctrl As Control
	Private strEn As String, strLv As String
	Private fntEn As Font, fntLv As Font
	Private clrEn As Color, clrLv As Color

	Public Sub New(ctrl As Control, strEn As String, strLv As String, fntEn As Font, fntLv As Font, clrEn As Color, _
		clrLv As Color)
		Me.ctrl = ctrl

		Me.strEn = strEn
		Me.strLv = strLv

		Me.fntEn = fntEn
		Me.fntLv = fntLv

		Me.clrEn = clrEn
		Me.clrLv = clrLv

		AddHandler Me.ctrl.Enter, New EventHandler(AddressOf ctrl_Enter)
		AddHandler Me.ctrl.Leave, New EventHandler(AddressOf ctrl_Leave)
	End Sub

	Private Sub ctrl_Enter(sender As Object, e As EventArgs)
		If ctrl.Text.Trim() = strLv Then
			ctrl.Text = strEn
			ctrl.Font = fntEn
			ctrl.ForeColor = clrEn
		End If
	End Sub

	Private Sub ctrl_Leave(sender As Object, e As EventArgs)
		If ctrl.Text.Trim() = strEn Then
			ctrl.Text = strLv
			ctrl.Font = fntLv
			ctrl.ForeColor = clrLv
		End If
	End Sub

	Public Sub Leave()
		ctrl_Leave(Me.ctrl, Nothing)
	End Sub

	Public Sub Enter()
		ctrl_Enter(Me.ctrl, Nothing)
	End Sub
End Class
