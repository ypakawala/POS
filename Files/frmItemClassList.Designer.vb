<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmItemClassList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmItemClassList))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance61 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnShowItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnColumnChooser = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBarcode = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.UltraGridColumnChooser1 = New Infragistics.Win.UltraWinGrid.UltraGridColumnChooser()
        Me.grdList = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraCalcManager1 = New Infragistics.Win.UltraWinCalcManager.UltraCalcManager(Me.components)
        Me.txtSearch = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Barcode1 = New C1.Win.C1BarCode.C1BarCode()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.DropSubCategory = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.DropCategory = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.UltraGridColumnChooser1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraCalcManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DropSubCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DropCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.ForeColor = System.Drawing.Color.Black
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnShowItem, Me.btnDelete, Me.btnPrint, Me.btnColumnChooser, Me.btnEdit, Me.btnExcel, Me.btnBarcode, Me.btnExit})
        Me.MenuStrip1.Location = New System.Drawing.Point(3, 1)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(728, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'btnNew
        '
        Me.btnNew.Image = Global.POS.My.Resources.Resources.ADD_16
        Me.btnNew.Name = "btnNew"
        Me.btnNew.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.btnNew.Size = New System.Drawing.Size(82, 20)
        Me.btnNew.Text = "New [F1]"
        '
        'btnShowItem
        '
        Me.btnShowItem.Image = CType(resources.GetObject("btnShowItem.Image"), System.Drawing.Image)
        Me.btnShowItem.Name = "btnShowItem"
        Me.btnShowItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.btnShowItem.Size = New System.Drawing.Size(114, 20)
        Me.btnShowItem.Text = "Show Item [F2]"
        '
        'btnDelete
        '
        Me.btnDelete.Image = Global.POS.My.Resources.Resources.DELETE_16
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.btnDelete.Size = New System.Drawing.Size(91, 20)
        Me.btnDelete.Text = "Delete [F3]"
        '
        'btnPrint
        '
        Me.btnPrint.Image = Global.POS.My.Resources.Resources.PRINT_16
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.btnPrint.Size = New System.Drawing.Size(83, 20)
        Me.btnPrint.Text = "Print [F4]"
        '
        'btnColumnChooser
        '
        Me.btnColumnChooser.Image = CType(resources.GetObject("btnColumnChooser.Image"), System.Drawing.Image)
        Me.btnColumnChooser.Name = "btnColumnChooser"
        Me.btnColumnChooser.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.btnColumnChooser.Size = New System.Drawing.Size(104, 20)
        Me.btnColumnChooser.Text = "Column  [F5]"
        '
        'btnEdit
        '
        Me.btnEdit.Image = Global.POS.My.Resources.Resources.EDIT_16
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.btnEdit.Size = New System.Drawing.Size(78, 20)
        Me.btnEdit.Text = "Edit [F6]"
        Me.btnEdit.Visible = False
        '
        'btnExcel
        '
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.ShortcutKeys = System.Windows.Forms.Keys.F7
        Me.btnExcel.Size = New System.Drawing.Size(61, 20)
        Me.btnExcel.Text = "Excel"
        '
        'btnBarcode
        '
        Me.btnBarcode.Image = CType(resources.GetObject("btnBarcode.Image"), System.Drawing.Image)
        Me.btnBarcode.Name = "btnBarcode"
        Me.btnBarcode.ShortcutKeys = System.Windows.Forms.Keys.F7
        Me.btnBarcode.Size = New System.Drawing.Size(101, 20)
        Me.btnBarcode.Text = "Barcode [F7]"
        '
        'btnExit
        '
        Me.btnExit.Image = Global.POS.My.Resources.Resources.CLOSE_16
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(84, 20)
        Me.btnExit.Text = "Exit [End]"
        '
        'UltraGridColumnChooser1
        '
        Me.UltraGridColumnChooser1.BackColor = System.Drawing.Color.White
        Appearance1.BackColor = System.Drawing.Color.White
        Me.UltraGridColumnChooser1.DisplayLayout.Appearance = Appearance1
        Me.UltraGridColumnChooser1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.UltraGridColumnChooser1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.UltraGridColumnChooser1.DisplayLayout.MaxColScrollRegions = 1
        Me.UltraGridColumnChooser1.DisplayLayout.MaxRowScrollRegions = 1
        Me.UltraGridColumnChooser1.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.UltraGridColumnChooser1.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None
        Me.UltraGridColumnChooser1.DisplayLayout.Override.AllowRowLayoutCellSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None
        Me.UltraGridColumnChooser1.DisplayLayout.Override.AllowRowLayoutLabelSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None
        Me.UltraGridColumnChooser1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.UltraGridColumnChooser1.DisplayLayout.Override.CellPadding = 2
        Me.UltraGridColumnChooser1.DisplayLayout.Override.ExpansionIndicator = Infragistics.Win.UltraWinGrid.ShowExpansionIndicator.Never
        Me.UltraGridColumnChooser1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.[Select]
        Me.UltraGridColumnChooser1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.UltraGridColumnChooser1.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed
        Me.UltraGridColumnChooser1.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.UltraGridColumnChooser1.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.UltraGridColumnChooser1.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.UltraGridColumnChooser1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None
        Me.UltraGridColumnChooser1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.UltraGridColumnChooser1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.UltraGridColumnChooser1.Dock = System.Windows.Forms.DockStyle.Left
        Me.UltraGridColumnChooser1.ForeColor = System.Drawing.Color.Black
        Me.UltraGridColumnChooser1.Location = New System.Drawing.Point(0, 28)
        Me.UltraGridColumnChooser1.Name = "UltraGridColumnChooser1"
        Me.UltraGridColumnChooser1.Size = New System.Drawing.Size(140, 245)
        Me.UltraGridColumnChooser1.SourceGrid = Me.grdList
        Me.UltraGridColumnChooser1.StyleLibraryName = ""
        Me.UltraGridColumnChooser1.StyleSetName = ""
        Me.UltraGridColumnChooser1.TabIndex = 3
        Me.UltraGridColumnChooser1.Text = "UltraGridColumnChooser1"
        Me.UltraGridColumnChooser1.Visible = False
        '
        'grdList
        '
        Me.grdList.CalcManager = Me.UltraCalcManager1
        Appearance3.BackColor = System.Drawing.Color.White
        Me.grdList.DisplayLayout.Appearance = Appearance3
        UltraGridBand1.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdList.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.grdList.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.grdList.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdList.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[True]
        Me.grdList.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Me.grdList.DisplayLayout.Override.CardAreaAppearance = Appearance4
        Me.grdList.DisplayLayout.Override.CellPadding = 3
        Me.grdList.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance5.TextHAlignAsString = "Left"
        Me.grdList.DisplayLayout.Override.HeaderAppearance = Appearance5
        Appearance6.BorderColor = System.Drawing.Color.LightGray
        Appearance6.TextVAlignAsString = "Middle"
        Me.grdList.DisplayLayout.Override.RowAppearance = Appearance6
        Appearance7.BackColor = System.Drawing.Color.LightSteelBlue
        Appearance7.BorderColor = System.Drawing.Color.Black
        Appearance7.ForeColor = System.Drawing.Color.Black
        Me.grdList.DisplayLayout.Override.SelectedRowAppearance = Appearance7
        Me.grdList.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.TopFixed
        Me.grdList.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None
        Me.grdList.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdList.Location = New System.Drawing.Point(140, 28)
        Me.grdList.Name = "grdList"
        Me.grdList.Size = New System.Drawing.Size(844, 245)
        Me.grdList.TabIndex = 2
        '
        'UltraCalcManager1
        '
        Me.UltraCalcManager1.ContainingControl = Me
        '
        'txtSearch
        '
        Appearance14.BackColor = System.Drawing.Color.White
        Appearance14.ForeColor = System.Drawing.Color.Black
        Appearance14.ImageAlpha = Infragistics.Win.Alpha.Opaque
        Appearance14.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.txtSearch.Appearance = Appearance14
        Me.txtSearch.BackColor = System.Drawing.Color.White
        Me.txtSearch.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.txtSearch.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtSearch.ForeColor = System.Drawing.Color.Black
        Me.txtSearch.Location = New System.Drawing.Point(751, 4)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(143, 20)
        Me.txtSearch.TabIndex = 0
        '
        'Barcode1
        '
        Me.Barcode1.CodeType = C1.Win.C1BarCode.CodeTypeEnum.Code128
        Me.Barcode1.Location = New System.Drawing.Point(361, 116)
        Me.Barcode1.Margin = New System.Windows.Forms.Padding(0)
        Me.Barcode1.Name = "Barcode1"
        Me.Barcode1.ShowText = True
        Me.Barcode1.Size = New System.Drawing.Size(68, 40)
        Me.Barcode1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Barcode1.TabIndex = 11
        Me.Barcode1.TabStop = False
        Me.Barcode1.Text = "1234567890123"
        '
        'DropSubCategory
        '
        Me.DropSubCategory.CalcManager = Me.UltraCalcManager1
        Me.DropSubCategory.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance41.BackColor = System.Drawing.SystemColors.Window
        Appearance41.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.DropSubCategory.DisplayLayout.Appearance = Appearance41
        Me.DropSubCategory.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.DropSubCategory.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance37.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance37.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance37.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance37.BorderColor = System.Drawing.SystemColors.Window
        Me.DropSubCategory.DisplayLayout.GroupByBox.Appearance = Appearance37
        Appearance39.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropSubCategory.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance39
        Me.DropSubCategory.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance40.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance40.BackColor2 = System.Drawing.SystemColors.Control
        Appearance40.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance40.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropSubCategory.DisplayLayout.GroupByBox.PromptAppearance = Appearance40
        Me.DropSubCategory.DisplayLayout.MaxColScrollRegions = 1
        Me.DropSubCategory.DisplayLayout.MaxRowScrollRegions = 1
        Appearance49.BackColor = System.Drawing.SystemColors.Window
        Appearance49.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DropSubCategory.DisplayLayout.Override.ActiveCellAppearance = Appearance49
        Appearance44.BackColor = System.Drawing.SystemColors.Highlight
        Appearance44.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.DropSubCategory.DisplayLayout.Override.ActiveRowAppearance = Appearance44
        Me.DropSubCategory.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.DropSubCategory.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance43.BackColor = System.Drawing.SystemColors.Window
        Me.DropSubCategory.DisplayLayout.Override.CardAreaAppearance = Appearance43
        Appearance42.BorderColor = System.Drawing.Color.Silver
        Appearance42.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.DropSubCategory.DisplayLayout.Override.CellAppearance = Appearance42
        Me.DropSubCategory.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.DropSubCategory.DisplayLayout.Override.CellPadding = 0
        Appearance46.BackColor = System.Drawing.SystemColors.Control
        Appearance46.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance46.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance46.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance46.BorderColor = System.Drawing.SystemColors.Window
        Me.DropSubCategory.DisplayLayout.Override.GroupByRowAppearance = Appearance46
        Appearance48.TextHAlignAsString = "Left"
        Me.DropSubCategory.DisplayLayout.Override.HeaderAppearance = Appearance48
        Me.DropSubCategory.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.DropSubCategory.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance47.BackColor = System.Drawing.SystemColors.Window
        Appearance47.BorderColor = System.Drawing.Color.Silver
        Me.DropSubCategory.DisplayLayout.Override.RowAppearance = Appearance47
        Me.DropSubCategory.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance45.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DropSubCategory.DisplayLayout.Override.TemplateAddRowAppearance = Appearance45
        Me.DropSubCategory.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.DropSubCategory.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.DropSubCategory.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.DropSubCategory.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.DropSubCategory.Location = New System.Drawing.Point(413, 111)
        Me.DropSubCategory.Name = "DropSubCategory"
        Me.DropSubCategory.Size = New System.Drawing.Size(158, 23)
        Me.DropSubCategory.TabIndex = 12
        Me.DropSubCategory.Visible = False
        '
        'DropCategory
        '
        Me.DropCategory.CalcManager = Me.UltraCalcManager1
        Me.DropCategory.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance50.BackColor = System.Drawing.SystemColors.Window
        Appearance50.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.DropCategory.DisplayLayout.Appearance = Appearance50
        Me.DropCategory.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.DropCategory.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance51.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance51.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance51.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance51.BorderColor = System.Drawing.SystemColors.Window
        Me.DropCategory.DisplayLayout.GroupByBox.Appearance = Appearance51
        Appearance52.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropCategory.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance52
        Me.DropCategory.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance53.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance53.BackColor2 = System.Drawing.SystemColors.Control
        Appearance53.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance53.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropCategory.DisplayLayout.GroupByBox.PromptAppearance = Appearance53
        Me.DropCategory.DisplayLayout.MaxColScrollRegions = 1
        Me.DropCategory.DisplayLayout.MaxRowScrollRegions = 1
        Appearance54.BackColor = System.Drawing.SystemColors.Window
        Appearance54.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DropCategory.DisplayLayout.Override.ActiveCellAppearance = Appearance54
        Appearance55.BackColor = System.Drawing.SystemColors.Highlight
        Appearance55.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.DropCategory.DisplayLayout.Override.ActiveRowAppearance = Appearance55
        Me.DropCategory.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.DropCategory.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance56.BackColor = System.Drawing.SystemColors.Window
        Me.DropCategory.DisplayLayout.Override.CardAreaAppearance = Appearance56
        Appearance57.BorderColor = System.Drawing.Color.Silver
        Appearance57.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.DropCategory.DisplayLayout.Override.CellAppearance = Appearance57
        Me.DropCategory.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.DropCategory.DisplayLayout.Override.CellPadding = 0
        Appearance58.BackColor = System.Drawing.SystemColors.Control
        Appearance58.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance58.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance58.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance58.BorderColor = System.Drawing.SystemColors.Window
        Me.DropCategory.DisplayLayout.Override.GroupByRowAppearance = Appearance58
        Appearance59.TextHAlignAsString = "Left"
        Me.DropCategory.DisplayLayout.Override.HeaderAppearance = Appearance59
        Me.DropCategory.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.DropCategory.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance60.BackColor = System.Drawing.SystemColors.Window
        Appearance60.BorderColor = System.Drawing.Color.Silver
        Me.DropCategory.DisplayLayout.Override.RowAppearance = Appearance60
        Me.DropCategory.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance61.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DropCategory.DisplayLayout.Override.TemplateAddRowAppearance = Appearance61
        Me.DropCategory.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.DropCategory.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.DropCategory.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.DropCategory.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.DropCategory.Location = New System.Drawing.Point(413, 139)
        Me.DropCategory.Name = "DropCategory"
        Me.DropCategory.Size = New System.Drawing.Size(158, 23)
        Me.DropCategory.TabIndex = 13
        Me.DropCategory.Visible = False
        '
        'UltraGroupBox1
        '
        Appearance2.BackColor = System.Drawing.Color.DodgerBlue
        Me.UltraGroupBox1.Appearance = Appearance2
        Me.UltraGroupBox1.BackColorInternal = System.Drawing.Color.White
        Me.UltraGroupBox1.Controls.Add(Me.MenuStrip1)
        Me.UltraGroupBox1.Controls.Add(Me.txtSearch)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraGroupBox1.ForeColor = System.Drawing.Color.Black
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(984, 28)
        Me.UltraGroupBox1.TabIndex = 130
        '
        'frmItemClassList
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(984, 273)
        Me.Controls.Add(Me.DropSubCategory)
        Me.Controls.Add(Me.DropCategory)
        Me.Controls.Add(Me.grdList)
        Me.Controls.Add(Me.UltraGridColumnChooser1)
        Me.Controls.Add(Me.Barcode1)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.DoubleBuffered = True
        Me.Name = "frmItemClassList"
        Me.Text = "Item List"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.UltraGridColumnChooser1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraCalcManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSearch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DropSubCategory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DropCategory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnShowItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UltraGridColumnChooser1 As Infragistics.Win.UltraWinGrid.UltraGridColumnChooser
    Friend WithEvents grdList As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnBarcode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtSearch As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnColumnChooser As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Barcode1 As C1.Win.C1BarCode.C1BarCode
    Friend WithEvents UltraCalcManager1 As Infragistics.Win.UltraWinCalcManager.UltraCalcManager
    Friend WithEvents btnEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents DropSubCategory As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents DropCategory As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
End Class
