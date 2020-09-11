Imports System.Math
Imports CrystalDecisions.CrystalReports.Engine
Imports POS.FixControls
Public Class frmPurchaseReport
    Dim DT As New DataTable
    Public Sub New(Optional ByVal _SupplierCode As String = Nothing)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If _SupplierCode <> Nothing Then Me.DropSupplier.Value = _SupplierCode
    End Sub
    Private Sub frmPurchaseReport_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, CRV.KeyUp, MenuStrip1.KeyUp, txtDateFrom.KeyUp, txtDateTo.KeyUp, UltraExpandableGroupBox1.KeyUp, DropSupplier.KeyUp, txtInvoiceNum.KeyUp
        If e.KeyCode = Keys.End Then
            Me.Close()
        End If
    End Sub
    Private Sub frmPurchaseReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.Cart_Blue
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

            Me.txtDateFrom.Value = Now.Date ' New Date(Now.Year, Now.Month, 1)
            Dim LastDay As Integer
            LastDay = DateAdd(DateInterval.Day, -1, DateSerial(Now.Year, Now.Month + 1, 1)).Day
            Me.txtDateTo.Value = New DateTime(Now.Year, Now.Month, Now.Day, 23, 59, 59) ' New DateTime(Now.Year, Now.Month, LastDay, 23, 59, 59)

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
            'If FixControl(Me.DropSupplier) = Nothing Then
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
    Private Function WhereReturn() As String
        Dim Result As String = Nothing
        Try
            Result = " WHERE (1=1) "
            'Result = " WHERE (SupplierCode = " & FixObjectNumber(Me.DropSupplier.SelectedRow.Cells("Code").Value) & ")"
            If TrimStr(Me.DropSupplier.Value) <> Nothing Then Result &= " AND SupplierCode = " & FixObjectNumber(Me.DropSupplier.SelectedRow.Cells("Code").Value)
            If FixControl(Me.txtDateFrom) <> Null_Date Then Result &= " AND (EffectiveDate >= '" & FixControlDateToString(Me.txtDateFrom) & "')"
            If FixControl(Me.txtDateTo) <> Null_Date Then Result &= " AND (EffectiveDate <= '" & FixControlDateToString(Me.txtDateTo) & "')"
            Result &= " AND (Posted=1) "
        Catch ex As Exception
            MsgBox("Where" & vbCrLf & ex.Message)
        End Try
        Return Result
    End Function
    Private Sub LoadReport()
        Try

            Dim report As New ReportDocument
            Dim _Where As String = Where()
            Dim DT_Summary As New DataTable
            Dim DT_Entry As New DataTable
            Dim DT_Returned As New DataTable
            Dim DT_Payment As New DataTable

            


            If TrimStr(Me.DropSupplier.Value) = Nothing Then
                DT_Summary = DBO.ReturnDataTable("SELECT * FROM Purchase_Summary " & _Where)
                DT_Entry = DBO.ReturnDataTable("SELECT * FROM Purchase_Entry_View " & _Where)
                'DT_Returned = DBO.ReturnDataTable("SELECT * FROM dbo.Purchase_Return_Entry_View " & WhereReturn())
                DT_Returned = DBO.ReturnDataTable("SELECT * FROM dbo.Purchase_Return_Entry_View WHERE PurchaseFromCode IN (SELECT code FROM Purchase_Entry_View " & _Where & " )")
                'DT_Payment = DBO.ReturnDataTable("SELECT * FROM Purchase_Payment_View " & _Where)
                DT_Payment = DBO.ReturnDataTable("SELECT * FROM Purchase_Payment_View WHERE PurchaseCode IN (SELECT Code FROM Purchase_Summary " & _Where & ") ")
                report.Load(CLS_Config.ReportPath & "Purchase Rotation.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)
            Else
                DT_Summary = DBO.ReturnDataTable("SELECT * FROM Purchase_Summary " & _Where)
                DT_Entry = DBO.ReturnDataTable("SELECT * FROM Purchase_Entry_View " & _Where)
                DT_Returned = DBO.ReturnDataTable("SELECT * FROM dbo.Purchase_Return_Entry_View " & WhereReturn())
                DT_Payment = DBO.ReturnDataTable("SELECT * FROM Purchase_Payment_View WHERE SupplierCode IN (SELECT SupplierCode FROM Purchase_Summary " & _Where & ")")
                report.Load(CLS_Config.ReportPath & "Purchase.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)
            End If
           report.SetDataSource(DT_Summary)
            report.Subreports("PurchaseEntry").SetDataSource(DT_Entry)
            report.Subreports("Payment").SetDataSource(DT_Payment)
            report.Subreports("Returned").SetDataSource(DT_Returned)

            report.SetParameterValue("CompanyName", FixObjectString(CLS_Config.CompanyName))
            report.SetParameterValue("Address1", FixObjectString(CLS_Config.Address1))
            report.SetParameterValue("Address2", FixObjectString(CLS_Config.Address2))
            report.SetParameterValue("Address3", FixObjectString(CLS_Config.Address3))
            report.SetParameterValue("Tel", FixObjectString(CLS_Config.Tel))
            Me.CRV.ReportSource = report

        Catch ex As Exception
            MsgBox("LoadReport" & vbCrLf & ex.Message)
        End Try
    End Sub

End Class