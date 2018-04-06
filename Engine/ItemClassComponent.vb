Imports POS.FixControls

Public Class ItemClassComponent

    Private m_Code As Integer = 0
    Private m_ItemClassCode As Integer = 0
    Private m_ItemCode As Integer = 0
    Private m_Quantity As Decimal = 0.0

    Public Property Code() As Integer
        Get
            Return m_Code
        End Get
        Set(ByVal value As Integer)
            m_Code = value
        End Set
    End Property
    Public Property ItemClassCode() As Integer
        Get
            Return m_ItemClassCode
        End Get
        Set(ByVal value As Integer)
            m_ItemClassCode = value
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
    Public Property Quantity() As Decimal
        Get
            Return m_Quantity
        End Get
        Set(ByVal value As Decimal)
            m_Quantity = value
        End Set
    End Property
   
    Public Sub New()
        Try

            m_Code = Nothing
            m_ItemClassCode = Nothing
            m_ItemCode = Nothing
            m_Quantity = Nothing

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Sub
    Public Function Add() As Boolean
        Try
            Dim PARA As New ArrayList
            PARA.Add(FixObjectString(m_ItemClassCode))
            PARA.Add(FixObjectString(m_ItemCode))
            PARA.Add(FixObjectString(m_Quantity))

            DBO.ExecuteSP("ItemClassComponentInsert", PARA)
            Return True
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return False
        End Try
    End Function
    
End Class