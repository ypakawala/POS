<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuotationList
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQuotationList))
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnClosedQuote = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnOpenQuote = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAllQuote = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.gbxSalesDetail = New Infragistics.Win.Misc.UltraGroupBox()
        Me.grdList = New Infragistics.Win.UltraWinGrid.UltraGrid()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.gbxSalesDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxSalesDetail.SuspendLayout()
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Appearance1.BackColor = System.Drawing.Color.DodgerBlue
        Me.UltraGroupBox1.Appearance = Appearance1
        Me.UltraGroupBox1.BackColorInternal = System.Drawing.Color.White
        Me.UltraGroupBox1.Controls.Add(Me.MenuStrip1)
        Me.UltraGroupBox1.Controls.Add(Me.Label6)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraGroupBox1.ForeColor = System.Drawing.Color.Black
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(1088, 38)
        Me.UltraGroupBox1.TabIndex = 124
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip1.GripMargin = New System.Windows.Forms.Padding(2)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnEdit, Me.btnClosedQuote, Me.btnOpenQuote, Me.btnAllQuote, Me.btnPrint, Me.btnExport, Me.btnExit})
        Me.MenuStrip1.Location = New System.Drawing.Point(3, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(776, 35)
        Me.MenuStrip1.TabIndex = 100
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'btnNew
        '
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Padding = New System.Windows.Forms.Padding(1)
        Me.btnNew.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.btnNew.Size = New System.Drawing.Size(88, 31)
        Me.btnNew.Text = "NEW - F2"
        '
        'btnEdit
        '
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Padding = New System.Windows.Forms.Padding(1)
        Me.btnEdit.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.btnEdit.Size = New System.Drawing.Size(82, 31)
        Me.btnEdit.Text = "Edit - F3"
        '
        'btnClosedQuote
        '
        Me.btnClosedQuote.Image = CType(resources.GetObject("btnClosedQuote.Image"), System.Drawing.Image)
        Me.btnClosedQuote.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnClosedQuote.Name = "btnClosedQuote"
        Me.btnClosedQuote.Padding = New System.Windows.Forms.Padding(1)
        Me.btnClosedQuote.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.btnClosedQuote.Size = New System.Drawing.Size(98, 31)
        Me.btnClosedQuote.Text = "Closed - F4"
        '
        'btnOpenQuote
        '
        Me.btnOpenQuote.Image = CType(resources.GetObject("btnOpenQuote.Image"), System.Drawing.Image)
        Me.btnOpenQuote.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnOpenQuote.Name = "btnOpenQuote"
        Me.btnOpenQuote.Padding = New System.Windows.Forms.Padding(1)
        Me.btnOpenQuote.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.btnOpenQuote.Size = New System.Drawing.Size(91, 31)
        Me.btnOpenQuote.Text = "Open - F5"
        '
        'btnAllQuote
        '
        Me.btnAllQuote.Image = CType(resources.GetObject("btnAllQuote.Image"), System.Drawing.Image)
        Me.btnAllQuote.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnAllQuote.Name = "btnAllQuote"
        Me.btnAllQuote.Padding = New System.Windows.Forms.Padding(1)
        Me.btnAllQuote.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.btnAllQuote.Size = New System.Drawing.Size(76, 31)
        Me.btnAllQuote.Text = "All - F6"
        '
        'btnPrint
        '
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Padding = New System.Windows.Forms.Padding(1)
        Me.btnPrint.ShortcutKeys = System.Windows.Forms.Keys.F7
        Me.btnPrint.Size = New System.Drawing.Size(87, 31)
        Me.btnPrint.Text = "Print - F7"
        '
        'btnExport
        '
        Me.btnExport.Image = CType(resources.GetObject("btnExport.Image"), System.Drawing.Image)
        Me.btnExport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Padding = New System.Windows.Forms.Padding(1)
        Me.btnExport.ShortcutKeys = System.Windows.Forms.Keys.F8
        Me.btnExport.Size = New System.Drawing.Size(95, 31)
        Me.btnExport.Text = "Export - F8"
        '
        'btnExit
        '
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Padding = New System.Windows.Forms.Padding(1)
        Me.btnExit.ShortcutKeys = System.Windows.Forms.Keys.F12
        Me.btnExit.Size = New System.Drawing.Size(86, 31)
        Me.btnExit.Text = "Exit - F12"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(779, 0)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(306, 35)
        Me.Label6.TabIndex = 99
        Me.Label6.Text = "Quotation List"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gbxSalesDetail
        '
        Me.gbxSalesDetail.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center
        Me.gbxSalesDetail.Controls.Add(Me.grdList)
        Me.gbxSalesDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbxSalesDetail.Location = New System.Drawing.Point(0, 38)
        Me.gbxSalesDetail.Name = "gbxSalesDetail"
        Me.gbxSalesDetail.Size = New System.Drawing.Size(1088, 365)
        Me.gbxSalesDetail.TabIndex = 125
        Me.gbxSalesDetail.Text = "Quotation List"
        Me.gbxSalesDetail.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'grdList
        '
        Appearance2.BackColor = System.Drawing.SystemColors.Window
        Appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdList.DisplayLayout.Appearance = Appearance2
        Me.grdList.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdList.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.BorderColor = System.Drawing.SystemColors.Window
        Me.grdList.DisplayLayout.GroupByBox.Appearance = Appearance3
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdList.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance4
        Me.grdList.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance5.BackColor2 = System.Drawing.SystemColors.Control
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdList.DisplayLayout.GroupByBox.PromptAppearance = Appearance5
        Me.grdList.DisplayLayout.MaxColScrollRegions = 1
        Me.grdList.DisplayLayout.MaxRowScrollRegions = 1
        Appearance6.BackColor = System.Drawing.SystemColors.Window
        Appearance6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdList.DisplayLayout.Override.ActiveCellAppearance = Appearance6
        Appearance7.BackColor = System.Drawing.SystemColors.Highlight
        Appearance7.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdList.DisplayLayout.Override.ActiveRowAppearance = Appearance7
        Me.grdList.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdList.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdList.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Me.grdList.DisplayLayout.Override.CardAreaAppearance = Appearance8
        Appearance9.BorderColor = System.Drawing.Color.Silver
        Appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdList.DisplayLayout.Override.CellAppearance = Appearance9
        Me.grdList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdList.DisplayLayout.Override.CellPadding = 0
        Me.grdList.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance10.BackColor = System.Drawing.SystemColors.Control
        Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance10.BorderColor = System.Drawing.SystemColors.Window
        Me.grdList.DisplayLayout.Override.GroupByRowAppearance = Appearance10
        Appearance11.TextHAlignAsString = "Left"
        Me.grdList.DisplayLayout.Override.HeaderAppearance = Appearance11
        Me.grdList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdList.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.BorderColor = System.Drawing.Color.Silver
        Me.grdList.DisplayLayout.Override.RowAppearance = Appearance12
        Me.grdList.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Appearance13.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdList.DisplayLayout.Override.TemplateAddRowAppearance = Appearance13
        Me.grdList.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdList.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdList.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdList.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.grdList.Location = New System.Drawing.Point(3, 17)
        Me.grdList.Name = "grdList"
        Me.grdList.Size = New System.Drawing.Size(1082, 345)
        Me.grdList.TabIndex = 111
        Me.grdList.Text = "UltraGrid7"
        '
        'frmQuotationList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1088, 403)
        Me.Controls.Add(Me.gbxSalesDetail)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.DoubleBuffered = True
        Me.Name = "frmQuotationList"
        Me.Text = "Quotation List"
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.gbxSalesDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxSalesDetail.ResumeLayout(False)
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Private WithEvents gbxSalesDetail As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents grdList As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnClosedQuote As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnOpenQuote As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnAllQuote As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnExport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripMenuItem
End Class
