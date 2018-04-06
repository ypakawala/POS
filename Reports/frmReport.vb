Imports System.Math
Imports CrystalDecisions.CrystalReports.Engine
Imports POS.FixControls
Public Class frmReport
    Dim Report_Type As ReportType

    Public Sub New(ByVal _Report_Type As ReportType, Optional ByVal _AccNo As Integer = 0)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Report_Type = _Report_Type
        
    End Sub
    Private Sub frmReport_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, MenuStrip1.KeyUp, txtDateFrom.KeyUp, txtDateTo.KeyUp, MenuStrip1.KeyUp
        If e.KeyCode = Keys.End Then
            Me.Close()
        End If
    End Sub
    Private Sub frmReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Select Case Report_Type
                Case ReportType.CategoryWiseSale : Me.Text = "Category Wise Sale Profit Report"
                Case ReportType.SubCategoryWiseSale : Me.Text = "Sub Category Wise Sale Profit Report"
                Case ReportType.ItemWiseSale : Me.Text = "Item Wise Sale Profit Report"
                Case ReportType.CustomerWiseSale : Me.Text = "Customer Wise Sale Profit Report"
                Case ReportType.CustomerWiseSaleDetail : Me.Text = "Customer Wise Detail Sale Profit Report"
                Case ReportType.SalesBelowCost : Me.Text = "Sale Below Cost Report"
            End Select

            btnClearAll_Click(sender, e)

        Catch ex As Exception
            MsgBox("frmAccountStatement_Load" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        LoadReport()
    End Sub
    Private Sub btnClearAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClearAll.Click
        Try
            Me.txtDateFrom.Value = New Date(Now.Year, Now.Month, 1)
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

            Return True
        Catch ex As Exception
            MsgBox("isValid" & vbCrLf & ex.Message)
        End Try
    End Function
    Private Function Where() As String
        Dim Result As String = Nothing
        Try
            Select Case Report_Type
                Case ReportType.SalesBelowCost : Result = " WHERE (TransectionDate BETWEEN '" & FixControlDateToString(Me.txtDateFrom) & "' AND '" & FixControlDateToString(Me.txtDateTo) & "') AND (TotalPrice < CostPrice)"
                Case ReportType.ItemWiseSale : Result = " WHERE (TransectionDate BETWEEN '" & FixControlDateToString(Me.txtDateFrom) & "' AND '" & FixControlDateToString(Me.txtDateTo) & "') AND (TransectionTypeCode NOT IN (4,5))"
                Case Else : Result = " WHERE (TransectionDate BETWEEN '" & FixControlDateToString(Me.txtDateFrom) & "' AND '" & FixControlDateToString(Me.txtDateTo) & "')"
            End Select

          
        Catch ex As Exception
            MsgBox("Where" & vbCrLf & ex.Message)
        End Try
        Return Result
    End Function
    Private Sub LoadReport()
        Try
            If Not isValid() Then Exit Sub

            Dim DT As New DataTable

            Select Case Report_Type
                Case ReportType.CategoryWiseSale
                    DT = DBO.ReturnDataTableFromSQL("SELECT (SELECT top 1 Title FROM D_ItemCategory WHERE D_ItemCategory.Code = (SELECT top 1 Category FROM Item WHERE Item.Code = Sale_Entry.ItemCode))as ItemCategory,TotalPrice,CostPrice FROM Sale_Entry WHERE Sale_Entry.SaleCode IN ( SELECT Code FROM Sale WHERE     (Sale.TransectionDate BETWEEN '" & FixControlDateToString(Me.txtDateFrom) & "' AND '" & FixControlDateToString(Me.txtDateTo) & "'))")
                Case Else
                    DT = DBO.ReturnDataTableFromSQL("SELECT * FROM dbo.Sales_Full_View " & Where() & " ORDER BY TransectionDate")

            End Select


           

            Dim report As New ReportDocument
            Select Case Report_Type
                Case ReportType.CategoryWiseSale : report.Load(CLS_Config.ReportPath & "Category Wise Sale.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)
                Case ReportType.SubCategoryWiseSale : report.Load(CLS_Config.ReportPath & "Sub Category Wise Sale.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)
                Case ReportType.ItemWiseSale : report.Load(CLS_Config.ReportPath & "Item Wise Sale.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)
                Case ReportType.CustomerWiseSale : report.Load(CLS_Config.ReportPath & "Customer Wise Sale.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)
                Case ReportType.CustomerWiseSaleDetail : report.Load(CLS_Config.ReportPath & "Customer Wise Detail Sale.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)
                Case ReportType.SalesBelowCost : report.Load(CLS_Config.ReportPath & "Sales Below Cost.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)
            End Select

            Select Case Report_Type
                Case ReportType.SalesBelowCost : Me.CRV.DisplayGroupTree = False
                Case Else : Me.CRV.DisplayGroupTree = True
            End Select

            report.SetDataSource(DT)

            report.SetParameterValue("CompanyName", FixObjectString(CLS_Config.CompanyName))
            report.SetParameterValue("Address1", FixObjectString(CLS_Config.Address1))
            report.SetParameterValue("Address2", FixObjectString(CLS_Config.Address2))
            report.SetParameterValue("Address3", FixObjectString(CLS_Config.Address3))
            report.SetParameterValue("Tel", FixObjectString(CLS_Config.Tel))
            report.SetParameterValue("DateFrom", FixControl(Me.txtDateFrom))
            report.SetParameterValue("DateTo", FixControl(Me.txtDateTo))
            report.SetParameterValue("User", UserClass.UserName)
            Me.CRV.ReportSource = report


        Catch ex As Exception
            MsgBox("LoadReport" & vbCrLf & ex.Message)
        End Try
    End Sub


End Class