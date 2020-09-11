Imports CrystalDecisions.CrystalReports.Engine
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmMembership

    Dim MembershipCode As Integer
    Dim CLS As New Membership
    Dim CONTEXT As New POSEntities

    Public Sub New(ByVal _MembershipCode As Integer)
        InitializeComponent()
        MembershipCode = _MembershipCode
    End Sub
    Private Sub frmMembership_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.Cart_Blue
        Try
            Me.Text = "Membership"
            FillDrop(Me.DropUserCode, "UserName", "Code", Table.P_User)

            LoadData()
            Me.txtMembershipDate.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub LoadData()
        Try

            CLS = New Membership
            CLS = (From q In CONTEXT.Memberships Where q.Code = MembershipCode Select q).ToList().SingleOrDefault()

            If IsDBNull(CLS) OrElse IsNothing(CLS) Then
                Me.txtMembershipDate.Value = Now.Date
                Me.txtMembershipNumber.Value = GetMembershipNumber()
                Me.DropUserCode.Value = UserClass.Code
            Else
                Me.txtCode.Value = CLS.Code
                Me.txtMembershipNumber.Value = CLS.MembershipNumber
                Me.txtMembershipDate.Value = CLS.MembershipDate
                Me.txtMemberName.Value = CLS.MemberName
                Me.txtMobile.Value = CLS.Mobile
                Me.txtDOB.Value = CLS.DOB
                Me.isClosed.Checked = CLS.isClosed
                Me.DropUserCode.Value = CLS.UserCode

            End If
        Catch ex As Exception
            MsgBox("LoadData" & vbCrLf & ex.Message)
            If Not IsNothing(ex.InnerException) Then MsgBox(ex.InnerException.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub Delete()

        If IsDBNull(CLS) Or IsNothing(CLS) Then
        Else
            CONTEXT.SaveChanges()
            CONTEXT.Memberships.DeleteObject(CLS)
        End If
    End Sub
    Private Function isValid() As Boolean
        Try
            If TrimDate(Me.txtMembershipDate.Value) = Null_Date Then
                MsgBox("Membership Date Missing")
                Me.txtMembershipDate.Focus()
                Return False
            End If
            If TrimStr(Me.txtMembershipNumber.Value) = Nothing Then
                MsgBox("Membership Number Missing")
                Me.txtMembershipNumber.Focus()
                Return False
            End If
            If TrimStr(Me.txtMemberName.Value) = Nothing Then
                MsgBox("Member Name Missing")
                Me.txtMemberName.Focus()
                Return False
            End If
            If TrimStr(Me.txtMobile.Value) = Nothing Then
                MsgBox("Mobile Missing")
                Me.txtMobile.Focus()
                Return False
            End If
            If TrimDate(Me.txtDOB.Value) = Null_Date Then
                MsgBox("Date Of Birth Missing")
                Me.txtDOB.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            MsgBox("isValid" & vbCrLf & ex.Message)
        End Try
    End Function
    Private Sub FillMissingField()
        Try
            If MembershipCode = 0 Then
                Me.txtCode.Value = GetNewCode("Code", "Membership")
            End If
        Catch ex As Exception
            MsgBox("isValid" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If Not isValid() Then Exit Sub
            FillMissingField()

            If IsDBNull(CLS) Or IsNothing(CLS) Then

                CLS = New Membership

                CLS.Code = Me.txtCode.Value
                CLS.MembershipNumber = TrimStr(Me.txtMembershipNumber.Value)
                CLS.MembershipDate = TrimDate(Me.txtMembershipDate.Value)
                CLS.DOB = TrimDate(Me.txtDOB.Value)
                CLS.UserCode = TrimInt(Me.DropUserCode.Value)
                CLS.MemberName = TrimStr(Me.txtMemberName.Value)
                CLS.Mobile = TrimStr(Me.txtMobile.Value)
                CLS.isClosed = TrimBoolean(Me.isClosed.Checked)

                CONTEXT.Memberships.AddObject(CLS)

            Else

                'CLS.Code = Me.txtCode.Value
                CLS.MembershipNumber = TrimStr(Me.txtMembershipNumber.Value)
                CLS.MembershipDate = TrimDate(Me.txtMembershipDate.Value)
                CLS.DOB = TrimDate(Me.txtDOB.Value)
                CLS.UserCode = TrimInt(Me.DropUserCode.Value)
                CLS.MemberName = TrimStr(Me.txtMemberName.Value)
                CLS.Mobile = TrimStr(Me.txtMobile.Value)
                CLS.isClosed = TrimBoolean(Me.isClosed.Checked)

            End If


            CONTEXT.SaveChanges()

            Find_Int = CLS.Code

            Me.Close()

        Catch ex As Exception
            MsgBox("btnSave_Click" & vbCrLf & ex.Message)
            If Not IsNothing(ex.InnerException) Then MsgBox(ex.InnerException.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If TrimInt(Me.txtCode.Value) = Nothing Then Exit Sub
        If MsgBox("Deleting Membership. Are you sure?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub
        Delete()
        CONTEXT.SaveChanges()
        Me.Close()

    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        LoadData()
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub txtMembershipDate_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMembershipDate.KeyDown
        If e.KeyCode = Keys.Enter Then Me.txtMembershipNumber.Focus()
    End Sub
    Private Sub txtMembershipNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMembershipNumber.KeyDown
        If e.KeyCode = Keys.Enter Then Me.txtMemberName.Focus()
    End Sub

    Private Sub txtMemberName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMemberName.KeyDown
        If e.KeyCode = Keys.Enter Then Me.txtMobile.Focus()
    End Sub
    Private Sub txtMobile_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMobile.KeyDown
        If e.KeyCode = Keys.Enter Then Me.txtDOB.Focus()
    End Sub
    Private Sub txtRemark_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDOB.KeyDown
        If e.KeyCode = Keys.Enter Then btnSave_Click(sender, e)
    End Sub


End Class