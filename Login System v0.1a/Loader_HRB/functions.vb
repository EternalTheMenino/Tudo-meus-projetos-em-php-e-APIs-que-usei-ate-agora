Imports System.Management

Module functions
    Function GetHDSerial() As String
        Dim strHDSerial As String = String.Empty
        Dim index As Integer = 0
        Dim Data As String
        Dim query As New SelectQuery("Win32_DiskDrive")
        Dim search As New ManagementObjectSearcher(query)
        Dim info As ManagementObject
        Try
            For Each info In search.Get()
                Data = info("SerialNumber")
                If Data.Contains(" ") Then
                    Return Data.Replace(" ", "")
                Else
                    Return Data.Replace(vbNewLine, "")
                End If
            Next
        Catch ex As Exception
            strHDSerial = "Error67"
        End Try
    End Function

    Public Function base64_encode(ByVal str As String) As String
        Dim data As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(str)
        Return System.Convert.ToBase64String(data)
    End Function
    Public Function base64_decode(ByVal str As String) As String
        Dim data As Byte() = System.Convert.FromBase64String(str)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function


    Public Function encry(ByVal str As String, ByVal dir As Integer) As String
        Dim retorna As String = ""
        For i As Integer = 0 To str.Length - 1
            retorna &= Chr(Asc(str(i)) + dir)
        Next
        Return retorna
    End Function
    Public Function decry(ByVal str As String, ByVal dir As Integer) As String
        Dim retorna As String = ""
        For i As Integer = 0 To str.Length - 1
            retorna &= Chr(Asc(str(i)) - dir)
        Next
        Return retorna
    End Function

    Dim DoubleBytes As Double
    Public Function FormatBytes(ByVal BytesCaller As ULong) As String
        'Função tirada de:
        'https://stackoverflow.com/questions/27367190/how-to-return-kb-mb-and-gb-from-bytes-using-a-public-function
        Try
            Select Case BytesCaller
                Case Is >= 1099511627776
                    DoubleBytes = CDbl(BytesCaller / 1099511627776) 'TB
                    Return FormatNumber(DoubleBytes, 2) & " TB"
                Case 1073741824 To 1099511627775
                    DoubleBytes = CDbl(BytesCaller / 1073741824) 'GB
                    Return FormatNumber(DoubleBytes, 2) & " GB"
                Case 1048576 To 1073741823
                    DoubleBytes = CDbl(BytesCaller / 1048576) 'MB
                    Return FormatNumber(DoubleBytes, 2) & " MB"
                Case 1024 To 1048575
                    DoubleBytes = CDbl(BytesCaller / 1024) 'KB
                    Return FormatNumber(DoubleBytes, 2) & " KB"
                Case 0 To 1023
                    DoubleBytes = BytesCaller ' bytes
                    Return FormatNumber(DoubleBytes, 2) & " bytes"
                Case Else
                    Return ""
            End Select
        Catch
            Return ""
        End Try

    End Function










    Private TargetProcessHandle As Integer
    Private pfnStartAddr As Integer
    Private pszLibFileRemote As String
    Private TargetBufferSize As Integer

    Public Const PROCESS_VM_READ = &H10
    Public Const TH32CS_SNAPPROCESS = &H2
    Public Const MEM_COMMIT = 4096
    Public Const PAGE_READWRITE = 4
    Public Const PROCESS_CREATE_THREAD = (&H2)
    Public Const PROCESS_VM_OPERATION = (&H8)
    Public Const PROCESS_VM_WRITE = (&H20)
    Dim DLLFileName As String
    Public Declare Function ReadProcessMemory Lib "kernel32" (
    ByVal hProcess As Integer,
    ByVal lpBaseAddress As Integer,
    ByVal lpBuffer As String,
    ByVal nSize As Integer,
    ByRef lpNumberOfBytesWritten As Integer) As Integer

    Public Declare Function LoadLibrary Lib "kernel32" Alias "LoadLibraryA" (
    ByVal lpLibFileName As String) As Integer

    Public Declare Function VirtualAllocEx Lib "kernel32" (
    ByVal hProcess As Integer,
    ByVal lpAddress As Integer,
    ByVal dwSize As Integer,
    ByVal flAllocationType As Integer,
    ByVal flProtect As Integer) As Integer

    Public Declare Function WriteProcessMemory Lib "kernel32" (
    ByVal hProcess As Integer,
    ByVal lpBaseAddress As Integer,
    ByVal lpBuffer As String,
    ByVal nSize As Integer,
    ByRef lpNumberOfBytesWritten As Integer) As Integer

    Public Declare Function GetProcAddress Lib "kernel32" (
    ByVal hModule As Integer, ByVal lpProcName As String) As Integer

    Private Declare Function GetModuleHandle Lib "Kernel32" Alias "GetModuleHandleA" (
    ByVal lpModuleName As String) As Integer

    Public Declare Function CreateRemoteThread Lib "kernel32" (
    ByVal hProcess As Integer,
    ByVal lpThreadAttributes As Integer,
    ByVal dwStackSize As Integer,
    ByVal lpStartAddress As Integer,
    ByVal lpParameter As Integer,
    ByVal dwCreationFlags As Integer,
    ByRef lpThreadId As Integer) As Integer

    Public Declare Function OpenProcess Lib "kernel32" (
    ByVal dwDesiredAccess As Integer,
    ByVal bInheritHandle As Integer,
    ByVal dwProcessId As Integer) As Integer

    Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" (
    ByVal lpClassName As String,
    ByVal lpWindowName As String) As Integer

    Private Declare Function CloseHandle Lib "kernel32" Alias "CloseHandleA" (
    ByVal hObject As Integer) As Integer
    Dim ExeName As String = IO.Path.GetFileNameWithoutExtension(Application.ExecutablePath)

    Public Sub Inject(ByVal proc As String, ByVal dlll As String)
        On Error GoTo 1
        'pgb1.Increment(10)
        Dim s() As Process
        s = Process.GetProcessesByName(proc)
        If s.Length > 0 Then
            'pgb1.Increment(30)
            If IO.File.Exists(dlll) Then
                'pgb1.Increment(60)
                Dim TargetProcess As Process() = Process.GetProcessesByName(proc)
                TargetProcessHandle = OpenProcess(PROCESS_CREATE_THREAD Or PROCESS_VM_OPERATION Or PROCESS_VM_WRITE, False, TargetProcess(0).Id)
                pszLibFileRemote = dlll
                pfnStartAddr = GetProcAddress(GetModuleHandle("Kernel32"), "LoadLibraryA")
                TargetBufferSize = 1 + Len(pszLibFileRemote)
                Dim Rtn As Integer
                Dim LoadLibParamAdr As Integer
                LoadLibParamAdr = VirtualAllocEx(TargetProcessHandle, 0, TargetBufferSize, MEM_COMMIT, PAGE_READWRITE)
                Rtn = WriteProcessMemory(TargetProcessHandle, LoadLibParamAdr, pszLibFileRemote, TargetBufferSize, 0)


                CreateRemoteThread(TargetProcessHandle, 0, 0, pfnStartAddr, LoadLibParamAdr, 0, 0)
                'Me.Text = "Injected com Sucesso!"
                CloseHandle(TargetProcessHandle)

            End If
        End If

1:
    End Sub
End Module
