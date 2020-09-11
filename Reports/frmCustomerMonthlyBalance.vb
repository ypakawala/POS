Imports System.Math
Imports CrystalDecisions.CrystalReports.Engine
Imports POS.FixControls
Public Class frmCustomerMonthlyBalance

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

            Me.txtDateTo.Value = Now.Date ' New DateTime(Now.Year, Now.Month, Now.Day, 23, 59, 59) 'New DateTime(Now.Year, Now.Month, LastDay, 23, 59, 59)
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
            Dim d As DateTime = CDate(Me.txtDateTo.Value)
            Dim LastDay As Integer
            LastDay = DateAdd(DateInterval.Day, -1, DateSerial(d.Year, d.Month + 1, 1)).Day
            Dim dt As New DateTime(d.Year, d.Month, LastDay, 23, 59, 59)

            'Dim DT As New DataTable

            'Dim PARA As New ArrayList
            'PARA.Add(FixControl(Me.txtDateTo))

            'DT = DBO.ExecuteSP_ReturnDataTable("CustomerMonthlyBalance", PARA)

            Dim report As New ReportDocument
            report.Load(CLS_Config.ReportPath & "Customer Monthly Balance.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)
            'report.SetDataSource(DT)

            report.SetParameterValue("CompanyName", FixObjectString(CLS_Config.CompanyName))
            report.SetParameterValue("Address1", FixObjectString(CLS_Config.Address1))
            report.SetParameterValue("Address2", FixObjectString(CLS_Config.Address2))
            report.SetParameterValue("Address3", FixObjectString(CLS_Config.Address3))
            report.SetParameterValue("Tel", FixObjectString(CLS_Config.Tel))
            report.SetParameterValue("AccCashCustomer", FixObjectNumber(CLS_Config.AccCashCustomer))

            report.SetParameterValue("@BalanceDate", dt)
            report.SetDatabaseLogon("pos", "pos")
            Me.CRV.ReportSource = report


        Catch ex As Exception
            MsgBox("LoadReport" & vbCrLf & ex.Message)
        End Try
    End Sub

End Class