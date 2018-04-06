
Public Interface IAdvancedSearch

    Property TableName() As String
    Property MulitSelect() As Boolean
    Property SourceForm() As String
    Property KeyColumn() As String
    Property HasColumnChooser() As Boolean
    Property WatchOnly() As Boolean
    Property SaveData() As Boolean
    Property AddData() As Boolean
    Property EditData() As Boolean
    Property DeleteData() As Boolean
    Property SearchData() As Boolean
    Property PrintData() As Boolean
    Property ExportData() As Boolean
    Property FormCode() As Integer



    Sub FillGrid()
    Sub FilterGrid()
    Sub Print()
    Sub Clear()
    Sub SelectAll()
    Sub ClearSelection()
    Sub SetLayout()

End Interface