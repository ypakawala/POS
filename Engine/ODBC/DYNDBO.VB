
#Region "Copyright(c)"

'Copyright (c) 2006 CONCEPT Corporation. All rigths reserved.

#End Region

#Region "Using Directives"

Imports System
Imports System.Data
Imports System.Collections
Imports System.Windows.Forms
'Imports System.Data.SqlClient
Imports System.Data.Odbc
'Imports DevExpress.XtraEditors

#End Region

Public Class DYNDBO

#Region "Privates"

    'Private m_serverName As String = DBSTNG.ServerName
    'Private m_dbName As String = DBSTNG.DBName
    'Private userID As String = DBSTNG.UserID
    'Private password As String = DBSTNG.Password
    'Private masterDB As String = DBSTNG.MasterDB
    'Private con As OdbcConnection
    'Private cmd As OdbcCommand
    'Private trans As OdbcTransaction
    'Private m_errorMSG As String = ""
    'Private Shared DSNName As String = ""


    Private m_serverName As String = "" ' DBSTNG.ServerName
    Private m_dbName As String = "" 'DBSTNG.DBName
    Private userID As String = "" 'DBSTNG.UserID
    Private password As String = "" 'DBSTNG.Password
    Private masterDB As String = "" 'DBSTNG.MasterDB
    Private con As OdbcConnection
    Private cmd As OdbcCommand
    Private trans As OdbcTransaction
    Private m_errorMSG As String = ""
    Private Shared DSNName As String = ""

#End Region

#Region "Properties"

    Public Property ServerName() As String
        Get
            Return ""
        End Get
        Set(ByVal value As String)
            m_serverName = value
        End Set
    End Property

    Public Property DBName() As String
        Get
            Return m_dbName
        End Get
        Set(ByVal value As String)
            m_dbName = value
        End Set
    End Property

    Public Property Connection() As OdbcConnection
        Get
            Return con
        End Get
        Set(ByVal value As OdbcConnection)
            con = DirectCast(value, OdbcConnection)
        End Set
    End Property

    Public Property Command() As OdbcCommand
        Get
            Return cmd
        End Get
        Set(ByVal value As OdbcCommand)
            cmd = DirectCast(value, OdbcCommand)
        End Set
    End Property

    Public Property Transaction() As OdbcTransaction
        Get
            Return trans
        End Get
        Set(ByVal value As OdbcTransaction)
            trans = DirectCast(value, OdbcTransaction)
        End Set
    End Property

    Public Property ErrorMSG() As String
        Get
            Return m_errorMSG
        End Get
        Set(ByVal value As String)
            m_errorMSG = value
        End Set
    End Property


#End Region

#Region "Constructors"

    Public Sub New()

    End Sub


#End Region

#Region "Methods"

#Region "Infra"

    'Public Function Connect(ByVal serverName As String, ByVal dbName As String, ByVal DsnName As String) As Boolean
    '    Dim re As Boolean = False
    '    If STADBO.Connect(serverName, dbName, con, cmd, trans, m_errorMSG, DsnName) Then
    '        AddHandler con.StateChange, AddressOf con_StateChange
    '        AddHandler con.InfoMessage, AddressOf con_InfoMessage
    '        AddHandler con.Disposed, AddressOf con_Disposed
    '        re = True
    '    End If
    '    Return re
    'End Function

    Public Function Connect(ByVal DsnName As String, ByVal userID As String, ByVal password As String) As Boolean
        Dim re As Boolean = False
        If STADBO.Connect(DsnName, userID, password, con, cmd, trans, m_errorMSG) Then
            AddHandler con.StateChange, AddressOf con_StateChange
            AddHandler con.InfoMessage, AddressOf con_InfoMessage
            AddHandler con.Disposed, AddressOf con_Disposed
            re = True
        End If
        Return re
    End Function

    Public Function Connect() As Boolean
        Return Connect(DSNName, userID, password)
    End Function

    'Public Function ConnectSecure() As Boolean
    '    Return Connect(m_serverName, m_dbName, userID, password, DSNName)
    'End Function

    Public Function ConnectMaster() As Boolean
        Return Connect(m_serverName, masterDB, DSNName)
    End Function

    Public Sub OpenIfClosed()
        STADBO.OpenIfClosed(con)
    End Sub

    Public Sub CloseIfOpened()
        STADBO.CloseIfOpened(con)
    End Sub

    Public Function GetSingleValue(ByVal query As String) As Object
        Return STADBO.GetSingleValue(con, cmd, query)
    End Function

    Public Function GetListValues(ByVal query As String, ByVal Column As String) As Object()
        Return STADBO.GetListValues(con, cmd, query, Column)
    End Function

    Public Function GetMenuValues(ByVal query As String) As MenuItem()
        Return STADBO.GetMenuValues(con, query)
    End Function

    Public Function ReturnDataTable(ByVal SelectQuery As String) As DataTable
        Return STADBO.ReturnDataTable(con, cmd, SelectQuery)
    End Function

    Public Function ActionQuery(ByVal _actionQuery As String) As Boolean
        Return STADBO.ActionQuery(con, cmd, _actionQuery)
    End Function

    Public Sub BeginTransaction()
        STADBO.BeginTransaction(con, trans, cmd)
    End Sub

    Public Sub Commit()
        STADBO.Commit(trans)
    End Sub

    Public Sub Rollback()
        STADBO.Rollback(trans)
    End Sub


#End Region

#Region "Usage"

    Public Function GetSingleString(ByVal query As String, ByVal nullRe As String) As String
        Return STADBO.GetSingleString(con, cmd, query, nullRe)
    End Function

    'Public Sub LoadComboBox(ByVal query As String, ByVal combo As ComboBoxEdit, ByVal column As String)
    '    STADBO.LoadComboBox(con, cmd, query, combo, column)
    'End Sub

    'Public Sub LoadListBox(ByVal query As String, ByVal listBox As ListBoxControl, ByVal column As String)
    '    STADBO.LoadListBox(con, cmd, query, listBox, column)
    'End Sub

    'Public Sub LoadCheckedListBox(ByVal query As String, ByVal chkList As CheckedListBoxControl, ByVal column As String)
    '    STADBO.LoadCheckedListBox(con, cmd, query, chkList, column)
    'End Sub

    Public Sub LoadMenu(ByVal query As String, ByVal menu As Menu)
        STADBO.LoadMenu(con, query, menu)
    End Sub

    Public Sub LoadDataGrid(ByVal SelectQuery As String, ByVal dataGrid As DataGrid)
        STADBO.LoadDataGrid(con, cmd, SelectQuery, dataGrid)
    End Sub

    Public Function FindRow(ByVal tbl As DataTable, ByVal byColumn As String, ByVal Value As String) As DataRow
        Return STADBO.FindRow(tbl, byColumn, Value)
    End Function

    Public Sub FillText(ByVal query As String, ByVal control As Control)
        STADBO.FillText(con, cmd, query, control)
    End Sub

    Public Sub FillText(ByVal query As String, ByVal control As Control, ByVal rowNo As Integer, ByVal Column As String)
        STADBO.FillText(con, cmd, query, control, rowNo, Column)
    End Sub

    Public Function IsStored(ByVal fromTable As String, ByVal code As String, ByVal name As String) As Boolean
        Return STADBO.IsStored(con, cmd, fromTable, code, name)
    End Function
    Public Function IsStored(ByVal fromTable As String, ByVal code As String, ByVal name As String, ByVal condition As String) As Boolean
        Return STADBO.IsStored(con, cmd, fromTable, code, name, condition)
    End Function

    Public Function IsStored(ByVal fromTable As String, ByVal field As String, ByVal code As String, ByVal name As String, ByVal condition As String) As Boolean
        Return STADBO.IsStored(con, cmd, fromTable, field, code, name, _
         condition)
    End Function

    Public Function HasRows(ByVal table As String) As Boolean
        Return STADBO.HasRows(con, cmd, table)
    End Function

    Public Function HasRows(ByVal table As String, ByVal field As String, ByVal val As String) As Boolean
        Return STADBO.HasRows(con, cmd, table, field, val)
    End Function


#End Region

#Region "Tools"

    Public Function Exists(ByVal dbName As String) As Boolean
        Return STADBO.Exists(con, cmd, dbName)
    End Function

    Public Function Exists() As Boolean
        Return Exists(m_dbName)
    End Function


    Public Function Create(ByVal dbName As String) As Boolean
        Return STADBO.Create(con, cmd, dbName)
    End Function

    Public Function Create() As Boolean
        Return Create(m_dbName)
    End Function


    Public Function BackUp(ByVal dbName As String, ByVal fileName As String) As Boolean
        Return STADBO.BackUp(con, cmd, dbName, fileName, m_errorMSG)
    End Function

    Public Function BackUp(ByVal fileName As String) As Boolean
        Return BackUp(m_dbName, fileName)
    End Function


    Public Function Restore(ByVal dbName As String, ByVal fileName As String) As Boolean
        Return STADBO.Restore(con, cmd, dbName, fileName, m_errorMSG)
    End Function

    Public Function Restore(ByVal fileName As String) As Boolean
        Return Restore(m_dbName, fileName)
    End Function


    Public Function Attach(ByVal dbName As String, ByVal dfn As String, ByVal lfn As String) As Boolean
        Return STADBO.Attach(con, cmd, dbName, dfn, lfn, m_errorMSG)
    End Function

    Public Function Attach(ByVal dfn As String, ByVal lfn As String) As Boolean
        Return Attach(m_dbName, dfn, lfn)
    End Function

    Public Function Detach(ByVal dbName As String) As Boolean
        Return STADBO.Detach(con, cmd, dbName, m_errorMSG)
    End Function

    Public Function Detach() As Boolean
        Return Detach(m_dbName)
    End Function


#End Region

#End Region

#Region "Events"

    Private Sub con_StateChange(ByVal sender As Object, ByVal e As StateChangeEventArgs)
        '		string str1 = "لقد انقطع الاتصال بقاعدة البيانات";
        '		string str2 = "سوف يقوم البرنامج بمحاوله اعادة الاتصال ؟";
        '		string str3 = "لقد فشلت محاوله اعادة الاتصال";
        '		string str4 = "هل تريد اعادة الاتصال يدويا ؟";
        '		if(e.CurrentState == ConnectionState.Closed)
        '		{
        '			if(MSG.WarnOKCancel(str1+"\n"+str2,2) == DialogResult.OK)
        '			{
        '				if(!Connect())
        '				{
        '					if(MSG.WarnOKCancel(str3+"\n"+str4,2) == DialogResult.OK)
        '					{
        '						DBSTNG.Check();
        '					}
        '					else
        '					{
        '						Application.Exit();
        '					}
        '				}
        '			}
        '			else
        '			{
        '				Application.Exit();
        '			}
        '		}
    End Sub

    Private Sub con_InfoMessage(ByVal sender As Object, ByVal e As OdbcInfoMessageEventArgs)
        MsgBox(e.Message)
    End Sub

    Private Sub con_Disposed(ByVal sender As Object, ByVal e As EventArgs)
        MsgBox("Disposed")
    End Sub


#End Region

End Class
