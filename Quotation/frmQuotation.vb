Imports CrystalDecisions.CrystalReports.Engine
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmQuotation

    Dim QuotationCode As Integer
    Dim CLS As New Quotation
    Dim CONTEXT As New POSEntities

    Public Sub New(ByVal _QuotationCode As Integer)
        InitializeComponent()
        QuotationCode = _QuotationCode
    End Sub
    Private Sub frmQuotation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.Cart_Blue
        Try
            Me.Text = "Quotation"


            If CLS_Config.SearchByBarcode Then
                FillDropByQuery(Me.DropItem, "ItemName", "Code", "SELECT Code, COALESCE(BarCode,'') + ' - ' + COALESCE(ItemName,'') AS ItemName,CostPrice,BarCode,BarCode2 FROM ITEM ORDER BY BarCode,ItemName")
            Else
                FillDrop(Me.DropItem, "ItemName", "Code", Table.Item, "CostPrice", "BarCode", "BarCode2")
            End If

            FillDrop(Me.DropItem2, "ItemName", "Code", Table.Item, "CostPrice", "BarCode", "BarCode2")
            FillDropWithCondition(Me.DropCustomerCode, "Title", "AccountNum", Table.Account, "Code", , , , " WHERE AccountType = " & AccountType.Customer)
            FillDrop(Me.DropUserCode, "UserName", "Code", Table.P_User)

            LoadData()
            Me.txtTransectionDate.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub LoadData()
        Try

            CLS = New Quotation
            CLS = (From q In CONTEXT.Quotations Where q.Code = QuotationCode Select q).ToList().SingleOrDefault()

            If IsDBNull(CLS) OrElse IsNothing(CLS) Then
                Me.txtTransectionDate.Value = Now.Date
                LoadQuotation_Entry(0)
            Else
                Me.txtCode.Value = CLS.Code
                Me.DropCustomerCode.Value = CLS.Account.AccountNum
                Me.txtTransectionDate.Value = CLS.TransectionDate
                Me.DropUserCode.Value = CLS.UserCode
                Me.txtTotalBill.Value = CLS.TotalBill
                Me.txtDiscount.Value = CLS.Discount
                Me.txtNetBill.Value = CLS.NetBill
                Me.txtRemark.Value = CLS.Remark
                Me.isClosed.Checked = CLS.isClosed

                LoadQuotation_Entry(CLS.Code)

            End If
        Catch ex As Exception
            MsgBox("LoadData" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub Delete()

        If IsDBNull(CLS) Or IsNothing(CLS) Then

        Else

            CONTEXT.SaveChanges()

            CONTEXT.Quotations.DeleteObject(CLS)

        End If


    End Sub
    Private Function isValid() As Boolean
        Try
            If TrimDate(Me.txtTransectionDate.Value) = Null_Date Then
                MsgBox("Date Missing")
                Me.txtTransectionDate.Focus()
                Return False
            End If
            If TrimInt(Me.DropCustomerCode.Value) = Nothing Then
                MsgBox("Customer Missing")
                Me.DropCustomerCode.Focus()
                Return False
            End If
            If Me.grdList.Rows.Count = 0 Then
                MsgBox("Item Missing")
                Me.DropItem.Focus()
                Return False
            End If
            If TrimDec(Me.txtTotalBill.Value) = Nothing Then
                MsgBox("Amount Missing")
                Me.DropItem.Focus()
                Return False
            End If
            Return True
        Catch ex As Exception
            MsgBox("isValid" & vbCrLf & ex.Message)
        End Try
    End Function
    Private Sub FillMissingField()
        Try
            If QuotationCode = 0 Then
                Me.txtCode.Value = GetNewCode("Code", "Quotation")
                Me.DropUserCode.Value = UserClass.Code
            End If
        Catch ex As Exception
            MsgBox("isValid" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If Not isValid() Then Exit Sub
            FillMissingField()

            If IsDBNull(CLS) Or IsNothing(CLS) Then

            Else
                CONTEXT.Quotations.DeleteObject(CLS)

            End If

            CLS = New Quotation

            CLS.Code = Me.txtCode.Value
            CLS.CustomerCode = getValueFromDrop(CType(Me.DropCustomerCode.DataSource, DataTable), "AccountNum", TrimInt(Me.DropCustomerCode.Value), "Code")
            CLS.TransectionDate = TrimDate(Me.txtTransectionDate.Value)
            CLS.UserCode = TrimInt(Me.DropUserCode.Value)
            CLS.CounterCode = CLS_Config.Counter
            CLS.TotalBill = TrimDec(Me.txtTotalBill.Value)
            CLS.Discount = TrimDec(Me.txtDiscount.Value)
            CLS.NetBill = TrimDec(Me.txtNetBill.Value)
            CLS.UserCode = TrimInt(Me.DropUserCode.Value)
            CLS.Remark = TrimStr(Me.txtRemark.Value)
            CLS.isClosed = TrimBoolean(Me.isClosed.Checked)

            Dim Quotation_EntryCode As Integer = GetNewCode("Code", DBTable.Quotation_Entry)
            Dim Row As UltraGridRow
            For Each Row In Me.grdList.Rows
                If Not Row.IsUnmodifiedTemplateAddRow Then
                    Dim _Quotation_Entry As New Quotation_Entry
                    _Quotation_Entry.Code = Quotation_EntryCode
                    _Quotation_Entry.QuotationCode = CLS.Code
                    _Quotation_Entry.ItemCode = TrimInt(Row.Cells("ItemCode").Value)
                    _Quotation_Entry.UnitPrice = TrimDec(Row.Cells("UnitPrice").Value)
                    _Quotation_Entry.Quantity = TrimDec(Row.Cells("Quantity").Value)
                    _Quotation_Entry.TotalPrice = TrimDec(Row.Cells("TotalPrice").Value)

                    CLS.Quotation_Entry.Add(_Quotation_Entry)
                    Quotation_EntryCode = Quotation_EntryCode + 1


                End If
            Next

            CONTEXT.Quotations.AddObject(CLS)
            CONTEXT.SaveChanges()

            MsgBox("Data saved Sucessfully")


        Catch ex As Exception
            MsgBox("btnSave_Click" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If TrimInt(Me.txtCode.Value) = Nothing Then Exit Sub
        If MsgBox("Deleting Quotation. Are you sure?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub
        Delete()
        CONTEXT.SaveChanges()
        Me.Close()

    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        LoadData()
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub txtTransectionDate_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTransectionDate.KeyDown
        If e.KeyCode = Keys.Enter Then Me.DropCustomerCode.Focus()
    End Sub

    Private Sub DropCustomerCode_EditorButtonClick(sender As Object, e As UltraWinEditors.EditorButtonEventArgs) Handles DropCustomerCode.EditorButtonClick
        Try
            Dim FRM As New frmDynamicList
            FRM.MdiParent = Me.MdiParent
            FRM.TableName = Table.Account
            FRM.AccountType = AccountType.Customer
            FRM.ShowDialog()
            FillDropWithCondition(Me.DropCustomerCode, "Title", "AccountNum", Table.Account, "Code", , , , " WHERE AccountType = " & AccountType.Customer)
            CONTEXT.Refresh(Objects.RefreshMode.StoreWins, CONTEXT.Account_Set)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub DropItem_EditorButtonClick(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinEditors.EditorButtonEventArgs) Handles DropItem.EditorButtonClick
        Try
            Dim FRM As New frmItem
            FRM.ShowDialog()

            If CLS_Config.SearchByBarcode Then
                FillDropByQuery(Me.DropItem, "ItemName", "Code", "SELECT Code, COALESCE(BarCode,'') + ' - ' + COALESCE(ItemName,'') AS ItemName,CostPrice,BarCode,BarCode2 FROM ITEM ORDER BY BarCode,ItemName")
            Else
                FillDrop(Me.DropItem, "ItemName", "Code", Table.Item, "CostPrice", "BarCode", "BarCode2")
            End If
            CONTEXT.Refresh(Objects.RefreshMode.StoreWins, CONTEXT.Item_Set)

            FillDrop(Me.DropItem2, "ItemName", "Code", Table.Item, "CostPrice", "BarCode", "BarCode2")

        Catch ex As Exception
            MsgBox("DropItem_EditorButtonClick" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub DropCustomerCode_KeyDown(sender As Object, e As KeyEventArgs) Handles DropCustomerCode.KeyDown
        If e.KeyCode = Keys.Enter Then Me.txtDiscount.Focus()
    End Sub
    Private Sub txtDiscount_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDiscount.KeyDown
        If e.KeyCode = Keys.Enter Then Me.txtRemark.Focus()
    End Sub
    Private Sub txtRemark_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRemark.KeyDown
        If e.KeyCode = Keys.Enter Then Me.DropItem.Focus()
    End Sub
    Private Sub DropItem_KeyDown(sender As Object, e As KeyEventArgs) Handles DropItem.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    Me.txtQuantity.Focus()
        'End If
        Try
            If e.KeyCode = Keys.Enter Then

                If TrimStr(Me.DropItem.Value) = Nothing Then
                Else
                    CLS_Item = New Item_
                    CLS_Item = Get_Item(CStr(Me.DropItem.Value))
                    If IsNothing(CLS_Item) Then
                        MsgBox("Item Dose Not Exists")
                        Me.DropItem.Focus()
                    Else
                        Me.DropItem.Value = CLS_Item.Code
                        Me.txtQuantity.Focus()
                    End If
                    'If ExistsCardID(Me.DropItem.Value) Then
                    '    SendKeys.Send("{TAB}")
                    'Else
                    '    MsgBox("Item Dose Not Exists")
                    '    Me.DropItem.Focus()
                    'End If
                    Exit Sub
                End If


                If TrimStr(Me.DropItem.Text) = Nothing Then
                Else
                    CLS_Item = New Item_
                    CLS_Item = Get_Item(CStr(Me.DropItem.Text))
                    'Dim ItemCode As Integer = Nothing
                    'ItemCode = ExistsBarCode(Me.DropItem.Text)
                    If IsNothing(CLS_Item) Then
                        MsgBox("Item Dose Not Exists")
                        Me.DropItem.Focus()
                    Else
                        Me.DropItem.Value = CLS_Item.Code
                        Me.txtQuantity.Focus()
                    End If

                    'If ItemCode <> Nothing Then Me.DropItem.Value = ItemCode

                End If


            End If
            'If e.KeyCode = Keys.End Then Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub txtQuantity_KeyDown(sender As Object, e As KeyEventArgs) Handles txtQuantity.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtTotalPrice.Focus()
        End If
    End Sub
    Private Sub txtTotalPrice_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTotalPrice.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    Me.txtUnitPrice.Focus()
        'End If

        Select Case e.KeyCode
            Case Keys.Enter
                If IsDBNull(CLS_Item) Or IsNothing(CLS_Item) Then Exit Sub
                If TrimDec(Me.txtQuantity.Value) <> Nothing And TrimDec(Me.txtTotalPrice.Value) <> Nothing Then
                    Me.txtUnitPrice.Value = Decimal.Round(CDec(Me.txtTotalPrice.Value) / CDec(Me.txtQuantity.Value), 3)
                End If
                Me.txtUnitPrice.Focus()
                Me.txtUnitPrice.SelectAll()
                'End If
        End Select

    End Sub
    Private Sub txtCostPrice_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUnitPrice.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    Me.btnAddRaw.Focus()
        'End If

        Select Case e.KeyCode
            Case Keys.Enter
                If IsDBNull(CLS_Item) Or IsNothing(CLS_Item) Then Exit Sub
                If TrimDec(Me.txtQuantity.Value) <> Nothing And TrimDec(Me.txtUnitPrice.Value) <> Nothing Then
                    Me.txtTotalPrice.Value = Decimal.Round(CDec(Me.txtUnitPrice.Value) * CDec(Me.txtQuantity.Value), 3)
                End If
                Me.btnAddItem.Focus()
        End Select

    End Sub

    Dim CLS_Item As New Item_
    Private Sub DropItem_ValueChanged(sender As Object, e As EventArgs) Handles DropItem.ValueChanged
        Try
            If TrimInt(Me.DropItem.Value) = Nothing Then
                CLS_Item = Nothing
                Exit Sub
            End If
            Dim ItemCode As Integer = Me.DropItem.Value
            CLS_Item = New Item_

            Using CTX As New POSEntities
                CLS_Item = (From q In CTX.Item_Set Where q.Code = ItemCode Select q).ToList.FirstOrDefault
            End Using

            Me.txtUnitPrice.Value = TrimDec(CLS_Item.CostPrice)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub txtQty_ValueChanged(sender As Object, e As EventArgs) Handles txtQuantity.ValueChanged
        Me.txtTotalPrice.Value = Decimal.Round(CDec(TrimDec(Me.txtUnitPrice.Value) * TrimDec(Me.txtQuantity.Value)), 3)
    End Sub
    Private Sub txtTotalBill_ValueChanged(sender As Object, e As EventArgs) Handles txtTotalBill.ValueChanged, txtDiscount.ValueChanged
        Me.txtNetBill.Value = TrimDec(Me.txtTotalBill.Value) - TrimDec(Me.txtDiscount.Value)
    End Sub
    Private Sub btnAddItem_Click(sender As Object, e As EventArgs) Handles btnAddItem.Click
        Me.txtTotalPrice.Value = Decimal.Round(CDec(TrimDec(Me.txtUnitPrice.Value) * TrimDec(Me.txtQuantity.Value)), 3)
        If Not isValidDetail() Then Exit Sub

        Me.grdList.DisplayLayout.Bands(0).AddNew()

        Me.DropItem.Focus()
        Me.DropItem.Focus()

        Me.DropItem.Value = Nothing
        Me.txtQuantity.Value = 0.0
        Me.txtTotalPrice.Value = 0.0
        Me.txtUnitPrice.Value = 0.0

    End Sub

    Private Function Get_Item(ByVal Barcode As String) As Item_
        Try
            Dim CLS As New Item_
            'IF BARCODE IS NULL RETURN EMPTY CLS
            If TrimStr(Barcode) = Nothing Then Return Nothing

            'IF BARCODE EXIST IN DS LOAD & RETURN CLS
            CLS = New Item_
            Using CTX As New POSEntities
                CLS = (From q In CTX.Item_Set Where q.Barcode = Barcode Select q).ToList().SingleOrDefault()
            End Using
            If Not IsDBNull(CLS) AndAlso Not IsNothing(CLS) Then Return CLS

            'IF BARCODE DOSE NOT EXIST CONT...


            'IF BARCODE IS NOT INTEGER SKIP CHECKING BY CODE
            If IsNumeric(Barcode) Then
                'IF CODE IS NUMERIC AND EXIST IN DS LOAD & RETURN CLS
                CLS = New Item_
                Using CTX As New POSEntities
                    CLS = (From q In CTX.Item_Set Where q.Code = Barcode Select q).ToList().SingleOrDefault()
                End Using
                If Not IsDBNull(CLS) AndAlso Not IsNothing(CLS) Then Return CLS

            End If

            'IF BARCODE2 EXIST IN DS LOAD & RETURN CLS
            CLS = New Item_
            Using CTX As New POSEntities
                CLS = (From q In CTX.Item_Set Where q.Barcode2 = Barcode Select q).ToList().SingleOrDefault()
            End Using
            If Not IsDBNull(CLS) AndAlso Not IsNothing(CLS) Then Return CLS

            'IF BARCODE IS NOT CODE RETURN EMPTY CLS
            Return Nothing
        Catch ex As Exception
            MSG.ErrorOk("[Get_Item]" & vbCrLf & ex.Message)
            Return Nothing
        End Try
    End Function
    Private Function isValidDetail() As Boolean
        Try
            If TrimInt(Me.DropItem.Value) = Nothing Then
                Me.DropItem.Focus()
                MsgBox("Invalid Raw.")
                Return False
            End If

            If TrimDec(Me.txtQuantity.Value) = Nothing Then
                Me.txtQuantity.Focus()
                MsgBox("Quantity missing.")
                Return False
            End If

            If TrimDec(Me.txtTotalPrice.Value) = Nothing Then
                Me.txtTotalPrice.Focus()
                MsgBox("Total Price missing.")
                Return False
            End If

            If TrimDec(Me.txtUnitPrice.Value) = Nothing Then
                Me.txtUnitPrice.Focus()
                MsgBox("UniPrice missing.")
                Return False
            End If



            If Me.txtTotalPrice.Value <> Decimal.Round(CDec(Me.txtUnitPrice.Value) * CDec(Me.txtQuantity.Value), 3) Then
                Me.txtUnitPrice.Value = Decimal.Round(CDec(Me.txtTotalPrice.Value) / CDec(Me.txtQuantity.Value), 3)
            End If

            Return True
        Catch ex As Exception
            MsgBox("isValidDetail" & vbCrLf & ex.Message)
        End Try
    End Function
    Private Sub LoadQuotation_Entry(ByVal QuotationCode As Integer)
        Try

            'Me.grdList.DataSource = (From q In CONTEXT.PurchaseEntries Where q.QuotationCode = QuotationCode).ToList
            'Dim DT As New DataTable
            Using CTX As New POSEntities
                Me.grdList.DataSource = (From q In CTX.Quotation_Entry Where q.QuotationCode = QuotationCode)
            End Using

            Me.grdList.DisplayLayout.Override.RowAlternateAppearance = RowAlternateAppearance

            'DT = DBO.ReturnDataTableFromSQL("SELECT * FROM Quotation_Entry WHERE QuotationCode = " & QuotationCode)
            'Me.grdList.DataSource = DT

            Me.grdList.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes
            Me.grdList.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True
            Me.grdList.DisplayLayout.Override.AllowDelete = DefaultableBoolean.True

            Me.grdList.DisplayLayout.Override.SelectTypeRow = SelectType.Single
            Me.grdList.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle


            '''''''''''''''''''''CAPTION'''''''''''''''''''''
            Me.grdList.DisplayLayout.Bands(0).Columns("Code").Header.Caption = "Code"
            Me.grdList.DisplayLayout.Bands(0).Columns("QuotationCode").Header.Caption = "QuotationCode"
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemCode").Header.Caption = "ItemCode"
            Me.grdList.DisplayLayout.Bands(0).Columns("Quantity").Header.Caption = "Quantity"
            Me.grdList.DisplayLayout.Bands(0).Columns("UnitPrice").Header.Caption = "UnitPrice"
            Me.grdList.DisplayLayout.Bands(0).Columns("TotalPrice").Header.Caption = "TotalPrice"
            '''''''''''''''''''''VISIBLE POSITION'''''''''''''''''''''
            Me.grdList.DisplayLayout.Bands(0).Columns("Code").Header.VisiblePosition = 0
            Me.grdList.DisplayLayout.Bands(0).Columns("QuotationCode").Header.VisiblePosition = 1
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemCode").Header.VisiblePosition = 2
            Me.grdList.DisplayLayout.Bands(0).Columns("Quantity").Header.VisiblePosition = 3
            Me.grdList.DisplayLayout.Bands(0).Columns("UnitPrice").Header.VisiblePosition = 5
            Me.grdList.DisplayLayout.Bands(0).Columns("TotalPrice").Header.VisiblePosition = 6
            '''''''''''''''''''''HIDDEN'''''''''''''''''''''
            Me.grdList.DisplayLayout.Bands(0).Columns("Code").Hidden = True
            Me.grdList.DisplayLayout.Bands(0).Columns("QuotationCode").Hidden = True
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemCode").Hidden = False
            Me.grdList.DisplayLayout.Bands(0).Columns("Quantity").Hidden = False
            Me.grdList.DisplayLayout.Bands(0).Columns("UnitPrice").Hidden = False
            Me.grdList.DisplayLayout.Bands(0).Columns("TotalPrice").Hidden = False
            Me.grdList.DisplayLayout.Bands(0).Columns("Item").Hidden = True
            Me.grdList.DisplayLayout.Bands(0).Columns("Quotation").Hidden = True
            '''''''''''''''''''''MASK INPUT'''''''''''''''''''''
            Me.grdList.DisplayLayout.Bands(0).Columns("Quantity").MaskInput = "{LOC}-nnnnn.nnnnn"
            Me.grdList.DisplayLayout.Bands(0).Columns("UnitPrice").MaskInput = "{LOC}-nnnnn.nnn"
            Me.grdList.DisplayLayout.Bands(0).Columns("TotalPrice").MaskInput = "{LOC}-nnnnn.nnn"
            '''''''''''''''''''''Perform Auto Resize'''''''''''''''''''''
            Me.grdList.DisplayLayout.Bands(0).Columns("Code").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("QuotationCode").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemCode").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("Quantity").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("UnitPrice").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("TotalPrice").PerformAutoResize()
            '''''''''''''''''''''Cell Activation'''''''''''''''''''''
            Me.grdList.DisplayLayout.Bands(0).Columns("Code").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("QuotationCode").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemCode").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("Quantity").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("UnitPrice").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("TotalPrice").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            '''''''''''''''''''''Tab Stop'''''''''''''''''''''
            Me.grdList.DisplayLayout.Bands(0).Columns("Code").TabStop = True
            Me.grdList.DisplayLayout.Bands(0).Columns("QuotationCode").TabStop = True
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemCode").TabStop = True
            Me.grdList.DisplayLayout.Bands(0).Columns("Quantity").TabStop = True
            Me.grdList.DisplayLayout.Bands(0).Columns("UnitPrice").TabStop = True
            Me.grdList.DisplayLayout.Bands(0).Columns("TotalPrice").TabStop = True
            '''''''''''''''''''''Tab Index'''''''''''''''''''''
            Me.grdList.DisplayLayout.Bands(0).Columns("Code").TabIndex = 0
            Me.grdList.DisplayLayout.Bands(0).Columns("QuotationCode").TabIndex = 1
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemCode").TabIndex = 2
            Me.grdList.DisplayLayout.Bands(0).Columns("Quantity").TabIndex = 3
            Me.grdList.DisplayLayout.Bands(0).Columns("UnitPrice").TabIndex = 5
            Me.grdList.DisplayLayout.Bands(0).Columns("TotalPrice").TabIndex = 6
            '''''''''''''''''''''Width'''''''''''''''''''''
            'Me.grdList.DisplayLayout.Bands(0).Columns("Code").Width = 50
            'Me.grdList.DisplayLayout.Bands(0).Columns("QuotationCode").Width = 250
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemCode").Width = 250
            Me.grdList.DisplayLayout.Bands(0).Columns("Quantity").Width = 100
            Me.grdList.DisplayLayout.Bands(0).Columns("UnitPrice").Width = 100
            Me.grdList.DisplayLayout.Bands(0).Columns("TotalPrice").Width = 100


        Catch ex As Exception
            MsgBox("SetGrdLayout" & vbCrLf & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub grdList_AfterRowInsert(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles grdList.AfterRowInsert
        Try
            e.Row.Cells("Code").Value = 0
            e.Row.Cells("QuotationCode").Value = QuotationCode
            e.Row.Cells("ItemCode").Value = TrimInt(Me.DropItem.Value)
            e.Row.Cells("Quantity").Value = TrimDec(Me.txtQuantity.Value)
            e.Row.Cells("UnitPrice").Value = TrimDec(Me.txtUnitPrice.Value)
            e.Row.Cells("TotalPrice").Value = TrimDec(Me.txtTotalPrice.Value)
            Me.txtTotalBill.Value = Get_Grid_Total(Me.grdList, "TotalPrice")
        Catch ex As Exception
            MsgBox("grdList_AfterRowInsert" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub grdList_AfterRowsDeleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdList.AfterRowsDeleted
        Me.txtTotalBill.Value = Get_Grid_Total(Me.grdList, "TotalPrice")

        DeleteCode = 0
    End Sub
    Dim DeleteCode As Integer = 0
    Private Sub grdList_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdList.BeforeRowsDeleted
        DeleteCode = TrimInt(e.Rows(0).Cells("Code").Value)
    End Sub
    Private Sub grdList_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdList.InitializeLayout
        ' Set the RowSelectorNumberStyle to enable the row-numbers.
        e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex

        ' You can control the appearance of the row numbers using the RowSelectorAppearance.
        e.Layout.Override.RowSelectorAppearance.ForeColor = Color.Black
        e.Layout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.False

        ' You can explicitly set the width of the row selectors if the default one calculated
        ' by the UltraGrid is not enough.
        e.Layout.Override.RowSelectorWidth = 40
        Me.grdList.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True

        e.Layout.Bands(0).Columns("ItemCode").EditorControl = Me.DropItem2

    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            If TrimInt(Me.txtCode.Value) = Nothing Then Exit Sub

            Dim DT As New DataTable
            DT.Clear()
            Dim Query As String = "SELECT  * FROM Quotation_Entry_View WHERE (Code=" & TrimInt(Me.txtCode.Value) & ")"
            DT = DBO.ReturnDataTableFromSQL(Query)

            Dim report2 As New ReportDocument
            report2.Load(CLS_Config.ReportPath & "Quotation.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)
            report2.SetDataSource(DT)

            report2.SetParameterValue("AccCashCustomer", TrimStr(CLS_Config.AccCashCustomer))
            report2.SetParameterValue("CompanyName", TrimStr(CLS_Config.CompanyName))
            report2.SetParameterValue("Address1", TrimStr(CLS_Config.Address1))
            report2.SetParameterValue("Address2", TrimStr(CLS_Config.Address2))
            report2.SetParameterValue("Address3", TrimStr(CLS_Config.Address3))
            report2.SetParameterValue("Tel", TrimStr(CLS_Config.Tel))
            report2.SetParameterValue("AmountInWords", DollarToString(DT.Rows(0).Item("NetBill")))

            report2.PrintOptions.PrinterName = CLS_Config.ReceiptPrinter
            report2.PrintToPrinter(1, False, 1, 2)


            'Dim Code As Integer = TrimInt(Me.txtCode.Value)
            'Dim frm As New frmReport(Resx.Purchase & " " & Resx.Report)
            'frm.ReportDataSource1 = New ReportDataSource("DataSet1", (From s In CONTEXT.V_PurchaseReport Where s.QuotationCode = Code Select s))
            'frm.ReportPath = RPTPath & "Purchase Invoice.rdlc"
            'frm.ShowDialog()


        Catch ex As Exception
            MsgBox("btnPrint_Click" & vbCrLf & ex.Message)
        End Try
    End Sub


End Class