Public Class frmDialogResult

    Public Sub New(ByVal _Message As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.lblMessage.Text = _Message
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

        Me.lblMessage.BackColor = Color.Transparent
        Me.BackColor = Color.DodgerBlue
    End Sub
End Class