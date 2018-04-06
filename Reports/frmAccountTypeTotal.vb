Imports System.Math
Imports CrystalDecisions.CrystalReports.Engine
Imports POS.FixControls
Public Class frmAccountTypeTotal


    Private Sub frmAccountStatement_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, MenuStrip1.KeyUp, txtDateFrom.KeyUp, txtDateTo.KeyUp, DropAccount.KeyUp, MenuStrip1.KeyUp
        If e.KeyCode = Keys.End Then
            Me.Close()
        End If
    End Sub
    Private Sub frmAccountStatement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillDrop(Me.DropAccount, "Title", "Code", "D_AccountType")
        btnClearAll_Click(sender, e)
    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        LoadReport()
    End Sub
    Private Sub btnClearAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClearAll.Click
        Try
            Me.txtDateFrom.Value = Now.Date 'New Date(Now.Year, Now.Month, 1)
            Dim LastDay As Integer
            LastDay = DateAdd(DateInterval.Day, -1, DateSerial(Now.Year, Now.Month + 1, 1)).Day
            Me.txtDateTo.Value = New DateTime(Now.Year, Now.Month, Now.Day, 23, 59, 59) 'New DateTime(Now.Year, Now.Month, LastDay, 23, 59, 59)
            Me.txtDateFrom.Focus()
            Me.txtDateFrom.SelectAll()
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
                Dim LastDay As Integer
                LastDay = DateAdd(DateInterval.Day, -1, DateSerial(Now.Year, Now.Month + 1, 1)).Day
                Me.txtDateTo.Value = New DateTime(Now.Year, Now.Month, LastDay, 23, 59, 59)

            End If
            If FixControl(Me.txtDateTo) <> Null_Date Then
                If CDate(Me.txtDateFrom.Value) > CDate(Me.txtDateTo.Value) Then
                    MSG.ErrorOk("[DATE TO] should be less then [DATE FROM].")
                    Me.txtDateTo.Focus()
                    Me.txtDateTo.SelectAll()
                    Return False
                End If
            End If

            If IsDBNull(Me.DropAccount.Value) Or IsNothing(Me.DropAccount.Value) Then
                MSG.ErrorOk("[ACCOUNT TYPE] is missing.")
                Me.DropAccount.Focus()
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
            Result = " WHERE (EffectiveDate BETWEEN '" & FixControlDateToString(Me.txtDateFrom) & "' AND '" & FixControlDateToString(Me.txtDateTo) & "') AND (AccountType=" & Me.DropAccount.Value & ")"

            Result &= " AND (Posted=1)"

        Catch ex As Exception
            MsgBox("Where" & vbCrLf & ex.Message)
        End Try
        Return Result
    End Function
    Private Sub LoadReport()
        Try
            If Not isValid() Then Exit Sub

            Dim DT As New DataTable
            DT = DBO.ReturnDataTableFromSQL("SELECT * FROM Voucher_View " & Where() & " ORDER BY EffectiveDate")

            Dim report As New ReportDocument
            report.Load(CLS_Config.ReportPath & "Account Type Total.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)
            report.SetDataSource(DT)

            report.SetParameterValue("CompanyName", FixObjectString(CLS_Config.CompanyName))
            report.SetParameterValue("Address1", FixObjectString(CLS_Config.Address1))
            report.SetParameterValue("Address2", FixObjectString(CLS_Config.Address2))
            report.SetParameterValue("Address3", FixObjectString(CLS_Config.Address3))
            report.SetParameterValue("Tel", FixObjectString(CLS_Config.Tel))
            report.SetParameterValue("DateFrom", FixControl(Me.txtDateFrom))
            report.SetParameterValue("DateTo", FixControl(Me.txtDateTo))
            Me.CRV.ReportSource = report


        Catch ex As Exception
            MsgBox("LoadReport" & vbCrLf & ex.Message)
        End Try
    End Sub


End Class