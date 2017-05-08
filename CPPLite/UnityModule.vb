Imports System.Runtime.InteropServices
Imports System.Security.Permissions
Imports System.Text

Module UnityModule
    Public Declare Function LoadLibrary Lib "kernel32" Alias "LoadLibraryA" (ByVal lpLibFileName As String) As Integer
    Public Declare Function FreeLibrary Lib "kernel32" (ByVal hLibModule As Integer) As Integer
    Public Declare Function GetProcAddress Lib "kernel32" (ByVal hModule As Integer, ByVal lpProcName As String) As Integer
    Public Declare Function CallWindowProc Lib "user32" Alias "CallWindowProcA" (ByVal lpPrevWndFunc As Integer, ByVal hwnd As ReturnFunctionDeclare, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    Public Declare Function CallWindowProc Lib "user32" Alias "CallWindowProcA" (ByVal lpPrevWndFunc As Integer, ByVal hwnd As Integer, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    Private Declare Function SysAllocString Lib "oleaut32.dll" (ByRef pOlechar As IntPtr) As String
    Private Declare Function SysFreeString Lib "oleaut32.dll" (ByRef bstr As String) As Integer

    Public Delegate Sub ReturnFunctionDeclare(Buffered As IntPtr)
    Public ReturnFunctionDelegate As New ReturnFunctionDeclare(AddressOf ReturnFunction)
    Public DLLHandle As Integer

    <SecurityPermissionAttribute(SecurityAction.Demand, Unrestricted:=True)>
    Public Sub ReturnFunction(Buffered As IntPtr)
        Debug.Print(Buffered)

        Debug.Print(Marshal.PtrToStringAnsi(Buffered))
        Debug.Print(Marshal.PtrToStringAuto(Buffered))
        Debug.Print(Marshal.PtrToStringBSTR(Buffered))
        Debug.Print(Marshal.PtrToStringUni(Buffered))

        'Dim ReturnString As String = ""
        'ReturnString = SysAllocString(Buffered)
        'Debug.Print(ReturnString)

        'Marshal.FreeBSTR(Buffered)
        'SysFreeString(ReturnString)
    End Sub

End Module
