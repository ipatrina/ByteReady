<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ByteReady
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ByteReady))
        Me.PgbProgress = New System.Windows.Forms.ProgressBar()
        Me.PicBadge = New System.Windows.Forms.PictureBox()
        Me.LblBufferSizeBytes = New System.Windows.Forms.Label()
        Me.NumBufferSize = New System.Windows.Forms.NumericUpDown()
        Me.LblBufferSize = New System.Windows.Forms.Label()
        Me.BtnAbout = New System.Windows.Forms.Button()
        Me.BtnControl = New System.Windows.Forms.Button()
        Me.TxtOutputPath = New System.Windows.Forms.TextBox()
        Me.BtnBrowseOutput = New System.Windows.Forms.Button()
        Me.LblOutputFile = New System.Windows.Forms.Label()
        Me.LblEndPointBytes = New System.Windows.Forms.Label()
        Me.NumEndPoint = New System.Windows.Forms.NumericUpDown()
        Me.LblEndPoint = New System.Windows.Forms.Label()
        Me.LblLengthBytes = New System.Windows.Forms.Label()
        Me.NumLength = New System.Windows.Forms.NumericUpDown()
        Me.LblLength = New System.Windows.Forms.Label()
        Me.LblStartPointBytes = New System.Windows.Forms.Label()
        Me.NumStartPoint = New System.Windows.Forms.NumericUpDown()
        Me.LblStartPoint = New System.Windows.Forms.Label()
        Me.TxtSourcePath = New System.Windows.Forms.TextBox()
        Me.BtnBrowseSource = New System.Windows.Forms.Button()
        Me.LblSourceFile = New System.Windows.Forms.Label()
        Me.SourcePathSelector = New System.Windows.Forms.OpenFileDialog()
        Me.OutputPathSelector = New System.Windows.Forms.SaveFileDialog()
        Me.CoreEngine = New System.ComponentModel.BackgroundWorker()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.TmrStatus = New System.Windows.Forms.Timer(Me.components)
        Me.TmrDisplay = New System.Windows.Forms.Timer(Me.components)
        Me.TxtExpr1 = New System.Windows.Forms.TextBox()
        Me.TxtExpr2 = New System.Windows.Forms.TextBox()
        Me.LblRegExTitle = New System.Windows.Forms.Label()
        CType(Me.PicBadge, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumBufferSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumEndPoint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumLength, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumStartPoint, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PgbProgress
        '
        Me.PgbProgress.Location = New System.Drawing.Point(16, 513)
        Me.PgbProgress.MarqueeAnimationSpeed = 10
        Me.PgbProgress.Name = "PgbProgress"
        Me.PgbProgress.Size = New System.Drawing.Size(316, 32)
        Me.PgbProgress.TabIndex = 124
        '
        'PicBadge
        '
        Me.PicBadge.Image = CType(resources.GetObject("PicBadge.Image"), System.Drawing.Image)
        Me.PicBadge.Location = New System.Drawing.Point(182, 17)
        Me.PicBadge.Name = "PicBadge"
        Me.PicBadge.Size = New System.Drawing.Size(100, 100)
        Me.PicBadge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicBadge.TabIndex = 123
        Me.PicBadge.TabStop = False
        '
        'LblBufferSizeBytes
        '
        Me.LblBufferSizeBytes.AutoSize = True
        Me.LblBufferSizeBytes.Location = New System.Drawing.Point(288, 333)
        Me.LblBufferSizeBytes.Name = "LblBufferSizeBytes"
        Me.LblBufferSizeBytes.Size = New System.Drawing.Size(50, 21)
        Me.LblBufferSizeBytes.TabIndex = 116
        Me.LblBufferSizeBytes.Text = "bytes"
        '
        'NumBufferSize
        '
        Me.NumBufferSize.Location = New System.Drawing.Point(131, 329)
        Me.NumBufferSize.Maximum = New Decimal(New Integer() {16777216, 0, 0, 0})
        Me.NumBufferSize.Minimum = New Decimal(New Integer() {1024, 0, 0, 0})
        Me.NumBufferSize.Name = "NumBufferSize"
        Me.NumBufferSize.Size = New System.Drawing.Size(151, 29)
        Me.NumBufferSize.TabIndex = 120
        Me.NumBufferSize.Value = New Decimal(New Integer() {10485760, 0, 0, 0})
        '
        'LblBufferSize
        '
        Me.LblBufferSize.AutoSize = True
        Me.LblBufferSize.Location = New System.Drawing.Point(12, 333)
        Me.LblBufferSize.Name = "LblBufferSize"
        Me.LblBufferSize.Size = New System.Drawing.Size(94, 21)
        Me.LblBufferSize.TabIndex = 115
        Me.LblBufferSize.Text = "Buffer size:"
        '
        'BtnAbout
        '
        Me.BtnAbout.Location = New System.Drawing.Point(344, 459)
        Me.BtnAbout.Name = "BtnAbout"
        Me.BtnAbout.Size = New System.Drawing.Size(108, 32)
        Me.BtnAbout.TabIndex = 161
        Me.BtnAbout.Text = "&About"
        Me.BtnAbout.UseVisualStyleBackColor = True
        '
        'BtnControl
        '
        Me.BtnControl.Font = New System.Drawing.Font("微软雅黑", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.BtnControl.Location = New System.Drawing.Point(137, 428)
        Me.BtnControl.Name = "BtnControl"
        Me.BtnControl.Size = New System.Drawing.Size(190, 63)
        Me.BtnControl.TabIndex = 151
        Me.BtnControl.Text = "&Start"
        Me.BtnControl.UseVisualStyleBackColor = True
        '
        'TxtOutputPath
        '
        Me.TxtOutputPath.Location = New System.Drawing.Point(131, 376)
        Me.TxtOutputPath.Name = "TxtOutputPath"
        Me.TxtOutputPath.Size = New System.Drawing.Size(201, 29)
        Me.TxtOutputPath.TabIndex = 131
        '
        'BtnBrowseOutput
        '
        Me.BtnBrowseOutput.Location = New System.Drawing.Point(344, 376)
        Me.BtnBrowseOutput.Name = "BtnBrowseOutput"
        Me.BtnBrowseOutput.Size = New System.Drawing.Size(108, 30)
        Me.BtnBrowseOutput.TabIndex = 133
        Me.BtnBrowseOutput.Text = "Br&owse..."
        Me.BtnBrowseOutput.UseVisualStyleBackColor = True
        '
        'LblOutputFile
        '
        Me.LblOutputFile.AutoSize = True
        Me.LblOutputFile.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblOutputFile.Location = New System.Drawing.Point(12, 380)
        Me.LblOutputFile.Name = "LblOutputFile"
        Me.LblOutputFile.Size = New System.Drawing.Size(100, 21)
        Me.LblOutputFile.TabIndex = 113
        Me.LblOutputFile.Text = "Output File:"
        '
        'LblEndPointBytes
        '
        Me.LblEndPointBytes.AutoSize = True
        Me.LblEndPointBytes.Location = New System.Drawing.Point(288, 287)
        Me.LblEndPointBytes.Name = "LblEndPointBytes"
        Me.LblEndPointBytes.Size = New System.Drawing.Size(50, 21)
        Me.LblEndPointBytes.TabIndex = 112
        Me.LblEndPointBytes.Text = "bytes"
        '
        'NumEndPoint
        '
        Me.NumEndPoint.Location = New System.Drawing.Point(131, 283)
        Me.NumEndPoint.Maximum = New Decimal(New Integer() {1024, 0, 0, 0})
        Me.NumEndPoint.Name = "NumEndPoint"
        Me.NumEndPoint.Size = New System.Drawing.Size(151, 29)
        Me.NumEndPoint.TabIndex = 117
        '
        'LblEndPoint
        '
        Me.LblEndPoint.AutoSize = True
        Me.LblEndPoint.Location = New System.Drawing.Point(12, 287)
        Me.LblEndPoint.Name = "LblEndPoint"
        Me.LblEndPoint.Size = New System.Drawing.Size(88, 21)
        Me.LblEndPoint.TabIndex = 110
        Me.LblEndPoint.Text = "End point:"
        '
        'LblLengthBytes
        '
        Me.LblLengthBytes.AutoSize = True
        Me.LblLengthBytes.Location = New System.Drawing.Point(288, 242)
        Me.LblLengthBytes.Name = "LblLengthBytes"
        Me.LblLengthBytes.Size = New System.Drawing.Size(50, 21)
        Me.LblLengthBytes.TabIndex = 109
        Me.LblLengthBytes.Text = "bytes"
        '
        'NumLength
        '
        Me.NumLength.Enabled = False
        Me.NumLength.Location = New System.Drawing.Point(131, 238)
        Me.NumLength.Maximum = New Decimal(New Integer() {1024, 0, 0, 0})
        Me.NumLength.Name = "NumLength"
        Me.NumLength.Size = New System.Drawing.Size(151, 29)
        Me.NumLength.TabIndex = 114
        '
        'LblLength
        '
        Me.LblLength.AutoSize = True
        Me.LblLength.Location = New System.Drawing.Point(12, 242)
        Me.LblLength.Name = "LblLength"
        Me.LblLength.Size = New System.Drawing.Size(67, 21)
        Me.LblLength.TabIndex = 107
        Me.LblLength.Text = "Length:"
        '
        'LblStartPointBytes
        '
        Me.LblStartPointBytes.AutoSize = True
        Me.LblStartPointBytes.Location = New System.Drawing.Point(288, 197)
        Me.LblStartPointBytes.Name = "LblStartPointBytes"
        Me.LblStartPointBytes.Size = New System.Drawing.Size(50, 21)
        Me.LblStartPointBytes.TabIndex = 106
        Me.LblStartPointBytes.Text = "bytes"
        '
        'NumStartPoint
        '
        Me.NumStartPoint.Location = New System.Drawing.Point(131, 194)
        Me.NumStartPoint.Maximum = New Decimal(New Integer() {1024, 0, 0, 0})
        Me.NumStartPoint.Name = "NumStartPoint"
        Me.NumStartPoint.Size = New System.Drawing.Size(151, 29)
        Me.NumStartPoint.TabIndex = 111
        '
        'LblStartPoint
        '
        Me.LblStartPoint.AutoSize = True
        Me.LblStartPoint.Location = New System.Drawing.Point(12, 197)
        Me.LblStartPoint.Name = "LblStartPoint"
        Me.LblStartPoint.Size = New System.Drawing.Size(95, 21)
        Me.LblStartPoint.TabIndex = 105
        Me.LblStartPoint.Text = "Start point:"
        '
        'TxtSourcePath
        '
        Me.TxtSourcePath.Location = New System.Drawing.Point(131, 149)
        Me.TxtSourcePath.Name = "TxtSourcePath"
        Me.TxtSourcePath.ReadOnly = True
        Me.TxtSourcePath.Size = New System.Drawing.Size(201, 29)
        Me.TxtSourcePath.TabIndex = 104
        '
        'BtnBrowseSource
        '
        Me.BtnBrowseSource.Location = New System.Drawing.Point(344, 149)
        Me.BtnBrowseSource.Name = "BtnBrowseSource"
        Me.BtnBrowseSource.Size = New System.Drawing.Size(108, 30)
        Me.BtnBrowseSource.TabIndex = 108
        Me.BtnBrowseSource.Text = "B&rowse..."
        Me.BtnBrowseSource.UseVisualStyleBackColor = True
        '
        'LblSourceFile
        '
        Me.LblSourceFile.AutoSize = True
        Me.LblSourceFile.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblSourceFile.Location = New System.Drawing.Point(12, 153)
        Me.LblSourceFile.Name = "LblSourceFile"
        Me.LblSourceFile.Size = New System.Drawing.Size(97, 21)
        Me.LblSourceFile.TabIndex = 103
        Me.LblSourceFile.Text = "Source File:"
        '
        'SourcePathSelector
        '
        Me.SourcePathSelector.Filter = "All Files|*.*"
        '
        'OutputPathSelector
        '
        Me.OutputPathSelector.Filter = "All Files|*.*"
        '
        'CoreEngine
        '
        Me.CoreEngine.WorkerReportsProgress = True
        '
        'LblStatus
        '
        Me.LblStatus.BackColor = System.Drawing.Color.DarkOrange
        Me.LblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblStatus.ForeColor = System.Drawing.Color.White
        Me.LblStatus.Location = New System.Drawing.Point(344, 513)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(108, 32)
        Me.LblStatus.TabIndex = 125
        Me.LblStatus.Text = "READY"
        Me.LblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TmrStatus
        '
        Me.TmrStatus.Interval = 300
        '
        'TmrDisplay
        '
        Me.TmrDisplay.Interval = 3000
        '
        'TxtExpr1
        '
        Me.TxtExpr1.Location = New System.Drawing.Point(344, 194)
        Me.TxtExpr1.Name = "TxtExpr1"
        Me.TxtExpr1.Size = New System.Drawing.Size(108, 29)
        Me.TxtExpr1.TabIndex = 112
        '
        'TxtExpr2
        '
        Me.TxtExpr2.Location = New System.Drawing.Point(344, 283)
        Me.TxtExpr2.Name = "TxtExpr2"
        Me.TxtExpr2.Size = New System.Drawing.Size(108, 29)
        Me.TxtExpr2.TabIndex = 118
        '
        'LblRegExTitle
        '
        Me.LblRegExTitle.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblRegExTitle.Location = New System.Drawing.Point(337, 242)
        Me.LblRegExTitle.Name = "LblRegExTitle"
        Me.LblRegExTitle.Size = New System.Drawing.Size(122, 21)
        Me.LblRegExTitle.TabIndex = 128
        Me.LblRegExTitle.Text = "▲ Expression ▼"
        Me.LblRegExTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ByteReady
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(464, 561)
        Me.Controls.Add(Me.LblRegExTitle)
        Me.Controls.Add(Me.TxtExpr2)
        Me.Controls.Add(Me.TxtExpr1)
        Me.Controls.Add(Me.LblStatus)
        Me.Controls.Add(Me.PgbProgress)
        Me.Controls.Add(Me.PicBadge)
        Me.Controls.Add(Me.LblBufferSizeBytes)
        Me.Controls.Add(Me.NumBufferSize)
        Me.Controls.Add(Me.LblBufferSize)
        Me.Controls.Add(Me.BtnAbout)
        Me.Controls.Add(Me.BtnControl)
        Me.Controls.Add(Me.TxtOutputPath)
        Me.Controls.Add(Me.BtnBrowseOutput)
        Me.Controls.Add(Me.LblOutputFile)
        Me.Controls.Add(Me.LblEndPointBytes)
        Me.Controls.Add(Me.NumEndPoint)
        Me.Controls.Add(Me.LblEndPoint)
        Me.Controls.Add(Me.LblLengthBytes)
        Me.Controls.Add(Me.NumLength)
        Me.Controls.Add(Me.LblLength)
        Me.Controls.Add(Me.LblStartPointBytes)
        Me.Controls.Add(Me.NumStartPoint)
        Me.Controls.Add(Me.LblStartPoint)
        Me.Controls.Add(Me.TxtSourcePath)
        Me.Controls.Add(Me.BtnBrowseSource)
        Me.Controls.Add(Me.LblSourceFile)
        Me.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.MaximizeBox = False
        Me.Name = "ByteReady"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ByteReady"
        CType(Me.PicBadge, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumBufferSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumEndPoint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumLength, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumStartPoint, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PgbProgress As ProgressBar
    Friend WithEvents PicBadge As PictureBox
    Friend WithEvents LblBufferSizeBytes As Label
    Friend WithEvents NumBufferSize As NumericUpDown
    Friend WithEvents LblBufferSize As Label
    Friend WithEvents BtnAbout As Button
    Friend WithEvents BtnControl As Button
    Friend WithEvents TxtOutputPath As TextBox
    Friend WithEvents BtnBrowseOutput As Button
    Friend WithEvents LblOutputFile As Label
    Friend WithEvents LblEndPointBytes As Label
    Friend WithEvents NumEndPoint As NumericUpDown
    Friend WithEvents LblEndPoint As Label
    Friend WithEvents LblLengthBytes As Label
    Friend WithEvents NumLength As NumericUpDown
    Friend WithEvents LblLength As Label
    Friend WithEvents LblStartPointBytes As Label
    Friend WithEvents NumStartPoint As NumericUpDown
    Friend WithEvents LblStartPoint As Label
    Friend WithEvents TxtSourcePath As TextBox
    Friend WithEvents BtnBrowseSource As Button
    Friend WithEvents LblSourceFile As Label
    Friend WithEvents SourcePathSelector As OpenFileDialog
    Friend WithEvents OutputPathSelector As SaveFileDialog
    Friend WithEvents CoreEngine As System.ComponentModel.BackgroundWorker
    Friend WithEvents LblStatus As Label
    Friend WithEvents TmrStatus As Timer
    Friend WithEvents TmrDisplay As Timer
    Friend WithEvents TxtExpr1 As TextBox
    Friend WithEvents TxtExpr2 As TextBox
    Friend WithEvents LblRegExTitle As Label
End Class
