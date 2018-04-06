<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBarcode2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBarcode2))
        Dim Appearance92 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance79 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnBarcode = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbxSearch = New Infragistics.Win.Misc.UltraGroupBox()
        Me.txtExpiryDate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.txtNoOfCopy = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel18 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.gbxSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxSearch.SuspendLayout()
        CType(Me.txtExpiryDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnBarcode, Me.btnExit})
        Me.MenuStrip1.Location = New System.Drawing.Point(3, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 3, 0, 3)
        Me.MenuStrip1.Size = New System.Drawing.Size(681, 26)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'btnBarcode
        '
        Me.btnBarcode.Image = CType(resources.GetObject("btnBarcode.Image"), System.Drawing.Image)
        Me.btnBarcode.Name = "btnBarcode"
        Me.btnBarcode.ShortcutKeys = System.Windows.Forms.Keys.F7
        Me.btnBarcode.Size = New System.Drawing.Size(107, 20)
        Me.btnBarcode.Text = "Barcode [F7]"
        '
        'btnExit
        '
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(89, 20)
        Me.btnExit.Text = "Exit [End]"
        '
        'gbxSearch
        '
        Me.gbxSearch.Controls.Add(Me.txtExpiryDate)
        Me.gbxSearch.Controls.Add(Me.txtNoOfCopy)
        Me.gbxSearch.Controls.Add(Me.UltraLabel5)
        Me.gbxSearch.Controls.Add(Me.UltraLabel18)
        Me.gbxSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxSearch.Location = New System.Drawing.Point(0, 0)
        Me.gbxSearch.Name = "gbxSearch"
        Me.gbxSearch.Size = New System.Drawing.Size(687, 59)
        Me.gbxSearch.TabIndex = 0
        Me.gbxSearch.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'txtExpiryDate
        '
        Me.txtExpiryDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtExpiryDate.Location = New System.Drawing.Point(80, 31)
        Me.txtExpiryDate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtExpiryDate.MaskInput = "{LOC}dd/mm/yyyy"
        Me.txtExpiryDate.Name = "txtExpiryDate"
        Me.txtExpiryDate.Size = New System.Drawing.Size(96, 22)
        Me.txtExpiryDate.TabIndex = 1
        '
        'txtNoOfCopy
        '
        Me.txtNoOfCopy.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtNoOfCopy.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.[Integer]
        Me.txtNoOfCopy.InputMask = "{LOC}nnn"
        Me.txtNoOfCopy.Location = New System.Drawing.Point(80, 3)
        Me.txtNoOfCopy.Name = "txtNoOfCopy"
        Me.txtNoOfCopy.Size = New System.Drawing.Size(37, 20)
        Me.txtNoOfCopy.TabIndex = 0
        '
        'UltraLabel5
        '
        Appearance92.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel5.Appearance = Appearance92
        Me.UltraLabel5.AutoSize = True
        Me.UltraLabel5.Location = New System.Drawing.Point(5, 7)
        Me.UltraLabel5.Margin = New System.Windows.Forms.Padding(4)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(60, 15)
        Me.UltraLabel5.TabIndex = 17
        Me.UltraLabel5.Text = "# of Copy :"
        '
        'UltraLabel18
        '
        Appearance79.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel18.Appearance = Appearance79
        Me.UltraLabel18.AutoSize = True
        Me.UltraLabel18.Location = New System.Drawing.Point(5, 35)
        Me.UltraLabel18.Margin = New System.Windows.Forms.Padding(4)
        Me.UltraLabel18.Name = "UltraLabel18"
        Me.UltraLabel18.Size = New System.Drawing.Size(67, 15)
        Me.UltraLabel18.TabIndex = 18
        Me.UltraLabel18.Text = "Expiry Date :"
        '
        'UltraGroupBox1
        '
        Appearance2.BackColor = System.Drawing.Color.DodgerBlue
        Me.UltraGroupBox1.Appearance = Appearance2
        Me.UltraGroupBox1.BackColorInternal = System.Drawing.Color.White
        Me.UltraGroupBox1.Controls.Add(Me.MenuStrip1)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraGroupBox1.ForeColor = System.Drawing.Color.Black
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 59)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(687, 28)
        Me.UltraGroupBox1.TabIndex = 130
        '
        'frmBarcode2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(687, 318)
        Me.Controls.Add(Me.gbxSearch)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmBarcode2"
        Me.Text = "frmBarcode"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.gbxSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxSearch.ResumeLayout(False)
        Me.gbxSearch.PerformLayout()
        CType(Me.txtExpiryDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnBarcode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gbxSearch As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtExpiryDate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txtNoOfCopy As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel18 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
End Class
