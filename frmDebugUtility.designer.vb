<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDebugUtility
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDebugUtility))
        Me.btnExit = New System.Windows.Forms.Button()
        Me.grpCrc = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtCRC16ReversedResult = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCRC16Result = New System.Windows.Forms.TextBox()
        Me.grpCRCModbus = New System.Windows.Forms.GroupBox()
        Me.txtModbusCRCReversedResult = New System.Windows.Forms.TextBox()
        Me.lblReversedResult = New System.Windows.Forms.Label()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.txtModbusCRCResult = New System.Windows.Forms.TextBox()
        Me.lblData = New System.Windows.Forms.Label()
        Me.txtDataField = New System.Windows.Forms.TextBox()
        Me.btnComputeCrc = New System.Windows.Forms.Button()
        Me.grpSerialDebugger = New System.Windows.Forms.GroupBox()
        Me.lblCrcStatus = New System.Windows.Forms.Label()
        Me.lblRtuCommand = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.lblRtuResponse = New System.Windows.Forms.Label()
        Me.txtRtuResponse = New System.Windows.Forms.TextBox()
        Me.txtCommand = New System.Windows.Forms.TextBox()
        Me.btnSendToRtu = New System.Windows.Forms.Button()
        Me.tmrRead = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbAppendCRC16 = New System.Windows.Forms.RadioButton()
        Me.rbAppendModbus = New System.Windows.Forms.RadioButton()
        Me.rbAppendNothing = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbHex = New System.Windows.Forms.RadioButton()
        Me.rbAscii = New System.Windows.Forms.RadioButton()
        Me.grpCrc.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpCRCModbus.SuspendLayout()
        Me.grpSerialDebugger.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(606, 359)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(114, 33)
        Me.btnExit.TabIndex = 0
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'grpCrc
        '
        Me.grpCrc.Controls.Add(Me.GroupBox1)
        Me.grpCrc.Controls.Add(Me.grpCRCModbus)
        Me.grpCrc.Controls.Add(Me.lblData)
        Me.grpCrc.Controls.Add(Me.txtDataField)
        Me.grpCrc.Controls.Add(Me.btnComputeCrc)
        Me.grpCrc.Location = New System.Drawing.Point(397, 23)
        Me.grpCrc.Name = "grpCrc"
        Me.grpCrc.Size = New System.Drawing.Size(323, 287)
        Me.grpCrc.TabIndex = 13
        Me.grpCrc.TabStop = False
        Me.grpCrc.Text = "CRC Calculator"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtCRC16ReversedResult)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtCRC16Result)
        Me.GroupBox1.Location = New System.Drawing.Point(162, 75)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(138, 128)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "CRC-16 (FLAR)"
        '
        'txtCRC16ReversedResult
        '
        Me.txtCRC16ReversedResult.Location = New System.Drawing.Point(18, 88)
        Me.txtCRC16ReversedResult.Name = "txtCRC16ReversedResult"
        Me.txtCRC16ReversedResult.Size = New System.Drawing.Size(94, 20)
        Me.txtCRC16ReversedResult.TabIndex = 25
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Reversed Result:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Result:"
        '
        'txtCRC16Result
        '
        Me.txtCRC16Result.Location = New System.Drawing.Point(18, 46)
        Me.txtCRC16Result.Name = "txtCRC16Result"
        Me.txtCRC16Result.Size = New System.Drawing.Size(94, 20)
        Me.txtCRC16Result.TabIndex = 23
        '
        'grpCRCModbus
        '
        Me.grpCRCModbus.Controls.Add(Me.txtModbusCRCReversedResult)
        Me.grpCRCModbus.Controls.Add(Me.lblReversedResult)
        Me.grpCRCModbus.Controls.Add(Me.lblResult)
        Me.grpCRCModbus.Controls.Add(Me.txtModbusCRCResult)
        Me.grpCRCModbus.Location = New System.Drawing.Point(9, 75)
        Me.grpCRCModbus.Name = "grpCRCModbus"
        Me.grpCRCModbus.Size = New System.Drawing.Size(138, 128)
        Me.grpCRCModbus.TabIndex = 16
        Me.grpCRCModbus.TabStop = False
        Me.grpCRCModbus.Text = "CRC Modbus"
        '
        'txtModbusCRCReversedResult
        '
        Me.txtModbusCRCReversedResult.Location = New System.Drawing.Point(18, 88)
        Me.txtModbusCRCReversedResult.Name = "txtModbusCRCReversedResult"
        Me.txtModbusCRCReversedResult.Size = New System.Drawing.Size(94, 20)
        Me.txtModbusCRCReversedResult.TabIndex = 20
        '
        'lblReversedResult
        '
        Me.lblReversedResult.AutoSize = True
        Me.lblReversedResult.Location = New System.Drawing.Point(15, 72)
        Me.lblReversedResult.Name = "lblReversedResult"
        Me.lblReversedResult.Size = New System.Drawing.Size(89, 13)
        Me.lblReversedResult.TabIndex = 19
        Me.lblReversedResult.Text = "Reversed Result:"
        '
        'lblResult
        '
        Me.lblResult.AutoSize = True
        Me.lblResult.Location = New System.Drawing.Point(15, 30)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(40, 13)
        Me.lblResult.TabIndex = 17
        Me.lblResult.Text = "Result:"
        '
        'txtModbusCRCResult
        '
        Me.txtModbusCRCResult.Location = New System.Drawing.Point(18, 46)
        Me.txtModbusCRCResult.Name = "txtModbusCRCResult"
        Me.txtModbusCRCResult.Size = New System.Drawing.Size(94, 20)
        Me.txtModbusCRCResult.TabIndex = 18
        '
        'lblData
        '
        Me.lblData.AutoSize = True
        Me.lblData.Location = New System.Drawing.Point(24, 16)
        Me.lblData.Name = "lblData"
        Me.lblData.Size = New System.Drawing.Size(161, 13)
        Me.lblData.TabIndex = 14
        Me.lblData.Text = "Space Separated Hex Message:"
        '
        'txtDataField
        '
        Me.txtDataField.Location = New System.Drawing.Point(27, 32)
        Me.txtDataField.Name = "txtDataField"
        Me.txtDataField.Size = New System.Drawing.Size(273, 20)
        Me.txtDataField.TabIndex = 15
        '
        'btnComputeCrc
        '
        Me.btnComputeCrc.Location = New System.Drawing.Point(76, 217)
        Me.btnComputeCrc.Name = "btnComputeCrc"
        Me.btnComputeCrc.Size = New System.Drawing.Size(141, 35)
        Me.btnComputeCrc.TabIndex = 26
        Me.btnComputeCrc.Text = "Compute CRC"
        Me.btnComputeCrc.UseVisualStyleBackColor = True
        '
        'grpSerialDebugger
        '
        Me.grpSerialDebugger.Controls.Add(Me.GroupBox3)
        Me.grpSerialDebugger.Controls.Add(Me.GroupBox2)
        Me.grpSerialDebugger.Controls.Add(Me.lblCrcStatus)
        Me.grpSerialDebugger.Controls.Add(Me.lblRtuCommand)
        Me.grpSerialDebugger.Controls.Add(Me.btnClear)
        Me.grpSerialDebugger.Controls.Add(Me.lblRtuResponse)
        Me.grpSerialDebugger.Controls.Add(Me.txtRtuResponse)
        Me.grpSerialDebugger.Controls.Add(Me.txtCommand)
        Me.grpSerialDebugger.Controls.Add(Me.btnSendToRtu)
        Me.grpSerialDebugger.Location = New System.Drawing.Point(12, 23)
        Me.grpSerialDebugger.Name = "grpSerialDebugger"
        Me.grpSerialDebugger.Size = New System.Drawing.Size(379, 399)
        Me.grpSerialDebugger.TabIndex = 1
        Me.grpSerialDebugger.TabStop = False
        Me.grpSerialDebugger.Text = "Serial RTU Debugger"
        '
        'lblCrcStatus
        '
        Me.lblCrcStatus.AutoSize = True
        Me.lblCrcStatus.Location = New System.Drawing.Point(6, 356)
        Me.lblCrcStatus.Name = "lblCrcStatus"
        Me.lblCrcStatus.Size = New System.Drawing.Size(62, 13)
        Me.lblCrcStatus.TabIndex = 31
        Me.lblCrcStatus.Text = "CRC Status"
        '
        'lblRtuCommand
        '
        Me.lblRtuCommand.AutoSize = True
        Me.lblRtuCommand.Location = New System.Drawing.Point(6, 18)
        Me.lblRtuCommand.Name = "lblRtuCommand"
        Me.lblRtuCommand.Size = New System.Drawing.Size(191, 13)
        Me.lblRtuCommand.TabIndex = 2
        Me.lblRtuCommand.Text = "Space Separated Hex RTU Command:"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(252, 199)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(121, 35)
        Me.btnClear.TabIndex = 7
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'lblRtuResponse
        '
        Me.lblRtuResponse.AutoSize = True
        Me.lblRtuResponse.Location = New System.Drawing.Point(6, 56)
        Me.lblRtuResponse.Name = "lblRtuResponse"
        Me.lblRtuResponse.Size = New System.Drawing.Size(106, 13)
        Me.lblRtuResponse.TabIndex = 4
        Me.lblRtuResponse.Text = "Hex RTU Response:"
        '
        'txtRtuResponse
        '
        Me.txtRtuResponse.Location = New System.Drawing.Point(7, 72)
        Me.txtRtuResponse.Multiline = True
        Me.txtRtuResponse.Name = "txtRtuResponse"
        Me.txtRtuResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRtuResponse.Size = New System.Drawing.Size(366, 121)
        Me.txtRtuResponse.TabIndex = 5
        '
        'txtCommand
        '
        Me.txtCommand.Location = New System.Drawing.Point(6, 33)
        Me.txtCommand.Name = "txtCommand"
        Me.txtCommand.Size = New System.Drawing.Size(367, 20)
        Me.txtCommand.TabIndex = 3
        '
        'btnSendToRtu
        '
        Me.btnSendToRtu.Location = New System.Drawing.Point(122, 199)
        Me.btnSendToRtu.Name = "btnSendToRtu"
        Me.btnSendToRtu.Size = New System.Drawing.Size(121, 35)
        Me.btnSendToRtu.TabIndex = 6
        Me.btnSendToRtu.Text = "Send to RTU"
        Me.btnSendToRtu.UseVisualStyleBackColor = True
        '
        'tmrRead
        '
        Me.tmrRead.Interval = 10
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbAppendCRC16)
        Me.GroupBox2.Controls.Add(Me.rbAppendModbus)
        Me.GroupBox2.Controls.Add(Me.rbAppendNothing)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 251)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(160, 100)
        Me.GroupBox2.TabIndex = 32
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "CRC Option"
        '
        'rbAppendCRC16
        '
        Me.rbAppendCRC16.AutoSize = True
        Me.rbAppendCRC16.Location = New System.Drawing.Point(16, 76)
        Me.rbAppendCRC16.Name = "rbAppendCRC16"
        Me.rbAppendCRC16.Size = New System.Drawing.Size(138, 17)
        Me.rbAppendCRC16.TabIndex = 13
        Me.rbAppendCRC16.TabStop = True
        Me.rbAppendCRC16.Text = "Append CRC-16 (FLAR)"
        Me.rbAppendCRC16.UseVisualStyleBackColor = True
        '
        'rbAppendModbus
        '
        Me.rbAppendModbus.AutoSize = True
        Me.rbAppendModbus.Location = New System.Drawing.Point(16, 53)
        Me.rbAppendModbus.Name = "rbAppendModbus"
        Me.rbAppendModbus.Size = New System.Drawing.Size(128, 17)
        Me.rbAppendModbus.TabIndex = 12
        Me.rbAppendModbus.TabStop = True
        Me.rbAppendModbus.Text = "Append Modbus CRC"
        Me.rbAppendModbus.UseVisualStyleBackColor = True
        '
        'rbAppendNothing
        '
        Me.rbAppendNothing.AutoSize = True
        Me.rbAppendNothing.Location = New System.Drawing.Point(16, 30)
        Me.rbAppendNothing.Name = "rbAppendNothing"
        Me.rbAppendNothing.Size = New System.Drawing.Size(121, 17)
        Me.rbAppendNothing.TabIndex = 11
        Me.rbAppendNothing.TabStop = True
        Me.rbAppendNothing.Text = "Send Raw (no CRC)"
        Me.rbAppendNothing.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbAscii)
        Me.GroupBox3.Controls.Add(Me.rbHex)
        Me.GroupBox3.Location = New System.Drawing.Point(275, 251)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(98, 100)
        Me.GroupBox3.TabIndex = 33
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Display Option"
        '
        'rbHex
        '
        Me.rbHex.AutoSize = True
        Me.rbHex.Location = New System.Drawing.Point(7, 29)
        Me.rbHex.Name = "rbHex"
        Me.rbHex.Size = New System.Drawing.Size(44, 17)
        Me.rbHex.TabIndex = 0
        Me.rbHex.TabStop = True
        Me.rbHex.Text = "Hex"
        Me.rbHex.UseVisualStyleBackColor = True
        '
        'rbAscii
        '
        Me.rbAscii.AutoSize = True
        Me.rbAscii.Location = New System.Drawing.Point(7, 53)
        Me.rbAscii.Name = "rbAscii"
        Me.rbAscii.Size = New System.Drawing.Size(52, 17)
        Me.rbAscii.TabIndex = 1
        Me.rbAscii.TabStop = True
        Me.rbAscii.Text = "ASCII"
        Me.rbAscii.UseVisualStyleBackColor = True
        '
        'frmDebugUtility
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(743, 439)
        Me.Controls.Add(Me.grpSerialDebugger)
        Me.Controls.Add(Me.grpCrc)
        Me.Controls.Add(Me.btnExit)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDebugUtility"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EZProbe Modbus Debug Utility"
        Me.grpCrc.ResumeLayout(False)
        Me.grpCrc.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpCRCModbus.ResumeLayout(False)
        Me.grpCRCModbus.PerformLayout()
        Me.grpSerialDebugger.ResumeLayout(False)
        Me.grpSerialDebugger.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents grpCrc As System.Windows.Forms.GroupBox
    Friend WithEvents lblData As System.Windows.Forms.Label
    Friend WithEvents txtDataField As System.Windows.Forms.TextBox
    Friend WithEvents btnComputeCrc As System.Windows.Forms.Button
    Friend WithEvents grpSerialDebugger As System.Windows.Forms.GroupBox
    Friend WithEvents lblRtuResponse As System.Windows.Forms.Label
    Friend WithEvents txtRtuResponse As System.Windows.Forms.TextBox
    Friend WithEvents txtCommand As System.Windows.Forms.TextBox
    Friend WithEvents btnSendToRtu As System.Windows.Forms.Button
    Friend WithEvents tmrRead As System.Windows.Forms.Timer
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents lblRtuCommand As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCRC16ReversedResult As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCRC16Result As System.Windows.Forms.TextBox
    Friend WithEvents grpCRCModbus As System.Windows.Forms.GroupBox
    Friend WithEvents txtModbusCRCReversedResult As System.Windows.Forms.TextBox
    Friend WithEvents lblReversedResult As System.Windows.Forms.Label
    Friend WithEvents lblResult As System.Windows.Forms.Label
    Friend WithEvents txtModbusCRCResult As System.Windows.Forms.TextBox
    Friend WithEvents lblCrcStatus As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbAscii As System.Windows.Forms.RadioButton
    Friend WithEvents rbHex As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbAppendCRC16 As System.Windows.Forms.RadioButton
    Friend WithEvents rbAppendModbus As System.Windows.Forms.RadioButton
    Friend WithEvents rbAppendNothing As System.Windows.Forms.RadioButton

End Class
