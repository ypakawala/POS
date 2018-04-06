
#Region "Using Directives"

Imports System
Imports System.Windows.Forms

#End Region

Public MustInherit Class MSG

#Region "Privates"

    Private Shared m_title As String = ""
    Private Shared m_msgOptions As MessageBoxOptions = MessageBoxOptions.DefaultDesktopOnly

#End Region

#Region "Properties"

    Public Shared Property Title() As String
        Get
            Return m_title
        End Get
        Set(ByVal value As String)
            m_title = value
        End Set
    End Property

    Public Shared Property MSGOptions() As MessageBoxOptions
        Get
            Return m_msgOptions
        End Get
        Set(ByVal value As MessageBoxOptions)
            m_msgOptions = value
        End Set
    End Property


#End Region

#Region "Methods"

    Public Shared Function AskBeforeSaving() As DialogResult
        Return InfoYesNo("هل تريد حفظ البيانات", 1)
    End Function

    Public Shared Function AskBeforeEditing() As DialogResult
        Return InfoYesNo("هل تريد حفظ البيانات", 1)
    End Function

    Public Shared Function AlreadyExists(ByVal c As Control) As DialogResult
        c.Focus()
        Return InfoOk("هذا البيان مسجل من قبل")
    End Function


    Public Shared Function Saved() As DialogResult
        Return InfoOk("تم الحفظ")
    End Function


    Private Shared Function DefaultButton(ByVal numButtons As Integer, ByVal _defaultButton As Integer) As MessageBoxDefaultButton
        Dim msgDefaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1
        Select Case numButtons
            Case 2
                If True Then
                    If _defaultButton >= 2 Then
                        msgDefaultButton = MessageBoxDefaultButton.Button2
                    End If
                    Exit Select
                End If
            Case 3
                If True Then
                    If _defaultButton = 2 Then
                        msgDefaultButton = MessageBoxDefaultButton.Button2
                    End If
                    If _defaultButton >= 3 Then
                        msgDefaultButton = MessageBoxDefaultButton.Button3
                    End If
                    Exit Select
                End If
        End Select
        Return msgDefaultButton
    End Function


    Public Shared Function NoneOk(ByVal str As String) As DialogResult
        Return MessageBox.Show(str, m_title, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, m_msgOptions)
    End Function


    Public Shared Function InfoOk(ByVal str As String) As DialogResult
        Return MessageBox.Show(str, m_title, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, m_msgOptions)
    End Function


    Public Shared Function ErrorOk(ByVal str As String) As DialogResult
        Return MessageBox.Show(str, m_title, MessageBoxButtons.OK, MessageBoxIcon.[Error], MessageBoxDefaultButton.Button1, m_msgOptions)
    End Function


    Public Shared Function WarnOk(ByVal str As String) As DialogResult
        Return MessageBox.Show(str, m_title, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, m_msgOptions)
    End Function


    Public Shared Function NoneOk(ByVal str As String, ByVal ctrlFocus As Control) As DialogResult
        ctrlFocus.Focus()
        Return MessageBox.Show(str, m_title, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, m_msgOptions)
    End Function


    Public Shared Function InfoOk(ByVal str As String, ByVal ctrlFocus As Control) As DialogResult
        ctrlFocus.Focus()
        Return MessageBox.Show(str, m_title, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, m_msgOptions)
    End Function


    Public Shared Function ErrorOk(ByVal str As String, ByVal ctrlFocus As Control) As DialogResult
        ctrlFocus.Focus()
        Return MessageBox.Show(str, m_title, MessageBoxButtons.OK, MessageBoxIcon.[Error], MessageBoxDefaultButton.Button1, m_msgOptions)
    End Function


    Public Shared Function WarnOk(ByVal str As String, ByVal ctrlFocus As Control) As DialogResult
        ctrlFocus.Focus()
        Return MessageBox.Show(str, m_title, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, m_msgOptions)
    End Function


    Public Shared Function NoneOKCancel(ByVal str As String, ByVal button As Integer) As DialogResult
        Return MessageBox.Show(str, m_title, MessageBoxButtons.OKCancel, MessageBoxIcon.None, DefaultButton(2, button), m_msgOptions)
    End Function


    Public Shared Function InfoOKCancel(ByVal str As String, ByVal button As Integer) As DialogResult
        Return MessageBox.Show(str, m_title, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, DefaultButton(2, button), m_msgOptions)
    End Function


    Public Shared Function ErrorOKCancel(ByVal str As String, ByVal button As Integer) As DialogResult
        Return MessageBox.Show(str, m_title, MessageBoxButtons.OKCancel, MessageBoxIcon.[Error], DefaultButton(2, button), m_msgOptions)
    End Function


    Public Shared Function WarnOKCancel(ByVal str As String, ByVal button As Integer) As DialogResult
        Return MessageBox.Show(str, m_title, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, DefaultButton(2, button), m_msgOptions)
    End Function


    Public Shared Function NoneYesNo(ByVal str As String, ByVal button As Integer) As DialogResult
        Return MessageBox.Show(str, m_title, MessageBoxButtons.YesNo, MessageBoxIcon.None, DefaultButton(2, button), m_msgOptions)
    End Function


    Public Shared Function InfoYesNo(ByVal str As String, ByVal button As Integer) As DialogResult
        Return MessageBox.Show(str, m_title, MessageBoxButtons.YesNo, MessageBoxIcon.Information, DefaultButton(2, button), m_msgOptions)
    End Function


    Public Shared Function ErrorYesNo(ByVal str As String, ByVal button As Integer) As DialogResult
        Return MessageBox.Show(str, m_title, MessageBoxButtons.YesNo, MessageBoxIcon.[Error], DefaultButton(2, button), m_msgOptions)
    End Function


    Public Shared Function WarnYesNo(ByVal str As String, ByVal button As Integer) As DialogResult
        Return MessageBox.Show(str, m_title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, DefaultButton(2, button), m_msgOptions)
    End Function


    Public Shared Function NoneRetryCancel(ByVal str As String, ByVal button As Integer) As DialogResult
        Return MessageBox.Show(str, m_title, MessageBoxButtons.RetryCancel, MessageBoxIcon.None, DefaultButton(2, button), m_msgOptions)
    End Function


    Public Shared Function InfoRetryCancel(ByVal str As String, ByVal button As Integer) As DialogResult
        Return MessageBox.Show(str, m_title, MessageBoxButtons.RetryCancel, MessageBoxIcon.Information, DefaultButton(2, button), m_msgOptions)
    End Function


    Public Shared Function ErrorRetryCancel(ByVal str As String, ByVal button As Integer) As DialogResult
        Return MessageBox.Show(str, m_title, MessageBoxButtons.RetryCancel, MessageBoxIcon.[Error], DefaultButton(2, button), m_msgOptions)
    End Function


    Public Shared Function WarnRetryCancel(ByVal str As String, ByVal button As Integer) As DialogResult
        Return MessageBox.Show(str, m_title, MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning, DefaultButton(2, button), m_msgOptions)
    End Function


    Public Shared Function NoneYesNoCancel(ByVal str As String, ByVal button As Integer) As DialogResult
        Return MessageBox.Show(str, m_title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.None, DefaultButton(3, button), m_msgOptions)
    End Function


    Public Shared Function InfoYesNoCancel(ByVal str As String, ByVal button As Integer) As DialogResult
        Return MessageBox.Show(str, m_title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, DefaultButton(3, button), m_msgOptions)
    End Function


    Public Shared Function ErrorYesNoCancel(ByVal str As String, ByVal button As Integer) As DialogResult
        Return MessageBox.Show(str, m_title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.[Error], DefaultButton(3, button), m_msgOptions)
    End Function


    Public Shared Function WarnYesNoCancel(ByVal str As String, ByVal button As Integer) As DialogResult
        Return MessageBox.Show(str, m_title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, DefaultButton(3, button), m_msgOptions)
    End Function


    Public Shared Function NoneAbortRetryIgnore(ByVal str As String, ByVal button As Integer) As DialogResult
        Return MessageBox.Show(str, m_title, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.None, DefaultButton(3, button), m_msgOptions)
    End Function


    Public Shared Function InfoAbortRetryIgnore(ByVal str As String, ByVal button As Integer) As DialogResult
        Return MessageBox.Show(str, m_title, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Information, DefaultButton(3, button), m_msgOptions)
    End Function


    Public Shared Function ErrorAbortRetryIgnore(ByVal str As String, ByVal button As Integer) As DialogResult
        Return MessageBox.Show(str, m_title, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.[Error], DefaultButton(3, button), m_msgOptions)
    End Function


    Public Shared Function WarnAbortRetryIgnore(ByVal str As String, ByVal button As Integer) As DialogResult
        Return MessageBox.Show(str, m_title, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning, DefaultButton(3, button), m_msgOptions)
    End Function


#End Region

End Class
