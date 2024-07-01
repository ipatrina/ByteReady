Imports System.ComponentModel
Imports System.IO
Imports System.Media
Imports System.Runtime.InteropServices

Public Class ByteReady
    Dim autoExit As Boolean = False
    Dim btnStartText As String = "&Start"
    Dim btnStopText As String = "&Stop"
    Dim fnOpen As IO.FileStream = Nothing
    Dim frOpen As IO.BinaryReader = Nothing
    Dim fnWrite As IO.FileStream = Nothing
    Dim frWrite As IO.BinaryWriter = Nothing
    Dim KeepExpr As Boolean = False
    Dim returnOK As Boolean = True
    Dim timercount As Integer = 0
    Dim timerdisplay As Boolean = True
    Dim sourceFileSize As Long = 0
    Dim taskCancel As Boolean = False
    Dim taskProgress As Integer = -1
    ReadOnly taskStopwatch As New Stopwatch

    <DllImport("kernel32.dll")>
    Private Shared Function GetSystemDefaultLangID() As UInt16
    End Function
    Public Shared ReadOnly Property SystemDefaultLangID() As UInt16
        Get
            Return GetSystemDefaultLangID()
        End Get
    End Property

    Private Sub ByteReady_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            AllowDrop = True

            NumStartPoint.Maximum = Int64.MaxValue
            NumLength.Maximum = Int64.MaxValue
            NumEndPoint.Maximum = Int64.MaxValue
            NumBufferSize.Maximum = Int64.MaxValue

            Dim lng As String = SystemDefaultLangID()
            If lng = 2052 Or lng = 1028 Or lng = 3076 Then
                LblSourceFile.Text = "源文件："
                LblStartPoint.Text = "起始点："
                LblLength.Text = "长度："
                LblEndPoint.Text = "结束点："
                LblBufferSize.Text = "缓冲大小："
                LblOutputFile.Text = "输出文件："
                BtnAbout.Text = "关于 (&A)"
                BtnBrowseSource.Text = "浏览...(&R)"
                BtnBrowseOutput.Text = "浏览...(&O)"
                btnStartText = "开始 (&S)"
                BtnControl.Text = btnStartText
                btnStopText = "停止 (&S)"
                LblStartPointBytes.Text = "字节"
                LblLengthBytes.Text = LblStartPointBytes.Text
                LblEndPointBytes.Text = LblStartPointBytes.Text
                LblBufferSizeBytes.Text = LblStartPointBytes.Text
                LblRegExTitle.Text = "▲ 表达式 ▼"
            End If

            Dim cmd As String = Command()
            If Not cmd = "" And Not cmd = Nothing Then
                If cmd.StartsWith(Chr(34)) And cmd.EndsWith(Chr(34)) Then
                    cmd = cmd.Substring(1, cmd.Length - 2)
                End If
                TxtSourcePath.Text = cmd.Split(">")(0)
                ApplySourcePath()
                Dim Spl1 As String() = cmd.Split(">")(1).Split(" ")
                Dim Range As String = Spl1(Spl1.Count - 1)
                TxtOutputPath.Text = cmd.Split(">")(1).Substring(0, (cmd.Split(">")(1).Length - Range.Length - 1))
                NumStartPoint.Value = Long.Parse(Range.Split("-")(0))
                NumEndPoint.Value = Long.Parse(Range.Split("-")(1).Split("@")(0))
                autoExit = True
                If Range.Split("-")(1).Split("@").Count > 1 Then
                    NumBufferSize.Value = Long.Parse(Range.Split("-")(1).Split("@")(1))
                End If
                BtnControl_Click(sender, e)
            End If
        Catch ex As Exception

        End Try

        Try
            NumBufferSize.Value = Int64.Parse(CreateObject("WScript.Shell").RegRead("HKCU\Software\ByteReady\BufferSize"))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnControl_Click(sender As Object, e As EventArgs) Handles BtnControl.Click
        Try
            If BtnControl.Text = btnStartText Then
                Try
                    CreateObject("WScript.Shell").RegWrite("HKCU\Software\ByteReady\BufferSize", NumBufferSize.Value, "REG_SZ")
                Catch ex As Exception

                End Try

                TxtOutputPath.Text = TxtOutputPath.Text.Replace("/", "\")
                If TxtOutputPath.Text.EndsWith(":") Then
                    TxtOutputPath.Text += "\"
                End If
                If Not TxtOutputPath.Text.Contains("\") Then
                    TxtOutputPath.Text = My.Computer.FileSystem.GetParentPath(TxtSourcePath.Text) & "\" & TxtOutputPath.Text
                End If
                If Not TxtOutputPath.Text.StartsWith("\\") Then TxtOutputPath.Text = TxtOutputPath.Text.Replace("\\", "\")

                PgbProgress.Value = 0
                LblStatus.BackColor = Color.Blue
                LblStatus.Text = "STANDBY"
                taskCancel = False
                taskProgress = -1
                TmrStatus.Enabled = False
                timerdisplay = True
                TmrDisplay.Enabled = True
                returnOK = False
                CloseFileOp()
                CoreEngine.RunWorkerAsync()
                BtnControl.Text = btnStopText
            Else
                taskCancel = True
                autoExit = False
            End If
        Catch ex As Exception
            returnOK = False
            Complete()
        End Try
    End Sub

    Private Sub BtnBrowseSource_Click(sender As Object, e As EventArgs) Handles BtnBrowseSource.Click
        Try
            If SourcePathSelector.ShowDialog = DialogResult.OK Then
                TxtSourcePath.Text = SourcePathSelector.FileName
                ApplySourcePath()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ApplySourcePath()
        Try
            Dim _loc_1 As New IO.FileInfo(TxtSourcePath.Text)
            NumEndPoint.Value = _loc_1.Length - 1
            sourceFileSize = _loc_1.Length - 1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnBrowseOutput_Click(sender As Object, e As EventArgs) Handles BtnBrowseOutput.Click
        Try
            If OutputPathSelector.ShowDialog = DialogResult.OK Then
                TxtOutputPath.Text = OutputPathSelector.FileName
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnCtrlReset()
        Try
            BtnControl.Text = btnStartText
        Catch ex As Exception

        End Try
    End Sub

    Private Sub NumStartPoint_ValueChanged(sender As Object, e As EventArgs) Handles NumEndPoint.ValueChanged, NumStartPoint.ValueChanged
        Try
            NumLength.Value = NumEndPoint.Value - NumStartPoint.Value + 1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnAbout_Click(sender As Object, e As EventArgs) Handles BtnAbout.Click
        Try
            Dim VersionStrings As String() = Application.ProductVersion.ToString.Split(".")
            MsgBox("ByteReady" & vbCrLf & vbCrLf & "Version: " & VersionStrings(0) & "." & VersionStrings(1) & "." & VersionStrings(2) & vbCrLf & "Date: 20" & VersionStrings(3).Substring(0, 2) & "." & VersionStrings(3).Substring(2, 2) & vbCrLf & vbCrLf & "Copyright © 2016-2023." & vbCrLf & "All rights reserved.", vbInformation, "About")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CoreEngine_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles CoreEngine.DoWork
        Try
            Dim worker As BackgroundWorker = TryCast(sender, BackgroundWorker)
            fnOpen = New IO.FileStream(TxtSourcePath.Text, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.ReadWrite)
            frOpen = New IO.BinaryReader(fnOpen)
            Dim StartingPoint As Int64 = NumStartPoint.Value
            Dim EndPoint As Int64 = NumEndPoint.Value
            Dim BufferPoint As Int64 = 0
            BufferPoint = StartingPoint
            frOpen.BaseStream.Position = StartingPoint
            Dim BufferSize As Int64 = 1048576
            BufferSize = NumBufferSize.Value
            If EndPoint > sourceFileSize Then
                EndPoint = sourceFileSize
            End If
            fnWrite = New IO.FileStream(TxtOutputPath.Text, IO.FileMode.Create)
            frWrite = New IO.BinaryWriter(fnWrite)
            Do
                If taskCancel Then Exit Sub
                If BufferSize > EndPoint - BufferPoint + 1 Then BufferSize = EndPoint - BufferPoint + 1
                frWrite.Write(frOpen.ReadBytes(BufferSize))
                BufferPoint += BufferSize
                worker.ReportProgress(Int((BufferPoint - StartingPoint) / (EndPoint - StartingPoint + 1) * 100))
            Loop Until BufferPoint >= EndPoint
            returnOK = True
        Catch ex As Exception
            returnOK = False
        Finally
            CloseFileOp()
        End Try
    End Sub

    Private Sub CloseFileOp()
        Try
            frOpen.Close()
            fnOpen.Close()
            frWrite.Close()
            fnWrite.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CoreEngine_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles CoreEngine.RunWorkerCompleted
        Try
            taskStopwatch.Stop()
            taskStopwatch.Reset()
        Catch ex As Exception

        End Try

        Complete()
    End Sub

    Private Sub Complete()
        Try
            If returnOK Then
                PgbProgress.Value = PgbProgress.Maximum
            End If
            timercount = 0
            TmrDisplay.Enabled = False
            TmrStatus.Enabled = True
            BtnCtrlReset()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CoreEngine_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles CoreEngine.ProgressChanged
        Try
            If e.ProgressPercentage > taskProgress Then
                PgbProgress.Value = e.ProgressPercentage
                taskProgress = e.ProgressPercentage
                Text = e.ProgressPercentage & "% - " & System.IO.Path.GetFileName(TxtOutputPath.Text)

                If taskStopwatch.IsRunning Then
                    Dim _loc_1 As TimeSpan = TimeSpan.FromTicks(taskStopwatch.Elapsed.Ticks * (100 - e.ProgressPercentage))
                    If Not taskProgress >= 100 And _loc_1.Days < 1 Then Text += "  (" & String.Format("{0}h {1}m {2}s", _loc_1.Hours, _loc_1.Minutes, _loc_1.Seconds) & ")"
                End If
                taskStopwatch.Reset()
                taskStopwatch.Start()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TmrStatus_Tick(sender As Object, e As EventArgs) Handles TmrStatus.Tick
        Try
            If timercount = 0 Or timercount = 2 Or timercount = 4 Then
                If returnOK Then
                    LblStatus.Text = "OK"
                    LblStatus.BackColor = Color.YellowGreen
                Else
                    If taskCancel Then
                        LblStatus.Text = "ABORT"
                    Else
                        LblStatus.Text = "FAIL"
                    End If
                    LblStatus.BackColor = Color.Red
                End If
                PlayBeep()
                If timercount = 4 Then
                    If autoExit And returnOK Then
                        autoExit = False
                    Else
                        TmrStatus.Enabled = False
                    End If
                End If
            ElseIf timercount = 5 Then
                TmrStatus.Enabled = False
                Dispose()
                End
            Else
                LblStatus.BackColor = Color.White
            End If
            timercount += 1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PlayBeep()
        Try
            Dim _loc_1 As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
            Dim _loc_2 As System.IO.Stream = _loc_1.GetManifestResourceStream("ByteReady.Beep.wav")
            Dim _loc_3 As New SoundPlayer(_loc_2)
            _loc_3.Play()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LblStatus_Click(sender As Object, e As EventArgs) Handles LblStatus.Click
        Try
            If Not LblStatus.Text = "STANDBY" Then
                LblStatus.Text = "READY"
                LblStatus.BackColor = Color.DarkOrange
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TmrDisplay_Tick(sender As Object, e As EventArgs) Handles TmrDisplay.Tick
        Try
            If timerdisplay Then
                LblStatus.BackColor = Color.White
                timerdisplay = False
                TmrDisplay.Interval = 300
            Else
                LblStatus.BackColor = Color.Blue
                timerdisplay = True
                TmrDisplay.Interval = 3000
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PicBadge_Click(sender As Object, e As EventArgs) Handles PicBadge.Click
        Try
            Process.Start(Application.ExecutablePath)
            If LblStatus.Text = "FAIL" Then
                End
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function Expr(Input As String, From As Integer) As Long
        Try
            KeepExpr = False
            Dim CustomKeepStr As String = ""
            Input = Input.ToLower.Replace("：", ":").Replace("k", "000").Replace("m", "000000").Replace("g", "000000000")
            If Input.ToLower().StartsWith("0x") Then
                Return Convert.ToInt64(Input, 16)
            ElseIf Input.Contains("@") Then
                Dim _loc_1 As String = ""
                Dim _loc_2 As String() = Input.Split("@")
                If _loc_2.Count > 1 Then
                    For _loc_3 = 0 To 1
                        For _loc_4 = 0 To _loc_2(_loc_3).Length - 2 Step 2
                            _loc_1 += _loc_2(_loc_3).Substring(_loc_4, 2) & ":"
                        Next
                        _loc_1 = _loc_1.Substring(0, _loc_1.Length - 1)
                        If _loc_3 = 0 Then _loc_1 += "/"
                    Next
                    Input = _loc_1
                    CustomKeepStr = "@" & _loc_2(1)
                End If
            End If
            If Input.Contains("%") Then
                Return sourceFileSize * ((Input.Split("%")(0)) / 100)
            ElseIf Input.Contains("/") Then
                If Input.Contains(":") Then
                    Dim _loc_5() As Long = {0, 0}
                    For _loc_6 = 0 To 1
                        If Input.Split("/")(_loc_6).Contains(":") Then
                            Dim _loc_7 As String() = Input.Split("/")(_loc_6).Split(":")
                            Dim _loc_8 As Integer = 0
                            For _loc_9 = 0 To _loc_7.Count - 1
                                _loc_8 += _loc_7(_loc_9) * (60 ^ (_loc_7.Count - _loc_9 - 1))
                            Next
                            _loc_5(_loc_6) = _loc_8
                        Else
                            _loc_5(_loc_6) = Input.Split("/")(_loc_6)
                        End If
                    Next
                    Input = _loc_5(0) & "/" & _loc_5(1)
                End If
                KeepExpr = True
                If CustomKeepStr.Length = 0 Then
                    TxtExpr1.Text = "/" & Input.Split("/")(1)
                    TxtExpr2.Text = "/" & Input.Split("/")(1)
                Else
                    TxtExpr1.Text = CustomKeepStr
                    TxtExpr2.Text = CustomKeepStr
                End If
                Return sourceFileSize * (((Input.Split("/")(0)) / (Input.Split("/")(1))))
            ElseIf Input.StartsWith("+") Then
                Return NumStartPoint.Value + (Input.Split("+")(1))
            ElseIf Input.StartsWith("-") Then
                Return NumEndPoint.Value - (Input.Split("-")(1))
            ElseIf Input.EndsWith("+") Then
                If From = 1 Then
                    Return NumStartPoint.Value + (Input.Split("+")(0))
                Else
                    Return NumEndPoint.Value + (Input.Split("+")(0))
                End If
            ElseIf Input.EndsWith("-") Then
                If From = 1 Then
                    Return NumStartPoint.Value - (Input.Split("-")(0))
                Else
                    Return NumEndPoint.Value - (Input.Split("-")(0))
                End If
            ElseIf Input.Contains("=") Then
                Return (Input.Split("=")(1))
            ElseIf Input.EndsWith("x") Then
                If From = 1 Then
                    Return Long.Parse(NumStartPoint.Value - (NumStartPoint.Value Mod Int(Input.Split("x")(0))))
                Else
                    Return Long.Parse(NumEndPoint.Value - ((NumEndPoint.Value + 1) Mod Int(Input.Split("x")(0))) + Int(Input.Split("x")(0)))
                End If
            Else
                Return -1
            End If
        Catch ex As Exception
            Return -1
        End Try
    End Function

    Private Sub TxtExpr1_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtExpr1.KeyDown
        Try
            If (e.KeyCode = Keys.Return) Then
                Dim _loc_1 As Long = Expr(TxtExpr1.Text, 1)
                If Not _loc_1 = -1 Then
                    NumStartPoint.Value = _loc_1
                    If KeepExpr And Path.GetExtension(TxtSourcePath.Text).ToLower = ".ts" Then NumStartPoint.Value = Expr("188x", 1)
                    If Not KeepExpr Then TxtExpr1.Text = ""
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtExpr2_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtExpr2.KeyDown
        Try
            If (e.KeyCode = Keys.Return) Then
                Dim _loc_1 As Long = Expr(TxtExpr2.Text, 2)
                If Not _loc_1 = -1 Then
                    NumEndPoint.Value = _loc_1
                    If KeepExpr And Path.GetExtension(TxtSourcePath.Text).ToLower = ".ts" Then NumEndPoint.Value = Expr("188x", 2)
                    If Not KeepExpr Then TxtExpr2.Text = ""
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LblSourceFile_Click(sender As Object, e As EventArgs) Handles LblSourceFile.Click
        Try
            Dim fi As New IO.FileInfo(TxtSourcePath.Text)
            Process.Start("explorer.exe", fi.DirectoryName)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LblOutputFile_Click(sender As Object, e As EventArgs) Handles LblOutputFile.Click
        Try
            Dim fi As New IO.FileInfo(TxtOutputPath.Text)
            Process.Start("explorer.exe", fi.DirectoryName)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ByteReady_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter
        Try
            If e.Data.GetDataPresent(DataFormats.FileDrop) = True Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.None
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ByteReady_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
        Try
            Dim DragFilePath As String() = e.Data.GetData(DataFormats.FileDrop)
            If My.Computer.FileSystem.FileExists(DragFilePath(0)) Then
                TxtSourcePath.Text = DragFilePath(0)
                ApplySourcePath()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
