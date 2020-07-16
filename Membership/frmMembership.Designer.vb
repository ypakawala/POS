<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMembership
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMembership))
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim EditorButton1 As Infragistics.Win.UltraWinEditors.EditorButton = New Infragistics.Win.UltraWinEditors.EditorButton()
        Me.isClosed = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.txtMembershipNumber = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtMembershipDate = New System.Windows.Forms.DateTimePicker()
        Me.txtCode = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.DropUserCode = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDOB = New System.Windows.Forms.DateTimePicker()
        Me.txtMobile = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtMemberName = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.DropItem = New Infragistics.Win.UltraWinGrid.UltraCombo()
        CType(Me.txtMembershipNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.DropUserCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMobile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMemberName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DropItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'isClosed
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Appearance1.FontData.SizeInPoints = 15.0!
        Me.isClosed.Appearance = Appearance1
        Me.isClosed.BackColor = System.Drawing.Color.Transparent
        Me.isClosed.BackColorInternal = System.Drawing.Color.Transparent
        Me.isClosed.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007ScrollbarButton
        Me.isClosed.ForeColor = System.Drawing.Color.Black
        Me.isClosed.Location = New System.Drawing.Point(192, 253)
        Me.isClosed.Name = "isClosed"
        Me.isClosed.Size = New System.Drawing.Size(120, 20)
        Me.isClosed.TabIndex = 5
        Me.isClosed.Text = "is Closed"
        '
        'txtMembershipNumber
        '
        Appearance2.BackColor = System.Drawing.Color.White
        Appearance2.ForeColor = System.Drawing.Color.Black
        Me.txtMembershipNumber.Appearance = Appearance2
        Me.txtMembershipNumber.BackColor = System.Drawing.Color.White
        Me.txtMembershipNumber.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtMembershipNumber.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.txtMembershipNumber.ForeColor = System.Drawing.Color.Black
        Me.txtMembershipNumber.Location = New System.Drawing.Point(192, 82)
        Me.txtMembershipNumber.Name = "txtMembershipNumber"
        Me.txtMembershipNumber.Size = New System.Drawing.Size(351, 34)
        Me.txtMembershipNumber.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(4, 5)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 24)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Code :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(4, 44)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(180, 24)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Membership Date :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(3, 200)
        Me.Label8.Margin = New System.Windows.Forms.Padding(5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(140, 24)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Date Of Birth :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(4, 163)
        Me.Label9.Margin = New System.Windows.Forms.Padding(5)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 24)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "Mobile :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.White
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(4, 79)
        Me.Label13.Margin = New System.Windows.Forms.Padding(5)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(139, 24)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "Membership #"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.White
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(4, 120)
        Me.Label10.Margin = New System.Windows.Forms.Padding(5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(153, 24)
        Me.Label10.TabIndex = 29
        Me.Label10.Text = "Member Name :"
        '
        'txtMembershipDate
        '
        Me.txtMembershipDate.BackColor = System.Drawing.Color.White
        Me.txtMembershipDate.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.txtMembershipDate.ForeColor = System.Drawing.Color.Black
        Me.txtMembershipDate.Location = New System.Drawing.Point(192, 44)
        Me.txtMembershipDate.Name = "txtMembershipDate"
        Me.txtMembershipDate.Size = New System.Drawing.Size(351, 32)
        Me.txtMembershipDate.TabIndex = 0
        Me.txtMembershipDate.Value = New Date(2013, 10, 21, 15, 0, 0, 0)
        '
        'txtCode
        '
        Appearance29.BackColor = System.Drawing.Color.White
        Appearance29.ForeColor = System.Drawing.Color.Black
        Me.txtCode.Appearance = Appearance29
        Me.txtCode.BackColor = System.Drawing.Color.White
        Me.txtCode.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtCode.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.txtCode.ForeColor = System.Drawing.Color.Black
        Me.txtCode.Location = New System.Drawing.Point(192, 4)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.ReadOnly = True
        Me.txtCode.Size = New System.Drawing.Size(351, 34)
        Me.txtCode.TabIndex = 6
        Me.txtCode.TabStop = False
        '
        'UltraGroupBox1
        '
        Appearance26.BackColor = System.Drawing.Color.DodgerBlue
        Me.UltraGroupBox1.Appearance = Appearance26
        Me.UltraGroupBox1.BackColorInternal = System.Drawing.Color.White
        Me.UltraGroupBox1.Controls.Add(Me.MenuStrip1)
        Me.UltraGroupBox1.Controls.Add(Me.Label6)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraGroupBox1.ForeColor = System.Drawing.Color.Black
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(635, 38)
        Me.UltraGroupBox1.TabIndex = 16
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip1.ForeColor = System.Drawing.Color.Black
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSave, Me.btnDelete, Me.btnCancel, Me.btnExit})
        Me.MenuStrip1.Location = New System.Drawing.Point(3, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.MenuStrip1.Size = New System.Drawing.Size(410, 36)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnSave.Name = "btnSave"
        Me.btnSave.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.btnSave.Size = New System.Drawing.Size(92, 30)
        Me.btnSave.Text = "Save - F4"
        '
        'btnDelete
        '
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.btnDelete.Size = New System.Drawing.Size(101, 30)
        Me.btnDelete.Text = "Delete - F5"
        '
        'btnCancel
        '
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.ShortcutKeys = System.Windows.Forms.Keys.F8
        Me.btnCancel.Size = New System.Drawing.Size(104, 30)
        Me.btnCancel.Text = "Cancel - F8"
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
        Me.Label6.Location = New System.Drawing.Point(413, 0)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(219, 35)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Membership"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.BackColorInternal = System.Drawing.Color.White
        Me.UltraGroupBox2.Controls.Add(Me.DropUserCode)
        Me.UltraGroupBox2.Controls.Add(Me.Label1)
        Me.UltraGroupBox2.Controls.Add(Me.txtDOB)
        Me.UltraGroupBox2.Controls.Add(Me.isClosed)
        Me.UltraGroupBox2.Controls.Add(Me.Label4)
        Me.UltraGroupBox2.Controls.Add(Me.txtMobile)
        Me.UltraGroupBox2.Controls.Add(Me.txtMemberName)
        Me.UltraGroupBox2.Controls.Add(Me.txtMembershipNumber)
        Me.UltraGroupBox2.Controls.Add(Me.txtCode)
        Me.UltraGroupBox2.Controls.Add(Me.txtMembershipDate)
        Me.UltraGroupBox2.Controls.Add(Me.Label10)
        Me.UltraGroupBox2.Controls.Add(Me.Label13)
        Me.UltraGroupBox2.Controls.Add(Me.Label9)
        Me.UltraGroupBox2.Controls.Add(Me.Label8)
        Me.UltraGroupBox2.Controls.Add(Me.Label5)
        Me.UltraGroupBox2.Dock = System.Windows.Forms.DockStyle.Left
        Me.UltraGroupBox2.ForeColor = System.Drawing.Color.Black
        Me.UltraGroupBox2.Location = New System.Drawing.Point(0, 38)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(556, 363)
        Me.UltraGroupBox2.TabIndex = 0
        '
        'DropUserCode
        '
        Appearance6.FontData.SizeInPoints = 15.0!
        Me.DropUserCode.Appearance = Appearance6
        Me.DropUserCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.DropUserCode.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.DropUserCode.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.DropUserCode.Location = New System.Drawing.Point(192, 288)
        Me.DropUserCode.Name = "DropUserCode"
        Me.DropUserCode.ReadOnly = True
        Me.DropUserCode.Size = New System.Drawing.Size(350, 35)
        Me.DropUserCode.TabIndex = 5
        Me.DropUserCode.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(8, 288)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 24)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "User:"
        '
        'txtDOB
        '
        Me.txtDOB.BackColor = System.Drawing.Color.White
        Me.txtDOB.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.txtDOB.ForeColor = System.Drawing.Color.Black
        Me.txtDOB.Location = New System.Drawing.Point(192, 202)
        Me.txtDOB.Name = "txtDOB"
        Me.txtDOB.Size = New System.Drawing.Size(351, 32)
        Me.txtDOB.TabIndex = 4
        Me.txtDOB.Value = New Date(2013, 10, 21, 15, 0, 0, 0)
        '
        'txtMobile
        '
        Appearance3.BackColor = System.Drawing.Color.White
        Appearance3.ForeColor = System.Drawing.Color.Black
        Me.txtMobile.Appearance = Appearance3
        Me.txtMobile.BackColor = System.Drawing.Color.White
        Me.txtMobile.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtMobile.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.txtMobile.ForeColor = System.Drawing.Color.Black
        Me.txtMobile.Location = New System.Drawing.Point(192, 162)
        Me.txtMobile.Name = "txtMobile"
        Me.txtMobile.Size = New System.Drawing.Size(351, 34)
        Me.txtMobile.TabIndex = 3
        '
        'txtMemberName
        '
        Appearance5.BackColor = System.Drawing.Color.White
        Appearance5.ForeColor = System.Drawing.Color.Black
        Me.txtMemberName.Appearance = Appearance5
        Me.txtMemberName.BackColor = System.Drawing.Color.White
        Me.txtMemberName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtMemberName.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.txtMemberName.ForeColor = System.Drawing.Color.Black
        Me.txtMemberName.Location = New System.Drawing.Point(192, 122)
        Me.txtMemberName.Name = "txtMemberName"
        Me.txtMemberName.Size = New System.Drawing.Size(351, 34)
        Me.txtMemberName.TabIndex = 2
        '
        'DropItem
        '
        Appearance12.FontData.SizeInPoints = 15.0!
        Me.DropItem.Appearance = Appearance12
        EditorButton1.Text = "..."
        EditorButton1.Width = 30
        Me.DropItem.ButtonsRight.Add(EditorButton1)
        Me.DropItem.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.DropItem.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.DropItem.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.DropItem.Location = New System.Drawing.Point(128, 4)
        Me.DropItem.Name = "DropItem"
        Me.DropItem.Size = New System.Drawing.Size(350, 35)
        Me.DropItem.TabIndex = 0
        '
        'frmMembership
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(635, 401)
        Me.Controls.Add(Me.UltraGroupBox2)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmMembership"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Membership"
        CType(Me.txtMembershipNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        CType(Me.DropUserCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMobile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMemberName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DropItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtCode As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtMembershipDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtMembershipNumber As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents isClosed As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtMemberName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents DropItem As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents txtDOB As DateTimePicker
    Friend WithEvents txtMobile As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents DropUserCode As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label1 As Label
End Class
