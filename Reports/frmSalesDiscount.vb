Imports System.Math
Imports CrystalDecisions.CrystalReports.Engine
Imports POS.FixControls
Public Class frmSalesDiscount
    Dim Receipt As Boolean = False
    Public Sub New(ByVal _Receipt As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Receipt = _Receipt
        If Receipt Then
            Me.Text = "Sales Discount Receipt"
        Else
            Me.Text = "Sales Discount"
        End If
    End Sub
    Private Sub frmSalesDiscount_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, MenuStrip1.KeyUp, txtDateFrom.KeyUp, txtDateTo.KeyUp, DropCustomer.KeyUp, DropUser.KeyUp, MenuStrip1.KeyUp
        If e.KeyCode = Keys.End Then
            Me.Close()
        End If
    End Sub
    Private Sub frmSalesDiscount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FillDropWithCondition(Me.DropCustomer, "Title", "AccountNum", Table.Account, "Code", , , , " WHERE AccountType = " & AccountType.Customer)
            FillDrop(Me.DropUser, "UserName", "Code", Table.P_User)

            Me.chkAtSale.Checked = True
            Me.chkAtPayment.Checked = True
            Me.txtDateFrom.Value = Now.Date
            Me.txtDateTo.Value = New DateTime(Now.Year, Now.Month, Now.Day, 23, 59, 59) 'Now
            Me.txtDateFrom.Focus()

        Catch ex As Exception
            MsgBox("frmSailSearch_Load" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        LoadReport()
    End Sub
    Private Sub btnClearAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClearAll.Click
        Try
            Me.txtDateFrom.Value = Now.Date
            Me.txtDateTo.Value = Now
            Me.DropCustomer.Value = Nothing
            Me.DropUser.Value = Nothing

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
            'If Not isValid() Then Exit Sub

            Dim Customer As String = getValueFromDrop(CType(Me.DropCustomer.DataSource, DataTable), "AccountNum", FixControl(Me.DropCustomer), "Code")
            Dim PARA As New ArrayList
            PARA.Add(FixControl(Me.txtDateFrom))
            PARA.Add(FixControl(Me.txtDateTo))
            PARA.Add(Customer)
            PARA.Add(FixControl(Me.DropUser))

            If FixObjectBoolean(Me.chkAtSale.Checked) And Not FixObjectBoolean(Me.chkAtPayment.Checked) Then
                PARA.Add(1)
            ElseIf Not FixObjectBoolean(Me.chkAtSale.Checked) And FixObjectBoolean(Me.chkAtPayment.Checked) Then
                PARA.Add(2)
            Else
                PARA.Add(0)
            End If

            Dim DT As New DataTable
            DT = DBO.ExecuteSP_ReturnDataTable("VoucherDiscount", PARA)
            DT.TableName = "VoucherDiscountView"

            Dim report As New ReportDocument
            If Receipt Then
                report.Load(CLS_Config.ReportPath & "Sales Discount Receipt.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)
            Else
                report.Load(CLS_Config.ReportPath & "Sales Discount.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)
            End If

            report.SetDataSource(DT)

            report.SetParameterValue("CompanyName", FixObjectString(CLS_Config.CompanyName))
            report.SetParameterValue("Address1", FixObjectString(CLS_Config.Address1))
            report.SetParameterValue("Address2", FixObjectString(CLS_Config.Address2))
            report.SetParameterValue("Address3", FixObjectString(CLS_Config.Address3))
            report.SetParameterValue("Tel", FixObjectString(CLS_Config.Tel))
            Me.CRV.ReportSource = report
            Me.CRV.DisplayGroupTree = True


        Catch ex As Exception
            MsgBox("LoadReport" & vbCrLf & ex.Message)
        End Try
    End Sub

End Class