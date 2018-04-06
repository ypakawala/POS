Public Class frmActivation

    Dim ActivationCode As String = FingerPrint.Value("NayeeM PakawalA")
    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Try
            If FixControls.FixControl(Me.txtUserName) = Nothing Then
                MsgBox("User Name  Missing")
                Me.txtUserName.Focus()
                Exit Sub
            End If

            If FixControls.FixControl(Me.txtActivationCode) = Nothing Then
                MsgBox("Activation Code Missing")
                Me.txtActivationCode.Focus()
                Exit Sub
            End If


            If FixControls.FixControl(Me.txtActivationCode) <> ActivationCode Then
                MsgBox("Invalid  Activation Code")
                Me.txtActivationCode.Focus()
                Exit Sub
            End If

            Dim PARA As New ArrayList
            PARA.Add(FixControls.FixControl(Me.txtUserName))
            PARA.Add(FixControls.FixControl(Me.txtActivationCode))
            DBO.ExecuteSP("ActivationInsert", PARA)


            Me.DialogResult = Windows.Forms.DialogResult.Yes
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnExit_Click(sender As System.Object, e As System.EventArgs) Handles btnExit.Click
        Me.DialogResult = Windows.Forms.DialogResult.No
        Me.Close()
    End Sub

    Private Sub btnGenerateDLL_Click(sender As Object, e As EventArgs) Handles btnGenerateDLL.Click
        If TrimStr(Me.txtUserName.Value) = Nothing Then
            MsgBox("User Name  Missing")
            Me.txtUserName.Focus()
            Exit Sub
        End If

        Dim Browser As New System.Windows.Forms.FolderBrowserDialog
        Dim result As New System.Windows.Forms.DialogResult


        result = Browser.ShowDialog()
        If Browser.SelectedPath = Nothing Then
            MsgBox("Invalid Path Selected")
            Exit Sub
        End If
        If result = Windows.Forms.DialogResult.OK Then
            Dim PATH = Browser.SelectedPath & "\" & Me.txtUserName.Text & ".dll"
            Dim ENCRYPT As New Crypto
            ENCRYPT.FileEncript(ActivationCode, PATH)
        End If

    End Sub
End Class