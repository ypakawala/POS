Imports System.Math
Imports CrystalDecisions.CrystalReports.Engine
Imports POS.FixControls
Public Class frmAccountBalance
    Dim Account_Type As AccountType
    Dim AccountTypeName As String
    Public Sub New(ByVal _Account_Type As AccountType)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Account_Type = _Account_Type
        AccountTypeName = DBO.GetSingleString("SELECT Title FROM D_AccountType WHERE Code=" & Account_Type, "Account Type")
        Me.Text = AccountTypeName & " Balance"
    End Sub
    Private Sub frmAccountBalance_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, CRV.KeyUp, txtDateTo.KeyUp
        If e.KeyCode = Keys.End Then
            Me.Close()
        End If
    End Sub
    Private Sub frmCustomerBalance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.Cart_Blue
        Try
            btnClearAll_Click(sender, e)
            btnSearch_Click(sender, e)
        Catch ex As Exception
            MsgBox("frmSailSearch_Load" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        LoadReport()
    End Sub
    Private Sub btnClearAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClearAll.Click
        Try

            Dim LastDay As Integer
            LastDay = DateAdd(DateInterval.Day, -1, DateSerial(Now.Year, Now.Month + 1, 1)).Day
            Me.txtDateTo.Value = New DateTime(Now.Year, Now.Month, Now.Day, 23, 59, 59) 'New DateTime(Now.Year, Now.Month, LastDay, 23, 59, 59)

            Me.txtDateTo.Focus()

        Catch ex As Exception
            MsgBox("btnClearAll_Click" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Function isValid() As Boolean
        Try
            If FixControl(Me.txtDateTo) = Null_Date Then
                MSG.ErrorOk("[DATE TO] is missing.")
                Me.txtDateTo.Focus()
                Me.txtDateTo.SelectAll()
                Return False
            End If

            Return True
        Catch ex As Exception
            MsgBox("isValid" & vbCrLf & ex.Message)
        End Try
    End Function

    Private Sub LoadReport()
        Try
            If Not isValid() Then Exit Sub

            Dim DT As New DataTable

            Dim PARA As New ArrayList
            PARA.Add(FixControl(Me.txtDateTo))
            PARA.Add(Account_Type)

            DT = DBO.ExecuteSP_ReturnDataTable("AccountBalance", PARA)

            Dim report As New ReportDocument
            report.Load(CLS_Config.ReportPath & "Account Balance.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)
            report.SetDataSource(DT)

            report.SetParameterValue("CompanyName", FixObjectString(CLS_Config.CompanyName))
            report.SetParameterValue("Address1", FixObjectString(CLS_Config.Address1))
            report.SetParameterValue("Address2", FixObjectString(CLS_Config.Address2))
            report.SetParameterValue("Address3", FixObjectString(CLS_Config.Address3))
            report.SetParameterValue("Tel", FixObjectString(CLS_Config.Tel))
            report.SetParameterValue("AccCashCustomer", FixObjectNumber(CLS_Config.AccCashCustomer))

            report.SetParameterValue("AccountType", AccountTypeName)
            report.SetParameterValue("ForDate", "Till " & CType(Me.txtDateTo.Value, Date).ToString("dd/MMM/yy"))
            report.SetDatabaseLogon(DatabaseLogID, DatabasePass)
            Me.CRV.ReportSource = report


        Catch ex As Exception
            MsgBox("LoadReport" & vbCrLf & ex.Message)
        End Try
    End Sub

End Class