Public Class frmLinearRegr
    'Linear Regression

#Region " Variable Declarations - All the variables used in this form and this application." '=================================================================================================

    'Declare Forms used by the application:
    Public WithEvents LinearRegrChart As frmLinearRegrChart

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
        dgvCalculations.Columns.Add(TextBox2Col0)
        dgvCalculations.Columns(0).HeaderText = "X * X"
        dgvCalculations.Columns(0).Width = 80

        Dim TextBox2Col1 As New DataGridViewTextBoxColumn
        dgvCalculations.Columns.Add(TextBox2Col1)
        dgvCalculations.Columns(1).HeaderText = "X * Y"
        dgvCalculations.Columns(1).Width = 80

        Dim TextBox2Col2 As New DataGridViewTextBoxColumn
        dgvCalculations.Columns.Add(TextBox2Col2)
        dgvCalculations.Columns(2).HeaderText = "Y * Y"
        dgvCalculations.Columns(2).Width = 80

        Dim TextBox3Col0 As New DataGridViewTextBoxColumn
        dgvPredictions.Columns.Add(TextBox3Col0)
        dgvPredictions.Columns(0).HeaderText = "Prediction"
        dgvPredictions.Columns(0).Width = 80

        Dim TextBox3Col1 As New DataGridViewTextBoxColumn
        dgvPredictions.Columns.Add(TextBox3Col1)
        dgvPredictions.Columns(1).HeaderText = "Error"
        dgvPredictions.Columns(1).Width = 80

        Dim TextBox3Col2 As New DataGridViewTextBoxColumn
        dgvPredictions.Columns.Add(TextBox3Col2)
        dgvPredictions.Columns(2).HeaderText = "Sq Error"
        dgvPredictions.Columns(2).Width = 80

        Dim TextBox4Col0 As New DataGridViewTextBoxColumn
        dgvSpecPredictions.Columns.Add(TextBox4Col0)
        dgvSpecPredictions.Columns(0).HeaderText = "X Value"
        dgvSpecPredictions.Columns(0).Width = 80

        Dim TextBox4Col1 As New DataGridViewTextBoxColumn
        dgvSpecPredictions.Columns.Add(TextBox4Col1)
        dgvSpecPredictions.Columns(1).HeaderText = "Pred Y"
        dgvSpecPredictions.Columns(1).Width = 80

        RestoreFormSettings()   'Restore the form settings

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Exit the Form
        SavePoints()
        Me.Close() 'Close the form

        If IsNothing(LinearRegrChart) Then

        Else 'Close the Chart form
            LinearRegrChart.Close()
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
        If IsNothing(LinearRegrChart) Then
            LinearRegrChart = New frmLinearRegrChart
            LinearRegrChart.Show()
            ShowInputPoints()
            ShowResiduals()
        Else
            LinearRegrChart.Show()
            ShowInputPoints()
            ShowResiduals()
        End If
    End Sub

    Private Sub LinearRegrChart_FormClosed(sender As Object, e As FormClosedEventArgs) Handles LinearRegrChart.FormClosed
        LinearRegrChart = Nothing
    End Sub

#End Region 'Open and Close Forms -------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region " Form Methods - The main actions performed by this form." '===========================================================================================================================

    Private Sub btnSavePoints_Click(sender As Object, e As EventArgs) Handles btnSavePoints.Click
        'Save the XY points in an XML file.

        SavePoints()

    End Sub

    Private Sub SavePoints()
        'Save the XY points in an XML file.

        If txtFileName.Text = "" Then
            'No file name specified
            Main.Message.Add("No Linear Regression Input Points file name specified. Exiting without saving." & vbCrLf)
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
                dgvCalculations.Rows.Add() 'Add a corresponding blank row to dgvCalculations
                dgvPredictions.Rows.Add() 'Add a corresponding blank row to dgvPredictions
            Next

            'Dim SpecXValues = From item In XDoc.<SpecifiedXValues>.<Value>
            Dim SpecXValues = From item In XDoc.<XYPoints>.<SpecifiedXValues>.<Value>

            For Each item In SpecXValues
                dgvSpecPredictions.Rows.Add(item.Value)
            Next

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
        dgvCalculations.Rows.Clear()
        txtSumXX.Text = ""
        txtSumXY.Text = ""
        txtNPoints.Text = ""
        txtRegrSlope.Text = ""
        txtRegrIntercept.Text = ""
        dgvSpecPredictions.Rows.Clear()

    End Sub

    Public Sub PositionSumTextBoxes()
        'Position the sum of values text boxes:

        txtSumX.Left = dgvInputPoints.Left + dgvInputPoints.RowHeadersWidth
        txtSumX.Width = dgvInputPoints.Columns(0).Width

        txtMeanX.Left = txtSumX.Left
        txtMeanX.Width = txtSumX.Width

        txtSumY.Left = dgvInputPoints.Left + dgvInputPoints.RowHeadersWidth + dgvInputPoints.Columns(0).Width
        txtSumY.Width = dgvInputPoints.Columns(1).Width

        txtMeanY.Left = txtSumY.Left
        txtMeanY.Width = txtSumY.Width

        txtSumXX.Left = dgvCalculations.Left + dgvCalculations.RowHeadersWidth
        txtSumXX.Width = dgvCalculations.Columns(0).Width

        txtMeanXX.Left = txtSumXX.Left
        txtMeanXX.Width = txtSumXX.Width

        txtSumXY.Left = dgvCalculations.Left + dgvCalculations.RowHeadersWidth + dgvCalculations.Columns(0).Width
        txtSumXY.Width = dgvCalculations.Columns(1).Width

        txtMeanXY.Left = txtSumXY.Left
        txtMeanXY.Width = txtSumXY.Width

        txtSumYY.Left = dgvCalculations.Left + dgvCalculations.RowHeadersWidth + dgvCalculations.Columns(0).Width + dgvCalculations.Columns(1).Width
        txtSumYY.Width = dgvCalculations.Columns(1).Width

        txtMeanYY.Left = txtSumYY.Left
        txtMeanYY.Width = txtSumYY.Width

        txtSumPred.Left = dgvPredictions.Left + dgvPredictions.RowHeadersWidth
        txtSumPred.Width = dgvPredictions.Columns(0).Width

        txtMeanPred.Left = txtSumPred.Left
        txtMeanPred.Width = txtSumPred.Width

        txtSumError.Left = dgvPredictions.Left + dgvPredictions.RowHeadersWidth + dgvPredictions.Columns(0).Width
        txtSumError.Width = dgvPredictions.Columns(1).Width

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
    End Sub

    Private Sub ApplyRegression()
        'Estimate the linear regression parameters:

        dgvInputPoints.AllowUserToAddRows = False
        Dim NPoints As Integer = dgvInputPoints.Rows.Count

        'In calculations table show xy, xx and yy:
        'https://www.statisticshowto.datasciencecentral.com/probability-and-statistics/regression-analysis/find-a-linear-regression-equation/
        'http://archive.bio.ed.ac.uk/jdeacon/statistics/tress11.html

        'Regression calculations:
        'http://reliawiki.org/index.php/Simple_Linear_Regression_Analysis


        If NPoints = 0 Then
            Main.Message.AddWarning("There are no input points to generate the linear regression parameters!")
        Else
            dgvCalculations.AllowUserToAddRows = False
            'dgvCalculations.Rows.Clear()
            Dim I As Integer
            Dim X As Double
            Dim Y As Double
            Dim SumX As Double = 0
            Dim SumY As Double = 0
            Dim SumXX As Double = 0
            Dim SumYY As Double = 0
            Dim SumXY As Double = 0
            For I = 0 To NPoints - 1
                X = dgvInputPoints.Rows(I).Cells(0).Value
                Y = dgvInputPoints.Rows(I).Cells(1).Value
                SumX += X
                SumY += Y
                SumXX += X * X
                SumYY += Y * Y
                SumXY += X * Y
                'dgvCalculations.Rows.Add(X * X, X * Y, Y * Y)
                dgvCalculations.Rows(I).SetValues(X * X, X * Y, Y * Y)
            Next
            dgvCalculations.AllowUserToAddRows = True
            txtSumX.Text = SumX
            txtMeanX.Text = SumX / NPoints
            txtSumY.Text = SumY
            txtMeanY.Text = SumY / NPoints
            txtSumXX.Text = SumXX
            txtMeanXX.Text = SumXX / NPoints
            txtSumXY.Text = SumXY
            txtMeanXY.Text = SumXY / NPoints
            txtSumYY.Text = SumYY
            txtMeanYY.Text = SumYY / NPoints
            txtNPoints.Text = NPoints
            Dim SSxy As Double = SumXY - (SumX * SumY) / NPoints
            Dim SSxx As Double = SumXX - (SumX * SumX) / NPoints
            Dim Slope As Double = SSxy / SSxx
            txtRegrSlope.Text = Slope
            Dim Intercept As Double = (SumY / NPoints) - (Slope * (SumX / NPoints))
            txtRegrIntercept.Text = Intercept
            'Calculate the Sample Linear Correlation Coefficient (r)
            Dim R As Double = (NPoints * SumXY - SumX * SumY) / ((NPoints * SumXX - SumX * SumX) * (NPoints * SumYY - SumY * SumY)) ^ 0.5
            txtCorrelation.Text = R
            txtRSquared.Text = R * R

            'Fill Predictions Table:
            dgvPredictions.AllowUserToAddRows = False
            'dgvPredictions.Rows.Clear()
            Dim Prediction As Double
            Dim SumPred As Double = 0
            Dim PredError As Double
            Dim SumPredError As Double = 0
            Dim SquaredError As Double
            Dim SumSqError As Double = 0

            For I = 0 To NPoints - 1
                X = dgvInputPoints.Rows(I).Cells(0).Value
                Y = dgvInputPoints.Rows(I).Cells(1).Value
                Prediction = Intercept + Slope * X
                SumPred += Prediction
                PredError = Y - Prediction
                SumPredError += PredError
                SquaredError = PredError * PredError
                'dgvPredictions.Rows.Add(Prediction, PredError, SquaredError)
                dgvPredictions.Rows(I).SetValues(Prediction, PredError, SquaredError)
                SumSqError += SquaredError
            Next
            txtSumPred.Text = SumPred
            txtMeanPred.Text = SumPred / NPoints
            txtSumError.Text = SumPredError
            txtMeanError.Text = SumPredError / NPoints
            txtSumSqError.Text = SumSqError
            txtMeanSqError.Text = SumSqError / NPoints
            txtErrorStdDev.Text = (SumSqError / NPoints) ^ 0.5
            dgvPredictions.AllowUserToAddRows = True
        End If

        dgvInputPoints.AllowUserToAddRows = True
    End Sub

    Private Sub ApplyRegression_Old()
        'Estimate the linear regression parameters:

        dgvInputPoints.AllowUserToAddRows = False
        Dim NPoints As Integer = dgvInputPoints.Rows.Count

        'In calculations table show xy, xx and yy:
        'https://www.statisticshowto.datasciencecentral.com/probability-and-statistics/regression-analysis/find-a-linear-regression-equation/
        'http://archive.bio.ed.ac.uk/jdeacon/statistics/tress11.html

        'Regression calculations:
        'http://reliawiki.org/index.php/Simple_Linear_Regression_Analysis


        If NPoints = 0 Then
            Main.Message.AddWarning("There are no input points to generate the linear regression parameters!")
        Else
            dgvCalculations.AllowUserToAddRows = False
            'dgvCalculations.Rows.Clear()
            Dim I As Integer
            Dim X As Single
            Dim Y As Single
            Dim SumX As Single = 0
            Dim SumY As Single = 0
            Dim SumXX As Single = 0
            Dim SumYY As Single = 0
            Dim SumXY As Single = 0
            For I = 0 To NPoints - 1
                X = dgvInputPoints.Rows(I).Cells(0).Value
                Y = dgvInputPoints.Rows(I).Cells(1).Value
                SumX += X
                SumY += Y
                SumXX += X * X
                SumYY += Y * Y
                SumXY += X * Y
                'dgvCalculations.Rows.Add(X * X, X * Y, Y * Y)
                dgvCalculations.Rows(I).SetValues(X * X, X * Y, Y * Y)
            Next
            dgvCalculations.AllowUserToAddRows = True
            txtSumX.Text = SumX
            txtMeanX.Text = SumX / NPoints
            txtSumY.Text = SumY
            txtMeanY.Text = SumY / NPoints
            txtSumXX.Text = SumXX
            txtMeanXX.Text = SumXX / NPoints
            txtSumXY.Text = SumXY
            txtMeanXY.Text = SumXY / NPoints
            txtSumYY.Text = SumYY
            txtMeanYY.Text = SumYY / NPoints
            txtNPoints.Text = NPoints
            Dim SSxy As Single = SumXY - (SumX * SumY) / NPoints
            Dim SSxx As Single = SumXX - (SumX * SumX) / NPoints
            Dim Slope As Single = SSxy / SSxx
            txtRegrSlope.Text = Slope
            Dim Intercept As Single = (SumY / NPoints) - (Slope * (SumX / NPoints))
            txtRegrIntercept.Text = Intercept
            'Calculate the Sample Linear Correlation Coefficient (r)
            Dim R As Single = (NPoints * SumXY - SumX * SumY) / ((NPoints * SumXX - SumX * SumX) * (NPoints * SumYY - SumY * SumY)) ^ 0.5
            txtCorrelation.Text = R
            txtRSquared.Text = R * R

            'Fill Predictions Table:
            dgvPredictions.AllowUserToAddRows = False
            'dgvPredictions.Rows.Clear()
            Dim Prediction As Single
            Dim SumPred As Single = 0
            Dim PredError As Single
            Dim SumPredError As Single = 0
            Dim SquaredError As Single
            Dim SumSqError As Single = 0

            For I = 0 To NPoints - 1
                X = dgvInputPoints.Rows(I).Cells(0).Value
                Y = dgvInputPoints.Rows(I).Cells(1).Value
                Prediction = Intercept + Slope * X
                SumPred += Prediction
                PredError = Y - Prediction
                SumPredError += PredError
                SquaredError = PredError * PredError
                'dgvPredictions.Rows.Add(Prediction, PredError, SquaredError)
                dgvPredictions.Rows(I).SetValues(Prediction, PredError, SquaredError)
                SumSqError += SquaredError
            Next
            txtSumPred.Text = SumPred
            txtMeanPred.Text = SumPred / NPoints
            txtSumError.Text = SumPredError
            txtMeanError.Text = SumPredError / NPoints
            txtSumSqError.Text = SumSqError
            txtMeanSqError.Text = SumSqError / NPoints
            txtErrorStdDev.Text = (SumSqError / NPoints) ^ 0.5
            dgvPredictions.AllowUserToAddRows = True
        End If

        dgvInputPoints.AllowUserToAddRows = True
    End Sub

    Private Sub dgvInputPoints_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInputPoints.CellContentClick

    End Sub

    Private Sub dgvInputPoints_Scroll(sender As Object, e As ScrollEventArgs) Handles dgvInputPoints.Scroll

        If e.ScrollOrientation = ScrollOrientation.VerticalScroll Then
            'Align the scroll settings of dgvCalculations:
            dgvCalculations.FirstDisplayedScrollingRowIndex = dgvInputPoints.FirstDisplayedScrollingRowIndex
            dgvPredictions.FirstDisplayedScrollingRowIndex = dgvInputPoints.FirstDisplayedScrollingRowIndex
        End If

    End Sub

    Private Sub dgvCalculations_Scroll(sender As Object, e As ScrollEventArgs) Handles dgvCalculations.Scroll

        If e.ScrollOrientation = ScrollOrientation.VerticalScroll Then
            'Align the scroll settings of dgvCalculations:
            dgvInputPoints.FirstDisplayedScrollingRowIndex = dgvCalculations.FirstDisplayedScrollingRowIndex
            dgvPredictions.FirstDisplayedScrollingRowIndex = dgvCalculations.FirstDisplayedScrollingRowIndex
        End If
    End Sub

    Private Sub dgvPredictions_Scroll(sender As Object, e As ScrollEventArgs) Handles dgvPredictions.Scroll
        'Align the scroll settings of dgvPredictions:
        dgvInputPoints.FirstDisplayedScrollingRowIndex = dgvPredictions.FirstDisplayedScrollingRowIndex
        dgvCalculations.FirstDisplayedScrollingRowIndex = dgvPredictions.FirstDisplayedScrollingRowIndex
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearData()
    End Sub

    Public Sub ShowInputPoints()
        'Show the Input Points on the Regression chart on the LinRegrChart form.

        If LinearRegrChart Is Nothing Then
            'The Linear Regression Chart form is not open!
        Else
            'Set up data series in the chtRegression chart:
            LinearRegrChart.chtRegression.Series.Clear()
            LinearRegrChart.chtRegression.Series.Add("Input Points")
            LinearRegrChart.chtRegression.Series("Input Points").YValuesPerPoint = 1
            LinearRegrChart.chtRegression.Series("Input Points").ChartType = DataVisualization.Charting.SeriesChartType.Point

            'LinearRegrChart.chtRegression.Series("Input Points").Label = txtDatasetName.Text 'THIS LABELS EACH POINT!

            'Add chart label:
            If LinearRegrChart.chtRegression.Titles.IndexOf("Label1") = -1 Then 'Label "Label1" does not exist
                LinearRegrChart.chtRegression.Titles.Add("Label1").Name = "Label1"
            End If
            LinearRegrChart.chtRegression.Titles("Label1").Text = txtDatasetName.Text
            Dim LabelFontStyle As FontStyle = FontStyle.Regular
            LinearRegrChart.chtRegression.Titles("Label1").Font = New Font("Arial", 12, LabelFontStyle)
            LinearRegrChart.chtRegression.Titles("Label1").Alignment = ContentAlignment.TopCenter

            'Set up the X and Y axes:
            LinearRegrChart.chtRegression.ChartAreas(0).AxisX.Minimum = [Double].NaN
            LinearRegrChart.chtRegression.ChartAreas(0).AxisX.Maximum = [Double].NaN

            LinearRegrChart.chtRegression.ChartAreas(0).AxisX.Interval = 0
            LinearRegrChart.chtRegression.ChartAreas(0).AxisX.MajorGrid.Interval = 0
            LinearRegrChart.chtRegression.ChartAreas(0).AxisX.RoundAxisValues()
            LinearRegrChart.chtRegression.ChartAreas(0).AxisX.IsStartedFromZero = False

            LinearRegrChart.chtRegression.ChartAreas(0).AxisY.LabelStyle.Format = "F3"
            LinearRegrChart.chtRegression.ChartAreas(0).AxisY.IsStartedFromZero = False

            'Add the X Axis label:
            LinearRegrChart.chtRegression.ChartAreas(0).AxisX.TitleFont = New Font("Arial", 10, LabelFontStyle)
            LinearRegrChart.chtRegression.ChartAreas(0).AxisX.Title = txtXName.Text & " (" & txtXUnits.Text & ")"
            LinearRegrChart.chtRegression.ChartAreas(0).AxisX.TitleAlignment = StringAlignment.Center

            'Add the Y Axis label:
            LinearRegrChart.chtRegression.ChartAreas(0).AxisY.TitleFont = New Font("Arial", 10, LabelFontStyle)
            LinearRegrChart.chtRegression.ChartAreas(0).AxisY.Title = txtYName.Text & " (" & txtYUnits.Text & ")"
            LinearRegrChart.chtRegression.ChartAreas(0).AxisY.TextOrientation = DataVisualization.Charting.TextOrientation.Rotated270
            LinearRegrChart.chtRegression.ChartAreas(0).AxisY.TitleAlignment = StringAlignment.Center

            'Specify the point symbols:
            LinearRegrChart.chtRegression.Series("Input Points").MarkerColor = Color.Blue
            LinearRegrChart.chtRegression.Series("Input Points").MarkerSize = 8
            LinearRegrChart.chtRegression.Series("Input Points").MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle

            dgvInputPoints.AllowUserToAddRows = False
            Dim NPoints As Integer = dgvInputPoints.Rows.Count
            Dim I As Integer
            Dim X As Single
            Dim Y As Single

            For I = 0 To NPoints - 1
                X = dgvInputPoints.Rows(I).Cells(0).Value
                Y = dgvInputPoints.Rows(I).Cells(1).Value
                LinearRegrChart.chtRegression.Series("Input Points").Points.AddXY(X, Y)
            Next

            dgvInputPoints.AllowUserToAddRows = True

            'Show regression line: ---------------------------------------------------------------------------------------------------------------
            LinearRegrChart.chtRegression.Series.Add("Regression")
            LinearRegrChart.chtRegression.Series("Regression").ChartType = DataVisualization.Charting.SeriesChartType.Line

            LinearRegrChart.chtRegression.ChartAreas(0).RecalculateAxesScale()
            Dim FirstX As Single = LinearRegrChart.chtRegression.ChartAreas(0).AxisX.Minimum
            Dim LastX As Single = LinearRegrChart.chtRegression.ChartAreas(0).AxisX.Maximum
            Dim FirstY As Single = Val(txtRegrIntercept.Text) + Val(txtRegrSlope.Text) * FirstX
            Dim LastY As Single = Val(txtRegrIntercept.Text) + Val(txtRegrSlope.Text) * LastX

            Dim AxisYMin As Single = LinearRegrChart.chtRegression.ChartAreas(0).AxisY.Minimum
            Dim AxisYMax As Single = LinearRegrChart.chtRegression.ChartAreas(0).AxisY.Maximum

            LinearRegrChart.chtRegression.ChartAreas(0).AxisX.Minimum = FirstX
            LinearRegrChart.chtRegression.ChartAreas(0).AxisX.Maximum = LastX
            LinearRegrChart.chtRegression.ChartAreas(0).AxisY.Minimum = AxisYMin
            LinearRegrChart.chtRegression.ChartAreas(0).AxisY.Maximum = AxisYMax

            'Specify the line style:
            LinearRegrChart.chtRegression.Series("Regression").Color = Color.Black
            LinearRegrChart.chtRegression.Series("Regression").BorderWidth = 2


            'Add the line end points:
            LinearRegrChart.chtRegression.Series("Regression").Points.AddXY(FirstX, FirstY)
            LinearRegrChart.chtRegression.Series("Regression").Points.AddXY(LastX, LastY)

            'Add the Input forecast points:
            LinearRegrChart.chtRegression.Series.Add("Input Forecast")
            LinearRegrChart.chtRegression.Series("Input Forecast").YValuesPerPoint = 1
            LinearRegrChart.chtRegression.Series("Input Forecast").ChartType = DataVisualization.Charting.SeriesChartType.Point

            'Specify the point symbols:
            LinearRegrChart.chtRegression.Series("Input Forecast").MarkerColor = Color.Red
            LinearRegrChart.chtRegression.Series("Input Forecast").MarkerBorderWidth = 1.5
            LinearRegrChart.chtRegression.Series("Input Forecast").MarkerSize = 12
            LinearRegrChart.chtRegression.Series("Input Forecast").MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle
            LinearRegrChart.chtRegression.Series("Input Forecast").MarkerBorderColor = Color.Red
            LinearRegrChart.chtRegression.Series("Input Forecast").MarkerColor = Color.Transparent

            'Add the Forecast points:
            For I = 0 To NPoints - 1
                X = dgvInputPoints.Rows(I).Cells(0).Value
                Y = dgvPredictions.Rows(I).Cells(0).Value
                LinearRegrChart.chtRegression.Series("Input Forecast").Points.AddXY(X, Y)
            Next

            'Show upper standard deviation line:
            LinearRegrChart.chtRegression.Series.Add("Std Dev +")
            LinearRegrChart.chtRegression.Series("Std Dev +").ChartType = DataVisualization.Charting.SeriesChartType.Line

            FirstY = Val(txtRegrIntercept.Text) + Val(txtErrorStdDev.Text) + Val(txtRegrSlope.Text) * FirstX
            LastY = Val(txtRegrIntercept.Text) + Val(txtErrorStdDev.Text) + Val(txtRegrSlope.Text) * LastX

            'Specify the line style:
            LinearRegrChart.chtRegression.Series("Std Dev +").Color = Color.Gray
            LinearRegrChart.chtRegression.Series("Std Dev +").BorderWidth = 2
            LinearRegrChart.chtRegression.Series("Std Dev +").BorderDashStyle = DataVisualization.Charting.ChartDashStyle.Dash

            'Add the line end points:
            LinearRegrChart.chtRegression.Series("Std Dev +").Points.AddXY(FirstX, FirstY)
            LinearRegrChart.chtRegression.Series("Std Dev +").Points.AddXY(LastX, LastY)


            'Show lower standard deviation line:
            LinearRegrChart.chtRegression.Series.Add("Std Dev -")
            LinearRegrChart.chtRegression.Series("Std Dev -").ChartType = DataVisualization.Charting.SeriesChartType.Line

            FirstY = Val(txtRegrIntercept.Text) - Val(txtErrorStdDev.Text) + Val(txtRegrSlope.Text) * FirstX
            LastY = Val(txtRegrIntercept.Text) - Val(txtErrorStdDev.Text) + Val(txtRegrSlope.Text) * LastX

            'Specify the line style:
            LinearRegrChart.chtRegression.Series("Std Dev -").Color = Color.Gray
            LinearRegrChart.chtRegression.Series("Std Dev -").BorderWidth = 2
            LinearRegrChart.chtRegression.Series("Std Dev -").BorderDashStyle = DataVisualization.Charting.ChartDashStyle.Dash

            'Add the line end points:
            LinearRegrChart.chtRegression.Series("Std Dev -").Points.AddXY(FirstX, FirstY)
            LinearRegrChart.chtRegression.Series("Std Dev -").Points.AddXY(LastX, LastY)

            'Add the specific forecast points: -------------------------------------------------------------------------------------------------------------------
            LinearRegrChart.chtRegression.Series.Add("Forecast")
            LinearRegrChart.chtRegression.Series("Forecast").YValuesPerPoint = 1
            LinearRegrChart.chtRegression.Series("Forecast").ChartType = DataVisualization.Charting.SeriesChartType.Point

            'Specify the point symbols:
            LinearRegrChart.chtRegression.Series("Forecast").MarkerColor = Color.Green
            LinearRegrChart.chtRegression.Series("Forecast").MarkerBorderWidth = 1.5
            LinearRegrChart.chtRegression.Series("Forecast").MarkerSize = 18
            LinearRegrChart.chtRegression.Series("Forecast").MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle
            LinearRegrChart.chtRegression.Series("Forecast").MarkerBorderColor = Color.Green
            LinearRegrChart.chtRegression.Series("Forecast").MarkerColor = Color.Transparent

            'Add the Specific Forecast points:
            dgvSpecPredictions.AllowUserToAddRows = False
            NPoints = dgvSpecPredictions.Rows.Count
            For I = 0 To NPoints - 1
                'X = dgvInputPoints.Rows(I).Cells(0).Value
                'Y = dgvPredictions.Rows(I).Cells(0).Value
                'LinearRegrChart.chtRegression.Series("Forecast").Points.AddXY(X, Y)
                X = dgvSpecPredictions.Rows(I).Cells(0).Value
                Y = dgvSpecPredictions.Rows(I).Cells(1).Value
                LinearRegrChart.chtRegression.Series("Forecast").Points.AddXY(X, Y)
            Next
            dgvSpecPredictions.AllowUserToAddRows = True
        End If

    End Sub

    Public Sub ShowResiduals()
        'Show the Input Points on the Residuals chart on the LinRegrChart form.

        If LinearRegrChart Is Nothing Then
            'The Linear Regression Chart form is not open!
        Else
            'Set up data series in the chtRegression chart:
            LinearRegrChart.chtResiduals.Series.Clear()
            LinearRegrChart.chtResiduals.Series.Add("Residuals")
            LinearRegrChart.chtResiduals.Series("Residuals").YValuesPerPoint = 1
            LinearRegrChart.chtResiduals.Series("Residuals").ChartType = DataVisualization.Charting.SeriesChartType.Point

            'Add chart label:
            If LinearRegrChart.chtResiduals.Titles.IndexOf("Label1") = -1 Then 'Label "Label1" does not exist
                LinearRegrChart.chtResiduals.Titles.Add("Label1").Name = "Label1"
            End If
            LinearRegrChart.chtResiduals.Titles("Label1").Text = "Linear Regression Residuals"
            Dim LabelFontStyle As FontStyle = FontStyle.Regular
            LinearRegrChart.chtResiduals.Titles("Label1").Font = New Font("Arial", 12, LabelFontStyle)
            LinearRegrChart.chtResiduals.Titles("Label1").Alignment = ContentAlignment.TopCenter

            'Set up the X and Y axes:
            LinearRegrChart.chtResiduals.ChartAreas(0).AxisX.Minimum = [Double].NaN
            LinearRegrChart.chtResiduals.ChartAreas(0).AxisX.Maximum = [Double].NaN

            LinearRegrChart.chtResiduals.ChartAreas(0).AxisX.Interval = 0
            LinearRegrChart.chtResiduals.ChartAreas(0).AxisX.MajorGrid.Interval = 0
            LinearRegrChart.chtResiduals.ChartAreas(0).AxisX.RoundAxisValues()
            LinearRegrChart.chtResiduals.ChartAreas(0).AxisX.IsStartedFromZero = False

            LinearRegrChart.chtResiduals.ChartAreas(0).AxisY.LabelStyle.Format = "F3"
            LinearRegrChart.chtResiduals.ChartAreas(0).AxisY.IsStartedFromZero = False

            'Add the X Axis label:
            LinearRegrChart.chtResiduals.ChartAreas(0).AxisX.TitleFont = New Font("Arial", 10, LabelFontStyle)
            LinearRegrChart.chtResiduals.ChartAreas(0).AxisX.Title = txtXName.Text & " (" & txtXUnits.Text & ")"
            LinearRegrChart.chtResiduals.ChartAreas(0).AxisX.TitleAlignment = StringAlignment.Center

            'Add the Y Axis label:
            LinearRegrChart.chtResiduals.ChartAreas(0).AxisY.TitleFont = New Font("Arial", 10, LabelFontStyle)
            LinearRegrChart.chtResiduals.ChartAreas(0).AxisY.Title = txtYName.Text & " (" & txtYUnits.Text & ")"
            LinearRegrChart.chtResiduals.ChartAreas(0).AxisY.TextOrientation = DataVisualization.Charting.TextOrientation.Rotated270
            LinearRegrChart.chtResiduals.ChartAreas(0).AxisY.TitleAlignment = StringAlignment.Center

            'Specify the point symbols:
            LinearRegrChart.chtResiduals.Series("Residuals").MarkerColor = Color.Blue
            LinearRegrChart.chtResiduals.Series("Residuals").MarkerSize = 8
            LinearRegrChart.chtResiduals.Series("Residuals").MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle

            dgvPredictions.AllowUserToAddRows = False
            Dim NPoints As Integer = dgvPredictions.Rows.Count 'Assume dgvInputPoints has the same number of rows!
            Dim I As Integer
            Dim X As Single
            Dim Y As Single

            For I = 0 To NPoints - 1
                X = dgvInputPoints.Rows(I).Cells(0).Value
                Y = dgvPredictions.Rows(I).Cells(1).Value
                LinearRegrChart.chtResiduals.Series("Residuals").Points.AddXY(X, Y)
            Next

            dgvPredictions.AllowUserToAddRows = True

            'Add the X Axis line at Y = 0:
            LinearRegrChart.chtResiduals.Series.Add("Zero")
            LinearRegrChart.chtResiduals.Series("Zero").ChartType = DataVisualization.Charting.SeriesChartType.Line

            LinearRegrChart.chtResiduals.ChartAreas(0).RecalculateAxesScale()
            Dim FirstX As Single = LinearRegrChart.chtResiduals.ChartAreas(0).AxisX.Minimum
            Dim LastX As Single = LinearRegrChart.chtResiduals.ChartAreas(0).AxisX.Maximum
            Dim FirstY As Single = LinearRegrChart.chtResiduals.ChartAreas(0).AxisY.Minimum
            Dim LastY As Single = LinearRegrChart.chtResiduals.ChartAreas(0).AxisY.Maximum

            LinearRegrChart.chtResiduals.ChartAreas(0).AxisX.Minimum = FirstX
            LinearRegrChart.chtResiduals.ChartAreas(0).AxisX.Maximum = LastX
            LinearRegrChart.chtResiduals.ChartAreas(0).AxisY.Minimum = FirstY
            LinearRegrChart.chtResiduals.ChartAreas(0).AxisY.Maximum = LastY

            'Specify the line style:
            LinearRegrChart.chtResiduals.Series("Zero").Color = Color.Black
            LinearRegrChart.chtResiduals.Series("Zero").BorderWidth = 2

            'Add the line end points:
            LinearRegrChart.chtResiduals.Series("Zero").Points.AddXY(FirstX, 0)
            LinearRegrChart.chtResiduals.Series("Zero").Points.AddXY(LastX, 0)

            'Show upper standard deviation line:
            LinearRegrChart.chtResiduals.Series.Add("Std Dev +")
            LinearRegrChart.chtResiduals.Series("Std Dev +").ChartType = DataVisualization.Charting.SeriesChartType.Line

            FirstY = Val(txtErrorStdDev.Text)
            LastY = Val(txtErrorStdDev.Text)

            'Specify the line style:
            LinearRegrChart.chtResiduals.Series("Std Dev +").Color = Color.Gray
            LinearRegrChart.chtResiduals.Series("Std Dev +").BorderWidth = 2
            LinearRegrChart.chtResiduals.Series("Std Dev +").BorderDashStyle = DataVisualization.Charting.ChartDashStyle.Dash

            'Add the line end points:
            LinearRegrChart.chtResiduals.Series("Std Dev +").Points.AddXY(FirstX, FirstY)
            LinearRegrChart.chtResiduals.Series("Std Dev +").Points.AddXY(LastX, LastY)


            'Show lower standard deviation line:
            LinearRegrChart.chtResiduals.Series.Add("Std Dev -")
            LinearRegrChart.chtResiduals.Series("Std Dev -").ChartType = DataVisualization.Charting.SeriesChartType.Line

            FirstY = -Val(txtErrorStdDev.Text)
            LastY = -Val(txtErrorStdDev.Text)

            'Specify the line style:
            LinearRegrChart.chtResiduals.Series("Std Dev -").Color = Color.Gray
            LinearRegrChart.chtResiduals.Series("Std Dev -").BorderWidth = 2
            LinearRegrChart.chtResiduals.Series("Std Dev -").BorderDashStyle = DataVisualization.Charting.ChartDashStyle.Dash

            'Add the line end points:
            LinearRegrChart.chtResiduals.Series("Std Dev -").Points.AddXY(FirstX, FirstY)
            LinearRegrChart.chtResiduals.Series("Std Dev -").Points.AddXY(LastX, LastY)

        End If

    End Sub

    Private Sub btnPredict_Click(sender As Object, e As EventArgs) Handles btnPredict.Click
        'Predict the Y Values from the X Values specified in dgvSpecPredictions:

        PredictYValues()

        'dgvSpecPredictions.AllowUserToAddRows = False

        'Dim NRows As Integer = dgvSpecPredictions.Rows.Count
        'Dim I As Integer
        'Dim XVal As Single
        'Dim YPred As Single

        'Dim RegSlope As Single = Val(txtRegrSlope.Text)
        'Dim RegIntercept As Single = Val(txtRegrIntercept.Text)

        'For I = 0 To NRows - 1
        '    XVal = dgvSpecPredictions.Rows(I).Cells(0).Value
        '    YPred = RegIntercept + XVal * RegSlope
        '    dgvSpecPredictions.Rows(I).Cells(1).Value = YPred
        'Next


        'dgvSpecPredictions.AllowUserToAddRows = True

    End Sub

    Private Sub PredictYValues()
        'Predict the Y Values corresponding to the XValues in dgvSpecPredictions:

        dgvSpecPredictions.AllowUserToAddRows = False

        Dim NRows As Integer = dgvSpecPredictions.Rows.Count
        Dim I As Integer
        Dim XVal As Single
        Dim YPred As Single

        Dim RegSlope As Single = Val(txtRegrSlope.Text)
        Dim RegIntercept As Single = Val(txtRegrIntercept.Text)

        For I = 0 To NRows - 1
            If dgvSpecPredictions.Rows(I).Cells(0).Value = "" Then
                XVal = 0
            Else
                XVal = dgvSpecPredictions.Rows(I).Cells(0).Value
            End If

            YPred = RegIntercept + XVal * RegSlope
            dgvSpecPredictions.Rows(I).Cells(1).Value = YPred
        Next

        dgvSpecPredictions.AllowUserToAddRows = True
    End Sub






#End Region 'Form Methods ---------------------------------------------------------------------------------------------------------------------------------------------------------------------



End Class