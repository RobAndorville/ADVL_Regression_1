Public Class frmNonLinRegr
    'Non-Linear Regression

#Region " Variable Declarations - All the variables used in this form and this application." '=================================================================================================

    'Declare Forms used by the application:
    Public WithEvents NonLinRegrChart As frmNonLinRegrChart

    Dim RegressionModel As String 'The name of the regression model (Currently Linear, Log, Exponential & Power)
    Dim TSlope As Double 'The slope of the regression line
    Dim TIntercept As Double 'The intercept of the regression line
    Dim TErrorStdDev As Double 'The standard deviation of the regression error

    Public LoadLastFile As Boolean = True 'If True then load the last data point file.

#End Region 'Variable Declarations ------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Properties - All the properties used in this form and this application" '============================================================================================================

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
                               <FileName><%= txtFileName.Text %></FileName>
                               <RegressionModel><%= cmbRegrModel.SelectedItem.ToString %></RegressionModel>
                               <AutoRegression><%= chkAutoRegression.Checked %></AutoRegression>
                               <AutoPredict><%= chkAutoPredict.Checked %></AutoPredict>
                           </FormSettings>

        'Add code to include other settings to save after the comment line <!---->

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

            If Settings.<FormSettings>.<AutoRegression>.Value <> Nothing Then chkAutoRegression.Checked = Settings.<FormSettings>.<AutoRegression>.Value
            If Settings.<FormSettings>.<AutoPredict>.Value <> Nothing Then chkAutoPredict.Checked = Settings.<FormSettings>.<AutoPredict>.Value



            If Settings.<FormSettings>.<RegressionModel>.Value <> Nothing Then
                cmbRegrModel.SelectedIndex = cmbRegrModel.FindStringExact(Settings.<FormSettings>.<RegressionModel>.Value)
                UpdateTransSelections()
            End If

            'Add code to read other saved setting here:
            If LoadLastFile = True Then
                If Settings.<FormSettings>.<FileName>.Value <> Nothing Then
                    txtFileName.Text = Settings.<FormSettings>.<FileName>.Value
                    OpenFile(txtFileName.Text)
                End If
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
        'RestoreFormSettings()   'Restore the form settings

        Dim TextBoxCol0 As New DataGridViewTextBoxColumn
        dgvInputPoints.Columns.Add(TextBoxCol0)
        dgvInputPoints.Columns(0).HeaderText = "X Values"
        dgvInputPoints.Columns(0).Width = 80

        Dim TextBoxCol1 As New DataGridViewTextBoxColumn
        dgvInputPoints.Columns.Add(TextBoxCol1)
        dgvInputPoints.Columns(1).HeaderText = "Y Values"
        dgvInputPoints.Columns(1).Width = 80


        Dim TextBox2Col0 As New DataGridViewTextBoxColumn
        dgvTransformedPoints.Columns.Add(TextBox2Col0)
        dgvTransformedPoints.Columns(0).HeaderText = "X Values"
        dgvTransformedPoints.Columns(0).Width = 80

        Dim TextBox2Col1 As New DataGridViewTextBoxColumn
        dgvTransformedPoints.Columns.Add(TextBox2Col1)
        dgvTransformedPoints.Columns(1).HeaderText = "Y Values"
        dgvTransformedPoints.Columns(1).Width = 80



        Dim TextBox3Col0 As New DataGridViewTextBoxColumn
        dgvTransCalculations.Columns.Add(TextBox3Col0)
        dgvTransCalculations.Columns(0).HeaderText = "X * X"
        dgvTransCalculations.Columns(0).Width = 80

        Dim TextBox3Col1 As New DataGridViewTextBoxColumn
        dgvTransCalculations.Columns.Add(TextBox3Col1)
        dgvTransCalculations.Columns(1).HeaderText = "X * Y"
        dgvTransCalculations.Columns(1).Width = 80

        Dim TextBox3Col2 As New DataGridViewTextBoxColumn
        dgvTransCalculations.Columns.Add(TextBox3Col2)
        dgvTransCalculations.Columns(2).HeaderText = "Y * Y"
        dgvTransCalculations.Columns(2).Width = 80


        Dim TextBox4Col0 As New DataGridViewTextBoxColumn
        dgvTransPredictions.Columns.Add(TextBox4Col0)
        dgvTransPredictions.Columns(0).HeaderText = "Prediction"
        dgvTransPredictions.Columns(0).Width = 80

        Dim TextBox4Col1 As New DataGridViewTextBoxColumn
        dgvTransPredictions.Columns.Add(TextBox4Col1)
        dgvTransPredictions.Columns(1).HeaderText = "Error"
        dgvTransPredictions.Columns(1).Width = 80

        Dim TextBox4Col2 As New DataGridViewTextBoxColumn
        dgvTransPredictions.Columns.Add(TextBox4Col2)
        dgvTransPredictions.Columns(2).HeaderText = "Sq Error"
        dgvTransPredictions.Columns(2).Width = 80


        Dim TextBox5Col0 As New DataGridViewTextBoxColumn
        dgvPredictions.Columns.Add(TextBox5Col0)
        dgvPredictions.Columns(0).HeaderText = "Prediction"
        dgvPredictions.Columns(0).Width = 80

        Dim TextBox5Col1 As New DataGridViewTextBoxColumn
        dgvPredictions.Columns.Add(TextBox5Col1)
        dgvPredictions.Columns(1).HeaderText = "Error"
        dgvPredictions.Columns(1).Width = 80

        Dim TextBox5Col2 As New DataGridViewTextBoxColumn
        dgvPredictions.Columns.Add(TextBox5Col2)
        dgvPredictions.Columns(2).HeaderText = "Sq Error"
        dgvPredictions.Columns(2).Width = 80


        Dim TextBox6Col0 As New DataGridViewTextBoxColumn
        dgvSpecPredictions.Columns.Add(TextBox6Col0)
        dgvSpecPredictions.Columns(0).HeaderText = "X Value"
        dgvSpecPredictions.Columns(0).Width = 80

        Dim TextBox6Col1 As New DataGridViewTextBoxColumn
        dgvSpecPredictions.Columns.Add(TextBox6Col1)
        dgvSpecPredictions.Columns(1).HeaderText = "Pred Y"
        dgvSpecPredictions.Columns(1).Width = 80


        'Add Regression Model selections:
        cmbRegrModel.Items.Add("Linear")
        cmbRegrModel.Items.Add("Logarithmic")
        cmbRegrModel.Items.Add("Exponential")
        cmbRegrModel.Items.Add("Power")

        'Add x transform selections:
        cmbXTrans.Items.Add("None")
        cmbXTrans.Items.Add("Log")

        'Add y transform selections:
        cmbYTrans.Items.Add("None")
        cmbYTrans.Items.Add("Log")

        cmbRegrModel.SelectedIndex = 0

        RestoreFormSettings()   'Restore the form settings

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Exit the Form
        SavePoints()
        Me.Close() 'Close the form

        If IsNothing(NonLinRegrChart) Then

        Else 'Close the Chart form
            NonLinRegrChart.Close()
        End If
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

    Private Sub btnChart_Click(sender As Object, e As EventArgs) Handles btnChart.Click
        'Open the Chart form:
        If IsNothing(NonLinRegrChart) Then
            NonLinRegrChart = New frmNonLinRegrChart
            NonLinRegrChart.Show()
            ShowTransformedPoints()
            ShowTransformedResiduals()
            ShowUnTransformedPoints()
            ShowUnTransformedResiduals()
        Else
            NonLinRegrChart.Show()
            ShowTransformedPoints()
            ShowTransformedResiduals()
            ShowUnTransformedPoints()
            ShowUnTransformedResiduals()
        End If
    End Sub

    Private Sub NonLinRegrChart_FormClosed(sender As Object, e As FormClosedEventArgs) Handles NonLinRegrChart.FormClosed
        NonLinRegrChart = Nothing
    End Sub

#End Region 'Open and Close Forms -------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region " Form Methods - The main actions performed by this form." '===========================================================================================================================

    Private Sub btnSavePoints_Click(sender As Object, e As EventArgs) Handles btnSavePoints.Click
        'Save the XY points in an XML file.
        SavePoints()

        'Dim FileName As String = ""
        'If LCase(txtFileName.Text).EndsWith("xypoints") Then
        '    FileName = IO.Path.GetFileNameWithoutExtension(txtFileName.Text) & ".XYPoints"
        'ElseIf txtFileName.Text.Contains(".") Then
        '    Main.Message.AddWarning("Unknown file extension: " & IO.Path.GetExtension(txtFileName.Text) & vbCrLf)
        '    Exit Sub
        'Else
        '    FileName = Trim(txtFileName.Text) & ".XYPoints"
        'End If

        'dgvInputPoints.AllowUserToAddRows = False 'This removes the last edit row from the DataGridView.

        'Dim XDoc = <?xml version="1.0" encoding="utf-8"?>
        '           <XYPoints>
        '               <!---->
        '               <!--X, Y Point Set-->
        '               <Name><%= txtDatasetName.Text %></Name>
        '               <Description><%= txtDatasetDescr.Text %></Description>
        '               <YValues>
        '                   <Description><%= txtYDescr.Text %></Description>
        '                   <Name><%= txtYName.Text %></Name>
        '                   <Units><%= txtYUnits.Text %></Units>
        '               </YValues>
        '               <XValues>
        '                   <Description><%= txtXDescr.Text %></Description>
        '                   <Name><%= txtXName.Text %></Name>
        '                   <Units><%= txtXUnits.Text %></Units>
        '               </XValues>
        '               <PointSet>
        '                   <%= From item In dgvInputPoints.Rows
        '                       Select
        '                           <Point>
        '                               <X><%= item.Cells(0).Value %></X>
        '                               <Y><%= item.Cells(1).Value %></Y>
        '                           </Point>
        '                   %>
        '               </PointSet>
        '           </XYPoints>

        'Main.Project.SaveXmlData(FileName, XDoc)

        'dgvInputPoints.AllowUserToAddRows = True 'Add the last edit row to the DataGridView.

    End Sub

    Private Sub SavePoints()
        'Save the XY points in an XML file.

        If txtFileName.Text = "" Then
            'No file name specified
            Main.Message.Add("No Non-Linear Regression Input Points file name specified. Exiting without saving." & vbCrLf)
            Exit Sub
        End If

        Dim FileName As String = ""
        If LCase(txtFileName.Text).EndsWith("xypoints") Then
            FileName = IO.Path.GetFileNameWithoutExtension(txtFileName.Text) & ".XYPoints"
        ElseIf txtFileName.Text.Contains(".") Then
            Main.Message.AddWarning("Unknown file extension: " & IO.Path.GetExtension(txtFileName.Text) & vbCrLf)
            Exit Sub
        Else
            FileName = Trim(txtFileName.Text) & ".XYPoints"
        End If

        dgvInputPoints.AllowUserToAddRows = False 'This removes the last edit row from the DataGridView.
        dgvSpecPredictions.AllowUserToAddRows = False

        Dim XDoc = <?xml version="1.0" encoding="utf-8"?>
                   <XYPoints>
                       <!---->
                       <!--X, Y Point Set-->
                       <Name><%= txtDatasetName.Text %></Name>
                       <Description><%= txtDatasetDescr.Text %></Description>
                       <YValues>
                           <Description><%= txtYDescr.Text %></Description>
                           <Name><%= txtYName.Text %></Name>
                           <Units><%= txtYUnits.Text %></Units>
                       </YValues>
                       <XValues>
                           <Description><%= txtXDescr.Text %></Description>
                           <Name><%= txtXName.Text %></Name>
                           <Units><%= txtXUnits.Text %></Units>
                       </XValues>
                       <PointSet>
                           <%= From item In dgvInputPoints.Rows
                               Select
                                   <Point>
                                       <X><%= item.Cells(0).Value %></X>
                                       <Y><%= item.Cells(1).Value %></Y>
                                   </Point>
                           %>
                       </PointSet>
                       <SpecifiedXValues>
                           <%= From item In dgvSpecPredictions.Rows
                               Select
                               <Value><%= item.Cells(0).Value %></Value>
                           %>
                       </SpecifiedXValues>
                   </XYPoints>

        Main.Project.SaveXmlData(FileName, XDoc)

        dgvInputPoints.AllowUserToAddRows = True 'Add the last edit row to the DataGridView.
        dgvSpecPredictions.AllowUserToAddRows = True
    End Sub

    Private Sub btnOpenPoints_Click(sender As Object, e As EventArgs) Handles btnOpenPoints.Click
        'Open an XY Points file.

        Dim SelectedFileName As String = Main.Project.SelectDataFile("Xy Y Points File", "XYPoints")

        If SelectedFileName = "" Then

        Else
            OpenFile(SelectedFileName)
        End If
    End Sub

    Private Sub OpenFile(ByVal FileName As String)
        'Open the specified XY Points file:

        ClearData()
        txtFileName.Text = FileName

        If Main.Project.DataFileExists(FileName) Then



            Dim XDoc As System.Xml.Linq.XDocument
            Main.Project.ReadXmlData(FileName, XDoc)

            If XDoc.<XYPoints>.<Name>.Value <> Nothing Then txtDatasetName.Text = XDoc.<XYPoints>.<Name>.Value
            If XDoc.<XYPoints>.<Description>.Value <> Nothing Then txtDatasetDescr.Text = XDoc.<XYPoints>.<Description>.Value
            If XDoc.<XYPoints>.<YValues>.<Description>.Value <> Nothing Then txtYDescr.Text = XDoc.<XYPoints>.<YValues>.<Description>.Value
            If XDoc.<XYPoints>.<YValues>.<Name>.Value <> Nothing Then txtYName.Text = XDoc.<XYPoints>.<YValues>.<Name>.Value
            If XDoc.<XYPoints>.<YValues>.<Units>.Value <> Nothing Then txtYUnits.Text = XDoc.<XYPoints>.<YValues>.<Units>.Value
            If XDoc.<XYPoints>.<XValues>.<Description>.Value <> Nothing Then txtXDescr.Text = XDoc.<XYPoints>.<XValues>.<Description>.Value
            If XDoc.<XYPoints>.<XValues>.<Name>.Value <> Nothing Then txtXName.Text = XDoc.<XYPoints>.<XValues>.<Name>.Value
            If XDoc.<XYPoints>.<XValues>.<Units>.Value <> Nothing Then txtXUnits.Text = XDoc.<XYPoints>.<XValues>.<Units>.Value

            Dim Points = From item In XDoc.<XYPoints>.<PointSet>.<Point>

            For Each item In Points
                dgvInputPoints.Rows.Add(item.<X>.Value, item.<Y>.Value)
                dgvTransformedPoints.Rows.Add()
                dgvTransCalculations.Rows.Add()
                dgvTransPredictions.Rows.Add()
                dgvPredictions.Rows.Add()
            Next

            Dim SpecXValues = From item In XDoc.<XYPoints>.<SpecifiedXValues>.<Value>

            For Each item In SpecXValues
                dgvSpecPredictions.Rows.Add(item.Value)
            Next

            dgvInputPoints.AllowUserToAddRows = True
            dgvTransformedPoints.AllowUserToAddRows = True
            dgvTransCalculations.AllowUserToAddRows = True
            dgvTransPredictions.AllowUserToAddRows = True
            dgvPredictions.AllowUserToAddRows = True

            If chkAutoRegression.Checked Then
                ApplyRegression()
                If chkAutoPredict.Checked Then
                    PredictYValues()
                End If
            End If
        Else
            Main.Message.AddWarning("File not found: " & FileName & vbCrLf)
        End If

    End Sub

    Public Sub ClearData()
        'Clear all regression data.

        txtFileName.Text = ""
        txtDatasetDescr.Text = ""
        txtYDescr.Text = ""
        txtYName.Text = ""
        txtYUnits.Text = ""
        txtXDescr.Text = ""
        txtXName.Text = ""
        txtXUnits.Text = ""

        dgvInputPoints.Rows.Clear()
        txtSumX.Text = ""
        txtSumY.Text = ""
        txtMeanX.Text = ""
        txtMeanY.Text = ""

        dgvTransformedPoints.Rows.Clear()
        txtSumTransX.Text = ""
        txtSumTransY.Text = ""
        txtMeanTransX.Text = ""
        txtMeanTransY.Text = ""

        dgvTransCalculations.Rows.Clear()
        txtSumTransXX.Text = ""
        txtSumTransXY.Text = ""
        txtMeanTransXX.Text = ""
        txtMeanTransXY.Text = ""

        dgvTransPredictions.Rows.Clear()
        txtSumTransPred.Text = ""
        txtSumTransError.Text = ""
        txtSumSqTransError.Text = ""
        txtMeanTransPred.Text = ""
        txtMeanTransError.Text = ""
        txtMeanSqTransError.Text = ""

        dgvPredictions.Rows.Clear()
        txtSumPred.Text = ""
        txtSumError.Text = ""
        txtSumSqError.Text = ""
        txtMeanPred.Text = ""
        txtMeanError.Text = ""
        txtMeanSqError.Text = ""

        txtNPoints.Text = ""
        txtRegrSlope.Text = ""
        txtRegrIntercept.Text = ""

    End Sub

    Public Sub PositionSumTextBoxes()
        'Position the sum of values text boxes:

        'Input Data Points section:
        txtSumX.Left = dgvInputPoints.Left + dgvInputPoints.RowHeadersWidth
        txtSumX.Width = dgvInputPoints.Columns(0).Width

        txtMeanX.Left = txtSumX.Left
        txtMeanX.Width = txtSumX.Width

        txtSumY.Left = dgvInputPoints.Left + dgvInputPoints.RowHeadersWidth + dgvInputPoints.Columns(0).Width
        txtSumY.Width = dgvInputPoints.Columns(1).Width

        txtMeanY.Left = txtSumY.Left
        txtMeanY.Width = txtSumY.Width

        'Transformed Points section
        txtSumTransX.Left = dgvTransformedPoints.Left + dgvTransformedPoints.RowHeadersWidth
        txtSumTransX.Width = dgvTransformedPoints.Columns(0).Width

        txtMeanTransX.Left = txtSumTransX.Left
        txtMeanTransX.Width = txtSumTransX.Width

        cmbXTrans.Left = txtSumTransX.Left
        cmbXTrans.Width = txtSumTransX.Width

        txtSumTransY.Left = dgvTransformedPoints.Left + dgvTransformedPoints.RowHeadersWidth + dgvTransformedPoints.Columns(0).Width
        txtSumTransY.Width = dgvTransformedPoints.Columns(1).Width

        txtMeanTransY.Left = txtSumTransY.Left
        txtMeanTransY.Width = txtSumTransY.Width

        cmbYTrans.Left = txtSumTransY.Left
        cmbYTrans.Width = txtSumTransY.Width

        'Transformed Points Calculations section:
        txtSumTransXX.Left = dgvTransCalculations.Left + dgvTransCalculations.RowHeadersWidth
        txtSumTransXX.Width = dgvTransCalculations.Columns(0).Width

        txtMeanTransXX.Left = txtSumTransXX.Left
        txtMeanTransXX.Width = txtSumTransXX.Width

        txtSumTransXY.Left = dgvTransCalculations.Left + dgvTransCalculations.RowHeadersWidth + dgvTransCalculations.Columns(0).Width
        txtSumTransXY.Width = dgvTransCalculations.Columns(1).Width

        txtMeanTransXY.Left = txtSumTransXY.Left
        txtMeanTransXY.Width = txtSumTransXY.Width

        txtSumTransYY.Left = dgvTransCalculations.Left + dgvTransCalculations.RowHeadersWidth + dgvTransCalculations.Columns(0).Width + dgvTransCalculations.Columns(1).Width
        txtSumTransYY.Width = dgvTransCalculations.Columns(1).Width

        txtMeanTransYY.Left = txtSumTransYY.Left
        txtMeanTransYY.Width = txtSumTransYY.Width

        'Transformed Predictions section:
        txtSumTransPred.Left = dgvTransPredictions.Left + dgvTransPredictions.RowHeadersWidth
        txtSumTransPred.Width = dgvTransPredictions.Columns(0).Width

        txtMeanTransPred.Left = txtSumTransPred.Left
        txtMeanTransPred.Width = txtSumTransPred.Width

        txtSumTransError.Left = dgvTransPredictions.Left + dgvTransPredictions.RowHeadersWidth + dgvTransPredictions.Columns(0).Width
        txtSumTransError.Width = dgvTransPredictions.Columns(1).Width

        txtMeanTransError.Left = txtSumTransError.Left
        txtMeanTransError.Width = txtSumTransError.Width

        txtSumSqTransError.Left = dgvTransPredictions.Left + dgvTransPredictions.RowHeadersWidth + dgvTransPredictions.Columns(0).Width + dgvTransPredictions.Columns(1).Width
        txtSumSqTransError.Width = dgvTransPredictions.Columns(2).Width

        txtMeanSqTransError.Left = txtSumSqTransError.Left
        txtMeanSqTransError.Width = txtSumSqTransError.Width

        'Predictions section:
        txtSumPred.Left = dgvPredictions.Left + dgvPredictions.RowHeadersWidth
        txtSumPred.Width = dgvTransPredictions.Columns(0).Width

        txtMeanPred.Left = txtSumPred.Left
        txtMeanPred.Width = txtSumPred.Width

        txtSumError.Left = dgvPredictions.Left + dgvPredictions.RowHeadersWidth + dgvPredictions.Columns(0).Width
        txtSumError.Width = dgvTransPredictions.Columns(1).Width

        txtMeanError.Left = txtSumError.Left
        txtMeanError.Width = txtSumError.Width

        txtSumSqError.Left = dgvPredictions.Left + dgvPredictions.RowHeadersWidth + dgvPredictions.Columns(0).Width + dgvPredictions.Columns(1).Width
        txtSumSqError.Width = dgvPredictions.Columns(2).Width

        txtMeanSqError.Left = txtSumSqError.Left
        txtMeanSqError.Width = txtSumSqError.Width

    End Sub

    Private Sub btnRegression_Click(sender As Object, e As EventArgs) Handles btnRegression.Click
        'Estimate the linear regression parameters:
        ApplyRegression()

        If chkAutoPredict.Checked Then
            PredictYValues()
        End If

    End Sub

    Private Sub ApplyRegression()
        'Estimate the linear regression parameters:

        dgvInputPoints.AllowUserToAddRows = False
        Dim NPoints As Integer = dgvInputPoints.Rows.Count

        If NPoints = 0 Then
            Main.Message.AddWarning("There are no input points to generate the linear regression parameters!")
        Else

            RegressionModel = cmbRegrModel.SelectedItem.ToString 'The regression model used.
            txtRegressionModel.Text = RegressionModel

            'Calculate Transformed Points:
            dgvTransformedPoints.AllowUserToAddRows = False
            'dgvTransformedPoints.Rows.Clear()
            Dim I As Integer

            For I = 0 To NPoints - 1
                'dgvTransformedPoints.Rows.Add(TransX(dgvInputPoints.Rows(I).Cells(0).Value), TransY(dgvInputPoints.Rows(I).Cells(1).Value))
                dgvTransformedPoints.Rows(I).SetValues(TransX(dgvInputPoints.Rows(I).Cells(0).Value), TransY(dgvInputPoints.Rows(I).Cells(1).Value))
            Next


            dgvTransCalculations.AllowUserToAddRows = False
            'dgvTransCalculations.Rows.Clear()

            Dim X As Double
            Dim Y As Double
            Dim SumX As Double = 0
            Dim SumY As Double = 0

            Dim TX As Double
            Dim TY As Double
            Dim SumTX As Double = 0
            Dim SumTY As Double = 0
            Dim SumTXX As Double = 0
            Dim SumTYY As Double = 0
            Dim SumTXY As Double = 0
            For I = 0 To NPoints - 1
                'Input Points calculations:
                X = dgvInputPoints.Rows(I).Cells(0).Value
                Y = dgvInputPoints.Rows(I).Cells(1).Value
                SumX += X
                SumY += Y

                'Transformed Points calculations
                TX = dgvTransformedPoints.Rows(I).Cells(0).Value
                TY = dgvTransformedPoints.Rows(I).Cells(1).Value
                SumTX += TX
                SumTY += TY
                SumTXX += TX * TX
                SumTYY += TY * TY
                SumTXY += TX * TY
                'dgvTransCalculations.Rows.Add(TX * TX, TX * TY, TY * TY)
                dgvTransCalculations.Rows(I).SetValues(TX * TX, TX * TY, TY * TY)
            Next
            dgvTransformedPoints.AllowUserToAddRows = True
            dgvTransCalculations.AllowUserToAddRows = True
            txtSumX.Text = SumX
            txtMeanX.Text = SumX / NPoints
            txtSumY.Text = SumY
            txtMeanY.Text = SumY / NPoints

            txtSumTransX.Text = SumTX
            txtMeanTransX.Text = SumTX / NPoints
            txtSumTransY.Text = SumTY
            txtMeanTransY.Text = SumTY / NPoints

            txtSumTransXX.Text = SumTXX
            txtMeanTransXX.Text = SumTXX / NPoints
            txtSumTransXY.Text = SumTXY
            txtMeanTransXY.Text = SumTXY / NPoints
            txtSumTransYY.Text = SumTYY
            txtMeanTransYY.Text = SumTYY / NPoints

            txtNPoints.Text = NPoints

            Dim SSTxy As Double = SumTXY - (SumTX * SumTY) / NPoints
            Dim SSTxx As Double = SumTXX - (SumTX * SumTX) / NPoints
            'Dim TSlope As Double = SSTxy / SSTxx
            'Slope = TSlope 'Save the linear regression parameter for use later.
            TSlope = SSTxy / SSTxx
            txtRegrSlope.Text = TSlope
            'Dim TIntercept As Double = (SumTY / NPoints) - (TSlope * (SumTX / NPoints))
            'Intercept = TIntercept 'Save the linear regression parameter for use later.
            TIntercept = (SumTY / NPoints) - (TSlope * (SumTX / NPoints))
            txtRegrIntercept.Text = TIntercept
            'Calculate the Sample Linear Correlation Coefficient (r)
            Dim TR As Double = (NPoints * SumTXY - SumTX * SumTY) / ((NPoints * SumTXX - SumTX * SumTX) * (NPoints * SumTYY - SumTY * SumTY)) ^ 0.5
            txtCorrelation.Text = TR

            'Fill Transformed Predictions Table and the Predictions Table:
            dgvTransPredictions.AllowUserToAddRows = False
            'dgvTransPredictions.Rows.Clear()
            dgvPredictions.AllowUserToAddRows = False
            'dgvPredictions.Rows.Clear()
            Dim TPrediction As Double 'The prediction generated using the transformed data
            Dim Prediction As Double ' The un-transformed TPrediction value
            Dim SumTPred As Double = 0 'The sum of the transformed data predictions
            Dim SumPred As Double = 0 'The sum of the un-transformed predictions
            Dim TPredError As Double 'The transformed data prediction error
            Dim PredError As Double 'The un-transformed data prediction error
            Dim SumTPredError As Double = 0 'The sum of the transformed data prediction errors
            Dim SumPredError As Double = 0 'The sum of the un-transformed data prediction errors
            Dim TSquaredError As Double 'The squared transformed data prediction errors
            Dim SquaredError As Double 'The squared un-transformed data prediction errors
            Dim TSumSqError As Double = 0 'The sum of the squared transformed data prediction errors
            Dim SumSqError As Double = 0 'The sum of the squared un-transformed data prediction errors

            For I = 0 To NPoints - 1
                TX = dgvTransformedPoints.Rows(I).Cells(0).Value
                TY = dgvTransformedPoints.Rows(I).Cells(1).Value
                TPrediction = TIntercept + TSlope * TX
                Prediction = UnTransY(TPrediction)
                SumTPred += TPrediction
                SumPred += Prediction
                TPredError = TY - TPrediction
                Y = dgvInputPoints.Rows(I).Cells(1).Value
                PredError = Y - Prediction
                SumTPredError += TPredError
                SumPredError += PredError
                TSquaredError = TPredError * TPredError
                SquaredError = PredError * PredError
                'dgvTransPredictions.Rows.Add(TPrediction, TPredError, TSquaredError)
                dgvTransPredictions.Rows(I).SetValues(TPrediction, TPredError, TSquaredError)
                'dgvPredictions.Rows.Add(Prediction, PredError, SquaredError)
                dgvPredictions.Rows(I).SetValues(Prediction, PredError, SquaredError)
                TSumSqError += TSquaredError
                SumSqError += SquaredError
            Next
            txtSumTransPred.Text = SumTPred
            txtMeanTransPred.Text = SumTPred / NPoints
            txtSumTransError.Text = SumTPredError
            txtMeanTransError.Text = SumTPredError / NPoints
            txtSumSqTransError.Text = TSumSqError
            txtMeanSqTransError.Text = TSumSqError / NPoints
            'ErrorStdDev = (TSumSqError / NPoints) ^ 0.5
            TErrorStdDev = (TSumSqError / NPoints) ^ 0.5
            'txtErrorStdDev.Text = ErrorStdDev
            txtErrorStdDev.Text = TErrorStdDev

            txtSumPred.Text = SumPred
            txtMeanPred.Text = SumPred / NPoints
            txtSumError.Text = SumPredError
            txtMeanError.Text = SumPredError / NPoints
            txtSumSqError.Text = SumSqError
            txtMeanSqError.Text = SumSqError / NPoints
            Dim UTErrorStdDev As Double = (SumSqError / NPoints) ^ 0.5
            txtUTErrorStdDev.Text = UTErrorStdDev

            dgvTransPredictions.AllowUserToAddRows = True
            dgvPredictions.AllowUserToAddRows = True

        End If

        dgvInputPoints.AllowUserToAddRows = True
    End Sub

    'Private Sub ApplyRegression_Old()
    '    'Estimate the linear regression parameters:

    '    dgvInputPoints.AllowUserToAddRows = False
    '    Dim NPoints As Integer = dgvInputPoints.Rows.Count

    '    If NPoints = 0 Then
    '        Main.Message.AddWarning("There are no input points to generate the linear regression parameters!")
    '    Else

    '        RegressionModel = cmbRegrModel.SelectedItem.ToString 'The regression model used.

    '        'Calculate Transformed Points:
    '        dgvTransformedPoints.AllowUserToAddRows = False
    '        dgvTransformedPoints.Rows.Clear()
    '        Dim I As Integer

    '        For I = 0 To NPoints - 1
    '            dgvTransformedPoints.Rows.Add(TransX(dgvInputPoints.Rows(I).Cells(0).Value), TransY(dgvInputPoints.Rows(I).Cells(1).Value))
    '        Next


    '        dgvTransCalculations.AllowUserToAddRows = False
    '        'dgvTransCalculations.Rows.Clear()

    '        Dim X As Single
    '        Dim Y As Single
    '        Dim SumX As Single = 0
    '        Dim SumY As Single = 0

    '        Dim TX As Single
    '        Dim TY As Single
    '        Dim SumTX As Single = 0
    '        Dim SumTY As Single = 0
    '        Dim SumTXX As Single = 0
    '        Dim SumTYY As Single = 0
    '        Dim SumTXY As Single = 0
    '        For I = 0 To NPoints - 1
    '            'Input Points calculations:
    '            X = dgvInputPoints.Rows(I).Cells(0).Value
    '            Y = dgvInputPoints.Rows(I).Cells(1).Value
    '            SumX += X
    '            SumY += Y

    '            'Transformed Points calculations
    '            TX = dgvTransformedPoints.Rows(I).Cells(0).Value
    '            TY = dgvTransformedPoints.Rows(I).Cells(1).Value
    '            SumTX += TX
    '            SumTY += TY
    '            SumTXX += TX * TX
    '            SumTYY += TY * TY
    '            SumTXY += TX * TY
    '            'dgvTransCalculations.Rows.Add(TX * TX, TX * TY, TY * TY)
    '            dgvTransCalculations.Rows(I).SetValues(TX * TX, TX * TY, TY * TY)
    '        Next
    '        dgvTransformedPoints.AllowUserToAddRows = True
    '        dgvTransCalculations.AllowUserToAddRows = True
    '        txtSumX.Text = SumX
    '        txtMeanX.Text = SumX / NPoints
    '        txtSumY.Text = SumY
    '        txtMeanY.Text = SumY / NPoints

    '        txtSumTransX.Text = SumTX
    '        txtMeanTransX.Text = SumTX / NPoints
    '        txtSumTransY.Text = SumTY
    '        txtMeanTransY.Text = SumTY / NPoints

    '        txtSumTransXX.Text = SumTXX
    '        txtMeanTransXX.Text = SumTXX / NPoints
    '        txtSumTransXY.Text = SumTXY
    '        txtMeanTransXY.Text = SumTXY / NPoints
    '        txtSumTransYY.Text = SumTYY
    '        txtMeanTransYY.Text = SumTYY / NPoints

    '        txtNPoints.Text = NPoints

    '        Dim SSTxy As Single = SumTXY - (SumTX * SumTY) / NPoints
    '        Dim SSTxx As Single = SumTXX - (SumTX * SumTX) / NPoints
    '        Dim TSlope As Single = SSTxy / SSTxx
    '        Slope = TSlope 'Save the linear regression parameter for use later.
    '        txtRegrSlope.Text = TSlope
    '        Dim TIntercept As Single = (SumTY / NPoints) - (TSlope * (SumTX / NPoints))
    '        Intercept = TIntercept 'Save the linear regression parameter for use later.
    '        txtRegrIntercept.Text = TIntercept
    '        'Calculate the Sample Linear Correlation Coefficient (r)
    '        Dim TR As Single = (NPoints * SumTXY - SumTX * SumTY) / ((NPoints * SumTXX - SumTX * SumTX) * (NPoints * SumTYY - SumTY * SumTY)) ^ 0.5
    '        txtCorrelation.Text = TR

    '        'Fill Transformed Predictions Table and the Predictions Table:
    '        dgvTransPredictions.AllowUserToAddRows = False
    '        'dgvTransPredictions.Rows.Clear()
    '        dgvPredictions.AllowUserToAddRows = False
    '        'dgvPredictions.Rows.Clear()
    '        Dim TPrediction As Single 'The prediction generated using the transformed data
    '        Dim Prediction As Single ' The un-transformed TPrediction value
    '        Dim SumTPred As Single = 0 'The sum of the transformed data predictions
    '        Dim SumPred As Single = 0 'The sum of the un-transformed predictions
    '        Dim TPredError As Single 'The transformed data prediction error
    '        Dim PredError As Single 'The un-transformed data prediction error
    '        Dim SumTPredError As Single = 0 'The sum of the transformed data prediction errors
    '        Dim SumPredError As Single = 0 'The sum of the un-transformed data prediction errors
    '        Dim TSquaredError As Single 'The squared transformed data prediction errors
    '        Dim SquaredError As Single 'The squared un-transformed data prediction errors
    '        Dim TSumSqError As Single = 0 'The sum of the squared transformed data prediction errors
    '        Dim SumSqError As Single = 0 'The sum of the squared un-transformed data prediction errors

    '        For I = 0 To NPoints - 1
    '            TX = dgvTransformedPoints.Rows(I).Cells(0).Value
    '            TY = dgvTransformedPoints.Rows(I).Cells(1).Value
    '            TPrediction = TIntercept + TSlope * TX
    '            Prediction = UnTransY(TPrediction)
    '            SumTPred += TPrediction
    '            SumPred += Prediction
    '            TPredError = TY - TPrediction
    '            Y = dgvInputPoints.Rows(I).Cells(1).Value
    '            PredError = Y - Prediction
    '            SumTPredError += TPredError
    '            SumPredError += PredError
    '            TSquaredError = TPredError * TPredError
    '            SquaredError = PredError * PredError
    '            'dgvTransPredictions.Rows.Add(TPrediction, TPredError, TSquaredError)
    '            dgvTransPredictions.Rows(I).SetValues(TPrediction, TPredError, TSquaredError)
    '            'dgvPredictions.Rows.Add(Prediction, PredError, SquaredError)
    '            dgvPredictions.Rows(I).SetValues(Prediction, PredError, SquaredError)
    '            TSumSqError += TSquaredError
    '            SumSqError += SquaredError
    '        Next
    '        txtSumTransPred.Text = SumTPred
    '        txtMeanTransPred.Text = SumTPred / NPoints
    '        txtSumTransError.Text = SumTPredError
    '        txtMeanTransError.Text = SumTPredError / NPoints
    '        txtSumSqTransError.Text = TSumSqError
    '        txtMeanSqTransError.Text = TSumSqError / NPoints
    '        ErrorStdDev = (TSumSqError / NPoints) ^ 0.5
    '        txtErrorStdDev.Text = ErrorStdDev

    '        txtSumPred.Text = SumPred
    '        txtMeanPred.Text = SumPred / NPoints
    '        txtSumError.Text = SumPredError
    '        txtMeanError.Text = SumPredError / NPoints
    '        txtSumSqError.Text = SumSqError
    '        txtMeanSqError.Text = SumSqError / NPoints
    '        Dim UTErrorStdDev As Single = (SumSqError / NPoints) ^ 0.5
    '        txtUTErrorStdDev.Text = UTErrorStdDev

    '        dgvTransPredictions.AllowUserToAddRows = True
    '        dgvPredictions.AllowUserToAddRows = True

    '    End If

    '    dgvInputPoints.AllowUserToAddRows = True
    'End Sub

    Private Function TransX(ByVal InputVal As Single) As Single
        'Return a transformed x value:
        Select Case cmbXTrans.SelectedItem.ToString
            Case "None"
                Return InputVal
            Case "Log"
                Return Math.Log(InputVal)
        End Select
    End Function

    Private Function TransY(ByVal InputVal As Single) As Single
        'Return a transformed y value:
        Select Case cmbYTrans.SelectedItem.ToString
            Case "None"
                Return InputVal
            Case "Log"
                Return Math.Log(InputVal)
        End Select
    End Function

    Private Function UnTransX(ByVal TransVal As Single) As Single
        'Return an un-transformed x value:
        Select Case cmbXTrans.SelectedItem.ToString
            Case "None"
                Return TransVal
            Case "Log"
                Return Math.Exp(TransVal)
        End Select
    End Function

    Private Function UnTransY(ByVal TransVal As Single) As Single
        'Return an un-transformed y value:
        Select Case cmbYTrans.SelectedItem.ToString
            Case "None"
                Return TransVal
            Case "Log"
                Return Math.Exp(TransVal)
        End Select
    End Function

    Private Function PredictY(ByVal XValue As Single) As Single
        'Predict a Y value from the given X value.
        'The regression line for the transformed points is: TransY = Intercept + Slope * TransX
        'The function UnTransY converts the TransY value back to a Y value.

        'Return UnTransY(Intercept + Slope * TransX(XValue))
        Return UnTransY(TIntercept + TSlope * TransX(XValue))
    End Function

    Private Function StdDevPredictY(ByVal XValue As Single, ByVal StdDevTransY As Single) As Single
        'Get a Y value 1 error standard deviation from the predicted Y value.
        'StdDevTransY is the standard deviation of errors from the linear model derived from the transformed data.

        'Return UnTransY(Intercept + Slope * TransX(XValue) - StdDevTransY)
        Return UnTransY(TIntercept + TSlope * TransX(XValue) - StdDevTransY)
    End Function

    Private Sub dgvInputPoints_Scroll(sender As Object, e As ScrollEventArgs) Handles dgvInputPoints.Scroll
        'Align the other DataGridViews:
        If e.ScrollOrientation = ScrollOrientation.VerticalScroll Then
            dgvTransformedPoints.FirstDisplayedScrollingRowIndex = dgvInputPoints.FirstDisplayedScrollingRowIndex  'Align the scroll settings of dgvTransformedPoints.
            dgvTransCalculations.FirstDisplayedScrollingRowIndex = dgvInputPoints.FirstDisplayedScrollingRowIndex  'Align the scroll settings of dgvCalculations.
            dgvTransPredictions.FirstDisplayedScrollingRowIndex = dgvInputPoints.FirstDisplayedScrollingRowIndex  'Align the scroll settings of dgvTransPredictions.
            dgvPredictions.FirstDisplayedScrollingRowIndex = dgvInputPoints.FirstDisplayedScrollingRowIndex  'Align the scroll settings of dgvPredictions.
        End If
    End Sub

    Private Sub dgvTransformedPoints_Scroll(sender As Object, e As ScrollEventArgs) Handles dgvTransformedPoints.Scroll
        'Align the other DataGridViews:
        If e.ScrollOrientation = ScrollOrientation.VerticalScroll Then
            dgvInputPoints.FirstDisplayedScrollingRowIndex = dgvTransformedPoints.FirstDisplayedScrollingRowIndex  'Align the scroll settings of dgvInputPoints.
            dgvTransCalculations.FirstDisplayedScrollingRowIndex = dgvTransformedPoints.FirstDisplayedScrollingRowIndex  'Align the scroll settings of dgvCalculations.
            dgvTransPredictions.FirstDisplayedScrollingRowIndex = dgvTransformedPoints.FirstDisplayedScrollingRowIndex  'Align the scroll settings of dgvTransPredictions.
            dgvPredictions.FirstDisplayedScrollingRowIndex = dgvTransformedPoints.FirstDisplayedScrollingRowIndex  'Align the scroll settings of dgvPredictions.
        End If
    End Sub

    Private Sub dgvTransCalculations_Scroll(sender As Object, e As ScrollEventArgs) Handles dgvTransCalculations.Scroll

        If e.ScrollOrientation = ScrollOrientation.VerticalScroll Then
            dgvInputPoints.FirstDisplayedScrollingRowIndex = dgvTransCalculations.FirstDisplayedScrollingRowIndex  'Align the scroll settings of dgvInputPoints.
            dgvTransformedPoints.FirstDisplayedScrollingRowIndex = dgvTransCalculations.FirstDisplayedScrollingRowIndex  'Align the scroll settings of dgvTransformedPoints.
            dgvTransPredictions.FirstDisplayedScrollingRowIndex = dgvTransCalculations.FirstDisplayedScrollingRowIndex  'Align the scroll settings of dgvTransPredictions.
            dgvPredictions.FirstDisplayedScrollingRowIndex = dgvTransCalculations.FirstDisplayedScrollingRowIndex  'Align the scroll settings of dgvPredictions.
        End If
    End Sub

    Private Sub dgvTransPredictions_Scroll(sender As Object, e As ScrollEventArgs) Handles dgvTransPredictions.Scroll
        'Align the other DataGridViews
        If e.ScrollOrientation = ScrollOrientation.VerticalScroll Then
            dgvInputPoints.FirstDisplayedScrollingRowIndex = dgvTransPredictions.FirstDisplayedScrollingRowIndex  'Align the scroll settings of dgvInputPoints.
            dgvTransformedPoints.FirstDisplayedScrollingRowIndex = dgvTransPredictions.FirstDisplayedScrollingRowIndex  'Align the scroll settings of dgvTransformedPoints.
            dgvTransCalculations.FirstDisplayedScrollingRowIndex = dgvTransPredictions.FirstDisplayedScrollingRowIndex  'Align the scroll settings of dgvCalculations.
            dgvPredictions.FirstDisplayedScrollingRowIndex = dgvTransPredictions.FirstDisplayedScrollingRowIndex  'Align the scroll settings of dgvPredictions.
        End If
    End Sub

    Private Sub dgvPredictions_Scroll(sender As Object, e As ScrollEventArgs) Handles dgvPredictions.Scroll
        'Align the other DataGridViews:
        If e.ScrollOrientation = ScrollOrientation.VerticalScroll Then
            dgvInputPoints.FirstDisplayedScrollingRowIndex = dgvPredictions.FirstDisplayedScrollingRowIndex  'Align the scroll settings of dgvInputPoints.
            dgvInputPoints.FirstDisplayedScrollingRowIndex = dgvPredictions.FirstDisplayedScrollingRowIndex  'Align the scroll settings of dgvInputPoints.
            dgvTransformedPoints.FirstDisplayedScrollingRowIndex = dgvPredictions.FirstDisplayedScrollingRowIndex  'Align the scroll settings of dgvTransformedPoints.
            dgvTransCalculations.FirstDisplayedScrollingRowIndex = dgvPredictions.FirstDisplayedScrollingRowIndex  'Align the scroll settings of dgvCalculations.
        End If
    End Sub



    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearData()
    End Sub

    'Public Sub ShowInputPoints()
    Public Sub ShowTransformedPoints()
        'Show the Input Points on the Regression chart on the LinRegrChart form.

        If NonLinRegrChart Is Nothing Then
            'The Non-Linear Regression Chart form is not open!
        Else
            'Set up data series in the chtTransRegression chart:
            NonLinRegrChart.chtTransRegression.Series.Clear()
            NonLinRegrChart.chtTransRegression.Series.Add("Transformed Points")
            NonLinRegrChart.chtTransRegression.Series("Transformed Points").YValuesPerPoint = 1
            NonLinRegrChart.chtTransRegression.Series("Transformed Points").ChartType = DataVisualization.Charting.SeriesChartType.Point

            'Add chart label:
            If NonLinRegrChart.chtTransRegression.Titles.IndexOf("Label1") = -1 Then 'Label "Label1" does not exist
                NonLinRegrChart.chtTransRegression.Titles.Add("Label1").Name = "Label1"
            End If
            NonLinRegrChart.chtTransRegression.Titles("Label1").Text = txtDatasetName.Text
            Dim LabelFontStyle As FontStyle = FontStyle.Regular
            NonLinRegrChart.chtTransRegression.Titles("Label1").Font = New Font("Arial", 12, LabelFontStyle)
            NonLinRegrChart.chtTransRegression.Titles("Label1").Alignment = ContentAlignment.TopCenter

            'Set up the X and Y axes:
            'NonLinRegrChart.chtTransRegression.ChartAreas(0).RecalculateAxesScale()
            NonLinRegrChart.chtTransRegression.ChartAreas(0).AxisX.Minimum = [Double].NaN
            NonLinRegrChart.chtTransRegression.ChartAreas(0).AxisX.Maximum = [Double].NaN

            NonLinRegrChart.chtTransRegression.ChartAreas(0).AxisX.Interval = 0
            NonLinRegrChart.chtTransRegression.ChartAreas(0).AxisX.MajorGrid.Interval = 0
            NonLinRegrChart.chtTransRegression.ChartAreas(0).AxisX.RoundAxisValues()
            NonLinRegrChart.chtTransRegression.ChartAreas(0).AxisX.IsStartedFromZero = False

            NonLinRegrChart.chtTransRegression.ChartAreas(0).AxisY.Minimum = [Double].NaN
            NonLinRegrChart.chtTransRegression.ChartAreas(0).AxisY.Maximum = [Double].NaN
            NonLinRegrChart.chtTransRegression.ChartAreas(0).AxisY.LabelStyle.Format = "F3" 'Added 1Sep19 - Fixed point with 3 decimal places
            NonLinRegrChart.chtTransRegression.ChartAreas(0).AxisY.IsStartedFromZero = False

            'Add the X Axis label:
            NonLinRegrChart.chtTransRegression.ChartAreas(0).AxisX.TitleFont = New Font("Arial", 10, LabelFontStyle)
            NonLinRegrChart.chtTransRegression.ChartAreas(0).AxisX.Title = txtXName.Text & " (" & txtXUnits.Text & ")"
            NonLinRegrChart.chtTransRegression.ChartAreas(0).AxisX.TitleAlignment = StringAlignment.Center

            'Add the Y Axis label:
            NonLinRegrChart.chtTransRegression.ChartAreas(0).AxisY.TitleFont = New Font("Arial", 10, LabelFontStyle)
            NonLinRegrChart.chtTransRegression.ChartAreas(0).AxisY.Title = txtYName.Text & " (" & txtYUnits.Text & ")"
            NonLinRegrChart.chtTransRegression.ChartAreas(0).AxisY.TextOrientation = DataVisualization.Charting.TextOrientation.Rotated270
            NonLinRegrChart.chtTransRegression.ChartAreas(0).AxisY.TitleAlignment = StringAlignment.Center

            'Specify the point symbols:
            NonLinRegrChart.chtTransRegression.Series("Transformed Points").MarkerColor = Color.Blue
            NonLinRegrChart.chtTransRegression.Series("Transformed Points").MarkerSize = 8
            NonLinRegrChart.chtTransRegression.Series("Transformed Points").MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle

            dgvInputPoints.AllowUserToAddRows = False
            dgvTransformedPoints.AllowUserToAddRows = False
            Dim NPoints As Integer = dgvInputPoints.Rows.Count
            Dim I As Integer
            Dim TX As Single
            Dim TY As Single

            For I = 0 To NPoints - 1
                TX = dgvTransformedPoints.Rows(I).Cells(0).Value
                TY = dgvTransformedPoints.Rows(I).Cells(1).Value
                NonLinRegrChart.chtTransRegression.Series("Transformed Points").Points.AddXY(TX, TY)
            Next

            'dgvInputPoints.AllowUserToAddRows = True
            dgvTransformedPoints.AllowUserToAddRows = True

            'Show regression line:
            NonLinRegrChart.chtTransRegression.Series.Add("Transformed Regression")
            NonLinRegrChart.chtTransRegression.Series("Transformed Regression").ChartType = DataVisualization.Charting.SeriesChartType.Line

            NonLinRegrChart.chtTransRegression.ChartAreas(0).RecalculateAxesScale()
            Dim FirstX As Single = NonLinRegrChart.chtTransRegression.ChartAreas(0).AxisX.Minimum
            Dim LastX As Single = NonLinRegrChart.chtTransRegression.ChartAreas(0).AxisX.Maximum
            Dim FirstY As Single = Val(txtRegrIntercept.Text) + Val(txtRegrSlope.Text) * FirstX
            Dim LastY As Single = Val(txtRegrIntercept.Text) + Val(txtRegrSlope.Text) * LastX

            Dim AxisYMin As Single = NonLinRegrChart.chtTransRegression.ChartAreas(0).AxisY.Minimum
            Dim AxisYMax As Single = NonLinRegrChart.chtTransRegression.ChartAreas(0).AxisY.Maximum

            NonLinRegrChart.chtTransRegression.ChartAreas(0).AxisX.Minimum = FirstX
            NonLinRegrChart.chtTransRegression.ChartAreas(0).AxisX.Maximum = LastX
            NonLinRegrChart.chtTransRegression.ChartAreas(0).AxisY.Minimum = AxisYMin
            NonLinRegrChart.chtTransRegression.ChartAreas(0).AxisY.Maximum = AxisYMax

            'Specify the line style:
            NonLinRegrChart.chtTransRegression.Series("Transformed Regression").Color = Color.Black
            NonLinRegrChart.chtTransRegression.Series("Transformed Regression").BorderWidth = 2


            'Add the line end points:
            NonLinRegrChart.chtTransRegression.Series("Transformed Regression").Points.AddXY(FirstX, FirstY)
            NonLinRegrChart.chtTransRegression.Series("Transformed Regression").Points.AddXY(LastX, LastY)

            'Add the forecast points:
            NonLinRegrChart.chtTransRegression.Series.Add("Trans Input Forecast")
            NonLinRegrChart.chtTransRegression.Series("Trans Input Forecast").YValuesPerPoint = 1
            NonLinRegrChart.chtTransRegression.Series("Trans Input Forecast").ChartType = DataVisualization.Charting.SeriesChartType.Point

            'Specify the point symbols:
            NonLinRegrChart.chtTransRegression.Series("Trans Input Forecast").MarkerColor = Color.Red
            NonLinRegrChart.chtTransRegression.Series("Trans Input Forecast").MarkerBorderWidth = 1.5
            NonLinRegrChart.chtTransRegression.Series("Trans Input Forecast").MarkerSize = 12
            NonLinRegrChart.chtTransRegression.Series("Trans Input Forecast").MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle
            NonLinRegrChart.chtTransRegression.Series("Trans Input Forecast").MarkerBorderColor = Color.Red
            NonLinRegrChart.chtTransRegression.Series("Trans Input Forecast").MarkerColor = Color.Transparent

            'Add the Forecast points:
            For I = 0 To NPoints - 1
                TX = dgvTransformedPoints.Rows(I).Cells(0).Value
                TY = dgvTransPredictions.Rows(I).Cells(0).Value
                NonLinRegrChart.chtTransRegression.Series("Trans Input Forecast").Points.AddXY(TX, TY)
            Next

            NonLinRegrChart.chtTransRegression.ChartAreas(0).RecalculateAxesScale()

            'Show upper standard deviation line:
            NonLinRegrChart.chtTransRegression.Series.Add("Transformed Std Dev +")
            NonLinRegrChart.chtTransRegression.Series("Transformed Std Dev +").ChartType = DataVisualization.Charting.SeriesChartType.Line

            FirstY = Val(txtRegrIntercept.Text) + Val(txtErrorStdDev.Text) + Val(txtRegrSlope.Text) * FirstX
            LastY = Val(txtRegrIntercept.Text) + Val(txtErrorStdDev.Text) + Val(txtRegrSlope.Text) * LastX

            'Specify the line style:
            NonLinRegrChart.chtTransRegression.Series("Transformed Std Dev +").Color = Color.Gray
            NonLinRegrChart.chtTransRegression.Series("Transformed Std Dev +").BorderWidth = 2
            NonLinRegrChart.chtTransRegression.Series("Transformed Std Dev +").BorderDashStyle = DataVisualization.Charting.ChartDashStyle.Dash

            'Add the line end points:
            NonLinRegrChart.chtTransRegression.Series("Transformed Std Dev +").Points.AddXY(FirstX, FirstY)
            NonLinRegrChart.chtTransRegression.Series("Transformed Std Dev +").Points.AddXY(LastX, LastY)


            'Show lower standard deviation line:
            NonLinRegrChart.chtTransRegression.Series.Add("Transformed Std Dev -")
            NonLinRegrChart.chtTransRegression.Series("Transformed Std Dev -").ChartType = DataVisualization.Charting.SeriesChartType.Line

            FirstY = Val(txtRegrIntercept.Text) - Val(txtErrorStdDev.Text) + Val(txtRegrSlope.Text) * FirstX
            LastY = Val(txtRegrIntercept.Text) - Val(txtErrorStdDev.Text) + Val(txtRegrSlope.Text) * LastX

            'Specify the line style:
            NonLinRegrChart.chtTransRegression.Series("Transformed Std Dev -").Color = Color.Gray
            NonLinRegrChart.chtTransRegression.Series("Transformed Std Dev -").BorderWidth = 2
            NonLinRegrChart.chtTransRegression.Series("Transformed Std Dev -").BorderDashStyle = DataVisualization.Charting.ChartDashStyle.Dash

            'Add the line end points:
            NonLinRegrChart.chtTransRegression.Series("Transformed Std Dev -").Points.AddXY(FirstX, FirstY)
            NonLinRegrChart.chtTransRegression.Series("Transformed Std Dev -").Points.AddXY(LastX, LastY)

            'NonLinRegrChart.chtTransRegression.ChartAreas(0).RecalculateAxesScale()

            'Add the specific forecast points: -------------------------------------------------------------------------------------------------------------------
            NonLinRegrChart.chtTransRegression.Series.Add("Forecast")
            NonLinRegrChart.chtTransRegression.Series("Forecast").YValuesPerPoint = 1
            NonLinRegrChart.chtTransRegression.Series("Forecast").ChartType = DataVisualization.Charting.SeriesChartType.Point

            'Specify the point symbols:
            NonLinRegrChart.chtTransRegression.Series("Forecast").MarkerColor = Color.Green
            NonLinRegrChart.chtTransRegression.Series("Forecast").MarkerBorderWidth = 1.5
            NonLinRegrChart.chtTransRegression.Series("Forecast").MarkerSize = 18
            NonLinRegrChart.chtTransRegression.Series("Forecast").MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle
            NonLinRegrChart.chtTransRegression.Series("Forecast").MarkerBorderColor = Color.Green
            NonLinRegrChart.chtTransRegression.Series("Forecast").MarkerColor = Color.Transparent

            'Add the Specific Forecast points:
            dgvSpecPredictions.AllowUserToAddRows = False
            NPoints = dgvSpecPredictions.Rows.Count
            For I = 0 To NPoints - 1
                NonLinRegrChart.chtTransRegression.Series("Forecast").Points.AddXY(TransX(dgvSpecPredictions.Rows(I).Cells(0).Value), TransY(dgvSpecPredictions.Rows(I).Cells(1).Value))
            Next
            dgvSpecPredictions.AllowUserToAddRows = True

        End If

    End Sub

    Public Sub ShowTransformedResiduals()
        'Show the Input Points on the Residuals chart on the LinRegrChart form.

        If NonLinRegrChart Is Nothing Then
            'The Linear Regression Chart form is not open!
        Else
            'Set up data series in the chtRegression chart:
            NonLinRegrChart.chtTransResiduals.Series.Clear()
            NonLinRegrChart.chtTransResiduals.Series.Add("Transformed Residuals")
            NonLinRegrChart.chtTransResiduals.Series("Transformed Residuals").YValuesPerPoint = 1
            NonLinRegrChart.chtTransResiduals.Series("Transformed Residuals").ChartType = DataVisualization.Charting.SeriesChartType.Point

            'Add chart label:
            If NonLinRegrChart.chtTransResiduals.Titles.IndexOf("Label1") = -1 Then 'Label "Label1" does not exist
                NonLinRegrChart.chtTransResiduals.Titles.Add("Label1").Name = "Label1"
            End If
            NonLinRegrChart.chtTransResiduals.Titles("Label1").Text = "Linear Regression Residuals"
            Dim LabelFontStyle As FontStyle = FontStyle.Regular
            NonLinRegrChart.chtTransResiduals.Titles("Label1").Font = New Font("Arial", 12, LabelFontStyle)
            NonLinRegrChart.chtTransResiduals.Titles("Label1").Alignment = ContentAlignment.TopCenter

            'Set up the X and Y axes:
            'NonLinRegrChart.chtTransResiduals.ChartAreas(0).RecalculateAxesScale()
            NonLinRegrChart.chtTransResiduals.ChartAreas(0).AxisX.Minimum = [Double].NaN
            NonLinRegrChart.chtTransResiduals.ChartAreas(0).AxisX.Maximum = [Double].NaN

            NonLinRegrChart.chtTransResiduals.ChartAreas(0).AxisX.Interval = 0
            NonLinRegrChart.chtTransResiduals.ChartAreas(0).AxisX.MajorGrid.Interval = 0
            NonLinRegrChart.chtTransResiduals.ChartAreas(0).AxisX.RoundAxisValues()
            NonLinRegrChart.chtTransResiduals.ChartAreas(0).AxisX.IsStartedFromZero = False


            NonLinRegrChart.chtTransResiduals.ChartAreas(0).AxisY.Minimum = [Double].NaN
            NonLinRegrChart.chtTransResiduals.ChartAreas(0).AxisY.Maximum = [Double].NaN
            'NonLinRegrChart.chtTransResiduals.ChartAreas(0).AxisY.RoundAxisValues() 'Added 1Sep19
            NonLinRegrChart.chtTransResiduals.ChartAreas(0).AxisY.LabelStyle.Format = "F3" 'Added 1Sep19 - Fixed point with 3 decimal places
            NonLinRegrChart.chtTransResiduals.ChartAreas(0).AxisY.IsStartedFromZero = False

            'Add the X Axis label:
            NonLinRegrChart.chtTransResiduals.ChartAreas(0).AxisX.TitleFont = New Font("Arial", 10, LabelFontStyle)
            NonLinRegrChart.chtTransResiduals.ChartAreas(0).AxisX.Title = txtXName.Text & " (" & txtXUnits.Text & ")"
            NonLinRegrChart.chtTransResiduals.ChartAreas(0).AxisX.TitleAlignment = StringAlignment.Center

            'Add the Y Axis label:
            NonLinRegrChart.chtTransResiduals.ChartAreas(0).AxisY.TitleFont = New Font("Arial", 10, LabelFontStyle)
            NonLinRegrChart.chtTransResiduals.ChartAreas(0).AxisY.Title = txtYName.Text & " (" & txtYUnits.Text & ")"
            NonLinRegrChart.chtTransResiduals.ChartAreas(0).AxisY.TextOrientation = DataVisualization.Charting.TextOrientation.Rotated270
            NonLinRegrChart.chtTransResiduals.ChartAreas(0).AxisY.TitleAlignment = StringAlignment.Center

            'Specify the point symbols:
            NonLinRegrChart.chtTransResiduals.Series("Transformed Residuals").MarkerColor = Color.Blue
            NonLinRegrChart.chtTransResiduals.Series("Transformed Residuals").MarkerSize = 8
            NonLinRegrChart.chtTransResiduals.Series("Transformed Residuals").MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle

            dgvTransPredictions.AllowUserToAddRows = False
            Dim NPoints As Integer = dgvTransPredictions.Rows.Count 'Assume dgvInputPoints has the same number of rows!
            Dim I As Integer
            Dim TX As Single
            Dim TY As Single

            For I = 0 To NPoints - 1
                TX = dgvTransformedPoints.Rows(I).Cells(0).Value
                TY = dgvTransPredictions.Rows(I).Cells(1).Value
                NonLinRegrChart.chtTransResiduals.Series("Transformed Residuals").Points.AddXY(TX, TY)
            Next

            dgvTransPredictions.AllowUserToAddRows = True

            'Add the X Axis line at Y = 0:
            NonLinRegrChart.chtTransResiduals.Series.Add("Zero")
            NonLinRegrChart.chtTransResiduals.Series("Zero").ChartType = DataVisualization.Charting.SeriesChartType.Line

            NonLinRegrChart.chtTransResiduals.ChartAreas(0).RecalculateAxesScale()
            Dim FirstX As Single = NonLinRegrChart.chtTransResiduals.ChartAreas(0).AxisX.Minimum
            Dim LastX As Single = NonLinRegrChart.chtTransResiduals.ChartAreas(0).AxisX.Maximum
            Dim FirstY As Single = NonLinRegrChart.chtTransResiduals.ChartAreas(0).AxisY.Minimum
            Dim LastY As Single = NonLinRegrChart.chtTransResiduals.ChartAreas(0).AxisY.Maximum

            NonLinRegrChart.chtTransResiduals.ChartAreas(0).AxisX.Minimum = FirstX
            NonLinRegrChart.chtTransResiduals.ChartAreas(0).AxisX.Maximum = LastX
            NonLinRegrChart.chtTransResiduals.ChartAreas(0).AxisY.Minimum = FirstY
            NonLinRegrChart.chtTransResiduals.ChartAreas(0).AxisY.Maximum = LastY

            'NonLinRegrChart.chtTransResiduals.ChartAreas(0).AxisY.RoundAxisValues() 'Added 1Sep19

            'Specify the line style:
            NonLinRegrChart.chtTransResiduals.Series("Zero").Color = Color.Black
            NonLinRegrChart.chtTransResiduals.Series("Zero").BorderWidth = 2

            'Add the line end points:
            NonLinRegrChart.chtTransResiduals.Series("Zero").Points.AddXY(FirstX, 0)
            NonLinRegrChart.chtTransResiduals.Series("Zero").Points.AddXY(LastX, 0)

            'Show upper standard deviation line:
            NonLinRegrChart.chtTransResiduals.Series.Add("Std Dev +")
            NonLinRegrChart.chtTransResiduals.Series("Std Dev +").ChartType = DataVisualization.Charting.SeriesChartType.Line

            FirstY = Val(txtErrorStdDev.Text)
            LastY = Val(txtErrorStdDev.Text)

            'Specify the line style:
            NonLinRegrChart.chtTransResiduals.Series("Std Dev +").Color = Color.Gray
            NonLinRegrChart.chtTransResiduals.Series("Std Dev +").BorderWidth = 2
            NonLinRegrChart.chtTransResiduals.Series("Std Dev +").BorderDashStyle = DataVisualization.Charting.ChartDashStyle.Dash

            'Add the line end points:
            NonLinRegrChart.chtTransResiduals.Series("Std Dev +").Points.AddXY(FirstX, FirstY)
            NonLinRegrChart.chtTransResiduals.Series("Std Dev +").Points.AddXY(LastX, LastY)


            'Show lower standard deviation line:
            NonLinRegrChart.chtTransResiduals.Series.Add("Std Dev -")
            NonLinRegrChart.chtTransResiduals.Series("Std Dev -").ChartType = DataVisualization.Charting.SeriesChartType.Line

            FirstY = -Val(txtErrorStdDev.Text)
            LastY = -Val(txtErrorStdDev.Text)

            'Specify the line style:
            NonLinRegrChart.chtTransResiduals.Series("Std Dev -").Color = Color.Gray
            NonLinRegrChart.chtTransResiduals.Series("Std Dev -").BorderWidth = 2
            NonLinRegrChart.chtTransResiduals.Series("Std Dev -").BorderDashStyle = DataVisualization.Charting.ChartDashStyle.Dash

            'Add the line end points:
            NonLinRegrChart.chtTransResiduals.Series("Std Dev -").Points.AddXY(FirstX, FirstY)
            NonLinRegrChart.chtTransResiduals.Series("Std Dev -").Points.AddXY(LastX, LastY)

            'NonLinRegrChart.chtTransResiduals.ChartAreas(0).RecalculateAxesScale()
            'NonLinRegrChart.chtTransResiduals.ChartAreas(0).AxisY.RoundAxisValues() 'Added 1Sep19

        End If

    End Sub

    Public Sub ShowUnTransformedPoints()
        'Show the Input Points on the Regression chart on the LinRegrChart form.

        If NonLinRegrChart Is Nothing Then
            'The Non-Linear Regression Chart form is not open!
        Else
            'Set up data series in the chtRegression chart:
            NonLinRegrChart.chtRegression.Series.Clear()
            NonLinRegrChart.chtRegression.Series.Add("Points")
            NonLinRegrChart.chtRegression.Series("Points").YValuesPerPoint = 1
            NonLinRegrChart.chtRegression.Series("Points").ChartType = DataVisualization.Charting.SeriesChartType.Point

            'Add chart label:
            If NonLinRegrChart.chtRegression.Titles.IndexOf("Label1") = -1 Then 'Label "Label1" does not exist
                NonLinRegrChart.chtRegression.Titles.Add("Label1").Name = "Label1"
            End If
            NonLinRegrChart.chtRegression.Titles("Label1").Text = txtDatasetName.Text
            Dim LabelFontStyle As FontStyle = FontStyle.Regular
            NonLinRegrChart.chtRegression.Titles("Label1").Font = New Font("Arial", 12, LabelFontStyle)
            NonLinRegrChart.chtRegression.Titles("Label1").Alignment = ContentAlignment.TopCenter

            'Set up the X and Y axes:
            'NonLinRegrChart.chtTransRegression.ChartAreas(0).RecalculateAxesScale()
            NonLinRegrChart.chtRegression.ChartAreas(0).AxisX.Minimum = [Double].NaN
            NonLinRegrChart.chtRegression.ChartAreas(0).AxisX.Maximum = [Double].NaN

            NonLinRegrChart.chtRegression.ChartAreas(0).AxisX.Interval = 0
            NonLinRegrChart.chtRegression.ChartAreas(0).AxisX.MajorGrid.Interval = 0
            NonLinRegrChart.chtRegression.ChartAreas(0).AxisX.RoundAxisValues()
            NonLinRegrChart.chtRegression.ChartAreas(0).AxisX.IsStartedFromZero = False

            NonLinRegrChart.chtRegression.ChartAreas(0).AxisY.Minimum = [Double].NaN
            NonLinRegrChart.chtRegression.ChartAreas(0).AxisY.Maximum = [Double].NaN
            NonLinRegrChart.chtRegression.ChartAreas(0).AxisY.IsStartedFromZero = False

            'Add the X Axis label:
            NonLinRegrChart.chtRegression.ChartAreas(0).AxisX.TitleFont = New Font("Arial", 10, LabelFontStyle)
            NonLinRegrChart.chtRegression.ChartAreas(0).AxisX.Title = txtXName.Text & " (" & txtXUnits.Text & ")"
            NonLinRegrChart.chtRegression.ChartAreas(0).AxisX.TitleAlignment = StringAlignment.Center

            'Add the Y Axis label:
            NonLinRegrChart.chtRegression.ChartAreas(0).AxisY.TitleFont = New Font("Arial", 10, LabelFontStyle)
            NonLinRegrChart.chtRegression.ChartAreas(0).AxisY.Title = txtYName.Text & " (" & txtYUnits.Text & ")"
            NonLinRegrChart.chtRegression.ChartAreas(0).AxisY.TextOrientation = DataVisualization.Charting.TextOrientation.Rotated270
            NonLinRegrChart.chtRegression.ChartAreas(0).AxisY.TitleAlignment = StringAlignment.Center

            'Specify the point symbols:
            NonLinRegrChart.chtRegression.Series("Points").MarkerColor = Color.Blue
            NonLinRegrChart.chtRegression.Series("Points").MarkerSize = 8
            NonLinRegrChart.chtRegression.Series("Points").MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle

            dgvInputPoints.AllowUserToAddRows = False
            'dgvTransformedPoints.AllowUserToAddRows = False
            Dim NPoints As Integer = dgvInputPoints.Rows.Count
            Dim I As Integer
            'Dim TX As Single
            'Dim TY As Single
            Dim X As Single
            Dim Y As Single

            For I = 0 To NPoints - 1
                'TX = dgvTransformedPoints.Rows(I).Cells(0).Value
                'TY = dgvTransformedPoints.Rows(I).Cells(1).Value
                X = dgvInputPoints.Rows(I).Cells(0).Value
                Y = dgvInputPoints.Rows(I).Cells(1).Value
                'NonLinRegrChart.chtRegression.Series("Points").Points.AddXY(TX, TY)
                NonLinRegrChart.chtRegression.Series("Points").Points.AddXY(X, Y)
            Next

            dgvInputPoints.AllowUserToAddRows = True
            'dgvTransformedPoints.AllowUserToAddRows = True

            'Show regression line:
            NonLinRegrChart.chtRegression.Series.Add("Regression")
            NonLinRegrChart.chtRegression.Series("Regression").ChartType = DataVisualization.Charting.SeriesChartType.Line

            'Also show upper standard deviation line:
            NonLinRegrChart.chtRegression.Series.Add("Std Dev +")
            NonLinRegrChart.chtRegression.Series("Std Dev +").ChartType = DataVisualization.Charting.SeriesChartType.Line

            'and show lower standard deviation line:
            NonLinRegrChart.chtRegression.Series.Add("Std Dev -")
            NonLinRegrChart.chtRegression.Series("Std Dev -").ChartType = DataVisualization.Charting.SeriesChartType.Line


            NonLinRegrChart.chtRegression.ChartAreas(0).RecalculateAxesScale()
            Dim FirstX As Single = NonLinRegrChart.chtRegression.ChartAreas(0).AxisX.Minimum
            Dim LastX As Single = NonLinRegrChart.chtRegression.ChartAreas(0).AxisX.Maximum
            'Dim FirstY As Single = Val(txtRegrIntercept.Text) + Val(txtRegrSlope.Text) * FirstX
            Dim FirstY As Single = PredictY(FirstX)
            'Dim LastY As Single = Val(txtRegrIntercept.Text) + Val(txtRegrSlope.Text) * LastX
            Dim LastY As Single = PredictY(LastX)

            Dim AxisYMin As Single = NonLinRegrChart.chtRegression.ChartAreas(0).AxisY.Minimum
            Dim AxisYMax As Single = NonLinRegrChart.chtRegression.ChartAreas(0).AxisY.Maximum

            NonLinRegrChart.chtRegression.ChartAreas(0).AxisX.Minimum = FirstX
            NonLinRegrChart.chtRegression.ChartAreas(0).AxisX.Maximum = LastX
            NonLinRegrChart.chtRegression.ChartAreas(0).AxisY.Minimum = AxisYMin
            NonLinRegrChart.chtRegression.ChartAreas(0).AxisY.Maximum = AxisYMax

            'Specify the line style:
            NonLinRegrChart.chtRegression.Series("Regression").Color = Color.Black
            NonLinRegrChart.chtRegression.Series("Regression").BorderWidth = 2


            ''Add the line end points:
            'NonLinRegrChart.chtRegression.Series("Regression").Points.AddXY(FirstX, FirstY)
            'NonLinRegrChart.chtRegression.Series("Regression").Points.AddXY(LastX, LastY)

            'Add the first regression line point:
            NonLinRegrChart.chtRegression.Series("Regression").Points.AddXY(FirstX, FirstY)
            'Main.Message.Add("Regression line points:" & vbCrLf)
            'Main.Message.Add("First x = " & FirstX & "  First y = " & FirstY & vbCrLf)

            'Add the first regression error upper standard deviation line point:
            'NonLinRegrChart.chtRegression.Series("Std Dev -").Points.AddXY(FirstX, StdDevPredictY(FirstX, -ErrorStdDev))
            NonLinRegrChart.chtRegression.Series("Std Dev -").Points.AddXY(FirstX, StdDevPredictY(FirstX, -TErrorStdDev))
            'Add the first regression error lower standard deviation line point:
            'NonLinRegrChart.chtRegression.Series("Std Dev +").Points.AddXY(FirstX, StdDevPredictY(FirstX, ErrorStdDev))
            NonLinRegrChart.chtRegression.Series("Std Dev +").Points.AddXY(FirstX, StdDevPredictY(FirstX, TErrorStdDev))

            'Add a set of points in between to define the regression line, which is only straight if the regression model is linear:
            Dim NRegrPts As Integer = 20
            Dim Incr As Single = (LastX - FirstX) / (NRegrPts - 1)
            Dim XVal As Single
            For I = 1 To NRegrPts - 1
                XVal = FirstX + I * Incr
                NonLinRegrChart.chtRegression.Series("Regression").Points.AddXY(XVal, PredictY(XVal))
                'Main.Message.Add("x = " & XVal & "  y = " & PredictY(XVal) & vbCrLf)
                'NonLinRegrChart.chtRegression.Series("Std Dev -").Points.AddXY(XVal, StdDevPredictY(XVal, -ErrorStdDev))
                NonLinRegrChart.chtRegression.Series("Std Dev -").Points.AddXY(XVal, StdDevPredictY(XVal, -TErrorStdDev))
                'NonLinRegrChart.chtRegression.Series("Std Dev +").Points.AddXY(XVal, StdDevPredictY(XVal, ErrorStdDev))
                NonLinRegrChart.chtRegression.Series("Std Dev +").Points.AddXY(XVal, StdDevPredictY(XVal, TErrorStdDev))
            Next


            'Add the last regression line points:
            NonLinRegrChart.chtRegression.Series("Regression").Points.AddXY(LastX, LastY)
            'Main.Message.Add("Last x = " & LastX & "  Last y = " & LastY & vbCrLf)

            'Add the last regression error upper standard deviation line point:
            'NonLinRegrChart.chtRegression.Series("Std Dev -").Points.AddXY(LastX, StdDevPredictY(LastX, -ErrorStdDev))
            NonLinRegrChart.chtRegression.Series("Std Dev -").Points.AddXY(LastX, StdDevPredictY(LastX, -TErrorStdDev))
            'Add the flast regression error lower standard deviation line point:
            'NonLinRegrChart.chtRegression.Series("Std Dev +").Points.AddXY(LastX, StdDevPredictY(LastX, ErrorStdDev))
            NonLinRegrChart.chtRegression.Series("Std Dev +").Points.AddXY(LastX, StdDevPredictY(LastX, TErrorStdDev))


            'Add the forecast points:
            NonLinRegrChart.chtRegression.Series.Add("Input Forecast")
            NonLinRegrChart.chtRegression.Series("Input Forecast").YValuesPerPoint = 1
            NonLinRegrChart.chtRegression.Series("Input Forecast").ChartType = DataVisualization.Charting.SeriesChartType.Point

            'Specify the point symbols:
            NonLinRegrChart.chtRegression.Series("Input Forecast").MarkerColor = Color.Red
            NonLinRegrChart.chtRegression.Series("Input Forecast").MarkerBorderWidth = 1.5
            NonLinRegrChart.chtRegression.Series("Input Forecast").MarkerSize = 12
            NonLinRegrChart.chtRegression.Series("Input Forecast").MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle
            NonLinRegrChart.chtRegression.Series("Input Forecast").MarkerBorderColor = Color.Red
            NonLinRegrChart.chtRegression.Series("Input Forecast").MarkerColor = Color.Transparent

            'Add the Forecast points:
            For I = 0 To NPoints - 1
                'TX = dgvTransformedPoints.Rows(I).Cells(0).Value
                'TY = dgvTransPredictions.Rows(I).Cells(0).Value
                X = dgvInputPoints.Rows(I).Cells(0).Value
                Y = dgvPredictions.Rows(I).Cells(0).Value
                'NonLinRegrChart.chtRegression.Series("Forecast").Points.AddXY(TX, TY)
                NonLinRegrChart.chtRegression.Series("Input Forecast").Points.AddXY(X, Y)
            Next

            NonLinRegrChart.chtRegression.ChartAreas(0).RecalculateAxesScale()

            ''Show upper standard deviation line:
            'NonLinRegrChart.chtRegression.Series.Add("Std Dev +")
            'NonLinRegrChart.chtRegression.Series("Std Dev +").ChartType = DataVisualization.Charting.SeriesChartType.Line

            'FirstY = Val(txtRegrIntercept.Text) + Val(txtErrorStdDev.Text) + Val(txtRegrSlope.Text) * FirstX
            'LastY = Val(txtRegrIntercept.Text) + Val(txtErrorStdDev.Text) + Val(txtRegrSlope.Text) * LastX

            'Specify the line style:
            NonLinRegrChart.chtRegression.Series("Std Dev +").Color = Color.Gray
            NonLinRegrChart.chtRegression.Series("Std Dev +").BorderWidth = 2
            NonLinRegrChart.chtRegression.Series("Std Dev +").BorderDashStyle = DataVisualization.Charting.ChartDashStyle.Dash

            ''Add the line end points:
            'NonLinRegrChart.chtRegression.Series("Std Dev +").Points.AddXY(FirstX, FirstY)
            'NonLinRegrChart.chtRegression.Series("Std Dev +").Points.AddXY(LastX, LastY)


            ''Show lower standard deviation line:
            'NonLinRegrChart.chtRegression.Series.Add("Std Dev -")
            'NonLinRegrChart.chtRegression.Series("Std Dev -").ChartType = DataVisualization.Charting.SeriesChartType.Line

            'FirstY = Val(txtRegrIntercept.Text) - Val(txtErrorStdDev.Text) + Val(txtRegrSlope.Text) * FirstX
            'LastY = Val(txtRegrIntercept.Text) - Val(txtErrorStdDev.Text) + Val(txtRegrSlope.Text) * LastX

            'Specify the line style:
            NonLinRegrChart.chtRegression.Series("Std Dev -").Color = Color.Gray
            NonLinRegrChart.chtRegression.Series("Std Dev -").BorderWidth = 2
            NonLinRegrChart.chtRegression.Series("Std Dev -").BorderDashStyle = DataVisualization.Charting.ChartDashStyle.Dash

            ''Add the line end points:
            'NonLinRegrChart.chtRegression.Series("Std Dev -").Points.AddXY(FirstX, FirstY)
            'NonLinRegrChart.chtRegression.Series("Std Dev -").Points.AddXY(LastX, LastY)


            'Add the specific forecast points: -------------------------------------------------------------------------------------------------------------------
            NonLinRegrChart.chtRegression.Series.Add("Forecast")
            NonLinRegrChart.chtRegression.Series("Forecast").YValuesPerPoint = 1
            NonLinRegrChart.chtRegression.Series("Forecast").ChartType = DataVisualization.Charting.SeriesChartType.Point

            'Specify the point symbols:
            NonLinRegrChart.chtRegression.Series("Forecast").MarkerColor = Color.Green
            NonLinRegrChart.chtRegression.Series("Forecast").MarkerBorderWidth = 1.5
            NonLinRegrChart.chtRegression.Series("Forecast").MarkerSize = 18
            NonLinRegrChart.chtRegression.Series("Forecast").MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle
            NonLinRegrChart.chtRegression.Series("Forecast").MarkerBorderColor = Color.Green
            NonLinRegrChart.chtRegression.Series("Forecast").MarkerColor = Color.Transparent

            'Add the Specific Forecast points:
            dgvSpecPredictions.AllowUserToAddRows = False
            NPoints = dgvSpecPredictions.Rows.Count
            For I = 0 To NPoints - 1
                'X = dgvInputPoints.Rows(I).Cells(0).Value
                'Y = dgvPredictions.Rows(I).Cells(0).Value
                'LinearRegrChart.chtRegression.Series("Forecast").Points.AddXY(X, Y)
                X = dgvSpecPredictions.Rows(I).Cells(0).Value
                Y = dgvSpecPredictions.Rows(I).Cells(1).Value
                NonLinRegrChart.chtRegression.Series("Forecast").Points.AddXY(X, Y)
            Next
            dgvSpecPredictions.AllowUserToAddRows = True

        End If

    End Sub

    Public Sub ShowUnTransformedResiduals()
        'Show the Input Points on the Residuals chart on the LinRegrChart form.

        If NonLinRegrChart Is Nothing Then
            'The Non-Linear Regression Chart form is not open!
        Else
            'Set up data series in the chtRegression chart:
            NonLinRegrChart.chtResiduals.Series.Clear()
            NonLinRegrChart.chtResiduals.Series.Add("Residuals")
            NonLinRegrChart.chtResiduals.Series("Residuals").YValuesPerPoint = 1
            NonLinRegrChart.chtResiduals.Series("Residuals").ChartType = DataVisualization.Charting.SeriesChartType.Point

            'Add chart label:
            If NonLinRegrChart.chtResiduals.Titles.IndexOf("Label1") = -1 Then 'Label "Label1" does not exist
                NonLinRegrChart.chtResiduals.Titles.Add("Label1").Name = "Label1"
            End If
            NonLinRegrChart.chtResiduals.Titles("Label1").Text = "Linear Regression Residuals"
            Dim LabelFontStyle As FontStyle = FontStyle.Regular
            NonLinRegrChart.chtResiduals.Titles("Label1").Font = New Font("Arial", 12, LabelFontStyle)
            NonLinRegrChart.chtResiduals.Titles("Label1").Alignment = ContentAlignment.TopCenter

            'Set up the X and Y axes:
            'NonLinRegrChart.chtTransResiduals.ChartAreas(0).RecalculateAxesScale()
            NonLinRegrChart.chtResiduals.ChartAreas(0).AxisX.Minimum = [Double].NaN
            NonLinRegrChart.chtResiduals.ChartAreas(0).AxisX.Maximum = [Double].NaN

            NonLinRegrChart.chtResiduals.ChartAreas(0).AxisX.Interval = 0
            NonLinRegrChart.chtResiduals.ChartAreas(0).AxisX.MajorGrid.Interval = 0
            NonLinRegrChart.chtResiduals.ChartAreas(0).AxisX.RoundAxisValues()
            NonLinRegrChart.chtResiduals.ChartAreas(0).AxisX.IsStartedFromZero = False


            NonLinRegrChart.chtResiduals.ChartAreas(0).AxisY.Minimum = [Double].NaN
            NonLinRegrChart.chtResiduals.ChartAreas(0).AxisY.Maximum = [Double].NaN
            NonLinRegrChart.chtResiduals.ChartAreas(0).AxisY.IsStartedFromZero = False

            'Add the X Axis label:
            NonLinRegrChart.chtResiduals.ChartAreas(0).AxisX.TitleFont = New Font("Arial", 10, LabelFontStyle)
            NonLinRegrChart.chtResiduals.ChartAreas(0).AxisX.Title = txtXName.Text & " (" & txtXUnits.Text & ")"
            NonLinRegrChart.chtResiduals.ChartAreas(0).AxisX.TitleAlignment = StringAlignment.Center

            'Add the Y Axis label:
            NonLinRegrChart.chtResiduals.ChartAreas(0).AxisY.TitleFont = New Font("Arial", 10, LabelFontStyle)
            NonLinRegrChart.chtResiduals.ChartAreas(0).AxisY.Title = txtYName.Text & " (" & txtYUnits.Text & ")"
            NonLinRegrChart.chtResiduals.ChartAreas(0).AxisY.TextOrientation = DataVisualization.Charting.TextOrientation.Rotated270
            NonLinRegrChart.chtResiduals.ChartAreas(0).AxisY.TitleAlignment = StringAlignment.Center

            'Specify the point symbols:
            NonLinRegrChart.chtResiduals.Series("Residuals").MarkerColor = Color.Blue
            NonLinRegrChart.chtResiduals.Series("Residuals").MarkerSize = 8
            NonLinRegrChart.chtResiduals.Series("Residuals").MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle

            dgvTransPredictions.AllowUserToAddRows = False
            Dim NPoints As Integer = dgvTransPredictions.Rows.Count 'Assume dgvInputPoints has the same number of rows!
            Dim I As Integer
            'Dim TX As Single
            'Dim TY As Single
            Dim X As Single
            Dim Y As Single

            For I = 0 To NPoints - 1
                'TX = dgvTransformedPoints.Rows(I).Cells(0).Value
                'TY = dgvTransPredictions.Rows(I).Cells(1).Value
                'NonLinRegrChart.chtResiduals.Series("Residuals").Points.AddXY(TX, TY)
                X = dgvInputPoints.Rows(I).Cells(0).Value
                Y = dgvPredictions.Rows(I).Cells(1).Value 'Prediction Error
                NonLinRegrChart.chtResiduals.Series("Residuals").Points.AddXY(X, Y)
            Next

            dgvTransPredictions.AllowUserToAddRows = True

            'Add the X Axis line at Y = 0:
            NonLinRegrChart.chtResiduals.Series.Add("Zero")
            NonLinRegrChart.chtResiduals.Series("Zero").ChartType = DataVisualization.Charting.SeriesChartType.Line

            NonLinRegrChart.chtResiduals.ChartAreas(0).RecalculateAxesScale()
            Dim FirstX As Single = NonLinRegrChart.chtResiduals.ChartAreas(0).AxisX.Minimum
            Dim LastX As Single = NonLinRegrChart.chtResiduals.ChartAreas(0).AxisX.Maximum
            Dim FirstY As Single = NonLinRegrChart.chtResiduals.ChartAreas(0).AxisY.Minimum
            Dim LastY As Single = NonLinRegrChart.chtResiduals.ChartAreas(0).AxisY.Maximum

            NonLinRegrChart.chtResiduals.ChartAreas(0).AxisX.Minimum = FirstX
            NonLinRegrChart.chtResiduals.ChartAreas(0).AxisX.Maximum = LastX
            NonLinRegrChart.chtResiduals.ChartAreas(0).AxisY.Minimum = FirstY
            NonLinRegrChart.chtResiduals.ChartAreas(0).AxisY.Maximum = LastY

            'Specify the line style:
            NonLinRegrChart.chtResiduals.Series("Zero").Color = Color.Black
            NonLinRegrChart.chtResiduals.Series("Zero").BorderWidth = 2

            'Add the line end points:
            NonLinRegrChart.chtResiduals.Series("Zero").Points.AddXY(FirstX, 0)
            NonLinRegrChart.chtResiduals.Series("Zero").Points.AddXY(LastX, 0)

            'Show upper standard deviation line:
            NonLinRegrChart.chtResiduals.Series.Add("Std Dev +")
            NonLinRegrChart.chtResiduals.Series("Std Dev +").ChartType = DataVisualization.Charting.SeriesChartType.Line

            'FirstY = Val(txtErrorStdDev.Text)
            'LastY = Val(txtErrorStdDev.Text)

            'Specify the line style:
            NonLinRegrChart.chtResiduals.Series("Std Dev +").Color = Color.Gray
            NonLinRegrChart.chtResiduals.Series("Std Dev +").BorderWidth = 2
            NonLinRegrChart.chtResiduals.Series("Std Dev +").BorderDashStyle = DataVisualization.Charting.ChartDashStyle.Dash

            ''Add the line end points:
            'NonLinRegrChart.chtResiduals.Series("Std Dev +").Points.AddXY(FirstX, FirstY)
            'NonLinRegrChart.chtResiduals.Series("Std Dev +").Points.AddXY(LastX, LastY)


            'Show lower standard deviation line:
            NonLinRegrChart.chtResiduals.Series.Add("Std Dev -")
            NonLinRegrChart.chtResiduals.Series("Std Dev -").ChartType = DataVisualization.Charting.SeriesChartType.Line

            'FirstY = -Val(txtErrorStdDev.Text)
            'LastY = -Val(txtErrorStdDev.Text)

            'Specify the line style:
            NonLinRegrChart.chtResiduals.Series("Std Dev -").Color = Color.Gray
            NonLinRegrChart.chtResiduals.Series("Std Dev -").BorderWidth = 2
            NonLinRegrChart.chtResiduals.Series("Std Dev -").BorderDashStyle = DataVisualization.Charting.ChartDashStyle.Dash

            ''Add the line end points:
            'NonLinRegrChart.chtResiduals.Series("Std Dev -").Points.AddXY(FirstX, FirstY)
            'NonLinRegrChart.chtResiduals.Series("Std Dev -").Points.AddXY(LastX, LastY)

            'Add the upper and lower standard deviation lines
            'FirstX is the X coordinate of the first point on the upper and lower Std Dev residual line
            Dim UStdDev As Single 'The upper standard deviation of the residuals
            'UStdDev = StdDevPredictY(FirstX, -ErrorStdDev) - PredictY(FirstX)
            UStdDev = StdDevPredictY(FirstX, -TErrorStdDev) - PredictY(FirstX)
            NonLinRegrChart.chtResiduals.Series("Std Dev -").Points.AddXY(FirstX, UStdDev) 'Add the first point in the upper standard deviation of residuals line

            Dim LStdDev As Single 'The lower standard deviation of the residuals
            'LStdDev = StdDevPredictY(FirstX, ErrorStdDev) - PredictY(FirstX)
            LStdDev = StdDevPredictY(FirstX, TErrorStdDev) - PredictY(FirstX)
            NonLinRegrChart.chtResiduals.Series("Std Dev +").Points.AddXY(FirstX, LStdDev) 'Add the first point in the lower standard deviation of residuals line

            'Add the middle points of the upper and lower standard deviation of residuals:
            Dim NStdDevPts As Integer = 20 'Add 20 points in the middle (This can be changed)
            Dim Incr As Single = (LastX - FirstX) / (NStdDevPts - 1)
            Dim XVal As Single
            For I = 1 To NStdDevPts - 1
                XVal = FirstX + I * Incr
                'UStdDev = StdDevPredictY(XVal, -ErrorStdDev) - PredictY(XVal)
                UStdDev = StdDevPredictY(XVal, -TErrorStdDev) - PredictY(XVal)
                NonLinRegrChart.chtResiduals.Series("Std Dev -").Points.AddXY(XVal, UStdDev)
                'LStdDev = StdDevPredictY(XVal, ErrorStdDev) - PredictY(XVal)
                LStdDev = StdDevPredictY(XVal, TErrorStdDev) - PredictY(XVal)
                NonLinRegrChart.chtResiduals.Series("Std Dev +").Points.AddXY(XVal, LStdDev)
            Next


            'LastX is the X coordinate of the last point on the upper and lower Std Dev residual line
            'UStdDev = StdDevPredictY(LastX, -ErrorStdDev) - PredictY(LastX)
            UStdDev = StdDevPredictY(LastX, -TErrorStdDev) - PredictY(LastX)
            NonLinRegrChart.chtResiduals.Series("Std Dev -").Points.AddXY(LastX, UStdDev) 'Add the last point in the upper standard deviation of residuals line

            'LStdDev = StdDevPredictY(LastX, ErrorStdDev) - PredictY(LastX)
            LStdDev = StdDevPredictY(LastX, TErrorStdDev) - PredictY(LastX)
            NonLinRegrChart.chtResiduals.Series("Std Dev +").Points.AddXY(LastX, LStdDev) 'Add the last point in the lower standard deviation of residuals line


            'NonLinRegrChart.chtTransResiduals.ChartAreas(0).RecalculateAxesScale()

        End If

    End Sub

    Private Sub cmbTransModel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRegrModel.SelectedIndexChanged

        If cmbRegrModel.Focused Then
            UpdateTransSelections()
        End If
    End Sub

    Private Sub UpdateTransSelections()
        'Update the transform data selections:
        Select Case cmbRegrModel.SelectedItem.ToString
            Case "Linear"
                cmbXTrans.SelectedIndex = cmbXTrans.FindStringExact("None")
                cmbYTrans.SelectedIndex = cmbYTrans.FindStringExact("None")
            Case "Logarithmic"
                cmbXTrans.SelectedIndex = cmbXTrans.FindStringExact("Log")
                cmbYTrans.SelectedIndex = cmbYTrans.FindStringExact("None")
            Case "Exponential"
                cmbXTrans.SelectedIndex = cmbXTrans.FindStringExact("None")
                cmbYTrans.SelectedIndex = cmbYTrans.FindStringExact("Log")
            Case "Power"
                cmbXTrans.SelectedIndex = cmbXTrans.FindStringExact("Log")
                cmbYTrans.SelectedIndex = cmbYTrans.FindStringExact("Log")
        End Select
        cmbXTrans.SelectionLength = 0
        cmbYTrans.SelectionLength = 0
    End Sub

    Private Sub cmbXTrans_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbXTrans.SelectedIndexChanged

        If cmbXTrans.Focused Then
            UpdateRegrModelSelection()
        End If
    End Sub

    Private Sub cmbYTrans_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbYTrans.SelectedIndexChanged

        If cmbYTrans.Focused Then
            UpdateRegrModelSelection()
        End If
    End Sub

    Private Sub UpdateRegrModelSelection()

        Select Case cmbXTrans.SelectedItem.ToString
            Case "None"
                Select Case cmbYTrans.SelectedItem.ToString
                    Case "None"
                        cmbRegrModel.SelectedIndex = cmbRegrModel.FindStringExact("Linear")
                    Case "Log"
                        cmbRegrModel.SelectedIndex = cmbRegrModel.FindStringExact("Exponential")
                End Select
            Case "Log"
                Select Case cmbYTrans.SelectedItem.ToString
                    Case "None"
                        cmbRegrModel.SelectedIndex = cmbRegrModel.FindStringExact("Logarithmic")
                    Case "Log"
                        cmbRegrModel.SelectedIndex = cmbRegrModel.FindStringExact("Power")
                End Select

        End Select
    End Sub

    Private Sub btnPredict_Click(sender As Object, e As EventArgs) Handles btnPredict.Click
        PredictYValues()
    End Sub

    Private Sub PredictYValues()
        'Predict the Y Values corresponding to the XValues in dgvSpecPredictions:

        dgvSpecPredictions.AllowUserToAddRows = False

        Dim NRows As Integer = dgvSpecPredictions.Rows.Count
        Dim I As Integer
        Dim XVal As Single
        Dim YPred As Single

        Dim TXVal As Single 'Transformed X Value
        Dim TYPred As Single 'Transformed prodicted Y Value

        Dim TSlope As Single = Val(txtRegrSlope.Text) 'The Transformed Data linear regression slope
        Dim TIntercept As Single = Val(txtRegrIntercept.Text) 'The Transformed Data linear Y intercept

        For I = 0 To NRows - 1
            If dgvSpecPredictions.Rows(I).Cells(0).Value = "" Then
                XVal = 0
            Else
                XVal = dgvSpecPredictions.Rows(I).Cells(0).Value
            End If

            TXVal = TransX(XVal)
            TYPred = TIntercept + TSlope * TXVal
            YPred = UnTransY(TYPred)
            'YPred = RegIntercept + XVal * RegSlope
            dgvSpecPredictions.Rows(I).Cells(1).Value = YPred
        Next

        dgvSpecPredictions.AllowUserToAddRows = True
    End Sub




#End Region 'Form Methods ---------------------------------------------------------------------------------------------------------------------------------------------------------------------



End Class