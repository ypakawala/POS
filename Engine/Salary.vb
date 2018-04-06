Imports POS.FixControls
Imports POS.CodeModule

Public Class Salary

    Private m_Code As Integer = 0
    Private m_EmployeeCode As Integer = 0
    Private m_SalaryAmount As Double = 0.0
    Private m_SalaryMonth As Integer = 0
    Private m_SalaryYear As Integer = 0
    Private m_VoucherCode As Integer = 0
    Private m_Notes As String = Nothing

    Public Property Code() As Integer
        Get
            Return m_Code
        End Get
        Set(ByVal value As Integer)
            m_Code = value
        End Set
    End Property
    Public Property EmployeeCode() As Integer
        Get
            Return m_EmployeeCode
        End Get
        Set(ByVal value As Integer)
            m_EmployeeCode = value
        End Set
    End Property
    Public Property SalaryAmount() As Double
        Get
            Return m_SalaryAmount
        End Get
        Set(ByVal value As Double)
            m_SalaryAmount = value
        End Set
    End Property
    Public Property SalaryMonth() As Integer
        Get
            Return m_SalaryMonth
        End Get
        Set(ByVal value As Integer)
            m_SalaryMonth = value
        End Set
    End Property
    Public Property SalaryYear() As Integer
        Get
            Return m_SalaryYear
        End Get
        Set(ByVal value As Integer)
            m_SalaryYear = value
        End Set
    End Property
    Public Property VoucherCode() As Integer
        Get
            Return m_VoucherCode
        End Get
        Set(ByVal value As Integer)
            m_VoucherCode = value
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

    Public Sub New()
        Try

            m_Code = Nothing
            m_EmployeeCode = 0
            m_SalaryAmount = 0
            m_SalaryMonth = 0
            m_SalaryYear = 0
            m_VoucherCode = 0
            m_Notes = Nothing

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Sub
    Public Function Add() As Integer
        Try
            Dim EffectiveDate As New DateTime(SalaryYear, SalaryMonth, 1)

            Dim PARA As New ArrayList
            PARA.Add(FixObjectNumber(m_Code))
            PARA.Add(FixObjectNumber(m_EmployeeCode))
            PARA.Add(FixObjectNumber(m_SalaryAmount))
            PARA.Add(FixObjectNumber(m_SalaryMonth))
            PARA.Add(FixObjectNumber(m_SalaryYear))
            PARA.Add(FixObjectNumber(m_VoucherCode))
            PARA.Add(FixObjectString(m_Notes))
            PARA.Add(EffectiveDate)
            PARA.Add(CLS_Config.Counter)
            PARA.Add(UserClass.Code)

            m_Code = DBO.ExecuteSP_ReturnSingleValue("SalaryGenerate", PARA)
            Return m_Code

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return False
        End Try
    End Function
    Public Function Delete() As Boolean
        Try

            Dim PARA As New ArrayList
            PARA.Add(FixObjectNumber(m_Code))
            PARA.Add(FixObjectNumber(m_VoucherCode))
            DBO.ExecuteSP_ReturnSingleValue("SalaryDelete", PARA)
            Return True

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return False
        End Try
    End Function
End Class