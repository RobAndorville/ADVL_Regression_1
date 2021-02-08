'==============================================================================================================================================================================================
'
'Copyright 2016 Signalworks Pty Ltd, ABN 26 066 681 598

'Licensed under the Apache License, Version 2.0 (the "License");
'you may not use this file except in compliance with the License.
'You may obtain a copy of the License at
'
'http://www.apache.org/licenses/LICENSE-2.0
'
'Unless required by applicable law or agreed to in writing, software
'distributed under the License is distributed on an "AS IS" BASIS,
''WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
'See the License for the specific language governing permissions and
'limitations under the License.
'
'----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Imports System.ComponentModel
Imports System.Security.Permissions
<PermissionSet(SecurityAction.Demand, Name:="FullTrust")>
<System.Runtime.InteropServices.ComVisibleAttribute(True)>
Public Class Main
    'The ADVL_Regression application finds the best fit equations of lines to match a set of points..
    '


#Region " Coding Notes - Notes on the code used in this class." '==============================================================================================================================

    'ADD THE SYSTEM UTILITIES REFERENCE: ==========================================================================================
    'The following references are required by this software: 
    'ADVL_Utilities_Library_1.dll
    'To add the reference, press Project \ Add Reference... 
    '  Select the Browse option then press the Browse button
    '  Find the ADVL_Utilities_Library_1.dll file (it should be located in the directory ...\Projects\ADVL_Utilities_Library_1\ADVL_Utilities_Library_1\bin\Debug\)
    '  Press the Add button. Press the OK button.
    'The Utilities Library is used for Project Management, Archive file management, running XSequence files and running XMessage files.
    'If there are problems with a reference, try deleting it from the references list and adding it again.

    'ADD THE SERVICE REFERENCE: ===================================================================================================
    'A service reference to the Message Service must be added to the source code before this service can be used.
    'This is used to connect to the Application Network.

    'Adding the service reference to a project that includes the Message Service project: -----------------------------------------
    'Project \ Add Service Reference
    'Press the Discover button.
    'Expand the items in the Services window and select IMsgService.
    'Press OK.
    '------------------------------------------------------------------------------------------------------------------------------
    '------------------------------------------------------------------------------------------------------------------------------
    'Adding the service reference to other projects that dont include the Message Service project: -------------------------------
    'Run the ADVL_Network_1 application to start the message service.
    'In Microsoft Visual Studio select: Project \ Add Service Reference
    'Enter the address: http://localhost:8734/ADVLService
    'Press the Go button.
    'MsgService is found.
    'Press OK to add ServiceReference1 to the project.
    '------------------------------------------------------------------------------------------------------------------------------
    '
    'ADD THE MsgServiceCallback CODE: =============================================================================================
    'This is used to connect to the Application Network.
    'In Microsoft Visual Studio select: Project \ Add Class
    'MsgServiceCallback.vb
    'Add the following code to the class:
    'Imports System.ServiceModel
    'Public Class MsgServiceCallback
    '    Implements ServiceReference1.IMsgServiceCallback
    '    Public Sub OnSendMessage(message As String) Implements ServiceReference1.IMsgServiceCallback.OnSendMessage
    '        'A message has been received.
    '        'Set the InstrReceived property value to the message (usually in XMessage format). This will also apply the instructions in the XMessage.
    '        Main.InstrReceived = message
    '    End Sub
    'End Class
    '------------------------------------------------------------------------------------------------------------------------------
    '
    'DEBUGGING TIPS:
    '1. If an application based on the Application Template does not initially run correctly,
    '    check that the copied methods, such as Main_Load, have the correct Handles statement.
    '    For example: the Main_Load method should have the following declaration: Private Sub Main_Load(sender As Object, e As EventArgs) Handles Me.Load
    '      It will not run when the application loads, with this declaration:      Private Sub Main_Load(sender As Object, e As EventArgs)
    '    For example: the Main_FormClosing method should have the following declaration: Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    '      It will not run when the application closes, with this declaration:     Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs)
    '------------------------------------------------------------------------------------------------------------------------------
    '
    'ADD THE Timer1 Control to the Main Form: =====================================================================================
    'Select the Main.vb [Design] tab.
    'Press Toolbox \ Components \ Timer and add Timer1 to the Main form.
    '------------------------------------------------------------------------------------------------------------------------------
    '
    'EDIT THE DefaultAppProperties() CODE: ========================================================================================
    'This sets the Application properties that are stored in the Application_Info_ADVL_2.xml settings file.
    'The following properties need to be updated:
    '  ApplicationInfo.Name
    '  ApplicationInfo.Description
    '  ApplicationInfo.CreationDate
    '  ApplicationInfo.Author
    '  ApplicationInfo.Copyright
    '  ApplicationInfo.Trademarks
    '  ApplicationInfo.License
    '  ApplicationInfo.SourceCode          (Optional - Preliminary implemetation coded.)
    '  ApplicationInfo.ModificationSummary (Optional - Preliminary implemetation coded.)
    '  ApplicationInfo.Libraries           (Optional - Preliminary implemetation coded.)
    '------------------------------------------------------------------------------------------------------------------------------
    '
    'ADD THE Application Icon: ====================================================================================================
    'Double-click My Project in the Solution Explorer window to open the project tab.
    'In the Application section press the Icon box and selct Browse.
    'Select an application icon.
    'This icon can also be selected for the Main form icon by editing the properties of this form.
    '------------------------------------------------------------------------------------------------------------------------------
    '
    'EDIT THE Application Info Text: ==============================================================================================
    'The Application Info Text is used to label the appllication icon in the Application Network tree view.
    'This is edited in the SendApplicationInfo() method of the Main form.
    'Edit the line of code: Dim text As New XElement("Text", "Application Template").
    'Replace the default text "Application Template" with the required text.
    'Note that this text can be updated at any time and when the updated executable is run, it will update the Application Network tree view the next time it is connected.
    '------------------------------------------------------------------------------------------------------------------------------
    '
    'Calling JavaScript from VB.NET:
    'The following Imports statement and permissions are required for the Main form:
    'Imports System.Security.Permissions
    '<PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
    '<System.Runtime.InteropServices.ComVisibleAttribute(True)> _
    'NOTE: the line continuation characters (_) will disappear form the code view after they have been typed!
    '------------------------------------------------------------------------------------------------------------------------------
    'Calling VB.NET from JavaScript
    'Add the following line to the Main.Load method:
    '  Me.WebBrowser1.ObjectForScripting = Me
    '------------------------------------------------------------------------------------------------------------------------------
    '
    'Adding a Context Menu Strip:
    'In Visual Studio select the tab Main.vb [Design]
    'Select Toolbox \ Menus & Toolbars \ ContectMenuStrip and add it to the form. ContectMenuStrip1 appears in the panel below the form.
    'Right-click ContextMenuStrip1 and select Edit Items...
    'Press Add to add a new menu item
    '  Add item: Name: ToolStripMenuItem1_EditWorkflowTabPage         Text: Edit Workflow Tab Page
    '  Add item: Name: ToolStripMenuItem1_ShowStartPageInWorkflowTab  Text: Show Start Page In Workflow Tab
    'Select the Workflows button on the main form and select ContectMenuStrip property = ContextMenuStrip1
    '------------------------------------------------------------------------------------------------------------------------------
    '
    'Edit the AppInfoHtmlString function to display the appropriate information about the application.
    '------------------------------------------------------------------------------------------------------------------------------
    '
    'The ADVL_Network_1 application should be running the first time the new application is run.
    'The Network application will automatically send its executable file location to the new application.
    'This will allow the new application to start the Network when required.
    '------------------------------------------------------------------------------------------------------------------------------
    '
    'Other code edits:
    '  Main.Load - Message.AddText("------------------- Starting Application: ADVL Application Template ----------------- " & vbCrLf, "Heading")
    '  Private Sub SendApplicationInfo() - Dim text As New XElement("Text", "Application Template")
    '------------------------------------------------------------------------------------------------------------------------------
    '

#End Region 'Coding Notes ---------------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Variable Declarations - All the variables and class objects used in this form and this application." '===============================================================================

    Public WithEvents ApplicationInfo As New ADVL_Utilities_Library_1.ApplicationInfo 'This object is used to store application information.
    Public WithEvents Project As New ADVL_Utilities_Library_1.Project 'This object is used to store Project information.
    Public WithEvents Message As New ADVL_Utilities_Library_1.Message 'This object is used to display messages in the Messages window.
    Public WithEvents ApplicationUsage As New ADVL_Utilities_Library_1.Usage 'This object stores application usage information.

    'Declare Forms used by the application:
    Public WithEvents LinRegrForm As frmLinearRegr
    Public WithEvents NonLinRegrForm As frmNonLinRegr
    Public WithEvents WebPageList As frmWebPageList
    Public WithEvents ReadDatabase As frmReadDatabase

    Public WithEvents NewHtmlDisplay As frmHtmlDisplay
    Public HtmlDisplayFormList As New ArrayList 'Used for displaying multiple HtmlDisplay forms.

    Public WithEvents NewWebPage As frmWebPage
    Public WebPageFormList As New ArrayList 'Used for displaying multiple WebView forms.

    'Declare objects used to connect to the Message Service:
    Public client As ServiceReference1.MsgServiceClient
    Public WithEvents XMsg As New ADVL_Utilities_Library_1.XMessage
    Dim XDoc As New System.Xml.XmlDocument
    Public Status As New System.Collections.Specialized.StringCollection
    Dim ClientProNetName As String = "" 'The name of the client Project Network requesting service. 
    Dim ClientAppName As String = "" 'The name of the client requesting service
    Dim ClientConnName As String = "" 'The name of the client connection requesting service
    Dim MessageXDoc As System.Xml.Linq.XDocument
    Dim xmessage As XElement 'This will contain the message. It will be added to MessageXDoc.
    Dim xlocns As New List(Of XElement) 'A list of locations. Each location forms part of the reply message. The information in the reply message will be sent to the specified location in the client application.
    Dim MessageText As String = "" 'The text of a message sent through the Application Network.

    Public OnCompletionInstruction As String = "Stop" 'The last instruction returned on completion of the processing of an XMessage.
    Public EndInstruction As String = "Stop" 'Another method of specifying the last instruction. This is processed in the EndOfSequence section of XMsg.Instructions.

    Public ConnectionName As String = "" 'The name of the connection used to connect this application to the ComNet (Message Service).

    Public ProNetName As String = "" 'The name of the Project Network
    Public ProNetPath As String = "" 'The path of the Project Network

    Public AdvlNetworkAppPath As String = "" 'The application path of the ADVL Network application (ComNet). This is where the "Application.Lock" file will be while ComNet is running
    Public AdvlNetworkExePath As String = "" 'The executable path of the ADVL Network.


    'Variable for local processing of an XMessage:
    Public WithEvents XMsgLocal As New ADVL_Utilities_Library_1.XMessage
    Dim XDocLocal As New System.Xml.XmlDocument
    Public StatusLocal As New System.Collections.Specialized.StringCollection

    'Main.Load variables:
    Dim ProjectSelected As Boolean = False 'If True, a project has been selected using Command Arguments. Used in Main.Load.
    Dim StartupConnectionName As String = "" 'If not "" the application will be connected to the ComNet using this connection name in  Main.Load.

    'The following variables are used to run JavaScript in Web Pages loaded into the Document View: -------------------
    Public WithEvents XSeq As New ADVL_Utilities_Library_1.XSequence
    'To run an XSequence:
    '  XSeq.RunXSequence(xDoc, Status) 'ImportStatus in Import
    '    Handle events:
    '      XSeq.ErrorMsg
    '      XSeq.Instruction(Info, Locn)

    Private XStatus As New System.Collections.Specialized.StringCollection

    'Variables used to restore Item values on a web page.
    Private FormName As String
    Private ItemName As String
    Private SelectId As String

    'StartProject variables:
    Private StartProject_AppName As String  'The application name
    Private StartProject_ConnName As String 'The connection name
    Private StartProject_ProjID As String   'The project ID

    Private WithEvents bgwComCheck As New System.ComponentModel.BackgroundWorker 'Used to perform communication checks on a separate thread.

    Public WithEvents bgwSendMessage As New System.ComponentModel.BackgroundWorker 'Used to send a message through the Message Service.
    Dim SendMessageParams As New clsSendMessageParams 'This hold the Send Message parameters: .ProjectNetworkName, .ConnectionName & .Message

    'Regression Server objects:
    Dim WithEvents LinRegr As New clsLinRegr 'Linear Regression class.
    Dim WithEvents NonLinRegr As New clsNonLinRegr 'Non-Linear Regression class.

    'Alternative SendMessage background worker - needed to send a message while instructions are being processed.
    Public WithEvents bgwSendMessageAlt As New System.ComponentModel.BackgroundWorker 'Used to send a message through the Message Service - alternative backgound worker.
    Dim SendMessageParamsAlt As New clsSendMessageParams 'This hold the Send Message parameters: .ProjectNetworkName, .ConnectionName & .Message - for the alternative background worker.

#End Region 'Variable Declarations ------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Properties - All the properties used in this form and this application" '============================================================================================================

    Private _connectionHashcode As Integer 'The Message Service connection hashcode. This is used to identify a connection in the Message Service when reconnecting.
    Property ConnectionHashcode As Integer
        Get
            Return _connectionHashcode
        End Get
        Set(value As Integer)
            _connectionHashcode = value
        End Set
    End Property

    Private _connectedToComNet As Boolean = False  'True if the application is connected to the Communication Network (Message Service).
    Property ConnectedToComNet As Boolean
        Get
            Return _connectedToComNet
        End Get
        Set(value As Boolean)
            _connectedToComNet = value
        End Set
    End Property

    Private _instrReceived As String = "" 'Contains Instructions received via the Message Service.
    Property InstrReceived As String
        Get
            Return _instrReceived
        End Get
        Set(value As String)
            If value = Nothing Then
                Message.Add("Empty message received!")
            Else
                _instrReceived = value
                ProcessInstructions(_instrReceived)
            End If
        End Set
    End Property

    Private Sub ProcessInstructions(ByVal Instructions As String)
        'Process the XMessage instructions.

        Dim MsgType As String
        If Instructions.StartsWith("<XMsg>") Then
            MsgType = "XMsg"
            If ShowXMessages Then
                'Add the message header to the XMessages window:
                Message.XAddText("Message received: " & vbCrLf, "XmlReceivedNotice")
            End If
        ElseIf Instructions.StartsWith("<XSys>") Then
            MsgType = "XSys"
            If ShowSysMessages Then
                'Add the message header to the XMessages window:
                Message.XAddText("System Message received: " & vbCrLf, "XmlReceivedNotice")
            End If
        Else
            MsgType = "Unknown"
        End If

        'If ShowXMessages Then
        '    'Add the message header to the XMessages window:
        '    Message.XAddText("Message received: " & vbCrLf, "XmlReceivedNotice")
        'End If

        'If Instructions.StartsWith("<XMsg>") Then 'This is an XMessage set of instructions.
        If MsgType = "XMsg" Or MsgType = "XSys" Then 'This is an XMessage or XSystem set of instructions.
                Try
                    'Inititalise the reply message:
                    ClientProNetName = ""
                    ClientConnName = ""
                    ClientAppName = ""
                    xlocns.Clear() 'Clear the list of locations in the reply message. 
                    Dim Decl As New XDeclaration("1.0", "utf-8", "yes")
                    MessageXDoc = New XDocument(Decl, Nothing) 'Reply message - this will be sent to the Client App.
                'xmessage = New XElement("XMsg")
                xmessage = New XElement(MsgType)
                xlocns.Add(New XElement("Main")) 'Initially set the location in the Client App to Main.

                    'Run the received message:
                    Dim XmlHeader As String = "<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?>"
                    XDoc.LoadXml(XmlHeader & vbCrLf & Instructions.Replace("&", "&amp;")) 'Replace "&" with "&amp:" before loading the XML text.
                'If ShowXMessages Then
                '    Message.XAddXml(XDoc)  'Add the message to the XMessages window.
                '    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                'End If
                If (MsgType = "XMsg") And ShowXMessages Then
                    Message.XAddXml(XDoc)  'Add the message to the XMessages window.
                    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                ElseIf (MsgType = "XSys") And ShowSysMessages Then
                    Message.XAddXml(XDoc)  'Add the message to the XMessages window.
                    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                End If
                XMsg.Run(XDoc, Status)
                Catch ex As Exception
                    Message.Add("Error running XMsg: " & ex.Message & vbCrLf)
                End Try

                'XMessage has been run.
                'Reply to this message:
                'Add the message reply to the XMessages window:
                'Complete the MessageXDoc:
                xmessage.Add(xlocns(xlocns.Count - 1)) 'Add the last location reply instructions to the message.
                MessageXDoc.Add(xmessage)
                MessageText = MessageXDoc.ToString

                If ClientConnName = "" Then
                'No client to send a message to - process the message locally.
                'If ShowXMessages Then
                '    Message.XAddText("Message processed locally:" & vbCrLf, "XmlSentNotice")
                '    Message.XAddXml(MessageText)
                '    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                'End If
                If (MsgType = "XMsg") And ShowXMessages Then
                    Message.XAddText("Message processed locally:" & vbCrLf, "XmlSentNotice")
                    Message.XAddXml(MessageText)
                    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                ElseIf (MsgType = "XSys") And ShowSysMessages Then
                    Message.XAddText("System Message processed locally:" & vbCrLf, "XmlSentNotice")
                    Message.XAddXml(MessageText)
                    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                End If
                ProcessLocalInstructions(MessageText)
                Else
                'If ShowXMessages Then
                '    Message.XAddText("Message sent to [" & ClientProNetName & "]." & ClientConnName & ":" & vbCrLf, "XmlSentNotice")
                '    Message.XAddXml(MessageText)
                '    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                'End If
                If (MsgType = "XMsg") And ShowXMessages Then
                    Message.XAddText("Message sent to [" & ClientProNetName & "]." & ClientConnName & ":" & vbCrLf, "XmlSentNotice")   'NOTE: There is no SendMessage code in the Message Service application!
                    Message.XAddXml(MessageText)
                    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                ElseIf (MsgType = "XSys") And ShowSysMessages Then
                    Message.XAddText("System Message sent to [" & ClientProNetName & "]." & ClientConnName & ":" & vbCrLf, "XmlSentNotice")   'NOTE: There is no SendMessage code in the Message Service application!
                    Message.XAddXml(MessageText)
                    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                End If

                'Send Message on a new thread:
                SendMessageParams.ProjectNetworkName = ClientProNetName
                    SendMessageParams.ConnectionName = ClientConnName
                    SendMessageParams.Message = MessageText
                    If bgwSendMessage.IsBusy Then
                        Message.AddWarning("Send Message backgroundworker is busy." & vbCrLf)
                    Else
                        bgwSendMessage.RunWorkerAsync(SendMessageParams)
                    End If
                End If

            Else 'This is not an XMessage!
                If Instructions.StartsWith("<XMsgBlk>") Then 'This is an XMessageBlock.
                'Process the received message:
                Dim XmlHeader As String = "<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?>"
                XDoc.LoadXml(XmlHeader & vbCrLf & Instructions.Replace("&", "&amp;")) 'Replace "&" with "&amp:" before loading the XML text.
                If ShowXMessages Then
                    Message.XAddXml(XDoc)   'Add the message to the XMessages window.
                    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                End If

                'Process the XMessageBlock:
                Dim XMsgBlkLocn As String
                XMsgBlkLocn = XDoc.GetElementsByTagName("ClientLocn")(0).InnerText
                Select Case XMsgBlkLocn
                    Case "TestLocn" 'Replace this with the required location name.
                        Dim XInfo As Xml.XmlNodeList = XDoc.GetElementsByTagName("XInfo") 'Get the XInfo node list
                        Dim InfoXDoc As New Xml.Linq.XDocument 'Create an XDocument to hold the information contained in XInfo 
                        InfoXDoc = XDocument.Parse("<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?>" & vbCrLf & XInfo(0).InnerXml) 'Read the information into InfoXDoc
                        'Add processing instructions here - The information in the InfoXDoc is usually stored in an XDocument in the application or as an XML file in the project.

                    Case Else
                        Message.AddWarning("Unknown XInfo Message location: " & XMsgBlkLocn & vbCrLf)
                End Select
            Else
                Message.XAddText("The message is not an XMessage or XMessageBlock: " & vbCrLf & Instructions & vbCrLf & vbCrLf, "Normal")
            End If
            'Message.XAddText("The message is not an XMessage: " & Instructions & vbCrLf, "Normal")
        End If
    End Sub

    Private Sub ProcessLocalInstructions(ByVal Instructions As String)
        'Process the XMessage instructions locally.

        'If Instructions.StartsWith("<XMsg>") Then 'This is an XMessage set of instructions.
        If Instructions.StartsWith("<XMsg>") Or Instructions.StartsWith("<XSys>") Then 'This is an XMessage set of instructions.
                'Run the received message:
                Dim XmlHeader As String = "<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?>"
                XDocLocal.LoadXml(XmlHeader & vbCrLf & Instructions)
                XMsgLocal.Run(XDocLocal, StatusLocal)
            Else 'This is not an XMessage!
                Message.XAddText("The message is not an XMessage: " & Instructions & vbCrLf, "Normal")
        End If
    End Sub

    Private _showXMessages As Boolean = True 'If True, XMessages that are sent or received will be shown in the Messages window.
    Property ShowXMessages As Boolean
        Get
            Return _showXMessages
        End Get
        Set(value As Boolean)
            _showXMessages = value
        End Set
    End Property

    Private _showSysMessages As Boolean = True 'If True, System messages that are sent or received will be shown in the messages window.
    Property ShowSysMessages As Boolean
        Get
            Return _showSysMessages
        End Get
        Set(value As Boolean)
            _showSysMessages = value
        End Set
    End Property


    Private _closedFormNo As Integer 'Temporarily holds the number of the form that is being closed. 
    Property ClosedFormNo As Integer
        Get
            Return _closedFormNo
        End Get
        Set(value As Integer)
            _closedFormNo = value
        End Set
    End Property

    Private _workflowFileName As String = "" 'The file name of the html document displayed in the Workflow tab.
    Public Property WorkflowFileName As String
        Get
            Return _workflowFileName
        End Get
        Set(value As String)
            _workflowFileName = value
        End Set
    End Property

#End Region 'Properties -----------------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Process XML Files - Read and write XML files." '=====================================================================================================================================

    Private Sub SaveFormSettings()
        'Save the form settings in an XML document.
        Dim settingsData = <?xml version="1.0" encoding="utf-8"?>
                           <!---->
                           <!--Form settings for Main form.-->
                           <FormSettings>
                               <Left><%= Me.Left %></Left>
                               <Top><%= Me.Top %></Top>
                               <Width><%= Me.Width %></Width>
                               <Height><%= Me.Height %></Height>
                               <AdvlNetworkAppPath><%= AdvlNetworkAppPath %></AdvlNetworkAppPath>
                               <AdvlNetworkExePath><%= AdvlNetworkExePath %></AdvlNetworkExePath>
                               <ShowXMessages><%= ShowXMessages %></ShowXMessages>
                               <ShowSysMessages><%= ShowSysMessages %></ShowSysMessages>
                               <!---->
                               <SelectedTabIndex><%= TabControl1.SelectedIndex %></SelectedTabIndex>
                           </FormSettings>

        '<MsgServiceAppPath><%= MsgServiceAppPath %></MsgServiceAppPath>
        '<MsgServiceExePath><%= MsgServiceExePath %></MsgServiceExePath>

        'Add code to include other settings to save after the comment line <!---->

        'Dim SettingsFileName As String = "FormSettings_" & ApplicationInfo.Name & "_" & Me.Text & ".xml"
        'Dim SettingsFileName As String = "FormSettings_" & ApplicationInfo.Name & "_Main.xml"
        Dim SettingsFileName As String = "FormSettings_" & ApplicationInfo.Name & " - Main.xml"
        Project.SaveXmlSettings(SettingsFileName, settingsData)
    End Sub

    Private Sub RestoreFormSettings()
        'Read the form settings from an XML document.

        'Dim SettingsFileName As String = "FormSettings_" & ApplicationInfo.Name & "_" & Me.Text & ".xml"
        'Dim SettingsFileName As String = "FormSettings_" & ApplicationInfo.Name & "_Main.xml"
        Dim SettingsFileName As String = "FormSettings_" & ApplicationInfo.Name & " - Main.xml"

        If Project.SettingsFileExists(SettingsFileName) Then
            Dim Settings As System.Xml.Linq.XDocument
            Project.ReadXmlSettings(SettingsFileName, Settings)

            If IsNothing(Settings) Then 'There is no Settings XML data.
                Exit Sub
            End If

            'Restore form position and size:
            If Settings.<FormSettings>.<Left>.Value <> Nothing Then Me.Left = Settings.<FormSettings>.<Left>.Value
            If Settings.<FormSettings>.<Top>.Value <> Nothing Then Me.Top = Settings.<FormSettings>.<Top>.Value
            If Settings.<FormSettings>.<Height>.Value <> Nothing Then Me.Height = Settings.<FormSettings>.<Height>.Value
            If Settings.<FormSettings>.<Width>.Value <> Nothing Then Me.Width = Settings.<FormSettings>.<Width>.Value

            'If Settings.<FormSettings>.<MsgServiceAppPath>.Value <> Nothing Then MsgServiceAppPath = Settings.<FormSettings>.<MsgServiceAppPath>.Value
            'If Settings.<FormSettings>.<MsgServiceExePath>.Value <> Nothing Then MsgServiceExePath = Settings.<FormSettings>.<MsgServiceExePath>.Value
            If Settings.<FormSettings>.<AdvlNetworkAppPath>.Value <> Nothing Then AdvlNetworkAppPath = Settings.<FormSettings>.<AdvlNetworkAppPath>.Value
            If Settings.<FormSettings>.<AdvlNetworkExePath>.Value <> Nothing Then AdvlNetworkExePath = Settings.<FormSettings>.<AdvlNetworkExePath>.Value

            If Settings.<FormSettings>.<ShowXMessages>.Value <> Nothing Then ShowXMessages = Settings.<FormSettings>.<ShowXMessages>.Value
            If Settings.<FormSettings>.<ShowSysMessages>.Value <> Nothing Then ShowSysMessages = Settings.<FormSettings>.<ShowSysMessages>.Value

            'Add code to read other saved setting here:
            If Settings.<FormSettings>.<SelectedTabIndex>.Value <> Nothing Then TabControl1.SelectedIndex = Settings.<FormSettings>.<SelectedTabIndex>.Value

            CheckFormPos()
        End If
    End Sub

    Private Sub CheckFormPos()
        'Check that the form can be seen on a screen.

        Dim MinWidthVisible As Integer = 192 'Minimum number of X pixels visible. The form will be moved if this many form pixels are not visible.
        Dim MinHeightVisible As Integer = 64 'Minimum number of Y pixels visible. The form will be moved if this many form pixels are not visible.

        Dim FormRect As New Rectangle(Me.Left, Me.Top, Me.Width, Me.Height)
        Dim WARect As Rectangle = Screen.GetWorkingArea(FormRect) 'The Working Area rectangle - the usable area of the screen containing the form.

        'NOTE: The top of the Working Are can be negative!
        ''Check if the top of the form is less than zero:
        'If Me.Top < 0 Then Me.Top = 0

        'Check if the top of the form is above the top of the Working Area:
        If Me.Top < WARect.Top Then
            Me.Top = WARect.Top
        End If

        'Check if the top of the form is too close to the bottom of the Working Area:
        If (Me.Top + MinHeightVisible) > (WARect.Top + WARect.Height) Then
            Me.Top = WARect.Top + WARect.Height - MinHeightVisible
        End If

        'Check if the left edge of the form is too close to the right edge of the Working Area:
        If (Me.Left + MinWidthVisible) > (WARect.Left + WARect.Width) Then
            Me.Left = WARect.Left + WARect.Width - MinWidthVisible
        End If

        'Check if the right edge of the form is too close to the left edge of the Working Area:
        If (Me.Left + Me.Width - MinWidthVisible) < WARect.Left Then
            Me.Left = WARect.Left - Me.Width + MinWidthVisible
        End If
    End Sub

    Private Sub ReadApplicationInfo()
        'Read the Application Information.

        If ApplicationInfo.FileExists Then
            ApplicationInfo.ReadFile()
        Else
            'There is no Application_Info_ADVL_2.xml file.
            DefaultAppProperties() 'Create a new Application Info file with default application properties:
            ApplicationInfo.WriteFile() 'Write the file now. The file information may be used by other applications.
        End If
    End Sub

    Private Sub DefaultAppProperties()
        'These properties will be saved in the Application_Info.xml file in the application directory.
        'If this file is deleted, it will be re-created using these default application properties.

        'Change this to show your application Name, Description and Creation Date.
        ApplicationInfo.Name = "ADVL_Regression_1"

        'ApplicationInfo.ApplicationDir is set when the application is started.
        ApplicationInfo.ExecutablePath = Application.ExecutablePath

        ApplicationInfo.Description = "This application implements several regression methods."
        ApplicationInfo.CreationDate = "14-Jul-2019 12:00:00"

        'Author -----------------------------------------------------------------------------------------------------------
        'Change this to show your Name, Description and Contact information.
        ApplicationInfo.Author.Name = "Signalworks Pty Ltd"
        ApplicationInfo.Author.Description = "Signalworks Pty Ltd" & vbCrLf &
            "Australian Proprietary Company" & vbCrLf &
            "ABN 26 066 681 598" & vbCrLf &
            "Registration Date 05/10/1994"

        ApplicationInfo.Author.Contact = "http://www.andorville.com.au/"

        'File Associations: -----------------------------------------------------------------------------------------------
        'Add any file associations here.
        'The file extension and a description of files that can be opened by this application are specified.
        'The example below specifies a coordinate system parameter file type with the file extension .ADVLCoord.
        'Dim Assn1 As New ADVL_System_Utilities.FileAssociation
        'Assn1.Extension = "ADVLCoord"
        'Assn1.Description = "Andorville™ software coordinate system parameter file"
        'ApplicationInfo.FileAssociations.Add(Assn1)

        'Version ----------------------------------------------------------------------------------------------------------
        ApplicationInfo.Version.Major = My.Application.Info.Version.Major
        ApplicationInfo.Version.Minor = My.Application.Info.Version.Minor
        ApplicationInfo.Version.Build = My.Application.Info.Version.Build
        ApplicationInfo.Version.Revision = My.Application.Info.Version.Revision

        'Copyright --------------------------------------------------------------------------------------------------------
        'Add your copyright information here.
        ApplicationInfo.Copyright.OwnerName = "Signalworks Pty Ltd, ABN 26 066 681 598"
        ApplicationInfo.Copyright.PublicationYear = "2016"

        'Trademarks -------------------------------------------------------------------------------------------------------
        'Add your trademark information here.
        Dim Trademark1 As New ADVL_Utilities_Library_1.Trademark
        Trademark1.OwnerName = "Signalworks Pty Ltd, ABN 26 066 681 598"
        Trademark1.Text = "Andorville"
        Trademark1.Registered = False
        Trademark1.GenericTerm = "software"
        ApplicationInfo.Trademarks.Add(Trademark1)
        Dim Trademark2 As New ADVL_Utilities_Library_1.Trademark
        Trademark2.OwnerName = "Signalworks Pty Ltd, ABN 26 066 681 598"
        Trademark2.Text = "AL-H7"
        Trademark2.Registered = False
        Trademark2.GenericTerm = "software"
        ApplicationInfo.Trademarks.Add(Trademark2)
        Dim Trademark3 As New ADVL_Utilities_Library_1.Trademark
        Trademark3.OwnerName = "Signalworks Pty Ltd, ABN 26 066 681 598"
        Trademark3.Text = "AL-M7"
        Trademark3.Registered = False
        Trademark3.GenericTerm = "software"
        ApplicationInfo.Trademarks.Add(Trademark3)

        'License -------------------------------------------------------------------------------------------------------
        'Add your license information here.
        ApplicationInfo.License.CopyrightOwnerName = "Signalworks Pty Ltd, ABN 26 066 681 598"
        ApplicationInfo.License.PublicationYear = "2016"

        'License Links:
        'http://choosealicense.com/
        'http://www.apache.org/licenses/
        'http://opensource.org/

        'Apache License 2.0 ---------------------------------------------
        ApplicationInfo.License.Code = ADVL_Utilities_Library_1.License.Codes.Apache_License_2_0
        ApplicationInfo.License.Notice = ApplicationInfo.License.ApacheLicenseNotice 'Get the pre-defined Aapche license notice.
        ApplicationInfo.License.Text = ApplicationInfo.License.ApacheLicenseText     'Get the pre-defined Apache license text.

        'Code to use other pre-defined license types is shown below:

        'GNU General Public License, version 3 --------------------------
        'ApplicationInfo.License.Type = ADVL_Utilities_Library_1.License.Types.GNU_GPL_V3_0
        'ApplicationInfo.License.Notice = 'Add the License Notice to ADVL_Utilities_Library_1 License class.
        'ApplicationInfo.License.Text = 'Add the License Text to ADVL_Utilities_Library_1 License class.

        'The MIT License ------------------------------------------------
        'ApplicationInfo.License.Type = ADVL_Utilities_Library_1.License.Types.MIT_License
        'ApplicationInfo.License.Notice = ApplicationInfo.License.MITLicenseNotice
        'ApplicationInfo.License.Text = ApplicationInfo.License.MITLicenseText

        'No License Specified -------------------------------------------
        'ApplicationInfo.License.Type = ADVL_Utilities_Library_1.License.Types.None
        'ApplicationInfo.License.Notice = ""
        'ApplicationInfo.License.Text = ""

        'The Unlicense --------------------------------------------------
        'ApplicationInfo.License.Type = ADVL_Utilities_Library_1.License.Types.The_Unlicense
        'ApplicationInfo.License.Notice = ApplicationInfo.License.UnLicenseNotice
        'ApplicationInfo.License.Text = ApplicationInfo.License.UnLicenseText

        'Unknown License ------------------------------------------------
        'ApplicationInfo.License.Type = ADVL_Utilities_Library_1.License.Types.Unknown
        'ApplicationInfo.License.Notice = ""
        'ApplicationInfo.License.Text = ""

        'Source Code: --------------------------------------------------------------------------------------------------
        'Add your source code information here if required.
        'THIS SECTION WILL BE UPDATED TO ALLOW A GITHUB LINK.
        ApplicationInfo.SourceCode.Language = "Visual Basic 2015"
        ApplicationInfo.SourceCode.FileName = ""
        ApplicationInfo.SourceCode.FileSize = 0
        ApplicationInfo.SourceCode.FileHash = ""
        ApplicationInfo.SourceCode.WebLink = ""
        ApplicationInfo.SourceCode.Contact = ""
        ApplicationInfo.SourceCode.Comments = ""

        'ModificationSummary: -----------------------------------------------------------------------------------------
        'Add any source code modification here is required.
        ApplicationInfo.ModificationSummary.BaseCodeName = ""
        ApplicationInfo.ModificationSummary.BaseCodeDescription = ""
        ApplicationInfo.ModificationSummary.BaseCodeVersion.Major = 0
        ApplicationInfo.ModificationSummary.BaseCodeVersion.Minor = 0
        ApplicationInfo.ModificationSummary.BaseCodeVersion.Build = 0
        ApplicationInfo.ModificationSummary.BaseCodeVersion.Revision = 0
        ApplicationInfo.ModificationSummary.Description = "This is the first released version of the application. No earlier base code used."

        'Library List: ------------------------------------------------------------------------------------------------
        'Add the ADVL_Utilties_Library_1 library:
        Dim NewLib As New ADVL_Utilities_Library_1.LibrarySummary
        NewLib.Name = "ADVL_System_Utilities"
        NewLib.Description = "System Utility classes used in Andorville™ software development system applications"
        NewLib.CreationDate = "7-Jan-2016 12:00:00"
        NewLib.LicenseNotice = "Copyright 2016 Signalworks Pty Ltd, ABN 26 066 681 598" & vbCrLf &
                               vbCrLf &
                               "Licensed under the Apache License, Version 2.0 (the ""License"");" & vbCrLf &
                               "you may not use this file except in compliance with the License." & vbCrLf &
                               "You may obtain a copy of the License at" & vbCrLf &
                               vbCrLf &
                               "http://www.apache.org/licenses/LICENSE-2.0" & vbCrLf &
                               vbCrLf &
                               "Unless required by applicable law or agreed to in writing, software" & vbCrLf &
                               "distributed under the License is distributed on an ""AS IS"" BASIS," & vbCrLf &
                               "WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied." & vbCrLf &
                               "See the License for the specific language governing permissions and" & vbCrLf &
                               "limitations under the License." & vbCrLf

        NewLib.CopyrightNotice = "Copyright 2016 Signalworks Pty Ltd, ABN 26 066 681 598"

        NewLib.Version.Major = 1
        NewLib.Version.Minor = 0
        NewLib.Version.Build = 1
        NewLib.Version.Revision = 0

        NewLib.Author.Name = "Signalworks Pty Ltd"
        NewLib.Author.Description = "Signalworks Pty Ltd" & vbCrLf &
            "Australian Proprietary Company" & vbCrLf &
            "ABN 26 066 681 598" & vbCrLf &
            "Registration Date 05/10/1994"

        NewLib.Author.Contact = "http://www.andorville.com.au/"

        Dim NewClass1 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass1.Name = "ZipComp"
        NewClass1.Description = "The ZipComp class is used to compress files into and extract files from a zip file."
        NewLib.Classes.Add(NewClass1)
        Dim NewClass2 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass2.Name = "XSequence"
        NewClass2.Description = "The XSequence class is used to run an XML property sequence (XSequence) file. XSequence files are used to record and replay processing sequences in Andorville™ software applications."
        NewLib.Classes.Add(NewClass2)
        Dim NewClass3 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass3.Name = "XMessage"
        NewClass3.Description = "The XMessage class is used to read an XML Message (XMessage). An XMessage is a simplified XSequence used to exchange information between Andorville™ software applications."
        NewLib.Classes.Add(NewClass3)
        Dim NewClass4 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass4.Name = "Location"
        NewClass4.Description = "The Location class consists of properties and methods to store data in a location, which is either a directory or archive file."
        NewLib.Classes.Add(NewClass4)
        Dim NewClass5 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass5.Name = "Project"
        NewClass5.Description = "An Andorville™ software application can store data within one or more projects. Each project stores a set of related data files. The Project class contains properties and methods used to manage a project."
        NewLib.Classes.Add(NewClass5)
        Dim NewClass6 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass6.Name = "ProjectSummary"
        NewClass6.Description = "ProjectSummary stores a summary of a project."
        NewLib.Classes.Add(NewClass6)
        Dim NewClass7 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass7.Name = "DataFileInfo"
        NewClass7.Description = "The DataFileInfo class stores information about a data file."
        NewLib.Classes.Add(NewClass7)
        Dim NewClass8 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass8.Name = "Message"
        NewClass8.Description = "The Message class contains text properties and methods used to display messages in an Andorville™ software application."
        NewLib.Classes.Add(NewClass8)
        Dim NewClass9 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass9.Name = "ApplicationSummary"
        NewClass9.Description = "The ApplicationSummary class stores a summary of an Andorville™ software application."
        NewLib.Classes.Add(NewClass9)
        Dim NewClass10 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass10.Name = "LibrarySummary"
        NewClass10.Description = "The LibrarySummary class stores a summary of a software library used by an application."
        NewLib.Classes.Add(NewClass10)
        Dim NewClass11 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass11.Name = "ClassSummary"
        NewClass11.Description = "The ClassSummary class stores a summary of a class contained in a software library."
        NewLib.Classes.Add(NewClass11)
        Dim NewClass12 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass12.Name = "ModificationSummary"
        NewClass12.Description = "The ModificationSummary class stores a summary of any modifications made to an application or library."
        NewLib.Classes.Add(NewClass12)
        Dim NewClass13 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass13.Name = "ApplicationInfo"
        NewClass13.Description = "The ApplicationInfo class stores information about an Andorville™ software application."
        NewLib.Classes.Add(NewClass13)
        Dim NewClass14 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass14.Name = "Version"
        NewClass14.Description = "The Version class stores application, library or project version information."
        NewLib.Classes.Add(NewClass14)
        Dim NewClass15 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass15.Name = "Author"
        NewClass15.Description = "The Author class stores information about an Author."
        NewLib.Classes.Add(NewClass15)
        Dim NewClass16 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass16.Name = "FileAssociation"
        NewClass16.Description = "The FileAssociation class stores the file association extension and description. An application can open files on its file association list."
        NewLib.Classes.Add(NewClass16)
        Dim NewClass17 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass17.Name = "Copyright"
        NewClass17.Description = "The Copyright class stores copyright information."
        NewLib.Classes.Add(NewClass17)
        Dim NewClass18 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass18.Name = "License"
        NewClass18.Description = "The License class stores license information."
        NewLib.Classes.Add(NewClass18)
        Dim NewClass19 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass19.Name = "SourceCode"
        NewClass19.Description = "The SourceCode class stores information about the source code for the application."
        NewLib.Classes.Add(NewClass19)
        Dim NewClass20 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass20.Name = "Usage"
        NewClass20.Description = "The Usage class stores information about application or project usage."
        NewLib.Classes.Add(NewClass20)
        Dim NewClass21 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass21.Name = "Trademark"
        NewClass21.Description = "The Trademark class stored information about a trademark used by the author of an application or data."
        NewLib.Classes.Add(NewClass21)

        ApplicationInfo.Libraries.Add(NewLib)

        'Add other library information here: --------------------------------------------------------------------------

    End Sub

    'Save the form settings if the form is being minimised:
    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = &H112 Then 'SysCommand
            If m.WParam.ToInt32 = &HF020 Then 'Form is being minimised
                SaveFormSettings()
            End If
        End If
        MyBase.WndProc(m)
    End Sub

    Private Sub SaveProjectSettings()
        'Save the project settings in an XML file.
        'Add any Project Settings to be saved into the settingsData XDocument.
        Dim settingsData = <?xml version="1.0" encoding="utf-8"?>
                           <!---->
                           <!--Project settings for ADVL_Coordinates_1 application.-->
                           <ProjectSettings>
                           </ProjectSettings>

        Dim SettingsFileName As String = "ProjectSettings_" & ApplicationInfo.Name & "_" & ".xml"
        Project.SaveXmlSettings(SettingsFileName, settingsData)
    End Sub

    Private Sub RestoreProjectSettings()
        'Restore the project settings from an XML document.

        Dim SettingsFileName As String = "ProjectSettings_" & ApplicationInfo.Name & "_" & ".xml"

        If Project.SettingsFileExists(SettingsFileName) Then
            Dim Settings As System.Xml.Linq.XDocument
            Project.ReadXmlSettings(SettingsFileName, Settings)

            If IsNothing(Settings) Then 'There is no Settings XML data.
                Exit Sub
            End If

            'Restore a Project Setting example:
            If Settings.<ProjectSettings>.<Setting1>.Value = Nothing Then
                'Project setting not saved.
                'Setting1 = ""
            Else
                'Setting1 = Settings.<ProjectSettings>.<Setting1>.Value
            End If

            'Continue restoring saved settings.

        End If

    End Sub

#End Region 'Process XML Files ----------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Display Methods - Code used to display this form." '============================================================================================================================

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Loading the Main form.

        'Set the Application Directory path: ------------------------------------------------
        Project.ApplicationDir = My.Application.Info.DirectoryPath.ToString

        'Read the Application Information file: ---------------------------------------------
        ApplicationInfo.ApplicationDir = My.Application.Info.DirectoryPath.ToString 'Set the Application Directory property
        'Get the Application Version Information:
        ApplicationInfo.Version.Major = My.Application.Info.Version.Major
        ApplicationInfo.Version.Minor = My.Application.Info.Version.Minor
        ApplicationInfo.Version.Build = My.Application.Info.Version.Build
        ApplicationInfo.Version.Revision = My.Application.Info.Version.Revision

        If ApplicationInfo.ApplicationLocked Then
            MessageBox.Show("The application is locked. If the application is not already in use, remove the 'Application_Info.lock file from the application directory: " & ApplicationInfo.ApplicationDir, "Notice", MessageBoxButtons.OK)
            Dim dr As System.Windows.Forms.DialogResult
            dr = MessageBox.Show("Press 'Yes' to unlock the application", "Notice", MessageBoxButtons.YesNo)
            If dr = System.Windows.Forms.DialogResult.Yes Then
                ApplicationInfo.UnlockApplication()
            Else
                Application.Exit()
                Exit Sub
            End If
        End If

        ReadApplicationInfo()

        'Read the Application Usage information: --------------------------------------------
        ApplicationUsage.StartTime = Now
        ApplicationUsage.SaveLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory
        ApplicationUsage.SaveLocn.Path = Project.ApplicationDir
        ApplicationUsage.RestoreUsageInfo()

        'Restore Project information: -------------------------------------------------------
        Project.Application.Name = ApplicationInfo.Name

        'Set up Message object:
        Message.ApplicationName = ApplicationInfo.Name

        'Set up a temporary initial settings location:
        Dim TempLocn As New ADVL_Utilities_Library_1.FileLocation
        TempLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory
        TempLocn.Path = ApplicationInfo.ApplicationDir
        Message.SettingsLocn = TempLocn

        Me.Show() 'Show this form before showing the Message form - This will show the App icon on top in the TaskBar.

        'Start showing messages here - Message system is set up.
        Message.AddText("------------------- Starting Application: ADVL Regression --------------------------- " & vbCrLf, "Heading")
        Message.AddText("Application usage: Total duration = " & Format(ApplicationUsage.TotalDuration.TotalHours, "#.##") & " hours" & vbCrLf, "Normal")

        'https://msdn.microsoft.com/en-us/library/z2d603cy(v=vs.80).aspx#Y550
        'Process any command line arguments:
        Try
            For Each s As String In My.Application.CommandLineArgs
                Message.Add("Command line argument: " & vbCrLf)
                Message.AddXml(s & vbCrLf & vbCrLf)
                InstrReceived = s
            Next
        Catch ex As Exception
            Message.AddWarning("Error processing command line arguments: " & ex.Message & vbCrLf)
        End Try

        If ProjectSelected = False Then
            'Read the Settings Location for the last project used:
            Project.ReadLastProjectInfo()
            'The Last_Project_Info.xml file contains:
            '  Project Name and Description. Settings Location Type and Settings Location Path.
            Message.Add("Last project details:" & vbCrLf)
            Message.Add("Project Type:  " & Project.Type.ToString & vbCrLf)
            Message.Add("Project Path:  " & Project.Path & vbCrLf)

            'At this point read the application start arguments, if any.
            'The selected project may be changed here.

            'Check if the project is locked:
            If Project.ProjectLocked Then
                Message.AddWarning("The project is locked: " & Project.Name & vbCrLf)
                Dim dr As System.Windows.Forms.DialogResult
                dr = MessageBox.Show("Press 'Yes' to unlock the project", "Notice", MessageBoxButtons.YesNo)
                If dr = System.Windows.Forms.DialogResult.Yes Then
                    Project.UnlockProject()
                    Message.AddWarning("The project has been unlocked: " & Project.Name & vbCrLf)
                    'Read the Project Information file: -------------------------------------------------
                    Message.Add("Reading project info." & vbCrLf)
                    Project.ReadProjectInfoFile()                 'Read the file in the SettingsLocation: ADVL_Project_Info.xml

                    Project.ReadParameters()
                    Project.ReadParentParameters()
                    If Project.ParentParameterExists("ProNetName") Then
                        Project.AddParameter("ProNetName", Project.ParentParameter("ProNetName").Value, Project.ParentParameter("ProNetName").Description) 'AddParameter will update the parameter if it already exists.
                        ProNetName = Project.Parameter("ProNetName").Value
                    Else
                        ProNetName = Project.GetParameter("ProNetName")
                    End If
                    If Project.ParentParameterExists("ProNetPath") Then 'Get the parent parameter value - it may have been updated.
                        Project.AddParameter("ProNetPath", Project.ParentParameter("ProNetPath").Value, Project.ParentParameter("ProNetPath").Description) 'AddParameter will update the parameter if it already exists.
                        ProNetPath = Project.Parameter("ProNetPath").Value
                    Else
                        ProNetPath = Project.GetParameter("ProNetPath") 'If the parameter does not exist, the value is set to ""
                    End If
                    Project.SaveParameters() 'These should be saved now - child projects look for parent parameters in the parameter file.

                    Project.LockProject() 'Lock the project while it is open in this application.
                    'Set the project start time. This is used to track project usage.
                    Project.Usage.StartTime = Now
                    ApplicationInfo.SettingsLocn = Project.SettingsLocn
                    'Set up the Message object:
                    Message.SettingsLocn = Project.SettingsLocn
                    Message.Show() 'Added 18May19
                Else
                    'Continue without any project selected.
                    Project.Name = ""
                    Project.Type = ADVL_Utilities_Library_1.Project.Types.None
                    Project.Description = ""
                    Project.SettingsLocn.Path = ""
                    Project.DataLocn.Path = ""
                End If
            Else
                'Read the Project Information file: -------------------------------------------------
                Message.Add("Reading project info." & vbCrLf)
                Project.ReadProjectInfoFile()  'Read the file in the Project Location: ADVL_Project_Info.xml

                Project.ReadParameters()
                Project.ReadParentParameters()
                If Project.ParentParameterExists("ProNetName") Then
                    Project.AddParameter("ProNetName", Project.ParentParameter("ProNetName").Value, Project.ParentParameter("ProNetName").Description) 'AddParameter will update the parameter if it already exists.
                    ProNetName = Project.Parameter("ProNetName").Value
                Else
                    ProNetName = Project.GetParameter("ProNetName")
                End If
                If Project.ParentParameterExists("ProNetPath") Then 'Get the parent parameter value - it may have been updated.
                    Project.AddParameter("ProNetPath", Project.ParentParameter("ProNetPath").Value, Project.ParentParameter("ProNetPath").Description) 'AddParameter will update the parameter if it already exists.
                    ProNetPath = Project.Parameter("ProNetPath").Value
                Else
                    ProNetPath = Project.GetParameter("ProNetPath") 'If the parameter does not exist, the value is set to ""
                End If
                Project.SaveParameters() 'These should be saved now - child projects look for parent parameters in the parameter file.

                Project.LockProject() 'Lock the project while it is open in this application.
                'Set the project start time. This is used to track project usage.
                Project.Usage.StartTime = Now
                ApplicationInfo.SettingsLocn = Project.SettingsLocn
                'Set up the Message object:
                Message.SettingsLocn = Project.SettingsLocn
                Message.Show() 'Added 18May19
            End If

        Else  'Project has been opened using Command Line arguments.

            Project.ReadParameters()
            Project.ReadParentParameters()
            If Project.ParentParameterExists("ProNetName") Then
                Project.AddParameter("ProNetName", Project.ParentParameter("ProNetName").Value, Project.ParentParameter("ProNetName").Description) 'AddParameter will update the parameter if it already exists.
                ProNetName = Project.Parameter("ProNetName").Value
            Else
                ProNetName = Project.GetParameter("ProNetName")
            End If
            If Project.ParentParameterExists("ProNetPath") Then 'Get the parent parameter value - it may have been updated.
                Project.AddParameter("ProNetPath", Project.ParentParameter("ProNetPath").Value, Project.ParentParameter("ProNetPath").Description) 'AddParameter will update the parameter if it already exists.
                ProNetPath = Project.Parameter("ProNetPath").Value
            Else
                ProNetPath = Project.GetParameter("ProNetPath") 'If the parameter does not exist, the value is set to ""
            End If
            Project.SaveParameters() 'These should be saved now - child projects look for parent parameters in the parameter file.

            Project.LockProject() 'Lock the project while it is open in this application.
            ProjectSelected = False 'Reset the Project Selected flag.

            'Set up the Message object:
            Message.SettingsLocn = Project.SettingsLocn
            Message.Show() 'Added 18May19
        End If

        'START Initialise the form: ===============================================================

        Me.WebBrowser1.ObjectForScripting = Me
        'IF THE LINE ABOVE PRODUCES AN ERROR ON STARTUP, CHECK THAT THE CODE ON THE FOLLOWING THREE LINES IS INSERTED JUST ABOVE THE Public Class Main STATEMENT.
        'Imports System.Security.Permissions
        '<PermissionSet(SecurityAction.Demand, Name:="FullTrust")>
        '<System.Runtime.InteropServices.ComVisibleAttribute(True)>

        bgwSendMessage.WorkerReportsProgress = True
        bgwSendMessage.WorkerSupportsCancellation = True

        InitialiseForm() 'Initialise the form for a new project.

        'END   Initialise the form: ---------------------------------------------------------------

        RestoreFormSettings() 'Restore the form settings
        Message.ShowXMessages = ShowXMessages
        Message.ShowSysMessages = ShowSysMessages
        RestoreProjectSettings() 'Restore the Project settings

        ShowProjectInfo() 'Show the project information.

        Message.AddText("------------------- Started OK -------------------------------------------------------------------------- " & vbCrLf & vbCrLf, "Heading")

        If StartupConnectionName = "" Then
            If Project.ConnectOnOpen Then
                ConnectToComNet() 'The Project is set to connect when it is opened.
            ElseIf ApplicationInfo.ConnectOnStartup Then
                ConnectToComNet() 'The Application is set to connect when it is started.
            Else
                'Don't connect to ComNet.
            End If
        Else
            'Connect to ComNet using the connection name StartupConnectionName.
            ConnectToComNet(StartupConnectionName)
        End If

        ''Start the timer to keep the connection awake:
        ''Timer3.Interval = 10000 '10 seconds - for testing
        'Timer3.Interval = TimeSpan.FromMinutes(55).TotalMilliseconds '55 minute interval
        'Timer3.Enabled = True
        'Timer3.Start()

    End Sub

    Private Sub InitialiseForm()
        'Initialise the form for a new project.
        OpenStartPage()
    End Sub

    Private Sub ShowProjectInfo()
        'Show the project information:

        txtParentProject.Text = Project.ParentProjectName
        'txtProNetName.Text = Project.GetParameter("AppNetName")
        txtProNetName.Text = Project.GetParameter("ProNetName")
        txtProjectName.Text = Project.Name
        txtProjectDescription.Text = Project.Description
        Select Case Project.Type
            Case ADVL_Utilities_Library_1.Project.Types.Directory
                txtProjectType.Text = "Directory"
            Case ADVL_Utilities_Library_1.Project.Types.Archive
                txtProjectType.Text = "Archive"
            Case ADVL_Utilities_Library_1.Project.Types.Hybrid
                txtProjectType.Text = "Hybrid"
            Case ADVL_Utilities_Library_1.Project.Types.None
                txtProjectType.Text = "None"
        End Select

        txtCreationDate.Text = Format(Project.Usage.FirstUsed, "d-MMM-yyyy H:mm:ss")
        txtLastUsed.Text = Format(Project.Usage.LastUsed, "d-MMM-yyyy H:mm:ss")

        txtID.Text = Project.ID

        txtProjectPath.Text = Project.Path

        Select Case Project.SettingsLocn.Type
            Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
                txtSettingsLocationType.Text = "Directory"
            Case ADVL_Utilities_Library_1.FileLocation.Types.Archive
                txtSettingsLocationType.Text = "Archive"
        End Select
        txtSettingsPath.Text = Project.SettingsLocn.Path

        Select Case Project.DataLocn.Type
            Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
                txtDataLocationType.Text = "Directory"
            Case ADVL_Utilities_Library_1.FileLocation.Types.Archive
                txtDataLocationType.Text = "Archive"
        End Select
        txtDataPath.Text = Project.DataLocn.Path

        Select Case Project.SystemLocn.Type
            Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
                txtSystemLocationType.Text = "Directory"
            Case ADVL_Utilities_Library_1.FileLocation.Types.Archive
                txtSystemLocationType.Text = "Archive"
        End Select
        txtSystemPath.Text = Project.SystemLocn.Path

        If Project.ConnectOnOpen Then
            chkConnect.Checked = True
        Else
            chkConnect.Checked = False
        End If

        txtTotalDuration.Text = Project.Usage.TotalDuration.Days.ToString.PadLeft(5, "0"c) & ":" &
                                Project.Usage.TotalDuration.Hours.ToString.PadLeft(2, "0"c) & ":" &
                                Project.Usage.TotalDuration.Minutes.ToString.PadLeft(2, "0"c) & ":" &
                                Project.Usage.TotalDuration.Seconds.ToString.PadLeft(2, "0"c)

        txtCurrentDuration.Text = Project.Usage.CurrentDuration.Days.ToString.PadLeft(5, "0"c) & ":" &
                                  Project.Usage.CurrentDuration.Hours.ToString.PadLeft(2, "0"c) & ":" &
                                  Project.Usage.CurrentDuration.Minutes.ToString.PadLeft(2, "0"c) & ":" &
                                  Project.Usage.CurrentDuration.Seconds.ToString.PadLeft(2, "0"c)

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Exit the Application

        DisconnectFromComNet() 'Disconnect from the Communication Network (Message Service).

        SaveProjectSettings() 'Save project settings.

        ApplicationInfo.WriteFile() 'Update the Application Information file.

        Project.SaveLastProjectInfo() 'Save information about the last project used.

        Project.SaveParameters()

        'Project.SaveProjectInfoFile() 'Update the Project Information file. This is not required unless there is a change made to the project.

        Project.Usage.SaveUsageInfo() 'Save Project usage information.

        Project.UnlockProject() 'Unlock the project.

        ApplicationUsage.SaveUsageInfo() 'Save Application usage information.
        ApplicationInfo.UnlockApplication()

        Application.Exit()

    End Sub

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Save the form settings if the form state is normal. (A minimised form will have the incorrect size and location.)
        If WindowState = FormWindowState.Normal Then
            SaveFormSettings()
        End If
    End Sub


#End Region 'Form Display Methods -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Open and Close Forms - Code used to open and close other forms." '===================================================================================================================

    Private Sub btnMessages_Click(sender As Object, e As EventArgs) Handles btnMessages.Click
        'Show the Messages form.
        Message.ApplicationName = ApplicationInfo.Name
        Message.SettingsLocn = Project.SettingsLocn
        Message.Show()
        Message.MessageForm.BringToFront()
    End Sub

    Private Sub btnWebPages_Click(sender As Object, e As EventArgs) Handles btnWebPages.Click
        'Open the Web Pages form.

        If IsNothing(WebPageList) Then
            WebPageList = New frmWebPageList
            WebPageList.Show()
        Else
            WebPageList.Show()
            WebPageList.BringToFront()
        End If
    End Sub

    Private Sub WebPageList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles WebPageList.FormClosed
        WebPageList = Nothing
    End Sub

    Public Function OpenNewWebPage() As Integer
        'Open a new HTML Web View window, or reuse an existing one if avaiable.
        'The new forms index number in WebViewFormList is returned.

        NewWebPage = New frmWebPage
        If WebPageFormList.Count = 0 Then
            WebPageFormList.Add(NewWebPage)
            WebPageFormList(0).FormNo = 0
            WebPageFormList(0).Show
            Return 0 'The new HTML Display is at position 0 in WebViewFormList()
        Else
            Dim I As Integer
            Dim FormAdded As Boolean = False
            For I = 0 To WebPageFormList.Count - 1 'Check if there are closed forms in WebViewFormList. They can be re-used.
                If IsNothing(WebPageFormList(I)) Then
                    WebPageFormList(I) = NewWebPage
                    WebPageFormList(I).FormNo = I
                    WebPageFormList(I).Show
                    FormAdded = True
                    Return I 'The new Html Display is at position I in WebViewFormList()
                    Exit For
                End If
            Next
            If FormAdded = False Then 'Add a new form to WebViewFormList
                Dim FormNo As Integer
                WebPageFormList.Add(NewWebPage)
                FormNo = WebPageFormList.Count - 1
                WebPageFormList(FormNo).FormNo = FormNo
                WebPageFormList(FormNo).Show
                Return FormNo 'The new WebPage is at position FormNo in WebPageFormList()
            End If
        End If
    End Function

    Public Sub WebPageFormClosed()
        'This subroutine is called when the Web Page form has been closed.
        'The subroutine is usually called from the FormClosed event of the WebPage form.
        'The WebPage form may have multiple instances.
        'The ClosedFormNumber property should contain the number of the instance of the WebPage form.
        'This property should be updated by the WebPage form when it is being closed.
        'The ClosedFormNumber property value is used to determine which element in WebPageList should be set to Nothing.

        If WebPageFormList.Count < ClosedFormNo + 1 Then
            'ClosedFormNo is too large to exist in WebPageFormList
            Exit Sub
        End If

        If IsNothing(WebPageFormList(ClosedFormNo)) Then
            'The form is already set to nothing
        Else
            WebPageFormList(ClosedFormNo) = Nothing
        End If
    End Sub

    Public Function OpenNewHtmlDisplayPage() As Integer
        'Open a new HTML display window, or reuse an existing one if avaiable.
        'The new forms index number in HtmlDisplayFormList is returned.

        NewHtmlDisplay = New frmHtmlDisplay
        If HtmlDisplayFormList.Count = 0 Then
            HtmlDisplayFormList.Add(NewHtmlDisplay)
            HtmlDisplayFormList(0).FormNo = 0
            HtmlDisplayFormList(0).Show
            Return 0 'The new HTML Display is at position 0 in HtmlDisplayFormList()
        Else
            Dim I As Integer
            Dim FormAdded As Boolean = False
            For I = 0 To HtmlDisplayFormList.Count - 1 'Check if there are closed forms in HtmlDisplayFormList. They can be re-used.
                If IsNothing(HtmlDisplayFormList(I)) Then
                    HtmlDisplayFormList(I) = NewHtmlDisplay
                    HtmlDisplayFormList(I).FormNo = I
                    HtmlDisplayFormList(I).Show
                    FormAdded = True
                    Return I 'The new Html Display is at position I in HtmlDisplayFormList()
                    Exit For
                End If
            Next
            If FormAdded = False Then 'Add a new form to HtmlDisplayFormList
                Dim FormNo As Integer
                HtmlDisplayFormList.Add(NewHtmlDisplay)
                FormNo = HtmlDisplayFormList.Count - 1
                HtmlDisplayFormList(FormNo).FormNo = FormNo
                HtmlDisplayFormList(FormNo).Show
                Return FormNo 'The new HtmlDisplay is at position FormNo in HtmlDisplayFormList()
            End If
        End If
    End Function

    Public Sub HtmlDisplayFormClosed()
        'This subroutine is called when the Html Display form has been closed.
        'The subroutine is usually called from the FormClosed event of the HtmlDisplay form.
        'The HtmlDisplay form may have multiple instances.
        'The ClosedFormNumber property should contain the number of the instance of the HtmlDisplay form.
        'This property should be updated by the HtmlDisplay form when it is being closed.
        'The ClosedFormNumber property value is used to determine which element in HtmlDisplayList should be set to Nothing.

        If HtmlDisplayFormList.Count < ClosedFormNo + 1 Then
            'ClosedFormNo is too large to exist in HtmlDisplayFormList
            Exit Sub
        End If

        If IsNothing(HtmlDisplayFormList(ClosedFormNo)) Then
            'The form is already set to nothing
        Else
            HtmlDisplayFormList(ClosedFormNo) = Nothing
        End If
    End Sub

    'Public Sub OpenWebPage(ByVal FileName As String)
    '    'Open the web page with the specified File Name.

    '    If FileName = "" Then

    '    Else
    '        'First check if the HTML file is already open:
    '        Dim FileFound As Boolean = False
    '        If WebPageFormList.Count = 0 Then

    '        Else
    '            Dim I As Integer
    '            For I = 0 To WebPageFormList.Count - 1
    '                If WebPageFormList(I) Is Nothing Then

    '                Else
    '                    If WebPageFormList(I).FileName = FileName Then
    '                        FileFound = True
    '                        WebPageFormList(I).BringToFront
    '                    End If
    '                End If
    '            Next
    '        End If

    '        If FileFound = False Then
    '            Dim FormNo As Integer = OpenNewWebPage()
    '            WebPageFormList(FormNo).FileName = FileName
    '            WebPageFormList(FormNo).OpenDocument
    '            WebPageFormList(FormNo).BringToFront
    '        End If
    '    End If
    'End Sub


    Private Sub btnLinearRegr_Click(sender As Object, e As EventArgs) Handles btnLinearRegr.Click
        'Open the Linear Regression form:
        If IsNothing(LinRegrForm) Then
            LinRegrForm = New frmLinearRegr
            LinRegrForm.Show()
            LinRegrForm.PositionSumTextBoxes()
        Else
            LinRegrForm.Show()
        End If
    End Sub

    Private Sub LinRegrForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles LinRegrForm.FormClosed
        LinRegrForm = Nothing
    End Sub

    Private Sub btnNonLinRegr_Click(sender As Object, e As EventArgs) Handles btnNonLinRegr.Click
        'Open the Non-Linear Regression form:
        If IsNothing(NonLinRegrForm) Then
            NonLinRegrForm = New frmNonLinRegr
            NonLinRegrForm.Show()
            NonLinRegrForm.PositionSumTextBoxes()
        Else
            NonLinRegrForm.Show()
        End If
    End Sub

    Private Sub NonLinRegrForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles NonLinRegrForm.FormClosed
        NonLinRegrForm = Nothing
    End Sub

    Private Sub btnReadDatabase_Click(sender As Object, e As EventArgs) Handles btnReadDatabase.Click
        'Open the Read Database form:
        If IsNothing(ReadDatabase) Then
            ReadDatabase = New frmReadDatabase
            ReadDatabase.Show()
        Else
            ReadDatabase.Show()
        End If
    End Sub

    Private Sub ReadDatabase_FormClosed(sender As Object, e As FormClosedEventArgs) Handles ReadDatabase.FormClosed
        ReadDatabase = Nothing
    End Sub

#End Region 'Open and Close Forms -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Methods - The main actions performed by this form." '===========================================================================================================================

    Private Sub btnProject_Click(sender As Object, e As EventArgs) Handles btnProject.Click
        Project.SelectProject()
    End Sub

    Private Sub btnParameters_Click(sender As Object, e As EventArgs) Handles btnParameters.Click
        Project.ShowParameters()
    End Sub

    Private Sub btnAppInfo_Click(sender As Object, e As EventArgs) Handles btnAppInfo.Click
        ApplicationInfo.ShowInfo()
    End Sub

    Private Sub btnAndorville_Click(sender As Object, e As EventArgs) Handles btnAndorville.Click
        ApplicationInfo.ShowInfo()
    End Sub

    Private Sub ApplicationInfo_UpdateExePath() Handles ApplicationInfo.UpdateExePath
        'Update the Executable Path.
        ApplicationInfo.ExecutablePath = Application.ExecutablePath
    End Sub

    Private Sub ApplicationInfo_RestoreDefaults() Handles ApplicationInfo.RestoreDefaults
        'Restore the default application settings.
        DefaultAppProperties()
    End Sub

    Public Sub UpdateWebPage(ByVal FileName As String)
        'Update the web page in WebPageFormList if the Web file name is FileName.

        Dim NPages As Integer = WebPageFormList.Count
        Dim I As Integer

        Try
            For I = 0 To NPages - 1
                If IsNothing(WebPageFormList(I)) Then
                    'Web page has been deleted!
                Else
                    If WebPageFormList(I).FileName = FileName Then
                        WebPageFormList(I).OpenDocument
                    End If
                End If
            Next
        Catch ex As Exception
            Message.AddWarning(ex.Message & vbCrLf)
        End Try
    End Sub


#Region " Start Page Code" '=========================================================================================================================================

    Public Sub OpenStartPage()
        'Open the StartPage.html file and display in the Workflow tab.

        If Project.DataFileExists("StartPage.html") Then
            WorkflowFileName = "StartPage.html"
            DisplayWorkflow()
        Else
            CreateStartPage()
            WorkflowFileName = "StartPage.html"
            DisplayWorkflow()
        End If

    End Sub

    Public Sub DisplayWorkflow()
        'Display the StartPage.html file in the Start Page tab.

        If Project.DataFileExists(WorkflowFileName) Then
            Dim rtbData As New IO.MemoryStream
            Project.ReadData(WorkflowFileName, rtbData)
            rtbData.Position = 0
            Dim sr As New IO.StreamReader(rtbData)
            WebBrowser1.DocumentText = sr.ReadToEnd()
        Else
            Message.AddWarning("Web page file not found: " & WorkflowFileName & vbCrLf)
        End If
    End Sub

    Private Sub CreateStartPage()
        'Create a new default StartPage.html file.

        Dim htmData As New IO.MemoryStream
        Dim sw As New IO.StreamWriter(htmData)
        sw.Write(AppInfoHtmlString("Application Information")) 'Create a web page providing information about the application.
        sw.Flush()
        Project.SaveData("StartPage.html", htmData)
    End Sub

    Public Function AppInfoHtmlString(ByVal DocumentTitle As String) As String
        'Create an Application Information Web Page.

        'This function should be edited to provide a brief description of the Application.

        Dim sb As New System.Text.StringBuilder

        sb.Append("<!DOCTYPE html>" & vbCrLf)
        sb.Append("<html>" & vbCrLf)
        sb.Append("<head>" & vbCrLf)
        sb.Append("<title>" & DocumentTitle & "</title>" & vbCrLf)
        sb.Append("<meta name=""description"" content=""Application information."">" & vbCrLf)
        sb.Append("</head>" & vbCrLf)

        sb.Append("<body style=""font-family:arial;"">" & vbCrLf & vbCrLf)

        sb.Append("<h2>" & "Andorville&trade; Regression" & "</h2>" & vbCrLf & vbCrLf) 'Add the page title.
        sb.Append("<hr>" & vbCrLf) 'Add a horizontal divider line.
        sb.Append("<p>A collection of regression methods.</p>" & vbCrLf) 'Add an application description.
        sb.Append("<hr>" & vbCrLf & vbCrLf) 'Add a horizontal divider line.

        sb.Append(DefaultJavaScriptString)

        sb.Append("</body>" & vbCrLf)
        sb.Append("</html>" & vbCrLf)

        Return sb.ToString

    End Function

    Public Function DefaultJavaScriptString() As String
        'Generate the default JavaScript section of an Andorville(TM) Workflow Web Page.

        Dim sb As New System.Text.StringBuilder

        'Add JavaScript section:
        sb.Append("<script>" & vbCrLf & vbCrLf)

        'START: User defined JavaScript functions ==========================================================================
        'Add functions to implement the main actions performed by this web page.
        sb.Append("//START: User defined JavaScript functions ==========================================================================" & vbCrLf)
        sb.Append("//  Add functions to implement the main actions performed by this web page." & vbCrLf & vbCrLf)

        sb.Append("//END:   User defined JavaScript functions __________________________________________________________________________" & vbCrLf & vbCrLf & vbCrLf)
        'END:   User defined JavaScript functions --------------------------------------------------------------------------


        'START: User modified JavaScript functions ==========================================================================
        'Modify these function to save all required web page settings and process all expected XMessage instructions.
        sb.Append("//START: User modified JavaScript functions ==========================================================================" & vbCrLf)
        sb.Append("//  Modify these function to save all required web page settings and process all expected XMessage instructions." & vbCrLf & vbCrLf)

        'Add the Start Up code section.
        sb.Append("//Code to execute on Start Up:" & vbCrLf)
        sb.Append("function StartUpCode() {" & vbCrLf)
        sb.Append("  RestoreSettings() ;" & vbCrLf)
        'sb.Append("  GetCalcsDbPath() ;" & vbCrLf)
        sb.Append("}" & vbCrLf & vbCrLf)

        'Add the SaveSettings function - This is used to save web page settings between sessions.
        sb.Append("//Save the web page settings." & vbCrLf)
        sb.Append("function SaveSettings() {" & vbCrLf)
        sb.Append("  var xSettings = ""<Settings>"" + "" \n"" ; //String containing the web page settings in XML format." & vbCrLf)
        sb.Append("  //Add xml lines to save each setting." & vbCrLf & vbCrLf)
        sb.Append("  xSettings +=    ""</Settings>"" + ""\n"" ; //End of the Settings element." & vbCrLf)
        sb.Append(vbCrLf)
        sb.Append("  //Save the settings as an XML file in the project." & vbCrLf)
        sb.Append("  window.external.SaveHtmlSettings(xSettings) ;" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        'Process a single XMsg instruction (Information:Location pair)
        sb.Append("//Process an XMessage instruction:" & vbCrLf)
        sb.Append("function XMsgInstruction(Info, Locn) {" & vbCrLf)
        sb.Append("  switch(Locn) {" & vbCrLf)
        sb.Append("  //Insert case statements here." & vbCrLf)
        sb.Append("  case ""Status"" :" & vbCrLf)
        sb.Append("    if (Info = ""OK"") { " & vbCrLf)
        sb.Append("      //Instruction processing completed OK:" & vbCrLf)
        sb.Append("      } else {" & vbCrLf)
        sb.Append("      window.external.AddWarning(""Error: Unknown Status information: "" + "" Info: "" + Info + ""\r\n"") ;" & vbCrLf)
        sb.Append("     }" & vbCrLf)
        sb.Append("    break ;" & vbCrLf)
        sb.Append(vbCrLf)
        sb.Append("  default:" & vbCrLf)
        sb.Append("    window.external.AddWarning(""Unknown location: "" + Locn + ""\r\n"") ;" & vbCrLf)
        sb.Append("  }" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        sb.Append("//END:   User modified JavaScript functions __________________________________________________________________________" & vbCrLf & vbCrLf & vbCrLf)
        'END:   User modified JavaScript functions --------------------------------------------------------------------------

        'START: Required Document Library Web Page JavaScript functions ==========================================================================
        sb.Append("//START: Required Document Library Web Page JavaScript functions ==========================================================================" & vbCrLf & vbCrLf)

        'Add the AddText function - This sends a message to the message window using a named text type.
        sb.Append("//Add text to the Message window using a named txt type:" & vbCrLf)
        sb.Append("function AddText(Msg, TextType) {" & vbCrLf)
        sb.Append("  window.external.AddText(Msg, TextType) ;" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        'Add the AddMessage function - This sends a message to the message window using default black text.
        sb.Append("//Add a message to the Message window using the default black text:" & vbCrLf)
        sb.Append("function AddMessage(Msg) {" & vbCrLf)
        sb.Append("  window.external.AddMessage(Msg) ;" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        'Add the AddWarning function - This sends a red, bold warning message to the message window.
        sb.Append("//Add a warning message to the Message window using bold red text:" & vbCrLf)
        sb.Append("function AddWarning(Msg) {" & vbCrLf)
        sb.Append("  window.external.AddWarning(Msg) ;" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        'Add the RestoreSettings function - This is used to restore web page settings.
        sb.Append("//Restore the web page settings." & vbCrLf)
        sb.Append("function RestoreSettings() {" & vbCrLf)
        sb.Append("  window.external.RestoreHtmlSettings() " & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        'This line runs the RestoreSettings function when the web page is loaded.
        sb.Append("//Restore the web page settings when the page loads." & vbCrLf)
        'sb.Append("window.onload = RestoreSettings; " & vbCrLf)
        sb.Append("window.onload = StartUpCode ; " & vbCrLf)
        sb.Append(vbCrLf)

        'Restores a single setting on the web page.
        sb.Append("//Restore a web page setting." & vbCrLf)
        sb.Append("  function RestoreSetting(FormName, ItemName, ItemValue) {" & vbCrLf)
        sb.Append("  document.forms[FormName][ItemName].value = ItemValue ;" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        'Add the RestoreOption function - This is used to add an option to a Select list.
        sb.Append("//Restore a Select control Option." & vbCrLf)
        sb.Append("function RestoreOption(SelectId, OptionText) {" & vbCrLf)
        sb.Append("  var x = document.getElementById(SelectId) ;" & vbCrLf)
        sb.Append("  var option = document.createElement(""Option"") ;" & vbCrLf)
        sb.Append("  option.text = OptionText ;" & vbCrLf)
        sb.Append("  x.add(option) ;" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        sb.Append("//END:   Required Document Library Web Page JavaScript functions __________________________________________________________________________" & vbCrLf & vbCrLf)
        'END:   Required Document Library Web Page JavaScript functions --------------------------------------------------------------------------

        sb.Append("</script>" & vbCrLf & vbCrLf)

        Return sb.ToString

    End Function

    Public Function DefaultHtmlString(ByVal DocumentTitle As String) As String
        'Create a blank HTML Web Page.

        Dim sb As New System.Text.StringBuilder

        sb.Append("<!DOCTYPE html>" & vbCrLf)
        sb.Append("<html>" & vbCrLf)
        sb.Append("<!-- Andorville(TM) Workflow File -->" & vbCrLf)
        sb.Append("<!-- Application Name:    " & ApplicationInfo.Name & " -->" & vbCrLf)
        sb.Append("<!-- Application Version: " & My.Application.Info.Version.ToString & " -->" & vbCrLf)
        sb.Append("<!-- Creation Date:          " & Format(Now, "dd MMMM yyyy") & " -->" & vbCrLf)
        sb.Append("<head>" & vbCrLf)
        sb.Append("<title>" & DocumentTitle & "</title>" & vbCrLf)
        sb.Append("<meta name=""description"" content=""Workflow description."">" & vbCrLf)
        sb.Append("</head>" & vbCrLf)

        sb.Append("<body style=""font-family:arial;"">" & vbCrLf & vbCrLf)

        sb.Append("<h2>" & DocumentTitle & "</h2>" & vbCrLf & vbCrLf)

        sb.Append(DefaultJavaScriptString)

        sb.Append("</body>" & vbCrLf)
        sb.Append("</html>" & vbCrLf)

        Return sb.ToString

    End Function

    Public Function DefaultHtmlString_Old(ByVal DocumentTitle As String) As String
        'Create a blank HTML Web Page.

        Dim sb As New System.Text.StringBuilder

        sb.Append("<!DOCTYPE html>" & vbCrLf)
        sb.Append("<html>" & vbCrLf & "<head>" & vbCrLf & "<title>" & DocumentTitle & "</title>" & vbCrLf)
        sb.Append("</head>" & vbCrLf & "<body>" & vbCrLf & vbCrLf)
        sb.Append("<h1>" & DocumentTitle & "</h1>" & vbCrLf & vbCrLf)

        'Add JavaScript section:
        sb.Append("<script>" & vbCrLf & vbCrLf)

        'START: User defined JavaScript functions ==========================================================================
        'Add functions to implement the main actions performed by this web page.
        sb.Append("//START: User defined JavaScript functions ==========================================================================" & vbCrLf)
        sb.Append("//  Add functions to implement the main actions performed by this web page." & vbCrLf & vbCrLf)

        sb.Append("//END:   User defined JavaScript functions __________________________________________________________________________" & vbCrLf & vbCrLf & vbCrLf)
        'END:   User defined JavaScript functions --------------------------------------------------------------------------


        'START: User modified JavaScript functions ==========================================================================
        'Modify these function to save all required web page settings and process all expected XMessage instructions.
        sb.Append("//START: User modified JavaScript functions ==========================================================================" & vbCrLf)
        sb.Append("//  Modify these function to save all required web page settings and process all expected XMessage instructions." & vbCrLf & vbCrLf)

        'Add the SaveSettings function - This is used to save web page settings between sessions.
        sb.Append("//Save the web page settings." & vbCrLf)
        sb.Append("function SaveSettings() {" & vbCrLf)
        sb.Append("  var xSettings = ""<Settings>"" + "" \n"" ; //String containing the web page settings in XML format." & vbCrLf)
        sb.Append("  //Add xml lines to save each setting." & vbCrLf & vbCrLf)
        sb.Append("  xSettings +=    ""</Settings>"" + ""\n"" ; //End of the Settings element." & vbCrLf)
        sb.Append(vbCrLf)
        sb.Append("  //Save the settings as an XML file in the project." & vbCrLf)
        sb.Append("  window.external.SaveHtmlSettings(xSettings) ;" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        'Process a single XMsg instruction (Information:Location pair)
        sb.Append("//Process an XMessage instruction:" & vbCrLf)
        sb.Append("function XMsgInstruction(Info, Locn) {" & vbCrLf)
        sb.Append("  switch(Locn) {" & vbCrLf)
        sb.Append("  //Insert case statements here." & vbCrLf)
        sb.Append("  default:" & vbCrLf)
        sb.Append("    window.external.AddWarning(""Unknown location: "" + Locn + ""\r\n"") ;" & vbCrLf)
        sb.Append("  }" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        sb.Append("//END:   User modified JavaScript functions __________________________________________________________________________" & vbCrLf & vbCrLf & vbCrLf)
        'END:   User modified JavaScript functions --------------------------------------------------------------------------

        'START: Required Document Library Web Page JavaScript functions ==========================================================================
        sb.Append("//START: Required Document Library Web Page JavaScript functions ==========================================================================" & vbCrLf & vbCrLf)

        'Add the AddText function - This sends a message to the message window using a named text type.
        sb.Append("//Add text to the Message window using a named txt type:" & vbCrLf)
        sb.Append("function AddText(Msg, TextType) {" & vbCrLf)
        sb.Append("  window.external.AddText(Msg, TextType) ;" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        'Add the AddMessage function - This sends a message to the message window using default black text.
        sb.Append("//Add a message to the Message window using the default black text:" & vbCrLf)
        sb.Append("function AddMessage(Msg) {" & vbCrLf)
        sb.Append("  window.external.AddMessage(Msg) ;" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        'Add the AddWarning function - This sends a red, bold warning message to the message window.
        sb.Append("//Add a warning message to the Message window using bold red text:" & vbCrLf)
        sb.Append("function AddWarning(Msg) {" & vbCrLf)
        sb.Append("  window.external.AddWarning(Msg) ;" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        'Add the RestoreSettings function - This is used to restore web page settings.
        sb.Append("//Restore the web page settings." & vbCrLf)
        sb.Append("function RestoreSettings() {" & vbCrLf)
        sb.Append("  window.external.RestoreHtmlSettings() " & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        'This line runs the RestoreSettings function when the web page is loaded.
        sb.Append("//Restore the web page settings when the page loads." & vbCrLf)
        sb.Append("window.onload = RestoreSettings; " & vbCrLf)
        sb.Append(vbCrLf)

        'Restores a single setting on the web page.
        sb.Append("//Restore a web page setting." & vbCrLf)
        sb.Append("  function RestoreSetting(FormName, ItemName, ItemValue) {" & vbCrLf)
        sb.Append("  document.forms[FormName][ItemName].value = ItemValue ;" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        'Add the RestoreOption function - This is used to add an option to a Select list.
        sb.Append("//Restore a Select control Option." & vbCrLf)
        sb.Append("function RestoreOption(SelectId, OptionText) {" & vbCrLf)
        sb.Append("  var x = document.getElementById(SelectId) ;" & vbCrLf)
        sb.Append("  var option = document.createElement(""Option"") ;" & vbCrLf)
        sb.Append("  option.text = OptionText ;" & vbCrLf)
        sb.Append("  x.add(option) ;" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        sb.Append("//END:   Required Document Library Web Page JavaScript functions __________________________________________________________________________" & vbCrLf & vbCrLf)
        'END:   Required Document Library Web Page JavaScript functions --------------------------------------------------------------------------

        sb.Append("</script>" & vbCrLf & vbCrLf)

        sb.Append("</body>" & vbCrLf & "</html>" & vbCrLf)

        Return sb.ToString

    End Function

#End Region 'Start Page Code ------------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region " Methods Called by JavaScript - A collection of methods that can be called by JavaScript in a web page shown in WebBrowser1" '==================================
    'These methods are used to display HTML pages in the Document tab.
    'The same methods can be found in the WebView form, which displays web pages on seprate forms.


    'Display Messages ==============================================================================================

    Public Sub AddMessage(ByVal Msg As String)
        'Add a normal text message to the Message window.
        Message.Add(Msg)
    End Sub

    Public Sub AddWarning(ByVal Msg As String)
        'Add a warning text message to the Message window.
        Message.AddWarning(Msg)
    End Sub

    Public Sub AddTextTypeMessage(ByVal Msg As String, ByVal TextType As String)
        'Add a message with the specified Text Type to the Message window.
        Message.AddText(Msg, TextType)
    End Sub

    Public Sub AddXmlMessage(ByVal XmlText As String)
        'Add an Xml message to the Message window.
        Message.AddXml(XmlText)
    End Sub

    'END Display Messages ------------------------------------------------------------------------------------------


    'Run an XSequence ==============================================================================================

    Public Sub RunClipboardXSeq()
        'Run the XSequence instructions in the clipboard.

        Dim XDocSeq As System.Xml.Linq.XDocument
        Try
            XDocSeq = XDocument.Parse(My.Computer.Clipboard.GetText)
        Catch ex As Exception
            Message.AddWarning("Error reading Clipboard data. " & ex.Message & vbCrLf)
            Exit Sub
        End Try

        If IsNothing(XDocSeq) Then
            Message.Add("No XSequence instructions were found in the clipboard.")
        Else
            Dim XmlSeq As New System.Xml.XmlDocument
            Try
                XmlSeq.LoadXml(XDocSeq.ToString) 'Convert XDocSeq to an XmlDocument to process with XSeq.
                'Run the sequence:
                XSeq.RunXSequence(XmlSeq, Status)
            Catch ex As Exception
                Message.AddWarning("Error restoring HTML settings. " & ex.Message & vbCrLf)
            End Try
        End If
    End Sub

    Public Sub RunXSequence(ByVal XSequence As String)
        'Run the XMSequence
        Dim XmlSeq As New System.Xml.XmlDocument
        XmlSeq.LoadXml(XSequence)
        XSeq.RunXSequence(XmlSeq, Status)
    End Sub

    Private Sub XSeq_ErrorMsg(ErrMsg As String) Handles XSeq.ErrorMsg
        Message.AddWarning(ErrMsg & vbCrLf)
    End Sub


    Private Sub XSeq_Instruction(Data As String, Locn As String) Handles XSeq.Instruction
        'Execute each instruction produced by running the XSeq file.

        Select Case Locn
            Case "Settings:Form:Name"
                FormName = Data

            Case "Settings:Form:Item:Name"
                ItemName = Data

            Case "Settings:Form:Item:Value"
                RestoreSetting(FormName, ItemName, Data)

            Case "Settings:Form:SelectId"
                SelectId = Data

            Case "Settings:Form:OptionText"
                RestoreOption(SelectId, Data)

            Case "Settings"

            Case "EndOfSequence"
                'Main.Message.Add("End of processing sequence" & Data & vbCrLf)

            Case Else
                Message.AddWarning("Unknown location: " & Locn & "  Data: " & Data & vbCrLf)

        End Select
    End Sub

    'END Run an XSequence ------------------------------------------------------------------------------------------


    'Run an XMessage ===============================================================================================

    Public Sub RunXMessage(ByVal XMsg As String)
        'Run the XMessage by sending it to InstrReceived.
        InstrReceived = XMsg
    End Sub

    Public Sub SendXMessage(ByVal ConnName As String, ByVal XMsg As String)
        'Send the XMessage to the application with the connection name ConnName.
        If IsNothing(client) Then
            Message.Add("No client connection available!" & vbCrLf)
        Else
            If client.State = ServiceModel.CommunicationState.Faulted Then
                Message.Add("client state is faulted. Message not sent!" & vbCrLf)
            Else
                If bgwSendMessage.IsBusy Then
                    Message.AddWarning("Send Message backgroundworker is busy." & vbCrLf)
                Else
                    Dim SendMessageParams As New Main.clsSendMessageParams
                    SendMessageParams.ProjectNetworkName = ProNetName
                    SendMessageParams.ConnectionName = ConnName
                    SendMessageParams.Message = XMsg
                    bgwSendMessage.RunWorkerAsync(SendMessageParams)
                    If ShowXMessages Then
                        Message.XAddText("Message sent to " & "[" & ProNetName & "]." & ConnName & ":" & vbCrLf, "XmlSentNotice")
                        Message.XAddXml(XMsg)
                        Message.XAddText(vbCrLf, "Normal") 'Add extra line
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub SendXMessageExt(ByVal ProNetName As String, ByVal ConnName As String, ByVal XMsg As String)
        'Send the XMsg to the application with the connection name ConnName and Project Network Name ProNetname.
        'This version can send the XMessage to a connection external to the current Project Network.
        If IsNothing(client) Then
            Message.Add("No client connection available!" & vbCrLf)
        Else
            If client.State = ServiceModel.CommunicationState.Faulted Then
                Message.Add("client state is faulted. Message not sent!" & vbCrLf)
            Else
                If bgwSendMessage.IsBusy Then
                    Message.AddWarning("Send Message backgroundworker is busy." & vbCrLf)
                Else
                    Dim SendMessageParams As New Main.clsSendMessageParams
                    SendMessageParams.ProjectNetworkName = ProNetName
                    SendMessageParams.ConnectionName = ConnName
                    SendMessageParams.Message = XMsg
                    bgwSendMessage.RunWorkerAsync(SendMessageParams)
                    If ShowXMessages Then
                        Message.XAddText("Message sent to " & "[" & ProNetName & "]." & ConnName & ":" & vbCrLf, "XmlSentNotice")
                        Message.XAddXml(XMsg)
                        Message.XAddText(vbCrLf, "Normal") 'Add extra line
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub SendXMessageWait(ByVal ConnName As String, ByVal XMsg As String)
        'Send the XMsg to the application with the connection name ConnName.
        'Wait for the connection to be made.
        If IsNothing(client) Then
            Message.Add("No client connection available!" & vbCrLf)
        Else
            Try
                'Application.DoEvents() 'TRY THE METHOD WITHOUT THE DOEVENTS
                If client.State = ServiceModel.CommunicationState.Faulted Then
                    Message.Add("client state is faulted. Message not sent!" & vbCrLf)
                Else
                    Dim StartTime As Date = Now
                    Dim Duration As TimeSpan
                    'Wait up to 16 seconds for the connection ConnName to be established
                    While client.ConnectionExists(ProNetName, ConnName) = False 'Wait until the required connection is made.
                        System.Threading.Thread.Sleep(1000) 'Pause for 1000ms
                        Duration = Now - StartTime
                        If Duration.Seconds > 16 Then Exit While
                    End While

                    If client.ConnectionExists(ProNetName, ConnName) = False Then
                        Message.AddWarning("Connection not available: " & ConnName & " in application network: " & ProNetName & vbCrLf)
                    Else
                        If bgwSendMessage.IsBusy Then
                            Message.AddWarning("Send Message backgroundworker is busy." & vbCrLf)
                        Else
                            Dim SendMessageParams As New Main.clsSendMessageParams
                            SendMessageParams.ProjectNetworkName = ProNetName
                            SendMessageParams.ConnectionName = ConnName
                            SendMessageParams.Message = XMsg
                            bgwSendMessage.RunWorkerAsync(SendMessageParams)
                            If ShowXMessages Then
                                Message.XAddText("Message sent to " & "[" & ProNetName & "]." & ConnName & ":" & vbCrLf, "XmlSentNotice")
                                Message.XAddXml(XMsg)
                                Message.XAddText(vbCrLf, "Normal") 'Add extra line
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                Message.AddWarning(ex.Message & vbCrLf)
            End Try
        End If
    End Sub

    Public Sub SendXMessageExtWait(ByVal ProNetName As String, ByVal ConnName As String, ByVal XMsg As String)
        'Send the XMsg to the application with the connection name ConnName and Project Network Name ProNetName.
        'Wait for the connection to be made.
        'This version can send the XMessage to a connection external to the current Project Network.
        If IsNothing(client) Then
            Message.Add("No client connection available!" & vbCrLf)
        Else
            If client.State = ServiceModel.CommunicationState.Faulted Then
                Message.Add("client state is faulted. Message not sent!" & vbCrLf)
            Else
                Dim StartTime As Date = Now
                Dim Duration As TimeSpan
                'Wait up to 16 seconds for the connection ConnName to be established
                While client.ConnectionExists(ProNetName, ConnName) = False
                    System.Threading.Thread.Sleep(1000) 'Pause for 1000ms
                    Duration = Now - StartTime
                    If Duration.Seconds > 16 Then Exit While
                End While

                If client.ConnectionExists(ProNetName, ConnName) = False Then
                    Message.AddWarning("Connection not available: " & ConnName & " in application network: " & ProNetName & vbCrLf)
                Else
                    If bgwSendMessage.IsBusy Then
                        Message.AddWarning("Send Message backgroundworker is busy." & vbCrLf)
                    Else
                        Dim SendMessageParams As New Main.clsSendMessageParams
                        SendMessageParams.ProjectNetworkName = ProNetName
                        SendMessageParams.ConnectionName = ConnName
                        SendMessageParams.Message = XMsg
                        bgwSendMessage.RunWorkerAsync(SendMessageParams)
                        If ShowXMessages Then
                            Message.XAddText("Message sent to " & "[" & ProNetName & "]." & ConnName & ":" & vbCrLf, "XmlSentNotice")
                            Message.XAddXml(XMsg)
                            Message.XAddText(vbCrLf, "Normal") 'Add extra line
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub XMsgInstruction(ByVal Info As String, ByVal Locn As String)
        'Send the XMessage Instruction to the JavaScript function XMsgInstruction for processing.
        Me.WebBrowser1.Document.InvokeScript("XMsgInstruction", New String() {Info, Locn})
    End Sub

    'END Run an XMessage -------------------------------------------------------------------------------------------


    'Get Information ===============================================================================================

    Public Function GetFormNo() As String
        'Return the Form Number of the current instance of the WebPage form.
        'Return FormNo.ToString
        Return "-1"
    End Function

    Public Function GetParentFormNo() As String
        'Return the Form Number of the Parent Form (that called this form).
        'Return ParentWebPageFormNo.ToString
        Return "-1" 'The Main Form does not have a Parent Web Page.
    End Function

    Public Function GetConnectionName() As String
        'Return the Connection Name of the Project.
        Return ConnectionName
    End Function

    Public Function GetProNetName() As String
        'Return the Project Network Name of the Project.
        Return ProNetName
    End Function

    Public Sub ParentProjectName(ByVal FormName As String, ByVal ItemName As String)
        'Return the Parent Project name:
        RestoreSetting(FormName, ItemName, Project.ParentProjectName)
    End Sub

    Public Sub ParentProjectPath(ByVal FormName As String, ByVal ItemName As String)
        'Return the Parent Project path:
        RestoreSetting(FormName, ItemName, Project.ParentProjectPath)
    End Sub

    Public Sub ParentProjectParameterValue(ByVal FormName As String, ByVal ItemName As String, ByVal ParameterName As String)
        'Return the specified Parent Project parameter value:
        RestoreSetting(FormName, ItemName, Project.ParentParameter(ParameterName).Value)
    End Sub

    Public Sub ProjectParameterValue(ByVal FormName As String, ByVal ItemName As String, ByVal ParameterName As String)
        'Return the specified Project parameter value:
        RestoreSetting(FormName, ItemName, Project.Parameter(ParameterName).Value)
    End Sub

    Public Sub ProjectNetworkName(ByVal FormName As String, ByVal ItemName As String)
        'Return the name of the Application Network:
        RestoreSetting(FormName, ItemName, Project.Parameter("ProNetName").Value)
    End Sub

    'END Get Information -------------------------------------------------------------------------------------------


    'Open a Web Page ===============================================================================================

    Public Sub OpenWebPage(ByVal FileName As String)
        'Open the web page with the specified File Name.

        If FileName = "" Then

        Else
            'First check if the HTML file is already open:
            Dim FileFound As Boolean = False
            If WebPageFormList.Count = 0 Then

            Else
                Dim I As Integer
                For I = 0 To WebPageFormList.Count - 1
                    If WebPageFormList(I) Is Nothing Then

                    Else
                        If WebPageFormList(I).FileName = FileName Then
                            FileFound = True
                            WebPageFormList(I).BringToFront
                        End If
                    End If
                Next
            End If

            If FileFound = False Then
                Dim FormNo As Integer = OpenNewWebPage()
                WebPageFormList(FormNo).FileName = FileName
                WebPageFormList(FormNo).OpenDocument
                WebPageFormList(FormNo).BringToFront
            End If
        End If
    End Sub

    'END Open a Web Page -------------------------------------------------------------------------------------------


    'Open and Close Projects =======================================================================================

    Public Sub OpenProjectAtRelativePath(ByVal RelativePath As String, ByVal ConnectionName As String)
        'Open the Project at the specified Relative Path using the specified Connection Name.

        Dim ProjectPath As String
        If RelativePath.StartsWith("\") Then
            ProjectPath = Project.Path & RelativePath
            client.StartProjectAtPath(ProjectPath, ConnectionName)
        Else
            ProjectPath = Project.Path & "\" & RelativePath
            client.StartProjectAtPath(ProjectPath, ConnectionName)
        End If
    End Sub

    Public Sub CheckOpenProjectAtRelativePath(ByVal RelativePath As String, ByVal ConnectionName As String)
        'Check if the project at the specified Relative Path is open.
        'Open it if it is not already open.
        'Open the Project at the specified Relative Path using the specified Connection Name.

        Dim ProjectPath As String
        If RelativePath.StartsWith("\") Then
            ProjectPath = Project.Path & RelativePath
            If client.ProjectOpen(ProjectPath) Then
                'Project is already open.
            Else
                client.StartProjectAtPath(ProjectPath, ConnectionName)
            End If
        Else
            ProjectPath = Project.Path & "\" & RelativePath
            If client.ProjectOpen(ProjectPath) Then
                'Project is already open.
            Else
                client.StartProjectAtPath(ProjectPath, ConnectionName)
            End If
        End If
    End Sub

    Public Sub OpenProjectAtProNetPath(ByVal RelativePath As String, ByVal ConnectionName As String)
        'Open the Project at the specified Path (relative to the Project Network Path) using the specified Connection Name.

        Dim ProjectPath As String
        If RelativePath.StartsWith("\") Then
            If Project.ParameterExists("ProNetPath") Then
                ProjectPath = Project.GetParameter("ProNetPath") & RelativePath
                client.StartProjectAtPath(ProjectPath, ConnectionName)
            Else
                Message.AddWarning("The Project Network Path is not known." & vbCrLf)
            End If
        Else
            If Project.ParameterExists("ProNetPath") Then
                ProjectPath = Project.GetParameter("ProNetPath") & "\" & RelativePath
                client.StartProjectAtPath(ProjectPath, ConnectionName)
            Else
                Message.AddWarning("The Project Network Path is not known." & vbCrLf)
            End If
        End If
    End Sub

    Public Sub CheckOpenProjectAtProNetPath(ByVal RelativePath As String, ByVal ConnectionName As String)
        'Check if the project at the specified Path (relative to the Project Network Path) is open.
        'Open it if it is not already open.
        'Open the Project at the specified Path using the specified Connection Name.

        Dim ProjectPath As String
        If RelativePath.StartsWith("\") Then
            If Project.ParameterExists("ProNetPath") Then
                ProjectPath = Project.GetParameter("ProNetPath") & RelativePath
                'client.StartProjectAtPath(ProjectPath, ConnectionName)
                If client.ProjectOpen(ProjectPath) Then
                    'Project is already open.
                Else
                    client.StartProjectAtPath(ProjectPath, ConnectionName)
                End If
            Else
                Message.AddWarning("The Project Network Path is not known." & vbCrLf)
            End If
        Else
            If Project.ParameterExists("ProNetPath") Then
                ProjectPath = Project.GetParameter("ProNetPath") & "\" & RelativePath
                'client.StartProjectAtPath(ProjectPath, ConnectionName)
                If client.ProjectOpen(ProjectPath) Then
                    'Project is already open.
                Else
                    client.StartProjectAtPath(ProjectPath, ConnectionName)
                End If
            Else
                Message.AddWarning("The Project Network Path is not known." & vbCrLf)
            End If
        End If
    End Sub

    Public Sub CloseProjectAtConnection(ByVal ProNetName As String, ByVal ConnectionName As String)
        'Close the Project at the specified connection.

        If IsNothing(client) Then
            Message.Add("No client connection available!" & vbCrLf)
        Else
            If client.State = ServiceModel.CommunicationState.Faulted Then
                Message.Add("client state is faulted. Message not sent!" & vbCrLf)
            Else
                'Create the XML instructions to close the application at the connection.
                Dim decl As New XDeclaration("1.0", "utf-8", "yes")
                Dim doc As New XDocument(decl, Nothing) 'Create an XDocument to store the instructions.
                Dim xmessage As New XElement("XMsg") 'This indicates the start of the message in the XMessage class

                'NOTE: No reply expected. No need to provide the following client information(?)
                'Dim clientConnName As New XElement("ClientConnectionName", Me.ConnectionName)
                'xmessage.Add(clientConnName)

                Dim command As New XElement("Command", "Close")
                xmessage.Add(command)
                doc.Add(xmessage)

                'Show the message sent to AppNet:
                Message.XAddText("Message sent to: [" & ProNetName & "]." & ConnectionName & ":" & vbCrLf, "XmlSentNotice")
                Message.XAddXml(doc.ToString)
                Message.XAddText(vbCrLf, "Normal") 'Add extra line

                client.SendMessage(ProNetName, ConnectionName, doc.ToString)
            End If
        End If
    End Sub

    'END Open and Close Projects -----------------------------------------------------------------------------------


    'System Methods ================================================================================================

    Public Sub SaveHtmlSettings(ByVal xSettings As String, ByVal FileName As String)
        'Save the Html settings for a web page.

        'Convert the XSettings to XML format:
        Dim XmlHeader As String = "<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?>"
        Dim XDocSettings As New System.Xml.Linq.XDocument

        Try
            XDocSettings = System.Xml.Linq.XDocument.Parse(XmlHeader & vbCrLf & xSettings)
        Catch ex As Exception
            Message.AddWarning("Error saving HTML settings file. " & ex.Message & vbCrLf)
        End Try

        Project.SaveXmlData(FileName, XDocSettings)
    End Sub


    Public Sub RestoreHtmlSettings()
        'Restore the Html settings for a web page.

        Dim SettingsFileName As String = WorkflowFileName & "Settings"
        Dim XDocSettings As New System.Xml.Linq.XDocument
        Project.ReadXmlData(SettingsFileName, XDocSettings)

        If XDocSettings Is Nothing Then
            'Message.Add("No HTML Settings file : " & SettingsFileName & vbCrLf)
        Else
            Dim XSettings As New System.Xml.XmlDocument
            Try
                XSettings.LoadXml(XDocSettings.ToString)
                'Run the Settings file:
                XSeq.RunXSequence(XSettings, Status)
            Catch ex As Exception
                Message.AddWarning("Error restoring HTML settings. " & ex.Message & vbCrLf)
            End Try
        End If
    End Sub

    Public Sub RestoreSetting(ByVal FormName As String, ByVal ItemName As String, ByVal ItemValue As String)
        'Restore the setting value with the specified Form Name and Item Name.
        Me.WebBrowser1.Document.InvokeScript("RestoreSetting", New String() {FormName, ItemName, ItemValue})
    End Sub

    Public Sub RestoreOption(ByVal SelectId As String, ByVal OptionText As String)
        'Restore the Option text in the Select control with the Id SelectId.
        Me.WebBrowser1.Document.InvokeScript("RestoreOption", New String() {SelectId, OptionText})
    End Sub

    Private Sub SaveWebPageSettings()
        'Call the SaveSettings JavaScript function:
        Try
            Me.WebBrowser1.Document.InvokeScript("SaveSettings")
        Catch ex As Exception
            Message.AddWarning("Web page settings not saved: " & ex.Message & vbCrLf)
        End Try
    End Sub

    'END System Methods --------------------------------------------------------------------------------------------


    'Legacy Code (These methods should no longer be used) ==========================================================

    Public Sub JSMethodTest1()
        'Test method that is called from JavaScript.
        Message.Add("JSMethodTest1 called OK." & vbCrLf)
    End Sub

    Public Sub JSMethodTest2(ByVal Var1 As String, ByVal Var2 As String)
        'Test method that is called from JavaScript.
        Message.Add("Var1 = " & Var1 & " Var2 = " & Var2 & vbCrLf)
    End Sub

    Public Sub JSDisplayXml(ByRef XDoc As XDocument)
        Message.Add(XDoc.ToString & vbCrLf & vbCrLf)
    End Sub

    Public Sub ShowMessage(ByVal Msg As String)
        Message.Add(Msg)
    End Sub

    Public Sub AddText(ByVal Msg As String, ByVal TextType As String)
        Message.AddText(Msg, TextType)
    End Sub

    'END Legacy Code -----------------------------------------------------------------------------------------------

#End Region 'Methods Called by JavaScript -------------------------------------------------------------------------------------------------------------------------------


#Region " Project Events Code"

    Private Sub Project_Message(Msg As String) Handles Project.Message
        'Display the Project message:
        Message.Add(Msg & vbCrLf)
    End Sub

    Private Sub Project_ErrorMessage(Msg As String) Handles Project.ErrorMessage
        'Display the Project error message:
        Message.AddWarning(Msg & vbCrLf)
    End Sub

    Private Sub Project_Closing() Handles Project.Closing
        'The current project is closing.
        SaveFormSettings() 'Save the form settings - they are saved in the Project before is closes.
        SaveProjectSettings() 'Update this subroutine if project settings need to be saved.
        Project.Usage.SaveUsageInfo() 'Save the current project usage information.
        'ClearCurrentProjectData()  'Clear the current project data before opening another project.
        Project.UnlockProject() 'Unlock the current project before it Is closed.
        If ConnectedToComNet Then DisconnectFromComNet()
    End Sub

    Private Sub Project_Selected() Handles Project.Selected
        'A new project has been selected.

        RestoreFormSettings()
        Project.ReadProjectInfoFile()

        Project.ReadParameters()
        Project.ReadParentParameters()
        If Project.ParentParameterExists("ProNetName") Then
            Project.AddParameter("ProNetName", Project.ParentParameter("ProNetName").Value, Project.ParentParameter("ProNetName").Description) 'AddParameter will update the parameter if it already exists.
            ProNetName = Project.Parameter("ProNetName").Value
        Else
            ProNetName = Project.GetParameter("ProNetName")
        End If
        If Project.ParentParameterExists("ProNetPath") Then 'Get the parent parameter value - it may have been updated.
            Project.AddParameter("ProNetPath", Project.ParentParameter("ProNetPath").Value, Project.ParentParameter("ProNetPath").Description) 'AddParameter will update the parameter if it already exists.
            ProNetPath = Project.Parameter("ProNetPath").Value
        Else
            ProNetPath = Project.GetParameter("ProNetPath") 'If the parameter does not exist, the value is set to ""
        End If
        Project.SaveParameters() 'These should be saved now - child projects look for parent parameters in the parameter file.

        Project.LockProject() 'Lock the project while it is open in this application.

        Project.Usage.StartTime = Now

        ApplicationInfo.SettingsLocn = Project.SettingsLocn
        Message.SettingsLocn = Project.SettingsLocn
        Message.Show() 'Added 18May19

        'Restore the new project settings:
        RestoreProjectSettings() 'Update this subroutine if project settings need to be restored.

        ShowProjectInfo()

        ''Show the project information:
        'txtProjectName.Text = Project.Name
        'txtProjectDescription.Text = Project.Description
        'Select Case Project.Type
        '    Case ADVL_Utilities_Library_1.Project.Types.Directory
        '        txtProjectType.Text = "Directory"
        '    Case ADVL_Utilities_Library_1.Project.Types.Archive
        '        txtProjectType.Text = "Archive"
        '    Case ADVL_Utilities_Library_1.Project.Types.Hybrid
        '        txtProjectType.Text = "Hybrid"
        '    Case ADVL_Utilities_Library_1.Project.Types.None
        '        txtProjectType.Text = "None"
        'End Select

        'txtCreationDate.Text = Format(Project.CreationDate, "d-MMM-yyyy H:mm:ss")
        'txtLastUsed.Text = Format(Project.Usage.LastUsed, "d-MMM-yyyy H:mm:ss")
        'Select Case Project.SettingsLocn.Type
        '    Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
        '        txtSettingsLocationType.Text = "Directory"
        '    Case ADVL_Utilities_Library_1.FileLocation.Types.Archive
        '        txtSettingsLocationType.Text = "Archive"
        'End Select
        'txtSettingsPath.Text = Project.SettingsLocn.Path
        'Select Case Project.DataLocn.Type
        '    Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
        '        txtDataLocationType.Text = "Directory"
        '    Case ADVL_Utilities_Library_1.FileLocation.Types.Archive
        '        txtDataLocationType.Text = "Archive"
        'End Select
        'txtDataPath.Text = Project.DataLocn.Path

        If Project.ConnectOnOpen Then
            ConnectToComNet() 'The Project is set to connect when it is opened.
        ElseIf ApplicationInfo.ConnectOnStartup Then
            ConnectToComNet() 'The Application is set to connect when it is started.
        Else
            'Don't connect to ComNet.
        End If

    End Sub

    Private Sub chkConnect_LostFocus(sender As Object, e As EventArgs) Handles chkConnect.LostFocus
        If chkConnect.Checked Then
            Project.ConnectOnOpen = True
        Else
            Project.ConnectOnOpen = False
        End If
        Project.SaveProjectInfoFile()
    End Sub

#End Region 'Project Events Code

#Region " Online/Offline Code" '=========================================================================================================================================

    Private Sub btnOnline_Click(sender As Object, e As EventArgs) Handles btnOnline.Click
        'Connect to or disconnect from the Message System (ComNet).
        If ConnectedToComNet = False Then
            ConnectToComNet()
        Else
            DisconnectFromComNet()
        End If
    End Sub

    Private Sub ConnectToComNet()
        'Connect to the Message Service. (ComNet)

        If IsNothing(client) Then
            client = New ServiceReference1.MsgServiceClient(New System.ServiceModel.InstanceContext(New MsgServiceCallback))
        End If

        If ComNetRunning() Then
            'The Application.Lock file has been found at AdvlNetworkAppPath
            'The Message Service is Running.
        Else 'The Message Service is NOT running'
            'Start the Andorville™ Network:
            If AdvlNetworkAppPath = "" Then
                Message.AddWarning("Andorville™ Network application path is unknown." & vbCrLf)
            Else
                If System.IO.File.Exists(AdvlNetworkExePath) Then 'OK to start the Message Service application:
                    Shell(Chr(34) & AdvlNetworkExePath & Chr(34), AppWinStyle.NormalFocus) 'Start Message Service application with no argument
                Else
                    'Incorrect Message Service Executable path.
                    Message.AddWarning("Andorville™ Network exe file not found. Service not started." & vbCrLf)
                End If
            End If
        End If

        'Try to fix a faulted client state:
        If client.State = ServiceModel.CommunicationState.Faulted Then
            client = Nothing
            client = New ServiceReference1.MsgServiceClient(New System.ServiceModel.InstanceContext(New MsgServiceCallback))
        End If

        If client.State = ServiceModel.CommunicationState.Faulted Then
            Message.AddWarning("Client state is faulted. Connection not made!" & vbCrLf)
        Else
            Try
                client.Endpoint.Binding.SendTimeout = New System.TimeSpan(0, 0, 16) 'Temporarily set the send timeaout to 16 seconds (8 seconds is too short for a slow computer!)

                ConnectionName = ApplicationInfo.Name 'This name will be modified if it is already used in an existing connection.
                ConnectionName = client.Connect(ProNetName, ApplicationInfo.Name, ConnectionName, Project.Name, Project.Description, Project.Type, Project.Path, False, False)

                If ConnectionName <> "" Then
                    Message.Add("Connected to the Andorville™ Network with Connection Name: [" & ProNetName & "]." & ConnectionName & vbCrLf)
                    client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeout to 1 hour
                    btnOnline.Text = "Online"
                    btnOnline.ForeColor = Color.ForestGreen
                    ConnectedToComNet = True
                    SendApplicationInfo()
                    SendProjectInfo()
                    client.GetAdvlNetworkAppInfoAsync() 'Update the Exe Path in case it has changed. This path may be needed in the future to start the ComNet (Message Service).

                    bgwComCheck.WorkerReportsProgress = True
                    bgwComCheck.WorkerSupportsCancellation = True
                    If bgwComCheck.IsBusy Then
                        'The ComCheck thread is already running.
                    Else
                        bgwComCheck.RunWorkerAsync() 'Start the ComCheck thread.
                    End If

                Else
                    Message.Add("Connection to the Andorville™ Network failed!" & vbCrLf)
                    client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeout to 1 hour
                End If
            Catch ex As System.TimeoutException
                Message.Add("Timeout error. Check if the Andorville™ Network (Message Service) is running." & vbCrLf)
            Catch ex As Exception
                Message.Add("Error message: " & ex.Message & vbCrLf)
                client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeout to 1 hour
            End Try
        End If
    End Sub

    Private Sub ConnectToComNet(ByVal ConnName As String)
        'Connect to the Message Service (ComNet) with the connection name ConnName.

        If ConnectedToComNet = False Then
            If IsNothing(client) Then
                client = New ServiceReference1.MsgServiceClient(New System.ServiceModel.InstanceContext(New MsgServiceCallback))
            End If

            'Try to fix a faulted client state:
            If client.State = ServiceModel.CommunicationState.Faulted Then
                client = Nothing
                client = New ServiceReference1.MsgServiceClient(New System.ServiceModel.InstanceContext(New MsgServiceCallback))
            End If

            If client.State = ServiceModel.CommunicationState.Faulted Then
                Message.AddWarning("client state is faulted. Connection not made!" & vbCrLf)
            Else
                Try
                    client.Endpoint.Binding.SendTimeout = New System.TimeSpan(0, 0, 16) 'Temporarily set the send timeout to 16 seconds (8 seconds is too short for a slow computer!)
                    ConnectionName = ConnName 'This name will be modified if it is already used in an existing connection.
                    ConnectionName = client.Connect(ProNetName, ApplicationInfo.Name, ConnectionName, Project.Name, Project.Description, Project.Type, Project.Path, False, False)

                    If ConnectionName <> "" Then
                        Message.Add("Connected to the Andorville™ Network with Connection Name: [" & ProNetName & "]." & ConnectionName & vbCrLf)
                        client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeout to 1 hour
                        btnOnline.Text = "Online"
                        btnOnline.ForeColor = Color.ForestGreen
                        ConnectedToComNet = True
                        SendApplicationInfo()
                        SendProjectInfo()
                        client.GetAdvlNetworkAppInfoAsync() 'Update the Exe Path in case it has changed. This path may be needed in the future to start the ComNet (Message Service).

                        bgwComCheck.WorkerReportsProgress = True
                        bgwComCheck.WorkerSupportsCancellation = True
                        If bgwComCheck.IsBusy Then
                            'The ComCheck thread is already running.
                        Else
                            bgwComCheck.RunWorkerAsync() 'Start the ComCheck thread.
                        End If

                    Else
                        Message.Add("Connection to the Andorville™ Network failed!" & vbCrLf)
                        client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeout to 1 hour
                    End If
                Catch ex As System.TimeoutException
                    Message.Add("Timeout error. Check if the Andorville™ Network (Message Service) is running." & vbCrLf)
                Catch ex As Exception
                    Message.Add("Error message: " & ex.Message & vbCrLf)
                    client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeout to 1 hour
                End Try
            End If
        Else
            Message.AddWarning("Already connected to the Andorville™ Network (Message Service)." & vbCrLf)
        End If
    End Sub

    Private Sub DisconnectFromComNet()
        'Disconnect from the Communication Network (Message Service).

        If ConnectedToComNet = True Then
            If IsNothing(client) Then
                'Message.Add("Already disconnected from the Communication Network." & vbCrLf)
                Message.Add("Already disconnected from the Andorville™ Network (Message Service)." & vbCrLf)
                btnOnline.Text = "Offline"
                btnOnline.ForeColor = Color.Red
                ConnectedToComNet = False
                ConnectionName = ""
            Else
                If client.State = ServiceModel.CommunicationState.Faulted Then
                    Message.Add("client state is faulted." & vbCrLf)
                    ConnectionName = ""
                Else
                    Try
                        'client.Disconnect(AppNetName, ConnectionName)
                        client.Disconnect(ProNetName, ConnectionName)
                        btnOnline.Text = "Offline"
                        btnOnline.ForeColor = Color.Red
                        ConnectedToComNet = False
                        ConnectionName = ""
                        'Message.Add("Disconnected from the Communication Network." & vbCrLf)
                        Message.Add("Disconnected from the Andorville™ Network (Message Service)." & vbCrLf)

                        If bgwComCheck.IsBusy Then
                            bgwComCheck.CancelAsync()
                        End If

                    Catch ex As Exception
                        'Message.AddWarning("Error disconnecting from Communication Network: " & ex.Message & vbCrLf)
                        Message.AddWarning("Error disconnecting from Andorville™ Network (Message Service): " & ex.Message & vbCrLf)
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub SendApplicationInfo()
        'Send the application information to the Administrator connections.

        If IsNothing(client) Then
            Message.Add("No client connection available!" & vbCrLf)
        Else
            If client.State = ServiceModel.CommunicationState.Faulted Then
                Message.Add("Client state is faulted. Message not sent!" & vbCrLf)
            Else
                'Create the XML instructions to send application information.
                Dim decl As New XDeclaration("1.0", "utf-8", "yes")
                Dim doc As New XDocument(decl, Nothing) 'Create an XDocument to store the instructions.
                Dim xmessage As New XElement("XMsg") 'This indicates the start of the message in the XMessage class
                Dim applicationInfo As New XElement("ApplicationInfo")
                Dim name As New XElement("Name", Me.ApplicationInfo.Name)
                applicationInfo.Add(name)

                Dim text As New XElement("Text", "ADVL Regression")
                applicationInfo.Add(text)

                Dim exePath As New XElement("ExecutablePath", Me.ApplicationInfo.ExecutablePath)
                applicationInfo.Add(exePath)

                Dim directory As New XElement("Directory", Me.ApplicationInfo.ApplicationDir)
                applicationInfo.Add(directory)
                Dim description As New XElement("Description", Me.ApplicationInfo.Description)
                applicationInfo.Add(description)
                xmessage.Add(applicationInfo)
                doc.Add(xmessage)

                'Show the message sent to ComNet:
                Message.XAddText("Message sent to " & "Message Service" & ":" & vbCrLf, "XmlSentNotice")
                Message.XAddXml(doc.ToString)
                Message.XAddText(vbCrLf, "Normal") 'Add extra line

                client.SendMessage("", "MessageService", doc.ToString)
            End If
        End If

    End Sub

    Private Sub SendProjectInfo()
        'Send the project information to the Network application.

        If ConnectedToComNet = False Then
            Message.AddWarning("The application is not connected to the Message Service." & vbCrLf)
        Else 'Connected to the Message Service (ComNet).
            If IsNothing(client) Then
                Message.Add("No client connection available!" & vbCrLf)
            Else
                If client.State = ServiceModel.CommunicationState.Faulted Then
                    Message.Add("Client state is faulted. Message not sent!" & vbCrLf)
                Else
                    'Construct the XMessage to send to AppNet:
                    Dim decl As New XDeclaration("1.0", "utf-8", "yes")
                    Dim doc As New XDocument(decl, Nothing) 'Create an XDocument to store the instructions.
                    Dim xmessage As New XElement("XMsg") 'This indicates the start of the message in the XMessage class
                    Dim projectInfo As New XElement("ProjectInfo")

                    Dim Path As New XElement("Path", Project.Path)
                    projectInfo.Add(Path)
                    xmessage.Add(projectInfo)
                    doc.Add(xmessage)

                    'Show the message sent to the Message Service:
                    Message.XAddText("Message sent to " & "Message Service" & ":" & vbCrLf, "XmlSentNotice")
                    Message.XAddXml(doc.ToString)
                    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                    client.SendMessage("", "MessageService", doc.ToString)
                End If
            End If
        End If
    End Sub

    Public Sub SendProjectInfo(ByVal ProjectPath As String)
        'Send the project information to the Network application.
        'This version of SendProjectInfo uses the ProjectPath argument.

        If ConnectedToComNet = False Then
            Message.AddWarning("The application is not connected to the Message Service." & vbCrLf)
        Else 'Connected to the Message Service (ComNet).
            If IsNothing(client) Then
                Message.Add("No client connection available!" & vbCrLf)
            Else
                If client.State = ServiceModel.CommunicationState.Faulted Then
                    Message.Add("Client state is faulted. Message not sent!" & vbCrLf)
                Else
                    'Construct the XMessage to send to AppNet:
                    Dim decl As New XDeclaration("1.0", "utf-8", "yes")
                    Dim doc As New XDocument(decl, Nothing) 'Create an XDocument to store the instructions.
                    Dim xmessage As New XElement("XMsg") 'This indicates the start of the message in the XMessage class
                    Dim projectInfo As New XElement("ProjectInfo")

                    Dim Path As New XElement("Path", ProjectPath)
                    projectInfo.Add(Path)
                    xmessage.Add(projectInfo)
                    doc.Add(xmessage)

                    'Show the message sent to the Message Service:
                    Message.XAddText("Message sent to " & "Message Service" & ":" & vbCrLf, "XmlSentNotice")
                    Message.XAddXml(doc.ToString)
                    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                    client.SendMessage("", "MessageService", doc.ToString)
                End If
            End If
        End If
    End Sub

    Private Function ComNetRunning() As Boolean
        'Return True if ComNet (Message Service) is running.
        ''If System.IO.File.Exists(MsgServiceAppPath & "\Application.Lock") Then
        'If System.IO.File.Exists(AdvlNetworkAppPath & "\Application.Lock") Then
        '    Return True
        'Else
        '    Return False
        'End If

        'If MsgServiceAppPath = "" Then
        If AdvlNetworkAppPath = "" Then
            'Message.Add("Message Service application path is not known." & vbCrLf)
            Message.Add("Andorville™ Network application path is not known." & vbCrLf)
            'Message.Add("Run the Message Service before connecting to update the path." & vbCrLf)
            Message.Add("Run the Andorville™ Network before connecting to update the path." & vbCrLf)
            Return False
        Else
            'If System.IO.File.Exists(MsgServiceAppPath & "\Application.Lock") Then
            If System.IO.File.Exists(AdvlNetworkAppPath & "\Application.Lock") Then
                'Message.Add("AppLock found - ComNet is running." & vbCrLf)
                Return True
            Else
                'Message.Add("AppLock not found - ComNet is running." & vbCrLf)
                Return False
            End If
        End If

    End Function

#End Region 'Online/Offline code ----------------------------------------------------------------------------------------------------------------------------------------

    Private Sub TabPage2_Enter(sender As Object, e As EventArgs) Handles TabPage2.Enter
        'Update the current duration:

        txtCurrentDuration.Text = Project.Usage.CurrentDuration.Days.ToString.PadLeft(5, "0"c) & ":" &
                                   Project.Usage.CurrentDuration.Hours.ToString.PadLeft(2, "0"c) & ":" &
                                   Project.Usage.CurrentDuration.Minutes.ToString.PadLeft(2, "0"c) & ":" &
                                   Project.Usage.CurrentDuration.Seconds.ToString.PadLeft(2, "0"c)

        Timer2.Interval = 5000 '5 seconds
        Timer2.Enabled = True
        Timer2.Start()

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        'Update the current duration:

        txtCurrentDuration.Text = Project.Usage.CurrentDuration.Days.ToString.PadLeft(5, "0"c) & ":" &
                           Project.Usage.CurrentDuration.Hours.ToString.PadLeft(2, "0"c) & ":" &
                           Project.Usage.CurrentDuration.Minutes.ToString.PadLeft(2, "0"c) & ":" &
                           Project.Usage.CurrentDuration.Seconds.ToString.PadLeft(2, "0"c)
    End Sub

    Private Sub TabPage2_Leave(sender As Object, e As EventArgs) Handles TabPage2.Leave
        Timer2.Enabled = False
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'Add the current project to the Message Service list.

        If Project.ParentProjectName <> "" Then
            Message.AddWarning("This project has a parent: " & Project.ParentProjectName & vbCrLf)
            Message.AddWarning("Child projects can not be added to the list." & vbCrLf)
            Exit Sub
        End If

        If ConnectedToComNet = False Then
            Message.AddWarning("The application is not connected to the Message Service." & vbCrLf)
        Else 'Connected to the Message Service (ComNet).
            If IsNothing(client) Then
                Message.Add("No client connection available!" & vbCrLf)
            Else
                If client.State = ServiceModel.CommunicationState.Faulted Then
                    Message.Add("Client state is faulted. Message not sent!" & vbCrLf)
                Else
                    'Construct the XMessage to send to AppNet:
                    Dim decl As New XDeclaration("1.0", "utf-8", "yes")
                    Dim doc As New XDocument(decl, Nothing) 'Create an XDocument to store the instructions.
                    Dim xmessage As New XElement("XMsg") 'This indicates the start of the message in the XMessage class
                    Dim projectInfo As New XElement("ProjectInfo")

                    Dim Path As New XElement("Path", Project.Path)
                    projectInfo.Add(Path)
                    xmessage.Add(projectInfo)
                    doc.Add(xmessage)

                    'Show the message sent to AppNet:
                    Message.XAddText("Message sent to " & "Message Service" & ":" & vbCrLf, "XmlSentNotice")
                    Message.XAddXml(doc.ToString)
                    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                    client.SendMessage("", "MessageService", doc.ToString)
                End If
            End If
        End If
    End Sub

    Private Sub btnOpenProject_Click(sender As Object, e As EventArgs) Handles btnOpenProject.Click

        If Project.Type = ADVL_Utilities_Library_1.Project.Types.Archive Then

        Else
            Process.Start(Project.Path)
        End If

    End Sub

    Private Sub btnOpenSettings_Click(sender As Object, e As EventArgs) Handles btnOpenSettings.Click
        If Project.SettingsLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory Then
            Process.Start(Project.SettingsLocn.Path)
        End If
    End Sub

    Private Sub btnOpenData_Click(sender As Object, e As EventArgs) Handles btnOpenData.Click
        If Project.DataLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory Then
            Process.Start(Project.DataLocn.Path)
        End If
    End Sub

    Private Sub btnOpenSystem_Click(sender As Object, e As EventArgs) Handles btnOpenSystem.Click
        If Project.SystemLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory Then
            Process.Start(Project.SystemLocn.Path)
        End If
    End Sub

    Private Sub btnOpenAppDir_Click(sender As Object, e As EventArgs) Handles btnOpenAppDir.Click
        Process.Start(ApplicationInfo.ApplicationDir)
    End Sub


#Region " Process XMessages" '===========================================================================================================================================

    Private Sub XMsg_Instruction(Data As String, Locn As String) Handles XMsg.Instruction
        'Process an XMessage instruction.
        'An XMessage is a simplified XSequence. It is used to exchange information between Andorville™ applications.
        '
        'An XSequence file is an AL-H7™ Information Sequence stored in an XML format.
        'AL-H7™ is the name of a programming system that uses sequences of data and location value pairs to store information or processing steps.
        'Any program, mathematical expression or data set can be expressed as an Information Sequence.

        'Add code here to process the XMessage instructions.
        'See other Andorville™ applications for examples.

        If IsDBNull(Data) Then
            Data = ""
        End If

        'Intercept instructions with the prefix "WebPage_"
        If Locn.StartsWith("WebPage_") Then 'Send the Data, Location data to the correct Web Page:
            'Message.Add("Web Page Location: " & Locn & vbCrLf)
            If Locn.Contains(":") Then
                Dim EndOfWebPageNoString As Integer = Locn.IndexOf(":")
                If Locn.Contains("-") Then
                    Dim HyphenLocn As Integer = Locn.IndexOf("-")
                    If HyphenLocn < EndOfWebPageNoString Then 'Web Page Location contains a sub-location in the web page - WebPage_1-SubLocn:Locn - SubLocn:Locn will be sent to Web page 1
                        EndOfWebPageNoString = HyphenLocn
                    End If
                End If
                Dim PageNoLen As Integer = EndOfWebPageNoString - 8
                Dim WebPageNoString As String = Locn.Substring(8, PageNoLen)
                Dim WebPageNo As Integer = CInt(WebPageNoString)
                Dim WebPageData As String = Data
                Dim WebPageLocn As String = Locn.Substring(EndOfWebPageNoString + 1)

                'Message.Add("WebPageData = " & WebPageData & "  WebPageLocn = " & WebPageLocn & vbCrLf)

                WebPageFormList(WebPageNo).XMsgInstruction(WebPageData, WebPageLocn)
            Else
                Message.AddWarning("XMessage instruction location is not complete: " & Locn & vbCrLf)
            End If
        Else

            Select Case Locn

            'Case "ClientAppNetName"
            '    ClientAppNetName = Data 'The name of the Client Application Network requesting service. ADDED 2Feb19.
                Case "ClientProNetName"
                    ClientProNetName = Data 'The name of the Client Application Network requesting service. AD

                Case "ClientName"
                    ClientAppName = Data 'The name of the Client application requesting service.

                Case "ClientConnectionName"
                    ClientConnName = Data 'The name of the client connection requesting service.

                Case "ClientLocn" 'The Location within the Client requesting service.
                    Dim statusOK As New XElement("Status", "OK") 'Add Status OK element when the Client Location is changed
                    xlocns(xlocns.Count - 1).Add(statusOK)

                    xmessage.Add(xlocns(xlocns.Count - 1)) 'Add the instructions for the last location to the reply xmessage
                    xlocns.Add(New XElement(Data)) 'Start the new location instructions

                'Case "OnCompletion" 'Specify the last instruction to be returned on completion of the XMessage processing.
                '    'OnCompletion = Data
                '    CompletionInstruction = Data

                  'UPDATE:
                Case "OnCompletion"
                    OnCompletionInstruction = Data

                Case "Main"
                 'Blank message - do nothing.

                'Case "Main:OnCompletion"
                '    Select Case "Stop"
                '        'Stop on completion of the instruction sequence.
                '    End Select

                Case "Main:EndInstruction"
                    Select Case Data
                        Case "Stop"
                            'Stop at the end of the instruction sequence.

                            'Add other cases here:
                    End Select

                Case "Main:Status"
                    Select Case Data
                        Case "OK"
                            'Main instructions completed OK
                    End Select

                Case "Command"
                    Select Case Data
                        Case "ConnectToComNet" 'Startup Command
                            If ConnectedToComNet = False Then
                                ConnectToComNet()
                            End If

                        Case "AppComCheck"
                            'Add the Appplication Communication info to the reply message:
                            Dim clientProNetName As New XElement("ClientProNetName", ProNetName) 'The Project Network Name
                            xlocns(xlocns.Count - 1).Add(clientProNetName)
                            Dim clientName As New XElement("ClientName", "ADVL_Regression_1") 'The name of this application.
                            xlocns(xlocns.Count - 1).Add(clientName)
                            Dim clientConnectionName As New XElement("ClientConnectionName", ConnectionName)
                            xlocns(xlocns.Count - 1).Add(clientConnectionName)
                            '<Status>OK</Status> will be automatically appended to the XMessage before it is sent.

                    End Select


            'Startup Command Arguments ================================================
            'Case "AppNetName"
            '    'This is currently not used.
            '    'The AppNetName is determined elsewhere.
                Case "ProNetName"
                'This is currently not used.
                'The ProNetName is determined elsewhere.

                Case "ProjectName"
                    If Project.OpenProject(Data) = True Then
                        ProjectSelected = True 'Project has been opened OK.
                    Else
                        ProjectSelected = False 'Project could not be opened.
                    End If

                Case "ProjectID"
                    Message.AddWarning("Add code to handle ProjectID parameter at StartUp!" & vbCrLf)
                'Note the ComNet will usually select a project using ProjectPath.

                Case "ProjectPath"
                    If Project.OpenProjectPath(Data) = True Then
                        ProjectSelected = True 'Project has been opened OK.
                        'THE PROJECT IS LOCKED IN THE Form.Load EVENT:

                        ApplicationInfo.SettingsLocn = Project.SettingsLocn
                        Message.SettingsLocn = Project.SettingsLocn 'Set up the Message object
                        Message.Show() 'Added 18May19

                        txtTotalDuration.Text = Project.Usage.TotalDuration.Days.ToString.PadLeft(5, "0"c) & ":" &
                                      Project.Usage.TotalDuration.Hours.ToString.PadLeft(2, "0"c) & ":" &
                                      Project.Usage.TotalDuration.Minutes.ToString.PadLeft(2, "0"c) & ":" &
                                      Project.Usage.TotalDuration.Seconds.ToString.PadLeft(2, "0"c)

                        txtCurrentDuration.Text = Project.Usage.CurrentDuration.Days.ToString.PadLeft(5, "0"c) & ":" &
                                       Project.Usage.CurrentDuration.Hours.ToString.PadLeft(2, "0"c) & ":" &
                                       Project.Usage.CurrentDuration.Minutes.ToString.PadLeft(2, "0"c) & ":" &
                                       Project.Usage.CurrentDuration.Seconds.ToString.PadLeft(2, "0"c)

                    Else
                        ProjectSelected = False 'Project could not be opened.
                        Message.AddWarning("Project could not be opened at path: " & Data & vbCrLf)
                    End If

                Case "ConnectionName"
                    StartupConnectionName = Data
            '--------------------------------------------------------------------------

            'Application Information  =================================================
            'returned by client.GetAdvlNetworkAppInfoAsync()
            'Case "MessageServiceAppInfo:Name"
            '    'The name of the Message Service Application. (Not used.)
                Case "AdvlNetworkAppInfo:Name"
                'The name of the Andorville™ Network Application. (Not used.)

            'Case "MessageServiceAppInfo:ExePath"
            '    'The executable file path of the Message Service Application.
            '    MsgServiceExePath = Data
                Case "AdvlNetworkAppInfo:ExePath"
                    'The executable file path of the Andorville™ Network Application.
                    AdvlNetworkExePath = Data

            'Case "MessageServiceAppInfo:Path"
            '    'The path of the Message Service Application (ComNet). (This is where an Application.Lock file will be found while ComNet is running.)
            '    MsgServiceAppPath = Data
                Case "AdvlNetworkAppInfo:Path"
                    'The path of the Andorville™ Network Application (ComNet). (This is where an Application.Lock file will be found while ComNet is running.)
                    AdvlNetworkAppPath = Data
           '---------------------------------------------------------------------------

           'Message Window Instructions  ==============================================
                Case "MessageWindow:Left"
                    If IsNothing(Message.MessageForm) Then
                        Message.ApplicationName = ApplicationInfo.Name
                        Message.SettingsLocn = Project.SettingsLocn
                        Message.Show()
                    End If
                    Message.MessageForm.Left = Data
                Case "MessageWindow:Top"
                    If IsNothing(Message.MessageForm) Then
                        Message.ApplicationName = ApplicationInfo.Name
                        Message.SettingsLocn = Project.SettingsLocn
                        Message.Show()
                    End If
                    Message.MessageForm.Top = Data
                Case "MessageWindow:Width"
                    If IsNothing(Message.MessageForm) Then
                        Message.ApplicationName = ApplicationInfo.Name
                        Message.SettingsLocn = Project.SettingsLocn
                        Message.Show()
                    End If
                    Message.MessageForm.Width = Data
                Case "MessageWindow:Height"
                    If IsNothing(Message.MessageForm) Then
                        Message.ApplicationName = ApplicationInfo.Name
                        Message.SettingsLocn = Project.SettingsLocn
                        Message.Show()
                    End If
                    Message.MessageForm.Height = Data
                Case "MessageWindow:Command"
                    Select Case Data
                        Case "BringToFront"
                            If IsNothing(Message.MessageForm) Then
                                Message.ApplicationName = ApplicationInfo.Name
                                Message.SettingsLocn = Project.SettingsLocn
                                Message.Show()
                            End If
                            'Message.MessageForm.BringToFront()
                            Message.MessageForm.Activate()
                            Message.MessageForm.TopMost = True
                            Message.MessageForm.TopMost = False
                        Case "SaveSettings"
                            Message.MessageForm.SaveFormSettings()
                    End Select

            '---------------------------------------------------------------------------

            'Command to bring the Application window to the front:
                Case "ApplicationWindow:Command"
                    Select Case Data
                        Case "BringToFront"
                            Me.Activate()
                            Me.TopMost = True
                            Me.TopMost = False
                    End Select

            '---------------------------------------------------------------------------


            'Linear Regression Instructions ============================================
                Case "Regression:Linear:Command"
                    Select Case Data
                        Case "Clear"
                            'Clear the Linear Regression data:
                            LinRegr.Clear()
                        Case "FitLine"
                            'Fit a regression line to the input points:
                            LinRegr.FitLine()
                        Case "GetCorrelation"
                            'Get the linear regression Correlation:
                            Dim correlation As New XElement("Correlation", LinRegr.Correlation)
                            xlocns(xlocns.Count - 1).Add(correlation) 'Add the XMessage instruction to the current reply XLocation
                        Case "GetErrorStdDev"
                            'Get the linear regression Standard Deviation of errors:
                            Dim errorStdDev As New XElement("ErrorStdDev", LinRegr.ErrorStdDev)
                            xlocns(xlocns.Count - 1).Add(errorStdDev) 'Add the XMessage instruction to the current reply XLocation
                        Case "GetForecast"
                            'Get the Forecast Point Y using the ForecastPointX value:
                            Dim forecast As New XElement("Forecast")
                            Dim forecastPointX As New XElement("PointX", LinRegr.ForecastPointX)
                            forecast.Add(forecastPointX)
                            Dim forecastPointY As New XElement("PointY", LinRegr.Predict(LinRegr.ForecastPointX))
                            forecast.Add(forecastPointY)
                            xlocns(xlocns.Count - 1).Add(forecast) 'Add the XMessage instructions to the current reply XLocation
                        Case "GetSlope"
                            'Get the slope of the linear regression line:
                            Dim slope As New XElement("Slope", LinRegr.Slope)
                            xlocns(xlocns.Count - 1).Add(slope) 'Add the XMessage instruction to the current reply XLocation
                        Case "GetIntercept"
                            'Get the Y Intercept of the linear regression line:
                            Dim intercept As New XElement("Intercept", LinRegr.Intercept)
                            xlocns(xlocns.Count - 1).Add(intercept) 'Add the XMessage instruction to the current reply XLocation
                        Case "GetRegressionLine"
                            'Get the linear regression line parameters:
                            Dim regressionLine As New XElement("RegressionLine")
                            Dim slope As New XElement("Slope", LinRegr.Slope)
                            regressionLine.Add(slope)
                            Dim intercept As New XElement("Intercept", LinRegr.Intercept)
                            regressionLine.Add(intercept)
                            xlocns(xlocns.Count - 1).Add(regressionLine) 'Add the XMessage instructions to the current reply XLocation
                        Case "GetRegressionInfo"
                            'Get all linear regression information: Slope, Intercept, Correlation and ErrorStdDev:
                            Dim regressionLine As New XElement("RegressionLine")
                            Dim slope As New XElement("Slope", LinRegr.Slope)
                            regressionLine.Add(slope)
                            Dim intercept As New XElement("Intercept", LinRegr.Intercept)
                            regressionLine.Add(intercept)
                            xlocns(xlocns.Count - 1).Add(regressionLine) 'Add the XMessage instructions to the current reply XLocation
                            Dim correlation As New XElement("Correlation", LinRegr.Correlation)
                            xlocns(xlocns.Count - 1).Add(correlation) 'Add the XMessage instruction to the current reply XLocation
                            Dim errorStdDev As New XElement("ErrorStdDev", LinRegr.ErrorStdDev)
                            xlocns(xlocns.Count - 1).Add(errorStdDev) 'Add the XMessage instruction to the current reply XLocation
                        Case Else
                            Message.AddWarning("Unknown command: Regression:Linear:Command " & Data & vbCrLf)
                    End Select

            'Commands to add single input points to the Linear Regression model:....................
                Case "Regression:Linear:InputPoint:X"
                    LinRegr.InputPointX = Data

                Case "Regression:Linear:InputPoint:Y"
                    LinRegr.InputPointY = Data

                Case "Regression:Linear:InputPoint:Command"
                    Select Case Data
                        Case "Add"
                            'Add the new Input Point to the DataPoints list:
                            LinRegr.AddInputPoint()
                        Case Else
                            Message.AddWarning("Unknown command: Regression:Linear:InputPoint:Command " & Data & vbCrLf)
                    End Select
            '.......................................................................................

            'Commands to read input points from a database:.........................................
                Case "Regression:Linear:Database:Path"
                    LinRegr.DatabasePath = Data
                Case "Regression:Linear:Database:Query"
                    LinRegr.DatabaseQuery = Data
                Case "Regression:Linear:Database:XValueColumnName"
                    LinRegr.DatabaseXValueColumnName = Data
                Case "Regression:Linear:Database:YValueColumnName"
                    LinRegr.DatabaseYValueColumnName = Data
                Case "Regression:Linear:Database:Command"
                    Select Case Data
                        Case "GetInputData"
                            'Get the Input Data from the Database:
                            LinRegr.DatabaseInputData()
                        Case Else
                            Message.AddWarning("Unknown command: Regression:Linear:Database:Command " & Data & vbCrLf)
                    End Select

            '.......................................................................................

                Case "Regression:Linear:ForecastPointX"
                    'Set the X value of a forecast point
                    LinRegr.ForecastPointX = Data


            '---------------------------------------------------------------------------

            'Non-Linear Regression Instructions ========================================

                Case "Regression:NonLinear:Command"
                    Select Case Data
                        Case "Clear"
                            'Clear the Non-Linear Regression data:
                            NonLinRegr.Clear()
                        Case "TransformInputPoints"
                            'Transform the Input Points
                            NonLinRegr.TransformInputPoints()
                        Case "FitLine"
                            'Fit a non-linear regression line to the input points:
                            NonLinRegr.FitLine()
                        Case "GetTransformedCorrelation"
                            'Get the non-linear regression Transformed Correlation:
                            Dim correlation As New XElement("TransformedCorrelation", NonLinRegr.TCorrelation)
                            xlocns(xlocns.Count - 1).Add(correlation) 'Add the XMessage instruction to the current reply XLocation
                        Case "GetTransformedErrorStdDev"
                            'Get the non-linear regression Transformed Standard Deviation of errors:
                            Dim errorStdDev As New XElement("TransformedErrorStdDev", NonLinRegr.TErrorStdDev)
                            xlocns(xlocns.Count - 1).Add(errorStdDev) 'Add the XMessage instruction to the current reply XLocation
                        Case "GetErrorStdDev"
                            'Get the non-linear regression Standard Deviation of errors:
                            Dim errorStdDev As New XElement("ErrorStdDev", NonLinRegr.ErrorStdDev)
                            xlocns(xlocns.Count - 1).Add(errorStdDev) 'Add the XMessage instruction to the current reply XLocation
                        Case "GetForecast"
                            'Get the Forecast Point Y using the ForecastPointX value:
                            Dim forecast As New XElement("Forecast")
                            Dim forecastPointX As New XElement("PointX", NonLinRegr.ForecastPointX)
                            forecast.Add(forecastPointX)
                            Dim forecastPointY As New XElement("PointY", NonLinRegr.PredictY(NonLinRegr.ForecastPointX))
                            forecast.Add(forecastPointY)
                            xlocns(xlocns.Count - 1).Add(forecast) 'Add the XMessage instructions to the current reply XLocation
                        Case "GetTransformedSlope"
                            'Get the slope of the linear regression line:
                            Dim slope As New XElement("TransformedSlope", NonLinRegr.TSlope)
                            xlocns(xlocns.Count - 1).Add(slope) 'Add the XMessage instruction to the current reply XLocation
                        Case "GetTransformedIntercept"
                            'Get the Y Intercept of the linear regression line:
                            Dim intercept As New XElement("TransformedIntercept", NonLinRegr.TIntercept)
                            xlocns(xlocns.Count - 1).Add(intercept) 'Add the XMessage instruction to the current reply XLocation
                        Case "GetTransformedRegressionLine"
                            'Get the linear regression line parameters:
                            Dim regressionLine As New XElement("TransformedRegressionLine")
                            Dim slope As New XElement("Slope", NonLinRegr.TSlope)
                            regressionLine.Add(slope)
                            Dim intercept As New XElement("Intercept", NonLinRegr.TIntercept)
                            regressionLine.Add(intercept)
                            xlocns(xlocns.Count - 1).Add(regressionLine) 'Add the XMessage instructions to the current reply XLocation
                        Case "GetRegressionInfo"
                            'Get all linear regression information: Slope, Intercept, Correlation and ErrorStdDev:
                            Dim regressionLine As New XElement("TransformedRegressionLine")
                            Dim transformType As New XElement("TransformType", NonLinRegr.TransformType)
                            regressionLine.Add(transformType)
                            Dim slope As New XElement("Slope", NonLinRegr.TSlope)
                            regressionLine.Add(slope)
                            Dim intercept As New XElement("Intercept", NonLinRegr.TIntercept)
                            regressionLine.Add(intercept)
                            xlocns(xlocns.Count - 1).Add(regressionLine) 'Add the XMessage instructions to the current reply XLocation
                            Dim correlation As New XElement("TransformedCorrelation", NonLinRegr.TCorrelation)
                            xlocns(xlocns.Count - 1).Add(correlation) 'Add the XMessage instruction to the current reply XLocation
                            Dim transErrorStdDev As New XElement("TransformedErrorStdDev", NonLinRegr.TErrorStdDev)
                            xlocns(xlocns.Count - 1).Add(transErrorStdDev) 'Add the XMessage instruction to the current reply XLocation
                            Dim errorStdDev As New XElement("ErrorStdDev", NonLinRegr.ErrorStdDev)
                            xlocns(xlocns.Count - 1).Add(errorStdDev) 'Add the XMessage instruction to the current reply XLocation

                            'Note: The TransformedErrorStdDev and ErrorStdDev are constants for a non-linear regression.
                            'The UnTransformedErrorStdDev is not a constant and must be calulated at each XValue.


                        Case Else
                            Message.AddWarning("Unknown command: Regression:NonLinear:Command " & Data & vbCrLf)
                    End Select

            'Commands to add single input points to the Linear Regression model:....................
                Case "Regression:NonLinear:InputPoint:X"
                    NonLinRegr.InputPointX = Data

                Case "Regression:NonLinear:InputPoint:Y"
                    NonLinRegr.InputPointY = Data

                Case "Regression:NonLinear:InputPoint:Command"
                    Select Case Data
                        Case "Add"
                            'Add the new Input Point to the DataPoints list:
                            NonLinRegr.AddInputPoint()
                        Case Else
                            Message.AddWarning("Unknown command: Regression:NonLinear:InputPoint:Command " & Data & vbCrLf)
                    End Select
            '.......................................................................................

            'Commands to read input points from a database:.........................................
                Case "Regression:NonLinear:Database:Path"
                    NonLinRegr.DatabasePath = Data
                Case "Regression:NonLinear:Database:Query"
                    NonLinRegr.DatabaseQuery = Data
                Case "Regression:NonLinear:Database:XValueColumnName"
                    NonLinRegr.DatabaseXValueColumnName = Data
                Case "Regression:NonLinear:Database:YValueColumnName"
                    NonLinRegr.DatabaseYValueColumnName = Data
                Case "Regression:NonLinear:Database:Command"
                    Select Case Data
                        Case "GetInputData"
                            'Get the Input Data from the Database:
                            NonLinRegr.DatabaseInputData()
                        Case Else
                            Message.AddWarning("Unknown command: Regression:NonLinear:Database:Command " & Data & vbCrLf)
                    End Select

                '.......................................................................................
                Case "Regression:NonLinear:TransformType"
                    'Set the type of transform to apply to the Input Points. The transform attempts to make the transformed points linear to allow a linear regression line fit.
                    'Valid transform types are: Linear, Logarithmic, Exponential and Power.
                    NonLinRegr.TransformType = Data

                Case "Regression:NonLinear:ForecastPointX"
                    'Set the X value of a forecast point
                    NonLinRegr.ForecastPointX = Data

                Case "Regression:NonLinear:ForecastPointXDateString"
                    'Set the X value of a forecast point using a date string
                    NonLinRegr.ForecastPointXDateString = Data


            '---------------------------------------------------------------------------

                Case "EndOfSequence"
                    'End of Information Vector Sequence reached.
                    'Add Status OK element at the end of the sequence:
                    'Dim statusOK As New XElement("Status", "OK")
                    'Dim statusOK As New XElement("Status", OnCompletion) '
                    Dim statusOK As New XElement("Status", "OK") 'Add Status OK element at the end of the sequence
                    xlocns(xlocns.Count - 1).Add(statusOK)

                    Select Case EndInstruction
                        Case "Stop"
                            'No instructions.

                            'Add any other Cases here:

                        Case Else
                            Message.AddWarning("Unknown End Instruction: " & EndInstruction & vbCrLf)
                    End Select
                    EndInstruction = "Stop"

                    ''Add the final OnCompletion instruction:
                    'Dim onCompletion As New XElement("OnCompletion", CompletionInstruction) '
                    ''xlocns(xlocns.Count - 1).Add(statusOK)
                    'xlocns(xlocns.Count - 1).Add(onCompletion)
                    'CompletionInstruction = "Stop" 'Reset the Completion Instruction

                    ''Final Version:
                    ''Add the final EndInstruction:
                    'Dim xEndInstruction As New XElement("EndInstruction", OnCompletionInstruction)
                    'xlocns(xlocns.Count - 1).Add(xEndInstruction)
                    'OnCompletionInstruction = "Stop" 'Reset the OnCompletion Instruction

                    'Add the final EndInstruction:
                    If OnCompletionInstruction = "Stop" Then
                        'Final EndInstruction is not required.
                    Else
                        Dim xEndInstruction As New XElement("EndInstruction", OnCompletionInstruction)
                        xlocns(xlocns.Count - 1).Add(xEndInstruction)
                        OnCompletionInstruction = "Stop" 'Reset the OnCompletion Instruction
                    End If

                Case Else
                    Message.AddWarning("Unknown location: " & Locn & vbCrLf)
                    Message.AddWarning("            data: " & Data & vbCrLf)
            End Select
        End If
    End Sub

    'Private Sub SendMessage()
    '    'Code used to send a message after a timer delay.
    '    'The message destination is stored in MessageDest
    '    'The message text is stored in MessageText
    '    Timer1.Interval = 100 '100ms delay
    '    Timer1.Enabled = True 'Start the timer.
    'End Sub

    'Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    '    If IsNothing(client) Then
    '        Message.AddWarning("No client connection available!" & vbCrLf)
    '    Else
    '        If client.State = ServiceModel.CommunicationState.Faulted Then
    '            Message.AddWarning("client state is faulted. Message not sent!" & vbCrLf)
    '        Else
    '            Try
    '                'Message.Add("Sending a message. Number of characters: " & MessageText.Length & vbCrLf)
    '                'client.SendMessage(ClientAppNetName, ClientConnName, MessageText)
    '                client.SendMessage(ClientProNetName, ClientConnName, MessageText)
    '                MessageText = "" 'Clear the message after it has been sent.
    '                ClientAppName = "" 'Clear the Client Application Name after the message has been sent.
    '                'ClientAppLocn = "" 'Clear the Client Application Location after the message has been sent.
    '                'ClientAppNetName = "" 'Clear the Client Application Network Name after the message has been sent. ADDED 2Feb19.
    '                ClientProNetName = "" 'Clear the Client Application Network Name after the message has been sent.
    '                ClientConnName = "" 'Clear the Client Application Name after the message has been sent.
    '                xlocns.Clear()
    '            Catch ex As Exception
    '                Message.AddWarning("Error sending message: " & ex.Message & vbCrLf)
    '            End Try
    '        End If
    '    End If

    '    'Stop timer:
    '    Timer1.Enabled = False
    'End Sub

    'Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
    '    'Keet the connection awake with each tick:

    '    If ConnectedToComNet = True Then
    '        Try
    '            If client.IsAlive() Then
    '                Message.Add(Format(Now, "HH:mm:ss") & " Connection OK." & vbCrLf)
    '                Timer3.Interval = TimeSpan.FromMinutes(55).TotalMilliseconds '55 minute interval
    '            Else
    '                Message.Add(Format(Now, "HH:mm:ss") & " Connection Fault." & vbCrLf)
    '                Timer3.Interval = TimeSpan.FromMinutes(55).TotalMilliseconds '55 minute interval
    '            End If
    '        Catch ex As Exception
    '            Message.AddWarning(ex.Message & vbCrLf)
    '            'Set interval to five minutes - try again in five minutes:
    '            Timer3.Interval = TimeSpan.FromMinutes(5).TotalMilliseconds '5 minute interval
    '        End Try
    '    Else
    '        Message.Add(Format(Now, "HH:mm:ss") & " Not connected." & vbCrLf)
    '    End If
    'End Sub

    Private Sub XMsgLocal_Instruction(Data As String, Locn As String) Handles XMsgLocal.Instruction
        'Process an XMessage instruction locally.

        If IsDBNull(Data) Then
            Data = ""
        End If

        'Intercept instructions with the prefix "WebPage_"
        If Locn.StartsWith("WebPage_") Then 'Send the Data, Location data to the correct Web Page:
            'Message.Add("Web Page Location: " & Locn & vbCrLf)
            If Locn.Contains(":") Then
                Dim EndOfWebPageNoString As Integer = Locn.IndexOf(":")
                If Locn.Contains("-") Then
                    Dim HyphenLocn As Integer = Locn.IndexOf("-")
                    If HyphenLocn < EndOfWebPageNoString Then 'Web Page Location contains a sub-location in the web page - WebPage_1-SubLocn:Locn - SubLocn:Locn will be sent to Web page 1
                        EndOfWebPageNoString = HyphenLocn
                    End If
                End If
                Dim PageNoLen As Integer = EndOfWebPageNoString - 8
                Dim WebPageNoString As String = Locn.Substring(8, PageNoLen)
                Dim WebPageNo As Integer = CInt(WebPageNoString)
                Dim WebPageData As String = Data
                Dim WebPageLocn As String = Locn.Substring(EndOfWebPageNoString + 1)

                'Message.Add("WebPageData = " & WebPageData & "  WebPageLocn = " & WebPageLocn & vbCrLf)

                WebPageFormList(WebPageNo).XMsgInstruction(WebPageData, WebPageLocn)
            Else
                Message.AddWarning("XMessage instruction location is not complete: " & Locn & vbCrLf)
            End If
        Else

            Select Case Locn
                Case "ClientName"
                    ClientAppName = Data 'The name of the Client requesting service.

                          'UPDATE:
                Case "OnCompletion"
                    OnCompletionInstruction = Data

                Case "Main"
                 'Blank message - do nothing.

                'Case "Main:OnCompletion"
                '    Select Case "Stop"
                '        'Stop on completion of the instruction sequence.
                '    End Select



                Case "Main:EndInstruction"
                    Select Case Data
                        Case "Stop"
                            'Stop at the end of the instruction sequence.

                            'Add other cases here:
                    End Select
                Case "Main:Status"
                    Select Case Data
                        Case "OK"
                            'Main instructions completed OK
                    End Select

                Case "EndOfSequence"
                    'End of Information Vector Sequence reached.

                Case Else
                    Message.AddWarning("Local XMessage: " & Locn & vbCrLf)
                    Message.AddWarning("Unknown location: " & Locn & vbCrLf)
                    Message.AddWarning("            data: " & Data & vbCrLf)
            End Select
        End If
    End Sub



#End Region 'Process XMessages ------------------------------------------------------------------------------------------------------------------------------------------


    Private Sub ToolStripMenuItem1_EditWorkflowTabPage_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1_EditWorkflowTabPage.Click
        'Edit the Workflow Web Page:

        If WorkflowFileName = "" Then
            Message.AddWarning("No page to edit." & vbCrLf)
        Else
            Dim FormNo As Integer = OpenNewHtmlDisplayPage()
            HtmlDisplayFormList(FormNo).FileName = WorkflowFileName
            HtmlDisplayFormList(FormNo).OpenDocument
        End If

    End Sub

    Private Sub ToolStripMenuItem1_ShowStartPageInWorkflowTab_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1_ShowStartPageInWorkflowTab.Click
        'Show the Start Page in the Workflow Tab:
        OpenStartPage()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Main_Move(sender As Object, e As EventArgs) Handles Me.Move
        txtLeft.Text = Me.Left
        txtTop.Text = Me.Top
    End Sub

    Private Sub bgwComCheck_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwComCheck.DoWork
        'The communications check thread.
        While ConnectedToComNet
            Try
                If client.IsAlive() Then
                    'Message.Add(Format(Now, "HH:mm:ss") & " Connection OK." & vbCrLf) 'This produces the error: Cross thread operation not valid.
                    bgwComCheck.ReportProgress(1, Format(Now, "HH:mm:ss") & " Connection OK." & vbCrLf)
                Else
                    'Message.Add(Format(Now, "HH:mm:ss") & " Connection Fault." & vbCrLf) 'This produces the error: Cross thread operation not valid.
                    bgwComCheck.ReportProgress(1, Format(Now, "HH:mm:ss") & " Connection Fault.")
                End If
            Catch ex As Exception
                bgwComCheck.ReportProgress(1, "Error in bgeComCheck_DoWork!" & vbCrLf)
                bgwComCheck.ReportProgress(1, ex.Message & vbCrLf)
            End Try

            'System.Threading.Thread.Sleep(60000) 'Sleep time in milliseconds (60 seconds) - For testing only.
            'System.Threading.Thread.Sleep(3600000) 'Sleep time in milliseconds (60 minutes)
            System.Threading.Thread.Sleep(1800000) 'Sleep time in milliseconds (30 minutes)
        End While
    End Sub

    Private Sub bgwComCheck_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwComCheck.ProgressChanged
        Message.Add(e.UserState.ToString) 'Show the ComCheck message 
    End Sub

    Private Sub XMsg_ErrorMsg(ErrMsg As String) Handles XMsg.ErrorMsg
        Message.AddWarning(ErrMsg & vbCrLf)
    End Sub

    Private Sub bgwSendMessage_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwSendMessage.DoWork
        'Send a message on a separate thread:
        Try
            If IsNothing(client) Then
                bgwSendMessage.ReportProgress(1, "No Connection available. Message not sent!")
            Else
                If client.State = ServiceModel.CommunicationState.Faulted Then
                    bgwSendMessage.ReportProgress(1, "Connection state is faulted. Message not sent!")
                Else
                    Dim SendMessageParams As clsSendMessageParams = e.Argument
                    client.SendMessage(SendMessageParams.ProjectNetworkName, SendMessageParams.ConnectionName, SendMessageParams.Message)
                End If
            End If
        Catch ex As Exception
            bgwSendMessage.ReportProgress(1, ex.Message)
        End Try
    End Sub

    Private Sub bgwSendMessage_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwSendMessage.ProgressChanged
        'Display an error message:
        Message.AddWarning("Send Message error: " & e.UserState.ToString & vbCrLf) 'Show the bgwSendMessage message 
    End Sub

    Private Sub bgwSendMessageAlt_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwSendMessageAlt.DoWork
        'Alternative SendMessage background worker - used to send a message while instructions are being processed. 
        'Send a message on a separate thread
        Try
            If IsNothing(client) Then
                bgwSendMessageAlt.ReportProgress(1, "No Connection available. Message not sent!")
            Else
                If client.State = ServiceModel.CommunicationState.Faulted Then
                    bgwSendMessageAlt.ReportProgress(1, "Connection state is faulted. Message not sent!")
                Else
                    Dim SendMessageParamsAlt As clsSendMessageParams = e.Argument
                    client.SendMessage(SendMessageParamsAlt.ProjectNetworkName, SendMessageParamsAlt.ConnectionName, SendMessageParamsAlt.Message)
                End If
            End If
        Catch ex As Exception
            bgwSendMessageAlt.ReportProgress(1, ex.Message)
        End Try
    End Sub

    Private Sub bgwSendMessageAlt_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwSendMessageAlt.ProgressChanged
        'Display an error message:
        Message.AddWarning("Send Message error: " & e.UserState.ToString & vbCrLf) 'Show the bgwSendMessageAlt message 
    End Sub

    Private Sub NonLinRegr_ErrorMessage(Message As String) Handles NonLinRegr.ErrorMessage
        Me.Message.AddWarning(Message)
    End Sub

    Private Sub NonLinRegr_Message(Message As String) Handles NonLinRegr.Message
        Me.Message.Add(Message)
    End Sub

    Private Sub LinRegr_ErrorMessage(Message As String) Handles LinRegr.ErrorMessage
        Me.Message.AddWarning(Message)
    End Sub

    Private Sub LinRegr_Message(Message As String) Handles LinRegr.Message
        Me.Message.Add(Message)
    End Sub

    Private Sub Message_ShowXMessagesChanged(Show As Boolean) Handles Message.ShowXMessagesChanged
        ShowXMessages = Show
    End Sub

    Private Sub Message_ShowSysMessagesChanged(Show As Boolean) Handles Message.ShowSysMessagesChanged
        ShowSysMessages = Show
    End Sub

    Private Sub Project_NewProjectCreated(ProjectPath As String) Handles Project.NewProjectCreated
        SendProjectInfo(ProjectPath) 'Send the path of the new project to the Network application. The new project will be added to the list of projects.
    End Sub






#End Region 'Form Methods ---------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Public Class clsSendMessageParams
        'Parameters used when sending a message using the Message Service.
        Public ProjectNetworkName As String
        Public ConnectionName As String
        Public Message As String
    End Class

End Class



Public Class clsLinRegr
    'Linear Regression class.

    'Variable declarations -------------------------------------------------------------------------------------

    'Public DataPoints As List(Of clsDataPoint) = New List(Of clsDataPoint) 'The list of input data points, predicted points and statistics.
    Public DataPoints As List(Of DataPoint) = New List(Of DataPoint) 'The list of input data points, predicted points and statistics.

    'Properties ------------------------------------------------------------------------------------------------

    Private _slope As Double = 0 'The slope of the linear regression line.
    Property Slope As Double
        Get
            Return _slope
        End Get
        Set(value As Double)
            _slope = value
        End Set
    End Property

    Private _intercept As Double = 0 'The Y intercept of the linear regression line.
    Property Intercept As Double
        Get
            Return _intercept
        End Get
        Set(value As Double)
            _intercept = value
        End Set
    End Property

    Private _correlation As Double = 0 'The corrleation (R) of the linear regression model.
    Property Correlation As Double
        Get
            Return _correlation
        End Get
        Set(value As Double)
            _correlation = value
        End Set
    End Property

    Private _errorStdDev As Double = 0 'The standard deviation of the y prediction errors.
    Property ErrorStdDev As Double
        Get
            Return _errorStdDev
        End Get
        Set(value As Double)
            _errorStdDev = value
        End Set
    End Property

    Private _inputPointX As Double = 0 'The X value of an input point
    Property InputPointX As Double
        Get
            Return _inputPointX
        End Get
        Set(value As Double)
            _inputPointX = value
        End Set
    End Property

    Private _inputPointY As Double = 0 'The Y value of an input point
    Property InputPointY As Double
        Get
            Return _inputPointY
        End Get
        Set(value As Double)
            _inputPointY = value
        End Set
    End Property

    Private _forecastPointX As Double = 0 'The X value of a forecast point (Y value to be forecast)
    Property ForecastPointX As Double
        Get
            Return _forecastPointX
        End Get
        Set(value As Double)
            _forecastPointX = value
        End Set
    End Property

    Private _databasePath As String = "" 'The path to a database containing Input Points.
    Property DatabasePath As String
        Get
            Return _databasePath
        End Get
        Set(value As String)
            _databasePath = value
        End Set
    End Property

    Private _databaseQuery As String = "" 'The Query used to extract Input Points from the database.
    Property DatabaseQuery As String
        Get
            Return _databaseQuery
        End Get
        Set(value As String)
            _databaseQuery = value
        End Set
    End Property

    Private _databaseXValueColumnName As String = "" 'The name of the Column in the Queried data table containing the X Values.
    Property DatabaseXValueColumnName As String
        Get
            Return _databaseXValueColumnName
        End Get
        Set(value As String)
            _databaseXValueColumnName = value
        End Set
    End Property

    Private _databaseYValueColumnName As String = "" 'The name of the Column in the Queried data table containing the Y Values.
    Property DatabaseYValueColumnName As String
        Get
            Return _databaseYValueColumnName
        End Get
        Set(value As String)
            _databaseYValueColumnName = value
        End Set
    End Property

    'Methods ---------------------------------------------------------------------------------------------------
    Public Sub Clear()
        'Clear all data from the Linear Regression class:

        DataPoints.Clear()
        Slope = 0
        Intercept = 0
        Correlation = 0
        ErrorStdDev = 0
    End Sub

    Public Sub AddInputPoint()
        'Add the input Point InputPointX, InputPointY
        Dim NewPoint As New DataPoint
        NewPoint.XValue = InputPointX
        NewPoint.YValue = InputPointY
        DataPoints.Add(NewPoint)
    End Sub

    Public Sub DatabaseInputData()
        'Get the Input Data from a database.

        If DatabasePath = "" Then
            RaiseEvent ErrorMessage("The database path is not specified." & vbCrLf)
            Exit Sub
        End If

        If DatabaseQuery = "" Then
            RaiseEvent ErrorMessage("The database query is not specified." & vbCrLf)
            Exit Sub
        End If

        If DatabaseXValueColumnName = "" Then
            RaiseEvent ErrorMessage("The database X Value Column Name is not specified." & vbCrLf)
            Exit Sub
        End If

        If DatabaseYValueColumnName = "" Then
            RaiseEvent ErrorMessage("The database Y Value Column Name is not specified." & vbCrLf)
            Exit Sub
        End If


        Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = " & DatabasePath
        Dim myConnection As OleDb.OleDbConnection = New OleDb.OleDbConnection
        myConnection.ConnectionString = connString
        myConnection.Open()

        Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(DatabaseQuery, myConnection)
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey

        Dim ds As DataSet = New DataSet

        Try
            da.Fill(ds, "InputData")

            Dim XType As String = ""
            Dim YType As String = ""

            If ds.Tables("InputData").Columns.Contains(DatabaseXValueColumnName) Then
                If ds.Tables("InputData").Columns.Contains(DatabaseYValueColumnName) Then
                    If ds.Tables("InputData").Columns(DatabaseXValueColumnName).DataType = System.Type.GetType("System.DateTime") Then
                        XType = "Date"
                    ElseIf ds.Tables("InputData").Columns(DatabaseXValueColumnName).DataType = System.Type.GetType("System.Single") Then
                        XType = "Number"
                    ElseIf ds.Tables("InputData").Columns(DatabaseXValueColumnName).DataType = System.Type.GetType("System.Double") Then
                        XType = "Number"
                    ElseIf ds.Tables("InputData").Columns(DatabaseXValueColumnName).DataType = System.Type.GetType("System.Integer") Then
                        XType = "Number"
                    Else
                        XType = "NotValid"
                        RaiseEvent ErrorMessage("The X Value data type is not valid: " & ds.Tables("InputData").Columns(DatabaseXValueColumnName).DataType.ToString & vbCrLf)
                    End If

                    If ds.Tables("InputData").Columns(DatabaseYValueColumnName).DataType = System.Type.GetType("System.Single") Then
                        YType = "Number"
                    ElseIf ds.Tables("InputData").Columns(DatabaseYValueColumnName).DataType = System.Type.GetType("System.Double") Then
                        YType = "Number"
                    ElseIf ds.Tables("InputData").Columns(DatabaseYValueColumnName).DataType = System.Type.GetType("System.Integer") Then
                        YType = "Number"
                    Else
                        YType = "NotValid"
                        RaiseEvent ErrorMessage("The Y Value data type is not valid: " & ds.Tables("InputData").Columns(DatabaseYValueColumnName).DataType.ToString & vbCrLf)
                    End If

                    'Copy the Input Data from the Data Table to the DataPoints:
                    If XType = "Date" Then
                        If YType = "Number" Then
                            DataPoints.Clear()
                            For Each dr As DataRow In ds.Tables("InputData").Rows
                                Dim NewPoint As New DataPoint
                                NewPoint.XValue = dr(DatabaseXValueColumnName).ToOADate
                                NewPoint.YValue = dr(DatabaseYValueColumnName)
                                DataPoints.Add(NewPoint)
                            Next
                        End If
                    ElseIf XType = "Number" Then
                        If YType = "Number" Then
                            DataPoints.Clear()
                            For Each dr As DataRow In ds.Tables("InputData").Rows
                                Dim NewPoint As New DataPoint
                                NewPoint.XValue = dr(DatabaseXValueColumnName)
                                NewPoint.YValue = dr(DatabaseYValueColumnName)
                                DataPoints.Add(NewPoint)
                            Next
                        End If
                    End If

                Else
                    RaiseEvent ErrorMessage("The Input Data table does not contain the Y Value column name: " & DatabaseYValueColumnName & vbCrLf)
                End If
            Else
                RaiseEvent ErrorMessage("The Input Data table does not contain the X Value column name: " & DatabaseXValueColumnName & vbCrLf)
            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub FitLine()
        'Fit a line to the Input data points.

        Dim NPoints As Integer = DataPoints.Count

        If NPoints = 0 Then
            RaiseEvent ErrorMessage("There are no input points!" & vbCrLf)
        Else
            Dim I As Integer
            Dim SumX As Double = 0
            Dim SumY As Double = 0
            Dim SumXX As Double = 0
            Dim SumYY As Double = 0
            Dim SumXY As Double = 0

            SumX = DataPoints.Sum(Function(pt) pt.XValue)
            SumY = DataPoints.Sum(Function(pt) pt.YValue)
            SumXX = DataPoints.Sum(Function(pt) pt.XValue * pt.XValue)
            SumYY = DataPoints.Sum(Function(pt) pt.YValue * pt.YValue)
            SumXY = DataPoints.Sum(Function(pt) pt.XValue * pt.YValue)

            Dim SSxy As Double = SumXY - (SumX * SumY) / NPoints
            Dim SSxx As Double = SumXX - (SumX * SumX) / NPoints
            Slope = SSxy / SSxx
            Intercept = (SumY / NPoints) - (Slope * (SumX / NPoints))

            Correlation = (NPoints * SumXY - SumX * SumY) / ((NPoints * SumXX - SumX * SumX) * (NPoints * SumYY - SumY * SumY)) ^ 0.5

            Dim SumPred As Double = 0
            Dim PredError As Double
            Dim SumPredError As Double = 0
            Dim SquaredError As Double
            Dim SumSqError As Double = 0

            For I = 0 To NPoints - 1
                DataPoints(I).YPrediction = Intercept + Slope * DataPoints(I).XValue
                DataPoints(I).YPredError = DataPoints(I).YValue - DataPoints(I).YPrediction
                DataPoints(I).SqYPredError = DataPoints(I).YPredError * DataPoints(I).YPredError
            Next

            SumSqError = DataPoints.Sum(Function(pt) pt.SqYPredError)
            ErrorStdDev = (SumSqError / NPoints) ^ 0.5

        End If

    End Sub

    Public Function Predict(ByVal XValue As Double) As Double
        'Predict the Y value from the X value
        Return Intercept + Slope * XValue
    End Function

    'Events ----------------------------------------------------------------------------------------------------

    Event ErrorMessage(ByVal Message As String)
    Event Message(ByVal Message As String)

End Class

'Public Class clsDataPoint
Public Class DataPoint
    'A Linear Regression data point
    Public XValue As Double = 0 'An x input value
    Public YValue As Double = 0 'A y input value

    Public YPrediction As Double = 0 'The linear regression y prediction at the x input point
    Public YPredError As Double = 0 'The y prediction error
    Public SqYPredError As Double = 0 'The y prediction error squared
End Class

Public Class NonLinDataPoint
    'A Non-Linear Regression data point
    Public XValue As Double = 0 'An x input value
    Public YValue As Double = 0 'A y input value

    Public TXValue As Double = 0 'A transformed x input value
    Public TYValue As Double = 0 'A transformed y input value

    Public TYPrediction As Double = 0 'The non-linear regression transformed y prediction at the transformed x input point
    Public TYPredError As Double = 0 'The transformed y prediction error
    Public SqTYPredError As Double = 0 'The transformed y prediction error squared

    Public YPrediction As Double = 0 'The un-transformed TYPrediction
    Public YPredError As Double = 0 'The un-transformed y prediction error
    Public SqYPredError As Double = 0 'The un-transformed y predition error squared
End Class
Public Class clsNonLinRegr
    'Non-Linear Regression class.

    'Variable declarations -------------------------------------------------------------------------------------

    Public DataPoints As List(Of NonLinDataPoint) = New List(Of NonLinDataPoint) 'The list of input data points, predicted points and statistics.

    'Properties ------------------------------------------------------------------------------------------------

    Private _tSlope As Double = 0 'The slope of the linear regression line fitted to the transformed input points.
    Property TSlope As Double
        Get
            Return _tSlope
        End Get
        Set(value As Double)
            _tSlope = value
        End Set
    End Property

    Private _tIntercept As Double = 0 'The TY intercept of the linear regression line fitted to the transformed input points.
    Property TIntercept As Double
        Get
            Return _tIntercept
        End Get
        Set(value As Double)
            _tIntercept = value
        End Set
    End Property

    Private _tCorrelation As Double = 0 'The corrleation (R) of the linear regression model fitted to the transformed input points.
    Property TCorrelation As Double
        Get
            Return _tCorrelation
        End Get
        Set(value As Double)
            _tCorrelation = value
        End Set
    End Property

    Private _tErrorStdDev As Double = 0 'The standard deviation of the ty prediction errors.
    Property TErrorStdDev As Double
        Get
            Return _tErrorStdDev
        End Get
        Set(value As Double)
            _tErrorStdDev = value
        End Set
    End Property

    Private _errorStdDev As Double = 0 'The standard deviation of the y prediction errors.
    Property ErrorStdDev As Double
        Get
            Return _errorStdDev
        End Get
        Set(value As Double)
            _errorStdDev = value
        End Set
    End Property

    Private _inputPointX As Double = 0 'The X value of an input point
    Property InputPointX As Double
        Get
            Return _inputPointX
        End Get
        Set(value As Double)
            _inputPointX = value
        End Set
    End Property

    Private _tInputPointX As Double = 0 'The transformed X value of an input point
    Property TInputPointX As Double
        Get
            Return _tInputPointX
        End Get
        Set(value As Double)
            _tInputPointX = value
        End Set
    End Property

    Private _inputPointY As Double = 0 'The Y value of an input point
    Property InputPointY As Double
        Get
            Return _inputPointY
        End Get
        Set(value As Double)
            _inputPointY = value
        End Set
    End Property

    Private _tInputPointY As Double = 0 'The transformed Y value of an input point
    Property TInputPointY As Double
        Get
            Return _tInputPointY
        End Get
        Set(value As Double)
            _tInputPointY = value
        End Set
    End Property

    Private _forecastPointX As Double = 0 'The X value of a forecast point (Y value to be forecast)
    Property ForecastPointX As Double
        Get
            Return _forecastPointX
        End Get
        Set(value As Double)
            _forecastPointX = value
        End Set
    End Property

    Private _forecastPointXDateString As String = "" 'The property is used to store the Date String corresponding to ForecastPointX date. The corresponding date number is also calculated for _ForecastPointX
    Property ForecastPointXDateString As String
        Get
            Return _forecastPointXDateString
        End Get
        Set(value As String)
            _forecastPointXDateString = value
            'Update _forecastPointX with the corresponding value:
            Dim ForecastPointXDate As Date = value
            _forecastPointX = ForecastPointXDate.ToOADate
        End Set
    End Property

    Private _tForecastPointX As Double = 0 'The transformed X value of a forecast point (Y value to be forecast)
    Property TForecastPointX As Double
        Get
            Return _tForecastPointX
        End Get
        Set(value As Double)
            _tForecastPointX = value
        End Set
    End Property

    Private _databasePath As String = "" 'The path to a database containing Input Points.
    Property DatabasePath As String
        Get
            Return _databasePath
        End Get
        Set(value As String)
            _databasePath = value
        End Set
    End Property

    Private _databaseQuery As String = "" 'The Query used to extract Input Points from the database.
    Property DatabaseQuery As String
        Get
            Return _databaseQuery
        End Get
        Set(value As String)
            _databaseQuery = value
        End Set
    End Property

    Private _databaseXValueColumnName As String = "" 'The name of the Column in the Queried data table containing the X Values.
    Property DatabaseXValueColumnName As String
        Get
            Return _databaseXValueColumnName
        End Get
        Set(value As String)
            _databaseXValueColumnName = value
        End Set
    End Property

    Private _databaseYValueColumnName As String = "" 'The name of the Column in the Queried data table containing the Y Values.
    Property DatabaseYValueColumnName As String
        Get
            Return _databaseYValueColumnName
        End Get
        Set(value As String)
            _databaseYValueColumnName = value
        End Set
    End Property

    'Transform Type     XValues     YValues
    'Linear             None        None
    'Logarithmic        Log         None
    'Exponential        None        Log
    'Power              Log         Log
    'Other              ?           ?
    Private _transformType As String = "Linear" 'The Transformation type applied to the input points to make the transformed data more linear.
    Property TransformType As String
        Get
            Return _transformType
        End Get
        Set(value As String)
            _transformType = value
            Select Case _transformType
                Case "Linear"
                    XTransform = "None"
                    YTransform = "None"
                Case "Logarithmic"
                    XTransform = "Log"
                    YTransform = "None"
                Case "Exponential"
                    XTransform = "None"
                    YTransform = "Log"
                Case "Power"
                    XTransform = "Log"
                    YTransform = "Log"
                Case "Other"
                    'User defined X and Y transforms
            End Select
        End Set
    End Property

    Private _xTransform As String = "None" 'The transformation  applied to the X values
    Property XTransform As String
        Get
            Return _xTransform
        End Get
        Set(value As String)
            _xTransform = value
        End Set
    End Property

    Private _yTransform As String = "None" 'The transformation applied to the Y values
    Property YTransform As String
        Get
            Return _yTransform
        End Get
        Set(value As String)
            _yTransform = value
        End Set
    End Property

    'Methods ---------------------------------------------------------------------------------------------------
    Public Sub Clear()
        'Clear all data from the Linear Regression class:

        DataPoints.Clear()
        TSlope = 0
        TIntercept = 0
        TCorrelation = 0
        TErrorStdDev = 0
    End Sub

    Public Sub AddInputPoint()
        'Add the input Point InputPointX, InputPointY
        Dim NewPoint As New NonLinDataPoint
        NewPoint.XValue = InputPointX
        NewPoint.YValue = InputPointY
        DataPoints.Add(NewPoint)
    End Sub

    Public Sub DatabaseInputData()
        'Get the Input Data from a database.

        If DatabasePath = "" Then
            RaiseEvent ErrorMessage("The database path is not specified." & vbCrLf)
            Exit Sub
        End If

        If DatabaseQuery = "" Then
            RaiseEvent ErrorMessage("The database query is not specified." & vbCrLf)
            Exit Sub
        End If

        If DatabaseXValueColumnName = "" Then
            RaiseEvent ErrorMessage("The database X Value Column Name is not specified." & vbCrLf)
            Exit Sub
        End If

        If DatabaseYValueColumnName = "" Then
            RaiseEvent ErrorMessage("The database Y Value Column Name is not specified." & vbCrLf)
            Exit Sub
        End If


        Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = " & DatabasePath
        Dim myConnection As OleDb.OleDbConnection = New OleDb.OleDbConnection
        myConnection.ConnectionString = connString
        myConnection.Open()

        Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(DatabaseQuery, myConnection)
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey

        Dim ds As DataSet = New DataSet

        Try
            da.Fill(ds, "InputData")

            Dim XType As String = ""
            Dim YType As String = ""

            If ds.Tables("InputData").Columns.Contains(DatabaseXValueColumnName) Then
                If ds.Tables("InputData").Columns.Contains(DatabaseYValueColumnName) Then
                    If ds.Tables("InputData").Columns(DatabaseXValueColumnName).DataType = System.Type.GetType("System.DateTime") Then
                        XType = "Date"
                    ElseIf ds.Tables("InputData").Columns(DatabaseXValueColumnName).DataType = System.Type.GetType("System.Single") Then
                        XType = "Number"
                    ElseIf ds.Tables("InputData").Columns(DatabaseXValueColumnName).DataType = System.Type.GetType("System.Double") Then
                        XType = "Number"
                    ElseIf ds.Tables("InputData").Columns(DatabaseXValueColumnName).DataType = System.Type.GetType("System.Integer") Then
                        XType = "Number"
                    Else
                        XType = "NotValid"
                        RaiseEvent ErrorMessage("The X Value data type is not valid: " & ds.Tables("InputData").Columns(DatabaseXValueColumnName).DataType.ToString & vbCrLf)
                    End If

                    If ds.Tables("InputData").Columns(DatabaseYValueColumnName).DataType = System.Type.GetType("System.Single") Then
                        YType = "Number"
                    ElseIf ds.Tables("InputData").Columns(DatabaseYValueColumnName).DataType = System.Type.GetType("System.Double") Then
                        YType = "Number"
                    ElseIf ds.Tables("InputData").Columns(DatabaseYValueColumnName).DataType = System.Type.GetType("System.Integer") Then
                        YType = "Number"
                    Else
                        YType = "NotValid"
                        RaiseEvent ErrorMessage("The Y Value data type is not valid: " & ds.Tables("InputData").Columns(DatabaseYValueColumnName).DataType.ToString & vbCrLf)
                    End If

                    'Copy the Input Data from the Data Table to the DataPoints:
                    If XType = "Date" Then
                        If YType = "Number" Then
                            DataPoints.Clear()
                            For Each dr As DataRow In ds.Tables("InputData").Rows
                                Dim NewPoint As New NonLinDataPoint
                                NewPoint.XValue = dr(DatabaseXValueColumnName).ToOADate
                                NewPoint.YValue = dr(DatabaseYValueColumnName)
                                DataPoints.Add(NewPoint)
                            Next
                        End If
                    ElseIf XType = "Number" Then
                        If YType = "Number" Then
                            Dim I As Integer = 0 'For debugging
                            DataPoints.Clear()
                            For Each dr As DataRow In ds.Tables("InputData").Rows
                                Dim NewPoint As New NonLinDataPoint
                                NewPoint.XValue = dr(DatabaseXValueColumnName)
                                NewPoint.YValue = dr(DatabaseYValueColumnName)
                                DataPoints.Add(NewPoint)
                                I += 1 'For debugging
                            Next
                            RaiseEvent Message("NonLinRegr.DatabaseInputData - Number of Input datapoints added: " & I & vbCrLf)
                        End If
                    End If

                Else
                    RaiseEvent ErrorMessage("The Input Data table does not contain the Y Value column name: " & DatabaseYValueColumnName & vbCrLf)
                End If
            Else
                RaiseEvent ErrorMessage("The Input Data table does not contain the X Value column name: " & DatabaseXValueColumnName & vbCrLf)
            End If

        Catch ex As Exception
            RaiseEvent ErrorMessage("NonLinRegr.DatabaseInputData error: " & ex.Message & vbCrLf)
        End Try

    End Sub 'DatabaseInputData()

    Public Sub TransformInputPoints()
        'Generate the Transformed Input Points.

        Select Case TransformType
            Case "Linear"
                LinearTransformXValues()
                LinearTransformYValues()
            Case "Logarithmic"
                LogTransformXValues()
                LinearTransformYValues()
            Case "Exponential"
                LinearTransformXValues()
                LogTransformYValues()
            Case "Power"
                LogTransformXValues()
                LogTransformYValues()
            Case Else
                RaiseEvent ErrorMessage("Unknown Transform Type: " & TransformType & vbCrLf)
        End Select

    End Sub

    Public Sub FitLine()
        'Fit a line to the Transformed Input data points.

        Dim NPoints As Integer = DataPoints.Count

        If NPoints = 0 Then
            RaiseEvent ErrorMessage("There are no input points!" & vbCrLf)
        Else
            Dim I As Integer
            Dim SumX As Double = 0
            Dim SumY As Double = 0
            Dim SumXX As Double = 0
            Dim SumYY As Double = 0
            Dim SumXY As Double = 0

            SumX = DataPoints.Sum(Function(pt) pt.TXValue)
            SumY = DataPoints.Sum(Function(pt) pt.TYValue)
            SumXX = DataPoints.Sum(Function(pt) pt.TXValue * pt.TXValue)
            SumYY = DataPoints.Sum(Function(pt) pt.TYValue * pt.TYValue)
            SumXY = DataPoints.Sum(Function(pt) pt.TXValue * pt.TYValue)

            Dim SSxy As Double = SumXY - (SumX * SumY) / NPoints
            Dim SSxx As Double = SumXX - (SumX * SumX) / NPoints
            TSlope = SSxy / SSxx
            TIntercept = (SumY / NPoints) - (TSlope * (SumX / NPoints))

            TCorrelation = (NPoints * SumXY - SumX * SumY) / ((NPoints * SumXX - SumX * SumX) * (NPoints * SumYY - SumY * SumY)) ^ 0.5

            'Dim SumPred As Double = 0
            'Dim PredError As Double
            'Dim SumPredError As Double = 0
            'Dim SquaredError As Double
            Dim TSumSqError As Double = 0
            Dim SumSqError As Double = 0

            For I = 0 To NPoints - 1
                DataPoints(I).TYPrediction = TIntercept + TSlope * DataPoints(I).TXValue
                DataPoints(I).TYPredError = DataPoints(I).TYValue - DataPoints(I).TYPrediction
                DataPoints(I).SqTYPredError = DataPoints(I).TYPredError * DataPoints(I).TYPredError

                DataPoints(I).YPrediction = UnTransY(DataPoints(I).TYPrediction)
                'DataPoints(I).YPredError = DataPoints(I).YValue - DataPoints(I).TYPrediction
                DataPoints(I).YPredError = DataPoints(I).YValue - DataPoints(I).YPrediction
                DataPoints(I).SqYPredError = DataPoints(I).YPredError * DataPoints(I).YPredError
            Next

            TSumSqError = DataPoints.Sum(Function(pt) pt.SqTYPredError)
            TErrorStdDev = (TSumSqError / NPoints) ^ 0.5 'The standard deviation of the errors in the transformed predictions.

            SumSqError = DataPoints.Sum(Function(pt) pt.SqYPredError)
            ErrorStdDev = (SumSqError / NPoints) ^ 0.5 'The standard deviation of the errors in the un-transformed predictions.

        End If

    End Sub

    Private Function TransX(ByVal InputVal As Single) As Single
        'Return a transformed x value:
        Select Case XTransform
            Case "None"
                Return InputVal
            Case "Log"
                Return Math.Log(InputVal)
        End Select
    End Function

    Private Function TransY(ByVal InputVal As Single) As Single
        'Return a transformed y value:
        Select Case YTransform
            Case "None"
                Return InputVal
            Case "Log"
                Return Math.Log(InputVal)
        End Select
    End Function

    Private Function UnTransX(ByVal TransVal As Single) As Single
        'Return an un-transformed x value:
        Select Case XTransform
            Case "None"
                Return TransVal
            Case "Log"
                Return Math.Exp(TransVal)
        End Select
    End Function

    Private Function UnTransY(ByVal TransVal As Single) As Single
        'Return an un-transformed y value:
        Select Case YTransform
            Case "None"
                Return TransVal
            Case "Log"
                Return Math.Exp(TransVal)
        End Select
    End Function

    'Public Function Predict(ByVal XValue As Double) As Double
    '    'Predict the Y value from the X value

    '    Return Intercept + Slope * XValue
    'End Function

    Public Function PredictY(ByVal XValue As Single) As Single
        'Predict a Y value from the given X value.
        'The regression line for the transformed points is: TransY = Intercept + Slope * TransX
        'The function UnTransY converts the TransY value back to a Y value.

        'Return UnTransY(Intercept + Slope * TransX(XValue))
        Return UnTransY(TIntercept + TSlope * TransX(XValue))
    End Function

    Private Sub LinearTransformXValues()
        'Set TXValues in DataPoint equal to XValues
        Dim I As Integer
        For I = 0 To DataPoints.Count - 1
            DataPoints(I).TXValue = DataPoints(I).XValue
        Next
    End Sub

    Private Sub LogTransformXValues()
        'Set TXValues in DataPoint equal to Log(XValues)
        Dim I As Integer
        For I = 0 To DataPoints.Count - 1
            DataPoints(I).TXValue = Math.Log(DataPoints(I).XValue)
        Next
    End Sub

    Private Sub LinearTransformYValues()
        'Set TYValues in DataPoint equal to YValues
        Dim I As Integer
        For I = 0 To DataPoints.Count - 1
            DataPoints(I).TYValue = DataPoints(I).YValue
        Next
    End Sub

    Private Sub LogTransformYValues()
        'Set TYValues in DataPoint equal to Log(YValues)
        Dim I As Integer
        For I = 0 To DataPoints.Count - 1
            DataPoints(I).TYValue = Math.Log(DataPoints(I).YValue)
        Next
    End Sub

    'Events ----------------------------------------------------------------------------------------------------

    Event ErrorMessage(ByVal Message As String)
    Event Message(ByVal Message As String)


End Class



