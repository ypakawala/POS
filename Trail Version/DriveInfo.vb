Option Strict On
Option Explicit On 

Imports System.Management

Class DriveInfoApp

    '<STAThread()> _
  'Shared Sub Main()

    '  Dim drives As New ArrayList

    '  Dim query As New ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive")

    '  For Each wmiDrive As ManagementObject In query.Get()
    '    Dim info As New DriveInfo
    '    info.Model = wmiDrive("Model").ToString()
    '    info.Type = wmiDrive("InterfaceType").ToString()
    '    drives.Add(info)
    '  Next

    '  query = New ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia")

    '  Dim i As Integer = 0
    '  For Each wmiDrive As ManagementObject In query.Get()
    '    ' Get the hard drive from collection using index.
    '    Dim info As DriveInfo = CType(drives(i), DriveInfo)
    '    ' Get the hardware serial number.
    '    If wmiDrive("SerialNumber") Is Nothing Then
    '      info.SerialNumber = "None"
    '    Else
    '      info.SerialNumber = wmiDrive("SerialNumber").ToString()
    '    End If
    '    i += 1
    '  Next

    '  ' Display available hard drives.
    '  For Each info As DriveInfo In drives
    '    Console.WriteLine("Model" + vbTab + vbTab + ": " + info.Model)
    '    Console.WriteLine("Type" + vbTab + vbTab + ": " + info.Type)
    '    Console.WriteLine("Serial No." + vbTab + ": " + info.SerialNumber)
    '    Console.WriteLine()
    '  Next

    '  Console.WriteLine("Press [Enter] to exit...")
    '  Console.ReadLine()

    'End Sub

    Public Function DiskInfo() As String

        Dim drives As New ArrayList

        Dim query As New ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive")

        For Each wmiDrive As ManagementObject In query.Get()
            Dim info As New DriveInfo
            info.Model = wmiDrive("Model").ToString()
            info.Type = wmiDrive("InterfaceType").ToString()
            drives.Add(info)
        Next

        query = New ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia")

        Dim i As Integer = 0
        For Each wmiDrive As ManagementObject In query.Get()
            ' Get the hard drive from collection using index.
            Dim info As DriveInfo = CType(drives(i), DriveInfo)
            ' Get the hardware serial number.
            If wmiDrive("SerialNumber") Is Nothing Then
                info.SerialNumber = "None"
            Else
                info.SerialNumber = wmiDrive("SerialNumber").ToString()
            End If
            i += 1
            Exit For
        Next

        ' Display available hard drives.
        For Each info As DriveInfo In drives
            Return info.Model & info.Type & info.SerialNumber

            ''Console.WriteLine("Model" + vbTab + vbTab + ": " + info.Model)
            ''Console.WriteLine("Type" + vbTab + vbTab + ": " + info.Type)
            ''Console.WriteLine("Serial No." + vbTab + ": " + info.SerialNumber)
            ''Console.WriteLine()
        Next

        ''Console.WriteLine("Press [Enter] to exit...")
        ''Console.ReadLine()

    End Function

End Class

Class DriveInfo

    Private _model As String
    Private _type As String
    Private _serialNumber As String

    Public Property Model() As String
        Get
            Return _model
        End Get
        Set(ByVal Value As String)
            _model = Value
        End Set
    End Property

    Public Property Type() As String
        Get
            Return _type
        End Get
        Set(ByVal Value As String)
            _type = Value
        End Set
    End Property

    Public Property SerialNumber() As String
        Get
            Return _serialNumber
        End Get
        Set(ByVal Value As String)
            _serialNumber = Value
        End Set
    End Property

End Class
