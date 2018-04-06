
#Region "Import Directives"

Imports System
Imports System.Web
Imports System.Diagnostics
Imports System.Globalization
Imports System.Data
Imports System.Collections

#End Region

Namespace HijriGregorian
	Public Class Cnvt
		#Region "Fields"

		Private cur As HttpContext

		Private Const startGreg As Integer = 1900
		Private Const endGreg As Integer = 2100
		Private allFormats As String() = {"yyyy/MM/dd", "yyyy/M/d", "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", _
			"yyyy-MM-dd", "yyyy-M-d", "dd-MM-yyyy", "d-M-yyyy", "dd-M-yyyy", "d-MM-yyyy", _
			"yyyy MM dd", "yyyy M d", "dd MM yyyy", "d M yyyy", "dd M yyyy", "d MM yyyy"}
		Private arCul As CultureInfo
		Private enCul As CultureInfo
		Private h As HijriCalendar
		Private g As GregorianCalendar

		#End Region

		#Region "Properties"
		#End Region

		#Region "Constructors"

		Public Sub New(hijriAdjustment As Integer)
			cur = HttpContext.Current

			arCul = New CultureInfo("ar-KW")
			enCul = New CultureInfo("en-US")

			h = New HijriCalendar()
			h.HijriAdjustment = hijriAdjustment
			g = New GregorianCalendar(GregorianCalendarTypes.USEnglish)


			arCul.DateTimeFormat.Calendar = h
		End Sub

		#End Region

		#Region "Methods"

		''' <summary>
		''' Check if string is hijri date and then return true 
		''' </summary>
		''' <param name="hijri"></param>
		''' <returns></returns>
		Public Function IsHijri(hijri As String) As Boolean
			If hijri.Length <= 0 Then

				cur.Trace.Warn("IsHijri Error: Date String is Empty")
				Return False
			End If
			Try
				Dim tempDate As DateTime = DateTime.ParseExact(hijri, allFormats, arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces)
				If tempDate.Year >= startGreg AndAlso tempDate.Year <= endGreg Then
					Return True
				Else
					Return False
				End If
			Catch ex As Exception
				cur.Trace.Warn("IsHijri Error :" & hijri.ToString() & vbLf & ex.Message)
				Return False
			End Try

		End Function
		''' <summary>
		''' Check if string is Gregorian date and then return true 
		''' </summary>
		''' <param name="greg"></param>
		''' <returns></returns>
		Public Function IsGreg(greg As String) As Boolean
			If greg.Length <= 0 Then

				cur.Trace.Warn("IsGreg :Date String is Empty")
				Return False
			End If
			Try
				Dim tempDate As DateTime = DateTime.ParseExact(greg, allFormats, enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces)
				If tempDate.Year >= startGreg AndAlso tempDate.Year <= endGreg Then
					Return True
				Else
					Return False
				End If
			Catch ex As Exception
				cur.Trace.Warn("IsGreg Error :" & greg.ToString() & vbLf & ex.Message)
				Return False
			End Try

		End Function

		''' <summary>
		''' Return Formatted Hijri date string 
		''' </summary>
		''' <param name="date"></param>
		''' <param name="format"></param>
		''' <returns></returns>
		Public Function FormatHijri([date] As String, format As String) As String
			If [date].Length <= 0 Then

				cur.Trace.Warn("Format :Date String is Empty")
				Return ""
			End If
			Try
				Dim tempDate As DateTime = DateTime.ParseExact([date], allFormats, arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces)

				Return tempDate.ToString(format, arCul.DateTimeFormat)
			Catch ex As Exception
				cur.Trace.Warn("Date :" & vbLf & ex.Message)
				Return ""
			End Try

		End Function
		''' <summary>
		''' Returned Formatted Gregorian date string
		''' </summary>
		''' <param name="date"></param>
		''' <param name="format"></param>
		''' <returns></returns>
		Public Function FormatGreg([date] As String, format As String) As String
			If [date].Length <= 0 Then

				cur.Trace.Warn("Format :Date String is Empty")
				Return ""
			End If
			Try
				Dim tempDate As DateTime = DateTime.ParseExact([date], allFormats, enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces)

				Return tempDate.ToString(format, enCul.DateTimeFormat)
			Catch ex As Exception
				cur.Trace.Warn("Date :" & vbLf & ex.Message)
				Return ""
			End Try

		End Function
		''' <summary>
		''' Return Today Gregorian date and return it in yyyy/MM/dd format
		''' </summary>
		''' <returns></returns>
		Public Function GDateNow() As String
			Try
				Return DateTime.Now.ToString("yyyy/MM/dd", enCul.DateTimeFormat)
			Catch ex As Exception
				cur.Trace.Warn("GDateNow :" & vbLf & ex.Message)
				Return ""
			End Try
		End Function
		''' <summary>
		''' Return formatted today Gregorian date based on your format
		''' </summary>
		''' <param name="format"></param>
		''' <returns></returns>
		Public Function GDateNow(format As String) As String
			Try
				Return DateTime.Now.ToString(format, enCul.DateTimeFormat)
			Catch ex As Exception
				cur.Trace.Warn("GDateNow :" & vbLf & ex.Message)
				Return ""
			End Try
		End Function

		''' <summary>
		''' Return Today Hijri date and return it in yyyy/MM/dd format
		''' </summary>
		''' <returns></returns>
		Public Function HDateNow() As String
			Try
				Return DateTime.Now.ToString("yyyy/MM/dd", arCul.DateTimeFormat)
			Catch ex As Exception
				cur.Trace.Warn("HDateNow :" & vbLf & ex.Message)
				Return ""
			End Try
		End Function
		''' <summary>
		''' Return formatted today hijri date based on your format
		''' </summary>
		''' <param name="format"></param>
		''' <returns></returns>

		Public Function HDateNow(format As String) As String
			Try
				Return DateTime.Now.ToString(format, arCul.DateTimeFormat)
			Catch ex As Exception
				cur.Trace.Warn("HDateNow :" & vbLf & ex.Message)
				Return ""
			End Try

		End Function

		''' <summary>
		''' Convert Hijri Date to it's equivalent Gregorian Date
		''' </summary>
		''' <param name="hijri"></param>
		''' <returns></returns>
		Public Function HijriToGreg(hijri As String) As String
			If hijri.Length <= 0 Then

				cur.Trace.Warn("HijriToGreg :Date String is Empty")
				Return ""
			End If
			Try
				Dim tempDate As DateTime = DateTime.ParseExact(hijri, allFormats, arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces)
				Return tempDate.ToString("yyyy/MM/dd", enCul.DateTimeFormat)
			Catch ex As Exception
				cur.Trace.Warn("HijriToGreg :" & hijri.ToString() & vbLf & ex.Message)
				Return ""
			End Try
		End Function
		''' <summary>
		''' Convert Hijri Date to it's equivalent Gregorian Date and return it in specified format
		''' </summary>
		''' <param name="hijri"></param>
		''' <param name="format"></param>
		''' <returns></returns>
		Public Function HijriToGreg(hijri As String, format As String) As String
			If hijri.Length <= 0 Then
				cur.Trace.Warn("HijriToGreg :Date String is Empty")
				Return ""
			End If
			Try
				Dim tempDate As DateTime = DateTime.ParseExact(hijri, allFormats, arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces)

				Return tempDate.ToString(format, enCul.DateTimeFormat)
			Catch ex As Exception
				cur.Trace.Warn("HijriToGreg :" & hijri.ToString() & vbLf & ex.Message)
				Return ""
			End Try
		End Function

		Public Function HijriToGreg(day As String, month As String, year As String) As DateTime
			Dim hijri As String = day & "/" & month & "/" & year
			Dim d As Integer = Convert.ToInt32(HijriToGreg(hijri, "dd"))
			Dim m As Integer = Convert.ToInt32(HijriToGreg(hijri, "MM"))
			Dim y As Integer = Convert.ToInt32(HijriToGreg(hijri, "yyyy"))

			Return New DateTime(y, m, d)
		End Function

		''' <summary>
		''' Convert Gregoian Date to it's equivalent Hijir Date
		''' </summary>
		''' <param name="greg"></param>
		''' <returns></returns>
		Public Function GregToHijri(greg As String) As String

			If greg.Length <= 0 Then

				cur.Trace.Warn("GregToHijri :Date String is Empty")
				Return ""
			End If
			Try
				Dim tempDate As DateTime = DateTime.ParseExact(greg, allFormats, enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces)

				Return tempDate.ToString("yyyy/MM/dd", arCul.DateTimeFormat)
			Catch ex As Exception
				cur.Trace.Warn("GregToHijri :" & greg.ToString() & vbLf & ex.Message)
				Return ""
			End Try
		End Function
		''' <summary>
		''' Convert Hijri Date to it's equivalent Gregorian Date and return it in specified format
		''' </summary>
		''' <param name="greg"></param>
		''' <param name="format"></param>
		''' <returns></returns>
		Public Function GregToHijri(greg As String, format As String) As String
			If greg.Length <= 0 Then
				cur.Trace.Warn("GregToHijri :Date String is Empty")
				Return ""
			End If
			Try
				Dim tempDate As DateTime = DateTime.ParseExact(greg, allFormats, enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces)
				Return tempDate.ToString(format, arCul.DateTimeFormat)
			Catch ex As Exception
				cur.Trace.Warn("GregToHijri :" & greg.ToString() & vbLf & ex.Message)
				Return ""
			End Try
		End Function

		Public Function GregToHijri(greg As DateTime) As ThreeDateParts
			Dim day As Integer = Convert.ToInt32(GregToHijri(greg.ToShortDateString(), "dd"))
			Dim month As Integer = Convert.ToInt32(GregToHijri(greg.ToShortDateString(), "MM"))
			Dim year As Integer = Convert.ToInt32(GregToHijri(greg.ToShortDateString(), "yyyy"))

			Dim tdp As New ThreeDateParts()
			tdp.day = day.ToString()
			tdp.year = year.ToString()

			Select Case month
				Case 1
					If True Then
						tdp.month = "محرم"
						Exit Select
					End If
				Case 2
					If True Then
						tdp.month = "صفر"
						Exit Select
					End If
				Case 3
					If True Then
						tdp.month = "ربيع أول"
						Exit Select
					End If
				Case 4
					If True Then
						tdp.month = "ربيع ثانى"
						Exit Select
					End If
				Case 5
					If True Then
						tdp.month = "جمادى أول"
						Exit Select
					End If
				Case 6
					If True Then
						tdp.month = "جمادى ثانى"
						Exit Select
					End If
				Case 7
					If True Then
						tdp.month = "رجب"
						Exit Select
					End If
				Case 8
					If True Then
						tdp.month = "شعبان"
						Exit Select
					End If
				Case 9
					If True Then
						tdp.month = "رمضان"
						Exit Select
					End If
				Case 10
					If True Then
						tdp.month = "شوال"
						Exit Select
					End If
				Case 11
					If True Then
						tdp.month = "ذو القعدة"
						Exit Select
					End If
				Case 12
					If True Then
						tdp.month = "ذو الحجة"
						Exit Select
					End If
			End Select
			Return tdp
		End Function

		''' <summary>
		''' Return Gregrian Date Time as digit stamp
		''' </summary>
		''' <returns></returns>
		Public Function GTimeStamp() As String
			Return GDateNow("yyyyMMddHHmmss")
		End Function
		''' <summary>
		''' Return Hijri Date Time as digit stamp
		''' </summary>
		''' <returns></returns>
		Public Function HTimeStamp() As String
			Return HDateNow("yyyyMMddHHmmss")
		End Function

		''' <summary>
		''' Compare if the Hijri date between  other financial year and return True if within , False in not within
		''' </summary>
		''' <param name="dt">Data Table contain start date and end date ,,start date is the first column in table , end date is the second column in table</param>
		''' <param name="fromDate"></param>
		''' <param name="endDate"></param>
		''' <returns></returns>


		''' <summary>
		''' Compare two instaces of string date and return indication of thier values 
		''' </summary>
		''' <param name="d1"></param>
		''' <param name="d2"></param>
		''' <returns>positive d1 is greater than d2,negative d1 is smaller than d2, 0 both are equal</returns>
		Public Function Compare(d1 As String, d2 As String) As Integer
			Try
				Dim date1 As DateTime = DateTime.ParseExact(d1, allFormats, arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces)
				Dim date2 As DateTime = DateTime.ParseExact(d2, allFormats, arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces)
				Return DateTime.Compare(date1, date2)
			Catch ex As Exception
				cur.Trace.Warn("Compare :" & vbLf & ex.Message)
				Return -1
			End Try

		End Function

		#End Region
	End Class

	Public Structure ThreeDateParts
		Public day As String
		Public month As String
		Public year As String
	End Structure
End Namespace
