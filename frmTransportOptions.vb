Imports System.IO.Ports

Public Class frmTransportOptions
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub frmTransportOptions_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If (clsCommObjFactory.GetInstance.SerialOrSocket) Then
            rbCommPort.Checked = True
        Else
            rbTcpIp.Checked = True
        End If
        clsCommObjFactory.GetInstance.FillCommPortCombo(cboComPort)
        txtIpAddress.Text = clsCommObjFactory.GetInstance.IpAddress
        txtBaud.Text = clsCommObjFactory.GetInstance.BaudRate.ToString
        numPortNumber.Value = clsCommObjFactory.GetInstance.IpPort.ToString
    End Sub

    Private Sub btnExit_Click(sender As System.Object, e As System.EventArgs) Handles btnExit.Click
        If (rbCommPort.Checked) Then
            clsCommObjFactory.GetInstance.SerialOrSocket = True
        Else
            clsCommObjFactory.GetInstance.SerialOrSocket = False
        End If
        clsCommObjFactory.GetInstance.IpAddress = txtIpAddress.Text
        clsCommObjFactory.GetInstance.IpPort = numPortNumber.Value
        clsCommObjFactory.GetInstance.BaudRate = txtBaud.Text
        clsCommObjFactory.GetInstance.SetCommPortComboChoice(cboComPort)
        clsCommObjFactory.GetInstance.SaveApplicationSettings()
        Me.Close()
    End Sub


End Class