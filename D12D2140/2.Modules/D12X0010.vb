''' <summary>
''' Module này dùng để chưá các hàm AuditLog
''' </summary>
Module D12X0010

    ''' <summary>
    ''' Kiểm tra có dùng mã AuditCode không
    ''' </summary>
    Enum StatusAuditCode
        ''' <summary>
        ''' Chưa kiểm tra
        ''' </summary>
        None = 0
        ''' <summary>
        ''' Kiểm tra có dùng
        ''' </summary>
        Use = 1
        ''' <summary>
        ''' Kiểm tra không dùng
        ''' </summary>
        NoUse = 2
    End Enum
   
    Public geAutoSetPurReq As StatusAuditCode = StatusAuditCode.None

    Public geEnPurRequest As StatusAuditCode = StatusAuditCode.None
    Public geAppPurRequest As StatusAuditCode = StatusAuditCode.None
    Public geAutoSelPurReq As StatusAuditCode = StatusAuditCode.None
    Public gePurchasePlan As StatusAuditCode = StatusAuditCode.None

    'Các AuditCode của AuditLog
   
    Public AuditCodeAutoSetPurReq As String = "AutoSetPurReq"

    Public Const AuditCodeEnPurRequest As String = "EnPurRequest"
    Public Const AuditCodeAppPurRequest As String = "AppPurRequest"
    Public Const AuditCodeAutoSelPurReq As String = "AutoSelPurReq"
    Public Const AuditCodePurchasePlan As String = "PurchasePlan"


    'Các biến toàn cục cho Audit
    'Public gbUseAudit As Boolean ' Module này có sử dụng Audit hay không
    Public gsAuditForm As String ' Mã và Tên Form cho in báo cáo (Font VNI)
    Public gsAuditReport As String 'Mã và Tên Report in báo cáo (Font VNI)

    'Public Sub UseAuditLog()
    '    '#------------------------------------------------------
    '    '#CreateUser:   Nguyen Thi Minh Hoa
    '    '#CreateDate:   21/11/2007
    '    '#ModifiedUser: Nguyen Thi Minh Hoa
    '    '#ModifiedDate: 21/11/2007
    '    '#Description: Kiểm tra module này có dùng Audit không? Có trả ra = True, không = False
    '    '#------------------------------------------------------
    '    Dim sSQL As String
    '    sSQL = "Select top 1 1 From D91T9200 Where Audit=1 And ModuleID= '12'"
    '    gbUseAudit = ExistRecord(sSQL)

    'End Sub

    Public Sub RunAuditLog(ByVal sAuditCode As String, ByVal sEventID As String, ByVal sDesc1 As String, ByVal sDesc2 As String, ByVal sDesc3 As String, ByVal sDesc4 As String, ByVal sDesc5 As String)
        ''Module này có dùng Auditlog không
        'If Not gbUseAudit Then Exit Sub
        ''Mã AuditCode này có sử dụng không
        'If Not CheckUseAuditCode(sAuditCode) Then Exit Sub

        'Ghi Audit cho mỗi nghiệp vụ
        Dim sSQL As String = ""
        sSQL &= "Exec D91P9106 "
        sSQL &= SQLDateTimeSave(Now) & COMMA 'AuditDate, datetime, NOT NULL
        sSQL &= SQLString(sAuditCode) & COMMA 'AuditCode, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString("12") & COMMA 'ModuleID, varchar[2], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(sEventID) & COMMA 'EventID, varchar[20], NOT NULL
        sSQL &= SQLString(sDesc1) & COMMA 'Desc1, varchar[250], NOT NULL
        sSQL &= SQLString(sDesc2) & COMMA 'Desc2, varchar[250], NOT NULL
        sSQL &= SQLString(sDesc3) & COMMA 'Desc3, varchar[250], NOT NULL
        sSQL &= SQLString(sDesc4) & COMMA 'Desc4, varchar[250], NOT NULL
        sSQL &= SQLString(sDesc5) 'Desc5, varchar[250], NOT NULL

        ExecuteSQLNoTransaction(sSQL)

    End Sub

    Private Function CheckUseAuditCode(ByVal AuditCode As String) As Boolean
        Select Case AuditCode
            Case AuditCodeAutoSetPurReq
                If geAutoSetPurReq = StatusAuditCode.None Then
                    If ExistRecordAuditCode(AuditCode) Then
                        geAutoSetPurReq = StatusAuditCode.Use
                    Else
                        geAutoSetPurReq = StatusAuditCode.NoUse
                    End If
                End If
                Return geAutoSetPurReq = StatusAuditCode.Use

            Case AuditCodeEnPurRequest
                If geEnPurRequest = StatusAuditCode.None Then
                    If ExistRecordAuditCode(AuditCode) Then
                        geEnPurRequest = StatusAuditCode.Use
                    Else
                        geEnPurRequest = StatusAuditCode.NoUse
                    End If
                End If
                Return geEnPurRequest = StatusAuditCode.Use


            Case AuditCodeAppPurRequest
                If geAppPurRequest = StatusAuditCode.None Then
                    If ExistRecordAuditCode(AuditCode) Then
                        geAppPurRequest = StatusAuditCode.Use
                    Else
                        geAppPurRequest = StatusAuditCode.NoUse
                    End If
                End If
                Return geAppPurRequest = StatusAuditCode.Use

            Case AuditCodePurchasePlan
                If gePurchasePlan = StatusAuditCode.None Then
                    If ExistRecordAuditCode(AuditCode) Then
                        gePurchasePlan = StatusAuditCode.Use
                    Else
                        gePurchasePlan = StatusAuditCode.NoUse
                    End If
                End If
                Return gePurchasePlan = StatusAuditCode.Use

                'AutoSelPurReq
            Case AuditCodeAutoSelPurReq
                If geAutoSelPurReq = StatusAuditCode.None Then
                    If ExistRecordAuditCode(AuditCode) Then
                        geAutoSelPurReq = StatusAuditCode.Use
                    Else
                        geAutoSelPurReq = StatusAuditCode.NoUse
                    End If
                End If
                Return geAutoSelPurReq = StatusAuditCode.Use
        End Select

    End Function

    Private Function ExistRecordAuditCode(ByVal AuditCode As String) As Boolean
        Dim sSQL As String
        sSQL = "Select 1 From D91T9200 WITH(NOLOCK) Where  Audit =1 And ModuleID= '12' And AuditCode= " & SQLString(AuditCode)
        Return ExistRecord(sSQL)
    End Function

End Module
