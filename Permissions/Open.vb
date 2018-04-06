
Public MustInherit Class Open

#Region "Fields"

    Public Shared blnForm As Boolean = True
    Public Shared blnCodeName As Boolean = True
    Public Shared blnCodeNamePlus As Boolean = True

#End Region

#Region "Methods"

    Public Shared Function OpenForm(ByVal frm As IDataEntry, Optional ByVal TablenName As String = "") As Boolean
        'Return frm
        'Dim ClsPermission As New Permission(frm, FormCode)
        blnForm = True 'ClsPermission.CanOpen

        If TablenName = "" Then
        Else
            frm.tblName = TablenName
        End If
        If blnForm Then
            DirectCast(frm, Form).ShowDialog()
            'DirectCast(frm, Form).MdiParent = frmMainIns
            'DirectCast(frm, Form).Show()
            Return True
        Else
            'frm.Dispose()
            Return False
        End If
    End Function

    Public Shared Function OpenFormShow(ByVal frm As IDataEntry, Optional ByVal TablenName As String = "") As Boolean
        'Return frm
        'Dim ClsPermission As New Permission(frm, FormCode)
        blnForm = True ' ClsPermission.CanOpen

        If TablenName = "" Then
        Else
            frm.tblName = TablenName
        End If
        If blnForm Then
            DirectCast(frm, Form).Show()
            'DirectCast(frm, Form).MdiParent = frmMainIns
            'DirectCast(frm, Form).Show()
            Return True
        Else
            'frm.Dispose()
            Return False
        End If
    End Function

    Public Shared Function OpenAccountList(ByVal frm As IDataEntry, Optional ByVal TablenName As String = "") As Boolean
        'Return frm
        'Dim ClsPermission As New Permission(frm, FormCode)
        blnForm = True ' ClsPermission.CanOpen

        If TablenName = "" Then
        Else
            frm.tblName = TablenName
        End If
        If blnForm Then
            DirectCast(frm, Form).Show()
            'DirectCast(frm, Form).MdiParent = frmMainIns
            'DirectCast(frm, Form).Show()
            Return True
        Else
            'frm.Dispose()
            Return False
        End If
    End Function

    Public Shared Function OpenFormAndReturnForm(ByVal frm As IDataEntry) As Form
        'Return frm
        'Dim ClsPermission As New Permission(frm, FormCode)
        blnForm = True 'ClsPermission.CanOpen
        If blnForm Then
            Return DirectCast(frm, Form)
        Else
            'frm.Dispose()
            Return Nothing
        End If
    End Function

    'Public Shared Function OpenFormSendVariable(ByVal frm As IDataEntry, ByVal FormCode As Integer, Optional ByVal TablenName As String = "") As Boolean
    '    'Return frm
    '    Dim ClsPermission As New Permission(frm, FormCode)
    '    blnForm = ClsPermission.CanOpen
    '    frm.WatchOnly = ClsPermission.WatchOnly
    '    frm.SaveData = ClsPermission.SaveData
    '    frm.AddData = ClsPermission.AddData
    '    frm.EditData = ClsPermission.EditData
    '    frm.DeleteData = ClsPermission.DeleteData
    '    frm.SearchData = ClsPermission.SearchData
    '    frm.PrintData = ClsPermission.PrintData
    '    frm.ExportData = ClsPermission.ExportData

    '    If TablenName = "" Then
    '    Else
    '        frm.tblName = TablenName
    '        frm.FormCode = FormCode

    '    End If
    '    If blnForm Then
    '        DirectCast(frm, Form).ShowDialog()
    '        'DirectCast(frm, Form).MdiParent = frmMainIns
    '        'DirectCast(frm, Form).Show()
    '        Return True
    '    Else
    '        'frm.Dispose()
    '        Return False
    '    End If
    'End Function
    'Public Shared Function CanOpenForm(ByVal frm As IDataEntry) As Boolean
    '    Dim permission As New Permission(frm)
    '    blnForm = permission.CanOpen
    '    frm.WatchOnly = permission.WatchOnly
    '    frm.SaveData = permission.SaveData
    '    frm.AddData = permission.AddData
    '    frm.EditData = permission.EditData
    '    frm.DeleteData = permission.DeleteData
    '    If blnForm Then
    '        'Application.Current.MainWindow.
    '        'Dim nav As NavigationService
    '        'nav.Navigate(New System.Uri("Database\TestSupplier.xaml", UriKind.RelativeOrAbsolute))
    '        DirectCast((Application.Current.MainWindow), NavigationWindow).Navigate(New System.Uri("Database\TestSupplier.xaml", UriKind.RelativeOrAbsolute))
    '        'New CurtainUI(frm).Down()
    '        Return True
    '    Else
    '        'frm.Dispose()
    '        Return False
    '    End If
    'End Function


    'Public Shared Function OpenForm(ByVal frm As IDataEntry, ByVal bln As Boolean) As IDataEntry
    '    Dim permission As New Permission(frm, bln)
    '    blnForm = permission.CanOpen
    '    frm.WatchOnly = permission.WatchOnly
    '    frm.SaveData = permission.SaveData
    '    frm.AddData = permission.AddData
    '    frm.EditData = permission.EditData
    '    frm.DeleteData = permission.DeleteData
    '    If blnForm Then
    '        Return frm
    '    Else
    '        'frm.Dispose()
    '        Return Nothing
    '    End If
    'End Function

    'Public Shared Function CanOpenForm(ByVal frm As IDataEntry, ByVal bln As Boolean) As Boolean
    '    Dim permission As New Permission(frm, bln)
    '    blnForm = permission.CanOpen
    '    frm.WatchOnly = permission.WatchOnly
    '    frm.SaveData = permission.SaveData
    '    frm.AddData = permission.AddData
    '    frm.EditData = permission.EditData
    '    frm.DeleteData = permission.DeleteData
    '    'If blnForm Then
    '    'New CurtainUI(frm).Down()
    '    '        Return True
    '    '    Else
    '    '        frm.Dispose()
    '    '        Return False
    '    '    End If
    'End Function


    'Public Shared Function CNForm(ByVal name As String, ByVal title As String, ByVal table As String, ByVal isCodeVisible As Boolean) As ALMASAR.CNUI
    '    Dim frm As New ALMASAR.CNUI(title, table, isCodeVisible)
    '    frm.Name = name
    '    Return DirectCast(OpenForm(frm), ALMASAR.CNUI)
    'End Function

    'Public Shared Function CN(ByVal name As String, ByVal title As String, ByVal table As String, ByVal isCodeVisible As Boolean) As Boolean
    '    Dim frm As New ALMASAR.CNUI(title, table, isCodeVisible)
    '    frm.Name = name
    '    Return CanOpenForm(frm)
    'End Function

    'Public Shared Function CNForm(ByVal name As String, ByVal title As String, ByVal table As String) As ALMASAR.CNUI
    '    Return CNForm(name, title, table, False)
    'End Function

    'Public Shared Function CN(ByVal name As String, ByVal title As String, ByVal table As String) As Boolean
    '    Return CN(name, title, table, False)
    'End Function


    'public static ALMASAR.CountryCNUI CountryCNForm(string title, string table)
    '{
    '    ALMASAR.CountryCNUI frm = new ALMASAR.CountryCNUI(title, table);
    '    return (ALMASAR.CountryCNUI)OpenForm(frm);
    '}

    'public static bool CountryCN(string title, string table)
    '{
    '    ALMASAR.CountryCNUI frm = new ALMASAR.CountryCNUI(title, table);
    '    return CanOpenForm(frm);
    '}


    Public Shared Function CheckUserPermition(ByVal frm As IDataEntry, Optional ByVal TablenName As String = "") As Boolean
        'Return frm
        'Dim ClsPermission As New Permission(frm, FormCode)
        blnForm = True 'ClsPermission.CanOpen
        'frm.WatchOnly = ClsPermission.WatchOnly
        'frm.SaveData = ClsPermission.SaveData
        'frm.AddData = ClsPermission.AddData
        'frm.EditData = ClsPermission.EditData
        'frm.DeleteData = ClsPermission.DeleteData
        'frm.SearchData = ClsPermission.SearchData
        'frm.PrintData = ClsPermission.PrintData
        'frm.ExportData = ClsPermission.ExportData

        If TablenName = "" Then
        Else
            frm.tblName = TablenName
        End If
        If blnForm Then
            Return True
        Else
            'frm.Dispose()
            Return False
        End If
    End Function

    Public Shared Function CanOpenForm(ByVal FormCode As Integer, ByVal UserCode As Integer) As Boolean
        Try
            If UserClass.IsAdmin Then
                Return True
            Else
                Return DBO.GetSingleValue("Select canOpen from P_SystemPermission where SystemForm = " & FormCode & " and UserCode =" & UserCode)
            End If

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function
#End Region

End Class
