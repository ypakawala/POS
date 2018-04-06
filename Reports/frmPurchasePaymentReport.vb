Imports System.Math
Imports CrystalDecisions.CrystalReports.Engine
Imports POS.FixControls
Public Class frmPurchasePaymentReport
    Dim DT As New DataTable
    Public Sub New(Optional ByVal _SupplierCode As String = Nothing)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If _SupplierCode <> Nothing Then Me.DropSupplier.Value = _SupplierCode
    End Sub
    Private Sub frmPurchasePaymentReport_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, CRV.KeyUp, MenuStrip1.KeyUp, txtDateFrom.KeyUp, txtDateTo.KeyUp, UltraExpandableGroupBox1.KeyUp, DropSupplier.KeyUp, txtInvoiceNum.KeyUp
        If e.KeyCode = Keys.End Then
            Me.Close()
        End If
    End Sub
    Private Sub frmPurchasePaymentReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FillDropWithCondition(Me.DropSupplier, "Title", "AccountNum", Table.Account, "Code", , , , " WHERE AccountType = " & AccountType.Supplier)

            btnClearAll_Click(sender, e)

        Catch ex As Exception
            MsgBox("frmSailSearch_Load" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If isValid() Then LoadReport()
    End Sub
    Private Sub btnClearAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClearAll.Click
        Try

            Me.txtDateFrom.Value = Now.Date 'New Date(Now.Year, Now.Month, 1)
            Dim LastDay As Integer
            LastDay = DateAdd(DateInterval.Day, -1, DateSerial(Now.Year, Now.Month + 1, 1)).Day
            Me.txtDateTo.Value = New DateTime(Now.Year, Now.Month, Now.Day, 23, 59, 59) 'New DateTime(Now.Year, Now.Month, LastDay, 23, 59, 59)

            Me.txtDateTo.Value = Now
            Me.txtDateFrom.Focus()

            Me.DropSupplier.Focus()

        Catch ex As Exception
            MsgBox("btnClearAll_Click" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Function isValid() As Boolean
        Try
            'If TrimStr(Me.DropSupplier.Value) = Nothing Then
            '    MSG.ErrorOk("[Supplier] is missing.")
            '    Me.DropSupplier.Focus()
            '    Return False
            'End If

            If FixControl(Me.txtDateFrom) <> Null_Date Then
                If FixControl(Me.txtDateTo) <> Null_Date Then
                    If CDate(Me.txtDateFrom.Value) > CDate(Me.txtDateTo.Value) Then
                        MSG.ErrorOk("[DATE TO] should be less then [DATE FROM].")
                        Me.txtDateTo.Focus()
                        Me.txtDateTo.SelectAll()
                        Return False
                    End If
                End If
            End If

            Return True
        Catch ex As Exception
            MsgBox("isValid" & vbCrLf & ex.Message)
        End Try
    End Function
    Private Function Where() As String
        Dim Result As String = Nothing
        Try
            Result = " WHERE (1=1) "
            'Result = " WHERE SupplierCode = " & FixObjectNumber(Me.DropSupplier.SelectedRow.Cells("Code").Value)
            If TrimStr(Me.DropSupplier.Value) <> Nothing Then Result &= " AND SupplierCode = " & FixObjectNumber(Me.DropSupplier.SelectedRow.Cells("Code").Value)
            If FixControl(Me.txtDateFrom) <> Null_Date Then Result &= " AND EffectiveDate >= '" & FixControlDateToString(Me.txtDateFrom) & "'"
            If FixControl(Me.txtDateTo) <> Null_Date Then Result &= " AND EffectiveDate <= '" & FixControlDateToString(Me.txtDateTo) & "'"
            If FixControl(Me.txtInvoiceNum) <> Nothing Then Result &= " AND NetBill = '" & FixControl(Me.txtInvoiceNum) & "'"

        Catch ex As Exception
            MsgBox("Where" & vbCrLf & ex.Message)
        End Try
        Return Result
    End Function
    Private Sub LoadReport()
        Try
            Dim _Where As String = Where()
            Dim DT_Payment As New DataTable
            DT_Payment = DBO.ReturnDataTable("SELECT * FROM Purchase_Payment_View " & _Where)

            'Dim DT_Summary As New DataTable
            'DT_Summary = DBO.ReturnDataTable("SELECT * FROM Purchase_Summary WHERE SupplierCode IN (SELECT SupplierCode FROM Purchase_Payment_View " & _Where & ")")

            Dim report As New ReportDocument
            If TrimStr(Me.DropSupplier.Value) = Nothing Then
                report.Load(CLS_Config.ReportPath & "Purchase Payment.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)
            Else
                report.Load(CLS_Config.ReportPath & "Purchase Payment for Supplier.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)
            End If
            report.SetDataSource(DT_Payment)
            'report.Subreports("Purchase").SetDataSource(DT_Summary)

            report.SetParameterValue("CompanyName", FixObjectString(CLS_Config.CompanyName))
            report.SetParameterValue("Address1", FixObjectString(CLS_Config.Address1))
            report.SetParameterValue("Address2", FixObjectString(CLS_Config.Address2))
            report.SetParameterValue("Address3", FixObjectString(CLS_Config.Address3))
            report.SetParameterValue("Tel", FixObjectString(CLS_Config.Tel))
            report.SetDatabaseLogon(DatabaseLogID, DatabasePass)
            Me.CRV.ReportSource = report
            Me.CRV.DisplayGroupTree = True

        Catch ex As Exception
            MsgBox("LoadReport" & vbCrLf & ex.Message)
        End Try
    End Sub

End Class