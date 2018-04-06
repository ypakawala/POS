
#Region "Copyright(c)"

'Copyright (c) 2006-2007 CONCEPT Software Corporation. All rigths reserved.

#End Region

#Region "Import Directives"

Imports System

#End Region

Public Class CNQ
	'Code Name Query(Data) Layer
	#Region "Methods"

	Public Shared Function GetNextQ(strTable As String, field As String, seed As String) As String
		Dim q As String = "SELECT " & "(CASE ISNULL(MAX(CAST(" & field & " AS BIGINT)), " & seed & ") " & "WHEN " & Int64.MaxValue & " THEN (CASE MIN(CAST(" & field & " AS BIGINT)) WHEN 1 THEN - 1 ELSE MIN(CAST(" & field & " AS BIGINT)) - 1 END) " & "ELSE ISNULL(MAX(CAST(" & field & " AS BIGINT)), " & seed & ") + 1 END) " & "AS nextCode FROM " & strTable
		Return q
	End Function

	Public Shared Function GetNextQ(strTable As String, field As String) As String
		Return GetNextQ(strTable, field, "0")
		

	End Function

	Public Shared Function GetNextCodeQ(strTable As String, seed As String) As String
		Return GetNextQ(strTable, "code", seed)
	End Function

	Public Shared Function GetNextCodeQ(strTable As String) As String
		Return GetNextCodeQ(strTable, "0")
	End Function

	Public Shared Function GetNextOwnCodeQ(strTable As String, seed As String) As String
		Return GetNextQ(strTable, "ownCode", seed)
	End Function

	Public Shared Function GetNextOwnCodeQ(strTable As String) As String
		Return GetNextOwnCodeQ(strTable, "0")
	End Function

	Public Shared Function LoadDataQ(strTable As String) As String
		Dim q As String = "SELECT code, name FROM " & strTable
		Return q
	End Function
	Public Shared Function LoadDataQ(strTable As String, code As String) As String
		Dim q As String = "SELECT code, name FROM " & strTable & " Where (code = " & code & ")"
		Return q
	End Function

	Public Shared Function LoadCodesQ(strTable As String) As String
		Dim q As String = "SELECT code FROM " & strTable & " ORDER BY code"
		Return q
	End Function
	Public Shared Function DeleteQ(strTable As String) As String
		Dim q As String = "DELETE FROM " & strTable
		Return q
	End Function
	Public Shared Function DeleteQ(strTable As String, code As String) As String
		Dim q As String = DeleteQ(strTable, "code", code)
		Return q
	End Function

	Public Shared Function DeleteQ(strTable As String, field As String, val As String) As String
        Dim q As String = "DELETE FROM " & strTable & " where (" & field & " = '" & val & "')"
		Return q
	End Function

#End Region

End Class
