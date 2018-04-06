
#Region "Copyright(c)"

'Copyright (c) 2006-2007 CONCEPT Software Corporation. All rigths reserved.

#End Region

#Region "Import Directives"

Imports System
Imports System.Windows.Forms
Imports System.Globalization

#End Region

Public Class Input
	#Region "Fields"

	Private Shared strNo As String() = New String() {"ًًٌٌٍٍَُُُُُِِِْآ", "ًًٌٌٍٍَُُُُُِِِْإ", "ًًٌٌٍٍَُُُُُِِِْأ", "ًًٌٌٍٍَُُُُُِِِْي", "ًًٌٌٍٍَُُُُُِِِْة"}

	#End Region

	#Region "Methods"


	Private Shared Function StrNoIndex(str As String) As Integer
		Dim re As Integer = -1
		Dim arrChar As Char() = str.ToCharArray()
		For i As Integer = 0 To arrChar.Length - 1
			If arrChar(i) = "أ"C Then
				re = i
			End If
			If arrChar(i) = "إ"C Then
				re = i
			End If
			If arrChar(i) = "آ"C Then
				re = i
			End If
			If arrChar(i) = "ة"C Then
				re = i
			End If
			If arrChar(i) = "ي"C Then
				re = i
			End If
		Next
		Return re
	End Function
    Private Shared Function StrNo1(ByVal str As String) As String
        Dim re As String = ""
        Dim arrChar As Char() = str.ToCharArray()
        For i As Integer = 0 To arrChar.Length - 1
            If arrChar(i) = "أ"c Then
                re = arrChar(i).ToString()
            End If
            If arrChar(i) = "إ"c Then
                re = arrChar(i).ToString()
            End If
            If arrChar(i) = "آ"c Then
                re = arrChar(i).ToString()
            End If
            If arrChar(i) = "ة"c Then
                re = arrChar(i).ToString()
                '				if(arrChar[i] == 'ي' && i == arrChar.Length - 1)
                '				{
                '					re = arrChar[i].ToString();
                '				}
            End If
        Next
        Return re
    End Function
    Private Shared Function StrNo2(ByVal str As String) As String
        Dim re As String = ""
        Dim arrChar As Char() = str.ToCharArray()
        Dim last As Integer = arrChar.Length - 1
        If arrChar(last) = "أ"c Then
            re = arrChar(last).ToString()
        End If
        If arrChar(last) = "إ"c Then
            re = arrChar(last).ToString()
        End If
        If arrChar(last) = "آ"c Then
            re = arrChar(last).ToString()
        End If
        If arrChar(last) = "ة"c Then
            re = arrChar(last).ToString()
        End If
        '				if(arrChar[i] == 'ي' && i == arrChar.Length - 1)
        '				{
        '					re = arrChar[i].ToString();
        '				}
        Return re
    End Function
    Private Shared Function StrYes(ByVal str As String) As String
        Dim re As String = ""
        Select Case str
            Case "أ"
                If True Then
                    re = "ا"
                    Exit Select
                End If
            Case "آ"
                If True Then
                    re = "ا"
                    Exit Select
                End If
            Case "إ"
                If True Then
                    re = "ا"
                    Exit Select
                End If
            Case "ة"
                If True Then
                    re = "ه"
                    Exit Select
                End If
            Case "ي"
                If True Then
                    re = "ى"
                    Exit Select
                End If
        End Select
        Return re
    End Function
	Public Shared Sub Correct(sender As Object)
		'		if(sender != null)
		'		{
		'			try
		'			{
		'				DevExpress.XtraEditors.TextEdit txt = (DevExpress.XtraEditors.TextEdit)sender;
		'				string str = StrNo2(txt.Text);
		'				string strNew = StrYes(str);
		'				int index = StrNoIndex(txt.Text);
		'				if(str != "")
		'				{
		'					string msg = " لقد ادخلت "+" ["+str+"] "+"هل تريد التصحيح ؟ ";
		'					if(MSG.InfoYesNo(msg,1) == DialogResult.Yes)
		'					{
		'						//txt.Text = txt.Text.Replace(str,strNew);
		'						txt.Text = txt.Text.Remove(txt.Text.Length - 1,1)+strNew;
		'						txt.Focus();
		'						txt.Select(txt.Text.Length,0);
		'					}
		'				}
		'			}
		'			catch
		'			{
		'			}
		'		}
	End Sub


	#End Region
End Class
