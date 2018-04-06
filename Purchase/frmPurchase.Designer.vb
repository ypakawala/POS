<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPurchase
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPurchase))
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalAmount")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PaidAmount")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Balance")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Returned")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Discount")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DiscountAtPay")
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim SummarySettings1 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "Balance", 2, True, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "Balance", 2, True)
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim SummarySettings2 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "TotalAmount", 0, True, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "TotalAmount", 0, True)
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim SummarySettings3 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "PaidAmount", 1, True, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "PaidAmount", 1, True)
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim SummarySettings4 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "Returned", 3, True, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "Returned", 3, True)
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim SummarySettings5 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "Discount", 4, True, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "Discount", 4, True)
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim SummarySettings6 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "DiscountAtPay", 5, True, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "DiscountAtPay", 5, True)
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnShowAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnUnPost = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnPayment = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupplierListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PurchaseReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupplierBalanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DebitAgeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AccountStatementToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnPurchasePayment = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSuplierPayment = New System.Windows.Forms.ToolStripMenuItem()
        Me.PurchaseSummaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnPurchaseSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnReturn = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.txtBalance = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.DropSupplier = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.grdList = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.DropSupplier, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraLabel1
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.FontData.BoldAsString = "True"
        Appearance1.FontData.SizeInPoints = 20.0!
        Appearance1.TextHAlignAsString = "Center"
        Appearance1.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance1
        Me.UltraLabel1.BackColorInternal = System.Drawing.Color.White
        Me.UltraLabel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel1.ForeColor = System.Drawing.Color.Black
        Me.UltraLabel1.Location = New System.Drawing.Point(0, 24)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(968, 40)
        Me.UltraLabel1.TabIndex = 10
        Me.UltraLabel1.Text = "Purchase"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip1.ForeColor = System.Drawing.Color.Black
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnEdit, Me.btnDelete, Me.btnShowAll, Me.btnUnPost, Me.btnPrint, Me.btnPayment, Me.btnReturn, Me.SupplierListToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.btnExit})
        Me.MenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.MenuStrip1.Location = New System.Drawing.Point(3, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip1.Size = New System.Drawing.Size(962, 24)
        Me.MenuStrip1.TabIndex = 11
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'btnNew
        '
        Me.btnNew.Image = Global.POS.My.Resources.Resources.ADD_16
        Me.btnNew.Name = "btnNew"
        Me.btnNew.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.btnNew.Size = New System.Drawing.Size(79, 20)
        Me.btnNew.Text = "New [F1]"
        '
        'btnEdit
        '
        Me.btnEdit.Image = Global.POS.My.Resources.Resources.EDIT_16
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.btnEdit.Size = New System.Drawing.Size(76, 20)
        Me.btnEdit.Text = "Edit [F2]"
        '
        'btnDelete
        '
        Me.btnDelete.Image = Global.POS.My.Resources.Resources.DELETE_16
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.btnDelete.Size = New System.Drawing.Size(89, 20)
        Me.btnDelete.Text = "Delete [F3]"
        '
        'btnShowAll
        '
        Me.btnShowAll.CheckOnClick = True
        Me.btnShowAll.Image = CType(resources.GetObject("btnShowAll.Image"), System.Drawing.Image)
        Me.btnShowAll.Name = "btnShowAll"
        Me.btnShowAll.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.btnShowAll.Size = New System.Drawing.Size(98, 20)
        Me.btnShowAll.Text = "Show All [F4]"
        '
        'btnUnPost
        '
        Me.btnUnPost.Image = CType(resources.GetObject("btnUnPost.Image"), System.Drawing.Image)
        Me.btnUnPost.Name = "btnUnPost"
        Me.btnUnPost.Size = New System.Drawing.Size(72, 20)
        Me.btnUnPost.Text = "Un Post"
        '
        'btnPrint
        '
        Me.btnPrint.Image = Global.POS.My.Resources.Resources.PRINT_16
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.btnPrint.Size = New System.Drawing.Size(80, 20)
        Me.btnPrint.Text = "Print [F5]"
        '
        'btnPayment
        '
        Me.btnPayment.Image = CType(resources.GetObject("btnPayment.Image"), System.Drawing.Image)
        Me.btnPayment.Name = "btnPayment"
        Me.btnPayment.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.btnPayment.Size = New System.Drawing.Size(124, 20)
        Me.btnPayment.Text = "New Payment [F6]"
        '
        'SupplierListToolStripMenuItem
        '
        Me.SupplierListToolStripMenuItem.Image = CType(resources.GetObject("SupplierListToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SupplierListToolStripMenuItem.Name = "SupplierListToolStripMenuItem"
        Me.SupplierListToolStripMenuItem.Size = New System.Drawing.Size(92, 20)
        Me.SupplierListToolStripMenuItem.Text = "Supplier List"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PurchaseReportToolStripMenuItem, Me.SupplierBalanceToolStripMenuItem, Me.DebitAgeToolStripMenuItem, Me.AccountStatementToolStripMenuItem1, Me.btnPurchasePayment, Me.btnSuplierPayment, Me.PurchaseSummaryToolStripMenuItem, Me.btnPurchaseSearch})
        Me.ReportsToolStripMenuItem.Image = CType(resources.GetObject("ReportsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(73, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PurchaseReportToolStripMenuItem
        '
        Me.PurchaseReportToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.PurchaseReportToolStripMenuItem.Image = CType(resources.GetObject("PurchaseReportToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PurchaseReportToolStripMenuItem.Name = "PurchaseReportToolStripMenuItem"
        Me.PurchaseReportToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8
        Me.PurchaseReportToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.PurchaseReportToolStripMenuItem.Text = "Purchase Report"
        '
        'SupplierBalanceToolStripMenuItem
        '
        Me.SupplierBalanceToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.SupplierBalanceToolStripMenuItem.Image = CType(resources.GetObject("SupplierBalanceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SupplierBalanceToolStripMenuItem.Name = "SupplierBalanceToolStripMenuItem"
        Me.SupplierBalanceToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9
        Me.SupplierBalanceToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.SupplierBalanceToolStripMenuItem.Text = "Supplier Balance"
        '
        'DebitAgeToolStripMenuItem
        '
        Me.DebitAgeToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.DebitAgeToolStripMenuItem.Image = CType(resources.GetObject("DebitAgeToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DebitAgeToolStripMenuItem.Name = "DebitAgeToolStripMenuItem"
        Me.DebitAgeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10
        Me.DebitAgeToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.DebitAgeToolStripMenuItem.Text = "Debit Age"
        '
        'AccountStatementToolStripMenuItem1
        '
        Me.AccountStatementToolStripMenuItem1.BackColor = System.Drawing.Color.DodgerBlue
        Me.AccountStatementToolStripMenuItem1.Image = CType(resources.GetObject("AccountStatementToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.AccountStatementToolStripMenuItem1.Name = "AccountStatementToolStripMenuItem1"
        Me.AccountStatementToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F11
        Me.AccountStatementToolStripMenuItem1.Size = New System.Drawing.Size(191, 22)
        Me.AccountStatementToolStripMenuItem1.Text = "Account Statement"
        '
        'btnPurchasePayment
        '
        Me.btnPurchasePayment.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnPurchasePayment.Image = CType(resources.GetObject("btnPurchasePayment.Image"), System.Drawing.Image)
        Me.btnPurchasePayment.Name = "btnPurchasePayment"
        Me.btnPurchasePayment.Size = New System.Drawing.Size(191, 22)
        Me.btnPurchasePayment.Text = "Purchase Payment"
        '
        'btnSuplierPayment
        '
        Me.btnSuplierPayment.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnSuplierPayment.Image = CType(resources.GetObject("btnSuplierPayment.Image"), System.Drawing.Image)
        Me.btnSuplierPayment.Name = "btnSuplierPayment"
        Me.btnSuplierPayment.Size = New System.Drawing.Size(191, 22)
        Me.btnSuplierPayment.Text = "Suplier Payment"
        Me.btnSuplierPayment.Visible = False
        '
        'PurchaseSummaryToolStripMenuItem
        '
        Me.PurchaseSummaryToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue
        Me.PurchaseSummaryToolStripMenuItem.Image = Global.POS.My.Resources.Resources.form_red
        Me.PurchaseSummaryToolStripMenuItem.Name = "PurchaseSummaryToolStripMenuItem"
        Me.PurchaseSummaryToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.PurchaseSummaryToolStripMenuItem.Text = "Purchase Summary"
        Me.PurchaseSummaryToolStripMenuItem.Visible = False
        '
        'btnPurchaseSearch
        '
        Me.btnPurchaseSearch.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnPurchaseSearch.Image = Global.POS.My.Resources.Resources.VIEW
        Me.btnPurchaseSearch.Name = "btnPurchaseSearch"
        Me.btnPurchaseSearch.Size = New System.Drawing.Size(191, 22)
        Me.btnPurchaseSearch.Text = "Purchase Search"
        '
        'btnReturn
        '
        Me.btnReturn.Image = Global.POS.My.Resources.Resources.UNDO_16
        Me.btnReturn.Name = "btnReturn"
        Me.btnReturn.ShortcutKeys = System.Windows.Forms.Keys.F7
        Me.btnReturn.ShowShortcutKeys = False
        Me.btnReturn.Size = New System.Drawing.Size(91, 20)
        Me.btnReturn.Text = "Return [F7]"
        '
        'btnExit
        '
        Me.btnExit.Image = Global.POS.My.Resources.Resources.CLOSE_16
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(82, 20)
        Me.btnExit.Text = "Exit [End]"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.BackColorInternal = System.Drawing.Color.White
        Me.UltraGroupBox1.Controls.Add(Me.txtBalance)
        Me.UltraGroupBox1.Controls.Add(Me.DropSupplier)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel3)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel2)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraGroupBox1.ForeColor = System.Drawing.Color.Black
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 64)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(968, 51)
        Me.UltraGroupBox1.TabIndex = 15
        Me.UltraGroupBox1.Text = "Search"
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'txtBalance
        '
        Appearance18.BackColor = System.Drawing.Color.White
        Appearance18.ForeColor = System.Drawing.Color.Black
        Me.txtBalance.Appearance = Appearance18
        Me.txtBalance.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtBalance.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.[Double]
        Me.txtBalance.InputMask = "{double:-9.3}"
        Me.txtBalance.Location = New System.Drawing.Point(432, 19)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.ReadOnly = True
        Me.txtBalance.Size = New System.Drawing.Size(100, 20)
        Me.txtBalance.TabIndex = 2
        Me.txtBalance.TabStop = False
        Me.txtBalance.Text = "UltraMaskedEdit1"
        '
        'DropSupplier
        '
        Me.DropSupplier.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Appearance19.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.DropSupplier.DisplayLayout.Appearance = Appearance19
        Me.DropSupplier.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.DropSupplier.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.BorderColor = System.Drawing.SystemColors.Window
        Me.DropSupplier.DisplayLayout.GroupByBox.Appearance = Appearance3
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropSupplier.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance4
        Me.DropSupplier.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance5.BackColor2 = System.Drawing.SystemColors.Control
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropSupplier.DisplayLayout.GroupByBox.PromptAppearance = Appearance5
        Me.DropSupplier.DisplayLayout.MaxColScrollRegions = 1
        Me.DropSupplier.DisplayLayout.MaxRowScrollRegions = 1
        Appearance6.BackColor = System.Drawing.SystemColors.Window
        Appearance6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DropSupplier.DisplayLayout.Override.ActiveCellAppearance = Appearance6
        Appearance7.BackColor = System.Drawing.SystemColors.Highlight
        Appearance7.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.DropSupplier.DisplayLayout.Override.ActiveRowAppearance = Appearance7
        Me.DropSupplier.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.DropSupplier.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Me.DropSupplier.DisplayLayout.Override.CardAreaAppearance = Appearance8
        Appearance9.BorderColor = System.Drawing.Color.Silver
        Appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.DropSupplier.DisplayLayout.Override.CellAppearance = Appearance9
        Me.DropSupplier.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.DropSupplier.DisplayLayout.Override.CellPadding = 0
        Appearance10.BackColor = System.Drawing.SystemColors.Control
        Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance10.BorderColor = System.Drawing.SystemColors.Window
        Me.DropSupplier.DisplayLayout.Override.GroupByRowAppearance = Appearance10
        Appearance11.TextHAlignAsString = "Left"
        Me.DropSupplier.DisplayLayout.Override.HeaderAppearance = Appearance11
        Me.DropSupplier.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.DropSupplier.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.BorderColor = System.Drawing.Color.Silver
        Me.DropSupplier.DisplayLayout.Override.RowAppearance = Appearance12
        Me.DropSupplier.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance13.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DropSupplier.DisplayLayout.Override.TemplateAddRowAppearance = Appearance13
        Me.DropSupplier.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.DropSupplier.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.DropSupplier.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.DropSupplier.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.DropSupplier.Location = New System.Drawing.Point(67, 19)
        Me.DropSupplier.Name = "DropSupplier"
        Me.DropSupplier.Size = New System.Drawing.Size(296, 23)
        Me.DropSupplier.TabIndex = 1
        '
        'UltraLabel3
        '
        Appearance14.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel3.Appearance = Appearance14
        Me.UltraLabel3.AutoSize = True
        Me.UltraLabel3.ForeColor = System.Drawing.Color.Black
        Me.UltraLabel3.Location = New System.Drawing.Point(380, 19)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(45, 15)
        Me.UltraLabel3.TabIndex = 0
        Me.UltraLabel3.Text = "Balance:"
        '
        'UltraLabel2
        '
        Appearance15.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel2.Appearance = Appearance15
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.ForeColor = System.Drawing.Color.Black
        Me.UltraLabel2.Location = New System.Drawing.Point(12, 19)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(43, 15)
        Me.UltraLabel2.TabIndex = 0
        Me.UltraLabel2.Text = "Supplier"
        '
        'grdList
        '
        Appearance16.BackColor = System.Drawing.Color.White
        Me.grdList.DisplayLayout.Appearance = Appearance16
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.Header.VisiblePosition = 1
        UltraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn2.Header.VisiblePosition = 2
        UltraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn3.Header.VisiblePosition = 0
        UltraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6})
        UltraGridBand1.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.TopFixed
        UltraGridBand1.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance17.BackColor = System.Drawing.Color.Black
        Appearance17.ForeColor = System.Drawing.Color.White
        UltraGridBand1.Override.SummaryValueAppearance = Appearance17
        SummarySettings1.DisplayFormat = "{0:#####.###}"
        SummarySettings1.GroupBySummaryValueAppearance = Appearance21
        SummarySettings1.ShowCalculatingText = Infragistics.Win.DefaultableBoolean.[False]
        SummarySettings1.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.TopFixed
        SummarySettings2.DisplayFormat = "{0:#####.###}"
        SummarySettings2.GroupBySummaryValueAppearance = Appearance22
        SummarySettings2.ShowCalculatingText = Infragistics.Win.DefaultableBoolean.[False]
        SummarySettings2.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.TopFixed
        SummarySettings3.DisplayFormat = "{0:#####.###}"
        SummarySettings3.GroupBySummaryValueAppearance = Appearance23
        SummarySettings3.ShowCalculatingText = Infragistics.Win.DefaultableBoolean.[False]
        SummarySettings3.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.TopFixed
        SummarySettings4.DisplayFormat = "{0:#####.###}"
        SummarySettings4.GroupBySummaryValueAppearance = Appearance24
        SummarySettings4.ShowCalculatingText = Infragistics.Win.DefaultableBoolean.[False]
        SummarySettings4.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.TopFixed
        SummarySettings5.DisplayFormat = "{0:#####.###}"
        SummarySettings5.GroupBySummaryValueAppearance = Appearance25
        SummarySettings5.ShowCalculatingText = Infragistics.Win.DefaultableBoolean.[False]
        SummarySettings5.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.TopFixed
        SummarySettings6.DisplayFormat = "{0:#####.###}"
        SummarySettings6.GroupBySummaryValueAppearance = Appearance26
        SummarySettings6.ShowCalculatingText = Infragistics.Win.DefaultableBoolean.[False]
        SummarySettings6.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.TopFixed
        UltraGridBand1.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings1, SummarySettings2, SummarySettings3, SummarySettings4, SummarySettings5, SummarySettings6})
        Me.grdList.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.grdList.DisplayLayout.MaxColScrollRegions = 1
        Me.grdList.DisplayLayout.MaxRowScrollRegions = 1
        Me.grdList.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdList.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None
        Appearance27.BackColor = System.Drawing.Color.Transparent
        Me.grdList.DisplayLayout.Override.CardAreaAppearance = Appearance27
        Me.grdList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdList.DisplayLayout.Override.CellPadding = 3
        Me.grdList.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance28.TextHAlignAsString = "Left"
        Me.grdList.DisplayLayout.Override.HeaderAppearance = Appearance28
        Me.grdList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance29.BorderColor = System.Drawing.Color.LightGray
        Appearance29.TextVAlignAsString = "Middle"
        Me.grdList.DisplayLayout.Override.RowAppearance = Appearance29
        Appearance38.BackColor = System.Drawing.Color.LightSteelBlue
        Appearance38.BorderColor = System.Drawing.Color.Black
        Appearance38.ForeColor = System.Drawing.Color.Black
        Me.grdList.DisplayLayout.Override.SelectedRowAppearance = Appearance38
        Me.grdList.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None
        Me.grdList.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdList.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdList.Location = New System.Drawing.Point(0, 115)
        Me.grdList.Name = "grdList"
        Me.grdList.Size = New System.Drawing.Size(968, 201)
        Me.grdList.TabIndex = 16
        '
        'UltraGroupBox2
        '
        Appearance2.BackColor = System.Drawing.Color.DodgerBlue
        Me.UltraGroupBox2.Appearance = Appearance2
        Me.UltraGroupBox2.BackColorInternal = System.Drawing.Color.White
        Me.UltraGroupBox2.Controls.Add(Me.MenuStrip1)
        Me.UltraGroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraGroupBox2.ForeColor = System.Drawing.Color.Black
        Me.UltraGroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(968, 24)
        Me.UltraGroupBox2.TabIndex = 130
        '
        'frmPurchase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(968, 316)
        Me.Controls.Add(Me.grdList)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.UltraLabel1)
        Me.Controls.Add(Me.UltraGroupBox2)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmPurchase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.DropSupplier, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnShowAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnPayment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PurchaseReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SupplierBalanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DebitAgeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AccountStatementToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SupplierListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnUnPost As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PurchaseSummaryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnReturn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtBalance As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents DropSupplier As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents grdList As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnPurchasePayment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnPurchaseSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnSuplierPayment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
End Class
