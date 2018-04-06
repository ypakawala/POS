Imports System.Text
Imports Microsoft.Win32
Imports System.Data.Odbc

Public Class COM_Trail

    '## TO DO ##
    Dim ParentFolder As String = "SOFTWARE"
    Dim MainFolder As String = "SOP"
    Dim REG_Location As String = "SOFTWARE\SOP"
    '## TO DO ##

    'if software is on trail
    Public The_Trail_Period As Integer 'freez software after this # of days of trail
    Public The_Trail_Left As Integer '# of days left for trail

    Private registered, regEditError As Boolean

    Public Sub Trial_version(ByVal Trial As Boolean, _
    ByVal Duration As Integer, _
    ByVal Show_Lables As Boolean, _
    Optional ByRef LoginButton As Boolean = True, _
    Optional ByRef LabelTrail As Boolean = False, _
    Optional ByRef LinkRegistration As Boolean = False, _
    Optional ByRef LabelTrailMSG As String = "")
        Try
            If Trial = False Then
                '
                'FOR FULL VERSION
                '
                LoginButton = True
                LabelTrail = False
                LinkRegistration = False
            Else
                '
                'FOR TRIAL VERSION
                '
                The_Trail_Period = Duration
                registered = isRegistered()
                If regEdit() Then
                    regEditError = False
                    The_Trail_Left = TrailDays()
                    If Not registered Then
                        LabelTrail = False
                        If The_Trail_Left <> 0 Then
                            LoginButton = True
                            If Show_Lables Then
                                LabelTrailMSG = "Trail duration left " & The_Trail_Left & " Days "
                                LabelTrail = True
                            Else
                                LabelTrail = False
                            End If

                        Else
                            LoginButton = False
                            If Show_Lables Then
                                LabelTrailMSG = "Trial Period Expired."
                                LabelTrail = True
                            Else
                                LabelTrail = False
                            End If
                        End If
                    Else
                        LoginButton = True
                        LabelTrail = False
                        LinkRegistration = False
                    End If
                Else
                    regEditError = True
                    If Not registered Then
                        LoginButton = False
                        If Show_Lables Then
                            LabelTrailMSG = "Trial Period Expired."
                            LabelTrail = True
                        Else
                            LabelTrail = False
                        End If
                    Else
                        LoginButton = True
                        LabelTrail = False
                        LinkRegistration = False
                    End If
                End If
            End If
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
        End Try
    End Sub

    Public Function TrailDays() As Integer
        Dim Result As Integer = 0
        Try
            'LOOK FOR TRIAL PERIOD IN REGISTRY
            Dim sqlErr As String = ""
            Dim regCount As Integer = RegValue(RegistryHive.LocalMachine, REG_Location, "cnt", sqlErr)
            Dim lastRun As String = RegValue(RegistryHive.LocalMachine, REG_Location, "lr", sqlErr)

            Dim regLastDate As Date = Convert.ToDateTime(lastRun)
            Dim currentDate As Date = Now.Date
            If currentDate < regLastDate Then
                Result = 0
            Else
                If regCount < The_Trail_Period Then
                    Result = The_Trail_Period - (regCount)
                ElseIf regCount = The_Trail_Period Then
                    Result = 1
                Else
                    Result = 0
                End If
            End If
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
        End Try
        Return Result
    End Function
    Public Function isRegistered() As Boolean
        Dim Result As Integer = 0
        Try
            Dim Cls_RegDB As New RegDB
            Dim a As New DriveInfoApp
            Dim key As String = a.DiskInfo
            key = key.Trim

            If Cls_RegDB.Exists(key) Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
        End Try
        Return Result
    End Function
    Public Function regEdit() As Boolean
        Dim Result As Boolean = False
        Try
            'LOOK FOR REGISTRY
            Dim sqlErr As String = ""
            Dim lastRun As String = RegValue(RegistryHive.LocalMachine, REG_Location, "lr", sqlErr)
            Dim regCount As Integer = RegValue(RegistryHive.LocalMachine, REG_Location, "cnt", sqlErr)
            'IF NO REGISTRY FOR COUNT IS FOUND THEN CREATE IT
            If regCount = Nothing Then
                Dim RegForm As New frmInstallationKey()
                RegForm.ShowDialog()
                Dim getKey As Boolean = RegForm.KEY

               If getKey Then
                    Dim regKey As RegistryKey
                    regKey = Registry.LocalMachine.OpenSubKey(ParentFolder, True)
                    regKey.CreateSubKey(MainFolder)
                    regKey = Registry.LocalMachine.OpenSubKey(REG_Location, True)
                    regKey.SetValue("id", Now.Date.ToString)
                    regKey.SetValue("lr", Now.Date.ToString)
                    regKey.SetValue("cnt", 1)
                    'Dim a As New DriveInfoApp
                    'regKey.SetValue("REG", a.DiskInfo)
                    'regKey.SetValue("idd", The_Install_date_diff)
                    regKey.Close()
                    Result = True
                Else
                    'MsgBox("Invalic Key. Contact Hard Task.")
                    Windows.Forms.MessageBox.Show("Invalic Key. Contact Hard Task.", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
                    Result = False
                    'Me.Close()
                End If
            Else 'IF REGISTRY FOUND THEN CHECK DATE
                Dim regLastDate As Date = Convert.ToDateTime(lastRun)
                Dim currentDate As Date = Now.Date
                If currentDate = regLastDate Then
                    Result = True
                ElseIf currentDate > regLastDate Then
                    Dim Diff As Integer = DateDiff(DateInterval.Day, regLastDate, currentDate)
                    Dim regKey As RegistryKey
                    regKey = Registry.LocalMachine.OpenSubKey(REG_Location, True)
                    regKey.SetValue("cnt", regCount + Diff)
                    regKey.SetValue("lr", currentDate)
                    regKey.Close()
                    Result = True
                Else
                    Result = False
                End If
            End If
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
        End Try
        Return Result
    End Function

    Public Function RegValue(ByVal Hive As RegistryHive, ByVal Key As String, ByVal ValueName As String, Optional ByRef ErrInfo As String = "") As String
        Dim objParent As RegistryKey
        Dim objSubkey As RegistryKey
        Dim sAns As String
        Select Case Hive
            Case RegistryHive.ClassesRoot
                objParent = Registry.ClassesRoot
            Case RegistryHive.CurrentConfig
                objParent = Registry.CurrentConfig
            Case RegistryHive.CurrentUser
                objParent = Registry.CurrentUser
            Case RegistryHive.DynData
                objParent = Registry.DynData
            Case RegistryHive.LocalMachine
                objParent = Registry.LocalMachine
            Case RegistryHive.PerformanceData
                objParent = Registry.PerformanceData
            Case RegistryHive.Users
                objParent = Registry.Users
        End Select
        Try
            objSubkey = objParent.OpenSubKey(Key)
            'if can't be found, object is not initialized
            If Not objSubkey Is Nothing Then
                sAns = (objSubkey.GetValue(ValueName))
            End If

        Catch ex As Exception

            ErrInfo = ex.Message
        Finally

            'if no error but value is empty, populate errinfo
            If ErrInfo = "" And sAns = "" Then
                ErrInfo = _
                   "No value found for requested registry key"
            End If
        End Try
        Return sAns
    End Function
    Public Function getEncode(ByVal str As String)
        ' Encode string.
        Dim ascii As New ASCIIEncoding
        Dim encodedBytes As Byte() = ascii.GetBytes(str)
        Dim b As Byte
        Dim temp As String
        For Each b In encodedBytes
            temp &= b
        Next b
        Return temp
    End Function


    Public Class RegDetails
        Public Code As System.Int32
        Public RegValue As System.String
        Public UserName As System.String
        Public AppID As System.Int32
    End Class
    Public Class RegDB

        Public Function [Exists](ByVal [RegValue] As System.String) As Boolean
            Try

                Dim PARA As New ArrayList
                PARA.Add(RegValue)
                PARA.Add(1)
                Return DBO.ExecuteSP_ReturnInteger("RegExists", PARA)

            Catch ex As System.Exception
                MsgBox(ex.Message)
            End Try
        End Function
        Public Function Add(ByVal Reg_Details As RegDetails) As Boolean
            Try

                Dim PARA As New ArrayList
                PARA.Add(Reg_Details.RegValue)
                PARA.Add(Reg_Details.UserName)
                PARA.Add(1)
                Return DBO.ExecuteSP_ReturnInteger("RegInsert", PARA)

            Catch ex As System.Exception
                MsgBox(ex.Message)
            End Try
        End Function
    End Class
End Class