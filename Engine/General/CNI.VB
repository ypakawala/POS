
#Region "Copyright(c)"

'Copyright (c) 2006-2007 CONCEPT Software Corporation. All rigths reserved.

#End Region

#Region "Import Directives"

Imports System
Imports System.Data
Imports System.Windows.Forms
Imports System.Windows
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinGrid

#End Region

Public Class CNI

    'Code Name Implementation Layer

#Region "Methods"

    Public Shared Function GetByCode(ByVal table As String, ByVal field As String, ByVal code As String) As String
        If code <> "" Then
            Dim q As String = "SELECT " & field & " FROM " & table & " WHERE (code = " & code & ")"
            Return DBO.GetSingleString(q, "")
        Else
            Return ""
        End If
    End Function

    Public Shared Function GetOwnCode(ByVal table As String, ByVal field As String, ByVal val As String, ByVal nullRe As String) As String
        Dim q As String = "SELECT ownCode FROM " & table & " WHERE (" & field & " = '" & val & "')"
        Return DBO.GetSingleString(q, nullRe)
    End Function

    Public Shared Function GetCodeByBase(ByVal table As String, ByVal name As String, ByVal baseField As String, ByVal baseCode As String, ByVal nullRe As String) As String
        Dim q As String = "SELECT code FROM " & table & " WHERE (name = '" & name & "') AND (" & baseField & " = " & baseCode & ")"
        Return DBO.GetSingleString(q, nullRe)
    End Function

    Public Shared Function GetCode(ByVal table As String, ByVal field As String, ByVal val As String, ByVal nullRe As String) As String
        Dim q As String = "SELECT code FROM " & table & " WHERE (" & field & " = '" & val & "')"
        Return DBO.GetSingleString(q, nullRe)
    End Function

    Public Shared Function GetCode(ByVal table As String, ByVal field As String, ByVal val As String) As String
        Return GetCode(table, field, val, "NULL")
    End Function

    Public Shared Function GetOwnCode(ByVal table As String, ByVal field As String, ByVal val As String) As String
        Return GetOwnCode(table, field, val, "NULL")
    End Function

    Public Shared Function GetCode(ByVal table As String, ByVal name As String) As String
        Return GetCode(table, "name", name, "NULL")
    End Function

    Public Shared Function GetOwnCode(ByVal table As String, ByVal name As String) As String
        Return GetOwnCode(table, "name", name, "NULL")
    End Function

    Public Shared Function GetNameByOwnCode(ByVal table As String, ByVal ownCode As String, ByVal nullRe As String) As String
        If ownCode <> "" Then
            Dim q As String = "SELECT name FROM " & table & " WHERE (ownCode = '" & ownCode & "')"
            Return DBO.GetSingleString(q, nullRe)
        Else
            Return ""
        End If
    End Function

    Public Shared Function GetNameByOwnCode(ByVal table As String, ByVal ownCode As String) As String
        Return GetNameByOwnCode(table, ownCode, "")
    End Function

    Public Shared Function GetName(ByVal table As String, ByVal code As String, ByVal nullRe As String) As String
        If code <> "" Then
            Dim q As String = "SELECT name FROM " & table & " WHERE (code = " & code & ")"
            Return DBO.GetSingleString(q, nullRe)
        Else
            Return ""
        End If
    End Function

    Public Shared Function GetName(ByVal table As String, ByVal code As String) As String
        Return GetName(table, code, "")
    End Function

    Public Shared Function GetNext(ByVal strTable As String, ByVal field As String) As String
        Dim q As String = CNQ.GetNextQ(strTable, field)
        Return DBO.GetSingleValue(q).ToString()
    End Function

    Public Shared Function GetNextCode(ByVal strTable As String) As String
        Dim q As String = CNQ.GetNextCodeQ(strTable)
        Return DBO.GetSingleValue(q).ToString()
    End Function

    Public Shared Function GetNextCode100X(ByVal strTable As String) As String
        Dim q As String = CNQ.GetNextCodeQ(strTable, "100")
        Return DBO.GetSingleValue(q).ToString()
    End Function

    Public Shared Function GetNextOwnCode100(ByVal strTable As String) As String
        Dim q As String = CNQ.GetNextOwnCodeQ(strTable, "100")
        Return DBO.GetSingleValue(q).ToString()
    End Function

    Public Shared Function GetNextOwnCode(ByVal strTable As String) As String
        Dim q As String = CNQ.GetNextOwnCodeQ(strTable, "0")
        Return DBO.GetSingleValue(q).ToString()
    End Function

    Public Shared Sub NextCode(ByVal strTable As String, ByVal txtCode As UltraTextEditor)
        txtCode.Text = GetNextCode(strTable)
    End Sub

    Public Shared Sub NextCode100X(ByVal strTable As String, ByVal txtCode As UltraTextEditor)
        txtCode.Text = GetNextCode100X(strTable)
    End Sub

    Public Shared Sub NextOwnCode100(ByVal strTable As String, ByVal txtOwnCode As UltraTextEditor)
        txtOwnCode.Text = GetNextOwnCode100(strTable)
    End Sub

    Public Shared Sub LoadCodes(ByVal strTable As String, ByRef tblCodes As DataTable, ByVal txtRecords As UltraTextEditor)
        Dim q As String = CNQ.LoadCodesQ(strTable)
        tblCodes = DBO.ReturnDataTable(q)
        'Record.Show(tblCodes.Rows.Count, tblCodes, txtRecords)
    End Sub

    Public Shared Function Delete(ByVal strTable As String, ByVal code As String) As Boolean
        Dim q As String = CNQ.DeleteQ(strTable, "code", code)
        Return DBO.ActionQuery(q)
    End Function

    Public Shared Function DeleteFromGrid(ByRef grid As UltraGrid, ByVal strTable As String) As Boolean
        Try
            'Dim i As Integer = 0
            'Dim dr As DataRecord

            'For i = 0 To grid.Records.Count - 1
            '    dr = grid.Records(i)
            '    If dr.RecordType = RecordType.DataRecord Then
            '        If dr.Cells("Selected").Value = True Then
            '            'DeletedCodes.Add(dr.Cells("Code").Value)
            '            Dim q As String = CNQ.DeleteQ(strTable, "code", dr.Cells("Code").Value)
            '            DBO.ActionQuery(q)
            '        End If
            '    End If
            'Next
        Catch ex As Exception

        End Try
    End Function

    Public Shared Function Delete(ByVal strTable As String, ByVal field As String, ByVal val As String) As Boolean
        Dim q As String = CNQ.DeleteQ(strTable, field, val)
        Return DBO.ActionQuery(q)
    End Function

    Public Shared Function Deleting(ByVal strTable As String, ByVal code As String, ByVal deleteData As Boolean, ByVal modi As Boolean, ByVal [New] As _Action) As Boolean
        Dim re As Boolean = False
        'If deleteData Then
        '    If modi Then
        '        If MSG.AskBeforeDeleting = DialogResult.Yes Then 'do you want to delete this data
        '            If CNI.Delete(strTable, code) Then
        '                [New]()
        '                re = True
        '            End If
        '        End If
        '    Else
        '        MSG.SelectDataToDelete() 'please select the data you wnt to delete
        '    End If
        'Else
        '    MSG.PermissionDenied() 'can not delete this data
        'End If
        Return re
    End Function

    'Public Shared Function Deleting(ByVal deleteData As Boolean, ByVal modi As Boolean, ByVal Delete As BlnAction, ByVal [New] As _Action, ByVal Counter As _Action, ByVal FillDrops As _Action) As Boolean
    '    Dim re As Boolean = False
    '    If deleteData Then
    '        If modi Then
    '            If MSG.WarnYesNo("هل تريد حذف هذا السجل؟", 1) = DialogResult.Yes Then 'do you want to delete this data
    '                DBO.BeginTransaction()
    '                Try
    '                    If Delete() Then
    '                        [New]()
    '                        DBO.Commit()
    '                        FillDrops()
    '                        Counter()
    '                        re = True
    '                    Else
    '                        DBO.Rollback()
    '                    End If
    '                Catch ex As Exception
    '                    DBO.Rollback()
    '                    MSG.ErrorOk("لا يمكن الحذف") 'delete faliure
    '                End Try
    '            End If
    '        Else
    '            MSG.ErrorOk("من فضلك إختر السجل المراد حذفه") 'please select the data you wnt to delete
    '        End If
    '    Else
    '        MSG.ErrorOk("لا يمكن الحذف طبقا للصلاحيات") 'can not delete this data
    '    End If
    '    Return re
    'End Function

    Public Shared Function Deleting(ByVal deleteData As Boolean, ByVal modi As Boolean, ByVal Delete As BlnAction, ByVal [New] As _Action, ByVal Counter As _Action, ByVal FillDrops As _Action, ByVal AuditSection As Integer, Optional ByVal AuditDescription As String = "") As Boolean
        Dim re As Boolean = False
        If deleteData Then
            If modi Then
                If MSG.WarnYesNo("هل تريد حذف هذا السجل؟", 1) = DialogResult.Yes Then 'do you want to delete this data
                    DBO.BeginTransaction()
                    Try
                        If Delete() Then
                            'Audit.AuditDelete(AuditSection, AuditDescription)
                            [New]()
                            DBO.Commit()
                            FillDrops()
                            Counter()
                            re = True
                        Else
                            DBO.Rollback()
                        End If
                    Catch ex As Exception
                        DBO.Rollback()
                        MSG.ErrorOk("لا يمكن الحذف") 'delete faliure
                    End Try
                End If
            Else
                MSG.ErrorOk("من فضلك إختر السجل المراد حذفه") 'please select the data you wnt to delete
            End If
        Else
            MSG.ErrorOk("لا يمكن الحذف طبقا للصلاحيات") 'can not delete this data
        End If
        Return re
    End Function

    Public Shared Function Adding(ByVal strTable As String, ByVal txtCode As UltraTextEditor, ByVal Add As BlnAction, ByVal [New] As _Action) As Boolean
        Dim re As Boolean = False
        CNI.NextCode(strTable, txtCode)
        If Add() Then
            [New]()
            re = True
        End If
        Return re
    End Function

    Public Shared Function Adding(ByVal Add As BlnAction, ByVal [New] As _Action) As Boolean
        Dim re As Boolean = False
        If Add() Then
            [New]()
            re = True
        End If
        Return re
    End Function

    Public Shared Function AddingX(ByVal Add As BlnAction, ByVal [New] As _Action) As Boolean
        Dim re As Boolean = False
        If MSG.AskBeforeSaving = DialogResult.Yes Then  'do you want to save this data
            If Add() Then
                [New]()
                re = True
            End If
        End If
        Return re
    End Function

    Public Shared Function Editing(ByVal Edit As BlnAction, ByVal [New] As _Action) As Boolean
        Dim re As Boolean = False
        If MSG.AskBeforeEditing = DialogResult.Yes Then 'do you want to save this data
            If Edit() Then
                [New]()
                re = True
            End If
        End If
        Return re
    End Function

    Public Shared Function Saving(ByVal addData As Boolean, ByVal editData As Boolean, ByVal deleteData As Boolean, ByVal modi As Boolean, ByVal CanSave As BlnAction, ByVal Editing As BlnAction, _
     ByVal Adding As BlnAction, ByVal Clear As _Action, ByVal [New] As _Action, ByVal AuditSection As Integer, Optional ByVal AuditDescription As String = "") As Boolean
        Dim re As Boolean = False

        Dim watchOnly As Boolean = False
        Dim saveData As Boolean = False
        If Not addData AndAlso Not editData AndAlso Not deleteData Then
            watchOnly = True
        End If
        If addData OrElse editData Then
            saveData = True
        End If
        '--------------------------------------------------------------
        If Not watchOnly Then
            If saveData Then
                If modi Then
                    If editData Then
                        DBO.BeginTransaction()
                        Try
                            If CanSave() Then
                                If Editing() Then
                                    DBO.Commit()
                                    'Audit.AuditEdit(AuditSection, AuditDescription)
                                    re = True
                                Else
                                    MSG.ErrorOk("لا يمكن الحفظ") 'NOT SAVED
                                    DBO.Rollback()
                                End If
                            Else
                                DBO.Rollback()
                            End If
                        Catch ex As Exception
                            DBO.Rollback()
                            MSG.ErrorOk("لا يمكن التعديل") 'update faliure
                        End Try
                    Else
                        MSG.ErrorOk("لا يمكن التعديل طبقا للصلاحيات") 'can not update this data
                    End If
                Else
                    If addData Then
                        DBO.BeginTransaction()
                        Try
                            If CanSave() Then
                                If Adding() Then
                                    DBO.Commit()
                                    'Audit.AuditAdd(AuditSection, AuditDescription)
                                    Clear()
                                    [New]()
                                    re = True
                                Else
                                    DBO.Rollback()
                                    MSG.ErrorOk("لا يمكن إضافة البيانات") 'add faliure
                                End If
                            Else
                                DBO.Rollback()
                            End If
                        Catch ex As Exception
                            DBO.Rollback()
                            MSG.ErrorOk("لا يمكن إضافة البيانات") 'data not added
                        End Try
                    Else
                        MSG.ErrorOk("لا يمكن التعديل طبقا للصلاحيات") 'can not add this data
                    End If
                End If
            Else
                MSG.ErrorOk("لا يمكن التعديل طبقا للصلاحيات") 'can not add/update this data
            End If
        Else
            MSG.ErrorOk("لا يمكن التعديل او الاضافة طبقا للصلاحيات") 'can not save. you can view only
        End If
        Return re
    End Function

    Public Shared Function SavingWithOutClearAndNew(ByVal addData As Boolean, ByVal editData As Boolean, ByVal deleteData As Boolean, ByVal modi As Boolean, ByVal CanSave As BlnAction, ByVal Editing As BlnAction, ByVal Adding As BlnAction, ByVal AuditSection As Integer, Optional ByVal AuditDescription As String = "") As Boolean
        Dim re As Boolean = False

        Dim watchOnly As Boolean = False
        Dim saveData As Boolean = False
        If Not addData AndAlso Not editData AndAlso Not deleteData Then
            watchOnly = True
        End If
        If addData OrElse editData Then
            saveData = True
        End If
        '--------------------------------------------------------------
        If Not watchOnly Then
            If saveData Then
                If modi Then
                    If editData Then
                        DBO.BeginTransaction()
                        Try
                            If CanSave() Then
                                If Editing() Then
                                    DBO.Commit()
                                    'Audit.AuditEdit(AuditSection, AuditDescription)
                                    re = True
                                Else
                                    MSG.ErrorOk("لا يمكن الحفظ") 'NOT SAVED
                                    DBO.Rollback()
                                End If
                            Else
                                DBO.Rollback()
                            End If
                        Catch ex As Exception
                            DBO.Rollback()
                            MSG.ErrorOk("لا يمكن التعديل") 'update faliure
                        End Try
                    Else
                        MSG.ErrorOk("لا يمكن التعديل طبقا للصلاحيات") 'can not update this data
                    End If
                Else
                    If addData Then
                        DBO.BeginTransaction()
                        Try
                            If CanSave() Then
                                If Adding() Then
                                    DBO.Commit()
                                    'Audit.AuditAdd(AuditSection, AuditDescription)
                                    re = True
                                Else
                                    DBO.Rollback()
                                    MSG.ErrorOk("لا يمكن إضافة البيانات") 'add faliure
                                End If
                            Else
                                DBO.Rollback()
                            End If
                        Catch ex As Exception
                            DBO.Rollback()
                            MSG.ErrorOk("لا يمكن إضافة البيانات") 'data not added
                        End Try
                    Else
                        MSG.ErrorOk("لا يمكن التعديل طبقا للصلاحيات") 'can not add this data
                    End If
                End If
            Else
                MSG.ErrorOk("لا يمكن التعديل طبقا للصلاحيات") 'can not add/update this data
            End If
        Else
            MSG.ErrorOk("لا يمكن التعديل طبقا للصلاحيات") 'can not save. you can view only
        End If
        Return re
    End Function

    Public Shared Function SavingEx(ByVal addData As Boolean, ByVal editData As Boolean, ByVal deleteData As Boolean, _
                                    ByVal modi As Boolean, ByVal CanSave As BlnAction, ByVal Editing As BlnAction, _
                                    ByVal Adding As BlnAction, ByVal Clear As _Action, ByVal [New] As _Action, ByVal AuditSection As Integer, Optional ByVal AuditDescription As String = "") As Boolean
        Dim re As Boolean = False
        If CNI.Saving(addData, editData, deleteData, modi, New BlnAction(AddressOf CanSave.Invoke), New BlnAction(AddressOf Editing.Invoke), _
                      New BlnAction(AddressOf Adding.Invoke), New _Action(AddressOf Clear.Invoke), New _Action(AddressOf [New].Invoke), _
                      AuditSection, AuditDescription) Then
            re = True
            MSG.Saved()
        End If
        Return re
    End Function

    Public Shared Function GetNewCode(ByVal tblName As String, ByVal PKCol As String) As Integer
        Try
            Return (CInt(DBO.GetSingleValue("SELECT COALESCE(MAX (" & PKCol & "),0) FROM " & tblName & "")) + 1)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Shared Function GetNewCodeAndSerial(ByVal tblName As String, ByVal SelectedCol As String, ByVal BasedCol As String, ByVal BasedColValue As String, ByVal BasedColtbl As String, ByRef Code As String, ByRef Serial As String) As Integer
        Try
            Dim q As String = "SELECT COALESCE(MAX (" & SelectedCol & "),0)+1 FROM " & tblName & " WHERE " & BasedCol & "='" & BasedColValue & "'"
            Dim NewSerial As Integer = CInt(DBO.GetSingleValue(q))
            Dim q2 As String = "SELECT Prefix FROM " & BasedColtbl & " WHERE Code='" & BasedColValue & "'"
            Dim Prefix As String = Convert.ToString(DBO.GetSingleValue(q2))

            Serial = NewSerial
            Code = Prefix & NewSerial

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    'Public Shared Function GetNewCodeAndSerial(ByVal tblName As String, ByRef txtCode As XamTextEditor, ByRef txtSerial As XamTextEditor) As Integer
    '    Try
    '        Dim q As String = "SELECT COALESCE(MAX (Serial),0)+1 FROM " & tblName & " WHERE StoreCode='" & 1 & "'"
    '        Dim NewSerial As Integer = CInt(DBO.GetSingleValue(q))
    '        Dim q2 As String = "SELECT Prefix FROM D_Store WHERE Code='" & 1 & "'"
    '        Dim Prefix As String = Convert.ToString(DBO.GetSingleValue(q2))

    '        txtSerial.Value = NewSerial
    '        txtCode.Value = Prefix & NewSerial

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Function

    'Public Shared Function GetNewCodeAndSerial(ByVal tblName As String, ByVal SelectedCol As String, ByVal BasedCol As String, ByVal BasedColValue As String, ByVal BasedColtbl As String, ByRef Code As String, ByRef Serial As Integer) As Integer
    '    Try
    '        Dim q As String = "SELECT COALESCE(MAX (" & SelectedCol & "),0)+1 FROM " & tblName & " WHERE " & BasedCol & "='" & BasedColValue & "'"
    '        Dim NewSerial As Integer = DBO.GetSingleValue(q)
    '        Dim q2 As String = "SELECT Prefix FROM D_Store WHERE Code='" & BasedColValue & "'"
    '        Dim Prefix As String = Convert.ToString(DBO.GetSingleValue(q2))

    '        Serial = NewSerial
    '        Code = Prefix & NewSerial

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Function

    'Public Shared Function GetNewCodeAndSerial(ByVal tblName As String, ByRef Code As String, ByRef Serial As Integer) As Integer
    '    Try
    '        Dim q As String = "SELECT COALESCE(MAX (Serial),0)+1 FROM " & tblName & " WHERE StoreCode='" & 1 & "'"
    '        Dim NewSerial As Integer = CInt(DBO.GetSingleValue(q))
    '        Dim q2 As String = "SELECT Prefix FROM D_Store WHERE Code='" & 1 & "'"
    '        Dim Prefix As String = Convert.ToString(DBO.GetSingleValue(q2))

    '        Serial = NewSerial
    '        Code = Prefix & NewSerial

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Function

    Public Shared Function isExsisting(ByVal tblName As String, ByRef Code As String, ByRef Serial As Integer) As Integer
        Try
            'Dim q2 As String = "SELECT Prefix FROM D_Store WHERE Code='" & 1 & "'"
            'Dim Prefix As String = Convert.ToString(DBO.GetSingleValue(q2))

            'Serial = NewSerial
            'Code = Prefix & NewSerial

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    'Public Shared Function LoadGrid(ByRef grid As XamDataGrid, ByRef DT As DataTable, ByVal tblName As String, ByVal PKCol As String) As Boolean
    '    Dim Result As Boolean = False
    '    Try
    '        If LoadGrid(grid, DT, tblName) Then
    '            Return True
    '        Else
    '            Return False
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Function

    Public Shared Function LoadGrid(ByRef grid As UltraGrid, ByRef DT As DataTable, ByVal tblName As String) As Boolean
        Try
            DT = DBO.ReturnDataTableFromTable(tblName)
            grid.DataSource = DT.DefaultView
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Shared Function LoadGrid(ByRef grid As UltraGrid, ByRef DT As DataTable, ByVal tblName As String, ByVal FKName As String, ByVal FKValue As String) As Boolean
        Try
            DT = DBO.ReturnDataTableFromTable(tblName, FKName, FKValue)
            grid.DataSource = DT.DefaultView
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Shared Function LoadGridSQL(ByRef grid As UltraGrid, ByRef DT As DataTable, ByVal SelectSQL As String) As Boolean
        Try
            DT = DBO.ReturnDataTableFromSQL(SelectSQL)
            grid.DataSource = DT.DefaultView
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    'Public Shared Function BindCol(ByRef grid As UltraGrid, ByVal ColNam As String, ByVal tblName As String, Optional ByVal FK_Name As String = "", Optional ByVal FK_Value As String = "") As Boolean
    '    Try
    '        'Dim dt As New DataTable
    '        'dt = DBO.ReturnDataTableFromTable(tblName)

    '        'Dim Provider As ComboBoxItemsProvider = New ComboBoxItemsProvider()
    '        'For i As Int32 = 0 To dt.Rows.Count - 1
    '        '    Provider.Items.Add(New ComboBoxDataItem(i, "Item " + i.ToString()))
    '        'Next
    '        'Dim Drop As New XamComboEditor
    '        'Drop.ValueType = GetType(XamComboEditor)
    '        'Drop.ItemsProvider = Provider

    '        Dim cmb As New XamComboEditor

    '        If FK_Name = "" Then FillDrop(cmb, "NameEn", "Code", tblName)
    '        If FK_Name <> "" Then FillDropFK(cmb, "NameEn", "Code", tblName, FK_Name, FK_Value)

    '        Dim styl As Style = New Style(GetType(XamComboEditor))
    '        styl.Setters.Add(New Setter(XamComboEditor.ItemsProviderProperty, cmb.ItemsProvider))
    '        grid.FieldLayouts(0).Fields(ColNam).Settings.EditorStyle = styl
    '        grid.FieldLayouts(0).Fields(ColNam).Settings.EditorType = GetType(XamComboEditor)

    '        'If FK_Name <> "" Then grid.FieldLayouts(0).Fields(FK_Name).Visibility = Visibility.Hidden


    '    Catch ex As Exception

    '    End Try

    'End Function

    Public Shared Function SaveGrid(ByRef grid As UltraGrid, ByRef DT As DataTable, ByVal tblName As String, ByVal PKCol As String) As Boolean
        Try
            If SetCodes(grid, tblName, PKCol) Then
                If DBO.UpdateDataTable(tblName, DT) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Shared Function SetCodes(ByRef grid As UltraGrid, ByVal tblName As String, ByVal PKCol As String) As Boolean
        Try
            Dim NewCode = GetNewCode(tblName, PKCol)
            Dim Row As UltraGridRow
            For Each Row In grid.Rows
                If IsDBNull(Row.Cells(PKCol).Value) Or IsNothing(Row.Cells(PKCol).Value) Then
                    Row.Cells(PKCol).Value = NewCode
                    Row.Update()
                    NewCode += 1
                End If
            Next
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Shared Function CheckCivilID(ByVal cid As String, ByVal eid As String) As Boolean
        Try

        Catch ex As Exception

        End Try

    End Function

    Public Shared Function ValidGrid(ByRef grid As UltraGrid, Optional ByVal Col1 As String = Nothing, Optional ByVal Col2 As String = Nothing, Optional ByVal Col3 As String = Nothing, Optional ByVal Col4 As String = Nothing, Optional ByVal Col5 As String = Nothing, Optional ByVal Col6 As String = Nothing, Optional ByVal Col7 As String = Nothing, Optional ByVal Col8 As String = Nothing, Optional ByVal Col9 As String = Nothing, Optional ByVal Col10 As String = Nothing) As Boolean
        Try

            Dim Row As UltraGridRow

            For Each Row In grid.Rows
                If Col1 <> Nothing Then
                    If IsDBNull(Row.Cells(Col1).Value) Or IsNothing(Row.Cells(Col1).Value) Then Return False
                    If Row.Cells(Col1).Value = Nothing Then Return False
                End If
                If Col2 <> Nothing Then
                    If IsDBNull(Row.Cells(Col2).Value) Or IsNothing(Row.Cells(Col2).Value) Then Return False
                    If Row.Cells(Col2).Value = Nothing Then Return False
                End If
                If Col3 <> Nothing Then
                    If IsDBNull(Row.Cells(Col3).Value) Or IsNothing(Row.Cells(Col3).Value) Then Return False
                    If Row.Cells(Col3).Value = Nothing Then Return False
                End If
                If Col4 <> Nothing Then
                    If IsDBNull(Row.Cells(Col4).Value) Or IsNothing(Row.Cells(Col4).Value) Then Return False
                    If Row.Cells(Col4).Value = Nothing Then Return False
                End If
                If Col5 <> Nothing Then
                    If IsDBNull(Row.Cells(Col5).Value) Or IsNothing(Row.Cells(Col5).Value) Then Return False
                    If Row.Cells(Col5).Value = Nothing Then Return False
                End If
                If Col6 <> Nothing Then
                    If IsDBNull(Row.Cells(Col6).Value) Or IsNothing(Row.Cells(Col6).Value) Then Return False
                    If Row.Cells(Col6).Value = Nothing Then Return False
                End If
                If Col7 <> Nothing Then
                    If IsDBNull(Row.Cells(Col7).Value) Or IsNothing(Row.Cells(Col7).Value) Then Return False
                    If Row.Cells(Col7).Value = Nothing Then Return False
                End If
                If Col8 <> Nothing Then
                    If IsDBNull(Row.Cells(Col8).Value) Or IsNothing(Row.Cells(Col8).Value) Then Return False
                    If Row.Cells(Col8).Value = Nothing Then Return False
                End If
                If Col9 <> Nothing Then
                    If IsDBNull(Row.Cells(Col9).Value) Or IsNothing(Row.Cells(Col9).Value) Then Return False
                    If Row.Cells(Col9).Value = Nothing Then Return False
                End If
                If Col10 <> Nothing Then
                    If IsDBNull(Row.Cells(Col10).Value) Or IsNothing(Row.Cells(Col10).Value) Then Return False
                    If Row.Cells(Col10).Value = Nothing Then Return False
                End If
            Next

            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

#Region "Unused"
    '	public static bool Saving(string strTable,DevExpress.XtraEditors.TextEdit txtCode,bool addData,bool editData,bool deleteData,bool modi
    '		,BlnAction CanSave,BlnAction Add,BlnAction Edit,Action New)
    '	{
    '		bool re = false;
    '		bool watchOnly = false;
    '		bool saveData = false;
    '		if(!addData && !editData && !deleteData)
    '		{
    '			watchOnly = true;
    '		}
    '		if(addData || editData)
    '		{
    '			saveData = true;
    '		}
    '		//--------------------------------------------------------------
    '		if(!watchOnly)
    '		{
    '			if(saveData)
    '			{
    '				if(modi)
    '				{
    '					if(editData)
    '					{
    '						if(CanSave())
    '						{
    '							if(Editing(Edit,New))
    '							{
    '								re = true;
    '							}
    '						}
    '					}
    '					else
    '					{
    '						MSG.InfoOk("لا يمكنك تعديل بيانات");
    '					}
    '				}
    '				else
    '				{
    '					if(addData)
    '					{
    '						if(CanSave())
    '						{
    '							if(Adding(strTable,txtCode,Add,New))
    '							{
    '								re = true;
    '							}
    '						}
    '					}
    '					else
    '					{
    '						MSG.InfoOk("لا يمكنك اضافة بيان جديد");
    '					}
    '				}
    '			}
    '			else
    '			{
    '				MSG.InfoOk("لا يمكنك التعديل او الاضافه فى البيانات");
    '			}
    '		}
    '		else
    '		{
    '			MSG.InfoOk("لا يمكنك الحفظ يمكنك الاستعراض فقط");
    '		}
    '		return re;
    '	}
    '	
    '	public static bool Saving(string strTable,DevExpress.XtraEditors.TextEdit txtCode,bool addData,bool editData,bool deleteData,bool modi
    '		,BlnAction CanSave,BlnAction Add,BlnAction Editing,Action New)
    '	{
    '		bool re = false;
    '		bool watchOnly = false;
    '		bool saveData = false;
    '		if(!addData && !editData && !deleteData)
    '		{
    '			watchOnly = true;
    '		}
    '		if(addData || editData)
    '		{
    '			saveData = true;
    '		}
    '		//--------------------------------------------------------------
    '		if(!watchOnly)
    '		{
    '			if(saveData)
    '			{
    '				if(modi)
    '				{
    '					if(editData)
    '					{
    '						if(CanSave())
    '						{
    '							if(Editing())
    '							{
    '								re = true;
    '							}
    '						}
    '					}
    '					else
    '					{
    '						MSG.InfoOk("لا يمكنك تعديل بيانات");
    '					}
    '				}
    '				else
    '				{
    '					if(addData)
    '					{
    '						if(CanSave())
    '						{
    '							if(Adding(strTable,txtCode,Add,New))
    '							{
    '								re = true;
    '							}
    '						}
    '					}
    '					else
    '					{
    '						MSG.InfoOk("لا يمكنك اضافة بيان جديد");
    '					}
    '				}
    '			}
    '			else
    '			{
    '				MSG.InfoOk("لا يمكنك التعديل او الاضافه فى البيانات");
    '			}
    '		}
    '		else
    '		{
    '			MSG.InfoOk("لا يمكنك الحفظ يمكنك الاستعراض فقط");
    '		}
    '		return re;
    '	}
    '	
#End Region

#End Region

End Class
