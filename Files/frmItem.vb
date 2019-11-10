Imports POS.FixControls
Imports System.Drawing.Printing
Imports System.IO

Public Class frmItem
    Implements IDataEntry
#Region "Member Variables"
    Private m_tableName As String = Table.Item
    Private DT As New DataTable
    Private DTOriginal As New DataTable
    Private m_modi As Boolean = False
    Protected m_canOpen As Boolean = False
    Private ItemCode As Integer = 0
    Dim CLS_Item As New Item
#End Region
#Region "Properties"
    Public Property tblName() As String Implements IDataEntry.tblName
        Get
            Return m_tableName
        End Get
        Set(ByVal value As String)
            m_tableName = value
        End Set
    End Property
    Public Property Modi() As Boolean Implements IDataEntry.Modi
        Get
            Return m_modi
        End Get
        Set(ByVal value As Boolean)
            m_modi = value
        End Set
    End Property
#End Region
#Region "Methods"
    Public Function Add() As Boolean Implements IDataEntry.Add
        Try
            Dim PARA As New ArrayList

            PARA.Add(FixControl(Me.txtCode))
            PARA.Add(FixControl(Me.txtItemName))
            PARA.Add(FixControl(Me.DropCategory))
            PARA.Add(FixControl(Me.DropSubCategory))
            PARA.Add(FixControl(Me.txtCostPrice))
            PARA.Add(FixControl(Me.txtProfitMargin))
            PARA.Add(FixControl(Me.txtSalesPrice))
            PARA.Add(FixControl(Me.txtBarcode))
            PARA.Add(FixControl(Me.txtBarcode2))
            PARA.Add(FixControl(Me.txtStockInHand))
            PARA.Add(FixControl(Me.txtStockInStore))
            PARA.Add(FixControl(Me.txtStockMin))
            PARA.Add(FixControl(Me.DropItemType))
            PARA.Add(FixControl(Me.txtNotes))
            PARA.Add(FixControl(Me.DropUMC))
            PARA.Add(FixControl(Me.DropCostMethod))
            PARA.Add(FixControl(Me.chkDiscontinued))
            PARA.Add(FixControl(Me.chkOnPromo))
            PARA.Add(FixControl(Me.txtPromoFrom))

            If TrimDate(Me.txtPromoTo.Value) <> Null_Date Then
                Dim pt As DateTime = TrimDate(Me.txtPromoTo.Value)
                Dim PromoTo As New DateTime(pt.Year, pt.Month, pt.Day, 23, 59, 59)
                PARA.Add(PromoTo)
            Else
                PARA.Add(FixControl(Me.txtPromoTo))
            End If

            PARA.Add(FixControl(Me.txtPromoPrice))
            PARA.Add(FixControl(Me.txtPromoStockLimit))
            PARA.Add(FixControl(Me.txtPromoStockSold))

            DBO.ExecuteSP("ItemInsert", PARA)

            Return True
        Catch ex As Exception
            MsgBox("[Add]" & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function Adding() As Boolean Implements IDataEntry.Adding

    End Function
    Public Function CanSave() As Boolean Implements IDataEntry.CanSave
        Try
            If Me.txtItemName.Value = Nothing Then
                MsgBox("Please check if you have given Card Name.")
                Me.txtItemName.Focus()
                Me.txtItemName.SelectAll()
                Return False
            Else
                Dim Item_Code As Integer = CLS_Item.Exists_Name(Me.txtItemName.Value)
                If Item_Code <> Me.txtCode.Value And Item_Code <> 0 Then
                    MsgBox("Name alredy in use")
                    Me.txtItemName.Focus()
                    Me.txtItemName.SelectAll()
                    Return False
                End If
            End If
            If FixControl(Me.DropCategory) = Nothing Then
                MsgBox("Please check if you have given Category.")
                Me.DropCategory.Focus()
                Return False
            End If
            If FixControl(Me.txtCostPrice) = Nothing Then
                MsgBox("Please check if you have given Cost Price.")
                Me.txtCostPrice.Focus()
                Me.txtCostPrice.SelectAll()
                Return False
            End If
            If FixControl(Me.txtSalesPrice) = Nothing Then
                MsgBox("Please check if you have given Sales Price.")
                Me.txtSalesPrice.Focus()
                Me.txtSalesPrice.SelectAll()
                Return False
            End If

            If Me.txtCostPrice.Value > Me.txtSalesPrice.Value Then
                MsgBox("Cost Price should be less then Sales Price.")
                Me.txtCostPrice.Focus()
                Me.txtCostPrice.SelectAll()
                Return False
            End If
            If FixControl(Me.txtBarcode) = Nothing Then
                MsgBox("Please check if you have given Barcode.")
                Me.txtBarcode.Focus()
                Me.txtBarcode.SelectAll()
                Return False
            End If

            If Not CLS_Item.ValidBarcode(Me.txtCode.Value, Me.txtBarcode.Value) Then
                MsgBox("Barcode alredy in use")
                Me.txtBarcode.Focus()
                Me.txtBarcode.SelectAll()
                Return False
            End If

            If FixControl(Me.DropCostMethod) = Nothing Then
                Me.DropCostMethod.Value = CostMethod.CostFromPurchase
            End If


            Select Case CType(FixControl(Me.DropCostMethod), CostMethod)
                Case CostMethod.CostFromMargin
                    If FixControl(Me.txtProfitMargin) = Nothing Then
                        MsgBox("Please check if you have given Profit Margin.")
                        Me.txtProfitMargin.Focus()
                        Me.txtProfitMargin.SelectAll()
                        Return False
                    End If
            End Select


            If FixControl(Me.txtStockMin) = Nothing Then Me.txtStockMin.Value = 0
            If FixControl(Me.txtStockInHand) = Nothing Then Me.txtStockInHand.Value = 0
            If FixControl(Me.txtStockInStore) = Nothing Then Me.txtStockInStore.Value = 0
            If FixControl(Me.DropItemType) = Nothing Then Me.DropItemType.Value = ItemType.StandardItem



            If TrimDate(Me.txtPromoFrom.Value) = Null_Date AndAlso TrimDate(Me.txtPromoTo.Value) = Null_Date Then
            ElseIf TrimDate(Me.txtPromoFrom.Value) <> Null_Date AndAlso TrimDate(Me.txtPromoTo.Value) = Null_Date Then
                MsgBox("Please give promo to date.")
                Me.txtPromoTo.Focus()
                Me.txtPromoTo.SelectAll()
                Return False
            ElseIf TrimDate(Me.txtPromoFrom.Value) = Null_Date AndAlso TrimDate(Me.txtPromoTo.Value) <> Null_Date Then
                MsgBox("Please give promo from date.")
                Me.txtPromoFrom.Focus()
                Me.txtPromoFrom.SelectAll()
                Return False
            ElseIf TrimDate(Me.txtPromoFrom.Value) <> Null_Date AndAlso TrimDate(Me.txtPromoTo.Value) <> Null_Date Then
                If TrimDate(Me.txtPromoFrom.Value) > TrimDate(Me.txtPromoTo.Value) Then
                    MsgBox("Invalid promo to date.")
                    Me.txtPromoTo.Focus()
                    Me.txtPromoTo.SelectAll()
                    Return False
                End If
                If TrimDec(Me.txtPromoPrice.Value) = 0 Then
                    MsgBox("Please give promo price.")
                    Me.txtPromoPrice.Focus()
                    Me.txtPromoPrice.SelectAll()
                    Return False
                End If
                If TrimDec(Me.txtPromoStockLimit.Value) = 0 Then
                    MsgBox("Please give promo stock limit.")
                    Me.txtPromoStockLimit.Focus()
                    Me.txtPromoStockLimit.SelectAll()
                    Return False
                End If

                If TrimDate(Me.txtPromoFrom.Value) <= Now AndAlso TrimDate(Me.txtPromoTo.Value) >= Now Then
                    If TrimDec(Me.txtPromoStockAvailable.Value) > 0 Then
                        Me.chkOnPromo.Checked = True
                    Else
                        Me.chkOnPromo.Checked = False
                    End If
                Else
                    Me.chkOnPromo.Checked = False
                End If
            End If


            Return True

        Catch ex As Exception
            MsgBox("[CanSave]" & vbCrLf & ex.Message)
        End Try
    End Function
    Public Sub Clear() Implements IDataEntry.Clear
        Try
            ItemCode = 0
            Me.txtCode.Value = Nothing
            Me.txtItemName.Value = Nothing
            Me.DropCategory.Value = Nothing
            Me.DropSubCategory.Value = Nothing
            Me.txtCostPrice.Value = Nothing
            Me.txtProfitMargin.Value = 0
            Me.txtSalesPrice.Value = Nothing
            Me.txtBarcode.Value = Nothing
            Me.txtBarcode2.Value = Nothing
            Me.txtStockInHand.Value = Nothing
            Me.txtStockInStore.Value = Nothing
            Me.txtStockMin.Value = Nothing
            Me.DropItemType.Value = Nothing
            Me.DropUMC.Value = Nothing
            Me.txtNotes.Value = Nothing
            Me.txtLastSaleDate.Value = Nothing
            Me.txtLastPurchaseDate.Value = Nothing
            Me.txtLastPurchaseCost.Value = Nothing
            Me.DropSearch.Value = Nothing
            Me.DropCostMethod.Value = Nothing
            Me.chkDiscontinued.Checked = False
            Me.chkOnPromo.Checked = False
            Me.txtPromoFrom.Value = Nothing
            Me.txtPromoTo.Value = Nothing
            Me.txtPromoPrice.Value = Nothing
            Me.txtPromoStockLimit.Value = Nothing
            Me.txtPromoStockSold.Value = Nothing
            Me.txtPromoStockAvailable.Value = Nothing

        Catch ex As Exception
            MsgBox("[Clear]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub ComboNavi() Implements IDataEntry.ComboNavi

    End Sub
    Public Sub Counter() Implements IDataEntry.Counter

    End Sub
    Public Sub DataLen() Implements IDataEntry.DataLen

    End Sub
    Public Function Delete() As Boolean Implements IDataEntry.Delete

    End Function
    Public Function Deleting() As Boolean Implements IDataEntry.Deleting

    End Function
    Public Function Edit() As Boolean Implements IDataEntry.Edit
        Try
            Dim PARA As New ArrayList

            PARA.Add(FixControl(Me.txtCode))
            PARA.Add(FixControl(Me.txtItemName))
            PARA.Add(FixControl(Me.DropCategory))
            PARA.Add(FixControl(Me.DropSubCategory))
            PARA.Add(FixControl(Me.txtCostPrice))
            PARA.Add(FixControl(Me.txtProfitMargin))
            PARA.Add(FixControl(Me.txtSalesPrice))
            PARA.Add(FixControl(Me.txtBarcode))
            PARA.Add(FixControl(Me.txtBarcode2))
            PARA.Add(FixControl(Me.txtStockInHand))
            PARA.Add(FixControl(Me.txtStockInStore))
            PARA.Add(FixControl(Me.txtStockMin))
            PARA.Add(FixControl(Me.DropItemType))
            PARA.Add(FixControl(Me.txtNotes))
            PARA.Add(FixControl(Me.DropUMC))
            PARA.Add(FixControl(Me.DropCostMethod))
            PARA.Add(FixControl(Me.chkDiscontinued))
            PARA.Add(FixControl(Me.chkOnPromo))
            PARA.Add(FixControl(Me.txtPromoFrom))

            If TrimDate(Me.txtPromoTo.Value) <> Null_Date Then
                Dim pt As DateTime = TrimDate(Me.txtPromoTo.Value)
                Dim PromoTo As New DateTime(pt.Year, pt.Month, pt.Day, 23, 59, 59)
                PARA.Add(PromoTo)
            Else
                PARA.Add(FixControl(Me.txtPromoTo))
            End If

            PARA.Add(FixControl(Me.txtPromoPrice))
            PARA.Add(FixControl(Me.txtPromoStockLimit))
            PARA.Add(FixControl(Me.txtPromoStockSold))

            DBO.ExecuteSP("ItemUpdate", PARA)
            Return True
        Catch ex As Exception
            MsgBox("[Edit]" & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function Editing() As Boolean Implements IDataEntry.Editing

    End Function
    Public Sub FillDrops() Implements IDataEntry.FillDrops
        Try
            'FillDrop(Me.DropSearch, "ItemName", "Code", Table.Item, "CostPrice", "SalesPrice", "BarCode", "BarCode2")
            If CLS_Config.SearchByBarcode Then
                FillDropByQuery(Me.DropSearch, "ItemName", "Code", "SELECT Code, COALESCE(barcode,'') + ' - ' + COALESCE(ItemName,'') AS ItemName,BarCode,BarCode2 FROM ITEM")
                'Me.DropSearch.DisplayLayout.Bands(0).Columns("CostPrice").Hidden = True
                'Me.DropSearch.DisplayLayout.Bands(0).Columns("SalesPrice").Hidden = True
                Me.DropSearch.DisplayLayout.Bands(0).Columns("BarCode").Hidden = True
                Me.DropSearch.DisplayLayout.Bands(0).Columns("BarCode2").Hidden = True
            Else
                FillDrop(Me.DropSearch, "ItemName", "Code", Table.Item, "BarCode", "BarCode2")
            End If
            Me.DropSearch.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append

            FillDrop(Me.DropCostMethod, "Title", "Code", Table.D_CostMethod)
            FillDrop(Me.DropCategory, "Title", "Code", Table.D_ItemCategory)
            FillDrop(Me.DropSubCategory, "Title", "Code", Table.D_ItemSubCategory)
            FillDrop(Me.DropItemType, "Title", "Code", Table.D_ItemType)
            FillDrop(Me.DropUMC, "Title", "Code", Table.D_UMCType)
        Catch ex As Exception
            MsgBox("[FillDrops]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub FillGrid() Implements IDataEntry.FillGrid

    End Sub
    Public Sub GridNavi() Implements IDataEntry.GridNavi

    End Sub
    Public Sub LoadCodes() Implements IDataEntry.LoadCodes

    End Sub
    Public Sub LoadData(ByVal Code As Integer) Implements IDataEntry.LoadData
        Try

            Dim CLS As New Item
            CLS.Select(Code)

            ItemCode = Code
            Me.DropSearch.Value = Code
            Me.txtCode.Value = CLS.Code
            Me.txtItemName.Value = CLS.ItemName
            Me.DropCategory.Value = CLS.Category
            Me.DropSubCategory.Value = CLS.SubCategory
            Me.txtCostPrice.Value = CLS.CostPrice
            Me.txtSalesPrice.Value = CLS.SalesPrice
            Me.txtProfitMargin.Value = CLS.ProfitMargin
            Me.txtBarcode.Value = CLS.Barcode
            Me.txtBarcode2.Value = CLS.Barcode2
            Me.txtStockInHand.Value = CLS.StockInHand
            Me.txtStockInStore.Value = CLS.StockInStore
            Me.txtStockMin.Value = CLS.StockMin
            Me.DropItemType.Value = CLS.ItemType
            Me.DropUMC.Value = CLS.UMC
            Me.txtNotes.Value = CLS.Notes
            If CLS.LastSaleDate = Nothing Then
                Me.txtLastSaleDate.Value = Nothing
            Else
                Me.txtLastSaleDate.Value = CLS.LastSaleDate
            End If
            If CLS.LastPurchaseDate = Nothing Then
                Me.txtLastPurchaseDate.Value = Nothing
            Else
                Me.txtLastPurchaseDate.Value = CLS.LastPurchaseDate
            End If
            If CLS.LastPurchaseCost = Nothing Then
                Me.txtLastPurchaseCost.Value = Nothing
            Else
                Me.txtLastPurchaseCost.Value = CLS.LastPurchaseCost
            End If
            Me.DropCostMethod.Value = CLS.CostMethod
            Me.chkDiscontinued.Checked = CLS.Discontinued

            Me.chkOnPromo.Checked = CLS.onPromo
            Me.txtPromoFrom.Value = IIf(TrimDate(CLS.PromoFrom) = Null_Date, Nothing, CLS.PromoFrom)
            Me.txtPromoTo.Value = IIf(TrimDate(CLS.PromoTo) = Null_Date, Nothing, CLS.PromoTo)
            Me.txtPromoPrice.Value = CLS.PromoPrice
            Me.txtPromoStockLimit.Value = CLS.PromoStockLimit
            Me.txtPromoStockSold.Value = CLS.PromoStockSold
            Me.txtPromoStockAvailable.Value = CLS.PromoStockAvailable

            Me.txtItemName.Focus()
            Me.txtItemName.SelectAll()


            If CLS_Config.ShowImage Then
                Dim ImageName As String = Nothing
                ImageName = ItemImagePath & TrimInt(Me.txtCode.Value) & ".jpg"
                If ItemImagePath <> Nothing AndAlso CategoryImagePath <> Nothing Then
                    If File.Exists(ImageName) Then
                        Me.picIcon.Image = Load_Img(ImageName)
                    Else
                        Me.picIcon.Image = My.Resources.no_picture
                    End If
                Else
                    Me.picIcon.Image = My.Resources.no_picture
                End If
            End If



        Catch ex As Exception
            MsgBox("[LoadData]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub Loading() Implements IDataEntry.Loading

    End Sub
    Public Sub LoadNew() Implements IDataEntry.LoadNew

    End Sub
    Public Sub Mask() Implements IDataEntry.Mask

    End Sub
    Public Sub NaviBack() Implements IDataEntry.NaviBack

    End Sub
    Public Sub NaviNext() Implements IDataEntry.NaviNext

    End Sub
    Public Sub [New]() Implements IDataEntry.New

    End Sub
    Public Sub ReadOnlyField() Implements IDataEntry.ReadOnlyField
        Try
            Me.txtStockTotal.ReadOnly = True
            If Not UserClass.CanAdjustStock Then
                Me.txtStockInHand.ReadOnly = True
                Me.txtStockInStore.ReadOnly = True
            End If
        Catch ex As Exception
            MsgBox("[ReadOnlyField]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Function Saving() As Boolean Implements IDataEntry.Saving

    End Function
    Public Function SetCode() As Boolean Implements IDataEntry.SetCode
        Dim PARA As New ArrayList
        Me.txtCode.Value = DBO.ExecuteSP_ReturnInteger("ItemAndClassCode", PARA) ' GetNewCode("Code", Table.Item)
    End Function
    Public Function SetDefault() As Boolean Implements IDataEntry.SetDefault
        Try
            ItemCode = 0
            Me.DropCategory.Value = CLS_Config.DefaultCategory
            Me.DropSubCategory.Value = CLS_Config.DefaultSubCategory
            Me.txtCostPrice.Value = 0
            Me.txtSalesPrice.Value = 0
            Me.txtStockInHand.Value = 0
            Me.txtStockInStore.Value = 0
            Me.txtStockMin.Value = 0
            Me.DropItemType.Value = ItemType.StandardItem
            Select Case CLS_Config.Company
                Case ZAHRABAKALA : Me.DropCostMethod.Value = CostMethod.CostFromMargin
                Case AbdulHussain : Me.DropCostMethod.Value = CostMethod.CostFromItemCard
                Case Else : Me.DropCostMethod.Value = CostMethod.CostFromPurchase
            End Select


        Catch ex As Exception
            MsgBox("[SetDefault]" & vbCrLf & ex.Message)
        End Try
    End Function
#End Region
#Region "Events"
    Public Sub New(Optional ByVal m_ItemCode As Integer = 0)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ItemCode = m_ItemCode
    End Sub

    Private Sub frmItem_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub
    Private Sub frmItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Me.picIcon.Visible = CLS_Config.ShowImage

            txtCostPrice.InputMask = Mask_Amount5
            txtProfitMargin.InputMask = Mask_Amount5Nagative
            txtSalesPrice.InputMask = Mask_Amount5
            txtPromoPrice.InputMask = Mask_Amount5

            FillDrops()
            ReadOnlyField()

            If ItemCode = 0 Then
                btnNew_Click(sender, e)
            Else
                LoadData(ItemCode)
            End If

            Me.txtItemName.Focus()
            Me.txtItemName.SelectAll()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region
#Region " BUTTON CLICK EVENT "
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Try
            Clear()
            SetDefault()
            SetCode()
            Me.txtItemName.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        Try
            If FixControl(Me.DropSearch) = Nothing Then
                MsgBox("First select an item to copy.")
                Exit Sub
            End If

            If Not CLS_Item.Exists(Me.DropSearch.Value) Then
                MsgBox("Item Dose Not Exists")
                Exit Sub
            End If

            'Clear()
            LoadData(Me.DropSearch.Value)
            ItemCode = 0
            Me.DropSearch.Value = Nothing
            SetCode()
            Me.txtItemName.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If CanSave() Then

                If ItemCode = 0 Then
                    If Not Add() Then Exit Sub
                Else
                    If Not Edit() Then Exit Sub
                End If

                frmMainIns.Timer1.Enabled = True
                FillDrop(Me.DropSearch, "ItemName", "Code", Table.Item, "BarCode", "BarCode2")
                'Me.DropSearch.Value = Me.txtCode.Value
                LoadData(Me.txtCode.Value)

                Me.DropSearch.Focus()
                Me.DropSearch.Select()

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Me.DropSearch.Focus()
    End Sub
    Private Sub btnUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUndo.Click
        Try
            If FixControl(Me.DropSearch) = Nothing Then
                btnNew_Click(sender, e)
                Exit Sub
            End If

            If Not CLS_Item.Exists(Me.DropSearch.Value) Then
                btnNew_Click(sender, e)
                Exit Sub
            End If

            'Clear()
            LoadData(Me.DropSearch.Value)
            Me.txtItemName.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click, btnClose.Click
        Try
            If MsgBox("Close Form", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                'If CLS_Config.NewSalesScreen Then
                '    If Not IsNothing(frmSales2Ins) Then
                '        frmSales2Ins.Fill_Dataset()
                '        frmSales2Ins.txtBarcode.Focus()
                '    End If
                'Else
                If Not IsNothing(frmSalesIns) Then
                    frmSalesIns.Fill_Dataset()
                    frmSalesIns.txtBarcode.Focus()
                End If
                'End If

                Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub


#End Region
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
    Private Sub DropUMC_EditorButtonClick(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinEditors.EditorButtonEventArgs) Handles DropUMC.EditorButtonClick
        Try
            Dim Name As String = InputBox("New UMC Type", "New UMC Type", Nothing)
            If Name = Nothing Then Exit Sub

            Dim PARA As New ArrayList
            PARA.Add(Name)
            Dim Code As Integer = CInt(DBO.ExecuteSP_ReturnSingleValue("D_UMCTypeInsert", PARA))

            FillDrop(Me.DropUMC, "Title", "Code", Table.D_UMCType)
            Me.DropSubCategory.Value = Code

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#Region " KEY DOWN "
    Private Sub txtItemName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItemName.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    Me.DropCategory.Focus()
                Case Keys.Divide
                    Me.DropSearch.Focus()
            End Select
        Catch ex As Exception
            MsgBox("[txtItemName_KeyDown]" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub DropCategory_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DropCategory.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    Me.DropSubCategory.Focus()
                Case Keys.Divide
                    Me.txtItemName.Focus()
                    Me.txtItemName.SelectAll()
            End Select

        Catch ex As Exception
            MsgBox("[DropCategory_KeyDown]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub DropSubCategory_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DropSubCategory.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    Me.txtCostPrice.Focus()
                    Me.txtCostPrice.SelectAll()
                Case Keys.Divide
                    Me.DropCategory.Focus()
            End Select

        Catch ex As Exception
            MsgBox("[DropSubCategory_KeyDown]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub txtCostPrice_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCostPrice.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    Me.txtProfitMargin.Focus()
                    Me.txtProfitMargin.SelectAll()
                Case Keys.Divide
                    Me.DropSubCategory.Focus()
            End Select

        Catch ex As Exception
            MsgBox("[txtCostPrice_KeyDown]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub txtPercentage_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProfitMargin.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    Get_SP_by_Percentage()
                    Me.txtSalesPrice.Focus()
                    Me.txtSalesPrice.SelectAll()
                Case Keys.Divide
                    Me.DropSubCategory.Focus()
            End Select

        Catch ex As Exception
            MsgBox("[txtPercentage_KeyDown]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub txtSalesPrice_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSalesPrice.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    txtSalesPrice_ValueChanged(sender, e)
                    Me.DropCostMethod.Focus()
                Case Keys.Divide
                    Me.txtProfitMargin.Focus()
                    Me.txtProfitMargin.SelectAll()
            End Select

        Catch ex As Exception
            MsgBox("[txtSalesPrice_KeyDown]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub DropCostMethod_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DropCostMethod.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    Me.txtBarcode.Focus()
                    Me.txtBarcode.SelectAll()
                Case Keys.Divide
                    Me.txtSalesPrice.Focus()
                    Me.txtSalesPrice.SelectAll()
            End Select

        Catch ex As Exception
            MsgBox("[DropCostMethod_KeyDown]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub txtBarcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBarcode.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    Me.txtBarcode2.Focus()
                    Me.txtBarcode2.SelectAll()
                Case Keys.Divide
                    Me.DropCostMethod.Focus()
            End Select

        Catch ex As Exception
            MsgBox("[txtBarcode_KeyDown]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub txtBarcode2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBarcode2.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    Me.txtStockInHand.Focus()
                    Me.txtStockInHand.SelectAll()
                Case Keys.Divide
                    Me.txtBarcode.Focus()
                    Me.txtBarcode.SelectAll()
            End Select

        Catch ex As Exception
            MsgBox("[txtBarcode2_KeyDown]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub txtStockInHand_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStockInHand.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    Me.txtStockMin.Focus()
                    Me.txtStockMin.SelectAll()
                Case Keys.Divide
                    Me.txtBarcode2.Focus()
                    Me.txtBarcode2.SelectAll()
            End Select

        Catch ex As Exception
            MsgBox("[txtStockInHand_KeyDown]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub txtStockInStore_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStockInStore.KeyDown, txtStockTotal.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    Me.txtStockMin.Focus()
                    Me.txtStockMin.SelectAll()
                Case Keys.Divide
                    Me.txtStockInHand.Focus()
                    Me.txtStockInHand.SelectAll()
            End Select

        Catch ex As Exception
            MsgBox("[txtStockInStore_KeyDown]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub txtStockMin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStockMin.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    Me.DropItemType.Focus()
                Case Keys.Divide
                    Me.txtStockInHand.Focus()
                    Me.txtStockInHand.SelectAll()
            End Select

        Catch ex As Exception
            MsgBox("[txtStockMin_KeyDown]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub DropItemType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DropItemType.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    Me.DropUMC.Focus()
                Case Keys.Divide
                    Me.txtStockMin.Focus()
                    Me.txtStockMin.SelectAll()
            End Select

        Catch ex As Exception
            MsgBox("[DropItemType_KeyDown]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub DropUMC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DropUMC.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    Me.txtNotes.Focus()
                    Me.txtNotes.SelectAll()
                Case Keys.Divide
                    Me.DropItemType.Focus()
            End Select

        Catch ex As Exception
            MsgBox("[DropUMC_KeyDown]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub txtNotes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNotes.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    Me.txtPromoFrom.Focus()
                    Me.txtPromoFrom.SelectAll()
                Case Keys.Divide
                    Me.DropUMC.Focus()
            End Select

        Catch ex As Exception
            MsgBox("[txtNotes_KeyDown]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub txtPromoFrom_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPromoFrom.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    Me.txtPromoTo.Focus()
                    Me.txtPromoTo.SelectAll()
                Case Keys.Divide
                    Me.txtNotes.Focus()
            End Select

        Catch ex As Exception
            MsgBox("[txtPromoFrom_KeyDown]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub txtPromoTo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPromoTo.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    Me.txtPromoPrice.Focus()
                    Me.txtPromoPrice.SelectAll()
                Case Keys.Divide
                    Me.txtPromoFrom.Focus()
            End Select

        Catch ex As Exception
            MsgBox("[txtPromoTo_KeyDown]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub txtPromoPrice_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPromoPrice.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    Me.txtPromoStockLimit.Focus()
                    Me.txtPromoStockLimit.SelectAll()
                Case Keys.Divide
                    Me.txtPromoTo.Focus()
            End Select

        Catch ex As Exception
            MsgBox("[txtPromoPrice_KeyDown]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub txtPromoStockLimit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPromoStockLimit.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    Me.txtPromoStockSold.Focus()
                    Me.txtPromoStockSold.SelectAll()
                Case Keys.Divide
                    Me.txtPromoPrice.Focus()
            End Select

        Catch ex As Exception
            MsgBox("[txtPromoStockLimit_KeyDown]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub txtPromoStockSold_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPromoStockSold.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    btnSave_Click(sender, e)
                Case Keys.Divide
                    Me.txtPromoStockLimit.Focus()
            End Select

        Catch ex As Exception
            MsgBox("[txtPromoStockSold_KeyDown]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub DropSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DropSearch.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter

                    If IsDBNull(Me.DropSearch.Text) Or IsNothing(Me.DropSearch.Text) Then
                    Else
                        Dim Item_Code As Integer = CLS_Item.Exists_By_Barcode(Me.DropSearch.Text)
                        If Item_Code <> 0 Then
                            LoadData(Item_Code)
                            Exit Sub
                        End If
                    End If

                    If IsDBNull(Me.DropSearch.Value) Or IsNothing(Me.DropSearch.Value) Then
                    ElseIf Me.DropSearch.Value = Nothing Then
                    Else

                        If CLS_Item.Exists(Me.DropSearch.Value) Then
                            LoadData(Me.DropSearch.Value)
                            Me.txtItemName.Focus()
                            Exit Sub
                        End If
                    End If

                    If IsDBNull(Me.DropSearch.Text) Or IsNothing(Me.DropSearch.Text) Then
                    ElseIf Me.DropSearch.Text = Nothing Then
                    Else

                        If CLS_Item.Exists(Me.DropSearch.Text) Then
                            LoadData(Me.DropSearch.Text)
                            Me.txtItemName.Focus()
                            Exit Sub
                        End If
                    End If

                    MsgBox("Item Dose Not Exists")



            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region
    Private Function Get_Item(ByVal Barcode As String) As Item
        Try
            Dim DT As New DataTable
            DT = Me.DropSearch.DataSource

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
    Private Sub Get_SP_by_Percentage()
        Try
            Dim CP As Decimal = Decimal.Round(CDec(FixControl(Me.txtCostPrice)), 3)
            Dim Percent As Decimal = Decimal.Round(CDec(FixControl(Me.txtProfitMargin)), 3) / 100
            If CP = 0 Or Percent = 0 Then Exit Sub
            Me.txtSalesPrice.Value = Decimal.Round(CDec((CP * Percent) + CP), 3)

        Catch ex As Exception
            MsgBox("[Get_SP_by_Percentage]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub txtSalesPrice_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalesPrice.ValueChanged, txtCostPrice.ValueChanged
        Try
            Dim CP As Decimal = Decimal.Round(CDec(FixControl(Me.txtCostPrice)), 3)
            Dim SP As Decimal = Decimal.Round(CDec(FixControl(Me.txtSalesPrice)), 3)
            If CP = 0 Or SP = 0 Then Exit Sub
            Me.txtProfitMargin.Value = Decimal.Round(CDec(((SP - CP) * 100) / CP), 3)

        Catch ex As Exception
            MsgBox("[txtSalesPrice_ValueChanged]" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub DropSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DropSearch.KeyUp, txtItemName.KeyUp, DropCategory.KeyUp, DropSubCategory.KeyUp, txtCostPrice.KeyUp, txtProfitMargin.KeyUp, txtSalesPrice.KeyUp, txtBarcode.KeyUp, txtBarcode2.KeyUp, txtStockInHand.KeyUp, txtStockInStore.KeyUp, txtStockMin.KeyUp, DropItemType.KeyUp, txtNotes.KeyUp, DropUMC.KeyUp, DropCostMethod.KeyUp, txtPromoFrom.KeyUp, txtPromoTo.KeyUp, txtPromoPrice.KeyUp, txtPromoStockLimit.KeyUp, chkOnPromo.KeyUp, txtPromoStockSold.KeyUp, txtPromoStockAvailable.KeyUp
        If e.KeyCode = Keys.End Then
            btnExit_Click(sender, e)
        End If
    End Sub

    Private Sub btnBarcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBarcode.Click
        Try
            If Not IsDBNull(Me.DropSearch.Value) And Not IsNothing(Me.DropSearch.Value) Then

                Dim b As New theNext.UC.Barcode
                b.BarcodePrinterName = CLS_Config.BarcodePrinter
                b.BarcodeShowCompany = CLS_Config.BarcodeShowCompany
                b.BarcodeShowItem = CLS_Config.BarcodeShowItem
                b.BarcodeShowPrice = CLS_Config.BarcodeShowPrice
                b.CompanyName = CLS_Config.CompanyName
                b.ItemName = TrimStr(Me.txtItemName.Value)
                b.BarcodeFontSize = CLS_Config.BarcodeFontSize
                b.BarcodeTop = CLS_Config.BarcodeTop
                b.BarcodeLeft = CLS_Config.BarcodeLeft
                b.BarcodeHeight = CLS_Config.BarcodeHeight
                b.BarcodeWidth = CLS_Config.BarcodeWidth
                b.BarcodeGap = CLS_Config.BarcodeGap
                b.SalesPrice = TrimDec(Me.txtSalesPrice.Value)
                b.BarcodeStr = TrimStr(Me.txtBarcode.Value)
                b.CurrencySymbol = "KD"
                b.DecimalPlace = 3
                b.BarcodeType = CLS_Config.BarcodeType
                b.BarcodeFontStyle = FontStyle.Regular
                b.ItemLength = BarcodeItemLength
                'b.Print()

                b.NoOfCopy = 1
                Dim count As Integer = InputBox("Please give the number of Barcode you wish to print.", "Quantity")
                For i As Integer = 0 To count - 1
                    b.Print()
                Next

                'Dim count As Integer = InputBox("Please give the number of Barcode you wish to print.", "Quantity")
                'If count >= 1 Then
                '    Me.Barcode1.Text = Me.txtBarcode.Value
                '    Dim prndoc As PrintDocument = New PrintDocument()
                '    prndoc.DocumentName = "Printing a Barcode"
                '    AddHandler prndoc.PrintPage, New System.Drawing.Printing.PrintPageEventHandler(AddressOf PrintBarCode)
                '    prndoc.PrinterSettings.Copies = count
                '    'prndoc.PrinterSettings.PrinterName = "Send To OneNote 2013"
                '    prndoc.PrinterSettings.PrinterName = CLS_Config.BarcodePrinter
                '    prndoc.Print()
                'End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    'Private Sub PrintBarCode(ByVal sender As Object, ByVal ppea As PrintPageEventArgs)
    '    Try
    '        'Barcode Size
    '        'Width  3.2 CM
    '        'Height 2.2 CM

    '        'Dim fnt As New System.Drawing.Font("Microsoft Sans Serif", 6.25!, FontStyle.Bold)
    '        Dim fnt As New System.Drawing.Font("Microsoft Sans Serif", CLS_Config.BarcodeFontSize, FontStyle.Bold)
    '        Dim Top As Integer = CLS_Config.BarcodeTop

    '        Dim grfx As System.Drawing.Graphics = ppea.Graphics
    '        Dim myImage As System.Drawing.Imaging.Metafile
    '        grfx.PageUnit = GraphicsUnit.Millimeter
    '        grfx.PageScale = 0.1F


    '        If CLS_Config.BarcodeShowCompany = True Then
    '            grfx.DrawString(CLS_Config.CompanyName, fnt, Brushes.Black, CLS_Config.BarcodeLeft, Top)
    '            Top = Top + CLS_Config.BarcodeGap
    '        End If

    '        If CLS_Config.BarcodeShowItem = True Then
    '            Dim ItemName As String = Me.txtItemName.Value
    '            If ItemName.Length > 21 Then
    '                ItemName = ItemName.Substring(0, 21)
    '            End If
    '            grfx.DrawString(ItemName, fnt, Brushes.Black, CLS_Config.BarcodeLeft, Top)
    '            Top = Top + CLS_Config.BarcodeGap
    '        End If



    '        If CLS_Config.BarcodeShowPrice = True Then
    '            Dim SP As Decimal = Me.txtSalesPrice.Value
    '            grfx.DrawString("KD " & ConvertToString(SP), fnt, Brushes.Black, CLS_Config.BarcodeLeft, Top)
    '            Top = Top + CLS_Config.BarcodeGap
    '        End If

    '        Barcode1.Refresh()
    '        'myImage = Barcode1.Picture
    '        myImage = Barcode1.Image
    '        'grfx.DrawImage(myImage, 0, 85, 300, 122)
    '        'grfx.DrawImage(myImage, 0, 85, 300, CLS_Config.BarcodeHeight)
    '        grfx.DrawImage(myImage, CLS_Config.BarcodeLeft, Top, CLS_Config.BarcodeWidth, CLS_Config.BarcodeHeight)
    '        'grfx.DrawImage(myImage, 190, Top, 165, 50) 'EDEE SMALL with Prince Only
    '        'grfx.DrawImage(myImage, 0, 85, CLS_Config.BarcodeWidth, CLS_Config.BarcodeHeight) 'CENTURY

    '        'myImage.Save("D:\POS\Barcode.jpg")

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Private Sub picIcon_Click(sender As Object, e As EventArgs) Handles picIcon.Click
        Try

            If TrimInt(Me.txtCode.Value) = Nothing Then Exit Sub

            Dim OpenDialog As New System.Windows.Forms.OpenFileDialog
            OpenDialog.Title = "Select Item Image."
            OpenDialog.Filter = "(*.jpg)|*.jpg"
            Dim result As DialogResult = OpenDialog.ShowDialog()
            If OpenDialog.FileName <> "" Then
                If result = Windows.Forms.DialogResult.OK Then
                    Dim fname As String = OpenDialog.FileName
                    'Me.PicBox.Image = GetPhoto(fname)
                    Dim ImageName As String = Nothing
                    ImageName = ItemImagePath & TrimInt(Me.txtCode.Value) & ".jpg"
                    If ItemImagePath <> Nothing AndAlso CategoryImagePath <> Nothing Then
                        File.Copy(fname, ImageName, True)
                        Me.picIcon.Image = Load_Img(ImageName)
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub gbxDetail_Click(sender As Object, e As EventArgs) Handles gbxDetail.Click

    End Sub

    Private Sub txtPromoStockLimit_Leave(sender As Object, e As EventArgs) Handles txtPromoStockLimit.Leave, txtPromoStockSold.Leave
        Me.txtPromoStockAvailable.Value = TrimDec(Me.txtPromoStockLimit.Value) - TrimDec(Me.txtPromoStockSold.Value)
    End Sub

    Private Sub btnPromo_Click(sender As Object, e As EventArgs) Handles btnPromo.Click
        Try
            Dim FRM As New frmDynamicList
            FRM.TableName = Table.V_Promotion
            FRM.FK = TrimInt(Me.txtCode.Value)
            FRM.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class