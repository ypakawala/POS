<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSailSearch
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
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("BillNo")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalBill")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Discount")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NetBill")
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim SummarySettings1 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "TotalBill", 1, True, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "TotalBill", 1, True)
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim SummarySettings2 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "Discount", 2, True, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "Discount", 2, True)
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim SummarySettings3 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "NetBill", 3, True, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "NetBill", 3, True)
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim SummarySettings4 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Count, Nothing, "BillNo", 0, True, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "BillNo", 0, True)
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance73 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance74 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSailSearch))
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance75 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance70 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance76 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance77 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance78 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance79 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance61 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance65 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance67 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance68 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance69 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance80 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance71 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance82 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance81 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance72 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab4 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.grdList = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.CRV_Receipt = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.UltraTabPageControl3 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.CRV_DetailBill = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnClearAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.UltraExpandableGroupBox1 = New Infragistics.Win.Misc.UltraExpandableGroupBox()
        Me.UltraExpandableGroupBoxPanel1 = New Infragistics.Win.Misc.UltraExpandableGroupBoxPanel()
        Me.txtSerailNum = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtPONumber = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtTotalTo = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.txtBillTo = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.txtBillFrom = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.txtTotalFrom = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.DropCounter = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.DropCustomer = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.DropUser = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.DropItem = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.UltraLabel15 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtDateTo = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.UltraLabel13 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel9 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtDateFrom = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.UltraLabel16 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel14 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel10 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel11 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl2.SuspendLayout()
        Me.UltraTabPageControl3.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.UltraExpandableGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraExpandableGroupBox1.SuspendLayout()
        Me.UltraExpandableGroupBoxPanel1.SuspendLayout()
        CType(Me.txtSerailNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPONumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DropCounter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DropCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DropUser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DropItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDateTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDateFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.grdList)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 22)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(654, 185)
        '
        'grdList
        '
        Appearance7.BackColor = System.Drawing.Color.White
        Me.grdList.DisplayLayout.Appearance = Appearance7
        Me.grdList.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4})
        UltraGridBand1.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance8.BackColor = System.Drawing.Color.Black
        Appearance8.ForeColor = System.Drawing.Color.White
        UltraGridBand1.Override.SummaryValueAppearance = Appearance8
        SummarySettings1.DisplayFormat = "Sum = {0:#####.###}"
        SummarySettings1.GroupBySummaryValueAppearance = Appearance9
        SummarySettings1.ShowCalculatingText = Infragistics.Win.DefaultableBoolean.[False]
        SummarySettings1.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.TopFixed
        SummarySettings2.DisplayFormat = "Sum = {0:#####.###}"
        SummarySettings2.GroupBySummaryValueAppearance = Appearance10
        SummarySettings2.ShowCalculatingText = Infragistics.Win.DefaultableBoolean.[False]
        SummarySettings2.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.TopFixed
        SummarySettings3.DisplayFormat = "Sum = {0:#####.###}"
        SummarySettings3.GroupBySummaryValueAppearance = Appearance11
        SummarySettings3.ShowCalculatingText = Infragistics.Win.DefaultableBoolean.[False]
        SummarySettings3.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.TopFixed
        SummarySettings4.DisplayFormat = "Count = {0:#####.###}"
        SummarySettings4.GroupBySummaryValueAppearance = Appearance12
        SummarySettings4.ShowCalculatingText = Infragistics.Win.DefaultableBoolean.[False]
        SummarySettings4.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.TopFixed
        UltraGridBand1.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings1, SummarySettings2, SummarySettings3, SummarySettings4})
        Me.grdList.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.grdList.DisplayLayout.MaxColScrollRegions = 1
        Me.grdList.DisplayLayout.MaxRowScrollRegions = 1
        Me.grdList.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdList.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None
        Appearance13.BackColor = System.Drawing.Color.Transparent
        Me.grdList.DisplayLayout.Override.CardAreaAppearance = Appearance13
        Me.grdList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdList.DisplayLayout.Override.CellPadding = 3
        Me.grdList.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance27.TextHAlignAsString = "Left"
        Me.grdList.DisplayLayout.Override.HeaderAppearance = Appearance27
        Me.grdList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance73.BorderColor = System.Drawing.Color.LightGray
        Appearance73.TextVAlignAsString = "Middle"
        Me.grdList.DisplayLayout.Override.RowAppearance = Appearance73
        Appearance74.BackColor = System.Drawing.Color.LightSteelBlue
        Appearance74.BorderColor = System.Drawing.Color.Black
        Appearance74.ForeColor = System.Drawing.Color.Black
        Me.grdList.DisplayLayout.Override.SelectedRowAppearance = Appearance74
        Me.grdList.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None
        Me.grdList.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdList.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdList.Location = New System.Drawing.Point(0, 0)
        Me.grdList.Name = "grdList"
        Me.grdList.Size = New System.Drawing.Size(654, 185)
        Me.grdList.TabIndex = 0
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.CRV_Receipt)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(654, 161)
        '
        'CRV_Receipt
        '
        Me.CRV_Receipt.ActiveViewIndex = -1
        Me.CRV_Receipt.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CRV_Receipt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRV_Receipt.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRV_Receipt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRV_Receipt.ForeColor = System.Drawing.Color.Black
        Me.CRV_Receipt.Location = New System.Drawing.Point(0, 0)
        Me.CRV_Receipt.Name = "CRV_Receipt"
        Me.CRV_Receipt.Size = New System.Drawing.Size(654, 161)
        Me.CRV_Receipt.TabIndex = 1
        '
        'UltraTabPageControl3
        '
        Me.UltraTabPageControl3.Controls.Add(Me.CRV_DetailBill)
        Me.UltraTabPageControl3.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl3.Name = "UltraTabPageControl3"
        Me.UltraTabPageControl3.Size = New System.Drawing.Size(654, 161)
        '
        'CRV_DetailBill
        '
        Me.CRV_DetailBill.ActiveViewIndex = -1
        Me.CRV_DetailBill.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CRV_DetailBill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRV_DetailBill.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRV_DetailBill.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRV_DetailBill.ForeColor = System.Drawing.Color.Black
        Me.CRV_DetailBill.Location = New System.Drawing.Point(0, 0)
        Me.CRV_DetailBill.Name = "CRV_DetailBill"
        Me.CRV_DetailBill.Size = New System.Drawing.Size(654, 161)
        Me.CRV_DetailBill.TabIndex = 2
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip1.ForeColor = System.Drawing.Color.Black
        Me.MenuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSearch, Me.btnClearAll, Me.btnEdit, Me.btnDelete, Me.btnExit})
        Me.MenuStrip1.Location = New System.Drawing.Point(3, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(650, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'btnSearch
        '
        Me.btnSearch.Image = Global.POS.My.Resources.Resources.VIEW
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.btnSearch.Size = New System.Drawing.Size(93, 20)
        Me.btnSearch.Text = "Search [F1]"
        '
        'btnClearAll
        '
        Me.btnClearAll.Image = CType(resources.GetObject("btnClearAll.Image"), System.Drawing.Image)
        Me.btnClearAll.Name = "btnClearAll"
        Me.btnClearAll.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.btnClearAll.Size = New System.Drawing.Size(102, 20)
        Me.btnClearAll.Text = "Clear All [F2]"
        '
        'btnEdit
        '
        Me.btnEdit.Image = Global.POS.My.Resources.Resources.EDIT_16
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.btnEdit.Size = New System.Drawing.Size(78, 20)
        Me.btnEdit.Text = "Edit [F3]"
        '
        'btnDelete
        '
        Me.btnDelete.Image = Global.POS.My.Resources.Resources.UNDO_16
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.btnDelete.Size = New System.Drawing.Size(93, 20)
        Me.btnDelete.Text = "Return [F4]"
        '
        'btnExit
        '
        Me.btnExit.Image = Global.POS.My.Resources.Resources.CLOSE_16
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(84, 20)
        Me.btnExit.Text = "Exit [End]"
        '
        'UltraExpandableGroupBox1
        '
        Me.UltraExpandableGroupBox1.BackColorInternal = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.UltraExpandableGroupBox1.Controls.Add(Me.UltraExpandableGroupBoxPanel1)
        Me.UltraExpandableGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraExpandableGroupBox1.ExpandedSize = New System.Drawing.Size(656, 185)
        Me.UltraExpandableGroupBox1.ForeColor = System.Drawing.Color.Black
        Me.UltraExpandableGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraExpandableGroupBox1.Name = "UltraExpandableGroupBox1"
        Me.UltraExpandableGroupBox1.Size = New System.Drawing.Size(656, 185)
        Me.UltraExpandableGroupBox1.TabIndex = 0
        Me.UltraExpandableGroupBox1.Text = "Criteria"
        Me.UltraExpandableGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraExpandableGroupBoxPanel1
        '
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.txtSerailNum)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.txtPONumber)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UltraLabel4)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UltraLabel3)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.txtTotalTo)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.txtBillTo)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.txtBillFrom)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.txtTotalFrom)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.DropCounter)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.DropCustomer)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.DropUser)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.DropItem)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UltraLabel15)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.txtDateTo)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UltraLabel13)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UltraLabel2)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UltraLabel9)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UltraLabel1)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.txtDateFrom)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UltraLabel16)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UltraLabel14)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UltraLabel10)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UltraLabel12)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UltraLabel11)
        Me.UltraExpandableGroupBoxPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraExpandableGroupBoxPanel1.ForeColor = System.Drawing.Color.Black
        Me.UltraExpandableGroupBoxPanel1.Location = New System.Drawing.Point(3, 20)
        Me.UltraExpandableGroupBoxPanel1.Name = "UltraExpandableGroupBoxPanel1"
        Me.UltraExpandableGroupBoxPanel1.Size = New System.Drawing.Size(650, 162)
        Me.UltraExpandableGroupBoxPanel1.TabIndex = 0
        '
        'txtSerailNum
        '
        Appearance6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance6.ForeColor = System.Drawing.Color.Black
        Me.txtSerailNum.Appearance = Appearance6
        Me.txtSerailNum.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSerailNum.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtSerailNum.ForeColor = System.Drawing.Color.Black
        Me.txtSerailNum.Location = New System.Drawing.Point(73, 139)
        Me.txtSerailNum.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSerailNum.Name = "txtSerailNum"
        Me.txtSerailNum.Size = New System.Drawing.Size(488, 22)
        Me.txtSerailNum.TabIndex = 11
        '
        'txtPONumber
        '
        Appearance75.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance75.ForeColor = System.Drawing.Color.Black
        Me.txtPONumber.Appearance = Appearance75
        Me.txtPONumber.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPONumber.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtPONumber.ForeColor = System.Drawing.Color.Black
        Me.txtPONumber.Location = New System.Drawing.Point(440, 56)
        Me.txtPONumber.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtPONumber.Name = "txtPONumber"
        Me.txtPONumber.Size = New System.Drawing.Size(121, 22)
        Me.txtPONumber.TabIndex = 8
        '
        'UltraLabel4
        '
        Appearance26.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel4.Appearance = Appearance26
        Me.UltraLabel4.AutoSize = True
        Me.UltraLabel4.ForeColor = System.Drawing.Color.Black
        Me.UltraLabel4.Location = New System.Drawing.Point(10, 144)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(42, 15)
        Me.UltraLabel4.TabIndex = 11
        Me.UltraLabel4.Text = "Serial #"
        '
        'UltraLabel3
        '
        Appearance70.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel3.Appearance = Appearance70
        Me.UltraLabel3.AutoSize = True
        Me.UltraLabel3.ForeColor = System.Drawing.Color.Black
        Me.UltraLabel3.Location = New System.Drawing.Point(376, 56)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(29, 15)
        Me.UltraLabel3.TabIndex = 10
        Me.UltraLabel3.Text = "PO #"
        '
        'txtTotalTo
        '
        Appearance76.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance76.ForeColor = System.Drawing.Color.Black
        Me.txtTotalTo.Appearance = Appearance76
        Me.txtTotalTo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtTotalTo.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.[Double]
        Me.txtTotalTo.InputMask = "{double:5.3}"
        Me.txtTotalTo.Location = New System.Drawing.Point(253, 30)
        Me.txtTotalTo.Name = "txtTotalTo"
        Me.txtTotalTo.Size = New System.Drawing.Size(121, 20)
        Me.txtTotalTo.TabIndex = 4
        '
        'txtBillTo
        '
        Appearance77.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance77.ForeColor = System.Drawing.Color.Black
        Me.txtBillTo.Appearance = Appearance77
        Me.txtBillTo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtBillTo.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.[Integer]
        Me.txtBillTo.InputMask = "nnnnnnnnn"
        Me.txtBillTo.Location = New System.Drawing.Point(253, 56)
        Me.txtBillTo.Name = "txtBillTo"
        Me.txtBillTo.Size = New System.Drawing.Size(121, 20)
        Me.txtBillTo.TabIndex = 7
        '
        'txtBillFrom
        '
        Appearance78.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance78.ForeColor = System.Drawing.Color.Black
        Me.txtBillFrom.Appearance = Appearance78
        Me.txtBillFrom.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtBillFrom.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.[Integer]
        Me.txtBillFrom.InputMask = "nnnnnnnnn"
        Me.txtBillFrom.Location = New System.Drawing.Point(73, 56)
        Me.txtBillFrom.Name = "txtBillFrom"
        Me.txtBillFrom.Size = New System.Drawing.Size(121, 20)
        Me.txtBillFrom.TabIndex = 6
        '
        'txtTotalFrom
        '
        Appearance79.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance79.ForeColor = System.Drawing.Color.Black
        Me.txtTotalFrom.Appearance = Appearance79
        Me.txtTotalFrom.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtTotalFrom.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.[Double]
        Me.txtTotalFrom.InputMask = "{double:5.3}"
        Me.txtTotalFrom.Location = New System.Drawing.Point(73, 30)
        Me.txtTotalFrom.Name = "txtTotalFrom"
        Me.txtTotalFrom.Size = New System.Drawing.Size(121, 20)
        Me.txtTotalFrom.TabIndex = 3
        '
        'DropCounter
        '
        Me.DropCounter.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance46.BackColor = System.Drawing.SystemColors.Window
        Appearance46.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.DropCounter.DisplayLayout.Appearance = Appearance46
        Me.DropCounter.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.DropCounter.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance47.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance47.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance47.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance47.BorderColor = System.Drawing.SystemColors.Window
        Me.DropCounter.DisplayLayout.GroupByBox.Appearance = Appearance47
        Appearance48.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropCounter.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance48
        Me.DropCounter.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance49.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance49.BackColor2 = System.Drawing.SystemColors.Control
        Appearance49.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance49.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropCounter.DisplayLayout.GroupByBox.PromptAppearance = Appearance49
        Me.DropCounter.DisplayLayout.MaxColScrollRegions = 1
        Me.DropCounter.DisplayLayout.MaxRowScrollRegions = 1
        Appearance50.BackColor = System.Drawing.SystemColors.Window
        Appearance50.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DropCounter.DisplayLayout.Override.ActiveCellAppearance = Appearance50
        Appearance51.BackColor = System.Drawing.SystemColors.Highlight
        Appearance51.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.DropCounter.DisplayLayout.Override.ActiveRowAppearance = Appearance51
        Me.DropCounter.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.DropCounter.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance52.BackColor = System.Drawing.SystemColors.Window
        Me.DropCounter.DisplayLayout.Override.CardAreaAppearance = Appearance52
        Appearance53.BorderColor = System.Drawing.Color.Silver
        Appearance53.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.DropCounter.DisplayLayout.Override.CellAppearance = Appearance53
        Me.DropCounter.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.DropCounter.DisplayLayout.Override.CellPadding = 0
        Appearance54.BackColor = System.Drawing.SystemColors.Control
        Appearance54.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance54.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance54.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance54.BorderColor = System.Drawing.SystemColors.Window
        Me.DropCounter.DisplayLayout.Override.GroupByRowAppearance = Appearance54
        Appearance55.TextHAlignAsString = "Left"
        Me.DropCounter.DisplayLayout.Override.HeaderAppearance = Appearance55
        Me.DropCounter.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.DropCounter.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance56.BackColor = System.Drawing.SystemColors.Window
        Appearance56.BorderColor = System.Drawing.Color.Silver
        Me.DropCounter.DisplayLayout.Override.RowAppearance = Appearance56
        Me.DropCounter.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance57.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DropCounter.DisplayLayout.Override.TemplateAddRowAppearance = Appearance57
        Me.DropCounter.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.DropCounter.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.DropCounter.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.DropCounter.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.DropCounter.Location = New System.Drawing.Point(440, 30)
        Me.DropCounter.Name = "DropCounter"
        Me.DropCounter.Size = New System.Drawing.Size(121, 23)
        Me.DropCounter.TabIndex = 5
        '
        'DropCustomer
        '
        Me.DropCustomer.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Appearance14.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.DropCustomer.DisplayLayout.Appearance = Appearance14
        Me.DropCustomer.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.DropCustomer.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance15.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance15.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance15.BorderColor = System.Drawing.SystemColors.Window
        Me.DropCustomer.DisplayLayout.GroupByBox.Appearance = Appearance15
        Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropCustomer.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance16
        Me.DropCustomer.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance17.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance17.BackColor2 = System.Drawing.SystemColors.Control
        Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance17.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropCustomer.DisplayLayout.GroupByBox.PromptAppearance = Appearance17
        Me.DropCustomer.DisplayLayout.MaxColScrollRegions = 1
        Me.DropCustomer.DisplayLayout.MaxRowScrollRegions = 1
        Appearance18.BackColor = System.Drawing.SystemColors.Window
        Appearance18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DropCustomer.DisplayLayout.Override.ActiveCellAppearance = Appearance18
        Appearance19.BackColor = System.Drawing.SystemColors.Highlight
        Appearance19.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.DropCustomer.DisplayLayout.Override.ActiveRowAppearance = Appearance19
        Me.DropCustomer.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.DropCustomer.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance20.BackColor = System.Drawing.SystemColors.Window
        Me.DropCustomer.DisplayLayout.Override.CardAreaAppearance = Appearance20
        Appearance21.BorderColor = System.Drawing.Color.Silver
        Appearance21.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.DropCustomer.DisplayLayout.Override.CellAppearance = Appearance21
        Me.DropCustomer.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.DropCustomer.DisplayLayout.Override.CellPadding = 0
        Appearance22.BackColor = System.Drawing.SystemColors.Control
        Appearance22.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance22.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance22.BorderColor = System.Drawing.SystemColors.Window
        Me.DropCustomer.DisplayLayout.Override.GroupByRowAppearance = Appearance22
        Appearance23.TextHAlignAsString = "Left"
        Me.DropCustomer.DisplayLayout.Override.HeaderAppearance = Appearance23
        Me.DropCustomer.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.DropCustomer.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance24.BackColor = System.Drawing.SystemColors.Window
        Appearance24.BorderColor = System.Drawing.Color.Silver
        Me.DropCustomer.DisplayLayout.Override.RowAppearance = Appearance24
        Me.DropCustomer.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance25.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DropCustomer.DisplayLayout.Override.TemplateAddRowAppearance = Appearance25
        Me.DropCustomer.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.DropCustomer.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.DropCustomer.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.DropCustomer.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.DropCustomer.Location = New System.Drawing.Point(73, 110)
        Me.DropCustomer.Name = "DropCustomer"
        Me.DropCustomer.Size = New System.Drawing.Size(488, 23)
        Me.DropCustomer.TabIndex = 10
        '
        'DropUser
        '
        Me.DropUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance58.BackColor = System.Drawing.SystemColors.Window
        Appearance58.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.DropUser.DisplayLayout.Appearance = Appearance58
        Me.DropUser.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.DropUser.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance59.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance59.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance59.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance59.BorderColor = System.Drawing.SystemColors.Window
        Me.DropUser.DisplayLayout.GroupByBox.Appearance = Appearance59
        Appearance60.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropUser.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance60
        Me.DropUser.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance61.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance61.BackColor2 = System.Drawing.SystemColors.Control
        Appearance61.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance61.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropUser.DisplayLayout.GroupByBox.PromptAppearance = Appearance61
        Me.DropUser.DisplayLayout.MaxColScrollRegions = 1
        Me.DropUser.DisplayLayout.MaxRowScrollRegions = 1
        Appearance62.BackColor = System.Drawing.SystemColors.Window
        Appearance62.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DropUser.DisplayLayout.Override.ActiveCellAppearance = Appearance62
        Appearance63.BackColor = System.Drawing.SystemColors.Highlight
        Appearance63.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.DropUser.DisplayLayout.Override.ActiveRowAppearance = Appearance63
        Me.DropUser.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.DropUser.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance64.BackColor = System.Drawing.SystemColors.Window
        Me.DropUser.DisplayLayout.Override.CardAreaAppearance = Appearance64
        Appearance65.BorderColor = System.Drawing.Color.Silver
        Appearance65.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.DropUser.DisplayLayout.Override.CellAppearance = Appearance65
        Me.DropUser.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.DropUser.DisplayLayout.Override.CellPadding = 0
        Appearance66.BackColor = System.Drawing.SystemColors.Control
        Appearance66.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance66.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance66.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance66.BorderColor = System.Drawing.SystemColors.Window
        Me.DropUser.DisplayLayout.Override.GroupByRowAppearance = Appearance66
        Appearance67.TextHAlignAsString = "Left"
        Me.DropUser.DisplayLayout.Override.HeaderAppearance = Appearance67
        Me.DropUser.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.DropUser.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance68.BackColor = System.Drawing.SystemColors.Window
        Appearance68.BorderColor = System.Drawing.Color.Silver
        Me.DropUser.DisplayLayout.Override.RowAppearance = Appearance68
        Me.DropUser.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance69.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DropUser.DisplayLayout.Override.TemplateAddRowAppearance = Appearance69
        Me.DropUser.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.DropUser.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.DropUser.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.DropUser.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.DropUser.Location = New System.Drawing.Point(440, 3)
        Me.DropUser.Name = "DropUser"
        Me.DropUser.Size = New System.Drawing.Size(121, 23)
        Me.DropUser.TabIndex = 2
        '
        'DropItem
        '
        Me.DropItem.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance31.BackColor = System.Drawing.SystemColors.Window
        Appearance31.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.DropItem.DisplayLayout.Appearance = Appearance31
        Me.DropItem.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.DropItem.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance32.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance32.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance32.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance32.BorderColor = System.Drawing.SystemColors.Window
        Me.DropItem.DisplayLayout.GroupByBox.Appearance = Appearance32
        Appearance33.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropItem.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance33
        Me.DropItem.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance34.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance34.BackColor2 = System.Drawing.SystemColors.Control
        Appearance34.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance34.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropItem.DisplayLayout.GroupByBox.PromptAppearance = Appearance34
        Me.DropItem.DisplayLayout.MaxColScrollRegions = 1
        Me.DropItem.DisplayLayout.MaxRowScrollRegions = 1
        Appearance35.BackColor = System.Drawing.SystemColors.Window
        Appearance35.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DropItem.DisplayLayout.Override.ActiveCellAppearance = Appearance35
        Appearance36.BackColor = System.Drawing.SystemColors.Highlight
        Appearance36.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.DropItem.DisplayLayout.Override.ActiveRowAppearance = Appearance36
        Me.DropItem.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.DropItem.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance37.BackColor = System.Drawing.SystemColors.Window
        Me.DropItem.DisplayLayout.Override.CardAreaAppearance = Appearance37
        Appearance38.BorderColor = System.Drawing.Color.Silver
        Appearance38.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.DropItem.DisplayLayout.Override.CellAppearance = Appearance38
        Me.DropItem.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.DropItem.DisplayLayout.Override.CellPadding = 0
        Appearance39.BackColor = System.Drawing.SystemColors.Control
        Appearance39.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance39.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance39.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance39.BorderColor = System.Drawing.SystemColors.Window
        Me.DropItem.DisplayLayout.Override.GroupByRowAppearance = Appearance39
        Appearance40.TextHAlignAsString = "Left"
        Me.DropItem.DisplayLayout.Override.HeaderAppearance = Appearance40
        Me.DropItem.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.DropItem.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance41.BackColor = System.Drawing.SystemColors.Window
        Appearance41.BorderColor = System.Drawing.Color.Silver
        Me.DropItem.DisplayLayout.Override.RowAppearance = Appearance41
        Me.DropItem.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance42.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DropItem.DisplayLayout.Override.TemplateAddRowAppearance = Appearance42
        Me.DropItem.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.DropItem.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.DropItem.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.DropItem.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.DropItem.Location = New System.Drawing.Point(73, 82)
        Me.DropItem.Name = "DropItem"
        Me.DropItem.Size = New System.Drawing.Size(488, 23)
        Me.DropItem.TabIndex = 9
        '
        'UltraLabel15
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel15.Appearance = Appearance1
        Me.UltraLabel15.AutoSize = True
        Me.UltraLabel15.ForeColor = System.Drawing.Color.Black
        Me.UltraLabel15.Location = New System.Drawing.Point(213, 56)
        Me.UltraLabel15.Name = "UltraLabel15"
        Me.UltraLabel15.Size = New System.Drawing.Size(20, 15)
        Me.UltraLabel15.TabIndex = 1
        Me.UltraLabel15.Text = "To:"
        '
        'txtDateTo
        '
        Appearance80.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance80.ForeColor = System.Drawing.Color.Black
        Me.txtDateTo.Appearance = Appearance80
        Me.txtDateTo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDateTo.DateTime = New Date(2010, 8, 8, 0, 0, 0, 0)
        Me.txtDateTo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtDateTo.ForeColor = System.Drawing.Color.Black
        Me.txtDateTo.Location = New System.Drawing.Point(253, 3)
        Me.txtDateTo.MaskInput = "{LOC}dd/mm/yyyy hh:mm"
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Size = New System.Drawing.Size(121, 22)
        Me.txtDateTo.TabIndex = 1
        Me.txtDateTo.Value = New Date(2010, 8, 8, 0, 0, 0, 0)
        '
        'UltraLabel13
        '
        Appearance43.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel13.Appearance = Appearance43
        Me.UltraLabel13.AutoSize = True
        Me.UltraLabel13.ForeColor = System.Drawing.Color.Black
        Me.UltraLabel13.Location = New System.Drawing.Point(213, 30)
        Me.UltraLabel13.Name = "UltraLabel13"
        Me.UltraLabel13.Size = New System.Drawing.Size(20, 15)
        Me.UltraLabel13.TabIndex = 1
        Me.UltraLabel13.Text = "To:"
        '
        'UltraLabel2
        '
        Appearance71.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel2.Appearance = Appearance71
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.ForeColor = System.Drawing.Color.Black
        Me.UltraLabel2.Location = New System.Drawing.Point(376, 30)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(46, 15)
        Me.UltraLabel2.TabIndex = 1
        Me.UltraLabel2.Text = "Counter:"
        '
        'UltraLabel9
        '
        Appearance29.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel9.Appearance = Appearance29
        Me.UltraLabel9.AutoSize = True
        Me.UltraLabel9.ForeColor = System.Drawing.Color.Black
        Me.UltraLabel9.Location = New System.Drawing.Point(213, 3)
        Me.UltraLabel9.Name = "UltraLabel9"
        Me.UltraLabel9.Size = New System.Drawing.Size(20, 15)
        Me.UltraLabel9.TabIndex = 1
        Me.UltraLabel9.Text = "To:"
        '
        'UltraLabel1
        '
        Appearance82.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel1.Appearance = Appearance82
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.ForeColor = System.Drawing.Color.Black
        Me.UltraLabel1.Location = New System.Drawing.Point(9, 110)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(54, 15)
        Me.UltraLabel1.TabIndex = 1
        Me.UltraLabel1.Text = "Customer:"
        '
        'txtDateFrom
        '
        Appearance81.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance81.ForeColor = System.Drawing.Color.Black
        Me.txtDateFrom.Appearance = Appearance81
        Me.txtDateFrom.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDateFrom.DateTime = New Date(2010, 8, 8, 0, 0, 0, 0)
        Me.txtDateFrom.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtDateFrom.ForeColor = System.Drawing.Color.Black
        Me.txtDateFrom.Location = New System.Drawing.Point(73, 3)
        Me.txtDateFrom.MaskInput = "{LOC}dd/mm/yyyy hh:mm"
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Size = New System.Drawing.Size(121, 22)
        Me.txtDateFrom.TabIndex = 0
        Me.txtDateFrom.Value = New Date(2010, 8, 8, 0, 0, 0, 0)
        '
        'UltraLabel16
        '
        Appearance72.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel16.Appearance = Appearance72
        Me.UltraLabel16.AutoSize = True
        Me.UltraLabel16.ForeColor = System.Drawing.Color.Black
        Me.UltraLabel16.Location = New System.Drawing.Point(376, 3)
        Me.UltraLabel16.Name = "UltraLabel16"
        Me.UltraLabel16.Size = New System.Drawing.Size(33, 15)
        Me.UltraLabel16.TabIndex = 1
        Me.UltraLabel16.Text = "User :"
        '
        'UltraLabel14
        '
        Appearance28.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel14.Appearance = Appearance28
        Me.UltraLabel14.AutoSize = True
        Me.UltraLabel14.ForeColor = System.Drawing.Color.Black
        Me.UltraLabel14.Location = New System.Drawing.Point(9, 56)
        Me.UltraLabel14.Name = "UltraLabel14"
        Me.UltraLabel14.Size = New System.Drawing.Size(62, 15)
        Me.UltraLabel14.TabIndex = 1
        Me.UltraLabel14.Text = "Bill # From:"
        '
        'UltraLabel10
        '
        Appearance44.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel10.Appearance = Appearance44
        Me.UltraLabel10.AutoSize = True
        Me.UltraLabel10.ForeColor = System.Drawing.Color.Black
        Me.UltraLabel10.Location = New System.Drawing.Point(9, 82)
        Me.UltraLabel10.Name = "UltraLabel10"
        Me.UltraLabel10.Size = New System.Drawing.Size(60, 15)
        Me.UltraLabel10.TabIndex = 1
        Me.UltraLabel10.Text = "Item in Bill:"
        '
        'UltraLabel12
        '
        Appearance45.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel12.Appearance = Appearance45
        Me.UltraLabel12.AutoSize = True
        Me.UltraLabel12.ForeColor = System.Drawing.Color.Black
        Me.UltraLabel12.Location = New System.Drawing.Point(9, 30)
        Me.UltraLabel12.Name = "UltraLabel12"
        Me.UltraLabel12.Size = New System.Drawing.Size(61, 15)
        Me.UltraLabel12.TabIndex = 1
        Me.UltraLabel12.Text = "Total From:"
        '
        'UltraLabel11
        '
        Appearance30.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel11.Appearance = Appearance30
        Me.UltraLabel11.AutoSize = True
        Me.UltraLabel11.ForeColor = System.Drawing.Color.Black
        Me.UltraLabel11.Location = New System.Drawing.Point(9, 3)
        Me.UltraLabel11.Name = "UltraLabel11"
        Me.UltraLabel11.Size = New System.Drawing.Size(55, 15)
        Me.UltraLabel11.TabIndex = 1
        Me.UltraLabel11.Text = "Date From"
        '
        'UltraTabControl1
        '
        Me.UltraTabControl1.BackColorInternal = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl2)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl3)
        Me.UltraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControl1.Location = New System.Drawing.Point(0, 185)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabControl1.Size = New System.Drawing.Size(656, 208)
        Me.UltraTabControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Office2007Ribbon
        Me.UltraTabControl1.TabIndex = 1
        Appearance3.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        UltraTab4.Appearance = Appearance3
        UltraTab4.TabPage = Me.UltraTabPageControl1
        UltraTab4.Text = "Bill List"
        Appearance4.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        UltraTab2.Appearance = Appearance4
        UltraTab2.TabPage = Me.UltraTabPageControl2
        UltraTab2.Text = "Receipt Bill"
        Appearance5.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        UltraTab3.Appearance = Appearance5
        UltraTab3.TabPage = Me.UltraTabPageControl3
        UltraTab3.Text = "Detail Bill"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab4, UltraTab2, UltraTab3})
        Me.UltraTabControl1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(654, 185)
        '
        'UltraGroupBox1
        '
        Appearance2.BackColor = System.Drawing.Color.DodgerBlue
        Me.UltraGroupBox1.Appearance = Appearance2
        Me.UltraGroupBox1.BackColorInternal = System.Drawing.Color.White
        Me.UltraGroupBox1.Controls.Add(Me.MenuStrip1)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraGroupBox1.ForeColor = System.Drawing.Color.Black
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 185)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(656, 28)
        Me.UltraGroupBox1.TabIndex = 130
        '
        'frmSailSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(656, 393)
        Me.Controls.Add(Me.UltraTabControl1)
        Me.Controls.Add(Me.UltraExpandableGroupBox1)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.DoubleBuffered = True
        Me.Name = "frmSailSearch"
        Me.Text = "Sail Search"
        Me.UltraTabPageControl1.ResumeLayout(False)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.UltraTabPageControl3.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.UltraExpandableGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraExpandableGroupBox1.ResumeLayout(False)
        Me.UltraExpandableGroupBoxPanel1.ResumeLayout(False)
        Me.UltraExpandableGroupBoxPanel1.PerformLayout()
        CType(Me.txtSerailNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPONumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DropCounter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DropCustomer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DropUser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DropItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDateTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDateFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnClearAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UltraExpandableGroupBox1 As Infragistics.Win.Misc.UltraExpandableGroupBox
    Friend WithEvents UltraExpandableGroupBoxPanel1 As Infragistics.Win.Misc.UltraExpandableGroupBoxPanel
    Friend WithEvents txtTotalTo As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents txtBillTo As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents txtBillFrom As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents txtTotalFrom As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents DropUser As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents DropItem As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraLabel15 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtDateTo As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel13 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel9 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtDateFrom As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel16 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel14 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel10 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel11 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraTabControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents grdList As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl3 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents DropCustomer As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents DropCounter As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents CRV_Receipt As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Private WithEvents CRV_DetailBill As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtSerailNum As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtPONumber As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
End Class
