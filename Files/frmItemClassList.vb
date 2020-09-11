Imports System.Data.Odbc
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports Infragistics.Win.UltraWinGrid
Imports System.ComponentModel
Imports POS.FixControls
Imports System.Drawing.Printing
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmItemClassList
    Implements IDataEntry
#Region "Member Variables"

    Private m_tableName As String = Table.ItemClass
    Private DT As New DataTable
    Private DTOriginal As New DataTable
    Private m_modi As Boolean = False
    Protected m_canOpen As Boolean = False
    Private m_Search As Boolean = False


#End Region
#Region "Properties"

    Public Property Search() As Boolean
        Get
            Return m_Search
        End Get
        Set(ByVal value As Boolean)
            m_Search = value
        End Set
    End Property
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

    Private Sub FillGrid()
        Try
            DT.Clear()
            DT = DBO.ReturnDataTableFromSQL("SELECT * FROM ItemClass ORDER BY Code DESC")
            'DTOriginal = DBO.ReturnDataTableFromSQL("SELECT * FROM Item ORDER BY Code DESC")
            'DT = DBO.ReturnDataTableFromTable(m_tableName)
            'DTOriginal = DBO.ReturnDataTableFromTable(m_tableName)
            Me.grdList.DataSource = DT
            Me.grdList.DataBind()

            FillDrop(Me.DropCategory, "Title", "Code", Table.D_ItemCategory)
            FillDrop(Me.DropSubCategory, "Title", "Code", Table.D_ItemSubCategory)

            If CLS_Config.Company = RASLANI Then
                Me.grdList.DisplayLayout.Bands(0).Columns("Barcode").SortIndicator = SortIndicator.Ascending
            End If

        Catch ex As Exception
            MSG.ErrorOk("[FillGrid]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub SetGridLayout()
        Try
            Me.grdList.DisplayLayout.Override.RowAlternateAppearance = RowAlternateAppearance
            'For i As Integer = 0 To Me.grdList.DisplayLayout.Bands(0).Columns.Count - 1
            '    Me.grdList.DisplayLayout.Bands(0).Columns(i).PerformAutoResize()
            'Next
            'Me.grdList.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand)

            'Dim i As Integer = 0
            'For i = 0 To Me.grdList.DisplayLayout.Bands(0).Columns.Count - 1
            '    If Me.grdList.DisplayLayout.Bands(0).Columns(i).Key <> "CostPrice" And _
            '     Me.grdList.DisplayLayout.Bands(0).Columns(i).Key <> "SalesPrice" And _
            '     Me.grdList.DisplayLayout.Bands(0).Columns(i).Key <> "StockInHand" Then
            '        Me.grdList.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            '    End If
            'Next

            Me.grdList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
            'Me.grdList.DisplayLayout.Bands(0).Columns("Code").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            Me.grdList.DisplayLayout.Bands(0).Columns("Category").EditorControl = Me.DropCategory
            Me.grdList.DisplayLayout.Bands(0).Columns("SubCategory").EditorControl = Me.DropSubCategory

            Me.grdList.DisplayLayout.Bands(0).Columns("Code").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("Barcode").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("Barcode2").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemName").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("SalesPrice").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("Category").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("SubCategory").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            Me.grdList.DisplayLayout.Bands(0).Columns("Code").Header.VisiblePosition = 0
            Me.grdList.DisplayLayout.Bands(0).Columns("Barcode").Header.VisiblePosition = 1
            Me.grdList.DisplayLayout.Bands(0).Columns("Barcode2").Header.VisiblePosition = 2
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemName").Header.VisiblePosition = 3
            Me.grdList.DisplayLayout.Bands(0).Columns("SalesPrice").Header.VisiblePosition = 4
            Me.grdList.DisplayLayout.Bands(0).Columns("Category").Header.VisiblePosition = 5
            Me.grdList.DisplayLayout.Bands(0).Columns("SubCategory").Header.VisiblePosition = 6
            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").Header.VisiblePosition = 7

           
            Me.grdList.DisplayLayout.Bands(0).Columns("Barcode").TabIndex = 0
            Me.grdList.DisplayLayout.Bands(0).Columns("Barcode2").TabIndex = 1
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemName").TabIndex = 3
            Me.grdList.DisplayLayout.Bands(0).Columns("SalesPrice").TabIndex = 8
           
            Me.grdList.DisplayLayout.Bands(0).Columns("SalesPrice").MaskInput = Mask_Amount
            
            Me.grdList.DisplayLayout.Bands(0).Columns("Barcode").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("Barcode2").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemName").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("SalesPrice").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("Category").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("SubCategory").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").PerformAutoResize()
            

            'SetChangePrice()

        Catch ex As Exception
            MSG.ErrorOk("[SetGridLayout]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub SetFormTitle()
        Try
            Me.Text = "Item Class List"
        Catch ex As Exception
            MSG.ErrorOk("[SetFormTitle]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub Delete()
        Try
            If IsNothing(Me.grdList.ActiveRow) Then
                MsgBox("Select Record First")
                Exit Sub
            End If

            If MSG.WarnYesNo("Are you sure you want to delete selected record?", 2) <> MsgBoxResult.Yes Then Exit Sub
            Dim CLS As New ItemClass
            CLS.Code = Me.grdList.ActiveRow.Cells("Code").Value
            CLS.Delete()
            MsgBox("Delete successfully")
            FillGrid()
            SetGridLayout()

        Catch ex As Exception
            MSG.ErrorOk("[Delete]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub CloseMe()
        Me.Close()
    End Sub
  
#End Region
#Region "Events"
   
    Private Sub grdList_DoubleClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles grdList.DoubleClickCell
        If e.Cell.Row.IsDataRow Then btnShowItem_Click(sender, e)
    End Sub

    Private Sub frmItemList_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Load_Save_XML(XML_Section.ItemClass, Me.grdList, False)
    End Sub

    Private Sub frmDynamicList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown, grdList.KeyDown
        If e.KeyCode = Keys.End Then btnExit_Click(sender, e)
    End Sub

    Private Sub frmItemList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.Cart_Blue
        Try

            SetFormTitle()
            FillGrid()
            SetGridLayout()
            Load_Save_XML(XML_Section.ItemClass, Me.grdList, True)

            Dim mapping As New GridKeyActionMapping(Keys.Enter, UltraGridAction.NextCellByTab, DirectCast(0, UltraGridState), UltraGridState.InEdit, SpecialKeys.All, DirectCast(0, SpecialKeys))
            Me.grdList.KeyActionMappings.Add(mapping)

            If m_Search Then Me.grdList.DisplayLayout.Bands(0).ColumnFilters.ClearAllFilters()

            Me.txtSearch.Focus()
            Me.txtSearch.SelectAll()

        Catch ex As Exception
            MSG.ErrorOk("[frmItemList_Load]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub frmItemList_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            frmItemClassListIns = Nothing
        Catch ex As Exception
            MSG.ErrorOk("[frmDynamicList_FormClosed]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Dim FRM As New frmItemClass
        FRM.ShowDialog()
        FillGrid()
        SetGridLayout()
    End Sub
    Private Sub btnShowItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowItem.Click
        Try
            If IsDBNull(Me.grdList.ActiveRow) Or IsNothing(Me.grdList.ActiveRow) Then
                MSG.ErrorOk("Select item first")
                Exit Sub
            End If

            If IsDBNull(Me.grdList.ActiveRow.Cells("Code").Value) Or IsNothing(Me.grdList.ActiveRow.Cells("Code").Value) Then
                MSG.ErrorOk("Select item first")
                Exit Sub
            ElseIf Me.grdList.ActiveRow.Cells("Code").Value = Nothing Then
                MSG.ErrorOk("Select item first")
                Exit Sub
            End If

            If m_Search Then
                Find_Int = FixCellNumber(Me.grdList.ActiveRow.Cells("Code"))
                Me.Close()
            Else
                Dim FRM As New frmItemClass(CInt(Me.grdList.ActiveRow.Cells("Code").Value))
                FRM.ShowDialog()
                FillGrid()
                SetGridLayout()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Delete()
    End Sub
    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Print()
    End Sub
    Private Sub btnColumnChooser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColumnChooser.Click
        If Me.UltraGridColumnChooser1.Visible Then
            Me.UltraGridColumnChooser1.Visible = False
        Else
            Me.UltraGridColumnChooser1.Visible = True
        End If
    End Sub
    Private Sub btnBarcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBarcode.Click
        Try
            If IsDBNull(Me.grdList.ActiveRow) Or IsNothing(Me.grdList.ActiveRow) Then
                MsgBox("Select item first.")
                Exit Sub
            End If
            If FixCellNumber(Me.grdList.ActiveRow.Cells("Code")) = Nothing Then
                MsgBox("Select item first.")
                Exit Sub
            End If

            Dim FRM As New frmBarcode(FixCellNumber(Me.grdList.ActiveRow.Cells("Code")), True)
            FRM.MdiParent = Me.MdiParent
            FRM.Show()


            'If Not IsDBNull(Me.grdList.ActiveRow) And Not IsNothing(Me.grdList.ActiveRow) Then
            '    Dim count As Integer = InputBox("Please give the number of Barcode you wish to print.", "Quantity")
            '    If count >= 1 Then

            '        Me.Barcode1.Text = Me.grdList.ActiveRow.Cells("BarCode").Value
            '        Dim prndoc As PrintDocument = New PrintDocument()
            '        prndoc.DocumentName = "Printing a Barcode"
            '        AddHandler prndoc.PrintPage, New System.Drawing.Printing.PrintPageEventHandler(AddressOf PrintBarcode)
            '        prndoc.PrinterSettings.Copies = count
            '        prndoc.PrinterSettings.PrinterName = CLS_Config.BarcodePrinter
            '        prndoc.Print()
            '    End If
            'End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub PrintBarCode(ByVal sender As Object, ByVal ppea As PrintPageEventArgs)
        Try
            'Barcode Size
            'Width  3.2 CM
            'Height 2.2 CM

            Dim fnt As New System.Drawing.Font("Microsoft Sans Serif", 6.25!, FontStyle.Bold)

            Dim grfx As System.Drawing.Graphics = ppea.Graphics
            Dim myImage As System.Drawing.Imaging.Metafile
            grfx.PageUnit = GraphicsUnit.Millimeter
            grfx.PageScale = 0.1F

            grfx.DrawString(CLS_Config.CompanyName, fnt, Brushes.Black, 0, 0)

            Dim ItemName As String = Me.grdList.ActiveRow.Cells("ItemName").Value
            If ItemName.Length > 21 Then
                ItemName = ItemName.Substring(0, 21)
            End If
            grfx.DrawString(ItemName, fnt, Brushes.Black, 0, 30)


            Dim SP As Decimal = Me.grdList.ActiveRow.Cells("SalesPrice").Value
            grfx.DrawString("PRICE " & ConvertToString(SP), fnt, Brushes.Black, 0, 60)


            Barcode1.Refresh()
            'myImage = Barcode1.Picture
            myImage = Barcode1.Image
            'grfx.DrawImage(myImage, 0, 85, 300, 122)
            'grfx.DrawImage(myImage, 0, 85, 300, CLS_Config.BarcodeHeight)
            grfx.DrawImage(myImage, 0, 85, CLS_Config.BarcodeWidth, CLS_Config.BarcodeHeight)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    'Private Sub grdList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdList.KeyDown
    '    Try
    '        If e.KeyCode <> Keys.Tab Then Exit Sub
    '        If Me.grdList.ActiveCell.Tag = "LAST" Then Add()

    '    Catch ex As Exception
    '        MSG.ErrorOk("[Save]" & vbCrLf & ex.Message)
    '    End Try
    'End Sub
    'Private Sub grdList_AfterRowInsert(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles grdList.AfterRowInsert
    '    Try
    '        e.Row.Cells("ItemType").Value = ItemType.StandardItem
    '        e.Row.Cells("Barcode").Activate()
    '        Me.grdList.PerformAction(UltraGridAction.EnterEditMode, False, False)
    '        e.Row.Tag = "NEW"
    '    Catch ex As Exception
    '        MSG.ErrorOk("[grdList_AfterRowInsert]" & vbCrLf & ex.Message)
    '    End Try
    'End Sub
    'Private Sub grdList_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles grdList.InitializeRow
    '    Try
    '        'e.Row.Cells("Title").Activate()
    '        'Me.grdList.PerformAction(EnterEditMode)
    '        'e.Row.Cells("Title").SelectAll()
    '    Catch ex As Exception
    '        MSG.ErrorOk("[grdList_InitializeRow]" & vbCrLf & ex.Message)
    '    End Try
    'End Sub
    'Private Sub grdList_AfterRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles grdList.AfterRowUpdate
    '    'Save()
    '    If e.Row.Tag = "NEW" Then
    '        Add_Item()
    '    Else
    '        Edit_Item()
    '    End If
    'End Sub
    'Private Function Add_Item() As Boolean
    '    Try

    '    Catch ex As Exception
    '        MSG.ErrorOk("[Add_Item]" & vbCrLf & ex.Message)
    '    End Try
    'End Function
    'Private Function Edit_Item() As Boolean
    '    Try

    '    Catch ex As Exception
    '        MSG.ErrorOk("[Edit_Item]" & vbCrLf & ex.Message)
    '    End Try
    'End Function
    Private Sub grdList_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdList.InitializeLayout
        ' Enable the the filter row user interface by setting the FilterUIType to FilterRow.
        e.Layout.Override.FilterUIType = FilterUIType.FilterRow

        ' FilterEvaluationTrigger specifies when UltraGrid applies the filter criteria typed 
        ' into a filter row. Default is OnCellValueChange which will cause the UltraGrid to
        ' re-filter the data as soon as the user modifies the value of a filter cell. This
        ' property is exposed off the the column as well so it can be set on a per column basis.
        e.Layout.Override.FilterEvaluationTrigger = FilterEvaluationTrigger.OnEnterKeyOrLeaveCell
        e.Layout.Bands(0).Columns(0).FilterEvaluationTrigger = FilterEvaluationTrigger.OnEnterKeyOrLeaveCell

        ' By default the UltraGrid selects the type of the filter operand editor based on
        ' the column's DataType. For DateTime and boolean columns it uses the column's editors.
        ' For other column types it uses the Combo. You can explicitly specify the operand
        ' editor style by setting the FilterOperandStyle on the override or the individual
        ' columns. This property is exposed on the column as well.
        e.Layout.Override.FilterOperandStyle = FilterOperandStyle.Combo
        'e.Layout.Bands(0).Columns(0).FilterOperandStyle = FilterOperandStyle.DropDownList

        ' By default UltraGrid displays user interface for selecting the filter operator. 
        ' You can set the FilterOperatorLocation to hide this user interface. This
        ' property is available on column as well so it can be controlled on a per column
        ' basis. Default is WithOperand. This property is exposed off the column as well.
        e.Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand
        e.Layout.Bands(0).Columns(0).FilterOperatorLocation = FilterOperatorLocation.Hidden

        ' By default the UltraGrid uses StartsWith as the filter operator. You use
        ' the FilterOperatorDefaultValue property to specify a different filter operator
        ' to use. This is the default or the initial filter operator value of the cells
        ' in filter row. If filter operator user interface is enabled (FilterOperatorLocation
        ' is not set to Hidden) then that ui will be initialized to the value of this
        ' property. The user can then change the operator via the operator ui. This
        ' property is exposed off the column as well.
        e.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains
        e.Layout.Bands(0).Columns(0).FilterOperatorDefaultValue = FilterOperatorDefaultValue.Equals

        ' FilterOperatorDropDownItems property can be used to control the options provided
        ' to the user for selecting the filter operator. By default UltraGrid bases 
        ' what operator options to provide on the column's data type. This property is
        ' avaibale on the column as well. Note that FilterOperatorDropDownItems is a flagged
        ' enum and thus multiple options can be combined using bitwise or operation.
        e.Layout.Override.FilterOperatorDropDownItems = FilterOperatorDropDownItems.All
        e.Layout.Bands(0).Columns(0).FilterOperatorDropDownItems = FilterOperatorDropDownItems.Equals Or FilterOperatorDropDownItems.NotEquals

        ' By default UltraGrid displays a clear button in each cell of the filter row
        ' as well as in the row selector of the filter row. When the user clicks this
        ' button the associated filter criteria is cleared. You can use the 
        ' FilterClearButtonLocation property to control if and where the filter clear
        ' buttons are displayed.
        e.Layout.Override.FilterClearButtonLocation = FilterClearButtonLocation.RowAndCell

        ' By default the UltraGrid performs case in-sensitive comparisons for filtering. You can 
        ' use the FilterComparisonType property to change this behavior and perform case sensitive
        ' comparisons. This property is exposed off the column as well so it can be set on a
        ' per column basis.
        e.Layout.Override.FilterComparisonType = FilterComparisonType.CaseInsensitive
        e.Layout.Bands(0).Columns(0).FilterComparisonType = FilterComparisonType.CaseInsensitive

    End Sub

#End Region
#Region "Not Used"

    Public Function Add1() As Boolean Implements IDataEntry.Add

    End Function

    Public Function Adding() As Boolean Implements IDataEntry.Adding

    End Function

    Public Function CanSave() As Boolean Implements IDataEntry.CanSave

    End Function

    Public Sub Clear() Implements IDataEntry.Clear

    End Sub

    Public Sub ComboNavi() Implements IDataEntry.ComboNavi

    End Sub

    Public Sub Counter() Implements IDataEntry.Counter

    End Sub

    Public Sub DataLen() Implements IDataEntry.DataLen

    End Sub

    Private Sub Print()
        Try
            Me.grdList.PrintPreview()
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Sub

    Public Function Delete1() As Boolean Implements IDataEntry.Delete

    End Function

    Public Function Deleting() As Boolean Implements IDataEntry.Deleting

    End Function

    Public Function Edit() As Boolean Implements IDataEntry.Edit

    End Function

    Public Function Editing() As Boolean Implements IDataEntry.Editing

    End Function

    Public Sub FillDrops() Implements IDataEntry.FillDrops

    End Sub

    Public Sub FillGrid1() Implements IDataEntry.FillGrid

    End Sub

    Public Sub GridNavi() Implements IDataEntry.GridNavi

    End Sub

    Public Sub LoadCodes() Implements IDataEntry.LoadCodes

    End Sub

    Public Sub LoadData(ByVal code As Integer) Implements IDataEntry.LoadData

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

    End Sub

    Public Function Saving() As Boolean Implements IDataEntry.Saving

    End Function



    Public Function SetCode() As Boolean Implements IDataEntry.SetCode

    End Function

    Public Function SetDefault() As Boolean Implements IDataEntry.SetDefault

    End Function



#End Region
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        SetChangePrice()
    End Sub

    Dim isEditing As Boolean = False
    Private Sub SetChangePrice()
        Try
            If Not isEditing Then
                Me.btnEdit.Text = "Edit"
                Me.btnEdit.Image = My.Resources.EDIT_16

                isEditing = True
                Me.grdList.DisplayLayout.Bands(0).Columns("ItemName").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Me.grdList.DisplayLayout.Bands(0).Columns("Barcode").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Me.grdList.DisplayLayout.Bands(0).Columns("Barcode2").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Me.grdList.DisplayLayout.Bands(0).Columns("ItemName").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Me.grdList.DisplayLayout.Bands(0).Columns("SalesPrice").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Me.grdList.DisplayLayout.Bands(0).Columns("Category").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Me.grdList.DisplayLayout.Bands(0).Columns("SubCategory").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Me.grdList.DisplayLayout.Bands(0).Columns("Notes").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Else
                Me.btnEdit.Text = "Save"
                Me.btnEdit.Image = My.Resources.SAVE_16

                isEditing = False
                Me.grdList.DisplayLayout.Bands(0).Columns("ItemName").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                Me.grdList.DisplayLayout.Bands(0).Columns("Barcode").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                Me.grdList.DisplayLayout.Bands(0).Columns("Barcode2").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                Me.grdList.DisplayLayout.Bands(0).Columns("ItemName").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                Me.grdList.DisplayLayout.Bands(0).Columns("SalesPrice").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                Me.grdList.DisplayLayout.Bands(0).Columns("Category").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                Me.grdList.DisplayLayout.Bands(0).Columns("SubCategory").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                Me.grdList.DisplayLayout.Bands(0).Columns("Notes").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit

                If IsDBNull(Me.grdList.ActiveRow) Or IsNothing(Me.grdList.ActiveRow) Then Exit Sub
                If IsDBNull(Me.grdList.ActiveRow.Cells("Code").Value) Or IsNothing(Me.grdList.ActiveRow.Cells("Code").Value) Then Exit Sub
                If Me.grdList.ActiveRow.Cells("Code").Value = Nothing Then Exit Sub

                Me.grdList.ActiveRow.Cells("Barcode").Selected = True
                Me.grdList.ActiveRow.Cells("Barcode").Activated = True

                Me.grdList.PerformAction(UltraGridAction.EnterEditMode)

            End If
        Catch ex As Exception
            MSG.ErrorOk("[btnChangePrice_Click]" & vbCrLf & ex.Message)
        End Try
    End Sub


    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
                Export(Me.grdList)
    End Sub
    Private Sub grdList_InitializeLayout2(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdList.InitializeLayout
        ' Set the RowSelectorNumberStyle to enable the row-numbers.
        e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex

        ' You can control the appearance of the row numbers using the RowSelectorAppearance.
        e.Layout.Override.RowSelectorAppearance.ForeColor = Color.Blue
        e.Layout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

        ' You can explicitly set the width of the row selectors if the default one calculated
        ' by the UltraGrid is not enough.
        e.Layout.Override.RowSelectorWidth = 50


    End Sub

#Region " SIMPLE SEARCH "

    Dim srch As Boolean = False

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        Try
            If e.KeyCode <> Keys.Enter Then Exit Sub

            Me.grdList.DisplayLayout.Bands(0).ColumnFilters.ClearAllFilters()
            If Me.txtSearch.Value <> Nothing Then
                Dim charr() As Char = {"[", "]", "{", "}"}
                For Each a As Char In charr
                    If Me.txtSearch.Value = a Then
                        Me.txtSearch.Value = Nothing
                        Exit Sub
                    End If
                Next
                srch = True
                Me.grdList.DisplayLayout.Bands(0).ColumnFilters("Barcode").FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Contains, txtSearch.Value)

            Else
                srch = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub grdList_FilterRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.FilterRowEventArgs) Handles grdList.FilterRow
        Try
            If srch = True Then
                Dim band As UltraGridBand = e.Row.Band

                Dim FC As New FilterCondition
                Dim FCList As New List(Of FilterCondition)

                Dim COL As UltraGridColumn
                For Each COL In Me.grdList.DisplayLayout.Bands(0).Columns
                    If COL.Hidden = False Then
                        FC = New FilterCondition(band.Columns(COL.Key), FilterComparisionOperator.Like, "*" & Me.txtSearch.Value & "*")
                        FCList.Add(FC)
                    End If
                Next


                Dim rowPasses As Boolean = e.Row.MeetsCriteria(FCList.ToArray(), FilterLogicalOperator.Or)

                If Not rowPasses Then
                    e.RowFilteredOut = True
                Else
                    e.RowFilteredOut = False
                End If


                'End If

            End If

        Catch ex As Exception
            MsgBox("Error in [grdList_FilterRow] " & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical, My.Application.Info.ProductName)
        End Try
    End Sub


#End Region

End Class