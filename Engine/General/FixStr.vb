
#Region "Copyright(c)"

'Copyright (c) 2006-2007 CONCEPT Software Corporation. All rigths reserved.

#End Region

#Region "Import Directives"

Imports System
Imports System.Text.RegularExpressions

#End Region

Public Class FixStr

#Region "Fields"

    Private Shared m_fix As Boolean = True
    Private Shared before As String() = New String() {"ًًٌٌٍٍَُُُُُِِِْآ", "ًًٌٌٍٍَُُُُُِِِْإ", "ًًٌٌٍٍَُُُُُِِِْأ", "ًًٌٌٍٍَُُُُُِِِْي", "ًًٌٌٍٍَُُُُُِِِْة"}
    Private Shared after As String() = New String() {"ًًٌٌٍٍَُُُُُِِِْا", "ًًٌٌٍٍَُُُُُِِِْا", "ًًٌٌٍٍَُُُُُِِِْا", "ًًٌٌٍٍَُُُُُِِِْى", "ًًٌٌٍٍَُُُُُِِِْه"}

#End Region

#Region "Properties"

    Public Shared Property Fix() As Boolean
        Get
            Return m_fix
        End Get
        Set(ByVal value As Boolean)
            m_fix = Value
        End Set
    End Property

#End Region

#Region "Methods"

    Public Shared Function DiscreteField(ByVal field As String) As String
        Dim str0 As String = "REPLACE(" & field & ", '" & "آ" & "', '" & "ا" & "')"
        Dim str1 As String = "REPLACE(" & str0 & ", '" & "إ" & "', '" & "ا" & "')"
        Dim str2 As String = "REPLACE(" & str1 & ", '" & "أ" & "', '" & "ا" & "')"
        Dim str3 As String = "REPLACE(" & str2 & ", '" & "ي" & "', '" & "ى" & "')"
        Dim str4 As String = "REPLACE(" & str3 & ", '" & "ة" & "', '" & "ه" & "')"
        Return str4
    End Function

    Private Shared Function Fld(ByVal field As String) As String
        If m_fix Then
            Dim str0 As String = "REPLACE(" & field & ", '" & "آ" & "', '" & "ا" & "')"
            Dim str1 As String = "REPLACE(" & str0 & ", '" & "إ" & "', '" & "ا" & "')"
            Dim str2 As String = "REPLACE(" & str1 & ", '" & "أ" & "', '" & "ا" & "')"
            Dim str3 As String = "REPLACE(" & str2 & ", '" & "ي" & "', '" & "ى" & "')"
            Dim str4 As String = "REPLACE(" & str3 & ", '" & "ة" & "', '" & "ه" & "')"
            Return str4
        Else
            Return field
        End If
    End Function

    Public Shared Function DiscreteValue(ByVal val As String) As String
        Dim str0 As String = "REPLACE('" & val & "', '" & "آ" & "', '" & "ا" & "')"
        Dim str1 As String = "REPLACE(" & str0 & ", '" & "إ" & "', '" & "ا" & "')"
        Dim str2 As String = "REPLACE(" & str1 & ", '" & "أ" & "', '" & "ا" & "')"
        Dim str3 As String = "REPLACE(" & str2 & ", '" & "ي" & "', '" & "ى" & "')"
        Dim str4 As String = "REPLACE(" & str3 & ", '" & "ة" & "', '" & "ه" & "')"
        Return str4
    End Function

    Public Shared Function Vlu(ByVal val As String) As String
        If m_fix Then
            Dim str0 As String = "REPLACE('" & val & "', '" & "آ" & "', '" & "ا" & "')"
            Dim str1 As String = "REPLACE(" & str0 & ", '" & "إ" & "', '" & "ا" & "')"
            Dim str2 As String = "REPLACE(" & str1 & ", '" & "أ" & "', '" & "ا" & "')"
            Dim str3 As String = "REPLACE(" & str2 & ", '" & "ي" & "', '" & "ى" & "')"
            Dim str4 As String = "REPLACE(" & str3 & ", '" & "ة" & "', '" & "ه" & "')"
            Return str4
        Else
            Return "'" & val & "'"
        End If
    End Function

    Private Shared Function All(ByVal str As String, ByVal strOp As String, ByVal strCondOp As String) As String
        Dim re As New Regex(strCondOp & "\s\(\S+\s" & strOp & "\s\'", RegexOptions.IgnoreCase)

        Dim mc As MatchCollection = re.Matches(str)

        Dim i As Integer = 0

        For Each m As Match In mc
            Dim lenVlu As Integer = FixStr.Fld("").Length
            Dim lenFld As Integer = FixStr.Vlu("").Length
            Dim lenAll As Integer = i * (lenFld + lenVlu - 2)
            Dim start As Integer = m.Index + m.Length + lenAll
            Dim [end] As Integer = str.IndexOf("')", start)
            Dim len As Integer = [end] - start + 2
            Dim rest As String = str.Substring(start, len)

            Dim strMatch As String = m.Value & rest

            Dim reFld As New Regex("\(\S+", RegexOptions.IgnoreCase)
            Dim mcFld As MatchCollection = reFld.Matches(strMatch)
            If mcFld.Count > 0 Then
                Dim strF As String = mcFld(0).Value.Replace("(", "").Replace(" ", "")
                strF = FixStr.Fld(strF)

                Dim strV As String = rest.Replace("')", "").Replace(" '", "")
                strV = FixStr.Vlu(strV)

                Dim strReplace As String = strCondOp & " (" & strF & " " & strOp & " " & strV & ")"
                str = str.Replace(strMatch, strReplace)
            End If
            i += 1
        Next
        Return str
    End Function
    Private Shared Function AllIn(ByVal str As String, ByVal strOp As String, ByVal strCondOp As String) As String
        Dim re As New Regex(strCondOp & "\s\(\S+\s" & strOp & "\s\(REPLACE", RegexOptions.IgnoreCase)

        Dim mc As MatchCollection = re.Matches(str)

        For Each m As Match In mc
            Dim strMatch As String = m.Value

            Dim reFld As New Regex("\(\S+", RegexOptions.IgnoreCase)
            Dim mcFld As MatchCollection = reFld.Matches(strMatch)
            If mcFld.Count > 0 Then
                Dim strF As String = mcFld(0).Value.Replace("(", "").Replace(" ", "")
                strF = FixStr.Fld(strF)

                Dim strReplace As String = strCondOp & " (" & strF & " " & strOp & " (REPLACE"
                str = str.Replace(strMatch, strReplace)
            End If
        Next
        Return str
    End Function

    Public Shared Function All(ByVal str As String, ByVal blnFix As Boolean) As String
        If blnFix Then
            str = All(str, "=", "WHERE")
            str = All(str, "!=", "WHERE")
            str = All(str, "LIKE", "WHERE")
            str = All(str, "=", "AND")
            str = All(str, "!=", "AND")
            str = All(str, "LIKE", "AND")
            str = AllIn(str, "IN", "WHERE")
            str = AllIn(str, "IN", "AND")
        End If
        Return str
    End Function
    Public Shared Function All(ByVal str As String) As String
        Return All(str, m_fix)
    End Function

#End Region

End Class
