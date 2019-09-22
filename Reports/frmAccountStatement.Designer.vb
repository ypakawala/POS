<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAccountStatement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAccountStatement))
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
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance71 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnClearAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.UltraExpandableGroupBox1 = New Infragistics.Win.Misc.UltraExpandableGroupBox()
        Me.UltraExpandableGroupBoxPanel1 = New Infragistics.Win.Misc.UltraExpandableGroupBoxPanel()
        Me.DropAccount = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.txtDateTo = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.UltraLabel9 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblAccount = New Infragistics.Win.Misc.UltraLabel()
        Me.txtDateFrom = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.UltraLabel11 = New Infragistics.Win.Misc.UltraLabel()
        Me.CRV = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.UltraExpandableGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraExpandableGroupBox1.SuspendLayout()
        Me.UltraExpandableGroupBoxPanel1.SuspendLayout()
        CType(Me.DropAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDateTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDateFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSearch, Me.btnClearAll, Me.btnPrint, Me.btnExit})
        Me.MenuStrip1.Location = New System.Drawing.Point(3, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(650, 24)
        Me.MenuStrip1.TabIndex = 1
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
        'btnExit
        '
        Me.btnExit.Image = Global.POS.My.Resources.Resources.CLOSE_16
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(85, 20)
        Me.btnExit.Text = "Exit [End]"
        '
        'UltraExpandableGroupBox1
        '
        Me.UltraExpandableGroupBox1.Controls.Add(Me.UltraExpandableGroupBoxPanel1)
        Me.UltraExpandableGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraExpandableGroupBox1.ExpandedSize = New System.Drawing.Size(656, 82)
        Me.UltraExpandableGroupBox1.Location = New System.Drawing.Point(0, 28)
        Me.UltraExpandableGroupBox1.Name = "UltraExpandableGroupBox1"
        Me.UltraExpandableGroupBox1.Size = New System.Drawing.Size(656, 82)
        Me.UltraExpandableGroupBox1.TabIndex = 0
        Me.UltraExpandableGroupBox1.TabStop = False
        Me.UltraExpandableGroupBox1.Text = "Criteria"
        Me.UltraExpandableGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraExpandableGroupBoxPanel1
        '
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.DropAccount)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.txtDateTo)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UltraLabel9)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.lblAccount)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.txtDateFrom)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UltraLabel11)
        Me.UltraExpandableGroupBoxPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraExpandableGroupBoxPanel1.Location = New System.Drawing.Point(3, 20)
        Me.UltraExpandableGroupBoxPanel1.Name = "UltraExpandableGroupBoxPanel1"
        Me.UltraExpandableGroupBoxPanel1.Size = New System.Drawing.Size(650, 59)
        Me.UltraExpandableGroupBoxPanel1.TabIndex = 0
        '
        'DropAccount
        '
        Me.DropAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance46.BackColor = System.Drawing.SystemColors.Window
        Appearance46.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.DropAccount.DisplayLayout.Appearance = Appearance46
        Me.DropAccount.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.DropAccount.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance47.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance47.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance47.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance47.BorderColor = System.Drawing.SystemColors.Window
        Me.DropAccount.DisplayLayout.GroupByBox.Appearance = Appearance47
        Appearance48.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropAccount.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance48
        Me.DropAccount.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance49.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance49.BackColor2 = System.Drawing.SystemColors.Control
        Appearance49.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance49.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropAccount.DisplayLayout.GroupByBox.PromptAppearance = Appearance49
        Me.DropAccount.DisplayLayout.MaxColScrollRegions = 1
        Me.DropAccount.DisplayLayout.MaxRowScrollRegions = 1
        Appearance50.BackColor = System.Drawing.SystemColors.Window
        Appearance50.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DropAccount.DisplayLayout.Override.ActiveCellAppearance = Appearance50
        Appearance51.BackColor = System.Drawing.SystemColors.Highlight
        Appearance51.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.DropAccount.DisplayLayout.Override.ActiveRowAppearance = Appearance51
        Me.DropAccount.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.DropAccount.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance52.BackColor = System.Drawing.SystemColors.Window
        Me.DropAccount.DisplayLayout.Override.CardAreaAppearance = Appearance52
        Appearance53.BorderColor = System.Drawing.Color.Silver
        Appearance53.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.DropAccount.DisplayLayout.Override.CellAppearance = Appearance53
        Me.DropAccount.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.DropAccount.DisplayLayout.Override.CellPadding = 0
        Appearance54.BackColor = System.Drawing.SystemColors.Control
        Appearance54.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance54.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance54.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance54.BorderColor = System.Drawing.SystemColors.Window
        Me.DropAccount.DisplayLayout.Override.GroupByRowAppearance = Appearance54
        Appearance55.TextHAlignAsString = "Left"
        Me.DropAccount.DisplayLayout.Override.HeaderAppearance = Appearance55
        Me.DropAccount.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.DropAccount.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance56.BackColor = System.Drawing.SystemColors.Window
        Appearance56.BorderColor = System.Drawing.Color.Silver
        Me.DropAccount.DisplayLayout.Override.RowAppearance = Appearance56
        Me.DropAccount.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance57.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DropAccount.DisplayLayout.Override.TemplateAddRowAppearance = Appearance57
        Me.DropAccount.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.DropAccount.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.DropAccount.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.DropAccount.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.DropAccount.Location = New System.Drawing.Point(115, 27)
        Me.DropAccount.Name = "DropAccount"
        Me.DropAccount.Size = New System.Drawing.Size(301, 23)
        Me.DropAccount.TabIndex = 2
        '
        'txtDateTo
        '
        Me.txtDateTo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtDateTo.Location = New System.Drawing.Point(295, 0)
        Me.txtDateTo.MaskInput = "{LOC}dd/mm/yyyy hh:mm"
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Size = New System.Drawing.Size(121, 22)
        Me.txtDateTo.TabIndex = 1
        '
        'UltraLabel9
        '
        Appearance29.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel9.Appearance = Appearance29
        Me.UltraLabel9.AutoSize = True
        Me.UltraLabel9.Location = New System.Drawing.Point(255, 0)
        Me.UltraLabel9.Name = "UltraLabel9"
        Me.UltraLabel9.Size = New System.Drawing.Size(20, 15)
        Me.UltraLabel9.TabIndex = 1
        Me.UltraLabel9.Text = "To:"
        '
        'lblAccount
        '
        Appearance71.BackColor = System.Drawing.Color.Transparent
        Me.lblAccount.Appearance = Appearance71
        Me.lblAccount.AutoSize = True
        Me.lblAccount.Location = New System.Drawing.Point(9, 30)
        Me.lblAccount.Name = "lblAccount"
        Me.lblAccount.Size = New System.Drawing.Size(54, 15)
        Me.lblAccount.TabIndex = 1
        Me.lblAccount.Text = "Customer:"
        '
        'txtDateFrom
        '
        Me.txtDateFrom.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtDateFrom.Location = New System.Drawing.Point(115, 0)
        Me.txtDateFrom.MaskInput = "{LOC}dd/mm/yyyy hh:mm"
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Size = New System.Drawing.Size(121, 22)
        Me.txtDateFrom.TabIndex = 0
        '
        'UltraLabel11
        '
        Appearance30.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel11.Appearance = Appearance30
        Me.UltraLabel11.AutoSize = True
        Me.UltraLabel11.Location = New System.Drawing.Point(9, 3)
        Me.UltraLabel11.Name = "UltraLabel11"
        Me.UltraLabel11.Size = New System.Drawing.Size(55, 15)
        Me.UltraLabel11.TabIndex = 1
        Me.UltraLabel11.Text = "Date From"
        '
        'CRV
        '
        Me.CRV.ActiveViewIndex = -1
        Me.CRV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRV.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRV.Location = New System.Drawing.Point(0, 110)
        Me.CRV.Name = "CRV"
        Me.CRV.SelectionFormula = ""
        Me.CRV.ShowPrintButton = False
        Me.CRV.Size = New System.Drawing.Size(656, 283)
        Me.CRV.TabIndex = 3
        Me.CRV.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.CRV.ViewTimeSelectionFormula = ""
        '
        'UltraGroupBox1
        '
        Appearance2.BackColor = System.Drawing.Color.DodgerBlue
        Me.UltraGroupBox1.Appearance = Appearance2
        Me.UltraGroupBox1.BackColorInternal = System.Drawing.Color.White
        Me.UltraGroupBox1.Controls.Add(Me.MenuStrip1)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraGroupBox1.ForeColor = System.Drawing.Color.Black
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(656, 28)
        Me.UltraGroupBox1.TabIndex = 130
        '
        'btnPrint
        '
        Me.btnPrint.Image = Global.POS.My.Resources.Resources.PRINT_16
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.btnPrint.Size = New System.Drawing.Size(83, 20)
        Me.btnPrint.Text = "Print [F3]"
        '
        'frmAccountStatement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(656, 393)
        Me.Controls.Add(Me.CRV)
        Me.Controls.Add(Me.UltraExpandableGroupBox1)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.DoubleBuffered = True
        Me.Name = "frmAccountStatement"
        Me.Text = "Sales Discount"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.UltraExpandableGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraExpandableGroupBox1.ResumeLayout(False)
        Me.UltraExpandableGroupBoxPanel1.ResumeLayout(False)
        Me.UltraExpandableGroupBoxPanel1.PerformLayout()
        CType(Me.DropAccount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDateTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDateFrom, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents txtDateTo As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel9 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtDateFrom As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel11 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents DropAccount As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents lblAccount As Infragistics.Win.Misc.UltraLabel
    Private WithEvents CRV As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents btnPrint As ToolStripMenuItem
End Class
