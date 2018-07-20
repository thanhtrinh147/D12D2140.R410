Imports System
Imports System.Text
Public Class D12F3100
    Dim dtCaptionCols As DataTable
    Dim dtObj, dtGrid As DataTable
    Dim bUseSpec As Boolean


#Region "Const of tdbg - Total of Columns: 73"
    Private Const COL_Choose As String = "Choose"                               ' Chọn
    Private Const COL_PRID As String = "PRID"                                   ' PRID
    Private Const COL_SupplierTransID As String = "SupplierTransID"             ' SupplierTransID
    Private Const COL_PRTransactionID As String = "PRTransactionID"             ' PRTransactionID
    Private Const COL_VoucherTypeID As String = "VoucherTypeID"                 ' Loại phiếu
    Private Const COL_TransTypeName As String = "TransTypeName"                 ' Nghiệp vụ
    Private Const COL_IsActivedOver As String = "IsActivedOver"                 ' Đã TH hết
    Private Const COL_ATVoucherNo As String = "ATVoucherNo"                     ' Chấp thuận chọn thầu
    Private Const COL_PRVoucherNo As String = "PRVoucherNo"                     ' Yêu cầu mua hàng
    Private Const COL_PRDate As String = "PRDate"                               ' Ngày phiếu
    Private Const COL_ObjectTypeID As String = "ObjectTypeID"                   ' Loại đối tượng
    Private Const COL_ObjectID As String = "ObjectID"                           ' Đối tượng
    Private Const COL_ObjectName As String = "ObjectName"                       ' Tên đối tượng
    Private Const COL_CurrencyID As String = "CurrencyID"                       ' Loại tiền
    Private Const COL_ExchangeRate As String = "ExchangeRate"                   ' Tỷ giá
    Private Const COL_PaymentMethodID As String = "PaymentMethodID"             ' Phương thức thanh toán
    Private Const COL_PaymentMethodName As String = "PaymentMethodName"         ' Tên PTTT
    Private Const COL_PaymentTermID As String = "PaymentTermID"                 ' Điều khoản TM
    Private Const COL_PaymentTermName As String = "PaymentTermName"             ' Tên ĐKTM
    Private Const COL_DeliveryID As String = "DeliveryID"                       ' PT giao hàng
    Private Const COL_DeliveryName As String = "DeliveryName"                   ' Tên PTGH
    Private Const COL_BuyerName As String = "BuyerName"                         ' Người lập
    Private Const COL_Note As String = "Note"                                   ' Diễn giải
    Private Const COL_Ana01ID As String = "Ana01ID"                             ' Ana01ID
    Private Const COL_Ana02ID As String = "Ana02ID"                             ' Ana02ID
    Private Const COL_Ana03ID As String = "Ana03ID"                             ' Ana03ID
    Private Const COL_Ana04ID As String = "Ana04ID"                             ' Ana04ID
    Private Const COL_Ana05ID As String = "Ana05ID"                             ' Ana05ID
    Private Const COL_Ana06ID As String = "Ana06ID"                             ' Ana06ID
    Private Const COL_Ana07ID As String = "Ana07ID"                             ' Ana07ID
    Private Const COL_Ana08ID As String = "Ana08ID"                             ' Ana08ID
    Private Const COL_Ana09ID As String = "Ana09ID"                             ' Ana09ID
    Private Const COL_Ana10ID As String = "Ana10ID"                             ' Ana10ID
    Private Const COL_ProjectID As String = "ProjectID"                         ' Mã dự án
    Private Const COL_ProjectName As String = "ProjectName"                     ' Tên dự án
    Private Const COL_InventoryID As String = "InventoryID"                     ' Mã hàng
    Private Const COL_InventoryName As String = "InventoryName"                 ' Tên hàng
    Private Const COL_Spec01ID As String = "Spec01ID"                           ' Spec01ID
    Private Const COL_Spec02ID As String = "Spec02ID"                           ' Spec02ID
    Private Const COL_Spec03ID As String = "Spec03ID"                           ' Spec03ID
    Private Const COL_Spec04ID As String = "Spec04ID"                           ' Spec04ID
    Private Const COL_Spec05ID As String = "Spec05ID"                           ' Spec05ID
    Private Const COL_Spec06ID As String = "Spec06ID"                           ' Spec06ID
    Private Const COL_Spec07ID As String = "Spec07ID"                           ' Spec07ID
    Private Const COL_Spec08ID As String = "Spec08ID"                           ' Spec08ID
    Private Const COL_Spec09ID As String = "Spec09ID"                           ' Spec09ID
    Private Const COL_Spec10ID As String = "Spec10ID"                           ' Spec10ID
    Private Const COL_UnitID As String = "UnitID"                               ' ĐVT
    Private Const COL_DeliveryDate As String = "DeliveryDate"                   ' Ngày nhận hàng
    Private Const COL_DetailDesc As String = "DetailDesc"                       ' Diễn giải chi tiết
    Private Const COL_OQuantity As String = "OQuantity"                         ' Số lượng
    Private Const COL_UnitPrice As String = "UnitPrice"                         ' Đơn giá
    Private Const COL_ApprovedQuantity As String = "ApprovedQuantity"           ' Số lượng duyệt
    Private Const COL_RealizedQuantity As String = "RealizedQuantity"           ' SL đã lập đơn hàng
    Private Const COL_RealizedCTQTY As String = "RealizedCTQTY"                 ' SL đã lập hợp đồng
    Private Const COL_VATGroupID As String = "VATGroupID"                       ' Nhóm thuế
    Private Const COL_RateTax As String = "RateTax"                             ' Thuế suất
    Private Const COL_RemainQuantity As String = "RemainQuantity"               ' SL cho phép
    Private Const COL_POQuantity As String = "POQuantity"                       ' Số lượng cần lập
    Private Const COL_IsContractRequisition As String = "IsContractRequisition" ' Đã lập HĐ khung mua hàng
    Private Const COL_IsContract As String = "IsContract"                       ' Đã lập HĐ mua hàng (D06)
    Private Const COL_ICode01ID As String = "ICode01ID"                         ' ICode01ID
    Private Const COL_ICode02ID As String = "ICode02ID"                         ' ICode02ID
    Private Const COL_ICode03ID As String = "ICode03ID"                         ' ICode03ID
    Private Const COL_ICode04ID As String = "ICode04ID"                         ' ICode04ID
    Private Const COL_ICode05ID As String = "ICode05ID"                         ' ICode05ID
    Private Const COL_ICode06ID As String = "ICode06ID"                         ' ICode06ID
    Private Const COL_ICode07ID As String = "ICode07ID"                         ' ICode07ID
    Private Const COL_ICode08ID As String = "ICode08ID"                         ' ICode08ID
    Private Const COL_ICode09ID As String = "ICode09ID"                         ' ICode09ID
    Private Const COL_ICode10ID As String = "ICode10ID"                         ' ICode10ID
    Private Const COL_CreateUserID As String = "CreateUserID"                   ' CreateUserID
    Private Const COL_DAGroupID As String = "DAGroupID"                         ' DAGroupID
#End Region

    Private usrOption As New D99U1111()
    Dim dtF12 As DataTable

    Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.'
        'Các control chỉnh theo Anchor là XXX
        AnchorForControl(EnumAnchorStyles.TopLeftRight, grpSupplier, txtObjectName)
        AnchorForControl(EnumAnchorStyles.BottomLeft, btnF12, chkIsAuto)
        AnchorForControl(EnumAnchorStyles.BottomRight, btnClose)
        AnchorResizeColumnsGrid(EnumAnchorStyles.TopLeftRightBottom, tdbg)
    End Sub

    Private Sub D12F3100_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If usrOption IsNot Nothing Then usrOption.Dispose()
    End Sub

    Private Sub D12F3100_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
        ElseIf e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        ElseIf e.KeyCode = Keys.F5 Then
            btnFilter_Click(Nothing, Nothing)
        End If

        Select Case e.KeyCode
            Case Keys.F12
                btnF12_Click(Nothing, Nothing)
            Case Keys.Escape
                usrOption.picClose_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub D12F3100_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadInfoGeneral()
        InputDateInTrueDBGrid(tdbg, COL_PRDate, COL_DeliveryDate)
        bUseSpec = LoadTDBGridSpecificationCaption(tdbg, IndexOfColumn(tdbg, COL_Spec01ID), SPLIT2, True, gbUnicode)
        LoadTDBGridAnalysisCaption("D12", tdbg, IndexOfColumn(tdbg, COL_Ana01ID), 1, True, gbUnicode)
        LoadLanguage()
        InputbyUnicode(Me, gbUnicode)
        tdbg_NumberFormat()
        tdbg_LockedColumns()
        ResetColorGrid(tdbg, 0, tdbg.Splits.Count - 1)
        ResetSplitDividerSize(tdbg)
        LoadTDBCombo()
        LoadDefault()
        '*************************
        CallD99U1111()
        '***********************************
        'ID 71854 21/1/2015
        tdbg.Splits(1).DisplayColumns(COL_IsActivedOver).Visible = chkIsShowVoucherOver.Checked 'Phải để sau CallD99U1111
        chkIsShowVoucherOver_Click(Nothing, Nothing)
        '*************************
        SetShortcutPopupMenu(ContextMenuStrip1)
        SetResolutionForm(Me, ContextMenuStrip1)
    End Sub

    Private Sub CallD99U1111(Optional ByVal bLoad As Boolean = True, Optional ByVal iMode As Object = 0)
        If bLoad Then
            Dim arrColObligatory() As Object = {COL_Choose, COL_PRVoucherNo, COL_TransTypeName}
            usrOption.AddColVisible(tdbg, SPLIT0, dtF12, -1, arrColObligatory, COL_Choose) 'Duyệt hết split 0 vì có hiển thị các cột ở cuối cùng như COL_D08T0300_Status
            usrOption.AddColVisible(tdbg, SPLIT1, dtF12, -1, arrColObligatory, COL_TransTypeName, COL_Ana10ID) 'split1
            usrOption.AddColVisible(tdbg, SPLIT2, dtF12, -1, arrColObligatory, COL_InventoryID, COL_POQuantity) 'split2
            usrOption.EditModeColVisible(dtF12, 1, COL_IsActivedOver)
        End If
        usrOption.picClose_Click(Nothing, Nothing)
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D99U1111(Me, tdbg, dtF12, iMode)
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Thuc_hien_yeu_cau_mua_hangF") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Thøc hiÖn y£u cÇu mua hªng
        '================================================================ 
        lblObjectTypeID.Text = rl3("Nha_cung_cap") 'Nhà cung cấp
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnF12.Text = rL3("Hien_thi") & " (F12)" 'Hiển thị
        btnFilter.Text = rL3("Loc") & " (F5)" 'Lọc
        '================================================================ 
        chkIsAuto.Text = rL3("Lap_don_hang_hang_loat") 'Lập đơn hàng hàng loạt
        chkIsShowVoucherOver.Text = rL3("Hien_thi_phieu_da_thuc_hien_het") 'Hiển thị phiếu đã thực hiện hết
        '================================================================ 
        optCTCT.Text = rl3("Chap_thuan_chon_thauU") 'Chấp thuận chọn thầu
        optYCMH.Text = rl3("Yeu_cau_mua_hang") 'Yêu cầu mua hàng
        '================================================================ 
        tdbcObjectTypeID.Columns("ObjectTypeID").Caption = rl3("Ma") 'Mã
        tdbcObjectTypeID.Columns("ObjectTypeName").Caption = rl3("Ten") 'Tên
        tdbcObjectID.Columns("ObjectID").Caption = rl3("Ma") 'Mã
        tdbcObjectID.Columns("ObjectName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns(COL_Choose).Caption = rL3("Chon") 'Chọn
        tdbg.Columns(COL_VoucherTypeID).Caption = rL3("Loai_phieu") 'Loại phiếu
        tdbg.Columns(COL_TransTypeName).Caption = rL3("Nghiep_vu") 'Nghiệp vụ
        tdbg.Columns(COL_IsActivedOver).Caption = rL3("Da_TH_het") 'Đã TH hết
        tdbg.Columns(COL_ATVoucherNo).Caption = rL3("Chap_thuan_chon_thauU") 'Chấp thuận chọn thầu
        tdbg.Columns(COL_PRVoucherNo).Caption = rL3("Yeu_cau_mua_hang") 'Yêu cầu mua hàng
        tdbg.Columns(COL_PRDate).Caption = rL3("Ngay_phieu") 'Ngày phiếu
        tdbg.Columns(COL_ObjectTypeID).Caption = rL3("Loai_doi_tuong") 'Loại đối tượng
        tdbg.Columns(COL_ObjectID).Caption = rL3("Doi_tuong") 'Đối tượng
        tdbg.Columns(COL_ObjectName).Caption = rL3("Ten_doi_tuong") 'Tên đối tượng
        tdbg.Columns(COL_CurrencyID).Caption = rL3("Loai_tien") 'Loại tiền
        tdbg.Columns(COL_ExchangeRate).Caption = rL3("Ty_gia") 'Tỷ giá
        tdbg.Columns(COL_PaymentMethodID).Caption = rL3("Phuong_thuc_thanh_toan") 'Phương thức thanh toán
        tdbg.Columns(COL_PaymentMethodName).Caption = rL3("Ten_PTTT") 'Tên PTTT
        tdbg.Columns(COL_PaymentTermID).Caption = rL3("Dieu_khoan_TM") 'Điều khoản TM
        tdbg.Columns(COL_PaymentTermName).Caption = rL3("Ten_DKTM") 'Tên ĐKTM
        tdbg.Columns(COL_DeliveryID).Caption = rL3("PT_giao_hang") 'PT giao hàng
        tdbg.Columns(COL_DeliveryName).Caption = rL3("Ten_PTGH") 'Tên PTGH
        tdbg.Columns(COL_BuyerName).Caption = rL3("Nguoi_lap") 'Người lập
        tdbg.Columns(COL_Note).Caption = rL3("Dien_giai") 'Diễn giải
        tdbg.Columns(COL_ProjectID).Caption = rL3("Ma_cong_trinh") 'Mã dự án
        tdbg.Columns(COL_ProjectName).Caption = rL3("Ten_cong_trinh") 'Tên dự án
        tdbg.Columns(COL_InventoryID).Caption = rL3("Ma_hang") 'Mã hàng
        tdbg.Columns(COL_InventoryName).Caption = rL3("Ten_hang_") 'Tên hàng
        tdbg.Columns(COL_UnitID).Caption = rL3("DVT") 'ĐVT
        tdbg.Columns(COL_DeliveryDate).Caption = rL3("Ngay_nhan_hang") 'Ngày nhận hàng
        tdbg.Columns(COL_DetailDesc).Caption = rL3("Dien_giai_chi_tiet") 'Diễn giải chi tiết
        tdbg.Columns(COL_OQuantity).Caption = rL3("So_luong") 'Số lượng
        tdbg.Columns(COL_UnitPrice).Caption = rL3("Don_gia") 'Đơn giá
        tdbg.Columns(COL_ApprovedQuantity).Caption = rL3("So_luong_duyet") 'Số lượng duyệt
        tdbg.Columns(COL_RealizedQuantity).Caption = rL3("SL_da_lap_don_hang") 'SL đã lập đơn hàng
        tdbg.Columns(COL_RealizedCTQTY).Caption = rL3("SL_da_lap_hop_dong") 'SL đã lập hợp đồng
        tdbg.Columns(COL_VATGroupID).Caption = rL3("Nhom_thue") 'Nhóm thuế
        tdbg.Columns(COL_RateTax).Caption = rL3("Thue_suat") 'Thuế suất
        tdbg.Columns(COL_RemainQuantity).Caption = rL3("SL_cho_phep") 'SL cho phép
        tdbg.Columns(COL_POQuantity).Caption = rL3("So_luong_can_lap") 'Số lượng cần lập
        tdbg.Columns(COL_IsContractRequisition).Caption = rL3("Da_lap_HD_khung_mua_hang") 'Đã lập HĐ khung mua hàng
        tdbg.Columns(COL_IsContract).Caption = rL3("Da_lap_HD_mua_hang_(D06)") 'Đã lập HĐ mua hàng (D06)
        '================================================================ 
        mnsCreateVoucher.Text = rL3("Lap_don_hang") 'Lập đơn hàng
        mnsCreateAvailableContract.Text = rL3("Lap_hop_dong_mua_hang") 'Lập hợp đồng mua hàng
        mnsCreateContract.Text = rL3("Lap_hop_dong_mua_hang") & Space(1) & "(" & rL3("chuyen_nganh_BDS") & ")" 'Lập hợp đồng mua hàng (Chuyên ngành BĐS)
        mnsCreateRequisition.Text = rL3("Lap_hop_dong_khung_mua_hang") 'Lập hợp đồng khung mua hàng
        mnsCreateContractD06.Text = rL3("Lap_hop_dong_mua_hang") & Space(1) & "(D06)" 'Lập hợp đồng mua hàng (D06)
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_ApprovedQuantity).NumberFormat = DxxFormat.D07_QuantityDecimals
        tdbg.Columns(COL_RealizedQuantity).NumberFormat = DxxFormat.D07_QuantityDecimals
        tdbg.Columns(COL_RemainQuantity).NumberFormat = DxxFormat.D07_QuantityDecimals
        tdbg.Columns(COL_POQuantity).NumberFormat = DxxFormat.D07_QuantityDecimals
        tdbg.Columns(COL_OQuantity).NumberFormat = DxxFormat.D07_QuantityDecimals
        tdbg.Columns(COL_UnitPrice).NumberFormat = DxxFormat.D07_UnitCostDecimals
        tdbg.Columns(COL_ExchangeRate).NumberFormat = DxxFormat.ExchangeRateDecimals
        tdbg.Columns(COL_RealizedCTQTY).NumberFormat = DxxFormat.D07_QuantityDecimals
        tdbg.Columns(COL_RateTax).NumberFormat = "Percent"
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT1).DisplayColumns(COL_TransTypeName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_IsActivedOver).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_ATVoucherNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_PRVoucherNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_PRDate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_ObjectTypeID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_ObjectID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_ObjectName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CurrencyID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_ExchangeRate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_PaymentMethodID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_PaymentMethodName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_PaymentTermID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_PaymentTermName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_DeliveryID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_DeliveryName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_BuyerName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Note).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana01ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana02ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana03ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana04ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana05ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana06ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana07ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana08ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana09ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Ana10ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_ProjectID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_ProjectName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_InventoryID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_InventoryName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_Spec01ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_Spec02ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_Spec03ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_Spec04ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_Spec05ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_Spec06ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_Spec07ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_Spec08ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_Spec09ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_Spec10ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_UnitID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_DeliveryDate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_DetailDesc).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_OQuantity).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_UnitPrice).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_ApprovedQuantity).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_RealizedQuantity).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_RealizedCTQTY).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_VATGroupID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_RateTax).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT3).DisplayColumns(COL_RemainQuantity).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT3).DisplayColumns(COL_IsContractRequisition).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT3).DisplayColumns(COL_IsContract).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub LoadDefault()
        Dim sSQL As String = "SELECT TOP 1 1 FROM D12T3400 WITH(NOLOCK)"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            mnsCreateContract.Visible = True
            tdbg.Splits(1).DisplayColumns(COL_TransTypeName).Visible = True
            tdbg.Splits(1).DisplayColumns(COL_TransTypeName).Visible = True
            tdbg.Splits(1).DisplayColumns(COL_ATVoucherNo).Visible = True
        Else
            mnsCreateContract.Visible = False
            tdbg.Splits(1).DisplayColumns(COL_TransTypeName).Visible = False
            tdbg.Splits(1).DisplayColumns(COL_TransTypeName).Visible = False
            tdbg.Splits(1).DisplayColumns(COL_ATVoucherNo).Visible = False
        End If
        ToolStripSeparator1.Visible = mnsCreateContract.Visible
        '***********************************
        If D12Systems.CreateDirectPO = 1 Then chkIsAuto.Visible = False
        '**********************************
        VisibleMenu() 'ID 80061 03/11/2016
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""

        'Load tdbcObjectTypeID
        sSQL = "Select '%' As ObjectTypeID, " & AllName & "  As ObjectTypeName, 0 AS DisplayOrder " & vbCrLf
        sSQL &= "Union All" & vbCrLf
        sSQL &= "Select ObjectTypeID, ObjectTypeName" & UnicodeJoin(gbUnicode) & " as ObjectTypeName, 1 AS DisplayOrder " & vbCrLf
        sSQL &= "From D91T0005 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Order By DisplayOrder, ObjectTypeID"
        LoadDataSource(tdbcObjectTypeID, sSQL, gbUnicode)

        'Load tdbcObjectID
        sSQL = "Select '%' As ObjectID, " & AllName & " As  ObjectName, '' AS ObjectTypeID, 0 AS DisplayOrder " & vbCrLf
        sSQL &= "Union All " & vbCrLf
        sSQL &= "Select ObjectID, ObjectName" & UnicodeJoin(gbUnicode) & " as ObjectName, ObjectTypeID, 1 AS DisplayOrder " & vbCrLf
        sSQL &= "From Object WITH(NOLOCK) "
        sSQL &= "WHERE  Disabled=0  " & vbCrLf
        sSQL &= "Order By DisplayOrder, ObjectID"
        dtObj = ReturnDataTable(sSQL)
    End Sub

    Private Sub LoadTdbcObjectID(ByVal ID As String)
        If ID = "%" Then
            LoadDataSource(tdbcObjectID, dtObj.DefaultView.ToTable, gbUnicode)
        Else
            LoadDataSource(tdbcObjectID, ReturnTableFilter(dtObj, "ObjectID ='%'  Or ObjectTypeID = " & SQLString(ID)), gbUnicode)
        End If
        tdbcObjectID.SelectedValue = "%"
    End Sub

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
        LoadTdbcObjectID(ReturnValueC1Combo(tdbcObjectTypeID))
    End Sub

    Private Sub tdbcObjectID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcObjectID.SelectedValueChanged
        If tdbcObjectID.SelectedValue Is Nothing Then
            txtObjectName.Text = ""
        Else
            txtObjectName.Text = tdbcObjectID.Columns(1).Value.ToString
        End If

        If tdbcObjectID.SelectedValue Is Nothing Then
            Try
                CType(tdbg.DataSource, DataTable).Clear()
                ReLoadTDBGrid()
                Exit Sub
            Catch ex As Exception

            End Try
        End If

        'LoadTDBGrid()'ID 94093 25/04/2017
    End Sub

    Private Sub tdbcObjectID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcObjectID.LostFocus
        If tdbcObjectID.FindStringExact(tdbcObjectID.Text) = -1 Then
            tdbcObjectID.Text = ""
        End If
    End Sub

    Private Sub tdbcObjectID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcObjectID.KeyDown
        If e.KeyCode = Keys.F2 Then
            'Dim f As New D91F6010
            'f.InListID = "2"
            'f.InWhere = "ObjectTypeID LIKE " & SQLString(tdbcObjectTypeID.Text)
            'f.ShowDialog()
            'If f.OutPut01 <> "" Then tdbcObjectID.SelectedValue = f.OutPut01
            'f.Dispose()

            Try
                Dim arrPro() As StructureProperties = Nothing
                SetProperties(arrPro, "InListID", "2")
                SetProperties(arrPro, "InWhere", "ObjectTypeID LIKE" & SQLString(ReturnValueC1Combo(tdbcObjectTypeID)))
                Dim frm As Form = CallFormShowDialog("D91D0240", "D91F6010", arrPro)
                Dim sKey As String = GetProperties(frm, "Output01").ToString
                If sKey <> "" Then
                    'Load dữ liệu
                    Dim sOutput02 As String = GetProperties(frm, "Output02").ToString
                    tdbcObjectTypeID.SelectedValue = sOutput02
                    tdbcObjectID.SelectedValue = sKey
                End If
            Catch ex As Exception
                D99C0008.MsgL3(ex.Message)
            End Try
        End If
    End Sub

#End Region

    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click 'ID 94093 25/04/2017
        btnFilter.Focus()
        If btnFilter.Focused = False Then Exit Sub
        Me.Cursor = Cursors.WaitCursor

        LoadTDBGrid()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadTDBGrid()
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        sFind = ""
        '***************************
        Dim sSQL As String = "SELECT TOP 1 1 FROM D12T3400 WITH(NOLOCK)"
        Dim dtCheck As DataTable = ReturnDataTable(sSQL)
        If dtCheck.Rows.Count > 0 Then
            optYCMH.Visible = True
            optCTCT.Visible = True
        Else
            optYCMH.Visible = False
            optCTCT.Visible = False
        End If
        If optCTCT.Checked Then iRowChoose = -1
        '**************************
        dtGrid = ReturnDataTable(SQLStoreD12P3100)

        'Add 04/09/08
        If D12Options.ViewMyVoucher Then dtGrid = ReturnTableFilter(dtGrid, "CreateUserID = " & SQLString(gsUserID))
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()
    End Sub

    Private Sub optYCMH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optYCMH.Click, optCTCT.Click
        'LoadTDBGrid()'ID 94093 25/04/2017
    End Sub

    'ID 71854 21/1/2015
    Private Sub chkIsShowVoucherOver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIsShowVoucherOver.Click
        'LoadTDBGrid()'ID 94093 25/04/2017
        tdbg.Splits(1).DisplayColumns(COL_IsActivedOver).Visible = chkIsShowVoucherOver.Checked
        CallD99U1111(False, IIf(chkIsShowVoucherOver.Checked, 1, 0))
    End Sub

    Dim bHeadClick As Boolean
    Private Sub HeadClick(ByVal iCol As Integer)
        If tdbg.RowCount <= 0 Then Exit Sub
        Select Case tdbg.Columns(iCol).DataField
            Case COL_Choose
                If optCTCT.Checked Then Exit Sub
                L3HeadClick(tdbg, iCol, bHeadClick, IndexOfColumn(tdbg, COL_IsActivedOver), "False") 'Có trong D99X0000
            Case Else
                tdbg.AllowSort = True 'Nếu mặc định AllowSort = True
        End Select
    End Sub

#Region "tdbg"
    Dim iRowChoose As Integer = -1
    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán và giá trị phụ thuộc từ Dropdown
        Select Case tdbg.Columns(e.ColIndex).DataField
            Case COL_Choose
                If optCTCT.Checked Then
                    Dim dr() As DataRow = dtGrid.Select("PRID = " & SQLString(tdbg.Columns(COL_PRID).Text))
                    If dr.Length > 1 Then
                        For Each dr1 As DataRow In dr
                            dr1.Item(tdbg.Columns(COL_Choose).DataField) = L3Int(tdbg.Columns(COL_Choose).Text)
                        Next
                    End If
                End If
        End Select

        tdbg.UpdateData()
        ResetGrid()
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        Select Case tdbg.Columns(e.ColIndex).DataField
            Case COL_Choose
                If optCTCT.Checked Then
                    Dim dtTemp As DataTable = ReturnTableFilter(dtGrid, "Choose = 1", True)
                    If dtTemp.Rows.Count > 0 Then
                        If iRowChoose <> -1 And tdbg.Row <> iRowChoose Then
                            e.Cancel = True
                        Else
                            iRowChoose = tdbg.Row
                        End If
                    Else
                        iRowChoose = tdbg.Row
                    End If
                End If
            Case COL_POQuantity
                If Number(tdbg.Columns(COL_POQuantity).Text) > Number(tdbg.Columns(COL_RemainQuantity).Text) Then
                    D99C0008.MsgL3(rL3("So_luong") & " " & rL3("khong_duoc_phep_vuot_qua") & " " & rL3("So_luong_cho_phep"))
                    e.Cancel = True
                End If
            Case COL_PRDate, COL_DeliveryDate
                tdbg.Select()
        End Select
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
    End Sub

    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False
    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub
            FilterChangeGrid(tdbg, sFilter) 'Nếu có Lọc khi In
            ReLoadTDBGrid(True)
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If tdbg.FilterActive Then
            HotKeyCtrlVOnGrid(tdbg, e)
            Exit Sub
        End If

        If e.KeyCode = Keys.S And e.Control Then HeadClick(tdbg.Col)
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        If tdbg.Columns(tdbg.Col).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox Then
            e.Handled = CheckKeyPress(e.KeyChar)
        ElseIf tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far Then
            e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End If
    End Sub

    Private Sub tdbg_FetchCellStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles tdbg.FetchCellStyle
        Select Case tdbg.Columns(e.Col).DataField
            Case COL_Choose
                If L3Bool(tdbg(e.Row, COL_IsActivedOver)) Then
                    e.CellStyle.Locked = True
                    e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                End If
        End Select
    End Sub

#End Region

    Private Class MyObj
        Public ObjectID As String
        Public CurrencyID As String
        Public ExchangeRate As Double
    End Class

    Private Function SupplierCount(ByVal dr() As DataRow) As Integer
        Dim a As New ArrayList
        Dim iCount As Integer = 0

        For i As Integer = 0 To dr.Length - 1
            Dim bDup As Boolean = False
            For k As Integer = 0 To a.Count - 1
                Dim y As MyObj = CType(a.Item(k), MyObj)
                If dr(i).Item(COL_ObjectID).ToString = y.ObjectID And dr(i).Item(COL_CurrencyID).ToString = y.CurrencyID And Number(dr(i).Item(COL_ExchangeRate)) = y.ExchangeRate Then
                    bDup = True
                    Exit For
                End If
            Next k

            If bDup = False Then
                Dim x As New MyObj
                x.CurrencyID = dr(i).Item(COL_CurrencyID).ToString
                x.ExchangeRate = Number(dr(i).Item(COL_ExchangeRate))
                x.ObjectID = dr(i).Item(COL_ObjectID).ToString
                a.Add(x)
            End If
        Next i

        iCount = a.Count
        Return iCount
    End Function


#Region "Active Find - List All (Client)"
    Private WithEvents Finder As New D99C1001
    Dim gbEnabledUseFind As Boolean = False
    Private sFind As String = ""
    Public WriteOnly Property strNewFind() As String
        Set(ByVal Value As String)
            sFind = Value
            ReLoadTDBGrid() 'Làm giống sự kiện Finder_FindClick. Ví dụ đối với form Báo cáo thường gọi btnPrint_Click(Nothing, Nothing): sFind = "
        End Set
    End Property

    Private Sub tsbFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsFind.Click
        gbEnabledUseFind = True
        'Chuẩn hóa D09U1111 : Tìm kiếm dùng table caption có sẵn
        tdbg.UpdateData()

        'Những cột bắt buộc nhập
        Dim arrColObligatory() As Integer = {IndexOfColumn(tdbg, COL_Choose), IndexOfColumn(tdbg, COL_PRVoucherNo), IndexOfColumn(tdbg, COL_TransTypeName)}
        Dim Arr As New ArrayList
        For i As Integer = 0 To tdbg.Splits.Count - 1
            AddColVisible(tdbg, i, Arr, arrColObligatory, False, False, gbUnicode)
        Next
        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)

        ShowFindDialogClient(Finder, dtCaptionCols, Me, "0", gbUnicode) ' Dùng DLL 
    End Sub

    Private Sub tsbListAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsListAll.Click
        sFind = ""
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid(Optional bFilterBar As Boolean = False)
        Dim strFind As String = sFind
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString
        If strFind <> "" Then strFind = "(" & strFind & ") Or " & COL_Choose & " =1"

        dtGrid.DefaultView.RowFilter = strFind
        If bFilterBar Then FindText(tdbg) '14/12/2017, Lê Thị THu Thảo: id 105328-Hỗ trợ tính năng search tại màn hình lựa chọn nhà cung cấp và thực hiện yêu cầu mua hàng
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        CheckMenu(Me.Name, ContextMenuStrip1, tdbg.RowCount, gbEnabledUseFind)
        FooterTotalGrid(tdbg, COL_PRVoucherNo)
        FooterSumNew(tdbg, COL_OQuantity, COL_ApprovedQuantity, COL_RealizedQuantity, COL_RealizedCTQTY, COL_RemainQuantity, COL_POQuantity)
    End Sub
#End Region
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function AllowSave(ByRef dr() As DataRow) As Boolean
        tdbg.UpdateData()
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        dr = dtGrid.Select(COL_Choose & " = 1")
        If dr.Length < 1 Then
            D99C0008.MsgL3(rL3("MSG000010"))
            tdbg.Focus()
            tdbg.SplitIndex = SPLIT0
            tdbg.Col = IndexOfColumn(tdbg, COL_Choose)
            tdbg.Row = 0
            Return False
        End If

        For i As Integer = 0 To tdbg.RowCount - 1
            If Number(SQLNumber(tdbg(i, COL_POQuantity), DxxFormat.D07_QuantityDecimals)) > Number(SQLNumber(tdbg(i, COL_RemainQuantity), DxxFormat.D07_QuantityDecimals)) Then
                D99C0008.MsgL3(rL3("So_luong") & " " & rL3("khong_duoc_phep_vuot_qua") & " " & rL3("So_luong_cho_phep"))
                Return False
            End If
        Next i
        Return True
    End Function

    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        If usrOption Is Nothing Then Exit Sub 'TH lưới không có cột
        usrOption.Location = New Point(tdbg.Left, btnF12.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    'ID 73207 26/02/2015
    Private Function AllowCheck(ByVal dr() As DataRow) As Boolean
        Dim sSQL As New StringBuilder
        sSQL.Append(SQLDeleteD12T9009.ToString & vbCrLf)
        sSQL.Append(SQLInsertD12T9009s(dr).ToString & vbCrLf)
        sSQL.Append(SQLStoreD12P5555.ToString)
        Return CheckStore(sSQL.ToString)
    End Function

#Region "Menu"
    Private Sub mnsCreateVoucher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsCreateVoucher.Click
        Dim dr() As DataRow = Nothing 'Chỉ những dòng được chọn
        If Not AllowSave(dr) Then Exit Sub
        '**********************************
        For i As Integer = 0 To dr.Length - 1
            If Number(dr(i).Item(tdbg.Columns(COL_RealizedCTQTY).DataField)) > 0 Then
                D99C0008.MsgL3(rL3("Du_lieu_duoc_chon_da_lap_Hop_dong_Ban_khong_the_lap_Don_hang"))
                tdbg.Focus()
                tdbg.SplitIndex = 0
                tdbg.Col = IndexOfColumn(tdbg, COL_Choose)
                tdbg.Row = findrowInGrid(tdbg, tdbg.Columns(COL_PRTransactionID).Text, COL_PRTransactionID)
                Exit Sub
            End If
        Next i
        '**********************************
        Dim sSQL As New StringBuilder("")
        sSQL.Append(SQLDeleteD12T2040() & vbCrLf)
        sSQL.Append(SQLInsertD12T2040s(dr).ToString & vbCrLf)
        sSQL.Append(SQLDeleteD91T9009() & vbCrLf)
        sSQL.Append(SQLInsertD91T9009s(dr).ToString)
        If ExecuteSQL(sSQL.ToString) Then
            Dim bSavedOK As Boolean = False
            If chkIsAuto.Checked Then 'Tự động
                Dim f As New D12F3101
                f.SupplierCount = SupplierCount(dr)
                f.ShowDialog()
                bSavedOK = f.bSaved
                f.Dispose()
            Else
                'ID 73207 26/02/2015
                Dim sLastObjectTypeID As String = ""
                Dim sLastObjectID As String = ""
                Dim sLastObjectName As String = ""
                Dim sLastCurrency As String = ""
                Dim sLastVoucherDesc As String = ""
                Dim sPaymentMethodID As String = ""
                Dim bIsDifferent As Boolean = False

                'Lấy giá trị đầu tiên
                sLastObjectTypeID = dr(0).Item(COL_ObjectTypeID).ToString
                sLastObjectID = dr(0).Item(COL_ObjectID).ToString
                sLastObjectName = dr(0).Item(COL_ObjectName).ToString
                sLastCurrency = dr(0).Item(COL_CurrencyID).ToString
                sLastVoucherDesc = dr(0).Item(COL_Note).ToString
                sPaymentMethodID = dr(0).Item(COL_PaymentMethodID).ToString
                '***********************************
                For i As Integer = 0 To dr.Length - 1
                    If sLastObjectTypeID <> dr(i).Item(COL_ObjectTypeID).ToString OrElse _
                        sLastObjectID <> dr(i).Item(COL_ObjectID).ToString OrElse sLastCurrency <> dr(i).Item(COL_CurrencyID).ToString Then
                        bIsDifferent = True
                        Exit For
                    Else
                        sLastObjectTypeID = dr(i).Item(COL_ObjectTypeID).ToString
                        sLastObjectID = dr(i).Item(COL_ObjectID).ToString
                        sLastObjectName = dr(i).Item(COL_ObjectName).ToString
                        sLastCurrency = dr(i).Item(COL_CurrencyID).ToString
                        sLastVoucherDesc = dr(i).Item(COL_Note).ToString
                    End If
                Next i

                If bIsDifferent Then
                    D99C0008.MsgL3(rL3("Ban_phai_chon_du_lieu_cung_doi_tuong_loai_tien_phuong_thuc_thanh_toan_phuong_thuc_giao_hang_va_dieu_khoan_thuong_mai"), L3MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                '***********************
                'ID 73207 26/02/2015
                If AllowCheck(dr) = False Then Exit Sub
                '***********************
                If D12Systems.CreateDirectPO = 1 Then
                    Dim frm As New Lemon3.DxxMxx40
                    With frm
                        .exeName = "D06E2140"
                        .FormActive = "D06F2520"
                        .FormPermission = "D12F3120"
                        Dim sField() As String = {"CallFrom", "ModuleID", "IsAllowEditPO"} '19/6/2018, Đào Quỳnh Như:id 108229-[CTHV] Bổ sung cột Tổng tiền và cho phép sửa các cột tiền trên màn hình Lựa chọn nhà cung cấp
                        Dim sValue() As Object = {Me.Name, D12, D12Systems.IsAllowEditPO}
                        .IDxx(sField) = sValue
                        .OutputName = New String() {"Output01"}
                        .ShowDialog()
                        Dim output() As String = .OutputXX()
                        If output IsNot Nothing OrElse output.Length > 0 Then
                            bSavedOK = L3Bool(output(0))
                        End If
                        .Dispose()
                    End With
                Else
                    Dim sSupplyTransID As String = "'(''"
                    For i As Integer = 0 To dr.Length - 1
                        sSupplyTransID &= dr(i).Item(COL_SupplierTransID).ToString & "'',''"
                    Next i
                    sSupplyTransID &= "'')'"
                    sSupplyTransID = sSupplyTransID.Replace(",'''')", ")")
                    '***********************
                    Dim f As New D12F3110
                    f.POID = ""
                    f.PRTransactionID = sSupplyTransID
                    f.ObjectTypeID = sLastObjectTypeID
                    f.ObjectID = sLastObjectID
                    f.PaymentMethodID = sPaymentMethodID
                    f.Currency = sLastCurrency
                    f.VoucherDesc = sLastVoucherDesc
                    f.FormState = EnumFormState.FormAdd
                    f.ShowDialog()
                    bSavedOK = f.bSaved
                    f.Dispose()
                End If
            End If

            If bSavedOK Then LoadTDBGrid()
        End If
    End Sub

    Private Function CheckContinue(ByVal dr() As DataRow) As Boolean
        Dim sLastObjectTypeID As String = ""
        Dim sLastObjectID As String = ""
        Dim sLastObjectName As String = ""
        Dim sLastCurrency As String = ""
        Dim sLastVoucherDesc As String = ""
        Dim bIsDifferent As Boolean = False

        'Lấy giá trị đầu tiên
        sLastObjectTypeID = dr(0).Item(COL_ObjectTypeID).ToString
        sLastObjectID = dr(0).Item(COL_ObjectID).ToString
        sLastObjectName = dr(0).Item(COL_ObjectName).ToString
        sLastCurrency = dr(0).Item(COL_CurrencyID).ToString
        sLastVoucherDesc = dr(0).Item(COL_Note).ToString
        '****************************
        For i As Integer = 0 To dr.Length - 1
            If sLastObjectTypeID <> dr(i).Item(COL_ObjectTypeID).ToString OrElse _
                sLastObjectID <> dr(i).Item(COL_ObjectID).ToString OrElse sLastCurrency <> dr(i).Item(COL_CurrencyID).ToString Then
                bIsDifferent = True
                Exit For
            Else
                sLastObjectTypeID = dr(i).Item(COL_ObjectTypeID).ToString
                sLastObjectID = dr(i).Item(COL_ObjectID).ToString
                sLastObjectName = dr(i).Item(COL_ObjectName).ToString
                sLastCurrency = dr(i).Item(COL_CurrencyID).ToString
                sLastVoucherDesc = dr(i).Item(COL_Note).ToString
            End If
        Next i

        If bIsDifferent Then
            D99C0008.MsgL3(rL3("Ban_phai_chon_du_lieu_cung_doi_tuong_loai_tien_phuong_thuc_thanh_toan_phuong_thuc_giao_hang_va_dieu_khoan_thuong_mai"), L3MessageBoxIcon.Exclamation)
            Return False
        End If
        '***********************
        If AllowCheck(dr) = False Then Return False 'ID 73207 26/02/2015

        Return True
    End Function

    Private Sub CreateContract(ByVal sFormActive As String)
        Dim dr() As DataRow = Nothing 'Chỉ những dòng được chọn
        If Not AllowSave(dr) Then Exit Sub
        '*************************
        For i As Integer = 0 To dr.Length - 1
            If Number(dr(i).Item(tdbg.Columns(COL_RealizedQuantity).DataField)) > 0 Then
                D99C0008.MsgL3(rL3("Du_lieu_duoc_chon_da_lap_Don_hang_Ban_khong_the_lap_Hop_dong"))
                tdbg.Focus()
                tdbg.SplitIndex = 0
                tdbg.Col = IndexOfColumn(tdbg, COL_Choose)
                tdbg.Row = findrowInGrid(tdbg, tdbg.Columns(COL_PRTransactionID).Text, COL_PRTransactionID)
                Exit Sub
            End If
        Next i
        '*************************
        Dim sSQL As New StringBuilder("")
        sSQL.Append(SQLDeleteD12T2040() & vbCrLf)
        sSQL.Append(SQLInsertD12T2040s(dr).ToString & vbCrLf)
        sSQL.Append(SQLDeleteD91T9009() & vbCrLf)
        sSQL.Append(SQLInsertD91T9009s(dr).ToString)
        If ExecuteSQL(sSQL.ToString) Then
            If chkIsAuto.Checked Then  'Tự động
                Dim f As New D12F3101
                f.SupplierCount = SupplierCount(dr)
                f.ShowDialog()
                If f.bSaved Then LoadTDBGrid()
                f.Dispose()
            Else
                If CheckContinue(dr) = False Then Exit Sub
                '***********************
                Select Case sFormActive
                    Case "D49F2031"
                        'Update 10/12/2014: Gọi dll D49
                        Dim arrPro() As StructureProperties = Nothing
                        SetProperties(arrPro, "ModuleID", "12")
                        SetProperties(arrPro, "FormCall", Me.Name)
                        SetProperties(arrPro, "FormIDPermission", "D49F2031")
                        Dim frm As Form = CallFormShowDialog("D49D2140", "D49F2031", arrPro)
                        If L3Bool(GetProperties(frm, "bSaved")) Then LoadTDBGrid()
                    Case "D49F2032"
                        Dim arrPro() As StructureProperties = Nothing
                        SetProperties(arrPro, "ModuleID", "12")
                        SetProperties(arrPro, "FormCall", Me.Name)
                        SetProperties(arrPro, "FormIDPermission", "D49F2032")
                        Dim frm As Form = CallFormShowDialog("D49D2140", "D49F2032", arrPro)
                        If L3Bool(GetProperties(frm, "bSaved")) Then LoadTDBGrid()
                    Case "D49F2500" 'ID 80061 03/11/2016
                        Dim arrPro() As StructureProperties = Nothing
                        SetProperties(arrPro, "ModuleID", "12")
                        SetProperties(arrPro, "FormCall", Me.Name)
                        SetProperties(arrPro, "FormIDPermission", "D49F2500")
                        SetProperties(arrPro, "FormState", EnumFormState.FormAdd)
                        Dim frm As Form = CallFormShowDialog("D49D3040", "D49F2500", arrPro)
                        If L3Bool(GetProperties(frm, "bSaved")) Then LoadTDBGrid()
                End Select
            End If
        End If
    End Sub

    Private Sub mnsCreateContract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsCreateContract.Click
        CreateContract("D49F2032")
    End Sub

    Private Sub mnsCreateAvailableContract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsCreateAvailableContract.Click
        CreateContract("D49F2031")
    End Sub
#End Region

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD91T9009s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 21/01/2015 10:40:17
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD91T9009s(ByVal dr() As DataRow) As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder

        For i As Integer = 0 To dr.Length - 1
            If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Luu bang tam" & vbCrLf)
            sSQL.Append("Insert Into D91T9009(")
            sSQL.Append("UserID, HostID, Key01ID, Key02ID, Key03ID, " & vbCrLf)
            sSQL.Append("Num01, Num02, FormID")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NULL
            sSQL.Append(SQLString(dr(i).Item(COL_SupplierTransID)) & COMMA) 'Key01ID, nvarchar[1000], NULL
            sSQL.Append(SQLString(dr(i).Item(COL_PRID)) & COMMA) 'Key02ID, nvarchar[1000], NULL
            sSQL.Append(SQLString(dr(i).Item(COL_PRTransactionID)) & COMMA & vbCrLf) 'Key03ID, nvarchar[1000], NULL
            sSQL.Append(SQLMoney(dr(i).Item(COL_POQuantity), tdbg.Columns(COL_POQuantity).NumberFormat) & COMMA) 'Num01, decimal, NOT NULL
            sSQL.Append(SQLMoney(i + 1) & COMMA) 'Num02, decimal, NOT NULL
            sSQL.Append(SQLString(Me.Name)) 'FormID, varchar[50], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD12T2040s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 21/01/2015 10:54:34
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD12T2040s(ByVal dr() As DataRow) As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder

        For i As Integer = 0 To dr.Length - 1
            If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Luu D12T2040" & vbCrLf)
            sSQL.Append("Insert Into D12T2040(")
            sSQL.Append("UserID, SupplierTransID")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NULL
            sSQL.Append(SQLString(dr(i).Item(COL_SupplierTransID))) 'SupplierTransID, varchar[20], NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD12T2040
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 04/02/2008 02:46:58
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD12T2040() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D12T2040"
        sSQL &= " Where UserID = " & SQLString(gsUserID) & vbCrLf
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD12P3100
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 31/01/2008 04:57:23
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD12P3100() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load luoi" & vbCrLf)
        sSQL &= "Exec D12P3100 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcObjectTypeID)) & COMMA 'ObjectTypeID, varchar[20], NOT NULL
        sSQL &= SQLString(ReturnValueC1Combo(tdbcObjectID)) & COMMA 'ObjectID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'strFind, varchar[8000], NOT NULL
        sSQL &= SQLNumber(D12Systems.UseWorkflow) & COMMA 'UseWorkflow, int, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLNumber(IIf(optYCMH.Checked, 0, 1)) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLNumber(chkIsShowVoucherOver.Checked) 'IsShowVoucherOver, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD12T9009
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 26/02/2015 11:04:53
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD12T9009() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa bang tam D12T9009" & vbCrlf)
        sSQL &= "Delete From D12T9009"
        sSQL &= " Where "
        sSQL &= "UserID = " & SQLString(gsUserID) & " And "
        sSQL &= "HostID = " & SQLString(My.Computer.Name) & " And "
        sSQL &= "FormID = " & SQLString(Me.Name)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD12T9009s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 26/02/2015 11:05:42
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD12T9009s(ByVal dr() As DataRow) As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder

        For i As Integer = 0 To dr.Length - 1
            If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Insert bang tam D12T9009" & vbCrLf)
            sSQL.Append("Insert Into D12T9009(")
            sSQL.Append("UserID, HostID, FormID, Key01ID, Key02ID, " & vbCrLf)
            sSQL.Append("Key03ID")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[50], NOT NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[50], NOT NULL
            sSQL.Append(SQLString(Me.Name) & COMMA) 'FormID, varchar[50], NOT NULL
            sSQL.Append(SQLString(dr(i).Item(COL_SupplierTransID).ToString) & COMMA) 'Key01ID, nvarchar[1000], NOT NULL
            sSQL.Append(SQLString(dr(i).Item(COL_PRID).ToString) & COMMA & vbCrLf) 'Key02ID, nvarchar[1000], NOT NULL
            sSQL.Append(SQLString(dr(i).Item(COL_PRTransactionID).ToString)) 'Key03ID, nvarchar[1000], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD12P5555
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 26/02/2015 11:07:37
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD12P5555() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Kiem tra" & vbCrlf)
        sSQL &= "Exec D12P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[2], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key01ID, varchar[50], NOT NULL
        sSQL &= SQLString("") 'Key02ID, varchar[50], NOT NULL
        Return sSQL
    End Function

#Region "ID 80061 03/11/2016"
    Private Sub VisibleMenu()
        'ID 72931 07/04/2015
        Dim sSQL As String = "--Do nguon an hien menu lap hop dong" & vbCrLf
        sSQL &= "SELECT KindContract, IsUsed FROM D49T0030 WITH(NOLOCK) WHERE IsUsed = 1"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        Dim dr() As DataRow = dt.Select("KindContract = 'PO'")
        mnsCreateAvailableContract.Visible = dr.Length > 0 And ReturnPermission("D12F3122") >= EnumPermission.View 'ID 76845 20/07/2015 'Nếu tồn tại dòng dữ liệu có KindContract = ‘PO’ thì hiện menu Lập hợp đồng mua hàng, ngược lại nếu không tồn tại dòng nào có KindContract = ‘PO’ thì ẩn menu Lập hợp đồng mua hàng

        '***************************
        dr = dt.Select("KindContract = 'PPC'")
        mnsCreateContract.Visible = dr.Length > 0 And ReturnPermission("D12F3123") >= EnumPermission.View 'ID 76845 20/07/2015 'Nếu tồn tại dòng dữ liệu có KindContract = ‘PPC’ thì hiện menu Lập hợp đồng mua hàng (chuyên ngành BĐS), ngược lại nếu không tồn tại dòng nào có KindContract = ‘PPC’ thì ẩn menu Lập hợp đồng mua hàng (chuyên ngành BĐS)
        ToolStripSeparator1.Visible = mnsCreateContract.Visible
        '***************************
        mnsCreateVoucher.Visible = ReturnPermission("D12F3121") >= EnumPermission.View 'ID 76845 20/07/2015
        '***************************
        sSQL = "SELECT IsUsed FROM D49T0030 WITH(NOLOCK) WHERE KindContract = 'PCC'"
        tdbg.Splits(3).DisplayColumns(COL_IsContractRequisition).Visible = L3Bool(ReturnScalar(sSQL))
        mnsCreateRequisition.Visible = tdbg.Splits(3).DisplayColumns(COL_IsContractRequisition).Visible
        ToolStripSeparator2.Visible = tdbg.Splits(3).DisplayColumns(COL_IsContractRequisition).Visible
        '***************************
        sSQL = "SELECT IsUsed FROM D49T0030 WITH(NOLOCK) WHERE KindContract = 'POD06'"
        tdbg.Splits(3).DisplayColumns(COL_IsContract).Visible = L3Bool(ReturnScalar(sSQL))
        mnsCreateContractD06.Visible = tdbg.Splits(3).DisplayColumns(COL_IsContract).Visible
        ToolStripSeparator3.Visible = tdbg.Splits(3).DisplayColumns(COL_IsContract).Visible
    End Sub

    Private Sub CheckMenuOther()
        If tdbg.Splits(3).DisplayColumns(COL_IsContractRequisition).Visible = False AndAlso tdbg.Splits(3).DisplayColumns(COL_IsContract).Visible = False Then Exit Sub
        Dim bCreateContractD06 As Boolean = ReturnPermission("D12F5607") > 0
        Dim bCreateRequisition As Boolean = ReturnPermission("D12F5606") > 0
        '*****************************
        Dim dr() As DataRow = dtGrid.Select(COL_Choose & " = 1")
        If dr.Length > 0 Then
            ' Nếu (IsContractRequisition = 1 và IsContract = 0) hoặc (IsContractRequisition = 0 và IsContract = 0) : thì sáng menu Lập hợp đồng khung mua hàng, mờ menu Lập hợp đồng mua hàng (D06)
            'Nếu ((IsContractRequisition = 0 và IsContract = 1) hoặc (IsContractRequisition = 0 và IsContract = 0): thì mờ menu Lập hợp đồng khung mua hàng, sáng menu Lập hợp đồng mua hàng (D06)
            For i As Integer = 0 To dr.Length - 1
                If L3Bool(dr(i).Item(COL_IsContract)) = False AndAlso L3Bool(dr(i).Item(COL_IsContractRequisition)) Then
                    If bCreateRequisition Then bCreateRequisition = True
                    If bCreateContractD06 Then bCreateContractD06 = False
                ElseIf L3Bool(dr(i).Item(COL_IsContract)) AndAlso L3Bool(dr(i).Item(COL_IsContractRequisition)) = False Then
                    If bCreateRequisition Then bCreateRequisition = False
                    If bCreateContractD06 Then bCreateContractD06 = True
                End If
            Next
        End If

        mnsCreateRequisition.Enabled = bCreateRequisition
        mnsCreateContractD06.Enabled = bCreateContractD06
    End Sub

    Private Sub ContextMenuStrip1_Opened(ByVal sender As Object, ByVal e As System.EventArgs) Handles ContextMenuStrip1.Opened
        CheckMenuOther()
    End Sub

    Private Sub mnsCreateContractD06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsCreateContractD06.Click
        Dim dr() As DataRow = Nothing 'Chỉ những dòng được chọn
        If Not AllowSave(dr) Then Exit Sub
        '**********************************
        For i As Integer = 0 To dr.Length - 1
            If Number(dr(i).Item(tdbg.Columns(COL_RealizedCTQTY).DataField)) > 0 Then
                D99C0008.MsgL3(rL3("Du_lieu_duoc_chon_da_lap_Hop_dong_Ban_khong_the_lap_Don_hang"))
                tdbg.Focus()
                tdbg.SplitIndex = 0
                tdbg.Col = IndexOfColumn(tdbg, COL_Choose)
                tdbg.Row = findrowInGrid(tdbg, tdbg.Columns(COL_PRTransactionID).Text, COL_PRTransactionID)
                Exit Sub
            End If
        Next i
        '**********************************
        Dim sSQL As New StringBuilder("")
        sSQL.Append(SQLDeleteD12T2040() & vbCrLf)
        sSQL.Append(SQLInsertD12T2040s(dr).ToString & vbCrLf)
        sSQL.Append(SQLDeleteD91T9009() & vbCrLf)
        sSQL.Append(SQLInsertD91T9009s(dr).ToString)
        If ExecuteSQL(sSQL.ToString) Then
            Dim bSavedOK As Boolean = False
            If chkIsAuto.Checked Then 'Tự động
                Dim f As New D12F3101
                f.SupplierCount = SupplierCount(dr)
                f.ShowDialog()
                bSavedOK = f.bSaved
                f.Dispose()
            Else
                'ID 73207 26/02/2015
                Dim sLastObjectTypeID As String = ""
                Dim sLastObjectID As String = ""
                Dim sLastObjectName As String = ""
                Dim sLastCurrency As String = ""
                Dim sLastVoucherDesc As String = ""
                Dim sPaymentMethodID As String = ""
                Dim bIsDifferent As Boolean = False

                'Lấy giá trị đầu tiên
                sLastObjectTypeID = dr(0).Item(COL_ObjectTypeID).ToString
                sLastObjectID = dr(0).Item(COL_ObjectID).ToString
                sLastObjectName = dr(0).Item(COL_ObjectName).ToString
                sLastCurrency = dr(0).Item(COL_CurrencyID).ToString
                sLastVoucherDesc = dr(0).Item(COL_Note).ToString
                sPaymentMethodID = dr(0).Item(COL_PaymentMethodID).ToString
                '***********************************
                For i As Integer = 0 To dr.Length - 1
                    If sLastObjectTypeID <> dr(i).Item(COL_ObjectTypeID).ToString OrElse _
                        sLastObjectID <> dr(i).Item(COL_ObjectID).ToString OrElse sLastCurrency <> dr(i).Item(COL_CurrencyID).ToString Then
                        bIsDifferent = True
                        Exit For
                    Else
                        sLastObjectTypeID = dr(i).Item(COL_ObjectTypeID).ToString
                        sLastObjectID = dr(i).Item(COL_ObjectID).ToString
                        sLastObjectName = dr(i).Item(COL_ObjectName).ToString
                        sLastCurrency = dr(i).Item(COL_CurrencyID).ToString
                        sLastVoucherDesc = dr(i).Item(COL_Note).ToString
                    End If
                Next i

                If bIsDifferent Then
                    D99C0008.MsgL3(rL3("Ban_phai_chon_du_lieu_cung_doi_tuong_loai_tien_phuong_thuc_thanh_toan_phuong_thuc_giao_hang_va_dieu_khoan_thuong_mai"), L3MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                '***********************
                'ID 73207 26/02/2015
                If AllowCheck(dr) = False Then Exit Sub
                '***********************
                Dim frm As New Lemon3.DxxMxx40
                With frm
                    .exeName = "D06E2040"
                    .FormActive = "D06F2420"
                    Dim sField() As String = {"CallFormID", "ModuleID"}
                    Dim sValue() As Object = {Me.Name, D12}
                    .IDxx(sField) = sValue
                    .OutputName = New String() {"Output01"}
                    .ShowDialog()
                    Dim output() As String = .OutputXX()
                    If output IsNot Nothing OrElse output.Length > 0 Then
                        bSavedOK = L3Bool(output(0))
                    End If
                    .Dispose()
                End With
            End If

            If bSavedOK Then LoadTDBGrid()
        End If
    End Sub

    Private Sub mnsCreateRequisition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnsCreateRequisition.Click
        CreateContract("D49F2500")
    End Sub
#End Region


    


    
End Class
