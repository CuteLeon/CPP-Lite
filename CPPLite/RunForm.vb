Imports System.ComponentModel
Imports System.IO
Imports System.Text.RegularExpressions

Public Class RunForm
    Dim CodeChanged As Boolean

    Private Sub RunForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        CodeTextBox.SetBounds(0, 0, Me.ClientRectangle.Width \ 2, Me.ClientRectangle.Height - ButtonsPanel.Height)

        PrintTextBox.SetBounds(CodeTextBox.Right, 0, Me.ClientRectangle.Width - CodeTextBox.Right, CodeTextBox.Height)

        ErrorListBox.SetBounds(PrintTextBox.Left, PrintTextBox.Top, PrintTextBox.Width, PrintTextBox.Height)
    End Sub

    Private Sub RunButton_Click(sender As Object, e As EventArgs) Handles RunButton.Click
        If CodeChanged Then
            ShellExecuter.FreeDLL()

            Me.Text = "CPP-Lite     正在生成代码..."
            If Not CPPSaver.SaveCPPToFile(CodeTextBox.Text) Then
                Me.Text = "CPP-Lite ==> 生成代码失败！"
                Exit Sub
            End If
            Me.Text = "CPP-Lite     生成代码成功，开始编译程序..."
            ErrorListBox.Items.Clear()
            If OBJCompiler.ComplierOBJ() Then
                If ErrorListBox.Visible Then
                    ErrorListBox.Hide()
                    PrintTextBox.Show()
                    PrintTextBox.Focus()
                End If
            Else
                Me.Text = "CPP-Lite ==> 编译程序失败，开始查找错误信息..."
                PrintTextBox.Hide()
                ErrorListBox.Show()
                ErrorListBox.Focus()
                SearchError()
                Exit Sub
            End If
            Me.Text = "CPP-Lite     编译成功，开始加载动态链接库..."
            If Not ShellExecuter.LoadDLL() Then
                Me.Text = "CPP-Lite ==> 加载动态链接库失败！"
                Exit Sub
            End If
            Me.Text = "CPP-Lite ==> 加载动态链接库成功，开始执行..."

            CodeChanged = False
        End If

        ShellExecuter.CallDLL("main")
        Me.Text = "CPP-Lite ==> 运行完毕！"
    End Sub

    ''' <summary>
    ''' 分析错误信息
    ''' </summary>
    Private Sub SearchError()
        Dim ErrorInfo() As String = IO.File.ReadAllLines(UnityWorkDirectory.BulidDirectory & "ret.txt")
        Dim Info() As String
        '跳过第 0 行
        For Index As Integer = 1 To ErrorInfo.Length - 1
            Info = Split(ErrorInfo(Index), ":", 3)
            If Info.Length < 3 Then Continue For
            If Info(1).ToLower().IndexOf("error") Then
                Dim ErrorPattern As String = ".*?\((?<LineIndex>.+?)\).*?"
                Dim ErrorRegex As Regex = New Regex(ErrorPattern, RegexOptions.IgnoreCase Or RegexOptions.Singleline)
                Dim ErrorMatchResult As Match = ErrorRegex.Match(Info(0))
                With ErrorListBox.Items
                    .Add((Integer.Parse(ErrorMatchResult.Groups("LineIndex").Value) - 2).ToString())
                    .Item(.Count - 1).SubItems.Add(Info(2))
                End With
            End If
        Next
    End Sub

    Private Sub RunForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        UnityWorkDirectory.EnvirmentDirectory = Application.StartupPath & "\Envirment\"
        UnityWorkDirectory.BulidDirectory = Application.StartupPath & "\Bulid\"
        CodeTextBox.SelectionStart = 0
        CodeTextBox.SelectionLength = 0
    End Sub

    Private Sub CodeTextBox_TextChanged(sender As Object, e As EventArgs) Handles CodeTextBox.TextChanged
        CodeChanged = True
    End Sub

    Private Sub ErrorListBox_DoubleClick(sender As Object, e As EventArgs) Handles ErrorListBox.DoubleClick
        Try
            If ErrorListBox.SelectedItems.Count = 0 Then Exit Sub
            Dim LineIndex As Integer
            If Integer.TryParse(ErrorListBox.SelectedItems.Item(0).Text, LineIndex) Then
                CodeTextBox.Select(String.Join(vbCrLf, CodeTextBox.Lines, 0, LineIndex - 1).Length, CodeTextBox.Lines(LineIndex - 1).Length + 2)
                CodeTextBox.Focus()
            End If
        Catch ex As Exception
            '无法定位错误行
        End Try
    End Sub

    Private Sub RunForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        ShellExecuter.FreeDLL()
    End Sub

End Class
