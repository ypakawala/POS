
Imports System
Imports System.Windows.Forms


Namespace DosSim
	Public Class DosStr
		Private a As Integer = 0
		Private interval As Integer = 50
		Private ch As Char()
		Private ctrl As Control
		Private tmr As Timer

		Public Sub New(str As String, ctrl As Control)
			tmr = New Timer()
			tmr.Interval = Me.interval
			AddHandler tmr.Tick, New EventHandler(AddressOf tmr_Tick)
			ch = str.ToCharArray()
			Me.ctrl = ctrl
		End Sub

		Public Sub New(str As String, ctrl As Control, interval As Integer)
			tmr = New Timer()
			Me.interval = interval
			tmr.Interval = Me.interval
			AddHandler tmr.Tick, New EventHandler(AddressOf tmr_Tick)
			ch = str.ToCharArray()
			Me.ctrl = ctrl
		End Sub

		Public Sub Start()
			tmr.Start()
		End Sub

		Private Sub tmr_Tick(sender As Object, e As EventArgs)
			If a < ch.Length Then
				ctrl.Text += ch(a).ToString()
				a += 1
			Else
				tmr.[Stop]()
				GC.Collect()
			End If
		End Sub
	End Class
End Namespace
