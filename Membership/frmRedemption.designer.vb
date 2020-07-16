<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRedemption
    Inherits DevComponents.DotNetBar.Metro.MetroForm
    'Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRedemption))
        Me.grdList = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnRedemption = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnRedemtion2 = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdList
        '
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Appearance19.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdList.DisplayLayout.Appearance = Appearance19
        Me.grdList.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.grdList.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdList.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance16.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance16.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance16.BorderColor = System.Drawing.SystemColors.Window
        Me.grdList.DisplayLayout.GroupByBox.Appearance = Appearance16
        Appearance17.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdList.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance17
        Me.grdList.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance18.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance18.BackColor2 = System.Drawing.SystemColors.Control
        Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance18.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdList.DisplayLayout.GroupByBox.PromptAppearance = Appearance18
        Me.grdList.DisplayLayout.MaxColScrollRegions = 1
        Me.grdList.DisplayLayout.MaxRowScrollRegions = 1
        Appearance27.BackColor = System.Drawing.SystemColors.Window
        Appearance27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdList.DisplayLayout.Override.ActiveCellAppearance = Appearance27
        Appearance22.BackColor = System.Drawing.SystemColors.Highlight
        Appearance22.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdList.DisplayLayout.Override.ActiveRowAppearance = Appearance22
        Me.grdList.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdList.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdList.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance21.BackColor = System.Drawing.SystemColors.Window
        Me.grdList.DisplayLayout.Override.CardAreaAppearance = Appearance21
        Appearance20.BorderColor = System.Drawing.Color.Silver
        Appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdList.DisplayLayout.Override.CellAppearance = Appearance20
        Me.grdList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdList.DisplayLayout.Override.CellPadding = 0
        Me.grdList.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance24.BackColor = System.Drawing.SystemColors.Control
        Appearance24.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance24.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance24.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance24.BorderColor = System.Drawing.SystemColors.Window
        Me.grdList.DisplayLayout.Override.GroupByRowAppearance = Appearance24
        Appearance1.TextHAlignAsString = "Left"
        Me.grdList.DisplayLayout.Override.HeaderAppearance = Appearance1
        Me.grdList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdList.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance28.BackColor = System.Drawing.Color.LightSkyBlue
        Me.grdList.DisplayLayout.Override.RowAlternateAppearance = Appearance28
        Appearance25.BackColor = System.Drawing.SystemColors.Window
        Appearance25.BorderColor = System.Drawing.Color.Silver
        Me.grdList.DisplayLayout.Override.RowAppearance = Appearance25
        Me.grdList.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance23.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdList.DisplayLayout.Override.TemplateAddRowAppearance = Appearance23
        Me.grdList.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdList.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdList.Location = New System.Drawing.Point(0, 38)
        Me.grdList.Name = "grdList"
        Me.grdList.Size = New System.Drawing.Size(907, 479)
        Me.grdList.TabIndex = 11
        Me.grdList.Text = "UltraGrid1"
        '
        'UltraGroupBox1
        '
        Appearance26.BackColor = System.Drawing.Color.DodgerBlue
        Me.UltraGroupBox1.Appearance = Appearance26
        Me.UltraGroupBox1.BackColorInternal = System.Drawing.Color.White
        Me.UltraGroupBox1.Controls.Add(Me.MenuStrip1)
        Me.UltraGroupBox1.Controls.Add(Me.Label6)
        Me.UltraGroupBox1.Controls.Add(Me.btnRedemtion2)
        Me.UltraGroupBox1.Controls.Add(Me.btnClose)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraGroupBox1.ForeColor = System.Drawing.Color.Black
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(907, 38)
        Me.UltraGroupBox1.TabIndex = 17
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip1.ForeColor = System.Drawing.Color.Black
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnRedemption, Me.btnExit})
        Me.MenuStrip1.Location = New System.Drawing.Point(3, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.MenuStrip1.Size = New System.Drawing.Size(682, 36)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'btnRedemption
        '
        Me.btnRedemption.Image = CType(resources.GetObject("btnRedemption.Image"), System.Drawing.Image)
        Me.btnRedemption.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnRedemption.Name = "btnRedemption"
        Me.btnRedemption.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.btnRedemption.Size = New System.Drawing.Size(133, 30)
        Me.btnRedemption.Text = "Redemption [F5]"
        '
        'btnExit
        '
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnExit.Name = "btnExit"
        Me.btnExit.ShortcutKeys = System.Windows.Forms.Keys.F12
        Me.btnExit.Size = New System.Drawing.Size(93, 30)
        Me.btnExit.Text = "Exit - F12"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(685, 0)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(219, 35)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Membership"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnRedemtion2
        '
        Me.btnRedemtion2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnRedemtion2.Location = New System.Drawing.Point(411, 5)
        Me.btnRedemtion2.Name = "btnRedemtion2"
        Me.btnRedemtion2.Size = New System.Drawing.Size(84, 29)
        Me.btnRedemtion2.TabIndex = 19
        Me.btnRedemtion2.Text = "Redemtion"
        Me.btnRedemtion2.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(517, 3)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(84, 29)
        Me.btnClose.TabIndex = 18
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmRedemption
        '
        Me.AcceptButton = Me.btnRedemtion2
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(907, 517)
        Me.Controls.Add(Me.grdList)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmRedemption"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Redemption"
        CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdList As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents btnExit As ToolStripMenuItem
    Friend WithEvents Label6 As Label
    Friend WithEvents btnRedemption As ToolStripMenuItem
    Friend WithEvents btnClose As Button
    Friend WithEvents btnRedemtion2 As Button
End Class
