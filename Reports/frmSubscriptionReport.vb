Imports System.Math
Imports CrystalDecisions.CrystalReports.Engine
Imports POS.FixControls
Public Class frmSubscriptionReport

    Private Sub frmSubscriptionReport_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, CRV.KeyUp
        If e.KeyCode = Keys.End Then
            Me.Close()
        End If
    End Sub
    Private Sub frmSubscriptionReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FillDrop(Me.DropYear, "Title", "Code", Table.D_Year)

            btnClearAll_Click(sender, e)
            btnSearch_Click(sender, e)
        Catch ex As Exception
            MsgBox("frmSubscriptionReport_Load" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        LoadReport()
    End Sub
    Private Sub btnClearAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClearAll.Click
        Try
            Me.DropYear.Value = Now.Year
        Catch ex As Exception
            MsgBox("btnClearAll_Click" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Function isValid() As Boolean
        Try
            If FixControl(Me.DropYear) = Nothing Then
                MSG.ErrorOk("[YEAR] is missing.")
                Me.DropYear.Focus()
                Return False
            End If
            Return True
        Catch ex As Exception
            MsgBox("isValid" & vbCrLf & ex.Message)
        End Try
    End Function
    Private Function Where() As String
        Dim Result As String = Nothing
        Try
            Result = " WHERE T_Year = " & FixControl(Me.DropYear)

        Catch ex As Exception
            MsgBox("Where" & vbCrLf & ex.Message)
        End Try
        Return Result
    End Function
    Private Sub LoadReport()
        Try
            If Not isValid() Then Exit Sub

            Dim DT As New DataTable
            DT = DBO.ReturnDataTableFromSQL("SELECT * FROM dbo.Sales_Full_View_Sub " & Where())


            Dim report As New ReportDocument
            report.Load(CLS_Config.ReportPath & "Subscription.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)
            report.SetDataSource(DT)


            report.SetParameterValue("CompanyName", FixObjectString(CLS_Config.CompanyName))
            report.SetParameterValue("Address1", FixObjectString(CLS_Config.Address1))
            report.SetParameterValue("Address2", FixObjectString(CLS_Config.Address2))
            report.SetParameterValue("Address3", FixObjectString(CLS_Config.Address3))
            report.SetParameterValue("Tel", FixObjectString(CLS_Config.Tel))
            report.SetParameterValue("Year", FixControl(Me.DropYear))

            Me.CRV.ReportSource = report


        Catch ex As Exception
            MsgBox("LoadReport" & vbCrLf & ex.Message)
        End Try
    End Sub

End Class