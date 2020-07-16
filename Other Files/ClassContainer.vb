Imports POS.FixControls
Imports System.IO
Imports System.Data
Imports System.Data.Odbc

Public Class ClassContainer

    Public Class P_UserDetails
        Public Code As System.Int32
        Public LoginName As System.String
        Public Pass As System.String
        Public UserName As System.String
        Public Designation As System.String
        Public IsAdmin As System.Boolean
        Public CanAdjustStock As System.Boolean
        Public Allow_Item As System.Boolean
        Public Allow_Files As System.Boolean
        Public Allow_Subscription_Add As System.Boolean
        Public Allow_Subscription_Delete As System.Boolean
        Public Allow_Subscription_Pay As System.Boolean
        Public Allow_Users As System.Boolean
        Public Allow_Salary As System.Boolean
        Public Allow_POS As System.Boolean
        Public Allow_Sale_Edit As System.Boolean
        Public Allow_Sale_Delete As System.Boolean
        Public Allow_Sale_Detail_Delete As System.Boolean
        Public Allow_Purchase As System.Boolean
        Public Allow_Purchase_Add As System.Boolean
        Public Allow_Purchase_Edit As System.Boolean
        Public Allow_Purchase_Delete As System.Boolean
        Public Allow_Purchase_Print As System.Boolean
        Public Allow_Purchase_Pay As System.Boolean
        Public Allow_Purchase_Unpost As System.Boolean
        Public Allow_Account_Supplier As System.Boolean
        Public Allow_Account_Customer As System.Boolean
        Public Allow_Account_Cash As System.Boolean
        Public Allow_Account_Bank As System.Boolean
        Public Allow_Account_Owners As System.Boolean
        Public Allow_Account_OtherRev As System.Boolean
        Public Allow_Account_Exp As System.Boolean
        Public Allow_Account_Voucher As System.Boolean
        Public Allow_Statement_Customer As System.Boolean
        Public Allow_Statement_Supplier As System.Boolean
        Public Allow_Statement_Cash As System.Boolean
        Public Allow_Statement_Bank As System.Boolean
        Public Allow_Statement_Owner As System.Boolean
        Public Allow_Statement_OtherRev As System.Boolean
        Public Allow_Statement_Exp As System.Boolean
        Public Rpt_DailySummary As System.Boolean
        Public Rpt_SalesSearch As System.Boolean
        Public Rpt_SalesReports As System.Boolean
        Public Rpt_InventoryReports As System.Boolean
        Public Rpt_ItemReports As System.Boolean
        Public Rpt_CustomerReports As System.Boolean
        Public Rpt_Alert As System.Boolean
        Public Rpt_Subscription As System.Boolean
        Public Rpt_PurchaseReport As System.Boolean
        Public Allow_Customer_Pay_Dis As System.Boolean
        Public Allow_Customer_Pay_Delete As System.Boolean
        Public Allow_Print_Barcode As System.Boolean
        Public Allow_Quotation As System.Boolean
        Public Allow_MembershipAdd As System.Boolean
        Public Allow_MembershipEdit As System.Boolean
        Public Allow_MembershipDelete As System.Boolean
        Public Allow_MembershipRedeem As System.Boolean
        Public Allow_MembershipPrint As System.Boolean
    End Class

    Public Class P_UserDB
        'Public Function Delete(ByVal [Code] As System.Int32) As Boolean
        '    Try
        '        Dim COM As New Odbc.OdbcCommand()
        '        Dim CON As New Odbc.OdbcConnection()
        '        CON.ConnectionString = mvarConnectString
        '        CON.Open()

        '        COM.CommandText = "{ CALL P_UserDelete(" & ParameterQuestions(1) & ") }" '"dbo.P_UserDelete"
        '        COM.CommandType = CommandType.StoredProcedure
        '        COM.Parameters.Add(New Odbc.OdbcParameter("@Code", OdbcType.Int, 4)).Value = CType(Code, System.Int32)
        '        ' COM.Parameters.Add(New Odbc.OdbcParameter("@LoginName", OdbcType.varchar, 50)).Value = CType(P_User_Details.LoginName, System.String)
        '        ' COM.Parameters.Add(New Odbc.OdbcParameter("@Pass", OdbcType.varchar, 50)).Value = CType(P_User_Details.Pass, System.String)
        '        ' COM.Parameters.Add(New Odbc.OdbcParameter("@UserName", OdbcType.varchar, 50)).Value = CType(P_User_Details.UserName, System.String)
        '        ' COM.Parameters.Add(New Odbc.OdbcParameter("@Designation", OdbcType.varchar, 50)).Value = CType(P_User_Details.Designation, System.String)
        '        ' COM.Parameters.Add(New Odbc.OdbcParameter("@AllowStoreMgt", OdbcType.bit, 1)).Value = CType(P_User_Details.AllowStoreMgt, System.Boolean)
        '        ' COM.Parameters.Add(New Odbc.OdbcParameter("@AllowPOS", OdbcType.bit, 1)).Value = CType(P_User_Details.AllowPOS, System.Boolean)

        '        COM.Connection = CON
        '        COM.ExecuteNonQuery()

        '        CON.Close()
        '        CON.Dispose()

        '        COM.Dispose()
        '        Return True
        '    Catch ex As System.Exception
        '        Throw New System.Exception("[Delete]" & ERR_MESSAGE, ex)
        '    End Try
        'End Function
        'Public Function [Select](ByVal [Code] As System.Int32) As P_UserDetails
        '    Try
        '        Dim COM As New Odbc.OdbcCommand()
        '        Dim CON As New Odbc.OdbcConnection()
        '        Dim DA As New Odbc.OdbcDataAdapter()
        '        Dim DT As New DataTable()
        '        Dim P_User_Details As P_UserDetails
        '        CON.ConnectionString = mvarConnectString
        '        CON.Open()

        '        COM.CommandText = "{ CALL P_UserSelect(" & ParameterQuestions(1) & ") }" '"dbo.P_UserSelect"
        '        COM.CommandType = CommandType.StoredProcedure
        '        COM.Parameters.Add(New Odbc.OdbcParameter("@Code", OdbcType.Int, 4)).Value = CType(Code, System.Int32)
        '        ' COM.Parameters.Add(New Odbc.OdbcParameter("@LoginName", OdbcType.varchar, 50)).Value = CType(P_User_Details.LoginName, System.String)
        '        ' COM.Parameters.Add(New Odbc.OdbcParameter("@Pass", OdbcType.varchar, 50)).Value = CType(P_User_Details.Pass, System.String)
        '        ' COM.Parameters.Add(New Odbc.OdbcParameter("@UserName", OdbcType.varchar, 50)).Value = CType(P_User_Details.UserName, System.String)
        '        ' COM.Parameters.Add(New Odbc.OdbcParameter("@Designation", OdbcType.varchar, 50)).Value = CType(P_User_Details.Designation, System.String)
        '        ' COM.Parameters.Add(New Odbc.OdbcParameter("@AllowStoreMgt", OdbcType.bit, 1)).Value = CType(P_User_Details.AllowStoreMgt, System.Boolean)
        '        ' COM.Parameters.Add(New Odbc.OdbcParameter("@AllowPOS", OdbcType.bit, 1)).Value = CType(P_User_Details.AllowPOS, System.Boolean)
        '        COM.Connection = CON
        '        DA.SelectCommand = COM
        '        DA.Fill(DT)

        '        If (Not DT Is Nothing) AndAlso (DT.Rows.Count > 0) Then
        '            P_User_Details = New P_UserDetails
        '            P_User_Details.Code = CType(DT.Rows(0).Item("Code"), System.Int32)
        '            If Not DT.Rows(0).Item("LoginName") Is DBNull.Value Then P_User_Details.LoginName = CType(DT.Rows(0).Item("LoginName"), System.String)
        '            If Not DT.Rows(0).Item("Pass") Is DBNull.Value Then P_User_Details.Pass = CType(DT.Rows(0).Item("Pass"), System.String)
        '            If Not DT.Rows(0).Item("UserName") Is DBNull.Value Then P_User_Details.UserName = CType(DT.Rows(0).Item("UserName"), System.String)
        '            If Not DT.Rows(0).Item("Designation") Is DBNull.Value Then P_User_Details.Designation = CType(DT.Rows(0).Item("Designation"), System.String)
        '            If Not DT.Rows(0).Item("AllowStoreMgt") Is DBNull.Value Then P_User_Details.AllowStoreMgt = CType(DT.Rows(0).Item("AllowStoreMgt"), System.Boolean)
        '            If Not DT.Rows(0).Item("AllowPOS") Is DBNull.Value Then P_User_Details.AllowPOS = CType(DT.Rows(0).Item("AllowPOS"), System.Boolean)
        '            If Not DT.Rows(0).Item("IsAdmin") Is DBNull.Value Then P_User_Details.IsAdmin = CType(DT.Rows(0).Item("IsAdmin"), System.Boolean)
        '        End If

        '        CON.Close()
        '        CON.Dispose()

        '        COM.Dispose()

        '        Return P_User_Details
        '    Catch ex As System.Exception
        '        Throw New System.Exception("[Select]" & ERR_MESSAGE, ex)
        '    End Try
        'End Function
        'Public Function [Exists](ByVal [Code] As System.Int32) As Boolean
        '    Try
        '        Dim COM As New Odbc.OdbcCommand()
        '        Dim CON As New Odbc.OdbcConnection()
        '        Dim nRes As Integer
        '        CON.ConnectionString = mvarConnectString
        '        CON.Open()

        '        COM.CommandText = "{ CALL P_UserExists(" & ParameterQuestions(1) & ") }" '"dbo.P_UserExists"
        '        COM.CommandType = CommandType.StoredProcedure
        '        COM.Parameters.Add(New Odbc.OdbcParameter("@Code", OdbcType.Int, 4)).Value = CType(Code, System.Int32)
        '        ' COM.Parameters.Add(New Odbc.OdbcParameter("@LoginName", OdbcType.varchar, 50)).Value = CType(P_User_Details.LoginName, System.String)
        '        ' COM.Parameters.Add(New Odbc.OdbcParameter("@Pass", OdbcType.varchar, 50)).Value = CType(P_User_Details.Pass, System.String)
        '        ' COM.Parameters.Add(New Odbc.OdbcParameter("@UserName", OdbcType.varchar, 50)).Value = CType(P_User_Details.UserName, System.String)
        '        ' COM.Parameters.Add(New Odbc.OdbcParameter("@Designation", OdbcType.varchar, 50)).Value = CType(P_User_Details.Designation, System.String)
        '        ' COM.Parameters.Add(New Odbc.OdbcParameter("@AllowStoreMgt", OdbcType.bit, 1)).Value = CType(P_User_Details.AllowStoreMgt, System.Boolean)
        '        ' COM.Parameters.Add(New Odbc.OdbcParameter("@AllowPOS", OdbcType.bit, 1)).Value = CType(P_User_Details.AllowPOS, System.Boolean)
        '        COM.Connection = CON
        '        nRes = COM.ExecuteScalar

        '        CON.Close()
        '        CON.Dispose()

        '        COM.Dispose()

        '        Return nRes > 0
        '    Catch ex As System.Exception
        '        Throw New System.Exception("[Exists]" & ERR_MESSAGE, ex)
        '    End Try
        'End Function
        'Public Function Add(ByVal P_User_Details As P_UserDetails) As Boolean
        '    Try
        '        Dim COM As New Odbc.OdbcCommand()
        '        Dim CON As New Odbc.OdbcConnection()
        '        CON.ConnectionString = mvarConnectString
        '        CON.Open()

        '        COM.CommandText = "{ CALL P_UserInsert(" & ParameterQuestions(78) & ") }" '"dbo.P_UserInsert"
        '        COM.CommandType = CommandType.StoredProcedure
        '        COM.Parameters.Add(New Odbc.OdbcParameter("@Code", OdbcType.Int, 4)).Value = CType(P_User_Details.Code, System.Int32)
        '        COM.Parameters.Add(New Odbc.OdbcParameter("@LoginName", OdbcType.VarChar, 50)).Value = CType(P_User_Details.LoginName, System.String)
        '        COM.Parameters.Add(New Odbc.OdbcParameter("@Pass", OdbcType.VarChar, 50)).Value = CType(P_User_Details.Pass, System.String)
        '        COM.Parameters.Add(New Odbc.OdbcParameter("@UserName", OdbcType.VarChar, 50)).Value = CType(P_User_Details.UserName, System.String)
        '        COM.Parameters.Add(New Odbc.OdbcParameter("@Designation", OdbcType.VarChar, 50)).Value = CType(P_User_Details.Designation, System.String)
        '        COM.Parameters.Add(New Odbc.OdbcParameter("@AllowStoreMgt", OdbcType.Bit, 1)).Value = CType(P_User_Details.AllowStoreMgt, System.Boolean)
        '        COM.Parameters.Add(New Odbc.OdbcParameter("@AllowPOS", OdbcType.Bit, 1)).Value = CType(P_User_Details.AllowPOS, System.Boolean)
        '        COM.Parameters.Add(New Odbc.OdbcParameter("@IsAdmin", OdbcType.Bit, 1)).Value = CType(P_User_Details.AllowPOS, System.Boolean)

        '        COM.Connection = CON
        '        COM.ExecuteNonQuery()

        '        CON.Close()
        '        CON.Dispose()

        '        COM.Dispose()

        '        Return True
        '    Catch ex As System.Exception
        '        Throw New System.Exception("[Add]" & ERR_MESSAGE, ex)
        '    End Try
        'End Function
        'Public Function Update(ByVal P_User_Details As P_UserDetails) As Boolean
        '    Try
        '        Dim COM As New Odbc.OdbcCommand()
        '        Dim CON As New Odbc.OdbcConnection()
        '        CON.ConnectionString = mvarConnectString
        '        CON.Open()

        '        COM.CommandText = "{ CALL P_UserUpdate(" & ParameterQuestions(7) & ") }" '"dbo.P_UserUpdate"
        '        COM.CommandType = CommandType.StoredProcedure
        '        COM.Parameters.Add(New Odbc.OdbcParameter("@Code", OdbcType.Int, 4)).Value = CType(P_User_Details.Code, System.Int32)
        '        COM.Parameters.Add(New Odbc.OdbcParameter("@LoginName", OdbcType.VarChar, 50)).Value = CType(P_User_Details.LoginName, System.String)
        '        COM.Parameters.Add(New Odbc.OdbcParameter("@Pass", OdbcType.VarChar, 50)).Value = CType(P_User_Details.Pass, System.String)
        '        COM.Parameters.Add(New Odbc.OdbcParameter("@UserName", OdbcType.VarChar, 50)).Value = CType(P_User_Details.UserName, System.String)
        '        COM.Parameters.Add(New Odbc.OdbcParameter("@Designation", OdbcType.VarChar, 50)).Value = CType(P_User_Details.Designation, System.String)
        '        COM.Parameters.Add(New Odbc.OdbcParameter("@AllowStoreMgt", OdbcType.Bit, 1)).Value = CType(P_User_Details.AllowStoreMgt, System.Boolean)
        '        COM.Parameters.Add(New Odbc.OdbcParameter("@AllowPOS", OdbcType.Bit, 1)).Value = CType(P_User_Details.AllowPOS, System.Boolean)

        '        COM.Connection = CON
        '        COM.ExecuteNonQuery()

        '        CON.Close()
        '        CON.Dispose()

        '        COM.Dispose()

        '        Return True
        '    Catch ex As System.Exception
        '        Throw New System.Exception("[Update]" & ERR_MESSAGE, ex)
        '    End Try
        'End Function
        'Public Function List() As DataTable
        '    Try
        '        Dim COM As New Odbc.OdbcCommand()
        '        Dim CON As New Odbc.OdbcConnection()
        '        Dim DA As New Odbc.OdbcDataAdapter()
        '        Dim DT As New DataTable()
        '        CON.ConnectionString = mvarConnectString
        '        CON.Open()

        '        COM.CommandText = "dbo.P_UserList"
        '        COM.CommandType = CommandType.StoredProcedure
        '        COM.Connection = CON
        '        DA.SelectCommand = COM
        '        DA.Fill(DT)

        '        CON.Close()
        '        CON.Dispose()

        '        COM.Dispose()

        '        If (Not DT Is Nothing) AndAlso (DT.Rows.Count > 0) Then
        '            Return DT
        '        Else
        '            Return Nothing
        '        End If

        '    Catch ex As System.Exception
        '        Throw New System.Exception("[List]" & ERR_MESSAGE, ex)
        '    End Try
        'End Function
        Public Function [LogIn](ByVal [UserName] As System.String, ByVal [Pass] As System.String) As P_UserDetails
            Dim CLS As New P_UserDetails
            Try

                Dim Para As New ArrayList
                Para.Add(FixObjectString(UserName))
                Para.Add(FixObjectString(Pass))

                Dim DT As DataTable
                DT = DBO.ExecuteSP_ReturnDataTable("P_UserLogIn", Para)
                If IsDBNull(DT) Or IsNothing(DT) Then
                    MsgBox("Invalid login.")
                    Exit Try
                End If
                If DT.Rows.Count = 0 Then
                    MsgBox("Invalid Username or Password.")
                    Exit Try
                End If

                CLS = New ClassContainer.P_UserDetails
                CLS.Code = FixObjectNumber(DT.Rows(0).Item("Code"))
                CLS.LoginName = FixObjectString(DT.Rows(0).Item("LoginName"))
                CLS.Pass = FixObjectString(DT.Rows(0).Item("Pass"))
                CLS.UserName = FixObjectString(DT.Rows(0).Item("UserName"))
                CLS.Designation = FixObjectString(DT.Rows(0).Item("Designation"))
                CLS.IsAdmin = FixObjectBoolean(DT.Rows(0).Item("IsAdmin"))
                CLS.CanAdjustStock = FixObjectBoolean(DT.Rows(0).Item("CanAdjustStock"))
                CLS.Allow_Item = FixObjectBoolean(DT.Rows(0).Item("Allow_Item"))
                CLS.Allow_Files = FixObjectBoolean(DT.Rows(0).Item("Allow_Files"))
                CLS.Allow_Subscription_Add = FixObjectBoolean(DT.Rows(0).Item("Allow_Subscription_Add"))
                CLS.Allow_Subscription_Delete = FixObjectBoolean(DT.Rows(0).Item("Allow_Subscription_Delete"))
                CLS.Allow_Subscription_Pay = FixObjectBoolean(DT.Rows(0).Item("Allow_Subscription_Pay"))
                CLS.Allow_Users = FixObjectBoolean(DT.Rows(0).Item("Allow_Users"))
                CLS.Allow_Salary = FixObjectBoolean(DT.Rows(0).Item("Allow_Salary"))
                CLS.Allow_POS = FixObjectBoolean(DT.Rows(0).Item("Allow_POS"))
                CLS.Allow_Sale_Edit = FixObjectBoolean(DT.Rows(0).Item("Allow_Sale_Edit"))
                CLS.Allow_Sale_Delete = FixObjectBoolean(DT.Rows(0).Item("Allow_Sale_Delete"))
                CLS.Allow_Sale_Detail_Delete = FixObjectBoolean(DT.Rows(0).Item("Allow_Sale_Detail_Delete"))
                CLS.Allow_Purchase = FixObjectBoolean(DT.Rows(0).Item("Allow_Purchase"))
                CLS.Allow_Purchase_Add = FixObjectBoolean(DT.Rows(0).Item("Allow_Purchase_Add"))
                CLS.Allow_Purchase_Edit = FixObjectBoolean(DT.Rows(0).Item("Allow_Purchase_Edit"))
                CLS.Allow_Purchase_Delete = FixObjectBoolean(DT.Rows(0).Item("Allow_Purchase_Delete"))
                CLS.Allow_Purchase_Print = FixObjectBoolean(DT.Rows(0).Item("Allow_Purchase_Print"))
                CLS.Allow_Purchase_Pay = FixObjectBoolean(DT.Rows(0).Item("Allow_Purchase_Pay"))
                CLS.Allow_Purchase_Unpost = FixObjectBoolean(DT.Rows(0).Item("Allow_Purchase_Unpost"))
                CLS.Allow_Account_Supplier = FixObjectBoolean(DT.Rows(0).Item("Allow_Account_Supplier"))
                CLS.Allow_Account_Customer = FixObjectBoolean(DT.Rows(0).Item("Allow_Account_Customer"))
                CLS.Allow_Account_Cash = FixObjectBoolean(DT.Rows(0).Item("Allow_Account_Cash"))
                CLS.Allow_Account_Bank = FixObjectBoolean(DT.Rows(0).Item("Allow_Account_Bank"))
                CLS.Allow_Account_Owners = FixObjectBoolean(DT.Rows(0).Item("Allow_Account_Owners"))
                CLS.Allow_Account_OtherRev = FixObjectBoolean(DT.Rows(0).Item("Allow_Account_OtherRev"))
                CLS.Allow_Account_Exp = FixObjectBoolean(DT.Rows(0).Item("Allow_Account_Exp"))
                CLS.Allow_Account_Voucher = FixObjectBoolean(DT.Rows(0).Item("Allow_Account_Voucher"))
                CLS.Allow_Statement_Customer = FixObjectBoolean(DT.Rows(0).Item("Allow_Statement_Customer"))
                CLS.Allow_Statement_Supplier = FixObjectBoolean(DT.Rows(0).Item("Allow_Statement_Supplier"))
                CLS.Allow_Statement_Cash = FixObjectBoolean(DT.Rows(0).Item("Allow_Statement_Cash"))
                CLS.Allow_Statement_Bank = FixObjectBoolean(DT.Rows(0).Item("Allow_Statement_Bank"))
                CLS.Allow_Statement_Owner = FixObjectBoolean(DT.Rows(0).Item("Allow_Statement_Owner"))
                CLS.Allow_Statement_OtherRev = FixObjectBoolean(DT.Rows(0).Item("Allow_Statement_OtherRev"))
                CLS.Allow_Statement_Exp = FixObjectBoolean(DT.Rows(0).Item("Allow_Statement_Exp"))
                CLS.Rpt_DailySummary = FixObjectBoolean(DT.Rows(0).Item("Rpt_DailySummary"))
                CLS.Rpt_SalesSearch = FixObjectBoolean(DT.Rows(0).Item("Rpt_SalesSearch"))
                CLS.Rpt_SalesReports = FixObjectBoolean(DT.Rows(0).Item("Rpt_SalesReports"))
                CLS.Rpt_InventoryReports = FixObjectBoolean(DT.Rows(0).Item("Rpt_InventoryReports"))
                CLS.Rpt_ItemReports = FixObjectBoolean(DT.Rows(0).Item("Rpt_ItemReports"))
                CLS.Rpt_CustomerReports = FixObjectBoolean(DT.Rows(0).Item("Rpt_CustomerReports"))
                CLS.Rpt_Alert = FixObjectBoolean(DT.Rows(0).Item("Rpt_Alert"))
                CLS.Rpt_Subscription = FixObjectBoolean(DT.Rows(0).Item("Rpt_Subscription"))
                CLS.Rpt_PurchaseReport = FixObjectBoolean(DT.Rows(0).Item("Rpt_PurchaseReport"))
                CLS.Allow_Customer_Pay_Dis = FixObjectBoolean(DT.Rows(0).Item("Allow_Customer_Pay_Dis"))
                CLS.Allow_Customer_Pay_Delete = FixObjectBoolean(DT.Rows(0).Item("Allow_Customer_Pay_Delete"))
                CLS.Allow_Print_Barcode = FixObjectBoolean(DT.Rows(0).Item("Allow_Print_Barcode"))
                CLS.Allow_Quotation = FixObjectBoolean(DT.Rows(0).Item("Allow_Quotation"))
                CLS.Allow_MembershipAdd = FixObjectBoolean(DT.Rows(0).Item("Allow_MembershipAdd"))
                CLS.Allow_MembershipEdit = FixObjectBoolean(DT.Rows(0).Item("Allow_MembershipEdit"))
                CLS.Allow_MembershipDelete = FixObjectBoolean(DT.Rows(0).Item("Allow_MembershipDelete"))
                CLS.Allow_MembershipRedeem = FixObjectBoolean(DT.Rows(0).Item("Allow_MembershipRedeem"))
                CLS.Allow_MembershipPrint = FixObjectBoolean(DT.Rows(0).Item("Allow_MembershipPrint"))

            Catch ex As System.Exception
                MSG.ErrorOk("[LogIn]" & vbCrLf & ex.Message)
            End Try
            Return CLS
        End Function
        'Public Function [Select](ByVal Code As System.Int32) As P_UserDetails
        '    Dim CLS As New P_UserDetails
        '    Try

        '        Dim Para As New ArrayList
        '        Para.Add(FixObjectNumber(Code))

        '        Dim DT As DataTable
        '        DT = DBO.ExecuteSP_ReturnDataTable("P_UserSelect", Para)
        '        If IsDBNull(DT) Or IsNothing(DT) Then Exit Try
        '        If DT.Rows.Count = 0 Then Exit Try

        '        CLS = New ClassContainer.P_UserDetails
        '        CLS.Code = FixObjectNumber(DT.Rows(0).Item("Code"))
        '        CLS.LoginName = FixObjectString(DT.Rows(0).Item("LoginName"))
        '        CLS.Pass = FixObjectString(DT.Rows(0).Item("Pass"))
        '        CLS.UserName = FixObjectString(DT.Rows(0).Item("UserName"))
        '        CLS.Designation = FixObjectString(DT.Rows(0).Item("Designation"))
        '        CLS.IsAdmin = FixObjectBoolean(DT.Rows(0).Item("IsAdmin"))
        '        CLS.CanAdjustStock = FixObjectBoolean(DT.Rows(0).Item("CanAdjustStock"))
        '        CLS.Allow_Item = FixObjectBoolean(DT.Rows(0).Item("Allow_Item"))
        '        CLS.Allow_Files = FixObjectBoolean(DT.Rows(0).Item("Allow_Files"))
        '        CLS.Allow_Subscription_Add = FixObjectBoolean(DT.Rows(0).Item("Allow_Subscription_Add"))
        '        CLS.Allow_Subscription_Delete = FixObjectBoolean(DT.Rows(0).Item("Allow_Subscription_Delete"))
        '        CLS.Allow_Subscription_Pay = FixObjectBoolean(DT.Rows(0).Item("Allow_Subscription_Pay"))
        '        CLS.Allow_Users = FixObjectBoolean(DT.Rows(0).Item("Allow_Users"))
        '        CLS.Allow_POS = FixObjectBoolean(DT.Rows(0).Item("Allow_POS"))
        '        CLS.Allow_Purchase = FixObjectBoolean(DT.Rows(0).Item("Allow_Purchase"))
        '        CLS.Allow_Purchase_Add = FixObjectBoolean(DT.Rows(0).Item("Allow_Purchase_Add"))
        '        CLS.Allow_Purchase_Edit = FixObjectBoolean(DT.Rows(0).Item("Allow_Purchase_Edit"))
        '        CLS.Allow_Purchase_Delete = FixObjectBoolean(DT.Rows(0).Item("Allow_Purchase_Delete"))
        '        CLS.Allow_Purchase_Print = FixObjectBoolean(DT.Rows(0).Item("Allow_Purchase_Print"))
        '        CLS.Allow_Purchase_Pay = FixObjectBoolean(DT.Rows(0).Item("Allow_Purchase_Pay"))
        '        CLS.Allow_Account_Supplier = FixObjectBoolean(DT.Rows(0).Item("Allow_Account_Supplier"))
        '        CLS.Allow_Account_Customer = FixObjectBoolean(DT.Rows(0).Item("Allow_Account_Customer"))
        '        CLS.Allow_Account_Cash = FixObjectBoolean(DT.Rows(0).Item("Allow_Account_Cash"))
        '        CLS.Allow_Account_Bank = FixObjectBoolean(DT.Rows(0).Item("Allow_Account_Bank"))
        '        CLS.Allow_Account_Owners = FixObjectBoolean(DT.Rows(0).Item("Allow_Account_Owners"))
        '        CLS.Allow_Account_OtherRev = FixObjectBoolean(DT.Rows(0).Item("Allow_Account_OtherRev"))
        '        CLS.Allow_Account_Exp = FixObjectBoolean(DT.Rows(0).Item("Allow_Account_Exp"))
        '        CLS.Allow_Account_Voucher = FixObjectBoolean(DT.Rows(0).Item("Allow_Account_Voucher"))
        '        CLS.Allow_Statement_Customer = FixObjectBoolean(DT.Rows(0).Item("Allow_Statement_Customer"))
        '        CLS.Allow_Statement_Supplier = FixObjectBoolean(DT.Rows(0).Item("Allow_Statement_Supplier"))
        '        CLS.Allow_Statement_Cash = FixObjectBoolean(DT.Rows(0).Item("Allow_Statement_Cash"))
        '        CLS.Allow_Statement_Bank = FixObjectBoolean(DT.Rows(0).Item("Allow_Statement_Bank"))
        '        CLS.Allow_Statement_Owner = FixObjectBoolean(DT.Rows(0).Item("Allow_Statement_Owner"))
        '        CLS.Allow_Statement_OtherRev = FixObjectBoolean(DT.Rows(0).Item("Allow_Statement_OtherRev"))
        '        CLS.Allow_Statement_Exp = FixObjectBoolean(DT.Rows(0).Item("Allow_Statement_Exp"))
        '        CLS.Rpt_DailySummary = FixObjectBoolean(DT.Rows(0).Item("Rpt_DailySummary"))
        '        CLS.Rpt_SalesSearch = FixObjectBoolean(DT.Rows(0).Item("Rpt_SalesSearch"))
        '        CLS.Rpt_SalesReports = FixObjectBoolean(DT.Rows(0).Item("Rpt_SalesReports"))
        '        CLS.Rpt_InventoryReports = FixObjectBoolean(DT.Rows(0).Item("Rpt_InventoryReports"))
        '        CLS.Rpt_ItemReports = FixObjectBoolean(DT.Rows(0).Item("Rpt_ItemReports"))
        '        CLS.Rpt_CustomerReports = FixObjectBoolean(DT.Rows(0).Item("Rpt_CustomerReports"))
        '        CLS.Rpt_Alert = FixObjectBoolean(DT.Rows(0).Item("Rpt_Alert"))
        '        CLS.Rpt_ItemExpry = FixObjectBoolean(DT.Rows(0).Item("Rpt_ItemExpry"))
        '        CLS.Rpt_CustomerHistory = FixObjectBoolean(DT.Rows(0).Item("Rpt_CustomerHistory"))
        '        CLS.Rpt_CustomerRotation = FixObjectBoolean(DT.Rows(0).Item("Rpt_CustomerRotation"))
        '        CLS.Rpt_Subcription = FixObjectBoolean(DT.Rows(0).Item("Rpt_Subcription"))
        '        CLS.Rpt_PurchaseReport = FixObjectBoolean(DT.Rows(0).Item("Rpt_PurchaseReport"))
        '        CLS.Rpt_SupplierBalance = FixObjectBoolean(DT.Rows(0).Item("Rpt_SupplierBalance"))
        '        CLS.Rpt_DebitAge = FixObjectBoolean(DT.Rows(0).Item("Rpt_DebitAge"))

        '    Catch ex As System.Exception
        '        MSG.ErrorOk("[LogIn]" & vbCrLf & ex.Message)
        '    End Try
        '    Return CLS
        'End Function
        'Public Function UpdatePass() As Boolean
        '    Try

        '    Catch ex As Exception
        '        MsgBox("UpdatePass" & vbCrLf & ex.Message)
        '    End Try
        'End Function
        'Public Function Add(ByVal P_User_Details As P_UserDetails) As Boolean
        '    Try

        '        Dim PARA As New ArrayList

        '        PARA.Add(P_User_Details.Code)
        '        PARA.Add(P_User_Details.LoginName)
        '        PARA.Add(P_User_Details.Pass)
        '        PARA.Add(P_User_Details.UserName)
        '        PARA.Add(P_User_Details.Designation)
        '        PARA.Add(P_User_Details.IsAdmin)
        '        PARA.Add(P_User_Details.CanAdjustStock)
        '        PARA.Add(P_User_Details.Allow_Item)
        '        PARA.Add(P_User_Details.Allow_Files)
        '        PARA.Add(P_User_Details.Allow_Subscription_Add)
        '        PARA.Add(P_User_Details.Allow_Subscription_Delete)
        '        PARA.Add(P_User_Details.Allow_Subscription_Pay)
        '        PARA.Add(P_User_Details.Allow_Users)
        '        PARA.Add(P_User_Details.Allow_POS)
        '        PARA.Add(P_User_Details.Allow_Purchase)
        '        PARA.Add(P_User_Details.Allow_Purchase_Add)
        '        PARA.Add(P_User_Details.Allow_Purchase_Edit)
        '        PARA.Add(P_User_Details.Allow_Purchase_Delete)
        '        PARA.Add(P_User_Details.Allow_Purchase_Print)
        '        PARA.Add(P_User_Details.Allow_Purchase_Pay)
        '        PARA.Add(P_User_Details.Allow_Account_Supplier)
        '        PARA.Add(P_User_Details.Allow_Account_Customer)
        '        PARA.Add(P_User_Details.Allow_Account_Cash)
        '        PARA.Add(P_User_Details.Allow_Account_Bank)
        '        PARA.Add(P_User_Details.Allow_Account_Owners)
        '        PARA.Add(P_User_Details.Allow_Account_OtherRev)
        '        PARA.Add(P_User_Details.Allow_Account_Exp)
        '        PARA.Add(P_User_Details.Allow_Account_Voucher)
        '        PARA.Add(P_User_Details.Allow_Statement_Customer)
        '        PARA.Add(P_User_Details.Allow_Statement_Supplier)
        '        PARA.Add(P_User_Details.Allow_Statement_Cash)
        '        PARA.Add(P_User_Details.Allow_Statement_Bank)
        '        PARA.Add(P_User_Details.Allow_Statement_Owner)
        '        PARA.Add(P_User_Details.Allow_Statement_OtherRev)
        '        PARA.Add(P_User_Details.Allow_Statement_Exp)
        '        PARA.Add(P_User_Details.Rpt_DailySummary)
        '        PARA.Add(P_User_Details.Rpt_SalesSearch)
        '        PARA.Add(P_User_Details.Rpt_SalesReports)
        '        PARA.Add(P_User_Details.Rpt_InventoryReports)
        '        PARA.Add(P_User_Details.Rpt_ItemReports)
        '        PARA.Add(P_User_Details.Rpt_CustomerReports)
        '        PARA.Add(P_User_Details.Rpt_Alert)
        '        PARA.Add(P_User_Details.Rpt_ItemExpry)
        '        PARA.Add(P_User_Details.Rpt_CustomerHistory)
        '        PARA.Add(P_User_Details.Rpt_CustomerRotation)
        '        PARA.Add(P_User_Details.Rpt_Subcription)
        '        PARA.Add(P_User_Details.Rpt_PurchaseReport)
        '        PARA.Add(P_User_Details.Rpt_SupplierBalance)
        '        PARA.Add(P_User_Details.Rpt_DebitAge)

        '        DBO.ExecuteSP("P_UserInsert", PARA)

        '        Return True
        '    Catch ex As System.Exception
        '        MSG.ErrorOk("[Add]" & vbCrLf & ex.Message)
        '    End Try
        'End Function
        'Public Function Update(ByVal P_User_Details As P_UserDetails) As Boolean
        '    Try

        '        Dim PARA As New ArrayList

        '        PARA.Add(P_User_Details.Code)
        '        PARA.Add(P_User_Details.LoginName)
        '        PARA.Add(P_User_Details.Pass)
        '        PARA.Add(P_User_Details.UserName)
        '        PARA.Add(P_User_Details.Designation)
        '        PARA.Add(P_User_Details.IsAdmin)
        '        PARA.Add(P_User_Details.CanAdjustStock)
        '        PARA.Add(P_User_Details.Allow_Item)
        '        PARA.Add(P_User_Details.Allow_Files)
        '        PARA.Add(P_User_Details.Allow_Subscription_Add)
        '        PARA.Add(P_User_Details.Allow_Subscription_Delete)
        '        PARA.Add(P_User_Details.Allow_Subscription_Pay)
        '        PARA.Add(P_User_Details.Allow_Users)
        '        PARA.Add(P_User_Details.Allow_POS)
        '        PARA.Add(P_User_Details.Allow_Purchase)
        '        PARA.Add(P_User_Details.Allow_Purchase_Add)
        '        PARA.Add(P_User_Details.Allow_Purchase_Edit)
        '        PARA.Add(P_User_Details.Allow_Purchase_Delete)
        '        PARA.Add(P_User_Details.Allow_Purchase_Print)
        '        PARA.Add(P_User_Details.Allow_Purchase_Pay)
        '        PARA.Add(P_User_Details.Allow_Account_Supplier)
        '        PARA.Add(P_User_Details.Allow_Account_Customer)
        '        PARA.Add(P_User_Details.Allow_Account_Cash)
        '        PARA.Add(P_User_Details.Allow_Account_Bank)
        '        PARA.Add(P_User_Details.Allow_Account_Owners)
        '        PARA.Add(P_User_Details.Allow_Account_OtherRev)
        '        PARA.Add(P_User_Details.Allow_Account_Exp)
        '        PARA.Add(P_User_Details.Allow_Account_Voucher)
        '        PARA.Add(P_User_Details.Allow_Statement_Customer)
        '        PARA.Add(P_User_Details.Allow_Statement_Supplier)
        '        PARA.Add(P_User_Details.Allow_Statement_Cash)
        '        PARA.Add(P_User_Details.Allow_Statement_Bank)
        '        PARA.Add(P_User_Details.Allow_Statement_Owner)
        '        PARA.Add(P_User_Details.Allow_Statement_OtherRev)
        '        PARA.Add(P_User_Details.Allow_Statement_Exp)
        '        PARA.Add(P_User_Details.Rpt_DailySummary)
        '        PARA.Add(P_User_Details.Rpt_SalesSearch)
        '        PARA.Add(P_User_Details.Rpt_SalesReports)
        '        PARA.Add(P_User_Details.Rpt_InventoryReports)
        '        PARA.Add(P_User_Details.Rpt_ItemReports)
        '        PARA.Add(P_User_Details.Rpt_CustomerReports)
        '        PARA.Add(P_User_Details.Rpt_Alert)
        '        PARA.Add(P_User_Details.Rpt_ItemExpry)
        '        PARA.Add(P_User_Details.Rpt_CustomerHistory)
        '        PARA.Add(P_User_Details.Rpt_CustomerRotation)
        '        PARA.Add(P_User_Details.Rpt_Subcription)
        '        PARA.Add(P_User_Details.Rpt_PurchaseReport)
        '        PARA.Add(P_User_Details.Rpt_SupplierBalance)
        '        PARA.Add(P_User_Details.Rpt_DebitAge)

        '        DBO.ExecuteSP("P_UserUpdate", PARA)

        '        Return True
        '    Catch ex As System.Exception
        '        MSG.ErrorOk("[Update]" & vbCrLf & ex.Message)
        '    End Try
        'End Function

    End Class

End Class