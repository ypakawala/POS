
#Region "Copyright(c)"

'Copyright (c) 2006 CONCEPT Corporation. All rigths reserved.

#End Region

#Region "Using Directives"

Imports System
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports System.ServiceProcess


#End Region

Public MustInherit Class DBSTNGO

#Region "Fields"

    Private Shared m_fileName As String = "" 'Application.StartupPath & "\Settings"
    Private Shared fileName2 As String = "" ' Application.StartupPath & "\DBSTNG"
    Private Shared m_serverName As String = ""
    Private Shared m_masterDB As String = "Master"
    Private Shared m_dbName As String = "POS"
    Private Shared m_integSec As Boolean = False
    Private Shared m_userID As String = "pos"
    Private Shared m_password As String = "pos"
    Private Shared m_DSNName As String = "POS"

#End Region

#Region "Properties"

    Public Shared Property DSNName() As String
        Get
            Return m_DSNName
        End Get
        Set(ByVal value As String)
            m_DSNName = value
        End Set
    End Property

    Public Shared Property FileName() As String
        Get
            Return fileName2
        End Get
        Set(ByVal value As String)
            fileName2 = value
        End Set
    End Property

    Public Shared Property ServerName() As String
        Get
            Return m_serverName
        End Get
        Set(ByVal value As String)
            m_serverName = value
        End Set
    End Property

    Public Shared Property MasterDB() As String
        Get
            Return m_masterDB
        End Get
        Set(ByVal value As String)
            m_masterDB = value
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

    Public Shared Property IntegSec() As Boolean
        Get
            Return m_integSec
        End Get
        Set(ByVal value As Boolean)
            m_integSec = value
        End Set
    End Property

    Public Shared Property UserID() As String
        Get
            Return m_userID
        End Get
        Set(ByVal value As String)
            m_userID = value
        End Set
    End Property

    Public Shared Property Password() As String
        Get
            Return m_password
        End Get
        Set(ByVal value As String)
            m_password = value
        End Set
    End Property

#End Region

#Region "Methods"

    Public Shared Function Check() As Boolean
        Return Check(m_dbName, False)
    End Function

    Public Shared Function CheckMaster() As Boolean
        Return Check(m_masterDB, True)
    End Function

    Public Shared Function Check(ByVal dbName As String, ByVal master As Boolean) As Boolean
        Dim re As Boolean = False
        If File.Exists(m_fileName) Then
            Dim str As String = Read()
            If str <> "" Then
                If DBO.Connect(DSNName, m_userID, m_password) Then
                    m_serverName = str
                    re = True
                Else
                    'Dim frmSettingsEntry As New DBSTNGETRY(master)
                    'If frmSettingsEntry.ShowDialog() = DialogResult.OK Then
                    '    re = True
                    'End If
                    re = False
                End If
            End If
        End If
        Return re
    End Function

    Public Shared Function Write(ByVal serverName As String) As Boolean
        Dim re As Boolean = False
        Try
            If File.Exists(m_fileName) Then
                File.Delete(m_fileName)
            End If
            Dim fs As New FileStream(m_fileName, FileMode.OpenOrCreate, FileAccess.Write)
            Dim bw As New BinaryWriter(fs, Encoding.Unicode)
            bw.Write(serverName)
            bw.Close()
            re = True
        Catch
        End Try
        Return re
    End Function

    Public Shared Function WriteXML() As Boolean
        Dim re As Boolean = False

        Try
            If File.Exists(fileName2) Then
                File.Delete(fileName2)
            End If

            Dim ds As New ConnectionDataset()
            Dim dr As System.Data.DataRow = ds.tblDBSTNG.NewRow()

            dr("ServerName") = m_serverName
            dr("DBName") = m_dbName
            dr("IntegSec") = m_integSec
            dr("UserID") = m_userID
            dr("Password") = m_password

            ds.tblDBSTNG.Rows.Add(dr)

            ds.tblDBSTNG.WriteXml(fileName2)

            re = True
        Catch ex As Exception
            File.Delete(fileName2)
        End Try

        Return re
    End Function

    Public Shared Function Read() As String
        Dim re As String = ""
        Dim fs As New FileStream(m_fileName, FileMode.Open, FileAccess.Read)
        Try
            Dim br As New BinaryReader(fs, Encoding.Unicode)
            re = br.ReadString()
            br.Close()
        Catch
            fs.Close()
            File.Delete(m_fileName)
        End Try
        Return re
    End Function

    Public Shared Function ReadXML(ByVal fileName As String) As Boolean
        Dim re As Boolean = False

        Try
            Dim ds As New ConnectionDataset()
            ds.tblDBSTNG.ReadXml(fileName)

            m_serverName = ds.tblDBSTNG.Rows(0)("ServerName").ToString()
            m_dbName = ds.tblDBSTNG.Rows(0)("DBName").ToString()
            m_integSec = Convert.ToBoolean(ds.tblDBSTNG.Rows(0)("IntegSec").ToString())
            m_userID = ds.tblDBSTNG.Rows(0)("UserID").ToString()
            m_password = ds.tblDBSTNG.Rows(0)("Password").ToString()

            re = True
        Catch ex As Exception
            File.Delete(fileName2)
        End Try

        Return re
    End Function

    'Public Shared Function SQLService(ByVal machine As String) As ServiceController
    '    Dim re As ServiceController = Nothing
    '    'Dim str As String = Srvs.SQLSrvr
    '    'Dim services As ServiceController() = ServiceController.GetServices(machine)
    '    'For Each s As ServiceController In services
    '    '    If s.ServiceName = str Then
    '    '        re = s
    '    '        Exit For
    '    '    End If
    '    'Next
    '    Return re
    'End Function

    'Public Shared Function CheckSQLService(ByVal sc As ServiceController) As Boolean
    '    Dim re As Boolean = False
    '    Try
    '        If sc IsNot Nothing Then
    '            If sc.Status <> ServiceControllerStatus.Running Then
    '                sc.Refresh()
    '                If sc.Status = ServiceControllerStatus.Paused Then
    '                    sc.[Continue]()
    '                ElseIf sc.Status = ServiceControllerStatus.Stopped Then
    '                    sc.Start()
    '                End If
    '                sc.Refresh()
    '            End If
    '            re = True
    '        Else
    '            MsgBox("SQL is not installed.")
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    '    Return re
    'End Function

    'Public Shared Function CheckSQLService(ByVal machine As String) As Boolean
    '    Dim re As Boolean = False
    '    Try
    '        Dim sc As ServiceController = SQLService(machine)
    '        If sc IsNot Nothing Then
    '            If sc.Status <> ServiceControllerStatus.Running Then
    '                sc.Refresh()
    '                If sc.Status = ServiceControllerStatus.Paused Then
    '                    sc.[Continue]()
    '                ElseIf sc.Status = ServiceControllerStatus.Stopped Then
    '                    sc.Start()
    '                End If
    '                sc.Refresh()
    '            End If
    '            re = True
    '        Else
    '            MsgBox("SQL is not installed.")
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    '    Return re
    'End Function

#End Region

End Class
