Imports System.Math
Imports CrystalDecisions.CrystalReports.Engine
Imports POS.FixControls
Public Class frmItemMovementSummary2
    Private Sub frmItemMovementSummary_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, CRV.KeyUp, DropCategory.KeyUp, MenuStrip1.KeyUp, txtDateFrom.KeyUp, txtDateTo.KeyUp, UltraExpandableGroupBox1.KeyUp
        If e.KeyCode = Keys.End Then
            Me.Close()
        End If
    End Sub
    Private Sub frmItemMovementSummary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.Cart_Blue
        Try
            FillDrop(Me.DropCategory, "Title", "Code", Table.D_ItemCategory)

            btnClearAll_Click(sender, e)
            btnSearch_Click(sender, e)
        Catch ex As Exception
            MsgBox("frmItemMovementSummary_Load" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        LoadReport()
    End Sub
    Private Sub btnClearAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClearAll.Click
        Try
            Me.txtDateFrom.Value = Now.Date
            Me.txtDateTo.Value = New DateTime(Now.Year, Now.Month, Now.Day, 23, 59, 59) 'Now.Date
            Me.DropCategory.Value = CLS_Config.DefaultCategory
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
            If FixControl(Me.DropCategory) = Nothing Then
                MSG.ErrorOk("[Category] is missing.")
                Me.DropCategory.Focus()
                Return False
            End If
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
            PARA.Add(FixControl(Me.DropCategory))
            DT = DBO.ExecuteSP_ReturnDataTable("ItemMovementSummary2", PARA)

            Dim report As New ReportDocument
            report.Load(CLS_Config.ReportPath & "Item Movement Summary 2.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)
            report.SetDataSource(DT)

            report.SetParameterValue("CompanyName", FixObjectString(CLS_Config.CompanyName))
            report.SetParameterValue("Address1", FixObjectString(CLS_Config.Address1))
            report.SetParameterValue("Address2", FixObjectString(CLS_Config.Address2))
            report.SetParameterValue("Address3", FixObjectString(CLS_Config.Address3))
            report.SetParameterValue("Tel", FixObjectString(CLS_Config.Tel))
            If Me.txtDateFrom.Value = Me.txtDateTo.Value Then
                report.SetParameterValue("ForDate", "FOR " & CType(Me.txtDateFrom.Value, Date).ToString("dd/MMM/yy"))
            Else
                report.SetParameterValue("ForDate", "BETWEEN " & CType(Me.txtDateFrom.Value, Date).ToString("dd/MMM/yy") & " AND " & CType(Me.txtDateTo.Value, Date).ToString("dd/MMM/yy"))
            End If
            Me.CRV.ReportSource = report


        Catch ex As Exception
            MsgBox("LoadReport" & vbCrLf & ex.Message)
        End Try
    End Sub

End Class