Imports System.Data.Odbc
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports Infragistics.Win.UltraWinGrid
Imports System.ComponentModel
Imports POS.FixControls


Public Class frmConfig
    Implements IDataEntry

#Region "Member Variables"

    Private m_tableName As String = Table.Config
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

    Public Property TableName() As String
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
            DT = DBO.ReturnDataTableFromTable(m_tableName)
            DTOriginal = DBO.ReturnDataTableFromTable(m_tableName)
            Me.grdList.DataSource = DT
            Me.grdList.DataBind()
        Catch ex As Exception
            MSG.ErrorOk("[FillGrid]" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub SetGridLayout()
        Try

            Me.grdList.DisplayLayout.Bands(0).CardView = True

            Me.grdList.DisplayLayout.Bands(0).Columns("Code").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            Me.grdList.DisplayLayout.Bands(0).Columns("Code").Width = 200
            Me.grdList.DisplayLayout.Bands(0).Columns("AccCash").EditorControl = DropCash
            Me.grdList.DisplayLayout.Bands(0).Columns("AccBank").EditorControl = DropBank
            Me.grdList.DisplayLayout.Bands(0).Columns("AccStock").EditorControl = DropStock
            Me.grdList.DisplayLayout.Bands(0).Columns("AccKnet").EditorControl = DropBank
            Me.grdList.DisplayLayout.Bands(0).Columns("AccMaster").EditorControl = DropBank
            Me.grdList.DisplayLayout.Bands(0).Columns("AccSalesReturn").EditorControl = DropStock
            Me.grdList.DisplayLayout.Bands(0).Columns("AccDiscount").EditorControl = DropCash
            Me.grdList.DisplayLayout.Bands(0).Columns("AccCreditSalesReturn").EditorControl = DropStock
            Me.grdList.DisplayLayout.Bands(0).Columns("AccCapital").EditorControl = DropOwner
            Me.grdList.DisplayLayout.Bands(0).Columns("AccDrawing").EditorControl = DropOwner
            Me.grdList.DisplayLayout.Bands(0).Columns("AccCashCustomer").EditorControl = DropCustomer
            Me.grdList.DisplayLayout.Bands(0).Columns("CardCategory").EditorControl = DropCategory
            Me.grdList.DisplayLayout.Bands(0).Columns("NewsPaperCategory").EditorControl = DropCategory
            Me.grdList.DisplayLayout.Bands(0).Columns("DefaultCategory").EditorControl = DropCategory
            Me.grdList.DisplayLayout.Bands(0).Columns("DefaultSubCategory").EditorControl = DropSubCategory
            Me.grdList.DisplayLayout.Bands(0).Columns("AccSalary").EditorControl = DropSalary
            Me.grdList.DisplayLayout.Bands(0).Columns("AccTempCredit").EditorControl = DropAccTempCredit
            Me.grdList.DisplayLayout.Bands(0).Columns("BarcodeType").EditorControl = DropBarcodeType

            'Me.grdList.DisplayLayout.Bands(0).CardSettings.Width = 300

            If Me.grdList.Rows.Count > 0 Then
                Me.grdList.Rows(0).Cells(1).Activate()
                Me.grdList.PerformAction(UltraGridAction.EnterEditMode, False, False)
            End If

        Catch ex As Exception
            MSG.ErrorOk("[SetGridLayout]" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub SetFormTitle()
        Try
            Me.Text = "Configuation"

        Catch ex As Exception
            MSG.ErrorOk("[SetFormTitle]" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub Save()
        Try
            FillMissingFields()
            Me.grdList.UpdateData()
            If IsValid() Then
                Me.grdList.UpdateData()
                DBO.UpdateDataTable(m_tableName, DT)

                CLS_Config = New SysConfig
                Dim Cls_Read As New ReadConnection

            End If
        Catch ex As Exception
            MSG.ErrorOk("[Save]" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub Cancel()
        Try
            Me.DT.RejectChanges()
            Me.grdList.PerformAction(UndoCell)
            Me.grdList.PerformAction(UndoRow)
            Me.grdList.PerformAction(Undo)
            Me.grdList.DataBind()
            Me.DT.RejectChanges()
            Me.grdList.DataBind()
        Catch ex As Exception
            MSG.ErrorOk("[Cancel]" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Function IsValid() As Boolean
        Try
            'Dim i As Integer = 0
            'Dim r As Integer = 0

            'For r = 0 To Me.grdList.DisplayLayout.Bands(0).Columns.Count - 1
            '    For i = 0 To Me.grdList.Rows.Count - 1
            '        Select Case Me.grdList.DisplayLayout.Bands(0).Columns(r).Key
            '            Case "Title"
            '                If FixCellString(Me.grdList.Rows(i).Cells("Title")) = "" Then
            '                    MsgBox(Me.grdList.DisplayLayout.Bands(0).Columns("Title").Header.Caption & " missing.")
            '                    Return False
            '                End If
            '        End Select
            '    Next
            'Next

        Catch ex As Exception
            MSG.ErrorOk("[IsValid]" & vbCrLf & ex.Message)
        End Try
        Return True
    End Function

    Private Function FillMissingFields() As Boolean
        Try
            Dim i As Integer
            Dim NewCode As Integer = GetNewCode("Code", TableName)

            For i = 0 To Me.grdList.Rows.Count - 1
                If IsDBNull(Me.grdList.Rows(i).Cells("Code").Value) Or IsNothing(Me.grdList.Rows(i).Cells("Code").Value) Then
                    Me.grdList.Rows(i).Cells("Code").Value = NewCode
                    NewCode += 1
                End If
            Next
        Catch ex As Exception
            'MsgBox("Error in [FillMissingFields] " & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical, My.Application.Info.ProductName)
        End Try
    End Function

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



    Private Sub frmDynamicList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown, grdList.KeyDown
        If e.KeyCode = Keys.End Then btnExit_Click(sender, e)
    End Sub

    Private Sub frmDynamicList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            
            FillDropWithCondition(Me.DropCustomer, "Title", "Code", Table.Account, "AccountNum", , , , " WHERE AccountType = " & AccountType.Customer)
            FillDropWithCondition(Me.DropSupplier, "Title", "Code", Table.Account, "AccountNum", , , , " WHERE AccountType = " & AccountType.Supplier)
            FillDropWithCondition(Me.DropStock, "Title", "Code", Table.Account, "AccountNum", , , , " WHERE AccountType = " & AccountType.Stock)
            FillDropWithCondition(Me.DropOtherRevenue, "Title", "Code", Table.Account, "AccountNum", , , , " WHERE AccountType = " & AccountType.Other_Revenue)
            FillDropWithCondition(Me.DropExpenses, "Title", "Code", Table.Account, "AccountNum", , , , " WHERE AccountType = " & AccountType.Expenses)
            FillDropWithCondition(Me.DropCash, "Title", "Code", Table.Account, "AccountNum", , , , " WHERE AccountType = " & AccountType.Cash)
            FillDropWithCondition(Me.DropBank, "Title", "Code", Table.Account, "AccountNum", , , , " WHERE AccountType = " & AccountType.Bank)
            FillDropWithCondition(Me.DropOwner, "Title", "Code", Table.Account, "AccountNum", , , , " WHERE AccountType = " & AccountType.Owner)
            FillDropWithCondition(Me.DropSalary, "Title", "Code", Table.Account, "AccountNum", , , , " WHERE AccountType = " & AccountType.Salary)
            FillDropWithCondition(Me.DropAccTempCredit, "Title", "Code", Table.Account, "AccountNum", , , , " WHERE AccountType = " & AccountType.Customer)

            FillDrop(Me.DropCategory, "Title", "Code", Table.D_ItemCategory)
            FillDrop(Me.DropSubCategory, "Title", "Code", Table.D_ItemSubCategory)
            FillDrop(Me.DropBarcodeType, "Title", "Code", Table.D_BarcodeType)

            SetFormTitle()
            FillGrid()
            SetGridLayout()
            SetFontSize()

            Dim mapping As New GridKeyActionMapping(Keys.Enter, UltraGridAction.NextCellByTab, DirectCast(0, UltraGridState), UltraGridState.InEdit, SpecialKeys.All, DirectCast(0, SpecialKeys))
            Me.grdList.KeyActionMappings.Add(mapping)

        Catch ex As Exception
            MSG.ErrorOk("[frmDynamicList_Load]" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub frmDynamicList_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            frmDynamicListIns = Nothing
        Catch ex As Exception
            MSG.ErrorOk("[frmDynamicList_FormClosed]" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub btnUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUndo.Click
        Cancel()
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Save()
    End Sub
    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Print()
    End Sub

    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub grdList_AfterRowInsert(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles grdList.AfterRowInsert
        Try

        Catch ex As Exception

        End Try
    End Sub
    Private Sub grdList_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles grdList.InitializeRow
        Try
            e.Row.Cells("Title").Activate()
            Me.grdList.PerformAction(EnterEditMode)
            e.Row.Cells("Title").SelectAll()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub grdList_AfterRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles grdList.AfterRowUpdate
        Save()
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



End Class