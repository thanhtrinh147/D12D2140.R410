''' <summary>
''' Định nghĩa các biến truyền qua lại giữa các exe với nhau
''' </summary>
Module D12X0003

    Public Const EXEMODULE As String = "D12"
    Public Const EXED00 As String = "D00E0030"
    Public Const EXEPARENT As String = "D12E0030"
    Public Const EXECHILD As String = "D12E2140"
    '---------------------------------------
    ''' <summary>
    ''' Server truyền vào
    ''' </summary>
    Public PARA_Server As String
    ''' <summary>
    ''' Database truyền vào
    ''' </summary>
    Public PARA_Database As String
    ''' <summary>
    ''' User login vào Lemon3 truyền vào
    ''' </summary>
    Public PARA_ConnectionUser As String
    ''' <summary>
    ''' User login vào Database truyền vào
    ''' </summary>
    Public PARA_UserID As String
    ''' <summary>
    ''' Password user login vào Database truyền vào
    ''' </summary>
    Public PARA_Password As String
    ''' <summary>
    ''' Đơn vị truyền vào
    ''' </summary>
    Public PARA_DivisionID As String
    ''' <summary>
    ''' Tháng kế toán truyền vào
    ''' </summary>
    Public PARA_TranMonth As String
    ''' <summary>
    ''' Năm kế toán truyền vào
    ''' </summary>
    Public PARA_TranYear As String
    ''' <summary>
    ''' Ngôn ngữ truyền vào
    ''' </summary>
    ''' <remarks></remarks>
    Public PARA_Language As EnumLanguage
    ''' <summary>
    ''' Form ID dùng để hiện thị. Ví dụ: DxxFxxxx
    ''' </summary>
    Public PARA_FormID As String
    ''' <summary>
    ''' Form ID dùng để phân quyền. Ví dụ: DxxFxxxx
    ''' </summary>
    Public PARA_FormIDPermission As String

    Public PARA_FormIDParent As String
    Public PARA_ID01 As String

    Public PARA_ID02 As Boolean

    Public PARA_PRID As String

    Public PARA_gbClosed As Boolean
    Public PARA_gbyUseWorkFlow As Byte

    Public PARA_CreateBy As String

    Public PARA_ModuleID As String

    'Public PARA_FormState As EnumFormState
    'Public PARA_SavedOk As Boolean
    '---------------------------------------
    'Ngoài ra khi cần thêm bất cứ thông số nào lập trình viên phải định nghĩa bắt
    'đầu bằng refix PARA_
    'Public PARA_POID As String 'Cho D12F3111
End Module
