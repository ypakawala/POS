Imports POS.FixControls
Imports POS.CodeModule

Public Class Account

    Private m_Code As Integer = 0
    Private m_AccountNum As String = Nothing
    Private m_AccountType As CodeModule.AccountType = 0
    Private m_Title As String = Nothing
    Private m_Telephone As String = Nothing
    Private m_Mobile As String = Nothing
    Private m_Notes As String = Nothing
    Private m_Salary As Decimal = Nothing
    Private m_PassportNo As String = Nothing
    Private m_PassportExp As DateTime = Nothing
    Private m_CivilID As String = Nothing
    Private m_CivilIDExp As DateTime = Nothing
    Private m_HealthCardNo As String = Nothing
    Private m_HealthCardExp As DateTime = Nothing
    Private m_TimeLimit As Integer = Nothing
    Private m_AmountLimit As Decimal = Nothing
    'RUN TIME CALCULATED
    Private m_FinalBalance As Double = 0.0
    Private m_Balance As Double = 0.0
    Private m_BalanceCurrentMonth As Double = 0.0
    Private m_BalancePrvMonth As Double = 0.0
    Private m_LastBill As Double = 0.0

   
    Public Property Code() As Integer
        Get
            Return m_Code
        End Get
        Set(ByVal value As Integer)
            m_Code = value
        End Set
    End Property
    Public Property AccountNum() As String
        Get
            Return m_AccountNum
        End Get
        Set(ByVal value As String)
            m_AccountNum = value
        End Set
    End Property
    Public Property AccountType() As CodeModule.AccountType
        Get
            Return m_AccountType
        End Get
        Set(ByVal value As CodeModule.AccountType)
            m_AccountType = value
        End Set
    End Property
    Public Property Title() As String
        Get
            Return m_Title
        End Get
        Set(ByVal value As String)
            m_Title = value
        End Set
    End Property
    Public Property Telephone() As String
        Get
            Return m_Telephone
        End Get
        Set(ByVal value As String)
            m_Telephone = value
        End Set
    End Property
    Public Property Mobile() As String
        Get
            Return m_Mobile
        End Get
        Set(ByVal value As String)
            m_Mobile = value
        End Set
    End Property
    Public Property Notes() As String
        Get
            Return m_Notes
        End Get
        Set(ByVal value As String)
            m_Notes = value
        End Set
    End Property
    Public Property Salary() As Decimal
        Get
            Return m_Salary
        End Get
        Set(ByVal value As Decimal)
            m_Salary = value
        End Set
    End Property
    Public Property PassportNo() As String
        Get
            Return m_PassportNo
        End Get
        Set(ByVal value As String)
            m_PassportNo = value
        End Set
    End Property
    Public Property PassportExp() As DateTime
        Get
            Return m_PassportExp
        End Get
        Set(ByVal value As DateTime)
            m_PassportExp = value
        End Set
    End Property
    Public Property CivilID() As String
        Get
            Return m_CivilID
        End Get
        Set(ByVal value As String)
            m_CivilID = value
        End Set
    End Property
    Public Property CivilIDExp() As DateTime
        Get
            Return m_CivilIDExp
        End Get
        Set(ByVal value As DateTime)
            m_CivilIDExp = value
        End Set
    End Property
    Public Property HealthCardNo() As String
        Get
            Return m_HealthCardNo
        End Get
        Set(ByVal value As String)
            m_HealthCardNo = value
        End Set
    End Property
    Public Property HealthCardExp() As DateTime
        Get
            Return m_HealthCardExp
        End Get
        Set(ByVal value As DateTime)
            m_HealthCardExp = value
        End Set
    End Property
    Public Property TimeLimit() As Integer
        Get
            Return m_TimeLimit
        End Get
        Set(ByVal value As Integer)
            m_TimeLimit = value
        End Set
    End Property
    Public Property AmountLimit() As Decimal
        Get
            Return m_AmountLimit
        End Get
        Set(ByVal value As Decimal)
            m_AmountLimit = value
        End Set
    End Property
    'RUN TIME CALCULATED
    Public Property FinalBalance() As Double
        Get
            Return m_FinalBalance
        End Get
        Set(ByVal value As Double)
            m_FinalBalance = value
        End Set
    End Property
    Public Property Balance() As Decimal
        Get
            Return m_Balance
        End Get
        Set(ByVal value As Decimal)
            m_Balance = value
        End Set
    End Property
    Public Property BalanceCurrentMonth() As Decimal
        Get
            Return m_BalanceCurrentMonth
        End Get
        Set(ByVal value As Decimal)
            m_BalanceCurrentMonth = value
        End Set
    End Property
    Public Property BalancePrvMonth() As Decimal
        Get
            Return m_BalancePrvMonth
        End Get
        Set(ByVal value As Decimal)
            m_BalancePrvMonth = value
        End Set
    End Property
    Public Property LastBill() As Decimal
        Get
            Return m_LastBill
        End Get
        Set(ByVal value As Decimal)
            m_LastBill = value
        End Set
    End Property

    Public Function [Select_Customer](ByVal AccountNum As String, ByVal BalanceDate As DateTime) As Boolean
        Try

         
            If CLS_Config.MonthBasePayment Then

                Dim DT As New DataTable
                Dim PARA As New ArrayList
                PARA.Add(AccountNum)
                PARA.Add(CodeModule.AccountType.Customer)
                PARA.Add(BalanceDate)
                DT = DBO.ExecuteSP_ReturnDataTable("AccountSelectCustomer", PARA)
                If DT.Rows.Count = 0 Then
                    Return False
                Else

                    m_Code = CInt(DT.Rows(0).Item("Code"))
                    m_AccountNum = CStr(FixObjectString(DT.Rows(0).Item("AccountNum")))
                    m_AccountType = CInt(FixObjectNumber(DT.Rows(0).Item("AccountType")))
                    m_Title = CStr(FixObjectString(DT.Rows(0).Item("Title")))
                    m_Notes = CStr(FixObjectString(DT.Rows(0).Item("Notes")))
                    If IsDBNull(DT.Rows(0).Item("TimeLimit")) Then
                        m_TimeLimit = -1
                    Else
                        m_TimeLimit = CInt(FixObjectNumber(DT.Rows(0).Item("TimeLimit")))
                    End If
                    If IsDBNull(DT.Rows(0).Item("AmountLimit")) Then
                        m_AmountLimit = -1
                    Else
                        m_AmountLimit = CInt(FixObjectNumber(DT.Rows(0).Item("AmountLimit")))
                    End If
                    m_FinalBalance = CDec(FixObjectNumber(DT.Rows(0).Item("FinalBalance")))
                    m_Balance = CDec(FixObjectNumber(DT.Rows(0).Item("Balance")))
                    m_BalanceCurrentMonth = CDec(FixObjectNumber(DT.Rows(0).Item("BalanceCurrentMonth")))
                    m_BalancePrvMonth = CDec(FixObjectNumber(DT.Rows(0).Item("BalancePrvMonth")))
                    m_LastBill = CDec(FixObjectNumber(DT.Rows(0).Item("LastBill")))

                    Return True
                End If

            Else

                Using CONTEXT = New POSEntities
                    Dim Acc As Account_ = (From a In CONTEXT.Account_Set
                                          Where a.AccountNum = AccountNum _
                                          AndAlso a.AccountType = CodeModule.AccountType.Customer
                                          Select a).ToList.SingleOrDefault

                    m_Code = CInt(Acc.Code)
                    m_AccountNum = CStr(FixObjectString(Acc.AccountNum))
                    m_AccountType = CInt(FixObjectNumber(Acc.AccountType))
                    m_Title = CStr(FixObjectString(Acc.Title))
                    m_Notes = CStr(FixObjectString(Acc.Notes))
                    If IsDBNull(Acc.TimeLimit) Then
                        m_TimeLimit = -1
                    Else
                        m_TimeLimit = CInt(FixObjectNumber(Acc.TimeLimit))
                    End If
                    If IsDBNull(Acc.AmountLimit) Then
                        m_AmountLimit = -1
                    Else
                        m_AmountLimit = CInt(FixObjectNumber(Acc.AmountLimit))
                    End If
                    m_FinalBalance = 0.0
                    m_BalanceCurrentMonth = 0.0
                    m_BalancePrvMonth = 0.0

                    m_Balance = (From q In CONTEXT.Voucher_Entry Where q.AccountCode = m_Code Select q.Debit - q.Credit).Sum
                    m_Balance = TrimDec(Math.Round(m_Balance, 3))

                    m_LastBill = (From q In CONTEXT.Sale_Set Where q.CustomerCode = m_Code Order By q.TransectionDate Descending Select q.NetBill).FirstOrDefault
                    m_LastBill = TrimDec(Math.Round(m_LastBill, 3))

                End Using

                Return True
            End If

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return 0
        End Try
    End Function
    Public Function [Select](ByVal AccountNum As String, ByVal AccountType As CodeModule.AccountType, ByVal BalanceDate As DateTime) As Boolean
        Try
            Dim DT As New DataTable
            Dim PARA As New ArrayList
            PARA.Add(AccountNum)
            PARA.Add(AccountType)
            PARA.Add(BalanceDate)
            DT = DBO.ExecuteSP_ReturnDataTable("AccountSelect", PARA)
            If DT.Rows.Count = 0 Then
                Return False
            Else

                m_Code = CInt(DT.Rows(0).Item("Code"))
                m_AccountNum = CStr(FixObjectString(DT.Rows(0).Item("AccountNum")))
                m_AccountType = CInt(FixObjectNumber(DT.Rows(0).Item("AccountType")))
                m_Title = CStr(FixObjectString(DT.Rows(0).Item("Title")))
                m_Telephone = CStr(FixObjectString(DT.Rows(0).Item("Telephone")))
                m_Mobile = CStr(FixObjectString(DT.Rows(0).Item("Mobile")))
                m_Notes = CStr(FixObjectString(DT.Rows(0).Item("Notes")))
                m_Salary = CDec(FixObjectNumber(DT.Rows(0).Item("Salary")))
                m_PassportNo = CStr(FixObjectString(DT.Rows(0).Item("PassportNo")))
                m_PassportExp = CDate(FixObjectDate(DT.Rows(0).Item("PassportExp")))
                m_CivilID = CStr(FixObjectString(DT.Rows(0).Item("CivilID")))
                m_CivilIDExp = CDate(FixObjectDate(DT.Rows(0).Item("CivilIDExp")))
                m_HealthCardNo = CStr(FixObjectString(DT.Rows(0).Item("HealthCardNo")))
                m_HealthCardExp = CDate(FixObjectDate(DT.Rows(0).Item("HealthCardExp")))
                If IsDBNull(DT.Rows(0).Item("TimeLimit")) Then
                    m_TimeLimit = -1
                Else
                    m_TimeLimit = CInt(FixObjectNumber(DT.Rows(0).Item("TimeLimit")))
                End If
                If IsDBNull(DT.Rows(0).Item("AmountLimit")) Then
                    m_AmountLimit = -1
                Else
                    m_AmountLimit = CInt(FixObjectNumber(DT.Rows(0).Item("AmountLimit")))
                End If
                m_Balance = CDec(FixObjectNumber(DT.Rows(0).Item("Balance")))

                Return True
            End If
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return 0
        End Try
    End Function
    Public Function [Select](ByVal AccountNum As String, ByVal AccountType As CodeModule.AccountType) As Boolean
        Try
            Dim DT As New DataTable
            Dim PARA As New ArrayList
            PARA.Add(AccountNum)
            PARA.Add(AccountType)
            DT = DBO.ExecuteSP_ReturnDataTable("AccountSelect2", PARA)
            If DT.Rows.Count = 0 Then
                Return False
            Else

                m_Code = CInt(DT.Rows(0).Item("Code"))
                m_AccountNum = CStr(FixObjectString(DT.Rows(0).Item("AccountNum")))
                m_AccountType = CInt(FixObjectNumber(DT.Rows(0).Item("AccountType")))
                m_Title = CStr(FixObjectString(DT.Rows(0).Item("Title")))
                m_Telephone = CStr(FixObjectString(DT.Rows(0).Item("Telephone")))
                m_Mobile = CStr(FixObjectString(DT.Rows(0).Item("Mobile")))
                m_Notes = CStr(FixObjectString(DT.Rows(0).Item("Notes")))
                m_Salary = CDec(FixObjectNumber(DT.Rows(0).Item("Salary")))
                m_PassportNo = CStr(FixObjectString(DT.Rows(0).Item("PassportNo")))
                m_PassportExp = CDate(FixObjectDate(DT.Rows(0).Item("PassportExp")))
                m_CivilID = CStr(FixObjectString(DT.Rows(0).Item("CivilID")))
                m_CivilIDExp = CDate(FixObjectDate(DT.Rows(0).Item("CivilIDExp")))
                m_HealthCardNo = CStr(FixObjectString(DT.Rows(0).Item("HealthCardNo")))
                m_HealthCardExp = CDate(FixObjectDate(DT.Rows(0).Item("HealthCardExp")))
                If IsDBNull(DT.Rows(0).Item("TimeLimit")) Then
                    m_TimeLimit = -1
                Else
                    m_TimeLimit = CInt(FixObjectNumber(DT.Rows(0).Item("TimeLimit")))
                End If
                If IsDBNull(DT.Rows(0).Item("AmountLimit")) Then
                    m_AmountLimit = -1
                Else
                    m_AmountLimit = CInt(FixObjectNumber(DT.Rows(0).Item("AmountLimit")))
                End If
             
                Return True
            End If
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return 0
        End Try
    End Function
End Class