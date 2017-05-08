''' <summary>
''' 用于隐蔽执行exe/bat，并获取返回值
''' </summary>
Public Class ShellExecuter

    Public Shared Function Execute(ExecutableFilePath As String) As Boolean
        Try
            Dim iProcess As Process = New Process()
            iProcess.StartInfo.FileName = ExecutableFilePath
            iProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            iProcess.Start()
            iProcess.WaitForExit()
            If iProcess.ExitCode = 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox("执行程序时失败！", ex.Message)
            Return False
        End Try
    End Function

    Public Shared Function LoadDLL() As Boolean
        DLLHandle = LoadLibrary(UnityWorkDirectory.BulidDirectory & "Temp.dll")
        If DLLHandle = 0 Then Return False

        Dim ProCAddress As Integer = GetProcAddress(DLLHandle, "Config")
        If ProCAddress = 0 Then Return False

        CallWindowProc(ProCAddress, ReturnFunctionDelegate, 0, 0, 0)
        Return True
    End Function

    Public Shared Sub CallDLL(FunctionName As String)
        Dim ProCAddress As Integer
        ProCAddress = GetProcAddress(DLLHandle, FunctionName)

        If ProCAddress = 0 Then
            MsgBox("函数 """ & FunctionName & """ 未定义", vbCritical)
        Else
            CallWindowProc(ProCAddress, 0, 0, 0, 0)
        End If
    End Sub

    Public Shared Sub FreeDLL()
        If DLLHandle > 0 Then FreeLibrary(DLLHandle)
    End Sub

End Class
