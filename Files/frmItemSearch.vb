Imports System.Data.Odbc
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports Infragistics.Win.UltraWinGrid
Imports System.ComponentModel
Imports POS.FixControls
Imports System.Drawing.Printing
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmItemSearch
    Implements IDataEntry
#Region "Member Variables"

    Private m_tableName As String = Table.Item_View
    Private DT As New DataTable
    Private DTOriginal As New DataTable
    Private m_modi As Boolean = False
    Protected m_canOpen As Boolean = False


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

    Private Sub FillGrid()
        Try
            DT.Clear()
            DT = DBO.ReturnDataTableFromSQL("SELECT * FROM Item_View WHERE COALESCE(Discontinued,0)=0 ORDER BY Code DESC")
            'DTOriginal = DBO.ReturnDataTableFromSQL("SELECT * FROM Item ORDER BY Code DESC")
            'DT = DBO.ReturnDataTableFromTable(m_tableName)
            'DTOriginal = DBO.ReturnDataTableFromTable(m_tableName)
            Me.grdList.DataSource = DT
            Me.grdList.DataBind()

            If CLS_Config.Company = RASLANI Then
                Me.grdList.DisplayLayout.Bands(0).Columns("Barcode").SortIndicator = SortIndicator.Ascending
            End If

        Catch ex As Exception
            MSG.ErrorOk("[FillGrid]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub SetGridLayout()
        Try
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

            Me.grdList.DisplayLayout.Override.RowAlternateAppearance = RowAlternateAppearance
            Me.grdList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
            'Me.grdList.DisplayLayout.Bands(0).Columns("Code").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            Me.grdList.DisplayLayout.Bands(0).Columns("Code").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("Barcode").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("Barcode2").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemName").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("Category").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("SubCategory").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("CostPrice").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("ProfitMargin").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("SalesPrice").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("StockInHand").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("StockInStore").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("StockTotal").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("StockMin").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("CostMethod").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemType").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("UMC").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("LastSaleDate").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("LastPurchaseDate").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("Discontinued").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            Me.grdList.DisplayLayout.Bands(0).Columns("Code").Header.VisiblePosition = 0
            Me.grdList.DisplayLayout.Bands(0).Columns("Barcode").Header.VisiblePosition = 1
            Me.grdList.DisplayLayout.Bands(0).Columns("Barcode2").Header.VisiblePosition = 2
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemName").Header.VisiblePosition = 3
            Me.grdList.DisplayLayout.Bands(0).Columns("Category").Header.VisiblePosition = 4
            Me.grdList.DisplayLayout.Bands(0).Columns("SubCategory").Header.VisiblePosition = 5
            Me.grdList.DisplayLayout.Bands(0).Columns("CostPrice").Header.VisiblePosition = 6
            Me.grdList.DisplayLayout.Bands(0).Columns("ProfitMargin").Header.VisiblePosition = 7
            Me.grdList.DisplayLayout.Bands(0).Columns("SalesPrice").Header.VisiblePosition = 8
            Me.grdList.DisplayLayout.Bands(0).Columns("StockInHand").Header.VisiblePosition = 9
            Me.grdList.DisplayLayout.Bands(0).Columns("StockInStore").Header.VisiblePosition = 10
            Me.grdList.DisplayLayout.Bands(0).Columns("StockTotal").Header.VisiblePosition = 11
            Me.grdList.DisplayLayout.Bands(0).Columns("StockMin").Header.VisiblePosition = 12
            Me.grdList.DisplayLayout.Bands(0).Columns("CostMethod").Header.VisiblePosition = 13
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemType").Header.VisiblePosition = 14
            Me.grdList.DisplayLayout.Bands(0).Columns("UMC").Header.VisiblePosition = 15
            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").Header.VisiblePosition = 16
            Me.grdList.DisplayLayout.Bands(0).Columns("LastSaleDate").Header.VisiblePosition = 17
            Me.grdList.DisplayLayout.Bands(0).Columns("LastPurchaseDate").Header.VisiblePosition = 18
            Me.grdList.DisplayLayout.Bands(0).Columns("Discontinued").Header.VisiblePosition = 19

            Select Case CLS_Config.Company
                Case ZAHRABAKALA
                    Me.grdList.DisplayLayout.Bands(0).Columns("SubCategory").Hidden = True
                    Me.grdList.DisplayLayout.Bands(0).Columns("StockMin").Hidden = True
                    Me.grdList.DisplayLayout.Bands(0).Columns("UMC").Hidden = True
                    Me.grdList.DisplayLayout.Bands(0).Columns("Notes").Hidden = True
                    Me.grdList.DisplayLayout.Bands(0).Columns("ProfitMargin").Hidden = True
                Case CENTURY
                    'Me.grdList.DisplayLayout.Bands(0).Columns("Code").Hidden = True
                    Me.grdList.DisplayLayout.Bands(0).Columns("Barcode2").Hidden = True
                    Me.grdList.DisplayLayout.Bands(0).Columns("SubCategory").Hidden = False
                    Me.grdList.DisplayLayout.Bands(0).Columns("StockInHand").Hidden = False
                    Me.grdList.DisplayLayout.Bands(0).Columns("StockInStore").Hidden = False
                    Me.grdList.DisplayLayout.Bands(0).Columns("StockTotal").Hidden = False
                    Me.grdList.DisplayLayout.Bands(0).Columns("StockMin").Hidden = True
                    Me.grdList.DisplayLayout.Bands(0).Columns("ItemType").Hidden = True
                    Me.grdList.DisplayLayout.Bands(0).Columns("UMC").Hidden = True
                    Me.grdList.DisplayLayout.Bands(0).Columns("Notes").Hidden = True
                    Me.grdList.DisplayLayout.Bands(0).Columns("LastSaleDate").Hidden = True
                    Me.grdList.DisplayLayout.Bands(0).Columns("LastPurchaseDate").Hidden = True
                    Me.grdList.DisplayLayout.Bands(0).Columns("Barcode2").Hidden = True
                    Me.grdList.DisplayLayout.Bands(0).Columns("StockMin").Hidden = True
                    Me.grdList.DisplayLayout.Bands(0).Columns("ProfitMargin").Hidden = True
                Case Else
                    'Me.grdList.DisplayLayout.Bands(0).Columns("Code").Hidden = True
                    Me.grdList.DisplayLayout.Bands(0).Columns("Barcode2").Hidden = True
                    Me.grdList.DisplayLayout.Bands(0).Columns("SubCategory").Hidden = True
                    Me.grdList.DisplayLayout.Bands(0).Columns("StockInHand").Hidden = False
                    Me.grdList.DisplayLayout.Bands(0).Columns("StockInStore").Hidden = False
                    Me.grdList.DisplayLayout.Bands(0).Columns("StockTotal").Hidden = False
                    Me.grdList.DisplayLayout.Bands(0).Columns("StockMin").Hidden = True
                    Me.grdList.DisplayLayout.Bands(0).Columns("ItemType").Hidden = True
                    Me.grdList.DisplayLayout.Bands(0).Columns("UMC").Hidden = True
                    Me.grdList.DisplayLayout.Bands(0).Columns("Notes").Hidden = True
                    Me.grdList.DisplayLayout.Bands(0).Columns("LastSaleDate").Hidden = True
                    Me.grdList.DisplayLayout.Bands(0).Columns("LastPurchaseDate").Hidden = True
                    Me.grdList.DisplayLayout.Bands(0).Columns("Barcode2").Hidden = True
                    Me.grdList.DisplayLayout.Bands(0).Columns("StockMin").Hidden = True
                    Me.grdList.DisplayLayout.Bands(0).Columns("ProfitMargin").Hidden = True

            End Select



            Me.grdList.DisplayLayout.Bands(0).Columns("Code").TabStop = False
            Me.grdList.DisplayLayout.Bands(0).Columns("Barcode").TabStop = True
            Me.grdList.DisplayLayout.Bands(0).Columns("Barcode2").TabStop = True
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemName").TabStop = True
            Me.grdList.DisplayLayout.Bands(0).Columns("Category").TabStop = True
            Me.grdList.DisplayLayout.Bands(0).Columns("SubCategory").TabStop = True
            Me.grdList.DisplayLayout.Bands(0).Columns("CostPrice").TabStop = True
            Me.grdList.DisplayLayout.Bands(0).Columns("ProfitMargin").TabStop = False
            Me.grdList.DisplayLayout.Bands(0).Columns("SalesPrice").TabStop = True
            Me.grdList.DisplayLayout.Bands(0).Columns("StockInHand").TabStop = True
            Me.grdList.DisplayLayout.Bands(0).Columns("StockInStore").TabStop = True
            Me.grdList.DisplayLayout.Bands(0).Columns("StockTotal").TabStop = False
            Me.grdList.DisplayLayout.Bands(0).Columns("CostMethod").TabStop = True
            Me.grdList.DisplayLayout.Bands(0).Columns("StockMin").TabStop = False
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemType").TabStop = False
            Me.grdList.DisplayLayout.Bands(0).Columns("UMC").TabStop = False
            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").TabStop = False
            Me.grdList.DisplayLayout.Bands(0).Columns("LastSaleDate").TabStop = False
            Me.grdList.DisplayLayout.Bands(0).Columns("LastPurchaseDate").TabStop = False
            Me.grdList.DisplayLayout.Bands(0).Columns("Discontinued").TabStop = False

            Me.grdList.DisplayLayout.Bands(0).Columns("Barcode").TabIndex = 0
            Me.grdList.DisplayLayout.Bands(0).Columns("Barcode2").TabIndex = 1
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemName").TabIndex = 3
            Me.grdList.DisplayLayout.Bands(0).Columns("Category").TabIndex = 4
            Me.grdList.DisplayLayout.Bands(0).Columns("SubCategory").TabIndex = 5
            Me.grdList.DisplayLayout.Bands(0).Columns("CostPrice").TabIndex = 7
            Me.grdList.DisplayLayout.Bands(0).Columns("SalesPrice").TabIndex = 8
            Me.grdList.DisplayLayout.Bands(0).Columns("StockInHand").TabIndex = 9
            Me.grdList.DisplayLayout.Bands(0).Columns("StockInStore").TabIndex = 10
            Me.grdList.DisplayLayout.Bands(0).Columns("CostMethod").TabIndex = 11
            Me.grdList.DisplayLayout.Bands(0).Columns("Discontinued").TabIndex = 12


            Me.grdList.DisplayLayout.Bands(0).Columns("CostMethod").EditorControl = Me.DropCostMethod
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemType").EditorControl = Me.DropItemType
            Me.grdList.DisplayLayout.Bands(0).Columns("Category").EditorControl = Me.DropCategory
            Me.grdList.DisplayLayout.Bands(0).Columns("SubCategory").EditorControl = Me.DropSubCategory
            Me.grdList.DisplayLayout.Bands(0).Columns("UMC").EditorControl = Me.DropUMC

            Me.grdList.DisplayLayout.Bands(0).Columns("Code").MinWidth = 50
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemName").MinWidth = 250
            Me.grdList.DisplayLayout.Bands(0).Columns("Category").MinWidth = 150
            Me.grdList.DisplayLayout.Bands(0).Columns("SubCategory").MinWidth = 100
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemType").MinWidth = 100
            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").MinWidth = 100
            Me.grdList.DisplayLayout.Bands(0).Columns("CostMethod").MinWidth = 100
            'Me.grdList.DisplayLayout.Bands(0).Columns("StockInHand").MinWidth = 100
            'Me.grdList.DisplayLayout.Bands(0).Columns("StockInStore").MinWidth = 100

            Me.grdList.DisplayLayout.Bands(0).Columns("StockInHand").Header.Caption = "In Shop"
            Me.grdList.DisplayLayout.Bands(0).Columns("StockInStore").Header.Caption = "In Store"


            Me.grdList.DisplayLayout.Bands(0).Columns("SalesPrice").MaskInput = Mask_Amount
            Me.grdList.DisplayLayout.Bands(0).Columns("ProfitMargin").MaskInput = Mask_Amount
            Me.grdList.DisplayLayout.Bands(0).Columns("CostPrice").MaskInput = Mask_Amount
            Me.grdList.DisplayLayout.Bands(0).Columns("LastSaleDate").MaskInput = Mask_Date
            Me.grdList.DisplayLayout.Bands(0).Columns("LastPurchaseDate").MaskInput = Mask_Date

            Me.grdList.DisplayLayout.Bands(0).Columns("Barcode").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("Barcode2").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemName").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("Category").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("SubCategory").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("CostPrice").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("ProfitMargin").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("SalesPrice").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("StockInHand").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("StockInStore").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("StockTotal").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("StockMin").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("CostMethod").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemType").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("UMC").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("LastSaleDate").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("LastPurchaseDate").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("Discontinued").PerformAutoResize()


            SetChangePrice()

        Catch ex As Exception
            MSG.ErrorOk("[SetGridLayout]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub SetFormTitle()
        Try
            Me.Text = "Item List"
        Catch ex As Exception
            MSG.ErrorOk("[SetFormTitle]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub Add()
        Try
            Me.grdList.DisplayLayout.Bands(0).AddNew()
            btnShowItem.Enabled = False
            btnDelete.Enabled = False
            Modi = False

        Catch ex As Exception
            MSG.ErrorOk("[Add]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub Save()
        Try
            Me.grdList.UpdateData()
            If IsValid() Then
                Me.grdList.UpdateData()

                Dim CLS As New Item
                CLS.Select(Me.grdList.ActiveRow.Cells("Code").Value)
                CLS.Barcode = FixCellString(Me.grdList.ActiveRow.Cells("Barcode"))
                CLS.Barcode2 = FixCellString(Me.grdList.ActiveRow.Cells("Barcode2"))
                CLS.ItemName = FixCellString(Me.grdList.ActiveRow.Cells("ItemName"))
                CLS.Category = FixCellNumber(Me.grdList.ActiveRow.Cells("Category"))
                CLS.SubCategory = FixCellNumber(Me.grdList.ActiveRow.Cells("SubCategory"))
                CLS.CostPrice = FixCellNumber(Me.grdList.ActiveRow.Cells("CostPrice"))
                CLS.ProfitMargin = FixCellNumber(Me.grdList.ActiveRow.Cells("ProfitMargin"))
                CLS.SalesPrice = FixCellNumber(Me.grdList.ActiveRow.Cells("SalesPrice"))
                CLS.StockInHand = FixCellNumber(Me.grdList.ActiveRow.Cells("StockInHand"))
                CLS.StockInStore = FixCellNumber(Me.grdList.ActiveRow.Cells("StockInStore"))
                CLS.CostMethod = FixCellNumber(Me.grdList.ActiveRow.Cells("CostMethod"))
                CLS.Discontinued = FixCellBoolean(Me.grdList.ActiveRow.Cells("Discontinued"))

                Dim PARA As New ArrayList

                PARA.Add(CLS.Code)
                PARA.Add(CLS.ItemName)
                PARA.Add(CLS.Category)
                PARA.Add(CLS.SubCategory)
                PARA.Add(CLS.CostPrice)
                PARA.Add(CLS.ProfitMargin)
                PARA.Add(CLS.SalesPrice)
                PARA.Add(CLS.Barcode)
                PARA.Add(CLS.Barcode2)
                PARA.Add(CLS.StockInHand)
                PARA.Add(CLS.StockInStore)
                PARA.Add(CLS.StockMin)
                PARA.Add(CLS.ItemType)
                PARA.Add(CLS.Notes)
                PARA.Add(CLS.UMC)
                PARA.Add(CLS.CostMethod)
                PARA.Add(CLS.Discontinued)

                DBO.ExecuteSP("ItemUpdate", PARA)

            Else
                FillGrid()
                SetGridLayout()
                SetFontSize()

            End If
        Catch ex As Exception
            MSG.ErrorOk("[Save]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Function IsValid() As Boolean
        Try

            If IsDBNull(Me.grdList.ActiveRow) Or IsNothing(Me.grdList.ActiveRow) Then
                MsgBox("Record not selected.")
                Return False
            ElseIf IsDBNull(Me.grdList.ActiveRow.Cells("Code").Value) Or IsNothing(Me.grdList.ActiveRow.Cells("Code").Value) Then
                MsgBox("Record not selected.")
                Return False
            ElseIf Me.grdList.ActiveRow.Cells("Code").Value = Nothing Then
                MsgBox("Record not selected.")
                Return False
            End If


            If IsDBNull(Me.grdList.ActiveRow.Cells("Barcode").Value) Or IsNothing(Me.grdList.ActiveRow.Cells("Barcode").Value) Then
                MsgBox("Invalid Barcode.")
                Return False
            ElseIf Me.grdList.ActiveRow.Cells("Barcode").Value = Nothing Then
                MsgBox("Invalid Barcode.")
                Return False
            End If

            Dim CLS_Item As New Item

            If Not CLS_Item.ValidBarcode(Me.grdList.ActiveRow.Cells("Code").Value, Me.grdList.ActiveRow.Cells("Barcode").Value) Then
                MsgBox("Invalid Barcode.")
                Return False
            End If

            If IsDBNull(Me.grdList.ActiveRow.Cells("CostPrice").Value) Or IsNothing(Me.grdList.ActiveRow.Cells("CostPrice").Value) Then
                MsgBox("Invalid Cost Price.")
                Return False
            ElseIf Me.grdList.ActiveRow.Cells("CostPrice").Value = Nothing Then
                MsgBox("Invalid Cost Price.")
                Return False
            End If

            If IsDBNull(Me.grdList.ActiveRow.Cells("SalesPrice").Value) Or IsNothing(Me.grdList.ActiveRow.Cells("SalesPrice").Value) Then
                MsgBox("Invalid Sales Price.")
                Return False
            ElseIf Me.grdList.ActiveRow.Cells("SalesPrice").Value = Nothing Then
                MsgBox("Invalid Sales Price.")
                Return False
            End If

            If IsDBNull(Me.grdList.ActiveRow.Cells("Category").Value) Or IsNothing(Me.grdList.ActiveRow.Cells("Category").Value) Then
                MsgBox("Invalid Category.")
                Return False
            ElseIf Me.grdList.ActiveRow.Cells("Category").Value = Nothing Then
                MsgBox("Invalid Category.")
                Return False
            End If

            If IsDBNull(Me.grdList.ActiveRow.Cells("SubCategory").Value) Or IsNothing(Me.grdList.ActiveRow.Cells("SubCategory").Value) Then
                MsgBox("Invalid Sub Category.")
                Return False
            ElseIf Me.grdList.ActiveRow.Cells("SubCategory").Value = Nothing Then
                MsgBox("Invalid Sub Category.")
                Return False
            End If

            Return True


        Catch ex As Exception
            MSG.ErrorOk("[IsValid]" & vbCrLf & ex.Message)
        End Try
        Return True
    End Function
    Private Sub Cancel()
        Try
            Me.DT.RejectChanges()
            Me.grdList.PerformAction(UndoCell)
            Me.grdList.PerformAction(UndoRow)
            Me.grdList.PerformAction(Undo)
            Me.grdList.DataBind()
            Me.btnShowItem.Enabled = True
            Me.btnDelete.Enabled = True
            Me.DT.RejectChanges()
            Me.grdList.DataBind()
        Catch ex As Exception
            MSG.ErrorOk("[Cancel]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub Delete()
        Try
            If IsNothing(Me.grdList.ActiveRow) Then
                MsgBox("Select Record First")
            Else
                Dim i As MsgBoxResult
                i = MSG.WarnYesNo("Are you sure you want to delete selected record?", 2)
                If i = MsgBoxResult.Yes Then
                    'Me.grdList.ActiveRow.Delete(False)
                    'Save()

                    Dim Code As Integer = Me.grdList.ActiveRow.Cells("Code").Value

                    Dim PARA As New ArrayList
                    PARA.Add(Code)

                    Dim Result As Integer = DBO.ExecuteSP_ReturnInteger("ItemDelete", PARA)
                    If Result = 0 Then
                        MsgBox("Cant Delete")
                    Else
                        MsgBox("Delete successfully")
                        FillGrid()
                        SetGridLayout()
                        SetFontSize()
                    End If


                Else
                End If
            End If
        Catch ex As Exception
            MSG.ErrorOk("[Delete]" & vbCrLf & ex.Message)
        End Try
    End Sub
    'Private Function IsValid(ByVal Rec As Integer) As Boolean
    '    Try
    '        If FixCellString(Me.grdList.Rows(Rec).Cells("Barcode")) = "" Then
    '            MsgBox("Barcode missing.")
    '            Me.grdList.Rows(Rec).Cells("Barcode").Activate()
    '            Me.grdList.PerformAction(UltraGridAction.EnterEditMode, False, False)
    '            Return False
    '        End If
    '        If FixCellString(Me.grdList.Rows(Rec).Cells("ItemName")) = "" Then
    '            MsgBox("ItemName missing.")
    '            Me.grdList.Rows(Rec).Cells("ItemName").Activate()
    '            Me.grdList.PerformAction(UltraGridAction.EnterEditMode, False, False)
    '            Return False
    '        End If
    '        If FixCellNumber(Me.grdList.Rows(Rec).Cells("CostPrice")) = Nothing Then
    '            MsgBox("CostPrice missing.")
    '            Me.grdList.Rows(Rec).Cells("CostPrice").Activate()
    '            Me.grdList.PerformAction(UltraGridAction.EnterEditMode, False, False)
    '            Return False
    '        End If
    '        If FixCellNumber(Me.grdList.Rows(Rec).Cells("SalesPrice")) = Nothing Then
    '            MsgBox("SalesPrice missing.")
    '            Me.grdList.Rows(Rec).Cells("SalesPrice").Activate()
    '            Me.grdList.PerformAction(UltraGridAction.EnterEditMode, False, False)
    '            Return False
    '        End If
    '        If FixCellNumber(Me.grdList.Rows(Rec).Cells("ItemType")) = Nothing Then
    '            MsgBox("ItemType missing.")
    '            Me.grdList.Rows(Rec).Cells("ItemType").Activate()
    '            Me.grdList.PerformAction(UltraGridAction.EnterEditMode, False, False)
    '            Return False
    '        End If

    '    Catch ex As Exception
    '        MSG.ErrorOk("[IsValid]" & vbCrLf & ex.Message)
    '    End Try
    '    Return True
    'End Function
    Private Sub CloseMe()
        Me.Close()
    End Sub
    Public Sub SetFontSize()
        Try

        Catch ex As Exception
            MSG.ErrorOk("[SetFontSize]" & vbCrLf & ex.Message)
        End Try
    End Sub

#End Region
#Region "Events"

    Private Sub grdList_AfterRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles grdList.AfterRowUpdate
        Save()
    End Sub

    Private Sub grdList_DoubleClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles grdList.DoubleClickCell
        If e.Cell.Row.IsDataRow Then btnShowItem_Click(sender, e)
    End Sub

    Private Sub frmItemSearch_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Load_Save_XML(XML_Section.ItemSearch, Me.grdList, False)
    End Sub


    Private Sub frmItemSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown, grdList.KeyDown
        If e.KeyCode = Keys.End Then btnExit_Click(sender, e)
    End Sub
    Private Sub frmItemList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.Cart_Blue
        Try

            SetFormTitle()
            FillGrid()
            SetGridLayout()
            Load_Save_XML(XML_Section.ItemSearch, Me.grdList, True)
            SetFontSize()
            Me.grdList.DisplayLayout.Override.RowAlternateAppearance = RowAlternateAppearance

            Dim mapping As New GridKeyActionMapping(Keys.Enter, UltraGridAction.NextCellByTab, DirectCast(0, UltraGridState), UltraGridState.InEdit, SpecialKeys.All, DirectCast(0, SpecialKeys))
            Me.grdList.KeyActionMappings.Add(mapping)

            Me.txtSearch.Focus()
            Me.txtSearch.SelectAll()


        Catch ex As Exception
            MSG.ErrorOk("[frmDynamicList_Load]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub frmItemSearch_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            'frmItemSearchIns = Nothing
        Catch ex As Exception
            MSG.ErrorOk("[frmDynamicList_FormClosed]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Dim FRM As New frmItem
        FRM.ShowDialog()
        FillGrid()
        SetGridLayout()
        SetFontSize()
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

            Dim FRM As New frmItem(CInt(Me.grdList.ActiveRow.Cells("Code").Value))
            FRM.ShowDialog()


            FillGrid()
            SetGridLayout()


        Catch ex As Exception

        End Try
    End Sub
    'Private Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
    '    Add()
    'End Sub
    'Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    'End Sub
    'Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
    '    Delete()
    'End Sub
    'Private Sub btnUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUndo.Click
    '    Cancel()
    'End Sub
    'Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
    '    Save()
    'End Sub
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

            Dim FRM As New frmBarcode(FixCellNumber(Me.grdList.ActiveRow.Cells("Code")), False)
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
                Me.grdList.DisplayLayout.Bands(0).Columns("Barcode").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Me.grdList.DisplayLayout.Bands(0).Columns("Barcode2").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Me.grdList.DisplayLayout.Bands(0).Columns("ItemName").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Me.grdList.DisplayLayout.Bands(0).Columns("Category").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Me.grdList.DisplayLayout.Bands(0).Columns("SubCategory").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Me.grdList.DisplayLayout.Bands(0).Columns("CostPrice").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Me.grdList.DisplayLayout.Bands(0).Columns("SalesPrice").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Me.grdList.DisplayLayout.Bands(0).Columns("StockInHand").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Me.grdList.DisplayLayout.Bands(0).Columns("StockInStore").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Me.grdList.DisplayLayout.Bands(0).Columns("CostMethod").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Me.grdList.DisplayLayout.Bands(0).Columns("Discontinued").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Else
                Me.btnEdit.Text = "Save"
                Me.btnEdit.Image = My.Resources.SAVE_16

                isEditing = False
                Me.grdList.DisplayLayout.Bands(0).Columns("Barcode").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                Me.grdList.DisplayLayout.Bands(0).Columns("Barcode2").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                Me.grdList.DisplayLayout.Bands(0).Columns("ItemName").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                Me.grdList.DisplayLayout.Bands(0).Columns("Category").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                Me.grdList.DisplayLayout.Bands(0).Columns("SubCategory").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                Me.grdList.DisplayLayout.Bands(0).Columns("CostPrice").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                Me.grdList.DisplayLayout.Bands(0).Columns("SalesPrice").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                Me.grdList.DisplayLayout.Bands(0).Columns("StockInHand").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                Me.grdList.DisplayLayout.Bands(0).Columns("StockInStore").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                Me.grdList.DisplayLayout.Bands(0).Columns("CostMethod").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                Me.grdList.DisplayLayout.Bands(0).Columns("Discontinued").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit

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
End Class