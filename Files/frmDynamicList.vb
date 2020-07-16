Imports System.Data.Odbc
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports Infragistics.Win.UltraWinGrid
Imports System.ComponentModel
Imports POS.FixControls
Imports System.IO


Public Class frmDynamicList
    Implements IDataEntry

#Region "Member Variables"

    Private m_FK As Integer = Nothing
    Private m_tableName As String = ""
    Private m_AccountType As AccountType = CodeModule.AccountType.None
    Private DT As New DataTable
    Private DTOriginal As New DataTable
    Private m_modi As Boolean = False
    Protected m_canOpen As Boolean = False


#End Region

#Region "Properties"

    Public Property FK() As String
        Get
            Return m_FK
        End Get
        Set(ByVal value As String)
            m_FK = value
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

    Public Property TableName() As String
        Get
            Return m_tableName
        End Get
        Set(ByVal value As String)
            m_tableName = value
        End Set
    End Property

    Public Property AccountType() As AccountType
        Get
            Return m_AccountType
        End Get
        Set(ByVal value As AccountType)
            m_AccountType = value
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
            Select Case TableName
                Case Table.Membership
                    DT = DBO.ReturnDataTable("SELECT     M.Code, M.MembershipNumber, M.MembershipDate, M.MemberName, M.Mobile, M.DOB, M.isClosed,  U.UserName FROM Membership AS M INNER JOIN P_User AS U ON M.UserCode = U.Code ")
                    DTOriginal = DBO.ReturnDataTable("SELECT     M.Code, M.MembershipNumber, M.MembershipDate, M.MemberName, M.Mobile, M.DOB, M.isClosed,  U.UserName FROM Membership AS M INNER JOIN P_User AS U ON M.UserCode = U.Code ")

                Case Table.Account
                    If FixObjectString(AccountType) = Nothing Then
                        MsgBox("Account Type missing.")
                        Exit Sub
                    End If
                    DT = DBO.ReturnDataTable("SELECT * FROM Account WHERE AccountType = " & AccountType)
                    DTOriginal = DBO.ReturnDataTable("SELECT * FROM Account WHERE AccountType = " & AccountType)
                Case Table.V_Promotion
                    If TrimInt(FK) = Nothing Then
                        DT = DBO.ReturnDataTableFromTable(m_tableName)
                        DTOriginal = DBO.ReturnDataTableFromTable(m_tableName)
                    Else
                        DT = DBO.ReturnDataTable("SELECT * FROM V_Promotion WHERE ItemCode = " & TrimInt(FK))
                        DTOriginal = DBO.ReturnDataTable("SELECT * FROM V_Promotion WHERE ItemCode = " & TrimInt(FK))
                    End If
                Case Else
                    DT = DBO.ReturnDataTableFromTable(m_tableName)
                    DTOriginal = DBO.ReturnDataTableFromTable(m_tableName)
            End Select
            Me.grdList.DataSource = DT
            Me.grdList.DataBind()
        Catch ex As Exception
            MSG.ErrorOk("[FillGrid]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub SetGridLayout()
        Try


            Me.grdList.DisplayLayout.Override.RowAlternateAppearance = RowAlternateAppearance
            Me.grdList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
            Select Case TableName

                Case Table.Membership
                    Me.btnNew.Enabled = False
                    Me.btnDelete.Enabled = False
                    Me.btnUndo.Enabled = False
                    Me.btnSave.Enabled = False
                    Me.btnRefresh.Enabled = False

                    Me.btnNew.Visible = False
                    Me.btnDelete.Visible = False
                    Me.btnUndo.Visible = False
                    Me.btnSave.Visible = False
                    Me.btnRefresh.Visible = False


                    Me.grdList.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
                    Me.grdList.DisplayLayout.Bands(0).Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False
                    Me.grdList.DisplayLayout.Bands(0).Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
                    Me.grdList.DisplayLayout.Bands(0).Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False


                Case Table.V_Promotion
                    Me.btnNew.Enabled = False
                    'Me.btnDelete.Enabled = False
                    Me.btnUndo.Enabled = False
                    Me.btnSave.Enabled = False

                    Me.btnNew.Visible = False
                    'Me.btnDelete.Visible = False
                    Me.btnUndo.Visible = False
                    Me.btnSave.Visible = False

                    Me.grdList.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
                    Me.grdList.DisplayLayout.Bands(0).Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True
                    Me.grdList.DisplayLayout.Bands(0).Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
                    Me.grdList.DisplayLayout.Bands(0).Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False

                    '''''''''''''''''''''CAPTION'''''''''''''''''''''
                    Me.grdList.DisplayLayout.Bands(0).Columns("Code").Header.Caption = "Code"
                    Me.grdList.DisplayLayout.Bands(0).Columns("ItemCode").Header.Caption = "Item Code"
                    Me.grdList.DisplayLayout.Bands(0).Columns("ItemName").Header.Caption = "Item Name"
                    Me.grdList.DisplayLayout.Bands(0).Columns("onPromo").Header.Caption = "on Promo"
                    Me.grdList.DisplayLayout.Bands(0).Columns("PromoFrom").Header.Caption = "Promo From"
                    Me.grdList.DisplayLayout.Bands(0).Columns("PromoTo").Header.Caption = "Promo To"
                    Me.grdList.DisplayLayout.Bands(0).Columns("PromoPrice").Header.Caption = "Price"
                    Me.grdList.DisplayLayout.Bands(0).Columns("PromoStockLimit").Header.Caption = "Stock Limit"
                    Me.grdList.DisplayLayout.Bands(0).Columns("PromoStockSold").Header.Caption = "Stock Sold"
                    Me.grdList.DisplayLayout.Bands(0).Columns("PromoStockAvailable").Header.Caption = "Stock Available"
                    '''''''''''''''''''''Cell Activation'''''''''''''''''''''
                    Me.grdList.DisplayLayout.Bands(0).Columns("Code").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                    Me.grdList.DisplayLayout.Bands(0).Columns("ItemCode").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                    Me.grdList.DisplayLayout.Bands(0).Columns("ItemName").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                    Me.grdList.DisplayLayout.Bands(0).Columns("onPromo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                    Me.grdList.DisplayLayout.Bands(0).Columns("PromoFrom").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                    Me.grdList.DisplayLayout.Bands(0).Columns("PromoTo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                    Me.grdList.DisplayLayout.Bands(0).Columns("PromoPrice").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                    Me.grdList.DisplayLayout.Bands(0).Columns("PromoStockLimit").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                    Me.grdList.DisplayLayout.Bands(0).Columns("PromoStockSold").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                    Me.grdList.DisplayLayout.Bands(0).Columns("PromoStockAvailable").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                    '''''''''''''''''''''Perform Auto Resize'''''''''''''''''''''
                    Me.grdList.DisplayLayout.Bands(0).Columns("Code").PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
                    Me.grdList.DisplayLayout.Bands(0).Columns("ItemCode").PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
                    Me.grdList.DisplayLayout.Bands(0).Columns("ItemName").PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
                    Me.grdList.DisplayLayout.Bands(0).Columns("onPromo").PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
                    Me.grdList.DisplayLayout.Bands(0).Columns("PromoFrom").PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
                    Me.grdList.DisplayLayout.Bands(0).Columns("PromoTo").PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
                    Me.grdList.DisplayLayout.Bands(0).Columns("PromoPrice").PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
                    Me.grdList.DisplayLayout.Bands(0).Columns("PromoStockLimit").PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
                    Me.grdList.DisplayLayout.Bands(0).Columns("PromoStockSold").PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
                    Me.grdList.DisplayLayout.Bands(0).Columns("PromoStockAvailable").PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
                    '''''''''''''''''''''MASK INPUT'''''''''''''''''''''
                    Me.grdList.DisplayLayout.Bands(0).Columns("PromoFrom").MaskInput = Mask_Date
                    Me.grdList.DisplayLayout.Bands(0).Columns("PromoTo").MaskInput = Mask_Date
                    Me.grdList.DisplayLayout.Bands(0).Columns("PromoPrice").MaskInput = Mask_Amount
                    Me.grdList.DisplayLayout.Bands(0).Columns("PromoStockLimit").MaskInput = Mask_Amount
                    Me.grdList.DisplayLayout.Bands(0).Columns("PromoStockSold").MaskInput = Mask_Amount
                    Me.grdList.DisplayLayout.Bands(0).Columns("PromoStockAvailable").MaskInput = Mask_Amount
                    '''''''''''''''''''''FORMAT'''''''''''''''''''''
                    Me.grdList.DisplayLayout.Bands(0).Columns("PromoFrom").Format = "dd/MM/yyyy"
                    Me.grdList.DisplayLayout.Bands(0).Columns("PromoTo").Format = "dd/MM/yyyy"
                    '''''''''''''''''''''Perform Auto Resize'''''''''''''''''''''

                Case Table.D_Counter

                    Me.grdList.DisplayLayout.Bands(0).Columns("Code").Header.Caption = "Code"
                    Me.grdList.DisplayLayout.Bands(0).Columns("Title").Header.Caption = "Cost Center"
                    Me.grdList.DisplayLayout.Bands(0).Columns("LastDate").Header.Caption = "Last Bill Date"
                    Me.grdList.DisplayLayout.Bands(0).Columns("BillNumber").Header.Caption = "Last Bill #"

                    Me.grdList.DisplayLayout.Bands(0).Columns("Code").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                    Me.grdList.DisplayLayout.Bands(0).Columns("Title").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                    Me.grdList.DisplayLayout.Bands(0).Columns("LastDate").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                    Me.grdList.DisplayLayout.Bands(0).Columns("BillNumber").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

                    Me.grdList.DisplayLayout.Bands(0).Columns("Code").Header.VisiblePosition = 0
                    Me.grdList.DisplayLayout.Bands(0).Columns("Title").Header.VisiblePosition = 1
                    Me.grdList.DisplayLayout.Bands(0).Columns("LastDate").Header.VisiblePosition = 2
                    Me.grdList.DisplayLayout.Bands(0).Columns("BillNumber").Header.VisiblePosition = 3

                    Me.grdList.DisplayLayout.Bands(0).Columns("Code").TabStop = False
                    Me.grdList.DisplayLayout.Bands(0).Columns("Title").TabStop = True
                    Me.grdList.DisplayLayout.Bands(0).Columns("LastDate").TabStop = False
                    Me.grdList.DisplayLayout.Bands(0).Columns("BillNumber").TabStop = False

                    Me.grdList.DisplayLayout.Bands(0).Columns("Title").TabIndex = 0

                    Me.grdList.DisplayLayout.Bands(0).Columns("Title").Tag = "LAST"

                    Me.grdList.DisplayLayout.Bands(0).Columns("Code").PerformAutoResize()
                    Me.grdList.DisplayLayout.Bands(0).Columns("Title").PerformAutoResize()
                    Me.grdList.DisplayLayout.Bands(0).Columns("LastDate").PerformAutoResize()
                    Me.grdList.DisplayLayout.Bands(0).Columns("BillNumber").PerformAutoResize()


                Case Table.D_UMCType

                    Me.grdList.DisplayLayout.Bands(0).Columns("Code").Header.Caption = "Code"
                    Me.grdList.DisplayLayout.Bands(0).Columns("Title").Header.Caption = "UMC Type"
                    Me.grdList.DisplayLayout.Bands(0).Columns("Base").Header.Caption = "Base UMC Type"
                    Me.grdList.DisplayLayout.Bands(0).Columns("BaseRate").Header.Caption = "Base Rate"

                    Me.grdList.DisplayLayout.Bands(0).Columns("Code").CellActivation = UltraWinGrid.Activation.NoEdit
                    Me.grdList.DisplayLayout.Bands(0).Columns("Title").CellActivation = UltraWinGrid.Activation.AllowEdit
                    Me.grdList.DisplayLayout.Bands(0).Columns("Base").CellActivation = UltraWinGrid.Activation.AllowEdit
                    Me.grdList.DisplayLayout.Bands(0).Columns("BaseRate").CellActivation = UltraWinGrid.Activation.AllowEdit

                    Me.grdList.DisplayLayout.Bands(0).Columns("Code").Header.VisiblePosition = 0
                    Me.grdList.DisplayLayout.Bands(0).Columns("Title").Header.VisiblePosition = 1
                    Me.grdList.DisplayLayout.Bands(0).Columns("Base").Header.VisiblePosition = 2
                    Me.grdList.DisplayLayout.Bands(0).Columns("BaseRate").Header.VisiblePosition = 3

                    Me.grdList.DisplayLayout.Bands(0).Columns("Code").TabStop = False
                    Me.grdList.DisplayLayout.Bands(0).Columns("Title").TabStop = True
                    Me.grdList.DisplayLayout.Bands(0).Columns("Base").TabStop = True
                    Me.grdList.DisplayLayout.Bands(0).Columns("BaseRate").TabStop = True

                    Me.grdList.DisplayLayout.Bands(0).Columns("Title").TabIndex = 0
                    Me.grdList.DisplayLayout.Bands(0).Columns("Base").TabIndex = 0
                    Me.grdList.DisplayLayout.Bands(0).Columns("BaseRate").TabIndex = 0

                    Me.grdList.DisplayLayout.Bands(0).Columns("BaseRate").Tag = "LAST"

                    Me.grdList.DisplayLayout.Bands(0).Columns("Code").PerformAutoResize()
                    Me.grdList.DisplayLayout.Bands(0).Columns("Title").PerformAutoResize()
                    Me.grdList.DisplayLayout.Bands(0).Columns("Base").PerformAutoResize()
                    Me.grdList.DisplayLayout.Bands(0).Columns("BaseRate").PerformAutoResize()

                    FillDrop(Me.DropData, "Title", "Code", Table.D_UMCType)
                    Me.grdList.DisplayLayout.Bands(0).Columns("Base").EditorControl = Me.DropData


                Case Table.Reward

                    Me.grdList.DisplayLayout.Bands(0).Columns("Code").Header.Caption = "Code"
                    Me.grdList.DisplayLayout.Bands(0).Columns("ItemCode").Header.Caption = "Item"
                    Me.grdList.DisplayLayout.Bands(0).Columns("RewardPoint").Header.Caption = "Reward Point"

                    Me.grdList.DisplayLayout.Bands(0).Columns("Code").CellActivation = UltraWinGrid.Activation.NoEdit
                    Me.grdList.DisplayLayout.Bands(0).Columns("ItemCode").CellActivation = UltraWinGrid.Activation.AllowEdit
                    Me.grdList.DisplayLayout.Bands(0).Columns("RewardPoint").CellActivation = UltraWinGrid.Activation.AllowEdit

                    Me.grdList.DisplayLayout.Bands(0).Columns("Code").Header.VisiblePosition = 0
                    Me.grdList.DisplayLayout.Bands(0).Columns("ItemCode").Header.VisiblePosition = 1
                    Me.grdList.DisplayLayout.Bands(0).Columns("RewardPoint").Header.VisiblePosition = 2

                    Me.grdList.DisplayLayout.Bands(0).Columns("Code").TabStop = False
                    Me.grdList.DisplayLayout.Bands(0).Columns("ItemCode").TabStop = True
                    Me.grdList.DisplayLayout.Bands(0).Columns("RewardPoint").TabStop = True

                    Me.grdList.DisplayLayout.Bands(0).Columns("ItemCode").TabIndex = 0
                    Me.grdList.DisplayLayout.Bands(0).Columns("RewardPoint").TabIndex = 1


                    Me.grdList.DisplayLayout.Bands(0).Columns("Code").PerformAutoResize()
                    Me.grdList.DisplayLayout.Bands(0).Columns("ItemCode").PerformAutoResize()
                    Me.grdList.DisplayLayout.Bands(0).Columns("RewardPoint").PerformAutoResize()

                    Me.grdList.DisplayLayout.Bands(0).Columns("ItemCode").Width = 250
                    Me.grdList.DisplayLayout.Bands(0).Columns("RewardPoint").Width = 100

                    If CLS_Config.SearchByBarcode Then
                        If CLS_Config.Company = ZAHRABAKALA Then
                            FillDropByQuery(Me.DropData, "ItemName", "Code", "SELECT Code, COALESCE(BarCode,'') + ' - ' + COALESCE(ItemName,'') AS ItemName,BarCode,BarCode2,ItemType FROM ITEM  WHERE (COALESCE(CostPrice, 0) > 0) AND  COALESCE(Discontinued,0)=0  ORDER BY BarCode,ItemName")
                        Else
                            FillDropByQuery(Me.DropData, "ItemName", "Code", "SELECT Code, COALESCE(BarCode,'') + ' - ' + COALESCE(ItemName,'') AS ItemName,BarCode,BarCode2,ItemType FROM ITEM WHERE  COALESCE(Discontinued,0)=0  ORDER BY BarCode,ItemName")
                        End If

                        Me.DropData.DisplayLayout.Bands(0).Columns("BarCode").Hidden = True
                        Me.DropData.DisplayLayout.Bands(0).Columns("BarCode2").Hidden = True
                        Me.DropData.DisplayLayout.Bands(0).Columns("ItemType").Hidden = True

                    Else
                        If CLS_Config.Company = ZAHRABAKALA Then
                            FillDropByQuery(Me.DropData, "ItemName", "Code", "SELECT Code, ItemName,BarCode,BarCode2,ItemType FROM ITEM  WHERE (COALESCE(CostPrice, 0) > 0) AND  COALESCE(Discontinued,0)=0  ORDER BY ItemName")
                            Me.DropData.DisplayLayout.Bands(0).Columns("BarCode").Hidden = True
                            Me.DropData.DisplayLayout.Bands(0).Columns("BarCode2").Hidden = True
                            Me.DropData.DisplayLayout.Bands(0).Columns("ItemType").Hidden = True
                        Else
                            FillDropByQuery(Me.DropData, "ItemName", "Code", "SELECT Code, ItemName,BarCode,BarCode2,ItemType FROM ITEM  WHERE COALESCE(Discontinued,0)=0  ORDER BY ItemName")

                            Me.DropData.DisplayLayout.Bands(0).Columns("BarCode").Hidden = True
                            Me.DropData.DisplayLayout.Bands(0).Columns("BarCode2").Hidden = True
                            Me.DropData.DisplayLayout.Bands(0).Columns("ItemType").Hidden = True

                        End If
                    End If

                    Me.DropData.DisplayLayout.Bands(0).Columns("ItemName").Width = 500
                    Me.DropData.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn

                    Me.grdList.DisplayLayout.Bands(0).Columns("ItemCode").EditorControl = Me.DropData





                Case Table.D_ItemCategory, Table.D_ItemSubCategory

                    Me.grdList.DisplayLayout.Bands(0).Columns("Code").Header.Caption = "Code"
                    Select Case TableName
                        Case Table.D_ItemCategory : Me.grdList.DisplayLayout.Bands(0).Columns("Title").Header.Caption = "Item Category"
                        Case Table.D_ItemSubCategory : Me.grdList.DisplayLayout.Bands(0).Columns("Title").Header.Caption = "Item Sub Category"
                    End Select

                    Me.grdList.DisplayLayout.Bands(0).Columns("Code").CellActivation = UltraWinGrid.Activation.NoEdit
                    Me.grdList.DisplayLayout.Bands(0).Columns("Title").CellActivation = UltraWinGrid.Activation.AllowEdit

                    Me.grdList.DisplayLayout.Bands(0).Columns("Code").Header.VisiblePosition = 0
                    Me.grdList.DisplayLayout.Bands(0).Columns("Title").Header.VisiblePosition = 1

                    Me.grdList.DisplayLayout.Bands(0).Columns("Code").TabStop = False
                    Me.grdList.DisplayLayout.Bands(0).Columns("Title").TabStop = True

                    Me.grdList.DisplayLayout.Bands(0).Columns("Title").TabIndex = 0

                    Me.grdList.DisplayLayout.Bands(0).Columns("Title").Tag = "LAST"

                    Me.grdList.DisplayLayout.Bands(0).Columns("Code").PerformAutoResize()
                    Me.grdList.DisplayLayout.Bands(0).Columns("Title").PerformAutoResize()


                Case Table.Account


                    Select Case AccountType
                        Case CodeModule.AccountType.Employee

                            Me.grdList.DisplayLayout.Bands(0).Columns("AccountNum").Header.Caption = "AccountNum"
                            Me.grdList.DisplayLayout.Bands(0).Columns("Title").Header.Caption = "Employee Name"
                            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").Header.Caption = "Notes"
                            Me.grdList.DisplayLayout.Bands(0).Columns("Salary").Header.Caption = "Salary"
                            Me.grdList.DisplayLayout.Bands(0).Columns("PassportNo").Header.Caption = "Passport No"
                            Me.grdList.DisplayLayout.Bands(0).Columns("PassportExp").Header.Caption = "Passport Exp"
                            Me.grdList.DisplayLayout.Bands(0).Columns("CivilID").Header.Caption = "Civil ID"
                            Me.grdList.DisplayLayout.Bands(0).Columns("CivilIDExp").Header.Caption = "Civil ID Exp"
                            Me.grdList.DisplayLayout.Bands(0).Columns("HealthCardNo").Header.Caption = "Health Card No"
                            Me.grdList.DisplayLayout.Bands(0).Columns("HealthCardExp").Header.Caption = "Health Card Exp"
                            Me.grdList.DisplayLayout.Bands(0).Columns("OpeningBalance").Header.Caption = "Opening Balance"


                            Me.grdList.DisplayLayout.Bands(0).Columns("AccountNum").Header.VisiblePosition = 0
                            Me.grdList.DisplayLayout.Bands(0).Columns("Title").Header.VisiblePosition = 1
                            Me.grdList.DisplayLayout.Bands(0).Columns("Salary").Header.VisiblePosition = 2
                            Me.grdList.DisplayLayout.Bands(0).Columns("Telephone").Header.VisiblePosition = 3
                            Me.grdList.DisplayLayout.Bands(0).Columns("Mobile").Header.VisiblePosition = 4
                            Me.grdList.DisplayLayout.Bands(0).Columns("PassportNo").Header.VisiblePosition = 5
                            Me.grdList.DisplayLayout.Bands(0).Columns("PassportExp").Header.VisiblePosition = 6
                            Me.grdList.DisplayLayout.Bands(0).Columns("CivilID").Header.VisiblePosition = 7
                            Me.grdList.DisplayLayout.Bands(0).Columns("CivilIDExp").Header.VisiblePosition = 8
                            Me.grdList.DisplayLayout.Bands(0).Columns("HealthCardNo").Header.VisiblePosition = 9
                            Me.grdList.DisplayLayout.Bands(0).Columns("HealthCardExp").Header.VisiblePosition = 10
                            Me.grdList.DisplayLayout.Bands(0).Columns("OpeningBalance").Header.VisiblePosition = 11
                            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").Header.VisiblePosition = 12

                            Me.grdList.DisplayLayout.Bands(0).Columns("AccountNum").TabStop = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("Title").TabStop = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("Salary").TabStop = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("Telephone").TabStop = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("Mobile").TabStop = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("PassportNo").TabStop = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("PassportExp").TabStop = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("CivilID").TabStop = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("CivilIDExp").TabStop = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("HealthCardNo").TabStop = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("HealthCardExp").TabStop = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("OpeningBalance").TabStop = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").TabStop = True

                            Me.grdList.DisplayLayout.Bands(0).Columns("Code").Hidden = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("AccountType").Hidden = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("TimeLimit").Hidden = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("AmountLimit").Hidden = True

                            Me.grdList.DisplayLayout.Bands(0).Columns("AccountNum").TabIndex = 0
                            Me.grdList.DisplayLayout.Bands(0).Columns("Title").TabIndex = 1
                            Me.grdList.DisplayLayout.Bands(0).Columns("Salary").TabIndex = 2
                            Me.grdList.DisplayLayout.Bands(0).Columns("Telephone").TabIndex = 3
                            Me.grdList.DisplayLayout.Bands(0).Columns("Mobile").TabIndex = 4
                            Me.grdList.DisplayLayout.Bands(0).Columns("PassportNo").TabIndex = 5
                            Me.grdList.DisplayLayout.Bands(0).Columns("PassportExp").TabIndex = 6
                            Me.grdList.DisplayLayout.Bands(0).Columns("CivilID").TabIndex = 7
                            Me.grdList.DisplayLayout.Bands(0).Columns("CivilIDExp").TabIndex = 8
                            Me.grdList.DisplayLayout.Bands(0).Columns("HealthCardNo").TabIndex = 9
                            Me.grdList.DisplayLayout.Bands(0).Columns("HealthCardExp").TabIndex = 10
                            Me.grdList.DisplayLayout.Bands(0).Columns("OpeningBalance").TabIndex = 11
                            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").TabIndex = 12


                            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").Tag = "LAST"

                            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").Width = 200

                            Me.grdList.DisplayLayout.Bands(0).Columns("AccountNum").PerformAutoResize()
                            Me.grdList.DisplayLayout.Bands(0).Columns("Title").PerformAutoResize()
                            Me.grdList.DisplayLayout.Bands(0).Columns("Telephone").PerformAutoResize()
                            Me.grdList.DisplayLayout.Bands(0).Columns("Mobile").PerformAutoResize()
                            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").PerformAutoResize()
                            Me.grdList.DisplayLayout.Bands(0).Columns("Salary").PerformAutoResize()
                            Me.grdList.DisplayLayout.Bands(0).Columns("PassportNo").PerformAutoResize()
                            Me.grdList.DisplayLayout.Bands(0).Columns("PassportExp").PerformAutoResize()
                            Me.grdList.DisplayLayout.Bands(0).Columns("CivilID").PerformAutoResize()
                            Me.grdList.DisplayLayout.Bands(0).Columns("CivilIDExp").PerformAutoResize()
                            Me.grdList.DisplayLayout.Bands(0).Columns("HealthCardNo").PerformAutoResize()
                            Me.grdList.DisplayLayout.Bands(0).Columns("HealthCardExp").PerformAutoResize()
                            Me.grdList.DisplayLayout.Bands(0).Columns("OpeningBalance").PerformAutoResize()


                            Me.grdList.DisplayLayout.Bands(0).Columns("PassportExp").MaskInput = "{LOC}dd/mm/yyyy"
                            Me.grdList.DisplayLayout.Bands(0).Columns("CivilIDExp").MaskInput = "{LOC}dd/mm/yyyy"
                            Me.grdList.DisplayLayout.Bands(0).Columns("HealthCardExp").MaskInput = "{LOC}dd/mm/yyyy"




                        Case CodeModule.AccountType.Customer

                            Me.grdList.DisplayLayout.Bands(0).Columns("AccountNum").Header.Caption = "AccountNum"
                            Me.grdList.DisplayLayout.Bands(0).Columns("Title").Header.Caption = "Customer Name"
                            Me.grdList.DisplayLayout.Bands(0).Columns("TimeLimit").Header.Caption = "Time Limit"
                            Me.grdList.DisplayLayout.Bands(0).Columns("AmountLimit").Header.Caption = "Amount Limit"
                            Me.grdList.DisplayLayout.Bands(0).Columns("Telephone").Header.Caption = "Telephone"
                            Me.grdList.DisplayLayout.Bands(0).Columns("Mobile").Header.Caption = "Mobile"
                            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").Header.Caption = "Notes"


                            Me.grdList.DisplayLayout.Bands(0).Columns("AccountNum").Header.VisiblePosition = 0
                            Me.grdList.DisplayLayout.Bands(0).Columns("Title").Header.VisiblePosition = 1
                            Me.grdList.DisplayLayout.Bands(0).Columns("TimeLimit").Header.VisiblePosition = 2
                            Me.grdList.DisplayLayout.Bands(0).Columns("AmountLimit").Header.VisiblePosition = 3
                            Me.grdList.DisplayLayout.Bands(0).Columns("Telephone").Header.VisiblePosition = 4
                            Me.grdList.DisplayLayout.Bands(0).Columns("Mobile").Header.VisiblePosition = 5
                            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").Header.VisiblePosition = 6

                            Me.grdList.DisplayLayout.Bands(0).Columns("AccountNum").TabStop = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("Title").TabStop = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("TimeLimit").TabStop = False
                            Me.grdList.DisplayLayout.Bands(0).Columns("AmountLimit").TabStop = False
                            Me.grdList.DisplayLayout.Bands(0).Columns("Telephone").TabStop = False
                            Me.grdList.DisplayLayout.Bands(0).Columns("Mobile").TabStop = False
                            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").TabStop = True

                            Me.grdList.DisplayLayout.Bands(0).Columns("Code").Hidden = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("AccountType").Hidden = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("Salary").Hidden = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("PassportNo").Hidden = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("PassportExp").Hidden = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("CivilID").Hidden = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("CivilIDExp").Hidden = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("HealthCardNo").Hidden = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("HealthCardExp").Hidden = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("OpeningBalance").Hidden = True

                            Me.grdList.DisplayLayout.Bands(0).Columns("AccountNum").TabIndex = 0
                            Me.grdList.DisplayLayout.Bands(0).Columns("Title").TabIndex = 1
                            Me.grdList.DisplayLayout.Bands(0).Columns("TimeLimit").TabIndex = 2
                            Me.grdList.DisplayLayout.Bands(0).Columns("AmountLimit").TabIndex = 3
                            Me.grdList.DisplayLayout.Bands(0).Columns("Telephone").TabIndex = 4
                            Me.grdList.DisplayLayout.Bands(0).Columns("Mobile").TabIndex = 5
                            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").TabIndex = 6

                            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").Tag = "LAST"

                            Me.grdList.DisplayLayout.Bands(0).Columns("Title").Width = 200
                            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").Width = 400

                            Me.grdList.DisplayLayout.Bands(0).Columns("AccountNum").PerformAutoResize()
                            'Me.grdList.DisplayLayout.Bands(0).Columns("Title").PerformAutoResize()
                            Me.grdList.DisplayLayout.Bands(0).Columns("TimeLimit").PerformAutoResize()
                            Me.grdList.DisplayLayout.Bands(0).Columns("AmountLimit").PerformAutoResize()
                            Me.grdList.DisplayLayout.Bands(0).Columns("Telephone").PerformAutoResize()
                            Me.grdList.DisplayLayout.Bands(0).Columns("Mobile").PerformAutoResize()
                            'Me.grdList.DisplayLayout.Bands(0).Columns("Notes").PerformAutoResize()


                        Case Else

                            Me.grdList.DisplayLayout.Bands(0).Columns("AccountNum").Header.Caption = "AccountNum"
                            Select Case AccountType
                                'Case AccountType.Asset : Me.grdList.DisplayLayout.Bands(0).Columns("Title").Header.Caption = "Assets Name"
                                Case AccountType.Customer
                                    Me.grdList.DisplayLayout.Bands(0).Columns("Title").Header.Caption = "Customer Name"
                                    Me.grdList.DisplayLayout.Bands(0).Columns("TimeLimit").Hidden = False
                                    Me.grdList.DisplayLayout.Bands(0).Columns("AmountLimit").Hidden = False
                                Case AccountType.Expenses : Me.grdList.DisplayLayout.Bands(0).Columns("Title").Header.Caption = "Expenses Name"
                                    'Case AccountType.Libilities : Me.grdList.DisplayLayout.Bands(0).Columns("Title").Header.Caption = "Libilities Name"
                                    'Case AccountType.Revenue : Me.grdList.DisplayLayout.Bands(0).Columns("Title").Header.Caption = "Revenue Name"
                                Case AccountType.Stock : Me.grdList.DisplayLayout.Bands(0).Columns("Title").Header.Caption = "Stock Name"
                                Case AccountType.Supplier : Me.grdList.DisplayLayout.Bands(0).Columns("Title").Header.Caption = "Supplier Name"
                                Case AccountType.Cash : Me.grdList.DisplayLayout.Bands(0).Columns("Title").Header.Caption = "Cash Name"
                                Case AccountType.Bank : Me.grdList.DisplayLayout.Bands(0).Columns("Title").Header.Caption = "Bank Name"
                            End Select
                            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").Header.Caption = "Notes"

                            Me.grdList.DisplayLayout.Bands(0).Columns("AccountNum").Header.VisiblePosition = 0
                            Me.grdList.DisplayLayout.Bands(0).Columns("Title").Header.VisiblePosition = 1
                            Me.grdList.DisplayLayout.Bands(0).Columns("Telephone").Header.VisiblePosition = 2
                            Me.grdList.DisplayLayout.Bands(0).Columns("Mobile").Header.VisiblePosition = 3
                            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").Header.VisiblePosition = 4

                            Me.grdList.DisplayLayout.Bands(0).Columns("AccountNum").TabStop = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("Title").TabStop = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").TabStop = True

                            Me.grdList.DisplayLayout.Bands(0).Columns("Code").Hidden = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("AccountType").Hidden = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("Salary").Hidden = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("PassportNo").Hidden = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("PassportExp").Hidden = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("CivilID").Hidden = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("CivilIDExp").Hidden = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("HealthCardNo").Hidden = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("HealthCardExp").Hidden = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("OpeningBalance").Hidden = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("TimeLimit").Hidden = True
                            Me.grdList.DisplayLayout.Bands(0).Columns("AmountLimit").Hidden = True

                            Me.grdList.DisplayLayout.Bands(0).Columns("AccountNum").TabIndex = 0
                            Me.grdList.DisplayLayout.Bands(0).Columns("Title").TabIndex = 1
                            Me.grdList.DisplayLayout.Bands(0).Columns("Telephone").TabIndex = 2
                            Me.grdList.DisplayLayout.Bands(0).Columns("Mobile").TabIndex = 3
                            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").TabIndex = 4

                            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").Tag = "LAST"

                            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").Width = 200

                            Me.grdList.DisplayLayout.Bands(0).Columns("AccountNum").PerformAutoResize()
                            Me.grdList.DisplayLayout.Bands(0).Columns("Title").PerformAutoResize()
                            Me.grdList.DisplayLayout.Bands(0).Columns("Telephone").PerformAutoResize()
                            Me.grdList.DisplayLayout.Bands(0).Columns("Mobile").PerformAutoResize()
                            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").PerformAutoResize()


                    End Select


            End Select


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
            Select Case tblName
                Case Table.Membership
                    Me.Text = "Membership"
                Case Table.V_Promotion
                    Me.Text = "Promotion List"
                Case Table.D_Counter
                    Me.Text = "Counter List"
                Case Table.D_ItemCategory
                    Me.Text = "Item Category List"
                Case Table.D_ItemSubCategory
                    Me.Text = "Item Sub Category List"
                Case Table.Reward
                    Me.Text = "Reward"
                Case Table.D_UMCType
                    Me.Text = "UMC Type List"
                Case Table.Account
                    Select Case AccountType
                        'Case AccountType.Assets : Me.Text = "Assets List"
                        Case AccountType.Customer : Me.Text = "Customer List"
                        Case AccountType.Expenses : Me.Text = "Expenses List"
                            'Case AccountType.Libilities : Me.Text = "Libilities List"
                            'Case AccountType.Revenue : Me.Text = "Revenue List"
                        Case AccountType.Stock : Me.Text = "Stock List"
                        Case AccountType.Supplier : Me.Text = "Supplier List"
                        Case AccountType.Cash : Me.Text = "Cash List"
                        Case AccountType.Bank : Me.Text = "Bank List"
                        Case AccountType.Employee : Me.Text = "Employee List"
                    End Select

            End Select

        Catch ex As Exception
            MSG.ErrorOk("[SetFormTitle]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub Add()
        Try
            Me.grdList.DisplayLayout.Bands(0).AddNew()
            btnNew.Enabled = False
            btnDelete.Enabled = False
            Modi = False

        Catch ex As Exception
            MSG.ErrorOk("[Add]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub Save()
        Try
            FillMissingFields()
            Me.grdList.UpdateData()
            If IsValid() Then
                Me.grdList.UpdateData()
                DBO.UpdateDataTable(m_tableName, DT)
                Me.btnNew.Enabled = True
                Me.btnDelete.Enabled = True
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
            Me.btnNew.Enabled = True
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
                i = MSG.WarnYesNo("Are you sure you want ot delete selected record?", 2)
                If i = MsgBoxResult.Yes Then

                    Select Case tblName
                        Case Table.V_Promotion

                            Dim Code As Integer = TrimInt(Me.grdList.ActiveRow.Cells("Code").Value)

                            Using CONTEXT = New POSEntities
                                Dim Promo As New Promotion
                                Promo = (From q In CONTEXT.Promotions Where q.Code = Code Select q).ToList.FirstOrDefault
                                If IsDBNull(Promo) OrElse IsNothing(Promo) Then
                                Else
                                    CONTEXT.Promotions.DeleteObject(Promo)
                                End If
                                CONTEXT.SaveChanges()
                            End Using

                            PromoRefresh()
                            FillGrid()
                            SetGridLayout()

                        Case Else
                            Me.grdList.ActiveRow.Delete(False)
                            Save()
                    End Select
                Else
                End If
            End If
        Catch ex As Exception
            MSG.ErrorOk("[Delete]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Function IsValid() As Boolean
        Try
            Select Case TableName
                Case Table.Reward

                    Dim ItemCodeList As New List(Of Integer)

                    Dim Row As UltraGridRow
                    For Each Row In Me.grdList.Rows
                        If Row.IsDataRow AndAlso Not Row.IsEmptyRow AndAlso Not Row.IsUnmodifiedTemplateAddRow Then
                            Me.grdList.PerformAction(UltraGridAction.ExitEditMode, False, False)

                            Dim ItemCode As Integer = TrimInt(Row.Cells("ItemCode").Value)

                            If ItemCode = Nothing Then
                                MsgBox("Item Name missing", MsgBoxStyle.Information)
                                Me.grdList.ActiveCell = Row.Cells("ItemCode")
                                Me.grdList.PerformAction(UltraGridAction.EnterEditMode)
                                Return False
                            End If

                            If ItemCodeList.Contains(ItemCode) Then
                                MsgBox("Item Name already used", MsgBoxStyle.Information)
                                Me.grdList.ActiveCell = Row.Cells("ItemCode")
                                Me.grdList.PerformAction(UltraGridAction.EnterEditMode)
                                Return False
                            End If

                            ItemCodeList.Add(ItemCode)

                                If TrimInt(Row.Cells("RewardPoint").Value) = Nothing Then
                                    MsgBox("RewardPoint missing", MsgBoxStyle.Information)
                                    Me.grdList.ActiveCell = Row.Cells("RewardPoint")
                                    Me.grdList.PerformAction(UltraGridAction.EnterEditMode)
                                    Return False
                                End If

                            End If


                    Next

                Case Else
                    Dim i As Integer = 0
                    Dim r As Integer = 0

                    For r = 0 To Me.grdList.DisplayLayout.Bands(0).Columns.Count - 1
                        For i = 0 To Me.grdList.Rows.Count - 1
                            Select Case Me.grdList.DisplayLayout.Bands(0).Columns(r).Key
                                Case "RewardPoint"
                                    If FixCellNumber(Me.grdList.Rows(i).Cells("RewardPoint")) = Nothing Then
                                        MsgBox("Reward Point is missing.")
                                        Me.grdList.Rows(i).Cells("RewardPoint").Activate()
                                        Me.grdList.PerformAction(UltraGridAction.EnterEditMode, False, False)
                                        Return False
                                    End If
                                Case "Title"
                                    If FixCellString(Me.grdList.Rows(i).Cells("Title")) = "" Then
                                        MsgBox(Me.grdList.DisplayLayout.Bands(0).Columns("Title").Header.Caption & " missing.")
                                        Me.grdList.Rows(i).Cells("Title").Activate()
                                        Me.grdList.PerformAction(UltraGridAction.EnterEditMode, False, False)
                                        Return False
                                    End If
                                Case "Salary"
                                    If AccountType = CodeModule.AccountType.Employee Then
                                        If FixCellString(Me.grdList.Rows(i).Cells("Salary")) = "" Then
                                            MsgBox("Employee salary is missing.")
                                            Me.grdList.Rows(i).Cells("Salary").Activate()
                                            Me.grdList.PerformAction(UltraGridAction.EnterEditMode, False, False)
                                            Return False
                                        End If
                                    End If
                                Case "AccountNum"
                                    If FixCellString(Me.grdList.Rows(i).Cells("AccountNum")) = "" Then
                                        MsgBox("Account Number missing.")
                                        Me.grdList.Rows(i).Cells("AccountNum").Activate()
                                        Me.grdList.PerformAction(UltraGridAction.EnterEditMode, False, False)

                                        Return False
                                    End If

                                    Dim Code As Integer = FixCellNumber(Me.grdList.Rows(i).Cells("Code"))
                                    Dim AccountNum As String = FixCellString(Me.grdList.Rows(i).Cells("AccountNum"))
                                    Dim AccountType As Integer = FixCellNumber(Me.grdList.Rows(i).Cells("AccountType"))

                                    If Code = Nothing Then Code = 0
                                    If AccountNum = Nothing Then AccountNum = "0"
                                    If AccountType = Nothing Then AccountType = 0

                                    Dim Exists As Boolean = False
                                    Dim Para As New ArrayList
                                    Para.Add(Code)
                                    Para.Add(AccountNum)
                                    Para.Add(AccountType)
                                    Exists = DBO.ExecuteSP_ReturnSingleValue("AccountNumExists", Para)
                                    If Exists Then
                                        MsgBox("Account Number already in use.")
                                        Me.grdList.Rows(i).Cells("AccountNum").Activate()
                                        Me.grdList.PerformAction(UltraGridAction.EnterEditMode, False, False)
                                        Return False
                                    End If

                            End Select
                        Next
                    Next
            End Select



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

    Private Sub ReturnCode()
        Try
            Select Case TableName
                Case Table.Account
                    If AccountType = CodeModule.AccountType.Customer Then

                        If IsDBNull(Me.grdList.ActiveRow) Or IsNothing(Me.grdList.ActiveRow) Then
                            MSG.ErrorOk("Select Account first")
                            Exit Sub
                        End If

                        If FixCellString(Me.grdList.ActiveRow.Cells("AccountNum")) = Nothing Then
                            MSG.ErrorOk("Select Account first")
                            Exit Sub
                        End If

                        Find_Str = FixCellString(Me.grdList.ActiveRow.Cells("AccountNum"))

                        Me.Close()

                    End If

                Case Table.Membership


                    If IsDBNull(Me.grdList.ActiveRow) Or IsNothing(Me.grdList.ActiveRow) Then
                        MSG.ErrorOk("Select Recoord first")
                        Exit Sub
                    End If

                    If FixCellString(Me.grdList.ActiveRow.Cells("Code")) = Nothing Then
                        MSG.ErrorOk("Select Recoord first")
                        Exit Sub
                    End If

                    Find_Int = FixCellNumber(Me.grdList.ActiveRow.Cells("Code"))

                    Me.Close()

            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub grdList_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles grdList.DoubleClickCell
        Try
            Select Case TableName
                Case Table.V_Promotion

                    Dim FRM As New frmItem(TrimInt(Me.grdList.ActiveRow.Cells("ItemCode").Value))
                    FRM.ShowDialog()
                    btnRefresh_Click(sender, e)

                Case Else
                    ReturnCode()

            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub frmDynamicList_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, grdList.KeyUp
        If e.KeyCode = Keys.End Then btnExit_Click(sender, e)
    End Sub
    Private Sub frmDynamicList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            SetFormTitle()
            FillGrid()
            SetGridLayout()
            SetFontSize()

            Dim mapping As New GridKeyActionMapping(Keys.Enter, UltraGridAction.NextCellByTab, DirectCast(0, UltraGridState), UltraGridState.InEdit, SpecialKeys.All, DirectCast(0, SpecialKeys))
            Me.grdList.KeyActionMappings.Add(mapping)

            If TableName = Table.D_ItemCategory AndAlso CLS_Config.ShowImage Then
                gbxImage.Visible = True
            Else
                gbxImage.Visible = False
            End If

            Me.txtSearch.Focus()
            Me.txtSearch.SelectAll()


        Catch ex As Exception
            MSG.ErrorOk("[frmDynamicList_Load]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub picIcon_Click(sender As Object, e As EventArgs) Handles picIcon.Click
        Try
            Dim Code As Integer = TrimInt(Me.grdList.ActiveRow.Cells("Code").Value)
            If Code = 0 Then Exit Sub

            Dim OpenDialog As New System.Windows.Forms.OpenFileDialog
            OpenDialog.Title = "Select Category Image."
            OpenDialog.Filter = "(*.jpg)|*.jpg"
            Dim result As DialogResult = OpenDialog.ShowDialog()
            If OpenDialog.FileName <> "" Then
                If result = Windows.Forms.DialogResult.OK Then
                    Dim fname As String = OpenDialog.FileName
                    'Me.PicBox.Image = GetPhoto(fname)
                    Dim ImageName As String = Nothing
                    ImageName = CategoryImagePath & Code & ".jpg"
                    If CategoryImagePath <> Nothing AndAlso CategoryImagePath <> Nothing Then
                        File.Copy(fname, ImageName, True)
                        Me.picIcon.Image = Load_Img(ImageName)
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub grdList_AfterRowActivate(sender As Object, e As EventArgs) Handles grdList.AfterRowActivate
        Try
            If Not CLS_Config.ShowImage Then Exit Sub
            If TableName <> Table.D_ItemCategory Then Exit Sub

            Dim Code As Integer = TrimInt(Me.grdList.ActiveRow.Cells("Code").Value)
            If Code = 0 Then
                Me.picIcon.Image = My.Resources.no_picture
                Exit Sub
            End If

            Dim ImageName As String = Nothing
            ImageName = CategoryImagePath & Code & ".jpg"
            If ItemImagePath <> Nothing AndAlso CategoryImagePath <> Nothing Then
                If File.Exists(ImageName) Then
                    Me.picIcon.Image = Load_Img(ImageName)
                Else
                    Me.picIcon.Image = My.Resources.no_picture
                End If
            Else
                Me.picIcon.Image = My.Resources.no_picture
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub frmDynamicList_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            frmDynamicListIns = Nothing
        Catch ex As Exception
            MSG.ErrorOk("[frmDynamicList_FormClosed]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Add()
    End Sub
    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Delete()
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
    Private Sub grdList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdList.KeyDown
        Try

            If e.KeyCode = Keys.Tab Then
                If Me.grdList.ActiveCell.Tag = "LAST" Then Add()
            End If


            If e.KeyCode = Keys.Enter AndAlso TableName = Table.Reward Then

                If IsNothing(Me.grdList.ActiveRow) Then Exit Sub
                If IsDBNull(Me.grdList.ActiveCell) OrElse IsNothing(Me.grdList.ActiveCell) Then Exit Sub
                If Me.grdList.ActiveCell.Column.Key <> "ItemCode" Then Exit Sub
                Dim CLS_Item As New Item

                If IsDBNull(Me.grdList.ActiveCell.Value) Or IsNothing(Me.grdList.ActiveCell.Value) Then
                ElseIf Me.grdList.ActiveCell.Value = Nothing Then
                Else

                    CLS_Item = New Item
                    CLS_Item = Get_Item(CStr(Me.grdList.ActiveCell.Value))
                    If IsNothing(CLS_Item) Then
                        MsgBox("Item Dose Not Exists")
                    Else
                        Me.grdList.ActiveCell.Value = CLS_Item.Code
                        'SendKeys.Send("{TAB}")
                        'Me.grdList.ActiveCell = Me.grdList.ActiveRow.Cells("RewardPoint")
                        'Me.grdList.PerformAction(UltraGridAction.EnterEditMode)
                    End If
                    Exit Sub
                End If


                If IsDBNull(Me.grdList.ActiveCell.Text) Or IsNothing(Me.grdList.ActiveCell.Text) Then
                Else
                    CLS_Item = New Item
                    CLS_Item = Get_Item(CStr(Me.grdList.ActiveCell.Text))
                    'Dim ItemCode As Integer = Nothing
                    If IsNothing(CLS_Item) Then
                        MsgBox("Item Dose Not Exists")
                    Else
                        Me.grdList.ActiveCell.Value = CLS_Item.Code
                        'Me.grdList.ActiveCell = Me.grdList.ActiveRow.Cells("RewardPoint")
                        'Me.grdList.PerformAction(UltraGridAction.EnterEditMode)
                    End If
                End If
            End If

            If e.KeyCode = Keys.Enter Then ReturnCode()

        Catch ex As Exception
            MsgBox("grdList_KeyDown" & vbCrLf & vbCrLf & ex.Message)
            If Not IsNothing(ex.InnerException) Then MsgBox(ex.InnerException.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Function Get_Item(ByVal Barcode As String) As Item
        Try
            Dim DT As New DataTable
            DT = Me.DropData.DataSource

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
                CLS.Barcode = IIf(IsDBNull(dr2(0).Item("Barcode")), 0, dr2(0).Item("Barcode"))
                CLS.Barcode2 = IIf(IsDBNull(dr2(0).Item("Barcode2")), 0, dr2(0).Item("Barcode2"))
                CLS.ItemType = IIf(IsDBNull(dr2(0).Item("ItemType")), ItemType.StandardItem, dr2(0).Item("ItemType"))
                Return CLS
            End If

            'IF BARCODE2 EXIST IN DS LOAD & RETURN CLS
            Dim dr1() As DataRow = DT.Select(" ItemName='" & Barcode & "'")
            If dr1.Length > 0 Then
                CLS.Code = IIf(IsDBNull(dr1(0).Item("Code")), 0, dr1(0).Item("Code"))
                CLS.ItemName = IIf(IsDBNull(dr1(0).Item("ItemName")), 0, dr1(0).Item("ItemName"))
                CLS.Barcode = IIf(IsDBNull(dr1(0).Item("Barcode")), 0, dr1(0).Item("Barcode"))
                CLS.Barcode2 = IIf(IsDBNull(dr1(0).Item("Barcode2")), 0, dr1(0).Item("Barcode2"))
                CLS.ItemType = IIf(IsDBNull(dr1(0).Item("ItemType")), ItemType.StandardItem, dr1(0).Item("ItemType"))
                Return CLS

            End If

            'IF BARCODE IS NOT CODE RETURN EMPTY CLS
            Return Nothing
        Catch ex As Exception
            MSG.ErrorOk("[Get_Item]" & vbCrLf & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Sub grdList_AfterRowInsert(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles grdList.AfterRowInsert
        Try
            Select Case TableName
                Case Table.D_Counter, Table.D_ItemCategory, Table.D_ItemSubCategory
                    e.Row.Cells("Title").Activate()
                Case Table.Account
                    e.Row.Cells("AccountType").Value = AccountType
                    e.Row.Cells("AccountNum").Activate()
                    e.Row.Cells("Salary").Value = 0
                    e.Row.Cells("OpeningBalance").Value = 0
            End Select
            Me.grdList.PerformAction(UltraGridAction.EnterEditMode, False, False)

        Catch ex As Exception
            MSG.ErrorOk("[grdList_AfterRowInsert]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub grdList_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles grdList.InitializeRow
        Try
            'e.Row.Cells("Title").Activate()
            'Me.grdList.PerformAction(EnterEditMode)
            'e.Row.Cells("Title").SelectAll()
        Catch ex As Exception
            MSG.ErrorOk("[grdList_InitializeRow]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub grdList_AfterRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles grdList.AfterRowUpdate
        'Save()
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
            e.DefaultLogicalPageLayoutInfo.PageHeader = Me.Text & " List"
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
            e.DefaultLogicalPageLayoutInfo.PageHeader = Me.Text & " List"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
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
        e.Layout.Bands(0).Columns(0).FilterOperandStyle = FilterOperandStyle.DropDownList

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




    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Try
            Select Case TableName
                Case Table.V_Promotion
                    PromoRefresh()
            End Select

            FillGrid()
            SetGridLayout()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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
                Me.grdList.DisplayLayout.Bands(0).ColumnFilters(0).FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Contains, txtSearch.Value)

            Else
                srch = False
            End If

            Try
                Me.grdList.Rows.GetRowAtVisibleIndex(1).Activated = True
                Me.grdList.Rows.GetRowAtVisibleIndex(1).Selected = True
            Catch ex As Exception
            End Try


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
                    Select Case COL.Key
                        Case "LastSaleDate", "LastPurchaseDate"
                            If COL.Hidden = False Then
                                FC = New FilterCondition(band.Columns(COL.Key), FilterComparisionOperator.Like, Me.txtSearch.Value)
                                FCList.Add(FC)
                            End If
                        Case Else
                            If COL.Hidden = False Then
                                FC = New FilterCondition(band.Columns(COL.Key), FilterComparisionOperator.Like, "*" & Me.txtSearch.Value & "*")
                                FCList.Add(FC)
                            End If
                    End Select
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