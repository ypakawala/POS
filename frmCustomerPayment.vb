Imports theNext.UC
Imports CrystalDecisions.CrystalReports.Engine
Imports POS.FixControls
Public Class frmCustomerPayment
    Dim DS As New DataSet
    Dim CLS_ACC As New Account
    Dim PaymentDate As DateTime

    Private Sub grdBill_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdBill.AfterRowActivate
        Try
            If CLS_ACC.Code = CLS_Config.AccTempCredit Then
                If IsDBNull(Me.grdBill.ActiveRow) Or IsNothing(Me.grdBill.ActiveRow) Then Exit Sub
                If FixCellNumber(Me.grdBill.ActiveRow.Cells("Code")) = Nothing Then Exit Sub
                Me.txtPaymentAmount.Value = FixCellNumber(Me.grdBill.ActiveRow.Cells("NetBill"))
            End If

        Catch ex As Exception
            'MSG.ErrorOk("[grdBill_AfterRowActivate]" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub DropCustomer_ItemNotInList(sender As Object, e As Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs) Handles DropCustomer.ItemNotInList

    End Sub


    Private Sub frmCustomerPayment_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, DropCustomer.KeyUp, DropPaymentType.KeyUp, txtBalance.KeyUp, txtPaymentAmount.KeyUp, UltraTabControl1.KeyUp, grdAccount.KeyUp, grdBill.KeyUp, MenuStrip1.KeyUp, txtTotalBalance.KeyUp, txtDiscount.KeyUp, txtNotes.KeyUp
        Select Case e.KeyCode
            Case Keys.End : Me.Close()
            Case Keys.F1 : Me.DropCustomer.Focus()
            Case Keys.F2 : Me.txtPaymentAmount.Focus()
            Case Keys.F3 : Me.DropPaymentType.Focus()
            Case Keys.F4 : Me.btnPay_Click(sender, e)
            Case Keys.F9 : Me.txtDiscount.Focus()
            Case Keys.F8 : Me.txtNotes.Focus()
        End Select
    End Sub
    Private Sub frmCustomerPayment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Me.txtBalance.InputMask = Mask_Amount5Nagative
            Me.txtDiscount.InputMask = Mask_Amount5
            Me.txtPaymentAmount.InputMask = Mask_Amount5
            Me.txtTotalBalance.InputMask = Mask_Amount5Nagative

            If Not CLS_Config.MonthBasePayment Then
                Me.lblTotalBalance.Visible = False
                Me.txtTotalBalance.Visible = False
            End If

            If Not UserClass.Allow_Customer_Pay_Delete Then Me.btnDelete.Visible = False

            If Not UserClass.Allow_Customer_Pay_Dis Then
                Me.txtDiscount.Value = 0
                Me.txtDiscount.Enabled = False
            End If

            FillDropWithCondition(Me.DropCustomer, "Title", "AccountNum", Table.Account, "Code", , , , " WHERE AccountType = " & AccountType.Customer & " AND Code<>" & CLS_Config.AccCashCustomer)
            FillDropWithCondition(Me.DropPaymentType, "Title", "Code", Table.D_PaymentType, , , , , " WHERE Code IN( " & PaymentType.Cash & "," & PaymentType.KNet & "," & PaymentType.MasterCard & ")")
            'FillDrop(Me.DropPaymentType, "Title", "Code", Table.D_PaymentType)

            If CLS_Config.Company <> BOOKSHOP Then Me.btnPayCard.Visible = False

            Me.DropPaymentType.Value = PaymentType.Cash

            Me.txtPaymentDate.Value = Now

            If CLS_Config.MonthBasePayment Then
                Me.txtPaymentDate.MaskInput = "{LOC}mm/yyyy"
                Me.txtPaymentDate.Value = Now.AddMonths(-1)
                Me.txtPaymentDate.MaxDate = New Date(Now.Year, Now.Month, getDaysOfMonth(Now.Year, Now.Month), 23, 59, 59)
                Me.txtPaymentDate.MinDate = New Date(Now.Year, Now.Month, 1)
                Me.txtPaymentDate.MinDate = CDate(Me.txtPaymentDate.MinDate).AddMonths(-1)
            Else
                Me.txtPaymentDate.MaskInput = "{LOC}dd/mm/yyyy hh:mm"
                Me.txtPaymentDate.MinDate = New Date(Now.Year, Now.Month, Now.Day, 0, 0, 0)
                'Me.txtPaymentDate.Visible = False
                'Me.lblPaymentDate.Visible = False
            End If

     
            Me.DropCustomer.Focus()
            Me.DropCustomer.Select()

        Catch ex As Exception
            MSG.ErrorOk("[frmCustomerPayment_Load]" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub DropCustomer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DropCustomer.KeyDown
        Try
            If e.KeyCode <> Keys.Enter Then Exit Sub

            If FixObjectString(Me.DropCustomer.Value) = Nothing Then
                If FixObjectString(Me.DropCustomer.Text) = Nothing Then
                    Me.txtBalance.Value = Nothing
                    Me.txtPaymentAmount.Value = Nothing
                    Me.grdBill.DataSource = Nothing
                    Me.grdBill.DataBind()
                    Me.grdAccount.DataSource = Nothing
                    Me.grdAccount.DataBind()
                    CLS_ACC = Nothing
                    Exit Sub
                Else

                    GetAccountInfo()

                    If IsDBNull(CLS_ACC) Or IsNothing(CLS_ACC) Then
                        MSG.ErrorOk("Invalid Customer Accout !!!")
                        Exit Sub
                    End If
                    'If Not CLS_ACC.Select_Customer(Me.DropCustomer.Text, Null_Date) Then
                    '    MSG.ErrorOk("Invalid Customer Accout !!!")
                    '    Exit Sub
                    'End If

                    'AUG 2016 'Fill_Dataset(CLS_ACC.Code)

                    Me.DropCustomer.Value = CLS_ACC.AccountNum

                    'Me.txtBalance.Value = CLS_ACC.Balance
                    Me.txtDiscount.Value = Nothing
                    Me.txtPaymentAmount.Value = Nothing
                    If Me.txtDiscount.Enabled Then
                        Me.txtDiscount.Focus()
                        Me.txtDiscount.SelectAll()
                    Else
                        Me.txtPaymentAmount.Focus()
                        Me.txtPaymentAmount.SelectAll()
                    End If
                End If
            Else
                GetAccountInfo()

                If IsDBNull(CLS_ACC) Or IsNothing(CLS_ACC) Then
                    MSG.ErrorOk("Invalid Customer Accout !!!")
                    Exit Sub
                End If

                'If Not CLS_ACC.Select_Customer(Me.DropCustomer.Value, Null_Date) Then
                '    MSG.ErrorOk("Invalid Customer Accout !!!")
                '    Exit Sub
                'End If

                'AUG 2016 'Fill_Dataset(CLS_ACC.Code)

                Me.DropCustomer.Value = CLS_ACC.AccountNum

                'Me.txtBalance.Value = CLS_ACC.Balance

                If CLS_ACC.Code <> CLS_Config.AccTempCredit Then
                    Me.txtDiscount.Value = Nothing
                    Me.txtPaymentAmount.Value = Nothing
                    If Me.txtDiscount.Enabled Then
                        Me.txtDiscount.Focus()
                        Me.txtDiscount.SelectAll()
                    Else
                        Me.txtPaymentAmount.Focus()
                        Me.txtPaymentAmount.SelectAll()
                    End If
                End If

            End If

        Catch ex As Exception
            MSG.ErrorOk("[DropCustomer_KeyDown]" & vbCrLf & ex.Message)
        End Try
    End Sub
    'Private Sub DropCustomer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DropCustomer.KeyDown
    '    Try
    '        If e.KeyCode <> Keys.Enter Then Exit Sub

    '        If FixObjectString(Me.DropCustomer.Value) = Nothing Then
    '            If FixObjectString(Me.DropCustomer.Text) = Nothing Then
    '                Me.txtBalance.Value = Nothing
    '                Me.txtPaymentAmount.Value = Nothing
    '                Me.grdBill.DataSource = Nothing
    '                Me.grdBill.DataBind()
    '                Me.grdAccount.DataSource = Nothing
    '                Me.grdAccount.DataBind()
    '                CLS_ACC = Nothing
    '                Exit Sub
    '            Else

    '                GetAccountInfo()

    '                If Not CLS_ACC.Select_Customer(Me.DropCustomer.Text, Null_Date) Then
    '                    MSG.ErrorOk("Invalid Customer Accout !!!")
    '                    Exit Sub
    '                End If

    '                Fill_Dataset(CLS_ACC.Code)

    '                Me.DropCustomer.Value = CLS_ACC.AccountNum

    '                Me.txtBalance.Value = CLS_ACC.Balance
    '                Me.txtPaymentAmount.Value = Nothing
    '                Me.txtPaymentAmount.Focus()
    '                Me.txtPaymentAmount.SelectAll()
    '            End If
    '        Else
    '            If Not CLS_ACC.Select_Customer(Me.DropCustomer.Value, Null_Date) Then
    '                MSG.ErrorOk("Invalid Customer Accout !!!")
    '                Exit Sub
    '            End If

    '            Fill_Dataset(CLS_ACC.Code)

    '            Me.DropCustomer.Value = CLS_ACC.AccountNum

    '            Me.txtBalance.Value = CLS_ACC.Balance

    '            If CLS_ACC.Code <> CLS_Config.AccTempCredit Then
    '                Me.txtPaymentAmount.Value = Nothing
    '                Me.txtPaymentAmount.Focus()
    '                Me.txtPaymentAmount.SelectAll()
    '            End If

    '        End If

    '    Catch ex As Exception
    '        MSG.ErrorOk("[DropCustomer_KeyDown]" & vbCrLf & ex.Message)
    '    End Try
    'End Sub
    Private Sub DropCustomer_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropCustomer.ValueChanged
        Try
            If FixObjectString(Me.DropCustomer.Value) = Nothing Then
                Me.txtBalance.Value = Nothing
                Me.txtPaymentAmount.Value = Nothing
                Me.grdBill.DataSource = Nothing
                Me.grdBill.DataBind()
                Me.grdAccount.DataSource = Nothing
                Me.grdAccount.DataBind()
                Exit Sub
            End If


            'If Not CLS_ACC.Select_Customer(Me.DropCustomer.Value) Then
            '    MSG.ErrorOk("Invalid Customer Accout !!!")
            '    Exit Sub
            'End If

            'Fill_Dataset(CLS_ACC.Code)

            'Me.txtBalance.Value = CLS_ACC.Balance
            'Me.txtPaymentAmount.Value = Nothing
            'Me.txtPaymentAmount.Focus()
            'Me.txtPaymentAmount.SelectAll()

        Catch ex As Exception
            MSG.ErrorOk("[DropCustomer_ValueChanged]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub Fill_Dataset(ByVal AccountCode As Integer)
        Try

            DS = New DataSet

            'If CLS_Config.MonthBasePayment Then
            Dim PARA As New ArrayList
            PARA.Add(AccountCode)
            DS = DBO.ExecuteSP_ReturnDataSet("CustomerInfo", PARA)

            'Else

            '    Using CONTEXT = New POSEntities

            '        Dim Voucher = (From q In CONTEXT.Voucher_Set
            '                       From u In CONTEXT.P_User
            '                       From vd In CONTEXT.Voucher_Entry
            '                       Where q.UserCode = u.Code _
            '                       AndAlso q.Code = vd.VoucherCode _
            '                       AndAlso vd.AccountCode = AccountCode _
            '                       AndAlso q.TransectionType <> 15 _
            '                       AndAlso q.TransectionType <> 16
            '                       Order By q.TransectionDate Descending
            '                       Select q.Code, q.TransectionType, q.RefNumber, q.EffectiveDate, vd.Debit, vd.Credit, u.UserName, q.Notes).Take(10)

            '        Dim DT0 As New DataTable
            '        DT0 = EntityToDataTable.EntityToDatatable(Voucher, CONTEXT)
            '        DT0.Columns("TransectionType").ColumnName = "TransectionTypeCode"


            '        Dim pur = (From q In CONTEXT.Sale_Set
            '                 From u In CONTEXT.P_User
            '           Where q.UserCode = u.Code _
            '           AndAlso q.CustomerCode = AccountCode _
            '           AndAlso q.TransectionType <> 15 _
            '           AndAlso q.TransectionType <> 16
            '           Order By q.TransectionDate Descending
            '           Select q.Code, q.BillNo, q.TransectionDate, TransectionTypeCode = q.TransectionType, q.TotalBill, q.Discount, q.NetBill, q.Remark, u.UserName).Take(10)

            '        Dim DT1 As New DataTable
            '        DT1 = EntityToDataTable.EntityToDatatable(pur, CONTEXT)
            '        DT1.Columns("TransectionDate").ColumnName = "Date"


            '        Dim S_IncludeList As IEnumerable(Of Integer)
            '        S_IncludeList = (From q In pur Select q.Code).Distinct.ToList


            '        Dim PurDetail = From q In CONTEXT.Sale_Entry_Set _
            '                        From itm In CONTEXT.Item_Set
            '                         Where S_IncludeList.Contains(q.SaleCode) _
            '                         Select q.Code, q.SaleCode, itm.ItemName, q.UnitPrice, q.Quantity, q.TotalPrice
            '        Dim DT2 As New DataTable
            '        DT2 = EntityToDataTable.EntityToDatatable(PurDetail, CONTEXT)


            '        DS.Tables.Add(DT0)
            '        DS.Tables.Add(DT1)
            '        DS.Tables.Add(DT2)

            '    End Using
            'End If








            'Me.UcGrid1.grdList.DataSource = DS


            Me.grdAccount.DataSource = DS.Tables(0)
            Me.grdAccount.DataBind()

            Me.grdAccount.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle

            If DS.Tables(1).Rows.Count > 0 Then
                'Create the Data Relationship
                DS.Relations.Add("Child", DS.Tables(1).Columns("Code"), _
                                            DS.Tables(2).Columns("SaleCode"))
            End If

            Me.grdBill.DataSource = DS
            Me.grdBill.DataMember = "Table1"
            Me.grdBill.DataBind()


            Me.grdAccount.DisplayLayout.Bands(0).Columns("Code").Hidden = True
            Me.grdAccount.DisplayLayout.Bands(0).Columns("TransectionTypeCode").Hidden = True

            Me.grdAccount.DisplayLayout.Bands(0).Columns("Notes").Width = 150
            Me.grdAccount.DisplayLayout.Bands(0).Columns("Debit").MaskInput = Mask_Amount
            Me.grdAccount.DisplayLayout.Bands(0).Columns("Credit").MaskInput = Mask_Amount
            Me.grdAccount.DisplayLayout.Bands(0).Columns("EffectiveDate").MaskInput = Mask_Date

            Me.grdAccount.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
            Me.grdAccount.DisplayLayout.Bands(0).Columns("EffectiveDate").SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Descending

            Dim i As Integer = 0
            For i = 0 To Me.grdAccount.DisplayLayout.Bands(0).Columns.Count - 1
                Me.grdAccount.DisplayLayout.Bands(0).Columns(i).PerformAutoResize()
            Next


            Me.grdBill.DisplayLayout.Bands(0).Columns("Code").Hidden = True
            If DS.Tables(1).Rows.Count > 0 Then
                Me.grdBill.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
                Me.grdBill.DisplayLayout.Bands(1).Columns("Code").Hidden = True
                Me.grdBill.DisplayLayout.Bands(1).Columns("SaleCode").Hidden = True
                Me.grdBill.DisplayLayout.Bands(0).Columns("Date").MaskInput = Mask_Date
                Me.grdBill.DisplayLayout.Bands(0).Columns("TotalBill").MaskInput = Mask_Amount
                Me.grdBill.DisplayLayout.Bands(0).Columns("Discount").MaskInput = Mask_Amount
                Me.grdBill.DisplayLayout.Bands(0).Columns("NetBill").MaskInput = Mask_Amount
                Me.grdBill.DisplayLayout.Bands(1).Columns("UnitPrice").MaskInput = Mask_Amount
                Me.grdBill.DisplayLayout.Bands(1).Columns("Quantity").MaskInput = Mask_Qty
                Me.grdBill.DisplayLayout.Bands(1).Columns("TotalPrice").MaskInput = Mask_Amount

                i = 0
                For i = 0 To Me.grdBill.DisplayLayout.Bands(0).Columns.Count - 1
                    Me.grdBill.DisplayLayout.Bands(0).Columns(i).PerformAutoResize()
                Next

                i = 0
                For i = 0 To Me.grdBill.DisplayLayout.Bands(1).Columns.Count - 1
                    Me.grdBill.DisplayLayout.Bands(1).Columns(i).PerformAutoResize()
                Next

                Me.grdBill.DisplayLayout.Bands(1).Columns("ItemName").Width = 250

                'Dim SummarySettings1 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "NetBill", 0, True, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "NetBill", 0, True)
                'SummarySettings1.DisplayFormat = " {0}"
                ''SummarySettings1.GroupBySummaryValueAppearance = Appearance18
                'SummarySettings1.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.TopFixed
                'Me.grdBill.DisplayLayout.Bands(0).Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings1})
                'Me.grdBill.DisplayLayout.BandsSerializer.Add(Me.grdBill.DisplayLayout.Bands(0))

                If CLS_ACC.Code = CLS_Config.AccTempCredit Then
                    Me.txtPaymentAmount.Enabled = False
                Else
                    Me.txtPaymentAmount.Enabled = True
                End If

            End If


        Catch ex As Exception
            MSG.ErrorOk("[Fill_Dataset]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub Pay(ByVal TranType As TransectionType)
        Try
            If FixObjectNumber(CLS_ACC.Code) = Nothing Then
                MSG.ErrorOk("Invalid Customer !!!")
                Me.DropCustomer.Focus()
                Exit Sub
            End If
            If FixControl(Me.txtPaymentDate) = Nothing Then
                MSG.ErrorOk("Invalid Payment Date !!!")
                Me.txtPaymentDate.Focus()
                Exit Sub
            End If
            Dim d1 As DateTime
            d1 = TrimDate(Me.txtPaymentDate.Value)
            Dim d2 As New DateTime(d1.Year, d1.Month, d1.Day, 0, 0, 0)
            Dim d3 As New DateTime(Now.Year, Now.Month, Now.Day, 0, 0, 0)
           
            If d2 > d3 Then
                Dim frm As New frmDialogResult("Payment Date is greater than today. Accounts will take effect on selected date only." & vbCrLf & vbCrLf & "Are you sure?")
                If frm.ShowDialog <> Windows.Forms.DialogResult.OK Then
                    Me.txtPaymentDate.Focus()
                    Me.txtPaymentDate.SelectAll()
                    Exit Sub
                End If
            End If
            'If FixControl(Me.txtBalance) = Nothing Then
            '    MSG.ErrorOk("Invalid Customer Balance!!!")
            '    Me.DropCustomer.Focus()
            '    Exit Sub
            'End If
            If FixControl(Me.txtPaymentAmount) = Nothing Then
                MSG.ErrorOk("Invalid Payment Amount!!!")
                Me.txtPaymentAmount.Focus()
                Me.txtPaymentAmount.SelectAll()
                Exit Sub
            End If

            If CLS_Config.MonthBasePayment Then
                If Me.txtPaymentAmount.Value + FixControl(Me.txtDiscount) > Me.txtTotalBalance.Value Then
                    Dim frm As New frmDialogResult("Payment is more than balance." & vbCrLf & vbCrLf & "Are you sure?")
                    If frm.ShowDialog <> Windows.Forms.DialogResult.OK Then
                        Me.txtPaymentAmount.Focus()
                        Me.txtPaymentAmount.SelectAll()
                        Exit Sub
                    End If
                End If
            Else
                If Me.txtPaymentAmount.Value + FixControl(Me.txtDiscount) > Me.txtBalance.Value Then
                    Dim frm As New frmDialogResult("Payment more than balance." & vbCrLf & vbCrLf & "Are you sure?")
                    If frm.ShowDialog <> Windows.Forms.DialogResult.OK Then
                        Me.txtPaymentAmount.Focus()
                        Me.txtPaymentAmount.SelectAll()
                        Exit Sub
                    End If
                End If
            End If
            

            If CLS_ACC.Code = CLS_Config.AccTempCredit Then
                If IsDBNull(Me.grdBill.ActiveRow) Or IsNothing(Me.grdBill.ActiveRow) Then
                    MSG.ErrorOk("Please select the sales transection to pay for.")
                    Exit Sub
                End If
                If FixCellNumber(Me.grdBill.ActiveRow.Cells("Code")) = Nothing Then
                    MSG.ErrorOk("Please select the sales transection to pay for.")
                    Exit Sub
                End If
            End If

            If FixControl(Me.DropPaymentType) = Nothing Then
                Me.DropPaymentType.Value = PaymentType.Cash
            End If

            If TranType = TransectionType.CustomerPayment Then

                Dim frm As New frmDialogResult("Payment from Customer [" & CLS_ACC.Title & "]" & vbCrLf & vbCrLf & _
                                 "Payment Amount [" & ConvertToString(FixControl(Me.txtPaymentAmount)) & "]" & vbCrLf & vbCrLf & _
                                 IIf(FixControl(Me.txtDiscount) > 0, "Discount [" & ConvertToString(FixControl(Me.txtDiscount)) & "]", ""))
                If frm.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub


            ElseIf TranType = TransectionType.Customer_Card_Payment Then


                Dim frm As New frmDialogResult("Card Payment from Customer [" & CLS_ACC.Title & "]" & vbCrLf & vbCrLf & "Payment Amount [" & ConvertToString(Me.txtPaymentAmount.Value) & "]")
                If frm.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub

            End If


            Dim temp As DateTime = FixControl(Me.txtPaymentDate)

            Dim Customer As String = Nothing

            If FixObjectString(Me.DropCustomer.Value) = Nothing Then
                If FixObjectString(Me.DropCustomer.Text) = Nothing Then Exit Sub
                Customer = FixObjectString(Me.DropCustomer.Text)
            Else
                Customer = FixObjectString(Me.DropCustomer.Value)
            End If

            Dim LastMonth As New DateTime(temp.Year, temp.Month, 1, 23, 59, 59)
            LastMonth = LastMonth.AddDays(-1)

            Dim CLS_Temp_Acc As New Account

            CLS_Temp_Acc.Select_Customer(Customer, LastMonth)


            If CLS_Config.MonthBasePayment And temp.Month = Now.Month And temp.Year = Now.Year And CLS_Temp_Acc.Balance > 0 Then

                If FixControl(Me.txtDiscount) > CLS_Temp_Acc.Balance Then
                    MsgBox("Discount amount " & FixControl(Me.txtDiscount) & " should be less then last month balance " & CLS_Temp_Acc.Balance)
                    Exit Sub
                End If

                If CLS_Temp_Acc.Balance >= FixControl(Me.txtPaymentAmount) + FixControl(Me.txtDiscount) Then

                    Dim PARA As New ArrayList

                    PARA.Add(CInt(CLS_ACC.Code))
                    PARA.Add(Decimal.Round(CDec(FixControl(Me.txtPaymentAmount)), 3))
                    PARA.Add(Decimal.Round(CDec(FixControl(Me.txtDiscount)), 3))
                    PARA.Add(UserClass.Code)
                    PARA.Add(CLS_Config.Counter)
                    PARA.Add(CInt(Me.DropPaymentType.Value))
                    PARA.Add(TranType)
                    If CLS_ACC.Code = CLS_Config.AccTempCredit Then
                        PARA.Add(Me.grdBill.ActiveRow.Cells("Code").Value)
                    Else
                        PARA.Add(TranType)
                    End If
                    PARA.Add(FixObjectDate(LastMonth))
                    PARA.Add(FixControl(txtNotes))
                    PARA.Add(FixControl(txtPaymentDate))


                    DBO.ExecuteSP("CustomerPayment", PARA)


                Else


                    Dim PARA As New ArrayList

                    PARA.Add(CInt(CLS_ACC.Code))
                    PARA.Add(Decimal.Round(CDec(CLS_Temp_Acc.Balance - FixControl(Me.txtDiscount)), 3))
                    PARA.Add(Decimal.Round(CDec(FixControl(Me.txtDiscount)), 3))
                    PARA.Add(UserClass.Code)
                    PARA.Add(CLS_Config.Counter)
                    PARA.Add(CInt(Me.DropPaymentType.Value))
                    PARA.Add(TranType)
                    If CLS_ACC.Code = CLS_Config.AccTempCredit Then
                        PARA.Add(Me.grdBill.ActiveRow.Cells("Code").Value)
                    Else
                        PARA.Add(TranType)
                    End If
                    PARA.Add(FixObjectDate(LastMonth))
                    PARA.Add(FixControl(txtNotes))
                    PARA.Add(FixControl(txtPaymentDate))

                    DBO.ExecuteSP("CustomerPayment", PARA)


                    PARA = New ArrayList

                    PARA.Add(CInt(CLS_ACC.Code))
                    PARA.Add(Decimal.Round(CDec(FixControl(Me.txtPaymentAmount) - CLS_Temp_Acc.Balance + FixControl(Me.txtDiscount)), 3))
                    PARA.Add(0)
                    PARA.Add(UserClass.Code)
                    PARA.Add(CLS_Config.Counter)
                    PARA.Add(CInt(Me.DropPaymentType.Value))
                    PARA.Add(TranType)
                    If CLS_ACC.Code = CLS_Config.AccTempCredit Then
                        PARA.Add(Me.grdBill.ActiveRow.Cells("Code").Value)
                    Else
                        PARA.Add(TranType)
                    End If
                    PARA.Add(FixObjectDate(PaymentDate))
                    PARA.Add(FixControl(txtNotes))
                    PARA.Add(FixControl(txtPaymentDate))

                    DBO.ExecuteSP("CustomerPayment", PARA)


                End If







            Else



                Dim PARA As New ArrayList

                PARA.Add(CInt(CLS_ACC.Code))
                PARA.Add(Decimal.Round(CDec(FixControl(Me.txtPaymentAmount)), 3))
                PARA.Add(Decimal.Round(CDec(FixControl(Me.txtDiscount)), 3))
                PARA.Add(UserClass.Code)
                PARA.Add(CLS_Config.Counter)
                PARA.Add(CInt(Me.DropPaymentType.Value))
                PARA.Add(TranType)
                If CLS_ACC.Code = CLS_Config.AccTempCredit Then
                    PARA.Add(Me.grdBill.ActiveRow.Cells("Code").Value)
                Else
                    PARA.Add(TranType)
                End If
                PARA.Add(Now())
                PARA.Add(FixControl(txtNotes))
                PARA.Add(FixControl(txtPaymentDate))

                DBO.ExecuteSP_ReturnInteger("CustomerPayment", PARA)



            End If






            If Not CLS_Config.PrintAtEnd Then
                PrintCreditPay(False)
                If CLS_Config.Company = ZAHRABAKALA Then
                    If MsgBox("Print Copy?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        PrintCreditPay(True)
                    End If

                End If
                BillNumber += 1

            Else
                Dim frm As New frmDialogResult("Do you want to PRINT the Invoice.")
                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                    PrintCreditPay_CR(False)
                End If
            End If

            'If CLS_Config.NewSalesScreen Then
            '    If Not IsNothing(frmSales2Ins) Then
            '        frmSales2Ins.txtBillNo.Text = BillNumber
            '    End If
            'Else
            If Not IsNothing(frmSalesIns) Then
                '''frmSalesIns.txtBillNo.Text = BillNumber
                frmSalesIns.txtDate.Value = Null_Date
                frmSalesIns.txtDate.Value = Now.Date
            End If
            'End If

            Me.Close()

        Catch ex As Exception
            MSG.ErrorOk("[Pay]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Dim PaymentCode As Integer = 0
    Private Sub txtPaymentAmount_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPaymentAmount.KeyDown
        If e.KeyCode = Keys.Enter Then btnPay_Click(sender, e)
    End Sub
    Private Sub txtDiscount_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDiscount.KeyDown
        If e.KeyCode = Keys.Enter Then Me.txtPaymentAmount.Focus()
    End Sub
    Private Sub PrintCreditPay(ByVal Copy As Boolean)
        Try
            Dim str As String = ""
            Select Case CLS_Config.Company
                Case MoveNPick
                    str = "     M & P" & vbCrLf
                    str += "   " & vbCrLf
                Case INDIAGATE
                    str = "     INDIA GATE SUPER MARKET" & vbCrLf
                    str += "   " & vbCrLf
                Case OsmanSM
                    str = "          OSMAN SUPER MARKET" & vbCrLf
                    str += "   " & vbCrLf
                Case EDEE
                    str = "          EDEE SUPER MARKET" & vbCrLf
                    str += "   SALMIYA TEL: 25635962,25653370" & vbCrLf
                Case BOOKSHOP
                    str = "              EDEE BOOK SHOP" & vbCrLf
                    str += "       SALMIYA TEL: 25648815" & vbCrLf
                Case ZAHRABAKALA
                    If Copy Then str += "               DUPLICATE COPY  " & vbCrLf
                    str += "            NOOR AL ZAHRA BAKALA" & vbCrLf
                    str += "              TEL: 224 78 975" & vbCrLf
                    str += "              MOB: 5500 3178" & vbCrLf
                Case CENTURY
                    str = "             CENTURY BAZAAR" & vbCrLf
                    str += "              TEL: 23915844 / 5" & vbCrLf
            End Select
            str += ConvertSize("BILL # " & BillNumber, 11, False) & ConvertSize("POS # " & CLS_Config.Counter, 29, True) & vbCrLf
            str += "            CREDIT PAYMENT              " & vbCrLf
            str += "----------------------------------------" & vbCrLf
            str += ConvertSize("ACC #      " & CLS_ACC.AccountNum.ToUpper, 40, False) & vbCrLf
            str += ConvertSize("CUST NAME: " & CLS_ACC.Title.ToUpper, 40, False) & vbCrLf
            str += ConvertSize("AMT PAID : " & ConvertToString(CDec(Me.txtPaymentAmount.Value), False).ToUpper, 40, False) & vbCrLf
            If FixControl(Me.txtDiscount) > 0 Then
                str += ConvertSize("DISCOUNT : " & ConvertToString(CDec(Me.txtDiscount.Value), False).ToUpper, 40, False) & vbCrLf
            End If
            Dim Balance As Decimal = CDec(FixControl(txtBalance))
            Dim TotalBalance As Decimal = CDec(FixControl(txtTotalBalance))
            Dim PaymentAmount As Decimal = CDec(FixControl(txtPaymentAmount))
            Dim Discount As Decimal = CDec(FixControl(txtDiscount))

            If CLS_Config.MonthBasePayment Then
                str += ConvertSize("MONTH PAID : " & CDate(Me.txtPaymentDate.Value).ToString("MMM-yyyy").ToUpper, 40, False) & vbCrLf
                str += ConvertSize(CDate(Me.txtPaymentDate.Value).ToString("MMM-yyyy").ToUpper & " BALANCE  : " & ConvertToString(Decimal.Round(Balance - PaymentAmount - Discount, 3), False).ToUpper, 40, False) & vbCrLf
                str += ConvertSize("TOTAL BALANCE  : " & ConvertToString(Decimal.Round(TotalBalance - PaymentAmount - Discount, 3), False).ToUpper, 40, False) & vbCrLf
            Else
                str += ConvertSize("TOTAL BALANCE  : " & ConvertToString(Decimal.Round(Balance - PaymentAmount - Discount, 3), False).ToUpper, 40, False) & vbCrLf
            End If
            If FixControl(Me.txtNotes) <> Nothing Then
                str += ConvertSize("NOTES :" & FixControl(Me.txtNotes), 40, False) & vbCrLf
            End If
            str += "----------------------------------------" & vbCrLf
            str += ConvertSize("       CASHIER: " & UserClass.UserName, 30, False) & vbCrLf
            str += ConvertSize("       THANK YOU ! VISIT AGAIN", 30, False) & vbCrLf
            str += ConvertSize("       " & Now.ToString("dd/MMM/yy HH:mm"), 30, False) ' & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf

            Dim pd As New PrintDialog()
            ' Open the printer dialog box, and then allow the user to select a printer.
            pd.PrinterSettings.PrinterName = CLS_Config.ReceiptPrinter
            RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, str)

            If PrintEmptySpaceType = 2 Then
                PrintEmptySpace2()
            Else
                PrintEmptySpace()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub PrintCreditPay_CR(ByVal Copy As Boolean)
        Try
            Dim Balance As Decimal = CDec(FixControl(txtBalance))
            Dim TotalBalance As Decimal = CDec(FixControl(txtTotalBalance))
            Dim PaymentAmount As Decimal = CDec(FixControl(txtPaymentAmount))
            Dim Discount As Decimal = CDec(FixControl(txtDiscount))

            'Select Case CLS_Config.Company
            '    Case ZAHRABAKALA, MoveNPick, EDEE

            '        Dim str As String = ""

            '        str += ConvertSize("BILL # " & BillNumber, 11, False) & ConvertSize("POS # " & CLS_Config.Counter, 29, True) & vbCrLf
            '        str += "            CREDIT PAYMENT              " & vbCrLf
            '        str += "----------------------------------------" & vbCrLf
            '        str += ConvertSize("ACC #      " & CLS_ACC.AccountNum.ToUpper, 40, False) & vbCrLf
            '        str += ConvertSize("CUST NAME: " & CLS_ACC.Title.ToUpper, 40, False) & vbCrLf
            '        str += ConvertSize("AMT PAID : " & ConvertToString(CDec(Me.txtPaymentAmount.Value), False).ToUpper, 40, False) & vbCrLf
            '        If FixControl(Me.txtDiscount) > 0 Then
            '            str += ConvertSize("DISCOUNT : " & ConvertToString(CDec(Me.txtDiscount.Value), False).ToUpper, 40, False) & vbCrLf
            '        End If

            '        If CLS_Config.MonthBasePayment Then
            '            str += ConvertSize("MONTH PAID : " & CDate(Me.txtPaymentDate.Value).ToString("MMM-yyyy").ToUpper, 40, False) & vbCrLf
            '            str += ConvertSize(CDate(Me.txtPaymentDate.Value).ToString("MMM-yyyy").ToUpper & " BALANCE  : " & ConvertToString(Decimal.Round(Balance - PaymentAmount - Discount, 3), False).ToUpper, 40, False) & vbCrLf
            '            str += ConvertSize("TOTAL BALANCE  : " & ConvertToString(Decimal.Round(TotalBalance - PaymentAmount - Discount, 3), False).ToUpper, 40, False) & vbCrLf
            '        Else
            '            str += ConvertSize("TOTAL BALANCE  : " & ConvertToString(Decimal.Round(Balance - PaymentAmount - Discount, 3), False).ToUpper, 40, False) & vbCrLf
            '        End If
            '        If FixControl(Me.txtNotes) <> Nothing Then
            '            str += ConvertSize("NOTES :" & FixControl(Me.txtNotes), 40, False) & vbCrLf
            '        End If
            '        str += "----------------------------------------" & vbCrLf
            '        str += ConvertSize("       CASHIER: " & UserClass.UserName, 30, False) & vbCrLf
            '        str += ConvertSize("       THANK YOU ! VISIT AGAIN", 30, False) & vbCrLf
            '        str += ConvertSize("       " & Now.ToString("dd/MMM/yy HH:mm"), 30, False) ' & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf

            '        Dim pd As New PrintDialog()
            '        ' Open the printer dialog box, and then allow the user to select a printer.
            '        pd.PrinterSettings.PrinterName = CLS_Config.ReceiptPrinter
            '        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, str)
            '        PrintEmptySpace()

            '    Case Else
            Dim report2 As New ReportDocument
            Select Case CLS_Config.Company
                Case ZAHRABAKALA, MoveNPick, EDEE, CENTURY, OsmanSM, INDIAGATE
                    report2.Load(CLS_Config.ReportPath & "Bill Payment Small.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)
                Case Else
                    report2.Load(CLS_Config.ReportPath & "Bill Payment.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)
            End Select

            'report2.SetDataSource(DT)

            report2.SetParameterValue("AccCashCustomer", FixObjectNumber(CLS_Config.AccCashCustomer))
            report2.SetParameterValue("CompanyName", FixObjectString(CLS_Config.CompanyName))
            report2.SetParameterValue("Address1", FixObjectString(CLS_Config.Address1))
            report2.SetParameterValue("Address2", FixObjectString(CLS_Config.Address2))
            report2.SetParameterValue("Address3", FixObjectString(CLS_Config.Address3))
            report2.SetParameterValue("Tel", FixObjectString(CLS_Config.Tel))
            report2.SetParameterValue("AmountInWords", DollarToString(TrimDec(Balance - PaymentAmount - Discount)))
            report2.SetParameterValue("DecimalPlace", FixObjectNumber(CLS_Config.DecimalPlace))
            report2.SetParameterValue("BillNumber", TrimStr(BillNumber))
            report2.SetParameterValue("Counter", TrimStr(CLS_Config.Counter))
            report2.SetParameterValue("AccountNum", TrimStr(CLS_ACC.AccountNum))
            report2.SetParameterValue("AccountName", TrimStr(CLS_ACC.Title))
            report2.SetParameterValue("PaymentAmount", TrimDec(Me.txtPaymentAmount.Value))
            report2.SetParameterValue("Discount", TrimDec(Me.txtDiscount.Value))
            report2.SetParameterValue("NetBalance", TrimDec(Balance - PaymentAmount - Discount))
            report2.SetParameterValue("Notes", TrimStr(txtNotes.Value))
            report2.SetParameterValue("UserName", TrimStr(UserClass.UserName))
            report2.SetParameterValue("PaymentDate", TrimDate(txtPaymentDate.Value))

            report2.PrintOptions.PrinterName = CLS_Config.ReceiptPrinter
            report2.PrintToPrinter(1, False, 1, 2)

            'End Select





        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnPay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPay.Click
        Pay(TransectionType.CustomerPayment)
    End Sub
    Private Sub btnPayCard_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPayCard.Click
        Pay(TransectionType.Customer_Card_Payment)
    End Sub
    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub txtPaymentDate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPaymentDate.Leave

    End Sub

    Private Sub txtPaymentDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPaymentDate.ValueChanged
        Try
            If FixControl(Me.txtPaymentDate) = Null_Date Then
                PaymentDate = Null_Date
            Else
                Dim temp As DateTime = FixControl(Me.txtPaymentDate)
                If temp.Year = Now.Year And temp.Month = Now.Month Then
                    PaymentDate = Now
                Else
                    Dim d As New DateTime(temp.Year, temp.Month, getDaysOfMonth(temp.Year, temp.Month), 23, 59, 59)
                    PaymentDate = d
                End If
            End If

            GetAccountInfo()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GetAccountInfo()
        Try
          
            CLS_ACC = New Account

            If FixObjectDate(PaymentDate) = Null_Date And CLS_Config.MonthBasePayment Then Exit Sub
            Dim Customer As String = Nothing

            If FixObjectString(Me.DropCustomer.Value) = Nothing Then
                If FixObjectString(Me.DropCustomer.Text) = Nothing Then Exit Sub
                Customer = FixObjectString(Me.DropCustomer.Text)
            Else
                Customer = FixObjectString(Me.DropCustomer.Value)
            End If



            If CLS_Config.MonthBasePayment Then
                If Not CLS_ACC.Select_Customer(Customer, PaymentDate) Then Exit Sub
                'If PaymentDate.Year <= 2011 And PaymentDate.Month < 11 Then
                Me.txtBalance.Value = CLS_ACC.Balance
                'Else
                '    Me.txtBalance.Value = CLS_ACC.BalanceCurrentMonth
                'End If
                Me.txtTotalBalance.Value = CLS_ACC.FinalBalance
            Else
                If Not CLS_ACC.Select_Customer(Customer, Null_Date) Then Exit Sub
                Me.txtBalance.Value = CLS_ACC.Balance
            End If

            Me.DropCustomer.Value = CLS_ACC.AccountNum

            If CLS_ACC.Balance = 0 Then
                'Me.txtPaymentDate.Value = New Date(Now.Year, Now.Month, getDaysOfMonth(Now.Year, Now.Month))
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If IsDBNull(Me.grdAccount.ActiveRow) Or IsNothing(Me.grdAccount.ActiveRow) Then
                MsgBox("Select customer payment/discount first.")
                Exit Sub
            End If

            Select Case CType(FixCellNumber(Me.grdAccount.ActiveRow.Cells("TransectionTypeCode")), TransectionType)
                Case TransectionType.CustomerPayment
                    If MsgBox("You are about to delete customer PAYMENT of [" & FixCellNumber(Me.grdAccount.ActiveRow.Cells("Credit")) & "] KD" & vbCrLf & vbCrLf & "Are you sure?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub
                Case TransectionType.Customer_Discount
                    If MsgBox("You are about to delete customer DISCOUNT of [" & FixCellNumber(Me.grdAccount.ActiveRow.Cells("Credit")) & "] KD" & vbCrLf & vbCrLf & "Are you sure?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub
                Case Else
                    MsgBox("Select customer payment/discount transection only.")
                    Exit Sub
            End Select
            'If CType(FixCellNumber(Me.grdAccount.ActiveRow.Cells("TransectionTypeCode")), TransectionType) <> TransectionType.CustomerPayment Then
            '    MsgBox("Select customer payment transection only.")
            '    Exit Sub
            'End If

            DBO.ActionQuery("DELETE FROM Voucher WHERE Code=" & FixCellNumber(Me.grdAccount.ActiveRow.Cells("Code")))

            'AUG 2016 'Fill_Dataset(CLS_ACC.Code)


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnLoadDetails_Click(sender As Object, e As EventArgs) Handles btnLoadDetails.Click
        Fill_Dataset(CLS_ACC.Code)
    End Sub
End Class