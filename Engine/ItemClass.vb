Imports POS.FixControls

Public Class ItemClass

    Private m_Code As Integer = 0
    Private m_ItemName As String = ""
    Private m_SalesPrice As Decimal = 0.0
    Private m_Barcode As String = ""
    Private m_Barcode2 As String = ""
    Private m_Category As Integer = 0
    Private m_SubCategory As Integer = 0
    Private m_Notes As String = ""

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
            m_ItemName = Nothing
            m_SalesPrice = 0.0
            m_Barcode = Nothing
            m_Barcode2 = Nothing
            m_Category = Nothing
            m_SubCategory = Nothing
            m_Notes = Nothing

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Sub
    Public Function Add() As Boolean
        Try
            Dim PARA As New ArrayList
            PARA.Add(FixObjectString(m_ItemName))
            PARA.Add(FixObjectString(m_Barcode))
            PARA.Add(FixObjectString(m_Barcode2))
            PARA.Add(FixObjectNumber(m_SalesPrice))
            PARA.Add(FixObjectNumber(m_Category))
            PARA.Add(FixObjectNumber(m_SubCategory))
            PARA.Add(FixObjectString(m_Notes))

            m_Code = DBO.ExecuteSP_ReturnInteger("ItemClassInsert", PARA)
            Return True
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return False
        End Try
    End Function
    Public Function Update() As Boolean
        Try
            Dim PARA As New ArrayList
            PARA.Add(FixObjectNumber(m_Code))
            PARA.Add(FixObjectString(m_ItemName))
            PARA.Add(FixObjectString(m_Barcode))
            PARA.Add(FixObjectString(m_Barcode2))
            PARA.Add(FixObjectNumber(m_SalesPrice))
            PARA.Add(FixObjectNumber(m_Category))
            PARA.Add(FixObjectNumber(m_SubCategory))
            PARA.Add(FixObjectString(m_Notes))

            If DBO.ExecuteSP("ItemClassUpdate", PARA) Then Return True

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return False
        End Try
    End Function
    Public Function Delete() As Boolean
        Try
            DBO.ActionQuery("DELETE FROM ItemClass WHERE Code=" & m_Code)
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function
    Public Function ValidBarcode(ByVal Code As Integer, ByVal Barcode As String) As Boolean
        Try
            Dim PARA As New ArrayList
            PARA.Add(FixObjectNumber(Code))
            PARA.Add(FixObjectString(Barcode))
            Return DBO.ExecuteSP_ReturnSingleValue("ItemClassValidBarcode", PARA)
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
            Return DBO.ExecuteSP_ReturnSingleValue("ItemClassValidBarcode2", PARA)
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return False
        End Try
    End Function
    Public Function [Exists](ByVal Code As Integer) As Boolean
        Try
            Dim PARA As New ArrayList
            PARA.Add(Code)
            Return DBO.ExecuteSP_ReturnSingleValue("ItemClassExists", PARA)
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return False
        End Try
    End Function
    Public Function [Exists_By_Barcode](ByVal Barcode As String) As Integer
        Try
            Dim PARA As New ArrayList
            PARA.Add(Barcode)
            Return DBO.ExecuteSP_ReturnSingleValue("ItemClassExists_By_Barcode", PARA)
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return 0
        End Try
    End Function
    Public Function [Exists_Name](ByVal ItemName As String) As Integer
        Try
            Dim PARA As New ArrayList
            PARA.Add(ItemName)
            Return DBO.ExecuteSP_ReturnSingleValue("ItemClassExists_Name", PARA)
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
            DT = DBO.ExecuteSP_ReturnDataTable("ItemClassSelect", PARA)
            If DT.Rows.Count = 0 Then
                Return False
            Else

                m_Code = CInt(DT.Rows(0).Item("Code"))
                m_ItemName = CStr(FixObjectString(DT.Rows(0).Item("ItemName")))
                m_SalesPrice = Decimal.Round(CDec(FixObjectNumber(DT.Rows(0).Item("SalesPrice"))), 3)
                m_Barcode = CStr(FixObjectString(DT.Rows(0).Item("Barcode")))
                m_Barcode2 = CStr(FixObjectString(DT.Rows(0).Item("Barcode2")))
                m_Category = CInt(DT.Rows(0).Item("Category"))
                m_SubCategory = FixObjectNumber(DT.Rows(0).Item("SubCategory"))
                m_Notes = CStr(FixObjectString(DT.Rows(0).Item("Notes")))

                Return True
            End If
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return 0
        End Try
    End Function
    
End Class