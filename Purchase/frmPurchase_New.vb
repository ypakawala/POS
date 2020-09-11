Imports POS.FixControls
Public Class frmPurchase_New
    Dim SupplierCode As Integer
    Dim DT As New DataTable
    Dim CLS_Purchase As New Purchase
    Dim CLS_Purchase_Entry As New Purchase_Entry
    Dim Operation As OperationType = OperationType.Add
    Dim CLS_Item As New Item
    Public Serial_Array As New ArrayList

    Public Sub New(ByVal _SupplierCode As Integer, Optional ByVal _PurchaseCode As Integer = 0)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Try
            SupplierCode = _SupplierCode
            If _PurchaseCode <> 0 Then
                Operation = OperationType.Edit
                CLS_Purchase.Select(_PurchaseCode)

                Me.txtCode.Value = CLS_Purchase.Code
                Me.txtEffectiveDate.Value = CLS_Purchase.EffectiveDate
                Me.txtInvoiceNum.Value = CLS_Purchase.InvoiceNum
                Me.txtAmount.Value = CLS_Purchase.Amount
                Me.txtDebitNote.Value = CLS_Purchase.DebitNote
                Me.txtDiscount.Value = CLS_Purchase.Discount
                Me.txtTotalAmount.Value = CLS_Purchase.TotalAmount
                Me.txtNotes.Value = CLS_Purchase.Notes

                If CLS_Purchase.Posted Then
                    Me.lblTitle.Text = "View Purchase"
                    Me.btnDelete.Visible = False
                    Me.btnSave.Visible = False
                    Me.btnPost.Visible = False
                Else
                    Me.lblTitle.Text = "Edit Purchase"
                End If
            Else
                Me.lblTitle.Text = "New Purchase"
            End If

            DT = CLS_Purchase_Entry.Select(_PurchaseCode)
            Me.grdList.DataSource = DT
            Me.grdList.DataBind()
            SetLayout()

            If Not TrimBoolean(CLS_Config.AddPurchaseDetail) Then
                Me.btnPost.Visible = False
                Me.btnPost.Enabled = False

                Me.btnDelete.Visible = False
                Me.btnDelete.Enabled = False

                Me.btnAdd.Visible = False
                Me.btnAdd.Enabled = False

            End If

        Catch ex As Exception
            MsgBox("New" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub SetLayout()
        Try
            Me.grdList.DisplayLayout.Override.RowAlternateAppearance = RowAlternateAppearance
            Me.grdList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
            'Set Grid's Columns Order (Arrnage) 
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemCode").Header.VisiblePosition = 0
            Me.grdList.DisplayLayout.Bands(0).Columns("Qty").Header.VisiblePosition = 1
            Me.grdList.DisplayLayout.Bands(0).Columns("UnitPrice").Header.VisiblePosition = 2
            Me.grdList.DisplayLayout.Bands(0).Columns("Price").Header.VisiblePosition = 3
            Me.grdList.DisplayLayout.Bands(0).Columns("SalesPrice").Header.VisiblePosition = 4
            Me.grdList.DisplayLayout.Bands(0).Columns("AvgPrice").Header.VisiblePosition = 5
            Me.grdList.DisplayLayout.Bands(0).Columns("ExpiryDate").Header.VisiblePosition = 6
            Me.grdList.DisplayLayout.Bands(0).Columns("SerailNum").Header.VisiblePosition = 7

            '''''''''''''''''''''Cell Activation'''''''''''''''''''''
            Me.grdList.DisplayLayout.Bands(0).Columns("Code").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("PurchaseCode").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemCode").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("Qty").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("QtyStock").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("QtyReturned").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("UnitPrice").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("Price").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("ExpiryDate").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("UMC").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("SalesPrice").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("AvgPrice").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("SerailNum").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            '''''''''''''''''''''Width'''''''''''''''''''''
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemCode").Width = 250


            'Me.grdList.DisplayLayout.Bands(0).Columns("Serial").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("Code").Hidden = True
            Me.grdList.DisplayLayout.Bands(0).Columns("PurchaseCode").Hidden = True
            Me.grdList.DisplayLayout.Bands(0).Columns("QtyStock").Hidden = True
            Me.grdList.DisplayLayout.Bands(0).Columns("QtyReturned").Hidden = True
            Me.grdList.DisplayLayout.Bands(0).Columns("UMC").Hidden = True

            Me.grdList.DisplayLayout.Bands(0).Columns("ItemCode").EditorControl = Me.DropItem

            Me.grdList.DisplayLayout.Bands(0).Columns("Qty").MaskInput = Mask_Qty
            Me.grdList.DisplayLayout.Bands(0).Columns("UnitPrice").MaskInput = Mask_Amount
            Me.grdList.DisplayLayout.Bands(0).Columns("SalesPrice").MaskInput = Mask_Amount
            Me.grdList.DisplayLayout.Bands(0).Columns("Price").MaskInput = Mask_Amount
            Me.grdList.DisplayLayout.Bands(0).Columns("AvgPrice").MaskInput = Mask_Amount
            Me.grdList.DisplayLayout.Bands(0).Columns("ExpiryDate").MaskInput = Mask_Date

        Catch ex As Exception
            MsgBox("SetLayout" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub frmPurchase_New_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        frmPurchase_NewIns = Nothing
    End Sub

    Private Sub frmPurchase_Edit_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, txtAmount.KeyUp, txtCode.KeyUp, txtDebitNote.KeyUp, txtDiscount.KeyUp, txtInvoiceNum.KeyUp, txtNotes.KeyUp, txtTotalAmount.KeyUp, txtEffectiveDate.KeyUp, MenuStrip1.KeyUp, txtQty.KeyUp, txtTotalPrice.KeyUp, DropItem.KeyUp, txtUnitPrice.KeyUp, txtExpiryDate.KeyUp, txtTotalPrice.KeyUp, txtSalesPrice.KeyUp
        'Select Case e.KeyCode
        '    Case Keys.End, Keys.Escape
        '        Me.Close()
        'End Select
    End Sub
    Private Sub frmPurchase_New_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.Cart_Blue
        Try

            txtAmount.MaskInput = Mask_Amount5
            txtDebitNote.MaskInput = Mask_Amount5
            txtDiscount.MaskInput = Mask_Amount5
            txtTotalAmount.MaskInput = Mask_Amount5
            txtTotalPrice.MaskInput = Mask_Amount5
            txtUnitPrice.MaskInput = Mask_Amount5
            txtSalesPrice.MaskInput = Mask_Amount5

            FillDropWithCondition(Me.DropSupplier, "Title", "AccountNum", Table.Account, "Code", , , , " WHERE AccountType = " & AccountType.Supplier)

            If CLS_Config.SearchByBarcode Then
                If CLS_Config.Company = ZAHRABAKALA Then
                    FillDropByQuery(Me.DropItem, "ItemName", "Code", "SELECT Code, COALESCE(BarCode,'') + ' - ' + COALESCE(ItemName,'') AS ItemName,CostPrice,LastPurchaseCost,SalesPrice,BarCode,BarCode2,ItemType FROM ITEM  WHERE (COALESCE(CostPrice, 0) > 0) AND  COALESCE(Discontinued,0)=0  ORDER BY BarCode,ItemName")
                Else
                    FillDropByQuery(Me.DropItem, "ItemName", "Code", "SELECT Code, COALESCE(BarCode,'') + ' - ' + COALESCE(ItemName,'') AS ItemName,CostPrice,LastPurchaseCost,SalesPrice,BarCode,BarCode2,ItemType FROM ITEM WHERE  COALESCE(Discontinued,0)=0  ORDER BY BarCode,ItemName")
                End If

                Me.DropItem.DisplayLayout.Bands(0).Columns("LastPurchaseCost").Hidden = True
                Me.DropItem.DisplayLayout.Bands(0).Columns("CostPrice").Hidden = True
                Me.DropItem.DisplayLayout.Bands(0).Columns("SalesPrice").Hidden = True
                Me.DropItem.DisplayLayout.Bands(0).Columns("BarCode").Hidden = True
                Me.DropItem.DisplayLayout.Bands(0).Columns("BarCode2").Hidden = True
                Me.DropItem.DisplayLayout.Bands(0).Columns("ItemType").Hidden = True

            Else
                If CLS_Config.Company = ZAHRABAKALA Then
                    FillDropByQuery(Me.DropItem, "ItemName", "Code", "SELECT Code, ItemName,CostPrice,LastPurchaseCost,SalesPrice,BarCode,BarCode2,ItemType FROM ITEM  WHERE (COALESCE(CostPrice, 0) > 0) AND  COALESCE(Discontinued,0)=0  ORDER BY ItemName")
                    Me.DropItem.DisplayLayout.Bands(0).Columns("LastPurchaseCost").Hidden = True
                    Me.DropItem.DisplayLayout.Bands(0).Columns("CostPrice").Hidden = True
                    Me.DropItem.DisplayLayout.Bands(0).Columns("SalesPrice").Hidden = True
                    Me.DropItem.DisplayLayout.Bands(0).Columns("BarCode").Hidden = True
                    Me.DropItem.DisplayLayout.Bands(0).Columns("BarCode2").Hidden = True
                    Me.DropItem.DisplayLayout.Bands(0).Columns("ItemType").Hidden = True
                Else
                    'FillDrop(Me.DropItem, "ItemName", "Code", Table.Item, "CostPrice", "LastPurchaseCost", "SalesPrice", "BarCode", "BarCode2", "ItemType")
                    FillDropByQuery(Me.DropItem, "ItemName", "Code", "SELECT Code, ItemName,CostPrice,LastPurchaseCost,SalesPrice,BarCode,BarCode2,ItemType FROM ITEM  WHERE COALESCE(Discontinued,0)=0  ORDER BY ItemName")

                    Me.DropItem.DisplayLayout.Bands(0).Columns("LastPurchaseCost").Hidden = True
                    Me.DropItem.DisplayLayout.Bands(0).Columns("CostPrice").Hidden = True
                    Me.DropItem.DisplayLayout.Bands(0).Columns("SalesPrice").Hidden = True
                    Me.DropItem.DisplayLayout.Bands(0).Columns("BarCode").Hidden = True
                    Me.DropItem.DisplayLayout.Bands(0).Columns("BarCode2").Hidden = True
                    Me.DropItem.DisplayLayout.Bands(0).Columns("ItemType").Hidden = True

                End If
            End If


            If CLS_Config.AddPurchaseDetail Then
                Me.txtAmount.Enabled = False
                Me.txtAmount.TabStop = False
                Me.WindowState = FormWindowState.Maximized
            Else
                Me.pnlItem.Visible = False
            End If

            Me.pnlExp.Visible = False
            Me.txtExpiryDate.Value = Nothing

            If Operation = OperationType.Add Then Me.txtEffectiveDate.Value = Now.Date
            Me.txtEffectiveDate.Focus()
            Me.txtEffectiveDate.SelectAll()
        Catch ex As Exception
            MsgBox("frmPurchase_New_Load" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Function Save(ByVal Posting As Boolean) As Boolean
        Try
            If Not isValid() Then Exit Function

            CLS_Purchase.SupplierCode = SupplierCode
            CLS_Purchase.EffectiveDate = Me.txtEffectiveDate.Value
            CLS_Purchase.InvoiceNum = Me.txtInvoiceNum.Value
            CLS_Purchase.Amount = Me.txtAmount.Value
            CLS_Purchase.DebitNote = Me.txtDebitNote.Value
            CLS_Purchase.Discount = Me.txtDiscount.Value
            CLS_Purchase.TotalAmount = Me.txtTotalAmount.Value
            CLS_Purchase.Notes = Me.txtNotes.Value
            CLS_Purchase.Posted = Posting

            Select Case Operation
                Case OperationType.Add : CLS_Purchase.Code = CLS_Purchase.Add()
                Case OperationType.Edit
                    CLS_Purchase.Code = CInt(FixControl(Me.txtCode))
                    CLS_Purchase.Update()
            End Select

            If CLS_Config.AddPurchaseDetail Then SaveDetails()



            Using CONTEXT = New POSEntities
                Dim P As New Purchase_
                P = (From q In CONTEXT.Purchase_Set Where q.Code = CLS_Purchase.Code Select q).ToList().SingleOrDefault()
                For Each PE In P.Purchase_Entry
                    Dim SUM_Qty As Decimal = 0.0
                    Dim SUM_QtyByUP As Decimal = 0.0
                    Dim PEList As List(Of Purchase_Entry_) = (From q In CONTEXT.Purchase_Entry_Set Where q.ItemCode = PE.ItemCode And q.QtyStock > 0 Order By q.Code Ascending Select q).ToList
                    For Each P_E In PEList
                        SUM_Qty = SUM_Qty + P_E.QtyStock
                        SUM_QtyByUP = SUM_QtyByUP + (P_E.QtyStock * P_E.UnitPrice)
                    Next
                    If SUM_Qty > 0 Then PE.AvgPrice = Decimal.Round(SUM_QtyByUP / SUM_Qty, CLS_Config.DecimalPlace)

                    If Posting Then
                        If TrimDec(PE.AvgPrice) <> 0 Then
                            PE.Item.CostPrice = PE.AvgPrice
                            If PE.Item.SalesPrice <> 0 Then
                                PE.Item.ProfitMargin = (((PE.Item.SalesPrice - PE.Item.CostPrice) * 100) / PE.Item.CostPrice)
                                PE.Item.ProfitMargin = Decimal.Round(CDec(PE.Item.ProfitMargin), CLS_Config.DecimalPlace)
                            End If
                        End If

                    End If

                Next
                CONTEXT.SaveChanges()
            End Using


            Me.Close()

        Catch ex As Exception
            MsgBox("Save" & vbCrLf & ex.Message)
        End Try
    End Function

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Add_Detail()
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If IsDBNull(Me.grdList.ActiveRow) Or IsNothing(Me.grdList.ActiveRow) Then Exit Sub
            Me.DropItem.Value = Me.grdList.ActiveRow.Cells("ItemCode").Value
            Me.txtQty.Value = Me.grdList.ActiveRow.Cells("Qty").Value
            Me.txtTotalPrice.Value = Me.grdList.ActiveRow.Cells("Price").Value
            Me.txtUnitPrice.Value = Me.grdList.ActiveRow.Cells("UnitPrice").Value
            Me.txtSalesPrice.Value = Me.grdList.ActiveRow.Cells("SalesPrice").Value
            Me.txtExpiryDate.Value = Me.grdList.ActiveRow.Cells("ExpiryDate").Value

            Me.grdList.ActiveRow.Delete(False)

            Me.DropItem.Focus()

        Catch ex As Exception
            MsgBox("btnDelete_Click" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If TrimBoolean(CLS_Config.AddPurchaseDetail) Then
                Save(False)
            Else
                Save(True)
            End If

        Catch ex As Exception
            MsgBox("btnSave_Click" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        Save(True)
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Function SaveDetails() As Boolean
        Try
            CLS_Purchase_Entry.PurchaseCode = CLS_Purchase.Code
            CLS_Purchase_Entry.Delete()

            Dim i As Integer = 0
            For i = 0 To Me.grdList.Rows.Count - 1
                CLS_Purchase_Entry.PurchaseCode = CLS_Purchase.Code
                CLS_Purchase_Entry.ItemCode = CInt(Me.grdList.Rows(i).Cells("ItemCode").Value)
                CLS_Purchase_Entry.Qty = CDec(Me.grdList.Rows(i).Cells("Qty").Value)
                CLS_Purchase_Entry.QtyStock = CDec(Me.grdList.Rows(i).Cells("Qty").Value)
                CLS_Purchase_Entry.QtyReturned = 0
                CLS_Purchase_Entry.UnitPrice = CDec(Me.grdList.Rows(i).Cells("UnitPrice").Value)
                CLS_Purchase_Entry.SalesPrice = CDec(Me.grdList.Rows(i).Cells("SalesPrice").Value)
                CLS_Purchase_Entry.Price = CDec(Me.grdList.Rows(i).Cells("Price").Value)
                CLS_Purchase_Entry.ExpiryDate = CDate(FixCellDate(Me.grdList.Rows(i).Cells("ExpiryDate")))
                CLS_Purchase_Entry.SerailNum = FixCellString(Me.grdList.Rows(i).Cells("SerailNum"))

                'If FixCellNumber(Me.grdList.Rows(i).Cells("Code")) = Nothing Then
                CLS_Purchase_Entry.Add()
                'Else
                'CLS_Purchase_Entry.Update()
                'End If

            Next

            Me.grdList.UpdateData()

        Catch ex As Exception
            MsgBox("SaveDetails" & vbCrLf & ex.Message)
        End Try
    End Function
    Private Function Add_Detail() As Boolean
        Try
            If Not isValidDetail() Then Exit Function

            TotalPrice = TrimDec(Me.txtTotalPrice.Value)
            Qty = TrimDec(Me.txtQty.Value)

            Me.grdList.DisplayLayout.Bands(0).AddNew()


            Me.pnlExp.Visible = False
            Me.txtExpiryDate.Value = Nothing

            Me.DropItem.Focus()
            Me.DropItem.Focus()

            Me.DropItem.Value = Nothing
            Me.txtQty.Value = 0
            Me.txtTotalPrice.Value = 0

        Catch ex As Exception
            MsgBox("Add_Detail" & vbCrLf & ex.Message)
        End Try
    End Function
    Private Function isValidDetail() As Boolean
        Try
            If IsDBNull(Me.DropItem.Value) Or IsNothing(Me.DropItem.Value) Then
                Me.DropItem.Focus()
                MsgBox("Invalid item or item missing.")
                Return False
            ElseIf Me.DropItem.Value = Nothing Then
                Me.DropItem.Focus()
                MsgBox("Invalid item or item missing.")
                Return False
            End If

            If IsDBNull(Me.txtQty.Value) Or IsNothing(Me.txtQty.Value) Then
                Me.txtQty.Focus()
                MsgBox("Quantity missing.")
                Return False
            ElseIf Me.txtQty.Value = Nothing Then
                Me.txtQty.Focus()
                MsgBox("Quantity missing.")
                Return False
            End If

            If IsDBNull(Me.txtTotalPrice.Value) Or IsNothing(Me.txtTotalPrice.Value) Then
                Me.txtTotalPrice.Focus()
                MsgBox("Total Price missing.")
                Return False
            ElseIf Me.txtTotalPrice.Value = Nothing Then
                Me.txtTotalPrice.Focus()
                MsgBox("Total Price missing.")
                Return False
            End If

            If IsDBNull(Me.txtUnitPrice.Value) Or IsNothing(Me.txtUnitPrice.Value) Then
                Me.txtUnitPrice.Focus()
                MsgBox("Unit Price missing.")
                Return False
            ElseIf Me.txtUnitPrice.Value = Nothing Then
                Me.txtUnitPrice.Focus()
                MsgBox("Unit Price missing.")
                Return False
            End If

            If Me.txtTotalPrice.Value <> Decimal.Round(CDec(Me.txtUnitPrice.Value) * CDec(Me.txtQty.Value), 3) Then
                'Me.txtTotalPrice.Value = Decimal.Round(CDec(Me.txtUnitPrice.Value) * CDec(Me.txtQty.Value), 3)
                Me.txtUnitPrice.Value = Decimal.Round(CDec(Me.txtTotalPrice.Value) / CDec(Me.txtQty.Value), 3)
            End If

            If IsDBNull(CLS_Item) Or IsNothing(CLS_Item) Then
                Me.DropItem.Focus()
                MsgBox("Invalid item or item missing...")
                Return False
            End If
            If CLS_Item.ItemType = ItemType.ExpireItem Then
                If FixControl(Me.txtExpiryDate) = Null_Date Then
                    Me.txtExpiryDate.Focus()
                    MsgBox("Expiry Date missing.")
                    Return False
                End If
            End If

            'If CLS_Item.ItemType = ItemType.Serail_Item Then
            '    If FixControl(Me.txtSerailNum) = Nothing Then
            '        Me.txtSerailNum.Focus()
            '        MsgBox("Serial # missing.")
            '        Return False
            '    Else
            '        Dim i As Integer = 0
            '        For i = 0 To Me.grdList.Rows.Count - 1
            '            If FixControl(Me.txtSerailNum) = FixCellString(Me.grdList.Rows(i).Cells("SerailNum")) Then
            '                Me.txtSerailNum.Focus()
            '                MsgBox("Serial # inserted.")
            '                Return False
            '            End If
            '        Next

            '        Dim repeat As Integer = DBO.GetSingleValue("SELECT COALESCE(COUNT(*), 0) FROM Purchase_Entry WHERE SerailNum='" & TrimStr(Me.txtSerailNum.Value) & "'")
            '        If repeat > 0 Then
            '            Me.txtSerailNum.Focus()
            '            MsgBox("Serial # already used before.")
            '            Return False
            '        End If
            '    End If
            'End If

            Return True
        Catch ex As Exception
            MsgBox("isValid" & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function isPurchaseInvoiceNumUsed(Code As Integer, InvoiceNum As String) As Boolean
        Try
            Using CONTEXT As New POSEntities()
                Dim _Purchase As New Purchase_
                _Purchase = (From q In CONTEXT.Purchase_Set Where q.Code <> Code AndAlso q.InvoiceNum = InvoiceNum AndAlso q.SupplierCode = SupplierCode Select q).SingleOrDefault

                If Not IsDBNull(_Purchase) AndAlso Not IsNothing(_Purchase) Then Return True
            End Using
            Return False
        Catch ex As Exception
            MsgBox("isPurchaseDocNumUsed" & vbCrLf & vbCrLf & ex.Message)
            If Not IsNothing(ex.InnerException) Then MsgBox(ex.InnerException.Message, MsgBoxStyle.Critical)
        End Try
    End Function
    Private Function isValid() As Boolean
        Try
            If IsDBNull(Me.txtEffectiveDate.Value) Or IsNothing(Me.txtEffectiveDate.Value) Then
                Me.txtEffectiveDate.Focus()
                MsgBox("Effective Date missing.")
                Return False
            ElseIf Me.txtEffectiveDate.Value = Nothing Then
                Me.txtEffectiveDate.Focus()
                MsgBox("Effective Date missing.")
                Return False
            End If

            If FixControl(Me.txtEffectiveDate) > Now.Date Then
                Me.txtEffectiveDate.Focus()
                MsgBox("Effective Date can not be greater than today.")
                Return False
            End If

            If IsDBNull(Me.txtInvoiceNum.Value) Or IsNothing(Me.txtInvoiceNum.Value) Then
                Me.txtInvoiceNum.Focus()
                MsgBox("InvoiceNum Date missing.")
                Return False
            ElseIf Me.txtInvoiceNum.Value = Nothing Then
                Me.txtInvoiceNum.Focus()
                MsgBox("InvoiceNum Date missing.")
                Return False
            End If

            If isPurchaseInvoiceNumUsed(TrimInt(Me.txtCode.Value), TrimStr(Me.txtInvoiceNum.Value)) Then
                Me.txtInvoiceNum.Focus()
                MsgBox("InvoiceNum already in use.")
                Return False
            End If

            If CLS_Config.AddPurchaseDetail Then Me.txtAmount.Value = Get_Grid_Total(Me.grdList, "Price")

            If IsDBNull(Me.txtAmount.Value) Or IsNothing(Me.txtAmount.Value) Then
                Me.txtAmount.Focus()
                MsgBox("Amount Date missing.")
                Return False
            ElseIf Me.txtAmount.Value = Nothing Then
                Me.txtAmount.Focus()
                MsgBox("Amount Date missing.")
                Return False
            End If

            If IsDBNull(Me.txtDebitNote.Value) Or IsNothing(Me.txtDebitNote.Value) Then
                Me.txtDebitNote.Value = 0.0
            ElseIf Me.txtDebitNote.Value = Nothing Then
                Me.txtDebitNote.Value = 0.0
            End If

            If IsDBNull(Me.txtDiscount.Value) Or IsNothing(Me.txtDiscount.Value) Then
                Me.txtDiscount.Value = 0.0
            ElseIf Me.txtDiscount.Value = Nothing Then
                Me.txtDiscount.Value = 0.0
            End If

            Return True
        Catch ex As Exception
            MsgBox("isValid" & vbCrLf & ex.Message)
        End Try
    End Function
    Dim TotalPrice As Decimal = 0.0
    Dim Qty As Decimal = 0.0
    Private Sub txtAmount_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmount.ValueChanged, txtDebitNote.ValueChanged, txtDiscount.ValueChanged
        Try
            If IsDBNull(Me.txtAmount.Value) Or IsNothing(Me.txtAmount.Value) Then
                Me.txtAmount.Value = 0.0
            ElseIf Me.txtAmount.Value = Nothing Then
                Me.txtAmount.Value = 0.0
            End If

            If IsDBNull(Me.txtDebitNote.Value) Or IsNothing(Me.txtDebitNote.Value) Then
                Me.txtDebitNote.Value = 0.0
            ElseIf Me.txtDebitNote.Value = Nothing Then
                Me.txtDebitNote.Value = 0.0
            End If

            If IsDBNull(Me.txtDiscount.Value) Or IsNothing(Me.txtDiscount.Value) Then
                Me.txtDiscount.Value = 0.0
            ElseIf Me.txtDiscount.Value = Nothing Then
                Me.txtDiscount.Value = 0.0
            End If

            Me.txtTotalAmount.Value = Me.txtAmount.Value - Me.txtDebitNote.Value - Me.txtDiscount.Value

        Catch ex As Exception
            MsgBox("txtAmount_ValueChanged" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub txtNotes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNotes.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If CLS_Config.AddPurchaseDetail Then
                    SendKeys.Send("{TAB}")
                Else
                    Me.btnSave_Click(sender, e)
                End If
        End Select
    End Sub
    Private Sub txtTotalPrice_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTotalPrice.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If IsDBNull(CLS_Item) Or IsNothing(CLS_Item) Then Exit Sub
                If FixControl(Me.txtQty) <> Nothing And FixControl(Me.txtTotalPrice) <> Nothing Then
                    Me.txtUnitPrice.Value = Decimal.Round(CDec(Me.txtTotalPrice.Value) / CDec(Me.txtQty.Value), 3)
                End If
                'If CLS_Item.ItemType = ItemType.ExpireItem Then
                '    Me.txtExpiryDate.Focus()
                '    Me.txtExpiryDate.SelectAll()
                'Else
                '    'Add_Detail()
                Me.txtUnitPrice.Focus()
                Me.txtUnitPrice.SelectAll()
                'End If
        End Select
    End Sub
    Private Sub txtUnitPrice_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUnitPrice.KeyDown

        Select Case e.KeyCode
            Case Keys.Enter
                If IsDBNull(CLS_Item) Or IsNothing(CLS_Item) Then Exit Sub
                If FixControl(Me.txtQty) <> Nothing And FixControl(Me.txtUnitPrice) <> Nothing Then
                    If CLS_Config.Company <> ZAHRABAKALA Then
                        Me.txtTotalPrice.Value = Decimal.Round(CDec(Me.txtUnitPrice.Value) * CDec(Me.txtQty.Value), 3)
                    End If
                End If
                Me.txtSalesPrice.Focus()
                Me.txtSalesPrice.SelectAll()
        End Select
    End Sub
    Private Sub txtSalesPrice_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSalesPrice.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If IsDBNull(CLS_Item) Or IsNothing(CLS_Item) Then Exit Sub
                If CLS_Item.ItemType = ItemType.ExpireItem Then
                    Me.txtExpiryDate.Focus()
                    Me.txtExpiryDate.SelectAll()
                ElseIf CLS_Item.ItemType = ItemType.Serail_Item Then
                    If TrimInt(Me.txtQty.Value) = 0 Then Me.txtQty.Value = 1

                    Serial_Array.Clear()
                    Dim frm As New frmSerialAdd(TrimInt(Me.txtQty.Value))
                    If frm.ShowDialog() <> Windows.Forms.DialogResult.Yes Then
                        Exit Sub
                    End If

                    If Not isValidDetail() Then Exit Sub
                  
                    TotalPrice = TrimDec(Me.txtUnitPrice.Value)
                    Qty = 1


                    For i As Integer = 0 To Serial_Array.Count - 1
                        SerailNum = Serial_Array(i)
                        Me.grdList.DisplayLayout.Bands(0).AddNew()
                    Next
                    Serial_Array.Clear()


                    Me.pnlExp.Visible = False
                    Me.txtExpiryDate.Value = Nothing

                    Me.DropItem.Focus()
                    Me.DropItem.Focus()

                    Me.DropItem.Value = Nothing
                    Me.txtQty.Value = 0
                    Me.txtTotalPrice.Value = 0

                Else
                    Add_Detail()
                End If
        End Select
    End Sub
    Private Sub txtQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQty.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If IsDBNull(CLS_Item) Or IsNothing(CLS_Item) Then
                    SendKeys.Send("{TAB}")
                    Exit Sub
                End If
                If FixControl(Me.txtQty) = Nothing Then
                    SendKeys.Send("{TAB}")
                    Exit Sub
                End If
                Me.txtTotalPrice.Value = CLS_Item.LastPurchaseCost * Me.txtQty.Value
                SendKeys.Send("{TAB}")
        End Select
    End Sub
    Private Sub txtExpiryDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtExpiryDate.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Add_Detail()
        End Select
    End Sub
    Private Sub txtTransectionDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEffectiveDate.KeyDown, txtInvoiceNum.KeyDown, txtAmount.KeyDown, txtDebitNote.KeyDown, txtDiscount.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub
    Private Sub DropItem_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DropItem.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then

                If IsDBNull(Me.DropItem.Value) Or IsNothing(Me.DropItem.Value) Then
                ElseIf Me.DropItem.Value = Nothing Then
                Else
                    CLS_Item = New Item
                    CLS_Item = Get_Item(CStr(Me.DropItem.Value))
                    If IsNothing(CLS_Item) Then
                        MsgBox("Item Dose Not Exists")
                        Me.DropItem.Focus()
                    Else
                        Me.DropItem.Value = CLS_Item.Code
                        SendKeys.Send("{TAB}")
                    End If
                    'If ExistsCardID(Me.DropItem.Value) Then
                    '    SendKeys.Send("{TAB}")
                    'Else
                    '    MsgBox("Item Dose Not Exists")
                    '    Me.DropItem.Focus()
                    'End If
                    Exit Sub
                End If


                If IsDBNull(Me.DropItem.Text) Or IsNothing(Me.DropItem.Text) Then
                Else
                    CLS_Item = New Item
                    CLS_Item = Get_Item(CStr(Me.DropItem.Text))
                    'Dim ItemCode As Integer = Nothing
                    'ItemCode = ExistsBarCode(Me.DropItem.Text)
                    If IsNothing(CLS_Item) Then
                        MsgBox("Item Dose Not Exists")
                        Me.DropItem.Focus()
                    Else
                        Me.DropItem.Value = CLS_Item.Code
                        SendKeys.Send("{TAB}")
                    End If

                    'If ItemCode <> Nothing Then Me.DropItem.Value = ItemCode

                End If


            End If
            'If e.KeyCode = Keys.End Then Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtAmount_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmount.GotFocus
        Me.txtAmount.SelectAll()
    End Sub
    Private Sub txtDebitNote_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDebitNote.GotFocus
        Me.txtDebitNote.SelectAll()
    End Sub
    Private Sub txtDiscount_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDiscount.GotFocus
        Me.txtDiscount.SelectAll()
    End Sub
    Private Sub txtQty_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQty.GotFocus
        Me.txtQty.SelectAll()
    End Sub
    Private Sub txtTotalPrice_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTotalPrice.GotFocus
        Me.txtTotalPrice.SelectAll()
    End Sub

    Private Sub DropItem_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropItem.ValueChanged
        Try
            CLS_Item = New Item
            CLS_Item = Get_Item(CStr(Me.DropItem.Value))

            If IsNothing(CLS_Item) Then
                Me.pnlExp.Visible = False
            Else
                Me.txtUnitPrice.Value = Decimal.Round(CDec(CLS_Item.LastPurchaseCost), 3)
                Me.txtSalesPrice.Value = Decimal.Round(CDec(CLS_Item.SalesPrice), 3)

                If CLS_Item.ItemType = ItemType.ExpireItem Then
                    Me.pnlExp.Visible = True
                ElseIf CLS_Item.ItemType = ItemType.Serail_Item Then
                    Me.pnlExp.Visible = False
                    Me.txtQty.Value = 1
                Else
                    Me.pnlExp.Visible = False
                End If

            End If

            'If IsDBNull(Me.DropItem.Value) Or IsNothing(Me.DropItem.Value) Then Exit Sub
            'If Me.DropItem.Value = Nothing Then Exit Sub

            'If IsDBNull(Me.DropItem.SelectedRow.Cells("CostPrice").Value) Or IsNothing(Me.DropItem.SelectedRow.Cells("CostPrice").Value) Then Exit Sub
            'If Me.DropItem.SelectedRow.Cells("CostPrice").Value = Nothing Then Exit Sub

            'Me.txtUnitPrice.Value = CType(Me.DropItem.SelectedRow.Cells("CostPrice").Value, Double)

        Catch ex As Exception
            MsgBox("DropItem_ValueChanged" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub DropItem_EditorButtonClick(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinEditors.EditorButtonEventArgs) Handles DropItem.EditorButtonClick
        Try
            Dim FRM As New frmItem
            FRM.ShowDialog()

            If CLS_Config.SearchByBarcode Then
                FillDropByQuery(Me.DropItem, "ItemName", "Code", "SELECT Code, COALESCE(BarCode,'') + ' - ' + COALESCE(ItemName,'') AS ItemName,CostPrice,LastPurchaseCost,SalesPrice,BarCode,BarCode2,ItemType FROM ITEM ORDER BY BarCode,ItemName")

                Me.DropItem.DisplayLayout.Bands(0).Columns("LastPurchaseCost").Hidden = True
                Me.DropItem.DisplayLayout.Bands(0).Columns("CostPrice").Hidden = True
                Me.DropItem.DisplayLayout.Bands(0).Columns("SalesPrice").Hidden = True
                Me.DropItem.DisplayLayout.Bands(0).Columns("BarCode").Hidden = True
                Me.DropItem.DisplayLayout.Bands(0).Columns("BarCode2").Hidden = True
                Me.DropItem.DisplayLayout.Bands(0).Columns("ItemType").Hidden = True

            Else
                FillDrop(Me.DropItem, "ItemName", "Code", Table.Item, "CostPrice", "LastPurchaseCost", "SalesPrice", "BarCode", "BarCode2", "ItemType")
            End If

        Catch ex As Exception
            MsgBox("DropItem_EditorButtonClick" & vbCrLf & ex.Message)
        End Try
    End Sub
    Dim SerailNum As String
    Private Sub grdList_AfterRowInsert(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles grdList.AfterRowInsert
        Try
            e.Row.Cells("ItemCode").Value = Me.DropItem.Value
            e.Row.Cells("Qty").Value = Qty
            e.Row.Cells("Price").Value = TotalPrice
            e.Row.Cells("UnitPrice").Value = Me.txtUnitPrice.Value
            e.Row.Cells("SalesPrice").Value = Me.txtSalesPrice.Value
            If FixControl(Me.txtExpiryDate) <> Null_Date And CLS_Item.ItemType = ItemType.ExpireItem Then
                e.Row.Cells("ExpiryDate").Value = Me.txtExpiryDate.Value
            End If
            If SerailNum <> Nothing And CLS_Item.ItemType = ItemType.Serail_Item Then
                e.Row.Cells("SerailNum").Value = SerailNum
            End If
            Me.txtAmount.Value = Get_Grid_Total(Me.grdList, "Price")

        Catch ex As Exception
            MsgBox("grdList_AfterRowInsert" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub grdList_AfterRowsDeleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdList.AfterRowsDeleted
        Me.txtAmount.Value = Get_Grid_Total(Me.grdList, "Price")
    End Sub

    Private Function ExistsBarCode(ByRef BarCode As String) As Integer
        Try
            Dim DT As DataTable = Me.DropItem.DataSource
            Dim dr() As DataRow = DT.Select(" BarCode='" & BarCode & "'")
            If dr.Length > 0 Then
                Return IIf(IsDBNull(dr(0).Item("Code")), 0, dr(0).Item("Code"))
            End If
            Return 0
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Private Function ExistsCardID(ByRef BarCode As String) As Integer
        Try
            Dim DT As DataTable = Me.DropItem.DataSource

            Dim dr() As DataRow = DT.Select(" Barcode='" & BarCode & "'")
            If dr.Length > 0 Then
                Return IIf(IsDBNull(dr(0).Item("Code")), 0, dr(0).Item("Code"))
            End If

            Dim dr2() As DataRow = DT.Select(" Barcode2='" & BarCode & "'")
            If dr2.Length > 0 Then
                Return IIf(IsDBNull(dr2(0).Item("Code")), 0, dr2(0).Item("Code"))
            End If

            'IF BARCODE IS NOT INTEGER RETURN EMPTY CLS
            If Not IsNumeric(BarCode) Then Return 0

            Dim dr3() As DataRow = DT.Select(" Code=" & BarCode)
            If dr3.Length > 0 Then
                Return IIf(IsDBNull(dr3(0).Item("Code")), 0, dr3(0).Item("Code"))
            End If

            Return 0

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Private Function Get_Item(ByVal Barcode As String) As Item
        Try
            Dim DT As New DataTable
            DT = Me.DropItem.DataSource

            Dim CLS As New Item
            'IF BARCODE IS NULL RETURN EMPTY CLS
            If FixObjectString(Barcode) = Nothing Then Return Nothing

            'IF BARCODE EXIST IN DS LOAD & RETURN CLS
            Dim dr() As DataRow = DT.Select(" Barcode='" & Barcode & "'")
            If dr.Length > 0 Then
                CLS.Code = IIf(IsDBNull(dr(0).Item("Code")), 0, dr(0).Item("Code"))
                CLS.ItemName = IIf(IsDBNull(dr(0).Item("ItemName")), 0, dr(0).Item("ItemName"))
                CLS.LastPurchaseCost = IIf(IsDBNull(dr(0).Item("LastPurchaseCost")), 0, dr(0).Item("LastPurchaseCost"))
                CLS.CostPrice = IIf(IsDBNull(dr(0).Item("CostPrice")), 0, dr(0).Item("CostPrice"))
                CLS.SalesPrice = IIf(IsDBNull(dr(0).Item("SalesPrice")), 0, dr(0).Item("SalesPrice"))
                CLS.Barcode = IIf(IsDBNull(dr(0).Item("Barcode")), 0, dr(0).Item("Barcode"))
                CLS.Barcode2 = IIf(IsDBNull(dr(0).Item("Barcode2")), 0, dr(0).Item("Barcode2"))
                CLS.ItemType = IIf(IsDBNull(dr(0).Item("ItemType")), ItemType.StandardItem, dr(0).Item("ItemType"))
                Return CLS
            End If
            'IF BARCODE DOSE NOT EXIST CONT...


            'IF BARCODE IS NOT INTEGER SKIP CHECKING BY CODE
            If IsNumeric(Barcode) Then
                'IF CODE IS NUMERIC AND EXIST IN DS LOAD & RETURN CLS
                Dim dr3() As DataRow = DT.Select(" Code=" & Barcode)
                If dr3.Length > 0 Then
                    CLS.Code = IIf(IsDBNull(dr3(0).Item("Code")), 0, dr3(0).Item("Code"))
                    CLS.ItemName = IIf(IsDBNull(dr3(0).Item("ItemName")), 0, dr3(0).Item("ItemName"))
                    CLS.LastPurchaseCost = IIf(IsDBNull(dr3(0).Item("LastPurchaseCost")), 0, dr3(0).Item("LastPurchaseCost"))
                    CLS.CostPrice = IIf(IsDBNull(dr3(0).Item("CostPrice")), 0, dr3(0).Item("CostPrice"))
                    CLS.SalesPrice = IIf(IsDBNull(dr3(0).Item("SalesPrice")), 0, dr3(0).Item("SalesPrice"))
                    CLS.Barcode = IIf(IsDBNull(dr3(0).Item("Barcode")), 0, dr3(0).Item("Barcode"))
                    CLS.Barcode2 = IIf(IsDBNull(dr3(0).Item("Barcode2")), 0, dr3(0).Item("Barcode2"))
                    CLS.ItemType = IIf(IsDBNull(dr3(0).Item("ItemType")), ItemType.StandardItem, dr3(0).Item("ItemType"))
                    Return CLS
                End If
            End If

            'IF BARCODE2 EXIST IN DS LOAD & RETURN CLS
            Dim dr2() As DataRow = DT.Select(" Barcode2='" & Barcode & "'")
            If dr2.Length > 0 Then
                CLS.Code = IIf(IsDBNull(dr2(0).Item("Code")), 0, dr2(0).Item("Code"))
                CLS.ItemName = IIf(IsDBNull(dr2(0).Item("ItemName")), 0, dr2(0).Item("ItemName"))
                CLS.LastPurchaseCost = IIf(IsDBNull(dr2(0).Item("LastPurchaseCost")), 0, dr2(0).Item("LastPurchaseCost"))
                CLS.CostPrice = IIf(IsDBNull(dr2(0).Item("CostPrice")), 0, dr2(0).Item("CostPrice"))
                CLS.SalesPrice = IIf(IsDBNull(dr2(0).Item("SalesPrice")), 0, dr2(0).Item("SalesPrice"))
                CLS.Barcode = IIf(IsDBNull(dr2(0).Item("Barcode")), 0, dr2(0).Item("Barcode"))
                CLS.Barcode2 = IIf(IsDBNull(dr2(0).Item("Barcode2")), 0, dr2(0).Item("Barcode2"))
                CLS.ItemType = IIf(IsDBNull(dr2(0).Item("ItemType")), ItemType.StandardItem, dr2(0).Item("ItemType"))
                Return CLS
            End If

            'IF BARCODE IS NOT CODE RETURN EMPTY CLS
            Return Nothing
        Catch ex As Exception
            MSG.ErrorOk("[Get_Item]" & vbCrLf & ex.Message)
            Return Nothing
        End Try
    End Function

End Class