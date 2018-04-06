Imports POS.FixControls
Imports POS.CodeModule

Public Class Purchase_Entry

    Private m_Code As Integer = 0
    Private m_PurchaseCode As Integer = 0
    Private m_ItemCode As Integer = 0.0
    Private m_Qty As Decimal = 0.0
    Private m_QtyStock As Decimal = 0
    Private m_QtyReturned As Decimal = 0
    Private m_UnitPrice As Decimal = 0.0
    Private m_SalesPrice As Decimal = 0.0
    Private m_Price As Decimal = 0.0
    Private m_ExpiryDate As Date = Nothing
    Private m_SerailNum As String = Nothing

    Public Property Code() As Integer
        Get
            Return m_Code
        End Get
        Set(ByVal value As Integer)
            m_Code = value
        End Set
    End Property
    Public Property PurchaseCode() As Integer
        Get
            Return m_PurchaseCode
        End Get
        Set(ByVal value As Integer)
            m_PurchaseCode = value
        End Set
    End Property
    Public Property ItemCode() As Integer
        Get
            Return m_ItemCode
        End Get
        Set(ByVal value As Integer)
            m_ItemCode = value
        End Set
    End Property
    Public Property Qty() As Decimal
        Get
            Return m_Qty
        End Get
        Set(ByVal value As Decimal)
            m_Qty = value
        End Set
    End Property
    Public Property QtyStock() As Decimal
        Get
            Return m_QtyStock
        End Get
        Set(ByVal value As Decimal)
            m_QtyStock = value
        End Set
    End Property
    Public Property QtyReturned() As Decimal
        Get
            Return m_QtyReturned
        End Get
        Set(ByVal value As Decimal)
            m_QtyReturned = value
        End Set
    End Property
    Public Property UnitPrice() As Decimal
        Get
            Return m_UnitPrice
        End Get
        Set(ByVal value As Decimal)
            m_UnitPrice = value
        End Set
    End Property
    Public Property SalesPrice() As Decimal
        Get
            Return m_SalesPrice
        End Get
        Set(ByVal value As Decimal)
            m_SalesPrice = value
        End Set
    End Property
    Public Property Price() As Decimal
        Get
            Return m_Price
        End Get
        Set(ByVal value As Decimal)
            m_Price = value
        End Set
    End Property
    Public Property ExpiryDate() As Date
        Get
            Return m_ExpiryDate
        End Get
        Set(ByVal value As Date)
            m_ExpiryDate = value
        End Set
    End Property
    Public Property SerailNum() As String
        Get
            Return m_SerailNum
        End Get
        Set(ByVal value As String)
            m_SerailNum = value
        End Set
    End Property


    Public Sub New()
        Try

            m_Code = Nothing
            m_PurchaseCode = Nothing
            m_ItemCode = Nothing
            m_Qty = 0.0
            m_QtyStock = 0.0
            m_QtyReturned = 0.0
            m_UnitPrice = 0.0
            m_SalesPrice = 0.0
            m_Price = 0.0
            m_ExpiryDate = Now.Date
            m_SerailNum = Nothing

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Sub
    Public Function Add() As Integer
        Try
            Dim PARA As New ArrayList
            PARA.Add(FixObjectNumber(m_PurchaseCode))
            PARA.Add(FixObjectNumber(m_ItemCode))
            PARA.Add(FixObjectNumber(m_Qty))
            PARA.Add(FixObjectNumber(m_QtyStock))
            PARA.Add(FixObjectNumber(m_QtyReturned))
            PARA.Add(FixObjectNumber(m_UnitPrice))
            PARA.Add(FixObjectNumber(m_SalesPrice))
            PARA.Add(FixObjectNumber(m_Price))
            PARA.Add(FixObjectDate(m_ExpiryDate))
            PARA.Add(TrimStr(m_SerailNum))
            PARA.Add(CLS_Config.Counter)

            m_Code = DBO.ExecuteSP_ReturnSingleValue("Purchase_EntryInsert", PARA)
            Return m_Code

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return False
        End Try
    End Function
    Public Function Update2() As Integer
        Try
            Dim PARA As New ArrayList
            PARA.Add(FixObjectNumber(m_Code))
            PARA.Add(FixObjectNumber(m_PurchaseCode))
            PARA.Add(FixObjectNumber(m_ItemCode))
            PARA.Add(FixObjectNumber(m_Qty))
            PARA.Add(FixObjectNumber(m_QtyStock))
            PARA.Add(FixObjectNumber(m_QtyReturned))
            PARA.Add(FixObjectNumber(m_UnitPrice))
            PARA.Add(FixObjectNumber(m_SalesPrice))
            PARA.Add(FixObjectNumber(m_Price))
            PARA.Add(FixObjectDate(m_ExpiryDate))
            PARA.Add(TrimStr(m_SerailNum))
            PARA.Add(CLS_Config.Counter)

            m_Code = DBO.ExecuteSP_ReturnSingleValue("Purchase_EntryUpdate", PARA)
            Return m_Code

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return False
        End Try
    End Function
    Public Function [Select](ByVal PurchaseCode As Integer) As DataTable
        Try
            Dim DT As New DataTable
            Dim PARA As New ArrayList
            PARA.Add(PurchaseCode)
            DT = DBO.ExecuteSP_ReturnDataTable("Purchase_EntrySelect", PARA)
            Return DT
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function Delete() As Integer
        Try
            Dim PARA As New ArrayList
            PARA.Add(FixObjectNumber(m_PurchaseCode))

            DBO.ExecuteSP_ReturnSingleValue("Purchase_EntryDelete_PCode", PARA)

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return False
        End Try
    End Function
End Class