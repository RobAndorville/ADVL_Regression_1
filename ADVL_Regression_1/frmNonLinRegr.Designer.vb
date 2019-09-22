<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNonLinRegr
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
        Me.btnChart = New System.Windows.Forms.Button()
        Me.txtErrorStdDev = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtMeanSqError = New System.Windows.Forms.TextBox()
        Me.txtMeanError = New System.Windows.Forms.TextBox()
        Me.txtMeanPred = New System.Windows.Forms.TextBox()
        Me.txtMeanTransXY = New System.Windows.Forms.TextBox()
        Me.txtMeanTransXX = New System.Windows.Forms.TextBox()
        Me.txtMeanY = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtMeanX = New System.Windows.Forms.TextBox()
        Me.txtSumSqError = New System.Windows.Forms.TextBox()
        Me.txtSumError = New System.Windows.Forms.TextBox()
        Me.txtSumPred = New System.Windows.Forms.TextBox()
        Me.btnPredict = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dgvTransPredictions = New System.Windows.Forms.DataGridView()
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
        Me.txtSumTransXY = New System.Windows.Forms.TextBox()
        Me.txtSumTransXX = New System.Windows.Forms.TextBox()
        Me.dgvTransCalculations = New System.Windows.Forms.DataGridView()
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
        Me.dgvTransformedPoints = New System.Windows.Forms.DataGridView()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cmbXTrans = New System.Windows.Forms.ComboBox()
        Me.cmbYTrans = New System.Windows.Forms.ComboBox()
        Me.txtMeanTransX = New System.Windows.Forms.TextBox()
        Me.txtSumTransX = New System.Windows.Forms.TextBox()
        Me.txtMeanTransY = New System.Windows.Forms.TextBox()
        Me.txtSumTransY = New System.Windows.Forms.TextBox()
        Me.cmbRegrModel = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.dgvPredictions = New System.Windows.Forms.DataGridView()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtMeanTransPred = New System.Windows.Forms.TextBox()
        Me.txtSumTransPred = New System.Windows.Forms.TextBox()
        Me.txtMeanTransError = New System.Windows.Forms.TextBox()
        Me.txtSumTransError = New System.Windows.Forms.TextBox()
        Me.txtSumSqTransError = New System.Windows.Forms.TextBox()
        Me.txtMeanSqTransError = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtRegressionModel = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtSumTransYY = New System.Windows.Forms.TextBox()
        Me.txtMeanTransYY = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtUTErrorStdDev = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.dgvSpecPredictions = New System.Windows.Forms.DataGridView()
        Me.chkAutoPredict = New System.Windows.Forms.CheckBox()
        Me.chkAutoRegression = New System.Windows.Forms.CheckBox()
        CType(Me.dgvTransPredictions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTransCalculations, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvInputPoints, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTransformedPoints, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPredictions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvSpecPredictions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnChart
        '
        Me.btnChart.Location = New System.Drawing.Point(94, 12)
        Me.btnChart.Name = "btnChart"
        Me.btnChart.Size = New System.Drawing.Size(54, 22)
        Me.btnChart.TabIndex = 134
        Me.btnChart.Text = "Chart"
        Me.btnChart.UseVisualStyleBackColor = True
        '
        'txtErrorStdDev
        '
        Me.txtErrorStdDev.Location = New System.Drawing.Point(116, 124)
        Me.txtErrorStdDev.Name = "txtErrorStdDev"
        Me.txtErrorStdDev.ReadOnly = True
        Me.txtErrorStdDev.Size = New System.Drawing.Size(151, 20)
        Me.txtErrorStdDev.TabIndex = 133
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 127)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(74, 13)
        Me.Label15.TabIndex = 132
        Me.Label15.Text = "Error Std Dev:"
        '
        'txtMeanSqError
        '
        Me.txtMeanSqError.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtMeanSqError.Location = New System.Drawing.Point(1322, 741)
        Me.txtMeanSqError.Name = "txtMeanSqError"
        Me.txtMeanSqError.ReadOnly = True
        Me.txtMeanSqError.Size = New System.Drawing.Size(96, 20)
        Me.txtMeanSqError.TabIndex = 131
        '
        'txtMeanError
        '
        Me.txtMeanError.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtMeanError.Location = New System.Drawing.Point(1220, 741)
        Me.txtMeanError.Name = "txtMeanError"
        Me.txtMeanError.ReadOnly = True
        Me.txtMeanError.Size = New System.Drawing.Size(96, 20)
        Me.txtMeanError.TabIndex = 130
        '
        'txtMeanPred
        '
        Me.txtMeanPred.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtMeanPred.Location = New System.Drawing.Point(1118, 741)
        Me.txtMeanPred.Name = "txtMeanPred"
        Me.txtMeanPred.ReadOnly = True
        Me.txtMeanPred.Size = New System.Drawing.Size(96, 20)
        Me.txtMeanPred.TabIndex = 129
        '
        'txtMeanTransXY
        '
        Me.txtMeanTransXY.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtMeanTransXY.Location = New System.Drawing.Point(586, 741)
        Me.txtMeanTransXY.Name = "txtMeanTransXY"
        Me.txtMeanTransXY.ReadOnly = True
        Me.txtMeanTransXY.Size = New System.Drawing.Size(96, 20)
        Me.txtMeanTransXY.TabIndex = 128
        '
        'txtMeanTransXX
        '
        Me.txtMeanTransXX.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtMeanTransXX.Location = New System.Drawing.Point(484, 741)
        Me.txtMeanTransXX.Name = "txtMeanTransXX"
        Me.txtMeanTransXX.ReadOnly = True
        Me.txtMeanTransXX.Size = New System.Drawing.Size(96, 20)
        Me.txtMeanTransXX.TabIndex = 127
        '
        'txtMeanY
        '
        Me.txtMeanY.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtMeanY.Location = New System.Drawing.Point(134, 741)
        Me.txtMeanY.Name = "txtMeanY"
        Me.txtMeanY.ReadOnly = True
        Me.txtMeanY.Size = New System.Drawing.Size(96, 20)
        Me.txtMeanY.TabIndex = 126
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(9, 744)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(37, 13)
        Me.Label14.TabIndex = 125
        Me.Label14.Text = "Mean:"
        '
        'txtMeanX
        '
        Me.txtMeanX.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtMeanX.Location = New System.Drawing.Point(46, 741)
        Me.txtMeanX.Name = "txtMeanX"
        Me.txtMeanX.ReadOnly = True
        Me.txtMeanX.Size = New System.Drawing.Size(82, 20)
        Me.txtMeanX.TabIndex = 124
        '
        'txtSumSqError
        '
        Me.txtSumSqError.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSumSqError.Location = New System.Drawing.Point(1322, 715)
        Me.txtSumSqError.Name = "txtSumSqError"
        Me.txtSumSqError.ReadOnly = True
        Me.txtSumSqError.Size = New System.Drawing.Size(96, 20)
        Me.txtSumSqError.TabIndex = 123
        '
        'txtSumError
        '
        Me.txtSumError.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSumError.Location = New System.Drawing.Point(1220, 715)
        Me.txtSumError.Name = "txtSumError"
        Me.txtSumError.ReadOnly = True
        Me.txtSumError.Size = New System.Drawing.Size(96, 20)
        Me.txtSumError.TabIndex = 122
        '
        'txtSumPred
        '
        Me.txtSumPred.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSumPred.Location = New System.Drawing.Point(1118, 715)
        Me.txtSumPred.Name = "txtSumPred"
        Me.txtSumPred.ReadOnly = True
        Me.txtSumPred.Size = New System.Drawing.Size(96, 20)
        Me.txtSumPred.TabIndex = 121
        '
        'btnPredict
        '
        Me.btnPredict.Location = New System.Drawing.Point(1014, 28)
        Me.btnPredict.Name = "btnPredict"
        Me.btnPredict.Size = New System.Drawing.Size(76, 22)
        Me.btnPredict.TabIndex = 120
        Me.btnPredict.Text = "Predict"
        Me.btnPredict.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(787, 398)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(124, 13)
        Me.Label13.TabIndex = 119
        Me.Label13.Text = "Transformed Predictions:"
        '
        'dgvTransPredictions
        '
        Me.dgvTransPredictions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvTransPredictions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTransPredictions.Location = New System.Drawing.Point(790, 414)
        Me.dgvTransPredictions.Name = "dgvTransPredictions"
        Me.dgvTransPredictions.Size = New System.Drawing.Size(310, 268)
        Me.dgvTransPredictions.TabIndex = 118
        '
        'txtCorrelation
        '
        Me.txtCorrelation.Location = New System.Drawing.Point(116, 98)
        Me.txtCorrelation.Name = "txtCorrelation"
        Me.txtCorrelation.ReadOnly = True
        Me.txtCorrelation.Size = New System.Drawing.Size(151, 20)
        Me.txtCorrelation.TabIndex = 117
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 101)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 13)
        Me.Label12.TabIndex = 116
        Me.Label12.Text = "Correlation (r):"
        '
        'txtRegrIntercept
        '
        Me.txtRegrIntercept.Location = New System.Drawing.Point(116, 71)
        Me.txtRegrIntercept.Name = "txtRegrIntercept"
        Me.txtRegrIntercept.Size = New System.Drawing.Size(151, 20)
        Me.txtRegrIntercept.TabIndex = 115
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 74)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(104, 13)
        Me.Label11.TabIndex = 114
        Me.Label11.Text = "Regression intercept"
        '
        'txtRegrSlope
        '
        Me.txtRegrSlope.Location = New System.Drawing.Point(116, 45)
        Me.txtRegrSlope.Name = "txtRegrSlope"
        Me.txtRegrSlope.Size = New System.Drawing.Size(151, 20)
        Me.txtRegrSlope.TabIndex = 113
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 48)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(91, 13)
        Me.Label10.TabIndex = 112
        Me.Label10.Text = "Regression slope:"
        '
        'txtNPoints
        '
        Me.txtNPoints.Location = New System.Drawing.Point(614, 37)
        Me.txtNPoints.Name = "txtNPoints"
        Me.txtNPoints.ReadOnly = True
        Me.txtNPoints.Size = New System.Drawing.Size(82, 20)
        Me.txtNPoints.TabIndex = 111
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(504, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 13)
        Me.Label9.TabIndex = 110
        Me.Label9.Text = "N input points:"
        '
        'btnRegression
        '
        Me.btnRegression.Location = New System.Drawing.Point(12, 12)
        Me.btnRegression.Name = "btnRegression"
        Me.btnRegression.Size = New System.Drawing.Size(76, 22)
        Me.btnRegression.TabIndex = 109
        Me.btnRegression.Text = "Regression"
        Me.btnRegression.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 718)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 13)
        Me.Label8.TabIndex = 103
        Me.Label8.Text = "Sum:"
        '
        'txtSumY
        '
        Me.txtSumY.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSumY.Location = New System.Drawing.Point(134, 715)
        Me.txtSumY.Name = "txtSumY"
        Me.txtSumY.ReadOnly = True
        Me.txtSumY.Size = New System.Drawing.Size(96, 20)
        Me.txtSumY.TabIndex = 108
        '
        'txtSumX
        '
        Me.txtSumX.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSumX.Location = New System.Drawing.Point(46, 715)
        Me.txtSumX.Name = "txtSumX"
        Me.txtSumX.ReadOnly = True
        Me.txtSumX.Size = New System.Drawing.Size(82, 20)
        Me.txtSumX.TabIndex = 107
        '
        'txtSumTransXY
        '
        Me.txtSumTransXY.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSumTransXY.Location = New System.Drawing.Point(586, 715)
        Me.txtSumTransXY.Name = "txtSumTransXY"
        Me.txtSumTransXY.ReadOnly = True
        Me.txtSumTransXY.Size = New System.Drawing.Size(96, 20)
        Me.txtSumTransXY.TabIndex = 106
        '
        'txtSumTransXX
        '
        Me.txtSumTransXX.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSumTransXX.Location = New System.Drawing.Point(484, 715)
        Me.txtSumTransXX.Name = "txtSumTransXX"
        Me.txtSumTransXX.ReadOnly = True
        Me.txtSumTransXX.Size = New System.Drawing.Size(96, 20)
        Me.txtSumTransXX.TabIndex = 105
        '
        'dgvTransCalculations
        '
        Me.dgvTransCalculations.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvTransCalculations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTransCalculations.Location = New System.Drawing.Point(484, 414)
        Me.dgvTransCalculations.Name = "dgvTransCalculations"
        Me.dgvTransCalculations.Size = New System.Drawing.Size(300, 268)
        Me.dgvTransCalculations.TabIndex = 104
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(481, 398)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(161, 13)
        Me.Label7.TabIndex = 102
        Me.Label7.Text = "Transformed Points Calculations:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 398)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 13)
        Me.Label6.TabIndex = 101
        Me.Label6.Text = "Input Data Points:"
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(1387, 12)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(48, 22)
        Me.btnExit.TabIndex = 100
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
        Me.GroupBox1.TabIndex = 99
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
        Me.dgvInputPoints.Location = New System.Drawing.Point(12, 414)
        Me.dgvInputPoints.Name = "dgvInputPoints"
        Me.dgvInputPoints.Size = New System.Drawing.Size(230, 268)
        Me.dgvInputPoints.TabIndex = 98
        '
        'dgvTransformedPoints
        '
        Me.dgvTransformedPoints.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvTransformedPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTransformedPoints.Location = New System.Drawing.Point(248, 414)
        Me.dgvTransformedPoints.Name = "dgvTransformedPoints"
        Me.dgvTransformedPoints.Size = New System.Drawing.Size(230, 268)
        Me.dgvTransformedPoints.TabIndex = 135
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(245, 398)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(101, 13)
        Me.Label22.TabIndex = 136
        Me.Label22.Text = "Transformed Points:"
        '
        'cmbXTrans
        '
        Me.cmbXTrans.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbXTrans.FormattingEnabled = True
        Me.cmbXTrans.Location = New System.Drawing.Point(248, 688)
        Me.cmbXTrans.Name = "cmbXTrans"
        Me.cmbXTrans.Size = New System.Drawing.Size(96, 21)
        Me.cmbXTrans.TabIndex = 137
        '
        'cmbYTrans
        '
        Me.cmbYTrans.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbYTrans.FormattingEnabled = True
        Me.cmbYTrans.Location = New System.Drawing.Point(350, 688)
        Me.cmbYTrans.Name = "cmbYTrans"
        Me.cmbYTrans.Size = New System.Drawing.Size(98, 21)
        Me.cmbYTrans.TabIndex = 138
        '
        'txtMeanTransX
        '
        Me.txtMeanTransX.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtMeanTransX.Location = New System.Drawing.Point(248, 741)
        Me.txtMeanTransX.Name = "txtMeanTransX"
        Me.txtMeanTransX.ReadOnly = True
        Me.txtMeanTransX.Size = New System.Drawing.Size(82, 20)
        Me.txtMeanTransX.TabIndex = 139
        '
        'txtSumTransX
        '
        Me.txtSumTransX.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSumTransX.Location = New System.Drawing.Point(248, 715)
        Me.txtSumTransX.Name = "txtSumTransX"
        Me.txtSumTransX.ReadOnly = True
        Me.txtSumTransX.Size = New System.Drawing.Size(82, 20)
        Me.txtSumTransX.TabIndex = 140
        '
        'txtMeanTransY
        '
        Me.txtMeanTransY.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtMeanTransY.Location = New System.Drawing.Point(350, 741)
        Me.txtMeanTransY.Name = "txtMeanTransY"
        Me.txtMeanTransY.ReadOnly = True
        Me.txtMeanTransY.Size = New System.Drawing.Size(96, 20)
        Me.txtMeanTransY.TabIndex = 141
        '
        'txtSumTransY
        '
        Me.txtSumTransY.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSumTransY.Location = New System.Drawing.Point(350, 715)
        Me.txtSumTransY.Name = "txtSumTransY"
        Me.txtSumTransY.ReadOnly = True
        Me.txtSumTransY.Size = New System.Drawing.Size(96, 20)
        Me.txtSumTransY.TabIndex = 142
        '
        'cmbRegrModel
        '
        Me.cmbRegrModel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbRegrModel.FormattingEnabled = True
        Me.cmbRegrModel.Location = New System.Drawing.Point(103, 688)
        Me.cmbRegrModel.Name = "cmbRegrModel"
        Me.cmbRegrModel.Size = New System.Drawing.Size(139, 21)
        Me.cmbRegrModel.TabIndex = 143
        '
        'Label23
        '
        Me.Label23.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(8, 691)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(95, 13)
        Me.Label23.TabIndex = 144
        Me.Label23.Text = "Regression Model:"
        '
        'dgvPredictions
        '
        Me.dgvPredictions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvPredictions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPredictions.Location = New System.Drawing.Point(1106, 414)
        Me.dgvPredictions.Name = "dgvPredictions"
        Me.dgvPredictions.Size = New System.Drawing.Size(310, 268)
        Me.dgvPredictions.TabIndex = 145
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(1103, 398)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(62, 13)
        Me.Label24.TabIndex = 146
        Me.Label24.Text = "Predictions:"
        '
        'txtMeanTransPred
        '
        Me.txtMeanTransPred.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtMeanTransPred.Location = New System.Drawing.Point(802, 741)
        Me.txtMeanTransPred.Name = "txtMeanTransPred"
        Me.txtMeanTransPred.ReadOnly = True
        Me.txtMeanTransPred.Size = New System.Drawing.Size(96, 20)
        Me.txtMeanTransPred.TabIndex = 147
        '
        'txtSumTransPred
        '
        Me.txtSumTransPred.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSumTransPred.Location = New System.Drawing.Point(802, 715)
        Me.txtSumTransPred.Name = "txtSumTransPred"
        Me.txtSumTransPred.ReadOnly = True
        Me.txtSumTransPred.Size = New System.Drawing.Size(96, 20)
        Me.txtSumTransPred.TabIndex = 148
        '
        'txtMeanTransError
        '
        Me.txtMeanTransError.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtMeanTransError.Location = New System.Drawing.Point(904, 741)
        Me.txtMeanTransError.Name = "txtMeanTransError"
        Me.txtMeanTransError.ReadOnly = True
        Me.txtMeanTransError.Size = New System.Drawing.Size(96, 20)
        Me.txtMeanTransError.TabIndex = 149
        '
        'txtSumTransError
        '
        Me.txtSumTransError.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSumTransError.Location = New System.Drawing.Point(904, 715)
        Me.txtSumTransError.Name = "txtSumTransError"
        Me.txtSumTransError.ReadOnly = True
        Me.txtSumTransError.Size = New System.Drawing.Size(96, 20)
        Me.txtSumTransError.TabIndex = 150
        '
        'txtSumSqTransError
        '
        Me.txtSumSqTransError.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSumSqTransError.Location = New System.Drawing.Point(1006, 715)
        Me.txtSumSqTransError.Name = "txtSumSqTransError"
        Me.txtSumSqTransError.ReadOnly = True
        Me.txtSumSqTransError.Size = New System.Drawing.Size(96, 20)
        Me.txtSumSqTransError.TabIndex = 151
        '
        'txtMeanSqTransError
        '
        Me.txtMeanSqTransError.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtMeanSqTransError.Location = New System.Drawing.Point(1006, 741)
        Me.txtMeanSqTransError.Name = "txtMeanSqTransError"
        Me.txtMeanSqTransError.ReadOnly = True
        Me.txtMeanSqTransError.Size = New System.Drawing.Size(96, 20)
        Me.txtMeanSqTransError.TabIndex = 152
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtRegressionModel)
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Controls.Add(Me.txtRegrSlope)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtRegrIntercept)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtCorrelation)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtErrorStdDev)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Location = New System.Drawing.Point(498, 63)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(273, 157)
        Me.GroupBox2.TabIndex = 153
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Transformed Data:"
        '
        'txtRegressionModel
        '
        Me.txtRegressionModel.Location = New System.Drawing.Point(116, 19)
        Me.txtRegressionModel.Name = "txtRegressionModel"
        Me.txtRegressionModel.ReadOnly = True
        Me.txtRegressionModel.Size = New System.Drawing.Size(151, 20)
        Me.txtRegressionModel.TabIndex = 135
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(6, 22)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(39, 13)
        Me.Label25.TabIndex = 134
        Me.Label25.Text = "Model:"
        '
        'txtSumTransYY
        '
        Me.txtSumTransYY.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSumTransYY.Location = New System.Drawing.Point(688, 715)
        Me.txtSumTransYY.Name = "txtSumTransYY"
        Me.txtSumTransYY.ReadOnly = True
        Me.txtSumTransYY.Size = New System.Drawing.Size(96, 20)
        Me.txtSumTransYY.TabIndex = 154
        '
        'txtMeanTransYY
        '
        Me.txtMeanTransYY.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtMeanTransYY.Location = New System.Drawing.Point(688, 741)
        Me.txtMeanTransYY.Name = "txtMeanTransYY"
        Me.txtMeanTransYY.ReadOnly = True
        Me.txtMeanTransYY.Size = New System.Drawing.Size(96, 20)
        Me.txtMeanTransYY.TabIndex = 155
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtUTErrorStdDev)
        Me.GroupBox3.Controls.Add(Me.Label27)
        Me.GroupBox3.Location = New System.Drawing.Point(498, 237)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(272, 51)
        Me.GroupBox3.TabIndex = 156
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Un-Transformed Data:"
        '
        'txtUTErrorStdDev
        '
        Me.txtUTErrorStdDev.Location = New System.Drawing.Point(115, 19)
        Me.txtUTErrorStdDev.Name = "txtUTErrorStdDev"
        Me.txtUTErrorStdDev.ReadOnly = True
        Me.txtUTErrorStdDev.Size = New System.Drawing.Size(151, 20)
        Me.txtUTErrorStdDev.TabIndex = 137
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(5, 22)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(74, 13)
        Me.Label27.TabIndex = 136
        Me.Label27.Text = "Error Std Dev:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(787, 40)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(172, 13)
        Me.Label26.TabIndex = 158
        Me.Label26.Text = "Y predictions at specified X values:"
        '
        'dgvSpecPredictions
        '
        Me.dgvSpecPredictions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSpecPredictions.Location = New System.Drawing.Point(790, 56)
        Me.dgvSpecPredictions.Name = "dgvSpecPredictions"
        Me.dgvSpecPredictions.Size = New System.Drawing.Size(300, 330)
        Me.dgvSpecPredictions.TabIndex = 157
        '
        'chkAutoPredict
        '
        Me.chkAutoPredict.AutoSize = True
        Me.chkAutoPredict.Location = New System.Drawing.Point(264, 16)
        Me.chkAutoPredict.Name = "chkAutoPredict"
        Me.chkAutoPredict.Size = New System.Drawing.Size(84, 17)
        Me.chkAutoPredict.TabIndex = 160
        Me.chkAutoPredict.Text = "Auto Predict"
        Me.chkAutoPredict.UseVisualStyleBackColor = True
        '
        'chkAutoRegression
        '
        Me.chkAutoRegression.AutoSize = True
        Me.chkAutoRegression.Location = New System.Drawing.Point(154, 16)
        Me.chkAutoRegression.Name = "chkAutoRegression"
        Me.chkAutoRegression.Size = New System.Drawing.Size(104, 17)
        Me.chkAutoRegression.TabIndex = 159
        Me.chkAutoRegression.Text = "Auto Regression"
        Me.chkAutoRegression.UseVisualStyleBackColor = True
        '
        'frmNonLinRegr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1447, 773)
        Me.Controls.Add(Me.chkAutoPredict)
        Me.Controls.Add(Me.chkAutoRegression)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.dgvSpecPredictions)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.txtMeanTransYY)
        Me.Controls.Add(Me.txtSumTransYY)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txtMeanSqTransError)
        Me.Controls.Add(Me.txtSumSqTransError)
        Me.Controls.Add(Me.txtSumTransError)
        Me.Controls.Add(Me.txtMeanTransError)
        Me.Controls.Add(Me.txtSumTransPred)
        Me.Controls.Add(Me.txtMeanTransPred)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.dgvPredictions)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.cmbRegrModel)
        Me.Controls.Add(Me.txtSumTransY)
        Me.Controls.Add(Me.txtMeanTransY)
        Me.Controls.Add(Me.txtSumTransX)
        Me.Controls.Add(Me.txtMeanTransX)
        Me.Controls.Add(Me.cmbYTrans)
        Me.Controls.Add(Me.cmbXTrans)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.dgvTransformedPoints)
        Me.Controls.Add(Me.btnChart)
        Me.Controls.Add(Me.txtMeanSqError)
        Me.Controls.Add(Me.txtMeanError)
        Me.Controls.Add(Me.txtMeanPred)
        Me.Controls.Add(Me.txtMeanTransXY)
        Me.Controls.Add(Me.txtMeanTransXX)
        Me.Controls.Add(Me.txtMeanY)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtMeanX)
        Me.Controls.Add(Me.txtSumSqError)
        Me.Controls.Add(Me.txtSumError)
        Me.Controls.Add(Me.txtSumPred)
        Me.Controls.Add(Me.btnPredict)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.dgvTransPredictions)
        Me.Controls.Add(Me.txtNPoints)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnRegression)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtSumY)
        Me.Controls.Add(Me.txtSumX)
        Me.Controls.Add(Me.txtSumTransXY)
        Me.Controls.Add(Me.txtSumTransXX)
        Me.Controls.Add(Me.dgvTransCalculations)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvInputPoints)
        Me.Name = "frmNonLinRegr"
        Me.Text = "Non-Linear Regression"
        CType(Me.dgvTransPredictions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTransCalculations, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvInputPoints, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTransformedPoints, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPredictions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
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
    Friend WithEvents txtMeanTransXY As TextBox
    Friend WithEvents txtMeanTransXX As TextBox
    Friend WithEvents txtMeanY As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtMeanX As TextBox
    Friend WithEvents txtSumSqError As TextBox
    Friend WithEvents txtSumError As TextBox
    Friend WithEvents txtSumPred As TextBox
    Friend WithEvents btnPredict As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents dgvTransPredictions As DataGridView
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
    Friend WithEvents txtSumTransXY As TextBox
    Friend WithEvents txtSumTransXX As TextBox
    Friend WithEvents dgvTransCalculations As DataGridView
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
    Friend WithEvents dgvTransformedPoints As DataGridView
    Friend WithEvents Label22 As Label
    Friend WithEvents cmbXTrans As ComboBox
    Friend WithEvents cmbYTrans As ComboBox
    Friend WithEvents txtMeanTransX As TextBox
    Friend WithEvents txtSumTransX As TextBox
    Friend WithEvents txtMeanTransY As TextBox
    Friend WithEvents txtSumTransY As TextBox
    Friend WithEvents cmbRegrModel As ComboBox
    Friend WithEvents Label23 As Label
    Friend WithEvents dgvPredictions As DataGridView
    Friend WithEvents Label24 As Label
    Friend WithEvents txtMeanTransPred As TextBox
    Friend WithEvents txtSumTransPred As TextBox
    Friend WithEvents txtMeanTransError As TextBox
    Friend WithEvents txtSumTransError As TextBox
    Friend WithEvents txtSumSqTransError As TextBox
    Friend WithEvents txtMeanSqTransError As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtRegressionModel As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents txtSumTransYY As TextBox
    Friend WithEvents txtMeanTransYY As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtUTErrorStdDev As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents dgvSpecPredictions As DataGridView
    Friend WithEvents chkAutoPredict As CheckBox
    Friend WithEvents chkAutoRegression As CheckBox
End Class
