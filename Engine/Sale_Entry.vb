Imports POS.FixControls
Imports POS.CodeModule

Public Class Sale_Entry

    Private m_Code As Integer = 0
    Private m_SaleCode As Integer = 0
    Private m_ItemCode As Integer = 0
    Private m_UnitPrice As Decimal = 0.0
    Private m_Quantity As Decimal = 0.0
    Private m_TotalPrice As Decimal = 0.0
    Private m_CostPrice As Decimal = 0.0
    'RUN TIME
    Private m_Barcode As String = Nothing
    Private m_ItemName As String = Nothing
    Private m_Type As String = Nothing
    Private m_Purchase_EntryCode As Integer = 0
    Private m_Notes As String = Nothing

  
    Public Property Code() As Integer
        Get
            Return m_Code
        End Get
        Set(ByVal value As Integer)
            m_Code = value
        End Set
    End Property
    Public Property SaleCode() As Integer
        Get
            Return m_SaleCode
        End Get
        Set(ByVal value As Integer)
            m_SaleCode = value
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
    Public Property UnitPrice() As Decimal
        Get
            Return m_UnitPrice
        End Get
        Set(ByVal value As Decimal)
            m_UnitPrice = value
        End Set
    End Property
    Public Property Quantity() As Decimal
        Get
            Return m_Quantity
        End Get
        Set(ByVal value As Decimal)
            m_Quantity = value
        End Set
    End Property
    Public Property TotalPrice() As Decimal
        Get
            Return m_TotalPrice
        End Get
        Set(ByVal value As Decimal)
            m_TotalPrice = value
        End Set
    End Property
    Public Property CostPrice() As Decimal
        Get
            Return m_CostPrice
        End Get
        Set(ByVal value As Decimal)
            m_CostPrice = value
        End Set
    End Property

    Public Property Barcode() As String
        Get
            Return m_Barcode
        End Get
        Set(ByVal value As String)
            m_Barcode = value
        End Set
    End Property
    Public Property ItemName() As String
        Get
            Return m_ItemName
        End Get
        Set(ByVal value As String)
            m_ItemName = value
        End Set
    End Property
    Public Property Type() As String
        Get
            Return m_Type
        End Get
        Set(ByVal value As String)
            m_Type = value
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
    Public Property Purchase_EntryCode() As Integer
        Get
            Return m_Purchase_EntryCode
        End Get
        Set(ByVal value As Integer)
            m_Purchase_EntryCode = value
        End Set
    End Property


    Public Sub New()
        Try

            m_Code = Nothing
            m_SaleCode = Nothing
            m_ItemCode = Nothing
            m_UnitPrice = 0.0
            m_Quantity = 1
            m_TotalPrice = 0.0
            m_CostPrice = 0.0

            m_Barcode = Nothing
            m_ItemName = Nothing
            m_Type = "Item"
            m_Purchase_EntryCode = Nothing

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Sub
    Public Function Add(ByVal TransectionType As TransectionType) As Boolean
        Try

            Dim PARA As New ArrayList
            PARA.Add(FixObjectNumber(m_SaleCode))
            PARA.Add(FixObjectNumber(m_ItemCode))
            PARA.Add(FixObjectNumber(m_UnitPrice))
            PARA.Add(FixObjectNumber(m_Quantity))
            PARA.Add(FixObjectNumber(m_TotalPrice))
            PARA.Add(FixObjectNumber(m_CostPrice))
            PARA.Add(FixObjectNumber(TransectionType))
            PARA.Add(TrimStr(Notes))

            If m_Type = "Item" Then
                PARA.Add(FixObjectNumber(m_Purchase_EntryCode))
                DBO.ExecuteSP("Sale_EntryInsert", PARA)
            Else
                DBO.ExecuteSP("Sale_EntryInsert_Class", PARA)
            End If

            Return True

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return False
        End Try
    End Function
    Public Function Cancel(ByVal TransectionType As TransectionType) As Boolean
        Try
            Dim PARA As New ArrayList
            PARA.Add(FixObjectNumber(m_SaleCode))
            PARA.Add(FixObjectNumber(m_ItemCode))
            PARA.Add(FixObjectNumber(m_UnitPrice))
            PARA.Add(FixObjectNumber(m_Quantity))
            PARA.Add(FixObjectNumber(m_TotalPrice))
            PARA.Add(FixObjectNumber(m_CostPrice))
            PARA.Add(FixObjectNumber(TransectionType))

            DBO.ExecuteSP("SaleCancel_EntryInsert", PARA)
            Return True
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return False
        End Try
    End Function
End Class