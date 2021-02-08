Public Class frmReadDatabase
    'Read Input data from a database

#Region " Variable Declarations - All the variables used in this form and this application." '=================================================================================================

    'Declare Forms used by the application:
    Public WithEvents LinearRegr As frmLinearRegr
    Public WithEvents NonLinRegr As frmNonLinRegr

    Public ds As DataSet = New DataSet

    Dim TableName As String
    Dim Query As String
    Dim connString As String
    Dim myConnection As OleDb.OleDbConnection = New OleDb.OleDbConnection
    Dim da As OleDb.OleDbDataAdapter


    Dim SelectedXValueColName As String = ""
    Dim SelectedXValueColNo As Integer = -1
    Dim XValueType As String = ""

    Dim SelectedYValueColName As String = ""
    Dim SelectedYValueColNo As Integer = -1
    Dim YValueType As String = ""


#End Region 'Variable Declarations ------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Properties - All the properties used in this form and this application" '============================================================================================================

    'Private _databasePath As String = "" 'The path to the selected database.
    'Property DatabasePath As String
    '    Get
    '        Return _databasePath
    '    End Get
    '    Set(value As String)
    '        _databasePath = value
    '    End Set
    'End Property

#End Region 'Properties -----------------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region " Process XML files - Read and write XML files." '=====================================================================================================================================

    Private Sub SaveFormSettings()
        'Save the form settings in an XML document.
        Dim settingsData = <?xml version="1.0" encoding="utf-8"?>
                           <!---->
                           <FormSettings>
                               <Left><%= Me.Left %></Left>
                               <Top><%= Me.Top %></Top>
                               <Width><%= Me.Width %></Width>
                               <Height><%= Me.Height %></Height>
                               <!---->
                               <DatabasePath><%= txtDatabase.Text %></DatabasePath>
                               <SelectedTable><%= TableName %></SelectedTable>
                               <Query><%= txtQuery.Text %></Query>
                               '<XValues><%= SelectedXValueColName %></XValues>
                               '<YValues><%= SelectedYValueColName %></YValues>
                           </FormSettings>

        'Add code to include other settings to save after the comment line <!---->

        '<SelectedTable><%= cmbSelectTable.SelectedItem.ToString %></SelectedTable>
        '<XValues><%= cmbXValueColumnName.SelectedItem.ToString %></XValues>
        '<YValues><%= cmbYValueColumnName.SelectedItem.ToString %></YValues>

        Dim SettingsFileName As String = "FormSettings_" & Main.ApplicationInfo.Name & "_" & Me.Text & ".xml"
        Main.Project.SaveXmlSettings(SettingsFileName, settingsData)
    End Sub

    Private Sub RestoreFormSettings()
        'Read the form settings from an XML document.

        Dim SettingsFileName As String = "FormSettings_" & Main.ApplicationInfo.Name & "_" & Me.Text & ".xml"

        If Main.Project.SettingsFileExists(SettingsFileName) Then
            Dim Settings As System.Xml.Linq.XDocument
            Main.Project.ReadXmlSettings(SettingsFileName, Settings)

            If IsNothing(Settings) Then 'There is no Settings XML data.
                Exit Sub
            End If

            'Restore form position and size:
            If Settings.<FormSettings>.<Left>.Value <> Nothing Then Me.Left = Settings.<FormSettings>.<Left>.Value
            If Settings.<FormSettings>.<Top>.Value <> Nothing Then Me.Top = Settings.<FormSettings>.<Top>.Value
            If Settings.<FormSettings>.<Height>.Value <> Nothing Then Me.Height = Settings.<FormSettings>.<Height>.Value
            If Settings.<FormSettings>.<Width>.Value <> Nothing Then Me.Width = Settings.<FormSettings>.<Width>.Value


            'Add code to read other saved setting here:
            If Settings.<FormSettings>.<DatabasePath>.Value <> Nothing Then
                txtDatabase.Text = Settings.<FormSettings>.<DatabasePath>.Value
                FillCmbSelectTable()
            End If

            If Settings.<FormSettings>.<SelectedTable>.Value <> Nothing Then
                cmbSelectTable.SelectedIndex = cmbSelectTable.FindStringExact(Settings.<FormSettings>.<SelectedTable>.Value)
            End If

            If Settings.<FormSettings>.<Query>.Value <> Nothing Then
                txtQuery.Text = Settings.<FormSettings>.<Query>.Value
            End If

            If Settings.<FormSettings>.<XValues>.Value <> Nothing Then
                SelectedXValueColName = Settings.<FormSettings>.<XValues>.Value
                'cmbXValueColumnName.SelectedIndex = cmbXValueColumnName.FindStringExact(Settings.<FormSettings>.<XValues>.Value)
                cmbXValueColumnName.SelectedIndex = cmbXValueColumnName.FindStringExact(SelectedXValueColName)

                If IsNothing(cmbXValueColumnName.SelectedIndex) Then
                    cmbXValueColumnName.SelectedIndex = 0
                End If
                SelectedXValueColNo = cmbXValueColumnName.SelectedIndex
            End If

            If Settings.<FormSettings>.<YValues>.Value <> Nothing Then
                SelectedYValueColName = Settings.<FormSettings>.<YValues>.Value
                'cmbYValueColumnName.SelectedIndex = cmbYValueColumnName.FindStringExact(Settings.<FormSettings>.<YValues>.Value)
                cmbYValueColumnName.SelectedIndex = cmbYValueColumnName.FindStringExact(SelectedYValueColName)
                If IsNothing(cmbYValueColumnName.SelectedIndex) Then
                    cmbYValueColumnName.SelectedIndex = 0
                End If
                SelectedYValueColNo = cmbYValueColumnName.SelectedIndex
            End If

            CheckFormPos()
        End If
    End Sub

    Private Sub CheckFormPos()
        'Check that the form can be seen on a screen.

        Dim MinWidthVisible As Integer = 192 'Minimum number of X pixels visible. The form will be moved if this many form pixels are not visible.
        Dim MinHeightVisible As Integer = 64 'Minimum number of Y pixels visible. The form will be moved if this many form pixels are not visible.

        Dim FormRect As New Rectangle(Me.Left, Me.Top, Me.Width, Me.Height)
        Dim WARect As Rectangle = Screen.GetWorkingArea(FormRect) 'The Working Area rectangle - the usable area of the screen containing the form.

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

    Protected Overrides Sub WndProc(ByRef m As Message) 'Save the form settings before the form is minimised:
        If m.Msg = &H112 Then 'SysCommand
            If m.WParam.ToInt32 = &HF020 Then 'Form is being minimised
                SaveFormSettings()
            End If
        End If
        MyBase.WndProc(m)
    End Sub

#End Region 'Process XML Files ----------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region " Form Display Methods - Code used to display this form." '============================================================================================================================

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles Me.Load
        RestoreFormSettings()   'Restore the form settings
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Exit the Form
        Me.Close() 'Close the form
    End Sub

    Private Sub Form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If WindowState = FormWindowState.Normal Then
            SaveFormSettings()
        Else
            'Dont save settings if the form is minimised.
        End If
    End Sub

#End Region 'Form Display Methods -------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region " Open and Close Forms - Code used to open and close other forms." '===================================================================================================================

    Private Sub btnOpenLinRegrForm_Click(sender As Object, e As EventArgs) Handles btnOpenLinRegrForm.Click
        'Open the Linear Regression form:
        If IsNothing(LinearRegr) Then
            LinearRegr = New frmLinearRegr
            LinearRegr.LoadLastFile = False 'Dont load the last file!
            LinearRegr.Show()
            LinearRegr.PositionSumTextBoxes()
            CopyLinRegrData() 'Copy the Input data from the Read Database form to the Linear Regression form.
        Else
            LinearRegr.LoadLastFile = False 'Dont load the last file!
            LinearRegr.Show()
            CopyLinRegrData() 'Copy the Input data from the Read Database form to the Linear Regression form.
        End If

    End Sub

    Private Sub LinearRegr_FormClosed(sender As Object, e As FormClosedEventArgs) Handles LinearRegr.FormClosed
        LinearRegr = Nothing
    End Sub

    Private Sub btnOpenNonLinRegrForm_Click(sender As Object, e As EventArgs) Handles btnOpenNonLinRegrForm.Click
        'Open the Non-Linear Regression form:
        If IsNothing(NonLinRegr) Then
            NonLinRegr = New frmNonLinRegr
            NonLinRegr.LoadLastFile = False 'Dont load the last file!
            NonLinRegr.Show()
            NonLinRegr.PositionSumTextBoxes()
            CopyNonLinRegrData() 'Copy the Input data from the Read Database form to the Non-Linear Regression form.
        Else
            NonLinRegr.LoadLastFile = False 'Dont load the last file!
            NonLinRegr.Show()
            CopyNonLinRegrData() 'Copy the Input data from the Read Database form to the Non-Linear Regression form.
        End If

    End Sub

    Private Sub NonLinRegr_FormClosed(sender As Object, e As FormClosedEventArgs) Handles NonLinRegr.FormClosed
        NonLinRegr = Nothing
    End Sub
#End Region 'Open and Close Forms -------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region " Form Methods - The main actions performed by this form." '===========================================================================================================================

    Private Sub btnDatabase_Click(sender As Object, e As EventArgs) Handles btnDatabase.Click
        'Select the database file:

        If txtDatabase.Text <> "" Then
            Dim fInfo As New System.IO.FileInfo(txtDatabase.Text)
            OpenFileDialog1.InitialDirectory = fInfo.DirectoryName
            OpenFileDialog1.Filter = "Database |*.accdb"
            OpenFileDialog1.FileName = fInfo.Name
        Else
            OpenFileDialog1.InitialDirectory = System.Environment.SpecialFolder.MyDocuments
            OpenFileDialog1.Filter = "Database |*.accdb"
            OpenFileDialog1.FileName = ""
        End If

        If OpenFileDialog1.ShowDialog() = vbOK Then
            'DatabasePath = OpenFileDialog1.FileName
            'txtDatabase.Text = DatabasePath
            txtDatabase.Text = OpenFileDialog1.FileName
            'FillLstTables()
            FillCmbSelectTable()
        End If
    End Sub

    Public Sub FillCmbSelectTable()
        'Fill the cmbSelectTable listbox with the available tables in the selected database.

        If txtDatabase.Text = "" Then
            Main.Message.AddWarning("No database selected!" & vbCrLf)
            Exit Sub
        End If

        'Database access for MS Access:
        Dim connectionString As String 'Declare a connection string for MS Access - defines the database or server to be used.
        Dim conn As System.Data.OleDb.OleDbConnection 'Declare a connection for MS Access - used by the Data Adapter to connect to and disconnect from the database.
        Dim dt As DataTable

        cmbSelectTable.Text = ""
        cmbSelectTable.Items.Clear()
        ds.Clear()
        ds.Reset()
        DataGridView1.Columns.Clear()

        'Specify the connection string:
        'Access 2003
        'connectionString = "provider=Microsoft.Jet.OLEDB.4.0;" + _
        '"data source = " + txtDatabase.Text

        'Access 2007:
        connectionString = "provider=Microsoft.ACE.OLEDB.12.0;" +
        "data source = " + txtDatabase.Text

        'Connect to the Access database:
        conn = New System.Data.OleDb.OleDbConnection(connectionString)
        conn.Open()

        'This error occurs on the above line (conn.Open()):
        'Additional information: The 'Microsoft.ACE.OLEDB.12.0' provider is not registered on the local machine.
        'Fix attempt: 
        'http://www.microsoft.com/en-us/download/confirmation.aspx?id=23734
        'Download AccessDatabaseEngine.exe
        'Run the file to install the 2007 Office System Driver: Data Connectivity Components.


        Dim restrictions As String() = New String() {Nothing, Nothing, Nothing, "TABLE"} 'This restriction removes system tables
        dt = conn.GetSchema("Tables", restrictions)

        'Fill cmbSelectTable
        Dim dr As DataRow
        Dim I As Integer 'Loop index
        Dim MaxI As Integer

        MaxI = dt.Rows.Count
        For I = 0 To MaxI - 1
            dr = dt.Rows(0)
            cmbSelectTable.Items.Add(dt.Rows(I).Item(2).ToString)
        Next I

        conn.Close()

    End Sub

    Private Sub cmbSelectTable_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSelectTable.SelectedIndexChanged
        'Update DataGridView1:

        If IsNothing(cmbSelectTable.SelectedItem) Then
            Exit Sub
        End If

        TableName = cmbSelectTable.SelectedItem.ToString
        'Query = "Select Top 500 * From " & TableName
        Query = "Select Top 500 * From " & "[" & TableName & "]"
        txtQuery.Text = Query

        'connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" & txtDatabase.Text
        'myConnection.ConnectionString = connString
        'myConnection.Open()

        'da = New OleDb.OleDbDataAdapter(Query, myConnection)

        'da.MissingSchemaAction = MissingSchemaAction.AddWithKey 'This statement is required to obtain the correct result from the statement: ds.Tables(0).Columns(0).MaxLength (This fixes a Microsoft bug: http://support.microsoft.com/kb/317175 )

        'ds.Clear()
        'ds.Reset()

        'da.FillSchema(ds, SchemaType.Source, TableName)
        ''da.FillSchema(ds, SchemaType.Source, "[" & TableName & "]")

        'da.Fill(ds, TableName)
        ''da.Fill(ds, "[" & TableName & "]")

        'DataGridView1.AutoGenerateColumns = True

        'DataGridView1.EditMode = DataGridViewEditMode.EditOnKeystroke

        'DataGridView1.DataSource = ds.Tables(0)
        'DataGridView1.AutoResizeColumns()

        'DataGridView1.Update()
        'DataGridView1.Refresh()
        'UpdateXYColumns()
        'myConnection.Close()

    End Sub

    Private Sub btnApplyQuery_Click(sender As Object, e As EventArgs) Handles btnApplyQuery.Click
        'Apply query on Table tab.

        If IsNothing(cmbSelectTable.SelectedItem) Then
            Exit Sub
        End If

        TableName = cmbSelectTable.SelectedItem.ToString

        connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" & txtDatabase.Text
        myConnection.ConnectionString = connString
        myConnection.Open()

        da = New OleDb.OleDbDataAdapter(txtQuery.Text, myConnection)

        da.MissingSchemaAction = MissingSchemaAction.AddWithKey

        ds.Clear()
        ds.Reset()
        Try
            da.Fill(ds, TableName)

            DataGridView1.AutoGenerateColumns = True

            DataGridView1.EditMode = DataGridViewEditMode.EditOnKeystroke

            DataGridView1.DataSource = ds.Tables(0)
            DataGridView1.AutoResizeColumns()

            DataGridView1.Update()
            DataGridView1.Refresh()
            UpdateXYColumns()

            'Re-selected the XValue item if it is still available:
            cmbXValueColumnName.SelectedIndex = cmbXValueColumnName.FindStringExact(SelectedXValueColName)
            If IsNothing(cmbXValueColumnName.SelectedIndex) Then
                cmbXValueColumnName.SelectedIndex = 0
            End If
            SelectedXValueColNo = cmbXValueColumnName.SelectedIndex

            'Re-selected the YValue item if it is still available:
            cmbYValueColumnName.SelectedIndex = cmbYValueColumnName.FindStringExact(SelectedYValueColName)
            If IsNothing(cmbYValueColumnName.SelectedIndex) Then
                cmbYValueColumnName.SelectedIndex = 0
            End If
            SelectedYValueColNo = cmbYValueColumnName.SelectedIndex

        Catch ex As Exception
            Main.Message.Add("Error applying query." & vbCrLf)
            Main.Message.Add(ex.Message & vbCrLf & vbCrLf)
        End Try

        myConnection.Close()
    End Sub

    Private Sub UpdateXYColumns()
        'Update the XValue and YValue ComboBoxes

        cmbXValueColumnName.Items.Clear()
        cmbYValueColumnName.Items.Clear()

        'For Each Column As DataColumn In DataGridView1.Columns
        For Each Column As DataGridViewTextBoxColumn In DataGridView1.Columns
            'cmbXValueColumnName.Items.Add(Column.ColumnName)
            cmbXValueColumnName.Items.Add(Column.HeaderText)
            'cmbYValueColumnName.Items.Add(Column.ColumnName)
            cmbYValueColumnName.Items.Add(Column.HeaderText)
        Next


    End Sub

    Private Sub cmbXValueColumnName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbXValueColumnName.SelectedIndexChanged
        'Dim SelColNo As Integer = cmbXValueColumnName.SelectedIndex
        SelectedXValueColNo = cmbXValueColumnName.SelectedIndex
        SelectedXValueColName = cmbXValueColumnName.SelectedItem.ToString

        'Main.Message.Add("XValue column number: " & SelColNo.ToString & vbCrLf)
        'Main.Message.Add("XValue value type: " & DataGridView1.Columns(SelColNo).ValueType.ToString & vbCrLf)

        'XValueType = DataGridView1.Columns(SelColNo).ValueType.ToString
        XValueType = DataGridView1.Columns(SelectedXValueColNo).ValueType.ToString

    End Sub

    Private Sub cmbYValueColumnName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbYValueColumnName.SelectedIndexChanged
        'Dim SelColNo As Integer = cmbYValueColumnName.SelectedIndex
        SelectedYValueColNo = cmbYValueColumnName.SelectedIndex
        SelectedYValueColName = cmbYValueColumnName.SelectedItem.ToString
        'YValueType = DataGridView1.Columns(SelColNo).ValueType.ToString
        YValueType = DataGridView1.Columns(SelectedYValueColNo).ValueType.ToString
    End Sub

    'Private Sub CopyLinRegrData_Click(sender As Object, e As EventArgs)
    '    'Copy selected linear regression data to the Linear Regression form.

    '    If XValueType = "System.String" Then
    '        Main.Message.AddWarning("The X Values are string type. Only date, Single or Double data types can be processed." & vbCrLf)
    '        Exit Sub
    '    End If

    '    If YValueType = "System.String" Then
    '        Main.Message.AddWarning("The Y Values are string type. Only Single or Double data types can be processed." & vbCrLf)
    '        Exit Sub
    '    End If

    '    If YValueType = "System.DateTime" Then
    '        Main.Message.AddWarning("The Y Values are Date type. Only Single or Double data types can be processed." & vbCrLf)
    '        Exit Sub
    '    End If

    '    If XValueType = "System.Single" Then
    '        If YValueType = "System.Single" Then
    '            CopyLinRegrXNumYNumData()
    '        ElseIf YValueType = "System.Double" Then
    '            CopyLinRegrXNumYNumData()
    '        Else
    '            Main.Message.AddWarning("Unknown Y Value data type: " & YValueType & vbCrLf)
    '            Exit Sub
    '        End If
    '    ElseIf XValueType = "System.Double" Then
    '        If YValueType = "System.Single" Then
    '            CopyLinRegrXNumYNumData()
    '        ElseIf YValueType = "System.Double" Then
    '            CopyLinRegrXNumYNumData()
    '        Else
    '            Main.Message.AddWarning("Unknown Y Value data type: " & YValueType & vbCrLf)
    '            Exit Sub
    '        End If
    '    ElseIf XValueType = "System.DateTime" Then
    '        If YValueType = "System.Single" Then
    '            CopyLinRegrXDateYNumData()
    '        ElseIf YValueType = "System.Double" Then
    '            CopyLinRegrXDateYNumData()
    '        Else
    '            Main.Message.AddWarning("Unknown Y Value data type: " & YValueType & vbCrLf)
    '            Exit Sub
    '        End If
    '    Else
    '        Main.Message.AddWarning("Unknown X Value data type: " & XValueType & vbCrLf)
    '        Exit Sub
    '    End If

    'End Sub

    Private Sub CopyLinRegrData()
        'Copy selected linear regression data to the Linear Regression form.

        If XValueType = "System.String" Then
            Main.Message.AddWarning("The X Values are string type. Only date, Single or Double data types can be processed." & vbCrLf)
            Exit Sub
        End If

        If YValueType = "System.String" Then
            Main.Message.AddWarning("The Y Values are string type. Only Single or Double data types can be processed." & vbCrLf)
            Exit Sub
        End If

        If YValueType = "System.DateTime" Then
            Main.Message.AddWarning("The Y Values are Date type. Only Single or Double data types can be processed." & vbCrLf)
            Exit Sub
        End If

        If XValueType = "System.Single" Then
            If YValueType = "System.Single" Then
                CopyLinRegrXNumYNumData()
            ElseIf YValueType = "System.Double" Then
                CopyLinRegrXNumYNumData()
            Else
                Main.Message.AddWarning("Unknown Y Value data type: " & YValueType & vbCrLf)
                Exit Sub
            End If
        ElseIf XValueType = "System.Double" Then
            If YValueType = "System.Single" Then
                CopyLinRegrXNumYNumData()
            ElseIf YValueType = "System.Double" Then
                CopyLinRegrXNumYNumData()
            Else
                Main.Message.AddWarning("Unknown Y Value data type: " & YValueType & vbCrLf)
                Exit Sub
            End If
        ElseIf XValueType = "System.DateTime" Then
            If YValueType = "System.Single" Then
                CopyLinRegrXDateYNumData()
            ElseIf YValueType = "System.Double" Then
                CopyLinRegrXDateYNumData()
            Else
                Main.Message.AddWarning("Unknown Y Value data type: " & YValueType & vbCrLf)
                Exit Sub
            End If
        Else
            Main.Message.AddWarning("Unknown X Value data type: " & XValueType & vbCrLf)
            Exit Sub
        End If
    End Sub

    Private Sub CopyNonLinRegrData()
        'Copy selected non-linear regression data to the Non-Linear Regression form.

        If XValueType = "System.String" Then
            Main.Message.AddWarning("The X Values are string type. Only date, Single or Double data types can be processed." & vbCrLf)
            Exit Sub
        End If

        If YValueType = "System.String" Then
            Main.Message.AddWarning("The Y Values are string type. Only Single or Double data types can be processed." & vbCrLf)
            Exit Sub
        End If

        If YValueType = "System.DateTime" Then
            Main.Message.AddWarning("The Y Values are Date type. Only Single or Double data types can be processed." & vbCrLf)
            Exit Sub
        End If

        If XValueType = "System.Single" Then
            If YValueType = "System.Single" Then
                CopyNonLinRegrXNumYNumData()
            ElseIf YValueType = "System.Double" Then
                CopyNonLinRegrXNumYNumData()
            Else
                Main.Message.AddWarning("Unknown Y Value data type: " & YValueType & vbCrLf)
                Exit Sub
            End If
        ElseIf XValueType = "System.Double" Then
            If YValueType = "System.Single" Then
                CopyNonLinRegrXNumYNumData()
            ElseIf YValueType = "System.Double" Then
                CopyNonLinRegrXNumYNumData()
            Else
                Main.Message.AddWarning("Unknown Y Value data type: " & YValueType & vbCrLf)
                Exit Sub
            End If
        ElseIf XValueType = "System.DateTime" Then
            If YValueType = "System.Single" Then
                CopyNonLinRegrXDateYNumData()
            ElseIf YValueType = "System.Double" Then
                CopyNonLinRegrXDateYNumData()
            Else
                Main.Message.AddWarning("Unknown Y Value data type: " & YValueType & vbCrLf)
                Exit Sub
            End If
        Else
            Main.Message.AddWarning("Unknown X Value data type: " & XValueType & vbCrLf)
            Exit Sub
        End If
    End Sub

    Private Sub CopyLinRegrXNumYNumData()
        'Copy the selected X Number and Y Number values to the Linear Regression form.

        DataGridView1.AllowUserToAddRows = False
        LinearRegr.ClearData()

        For Each Row As DataGridViewRow In DataGridView1.Rows
            LinearRegr.dgvInputPoints.Rows.Add(Row.Cells(SelectedXValueColNo).Value, Row.Cells(SelectedYValueColNo).Value)
            LinearRegr.dgvCalculations.Rows.Add()
            LinearRegr.dgvPredictions.Rows.Add()
        Next
        DataGridView1.AllowUserToAddRows = True

        LinearRegr.txtXName.Text = DataGridView1.Columns(0).HeaderText
        LinearRegr.txtYName.Text = DataGridView1.Columns(1).HeaderText
    End Sub

    Private Sub CopyNonLinRegrXNumYNumData()
        'Copy the selected X Number and Y Number values to the Linear Regression form.

        DataGridView1.AllowUserToAddRows = False
        NonLinRegr.ClearData()

        For Each Row As DataGridViewRow In DataGridView1.Rows
            NonLinRegr.dgvInputPoints.Rows.Add(Row.Cells(SelectedXValueColNo).Value, Row.Cells(SelectedYValueColNo).Value)
            NonLinRegr.dgvTransformedPoints.Rows.Add()
            NonLinRegr.dgvTransCalculations.Rows.Add()
            NonLinRegr.dgvTransPredictions.Rows.Add()
            NonLinRegr.dgvPredictions.Rows.Add()
        Next
        DataGridView1.AllowUserToAddRows = True

        NonLinRegr.txtXName.Text = DataGridView1.Columns(0).HeaderText
        NonLinRegr.txtYName.Text = DataGridView1.Columns(1).HeaderText

    End Sub

    Private Sub CopyLinRegrXDateYNumData()
        'Copy the selected X Date and Y Number values to the Linear Regression form.

        'Int(DateValue.ToOADate)
        DataGridView1.AllowUserToAddRows = False
        LinearRegr.ClearData()
        For Each Row As DataGridViewRow In DataGridView1.Rows
            LinearRegr.dgvInputPoints.Rows.Add(Row.Cells(SelectedXValueColNo).Value.ToOADate, Row.Cells(SelectedYValueColNo).Value)
            LinearRegr.dgvCalculations.Rows.Add()
            LinearRegr.dgvPredictions.Rows.Add()
        Next
        DataGridView1.AllowUserToAddRows = True

        LinearRegr.txtXName.Text = DataGridView1.Columns(0).HeaderText
        LinearRegr.txtXUnits.Text = "Date Number"
        LinearRegr.txtYName.Text = DataGridView1.Columns(1).HeaderText

    End Sub

    Private Sub CopyNonLinRegrXDateYNumData()
        'Copy the selected X Date and Y Number values to the Linear Regression form.

        DataGridView1.AllowUserToAddRows = False
        NonLinRegr.ClearData()

        For Each Row As DataGridViewRow In DataGridView1.Rows
            NonLinRegr.dgvInputPoints.Rows.Add(Row.Cells(SelectedXValueColNo).Value.ToOADate, Row.Cells(SelectedYValueColNo).Value)
            NonLinRegr.dgvTransformedPoints.Rows.Add()
            NonLinRegr.dgvTransCalculations.Rows.Add()
            NonLinRegr.dgvTransPredictions.Rows.Add()
            NonLinRegr.dgvPredictions.Rows.Add()
        Next
        DataGridView1.AllowUserToAddRows = True

        NonLinRegr.txtXName.Text = DataGridView1.Columns(0).HeaderText
        NonLinRegr.txtXUnits.Text = "Date Number"
        NonLinRegr.txtYName.Text = DataGridView1.Columns(1).HeaderText

    End Sub






#End Region 'Form Methods ---------------------------------------------------------------------------------------------------------------------------------------------------------------------







End Class