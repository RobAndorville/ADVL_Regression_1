<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNonLinRegrChart
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea4 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend4 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.chtTransRegression = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.chtTransResiduals = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.chtRegression = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.chtResiduals = New System.Windows.Forms.DataVisualization.Charting.Chart()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.chtTransRegression, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chtTransResiduals, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chtRegression, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chtResiduals, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(12, 40)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer1.Size = New System.Drawing.Size(1100, 693)
        Me.SplitContainer1.SplitterDistance = 529
        Me.SplitContainer1.TabIndex = 0
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(1064, 12)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(48, 22)
        Me.btnExit.TabIndex = 9
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.chtTransRegression)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.chtTransResiduals)
        Me.SplitContainer2.Size = New System.Drawing.Size(523, 687)
        Me.SplitContainer2.SplitterDistance = 174
        Me.SplitContainer2.TabIndex = 0
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer3.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.chtRegression)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.chtResiduals)
        Me.SplitContainer3.Size = New System.Drawing.Size(561, 687)
        Me.SplitContainer3.SplitterDistance = 187
        Me.SplitContainer3.TabIndex = 0
        '
        'chtTransRegression
        '
        Me.chtTransRegression.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea1.Name = "ChartArea1"
        Me.chtTransRegression.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.chtTransRegression.Legends.Add(Legend1)
        Me.chtTransRegression.Location = New System.Drawing.Point(3, 3)
        Me.chtTransRegression.Name = "chtTransRegression"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.chtTransRegression.Series.Add(Series1)
        Me.chtTransRegression.Size = New System.Drawing.Size(517, 168)
        Me.chtTransRegression.TabIndex = 0
        Me.chtTransRegression.Text = "Chart1"
        '
        'chtTransResiduals
        '
        Me.chtTransResiduals.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea2.Name = "ChartArea1"
        Me.chtTransResiduals.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.chtTransResiduals.Legends.Add(Legend2)
        Me.chtTransResiduals.Location = New System.Drawing.Point(3, 3)
        Me.chtTransResiduals.Name = "chtTransResiduals"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.chtTransResiduals.Series.Add(Series2)
        Me.chtTransResiduals.Size = New System.Drawing.Size(517, 503)
        Me.chtTransResiduals.TabIndex = 0
        Me.chtTransResiduals.Text = "Chart2"
        '
        'chtRegression
        '
        Me.chtRegression.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea3.Name = "ChartArea1"
        Me.chtRegression.ChartAreas.Add(ChartArea3)
        Legend3.Name = "Legend1"
        Me.chtRegression.Legends.Add(Legend3)
        Me.chtRegression.Location = New System.Drawing.Point(3, 3)
        Me.chtRegression.Name = "chtRegression"
        Series3.ChartArea = "ChartArea1"
        Series3.Legend = "Legend1"
        Series3.Name = "Series1"
        Me.chtRegression.Series.Add(Series3)
        Me.chtRegression.Size = New System.Drawing.Size(555, 181)
        Me.chtRegression.TabIndex = 0
        Me.chtRegression.Text = "Chart3"
        '
        'chtResiduals
        '
        Me.chtResiduals.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea4.Name = "ChartArea1"
        Me.chtResiduals.ChartAreas.Add(ChartArea4)
        Legend4.Name = "Legend1"
        Me.chtResiduals.Legends.Add(Legend4)
        Me.chtResiduals.Location = New System.Drawing.Point(3, 3)
        Me.chtResiduals.Name = "chtResiduals"
        Series4.ChartArea = "ChartArea1"
        Series4.Legend = "Legend1"
        Series4.Name = "Series1"
        Me.chtResiduals.Series.Add(Series4)
        Me.chtResiduals.Size = New System.Drawing.Size(555, 490)
        Me.chtResiduals.TabIndex = 0
        Me.chtResiduals.Text = "Chart4"
        '
        'frmNonLinRegrChart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1124, 745)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmNonLinRegrChart"
        Me.Text = "Non-Linear Regression Charts"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.chtTransRegression, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chtTransResiduals, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chtRegression, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chtResiduals, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents btnExit As Button
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents chtTransRegression As DataVisualization.Charting.Chart
    Friend WithEvents chtTransResiduals As DataVisualization.Charting.Chart
    Friend WithEvents SplitContainer3 As SplitContainer
    Friend WithEvents chtRegression As DataVisualization.Charting.Chart
    Friend WithEvents chtResiduals As DataVisualization.Charting.Chart
End Class
