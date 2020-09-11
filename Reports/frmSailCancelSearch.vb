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
        Me.Icon = My.Resources.Cart_Blue
        Try
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

            Me.grdList.DataSource = Nothing
            Me.grdList.DataBind()

        Catch ex As Exception
            MsgBox("btnClearAll_Click" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub FillGrid()
        Try

            If Not isValid() Then Exit Sub

            Dim DT As New DataTable
            DT = New DataTable
            'DT = DBO.ReturnDataTableFromSQL("SELECT  Code, TransectionDate,TransectionType,HoldCleared,UserName FROM SaleCancel_View " & Where() & "  GROUP BY Code, TransectionDate,TransectionType,HoldCleared,UserName ORDER BY TransectionDate,TransectionType DESC")
            DT = DBO.ReturnDataTableFromSQL("SELECT C.Code, C.TransectionDate, C.TransectionType, C.HoldCleared, U.UserName,C.NetBill, C.Remark,C.UserCode,C.CounterCode " &
                                            " FROM SaleCancel AS C INNER JOIN P_User AS U ON C.UserCode = U.Code" &
                                            Where() &
                                            " ORDER BY C.TransectionDate, C.TransectionType DESC")

            Dim DT2 As New DataTable
            DT2 = New DataTable
            'DT2 = DBO.ReturnDataTableFromSQL("SELECT  Code, ItemName, UnitPrice, Quantity,TotalPrice FROM    SaleCancel_View " & Where())
            DT2 = DBO.ReturnDataTableFromSQL("SELECT E.SaleCode, I.ItemName, E.UnitPrice, E.Quantity, E.TotalPrice " &
                                            " FROM SaleCancel_Entry AS E INNER JOIN Item AS I ON E.ItemCode = I.Code INNER JOIN SaleCancel AS C ON E.SaleCode = C.Code " &
                                             Where())

            Dim ds As New DataSet
            ds.Tables.Add(DT)
            ds.Tables.Add(DT2)

            If ds.Tables(1).Rows.Count > 0 Then
                'Create the Data Relationship
                ds.Relations.Add("Child", ds.Tables(0).Columns("Code"),
                                            ds.Tables(1).Columns("SaleCode"))
            End If
            Me.grdList.DataSource = ds
            Me.grdList.DataMember = "Table1"
            Me.grdList.DataBind()

            'Me.grdList.DisplayLayout.Bands(0).Columns("SaleCode").Hidden = True
            Me.grdList.DisplayLayout.Bands(0).Columns("TransectionDate").MaskInput = "{LOC}dd/mm/yyyy hh:mm"

            Me.grdList.DisplayLayout.Bands(0).Columns("Code").Header.VisiblePosition = 0
            Me.grdList.DisplayLayout.Bands(0).Columns("TransectionDate").Header.VisiblePosition = 1
            Me.grdList.DisplayLayout.Bands(0).Columns("HoldCleared").Header.VisiblePosition = 2
            Me.grdList.DisplayLayout.Bands(0).Columns("UserName").Header.VisiblePosition = 3
            Me.grdList.DisplayLayout.Bands(0).Columns("NetBill").Header.VisiblePosition = 4
            Me.grdList.DisplayLayout.Bands(0).Columns("Remark").Header.VisiblePosition = 5

            Me.grdList.DisplayLayout.Bands(0).Columns("Code").Width = 100
            Me.grdList.DisplayLayout.Bands(0).Columns("TransectionDate").Width = 100
            Me.grdList.DisplayLayout.Bands(0).Columns("HoldCleared").Width = 100
            Me.grdList.DisplayLayout.Bands(0).Columns("UserName").Width = 100
            Me.grdList.DisplayLayout.Bands(0).Columns("NetBill").Width = 100
            Me.grdList.DisplayLayout.Bands(0).Columns("Remark").Width = 250

            If ds.Tables(1).Rows.Count > 0 Then
                Me.grdList.DisplayLayout.Bands(1).Columns("SaleCode").Hidden = True

                Me.grdList.DisplayLayout.Bands(1).Columns("ItemName").Header.VisiblePosition = 0
                Me.grdList.DisplayLayout.Bands(1).Columns("UnitPrice").Header.VisiblePosition = 1
                Me.grdList.DisplayLayout.Bands(1).Columns("Quantity").Header.VisiblePosition = 2
                Me.grdList.DisplayLayout.Bands(1).Columns("TotalPrice").Header.VisiblePosition = 3

                Me.grdList.DisplayLayout.Bands(1).Columns("ItemName").Width = 300
                Me.grdList.DisplayLayout.Bands(1).Columns("UnitPrice").Width = 100
                Me.grdList.DisplayLayout.Bands(1).Columns("Quantity").Width = 100
                Me.grdList.DisplayLayout.Bands(1).Columns("TotalPrice").Width = 100


                Me.grdList.DisplayLayout.Bands(1).Columns("UnitPrice").MaskInput = Mask_Amount
                Me.grdList.DisplayLayout.Bands(1).Columns("Quantity").MaskInput = Mask_Amount
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

        Catch ex As Exception
            MsgBox("Where" & vbCrLf & ex.Message)
        End Try
        Return Result
    End Function

End Class