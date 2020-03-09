'*** Mô tả hoạt động form
'Trên lưới Master, kỳ thay đổi k làm mất dòng đã check chọn. Nhưng có hay k có nhà cung cấp, thay đổi lựa chọn đó
'thì làm mất dòng đã check chọn, nhưng nếu dòng đã check chọn có trong danh sách mới thì nó vẫn được check chọn.

'Kết quả Tìm kiếm vẫn giữ lại dòng đã check chọn.
'***
Imports System.Text
'#-------------------------------------------------------------------------------------
'# Created Date: 
'# Created User: Đỗ Minh Dũng
'# Modify Date: 05/08/2008 10:19:38 AM
'# Modify User: Đỗ Minh Dũng
'#-------------------------------------------------------------------------------------
Public Class D12F3030

'#Region "Const of tdbgM - Total of Columns: 6"
'    Private Const COLM_Choose As String = "Choose"           ' Chọn
'    Private Const COLM_PRVoucherNo As String = "PRVoucherNo" ' Số chứng từ
'    Private Const COLM_PRDate As String = "PRDate"           ' Ngày yêu cầu
'    Private Const COLM_BuyerName As String = "BuyerName"     ' Người yêu cầu
'    Private Const COLM_Note As String = "Note"               ' Diễn giải
'    Private Const COLM_PRID As String = "PRID"               ' PRID
'#End Region
    
#Region "Const of tdbgM - Total of Columns: 7"
    Private Const COLM_Choose As String = "Choose"           ' Chọn
    Private Const COLM_PRVoucherNo As String = "PRVoucherNo" ' Số chứng từ
    Private Const COLM_PRDate As String = "PRDate"           ' Ngày yêu cầu
    Private Const COLM_ApproveDate As String = "ApproveDate" ' Ngày duyệt yêu cầu '119954 - 27 June 2019
    Private Const COLM_BuyerName As String = "BuyerName"     ' Người yêu cầu
    Private Const COLM_Note As String = "Note"               ' Diễn giải
    Private Const COLM_PRID As String = "PRID"               ' PRID
#End Region


#Region "Const of tdbgD - Total of Columns: 65"
    Private Const COLD_Choose As String = "Choose"                     ' Chọn
    Private Const COLD_PRTransactionID As String = "PRTransactionID"   ' PRTransactionID
    Private Const COLD_InventoryID As String = "InventoryID"           ' Mã hàng
    Private Const COLD_InventoryName As String = "InventoryName"       ' Tên hàng
    Private Const COLD_Spec01ID As String = "Spec01ID"                 ' Spec01ID
    Private Const COLD_Spec02ID As String = "Spec02ID"                 ' Spec02ID
    Private Const COLD_Spec03ID As String = "Spec03ID"                 ' Spec03ID
    Private Const COLD_Spec04ID As String = "Spec04ID"                 ' Spec04ID
    Private Const COLD_Spec05ID As String = "Spec05ID"                 ' Spec05ID
    Private Const COLD_Spec06ID As String = "Spec06ID"                 ' Spec06ID
    Private Const COLD_Spec07ID As String = "Spec07ID"                 ' Spec07ID
    Private Const COLD_Spec08ID As String = "Spec08ID"                 ' Spec08ID
    Private Const COLD_Spec09ID As String = "Spec09ID"                 ' Spec09ID
    Private Const COLD_Spec10ID As String = "Spec10ID"                 ' Spec10ID
    Private Const COLD_UnitID As String = "UnitID"                     ' ĐVT
    Private Const COLD_ApprovedQuantity As String = "ApprovedQuantity" ' SL Yêu cầu
    Private Const COLD_POQuantity As String = "POQuantity"             ' SL được phép lập đơn đặt hàng
    Private Const COLD_DExpectDate As String = "DExpectDate"           ' Ngày nhận hàng (YCMH)
    Private Const COLD_DetailDesc As String = "DetailDesc"             ' Diễn giải
    Private Const COLD_ICode01Name As String = "ICode01Name"           ' ICode01Name
    Private Const COLD_ICode02Name As String = "ICode02Name"           ' ICode02Name
    Private Const COLD_ICode03Name As String = "ICode03Name"           ' ICode03Name
    Private Const COLD_ICode04Name As String = "ICode04Name"           ' ICode04Name
    Private Const COLD_ICode05Name As String = "ICode05Name"           ' ICode05Name
    Private Const COLD_ICode06Name As String = "ICode06Name"           ' ICode06Name
    Private Const COLD_ICode07Name As String = "ICode07Name"           ' ICode07Name
    Private Const COLD_ICode08Name As String = "ICode08Name"           ' ICode08Name
    Private Const COLD_ICode09Name As String = "ICode09Name"           ' ICode09Name
    Private Const COLD_ICode10Name As String = "ICode10Name"           ' ICode10Name
    Private Const COLD_ICode11Name As String = "ICode11Name"           ' ICode11Name
    Private Const COLD_ICode12Name As String = "ICode12Name"           ' ICode12Name
    Private Const COLD_ICode13Name As String = "ICode13Name"           ' ICode13Name
    Private Const COLD_ICode14Name As String = "ICode14Name"           ' ICode14Name
    Private Const COLD_ICode15Name As String = "ICode15Name"           ' ICode15Name
    Private Const COLD_ICode16Name As String = "ICode16Name"           ' ICode16Name
    Private Const COLD_ICode17Name As String = "ICode17Name"           ' ICode17Name
    Private Const COLD_ICode18Name As String = "ICode18Name"           ' ICode18Name
    Private Const COLD_ICode19Name As String = "ICode19Name"           ' ICode19Name
    Private Const COLD_ICode20Name As String = "ICode20Name"           ' ICode20Name
    Private Const COLD_ProjectID As String = "ProjectID"               ' Mã dự án
    Private Const COLD_ProjectName As String = "ProjectName"           ' Tên dự án
    Private Const COLD_TaskID As String = "TaskID"                     ' Mã hạng mục
    Private Const COLD_TaskName As String = "TaskName"                 ' Tên hạng mục
    Private Const COLD_PRVoucherNo As String = "PRVoucherNo"           ' Số phiếu YCMH
    Private Const COLD_MPSVoucherNo As String = "MPSVoucherNo"         ' Kế hoạch sản xuất
    Private Const COLD_PeriodID As String = "PeriodID"                 ' Kỳ sản xuất
    Private Const COLD_ProductID As String = "ProductID"               ' Sản phẩm
    Private Const COLD_SaleOrderNo As String = "SaleOrderNo"           ' Đơn hàng
    Private Const COLD_DeliveryDate As String = "DeliveryDate"         ' Ngày giao hàng (Đơn hàng)
    Private Const COLD_NRef1 As String = "NRef1"                       ' NRef1
    Private Const COLD_NRef2 As String = "NRef2"                       ' NRef2
    Private Const COLD_NRef3 As String = "NRef3"                       ' NRef3
    Private Const COLD_NRef4 As String = "NRef4"                       ' NRef4
    Private Const COLD_NRef5 As String = "NRef5"                       ' NRef5
    Private Const COLD_VRef1 As String = "VRef1"                       ' VRef1
    Private Const COLD_VRef2 As String = "VRef2"                       ' VRef2
    Private Const COLD_VRef3 As String = "VRef3"                       ' VRef3
    Private Const COLD_VRef4 As String = "VRef4"                       ' VRef4
    Private Const COLD_VRef5 As String = "VRef5"                       ' VRef5
    Private Const COLD_DRef1 As String = "DRef1"                       ' DRef1
    Private Const COLD_DRef2 As String = "DRef2"                       ' DRef2
    Private Const COLD_DRef3 As String = "DRef3"                       ' DRef3
    Private Const COLD_DRef4 As String = "DRef4"                       ' DRef4
    Private Const COLD_DRef5 As String = "DRef5"                       ' DRef5
    Private Const COLD_PRID As String = "PRID"                         ' PRID
#End Region



    Dim dtGridMaster, dtGridDetail As DataTable
    Dim dtTempDetail As DataTable

    Dim sPRIDList As New StringBuilder
    Dim bLastSupplierAbsentCheck As Boolean

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub LoadtdbcPeriod()
        LoadCboPeriodReport(tdbcPeriodFrom, tdbcPeriodTo, D12)

        tdbcPeriodFrom.SelectedValue = giTranMonth.ToString("00") & "/" & giTranYear.ToString
        tdbcPeriodTo.SelectedValue = giTranMonth.ToString("00") & "/" & giTranYear.ToString
    End Sub

    Private Sub LoadSpecCaption()
        Dim sSQL As New StringBuilder
        sSQL.Append("SELECT SpecTypeID, Caption" & UnicodeJoin(gbUnicode) & " as Caption, Disabled FROM D07T0410 ORDER BY SpecTypeID")
        Dim dtSpec As DataTable = ReturnDataTable(sSQL.ToString)

        'Load visible cua Spec
        Dim dr As DataRow
        For i As Integer = 0 To 9
            dr = dtSpec.Rows(i)
            tdbgD.Splits(SPLIT0).DisplayColumns(IndexOfColumn(tdbgD, COLD_Spec01ID) + i).Visible = Not L3Bool(dr("Disabled"))
            tdbgD.Splits(SPLIT0).DisplayColumns(IndexOfColumn(tdbgD, COLD_Spec01ID) + i).HeadingStyle.Font = FontUnicode(gbUnicode)
            tdbgD.Columns(IndexOfColumn(tdbgD, COLD_Spec01ID) + i).Caption = dr("Caption").ToString
        Next i
    End Sub

    Private Sub tdbgD_NumberFormat()
        tdbgD.Columns(COLD_ApprovedQuantity).NumberFormat = DxxFormat.D07_QuantityDecimals
        tdbgD.Columns(COLD_POQuantity).NumberFormat = DxxFormat.D07_QuantityDecimals
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Lua_chon_nha_cung_cap_(buoc_1)_-_D12F3030") & UnicodeCaption(gbUnicode) 'Løa chãn nhª cung cÊp (b§ìc 1) - D12F3030
        '================================================================ 
        lblPeriod.Text = rl3("Ky") 'Kỳ
        '================================================================ 
        btnF12.Text = rL3("Hien_thi") & " (F12)" 'Hiển thị (F12)
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        btnProduction.Text = "&1. " & rl3("San_xuat") 'Sản xuất
        btnSubInfo.Text = "&2. " & rl3("Thong_tin_phu") 'Thông tin phụ
        btnChoose.Text = rl3("_Chon") 'Chọn
        btnFilter.Text = rL3("_Loc") '&Lọc
        btnCompare.Text = "&" & rL3("So_sanh_NCC") 'So sánh NCC
        btnContinue.Text = rL3("_Tiep_tuc") '&Tiếp tục
        '================================================================ 
        chkAutoSelectSupplier.Text = rl3("Lua_chon_nha_cung_cap_tu_dong") 'Lựa chọn nhà cung cấp tự động
        chkShowCheckedRow.Text = rl3("Chi_hien_thi_nhung_du__lieu_da_chon") 'Chỉ hiển thị những dữ  liệu đã chọn
        '================================================================ 
        optSupplierReady.Text = rl3("Da_co_nha_cung_cap") 'Đã có nhà cung cấp
        optSupplierAbsent.Text = rl3("Chua_co_nha_cung_cap") 'Chưa có nhà cung cấp
        '================================================================ 
        tdbcPeriodFrom.Columns("Period").Caption = rl3("Ky_ke_toan") 'Kỳ kế toán
        tdbcPeriodFrom.Columns("TranMonth").Caption = rl3("Thang") 'Tháng
        tdbcPeriodFrom.Columns("TranYear").Caption = rl3("Nam") 'Năm
        tdbcPeriodTo.Columns("Period").Caption = rl3("Ky_ke_toan") 'Kỳ kế toán
        tdbcPeriodTo.Columns("TranMonth").Caption = rl3("Thang") 'Tháng
        tdbcPeriodTo.Columns("TranYear").Caption = rl3("Nam") 'Năm
        '================================================================ 
        tdbgM.Columns("Choose").Caption = rl3("Chon") 'Chọn
        tdbgM.Columns("PRVoucherNo").Caption = rl3("So_chung_tu") 'Số chứng từ
        tdbgM.Columns("PRDate").Caption = rl3("Ngay_yeu_cau") 'Ngày yêu cầu
        tdbgM.Columns("ApproveDate").Caption = rl3("Ngay_duyet_yeu_cau")'Ngày duyệt yêu cầu
        tdbgM.Columns("BuyerName").Caption = rl3("Nguoi_yeu_cau") 'Người yêu cầu
        tdbgM.Columns("Note").Caption = rl3("Dien_giai") 'Diễn giải
        '================================================================ 
        tdbgD.Columns("Choose").Caption = rl3("Chon") 'Chọn
        tdbgD.Columns("InventoryID").Caption = rl3("_Ma_hang") 'Mã hàng
        tdbgD.Columns("InventoryName").Caption = rl3("Ten_hang") 'Tên hàng
        tdbgD.Columns("UnitID").Caption = rl3("DVT") 'ĐVT
        'tdbgD.Columns("ApprovedQuantity").Caption = rl3("So_luong_duyet") 'Số lượng duyệt COMMENT 09/06/08
        tdbgD.Columns("ApprovedQuantity").Caption = rl3("SL_yeu_cau") 'SL Yêu cầu
        tdbgD.Columns("POQuantity").Caption = rL3("SL_duoc_phep_lap_don_dat_hang") 'SL được phép lập đơn đặt hàng
        tdbgD.Columns(COLD_PRVoucherNo).Caption = rL3("So_phieu_YCMH")           ' Số phiếu YCMH
        tdbgD.Columns("MPSVoucherNo").Caption = rl3("Ke_hoach_san_xuat") 'Kế hoạch sản xuất
        tdbgD.Columns("PeriodID").Caption = rl3("Ky_san_xuat") 'Kỳ sản xuất
        tdbgD.Columns("ProductID").Caption = rl3("San_pham") 'Sản phẩm
        tdbgD.Columns("SaleOrderNo").Caption = rl3("_Don_hang") 'Đơn hàng
        tdbgD.Columns("DExpectDate").Caption = rl3("Ngay_nhan_hang") & " (" & rl3("YCMH") & ")" 'Ngày nhận hàng (YCMH)
        tdbgD.Columns("DeliveryDate").Caption = rL3("Ngay_giao_hang") & " (" & rL3("Don_hang") & ")" 'Ngày giao hàng (Đơn hàng)
        tdbgD.Columns(COLD_DetailDesc).Caption = rL3("Dien_giai") 'Diễn giải
        tdbgD.Columns(COLD_ProjectID).Caption = rL3("Ma_cong_trinh") 'Mã dự án
        tdbgD.Columns(COLD_ProjectName).Caption = rL3("Ten_cong_trinh") 'Tên dự án
        tdbgD.Columns(COLD_TaskID).Caption = rL3("Ma_hang_muc")                    ' Mã hạng mục
        tdbgD.Columns(COLD_TaskName).Caption = rL3("Ten_hang_muc")              ' Tên hạng mục
        '================================================================ 
        mnuFind.Text = rl3("Tim__kiem") 'Tìm &kiếm
        mnuListAll.Text = rl3("_Liet_ke_tat_ca") '&Liệt kê tất cả
    End Sub

    Private Sub D12F3030_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If usrOption IsNot Nothing Then usrOption.Dispose() '23/11/2017, Lê Bảo Trâm: id 104908-Lựa chọn NCC bước 1 theo hạng mục
    End Sub

    Private Sub D12F3030_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.F
                    mnuFind_Click(Nothing, Nothing)
                Case Keys.A
                    mnuListAll_Click(Nothing, Nothing)
            End Select
        Else
            Select Case e.KeyCode
                Case Keys.F11
                    HotKeyF11(Me, tdbgM)
                Case Keys.F12
                    btnF12_Click(Nothing, Nothing)
                Case Keys.Escape
                    usrOption.picClose_Click(Nothing, Nothing)
            End Select
        End If
    End Sub

    Private Sub D12F3030_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        FormKeyPress(sender, e)
    End Sub

    Private Sub D12F3030_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '24/10/2018, id 114069-Thay đổi độ rộng của lưới màn hình dưới lớn hơn lưới màn hình trên của màn hình Lựa chọn nhà cung cấp bước 1(D12F3030)
        LoadInfoGeneral()
        'Me.Cursor = Cursors.WaitCursor
        LoadtdbcPeriod()
        optSupplierAbsent.Checked = True
        bLastSupplierAbsentCheck = optSupplierAbsent.Checked
        'chkAutoSelectSupplier.Checked = True
        LoadSpecCaption()
        LoadSubInfo()
        ResetColorGrid(tdbgM, tdbgD)
        tdbgD_NumberFormat()
        Loadlanguage()
        InputbyUnicode(Me, gbUnicode)
        '**********************
        If D12Systems.TimeSetupDefaultOfSupplier <> "" Then 'ID 96585 25/07/2017
            chkAutoSelectSupplier.Visible = False
            btnCompare.Visible = False
            btnChoose.Visible = False
            btnContinue.Visible = True
            btnContinue.Left = btnChoose.Left
        Else
            chkAutoSelectSupplier.Visible = True
            btnCompare.Visible = True
            btnChoose.Visible = True
            btnContinue.Visible = False
        End If
        '**********************
        SetShortcutPopupMenu(C1CommandHolder)
        CallD99U1111(-1, True, 0)
        Split1Visible(True)
        SetResolutionForm(Me)
        'Me.Cursor = Cursors.Default
    End Sub

#Region "SQLs"
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD12P2025
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 18/01/2008 11:57:20
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD12P2025() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D12P2025 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString("%") & COMMA 'BuyerID, varchar[20], NOT NULL
        sSQL &= SQLNumber(tdbcPeriodFrom.Columns("TranMonth").Text) & COMMA 'FromMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodFrom.Columns("TranYear").Text) & COMMA 'FromYear, int, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodTo.Columns("TranMonth").Text) & COMMA 'ToMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(tdbcPeriodTo.Columns("TranYear").Text) & COMMA 'ToYear, int, NOT NULL
        sSQL &= SQLNumber(IIf(optSupplierReady.Checked, 1, 0)) & COMMA 'Supplier, tinyint, NOT NULL
        sSQL &= SQLString(sFind) & COMMA 'strFind, varchar[8000], NOT NULL
        sSQL &= SQLNumber(gbUnicode)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD12P2030
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 18/01/2008 04:10:41
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD12P2030() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D12P2030 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(IIf(optSupplierReady.Checked, 1, 0)) & COMMA  'Supplier, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode)
        Return sSQL
    End Function
#End Region

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        byTDBGFocus = 0
        chkShowCheckedRow.Checked = False
        Dim dtTemp As DataTable = ReturnDataTable(SQLStoreD12P2025)
        If D12Options.ViewMyVoucher Then
            dtGridMaster = ReturnTableFilter(dtTemp, "CreateUserID = " & SQLString(gsUserID))
        Else
            dtGridMaster = dtTemp
        End If
        LoadDataSource(tdbgM, dtGridMaster, gbUnicode)
        gbEnabledUseFind = dtGridMaster.Rows.Count > 0
        '*************************
        dtTempDetail = ReturnDataTable(SQLStoreD12P2030)
        If dtGridDetail IsNot Nothing Then dtGridDetail.Clear()
        gbEnabledUseFindDetail = False
    End Sub


    'Lấy các PRID của dòng có check
    'Output: thay đổi sPRIDList
    Private Sub GetPRIDList()
        sPRIDList.Remove(0, sPRIDList.Length)
        For i As Integer = 0 To tdbgM.RowCount - 1
            If CBool(tdbgM(i, COLM_Choose)) = True Then
                sPRIDList.Append(SQLString(tdbgM(i, COLM_PRID).ToString) & COMMA)
            End If
        Next i

        If sPRIDList.ToString = "" Then
            sPRIDList.Append("''")
        End If

        If sPRIDList.ToString.LastIndexOf(COMMA) <> -1 Then
            sPRIDList.Remove(sPRIDList.Length - 2, 2)
        End If

        sPRIDList.Insert(0, "(")
        sPRIDList.Append(")")
    End Sub


#Region "Active Find Client - List All "
    Private WithEvents Finder As New D99C1001
    Dim gbEnabledUseFind As Boolean = False
    Private sFind As String = ""
    Public WriteOnly Property strNewFind() As String
        Set(ByVal Value As String)
            If sContextMenuSource = "M" Then
                sFind = Value
            Else
                sFindDetail = Value
            End If
            ReLoadTDBGrid() 'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
        End Set
    End Property

    Private sFindDetail As String = ""
    Dim sContextMenuSource As String

    Private Sub mnuFind_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFind.Click
        If Not CallMenuFromGrid(tdbgM, e) And Not CallMenuFromGrid(tdbgD, e) Then Exit Sub
        If byTDBGFocus = 1 Then ' If Me.ActiveControl.Name = "tdbgM" Then
            sContextMenuSource = "M"
            Dim sSQL As String = ""
            gbEnabledUseFind = True
            sSQL = "Select * From D12V1234 "
            sSQL &= "Where FormID = " & SQLString(Me.Name) & " And Mode = '01' And Language = " & SQLString(gsLanguage)
            ShowFindDialogClient(Finder, sSQL, Me, False)
        ElseIf byTDBGFocus = 2 Then
            sContextMenuSource = "D"
            Dim sSQL As String = ""
            gbEnabledUseFind = True
            sSQL = "Select * From D12V1234 "
            sSQL &= "Where FormID = " & SQLString(Me.Name) & " And Mode = '02' " & "And Language = " & SQLString(gsLanguage)
            ShowFindDialogClient(Finder, sSQL, Me, gbUnicode)
        End If
    End Sub

    'Private Sub Finder_FindClick(ByVal ResultWhereClause As Object) Handles Finder.FindClick
    '    If ResultWhereClause Is Nothing Or ResultWhereClause.ToString = "" Then Exit Sub
    '    If sContextMenuSource = "M" Then
    '        sFind = ResultWhereClause.ToString()
    '    Else
    '        sFindDetail = ResultWhereClause.ToString()
    '    End If
    '    ReLoadTDBGrid()
    'End Sub

    Private Sub mnuListAll_Click(ByVal sender As Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListAll.Click
        If Not CallMenuFromGrid(tdbgM, e) And Not CallMenuFromGrid(tdbgD, e) Then Exit Sub
        If byTDBGFocus = 1 Then ' If tdbgM.Focused Then
            sFind = ""
            ResetFilter(tdbgM, sFilter, bRefreshFilter)
        ElseIf byTDBGFocus = 2 Then
            sFindDetail = ""
            ResetFilter(tdbgD, sFilterDetail, bRefreshFilterDetail)
        End If
        ReLoadTDBGrid()
    End Sub

    'Dim dtTempMOrg As DataTable
    'Dim dtTempDOrg As DataTable

    'Private Sub ReLoadTDBGrid()
    '    dtTempMOrg.DefaultView.RowFilter = sFind.Replace("N'", "'") '
    '    dtTempM = dtTempMOrg.DefaultView.ToTable
    '    LoadTdbgMaster()
    '    GetPRIDList()
    '    LoadTdbgDetail()
    'End Sub

    Private Sub ReLoadTDBGrid(Optional bFilterBar As Boolean = False, Optional byGrid As Byte = 0)
        Dim strFind As String = ""
        Dim strFindDetail As String = ""
        If chkShowCheckedRow.Checked Then
            strFind = "Choose = True"
            strFindDetail = "Choose = True"
        Else
            strFind = sFind
            strFindDetail = sFindDetail
            If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
            If sFilterDetail.ToString.Equals("") = False And strFindDetail.Equals("") = False Then strFindDetail &= " And "
            strFind &= sFilter.ToString
            strFindDetail &= sFilterDetail.ToString
            If strFind <> "" Then strFind = "Choose = True Or (" & strFind & ")"
            If strFindDetail <> "" Then strFindDetail = "Choose = True Or (" & strFindDetail & ")"
        End If
        dtGridMaster.DefaultView.RowFilter = strFind
        dtGridDetail.DefaultView.RowFilter = strFindDetail

        If bFilterBar Then '14/12/2017, Lê Thị THu Thảo: id 105328-Hỗ trợ tính năng search tại màn hình lựa chọn nhà cung cấp và thực hiện yêu cầu mua hàng
            If byGrid = 1 Then
                FindText(tdbgM)
            ElseIf byGrid = 2 Then
                FindText(tdbgD)
            End If
        End If
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        FooterTotalGrid(tdbgM, COLM_PRVoucherNo)
        If dtGridDetail IsNot Nothing Then FooterTotalGrid(tdbgD, COLD_InventoryID)
        FooterSumFilter(tdbgD, sFilterDetail.ToString, COLD_ApprovedQuantity, COLD_POQuantity) '1/10/2018, Nguyễn Thị Ý Nhi:id 113610-Bổ sung cột Số phiếu YCMH và dòng Sum cho hai cột SL yêu cầu, SL được phép lập đơn đặt hàng
    End Sub

#Region "tdbgM"
    Dim bRefreshFilter As Boolean = False 'Cờ bật set FilterText =""
    Dim sFilter As New System.Text.StringBuilder()

    Private Sub tdbgM_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbgM.FilterChange
        Try
            If (dtGridMaster Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub
            FilterChangeGrid(tdbgM, sFilter) 'Nếu có Lọc khi In
            ReLoadTDBGrid(True, 1)
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Private Sub tdbgM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbgM.KeyDown
        'Me.Cursor = Cursors.WaitCursor
        'If tdbgM.FilterActive Then HotKeyCtrlVOnGrid(tdbgM, e) : Exit Sub
        If tdbgM.FilterActive Then HotKeyCtrlVOnGrid(tdbgM, e) : Exit Sub

        If e.KeyCode = Keys.S And e.Control And tdbgM.Col = IndexOfColumn(tdbgM, COLM_Choose) Then
            HeadClick(tdbgM.Col)
        End If
        'Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbgM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbgM.KeyPress
        If tdbgM.Columns(tdbgM.Col).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox Then
            e.Handled = CheckKeyPress(e.KeyChar)
        ElseIf tdbgM.Splits(tdbgM.SplitIndex).DisplayColumns(tdbgM.Col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far Then
            e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End If
    End Sub

    Dim bSelect As Boolean = False
    Private Sub tdbgM_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgM.HeadClick
        HeadClick(e.ColIndex)
    End Sub

    Private Sub tdbgM_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgM.AfterColUpdate
        Select Case tdbgM.Columns(e.ColIndex).DataField
            Case COLM_Choose
                GetPRIDList()
                LoadTdbgDetail()
        End Select
        tdbgM.UpdateData()
    End Sub

    Dim byTDBGFocus As Byte = 0
    Private Sub tdbgM_MouseClick(sender As Object, e As MouseEventArgs) Handles tdbgM.MouseClick
        byTDBGFocus = 1
    End Sub

    Private Sub tdbgM_Click(sender As Object, e As EventArgs) Handles tdbgM.Click
        byTDBGFocus = 1
    End Sub

    Private Sub tdbgM_MouseDown(sender As Object, e As MouseEventArgs) Handles tdbgM.MouseDown
        byTDBGFocus = 1
    End Sub

#End Region

    Private Sub HeadClick(ByVal iCol As Integer)
        Select Case iCol
            Case IndexOfColumn(tdbgM, COLM_Choose)
                tdbgM.AllowSort = False
                L3HeadClick(tdbgM, COLM_Choose, bSelect)
                GetPRIDList()
                LoadTdbgDetail()
            Case Else
                tdbgM.AllowSort = True
        End Select
    End Sub

#Region "tdbgD"

    Dim bRefreshFilterDetail As Boolean = False 'Cờ bật set FilterText =""
    Dim sFilterDetail As New System.Text.StringBuilder()

    Private Sub tdbgD_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbgD.FilterChange
        Try
            If (dtGridDetail Is Nothing) Then Exit Sub
            If bRefreshFilterDetail Then Exit Sub 'set FilterText ="" thì thoát
            'Filter the data 
            FilterChangeGrid(tdbgD, sFilterDetail)
            ReLoadTDBGrid(True, 2)
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Dim bSelectDetail As Boolean = False

    Private Sub tdbgD_MouseClick(sender As Object, e As MouseEventArgs) Handles tdbgD.MouseClick
        byTDBGFocus = 2
    End Sub

    Private Sub tdbgD_Click(sender As Object, e As EventArgs) Handles tdbgD.Click
        byTDBGFocus = 2
    End Sub

    Private Sub tdbgD_MouseDown(sender As Object, e As MouseEventArgs) Handles tdbgD.MouseDown
        byTDBGFocus = 2
    End Sub

    Private Sub tdbgD_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgD.HeadClick
        Select Case tdbgD.Columns(e.ColIndex).DataField
            Case COLD_Choose
                tdbgD.AllowSort = False
                L3HeadClick(tdbgD, e.ColIndex, bSelectDetail)
            Case Else
                tdbgD.AllowSort = True
        End Select
    End Sub

    Private Sub tdbgD_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbgD.KeyDown
        'Me.Cursor = Cursors.WaitCursor
        'If tdbgD.FilterActive Then HotKeyCtrlVOnGrid(tdbgD, e) : Me.Cursor = Cursors.Default : Exit Sub

        If tdbgD.FilterActive Then HotKeyCtrlVOnGrid(tdbgD, e) : Exit Sub

        If e.KeyCode = Keys.S And e.Control And tdbgD.Col = IndexOfColumn(tdbgD, COLD_Choose) Then
            'L3HeadClick(tdbgD, tdbgD.Col, bSelectDetail)
            CtrlS_D(tdbgD.Row) '17/9/2018, Lê Thị Thu Thảo:id 113473-Hỗ trợ tính năng check chọn nhiều dòng mặt hàng
        End If
        'Me.Cursor = Cursors.Default
    End Sub

    '17/9/2018, Lê Thị Thu Thảo:id 113473-Hỗ trợ tính năng check chọn nhiều dòng mặt hàng
    Private Sub CtrlS_D(iRow As Integer)
        tdbgD.UpdateData()
        If tdbgD.RowCount < 2 Then Exit Sub

        Dim bChoose As Boolean = L3Bool(tdbgD(iRow, COLD_Choose))
        Dim j As Integer = tdbgD.RowCount - 1

        While j > iRow
            tdbgD(j, COLD_Choose) = bChoose
            j -= 1
        End While
        tdbgD.UpdateData()
    End Sub

    Private Sub tdbgD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbgD.KeyPress
        If tdbgD.Columns(tdbgD.Col).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox Then
            e.Handled = CheckKeyPress(e.KeyChar)
        ElseIf tdbgD.Splits(tdbgD.SplitIndex).DisplayColumns(tdbgD.Col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far Then
            e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End If
    End Sub
#End Region

#End Region

    Private Sub btnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChoose.Click
        btnChoose.Focus()
        If btnChoose.Focused = False Then Exit Sub
        '************************************
        Dim sSQL As String = ""

        'Kiem tra 
        Dim iCheckedCount As Integer = 0
        For i As Integer = 0 To tdbgD.RowCount - 1
            If L3Bool(tdbgD(i, COLD_Choose)) = True Then
                iCheckedCount += 1

                'k cần đếm nữa
                If iCheckedCount > 1 Then
                    Exit For
                End If
            End If
        Next i

        If iCheckedCount = 0 Then
            D99C0008.MsgNotYetChoose(rL3("Ma_hang"))
            Exit Sub
        End If
        'end kiem tra

        Dim arInventoryID As New ArrayList 'dùng để kt mặt hàng đã chọn có giống nhau k

        If chkAutoSelectSupplier.Checked Then
            sSQL = SQLDeleteD91T9009.ToString & vbCrLf
            sSQL &= SQLInsertD91T9009s.ToString & vbCrLf
            If ExecuteSQL(sSQL) Then
                Dim f As New D12F3040
                For i As Integer = 0 To tdbgD.RowCount - 1
                    If L3Bool(tdbgD(i, COLD_Choose)) = True Then
                        arInventoryID.Add(tdbgD(i, COLD_InventoryID).ToString)
                    End If
                Next i

                'Kiểm tra các mặt hàng có giống nhau k, biến này sẽ được kt thỏa hay k ở 3040
                Dim bDiff As Boolean = False
                For i As Integer = 1 To arInventoryID.Count - 1
                    If arInventoryID.Item(0).ToString <> arInventoryID.Item(i).ToString Then
                        bDiff = True
                        Exit For
                    End If
                Next i
                f.bDiff = bDiff
                f.AutoSelectSupplier = CInt(IIf(chkAutoSelectSupplier.Checked, 1, 0))
                f.SelectedSupplier = CInt(IIf(optSupplierReady.Checked, 1, 0))

                f.ShowDialog()
                f.Dispose()
            End If
            sSQL = SQLDeleteD91T9009.ToString & vbCrLf
            ExecuteSQL(sSQL)

        Else
            sSQL = SQLDeleteD91T9009.ToString & vbCrLf
            sSQL &= SQLInsertD91T9009s.ToString & vbCrLf
            If ExecuteSQL(sSQL) Then
                Dim f As New D12F3050
                With f
                    .AutoSelectSupplier = CInt(IIf(chkAutoSelectSupplier.Checked, 1, 0))
                    .SelectedSupplier = CInt(IIf(optSupplierReady.Checked, 1, 0))
                    .BaseOnPrice = 0
                    .BaseONPriority = 0
                    .Value1 = ""
                    .Value2 = ""
                    .Value3 = ""
                    .ShowDialog()
                    .Dispose()
                End With
            End If
            sSQL = SQLDeleteD91T9009.ToString & vbCrLf
            ExecuteSQL(sSQL)
        End If

        bLastSupplierAbsentCheck = Not bLastSupplierAbsentCheck 'nhằm bắt master cập nhật lại data
        btnFilter_Click(Nothing, Nothing)
    End Sub


    Private Sub chkShowCheckedRow_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowCheckedRow.CheckedChanged
        If dtGridMaster Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub

    Dim gbEnabledUseFindDetail As Boolean = False
    Private Sub SaveLastChooseDetail(ByRef dtGrid As DataTable, ByVal dtTemp As DataTable, ByVal sField As String)
        'b1. Xóa các dòng không check trong dtGrid
        Dim dtGrid_copy As DataTable = ReturnTableFilter(dtGrid, "Choose = True")

        'b2. Insert tất cả các dòng trong dtTemp vào dtGrid, trừ các dòng trùng
        For Each drTemp As DataRow In dtTemp.Rows
            Dim bDup As Boolean = False

            For Each dr As DataRow In dtGrid_copy.Rows
                If dr(sField).ToString = drTemp(sField).ToString Then
                    bDup = True
                    Exit For
                End If
            Next

            If bDup = False Then
                dtGrid_copy.ImportRow(drTemp)
            End If
        Next

        dtGrid = dtGrid_copy

    End Sub

    Private Sub SaveLastChoose(ByRef dtGrid As DataTable, ByRef dtTemp As DataTable, ByVal sField As String)
        For Each drTemp As DataRow In dtTemp.Rows
            For Each dr As DataRow In dtGrid.Rows
                If dr(sField).ToString = drTemp(sField).ToString Then
                    dr.BeginEdit()
                    dr("Choose") = drTemp("Choose")
                    dr.EndEdit()
                End If
            Next
        Next
        'dtGrid = dtTemp
    End Sub

    Private Sub LoadTdbgDetail()
        If sPRIDList.ToString = "" Then Exit Sub
        If dtGridDetail Is Nothing Then
            dtGridDetail = ReturnTableFilter(dtTempDetail, "PRID IN " & sPRIDList.ToString)
        Else
            Dim dtBefore As DataTable = dtGridDetail.Copy
            dtGridDetail = ReturnTableFilter(dtTempDetail, "PRID IN " & sPRIDList.ToString)
            'dtGridDetail = ReturnTableFilter(dtTempDetail, "PRID IN " & sPRIDList.ToString)
            SaveLastChoose(dtGridDetail, dtBefore, "PRTransactionID")
        End If
        LoadDataSource(tdbgD, dtGridDetail, gbUnicode)
        FooterSumFilter(tdbgD, sFilterDetail.ToString, COLD_ApprovedQuantity, COLD_POQuantity) '1/10/2018, Nguyễn Thị Ý Nhi:id 113610-Bổ sung cột Số phiếu YCMH và dòng Sum cho hai cột SL yêu cầu, SL được phép lập đơn đặt hàng
        If dtGridDetail.Rows.Count > 0 Then gbEnabledUseFindDetail = True
    End Sub



    Dim dtNRef As DataTable
    Dim dtVRef As DataTable
    Dim dtDRef As DataTable

    Private Sub LoadSubInfo()
        Dim sSQL As String = "Select * From D07N0037('D07T0011')" & vbCrLf
        sSQL &= " Order by DataType, DisplayOrder" & vbCrLf
        Dim dtSub As DataTable = ReturnDataTable(sSQL)

        dtNRef = ReturnTableFilter(dtSub, "FieldName Like 'N%'")
        For i As Integer = 0 To dtNRef.Rows.Count - 1
            With dtNRef.Rows(i)
                tdbgD.Splits(SPLIT1).DisplayColumns(IndexOfColumn(tdbgD, COLD_NRef1) + i).Width = 80
                tdbgD.Splits(SPLIT1).DisplayColumns(IndexOfColumn(tdbgD, COLD_NRef1) + i).HeadingStyle.Font = FontUnicode(gbUnicode)
                tdbgD.Splits(SPLIT1).DisplayColumns(IndexOfColumn(tdbgD, COLD_NRef1) + i).Visible = L3Bool(.Item("DefaultUse"))
                tdbgD.Columns(IndexOfColumn(tdbgD, COLD_NRef1) + i).Caption = IIf(geLanguage = EnumLanguage.Vietnamese, .Item("Caption84" & UnicodeJoin(gbUnicode)).ToString, .Item("Caption01" & UnicodeJoin(gbUnicode)).ToString).ToString
                tdbgD.Columns(IndexOfColumn(tdbgD, COLD_NRef1) + i).NumberFormat = "#,##0" & InsertZero(CInt(.Item("DecimalNum")))
            End With
        Next i
        '************************
        dtVRef = ReturnTableFilter(dtSub, "FieldName Like 'V%'")
        For i As Integer = 0 To dtVRef.Rows.Count - 1
            With dtVRef.Rows(i)
                tdbgD.Splits(SPLIT1).DisplayColumns(IndexOfColumn(tdbgD, COLD_VRef1) + i).Width = 140
                tdbgD.Splits(SPLIT1).DisplayColumns(IndexOfColumn(tdbgD, COLD_VRef1) + i).HeadingStyle.Font = FontUnicode(gbUnicode)
                tdbgD.Splits(SPLIT1).DisplayColumns(IndexOfColumn(tdbgD, COLD_VRef1) + i).Visible = L3Bool(.Item("DefaultUse"))
                tdbgD.Columns(IndexOfColumn(tdbgD, COLD_VRef1) + i).Caption = IIf(geLanguage = EnumLanguage.Vietnamese, .Item("Caption84" & UnicodeJoin(gbUnicode)).ToString, .Item("Caption01" & UnicodeJoin(gbUnicode)).ToString).ToString
            End With
        Next i
        '************************
        dtDRef = ReturnTableFilter(dtSub, "FieldName Like 'D%'")
        For i As Integer = 0 To dtDRef.Rows.Count - 1
            With dtDRef.Rows(i)
                tdbgD.Splits(SPLIT1).DisplayColumns(IndexOfColumn(tdbgD, COLD_DRef1) + i).Width = 80
                tdbgD.Splits(SPLIT1).DisplayColumns(IndexOfColumn(tdbgD, COLD_DRef1) + i).HeadingStyle.Font = FontUnicode(gbUnicode)
                tdbgD.Splits(SPLIT1).DisplayColumns(IndexOfColumn(tdbgD, COLD_DRef1) + i).Visible = L3Bool(.Item("DefaultUse"))
                tdbgD.Columns(IndexOfColumn(tdbgD, COLD_DRef1) + i).Caption = IIf(geLanguage = EnumLanguage.Vietnamese, .Item("Caption84" & UnicodeJoin(gbUnicode)).ToString, .Item("Caption01" & UnicodeJoin(gbUnicode)).ToString).ToString
            End With
        Next i
        '************************
        sSQL = "SELECT TypeCodeID, Caption" & UnicodeJoin(gbUnicode) & " As Caption, Disabled" & vbCrLf
        sSQL &= "FROM D07T0033 WITH(NOLOCK) ORDER BY TypeCodeID"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        For i As Integer = 0 To dt.Rows.Count - 1
            With dt.Rows(i)
                tdbgD.Splits(0).DisplayColumns(IndexOfColumn(tdbgD, COLD_ICode01Name) + i).Width = 140
                tdbgD.Splits(0).DisplayColumns(IndexOfColumn(tdbgD, COLD_ICode01Name) + i).HeadingStyle.Font = FontUnicode(gbUnicode)
                tdbgD.Splits(0).DisplayColumns(IndexOfColumn(tdbgD, COLD_ICode01Name) + i).Visible = Not L3Bool(.Item("Disabled"))
                tdbgD.Columns(IndexOfColumn(tdbgD, COLD_ICode01Name) + i).Caption = .Item("Caption").ToString
            End With
        Next i

    End Sub

    Private Sub Split1Visible(ByVal bProductionVisible As Boolean)
        With tdbgD.Splits(SPLIT1)
            .DisplayColumns(COLD_MPSVoucherNo).Visible = bProductionVisible
            .DisplayColumns(COLD_PeriodID).Visible = bProductionVisible
            .DisplayColumns(COLD_ProductID).Visible = bProductionVisible
            .DisplayColumns(COLD_SaleOrderNo).Visible = bProductionVisible
            .DisplayColumns(COLD_DeliveryDate).Visible = bProductionVisible

            For i As Integer = 0 To dtNRef.Rows.Count - 1
                .DisplayColumns(IndexOfColumn(tdbgD, COLD_NRef1) + i).Visible = Not bProductionVisible And L3Bool(dtNRef.Rows(i).Item("DefaultUse"))
            Next i

            For i As Integer = 0 To dtVRef.Rows.Count - 1
                .DisplayColumns(IndexOfColumn(tdbgD, COLD_VRef1) + i).Visible = Not bProductionVisible And L3Bool(dtVRef.Rows(i).Item("DefaultUse"))
            Next i

            For i As Integer = 0 To dtDRef.Rows.Count - 1
                .DisplayColumns(IndexOfColumn(tdbgD, COLD_DRef1) + i).Visible = Not bProductionVisible And L3Bool(dtDRef.Rows(i).Item("DefaultUse"))
            Next i

            For i As Integer = 0 To tdbgD.Columns.Count - 1
                If .DisplayColumns(i).Visible = True Then
                    tdbgD.Col = i
                    tdbgD.Row = tdbgD.Row
                    tdbgD.SplitIndex = SPLIT1
                    tdbgD.Focus()
                    Exit For
                End If
            Next i

        End With

        btnProduction.Enabled = Not bProductionVisible
        btnSubInfo.Enabled = bProductionVisible
    End Sub

    Private Sub btnProduction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProduction.Click
        Split1Visible(True)
        CallD99U1111(0, dtF12 Is Nothing)
    End Sub

    Private Sub btnSubInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubInfo.Click
        Split1Visible(False)
        CallD99U1111(1, dtF12 Is Nothing)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD91T9009
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 28/07/2010 03:31:05
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD91T9009() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D91T9009"
        sSQL &= " Where HostID=" & SQLString(My.Computer.Name) & " And UserID=" & SQLString(gsUserID) & " And Key01ID='12' And Key02ID=" & SQLString(Me.Name)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD91T9009s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 28/07/2010 03:33:37
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD91T9009s() As StringBuilder
        Dim sRet As New StringBuilder("")
        Dim sSQL As New StringBuilder("")

        For i As Integer = 0 To tdbgD.RowCount - 1
            If L3Bool(tdbgD(i, COLD_Choose)) Then
                sSQL.Append("Insert Into D91T9009(")
                sSQL.Append("UserID, HostID, Key01ID, Key02ID, Key03ID, Key04ID")
                sSQL.Append(") Values(")
                sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NULL
                sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NULL
                sSQL.Append(SQLString("12") & COMMA) 'Key01ID, varchar[250], NULL
                sSQL.Append(SQLString(Me.Name) & COMMA) 'Key02ID, varchar[250], NULL
                sSQL.Append(SQLString(tdbgD(i, COLD_PRTransactionID)) & COMMA) 'Key03ID, varchar[250], NULL
                sSQL.Append(SQLString(tdbgD(i, COLD_PRID))) 'Key04ID, varchar[250], NULL
                sSQL.Append(")")

                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
            End If
        Next

        Return sRet
    End Function

    Private Sub C1ContextMenu_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1ContextMenu.Popup
        If tdbgM.Focus Then
            mnuFind.Enabled = (gbEnabledUseFind OrElse tdbgM.RowCount > 0) And (Not chkShowCheckedRow.Checked)
            mnuListAll.Enabled = mnuFind.Enabled
        Else
            mnuFind.Enabled = (gbEnabledUseFindDetail OrElse tdbgD.RowCount > 0) And (Not chkShowCheckedRow.Checked)
            mnuListAll.Enabled = mnuFind.Enabled
        End If
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

    Private Sub btnCompare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompare.Click
        btnCompare.Focus()
        If btnCompare.Focused = False Then Exit Sub
        '************************************
        Dim dr() As DataRow = dtGridMaster.Select(COLM_Choose & "=1")
        If dr.Length > 1 Then
            D99C0008.MsgL3(rL3("Ban_chi_duoc_chon_mot_yeu_cau_mua_hang"))
            tdbgM.Focus()
            tdbgM.Col = IndexOfColumn(tdbgM, COLM_Choose)
            Exit Sub
        End If
        '*******************
        Dim sSQL As New StringBuilder
        sSQL.Append(SQLDeleteD91T9009.ToString & vbCrLf)
        sSQL.Append(SQLInsertD91T9009s.ToString & vbCrLf)
        If ExecuteSQL(sSQL.ToString) Then
            Dim frm As New D12F3070
            frm.ShowDialog()
            frm.Dispose()
        End If
    End Sub

#Region "'ID 96585 25/07/2017"
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD91T9009
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 28/07/2010 03:31:05
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD12T9009() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D12T9009 "
        sSQL &= " Where HostID=" & SQLString(My.Computer.Name) & " And UserID=" & SQLString(gsUserID) & " And FormID=" & SQLString(Me.Name)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD91T9009s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 28/07/2010 03:33:37
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD12T9009s(dr() As DataRow) As StringBuilder
        Dim sRet As New StringBuilder("")
        Dim sSQL As New StringBuilder("")

        For i As Integer = 0 To dr.Length - 1
            sSQL.Append("Insert Into D12T9009 (")
            sSQL.Append("UserID, HostID, FormID, Key01ID, Key02ID")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NULL
            sSQL.Append(SQLString(Me.Name) & COMMA) 'FormID, varchar[20], NULL
            sSQL.Append(SQLString(dr(i).Item(COLD_PRTransactionID)) & COMMA) 'Key01ID, varchar[250], NULL
            sSQL.Append(SQLString(dr(i).Item(COLD_PRID))) 'Key02ID, varchar[250], NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next

        Return sRet
    End Function

    Private Function AllowSave(ByRef dr() As DataRow) As Boolean
        tdbgD.UpdateData()
        If tdbgD.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbgD.Focus()
            Return False
        End If
        dr = dtGridDetail.Select(COLD_Choose & " = 1")
        If dr.Length < 1 Then
            D99C0008.MsgL3(rL3("MSG000010"))
            tdbgD.Focus()
            tdbgD.SplitIndex = SPLIT0
            tdbgD.Col = IndexOfColumn(tdbgD, COLD_Choose)
            tdbgD.Row = 0
            Return False
        End If
        Return True
    End Function

    Private Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        btnContinue.Focus()
        If btnContinue.Focused = False Then Exit Sub
        '************************************
        Dim dr() As DataRow = Nothing
        If AllowSave(dr) = False Then Exit Sub

        Dim sSQL As New StringBuilder
        If optSupplierReady.Checked Then
            sSQL.Append(SQLDeleteD91T9009.ToString & vbCrLf)
            sSQL.Append(SQLInsertD91T9009s.ToString & vbCrLf)
            If ExecuteSQL(sSQL.ToString) Then
                Dim f As New D12F3050
                With f
                    .AutoSelectSupplier = CInt(IIf(chkAutoSelectSupplier.Checked, 1, 0))
                    .SelectedSupplier = CInt(IIf(optSupplierReady.Checked, 1, 0))
                    .BaseOnPrice = 0
                    .BaseONPriority = 0
                    .Value1 = ""
                    .Value2 = ""
                    .Value3 = ""
                    .ShowDialog()
                    .Dispose()
                End With
            End If
            '********************
            sSQL.Remove(0, sSQL.Length)
            sSQL.Append(SQLDeleteD91T9009.ToString & vbCrLf)
            ExecuteSQLNoTransaction(sSQL.ToString)
        Else
            sSQL.Append(SQLDeleteD12T9009.ToString & vbCrLf)
            sSQL.Append(SQLInsertD12T9009s(dr).ToString & vbCrLf)
            If ExecuteSQL(sSQL.ToString) Then
                Dim frm As New D12F3031
                frm.ShowDialog()
                frm.Dispose()
            End If
        End If
    End Sub
#End Region

#Region "Hien thi F12"

    Private usrOption As New D99U1111()
    Dim dtF12 As DataTable
    '23/11/2017, Lê Bảo Trâm: id 104908-Lựa chọn NCC bước 1 theo hạng mục
    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        If usrOption Is Nothing Then Exit Sub 'TH lưới không có cột
        usrOption.Location = New Point(tdbgD.Left, btnF12.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Dim arrColObligatory() As Object = {COLD_Choose, COLD_InventoryID, COLD_MPSVoucherNo}

    Private Sub CallD99U1111(ByVal iButton As Integer, Optional ByVal bLoad As Boolean = True, Optional ByVal iMode As Object = 0)
        If bLoad Then
            dtF12 = Nothing
            usrOption.AddColVisible(tdbgD, SPLIT0, dtF12, 0, arrColObligatory, COLD_Choose, COLD_TaskName)
            usrOption.AddColVisible(tdbgD, SPLIT1, dtF12, -1, arrColObligatory, COLD_PRVoucherNo, COLD_DeliveryDate, , 0)
            usrOption.AddColVisible(tdbgD, SPLIT1, dtF12, -1, arrColObligatory, COLD_NRef1, COLD_DRef5, , 1)
        End If

        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D99U1111(Me, tdbgD, dtF12, iMode, , , iButton)
    End Sub

#End Region
    
  
   
   
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        '' Add any initialization after the InitializeComponent() call.
        'AnchorForControl(EnumAnchorStyles.TopLeftRightBottom, C1SplitContainer1)
        'AnchorForControl(EnumAnchorStyles.TopRight, btnFilter)
        'AnchorResizeColumnsGrid(EnumAnchorStyles.TopLeftRightBottom, tdbgM)
        'AnchorForControl(EnumAnchorStyles.BottomRight, btnSubInfo, btnProduction)
        'AnchorResizeColumnsGrid(EnumAnchorStyles.BottomLeftRight, tdbgD)
        'AnchorForControl(EnumAnchorStyles.BottomLeft, btnF12)
        'AnchorForControl(EnumAnchorStyles.BottomRight, btnClose, btnChoose, btnCompare, btnContinue)
    End Sub
End Class
