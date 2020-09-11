﻿
Imports System.Math
Imports System.Data.Odbc
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Imports System.Drawing.Printing
Imports System.IO

Public Module CodeModule

    Public ProjectKey As String = "theNextPOS"

    Public UpdateFilePath As String = System.Configuration.ConfigurationSettings.AppSettings("UpdateFilePath")
    Public CashdrawerPath As String = System.Configuration.ConfigurationSettings.AppSettings("CashdrawerPath")
    Public PrinterPort As String = System.Configuration.ConfigurationSettings.AppSettings("PrinterPort")
    Public PortMax As Integer = System.Configuration.ConfigurationSettings.AppSettings("PortMax")
    Public CategoryWidth As String = System.Configuration.ConfigurationSettings.AppSettings("CategoryWidth")
    Public CategoryHeight As String = System.Configuration.ConfigurationSettings.AppSettings("CategoryHeight")
    Public ItemWidth As String = System.Configuration.ConfigurationSettings.AppSettings("ItemWidth")
    Public ItemHeight As String = System.Configuration.ConfigurationSettings.AppSettings("ItemHeight")
    Public CategoryImagePath As String = System.Configuration.ConfigurationSettings.AppSettings("CategoryImagePath")
    Public ItemImagePath As String = System.Configuration.ConfigurationSettings.AppSettings("ItemImagePath")
    Public ImageFontSize As Single = System.Configuration.ConfigurationSettings.AppSettings("ImageFontSize")
    Public GeneralItemCode As Single = System.Configuration.ConfigurationSettings.AppSettings("GeneralItemCode")
    Public PrintEmptySpaceType As Integer = System.Configuration.ConfigurationSettings.AppSettings("PrintEmptySpaceType")
    Public ChrWeightItemBarcodeLength As Integer = System.Configuration.ConfigurationSettings.AppSettings("ChrWeightItemBarcodeLength")
    Public ChrWeightItemStrat As Integer = System.Configuration.ConfigurationSettings.AppSettings("ChrWeightItemStrat")
    Public ChrWeightItemLength As Integer = System.Configuration.ConfigurationSettings.AppSettings("ChrWeightItemLength")
    Public ChrWeightPriceStart As Integer = System.Configuration.ConfigurationSettings.AppSettings("ChrWeightPriceStart")
    Public ChrWeightPriceLength As Integer = System.Configuration.ConfigurationSettings.AppSettings("ChrWeightPriceLength")
    Public CategoryHighlight As Integer = System.Configuration.ConfigurationSettings.AppSettings("CategoryHighlight")
    Public BarcodeItemLength As Integer = System.Configuration.ConfigurationSettings.AppSettings("BarcodeItemLength")
    Public YSD As String = System.Configuration.ConfigurationSettings.AppSettings("YSD")

    Public YearStartDate As Date = Now.Date
    Public BDate As Date = Now.Date
    Public onTrial As Boolean = False
    Public showTrial As Boolean = False
    Public ForceC As Boolean = False


    Public RowAlternateAppearance As Infragistics.Win.Appearance = New Infragistics.Win.Appearance

    Public CLS_Config As SysConfig
    Public CLS_Sale As Sale

    Public Printer_On As Boolean = True
    Public CostPrice_On As Boolean = False
    Public BillNumber As Integer = 0

    Public ConnStr As String = Nothing
    Public UserClass As ClassContainer.P_UserDetails
    Public Null_Date As New Date(1900, 1, 1)
    Public Mask_Int5 As String = "nnnnn"
    Public Mask_Qty As String = "{double:-9.3}"
    Public Mask_Amount As String = "{double:-9.3}"
    Public Mask_AmountPositive As String = "{double:9.3}"
    Public Mask_Amount5 As String = "{double:5.3}"
    Public Mask_Amount5Nagative As String = "{double:-5.3}"
    Public Mask_Date As String = "{LOC}dd/mm/yyyy"

    'Declare Function sndPLaySound Lib "winmm.dll" Alias "sndPlaySoundA" (ByVal name As String, ByVal flags As Long) As Long
    'Public Const SND_ASYNC As Int32 = &H1
    Public Key_List As New ArrayList
    Public Key_No_List As New ArrayList

    Public INDIAGATE As String = "IG"
    Public OsmanSM As String = "OS"
    Public EDEE As String = "ED"
    Public BOOKSHOP As String = "BS"
    Public ZAHRABAKALA As String = "ZB"
    Public RASLANI As String = "R"
    Public CENTURY As String = "CB"
    Public MAHIR As String = "MH"
    Public MoveNPick As String = "MnP"
    Public AbdulHussain As String = "AH"

    Public Help As String = Nothing

    Public Property Printers As New PrinterCollection
    Public Property Printer_ As New Printer

    Public Find_Int As Integer
    Public Find2_Int As Integer
    Public Find_Str As String
    Public Find_Dec As Decimal

    Public DatabaseName, DatabaseLogID, DatabasePass As String

    Public CurrencyBase As Integer = 1000


    Public Sub Set_Key_Array()
        Key_List.Add(CLS_Config.K_Add)
        Key_List.Add(CLS_Config.K_Add2)
        Key_List.Add(CLS_Config.K_Balance)
        Key_List.Add(CLS_Config.K_Cash)
        Key_List.Add(CLS_Config.K_Cash2)
        Key_List.Add(CLS_Config.K_Clear)
        Key_List.Add(CLS_Config.K_ClearBox)
        Key_List.Add(CLS_Config.K_Close)
        Key_List.Add(CLS_Config.K_Credit_Sale)
        Key_List.Add(CLS_Config.K_Delete)
        Key_List.Add(CLS_Config.K_Delete2)
        Key_List.Add(CLS_Config.K_Discount)
        Key_List.Add(CLS_Config.K_Discount_Per)
        Key_List.Add(CLS_Config.K_EditBill)
        Key_List.Add(CLS_Config.K_Hold)
        Key_List.Add(CLS_Config.K_Info)
        Key_List.Add(CLS_Config.K_Knet)
        Key_List.Add(CLS_Config.K_MasterVisa)
        Key_List.Add(CLS_Config.K_Multiply)
        Key_List.Add(CLS_Config.K_Multiply2)
        Key_List.Add(CLS_Config.K_Open_Item)
        Key_List.Add(CLS_Config.K_Payment)
        Key_List.Add(CLS_Config.K_Price)
        Key_List.Add(CLS_Config.K_Price2)
        Key_List.Add(CLS_Config.K_Print)
        Key_List.Add(CLS_Config.K_Repeat)
        Key_List.Add(CLS_Config.K_Remark)
        Key_List.Add(CLS_Config.K_SalesReturn)
        Key_List.Add(CLS_Config.K_ItemList)
        Key_List.Add(CLS_Config.K_CustomerList)
        Key_List.Add(CLS_Config.K_Discount_Per)
        Key_List.Add(CLS_Config.K_Remark)
        Key_List.Add(CLS_Config.K_Reprint)
        Key_List.Add(CLS_Config.K_Membership)
        Key_List.Sort()

        'Key_No_List.Add(Keys.Decimal)

    End Sub
    Public Function in_Key_List(ByVal Key As Keys) As Boolean
        Try
            Dim i As Integer = 0
            For i = 0 To Key_List.Count - 1
                If Key = CType(Key_List.Item(i), Keys) Then
                    Return True
                End If
            Next

        Catch ex As Exception
            MSG.ErrorOk("[grdList_AfterRowInsert]" & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function in_Key_No_List(ByVal Key As Keys) As Boolean
        Try
            Dim i As Integer = 0
            For i = 0 To Key_No_List.Count - 1
                If Key = CType(Key_No_List.Item(i), Keys) Then
                    Return True
                End If
            Next

        Catch ex As Exception
            MSG.ErrorOk("[grdList_AfterRowInsert]" & vbCrLf & ex.Message)
        End Try
    End Function
    Public Enum AccountType
        None = 0
        Customer = 1
        Supplier = 2
        Stock = 3
        'Assets = 4
        'Libilities = 5
        Other_Revenue = 6
        Expenses = 7
        Cash = 8
        Bank = 9
        Owner = 10
        Employee = 11
        Salary = 12
    End Enum
    Public Enum ItemType
        StandardItem = 1
        WeighedItem = 2
        ExpireItem = 3
        Card = 4
        Subscription_Item = 5
        Serail_Item = 6
    End Enum
    Public Enum TransectionType
        CashSale = 1
        CreditSale = 2
        Hold = 3
        CashSaleReturn = 4
        CreditSaleReturn = 5
        Purchase = 6
        ManualAdjustment = 7
        CustomerPayment = 8
        SupplierPayment = 9
        Capital_Investment = 10
        Drawing = 11
        Other_Revenue = 12
        Expenses = 13
        Customer_Card_Payment = 14
        News_Subscription = 15
        Customer_News_Payment = 16
        Purchase_Return = 17
        Salary = 18
        Salary_Payment = 19
        Customer_Discount = 20
        Sales_Cancel = 21
    End Enum
    Public Enum PaymentType
        None = 0
        Cash = 1
        KNet = 2
        MasterCard = 3
        Cheque = 4
        Credit = 5
        KNet_Cash = 6
        MasterCard_Cash = 7
    End Enum
    Public Enum TableNo
        Sale_Entry = 0
        Item = 1
        Customer = 2
        D_Counter = 3
        Hold = 4
    End Enum
    Public Enum OperationType
        None = 0
        Info = 1
        Open_Item = 2
        Edit = 3
        Add = 4
        Open_Edit = 5
    End Enum
    Public Enum ReportType
        None = 0
        CategoryWiseSale = 1
        SubCategoryWiseSale = 2
        ItemWiseSale = 3
        CustomerWiseSale = 4
        CustomerWiseSaleDetail = 5
        SalesBelowCost = 6
        SlowMovement = 7
    End Enum
    Public Enum CostMethod
        CostFromPurchase = 1
        CostFromMargin = 2
        CostFromItemCard = 3
    End Enum

    Public Function ParameterQuestions(Optional ByVal ParaNO As Integer = 1) As String
        Dim result As String = Nothing
        If ParaNO < 1 Then
            Return Nothing
        Else
            Dim i As Integer = 1
            Do While i < ParaNO
                result = result & "?,"
                i = i + 1
            Loop
        End If
        Return result & "?"
    End Function
    Public Function FillDrop(ByRef Cmb As Infragistics.Win.UltraWinGrid.UltraCombo, ByVal DisplayMember As String, ByVal ValueMember As String, ByVal TblName As String, Optional ByVal HiddenMember1 As String = "", Optional ByVal HiddenMember2 As String = "", Optional ByVal HiddenMember3 As String = "", Optional ByVal HiddenMember4 As String = "", Optional ByVal HiddenMember5 As String = "", Optional ByVal HiddenMember6 As String = "", Optional ByVal HiddenMember7 As String = "", Optional ByVal HiddenMember8 As String = "", Optional ByVal HiddenMember9 As String = "")
        Try
            Dim COM As New System.Data.Odbc.OdbcCommand
            Dim CON As New System.Data.Odbc.OdbcConnection
            Dim DA As New System.Data.Odbc.OdbcDataAdapter
            Dim DT As New DataTable
            CON.ConnectionString = ConnStr
            CON.Open()

            COM.CommandText = "SELECT  " & ValueMember & " , " & DisplayMember & IIf(HiddenMember1 = "", "", " , " & HiddenMember1) & IIf(HiddenMember2 = "", "", " , " & HiddenMember2) & IIf(HiddenMember3 = "", "", " , " & HiddenMember3) & IIf(HiddenMember4 = "", "", " , " & HiddenMember4) & IIf(HiddenMember5 = "", "", " , " & HiddenMember5) & IIf(HiddenMember6 = "", "", " , " & HiddenMember6) & IIf(HiddenMember7 = "", "", " , " & HiddenMember7) & IIf(HiddenMember8 = "", "", " , " & HiddenMember8) & IIf(HiddenMember9 = "", "", " , " & HiddenMember9) & "  FROM " & TblName & " ORDER BY " & DisplayMember

            COM.CommandType = CommandType.Text
            COM.Connection = CON
            DA.SelectCommand = COM
            DA.Fill(DT)

            Cmb.DataSource = DT
            Cmb.DisplayMember = DisplayMember
            Cmb.ValueMember = ValueMember
            Cmb.DisplayLayout.Bands(0).Columns(ValueMember).Hidden = True

            Cmb.DisplayLayout.Bands(0).ColHeadersVisible = False
            Cmb.DisplayLayout.Bands(0).GroupHeadersVisible = False

            If HiddenMember1 <> "" Then
                Cmb.DisplayLayout.Bands(0).Columns(HiddenMember1).Hidden = True
            End If
            If HiddenMember2 <> "" Then
                Cmb.DisplayLayout.Bands(0).Columns(HiddenMember2).Hidden = True
            End If
            If HiddenMember3 <> "" Then
                Cmb.DisplayLayout.Bands(0).Columns(HiddenMember3).Hidden = True
            End If
            If HiddenMember4 <> "" Then
                Cmb.DisplayLayout.Bands(0).Columns(HiddenMember4).Hidden = True
            End If
            If HiddenMember5 <> "" Then
                Cmb.DisplayLayout.Bands(0).Columns(HiddenMember5).Hidden = True
            End If

            If HiddenMember6 <> "" Then
                Cmb.DisplayLayout.Bands(0).Columns(HiddenMember6).Hidden = True
            End If
            If HiddenMember7 <> "" Then
                Cmb.DisplayLayout.Bands(0).Columns(HiddenMember7).Hidden = True
            End If
            If HiddenMember8 <> "" Then
                Cmb.DisplayLayout.Bands(0).Columns(HiddenMember8).Hidden = True
            End If
            If HiddenMember9 <> "" Then
                Cmb.DisplayLayout.Bands(0).Columns(HiddenMember9).Hidden = True
            End If

            Cmb.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
            Cmb.DisplayLayout.Bands(0).Columns(DisplayMember).Width = 250

            'Cmb.DisplayLayout.Override.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            'Cmb.Appearance.TextHAlign = Infragistics.Win.HAlign.Right

            'Cmb.Appearance.FontData.BoldAsString = "True"
            'Cmb.Appearance.FontData.Name = "Arial"
            'Cmb.Appearance.FontData.SizeInPoints = 11.0!

            'Cmb.DisplayLayout.Override.CellAppearance.FontData.BoldAsString = "True"
            'Cmb.DisplayLayout.Override.CellAppearance.FontData.Name = "Arial"
            'Cmb.DisplayLayout.Override.CellAppearance.FontData.SizeInPoints = 11.0!

            Cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            'Cmb.Appearance.TextHAlign = Infragistics.Win.HAlign.Left

            CON.Close()
            CON.Dispose()

            COM.Dispose()

        Catch ex As System.Exception
            Throw (ex)
        End Try
    End Function
    Public Function FillDropByQuery(ByRef Cmb As Infragistics.Win.UltraWinGrid.UltraCombo, ByVal DisplayMember As String, ByVal ValueMember As String, ByVal Query As String)
        Try
            Dim COM As New System.Data.Odbc.OdbcCommand
            Dim CON As New System.Data.Odbc.OdbcConnection
            Dim DA As New System.Data.Odbc.OdbcDataAdapter
            Dim DT As New DataTable
            CON.ConnectionString = ConnStr
            CON.Open()


            COM.CommandText = Query

            COM.CommandType = CommandType.Text
            COM.Connection = CON
            DA.SelectCommand = COM
            DA.Fill(DT)

            Cmb.DataSource = DT
            Cmb.DisplayMember = DisplayMember
            Cmb.ValueMember = ValueMember
            Cmb.DisplayLayout.Bands(0).Columns(ValueMember).Hidden = True

            Cmb.DisplayLayout.Bands(0).ColHeadersVisible = False
            Cmb.DisplayLayout.Bands(0).GroupHeadersVisible = False


            Cmb.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
            Cmb.DisplayLayout.Bands(0).Columns(DisplayMember).Width = 250

            'Cmb.DisplayLayout.Override.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            'Cmb.Appearance.TextHAlign = Infragistics.Win.HAlign.Right

            'Cmb.Appearance.FontData.BoldAsString = "True"
            'Cmb.Appearance.FontData.Name = "Arial"
            'Cmb.Appearance.FontData.SizeInPoints = 11.0!

            'Cmb.DisplayLayout.Override.CellAppearance.FontData.BoldAsString = "True"
            'Cmb.DisplayLayout.Override.CellAppearance.FontData.Name = "Arial"
            'Cmb.DisplayLayout.Override.CellAppearance.FontData.SizeInPoints = 11.0!

            Cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            'Cmb.Appearance.TextHAlign = Infragistics.Win.HAlign.Left

            CON.Close()
            CON.Dispose()

            COM.Dispose()

        Catch ex As System.Exception
            Throw (ex)
        End Try
    End Function
    Public Function FillDropWithCondition(ByRef Cmb As Infragistics.Win.UltraWinGrid.UltraCombo, ByVal DisplayMember As String, ByVal ValueMember As String, ByVal TblName As String, Optional ByVal HiddenMember1 As String = "", Optional ByVal HiddenMember2 As String = "", Optional ByVal HiddenMember3 As String = "", Optional ByVal HiddenMember4 As String = "", Optional ByVal WherePart As String = "")
        Try
            Dim COM As New System.Data.Odbc.OdbcCommand
            Dim CON As New System.Data.Odbc.OdbcConnection
            Dim DA As New System.Data.Odbc.OdbcDataAdapter
            Dim DT As New DataTable
            CON.ConnectionString = ConnStr
            CON.Open()

            COM.CommandText = "SELECT  " & ValueMember & " , " & DisplayMember & IIf(HiddenMember1 = "", "", " , " & HiddenMember1) & IIf(HiddenMember2 = "", "", " , " & HiddenMember2) & IIf(HiddenMember3 = "", "", " , " & HiddenMember3) & IIf(HiddenMember4 = "", "", " , " & HiddenMember4) & " FROM " & TblName & WherePart & " ORDER BY " & DisplayMember
            COM.CommandType = CommandType.Text
            COM.Connection = CON
            DA.SelectCommand = COM
            DA.Fill(DT)

            Cmb.DataSource = DT
            Cmb.DisplayMember = DisplayMember
            Cmb.ValueMember = ValueMember
            Cmb.DisplayLayout.Bands(0).Columns(ValueMember).Hidden = True

            Cmb.DisplayLayout.Bands(0).ColHeadersVisible = False
            Cmb.DisplayLayout.Bands(0).GroupHeadersVisible = False

            If HiddenMember1 <> "" Then
                Cmb.DisplayLayout.Bands(0).Columns(HiddenMember1).Hidden = True
            End If
            If HiddenMember2 <> "" Then
                Cmb.DisplayLayout.Bands(0).Columns(HiddenMember2).Hidden = True
            End If
            If HiddenMember3 <> "" Then
                Cmb.DisplayLayout.Bands(0).Columns(HiddenMember3).Hidden = True
            End If
            If HiddenMember4 <> "" Then
                Cmb.DisplayLayout.Bands(0).Columns(HiddenMember4).Hidden = True
            End If

            Cmb.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
            Cmb.DisplayLayout.Bands(0).Columns(DisplayMember).Width = 250

            'Cmb.DisplayLayout.Override.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            'Cmb.Appearance.FontData.BoldAsString = "True"
            'Cmb.Appearance.FontData.Name = "Arial"
            'Cmb.Appearance.FontData.SizeInPoints = 11.0!

            'Cmb.DisplayLayout.Override.CellAppearance.FontData.BoldAsString = "True"
            'Cmb.DisplayLayout.Override.CellAppearance.FontData.Name = "Arial"
            'Cmb.DisplayLayout.Override.CellAppearance.FontData.SizeInPoints = 11.0!

            Cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            Cmb.Appearance.TextHAlign = Infragistics.Win.HAlign.Left

            CON.Close()
            CON.Dispose()

            COM.Dispose()

        Catch ex As System.Exception
            Throw (ex)
        End Try
    End Function
    Public Function GetNewCode(ByVal PK As String, ByVal TblName As String) As Integer
        Dim TheCode As Integer
        'Dim dr As OdbcDataReader
        Dim dr As OdbcDataReader

        Dim DBConn As New OdbcConnection(ConnStr)
        Try
            If DBConn.State <> ConnectionState.Open Then
                DBConn.Open()
            End If
            Dim Str As String = "SELECT MAX(" & PK & ") FROM " & TblName
            dr = New OdbcCommand(Str, DBConn).ExecuteReader
            If dr.Read Then
                TheCode = IIf(IsDBNull(dr(0)), 0, dr(0))
            End If
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show("___Error___" & ex.Message)
        Finally
            'Close DataReader And Connection
            dr.Close()
            dr = Nothing
            DBConn.Close()
        End Try
        Return TheCode + 1
    End Function

    Public Function GetMembershipNumber() As Int64
        Dim TheCode As Int64
        'Dim dr As OdbcDataReader
        Dim dr As OdbcDataReader

        Dim DBConn As New OdbcConnection(ConnStr)
        Try
            If DBConn.State <> ConnectionState.Open Then
                DBConn.Open()
            End If
            Dim Str As String = "SELECT MAX(MembershipNumber) FROM Membership"
            dr = New OdbcCommand(Str, DBConn).ExecuteReader
            If dr.Read Then
                TheCode = IIf(IsDBNull(dr(0)), 0, dr(0))
                If TheCode = 0 Then TheCode = CLS_Config.MembershipStartNumber
            End If
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show("___Error___" & ex.Message)
        Finally
            'Close DataReader And Connection
            dr.Close()
            dr = Nothing
            DBConn.Close()
        End Try
        Return TheCode + 1
    End Function

    Public Function ConvertToString(ByVal Num As Decimal, Optional ByVal Prefix2 As Boolean = True) As String
        Dim Result As String = Nothing
        Try
            Dim Prefix As String = Nothing
            Dim Sufix As String = Nothing
            Dim p As Integer = Num.ToString.IndexOf(".")
            If CType(Num, String).Contains(".") Then
                Prefix = Num.ToString.Substring(0, IIf(p < 0, 1, p))
                Sufix = Num.ToString.Substring(Num.ToString.IndexOf(".") + 1)
            Else
                Prefix = Num 'Num.ToString.Substring(0, IIf(p < 0, 1, p))
                Sufix = "" 'Num.ToString.Substring(Num.ToString.IndexOf(".") + 1)
            End If

            If Prefix2 Then
                Select Case Prefix.Length
                    Case 0 : Prefix = "00" & Prefix
                    Case 1 : Prefix = "0" & Prefix
                    Case 2 : Prefix = Prefix
                End Select
            Else
                Select Case Prefix.Length
                    Case 0 : Prefix = "0" & Prefix
                    Case 1 : Prefix = Prefix
                End Select

            End If

            Select Case CLS_Config.DecimalPlace
                  Case 1
                    Select Case Sufix.Length
                        Case 0 : Sufix = Sufix & "0"
                        Case 1 : Sufix = Sufix
                    End Select
                Case 2
                    Select Case Sufix.Length
                        Case 0 : Sufix = Sufix & "00"
                        Case 1 : Sufix = Sufix & "0"
                        Case 2 : Sufix = Sufix
                    End Select
                Case 3
                    Select Case Sufix.Length
                        Case 0 : Sufix = Sufix & "000"
                        Case 1 : Sufix = Sufix & "00"
                        Case 2 : Sufix = Sufix & "0"
                        Case 3 : Sufix = Sufix
                    End Select
            End Select

            If CLS_Config.DecimalPlace = 0 Then
                Result = Prefix
            Else
                Result = Prefix & "." & Sufix
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Result
    End Function
    
    Public Function Get_Grid_Total(ByVal Grid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal ColName As String) As Double
        Try
            Dim Result As Decimal = 0.0
            Dim a As Integer = 0
            Grid.Refresh()

            For a = 0 To Grid.Rows.Count - 1
                Result += Grid.Rows(a).Cells(ColName).Value
            Next

            Return Decimal.Round(Result, 3)
        Catch ex As Exception
            MSG.ErrorOk("[Get_Grid_Total]" & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function Get_Last_Bill() As Integer
        Dim PARA As New ArrayList
        PARA.Add(CLS_Config.Counter)
        If Now.Hour < 4 Then
            PARA.Add(Now.Date.AddDays(-1))
        Else
            PARA.Add(Now.Date)
        End If

        Return DBO.ExecuteSP_ReturnSingleValue("D_Counter_Last_Bill", PARA)
    End Function
    Public Function Update_Last_Bill() As Integer

        Dim PARA As New ArrayList
        PARA.Add(CLS_Config.Counter)
        If BillNumber > 0 Then PARA.Add(BillNumber - 1)
        If BillNumber = 0 Then PARA.Add(BillNumber)

        If Now.Hour < 4 Then
            PARA.Add(Now.Date.AddDays(-1))
        Else
            PARA.Add(Now.Date)
        End If

        Return DBO.ExecuteSP_ReturnSingleValue("D_Counter_Update", PARA)
    End Function
    Public Function Convert_Array_To_String(ByVal Arr As ArrayList) As String
        Dim Result As String = Nothing
        Try
            Dim I As Integer = 0
            For I = 0 To Arr.Count - 1
                Result = Result & Arr(I).ToString & vbCrLf
            Next
        Catch ex As Exception
            MSG.ErrorOk("[Convert_Array_To_String]" & vbCrLf & ex.Message)
        End Try
        Return Result
    End Function
    ''' <summary>
    ''' leaves a blank space before end doC
    ''' will cut if cutter available
    ''' will open cash drawer if enable in printer properties
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub PrintEmptySpace()
        Try
            If CLS_Config.PrintAtEnd Then Exit Sub


            'Dim str As String = ""
            'str = vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf

            'Dim pd As New PrintDialog()
            '' Open the printer dialog box, and then allow the user to select a printer.
            'pd.PrinterSettings.PrinterName = CLS_Config.ReceiptPrinter
            'RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, str)

            'century .counter 2 give error if /d:lpt1 IN OPEN CASH BOX
            'Try
            Printer_.Print()
            Printer_.EndDoc()
            'Catch ex As Exception

            'End Try

            'MsgBox("2")


            'Dim intFileNo As Integer = FreeFile()
            'FileOpen(1, "c:\escapes.txt", OpenMode.Output)
            'PrintLine(1, Chr(27) & Chr(105))

            'FileClose(1)
            'Shell("print /d:lpt1 c:\escapes.txt", vbNormalFocus)


            'Cut_Receipt()

            'Dim intFileNo2 As Integer = FreeFile()
            'FileOpen(1, "c:\escapes2.txt", OpenMode.Output)
            ''PrintLine(1, Chr(27) & Chr(112))
            'PrintLine(1, Chr(27) & Chr(112) & Chr(0) & Chr(25) & Chr(250))

            'FileClose(1)
            'Shell("print /d:lpt1 c:\escapes2.txt", vbNormalFocus)


        Catch ex As Exception
            MsgBox("PrintEmptySpace" & vbCrLf & ex.Message & vbCrLf & ex.InnerException.Message)
        End Try
    End Sub
    Public Sub PrintEmptySpace2()
        Try
            If CLS_Config.PrintAtEnd Then Exit Sub


            Dim str As String = ""
            str = vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf

            Dim pd As New PrintDialog()
            ' Open the printer dialog box, and then allow the user to select a printer.
            pd.PrinterSettings.PrinterName = CLS_Config.ReceiptPrinter
            RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, str)

            'century .counter 2 give error if /d:lpt1 IN OPEN CASH BOX
            'Try
            '    Printer_.Print()
            '    Printer_.EndDoc()
            'Catch ex As Exception

            'End Try

            'MsgBox("2")


            'Dim intFileNo As Integer = FreeFile()
            'FileOpen(1, "c:\escapes.txt", OpenMode.Output)
            'PrintLine(1, Chr(27) & Chr(105))

            'FileClose(1)
            'Shell("print /d:lpt1 c:\escapes.txt", vbNormalFocus)


            Cut_Receipt()

            'Dim intFileNo2 As Integer = FreeFile()
            'FileOpen(1, "c:\escapes2.txt", OpenMode.Output)
            ''PrintLine(1, Chr(27) & Chr(112))
            'PrintLine(1, Chr(27) & Chr(112) & Chr(0) & Chr(25) & Chr(250))

            'FileClose(1)
            'Shell("print /d:lpt1 c:\escapes2.txt", vbNormalFocus)


        Catch ex As Exception
            MsgBox("PrintEmptySpace2" & vbCrLf & ex.Message & vbCrLf & ex.InnerException.Message)
        End Try
    End Sub
    'Epson	TM-U220A - TM-U220PD
    '27,112,0,25,250 OR 27,112
    '27,112,0,75,250 OR 27,105
    ''' <summary>
    ''' only working with lpt printer
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub open_cashdrawer()
        If Not CLS_Config.Has_Cash_Drawer Then Exit Sub
        Dim intFileNo As Integer = FreeFile()
        Dim path As String = CashdrawerPath '"c:\escapes.txt" 'Application.ExecutablePath.Substring(0, Application.ExecutablePath.Length - 7) & "escapes.txt"
        FileOpen(1, path, OpenMode.Output)
        'PrintLine(1, ChrW(27) & "p" & vbNullChar & ChrW(25) & Chr(250))
        PrintLine(1, Chr(27) & "p" & Chr(0) & Chr(25) & Chr(250))
        FileClose(1)
        Shell("print /d:" & PrinterPort & " " & path, vbNormalFocus)
        'Shell("print /d:lpt1 " & path, vbNormalFocus)
        'Shell("print /d:ESDPRT001 " & path, vbNormalFocus)


        'FileSystem.FreeFile()
        'FileSystem.FileOpen(1, "c:\escapes.txt", OpenMode.Output, OpenAccess.[Default], OpenShare.[Default], -1)
        'FileSystem.PrintLine(1, DirectCast(ChrW(27) & "p" & vbNullChar & ChrW(25) & Conversions.ToString(Strings.Chr(250)), Object))
        'FileSystem.FileClose(1)
        'Interaction.Shell("print /d:lpt1 c:\escapes.txt", AppWinStyle.NormalFocus, False, -1)


    End Sub
    Public Sub Cut_Receipt()
        Try
            'CUT PAGE
            Dim intFileNo As Integer = FreeFile()
            FileOpen(1, "D:\escapes.txt", OpenMode.Output)
            PrintLine(1, Chr(27) & Chr(109))

            FileClose(1)
            'Shell("print /d:lpt1 d:\escapes.txt", vbNormalFocus)
            Shell("print /d:" & PrinterPort & " d:\escapes2.txt", vbNormalFocus)
            'Shell("print /d:" & PrinterPort & " " & Path, vbNormalFocus)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function ConvertSize(ByVal Str As String, ByVal Size As Integer, ByVal SpaceB4 As Boolean) As String
        Try
            Dim i As Integer = 0

            If Str.Length < Size Then

                Dim result As String = Str
                Dim Space As String = Nothing
                For i = Str.Length + 1 To Size
                    Space &= " "
                Next

                If SpaceB4 Then Return Space & result
                If Not SpaceB4 Then Return result & Space

            ElseIf Str.Length = Size Then
                Return Str
            ElseIf Str.Length > Size Then
                Return Str.Substring(0, Size)
            End If

        Catch ex As Exception
            MsgBox("ConvertSize" & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function VoucherTotal(ByVal DateFrom As DateTime, _
                                 ByVal DateTo As DateTime, _
                                 ByVal Account As Integer, _
                                 ByVal TransType As TransectionType, _
                                 ByVal PayType As PaymentType, _
                                 ByVal isDebit As Boolean, _
                                 ByVal User As Integer, _
                                 ByVal Counter As Integer) As Decimal
        Try

            Dim T As New DateTime(DateTo.Year, DateTo.Month, DateTo.Day, DateTo.Hour, DateTo.Minute, 59)
            DateTo = T

            Dim F As New DateTime(DateFrom.Year, DateFrom.Month, DateFrom.Day, DateFrom.Hour, DateFrom.Minute, 0)
            DateFrom = F

            Dim PARA As New ArrayList
            PARA.Add(Account)
            PARA.Add(TransType)
            PARA.Add(PayType)
            PARA.Add(Counter)
            PARA.Add(DateFrom)
            PARA.Add(DateTo)
            PARA.Add(User)
            PARA.Add(isDebit)

            Dim DT As New DataTable
            DT = DBO.ExecuteSP_ReturnDataTable("Voucher_Total", PARA)
            If DT.Rows.Count > 0 Then
                Return Decimal.Round(CDec(DT.Rows(0).Item(0)), 3)
            Else
                Return 0
            End If

        Catch ex As Exception
            MsgBox("VoucherTotal" & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function Sale_Profit(ByVal DateFrom As DateTime, _
                                     ByVal DateTo As DateTime, _
                                     ByVal isCash As Boolean, _
                                     ByVal Card As Boolean, _
                                     ByVal Counter As Integer) As Decimal
        Try

            Dim T As New DateTime(DateTo.Year, DateTo.Month, DateTo.Day, DateTo.Hour, DateTo.Minute, 59)
            DateTo = T

            Dim F As New DateTime(DateFrom.Year, DateFrom.Month, DateFrom.Day, DateFrom.Hour, DateFrom.Minute, 0)
            DateFrom = F

            Dim PARA As New ArrayList
            PARA.Add(DateFrom)
            PARA.Add(DateTo)
            PARA.Add(isCash)
            PARA.Add(Card)
            PARA.Add(Counter)

            Dim DT As New DataTable
            DT = DBO.ExecuteSP_ReturnDataTable("Sale_Profit", PARA)
            If DT.Rows.Count > 0 Then
                Return Decimal.Round(CDec(DT.Rows(0).Item(0)), 3)
            Else
                Return 0
            End If

        Catch ex As Exception
            MsgBox("Sale_Profit" & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function SaleTotal(ByVal DateFrom As DateTime, _
                                 ByVal DateTo As DateTime, _
                                 ByVal TransType As TransectionType, _
                                 ByVal User As Integer, _
                                 ByVal Counter As Integer) As Decimal
        Try

            Dim T As New DateTime(DateTo.Year, DateTo.Month, DateTo.Day, 23, 59, 59)
            DateTo = T

            Dim PARA As New ArrayList
            PARA.Add(TransType)
            PARA.Add(Counter)
            PARA.Add(DateFrom)
            PARA.Add(DateTo)
            PARA.Add(User)

            Dim DT As New DataTable
            DT = DBO.ExecuteSP_ReturnDataTable("Sales_Total", PARA)
            If DT.Rows.Count > 0 Then
                Return Decimal.Round(CDec(DT.Rows(0).Item(0)), 3)
            Else
                Return 0
            End If

        Catch ex As Exception
            MsgBox("VoucherTotal" & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function Sale_Count(ByVal DateFrom As DateTime, _
                               ByVal DateTo As DateTime, _
                                     ByRef Counter As Integer, _
                                     ByRef User As Integer, _
                                     ByRef CNTCash As Integer, _
                                     ByRef CNTKnet As Integer, _
                                     ByRef CNTMaster As Integer, _
                                     ByRef CNTCheque As Integer, _
                                     ByRef CNTCredit As Integer, _
                                     ByRef CNTKnetCash As Integer, _
                                     ByRef CNTMasterCash As Integer, _
                                     ByRef CNTCancel As Integer) As Decimal
        Try

            CNTCash = 0
            CNTKnet = 0
            CNTMaster = 0
            CNTCheque = 0
            CNTCredit = 0
            CNTKnetCash = 0
            CNTMasterCash = 0
            CNTCancel = 0

            Dim PARA As New ArrayList
            PARA.Add(DateFrom)
            PARA.Add(DateTo)
            PARA.Add(Counter)
            PARA.Add(User)

            Dim DS As New DataSet
            DS = DBO.ExecuteSP_ReturnDataSet("SaleCount", PARA)

            If DS.Tables(0).Rows.Count > 0 Then CNTCash = CInt(DS.Tables(0).Rows(0).Item(0))
            If DS.Tables(1).Rows.Count > 0 Then CNTKnet = CInt(DS.Tables(1).Rows(0).Item(0))
            If DS.Tables(2).Rows.Count > 0 Then CNTMaster = CInt(DS.Tables(2).Rows(0).Item(0))
            If DS.Tables(3).Rows.Count > 0 Then CNTCheque = CInt(DS.Tables(3).Rows(0).Item(0))
            If DS.Tables(4).Rows.Count > 0 Then CNTCredit = CInt(DS.Tables(4).Rows(0).Item(0))
            If DS.Tables(5).Rows.Count > 0 Then CNTKnetCash = CInt(DS.Tables(5).Rows(0).Item(0))
            If DS.Tables(6).Rows.Count > 0 Then CNTMasterCash = CInt(DS.Tables(6).Rows(0).Item(0))
            If DS.Tables(7).Rows.Count > 0 Then CNTCancel = CInt(DS.Tables(7).Rows(0).Item(0))


        Catch ex As Exception
            MsgBox("Sale_Count" & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function NumToString(ByVal nNumber As Decimal) As String

        Dim bNegative As Boolean
        Dim bHundred As Boolean

        If nNumber < 0 Then
            bNegative = True
        End If

        nNumber = Abs(Int(nNumber))

        If nNumber < 1000 Then
            If nNumber \ 100 > 0 Then
                NumToString = NumToString & _
                     NumToString(nNumber \ 100) & " Hundred"
                bHundred = True
            End If
            nNumber = nNumber - ((nNumber \ 100) * 100)
            Dim bNoFirstDigit As Boolean
            bNoFirstDigit = False
            Select Case nNumber \ 10
                Case 0
                    Select Case nNumber Mod 10
                        Case 0
                            If Not bHundred Then
                                NumToString = NumToString & " Zero"
                            End If
                        Case 1 : NumToString = NumToString & " One"
                        Case 2 : NumToString = NumToString & " Two"
                        Case 3 : NumToString = NumToString & " Three"
                        Case 4 : NumToString = NumToString & " Four"
                        Case 5 : NumToString = NumToString & " Five"
                        Case 6 : NumToString = NumToString & " Six"
                        Case 7 : NumToString = NumToString & " Seven"
                        Case 8 : NumToString = NumToString & " Eight"
                        Case 9 : NumToString = NumToString & " Nine"
                    End Select
                    bNoFirstDigit = True
                Case 1
                    Select Case nNumber Mod 10
                        Case 0 : NumToString = NumToString & " Ten"
                        Case 1 : NumToString = NumToString & " Eleven"
                        Case 2 : NumToString = NumToString & " Twelve"
                        Case 3 : NumToString = NumToString & " Thirteen"
                        Case 4 : NumToString = NumToString & " Fourteen"
                        Case 5 : NumToString = NumToString & " Fifteen"
                        Case 6 : NumToString = NumToString & " Sixteen"
                        Case 7 : NumToString = NumToString & " Seventeen"
                        Case 8 : NumToString = NumToString & " Sighteen"
                        Case 9 : NumToString = NumToString & " Nineteen"
                    End Select
                    bNoFirstDigit = True
                Case 2 : NumToString = NumToString & " Twenty"
                Case 3 : NumToString = NumToString & " Thirty"
                Case 4 : NumToString = NumToString & " Forty"
                Case 5 : NumToString = NumToString & " Fifty"
                Case 6 : NumToString = NumToString & " Sixty"
                Case 7 : NumToString = NumToString & " Seventy"
                Case 8 : NumToString = NumToString & " Eighty"
                Case 9 : NumToString = NumToString & " Ninety"
            End Select
            If Not bNoFirstDigit Then
                If nNumber Mod 10 <> 0 Then
                    NumToString = NumToString & "-" & _
                                  Mid(NumToString(nNumber Mod 10), 2)
                End If
            End If
        Else
            Dim nTemp As Decimal
            nTemp = 10 ^ 12 'trillion
            Do While nTemp >= 1
                If nNumber >= nTemp Then
                    NumToString = NumToString & _
                                  NumToString(Int(nNumber / nTemp))
                    Select Case Int(Log(nTemp) / Log(10) + 0.5)
                        Case 12 : NumToString = NumToString & " Trillion"
                        Case 9 : NumToString = NumToString & " Billion"
                        Case 6 : NumToString = NumToString & " Million"
                        Case 3 : NumToString = NumToString & " Thousand"
                    End Select

                    nNumber = nNumber - (Int(nNumber / nTemp) * nTemp)
                End If
                nTemp = nTemp / 1000
            Loop
        End If

        If bNegative Then
            NumToString = " Negative" & NumToString
        End If

    End Function
    Public Function DollarToString(ByVal nAmount As Decimal) As String

        Dim Dinar As Decimal
        Dim Fils As Decimal

        Dinar = Int(nAmount)
        Fils = (Abs(nAmount) * 1000) Mod 1000

        DollarToString = NumToString(Dinar) & " Dinar"

        If Abs(Dinar) <> 1 Then
            DollarToString = DollarToString & "s"
        End If

        DollarToString = DollarToString & " And" & _
                         NumToString(Fils) & " Fils"

        If Abs(Fils) <> 1 Then
            DollarToString = DollarToString & ""
        End If

    End Function
    Public Function OpeningBalance(ByVal TillDate As DateTime, ByVal Account As Integer) As Decimal
        Try
            Dim DT As New DataTable
            Dim PARA As New ArrayList
            PARA.Add(Account)
            PARA.Add(TillDate)
            DT = DBO.ExecuteSP_ReturnDataTable("VoucherBalance", PARA)

            If DT.Rows.Count > 0 Then
                Return Decimal.Round(CDec(DT.Rows(0).Item(0)), 3)
            Else
                Return 0
            End If

        Catch ex As Exception
            MsgBox("OpeningBalance" & vbCrLf & ex.Message)
        End Try
    End Function

    Private PlaySound As New System.Media.SoundPlayer
    Public Sub PlaySoundFile(ByVal SoundPath As String)
        PlaySound.SoundLocation = SoundPath
        PlaySound.Load()
        PlaySound.Play()
    End Sub
    Public Function getDaysOfMonth(ByVal tYear As Integer, ByVal tMonth As Integer) As Integer
        Dim days As Integer = 31
        Select Case tMonth
            Case 1, 3, 5, 7, 8, 10, 12
                days = 31
            Case 4, 6, 9, 11
                days = 30
            Case 2
                If Date.IsLeapYear(tYear) Then
                    days = 29
                Else
                    days = 28
                End If
        End Select
        Return days
    End Function
    Public Function getValueFromDrop(ByVal DT As DataTable, ByVal PK As String, ByVal PKValue As String, ByVal ColGet As String) As String
        Try
            Dim dr() As DataRow = DT.Select(PK & "='" & PKValue & "'")
            If dr.Length > 0 Then
                Return FixControls.FixObjectString(dr(0).Item(ColGet))
            End If
            Return "0"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    'Public Function getNewCode(ByVal TableName As String, Optional Connection_String As String = Nothing) As Integer
    '    Dim Result As Integer = 0
    '    Try
    '        Using CONTEXT = New POSEntities
    '            Select Case TableName
    '                Case DBTable.Sales_Batch
    '                    Dim q = (From s In CONTEXT.Activations Select s.Code)
    '                    If q.Count > 0 Then Result = q.Max()
    '            End Select
    '        End Using

    '    Catch ex As Exception
    '    End Try
    '    Return Result + 1

    'End Function

    Public _ActivationCode As String
    Public Function CheckActivation() As Boolean
        Try
            _ActivationCode = FingerPrint2.FingerPrint.Value(ProjectKey)

            Using CONTEXT = New POSEntities
                Dim _Activation As New Activation
                _Activation = Nothing
                _Activation = (From obj In CONTEXT.Activations Where obj.ActivationCode = _ActivationCode Select obj).ToList().SingleOrDefault()

                If IsDBNull(_Activation) OrElse IsNothing(_Activation) Then
                    Dim frm As New FingerPrint2.frmSetKet(ProjectKey)
                    If frm.ShowDialog() = DialogResult.Yes Then
                        _Activation = New Activation
                        _Activation.Code = GetNewCode("Code", DBTable.Activation)
                        _Activation.UserName = FingerPrint2.FingerPrint.cpuId
                        _Activation.ActivationCode = FingerPrint2.FingerPrint.fingerPrint
                        _Activation.TimeStamp = Now
                        CONTEXT.Activations.AddObject(_Activation)
                        CONTEXT.SaveChanges()
                    Else
                        MsgBox("Invalid  Activation Code. Application Will Close")
                        Application.Exit()
                        Return False
                    End If
                    'Dim ActivationResult As System.Windows.Forms.DialogResult
                    'Dim frmActivationIns As New frmActivation
                    'ActivationResult = frmActivationIns.ShowDialog()
                    'If ActivationResult <> DialogResult.Yes Then
                    '    MsgBox("INVALID  ACTIVATION CODE. APPLICATION WILL CLOSE")
                    '    Application.Exit()
                    '    Return False
                    'End If
                End If

                If onTrial Then
                    If BDate < Now.Date AndAlso ForceC Then
                        CONTEXT.Activations.DeleteObject(_Activation)
                        CONTEXT.SaveChanges()
                        MsgBox("DATABASE GOT CORRUPTED. PLEASE CONTACT THE SOFTWARE COMPANY.")
                        Application.Exit()
                        Return False
                    End If
                End If


            End Using


            'Dim ActivationCode As String = FingerPrint.Value("NayeeM PakawalA")
            'Dim isActivate As Integer = FixControls.FixObjectNumber(DBO.GetSingleValue("SELECT COALESCE(Code,0) AS Code FROM Activation WHERE ActivationCode = '" & ActivationCode & "'"))
            'If isActivate = Nothing Then
            '    Dim ActivationResult As System.Windows.Forms.DialogResult
            '    Dim frmActivationIns As New frmActivation
            '    ActivationResult = frmActivationIns.ShowDialog()
            '    If ActivationResult <> DialogResult.Yes Then
            '        MsgBox("Invalid  Activation Code. Application Will Close")
            '        Application.Exit()
            '        Return False
            '    End If
            'End If




            Return True

        Catch ex As Exception

        End Try
    End Function


    Public Enum XML_Section As Integer
        ItemList = 1
        ItemSearch = 2
        ItemClass = 3
        ItemDrillDownEnquiry = 4
    End Enum
    Public Function Load_Save_XML(ByVal Section As XML_Section, ByRef Grid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal isLoading As Boolean) As Boolean
        Try

            If FixControls.FixObjectString(CLS_Config.ReportPath) = Nothing Then Return False

            Dim FileName As String = Nothing
            Dim PropertyCategories As Infragistics.Win.UltraWinGrid.PropertyCategories = Infragistics.Win.UltraWinGrid.PropertyCategories.All

            Select Case Section

                Case XML_Section.ItemList
                    FileName = CLS_Config.ReportPath & "\ItemList.xml"
                    'PropertyCategories = Infragistics.Win.UltraWinGrid.PropertyCategories.SortedColumns
                Case XML_Section.ItemSearch
                    FileName = CLS_Config.ReportPath & "\ItemSearch.xml"
                Case XML_Section.ItemClass
                    FileName = CLS_Config.ReportPath & "\ItemClass.xml"
                Case XML_Section.ItemDrillDownEnquiry
                    FileName = CLS_Config.ReportPath & "\ItemDrillDownEnquiry.xml"

            End Select

            If isLoading Then
                If File.Exists(FileName) Then
                    Grid.DisplayLayout.LoadFromXml(FileName, PropertyCategories)
                    Return True
                End If
            Else
                Grid.DisplayLayout.SaveAsXml(FileName, PropertyCategories)
                Return True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Sub Export(ByVal GRID As Infragistics.Win.UltraWinGrid.UltraGrid)
        Try
            If GRID.Rows.VisibleRowCount = 0 Then
                MsgBox("No record in the List.")
            Else
                Dim SaveDialog As New System.Windows.Forms.SaveFileDialog
                SaveDialog.Title = "Select appropreate location."
                SaveDialog.Filter = "(*.xls)|*.xls"
                Dim result As DialogResult = SaveDialog.ShowDialog()
                If SaveDialog.FileName <> "" Then
                    If result = Windows.Forms.DialogResult.OK Then
                        Dim fname As String = SaveDialog.FileName
                        Dim UltraGridExcelExporter1 As New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
                        UltraGridExcelExporter1.Export(GRID, fname)
                        MsgBox("The file was Saved Successfully") ' TO DO
                        System.IO.File.Open(fname, IO.FileMode.Open)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Export" & ex.Message)
        End Try


    End Sub

    Public Function TrimStr(ByVal Val As Object) As String
        If IsDBNull(Val) Or IsNothing(Val) Then Return ""
        If Trim(Val) = "" Then Return ""
        If Trim(Val) = Nothing Then Return ""
        Return CStr(Trim(Val))
    End Function
    Public Function TrimDec(ByVal Val As Object) As Double
        If IsDBNull(Val) Or IsNothing(Val) Then Return Nothing
        If Trim(Val) = Nothing Then Return Nothing
        Return CDec(Trim(Val))
    End Function
    Public Function TrimInt(ByVal Val As Object) As Integer
        If IsDBNull(Val) Or IsNothing(Val) Then Return 0
        If Trim(Val) = Nothing Then Return 0
        If Trim(Val) = "" Then Return 0
        Return CInt(Trim(Val))
    End Function
    Public Function TrimDate(ByVal Val As Object) As Date
        If IsDBNull(Val) Or IsNothing(Val) Then Return Null_Date
        If Val = Nothing Then Return Null_Date
        Return CDate(Val)
    End Function
    Public Function TrimBoolean(ByVal Val As Object) As Boolean
        If IsDBNull(Val) Or IsNothing(Val) Then Return False
        If Val = Nothing Then Return False
        Return CBool(Val)
    End Function


    Public Function Load_Img(ByVal PhotoPath As String) As Image
        Dim Imge As Image = Nothing
        Try

            If File.Exists(PhotoPath) Then
                Imge = PureImage(GetPhoto(PhotoPath))
            Else
                'Imge = Img.PureImage(GetPhoto(m_Blank_Image))
            End If

        Catch ex As Exception
            'Me.PicBox.Image = Nothing
            Imge = Nothing
        End Try
        Return Imge
    End Function
    Public Function PureImage(binaryImg As Byte()) As Image
        Try
            Dim ms As New MemoryStream(binaryImg)
            Return Image.FromStream(ms)
        Catch
            Return Nothing
        End Try
    End Function
    Public Function GetPhoto(ByVal filePath As String) As Byte()
        Dim fs As FileStream = New FileStream(filePath, FileMode.Open, FileAccess.Read)
        Dim br As BinaryReader = New BinaryReader(fs)
        Dim photo() As Byte = br.ReadBytes(fs.Length)
        br.Close()
        fs.Close()
        Return photo
    End Function

    Public Sub PromoRefresh()
        Using CONTEXT = New POSEntities

            Dim sql = (From q In CONTEXT.Item_Set
                                           Where If(q.PromoFrom, New DateTime(1900, 1, 1)) <= DateTime.Now _
                                           AndAlso If(q.PromoTo, New DateTime(1900, 1, 1)) > DateTime.Now _
                                           AndAlso If(q.PromoStockSold, 0.0) < If(q.PromoStockLimit, 0.0)
                                           Order By q.Code Select q)
            If sql.Count > 0 Then
                Dim NewPromoCode As Integer = 0
                Dim a = (From s In CONTEXT.Promotions Select s.Code)
                If a.Count > 0 Then NewPromoCode = a.Max()
                NewPromoCode = NewPromoCode + 1

                Dim IList As List(Of Item_) = sql.ToList
                For Each Itm In IList
                    Itm.onPromo = True

                    Dim Promo As New Promotion
                    Promo = (From q In CONTEXT.Promotions Where q.ItemCode = Itm.Code AndAlso q.PromoFrom = Itm.PromoFrom AndAlso q.PromoTo = Itm.PromoTo Select q).ToList.FirstOrDefault
                    If IsDBNull(Promo) OrElse IsNothing(Promo) Then
                        Promo = New Promotion
                        Promo.Code = NewPromoCode
                        Promo.ItemCode = Itm.Code
                        Promo.onPromo = True
                        Promo.PromoFrom = Itm.PromoFrom
                        Promo.PromoTo = Itm.PromoTo
                        Promo.PromoPrice = TrimDec(Itm.PromoPrice)
                        Promo.PromoStockLimit = TrimDec(Itm.PromoStockLimit)
                        Promo.PromoStockSold = TrimDec(Itm.PromoStockSold)
                        CONTEXT.Promotions.AddObject(Promo)
                        NewPromoCode = NewPromoCode + 1
                    Else
                        Promo.onPromo = True
                        Promo.PromoPrice = TrimDec(Itm.PromoPrice)
                        Promo.PromoStockLimit = TrimDec(Itm.PromoStockLimit)
                        Promo.PromoStockSold = TrimDec(Itm.PromoStockSold)
                    End If
                Next

            End If
          

            Dim sql2 = (From q In CONTEXT.Item_Set
                        Where ( _
                            (If(q.PromoFrom, New DateTime(1900, 1, 1)) < DateTime.Now AndAlso If(q.PromoTo, New DateTime(1900, 1, 1)) < DateTime.Now) _
                            OrElse (If(q.PromoStockSold, 0.0) >= If(q.PromoStockLimit, 0.0)) _
                            ) _
                        AndAlso If(q.PromoTo, New DateTime(1900, 1, 1)) <> Null_Date _
                        AndAlso If(q.onPromo, False) = True _
                        Order By q.Code Select q)
            If sql2.Count > 0 Then
                Dim UList As List(Of Item_) = sql2.ToList
                For Each Itm In UList
                    Itm.onPromo = False

                    Dim Promo As New Promotion
                    Promo = (From q In CONTEXT.Promotions Where q.ItemCode = Itm.Code AndAlso q.PromoFrom = Itm.PromoFrom AndAlso q.PromoTo = Itm.PromoTo Select q).ToList.FirstOrDefault
                    If IsDBNull(Promo) OrElse IsNothing(Promo) Then
                    Else
                        Promo.onPromo = False
                    End If
                Next
            End If

            
            'Dim sql3 = (From q In CONTEXT.Item_Set Where If(q.PromoStockSold, 0.0) >= If(q.PromoStockLimit, 0.0) AndAlso If(q.onPromo, False) = True Order By q.Code Select q)
            'If sql3.Count > 0 Then
            '    Dim U2List As List(Of Item_) = sql3.ToList
            '    For Each Itm In U2List
            '        Itm.onPromo = False

            '        Dim Promo As New Promotion
            '        Promo = (From q In CONTEXT.Promotions Where q.ItemCode = Itm.Code AndAlso q.PromoFrom = Itm.PromoFrom AndAlso q.PromoTo = Itm.PromoTo Select q).ToList.FirstOrDefault
            '        If IsDBNull(Promo) OrElse IsNothing(Promo) Then
            '        Else
            '            Promo.onPromo = False
            '        End If
            '    Next
            'End If


            Dim sql4 = (From q In CONTEXT.Promotions
                        Where ( _
                            (If(q.PromoFrom, New DateTime(1900, 1, 1)) < DateTime.Now AndAlso If(q.PromoTo, New DateTime(1900, 1, 1)) < DateTime.Now) _
                            OrElse (If(q.PromoStockSold, 0.0) >= If(q.PromoStockLimit, 0.0)) _
                            ) _
                        AndAlso If(q.PromoTo, New DateTime(1900, 1, 1)) <> Null_Date _
                        AndAlso If(q.onPromo, False) = True _
                        Order By q.Code Select q)
            If sql4.Count > 0 Then
                Dim UList As List(Of Promotion) = sql4.ToList
                For Each promo In UList
                    promo.onPromo = False
                    promo.Item.onPromo = False
                Next
            End If


            CONTEXT.SaveChanges()

        End Using

    End Sub

End Module

