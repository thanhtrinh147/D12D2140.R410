Imports System.Text
'#-------------------------------------------------------------------------------------
'# Created Date: 05/03/2008 8:06:14 AM
'# Created User: Đỗ Minh Dũng
'# Modify Date: 05/03/2008 8:06:14 AM
'# Modify User: Đỗ Minh Dũng
'#-------------------------------------------------------------------------------------

Public Class D12F3120
	Dim report As D99C2003
	Dim dtCaptionCols As DataTable
    Dim sPOID As String = ""

    Dim eD12F3120Permission As EnumPermission
    Dim iPerD12F5558 As Integer = -1
    Dim iPerD12F3110 As Integer = -1
    Dim dtGrid As DataTable

#Region "Const of tdbgM"
    Private Const COLM_POID As Integer = 0              ' POID
    Private Const COLM_VoucherTypeID As Integer = 1     ' Loại phiếu
    Private Const COLM_VoucherNo As Integer = 2         ' Số phiếu 
    Private Const COLM_VoucherDate As Integer = 3       ' Ngày phiếu
    Private Const COLM_ObjectID As Integer = 4          ' Mã NCC
    Private Const COLM_ObjectName As Integer = 5        ' Tên NCC
    Private Const COLM_CurrencyID As Integer = 6        ' Loại tiền
    Private Const COLM_OAmount As Integer = 7           ' Nguyên tệ
    Private Const COLM_CAmount As Integer = 8           ' Quy đổi
    Private Const COLM_POStatus As Integer = 9          ' POStatus
    Private Const COLM_POStatusName As Integer = 10     ' Trạng thái
    Private Const COLM_VoucherDesc As Integer = 11      ' Diễn giải
    Private Const COLM_EmployeeName As Integer = 12     ' Người lập
    Private Const COLM_Pick As Integer = 13             ' Giữ chỗ
    Private Const COLM_PostedD06 As Integer = 14        ' Chuyển Module mua hàng
    Private Const COLM_CreateUserID As Integer = 15     ' CreateUserID
    Private Const COLM_LastModifyUserID As Integer = 16 ' LastModifyUserID
    Private Const COLM_CreateDate As Integer = 17       ' CreateDate
    Private Const COLM_LastModifyDate As Integer = 18   ' LastModifyDate
    Private Const COLM_Period As Integer = 19           ' Kỳ
    Private Const COLM_TypePostedD06 As Integer = 20    ' TypePostedD06
    Private Const COLM_D06VoucherNo As Integer = 21     ' D06VoucherNo
#End Region

#Region "Const of tdbgD"
    Private Const COLD_POItemID As Integer = 0      ' POItemID
    Private Const COLD_OrderNum As Integer = 1      ' STT
    Private Const COLD_InventoryID As Integer = 2   ' Mã hàng
    Private Const COLD_NoName01 As Integer = 3      ' NoName01
    Private Const COLD_InventoryName As Integer = 4 ' Tên hàng
    Private Const COLD_ExpectDate As Integer = 5    ' Ngày nhận hàng
    Private Const COLD_UnitID As Integer = 6        ' ĐVT
    Private Const COLD_OQuantity As Integer = 7     ' Số lượng
    Private Const COLD_CQuantity As Integer = 8     ' Số lượng QĐ
    Private Const COLD_UnitPrice As Integer = 9     ' Đơn giá
    Private Const COLD_OAmount As Integer = 10      ' Thành tiền NT
    Private Const COLD_CAmount As Integer = 11      ' Tổng tiền QĐ
    Private Const COLD_PRVoucherNo As Integer = 12  ' Yêu cầu mua hàng
#End Region

    Private Sub D12F3120_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        ElseIf e.KeyCode = Keys.F5 Then
            btnFilter_Click(Nothing, Nothing)
        End If
    End Sub


    Private Sub D12F3120_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        giPerF5700 = ReturnPermission("D12F5700")
        SetShortcutPopupMenu(Me, ToolStrip1, ContextMenuStrip1)
        Loadlanguage()
        SetBackColorObligatory()
        LoadTDBCombo()
        ResetColorGrid(tdbgM, 0, 1)
        ResetColorGrid(tdbgD)
        tdbgM_NumberFormat()
        tdbgD_NumberFormat()
        '********************************
        eD12F3120Permission = CType(ReturnPermission("D12F3120"), EnumPermission)
        iPerD12F5558 = ReturnPermission("D12F5558")
        iPerD12F3110 = ReturnPermission("D12F3110")
        tdbgD.Visible = False
        InputDateInTrueDBGrid(tdbgM, COLM_VoucherDate)
        tdbcPeriodFrom.Text = Format(giTranMonth, "00") & "/" & Format(giTranYear, "0000")
        tdbcPeriodTo.Text = Format(giTranMonth, "00") & "/" & Format(giTranYear, "0000")
        c1dateDateFrom.Value = Date.Today
        c1dateDateTo.Value = Date.Today
        InputbyUnicode(Me, gbUnicode)
        CheckMyMenu()
        '********************************
        If giPerF5700 <= 0 Then
            lblPerF5700.Text = rL3("MSG000005")
        Else
            lblPerF5700.Text = ""
        End If
        '********************************
        SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbgM_NumberFormat()
        tdbgM.Columns(COLM_OAmount).NumberFormat = DxxFormat.DecimalPlaces
        tdbgM.Columns(COLM_CAmount).NumberFormat = DxxFormat.D90_ConvertedDecimals
    End Sub

    Private Sub tdbgD_NumberFormat()
        tdbgD.Columns(COLD_OQuantity).NumberFormat = DxxFormat.D07_QuantityDecimals
        tdbgD.Columns(COLD_CQuantity).NumberFormat = DxxFormat.D07_QuantityDecimals
        tdbgD.Columns(COLD_UnitPrice).NumberFormat = DxxFormat.D07_UnitCostDecimals
        tdbgD.Columns(COLD_OAmount).NumberFormat = DxxFormat.DecimalPlaces
        tdbgD.Columns(COLD_CAmount).NumberFormat = DxxFormat.D90_ConvertedDecimals
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rL3("Danh_sach_don_dat_hang_-_D12F3120") & UnicodeCaption(gbUnicode) 'Danh sÀch ¢¥n ¢Æt hªng - D12F3120
        '================================================================ 
        lblVoucherNo.Text = rL3("So_phieu") 'Số phiếu
        '================================================================ 
        btnFilter.Text = rL3("Loc") & Space(1) & "(F5)" '&Lọc
        '================================================================ 
        chkIsTime.Text = rL3("Ky") 'Kỳ
        chkIsDate.Text = rL3("Ngay_phieu") 'Ngày phiếu
        '================================================================
        tdbcPeriodTo.Columns("Period").Caption = rL3("Ky") 'Kỳ
        tdbcPeriodFrom.Columns("Period").Caption = rL3("Ky") 'Kỳ
        '================================================================ 
        tdbgM.Columns("VoucherTypeID").Caption = rL3("Loai_phieu") 'Loại phiếu
        'tdbgM.Columns("VoucherTypeID").FooterText = rl3("Tong_")
        tdbgM.Columns("VoucherNo").Caption = rL3("So_phieu") 'Số phiếu 
        tdbgM.Columns("VoucherDate").Caption = rL3("Ngay_phieu") 'Ngày phiếu
        tdbgM.Columns("ObjectID").Caption = rL3("Ma_NCC") 'Mã NCC
        tdbgM.Columns("ObjectName").Caption = rL3("Ten_NCC") 'Tên NCC
        tdbgM.Columns("CurrencyID").Caption = rL3("Loai_tien") 'Loại tiền
        tdbgM.Columns("OAmount").Caption = rL3("Nguyen_te") 'Nguyên tệ
        tdbgM.Columns("CAmount").Caption = rL3("Quy_doi") 'Quy đổi
        tdbgM.Columns("POStatusName").Caption = rL3("Trang_thai") 'Trạng thái
        tdbgM.Columns("VoucherDesc").Caption = rL3("Dien_giai") 'Diễn giải
        tdbgM.Columns("EmployeeName").Caption = rL3("Nguoi_lap") 'Người lập
        tdbgM.Columns("Pick").Caption = rL3("Giu_cho") 'Giữ chỗ
        tdbgM.Columns("PostedD06").Caption = rL3("Chuyen_Module_mua_hang") 'Chuyển Module mua hàng
        tdbgM.Columns("Period").Caption = rL3("Ky") 'Kỳ
        '================================================================ 
        tdbgD.Columns("OrderNum").Caption = rL3("STT") 'STT
        tdbgD.Columns("InventoryID").Caption = rL3("_Ma_hang") 'Mã hàng
        tdbgD.Columns("InventoryName").Caption = rL3("Ten_hang") 'Tên hàng
        tdbgD.Columns("ExpectDate").Caption = rL3("Ngay_nhan_hang") 'Ngày nhận hàng
        tdbgD.Columns("UnitID").Caption = rL3("DVT") 'ĐVT
        tdbgD.Columns("OQuantity").Caption = rL3("So_luong") 'Số lượng
        tdbgD.Columns("CQuantity").Caption = rL3("So_luong_QD") 'Số lượng QĐ
        tdbgD.Columns("UnitPrice").Caption = rL3("Don_gia") 'Đơn giá
        tdbgD.Columns("OAmount").Caption = rL3("Thanh_tien_NT") 'Thành tiền NT
        tdbgD.Columns("CAmount").Caption = rL3("Thanh_tien_QD") 'Thành tiền QĐ
        tdbgD.Columns("PRVoucherNo").Caption = rL3("Yeu_cau_mua_hang") 'Yêu cầu mua hàng
        '================================================================ 
        'mnuEditVoucher.Text = rl3("Sua_so__phieu") 'rl3("Sua_so_phieu")
        tsbiPrintPO.Text = rL3("Don_dat_hang_D12")
        tsbiPrintPOList.Text = rL3("Danh_sach_don_dat_hang")
        tsmiPrintPO.Text = rL3("Don_dat_hang_D12")
        tsmiPrintPOList.Text = rL3("Danh_sach_don_dat_hang")
        mnsiPrintPO.Text = rL3("Don_dat_hang_D12")
        mnsiPrintPOList.Text = rL3("Danh_sach_don_dat_hang")
        tsmOrderApprove.Text = rL3("Duyet_don_dat_hang") 'Duyệt đơn đặt hàng
        mnsOrderApprove.Text = rL3("Duyet_don_dat_hang") 'Duyệt đơn đặt hàng
        tsmApprovedStatusDelete.Text = rL3("Huy_trang_thai_duyet") 'Hủy trạng thái duyệt
        mnsApprovedStatusDelete.Text = rL3("Huy_trang_thai_duyet") 'Hủy trạng thái duyệt
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcPeriodFrom
        sSQL = "Select REPLACE(STR(TranMonth, 2), ' ', '0') + '/' + STR(TranYear, 4) AS Period, TranMonth, TranYear,  TranYear * 100 + TranMonth As TempCol" & vbCrLf
        sSQL &= "From D12T9999 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where DivisionID = " & SQLString(gsDivisionID)
        sSQL &= "Order By TranYear DESC, TranMonth DESC"

        Dim dt As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(tdbcPeriodFrom, dt, gbUnicode)
        LoadDataSource(tdbcPeriodTo, dt.Copy, gbUnicode)
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcPeriodFrom.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPeriodTo.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateDateFrom.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateDateTo.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

#Region "Events tdbcPeriodFrom"

    Private Sub tdbcPeriodFrom_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPeriodFrom.LostFocus
        If tdbcPeriodFrom.FindStringExact(tdbcPeriodFrom.Text) = -1 Then tdbcPeriodFrom.Text = ""
    End Sub

#End Region

#Region "Events tdbcPeriodTo"

    Private Sub tdbcPeriodTo_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPeriodTo.LostFocus
        If tdbcPeriodTo.FindStringExact(tdbcPeriodTo.Text) = -1 Then tdbcPeriodTo.Text = ""
    End Sub

#End Region

    Private Sub chkIsTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIsTime.CheckedChanged
        tdbcPeriodFrom.Enabled = chkIsTime.Checked
        tdbcPeriodTo.Enabled = tdbcPeriodFrom.Enabled
    End Sub

    Private Sub chkIsDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIsDate.CheckedChanged
        c1dateDateFrom.Enabled = chkIsDate.Checked
        c1dateDateTo.Enabled = c1dateDateFrom.Enabled
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        If AllowSave() = False Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        sFind = ""
        LoadTDBGridMaster()
        If mnsShowDetail.Checked Then LoadTDBGridDetail()
        Me.Cursor = Cursors.Default
    End Sub

    Private Function GetSumOfColumn(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal iCol As Integer) As Double
        Dim dblSum As Double = 0
        For i As Integer = 0 To c1Grid.RowCount - 1
            dblSum += Number(c1Grid(i, iCol))
        Next i

        Return dblSum
    End Function

    Private Sub CheckMyMenu()
        CheckMenu(Me.Name, ToolStrip1, tdbgM.RowCount, gbEnabledUseFind, True, ContextMenuStrip1)
        mnsEditVoucher.Enabled = iPerD12F5558 > 2 And Not gbClosed And tdbgM.RowCount > 0 AndAlso Not L3Bool(tdbgM(tdbgM.Row, COLM_PostedD06))
        tsmEditVoucher.Enabled = mnsEditVoucher.Enabled
        mnsApprovedStatusDelete.Enabled = iPerD12F3110 > 1 And tdbgM.RowCount > 0 AndAlso Not L3Bool(tdbgM(tdbgM.Row, COLM_PostedD06))
        tsmApprovedStatusDelete.Enabled = mnsApprovedStatusDelete.Enabled
        mnsOrderApprove.Enabled = iPerD12F3110 > 1 And tdbgM.RowCount > 0 AndAlso Not L3Bool(tdbgM(tdbgM.Row, COLM_PostedD06))
        tsmOrderApprove.Enabled = mnsOrderApprove.Enabled
        '====Bổ sung 06/08/2012 - ID 49991=================================================
        mnsDelete.Enabled = mnsDelete.Enabled AndAlso Not L3Bool(tdbgM(tdbgM.Row, COLM_PostedD06))
        tsbDelete.Enabled = mnsDelete.Enabled
        tsmDelete.Enabled = mnsDelete.Enabled
    End Sub

    Private Sub LoadTDBGridMaster(Optional ByVal bFlagAdd As Boolean = False, Optional ByVal sKey As String = "")
        dtGrid = ReturnDataTable(SQLStoreD12P3120)
        If bFlagAdd Then
            ResetFilter(tdbgM, sFilter, bRefreshFilter)
            sFind = ""
        End If
        gbEnabledUseFind = dtGrid.Rows.Count > 0

        If giPerF5700 = 0 Or D12Options.ViewMyVoucher Then dtGrid = ReturnTableFilter(dtGrid, "CreateUserID = " & SQLString(gsUserID), True)
        LoadDataSource(tdbgM, dtGrid, gbUnicode)
        ReLoadTDBGrid()

        If sKey <> "" Then 'Khi Thêm mới hoặc Sửa đều thực thi
            Dim dt As DataTable = dtGrid.DefaultView.ToTable
            Dim dr() As DataRow = dt.Select(tdbgM.Columns(COLM_POID).DataField & "=" & SQLString(sKey), dt.DefaultView.Sort)
            If dr.Length > 0 Then tdbgM.Row = dt.Rows.IndexOf(dr(0))
            If Not tdbgM.Focused Then tdbgM.Focus()
        End If
    End Sub

    Private Sub LoadTDBGridDetail()
        Dim sSQL As String = ""
        sSQL &= " SELECT     A.POItemID, A.OrderNum, A.InventoryID, A.InventoryName" & UnicodeJoin(gbUnicode) & ", " & vbCrLf
        sSQL &= " A.UnitID, A.ExpectDate, A.OQuantity, A.CQuantity, A.UnitPrice," & vbCrLf
        sSQL &= " A.OAmount, A.CAmount, B.PRVoucherNo " & vbCrLf
        sSQL &= " FROM 	D12T2060 A WITH(NOLOCK) " & vbCrLf
        sSQL &= " LEFT JOIN D12T2010 B WITH(NOLOCK) " & vbCrLf
        sSQL &= " ON A.PRID = B.PRID AND A.PRTransactionID = B.PRTransactionID" & vbCrLf
        sSQL &= " WHERE A.POID=" & SQLString(tdbgM.Columns(COLM_POID).Text) & vbCrLf

        LoadDataSource(tdbgD, sSQL, gbUnicode)

        tdbgD.Columns(COLD_OQuantity).FooterText = Format(GetSumOfColumn(tdbgD, COLD_OQuantity), DxxFormat.D07_QuantityDecimals)
        tdbgD.Columns(COLD_CQuantity).FooterText = Format(GetSumOfColumn(tdbgD, COLD_CQuantity), DxxFormat.D07_QuantityDecimals)
        tdbgD.Columns(COLD_UnitPrice).FooterText = Format(GetSumOfColumn(tdbgD, COLD_UnitPrice), DxxFormat.D07_UnitCostDecimals)
        tdbgD.Columns(COLD_OAmount).FooterText = Format(GetSumOfColumn(tdbgD, COLD_OAmount), DxxFormat.DecimalPlaces)
        tdbgD.Columns(COLD_CAmount).FooterText = Format(GetSumOfColumn(tdbgD, COLD_CAmount), DxxFormat.D90_ConvertedDecimals)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD06T2520
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 19/06/2008 09:11:49
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD06T2520() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D06T2520"
        sSQL &= " Where "
        sSQL &= "POID = " & SQLString(tdbgM.Columns(COLM_POID).Text)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD06T2510
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 19/06/2008 09:12:48
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD06T2510() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D06T2510"
        sSQL &= " Where "
        sSQL &= "POID = " & SQLString(tdbgM.Columns(COLM_POID).Text)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD06T2420
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 05/06/2009 11:57:03
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD06T2420() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D06T2420"
        sSQL &= " Where "
        sSQL &= "ContractVoucherID = " & SQLString(tdbgM.Columns(COLM_POID).Text)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD06T2410
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 05/06/2009 11:57:56
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD06T2410() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D06T2410"
        sSQL &= " Where "
        sSQL &= "ContractVoucherID = " & SQLString(tdbgM.Columns(COLM_POID).Text)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD12T2060
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 05/03/2008 10:56:06
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD12T2060() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D12T2060"
        sSQL &= " Where "
        sSQL &= "POID = " & SQLString(tdbgM.Columns(COLM_POID).Text)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD12P3111
    '# Created User: MINHTAM
    '# Created Date: 09/09/2014 08:59:10
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD12P3111() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa du lieu" & vbCrlf)
        sSQL &= "Exec D12P3111 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(tdbgM.Columns(COLM_POID).Text) & vbCrLf 'POID, varchar[20], NOT NULL

        ' 2012-03-09 Bổ sung đoạn lệnh khi xóa phiếu
        ' ID = 47199
        sSQL &= SQLStoreD91P9113("D12T2050", tdbgM.Columns(COLM_VoucherNo).Text) & vbCrLf

        If tdbgM.Columns(COLM_PostedD06).Text = "1" Then
            If tdbgM.Columns(COLM_TypePostedD06).Text = "1" Then
                sSQL &= SQLStoreD91P9113("D06T2410", tdbgM.Columns(COLM_D06VoucherNo).Text) & vbCrLf
            ElseIf tdbgM.Columns(COLM_TypePostedD06).Text = "0" Then
                sSQL &= SQLStoreD91P9113("D06T2510", tdbgM.Columns(COLM_D06VoucherNo).Text) & vbCrLf
            End If
        End If

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD91P9113
    '# Created User: Tien Dau
    '# Created Date: 09/03/2012 01:29:59
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD91P9113(ByVal sVoucherTableName As String, ByVal sVoucherNo As String) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D91P9113 "
        sSQL &= SQLString(sVoucherTableName) & COMMA 'VoucherTableName, varchar[50], NOT NULL
        sSQL &= SQLString(sVoucherNo) 'VoucherNo, varchar[50], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD12P3120
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 20/01/2011 03:18:28
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD12P3120() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D12P3120 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, smallint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, char, NOT NULL
        sSQL &= SQLString(sFind) & COMMA 'sFind, varchar[8000], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(txtVoucherNo.Text) & COMMA 'VoucherNo, varchar[20], NOT NULL

        If chkIsDate.Checked AndAlso chkIsTime.Checked = False Then
            sSQL &= SQLNumber(1) & COMMA 'IsDate, tinyint, NOT NULL
        ElseIf chkIsDate.Checked = False AndAlso chkIsTime.Checked Then
            sSQL &= SQLNumber(2) & COMMA 'IsDate, tinyint, NOT NULL
        ElseIf chkIsDate.Checked AndAlso chkIsTime.Checked Then
            sSQL &= SQLNumber(3) & COMMA 'IsDate, tinyint, NOT NULL
        ElseIf chkIsDate.Checked = False AndAlso chkIsTime.Checked = False Then
            sSQL &= SQLNumber(4) & COMMA 'IsDate, tinyint, NOT NULL
        End If

        sSQL &= SQLDateSave(c1dateDateFrom.Text) & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateDateTo.Text) & COMMA 'DateTo, datetime, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodFrom.Columns("TranMonth").Text) & COMMA 'FromMonth, int, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodFrom.Columns("TranYear").Text) & COMMA 'FromYear, int, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodTo.Columns("TranMonth").Text) & COMMA 'ToMonth, int, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodTo.Columns("TranYear").Text) & COMMA 'ToYear, int, NOT NULL
        sSQL &= SQLNumber(gbUnicode)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD12P3121
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 21/01/2011 09:25:46
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD12P3121(ByVal sPOID As String) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D12P3121 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(sPOID) & COMMA 'POID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, char, NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(txtVoucherNo.Text) & COMMA 'VoucherNo, varchar[20], NOT NULL
        If chkIsDate.Checked AndAlso chkIsTime.Checked = False Then
            sSQL &= SQLNumber(1) & COMMA 'IsDate, tinyint, NOT NULL
        ElseIf chkIsDate.Checked = False AndAlso chkIsTime.Checked Then
            sSQL &= SQLNumber(2) & COMMA 'IsDate, tinyint, NOT NULL
        ElseIf chkIsDate.Checked AndAlso chkIsTime.Checked Then
            sSQL &= SQLNumber(3) & COMMA 'IsDate, tinyint, NOT NULL
        ElseIf chkIsDate.Checked = False AndAlso chkIsTime.Checked = False Then
            sSQL &= SQLNumber(4) & COMMA 'IsDate, tinyint, NOT NULL
        End If
        sSQL &= SQLDateSave(c1dateDateFrom.Text) & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave(c1dateDateTo.Text) & COMMA 'DateTo, datetime, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodFrom.Columns("TranMonth").Text) & COMMA 'FromMonth, int, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodFrom.Columns("TranYear").Text) & COMMA 'FromYear, int, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodTo.Columns("TranMonth").Text) & COMMA 'ToMonth, int, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodTo.Columns("TranYear").Text) & COMMA 'ToYear, int, NOT NULL
        sSQL &= SQLNumber(gbUnicode)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD12P3130
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 05/03/2008 08:37:05
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD12P3130(ByVal sMode As String) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D12P3130 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbgM.Columns(COLM_POID).Text) & COMMA 'POID, varchar[20], NOT NULL
        sSQL &= SQLString(sMode) & COMMA 'Mode, char, NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, char, NOT NULL
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD12T2050
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 07/03/2008 10:30:13
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD12T2050() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D12T2050 Set ")

        sSQL.Append("POStatus = " & SQLString("4")) 'char, NOT NULL

        sSQL.Append(" Where ")
        sSQL.Append("POID = " & SQLString(tdbgM.Columns(COLM_POID).Text))

        Return sSQL
    End Function

    Private Function AllowSave() As Boolean
        If chkIsTime.Checked Then
            If tdbcPeriodFrom.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rl3("Ky"))
                tdbcPeriodFrom.Focus()
                Return False
            End If
            If tdbcPeriodTo.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose(rl3("Ky"))
                tdbcPeriodTo.Focus()
                Return False
            End If

            If L3Int(tdbcPeriodFrom.Columns("TempCol").Text) > L3Int(tdbcPeriodTo.Columns("TempCol").Text) Then
                D99C0008.MsgL3(rl3("Ky_khong_hop_le"))
                tdbcPeriodFrom.Focus()
                Return False
            End If
        End If

        If chkIsDate.Checked Then
            If c1dateDateFrom.Value.ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ngay_phieu"))
                c1dateDateFrom.Focus()
                Return False
            End If
            If c1dateDateTo.Value.ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ngay_phieu"))
                c1dateDateTo.Focus()
                Return False
            End If

            If CDate(SQLDateShow(c1dateDateFrom.Text)) > CDate(SQLDateShow(c1dateDateTo.Text)) Then
                D99C0008.MsgL3(rl3("Ngay_khong_hop_le"))
                c1dateDateFrom.Focus()
                Return False
            End If
        End If

        Return True
    End Function

    Dim bRowColChange As Boolean
    Private Sub tdbgM_BeforeRowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles tdbgM.BeforeRowColChange
        bRowColChange = True
    End Sub

    Private Sub tdbgM_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbgM.RowColChange
  If e IsNot Nothing AndAlso e.LastRow = -1 Then Exit Sub
        If tdbgM.RowCount <= 0 Then Exit Sub
        If e.LastRow = tdbgM.Row Then Exit Sub
        If Not bRowColChange Then Exit Sub
        CheckMyMenu()
        If bRowColChange Then bRowColChange = False
        If tdbgD.Visible Then LoadTDBGridDetail()
    End Sub


#Region "Active Find - List All (Client)"
    'Dim dtCaptionCols As DataTable
    Private WithEvents Finder As New D99C1001
	Dim gbEnabledUseFind As Boolean = False

    Private sFind As String = ""
	Public WriteOnly Property strNewFind() As String
		Set(ByVal Value As String)
			sFind = Value
			ReLoadTDBGrid()'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
		End Set
	End Property

    Private Sub tsbFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbFind.Click, tsmFind.Click, mnsFind.Click
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbgM.UpdateData()
        'Những cột bắt buộc nhập
        Dim Arr As New ArrayList
        AddColVisible(tdbgM, SPLIT0, Arr, , False, False, gbUnicode)
        AddColVisible(tdbgM, SPLIT1, Arr, , False, False, gbUnicode)
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbgM, Arr)

        ShowFindDialogClient(Finder, dtCaptionCols, Me, "0", gbUnicode)
    End Sub

    'Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '    If ResultWhereClause Is Nothing Or ResultWhereClause.ToString = "" Then Exit Sub
    '    sFind = ResultWhereClause.ToString()
    '    ReLoadTDBGrid()
    'End Sub

    Private Sub tsbListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbListAll.Click, tsmListAll.Click, mnsListAll.Click
        sFind = ""
        ResetFilter(tdbgM, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString
        dtGrid.DefaultView.RowFilter = strFind
        ' Nếu lưới có Group thì bổ sung thêm 2 đoạn lệnh sau:
        'tdbg.WrapCellPointer = tdbg.RowCount > 0
        ResetGrid()
        If mnsShowDetail.Checked Then LoadTDBGridDetail()
    End Sub

    Private Sub ResetGrid()
        CheckMyMenu()
        FooterTotalGrid(tdbgM, COLM_VoucherNo)
        FooterSumNew(tdbgM, COLM_OAmount, COLM_CAmount)
    End Sub
#End Region

#Region "Active FilterChange "
    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False

    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbgM.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub 'set FilterText ="" thì thoát
            FilterChangeGrid(tdbgM, sFilter)
            ReLoadTDBGrid()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message)
        End Try
    End Sub

#End Region

    Dim iHeight As Integer = 0 ' Lấy tọa độ Y của chuột click tới
    Private Sub tdbg_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbgM.MouseClick
        iHeight = e.Location.Y
    End Sub

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbgM.DoubleClick
        If iHeight <= tdbgM.Splits(0).ColumnCaptionHeight OrElse tdbgM.FilterActive Then Exit Sub
        If mnsEdit.Enabled Then
            mnsEdit_Click(Nothing, Nothing)
        ElseIf mnsView.Enabled Then
            mnsView_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbgM.KeyDown
        If e.KeyCode = Keys.Enter Then tdbg_DoubleClick(Nothing, Nothing)
        HotKeyCtrlVOnGrid(tdbgM, e)
    End Sub

    Private Sub mnsAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnsAdd.Click, tsmAdd.Click, tsbAdd.Click
        Dim f As New D12F3100
        With f
            .ShowDialog()
            .Dispose()
        End With

        LoadTDBGridMaster(True)
    End Sub

    'không cho nhấn giá trị trên cột Filter bar đối với cột STT
    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbgM.KeyPress
        Select Case tdbgM.Col
            Case COLM_Pick, COLM_PostedD06 'Chặn Ctrl + V trên cột Check
                e.Handled = CheckKeyPress(e.KeyChar)
            Case COLM_CAmount, COLM_OAmount
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    Private Sub mnsApprovedStatusDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnsApprovedStatusDelete.Click, tsmApprovedStatusDelete.Click
        If D99C0008.Msg(rl3("Ban_co_muon_huy_trang_thai_duyet_khong"), rl3("Thong_bao"), L3MessageBoxButtons.YesNo, L3MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub

        If Format(giTranMonth, "00") & "/" & Format(giTranYear, "0000") <> tdbgM.Columns(COLM_Period).Text Then
            D99C0008.MsgL3(rl3("MSG000001"))
            Exit Sub
        End If

        If giPerF5700 = 1 Or giPerF5700 = 2 Then
            If tdbgM.Columns(COLM_CreateUserID).Text <> gsUserID Then
                D99C0008.MsgL3(rl3("MSG000006"))
                Exit Sub
            End If
        End If

        If CheckStore(SQLStoreD12P3130("E")) = False Then Exit Sub

        If ExecuteSQL(SQLUpdateD12T2050.ToString) = True Then
            D99C0008.Msg(rl3("Huy_trang_thai_duyet_thanh_congU"), rl3("Thong_bao"), L3MessageBoxButtons.OK)
            Dim iBookmark As Integer = tdbgM.Bookmark
            LoadTDBGridMaster()
            tdbgM.Bookmark = iBookmark
        Else
            D99C0008.Msg(rl3("Huy_trang_thai_duyet_khong_thanh_congU"), rl3("Thong_bao"), L3MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub mnsDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnsDelete.Click, tsmDelete.Click, tsbDelete.Click
        If AskDelete() = Windows.Forms.DialogResult.No Then Exit Sub

        If Format(giTranMonth, "00") & "/" & Format(giTranYear, "0000") <> tdbgM.Columns(COLM_Period).Text Then
            D99C0008.MsgL3(rl3("MSG000001"))
            Exit Sub
        End If

        If giPerF5700 = 1 Or giPerF5700 = 2 Then
            If tdbgM.Columns(COLM_CreateUserID).Text <> gsUserID Then
                D99C0008.MsgL3(rl3("MSG000006"))
                Exit Sub
            End If
        End If

        If giPerF5700 = 1 Or giPerF5700 = 2 Or giPerF5700 = 3 Then
            If tdbgM.Columns(COLM_CreateUserID).Text <> gsUserID Then
                D99C0008.MsgL3(rl3("MSG000007"))
                Exit Sub
            End If
        End If

        If CheckStore(SQLStoreD12P3130("D")) = False Then Exit Sub

        Dim sSQL As String = SQLStoreD12P3111() & vbCrLf

        Dim bResult As Boolean
        bResult = ExecuteSQL(sSQL)
        If bResult Then
            DeleteOK()
            'RunAuditLog("AutoSetPurReq", "03", tdbgM.Columns(COLM_VoucherNo).Text + " " + tdbgM.Columns(COLM_VoucherDate).Text, tdbgM.Columns(COLM_VoucherDesc).Text, "", "", "")
            Lemon3.D91.RunAuditLog("12", "AutoSetPurReq", "03", tdbgM.Columns(COLM_VoucherNo).Text + " " + tdbgM.Columns(COLM_VoucherDate).Text, tdbgM.Columns(COLM_VoucherDesc).Text, "", "", "") 'ID 84813 29/02/2016
            Dim iBookmark As Integer = -1
            If tdbgM.Bookmark - 1 > 0 Then iBookmark = tdbgM.Bookmark - 1
            LoadTDBGridMaster()
            If iBookmark > -1 Then tdbgM.Bookmark = iBookmark
        Else
            DeleteNotOK()
        End If
    End Sub

    Private Sub mnsEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnsEdit.Click, tsmEdit.Click, tsbEdit.Click
        If Format(giTranMonth, "00") & "/" & Format(giTranYear, "0000") <> tdbgM.Columns(COLM_Period).Text Then
            D99C0008.MsgL3(rl3("MSG000001"))
            Exit Sub
        End If

        If giPerF5700 = 1 Or giPerF5700 = 2 Then
            If tdbgM.Columns(COLM_CreateUserID).Text <> gsUserID Then
                D99C0008.MsgL3(rl3("MSG000006"))
                Exit Sub
            End If
        End If

        If CheckStore(SQLStoreD12P3130("E")) = False Then Exit Sub

        Dim f As New D12F3110
        With f
            .POID = tdbgM.Columns(COLM_POID).Text
            .FormState = EnumFormState.FormEdit
            .ShowDialog()
            .Dispose()
        End With

        LoadTDBGridMaster(, tdbgM.Columns(COLM_POID).Text)

    End Sub

    Private Sub mnsEditVoucher_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnsEditVoucher.Click, tsmEditVoucher.Click
        If Format(giTranMonth, "00") & "/" & Format(giTranYear, "0000") <> tdbgM.Columns(COLM_Period).Text Then
            D99C0008.MsgL3(rl3("MSG000001"))
            Exit Sub
        End If

        If giPerF5700 = 1 Or giPerF5700 = 2 Then
            If tdbgM.Columns(COLM_CreateUserID).Text <> gsUserID Then
                D99C0008.MsgL3(rl3("MSG000006"))
                Exit Sub
            End If
        End If

        If CheckStore(SQLStoreD12P3130("E")) = False Then Exit Sub
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D12F5558")
        SetProperties(arrPro, "VoucherID", tdbgM.Columns(COLM_POID).Text)
        SetProperties(arrPro, "Mode", 0)
        SetProperties(arrPro, "TableName", "D12T2050")
        SetProperties(arrPro, "ModuleID", D12)
        SetProperties(arrPro, "OldVoucherNo", tdbgM.Columns(COLM_VoucherNo).Text)
        Dim frm As Form = CallFormShowDialog("D91D0640", "D91F5558", arrPro)
        Dim sNew As String = GetProperties(frm, "NewVoucherNo").ToString
        If sNew <> "" Then
           LoadTDBGridMaster(, tdbgM.Columns(COLM_POID).Text)
        End If
    End Sub

    Private Sub mnsOrderApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnsOrderApprove.Click, tsmOrderApprove.Click
        If Format(giTranMonth, "00") & "/" & Format(giTranYear, "0000") <> tdbgM.Columns(COLM_Period).Text Then
            D99C0008.MsgL3(rl3("MSG000001"))
            Exit Sub
        End If

        If giPerF5700 = 1 Or giPerF5700 = 2 Then
            If tdbgM.Columns(COLM_CreateUserID).Text <> gsUserID Then
                D99C0008.MsgL3(rl3("MSG000006"))
                Exit Sub
            End If
        End If

        If CheckStore(SQLStoreD12P3130("E")) = False Then Exit Sub

        Dim fb As New D12F3110
        With fb

            .POID = tdbgM.Columns(COLM_POID).Text
            .Status = "Status"
            .FormState = EnumFormState.FormEdit
            .ShowDialog()
            If .bSaved Then
                LoadTDBGridMaster(, tdbgM.Columns(COLM_POID).Text)
            End If
            .Dispose()
        End With
    End Sub

    Private Sub mnsiPrintPO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnsiPrintPO.Click, tsbiPrintPO.Click, tsmiPrintPO.Click
        If Not AllowNewD99C2003(report, Me) Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        '************************************
        Dim conn As New SqlConnection(gsConnectionString)
        Dim sReportName As String = "D12R3121"
        Dim sSubReportName As String = "D06R0025"
        Dim sReportCaption As String = ""
        Dim sSQL As String = ""
        Dim sSQLSub As String = ""

        Dim sReportPath As String = ""
        Dim sReportTitle As String = "" 'Thêm biến
        Dim sCustomReport As String = ""

        sReportName = GetReportPath(Me.Name, sReportName, sCustomReport, sReportPath, sReportTitle)
        If sReportName = "" Then Me.Cursor = Cursors.Default : Exit Sub

        sReportCaption = rl3("Don_dat_hangW") & " - " & sReportName

        sSQL &= SQLStoreD12P3121(tdbgM.Columns(COLM_POID).Text)
        sSQLSub = "SELECT * FROM D91V0016 Where DivisionID=" & SQLString(gsDivisionID)
        UnicodeSubReport(sSubReportName, sSQLSub, gsDivisionID, gbUnicode)
        With report
            .OpenConnection(conn)
            .AddSub(sSQLSub, sSubReportName & ".rpt")
            .AddMain(sSQL)
            .PrintReport(sReportPath, sReportCaption)
        End With
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mnsiPrintPOList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnsiPrintPOList.Click, tsbiPrintPOList.Click, tsmiPrintPOList.Click
        If Not AllowNewD99C2003(report, Me) Then Exit Sub
        If tdbgM.RowCount <= 0 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        '************************************
        Dim conn As New SqlConnection(gsConnectionString)
        Dim sReportName As String = "D12R3120"
        Dim sSubReportName As String = "D06R0025"
        Dim sReportCaption As String = ""
        Dim sSQL As String = ""
        Dim sSQLSub As String = ""

        Dim sReportPath As String = ""
        Dim sReportTitle As String = "" 'Thêm biến
        Dim sCustomReport As String = ""

        sReportName = GetReportPath("D12F3120B", sReportName, sCustomReport, sReportPath, sReportTitle)
        If sReportName = "" Then Me.Cursor = Cursors.Default : Exit Sub
        sReportCaption = rl3("Danh_sach_don_dat_hangW") & " - " & sReportName

        sSQL &= SQLStoreD12P3121("%")
        sSQLSub = "SELECT * FROM D91V0016 Where DivisionID=" & SQLString(gsDivisionID)
        UnicodeSubReport(sSubReportName, sSQLSub, gsDivisionID, gbUnicode)
        With report
            .OpenConnection(conn)
            .AddSub(sSQLSub, sSubReportName & ".rpt")
            .AddMain(sSQL)
            .PrintReport(sReportPath, sReportCaption)
        End With
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mnsShowDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnsShowDetail.Click, tsmShowDetail.Click
        If mnsShowDetail.Checked = False Then
            mnsShowDetail.Checked = True

            tdbgM.Size = New Size(tdbgM.Size.Width, (tdbgM.Size.Height - (tdbgD.Size.Height + 10)))
            tdbgD.Visible = True
            LoadTDBGridDetail()
        Else
            mnsShowDetail.Checked = False
            tdbgM.Size = New Size(tdbgM.Size.Width, (tdbgM.Size.Height + (tdbgD.Size.Height + 10)))
            tdbgD.Visible = False
        End If
    End Sub

    Private Sub mnsView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnsView.Click, tsbView.Click, tsmView.Click
        Dim f As New D12F3110
        With f
            .POID = tdbgM.Columns(COLM_POID).Text
            .FormState = EnumFormState.FormView
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub tsbSysInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSysInfo.Click, tsmSysInfo.Click, mnsSysInfo.Click
        ShowSysInfoDialog(Me,tdbgM.Columns(COLM_CreateUserID).Text, tdbgM.Columns(COLM_CreateDate).Text, tdbgM.Columns(COLM_LastModifyUserID).Text, tdbgM.Columns(COLM_LastModifyDate).Text)
    End Sub

    Private Sub tsbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClose.Click
        Me.Close()
    End Sub

End Class