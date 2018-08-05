Imports System.IO.Ports
Imports System.IO

Public Class clsCommObjFactory
    Private objRS232Comm As New clsRS232Comm
    Private objAsyncComm As New clsAsyncComm
    Private objDemoMode As New clsDemoComm
    Private objEthernetComm As New clsEthernetComm
    Private Test As Boolean = False
    Private Shared Instance As clsCommObjFactory
    Private Shared blCreated As Boolean
    Private Const MODBUS_TCP As Integer = 0
    Private Const MODBUS_RTU_TERM_SERVER As Integer = 1
    Private Const MODBUS_RTU_COM_PORT_ACCESS As Integer = 2
    Private Const MODBUS_ASCII_TERM_SERVER As Integer = 3
    Private Const MODUBS_ASCII_COM_PORT_ACCESS = 4
    Private Const DEMO As Integer = 5
    Private strCommPort As String = My.Settings.ComPort
    Private intBaudRate As Integer = My.Settings.BaudRate
    Private strIpAddress As String = My.Settings.IpAddress
    Private intIpPort As Integer = My.Settings.IpPort
    Private blnSerialOrSocket As Boolean = My.Settings.SerialOrSocket

    Private Sub New()
        'Singleton Pattern so don't allow public access to constructor
    End Sub

    Public Shared Function GetInstance() As clsCommObjFactory
        If Instance Is Nothing Then
            Instance = New clsCommObjFactory
            'Instance.strCommPort = GetSetting(My.Application.Info.Title, "SerialPort", "CommPort", "COM1")
            Return Instance
        Else
            Return Instance
        End If
    End Function

    Enum Timeout As Integer
        T100ms
        T300mS
        T1S
        T3S
        T10S
    End Enum

    Public Sub FillCommPortCombo(ByVal cboComPort As ComboBox)
        Dim selectedIndex As Integer
        cboComPort.Items.Clear()
        For Each portName As String In objRS232Comm.ReturnAllPortNames
            cboComPort.Items.Add(portName)
        Next portName

        'Had to separate this because ReturnAllPortNames does not return a sorted list
        'and if the sort property is set to true for the combo box then 
        'the item must be selected after the control is populated.
        For index As Integer = 0 To cboComPort.Items.Count - 1
            Dim s As String = cboComPort.Items(index).ToString
            If cboComPort.Items(index).ToString = Me.strCommPort Then selectedIndex = index
        Next

        If (selectedIndex = -1 And cboComPort.Items.Count <> 0) Then
            cboComPort.SelectedIndex = 0
        Else
            cboComPort.SelectedIndex = selectedIndex
        End If
    End Sub

    Public Sub SetCommPortComboChoice(ByVal cboBox As ComboBox)
        If cboBox.SelectedIndex <> -1 Then
            Instance.strCommPort = cboBox.SelectedItem.ToString
        Else
            Throw New Exception("Item not selected in combo box.")
        End If
    End Sub

    Public Sub FillCommChoiceCombo(ByVal cboBox As ComboBox, ByVal InitialValue As Integer)
        cboBox.Items.Clear()
        cboBox.Items.Add(New clsMylist("Modbus TCP RTU", MODBUS_TCP))
        cboBox.SelectedIndex = 0                                        'Default
        cboBox.Items.Add(New clsMylist("Modbus RTU Terminal Server", MODBUS_RTU_TERM_SERVER))
        If MODBUS_RTU_TERM_SERVER = InitialValue Then cboBox.SelectedIndex = 1
        cboBox.Items.Add(New clsMylist("Modbus RTU Serial Port", MODBUS_RTU_COM_PORT_ACCESS))
        If MODBUS_RTU_COM_PORT_ACCESS = InitialValue Then cboBox.SelectedIndex = 2
        cboBox.Items.Add(New clsMylist("Modbus Ascii Terminal Server", MODBUS_ASCII_TERM_SERVER))
        If MODBUS_ASCII_TERM_SERVER = InitialValue Then cboBox.SelectedIndex = 3
        cboBox.Items.Add(New clsMylist("Modbus Ascii Serial Port", MODUBS_ASCII_COM_PORT_ACCESS))
        If MODUBS_ASCII_COM_PORT_ACCESS = InitialValue Then cboBox.SelectedIndex = 4
        cboBox.Items.Add(New clsMylist("Demo Mode", DEMO))
        If DEMO = InitialValue Then cboBox.SelectedIndex = 5
    End Sub

    Public Function GetCommChoiceValue(ByVal cboBox As System.Windows.Forms.ComboBox) As Integer
        Dim objMyList As clsMylist
        If cboBox.SelectedIndex <> -1 Then
            objMyList = cboBox.Items(cboBox.SelectedIndex)
            Return objMyList.ItemData
        Else
            Throw New Exception("Item not selected in combo box.")
        End If
    End Function

    Function GetRs232CommObject() As clsRS232Comm
        objRS232Comm.setCommPort(Instance.strCommPort)
        Return objRS232Comm
    End Function

    Public Function GetTransportObject() As ICommunications
        If (blnSerialOrSocket) Then
            objRS232Comm.setCommPort(strCommPort)
            objRS232Comm.setBaudRate(intBaudRate)
            Return objRS232Comm
        Else
            objAsyncComm.setIpAddress(strIpAddress)
            objAsyncComm.setPort(intIpPort)
            Return (objAsyncComm)
        End If
    End Function

    Function GetModbusMessageHandler(ByVal _objRtu As clsAdoRtus) As IModbusFunctionCalls
        Select Case _objRtu.intCommMode
            Case MODBUS_TCP
                objEthernetComm.setIpAddress(_objRtu.strIpAddress)
                Return New clsModbusEthernetMessageHandler(objEthernetComm, _objRtu)
            Case MODBUS_RTU_TERM_SERVER
                objAsyncComm.setIpAddress(_objRtu.strIpAddress)
                objAsyncComm.setPort(_objRtu.intIpPort)
                objAsyncComm.setBaudRate(_objRtu.intBaudRate)
                Return New clsModbusSerialMessageHandler(objAsyncComm, New clsModbusRtuDelegate, _objRtu)
            Case MODBUS_RTU_COM_PORT_ACCESS
                'objRS232Comm.setBaudRate(intBaudRate)
                objRS232Comm.setBaudRate(_objRtu.intBaudRate)
                objRS232Comm.setCommPort(strCommPort)
                Return New clsModbusSerialMessageHandler(objRS232Comm, New clsModbusRtuDelegate, _objRtu)
            Case MODBUS_ASCII_TERM_SERVER
                objAsyncComm.setIpAddress(_objRtu.strIpAddress)
                objAsyncComm.setPort(_objRtu.intIpPort)
                objAsyncComm.setBaudRate(_objRtu.intBaudRate)
                Return New clsModbusSerialMessageHandler(objAsyncComm, New clsModbusAsciiDelegate, _objRtu)
            Case MODUBS_ASCII_COM_PORT_ACCESS
                'objRS232Comm.setBaudRate(intBaudRate)
                objRS232Comm.setBaudRate(_objRtu.intBaudRate)
                objRS232Comm.setCommPort(strCommPort)
                Return New clsModbusSerialMessageHandler(objRS232Comm, New clsModbusAsciiDelegate, _objRtu)
            Case DEMO
                Return New clsModbusSerialMessageHandler(objDemoMode, New clsModbusAsciiDelegate, _objRtu)
            Case Else
                MsgBox("CommType not found.  This is CommObjFactory.", MsgBoxStyle.Critical)
                Return Nothing
        End Select
    End Function

    Public Function GetSerialPortNames() As String()
        Return objRS232Comm.ReturnAllPortNames()
    End Function

    Public Sub SaveApplicationSettings()
        My.Settings.ComPort = strCommPort
        My.Settings.BaudRate = intBaudRate
        My.Settings.IpAddress = strIpAddress
        My.Settings.IpPort = intIpPort
        My.Settings.SerialOrSocket = blnSerialOrSocket
        My.Settings.Save()
    End Sub


    Public Property ComPort() As String
        Get
            Return strCommPort
        End Get
        Set(ByVal value As String)
            strCommPort = value
        End Set
    End Property

    Public Property BaudRate() As String
        Get
            Return intBaudRate
        End Get
        Set(ByVal value As String)
            intBaudRate = value
        End Set
    End Property

    Public Property IpAddress() As String
        Get
            Return strIpAddress
        End Get
        Set(ByVal value As String)
            strIpAddress = value
        End Set
    End Property

    Public Property IpPort() As Integer
        Get
            Return intIpPort
        End Get
        Set(ByVal value As Integer)
            intIpPort = value
        End Set
    End Property


    Public Property SerialOrSocket As Boolean
        Get
            Return blnSerialOrSocket
        End Get
        Set(ByVal value As Boolean)
            blnSerialOrSocket = value
        End Set
    End Property

End Class
