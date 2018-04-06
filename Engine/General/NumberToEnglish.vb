
#Region "Import Directives"

Imports System

#End Region

Public Class NumberToEnglish
	Public Function changeNumericToWords(numb As Double) As String
		Dim num As String = numb.ToString()
		Return changeToWords(num, False)
	End Function
	Public Function changeCurrencyToWords(numb As String) As String
		Return changeToWords(numb, True)
	End Function
	Public Function changeNumericToWords(numb As String) As String
		Return changeToWords(numb, False)
	End Function
	Public Function changeCurrencyToWords(numb As Double) As String
		Return changeToWords(numb.ToString(), True)
	End Function

	Private Function changeToWords(numb As String, isCurrency As Boolean) As String
		Dim val As [String] = "", wholeNo As [String] = numb, points As [String] = "", andStr As [String] = "", pointStr As [String] = ""
		Dim endStr As [String] = If((isCurrency), ("Only"), (""))
		Try
			Dim decimalPlace As Integer = numb.IndexOf(".")
			If decimalPlace > 0 Then
				wholeNo = numb.Substring(0, decimalPlace)
				points = numb.Substring(decimalPlace + 1)
				If Convert.ToInt32(points) > 0 Then
					andStr = If((isCurrency), ("and"), ("point"))
					' just to separate whole numbers from points/cents
					endStr = If((isCurrency), ("Cents " & endStr), (""))
					pointStr = translateCents(points)
				End If
			End If
			val = [String].Format("{0} {1}{2} {3}", translateWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr)
		Catch
			

		End Try
		Return val
	End Function
	Private Function translateWholeNumber(number As String) As String
		Dim word As String = ""
		Try
			Dim beginsZero As Boolean = False
			'tests for 0XX
			Dim isDone As Boolean = False
			'test if already translated
			Dim dblAmt As Double = (Convert.ToDouble(number))
			'if ((dblAmt > 0) && number.StartsWith("0"))
			If dblAmt > 0 Then
				'test for zero or digit zero in a nuemric
				beginsZero = number.StartsWith("0")

				Dim numDigits As Integer = Convert.ToString(dblAmt).Length
				Dim pos As Integer = 0
				'store digit grouping
				Dim place As [String] = ""
				'digit grouping name:hundres,thousand,etc...
				Select Case numDigits
					Case 1
						'ones' range
						word = ones(number)
						isDone = True
						Exit Select
					Case 2
						'tens' range
						word = tens(number)
						isDone = True
						Exit Select
					Case 3
						'hundreds' range
						pos = (numDigits Mod 3) + 1
						place = " مائة "
						Exit Select
					'thousands' range
					Case 4, 5, 6
						pos = (numDigits Mod 4) + 1
						place = " الف "
						Exit Select
					'millions' range
					Case 7, 8, 9
						pos = (numDigits Mod 7) + 1
						place = " مليون "
						Exit Select
					Case 10
						'Billions's range
						pos = (numDigits Mod 10) + 1
						place = " بليون "
						Exit Select
					Case Else
						'add extra case options for anything above Billion...
						isDone = True
						Exit Select
				End Select
				If Not isDone Then
					'if transalation is not done, continue...(Recursion comes in now!!)
					word = translateWholeNumber(number.Substring(0, pos)) & place & translateWholeNumber(number.Substring(pos))
					'check for trailing zeros
					If beginsZero Then
						word = " و " & word.Trim()
					End If
				End If
				If beginsZero Then
					word = " و " & word.Trim()
				End If
				'ignore digit grouping names
				If word.Trim().Equals(place.Trim()) Then
					word = ""
				End If
			End If
		Catch
			

		End Try
		Return word.Trim()
	End Function
	Private Function tens(digit As String) As String
		Dim digt As Integer = Convert.ToInt32(digit)
		Dim name As [String] = Nothing
		Select Case digt
			Case 10
				name = "عشرة"
				Exit Select
			Case 11
				name = "احد عشر"
				Exit Select
			Case 12
				name = "اثنتا عشر"
				Exit Select
			Case 13
				name = "ثلاثة عشر"
				Exit Select
			Case 14
				name = "اربعة عشر"
				Exit Select
			Case 15
				name = "خمسة عشر"
				Exit Select
			Case 16
				name = "ستة عشر"
				Exit Select
			Case 17
				name = "سبعة عشر"
				Exit Select
			Case 18
				name = "ثمانية عشر"
				Exit Select
			Case 19
				name = "تسعة عشر"
				Exit Select
			Case 20
				name = "عشرون"
				Exit Select
			Case 30
				name = "ثلاثون"
				Exit Select
			Case 40
				name = "اربعون"
				Exit Select
			Case 50
				name = "خمسون"
				Exit Select
			Case 60
				name = "ستون"
				Exit Select
			Case 70
				name = "سبعون"
				Exit Select
			Case 80
				name = "ثمانون"
				Exit Select
			Case 90
				name = "تسعون"
				Exit Select
			Case Else
				If digt > 0 Then
					name = tens(digit.Substring(0, 1) & "0") & " " & ones(digit.Substring(1))
				End If
				Exit Select
		End Select
		Return name
	End Function
	Private Function ones(digit As String) As String
		Dim digt As Integer = Convert.ToInt32(digit)
		Dim name As [String] = ""
		Select Case digt
			Case 1
				name = "واحد"
				Exit Select
			Case 2
				name = "اثنان"
				Exit Select
			Case 3
				name = "ثلاثة"
				Exit Select
			Case 4
				name = "اربعة"
				Exit Select
			Case 5
				name = "خمسة"
				Exit Select
			Case 6
				name = "ستة"
				Exit Select
			Case 7
				name = "سبعة"
				Exit Select
			Case 8
				name = "ثمانية"
				Exit Select
			Case 9
				name = "تسعة"
				Exit Select
		End Select
		Return name
	End Function
	Private Function translateCents(cents As String) As String
		Dim cts As [String] = "", digit As [String] = "", engOne As [String] = ""
		For i As Integer = 0 To cents.Length - 1
			digit = cents(i).ToString()
			If digit.Equals("0") Then
				engOne = "صفر"
			Else
				engOne = ones(digit)
			End If
			cts += " " & engOne
		Next
		Return cts
	End Function
End Class
