Imports POS.FixControls
Imports CrystalDecisions.CrystalReports.Engine
Imports Infragistics.Win.UltraWinGrid

Public Class frmMemberhipList
    Public ParentForm As String
    Public CLS As New Membership
    Dim CONTEXT As New POSEntities
    Dim MembershipCode As Integer = 0
    Public Sub New(_MembershipCode As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        MembershipCode = _MembershipCode
    End Sub

    Private Sub frmMemberhipList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.Cart_Blue
        Try
            Me.lblDOB.Text = Nothing
            Me.lblMembershipDate.Text = Nothing
            Me.lblMmebershipNumber.Text = Nothing
            Me.lblMobile.Text = Nothing
            Me.lblName.Text = Nothing
            Me.lblPoints.Text = Nothing
            Me.lblPointsAmt.Text = Nothing
            Me.lblisClosed.Visible = False

            Me.txtSearch.SelectAll()

            Me.btnNew.Visible = UserClass.Allow_MembershipAdd
            Me.btnNew.Enabled = UserClass.Allow_MembershipAdd

            Me.btnEdit.Visible = UserClass.Allow_MembershipEdit
            Me.btnEdit.Enabled = UserClass.Allow_MembershipEdit

            Me.btnItemRedemption.Visible = CLS_Config.MembershipRedemptionReward AndAlso UserClass.Allow_MembershipRedeem
            Me.btnItemRedemption.Enabled = CLS_Config.MembershipRedemptionReward AndAlso UserClass.Allow_MembershipRedeem

            Me.btnCashRedemption.Visible = CLS_Config.MembershipRedemptionCash AndAlso UserClass.Allow_MembershipRedeem
            Me.btnCashRedemption.Enabled = CLS_Config.MembershipRedemptionCash AndAlso UserClass.Allow_MembershipRedeem

            Me.btnDelete.Visible = CLS_Config.MembershipRedemptionReward AndAlso UserClass.Allow_MembershipDelete
            Me.btnDelete.Enabled = CLS_Config.MembershipRedemptionReward AndAlso UserClass.Allow_MembershipDelete

            Me.btnPrint.Visible = CLS_Config.MembershipRedemptionReward AndAlso UserClass.Allow_MembershipPrint
            Me.btnPrint.Enabled = CLS_Config.MembershipRedemptionReward AndAlso UserClass.Allow_MembershipPrint

            If MembershipCode <> 0 Then LoadData(MembershipCode)

        Catch ex As Exception
            MsgBox("frmMemberhipList_Load" & vbCrLf & ex.Message)
            If Not IsNothing(ex.InnerException) Then MsgBox(ex.InnerException.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Find_Int = Nothing
        Dim frm As New frmMembership(0)
        frm.ShowDialog()

        CONTEXT.Refresh(Objects.RefreshMode.StoreWins, CONTEXT.Memberships)
        LoadData(TrimInt(Find_Int))
        Me.txtSearch.SelectAll()

    End Sub

    Private Sub txtItemName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            LoadData(TrimStr(Me.txtSearch.Value))

        End If
    End Sub
    Private Function LoadData(SearchCode As String) As Boolean
        Try
            If Not IsNumeric(SearchCode) Then

                Me.lblDOB.Text = Nothing
                Me.lblMembershipDate.Text = Nothing
                Me.lblMmebershipNumber.Text = Nothing
                Me.lblMobile.Text = Nothing
                Me.lblName.Text = Nothing
                Me.lblPoints.Text = Nothing
                Me.lblPointsAmt.Text = Nothing
                Me.lblisClosed.Visible = False

                MsgBox("Invalid Membership / Mobile #")
                Return False
            End If

            CLS = New Membership
            CLS = (From q In CONTEXT.Memberships Where q.MembershipNumber = SearchCode Select q).ToList().SingleOrDefault()

            If IsDBNull(CLS) OrElse IsNothing(CLS) Then
                CLS = (From q In CONTEXT.Memberships Where q.Mobile = SearchCode Select q).ToList().SingleOrDefault()
            End If
            If IsDBNull(CLS) OrElse IsNothing(CLS) Then
                CLS = (From q In CONTEXT.Memberships Where q.Code = SearchCode Select q).ToList().SingleOrDefault()
            End If

            If IsDBNull(CLS) OrElse IsNothing(CLS) Then

                Me.lblDOB.Text = Nothing
                Me.lblMembershipDate.Text = Nothing
                Me.lblMmebershipNumber.Text = Nothing
                Me.lblMobile.Text = Nothing
                Me.lblName.Text = Nothing
                Me.lblPoints.Text = Nothing
                Me.lblPointsAmt.Text = Nothing
                Me.lblisClosed.Visible = False

                Me.grdList.DataSource = Nothing

                MsgBox("Invalid Membership / Mobile #")
                Return False
            Else

                Me.lblMmebershipNumber.Text = CLS.MembershipNumber
                Me.lblMembershipDate.Text = CLS.MembershipDate
                Me.lblName.Text = CLS.MemberName
                Me.lblMobile.Text = CLS.Mobile
                Me.lblDOB.Text = CLS.DOB
                Me.lblisClosed.Visible = TrimBoolean(CLS.isClosed)


                Dim Query = (From q In CONTEXT.V_MembershipHistory Where q.Code = CLS.Code Select q.Debit - q.Credit)
                If Query.ToList.Count > 0 Then
                    lblPoints.Text = ConvertToString(Query.Sum, True)
                    lblPointsAmt.Text = ConvertToString(Math.Round(CDec(Query.Sum * CLS_Config.MembershipPoint2Amt), 3), True)
                Else
                    lblPoints.Text = "00.000"
                    lblPointsAmt.Text = "00.000"
                End If

                FillGrid(CLS.Code)
            End If

            Me.txtSearch.Text = CLS.MembershipNumber
            Me.txtSearch.SelectAll()

        Catch ex As Exception
            MsgBox("LoadData" & vbCrLf & ex.Message)
            If Not IsNothing(ex.InnerException) Then MsgBox(ex.InnerException.Message, MsgBoxStyle.Critical)
        End Try
    End Function


    Private Sub FillGrid(Code As Integer)
        Try
            Dim DT As New DataTable
            DT = DBO.ReturnDataTable("SELECT * FROM V_MembershipHistory WHERE Code = " & Code)
            Me.grdList.DataSource = DT
            Me.grdList.DataBind()

            Me.grdList.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
            Me.grdList.DisplayLayout.Bands(0).Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False
            Me.grdList.DisplayLayout.Bands(0).Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
            Me.grdList.DisplayLayout.Bands(0).Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False
            Me.grdList.DisplayLayout.Override.RowAlternateAppearance = RowAlternateAppearance
            Me.grdList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
            Me.grdList.DisplayLayout.Bands(0).Columns("DOB").MaskInput = Mask_Date
            Me.grdList.DisplayLayout.Bands(0).Columns("TransectionDate").MaskInput = Mask_Date
            Me.grdList.DisplayLayout.Bands(0).Columns("Debit").MaskInput = Mask_Amount
            Me.grdList.DisplayLayout.Bands(0).Columns("Credit").MaskInput = Mask_Amount

            Me.grdList.DisplayLayout.Bands(0).Columns("Debit").Header.Caption = "Earned"
            Me.grdList.DisplayLayout.Bands(0).Columns("Credit").Header.Caption = "Redeem"

            Me.grdList.DisplayLayout.Bands(0).Columns("Code").Hidden = True
            Me.grdList.DisplayLayout.Bands(0).Columns("MembershipNumber").Hidden = True
            Me.grdList.DisplayLayout.Bands(0).Columns("MemberName").Hidden = True
            Me.grdList.DisplayLayout.Bands(0).Columns("Mobile").Hidden = True
            Me.grdList.DisplayLayout.Bands(0).Columns("DOB").Hidden = True

            Me.grdList.DisplayLayout.Bands(0).Columns("ItemName").Width = 250

            Try
                Me.grdList.Rows.GetRowAtVisibleIndex(1).Activated = True
                Me.grdList.Rows.GetRowAtVisibleIndex(1).Selected = True
            Catch ex As Exception
            End Try

        Catch ex As Exception
            MsgBox("FillGrid" & vbCrLf & ex.Message)
        End Try
    End Sub


    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            If IsDBNull(CLS) OrElse IsNothing(CLS) OrElse TrimInt(CLS.Code) = Nothing Then
                MsgBox("Invalid Membership / Mobile #")
                Exit Sub
            End If
            Find_Int = Nothing
            Dim frm As New frmMembership(CLS.Code)
            frm.ShowDialog()

            CONTEXT.Refresh(Objects.RefreshMode.StoreWins, CONTEXT.Memberships)

            LoadData(CLS.Code)
            Me.txtSearch.SelectAll()

        Catch ex As Exception
            MsgBox("btnEdit_Click" & vbCrLf & ex.Message)
            If Not IsNothing(ex.InnerException) Then MsgBox(ex.InnerException.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click, btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnAssign_Click(sender As Object, e As EventArgs) Handles btnAssign.Click
        If IsDBNull(CLS) OrElse IsNothing(CLS) Then
            MsgBox("Invalid Membership / Mobile #")
            Exit Sub
        End If

        Select Case ParentForm
            Case "frmSales"
                frmSalesIns.CLS_Sale.MembershipCode = CLS.Code
                Me.Close()
        End Select
    End Sub

    Private Sub btnList_Click(sender As Object, e As EventArgs) Handles btnList.Click

        Find_Int = Nothing
        Dim FRM As New frmDynamicList
        FRM.TableName = Table.Membership
        FRM.ShowDialog()

        LoadData(TrimInt(Find_Int))
        Me.txtSearch.SelectAll()

    End Sub


    Private Sub btnCashRedemption_Click(sender As Object, e As EventArgs) Handles btnCashRedemption.Click
        Try
            If IsDBNull(CLS) OrElse IsNothing(CLS) OrElse TrimInt(CLS.Code) = Nothing Then
                MsgBox("Invalid Membership / Mobile #")
                Exit Try
            End If

            Select Case ParentForm
                Case "frmSales"
                    frmSalesIns.CLS_Sale.MembershipCode = CLS.Code
                    Dim Amt As Decimal = TrimDec(Me.lblPointsAmt.Text)

                    If Amt * 1000 Mod 5 <> 0 Then
                        Amt = Amt - (Amt * 1000 Mod 5) / 1000
                    End If


                    If Amt > frmSalesIns.txtTotalBill.Value Then
                        frmSalesIns.txtDiscount.Value = TrimDec(frmSalesIns.txtTotalBill.Value)
                    Else
                        frmSalesIns.txtDiscount.Value = Amt
                    End If
                    Me.Close()
            End Select

        Catch ex As Exception
            MsgBox("btnEdit_Click" & vbCrLf & ex.Message)
            If Not IsNothing(ex.InnerException) Then MsgBox(ex.InnerException.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnItemRedemption_Click(sender As Object, e As EventArgs) Handles btnItemRedemption.Click
        Try
            If IsDBNull(CLS) OrElse IsNothing(CLS) OrElse TrimInt(CLS.Code) = Nothing Then
                MsgBox("Invalid Membership / Mobile #")
                Exit Try
            End If

            Find_Dec = TrimDec(lblPoints.Text)
            Find_Int = Nothing

            Dim frm As New frmRedemption
            If frm.ShowDialog <> DialogResult.OK Then Exit Try

            Find_Dec = 0.0

            Using CONTEXT = New POSEntities
                Dim CLS_Reward As Reward = (From q In CONTEXT.Rewards Where q.Code = Find_Int Select q).SingleOrDefault

                Dim frmShowDialog As New frmDialogResult("Reward selected." & vbCrLf & CLS_Reward.Item.ItemName & vbCrLf & "Reward Point: " & CLS_Reward.RewardPoint & vbCrLf & "Are you sure?")
                If frmShowDialog.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Try


                Dim CLS_Redemption As New Redemption
                CLS_Redemption.Code = GetNewCode("code", "Redemption")
                CLS_Redemption.MembershipCode = CLS.Code
                CLS_Redemption.TransectionDate = Now()
                CLS_Redemption.CashRedemption = False
                CLS_Redemption.RewardPoint = CLS_Reward.RewardPoint
                CLS_Redemption.RewardCash = 0.0
                CLS_Redemption.ItemCode = CLS_Reward.ItemCode
                CONTEXT.Redemptions.AddObject(CLS_Redemption)
                CONTEXT.SaveChanges()

                LoadData(CLS.Code)


                PrintRedemtion(CLS_Redemption.Code)

            End Using




        Catch ex As Exception
            MsgBox("btnEdit_Click" & vbCrLf & ex.Message)
            If Not IsNothing(ex.InnerException) Then MsgBox(ex.InnerException.Message, MsgBoxStyle.Critical)
        End Try

        Me.txtSearch.SelectAll()
        Find_Dec = Nothing
        Find_Int = Nothing

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If IsDBNull(CLS) OrElse IsNothing(CLS) OrElse TrimInt(CLS.Code) = Nothing Then
                MsgBox("Invalid Membership / Mobile #")
                Exit Try
            End If


            If IsDBNull(Me.grdList.ActiveRow) Or IsNothing(Me.grdList.ActiveRow) Then Exit Sub
            If IsDBNull(Me.grdList.ActiveRow.Cells("Code").Value) Or IsNothing(Me.grdList.ActiveRow.Cells("Code").Value) Then Exit Sub

            Dim Source As String = TrimStr(Me.grdList.ActiveRow.Cells("Source").Value)
            Dim Ref As Integer = TrimInt(Me.grdList.ActiveRow.Cells("Ref").Value)
            Dim ItemName As String = TrimStr(Me.grdList.ActiveRow.Cells("ItemName").Value)
            Dim Credit As Decimal = TrimDec(Me.grdList.ActiveRow.Cells("Credit").Value)

            If Source <> "Redemption" Then
                MsgBox("Invalid record")
                Exit Try

            End If
            Dim frmShowDialog As New frmDialogResult("Deleting Reward" & vbCrLf & "Ref : " & Ref & "     Reward Points : " & Credit & vbCrLf & ItemName & vbCrLf & "Are you sure?")
            If frmShowDialog.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Try


            Using CONTEXT = New POSEntities
                Dim CLS_Redemption As Redemption = (From q In CONTEXT.Redemptions Where q.Code = Ref Select q).SingleOrDefault
                CONTEXT.Redemptions.DeleteObject(CLS_Redemption)
                CONTEXT.SaveChanges()
            End Using

            LoadData(CLS.Code)

        Catch ex As Exception
            MsgBox("btnDelete_Click" & vbCrLf & ex.Message)
            If Not IsNothing(ex.InnerException) Then MsgBox(ex.InnerException.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            If IsDBNull(CLS) OrElse IsNothing(CLS) OrElse TrimInt(CLS.Code) = Nothing Then
                MsgBox("Invalid Membership / Mobile #")
                Exit Try
            End If


            If IsDBNull(Me.grdList.ActiveRow) Or IsNothing(Me.grdList.ActiveRow) Then Exit Sub
            If IsDBNull(Me.grdList.ActiveRow.Cells("Code").Value) Or IsNothing(Me.grdList.ActiveRow.Cells("Code").Value) Then Exit Sub

            Dim Source As String = TrimStr(Me.grdList.ActiveRow.Cells("Source").Value)
            Dim Ref As Integer = TrimInt(Me.grdList.ActiveRow.Cells("Ref").Value)
            Dim ItemName As String = TrimStr(Me.grdList.ActiveRow.Cells("ItemName").Value)
            Dim Credit As Decimal = TrimDec(Me.grdList.ActiveRow.Cells("Credit").Value)

            If Source = "Redemption" Then
                PrintRedemtion(Ref)
            Else
                PrintSale(Ref)
            End If

        Catch ex As Exception
            MsgBox("btnPrint_Click" & vbCrLf & ex.Message)
            If Not IsNothing(ex.InnerException) Then MsgBox(ex.InnerException.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub PrintRedemtion(Code As Integer)
        Try
            Dim DT As New DataTable
            DT.Clear()
            Dim Query As String = "SELECT  * FROM V_MembershipHistory WHERE (Ref=" & Code & " AND Source='Redemption' )"
            DT = DBO.ReturnDataTableFromSQL(Query)

            Dim report2 As New ReportDocument
            report2.Load(CLS_Config.ReportPath & "Redemption.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)
            report2.SetDataSource(DT)

            report2.SetParameterValue("CompanyName", TrimStr(CLS_Config.CompanyName))
            report2.SetParameterValue("Address1", TrimStr(CLS_Config.Address1))
            report2.SetParameterValue("Address2", TrimStr(CLS_Config.Address2))
            report2.SetParameterValue("Address3", TrimStr(CLS_Config.Address3))
            report2.SetParameterValue("Tel", TrimStr(CLS_Config.Tel))
            report2.SetParameterValue("PointBalance", TrimDec(lblPoints.Text))

            report2.PrintOptions.PrinterName = CLS_Config.ReceiptPrinter
            report2.PrintToPrinter(1, False, 1, 2)

        Catch ex As Exception
            MsgBox("Print" & vbCrLf & ex.Message)
            If Not IsNothing(ex.InnerException) Then MsgBox(ex.InnerException.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub PrintSale(ByVal SaleCode As Integer)
        Try
            Dim DT As New DataTable
            DT = DBO.ReturnDataTable("SELECT * FROM Sales_Full_View Where SaleCode=" & CInt(SaleCode))


            Dim report As New ReportDocument
            report.Load(CLS_Config.ReportPath & "Bill Receipt.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)
            report.SetDataSource(DT)

            report.SetParameterValue("AccCashCustomer", FixObjectNumber(CLS_Config.AccCashCustomer))
            report.SetParameterValue("CompanyName", FixObjectString(CLS_Config.CompanyName))
            report.SetParameterValue("Address1", FixObjectString(CLS_Config.Address1))
            report.SetParameterValue("Address2", FixObjectString(CLS_Config.Address2))
            report.SetParameterValue("Address3", FixObjectString(CLS_Config.Address3))
            report.SetParameterValue("Tel", FixObjectString(CLS_Config.Tel))
            report.SetParameterValue("CustomerBalance", 0)
            report.SetParameterValue("CashAmount", 0)

            report.SetParameterValue("MembershipRedemptionCash", FixObjectBoolean(CLS_Config.MembershipRedemptionCash))
            report.SetParameterValue("MembershipNumber", FixObjectString(CLS.MembershipNumber))
            report.SetParameterValue("MembershipName", FixObjectString(CLS.MemberName))
            report.SetParameterValue("MembershipPoints", FixObjectString(lblPoints.Text))
            report.SetParameterValue("MembershipPointsAmt", FixObjectString(lblPointsAmt.Text))


            report.PrintOptions.PrinterName = CLS_Config.ReceiptPrinter
            report.PrintToPrinter(1, False, 1, 2)

        Catch ex As Exception
            MsgBox("LoadReport" & vbCrLf & ex.Message)
        End Try
    End Sub

End Class