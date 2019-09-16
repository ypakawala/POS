Imports POS.FixControls
Imports POS.CodeModule

Public Class Purchase_Return

    Private m_Code As Integer = 0
    Private m_EffectiveDate As Date = Nothing
    Private m_TransectionDate As Date = Nothing
    Private m_TransectionType As TransectionType = CodeModule.TransectionType.Purchase
    Private m_SupplierCode As Integer = 0
    Private m_InvoiceNum As String = 0
    Private m_Amount As Decimal = 0.0
    Private m_Posted As Boolean = False
    Private m_UserCode As Integer = 0.0
    Private m_Notes As String = Nothing
    Private m_VoucherCode As Integer = Nothing

    Public Property Code() As Integer
        Get
            Return m_Code
        End Get
        Set(ByVal value As Integer)
            m_Code = value
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
    Public Property TransectionType() As TransectionType
        Get
            Return m_TransectionType
        End Get
        Set(ByVal value As TransectionType)
            m_TransectionType = value
        End Set
    End Property
    Public Property SupplierCode() As Integer
        Get
            Return m_SupplierCode
        End Get
        Set(ByVal value As Integer)
            m_SupplierCode = value
        End Set
    End Property
    Public Property InvoiceNum() As String
        Get
            Return m_InvoiceNum
        End Get
        Set(ByVal value As String)
            m_InvoiceNum = value
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
    Public Property Posted() As Boolean
        Get
            Return m_Posted
        End Get
        Set(ByVal value As Boolean)
            m_Posted = value
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
    Public Property VoucherCode() As Integer
        Get
            Return m_VoucherCode
        End Get
        Set(ByVal value As Integer)
            m_VoucherCode = value
        End Set
    End Property

    Public Sub New()
        Try

            m_Code = Nothing
            m_EffectiveDate = Now.Date
            m_TransectionDate = Now.Date
            m_TransectionType = CodeModule.TransectionType.Purchase
            m_SupplierCode = Nothing
            m_InvoiceNum = Nothing
            m_Amount = 0.0
            m_Posted = False
            m_UserCode = UserClass.Code
            m_VoucherCode = 0.0


        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Sub
    Public Function Add() As Integer
        Try
            Dim PARA As New ArrayList
            PARA.Add(FixObjectDate(m_EffectiveDate))
            PARA.Add(FixObjectDate(m_TransectionDate))
            PARA.Add(FixObjectNumber(m_TransectionType))
            PARA.Add(FixObjectNumber(m_SupplierCode))
            PARA.Add(FixObjectString(m_InvoiceNum))
            PARA.Add(FixObjectNumber(m_Amount))
            PARA.Add(FixObjectBoolean(m_Posted))
            PARA.Add(FixObjectNumber(m_UserCode))
            PARA.Add(FixObjectString(m_Notes))
            PARA.Add(CLS_Config.Counter)

            m_Code = DBO.ExecuteSP_ReturnSingleValue("Purchase_ReturnInsert", PARA)
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
            PARA.Add(FixObjectDate(m_EffectiveDate))
            PARA.Add(FixObjectDate(m_TransectionDate))
            PARA.Add(FixObjectNumber(m_TransectionType))
            PARA.Add(FixObjectNumber(m_SupplierCode))
            PARA.Add(FixObjectString(m_InvoiceNum))
            PARA.Add(FixObjectNumber(m_Amount))
            PARA.Add(FixObjectBoolean(m_Posted))
            PARA.Add(FixObjectNumber(m_UserCode))
            PARA.Add(FixObjectString(m_Notes))
            PARA.Add(CLS_Config.Counter)

            DBO.ExecuteSP("Purchase_ReturnUpdate", PARA)
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
            DT = DBO.ExecuteSP_ReturnDataTable("Purchase_ReturnSelect", PARA)
            If DT.Rows.Count = 0 Then
                Return Nothing
            Else

                m_Code = CInt(DT.Rows(0).Item("Code"))
                m_EffectiveDate = CDate(FixObjectDate(DT.Rows(0).Item("EffectiveDate")))
                m_TransectionDate = CDate(FixObjectDate(DT.Rows(0).Item("TransectionDate")))
                m_TransectionType = CInt(FixObjectNumber(DT.Rows(0).Item("TransectionType")))
                m_SupplierCode = CInt(FixObjectNumber(DT.Rows(0).Item("SupplierCode")))
                m_InvoiceNum = CStr(FixObjectString(DT.Rows(0).Item("InvoiceNum")))
                m_Amount = Decimal.Round(CDec(FixObjectNumber(DT.Rows(0).Item("Amount"))), 3)
                m_Posted = CBool(FixObjectBoolean(DT.Rows(0).Item("Posted")))
                m_UserCode = CInt(FixObjectNumber(DT.Rows(0).Item("UserCode")))
                m_Notes = CStr(FixObjectString(DT.Rows(0).Item("Notes")))
                m_VoucherCode = CInt(DT.Rows(0).Item("VoucherCode"))


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

            DBO.ExecuteSP("Purchase_ReturnDelete", PARA)
            Return True

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return False
        End Try
    End Function

End Class
