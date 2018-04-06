
#Region "Copyright(c)"

'Copyright (c) 2006-2007 CONCEPT Software Corporation. All rigths reserved.

#End Region

#Region "Import Directives"

Imports System
Imports System.IO
Imports System.Data
Imports System.Windows.Forms
Imports Infragistics.Win.UltraWinGrid

#End Region

Public Class MD

    Public Shared Function FileToBinary(ByVal fileName As String) As Byte()
        Dim fileStream As New FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read)

        Dim len As Long
        len = fileStream.Length

        Dim fileAsByte As [Byte]() = New [Byte](len - 1) {}
        fileStream.Read(fileAsByte, 0, fileAsByte.Length)

        Dim memoryStream As New MemoryStream(fileAsByte)
        Return memoryStream.ToArray()
    End Function

#Region "Others"

    Public Shared Function IsContained(ByVal tbl As DataTable, ByVal col As String, ByVal val As String) As Boolean
        Dim re As Boolean = False
        If tbl.Rows.Count > 0 Then
            For i As Integer = 0 To tbl.Rows.Count - 1
                Dim tblVal As String = tbl.Rows(i)(col).ToString()
                If tblVal = val Then
                    re = True
                    Exit For
                End If
            Next
        End If
        Return re
    End Function
    Public Shared Function IsContained(ByVal tbl As DataTable, ByVal col As String, ByVal val As String, ByVal exceptRow As Integer) As Boolean
        Dim re As Boolean = False
        If tbl.Rows.Count > 0 Then
            For i As Integer = 0 To tbl.Rows.Count - 1
                If i <> exceptRow Then
                    Dim tblVal As String = tbl.Rows(i)(col).ToString()
                    If tblVal = val Then
                        re = True
                        Exit For
                    End If
                End If
            Next
        End If
        Return re
    End Function
    Public Shared Function IsContained(ByVal tbl As DataTable, ByVal col As Integer, ByVal val As String, ByVal exceptRow As Integer) As Boolean
        Dim re As Boolean = False
        If tbl.Rows.Count > 0 Then
            For i As Integer = 0 To tbl.Rows.Count - 1
                If i <> exceptRow Then
                    Dim tblVal As String = tbl.Rows(i)(col).ToString()
                    If tblVal = val Then
                        re = True
                        Exit For
                    End If
                End If
            Next
        End If
        Return re
    End Function
    Public Shared Function IsContained(ByVal tbl As DataTable, ByVal col As Integer, ByVal val As String) As Boolean
        Dim re As Boolean = False
        If tbl.Rows.Count > 0 Then
            For i As Integer = 0 To tbl.Rows.Count - 1
                Dim tblVal As String = tbl.Rows(i)(col).ToString()
                If tblVal = val Then
                    re = True
                    Exit For
                End If
            Next
        End If
        Return re
    End Function


    Public Shared Function GetIndex(ByVal tbl As DataTable, ByVal whereFiled As String, ByVal whereVal As String) As Integer
        Dim re As Integer = -1
        If tbl IsNot Nothing AndAlso tbl.Rows.Count > 0 Then
            For i As Integer = 0 To tbl.Rows.Count - 1
                Dim currentVal As String = tbl.Rows(i)(whereFiled).ToString()
                If currentVal = whereVal Then
                    re = i
                    Exit For
                End If
            Next
        End If
        Return re
    End Function

    Public Shared Function GetRowIndex(ByVal tbl As DataTable, ByVal matchValue As String, ByVal columnName As String) As Integer
        Dim index As Integer = -1
        If tbl IsNot Nothing Then
            For i As Integer = 0 To tbl.Rows.Count - 1
                Dim currentId As String = tbl.Rows(i)(columnName).ToString()
                If matchValue = currentId Then
                    index = i
                    Exit For
                End If
            Next
        End If
        Return index
    End Function
    Public Shared Function GetRowIndex(ByVal tbl As DataTable, ByVal matchValue As String, ByVal columnNumber As Integer) As Integer
        Dim index As Integer = -1
        If tbl IsNot Nothing Then
            If tbl.Columns.Count > 0 Then
                Dim columnName As String = tbl.Columns(columnNumber).ColumnName
                index = GetRowIndex(tbl, matchValue, columnName)
            End If
        End If
        Return index
    End Function


    Public Shared Sub ReArrange(ByVal table As DataTable, ByVal col As Integer)
        If table IsNot Nothing Then
            If table.Rows.Count > 0 Then
                For i As Integer = 0 To table.Rows.Count - 1
                    table.Rows(i)(col) = i + 1
                Next
            End If
        End If
    End Sub

    Public Shared Sub ReArrange(ByVal table As DataTable, ByVal strCol As String, ByVal columnCategory As String)
        If table IsNot Nothing Then
            If table.Rows.Count > 0 Then
                Dim strBase As String = table.Rows(0)(columnCategory).ToString()
                Dim a As Integer = 0
                For i As Integer = 0 To table.Rows.Count - 1
                    Dim strValue As String = table.Rows(i)(columnCategory).ToString()
                    If strValue <> strBase Then
                        strBase = table.Rows(i)(columnCategory).ToString()
                        a = 0
                    End If
                    a += 1
                    table.Rows(i)(strCol) = a
                Next
            End If
        End If
    End Sub

    Public Shared Sub ReArrange(ByVal table As DataTable, ByVal col As Integer, ByVal seed As Integer)
        If table IsNot Nothing Then
            If table.Rows.Count > 0 Then
                For i As Integer = 0 To table.Rows.Count - 1
                    table.Rows(i)(col) = i + 1 + seed
                Next
            End If
        End If
    End Sub
    Public Shared Sub ReArrangeTable(ByVal tblTarget As DataTable, ByVal strCol As String)
        If tblTarget IsNot Nothing Then
            For i As Integer = 0 To tblTarget.Rows.Count - 1
                tblTarget.Rows(i)(strCol) = Convert.ToString(i + 1)
            Next
        End If
    End Sub
    Public Shared Sub ReArrangeTable(ByVal tblTarget As DataTable, ByVal colNum As Integer)
        If tblTarget IsNot Nothing Then
            Dim colName As String = tblTarget.Columns(colNum).ColumnName
            ReArrangeTable(tblTarget, colName)
        End If
    End Sub


    Public Shared Function CellValue(ByVal grid As UltraGrid, ByVal col As Integer) As String
        Dim re As String = ""
        'Dim tbl As DataTable = DirectCast(grid.GridControl.DataSource, DataTable)
        'If tbl.Rows.Count > 0 Then
        '    Dim index As Integer = grid.GetSelectedRows()(0)

        '    If index > -1 Then
        '        re = tbl.Rows(index)(col).ToString()
        '    End If
        'End If
        Return re
    End Function
    Public Shared Function CellValue(ByVal grid As UltraGrid, ByVal col As String) As String
        Dim re As String = ""
        'Dim tbl As DataTable = DirectCast(grid.GridControl.DataSource, DataTable)
        'If tbl.Rows.Count > 0 Then
        '    Dim index As Integer = grid.GetSelectedRows()(0)

        '    If index > -1 Then
        '        re = tbl.Rows(index)(col).ToString()
        '    End If
        'End If
        Return re
    End Function


    Public Shared Sub AddRows(ByVal tblFrom As DataTable, ByVal tblTo As DataTable)
        For i As Integer = 0 To tblFrom.Rows.Count - 1
            Dim dr As DataRow = tblTo.NewRow()
            For j As Integer = 0 To tblFrom.Columns.Count - 1
                dr(j) = tblFrom.Rows(i)(j)
            Next
            tblTo.Rows.Add(dr)
        Next
        MD.ReArrange(tblTo, 0)
    End Sub

    Public Shared Sub AddRow(ByVal gridFrom As DataGrid, ByVal tblTo As DataTable)
        Dim index As Integer = gridFrom.CurrentRowIndex
        If index > -1 Then
            Dim tblFrom As DataTable = DirectCast(gridFrom.DataSource, DataTable)
            tblTo.Clear()
            Dim dr As DataRow = tblTo.NewRow()
            For j As Integer = 0 To tblFrom.Columns.Count - 1
                dr(j) = tblFrom.Rows(index)(j)
            Next
            tblTo.Rows.Add(dr)
            MD.ReArrange(tblTo, 0)
        End If
    End Sub


    Public Shared Sub SetFocus(ByVal ctrlDest As Control, ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            ctrlDest.Focus()
        End If
    End Sub


    Public Shared Sub EscapeControl(ByVal ctrlFirst As Control, ByVal ctrlNext As Control)
        ctrlNext.TabIndex = ctrlFirst.TabIndex
        ctrlFirst.TabStop = False
    End Sub


    Public Shared Sub EnDisable(ByVal sender As Object, ByVal ParamArray ctrl As Control())
        Dim chk As CheckBox = DirectCast(sender, CheckBox)
        EnDisable(chk.Checked, ctrl)
    End Sub
    Public Shared Sub EnDisable(ByVal sender As Object, ByVal frm As Form, ByVal strTag As String)
        'Dim chk As DevExpress.XtraEditors.CheckEdit = DirectCast(sender, DevExpress.XtraEditors.CheckEdit)
        Dim chk As CheckBox = DirectCast(sender, CheckBox)
        EnDisable(chk.Checked, frm, strTag)
    End Sub
    Public Shared Sub EnDisable(ByVal en As Boolean, ByVal ParamArray ctrl As Control())
        For Each c As Control In ctrl
            c.Enabled = en
        Next
    End Sub
    Public Shared Sub EnDisable(ByVal en As Boolean, ByVal frm As Form, ByVal strTag As String)
        Try
            For Each c As Control In frm.Controls
                If c.Tag.ToString() = strTag Then
                    c.Enabled = en
                End If
            Next
        Catch
        End Try
    End Sub

    Public Shared Sub Visiblity(ByVal sender As Object, ByVal ParamArray ctrl As Control())
        Dim chk As CheckBox = DirectCast(sender, CheckBox)
        Visiblity(chk.Checked, ctrl)
    End Sub
    Public Shared Sub Visiblity(ByVal en As Boolean, ByVal ParamArray ctrl As Control())
        For Each c As Control In ctrl
            c.Visible = en
        Next
    End Sub

    Public Shared Sub Action(ByVal action As _Action, ByVal e As KeyPressEventArgs)
        If CInt(AscW(e.KeyChar)) = CInt(Keys.Enter) Then
            action()
        End If
    End Sub

    Public Shared Sub OpenLoad(ByVal tableName As String, ByVal blnAction As BlnAction, ByVal cbo As UltraCombo, ByVal loadCombo As LoadCombo)
        Dim name As String = cbo.Text
        Dim code As String = CNI.GetCode(tableName, name)

        If blnAction() Then
            loadCombo(cbo)
            name = CNI.GetName(tableName, code)
            cbo.Text = name
        End If
    End Sub

    Public Shared Sub OpenLoad(ByVal blnAction As BlnAction, ByVal cbo As UltraCombo, ByVal loadCombo As LoadCombo)
        Dim str As String = cbo.Text

        If blnAction() Then
            loadCombo(cbo)
            cbo.Text = str
        End If
    End Sub

    Public Shared Function BoolNullHandle(ByVal obj As Object) As Boolean
        If obj Is Nothing OrElse obj Is DBNull.Value Then
            obj = 0
        End If

        Return Convert.ToBoolean(obj)
    End Function

#End Region

End Class

Public Delegate Sub LoadCombo(ByVal cbo As UltraCombo)
