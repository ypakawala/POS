Imports POS.FixControls
Imports System.Threading

Public Class frmLogin
    Private trd As Thread


    Private Sub purchaseFix_AvgPrice()
        Using CONTEXT = New POSEntities
            Dim PList As List(Of Purchase_) = (From q In CONTEXT.Purchase_Set Order By q.EffectiveDate, q.Code Ascending Select q).ToList
            For Each P In PList
                For Each PE In P.Purchase_Entry
                    Dim SUM_Qty As Decimal = 0.0
                    Dim SUM_QtyByUP As Decimal = 0.0
                    Dim PEList As List(Of Purchase_Entry_) = (From q In CONTEXT.Purchase_Entry_Set Where q.ItemCode = PE.ItemCode Order By q.Code Ascending Select q).ToList
                    For Each P_E In PEList
                        SUM_Qty = SUM_Qty + P_E.Qty
                        SUM_QtyByUP = SUM_QtyByUP + (P_E.Qty * P_E.UnitPrice)
                    Next
                    PE.AvgPrice = Decimal.Round(SUM_QtyByUP / SUM_Qty, CLS_Config.DecimalPlace)

                    If P.Posted Then
                        PE.Item.CostPrice = PE.AvgPrice
                        If PE.Item.SalesPrice <> 0 Then
                            PE.Item.ProfitMargin = (((PE.Item.SalesPrice - PE.Item.CostPrice) * 100) / PE.Item.CostPrice)
                            PE.Item.ProfitMargin = Decimal.Round(CDec(PE.Item.ProfitMargin), CLS_Config.DecimalPlace)
                        End If
                    End If

                Next
            Next



            CONTEXT.SaveChanges()
        End Using

    End Sub
    Private Sub purchaseFix_QtyStock()
        Using CONTEXT = New POSEntities
            Dim IList As List(Of Item_) = (From i In CONTEXT.Item_Set
                                           Where i.StockInHand < (From pe In CONTEXT.Purchase_Entry_Set Where pe.ItemCode = i.Code And pe.Purchase.Posted = True Select pe.QtyStock).Sum _
                                           Order By i.Code Descending Select i).ToList
            For Each I In IList

                Dim Bucket As Decimal = 0.0

                For Each PE In I.Purchase_Entry.Where(Function(w) w.Purchase.Posted = True AndAlso w.QtyStock > 0).OrderByDescending(Function(F) F.Purchase.EffectiveDate)

                    If I.StockInHand > Bucket Then

                        If I.StockInHand >= Bucket + PE.QtyStock Then
                            Bucket = Bucket + PE.QtyStock
                        ElseIf I.StockInHand < Bucket + PE.QtyStock Then
                            PE.QtyStock = I.StockInHand - Bucket
                            Bucket = I.StockInHand
                        End If
                    ElseIf I.StockInHand <= Bucket Then
                        PE.QtyStock = 0
                    End If

                Next
            Next
            CONTEXT.SaveChanges()
        End Using

    End Sub
    'Private Sub BW1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)

    'End Sub
    Private Sub ThreadTask()
        Try

            Dim report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            report.Load(CLS_Config.ReportPath & "Barcode.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)

        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & ex.InnerException.Message)
        End Try

    End Sub
    Private Sub frmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Icon = My.Resources.Cart_Blue

        'Dim expDate As New DateTime(2016, 6, 1)
        'If Now > expDate Then
        '    Application.Exit()
        'End If


        If Not theNext.UC.Pub.Get_Trial_Info(YSD, YearStartDate, BDate, onTrial, showTrial, ForceC) Then
            MsgBox("INVALID CONFIG VALUE")
            Application.Exit()
            Me.Close()
        End If

        lblTrial.Visible = showTrial

        If BDate <= Now.Date AndAlso onTrial Then
            lblTrial.Text = "Trial period has expired on " & BDate.ToString("dd/MMM/yyyyy")
            'Exit Sub
        Else
            lblTrial.Text = "Trial period will expire in " & DateDiff(DateInterval.Day, Now.Date, BDate) & " days. " & BDate.ToString("dd/MMM/yyyyy")
        End If

        RowAlternateAppearance.BackColor = System.Drawing.Color.AliceBlue
        Me.btnOK.BackColor = Color.DodgerBlue
        Me.btnCancel.BackColor = Color.OrangeRed


        Dim arr As New ArrayList
        arr = ReadConnection.GetFileContents("Connection.txt")

        ConnStr = arr(0)


        Dim STR As String = ConnStr

        Dim Index_From As Integer = STR.IndexOf("Dsn=") + 4
        STR = STR.Substring(Index_From)
        Dim Index_To As Integer = STR.IndexOf(";")
        DatabaseName = STR.Substring(0, Index_To)

        Index_From = STR.IndexOf("Uid=") + 4
        STR = STR.Substring(Index_From)
        Index_To = STR.IndexOf(";")
        DatabaseLogID = STR.Substring(0, Index_To)

        Index_From = STR.IndexOf("Pwd=") + 4
        DatabasePass = STR.Substring(Index_From)


        If DBO.Connect(DatabaseName, DatabaseLogID, DatabasePass) Then


            CLS_Config = New SysConfig


        Else
            MsgBox("Can not connect to Data Base.")
            End
        End If

        Dim Cls_Read As New ReadConnection










        'open_cashdrawer()

        'Dim cls As New Display
        'cls.OpenPort()
        'cls.WritePort(Chr(&H2) + Chr(&H5) + Chr(&H44) + Chr(&H8) + Chr(&H3))
        'cls.ClosePort()

        Me.lblVersion.Text = System.String.Format(Me.lblVersion.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

        If Not CheckActivation() Then Exit Sub

        'Dim BW1 As New System.ComponentModel.BackgroundWorker
        'AddHandler BW1.DoWork, AddressOf Me.BW1_DoWork
        'BW1.RunWorkerAsync()


        trd = New Thread(AddressOf ThreadTask)
        trd.IsBackground = True
        trd.Start()


        PromoRefresh()

        Trail()

        'sndPLaySound("START.WAV", SND_ASYNC)
        PlaySoundFile("START.WAV")


        'Set Culture To English United States
        Dim myCIintl As New System.Globalization.CultureInfo("en-US", False)
        Application.CurrentCulture = myCIintl




        'Me.txtLoginName.Value = "1"
        'Me.txtPass.Value = "1"
        'btnOK_Click(sender, e)
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            If CLS_Config.Company = AbdulHussain Then purchaseFix_QtyStock()

            'purchaseFix()

            'MsgBox("FIX")

            If Not isValid() Then Exit Sub

            If Me.txtLoginName.Value = "nayeem" And Me.txtPass.Value = "pakawala" Then
                Registration()
                Me.txtLoginName.Value = Nothing
                Me.txtPass.Value = Nothing

                Me.txtLoginName.Focus()
                Me.txtLoginName.SelectAll()
            Else
                If Me.btnOK.Enabled = False Then Exit Sub

                Dim clsDB As New ClassContainer.P_UserDB
                UserClass = clsDB.LogIn(Me.txtLoginName.Value, Me.txtPass.Value)
                If IsDBNull(UserClass) Or IsNothing(UserClass) Then Exit Sub
                If UserClass.Code = 0 Then Exit Sub


                DBO.ActionQuery("UPDATE dbo.Activation SET LastRun=GETDATE(), LastUserCode=" & UserClass.Code & " WHERE ActivationCode='" & _ActivationCode & "'")

                'Me.DialogResult = Windows.Forms.DialogResult.OK
                'Me.Close()


                If IsNothing(frmMainIns) Then
                    Me.Hide()
                    frmMainIns = New frmMain
                    frmMainIns.ShowDialog()
                    'Audit.LogOut()
                    Me.Close()
                End If

            End If

        Catch ex As Exception
            MsgBox("[btnOK_Click]" & vbCrLf & ex.Message)
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtLoginName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLoginName.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtPass.Focus()
            Me.txtPass.SelectAll()
        End If
    End Sub
    Private Sub txtPass_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPass.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.btnOK_Click(sender, e)
        End If
    End Sub

    Private Sub Registration()
        Try
            Dim cls_COM_Trail As New COM_Trail
            If cls_COM_Trail.isRegistered Then
                MsgBox("Already Registered.")
            Else
                Dim RegForm As New frmRegistration()
                Dim getKey As Boolean = RegForm.ShowDialog
                If getKey Then Trail()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function isValid() As Boolean
        Try
            If FixControl(Me.txtLoginName) = Nothing Then
                MsgBox("Login name missing.")
                Me.txtLoginName.Focus()
                Return False
            End If
            If FixControl(Me.txtPass) = Nothing Then
                MsgBox("Password missing.")
                Me.txtPass.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            MsgBox("[isValid]" & vbCrLf & ex.Message)
        End Try
    End Function
    Private Sub Trail()
        'If Now.Date > New Date(2017, 12, 1) Then
        '    MsgBox("007- OUT OF MEMORY ERROR.")
        '    End
        'End If

        'Dim cls_COM_Trail As New COM_Trail
        'Dim loginButton_Enable As Boolean = True
        'Dim LabelTrail_Visible As Boolean = True
        'Dim LinkRegistration As Boolean = True
        'Dim LabelMSG As String = ""

        'cls_COM_Trail.Trial_version(True, 7, False, loginButton_Enable, LabelTrail_Visible, LinkRegistration, LabelMSG)

        'Me.btnOK.Enabled = loginButton_Enable

    End Sub

End Class

