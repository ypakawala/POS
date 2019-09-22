Imports System.Math
Imports CrystalDecisions.CrystalReports.Engine
Imports POS.FixControls
Public Class frmAccountStatement
    Dim Account_Type As AccountType
    Dim CLS_Acc As New Account
    Public Sub New(ByVal _AccoutType As AccountType, Optional ByVal _AccNo As String = Nothing)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Account_Type = _AccoutType
        FillDropWithCondition(Me.DropAccount, "Title", "AccountNum", Table.Account, "Code", , , , " WHERE AccountType = " & Account_Type)
        If _AccNo <> Nothing Then
            Me.DropAccount.Value = _AccNo
            LoadReport()
        End If

    End Sub
    Private Sub frmAccountStatement_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, MenuStrip1.KeyUp, txtDateFrom.KeyUp, txtDateTo.KeyUp, DropAccount.KeyUp, MenuStrip1.KeyUp
        If e.KeyCode = Keys.End Then
            Me.Close()
        End If
    End Sub
    Private Sub frmAccountStatement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Select Case Account_Type
                Case AccountType.Bank
                    Me.Text = "Bank Statement"
                    Me.lblAccount.Text = "Bank Account"
                Case AccountType.Cash
                    Me.Text = "Cash Statement"
                    Me.lblAccount.Text = "Cash Account"
                Case AccountType.Customer
                    Me.Text = "Customer Statement"
                    Me.lblAccount.Text = "Customer Account"
                Case AccountType.Expenses
                    Me.Text = "Expenses Statement"
                    Me.lblAccount.Text = "Expenses Account"
                Case AccountType.Stock
                    Me.Text = "Stock Statement"
                    Me.lblAccount.Text = "Stock Account"
                Case AccountType.Supplier
                    Me.Text = "Supplier Statement"
                    Me.lblAccount.Text = "Supplier Account"
                Case AccountType.Expenses
                    Me.Text = "Expenses Statement"
                    Me.lblAccount.Text = "Expenses Account"
                Case AccountType.Owner
                    Me.Text = "Owner Statement"
                    Me.lblAccount.Text = "Owner Account"
                Case AccountType.Employee
                    Me.Text = "Employee Statement"
                    Me.lblAccount.Text = "Employee Account"
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
    Private Sub DropAccount_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DropAccount.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                CLS_Acc = New Account

                If IsDBNull(Me.DropAccount.Value) Or IsNothing(Me.DropAccount.Value) Then
                ElseIf Me.DropAccount.Value = Nothing Then
                Else
                    CLS_Acc = New Account
                    CLS_Acc = Get_Account(CStr(Me.DropAccount.Value))
                    If IsNothing(CLS_Acc) Then
                        MsgBox("Item Dose Not Exists")
                        Me.DropAccount.Focus()
                    Else
                        Me.DropAccount.Value = CLS_Acc.AccountNum
                        btnSearch_Click(sender, e)
                    End If
                    Exit Sub
                End If


                If IsDBNull(Me.DropAccount.Text) Or IsNothing(Me.DropAccount.Text) Then
                Else
                    CLS_Acc = New Account
                    CLS_Acc = Get_Account(CStr(Me.DropAccount.Text))
                    If IsNothing(CLS_Acc) Then
                        MsgBox("Item Dose Not Exists")
                        Me.DropAccount.Focus()
                    Else
                        Me.DropAccount.Value = CLS_Acc.AccountNum
                        btnSearch_Click(sender, e)
                    End If

                End If


            End If

        Catch ex As Exception
            MsgBox("DropAccount_KeyDown" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub DropAccount_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropAccount.ValueChanged
        Try
            If IsDBNull(Me.DropAccount.Value) Or IsNothing(Me.DropAccount.Value) Then
            ElseIf Me.DropAccount.Value = Nothing Then
            Else
                CLS_Acc = New Account
                CLS_Acc = Get_Account(CStr(Me.DropAccount.Value))
            End If
        Catch ex As Exception
            MsgBox("DropAccount_ValueChanged" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Function Get_Account(ByVal AccountNum As String) As Account
        Try
            Dim DT As New DataTable
            DT = Me.DropAccount.DataSource

            Dim CLS As New Account
            'IF BARCODE IS NULL RETURN EMPTY CLS
            If FixObjectString(AccountNum) = Nothing Then Return Nothing

            'IF AccountNum EXIST IN DS LOAD & RETURN CLS
            Dim dr() As DataRow = DT.Select(" AccountNum='" & AccountNum & "'")
            If dr.Length > 0 Then
                CLS.Code = IIf(IsDBNull(dr(0).Item("Code")), 0, dr(0).Item("Code"))
                CLS.Title = IIf(IsDBNull(dr(0).Item("Title")), 0, dr(0).Item("Title"))
                CLS.AccountNum = IIf(IsDBNull(dr(0).Item("AccountNum")), 0, dr(0).Item("AccountNum"))
                Return CLS
            End If
            'IF BARCODE DOSE NOT EXIST CONT...


            'IF AccountNum IS NOT INTEGER SKIP CHECKING BY CODE
            If IsNumeric(AccountNum) Then
                'IF CODE IS NUMERIC AND EXIST IN DS LOAD & RETURN CLS
                Dim dr3() As DataRow = DT.Select(" Code=" & CInt(AccountNum))
                If dr3.Length > 0 Then
                    CLS.Code = IIf(IsDBNull(dr3(0).Item("Code")), 0, dr3(0).Item("Code"))
                    CLS.Title = IIf(IsDBNull(dr3(0).Item("Title")), 0, dr3(0).Item("Title"))
                    CLS.AccountNum = IIf(IsDBNull(dr3(0).Item("AccountNum")), 0, dr3(0).Item("AccountNum"))
                    Return CLS
                End If
            End If

             Return Nothing
        Catch ex As Exception
            MSG.ErrorOk("[Get_Account]" & vbCrLf & ex.Message)
            Return Nothing
        End Try
    End Function
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
                MSG.ErrorOk("[ACCOUNT] is missing.")
                Me.DropAccount.Focus()
                Return False
            End If

            If IsDBNull(CLS_Acc) Or IsNothing(CLS_Acc) Then
                MSG.ErrorOk("[ACCOUNT] is missing.")
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
            Result = " WHERE (EffectiveDate BETWEEN '" & FixControlDateToString(Me.txtDateFrom) & "' AND '" & FixControlDateToString(Me.txtDateTo) & "')"

            If CLS_Acc.Code = CLS_Config.AccCashCustomer Then
                Result &= " AND (TransectionTypeCode= 1) AND (AccountCode <> " & CLS_Config.AccStock & ")"
            Else
                Result &= " AND (AccountCode = '" & CLS_Acc.Code & "')"
            End If
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
            DT = DBO.ReturnDataTableFromSQL("SELECT * FROM Voucher_View " & Where() & " ORDER BY EffectiveDate,TransectionTypeCode")

            Dim OpenBal As Decimal = 0.0
            Select Case Account_Type
                Case AccountType.Customer, AccountType.Supplier, AccountType.Employee
                    OpenBal = OpeningBalance(Me.txtDateFrom.Value, CLS_Acc.Code)
            End Select

            Dim i As Integer
            Dim PrevBalance As Double = OpenBal
            Dim debit, credit As Double
            For i = 0 To DT.Rows.Count - 1
                debit = CDec(DT.Rows(i).Item("Debit"))
                credit = CDec(DT.Rows(i).Item("Credit"))
                PrevBalance = debit - credit + PrevBalance
                DT.Rows(i).Item("Balance") = PrevBalance
            Next

            report = New ReportDocument
            If CLS_Config.A4Printer Then
                report.Load(CLS_Config.ReportPath & "Account Statement A4.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)
            Else
                report.Load(CLS_Config.ReportPath & "Account Statement.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)
            End If
            report.SetDataSource(DT)

            report.SetParameterValue("CompanyName", FixObjectString(CLS_Config.CompanyName))
            report.SetParameterValue("Address1", FixObjectString(CLS_Config.Address1))
            report.SetParameterValue("Address2", FixObjectString(CLS_Config.Address2))
            report.SetParameterValue("Address3", FixObjectString(CLS_Config.Address3))
            report.SetParameterValue("Tel", FixObjectString(CLS_Config.Tel))
            report.SetParameterValue("DateFrom", FixControl(Me.txtDateFrom))
            report.SetParameterValue("DateTo", FixControl(Me.txtDateTo))
            report.SetParameterValue("OpeningBalance", OpenBal)
            Me.CRV.ReportSource = report


        Catch ex As Exception
            MsgBox("LoadReport" & vbCrLf & ex.Message)
        End Try
    End Sub
    Dim report As New ReportDocument

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        report.PrintOptions.PrinterName = CLS_Config.ReceiptPrinter
        report.PrintToPrinter(1, False, 1, 2)
    End Sub
End Class