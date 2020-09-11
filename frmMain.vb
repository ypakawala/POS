Imports System.Windows.Forms

Public Class frmMain

    Public Sub PrintOnOff(ByVal _ON As Boolean)
        Try
            If _ON = True Then
                Printer_On = True
                Me.PrintToolStripMenuItem.BackColor = Color.Gold
            Else
                Printer_On = False
                Me.PrintToolStripMenuItem.BackColor = Color.Transparent
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not IsNothing(frmSalesIns) Then frmSalesIns.Close()
        'Update_Last_Bill()
        'PlaySoundFile("START.WAV")
    End Sub
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.Cart_Blue
        Try
            'frmMainIns.MenuStrip1.BackColor = Color.DodgerBlue
            'Me.StatusStrip.BackColor = Color.DodgerBlue

            Me.btnMembership.Visible = CLS_Config.MembershipSystem

            Me.Text = "POS System for -------   " & CLS_Config.CompanyName

            Me.lblLoginName.Text = "User Name: " & UserClass.UserName
            Me.lblDesignation.Text = "Designation: " & UserClass.Designation
            Me.lblVersion.Text = System.String.Format(Me.lblVersion.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

            Permission()
            PrintOnOff(True)

            'Set the specified printer driver as the "default printer."
            'The name in quotes should match the Windows Printer Name exactly
            '2015.10.31'For Each prnPrinter In Printers
            '2015.10.31'If prnPrinter.DeviceName = CLS_Config.ReceiptPrinter Then
            '2015.10.31'Printer_ = prnPrinter
            '2015.10.31'Exit For
            '2015.10.31' End If
            '2015.10.31'Next


            'If CLS_Config.Company = ZAHRABAKALA Then
            '    Me.EmployeeStatementToolStripMenuItem1.Visible = False
            '    Me.SalaryToolStripMenuItem.Visible = False
            '    Me.btnCheque.Visible = False
            'End If

            CostPrice_On = False
            'BillNumber = Get_Last_Bill()

            Select Case CLS_Config.Company
                Case ZAHRABAKALA
                    SalaryToolStripMenuItem.Visible = False
            End Select

            If CLS_Config.OpenSalesForm And UserClass.Allow_POS Then SaleToolStripMenuItem_Click(sender, e)
        Catch ex As Exception
            MSG.ErrorOk("[frmMain_Load]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            Me.ProgressBar1.Visible = True
            Me.ProgressBar1.Value = Me.ProgressBar1.Value + 2
            Me.Cursor = Cursors.WaitCursor
            If Me.ProgressBar1.Value = 100 Then
                Timer1.Enabled = False
                Me.ProgressBar1.Value = 0
                Me.ProgressBar1.Visible = False
                Me.Cursor = Cursors.Default
            End If
        Catch
            MsgBox(Err.Description, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub Permission()
        Try
            Me.btnItems.Visible = UserClass.Allow_Item
            Me.btnItemList.Visible = UserClass.Allow_Item
            Me.btnPrintBarcode.Visible = UserClass.Allow_Print_Barcode
            Me.btnItemCategory.Visible = UserClass.Allow_Files
            Me.btnItemSubCategory.Visible = UserClass.Allow_Files
            Me.btnUMC.Visible = UserClass.Allow_Files
            Me.btnConfig.Visible = UserClass.IsAdmin
            Me.Backup.Visible = UserClass.IsAdmin
            Me.SubscribeToolStripMenuItem.Visible = UserClass.Allow_Subscription_Add
            Me.UnsubscribeToolStripMenuItem.Visible = UserClass.Allow_Subscription_Delete
            Me.SubscriptionPaymentToolStripMenuItem.Visible = UserClass.Allow_Subscription_Pay
            Me.UsersToolStripMenuItem.Visible = UserClass.Allow_Users
            Me.SaleToolStripMenuItem.Visible = UserClass.Allow_POS
            Me.btnSalesReturn.Visible = UserClass.Allow_Sale_Delete
            Me.btnQuotation.Visible = UserClass.Allow_Quotation
            Me.CostPriceToolStripMenuItem.Visible = UserClass.Allow_POS
            Me.PrintToolStripMenuItem.Visible = UserClass.Allow_POS
            Me.HelpToolStripMenuItem.Visible = UserClass.Allow_POS
            Me.PurchaseToolStripMenuItem1.Visible = UserClass.Allow_Purchase

            Me.btnItemClass.Visible = False

            Me.SupplierToolStripMenuItem.Visible = UserClass.Allow_Account_Supplier
            Me.CustomerToolStripMenuItem1.Visible = UserClass.Allow_Account_Customer
            Me.CashToolStripMenuItem.Visible = UserClass.Allow_Account_Cash
            Me.BankToolStripMenuItem.Visible = UserClass.Allow_Account_Bank
            Me.OwnerToolStripMenuItem1.Visible = UserClass.Allow_Account_Owners
            Me.OtherRevenueToolStripMenuItem.Visible = UserClass.Allow_Account_OtherRev
            Me.ExpensesToolStripMenuItem.Visible = UserClass.Allow_Account_Exp
            Me.VoucherToolStripMenuItem.Visible = UserClass.Allow_Account_Voucher

            If Not UserClass.Allow_Account_Supplier And _
            Not UserClass.Allow_Account_Customer And _
            Not UserClass.Allow_Account_Cash And _
            Not UserClass.Allow_Account_Bank And _
            Not UserClass.Allow_Account_Owners And _
            Not UserClass.Allow_Account_OtherRev And _
            Not UserClass.Allow_Account_Exp And _
            Not UserClass.Allow_Account_Voucher Then
                Me.AccountsToolStripMenuItem.Visible = False
            End If

            Me.DailySummaryToolStripMenuItem.Visible = UserClass.Rpt_DailySummary
            Me.SalesSearchToolStripMenuItem.Visible = UserClass.Rpt_SalesSearch
            Me.mmSalesReports.Visible = UserClass.Rpt_SalesReports
            Me.mmInventoryReports.Visible = UserClass.Rpt_InventoryReports
            Me.mmItemReports.Visible = UserClass.Rpt_ItemReports
            Me.mmCustomerReports.Visible = UserClass.Rpt_CustomerReports
            Me.mmAlert.Visible = UserClass.Rpt_Alert
            Me.SubscriptionToolStripMenuItem.Visible = UserClass.Rpt_Subscription
            'Me.mmInventoryReports.Visible = UserClass.Rpt_PurchaseReport

            If Not UserClass.Rpt_DailySummary And _
            Not UserClass.Rpt_SalesSearch And _
            Not UserClass.Rpt_SalesReports And _
            Not UserClass.Rpt_InventoryReports And _
            Not UserClass.Rpt_ItemReports And _
            Not UserClass.Rpt_CustomerReports And _
            Not UserClass.Rpt_Alert And _
            Not UserClass.Rpt_Subscription Then
                Me.ReportsToolStripMenuItem.Visible = False
            End If

            Me.CustomerStatementToolStripMenuItem.Visible = UserClass.Allow_Statement_Customer
            Me.CustomerStatementToolStripMenuItem2.Visible = UserClass.Allow_Statement_Customer
            Me.SupplierStatementToolStripMenuItem2.Visible = UserClass.Allow_Statement_Supplier
            Me.CashStatementToolStripMenuItem.Visible = UserClass.Allow_Statement_Cash
            Me.BankStatementToolStripMenuItem.Visible = UserClass.Allow_Statement_Bank
            Me.OwnersStatementToolStripMenuItem.Visible = UserClass.Allow_Statement_Owner
            Me.OtherRevenueStatementToolStripMenuItem.Visible = UserClass.Allow_Statement_OtherRev
            Me.ExpensesStatementToolStripMenuItem.Visible = UserClass.Allow_Statement_Exp


            If Not UserClass.Allow_Statement_Customer And _
            Not UserClass.Allow_Statement_Supplier And _
            Not UserClass.Allow_Statement_Cash And _
            Not UserClass.Allow_Statement_Bank And _
            Not UserClass.Allow_Statement_Owner And _
            Not UserClass.Allow_Statement_OtherRev And _
            Not UserClass.Allow_Statement_Exp Then
                Me.StatementsToolStripMenuItem.Visible = False
            End If

            If Not UserClass.IsAdmin AndAlso UserClass.Allow_Salary Then
                Me.GenerateSalaryToolStripMenuItem.Visible = False
            ElseIf Not UserClass.IsAdmin AndAlso Not UserClass.Allow_Salary Then
                Me.SalaryToolStripMenuItem.Visible = False
            End If

        Catch ex As Exception
            MSG.ErrorOk("[Permission]" & vbCrLf & ex.Message)
        End Try
    End Sub
    'LIST
    Private Sub btnItemList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnItemList.Click
        Dim FRM As New frmItemList
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    Private Sub btnItems_Click(sender As Object, e As EventArgs) Handles btnItems.Click
        Try
            Dim FRM As New frmItem
            FRM.Show()
        Catch ex As Exception
            MsgBox("[btnItems_Click]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnItemClass_Click(sender As Object, e As EventArgs) Handles btnItemClass.Click
        If IsNothing(frmItemClassListIns) Then
            frmItemClassListIns = New frmItemClassList
            frmItemClassListIns.MdiParent = Me
            frmItemClassListIns.Show()
        End If
    End Sub
    Private Sub btnPrintBarcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintBarcode.Click
        Dim FRM As New frmBarcode(0, False)
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    Private Sub btnItemCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnItemCategory.Click
        Dim FRM As New frmDynamicList
        FRM.MdiParent = Me
        FRM.TableName = Table.D_ItemCategory
        FRM.Show()
    End Sub
    Private Sub btnItemSubCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnItemSubCategory.Click
        Dim FRM As New frmDynamicList
        FRM.MdiParent = Me
        FRM.TableName = Table.D_ItemSubCategory
        FRM.Show()
    End Sub
    Private Sub btnUMC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUMC.Click
        Dim FRM As New frmDynamicList
        FRM.MdiParent = Me
        FRM.TableName = Table.D_UMCType
        FRM.Show()
    End Sub
    Private Sub btnCounterList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub SubscribeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubscribeToolStripMenuItem.Click
        Dim FRM As New frmSubscription
        FRM.ShowDialog()
    End Sub
    Private Sub UnsubscribeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnsubscribeToolStripMenuItem.Click
        Dim FRM As New frmUnsubscription
        FRM.ShowDialog()
    End Sub
    Private Sub SubscriptionPaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubscriptionPaymentToolStripMenuItem.Click
        Dim FRM As New frmSubscriptionPay
        FRM.ShowDialog()
    End Sub
    Private Sub ChangePasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        Dim FRM As New frmChnagePassword
        FRM.ShowDialog()
    End Sub
    Private Sub UsersToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UsersToolStripMenuItem.Click
        Dim FRM As New frmUsers
        FRM.ShowDialog()
    End Sub
    Private Sub Backup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Backup.Click
        Try
            Dim SaveDialog As New SaveFileDialog()
            SaveDialog.Filter = "Bak File|*.bak"
            SaveDialog.Title = "Save an bak File"
            SaveDialog.InitialDirectory = "C:\"
            SaveDialog.ShowDialog()
            If SaveDialog.FileName <> "" Then
                If SaveDialog.FileName = "C:\" Or SaveDialog.FileName = "D:\" Or SaveDialog.FileName = "E:\" Then
                    MsgBox("Invalid Path")
                Else
                    DBO.DatabaseBackups(SaveDialog.FileName)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfig.Click
        Dim FRM As New frmConfig
        FRM.MdiParent = Me
        FRM.TableName = Table.Config
        FRM.Show()
    End Sub
    'ACTION
    Private Sub SaleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaleToolStripMenuItem.Click
        Try
            'If CLS_Config.NewSalesScreen Then
            '    If IsNothing(frmSales2Ins) Then
            '        frmSales2Ins = New frmSales2
            '        frmSales2Ins.MdiParent = Me
            '        frmSales2Ins.Show()
            '    End If
            'Else
            If IsNothing(frmSalesIns) Then
                frmSalesIns = New frmSales(False)
                frmSalesIns.MdiParent = Me
                frmSalesIns.Show()
            End If
            'End If
        Catch ex As Exception
            MsgBox("[SalesToolStripMenuItem1_Click]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnSalesReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalesReturn.Click
        Try
            'If CLS_Config.NewSalesScreen Then
            '    If IsNothing(frmSales2Ins) Then
            '        frmSales2Ins = New frmSales2
            '        frmSales2Ins.MdiParent = Me
            '        frmSales2Ins.Show()
            '    End If
            'Else
            If IsNothing(frmSalesIns) Then
                frmSalesIns = New frmSales(True)
                frmSalesIns.MdiParent = Me
                frmSalesIns.Show()
            End If
            'End If
        Catch ex As Exception
            MsgBox("[SalesToolStripMenuItem1_Click]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnQuotation_Click(sender As Object, e As EventArgs) Handles btnQuotation.Click
        If IsNothing(frmQuotationListIns) Then
            frmQuotationListIns = New frmQuotationList
            frmQuotationListIns.MdiParent = Me
            frmQuotationListIns.Show()
        End If
    End Sub
    Private Sub PurchaseToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseToolStripMenuItem1.Click
        'Dim FRM As New frmPurchase
        'FRM.Show()
        If IsNothing(frmPurchaseIns) Then
            frmPurchaseIns = New frmPurchase
            frmPurchaseIns.MdiParent = Me
            frmPurchaseIns.Show()
        End If
    End Sub
    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        If Me.PrintToolStripMenuItem.Checked = True Then
            PrintOnOff(True)
        Else
            PrintOnOff(False)
        End If
    End Sub
    Private Sub CostPriceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CostPriceToolStripMenuItem.Click
        Try
            If Me.CostPriceToolStripMenuItem.Checked = True Then
                CostPrice_On = True
                Me.MenuStrip1.BackColor = Color.OrangeRed
            Else
                CostPrice_On = False
                Me.MenuStrip1.BackColor = Color.DodgerBlue
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub HelpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpToolStripMenuItem.Click
        MSG.InfoOk(Help)
    End Sub
    'ACCOUNT
    Private Sub CustomerToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerToolStripMenuItem1.Click
        Dim FRM As New frmDynamicList
        FRM.MdiParent = Me
        FRM.TableName = Table.Account
        FRM.AccountType = AccountType.Customer
        FRM.Show()
    End Sub
    Private Sub SupplierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierToolStripMenuItem.Click
        Dim FRM As New frmDynamicList
        FRM.MdiParent = Me
        FRM.TableName = Table.Account
        FRM.AccountType = AccountType.Supplier
        FRM.Show()
    End Sub
    Private Sub AssetsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CashToolStripMenuItem.Click
        Dim FRM As New frmDynamicList
        FRM.MdiParent = Me
        FRM.TableName = Table.Account
        FRM.AccountType = AccountType.Cash
        FRM.Show()
    End Sub
    Private Sub LibilitiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankToolStripMenuItem.Click
        Dim FRM As New frmDynamicList
        FRM.MdiParent = Me
        FRM.TableName = Table.Account
        FRM.AccountType = AccountType.Bank
        FRM.Show()
    End Sub
    Private Sub OwnerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OwnerToolStripMenuItem1.Click
        Dim FRM As New frmDynamicList
        FRM.MdiParent = Me
        FRM.TableName = Table.Account
        FRM.AccountType = AccountType.Owner
        FRM.Show()
    End Sub
    Private Sub EmployeeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeeToolStripMenuItem.Click
        Dim FRM As New frmDynamicList
        FRM.MdiParent = Me
        FRM.TableName = Table.Account
        FRM.AccountType = AccountType.Employee
        FRM.Show()
    End Sub
    Private Sub OtherRevenueToolStripMenuItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OtherRevenueToolStripMenuItem.Click
        Dim FRM As New frmDynamicList
        FRM.MdiParent = Me
        FRM.TableName = Table.Account
        FRM.AccountType = AccountType.Other_Revenue
        FRM.Show()
    End Sub
    Private Sub ExpensesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpensesToolStripMenuItem.Click
        Dim FRM As New frmDynamicList
        FRM.MdiParent = Me
        FRM.TableName = Table.Account
        FRM.AccountType = AccountType.Expenses
        FRM.Show()
    End Sub
    Private Sub VoucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VoucherToolStripMenuItem.Click
        Dim FRM As New frmVoucher
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    Private Sub btnCheque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheque.Click
        If IsNothing(frmChequeIns) Then
            frmChequeIns = New frmCheque
            frmChequeIns.MdiParent = Me
            frmChequeIns.Show()
        End If
    End Sub
    'REPORTS
    Private Sub DailySummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DailySummaryToolStripMenuItem.Click
        Dim FRM As New frmDailySummary
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    Private Sub SalesSearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesSearchToolStripMenuItem.Click
        Dim FRM As New frmSailSearch
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    'SALES REPORTS
    Private Sub btnSalesDiscountInBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalesDiscountInBill.Click
        Dim FRM As New frmSalesDiscountInBill
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    Private Sub btnSalesDiscount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalesDiscount.Click
        Dim FRM As New frmSalesDiscount(False)
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    Private Sub btnSalesDiscountReceipt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalesDiscountReceipt.Click
        Dim FRM As New frmSalesDiscount(True)
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    Private Sub CategoryWiseSaleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CategoryWiseSaleToolStripMenuItem.Click
        Dim FRM As New frmReport(ReportType.CategoryWiseSale)
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    Private Sub SubCategoryWiseSaleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubCategoryWiseSaleToolStripMenuItem.Click
        Dim FRM As New frmReport(ReportType.SubCategoryWiseSale)
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    Private Sub ItemWiseSaleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemWiseSaleToolStripMenuItem.Click
        Dim FRM As New frmReport(ReportType.ItemWiseSale)
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    Private Sub CustomerWiseSaleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerWiseSaleToolStripMenuItem.Click
        Dim FRM As New frmReport(ReportType.CustomerWiseSale)
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    Private Sub CustomerWiseSaleDetailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerWiseSaleDetailToolStripMenuItem.Click
        Dim FRM As New frmReport(ReportType.CustomerWiseSaleDetail)
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    Private Sub SalesBelowCostToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesBelowCostToolStripMenuItem.Click
        Dim FRM As New frmReport(ReportType.SalesBelowCost)
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    Private Sub btnSaleCancelSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaleCancelSearch.Click
        Dim FRM As New frmSailCancelSearch
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    'INVENTORY REPORTS
    Private Sub AdjustmentReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdjustmentReportToolStripMenuItem.Click

    End Sub
    Private Sub StockBelowLevelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockBelowLevelToolStripMenuItem.Click

    End Sub
    Private Sub SlowMovementReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SlowMovementReportToolStripMenuItem.Click
        Dim FRM As New frmSlowMovement
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    Private Sub TotalStockValueByCategoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TotalStockValueByCategoryToolStripMenuItem.Click

    End Sub
    Private Sub TotalStockValueBySubCategoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TotalStockValueBySubCategoryToolStripMenuItem.Click

    End Sub
    Private Sub TotalStockValueToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TotalStockValueToolStripMenuItem.Click

    End Sub
    'ITEM REPORTS
    Private Sub ItemTuenoverToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemTurnoverToolStripMenuItem.Click

    End Sub
    Private Sub ItemMovementSummary2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemMovementSummary2ToolStripMenuItem.Click
        Dim FRM As New frmItemMovementSummary2
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    Private Sub ItemSalesMovementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemSalesMovementToolStripMenuItem.Click
        Dim FRM As New frmItemSalesMovement
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    Private Sub btnItemMovement_Click(sender As Object, e As EventArgs) Handles btnItemMovement.Click
        Dim frm As New frmItemMovement
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub ItemMovementSummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemMovementSummaryToolStripMenuItem.Click
        Dim FRM As New frmItemMovementSummary
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    Private Sub btnItemDrillDownEnquiry_Click(sender As System.Object, e As System.EventArgs) Handles btnItemDrillDownEnquiry.Click
        Dim FRM As New frmItemDrillDownEnquiry
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    'CUSTOMER REPORTS
    Private Sub btnCustomerHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomerHistory.Click
        Dim FRM As New frmCustomerHistory
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    Private Sub CustomerRotationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerRotationToolStripMenuItem.Click
        Dim FRM As New frmCustomerRotation
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    Private Sub CustomerStatementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerStatementToolStripMenuItem.Click
        Dim FRM As New frmAccountStatement(AccountType.Customer)
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    Private Sub btnCustomerSales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomerSales.Click
        Dim FRM As New frmCustomerSales
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    Private Sub btnCustomerPaid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomerPaid.Click
        Dim FRM As New frmCustomerPaid
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    Private Sub btnCustomerBalance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomerBalance.Click
        Dim FRM As New frmAccountBalance(AccountType.Customer)
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    Private Sub btnCustomerBalanceInDuration_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomerBalanceInDuration.Click
        Dim FRM As New frmCustomerBalanceInDuration
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    Private Sub btnCustomerMonthlyBalance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomerMonthlyBalance.Click
        Dim FRM As New frmCustomerMonthlyBalance
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    'ALERT REPORTS
    Private Sub ItemAlertToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemAlertToolStripMenuItem.Click
        Dim FRM As New frmItemAlert
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    Private Sub ItemExpiryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemExpiryToolStripMenuItem.Click
        Dim FRM As New frmItemExpiry
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    Private Sub SubscriptionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubscriptionToolStripMenuItem.Click
        Dim FRM As New frmSubscriptionReport
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    'STATEMENTS
    Private Sub CashStatementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CashStatementToolStripMenuItem.Click
        Dim FRM As New frmAccountStatement(AccountType.Cash)
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    Private Sub BankStatementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankStatementToolStripMenuItem.Click
        Dim FRM As New frmAccountStatement(AccountType.Bank)
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    Private Sub OwnersStatementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OwnersStatementToolStripMenuItem.Click
        Dim FRM As New frmAccountStatement(AccountType.Owner)
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    Private Sub OtherRevenueStatementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OtherRevenueStatementToolStripMenuItem.Click
        Dim FRM As New frmAccountStatement(AccountType.Other_Revenue)
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    Private Sub ExpensesStatementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpensesStatementToolStripMenuItem.Click
        Dim FRM As New frmAccountStatement(AccountType.Expenses)
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    Private Sub CustomerStatementToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerStatementToolStripMenuItem2.Click
        Dim FRM As New frmAccountStatement(AccountType.Customer)
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    Private Sub SupplierStatementToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierStatementToolStripMenuItem2.Click
        Dim FRM As New frmAccountStatement(AccountType.Supplier)
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    Private Sub EmployeeStatementToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeeStatementToolStripMenuItem1.Click
        Dim FRM As New frmAccountStatement(AccountType.Employee)
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    'SALARY   
    Private Sub GenerateSalaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerateSalaryToolStripMenuItem.Click
        Dim frm As New frmPassword
        If frm.ShowDialog = Windows.Forms.DialogResult.Yes Then
            If IsNothing(frmGenerateSalaryIns) Then
                frmGenerateSalaryIns = New frmGenerateSalary
                frmGenerateSalaryIns.MdiParent = Me
                frmGenerateSalaryIns.Show()
            End If
        End If
    End Sub
    Private Sub EmployeePaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeePaymentToolStripMenuItem.Click
        If IsNothing(frmSalaryPaymentListIns) Then
            frmSalaryPaymentListIns = New frmSalaryPaymentList
            frmSalaryPaymentListIns.MdiParent = Me
            frmSalaryPaymentListIns.Show()
        End If
    End Sub
    Private Sub btnTransectionTotalbyAccountType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccountTypeTotal.Click
        Dim FRM As New frmAccountTypeTotal()
        FRM.MdiParent = Me
        FRM.Show()
    End Sub
    
    

    Private Sub btnPromotion_Click(sender As Object, e As EventArgs) Handles btnPromotion.Click
        Dim FRM As New frmDynamicList
        FRM.MdiParent = Me
        FRM.TableName = Table.V_Promotion
        FRM.FK = Nothing
        FRM.Show()
    End Sub

    Private Sub btnMembership_Click(sender As Object, e As EventArgs) Handles btnMembership.Click
        Dim frm As New frmMemberhipList(0)
        frm.ParentForm = "frmMain"
        frm.Owner = Me
        frm.ShowDialog()

    End Sub

    Private Sub btnReward_Click(sender As Object, e As EventArgs) Handles btnReward.Click
        Dim FRM As New frmDynamicList
        FRM.MdiParent = Me
        FRM.TableName = Table.Reward
        FRM.FK = Nothing
        FRM.Show()
    End Sub

End Class