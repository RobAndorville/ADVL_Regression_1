<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLinearRegr
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
        Me.components = New System.ComponentModel.Container()
        Me.btnChart = New System.Windows.Forms.Button()
        Me.txtErrorStdDev = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtMeanSqError = New System.Windows.Forms.TextBox()
        Me.txtMeanError = New System.Windows.Forms.TextBox()
        Me.txtMeanPred = New System.Windows.Forms.TextBox()
        Me.txtMeanXY = New System.Windows.Forms.TextBox()
        Me.txtMeanXX = New System.Windows.Forms.TextBox()
        Me.txtMeanY = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtMeanX = New System.Windows.Forms.TextBox()
        Me.txtSumSqError = New System.Windows.Forms.TextBox()
        Me.txtSumError = New System.Windows.Forms.TextBox()
        Me.txtSumPred = New System.Windows.Forms.TextBox()
        Me.btnPredict = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dgvPredictions = New System.Windows.Forms.DataGridView()
        Me.txtCorrelation = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtRegrIntercept = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtRegrSlope = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtNPoints = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnRegression = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSumY = New System.Windows.Forms.TextBox()
        Me.txtSumX = New System.Windows.Forms.TextBox()
        Me.txtSumXY = New System.Windows.Forms.TextBox()
        Me.txtSumXX = New System.Windows.Forms.TextBox()
        Me.dgvCalculations = New System.Windows.Forms.DataGridView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtDatasetName = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtXName = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtYName = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.txtDatasetDescr = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtXUnits = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtXDescr = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtYUnits = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtYDescr = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSavePoints = New System.Windows.Forms.Button()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.btnOpenPoints = New System.Windows.Forms.Button()
        Me.dgvInputPoints = New System.Windows.Forms.DataGridView()
        Me.txtSumYY = New System.Windows.Forms.TextBox()
        Me.txtMeanYY = New System.Windows.Forms.TextBox()
        Me.dgvSpecPredictions = New System.Windows.Forms.DataGridView()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.chkAutoRegression = New System.Windows.Forms.CheckBox()
        Me.chkAutoPredict = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtRSquared = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        CType(Me.dgvPredictions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCalculations, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvInputPoints, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSpecPredictions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnChart
        '
        Me.btnChart.Location = New System.Drawing.Point(94, 12)
        Me.btnChart.Name = "btnChart"
        Me.btnChart.Size = New System.Drawing.Size(54, 22)
        Me.btnChart.TabIndex = 97
        Me.btnChart.Text = "Chart"
        Me.btnChart.UseVisualStyleBackColor = True
        '
        'txtErrorStdDev
        '
        Me.txtErrorStdDev.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtErrorStdDev.Location = New System.Drawing.Point(605, 168)
        Me.txtErrorStdDev.Name = "txtErrorStdDev"
        Me.txtErrorStdDev.ReadOnly = True
        Me.txtErrorStdDev.Size = New System.Drawing.Size(344, 20)
        Me.txtErrorStdDev.TabIndex = 96
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(496, 171)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(74, 13)
        Me.Label15.TabIndex = 95
        Me.Label15.Text = "Error Std Dev:"
        '
        'txtMeanSqError
        '
        Me.txtMeanSqError.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtMeanSqError.Location = New System.Drawing.Point(748, 762)
        Me.txtMeanSqError.Name = "txtMeanSqError"
        Me.txtMeanSqError.ReadOnly = True
        Me.txtMeanSqError.Size = New System.Drawing.Size(96, 20)
        Me.txtMeanSqError.TabIndex = 94
        '
        'txtMeanError
        '
        Me.txtMeanError.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtMeanError.Location = New System.Drawing.Point(646, 762)
        Me.txtMeanError.Name = "txtMeanError"
        Me.txtMeanError.ReadOnly = True
        Me.txtMeanError.Size = New System.Drawing.Size(96, 20)
        Me.txtMeanError.TabIndex = 93
        '
        'txtMeanPred
        '
        Me.txtMeanPred.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtMeanPred.Location = New System.Drawing.Point(544, 762)
        Me.txtMeanPred.Name = "txtMeanPred"
        Me.txtMeanPred.ReadOnly = True
        Me.txtMeanPred.Size = New System.Drawing.Size(96, 20)
        Me.txtMeanPred.TabIndex = 92
        '
        'txtMeanXY
        '
        Me.txtMeanXY.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtMeanXY.Location = New System.Drawing.Point(340, 762)
        Me.txtMeanXY.Name = "txtMeanXY"
        Me.txtMeanXY.ReadOnly = True
        Me.txtMeanXY.Size = New System.Drawing.Size(96, 20)
        Me.txtMeanXY.TabIndex = 91
        '
        'txtMeanXX
        '
        Me.txtMeanXX.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtMeanXX.Location = New System.Drawing.Point(238, 762)
        Me.txtMeanXX.Name = "txtMeanXX"
        Me.txtMeanXX.ReadOnly = True
        Me.txtMeanXX.Size = New System.Drawing.Size(96, 20)
        Me.txtMeanXX.TabIndex = 90
        '
        'txtMeanY
        '
        Me.txtMeanY.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtMeanY.Location = New System.Drawing.Point(134, 762)
        Me.txtMeanY.Name = "txtMeanY"
        Me.txtMeanY.ReadOnly = True
        Me.txtMeanY.Size = New System.Drawing.Size(96, 20)
        Me.txtMeanY.TabIndex = 89
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(9, 765)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(37, 13)
        Me.Label14.TabIndex = 88
        Me.Label14.Text = "Mean:"
        '
        'txtMeanX
        '
        Me.txtMeanX.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtMeanX.Location = New System.Drawing.Point(46, 762)
        Me.txtMeanX.Name = "txtMeanX"
        Me.txtMeanX.ReadOnly = True
        Me.txtMeanX.Size = New System.Drawing.Size(82, 20)
        Me.txtMeanX.TabIndex = 87
        '
        'txtSumSqError
        '
        Me.txtSumSqError.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSumSqError.Location = New System.Drawing.Point(748, 736)
        Me.txtSumSqError.Name = "txtSumSqError"
        Me.txtSumSqError.ReadOnly = True
        Me.txtSumSqError.Size = New System.Drawing.Size(96, 20)
        Me.txtSumSqError.TabIndex = 86
        '
        'txtSumError
        '
        Me.txtSumError.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSumError.Location = New System.Drawing.Point(646, 736)
        Me.txtSumError.Name = "txtSumError"
        Me.txtSumError.ReadOnly = True
        Me.txtSumError.Size = New System.Drawing.Size(96, 20)
        Me.txtSumError.TabIndex = 85
        '
        'txtSumPred
        '
        Me.txtSumPred.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSumPred.Location = New System.Drawing.Point(544, 736)
        Me.txtSumPred.Name = "txtSumPred"
        Me.txtSumPred.ReadOnly = True
        Me.txtSumPred.Size = New System.Drawing.Size(96, 20)
        Me.txtSumPred.TabIndex = 84
        '
        'btnPredict
        '
        Me.btnPredict.Location = New System.Drawing.Point(768, 194)
        Me.btnPredict.Name = "btnPredict"
        Me.btnPredict.Size = New System.Drawing.Size(76, 22)
        Me.btnPredict.TabIndex = 83
        Me.btnPredict.Text = "Predict"
        Me.btnPredict.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(541, 415)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 13)
        Me.Label13.TabIndex = 82
        Me.Label13.Text = "Y Predictions:"
        '
        'dgvPredictions
        '
        Me.dgvPredictions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvPredictions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPredictions.Location = New System.Drawing.Point(544, 431)
        Me.dgvPredictions.Name = "dgvPredictions"
        Me.dgvPredictions.Size = New System.Drawing.Size(300, 290)
        Me.dgvPredictions.TabIndex = 81
        '
        'txtCorrelation
        '
        Me.txtCorrelation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCorrelation.Location = New System.Drawing.Point(605, 116)
        Me.txtCorrelation.Name = "txtCorrelation"
        Me.txtCorrelation.ReadOnly = True
        Me.txtCorrelation.Size = New System.Drawing.Size(344, 20)
        Me.txtCorrelation.TabIndex = 80
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(495, 119)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 13)
        Me.Label12.TabIndex = 79
        Me.Label12.Text = "Correlation (r):"
        '
        'txtRegrIntercept
        '
        Me.txtRegrIntercept.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRegrIntercept.Location = New System.Drawing.Point(605, 90)
        Me.txtRegrIntercept.Name = "txtRegrIntercept"
        Me.txtRegrIntercept.Size = New System.Drawing.Size(344, 20)
        Me.txtRegrIntercept.TabIndex = 78
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(495, 93)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(104, 13)
        Me.Label11.TabIndex = 77
        Me.Label11.Text = "Regression intercept"
        '
        'txtRegrSlope
        '
        Me.txtRegrSlope.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRegrSlope.Location = New System.Drawing.Point(605, 63)
        Me.txtRegrSlope.Name = "txtRegrSlope"
        Me.txtRegrSlope.Size = New System.Drawing.Size(344, 20)
        Me.txtRegrSlope.TabIndex = 76
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(494, 66)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(91, 13)
        Me.Label10.TabIndex = 75
        Me.Label10.Text = "Regression slope:"
        '
        'txtNPoints
        '
        Me.txtNPoints.Location = New System.Drawing.Point(605, 37)
        Me.txtNPoints.Name = "txtNPoints"
        Me.txtNPoints.ReadOnly = True
        Me.txtNPoints.Size = New System.Drawing.Size(82, 20)
        Me.txtNPoints.TabIndex = 74
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(495, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 13)
        Me.Label9.TabIndex = 73
        Me.Label9.Text = "N input points:"
        '
        'btnRegression
        '
        Me.btnRegression.Location = New System.Drawing.Point(12, 12)
        Me.btnRegression.Name = "btnRegression"
        Me.btnRegression.Size = New System.Drawing.Size(76, 22)
        Me.btnRegression.TabIndex = 72
        Me.btnRegression.Text = "Regression"
        Me.btnRegression.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 739)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 13)
        Me.Label8.TabIndex = 66
        Me.Label8.Text = "Sum:"
        '
        'txtSumY
        '
        Me.txtSumY.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSumY.Location = New System.Drawing.Point(134, 736)
        Me.txtSumY.Name = "txtSumY"
        Me.txtSumY.ReadOnly = True
        Me.txtSumY.Size = New System.Drawing.Size(96, 20)
        Me.txtSumY.TabIndex = 71
        '
        'txtSumX
        '
        Me.txtSumX.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSumX.Location = New System.Drawing.Point(46, 736)
        Me.txtSumX.Name = "txtSumX"
        Me.txtSumX.ReadOnly = True
        Me.txtSumX.Size = New System.Drawing.Size(82, 20)
        Me.txtSumX.TabIndex = 70
        '
        'txtSumXY
        '
        Me.txtSumXY.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSumXY.Location = New System.Drawing.Point(340, 736)
        Me.txtSumXY.Name = "txtSumXY"
        Me.txtSumXY.ReadOnly = True
        Me.txtSumXY.Size = New System.Drawing.Size(96, 20)
        Me.txtSumXY.TabIndex = 69
        '
        'txtSumXX
        '
        Me.txtSumXX.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSumXX.Location = New System.Drawing.Point(238, 736)
        Me.txtSumXX.Name = "txtSumXX"
        Me.txtSumXX.ReadOnly = True
        Me.txtSumXX.Size = New System.Drawing.Size(96, 20)
        Me.txtSumXX.TabIndex = 68
        '
        'dgvCalculations
        '
        Me.dgvCalculations.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvCalculations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCalculations.Location = New System.Drawing.Point(238, 431)
        Me.dgvCalculations.Name = "dgvCalculations"
        Me.dgvCalculations.Size = New System.Drawing.Size(300, 290)
        Me.dgvCalculations.TabIndex = 67
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(235, 414)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 13)
        Me.Label7.TabIndex = 65
        Me.Label7.Text = "Calculations:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 414)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 13)
        Me.Label6.TabIndex = 64
        Me.Label6.Text = "Input Data Points:"
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(901, 12)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(48, 22)
        Me.btnExit.TabIndex = 63
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.txtDatasetName)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.txtXName)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtYName)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.btnClear)
        Me.GroupBox1.Controls.Add(Me.txtDatasetDescr)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtXUnits)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtXDescr)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtYUnits)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtYDescr)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnSavePoints)
        Me.GroupBox1.Controls.Add(Me.txtFileName)
        Me.GroupBox1.Controls.Add(Me.btnOpenPoints)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(476, 355)
        Me.GroupBox1.TabIndex = 62
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Input Data Points:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 105)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(38, 13)
        Me.Label21.TabIndex = 38
        Me.Label21.Text = "Descr:"
        '
        'txtDatasetName
        '
        Me.txtDatasetName.Location = New System.Drawing.Point(91, 73)
        Me.txtDatasetName.Name = "txtDatasetName"
        Me.txtDatasetName.Size = New System.Drawing.Size(379, 20)
        Me.txtDatasetName.TabIndex = 37
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(6, 299)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(38, 13)
        Me.Label20.TabIndex = 36
        Me.Label20.Text = "Descr:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 276)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(38, 13)
        Me.Label19.TabIndex = 35
        Me.Label19.Text = "Name:"
        '
        'txtXName
        '
        Me.txtXName.Location = New System.Drawing.Point(50, 273)
        Me.txtXName.Name = "txtXName"
        Me.txtXName.Size = New System.Drawing.Size(318, 20)
        Me.txtXName.TabIndex = 34
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 201)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(38, 13)
        Me.Label18.TabIndex = 33
        Me.Label18.Text = "Descr:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 178)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(38, 13)
        Me.Label17.TabIndex = 32
        Me.Label17.Text = "Name:"
        '
        'txtYName
        '
        Me.txtYName.Location = New System.Drawing.Point(50, 175)
        Me.txtYName.Name = "txtYName"
        Me.txtYName.Size = New System.Drawing.Size(318, 20)
        Me.txtYName.TabIndex = 31
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 50)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(55, 13)
        Me.Label16.TabIndex = 30
        Me.Label16.Text = "File name:"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(108, 19)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(45, 22)
        Me.btnClear.TabIndex = 29
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'txtDatasetDescr
        '
        Me.txtDatasetDescr.Location = New System.Drawing.Point(50, 102)
        Me.txtDatasetDescr.Multiline = True
        Me.txtDatasetDescr.Name = "txtDatasetDescr"
        Me.txtDatasetDescr.Size = New System.Drawing.Size(420, 49)
        Me.txtDatasetDescr.TabIndex = 28
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Data set name:"
        '
        'txtXUnits
        '
        Me.txtXUnits.Location = New System.Drawing.Point(374, 273)
        Me.txtXUnits.Name = "txtXUnits"
        Me.txtXUnits.Size = New System.Drawing.Size(96, 20)
        Me.txtXUnits.TabIndex = 26
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(371, 257)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Units:"
        '
        'txtXDescr
        '
        Me.txtXDescr.Location = New System.Drawing.Point(50, 299)
        Me.txtXDescr.Multiline = True
        Me.txtXDescr.Name = "txtXDescr"
        Me.txtXDescr.Size = New System.Drawing.Size(420, 47)
        Me.txtXDescr.TabIndex = 24
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 257)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "X values:"
        '
        'txtYUnits
        '
        Me.txtYUnits.Location = New System.Drawing.Point(374, 175)
        Me.txtYUnits.Name = "txtYUnits"
        Me.txtYUnits.Size = New System.Drawing.Size(96, 20)
        Me.txtYUnits.TabIndex = 22
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(371, 159)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Units:"
        '
        'txtYDescr
        '
        Me.txtYDescr.Location = New System.Drawing.Point(50, 201)
        Me.txtYDescr.Multiline = True
        Me.txtYDescr.Name = "txtYDescr"
        Me.txtYDescr.Size = New System.Drawing.Size(420, 47)
        Me.txtYDescr.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 159)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Y values:"
        '
        'btnSavePoints
        '
        Me.btnSavePoints.Location = New System.Drawing.Point(57, 19)
        Me.btnSavePoints.Name = "btnSavePoints"
        Me.btnSavePoints.Size = New System.Drawing.Size(45, 22)
        Me.btnSavePoints.TabIndex = 18
        Me.btnSavePoints.Text = "Save"
        Me.btnSavePoints.UseVisualStyleBackColor = True
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(67, 47)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(403, 20)
        Me.txtFileName.TabIndex = 17
        '
        'btnOpenPoints
        '
        Me.btnOpenPoints.Location = New System.Drawing.Point(6, 19)
        Me.btnOpenPoints.Name = "btnOpenPoints"
        Me.btnOpenPoints.Size = New System.Drawing.Size(45, 22)
        Me.btnOpenPoints.TabIndex = 15
        Me.btnOpenPoints.Text = "Open"
        Me.btnOpenPoints.UseVisualStyleBackColor = True
        '
        'dgvInputPoints
        '
        Me.dgvInputPoints.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvInputPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInputPoints.Location = New System.Drawing.Point(12, 431)
        Me.dgvInputPoints.Name = "dgvInputPoints"
        Me.dgvInputPoints.Size = New System.Drawing.Size(220, 290)
        Me.dgvInputPoints.TabIndex = 61
        '
        'txtSumYY
        '
        Me.txtSumYY.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSumYY.Location = New System.Drawing.Point(442, 736)
        Me.txtSumYY.Name = "txtSumYY"
        Me.txtSumYY.ReadOnly = True
        Me.txtSumYY.Size = New System.Drawing.Size(96, 20)
        Me.txtSumYY.TabIndex = 98
        '
        'txtMeanYY
        '
        Me.txtMeanYY.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtMeanYY.Location = New System.Drawing.Point(442, 762)
        Me.txtMeanYY.Name = "txtMeanYY"
        Me.txtMeanYY.ReadOnly = True
        Me.txtMeanYY.Size = New System.Drawing.Size(96, 20)
        Me.txtMeanYY.TabIndex = 99
        '
        'dgvSpecPredictions
        '
        Me.dgvSpecPredictions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSpecPredictions.Location = New System.Drawing.Point(544, 220)
        Me.dgvSpecPredictions.Name = "dgvSpecPredictions"
        Me.dgvSpecPredictions.Size = New System.Drawing.Size(300, 192)
        Me.dgvSpecPredictions.TabIndex = 100
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(541, 204)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(172, 13)
        Me.Label22.TabIndex = 101
        Me.Label22.Text = "Y predictions at specified X values:"
        '
        'chkAutoRegression
        '
        Me.chkAutoRegression.AutoSize = True
        Me.chkAutoRegression.Location = New System.Drawing.Point(154, 16)
        Me.chkAutoRegression.Name = "chkAutoRegression"
        Me.chkAutoRegression.Size = New System.Drawing.Size(104, 17)
        Me.chkAutoRegression.TabIndex = 102
        Me.chkAutoRegression.Text = "Auto Regression"
        Me.ToolTip1.SetToolTip(Me.chkAutoRegression, "Apply regression automatically when Input points are loaded")
        Me.chkAutoRegression.UseVisualStyleBackColor = True
        '
        'chkAutoPredict
        '
        Me.chkAutoPredict.AutoSize = True
        Me.chkAutoPredict.Location = New System.Drawing.Point(264, 16)
        Me.chkAutoPredict.Name = "chkAutoPredict"
        Me.chkAutoPredict.Size = New System.Drawing.Size(84, 17)
        Me.chkAutoPredict.TabIndex = 103
        Me.chkAutoPredict.Text = "Auto Predict"
        Me.ToolTip1.SetToolTip(Me.chkAutoPredict, "Generate Y Value predictions automatically")
        Me.chkAutoPredict.UseVisualStyleBackColor = True
        '
        'txtRSquared
        '
        Me.txtRSquared.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRSquared.Location = New System.Drawing.Point(605, 142)
        Me.txtRSquared.Name = "txtRSquared"
        Me.txtRSquared.ReadOnly = True
        Me.txtRSquared.Size = New System.Drawing.Size(344, 20)
        Me.txtRSquared.TabIndex = 104
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(496, 145)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(59, 13)
        Me.Label23.TabIndex = 105
        Me.Label23.Text = "R squared:"
        '
        'frmLinearRegr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(961, 794)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.txtRSquared)
        Me.Controls.Add(Me.chkAutoPredict)
        Me.Controls.Add(Me.chkAutoRegression)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.dgvSpecPredictions)
        Me.Controls.Add(Me.txtMeanYY)
        Me.Controls.Add(Me.txtSumYY)
        Me.Controls.Add(Me.btnChart)
        Me.Controls.Add(Me.txtErrorStdDev)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtMeanSqError)
        Me.Controls.Add(Me.txtMeanError)
        Me.Controls.Add(Me.txtMeanPred)
        Me.Controls.Add(Me.txtMeanXY)
        Me.Controls.Add(Me.txtMeanXX)
        Me.Controls.Add(Me.txtMeanY)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtMeanX)
        Me.Controls.Add(Me.txtSumSqError)
        Me.Controls.Add(Me.txtSumError)
        Me.Controls.Add(Me.txtSumPred)
        Me.Controls.Add(Me.btnPredict)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.dgvPredictions)
        Me.Controls.Add(Me.txtCorrelation)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtRegrIntercept)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtRegrSlope)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtNPoints)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnRegression)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtSumY)
        Me.Controls.Add(Me.txtSumX)
        Me.Controls.Add(Me.txtSumXY)
        Me.Controls.Add(Me.txtSumXX)
        Me.Controls.Add(Me.dgvCalculations)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvInputPoints)
        Me.Name = "frmLinearRegr"
        Me.Text = "Linear Regression"
        CType(Me.dgvPredictions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCalculations, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvInputPoints, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSpecPredictions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnChart As Button
    Friend WithEvents txtErrorStdDev As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtMeanSqError As TextBox
    Friend WithEvents txtMeanError As TextBox
    Friend WithEvents txtMeanPred As TextBox
    Friend WithEvents txtMeanXY As TextBox
    Friend WithEvents txtMeanXX As TextBox
    Friend WithEvents txtMeanY As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtMeanX As TextBox
    Friend WithEvents txtSumSqError As TextBox
    Friend WithEvents txtSumError As TextBox
    Friend WithEvents txtSumPred As TextBox
    Friend WithEvents btnPredict As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents dgvPredictions As DataGridView
    Friend WithEvents txtCorrelation As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtRegrIntercept As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtRegrSlope As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtNPoints As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents btnRegression As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents txtSumY As TextBox
    Friend WithEvents txtSumX As TextBox
    Friend WithEvents txtSumXY As TextBox
    Friend WithEvents txtSumXX As TextBox
    Friend WithEvents dgvCalculations As DataGridView
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btnExit As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label21 As Label
    Friend WithEvents txtDatasetName As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents txtXName As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents txtYName As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents btnClear As Button
    Friend WithEvents txtDatasetDescr As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtXUnits As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtXDescr As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtYUnits As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtYDescr As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSavePoints As Button
    Friend WithEvents txtFileName As TextBox
    Friend WithEvents btnOpenPoints As Button
    Friend WithEvents dgvInputPoints As DataGridView
    Friend WithEvents txtSumYY As TextBox
    Friend WithEvents txtMeanYY As TextBox
    Friend WithEvents dgvSpecPredictions As DataGridView
    Friend WithEvents Label22 As Label
    Friend WithEvents chkAutoRegression As CheckBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents chkAutoPredict As CheckBox
    Friend WithEvents txtRSquared As TextBox
    Friend WithEvents Label23 As Label
End Class
