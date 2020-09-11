Imports CrystalDecisions.CrystalReports.Engine
Imports POS.FixControls

Public Class frmDailySummary
    Public Sub New()

        Try
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.InnerException.Message)
        End Try
    End Sub
    Private Sub frmDailySummary_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, CRV.KeyUp, txtDateFrom.KeyUp, txtDateTo.KeyUp, DropUser.KeyUp, UltraExpandableGroupBox1.KeyUp, DropCounter.KeyUp
        If e.KeyCode = Keys.End Then
            Me.Close()
        End If
    End Sub
    Private Sub frmDailySummary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.Cart_Blue
        Try

            FillDrop(Me.DropUser, "UserName", "Code", Table.P_User)
            FillDrop(Me.DropCounter, "Title", "Code", Table.D_Counter)

            Me.DropCounter.Value = CLS_Config.Counter
            Me.DropUser.Value = Nothing
            Me.txtDateFrom.Value = New Date(Now.Year, Now.Month, Now.Day, 4, 0, 0)
            Me.txtDateTo.Value = New Date(Now.Year, Now.Month, Now.AddDays(1).Day, 4, 0, 0)
            Me.txtDateTo.Value = Now

            If CLS_Config.Company = ZAHRABAKALA Then Me.DropCounter.Value = Nothing

            btnPreview_Click(sender, e)

        Catch ex As Exception
            MsgBox("frmDailySummary_Load" & vbCrLf & ex.Message)
        End Try
    End Sub
    Dim report As New ReportDocument

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Try
            Dim F As DateTime
            If FixControl(Me.txtDateFrom) = Null_Date Then
                MSG.ErrorOk("From date is missing.")
                Me.txtDateFrom.Focus()
                Me.txtDateFrom.SelectAll()
                Exit Sub
            Else
                F = CDate(Me.txtDateFrom.Value)
            End If

            Dim T As DateTime
            If FixControl(Me.txtDateTo) = Null_Date Then
                MSG.ErrorOk("To date is missing.")
                Me.txtDateTo.Focus()
                Me.txtDateTo.SelectAll()
                Exit Sub
            Else
                T = CDate(Me.txtDateTo.Value)
            End If

            Dim UserCode As Integer
            If FixControl(Me.DropUser) = Nothing Then
                UserCode = 0
            Else
                UserCode = CInt(Me.DropUser.Value)
            End If
            Dim Counter As Integer
            If FixControl(Me.DropCounter) = Nothing Then
                Counter = 0
            Else
                Counter = CInt(Me.DropCounter.Value)
            End If

            Dim CNTCash, CNTKnet, CNTMaster, CNTCheque, CNTCredit, CNTKnetCash, CNTMasterCash, CNTCancel As Integer
            'Dim DaT As New Date(F.Year, F.Month, F.Day)
            Sale_Count(F, T, Counter, UserCode, CNTCash, CNTKnet, CNTMaster, CNTCheque, CNTCredit, CNTKnetCash, CNTMasterCash, CNTCancel)


            'Dim CASH, KNET, MASTERCARD, CREDITPAY_IN_CASH, CREDITPAY_IN_KNET, CREDITPAY_IN_MASTERCARD, CASH_SALESRETURN, DISCOUNT, DISCOUNT_CREDIT, CREDIT, CREDIT_RETURN As Decimal


            Dim SaleCountCASH As Decimal = VoucherTotal(F, T, CLS_Config.AccCash, TransectionType.CashSale, PaymentType.Cash, True, UserCode, Counter)
            Dim CASH As Decimal = VoucherTotal(F, T, CLS_Config.AccCash, TransectionType.CashSale, PaymentType.Cash, True, UserCode, Counter)
            CASH += VoucherTotal(F, T, CLS_Config.AccCash, TransectionType.CashSale, PaymentType.KNet_Cash, True, UserCode, Counter)
            CASH += VoucherTotal(F, T, CLS_Config.AccCash, TransectionType.CashSale, PaymentType.MasterCard_Cash, True, UserCode, Counter)
            Dim KNET As Decimal = VoucherTotal(F, T, CLS_Config.AccKnet, TransectionType.CashSale, PaymentType.KNet, True, UserCode, Counter)
            KNET += VoucherTotal(F, T, CLS_Config.AccKnet, TransectionType.CashSale, PaymentType.KNet_Cash, True, UserCode, Counter)
            Dim MASTERCARD As Decimal = VoucherTotal(F, T, CLS_Config.AccMaster, TransectionType.CashSale, PaymentType.MasterCard, True, UserCode, Counter)
            MASTERCARD += VoucherTotal(F, T, CLS_Config.AccMaster, TransectionType.CashSale, PaymentType.MasterCard_Cash, True, UserCode, Counter)
            Dim CREDITPAY_IN_CASH As Decimal = VoucherTotal(F, T, CLS_Config.AccCash, TransectionType.CustomerPayment, PaymentType.Cash, True, UserCode, Counter)
            CREDITPAY_IN_CASH += VoucherTotal(F, T, CLS_Config.AccCash, TransectionType.Customer_News_Payment, PaymentType.Cash, True, UserCode, Counter)
            Dim CREDITPAY_IN_KNET As Decimal = VoucherTotal(F, T, CLS_Config.AccKnet, TransectionType.CustomerPayment, PaymentType.KNet, True, UserCode, Counter)
            Dim CREDITPAY_IN_MASTERCARD As Decimal = VoucherTotal(F, T, CLS_Config.AccMaster, TransectionType.CustomerPayment, PaymentType.MasterCard, True, UserCode, Counter)
            Dim CASH_SALESRETURN As Decimal = VoucherTotal(F, T, CLS_Config.AccSalesReturn, TransectionType.CashSaleReturn, PaymentType.Cash, True, UserCode, Counter)
            Dim DISCOUNT As Decimal = VoucherTotal(F, T, CLS_Config.AccDiscount, TransectionType.Customer_Discount, PaymentType.Cash, True, UserCode, Counter)
            DISCOUNT += VoucherTotal(F, T, CLS_Config.AccDiscount, TransectionType.Customer_Discount, PaymentType.KNet, True, UserCode, Counter)
            DISCOUNT += VoucherTotal(F, T, CLS_Config.AccDiscount, TransectionType.Customer_Discount, PaymentType.MasterCard, True, UserCode, Counter)

            Dim CREDIT As Decimal = VoucherTotal(F, T, CLS_Config.AccStock, TransectionType.CreditSale, PaymentType.Credit, False, UserCode, Counter)
            CREDIT += VoucherTotal(F, T, CLS_Config.AccStock, TransectionType.News_Subscription, PaymentType.Credit, False, UserCode, Counter)
            Dim CREDIT_RETURN As Decimal = VoucherTotal(F, T, CLS_Config.AccCreditSalesReturn, TransectionType.CreditSaleReturn, PaymentType.Credit, True, UserCode, Counter)
            Dim DISCOUNT_CREDIT As Decimal = VoucherTotal(F, T, CLS_Config.AccDiscount, TransectionType.Customer_Discount, PaymentType.Credit, True, UserCode, Counter)

            Dim CASHPROFIT As Decimal = Sale_Profit(F, T, True, False, Counter)
            Dim CREDITPROFIT As Decimal = Sale_Profit(F, T, False, False, Counter)

            Dim CARD_CASH As Decimal = 0
            Dim CARD_CASH_SALESRETURN As Decimal = 0
            Dim CARD_CREDIT As Decimal = 0
            Dim CARD_CREDIT_RETURN As Decimal = 0
            Dim CARD_CREDIT_PAY_CASH As Decimal = 0

            Dim CARD_CASHPROFIT As Decimal = 0
            Dim CARD_CREDITPROFIT As Decimal = 0
            Select Case CLS_Config.Company
                Case BOOKSHOP, MoveNPick
                    CARD_CASH = SaleTotal(F, T, TransectionType.CashSale, UserCode, Counter)
                    CARD_CASH_SALESRETURN = SaleTotal(F, T, TransectionType.CashSaleReturn, UserCode, Counter)
                    CARD_CREDIT = SaleTotal(F, T, TransectionType.CreditSale, UserCode, Counter)
                    CARD_CREDIT_RETURN = SaleTotal(F, T, TransectionType.CreditSaleReturn, UserCode, Counter)
                    CARD_CREDIT_PAY_CASH = VoucherTotal(F, T, CLS_Config.AccCash, TransectionType.Customer_Card_Payment, PaymentType.Cash, True, UserCode, Counter)

                    CARD_CASHPROFIT = Sale_Profit(F, T, True, True, Counter)
                    CARD_CREDITPROFIT = Sale_Profit(F, T, False, True, Counter)
            End Select

            CASH -= CARD_CASH
            CASH_SALESRETURN -= CARD_CASH_SALESRETURN
            CREDIT -= CARD_CREDIT
            CREDIT_RETURN -= CARD_CREDIT_RETURN

            Dim FP As New DateTime(F.Year, F.Month, F.Day)

            Dim CashPurchase As Decimal = VoucherTotal(FP, T, CLS_Config.AccCash, TransectionType.SupplierPayment, PaymentType.Cash, False, UserCode, Counter)
            Dim KnetPurchase As Decimal = VoucherTotal(FP, T, CLS_Config.AccKnet, TransectionType.SupplierPayment, PaymentType.KNet, False, UserCode, Counter)
            KnetPurchase += VoucherTotal(FP, T, CLS_Config.AccKnet, TransectionType.SupplierPayment, PaymentType.KNet_Cash, False, UserCode, Counter)
            Dim MasterCardPurchase As Decimal = VoucherTotal(FP, T, CLS_Config.AccMaster, TransectionType.SupplierPayment, PaymentType.MasterCard, False, UserCode, Counter)
            MasterCardPurchase += VoucherTotal(FP, T, CLS_Config.AccMaster, TransectionType.SupplierPayment, PaymentType.MasterCard_Cash, False, UserCode, Counter)


            Dim Expenses As Decimal = VoucherTotal(FP, T, 0, TransectionType.Expenses, PaymentType.None, True, UserCode, Counter)
            Dim Other_Revenue As Decimal = VoucherTotal(FP, T, 0, TransectionType.Other_Revenue, PaymentType.None, True, UserCode, Counter)
            Dim Drawing As Decimal = VoucherTotal(FP, T, 0, TransectionType.Drawing, PaymentType.None, True, UserCode, Counter)
            Dim Capital_Investment As Decimal = VoucherTotal(FP, T, 0, TransectionType.Capital_Investment, PaymentType.None, True, UserCode, Counter)


            Dim DT As New DataTable
            DT = DBO.ReturnDataTable("Select * from Config Where Code=1")

            Dim DT2 As New DataTable
            DT2 = DBO.ReturnDataTable("Select * from Purchase_Summary WHERE EffectiveDate BETWEEN '" & FP & "' AND '" & T & "' ")

            report = New ReportDocument
            report.Load(CLS_Config.ReportPath & "DailySummary.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)

            report.SetDataSource(DT)
            report.Subreports("Purcahse").SetDataSource(DT2)

            If Me.txtDateFrom.Value = Me.txtDateTo.Value Then
                report.SetParameterValue("SalesDate", "FOR " & CType(Me.txtDateFrom.Value, Date).ToString("dd/MMM/yy HH:mm"))
            Else
                report.SetParameterValue("SalesDate", "" & CType(Me.txtDateFrom.Value, Date).ToString("dd/MMM/yy HH:mm") & " AND " & CType(Me.txtDateTo.Value, Date).ToString("dd/MMM/yy HH:mm"))
            End If
            report.SetParameterValue("Cash", IIf(IsDBNull(CASH), 0, CASH))
            report.SetParameterValue("KNet", IIf(IsDBNull(KNET), 0, KNET))
            report.SetParameterValue("Master", IIf(IsDBNull(MASTERCARD), 0, MASTERCARD))
            report.SetParameterValue("CreditPaid", IIf(IsDBNull(CREDITPAY_IN_CASH), 0, CREDITPAY_IN_CASH))
            report.SetParameterValue("CreditKNet", IIf(IsDBNull(CREDITPAY_IN_KNET), 0, CREDITPAY_IN_KNET))
            report.SetParameterValue("CreditMaster", IIf(IsDBNull(CREDITPAY_IN_MASTERCARD), 0, CREDITPAY_IN_MASTERCARD))
            report.SetParameterValue("CashSalesReturn", IIf(IsDBNull(CASH_SALESRETURN), 0, CASH_SALESRETURN))
            report.SetParameterValue("CashDiscount", IIf(IsDBNull(DISCOUNT), 0, DISCOUNT))
            report.SetParameterValue("Credit", IIf(IsDBNull(CREDIT), 0, CREDIT))
            report.SetParameterValue("CreditSalesReturn", IIf(IsDBNull(CREDIT_RETURN), 0, CREDIT_RETURN))
            report.SetParameterValue("CreditDiscount", IIf(IsDBNull(DISCOUNT_CREDIT), 0, DISCOUNT_CREDIT))
            report.SetParameterValue("CashProfit", IIf(IsDBNull(CASHPROFIT), 0, CASHPROFIT))
            report.SetParameterValue("CreditProfit", IIf(IsDBNull(CREDITPROFIT), 0, CREDITPROFIT))
            report.SetParameterValue("CardCash", IIf(IsDBNull(CREDITPROFIT), 0, CARD_CASH))
            report.SetParameterValue("CardCredit", IIf(IsDBNull(CREDITPROFIT), 0, CARD_CREDIT))
            report.SetParameterValue("CardCashSalesReturn", IIf(IsDBNull(CREDITPROFIT), 0, CARD_CASH_SALESRETURN))
            report.SetParameterValue("CardCreditSalesReturn", IIf(IsDBNull(CREDITPROFIT), 0, CARD_CREDIT_RETURN))
            report.SetParameterValue("CardCreditPaid", IIf(IsDBNull(CREDITPROFIT), 0, CARD_CREDIT_PAY_CASH))
            report.SetParameterValue("CardCashProfit", IIf(IsDBNull(CREDITPROFIT), 0, CARD_CASHPROFIT))
            report.SetParameterValue("CardCreditProfit", IIf(IsDBNull(CREDITPROFIT), 0, CARD_CREDITPROFIT))

            report.SetParameterValue("CNTCash", IIf(IsDBNull(CNTCash), 0, CNTCash))
            report.SetParameterValue("CNTKnet", IIf(IsDBNull(CNTKnet), 0, CNTKnet))
            report.SetParameterValue("CNTMaster", IIf(IsDBNull(CNTMaster), 0, CNTMaster))
            report.SetParameterValue("CNTCheque", IIf(IsDBNull(CNTCheque), 0, CNTCheque))
            report.SetParameterValue("CNTCredit", IIf(IsDBNull(CNTCredit), 0, CNTCredit))
            report.SetParameterValue("CNTKnetCash", IIf(IsDBNull(CNTKnetCash), 0, CNTKnetCash))
            report.SetParameterValue("CNTMasterCash", IIf(IsDBNull(CNTMasterCash), 0, CNTMasterCash))
            report.SetParameterValue("CNTCancel", IIf(IsDBNull(CNTCancel), 0, CNTCancel))

            report.SetParameterValue("CashPurchase", IIf(IsDBNull(CashPurchase), 0, CashPurchase))
            report.SetParameterValue("KnetPurchase", IIf(IsDBNull(KnetPurchase), 0, KnetPurchase))
            report.SetParameterValue("MasterCardPurchase", IIf(IsDBNull(MasterCardPurchase), 0, MasterCardPurchase))


            report.SetParameterValue("Expenses", IIf(IsDBNull(Expenses), 0, Expenses))
            report.SetParameterValue("Other_Revenue", IIf(IsDBNull(Other_Revenue), 0, Other_Revenue))
            report.SetParameterValue("Drawing", IIf(IsDBNull(Drawing), 0, Drawing))
            report.SetParameterValue("Capital_Investment", IIf(IsDBNull(Capital_Investment), 0, Capital_Investment))

            Me.CRV.ReportSource = report



        Catch ex As Exception
            MsgBox("btnPreview_Click" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        report.PrintOptions.PrinterName = CLS_Config.ReceiptPrinter
        report.PrintToPrinter(1, False, 1, 2)
    End Sub
End Class