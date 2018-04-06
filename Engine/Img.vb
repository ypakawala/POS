
#Region "Copyright(c)"

'Copyright (c) 2005 CONCEPT Corporation. All rigths reserved.

#End Region

#Region "Using Directives"

Imports System
Imports System.IO
Imports System.Drawing

#End Region

Public Class Img
	#Region "Privates"

	#End Region

	#Region "Properties"

	#End Region

	#Region "Constructors"

	Public Sub New()
	End Sub

	#End Region

	#Region "Methods"

	Public Shared Function PureImage(binaryImg As Byte()) As Image
		Try
			Dim ms As New MemoryStream(binaryImg)
			Return Image.FromStream(ms)
		Catch
			Return Nothing
		End Try
	End Function
	Public Shared Function BinaryImage(img As Image) As Byte()
		Try
			Dim ms As New MemoryStream()
            img.Save(ms, img.RawFormat)
			Return ms.GetBuffer()
		Catch
			Return Nothing
		End Try
    End Function

    Public Shared Function BinaryImageBmp(ByVal img As Image) As Byte()
        Try
            Dim ms As New MemoryStream()
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            Return ms.GetBuffer()
        Catch
            Return Nothing
        End Try
    End Function


	Public Shared Function BinaryImage(bmp As Bitmap) As Byte()
		Try
			Dim ms As New MemoryStream()
			bmp.Save(ms, bmp.RawFormat)
			Return ms.GetBuffer()
		Catch
			Return Nothing
		End Try
    End Function

	#End Region

	#Region "Events"
	#End Region
End Class
