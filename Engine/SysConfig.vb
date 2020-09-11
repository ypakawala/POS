Imports POS.FixControls

Public Class SysConfig

    Private m_Code As Integer = 0
    Private m_CompanyName As String = ""
    Private m_Tel As String = ""
    Private m_Mob As String = ""
    Private m_Fax As String = ""
    Private m_Address1 As String = ""
    Private m_Address2 As String = ""
    Private m_Address3 As String = ""
    Private m_AccCash As Integer = 0
    Private m_AccBank As Integer = 0
    Private m_AccStock As Integer = 0
    Private m_AccKnet As Integer = 0
    Private m_AccMaster As Integer = 0
    Private m_AccSalesReturn As Integer = 0
    Private m_AccDiscount As Integer = 0
    Private m_AccCreditSalesReturn As Integer = 0
    Private m_AccCapital As Integer = 0
    Private m_AccDrawing As Integer = 0
    Private m_AccCashCustomer As Integer = 0
    Private m_OpenSalesForm As Boolean = False
    Private m_AddSalesDetail As Boolean = False
    Private m_AddPurchaseDetail As Boolean = False
    Private m_CardCategory As Integer = 0
    Private m_NewsPaperCategory As Integer = 0
    Private m_DefaultCategory As Integer = 0
    Private m_DefaultSubCategory As Integer = 0
    'Private m_BigReceiprPrinter As Boolean = False
    Private m_SearchByBarcode As Boolean = False
    Private m_ResetReceiptYearly As Boolean = False
    Private m_NewSalesScreen As Boolean = False
    Private m_AccSalary As Integer = 0
    Private m_AccTempCredit As Integer = 0
    Private m_MonthBasePayment As Boolean = False
    Private m_DecimalPlace As Integer = 3
    Private m_ShowImage As Boolean = False
    Private m_BarcodeShowCompany As Boolean = False
    Private m_BarcodeShowItem As Boolean = False
    Private m_BarcodeShowPrice As Boolean = False
    Private m_BarcodeGap As Integer = 0
    Private m_BarcodeHeight As Integer = 0
    Private m_BarcodeWidth As Integer = 0
    Private m_BarcodeLeft As Integer = 0
    Private m_BarcodeTop As Integer = 0
    Private m_BarcodeFontSize As Integer = 0
    Private m_BarcodeType As Integer = 0
    Private m_AccSuspense As Integer = 0
    Private m_MembershipSystem As Boolean = False
    Private m_MembershipAmt2Point As Decimal = 0.0
    Private m_MembershipPoint2Amt As Decimal = 0.0
    Private m_MembershipStartNumber As Int64 = 0
    Private m_MembershipRedemptionCash As Boolean = False
    Private m_MembershipRedemptionReward As Boolean = False

    Private m_Company As String = ""
    Private m_Counter As String = ""
    Private m_ReceiptPrinter As String = ""
    Private m_BarcodePrinter As String = ""
    Private m_ComPort As String = ""
    Private m_ReportPath As String = ""

    Private m_Add As Keys = Nothing
    Private m_Add2 As Keys = Nothing
    Private m_Info As Keys = Nothing
    Private m_Delete As Keys = Nothing
    Private m_Delete2 As Keys = Nothing
    Private m_Multiply As Keys = Nothing
    Private m_Multiply2 As Keys = Nothing
    Private m_Price As Keys = Nothing
    Private m_Price2 As Keys = Nothing
    Private m_Cash As Keys = Nothing
    Private m_Cash2 As Keys = Nothing
    Private m_Credit_Sale As Keys = Nothing
    Private m_Payment As Keys = Nothing
    Private m_Balance As Keys = Nothing
    Private m_SalesReturn As Keys = Nothing
    Private m_Discount As Keys = Nothing
    Private m_Hold As Keys = Nothing
    Private m_Repeat As Keys = Nothing
    Private m_Open_Item As Keys = Nothing
    Private m_Knet As Keys = Nothing
    Private m_MasterVisa As Keys = Nothing
    Private m_Clear As Keys = Nothing
    Private m_ClearBox As Keys = Nothing
    Private m_Close As Keys = Nothing
    Private m_Print As Keys = Nothing
    Private m_ItemList As Keys = Nothing
    Private m_CustomerList As Keys = Nothing
    Private m_EditBill As Keys = Nothing
    Private m_Discount_Per As Keys = Nothing
    Private m_Has_Cash_Drawer As Boolean = True
    Private m_Has_Print_Cut As Boolean = True
    Private m_DisplayPole_Method As Integer = 0
    'Private m_Has_Display_Pole As Boolean = True
    'Private m_Has_New_Display_Pole As Boolean = True
    'Private m_Has_Recp_Print As Boolean = True
    Private m_Remark As Keys = Nothing
    Private m_Reprint As Keys = Nothing
    Private m_Membership As Keys = Nothing

    Private m_A4Printer As Boolean = False
    Private m_PrintAtEnd As Boolean = False

    Private m_Add_S As String = Nothing
    Private m_Add2_S As String = Nothing
    Private m_Info_S As String = Nothing
    Private m_Delete_S As String = Nothing
    Private m_Delete2_S As String = Nothing
    Private m_Multiply_S As String = Nothing
    Private m_Multiply2_S As String = Nothing
    Private m_Price_S As String = Nothing
    Private m_Price2_S As String = Nothing
    Private m_Cash_S As String = Nothing
    Private m_Cash2_S As String = Nothing
    Private m_Credit_Sale_S As String = Nothing
    Private m_Payment_S As String = Nothing
    Private m_Balance_S As String = Nothing
    Private m_SalesReturn_S As String = Nothing
    Private m_Discount_S As String = Nothing
    Private m_Hold_S As String = Nothing
    Private m_Repeat_S As String = Nothing
    Private m_Open_Item_S As String = Nothing
    Private m_Knet_S As String = Nothing
    Private m_MasterVisa_S As String = Nothing
    Private m_Clear_S As String = Nothing
    Private m_ClearBox_S As String = Nothing
    Private m_Close_S As String = Nothing
    Private m_Print_S As String = Nothing
    Private m_ItemList_S As String = Nothing
    Private m_CustomerList_S As String = Nothing
    Private m_EditBill_S As String = Nothing
    Private m_Discount_Per_S As String = Nothing
    Private m_Remark_S As String = Nothing
    Private m_Reprint_S As String = Nothing
    Private m_Membership_S As String = Nothing


    'Private m_BarcodeHeight As Integer = 122
    'Private m_BarcodeWidth As Integer = 300
    'Private m_BarcodeName As Boolean = 1
    'Private m_BarcodePrice As Boolean = 1
    'Private m_BarcodeLeft As Integer = 0
    'Private m_BarcodeTop As Integer = 85
    'Private m_BarcodeGap As Integer = 30


    Public Property Code() As Integer
        Get
            Return m_Code
        End Get
        Set(ByVal value As Integer)
            m_Code = value
        End Set
    End Property
    Public Property CompanyName() As String
        Get
            Return m_CompanyName
        End Get
        Set(ByVal value As String)
            m_CompanyName = value
        End Set
    End Property
    Public Property Tel() As String
        Get
            Return m_Tel
        End Get
        Set(ByVal value As String)
            m_Tel = value
        End Set
    End Property
    Public Property Mob() As String
        Get
            Return m_Mob
        End Get
        Set(ByVal value As String)
            m_Mob = value
        End Set
    End Property
    Public Property Fax() As String
        Get
            Return m_Fax
        End Get
        Set(ByVal value As String)
            m_Fax = value
        End Set
    End Property
    Public Property Address1() As String
        Get
            Return m_Address1
        End Get
        Set(ByVal value As String)
            m_Address1 = value
        End Set
    End Property
    Public Property Address2() As String
        Get
            Return m_Address2
        End Get
        Set(ByVal value As String)
            m_Address2 = value
        End Set
    End Property
    Public Property Address3() As String
        Get
            Return m_Address3
        End Get
        Set(ByVal value As String)
            m_Address3 = value
        End Set
    End Property

    Public Property AccCash() As Integer
        Get
            Return m_AccCash
        End Get
        Set(ByVal value As Integer)
            m_AccCash = value
        End Set
    End Property
    Public Property AccBank() As Integer
        Get
            Return m_AccBank
        End Get
        Set(ByVal value As Integer)
            m_AccBank = value
        End Set
    End Property
    Public Property AccStock() As Integer
        Get
            Return m_AccStock
        End Get
        Set(ByVal value As Integer)
            m_AccStock = value
        End Set
    End Property
    Public Property AccKnet() As Integer
        Get
            Return m_AccKnet
        End Get
        Set(ByVal value As Integer)
            m_AccKnet = value
        End Set
    End Property
    Public Property AccMaster() As Integer
        Get
            Return m_AccMaster
        End Get
        Set(ByVal value As Integer)
            m_AccMaster = value
        End Set
    End Property
    Public Property AccSalesReturn() As Integer
        Get
            Return m_AccSalesReturn
        End Get
        Set(ByVal value As Integer)
            m_AccSalesReturn = value
        End Set
    End Property
    Public Property AccDiscount() As Integer
        Get
            Return m_AccDiscount
        End Get
        Set(ByVal value As Integer)
            m_AccDiscount = value
        End Set
    End Property
    Public Property AccCreditSalesReturn() As Integer
        Get
            Return m_AccCreditSalesReturn
        End Get
        Set(ByVal value As Integer)
            m_AccCreditSalesReturn = value
        End Set
    End Property
    Public Property AccCapital() As Integer
        Get
            Return m_AccCapital
        End Get
        Set(ByVal value As Integer)
            m_AccCapital = value
        End Set
    End Property
    Public Property AccCashCustomer() As Integer
        Get
            Return m_AccCashCustomer
        End Get
        Set(ByVal value As Integer)
            m_AccCashCustomer = value
        End Set
    End Property
    Public Property AccDrawing() As Integer
        Get
            Return m_AccDrawing
        End Get
        Set(ByVal value As Integer)
            m_AccDrawing = value
        End Set
    End Property
    Public Property OpenSalesForm() As Boolean
        Get
            Return m_OpenSalesForm
        End Get
        Set(ByVal value As Boolean)
            m_OpenSalesForm = value
        End Set
    End Property
    Public Property AddSalesDetail() As Boolean
        Get
            Return m_AddSalesDetail
        End Get
        Set(ByVal value As Boolean)
            m_AddSalesDetail = value
        End Set
    End Property
    Public Property AddPurchaseDetail() As Boolean
        Get
            Return m_AddPurchaseDetail
        End Get
        Set(ByVal value As Boolean)
            m_AddPurchaseDetail = value
        End Set
    End Property
    Public Property CardCategory() As Integer
        Get
            Return m_CardCategory
        End Get
        Set(ByVal value As Integer)
            m_CardCategory = value
        End Set
    End Property
    Public Property NewsPaperCategory() As Integer
        Get
            Return m_NewsPaperCategory
        End Get
        Set(ByVal value As Integer)
            m_NewsPaperCategory = value
        End Set
    End Property
    Public Property DefaultCategory() As Integer
        Get
            Return m_DefaultCategory
        End Get
        Set(ByVal value As Integer)
            m_DefaultCategory = value
        End Set
    End Property
    Public Property DefaultSubCategory() As Integer
        Get
            Return m_DefaultSubCategory
        End Get
        Set(ByVal value As Integer)
            m_DefaultSubCategory = value
        End Set
    End Property
    'Public Property BigReceiprPrinter() As Boolean
    '    Get
    '        Return m_BigReceiprPrinter
    '    End Get
    '    Set(ByVal value As Boolean)
    '        m_BigReceiprPrinter = value
    '    End Set
    'End Property
    Public Property SearchByBarcode() As Boolean
        Get
            Return m_SearchByBarcode
        End Get
        Set(ByVal value As Boolean)
            m_SearchByBarcode = value
        End Set
    End Property
    Public Property ResetReceiptYearly() As Boolean
        Get
            Return m_ResetReceiptYearly
        End Get
        Set(ByVal value As Boolean)
            m_ResetReceiptYearly = value
        End Set
    End Property
    Public Property NewSalesScreen() As Boolean
        Get
            Return m_NewSalesScreen
        End Get
        Set(ByVal value As Boolean)
            m_NewSalesScreen = value
        End Set
    End Property
    Public Property AccTempCredit() As Integer
        Get
            Return m_AccTempCredit
        End Get
        Set(ByVal value As Integer)
            m_AccTempCredit = value
        End Set
    End Property
    Public Property MonthBasePayment() As Boolean
        Get
            Return m_MonthBasePayment
        End Get
        Set(ByVal value As Boolean)
            m_MonthBasePayment = value
        End Set
    End Property
    Public Property DecimalPlace() As Integer
        Get
            Return m_DecimalPlace
        End Get
        Set(ByVal value As Integer)
            m_DecimalPlace = value
        End Set
    End Property
    Public Property ShowImage() As Boolean
        Get
            Return m_ShowImage
        End Get
        Set(ByVal value As Boolean)
            m_ShowImage = value
        End Set
    End Property
    Public Property BarcodeShowCompany() As Boolean
        Get
            Return m_BarcodeShowCompany
        End Get
        Set(ByVal value As Boolean)
            m_BarcodeShowCompany = value
        End Set
    End Property
    Public Property BarcodeShowItem() As Boolean
        Get
            Return m_BarcodeShowItem
        End Get
        Set(ByVal value As Boolean)
            m_BarcodeShowItem = value
        End Set
    End Property
    Public Property BarcodeShowPrice() As Boolean
        Get
            Return m_BarcodeShowPrice
        End Get
        Set(ByVal value As Boolean)
            m_BarcodeShowPrice = value
        End Set
    End Property
    Public Property BarcodeGap() As Integer
        Get
            Return m_BarcodeGap
        End Get
        Set(ByVal value As Integer)
            m_BarcodeGap = value
        End Set
    End Property
    Public Property BarcodeHeight() As Integer
        Get
            Return m_BarcodeHeight
        End Get
        Set(ByVal value As Integer)
            m_BarcodeHeight = value
        End Set
    End Property
    Public Property BarcodeWidth() As Integer
        Get
            Return m_BarcodeWidth
        End Get
        Set(ByVal value As Integer)
            m_BarcodeWidth = value
        End Set
    End Property
    Public Property BarcodeLeft() As Integer
        Get
            Return m_BarcodeLeft
        End Get
        Set(ByVal value As Integer)
            m_BarcodeLeft = value
        End Set
    End Property
    Public Property BarcodeTop() As Integer
        Get
            Return m_BarcodeTop
        End Get
        Set(ByVal value As Integer)
            m_BarcodeTop = value
        End Set
    End Property
    Public Property BarcodeFontSize() As Integer
        Get
            Return m_BarcodeFontSize
        End Get
        Set(ByVal value As Integer)
            m_BarcodeFontSize = value
        End Set
    End Property
    Public Property BarcodeType() As Integer
        Get
            Return m_BarcodeType
        End Get
        Set(ByVal value As Integer)
            m_BarcodeType = value
        End Set
    End Property
    Public Property AccSuspense() As Integer
        Get
            Return m_AccSuspense
        End Get
        Set(ByVal value As Integer)
            m_AccSuspense = value
        End Set
    End Property
    Public Property MembershipSystem() As Boolean
        Get
            Return m_MembershipSystem
        End Get
        Set(ByVal value As Boolean)
            m_MembershipSystem = value
        End Set
    End Property
    Public Property MembershipAmt2Point() As Decimal
        Get
            Return m_MembershipAmt2Point
        End Get
        Set(ByVal value As Decimal)
            m_MembershipAmt2Point = value
        End Set
    End Property
    Public Property MembershipPoint2Amt() As Decimal
        Get
            Return m_MembershipPoint2Amt
        End Get
        Set(ByVal value As Decimal)
            m_MembershipPoint2Amt = value
        End Set
    End Property
    Public Property MembershipStartNumber() As Int64
        Get
            Return m_MembershipStartNumber
        End Get
        Set(ByVal value As Int64)
            m_MembershipStartNumber = value
        End Set
    End Property
    Public Property MembershipRedemptionCash() As Boolean
        Get
            Return m_MembershipRedemptionCash
        End Get
        Set(ByVal value As Boolean)
            m_MembershipRedemptionCash = value
        End Set
    End Property
    Public Property MembershipRedemptionReward() As Boolean
        Get
            Return m_MembershipRedemptionReward
        End Get
        Set(ByVal value As Boolean)
            m_MembershipRedemptionReward = value
        End Set
    End Property
    Public Property AccSalary() As Integer
        Get
            Return m_AccSalary
        End Get
        Set(ByVal value As Integer)
            m_AccSalary = value
        End Set
    End Property

    Public Property Company() As String
        Get
            Return m_Company
        End Get
        Set(ByVal value As String)
            m_Company = value
        End Set
    End Property
    Public Property Counter() As String
        Get
            Return m_Counter
        End Get
        Set(ByVal value As String)
            m_Counter = value
        End Set
    End Property
    Public Property ReceiptPrinter() As String
        Get
            Return m_ReceiptPrinter
        End Get
        Set(ByVal value As String)
            m_ReceiptPrinter = value
        End Set
    End Property
    Public Property BarcodePrinter() As String
        Get
            Return m_BarcodePrinter
        End Get
        Set(ByVal value As String)
            m_BarcodePrinter = value
        End Set
    End Property
    Public Property ComPort() As String
        Get
            Return m_ComPort
        End Get
        Set(ByVal value As String)
            m_ComPort = value
        End Set
    End Property
    Public Property ReportPath() As String
        Get
            Return m_ReportPath
        End Get
        Set(ByVal value As String)
            m_ReportPath = value
        End Set
    End Property
#Region "KEYS"

    Public Property K_Add() As Keys
        Get
            Return m_Add
        End Get
        Set(ByVal value As Keys)
            m_Add = value
        End Set
    End Property

    Public Property K_Add2() As Keys
        Get
            Return m_Add2
        End Get
        Set(ByVal value As Keys)
            m_Add2 = value
        End Set
    End Property

    Public Property K_Info() As Keys
        Get
            Return m_Info
        End Get
        Set(ByVal value As Keys)
            m_Info = value
        End Set
    End Property

    Public Property K_Delete() As Keys
        Get
            Return m_Delete
        End Get
        Set(ByVal value As Keys)
            m_Delete = value
        End Set
    End Property

    Public Property K_Delete2() As Keys
        Get
            Return m_Delete2
        End Get
        Set(ByVal value As Keys)
            m_Delete2 = value
        End Set
    End Property

    Public Property K_Multiply() As Keys
        Get
            Return m_Multiply
        End Get
        Set(ByVal value As Keys)
            m_Multiply = value
        End Set
    End Property

    Public Property K_Multiply2() As Keys
        Get
            Return m_Multiply
        End Get
        Set(ByVal value As Keys)
            m_Multiply = value
        End Set
    End Property

    Public Property K_Price() As Keys
        Get
            Return m_Price
        End Get
        Set(ByVal value As Keys)
            m_Price = value
        End Set
    End Property

    Public Property K_Price2() As Keys
        Get
            Return m_Price2
        End Get
        Set(ByVal value As Keys)
            m_Price2 = value
        End Set
    End Property

    Public Property K_Cash() As Keys
        Get
            Return m_Cash
        End Get
        Set(ByVal value As Keys)
            m_Cash = value
        End Set
    End Property

    Public Property K_Cash2() As Keys
        Get
            Return m_Cash2
        End Get
        Set(ByVal value As Keys)
            m_Cash2 = value
        End Set
    End Property

    Public Property K_Credit_Sale() As Keys
        Get
            Return m_Credit_Sale
        End Get
        Set(ByVal value As Keys)
            m_Credit_Sale = value
        End Set
    End Property

    Public Property K_Payment() As Keys
        Get
            Return m_Payment
        End Get
        Set(ByVal value As Keys)
            m_Payment = value
        End Set
    End Property

    Public Property K_Balance() As Keys
        Get
            Return m_Balance
        End Get
        Set(ByVal value As Keys)
            m_Balance = value
        End Set
    End Property

    Public Property K_SalesReturn() As Keys
        Get
            Return m_SalesReturn
        End Get
        Set(ByVal value As Keys)
            m_SalesReturn = value
        End Set
    End Property

    Public Property K_Discount() As Keys
        Get
            Return m_Discount
        End Get
        Set(ByVal value As Keys)
            m_Discount = value
        End Set
    End Property

    Public Property K_Hold() As Keys
        Get
            Return m_Hold
        End Get
        Set(ByVal value As Keys)
            m_Hold = value
        End Set
    End Property

    Public Property K_Repeat() As Keys
        Get
            Return m_Repeat
        End Get
        Set(ByVal value As Keys)
            m_Repeat = value
        End Set
    End Property

    Public Property K_Open_Item() As Keys
        Get
            Return m_Open_Item
        End Get
        Set(ByVal value As Keys)
            m_Open_Item = value
        End Set
    End Property

    Public Property K_Knet() As Keys
        Get
            Return m_Knet
        End Get
        Set(ByVal value As Keys)
            m_Knet = value
        End Set
    End Property

    Public Property K_MasterVisa() As Keys
        Get
            Return m_MasterVisa
        End Get
        Set(ByVal value As Keys)
            m_MasterVisa = value
        End Set
    End Property

    Public Property K_Clear() As Keys
        Get
            Return m_Clear
        End Get
        Set(ByVal value As Keys)
            m_Clear = value
        End Set
    End Property

    Public Property K_ClearBox() As Keys
        Get
            Return m_ClearBox
        End Get
        Set(ByVal value As Keys)
            m_ClearBox = value
        End Set
    End Property

    Public Property K_Close() As Keys
        Get
            Return m_Close
        End Get
        Set(ByVal value As Keys)
            m_Close = value
        End Set
    End Property

    Public Property K_Print() As Keys
        Get
            Return m_Print
        End Get
        Set(ByVal value As Keys)
            m_Print = value
        End Set
    End Property

    Public Property K_ItemList() As Keys
        Get
            Return m_ItemList
        End Get
        Set(ByVal value As Keys)
            m_ItemList = value
        End Set
    End Property

    Public Property K_CustomerList() As Keys
        Get
            Return m_CustomerList
        End Get
        Set(ByVal value As Keys)
            m_CustomerList = value
        End Set
    End Property

    Public Property K_EditBill() As Keys
        Get
            Return m_EditBill
        End Get
        Set(ByVal value As Keys)
            m_EditBill = value
        End Set
    End Property

    Public Property K_Discount_Per() As Keys
        Get
            Return m_Discount_Per
        End Get
        Set(ByVal value As Keys)
            m_Discount_Per = value
        End Set
    End Property

    Public Property K_Remark() As Keys
        Get
            Return m_Remark
        End Get
        Set(ByVal value As Keys)
            m_Remark = value
        End Set
    End Property

    Public Property K_Reprint() As Keys
        Get
            Return m_Reprint
        End Get
        Set(ByVal value As Keys)
            m_Reprint = value
        End Set
    End Property

    Public Property K_Membership() As Keys
        Get
            Return m_Membership
        End Get
        Set(ByVal value As Keys)
            m_Membership = value
        End Set
    End Property

#End Region

#Region "KEYS STRING"

    Public Property K_Add_S() As String
        Get
            Return m_Add_S
        End Get
        Set(ByVal value As String)
            m_Add_S = value
        End Set
    End Property

    Public Property K_Add2_S() As String
        Get
            Return m_Add2_S
        End Get
        Set(ByVal value As String)
            m_Add2_S = value
        End Set
    End Property

    Public Property K_Info_S() As String
        Get
            Return m_Info_S
        End Get
        Set(ByVal value As String)
            m_Info_S = value
        End Set
    End Property

    Public Property K_Delete_S() As String
        Get
            Return m_Delete_S
        End Get
        Set(ByVal value As String)
            m_Delete_S = value
        End Set
    End Property

    Public Property K_Delete2_S() As String
        Get
            Return m_Delete2_S
        End Get
        Set(ByVal value As String)
            m_Delete2_S = value
        End Set
    End Property

    Public Property K_Multiply_S() As String
        Get
            Return m_Multiply_S
        End Get
        Set(ByVal value As String)
            m_Multiply_S = value
        End Set
    End Property

    Public Property K_Multiply2_S() As String
        Get
            Return m_Multiply_S
        End Get
        Set(ByVal value As String)
            m_Multiply_S = value
        End Set
    End Property

    Public Property K_Price_S() As String
        Get
            Return m_Price_S
        End Get
        Set(ByVal value As String)
            m_Price_S = value
        End Set
    End Property

    Public Property K_Price2_S() As String
        Get
            Return m_Price2_S
        End Get
        Set(ByVal value As String)
            m_Price2_S = value
        End Set
    End Property

    Public Property K_Cash_S() As String
        Get
            Return m_Cash_S
        End Get
        Set(ByVal value As String)
            m_Cash_S = value
        End Set
    End Property

    Public Property K_Cash2_S() As String
        Get
            Return m_Cash2_S
        End Get
        Set(ByVal value As String)
            m_Cash2_S = value
        End Set
    End Property

    Public Property K_Credit_Sale_S() As String
        Get
            Return m_Credit_Sale_S
        End Get
        Set(ByVal value As String)
            m_Credit_Sale_S = value
        End Set
    End Property

    Public Property K_Payment_S() As String
        Get
            Return m_Payment_S
        End Get
        Set(ByVal value As String)
            m_Payment_S = value
        End Set
    End Property

    Public Property K_Balance_S() As String
        Get
            Return m_Balance_S
        End Get
        Set(ByVal value As String)
            m_Balance_S = value
        End Set
    End Property

    Public Property K_SalesReturn_S() As String
        Get
            Return m_SalesReturn_S
        End Get
        Set(ByVal value As String)
            m_SalesReturn_S = value
        End Set
    End Property

    Public Property K_Discount_S() As String
        Get
            Return m_Discount_S
        End Get
        Set(ByVal value As String)
            m_Discount_S = value
        End Set
    End Property

    Public Property K_Hold_S() As String
        Get
            Return m_Hold_S
        End Get
        Set(ByVal value As String)
            m_Hold_S = value
        End Set
    End Property

    Public Property K_Repeat_S() As String
        Get
            Return m_Repeat_S
        End Get
        Set(ByVal value As String)
            m_Repeat_S = value
        End Set
    End Property

    Public Property K_Open_Item_S() As String
        Get
            Return m_Open_Item_S
        End Get
        Set(ByVal value As String)
            m_Open_Item_S = value
        End Set
    End Property

    Public Property K_Knet_S() As String
        Get
            Return m_Knet_S
        End Get
        Set(ByVal value As String)
            m_Knet_S = value
        End Set
    End Property

    Public Property K_MasterVisa_S() As String
        Get
            Return m_MasterVisa_S
        End Get
        Set(ByVal value As String)
            m_MasterVisa_S = value
        End Set
    End Property

    Public Property K_Clear_S() As String
        Get
            Return m_Clear_S
        End Get
        Set(ByVal value As String)
            m_Clear_S = value
        End Set
    End Property

    Public Property K_ClearBox_S() As String
        Get
            Return m_ClearBox_S
        End Get
        Set(ByVal value As String)
            m_ClearBox_S = value
        End Set
    End Property

    Public Property K_Close_S() As String
        Get
            Return m_Close_S
        End Get
        Set(ByVal value As String)
            m_Close_S = value
        End Set
    End Property

    Public Property K_Print_S() As String
        Get
            Return m_Print_S
        End Get
        Set(ByVal value As String)
            m_Print_S = value
        End Set
    End Property

    Public Property K_ItemList_S() As String
        Get
            Return m_ItemList_S
        End Get
        Set(ByVal value As String)
            m_ItemList_S = value
        End Set
    End Property

    Public Property K_CustomerList_S() As String
        Get
            Return m_CustomerList_S
        End Get
        Set(ByVal value As String)
            m_CustomerList_S = value
        End Set
    End Property

    Public Property K_EditBill_S() As String
        Get
            Return m_EditBill_S
        End Get
        Set(ByVal value As String)
            m_EditBill_S = value
        End Set
    End Property

    Public Property K_Discount_Per_S() As String
        Get
            Return m_Discount_Per_S
        End Get
        Set(ByVal value As String)
            m_Discount_Per_S = value
        End Set
    End Property

    Public Property K_Remark_S() As String
        Get
            Return m_Remark_S
        End Get
        Set(ByVal value As String)
            m_Remark_S = value
        End Set
    End Property

    Public Property K_Reprint_S() As String
        Get
            Return m_Reprint_S
        End Get
        Set(ByVal value As String)
            m_Reprint_S = value
        End Set
    End Property

    Public Property K_Membership_S() As String
        Get
            Return m_Membership_S
        End Get
        Set(ByVal value As String)
            m_Membership_S = value
        End Set
    End Property

#End Region


    Public Property Has_Cash_Drawer() As Boolean
        Get
            Return m_Has_Cash_Drawer
        End Get
        Set(ByVal value As Boolean)
            m_Has_Cash_Drawer = value
        End Set
    End Property

    Public Property Has_Print_Cut() As Boolean
        Get
            Return m_Has_Print_Cut
        End Get
        Set(ByVal value As Boolean)
            m_Has_Print_Cut = value
        End Set
    End Property

    Public Property DisplayPole_Method() As Integer
        Get
            Return m_DisplayPole_Method
        End Get
        Set(ByVal value As Integer)
            m_DisplayPole_Method = value
        End Set
    End Property

    'Public Property Has_Display_Pole() As Boolean
    '    Get
    '        Return m_Has_Display_Pole
    '    End Get
    '    Set(ByVal value As Boolean)
    '        m_Has_Display_Pole = value
    '    End Set
    'End Property
    'Public Property Has_New_Display_Pole() As Boolean
    '    Get
    '        Return m_Has_New_Display_Pole
    '    End Get
    '    Set(ByVal value As Boolean)
    '        m_Has_New_Display_Pole = value
    '    End Set
    'End Property
    'Public Property Has_Recp_Print() As Boolean
    '    Get
    '        Return m_Has_Recp_Print
    '    End Get
    '    Set(ByVal value As Boolean)
    '        m_Has_Recp_Print = value
    '    End Set
    'End Property
    'Public Property BarcodeHeight() As Integer
    '    Get
    '        Return m_BarcodeHeight
    '    End Get
    '    Set(ByVal value As Integer)
    '        m_BarcodeHeight = value
    '    End Set
    'End Property
    'Public Property BarcodeWidth() As Integer
    '    Get
    '        Return m_BarcodeWidth
    '    End Get
    '    Set(ByVal value As Integer)
    '        m_BarcodeWidth = value
    '    End Set
    'End Property
    'Public Property BarcodeName() As Boolean
    '    Get
    '        Return m_BarcodeName
    '    End Get
    '    Set(ByVal value As Boolean)
    '        m_BarcodeName = value
    '    End Set
    'End Property
    'Public Property BarcodePrice() As Boolean
    '    Get
    '        Return m_BarcodePrice
    '    End Get
    '    Set(ByVal value As Boolean)
    '        m_BarcodePrice = value
    '    End Set
    'End Property
    'Public Property BarcodeLeft() As Integer
    '    Get
    '        Return m_BarcodeLeft
    '    End Get
    '    Set(ByVal value As Integer)
    '        m_BarcodeLeft = value
    '    End Set
    'End Property
    'Public Property BarcodeTop() As Integer
    '    Get
    '        Return m_BarcodeTop
    '    End Get
    '    Set(ByVal value As Integer)
    '        m_BarcodeTop = value
    '    End Set
    'End Property
    'Public Property BarcodeGap() As Integer
    '    Get
    '        Return m_BarcodeGap
    '    End Get
    '    Set(ByVal value As Integer)
    '        m_BarcodeGap = value
    '    End Set
    'End Property

    Public Property A4Printer() As Boolean
        Get
            Return m_A4Printer
        End Get
        Set(ByVal value As Boolean)
            m_A4Printer = value
        End Set
    End Property
    Public Property PrintAtEnd() As Boolean
        Get
            Return m_PrintAtEnd
        End Get
        Set(ByVal value As Boolean)
            m_PrintAtEnd = value
        End Set
    End Property

    Public Sub New()
        Try
            GetConfig()
            YearExists(Now.Year.ToString)
            YearExists(Now.AddYears(1).Year.ToString)
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Sub
    Public Function GetConfig() As Boolean
        Try
            Dim DT As New DataTable
            DT = DBO.ReturnDataTable("Select * from Config Where Code=1")
            If DT.Rows.Count = 0 Then
                Return False
            Else
                m_Code = FixObjectNumber(DT.Rows(0).Item("Code"))
                m_CompanyName = FixObjectString(DT.Rows(0).Item("CompanyName"))
                m_Tel = FixObjectString(DT.Rows(0).Item("Tel"))
                m_Mob = FixObjectString(DT.Rows(0).Item("Mob"))
                m_Fax = FixObjectString(DT.Rows(0).Item("Fax"))
                m_Address1 = FixObjectString(DT.Rows(0).Item("Address1"))
                m_Address2 = FixObjectString(DT.Rows(0).Item("Address2"))
                m_Address3 = FixObjectString(DT.Rows(0).Item("Address3"))
                m_AccCash = FixObjectNumber(DT.Rows(0).Item("AccCash"))
                m_AccBank = FixObjectNumber(DT.Rows(0).Item("AccBank"))
                m_AccStock = FixObjectNumber(DT.Rows(0).Item("AccStock"))
                m_AccKnet = FixObjectNumber(DT.Rows(0).Item("AccKnet"))
                m_AccMaster = FixObjectNumber(DT.Rows(0).Item("AccMaster"))
                m_AccSalesReturn = FixObjectNumber(DT.Rows(0).Item("AccSalesReturn"))
                m_AccDiscount = FixObjectNumber(DT.Rows(0).Item("AccDiscount"))
                m_AccCreditSalesReturn = FixObjectNumber(DT.Rows(0).Item("AccCreditSalesReturn"))
                m_AccCapital = FixObjectNumber(DT.Rows(0).Item("AccCapital"))
                m_AccDrawing = FixObjectNumber(DT.Rows(0).Item("AccDrawing"))
                m_AccCashCustomer = FixObjectNumber(DT.Rows(0).Item("AccCashCustomer"))
                m_OpenSalesForm = FixObjectBoolean(DT.Rows(0).Item("OpenSalesForm"))
                m_AddSalesDetail = FixObjectBoolean(DT.Rows(0).Item("AddSalesDetail"))
                m_AddPurchaseDetail = FixObjectBoolean(DT.Rows(0).Item("AddPurchaseDetail"))
                m_CardCategory = FixObjectNumber(DT.Rows(0).Item("CardCategory"))
                m_NewsPaperCategory = FixObjectNumber(DT.Rows(0).Item("NewsPaperCategory"))
                m_DefaultCategory = FixObjectNumber(DT.Rows(0).Item("DefaultCategory"))
                m_DefaultSubCategory = FixObjectNumber(DT.Rows(0).Item("DefaultSubCategory"))
                'm_BigReceiprPrinter = FixObjectBoolean(DT.Rows(0).Item("BigReceiprPrinter"))
                m_SearchByBarcode = FixObjectBoolean(DT.Rows(0).Item("SearchByBarcode"))
                m_ResetReceiptYearly = FixObjectBoolean(DT.Rows(0).Item("ResetReceiptYearly"))
                m_NewSalesScreen = FixObjectBoolean(DT.Rows(0).Item("NewSalesScreen"))
                m_AccSalary = FixObjectNumber(DT.Rows(0).Item("AccSalary"))
                m_AccTempCredit = FixObjectNumber(DT.Rows(0).Item("AccTempCredit"))
                m_MonthBasePayment = FixObjectBoolean(DT.Rows(0).Item("MonthBasePayment"))
                m_DecimalPlace = FixObjectNumber(DT.Rows(0).Item("DecimalPlace"))
                m_ShowImage = FixObjectBoolean(DT.Rows(0).Item("ShowImage"))
                m_BarcodeShowCompany = FixObjectBoolean(DT.Rows(0).Item("BarcodeShowCompany"))
                m_BarcodeShowItem = FixObjectBoolean(DT.Rows(0).Item("BarcodeShowItem"))
                m_BarcodeShowPrice = FixObjectBoolean(DT.Rows(0).Item("BarcodeShowPrice"))
                m_BarcodeGap = FixObjectNumber(DT.Rows(0).Item("BarcodeGap"))
                m_BarcodeHeight = FixObjectNumber(DT.Rows(0).Item("BarcodeHeight"))
                m_BarcodeWidth = FixObjectNumber(DT.Rows(0).Item("BarcodeWidth"))
                m_BarcodeLeft = FixObjectNumber(DT.Rows(0).Item("BarcodeLeft"))
                m_BarcodeTop = FixObjectNumber(DT.Rows(0).Item("BarcodeTop"))
                m_BarcodeFontSize = FixObjectNumber(DT.Rows(0).Item("BarcodeFontSize"))
                m_AccSuspense = FixObjectNumber(DT.Rows(0).Item("AccSuspense"))
                m_MembershipSystem = FixObjectBoolean(DT.Rows(0).Item("MembershipSystem"))
                m_MembershipAmt2Point = FixObjectNumber(DT.Rows(0).Item("MembershipAmt2Point"))
                m_MembershipPoint2Amt = FixObjectNumber(DT.Rows(0).Item("MembershipPoint2Amt"))
                m_MembershipStartNumber = FixObjectNumber(DT.Rows(0).Item("MembershipStartNumber"))
                m_MembershipRedemptionCash = FixObjectBoolean(DT.Rows(0).Item("MembershipRedemptionCash"))
                m_MembershipRedemptionReward = FixObjectBoolean(DT.Rows(0).Item("MembershipRedemptionReward"))


                Select Case m_DecimalPlace
                    Case 0 : CurrencyBase = 1
                    Case 1 : CurrencyBase = 10
                    Case 2 : CurrencyBase = 100
                    Case 3 : CurrencyBase = 1000
                End Select

                Mask_Amount = "{double:-9." & m_DecimalPlace & "}"
                Mask_Amount5 = "{double:5." & m_DecimalPlace & "}"
                Mask_Amount5Nagative = "{double:-5." & m_DecimalPlace & "}"
                Mask_AmountPositive = "{double:9." & m_DecimalPlace & "}"


                Return True
            End If

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function
    Public Function GetConfigDT() As Boolean
        Try
            Dim DT As New DataTable
            DT = DBO.ReturnDataTable("Select * from Config Where Code=1")
            If DT.Rows.Count = 0 Then
                Return False
            Else
                m_Code = FixObjectNumber(DT.Rows(0).Item("Code"))
                m_CompanyName = FixObjectString(DT.Rows(0).Item("CompanyName"))
                m_Tel = FixObjectString(DT.Rows(0).Item("Tel"))
                m_Mob = FixObjectString(DT.Rows(0).Item("Mob"))
                m_Fax = FixObjectString(DT.Rows(0).Item("Fax"))
                m_Address1 = FixObjectString(DT.Rows(0).Item("Address1"))
                m_Address2 = FixObjectString(DT.Rows(0).Item("Address2"))
                m_Address3 = FixObjectString(DT.Rows(0).Item("Address3"))
                m_AccCash = FixObjectNumber(DT.Rows(0).Item("AccCash"))
                m_AccBank = FixObjectNumber(DT.Rows(0).Item("AccBank"))
                m_AccStock = FixObjectNumber(DT.Rows(0).Item("AccStock"))
                m_AccKnet = FixObjectNumber(DT.Rows(0).Item("AccKnet"))
                m_AccMaster = FixObjectNumber(DT.Rows(0).Item("AccMaster"))
                m_AccSalesReturn = FixObjectNumber(DT.Rows(0).Item("AccSalesReturn"))
                m_AccDiscount = FixObjectNumber(DT.Rows(0).Item("AccDiscount"))
                m_AccCreditSalesReturn = FixObjectNumber(DT.Rows(0).Item("AccCreditSalesReturn"))
                m_AccCapital = FixObjectNumber(DT.Rows(0).Item("AccCapital"))
                m_AccDrawing = FixObjectNumber(DT.Rows(0).Item("AccDrawing"))
                m_AccCashCustomer = FixObjectNumber(DT.Rows(0).Item("AccCashCustomer"))
                m_OpenSalesForm = FixObjectBoolean(DT.Rows(0).Item("OpenSalesForm"))
                m_AddSalesDetail = FixObjectBoolean(DT.Rows(0).Item("AddSalesDetail"))
                m_AddPurchaseDetail = FixObjectBoolean(DT.Rows(0).Item("AddPurchaseDetail"))
                m_CardCategory = FixObjectNumber(DT.Rows(0).Item("CardCategory"))
                m_NewsPaperCategory = FixObjectNumber(DT.Rows(0).Item("NewsPaperCategory"))
                m_DefaultCategory = FixObjectNumber(DT.Rows(0).Item("DefaultCategory"))
                m_DefaultSubCategory = FixObjectNumber(DT.Rows(0).Item("DefaultSubCategory"))
                'm_BigReceiprPrinter = FixObjectBoolean(DT.Rows(0).Item("BigReceiprPrinter"))
                m_SearchByBarcode = FixObjectBoolean(DT.Rows(0).Item("SearchByBarcode"))
                m_ResetReceiptYearly = FixObjectBoolean(DT.Rows(0).Item("ResetReceiptYearly"))
                m_NewSalesScreen = FixObjectBoolean(DT.Rows(0).Item("NewSalesScreen"))
                m_AccSalary = FixObjectNumber(DT.Rows(0).Item("AccSalary"))
                m_AccTempCredit = FixObjectNumber(DT.Rows(0).Item("AccTempCredit"))
                m_MonthBasePayment = FixObjectBoolean(DT.Rows(0).Item("MonthBasePayment"))
                m_DecimalPlace = FixObjectNumber(DT.Rows(0).Item("DecimalPlace"))
                m_ShowImage = FixObjectBoolean(DT.Rows(0).Item("ShowImage"))
                m_BarcodeShowCompany = FixObjectBoolean(DT.Rows(0).Item("BarcodeShowCompany"))
                m_BarcodeShowItem = FixObjectBoolean(DT.Rows(0).Item("BarcodeShowItem"))
                m_BarcodeShowPrice = FixObjectBoolean(DT.Rows(0).Item("BarcodeShowPrice"))
                m_BarcodeGap = FixObjectNumber(DT.Rows(0).Item("BarcodeGap"))
                m_BarcodeHeight = FixObjectNumber(DT.Rows(0).Item("BarcodeHeight"))
                m_BarcodeWidth = FixObjectNumber(DT.Rows(0).Item("BarcodeWidth"))
                m_BarcodeLeft = FixObjectNumber(DT.Rows(0).Item("BarcodeLeft"))
                m_BarcodeTop = FixObjectNumber(DT.Rows(0).Item("BarcodeTop"))
                m_BarcodeFontSize = FixObjectNumber(DT.Rows(0).Item("BarcodeFontSize"))
                m_BarcodeType = FixObjectNumber(DT.Rows(0).Item("BarcodeType"))


                Select Case m_DecimalPlace
                    Case 0 : CurrencyBase = 1
                    Case 1 : CurrencyBase = 10
                    Case 2 : CurrencyBase = 100
                    Case 3 : CurrencyBase = 1000
                End Select

                Mask_Amount = "{double:-9." & m_DecimalPlace & "}"
                Mask_Amount5 = "{double:5." & m_DecimalPlace & "}"
                Mask_AmountPositive = "{double:9." & m_DecimalPlace & "}"


                Return True
            End If

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function
    Private Function YearExists(ByVal YearNo As String)
        Try
            Dim PARA As New ArrayList
            PARA.Add(YearNo)
            DBO.ExecuteSP("D_YearExists", PARA)

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function

End Class