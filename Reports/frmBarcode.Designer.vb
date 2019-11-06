<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBarcode
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBarcode))
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance92 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance79 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnClearAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBarcode2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.UltraExpandableGroupBox1 = New Infragistics.Win.Misc.UltraExpandableGroupBox()
        Me.UltraExpandableGroupBoxPanel1 = New Infragistics.Win.Misc.UltraExpandableGroupBoxPanel()
        Me.DropItem = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.UltraLabel14 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtExpiryDate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.txtNoOfCopy = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel18 = New Infragistics.Win.Misc.UltraLabel()
        Me.CRV = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Barcode1 = New C1.Win.C1BarCode.C1BarCode()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.txtEncodedText = New System.Windows.Forms.TextBox()
        Me.txtDataToEncode = New System.Windows.Forms.TextBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.UltraExpandableGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraExpandableGroupBox1.SuspendLayout()
        Me.UltraExpandableGroupBoxPanel1.SuspendLayout()
        CType(Me.DropItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtExpiryDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSearch, Me.btnClearAll, Me.btnBarcode2, Me.btnExit})
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
        'btnBarcode2
        '
        Me.btnBarcode2.Image = CType(resources.GetObject("btnBarcode2.Image"), System.Drawing.Image)
        Me.btnBarcode2.Name = "btnBarcode2"
        Me.btnBarcode2.Size = New System.Drawing.Size(87, 20)
        Me.btnBarcode2.Text = "Barcode 2"
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
        Me.UltraExpandableGroupBox1.ExpandedSize = New System.Drawing.Size(656, 88)
        Me.UltraExpandableGroupBox1.Location = New System.Drawing.Point(0, 28)
        Me.UltraExpandableGroupBox1.Name = "UltraExpandableGroupBox1"
        Me.UltraExpandableGroupBox1.Size = New System.Drawing.Size(656, 88)
        Me.UltraExpandableGroupBox1.TabIndex = 0
        Me.UltraExpandableGroupBox1.TabStop = False
        Me.UltraExpandableGroupBox1.Text = "Criteria"
        Me.UltraExpandableGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraExpandableGroupBoxPanel1
        '
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.txtDataToEncode)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.txtEncodedText)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.DropItem)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UltraLabel14)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.txtExpiryDate)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.txtNoOfCopy)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UltraLabel5)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UltraLabel18)
        Me.UltraExpandableGroupBoxPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraExpandableGroupBoxPanel1.Location = New System.Drawing.Point(3, 20)
        Me.UltraExpandableGroupBoxPanel1.Name = "UltraExpandableGroupBoxPanel1"
        Me.UltraExpandableGroupBoxPanel1.Size = New System.Drawing.Size(650, 65)
        Me.UltraExpandableGroupBoxPanel1.TabIndex = 0
        '
        'DropItem
        '
        Me.DropItem.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance25.BackColor = System.Drawing.SystemColors.Window
        Appearance25.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.DropItem.DisplayLayout.Appearance = Appearance25
        Me.DropItem.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.DropItem.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance26.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance26.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance26.BorderColor = System.Drawing.SystemColors.Window
        Me.DropItem.DisplayLayout.GroupByBox.Appearance = Appearance26
        Appearance27.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropItem.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance27
        Me.DropItem.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance28.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance28.BackColor2 = System.Drawing.SystemColors.Control
        Appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance28.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropItem.DisplayLayout.GroupByBox.PromptAppearance = Appearance28
        Me.DropItem.DisplayLayout.MaxColScrollRegions = 1
        Me.DropItem.DisplayLayout.MaxRowScrollRegions = 1
        Appearance29.BackColor = System.Drawing.SystemColors.Window
        Appearance29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DropItem.DisplayLayout.Override.ActiveCellAppearance = Appearance29
        Appearance30.BackColor = System.Drawing.SystemColors.Highlight
        Appearance30.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.DropItem.DisplayLayout.Override.ActiveRowAppearance = Appearance30
        Me.DropItem.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.DropItem.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance31.BackColor = System.Drawing.SystemColors.Window
        Me.DropItem.DisplayLayout.Override.CardAreaAppearance = Appearance31
        Appearance32.BorderColor = System.Drawing.Color.Silver
        Appearance32.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.DropItem.DisplayLayout.Override.CellAppearance = Appearance32
        Me.DropItem.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.DropItem.DisplayLayout.Override.CellPadding = 0
        Appearance33.BackColor = System.Drawing.SystemColors.Control
        Appearance33.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance33.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance33.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance33.BorderColor = System.Drawing.SystemColors.Window
        Me.DropItem.DisplayLayout.Override.GroupByRowAppearance = Appearance33
        Appearance34.TextHAlignAsString = "Left"
        Me.DropItem.DisplayLayout.Override.HeaderAppearance = Appearance34
        Me.DropItem.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.DropItem.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance35.BackColor = System.Drawing.SystemColors.Window
        Appearance35.BorderColor = System.Drawing.Color.Silver
        Me.DropItem.DisplayLayout.Override.RowAppearance = Appearance35
        Me.DropItem.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance36.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DropItem.DisplayLayout.Override.TemplateAddRowAppearance = Appearance36
        Me.DropItem.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.DropItem.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.DropItem.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.DropItem.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.DropItem.Location = New System.Drawing.Point(85, 2)
        Me.DropItem.Name = "DropItem"
        Me.DropItem.Size = New System.Drawing.Size(517, 23)
        Me.DropItem.TabIndex = 0
        '
        'UltraLabel14
        '
        Appearance50.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel14.Appearance = Appearance50
        Me.UltraLabel14.AutoSize = True
        Me.UltraLabel14.Location = New System.Drawing.Point(4, 4)
        Me.UltraLabel14.Margin = New System.Windows.Forms.Padding(4)
        Me.UltraLabel14.Name = "UltraLabel14"
        Me.UltraLabel14.Size = New System.Drawing.Size(66, 15)
        Me.UltraLabel14.TabIndex = 23
        Me.UltraLabel14.Text = "Item Name :"
        '
        'txtExpiryDate
        '
        Me.txtExpiryDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtExpiryDate.Location = New System.Drawing.Point(204, 33)
        Me.txtExpiryDate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtExpiryDate.MaskInput = "{LOC}dd/mm/yyyy"
        Me.txtExpiryDate.Name = "txtExpiryDate"
        Me.txtExpiryDate.Size = New System.Drawing.Size(96, 22)
        Me.txtExpiryDate.TabIndex = 2
        '
        'txtNoOfCopy
        '
        Me.txtNoOfCopy.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtNoOfCopy.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.[Integer]
        Me.txtNoOfCopy.InputMask = "{LOC}nnn"
        Me.txtNoOfCopy.Location = New System.Drawing.Point(85, 34)
        Me.txtNoOfCopy.Name = "txtNoOfCopy"
        Me.txtNoOfCopy.Size = New System.Drawing.Size(37, 20)
        Me.txtNoOfCopy.TabIndex = 1
        '
        'UltraLabel5
        '
        Appearance92.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel5.Appearance = Appearance92
        Me.UltraLabel5.AutoSize = True
        Me.UltraLabel5.Location = New System.Drawing.Point(10, 37)
        Me.UltraLabel5.Margin = New System.Windows.Forms.Padding(4)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(60, 15)
        Me.UltraLabel5.TabIndex = 21
        Me.UltraLabel5.Text = "# of Copy :"
        '
        'UltraLabel18
        '
        Appearance79.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel18.Appearance = Appearance79
        Me.UltraLabel18.AutoSize = True
        Me.UltraLabel18.Location = New System.Drawing.Point(129, 37)
        Me.UltraLabel18.Margin = New System.Windows.Forms.Padding(4)
        Me.UltraLabel18.Name = "UltraLabel18"
        Me.UltraLabel18.Size = New System.Drawing.Size(67, 15)
        Me.UltraLabel18.TabIndex = 22
        Me.UltraLabel18.Text = "Expiry Date :"
        '
        'CRV
        '
        Me.CRV.ActiveViewIndex = -1
        Me.CRV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRV.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRV.Location = New System.Drawing.Point(0, 116)
        Me.CRV.Name = "CRV"
        Me.CRV.SelectionFormula = ""
        Me.CRV.Size = New System.Drawing.Size(656, 277)
        Me.CRV.TabIndex = 1
        Me.CRV.ViewTimeSelectionFormula = ""
        '
        'Barcode1
        '
        Me.Barcode1.CodeType = C1.Win.C1BarCode.CodeTypeEnum.Code128
        Me.Barcode1.Location = New System.Drawing.Point(329, 164)
        Me.Barcode1.Margin = New System.Windows.Forms.Padding(0)
        Me.Barcode1.Name = "Barcode1"
        Me.Barcode1.ShowText = True
        Me.Barcode1.Size = New System.Drawing.Size(68, 40)
        Me.Barcode1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Barcode1.TabIndex = 13
        Me.Barcode1.TabStop = False
        Me.Barcode1.Text = "1234567890123"
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
        'txtEncodedText
        '
        Me.txtEncodedText.Location = New System.Drawing.Point(307, 45)
        Me.txtEncodedText.Name = "txtEncodedText"
        Me.txtEncodedText.Size = New System.Drawing.Size(310, 20)
        Me.txtEncodedText.TabIndex = 24
        Me.txtEncodedText.Visible = False
        '
        'txtDataToEncode
        '
        Me.txtDataToEncode.Location = New System.Drawing.Point(307, 19)
        Me.txtDataToEncode.Name = "txtDataToEncode"
        Me.txtDataToEncode.Size = New System.Drawing.Size(310, 20)
        Me.txtDataToEncode.TabIndex = 25
        Me.txtDataToEncode.Visible = False
        '
        'frmBarcode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(656, 393)
        Me.Controls.Add(Me.CRV)
        Me.Controls.Add(Me.UltraExpandableGroupBox1)
        Me.Controls.Add(Me.Barcode1)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.DoubleBuffered = True
        Me.Name = "frmBarcode"
        Me.Text = "Barcode"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.UltraExpandableGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraExpandableGroupBox1.ResumeLayout(False)
        Me.UltraExpandableGroupBoxPanel1.ResumeLayout(False)
        Me.UltraExpandableGroupBoxPanel1.PerformLayout()
        CType(Me.DropItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtExpiryDate, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents txtExpiryDate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txtNoOfCopy As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel18 As Infragistics.Win.Misc.UltraLabel
    Private WithEvents CRV As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents DropItem As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraLabel14 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnBarcode2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Barcode1 As C1.Win.C1BarCode.C1BarCode
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtEncodedText As TextBox
    Friend WithEvents txtDataToEncode As TextBox
End Class
