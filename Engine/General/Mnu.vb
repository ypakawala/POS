
#Region "Copyright(c)"

'Copyright (c) 2006-2007 CONCEPT Software Corporation. All rigths reserved.

#End Region

#Region "Import Directives"

Imports System
Imports System.Collections
Imports System.Windows.Forms

#End Region

Public Class Mnu
	#Region "Fields"

	Private Shared m_arrStrHeader As String()
	Private Shared m_arrStrSub As String()()
	Private Shared m_alSub As ArrayList()

	#End Region

	#Region "Properties"

	Public Shared Property ArrStrHeader() As String()
		Get
			Return m_arrStrHeader
		End Get
		Set
			m_arrStrHeader = value
		End Set
	End Property

	Public Shared Property ArrStrSub() As String()()
		Get
			Return m_arrStrSub
		End Get
		Set
			m_arrStrSub = value
		End Set
	End Property

	Public Shared Property AlSub() As ArrayList()
		Get
			Return m_alSub
		End Get
		Set
			m_alSub = value
		End Set
	End Property


	#End Region

	#Region "Methods"

	Public Shared Sub Generate(mmMain As MainMenu)
		'we subtract 1 from count because it is used for shortcuts.
		Dim count As Integer = mmMain.MenuItems.Count - 1
		m_arrStrHeader = New String(count - 1) {}
		m_arrStrSub = New String(count - 1)() {}
		m_alSub = New ArrayList(count - 1) {}
		For i As Integer = 0 To count - 1
			Dim subCount As Integer = mmMain.MenuItems(i).MenuItems.Count
			m_arrStrHeader(i) = mmMain.MenuItems(i).Text.Trim()
			m_alSub(i) = New ArrayList()
			For j As Integer = 0 To subCount - 1
				Dim str As String = mmMain.MenuItems(i).MenuItems(j).Text.Trim().Replace("-", "")
				If str <> "" Then
					m_alSub(i).Add(str)
				End If
			Next
		Next
	End Sub

	Public Shared Sub GenerateHeader(mmMain As MainMenu, headerSub As String)
		Dim str As String = headerSub
		Dim arrChar As Char() = str.ToCharArray()
		Dim count As Integer = arrChar.Length
		For i As Integer = 0 To count - 1
			Dim intEn As Integer = Convert.ToInt16(arrChar(i).ToString())
			Dim en As Boolean = Convert.ToBoolean(intEn)
			mmMain.MenuItems(i).Enabled = en
		Next
	End Sub

	Public Shared Sub GenerateSub(mmMain As MainMenu, subString As String)
		Dim str As String = subString
		Dim arrChar As Char() = str.ToCharArray()
		Dim k As Integer = 0
		'we subtract 1 from count because it is used for shortcuts.
		Dim headerCount As Integer = mmMain.MenuItems.Count - 1
		For i As Integer = 0 To headerCount - 1
			Dim subCount As Integer = mmMain.MenuItems(i).MenuItems.Count
			For j As Integer = 0 To subCount - 1
				Dim s As String = mmMain.MenuItems(i).MenuItems(j).Text.Trim().Replace("-", "")
				If s <> "" Then
					Dim intEn As Integer = Convert.ToInt16(arrChar(k).ToString())
					Dim en As Boolean = Convert.ToBoolean(intEn)
					mmMain.MenuItems(i).MenuItems(j).Enabled = en
					k += 1
				End If
			Next
		Next
	End Sub


	#End Region
End Class
