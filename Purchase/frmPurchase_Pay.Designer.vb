<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPurchase_Pay
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
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("InvoiceNum")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PurchaseCode")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PurchaseDate")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Amount")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PaidAmount")
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPurchase_Pay))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.DropPaymentAccount = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.grdList = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.txtCheckNum = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtTotallDueAmount = New Infragistics.Win.UltraWinEditors.UltraNumericEditor()
        Me.txtDiscountAtPay = New Infragistics.Win.UltraWinEditors.UltraNumericEditor()
        Me.txtPaidAmount = New Infragistics.Win.UltraWinEditors.UltraNumericEditor()
        Me.txtCheckDate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.txtPaymentDate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.txtRefNum = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtNotes = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel10 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel9 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSelectPurchase = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.DropPaymentAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCheckNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotallDueAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDiscountAtPay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPaidAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCheckDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPaymentDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRefNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNotes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.DropPaymentAccount)
        Me.UltraGroupBox1.Controls.Add(Me.grdList)
        Me.UltraGroupBox1.Controls.Add(Me.txtCheckNum)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel2)
        Me.UltraGroupBox1.Controls.Add(Me.txtTotallDueAmount)
        Me.UltraGroupBox1.Controls.Add(Me.txtDiscountAtPay)
        Me.UltraGroupBox1.Controls.Add(Me.txtPaidAmount)
        Me.UltraGroupBox1.Controls.Add(Me.txtCheckDate)
        Me.UltraGroupBox1.Controls.Add(Me.txtPaymentDate)
        Me.UltraGroupBox1.Controls.Add(Me.txtRefNum)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel7)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel8)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel6)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel5)
        Me.UltraGroupBox1.Controls.Add(Me.txtNotes)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel4)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel10)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel9)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel3)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 62)
        Me.UltraGroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(1048, 429)
        Me.UltraGroupBox1.TabIndex = 0
        Me.UltraGroupBox1.Text = "Search"
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'DropPaymentAccount
        '
        Me.DropPaymentAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance29.BackColor = System.Drawing.SystemColors.Window
        Appearance29.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.DropPaymentAccount.DisplayLayout.Appearance = Appearance29
        Me.DropPaymentAccount.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.DropPaymentAccount.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance30.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance30.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance30.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance30.BorderColor = System.Drawing.SystemColors.Window
        Me.DropPaymentAccount.DisplayLayout.GroupByBox.Appearance = Appearance30
        Appearance31.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropPaymentAccount.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance31
        Me.DropPaymentAccount.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance32.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance32.BackColor2 = System.Drawing.SystemColors.Control
        Appearance32.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance32.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DropPaymentAccount.DisplayLayout.GroupByBox.PromptAppearance = Appearance32
        Me.DropPaymentAccount.DisplayLayout.MaxColScrollRegions = 1
        Me.DropPaymentAccount.DisplayLayout.MaxRowScrollRegions = 1
        Appearance33.BackColor = System.Drawing.SystemColors.Window
        Appearance33.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DropPaymentAccount.DisplayLayout.Override.ActiveCellAppearance = Appearance33
        Appearance34.BackColor = System.Drawing.SystemColors.Highlight
        Appearance34.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.DropPaymentAccount.DisplayLayout.Override.ActiveRowAppearance = Appearance34
        Me.DropPaymentAccount.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.DropPaymentAccount.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance35.BackColor = System.Drawing.SystemColors.Window
        Me.DropPaymentAccount.DisplayLayout.Override.CardAreaAppearance = Appearance35
        Appearance36.BorderColor = System.Drawing.Color.Silver
        Appearance36.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.DropPaymentAccount.DisplayLayout.Override.CellAppearance = Appearance36
        Me.DropPaymentAccount.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.DropPaymentAccount.DisplayLayout.Override.CellPadding = 0
        Appearance37.BackColor = System.Drawing.SystemColors.Control
        Appearance37.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance37.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance37.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance37.BorderColor = System.Drawing.SystemColors.Window
        Me.DropPaymentAccount.DisplayLayout.Override.GroupByRowAppearance = Appearance37
        Appearance38.TextHAlignAsString = "Left"
        Me.DropPaymentAccount.DisplayLayout.Override.HeaderAppearance = Appearance38
        Me.DropPaymentAccount.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.DropPaymentAccount.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance39.BackColor = System.Drawing.SystemColors.Window
        Appearance39.BorderColor = System.Drawing.Color.Silver
        Me.DropPaymentAccount.DisplayLayout.Override.RowAppearance = Appearance39
        Me.DropPaymentAccount.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance40.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DropPaymentAccount.DisplayLayout.Override.TemplateAddRowAppearance = Appearance40
        Me.DropPaymentAccount.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.DropPaymentAccount.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.DropPaymentAccount.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.DropPaymentAccount.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.DropPaymentAccount.Location = New System.Drawing.Point(164, 237)
        Me.DropPaymentAccount.Name = "DropPaymentAccount"
        Me.DropPaymentAccount.Size = New System.Drawing.Size(168, 29)
        Me.DropPaymentAccount.TabIndex = 5
        '
        'grdList
        '
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdList.DisplayLayout.Appearance = Appearance5
        Me.grdList.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Width = 106
        UltraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Width = 33
        UltraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5})
        Me.grdList.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.grdList.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdList.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance11.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance11.BorderColor = System.Drawing.SystemColors.Window
        Me.grdList.DisplayLayout.GroupByBox.Appearance = Appearance11
        Appearance12.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdList.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance12
        Me.grdList.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance13.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance13.BackColor2 = System.Drawing.SystemColors.Control
        Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance13.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdList.DisplayLayout.GroupByBox.PromptAppearance = Appearance13
        Me.grdList.DisplayLayout.MaxColScrollRegions = 1
        Me.grdList.DisplayLayout.MaxRowScrollRegions = 1
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Appearance14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdList.DisplayLayout.Override.ActiveCellAppearance = Appearance14
        Appearance15.BackColor = System.Drawing.SystemColors.Highlight
        Appearance15.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdList.DisplayLayout.Override.ActiveRowAppearance = Appearance15
        Me.grdList.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdList.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance16.BackColor = System.Drawing.SystemColors.Window
        Me.grdList.DisplayLayout.Override.CardAreaAppearance = Appearance16
        Appearance17.BorderColor = System.Drawing.Color.Silver
        Appearance17.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdList.DisplayLayout.Override.CellAppearance = Appearance17
        Me.grdList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdList.DisplayLayout.Override.CellPadding = 0
        Me.grdList.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance18.BackColor = System.Drawing.SystemColors.Control
        Appearance18.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance18.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance18.BorderColor = System.Drawing.SystemColors.Window
        Me.grdList.DisplayLayout.Override.GroupByRowAppearance = Appearance18
        Appearance19.TextHAlignAsString = "Left"
        Me.grdList.DisplayLayout.Override.HeaderAppearance = Appearance19
        Me.grdList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdList.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance20.BackColor = System.Drawing.Color.LightSkyBlue
        Me.grdList.DisplayLayout.Override.RowAlternateAppearance = Appearance20
        Appearance21.BackColor = System.Drawing.SystemColors.Window
        Appearance21.BorderColor = System.Drawing.Color.Silver
        Me.grdList.DisplayLayout.Override.RowAppearance = Appearance21
        Me.grdList.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance47.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdList.DisplayLayout.Override.TemplateAddRowAppearance = Appearance47
        Me.grdList.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdList.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdList.Dock = System.Windows.Forms.DockStyle.Right
        Me.grdList.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.grdList.Location = New System.Drawing.Point(338, 23)
        Me.grdList.Name = "grdList"
        Me.grdList.Size = New System.Drawing.Size(707, 403)
        Me.grdList.TabIndex = 9
        Me.grdList.Text = "UltraGrid1"
        '
        'txtCheckNum
        '
        Me.txtCheckNum.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtCheckNum.Location = New System.Drawing.Point(164, 274)
        Me.txtCheckNum.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtCheckNum.Name = "txtCheckNum"
        Me.txtCheckNum.Size = New System.Drawing.Size(167, 28)
        Me.txtCheckNum.TabIndex = 6
        '
        'UltraLabel2
        '
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel2.Appearance = Appearance6
        Me.UltraLabel2.Location = New System.Drawing.Point(7, 274)
        Me.UltraLabel2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(167, 25)
        Me.UltraLabel2.TabIndex = 7
        Me.UltraLabel2.Text = "Check #"
        '
        'txtTotallDueAmount
        '
        Me.txtTotallDueAmount.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtTotallDueAmount.Enabled = False
        Me.txtTotallDueAmount.Location = New System.Drawing.Point(164, 129)
        Me.txtTotallDueAmount.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtTotallDueAmount.MaskInput = "{double:9.3}"
        Me.txtTotallDueAmount.Name = "txtTotallDueAmount"
        Me.txtTotallDueAmount.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtTotallDueAmount.ReadOnly = True
        Me.txtTotallDueAmount.Size = New System.Drawing.Size(167, 28)
        Me.txtTotallDueAmount.TabIndex = 2
        Me.txtTotallDueAmount.TabStop = False
        '
        'txtDiscountAtPay
        '
        Me.txtDiscountAtPay.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtDiscountAtPay.Location = New System.Drawing.Point(164, 201)
        Me.txtDiscountAtPay.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtDiscountAtPay.MaskInput = "{double:9.3}"
        Me.txtDiscountAtPay.Name = "txtDiscountAtPay"
        Me.txtDiscountAtPay.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtDiscountAtPay.Size = New System.Drawing.Size(167, 28)
        Me.txtDiscountAtPay.TabIndex = 4
        '
        'txtPaidAmount
        '
        Me.txtPaidAmount.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtPaidAmount.Location = New System.Drawing.Point(164, 163)
        Me.txtPaidAmount.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtPaidAmount.MaskInput = "{double:9.3}"
        Me.txtPaidAmount.Name = "txtPaidAmount"
        Me.txtPaidAmount.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.txtPaidAmount.Size = New System.Drawing.Size(167, 28)
        Me.txtPaidAmount.TabIndex = 3
        '
        'txtCheckDate
        '
        Me.txtCheckDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtCheckDate.Location = New System.Drawing.Point(164, 312)
        Me.txtCheckDate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtCheckDate.MaskInput = "{LOC}dd/mm/yyyy"
        Me.txtCheckDate.Name = "txtCheckDate"
        Me.txtCheckDate.Size = New System.Drawing.Size(167, 28)
        Me.txtCheckDate.TabIndex = 7
        '
        'txtPaymentDate
        '
        Me.txtPaymentDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtPaymentDate.Location = New System.Drawing.Point(164, 49)
        Me.txtPaymentDate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtPaymentDate.MaskInput = "{LOC}dd/mm/yyyy"
        Me.txtPaymentDate.Name = "txtPaymentDate"
        Me.txtPaymentDate.Size = New System.Drawing.Size(167, 28)
        Me.txtPaymentDate.TabIndex = 0
        '
        'txtRefNum
        '
        Me.txtRefNum.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtRefNum.Location = New System.Drawing.Point(164, 91)
        Me.txtRefNum.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtRefNum.Name = "txtRefNum"
        Me.txtRefNum.Size = New System.Drawing.Size(167, 28)
        Me.txtRefNum.TabIndex = 1
        '
        'UltraLabel7
        '
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel7.Appearance = Appearance7
        Me.UltraLabel7.Location = New System.Drawing.Point(7, 129)
        Me.UltraLabel7.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(167, 25)
        Me.UltraLabel7.TabIndex = 5
        Me.UltraLabel7.Text = "Total Due Amount :"
        '
        'UltraLabel8
        '
        Appearance22.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel8.Appearance = Appearance22
        Me.UltraLabel8.Location = New System.Drawing.Point(7, 201)
        Me.UltraLabel8.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(167, 25)
        Me.UltraLabel8.TabIndex = 5
        Me.UltraLabel8.Text = "Discount @ Pay:"
        '
        'UltraLabel6
        '
        Appearance8.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel6.Appearance = Appearance8
        Me.UltraLabel6.Location = New System.Drawing.Point(7, 236)
        Me.UltraLabel6.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(167, 25)
        Me.UltraLabel6.TabIndex = 5
        Me.UltraLabel6.Text = "Payment Account :"
        '
        'UltraLabel5
        '
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel5.Appearance = Appearance4
        Me.UltraLabel5.Location = New System.Drawing.Point(7, 163)
        Me.UltraLabel5.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(167, 25)
        Me.UltraLabel5.TabIndex = 5
        Me.UltraLabel5.Text = "Paid Amount :"
        '
        'txtNotes
        '
        Me.txtNotes.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtNotes.Location = New System.Drawing.Point(164, 350)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(167, 28)
        Me.txtNotes.TabIndex = 8
        '
        'UltraLabel4
        '
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel4.Appearance = Appearance9
        Me.UltraLabel4.Location = New System.Drawing.Point(7, 91)
        Me.UltraLabel4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(167, 25)
        Me.UltraLabel4.TabIndex = 0
        Me.UltraLabel4.Text = "Ref #"
        '
        'UltraLabel10
        '
        Appearance41.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel10.Appearance = Appearance41
        Me.UltraLabel10.Location = New System.Drawing.Point(7, 312)
        Me.UltraLabel10.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UltraLabel10.Name = "UltraLabel10"
        Me.UltraLabel10.Size = New System.Drawing.Size(167, 25)
        Me.UltraLabel10.TabIndex = 0
        Me.UltraLabel10.Text = "Check Date :"
        '
        'UltraLabel9
        '
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel9.Appearance = Appearance3
        Me.UltraLabel9.Location = New System.Drawing.Point(7, 350)
        Me.UltraLabel9.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UltraLabel9.Name = "UltraLabel9"
        Me.UltraLabel9.Size = New System.Drawing.Size(167, 25)
        Me.UltraLabel9.TabIndex = 0
        Me.UltraLabel9.Text = "Notes :"
        '
        'UltraLabel3
        '
        Appearance10.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel3.Appearance = Appearance10
        Me.UltraLabel3.Location = New System.Drawing.Point(7, 49)
        Me.UltraLabel3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(167, 25)
        Me.UltraLabel3.TabIndex = 0
        Me.UltraLabel3.Text = "Payment Date :"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSave, Me.btnSelectPurchase, Me.btnExit})
        Me.MenuStrip1.Location = New System.Drawing.Point(3, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 26)
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
        'btnSelectPurchase
        '
        Me.btnSelectPurchase.Image = CType(resources.GetObject("btnSelectPurchase.Image"), System.Drawing.Image)
        Me.btnSelectPurchase.Name = "btnSelectPurchase"
        Me.btnSelectPurchase.ShortcutKeys = System.Windows.Forms.Keys.F7
        Me.btnSelectPurchase.Size = New System.Drawing.Size(140, 20)
        Me.btnSelectPurchase.Text = "Select Purchase [F7]"
        '
        'btnExit
        '
        Me.btnExit.Image = Global.POS.My.Resources.Resources.CLOSE_16
        Me.btnExit.Name = "btnExit"
        Me.btnExit.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.btnExit.Size = New System.Drawing.Size(76, 20)
        Me.btnExit.Text = "Exit [F6]"
        '
        'UltraLabel1
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.FontData.BoldAsString = "True"
        Appearance1.FontData.SizeInPoints = 20.0!
        Appearance1.TextHAlignAsString = "Center"
        Appearance1.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance1
        Me.UltraLabel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel1.Location = New System.Drawing.Point(0, 0)
        Me.UltraLabel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(1048, 62)
        Me.UltraLabel1.TabIndex = 5
        Me.UltraLabel1.Text = "Purchase Payment"
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
        Me.UltraGroupBox2.Size = New System.Drawing.Size(1048, 28)
        Me.UltraGroupBox2.TabIndex = 130
        '
        'frmPurchase_Pay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1048, 491)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.UltraLabel1)
        Me.Controls.Add(Me.UltraGroupBox2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "frmPurchase_Pay"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmPurchase_Pay"
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.DropPaymentAccount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCheckNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotallDueAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDiscountAtPay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPaidAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCheckDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPaymentDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRefNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNotes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents DropPaymentAccount As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents grdList As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtCheckNum As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtTotallDueAmount As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents txtPaidAmount As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents txtCheckDate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txtPaymentDate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txtRefNum As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtNotes As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel10 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel9 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnSelectPurchase As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtDiscountAtPay As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
End Class
