Imports POS.FixControls
Public Class frmPurchase_Return
    Dim DT As New DataTable
    'Dim CLS_Purchase As New Purchase
    Dim CLS_Purchase_Return As New Purchase_Return
    Dim CLS_Purchase_Return_Entry As New Purchase_Return_Entry
    Dim Operation As OperationType = OperationType.Add
    Dim CLS_Item As New Item
    Public Arr_Added As New ArrayList
    Public Class Purchase_FromDetails
        Public Code As System.Int32
        Public QtyStock As System.Decimal
        Public UnitPrice As System.Decimal
        Public ExpiryDate As System.DateTime
    End Class
    Public CLS As Purchase_FromDetails
    Dim Purchase_Code As Integer = 0
    Public Sub New(ByVal _SupplierCode As Integer, ByVal _Purchase_Code As Integer, Optional ByVal _PurchaseReturnCode As Integer = 0)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Try
            Purchase_Code = _Purchase_Code

            If _PurchaseReturnCode = 0 Then
                CLS_Purchase_Return.SupplierCode = _SupplierCode
                Me.lblTitle.Text = "Purchase Return"
                Operation = OperationType.Add
            Else
                CLS_Purchase_Return.SupplierCode = _SupplierCode
                Operation = OperationType.Edit

                CLS_Purchase_Return.Select(_PurchaseReturnCode)

                Me.txtCode.Value = CLS_Purchase_Return.Code
                Me.txtEffectiveDate.Value = CLS_Purchase_Return.EffectiveDate
                Me.txtInvoiceNum.Value = CLS_Purchase_Return.InvoiceNum
                Me.txtAmount.Value = CLS_Purchase_Return.Amount
                Me.txtNotes.Value = CLS_Purchase_Return.Notes

                Me.lblTitle.Text = "Purchase Return"
                Me.btnPost.Visible = False
                Me.btnPost.Enabled = False
                Me.btnDelete.Visible = False
                Me.btnDelete.Enabled = False

            End If


            Dim CLS As New Purchase_Return_Entry
            DT = CLS.Select(_PurchaseReturnCode)

            Me.grdList.DataSource = DT
            Me.grdList.DataBind()

            SetLayout()

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
            Me.grdList.DisplayLayout.Bands(0).Columns("ExpiryDate").Header.VisiblePosition = 4


            Me.grdList.DisplayLayout.Bands(0).Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False

            Me.grdList.DisplayLayout.Bands(0).Columns("ItemCode").TabStop = False
            Me.grdList.DisplayLayout.Bands(0).Columns("Qty").TabStop = True
            Me.grdList.DisplayLayout.Bands(0).Columns("UnitPrice").TabStop = False
            Me.grdList.DisplayLayout.Bands(0).Columns("Price").TabStop = False
            Me.grdList.DisplayLayout.Bands(0).Columns("ExpiryDate").TabStop = False
            Me.grdList.DisplayLayout.Bands(0).Columns("QtyAvailable").TabStop = False

            Me.grdList.DisplayLayout.Bands(0).Columns("Code").Hidden = True
            'Me.grdList.DisplayLayout.Bands(0).Columns("PurchaseReturnCode").Hidden = True
            'Me.grdList.DisplayLayout.Bands(0).Columns("PurchaseFromCode").Hidden = True

            Me.grdList.DisplayLayout.Bands(0).Columns("ItemCode").EditorControl = Me.DropItem

            Me.grdList.DisplayLayout.Bands(0).Columns("Qty").MaskInput = Mask_Qty
            Me.grdList.DisplayLayout.Bands(0).Columns("UnitPrice").MaskInput = Mask_Amount
            Me.grdList.DisplayLayout.Bands(0).Columns("Price").MaskInput = Mask_Amount
            Me.grdList.DisplayLayout.Bands(0).Columns("ExpiryDate").MaskInput = Mask_Date
            Me.grdList.DisplayLayout.Bands(0).Columns("QtyAvailable").MaskInput = Mask_Qty

        Catch ex As Exception
            MsgBox("SetLayout" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub frmPurchase_Return_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmPurchase_ReturnIns = Nothing
    End Sub
    Private Sub frmPurchase_Return_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.Cart_Blue
        Try
            Me.txtAmount.MaskInput = Mask_Amount5

            If CLS_Config.SearchByBarcode Then
                FillDropByQuery(Me.DropItem, "ItemName", "Code", "SELECT Code, COALESCE(BarCode,'') + ' - ' + COALESCE(ItemName,'') AS ItemName,CostPrice,SalesPrice,BarCode,BarCode2,ItemType FROM ITEM WHERE   code IN ( SELECT    ItemCode FROM      dbo.Purchase_Entry_View WHERE     PurchaseCode = " & Purchase_Code & " ) ORDER BY BarCode,ItemName")
            Else
                FillDropByQuery(Me.DropItem, "ItemName", "Code", "SELECT Code, ItemName,CostPrice,SalesPrice,BarCode,BarCode2,ItemType FROM ITEM WHERE   code IN ( SELECT    ItemCode FROM      dbo.Purchase_Entry_View WHERE     PurchaseCode = " & Purchase_Code & " ) ORDER BY BarCode,ItemName")
            End If

            Me.DropItem.DisplayLayout.Bands(0).Columns("CostPrice").Hidden = True
            Me.DropItem.DisplayLayout.Bands(0).Columns("SalesPrice").Hidden = True
            Me.DropItem.DisplayLayout.Bands(0).Columns("BarCode").Hidden = True
            Me.DropItem.DisplayLayout.Bands(0).Columns("BarCode2").Hidden = True
            Me.DropItem.DisplayLayout.Bands(0).Columns("ItemType").Hidden = True

            Dim CLS As New Purchase

            If TrimBoolean(CLS_Config.AddPurchaseDetail) Then
                Me.txtAmount.Enabled = False
                Me.txtAmount.TabStop = False
            Else
                Me.pnlItem.Visible = False
                Me.WindowState = FormWindowState.Normal
                Me.Width = 350
                Me.StartPosition = FormStartPosition.CenterParent

                Me.btnDelete.Visible = False
                Me.btnDelete.Enabled = False

            End If

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

            CLS_Purchase_Return.TransectionDate = Now.Date
            CLS_Purchase_Return.EffectiveDate = Me.txtEffectiveDate.Value
            CLS_Purchase_Return.TransectionType = TransectionType.Purchase_Return
            CLS_Purchase_Return.InvoiceNum = Me.txtInvoiceNum.Value
            CLS_Purchase_Return.Amount = Me.txtAmount.Value
            CLS_Purchase_Return.Posted = Posting
            CLS_Purchase_Return.UserCode = UserClass.Code
            CLS_Purchase_Return.Notes = Me.txtNotes.Value

            Select Case Operation
                Case OperationType.Add : CLS_Purchase_Return.Code = CLS_Purchase_Return.Add()
                Case OperationType.Edit

                    DBO.ActionQuery("DELETE FROM dbo.Voucher WHERE Code =" & CLS_Purchase_Return.VoucherCode)

                    CLS_Purchase_Return.Code = CInt(FixControl(Me.txtCode))
                    CLS_Purchase_Return.Update()
            End Select

            'If CLS_Config.AddPurchaseDetail Then 
            SaveDetails()
            Me.Close()

        Catch ex As Exception
            MsgBox("Save" & vbCrLf & ex.Message)
        End Try
    End Function
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Save(True)
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
            CLS_Purchase_Return_Entry.PurchaseReturnCode = CLS_Purchase_Return.Code
            CLS_Purchase_Return_Entry.Delete()


            If CLS_Config.AddPurchaseDetail Then
                Dim i As Integer = 0
                For i = 0 To Me.grdList.Rows.Count - 1
                    CLS_Purchase_Return_Entry.PurchaseReturnCode = CLS_Purchase_Return.Code
                    CLS_Purchase_Return_Entry.PurchaseFromCode = FixCellNumber(Me.grdList.Rows(i).Cells("PurchaseFromCode"))
                    CLS_Purchase_Return_Entry.ItemCode = FixCellNumber(Me.grdList.Rows(i).Cells("ItemCode"))
                    CLS_Purchase_Return_Entry.Qty = FixCellNumber(Me.grdList.Rows(i).Cells("Qty"))
                    CLS_Purchase_Return_Entry.UnitPrice = FixCellNumber(Me.grdList.Rows(i).Cells("UnitPrice"))
                    CLS_Purchase_Return_Entry.Price = FixCellNumber(Me.grdList.Rows(i).Cells("Price"))
                    CLS_Purchase_Return_Entry.ExpiryDate = FixCellDate(Me.grdList.Rows(i).Cells("ExpiryDate"))

                    'If FixCellNumber(Me.grdList.Rows(i).Cells("Code")) = Nothing Then
                    CLS_Purchase_Return_Entry.Add()
                    'Else
                    'CLS_Purchase_Entry.Update()
                    'End If

                Next

                Me.grdList.UpdateData()
            Else

                CLS_Purchase_Return_Entry.PurchaseReturnCode = CLS_Purchase_Return.Code
                CLS_Purchase_Return_Entry.PurchaseFromCode = Purchase_Code
                CLS_Purchase_Return_Entry.Price = CLS_Purchase_Return.Amount

                'If FixCellNumber(Me.grdList.Rows(i).Cells("Code")) = Nothing Then
                CLS_Purchase_Return_Entry.Add()

            End If
            

        Catch ex As Exception
            MsgBox("SaveDetails" & vbCrLf & ex.Message)
        End Try
    End Function
    Private Function Add_Detail() As Boolean
        Try
            If Not isValidDetail() Then Exit Function


            Dim Q As Decimal = FixControl(Me.txtQty)
            Do While Q > 0
                CLS = New Purchase_FromDetails

               
                Dim FRM As New frmPurchase_Return_From(CLS_Purchase_Return.SupplierCode, Purchase_Code, Me.DropItem.Value)
                FRM.ShowDialog()
                If IsDBNull(CLS) Or IsNothing(CLS) Then
                ElseIf CLS.Code = 0 Then
                    Exit Do
                Else
                    If Q < CLS.QtyStock Then CLS.QtyStock = Q
                    Me.grdList.DisplayLayout.Bands(0).AddNew()
                    Q -= CLS.QtyStock
                    Q = Decimal.Round(Q, 3)
                    Arr_Added.Add(CLS.Code)
                End If


            Loop

            Me.DropItem.Focus()
            Me.DropItem.Focus()

            Me.DropItem.Value = Nothing
            Me.txtQty.Value = Nothing
            
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

            If IsDBNull(CLS_Item) Or IsNothing(CLS_Item) Then
                Me.DropItem.Focus()
                MsgBox("Invalid item or item missing...")
                Return False
            End If
            
            Return True
        Catch ex As Exception
            MsgBox("isValid" & vbCrLf & ex.Message)
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

            If CLS_Config.AddPurchaseDetail Then Me.txtAmount.Value = Get_Grid_Total(Me.grdList, "Price")

            If IsDBNull(Me.txtAmount.Value) Or IsNothing(Me.txtAmount.Value) Then
                Me.txtAmount.Focus()
                MsgBox("Amount missing.")
                Return False
            ElseIf Me.txtAmount.Value = Nothing Then
                Me.txtAmount.Focus()
                MsgBox("Amount missing.")
                Return False
            End If

            Dim Balance As Decimal = TrimDec(DBO.GetSingleValue("SELECT COALESCE(Balance,0) FROM dbo.Purchase_Summary WHERE Code = " & Purchase_Code))
            If Me.txtAmount.Value > Balance Then
                MsgBox("This invoice can make return for max of [" & ConvertToString(Balance) & " KD ] Only")
                Return False
            End If

            Return True
        Catch ex As Exception
            MsgBox("isValid" & vbCrLf & ex.Message)
        End Try
    End Function

    Private Sub txtAmount_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmount.ValueChanged
        Try
            If IsDBNull(Me.txtAmount.Value) Or IsNothing(Me.txtAmount.Value) Then
                Me.txtAmount.Value = 0.0
            ElseIf Me.txtAmount.Value = Nothing Then
                Me.txtAmount.Value = 0.0
            End If

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
    Private Sub txtQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQty.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If IsDBNull(CLS_Item) Or IsNothing(CLS_Item) Then
                    'SendKeys.Send("{TAB}")
                    Me.DropItem.Focus()
                    Exit Sub
                End If
                If FixControl(Me.txtQty) = Nothing Then
                    'SendKeys.Send("{TAB}")
                    Me.txtQty.SelectAll()
                    Me.txtQty.Focus()
                    Exit Sub
                End If
                Add_Detail()
        End Select
    End Sub
    Private Sub txtTransectionDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEffectiveDate.KeyDown, txtInvoiceNum.KeyDown, txtAmount.KeyDown
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
    Private Sub txtQty_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQty.GotFocus
        Me.txtQty.SelectAll()
    End Sub

    Private Sub DropItem_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropItem.ValueChanged
        Try
            CLS_Item = New Item
            CLS_Item = Get_Item(CStr(Me.DropItem.Value))

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
                FillDropByQuery(Me.DropItem, "ItemName", "Code", "SELECT Code, COALESCE(BarCode,'') + ' - ' + COALESCE(ItemName,'') AS ItemName,CostPrice,SalesPrice,BarCode,BarCode2,ItemType FROM ITEM WHERE   code IN ( SELECT    ItemCode FROM      dbo.Purchase_Entry_View WHERE     SupplierCode = " & CLS_Purchase_Return.SupplierCode & " ) ORDER BY BarCode,ItemName")
            Else
                FillDropByQuery(Me.DropItem, "ItemName", "Code", "SELECT Code, ItemName,CostPrice,SalesPrice,BarCode,BarCode2,ItemType FROM ITEM WHERE   code IN ( SELECT    ItemCode FROM      dbo.Purchase_Entry_View WHERE     SupplierCode = " & CLS_Purchase_Return.SupplierCode & " ) ORDER BY BarCode,ItemName")
            End If

            Me.DropItem.DisplayLayout.Bands(0).Columns("CostPrice").Hidden = True
            Me.DropItem.DisplayLayout.Bands(0).Columns("SalesPrice").Hidden = True
            Me.DropItem.DisplayLayout.Bands(0).Columns("BarCode").Hidden = True
            Me.DropItem.DisplayLayout.Bands(0).Columns("BarCode2").Hidden = True
            Me.DropItem.DisplayLayout.Bands(0).Columns("ItemType").Hidden = True


        Catch ex As Exception
            MsgBox("DropItem_EditorButtonClick" & vbCrLf & ex.Message)
        End Try
    End Sub

    'Private Sub grdList_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdList.AfterCellUpdate
    '    Try
    '        Select Case e.Cell.Column.Key
    '            Case "Qty"
    '                If FixCellNumber(e.Cell) = Nothing Then Exit Sub
    '                e.Cell.Row.Cells("Price").Value = FixCellNumber(e.Cell.Row.Cells("UnitPrice")) * FixCellNumber(e.Cell.Row.Cells("Qty"))
    '            Case "Price"
    '                Me.txtAmount.Value = Get_Grid_Total(Me.grdList, "Price")
    '        End Select
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Private Sub grdList_AfterRowInsert(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles grdList.AfterRowInsert
        Try
            e.Row.Cells("PurchaseFromCode").Value = CLS.Code
            e.Row.Cells("ItemCode").Value = Me.DropItem.Value
            e.Row.Cells("Qty").Value = CLS.QtyStock
            e.Row.Cells("UnitPrice").Value = CLS.UnitPrice
            e.Row.Cells("Price").Value = CLS.QtyStock * CLS.UnitPrice
            e.Row.Cells("ExpiryDate").Value = CLS.ExpiryDate
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


    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If IsDBNull(Me.grdList.ActiveRow) Or IsNothing(Me.grdList.ActiveRow) Then Exit Sub

            Me.grdList.ActiveRow.Delete(False)

            Me.DropItem.Focus()

        Catch ex As Exception
            MsgBox("btnDelete_Click" & vbCrLf & ex.Message)
        End Try
    End Sub

End Class