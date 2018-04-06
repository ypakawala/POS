
Imports System.Data.SqlClient
Imports System.IO

Public Class ReadConnection
    'Public ConnectionString As String
    Public Property GetConnectionstring() As String
        Get
            Return ConnStr
        End Get
        Set(ByVal value As String)
            ConnStr = value
        End Set
    End Property
    Public Sub New()
        Try
            Dim arr As New ArrayList
            arr = GetFileContents("Connection.txt")

            ConnStr = arr(0)

            CLS_Config.Company = arr(1).Substring(14)
            CLS_Config.Counter = arr(2).Substring(14)
            CLS_Config.ReceiptPrinter = arr(3).Substring(14)
            CLS_Config.BarcodePrinter = arr(4).Substring(14)
            CLS_Config.ComPort = arr(5).Substring(14)
            CLS_Config.ReportPath = arr(6).Substring(14)

            CLS_Config.K_Add = [Enum].Parse(GetType(System.Windows.Forms.Keys), arr(7).Substring(14), False)
            CLS_Config.K_Add2 = [Enum].Parse(GetType(System.Windows.Forms.Keys), arr(8).Substring(14), False)
            CLS_Config.K_Info = [Enum].Parse(GetType(System.Windows.Forms.Keys), arr(9).Substring(14), False)
            CLS_Config.K_Delete = [Enum].Parse(GetType(System.Windows.Forms.Keys), arr(10).Substring(14), False)
            CLS_Config.K_Delete2 = [Enum].Parse(GetType(System.Windows.Forms.Keys), arr(11).Substring(14), False)
            CLS_Config.K_Multiply = [Enum].Parse(GetType(System.Windows.Forms.Keys), arr(12).Substring(14), False)
            CLS_Config.K_Multiply2 = [Enum].Parse(GetType(System.Windows.Forms.Keys), arr(13).Substring(14), False)
            CLS_Config.K_Price = [Enum].Parse(GetType(System.Windows.Forms.Keys), arr(14).Substring(14), False)
            CLS_Config.K_Price2 = [Enum].Parse(GetType(System.Windows.Forms.Keys), arr(15).Substring(14), False)
            CLS_Config.K_Cash = [Enum].Parse(GetType(System.Windows.Forms.Keys), arr(16).Substring(14), False)
            CLS_Config.K_Cash2 = [Enum].Parse(GetType(System.Windows.Forms.Keys), arr(17).Substring(14), False)
            CLS_Config.K_Credit_Sale = [Enum].Parse(GetType(System.Windows.Forms.Keys), arr(18).Substring(14), False)
            CLS_Config.K_Payment = [Enum].Parse(GetType(System.Windows.Forms.Keys), arr(19).Substring(14), False)
            CLS_Config.K_Balance = [Enum].Parse(GetType(System.Windows.Forms.Keys), arr(20).Substring(14), False)
            CLS_Config.K_SalesReturn = [Enum].Parse(GetType(System.Windows.Forms.Keys), arr(21).Substring(14), False)
            CLS_Config.K_Discount = [Enum].Parse(GetType(System.Windows.Forms.Keys), arr(22).Substring(14), False)
            CLS_Config.K_Hold = [Enum].Parse(GetType(System.Windows.Forms.Keys), arr(23).Substring(14), False)
            CLS_Config.K_Repeat = [Enum].Parse(GetType(System.Windows.Forms.Keys), arr(24).Substring(14), False)
            CLS_Config.K_Open_Item = [Enum].Parse(GetType(System.Windows.Forms.Keys), arr(25).Substring(14), False)
            CLS_Config.K_Knet = [Enum].Parse(GetType(System.Windows.Forms.Keys), arr(26).Substring(14), False)
            CLS_Config.K_MasterVisa = [Enum].Parse(GetType(System.Windows.Forms.Keys), arr(27).Substring(14), False)
            CLS_Config.K_Clear = [Enum].Parse(GetType(System.Windows.Forms.Keys), arr(28).Substring(14), False)
            CLS_Config.K_ClearBox = [Enum].Parse(GetType(System.Windows.Forms.Keys), arr(29).Substring(14), False)
            CLS_Config.K_Close = [Enum].Parse(GetType(System.Windows.Forms.Keys), arr(30).Substring(14), False)
            CLS_Config.K_Print = [Enum].Parse(GetType(System.Windows.Forms.Keys), arr(31).Substring(14), False)
            CLS_Config.K_ItemList = [Enum].Parse(GetType(System.Windows.Forms.Keys), arr(32).Substring(14), False)
            CLS_Config.K_CustomerList = [Enum].Parse(GetType(System.Windows.Forms.Keys), arr(33).Substring(14), False)
            CLS_Config.K_EditBill = [Enum].Parse(GetType(System.Windows.Forms.Keys), arr(34).Substring(14), False)
            CLS_Config.K_Discount_Per = [Enum].Parse(GetType(System.Windows.Forms.Keys), arr(35).Substring(14), False)
            CLS_Config.K_Remark = [Enum].Parse(GetType(System.Windows.Forms.Keys), arr(36).Substring(14), False)
            CLS_Config.K_Reprint = [Enum].Parse(GetType(System.Windows.Forms.Keys), arr(42).Substring(14), False)

            CLS_Config.K_Add_S = arr(7).Substring(14)
            CLS_Config.K_Add2_S = arr(8).Substring(14)
            CLS_Config.K_Info_S = arr(9).Substring(14)
            CLS_Config.K_Delete_S = arr(10).Substring(14)
            CLS_Config.K_Delete2_S = arr(11).Substring(14)
            CLS_Config.K_Multiply_S = arr(12).Substring(14)
            CLS_Config.K_Multiply2_S = arr(13).Substring(14)
            CLS_Config.K_Price_S = arr(14).Substring(14)
            CLS_Config.K_Price2_S = arr(15).Substring(14)
            CLS_Config.K_Cash_S = arr(16).Substring(14)
            CLS_Config.K_Cash2_S = arr(17).Substring(14)
            CLS_Config.K_Credit_Sale_S = arr(18).Substring(14)
            CLS_Config.K_Payment_S = arr(19).Substring(14)
            CLS_Config.K_Balance_S = arr(20).Substring(14)
            CLS_Config.K_SalesReturn_S = arr(21).Substring(14)
            CLS_Config.K_Discount_S = arr(22).Substring(14)
            CLS_Config.K_Hold_S = arr(23).Substring(14)
            CLS_Config.K_Repeat_S = arr(24).Substring(14)
            CLS_Config.K_Open_Item_S = arr(25).Substring(14)
            CLS_Config.K_Knet_S = arr(26).Substring(14)
            CLS_Config.K_MasterVisa_S = arr(27).Substring(14)
            CLS_Config.K_Clear_S = arr(28).Substring(14)
            CLS_Config.K_ClearBox_S = arr(29).Substring(14)
            CLS_Config.K_Close_S = arr(30).Substring(14)
            CLS_Config.K_Print_S = arr(31).Substring(14)
            CLS_Config.K_ItemList_S = arr(32).Substring(14)
            CLS_Config.K_CustomerList_S = arr(33).Substring(14)
            CLS_Config.K_EditBill_S = arr(34).Substring(14)
            CLS_Config.K_Discount_Per_S = arr(35).Substring(14)
            CLS_Config.K_Remark_S = arr(36).Substring(14)


            CLS_Config.Has_Cash_Drawer = arr(37).Substring(14)
            CLS_Config.Has_Print_Cut = arr(38).Substring(14)
            CLS_Config.DisplayPole_Method = arr(39).Substring(14)
            'If arr(39).Substring(14) = 0 Then
            '    CLS_Config.Has_Display_Pole = False
            '    CLS_Config.Has_New_Display_Pole = False
            'ElseIf arr(39).Substring(14) = 1 Then
            '    CLS_Config.Has_Display_Pole = True
            '    CLS_Config.Has_New_Display_Pole = False
            'ElseIf arr(39).Substring(14) = 2 Then
            '    CLS_Config.Has_Display_Pole = False
            '    CLS_Config.Has_New_Display_Pole = True
            'End If
            CLS_Config.PrintAtEnd = arr(40).Substring(14)
            'CLS_Config.BarcodeHeight = arr(41).Substring(14)
            'CLS_Config.BarcodeWidth = arr(42).Substring(14)
            CLS_Config.A4Printer = arr(41).Substring(14)
            CLS_Config.K_Reprint_S = arr(42).Substring(14)
            'CLS_Config.BarcodeName = arr(45).Substring(14)
            'CLS_Config.BarcodePrice = arr(46).Substring(14)
            'CLS_Config.BarcodeLeft = arr(47).Substring(14)
            'CLS_Config.BarcodeTop = arr(48).Substring(14)
            'CLS_Config.BarcodeGap = arr(49).Substring(14)


            Set_Key_Array()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Shared Function GetFileContents(ByVal FullPath As String, Optional ByRef ErrInfo As String = "") As ArrayList

        Dim strContents As New ArrayList
        Dim objReader As StreamReader
        Try
            Help = Nothing
            objReader = New StreamReader(FullPath)
            'strContents.Add(objReader.ReadLine)
            'strContents.Add(objReader.ReadLine)
            While Not objReader.EndOfStream
                Dim txt As String = objReader.ReadLine
                strContents.Add(txt)
                Help = Help & txt & vbCrLf
            End While

            objReader.Close()
            Return strContents
        Catch Ex As Exception
            ErrInfo = Ex.Message
        End Try
    End Function
End Class