
#Region "Copyright(c)"

'Copyright (c) 2005 OZONE Corporation. All rigths reserved.

#End Region

#Region "Import Directives"

Imports System
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary

#End Region

<Serializable> _
Public Class Srlz
	#Region "Methods"

	Public Shared Function Load(file__1 As String) As Object
		Dim result As Object
		Try
			Dim binFmt As IFormatter = New BinaryFormatter()
			Dim s As Stream = File.Open(file__1, FileMode.Open)
			result = binFmt.Deserialize(s)
			s.Close()
		Catch ex As Exception
			Throw New Exception("Unable to load file " & file__1 & " : " & Convert.ToString(ex))
		End Try
		Return result
	End Function

	Public Shared Sub Save(file__1 As String, obj As Object)
		Dim binFmt As IFormatter = New BinaryFormatter()
		Dim s As Stream = File.Open(file__1, FileMode.Create)
		binFmt.Serialize(s, obj)
		s.Close()
	End Sub

	#End Region
End Class
