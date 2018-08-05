<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransportOptions
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTransportOptions))
        Me.btnExit = New System.Windows.Forms.Button()
        Me.grpCommPortSettings = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtBaud = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboComPort = New System.Windows.Forms.ComboBox()
        Me.grpTcpIpSettings = New System.Windows.Forms.GroupBox()
        Me.numPortNumber = New System.Windows.Forms.NumericUpDown()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txtIpAddress = New System.Windows.Forms.TextBox()
        Me.rbCommPort = New System.Windows.Forms.RadioButton()
        Me.rbTcpIp = New System.Windows.Forms.RadioButton()
        Me.grpCommPortSettings.SuspendLayout()
        Me.grpTcpIpSettings.SuspendLayout()
        CType(Me.numPortNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(189, 359)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 14
        Me.btnExit.Text = "OK"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'grpCommPortSettings
        '
        Me.grpCommPortSettings.Controls.Add(Me.Label4)
        Me.grpCommPortSettings.Controls.Add(Me.txtBaud)
        Me.grpCommPortSettings.Controls.Add(Me.Label3)
        Me.grpCommPortSettings.Controls.Add(Me.cboComPort)
        Me.grpCommPortSettings.Location = New System.Drawing.Point(24, 230)
        Me.grpCommPortSettings.Name = "grpCommPortSettings"
        Me.grpCommPortSettings.Size = New System.Drawing.Size(159, 152)
        Me.grpCommPortSettings.TabIndex = 13
        Me.grpCommPortSettings.TabStop = False
        Me.grpCommPortSettings.Text = "Comm Port Settings"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Com Port:"
        '
        'txtBaud
        '
        Me.txtBaud.Location = New System.Drawing.Point(6, 91)
        Me.txtBaud.Name = "txtBaud"
        Me.txtBaud.Size = New System.Drawing.Size(100, 20)
        Me.txtBaud.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Baud:"
        '
        'cboComPort
        '
        Me.cboComPort.FormattingEnabled = True
        Me.cboComPort.Location = New System.Drawing.Point(6, 43)
        Me.cboComPort.Name = "cboComPort"
        Me.cboComPort.Size = New System.Drawing.Size(121, 21)
        Me.cboComPort.Sorted = True
        Me.cboComPort.TabIndex = 0
        '
        'grpTcpIpSettings
        '
        Me.grpTcpIpSettings.Controls.Add(Me.numPortNumber)
        Me.grpTcpIpSettings.Controls.Add(Me.label2)
        Me.grpTcpIpSettings.Controls.Add(Me.label1)
        Me.grpTcpIpSettings.Controls.Add(Me.txtIpAddress)
        Me.grpTcpIpSettings.Location = New System.Drawing.Point(24, 49)
        Me.grpTcpIpSettings.Name = "grpTcpIpSettings"
        Me.grpTcpIpSettings.Size = New System.Drawing.Size(159, 124)
        Me.grpTcpIpSettings.TabIndex = 12
        Me.grpTcpIpSettings.TabStop = False
        Me.grpTcpIpSettings.Text = "TCP/IP Settings"
        '
        'numPortNumber
        '
        Me.numPortNumber.Location = New System.Drawing.Point(15, 84)
        Me.numPortNumber.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.numPortNumber.Name = "numPortNumber"
        Me.numPortNumber.Size = New System.Drawing.Size(113, 20)
        Me.numPortNumber.TabIndex = 4
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(11, 68)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(69, 13)
        Me.label2.TabIndex = 3
        Me.label2.Text = "Port Number:"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(7, 20)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(124, 13)
        Me.label1.TabIndex = 1
        Me.label1.Text = "IP Address or Hostname:"
        '
        'txtIpAddress
        '
        Me.txtIpAddress.Location = New System.Drawing.Point(6, 36)
        Me.txtIpAddress.Name = "txtIpAddress"
        Me.txtIpAddress.Size = New System.Drawing.Size(122, 20)
        Me.txtIpAddress.TabIndex = 0
        '
        'rbCommPort
        '
        Me.rbCommPort.AutoSize = True
        Me.rbCommPort.Location = New System.Drawing.Point(24, 207)
        Me.rbCommPort.Name = "rbCommPort"
        Me.rbCommPort.Size = New System.Drawing.Size(76, 17)
        Me.rbCommPort.TabIndex = 11
        Me.rbCommPort.TabStop = True
        Me.rbCommPort.Text = "Comm Port"
        Me.rbCommPort.UseVisualStyleBackColor = True
        '
        'rbTcpIp
        '
        Me.rbTcpIp.AutoSize = True
        Me.rbTcpIp.Location = New System.Drawing.Point(24, 25)
        Me.rbTcpIp.Name = "rbTcpIp"
        Me.rbTcpIp.Size = New System.Drawing.Size(61, 17)
        Me.rbTcpIp.TabIndex = 10
        Me.rbTcpIp.TabStop = True
        Me.rbTcpIp.Text = "TCP/IP"
        Me.rbTcpIp.UseVisualStyleBackColor = True
        '
        'frmTransportOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(282, 394)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.grpCommPortSettings)
        Me.Controls.Add(Me.grpTcpIpSettings)
        Me.Controls.Add(Me.rbCommPort)
        Me.Controls.Add(Me.rbTcpIp)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmTransportOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.grpCommPortSettings.ResumeLayout(False)
        Me.grpCommPortSettings.PerformLayout()
        Me.grpTcpIpSettings.ResumeLayout(False)
        Me.grpTcpIpSettings.PerformLayout()
        CType(Me.numPortNumber, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnExit As System.Windows.Forms.Button
    Private WithEvents grpCommPortSettings As System.Windows.Forms.GroupBox
    Private WithEvents grpTcpIpSettings As System.Windows.Forms.GroupBox
    Private WithEvents numPortNumber As System.Windows.Forms.NumericUpDown
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents txtIpAddress As System.Windows.Forms.TextBox
    Private WithEvents rbCommPort As System.Windows.Forms.RadioButton
    Private WithEvents rbTcpIp As System.Windows.Forms.RadioButton
    Friend WithEvents cboComPort As System.Windows.Forms.ComboBox
    Friend WithEvents txtBaud As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
