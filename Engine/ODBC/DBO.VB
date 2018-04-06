
Imports System
Imports System.Data
Imports System.Collections
Imports System.Windows.Forms
Imports System.Data.Odbc
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public MustInherit Class DBO

#Region "Fields"

    Private Shared DSNName As String = "Customs"
    Private Shared m_serverName As String = "" ' DBSTNG.ServerName
    Private Shared m_dbName As String = "customs" 'DBSTNG.DBName
    Private Shared userID As String = "customs" 'DBSTNG.UserID
    Private Shared password As String = "customs" 'DBSTNG.Password
    Private Shared masterDB As String = "" 'DBSTNG.MasterDB
    Private Shared con As OdbcConnection
    Private Shared cmd As OdbcCommand
    Private Shared trans As OdbcTransaction
    Private Shared m_errorMSG As String = ""

#End Region

#Region "Properties"

    Public Shared Property ServerName() As String
        Get
            Return ""
        End Get
        Set(ByVal value As String)
            m_serverName = value
        End Set
    End Property

    Public Shared Property DBName() As String
        Get
            Return m_dbName
        End Get
        Set(ByVal value As String)
            m_dbName = value
        End Set
    End Property

    Public Shared Property Connection() As OdbcConnection
        Get
            Return con
        End Get
        Set(ByVal value As OdbcConnection)
            con = DirectCast(value, OdbcConnection)
        End Set
    End Property

    Public Shared Property Command() As OdbcCommand
        Get
            Return cmd
        End Get
        Set(ByVal value As OdbcCommand)
            cmd = DirectCast(value, OdbcCommand)
        End Set
    End Property

    Public Shared Property Transaction() As OdbcTransaction
        Get
            Return trans
        End Get
        Set(ByVal value As OdbcTransaction)
            trans = DirectCast(value, OdbcTransaction)
        End Set
    End Property

    Public Shared Property ErrorMSG() As String
        Get
            Return m_errorMSG
        End Get
        Set(ByVal value As String)
            m_errorMSG = value
        End Set
    End Property


#End Region

#Region "Methods"

#Region "Infra"

    Public Shared Function Connect(ByVal DSNName As String, ByVal UserID As String, ByVal Password As String) As Boolean
        Dim re As Boolean = False
        If STADBO.Connect(DSNName, UserID, Password, con, Command, trans, m_errorMSG) Then
            AddHandler con.StateChange, AddressOf con_StateChange
            AddHandler con.InfoMessage, AddressOf con_InfoMessage
            AddHandler con.Disposed, AddressOf con_Disposed
            re = True
        End If
        Return re
    End Function

    'Public Shared Function Connect(ByVal serverName As String, ByVal dbName As String, ByVal userID As String, ByVal password As String, ByVal DsnName As String) As Boolean
    '    Dim re As Boolean = False
    '    If STADBO.Connect(serverName, dbName, userID, password, con, cmd, _
    '     trans, m_errorMSG, DsnName) Then
    '        AddHandler con.StateChange, AddressOf con_StateChange
    '        AddHandler con.InfoMessage, AddressOf con_InfoMessage
    '        AddHandler con.Disposed, AddressOf con_Disposed
    '        re = True
    '    End If
    '    Return re
    'End Function

    Public Shared Function Connect() As Boolean
        Return Connect(DSNName, userID, password)
    End Function

    'Public Shared Function Connect(ByVal DsnName As String, ByVal userID As String, ByVal password As String) As Boolean
    '    Return Connect(m_serverName, m_dbName, DsnName)
    'End Function

    'Public Shared Function ConnectSecure() As Boolean
    '    Return Connect(m_serverName, m_dbName, userID, password, DSNName)
    'End Function

    Public Shared Function ConnectMaster() As Boolean
        Return Connect(m_serverName, masterDB, DSNName)
    End Function

    Public Shared Sub OpenIfClosed()
        STADBO.OpenIfClosed(con)
    End Sub

    Public Shared Sub CloseIfOpened()
        STADBO.CloseIfOpened(con)
    End Sub

    Public Shared Function GetSingleValue(ByVal query As String) As Object
        Return STADBO.GetSingleValue(con, cmd, query)
    End Function

    Public Shared Function GetListValues(ByVal query As String, ByVal Column As String) As Object()
        Return STADBO.GetListValues(con, cmd, query, Column)
    End Function

    'Public Shared Function GetListValues(ByVal query As String, ByVal strValueMember As String, ByVal strDisplayMember As String) As ValueDisplayMember()
    '    Return STADBO.GetListValues(con, cmd, query, strValueMember, strDisplayMember)
    'End Function

    Public Shared Function GetMenuValues(ByVal query As String) As MenuItem()
        Return STADBO.GetMenuValues(con, query)
    End Function

    Public Shared Function ReturnDataTable(ByVal SelectQuery As String) As DataTable
        Return STADBO.ReturnDataTable(con, cmd, SelectQuery)
    End Function

    Public Shared Function ReturnDataTableFromTable(ByVal tblName As String) As DataTable
        Return STADBO.ReturnDataTableFromTable(con, cmd, tblName)
    End Function

    Public Shared Function ReturnDataTableFromTable(ByVal tblName As String, ByVal FKName As String, ByVal FKValue As Integer) As DataTable
        Return STADBO.ReturnDataTableFromTable(con, cmd, tblName, FKName, FKValue)
    End Function

    Public Shared Function ActionQuery(ByVal _actionQuery As String) As Boolean
        Return STADBO.ActionQuery(con, cmd, _actionQuery)
    End Function

    Public Shared Function ExecuteSP(ByVal StoredProcedureName As String, ByVal ParaList As ArrayList) As Boolean
        Return STADBO.ExecuteSP(con, cmd, StoredProcedureName, ParaList)
    End Function

    Public Shared Function ExecuteSP_ReturnInteger(ByVal StoredProcedureName As String, ByVal ParaList As ArrayList) As Integer
        Return STADBO.ExecuteSP_ReturnInteger(con, cmd, StoredProcedureName, ParaList)
    End Function

    Public Shared Function ExecuteSP_ReturnString(ByVal StoredProcedureName As String, ByVal ParaList As ArrayList) As String
        Return STADBO.ExecuteSP_ReturnString(con, cmd, StoredProcedureName, ParaList)
    End Function

    Public Shared Function ExecuteSP_ReturnSingleValue(ByVal StoredProcedureName As String, ByVal ParaList As ArrayList) As Object
        Return STADBO.ExecuteSP_ReturnSingleValue(con, cmd, StoredProcedureName, ParaList)
    End Function

    Public Shared Function ExecuteSP_ReturnDateTime(ByVal StoredProcedureName As String, ByVal ParaList As ArrayList) As DateTime
        Return STADBO.ExecuteSP_ReturnDateTime(con, cmd, StoredProcedureName, ParaList)
    End Function

    Public Shared Function ExecuteSP_ReturnDataTable(ByVal StoredProcedureName As String, ByVal ParaList As ArrayList) As DataTable
        Return STADBO.ExecuteSP_ReturnDataTable(con, cmd, StoredProcedureName, ParaList)
    End Function

    Public Shared Function ExecuteSP_ReturnDataSet(ByVal StoredProcedureName As String, ByVal ParaList As ArrayList) As DataSet
        Return STADBO.ExecuteSP_ReturnDataSet(con, cmd, StoredProcedureName, ParaList)
    End Function

    Public Shared Function UpdateDataTable(ByVal TableName As String, ByVal DT As DataTable) As Boolean
        Return STADBO.UpdateDataTable(con, TableName, DT)
    End Function

    Public Shared Sub BeginTransaction()
        STADBO.BeginTransaction(con, trans, cmd)
    End Sub

    Public Shared Sub Commit()
        STADBO.Commit(trans)
    End Sub

    Public Shared Sub Rollback()
        STADBO.Rollback(trans)
    End Sub


#End Region

#Region "Usage"

    Public Shared Function GetSingleString(ByVal query As String, ByVal nullRe As String) As String
        Return STADBO.GetSingleString(con, cmd, query, nullRe)
    End Function

    Public Shared Sub LoadComboBoxEx(ByVal query As String, ByVal combo As Infragistics.Win.UltraWinGrid.UltraCombo, ByVal strValueMember As String, ByVal strDisplayMember As String)
        STADBO.LoadComboBoxEx(con, cmd, query, combo, strValueMember, strDisplayMember)
    End Sub

    Public Shared Sub LoadComboBox(ByVal query As String, ByVal combo As Infragistics.Win.UltraWinGrid.UltraCombo, ByVal column As String)
        STADBO.LoadComboBox(con, cmd, query, combo, column)
    End Sub

    Public Shared Sub LoadComboBox(ByVal tblName As String, ByRef combo As Infragistics.Win.UltraWinGrid.UltraCombo, ByVal DisplayMember As String, ByVal ValueMember As String, Optional ByVal HiddenMember1 As String = "", Optional ByVal HiddenMember2 As String = "", Optional ByVal HiddenMember3 As String = "")
        STADBO.LoadComboBox(con, cmd, tblName, combo, "NameAr", "Code", HiddenMember1, HiddenMember2, HiddenMember3)
    End Sub

    Public Shared Sub LoadComboBox(ByVal query As String, ByVal combo As System.Windows.Forms.ComboBox, ByVal strDisplayMember As String, ByVal strValueMember As String)
        STADBO.LoadComboBox(con, cmd, query, combo, strDisplayMember, strValueMember)
    End Sub

    'Public Shared Sub LoadListBox(query As String, listBox As DevExpress.XtraEditors.ListBoxControl, column As String)
    '	STADBO.LoadListBox(con, cmd, query, listBox, column)
    'End Sub

    'Public Shared Sub LoadCheckedListBox(query As String, chkList As DevExpress.XtraEditors.CheckedListBoxControl, column As String)
    '	STADBO.LoadCheckedListBox(con, cmd, query, chkList, column)
    'End Sub

    Public Shared Sub LoadTreeNode(ByVal query As String, ByVal tnc As TreeNodeCollection, ByVal column As String)
        STADBO.LoadTreeNode(con, query, tnc, column)
    End Sub

    Public Shared Sub LoadMenu(ByVal query As String, ByVal menu As Menu)
        STADBO.LoadMenu(con, query, menu)
    End Sub

    Public Shared Sub LoadDataGrid(ByVal SelectQuery As String, ByVal dataGrid As DataGrid)
        STADBO.LoadDataGrid(con, cmd, SelectQuery, dataGrid)
    End Sub

    Public Shared Sub LoadDataGrid(ByVal tblName As String, ByRef dataGrid As UltraGrid)
        STADBO.LoadDataGrid(con, cmd, tblName, dataGrid)
    End Sub

    Public Shared Function ReturnDataTableFromSQL(ByVal SelectSQL As String) As DataTable
        Return STADBO.ReturnDataTableFromSQL(con, cmd, SelectSQL)
    End Function

    Public Shared Function FindRow(ByVal tbl As DataTable, ByVal byColumn As String, ByVal Value As String) As DataRow
        Return STADBO.FindRow(tbl, byColumn, Value)
    End Function

    Public Shared Sub FillText(ByVal query As String, ByVal control As Control)
        STADBO.FillText(con, cmd, query, control)
    End Sub

    Public Shared Sub FillText(ByVal query As String, ByVal control As Control, ByVal rowNo As Integer, ByVal Column As String)
        STADBO.FillText(con, cmd, query, control, rowNo, Column)
    End Sub

    Public Shared Function IsStored(ByVal fromTable As String, ByVal code As String, ByVal name As String) As Boolean
        Return STADBO.IsStored(con, cmd, fromTable, code, name)
    End Function

    Public Shared Function IsStored(ByVal fromTable As String, ByVal code As String, ByVal name As String, ByVal condition As String) As Boolean
        Return STADBO.IsStored(con, cmd, fromTable, code, name, condition)
    End Function

    Public Shared Function IsStored(ByVal fromTable As String, ByVal field As String, ByVal code As String, ByVal name As String, ByVal condition As String) As Boolean
        Return STADBO.IsStored(con, cmd, fromTable, field, code, name, _
         condition)
    End Function

    Public Shared Function HasRows(ByVal table As String) As Boolean
        Return STADBO.HasRows(con, cmd, table)
    End Function

    Public Shared Function HasRows(ByVal table As String, ByVal cond As String) As Boolean
        Return STADBO.HasRows(con, cmd, table, cond)
    End Function

    Public Shared Function HasRows(ByVal table As String, ByVal field As String, ByVal val As String) As Boolean
        Return STADBO.HasRows(con, cmd, table, field, val)
    End Function



#End Region

#Region "Tools"

    Public Shared Function Exists(ByVal dbName As String) As Boolean
        Return STADBO.Exists(con, cmd, dbName)
    End Function

    Public Shared Function Exists() As Boolean
        Return Exists(m_dbName)
    End Function


    Public Shared Function Create(ByVal dbName As String) As Boolean
        Return STADBO.Create(con, cmd, dbName)
    End Function

    Public Shared Function Create() As Boolean
        Return Create(m_dbName)
    End Function

    Public Shared Function BackUp(ByVal dbName As String, ByVal fileName As String) As Boolean
        Return STADBO.BackUp(con, cmd, dbName, fileName, m_errorMSG)
    End Function

    Public Shared Function BackUp(ByVal fileName As String) As Boolean
        Return BackUp(m_dbName, fileName)
    End Function

    Public Shared Function Restore(ByVal dbName As String, ByVal fileName As String) As Boolean
        Return STADBO.Restore(con, cmd, dbName, fileName, m_errorMSG)
    End Function

    Public Shared Function Restore(ByVal fileName As String) As Boolean
        Return Restore(m_dbName, fileName)
    End Function

    Public Shared Function Attach(ByVal dbName As String, ByVal dfn As String, ByVal lfn As String) As Boolean
        Return STADBO.Attach(con, cmd, dbName, dfn, lfn, m_errorMSG)
    End Function

    Public Shared Function Attach(ByVal dfn As String, ByVal lfn As String) As Boolean
        Return Attach(m_dbName, dfn, lfn)
    End Function

    Public Shared Function Detach(ByVal dbName As String) As Boolean
        Return STADBO.Detach(con, cmd, dbName, m_errorMSG)
    End Function

    Public Shared Function Detach() As Boolean
        Return Detach(m_dbName)
    End Function

    Public Shared Function Relocate(ByVal dbName As String, ByVal newPath As String) As Boolean
        Return STADBO.Relocate(con, trans, cmd, dbName, newPath, m_errorMSG)
    End Function

    Public Shared Function Relocate(ByVal newPath As String) As Boolean
        Return Relocate(m_dbName, newPath)
    End Function

    Public Shared Function DatabaseBackups(ByVal PATH As String) As Boolean
        Return STADBO.DatabaseBackups(PATH)
    End Function


#End Region

#End Region

#Region "Events"

    Private Shared Sub con_StateChange(ByVal sender As Object, ByVal e As StateChangeEventArgs)
        'MSG.InfoOk(e.CurrentState.ToString());
    End Sub


    Private Shared Sub con_InfoMessage(ByVal sender As Object, ByVal e As OdbcInfoMessageEventArgs)
        'MSG.InfoOk(e.Message);
    End Sub

    Private Shared Sub con_Disposed(ByVal sender As Object, ByVal e As EventArgs)
        'MSG.InfoOk("Disposed");
    End Sub

#End Region

End Class