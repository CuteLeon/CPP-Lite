''' <summary>
''' 用于根据 CPP 文件编译为 OBJ
''' </summary>
Public Class OBJCompiler

    Public Shared Function ComplierOBJ() As Boolean
        If ShellExecuter.Execute(UnityWorkDirectory.EnvirmentDirectory & "MyCL.bat") Then
            Return True
        Else
            Return False
        End If
    End Function

End Class
