
#Region "Using Directives"

Imports System
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

#End Region

Public Partial Class CurtainUI
	Inherits Form
	#Region "Fields"

	Private dr As DialogResult
	Private done As Boolean = False
	Private Shared cui As CurtainUI = Nothing
	Private Shared m_hasCurtain As Boolean = True
	Private ui As Form = Nothing

	#End Region

	#Region "Properties"

	Public Shared Property HasCurtain() As Boolean

		Get
			Return m_hasCurtain
		End Get
		Set
			m_hasCurtain = value
		End Set
	End Property

	#End Region

	#Region "Constructors"

	Public Sub New(ui As Form)
		InitializeComponent()

		Me.ui = ui
	End Sub

	Public Sub New()
		InitializeComponent()
	End Sub

	#End Region

	#Region "Methods"

	Public Function Down(ui As Form) As DialogResult
		dr = DialogResult.None

		If m_hasCurtain Then
			ShowDialog()
		End If

		Return dr
	End Function

	Public Function Down() As DialogResult
		dr = DialogResult.None

		If m_hasCurtain Then
			ShowDialog()
		End If

		Return dr
	End Function

	Public Sub Up()
		If m_hasCurtain Then
			Dispose()
		End If
	End Sub

	#End Region

	#Region "Events"

	Protected Overloads Overrides Sub OnLoad(e As EventArgs)
		MyBase.OnLoad(e)

		Location = ActiveForm.Location

		'Width = Screen.PrimaryScreen.Bounds.Width;
		'Height = Screen.PrimaryScreen.Bounds.Height;

		Bounds = ActiveForm.Bounds

		If ui IsNot Nothing Then
			timer1.Start()
		End If
	End Sub

	Private Sub timer1_Tick(sender As Object, e As EventArgs)
		If Not done Then
			done = True
			dr = ui.ShowDialog()
			Up()
		Else
			timer1.[Stop]()
		End If
	End Sub

	#End Region

	#Region "Implementation"

	'private static DialogResult Down(Form ui)
	'{
	'    dr = DialogResult.None;
	'    if (hasCurtain)
	'    {
	'        if (cui == null)
	'        {
	'            cui = new CurtainUI(ui);
	'            cui.ShowDialog();
	'        }
	'    }
	'    return dr;
	'}

	'private static void Down()
	'{
	'    if (hasCurtain)
	'    {
	'        if (cui == null)
	'        {
	'            cui = new CurtainUI();
	'            cui.ShowDialog();
	'        }
	'    }
	'}

	'private static void Up()
	'{
	'    if (hasCurtain)
	'    {
	'        if (cui != null)
	'        {
	'            cui.Dispose();
	'            cui = null;
	'        }
	'    }
	'}

	#End Region
End Class
