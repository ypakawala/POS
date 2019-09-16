Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports POS.FixControls

Public Class frmPurchase
    Dim DS As New DataSet

    Private Sub frmPurchase_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        frmPurchaseIns = Nothing
    End Sub

    Private Sub grdList_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdList.ClickCell
        Try
            If e.Cell.Band.Index <> 0 Then Exit Sub
            Select Case e.Cell.Column.Key
                Case "PaidAmount"
                    If UserClass.Allow_Purchase_Pay Then btnPaymentDetail_Click(sender, e)
                Case "Returned"
                    If UserClass.Allow_Purchase_Edit Then btnReturnList_Click(sender, e)
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub grdTeam1_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles grdList.InitializeRow
        If e.Row.Band.Index <> 0 Then Exit Sub
        e.Row.Cells("PaidAmount").Appearance.Cursor = Cursors.Hand
        e.Row.Cells("Returned").Appearance.Cursor = Cursors.Hand

        'e.Row.Cells("TotalAmount").Appearance.BackColor = Color.BurlyWood
        e.Row.Cells("PaidAmount").Appearance.BackColor = Color.LightBlue
        e.Row.Cells("Returned").Appearance.BackColor = Color.LightPink
    End Sub
    Private Sub frmPurchase_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MenuStrip1.KeyUp, grdList.KeyUp, Me.KeyUp, DropSupplier.KeyUp
        Select Case e.KeyCode
            Case Keys.End, Keys.Escape
                Me.Close()
        End Select
    End Sub
    Private Sub frmPurchase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtBalance.InputMask = Mask_Amount5
        Permission()
        FillDropWithCondition(Me.DropSupplier, "Title", "AccountNum", Table.Account, "Code", , , , " WHERE AccountType = " & AccountType.Supplier)


        Me.DropSupplier.Focus()
    End Sub
    Private Sub Permission()
        Try
            Me.btnNew.Visible = UserClass.Allow_Purchase_Add
            Me.btnDelete.Visible = UserClass.Allow_Purchase_Delete
            Me.btnEdit.Visible = UserClass.Allow_Purchase_Edit
            Me.btnReturn.Visible = UserClass.Allow_Purchase_Edit
            Me.btnPayment.Visible = UserClass.Allow_Purchase_Pay
            Me.btnUnPost.Visible = IIf(CLS_Config.Company = AbdulHussain, False, UserClass.Allow_Purchase_Unpost)
            'Me.btnPaymentDetail.Visible = UserClass.Allow_Purchase_Pay
            Me.btnPrint.Visible = UserClass.Allow_Purchase_Print
            Me.AccountStatementToolStripMenuItem1.Visible = UserClass.Allow_Statement_Supplier
            Me.ReportsToolStripMenuItem.Visible = UserClass.Rpt_PurchaseReport
            Me.SupplierListToolStripMenuItem.Visible = UserClass.Allow_Files
        Catch ex As Exception
            MSG.ErrorOk("[Permission]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Try
            If Not UserClass.Allow_Purchase_Add Then
                MsgBox("Permission Denied.")
                Me.DropSupplier.Focus()
                Exit Sub
            End If
            If IsDBNull(Me.DropSupplier.Value) Or IsNothing(Me.DropSupplier.Value) Then
                MsgBox("Select Supplier")
                Me.DropSupplier.Focus()
                Exit Sub
            End If
            If Me.DropSupplier.Value = Nothing Then
                MsgBox("Select Supplier")
                Me.DropSupplier.Focus()
                Exit Sub
            End If

            frmPurchase_NewIns = New frmPurchase_New(CInt(Me.DropSupplier.SelectedRow.Cells("Code").Value))
            frmPurchase_NewIns.ShowDialog()

            FillGrid(Me.DropSupplier.SelectedRow.Cells("Code").Value)

        Catch ex As Exception
            MsgBox("btnNew_Click" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Try
            If Not UserClass.Allow_Purchase_Edit Then
                MsgBox("Permission Denied.")
                Me.DropSupplier.Focus()
                Exit Sub
            End If
            If IsDBNull(Me.grdList.ActiveRow.Cells("Code").Value) Or IsNothing(Me.grdList.ActiveRow.Cells("Code").Value) Then
                MsgBox("Select Record first")
                Exit Sub
            ElseIf Me.grdList.ActiveRow.Cells("Code").Value = Nothing Then
                MsgBox("Select Record first")
                Exit Sub
            ElseIf Me.grdList.ActiveRow.IsFilteredOut = True Then
                MsgBox("Please select the record.")
                Exit Sub
            End If

            If FixCellBoolean(Me.grdList.ActiveRow.Cells("Posted")) = True Then
                MsgBox("Purchase has been posted.Can not be edited.")
                Exit Sub
            End If

            If FixCellNumber(Me.grdList.ActiveRow.Cells("PaidAmount")) > 0 Then
                MsgBox("Payment has been maid for the selected purchase.Can not be edited.")
                Exit Sub
            End If


            frmPurchase_NewIns = New frmPurchase_New(CInt(Me.DropSupplier.SelectedRow.Cells("Code").Value), CInt(Me.grdList.ActiveRow.Cells("Code").Value))
            frmPurchase_NewIns.ShowDialog()

            FillGrid(Me.DropSupplier.SelectedRow.Cells("Code").Value)

        Catch ex As Exception
            MsgBox("btnEdit_Click" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If Not UserClass.Allow_Purchase_Delete Then
                MsgBox("Permission Denied.")
                Me.DropSupplier.Focus()
                Exit Sub
            End If

            If FixCellNumber(Me.grdList.ActiveRow.Cells("Code")) = Nothing Then
                MsgBox("Select Record first")
                Exit Sub
            ElseIf Me.grdList.ActiveRow.IsFilteredOut = True Then
                MsgBox("Please select the record.")
                Exit Sub
            End If
            If FixCellBoolean(Me.grdList.ActiveRow.Cells("Posted")) = True Then
                MsgBox("Purchase has been posted.Can not be deleted.")
                Exit Sub
            End If

            If FixCellNumber(Me.grdList.ActiveRow.Cells("PaidAmount")) > 0 Then
                MsgBox("Payment has been maid for the selected purchase.Can not be deleted.")
                Exit Sub
            End If

            If MsgBox("Are you sure you want to delete the purchase entry?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub

            Dim CLS As New Purchase
            CLS.Code = Me.grdList.ActiveRow.Cells("Code").Value
            CLS.Delete()

            FillGrid(Me.DropSupplier.SelectedRow.Cells("Code").Value)

        Catch ex As Exception
            MsgBox("btnDelete_Click" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPayment.Click
        Try
            If Not UserClass.Allow_Purchase_Pay Then
                MsgBox("Permission Denied.")
                Me.DropSupplier.Focus()
                Exit Sub
            End If

            If IsDBNull(Me.DropSupplier.Value) Or IsNothing(Me.DropSupplier.Value) Then
                MsgBox("Select Supplier")
                Me.DropSupplier.Focus()
                Exit Sub
            End If
            If Me.DropSupplier.Value = Nothing Then
                MsgBox("Select Supplier")
                Me.DropSupplier.Focus()
                Exit Sub
            End If

            If IsNothing(frmPurchase_PayIns) Then
                frmPurchase_PayIns = New frmPurchase_Pay(Me.DropSupplier.SelectedRow.Cells("Code").Value)
                frmPurchase_PayIns.ShowDialog()
                FillGrid(Me.DropSupplier.SelectedRow.Cells("Code").Value)
            End If
        Catch ex As Exception
            MsgBox("btnPayment_Click" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnPaymentDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Not UserClass.Allow_Purchase_Pay Then
                MsgBox("Permission Denied.")
                Me.DropSupplier.Focus()
                Exit Sub
            End If

            If IsDBNull(Me.grdList.ActiveRow) Or IsNothing(Me.grdList.ActiveRow) Then
                MsgBox("Please select the record.")
                Exit Sub
            ElseIf IsDBNull(Me.grdList.ActiveRow.Cells("Code").Value) Or IsNothing(Me.grdList.ActiveRow.Cells("Code").Value) Then
                MsgBox("Please select the record.")
                Exit Sub
            ElseIf Me.grdList.ActiveRow.Cells("Code").Value = Nothing Then
                MsgBox("Please select the record.")
                Exit Sub
            ElseIf Me.grdList.ActiveRow.IsFilteredOut = True Then
                MsgBox("Please select the record.")
                Exit Sub
            End If


            Dim frm As New frmPurchase_Payment_Detail(FixCellNumber(Me.grdList.ActiveRow.Cells("Code")))
            frm.ShowDialog()

            FillGrid(Me.DropSupplier.SelectedRow.Cells("Code").Value)


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnUnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnPost.Click
        Try
            If Not UserClass.Allow_Purchase_Unpost Then
                MsgBox("Permission Denied.")
                Me.DropSupplier.Focus()
                Exit Sub
            End If
            If IsDBNull(Me.grdList.ActiveRow.Cells("Code").Value) Or IsNothing(Me.grdList.ActiveRow.Cells("Code").Value) Then
                MsgBox("Select Record first")
                Exit Sub
            ElseIf Me.grdList.ActiveRow.Cells("Code").Value = Nothing Then
                MsgBox("Select Record first")
                Exit Sub
            ElseIf Me.grdList.ActiveRow.IsFilteredOut = True Then
                MsgBox("Please select the record.")
                Exit Sub
            End If
            If FixCellBoolean(Me.grdList.ActiveRow.Cells("Posted")) = False Then Exit Sub

            If FixCellNumber(Me.grdList.ActiveRow.Cells("PaidAmount")) > 0 Then
                MsgBox("Payment has been maid for the selected purchase.Can not be unposted.")
                Exit Sub
            End If

            If FixCellNumber(Me.grdList.ActiveRow.Cells("Returned")) > 0 Then
                MsgBox("Returned has been maid for the selected purchase.Can not be unposted.")
                Exit Sub
            End If

            Dim PARA As New ArrayList
            PARA.Add(Me.grdList.ActiveRow.Cells("Code").Value)
            DBO.ExecuteSP("Purchase_Unpost", PARA)

            MsgBox("Purchase unposted sucessfully.")
            FillGrid(Me.DropSupplier.SelectedRow.Cells("Code").Value)



        Catch ex As Exception
            MsgBox("btnEdit_Click" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If Not UserClass.Allow_Purchase_Print Then
            MsgBox("Permission Denied.")
            Me.DropSupplier.Focus()
            Exit Sub
        End If
        Me.grdList.PrintPreview()
    End Sub
    Private Sub btnShowAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowAll.Click
        Me.grdList.DisplayLayout.Bands(0).ColumnFilters.ClearAllFilters()
        If Me.btnShowAll.Checked Then
            Me.grdList.DisplayLayout.Bands(0).ColumnFilters("Balance").FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.GreaterThan, 0)
            Me.btnShowAll.Text = "Show All [F4]"
        Else
            Me.btnShowAll.Text = "Show Due [F4]"
        End If
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub DropSupplier_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropSupplier.ValueChanged
        Try
            If IsDBNull(Me.DropSupplier.Value) Or IsNothing(Me.DropSupplier.Value) Then Exit Sub
            If Me.DropSupplier.Value = Nothing Then Exit Sub

            FillGrid(Me.DropSupplier.SelectedRow.Cells("Code").Value)

        Catch ex As Exception
            MsgBox("DropSupplier_ValueChanged" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub FillGrid(ByVal AccountNum As String)
        Try
            'DS = CLS_PurchaseDB_DB.ListBySupplier(SupplierCode)
            DS = New DataSet
            Dim PARA As New ArrayList
            PARA.Add(AccountNum)
            DS = DBO.ExecuteSP_ReturnDataSet("PurchaseList", PARA)

            If DS.Tables(0).Rows.Count > 0 Then
                'Create the Data Relationship
                DS.Relations.Add("Child", DS.Tables(0).Columns("Code"), _
                                            DS.Tables(1).Columns("PurchaseCode"))
            End If

            Me.grdList.DisplayLayout.Override.RowAlternateAppearance = RowAlternateAppearance

            Me.grdList.DataSource = DS
            Me.grdList.DataMember = "Table"
            Me.grdList.DataBind()
            Me.grdList.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle
            Me.grdList.DisplayLayout.Bands(0).Columns("EffectiveDate").SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Descending

            Me.grdList.DisplayLayout.Bands(0).Columns("DiscountAtPay").Hidden = True

            'Set Grid's Columns Order (Arrnage) 
            Me.grdList.DisplayLayout.Bands(0).Columns("Code").Header.VisiblePosition = 0
            Me.grdList.DisplayLayout.Bands(0).Columns("EffectiveDate").Header.VisiblePosition = 1
            Me.grdList.DisplayLayout.Bands(0).Columns("InvoiceNum").Header.VisiblePosition = 2
            Me.grdList.DisplayLayout.Bands(0).Columns("TotalAmount").Header.VisiblePosition = 3
            Me.grdList.DisplayLayout.Bands(0).Columns("PaidAmount").Header.VisiblePosition = 4
            Me.grdList.DisplayLayout.Bands(0).Columns("Discount").Header.VisiblePosition = 5
            Me.grdList.DisplayLayout.Bands(0).Columns("DiscountAtPay").Header.VisiblePosition = 6
            Me.grdList.DisplayLayout.Bands(0).Columns("Returned").Header.VisiblePosition = 7
            Me.grdList.DisplayLayout.Bands(0).Columns("Balance").Header.VisiblePosition = 8
            Me.grdList.DisplayLayout.Bands(0).Columns("Posted").Header.VisiblePosition = 9
            Me.grdList.DisplayLayout.Bands(0).Columns("UserName").Header.VisiblePosition = 10
            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").Header.VisiblePosition = 11

            Me.grdList.DisplayLayout.Bands(0).Columns("EffectiveDate").MaskInput = Mask_Date
            Me.grdList.DisplayLayout.Bands(0).Columns("TotalAmount").MaskInput = Mask_Amount
            Me.grdList.DisplayLayout.Bands(0).Columns("PaidAmount").MaskInput = Mask_Amount
            Me.grdList.DisplayLayout.Bands(0).Columns("Discount").MaskInput = Mask_Amount
            Me.grdList.DisplayLayout.Bands(0).Columns("DiscountAtPay").MaskInput = Mask_Amount
            Me.grdList.DisplayLayout.Bands(0).Columns("Balance").MaskInput = Mask_Amount

            Me.grdList.DisplayLayout.Bands(0).Columns("Discount").Width = 100
            Me.grdList.DisplayLayout.Bands(0).Columns("DiscountAtPay").Width = 100
            Me.grdList.DisplayLayout.Bands(0).Columns("Balance").Width = 100
            Me.grdList.DisplayLayout.Bands(0).Columns("Posted").Width = 50
            Me.grdList.DisplayLayout.Bands(0).Columns("EffectiveDate").Width = 50

            If DS.Tables(0).Rows.Count > 0 Then
                Me.grdList.DisplayLayout.Bands(1).Columns("Code").Hidden = True
                Me.grdList.DisplayLayout.Bands(1).Columns("ItemName").Width = 250
            End If
            'Me.grdList.DisplayLayout.Bands(1).CardView = True

            Me.txtBalance.Value = CDec(DS.Tables(2).Rows(0).Item("Balance"))

            Me.btnShowAll.Checked = True
            Me.btnShowAll.Checked = False
            Me.btnShowAll.Checked = True

            Me.grdList.DisplayLayout.Bands(0).ColumnFilters.ClearAllFilters()
            Me.grdList.DisplayLayout.Bands(0).ColumnFilters("Balance").FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.GreaterThan, 0)
            Me.btnShowAll.Text = "Show All [F4]"



        Catch ex As Exception
            MsgBox("FillGrid" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub grdList_InitializePrintPreview(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelablePrintPreviewEventArgs) Handles grdList.InitializePrintPreview
        Try
            ' Set the zomm level to 100 % in the print preview.
            e.PrintPreviewSettings.Zoom = 1.0

            ' Set the location and size of the print preview dialog.
            e.PrintPreviewSettings.DialogLeft = SystemInformation.WorkingArea.X
            e.PrintPreviewSettings.DialogTop = SystemInformation.WorkingArea.Y
            e.PrintPreviewSettings.DialogWidth = SystemInformation.WorkingArea.Width
            e.PrintPreviewSettings.DialogHeight = SystemInformation.WorkingArea.Height

            ' Horizontally fit everything in a signle page.
            e.DefaultLogicalPageLayoutInfo.FitWidthToPages = 1
            e.PrintDocument.DefaultPageSettings.Landscape = True

            ' Set up the header and the footer.
            e.DefaultLogicalPageLayoutInfo.PageHeader = "Purchase List for " & Me.DropSupplier.Text
            e.DefaultLogicalPageLayoutInfo.PageHeaderHeight = 40
            e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.FontData.SizeInPoints = 14
            e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.TextHAlign = HAlign.Center
            e.DefaultLogicalPageLayoutInfo.PageHeaderBorderStyle = UIElementBorderStyle.Solid

            ' Use <#> token in the string to designate page numbers.
            e.DefaultLogicalPageLayoutInfo.PageFooter = "Page <#>."
            e.DefaultLogicalPageLayoutInfo.PageFooterHeight = 40
            e.DefaultLogicalPageLayoutInfo.PageFooterAppearance.TextHAlign = HAlign.Right
            e.DefaultLogicalPageLayoutInfo.PageFooterAppearance.FontData.Italic = DefaultableBoolean.True
            e.DefaultLogicalPageLayoutInfo.PageFooterBorderStyle = UIElementBorderStyle.Solid

            ' Set the ClippingOverride to Yes.
            e.DefaultLogicalPageLayoutInfo.ClippingOverride = ClippingOverride.Yes

            ' Set the document name through the PrintDocument which returns a PrintDocument object.
            e.DefaultLogicalPageLayoutInfo.PageHeader = "Purchase List for " & Me.DropSupplier.Text
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub grdList_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdList.InitializeLayout
        ' Set the RowSelectorNumberStyle to enable the row-numbers.
        e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex

        ' You can control the appearance of the row numbers using the RowSelectorAppearance.
        e.Layout.Override.RowSelectorAppearance.ForeColor = Color.Blue
        e.Layout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

        ' You can explicitly set the width of the row selectors if the default one calculated
        ' by the UltraGrid is not enough.
        e.Layout.Override.RowSelectorWidth = 35


    End Sub
    Private Sub PurchaseReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseReportToolStripMenuItem.Click
        If Not UserClass.Rpt_PurchaseReport Then
            MsgBox("Permission Denied.")
            Me.DropSupplier.Focus()
            Exit Sub
        End If
        If TrimStr(Me.DropSupplier.Value) <> Nothing Then
            Dim FRM As New frmPurchaseReport(TrimStr(Me.DropSupplier.Value))
            FRM.ShowDialog()
        Else
            Dim FRM As New frmPurchaseReport
            FRM.ShowDialog()
        End If

    End Sub
    Private Sub SupplierBalanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierBalanceToolStripMenuItem.Click
        'Dim FRM As New frmSupplierBalance
        'FRM.ShowDialog()
        Dim FRM2 As New frmAccountBalance(AccountType.Supplier)
        FRM2.ShowDialog()
    End Sub
    Private Sub DebitAgeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DebitAgeToolStripMenuItem.Click
        Dim FRM As New frmDebitAge
        FRM.ShowDialog()
    End Sub
    Private Sub AccountStatementToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountStatementToolStripMenuItem1.Click
        If Not UserClass.Allow_Statement_Supplier Then
            MsgBox("Permission Denied.")
            Me.DropSupplier.Focus()
            Exit Sub
        End If
        If TrimStr(Me.DropSupplier.Value) = Nothing Then
            Dim FRM As New frmAccountStatement(AccountType.Supplier)
            FRM.ShowDialog()
        Else
            Dim FRM As New frmAccountStatement(AccountType.Supplier, TrimStr(Me.DropSupplier.Value))
            FRM.ShowDialog()
        End If
    End Sub
    Private Sub SupplierListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierListToolStripMenuItem.Click
        If Not UserClass.Allow_Files Then
            MsgBox("Permission Denied.")
            Me.DropSupplier.Focus()
            Exit Sub
        End If
        Dim FRM As New frmDynamicList
        FRM.TableName = Table.Account
        FRM.AccountType = AccountType.Supplier
        FRM.ShowDialog()
        FillDropWithCondition(Me.DropSupplier, "Title", "AccountNum", Table.Account, "Code", , , , " WHERE AccountType = " & AccountType.Supplier)
        Me.DropSupplier.Focus()
    End Sub
    Private Sub btnReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturn.Click
        Try
            If Not UserClass.Allow_Purchase_Edit Then
                MsgBox("Permission Denied.")
                Me.DropSupplier.Focus()
                Exit Sub
            End If
            If IsDBNull(Me.DropSupplier.Value) Or IsNothing(Me.DropSupplier.Value) Then
                MsgBox("Select Supplier first")
                Exit Sub
            ElseIf Me.DropSupplier.Value = Nothing Then
                MsgBox("Select Supplier first")
                Exit Sub
            End If

            If IsDBNull(Me.grdList.ActiveRow) Or IsNothing(Me.grdList.ActiveRow) Then
                MsgBox("Please select the record.")
                Exit Sub
            ElseIf IsDBNull(Me.grdList.ActiveRow.Cells("Code").Value) Or IsNothing(Me.grdList.ActiveRow.Cells("Code").Value) Then
                MsgBox("Please select the record.")
                Exit Sub
            ElseIf Me.grdList.ActiveRow.Cells("Code").Value = Nothing Then
                MsgBox("Please select the record.")
                Exit Sub
            ElseIf Me.grdList.ActiveRow.IsFilteredOut = True Then
                MsgBox("Please select the record.")
                Exit Sub
            ElseIf TrimBoolean(Me.grdList.ActiveRow.Cells("Posted").Value) = False Then
                MsgBox("Purchase is not posted yet.")
                Exit Sub
            End If
            frmPurchase_ReturnIns = Nothing
            frmPurchase_ReturnIns = New frmPurchase_Return(CInt(Me.DropSupplier.SelectedRow.Cells("Code").Value), Me.grdList.ActiveRow.Cells("Code").Value)
            frmPurchase_ReturnIns.ShowDialog()

            FillGrid(Me.DropSupplier.SelectedRow.Cells("Code").Value)

        Catch ex As Exception
            MsgBox("btnReturn_Click" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnReturnList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not UserClass.Allow_Purchase_Edit Then
            MsgBox("Permission Denied.")
            Me.DropSupplier.Focus()
            Exit Sub
        End If
        If IsDBNull(Me.DropSupplier.Value) Or IsNothing(Me.DropSupplier.Value) Then
            MsgBox("Select Supplier first")
            Exit Sub
        ElseIf Me.DropSupplier.Value = Nothing Then
            MsgBox("Select Supplier first")
            Exit Sub
        End If

        If IsDBNull(Me.grdList.ActiveRow.Cells("Code").Value) Or IsNothing(Me.grdList.ActiveRow.Cells("Code").Value) Then
            MsgBox("Select Record first")
            Exit Sub
        ElseIf Me.grdList.ActiveRow.Cells("Code").Value = Nothing Then
            MsgBox("Select Record first")
            Exit Sub
        ElseIf Me.grdList.ActiveRow.IsFilteredOut = True Then
            MsgBox("Please select the record.")
            Exit Sub
        End If

        Dim FRM As New frmPurchase_Return_List(CInt(Me.DropSupplier.SelectedRow.Cells("Code").Value), Me.grdList.ActiveRow.Cells("Code").Value)
        FRM.ShowDialog()
        FillGrid(Me.DropSupplier.SelectedRow.Cells("Code").Value)
    End Sub

    Private Sub btnPurchasePayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPurchasePayment.Click
        If Not UserClass.Rpt_PurchaseReport Then
            MsgBox("Permission Denied.")
            Me.DropSupplier.Focus()
            Exit Sub
        End If
        If TrimStr(Me.DropSupplier.Value) <> Nothing Then
            Dim FRM As New frmPurchasePaymentReport(Me.DropSupplier.Value)
            FRM.ShowDialog()
        Else
            Dim FRM As New frmPurchasePaymentReport
            FRM.ShowDialog()
        End If
    End Sub

    Private Sub btnPurchaseSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPurchaseSearch.Click
        Dim frm As New frmPurchaseSearch
        frm.ShowDialog()
    End Sub

    Private Sub btnSuplierPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSuplierPayment.Click

    End Sub

    Private Sub PurchaseSummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseSummaryToolStripMenuItem.Click

    End Sub
End Class