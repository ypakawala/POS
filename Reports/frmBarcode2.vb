Imports CrystalDecisions.CrystalReports.Engine

Public Class frmBarcode2

    Dim m_ItemCode As Integer
    Public Property ItemCode() As Integer
        Get
            Return m_ItemCode
        End Get
        Set(ByVal value As Integer)
            m_ItemCode = value
        End Set
    End Property

    Public Sub New(ByVal _ItemCode As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_ItemCode = _ItemCode
    End Sub
    Private Sub frmBarcode_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PrintBarcode()
        Try


            If FixControls.FixControl(Me.txtNoOfCopy) = Nothing Then
                MsgBox("Select # of copy")
                Me.txtNoOfCopy.Focus()
                Me.txtNoOfCopy.SelectAll()
                Exit Sub
            End If


            Dim DT As New DataTable
            DT = DBO.ReturnDataTableFromSQL("SELECT * FROM Item_View WHERE Code = " & m_ItemCode)

            Dim report As New ReportDocument
            report.Load(CLS_Config.ReportPath & "Barcode.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)
            report.SetDataSource(DT)
            report.SetParameterValue("ExpiryDate", FixControls.FixControl(Me.txtExpiryDate))
            report.PrintToPrinter(FixControls.FixControl(Me.txtNoOfCopy), False, 0, 999)

        Catch ex As Exception
            MsgBox("LoadReport" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub btnBarcode_Click(sender As System.Object, e As System.EventArgs) Handles btnBarcode.Click

    End Sub

    Private Sub btnExit_Click(sender As System.Object, e As System.EventArgs) Handles btnExit.Click

    End Sub
End Class