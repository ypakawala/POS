<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChequeNew
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
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.chkCleared = New System.Windows.Forms.CheckBox()
        Me.UltraLabel11 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.DropSupplierCode = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtCode = New Infragistics.Win.UltraWinEditors.UltraNumericEditor()
        Me.txtAmount = New Infragistics.Win.UltraWinEditors.UltraNumericEditor()
        Me.txttDate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.txtChequeNo = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtNotes = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel9 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.DropSupplierCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txttDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtChequeNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNotes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSave, Me.btnExit})
        Me.MenuStrip1.Location = New System.Drawing.Point(3, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(375, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'btnSave
        '
        Me.btnSave.Image = Global.POS.My.Resources.Resources.SAVE_16
        Me.btnSave.Name = "btnSave"
        Me.btnSave.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.btnSave.Size = New System.Drawing.Size(82, 20)
        Me.btnSave.Text = "Save [F5]"
        '
        'btnExit
        '
        Me.btnExit.Image = Global.POS.My.Resources.Resources.CLOSE_16
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(84, 20)
        Me.btnExit.Text = "Exit [End]"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.chkCleared)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel11)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel8)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox1.Controls.Add(Me.DropSupplierCode)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel2)
        Me.UltraGroupBox1.Controls.Add(Me.txtCode)
        Me.UltraGroupBox1.Controls.Add(Me.txtAmount)
        Me.UltraGroupBox1.Controls.Add(Me.txttDate)
        Me.UltraGroupBox1.Controls.Add(Me.txtChequeNo)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel5)
        Me.UltraGroupBox1.Controls.Add(Me.txtNotes)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel9)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 28)
        Me.UltraGroupBox1.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(381, 224)
        Me.UltraGroupBox1.TabIndex = 0
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'chkCleared
        '
        Me.chkCleared.BackColor = System.Drawing.Color.Transparent
        Me.chkCleared.Location = New System.Drawing.Point(67, 193)
        Me.chkCleared.Name = "chkCleared"
        Me.chkCleared.Size = New System.Drawing.Size(76, 21)
        Me.chkCleared.TabIndex = 9
        Me.chkCleared.Text = "Cleared"
        Me.chkCleared.UseVisualStyleBackColor = False
        '
        'UltraLabel11
        '
        Appearance10.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel11.Appearance = Appearance10
        Me.UltraLabel11.AutoSize = True
        Me.UltraLabel11.Location = New System.Drawing.Point(8, 59)
        Me.UltraLabel11.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.UltraLabel11.Name = "UltraLabel11"
        Me.UltraLabel11.Size = New System.Drawing.Size(55, 17)
        Me.UltraLabel11.TabIndex = 8
        Me.UltraLabel11.Text = "Supplier"
        '
        'UltraLabel8
        '
        Appearance22.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel8.Appearance = Appearance22
        Me.UltraLabel8.AutoSize = True
        Me.UltraLabel8.Location = New System.Drawing.Point(8, 32)
        Me.UltraLabel8.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(34, 17)
        Me.UltraLabel8.TabIndex = 8
        Me.UltraLabel8.Text = "Date"
        '
        'UltraLabel1
        '
        Appearance23.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel1.Appearance = Appearance23
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Location = New System.Drawing.Point(8, 6)
        Me.UltraLabel1.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(38, 17)
        Me.UltraLabel1.TabIndex = 8
        Me.UltraLabel1.Text = "Code"
        '
        'DropSupplierCode
        '
        Me.DropSupplierCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance29.BackColor = System.Drawing.SystemColors.Window
        Appearance29.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.DropSupplierCode.DisplayLayout.Appearance = Appearance29
        Me.DropSupplierCode.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.DropSupplierCode.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance30.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance30.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance30.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance30.BorderColor = System.Drawing.SystemColors.Window
        Me.DropSupplierCode.DisplayLayout.GroupByBox.Appearance = Appearance30
        Appearance31.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropSupplierCode.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance31
        Me.DropSupplierCode.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance32.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance32.BackColor2 = System.Drawing.SystemColors.Control
        Appearance32.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance32.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropSupplierCode.DisplayLayout.GroupByBox.PromptAppearance = Appearance32
        Me.DropSupplierCode.DisplayLayout.MaxColScrollRegions = 1
        Me.DropSupplierCode.DisplayLayout.MaxRowScrollRegions = 1
        Appearance33.BackColor = System.Drawing.SystemColors.Window
        Appearance33.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DropSupplierCode.DisplayLayout.Override.ActiveCellAppearance = Appearance33
        Appearance34.BackColor = System.Drawing.SystemColors.Highlight
        Appearance34.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.DropSupplierCode.DisplayLayout.Override.ActiveRowAppearance = Appearance34
        Me.DropSupplierCode.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.DropSupplierCode.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance35.BackColor = System.Drawing.SystemColors.Window
        Me.DropSupplierCode.DisplayLayout.Override.CardAreaAppearance = Appearance35
        Appearance36.BorderColor = System.Drawing.Color.Silver
        Appearance36.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.DropSupplierCode.DisplayLayout.Override.CellAppearance = Appearance36
        Me.DropSupplierCode.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.DropSupplierCode.DisplayLayout.Override.CellPadding = 0
        Appearance37.BackColor = System.Drawing.SystemColors.Control
        Appearance37.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance37.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance37.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance37.BorderColor = System.Drawing.SystemColors.Window
        Me.DropSupplierCode.DisplayLayout.Override.GroupByRowAppearance = Appearance37
        Appearance38.TextHAlignAsString = "Left"
        Me.DropSupplierCode.DisplayLayout.Override.HeaderAppearance = Appearance38
        Me.DropSupplierCode.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.DropSupplierCode.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance39.BackColor = System.Drawing.SystemColors.Window
        Appearance39.BorderColor = System.Drawing.Color.Silver
        Me.DropSupplierCode.DisplayLayout.Override.RowAppearance = Appearance39
        Me.DropSupplierCode.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance40.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DropSupplierCode.DisplayLayout.Override.TemplateAddRowAppearance = Appearance40
        Me.DropSupplierCode.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.DropSupplierCode.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.DropSupplierCode.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.DropSupplierCode.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.DropSupplierCode.Location = New System.Drawing.Point(70, 55)
        Me.DropSupplierCode.Margin = New System.Windows.Forms.Padding(4)
        Me.DropSupplierCode.Name = "DropSupplierCode"
        Me.DropSupplierCode.Size = New System.Drawing.Size(303, 25)
        Me.DropSupplierCode.TabIndex = 2
        '
        'UltraLabel2
        '
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel2.Appearance = Appearance6
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Location = New System.Drawing.Point(8, 88)
        Me.UltraLabel2.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(55, 17)
        Me.UltraLabel2.TabIndex = 7
        Me.UltraLabel2.Text = "Check #"
        '
        'txtCode
        '
        Me.txtCode.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtCode.Enabled = False
        Me.txtCode.Location = New System.Drawing.Point(70, 2)
        Me.txtCode.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.txtCode.MaskInput = "{LOC}nnnn"
        Me.txtCode.Name = "txtCode"
        Me.txtCode.ReadOnly = True
        Me.txtCode.Size = New System.Drawing.Size(303, 24)
        Me.txtCode.TabIndex = 0
        Me.txtCode.TabStop = False
        '
        'txtAmount
        '
        Me.txtAmount.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtAmount.Location = New System.Drawing.Point(70, 109)
        Me.txtAmount.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.txtAmount.MaskInput = "{double:9.3}"
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtAmount.Size = New System.Drawing.Size(303, 24)
        Me.txtAmount.TabIndex = 4
        '
        'txttDate
        '
        Me.txttDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txttDate.Location = New System.Drawing.Point(70, 28)
        Me.txttDate.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.txttDate.MaskInput = "{LOC}dd/mm/yyyy"
        Me.txttDate.Name = "txttDate"
        Me.txttDate.Size = New System.Drawing.Size(303, 24)
        Me.txttDate.TabIndex = 1
        '
        'txtChequeNo
        '
        Me.txtChequeNo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtChequeNo.Location = New System.Drawing.Point(70, 82)
        Me.txtChequeNo.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.txtChequeNo.Name = "txtChequeNo"
        Me.txtChequeNo.Size = New System.Drawing.Size(303, 24)
        Me.txtChequeNo.TabIndex = 3
        '
        'UltraLabel5
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel5.Appearance = Appearance1
        Me.UltraLabel5.AutoSize = True
        Me.UltraLabel5.Location = New System.Drawing.Point(8, 115)
        Me.UltraLabel5.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(60, 17)
        Me.UltraLabel5.TabIndex = 5
        Me.UltraLabel5.Text = "Amount :"
        '
        'txtNotes
        '
        Me.txtNotes.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtNotes.Location = New System.Drawing.Point(70, 136)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(303, 53)
        Me.txtNotes.TabIndex = 5
        '
        'UltraLabel9
        '
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel9.Appearance = Appearance3
        Me.UltraLabel9.AutoSize = True
        Me.UltraLabel9.Location = New System.Drawing.Point(8, 146)
        Me.UltraLabel9.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.UltraLabel9.Name = "UltraLabel9"
        Me.UltraLabel9.Size = New System.Drawing.Size(48, 17)
        Me.UltraLabel9.TabIndex = 0
        Me.UltraLabel9.Text = "Notes :"
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
        Me.UltraGroupBox2.Size = New System.Drawing.Size(381, 28)
        Me.UltraGroupBox2.TabIndex = 130
        '
        'frmChequeNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(381, 252)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.UltraGroupBox2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmChequeNew"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cheque"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.DropSupplierCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txttDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtChequeNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNotes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel11 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents DropSupplierCode As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtCode As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents txtAmount As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents txttDate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txtChequeNo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtNotes As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel9 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents chkCleared As System.Windows.Forms.CheckBox
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
End Class
