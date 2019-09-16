Imports POS.FixControls
Public Class frmItemClass
    Dim SupplierCode As Integer
    Dim DT As New DataTable
    'Dim CLS_Purchase As New Purchase
    'Dim CLS_Purchase_Entry As New Purchase_Entry
    Dim Operation As OperationType = OperationType.Add
    Dim CLS_Item As New Item
    Dim CLS_ItemClass As New ItemClass

    Public Sub New(Optional ByVal _ItemClassCode As Integer = 0)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
     
        If _ItemClassCode <> 0 Then
            Operation = OperationType.Edit
            CLS_ItemClass.Select(_ItemClassCode)

            Me.txtCode.Value = CLS_ItemClass.Code
            Me.txtItemName.Value = CLS_ItemClass.ItemName
            Me.txtBarcode.Value = CLS_ItemClass.Barcode
            Me.txtBarcode2.Value = CLS_ItemClass.Barcode2
            Me.txtSalesPrice.Value = CLS_ItemClass.SalesPrice
            Me.DropCategory.Value = IIf(FixObjectNumber(CLS_ItemClass.Category) = 0, Nothing, FixObjectNumber(CLS_ItemClass.Category))
            Me.DropSubCategory.Value = IIf(FixObjectNumber(CLS_ItemClass.SubCategory) = 0, Nothing, FixObjectNumber(CLS_ItemClass.SubCategory))
            Me.txtNotes.Value = CLS_ItemClass.Notes

            Me.lblTitle.Text = "Edit Item Calss"
        Else
            Me.lblTitle.Text = "New Item Class"
        End If

        DT = DBO.ReturnDataTable("SELECT * FROM ItemClassComponent WHERE ItemClassCode = " & _ItemClassCode)
        Me.grdList.DataSource = DT
        Me.grdList.DataBind()
        SetLayout()
    End Sub
    Private Sub SetLayout()
        Try
            Me.grdList.DisplayLayout.Override.RowAlternateAppearance = RowAlternateAppearance
            Me.grdList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
            'Set Grid's Columns Order (Arrnage) 
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemCode").Header.VisiblePosition = 0
            Me.grdList.DisplayLayout.Bands(0).Columns("Quantity").Header.VisiblePosition = 1

            Me.grdList.DisplayLayout.Bands(0).Columns("Code").Hidden = True
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemClassCode").Hidden = True

            Me.grdList.DisplayLayout.Bands(0).Columns("ItemCode").EditorControl = Me.DropItem
            Me.grdList.DisplayLayout.Bands(0).Columns("Quantity").MaskInput = Mask_Qty

            Me.grdList.DisplayLayout.Bands(0).Columns("ItemCode").Width = 350
            Me.grdList.DisplayLayout.Bands(0).Columns("Quantity").Width = 150

            Me.grdList.DisplayLayout.Bands(0).Columns("ItemCode").Header.Caption = "Item"
            Me.grdList.DisplayLayout.Bands(0).Columns("Quantity").Header.Caption = "Quantity"


        Catch ex As Exception
            MsgBox("SetLayout" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub frmItemClass_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            txtSalesPrice.InputMask = Mask_Amount5

            If CLS_Config.SearchByBarcode Then
                If CLS_Config.Company = ZAHRABAKALA Then
                    FillDropByQuery(Me.DropItem, "ItemName", "Code", "SELECT Code, COALESCE(BarCode,'') + ' - ' + COALESCE(ItemName,'') AS ItemName,BarCode,BarCode2 FROM ITEM  WHERE (COALESCE(CostPrice, 0) > 0) ORDER BY BarCode,ItemName")
                Else
                    FillDropByQuery(Me.DropItem, "ItemName", "Code", "SELECT Code, COALESCE(BarCode,'') + ' - ' + COALESCE(ItemName,'') AS ItemName,BarCode,BarCode2 FROM ITEM ORDER BY BarCode,ItemName")
                End If

                Me.DropItem.DisplayLayout.Bands(0).Columns("BarCode").Hidden = True
                Me.DropItem.DisplayLayout.Bands(0).Columns("BarCode2").Hidden = True

            Else
                If CLS_Config.Company = ZAHRABAKALA Then
                    FillDropByQuery(Me.DropItem, "ItemName", "Code", "SELECT Code, ItemName,BarCode,BarCode2 FROM ITEM  WHERE (COALESCE(CostPrice, 0) > 0) ORDER BY ItemName")
                    Me.DropItem.DisplayLayout.Bands(0).Columns("BarCode").Hidden = True
                    Me.DropItem.DisplayLayout.Bands(0).Columns("BarCode2").Hidden = True
                Else
                    FillDrop(Me.DropItem, "ItemName", "Code", Table.Item, "BarCode", "BarCode2")
                End If
            End If

            FillDrop(Me.DropCategory, "Title", "Code", Table.D_ItemCategory)
            FillDrop(Me.DropSubCategory, "Title", "Code", Table.D_ItemSubCategory)


            Me.txtItemName.Focus()
            Me.txtItemName.SelectAll()

        Catch ex As Exception
            MsgBox("frmItemClass_Load" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Function Save() As Boolean
        Try
            If Not isValid() Then Exit Function

            CLS_ItemClass.ItemName = FixControl(Me.txtItemName)
            CLS_ItemClass.Barcode = FixControl(Me.txtBarcode)
            CLS_ItemClass.Barcode2 = FixControl(Me.txtBarcode2)
            CLS_ItemClass.SalesPrice = FixControl(Me.txtSalesPrice)
            CLS_ItemClass.Category = FixControl(Me.DropCategory)
            CLS_ItemClass.SubCategory = FixControl(Me.DropSubCategory)
            CLS_ItemClass.Notes = FixControl(Me.txtNotes)

            Select Case Operation
                Case OperationType.Add : CLS_ItemClass.Add()
                Case OperationType.Edit
                    CLS_ItemClass.Code = CInt(FixControl(Me.txtCode))
                    CLS_ItemClass.Update()
            End Select

            'If CLS_Config.AddPurchaseDetail Then 
            SaveDetails()
            Me.Close()

        Catch ex As Exception
            MsgBox("Save" & vbCrLf & ex.Message)
        End Try
    End Function

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Add_Detail()
    End Sub
    Private Sub btnDeleteItem_Click(sender As Object, e As EventArgs) Handles btnDeleteItem.Click
        Try
            If IsDBNull(Me.grdList.ActiveRow) Or IsNothing(Me.grdList.ActiveRow) Then Exit Sub
            Me.DropItem.Value = Me.grdList.ActiveRow.Cells("ItemCode").Value
            Me.txtQty.Value = Me.grdList.ActiveRow.Cells("Quantity").Value

            Me.grdList.ActiveRow.Delete(False)

            Me.DropItem.Focus()

        Catch ex As Exception
            MsgBox("btnDelete_Click" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If IsNothing(Me.grdList.ActiveRow) Then
                MsgBox("Select Record First")
                Exit Sub
            End If

            If MSG.WarnYesNo("Are you sure you want to delete selected record?", 2) <> MsgBoxResult.Yes Then Exit Sub
            Dim CLS As New ItemClass
            CLS.Code = Me.txtCode.Value
            CLS.Delete()
            MsgBox("Delete successfully")

            Me.Close()
        Catch ex As Exception
            MSG.ErrorOk("[Delete]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Save()
        Catch ex As Exception
            MsgBox("btnSave_Click" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Function SaveDetails() As Boolean
        Try
            DBO.ActionQuery("DELETE FROM ItemClassComponent WHERE ItemClassCode=" & FixObjectNumber(CLS_ItemClass.Code))

            Dim i As Integer = 0
            For i = 0 To Me.grdList.Rows.Count - 1
                Dim PARA As New ArrayList
                PARA.Add(FixObjectNumber(CLS_ItemClass.Code))
                PARA.Add(CInt(Me.grdList.Rows(i).Cells("ItemCode").Value))
                PARA.Add(CDec(Me.grdList.Rows(i).Cells("Quantity").Value))
                DBO.ExecuteSP("ItemClassComponentInsert", PARA)
            Next
            Me.grdList.UpdateData()
        Catch ex As Exception
            MsgBox("SaveDetails" & vbCrLf & ex.Message)
        End Try
    End Function
    Private Function Add_Detail() As Boolean
        Try
            If Not isValidDetail() Then Exit Function

            Me.grdList.DisplayLayout.Bands(0).AddNew()

            Me.DropItem.Focus()
            Me.DropItem.Focus()

            Me.DropItem.Value = Nothing
            Me.txtQty.Value = 0
            
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

            If IsDBNull(CLS_ItemClass) Or IsNothing(CLS_ItemClass) Then
                Me.DropItem.Focus()
                MsgBox("Invalid item or item missing...")
                Return False
            End If
           
            Return True
        Catch ex As Exception
            MsgBox("isValid" & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function isValid() As Boolean
        Try
            If Me.txtItemName.Value = Nothing Then
                MsgBox("Please check if you have given Card Name.")
                Me.txtItemName.Focus()
                Me.txtItemName.SelectAll()
                Return False
            Else
                Dim Item_Code As Integer = CLS_ItemClass.Exists_Name(Me.txtItemName.Value)
                If Item_Code <> Me.txtCode.Value And Item_Code <> 0 Then
                    MsgBox("Name alredy in use")
                    Me.txtItemName.Focus()
                    Me.txtItemName.SelectAll()
                    Return False
                End If
            End If
            If FixControl(Me.txtSalesPrice) = Nothing Then
                MsgBox("Please check if you have given Sales Price.")
                Me.txtSalesPrice.Focus()
                Me.txtSalesPrice.SelectAll()
                Return False
            End If

            If FixControl(Me.DropCategory) = Nothing Then
                MsgBox("Please check if you have given Category.")
                Me.DropCategory.Focus()
                Return False
            End If

            If FixControl(Me.txtBarcode) = Nothing Then
                MsgBox("Please check if you have given Barcode.")
                Me.txtBarcode.Focus()
                Me.txtBarcode.SelectAll()
                Return False
            End If

            If Not CLS_ItemClass.ValidBarcode(Me.txtCode.Value, Me.txtBarcode.Value) Then
                MsgBox("Barcode alredy in use")
                Me.txtBarcode.Focus()
                Me.txtBarcode.SelectAll()
                Return False
            End If

            Return True

        Catch ex As Exception
            MsgBox("[CanSave]" & vbCrLf & ex.Message)
        End Try
    End Function
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
    Private Sub txtItemName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItemName.GotFocus
        Me.txtItemName.SelectAll()
    End Sub
    Private Sub txtSalesPrice_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalesPrice.GotFocus
        Me.txtSalesPrice.SelectAll()
    End Sub
    Private Sub txtBarcode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBarcode.GotFocus
        Me.txtBarcode.SelectAll()
    End Sub
    Private Sub txtBarcode2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBarcode2.GotFocus
        Me.txtBarcode2.SelectAll()
    End Sub
    Private Sub txtNotes_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNotes.GotFocus
        Me.txtNotes.SelectAll()
    End Sub
    Private Sub txtQty_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQty.GotFocus
        Me.txtQty.SelectAll()
    End Sub

    Private Sub DropItem_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropItem.ValueChanged
        Try
            CLS_Item = New Item
            CLS_Item = Get_Item(CStr(Me.DropItem.Value))

        Catch ex As Exception
            MsgBox("DropItem_ValueChanged" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub DropItem_EditorButtonClick(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinEditors.EditorButtonEventArgs) Handles DropItem.EditorButtonClick
        Try
            Dim FRM As New frmItem
            FRM.ShowDialog()

            If CLS_Config.SearchByBarcode Then
                FillDropByQuery(Me.DropItem, "ItemName", "Code", "SELECT Code, COALESCE(BarCode,'') + ' - ' + COALESCE(ItemName,'') AS ItemName,BarCode,BarCode2 FROM ITEM ORDER BY BarCode,ItemName")

                Me.DropItem.DisplayLayout.Bands(0).Columns("BarCode").Hidden = True
                Me.DropItem.DisplayLayout.Bands(0).Columns("BarCode2").Hidden = True

            Else
                FillDrop(Me.DropItem, "ItemName", "Code", Table.Item, "BarCode", "BarCode2")
            End If

        Catch ex As Exception
            MsgBox("DropItem_EditorButtonClick" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub grdList_AfterRowInsert(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles grdList.AfterRowInsert
        Try
            e.Row.Cells("ItemCode").Value = Me.DropItem.Value
            e.Row.Cells("Quantity").Value = Me.txtQty.Value
        Catch ex As Exception
            MsgBox("grdList_AfterRowInsert" & vbCrLf & ex.Message)
        End Try
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
                CLS.Barcode = IIf(IsDBNull(dr(0).Item("Barcode")), 0, dr(0).Item("Barcode"))
                CLS.Barcode2 = IIf(IsDBNull(dr(0).Item("Barcode2")), 0, dr(0).Item("Barcode2"))
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
                    CLS.Barcode = IIf(IsDBNull(dr3(0).Item("Barcode")), 0, dr3(0).Item("Barcode"))
                    CLS.Barcode2 = IIf(IsDBNull(dr3(0).Item("Barcode2")), 0, dr3(0).Item("Barcode2"))
                    Return CLS
                End If
            End If

            'IF BARCODE2 EXIST IN DS LOAD & RETURN CLS
            Dim dr2() As DataRow = DT.Select(" Barcode2='" & Barcode & "'")
            If dr2.Length > 0 Then
                CLS.Code = IIf(IsDBNull(dr2(0).Item("Code")), 0, dr2(0).Item("Code"))
                CLS.ItemName = IIf(IsDBNull(dr2(0).Item("ItemName")), 0, dr2(0).Item("ItemName"))
                CLS.Barcode = IIf(IsDBNull(dr2(0).Item("Barcode")), 0, dr2(0).Item("Barcode"))
                CLS.Barcode2 = IIf(IsDBNull(dr2(0).Item("Barcode2")), 0, dr2(0).Item("Barcode2"))
                Return CLS
            End If

            'IF BARCODE IS NOT CODE RETURN EMPTY CLS
            Return Nothing
        Catch ex As Exception
            MSG.ErrorOk("[Get_Item]" & vbCrLf & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Sub txtItemName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtItemName.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.txtSalesPrice.Focus()
        End Select
    End Sub
    Private Sub txtSalesPrice_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSalesPrice.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.DropCategory.Focus()
        End Select
    End Sub
    Private Sub DropCategory_KeyDown(sender As Object, e As KeyEventArgs) Handles DropCategory.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.DropSubCategory.Focus()
        End Select
    End Sub
    Private Sub DropSubCategory_KeyDown(sender As Object, e As KeyEventArgs) Handles DropSubCategory.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.txtBarcode.Focus()
        End Select
    End Sub
    Private Sub txtBarcode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarcode.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.txtBarcode2.Focus()
        End Select
    End Sub
    Private Sub txtBarcode2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarcode2.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.txtNotes.Focus()
        End Select
    End Sub
    Private Sub txtNotes_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNotes.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.txtQty.Focus()
        End Select
    End Sub
    Private Sub txtQty_KeyDown(sender As Object, e As KeyEventArgs) Handles txtQty.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If IsDBNull(CLS_ItemClass) Or IsNothing(CLS_ItemClass) Then Exit Sub
                Add_Detail()
        End Select
    End Sub

    Private Sub DropCategory_EditorButtonClick(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinEditors.EditorButtonEventArgs) Handles DropCategory.EditorButtonClick
        Try
            Dim Name As String = InputBox("New Category Name", "New Category", Nothing)
            If Name = Nothing Then Exit Sub

            Dim PARA As New ArrayList
            PARA.Add(Name)
            Dim Code As Integer = CInt(DBO.ExecuteSP_ReturnSingleValue("D_ItemCategoryInsert", PARA))

            FillDrop(Me.DropCategory, "Title", "Code", Table.D_ItemCategory)
            Me.DropCategory.Value = Code

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub DropSubCategory_EditorButtonClick(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinEditors.EditorButtonEventArgs) Handles DropSubCategory.EditorButtonClick
        Try
            Dim Name As String = InputBox("New Sub Category Name", "New Sub Category", Nothing)
            If Name = Nothing Then Exit Sub

            Dim PARA As New ArrayList
            PARA.Add(Name)
            Dim Code As Integer = CInt(DBO.ExecuteSP_ReturnSingleValue("D_ItemSubCategoryInsert", PARA))

            FillDrop(Me.DropSubCategory, "Title", "Code", Table.D_ItemSubCategory)
            Me.DropSubCategory.Value = Code

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub DropSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItemName.KeyUp, DropCategory.KeyUp, DropSubCategory.KeyUp, txtSalesPrice.KeyUp, txtBarcode.KeyUp, txtBarcode2.KeyUp, txtNotes.KeyUp
        If e.KeyCode = Keys.End Then btnExit_Click(sender, e)
    End Sub

End Class