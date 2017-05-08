''' <summary>
''' 用于保存 C++ 代码文件
''' </summary>
Public Class CPPSaver
    ''' <summary>
    ''' 保存 C++ 代码文件
    ''' </summary>
    ''' <param name="CPPCode">C++ 代码</param>
    ''' <returns></returns>
    Public Shared Function SaveCPPToFile(CPPCode As String) As Boolean
        Try
            IO.File.WriteAllLines(UnityWorkDirectory.BulidDirectory & "Temp.cpp", New String() {"#include ""stdafx.h""", "#include ""Temp.h""", CPPCode})
            Return IO.File.Exists(UnityWorkDirectory.BulidDirectory & "Temp.cpp")
        Catch ex As Exception
            MsgBox("生成代码失败！", ex.Message)
            Return False
        End Try
    End Function

End Class
