Imports System
Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic
Imports System.Convert

Public Class frmDebugUtility
    Dim objCrcCalculator As New clsCrcCalculator()
    Const BLOCK_LIMIT As Integer = 2049
    Dim buffer() As Byte = New Byte(BLOCK_LIMIT) {}
    Dim responseMessage() As Byte
    Private Delegate Sub SetTextBoxTextInvoker(ByVal text As String)
    Private Delegate Sub SetTextBoxTextColorInvoker(ByVal color As Color)
    Private thisLock As New Object  'Used for synclock

    Private destOffset As Integer = 0
    Private _TransportObject As ICommunications
    Private _stream As Stream
    Private Event DataReceivedEvent(ByVal b() As Byte)
    'https://www.dotnetperls.com/lambda-vbnet
    'https://msdn.microsoft.com/en-us/library/system.buffer.blockcopy(v=vs.110).aspx
    Private kickoffRead As Action = Sub()
                                        Try 'This handles the error caused by closing the connection when the form closes
                                            _stream.BeginRead(buffer, 0, buffer.Length, Sub(ar As IAsyncResult)
                                                                                            Try
                                                                                                Dim actualLength As Integer = _stream.EndRead(ar)
                                                                                                Dim received() As Byte = New Byte(actualLength - 1) {}
                                                                                                Array.Copy(buffer, received, actualLength)
                                                                                                'System.Buffer.BlockCopy(buffer, 0, received, 0, actualLength)
                                                                                                RaiseEvent DataReceivedEvent(received)
                                                                                            Catch ex As Exception
                                                                                                Debug.Print(ex.ToString)
                                                                                            End Try
                                                                                            kickoffRead()
                                                                                        End Sub, Nothing)

                                        Catch
                                        End Try
                                    End Sub


    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        rbAppendNothing.Checked = True
        lblCrcStatus.Text = ""
        rbHex.Checked = True
    End Sub

    Private Sub processReceivedData(ByVal b() As Byte)
        Dim s As String = ""
        For Each dataByte As Byte In b
            If (rbHex.Checked) Then
                s += dataByte.ToString("X2") + " "
            Else
                s += CType(ChrW(dataByte), Char)
            End If
        Next
        SetResponseText(s)
    End Sub


    Private Sub SetResponseText(text As String)
        'http://www.vbforums.com/showthread.php?498387-Accessing-Controls-from-Worker-Threads
        'https://msdn.microsoft.com/en-us/library/a1hetckb(v=vs.110).aspx
        If Me.txtRtuResponse.InvokeRequired Then
            Me.txtRtuResponse.Invoke(New SetTextBoxTextInvoker(AddressOf SetResponseText), New Object() {text})
        Else
            Me.txtRtuResponse.Text() += text
        End If
    End Sub

    Private Sub SetResponseTextColor(color As Color)
        'http://www.vbforums.com/showthread.php?498387-Accessing-Controls-from-Worker-Threads
        'https://msdn.microsoft.com/en-us/library/a1hetckb(v=vs.110).aspx
        If Me.txtRtuResponse.InvokeRequired Then
            Me.txtRtuResponse.Invoke(New SetTextBoxTextColorInvoker(AddressOf SetResponseTextColor), New Object() {color})
        Else
            Me.txtRtuResponse.ForeColor = color
        End If
    End Sub

    Private Sub SetCrcStatusText(text As String)
        'http://www.vbforums.com/showthread.php?498387-Accessing-Controls-from-Worker-Threads
        'https://msdn.microsoft.com/en-us/library/a1hetckb(v=vs.110).aspx
        If Me.lblCrcStatus.InvokeRequired Then
            Me.lblCrcStatus.Invoke(New SetTextBoxTextInvoker(AddressOf SetCrcStatusText), New Object() {text})
        Else
            Me.lblCrcStatus.Text() = text
        End If
    End Sub

    Private Sub SetCrcStatusTextColor(color As Color)
        'http://www.vbforums.com/showthread.php?498387-Accessing-Controls-from-Worker-Threads
        'https://msdn.microsoft.com/en-us/library/a1hetckb(v=vs.110).aspx
        If Me.lblCrcStatus.InvokeRequired Then
            Me.lblCrcStatus.Invoke(New SetTextBoxTextColorInvoker(AddressOf SetCrcStatusTextColor), New Object() {color})
        Else
            Me.lblCrcStatus.ForeColor = color
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub


    Private Sub btnComputeCrc_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComputeCrc.Click
        Dim I As Integer = 0
        Dim byteData() As Byte
        Dim Tokens() As String
        Try
            If txtDataField.Text.Length = 0 Then
                MsgBox("Please enter space separated hex characters")
            Else
                Tokens = Split(Trim(txtDataField.Text), " ")
                ReDim byteData(Tokens.Length - 1)
                Debug.Print("ByteData Array Length = " & byteData.Length)
                Debug.Print("Token Length = " & Tokens.Length)
                For Each token As String In Tokens
                    byteData(I) = Convert.ToByte(token, 16)
                    I += 1
                Next
                Dim hexCrc As String = objCrcCalculator.crcModbusCalculator(byteData, byteData.Length).ToString("X4")
                txtModbusCRCResult.Text = hexCrc
                txtModbusCRCReversedResult.Text = Microsoft.VisualBasic.Right(hexCrc, 2) & Microsoft.VisualBasic.Left(hexCrc, 2)

                'mCalcCRC16
                hexCrc = objCrcCalculator.crc16Calculator(byteData, byteData.Length).ToString("X4")
                txtCRC16Result.Text = hexCrc
                txtCRC16ReversedResult.Text = Microsoft.VisualBasic.Right(hexCrc, 2) & Microsoft.VisualBasic.Left(hexCrc, 2)
            End If
        Catch ex As Exception
            MsgBox("Could not convert one or more entered values to a valid byte.")
        End Try
    End Sub

    Private Sub btnSendToRtu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendToRtu.Click
        Dim I As Integer = 0
        Dim byteData() As Byte = Nothing
        Dim Tokens() As String = Nothing
        Dim rxList As New List(Of Byte)()

        txtRtuResponse.Text = ""
        txtRtuResponse.ForeColor = Color.Black
        lblCrcStatus.Text = ""
        Me.responseMessage = Nothing

        Try
            If txtCommand.Text.Length = 0 Then
                Throw New ArgumentException("Please enter space separated hex characters")
            Else
                Tokens = Split(Trim(txtCommand.Text), " ")
                ReDim byteData(Tokens.Length - 1) 'Zero-based
                Debug.Print("ByteData Array Length = " & byteData.Length)
                Debug.Print("Token Length = " & Tokens.Length)
                For Each token As String In Tokens
                    byteData(I) = Convert.ToByte(token, 16)
                    I += 1
                Next
                If (rbAppendModbus.Checked = True Or rbAppendCRC16.Checked = True) Then
                    Dim hexCrc As String
                    ReDim Preserve byteData(Tokens.Length + 1) 'Zero-based - add one for two bytes of CRC
                    If (rbAppendModbus.Checked = True) Then
                        hexCrc = Microsoft.VisualBasic.Right("0000" & Hex(objCrcCalculator.crcModbusCalculator(byteData, byteData.Length - 2)), 4I)
                    Else    'rbAppendCRC16.Checked = True
                        If (byteData(0) <> 2) Then Throw New ArgumentException("The first string of a FLAR message must be STX (2)")
                        If (I < 2) Then Throw New ArgumentException("A FLAR message must contain at least two elements")
                        Dim flarBytes As Byte() = Array.CreateInstance(GetType(System.Byte), I - 1)
                        Array.Copy(byteData, byteData.GetLowerBound(0) + 1, flarBytes, flarBytes.GetLowerBound(0), I - 1)
                        hexCrc = Microsoft.VisualBasic.Right("0000" & Hex(objCrcCalculator.crc16Calculator(flarBytes, flarBytes.Length)), 4I)
                    End If
                    byteData(I) = Convert.ToByte(Microsoft.VisualBasic.Right(hexCrc, 2), 16)
                    I += 1
                    byteData(I) = Convert.ToByte(Microsoft.VisualBasic.Left(hexCrc, 2), 16)
                Else
                    'Send without CRC
                End If
            End If
            'Me.Cursor = Cursors.WaitCursor
            Try
                _stream.Write(byteData, 0, byteData.Length)
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                'Me.Cursor = Cursors.Default
            End Try
        Catch ex As ArgumentException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox("Could not convert one or more entered values to a valid byte.")
        End Try

    End Sub

    Private Sub processResponse(ByVal newBytes() As Byte)
        Dim crcValue As Integer = 1
        Debug.Print("processResponse Thread: " + Threading.Thread.CurrentThread.ManagedThreadId.ToString())
        Dim StartIndex As Integer = 0
        SyncLock thisLock
            If (Me.responseMessage Is Nothing) Then
                Me.responseMessage = New Byte(newBytes.Length - 1) {}
            Else
                StartIndex = Me.responseMessage.Length
                ReDim Preserve Me.responseMessage(newBytes.Length + Me.responseMessage.Length - 1)
            End If
            Dim Count As Integer = newBytes.Length
            System.Array.Copy(newBytes, 0, Me.responseMessage, StartIndex, Count)
            If (rbAppendModbus.Checked = True Or rbAppendCRC16.Checked = True) Then
                If (rbAppendModbus.Checked = True) Then
                    crcValue = objCrcCalculator.crcModbusCalculator(Me.responseMessage, Me.responseMessage.Count)
                Else
                    If (newBytes.Count > 2) Then 'Don't bother to compute FLARE CRC until 3 bytes have been received
                        Dim flarRxBytes As Byte() = Array.CreateInstance(GetType(System.Byte), newBytes.Count - 1)
                        Array.Copy(newBytes, Me.responseMessage.GetLowerBound(0) + 1, flarRxBytes, flarRxBytes.GetLowerBound(0), flarRxBytes.Count)
                        crcValue = objCrcCalculator.crc16Calculator(flarRxBytes, flarRxBytes.Count)
                    End If
                End If

                If crcValue = 0 Then

                    SetResponseTextColor(Color.Green)
                    SetCrcStatusText("Valid CRC")
                    SetCrcStatusTextColor(Color.Green)
                Else
                    SetResponseTextColor(Color.Red)
                    SetCrcStatusText("Invalid CRC")
                    SetCrcStatusTextColor(Color.Red)
                End If
            End If
        End SyncLock
    End Sub



    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtRtuResponse.Text = ""
        txtRtuResponse.ForeColor = Color.Black
        lblCrcStatus.Text = ""
    End Sub

    Private Sub frmDebugUtility_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        tmrRead.Enabled = False
        clsCommObjFactory.GetInstance.GetTransportObject.CloseConnection()
    End Sub

    Private Sub frmDebugUtility_Load(sender As Object, e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub grpSerialDebugger_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpSerialDebugger.Enter

    End Sub

    Private Sub btnComputeCRC16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim I As Integer = 0
        Dim byteData() As Byte
        Dim Tokens() As String
        Try
            If txtDataField.Text.Length = 0 Then
                MsgBox("Please enter space separated hex characters")
            Else
                Tokens = Split(Trim(txtDataField.Text), " ")
                ReDim byteData(Tokens.Length - 1)
                Debug.Print("ByteData Array Length = " & byteData.Length)
                Debug.Print("Token Length = " & Tokens.Length)
                For Each token As String In Tokens
                    byteData(I) = Convert.ToByte(token, 16)
                    I += 1
                Next
                Dim hexCrc As String = Microsoft.VisualBasic.Right("0000" & Hex(objCrcCalculator.crc16Calculator(byteData, byteData.Length)), 4I)
                txtModbusCRCResult.Text = hexCrc
                txtModbusCRCReversedResult.Text = Microsoft.VisualBasic.Right(hexCrc, 2) & Microsoft.VisualBasic.Left(hexCrc, 2)
            End If
        Catch ex As Exception
            MsgBox("Could not convert one or more entered values to a valid byte.")
        End Try
    End Sub

    Private Sub frmDebugUtility_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Dim f = New frmTransportOptions()
        f.ShowDialog()
        Debug.Print("processResponse Thread: " + Threading.Thread.CurrentThread.ManagedThreadId.ToString())
        AddHandler DataReceivedEvent, AddressOf processReceivedData
        AddHandler DataReceivedEvent, AddressOf processResponse
        'RemoveHandler
        clsCommObjFactory.GetInstance.GetTransportObject.OpenConnection()
        _stream = clsCommObjFactory.GetInstance.GetTransportObject.GetBaseStream()
        kickoffRead()
    End Sub
End Class

