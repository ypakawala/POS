Imports Engine

Public Class Logged

    Private Shared m_Logged As Boolean = False

    Public Shared Property Logged() As Boolean
        Get
            Return m_Logged
        End Get
        Set(ByVal value As Boolean)
            m_Logged = value
        End Set
    End Property

End Class
