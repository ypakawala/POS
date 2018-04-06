
Public Class OpenForms

    Public Shared Function OpenMasterFile(Optional ByVal TableName As String = "") As Boolean
        Try
            If Open.OpenForm(New frmDynamicList, TableName) Then
            Else
                MSG.InfoOk("غير مسموح بالدخول")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

End Class

