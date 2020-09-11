Imports System.Math
Imports CrystalDecisions.CrystalReports.Engine
Imports POS.FixControls
Imports System.Drawing.Printing

Public Class frmBarcode
    Dim m_ItemCode As Integer
    Dim m_isClass As Boolean

    Public Sub New(ByVal _ItemCode As Integer, ByVal isClass As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_ItemCode = _ItemCode
        m_isClass = isClass

    End Sub
    Private Sub frmBarcode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, MenuStrip1.KeyUp, MenuStrip1.KeyUp
        If e.KeyCode = Keys.End Then Me.Close()
    End Sub
    Private Sub frmBarcode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.Cart_Blue
        Try
            If CLS_Config.SearchByBarcode Then
                If m_isClass Then
                    FillDropByQuery(Me.DropItem, "ItemName", "Code", "SELECT Code, COALESCE(Barcode,'') + ' - ' + COALESCE(ItemName,'') AS ItemName,SalesPrice,BarCode,BarCode2 FROM ItemClass")
                Else
                    FillDropByQuery(Me.DropItem, "ItemName", "Code", "SELECT Code, COALESCE(barcode,'') + ' - ' + COALESCE(ItemName,'') AS ItemName,CostPrice,SalesPrice,BarCode,BarCode2 FROM ITEM")
                End If
                Me.DropItem.DisplayLayout.Bands(0).Columns("CostPrice").Hidden = True
                Me.DropItem.DisplayLayout.Bands(0).Columns("SalesPrice").Hidden = True
                Me.DropItem.DisplayLayout.Bands(0).Columns("BarCode").Hidden = True
                Me.DropItem.DisplayLayout.Bands(0).Columns("BarCode2").Hidden = True
            Else
                If m_isClass Then
                    FillDrop(Me.DropItem, "ItemName", "Code", Table.ItemClass, "SalesPrice", "BarCode", "BarCode2")
                Else
                    FillDrop(Me.DropItem, "ItemName", "Code", Table.Item, "CostPrice", "SalesPrice", "BarCode", "BarCode2")
                End If
            End If

            If m_ItemCode <> Nothing Then Me.DropItem.Value = m_ItemCode

            Me.txtNoOfCopy.Value = 1
            Me.txtExpiryDate.Value = Nothing


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        LoadReport()
    End Sub
    Private Sub btnClearAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClearAll.Click
        Me.txtNoOfCopy.Value = Nothing
        Me.txtExpiryDate.Value = Nothing
    End Sub
    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Function isValid() As Boolean
        Try
            If FixControls.FixControl(Me.DropItem) = Nothing Then
                MsgBox("Select Itme")
                Me.DropItem.Focus()
                Return False
            End If

            If FixControls.FixControl(Me.txtNoOfCopy) = Nothing Then
                MsgBox("Select # of copy")
                Me.txtNoOfCopy.Focus()
                Me.txtNoOfCopy.SelectAll()
                Return False
            End If

            Return True
        Catch ex As Exception
            MsgBox("isValid" & vbCrLf & ex.Message)
        End Try
    End Function
    Private Sub LoadReport()
        Try
            If Not isValid() Then Exit Sub



            Dim DT As New DataTable
            If m_isClass Then
                DT = DBO.ReturnDataTableFromSQL("SELECT * FROM ItemClass AS Item_View WHERE Code = " & FixControls.FixControl(Me.DropItem))
            Else
                DT = DBO.ReturnDataTableFromSQL("SELECT * FROM Item_View WHERE Code = " & FixControls.FixControl(Me.DropItem))
            End If

            'txtDataToEncode.Text = DT.Rows(0).Item("barcode")

            'Dim FontEncoder As New IDAutomation.NetAssembly.FontEncoder
            'Dim UniversalFontEncoder As New IDAutomation.NetAssembly.UniversalFontEncoder
            'Dim IntelligentMail As New IDAutomation.IntelligentMail.IntelligentMail
            'Dim DataBar As New IDAutomation.DataBar.DataBar

            'txtEncodedText.Text = UniversalFontEncoder.IDAutomation_Uni_C128(txtDataToEncode.Text)

            'DT.Rows(0).Item("barcode") = txtEncodedText.Text



            'Dim b As New theNext.UC.Barcode
            'b.BarcodeStr = getValueFromDrop(CType(Me.DropItem.DataSource, DataTable), "Code", FixControl(Me.DropItem), "BarCode")
            'b.BarcodeType = CLS_Config.BarcodeType


            'Dim BarcodeByte As Byte()
            'BarcodeByte = b.GetBarcodeImage()

            'For Each dr As DataRow In DT.Rows
            '    dr("BarcodeImg") = BarcodeByte
            'Next


            Dim report As New ReportDocument
            report.Load(CLS_Config.ReportPath & "Barcode.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)
            report.SetDataSource(DT)
            report.SetParameterValue("ExpiryDate", FixControls.FixControl(Me.txtExpiryDate))
            Me.CRV.ReportSource = report


        Catch ex As Exception
            MsgBox("LoadReport" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub DropItem_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DropItem.KeyDown
        Try
            Dim CLS_Item As New Item
            Dim CLS_ItemClass As New ItemClass
            Select Case e.KeyCode
                Case Keys.Enter

                    If IsDBNull(Me.DropItem.Text) Or IsNothing(Me.DropItem.Text) Then
                    Else
                        Dim Item_Code As Integer = Nothing
                        If m_isClass Then CLS_ItemClass.Exists_By_Barcode(Me.DropItem.Text)
                        If Not m_isClass Then CLS_Item.Exists_By_Barcode(Me.DropItem.Text)
                        If Item_Code <> 0 Then
                            Me.DropItem.Value = Item_Code
                            Me.DropItem.Focus()
                            Exit Sub
                        End If
                    End If

                    If IsDBNull(Me.DropItem.Value) Or IsNothing(Me.DropItem.Value) Then
                    ElseIf Me.DropItem.Value = Nothing Then
                    Else
                        If m_isClass Then
                            If CLS_ItemClass.Exists(Me.DropItem.Value) Then
                                Me.DropItem.Focus()
                                Exit Sub
                            End If
                        Else
                            If CLS_Item.Exists(Me.DropItem.Value) Then
                                Me.DropItem.Focus()
                                Exit Sub
                            End If
                        End If
                    End If

                    MsgBox("Item Dose Not Exists")



            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnBarcode2_Click(sender As Object, e As EventArgs) Handles btnBarcode2.Click
        Try
            If IsDBNull(Me.DropItem.Value) Or IsNothing(Me.DropItem.Value) Then Exit Sub
            If IsDBNull(Me.txtNoOfCopy.Value) Or IsNothing(Me.txtNoOfCopy.Value) Then Me.txtNoOfCopy.Value = 1

            Dim b As New theNext.UC.Barcode
            b.BarcodePrinterName = CLS_Config.BarcodePrinter
            b.BarcodeShowCompany = CLS_Config.BarcodeShowCompany
            b.BarcodeShowItem = CLS_Config.BarcodeShowItem
            b.BarcodeShowPrice = CLS_Config.BarcodeShowPrice
            b.CompanyName = CLS_Config.CompanyName
            b.ItemName = getValueFromDrop(CType(Me.DropItem.DataSource, DataTable), "Code", FixControl(Me.DropItem), "ItemName")
            b.BarcodeFontSize = CLS_Config.BarcodeFontSize
            b.BarcodeTop = CLS_Config.BarcodeTop
            b.BarcodeLeft = CLS_Config.BarcodeLeft
            b.BarcodeHeight = CLS_Config.BarcodeHeight
            b.BarcodeWidth = CLS_Config.BarcodeWidth
            b.BarcodeGap = CLS_Config.BarcodeGap
            b.SalesPrice = getValueFromDrop(CType(Me.DropItem.DataSource, DataTable), "Code", FixControl(Me.DropItem), "SalesPrice")
            b.BarcodeStr = getValueFromDrop(CType(Me.DropItem.DataSource, DataTable), "Code", FixControl(Me.DropItem), "BarCode")
            b.CurrencySymbol = "KD"
            b.DecimalPlace = 3
            b.BarcodeType = CLS_Config.BarcodeType

            b.ExpiryDate = TrimDate(Me.txtExpiryDate.Value)
            b.NoOfCopy = TrimInt(Me.txtNoOfCopy.Value)

            b.Print()

            'Dim count As Integer = Me.txtNoOfCopy.Value
            'If count >= 1 Then

            '    Me.Barcode1.Text = getValueFromDrop(CType(Me.DropItem.DataSource, DataTable), "Code", FixControl(Me.DropItem), "BarCode")
            '    Dim prndoc As PrintDocument = New PrintDocument()
            '    prndoc.DocumentName = "Printing a Barcode"
            '    AddHandler prndoc.PrintPage, New System.Drawing.Printing.PrintPageEventHandler(AddressOf PrintBarCode)
            '    prndoc.PrinterSettings.Copies = count
            '    prndoc.PrinterSettings.PrinterName = CLS_Config.BarcodePrinter
            '    prndoc.Print()
            'End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub PrintBarCode(ByVal sender As Object, ByVal ppea As PrintPageEventArgs)
        Try
            'Barcode Size
            'Width  3.2 CM
            'Height 2.2 CM

            Dim fnt As New System.Drawing.Font("Microsoft Sans Serif", 6.25!, FontStyle.Bold)

            Dim grfx As System.Drawing.Graphics = ppea.Graphics
            Dim myImage As System.Drawing.Imaging.Metafile
            grfx.PageUnit = GraphicsUnit.Millimeter
            grfx.PageScale = 0.1F

            grfx.DrawString(CLS_Config.CompanyName, fnt, Brushes.Black, 0, 0)

            Dim ItemName As String = getValueFromDrop(CType(Me.DropItem.DataSource, DataTable), "Code", FixControl(Me.DropItem), "ItemName")
            If ItemName.Length > 21 Then
                ItemName = ItemName.Substring(0, 21)
            End If
            grfx.DrawString(ItemName, fnt, Brushes.Black, 0, 30)



            Dim EXP As String = Nothing

            If FixObjectDate(Me.txtExpiryDate.Value) <> Null_Date Then
                EXP = "   EXP: " & FixObjectDate(Me.txtExpiryDate.Value).ToString("MMM-yy")
            End If

            If CLS_Config.Company = ZAHRABAKALA Then
                grfx.DrawString(Trim(EXP), fnt, Brushes.Black, 0, 60)
            Else
                Dim SP As Decimal = getValueFromDrop(CType(Me.DropItem.DataSource, DataTable), "Code", FixControl(Me.DropItem), "SalesPrice")
                grfx.DrawString("PRICE " & ConvertToString(SP) & EXP, fnt, Brushes.Black, 0, 60)
            End If



            Barcode1.Refresh()
            'myImage = Barcode1.Picture
            myImage = Barcode1.Image
            'grfx.DrawImage(myImage, 0, 85, 300, 122)
            'grfx.DrawImage(myImage, 0, 85, 300, CLS_Config.BarcodeHeight)
            grfx.DrawImage(myImage, 0, 85, CLS_Config.BarcodeWidth, CLS_Config.BarcodeHeight)


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class