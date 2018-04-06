Public Class Display
    Declare Function opencd722usb Lib "cd722dusb.dll" () As Boolean
    Declare Function writecd722usb Lib "cd722dusb.dll" (ByRef dataoutput As Byte, ByVal Length As Integer) As Integer
    Declare Function readcd722usb Lib "cd722dusb.dll" (ByRef DataInput As Byte, ByVal size As Integer) As Integer
    Declare Function closecd722usb Lib "cd722dusb.dll" () As Boolean
    Private m_USB_is_Open As Boolean = False
    Private m_Result As Boolean = Nothing

    Public Sub New()
    End Sub

    Public Sub OpenPort()
        If m_USB_is_Open Then
            Throw New System.IO.IOException("USB is already open")
        End If
        m_Result = opencd722usb()
        If m_Result Then
            m_USB_is_Open = True
        Else
            Throw New System.IO.IOException("Unable to open USB")
        End If
    End Sub

    Public Sub ClosePort()
        If Not m_USB_is_Open Then
            Throw New System.IO.IOException("USB is already closed")
        End If
        m_Result = closecd722usb()
        If m_Result Then
            m_USB_is_Open = False
        Else
            Throw New System.IO.IOException("Unable to close USB")
        End If
    End Sub

    Public Sub WritePort(ByVal DataOutput As String)
        Dim Encoding As System.Text.Encoding = System.Text.Encoding.UTF8
        Dim byteOutput() As Byte = Encoding.GetBytes(DataOutput)
        Dim Result As Integer = writecd722usb(byteOutput(0), byteOutput.Length)
    End Sub

    Public Function ReadPort() As String
        Dim Encoding As System.Text.Encoding = System.Text.Encoding.UTF8
        Dim readBuffer(2048) As Byte
        Dim readLength As Integer
        Dim Result As Integer = readcd722usb(readBuffer(0), readLength)
        ReadPort = New String(Encoding.GetChars(readBuffer, 0, readLength))
    End Function

    Public Function Clear()
        WritePort(Chr(&HC))
    End Function

    Public Sub ShowScrollText()
        WritePort(Chr(&H2) + Chr(&H5) + Chr(&H44) + Chr(&H8) + Chr(&H3))
        'Dim Length As Long
        'Dim slen As Long
        'slen = Len(Chr(&H2) + Chr(&H5) + Chr(&H44) + Chr(&H8) + Chr(&H3))
        'Length = slen

        ''Dim Encoding As System.Text.Encoding = System.Text.Encoding.UTF8
        ''Dim byteOutput() As Byte = Encoding.GetBytes(dataoutput)
        ''Dim Result As Integer = writecd722usb(byteOutput(0), byteOutput.Length)

        'Dim dataoutput() As Byte

        'For i = 0 To slen - 1
        '    dataoutput(i) = Asc(Mid((Chr(&H2) + Chr(&H5) + Chr(&H44) + Chr(&H8) + Chr(&H3)), i + 1, 1))
        'Next i
        'writecd722usb(dataoutput(0), Length)

    End Sub
 

    'Private Sub numupperline_Click()
    '    If openusbFlag = False Then Mesg("Port not open...", 4, "message") : Exit Sub
    '    Dim Length As Long
    '    Dim slen As Long
    '    slen = Len(Chr(&H2) + Chr(&H5) + Chr(&H7) + Chr(&H32) + Chr(&H3))
    '    Length = slen
    '    For i = 0 To slen - 1
    '        dataoutput(i) = Asc(Mid((Chr(&H2) + Chr(&H5) + Chr(&H7) + Chr(&H32) + Chr(&H3)), i + 1, 1))
    '    Next i
    '    ret = writecd722usb(dataoutput(0), Length)
    '    'Comm1.Output = Chr(&H2) + Chr(&H5) + Chr(&H7) + Chr(&H32) + Chr(&H3)
    'End Sub

    'Sub WriteSomethingRedToPrinterThroughDisplay()
    '    cls.OpenPort()
    '    cls.WritePort(Chr(12)) ' Clear pole display
    '    cls.WritePort(Chr(27) & Chr(61) & Chr(1)) ' Send print through pole display
    '    cls.WritePort(Chr(27) & Chr(64)) ' Initialize printer
    '    cls.WritePort(Chr(27) & Chr(114) & Chr(1)) ' Select Red color to print
    '    cls.WritePort(String.Format("{0,-10}_
    '    {1,7:-0.000}{2,10:0.00}{3,13:-0.00}", _
    '        tempitemid, tempunits, tempunitprice, _
    '        tempsubtotal) & Chr(10)) ' Print text and new line
    '    cls.WritePort(Chr(27) & Chr(114) & Chr(0)) ' Set color to default Black
    '    cls.WritePort(Chr(27) & Chr(61) & _
    '    Chr(2)) ' De-select printer and enable pole display
    '    cls.ClosePort()
    'End Sub

End Class