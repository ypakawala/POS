Public Class frmDialogResult
    Dim InfoOnly As Boolean = False
    Public Sub New(ByVal _Message As String, Optional _InfoOnly As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.lblMessage.Text = _Message

        InfoOnly = _InfoOnly

    End Sub
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Select Case CLS_Config.Company
            Case EDEE, CENTURY, BOOKSHOP, OsmanSM, INDIAGATE
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Case Else
                Me.DialogResult = Windows.Forms.DialogResult.OK
        End Select
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Select Case CLS_Config.Company
            Case EDEE, CENTURY, BOOKSHOP, OsmanSM, INDIAGATE
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Case Else
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Select
    End Sub

    Private Sub _KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnOK.KeyDown, btnCancel.KeyDown, Me.KeyDown
        Select Case CLS_Config.Company
            Case EDEE, CENTURY, BOOKSHOP, OsmanSM, INDIAGATE
                Select Case e.KeyCode
                    Case CLS_Config.K_Add, CLS_Config.K_Add2 : Me.DialogResult = Windows.Forms.DialogResult.Cancel
                    Case CLS_Config.K_Cash, CLS_Config.K_Cash2 : Me.DialogResult = Windows.Forms.DialogResult.OK
                End Select
            Case Else
                Select Case e.KeyCode
                    Case CLS_Config.K_Add, CLS_Config.K_Add2 : Me.DialogResult = Windows.Forms.DialogResult.OK
                    Case CLS_Config.K_Cash, CLS_Config.K_Cash2 : Me.DialogResult = Windows.Forms.DialogResult.Cancel
                End Select
        End Select
       
    End Sub

    Private Sub frmDialogResult_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Icon = My.Resources.Cart_Blue
        Select Case CLS_Config.Company
            Case EDEE, CENTURY, BOOKSHOP, OsmanSM, INDIAGATE
                Me.btnOK.Text = "&CANCEL"
                Me.btnCancel.Text = "&OK"
                Me.btnOK.BackColor = Color.OrangeRed
                Me.btnCancel.BackColor = Color.Yellow
            Case Else
                Me.btnOK.Text = "&OK"
                Me.btnCancel.Text = "&CANCEL"
                Me.btnOK.BackColor = Color.Yellow
                Me.btnCancel.BackColor = Color.OrangeRed
        End Select

        Me.btnOK.Visible = False
        Me.btnCancel.Visible = False

        Me.lblMessage.BackColor = Color.Transparent


        If InfoOnly Then
            Me.btnCancel.Visible = False
            Me.btnOK.Visible = False
            Me.BackColor = Color.Pink

            Select Case CLS_Config.Company
                Case INDIAGATE : Me.Timer1.Enabled = False
                Case Else : Me.Timer1.Enabled = True
            End Select
        Else

            Me.btnCancel.Visible = True
            Me.btnOK.Visible = True
            Me.BackColor = Color.DodgerBlue
            Me.Timer1.Enabled = False

        End If

    End Sub

    Private Sub lblMessage_Click(sender As Object, e As EventArgs) Handles lblMessage.Click, Me.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

End Class