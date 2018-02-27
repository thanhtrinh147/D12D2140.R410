Imports System.Windows.Forms
Imports System
'#-------------------------------------------------------------------------------------
'# Created Date: 31/10/2008 2:25:46 PM
'# Created User: Đỗ Minh Dũng
'# Modify Date: 31/10/2008 2:25:46 PM
'# Modify User: Đỗ Minh Dũng
'#-------------------------------------------------------------------------------------
Public Class D12F3110
	Dim report As D99C2003
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

    Dim sEditTransTypeID As String = ""
    Dim sEditVoucherTypeID As String = ""
    Dim dtLCNo As DataTable
    Const UseD54 As String = "UseD54" 'Field trên combo Loại nghiệp vụ


#Region "Const of tdbg - Total of Columns: 93"
    Private Const COL_POID As Integer = 0              ' POID
    Private Const COL_POItemID As Integer = 1          ' POItemID
    Private Const COL_PRID As Integer = 2              ' PRID
    Private Const COL_PRTransactionID As Integer = 3   ' PRTransactionID
    Private Const COL_SupplierTransID As Integer = 4   ' SupplierTransID
    Private Const COL_OrderNum As Integer = 5          ' STT
    Private Const COL_InventoryID As Integer = 6       ' Mã hàng
    Private Const COL_InventoryName As Integer = 7     ' Tên hàng
    Private Const COL_OInventoryName As Integer = 8    ' OInventoryName
    Private Const COL_ObjectID As Integer = 9          ' ObjectID
    Private Const COL_ObjectName As Integer = 10       ' ObjectName
    Private Const COL_Spec01ID As Integer = 11         ' Spec01ID
    Private Const COL_Spec02ID As Integer = 12         ' Spec02ID
    Private Const COL_Spec03ID As Integer = 13         ' Spec03ID
    Private Const COL_Spec04ID As Integer = 14         ' Spec04ID
    Private Const COL_Spec05ID As Integer = 15         ' Spec05ID
    Private Const COL_Spec06ID As Integer = 16         ' Spec06ID
    Private Const COL_Spec07ID As Integer = 17         ' Spec07ID
    Private Const COL_Spec08ID As Integer = 18         ' Spec08ID
    Private Const COL_Spec09ID As Integer = 19         ' Spec09ID
    Private Const COL_Spec10ID As Integer = 20         ' Spec10ID
    Private Const COL_PRVoucherNo As Integer = 21      ' Số phiếu YCMH
    Private Const COL_ProjectID As Integer = 22        ' Mã dự án
    Private Const COL_ProjectName As Integer = 23      ' Tên dự án
    Private Const COL_TaskID As Integer = 24           ' Mã hạng mục
    Private Const COL_TaskName As Integer = 25         ' Tên hạng mục
    Private Const COL_UnitID As Integer = 26           ' ĐVT
    Private Const COL_PROQuantity As Integer = 27      ' Số lượng duyệt
    Private Const COL_RemainOQuantity As Integer = 28  ' Số lượng còn lại
    Private Const COL_OQuantity As Integer = 29        ' Số lượng
    Private Const COL_CQuantity As Integer = 30        ' Số lượng QĐ
    Private Const COL_D06OQuantity As Integer = 31     ' SL chuyển module Mua hàng
    Private Const COL_D06CQuantity As Integer = 32     ' SL Quy đổi chuyển module Mua hàng
    Private Const COL_UnitPrice As Integer = 33        ' Đơn giá
    Private Const COL_OAmount As Integer = 34          ' Thành tiền NT
    Private Const COL_CAmount As Integer = 35          ' Thành tiền QĐ
    Private Const COL_NoName01 As Integer = 36         ' NoName01
    Private Const COL_VATGroupID As Integer = 37       ' Nhóm thuế
    Private Const COL_RateTax As Integer = 38          ' Thuế suất GTGT
    Private Const COL_VATOAmount As Integer = 39       ' Tiền thuế NT
    Private Const COL_VATCAmount As Integer = 40       ' Tiền thuế QĐ
    Private Const COL_StartDate As Integer = 41        ' Ngày bắt đầu
    Private Const COL_DExpectDate As Integer = 42      ' Ngày nhận hàng
    Private Const COL_ExpiryDate As Integer = 43       ' Ngày hết hạn
    Private Const COL_WarehouseID As Integer = 44      ' Mã kho
    Private Const COL_DetailDesc As Integer = 45       ' Diễn giải chi tiết
    Private Const COL_Ana01ID As Integer = 46          ' Ana01ID
    Private Const COL_Ana02ID As Integer = 47          ' KM 02
    Private Const COL_Ana03ID As Integer = 48          ' KM 03
    Private Const COL_Ana04ID As Integer = 49          ' KM 04
    Private Const COL_Ana05ID As Integer = 50          ' KM 05
    Private Const COL_Ana06ID As Integer = 51          ' KM 06
    Private Const COL_Ana07ID As Integer = 52          ' KM 07
    Private Const COL_Ana08ID As Integer = 53          ' KM 08
    Private Const COL_Ana09ID As Integer = 54          ' KM 09
    Private Const COL_Ana10ID As Integer = 55          ' KM 10
    Private Const COL_NoName03 As Integer = 56         ' NoName03
    Private Const COL_MPSVoucherID As Integer = 57     ' MPSVoucherID
    Private Const COL_MPSVoucherNo As Integer = 58     ' Kế hoạch sản xuất
    Private Const COL_PeriodID As Integer = 59         ' Kỳ sản xuất
    Private Const COL_ProductID As Integer = 60        ' Sản phẩm
    Private Const COL_LocationNo As Integer = 61       ' Số lô
    Private Const COL_IsPromotion As Integer = 62      ' IsPromotion
    Private Const COL_CurrencyID As Integer = 63       ' CurrencyID
    Private Const COL_ExchangeRate As Integer = 64     ' ExchangeRate
    Private Const COL_Operator As Integer = 65         ' Operator
    Private Const COL_NoName04 As Integer = 66         ' NoName04
    Private Const COL_NRef1 As Integer = 67            ' NRef1
    Private Const COL_NRef2 As Integer = 68            ' NRef2
    Private Const COL_NRef3 As Integer = 69            ' NRef3
    Private Const COL_NRef4 As Integer = 70            ' NRef4
    Private Const COL_NRef5 As Integer = 71            ' NRef5
    Private Const COL_VRef1 As Integer = 72            ' VRef1
    Private Const COL_VRef2 As Integer = 73            ' VRef2
    Private Const COL_VRef3 As Integer = 74            ' VRef3
    Private Const COL_VRef4 As Integer = 75            ' VRef4
    Private Const COL_VRef5 As Integer = 76            ' VRef5
    Private Const COL_DRef1 As Integer = 77            ' DRef1
    Private Const COL_DRef2 As Integer = 78            ' DRef2
    Private Const COL_DRef3 As Integer = 79            ' DRef3
    Private Const COL_DRef4 As Integer = 80            ' DRef4
    Private Const COL_DRef5 As Integer = 81            ' DRef5
    Private Const COL_Spec01Name As Integer = 82       ' Spec01Name
    Private Const COL_Spec02Name As Integer = 83       ' Spec02Name
    Private Const COL_Spec03Name As Integer = 84       ' Spec03Name
    Private Const COL_Spec04Name As Integer = 85       ' Spec04Name
    Private Const COL_Spec05Name As Integer = 86       ' Spec05Name
    Private Const COL_Spec06Name As Integer = 87       ' Spec06Name
    Private Const COL_Spec07Name As Integer = 88       ' Spec07Name
    Private Const COL_Spec08Name As Integer = 89       ' Spec08Name
    Private Const COL_Spec09Name As Integer = 90       ' Spec09Name
    Private Const COL_Spec10Name As Integer = 91       ' Spec10Name
    Private Const COL_ConversionFactor As Integer = 92 ' ConversionFactor
#End Region

    Private _status As String = ""
    Public WriteOnly Property Status() As String
        Set(ByVal Value As String)
            _status = Value
        End Set
    End Property

    Private _objectTypeID As String = ""
    Public WriteOnly Property ObjectTypeID() As String
        Set(ByVal Value As String)
            _objectTypeID = Value
        End Set
    End Property

    Private _objectID As String = ""
    Public WriteOnly Property ObjectID() As String
        Set(ByVal Value As String)
            _objectID = Value
        End Set
    End Property

    Private _PaymentMethodID As String = ""
    Public WriteOnly Property PaymentMethodID() As String
        Set(ByVal Value As String)
            _PaymentMethodID = Value
        End Set
    End Property

    Private _currency As String = ""
    Public WriteOnly Property Currency() As String
        Set(ByVal Value As String)
            _currency = Value
        End Set
    End Property

    Private _voucherDesc As String = ""
    Public Property VoucherDesc() As String
        Get
            Return _voucherDesc
        End Get
        Set(ByVal Value As String)
            _voucherDesc = Value
        End Set
    End Property

    Dim bAna As Boolean
    Dim iLastCol As Integer
    Dim bUseSpec As Boolean
    Dim iPerD12F5812 As Integer = 0
    Dim iPerD12F3120 As Integer = 0
    Dim dtGrid As DataTable

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value

            Loadlanguage() 'ID 96376 01/08/2017
            iPerD12F5812 = ReturnPermission("D12F5812")
            iPerD12F3120 = ReturnPermission("D12F3120")
            tdbcObjectTypeID.Tag = ""
            tdbg.Columns(COL_StartDate).Tag = False

            bUseSpec = LoadTDBGridSpecificationCaption(tdbg, COL_Spec01ID, SPLIT0, True, gbUnicode)
            LoadTDBGridAnalysisCaption("D12", tdbg, COL_Ana01ID, SPLIT1, , gbUnicode)

            tdbg_NumberFormat()
            LoadTDBDropDown()
            Select Case _FormState
                Case EnumFormState.FormAdd
                    LoadTDBCombo()
                    LoadAddNew()
                    tdbcCurrencyID_SelectedValueChanged(Nothing, Nothing) 'Thực hiện tính lai thành tiền NT và thành tiền QĐ
                Case EnumFormState.FormEdit
                    LoadEdit()
                Case EnumFormState.FormView
                    btnSave.Enabled = False
                    LoadEdit()
            End Select

        End Set
    End Property

    Private _pOID As String = ""
    Public Property POID() As String
        Get
            Return _pOID
        End Get
        Set(ByVal Value As String)
            _pOID = Value
        End Set
    End Property

    Private _pRTransactionID As String = ""
    Public Property PRTransactionID() As String
        Get
            Return _pRTransactionID
        End Get
        Set(ByVal Value As String)
            _pRTransactionID = Value
        End Set
    End Property

    Private Sub D12F3110b_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
       
        If _FormState = EnumFormState.FormEdit Or _FormState = EnumFormState.FormEditOther Then
            If Not _bSaved Then
                If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
            End If
        ElseIf _FormState = EnumFormState.FormAdd Then

            If btnSave.Enabled Then
                If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
            End If
        End If
    End Sub

    Private Sub D12F3110_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If _FormState = EnumFormState.FormAdd Then
            If tdbcTransTypeID.GetItemText(0, "TransTypeID") <> "" And tdbcTransTypeID.GetItemText(1, "TransTypeID") = "" Then
                tdbcTransTypeID.SelectedIndex = 0
                tdbcVoucherTypeID.Focus()
            End If
        End If

    End Sub

    Private Sub D12F3110b_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me)
        End Select
    End Sub

    Private Sub D12F3110b_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If bLoadFormState = False Then FormState = _FormState
        Me.Cursor = Cursors.WaitCursor
        SetBackColorObligatory()
        tdbg_LockedColumns()
        ResetXCheckAna()
        ResetFooterGrid(tdbg, 0, 1)
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtVoucherNo)
        tdbcStatusID.Enabled = ReturnPermission("D12F3110") >= EnumPermission.Add
        EnableCheck()
        PostedD06_Change()
        InputDateInTrueDBGrid(tdbg, COL_StartDate, COL_DExpectDate, COL_ExpiryDate, COL_DRef1, COL_DRef2, COL_DRef3, COL_DRef4, COL_DRef5)
        ' Gắn các Dropdown
        tdbg.Columns(COL_Ana01ID).DropDown = tdbdAna01ID
        tdbg.Columns(COL_Ana02ID).DropDown = tdbdAna02ID
        tdbg.Columns(COL_Ana03ID).DropDown = tdbdAna03ID
        tdbg.Columns(COL_Ana04ID).DropDown = tdbdAna04ID
        tdbg.Columns(COL_Ana05ID).DropDown = tdbdAna05ID
        tdbg.Columns(COL_Ana06ID).DropDown = tdbdAna06ID
        tdbg.Columns(COL_Ana07ID).DropDown = tdbdAna07ID
        tdbg.Columns(COL_Ana08ID).DropDown = tdbdAna08ID
        tdbg.Columns(COL_Ana09ID).DropDown = tdbdAna09ID
        tdbg.Columns(COL_Ana10ID).DropDown = tdbdAna10ID
        '*******************************
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub EnableCheck()
        chkPostedD06.Enabled = iPerD12F5812 > 1 And ReturnValueC1Combo(tdbcStatusID).ToString = "0"
        If chkPostedD06.Enabled = False And (iPerD12F5812 >= 2) Then chkPostedD06.Checked = False
        If iPerD12F5812 < 2 Then grpPostedD06.Enabled = False
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Lap_don_dat_hang_-_D12F3110") & UnicodeCaption(gbUnicode) 'LËp ¢¥n ¢Æt hªng - D12F3110
        '================================================================ 
        lblVoucherTypeID.Text = rl3("Loai_phieu") 'Loại phiếu
        lblVoucherNo.Text = rl3("So_phieu") 'Số phiếu
        lblteVoucherDate.Text = rl3("Ngay_phieu") 'Ngày phiếu
        lblObjectTypeID.Text = rl3("Nha_cung_cap") 'Nhà cung cấp
        lblStatusID.Text = rl3("Trang_thai") 'Trạng thái
        lblCurrencyID.Text = rl3("Loai_tien") 'Loại tiền
        lblExchangeRate.Text = rl3("Ty_gia") 'Tỷ giá
        lblteExpectDate.Text = rl3("Ngay_nhan_hang") 'Ngày nhận hàng
        lbltePaymentDate.Text = rl3("Ngay_thanh_toan") 'Ngày thanh toán
        lblShipAddressID.Text = rl3("Noi_nhan_hang") 'Nơi nhận hàng
        lblReceiptPersonID.Text = rl3("Nguoi_nhan_hang") 'Người nhận hàng
        lblEmployeeID.Text = rl3("Nguoi_lap") 'Người lập
        lblVoucherDesc.Text = rl3("Dien_giai") 'Diễn giải
        lblPaymentMethodID.Text = rl3("PTTT") 'PTTT
        lblPaymentTermID.Text = rl3("DKTM") 'ĐKTM
        lblD06VourcherTypeID.Text = rl3("Loai_phieu") 'Loại phiếu
        lblD06VoucherNo.Text = rl3("So_phieu") 'Số phiếu
        lblTransTypeID.Text = rl3("Loai_nghiep_vu") 'Loại nghiệp vụ
        lblDeliveryID.Text = rl3("PT_giao_hang") 'PT giao hàng
        lblLCNo.Text = rl3("So_LC")
        lblVoucherDesc.Text = rl3("Dien_giai") 'Diễn giải
        lblNote.Text = rl3("Ghi_chu")
        lblteValidDateFrom.Text = rL3("Hieu_luc")
        lblD06DocNo.Text = rL3("So_chung_tu") 'Số chứng từ
        lblD06DocDate.Text = rL3("Ngay_chung_tu") 'Ngày chứng từ
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        btnAdditionalInfo.Text = rl3("Thong_tin_bo_sung") 'Thông tin bổ sung
        btnMain.Text = "&1. " & rl3("Thong_tin_chinh") 'Thông tin chính
        btnAna.Text = "&2. " & rl3("Khoan_muc") 'Khoản mục
        btnOther.Text = "&3. " & rl3("Khac") 'Khác
        btnSub.Text = "&4. " & rl3("Thong_tin_phu") 'Thông tin phụ
        btnPrint.Text = rl3("_In") '&In
        btnReference.Text = rl3("Thong_tin_tham_khao") 'Thông tin tham khảo
        btnHotKey.Text = rl3("_Phim_nong") '&Phím nóng
        '================================================================ 
        chkPick.Text = rl3("Giu_cho") 'Giữ chỗ
        chkPostedD06.Text = rl3("Chuyen_Module_mua_hang") 'Chuyển module mua hàng
        chkIsLC.Text = rl3("Bat_buoc_mo_LC") 'Bắt buộc mở L/C
        '================================================================ 
        optTypePostedD06_1.Text = rl3("Hop_dong") 'Hợp đồng
        optTypePostedD06_0.Text = rl3("Don_dat_hang_D12") 'Đơn đặt hàng
        '================================================================ 
        tdbcVoucherTypeID.Columns("VoucherTypeID").Caption = rl3("Ma") 'Mã
        tdbcVoucherTypeID.Columns("VoucherTypeName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcObjectTypeID.Columns("ObjectTypeID").Caption = rl3("Ma") 'Mã
        tdbcObjectTypeID.Columns("ObjectTypeName").Caption = rl3("Ten") 'Tên
        tdbcObjectID.Columns("ObjectID").Caption = rl3("Ma") 'Mã
        tdbcObjectID.Columns("ObjectName").Caption = rl3("Ten") 'Tên
        tdbcStatusID.Columns("StatusID").Caption = rl3("Ma") 'Mã
        tdbcStatusID.Columns("StatusName").Caption = rl3("Ten") 'Tên
        tdbcCurrencyID.Columns("CurrencyID").Caption = rl3("Ma") 'Mã
        tdbcCurrencyID.Columns("CurrencyName").Caption = rl3("Ten") 'Tên
        tdbcShipAddressID.Columns("ShipAddressID").Caption = rl3("Ma") 'Mã
        tdbcShipAddressID.Columns("ShipAddressName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcShipAddressID.Columns("ShipAddress").Caption = rl3("Dia_chi") 'Địa chỉ
        tdbcReceiptPersonID.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbcReceiptPersonID.Columns("EmployeeName").Caption = rl3("Ten") 'Tên
        tdbcEmployeeID.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbcEmployeeID.Columns("EmployeeName").Caption = rl3("Ten") 'Tên
        tdbcPaymentMethodID.Columns("PaymentMethodID").Caption = rl3("Ma") 'Mã
        tdbcPaymentMethodID.Columns("PaymentMethodName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcPaymentTermID.Columns("PaymentTermID").Caption = rl3("Ma") 'Mã
        tdbcPaymentTermID.Columns("PaymentTermName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcD06VoucherTypeID.Columns("VoucherTypeID").Caption = rl3("Ma") 'Mã
        tdbcD06VoucherTypeID.Columns("VoucherTypeName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcDeliveryID.Columns("DeliveryID").Caption = rl3("Ma") 'Mã
        tdbcDeliveryID.Columns("DeliveryName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcTransTypeID.Columns("TransTypeID").Caption = rl3("Ma") 'Mã
        tdbcTransTypeID.Columns("TransTypeName").Caption = rL3("Ten") 'Tên
        tdbcLCNo.Columns("LCNo").Caption = rL3("Ma")
        tdbcLCNo.Columns("LCDesc").Caption = rL3("Dien_giai")
        '================================================================ 
        tdbdLocationNo.Columns("LocationNo").Caption = rL3("So_lo") 'Số lô
        tdbdLocationNo.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbdProductID.Columns("InventoryID").Caption = rl3("Ma") 'Mã 
        tdbdProductID.Columns("InventoryName").Caption = rl3("Ten") 'Tên 
        tdbdProductID.Columns("UnitID").Caption = rl3("DVT") 'ĐVT
        tdbdPeriodID.Columns("PeriodID").Caption = rl3("Ma") 'Mã
        tdbdPeriodID.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbdMPSVoucherNo.Columns("MPSVoucherNo").Caption = rl3("Ke_hoach_san_xuat") 'Kế hoạch sản xuất
        tdbdMPSVoucherNo.Columns("MPSDescription").Caption = rl3("Dien_giai") 'Diễn giải
        tdbdVATGroupID.Columns("VATGroupID").Caption = rl3("Ma") 'Mã
        tdbdVATGroupID.Columns("VATGroupName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbdWareHouseID.Columns("WareHouseID").Caption = rl3("Ma") 'Mã
        tdbdWareHouseID.Columns("WareHouseName").Caption = rL3("Ten") 'Tên
        tdbdAna06ID.Columns("AnaID").Caption = rL3("Ma") 'Mã khoản mục
        tdbdAna06ID.Columns("AnaName").Caption = rL3("Ten") 'Tên khoản mục
        tdbdAna05ID.Columns("AnaID").Caption = rL3("Ma") 'Mã khoản mục
        tdbdAna05ID.Columns("AnaName").Caption = rL3("Ten") 'Tên khoản mục
        tdbdAna03ID.Columns("AnaID").Caption = rL3("Ma") 'Mã khoản mục
        tdbdAna03ID.Columns("AnaName").Caption = rL3("Ten") 'Tên khoản mục
        tdbdAna01ID.Columns("AnaID").Caption = rL3("Ma") 'Mã khoản mục
        tdbdAna01ID.Columns("AnaName").Caption = rL3("Ten") 'Tên khoản mục
        tdbdAna10ID.Columns("AnaID").Caption = rL3("Ma") 'Mã khoản mục
        tdbdAna10ID.Columns("AnaName").Caption = rL3("Ten") 'Tên khoản mục
        tdbdAna07ID.Columns("AnaID").Caption = rL3("Ma") 'Mã khoản mục
        tdbdAna07ID.Columns("AnaName").Caption = rL3("Ten") 'Tên khoản mục
        tdbdAna04ID.Columns("AnaID").Caption = rL3("Ma") 'Mã khoản mục
        tdbdAna04ID.Columns("AnaName").Caption = rL3("Ten") 'Tên khoản mục
        tdbdAna02ID.Columns("AnaID").Caption = rL3("Ma") 'Mã khoản mục
        tdbdAna02ID.Columns("AnaName").Caption = rL3("Ten") 'Tên khoản mục
        tdbdAna08ID.Columns("AnaID").Caption = rL3("Ma") 'Mã khoản mục
        tdbdAna08ID.Columns("AnaName").Caption = rL3("Ten") 'Tên khoản mục
        tdbdAna09ID.Columns("AnaID").Caption = rL3("Ma") 'Mã khoản mục
        tdbdAna09ID.Columns("AnaName").Caption = rL3("Ten") 'Tên khoản mục
        tdbdSpec10ID.Columns("SpecID").Caption = rL3("Ma") 'Mã
        tdbdSpec10ID.Columns("SpecName").Caption = rL3("Ten") 'Tên
        tdbdSpec09ID.Columns("SpecID").Caption = rL3("Ma") 'Mã
        tdbdSpec09ID.Columns("SpecName").Caption = rL3("Ten") 'Tên
        tdbdSpec08ID.Columns("SpecID").Caption = rL3("Ma") 'Mã
        tdbdSpec08ID.Columns("SpecName").Caption = rL3("Ten") 'Tên
        tdbdSpec07ID.Columns("SpecID").Caption = rL3("Ma") 'Mã
        tdbdSpec07ID.Columns("SpecName").Caption = rL3("Ten") 'Tên
        tdbdSpec06ID.Columns("SpecID").Caption = rL3("Ma") 'Mã
        tdbdSpec06ID.Columns("SpecName").Caption = rL3("Ten") 'Tên
        tdbdSpec05ID.Columns("SpecID").Caption = rL3("Ma") 'Mã
        tdbdSpec05ID.Columns("SpecName").Caption = rL3("Ten") 'Tên
        tdbdSpec04ID.Columns("SpecID").Caption = rL3("Ma") 'Mã
        tdbdSpec04ID.Columns("SpecName").Caption = rL3("Ten") 'Tên
        tdbdSpec03ID.Columns("SpecID").Caption = rL3("Ma") 'Mã
        tdbdSpec03ID.Columns("SpecName").Caption = rL3("Ten") 'Tên
        tdbdSpec02ID.Columns("SpecID").Caption = rL3("Ma") 'Mã
        tdbdSpec02ID.Columns("SpecName").Caption = rL3("Ten") 'Tên
        tdbdSpec01ID.Columns("SpecID").Caption = rL3("Ma") 'Mã
        tdbdSpec01ID.Columns("SpecName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("OrderNum").Caption = rl3("STT") 'STT
        tdbg.Columns("InventoryID").Caption = rl3("_Ma_hang") 'Mã hàng
        tdbg.Columns("InventoryName").Caption = rL3("Ten_hang") 'Tên hàng
        tdbg.Columns(COL_PRVoucherNo).Caption = rL3("So_phieu_YCMH") 'Số phiếu YCMH
        tdbg.Columns("UnitID").Caption = rl3("DVT") 'ĐVT
        tdbg.Columns("PROQuantity").Caption = rl3("So_luong_duyet") 'Số lượng duyệt
        tdbg.Columns("OQuantity").Caption = rl3("So_luong") 'Số lượng
        tdbg.Columns("CQuantity").Caption = rl3("So_luong_QD") 'Số lượng QĐ
        tdbg.Columns("D06OQuantity").Caption = rl3("SL_chuyen_module_Mua_hang") 'SL chuyển module Mua hàng
        tdbg.Columns("D06CQuantity").Caption = rl3("SL_Quy_doi_chuyen_module_Mua_hang") 'SL Quy đổi chuyển module Mua hàng
        tdbg.Columns("UnitPrice").Caption = rl3("Don_gia") 'Đơn giá
        tdbg.Columns("OAmount").Caption = rl3("Thanh_tien_NT") 'Thành tiền NT
        tdbg.Columns("CAmount").Caption = rl3("Thanh_tien_QD") 'Thành tiền QĐ
        tdbg.Columns("VATGroupID").Caption = rl3("Nhom_thue") 'Nhóm thuế
        tdbg.Columns("RateTax").Caption = rl3("Thue_suat_GTGT") 'Thuế suất GTGT
        tdbg.Columns("VATOAmount").Caption = rl3("Tien_thue_NT") 'Tiền thuế NT
        tdbg.Columns("VATCAmount").Caption = rl3("Tien_thue_QD") 'Tiền thuế QĐ
        tdbg.Columns("StartDate").Caption = rl3("Ngay_bat_dau") 'Ngày bắt đầu
        tdbg.Columns("DExpectDate").Caption = rl3("Ngay_nhan_hang") 'Ngày nhận hàng
        tdbg.Columns("ExpiryDate").Caption = rl3("Ngay_het_han") 'Ngày hết hạn
        tdbg.Columns("WarehouseID").Caption = rl3("Ma_kho") 'Mã kho
        tdbg.Columns("DetailDesc").Caption = rl3("Dien_giai_chi_tiet") 'Diễn giải chi tiết
        tdbg.Columns("MPSVoucherNo").Caption = rl3("Ke_hoach_san_xuat") 'Kế hoạch sản xuất
        tdbg.Columns("PeriodID").Caption = rl3("Ky_san_xuat") 'Kỳ sản xuất
        tdbg.Columns("ProductID").Caption = rl3("San_pham") 'Sản phẩm
        tdbg.Columns("LocationNo").Caption = rl3("So_lo") 'Số lô
        tdbg.Columns("RemainOQuantity").Caption = rL3("So_luong_con_lai")
        tdbg.Columns(COL_ProjectID).Caption = rL3("Cong_trinh") 'Dự án
        tdbg.Columns(COL_ProjectName).Caption = rL3("Ten_du_an1") 'Tên dự án
        tdbg.Columns(COL_TaskID).Caption = rL3("Hang_muc")
        tdbg.Columns(COL_TaskName).Caption = rL3("Ten_hang_muc1")
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcTransTypeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcVoucherTypeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtVoucherNo.BackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateVoucherDate.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcObjectTypeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcObjectID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcStatusID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcCurrencyID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcEmployeeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        cneExchangeRate.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcD06VoucherTypeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtD06VoucherNo.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub LoadTDBGrid()
        dtGrid = ReturnDataTable(SQLStoreD12P3115)
        LoadDataSource(tdbg, dtGrid, gbUnicode)

        ' 2012-02-23 Đổ giá trị mặc định cho combo điều khoản thương mại
        If dtGrid IsNot Nothing AndAlso dtGrid.Rows.Count > 0 Then
            If tdbcPaymentTermID.Text = "" Then tdbcPaymentTermID.SelectedValue = dtGrid.Rows(0)("PaymentTermID").ToString
            If tdbcDeliveryID.Text = "" Then tdbcDeliveryID.SelectedValue = dtGrid.Rows(0)("DeliveryID").ToString
        End If

        For i As Integer = 0 To tdbg.RowCount - 1
            tdbg(i, COL_OrderNum) = i + 1
            If tdbg(i, COL_StartDate).ToString <> "" Then tdbg.Columns(COL_StartDate).Tag = True
        Next i
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        tdbg.UpdateData()
        FooterTotalGrid(tdbg, COL_InventoryID)
        FooterSumNew(tdbg, COL_OQuantity, COL_CQuantity, COL_D06OQuantity, COL_D06CQuantity, COL_OAmount, COL_CAmount, COL_VATOAmount, COL_VATCAmount)
    End Sub

    Private Sub tdbg_NumberFormat()
        InputNumber(cneExchangeRate, SqlDbType.Decimal, DxxFormat.ExchangeRateDecimals, False, 28, 8)
        '*********************************
        Dim arr() As FormatColumn = Nothing
        AddDecimalColumns(arr, tdbg.Columns(COL_PROQuantity).DataField, DxxFormat.D07_QuantityDecimals, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_RemainOQuantity).DataField, DxxFormat.D07_QuantityDecimals, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_OQuantity).DataField, DxxFormat.D07_QuantityDecimals, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_CQuantity).DataField, DxxFormat.D07_QuantityDecimals, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_D06OQuantity).DataField, DxxFormat.D07_QuantityDecimals, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_D06CQuantity).DataField, DxxFormat.D07_QuantityDecimals, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_UnitPrice).DataField, DxxFormat.D07_UnitCostDecimals, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_OAmount).DataField, DxxFormat.DecimalPlaces, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_CAmount).DataField, DxxFormat.D90_ConvertedDecimals, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_VATOAmount).DataField, DxxFormat.DecimalPlaces, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_VATCAmount).DataField, DxxFormat.D90_ConvertedDecimals, 28, 8)

        'AddDecimalColumns(arr, tdbg.Columns(COL_RateTax).DataField, DxxFormat.DefaultNumber2, 28, 8)
        AddPercentColumns(arr, tdbg.Columns(COL_RateTax).DataField) 'Cột tỷ lệ %
        InputNumber(tdbg, arr)
    End Sub

    Private Sub LoadEdit()
        tdbcTransTypeID.Enabled = False
        tdbcVoucherTypeID.Enabled = False
        txtVoucherNo.Enabled = False
        'Thêm từ MH vb6
        tdbcObjectTypeID.Enabled = False
        tdbcObjectID.Enabled = False

        LoadEditData()
        TransTypeID_LostFocus()

        If _status = "Status" Then
            txtVoucherDesc.Enabled = False
            txtNote.Enabled = False
            tdbcShipAddressID.Enabled = False
            c1dateVoucherDate.Enabled = False
            tdbcEmployeeID.Enabled = False
            c1dateExpectDate.Enabled = False
            tdbcReceiptPersonID.Enabled = False
            tdbcPaymentMethodID.Enabled = False
            c1datePaymentDate.Enabled = False
            tdbcCurrencyID.Enabled = False
            cneExchangeRate.Enabled = False
            chkPick.Enabled = False
            tdbcStatusID.SelectedValue = 0

            tdbg.Splits(1).DisplayColumns(COL_DExpectDate).Locked = True
            tdbg.Splits(1).DisplayColumns(COL_WarehouseID).Locked = True
            tdbg.Splits(1).DisplayColumns(COL_DExpectDate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(1).DisplayColumns(COL_WarehouseID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(1).DisplayColumns(COL_OAmount).Locked = True
            tdbg.Splits(1).DisplayColumns(COL_CAmount).Locked = True
            tdbg.Splits(1).DisplayColumns(COL_OAmount).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(1).DisplayColumns(COL_CAmount).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        End If
    End Sub

    Private Sub LoadEditData()
        Dim sSQL As String = ""
        sSQL = "--Do nguon cho Master" & vbCrLf
        sSQL &= "Select POID, DivisionID, TranMonth, TranYear, VoucherTypeID"
        sSQL &= ", VoucherNo, VoucherDate, ExpectDate, VoucherDesc" & UnicodeJoin(gbUnicode) & " as VoucherDesc, EmployeeID"
        sSQL &= ", ObjectTypeID, ObjectID, ShipAddressID, CurrencyID, ExchangeRate"
        sSQL &= ", Pick, PostedD06, POStatus, CreateUserID, CreateDate"
        sSQL &= ", LastModifyUserID, LastModifyDate, PaymentDate, PaymentMethodID, ReceiptPersonID" & vbCrLf
        sSQL &= ", ReceiptPerson" & UnicodeJoin(gbUnicode) & " as ReceiptPerson, PaymentTermID, MStr01" & UnicodeJoin(gbUnicode) & " as MStr01, MStr02" & UnicodeJoin(gbUnicode) & " as MStr02, MStr03" & UnicodeJoin(gbUnicode) & " as MStr03"
        sSQL &= ", MStr04" & UnicodeJoin(gbUnicode) & " as MStr04, MStr05" & UnicodeJoin(gbUnicode) & " as MStr05, MStr06" & UnicodeJoin(gbUnicode) & " as MStr06, MStr07" & UnicodeJoin(gbUnicode) & " as MStr07, MStr08" & UnicodeJoin(gbUnicode) & " as MStr08"
        sSQL &= ", MStr09" & UnicodeJoin(gbUnicode) & " as MStr09, MStr10" & UnicodeJoin(gbUnicode) & " as MStr10, MNum01, MNum02, MNum03"
        sSQL &= ", MNum04, MNum05, MNum06, MNum07, MNum08" & vbCrLf
        sSQL &= ", MNum09, MNum10, MDat01, MDat02, MDat03"
        sSQL &= ", MDat04, MDat05, MDat06, MDat07, MDat08"
        sSQL &= ", MDat09, MDat10, TransTypeID, IsLC, TypePostedD06"
        sSQL &= ", DeliveryID, D06VoucherTypeID, D06VoucherNo, D06DocNo, D06DocDate, LCNo, Notes" & UnicodeJoin(gbUnicode) & " as Notes"
        sSQL &= ", ValidDateFrom, ValidDateTo" & vbCrLf
        sSQL &= "FROM D12T2050 WITH(NOLOCK) WHERE POID = " & SQLString(_pOID)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                bRunValueChange = False
                sEditTransTypeID = .Item("TransTypeID").ToString
                sEditVoucherTypeID = .Item("VoucherTypeID").ToString
                '*********************************
                LoadTDBCombo()
                tdbcTransTypeID.SelectedValue = .Item("TransTypeID")
                tdbcVoucherTypeID.SelectedValue = .Item("VoucherTypeID").ToString
                txtVoucherNo.Text = .Item("VoucherNo").ToString
                c1dateVoucherDate.Value = SQLDateShow(.Item("VoucherDate"))

                tdbcObjectTypeID.SelectedValue = .Item("ObjectTypeID").ToString
                tdbcObjectTypeID_LostFocus(Nothing, Nothing)
                tdbcObjectID.SelectedValue = .Item("ObjectID").ToString
                tdbcObjectID_LostFocus(Nothing, Nothing)
                tdbcStatusID.SelectedValue = .Item("POStatus").ToString
                tdbcStatusID_LostFocus(Nothing, Nothing)
                '******************************
                tdbcCurrencyID.SelectedValue = .Item("CurrencyID").ToString
                cneExchangeRate.Value = Number(.Item("ExchangeRate"))
                ResetStringFormat(, False, False)
                '******************************
                c1dateExpectDate.Value = SQLDateShow(.Item("ExpectDate"))
                c1datePaymentDate.Value = SQLDateShow(.Item("PaymentDate"))
                tdbcShipAddressID.Text = .Item("ShipAddressID").ToString
                tdbcReceiptPersonID.SelectedValue = .Item("ReceiptPersonID")
                tdbcEmployeeID.SelectedValue = .Item("EmployeeID")
                txtVoucherDesc.Text = .Item("VoucherDesc").ToString
                tdbcPaymentMethodID.SelectedValue = .Item("PaymentMethodID")
                tdbcPaymentTermID.SelectedValue = .Item("PaymentTermID")
                tdbcDeliveryID.SelectedValue = .Item("DeliveryID")
                txtNote.Text = .Item("Notes").ToString
                Select Case Number(.Item("TypePostedD06"))
                    Case 0
                        optTypePostedD06_0.Checked = True
                    Case 1
                        optTypePostedD06_1.Checked = True
                End Select

                chkPostedD06.Checked = L3Bool(.Item("PostedD06"))
                PostedD06_Change()
                chkPick.Checked = L3Bool(.Item("Pick"))
                chkIsLC.Checked = L3Bool(.Item("IsLC"))
                tdbcLCNo.SelectedValue = .Item("LCNo")
                tdbcD06VoucherTypeID.SelectedValue = .Item("D06VoucherTypeID")
                txtD06VoucherNo.Text = .Item("D06VoucherNo").ToString
                txtD06DocNo.Text = .Item("D06DocNo").ToString 'ID 90240 29/09/2017
                c1dateD06DocDate.Value = SQLDateShow(.Item("D06DocDate")) 'ID 90240 29/09/2017
                c1dateValidDateFrom.Value = SQLDateShow(.Item("ValidDateFrom"))
                c1dateValidDateTo.Value = SQLDateShow(.Item("ValidDateTo"))
            End With
            _pRTransactionID = "'('''')'"
            LoadTDBGrid()
        End If
        Format_WhenCurrencyIDChange()
        bRunValueChange = True
    End Sub

    Private Sub LoadAddNew()

        btnPrint.Enabled = False
        btnAdditionalInfo.Enabled = False

        c1dateExpectDate.Value = Now.Date
        c1datePaymentDate.Value = Now.Date

        tdbcStatusID.SelectedIndex = 0
        tdbcObjectTypeID.SelectedValue = _objectTypeID
        tdbcObjectTypeID_LostFocus(Nothing, Nothing)
        tdbcObjectID.SelectedValue = _objectID

        tdbcCurrencyID.SelectedValue = _currency
        tdbcPaymentMethodID.SelectedValue = _PaymentMethodID
        txtVoucherDesc.Text = _voucherDesc

        PostedD06_Change()

        LoadTDBGrid()
        ChangeButtonClick(ButtonForGrid.Main)

        'Thêm từ MH vb6
        If ReturnPermission("D12F3111") > EnumPermission.View Then
            tdbcObjectTypeID.Enabled = True
            tdbcObjectID.Enabled = True
        Else
            tdbcObjectTypeID.Enabled = False
            tdbcObjectID.Enabled = False
        End If
    End Sub

    Dim dtPaymentMothod As DataTable
    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcTransTypeID
        LoadTdbcTransTypeID(tdbcTransTypeID, "1", sEditTransTypeID)

        'Load tdbcVoucherTypeID
        LoadVoucherTypeID(tdbcVoucherTypeID, tdbcD06VoucherTypeID, D12, sEditVoucherTypeID, gbUnicode)

        'Load tdbcObjectTypeID
        LoadObjectTypeID(tdbcObjectTypeID, gbUnicode)

        'Load tdbcObjectID
        sSQL = " Select	ObjectID , ObjectName" & UnicodeJoin(gbUnicode) & " as ObjectName ,ObjectTypeID " & vbCrLf
        sSQL &= " 	From 	Object WITH(NOLOCK) " & vbCrLf
        sSQL &= " 	Where 	 Disabled = 0 " & vbCrLf
        sSQL &= " 	Order by 	ObjectID " & vbCrLf
        dtObjectID = ReturnDataTable(sSQL)

        'Load tdbcStatusID
        sSQL = " Select StatusID, StatusName" & UnicodeJoin(gbUnicode) & " as StatusName " & vbCrLf
        sSQL &= "  From D06V0002 " & vbCrLf
        sSQL &= "  Where UsedD12 = 1  AND Language = " & SQLString(gsLanguage) & vbCrLf
        sSQL &= "  ORDER BY NO"
        LoadDataSource(tdbcStatusID, sSQL, gbUnicode)

        'Load tdbcCurrencyID
        '*Update 5/4/2013 theo ID 55530 của Thị Ni bởi Văn Vinh
        'Do hàm chuẩn không có trường PurchasePriceDecimals nên copy câu SQL ra đây để thêm vào.
        ' LoadCurrencyID(tdbcCurrencyID, gbUnicode)
        sSQL = "Select CurrencyID, CurrencyName" & UnicodeJoin(gbUnicode) & " As CurrencyName, ExchangeRate, Operator, MethodID, OriginalDecimal, ExchangeRateDecimal, UnitPriceDecimals, PurchasePriceDecimals  "
        sSQL &= "From D91V0010 "
        sSQL &= "Where Disabled =0 "
        sSQL &= "Order By CurrencyID "
        LoadDataSource(tdbcCurrencyID, sSQL, gbUnicode)
        '***************************************
        'Load tdbcShipAddressID
        sSQL = " Select  ObjectID as ShipAddressID, ObjectName" & UnicodeJoin(gbUnicode) & " as ShipAddressName, ObjectAddress" & UnicodeJoin(gbUnicode) & " As ShipAddress" & vbCrLf
        sSQL &= " From Object WITH(NOLOCK) " & vbCrLf
        sSQL &= " Where ObjectTypeID ='DV' And Disabled=0" & vbCrLf
        sSQL &= " Order By ObjectID" & vbCrLf
        LoadDataSource(tdbcShipAddressID, sSQL, gbUnicode)

        'load tdbcEmployeeID
        Dim dt As DataTable = ReturnTableCreateBy(gbUnicode)
        LoadCboCreateBy(tdbcEmployeeID, dt, gbUnicode)
        'Load tdbcReceiptPersonID
        LoadDataSource(tdbcReceiptPersonID, dt.Copy, gbUnicode)

        'Load tdbcPaymentTermID
        sSQL = " Select 	PaymentTermID, PaymentTermName" & UnicodeJoin(gbUnicode) & " as PaymentTermName" & vbCrLf
        sSQL &= " 	From	D91T0082 WITH(NOLOCK) " & vbCrLf
        sSQL &= " 	Where	Disabled = 0" & vbCrLf
        sSQL &= " 	Order by	PaymentTermID" & vbCrLf
        LoadDataSource(tdbcPaymentTermID, sSQL, gbUnicode)

        'Load tdbcPaymentMethodID
        sSQL = " Select 	PaymentMethodID, PaymentMethodName" & UnicodeJoin(gbUnicode) & " as PaymentMethodName" & vbCrLf
        sSQL &= " 	From	D91T0080 WITH(NOLOCK) " & vbCrLf
        sSQL &= " 	Where	Disabled = 0" & vbCrLf
        sSQL &= " 	Order by	PaymentMethodID" & vbCrLf
        dtPaymentMothod = ReturnDataTable(sSQL)
        LoadDataSource(tdbcPaymentMethodID, dtPaymentMothod, gbUnicode)

        'Load tdbcDeliveryID
        sSQL = "Select DeliveryID, Description" & UnicodeJoin(gbUnicode) & " as DeliveryName" & vbCrLf
        sSQL &= "From D91T0081 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled = 0" & vbCrLf
        sSQL &= "Order by DeliveryID" & vbCrLf
        LoadDataSource(tdbcDeliveryID, sSQL, gbUnicode)

        'Load tdbcLCNo
        sSQL = "Select LCNo, LCDesc" & UnicodeJoin(gbUnicode) & " as LCDesc, ObjectTypeID, ObjectID" & vbCrLf
        sSQL &= "From D91T1020 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled = 0 " & vbCrLf
        dtLCNo = ReturnDataTable(sSQL)
    End Sub

    Private Sub ChangeButtonClick(ByVal WhichButton As ButtonForGrid)
        With tdbg.Splits(SPLIT1)
            Select Case WhichButton
                Case ButtonForGrid.Main
                    btnMain.Enabled = False
                    btnAna.Enabled = L3Bool(btnAna.Tag)
                    btnOther.Enabled = True
                    btnSub.Enabled = L3Bool(btnSub.Tag)

                    AllColOfButtonMain(True)

                    For i As Integer = 0 To 9
                        .DisplayColumns(COL_Ana01ID + i).Visible = False
                    Next i

                    For i As Integer = 0 To 14
                        .DisplayColumns(COL_NRef1 + i).Visible = False
                    Next i

                    .DisplayColumns(COL_MPSVoucherNo).Visible = False
                    .DisplayColumns(COL_PeriodID).Visible = False
                    .DisplayColumns(COL_ProductID).Visible = False
                    .DisplayColumns(COL_LocationNo).Visible = False

                Case ButtonForGrid.Ana
                    btnMain.Enabled = True
                    btnAna.Enabled = False
                    btnOther.Enabled = True
                    btnSub.Enabled = L3Bool(btnSub.Tag)

                    AllColOfButtonMain(False)

                    For i As Integer = 0 To 9
                        .DisplayColumns(COL_Ana01ID + i).Visible = L3Bool(tdbg.Columns(COL_Ana01ID + i).Tag)
                    Next i

                    For i As Integer = 0 To 14
                        .DisplayColumns(COL_NRef1 + i).Visible = False
                    Next i

                    .DisplayColumns(COL_MPSVoucherNo).Visible = False
                    .DisplayColumns(COL_PeriodID).Visible = False
                    .DisplayColumns(COL_ProductID).Visible = False
                    .DisplayColumns(COL_LocationNo).Visible = False

                Case ButtonForGrid.Other
                    btnMain.Enabled = True
                    btnAna.Enabled = L3Bool(btnAna.Tag)
                    btnOther.Enabled = False
                    btnSub.Enabled = L3Bool(btnSub.Tag)

                    AllColOfButtonMain(False)

                    For i As Integer = 0 To 9
                        .DisplayColumns(COL_Ana01ID + i).Visible = False
                    Next i

                    For i As Integer = 0 To 14
                        .DisplayColumns(COL_NRef1 + i).Visible = False
                    Next i

                    .DisplayColumns(COL_MPSVoucherNo).Visible = True
                    .DisplayColumns(COL_PeriodID).Visible = True
                    .DisplayColumns(COL_ProductID).Visible = True
                    .DisplayColumns(COL_LocationNo).Visible = True


                Case ButtonForGrid.SubInfo
                    btnMain.Enabled = True
                    btnAna.Enabled = L3Bool(btnAna.Tag)
                    btnOther.Enabled = True
                    btnSub.Enabled = False

                    AllColOfButtonMain(False)

                    For i As Integer = 0 To 9
                        .DisplayColumns(COL_Ana01ID + i).Visible = False
                    Next i

                    For i As Integer = 0 To 14
                        .DisplayColumns(COL_NRef1 + i).Visible = L3Bool(tdbg.Columns(COL_NRef1 + i).Tag)
                    Next i

                    .DisplayColumns(COL_MPSVoucherNo).Visible = False
                    .DisplayColumns(COL_PeriodID).Visible = False
                    .DisplayColumns(COL_ProductID).Visible = False
                    .DisplayColumns(COL_LocationNo).Visible = False

            End Select
        End With

        iLastCol = CountCol(tdbg, SPLIT1)
    End Sub

    Private Sub AllColOfButtonMain(ByVal bVisible As Boolean)
        With tdbg.Splits(SPLIT1)
            .DisplayColumns(COL_UnitID).Visible = bVisible
            .DisplayColumns(COL_PROQuantity).Visible = bVisible
            .DisplayColumns(COL_OQuantity).Visible = bVisible
            .DisplayColumns(COL_CQuantity).Visible = bVisible And L3Bool(tdbg.Columns(COL_CQuantity).Tag)
            .DisplayColumns(COL_UnitPrice).Visible = bVisible
            .DisplayColumns(COL_OAmount).Visible = bVisible
            .DisplayColumns(COL_CAmount).Visible = bVisible And L3Bool(tdbg.Columns(COL_CAmount).Tag)
            .DisplayColumns(COL_VATGroupID).Visible = bVisible
            .DisplayColumns(COL_RateTax).Visible = bVisible
            .DisplayColumns(COL_VATOAmount).Visible = bVisible
            .DisplayColumns(COL_VATCAmount).Visible = bVisible
            .DisplayColumns(COL_StartDate).Visible = bVisible And L3Bool(tdbg.Columns(COL_StartDate).Tag)
            .DisplayColumns(COL_DExpectDate).Visible = bVisible
            .DisplayColumns(COL_ExpiryDate).Visible = bVisible
            .DisplayColumns(COL_WarehouseID).Visible = bVisible
            .DisplayColumns(COL_DetailDesc).Visible = bVisible
            .DisplayColumns(COL_D06OQuantity).Visible = bVisible And chkPostedD06.Checked
            .DisplayColumns(COL_D06CQuantity).Visible = bVisible And chkPostedD06.Checked
        End With
        '****************************
        VisibleProjectID(bVisible) 'ID 90240 06/09/2016
    End Sub

    Private Sub VisibleProjectID(ByVal bVisible As Boolean) 'ID 90240 06/09/2016
        Dim bUseD54 As Boolean = L3Bool(ReturnValueC1Combo(tdbcTransTypeID, UseD54))
        tdbg.Splits(1).DisplayColumns(COL_ProjectID).Visible = bVisible AndAlso bUseD54
        tdbg.Splits(1).DisplayColumns(COL_ProjectName).Visible = bVisible AndAlso bUseD54
        tdbg.Splits(1).DisplayColumns(COL_TaskID).Visible = bVisible AndAlso bUseD54
        tdbg.Splits(1).DisplayColumns(COL_TaskName).Visible = bVisible AndAlso bUseD54
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_OrderNum).Locked = True
        tdbg.Splits(SPLIT0).DisplayColumns(COL_InventoryID).Locked = True
        tdbg.Splits(SPLIT0).DisplayColumns(COL_InventoryName).Locked = True
        tdbg.Splits(SPLIT1).DisplayColumns(COL_UnitID).Locked = True

        tdbg.Splits(SPLIT1).DisplayColumns(COL_UnitID).Locked = True
        tdbg.Splits(SPLIT1).DisplayColumns(COL_PROQuantity).Locked = True

        'y/c Lan Huong rem 18/05/09
        'y/c Lan Huong Mở rem 30/06/09
        tdbg.Splits(SPLIT1).DisplayColumns(COL_OQuantity).Locked = True
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CQuantity).Locked = True

        tdbg.Splits(SPLIT1).DisplayColumns(COL_RemainOQuantity).Locked = True

        tdbg.Splits(SPLIT1).DisplayColumns(COL_RateTax).Locked = True
        tdbg.Splits(SPLIT1).DisplayColumns(COL_D06CQuantity).Locked = True

        tdbg.Splits(SPLIT0).DisplayColumns(COL_OrderNum).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_InventoryID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_InventoryName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_UnitID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)

        tdbg.Splits(SPLIT1).DisplayColumns(COL_UnitID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_PROQuantity).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_RemainOQuantity).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_OQuantity).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_CQuantity).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)

        tdbg.Splits(SPLIT1).DisplayColumns(COL_RateTax).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_D06CQuantity).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_StartDate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_ProjectID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_ProjectName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_TaskID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_TaskName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)

        LockColumSpec(True)

        tdbg.Splits(SPLIT0).DisplayColumns(COL_PRVoucherNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub LockColumSpec(ByVal IsLock As Boolean)
        For i As Integer = COL_Spec01ID To COL_Spec10ID
            tdbg.Splits(SPLIT0).DisplayColumns(i).Locked = IsLock
            tdbg.Splits(SPLIT0).DisplayColumns(i).Button = Not L3Bool(tdbg.Splits(SPLIT0).DisplayColumns(i).Locked)
            If IsLock Then
                tdbg.Splits(SPLIT0).DisplayColumns(i).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            Else
                tdbg.Splits(SPLIT0).DisplayColumns(i).Style.ResetBackColor()
            End If
        Next
    End Sub

    Private Sub LoadTdbdLocationNo()
        Dim sSQL As String = ""
        'Load tdbdLocationNo
        sSQL = "SELECT '+' AS LocationNo, " & NewName & " AS Description, 0 AS DisplayOrder" & vbCrLf
        sSQL &= "UNION " & vbCrLf
        sSQL &= "Select LocationNo, Description" & UnicodeJoin(gbUnicode) & " as Description, 1 AS DisplayOrder FROM D07T1210 WITH(NOLOCK) WHERE Disabled=0 ORDER BY DisplayOrder, LocationNo"
        LoadDataSource(tdbdLocationNo, sSQL, gbUnicode)

    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""

        sSQL = "SELECT InventoryID, InventoryName" & UnicodeJoin(gbUnicode) & " as InventoryName " & vbCrLf
        sSQL &= " FROM D07T0002 WITH(NOLOCK) " & vbCrLf
        sSQL &= "   WHERE Disabled = 0 And IsService = 0" & vbCrLf
        sSQL &= "   ORDER BY InventoryID"
        LoadDataSource(tdbdProductID, sSQL, gbUnicode)

        'Load tdbdMPSVoucherNo 
        sSQL = " Select VoucherNo As MPSVoucherNo, " & vbCrLf
        sSQL &= " MPSDescription" & UnicodeJoin(gbUnicode) & " as MPSDescription, " & vbCrLf
        sSQL &= " MPSVoucherID " & vbCrLf
        sSQL &= " From 		D30T2010 WITH(NOLOCK) " & vbCrLf
        sSQL &= " Where Disabled = 0 And DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        sSQL &= " Order By 		VoucherNo"
        LoadDataSource(tdbdMPSVoucherNo, sSQL, gbUnicode)


        'Load tdbdLocationNo
        LoadTdbdLocationNo()

        sSQL = " Select 	PeriodID , Note" & UnicodeJoin(gbUnicode) & " as Description" & vbCrLf
        sSQL &= " From	 D08T0100 WITH(NOLOCK) " & vbCrLf
        sSQL &= " WHERE 	DivisionID = " & SQLString(gsDivisionID) & " And IsDistribute = 0 And Disabled = 0 " & vbCrLf
        sSQL &= " ORDER BY PeriodID" & vbCrLf
        LoadDataSource(tdbdPeriodID, sSQL, gbUnicode)

        sSQL = " Select 	WareHouseID, WareHouseName" & UnicodeJoin(gbUnicode) & " as WareHouseName " & vbCrLf
        sSQL &= " From 	D07T0007 WITH(NOLOCK) " & vbCrLf
        sSQL &= " Where	 Disabled=0 AND DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        sSQL &= " Order By 	WareHouseID" & vbCrLf
        LoadDataSource(tdbdWareHouseID, sSQL, gbUnicode)


        sSQL = " Select  	VATGroupID, VATGroupName" & UnicodeJoin(gbUnicode) & " as VATGroupName, " & vbCrLf
        sSQL &= " 		convert(varchar(20), RateTax * 100)+ '%'  as RateTax" & vbCrLf
        sSQL &= " 	From 	D91T0040 WITH(NOLOCK) " & vbCrLf
        sSQL &= " 	Where 	Disabled = 0" & vbCrLf
        sSQL &= " 	Order by	RateTax" & vbCrLf
        LoadDataSource(tdbdVATGroupID, sSQL, gbUnicode)

        'Load tdbdAna01ID
        LoadTDBDropDownAna(tdbdAna01ID, tdbdAna02ID, tdbdAna03ID, tdbdAna04ID, tdbdAna05ID, tdbdAna06ID, tdbdAna07ID, tdbdAna08ID, tdbdAna09ID, tdbdAna10ID, tdbg, COL_Ana01ID, gbUnicode, True)

        'Load tdbdSpec01ID
        LoadTDBDropDownSpecification(tdbdSpec01ID, tdbdSpec02ID, tdbdSpec03ID, tdbdSpec04ID, tdbdSpec05ID, tdbdSpec06ID, tdbdSpec07ID, tdbdSpec08ID, tdbdSpec09ID, tdbdSpec10ID, tdbg, COL_Spec01ID, gbUnicode, True)
    End Sub

    Private Sub LocationNo_Task()
        If tdbg.Columns(COL_LocationNo).Text = "+" Then
            tdbg.Columns(COL_LocationNo).Text = ""

            If ReturnPermission("D07F1210") < EnumPermission.Add Then
                MsgNoPermissionAdd()
            Else
                'Dim f As New D07F1211
                'f.ShowDialog()
                'Dim sNewLocationNo As String = f.Out_LocationNo
                'f.Dispose()
                'ID 82568 04/12/2015
                Dim sNewLocationNo As String = Lemon3.D07.AddNewLocation
                If sNewLocationNo <> "" Then
                    LoadTdbdLocationNo()
                    tdbg.Columns(COL_LocationNo).Text = sNewLocationNo
                Else
                    tdbg.Columns(COL_LocationNo).Text = ""
                End If
            End If
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If tdbcTransTypeID.Text = "" And _FormState = EnumFormState.FormAdd Then tdbcTransTypeID.Focus() : Exit Sub
        Me.Close()
    End Sub

    Private Sub HeadClick_Task()
        tdbg.UpdateData()
        Select Case tdbg.Col
            Case COL_InventoryID, COL_InventoryName, COL_StartDate
                tdbg.AllowSort = True
            Case COL_DExpectDate, COL_WarehouseID, COL_MPSVoucherNo, COL_PeriodID, COL_ProductID, COL_LocationNo, COL_Ana01ID To COL_Ana10ID, COL_NRef1 To COL_DRef5, COL_DetailDesc
                tdbg.AllowSort = False
                CopyColumns(tdbg, tdbg.Col, tdbg.Columns(tdbg.Col).Text, tdbg.Row)
            Case COL_VATGroupID
                tdbg.AllowSort = False
                CopyColumns(tdbg, tdbg.Col, tdbg.Row, 2, tdbg.Columns(tdbg.Col).Text)

                For i As Integer = 0 To tdbg.RowCount - 1
                    CalVATOAmount(i)
                    CalVATCAmount(i)
                Next i
                ResetGrid()
        End Select
    End Sub

#Region "tdbg"
    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        tdbg.Col = e.ColIndex
        HeadClick_Task()
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        tdbg.UpdateData()
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL_VATGroupID, COL_WarehouseID, COL_PeriodID, COL_ProductID, COL_LocationNo
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                End If
            Case COL_Spec01ID, COL_Spec02ID, COL_Spec03ID, COL_Spec04ID, COL_Spec05ID, COL_Spec06ID, COL_Spec07ID, COL_Spec08ID, COL_Spec09ID, COL_Spec10ID
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns("SpecID").Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    tdbg.Columns(tdbg.Columns(e.ColIndex).DataField.Replace("ID", "Name")).Text = ""
                End If
            Case COL_Ana01ID To COL_Ana10ID
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns("AnaID").Text Then
                    If gbArrAnaValidate(L3Int(tdbg.Columns(e.ColIndex).DataField.Substring(3, 2)) - 1) Then 'Kiểm tra nhập trong danh sách
                        tdbg.Columns(e.ColIndex).Text = ""
                    Else
                        If tdbg.Columns(e.ColIndex).Text.Length > giArrAnaLength(L3Int(tdbg.Columns(e.ColIndex).DataField.Substring(3, 2)) - 1) Then ' Kiểm tra chiều dài nhập vào
                            tdbg.Columns(e.ColIndex).Text = ""
                        End If
                    End If
                End If
            Case COL_MPSVoucherNo
                If tdbg.Columns(COL_MPSVoucherNo).Text <> tdbdMPSVoucherNo.Columns(0).Text Then
                    tdbg.Columns(COL_MPSVoucherNo).Text = ""
                    tdbg.Columns(COL_MPSVoucherID).Text = ""
                End If
            Case COL_OQuantity
                If Number(tdbg.Columns(COL_OQuantity).Text) > Number(tdbg.Columns(COL_RemainOQuantity).Text) Then
                    D99C0008.MsgL3(rL3("So_luong_khong_duoc_phep_vuot_qua_so_luong_con_lai"))
                    e.Cancel = True
                End If
            Case COL_D06OQuantity
                If chkPostedD06.Checked AndAlso Number(tdbg.Columns(e.ColIndex).Text) = 0 Then
                    D99C0008.MsgL3(rL3("So_luong_chuyen_sang_module_mua_hang_phai_lon_hon_0"))
                    tdbg.Columns(e.ColIndex).Text = ""
                    tdbg.Columns(COL_D06CQuantity).Text = ""
                End If
            Case COL_VATGroupID
                If tdbg.Columns(COL_VATGroupID).Text <> tdbdVATGroupID.Columns(0).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    tdbg.Columns(COL_RateTax).Text = ""
                End If
        End Select
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        Select Case e.ColIndex
            Case COL_StartDate, COL_DExpectDate, COL_ExpiryDate, COL_DRef1 To COL_DRef5
                tdbg.Select()
            Case COL_D06OQuantity
                'tdbg.Columns(COL_D06CQuantity).Text = Number(tdbg.Columns(COL_D06OQuantity).Text) * Number(tdbg.Columns(COL_ConversionFactor).Text)
                'UnitPrice_Change(tdbg.Row)
                CalD06CQuantity()
                CalOAmount()
                CalCAmount()
                CalVATOAmount()
                CalVATCAmount()
            Case COL_UnitPrice
                'UnitPrice_Change(tdbg.Row)
                CalOAmount()
                CalCAmount()
                CalVATOAmount()
                CalVATCAmount()
            Case COL_OAmount
                'OAmount_Change(tdbg.Row)
                CalCAmount()
                CalVATOAmount()
                CalVATCAmount()
            Case COL_VATGroupID
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    tdbg.Columns(COL_RateTax).Value = 0 'Gắn rỗng các cột liên quan
                Else
                    tdbg.Columns(COL_RateTax).Value = tdbdVATGroupID.Columns("RateTax").Text
                End If
                'VATGroupID()
                CalVATOAmount()
                CalVATCAmount()
            Case COL_VATOAmount
                'If tdbcCurrencyID.Columns("Operator").Text = "0" Then
                '    tdbg.Columns(COL_VATCAmount).Text = CStr(Number(tdbg.Columns(COL_VATOAmount).Text) * Number(cneExchangeRate.Value))
                'ElseIf tdbcCurrencyID.Columns("Operator").Text = "1" Then
                '    tdbg.Columns(COL_VATCAmount).Text = CStr(Number(tdbg.Columns(COL_VATOAmount).Text) / Number(cneExchangeRate.Value))
                'End If
                CalVATCAmount()
            Case COL_LocationNo
                If tdbg.Columns(e.ColIndex).Text = "" Then Exit Sub
                LocationNo_Task()
                If tdbg.Columns(e.ColIndex).Text = "+" Then tdbg.Columns(e.ColIndex).Text = ""
            Case COL_MPSVoucherNo
                If tdbg.Columns(e.ColIndex).Text = "" Then Exit Sub
                tdbg.Columns(COL_MPSVoucherID).Text = tdbdMPSVoucherNo.Columns("MPSVoucherID").Text
            Case COL_Ana01ID To COL_Ana10ID
                If tdbg.Columns(e.ColIndex).Text = "+" Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    ShowD91F1302("K" & tdbg.Columns(e.ColIndex).DataField.Substring(3, 2), e.ColIndex, COL_Ana01ID)
                End If
                ' Bổ sung gọi mà hình thêm quy cách
            Case COL_Spec01ID To COL_Spec10ID
                If tdbg.Columns(e.ColIndex).Text <> "" Then
                    If tdbg.Columns(e.ColIndex).Text = "+" Then
                        tdbg.Columns(e.ColIndex).Text = ""
                        tdbg.Columns(tdbg.Columns(e.ColIndex).DataField.Replace("ID", "Name")).Text = ""
                        ShowD07F1411(tdbg.Columns(e.ColIndex).DataField.Substring(4, 2))
                    Else
                        tdbg.Columns(tdbg.Columns(e.ColIndex).DataField.Replace("ID", "Name")).Text = tdbg.Columns(e.ColIndex).DropDown.Columns(1).Text
                    End If
                End If
        End Select
        ResetGrid()
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                If e.Shift Then
                    Dim sSQL As String = ""
                    sSQL &= SQLDeleteD07T6155() & vbCrLf
                    sSQL &= SQLInsertD07T6155s().ToString & vbCrLf
                    ExecuteSQL(sSQL)

                    'Dim f As New D07F6155
                    'f.ShowDialog()
                    'f.Dispose()    
                    RunExeDxxExx40("D07E3140", "D07F6155")
                Else
                    'Dim F As New D07F6150
                    'F.InventoryID = tdbg.Columns(COL_InventoryID).Text
                    'F.ShowDialog()
                    'F.Dispose()
                    RunExeDxxExx40("D07E3140", "D07F6150", , "ID01", tdbg.Columns(COL_InventoryID).Text)
                End If
            Case Keys.F4
                If tdbg.Col = COL_InventoryID Then
                    Dim f As New D12F3112
                    f.InventoryID = tdbg.Columns(COL_InventoryID).Text
                    f.TOQuantity = Number(tdbg.Columns(COL_OQuantity).Text)
                    f.ConversionFactor = Number(tdbg.Columns(COL_ConversionFactor).Text)
                    f.dtGrid = ReturnTableFilter(dtGrid, "OrderNum=" & SQLString(tdbg(tdbg.Row, COL_OrderNum)), True)
                    f.ShowDialog()
                    If f.bIsSplit = True Then
                        Dim dttemp As DataTable = f.dtGrid
                        dtGrid.Rows(tdbg.Row).Item("OQuantity") = dttemp.Rows(0).Item("OQuantity")
                        dtGrid.Rows(tdbg.Row).Item("CQuantity") = dttemp.Rows(0).Item("CQuantity")
                        'UnitPrice_Change(tdbg.Row)
                        'OAmount_Change(tdbg.Row)
                        CalOAmount(tdbg.Row)
                        CalCAmount(tdbg.Row)
                        CalVATOAmount(tdbg.Row)
                        CalVATCAmount(tdbg.Row)

                        Dim iRow As Integer = tdbg.Row
                        For i As Integer = 1 To dttemp.Rows.Count - 1
                            Dim Dtr2 As DataRow = dtGrid.NewRow
                            dtGrid.Rows.InsertAt(Dtr2, iRow + i)
                            Dtr2.ItemArray = dtGrid.Rows(iRow).ItemArray
                            Dtr2.Item("OQuantity") = dttemp.Rows(i).Item("OQuantity")
                            Dtr2.Item("CQuantity") = dttemp.Rows(i).Item("CQuantity")
                            Dtr2.Item("POItemID") = ""
                            'UnitPrice_Change(iRow + i)
                            'OAmount_Change(iRow + i)
                            CalOAmount(iRow + i)
                            CalCAmount(iRow + i)
                            CalVATOAmount(iRow + i)
                            CalVATCAmount(iRow + i)

                        Next
                        ''set lai ordernum
                        For i As Integer = 0 To tdbg.RowCount - 1
                            tdbg(i, COL_OrderNum) = i + 1
                            If tdbg(i, COL_StartDate).ToString <> "" Then tdbg.Columns(COL_StartDate).Tag = True
                        Next i
                        dtGrid.AcceptChanges()
                        ResetGrid()
                    End If
                    f.Dispose()
                End If

            Case Keys.F6
                If _FormState = EnumFormState.FormAdd And _bSaved = False Then Exit Sub
                Dim f As New D12F3130
                f.DisableSaveButton = L3Bool(IIf(_FormState = EnumFormState.FormView, True, False))
                f.POItemID = tdbg.Columns(COL_POItemID).Text
                f.ShowDialog()
                f.Dispose()
            Case Keys.Enter
                If tdbg.Col = iLastCol Then HotKeyEnterGrid(tdbg, COL_InventoryID, e, SPLIT0)
            Case Keys.S
                If e.Control Then HeadClick_Task()
            Case Else
                HotKeyDownGrid(e, tdbg, COL_InventoryID, 0, 1, , , , COL_DetailDesc, txtVoucherDesc.Text)
        End Select
    End Sub
#End Region

    Private Sub ShowD07F1411(ByVal sSpecTypeID As String)
        If ReturnPermission("D07F1410") <= 1 Then
            D99C0008.MsgL3(rL3("Ban_khong_co_quyen_them_moi")) 'Bạn không có quyền thêm mới
            Exit Sub
        End If
        Dim sFieldName As String = tdbg.Columns(tdbg.Col).DataField
        Me.Cursor = Cursors.WaitCursor
       

        Dim arrPro() As StructureProperties = Nothing 'ID  96376 28/04/2017
        SetProperties(arrPro, "SpecTypeID", sSpecTypeID)
        SetProperties(arrPro, "FormIDPermission", "D07F1410")
        Dim frm As Form = CallFormShowDialog("D07D1440", "D07F1411", arrPro)
        Dim bSavedOK As Boolean = L3Bool(GetProperties(frm, "bSaved"))
        Dim sOutput01 As String = GetProperties(frm, "SpecID_D07F1411").ToString

        If bSavedOK And sOutput01 <> "" Then 'Load lai du lieu cho dropdown
            '- Chỉ load nguồn cho dropdown đang thêm mới
            Dim dtSpec As DataTable = ReturnTableSpecification(True, gbUnicode, sSpecTypeID)
            Dim dr() As DataRow = dtSpec.Select("SpecID = " & SQLString(sOutput01))
            LoadDataSource(tdbg.Columns(sFieldName).DropDown, dtSpec, gbUnicode)
            If dr.Length > 0 Then
                tdbg.Columns(sFieldName).Text = sOutput01
                tdbg.Columns(sFieldName.Replace("ID", "Name")).Text = dr(0).Item("SpecName").ToString
            End If
            tdbg.Col = IndexOfColumn(tdbg, sFieldName)
            tdbg.UpdateData()
        End If
        Me.Cursor = Cursors.Default
    End Sub

#Region "Events tdbcTransTypeID"

    Private Sub tdbcTransTypeID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTransTypeID.Close
        If tdbcTransTypeID.FindStringExact(tdbcTransTypeID.Text) = -1 Then tdbcTransTypeID.Text = ""
        tdbg.LeftCol = COL_OrderNum
        tdbcVoucherTypeID.Focus()
    End Sub

    Private Sub tdbcTransTypeID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTransTypeID.LostFocus
        If tdbcTransTypeID.Text = "" Then
            tdbcTransTypeID.Focus()
            Exit Sub
        End If
        tdbcTransTypeID.Enabled = False
        TransTypeID_LostFocus()
        If tdbcTransTypeID.Columns("AllowChangeSpecID").Value.ToString = "1" Then LockColumSpec(False)
    End Sub
#End Region

    Private Sub TransTypeID_LostFocus()
        Dim arr() As FormatColumn = Nothing
        btnAna.Tag = "False"
        btnSub.Tag = "False"
        tdbg.Columns(COL_CQuantity).Tag = False
        tdbg.Columns(COL_CAmount).Tag = False

        If tdbcTransTypeID.Text = "" Then
            btnAna.Enabled = False
            btnSub.Enabled = False
        Else
            With tdbcTransTypeID
                If _FormState = EnumFormState.FormAdd Then
                    tdbcVoucherTypeID.SelectedValue = .Columns("VoucherTypeID").Text

                    'Các giá trị này ưu tiên lấy từ D12F3100
                    If tdbcObjectTypeID.Text = "" Then tdbcObjectTypeID.SelectedValue = .Columns("ObjectTypeID").Text
                    If tdbcObjectID.Text = "" Then tdbcObjectID.SelectedValue = .Columns("ObjectID").Text
                    If tdbcCurrencyID.Text = "" Then tdbcCurrencyID.SelectedValue = .Columns("CurrencyID").Text
                    'End Các giá trị này ưu tiên lấy từ D12F3100

                    tdbcReceiptPersonID.SelectedValue = .Columns("ReceiptPersonID").Text
                    GetTextCreateBy(tdbcEmployeeID)
                    If txtVoucherDesc.Text = "" Then txtVoucherDesc.Text = .Columns("VoucherDesc").Text
                    If tdbcPaymentMethodID.Text = "" Then tdbcPaymentMethodID.SelectedValue = tdbcTransTypeID.Columns("PaymentMethodID").Text

                    ' Nếu có giá trị PaymentTermID thì gán lại cho combo tdbcPaymentTermID
                    ' Ngược lại thì giữ nguyên giá trị khi truyền từ màn hình D12F3100
                    If Not String.IsNullOrEmpty(.Columns("PaymentTermID").Text) Then tdbcPaymentTermID.SelectedValue = .Columns("PaymentTermID").Text
                    tdbcShipAddressID.SelectedValue = .Columns("ShipAddressID").Text
                    c1dateVoucherDate.Value = Today.Date

                    If Number(.Columns("TypePostedD06").Text) = 0 Then
                        optTypePostedD06_0.Checked = True
                    Else
                        optTypePostedD06_1.Checked = True
                    End If
                End If
                '*******************************
                If L3Bool(.Columns("LockOAmount").Text) = True Then
                    tdbg.Splits(SPLIT1).DisplayColumns(COL_OAmount).Locked = True
                    tdbg.Splits(SPLIT1).DisplayColumns(COL_OAmount).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                End If
                If L3Bool(.Columns("LockCAmount").Text) = True Then
                    tdbg.Splits(SPLIT1).DisplayColumns(COL_CAmount).Locked = True
                    tdbg.Splits(SPLIT1).DisplayColumns(COL_CAmount).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                End If
                tdbg.Columns(COL_CQuantity).Tag = L3Bool(.Columns("UseCQuantity").Text)
                tdbg.Columns(COL_CAmount).Tag = L3Bool(.Columns("UseCAmount").Text)
            End With

            With tdbg
                For i As Integer = 0 To 9
                    'Spec
                    .Splits(SPLIT0).DisplayColumns(COL_Spec01ID + i).Visible = L3Bool(.Columns(COL_Spec01ID + i).Tag) And L3Bool(tdbcTransTypeID.Columns("UseSpec" & (i + 1).ToString("00") & "ID").Text)

                    'Ana
                    .Splits(SPLIT1).DisplayColumns(COL_Ana01ID + i).Visible = L3Bool(.Columns(COL_Ana01ID + i).Tag) And L3Bool(tdbcTransTypeID.Columns("UseAna" & (i + 1).ToString("00") & "ID").Text)
                    .Columns(COL_Ana01ID + i).Tag = L3Bool(.Columns(COL_Ana01ID + i).Tag) And L3Bool(tdbcTransTypeID.Columns("UseAna" & (i + 1).ToString("00") & "ID").Text)
                    If .Splits(SPLIT1).DisplayColumns(COL_Ana01ID + i).Visible Then
                        btnAna.Tag = "True"

                        If _FormState = EnumFormState.FormAdd Then
                            Dim sID As String = tdbcTransTypeID.Columns("DefaultAna" & (i + 1).ToString("00") & "ID").Text
                            tdbg.Columns(COL_Ana01ID + i).DefaultValue = ReturnValueC1DropDown(tdbg.Columns(COL_Ana01ID + i).DropDown, "AnaID", "AnaID=" & SQLString(sID))
                            For k As Integer = 0 To tdbg.RowCount - 1
                                If tdbg(k, COL_Ana01ID + i).ToString = "" Then tdbg(k, COL_Ana01ID + i) = .Columns(COL_Ana01ID + i).DefaultValue
                            Next k
                        End If

                    End If
                Next i
                '*****************************
                'SubInfo
                Dim sSQL As String = ""
                sSQL &= " Select 	B.FieldName, B.TableName, Case When (A.DefaultUse = 1 AND B.DisplaySub = 1) Then 1 Else 0 "
                sSQL &= " End As DisplaySub, " & vbCrLf
                sSQL &= " 	B.SubDefaultValue" & UnicodeJoin(gbUnicode) & " as SubDefaultValue, B.DecimalNum, B.Caption" & UnicodeJoin(gbUnicode) & " as Caption, B.DataType" & vbCrLf
                sSQL &= " FROM ( Select * From D07N0037('D07T0011')) A" & vbCrLf
                sSQL &= " INNER JOIN  (Select * From " & SQLUDFD12N3000() & "Where TableName = 'D07T0011') B" & vbCrLf
                sSQL &= " ON A.FieldName = B.FieldName AND A.DataType = B.DataType" & vbCrLf
                sSQL &= " Order By B.DataType, B.FieldName" & vbCrLf

                Dim dtSub As DataTable = ReturnDataTable(sSQL)
                If dtSub.Rows.Count > 0 Then
                    For k As Integer = 0 To 14
                        .Splits(SPLIT1).DisplayColumns(COL_NRef1 + k).HeadingStyle.Font = FontUnicode(gbUnicode)
                        .Splits(SPLIT1).DisplayColumns(COL_NRef1 + k).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        .Splits(SPLIT1).DisplayColumns(COL_NRef1 + k).Visible = L3Bool(dtSub.Rows(k).Item("DisplaySub"))
                        .Columns(COL_NRef1 + k).Caption = dtSub.Rows(k).Item("Caption").ToString
                        .Columns(COL_NRef1 + k).Tag = L3Bool(dtSub.Rows(k).Item("DisplaySub"))
                        If .Splits(SPLIT1).DisplayColumns(COL_NRef1 + k).Visible Then
                            .Columns(COL_NRef1 + k).DefaultValue = dtSub.Rows(k).Item("SubDefaultValue").ToString
                            If _FormState = EnumFormState.FormAdd Then
                                'insert values depend on TransTypeID if cell is empty
                                For i As Integer = 0 To tdbg.RowCount - 1
                                    If tdbg(i, COL_NRef1 + k).ToString = "" Then tdbg(i, COL_NRef1 + k) = .Columns(COL_NRef1 + k).DefaultValue
                                Next i
                            End If
                            btnSub.Tag = "True"
                        End If

                        Select Case dtSub.Rows(k).Item("DataType").ToString
                            Case "0"
                                .Splits(SPLIT1).DisplayColumns(COL_NRef1 + k).Width = 110
                                .Splits(SPLIT1).DisplayColumns(COL_NRef1 + k).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                                ' .Columns(COL_NRef1 + k).NumberFormat = DxxFormat.DefaultNumber2
                                AddDecimalColumns(arr, tdbg.Columns(COL_NRef1 + k).DataField, "N" & dtSub.Rows(k).Item("DecimalNum").ToString, 28, 8)
                            Case "1"
                                .Splits(SPLIT1).DisplayColumns(COL_NRef1 + k).Width = 140
                                .Columns(COL_NRef1 + k).DataWidth = 250
                            Case "2"
                                .Splits(SPLIT1).DisplayColumns(COL_NRef1 + k).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                                .Splits(SPLIT1).DisplayColumns(COL_NRef1 + k).Width = 80
                                InputDateInTrueDBGrid(tdbg, COL_NRef1 + k)
                                '.Columns(COL_NRef1 + k).NumberFormat = "Edit Mask"
                                '.Columns(COL_NRef1 + k).EnableDateTimeEditor = False
                                '.Columns(COL_NRef1 + k).EditMaskUpdate = True
                                '.Columns(COL_NRef1 + k).EditMask = "00/00/0000"
                        End Select
                    Next k
                End If
            End With
            ChangeButtonClick(ButtonForGrid.Main)
        End If
        Format_WhenCurrencyIDChange()
        '************************
        If arr IsNot Nothing Then InputNumber(tdbg, arr)
    End Sub


#Region "Events tdbcVoucherTypeID with txtVoucherNo"
    Dim sOldVoucherNo As String = "" 'Lưu lại số phiếu cũ
    Dim bEditVoucherNo As Boolean = False '= True: có nhấn F2; = False: không
    Dim bFirstF2 As Boolean = False 'Nhấn F2 lần đầu tiên
    Dim iPer_F5558 As Integer = ReturnPermission("D12F5558") 'Phân quyền cho Sửa số phiếu

    Private Sub tdbcVoucherTypeID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.Close
        If tdbcVoucherTypeID.FindStringExact(tdbcVoucherTypeID.Text) = -1 Then
            tdbcVoucherTypeID.Text = ""
            txtVoucherNo.Text = ""
        End If
    End Sub

    Private Sub tdbcVoucherTypeID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.SelectedValueChanged
        bEditVoucherNo = False
        bFirstF2 = False
        If tdbcVoucherTypeID.SelectedValue Is Nothing OrElse tdbcVoucherTypeID.Text = "" Then
            txtVoucherNo.Text = ""
            ReadOnlyControl(txtVoucherNo)
            Exit Sub
        End If
        If _FormState = EnumFormState.FormAdd Then
            If tdbcVoucherTypeID.Columns("Auto").Text = "1" Then 'Sinh tự động
                txtVoucherNo.Text = CreateIGEVoucherNo(tdbcVoucherTypeID, False)
                ReadOnlyControl(txtVoucherNo)
            Else 'Không sinh tự động
                txtVoucherNo.Text = ""
                UnReadOnlyControl(txtVoucherNo, True)
            End If
        End If
    End Sub

    Private Sub txtVoucherNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVoucherNo.KeyDown
        If e.KeyCode = Keys.F2 Then
            'Loại phiếu hay Số phiếu = "" thì thoát
            If tdbcVoucherTypeID.Text = "" Or txtVoucherNo.Text = "" Then Exit Sub

            'Update 21/09/2010: Trường hợp Thêm mới phiếu và đã lưu Thành công thì không cho sửa Số phiếu
            If _FormState = EnumFormState.FormAdd And btnSave.Enabled = False Then Exit Sub
            'Kiểm tra quyền cho trường hợp Sửa
            If _FormState = EnumFormState.FormEdit And iPer_F5558 <= 2 Then Exit Sub

            'Cho sửa Số phiếu ở trạng thái Thêm mới hay Sửa
            If _FormState = EnumFormState.FormAdd Or _FormState = EnumFormState.FormEdit Then
                'Trước khi gọi exe con thì nhớ lại Số phiếu cũ
                If bFirstF2 = False Then
                    sOldVoucherNo = txtVoucherNo.Text
                    bFirstF2 = True
                End If
                'ID 79481 7/9/2015
                Dim arrPro() As StructureProperties = Nothing
                SetProperties(arrPro, "FormIDPermission", "D12F5558")
                SetProperties(arrPro, "VoucherTypeID", ReturnValueC1Combo(tdbcVoucherTypeID))
                'Update 21/09/2010
                If _FormState = EnumFormState.FormAdd Then
                    SetProperties(arrPro, "VoucherID", "")
                ElseIf _FormState = EnumFormState.FormEdit Then
                    SetProperties(arrPro, "VoucherID", _pOID)
                End If
                'SetProperties(arrPro, "VoucherID", _voucherID)
                SetProperties(arrPro, "Mode", 0)
                SetProperties(arrPro, "KeyID01", "")
                SetProperties(arrPro, "TableName", "D12T2050")
                SetProperties(arrPro, "ModuleID", D12)
                SetProperties(arrPro, "OldVoucherNo", txtVoucherNo.Text)
                SetProperties(arrPro, "KeyID02", "")
                SetProperties(arrPro, "KeyID03", "")
                SetProperties(arrPro, "KeyID04", "")
                SetProperties(arrPro, "KeyID05", "")
                Dim frm As Form = CallFormShowDialog("D91D0640", "D91F5558", arrPro)
                Dim sNew As String = GetProperties(frm, "NewVoucherNo").ToString
                If sNew <> "" Then
                    ' 2012-03-09 Kiểm tra để gán số phiếu Chuyển module mua hàng
                    If chkPostedD06.Checked Then
                        If tdbcVoucherTypeID.Text = tdbcD06VoucherTypeID.Text And txtD06VoucherNo.Text = txtVoucherNo.Text Then
                            txtD06VoucherNo.Text = sNew
                        End If
                    End If
                    txtVoucherNo.Text = sNew 'Giá trị trả về Số phiếu mới
                    ReadOnlyControl(txtVoucherNo) 'Lock text Số phiếu
                    bEditVoucherNo = True 'Đã nhấn F2
                    _bSaved = True
                End If
            End If
        End If
    End Sub

#End Region

#Region "Events tdbcD06VoucherTypeID with txtD06VoucherNo"

    Private Sub tdbcD06VoucherTypeID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcD06VoucherTypeID.Close
        If tdbcD06VoucherTypeID.FindStringExact(tdbcD06VoucherTypeID.Text) = -1 Then
            tdbcD06VoucherTypeID.Text = ""
            txtD06VoucherNo.Text = ""
        End If
    End Sub

    Private Sub tdbcD06VoucherTypeID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcD06VoucherTypeID.SelectedValueChanged
        If tdbcD06VoucherTypeID.SelectedValue Is Nothing OrElse tdbcD06VoucherTypeID.Text = "" Then
            txtD06VoucherNo.Text = ""
            ReadOnlyControl(txtD06VoucherNo)
            Exit Sub
        End If
        If _FormState = EnumFormState.FormAdd Then
            If tdbcD06VoucherTypeID.Columns("Auto").Text = "1" Then 'Sinh tự động
                If chkPostedD06.Checked Then txtD06VoucherNo.Text = CreateIGEVoucherNo(tdbcD06VoucherTypeID, False)
                ReadOnlyControl(txtD06VoucherNo)
            Else 'Không sinh tự động
                txtD06VoucherNo.Text = ""
                UnReadOnlyControl(txtD06VoucherNo, True)
            End If
        End If
    End Sub
#End Region

    Dim dtObjectID As DataTable

    Private Sub LoadtdbcObjectID(ByVal sObjectTypeID As String)
        LoadDataSource(tdbcObjectID, ReturnTableFilter(dtObjectID, "ObjectTypeID = " & SQLString(sObjectTypeID)), gbUnicode)
    End Sub

#Region "Events tdbcObjectTypeID load tdbcObjectID with txtObjectName"

    Private Sub tdbcObjectTypeID_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcObjectTypeID.GotFocus
        'Dùng phím Enter
        tdbcObjectTypeID.Tag = tdbcObjectTypeID.Text
    End Sub

    Private Sub tdbcObjectTypeID_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbcObjectTypeID.MouseDown
        'Di chuyển chuột
        tdbcObjectTypeID.Tag = tdbcObjectTypeID.Text
    End Sub

    Private Sub tdbcObjectTypeID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcObjectTypeID.SelectedValueChanged
        tdbcObjectID.Text = ""
    End Sub

    Private Sub tdbcObjectTypeID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcObjectTypeID.LostFocus
        If tdbcObjectTypeID.Tag.ToString = "" And tdbcObjectTypeID.Text = "" Then Exit Sub
        If tdbcObjectTypeID.Tag.ToString = tdbcObjectTypeID.Text And tdbcObjectTypeID.SelectedValue IsNot Nothing Then Exit Sub
        If tdbcObjectTypeID.FindStringExact(tdbcObjectTypeID.Text) = -1 OrElse tdbcObjectTypeID.SelectedValue Is Nothing Then
            tdbcObjectTypeID.Text = ""
            LoadtdbcObjectID("-1")
            tdbcObjectID.Text = ""
            Exit Sub
        End If
        LoadtdbcObjectID(tdbcObjectTypeID.SelectedValue.ToString())
        tdbcObjectID.Text = ""
    End Sub

    Private Sub tdbcObjectID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcObjectID.SelectedValueChanged
        If tdbcObjectID.SelectedValue Is Nothing Then
            txtObjectName.Text = ""
        Else
            txtObjectName.Text = tdbcObjectID.Columns(1).Value.ToString
        End If
    End Sub

    Private Sub tdbcObjectID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcObjectID.LostFocus
        If tdbcObjectID.FindStringExact(tdbcObjectID.Text) = -1 Then
            tdbcObjectID.Text = ""
            LoadTdbcLCNo("-1", "-1")
            Exit Sub
        End If

        LoadTdbcLCNo(tdbcObjectTypeID.Text, tdbcObjectID.Text)

        If _FormState = EnumFormState.FormAdd Then

            Dim sSQL As String
            sSQL = "SELECT UnitPrice, InventoryID" & vbCrLf
            sSQL = sSQL & "FROM D12T1100 WITH(NOLOCK) " & vbCrLf
            sSQL = sSQL & "WHERE ObjectTypeID = " & SQLString(tdbcObjectTypeID.Text) & vbCrLf
            sSQL = sSQL & "AND ObjectID = " & SQLString(tdbcObjectID.Text)
            Dim dt As DataTable = ReturnDataTable(sSQL)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To tdbg.RowCount - 1
                    Dim dtUnitPrice As DataTable = ReturnTableFilter(dt, "InventoryID = " & SQLString(tdbg(i, COL_InventoryID)))
                    If dtUnitPrice.Rows.Count > 0 Then
                        tdbg(i, COL_UnitPrice) = dtUnitPrice.Rows(0).Item("UnitPrice").ToString
                    Else
                        tdbg(i, COL_UnitPrice) = ""
                    End If
                    'UnitPrice_Change(i)
                    CalOAmount(i)
                    CalCAmount(i)
                    CalVATOAmount(i)
                    CalVATCAmount(i)
                Next i
                ResetGrid()
            End If
        End If
    End Sub

    Private Sub tdbcObjectID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcObjectID.KeyDown
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

    Private Sub LoadTdbcLCNo(ByVal sObjType As String, ByVal sObj As String)
        LoadDataSource(tdbcLCNo, ReturnTableFilter(dtLCNo, "ObjectTypeID = " & SQLString(sObjType) & " And ObjectID = " & SQLString(sObj), True), gbUnicode)
    End Sub

#Region "Events tdbcStatusID"

    Private Sub tdbcStatusID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcStatusID.SelectedValueChanged
        If tdbcStatusID.SelectedValue Is Nothing Or tdbcStatusID.Text = "" Then
            EnableCheck()
            Exit Sub
        End If
        If iPerD12F5812 < 2 Then Exit Sub
        If tdbcStatusID.SelectedValue.ToString = "0" Then
            chkPostedD06.Enabled = True
            chkIsLC.Enabled = True
        Else
            chkPostedD06.Enabled = False
            chkPostedD06.Checked = False

            chkIsLC.Enabled = False
            chkIsLC.Checked = False
        End If
        EnableCheck()
        PostedD06_Change()
    End Sub

    Private Sub tdbcStatusID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcStatusID.LostFocus
        If tdbcStatusID.FindStringExact(tdbcStatusID.Text) = -1 Then
            tdbcStatusID.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcShipAddressID with txtShipAddressName"

    Private Sub tdbcShipAddressID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcShipAddressID.SelectedValueChanged
        If tdbcShipAddressID.SelectedValue Is Nothing Then
            txtShipAddressName.Text = ""
        Else
            txtShipAddressName.Text = tdbcShipAddressID.Columns(1).Value.ToString
        End If
    End Sub

    Private Sub tdbcShipAddressID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcShipAddressID.LostFocus
        If tdbcShipAddressID.FindStringExact(tdbcShipAddressID.Text) = -1 Then
            tdbcShipAddressID.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcReceiptPersonID"
    Private Sub tdbcReceiptPersonID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcReceiptPersonID.LostFocus
        If tdbcReceiptPersonID.FindStringExact(tdbcReceiptPersonID.Text) = -1 Then tdbcReceiptPersonID.Text = ""
    End Sub
#End Region

#Region "Events tdbcEmployeeID"

    Private Sub tdbcEmployeeID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEmployeeID.LostFocus
        If tdbcEmployeeID.FindStringExact(tdbcEmployeeID.Text) = -1 Then tdbcEmployeeID.Text = ""
    End Sub

#End Region

#Region "Events tdbcPaymentMethodID"
    Private Sub tdbcPaymentMethodID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcPaymentMethodID.LostFocus
        If tdbcPaymentMethodID.FindStringExact(tdbcPaymentMethodID.Text) = -1 Then tdbcPaymentMethodID.Text = ""
    End Sub
#End Region

#Region "Events tdbcPaymentTermID"
    Private Sub tdbcPaymentTermID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcPaymentTermID.LostFocus
        If tdbcPaymentTermID.FindStringExact(tdbcPaymentTermID.Text) = -1 Then tdbcPaymentTermID.Text = ""
    End Sub
#End Region

#Region "Events tdbcCurrencyID with txtExchangeRate"
    Private Sub LockExchangeRate()
        ' Loại tiền chọn là Tiền hạch toán thì bIsBaseCurrency = True, khoá Tỷ giá
        If tdbcCurrencyID.Text = DxxFormat.BaseCurrencyID Then
            cneExchangeRate.Enabled = False
            cneExchangeRate.Value = 1
        Else
            cneExchangeRate.Enabled = True
        End If
    End Sub

    Private Sub Format_WhenCurrencyIDChange()
        Dim sFormatOriginal As String = CustomFormat(tdbcCurrencyID.Columns("OriginalDecimal").Text) 'Format Tiền nguyên tệ
        Dim sUnitPrice As String = CustomFormat(tdbcCurrencyID.Columns("PurchasePriceDecimals").Text) 'Format Đơn giá

        ReFormatNumber(tdbg, sUnitPrice, tdbg.Columns(COL_UnitPrice).DataField)
        ReFormatNumber(tdbg, sFormatOriginal, tdbg.Columns(COL_OAmount).DataField, tdbg.Columns(COL_VATOAmount).DataField)
    End Sub

    Dim dExchangeRate As Double = 0
    Private Sub ResetStringFormat(Optional ByVal bResetFormat As Boolean = True, Optional ByVal bExchangeRateByDate As Boolean = True, Optional ByVal bCalOAmount As Boolean = True)
        If bResetFormat Then
            If bExchangeRateByDate Then cneExchangeRate.Value = Number(ReturnValueC1Combo(tdbcCurrencyID, "ExchangeRate"))
            ReFormatNumber(cneExchangeRate, CustomFormat(ReturnValueC1Combo(tdbcCurrencyID, "ExchangeRateDecimal")))
            Format_WhenCurrencyIDChange()
        End If

        If Number(cneExchangeRate.Text) <> 0 Then
            dExchangeRate = Number(IIf(L3Int(tdbcCurrencyID.Columns("Operator").Text) = 0, Number(cneExchangeRate.Text), 1 / Number(cneExchangeRate.Text)).ToString)
        Else
            dExchangeRate = 0
        End If
        CalculateExchangeRateAll(bCalOAmount)
        '*********************
        LockExchangeRate()
    End Sub

    Private Sub cneExchangeRate_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cneExchangeRate.Validated
        If cneExchangeRate.Tag Is Nothing OrElse cneExchangeRate.Tag.ToString <> cneExchangeRate.Text Then
            ResetStringFormat(False, False, False)
            cneExchangeRate.Tag = cneExchangeRate.Text
        End If
    End Sub

    'Private Sub tdbcCurrencyID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCurrencyID.SelectedValueChanged
    '    If tdbcCurrencyID.SelectedValue Is Nothing Then
    '        cneExchangeRate.Value = ""
    '    Else
    '        cneExchangeRate.Value = tdbcCurrencyID.Columns("ExchangeRate").Value.ToString
    '        If tdbcCurrencyID.Text = gsCurrencyID Then cneExchangeRate.Enabled = False Else cneExchangeRate.Enabled = True
    '        '-----------------------------------------------
    '        For i As Integer = 0 To tdbg.RowCount - 1
    '            If chkPostedD06.Checked Then
    '                tdbg(i, COL_OAmount) = Number(SQLNumber(tdbg(i, COL_UnitPrice), tdbg.Columns(COL_UnitPrice).NumberFormat)) * Number(SQLNumber(tdbg(i, COL_D06OQuantity), DxxFormat.D07_QuantityDecimals))
    '            Else
    '                tdbg(i, COL_OAmount) = Number(SQLNumber(tdbg(i, COL_UnitPrice), tdbg.Columns(COL_UnitPrice).NumberFormat)) * Number(SQLNumber(tdbg(i, COL_OQuantity), DxxFormat.D07_QuantityDecimals))
    '            End If
    '        Next
    '        '********************
    '        If tdbcCurrencyID.Columns("Operator").Text = "0" Then
    '            For i As Integer = 0 To tdbg.RowCount - 1
    '                tdbg(i, COL_CAmount) = Number(SQLNumber(tdbg(i, COL_OAmount), tdbg.Columns(COL_OAmount).NumberFormat)) * Number(cneExchangeRate.Value)
    '                tdbg(i, COL_VATCAmount) = Number(SQLNumber(tdbg(i, COL_VATOAmount), tdbg.Columns(COL_VATOAmount).NumberFormat)) * Number(cneExchangeRate.Value)
    '            Next i
    '        ElseIf tdbcCurrencyID.Columns("Operator").Text = "1" Then
    '            For i As Integer = 0 To tdbg.RowCount - 1
    '                tdbg(i, COL_CAmount) = Number(SQLNumber(tdbg(i, COL_OAmount), tdbg.Columns(COL_OAmount).NumberFormat)) / Number(cneExchangeRate.Value)
    '                tdbg(i, COL_VATCAmount) = Number(SQLNumber(tdbg(i, COL_VATOAmount), tdbg.Columns(COL_VATOAmount).NumberFormat)) / Number(cneExchangeRate.Value)
    '            Next i
    '        End If
    '    End If

    '    ResetGrid()
    'End Sub

    Dim bRunValueChange As Boolean = True
    Private Sub tdbcCurrencyID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCurrencyID.SelectedValueChanged
        If bRunValueChange AndAlso tdbcCurrencyID.Text <> "" Then
            ResetStringFormat()
        End If
    End Sub

    Private Sub tdbcCurrencyID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcCurrencyID.LostFocus
        If tdbcCurrencyID.FindStringExact(tdbcCurrencyID.Text) = -1 Then
            tdbcCurrencyID.Text = ""
        End If
    End Sub
#End Region

#Region "Events tdbcLCNo"

    Private Sub tdbcLCNo_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcLCNo.LostFocus
        If tdbcLCNo.FindStringExact(tdbcLCNo.Text) = -1 Then tdbcLCNo.Text = ""
    End Sub

#End Region

#Region "Events tdbcDeliveryID with txtDeliveryName"
    Private Sub tdbcDeliveryID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDeliveryID.LostFocus
        If tdbcDeliveryID.FindStringExact(tdbcDeliveryID.Text) = -1 Then
            tdbcDeliveryID.Text = ""
        End If
    End Sub
#End Region


    Private Sub btnMain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMain.Click
        If tdbcTransTypeID.Text = "" And _FormState = EnumFormState.FormAdd Then tdbcTransTypeID.Focus() : Exit Sub
        ChangeButtonClick(ButtonForGrid.Main)
    End Sub

    Private Sub btnAna_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAna.Click
        If tdbcTransTypeID.Text = "" And _FormState = EnumFormState.FormAdd Then tdbcTransTypeID.Focus() : Exit Sub
        ChangeButtonClick(ButtonForGrid.Ana)
    End Sub

    Private Sub btnOther_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOther.Click
        If tdbcTransTypeID.Text = "" And _FormState = EnumFormState.FormAdd Then tdbcTransTypeID.Focus() : Exit Sub
        ChangeButtonClick(ButtonForGrid.Other)
    End Sub

    Private Sub btnSub_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSub.Click
        If tdbcTransTypeID.Text = "" And _FormState = EnumFormState.FormAdd Then tdbcTransTypeID.Focus() : Exit Sub
        ChangeButtonClick(ButtonForGrid.SubInfo)
    End Sub

    Private Sub btnAdditionalInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdditionalInfo.Click
        Dim f As New D12F3111
        f.POID = _pOID
        f.IsViewPermission = L3Bool(IIf(_FormState = EnumFormState.FormView, 1, 0))
        Dim sSQL As String = ""
        sSQL &= " IF EXISTS ( SELECT * from D12T2050 WITH(NOLOCK) " & vbCrLf
        sSQL &= " 	       WHERE POID = " & SQLString(_pOID) & vbCrLf
        sSQL &= " AND MStr01 = '' AND MStr02 = '' AND MStr03 = '' AND MStr04 = '' AND MStr05 = '' AND MStr06 = '' AND "
        sSQL &= " MStr07 = '' AND MStr08 = '' AND MStr09 = '' AND MStr10 = '' " & vbCrLf
        sSQL &= " AND MNum01 = 0 AND MNum02 = 0 AND MNum03 = 0 AND MNum04 = 0 AND MNum05 = 0 AND MNum06 = 0 AND "
        sSQL &= " MNum07 = 0 AND MNum08 = 0 AND MNum09 = 0 AND MNum10 = 0" & vbCrLf
        sSQL &= " AND MDat01 IS NULL AND MDat02 IS NULL AND MDat03 IS NULL AND MDat04 IS NULL AND MDat05 IS NULL AND "
        sSQL &= " MDat06 IS NULL AND MDat07 IS NULL AND MDat08 IS NULL AND MDat09 IS NULL AND MDat10 IS NULL )" & vbCrLf
        sSQL &= " BEGIN SELECT 1" & vbCrLf
        sSQL &= " END" & vbCrLf
        sSQL &= " ELSE SELECT 0" & vbCrLf
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item(0).ToString = "1" Then
                f.FormState = EnumFormState.FormAdd
            Else
                f.FormState = EnumFormState.FormEdit
            End If
        End If
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub ShowD91F1302(ByVal sAnaCategoryID As String, ByVal iCol As Integer, ByVal COL_Ana01 As Integer)
        If ReturnPermission("D91F1301") <= 1 Then
            D99C0008.MsgL3(rL3("Ban_khong_co_quyen_them_moi")) 'Bạn không có quyền thêm mới
            Exit Sub
        End If

        Dim iIndex As Integer = iCol - COL_Ana01
        '        Dim frm As New D91F1301
        '        frm.FormName = "D91F1302"
        '        frm.KeyID01 = sAnaCategoryID
        '        frm.KeyID02 = gsArrAnaCategoryName(iIndex)
        '        frm.ShowDialog()
        '        Dim sKey As String = frm.Output01
        '        frm.Dispose()
        '        If sKey <> "" Then 'Load lai du lieu cho dropdown
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "D91F1301")
        SetProperties(arrPro, "AnaCategatoryID", sAnaCategoryID)
        SetProperties(arrPro, "AnaCategatoryName", gsArrAnaCategoryName(iIndex))
        SetProperties(arrPro, "FormState", 0)
        Dim frm As Form = CallFormShowDialog("D91D0540", "D91F1302", arrPro)
        Dim sKey As Object = GetProperties(frm, "AnaID")
        If sKey Is Nothing Then Exit Sub
        If sKey.ToString <> "" Then
            Dim dtAna As DataTable = ReturnTableAnaID(True, gbUnicode, sAnaCategoryID)
            LoadDataSource(tdbg.Columns(iCol).DropDown, dtAna, gbUnicode)
            tdbg.Columns(iCol).Text = sKey.ToString
        End If
    End Sub


#Region "Các hàm tính toán"

    'Private Sub UnitPrice_Change(ByVal iRow As Integer)
    '    tdbg.UpdateData()
    '    Dim OAmount As Double = 0
    '    Dim VATOAmount As Double = 0
    '    Dim UnitPrice As Double = Number(SQLNumber(tdbg(iRow, COL_UnitPrice), tdbg.Columns(COL_UnitPrice).NumberFormat))
    '    Dim D06OQuantity As Double = Number(SQLNumber(tdbg(iRow, COL_D06OQuantity), tdbg.Columns(COL_D06CQuantity).NumberFormat))
    '    Dim OQuantity As Double = Number(SQLNumber(tdbg(iRow, COL_OQuantity), tdbg.Columns(COL_OQuantity).NumberFormat))
    '    Dim RateTax As Double = Number(SQLNumber(tdbg(iRow, COL_RateTax).ToString.Replace("%", ""), tdbg.Columns(COL_RateTax).NumberFormat))

    '    If chkPostedD06.Checked Then
    '        tdbg(iRow, COL_OAmount) = UnitPrice * D06OQuantity
    '    Else
    '        tdbg(iRow, COL_OAmount) = UnitPrice * OQuantity
    '    End If
    '    OAmount = Number(SQLNumber(tdbg(iRow, COL_OAmount), tdbg.Columns(COL_OAmount).NumberFormat))


    '    If tdbcCurrencyID.Columns("Operator").Text = "0" Then
    '        tdbg(iRow, COL_CAmount) = OAmount * Number(txtExchangeRate.Text)
    '    ElseIf tdbcCurrencyID.Columns("Operator").Text = "1" Then
    '        tdbg(iRow, COL_CAmount) = OAmount / Number(txtExchangeRate.Text)
    '    End If

    '    'Oamount thay doi -> VATOAmount thay doi nen phai tinh lai 
    '    tdbg(iRow, COL_VATOAmount) = OAmount * RateTax / 100

    '    VATOAmount = Number(SQLNumber(tdbg(iRow, COL_VATOAmount), tdbg.Columns(COL_VATOAmount).NumberFormat))

    '    If tdbg(iRow, COL_Operator).ToString = "0" Then
    '        tdbg(iRow, COL_VATCAmount) = VATOAmount * Number(txtExchangeRate.Text)
    '    ElseIf tdbg(iRow, COL_Operator).ToString = "1" Then
    '        tdbg(iRow, COL_VATCAmount) = VATOAmount / Number(txtExchangeRate.Text)
    '    End If

    '    ResetGrid()
    'End Sub

    'Private Sub OAmount_Change(ByVal iRow As Integer)
    '    tdbg.UpdateData()
    '    Dim OAmount As Double = 0
    '    Dim VATOAmount As Double = 0
    '    Dim UnitPrice As Double = Number(SQLNumber(tdbg(iRow, COL_UnitPrice), DxxFormat.D07_UnitCostDecimals))
    '    Dim D06OQuantity As Double = Number(SQLNumber(tdbg(iRow, COL_D06OQuantity), DxxFormat.D07_QuantityDecimals))
    '    Dim OQuantity As Double = Number(SQLNumber(tdbg(iRow, COL_OQuantity), DxxFormat.D07_QuantityDecimals))
    '    Dim RateTax As Double = Number(SQLNumber(tdbg(iRow, COL_RateTax).ToString.Replace("%", ""), tdbg.Columns(COL_RateTax).NumberFormat))

    '    OAmount = Number(SQLNumber(tdbg(iRow, COL_OAmount), tdbg.Columns(COL_OAmount).NumberFormat))


    '    If tdbcCurrencyID.Columns("Operator").Text = "0" Then
    '        tdbg(iRow, COL_CAmount) = OAmount * Number(txtExchangeRate.Text)
    '    ElseIf tdbcCurrencyID.Columns("Operator").Text = "1" Then
    '        tdbg(iRow, COL_CAmount) = OAmount / Number(txtExchangeRate.Text)
    '    End If

    '    'Oamount thay doi -> VATOAmount thay doi nen phai tinh lai 
    '    tdbg(iRow, COL_VATOAmount) = OAmount * RateTax / 100

    '    VATOAmount = Number(SQLNumber(tdbg(iRow, COL_VATOAmount), tdbg.Columns(COL_VATOAmount).NumberFormat))

    '    If tdbg(iRow, COL_Operator).ToString = "0" Then
    '        tdbg(iRow, COL_VATCAmount) = VATOAmount * Number(txtExchangeRate.Text)
    '    ElseIf tdbg(iRow, COL_Operator).ToString = "1" Then
    '        tdbg(iRow, COL_VATCAmount) = VATOAmount / Number(txtExchangeRate.Text)
    '    End If

    '    ResetGrid()
    'End Sub

    'Private Sub VATGroupID()
    '    tdbg.Columns(COL_VATOAmount).Value = Number(tdbg.Columns(COL_OAmount).Text) * (Number(tdbg.Columns(COL_RateTax).Text.Replace("%", "")) / 100)

    '    'Thay tdbg.Columns(COL_Operator).Text = với  tdbcCurrencyID.Columns("Operator").Text 29/05/09
    '    If tdbcCurrencyID.Columns("Operator").Text = "0" Then
    '        tdbg.Columns(COL_VATCAmount).Value = Number(tdbg.Columns(COL_VATOAmount).Text) * Number(txtExchangeRate.Text)
    '    ElseIf tdbcCurrencyID.Columns("Operator").Text = "1" Then
    '        tdbg.Columns(COL_VATCAmount).Value = Number(tdbg.Columns(COL_VATOAmount).Text) / Number(txtExchangeRate.Text)
    '    End If
    '    ResetGrid()

    'End Sub

    Private Sub CalculateExchangeRateAll(ByVal bCalOAmount As Boolean)
        For i As Integer = 0 To tdbg.RowCount - 1
            If bCalOAmount Then CalOAmount(i)
            CalCAmount(i)
            CalVATCAmount(i)
        Next
        ResetGrid()
    End Sub

    Private Sub CalD06CQuantity()
        tdbg.Columns(COL_D06CQuantity).Text = SQLNumber(Number(tdbg.Columns(COL_D06OQuantity).Text) * Number(tdbg.Columns(COL_ConversionFactor).Text), tdbg.Columns(COL_D06CQuantity).NumberFormat)
    End Sub

    Private Sub CalCQuantity(ByVal row As Integer) 'Dùng cho HeadClick
        tdbg(row, COL_D06CQuantity) = SQLNumber(Number(tdbg(row, COL_D06OQuantity), tdbg.Columns(COL_D06OQuantity).NumberFormat) * Number(tdbg(row, COL_ConversionFactor)), tdbg.Columns(COL_D06CQuantity).NumberFormat)
    End Sub

    Private Sub CalOAmount()
        If chkPostedD06.Checked Then
            tdbg.Columns(COL_OAmount).Text = SQLNumber(Number(tdbg.Columns(COL_D06OQuantity).Text) * Number(tdbg.Columns(COL_UnitPrice).Text), tdbg.Columns(COL_OAmount).NumberFormat)
        Else
            tdbg.Columns(COL_OAmount).Text = SQLNumber(Number(tdbg.Columns(COL_OQuantity).Text) * Number(tdbg.Columns(COL_UnitPrice).Text), tdbg.Columns(COL_OAmount).NumberFormat)
        End If
    End Sub

    Private Sub CalOAmount(ByVal row As Integer) 'Dùng cho HeadClick
        If chkPostedD06.Checked Then
            tdbg(row, COL_OAmount) = Number(Number(tdbg(row, COL_D06OQuantity), tdbg.Columns(COL_D06OQuantity).NumberFormat) * Number(tdbg(row, COL_UnitPrice), tdbg.Columns(COL_UnitPrice).NumberFormat), tdbg.Columns(COL_OAmount).NumberFormat)
        Else
            tdbg(row, COL_OAmount) = Number(Number(tdbg(row, COL_OQuantity), tdbg.Columns(COL_OQuantity).NumberFormat) * Number(tdbg(row, COL_UnitPrice), tdbg.Columns(COL_UnitPrice).NumberFormat), tdbg.Columns(COL_OAmount).NumberFormat)
        End If
    End Sub

    Private Sub CalVATOAmount()
        Dim dRateTax As Double = Number(tdbg.Columns(COL_RateTax).Value.ToString.Replace("%", "")) / 100
        tdbg.Columns(COL_VATOAmount).Text = SQLNumber(Number(tdbg.Columns(COL_OAmount).Text) * Number(tdbg.Columns(COL_RateTax).Value, DxxFormat.DefaultNumber4), tdbg.Columns(COL_VATOAmount).NumberFormat)
    End Sub

    Private Sub CalVATOAmount(ByVal row As Integer) 'Dùng cho HeadClick
        Dim dRateTax As Double = Number(tdbg(row, COL_RateTax).ToString.Replace("%", ""), tdbg.Columns(COL_RateTax).NumberFormat) / 100
        tdbg(row, COL_VATOAmount) = Number(Number(tdbg(row, COL_OAmount), tdbg.Columns(COL_OAmount).NumberFormat) * Number(tdbg(row, COL_RateTax), DxxFormat.DefaultNumber4), tdbg.Columns(COL_VATOAmount).NumberFormat)
    End Sub

    Private Sub CalCAmount()
        tdbg.Columns(COL_CAmount).Text = SQLNumber(Number(tdbg.Columns(COL_OAmount).Text) * dExchangeRate, tdbg.Columns(COL_CAmount).NumberFormat)
    End Sub

    Private Sub CalCAmount(ByVal row As Integer) ' Dùng cho HeadClick
        tdbg(row, COL_CAmount) = SQLNumber(Number(tdbg(row, COL_OAmount), tdbg.Columns(COL_OAmount).NumberFormat) * dExchangeRate, tdbg.Columns(COL_CAmount).NumberFormat)
    End Sub

    Private Sub CalVATCAmount()
        tdbg.Columns(COL_VATCAmount).Text = SQLNumber(Number(tdbg.Columns(COL_VATOAmount).Text) * dExchangeRate, tdbg.Columns(COL_VATCAmount).NumberFormat)
    End Sub

    Private Sub CalVATCAmount(ByVal row As Integer) ' Dùng cho HeadClick
        tdbg(row, COL_VATCAmount) = Number(Number(tdbg(row, COL_VATOAmount), tdbg.Columns(COL_VATOAmount).NumberFormat) * dExchangeRate, tdbg.Columns(COL_VATCAmount).NumberFormat)
    End Sub

#End Region

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD12P3115
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 04/11/2008 08:33:28
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD12P3115() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D12P3115 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(_pOID) & COMMA 'POID, varchar[20], NOT NULL
        sSQL &= _pRTransactionID & COMMA 'strPRtransactionID, varchar[8000], NOT NULL
        sSQL &= SQLNumber(D12Systems.UseWorkflow) & COMMA 'UseWorkflow, int, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD07T6155s
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 04/11/2008 11:23:30
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD07T6155s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL.Append("Insert Into D07T6155(")
            sSQL.Append("UserID, OrderNo, InventoryID, Spec01ID, Spec02ID, ")
            sSQL.Append("Spec03ID, Spec04ID, Spec05ID, Spec06ID, Spec07ID, ")
            sSQL.Append("Spec08ID, Spec09ID, Spec10ID, UnitID, OQuantity, ")
            sSQL.Append("CQuantity, DebitAccountID, CreditAccountID, KindVoucherID, ModuleID")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_OrderNum)) & COMMA) 'OrderNo, tinyint, NULL
            sSQL.Append(SQLString(tdbg(i, COL_InventoryID)) & COMMA) 'InventoryID, varchar[50], NULL
            sSQL.Append(SQLString(tdbg(i, COL_Spec01ID)) & COMMA) 'Spec01ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_Spec02ID)) & COMMA) 'Spec02ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_Spec03ID)) & COMMA) 'Spec03ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_Spec04ID)) & COMMA) 'Spec04ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_Spec05ID)) & COMMA) 'Spec05ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_Spec06ID)) & COMMA) 'Spec06ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_Spec07ID)) & COMMA) 'Spec07ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_Spec08ID)) & COMMA) 'Spec08ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_Spec09ID)) & COMMA) 'Spec09ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_Spec10ID)) & COMMA) 'Spec10ID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_UnitID)) & COMMA) 'UnitID, varchar[20], NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_OQuantity)) & COMMA) 'OQuantity, decimal, NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_CQuantity)) & COMMA) 'CQuantity, decimal, NULL
            sSQL.Append(SQLString("") & COMMA) 'DebitAccountID, varchar[20], NULL
            sSQL.Append(SQLString("") & COMMA) 'CreditAccountID, varchar[20], NULL
            sSQL.Append(SQLNumber("0") & COMMA) 'KindVoucherID, tinyint, NULL
            sSQL.Append(SQLString("12")) 'ModuleID, varchar[20], NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD07T6155
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 04/11/2008 11:28:36
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD07T6155() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D07T6155"
        sSQL &= " Where UserID = " & SQLString(gsUserID)
        Return sSQL
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD12T2050
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 04/11/2008 01:45:05
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD12T2050() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D12T2050(")
        sSQL.Append("POID, DivisionID, TranMonth, TranYear, VoucherTypeID, " & vbCrLf)
        sSQL.Append("VoucherNo, VoucherDate, ExpectDate, VoucherDesc, VoucherDescU, EmployeeID, " & vbCrLf)
        sSQL.Append("ObjectTypeID, ObjectID, ShipAddressID, CurrencyID, ExchangeRate, " & vbCrLf)
        sSQL.Append("Pick, PostedD06, IsLC, POStatus, CreateUserID, CreateDate, " & vbCrLf)
        sSQL.Append("LastModifyUserID, LastModifyDate, ValidDateFrom, ValidDateTo," & vbCrLf)
        sSQL.Append("PaymentDate, PaymentMethodID, ReceiptPersonID, " & vbCrLf)
        sSQL.Append("TypePostedD06, TransTypeID, DeliveryID, PaymentTermID, D06VoucherTypeID, D06VoucherNo, D06DocNo, D06DocDate, ")
        sSQL.Append("Notes, NotesU, LCNo")
        sSQL.Append(") " & vbCrLf & " Values(")

        sSQL.Append(SQLString(_pOID) & COMMA) 'POID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
        sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NOT NULL
        sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, int, NOT NULL
        sSQL.Append(SQLString(tdbcVoucherTypeID.Text) & COMMA & vbCrLf) 'VoucherTypeID, varchar[20], NOT NULL
        sSQL.Append(SQLString(txtVoucherNo.Text) & COMMA) 'VoucherNo, varchar[20], NOT NULL
        sSQL.Append(SQLDateSave(c1dateVoucherDate.Text) & COMMA) 'VoucherDate, datetime, NULL
        sSQL.Append(SQLDateSave(c1dateExpectDate.Text) & COMMA) 'ExpectDate, datetime, NULL
        sSQL.Append(SQLStringUnicode(txtVoucherDesc.Text, gbUnicode, False) & COMMA) 'VoucherDesc, varchar[250], NOT NULL
        sSQL.Append(SQLStringUnicode(txtVoucherDesc.Text, gbUnicode, True) & COMMA) 'VoucherDesc, varchar[250], NOT NULL
        sSQL.Append(SQLString(tdbcEmployeeID.Text) & COMMA & vbCrLf) 'EmployeeID, varchar[20], NOT NULL
        sSQL.Append(SQLString(tdbcObjectTypeID.Text) & COMMA) 'ObjectTypeID, varchar[20], NOT NULL
        sSQL.Append(SQLString(tdbcObjectID.Text) & COMMA) 'ObjectID, varchar[20], NOT NULL
        sSQL.Append(SQLString(tdbcShipAddressID.Text) & COMMA) 'ShipAddressID, varchar[20], NOT NULL
        sSQL.Append(SQLString(tdbcCurrencyID.Text) & COMMA) 'CurrencyID, varchar[20], NOT NULL
        sSQL.Append(SQLMoney(cneExchangeRate.Value) & COMMA & vbCrLf) 'ExchangeRate, money, NOT NULL
        sSQL.Append(SQLNumber(chkPick.Checked) & COMMA) 'Pick, tinyint, NOT NULL
        sSQL.Append(SQLNumber(chkPostedD06.Checked) & COMMA) 'PostedD06, tinyint, NOT NULL
        sSQL.Append(SQLNumber(chkIsLC.Checked) & COMMA) 'IsLc
        sSQL.Append(SQLString(tdbcStatusID.SelectedValue.ToString) & COMMA) 'POStatus, char, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA & vbCrLf) 'CreateDate, datetime, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NOT NULL
        sSQL.Append(SQLDateSave(c1dateValidDateFrom.Text) & COMMA)
        sSQL.Append(SQLDateSave(c1dateValidDateTo.Text) & COMMA)
        sSQL.Append(SQLDateSave(c1datePaymentDate.Text) & COMMA) 'PaymentDate, datetime, NULL
        sSQL.Append(SQLString(tdbcPaymentMethodID.Text) & COMMA) 'PaymentMethodID, varchar[20], NOT NULL
        sSQL.Append(SQLString(tdbcReceiptPersonID.Text) & COMMA & vbCrLf) 'ReceiptPersonID, varchar[20], NOT NULL
        'sSQL.Append(SQLString(?????) & COMMA) 'ReceiptPerson, varchar[20], NOT NULL
        sSQL.Append(SQLNumber(IIf(optTypePostedD06_0.Checked, 0, 1)) & COMMA)
        sSQL.Append(SQLString(tdbcTransTypeID.Text) & COMMA)
        sSQL.Append(SQLString(tdbcDeliveryID.Text) & COMMA)
        sSQL.Append(SQLString(tdbcPaymentTermID.Text) & COMMA) 'PaymentTermID, varchar[20], NOT NULL
        sSQL.Append(SQLString(tdbcD06VoucherTypeID.Text) & COMMA) 'D06VoucherTypeID, varchar[20], NOT NULL
        sSQL.Append(SQLString(txtD06VoucherNo.Text) & COMMA) 'D06VoucherNo, varchar[20], NOT NULL
        sSQL.Append(SQLString(txtD06DocNo.Text) & COMMA) 'D06DocNo, varchar[20], NOT NULL
        sSQL.Append(SQLDateSave(c1dateD06DocDate.Value) & COMMA) 'D06DocDate,datetime, NOT NULL

        sSQL.Append(SQLStringUnicode(txtNote.Text, gbUnicode, False) & COMMA)
        sSQL.Append(SQLStringUnicode(txtNote.Text, gbUnicode, True) & COMMA)
        sSQL.Append(SQLString(tdbcLCNo.Text))
        sSQL.Append(")")

        Return sSQL
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD12T2050
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 04/11/2008 01:56:01
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD12T2050() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D12T2050 Set ")
        sSQL.Append("DivisionID = " & SQLString(gsDivisionID) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("TranMonth = " & SQLNumber(giTranMonth) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("TranYear = " & SQLNumber(giTranYear) & COMMA) 'int, NOT NULL
        sSQL.Append("VoucherDate = " & SQLDateSave(c1dateVoucherDate.Text) & COMMA) 'datetime, NULL
        sSQL.Append("ExpectDate = " & SQLDateSave(c1dateExpectDate.Text) & COMMA & vbCrLf) 'datetime, NULL
        sSQL.Append("VoucherDesc = " & SQLStringUnicode(txtVoucherDesc.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("VoucherDescU = " & SQLStringUnicode(txtVoucherDesc.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("EmployeeID = " & SQLString(tdbcEmployeeID.Text) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("ObjectTypeID = " & SQLString(tdbcObjectTypeID.Text) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("ObjectID = " & SQLString(tdbcObjectID.Text) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("ShipAddressID = " & SQLString(tdbcShipAddressID.Text) & COMMA & vbCrLf) 'varchar[20], NOT NULL
        sSQL.Append("CurrencyID = " & SQLString(tdbcCurrencyID.Text) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("ExchangeRate = " & SQLMoney(cneExchangeRate.Value) & COMMA) 'money, NOT NULL
        sSQL.Append("Pick = " & SQLNumber(chkPick.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("PostedD06 = " & SQLNumber(chkPostedD06.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("IsLC = " & SQLNumber(chkIsLC.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("POStatus = " & SQLString(tdbcStatusID.SelectedValue.ToString) & COMMA & vbCrLf) 'char, NOT NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NOT NULL
        sSQL.Append("ValidDateFrom = " & SQLDateSave(c1dateValidDateFrom.Text) & COMMA)
        sSQL.Append("ValidDateto = " & SQLDateSave(c1dateValidDateTo.Text) & COMMA)
        sSQL.Append("PaymentDate = " & SQLDateSave(c1datePaymentDate.Text) & COMMA) 'datetime, NULL
        sSQL.Append("PaymentMethodID = " & SQLString(tdbcPaymentMethodID.Text) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("ReceiptPersonID = " & SQLString(tdbcReceiptPersonID.Text) & COMMA & vbCrLf) 'varchar[20], NOT NULL
        sSQL.Append("TypePostedD06 = " & SQLNumber(IIf(optTypePostedD06_0.Checked, 0, 1)) & COMMA)
        sSQL.Append("DeliveryID = " & SQLString(tdbcDeliveryID.Text) & COMMA)
        sSQL.Append("PaymentTermID = " & SQLString(tdbcPaymentTermID.Text) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("D06VoucherTypeID = " & SQLString(tdbcD06VoucherTypeID.Text) & COMMA) 'D06VoucherTypeID, varchar[20], NOT NULL
        sSQL.Append("D06VoucherNo = " & SQLString(txtD06VoucherNo.Text) & COMMA) 'D06VoucherNo, varchar[20], NOT NULL
        sSQL.Append("D06DocNo = " & SQLString(txtD06DocNo.Text) & COMMA) 'D06VoucherNo, varchar[20], NOT NULL
        sSQL.Append("D06DocDate = " & SQLDateSave(c1dateD06DocDate.Text) & COMMA) 'datetime, NULL
        sSQL.Append("Notes = " & SQLStringUnicode(txtNote.Text, gbUnicode, False) & COMMA)
        sSQL.Append("NotesU = " & SQLStringUnicode(txtNote.Text, gbUnicode, True) & COMMA)
        sSQL.Append("LCNo = " & SQLString(tdbcLCNo.Text))

        sSQL.Append(" Where ")
        sSQL.Append("POID = " & SQLString(_pOID))

        Return sSQL
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD12T2060
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 04/11/2008 02:58:32
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD12T2060(ByVal sPOID As String) As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D12T2060"
        sSQL &= " Where "
        sSQL &= "POID = " & SQLString(sPOID)
        Return sSQL
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD12T2060s
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 04/11/2008 03:07:04
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD12T2060s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        Dim sPOItemID As String = ""

        Dim iCountIGE As Integer = 0
        Dim iFirstIGEPOItemID As Long

        If _FormState = EnumFormState.FormEdit Then
            For i As Integer = 0 To tdbg.RowCount - 1
                If tdbg(i, COL_POItemID).ToString = "" Then
                    iCountIGE = iCountIGE + 1
                End If
            Next
        Else
            iCountIGE = tdbg.RowCount
        End If

        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_POItemID).ToString = "" Then
                sPOItemID = CreateIGENewS("D12T2060", "POItemID", "12", "OI", gsStringKey, sPOItemID, iCountIGE, iFirstIGEPOItemID)
                tdbg(i, COL_POItemID) = sPOItemID
            End If

            sSQL.Append("Insert Into D12T2060(")
            sSQL.Append("POID, POItemID, PRID, PRTransactionID, SupplierTransID, " & vbCrLf)
            sSQL.Append("OrderNum, InventoryID, InventoryName, InventoryNameU, UnitID, WareHouseID, DetailDesc, DetailDescU, " & vbCrLf)
            sSQL.Append("OQuantity, CQuantity, UnitPrice, OAmount, CAmount, " & vbCrLf)
            sSQL.Append("Ana01ID, Ana02ID, Ana03ID, Ana04ID, Ana05ID, Ana06ID, Ana07ID, Ana08ID, Ana09ID, Ana10ID," & vbCrLf)
            sSQL.Append("MPSVoucherID, RateTax, VATGroupID, VATOAmount, VATCAmount, " & vbCrLf)
            sSQL.Append("NRef1, NRef2, NRef3, NRef4, NRef5," & vbCrLf)
            sSQL.Append(" VRef1, VRef2, VRef3, VRef4, VRef5, VRef1U, VRef2U, VRef3U, VRef4U, VRef5U, " & vbCrLf)
            sSQL.Append("DRef1,DRef2, DRef3, DRef4, DRef5," & vbCrLf)
            sSQL.Append("Spec01ID, Spec02ID, Spec03ID, Spec04ID, Spec05ID, Spec06ID, Spec07ID, Spec08ID, Spec09ID, Spec10ID, " & vbCrLf)
            sSQL.Append("ExpectDate, ExpiryDate, ProductID, LocationNo, PeriodID, D06OQuantity, D06CQuantity, ")
            sSQL.Append("ProjectID, ProjectName, ProjectNameU, TaskID, TaskName, TaskNameU" & vbCrLf)
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(_pOID) & COMMA) 'POID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_POItemID)) & COMMA) 'POItemID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_PRID)) & COMMA) 'PRID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_PRTransactionID)) & COMMA) 'PRTransactionID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_SupplierTransID)) & COMMA & vbCrLf) 'SupplierTransID, varchar[20], NOT NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_OrderNum)) & COMMA) 'OrderNum, int, NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_InventoryID)) & COMMA) 'InventoryID, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_InventoryName), gbUnicode, False) & COMMA) 'InventoryName, varchar[100], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_InventoryName), gbUnicode, True) & COMMA) 'InventoryName, varchar[100], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_UnitID)) & COMMA) 'UnitID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_WarehouseID)) & COMMA) 'WareHouseID, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_DetailDesc), gbUnicode, False) & COMMA & vbCrLf)
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_DetailDesc), gbUnicode, True) & COMMA & vbCrLf)
            sSQL.Append(SQLMoney(tdbg(i, COL_OQuantity), tdbg.Columns(COL_OQuantity).NumberFormat) & COMMA) 'OQuantity, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_CQuantity), tdbg.Columns(COL_CQuantity).NumberFormat) & COMMA) 'CQuantity, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_UnitPrice), tdbg.Columns(COL_UnitPrice).NumberFormat) & COMMA) 'UnitPrice, money, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_OAmount), tdbg.Columns(COL_OAmount).NumberFormat) & COMMA) 'OAmount, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_CAmount).ToString, tdbg.Columns(COL_CAmount).NumberFormat) & COMMA & vbCrLf) 'CAmount, decimal, NOT NULL


            For k As Integer = 0 To 9
                sSQL.Append(SQLString(tdbg(i, COL_Ana01ID + k)) & COMMA) 'Ana01ID, varchar[20], NOT NULL
            Next k
            sSQL.Append(vbCrLf)

            sSQL.Append(SQLString(tdbg(i, COL_MPSVoucherID)) & COMMA) 'MPSVoucherID, varchar[20], NOT NULL
            Dim dblRateTax As Double = Number(tdbg(i, COL_RateTax)) / 100
            sSQL.Append(SQLMoney(tdbg(i, COL_RateTax), DxxFormat.DefaultNumber4) & COMMA) 'RateTax, smallmoney, NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_VATGroupID)) & COMMA) 'VATGroupID, varchar[20], NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_VATOAmount), tdbg.Columns(COL_VATOAmount).NumberFormat) & COMMA) 'VATOAmount, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_VATCAmount), tdbg.Columns(COL_VATCAmount).NumberFormat) & COMMA & vbCrLf) 'VATCAmount, decimal, NOT NULL

            sSQL.Append(SQLMoney(tdbg(i, COL_NRef1), DxxFormat.DefaultNumber2) & COMMA) 'NRef1, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_NRef2), DxxFormat.DefaultNumber2) & COMMA) 'NRef2, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_NRef3), DxxFormat.DefaultNumber2) & COMMA) 'NRef3, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_NRef4), DxxFormat.DefaultNumber2) & COMMA) 'NRef4, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_NRef5), DxxFormat.DefaultNumber2) & COMMA & vbCrLf) 'NRef5, decimal, NOT NULL

            sSQL.Append(SQLStringUnicode(tdbg(i, COL_VRef1), gbUnicode, False) & COMMA) 'VRef1, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_VRef2), gbUnicode, False) & COMMA) 'VRef2, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_VRef3), gbUnicode, False) & COMMA) 'VRef3, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_VRef4), gbUnicode, False) & COMMA) 'VRef4, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_VRef5), gbUnicode, False) & COMMA & vbCrLf) 'VRef5, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_VRef1), gbUnicode, True) & COMMA) 'VRef1, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_VRef2), gbUnicode, True) & COMMA) 'VRef2, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_VRef3), gbUnicode, True) & COMMA) 'VRef3, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_VRef4), gbUnicode, True) & COMMA) 'VRef4, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_VRef5), gbUnicode, True) & COMMA & vbCrLf) 'VRef5, varchar[250], NOT NULL

            sSQL.Append(SQLDateSave(tdbg(i, COL_DRef1)) & COMMA) 'DRef1, datetime, NULL
            sSQL.Append(SQLDateSave(tdbg(i, COL_DRef2)) & COMMA) 'DRef2, datetime, NULL
            sSQL.Append(SQLDateSave(tdbg(i, COL_DRef3)) & COMMA) 'DRef3, datetime, NULL
            sSQL.Append(SQLDateSave(tdbg(i, COL_DRef4)) & COMMA) 'DRef4, datetime, NULL
            sSQL.Append(SQLDateSave(tdbg(i, COL_DRef5)) & COMMA & vbCrLf) 'DRef5, datetime, NULL

            For k As Integer = 0 To 9
                sSQL.Append(SQLString(tdbg(i, COL_Spec01ID + k)) & COMMA) 'Spec01ID, varchar[20], NOT NULL
            Next k

            sSQL.Append(vbCrLf)

            sSQL.Append(SQLDateSave(tdbg(i, COL_DExpectDate)) & COMMA) 'ExpectDate, datetime, NULL
            sSQL.Append(SQLDateSave(tdbg(i, COL_ExpiryDate)) & COMMA) 'ExpiryDate, datetime, NULL
            sSQL.Append(SQLString(tdbg(i, COL_ProductID)) & COMMA) 'ProductID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_LocationNo)) & COMMA) 'LocationNo, varchar[30], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_PeriodID)) & COMMA) 'PeriodID, varchar[20], NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_D06OQuantity), tdbg.Columns(COL_D06OQuantity).NumberFormat) & COMMA) 'D06OQuantity, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_D06CQuantity), tdbg.Columns(COL_D06CQuantity).NumberFormat) & COMMA) 'D06CQuantity, decimal, NOT NULL
            If L3Bool(ReturnValueC1Combo(tdbcTransTypeID, UseD54)) Then
                sSQL.Append(SQLString(tdbg(i, COL_ProjectID)) & COMMA) 'ProjectID, varchar[20], NOT NULL
                sSQL.Append(SQLStringUnicode(tdbg(i, COL_ProjectName), gbUnicode, False) & COMMA) 'ProjectName, varchar[20], NOT NULL
                sSQL.Append(SQLStringUnicode(tdbg(i, COL_ProjectName), gbUnicode, True) & COMMA) 'ProjectNameU, varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_TaskID)) & COMMA) 'TaskID, varchar[20], NOT NULL
                sSQL.Append(SQLStringUnicode(tdbg(i, COL_TaskName), gbUnicode, False) & COMMA) 'TaskName, varchar[20], NOT NULL
                sSQL.Append(SQLStringUnicode(tdbg(i, COL_TaskName), gbUnicode, True)) 'TaskNameU, varchar[20], NOT NULL
            Else
                sSQL.Append("'','',N'','','',N''")
            End If
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD12P3200
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 04/11/2008 04:09:29
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD12P3200() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D12P3200 "
        sSQL &= SQLString(_pOID) & COMMA 'POID, varchar[20], NOT NULL
        sSQL &= SQLNumber(chkPostedD06.Checked) 'PostedD06, tinyint, NOT NULL
        Return sSQL
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD12P3121
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 07/11/2008 11:57:40
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD12P3121() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D12P3121 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(_pOID) & COMMA 'POID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, char, NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA
        sSQL &= SQLNumber(giTranYear) & COMMA
        sSQL &= SQLString("") & COMMA 'VoucherNo, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'IsDate, tinyint, NOT NULL
        sSQL &= SQLDateSave("") & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave("") & COMMA 'DateTo, datetime, NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'FromMonth, int, NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'FromYear, int, NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'ToMonth, int, NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'ToYear, int, NOT NULL
        sSQL &= SQLNumber(gbUnicode)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUDFD12N3000
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 03/11/2008 09:14:07
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUDFD12N3000() As String
        Dim sSQL As String = ""
        sSQL &= "D12N3000("
        sSQL &= SQLString(tdbcTransTypeID.Text) & COMMA 'TranTypeID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) 'Language, varchar[20], NOT NULL
        sSQL &= ")"
        Return sSQL
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If tdbcTransTypeID.Text = "" And _FormState = EnumFormState.FormAdd Then tdbcTransTypeID.Focus() : Exit Sub
        tdbg.UpdateData()
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        'Kiểm tra Ngày phiếu có phù hợp với kỳ kế toán hiện tại không (gọi hàm CheckVoucherDateInPeriod)
        If CheckVoucherDateInPeriod(c1dateVoucherDate.Value.ToString) = False Then c1dateVoucherDate.Focus() : Exit Sub

        'Kiểm tra có quyền nhập Ngày phiếu lớn hơn Ngày GetDate không?
        If CheckVoucherDateWithGetDate(c1dateVoucherDate.Value.ToString, "D12F5704") = False Then c1dateVoucherDate.Focus() : Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Select Case _FormState
            Case EnumFormState.FormAdd
                '****************************************
                'Kiểm tra phiếu theo kiểu mới
                'Sinh IGE cho khóa của Phiếu trước
                _pOID = CreateIGE("D12T2050", "POID", "12", "PO", gsStringKey)
                'Kiểm tra phiếu 
                If tdbcVoucherTypeID.Columns("Auto").Text = "1" And bEditVoucherNo = False Then 'Sinh tự động và không nhấn F2
                    txtVoucherNo.Text = CreateIGEVoucherNoNew(tdbcVoucherTypeID, "D12T2050", _pOID)
                    If tdbcVoucherTypeID.Text = tdbcD06VoucherTypeID.Text Then txtD06VoucherNo.Text = txtVoucherNo.Text
                Else 'Không sinh tự động hay có nhấn F2
                    If bEditVoucherNo = False Then
                        'Kiểm tra trùng Số phiếu
                        If CheckDuplicateVoucherNoNew("D12", "D12T2050", _pOID, txtVoucherNo.Text) = True Then btnSave.Enabled = True : btnClose.Enabled = True : Me.Cursor = Cursors.Default : Exit Sub
                    Else 'Có nhấn F2 để sửa số phiếu
                        'Insert Số phiếu vào bảng D40T5558
                        SQLInsertD12T5558(_pOID, sOldVoucherNo, txtVoucherNo.Text)
                    End If
                    'Insert VoucherNo vào bảng D91T9111
                    InsertVoucherNoD91T9111(txtVoucherNo.Text, "D12T2050", _pOID)
                End If
                '*****************************
                'Modify 20/08/2012  sửa lỗi tăng số tự động
                Dim sTableName As String = IIf(optTypePostedD06_0.Checked, "D06T2510", "D06T2410").ToString
                If chkPostedD06.Checked Then
                    If tdbcVoucherTypeID.Text = tdbcD06VoucherTypeID.Text And txtVoucherNo.Text = txtD06VoucherNo.Text Then
                        'Nếu số phiếu D12 và D06 giống nhau thì k cần sinh thêm nữa (k tăng lastkey)
                    Else
                        'Tăng last key
                        If L3Int(tdbcD06VoucherTypeID.Columns("Auto").Text) <> 0 Then ' Tạo mã tự động
                            txtD06VoucherNo.Text = CreateIGEVoucherNoNew(tdbcD06VoucherTypeID, sTableName, _pOID)
                        Else
                            If CheckDuplicateVoucherNoNew("D06", sTableName, _pOID, txtD06VoucherNo.Text) Then
                                Me.Cursor = Cursors.Default
                                btnSave.Enabled = True
                                btnClose.Enabled = True
                                Exit Sub
                            End If
                            'Insert VoucherNo vào bảng D91T9111
                            InsertVoucherNoD91T9111(txtD06VoucherNo.Text, sTableName, _pOID) '  InsertVoucherNoD91T9111(txtVoucherNo.Text, sTableName, _pOID)
                        End If
                    End If
                End If
                bEditVoucherNo = False
                sOldVoucherNo = ""
                bFirstF2 = False
                '****************************************
                sSQL.Append(SQLInsertD12T2050.ToString & vbCrLf)
                sSQL.Append(SQLDeleteD12T2060("").ToString & vbCrLf)
                sSQL.Append(SQLInsertD12T2060s.ToString & vbCrLf)
            Case EnumFormState.FormEdit
                'Modify 20/08/2012  sửa lỗi tăng số tự động
                Dim sTableName As String = IIf(optTypePostedD06_0.Checked, "D06T2510", "D06T2410").ToString
                If chkPostedD06.Checked Then
                    If tdbcVoucherTypeID.Text = tdbcD06VoucherTypeID.Text And txtVoucherNo.Text = txtD06VoucherNo.Text Then
                        'Nếu số phiếu D12 và D06 giống nhau thì k cần sinh thêm nữa (k tăng lastkey)
                    Else
                        'Tăng last key
                        If L3Int(tdbcD06VoucherTypeID.Columns("Auto").Text) <> 0 Then ' Tạo mã tự động
                            txtD06VoucherNo.Text = CreateIGEVoucherNoNew(tdbcD06VoucherTypeID, sTableName, _pOID)
                        Else
                            If CheckDuplicateVoucherNoNew("D06", sTableName, _pOID, txtD06VoucherNo.Text) Then
                                Me.Cursor = Cursors.Default
                                btnSave.Enabled = True
                                btnClose.Enabled = True
                                Exit Sub
                            End If
                            'Insert VoucherNo vào bảng D91T9111
                            InsertVoucherNoD91T9111(txtD06VoucherNo.Text, sTableName, _pOID) 'InsertVoucherNoD91T9111(txtVoucherNo.Text, sTableName, _pOID)
                        End If
                    End If
                End If
                sSQL.Append(SQLUpdateD12T2050.ToString & vbCrLf)
                sSQL.Append(SQLDeleteD12T2060(_pOID).ToString & vbCrLf)
                sSQL.Append(SQLInsertD12T2060s.ToString & vbCrLf)
        End Select

        sSQL.Append(SQLStoreD12P3200)

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            _bSaved = True
            SaveOK()
            btnAdditionalInfo.Enabled = True
            btnClose.Enabled = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnPrint.Enabled = True

                Case EnumFormState.FormEdit
                    If _FormState = EnumFormState.FormEdit Then
                        'RunAuditLog("AutoSetPurReq", "02", txtVoucherNo.Text + " " + c1dateVoucherDate.Text, txtVoucherDesc.Text, "", "", "")
                        Lemon3.D91.RunAuditLog("12", "AutoSetPurReq", "02", txtVoucherNo.Text + " " + c1dateVoucherDate.Text, txtVoucherDesc.Text, "", "", "") 'ID 84813 29/02/2016
                    End If
                    btnSave.Enabled = True
            End Select
            btnClose.Focus()
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
            btnSave.Focus()
            If _FormState = EnumFormState.FormAdd Then DeleteVoucherNoD91T9111_Transaction(txtVoucherNo.Text, "D12T2050", "VoucherNo", tdbcVoucherTypeID, bEditVoucherNo) 'ID 73378 23/03/2015
        End If
    End Sub

    Private Function AllowSave() As Boolean
        If tdbcTransTypeID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Loai_nghiep_vu"))
            tdbcTransTypeID.Focus()
            Return False
        End If
        If tdbcVoucherTypeID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Loai_phieu"))
            tdbcVoucherTypeID.Focus()
            Return False
        End If
        If txtVoucherNo.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rL3("So_phieu"))
            txtVoucherNo.Focus()
            Return False
        End If

        If chkPostedD06.Checked Then
            If txtD06VoucherNo.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rL3("So_phieu"))
                txtD06VoucherNo.Focus()
                Return False
            End If
        End If

        If c1dateVoucherDate.Value.ToString = "" Then
            D99C0008.MsgNotYetEnter(rL3("Ngay_phieu"))
            c1dateVoucherDate.Focus()
            Return False
        End If
        If tdbcObjectTypeID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Nha_cung_cap"))
            tdbcObjectTypeID.Focus()
            Return False
        End If
        If tdbcObjectID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Nha_cung_cap"))
            tdbcObjectID.Focus()
            Return False
        End If
        If tdbcStatusID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Trang_thai"))
            tdbcStatusID.Focus()
            Return False
        End If
        If tdbcCurrencyID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Loai_tien"))
            tdbcCurrencyID.Focus()
            Return False
        End If

        If tdbcEmployeeID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Nguoi_lap"))
            tdbcEmployeeID.Focus()
            Return False
        End If

        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_UnitPrice).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Don_gia"))
                tdbg.SplitIndex = SPLIT1
                tdbg.Col = COL_UnitPrice
                tdbg.Bookmark = i
                tdbg.Focus()
                Return False
            End If

            If chkPostedD06.Checked AndAlso Number(tdbg(i, COL_D06OQuantity)) = 0 Then
                D99C0008.MsgNotYetEnter(rL3("SL_chuyen_modunle_Mua_hang"))
                tdbg.SplitIndex = SPLIT1
                tdbg.Col = COL_D06OQuantity
                tdbg.Bookmark = i
                tdbg.Focus()
                Return False
            End If
            For k As Integer = 0 To 9
                If L3Bool(tdbg.Columns(COL_Ana01ID + k).Tag) Then
                    If tdbg(i, COL_Ana01ID + k).ToString = "" Then
                        Select Case CInt(tdbcTransTypeID.Columns("CheckAna" & (k + 1).ToString("00") & "ID").Text)
                            Case 1
                                D99C0008.MsgNotYetEnter(rL3("Khoan_muc"))
                                ChangeButtonClick(ButtonForGrid.Ana)
                                tdbg.SplitIndex = SPLIT1
                                tdbg.Col = COL_Ana01ID + k
                                tdbg.Bookmark = i
                                tdbg.Focus()
                                Return False

                            Case 2
                                If xCheckAna(k) = False Then
                                    xCheckAna(k) = True
                                    If D99C0008.Msg(rL3("Ban_chua_nhap") & " " & rL3("Khoan_muc") & "." & " " & rL3("Ban_co_muon_nhap_khong"), rL3("Thong_bao"), L3MessageBoxButtons.YesNo, L3MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                        ChangeButtonClick(ButtonForGrid.Ana)
                                        tdbg.SplitIndex = SPLIT1
                                        tdbg.Col = COL_Ana01ID + k
                                        tdbg.Bookmark = i
                                        tdbg.Focus()
                                        Return False
                                    End If

                                End If
                        End Select
                    End If
                End If

            Next k

        Next
        Return True
    End Function

    Private Sub btnHotKey_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHotKey.Click
        Dim f As New D12F7777
        With f
            .CallShowForm("D12F3110")
            .ShowDialog()
        End With
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If tdbcTransTypeID.Text = "" And _FormState = EnumFormState.FormAdd Then tdbcTransTypeID.Focus() : Exit Sub
        If Not AllowNewD99C2003(report, Me) Then Exit Sub
      
        btnPrint.Enabled = False
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

        sReportName = GetReportPath("D12F3120", sReportName, sCustomReport, sReportPath, sReportTitle)
        If sReportName = "" Then Me.Cursor = Cursors.Default : Exit Sub
        sReportCaption = rL3("Don_dat_hangW") & " - " & sReportName

        sSQL &= SQLStoreD12P3121()
        sSQLSub = "SELECT * FROM D91V0016 Where DivisionID=" & SQLString(gsDivisionID)
        UnicodeSubReport(sSubReportName, sSQLSub, gsDivisionID, gbUnicode)

        With report
            .OpenConnection(conn)
            .AddSub(sSQLSub, sSubReportName & ".rpt")
            .AddMain(sSQL)
            .PrintReport(sReportPath, sReportCaption)
        End With
        Me.Cursor = Cursors.Default
        btnPrint.Enabled = True

        'End If
    End Sub

    Private Sub btnReference_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReference.Click
        'Dim f As New D12F3010
        'f.FormActive = "D12F3010"
        'f.FormPermission = "D12F3010"
        'f.ID02 = "D12F3110"
        'f.ID01 = tdbg.Columns(COL_InventoryID).Text
        'f.ShowDialog()
        'f.Dispose()
        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "MotherForm", Me.Name)
        SetProperties(arrPro, "InventoryID", tdbg.Columns(COL_InventoryID).Text)
        CallFormShow(Me, "D12D4140", "D12F3010", arrPro)
    End Sub

    Private Sub PostedD06_Change()
        optTypePostedD06_0.Enabled = chkPostedD06.Checked
        optTypePostedD06_1.Enabled = chkPostedD06.Checked
        tdbcD06VoucherTypeID.Enabled = chkPostedD06.Checked
        txtD06VoucherNo.Enabled = chkPostedD06.Checked
        chkIsLC.Enabled = chkPostedD06.Checked
        optTypePostedD06_0_CheckedChanged(Nothing, Nothing) 'ID 90240 29/09/2017

        If chkPostedD06.Checked Then
            'Lấy theo  nghiệp vu  'Nếu Loại phiếu D06 <> thì mới sinh số phiếu
            If tdbcTransTypeID.Columns("D06VoucherTypeID").Text <> "" And tdbcTransTypeID.Columns("D06VoucherTypeID").Text <> tdbcVoucherTypeID.Text Then
                tdbcD06VoucherTypeID.SelectedValue = tdbcTransTypeID.Columns("D06VoucherTypeID").Text
            Else
                'Mặc định giá trị, lấy từ số phiếu chung xuống
                If tdbcD06VoucherTypeID.Text = "" Then
                    tdbcD06VoucherTypeID.Text = tdbcVoucherTypeID.Text
                    txtD06VoucherNo.Text = txtVoucherNo.Text
                End If
            End If
            tdbg.Splits(SPLIT1).DisplayColumns(COL_D06OQuantity).Visible = True
            tdbg.Splits(SPLIT1).DisplayColumns(COL_D06CQuantity).Visible = True
        Else
            tdbcD06VoucherTypeID.Text = ""
            txtD06VoucherNo.Text = ""

            tdbg.Splits(SPLIT1).DisplayColumns(COL_D06OQuantity).Visible = False
            tdbg.Splits(SPLIT1).DisplayColumns(COL_D06CQuantity).Visible = False
        End If

        If chkPostedD06.Checked Then
            For i As Integer = 0 To tdbg.RowCount - 1
                If _FormState = EnumFormState.FormAdd Or (Number(tdbg(i, COL_D06OQuantity)) = 0 And _FormState = EnumFormState.FormEdit) Then
                    tdbg(i, COL_D06OQuantity) = tdbg(i, COL_OQuantity)
                    tdbg(i, COL_D06CQuantity) = tdbg(i, COL_CQuantity)
                End If
            Next i
            tdbg.AllowUpdate = False
            Panel1.Enabled = False
        Else
            For i As Integer = 0 To tdbg.RowCount - 1
                tdbg(i, COL_D06OQuantity) = ""
                tdbg(i, COL_D06CQuantity) = ""
            Next
            tdbg.AllowUpdate = True
            Panel1.Enabled = True
        End If

    End Sub

    Private Sub chkPostedD06_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPostedD06.Click
        PostedD06_Change()
        For i As Integer = 0 To tdbg.RowCount - 1
            'UnitPrice_Change(i)
            CalOAmount(i)
            CalCAmount(i)
            CalVATOAmount(i)
            CalVATCAmount(i)
        Next i
        ResetGrid()
    End Sub

    Private Sub optTypePostedD06_0_CheckedChanged(sender As Object, e As EventArgs) Handles optTypePostedD06_0.CheckedChanged
        tdbcD06VoucherTypeID.Text = ""
        txtD06VoucherNo.Text = ""
        '******************************
        'ID 90240 29/09/2017
        txtD06DocNo.Enabled = chkPostedD06.Checked AndAlso optTypePostedD06_0.Checked
        If txtD06DocNo.Enabled = False Then txtD06DocNo.Text = ""
        c1dateD06DocDate.Enabled = chkPostedD06.Checked AndAlso optTypePostedD06_0.Checked
        If c1dateD06DocDate.Enabled = False Then c1dateD06DocDate.Value = ""
    End Sub

End Class
