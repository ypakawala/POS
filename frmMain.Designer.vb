<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits DevComponents.DotNetBar.Metro.MetroForm
    'Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.lblLoginName = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblDesignation = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.lblVersion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.UltraTabbedMdiManager1 = New Infragistics.Win.UltraWinTabbedMdi.UltraTabbedMdiManager(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnItemList = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnItems = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnItemClass = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnPrintBarcode = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnItemCategory = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnItemSubCategory = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnUMC = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.SubscribeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnsubscribeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SubscriptionPaymentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.ChangePasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.Backup = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnConfig = New System.Windows.Forms.ToolStripMenuItem()
        Me.OperationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSalesReturn = New System.Windows.Forms.ToolStripMenuItem()
        Me.PurchaseToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnPromotion = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnMembership = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnQuotation = New System.Windows.Forms.ToolStripMenuItem()
        Me.AccountsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupplierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomerToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CashToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BankToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OwnerToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmployeeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.OtherRevenueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExpensesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.VoucherToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCheque = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DailySummaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalesSearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mmSalesReports = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSalesDiscountInBill = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSalesDiscountReceipt = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSalesDiscount = New System.Windows.Forms.ToolStripMenuItem()
        Me.CategoryWiseSaleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SubCategoryWiseSaleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemWiseSaleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomerWiseSaleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomerWiseSaleDetailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalesBelowCostToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSaleCancelSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.mmInventoryReports = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdjustmentReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StockBelowLevelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SlowMovementReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TotalStockValueByCategoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TotalStockValueBySubCategoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TotalStockValueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mmItemReports = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemTurnoverToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnItemMovement = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemMovementSummaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemMovementSummary2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemSalesMovementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnItemDrillDownEnquiry = New System.Windows.Forms.ToolStripMenuItem()
        Me.mmCustomerReports = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCustomerHistory = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomerRotationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomerStatementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCustomerPaid = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCustomerBalance = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCustomerBalanceInDuration = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCustomerMonthlyBalance = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCustomerSales = New System.Windows.Forms.ToolStripMenuItem()
        Me.mmAlert = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemAlertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemExpiryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SubscriptionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAccountTypeTotal = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatementsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupplierStatementToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomerStatementToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CashStatementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BankStatementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OwnersStatementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OtherRevenueStatementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExpensesStatementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmployeeStatementToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerateSalaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmployeePaymentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CostPriceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnReward = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip.SuspendLayout()
        CType(Me.UltraTabbedMdiManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip.ForeColor = System.Drawing.Color.Black
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblLoginName, Me.lblDesignation, Me.ProgressBar1, Me.lblVersion})
        Me.StatusStrip.Location = New System.Drawing.Point(3, 3)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(1172, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'lblLoginName
        '
        Me.lblLoginName.Name = "lblLoginName"
        Me.lblLoginName.Size = New System.Drawing.Size(75, 17)
        Me.lblLoginName.Text = "Login Name:"
        '
        'lblDesignation
        '
        Me.lblDesignation.Name = "lblDesignation"
        Me.lblDesignation.Size = New System.Drawing.Size(73, 17)
        Me.lblDesignation.Text = "Designation:"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.Color.DodgerBlue
        Me.ProgressBar1.ForeColor = System.Drawing.Color.Black
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(100, 16)
        '
        'lblVersion
        '
        Me.lblVersion.ActiveLinkColor = System.Drawing.Color.Red
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(113, 17)
        Me.lblVersion.Text = "Version {0}.{1}.{2}.{3}"
        '
        'UltraTabbedMdiManager1
        '
        Me.UltraTabbedMdiManager1.AllowMaximize = True
        Me.UltraTabbedMdiManager1.MdiParent = Me
        Me.UltraTabbedMdiManager1.ViewStyle = Infragistics.Win.UltraWinTabbedMdi.ViewStyle.Office2007
        '
        'Timer1
        '
        Me.Timer1.Interval = 50
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip1.ForeColor = System.Drawing.Color.Black
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.OperationToolStripMenuItem, Me.AccountsToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.StatementsToolStripMenuItem, Me.SalaryToolStripMenuItem, Me.PrintToolStripMenuItem, Me.CostPriceToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(3, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1172, 24)
        Me.MenuStrip1.TabIndex = 11
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnItemList, Me.btnItems, Me.btnItemClass, Me.btnReward, Me.btnPrintBarcode, Me.ToolStripSeparator4, Me.btnItemCategory, Me.btnItemSubCategory, Me.btnUMC, Me.ToolStripSeparator5, Me.SubscribeToolStripMenuItem, Me.UnsubscribeToolStripMenuItem, Me.SubscriptionPaymentToolStripMenuItem, Me.ToolStripSeparator11, Me.ChangePasswordToolStripMenuItem, Me.UsersToolStripMenuItem, Me.ToolStripSeparator13, Me.Backup, Me.btnConfig})
        Me.FileMenu.Image = CType(resources.GetObject("FileMenu.Image"), System.Drawing.Image)
        Me.FileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Size = New System.Drawing.Size(53, 20)
        Me.FileMenu.Text = "&File"
        '
        'btnItemList
        '
        Me.btnItemList.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnItemList.Image = CType(resources.GetObject("btnItemList.Image"), System.Drawing.Image)
        Me.btnItemList.Name = "btnItemList"
        Me.btnItemList.Size = New System.Drawing.Size(190, 22)
        Me.btnItemList.Text = "Item List"
        '
        'btnItems
        '
        Me.btnItems.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnItems.Image = CType(resources.GetObject("btnItems.Image"), System.Drawing.Image)
        Me.btnItems.Name = "btnItems"
        Me.btnItems.Size = New System.Drawing.Size(190, 22)
        Me.btnItems.Text = "Items"
        '
        'btnItemClass
        '
        Me.btnItemClass.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnItemClass.Image = CType(resources.GetObject("btnItemClass.Image"), System.Drawing.Image)
        Me.btnItemClass.Name = "btnItemClass"
        Me.btnItemClass.Size = New System.Drawing.Size(190, 22)
        Me.btnItemClass.Text = "Item Class"
        '
        'btnPrintBarcode
        '
        Me.btnPrintBarcode.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnPrintBarcode.Image = CType(resources.GetObject("btnPrintBarcode.Image"), System.Drawing.Image)
        Me.btnPrintBarcode.Name = "btnPrintBarcode"
        Me.btnPrintBarcode.Size = New System.Drawing.Size(190, 22)
        Me.btnPrintBarcode.Text = "Print Barcode"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.BackColor = System.Drawing.Color.DodgerBlue
        Me.ToolStripSeparator4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(187, 6)
        '
        'btnItemCategory
        '
        Me.btnItemCategory.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnItemCategory.Image = CType(resources.GetObject("btnItemCategory.Image"), System.Drawing.Image)
        Me.btnItemCategory.ImageTransparentColor = System.Drawing.Color.Black
        Me.btnItemCategory.Name = "btnItemCategory"
        Me.btnItemCategory.Size = New System.Drawing.Size(190, 22)
        Me.btnItemCategory.Text = "Item Category"
        '
        'btnItemSubCategory
        '
        Me.btnItemSubCategory.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnItemSubCategory.Image = CType(resources.GetObject("btnItemSubCategory.Image"), System.Drawing.Image)
        Me.btnItemSubCategory.ImageTransparentColor = System.Drawing.Color.Black
        Me.btnItemSubCategory.Name = "btnItemSubCategory"
        Me.btnItemSubCategory.Size = New System.Drawing.Size(190, 22)
        Me.btnItemSubCategory.Text = "Item Sub Category"
        '
        'btnUMC
        '
        Me.btnUMC.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnUMC.Image = CType(resources.GetObject("btnUMC.Image"), System.Drawing.Image)
        Me.btnUMC.ImageTransparentColor = System.Drawing.Color.Black
        Me.btnUMC.Name = "btnUMC"
        Me.btnUMC.Size = New System.Drawing.Size(190, 22)
        Me.btnUMC.Text = "UMC Type"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.BackColor = System.Drawing.Color.DodgerBlue
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(187, 6)
        Me.ToolStripSeparator5.Visible = False
        '
        'SubscribeToolStripMenuItem
        '
        Me.SubscribeToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.SubscribeToolStripMenuItem.Image = CType(resources.GetObject("SubscribeToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SubscribeToolStripMenuItem.Name = "SubscribeToolStripMenuItem"
        Me.SubscribeToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.SubscribeToolStripMenuItem.Text = "Subscribe"
        '
        'UnsubscribeToolStripMenuItem
        '
        Me.UnsubscribeToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.UnsubscribeToolStripMenuItem.Image = CType(resources.GetObject("UnsubscribeToolStripMenuItem.Image"), System.Drawing.Image)
        Me.UnsubscribeToolStripMenuItem.Name = "UnsubscribeToolStripMenuItem"
        Me.UnsubscribeToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.UnsubscribeToolStripMenuItem.Text = "Unsubscribe"
        '
        'SubscriptionPaymentToolStripMenuItem
        '
        Me.SubscriptionPaymentToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.SubscriptionPaymentToolStripMenuItem.Image = CType(resources.GetObject("SubscriptionPaymentToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SubscriptionPaymentToolStripMenuItem.Name = "SubscriptionPaymentToolStripMenuItem"
        Me.SubscriptionPaymentToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.SubscriptionPaymentToolStripMenuItem.Text = "Subscription Payment"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.BackColor = System.Drawing.Color.DodgerBlue
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(187, 6)
        '
        'ChangePasswordToolStripMenuItem
        '
        Me.ChangePasswordToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.ChangePasswordToolStripMenuItem.Image = CType(resources.GetObject("ChangePasswordToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ChangePasswordToolStripMenuItem.Name = "ChangePasswordToolStripMenuItem"
        Me.ChangePasswordToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.ChangePasswordToolStripMenuItem.Text = "Change Password"
        '
        'UsersToolStripMenuItem
        '
        Me.UsersToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.UsersToolStripMenuItem.Image = CType(resources.GetObject("UsersToolStripMenuItem.Image"), System.Drawing.Image)
        Me.UsersToolStripMenuItem.Name = "UsersToolStripMenuItem"
        Me.UsersToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.UsersToolStripMenuItem.Text = "Users"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.BackColor = System.Drawing.Color.DodgerBlue
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(187, 6)
        '
        'Backup
        '
        Me.Backup.BackColor = System.Drawing.Color.DodgerBlue
        Me.Backup.Image = CType(resources.GetObject("Backup.Image"), System.Drawing.Image)
        Me.Backup.ImageTransparentColor = System.Drawing.Color.Black
        Me.Backup.Name = "Backup"
        Me.Backup.Size = New System.Drawing.Size(190, 22)
        Me.Backup.Text = "Backup"
        '
        'btnConfig
        '
        Me.btnConfig.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnConfig.Image = CType(resources.GetObject("btnConfig.Image"), System.Drawing.Image)
        Me.btnConfig.ImageTransparentColor = System.Drawing.Color.Black
        Me.btnConfig.Name = "btnConfig"
        Me.btnConfig.Size = New System.Drawing.Size(190, 22)
        Me.btnConfig.Text = "Configuration"
        '
        'OperationToolStripMenuItem
        '
        Me.OperationToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaleToolStripMenuItem, Me.btnSalesReturn, Me.PurchaseToolStripMenuItem1, Me.btnPromotion, Me.btnMembership, Me.btnQuotation})
        Me.OperationToolStripMenuItem.Image = CType(resources.GetObject("OperationToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OperationToolStripMenuItem.Name = "OperationToolStripMenuItem"
        Me.OperationToolStripMenuItem.Size = New System.Drawing.Size(88, 20)
        Me.OperationToolStripMenuItem.Text = "Operation"
        '
        'SaleToolStripMenuItem
        '
        Me.SaleToolStripMenuItem.Image = CType(resources.GetObject("SaleToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaleToolStripMenuItem.Name = "SaleToolStripMenuItem"
        Me.SaleToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.SaleToolStripMenuItem.Text = "Sale"
        '
        'btnSalesReturn
        '
        Me.btnSalesReturn.Image = CType(resources.GetObject("btnSalesReturn.Image"), System.Drawing.Image)
        Me.btnSalesReturn.Name = "btnSalesReturn"
        Me.btnSalesReturn.Size = New System.Drawing.Size(141, 22)
        Me.btnSalesReturn.Text = "Sales Return"
        '
        'PurchaseToolStripMenuItem1
        '
        Me.PurchaseToolStripMenuItem1.Image = CType(resources.GetObject("PurchaseToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.PurchaseToolStripMenuItem1.Name = "PurchaseToolStripMenuItem1"
        Me.PurchaseToolStripMenuItem1.Size = New System.Drawing.Size(141, 22)
        Me.PurchaseToolStripMenuItem1.Text = "Purchase"
        '
        'btnPromotion
        '
        Me.btnPromotion.Image = CType(resources.GetObject("btnPromotion.Image"), System.Drawing.Image)
        Me.btnPromotion.Name = "btnPromotion"
        Me.btnPromotion.Size = New System.Drawing.Size(141, 22)
        Me.btnPromotion.Text = "Promotion"
        '
        'btnMembership
        '
        Me.btnMembership.Image = CType(resources.GetObject("btnMembership.Image"), System.Drawing.Image)
        Me.btnMembership.Name = "btnMembership"
        Me.btnMembership.Size = New System.Drawing.Size(141, 22)
        Me.btnMembership.Text = "Membership"
        '
        'btnQuotation
        '
        Me.btnQuotation.Image = CType(resources.GetObject("btnQuotation.Image"), System.Drawing.Image)
        Me.btnQuotation.Name = "btnQuotation"
        Me.btnQuotation.Size = New System.Drawing.Size(141, 22)
        Me.btnQuotation.Text = "Quotation"
        '
        'AccountsToolStripMenuItem
        '
        Me.AccountsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SupplierToolStripMenuItem, Me.CustomerToolStripMenuItem1, Me.CashToolStripMenuItem, Me.BankToolStripMenuItem, Me.OwnerToolStripMenuItem1, Me.EmployeeToolStripMenuItem, Me.ToolStripSeparator7, Me.OtherRevenueToolStripMenuItem, Me.ExpensesToolStripMenuItem, Me.ToolStripSeparator8, Me.VoucherToolStripMenuItem, Me.ToolStripSeparator9, Me.btnCheque})
        Me.AccountsToolStripMenuItem.Image = CType(resources.GetObject("AccountsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AccountsToolStripMenuItem.Name = "AccountsToolStripMenuItem"
        Me.AccountsToolStripMenuItem.Size = New System.Drawing.Size(85, 20)
        Me.AccountsToolStripMenuItem.Text = "Accounts"
        '
        'SupplierToolStripMenuItem
        '
        Me.SupplierToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.SupplierToolStripMenuItem.Image = CType(resources.GetObject("SupplierToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SupplierToolStripMenuItem.Name = "SupplierToolStripMenuItem"
        Me.SupplierToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.F2), System.Windows.Forms.Keys)
        Me.SupplierToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.SupplierToolStripMenuItem.Text = "Supplier List"
        '
        'CustomerToolStripMenuItem1
        '
        Me.CustomerToolStripMenuItem1.BackColor = System.Drawing.Color.DodgerBlue
        Me.CustomerToolStripMenuItem1.Image = CType(resources.GetObject("CustomerToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.CustomerToolStripMenuItem1.Name = "CustomerToolStripMenuItem1"
        Me.CustomerToolStripMenuItem1.ShortcutKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.F1), System.Windows.Forms.Keys)
        Me.CustomerToolStripMenuItem1.Size = New System.Drawing.Size(224, 22)
        Me.CustomerToolStripMenuItem1.Text = "Customer List"
        '
        'CashToolStripMenuItem
        '
        Me.CashToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.CashToolStripMenuItem.Image = CType(resources.GetObject("CashToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CashToolStripMenuItem.Name = "CashToolStripMenuItem"
        Me.CashToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.F3), System.Windows.Forms.Keys)
        Me.CashToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.CashToolStripMenuItem.Text = "Cash List"
        '
        'BankToolStripMenuItem
        '
        Me.BankToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.BankToolStripMenuItem.Image = CType(resources.GetObject("BankToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BankToolStripMenuItem.Name = "BankToolStripMenuItem"
        Me.BankToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.BankToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.BankToolStripMenuItem.Text = "Bank List"
        '
        'OwnerToolStripMenuItem1
        '
        Me.OwnerToolStripMenuItem1.BackColor = System.Drawing.Color.DodgerBlue
        Me.OwnerToolStripMenuItem1.Image = CType(resources.GetObject("OwnerToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.OwnerToolStripMenuItem1.Name = "OwnerToolStripMenuItem1"
        Me.OwnerToolStripMenuItem1.ShortcutKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.F5), System.Windows.Forms.Keys)
        Me.OwnerToolStripMenuItem1.Size = New System.Drawing.Size(224, 22)
        Me.OwnerToolStripMenuItem1.Text = "Owner List"
        '
        'EmployeeToolStripMenuItem
        '
        Me.EmployeeToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.EmployeeToolStripMenuItem.Image = CType(resources.GetObject("EmployeeToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EmployeeToolStripMenuItem.Name = "EmployeeToolStripMenuItem"
        Me.EmployeeToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.F6), System.Windows.Forms.Keys)
        Me.EmployeeToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.EmployeeToolStripMenuItem.Text = "Employee List"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.BackColor = System.Drawing.Color.DodgerBlue
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(221, 6)
        '
        'OtherRevenueToolStripMenuItem
        '
        Me.OtherRevenueToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.OtherRevenueToolStripMenuItem.Image = CType(resources.GetObject("OtherRevenueToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OtherRevenueToolStripMenuItem.Name = "OtherRevenueToolStripMenuItem"
        Me.OtherRevenueToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.F7), System.Windows.Forms.Keys)
        Me.OtherRevenueToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.OtherRevenueToolStripMenuItem.Text = "Other Revenue List"
        '
        'ExpensesToolStripMenuItem
        '
        Me.ExpensesToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.ExpensesToolStripMenuItem.Image = CType(resources.GetObject("ExpensesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExpensesToolStripMenuItem.Name = "ExpensesToolStripMenuItem"
        Me.ExpensesToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.F8), System.Windows.Forms.Keys)
        Me.ExpensesToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.ExpensesToolStripMenuItem.Text = "Expenses List"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(221, 6)
        '
        'VoucherToolStripMenuItem
        '
        Me.VoucherToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.VoucherToolStripMenuItem.Image = CType(resources.GetObject("VoucherToolStripMenuItem.Image"), System.Drawing.Image)
        Me.VoucherToolStripMenuItem.Name = "VoucherToolStripMenuItem"
        Me.VoucherToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.F9), System.Windows.Forms.Keys)
        Me.VoucherToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.VoucherToolStripMenuItem.Text = "Voucher"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.BackColor = System.Drawing.Color.DodgerBlue
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(221, 6)
        '
        'btnCheque
        '
        Me.btnCheque.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnCheque.Image = CType(resources.GetObject("btnCheque.Image"), System.Drawing.Image)
        Me.btnCheque.Name = "btnCheque"
        Me.btnCheque.ShortcutKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.F10), System.Windows.Forms.Keys)
        Me.btnCheque.Size = New System.Drawing.Size(224, 22)
        Me.btnCheque.Text = "Cheque"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DailySummaryToolStripMenuItem, Me.SalesSearchToolStripMenuItem, Me.mmSalesReports, Me.mmInventoryReports, Me.mmItemReports, Me.mmCustomerReports, Me.mmAlert, Me.SubscriptionToolStripMenuItem, Me.btnAccountTypeTotal})
        Me.ReportsToolStripMenuItem.Image = CType(resources.GetObject("ReportsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(75, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'DailySummaryToolStripMenuItem
        '
        Me.DailySummaryToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.DailySummaryToolStripMenuItem.Image = CType(resources.GetObject("DailySummaryToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DailySummaryToolStripMenuItem.Name = "DailySummaryToolStripMenuItem"
        Me.DailySummaryToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.DailySummaryToolStripMenuItem.Text = "Daily Summary"
        '
        'SalesSearchToolStripMenuItem
        '
        Me.SalesSearchToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.SalesSearchToolStripMenuItem.Image = CType(resources.GetObject("SalesSearchToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SalesSearchToolStripMenuItem.Name = "SalesSearchToolStripMenuItem"
        Me.SalesSearchToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.SalesSearchToolStripMenuItem.Text = "Sales Search"
        '
        'mmSalesReports
        '
        Me.mmSalesReports.BackColor = System.Drawing.Color.DodgerBlue
        Me.mmSalesReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSalesDiscountInBill, Me.btnSalesDiscountReceipt, Me.btnSalesDiscount, Me.CategoryWiseSaleToolStripMenuItem, Me.SubCategoryWiseSaleToolStripMenuItem, Me.ItemWiseSaleToolStripMenuItem, Me.CustomerWiseSaleToolStripMenuItem, Me.CustomerWiseSaleDetailToolStripMenuItem, Me.SalesBelowCostToolStripMenuItem, Me.btnSaleCancelSearch})
        Me.mmSalesReports.Image = CType(resources.GetObject("mmSalesReports.Image"), System.Drawing.Image)
        Me.mmSalesReports.Name = "mmSalesReports"
        Me.mmSalesReports.Size = New System.Drawing.Size(174, 22)
        Me.mmSalesReports.Text = "Sales Reports"
        '
        'btnSalesDiscountInBill
        '
        Me.btnSalesDiscountInBill.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnSalesDiscountInBill.Image = CType(resources.GetObject("btnSalesDiscountInBill.Image"), System.Drawing.Image)
        Me.btnSalesDiscountInBill.Name = "btnSalesDiscountInBill"
        Me.btnSalesDiscountInBill.Size = New System.Drawing.Size(211, 22)
        Me.btnSalesDiscountInBill.Text = "Sales Discount in Bill"
        '
        'btnSalesDiscountReceipt
        '
        Me.btnSalesDiscountReceipt.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnSalesDiscountReceipt.Image = CType(resources.GetObject("btnSalesDiscountReceipt.Image"), System.Drawing.Image)
        Me.btnSalesDiscountReceipt.Name = "btnSalesDiscountReceipt"
        Me.btnSalesDiscountReceipt.Size = New System.Drawing.Size(211, 22)
        Me.btnSalesDiscountReceipt.Text = "Sales Discount Receipt"
        '
        'btnSalesDiscount
        '
        Me.btnSalesDiscount.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnSalesDiscount.Image = CType(resources.GetObject("btnSalesDiscount.Image"), System.Drawing.Image)
        Me.btnSalesDiscount.Name = "btnSalesDiscount"
        Me.btnSalesDiscount.Size = New System.Drawing.Size(211, 22)
        Me.btnSalesDiscount.Text = "Sales Discount"
        '
        'CategoryWiseSaleToolStripMenuItem
        '
        Me.CategoryWiseSaleToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.CategoryWiseSaleToolStripMenuItem.Image = CType(resources.GetObject("CategoryWiseSaleToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CategoryWiseSaleToolStripMenuItem.Name = "CategoryWiseSaleToolStripMenuItem"
        Me.CategoryWiseSaleToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.CategoryWiseSaleToolStripMenuItem.Text = "Category Wise Sale"
        '
        'SubCategoryWiseSaleToolStripMenuItem
        '
        Me.SubCategoryWiseSaleToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.SubCategoryWiseSaleToolStripMenuItem.Image = CType(resources.GetObject("SubCategoryWiseSaleToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SubCategoryWiseSaleToolStripMenuItem.Name = "SubCategoryWiseSaleToolStripMenuItem"
        Me.SubCategoryWiseSaleToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.SubCategoryWiseSaleToolStripMenuItem.Text = "Sub Category Wise Sale"
        '
        'ItemWiseSaleToolStripMenuItem
        '
        Me.ItemWiseSaleToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.ItemWiseSaleToolStripMenuItem.Image = CType(resources.GetObject("ItemWiseSaleToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ItemWiseSaleToolStripMenuItem.Name = "ItemWiseSaleToolStripMenuItem"
        Me.ItemWiseSaleToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.ItemWiseSaleToolStripMenuItem.Text = "Item Wise Sale"
        '
        'CustomerWiseSaleToolStripMenuItem
        '
        Me.CustomerWiseSaleToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.CustomerWiseSaleToolStripMenuItem.Image = CType(resources.GetObject("CustomerWiseSaleToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CustomerWiseSaleToolStripMenuItem.Name = "CustomerWiseSaleToolStripMenuItem"
        Me.CustomerWiseSaleToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.CustomerWiseSaleToolStripMenuItem.Text = "Customer Wise Sale"
        '
        'CustomerWiseSaleDetailToolStripMenuItem
        '
        Me.CustomerWiseSaleDetailToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.CustomerWiseSaleDetailToolStripMenuItem.Image = CType(resources.GetObject("CustomerWiseSaleDetailToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CustomerWiseSaleDetailToolStripMenuItem.Name = "CustomerWiseSaleDetailToolStripMenuItem"
        Me.CustomerWiseSaleDetailToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.CustomerWiseSaleDetailToolStripMenuItem.Text = "Customer Wise Sale Detail"
        '
        'SalesBelowCostToolStripMenuItem
        '
        Me.SalesBelowCostToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.SalesBelowCostToolStripMenuItem.Image = Global.POS.My.Resources.Resources.form_red
        Me.SalesBelowCostToolStripMenuItem.Name = "SalesBelowCostToolStripMenuItem"
        Me.SalesBelowCostToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.SalesBelowCostToolStripMenuItem.Text = "Sales Below Cost"
        '
        'btnSaleCancelSearch
        '
        Me.btnSaleCancelSearch.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnSaleCancelSearch.Image = CType(resources.GetObject("btnSaleCancelSearch.Image"), System.Drawing.Image)
        Me.btnSaleCancelSearch.Name = "btnSaleCancelSearch"
        Me.btnSaleCancelSearch.Size = New System.Drawing.Size(211, 22)
        Me.btnSaleCancelSearch.Text = "Sales Cancel Search"
        '
        'mmInventoryReports
        '
        Me.mmInventoryReports.BackColor = System.Drawing.Color.DodgerBlue
        Me.mmInventoryReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AdjustmentReportToolStripMenuItem, Me.StockBelowLevelToolStripMenuItem, Me.SlowMovementReportToolStripMenuItem, Me.TotalStockValueByCategoryToolStripMenuItem, Me.TotalStockValueBySubCategoryToolStripMenuItem, Me.TotalStockValueToolStripMenuItem})
        Me.mmInventoryReports.Image = Global.POS.My.Resources.Resources.form_red
        Me.mmInventoryReports.Name = "mmInventoryReports"
        Me.mmInventoryReports.Size = New System.Drawing.Size(174, 22)
        Me.mmInventoryReports.Text = "Inventory Reports"
        '
        'AdjustmentReportToolStripMenuItem
        '
        Me.AdjustmentReportToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.AdjustmentReportToolStripMenuItem.Image = CType(resources.GetObject("AdjustmentReportToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AdjustmentReportToolStripMenuItem.Name = "AdjustmentReportToolStripMenuItem"
        Me.AdjustmentReportToolStripMenuItem.Size = New System.Drawing.Size(252, 22)
        Me.AdjustmentReportToolStripMenuItem.Text = "Adjustment Report"
        Me.AdjustmentReportToolStripMenuItem.Visible = False
        '
        'StockBelowLevelToolStripMenuItem
        '
        Me.StockBelowLevelToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.StockBelowLevelToolStripMenuItem.Image = CType(resources.GetObject("StockBelowLevelToolStripMenuItem.Image"), System.Drawing.Image)
        Me.StockBelowLevelToolStripMenuItem.Name = "StockBelowLevelToolStripMenuItem"
        Me.StockBelowLevelToolStripMenuItem.Size = New System.Drawing.Size(252, 22)
        Me.StockBelowLevelToolStripMenuItem.Text = "Stock Below Level"
        Me.StockBelowLevelToolStripMenuItem.Visible = False
        '
        'SlowMovementReportToolStripMenuItem
        '
        Me.SlowMovementReportToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.SlowMovementReportToolStripMenuItem.Image = CType(resources.GetObject("SlowMovementReportToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SlowMovementReportToolStripMenuItem.Name = "SlowMovementReportToolStripMenuItem"
        Me.SlowMovementReportToolStripMenuItem.Size = New System.Drawing.Size(252, 22)
        Me.SlowMovementReportToolStripMenuItem.Text = "Slow Movement Report"
        '
        'TotalStockValueByCategoryToolStripMenuItem
        '
        Me.TotalStockValueByCategoryToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.TotalStockValueByCategoryToolStripMenuItem.Image = CType(resources.GetObject("TotalStockValueByCategoryToolStripMenuItem.Image"), System.Drawing.Image)
        Me.TotalStockValueByCategoryToolStripMenuItem.Name = "TotalStockValueByCategoryToolStripMenuItem"
        Me.TotalStockValueByCategoryToolStripMenuItem.Size = New System.Drawing.Size(252, 22)
        Me.TotalStockValueByCategoryToolStripMenuItem.Text = "Total Stock Value By Category"
        Me.TotalStockValueByCategoryToolStripMenuItem.Visible = False
        '
        'TotalStockValueBySubCategoryToolStripMenuItem
        '
        Me.TotalStockValueBySubCategoryToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.TotalStockValueBySubCategoryToolStripMenuItem.Image = CType(resources.GetObject("TotalStockValueBySubCategoryToolStripMenuItem.Image"), System.Drawing.Image)
        Me.TotalStockValueBySubCategoryToolStripMenuItem.Name = "TotalStockValueBySubCategoryToolStripMenuItem"
        Me.TotalStockValueBySubCategoryToolStripMenuItem.Size = New System.Drawing.Size(252, 22)
        Me.TotalStockValueBySubCategoryToolStripMenuItem.Text = "Total Stock Value By Sub Category"
        Me.TotalStockValueBySubCategoryToolStripMenuItem.Visible = False
        '
        'TotalStockValueToolStripMenuItem
        '
        Me.TotalStockValueToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.TotalStockValueToolStripMenuItem.Image = CType(resources.GetObject("TotalStockValueToolStripMenuItem.Image"), System.Drawing.Image)
        Me.TotalStockValueToolStripMenuItem.Name = "TotalStockValueToolStripMenuItem"
        Me.TotalStockValueToolStripMenuItem.Size = New System.Drawing.Size(252, 22)
        Me.TotalStockValueToolStripMenuItem.Text = "Total Stock Value"
        Me.TotalStockValueToolStripMenuItem.Visible = False
        '
        'mmItemReports
        '
        Me.mmItemReports.BackColor = System.Drawing.Color.DodgerBlue
        Me.mmItemReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ItemTurnoverToolStripMenuItem, Me.btnItemMovement, Me.ItemMovementSummaryToolStripMenuItem, Me.ItemMovementSummary2ToolStripMenuItem, Me.ItemSalesMovementToolStripMenuItem, Me.btnItemDrillDownEnquiry})
        Me.mmItemReports.Image = CType(resources.GetObject("mmItemReports.Image"), System.Drawing.Image)
        Me.mmItemReports.Name = "mmItemReports"
        Me.mmItemReports.Size = New System.Drawing.Size(174, 22)
        Me.mmItemReports.Text = "Item Reports"
        '
        'ItemTurnoverToolStripMenuItem
        '
        Me.ItemTurnoverToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.ItemTurnoverToolStripMenuItem.Image = CType(resources.GetObject("ItemTurnoverToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ItemTurnoverToolStripMenuItem.Name = "ItemTurnoverToolStripMenuItem"
        Me.ItemTurnoverToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.ItemTurnoverToolStripMenuItem.Text = "Item Turnover"
        Me.ItemTurnoverToolStripMenuItem.Visible = False
        '
        'btnItemMovement
        '
        Me.btnItemMovement.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnItemMovement.Image = CType(resources.GetObject("btnItemMovement.Image"), System.Drawing.Image)
        Me.btnItemMovement.Name = "btnItemMovement"
        Me.btnItemMovement.Size = New System.Drawing.Size(222, 22)
        Me.btnItemMovement.Text = "Item Movement"
        '
        'ItemMovementSummaryToolStripMenuItem
        '
        Me.ItemMovementSummaryToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.ItemMovementSummaryToolStripMenuItem.Image = CType(resources.GetObject("ItemMovementSummaryToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ItemMovementSummaryToolStripMenuItem.Name = "ItemMovementSummaryToolStripMenuItem"
        Me.ItemMovementSummaryToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.ItemMovementSummaryToolStripMenuItem.Text = "Item Movement Summary"
        '
        'ItemMovementSummary2ToolStripMenuItem
        '
        Me.ItemMovementSummary2ToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.ItemMovementSummary2ToolStripMenuItem.Image = CType(resources.GetObject("ItemMovementSummary2ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ItemMovementSummary2ToolStripMenuItem.Name = "ItemMovementSummary2ToolStripMenuItem"
        Me.ItemMovementSummary2ToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.ItemMovementSummary2ToolStripMenuItem.Text = "Item Movement Summary 2"
        '
        'ItemSalesMovementToolStripMenuItem
        '
        Me.ItemSalesMovementToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.ItemSalesMovementToolStripMenuItem.Image = CType(resources.GetObject("ItemSalesMovementToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ItemSalesMovementToolStripMenuItem.Name = "ItemSalesMovementToolStripMenuItem"
        Me.ItemSalesMovementToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.ItemSalesMovementToolStripMenuItem.Text = "Item Sales Movement"
        '
        'btnItemDrillDownEnquiry
        '
        Me.btnItemDrillDownEnquiry.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnItemDrillDownEnquiry.Image = CType(resources.GetObject("btnItemDrillDownEnquiry.Image"), System.Drawing.Image)
        Me.btnItemDrillDownEnquiry.Name = "btnItemDrillDownEnquiry"
        Me.btnItemDrillDownEnquiry.Size = New System.Drawing.Size(222, 22)
        Me.btnItemDrillDownEnquiry.Text = "Item Drill Down Enquiry"
        '
        'mmCustomerReports
        '
        Me.mmCustomerReports.BackColor = System.Drawing.Color.DodgerBlue
        Me.mmCustomerReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnCustomerHistory, Me.CustomerRotationToolStripMenuItem, Me.CustomerStatementToolStripMenuItem, Me.btnCustomerPaid, Me.btnCustomerBalance, Me.btnCustomerBalanceInDuration, Me.btnCustomerMonthlyBalance, Me.btnCustomerSales})
        Me.mmCustomerReports.Image = CType(resources.GetObject("mmCustomerReports.Image"), System.Drawing.Image)
        Me.mmCustomerReports.Name = "mmCustomerReports"
        Me.mmCustomerReports.Size = New System.Drawing.Size(174, 22)
        Me.mmCustomerReports.Text = "Customer Reports"
        '
        'btnCustomerHistory
        '
        Me.btnCustomerHistory.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnCustomerHistory.Image = CType(resources.GetObject("btnCustomerHistory.Image"), System.Drawing.Image)
        Me.btnCustomerHistory.Name = "btnCustomerHistory"
        Me.btnCustomerHistory.Size = New System.Drawing.Size(232, 22)
        Me.btnCustomerHistory.Text = "Customer History"
        '
        'CustomerRotationToolStripMenuItem
        '
        Me.CustomerRotationToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.CustomerRotationToolStripMenuItem.Image = CType(resources.GetObject("CustomerRotationToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CustomerRotationToolStripMenuItem.Name = "CustomerRotationToolStripMenuItem"
        Me.CustomerRotationToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.CustomerRotationToolStripMenuItem.Text = "Customer Rotation"
        '
        'CustomerStatementToolStripMenuItem
        '
        Me.CustomerStatementToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.CustomerStatementToolStripMenuItem.Image = CType(resources.GetObject("CustomerStatementToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CustomerStatementToolStripMenuItem.Name = "CustomerStatementToolStripMenuItem"
        Me.CustomerStatementToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.CustomerStatementToolStripMenuItem.Text = "Customer Statement"
        '
        'btnCustomerPaid
        '
        Me.btnCustomerPaid.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnCustomerPaid.Image = CType(resources.GetObject("btnCustomerPaid.Image"), System.Drawing.Image)
        Me.btnCustomerPaid.Name = "btnCustomerPaid"
        Me.btnCustomerPaid.Size = New System.Drawing.Size(232, 22)
        Me.btnCustomerPaid.Text = "Customer Paid"
        '
        'btnCustomerBalance
        '
        Me.btnCustomerBalance.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnCustomerBalance.Image = CType(resources.GetObject("btnCustomerBalance.Image"), System.Drawing.Image)
        Me.btnCustomerBalance.Name = "btnCustomerBalance"
        Me.btnCustomerBalance.Size = New System.Drawing.Size(232, 22)
        Me.btnCustomerBalance.Text = "Customer Balance"
        '
        'btnCustomerBalanceInDuration
        '
        Me.btnCustomerBalanceInDuration.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnCustomerBalanceInDuration.Image = CType(resources.GetObject("btnCustomerBalanceInDuration.Image"), System.Drawing.Image)
        Me.btnCustomerBalanceInDuration.Name = "btnCustomerBalanceInDuration"
        Me.btnCustomerBalanceInDuration.Size = New System.Drawing.Size(232, 22)
        Me.btnCustomerBalanceInDuration.Text = "Customer Balance In Duration"
        '
        'btnCustomerMonthlyBalance
        '
        Me.btnCustomerMonthlyBalance.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnCustomerMonthlyBalance.Image = CType(resources.GetObject("btnCustomerMonthlyBalance.Image"), System.Drawing.Image)
        Me.btnCustomerMonthlyBalance.Name = "btnCustomerMonthlyBalance"
        Me.btnCustomerMonthlyBalance.Size = New System.Drawing.Size(232, 22)
        Me.btnCustomerMonthlyBalance.Text = "Customer Monthly Balance"
        '
        'btnCustomerSales
        '
        Me.btnCustomerSales.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnCustomerSales.Image = CType(resources.GetObject("btnCustomerSales.Image"), System.Drawing.Image)
        Me.btnCustomerSales.Name = "btnCustomerSales"
        Me.btnCustomerSales.Size = New System.Drawing.Size(232, 22)
        Me.btnCustomerSales.Text = "Customer Sales"
        '
        'mmAlert
        '
        Me.mmAlert.BackColor = System.Drawing.Color.DodgerBlue
        Me.mmAlert.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ItemAlertToolStripMenuItem, Me.ItemExpiryToolStripMenuItem})
        Me.mmAlert.Image = CType(resources.GetObject("mmAlert.Image"), System.Drawing.Image)
        Me.mmAlert.Name = "mmAlert"
        Me.mmAlert.Size = New System.Drawing.Size(174, 22)
        Me.mmAlert.Text = "Alert"
        '
        'ItemAlertToolStripMenuItem
        '
        Me.ItemAlertToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.ItemAlertToolStripMenuItem.Image = CType(resources.GetObject("ItemAlertToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ItemAlertToolStripMenuItem.Name = "ItemAlertToolStripMenuItem"
        Me.ItemAlertToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.ItemAlertToolStripMenuItem.Text = "Item Alert"
        '
        'ItemExpiryToolStripMenuItem
        '
        Me.ItemExpiryToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.ItemExpiryToolStripMenuItem.Image = CType(resources.GetObject("ItemExpiryToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ItemExpiryToolStripMenuItem.Name = "ItemExpiryToolStripMenuItem"
        Me.ItemExpiryToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.ItemExpiryToolStripMenuItem.Text = "Item Expiry"
        '
        'SubscriptionToolStripMenuItem
        '
        Me.SubscriptionToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.SubscriptionToolStripMenuItem.Image = CType(resources.GetObject("SubscriptionToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SubscriptionToolStripMenuItem.Name = "SubscriptionToolStripMenuItem"
        Me.SubscriptionToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.SubscriptionToolStripMenuItem.Text = "Subscription"
        '
        'btnAccountTypeTotal
        '
        Me.btnAccountTypeTotal.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnAccountTypeTotal.Image = CType(resources.GetObject("btnAccountTypeTotal.Image"), System.Drawing.Image)
        Me.btnAccountTypeTotal.Name = "btnAccountTypeTotal"
        Me.btnAccountTypeTotal.Size = New System.Drawing.Size(174, 22)
        Me.btnAccountTypeTotal.Text = "Account Type Total"
        '
        'StatementsToolStripMenuItem
        '
        Me.StatementsToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        Me.StatementsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SupplierStatementToolStripMenuItem2, Me.CustomerStatementToolStripMenuItem2, Me.CashStatementToolStripMenuItem, Me.BankStatementToolStripMenuItem, Me.OwnersStatementToolStripMenuItem, Me.OtherRevenueStatementToolStripMenuItem, Me.ExpensesStatementToolStripMenuItem, Me.EmployeeStatementToolStripMenuItem1})
        Me.StatementsToolStripMenuItem.Image = CType(resources.GetObject("StatementsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.StatementsToolStripMenuItem.Name = "StatementsToolStripMenuItem"
        Me.StatementsToolStripMenuItem.Size = New System.Drawing.Size(94, 20)
        Me.StatementsToolStripMenuItem.Text = "Statements"
        '
        'SupplierStatementToolStripMenuItem2
        '
        Me.SupplierStatementToolStripMenuItem2.BackColor = System.Drawing.Color.DodgerBlue
        Me.SupplierStatementToolStripMenuItem2.Image = CType(resources.GetObject("SupplierStatementToolStripMenuItem2.Image"), System.Drawing.Image)
        Me.SupplierStatementToolStripMenuItem2.Name = "SupplierStatementToolStripMenuItem2"
        Me.SupplierStatementToolStripMenuItem2.Size = New System.Drawing.Size(209, 22)
        Me.SupplierStatementToolStripMenuItem2.Text = "Supplier Statement"
        '
        'CustomerStatementToolStripMenuItem2
        '
        Me.CustomerStatementToolStripMenuItem2.BackColor = System.Drawing.Color.DodgerBlue
        Me.CustomerStatementToolStripMenuItem2.Image = CType(resources.GetObject("CustomerStatementToolStripMenuItem2.Image"), System.Drawing.Image)
        Me.CustomerStatementToolStripMenuItem2.Name = "CustomerStatementToolStripMenuItem2"
        Me.CustomerStatementToolStripMenuItem2.Size = New System.Drawing.Size(209, 22)
        Me.CustomerStatementToolStripMenuItem2.Text = "Customer Statement"
        '
        'CashStatementToolStripMenuItem
        '
        Me.CashStatementToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.CashStatementToolStripMenuItem.Image = CType(resources.GetObject("CashStatementToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CashStatementToolStripMenuItem.Name = "CashStatementToolStripMenuItem"
        Me.CashStatementToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.CashStatementToolStripMenuItem.Text = "Cash Statement"
        '
        'BankStatementToolStripMenuItem
        '
        Me.BankStatementToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.BankStatementToolStripMenuItem.Image = CType(resources.GetObject("BankStatementToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BankStatementToolStripMenuItem.Name = "BankStatementToolStripMenuItem"
        Me.BankStatementToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.BankStatementToolStripMenuItem.Text = "Bank Statement"
        '
        'OwnersStatementToolStripMenuItem
        '
        Me.OwnersStatementToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.OwnersStatementToolStripMenuItem.Image = CType(resources.GetObject("OwnersStatementToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OwnersStatementToolStripMenuItem.Name = "OwnersStatementToolStripMenuItem"
        Me.OwnersStatementToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.OwnersStatementToolStripMenuItem.Text = "Owners Statement"
        '
        'OtherRevenueStatementToolStripMenuItem
        '
        Me.OtherRevenueStatementToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.OtherRevenueStatementToolStripMenuItem.Image = CType(resources.GetObject("OtherRevenueStatementToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OtherRevenueStatementToolStripMenuItem.Name = "OtherRevenueStatementToolStripMenuItem"
        Me.OtherRevenueStatementToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.OtherRevenueStatementToolStripMenuItem.Text = "Other Revenue Statement"
        '
        'ExpensesStatementToolStripMenuItem
        '
        Me.ExpensesStatementToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.ExpensesStatementToolStripMenuItem.Image = CType(resources.GetObject("ExpensesStatementToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExpensesStatementToolStripMenuItem.Name = "ExpensesStatementToolStripMenuItem"
        Me.ExpensesStatementToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.ExpensesStatementToolStripMenuItem.Text = "Expenses Statement"
        '
        'EmployeeStatementToolStripMenuItem1
        '
        Me.EmployeeStatementToolStripMenuItem1.BackColor = System.Drawing.Color.DodgerBlue
        Me.EmployeeStatementToolStripMenuItem1.Image = CType(resources.GetObject("EmployeeStatementToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.EmployeeStatementToolStripMenuItem1.Name = "EmployeeStatementToolStripMenuItem1"
        Me.EmployeeStatementToolStripMenuItem1.Size = New System.Drawing.Size(209, 22)
        Me.EmployeeStatementToolStripMenuItem1.Text = "Employee Statement"
        '
        'SalaryToolStripMenuItem
        '
        Me.SalaryToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GenerateSalaryToolStripMenuItem, Me.EmployeePaymentToolStripMenuItem})
        Me.SalaryToolStripMenuItem.Image = CType(resources.GetObject("SalaryToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SalaryToolStripMenuItem.Name = "SalaryToolStripMenuItem"
        Me.SalaryToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.SalaryToolStripMenuItem.Text = "Salary"
        '
        'GenerateSalaryToolStripMenuItem
        '
        Me.GenerateSalaryToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.GenerateSalaryToolStripMenuItem.Image = CType(resources.GetObject("GenerateSalaryToolStripMenuItem.Image"), System.Drawing.Image)
        Me.GenerateSalaryToolStripMenuItem.Name = "GenerateSalaryToolStripMenuItem"
        Me.GenerateSalaryToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.GenerateSalaryToolStripMenuItem.Text = "Generate Salary"
        '
        'EmployeePaymentToolStripMenuItem
        '
        Me.EmployeePaymentToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.EmployeePaymentToolStripMenuItem.Image = CType(resources.GetObject("EmployeePaymentToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EmployeePaymentToolStripMenuItem.Name = "EmployeePaymentToolStripMenuItem"
        Me.EmployeePaymentToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.EmployeePaymentToolStripMenuItem.Text = "Employee Payment"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.CheckOnClick = True
        Me.PrintToolStripMenuItem.Image = Global.POS.My.Resources.Resources.PRINT_16
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'CostPriceToolStripMenuItem
        '
        Me.CostPriceToolStripMenuItem.CheckOnClick = True
        Me.CostPriceToolStripMenuItem.Image = CType(resources.GetObject("CostPriceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CostPriceToolStripMenuItem.Name = "CostPriceToolStripMenuItem"
        Me.CostPriceToolStripMenuItem.Size = New System.Drawing.Size(88, 20)
        Me.CostPriceToolStripMenuItem.Text = "Cost Price"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Image = CType(resources.GetObject("HelpToolStripMenuItem.Image"), System.Drawing.Image)
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'UltraGroupBox1
        '
        Appearance1.BackColor = System.Drawing.Color.DodgerBlue
        Me.UltraGroupBox1.Appearance = Appearance1
        Me.UltraGroupBox1.BackColorInternal = System.Drawing.Color.White
        Me.UltraGroupBox1.Controls.Add(Me.MenuStrip1)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraGroupBox1.ForeColor = System.Drawing.Color.Black
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(1178, 28)
        Me.UltraGroupBox1.TabIndex = 130
        '
        'UltraGroupBox2
        '
        Appearance2.BackColor = System.Drawing.Color.DarkOrange
        Me.UltraGroupBox2.Appearance = Appearance2
        Me.UltraGroupBox2.BackColorInternal = System.Drawing.Color.White
        Me.UltraGroupBox2.Controls.Add(Me.StatusStrip)
        Me.UltraGroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UltraGroupBox2.ForeColor = System.Drawing.Color.Black
        Me.UltraGroupBox2.Location = New System.Drawing.Point(0, 232)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(1178, 28)
        Me.UltraGroupBox2.TabIndex = 131
        '
        'btnReward
        '
        Me.btnReward.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnReward.Image = CType(resources.GetObject("btnReward.Image"), System.Drawing.Image)
        Me.btnReward.Name = "btnReward"
        Me.btnReward.Size = New System.Drawing.Size(190, 22)
        Me.btnReward.Text = "Reward"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DodgerBlue
        Me.ClientSize = New System.Drawing.Size(1178, 260)
        Me.Controls.Add(Me.UltraGroupBox2)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMain"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        CType(Me.UltraTabbedMdiManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents lblLoginName As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents lblDesignation As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents UltraTabbedMdiManager1 As Infragistics.Win.UltraWinTabbedMdi.UltraTabbedMdiManager
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblVersion As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CostPriceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalaryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GenerateSalaryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmployeePaymentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatementsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SupplierStatementToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomerStatementToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CashStatementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BankStatementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OwnersStatementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OtherRevenueStatementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExpensesStatementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmployeeStatementToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DailySummaryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalesSearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmSalesReports As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnSalesDiscountInBill As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnSalesDiscountReceipt As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnSalesDiscount As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CategoryWiseSaleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SubCategoryWiseSaleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemWiseSaleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomerWiseSaleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomerWiseSaleDetailToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalesBelowCostToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnSaleCancelSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmInventoryReports As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdjustmentReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StockBelowLevelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SlowMovementReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TotalStockValueByCategoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TotalStockValueBySubCategoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TotalStockValueToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmItemReports As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemTurnoverToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnItemMovement As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemMovementSummaryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemMovementSummary2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemSalesMovementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnItemDrillDownEnquiry As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmCustomerReports As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCustomerHistory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomerRotationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomerStatementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCustomerPaid As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCustomerBalance As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCustomerBalanceInDuration As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCustomerMonthlyBalance As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCustomerSales As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmAlert As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemAlertToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemExpiryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SubscriptionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnAccountTypeTotal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AccountsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SupplierToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomerToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CashToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BankToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OwnerToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmployeeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents OtherRevenueToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExpensesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents VoucherToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCheque As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnItemList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnItems As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnItemClass As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnPrintBarcode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnItemCategory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnItemSubCategory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnUMC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SubscribeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnsubscribeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SubscriptionPaymentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ChangePasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UsersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Backup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnConfig As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents OperationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnSalesReturn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PurchaseToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnQuotation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnPromotion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnMembership As ToolStripMenuItem
    Friend WithEvents btnReward As ToolStripMenuItem
End Class
