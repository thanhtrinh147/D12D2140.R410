Imports System
Public Enum D12E0230Form
    D12F3000
    D12F3110
    D12F2156
    D12F2152
End Enum

Public Class D12E0230
    Private Const EXEMODULE As String = "D12"
    Private Const EXECHILD As String = "D12E0230"
    Private sLanguage As String

    ''' <summary>
    ''' Khởi tạo exe con D12E0230
    ''' </summary>
    ''' <param name="Server">Server kết nối đến hệ thống</param>
    ''' <param name="Database">Database kết nối đến hệ thống</param>
    ''' <param name="UserDatabaseID">User Database kết nối đến hệ thống</param>
    ''' <param name="Password">Password kết nối đến hệ thống</param>
    ''' <param name="UserID">User Lemon3 kết nối đến hệ thống</param>
    ''' <param name="Language">Ngôn ngữ sử dụng</param>
    Public Sub New(ByVal Server As String, ByVal Database As String, ByVal UserDatabaseID As String, ByVal Password As String, ByVal UserID As String, ByVal Language As String)
        sLanguage = Language
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ServerName", Server, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "DBName", Database, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ConnectionUserID", UserDatabaseID, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Password", Password, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "UserID", UserID, CodeOption.lmCode)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Language", Language)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "UseWorkFlow", gbyUseWorkflow.ToString)
    End Sub

    ''' <summary>
    ''' Khởi tạo exe con D91E0130
    ''' </summary>
    ''' <param name="Server">Server kết nối đến hệ thống</param>
    ''' <param name="Database">Database kết nối đến hệ thống</param>
    ''' <param name="UserDatabaseID">User Database kết nối đến hệ thống</param>
    ''' <param name="Password">Password kết nối đến hệ thống</param>
    ''' <param name="UserID">User Lemon3 kết nối đến hệ thống</param>
    ''' <param name="Language">Ngôn ngữ sử dụng</param>
    ''' <param name="DivisionID">Đơn vị hiện tại</param>
    ''' <param name="TranMonth">Tháng kế toán hiện tại</param>
    ''' <param name="TranYear">Năm kế toán hiện tại</param>
    Public Sub New(ByVal Server As String, ByVal Database As String, ByVal UserDatabaseID As String, ByVal Password As String, ByVal UserID As String, ByVal Language As String, ByVal DivisionID As String, ByVal TranMonth As Integer, ByVal TranYear As Integer)
        Me.New(Server, Database, UserDatabaseID, Password, UserID, Language)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "DivisionID", DivisionID)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "TranMonth", TranMonth.ToString)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "TranYear", TranYear.ToString)
        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ID02", "D12F1031")
    End Sub

    ''' <summary>
    ''' Màn hình cần hiển thị cho exe con
    ''' </summary>
    Public WriteOnly Property FormActive() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Ctrl01", Value)
        End Set
    End Property

    Public WriteOnly Property FormShow() As D12E0230Form
        Set(ByVal Value As D12E0230Form)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Ctrl01", [Enum].GetName(GetType(D12E0230Form), Value))
        End Set
    End Property

    ''' <summary>
    ''' Màn hình phân quyền cho exe con
    ''' </summary>
    Public WriteOnly Property FormPermission() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "Ctrl03", Value)
        End Set
    End Property

    '''' <summary>
    '''' ModuleName
    '''' </summary>
    'Public WriteOnly Property FormState() As String
    '    Set(ByVal Value As String)
    '        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "FlagUpdate", Value)
    '    End Set
    'End Property

    ''' <summary>
    ''' ModuleName
    ''' </summary>
    ''' 
    Public WriteOnly Property FormState() As String
        Set(ByVal Value As String)
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "FlagUpdate", Value)
        End Set
    End Property


    'Public WriteOnly Property FormState() As EnumFormState
    '    Set(ByVal Value As EnumFormState)
    '        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "FlagUpdate", ConvertToVB6FormState(Value).ToString)
    '    End Set
    'End Property

    

    'Public WriteOnly Property PRID() As String
    '    Set(ByVal Value As String)
    '        D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ID01", Value)
    '    End Set
    'End Property

    Private _pRID As String
    Public Property PRID() As String
        Get
            Dim s As String = ""
            s = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ID01", "")
            Return IIf(s Is Nothing, "", s).ToString
        End Get
        Set(ByVal Value As String)
            If Value Is Nothing Then Value = ""
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ID01", Value)
        End Set
    End Property


    Public WriteOnly Property PRTransactionID() As String
        Set(ByVal Value As String)
            If Value Is Nothing Then Value = ""
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ID01", Value)
        End Set
    End Property

    Public WriteOnly Property ObjectTypeID() As String
        Set(ByVal Value As String)
            If Value Is Nothing Then Value = ""
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ID02", Value)
        End Set
    End Property

    Public WriteOnly Property ObjectID() As String
        Set(ByVal Value As String)
            If Value Is Nothing Then Value = ""
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ID03", Value)
        End Set
    End Property

    Public WriteOnly Property ObjectName() As String
        Set(ByVal Value As String)
            If Value Is Nothing Then Value = ""
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ID04", Value)
        End Set
    End Property

    Public WriteOnly Property POID() As String
        Set(ByVal Value As String)
            If Value Is Nothing Then Value = ""
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ID05", Value)
        End Set
    End Property

    Public WriteOnly Property StatusMenu() As String
        Set(ByVal Value As String)
            If Value Is Nothing Then Value = ""
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ID06", Value)
        End Set
    End Property

    Public WriteOnly Property ParentForm() As String
        Set(ByVal Value As String)
            If Value Is Nothing Then Value = ""
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ID07", Value)
        End Set
    End Property


    Public WriteOnly Property MStatus() As String
        Set(ByVal Value As String)
            If Value Is Nothing Then Value = ""
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ID08", Value)
        End Set
    End Property

    Public WriteOnly Property VoucherID() As String
        Set(ByVal Value As String)
            If Value Is Nothing Then Value = ""
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ID09", Value)
        End Set
    End Property

    Public WriteOnly Property PlanID() As String
        Set(ByVal Value As String)
            If Value Is Nothing Then Value = ""

            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ID01", Value)
        End Set
    End Property


    ''' <summary>
    ''' SavedOK
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public ReadOnly Property Out_SavedOK() As Boolean
        Get
            Return CBool(D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "SavedOK", "True"))
        End Get
    End Property

    Private _formCall As String
    Public WriteOnly Property FormCall() As String
        Set(ByVal Value As String)
            If Value Is Nothing Then Value = ""
            D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "ID07", Value)
        End Set
    End Property

    ''' <summary>
    ''' Thực thi exe con
    ''' </summary>
    Public Sub Run()
        If Not ExistFile(My.Application.Info.DirectoryPath & "\" & EXECHILD & ".exe") Then Exit Sub
        Dim pInfo As New System.Diagnostics.ProcessStartInfo(My.Application.Info.DirectoryPath & "\" & EXECHILD & ".exe")
        pInfo.Arguments = "/DigiNet Corporation"
        pInfo.WindowStyle = ProcessWindowStyle.Normal
        Process.Start(pInfo)
    End Sub


    ''' <summary>
    ''' Kiểm tra tồn tại exe con không ?
    ''' </summary>
    Private Function ExistFile(ByVal Path As String) As Boolean
        If System.IO.File.Exists(Path) Then Return True
        If sLanguage = "0" Then
            D99C0008.MsgL3("Không tồn tại file " & EXECHILD & ".exe")
        Else
            D99C0008.MsgL3("Not exist file" & EXECHILD & ".exe")
        End If
        Return False
    End Function
End Class
