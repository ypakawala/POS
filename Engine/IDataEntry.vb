
#Region "Copyright(c)"

'Copyright (c) 2008 HardTask Corporation. All rigths reserved.

#End Region


#Region "Import Directives"

#End Region

Public Interface IDataEntry


    'Protected m_watchOnly As Boolean = False, m_saveData As Boolean = False, m_addData As Boolean = False, m_editData As Boolean = False, m_deleteData As Boolean = False
    'Protected m_modi As Boolean = False
    ''protected string tableName = "";
    'Protected tblCodes As New DataTable()

    Property tblName() As String
    Property Modi() As Boolean

    'Property Var1() As Integer
    'Property Var2() As Integer
    'Property Var3() As Integer
    'Property Var4() As Integer

    Sub DataLen()
    Sub Mask()
    Sub ReadOnlyField()
    Sub LoadNew()
    Sub Loading()

    Function Add() As Boolean
    Function Edit() As Boolean
    Function Delete() As Boolean

    Function Adding() As Boolean
    Function Editing() As Boolean
    Function Deleting() As Boolean

    Function Saving() As Boolean

    Sub LoadCodes()
    Sub LoadData(ByVal code As Integer)
    Sub FillDrops()
    Function SetCode() As Boolean
    Function SetDefault() As Boolean


    Function CanSave() As Boolean

    Sub Counter()
    Sub Clear()
    Sub [New]()

    Sub FillGrid()
    Sub NaviNext()
    Sub NaviBack()
    Sub GridNavi()
    Sub ComboNavi()



End Interface


