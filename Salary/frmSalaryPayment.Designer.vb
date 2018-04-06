<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSalaryPayment
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
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.lblTitle = New Infragistics.Win.Misc.UltraLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.DropAccountTo = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtCode = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblAccountTo = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel9 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtRefNumber = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtNotes = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtEffectiveDate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.txtBalance = New Infragistics.Win.UltraWinEditors.UltraNumericEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtAmount = New Infragistics.Win.UltraWinEditors.UltraNumericEditor()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.DropAccountTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRefNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNotes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEffectiveDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBalance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.FontData.BoldAsString = "True"
        Appearance1.FontData.SizeInPoints = 20.0!
        Appearance1.TextHAlignAsString = "Center"
        Appearance1.TextVAlignAsString = "Middle"
        Me.lblTitle.Appearance = Appearance1
        Me.lblTitle.BackColorInternal = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Black
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(408, 62)
        Me.lblTitle.TabIndex = 2
        Me.lblTitle.Text = "Salary Payment"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip1.ForeColor = System.Drawing.Color.Black
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSave, Me.btnExit})
        Me.MenuStrip1.Location = New System.Drawing.Point(3, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.MenuStrip1.Size = New System.Drawing.Size(402, 26)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'btnSave
        '
        Me.btnSave.Image = Global.POS.My.Resources.Resources.SAVE_16
        Me.btnSave.Name = "btnSave"
        Me.btnSave.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.btnSave.Size = New System.Drawing.Size(82, 20)
        Me.btnSave.Text = "Save [F4]"
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
        Me.UltraGroupBox1.BackColorInternal = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.UltraGroupBox1.Controls.Add(Me.DropAccountTo)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel2)
        Me.UltraGroupBox1.Controls.Add(Me.txtCode)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel3)
        Me.UltraGroupBox1.Controls.Add(Me.lblAccountTo)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel9)
        Me.UltraGroupBox1.Controls.Add(Me.txtRefNumber)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel4)
        Me.UltraGroupBox1.Controls.Add(Me.txtNotes)
        Me.UltraGroupBox1.Controls.Add(Me.txtEffectiveDate)
        Me.UltraGroupBox1.Controls.Add(Me.txtBalance)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox1.Controls.Add(Me.txtAmount)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel5)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.ForeColor = System.Drawing.Color.Black
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 62)
        Me.UltraGroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(408, 354)
        Me.UltraGroupBox1.TabIndex = 0
        Me.UltraGroupBox1.Text = "Payment Details"
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'DropAccountTo
        '
        Me.DropAccountTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.DropAccountTo.DisplayLayout.Appearance = Appearance12
        Me.DropAccountTo.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.DropAccountTo.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance9.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.DropAccountTo.DisplayLayout.GroupByBox.Appearance = Appearance9
        Appearance10.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropAccountTo.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance10
        Me.DropAccountTo.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance11.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance11.BackColor2 = System.Drawing.SystemColors.Control
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance11.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropAccountTo.DisplayLayout.GroupByBox.PromptAppearance = Appearance11
        Me.DropAccountTo.DisplayLayout.MaxColScrollRegions = 1
        Me.DropAccountTo.DisplayLayout.MaxRowScrollRegions = 1
        Appearance20.BackColor = System.Drawing.SystemColors.Window
        Appearance20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DropAccountTo.DisplayLayout.Override.ActiveCellAppearance = Appearance20
        Appearance15.BackColor = System.Drawing.SystemColors.Highlight
        Appearance15.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.DropAccountTo.DisplayLayout.Override.ActiveRowAppearance = Appearance15
        Me.DropAccountTo.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.DropAccountTo.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Me.DropAccountTo.DisplayLayout.Override.CardAreaAppearance = Appearance14
        Appearance13.BorderColor = System.Drawing.Color.Silver
        Appearance13.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.DropAccountTo.DisplayLayout.Override.CellAppearance = Appearance13
        Me.DropAccountTo.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.DropAccountTo.DisplayLayout.Override.CellPadding = 0
        Appearance17.BackColor = System.Drawing.SystemColors.Control
        Appearance17.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance17.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance17.BorderColor = System.Drawing.SystemColors.Window
        Me.DropAccountTo.DisplayLayout.Override.GroupByRowAppearance = Appearance17
        Appearance19.TextHAlignAsString = "Left"
        Me.DropAccountTo.DisplayLayout.Override.HeaderAppearance = Appearance19
        Me.DropAccountTo.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.DropAccountTo.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance18.BackColor = System.Drawing.SystemColors.Window
        Appearance18.BorderColor = System.Drawing.Color.Silver
        Me.DropAccountTo.DisplayLayout.Override.RowAppearance = Appearance18
        Me.DropAccountTo.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DropAccountTo.DisplayLayout.Override.TemplateAddRowAppearance = Appearance16
        Me.DropAccountTo.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.DropAccountTo.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.DropAccountTo.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.DropAccountTo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.DropAccountTo.Location = New System.Drawing.Point(160, 140)
        Me.DropAccountTo.Name = "DropAccountTo"
        Me.DropAccountTo.Size = New System.Drawing.Size(242, 29)
        Me.DropAccountTo.TabIndex = 3
        '
        'UltraLabel2
        '
        Appearance23.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel2.Appearance = Appearance23
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.ForeColor = System.Drawing.Color.Black
        Me.UltraLabel2.Location = New System.Drawing.Point(7, 28)
        Me.UltraLabel2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(56, 21)
        Me.UltraLabel2.TabIndex = 0
        Me.UltraLabel2.Text = "Code :"
        '
        'txtCode
        '
        Appearance5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance5.ForeColor = System.Drawing.Color.Black
        Me.txtCode.Appearance = Appearance5
        Me.txtCode.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCode.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtCode.ForeColor = System.Drawing.Color.Black
        Me.txtCode.Location = New System.Drawing.Point(160, 28)
        Me.txtCode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.ReadOnly = True
        Me.txtCode.Size = New System.Drawing.Size(242, 28)
        Me.txtCode.TabIndex = 2
        Me.txtCode.TabStop = False
        '
        'UltraLabel3
        '
        Appearance41.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel3.Appearance = Appearance41
        Me.UltraLabel3.AutoSize = True
        Me.UltraLabel3.ForeColor = System.Drawing.Color.Black
        Me.UltraLabel3.Location = New System.Drawing.Point(7, 104)
        Me.UltraLabel3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(122, 21)
        Me.UltraLabel3.TabIndex = 0
        Me.UltraLabel3.Text = "Effective Date :"
        '
        'lblAccountTo
        '
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Me.lblAccountTo.Appearance = Appearance4
        Me.lblAccountTo.AutoSize = True
        Me.lblAccountTo.ForeColor = System.Drawing.Color.Black
        Me.lblAccountTo.Location = New System.Drawing.Point(7, 140)
        Me.lblAccountTo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lblAccountTo.Name = "lblAccountTo"
        Me.lblAccountTo.Size = New System.Drawing.Size(149, 21)
        Me.lblAccountTo.TabIndex = 5
        Me.lblAccountTo.Text = "Payment Account :"
        '
        'UltraLabel9
        '
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel9.Appearance = Appearance3
        Me.UltraLabel9.AutoSize = True
        Me.UltraLabel9.ForeColor = System.Drawing.Color.Black
        Me.UltraLabel9.Location = New System.Drawing.Point(6, 255)
        Me.UltraLabel9.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UltraLabel9.Name = "UltraLabel9"
        Me.UltraLabel9.Size = New System.Drawing.Size(60, 21)
        Me.UltraLabel9.TabIndex = 0
        Me.UltraLabel9.Text = "Notes :"
        '
        'txtRefNumber
        '
        Appearance8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance8.ForeColor = System.Drawing.Color.Black
        Me.txtRefNumber.Appearance = Appearance8
        Me.txtRefNumber.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtRefNumber.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtRefNumber.ForeColor = System.Drawing.Color.Black
        Me.txtRefNumber.Location = New System.Drawing.Point(160, 66)
        Me.txtRefNumber.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtRefNumber.Name = "txtRefNumber"
        Me.txtRefNumber.Size = New System.Drawing.Size(242, 28)
        Me.txtRefNumber.TabIndex = 0
        '
        'UltraLabel4
        '
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel4.Appearance = Appearance6
        Me.UltraLabel4.AutoSize = True
        Me.UltraLabel4.ForeColor = System.Drawing.Color.Black
        Me.UltraLabel4.Location = New System.Drawing.Point(7, 66)
        Me.UltraLabel4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(47, 21)
        Me.UltraLabel4.TabIndex = 0
        Me.UltraLabel4.Text = "Ref #"
        '
        'txtNotes
        '
        Appearance21.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance21.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.Appearance = Appearance21
        Me.txtNotes.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtNotes.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.Location = New System.Drawing.Point(159, 253)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(242, 63)
        Me.txtNotes.TabIndex = 5
        '
        'txtEffectiveDate
        '
        Appearance22.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance22.ForeColor = System.Drawing.Color.Black
        Me.txtEffectiveDate.Appearance = Appearance22
        Me.txtEffectiveDate.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtEffectiveDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtEffectiveDate.ForeColor = System.Drawing.Color.Black
        Me.txtEffectiveDate.Location = New System.Drawing.Point(160, 104)
        Me.txtEffectiveDate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtEffectiveDate.MaskInput = "{LOC}dd/mm/yyyy"
        Me.txtEffectiveDate.Name = "txtEffectiveDate"
        Me.txtEffectiveDate.Size = New System.Drawing.Size(242, 28)
        Me.txtEffectiveDate.TabIndex = 1
        '
        'txtBalance
        '
        Appearance24.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance24.ForeColor = System.Drawing.Color.Black
        Me.txtBalance.Appearance = Appearance24
        Me.txtBalance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtBalance.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtBalance.ForeColor = System.Drawing.Color.Black
        Me.txtBalance.Location = New System.Drawing.Point(160, 215)
        Me.txtBalance.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtBalance.MaskInput = "{double:9.3}"
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtBalance.ReadOnly = True
        Me.txtBalance.Size = New System.Drawing.Size(242, 28)
        Me.txtBalance.TabIndex = 4
        Me.txtBalance.TabStop = False
        '
        'UltraLabel1
        '
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel1.Appearance = Appearance7
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.ForeColor = System.Drawing.Color.Black
        Me.UltraLabel1.Location = New System.Drawing.Point(7, 215)
        Me.UltraLabel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(77, 21)
        Me.UltraLabel1.TabIndex = 5
        Me.UltraLabel1.Text = "Balance :"
        '
        'txtAmount
        '
        Appearance25.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance25.ForeColor = System.Drawing.Color.Black
        Me.txtAmount.Appearance = Appearance25
        Me.txtAmount.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtAmount.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtAmount.ForeColor = System.Drawing.Color.Black
        Me.txtAmount.Location = New System.Drawing.Point(160, 177)
        Me.txtAmount.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtAmount.MaskInput = "{double:9.3}"
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtAmount.Size = New System.Drawing.Size(242, 28)
        Me.txtAmount.TabIndex = 4
        '
        'UltraLabel5
        '
        Appearance26.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel5.Appearance = Appearance26
        Me.UltraLabel5.AutoSize = True
        Me.UltraLabel5.ForeColor = System.Drawing.Color.Black
        Me.UltraLabel5.Location = New System.Drawing.Point(7, 177)
        Me.UltraLabel5.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(74, 21)
        Me.UltraLabel5.TabIndex = 5
        Me.UltraLabel5.Text = "Amount :"
        '
        'UltraGroupBox2
        '
        Appearance2.BackColor = System.Drawing.Color.DodgerBlue
        Me.UltraGroupBox2.Appearance = Appearance2
        Me.UltraGroupBox2.BackColorInternal = System.Drawing.Color.White
        Me.UltraGroupBox2.Controls.Add(Me.MenuStrip1)
        Me.UltraGroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraGroupBox2.ForeColor = System.Drawing.Color.Black
        Me.UltraGroupBox2.Location = New System.Drawing.Point(0, 62)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(408, 28)
        Me.UltraGroupBox2.TabIndex = 130
        '
        'frmSalaryPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(408, 416)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.UltraGroupBox2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "frmSalaryPayment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Voucher"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.DropAccountTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRefNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNotes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEffectiveDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBalance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTitle As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtAmount As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents txtEffectiveDate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txtRefNumber As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtCode As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblAccountTo As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtNotes As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel9 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents DropAccountTo As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents txtBalance As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
End Class
