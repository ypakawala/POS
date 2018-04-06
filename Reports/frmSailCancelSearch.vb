Imports System.Math
Imports CrystalDecisions.CrystalReports.Engine
Imports POS.FixControls
Public Class frmSailCancelSearch

    Private Sub frmSailCancelSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, MenuStrip1.KeyUp, txtDateFrom.KeyUp, txtDateTo.KeyUp, UltraExpandableGroupBox1.KeyUp, grdList.KeyUp
        If e.KeyCode = Keys.End Then
            Me.Close()
        End If
    End Sub
    Private Sub frmSailCancelSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FillDrop(Me.DropItem, "ItemName", "Code", Table.Item, "CostPrice", "BarCode", "BarCode2")
            FillDrop(Me.DropUser, "UserName", "Code", Table.P_User)
            FillDrop(Me.DropCounter, "Title", "Code", Table.D_Counter)

            Me.txtDateFrom.Value = Now.Date
            Me.txtDateTo.Value = New DateTime(Now.Year, Now.Month, Now.Day, 23, 59, 59)
            Me.txtDateFrom.Focus()

        Catch ex As Exception
            MsgBox("frmSailSearch_Load" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        FillGrid()
    End Sub
    Private Sub btnClearAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClearAll.Click
        Try
            Me.txtDateFrom.Value = Now.Date
            Me.txtDateTo.Value = Now
            Me.DropUser.Value = Nothing
            Me.DropItem.Value = Nothing

            Me.grdList.DataSource = Nothing
            Me.grdList.DataBind()

        Catch ex As Exception
            MsgBox("btnClearAll_Click" & vbCrLf & ex.Message)
        End Try
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

    Private Sub FillGrid()
        Try

            If Not isValid() Then Exit Sub

            Dim DT As New DataTable
            DT = New DataTable
            DT = DBO.ReturnDataTableFromSQL("SELECT  Code, TransectionDate,TransectionType,HoldCleared,UserName FROM SaleCancel_View " & Where() & "  GROUP BY Code, TransectionDate,TransectionType,HoldCleared,UserName ORDER BY TransectionDate,TransectionType DESC")

            Dim DT2 As New DataTable
            DT2 = New DataTable
            DT2 = DBO.ReturnDataTableFromSQL("SELECT  Code, ItemName, UnitPrice, Quantity,TotalPrice FROM    SaleCancel_View " & Where())

            Dim ds As New DataSet
            ds.Tables.Add(DT)
            ds.Tables.Add(DT2)

            If ds.Tables(1).Rows.Count > 0 Then
                'Create the Data Relationship
                ds.Relations.Add("Child", ds.Tables(0).Columns("Code"), _
                                            ds.Tables(1).Columns("Code"))
            End If
            Me.grdList.DataSource = ds
            Me.grdList.DataMember = "Table1"
            Me.grdList.DataBind()
            Me.grdList.DisplayLayout.Override.RowAlternateAppearance = RowAlternateAppearance

            'Me.grdList.DisplayLayout.Bands(0).Columns("SaleCode").Hidden = True
            Me.grdList.DisplayLayout.Bands(0).Columns("TransectionDate").MaskInput = "{LOC}dd/mm/yyyy hh:mm"

            Me.grdList.DisplayLayout.Bands(0).Columns("Code").Header.VisiblePosition = 0
            Me.grdList.DisplayLayout.Bands(0).Columns("TransectionDate").Header.VisiblePosition = 1
            Me.grdList.DisplayLayout.Bands(0).Columns("HoldCleared").Header.VisiblePosition = 2
            Me.grdList.DisplayLayout.Bands(0).Columns("UserName").Header.VisiblePosition = 3

            Me.grdList.DisplayLayout.Bands(0).Columns("Code").Width = 100
            Me.grdList.DisplayLayout.Bands(0).Columns("TransectionDate").Width = 100
            Me.grdList.DisplayLayout.Bands(0).Columns("HoldCleared").Width = 100
            Me.grdList.DisplayLayout.Bands(0).Columns("UserName").Width = 100

            If ds.Tables(1).Rows.Count > 0 Then
                Me.grdList.DisplayLayout.Bands(1).Columns("Code").Hidden = True

                Me.grdList.DisplayLayout.Bands(1).Columns("ItemName").Header.VisiblePosition = 0
                Me.grdList.DisplayLayout.Bands(1).Columns("UnitPrice").Header.VisiblePosition = 1
                Me.grdList.DisplayLayout.Bands(1).Columns("Quantity").Header.VisiblePosition = 2
                Me.grdList.DisplayLayout.Bands(1).Columns("TotalPrice").Header.VisiblePosition = 3

                Me.grdList.DisplayLayout.Bands(1).Columns("ItemName").Width = 300
                Me.grdList.DisplayLayout.Bands(1).Columns("UnitPrice").Width = 100
                Me.grdList.DisplayLayout.Bands(1).Columns("Quantity").Width = 100
                Me.grdList.DisplayLayout.Bands(1).Columns("TotalPrice").Width = 100


                Me.grdList.DisplayLayout.Bands(1).Columns("UnitPrice").MaskInput = Mask_Amount
                Me.grdList.DisplayLayout.Bands(1).Columns("Quantity").MaskInput = Mask_Qty
                Me.grdList.DisplayLayout.Bands(1).Columns("TotalPrice").MaskInput = Mask_Amount

            End If
          
        Catch ex As Exception
            MsgBox("FillGrid" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Function isValid() As Boolean
        Try
            If FixControl(Me.txtDateFrom) = Null_Date Then
                MSG.ErrorOk("[DATE FROM] is missing.")
                Me.txtDateFrom.Focus()
                Me.txtDateFrom.SelectAll()
                Return False
            End If

            If FixControl(Me.txtDateTo) <> Null_Date Then
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
    Private Function Where() As String
        Dim Result As String = Nothing
        Try
            Result = " WHERE TransectionDate >= '" & FixControlDateToString(Me.txtDateFrom) & "'"

            If FixControl(Me.txtDateTo) <> Null_Date Then Result &= " AND TransectionDate <= '" & FixControlDateToString(Me.txtDateTo) & "'"

            If FixControl(Me.DropUser) <> Nothing Then Result &= " AND UserCode = " & FixControl(Me.DropUser)
            If FixControl(Me.DropCounter) <> Nothing Then Result &= " AND CounterCode = " & FixControl(Me.DropCounter)
            If FixControl(Me.DropItem) <> Nothing Then Result &= " AND ItemCode = " & FixControl(Me.DropItem)

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
    


End Class