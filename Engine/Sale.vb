Imports POS.FixControls
Imports POS.CodeModule

Public Class Sale

    Private m_Code As Integer = 0
    Private m_CustomerCode As Integer = 0
    Private m_TransectionDate As Date = Nothing
    Private m_TransectionType As TransectionType = CodeModule.TransectionType.CashSale
    Private m_BillNo As Integer = 0
    Private m_UserCode As Integer = 0
    Private m_CounterCode As Integer = 0
    Private m_PaymentType As PaymentType = CodeModule.PaymentType.Cash
    Private m_TotalBill As Decimal = 0.0
    Private m_Discount As Decimal = 0.0
    Private m_NetBill As Decimal = 0.0
    Private m_Payment As Decimal = 0.0
    Private m_Balance As Decimal = 0.0
    Private m_CashAmount As Decimal = 0.0
    Private m_CustomerNum As String = Nothing
    Private m_CustomerName As String = Nothing
    Private m_Remark As String = Nothing
    Private m_PONumber As String = Nothing
    Private m_PaymentCleared As Boolean = False
    Private m_ReturnSaleCode As Integer = 0

   
    Public Property Code() As Integer
        Get
            Return m_Code
        End Get
        Set(ByVal value As Integer)
            m_Code = value
        End Set
    End Property
    Public Property CustomerCode() As Integer
        Get
            Return m_CustomerCode
        End Get
        Set(ByVal value As Integer)
            m_CustomerCode = value
        End Set
    End Property
    Public Property TransectionDate() As Date
        Get
            Return m_TransectionDate
        End Get
        Set(ByVal value As Date)
            m_TransectionDate = value
        End Set
    End Property
    Public Property TransectionType() As TransectionType
        Get
            Return m_TransectionType
        End Get
        Set(ByVal value As TransectionType)
            m_TransectionType = value
        End Set
    End Property
    Public Property BillNo() As Integer
        Get
            Return m_BillNo
        End Get
        Set(ByVal value As Integer)
            m_BillNo = value
        End Set
    End Property
    Public Property UserCode() As Integer
        Get
            Return m_UserCode
        End Get
        Set(ByVal value As Integer)
            m_UserCode = value
        End Set
    End Property
    Public Property CounterCode() As Integer
        Get
            Return m_CounterCode
        End Get
        Set(ByVal value As Integer)
            m_CounterCode = value
        End Set
    End Property
    Public Property PaymentType() As PaymentType
        Get
            Return m_PaymentType
        End Get
        Set(ByVal value As PaymentType)
            m_PaymentType = value
        End Set
    End Property
    Public Property TotalBill() As Decimal
        Get
            Return m_TotalBill
        End Get
        Set(ByVal value As Decimal)
            m_TotalBill = value
        End Set
    End Property
    Public Property Discount() As Decimal
        Get
            Return m_Discount
        End Get
        Set(ByVal value As Decimal)
            m_Discount = value
        End Set
    End Property
    Public Property NetBill() As Decimal
        Get
            Return m_NetBill
        End Get
        Set(ByVal value As Decimal)
            m_NetBill = value
        End Set
    End Property
    Public Property Payment() As Decimal
        Get
            Return m_Payment
        End Get
        Set(ByVal value As Decimal)
            m_Payment = value
        End Set
    End Property
    Public Property Balance() As Decimal
        Get
            Return m_Balance
        End Get
        Set(ByVal value As Decimal)
            m_Balance = value
        End Set
    End Property
    Public Property CashAmount() As Decimal
        Get
            Return m_CashAmount
        End Get
        Set(ByVal value As Decimal)
            m_CashAmount = value
        End Set
    End Property
    Public Property CustomerNum() As String
        Get
            Return m_CustomerNum
        End Get
        Set(ByVal value As String)
            m_CustomerNum = value
        End Set
    End Property
    Public Property CustomerName() As String
        Get
            Return m_CustomerName
        End Get
        Set(ByVal value As String)
            m_CustomerName = value
        End Set
    End Property
    Public Property Remark() As String
        Get
            Return m_Remark
        End Get
        Set(ByVal value As String)
            m_Remark = value
        End Set
    End Property
    Public Property PONumber() As String
        Get
            Return m_PONumber
        End Get
        Set(ByVal value As String)
            m_PONumber = value
        End Set
    End Property
    Public Property PaymentCleared() As Boolean
        Get
            Return m_PaymentCleared
        End Get
        Set(ByVal value As Boolean)
            m_PaymentCleared = value
        End Set
    End Property
    Public Property ReturnSaleCode() As Integer
        Get
            Return m_ReturnSaleCode
        End Get
        Set(ByVal value As Integer)
            m_ReturnSaleCode = value
        End Set
    End Property

    Public Sub New()
        Try

            m_Code = Nothing
            m_CustomerCode = CLS_Config.AccCashCustomer
            m_TransectionDate = Now.Date
            m_TransectionType = CodeModule.TransectionType.CashSale
            m_BillNo = Nothing
            m_UserCode = UserClass.Code
            m_CounterCode = CLS_Config.Counter
            m_PaymentType = CodeModule.PaymentType.Cash
            m_TotalBill = 0.0
            m_Discount = 0.0
            m_NetBill = 0.0
            m_Payment = 0.0
            m_Balance = 0.0
            m_CashAmount = 0.0
            m_CustomerNum = Nothing
            m_CustomerName = Nothing
            m_Remark = Nothing
            m_PONumber = Nothing
            m_PaymentCleared = False
            m_ReturnSaleCode = 0

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Sub
    Public Function Add() As Integer
        Try
            Dim TD As DateTime
            TD = FixObjectDate(m_TransectionDate)
            If TD.Hour = 0 Then
                Dim D As New DateTime(TD.Year, TD.Month, TD.Day, Now.Hour, Now.Minute, 0)
                m_TransectionDate = D
            End If


            Dim PARA As New ArrayList
            PARA.Add(FixObjectString(m_CustomerCode))
            PARA.Add(FixObjectDate(m_TransectionDate))
            PARA.Add(FixObjectNumber(m_TransectionType))
            PARA.Add(FixObjectNumber(m_BillNo))
            PARA.Add(FixObjectNumber(m_UserCode))
            PARA.Add(FixObjectNumber(m_CounterCode))
            PARA.Add(FixObjectNumber(m_PaymentType))
            PARA.Add(FixObjectNumber(m_TotalBill))
            PARA.Add(FixObjectNumber(m_Discount))
            PARA.Add(FixObjectNumber(m_NetBill))
            PARA.Add(FixObjectNumber(m_Payment))
            PARA.Add(FixObjectNumber(m_Balance))
            PARA.Add(FixObjectNumber(m_CashAmount))
            PARA.Add(FixObjectString(m_Remark))
            PARA.Add(FixObjectString(m_PONumber))
            PARA.Add(FixObjectString(m_ReturnSaleCode))

            m_Code = DBO.ExecuteSP_ReturnSingleValue("SaleInsert", PARA)
            Return m_Code

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return False
        End Try
    End Function
    Public Function Cancel(ByVal TransectionType As TransectionType, ByVal HoldCode As Integer) As Integer
        Try
            Dim TD As DateTime
            TD = FixObjectDate(m_TransectionDate)
            Dim D As New DateTime(TD.Year, TD.Month, TD.Day, Now.Hour, Now.Minute, 0)
            m_TransectionDate = D

            Dim PARA As New ArrayList
            PARA.Add(FixObjectString(m_CustomerCode))
            PARA.Add(FixObjectDate(m_TransectionDate))
            PARA.Add(FixObjectNumber(TransectionType))
            PARA.Add(FixObjectNumber(m_BillNo))
            PARA.Add(FixObjectNumber(m_UserCode))
            PARA.Add(FixObjectNumber(m_CounterCode))
            PARA.Add(FixObjectNumber(m_PaymentType))
            PARA.Add(FixObjectNumber(m_TotalBill))
            PARA.Add(FixObjectNumber(m_Discount))
            PARA.Add(FixObjectNumber(m_NetBill))
            PARA.Add(FixObjectNumber(m_Payment))
            PARA.Add(FixObjectNumber(m_Balance))
            PARA.Add(FixObjectNumber(m_CashAmount))
            PARA.Add(FixObjectString(m_Remark))
            PARA.Add(FixObjectNumber(HoldCode))

            m_Code = DBO.ExecuteSP_ReturnSingleValue("SaleCancelInsert", PARA)
            Return m_Code

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return False
        End Try
    End Function
    Public Function Delete(ByVal SaleCode As Integer) As Boolean
        Try
            Dim PARA As New ArrayList
            PARA.Add(SaleCode)
            DBO.ExecuteSP_ReturnSingleValue("SaleDelete", PARA)
            Return True
            Exit Function

            Using CONTEXT = New POSEntities
                Dim S As Sale_ = (From q In CONTEXT.Sale_Set Where q.Code = SaleCode Select q).SingleOrDefault
                For Each SE In S.Sale_Entry

                    Dim Itm As Item_ = (From q In CONTEXT.Item_Set Where q.Code = SE.ItemCode Select q).SingleOrDefault
                    Itm.StockInHand = TrimDec(Itm.StockInHand) + TrimDec(SE.Quantity)

                    Dim IMList As List(Of ItemMovement) = (From q In CONTEXT.ItemMovements Where q.ForeignKey = S.Code Select q).ToList
                    For Each IM In IMList
                        CONTEXT.ItemMovements.DeleteObject(IM)
                    Next

                    Dim PE As Purchase_Entry_
                    Dim Bucket As Decimal = TrimDec(SE.Quantity)

                    While Bucket > 0

                        If TrimInt(SE.Purchase_EntryCode) = Nothing Then

                            If TrimInt(Itm.ItemType) = ItemType.Serail_Item Then 'SERIAL ITEM WITHOUT SERIAL AT SALE TIME
                                PE = (From q In CONTEXT.Purchase_Entry_Set Where q.ItemCode = SE.ItemCode AndAlso q.QtyStock < q.Qty AndAlso If(q.SerailNum, "") = "" Order By q.ExpiryDate, q.Code Select q).SingleOrDefault
                            Else
                                PE = (From q In CONTEXT.Purchase_Entry_Set Where q.ItemCode = SE.ItemCode AndAlso q.QtyStock < q.Qty Order By q.ExpiryDate, q.Code Select q).SingleOrDefault
                            End If

                        Else
                            PE = (From q In CONTEXT.Purchase_Entry_Set Where q.Code = SE.Purchase_EntryCode Select q).SingleOrDefault
                        End If

                        If IsDBNull(PE) OrElse IsNothing(PE) Then 'Case 1.1
                            Bucket = 0
                            Exit While
                        Else
                            If Bucket <= (PE.Qty - PE.QtyStock) Then 'Case 1.2
                                PE.QtyStock = TrimDec(PE.QtyStock) + Bucket
                                Bucket = 0
                                Exit While
                            ElseIf Bucket > (PE.Qty - PE.QtyStock) Then 'Case 1.3
                                Dim Temp As Decimal = PE.Qty - PE.QtyStock
                                PE.QtyStock = PE.Qty
                                Bucket = Bucket - Temp
                            End If
                        End If

                    End While

                    Dim V As Voucher_
                    V = (From q In CONTEXT.Voucher_Set Where q.Code = S.VoucherCode Select q).SingleOrDefault
                    If Not IsDBNull(V) AndAlso Not IsNothing(V) Then CONTEXT.Voucher_Set.DeleteObject(V)

                    Dim VD As Voucher_
                    VD = (From q In CONTEXT.Voucher_Set Where q.Code = S.VoucherCode + 1 Select q).SingleOrDefault
                    If Not IsDBNull(VD) AndAlso Not IsNothing(VD) Then CONTEXT.Voucher_Set.DeleteObject(VD)

                    CONTEXT.Sale_Set.DeleteObject(S)

                Next



                CONTEXT.SaveChanges()
            End Using

            Return True

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return False
        End Try
    End Function
    Public Function [SelectHold](ByVal BillNo As Integer, Optional ByVal Code As Integer = 0) As DataTable
        Try
            Dim DS As New DataSet
            Dim PARA As New ArrayList
            PARA.Add(BillNo)
            PARA.Add(Code)
            PARA.Add(CLS_Config.Counter)
            DS = DBO.ExecuteSP_ReturnDataSet("SaleSelect_Hold", PARA)
            If DS.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else

                m_Code = CInt(DS.Tables(0).Rows(0).Item("Code"))
                m_CustomerCode = CInt(FixObjectNumber(DS.Tables(0).Rows(0).Item("CustomerCode")))
                m_TransectionDate = CDate(FixObjectDate(DS.Tables(0).Rows(0).Item("TransectionDate")))
                m_TransectionType = CInt(FixObjectNumber(DS.Tables(0).Rows(0).Item("TransectionType")))
                m_BillNo = CInt(FixObjectNumber(DS.Tables(0).Rows(0).Item("BillNo")))
                m_CounterCode = CInt(FixObjectNumber(DS.Tables(0).Rows(0).Item("CounterCode")))
                m_CounterCode = CInt(FixObjectNumber(DS.Tables(0).Rows(0).Item("CounterCode")))
                m_PaymentType = CInt(FixObjectNumber(DS.Tables(0).Rows(0).Item("PaymentType")))
                m_TotalBill = Decimal.Round(CDec(FixObjectNumber(DS.Tables(0).Rows(0).Item("TotalBill"))), 3)
                m_Discount = Decimal.Round(CDec(FixObjectNumber(DS.Tables(0).Rows(0).Item("Discount"))), 3)
                m_NetBill = Decimal.Round(CDec(FixObjectNumber(DS.Tables(0).Rows(0).Item("NetBill"))), 3)
                'm_Payment = Decimal.Round(CDec(FixObjectNumber(DS.Tables(0).Rows(0).Item("Payment"))), 3)
                'm_Balance = Decimal.Round(CDec(FixObjectNumber(DS.Tables(0).Rows(0).Item("Balance"))), 3)
                m_Remark = CStr(FixObjectString(DS.Tables(0).Rows(0).Item("Remark")))
                m_PONumber = CStr(FixObjectString(DS.Tables(0).Rows(0).Item("PONumber")))
                m_ReturnSaleCode = TrimInt(DS.Tables(0).Rows(0).Item("ReturnSaleCode"))

                Dim i As Integer = 0
                For i = 0 To DS.Tables(1).Rows.Count - 1
                    DS.Tables(1).Rows(i).Item("Sr") = i + 1
                Next
                Return DS.Tables(1)

            End If
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function [SelectEdit](ByVal Code As Integer) As DataTable
        Try
            Dim DS As New DataSet
            Dim PARA As New ArrayList
            PARA.Add(Code)
            DS = DBO.ExecuteSP_ReturnDataSet("SaleSelect_Edit", PARA)
            If DS.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else

                m_Code = CInt(DS.Tables(0).Rows(0).Item("Code"))
                m_CustomerCode = CInt(FixObjectNumber(DS.Tables(0).Rows(0).Item("CustomerCode")))
                m_TransectionDate = CDate(FixObjectDate(DS.Tables(0).Rows(0).Item("TransectionDate")))
                m_TransectionType = CInt(FixObjectNumber(DS.Tables(0).Rows(0).Item("TransectionType")))
                m_BillNo = CInt(FixObjectNumber(DS.Tables(0).Rows(0).Item("BillNo")))
                m_CounterCode = CInt(FixObjectNumber(DS.Tables(0).Rows(0).Item("CounterCode")))
                m_CounterCode = CInt(FixObjectNumber(DS.Tables(0).Rows(0).Item("CounterCode")))
                m_PaymentType = CInt(FixObjectNumber(DS.Tables(0).Rows(0).Item("PaymentType")))
                m_TotalBill = Decimal.Round(CDec(FixObjectNumber(DS.Tables(0).Rows(0).Item("TotalBill"))), 3)
                m_Discount = Decimal.Round(CDec(FixObjectNumber(DS.Tables(0).Rows(0).Item("Discount"))), 3)
                m_NetBill = Decimal.Round(CDec(FixObjectNumber(DS.Tables(0).Rows(0).Item("NetBill"))), 3)
                'm_Payment = Decimal.Round(CDec(FixObjectNumber(DS.Tables(0).Rows(0).Item("Payment"))), 3)
                'm_Balance = Decimal.Round(CDec(FixObjectNumber(DS.Tables(0).Rows(0).Item("Balance"))), 3)
                m_Remark = CStr(FixObjectString(DS.Tables(0).Rows(0).Item("Remark")))
                m_PONumber = CStr(FixObjectString(DS.Tables(0).Rows(0).Item("PONumber")))
                m_ReturnSaleCode = TrimInt(DS.Tables(0).Rows(0).Item("ReturnSaleCode"))

                Dim i As Integer = 0
                For i = 0 To DS.Tables(1).Rows.Count - 1
                    DS.Tables(1).Rows(i).Item("Sr") = i + 1
                Next
                Return DS.Tables(1)

            End If
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function Sale_Sub_Exists(ByVal Customer As Integer, ByVal Item As Integer, ByVal theMonth As Integer) As Decimal
        Try
            Dim DS As New DataSet
            Dim PARA As New ArrayList
            PARA.Add(Customer)
            PARA.Add(Item)
            PARA.Add(theMonth)
            DS = DBO.ExecuteSP_ReturnDataSet("Sale_Sub_Exists", PARA)
            If DS.Tables(0).Rows.Count = 0 Then
                Return 0
            Else
                Return FixObjectNumber(DS.Tables(0).Rows(0).Item("TotalPrice"))
            End If
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function Get_SalesCode(ByVal BillNumber As Integer) As Decimal
        Try
            Dim PARA As New ArrayList
            PARA.Add(BillNumber)
            Return DBO.ExecuteSP_ReturnInteger("Sale_GetCode", PARA)

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return Nothing
        End Try
    End Function
    'Public Function Sale_Sub_Exists(ByVal Customer As Integer, ByVal Item As Integer, ByVal theMonth As Integer) As Decimal
    '    Try
    '        Dim PARA As New ArrayList
    '        PARA.Add(Customer)
    '        PARA.Add(Item)
    '        PARA.Add(theMonth)
    '        Return DBO.ExecuteSP_ReturnSingleValue("Sale_Sub_Exists", PARA)

    '    Catch ex As Exception
    '        MSG.ErrorOk(ex.Message)
    '        Return False
    '    End Try
    'End Function
    Public Function Sale_Sub_Payed(ByVal Customer As Integer, ByVal Item As Integer, ByVal theMonth As Integer) As Boolean
        Try
            Dim PARA As New ArrayList
            PARA.Add(Customer)
            PARA.Add(Item)
            PARA.Add(theMonth)
            Return DBO.ExecuteSP_ReturnSingleValue("Sale_Sub_Payed", PARA)

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return False
        End Try
    End Function
    Public Function Sale_Sub_Delete(ByVal Customer As Integer, ByVal Item As Integer, ByVal theMonth As Integer) As Boolean
        Try
            Dim PARA As New ArrayList
            PARA.Add(Customer)
            PARA.Add(Item)
            PARA.Add(theMonth)
            DBO.ExecuteSP_ReturnSingleValue("Sale_Sub_Delete", PARA)
            Return True
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
            Return False
        End Try
    End Function
End Class