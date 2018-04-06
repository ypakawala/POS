Imports POS.FixControls
Imports POS.CodeModule

Public Class Voucher

    Private m_Code As Integer = 0
    Private m_CounterCode As Integer = 0
    Private m_RefNumber As String = 0
    Private m_EffectiveDate As Date = Nothing
    Private m_TransectionDate As Date = Nothing
    Private m_UserCode As Integer = 0
    Private m_Notes As String = Nothing
    Private m_Posted As Boolean = False
    Private m_TransectionType As TransectionType = CodeModule.TransectionType.Purchase
    Private m_PaymentType As PaymentType = CodeModule.PaymentType.Cash

    Private m_AccountFrom As Integer = 0
    Private m_AccountTo As Integer = 0
    Private m_Amount As Decimal = 0.0

    Public Property Code() As Integer
        Get
            Return m_Code
        End Get
        Set(ByVal value As Integer)
            m_Code = value
        End Set
    End Property
    Public Property CounterCode() As Integer
        Get
            Return m_CounterCode
        End Get
        Set(ByVal value As Integer)
            m_CounterCode = value
        End Set
    End Property
    Public Property RefNumber() As String
        Get
            Return m_RefNumber
        End Get
        Set(ByVal value As String)
            m_RefNumber = value
        End Set
    End Property
    Public Property EffectiveDate() As Date
        Get
            Return m_EffectiveDate
        End Get
        Set(ByVal value As Date)
            m_EffectiveDate = value
        End Set
    End Property
    Public Property TransectionDate() As Date
        Get
            Return m_TransectionDate
        End Get
        Set(ByVal value As Date)
            m_TransectionDate = value
        End Set
    End Property
    Public Property UserCode() As Integer
        Get
            Return m_UserCode
        End Get
        Set(ByVal value As Integer)
            m_UserCode = value
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
    Public Property Posted() As Boolean
        Get
            Return m_Posted
        End Get
        Set(ByVal value As Boolean)
            m_Posted = value
        End Set
    End Property
    Public Property TransectionType() As TransectionType
        Get
            Return m_TransectionType
        End Get
        Set(ByVal value As TransectionType)
            m_TransectionType = value
        End Set
    End Property
    Public Property PaymentType() As PaymentType
        Get
            Return m_PaymentType
        End Get
        Set(ByVal value As PaymentType)
            m_PaymentType = value
        End Set
    End Property

    Public Property AccountFrom() As Integer
        Get
            Return m_AccountFrom
        End Get
        Set(ByVal value As Integer)
            m_AccountFrom = value
        End Set
    End Property
    Public Property AccountTo() As Integer
        Get
            Return m_AccountTo
        End Get
        Set(ByVal value As Integer)
            m_AccountTo = value
        End Set
    End Property
    Public Property Amount() As Decimal
        Get
            Return m_Amount
        End Get
        Set(ByVal value As Decimal)
            m_Amount = value
        End Set
    End Property
    


    Public Sub New()
        Try

            m_Code = Nothing
            m_RefNumber = Nothing
            m_CounterCode = CLS_Config.Counter
            m_EffectiveDate = Now.Date
            m_TransectionDate = Now.Date
            m_UserCode = UserClass.Code
            m_Notes = Nothing
            m_Posted = False
            m_TransectionType = CodeModule.TransectionType.Purchase
            m_PaymentType = CodeModule.PaymentType.Cash
            m_AccountFrom = 0
            m_AccountTo = 0
            m_Amount = 0.0

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Sub
    Public Function Add() As Integer
        Try
            Dim PARA As New ArrayList
            PARA.Add(FixObjectNumber(m_CounterCode))
            PARA.Add(FixObjectString(m_RefNumber))
            PARA.Add(FixObjectDate(m_EffectiveDate))
            PARA.Add(FixObjectNumber(m_UserCode))
            PARA.Add(FixObjectString(m_Notes))
            PARA.Add(FixObjectBoolean(m_Posted))
            PARA.Add(FixObjectNumber(m_TransectionType))
            PARA.Add(FixObjectNumber(m_PaymentType))
            PARA.Add(FixObjectNumber(m_AccountFrom))
            PARA.Add(FixObjectNumber(m_AccountTo))
            PARA.Add(FixObjectNumber(m_Amount))

            m_Code = DBO.ExecuteSP_ReturnSingleValue("VoucherInsert", PARA)
            Return m_Code

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return 0
        End Try
    End Function
    Public Function Update() As Boolean
        Try
            Dim PARA As New ArrayList
            PARA.Add(FixObjectNumber(m_Code))
            PARA.Add(FixObjectNumber(m_CounterCode))
            PARA.Add(FixObjectString(m_RefNumber))
            PARA.Add(FixObjectDate(m_EffectiveDate))
            PARA.Add(FixObjectNumber(m_UserCode))
            PARA.Add(FixObjectString(m_Notes))
            PARA.Add(FixObjectBoolean(m_Posted))
            PARA.Add(FixObjectNumber(m_TransectionType))
            PARA.Add(FixObjectNumber(m_PaymentType))
            PARA.Add(FixObjectNumber(m_AccountFrom))
            PARA.Add(FixObjectNumber(m_AccountTo))
            PARA.Add(FixObjectNumber(m_Amount))

            DBO.ExecuteSP("VoucherUpdate", PARA)
            Return True

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return False
        End Try
    End Function
    Public Function [Select](ByVal Code As Integer) As Boolean
        Try
            Dim DT As New DataTable
            Dim PARA As New ArrayList
            PARA.Add(Code)
            DT = DBO.ExecuteSP_ReturnDataTable("VoucherSelect", PARA)
            If DT.Rows.Count = 0 Then
                Return Nothing
            Else

                m_Code = CInt(DT.Rows(0).Item("Code"))
                m_CounterCode = CInt(FixObjectNumber(DT.Rows(0).Item("CounterCode")))
                m_RefNumber = CStr(FixObjectString(DT.Rows(0).Item("RefNumber")))
                m_EffectiveDate = CDate(FixObjectDate(DT.Rows(0).Item("EffectiveDate")))
                m_UserCode = CInt(FixObjectNumber(DT.Rows(0).Item("UserCode")))
                m_Notes = CStr(FixObjectString(DT.Rows(0).Item("Notes")))
                m_Posted = CBool(FixObjectBoolean(DT.Rows(0).Item("Posted")))
                m_TransectionType = CInt(FixObjectNumber(DT.Rows(0).Item("TransectionTypeCode")))
                m_PaymentType = CInt(FixObjectNumber(DT.Rows(0).Item("PaymentTypeCode")))
                m_AccountFrom = Decimal.Round(CDec(FixObjectNumber(DT.Rows(0).Item("AccountCode"))), 3)
                m_AccountTo = Decimal.Round(CDec(FixObjectNumber(DT.Rows(1).Item("AccountCode"))), 3)
                m_Amount = Decimal.Round(CDec(FixObjectNumber(DT.Rows(0).Item("Debit"))), 3)

                Return True

            End If
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return False
        End Try
    End Function
    Public Function Delete() As Boolean
        Try
            Dim PARA As New ArrayList
            PARA.Add(FixObjectNumber(m_Code))
            DBO.ExecuteSP("VoucherDelete", PARA)

            Return True

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return False
        End Try
    End Function
    'Public Function [Balance](ByVal PaymentType As Integer) As Double
    '    Try
    '        Dim DT As New DataTable
    '        Dim PARA As New ArrayList
    '        PARA.Add(PaymentType)
    '        DT = DBO.ExecuteSP_ReturnDataTable("PurchaseBalance", PARA)
    '        If DT.Rows.Count = 0 Then
    '            Return 0.0
    '        Else
    '            Return Decimal.Round(CDec(FixObjectNumber(DT.Rows(0).Item("Balance"))), 3)
    '        End If
    '    Catch ex As Exception
    '        MSG.ErrorOk(ex.Message)
    '        Return 0.0
    '    End Try
    'End Function
End Class