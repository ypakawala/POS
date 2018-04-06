
Imports System.Data
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinGrid

Public Class FixControls

#Region "Methods"

    ''' <summary>
    ''' Thsi Function Check the value of control and return Empty string in case DBNULL or return the existing string
    ''' </summary>
    ''' <param name="cntrl">UltraTextEditor to Validate</param>
    ''' <returns>String Value in UltraTextEditor Control or Empty String in case of DBNULL</returns>
    ''' <remarks></remarks>
    Public Shared Function FixControl(ByRef cntrl As Infragistics.Win.UltraWinEditors.UltraTextEditor) As String
        Try
            If IsDBNull(cntrl.Value) Or IsNothing(cntrl.Value) Then
                Return ""
            Else
                Return cntrl.Value
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return ""
        End Try
    End Function
    Public Shared Function FixControl(ByRef cntrl As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit) As Decimal
        Try
            If IsDBNull(cntrl.Value) Or IsNothing(cntrl.Value) Then
                Return Nothing
            Else
                Return Decimal.Round(CDec(cntrl.Value), 3)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return 0
        End Try
    End Function
    Public Shared Function FixControl(ByRef cntrl As Infragistics.Win.UltraWinEditors.UltraComboEditor) As Decimal
        Try
            If IsDBNull(cntrl.Value) Or IsNothing(cntrl.Value) Then
                Return Nothing
            Else
                Return cntrl.Value
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return 0
        End Try
    End Function
    Public Shared Function FixControl(ByRef cntrl As Infragistics.Win.UltraWinGrid.UltraCombo) As Decimal
        Try
            If IsDBNull(cntrl.Value) Or IsNothing(cntrl.Value) Then
                Return Nothing
            Else
                Return Decimal.Round(CDec(cntrl.Value), 3)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return 0
        End Try
    End Function
    Public Shared Function FixControl(ByRef cntrl As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor) As Date
        Try
            If IsDBNull(cntrl.Value) Or IsNothing(cntrl.Value) Then
                Return Null_Date
            Else
                Return CDate(cntrl.Value)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Null_Date
        End Try
    End Function
    Public Shared Function FixControl(ByRef cntrl As Infragistics.Win.UltraWinEditors.UltraNumericEditor) As Decimal
        Try
            If IsDBNull(cntrl.Value) Or IsNothing(cntrl.Value) Then
                Return 0.0
            Else
                Return Decimal.Round(CDec(cntrl.Value), 3)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return 0.0
        End Try
    End Function
    Public Shared Function FixControl(ByRef cntrl As Infragistics.Win.UltraWinEditors.UltraCheckEditor) As Boolean
        Try
            If IsDBNull(cntrl.Checked) Or IsNothing(cntrl.Checked) Then
                Return False
            Else
                Return CBool(cntrl.Checked)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Shared Function FixCellNumber(ByVal Cell As Infragistics.Win.UltraWinGrid.UltraGridCell) As Decimal
        Try
            If IsDBNull(Cell.Value) Or IsNothing(Cell.Value) Then
                Return Nothing
            Else
                Return Decimal.Round(CDec(Cell.Value), 3)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return 0
        End Try
    End Function
    Public Shared Function FixCellString(ByVal Cell As Infragistics.Win.UltraWinGrid.UltraGridCell) As String
        Try
            If IsDBNull(Cell.Value) Or IsNothing(Cell.Value) Then
                Return ""
            Else
                Return CStr(Cell.Value)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return ""
        End Try
    End Function
    Public Shared Function FixCellDate(ByVal Cell As Infragistics.Win.UltraWinGrid.UltraGridCell) As Date
        Try
            If IsDBNull(Cell.Value) Or IsNothing(Cell.Value) Then
                Return Null_Date
            Else
                Return CDate(Cell.Value)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Null_Date
        End Try
    End Function
    Public Shared Function FixCellBoolean(ByVal Cell As Infragistics.Win.UltraWinGrid.UltraGridCell) As Boolean
        Try
            If IsDBNull(Cell.Value) Or IsNothing(Cell.Value) Then
                Return False
            Else
                Return CBool(Cell.Value)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    Public Shared Function FixObjectNumber(ByVal value As Object) As Decimal
        Try
            If IsDBNull(value) Or IsNothing(value) Then
                Return 0
            Else
                Return Decimal.Round(CDec(value), 3)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return 0
        End Try
    End Function
    Public Shared Function FixObjectString(ByVal value As Object) As String
        Try
            If IsDBNull(value) Or IsNothing(value) Then Return ""
            Return CStr(value.ToString.Trim)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return 0
        End Try
    End Function
    Public Shared Function FixObjectBoolean(ByVal value As Object) As Boolean
        Try
            If IsDBNull(value) Or IsNothing(value) Then Return False
            Return CBool(value)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return 0
        End Try
    End Function
    Public Shared Function FixObjectDate(ByVal value As Object) As DateTime
        Try
            If IsDBNull(value) Or IsNothing(value) Then Return Null_Date
            Return CDate(value)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Null_Date
        End Try
    End Function
    Public Shared Function FixControlDateToString(ByRef cntrl As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor) As String
        Try
            If IsDBNull(cntrl.Value) Or IsNothing(cntrl.Value) Then
                Return Nothing
            Else
                Return CDate(cntrl.Value).ToString("MM/dd/yyyy HH:mm:ss")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    'Public Shared Function FixControl(ByRef cntrl As UltraTextEditor) As String
    '    Try
    '        If IsDBNull(cntrl.Value) Or IsNothing(cntrl.Value) Then Return ""
    '        Return cntrl.Value
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        Return ""
    '    End Try
    'End Function

    'Public Shared Function FixControl(ByRef cntrl As UltraTextEditor) As Decimal
    '    Try
    '        If IsDBNull(cntrl.Value) Or IsNothing(cntrl.Value) Then Return 0
    '        If cntrl.Value = Nothing Then Return 0
    '        Return cntrl.Value
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        Return 0
    '    End Try
    'End Function

    'Public Shared Function FixControl(ByRef cntrl As UltraTextEditor) As Date
    '    Try
    '        If IsDBNull(cntrl.Value) Or IsNothing(cntrl.Value) Then Return DT.Null_Date
    '        If cntrl.Value = Nothing Then Return DT.Null_Date
    '        Return cntrl.Value
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        Return DT.Null_Date
    '    End Try
    'End Function

    'Public Shared Function FixControl(ByRef cntrl As UltraTextEditor) As Decimal
    '    Try
    '        If IsDBNull(cntrl.Value) Or IsNothing(cntrl.Value) Then Return Nothing
    '        If cntrl.DisplayText = cntrl.Value Then Return Nothing
    '        Return cntrl.Value
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        Return False
    '    End Try
    'End Function
    'Public Shared Function FixDropString(ByRef cntrl As UltraTextEditor) As String
    '    Try
    '        If IsDBNull(cntrl.Value) Or IsNothing(cntrl.Value) Then Return Nothing
    '        If cntrl.DisplayText = cntrl.Value Then Return Nothing
    '        Return cntrl.Value
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        Return False
    '    End Try
    'End Function

    'Public Shared Function FixCellNumber(ByVal Cell As Infragistics.Win.UltraWinGrid.UltraGridCell) As Decimal
    '    Try
    '        If IsDBNull(Cell.Value) Or IsNothing(Cell.Value) Then Return Nothing
    '        Return Cell.Value
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        Return 0
    '    End Try
    'End Function

    'Public Shared Function FixCellString(ByVal Cell As Infragistics.Win.UltraWinGrid.UltraGridCell) As String
    '    Try
    '        If IsDBNull(Cell.Value) Or IsNothing(Cell.Value) Then Return ""
    '        Return Cell.Value
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        Return ""
    '    End Try
    'End Function

    'Public Shared Function FixCellDate(ByVal Cell As Infragistics.Win.UltraWinGrid.UltraGridCell) As Date
    '    Try
    '        If IsDBNull(Cell.Value) Or IsNothing(Cell.Value) Then Return DT.Null_Date
    '        Return Cell.Value
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        Return DT.Null_Date
    '    End Try
    'End Function

    'Public Shared Function FixObjectNumber(ByVal value As Object) As Decimal
    '    Try
    '        If IsDBNull(value) Or IsNothing(value) Then Return 0
    '        Return value
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        Return 0
    '    End Try
    'End Function

    'Public Shared Function FixObject(ByVal Value As Object) As Object
    '    Try
    '        If IsDBNull(Value) Or IsNothing(Value) Then Return Nothing
    '        Return Value
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        Return Nothing
    '    End Try
    'End Function

    'Public Shared Function FixDrop(ByRef Combo As UltraCombo) As Boolean
    '    Try
    '        If IsDBNull(Combo.Value) Or IsNothing(Combo.Value) Then
    '            Combo.Value = Nothing
    '        End If
    '        Return True
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        Return Nothing
    '    End Try
    'End Function

#End Region

End Class