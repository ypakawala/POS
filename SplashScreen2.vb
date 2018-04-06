Public Class SplashScreen2
    Sub New()
        InitializeComponent()
    End Sub

    Public Overrides Sub ProcessCommand(ByVal cmd As System.Enum, ByVal arg As Object)
        MyBase.ProcessCommand(cmd, arg)
    End Sub

    Public Enum SplashScreenCommand
        SomeCommandId
    End Enum

    Private Sub SplashScreen2_Load(sender As Object, e As EventArgs) Handles Me.Load



        If AutoUpdate.UpdateFiles(UpdateFilePath) Then End


        'Set up the dialog text at runtime according to the application's assembly information.  

        'TODO: Customize the application's assembly information in the "Application" pane of the project 
        '  properties dialog (under the "Project" menu).


        

        'Dim ClsConnection As New ClsDBConnection
        'Application title
        'If My.Application.Info.Title <> "" Then
        '    If CompanyCode = ClinicComany.HollywoodSaloon Then
        '        ApplicationTitle.Text = "M.Makeup System"
        '    Else
        ApplicationTitle.Text = My.Application.Info.Title
        '    End If

        'Else
        '    If the application title is missing, use the application name, without the extension
        'ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        'End If

        'Format the version information using the text set into the Version control at design time as the
        '  formatting string.  This allows for effective localization if desired.
        '  Build and revision information could be included by using the following code and changing the 
        '  Version control's designtime text to "Version {0}.{1:00}.{2}.{3}" or something similar.  See
        '  String.Format() in Help for more information.
        '
        Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

        'Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)

        'Copyright info
        Copyright.Text = My.Application.Info.Copyright


     
    End Sub
End Class
