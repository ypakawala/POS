
Imports System
Imports System.Data
Imports System.Collections
Imports System.Windows.Forms
Imports System.Data.Odbc
Imports Infragistics.Win.UltraWinGrid

Friend MustInherit Class STADBO

#Region "Fields"

    Private Shared m_commandTimeout As Integer = 1000
    Private Shared connectionTimeout As Integer = 1000
    Private Shared Null_Date As New DateTime(1900, 1, 1)

#End Region

#Region "Properties"

    Public Shared Property CommandTimeout() As Integer
        Get
            Return m_commandTimeout
        End Get
        Set(ByVal value As Integer)
            m_commandTimeout = value
        End Set
    End Property

#End Region

#Region "Methods"

#Region "Infra"

    Public Shared Function Connect(ByVal DsnName As String, ByVal userID As String, ByVal password As String, _
                                   ByRef con As OdbcConnection, ByRef cmd As OdbcCommand, _
                                   ByRef trans As OdbcTransaction, ByRef errorMSG As String) As Boolean
        Dim re As Boolean = False
        Try
            con = New OdbcConnection()
            'con.ConnectionString = ((((((("Integrated Security = " & iSec & ";" & "Persist Security Info = ") & psi & ";" & "User ID = ") & userID & ";" & "password = ") & password & ";" & "Initial Catalog = ") & dbName & ";" & "Data Source = ") & serverName & ";" & "Packet Size = 4096;" & "Connect Timeout = ") & connectionTimeout & ";" & "Workstation ID = ") & Environment.MachineName & ";"
            'con.ConnectionString = "Dsn=orcl;uid=hrms;pwd=hrms"
            'con.ConnectionString = "Dsn=" & DsnName & ";Uid=" & userID & ";Pwd=" & password & ";database=POSMS;trusted connection=No"
            con.ConnectionString = "Dsn=" & DsnName & ";Uid=" & userID & ";Pwd=" & password

            cmd = New OdbcCommand()
            cmd.Connection = con
            con.Open()
            cmd.CommandTimeout = m_commandTimeout
            cmd.Transaction = trans
            re = True
        Catch ex As Exception
            errorMSG = ex.Message
        End Try
        Return re
    End Function

    'Public Shared Function Connect(ByVal userID As String, ByVal password As String, ByRef con As OdbcConnection, ByRef cmd As OdbcCommand, _
    ' ByRef trans As OdbcTransaction, ByRef errorMSG As String, ByVal DsnName As String) As Boolean
    '    Return Connect(userID, password, con, cmd, trans, errorMSG, DsnName)
    'End Function

    'Public Shared Function Connect(ByRef con As OdbcConnection, ByRef cmd As OdbcCommand, ByRef trans As OdbcTransaction, ByRef errorMSG As String, ByVal DsnName As String) As Boolean
    '    Return Connect(serverName, dbName, "SSPI", "False", "", "", _
    '     con, cmd, trans, errorMSG, DsnName)
    'End Function

    'Public Shared Function Connect(ByRef con As OdbcConnection, ByRef cmd As OdbcCommand, ByRef trans As OdbcTransaction, ByRef errorMSG As String, ByVal DsnName As String) As Boolean
    '    Return Connect(serverName, dbName, "SSPI", "False", "", "", _
    '     con, cmd, trans, errorMSG, DsnName)
    'End Function

    Public Shared Sub OpenIfClosed(ByRef con As OdbcConnection)
        If con IsNot Nothing Then
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
        End If
    End Sub

    Public Shared Sub CloseIfOpened(ByRef con As OdbcConnection)
        If con IsNot Nothing Then
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End If
    End Sub

    Public Shared Function GetSingleValue(ByRef con As OdbcConnection, ByRef cmd As OdbcCommand, ByVal query As String) As Object
        Try
            'CloseIfOpened(ref con);
            OpenIfClosed(con)
            cmd.CommandText = query
            Dim obj As Object = cmd.ExecuteScalar()
            Return obj
        Catch ex As OdbcException
            CloseIfOpened(con)
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function GetListValues(ByRef con As OdbcConnection, ByRef cmd As OdbcCommand, ByVal query As String, ByVal Column As String) As Object()
        Try
            OpenIfClosed(con)
            Dim arrList As New ArrayList()
            cmd.CommandText = query
            Dim dr As OdbcDataReader = cmd.ExecuteReader()
            While dr.Read()
                arrList.Add(dr(Column))
            End While
            Dim list As Object() = New Object(arrList.Count - 1) {}
            arrList.CopyTo(list)
            arrList = Nothing
            dr.Close()
            'CloseIfOpened();
            Return list
        Catch ex As OdbcException
            MsgBox(ex.Message)
            CloseIfOpened(con)
            Return Nothing
        End Try
    End Function

    'Public Shared Function GetListValues(ByRef con As OdbcConnection, ByRef cmd As OdbcCommand, ByVal query As String, ByVal strValueMember As String, ByVal strDisplayMember As String) As ValueDisplayMember()
    '    Try
    '        OpenIfClosed(con)
    '        Dim arrList As New ArrayList()
    '        cmd.CommandText = query
    '        Dim dr As OdbcDataReader = cmd.ExecuteReader()
    '        While dr.Read()
    '            arrList.Add(New ValueDisplayMember(dr(strValueMember).ToString(), dr(strDisplayMember).ToString()))
    '        End While
    '        Dim list As ValueDisplayMember() = New ValueDisplayMember(arrList.Count - 1) {}
    '        arrList.CopyTo(list)
    '        arrList = Nothing
    '        dr.Close()
    '        'CloseIfOpened();
    '        Return list
    '    Catch ex As OdbcException
    '        msgbox(ex.Message)
    '        CloseIfOpened(con)
    '        Return Nothing
    '    End Try
    'End Function

    Public Shared Function GetTreeNodeValues(ByRef con As OdbcConnection, ByVal query As String, ByVal Column As String) As TreeNode()
        OpenIfClosed(con)
        Dim table As New DataTable()
        Dim da As New OdbcDataAdapter(query, con)
        da.Fill(table)
        Dim treeNode As TreeNode() = New TreeNode(table.Rows.Count - 1) {}
        If table.Rows.Count > 0 Then
            For i As Integer = 0 To treeNode.Length - 1
                treeNode(i) = New TreeNode()
                treeNode(i).Text = table.Rows(i)(Column).ToString()
            Next
        End If
        'CloseIfOpened();
        Return treeNode
    End Function

    Public Shared Function GetMenuValues(ByRef con As OdbcConnection, ByVal query As String) As MenuItem()
        OpenIfClosed(con)
        Dim table As New DataTable()
        Dim da As New OdbcDataAdapter(query, con)
        da.Fill(table)
        Dim menuItems As MenuItem() = New MenuItem(table.Rows.Count - 1) {}
        If table.Rows.Count > 0 Then
            For i As Integer = 0 To menuItems.Length - 1
                menuItems(i) = New MenuItem()
                menuItems(i).Text = table.Rows(i)(0).ToString()
            Next
        End If
        'CloseIfOpened();
        Return menuItems
    End Function

    Public Shared Function ReturnDataTable(ByRef con As OdbcConnection, ByRef cmd As OdbcCommand, ByVal SelectQuery As String) As DataTable
        Try
            OpenIfClosed(con)
            Dim table As New DataTable()
            'SelectQuery,con
            Dim da As New OdbcDataAdapter(SelectQuery, con)
            'cmd.CommandText = SelectQuery
            'da.SelectCommand = cmd
            da.Fill(table)
            'CloseIfOpened();
            Return table
        Catch ex As OdbcException
            MsgBox(ex.Message)
            CloseIfOpened(con)
            Return Nothing
        End Try
    End Function

    Public Shared Function ReturnDataTableFromTable(ByRef con As OdbcConnection, ByRef cmd As OdbcCommand, ByVal tblName As String) As DataTable
        Dim table As New DataTable()
        Try
            OpenIfClosed(con)
            'SelectQuery,con
            Dim da As New OdbcDataAdapter()
            cmd.CommandText = "SELECT * FROM " & tblName
            da.SelectCommand = cmd
            da.Fill(table)
        Catch ex As OdbcException
            MsgBox(ex.Message)
            table = Nothing
        Finally
            CloseIfOpened(con)
        End Try
        Return table
    End Function

    Public Shared Function ReturnDataTableFromTable(ByRef con As OdbcConnection, ByRef cmd As OdbcCommand, ByVal tblName As String, ByVal FKName As String, ByVal FKValue As Integer) As DataTable
        Dim table As New DataTable()
        Try
            OpenIfClosed(con)
            'SelectQuery,con
            Dim da As New OdbcDataAdapter()
            cmd.CommandText = "SELECT * FROM " & tblName & " WHERE (" & FKName & "=" & FKValue & ")"
            da.SelectCommand = cmd
            da.Fill(table)
        Catch ex As OdbcException
            MsgBox(ex.Message)
            table = Nothing
        Finally
            CloseIfOpened(con)
        End Try
        Return table
    End Function


    Public Shared Function ActionQuery(ByRef con As OdbcConnection, ByRef cmd As OdbcCommand, ByVal _actionQuery As String) As Boolean
        Try
            OpenIfClosed(con)
            cmd.CommandText = _actionQuery
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As OdbcException
            If ex.Message.IndexOf("DELETE statement conflicted with") > -1 Then
                'msgbox("You can't delete these data it relates to another.");
                MsgBox("لايمكنك حذف هذه البيانات لأنها مرتبطة ببيانات اخرى")
            ElseIf ex.Message.IndexOf("UPDATE statement conflicted with") > -1 Then
                'msgbox("You can't update these data it relates to another.");
                MsgBox("لايمكنك تعديل هذه البيانات لأنها مرتبطة ببيانات اخرى")
            Else
                'Displays the error
                CloseIfOpened(con)
                MsgBox(ex.Message)
            End If
            Return False
        End Try
    End Function

    Public Shared Function ExecuteSP(ByRef con As OdbcConnection, ByRef cmd As OdbcCommand, ByVal StoredProcedureName As String, ByVal ParaList As ArrayList) As Boolean
        Try
            OpenIfClosed(con)

            cmd.CommandText = StoredProcedureName
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = con
            OdbcCommandBuilder.DeriveParameters(cmd)

            SetParameterValue(cmd, ParaList)
            cmd.CommandText = "{?=CALL " & StoredProcedureName & IIf(ParaList.Count = 0, "", "(" & ParameterQuestions(ParaList.Count) & ")") & " }"
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As OdbcException
            CloseIfOpened(con)
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    'Public Shared Function ExecuteSP_ReturnInteger(ByRef con As OdbcConnection, ByRef cmd As OdbcCommand, ByVal StoredProcedureName As String, ByVal ParaList As ArrayList) As Integer
    '    Dim Result As Integer = Nothing
    '    Try
    '        OpenIfClosed(con)

    '        cmd.CommandText = StoredProcedureName
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.Connection = con
    '        OdbcCommandBuilder.DeriveParameters(cmd)

    '        SetParameterValue(cmd, ParaList)
    '        cmd.CommandText = "{?=CALL " & StoredProcedureName & IIf(ParaList.Count = 0, "", "(" & ParameterQuestions(ParaList.Count) & ")") & " }"
    '        cmd.ExecuteScalar()

    '        For Each parameter As OdbcParameter In cmd.Parameters
    '            If parameter.Direction = ParameterDirection.ReturnValue Then
    '                Result = IIf(IsDBNull(parameter.Value), Nothing, parameter.Value)
    '            End If
    '        Next

    '        Return Result


    '    Catch ex As OdbcException
    '        CloseIfOpened(con)
    '        msgbox(ex.Message)
    '        Return Nothing
    '    End Try
    'End Function

    Public Shared Function ExecuteSP_ReturnSingleValue(ByRef con As OdbcConnection, ByRef cmd As OdbcCommand, ByVal StoredProcedureName As String, ByVal ParaList As ArrayList) As Object
        Dim Result As Object = Nothing
        Try
            OpenIfClosed(con)

            cmd.CommandText = StoredProcedureName
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = con
            OdbcCommandBuilder.DeriveParameters(cmd)

            SetParameterValue(cmd, ParaList)
            cmd.CommandText = "{?=CALL " & StoredProcedureName & IIf(ParaList.Count = 0, "", "(" & ParameterQuestions(ParaList.Count) & ")") & " }"
            cmd.ExecuteScalar()

            For Each parameter As OdbcParameter In cmd.Parameters
                If parameter.Direction = ParameterDirection.ReturnValue Then
                    Result = IIf(IsDBNull(parameter.Value), Nothing, parameter.Value)
                End If
            Next

            Return Result

        Catch ex As OdbcException
            CloseIfOpened(con)
            MsgBox("At ExecuteSP_ReturnSingleValue :" & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function ExecuteSP_ReturnInteger(ByRef con As OdbcConnection, ByRef cmd As OdbcCommand, ByVal StoredProcedureName As String, ByVal ParaList As ArrayList) As Integer
        Dim Result As Integer = Nothing
        Try
            OpenIfClosed(con)

            cmd.CommandText = StoredProcedureName
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = con
            OdbcCommandBuilder.DeriveParameters(cmd)

            SetParameterValue(cmd, ParaList)
            cmd.CommandText = "{?=CALL " & StoredProcedureName & IIf(ParaList.Count = 0, "", "(" & ParameterQuestions(ParaList.Count) & ")") & " }"
            cmd.ExecuteScalar()

            For Each parameter As OdbcParameter In cmd.Parameters
                If parameter.Direction = ParameterDirection.ReturnValue Then
                    Result = IIf(IsDBNull(parameter.Value), Nothing, parameter.Value)
                End If
            Next

            Return Result

        Catch ex As OdbcException
            CloseIfOpened(con)
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function ExecuteSP_ReturnString(ByRef con As OdbcConnection, ByRef cmd As OdbcCommand, ByVal StoredProcedureName As String, ByVal ParaList As ArrayList) As String
        Dim Result As String = Nothing
        Try
            OpenIfClosed(con)

            cmd.CommandText = StoredProcedureName
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = con
            OdbcCommandBuilder.DeriveParameters(cmd)

            SetParameterValue(cmd, ParaList)

            cmd.CommandText = "{?=CALL " & StoredProcedureName & IIf(ParaList.Count = 0, "", "(" & ParameterQuestions(ParaList.Count) & ")") & " }"
            cmd.ExecuteScalar()

            For Each parameter As OdbcParameter In cmd.Parameters
                If parameter.Direction = ParameterDirection.ReturnValue Then
                    Result = IIf(IsDBNull(parameter.Value), Nothing, parameter.Value)
                End If
            Next

            Return Result

        Catch ex As OdbcException
            CloseIfOpened(con)
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function ExecuteSP_ReturnDateTime(ByRef con As OdbcConnection, ByRef cmd As OdbcCommand, ByVal StoredProcedureName As String, ByVal ParaList As ArrayList) As DateTime
        Dim Result As DateTime = Nothing
        Try
            OpenIfClosed(con)

            cmd.CommandText = StoredProcedureName
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = con
            OdbcCommandBuilder.DeriveParameters(cmd)

            SetParameterValue(cmd, ParaList)
            cmd.CommandText = "{?=CALL " & StoredProcedureName & IIf(ParaList.Count = 0, "", "(" & ParameterQuestions(ParaList.Count) & ")") & " }"
            cmd.ExecuteScalar()

            For Each parameter As OdbcParameter In cmd.Parameters
                If parameter.Direction = ParameterDirection.ReturnValue Then
                    Result = IIf(IsDBNull(parameter.Value), Nothing, parameter.Value)
                End If
            Next

            Return Result

        Catch ex As OdbcException
            CloseIfOpened(con)
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function ExecuteSP_ReturnDataTable(ByRef con As OdbcConnection, ByRef cmd As OdbcCommand, ByVal StoredProcedureName As String, ByVal ParaList As ArrayList) As DataTable
        Try
            OpenIfClosed(con)
            Dim DA As New Odbc.OdbcDataAdapter()
            Dim DT As New DataTable()

            cmd.CommandText = StoredProcedureName
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = con
            OdbcCommandBuilder.DeriveParameters(cmd)

            SetParameterValue(cmd, ParaList)
            'cmd.CommandText = "{?=CALL " & StoredProcedureName & "}"
            cmd.CommandText = "{?=CALL " & StoredProcedureName & IIf(ParaList.Count = 0, "", "(" & ParameterQuestions(ParaList.Count) & ")") & " }"
            'cmd.ExecuteNonQuery()

            DA.SelectCommand = cmd
            DA.Fill(DT)
            DA.Dispose()

            Return DT

        Catch ex As OdbcException
            'CloseIfOpened(con)
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function ExecuteSP_ReturnDataSet(ByRef con As OdbcConnection, ByRef cmd As OdbcCommand, ByVal StoredProcedureName As String, ByVal ParaList As ArrayList) As DataSet
        Try
            OpenIfClosed(con)
            Dim DA As New Odbc.OdbcDataAdapter()
            Dim DS As New DataSet()

            cmd.CommandText = StoredProcedureName
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = con

            OdbcCommandBuilder.DeriveParameters(cmd)
            SetParameterValue(cmd, ParaList)
            cmd.CommandText = "{?=CALL " & StoredProcedureName & IIf(ParaList.Count = 0, "", "(" & ParameterQuestions(ParaList.Count) & ")") & " }"

            DA.SelectCommand = cmd
            DA.Fill(DS)
            DA.Dispose()

            Return DS

        Catch ex As OdbcException
            'CloseIfOpened(con)
            MSG.ErrorOk(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Shared Function UpdateDataTable(ByRef con As OdbcConnection, ByVal TableName As String, ByVal DT As DataTable) As Boolean
        Try

            OpenIfClosed(con)
            Dim DAD As New OdbcDataAdapter("SELECT *  FROM " & TableName, con)
            Dim CMdBuilder As New OdbcCommandBuilder(DAD)
            DAD.Update(DT)

            Return True

        Catch ex As Exception
            CloseIfOpened(con)
            MsgBox(ex.Message)
            Return False
        Finally
            'CloseIfOpened(con)
        End Try
    End Function

    Public Shared Sub SetParameterValue(ByRef cmd As OdbcCommand, ByVal ParaList As ArrayList)
        Try
            Dim index As Integer = 0
            ' Populate the Input Parameters With Values Provided
            For Each parameter As OdbcParameter In cmd.Parameters
                If parameter.Direction = ParameterDirection.Input Or parameter.Direction = ParameterDirection.InputOutput Then
                    If parameter.DbType = DbType.DateTime And ParaList(index) = Nothing Then
                        parameter.Value = Null_Date
                    Else
                        parameter.Value = ParaList(index)
                    End If
                    index += 1
                End If
            Next
        Catch ex As Exception
            MsgBox("At SetParameterValue :" & ex.Message)
        End Try
    End Sub

    Public Shared Function ParameterQuestions(Optional ByVal ParaNO As Integer = 1) As String
        Dim result As String = Nothing
        If ParaNO < 1 Then
            Return Nothing
        Else
            Dim i As Integer = 1
            Do While i < ParaNO
                result = result & "?,"
                i = i + 1
            Loop
        End If
        Return result & "?"
    End Function

    Public Shared Sub BeginTransaction(ByRef con As OdbcConnection, ByRef trans As OdbcTransaction, ByRef cmd As OdbcCommand)
        OpenIfClosed(con)
        trans = con.BeginTransaction()
        cmd.Transaction = trans
    End Sub

    Public Shared Sub Commit(ByRef trans As OdbcTransaction)
        trans.Commit()
    End Sub

    Public Shared Sub Rollback(ByRef trans As OdbcTransaction)
        trans.Rollback()
    End Sub


#End Region

#Region "Usage"

    Public Shared Function GetSingleString(ByVal con As OdbcConnection, ByVal cmd As OdbcCommand, ByVal query As String, ByVal nullRe As String) As String
        Dim obj As Object = GetSingleValue(con, cmd, query)
        If obj IsNot Nothing AndAlso obj IsNot DBNull.Value Then
            Return obj.ToString()
        Else
            Return nullRe
        End If
    End Function

    Public Shared Sub LoadComboBoxEx(ByRef con As OdbcConnection, ByRef cmd As OdbcCommand, ByVal query As String, ByVal combo As UltraCombo, ByVal strValueMember As String, ByVal strDisplayMember As String)
        'MIM
        'combo.SelectedIndex = -1
        'combo.Properties.Items.Clear()
        'combo.Properties.Items.AddRange(GetListValues(con, cmd, query, strValueMember, strDisplayMember))
    End Sub

    Public Shared Sub LoadComboBox(ByVal con As OdbcConnection, ByVal cmd As OdbcCommand, ByVal query As String, ByVal combo As UltraCombo, ByVal column As String)
        'MIM
        'combo.SelectedIndex = -1
        'combo.Properties.Items.Clear()
        'combo.Properties.Items.AddRange(GetListValues(con, cmd, query, column))
    End Sub

    Public Shared Sub LoadComboBox(ByVal con As OdbcConnection, ByVal cmd As OdbcCommand, ByVal tblName As String, ByRef combo As UltraCombo, ByVal DisplayMember As String, ByVal ValueMember As String, Optional ByVal HiddenMember1 As String = "", Optional ByVal HiddenMember2 As String = "", Optional ByVal HiddenMember3 As String = "", Optional ByVal HiddenMember4 As String = "")


        Dim str As String = "SELECT  " & ValueMember & " , " & DisplayMember & IIf(HiddenMember1 = "", "", " , " & HiddenMember1) & IIf(HiddenMember2 = "", "", " , " & HiddenMember2) & IIf(HiddenMember3 = "", "", " , " & HiddenMember3) & IIf(HiddenMember4 = "", "", " , " & HiddenMember4) & " FROM " & tblName & " ORDER BY " & DisplayMember
        combo.DataSource = ReturnDataTable(con, cmd, str)
        combo.DisplayMember = DisplayMember
        combo.ValueMember = ValueMember
        combo.DataBind()

        combo.DisplayLayout.Bands(0).Columns(ValueMember).Hidden = True

        If HiddenMember1 <> "" Then
            combo.DisplayLayout.Bands(0).Columns(HiddenMember1).Hidden = True
        End If
        If HiddenMember2 <> "" Then
            combo.DisplayLayout.Bands(0).Columns(HiddenMember2).Hidden = True
        End If
        If HiddenMember3 <> "" Then
            combo.DisplayLayout.Bands(0).Columns(HiddenMember3).Hidden = True
        End If
        If HiddenMember4 <> "" Then
            combo.DisplayLayout.Bands(0).Columns(HiddenMember4).Hidden = True
        End If

        combo.DisplayLayout.Bands(0).ColHeadersVisible = False

        combo.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        combo.DisplayLayout.Bands(0).Columns(DisplayMember).Width = 250




        'MIM
        'combo.SelectedIndex = -1
        'combo.Properties.Items.Clear()
        'combo.Properties.Items.AddRange(GetListValues(con, cmd, query, column))
    End Sub

    Public Shared Sub LoadComboBox(ByVal con As OdbcConnection, ByVal cmd As OdbcCommand, ByVal query As String, ByVal combo As System.Windows.Forms.ComboBox, ByVal strDisplayMember As String, ByVal strValueMember As String)
        'MIM
        combo.SelectedIndex = -1
        combo.Items.Clear()
        combo.DataSource = ReturnDataTable(con, cmd, query)
        combo.DisplayMember = strDisplayMember
        combo.ValueMember = strValueMember
    End Sub

    Public Shared Sub LoadListBox(ByVal con As OdbcConnection, ByVal cmd As OdbcCommand, ByVal query As String, ByVal listBox As ListControl, ByVal column As String)
        'MIM
        'listBox.SelectedIndex = -1
        'listBox.Items.Clear()
        'listBox.Items.AddRange(GetListValues(con, cmd, query, column))
    End Sub

    Public Shared Sub LoadCheckedListBox(ByVal con As OdbcConnection, ByVal cmd As OdbcCommand, ByVal query As String, ByVal chkList As CheckedListBox, ByVal column As String)
        chkList.SelectedIndex = -1
        chkList.Items.Clear()
        chkList.Items.AddRange(GetListValues(con, cmd, query, column))
    End Sub

    Public Shared Sub LoadTreeNode(ByVal con As OdbcConnection, ByVal query As String, ByVal tnc As TreeNodeCollection, ByVal column As String)
        tnc.Clear()
        tnc.AddRange(GetTreeNodeValues(con, query, column))
    End Sub

    Public Shared Sub LoadMenu(ByVal con As OdbcConnection, ByVal query As String, ByVal menu As Menu)
        menu.MenuItems.Clear()
        menu.MenuItems.AddRange(GetMenuValues(con, query))
    End Sub

    Public Shared Sub LoadDataGrid(ByVal con As OdbcConnection, ByVal cmd As OdbcCommand, ByVal SelectQuery As String, ByVal dataGrid As DataGrid)
        dataGrid.DataSource = ReturnDataTable(con, cmd, SelectQuery)
    End Sub

    Public Shared Sub LoadDataGrid(ByVal con As OdbcConnection, ByVal cmd As OdbcCommand, ByVal tblName As String, ByRef dataGrid As UltraGrid)
        dataGrid.DataSource = ReturnDataTableFromTable(con, cmd, tblName)
    End Sub

    Public Shared Function ReturnDataTableFromSQL(ByRef con As OdbcConnection, ByRef cmd As OdbcCommand, ByVal SelectSQL As String) As DataTable
        Dim table As New DataTable()
        Try
            OpenIfClosed(con)
            'SelectQuery,con
            Dim da As New OdbcDataAdapter()
            cmd.CommandText = SelectSQL
            da.SelectCommand = cmd
            da.Fill(table)
        Catch ex As OdbcException
            MSG.ErrorOk(ex.Message)
            table = Nothing
        Finally
            CloseIfOpened(con)
        End Try
        Return table
    End Function

    Public Shared Function FindRow(ByVal tbl As DataTable, ByVal byColumn As String, ByVal Value As String) As DataRow
        tbl.PrimaryKey = New DataColumn() {tbl.Columns(byColumn)}
        Dim row As DataRow = tbl.Rows.Find(Value)
        Return row
    End Function

    Public Shared Sub FillText(ByVal con As OdbcConnection, ByVal cmd As OdbcCommand, ByVal query As String, ByVal control As Control)
        control.Text = GetSingleValue(con, cmd, query).ToString()
    End Sub

    Public Shared Sub FillText(ByVal con As OdbcConnection, ByVal cmd As OdbcCommand, ByVal query As String, ByVal control As Control, ByVal rowNo As Integer, ByVal Column As String)
        Dim table As DataTable = ReturnDataTable(con, cmd, query)
        If table.Rows.Count > 0 Then
            control.Text = table.Rows(rowNo)(Column).ToString()
        Else
            control.Text = ""
        End If
    End Sub

    Public Shared Function IsStored(ByVal con As OdbcConnection, ByVal cmd As OdbcCommand, ByVal fromTable As String, ByVal code As String, ByVal name As String) As Boolean
        Dim q As String = "SELECT count(name) FROM " & fromTable & " WHERE (name = '" & name.Trim() & "')" & " AND (code <> " & code & ")"
        Dim count As Integer = Convert.ToInt32(GetSingleValue(con, cmd, q))
        If count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function IsStored(ByVal con As OdbcConnection, ByVal cmd As OdbcCommand, ByVal fromTable As String, ByVal code As String, ByVal name As String, ByVal condition As String) As Boolean
        Dim q As String = "SELECT count(name) FROM " & fromTable & " WHERE (name = '" & name.Trim() & "')" & " AND (code <> " & code & ") " & condition
        Dim count As Integer = Convert.ToInt32(GetSingleValue(con, cmd, q))
        If count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function IsStored(ByVal con As OdbcConnection, ByVal cmd As OdbcCommand, ByVal fromTable As String, ByVal field As String, ByVal code As String, ByVal name As String, _
     ByVal condition As String) As Boolean
        Dim q As String = "SELECT count(" & field & ") FROM " & fromTable & " WHERE (" & field & " = '" & name.Trim() & "')" & " AND (code <> " & code & ") " & condition
        Dim count As Integer = Convert.ToInt32(GetSingleValue(con, cmd, q))
        If count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function HasRows(ByVal con As OdbcConnection, ByVal cmd As OdbcCommand, ByVal table As String) As Boolean
        Dim q As String = "SELECT COUNT(*) AS RowNo FROM " & table
        Return Convert.ToBoolean(GetSingleValue(con, cmd, q))
    End Function

    Public Shared Function HasRows(ByVal con As OdbcConnection, ByVal cmd As OdbcCommand, ByVal table As String, ByVal cond As String) As Boolean
        Dim q As String = "SELECT COUNT(*) AS RowNo FROM " & table & " " & cond
        Return Convert.ToBoolean(GetSingleValue(con, cmd, q))
    End Function

    Public Shared Function HasRows(ByVal con As OdbcConnection, ByVal cmd As OdbcCommand, ByVal table As String, ByVal field As String, ByVal val As String) As Boolean
        Dim q As String = "SELECT COUNT(" & field & ") AS RowNo FROM " & table & " WHERE (" & field & " = " & val & ")"
        Return Convert.ToBoolean(GetSingleValue(con, cmd, q))
    End Function

#End Region

#Region "Tools"

    Public Shared Sub LoadDBs(ByRef con As OdbcConnection, ByRef cmd As OdbcCommand, ByVal cbo As UltraCombo)
        Dim q As String = "select name from sysdatabases"
        LoadComboBox(con, cmd, q, cbo, "name")
    End Sub


    Public Shared Function Exists(ByRef con As OdbcConnection, ByRef cmd As OdbcCommand, ByVal dbName As String) As Boolean
        Dim q As String = "select count(name) as cnt from sysdatabases where (name = '" & dbName & "')"
        Dim count As Integer = Convert.ToInt32(GetSingleValue(con, cmd, q))
        If count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function


    Public Shared Function GetDBFileName(ByRef con As OdbcConnection, ByRef cmd As OdbcCommand, ByVal dbName As String) As String
        Dim q As String = "select filename from sysdatabases where (name = '" & dbName & "')"
        Return GetSingleString(con, cmd, q, "")
    End Function


    Public Shared Function Create(ByRef con As OdbcConnection, ByRef cmd As OdbcCommand, ByVal dbName As String) As Boolean
        Dim re As Boolean = False
        Try
            OpenIfClosed(con)
            Dim q As String = "create database " & dbName
            cmd.CommandText = q
            cmd.ExecuteNonQuery()
            re = True
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CloseIfOpened(con)
        End Try
        Return re
    End Function


    Public Shared Function BackUp(ByRef con As OdbcConnection, ByRef cmd As OdbcCommand, ByVal dbName As String, ByVal fileName As String, ByVal errorMSG As String) As Boolean
        Dim re As Boolean = False
        Try
            OpenIfClosed(con)
            Dim q As String = "BACKUP DATABASE " & dbName & " TO DISK = '" & fileName & "' WITH INIT"
            cmd.CommandText = q
            cmd.ExecuteNonQuery()
            re = True
        Catch ex As Exception
            If ex.Message.IndexOf("successfully") > -1 Then
                re = True
            Else
                errorMSG = ex.Message
            End If
        Finally
            CloseIfOpened(con)
        End Try
        Return re
    End Function


    Public Shared Function Restore(ByRef con As OdbcConnection, ByRef cmd As OdbcCommand, ByVal dbName As String, ByVal fileName As String, ByVal errorMSG As String) As Boolean
        Dim re As Boolean = False
        Try
            OpenIfClosed(con)
            Dim q As String = "RESTORE DATABASE " & dbName & " FROM DISK = '" & fileName & "'"
            '	+" WITH MOVE "+"'"+dbName+"' TO '"+GetDBFileName(ref con,ref cmd,dbName)+"'";
            cmd.CommandText = q
            cmd.ExecuteNonQuery()
            re = True
        Catch ex As Exception
            If ex.Message.IndexOf("successfully") > -1 Then
                re = True
            Else
                errorMSG = ex.Message
            End If
        Finally
            CloseIfOpened(con)
        End Try
        Return re
    End Function


    Public Shared Function Attach(ByRef con As OdbcConnection, ByRef cmd As OdbcCommand, ByVal dbName As String, ByVal dataFileName As String, ByVal logFileName As String, ByVal errorMSG As String) As Boolean
        Dim re As Boolean = False
        Try
            OpenIfClosed(con)
            Dim q As String = "EXEC sp_attach_db " & "@dbname = N'" & dbName & "' " & ", " & "@filename1 = N'" & dataFileName & "' " & ", " & "@filename2 = N'" & logFileName & "'"
            cmd.CommandText = q
            cmd.ExecuteNonQuery()
            re = True
        Catch ex As Exception
            If ex.Message.IndexOf("successfully") > -1 Then
                re = True
            Else
                errorMSG = ex.Message
            End If
        Finally
            CloseIfOpened(con)
        End Try
        Return re
    End Function


    Public Shared Function Detach(ByRef con As OdbcConnection, ByRef cmd As OdbcCommand, ByVal dbName As String, ByVal errorMSG As String) As Boolean
        Dim re As Boolean = False
        Try
            OpenIfClosed(con)
            Dim q As String = "EXEC sp_detach_db '" & dbName & "', 'true'"
            cmd.CommandText = q
            cmd.ExecuteNonQuery()
            re = True
        Catch ex As Exception
            If ex.Message.IndexOf("successfully") > -1 Then
                re = True
            Else
                errorMSG = ex.Message
            End If
        Finally
            CloseIfOpened(con)
        End Try
        Return re
    End Function


    Public Shared Function Relocate(ByRef con As OdbcConnection, ByRef trans As OdbcTransaction, ByRef cmd As OdbcCommand, ByVal dbName As String, ByVal newPath As String, ByVal errorMSG As String) As Boolean
        Dim re As Boolean = False
        'BeginTransaction(ref con,ref trans,ref cmd);
        Try
            Dim oldDFN As String = GetDBFileName(con, cmd, dbName)
            Dim oldLFN As String = oldDFN.Substring(0, oldDFN.Length - 4) & "_log" & ".ldf"

            Dim newDFN As String = newPath & "\" & dbName & ".mdf"
            Dim newLFN As String = newPath & "\" & dbName & "_log" & ".ldf"

            If Detach(con, cmd, dbName, errorMSG) Then
                System.IO.File.Move(oldDFN, newDFN)
                System.IO.File.Move(oldLFN, newLFN)

                If Attach(con, cmd, dbName, newDFN, newLFN, errorMSG) Then
                    'Commit(ref trans);
                    re = True
                End If
            End If
        Catch ex As Exception
            'Rollback(ref trans);
            errorMSG = ex.Message
        End Try
        Return re
    End Function

    Public Shared Function DatabaseBackups(ByVal PATH As String) As Boolean
        Dim dr As OdbcDataReader
        Dim result As Decimal = 0.0
        Dim Dbconn As New OdbcConnection(ConnStr)
        Try
            Dbconn.Open()
            Dim str As String = "BACKUP DATABASE [POS] TO  DISK = N'" & PATH & "' WITH NOFORMAT, NOINIT,  NAME = N'POS-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10"
            Dim dbcomm As New OdbcCommand(str, Dbconn)
            dr = dbcomm.ExecuteReader
            If dr.Read Then
                result = IIf(IsDBNull(dr(0)), 0, dr(0))
            End If
            MsgBox("The file was Saved Successfully at [" & PATH & "]")
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        Finally
            dr.Close()
            dr = Nothing
            Dbconn.Close()
        End Try
        Return result
    End Function
#End Region

#End Region

End Class