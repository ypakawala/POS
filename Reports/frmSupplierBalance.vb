﻿Imports System.Math
Imports CrystalDecisions.CrystalReports.Engine
Imports POS.FixControls
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class frmSupplierBalance
    Dim DT As New DataTable
    Private Sub frmSupplierBalance_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, CRV.KeyUp, MenuStrip1.KeyUp
        If e.KeyCode = Keys.End Then
            Me.Close()
        End If
    End Sub
    Private Sub frmSupplierBalance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.Cart_Blue
        Try
            LoadReport()

        Catch ex As Exception
            MsgBox("frmSupplierBalance_Load" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub LoadReport()
        Try
            DT = New DataTable
            DT = DBO.ReturnDataTableFromSQL("SELECT * FROM Purchase_Balance")

            Dim report As New ReportDocument
            report.Load(CLS_Config.ReportPath & "Supplier Balance.rpt", CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)
            report.SetDataSource(DT)

            report.SetParameterValue("CompanyName", FixObjectString(CLS_Config.CompanyName))
            report.SetParameterValue("Address1", FixObjectString(CLS_Config.Address1))
            report.SetParameterValue("Address2", FixObjectString(CLS_Config.Address2))
            report.SetParameterValue("Address3", FixObjectString(CLS_Config.Address3))
            report.SetParameterValue("Tel", FixObjectString(CLS_Config.Tel))

            Me.CRV.ReportSource = report


        Catch ex As Exception
            MsgBox("LoadReport" & vbCrLf & ex.Message)
        End Try
    End Sub
End Class