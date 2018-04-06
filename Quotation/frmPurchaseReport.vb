Imports Microsoft.Reporting.WinForms
Imports ResourceLibrary

Public Class frmPurchaseReport

    Public Sub New()
        Threading.Thread.CurrentThread.CurrentUICulture = New Globalization.CultureInfo("en")
        InitializeComponent()
    End Sub
    Private Sub frmPurchaseReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtFrom.Value = New DateTime(Now.Year, Now.Month, Now.Day, 0, 0, 0)
        Me.txtTo.Value = New DateTime(Now.Year, Now.Month, Now.Day, 23, 59, 59)
    End Sub
    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        Try
            If Not Valid() Then Exit Sub

            Dim F As DateTime = TrimDate(txtFrom.Value)
            Dim T As DateTime = TrimDate(txtTo.Value)
            Dim FromDate As New DateTime(F.Year, F.Month, F.Day, 0, 0, 0)
            Dim ToDate As New DateTime(T.Year, T.Month, T.Day, 23, 59, 59)

            Using CONTEXT = New SaloonEntities2


                Dim ReportDataSource As New ReportDataSource("DataSet1", (From s In CONTEXT.V_PurchaseReport
                                                                              Where s.CompanyCode = _Company.Code _
                                                                              And s.EffectiveDate >= FromDate _
                                                                              And s.EffectiveDate <= ToDate
                                                                              Select s).ToList)

                Me.ReportViewer1.Reset()
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = RPTPath & "Purchase Report.rdlc"

                Me.ReportViewer1.LocalReport.SetParameters(New ReportParameter("FromDate", FromDate.ToString))
                Me.ReportViewer1.LocalReport.SetParameters(New ReportParameter("ToDate", ToDate.ToString))

                Me.ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource)
                Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
                Me.ReportViewer1.ZoomMode = ZoomMode.Percent
                Me.ReportViewer1.ZoomPercent = 100
                Me.ReportViewer1.RefreshReport()
            End Using

        Catch ex As Exception
            MsgBox("btnPreview_Click" & vbCrLf & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Function Valid() As Boolean
        Try
            If TrimDate(txtFrom.Value) = Null_Date Then
                MsgBox(Resx.Date_ & " " & Resx.Missing, MsgBoxStyle.Information)
                txtFrom.Focus()
                txtFrom.Select()
                Return False
            End If
            If TrimDate(txtTo.Value) = Null_Date Then
                MsgBox(Resx.Date_ & " " & Resx.Missing, MsgBoxStyle.Information)
                txtTo.Focus()
                txtTo.Select()
                Return False
            End If

            If txtFrom.Value > txtTo.Value Then
                MsgBox(Resx.Invalid & " " & Resx.Date_, MsgBoxStyle.Information)
                txtTo.Focus()
                txtTo.Select()
                Return False
            End If

            Return True
        Catch ex As Exception
            MsgBox("Valid" & vbCrLf & vbCrLf & ex.Message)
        End Try

    End Function
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class
