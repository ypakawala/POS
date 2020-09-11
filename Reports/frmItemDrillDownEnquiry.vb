Imports System.Math
Imports CrystalDecisions.CrystalReports.Engine
Imports POS.FixControls
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmItemDrillDownEnquiry
    Dim DT As New DataTable

    Private Sub frmItemDrillDownEnquiry_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Load_Save_XML(XML_Section.ItemDrillDownEnquiry, Me.grdList, False)
    End Sub
    Private Sub frmItemDrillDownEnquiry_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, MenuStrip1.KeyUp, txtDateFrom.KeyUp, txtDateTo.KeyUp, UltraExpandableGroupBox1.KeyUp, CR.KeyUp, grdList.KeyUp, DropItem.KeyUp, txtSerailNum.KeyDown
        If e.KeyCode = Keys.End Then Me.Close()
    End Sub
    Private Sub frmItemDrillDownEnquiry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.Cart_Blue
        Try

            FillDrop(Me.DropItem, "ItemName", "Code", Table.Item, "CostPrice", "BarCode", "BarCode2")
            Me.txtDateFrom.Value = New Date(Now.Year, Now.Month, Now.Day, 0, 0, 0)
            Me.txtDateTo.Value = Now
            FillGrid()
            Load_Save_XML(XML_Section.ItemDrillDownEnquiry, Me.grdList, True)
            Me.DropItem.Focus()
            Me.grdList.DisplayLayout.Override.RowAlternateAppearance = RowAlternateAppearance

        Catch ex As Exception
            MsgBox("frmSailSearch_Load" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        FillGrid()
    End Sub

    Private Sub btnClearAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClearAll.Click
        Try
            Me.txtDateFrom.Value = Nothing
            Me.txtDateTo.Value = Nothing
            Me.DropItem.Value = Nothing
            Me.txtSerailNum.Value = Nothing

        Catch ex As Exception
            MsgBox("btnClearAll_Click" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Export(Me.grdList)
    End Sub
    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub DropItem_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DropItem.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim CLS_Item As New Item

                If IsDBNull(Me.DropItem.Value) Or IsNothing(Me.DropItem.Value) Then
                ElseIf Me.DropItem.Value = Nothing Then
                Else
                    CLS_Item = New Item
                    CLS_Item = Get_Item(CStr(Me.DropItem.Value))
                    If IsNothing(CLS_Item) Then
                        MsgBox("Item Dose Not Exists")
                        Me.DropItem.Focus()
                    Else
                        Me.DropItem.Value = CLS_Item.Code
                        btnSearch_Click(sender, e)
                    End If
                    Exit Sub
                End If


                If IsDBNull(Me.DropItem.Text) Or IsNothing(Me.DropItem.Text) Then
                Else
                    CLS_Item = New Item
                    CLS_Item = Get_Item(CStr(Me.DropItem.Text))
                    If IsNothing(CLS_Item) Then
                        MsgBox("Item Dose Not Exists")
                        Me.DropItem.Focus()
                    Else
                        Me.DropItem.Value = CLS_Item.Code
                        btnSearch_Click(sender, e)
                    End If

                End If


            End If

        Catch ex As Exception
            MsgBox("DropItem_KeyDown" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub grdList_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles grdList.DoubleClickRow
        Try
            If IsDBNull(Me.grdList.ActiveRow) Or IsNothing(Me.grdList.ActiveRow) Then Exit Sub
            Dim Code As Integer = TrimInt(Me.grdList.ActiveRow.Cells("Code").Value)
            Dim TransectionCode As Integer = TrimInt(Me.grdList.ActiveRow.Cells("TransectionCode").Value)
            If Code = 0 Then Exit Sub
            Select Case TransectionCode
                Case 1
                    LoadReportSales(Code)
                    Me.UltraTabControl1.Tabs("Bill").Selected = True
                Case 2
                    LoadReportPurchase(Code)
                    Me.UltraTabControl1.Tabs("Bill").Selected = True
                Case 3
            End Select
        Catch ex As Exception
            MsgBox("grdList_DoubleClickRow" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub FillGrid()
        Try

            If Not isValid() Then Exit Sub

            Me.grdList.Visible = True

            Dim sql As String = " SELECT  1 AS TransectionCode,'Sale' AS TransectionType,SaleCode AS Code,TransDate AS EffectiveDate,CONVERT(VARCHAR(50),BillNo) AS InvoiceNum,ItemName,Barcode,ItemCategory,SubCategory,UnitPrice,Quantity,TotalPrice,AccountName,COALESCE(SerailNum,'') AS SerailNum,Remark AS Notes,UserName,COALESCE((SELECT COALESCE(StockInStore,0)+COALESCE(StockInHand,0) FROM   dbo.Item WHERE  dbo.Item.Code=dbo.Sales_Full_View.ItemCode),0) AS Stock " & _
                " FROM    dbo.Sales_Full_View " & _
                WhereSales() & _
                " UNION " & _
                " SELECT  1 AS TransectionCode,'Sale Return' AS TransectionType,SaleCode AS Code,TransDate AS EffectiveDate,CONVERT(VARCHAR(50),BillNo) AS InvoiceNum,ItemName,Barcode,ItemCategory,SubCategory,UnitPrice,Quantity,TotalPrice,AccountName,COALESCE(SerailNum,'') AS SerailNum,Remark AS Notes,UserName,COALESCE((SELECT  COALESCE(StockInStore,0)+COALESCE(StockInHand,0) FROM    dbo.Item WHERE   dbo.Item.Code=dbo.Sales_Full_View.ItemCode),0) AS Stock " & _
                " FROM    dbo.Sales_Full_View " & _
                WhereSalesReturn() & _
                " UNION " & _
                " SELECT  2 AS TransectionCode,'Purchase' AS TransectionType,PurchaseCode AS Code,EffectiveDate,CONVERT(VARCHAR(50),InvoiceNum) AS InvoiceNum,ItemName,Barcode,ItemCategory,SubCategory,UnitPrice,Qty AS Quantity,Price AS TotalPrice,SupplierName AS AccountName,COALESCE(SerailNum,'') AS SerailNum,Notes,UserName,COALESCE((SELECT  COALESCE(StockInStore,0)+COALESCE(StockInHand,0) FROM    dbo.Item WHERE   dbo.Item.Code=dbo.Purchase_Entry_View.ItemCode),0) AS Stock " & _
                " FROM    dbo.Purchase_Entry_View " & _
                WherePurchase() & _
                " UNION " & _
                " SELECT  3 AS TransectionCode,'Purchase Return' AS TransectionType,PurchaseReturnCode AS Code,EffectiveDate,CONVERT(VARCHAR(50),InvoiceNum) AS InvoiceNum,ItemName,Barcode,ItemCategory,SubCategory,UnitPrice,Qty AS Quantity,Price AS TotalPrice,Supplier AS AccountName,COALESCE(SerailNum,'') AS SerailNum,Notes,UserName,COALESCE((SELECT COALESCE(StockInStore,0)+COALESCE(StockInHand,0) FROM   dbo.Item WHERE  dbo.Item.Code=dbo.Purchase_Return_Entry_View.ItemCode),0) AS Stock " & _
                " FROM    dbo.Purchase_Return_Entry_View " & _
                WherePurchaseReturn() & _
                " ORDER BY EffectiveDate "

            DT = New DataTable
            'DT = DBO.ReturnDataTableFromSQL("SELECT SaleCode,TransDate,BillNo,UnitPrice,Quantity,TotalPrice,AccountName,SerailNum,Remark FROM dbo.Sales_Full_View " & WhereSales() & "  ORDER BY TransectionDate DESC")
            DT = DBO.ReturnDataTableFromSQL(sql)

            Me.grdList.DataSource = DT
            'Me.grdList.DataMember = "Table"
            Me.grdList.DataBind()



            '''''''''''''''''''''CAPTION'''''''''''''''''''''
            Me.grdList.DisplayLayout.Bands(0).Columns("TransectionCode").Header.Caption = "Transection Code"
            Me.grdList.DisplayLayout.Bands(0).Columns("TransectionType").Header.Caption = "Transection Type"
            Me.grdList.DisplayLayout.Bands(0).Columns("Code").Header.Caption = "Code"
            Me.grdList.DisplayLayout.Bands(0).Columns("EffectiveDate").Header.Caption = "Effective Date"
            Me.grdList.DisplayLayout.Bands(0).Columns("InvoiceNum").Header.Caption = "Invoice Num"
            Me.grdList.DisplayLayout.Bands(0).Columns("UnitPrice").Header.Caption = "Unit Price"
            Me.grdList.DisplayLayout.Bands(0).Columns("Quantity").Header.Caption = "Quantity"
            Me.grdList.DisplayLayout.Bands(0).Columns("TotalPrice").Header.Caption = "Total Price"
            Me.grdList.DisplayLayout.Bands(0).Columns("AccountName").Header.Caption = "Account Name"
            Me.grdList.DisplayLayout.Bands(0).Columns("SerailNum").Header.Caption = "Serail Num"
            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").Header.Caption = "Notes"
            Me.grdList.DisplayLayout.Bands(0).Columns("UserName").Header.Caption = "User Name"
            '''''''''''''''''''''HIDDEN'''''''''''''''''''''
            Me.grdList.DisplayLayout.Bands(0).Columns("TransectionCode").Hidden = True
            Me.grdList.DisplayLayout.Bands(0).Columns("Code").Hidden = True
            '''''''''''''''''''''MASK INPUT'''''''''''''''''''''
            Me.grdList.DisplayLayout.Bands(0).Columns("EffectiveDate").MaskInput = "{LOC}dd/mm/yyyy"
            Me.grdList.DisplayLayout.Bands(0).Columns("UnitPrice").MaskInput = Mask_Amount
            Me.grdList.DisplayLayout.Bands(0).Columns("Quantity").MaskInput = Mask_Amount
            Me.grdList.DisplayLayout.Bands(0).Columns("TotalPrice").MaskInput = Mask_Amount
            '''''''''''''''''''''FORMAT'''''''''''''''''''''
            Me.grdList.DisplayLayout.Bands(0).Columns("EffectiveDate").Format = "dd/MM/yyyy"
            '''''''''''''''''''''Perform Auto Resize'''''''''''''''''''''
            Me.grdList.DisplayLayout.Bands(0).Columns("TransectionCode").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("TransectionType").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("Code").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("EffectiveDate").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("InvoiceNum").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemName").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("Barcode").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemCategory").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("SubCategory").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("UnitPrice").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("Quantity").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("TotalPrice").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("AccountName").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("SerailNum").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").PerformAutoResize()
            Me.grdList.DisplayLayout.Bands(0).Columns("UserName").PerformAutoResize()
            '''''''''''''''''''''Cell Activation'''''''''''''''''''''
            Me.grdList.DisplayLayout.Bands(0).Columns("TransectionCode").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("TransectionType").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("Code").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("EffectiveDate").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("InvoiceNum").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemName").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("Barcode").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemCategory").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("SubCategory").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("UnitPrice").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("Quantity").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("TotalPrice").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("AccountName").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("SerailNum").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.grdList.DisplayLayout.Bands(0).Columns("UserName").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            '''''''''''''''''''''Width'''''''''''''''''''''
            Me.grdList.DisplayLayout.Bands(0).Columns("TransectionCode").Width = 50
            Me.grdList.DisplayLayout.Bands(0).Columns("TransectionType").Width = 150
            Me.grdList.DisplayLayout.Bands(0).Columns("Code").Width = 50
            Me.grdList.DisplayLayout.Bands(0).Columns("EffectiveDate").Width = 150
            Me.grdList.DisplayLayout.Bands(0).Columns("InvoiceNum").Width = 150
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemName").Width = 150
            Me.grdList.DisplayLayout.Bands(0).Columns("Barcode").Width = 150
            Me.grdList.DisplayLayout.Bands(0).Columns("ItemCategory").Width = 150
            Me.grdList.DisplayLayout.Bands(0).Columns("SubCategory").Width = 150
            Me.grdList.DisplayLayout.Bands(0).Columns("UnitPrice").Width = 150
            Me.grdList.DisplayLayout.Bands(0).Columns("Quantity").Width = 100
            Me.grdList.DisplayLayout.Bands(0).Columns("TotalPrice").Width = 150
            Me.grdList.DisplayLayout.Bands(0).Columns("AccountName").Width = 150
            Me.grdList.DisplayLayout.Bands(0).Columns("SerailNum").Width = 150
            Me.grdList.DisplayLayout.Bands(0).Columns("Notes").Width = 150
            Me.grdList.DisplayLayout.Bands(0).Columns("UserName").Width = 150


            ' '''''''''''''''''''''Hidden'''''''''''''''''''''
            'Me.grdList.DisplayLayout.Bands(0).Columns("TransectionCode").Hidden = True
            'Me.grdList.DisplayLayout.Bands(0).Columns("Code").Hidden = True
            ' '''''''''''''''''''''Caption'''''''''''''''''''''
            'Me.grdList.DisplayLayout.Bands(0).Columns("TransectionType").Header.Caption = "Transection Type"
            'Me.grdList.DisplayLayout.Bands(0).Columns("EffectiveDate").Header.Caption = "Sales Date"
            'Me.grdList.DisplayLayout.Bands(0).Columns("BillNo").Header.Caption = "Bill No"
            'Me.grdList.DisplayLayout.Bands(0).Columns("UnitPrice").Header.Caption = "Unit Price"
            'Me.grdList.DisplayLayout.Bands(0).Columns("Quantity").Header.Caption = "Quantity"
            'Me.grdList.DisplayLayout.Bands(0).Columns("TotalPrice").Header.Caption = "Total Price"
            'Me.grdList.DisplayLayout.Bands(0).Columns("AccountName").Header.Caption = "Customer Name"
            'Me.grdList.DisplayLayout.Bands(0).Columns("Remark").Header.Caption = "Remark"
            'Me.grdList.DisplayLayout.Bands(0).Columns("SerailNum").Header.Caption = "Serail #"
            ' '''''''''''''''''''''MaskInput'''''''''''''''''''''
            'Me.grdList.DisplayLayout.Bands(0).Columns("TransDate").MaskInput = "{LOC}dd/mm/yyyy"
            'Me.grdList.DisplayLayout.Bands(0).Columns("UnitPrice").MaskInput = Mask_Amount
            'Me.grdList.DisplayLayout.Bands(0).Columns("Quantity").MaskInput = Mask_Qty
            'Me.grdList.DisplayLayout.Bands(0).Columns("TotalPrice").MaskInput = Mask_Amount
            ' '''''''''''''''''''''Width'''''''''''''''''''''
            'Me.grdList.DisplayLayout.Bands(0).Columns("TransDate").Width = 150
            'Me.grdList.DisplayLayout.Bands(0).Columns("BillNo").Width = 100
            'Me.grdList.DisplayLayout.Bands(0).Columns("UnitPrice").Width = 100
            'Me.grdList.DisplayLayout.Bands(0).Columns("Quantity").Width = 100
            'Me.grdList.DisplayLayout.Bands(0).Columns("TotalPrice").Width = 100
            'Me.grdList.DisplayLayout.Bands(0).Columns("AccountName").Width = 250
            'Me.grdList.DisplayLayout.Bands(0).Columns("Remark").Width = 250
            'Me.grdList.DisplayLayout.Bands(0).Columns("SerailNum").Width = 150
            ' '''''''''''''''''''''Cell Activation'''''''''''''''''''''
            'Me.grdList.DisplayLayout.Bands(0).Columns("TransDate").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            'Me.grdList.DisplayLayout.Bands(0).Columns("BillNo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            'Me.grdList.DisplayLayout.Bands(0).Columns("UnitPrice").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            'Me.grdList.DisplayLayout.Bands(0).Columns("Quantity").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            'Me.grdList.DisplayLayout.Bands(0).Columns("TotalPrice").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            'Me.grdList.DisplayLayout.Bands(0).Columns("AccountName").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            'Me.grdList.DisplayLayout.Bands(0).Columns("Remark").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            'Me.grdList.DisplayLayout.Bands(0).Columns("SerailNum").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            '' '''''''''''''''''''''Perform Auto Resize'''''''''''''''''''''
            ''Me.grdList.DisplayLayout.Bands(0).Columns("TransDate").PerformAutoResize()
            ''Me.grdList.DisplayLayout.Bands(0).Columns("BillNo").PerformAutoResize()
            ''Me.grdList.DisplayLayout.Bands(0).Columns("UnitPrice").PerformAutoResize()
            ''Me.grdList.DisplayLayout.Bands(0).Columns("Quantity").PerformAutoResize()
            ''Me.grdList.DisplayLayout.Bands(0).Columns("TotalPrice").PerformAutoResize()
            ''Me.grdList.DisplayLayout.Bands(0).Columns("AccountName").PerformAutoResize()
            ''Me.grdList.DisplayLayout.Bands(0).Columns("Remark").PerformAutoResize()
            ''Me.grdList.DisplayLayout.Bands(0).Columns("SerailNum").PerformAutoResize()
            Me.UltraTabControl1.Tabs("List").Selected = True


        Catch ex As Exception
            MsgBox("FillGrid" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Function isValid() As Boolean
        Try

            'If FixControl(Me.DropItem) = Nothing Then
            '    MSG.ErrorOk("Select Item.")
            '    Me.DropItem.Focus()
            '    Return False
            'End If


            If FixControl(Me.txtDateTo) <> Null_Date And FixControl(Me.txtDateFrom) <> Null_Date Then
                If CDate(Me.txtDateFrom.Value) > CDate(Me.txtDateTo.Value) Then
                    MSG.ErrorOk("[DATE TO] should be less then [DATE FROM].")
                    Me.txtDateTo.Focus()
                    Me.txtDateTo.SelectAll()
                    Return False
                End If
            End If

            Return True
        Catch ex As Exception
            MsgBox("isValid" & vbCrLf & ex.Message)
        End Try
    End Function
    Private Function WhereSales() As String
        Dim Result As String = Nothing
        Try


            Result = " WHERE (TransectionTypeCode IN (1,2,3)) "
            If TrimInt(Me.DropItem.Value) <> 0 Then Result &= " AND ItemCode = " & FixControl(Me.DropItem)
            If FixControl(Me.txtDateFrom) <> Null_Date Then Result &= " AND TransectionDate >= '" & FixControlDateToString(Me.txtDateFrom) & "'"
            If FixControl(Me.txtDateTo) <> Null_Date Then Result &= " AND TransectionDate <= '" & FixControlDateToString(Me.txtDateTo) & "'"
            'If FixControl(Me.txtSerailNum) <> Nothing Then Result &= " AND SerailNum LIKE '%" & FixControl(Me.txtSerailNum) & "%' "
            If FixControl(Me.txtSerailNum) <> Nothing Then Result &= " AND SerailNum = '" & FixControl(Me.txtSerailNum) & "' "


        Catch ex As Exception
            MsgBox("Where" & vbCrLf & ex.Message)
        End Try
        Return Result
    End Function
    Private Function WhereSalesReturn() As String
        Dim Result As String = Nothing
        Try


            Result = " WHERE (TransectionTypeCode IN (4,5)) "
            If TrimInt(Me.DropItem.Value) <> 0 Then Result &= " AND ItemCode = " & FixControl(Me.DropItem)
            If FixControl(Me.txtDateFrom) <> Null_Date Then Result &= " AND TransectionDate >= '" & FixControlDateToString(Me.txtDateFrom) & "'"
            If FixControl(Me.txtDateTo) <> Null_Date Then Result &= " AND TransectionDate <= '" & FixControlDateToString(Me.txtDateTo) & "'"
            'If FixControl(Me.txtSerailNum) <> Nothing Then Result &= " AND SerailNum LIKE '%" & FixControl(Me.txtSerailNum) & "%' "
            If FixControl(Me.txtSerailNum) <> Nothing Then Result &= " AND SerailNum = '" & FixControl(Me.txtSerailNum) & "' "


        Catch ex As Exception
            MsgBox("Where" & vbCrLf & ex.Message)
        End Try
        Return Result
    End Function
    Private Function WherePurchase() As String
        Dim Result As String = Nothing
        Try


            Result = " WHERE 1=1 "
            If TrimInt(Me.DropItem.Value) <> 0 Then Result &= " AND ItemCode = " & FixControl(Me.DropItem)
            If FixControl(Me.txtDateFrom) <> Null_Date Then Result &= " AND EffectiveDate >= '" & FixControlDateToString(Me.txtDateFrom) & "'"
            If FixControl(Me.txtDateTo) <> Null_Date Then Result &= " AND EffectiveDate <= '" & FixControlDateToString(Me.txtDateTo) & "'"
            'If FixControl(Me.txtSerailNum) <> Nothing Then Result &= " AND SerailNum LIKE '%" & FixControl(Me.txtSerailNum) & "%' "
            If FixControl(Me.txtSerailNum) <> Nothing Then Result &= " AND SerailNum = '" & FixControl(Me.txtSerailNum) & "' "


        Catch ex As Exception
            MsgBox("Where" & vbCrLf & ex.Message)
        End Try
        Return Result
    End Function
    Private Function WherePurchaseReturn() As String
        Dim Result As String = Nothing
        Try


            Result = " WHERE 1=1 "
            If TrimInt(Me.DropItem.Value) <> 0 Then Result &= " AND ItemCode = " & FixControl(Me.DropItem)
            If FixControl(Me.txtDateFrom) <> Null_Date Then Result &= " AND EffectiveDate >= '" & FixControlDateToString(Me.txtDateFrom) & "'"
            If FixControl(Me.txtDateTo) <> Null_Date Then Result &= " AND EffectiveDate <= '" & FixControlDateToString(Me.txtDateTo) & "'"
            'If FixControl(Me.txtSerailNum) <> Nothing Then Result &= " AND SerailNum LIKE '%" & FixControl(Me.txtSerailNum) & "%' "
            If FixControl(Me.txtSerailNum) <> Nothing Then Result &= " AND SerailNum = '" & FixControl(Me.txtSerailNum) & "' "


        Catch ex As Exception
            MsgBox("Where" & vbCrLf & ex.Message)
        End Try
        Return Result
    End Function
    Private Function Get_Item(ByVal Barcode As String) As Item
        Try
            Dim DT As New DataTable
            DT = Me.DropItem.DataSource

            Dim CLS As New Item
            'IF BARCODE IS NULL RETURN EMPTY CLS
            If FixObjectString(Barcode) = Nothing Then Return Nothing

            'IF BARCODE EXIST IN DS LOAD & RETURN CLS
            Dim dr() As DataRow = DT.Select(" Barcode='" & Barcode & "'")
            If dr.Length > 0 Then
                CLS.Code = IIf(IsDBNull(dr(0).Item("Code")), 0, dr(0).Item("Code"))
                CLS.ItemName = IIf(IsDBNull(dr(0).Item("ItemName")), 0, dr(0).Item("ItemName"))
                CLS.Barcode = IIf(IsDBNull(dr(0).Item("Barcode")), 0, dr(0).Item("Barcode"))
                CLS.Barcode2 = IIf(IsDBNull(dr(0).Item("Barcode2")), 0, dr(0).Item("Barcode2"))
                Return CLS
            End If
            'IF BARCODE DOSE NOT EXIST CONT...


            'IF BARCODE IS NOT INTEGER SKIP CHECKING BY CODE
            If IsNumeric(Barcode) Then
                'IF CODE IS NUMERIC AND EXIST IN DS LOAD & RETURN CLS
                Dim dr3() As DataRow = DT.Select(" Code=" & Barcode)
                If dr3.Length > 0 Then
                    CLS.Code = IIf(IsDBNull(dr3(0).Item("Code")), 0, dr3(0).Item("Code"))
                    CLS.ItemName = IIf(IsDBNull(dr3(0).Item("ItemName")), 0, dr3(0).Item("ItemName"))
                    CLS.Barcode = IIf(IsDBNull(dr3(0).Item("Barcode")), 0, dr3(0).Item("Barcode"))
                    CLS.Barcode2 = IIf(IsDBNull(dr3(0).Item("Barcode2")), 0, dr3(0).Item("Barcode2"))
                    Return CLS
                End If
            End If

            'IF BARCODE2 EXIST IN DS LOAD & RETURN CLS
            Dim dr2() As DataRow = DT.Select(" Barcode2='" & Barcode & "'")
            If dr2.Length > 0 Then
                CLS.Code = IIf(IsDBNull(dr2(0).Item("Code")), 0, dr2(0).Item("Code"))
                CLS.ItemName = IIf(IsDBNull(dr2(0).Item("ItemName")), 0, dr2(0).Item("ItemName"))
                CLS.Barcode = IIf(IsDBNull(dr2(0).Item("Barcode")), 0, dr2(0).Item("Barcode"))
                CLS.Barcode2 = IIf(IsDBNull(dr2(0).Item("Barcode2")), 0, dr2(0).Item("Barcode2"))
                Return CLS
            End If

            'IF BARCODE IS NOT CODE RETURN EMPTY CLS
            Return Nothing
        Catch ex As Exception
            MSG.ErrorOk("[Get_Item]" & vbCrLf & ex.Message)
            Return Nothing
        End Try
    End Function
    Private Sub LoadReportSales(ByVal SaleCode As Integer)
        Try
            Dim DT As New DataTable
            DT = DBO.ReturnDataTable("SELECT * FROM Sales_Full_View Where SaleCode=" & CInt(SaleCode))


            'Dim report2 As New ReportDocument
            'report2.Load(CLS_Config.ReportPath & "Bill Detail View.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)
            'report2.SetDataSource(DT)

            'report2.SetParameterValue("AccCashCustomer", FixObjectNumber(CLS_Config.AccCashCustomer))
            'report2.SetParameterValue("CompanyName", FixObjectString(CLS_Config.CompanyName))
            'report2.SetParameterValue("Address1", FixObjectString(CLS_Config.Address1))
            'report2.SetParameterValue("Address2", FixObjectString(CLS_Config.Address2))
            'report2.SetParameterValue("Address3", FixObjectString(CLS_Config.Address3))
            'report2.SetParameterValue("Tel", FixObjectString(CLS_Config.Tel))
            'report2.SetParameterValue("AmountInWords", DollarToString(DT.Rows(0).Item("NetBill")))


            Dim report2 As New ReportDocument
            report2.Load(CLS_Config.ReportPath & "Bill Detail.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)
            report2.SetDataSource(DT)

            report2.SetParameterValue("AccCashCustomer", FixObjectNumber(CLS_Config.AccCashCustomer))
            report2.SetParameterValue("CompanyName", FixObjectString(CLS_Config.CompanyName))
            report2.SetParameterValue("Address1", FixObjectString(CLS_Config.Address1))
            report2.SetParameterValue("Address2", FixObjectString(CLS_Config.Address2))
            report2.SetParameterValue("Address3", FixObjectString(CLS_Config.Address3))
            report2.SetParameterValue("Tel", FixObjectString(CLS_Config.Tel))
            report2.SetParameterValue("AmountInWords", DollarToString(DT.Rows(0).Item("NetBill")))
            report2.SetParameterValue("DecimalPlace", FixObjectNumber(CLS_Config.DecimalPlace))

            Select Case CType(DT.Rows(0).Item("TransectionTypeCode"), TransectionType)
                Case TransectionType.CashSaleReturn, TransectionType.CreditSaleReturn
                    report2.SetParameterValue("isSaleReturn", True)
                Case Else
                    report2.SetParameterValue("isSaleReturn", False)
            End Select

            Me.CR.ReportSource = report2



        Catch ex As Exception
            MsgBox("LoadReport" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub LoadReportPurchase(ByVal PurchaseCode As Integer)
        Try
            Dim DT As New DataTable
            DT = DBO.ReturnDataTable("SELECT * FROM Purchase_Entry_View Where PurchaseCode=" & CInt(PurchaseCode))


            Dim report2 As New ReportDocument
            report2.Load(CLS_Config.ReportPath & "Purchase Detail.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)
            report2.SetDataSource(DT)

            report2.SetParameterValue("AccCashCustomer", FixObjectNumber(CLS_Config.AccCashCustomer))
            report2.SetParameterValue("CompanyName", FixObjectString(CLS_Config.CompanyName))
            report2.SetParameterValue("Address1", FixObjectString(CLS_Config.Address1))
            report2.SetParameterValue("Address2", FixObjectString(CLS_Config.Address2))
            report2.SetParameterValue("Address3", FixObjectString(CLS_Config.Address3))
            report2.SetParameterValue("Tel", FixObjectString(CLS_Config.Tel))
            report2.SetParameterValue("AmountInWords", DollarToString(DT.Rows(0).Item("TotalAmount")))

            Me.CR.ReportSource = report2



        Catch ex As Exception
            MsgBox("LoadReport" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub grdList_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdList.InitializeLayout
        ' Set the RowSelectorNumberStyle to enable the row-numbers.
        e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex

        ' You can control the appearance of the row numbers using the RowSelectorAppearance.
        e.Layout.Override.RowSelectorAppearance.ForeColor = Color.Blue
        e.Layout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

        ' You can explicitly set the width of the row selectors if the default one calculated
        ' by the UltraGrid is not enough.
        e.Layout.Override.RowSelectorWidth = 25


    End Sub

    Private Sub btnColumnChooser_Click(sender As Object, e As EventArgs) Handles btnColumnChooser.Click
        If Me.UltraGridColumnChooser1.Visible Then
            Me.UltraGridColumnChooser1.Visible = False
        Else
            Me.UltraGridColumnChooser1.Visible = True
        End If
    End Sub
End Class