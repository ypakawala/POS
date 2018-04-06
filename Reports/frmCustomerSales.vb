Imports System.Math
Imports CrystalDecisions.CrystalReports.Engine
Imports POS.FixControls
Public Class frmCustomerSales

    Private Sub frmCustomerSales_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, CRV.KeyUp, txtDateFrom.KeyUp, txtDateTo.KeyUp
        If e.KeyCode = Keys.End Then
            Me.Close()
        End If
    End Sub
    Private Sub frmCustomerSales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            btnClearAll_Click(sender, e)
            btnSearch_Click(sender, e)
        Catch ex As Exception
            MsgBox("frmCustomerSales_Load" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        LoadReport()
    End Sub
    Private Sub btnClearAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClearAll.Click
        Try
            Me.txtDateFrom.Value = Now.Date ' New DateTime(Now.Year, Now.Month, 1)

            Dim LastDay As Integer
            LastDay = DateAdd(DateInterval.Day, -1, DateSerial(Now.Year, Now.Month + 1, 1)).Day
            Me.txtDateTo.Value = New DateTime(Now.Year, Now.Month, Now.Day, 23, 59, 59) ' New DateTime(Now.Year, Now.Month, LastDay, 23, 59, 59)

            Me.txtDateFrom.Focus()

        Catch ex As Exception
            MsgBox("btnClearAll_Click" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Function isValid() As Boolean
        Try
            If FixControl(Me.txtDateFrom) = Null_Date Then
                MSG.ErrorOk("[DATE FROM] is missing.")
                Me.txtDateFrom.Focus()
                Me.txtDateFrom.SelectAll()
                Return False
            End If

            If FixControl(Me.txtDateTo) = Null_Date Then
                MSG.ErrorOk("[DATE TO] is missing.")
                Me.txtDateTo.Focus()
                Me.txtDateTo.SelectAll()
                Return False
            End If

            If FixControl(Me.txtDateTo) <> Null_Date Then
                If CDate(Me.txtDateFrom.Value) > CDate(Me.txtDateTo.Value) Then
                    MSG.ErrorOk("[DATE TO] should be less then [DATE FROM].")
                    Me.txtDateTo.Focus()
                    Me.txtDateTo.SelectAll()
                    Return False
                End If
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
            PARA.Add(FixControl(Me.txtDateFrom))
            PARA.Add(FixControl(Me.txtDateTo))

            DT = DBO.ExecuteSP_ReturnDataTable("Sale_CustomerSales", PARA)

            Dim report As New ReportDocument
            report.Load(CLS_Config.ReportPath & "Customer Sales.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)
            report.SetDataSource(DT)

            report.SetParameterValue("CompanyName", FixObjectString(CLS_Config.CompanyName))
            report.SetParameterValue("Address1", FixObjectString(CLS_Config.Address1))
            report.SetParameterValue("Address2", FixObjectString(CLS_Config.Address2))
            report.SetParameterValue("Address3", FixObjectString(CLS_Config.Address3))
            report.SetParameterValue("Tel", FixObjectString(CLS_Config.Tel))
            report.SetParameterValue("AccCashCustomer", FixObjectNumber(CLS_Config.AccCashCustomer))
            report.SetParameterValue("ForDate", "BETWEEN " & CType(Me.txtDateFrom.Value, Date).ToString("dd/MMM/yy") & " AND " & CType(Me.txtDateTo.Value, Date).ToString("dd/MMM/yy"))

            Me.CRV.ReportSource = report


        Catch ex As Exception
            MsgBox("LoadReport" & vbCrLf & ex.Message)
        End Try
    End Sub

End Class