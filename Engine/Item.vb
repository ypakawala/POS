Imports POS.FixControls

Public Class Item

    Private m_Code As Integer = 0
    Private m_ItemName As String = ""
    Private m_Category As Integer = 0
    Private m_SubCategory As Integer = 0
    Private m_CostPrice As Decimal = 0.0
    Private m_ProfitMargin As Decimal = 0.0
    Private m_SalesPrice As Decimal = 0.0
    Private m_Barcode As String = ""
    Private m_Barcode2 As String = ""
    Private m_StockInHand As Decimal = 0.0
    Private m_StockInStore As Decimal = 0.0
    Private m_Stock As Decimal = 0.0
    Private m_StockMin As Decimal = 0.0
    Private m_ItemType As ItemType
    Private m_UMC As Integer
    Private m_Notes As String = ""
    Private m_LastSaleDate As Date = Nothing
    Private m_LastPurchaseDate As Date = Nothing
    Private m_LastPurchaseCost As Decimal = 0.0
    Private m_CostMethod As CostMethod = CostMethod.CostFromPurchase
    Private m_Type As String = Nothing
    Private m_Discontinued As Boolean = False
    Private m_onPromo As Boolean = False
    Private m_PromoFrom As DateTime = Nothing
    Private m_PromoTo As DateTime = Nothing
    Private m_PromoPrice As Decimal = Nothing
    Private m_PromoStockLimit As Decimal = Nothing
    Private m_PromoStockSold As Decimal = Nothing
    Private m_PromoStockAvailable As Decimal = Nothing



    Public Property Code() As Integer
        Get
            Return m_Code
        End Get
        Set(ByVal value As Integer)
            m_Code = value
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
    Public Property Category() As Integer
        Get
            Return m_Category
        End Get
        Set(ByVal value As Integer)
            m_Category = value
        End Set
    End Property
    Public Property SubCategory() As Integer
        Get
            Return m_SubCategory
        End Get
        Set(ByVal value As Integer)
            m_SubCategory = value
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
    Public Property ProfitMargin() As Decimal
        Get
            Return m_ProfitMargin
        End Get
        Set(ByVal value As Decimal)
            m_ProfitMargin = value
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
    Public Property Barcode() As String
        Get
            Return m_Barcode
        End Get
        Set(ByVal value As String)
            m_Barcode = value
        End Set
    End Property
    Public Property Barcode2() As String
        Get
            Return m_Barcode2
        End Get
        Set(ByVal value As String)
            m_Barcode2 = value
        End Set
    End Property
    Public Property StockInHand() As Decimal
        Get
            Return m_StockInHand
        End Get
        Set(ByVal value As Decimal)
            m_StockInHand = value
        End Set
    End Property
    Public Property StockInStore() As Decimal
        Get
            Return m_StockInStore
        End Get
        Set(ByVal value As Decimal)
            m_StockInStore = value
        End Set
    End Property
    Public Property Stock() As Decimal
        Get
            Return m_Stock
        End Get
        Set(ByVal value As Decimal)
            m_Stock = value
        End Set
    End Property
    Public Property StockMin() As Decimal
        Get
            Return m_StockMin
        End Get
        Set(ByVal value As Decimal)
            m_StockMin = value
        End Set
    End Property
    Public Property ItemType() As ItemType
        Get
            Return m_ItemType
        End Get
        Set(ByVal value As ItemType)
            m_ItemType = value
        End Set
    End Property
    Public Property UMC() As Integer
        Get
            Return m_UMC
        End Get
        Set(ByVal value As Integer)
            m_UMC = value
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
    Public Property LastSaleDate() As Date
        Get
            Return m_LastSaleDate
        End Get
        Set(ByVal value As Date)
            m_LastSaleDate = value
        End Set
    End Property
    Public Property LastPurchaseDate() As Date
        Get
            Return m_LastPurchaseDate
        End Get
        Set(ByVal value As Date)
            m_LastPurchaseDate = value
        End Set
    End Property
    Public Property LastPurchaseCost() As Decimal
        Get
            Return m_LastPurchaseCost
        End Get
        Set(ByVal value As Decimal)
            m_LastPurchaseCost = value
        End Set
    End Property
    Public Property CostMethod() As CostMethod
        Get
            Return m_CostMethod
        End Get
        Set(ByVal value As CostMethod)
            m_CostMethod = value
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
    Public Property Discontinued() As Boolean
        Get
            Return m_Discontinued
        End Get
        Set(ByVal value As Boolean)
            m_Discontinued = value
        End Set
    End Property
    Public Property onPromo() As Boolean
        Get
            Return m_onPromo
        End Get
        Set(ByVal value As Boolean)
            m_onPromo = value
        End Set
    End Property
    Public Property PromoFrom() As DateTime
        Get
            Return m_PromoFrom
        End Get
        Set(ByVal value As DateTime)
            m_PromoFrom = value
        End Set
    End Property
    Public Property PromoTo() As DateTime
        Get
            Return m_PromoTo
        End Get
        Set(ByVal value As DateTime)
            m_PromoTo = value
        End Set
    End Property
    Public Property PromoPrice() As Decimal
        Get
            Return m_PromoPrice
        End Get
        Set(ByVal value As Decimal)
            m_PromoPrice = value
        End Set
    End Property
    Public Property PromoStockLimit() As Decimal
        Get
            Return m_PromoStockLimit
        End Get
        Set(ByVal value As Decimal)
            m_PromoStockLimit = value
        End Set
    End Property
    Public Property PromoStockSold() As Decimal
        Get
            Return m_PromoStockSold
        End Get
        Set(ByVal value As Decimal)
            m_PromoStockSold = value
        End Set
    End Property
    Public Property PromoStockAvailable() As Decimal
        Get
            Return m_PromoStockAvailable
        End Get
        Set(ByVal value As Decimal)
            m_PromoStockAvailable = value
        End Set
    End Property

    Public Sub New()
        Try

            m_Code = Nothing
            m_ItemName = Nothing
            m_Category = CLS_Config.DefaultCategory
            m_SubCategory = CLS_Config.DefaultSubCategory
            m_CostPrice = 0.0
            m_SalesPrice = 0.0
            m_Barcode = Nothing
            m_Barcode2 = Nothing
            m_StockInHand = 0.0
            m_StockInStore = 0.0
            m_StockMin = 0.0
            m_ItemType = CodeModule.ItemType.StandardItem
            m_UMC = Nothing
            m_LastSaleDate = Nothing
            m_LastPurchaseDate = Nothing
            m_LastPurchaseCost = 0.0
            m_CostMethod = CodeModule.CostMethod.CostFromPurchase
            m_Type = "Item"
            m_Discontinued = False
            m_onPromo = False
            m_PromoFrom = Null_Date
            m_PromoTo = Null_Date
            m_PromoPrice = Nothing
            m_PromoStockLimit = Nothing
            m_PromoStockSold = Nothing
            m_PromoStockAvailable = Nothing

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Sub
    'Public Function Add() As Boolean
    '    Try
    '        Dim PARA As New ArrayList
    '        PARA.Add(FixObjectNumber(m_Code))
    '        PARA.Add(FixObjectString(m_ItemName))
    '        PARA.Add(FixObjectNumber(m_Category))
    '        PARA.Add(FixObjectNumber(m_SubCategory))
    '        PARA.Add(FixObjectNumber(m_CostPrice))
    '        PARA.Add(FixObjectNumber(m_SalesPrice))
    '        PARA.Add(FixObjectString(m_Barcode))
    '        PARA.Add(FixObjectString(m_Barcode2))
    '        PARA.Add(FixObjectNumber(m_StockInHand))
    '        PARA.Add(FixObjectNumber(m_StockInStore))
    '        PARA.Add(FixObjectNumber(m_StockMin))
    '        PARA.Add(FixObjectNumber(m_ItemType))
    '        PARA.Add(FixObjectNumber(m_UMC))

    '        DBO.ExecuteSP("ItemInsert", PARA)
    '        Return True
    '    Catch ex As Exception
    '        MSG.ErrorOk(ex.Message)
    '        Return False
    '    End Try
    'End Function
    'Public Function Update() As Boolean
    '    Try
    '        Dim PARA As New ArrayList
    '        PARA.Add(FixObjectNumber(m_Code))
    '        PARA.Add(FixObjectString(m_ItemName))
    '        PARA.Add(FixObjectNumber(m_Category))
    '        PARA.Add(FixObjectNumber(m_SubCategory))
    '        PARA.Add(FixObjectNumber(m_CostPrice))
    '        PARA.Add(FixObjectNumber(m_ProfitMargin))
    '        PARA.Add(FixObjectNumber(m_SalesPrice))
    '        PARA.Add(FixObjectString(m_Barcode))
    '        PARA.Add(FixObjectString(m_Barcode2))
    '        PARA.Add(FixObjectNumber(m_StockInHand))
    '        PARA.Add(FixObjectNumber(m_StockInStore))
    '        PARA.Add(FixObjectNumber(m_StockMin))
    '        PARA.Add(FixObjectNumber(m_ItemType))
    '        PARA.Add(FixObjectNumber(m_UMC))

    '        DBO.ExecuteSP("ItemUpdate", PARA)
    '        Return True
    '    Catch ex As Exception
    '        MSG.ErrorOk(ex.Message)
    '        Return False
    '    End Try
    'End Function
    Public Function Delete() As Boolean
        Try
            Dim PARA As New ArrayList
            PARA.Add(FixObjectNumber(m_Code))

            DBO.ExecuteSP("ItemDelete", PARA)

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function
    Public Function ValidBarcode(ByVal Code As Integer, ByVal Barcode As String) As Boolean
        Try
            Dim PARA As New ArrayList
            PARA.Add(FixObjectNumber(Code))
            PARA.Add(FixObjectString(Barcode))
            Return DBO.ExecuteSP_ReturnSingleValue("ItemValidBarcode", PARA)
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return False
        End Try
    End Function
    Public Function ValidBarcode2_(ByVal Code As Integer, ByVal Barcode2 As String) As Boolean
        Try
            Dim PARA As New ArrayList
            PARA.Add(FixObjectNumber(Code))
            PARA.Add(FixObjectNumber(Barcode2))
            Return DBO.ExecuteSP_ReturnSingleValue("ItemValidBarcode2", PARA)
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return False
        End Try
    End Function
    Public Function [Exists](ByVal Code As Integer) As Boolean
        Try
            Dim PARA As New ArrayList
            PARA.Add(Code)
            Return DBO.ExecuteSP_ReturnSingleValue("ItemExists", PARA)
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return False
        End Try
    End Function
    Public Function [Exists_By_Barcode](ByVal Barcode As String) As Integer
        Try
            Dim PARA As New ArrayList
            PARA.Add(Barcode)
            Return DBO.ExecuteSP_ReturnSingleValue("ItemExists_By_Barcode", PARA)
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return 0
        End Try
    End Function
    Public Function [Exists_Name](ByVal ItemName As String) As Integer
        Try
            Dim PARA As New ArrayList
            PARA.Add(ItemName)
            Return DBO.ExecuteSP_ReturnSingleValue("ItemExists_Name", PARA)
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return 0
        End Try
    End Function
    Public Function [Select](ByVal Code As Integer) As Boolean
        Try
            Dim DT As New DataTable
            Dim PARA As New ArrayList
            PARA.Add(Code)
            DT = DBO.ExecuteSP_ReturnDataTable("ItemSelect", PARA)
            If DT.Rows.Count = 0 Then
                Return False
            Else

                m_Code = CInt(DT.Rows(0).Item("Code"))
                m_ItemName = CStr(FixObjectString(DT.Rows(0).Item("ItemName")))
                m_Category = CInt(FixObjectNumber(DT.Rows(0).Item("Category")))
                m_SubCategory = CInt(FixObjectNumber(DT.Rows(0).Item("SubCategory")))
                m_CostPrice = Decimal.Round(CDec(FixObjectNumber(DT.Rows(0).Item("CostPrice"))), 3)
                m_ProfitMargin = Decimal.Round(CDec(FixObjectNumber(DT.Rows(0).Item("ProfitMargin"))), 3)
                m_SalesPrice = Decimal.Round(CDec(FixObjectNumber(DT.Rows(0).Item("SalesPrice"))), 3)
                m_Barcode = CStr(FixObjectString(DT.Rows(0).Item("Barcode")))
                m_Barcode2 = CStr(FixObjectString(DT.Rows(0).Item("Barcode2")))
                m_StockInHand = CDec(FixObjectNumber(DT.Rows(0).Item("StockInHand")))
                m_StockInStore = CDec(FixObjectNumber(DT.Rows(0).Item("StockInStore")))
                m_StockMin = CDec(FixObjectNumber(DT.Rows(0).Item("StockMin")))
                m_ItemType = CDec(FixObjectNumber(DT.Rows(0).Item("ItemType")))
                m_UMC = CDec(FixObjectNumber(DT.Rows(0).Item("UMC")))
                m_Notes = CStr(FixObjectString(DT.Rows(0).Item("Notes")))
                m_LastSaleDate = CDate(FixObjectDate(DT.Rows(0).Item("LastSaleDate")))
                m_LastPurchaseDate = CDate(FixObjectDate(DT.Rows(0).Item("LastPurchaseDate")))
                m_LastPurchaseCost = CDec(FixObjectNumber(DT.Rows(0).Item("LastPurchaseCost")))
                m_CostMethod = CInt(FixObjectNumber(DT.Rows(0).Item("CostMethod")))
                m_Discontinued = TrimBoolean(DT.Rows(0).Item("Discontinued"))
                m_onPromo = TrimBoolean(DT.Rows(0).Item("onPromo"))
                m_PromoFrom = TrimDate(DT.Rows(0).Item("PromoFrom"))
                m_PromoTo = TrimDate(DT.Rows(0).Item("PromoTo"))
                m_PromoPrice = TrimDec(DT.Rows(0).Item("PromoPrice"))
                m_PromoStockLimit = TrimDec(DT.Rows(0).Item("PromoStockLimit"))
                m_PromoStockSold = TrimDec(DT.Rows(0).Item("PromoStockSold"))
                m_PromoStockAvailable = m_PromoStockLimit - m_PromoStockSold

                If m_LastSaleDate = Null_Date Then m_LastSaleDate = Nothing
                If m_LastPurchaseDate = Null_Date Then m_LastPurchaseDate = Nothing

                'If m_CostPrice = 0 Then
                '    m_ProfitMargin = 0
                'Else
                '    m_ProfitMargin = Decimal.Round(CDec(((m_SalesPrice - m_CostPrice) * 100) / m_CostPrice), 3)
                'End If

                m_Stock = CDec(m_StockInHand + m_StockInStore)

                Return True
            End If
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return 0
        End Try
    End Function
    Public Function [ItemStock](ByVal Code As Integer) As Decimal
        Try
            Dim DT As New DataTable
            Dim PARA As New ArrayList
            PARA.Add(Code)
            DT = DBO.ExecuteSP_ReturnDataTable("ItemStock", PARA)
            If DT.Rows.Count = 0 Then
                Return False
            Else

                m_StockInHand = CDec(FixObjectNumber(DT.Rows(0).Item("StockInHand")))
                m_StockInStore = CDec(FixObjectNumber(DT.Rows(0).Item("StockInStore")))
                m_Stock = CDec(m_StockInHand + m_StockInStore)

                Return m_Stock
            End If
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return 0
        End Try
    End Function
End Class