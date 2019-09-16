Imports POS.FixControls
Imports POS.CodeModule

Public Class Purchase_Return_Entry

    Private m_Code As Integer = 0
    Private m_PurchaseReturnCode As Integer = 0
    Private m_PurchaseFromCode As Integer = 0
    Private m_ItemCode As Integer = 0.0
    Private m_Qty As Decimal = 0.0
    Private m_UnitPrice As Decimal = 0.0
    Private m_Price As Decimal = 0.0
    Private m_ExpiryDate As Date = Nothing

    Public Property Code() As Integer
        Get
            Return m_Code
        End Get
        Set(ByVal value As Integer)
            m_Code = value
        End Set
    End Property
    Public Property PurchaseReturnCode() As Integer
        Get
            Return m_PurchaseReturnCode
        End Get
        Set(ByVal value As Integer)
            m_PurchaseReturnCode = value
        End Set
    End Property
    Public Property PurchaseFromCode() As Integer
        Get
            Return m_PurchaseFromCode
        End Get
        Set(ByVal value As Integer)
            m_PurchaseFromCode = value
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
    Public Property UnitPrice() As Decimal
        Get
            Return m_UnitPrice
        End Get
        Set(ByVal value As Decimal)
            m_UnitPrice = value
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


    Public Sub New()
        Try

            m_Code = Nothing
            PurchaseReturnCode = Nothing
            PurchaseFromCode = Nothing
            m_ItemCode = Nothing
            m_Qty = 0.0
           m_UnitPrice = 0.0
            m_Price = 0.0
            m_ExpiryDate = Now.Date

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Sub
    Public Function Add() As Integer
        Try
            If CLS_Config.AddPurchaseDetail Then
                Dim PARA As New ArrayList
                PARA.Add(FixObjectNumber(m_PurchaseReturnCode))
                PARA.Add(FixObjectNumber(m_PurchaseFromCode))
                PARA.Add(FixObjectNumber(m_ItemCode))
                PARA.Add(FixObjectNumber(m_Qty))
                PARA.Add(FixObjectNumber(m_UnitPrice))
                PARA.Add(FixObjectNumber(m_Price))
                PARA.Add(FixObjectDate(m_ExpiryDate))
                PARA.Add(CLS_Config.Counter)

                m_Code = DBO.ExecuteSP_ReturnSingleValue("Purchase_Return_EntryInsert", PARA)
                Return m_Code

            Else
                Dim PARA As New ArrayList
                PARA.Add(FixObjectNumber(m_PurchaseReturnCode))
                PARA.Add(FixObjectNumber(m_PurchaseFromCode))
                PARA.Add(FixObjectNumber(m_Price))

                m_Code = DBO.ExecuteSP_ReturnSingleValue("Purchase_Return_EntryInsert2", PARA)
                Return m_Code
            End If


           

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return False
        End Try
    End Function
    Public Function Update() As Integer
        Try
            Dim PARA As New ArrayList
            PARA.Add(FixObjectNumber(m_Code))
            PARA.Add(FixObjectNumber(m_PurchaseReturnCode))
            PARA.Add(FixObjectNumber(m_PurchaseFromCode))
            PARA.Add(FixObjectNumber(m_ItemCode))
            PARA.Add(FixObjectNumber(m_Qty))
            PARA.Add(FixObjectNumber(m_UnitPrice))
            PARA.Add(FixObjectNumber(m_Price))
            PARA.Add(FixObjectDate(m_ExpiryDate))
            PARA.Add(CLS_Config.Counter)

            m_Code = DBO.ExecuteSP_ReturnSingleValue("Purchase_Return_EntryUpdate", PARA)
            Return m_Code

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return False
        End Try
    End Function
    Public Function [Select](ByVal PurchaseReturnCode As Integer) As DataTable
        Try
            Dim DT As New DataTable
            Dim PARA As New ArrayList
            PARA.Add(PurchaseReturnCode)
            DT = DBO.ExecuteSP_ReturnDataTable("Purchase_Return_EntrySelect", PARA)
            Return DT
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function [Select4Return](ByVal PurchaseCode As Integer) As DataTable
        Try
            Dim DT As New DataTable
            Dim PARA As New ArrayList
            PARA.Add(PurchaseCode)
            DT = DBO.ExecuteSP_ReturnDataTable("Purchase_EntrySelect4Return", PARA)
            Return DT
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function Delete() As Integer
        Try
            Dim PARA As New ArrayList
            PARA.Add(FixObjectNumber(m_PurchaseReturnCode))

            DBO.ExecuteSP_ReturnSingleValue("Purchase_Return_EntryDelete_PRCode", PARA)

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return False
        End Try
    End Function
End Class