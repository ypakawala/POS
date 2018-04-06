
Imports Infragistics.Win.UltraWinMaskedEdit
Imports System.Data.Odbc

Public Class DataF

    Public Shared Function GetCarIDByCode(ByVal code As Integer, ByRef txtid1 As UltraMaskedEdit, ByRef txtid2 As UltraMaskedEdit) As Boolean
        Try
            Dim Q As String = "SELECT CardId1, CardId2 FROM Vehicle WHERE Code = " & code
            Dim DT As New DataTable
            DT = DBO.ReturnDataTableFromSQL(Q)
            txtid1.Value = FixObject(DT.Rows(0).Item("CardId1"))
            txtid2.Value = FixObject(DT.Rows(0).Item("CardId2"))
            Return True
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return False
        End Try
    End Function

    Public Shared Function GetNewFileNo() As String
        Try
            Dim Q As String = "SELECT Count(Code) FROM Passing WHERE Year(PassingDate) = " & Now.Date.Year
            Return CStr(CStr(CInt(DBO.GetSingleValue(Q)) + 1) & Now.Date.ToString("MMyy"))
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return ""
        End Try
    End Function

    Public Shared Function GetNewExaminationSerial() As String
        Try
            Dim Q As String = "SELECT Count(Code) FROM Examination WHERE Year(VDate) = " & Now.Date.Year
            Return CStr(CStr(Now.Date.ToString("yyyy") & "/" & CStr(DBO.GetSingleValue(Q)) + 1))
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return ""
        End Try
    End Function

    Public Shared Function IsFileExists(ByVal FileNo As String, ByVal ActionType As Integer, ByVal VehicleType As Integer) As Boolean
        Try
            Dim Para As New ArrayList

            Para.Add(FileNo)
            Para.Add(ActionType)
            Para.Add(VehicleType)

            If DBO.ExecuteSP_ReturnInteger("FileExists", Para) > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function

    Public Shared Function IsCarExists(ByVal CardID1 As String, ByVal CardID2 As String) As Boolean
        Try
            Dim TempCounter As Integer = 0
            TempCounter = CInt(DBO.GetSingleValue("SELECT count(*) FROM Vehicle where  COALESCE (CardId1, '') ='" & CardID1 & "' and  COALESCE (CardId2, '') ='" & CardID2 & "'"))

            If TempCounter > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function

    Public Shared Function IsCarExistsByCity(ByVal CardID1 As String, ByVal CityCode As Integer) As Boolean
        Try
            Dim TempCounter As Integer = 0
            TempCounter = CInt(DBO.GetSingleValue("SELECT count(*) FROM Vehicle where  COALESCE (CardId1, '') ='" & CardID1 & "' and  City =" & CityCode))

            If TempCounter > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function

    Public Shared Function IsCarExpired(ByVal VCode As Integer) As Boolean
        Try
            Dim DT As New DateTime
            DT = DBO.GetSingleValue("Select ExpiryDate from Vehicle where Code=" & VCode)
            If DT > Now.Date Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function

    Public Shared Function IsFileExists(ByVal FileNo As String) As Boolean
        Try
            Dim Para As New ArrayList

            Para.Add(FileNo)

            If DBO.ExecuteSP_ReturnInteger("FileExistsInAll", Para) > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function

    Public Shared Function GetCodeBasedonSerial(ByVal FileNo As String) As Integer
        Try
            Dim Para As New ArrayList
            Para.Add(FileNo)
            Return DBO.ExecuteSP_ReturnInteger("GetCodeBasedonSerial", Para)
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function

    Public Shared Function UpdateFileCancelStatus(ByVal FCode As Integer, ByVal CNotes As String, ByVal Cstatus As Boolean, ByVal CaDate As Date) As Boolean
        Try
            Dim Para As New ArrayList
            Para.Add(FCode)
            Para.Add(Cstatus)
            Para.Add(CNotes)
            Para.Add(CaDate)
            Para.Add(UsersDetails.Code)
            Return DBO.ExecuteSP("UpdateFileCancelStatus", Para)
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function

    Public Shared Function UpdateStopCancelStatus(ByVal FCode As Integer, ByVal CNotes As String, ByVal Cstatus As Boolean, ByVal CaDate As Date) As Boolean
        Try
            Dim Para As New ArrayList
            Para.Add(FCode)
            Para.Add(Cstatus)
            Para.Add(CNotes)
            Para.Add(CaDate)
            Para.Add(UsersDetails.Code)
            Return DBO.ExecuteSP("UpdateStopCancelStatus", Para)
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function

    Public Shared Function UpdateExaminationCancelStatus(ByVal FCode As Integer, ByVal CNotes As String, ByVal Cstatus As Boolean, ByVal CaDate As Date) As Boolean
        Try
            Dim Para As New ArrayList
            Para.Add(FCode)
            Para.Add(Cstatus)
            Para.Add(CNotes)
            Para.Add(CaDate)
            Para.Add(UsersDetails.Code)
            Return DBO.ExecuteSP("UpdateExaminationCancelStatus", Para)
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function

    Public Shared Function UpdateFemaleExaminationCancelStatus(ByVal FCode As Integer, ByVal CNotes As String, ByVal Cstatus As Boolean, ByVal CaDate As Date) As Boolean
        Try
            Dim Para As New ArrayList
            Para.Add(FCode)
            Para.Add(Cstatus)
            Para.Add(CNotes)
            Para.Add(CaDate)
            Para.Add(UsersDetails.Code)
            Return DBO.ExecuteSP("UpdateFemaleExaminationCancelStatus", Para)
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function

    Public Shared Function InsertPartner(ByVal ECode As Integer, ByVal EntityCode As String) As Boolean
        Try

            Dim Para As New ArrayList
            Para.Add(GetNewCode("Code", "Parteners"))
            Para.Add(ECode)
            Para.Add(EntityCode)

            Return DBO.ExecuteSP("PartenersInsert", Para)
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function

    Public Shared Function GetCurrentShift() As Integer
        Dim Dbconn As New OdbcConnection(DBO.Connection.ConnectionString)
        Dim dr As OdbcDataReader
        Try
            Dbconn.Open()
            dr = New OdbcCommand("SELECT TOP (1) NewShift FROM CurrentStatus ORDER BY Vdate DESC", Dbconn).ExecuteReader
            If dr.Read Then
                Return CInt(dr(0))
            Else
                Return Nothing
            End If
            'Dim LastShift As Object
            'LastShift = DBO.GetSingleValue("SELECT TOP (1) NewShift FROM CurrentStatus ORDER BY Vdate DESC")
            'If IsDBNull(LastShift) Then
            '    Return Nothing
            'Else
            '    Return LastShift
            'End If
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        Finally
            If Not IsNothing(dr) Then
                dr.Close()
                dr = Nothing
            End If
            If Dbconn.State = ConnectionState.Open Then
                Dbconn.Close()
            End If
        End Try
    End Function

    Public Shared Function IncrementProcessCounter() As Boolean
        Try
            If DBO.ActionQuery("Update P_Users Set ActionsCounter=Coalesce(ActionsCounter,0)+1 where Code=" & UsersDetails.Code) Then
                'Update Status Bar With New Counter
                SetOperationCounter()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return False
        End Try
    End Function

    Public Shared Function ClearProcessCounter() As Boolean
        Try
            Return DBO.ActionQuery("Update P_Users Set ActionsCounter=0 where Code=" & UsersDetails.Code)
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function

    Public Shared Function SetShift(ByVal userCode As Integer, ByVal SaloonEnter As Boolean, ByVal SaloonExit As Boolean, ByVal LorryEnter As Boolean, ByVal LorryExit As Boolean, ByVal FemaleCheck As Boolean) As Boolean
        Try
            Dim re1 As Boolean = False, re2 As Boolean = False, re3 As Boolean = False, re4 As Boolean = False, re5 As Boolean = False

            If CInt(DBO.GetSingleValue(("SELECT COUNT(Code) AS Expr1 FROM P_SystemPermission WHERE (SystemForm = 27) AND (UserCode = " & userCode & ")"))) = 0 Then 'Check Exists
                re1 = DBO.ActionQuery(" INSERT INTO P_SystemPermission " & _
                                                     " (Code, SystemForm, UserCode, canOpen, canAdd, canEdit, " & _
                                                     " canDelete, canSearch, canPrint, canExport) " & _
                                                     " VALUES (" & GetNewCode("Code", "P_SystemPermission") & ",27," & userCode & ", " & _
                                                      Convert.ToInt64(SaloonEnter) & ", 1, 1, 1, 1, 1, 1) ")
            Else
                re1 = DBO.ActionQuery("update p_systemPermission set canopen =" & Convert.ToInt64(SaloonEnter) & " where usercode=" & userCode & " and systemform=27")
            End If


            If CInt(DBO.GetSingleValue(("SELECT COUNT(Code) AS Expr1 FROM P_SystemPermission WHERE (SystemForm = 28) AND (UserCode = " & userCode & ")"))) = 0 Then 'Check Exists
                re2 = DBO.ActionQuery(" INSERT INTO P_SystemPermission " & _
                                                     " (Code, SystemForm, UserCode, canOpen, canAdd, canEdit, " & _
                                                     " canDelete, canSearch, canPrint, canExport) " & _
                                                     " VALUES (" & GetNewCode("Code", "P_SystemPermission") & ",28," & userCode & ", " & _
                                                      Convert.ToInt64(SaloonExit) & ", 1, 1, 1, 1, 1, 1) ")
            Else
                re2 = DBO.ActionQuery("update p_systemPermission set canopen =" & Convert.ToInt64(SaloonExit) & " where usercode=" & userCode & " and systemform=28")
            End If


            If CInt(DBO.GetSingleValue(("SELECT COUNT(Code) AS Expr1 FROM P_SystemPermission WHERE (SystemForm = 29) AND (UserCode = " & userCode & ")"))) = 0 Then 'Check Exists
                re3 = DBO.ActionQuery(" INSERT INTO P_SystemPermission " & _
                                                     " (Code, SystemForm, UserCode, canOpen, canAdd, canEdit, " & _
                                                     " canDelete, canSearch, canPrint, canExport) " & _
                                                     " VALUES (" & GetNewCode("Code", "P_SystemPermission") & ",29," & userCode & ", " & _
                                                      Convert.ToInt64(LorryEnter) & ", 1, 1, 1, 1, 1, 1) ")
            Else
                re3 = DBO.ActionQuery("update p_systemPermission set canopen =" & Convert.ToInt64(LorryEnter) & " where usercode=" & userCode & " and systemform=29")
            End If

            If CInt(DBO.GetSingleValue(("SELECT COUNT(Code) AS Expr1 FROM P_SystemPermission WHERE (SystemForm = 30) AND (UserCode = " & userCode & ")"))) = 0 Then 'Check Exists
                re4 = DBO.ActionQuery(" INSERT INTO P_SystemPermission " & _
                                                     " (Code, SystemForm, UserCode, canOpen, canAdd, canEdit, " & _
                                                     " canDelete, canSearch, canPrint, canExport) " & _
                                                     " VALUES (" & GetNewCode("Code", "P_SystemPermission") & ",30," & userCode & ", " & _
                                                      Convert.ToInt64(LorryExit) & ", 1, 1, 1, 1, 1, 1) ")
            Else
                re4 = DBO.ActionQuery("update p_systemPermission set canopen =" & Convert.ToInt64(LorryExit) & " where usercode=" & userCode & " and systemform=30")
            End If

            If CInt(DBO.GetSingleValue(("SELECT COUNT(Code) AS Expr1 FROM P_SystemPermission WHERE (SystemForm = 48) AND (UserCode = " & userCode & ")"))) = 0 Then 'Check Female check
                re5 = DBO.ActionQuery(" INSERT INTO P_SystemPermission " & _
                                                     " (Code, SystemForm, UserCode, canOpen, canAdd, canEdit, " & _
                                                     " canDelete, canSearch, canPrint, canExport) " & _
                                                     " VALUES (" & GetNewCode("Code", "P_SystemPermission") & ",48," & userCode & ", " & _
                                                      Convert.ToInt64(LorryExit) & ", 1, 1, 1, 1, 1, 1) ")
            Else
                re5 = DBO.ActionQuery("update p_systemPermission set canopen =" & Convert.ToInt64(FemaleCheck) & " where usercode=" & userCode & " and systemform=48")
            End If


            If re1 And re2 And re3 And re4 And re5 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function

    Public Shared Function SetInspectorNo(ByVal userCode As Integer, ByVal InspectorNo As String) As Boolean
        Try
            Return DBO.ActionQuery("update P_Users set InspectorNo ='" & InspectorNo & "' where code=" & userCode)
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function

    Public Shared Function SendMsg(ByVal ReceiverCode As Integer, ByVal Contents As String) As Boolean
        Try
            Dim Para As New ArrayList

            Para.Add(GetNewCode("Code", "Notifications"))
            Para.Add(Now)
            Para.Add(Contents)
            Para.Add(UsersDetails.Code)
            Para.Add(ReceiverCode)
            Para.Add(False)

            Return DBO.ExecuteSP("NotificationsInsert", Para)

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function

    Public Shared Function UpdateMsgStatus(ByVal Code As Integer) As Boolean
        Try
            Return DBO.ActionQuery("Update notifications set recieved =1 where code=" & Code)
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function

    Public Shared Function IsStopped(ByVal EntityType As Integer, ByVal EntityCode As Integer) As Boolean
        Try
            Dim Counter As Integer = CInt(DBO.GetSingleValue("SELECT COUNT(*) FROM Stopping WHERE (CancelStatus <> 1)  and (EntityType = " & EntityType & ") AND (EntityCode = " & EntityCode & ")"))
            If Counter = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function

    Public Shared Function GetStopType(ByVal EntityType As Integer, ByVal EntityCode As Integer, ByRef lblReason As String) As String
        Try
            'Return CStr(DBO.GetSingleString(" SELECT StopType.Title + ' - ' + StopStatus.Title  " & _
            '                                " FROM Stopping LEFT OUTER JOIN " & _
            '                                " StopType ON Stopping.StopType = StopType.Code LEFT OUTER JOIN " & _
            '                                " StopStatus ON Stopping.Status = StopStatus.Code " & _
            '                                " WHERE (Stopping.CancelStatus <> 1) AND (Stopping.EntityType = " & EntityType & ") AND (Stopping.EntityCode = " & EntityCode & ")", ""))

            Dim DT As New DataTable

            DT = DBO.ReturnDataTable(" SELECT StopType.Title + ' - ' + StopStatus.Title as StopType,Stopping.Reason  " & _
                                     " FROM Stopping LEFT OUTER JOIN " & _
                                     " StopType ON Stopping.StopType = StopType.Code LEFT OUTER JOIN " & _
                                     " StopStatus ON Stopping.Status = StopStatus.Code " & _
                                     " WHERE (Stopping.CancelStatus <> 1) AND (Stopping.EntityType = " & EntityType & ") AND (Stopping.EntityCode = " & EntityCode & ")")

            If DT.Rows.Count > 0 Then
                lblReason = FixObjectString(DT.Rows(0).Item("Reason"))
                Return FixObjectString(DT.Rows(0).Item("StopType"))
            End If
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return ""
        End Try
    End Function

    Public Shared Function IsStopped(ByVal EntityType As Integer, ByVal EntityCode As Integer, ByVal ActionType As Integer) As Boolean
        Try
            Dim Counter As Integer = CInt(DBO.GetSingleValue("SELECT COUNT(*) FROM Stopping WHERE (CancelStatus <> 1)  and (EntityType = " & EntityType & ") AND (EntityCode = " & EntityCode & ") AND (Status=1) AND ((StopType=" & ActionType & ") OR (StopType=3))"))
            If Counter = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function

    Public Shared Function IsStoppedForFemale(ByVal EntityType As Integer, ByVal EntityCode As Integer) As Boolean
        Try
            Dim Counter As Integer = CInt(DBO.GetSingleValue("SELECT COUNT(*) FROM Stopping WHERE (CancelStatus <> 1)  and (EntityType = " & EntityType & ") AND (EntityCode = " & EntityCode & ") AND (Status=1) "))
            If Counter = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function


    Public Shared Function IsStoppedByMOE(ByVal MOE As String, ByVal ActionType As Integer) As Boolean
        Try
            Dim Counter As Integer = CInt(DBO.GetSingleValue("SELECT COUNT(*) FROM Stopping WHERE (CancelStatus <> 1)  and (MOE= '" & MOE & "') and (Status=1) AND ((StopType=" & ActionType & ") OR (StopType=3))"))
            If Counter = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function


    ''' <summary>
    ''' check if this MOE Exists Before
    ''' </summary>
    ''' <param name="MOE"> Ministry of Interior Number</param>
    ''' <param name="RecordCode"> Record Primary Key</param>
    ''' <returns> Retrun True if Exists and Return False If Not</returns>
    ''' <remarks></remarks>
    Public Shared Function MOEDriverExists(ByVal MOE As String, Optional ByVal RecordCode As Integer = 0) As Boolean
        Try
            Dim Counter As Integer

            If RecordCode = 0 Then 'Add
                Counter = CInt(DBO.GetSingleValue("SELECT COUNT(*) FROM Drivers WHERE MOE = '" & MOE & "'"))
            Else 'Edit
                Counter = CInt(DBO.GetSingleValue("SELECT COUNT(*) FROM Drivers WHERE code <> " & RecordCode & " And MOE = '" & MOE & "'"))
            End If

            If Counter = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function
    Public Shared Function CivilIDDriverExists(ByVal CivilID As String, Optional ByVal RecordCode As Integer = 0) As Boolean
        Try
            Dim Counter As Integer

            If RecordCode = 0 Then 'Add
                Counter = CInt(DBO.GetSingleValue("SELECT COUNT(*) FROM Drivers WHERE CivilID = '" & CivilID & "'"))
            Else 'Edit
                Counter = CInt(DBO.GetSingleValue("SELECT COUNT(*) FROM Drivers WHERE code <> " & RecordCode & " And CivilID = '" & CivilID & "'"))
            End If

            If Counter = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function


    Public Shared Function MOEPersonExists(ByVal MOE As String, Optional ByVal RecordCode As Integer = 0) As Boolean
        Try
            Dim Counter As Integer

            If RecordCode = 0 Then 'Add
                Counter = CInt(DBO.GetSingleValue("SELECT COUNT(*) FROM Persons WHERE MOE = '" & MOE & "'"))
            Else 'Edit
                Counter = CInt(DBO.GetSingleValue("SELECT COUNT(*) FROM Persons WHERE code <> " & RecordCode & " And MOE = '" & MOE & "'"))
            End If
            If Counter = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function
    Public Shared Function CivilIDPersonExists(ByVal CivilID As String, Optional ByVal RecordCode As Integer = 0) As Boolean
        Try
            Dim Counter As Integer

            If RecordCode = 0 Then 'Add
                Counter = CInt(DBO.GetSingleValue("SELECT COUNT(*) FROM Persons WHERE CivilID = '" & CivilID & "'"))
            Else 'Edit
                Counter = CInt(DBO.GetSingleValue("SELECT COUNT(*) FROM Persons WHERE code <> " & RecordCode & " And CivilID = '" & CivilID & "'"))
            End If
            If Counter = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function

    Public Shared Function PassportNoPersonExists(ByVal PassportNo As String, Optional ByVal RecordCode As Integer = 0) As Boolean
        Try
            Dim Counter As Integer

            If RecordCode = 0 Then 'Add
                Counter = CInt(DBO.GetSingleValue("SELECT COUNT(*) FROM Persons WHERE PassportNo = '" & PassportNo & "'"))
            Else 'Edit
                Counter = CInt(DBO.GetSingleValue("SELECT COUNT(*) FROM Persons WHERE code <> " & RecordCode & " And PassportNo = '" & PassportNo & "'"))
            End If
            If Counter = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function


    Public Shared Function MOEOwnerExists(ByVal MOE As String, Optional ByVal RecordCode As Integer = 0) As Boolean
        Try

            Dim Counter As Integer

            If RecordCode = 0 Then 'Add
                Counter = CInt(DBO.GetSingleValue("SELECT COUNT(*) FROM VehicleOwner WHERE MOE = '" & MOE & "'"))
            Else 'Edit
                Counter = CInt(DBO.GetSingleValue("SELECT COUNT(*) FROM VehicleOwner WHERE code <> " & RecordCode & " And MOE = '" & MOE & "'"))
            End If

            If Counter = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function
    Public Shared Function CivilIDPlayerExists(ByVal CivilID As String, Optional ByVal RecordCode As Integer = 0) As Boolean
        Try

            Dim Counter As Integer

            If RecordCode = 0 Then 'Add
                Counter = CInt(DBO.GetSingleValue("SELECT COUNT(*) FROM D_PlayerData WHERE CivilID = '" & CivilID & "'"))
            Else 'Edit
                Counter = CInt(DBO.GetSingleValue("SELECT COUNT(*) FROM D_PlayerData WHERE code <> " & RecordCode & " And CivilID = '" & CivilID & "'"))
            End If

            If Counter = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function


    Public Shared Function UnifiedNoEmployeeExists(ByVal UNNo As String, Optional ByVal RecordCode As Integer = 0) As Boolean
        Try
            Dim Counter As Integer

            If RecordCode = 0 Then 'Add
                Counter = CInt(DBO.GetSingleValue("SELECT COUNT(*) FROM D_PlayerData WHERE UnifiedNo = '" & UNNo & "'"))
            Else 'Edit
                Counter = CInt(DBO.GetSingleValue("SELECT COUNT(*) FROM D_PlayerData WHERE code <> " & RecordCode & " And UnifiedNo = '" & UNNo & "'"))
            End If

            If Counter = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function

    Public Shared Function HasMany(ByVal CArdID1 As String) As Boolean
        Try
            Dim Counter As Integer

            Counter = CInt(DBO.GetSingleValue("SELECT COUNT(*) FROM Vehicle WHERE CardID1='" & CArdID1 & "'"))

            If Counter = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function


    Public Shared Function RecoverDeletedPassingRecord(ByVal Code As Integer) As Boolean
        Try
            Return DBO.ActionQuery("Update Passing set RecoveredStatus=1 , CancelStatus=0 , RecoveredDate='" & Now.Date & "' , RecoverUser=" & UsersDetails.Code & " Where code=" & Code)
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function


    Public Shared Function RecoverDeletedStopRecord(ByVal Code As Integer) As Boolean
        Try
            Return DBO.ActionQuery("Update Stopping set RecoveredStatus=1 , CancelStatus=0 , RecoveredDate='" & Now.Date & "' , RecoverUser=" & UsersDetails.Code & " Where code=" & Code)
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function


    Public Shared Function RecoverDeletedExaminationRecord(ByVal Code As Integer) As Boolean
        Try
            Return DBO.ActionQuery("Update Examination set RecoveredStatus=1 , CancelStatus=0 , RecoveredDate='" & Now.Date & "' , RecoverUser=" & UsersDetails.Code & " Where code=" & Code)
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function

    Public Shared Function RecoverDeletedFemaleExaminationRecord(ByVal Code As Integer) As Boolean
        Try
            Return DBO.ActionQuery("Update FemaleExamination set RecoveredStatus=1 , CancelStatus=0 , RecoveredDate='" & Now.Date & "' , RecoverUser=" & UsersDetails.Code & " Where code=" & Code)
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function


    Public Shared Function InsertPermissionRecord(ByVal UserCode As Integer, _
                                                  ByVal SystemForm As Integer, _
                                                  ByRef canOpen As Boolean, _
                                                  ByRef canAdd As Boolean, _
                                                  ByRef canEdit As Boolean, _
                                                  ByRef canDelete As Boolean, _
                                                  ByRef canSearch As Boolean, _
                                                  ByRef canPrint As Boolean, _
                                                  ByRef canExport As Boolean) As Boolean
        Try
            Dim Para As New ArrayList

            Para.Add(GetNewCode("Code", "P_SystemPermission"))
            Para.Add(SystemForm)
            Para.Add(UserCode)
            Para.Add(canOpen)
            Para.Add(canAdd)
            Para.Add(canEdit)
            Para.Add(canDelete)
            Para.Add(canSearch)
            Para.Add(canPrint)
            Para.Add(canExport)

            Return DBO.ExecuteSP("P_SystemPermissionInsert", Para)
            'Return DBO.ActionQuery("Update Examination set RecoveredStatus=1 , CancelStatus=0 , RecoveredDate='" & Now.Date & "' , RecoverUser=" & UsersDetails.Code & " Where code=" & Code)
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function


    Public Shared Function RefreshPermission(ByRef FormCode As String, _
                                             ByRef m_canOpen As Boolean, _
                                             ByRef m_addData As Boolean, _
                                             ByRef m_editData As Boolean, _
                                             ByRef m_deleteData As Boolean, _
                                             ByRef m_SearchData As Boolean, _
                                             ByRef m_PrintData As Boolean, _
                                             ByRef m_ExportData As Boolean, _
                                             ByRef m_watchOnly As Boolean, _
                                             ByRef m_saveData As Boolean) As Boolean


        Dim Dbconn As New OdbcConnection(DBO.Connection.ConnectionString)

        Try
            If UsersDetails.IsAdmin Then
                m_canOpen = True
                m_addData = True
                m_editData = True
                m_deleteData = True
                m_SearchData = True
                m_PrintData = True
                m_ExportData = True

                If Not m_addData AndAlso Not m_editData AndAlso Not m_deleteData Then
                    m_watchOnly = True
                End If

                If m_addData OrElse m_editData Then
                    m_saveData = True
                End If

            Else
                Dim Str As String = "SELECT code, UserCode, SystemForm, canOpen, canAdd, canEdit, canDelete, canSearch, canPrint, canExport FROM " & DBTable.UserFormPermission & " WHERE (SystemForm = " & FormCode & ") AND (UserCode = " & UsersDetails.Code & ")"
                Dbconn.Open()
                Dim dt As New DataTable
                Dim DBA As New OdbcDataAdapter(Str, Dbconn)
                DBA.Fill(dt)

                If dt.Rows.Count > 0 Then

                    m_canOpen = FixObjectBoolean(dt.Rows(0)("canOpen"))
                    m_addData = FixObjectBoolean(dt.Rows(0)("canAdd"))
                    m_editData = FixObjectBoolean(dt.Rows(0)("canEdit"))
                    m_deleteData = FixObjectBoolean(dt.Rows(0)("canDelete"))
                    m_SearchData = FixObjectBoolean(dt.Rows(0)("canSearch"))
                    m_PrintData = FixObjectBoolean(dt.Rows(0)("canPrint"))
                    m_ExportData = FixObjectBoolean(dt.Rows(0)("canExport"))

                    If Not m_addData AndAlso Not m_editData AndAlso Not m_deleteData Then
                        m_watchOnly = True
                    End If
                    If m_addData OrElse m_editData Then
                        m_saveData = True
                    End If
                End If
            End If

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        Finally
            If Dbconn.State = ConnectionState.Open Then
                Dbconn.Close()
            End If
        End Try
    End Function


    Public Shared Function isDriverSameOwner(ByVal DriverCode As Integer, ByVal OwnerCode As Integer) As Boolean
        Try

            'Check By MOE

            Dim DriverMOE As String = DBO.GetSingleString("Select MOE from Drivers where code= " & DriverCode, "")
            Dim OwnerMOE As String = DBO.GetSingleString("Select MOE from VehicleOwner where code= " & OwnerCode, "")

            If DriverMOE = OwnerMOE Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function


End Class