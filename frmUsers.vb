Imports POS.FixControls
Imports POS.ClassContainer

Public Class frmUsers
    Implements IDataEntry
#Region "Member Variables"
    Dim CLS_UserDB As New P_UserDB
    Dim CLS_User As New P_UserDetails
    Private m_modi As Boolean = False
    Private m_tableName As String = Table.P_User
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

            PARA.Add(FixControl(LoginName))
            PARA.Add(FixControl(Pass))
            PARA.Add(FixControl(UserName))
            PARA.Add(FixControl(Designation))
            PARA.Add(FixControl(IsAdmin))
            PARA.Add(FixControl(CanAdjustStock))
            PARA.Add(FixControl(Allow_Item))
            PARA.Add(FixControl(Allow_Files))
            PARA.Add(FixControl(Allow_Subscription_Add))
            PARA.Add(FixControl(Allow_Subscription_Delete))
            PARA.Add(FixControl(Allow_Subscription_Pay))
            PARA.Add(FixControl(Allow_Users))
            PARA.Add(FixControl(Allow_Salary))
            PARA.Add(FixControl(Allow_POS))
            PARA.Add(FixControl(Allow_Sale_Edit))
            PARA.Add(FixControl(Allow_Sale_Delete))
            PARA.Add(FixControl(Allow_Sale_Detail_Delete))
            PARA.Add(FixControl(Allow_Purchase))
            PARA.Add(FixControl(Allow_Purchase_Add))
            PARA.Add(FixControl(Allow_Purchase_Edit))
            PARA.Add(FixControl(Allow_Purchase_Delete))
            PARA.Add(FixControl(Allow_Purchase_Print))
            PARA.Add(FixControl(Allow_Purchase_Pay))
            PARA.Add(FixControl(Allow_Purchase_Unpost))
            PARA.Add(FixControl(Allow_Account_Supplier))
            PARA.Add(FixControl(Allow_Account_Customer))
            PARA.Add(FixControl(Allow_Account_Cash))
            PARA.Add(FixControl(Allow_Account_Bank))
            PARA.Add(FixControl(Allow_Account_Owners))
            PARA.Add(FixControl(Allow_Account_OtherRev))
            PARA.Add(FixControl(Allow_Account_Exp))
            PARA.Add(FixControl(Allow_Account_Voucher))
            PARA.Add(FixControl(Allow_Statement_Customer))
            PARA.Add(FixControl(Allow_Statement_Supplier))
            PARA.Add(FixControl(Allow_Statement_Cash))
            PARA.Add(FixControl(Allow_Statement_Bank))
            PARA.Add(FixControl(Allow_Statement_Owner))
            PARA.Add(FixControl(Allow_Statement_OtherRev))
            PARA.Add(FixControl(Allow_Statement_Exp))
            PARA.Add(FixControl(Rpt_DailySummary))
            PARA.Add(FixControl(Rpt_SalesSearch))
            PARA.Add(FixControl(Rpt_SalesReports))
            PARA.Add(FixControl(Rpt_InventoryReports))
            PARA.Add(FixControl(Rpt_ItemReports))
            PARA.Add(FixControl(Rpt_CustomerReports))
            PARA.Add(FixControl(Rpt_Alert))
            PARA.Add(FixControl(Rpt_Subscription))
            PARA.Add(FixControl(Rpt_PurchaseReport))
            PARA.Add(FixControl(Allow_Customer_Pay_Dis))
            PARA.Add(FixControl(Allow_Customer_Pay_Delete))
            PARA.Add(FixControl(Allow_Print_Barcode))
            PARA.Add(FixControl(Allow_Quotation))
            PARA.Add(FixControl(Allow_MembershipAdd))
            PARA.Add(FixControl(Allow_MembershipEdit))
            PARA.Add(FixControl(Allow_MembershipDelete))
            PARA.Add(FixControl(Allow_MembershipRedeem))
            PARA.Add(FixControl(Allow_MembershipPrint))

            Me.Code.Value = DBO.ExecuteSP_ReturnInteger("P_UserInsert", PARA)

            Return True
        Catch ex As System.Exception
            MSG.ErrorOk("[Add]" & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function Adding() As Boolean Implements IDataEntry.Adding

    End Function
    Public Function CanSave() As Boolean Implements IDataEntry.CanSave

    End Function
    Public Sub Clear() Implements IDataEntry.Clear
        Try
            Me.Code.Value = Nothing
            Me.LoginName.Value = Nothing
            Me.Pass.Value = Nothing
            Me.confirmPass.Value = Nothing
            Me.UserName.Value = Nothing
            Me.Designation.Value = Nothing
            Me.IsAdmin.Checked = False
            Me.CanAdjustStock.Checked = False
            Me.Allow_Item.Checked = False
            Me.Allow_Files.Checked = False
            Me.Allow_Subscription_Add.Checked = False
            Me.Allow_Subscription_Delete.Checked = False
            Me.Allow_Subscription_Pay.Checked = False
            Me.Allow_Users.Checked = False
            Me.Allow_Salary.Checked = False
            Me.Allow_POS.Checked = False
            Me.Allow_Sale_Edit.Checked = False
            Me.Allow_Sale_Delete.Checked = False
            Me.Allow_Sale_Detail_Delete.Checked = False
            Me.Allow_Purchase.Checked = False
            Me.Allow_Purchase_Add.Checked = False
            Me.Allow_Purchase_Edit.Checked = False
            Me.Allow_Purchase_Delete.Checked = False
            Me.Allow_Purchase_Print.Checked = False
            Me.Allow_Purchase_Pay.Checked = False
            Me.Allow_Purchase_Unpost.Checked = False
            Me.Allow_Account_Supplier.Checked = False
            Me.Allow_Account_Customer.Checked = False
            Me.Allow_Account_Cash.Checked = False
            Me.Allow_Account_Bank.Checked = False
            Me.Allow_Account_Owners.Checked = False
            Me.Allow_Account_OtherRev.Checked = False
            Me.Allow_Account_Exp.Checked = False
            Me.Allow_Account_Voucher.Checked = False
            Me.Allow_Statement_Customer.Checked = False
            Me.Allow_Statement_Supplier.Checked = False
            Me.Allow_Statement_Cash.Checked = False
            Me.Allow_Statement_Bank.Checked = False
            Me.Allow_Statement_Owner.Checked = False
            Me.Allow_Statement_OtherRev.Checked = False
            Me.Allow_Statement_Exp.Checked = False
            Me.Rpt_DailySummary.Checked = False
            Me.Rpt_SalesSearch.Checked = False
            Me.Rpt_SalesReports.Checked = False
            Me.Rpt_InventoryReports.Checked = False
            Me.Rpt_ItemReports.Checked = False
            Me.Rpt_CustomerReports.Checked = False
            Me.Rpt_Alert.Checked = False
            Me.Rpt_Subscription.Checked = False
            Me.Rpt_PurchaseReport.Checked = False
            Me.Allow_Customer_Pay_Dis.Checked = False
            Me.Allow_Customer_Pay_Delete.Checked = False
            Me.Allow_Print_Barcode.Checked = False
            Me.Allow_Quotation.Checked = False
            Me.Allow_MembershipAdd.Checked = False
            Me.Allow_MembershipEdit.Checked = False
            Me.Allow_MembershipDelete.Checked = False
            Me.Allow_MembershipRedeem.Checked = False
            Me.Allow_MembershipPrint.Checked = False

        Catch ex As Exception
            MsgBox("Clear" & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub ComboNavi() Implements IDataEntry.ComboNavi

    End Sub
    Public Sub Counter() Implements IDataEntry.Counter

    End Sub
    Public Sub DataLen() Implements IDataEntry.DataLen

    End Sub
    Public Function Delete() As Boolean Implements IDataEntry.Delete
        Try
            Dim PARA As New ArrayList

            PARA.Add(FixControl(Code))
            Return CBool(DBO.ExecuteSP_ReturnInteger("P_UserDelete", PARA))

        Catch ex As Exception

        End Try
    End Function
    Public Function Deleting() As Boolean Implements IDataEntry.Deleting

    End Function
    Public Function Edit() As Boolean Implements IDataEntry.Edit
        Try

            Dim PARA As New ArrayList

            PARA.Add(FixControl(Code))
            PARA.Add(FixControl(LoginName))
            PARA.Add(FixControl(Pass))
            PARA.Add(FixControl(UserName))
            PARA.Add(FixControl(Designation))
            PARA.Add(FixControl(IsAdmin))
            PARA.Add(FixControl(CanAdjustStock))
            PARA.Add(FixControl(Allow_Item))
            PARA.Add(FixControl(Allow_Files))
            PARA.Add(FixControl(Allow_Subscription_Add))
            PARA.Add(FixControl(Allow_Subscription_Delete))
            PARA.Add(FixControl(Allow_Subscription_Pay))
            PARA.Add(FixControl(Allow_Users))
            PARA.Add(FixControl(Allow_Salary))
            PARA.Add(FixControl(Allow_POS))
            PARA.Add(FixControl(Allow_Sale_Edit))
            PARA.Add(FixControl(Allow_Sale_Delete))
            PARA.Add(FixControl(Allow_Sale_Detail_Delete))
            PARA.Add(FixControl(Allow_Purchase))
            PARA.Add(FixControl(Allow_Purchase_Add))
            PARA.Add(FixControl(Allow_Purchase_Edit))
            PARA.Add(FixControl(Allow_Purchase_Delete))
            PARA.Add(FixControl(Allow_Purchase_Print))
            PARA.Add(FixControl(Allow_Purchase_Pay))
            PARA.Add(FixControl(Allow_Purchase_Unpost))
            PARA.Add(FixControl(Allow_Account_Supplier))
            PARA.Add(FixControl(Allow_Account_Customer))
            PARA.Add(FixControl(Allow_Account_Cash))
            PARA.Add(FixControl(Allow_Account_Bank))
            PARA.Add(FixControl(Allow_Account_Owners))
            PARA.Add(FixControl(Allow_Account_OtherRev))
            PARA.Add(FixControl(Allow_Account_Exp))
            PARA.Add(FixControl(Allow_Account_Voucher))
            PARA.Add(FixControl(Allow_Statement_Customer))
            PARA.Add(FixControl(Allow_Statement_Supplier))
            PARA.Add(FixControl(Allow_Statement_Cash))
            PARA.Add(FixControl(Allow_Statement_Bank))
            PARA.Add(FixControl(Allow_Statement_Owner))
            PARA.Add(FixControl(Allow_Statement_OtherRev))
            PARA.Add(FixControl(Allow_Statement_Exp))
            PARA.Add(FixControl(Rpt_DailySummary))
            PARA.Add(FixControl(Rpt_SalesSearch))
            PARA.Add(FixControl(Rpt_SalesReports))
            PARA.Add(FixControl(Rpt_InventoryReports))
            PARA.Add(FixControl(Rpt_ItemReports))
            PARA.Add(FixControl(Rpt_CustomerReports))
            PARA.Add(FixControl(Rpt_Alert))
            PARA.Add(FixControl(Rpt_Subscription))
            PARA.Add(FixControl(Rpt_PurchaseReport))
            PARA.Add(FixControl(Allow_Customer_Pay_Dis))
            PARA.Add(FixControl(Allow_Customer_Pay_Delete))
            PARA.Add(FixControl(Allow_Print_Barcode))
            PARA.Add(FixControl(Allow_Quotation))
            PARA.Add(FixControl(Allow_MembershipAdd))
            PARA.Add(FixControl(Allow_MembershipEdit))
            PARA.Add(FixControl(Allow_MembershipDelete))
            PARA.Add(FixControl(Allow_MembershipRedeem))
            PARA.Add(FixControl(Allow_MembershipPrint))

            DBO.ExecuteSP("P_UserUpdate", PARA)

            Return True
        Catch ex As System.Exception
            MSG.ErrorOk("[Edit]" & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function Editing() As Boolean Implements IDataEntry.Editing

    End Function
    Public Sub FillDrops() Implements IDataEntry.FillDrops
        FillDrop(Me.DropUser, "UserName", "Code", Table.P_User)
    End Sub
    Public Sub FillGrid() Implements IDataEntry.FillGrid

    End Sub
    Public Sub GridNavi() Implements IDataEntry.GridNavi

    End Sub
    Public Sub LoadCodes() Implements IDataEntry.LoadCodes

    End Sub
    Public Sub LoadData(ByVal code As Integer) Implements IDataEntry.LoadData
        Try
            Dim Para As New ArrayList
            Para.Add(FixObjectNumber(code))

            Dim DT As DataTable
            DT = DBO.ExecuteSP_ReturnDataTable("P_UserSelect", Para)
            If IsDBNull(DT) Or IsNothing(DT) Then Exit Try
            If DT.Rows.Count = 0 Then Exit Try

            m_modi = True

            Me.Code.Value = FixObjectNumber(DT.Rows(0).Item("Code"))
            Me.LoginName.Value = FixObjectString(DT.Rows(0).Item("LoginName"))
            Me.Pass.Value = FixObjectString(DT.Rows(0).Item("Pass"))
            Me.confirmPass.Value = FixObjectString(DT.Rows(0).Item("Pass"))
            Me.UserName.Value = FixObjectString(DT.Rows(0).Item("UserName"))
            Me.Designation.Value = FixObjectString(DT.Rows(0).Item("Designation"))
            Me.IsAdmin.Checked = FixObjectBoolean(DT.Rows(0).Item("IsAdmin"))
            Me.CanAdjustStock.Checked = FixObjectBoolean(DT.Rows(0).Item("CanAdjustStock"))
            Me.Allow_Item.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_Item"))
            Me.Allow_Files.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_Files"))
            Me.Allow_Subscription_Add.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_Subscription_Add"))
            Me.Allow_Subscription_Delete.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_Subscription_Delete"))
            Me.Allow_Subscription_Pay.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_Subscription_Pay"))
            Me.Allow_Users.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_Users"))
            Me.Allow_Salary.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_Salary"))
            Me.Allow_POS.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_POS"))
            Me.Allow_Sale_Edit.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_Sale_Edit"))
            Me.Allow_Sale_Delete.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_Sale_Delete"))
            Me.Allow_Sale_Detail_Delete.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_Sale_Detail_Delete"))
            Me.Allow_Purchase.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_Purchase"))
            Me.Allow_Purchase_Add.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_Purchase_Add"))
            Me.Allow_Purchase_Edit.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_Purchase_Edit"))
            Me.Allow_Purchase_Delete.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_Purchase_Delete"))
            Me.Allow_Purchase_Print.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_Purchase_Print"))
            Me.Allow_Purchase_Pay.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_Purchase_Pay"))
            Me.Allow_Purchase_Unpost.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_Purchase_Unpost"))
            Me.Allow_Account_Supplier.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_Account_Supplier"))
            Me.Allow_Account_Customer.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_Account_Customer"))
            Me.Allow_Account_Cash.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_Account_Cash"))
            Me.Allow_Account_Bank.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_Account_Bank"))
            Me.Allow_Account_Owners.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_Account_Owners"))
            Me.Allow_Account_OtherRev.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_Account_OtherRev"))
            Me.Allow_Account_Exp.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_Account_Exp"))
            Me.Allow_Account_Voucher.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_Account_Voucher"))
            Me.Allow_Statement_Customer.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_Statement_Customer"))
            Me.Allow_Statement_Supplier.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_Statement_Supplier"))
            Me.Allow_Statement_Cash.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_Statement_Cash"))
            Me.Allow_Statement_Bank.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_Statement_Bank"))
            Me.Allow_Statement_Owner.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_Statement_Owner"))
            Me.Allow_Statement_OtherRev.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_Statement_OtherRev"))
            Me.Allow_Statement_Exp.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_Statement_Exp"))
            Me.Rpt_DailySummary.Checked = FixObjectBoolean(DT.Rows(0).Item("Rpt_DailySummary"))
            Me.Rpt_SalesSearch.Checked = FixObjectBoolean(DT.Rows(0).Item("Rpt_SalesSearch"))
            Me.Rpt_SalesReports.Checked = FixObjectBoolean(DT.Rows(0).Item("Rpt_SalesReports"))
            Me.Rpt_InventoryReports.Checked = FixObjectBoolean(DT.Rows(0).Item("Rpt_InventoryReports"))
            Me.Rpt_ItemReports.Checked = FixObjectBoolean(DT.Rows(0).Item("Rpt_ItemReports"))
            Me.Rpt_CustomerReports.Checked = FixObjectBoolean(DT.Rows(0).Item("Rpt_CustomerReports"))
            Me.Rpt_Alert.Checked = FixObjectBoolean(DT.Rows(0).Item("Rpt_Alert"))
            Me.Rpt_Subscription.Checked = FixObjectBoolean(DT.Rows(0).Item("Rpt_Subscription"))
            Me.Rpt_PurchaseReport.Checked = FixObjectBoolean(DT.Rows(0).Item("Rpt_PurchaseReport"))
            Me.Allow_Customer_Pay_Dis.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_Customer_Pay_Dis"))
            Me.Allow_Customer_Pay_Delete.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_Customer_Pay_Delete"))
            Me.Allow_Print_Barcode.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_Print_Barcode"))
            Me.Allow_Quotation.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_Quotation"))
            Me.Allow_MembershipAdd.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_MembershipAdd"))
            Me.Allow_MembershipEdit.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_MembershipEdit"))
            Me.Allow_MembershipDelete.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_MembershipDelete"))
            Me.Allow_MembershipRedeem.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_MembershipRedeem"))
            Me.Allow_MembershipPrint.Checked = FixObjectBoolean(DT.Rows(0).Item("Allow_MembershipPrint"))

        Catch ex As Exception
            MsgBox("LoadData" & vbCrLf & ex.Message)
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
        Clear()
        m_modi = False
        Me.UserName.Focus()
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
#Region "Events"
    Private Sub frmUsers_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, DropUser.KeyUp
        Select Case e.KeyCode
            Case Keys.End, Keys.Escape
                Me.Close()
        End Select
    End Sub
    Private Sub frmUsers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FillDrops()
            Clear()
            Me.DropUser.Focus()

        Catch ex As Exception
            MSG.ErrorOk("[frmUsers_Load]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub DropUser_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropUser.ValueChanged
        Try
            If IsDBNull(Me.DropUser.Value) Or IsNothing(Me.DropUser.Value) Then Exit Sub
            If Me.DropUser.Value = Nothing Then Exit Sub

            LoadData(Me.DropUser.Value)

        Catch ex As Exception
            MsgBox("DropSupplier_ValueChanged" & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region
#Region " BUTTON CLICK EVENT "
    Private Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        [New]()
    End Sub
    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If FixControl(Me.DropUser) = Nothing Then
            MsgBox("Select user first")
            Exit Sub
        End If

        If MsgBox("Are you sure you want to delete user " & vbCrLf & vbCrLf & FixControl(Me.UserName), MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub

        If Delete() Then
            FillDrops()
            Me.Clear()
            Me.DropUser.Value = Nothing
            Me.DropUser.Focus()
        Else
            MSG.ErrorOk("Select user can not be deleted.")
        End If
    End Sub
    Private Sub btnUndo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUndo.Click
        Try
            Clear()
            If FixControl(Me.DropUser) = Nothing Then Exit Sub
            LoadData(FixControl(Me.DropUser))
            Me.DropUser.Focus()

        Catch ex As Exception
            MSG.ErrorOk("[btnUndo_Click]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If m_modi Then Edit()
            If Not m_modi Then Add()

            FillDrops()

            If m_modi Then
                If Me.DropUser.Value = UserClass.Code Then
                    UserClass = CLS_UserDB.LogIn(Me.UserName.Value, Me.Pass.Value)
                End If
            End If

            m_modi = True
            Me.DropUser.Value = Me.Code.Value

            Me.DropUser.Focus()

        Catch ex As Exception
            MSG.ErrorOk("[btnSave_Click]" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
#End Region

End Class