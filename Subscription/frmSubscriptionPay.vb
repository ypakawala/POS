Imports Infragistics.Win.UltraWinGrid
Imports POS.FixControls
Public Class frmSubscriptionPay
    Dim CLS_Sale As New Sale
    Private Sub frmSubscriptionPay_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, MenuStrip1.KeyUp, DropNewsPaper.KeyUp, DropMonth.KeyUp, DropCustomer.KeyUp
        Select Case e.KeyCode
            Case Keys.End, Keys.Escape
                Me.Close()
        End Select
    End Sub
    Private Sub frmSubscriptionPay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.Cart_Blue
        Try
            FillDropWithCondition(Me.DropNewsPaper, "ItemName", "Code", Table.Item, "CostPrice", "SalesPrice", "BarCode", "BarCode2", " WHERE ItemType = " & ItemType.Subscription_Item)
            FillDropWithCondition(Me.DropCustomer, "Title", "AccountNum", Table.Account, "Code", , , , " WHERE AccountType = " & AccountType.Customer & " AND Code<>" & CLS_Config.AccCashCustomer)
            FillDrop(Me.DropMonth, "Title", "Code", Table.D_Month)

            Me.DropMonth.DisplayLayout.Bands(0).Columns("Code").SortIndicator = SortIndicator.Ascending

            Me.txtPaymentDate.Value = Now.Date
            Me.DropNewsPaper.Focus()

        Catch ex As Exception
            MsgBox("frmSubscriptionPay_Load" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If Not isValid() Then Exit Sub
            If MSG.InfoYesNo("Do you want to Pay for seleted customer?", 2) = Windows.Forms.DialogResult.Yes Then
                Dim PARA As New ArrayList

                PARA.Add(FixObjectNumber(Me.DropCustomer.SelectedRow.Cells("Code").Value))
                PARA.Add(FixObjectNumber(Me.DropNewsPaper.Value))
                PARA.Add(FixObjectNumber(Me.DropMonth.Value))
                PARA.Add(FixObjectDate(Me.txtPaymentDate.Value))
                PARA.Add(FixObjectNumber(SalesPrice))
                PARA.Add(UserClass.Code)
                PARA.Add(CLS_Config.Counter)

                DBO.ExecuteSP("Sale_Sub_Pay", PARA)


            End If
        Catch ex As Exception
            MsgBox("btnSave_Click" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Dim SalesPrice As Decimal = 0.0
    Private Function isValid() As Boolean
        Try
            If FixControl(Me.DropNewsPaper) = Nothing Then
                Me.DropNewsPaper.Focus()
                MsgBox("News Paper / Magzine Name missing.")
                Return False
            End If
            If FixControl(Me.DropCustomer) = Nothing Then
                Me.DropCustomer.Focus()
                MsgBox("Customer missing.")
                Return False
            End If
            If FixControl(Me.DropMonth) = Nothing Then
                Me.DropMonth.Focus()
                MsgBox("Month missing.")
                Return False
            End If
            If FixControl(Me.txtPaymentDate) = Nothing Then
                Me.txtPaymentDate.Focus()
                MsgBox("Payment Date missing.")
                Return False
            End If

            SalesPrice = CLS_Sale.Sale_Sub_Exists(Me.DropCustomer.SelectedRow.Cells("Code").Value, Me.DropNewsPaper.Value, Me.DropMonth.Value)
            If SalesPrice = 0 Then
                MsgBox("Subscription dose not exists for selected customer")
                Return False
            End If

            If CLS_Sale.Sale_Sub_Payed(Me.DropCustomer.SelectedRow.Cells("Code").Value, Me.DropNewsPaper.Value, Me.DropMonth.Value) Then
                MsgBox("Subscription is already being payed.")
                Return False
            End If

            Return True
        Catch ex As Exception
            MsgBox("isValid" & vbCrLf & ex.Message)
        End Try
    End Function

    Private Sub DropNewsPaper_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DropNewsPaper.KeyDown, DropMonth.KeyDown, DropCustomer.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub
    Private Sub txtNotes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.Enter
                btnSave_Click(sender, e)
        End Select
    End Sub

End Class