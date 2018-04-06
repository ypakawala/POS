Imports POS.FixControls

Public Class frmChequeNew
    Dim Code As Integer = 0
    Dim SupplierCode As Integer = 0
    Dim DT_Supplier As New DataTable
    Public Sub New(Optional ByVal _Code As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Code = _Code

        FillDropWithCondition(Me.DropSupplierCode, "Title", "AccountNum", Table.Account, "Code", , , , " WHERE AccountType = " & AccountType.Supplier)
        DT_Supplier = CType(Me.DropSupplierCode.DataSource, DataTable)


        If Code <> 0 Then
            Dim PARA As New ArrayList
            PARA.Add(Code)
            Dim DT As New DataTable
            DT = DBO.ExecuteSP_ReturnDataTable("ChequeSelect", PARA)

            If DT.Rows.Count = 0 Then
                MsgBox("Invalid Code")
            Else
                Me.txtCode.Value = CInt(DT.Rows(0).Item("Code"))
                Me.txttDate.Value = CStr(FixObjectDate(DT.Rows(0).Item("tDate")))
                Me.txtChequeNo.Value = CStr(FixObjectString(DT.Rows(0).Item("ChequeNo")))
                Me.txtAmount.Value = CStr(FixObjectNumber(DT.Rows(0).Item("Amount")))
                Me.txtNotes.Value = CStr(FixObjectString(DT.Rows(0).Item("Notes")))
                SupplierCode = CInt(FixObjectNumber(DT.Rows(0).Item("SupplierCode")))
                Me.chkCleared.Checked = CBool(FixObjectBoolean(DT.Rows(0).Item("Cleared")))

                Dim dr() As DataRow = DT_Supplier.Select(" Code=" & SupplierCode)
                If dr.Length > 0 Then
                    Me.DropSupplierCode.Value = FixObjectString(dr(0).Item("AccountNum"))
                End If

            End If
        End If

    End Sub

    Private Sub frmChequeNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtAmount.MaskInput = Mask_Amount5

    End Sub
    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If Not IsValid() Then Exit Sub

            Dim PARA As New ArrayList

            If Code = 0 Then 'NEW
                Dim NewCode As Integer = GetNewCode("Code", DBTable.Cheque)
                PARA.Add(NewCode)
                PARA.Add(FixControl(Me.txttDate))
                PARA.Add(SupplierCode)
                PARA.Add(FixControl(Me.txtChequeNo))
                PARA.Add(FixControl(Me.txtAmount))
                PARA.Add(FixControl(Me.txtNotes))
                PARA.Add(FixObjectBoolean(Me.chkCleared.Checked))
                DBO.ExecuteSP("ChequeInsert", PARA)
            Else 'EDIT
                PARA.Add(Code)
                PARA.Add(FixControl(Me.txttDate))
                PARA.Add(SupplierCode)
                PARA.Add(FixControl(Me.txtChequeNo))
                PARA.Add(FixControl(Me.txtAmount))
                PARA.Add(FixControl(Me.txtNotes))
                PARA.Add(FixObjectBoolean(Me.chkCleared.Checked))
                DBO.ExecuteSP("ChequeUpdate", PARA)
            End If

            Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Function IsValid() As Boolean
        Try
            If FixControl(Me.txttDate) = Null_Date Then
                MsgBox("Date missing")
                Me.txttDate.Focus()
                Me.txttDate.SelectAll()
                Return False
            End If
            If FixControl(Me.DropSupplierCode) = Nothing Then
                MsgBox("Supplier missing")
                Me.DropSupplierCode.Focus()
                Return False
            End If

            Dim dr() As DataRow = DT_Supplier.Select(" AccountNum='" & FixControl(Me.DropSupplierCode) & "'")
            If dr.Length = 0 Then
                MsgBox("Supplier missing")
                Me.DropSupplierCode.Focus()
                Return False
            Else
                SupplierCode = FixObjectNumber(dr(0).Item("Code"))
            End If
            'If FixObjectNumber(Me.DropSupplierCode.SelectedRow.Cells("Code").Value) = Nothing Then
            '    MsgBox("Supplier missing")
            '    Me.DropSupplierCode.Focus()
            '    Return False
            'End If

            If FixControl(Me.txtChequeNo) = Nothing Then
                MsgBox("Cheque No Missing")
                Me.txtChequeNo.Focus()
                Me.txtChequeNo.SelectAll()
                Return False
            End If
            If FixControl(Me.txtAmount) = Nothing Then
                MsgBox("txtAmount Missing")
                Me.txtAmount.Focus()
                Me.txtAmount.SelectAll()
                Return False
            End If


            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DropSupplierCode.KeyDown, txtAmount.KeyDown, txtChequeNo.KeyDown, txtCode.KeyDown, txtNotes.KeyDown, txttDate.KeyDown, MenuStrip1.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtAmount_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmount.GotFocus
        Me.txtAmount.SelectAll()
    End Sub
End Class