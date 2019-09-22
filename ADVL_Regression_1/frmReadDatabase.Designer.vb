<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReadDatabase
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnDatabase = New System.Windows.Forms.Button()
        Me.txtDatabase = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnOpenLinRegrForm = New System.Windows.Forms.Button()
        Me.btnOpenNonLinRegrForm = New System.Windows.Forms.Button()
        Me.btnForecast = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtQuery = New System.Windows.Forms.TextBox()
        Me.cmbSelectTable = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnApplyQuery = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.cmbXValueColumnName = New System.Windows.Forms.ComboBox()
        Me.cmbYValueColumnName = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(610, 12)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(48, 22)
        Me.btnExit.TabIndex = 64
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnDatabase
        '
        Me.btnDatabase.Location = New System.Drawing.Point(12, 63)
        Me.btnDatabase.Name = "btnDatabase"
        Me.btnDatabase.Size = New System.Drawing.Size(64, 22)
        Me.btnDatabase.TabIndex = 67
        Me.btnDatabase.Text = "Find"
        Me.btnDatabase.UseVisualStyleBackColor = True
        '
        'txtDatabase
        '
        Me.txtDatabase.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDatabase.Location = New System.Drawing.Point(84, 40)
        Me.txtDatabase.Multiline = True
        Me.txtDatabase.Name = "txtDatabase"
        Me.txtDatabase.Size = New System.Drawing.Size(574, 45)
        Me.txtDatabase.TabIndex = 66
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 65
        Me.Label1.Text = "Database:"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnOpenLinRegrForm
        '
        Me.btnOpenLinRegrForm.Location = New System.Drawing.Point(12, 12)
        Me.btnOpenLinRegrForm.Name = "btnOpenLinRegrForm"
        Me.btnOpenLinRegrForm.Size = New System.Drawing.Size(133, 22)
        Me.btnOpenLinRegrForm.TabIndex = 68
        Me.btnOpenLinRegrForm.Text = "Linear Regression Form"
        Me.btnOpenLinRegrForm.UseVisualStyleBackColor = True
        '
        'btnOpenNonLinRegrForm
        '
        Me.btnOpenNonLinRegrForm.Location = New System.Drawing.Point(151, 12)
        Me.btnOpenNonLinRegrForm.Name = "btnOpenNonLinRegrForm"
        Me.btnOpenNonLinRegrForm.Size = New System.Drawing.Size(156, 22)
        Me.btnOpenNonLinRegrForm.TabIndex = 69
        Me.btnOpenNonLinRegrForm.Text = "Non-Linear Regression Form"
        Me.btnOpenNonLinRegrForm.UseVisualStyleBackColor = True
        '
        'btnForecast
        '
        Me.btnForecast.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnForecast.Location = New System.Drawing.Point(326, 169)
        Me.btnForecast.Name = "btnForecast"
        Me.btnForecast.Size = New System.Drawing.Size(68, 22)
        Me.btnForecast.TabIndex = 70
        Me.btnForecast.Text = "Forecast"
        Me.btnForecast.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 121)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 71
        Me.Label2.Text = "Query:"
        '
        'txtQuery
        '
        Me.txtQuery.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQuery.Location = New System.Drawing.Point(84, 118)
        Me.txtQuery.Multiline = True
        Me.txtQuery.Name = "txtQuery"
        Me.txtQuery.Size = New System.Drawing.Size(574, 45)
        Me.txtQuery.TabIndex = 72
        '
        'cmbSelectTable
        '
        Me.cmbSelectTable.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbSelectTable.FormattingEnabled = True
        Me.cmbSelectTable.Location = New System.Drawing.Point(84, 91)
        Me.cmbSelectTable.Name = "cmbSelectTable"
        Me.cmbSelectTable.Size = New System.Drawing.Size(574, 21)
        Me.cmbSelectTable.TabIndex = 73
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 94)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(66, 13)
        Me.Label14.TabIndex = 74
        Me.Label14.Text = "Select table:"
        '
        'btnApplyQuery
        '
        Me.btnApplyQuery.Location = New System.Drawing.Point(12, 141)
        Me.btnApplyQuery.Name = "btnApplyQuery"
        Me.btnApplyQuery.Size = New System.Drawing.Size(64, 22)
        Me.btnApplyQuery.TabIndex = 75
        Me.btnApplyQuery.Text = "Apply"
        Me.btnApplyQuery.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 169)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(308, 308)
        Me.DataGridView1.TabIndex = 76
        '
        'cmbXValueColumnName
        '
        Me.cmbXValueColumnName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbXValueColumnName.FormattingEnabled = True
        Me.cmbXValueColumnName.Location = New System.Drawing.Point(69, 483)
        Me.cmbXValueColumnName.Name = "cmbXValueColumnName"
        Me.cmbXValueColumnName.Size = New System.Drawing.Size(251, 21)
        Me.cmbXValueColumnName.TabIndex = 77
        '
        'cmbYValueColumnName
        '
        Me.cmbYValueColumnName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbYValueColumnName.FormattingEnabled = True
        Me.cmbYValueColumnName.Location = New System.Drawing.Point(69, 510)
        Me.cmbYValueColumnName.Name = "cmbYValueColumnName"
        Me.cmbYValueColumnName.Size = New System.Drawing.Size(251, 21)
        Me.cmbYValueColumnName.TabIndex = 78
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 486)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 79
        Me.Label3.Text = "X values:"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 513)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 80
        Me.Label4.Text = "Y values:"
        '
        'frmReadDatabase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(670, 543)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbYValueColumnName)
        Me.Controls.Add(Me.cmbXValueColumnName)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnApplyQuery)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.cmbSelectTable)
        Me.Controls.Add(Me.txtQuery)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnForecast)
        Me.Controls.Add(Me.btnOpenNonLinRegrForm)
        Me.Controls.Add(Me.btnOpenLinRegrForm)
        Me.Controls.Add(Me.btnDatabase)
        Me.Controls.Add(Me.txtDatabase)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnExit)
        Me.Name = "frmReadDatabase"
        Me.Text = "Read Database"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents btnDatabase As Button
    Friend WithEvents txtDatabase As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents btnOpenLinRegrForm As Button
    Friend WithEvents btnOpenNonLinRegrForm As Button
    Friend WithEvents btnForecast As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtQuery As TextBox
    Friend WithEvents cmbSelectTable As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents btnApplyQuery As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents cmbXValueColumnName As ComboBox
    Friend WithEvents cmbYValueColumnName As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
End Class
