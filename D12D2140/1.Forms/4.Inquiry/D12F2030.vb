'#-------------------------------------------------------------------------------------
'# Created Date: 03/04/2008 9:08:51 AM
'# Created User: Đỗ Minh Dũng
'# Modify Date: 03/04/2008 9:08:51 AM
'# Modify User: Đỗ Minh Dũng
'#-------------------------------------------------------------------------------------
Public Class D12F2030
	Dim dtCaptionCols As DataTable

    Dim bUseSpec As Boolean
    Dim dtGrid As DataTable
    Dim iColumnsSum() As Integer = {COL_ApprovedQuantity, COL_POQuantity, COL_Amount}

#Region "Chuẩn hóa D09U1111 B1: đinh nghĩa biến "
    'Chuẩn hóa D09U1111 B1: đinh nghĩa biến
    Private usrOption As D09U1111
    Private arrMaster As New ArrayList ' Mảng Master
#End Region

#Region "Const of tdbg"
    Private Const COL_Choose As Integer = 0            ' Chọn
    Private Const COL_PRID As Integer = 1              ' PRID
    Private Const COL_PRTransactionID As Integer = 2   ' PRTransactionID
    Private Const COL_SupplierTransID As Integer = 3   ' SupplierTransID
    Private Const COL_PRVoucherNo As Integer = 4       ' Số yêu cầu
    Private Const COL_AStatusName As Integer = 5       ' Trạng thái duyệt
    Private Const COL_ApproveNotes As Integer = 6      ' Ghi chú duyệt
    Private Const COL_ApproveUserID As Integer = 7     ' Người duyệt
    Private Const COL_ApprovedQuantity As Integer = 8  ' Số lượng duyệt
    Private Const COL_ObjectID As Integer = 9          ' Đối tượng
    Private Const COL_InventoryID As Integer = 10      ' Mã hàng
    Private Const COL_InventoryName As Integer = 11    ' Tên hàng
    Private Const COL_Spec01ID As Integer = 12         ' Spec01ID
    Private Const COL_Spec02ID As Integer = 13         ' Spec02ID
    Private Const COL_Spec03ID As Integer = 14         ' Spec03ID
    Private Const COL_Spec04ID As Integer = 15         ' Spec04ID
    Private Const COL_Spec05ID As Integer = 16         ' Spec05ID
    Private Const COL_Spec06ID As Integer = 17         ' Spec06ID
    Private Const COL_Spec07ID As Integer = 18         ' Spec07ID
    Private Const COL_Spec08ID As Integer = 19         ' Spec08ID
    Private Const COL_Spec09ID As Integer = 20         ' Spec09ID
    Private Const COL_Spec10ID As Integer = 21         ' Spec10ID
    Private Const COL_UnitID As Integer = 22           ' ĐVT
    Private Const COL_EmptyCol As Integer = 23         ' EmptyCol
    Private Const COL_POQuantity As Integer = 24       ' SL lập đơn hàng
    Private Const COL_Amount As Integer = 25           ' Thành tiền
    Private Const COL_CreateUserID As Integer = 26     ' CreateUserID
    Private Const COL_CreateDate As Integer = 27       ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 28 ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 29   ' LastModifyDate
    Private Const COL_ObjectTypeID As Integer = 30     ' ObjectTypeID
#End Region

    Private Sub D12F2030_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me, True)
            Case Keys.F5
                btnFilter_Click(sender, Nothing)
            Case Keys.F11
                HotKeyF11(Me, tdbg)
                'Chuẩn hóa D09U1111 B4: mở UserControl(F12), đóng UserControl (Escape)
            Case Keys.F12 ' Mở
                btnF12_Click(Nothing, Nothing)
            Case Keys.Escape 'Đóng
                If giRefreshUserControl = 0 Then
                    If D99C0008.MsgAsk("Thông tin trên lưới đã thay đổi, bạn có muốn Refresh lại không?") = Windows.Forms.DialogResult.Yes Then
                        usrOption.D09U1111Refresh()
                    End If
                End If
                usrOption.Hide()
        End Select
    End Sub

    Private Sub D12F2030_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If usrOption IsNot Nothing Then usrOption.Dispose()
    End Sub

    Private Sub D12F2030_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        bUseSpec = LoadTDBGridSpecificationCaption(tdbg, COL_Spec01ID, 0, True, gbUnicode)
        gbEnabledUseFind = False
        ResetColorGrid(tdbg)
        ResetFooterGrid(tdbg)
        InputbyUnicode(Me, gbUnicode)
        LoadLanguage()
        LoadTDBCombo()
        ResetColorGrid(tdbg)
        tdbg_NumberFormat()
        LoadDefault()
        CallD09U1111(True)
        SetShortcutPopupMenu(Me, ToolStrip1, ContextMenuStrip1)
        CheckMenu(Me.Name, ToolStrip1, tdbg.RowCount, gbEnabledUseFind, True, ContextMenuStrip1)
        SetResolutionForm(Me, ContextMenuStrip1)
    End Sub

    'Dim dtCaptionCols As DataTable
    Private Sub CallD09U1111(ByVal bLoadFirst As Boolean)
        'CHÚ Ý: Luôn luôn để đúng thứ tự Split và nút nhấn trên lưới
        If bLoadFirst Then
            'Những cột bắt buộc nhập
            Dim arrColObligatory() As Integer = {COL_Choose}
            AddColVisible(tdbg, SPLIT0, arrMaster, arrColObligatory, , , gbUnicode)
        End If
        dtCaptionCols = CreateTableForExcel(tdbg, arrMaster)
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D09U1111(tdbg, dtCaptionCols, Me.Name.Substring(1, 2), Me.Name, "0", , bLoadFirst, , gbUnicode)
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_ApprovedQuantity).NumberFormat = DxxFormat.D07_QuantityDecimals
        tdbg.Columns(COL_POQuantity).NumberFormat = DxxFormat.D07_QuantityDecimals
        tdbg.Columns(COL_Amount).NumberFormat = DxxFormat.DecimalPlaces 'ID 55529 DxxFormat.D90_ConvertedDecimals
    End Sub

    Private Sub LoadDefault()
        c1dateFrom.Value = Now.Date
        c1dateTo.Value = Now.Date
        tdbcPeriodIDFrom.Text = giTranMonth.ToString("00") & "/" & giTranYear
        tdbcPeriodIDTo.Text = giTranMonth.ToString("00") & "/" & giTranYear
        optPeriod.Checked = True

        tdbg.Splits(0).DisplayColumns(COL_AStatusName).Visible = (D12Systems.QApproveMaxLevel <> 0)
        tdbg.Splits(0).DisplayColumns(COL_ApproveNotes).Visible = (D12Systems.QApproveMaxLevel <> 0)
        tdbg.Splits(0).DisplayColumns(COL_ApproveUserID).Visible = (D12Systems.QApproveMaxLevel <> 0)
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""

        LoadCboPeriodReport(tdbcPeriodIDFrom, tdbcPeriodIDTo, D12)

        'Load tdbcObjectTypeID
        sSQL = "Select '%' As ObjectTypeID, " & AllName & " As ObjectTypeName, 0 AS DisplayOrder " & vbCrLf
        sSQL &= " Union All " & vbCrLf
        sSQL &= " Select ObjectTypeID, "
        sSQL &= IIf(gsLanguage = "84", "ObjectTypeName", "ObjectTypeName01").ToString() & UnicodeJoin(gbUnicode) & " as ObjectTypeName,"
        sSQL &= " 1 AS DisplayOrder " & vbCrLf
        sSQL &= " From D91T0005 WITH(NOLOCK) " & vbCrLf
        sSQL &= " Order By DisplayOrder, ObjectTypeID" & vbCrLf
        LoadDataSource(tdbcObjectTypeID, sSQL, gbUnicode)
        tdbcObjectTypeID.SelectedValue = "%"
    End Sub

    Private Sub LoadTdbcObjectID(ByVal ObjectTypeID As String)
        Dim sSQL As String = ""
        'Load tdbcObjectID
        sSQL = " Select '%' As ObjectID, " & AllName & " As  ObjectName, 0 AS DisplayOrder " & vbCrLf
        sSQL &= "Union All " & vbCrLf
        sSQL &= "Select ObjectID, ObjectName" & UnicodeJoin(gbUnicode) & " as ObjectName, 1 AS DisplayOrder " & vbCrLf
        sSQL &= "From Object WITH(NOLOCK) Where ObjectTypeID Like " & SQLString(ObjectTypeID) & vbCrLf
        sSQL &= "And Disabled=0  " & vbCrLf
        sSQL &= "Order By DisplayOrder, ObjectID" & vbCrLf
        LoadDataSource(tdbcObjectID, sSQL, gbUnicode)
    End Sub


#Region "Events tdbcPeriodIDFrom"

    Private Sub tdbcPeriodIDFrom_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPeriodIDFrom.LostFocus
        If tdbcPeriodIDFrom.FindStringExact(tdbcPeriodIDFrom.Text) = -1 Then tdbcPeriodIDFrom.Text = ""
    End Sub

#End Region

#Region "Events tdbcPeriodIDTo"

    Private Sub tdbcPeriodIDTo_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPeriodIDTo.LostFocus
        If tdbcPeriodIDTo.FindStringExact(tdbcPeriodIDTo.Text) = -1 Then tdbcPeriodIDTo.Text = ""
    End Sub
#End Region

#Region "Events tdbcObjectTypeID load tdbcObjectID with txtObjectName"

    Private Sub tdbcObjectTypeID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcObjectTypeID.LostFocus
        If tdbcObjectTypeID.FindStringExact(tdbcObjectTypeID.Text) = -1 Then tdbcObjectTypeID.Text = ""
    End Sub

    Private Sub tdbcObjectTypeID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcObjectTypeID.SelectedValueChanged
        If Not (tdbcObjectTypeID.Tag Is Nothing OrElse tdbcObjectTypeID.Tag.ToString = "") Then
            tdbcObjectTypeID.Tag = ""
            Exit Sub
        End If
        If tdbcObjectTypeID.SelectedValue Is Nothing Then
            LoadTdbcObjectID("-1")
            Exit Sub
        End If

        LoadTdbcObjectID(tdbcObjectTypeID.Text())
        tdbcObjectID.SelectedValue = "%"
    End Sub

    Private Sub tdbcObjectID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcObjectID.LostFocus
        If tdbcObjectID.FindStringExact(tdbcObjectID.Text) = -1 Then
            tdbcObjectID.Text = ""
            txtObjectName.Text = ""
        End If
    End Sub

    Private Sub tdbcObjectID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcObjectID.SelectedValueChanged
        If tdbcObjectID.SelectedValue Is Nothing Then
            txtObjectName.Text = ""
        Else
            txtObjectName.Text = tdbcObjectID.Columns(1).Value.ToString
        End If
    End Sub
#End Region

    Private Sub optPeriod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPeriod.CheckedChanged
        tdbcPeriodIDFrom.Enabled = optPeriod.Checked
        tdbcPeriodIDTo.Enabled = optPeriod.Checked
        c1dateFrom.Enabled = Not optPeriod.Checked
        c1dateTo.Enabled = Not optPeriod.Checked
    End Sub

    Private Function GetCheckedRow() As String
        Dim sList As String = ""

        For i As Integer = 0 To tdbg.RowCount - 1
            If L3Bool(tdbg(i, COL_Choose)) = True Then
                sList += SQLString(tdbg(i, COL_SupplierTransID)) & COMMA
            End If
        Next i

        sList = sList.Remove(sList.Length - 2)
        sList = "(" & sList & ")"
        Return sList
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD12P2032
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 03/04/2008 09:34:30
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD12P2032() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D12P2032 "
        sSQL &= SQLString(tdbg.Columns(COL_PRID).Text) & COMMA 'PRID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbg.Columns(COL_PRTransactionID).Text) & COMMA 'PRTransactionID, varchar[20], NOT NULL
        sSQL &= SQLString(GetCheckedRow) & COMMA 'StrSupplierTranID, varchar[8000], NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD12P2033
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 03/04/2008 09:02:59
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD12P2033() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D12P2033 "
        sSQL &= SQLNumber(tdbcPeriodIDFrom.Columns("TranMonth").Text) & COMMA 'TranMonthFrom, smallint, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodIDFrom.Columns("TranYear").Text) & COMMA 'TranYearFrom, int, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodIDTo.Columns("TranMonth").Text) & COMMA 'TranMonthTo, smallint, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodIDTo.Columns("TranYear").Text) & COMMA 'TranYearTo, int, NOT NULL
        sSQL &= SQLDateSave(c1dateFrom.Text) & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateTo.Text) & COMMA 'DateTo, datetime, NOT NULL
        sSQL &= SQLString(tdbcObjectTypeID.Text) & COMMA 'ObjectTypeID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcObjectID.Text) & COMMA 'ObjectID, varchar[20], NOT NULL
        sSQL &= SQLNumber(IIf(optPeriod.Checked, 0, 1)) & COMMA 'Time, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        '23/3/2018, Nguyễn Quốc Khương: id 107118-Lỗi truy vấn lựa chọn nhà cung cấp 
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) 'DivisionID, varchar[20], NOT NULL
        Return sSQL
    End Function

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Me.Cursor = Cursors.WaitCursor
        LoadTDBGrid()
        CallD09U1111(False)
        Me.Cursor = Cursors.Default
    End Sub

    Private Function AllowDelate() As Boolean
        Dim bAtLeast As Boolean = False

        For i As Integer = 0 To tdbg.RowCount - 1
            If L3Bool(tdbg(i, COL_Choose)) Then
                bAtLeast = True
                Exit For
            End If
        Next i

        If Not bAtLeast Then
            D99C0008.MsgL3(rl3("MSG000010"))
            tdbg.Col = COL_Choose
            tdbg.Focus()
            Exit Function
        End If

        Return True
    End Function

    Private Sub HeadClickTask(ByVal icol As Integer)
        If icol = COL_Choose Then
            If tdbg.RowCount <= 0 Then Exit Sub

            Dim bCheck As Boolean = CBool(tdbg(0, COL_Choose))

            For i As Integer = 0 To tdbg.RowCount - 1
                tdbg(i, COL_Choose) = Not bCheck
            Next i
        End If
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        If e.ColIndex = COL_Choose Then
            tdbg.AllowSort = False
        Else
            tdbg.AllowSort = True
        End If

        HeadClickTask(e.ColIndex)
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        HotKeyCtrlVOnGrid(tdbg, e)
        Select Case e.KeyCode
            Case Keys.Enter
                If tdbg.Col = COL_Amount Then
                    HotKeyEnterGrid(tdbg, COL_Choose, e)
                End If

        End Select

        If e.Control And e.KeyCode = Keys.S Then
            HeadClickTask(tdbg.Col)
        End If
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Lua_chon_nha_cung_cap_-_D12F2030") & UnicodeCaption(gbUnicode) 'Løa chãn nhª cung cÊp - D12F2030
        '================================================================ 
        lblObjectID.Text = rl3("Doi_tuong") 'Đối tượng
        '================================================================ 
        btnFilter.Text = rl3("Loc") & " (F5)" 'Lọc
        btnF12.Text = rl3("Hien_thi") & " (F12)" 'Hiển thị
        '================================================================ 
        optPeriod.Text = rl3("Ky") 'Kỳ
        optDate.Text = rl3("Ngay") 'Ngày
        '================================================================ 
        '================================================================ 
        tdbcPeriodIDFrom.Columns("Period").Caption = rl3("Ky") 'Kỳ
        tdbcPeriodIDTo.Columns("Period").Caption = rl3("Ky") 'Kỳ
        tdbcObjectTypeID.Columns("ObjectTypeID").Caption = rl3("Ma") 'Mã
        tdbcObjectTypeID.Columns("ObjectTypeName").Caption = rl3("Ten") 'Tên
        tdbcObjectID.Columns("ObjectID").Caption = rl3("Ma") 'Mã
        tdbcObjectID.Columns("ObjectName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("Choose").Caption = rl3("Chon") 'Chọn
        tdbg.Columns("PRVoucherNo").Caption = rl3("So_yeu_cau") 'Số yêu cầu
        tdbg.Columns("AStatusName").Caption = rl3("Trang_thai_duyet") 'Trạng thái duyệt
        tdbg.Columns("ApproveNotes").Caption = rl3("Ghi_chu_duyet") 'Ghi chú duyệt
        tdbg.Columns("ApproveUserID").Caption = rl3("Nguoi_duyet") 'Người duyệt
        tdbg.Columns("ApprovedQuantity").Caption = rl3("So_luong_duyet") 'Số lượng duyệt
        tdbg.Columns("ObjectID").Caption = rl3("Doi_tuong") 'Đối tượng
        tdbg.Columns("InventoryID").Caption = rl3("Ma_hang") 'Mã hàng
        tdbg.Columns("InventoryName").Caption = rl3("Ten_hang_") 'Tên hàng
        tdbg.Columns("UnitID").Caption = rl3("DVT") 'ĐVT
        tdbg.Columns("POQuantity").Caption = rl3("SL_lap_don_hang") 'SL lập đơn hàng
        tdbg.Columns("Amount").Caption = rl3("Thanh_tien") 'Thành tiền
        '================================================================ 
        'mnuDelete.Text = rl3("_Xoa") '&Xóa
        'mnuFind.Text = rl3("Tim__kiem") 'Tìm &kiếm
        'mnuListAll.Text = rl3("_Liet_ke_tat_ca") '&Liệt kê tất cả
        'mnuSysInfo.Text = rl3("Thong_tin__he_thong") 'Thông tin &hệ thống
    End Sub

    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False

    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub 'set FilterText ="" thì thoát
            FilterChangeGrid(tdbg, sFilter)
            ReLoadTDBGrid()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message)
        End Try
    End Sub

    Private Sub tsbSysInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSysInfo.Click, tsmSysInfo.Click, mnsSysInfo.Click
        ShowSysInfoDialog(Me,tdbg.Columns(COL_CreateUserID).Text, tdbg.Columns(COL_CreateDate).Text, tdbg.Columns(COL_LastModifyUserID).Text, tdbg.Columns(COL_LastModifyDate).Text)
    End Sub

    Private Sub tsbClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub

    Private Sub LoadTDBGrid()
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        sFind = ""

        Dim sSQL As String = SQLStoreD12P2033()
        dtGrid = ReturnDataTable(sSQL)
        'Cách mới theo chuẩn: Tìm kiếm và Liệt kê tất cả luôn luôn sáng Khi(dt.Rows.Count > 0)
        gbEnabledUseFind = dtGrid.Rows.Count > 0
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString
        If strFind <> "" Then strFind &= " or Choose = True "
        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        CheckMenu(Me.Name, ToolStrip1, tdbg.RowCount, gbEnabledUseFind, True, ContextMenuStrip1)
        FooterTotalGrid(tdbg, COL_PRVoucherNo)
        FooterSum(tdbg, iColumnsSum, , True)
    End Sub

    Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbDelete.Click, tsmDelete.Click, mnsDelete.Click
        If D99C0008.MsgAskDelete = Windows.Forms.DialogResult.No Then Exit Sub
        If AllowDelate() = False Then Exit Sub

        Dim dt As DataTable = ReturnDataTable(SQLStoreD12P2032)
        If dt.Rows.Count > 0 Then
            D99C0008.MsgL3(ConvertVietwareFToUnicode(dt.Rows(0).Item("Message").ToString))
            If dt.Rows(0).Item("Status").ToString = "0" Then
                'RunAuditLog("AutoSelPurReq", "03", tdbg.Columns(COL_PRVoucherNo).Text, tdbg.Columns(COL_ObjectTypeID).Text, tdbg.Columns(COL_ObjectID).Text, tdbg.Columns(COL_UnitID).Text, tdbg.Columns(COL_POQuantity).Text)
                Lemon3.D91.RunAuditLog("12", "AutoSelPurReq", "03", tdbg.Columns(COL_PRVoucherNo).Text, tdbg.Columns(COL_ObjectTypeID).Text, tdbg.Columns(COL_ObjectID).Text, tdbg.Columns(COL_UnitID).Text, tdbg.Columns(COL_POQuantity).Text) 'ID 84813 29/02/2016
                LoadTDBGrid()
            End If
        End If
    End Sub

    Private WithEvents Finder As New D99C1001
    Dim gbEnabledUseFind As Boolean = False
    Private sFind As String = ""
    Public WriteOnly Property strNewFind() As String
        Set(ByVal Value As String)
            sFind = Value
            ReLoadTDBGrid() 'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
        End Set
    End Property

    Private Sub tsbFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbFind.Click, tsmFind.Click, mnsFind.Click
        gbEnabledUseFind = True
        '*****************************************
        'Chuẩn hóa D09U1111: Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()
        ResetTableForExcel(tdbg, dtCaptionCols)
        ShowFindDialogClient(Finder, ResetTableByGrid(usrOption, dtCaptionCols.DefaultView.ToTable), Me, "0", gbUnicode)
    End Sub

    'Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '    If ResultWhereClause Is Nothing Or ResultWhereClause.ToString = "" Then Exit Sub
    '    sFind = ResultWhereClause.ToString()
    '    ReLoadTDBGrid()
    'End Sub

    Private Sub tsbListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbListAll.Click, tsmListAll.Click, mnsListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

    Private Sub btnF12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnF12.Click
        'Chuẩn hóa D09U1111 B3: sự kiện hiển thị UserControl 
        giRefreshUserControl = -1
        usrOption.Location = New Point(tdbg.Left, btnF12.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_Amount, COL_ApprovedQuantity, COL_POQuantity
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Choose
                e.Handled = CheckKeyPress(e.KeyChar)
        End Select
    End Sub
End Class
