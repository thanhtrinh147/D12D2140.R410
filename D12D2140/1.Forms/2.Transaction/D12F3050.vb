Imports System
Imports System.Text
Imports System.Windows.Forms
'#-------------------------------------------------------------------------------------
'# Created Date: 23/01/2008 11:31:08 AM
'# Created User: Đỗ Minh Dũng
'# Modify Date: 23/01/2008 11:31:08 AM
'# Modify User: Đỗ Minh Dũng
'#-------------------------------------------------------------------------------------

Public Class D12F3050
    Dim clsFilterDropdown As Lemon3.Controls.FilterDropdown 'ID 93879 12/12/2016

    Private _bSaved As Boolean = False
    Public ReadOnly Property bSaved() As Boolean
        Get
            Return _bSaved
        End Get
    End Property

    Private _FormID As String = ""
    Public WriteOnly Property FormID() As String
        Set(ByVal Value As String)
            _FormID = Value
        End Set
    End Property

#Region "Const of tdbg - Total of Columns: 63"
    Private Const COL_OrderNum As Integer = 0               ' STT
    Private Const COL_PRTransactionID As Integer = 1        ' PRTransactionID
    Private Const COL_PRVoucherNo As Integer = 2            ' Số chứng từ
    Private Const COL_InventoryID As Integer = 3            ' Mã hàng
    Private Const COL_InventoryName As Integer = 4          ' Tên hàng
    Private Const COL_Spec01ID As Integer = 5               ' Spec01ID
    Private Const COL_Spec02ID As Integer = 6               ' Spec02ID
    Private Const COL_Spec03ID As Integer = 7               ' Spec03ID
    Private Const COL_Spec04ID As Integer = 8               ' Spec04ID
    Private Const COL_Spec05ID As Integer = 9               ' Spec05ID
    Private Const COL_Spec06ID As Integer = 10              ' Spec06ID
    Private Const COL_Spec07ID As Integer = 11              ' Spec07ID
    Private Const COL_Spec08ID As Integer = 12              ' Spec08ID
    Private Const COL_Spec09ID As Integer = 13              ' Spec09ID
    Private Const COL_Spec10ID As Integer = 14              ' Spec10ID
    Private Const COL_UnitID As Integer = 15                ' ĐVT
    Private Const COL_DetailDesc As Integer = 16            ' Diễn giải
    Private Const COL_ProjectID As Integer = 17             ' Mã dự án
    Private Const COL_ProjectName As Integer = 18           ' Tên dự án
    Private Const COL_TaskID As Integer = 19                ' Mã hạng mục
    Private Const COL_TaskName As Integer = 20              ' Tên hạng mục
    Private Const COL_ApprovedQuantity As Integer = 21      ' SL yêu cầu
    Private Const COL_POQuantity As Integer = 22            ' SL được phép lập đơn đặt hàng
    Private Const COL_ObjectTypeID As Integer = 23          ' Loại đối tượng
    Private Const COL_ObjectID As Integer = 24              ' Đối tượng
    Private Const COL_ObjectName As Integer = 25            ' Tên đối tượng
    Private Const COL_CurrencyID As Integer = 26            ' Loại tiền
    Private Const COL_ExchangeRate As Integer = 27          ' Tỷ giá
    Private Const COL_MinQuantity As Integer = 28           ' SL đặt hàng tối thiểu
    Private Const COL_OQuantity As Integer = 29             ' SL đặt hàng
    Private Const COL_CQuantity As Integer = 30             ' SL đặt hàng QĐ
    Private Const COL_PRConversionFactor As Integer = 31    ' PRConversionFactor
    Private Const COL_SupplyUnitID As Integer = 32          ' ĐVT theo NCC
    Private Const COL_SupplyOQuantity As Integer = 33       ' SL theo NCC
    Private Const COL_SupplyCQuantity As Integer = 34       ' SL QĐ theo NCC
    Private Const COL_ConversionFactor As Integer = 35      ' ConversionFactor
    Private Const COL_UnitPrice As Integer = 36             ' Đơn giá
    Private Const COL_OAmount As Integer = 37               ' Thành tiền
    Private Const COL_VATGroupID As Integer = 38            ' Nhóm thuế
    Private Const COL_RateTax As Integer = 39               ' Thuế suất
    Private Const COL_VATOAmount As Integer = 40            ' Tiền thuế NT
    Private Const COL_IsUsed As Integer = 41                ' IsUsed
    Private Const COL_SupplierTransID As Integer = 42       ' SupplierTransID
    Private Const COL_PRID As Integer = 43                  ' PRID
    Private Const COL_LockObj As Integer = 44               ' LockObj
    Private Const COL_OriginalDecimal As Integer = 45       ' OriginalDecimal
    Private Const COL_ExchangeRateDecimal As Integer = 46   ' ExchangeRateDecimal
    Private Const COL_PurchasePriceDecimals As Integer = 47 ' PurchasePriceDecimals
    Private Const COL_NRef1 As Integer = 48                 ' NRef1
    Private Const COL_NRef2 As Integer = 49                 ' NRef2
    Private Const COL_NRef3 As Integer = 50                 ' NRef3
    Private Const COL_NRef4 As Integer = 51                 ' NRef4
    Private Const COL_NRef5 As Integer = 52                 ' NRef5
    Private Const COL_VRef1 As Integer = 53                 ' VRef1
    Private Const COL_VRef2 As Integer = 54                 ' VRef2
    Private Const COL_VRef3 As Integer = 55                 ' VRef3
    Private Const COL_VRef4 As Integer = 56                 ' VRef4
    Private Const COL_VRef5 As Integer = 57                 ' VRef5
    Private Const COL_DRef1 As Integer = 58                 ' DRef1
    Private Const COL_DRef2 As Integer = 59                 ' DRef2
    Private Const COL_DRef3 As Integer = 60                 ' DRef3
    Private Const COL_DRef4 As Integer = 61                 ' DRef4
    Private Const COL_DRef5 As Integer = 62                 ' DRef5
#End Region


#Region "Properties"

    Private _selectedSupplier As Integer = 0 '1: Đã có nhà cung cấp 
    Public WriteOnly Property SelectedSupplier() As Integer
        Set(ByVal Value As Integer)
            _selectedSupplier = Value
        End Set
    End Property

    Private _autoSelectSupplier As Integer = 0 '1: Lựa chọn nhà cung cấp tự động
    Public WriteOnly Property AutoSelectSupplier() As Integer
        Set(ByVal Value As Integer)
            _autoSelectSupplier = Value
        End Set
    End Property

    Private _baseOnPrice As Integer = 0 '1: Ưu tiên 1
    Public WriteOnly Property BaseOnPrice() As Integer
        Set(ByVal Value As Integer)
            _baseOnPrice = Value
        End Set
    End Property

    Private _baseONPriority As Integer = 0 '1: Ưu tiên 2
    Public WriteOnly Property BaseONPriority() As Integer
        Set(ByVal Value As Integer)
            _baseONPriority = Value
        End Set
    End Property

    Private _baseDeliveryDay As Integer = 0 '1 :'Ưu tiên 3
    Public WriteOnly Property BaseDeliveryDay() As Integer
        Set(ByVal Value As Integer)
            _baseDeliveryDay = Value
        End Set
    End Property

    Private _value1 As String = ""
    Public WriteOnly Property Value1() As String
        Set(ByVal Value As String)
            _value1 = Value
        End Set
    End Property

    Private _value2 As String = ""
    Public WriteOnly Property Value2() As String
        Set(ByVal Value As String)
            _value2 = Value
        End Set
    End Property

    Private _value3 As String = ""
    Public WriteOnly Property Value3() As String
        Set(ByVal Value As String)
            _value3 = Value
        End Set
    End Property

    Private _sQLLoadData As String = ""
    Public WriteOnly Property SQLLoadData() As String
        Set(ByVal Value As String)
            _sQLLoadData = Value
        End Set
    End Property

#End Region

    Dim iOriginalRowCount As Integer = 0 'biến dùng trong TH Chọn nhà cung cấp tự động, khóa 2 cột ObjectType và Object
    Dim dt1Row As DataTable
    Dim dtObjectTypeID, dtObjectID As DataTable
    Dim bLockRow As Boolean = False
    Dim sSQL_Obj As String
    Dim SumOQuantity As Double = 0
    Dim bShiftInsert As Boolean = False
    Dim bUseSpec As Boolean

    Private Sub D12F3050_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Dim sSQL As String = SQLDeleteD12T2030(gsUserID)
        ExecuteSQLNoTransaction(sSQL)
        If usrOption IsNot Nothing Then usrOption.Dispose()
    End Sub

    Private Sub D12F3050_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F12
                btnF12_Click(Nothing, Nothing)
            Case Keys.Escape
                usrOption.picClose_Click(Nothing, Nothing)
            Case Keys.Enter
                UseEnterAsTab(Me)
        End Select
    End Sub

    Private Sub D12F3050_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        clsFilterDropdown = New Lemon3.Controls.FilterDropdown()
        clsFilterDropdown.CheckD91 = True 'Giá trị mặc định True: kiểm tra theo DxxFormat.LoadFormNotINV. Ngược lại luôn luôn Filter dạng mới (dùng cho Novaland)
        clsFilterDropdown.UseFilterDropdown(tdbg, COL_ObjectID) 'ID 93879 12/12/2016
        '*************************
        _bSaved = False
        bUseSpec = LoadTDBGridSpecificationCaption(tdbg, COL_Spec01ID, 0, True, gbUnicode)
        Loadlanguage()
        ResetFooterGrid(tdbg)
        tdbg_LockedColumns()
        tdbg_NumberFormat()
        LoadTDBDropDown()
        VisibledCol()
        LoadSubInfo()   'ID-136134
        '***********************
        'ID 83214 27/01/2016
        LoadTDBGrid()
        ResetColorGrid(tdbg, 0, tdbg.Splits.Count - 1)
        'LoadDefault_COL_UnitPrice()
        Loaddt1Row()
        If _baseOnPrice = 0 And _baseONPriority = 0 And _baseDeliveryDay = 0 Then
            LoadTable_ObjectTypeID()
            LoadTable_ObjectID()
        End If

        For i As Integer = 0 To tdbg.RowCount - 1
            LoadDefaultOnObject1Row(i)
        Next i

        CallD99U1111()
        InputbyUnicode(Me, gbUnicode)
        SetBackColorObligatory() '2/8/2018, id 110407-AICA - Sửa:" Các trường: Loại đối tượng, Đối tượng, Loại tiền;(màn hình D12F3050) bắt buộc nhập nhưng không hiển thị màu nền bắt buộc nhập"
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rL3("Lua_chon_nha_cung_cap_-_D12F3050") & UnicodeCaption(gbUnicode) 'Løa chãn nhª cung cÊp - D12F3050
        '================================================================ 
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        btnSave.Text = rL3("_Luu") '&Lưu
        btnF12.Text = rL3("Hien_thi") & " (F12)" 'Hiển thị (F12)
        btnGroupInventoryID.Text = rL3("Nhom__ma_hang") 'Nhóm &mã hàng
        '================================================================ 
        tdbdVATGroupID.Columns("VATGroupID").Caption = rL3("Ma") 'Mã
        tdbdVATGroupID.Columns("VATGroupName").Caption = rL3("Ten") 'Tên
        tdbdVATGroupID.Columns("VATRateTax").Caption = rL3("Ma") 'Mã
        tdbdCurrencyID.Columns("CurrencyID").Caption = rL3("Loai_tien") 'Loại tiền
        tdbdCurrencyID.Columns("CurrencyName").Caption = rL3("Ten") 'Tên
        tdbdCurrencyID.Columns("ExchangeRate").Caption = rL3("Ty_gia") 'Tỷ giá
        tdbdObjectID.Columns("ObjectTypeID").Caption = rL3("Loai_DT") 'Loại ĐT
        tdbdObjectID.Columns("ObjectName").Caption = rL3("Ten") 'Tên
        tdbdObjectID.Columns("UnitPrice").Caption = rL3("Don_gia") 'Đơn giá
        tdbdObjectTypeID.Columns("ObjectTypeID").Caption = rL3("Ma") 'Mã
        tdbdObjectTypeID.Columns("ObjectTypeName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns(COL_OrderNum).Caption = rL3("STT")
        tdbg.Columns(COL_PRVoucherNo).Caption = rL3("So_chung_tu")
        tdbg.Columns("InventoryID").Caption = rL3("_Ma_hang") 'Mã hàng
        tdbg.Columns("InventoryName").Caption = rL3("Ten_hang") 'Tên hàng
        tdbg.Columns(COL_UnitID).Caption = rL3("DVT") 'ĐVT

        tdbg.Columns(COL_ProjectID).Caption = rL3("Ma_cong_trinh")          ' Mã dự án
        tdbg.Columns(COL_ProjectName).Caption = rL3("Ten_cong_trinh")           ' Tên dự án
        tdbg.Columns(COL_TaskID).Caption = rL3("Ma_hang_muc")              ' Mã hạng mục
        tdbg.Columns(COL_TaskName).Caption = rL3("Ten_hang_muc")            ' Tên hạng mục

        tdbg.Columns(COL_ApprovedQuantity).Caption = rL3("SL_yeu_cau") 'SL yêu cầu
        tdbg.Columns(COL_POQuantity).Caption = rL3("SL_duoc_phep_lap_don_dat_hang") 'SL được phép lập đơn đặt hàng
        tdbg.Columns(COL_ObjectTypeID).Caption = rL3("Loai_doi_tuong") 'Loại đối tượng
        tdbg.Columns(COL_ObjectID).Caption = rL3("Doi_tuong") 'Đối tượng
        tdbg.Columns(COL_ObjectName).Caption = rL3("Ten_doi_tuong") 'Tên đối tượng
        tdbg.Columns(COL_CurrencyID).Caption = rL3("Loai_tien") 'Loại tiền
        tdbg.Columns(COL_ExchangeRate).Caption = rL3("Ty_gia") 'Tỷ giá
        tdbg.Columns(COL_MinQuantity).Caption = rL3("SL_dat_hang_toi_thieu") 'SL đặt hàng tối thiểu
        tdbg.Columns(COL_OQuantity).Caption = rL3("SL_dat_hang") 'SL đặt hàng
        tdbg.Columns(COL_CQuantity).Caption = rL3("SL_dat_hang_QD") 'SL đặt hàng QĐ
        tdbg.Columns(COL_SupplyUnitID).Caption = rL3("DVT_theo_NCC") 'ĐVT theo NCC
        tdbg.Columns(COL_SupplyOQuantity).Caption = rL3("SL_theo_NCC") 'SL theo NCC
        tdbg.Columns(COL_SupplyCQuantity).Caption = rL3("SL_QD_theo_NCC") 'SL QĐ theo NCC
        tdbg.Columns(COL_UnitPrice).Caption = rL3("Don_gia") 'Đơn giá
        tdbg.Columns(COL_OAmount).Caption = rL3("Thanh_tien") 'Thành tiền
        tdbg.Columns(COL_VATGroupID).Caption = rL3("Nhom_thue") 'Nhóm thuế
        tdbg.Columns(COL_RateTax).Caption = rL3("Thue_suat") 'Thuế suất
        tdbg.Columns(COL_VATOAmount).Caption = rL3("Tien_thue_NT") 'Tiền thuế NT
        tdbg.Columns(COL_DetailDesc).Caption = rL3("Dien_giai") 'Diễn giải
    End Sub

    Private Sub VisibledCol()
        If D12Systems.IsAutoPriceByCQTY = False Then
            tdbg.Splits(2).DisplayColumns(COL_SupplyOQuantity).Visible = False
            tdbg.Splits(2).DisplayColumns(COL_SupplyCQuantity).Visible = False
            tdbg.Splits(2).DisplayColumns(COL_SupplyUnitID).Visible = False
        End If
    End Sub

    Private Sub Loaddt1Row()
        Dim sSQL As String = SQLStoreD12P3054() 'ID 83214 25/01/2016
        dt1Row = ReturnDataTable(sSQL)
    End Sub

    Private Function GetTableObjectTypeID(ByVal sPRID As String, ByVal sPRTransactionID As String) As DataTable
        If _baseOnPrice = 0 And _baseONPriority = 0 And _baseDeliveryDay = 0 Then
            Return dt1Row.DefaultView.ToTable
        Else
            Dim sSQL As String = SQLStoreD12P3055(sPRID, sPRTransactionID, "", 0) 'ID 83214 25/01/2016
            Dim dt As DataTable = ReturnDataTable(sSQL)
            Return dt
        End If
    End Function

    Private Sub LoadTable_ObjectID()
        Dim sSQL As String = SQLStoreD12P3055("", "", "", 1) 'ID 83214 25/01/2016
        dtObjectID = ReturnDataTable(sSQL)
    End Sub

    Private Sub LoadTable_ObjectTypeID()
        Dim sSQL As String = SQLStoreD12P3055("", "", "", 0) 'ID 83214 25/01/2016
        dtObjectTypeID = ReturnDataTable(sSQL)
    End Sub

    Private Sub LoadTdbdObjectTypeID(ByVal sPRID As String, ByVal sPRTransactionID As String)
        If _baseOnPrice = 0 And _baseONPriority = 0 And _baseDeliveryDay = 0 Then
            LoadDataSource(tdbdObjectTypeID, dtObjectTypeID.DefaultView.ToTable, gbUnicode)
        Else
            Dim sSQL As String = SQLStoreD12P3055(sPRID, sPRTransactionID, "", 0) 'ID 83214 25/01/2016
            LoadDataSource(tdbdObjectTypeID, sSQL, gbUnicode)
        End If
    End Sub

    Private Sub LoadTdbdObjectID(ByVal sPRID As String, ByVal sPRTransactionID As String, ByVal sObjectTypeID As String)
        If clsFilterDropdown.IsNewFilter Then
            tdbdObjectID.DisplayColumns("ObjectTypeID").Visible = (sObjectTypeID = "" Or sObjectTypeID = "-1") 'ID 93879 12/12/2016
        Else
            tdbdObjectID.DisplayColumns("ObjectTypeID").Visible = False 'ID 96273 13/04/2017
        End If

        If _baseOnPrice = 0 And _baseONPriority = 0 And _baseDeliveryDay = 0 Then
            Dim dt As DataTable
            If clsFilterDropdown.IsNewFilter Then 'ID 93879 12/12/2016
                If sObjectTypeID = "" Then
                    dt = ReturnTableFilter(dtObjectID, "ObjectID <> '+' ", True)
                Else
                    dt = ReturnTableFilter(dtObjectID, "ObjectTypeID=" & SQLString(sObjectTypeID), True)
                End If
            Else
                dt = ReturnTableFilter(dtObjectID, "ObjectTypeID = " & SQLString(sObjectTypeID), True)
            End If
            LoadDataSource(tdbdObjectID, dt, gbUnicode)
        Else
            Dim sSQL As String = SQLStoreD12P3055(sPRID, sPRTransactionID, sObjectTypeID, 1) 'ID 83214 25/01/2016
            LoadDataSource(tdbdObjectID, sSQL, gbUnicode)
        End If
    End Sub


    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        'Load tdbdVATGroupID
        sSQL = "Select VATGroupID, VATGroupName" & UnicodeJoin(gbUnicode) & " as VATGroupName, Convert(Varchar(10), RateTax*100) + '%' As VATRateTax" & vbCrLf
        sSQL &= "From D91T0040 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled = 0" & vbCrLf
        sSQL &= "Order By VATGroupID"
        LoadDataSource(tdbdVATGroupID, sSQL, gbUnicode)

        'Load tdbdCurrencyID
        '*update 5/4/2013 theo ID 55529 cua Thị Ni bởi Văn Vinh
        sSQL = "--Do nguon dropdown Loai tien" & vbCrLf
        sSQL &= "SELECT CurrencyID, CurrencyName" & UnicodeJoin(gbUnicode) & " As CurrencyName, ExchangeRate, "
        sSQL &= "Operator, OriginalDecimal, ExchangeRateDecimal, UnitPriceDecimals, PurchasePriceDecimals" & vbCrLf
        sSQL &= "FROM D91V0010 WHERE Disabled =0 ORDER BY CurrencyID "
        LoadDataSource(tdbdCurrencyID, sSQL, gbUnicode)
        '*********************************
        ' lOAD OBJECT
        LoadTable_ObjectID()
        LoadDataSource(tdbdObjectID, dtObjectID.DefaultView.ToTable, gbUnicode)
    End Sub

    Dim dtGrid As DataTable
    Private Sub LoadTDBGrid()
        Dim sSQL As String = IIf(_sQLLoadData = "", SQLStoreD12P2035(), _sQLLoadData).ToString
        dtGrid = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ResetGrid() 'ID-144738
    End Sub

    Private Sub ReLoadTDBGrid()
        dtGrid.DefaultView.RowFilter = sFilter.ToString

    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_OrderNum).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_PRTransactionID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_PRVoucherNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_InventoryID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_InventoryName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_Spec01ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_Spec02ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_Spec03ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_Spec04ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_Spec05ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_Spec06ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_Spec07ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_Spec08ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_Spec09ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_Spec10ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_UnitID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        '23/11/2017, Lê Bảo Trâm: id 104908-Lựa chọn NCC bước 1 theo hạng mục
        tdbg.Splits(SPLIT0).DisplayColumns(COL_ProjectID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_ProjectName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_TaskID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_TaskName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)

        tdbg.Splits(SPLIT0).DisplayColumns(COL_DetailDesc).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_ApprovedQuantity).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_POQuantity).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_PRTransactionID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_InventoryID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_InventoryName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec01ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec02ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec03ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec04ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec05ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec06ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec07ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec08ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec09ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_Spec10ID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_UnitID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_ApprovedQuantity).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_POQuantity).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_PRTransactionID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
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
        tdbg.Splits(SPLIT2).DisplayColumns(COL_ApprovedQuantity).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_POQuantity).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_ObjectName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_MinQuantity).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_CQuantity).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_SupplyUnitID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_SupplyOQuantity).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_SupplyCQuantity).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_OAmount).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_RateTax).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_VATOAmount).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_RateTax).NumberFormat = DxxFormat.DefaultNumber2

        Dim arrCol() As FormatColumn = Nothing
        AddDecimalColumns(arrCol, tdbg.Columns(COL_UnitPrice).DataField, DxxFormat.UnitPriceDecimalPlaces, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns(COL_OQuantity).DataField, DxxFormat.D07_QuantityDecimals, 28, 8)
        AddDecimalColumns(arrCol, tdbg.Columns(COL_CQuantity).DataField, DxxFormat.D07_QuantityDecimals, 28, 8)
        AddDecimalColumns(arrCol, tdbg.Columns(COL_SupplyOQuantity).DataField, DxxFormat.D07_QuantityDecimals, 28, 8)
        AddDecimalColumns(arrCol, tdbg.Columns(COL_SupplyCQuantity).DataField, DxxFormat.D07_QuantityDecimals, 28, 8)
        AddDecimalColumns(arrCol, tdbg.Columns(COL_ApprovedQuantity).DataField, DxxFormat.D07_QuantityDecimals, 28, 8)
        AddDecimalColumns(arrCol, tdbg.Columns(COL_POQuantity).DataField, DxxFormat.D07_QuantityDecimals, 28, 8)
        AddDecimalColumns(arrCol, tdbg.Columns(COL_MinQuantity).DataField, DxxFormat.D07_QuantityDecimals, 28, 8)
        AddDecimalColumns(arrCol, tdbg.Columns(COL_ExchangeRate).DataField, DxxFormat.ExchangeRateDecimals, 28, 8)
        AddDecimalColumns(arrCol, tdbg.Columns(COL_OAmount).DataField, DxxFormat.DecimalPlaces, 28, 8)
        AddDecimalColumns(arrCol, tdbg.Columns(COL_VATOAmount).DataField, DxxFormat.DecimalPlaces, 28, 8)

        'Định dạng các cột số trên lưới
        InputNumber(tdbg, arrCol)
    End Sub

#Region "tdbg"

    Private Sub tdbg_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL_ObjectTypeID, COL_CurrencyID, COL_VATGroupID
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                End If
            Case COL_ObjectID
                If clsFilterDropdown.IsNewFilter Then Exit Sub 'ID 93879  12/12/2016
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                End If
            Case COL_OQuantity
                Try
                    SumOQuantity = Number(tdbg.Columns(COL_OQuantity).Text)
                    For i As Integer = 0 To tdbg.RowCount - 1
                        If i <> tdbg.Row And tdbg(i, COL_PRTransactionID).ToString = tdbg.Columns(COL_PRTransactionID).Text Then
                            SumOQuantity += Number(SQLNumber(tdbg(i, COL_OQuantity), tdbg.Columns(COL_OQuantity).NumberFormat))
                        End If
                    Next i
                    If SumOQuantity > Number(tdbg.Columns(COL_POQuantity).Text) Then
                        D99C0008.MsgL3(rL3("So_luong_dat_hang_khong_duoc_phep_lon_hon_so_luong_duoc_phep_lap_DDH"))
                        e.Cancel = True
                    End If
                Catch ex As Exception
                    e.Cancel = True
                End Try
        End Select
    End Sub

    Private Sub tdbg_BeforeDelete(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles tdbg.BeforeDelete
        If Number(tdbg.Columns(COL_IsUsed).Text) = 1 Then e.Cancel = True
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        tdbg.UpdateData()
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        Select Case e.ColIndex
            Case COL_ObjectTypeID, COL_CurrencyID, COL_VATGroupID 'ID 92144 19/10/2016
                Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = tdbg.Columns(e.ColIndex).DropDown ' clsFilterDropdown.GetDropdown(tdbg, e.Column.DataColumn.DataField)
                If tdbd Is Nothing Then Exit Select
                'Dim row As DataRow = ReturnDataRow(tdbd, tdbd.DisplayMember & "=" & SQLString(tdbg.Columns(e.ColIndex).Text))
                Dim row As DataRow = Nothing
                If tdbg.Columns(e.ColIndex).Text <> "" Then row = CType(tdbd.DataSource, DataTable).Rows(tdbd.Row) 'Sửa lỗi bị khi chọn Mã trùng 82152
                AfterColUpdate(e.ColIndex, row)
            Case COL_ObjectID 'ID 93879  12/12/2016
                Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = clsFilterDropdown.GetDropdown(tdbg, e.Column.DataColumn.DataField)
                If tdbd Is Nothing Then Exit Select
                If clsFilterDropdown.IsNewFilter Then
                    Dim dr() As DataRow = clsFilterDropdown.FilterDropdown(tdbg, e, tdbd)
                    AfterColUpdate(e.ColIndex, dr)
                    Exit Sub
                Else ' Nhập liệu dạng cũ (xổ dropdown)
                    Dim row As DataRow = Nothing
                    If tdbg.Columns(e.ColIndex).Text <> "" Then row = CType(tdbd.DataSource, DataTable).Rows(tdbd.Row) 'Sửa lỗi bị khi chọn Mã trùng 82152
                    AfterColUpdate(e.ColIndex, row)
                End If
            Case COL_OQuantity
                tdbg.UpdateData()
                Dim dt As DataTable = ReturnDataTable(SQLStoreD12P3052)
                If dt.Rows.Count > 0 Then
                    tdbg.Columns(COL_UnitPrice).Text = SQLNumber(dt.Rows(0)("UnitPrice").ToString, "N" & tdbg.Columns(COL_PurchasePriceDecimals).Text)
                Else
                    tdbg.Columns(COL_UnitPrice).Text = SQLNumber(0, "N" & tdbg.Columns(COL_PurchasePriceDecimals).Text)
                End If

                CalCQuantity()
                CalSupplyOQuantity()
                CalSupplyCQuantity()
                CalOAmount()
                CalVATOAmount()
                '*******************************
                'SumOQuantity lấy từ BeforeColUpdate
                'Đẩy dữ liệu mới tính xuống dưới 1 dòng
                If Number(SumOQuantity, tdbg.Columns(COL_OQuantity).NumberFormat) < Number(tdbg.Columns(COL_ApprovedQuantity).Text, tdbg.Columns(COL_ApprovedQuantity).NumberFormat) Then
                    bShiftInsert = True
                    tdbg.AllowAddNew = True 'ID 95381 23/02/2017
                    InsertRowBelow(tdbg, SPLIT2, COL_OQuantity)
                    tdbg.Columns(COL_ObjectTypeID).Text = ""
                    tdbg.Columns(COL_ObjectID).Text = ""
                    tdbg.Columns(COL_ObjectName).Text = "" '19/10/2018, id 114044-AICA - Lỗi khi tách số lượng đặt hàng trên màn hình Lựa chọn nhà cung cấp D12F3050
                    tdbg.Columns(COL_SupplierTransID).Text = ""
                    tdbg.Columns(COL_OQuantity).Text = SQLNumber(Number(tdbg(tdbg.Row - 1, COL_ApprovedQuantity)) - SumOQuantity, tdbg.Columns(COL_OQuantity).NumberFormat)
                    '***********************
                    'Tính lại cho dòng mới tách
                    CalCQuantity()
                    CalSupplyOQuantity()
                    CalSupplyCQuantity()
                    CalOAmount()
                    CalVATOAmount()
                    '************************
                    tdbg.SplitIndex = SPLIT2
                    tdbg.Row = tdbg.Row
                    tdbg.Col = COL_OQuantity
                    tdbg.Focus()
                    tdbg.AllowAddNew = False 'ID 95381 23/02/2017
                End If

            Case COL_UnitPrice
                tdbg.Columns(COL_UnitPrice).Text = SQLNumber(tdbg.Columns(COL_UnitPrice).Text, "N" & tdbg.Columns(COL_PurchasePriceDecimals).Text)
                CalOAmount()
                CalVATOAmount()

            Case COL_OAmount
                CalVATOAmount()

        End Select
        '******************
        tdbg.UpdateData()
        ResetGrid() 'ID-144738
    End Sub

    '19/10/2018, id 114044-AICA - Lỗi khi tách số lượng đặt hàng trên màn hình Lựa chọn nhà cung cấp D12F3050
    Private Sub InsertRowBelow(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal SplitIndex As Integer, ByVal ColFirst As Integer)
        Dim iBookmark As Integer = 0
        c1Grid.UpdateData()
        If Not c1Grid.AllowAddNew Or c1Grid.RowCount < 1 Then Exit Sub

        Try
            iBookmark = c1Grid.Bookmark
            Dim drAdd As DataRow
            drAdd = dtGrid.NewRow
            drAdd.ItemArray = dtGrid.Rows(iBookmark).ItemArray
            dtGrid.Rows.InsertAt(drAdd, iBookmark + 1)
            dtGrid.AcceptChanges()
            c1Grid.UpdateData()
            c1Grid.Row = iBookmark + 1
            c1Grid.Focus()
        Catch ex As Exception
            D99C0008.Msg("Lỗi HotKeyShiftInsert: " & ex.Message)
        End Try
    End Sub

    Private Sub tdbg_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles tdbg.BeforeColEdit
        Select Case e.ColIndex
            Case COL_ObjectTypeID
                If L3Bool(_autoSelectSupplier) And tdbg.Columns(COL_LockObj).Text = "1" Then e.Cancel = True
            Case COL_ObjectID
                If L3Bool(_autoSelectSupplier) And tdbg.Columns(COL_LockObj).Text = "1" Then e.Cancel = True
            Case Else
                If Number(tdbg(tdbg.Row, COL_IsUsed)) = 1 Then e.Cancel = True
        End Select
    End Sub

    Private Sub tdbg_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ButtonClick
        If clsFilterDropdown.IsNewFilter = False Then Exit Sub
        If tdbg.AllowUpdate = False Then Exit Sub
        If tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Locked Then Exit Sub
        Select Case tdbg.Col
            Case COL_ObjectID 'ID 93879 12/12/2016
                Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = clsFilterDropdown.GetDropdown(tdbg, tdbg.Columns(tdbg.Col).DataField)
                If tdbd Is Nothing Then Exit Select
                Dim dr() As DataRow = clsFilterDropdown.FilterDropdown(tdbg, e, tdbd)
                If dr Is Nothing Then Exit Sub
                AfterColUpdate(tdbg.Col, dr)
        End Select
    End Sub

    Dim sFilter As New System.Text.StringBuilder()
    'Dim sFilterServer As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False
    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub
            FilterChangeGrid(tdbg, sFilter) 'Nếu có Lọc khi In
            ReLoadTDBGrid()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If clsFilterDropdown.CheckKeydownFilterDropdown(tdbg, e) Then
            Select Case tdbg.Col
                Case COL_ObjectID 'ID 93879 12/12/2016
                    Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = clsFilterDropdown.GetDropdown(tdbg, tdbg.Columns(tdbg.Col).DataField)
                    If tdbd Is Nothing Then Exit Select
                    Dim dr() As DataRow = clsFilterDropdown.FilterDropdown(tdbg, e, tdbd)
                    If dr Is Nothing Then Exit Sub
                    AfterColUpdate(tdbg.Col, dr)
                    Exit Sub
            End Select
        End If
        '**************************
        Select Case e.KeyCode
            Case Keys.Enter
                If tdbg.Col = COL_VATGroupID Then HotKeyEnterGrid(tdbg, COL_ObjectTypeID, e)
            Case Keys.F7
                Select Case tdbg.Col
                    Case COL_ObjectTypeID, COL_ObjectID, COL_CurrencyID, COL_VATGroupID 'ID 92144 19/10/2016
                        HotKeyF7(tdbg)
                        Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = tdbg.Columns(tdbg.Col).DropDown
                        If tdbd Is Nothing Then Exit Select
                        Dim row As DataRow = ReturnDataRow(tdbd, tdbd.DisplayMember & "=" & SQLString(tdbg.Columns(tdbg.Col).Text))
                        AfterColUpdate(tdbg.Col, row)
                End Select
            Case Keys.S
                If e.Control Then HeadClickTask(tdbg.Col)
            Case Keys.Insert
                If e.Shift Then
                    SumOQuantity = Number(tdbg.Columns(COL_OQuantity).Text, tdbg.Columns(COL_OQuantity).NumberFormat)
                    For i As Integer = 0 To tdbg.RowCount - 1
                        If i <> tdbg.Row And tdbg(i, COL_PRTransactionID).ToString = tdbg.Columns(COL_PRTransactionID).Text Then
                            SumOQuantity += Number(SQLNumber(tdbg(i, COL_OQuantity), DxxFormat.D07_QuantityDecimals))
                        End If
                    Next i
                    If Number(tdbg(tdbg.Row - 1, COL_ApprovedQuantity), tdbg.Columns(COL_ApprovedQuantity).NumberFormat) < Number(SumOQuantity, tdbg.Columns(COL_OQuantity).NumberFormat) Then Exit Sub
                    bShiftInsert = True
                    InsertRowBelow(tdbg, SPLIT2, COL_OQuantity)

                    tdbg.Columns(COL_ObjectTypeID).Text = ""
                    tdbg.Columns(COL_ObjectID).Text = ""
                    tdbg.Columns(COL_SupplierTransID).Text = ""
                    tdbg.Columns(COL_OQuantity).Text = SQLNumber(Number(tdbg(tdbg.Row - 1, COL_ApprovedQuantity)) - SumOQuantity, tdbg.Columns(COL_OQuantity).NumberFormat)
                    tdbg.SplitIndex = SPLIT2
                    tdbg.Row = tdbg.Row
                    tdbg.Col = COL_OQuantity
                    tdbg.Focus()
                End If

            Case Keys.F2 'Bỏ theo ID 93879 12/12/2016
                'sSQL = "ObjectTypeID + object.ObjectID in (Select Distinct ObjectTypeID + ObjectID" & vbCrLf
                'sSQL &= "From D12N3050("
                'sSQL &= SQLString(_baseOnPrice) & COMMA
                'sSQL &= SQLString(_baseONPriority) & COMMA
                'sSQL &= SQLString(_baseDeliveryDay) & COMMA
                'sSQL &= SQLString(tdbg.Columns(COL_PRTransactionID).Text) & COMMA
                'sSQL &= SQLString(_value1) & COMMA
                'sSQL &= SQLString(_value2) & COMMA
                'sSQL &= SQLString(_value3) & COMMA
                'sSQL &= "GetDate()" & ")" & vbCrLf
                'sSQL &= "Where ObjectTypeID = " & SQLString(tdbg.Columns(COL_ObjectTypeID).Text) & ")"

                If clsFilterDropdown.IsNewFilter Then Exit Sub 'ID 96273 13/04/2017
                Dim sSQL As String = SQLStoreD12P3055(tdbg(tdbg.Row, COL_PRID).ToString, tdbg(tdbg.Row, COL_PRTransactionID).ToString, tdbg(tdbg.Row, COL_ObjectTypeID).ToString, 1) 'ID 83214 25/01/2016
                If tdbg.Col = COL_ObjectID Then
                    Try
                        Dim arrPro() As StructureProperties = Nothing
                        SetProperties(arrPro, "InListID", "2")
                        SetProperties(arrPro, "InWhere", "")
                        SetProperties(arrPro, "SQLLoadGrid", sSQL) 'ID 96273 13/04/2017
                        Dim frm As Form = CallFormShowDialog("D91D0240", "D91F6010", arrPro)
                        Dim sKey As String = GetProperties(frm, "Output01").ToString
                        If sKey <> "" Then
                            'Load dữ liệu
                            Dim sOutput02 As String = GetProperties(frm, "Output02").ToString
                            Dim sOutput03 As String = GetProperties(frm, "Output03").ToString
                            If tdbg.Columns(COL_ObjectTypeID).Text = "" Then
                                LoadTdbdObjectTypeID(tdbg(tdbg.Row, COL_PRID).ToString, tdbg(tdbg.Row, COL_PRTransactionID).ToString)
                                tdbg.Columns(COL_ObjectTypeID).Text = sOutput02
                                LoadTdbdObjectID(tdbg(tdbg.Row, COL_PRID).ToString, tdbg(tdbg.Row, COL_PRTransactionID).ToString, tdbg(tdbg.Row, COL_ObjectTypeID).ToString)
                            End If
                            tdbg.Columns(COL_ObjectID).Text = sKey
                            tdbg.Columns(COL_ObjectName).Text = sOutput03
                        End If
                        tdbg.UpdateData()
                    Catch ex As Exception
                        D99C0008.MsgL3(ex.Message)
                    End Try
                End If
            Case Else
                If e.Control And e.KeyCode = Keys.Delete Then
                    If Number(tdbg.Columns(COL_IsUsed).Text) = 1 Then Exit Sub
                End If
                If e.Control And e.KeyCode = Keys.V Then
                    If tdbg.FilterActive Then Exit Select
                    tdbg.Columns(tdbg.Col).Text = Clipboard.GetText
                    tdbg.UpdateData()
                End If
                HotKeyDownGrid(e, tdbg, COL_ObjectTypeID, 0, 0, True, True, True)
        End Select

        HotKeyCtrlVOnGrid(tdbg, e, COL_OrderNum)
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        If tdbg.Columns(tdbg.Col).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox Then
            e.Handled = CheckKeyPress(e.KeyChar)
        ElseIf tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far Then
            e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End If
        Select Case tdbg.Col
            Case COL_OrderNum 'Chặn nhập liệu trên cột STT tăng tự động trong code
                e.Handled = CheckKeyPress(e.KeyChar, True)
        End Select
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        If e IsNot Nothing AndAlso e.LastRow = -1 Then Exit Sub
        If bShiftInsert Then
            If tdbg.AddNewMode = C1.Win.C1TrueDBGrid.AddNewModeEnum.AddNewCurrent Then
                tdbg.Columns(COL_SupplierTransID).Text = "" ' Gán 1 c?t b?t k? ="" cho l??i
                bShiftInsert = False
            End If
        End If
        Select Case tdbg.Col
            Case COL_ObjectTypeID
                LoadTdbdObjectTypeID(tdbg(tdbg.Row, COL_PRID).ToString, tdbg(tdbg.Row, COL_PRTransactionID).ToString)
                If L3Bool(_autoSelectSupplier) And tdbg.Columns(COL_LockObj).Text = "1" Then
                    tdbg.Splits(2).DisplayColumns(tdbg.Col).Button = False
                Else
                    tdbg.Splits(2).DisplayColumns(tdbg.Col).Button = True
                End If
            Case COL_ObjectID
                LoadTdbdObjectID(tdbg(tdbg.Row, COL_PRID).ToString, tdbg(tdbg.Row, COL_PRTransactionID).ToString, tdbg(tdbg.Row, COL_ObjectTypeID).ToString)
                If L3Bool(_autoSelectSupplier) And tdbg.Columns(COL_LockObj).Text = "1" Then
                    tdbg.Splits(2).DisplayColumns(tdbg.Col).Button = False
                Else
                    tdbg.Splits(2).DisplayColumns(tdbg.Col).Button = True
                End If
        End Select
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClickTask(e.ColIndex)
    End Sub

    Private Sub HeadClickTask(ByVal iCol As Integer)
        Select Case iCol
            Case COL_ObjectTypeID
                CopyColumns_ObjectTypeID(tdbg, iCol, tdbg.Row)
            Case COL_ObjectID
                CopyColumns_ObjectID(tdbg, iCol, tdbg.Row)
            Case COL_VATGroupID
                CopyColumnArr(tdbg, iCol, New Integer() {COL_RateTax})
                For i As Integer = tdbg.Bookmark To tdbg.RowCount - 1
                    CalVATOAmount(i)
                Next
                tdbg.UpdateData()
            Case COL_CurrencyID 'ID 96427 10/05/2017
                Dim arr() As Integer = {COL_ExchangeRate, COL_OriginalDecimal, COL_PurchasePriceDecimals}
                CopyColumnArr(tdbg, iCol, arr)
                For i As Integer = tdbg.Row To tdbg.RowCount - 1
                    ReFormatCol(i)
                Next
                tdbg.UpdateData()
        End Select
    End Sub

    'DataField của cột ="" nên phải khai báo cột kiểu Integer
    Private Sub tdbg_UnboundColumnFetch(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.UnboundColumnFetchEventArgs) Handles tdbg.UnboundColumnFetch
        Select Case e.Col
            Case COL_OrderNum 'STT
                e.Value = FormatNumber(e.Row + 1, 0).ToString
        End Select
    End Sub

#End Region

    'Hàm format lại khi thay đổi loại tiền
    Private Sub ReFormatCol()
        tdbg.Columns(COL_UnitPrice).Text = SQLNumber(tdbg.Columns(COL_UnitPrice).Text, "N" & tdbg.Columns(COL_PurchasePriceDecimals).Text)
        tdbg.Columns(COL_OAmount).Text = SQLNumber(tdbg.Columns(COL_OAmount).Text, "N" & tdbg.Columns(COL_OriginalDecimal).Text)
    End Sub

#Region "ID 96427 10/05/2017"
    Private Sub ReFormatCol(ByVal i As Integer) 'Dùng cho HeadClick
        tdbg(i, COL_UnitPrice) = SQLNumber(tdbg(i, COL_UnitPrice), "N" & tdbg(i, COL_PurchasePriceDecimals).ToString)
        tdbg(i, COL_OAmount) = SQLNumber(tdbg(i, COL_OAmount), "N" & tdbg(i, COL_OriginalDecimal).ToString)
    End Sub
#End Region

#Region "Tính toán"

    Private Sub CalCQuantity()
        'Tính SL đặt hàng QĐ = SL đặt hàng * Hệ số quy đổi YCMH  
        tdbg.Columns(COL_CQuantity).Text = SQLNumber(Number(tdbg.Columns(COL_OQuantity).Text) * Number(tdbg.Columns(COL_PRConversionFactor).Text), tdbg.Columns(COL_CQuantity).NumberFormat)
    End Sub

    Private Sub CalCQuantity(ByVal i As Integer)
        'Tính SL đặt hàng QĐ = SL đặt hàng * Hệ số quy đổi YCMH  
        tdbg(i, COL_CQuantity) = SQLNumber(Number(tdbg(i, COL_OQuantity), tdbg.Columns(COL_OQuantity).NumberFormat) * Number(tdbg(i, COL_PRConversionFactor)), tdbg.Columns(COL_CQuantity).NumberFormat)
    End Sub

    Private Sub CalSupplyOQuantity()
        'Tính SL theo NCC = SL đặt hàng QĐ / Hệ số quy đổi NCC
        If Number(tdbg.Columns(COL_ConversionFactor).Text) = 0 Then
            tdbg.Columns(COL_SupplyOQuantity).Text = "0"
        Else
            tdbg.Columns(COL_SupplyOQuantity).Text = SQLNumber(Number(tdbg.Columns(COL_CQuantity).Text) / Number(tdbg.Columns(COL_ConversionFactor).Text), tdbg.Columns(COL_SupplyOQuantity).NumberFormat)
        End If
    End Sub

    Private Sub CalSupplyOQuantity(ByVal i As Integer)
        'Tính SL theo NCC = SL đặt hàng QĐ / Hệ số quy đổi NCC
        If Number(tdbg(i, COL_ConversionFactor)) = 0 Then
            tdbg(i, COL_SupplyOQuantity) = "0"
        Else
            tdbg(i, COL_SupplyOQuantity) = SQLNumber(Number(tdbg(i, COL_CQuantity), tdbg.Columns(COL_CQuantity).NumberFormat) / Number(tdbg(i, COL_ConversionFactor)), tdbg.Columns(COL_SupplyOQuantity).NumberFormat)
        End If
    End Sub

    Private Sub CalSupplyCQuantity()
        'Tính SLQĐ theo NCC = SL theo NCC * Hệ số quy đổi NCC
        tdbg.Columns(COL_SupplyCQuantity).Text = SQLNumber(Number(tdbg.Columns(COL_SupplyOQuantity).Text) * Number(tdbg.Columns(COL_ConversionFactor).Text), tdbg.Columns(COL_SupplyCQuantity).NumberFormat)
    End Sub

    Private Sub CalSupplyCQuantity(ByVal i As Integer)
        'Tính SLQĐ theo NCC = SL theo NCC * Hệ số quy đổi NCC
        tdbg(i, COL_SupplyCQuantity) = SQLNumber(Number(tdbg(i, COL_SupplyOQuantity), tdbg.Columns(COL_SupplyOQuantity).NumberFormat) * Number(tdbg(i, COL_ConversionFactor)), tdbg.Columns(COL_SupplyCQuantity).NumberFormat)
    End Sub

    Private Sub CalOAmount()
        If D12Systems.IsAutoPriceByCQTY Then
            'Nếu IsAutoPriceByCQTY = 1 thì Thành tiền = Đơn giá * SL theo NCC
            tdbg.Columns(COL_OAmount).Text = SQLNumber(Number(tdbg.Columns(COL_UnitPrice).Text, "N" & tdbg.Columns(COL_PurchasePriceDecimals).Text) * Number(tdbg.Columns(COL_SupplyOQuantity).Text), "N" & tdbg.Columns(COL_OriginalDecimal).Text)
        Else
            'Thành tiền = Đơn giá * SL 
            tdbg.Columns(COL_OAmount).Text = SQLNumber(Number(tdbg.Columns(COL_UnitPrice).Text, "N" & tdbg.Columns(COL_PurchasePriceDecimals).Text) * Number(tdbg.Columns(COL_OQuantity).Text), "N" & tdbg.Columns(COL_OriginalDecimal).Text)
        End If
    End Sub

    Private Sub CalOAmount(ByVal i As Integer)
        If D12Systems.IsAutoPriceByCQTY Then
            'Nếu IsAutoPriceByCQTY = 1 thì Thành tiền = Đơn giá * SL theo NCC
            tdbg(i, COL_OAmount) = SQLNumber(Number(tdbg(i, COL_UnitPrice), "N" & tdbg(i, COL_PurchasePriceDecimals).ToString) * Number(tdbg(i, COL_SupplyOQuantity), tdbg.Columns(COL_SupplyOQuantity).NumberFormat), "N" & tdbg(i, COL_OriginalDecimal).ToString)
        Else
            'Thành tiền = Đơn giá * SL 
            tdbg(i, COL_OAmount) = SQLNumber(Number(tdbg(i, COL_UnitPrice), "N" & tdbg(i, COL_PurchasePriceDecimals).ToString) * Number(tdbg(i, COL_OQuantity), tdbg.Columns(COL_OQuantity).NumberFormat), "N" & tdbg(i, COL_OriginalDecimal).ToString)
        End If
    End Sub

    Private Sub CalVATOAmount()
        'Thuế GTGT NT = Thành tiền NT * Thuế suất
        tdbg.Columns(COL_VATOAmount).Text = SQLNumber(Number(tdbg.Columns(COL_OAmount).Text, "N" & tdbg.Columns(COL_OriginalDecimal).Text) * Number(tdbg.Columns(COL_RateTax).Text), "N" & tdbg.Columns(COL_OriginalDecimal).Text)
    End Sub

    Private Sub CalVATOAmount(ByVal i As Integer)
        'Thuế GTGT NT = Thành tiền NT * Thuế suất
        tdbg(i, COL_VATOAmount) = SQLNumber(Number(tdbg(i, COL_OAmount), "N" & tdbg(i, COL_OriginalDecimal).ToString) * Number(tdbg(i, COL_RateTax), tdbg.Columns(COL_RateTax).NumberFormat), "N" & tdbg(i, COL_OriginalDecimal).ToString)
    End Sub
#End Region

    Private Sub AfterColUpdate(ByVal iCol As Integer, ByVal dr() As DataRow)
        Dim iRow As Integer = tdbg.Row
        If dr Is Nothing OrElse dr.Length = 0 Then
            Dim row As DataRow = Nothing
            AfterColUpdate(iCol, row)
        ElseIf dr.Length = 1 Then
            If tdbg.Bookmark <> tdbg.Row AndAlso tdbg.RowCount = tdbg.Row Then 'Đang đứng dòng mới
                Dim dr1 As DataRow = dtGrid.NewRow
                dtGrid.Rows.InsertAt(dr1, tdbg.Row)
                tdbg.Bookmark = tdbg.Row
            End If
            AfterColUpdate(iCol, dr(0))
        Else
            For Each row As DataRow In dr
                If tdbg.Bookmark <> tdbg.Row AndAlso tdbg.RowCount = tdbg.Row Then 'Đang đứng dòng mới
                    Dim dr1 As DataRow = dtGrid.NewRow
                    dtGrid.Rows.InsertAt(dr1, tdbg.Row)
                    tdbg.Bookmark = tdbg.Row
                Else
                    tdbg.Row = iRow
                    tdbg.Bookmark = iRow
                End If
                AfterColUpdate(iCol, row)
                tdbg.UpdateData()
                iRow += 1
            Next
            tdbg.Focus()
        End If
    End Sub

    Private Sub AfterColUpdate(ByVal iCol As Integer, ByVal dr As DataRow)
        'Gán lại các giá trị phụ thuộc vào Dropdown
        Select Case iCol
            Case COL_ObjectTypeID
                tdbg.Columns(COL_ObjectID).Text = ""
                tdbg.Columns(COL_SupplyUnitID).Text = ""
                tdbg.Columns(COL_ConversionFactor).Text = "1"
                If dr Is Nothing OrElse dr.Item("ObjectTypeID").ToString = "" Then
                    tdbg.Columns(COL_ObjectTypeID).Text = ""
                Else
                    tdbg.Columns(COL_ObjectTypeID).Text = dr.Item("ObjectTypeID").ToString
                End If
                '**********************
                Dim dt As DataTable = GetTableObjectTypeID(tdbg.Columns(COL_PRID).Text, tdbg.Columns(COL_PRTransactionID).Text)
                Dim dr1() As DataRow = dt.Select("ObjectTypeID = " & SQLString(tdbg.Columns(COL_ObjectTypeID).Text))
                If dr1.Length = 1 Then
                    tdbg.Columns(COL_ObjectTypeID).Text = dr1(0).Item("ObjectTypeID").ToString
                    tdbg.Columns(COL_ObjectID).Text = dr1(0).Item("ObjectID").ToString
                    DefaultSomeCol(dr1(0))
                Else
                    tdbg.Columns(COL_ObjectName).Text = ""
                End If
            Case COL_ObjectID
                If dr Is Nothing OrElse dr.Item("ObjectID").ToString = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_ObjectID).Text = ""
                    tdbg.Columns(COL_ObjectName).Text = ""
                    tdbg.Columns(COL_SupplyUnitID).Text = ""
                    tdbg.Columns(COL_ConversionFactor).Text = "1"
                    tdbg.Columns(COL_SupplyOQuantity).Text = ""
                    tdbg.Columns(COL_SupplyCQuantity).Text = "1"
                Else
                    If tdbg.Columns(COL_ObjectTypeID).Text = "" Then
                        LoadTdbdObjectTypeID(tdbg.Columns(COL_PRID).Text, tdbg.Columns(COL_PRTransactionID).Text)
                        tdbg.Columns(COL_ObjectTypeID).Text = dr.Item("ObjectTypeID").ToString
                        LoadTdbdObjectID(tdbg.Columns(COL_PRID).Text, tdbg.Columns(COL_PRTransactionID).Text, tdbg.Columns(COL_ObjectTypeID).Text)
                    End If
                    tdbg.Columns(COL_ObjectID).Text = dr.Item("ObjectID").ToString
                    tdbg.Columns(COL_ObjectName).Text = dr.Item("ObjectName").ToString
                    tdbg.Columns(COL_SupplyUnitID).Text = dr.Item("SupplyUnitID").ToString
                    tdbg.Columns(COL_ConversionFactor).Text = dr.Item("ConversionFactor").ToString
                    tdbg.Columns(COL_SupplyOQuantity).Text = dr.Item("SupplyOQuantity").ToString
                    tdbg.Columns(COL_SupplyCQuantity).Text = dr.Item("SupplyCQuantity").ToString
                End If
             
                LoadDefaultValue_D12P3051()
                CalSupplyOQuantity()
                CalSupplyCQuantity()
            Case COL_CurrencyID
                If dr Is Nothing OrElse dr.Item("CurrencyID").ToString = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_CurrencyID).Text = ""
                    tdbg.Columns(COL_ExchangeRate).Text = "0"
                    tdbg.Columns(COL_OriginalDecimal).Text = "0"
                    tdbg.Columns(COL_PurchasePriceDecimals).Text = "0"
                Else
                    tdbg.Columns(COL_CurrencyID).Text = dr.Item("CurrencyID").ToString
                    tdbg.Columns(COL_ExchangeRate).Text = dr.Item("ExchangeRate").ToString
                    tdbg.Columns(COL_OriginalDecimal).Text = dr.Item("OriginalDecimal").ToString
                    tdbg.Columns(COL_PurchasePriceDecimals).Text = dr.Item("PurchasePriceDecimals").ToString
                End If
                ReFormatCol()
            Case COL_VATGroupID
                If dr Is Nothing OrElse dr.Item("VATGroupID").ToString = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_VATGroupID).Text = ""
                    tdbg.Columns(COL_RateTax).Text = ""
                Else
                    tdbg.Columns(COL_VATGroupID).Text = dr.Item("VATGroupID").ToString
                    tdbg.Columns(COL_RateTax).Text = dr.Item("VATRateTax").ToString
                End If
                CalVATOAmount()
        End Select
    End Sub

    'Copy cột viết riêng cho loại đối tượng
    Private Sub CopyColumns_ObjectTypeID(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal RowCopy As Int32)
        Dim sValue As String = c1Grid(RowCopy, ColCopy).ToString

        Try
            c1Grid.UpdateData()
            If c1Grid.RowCount < 2 Then Exit Sub

            sValue = c1Grid(RowCopy, ColCopy).ToString

            Dim Flag As DialogResult
            Flag = MessageBox.Show(rL3("Copy_cot_du_lieu_cho") & vbCrLf & rL3("____-_Tat_ca_cac_cot_(nhan_Yes)") & vbCrLf & rL3("____-_Nhung_dong_con_trong_(nhan_No)"), MsgAnnouncement, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            If Flag = Windows.Forms.DialogResult.No Then ' Copy nhung dong con trong

                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    If c1Grid(i, ColCopy).ToString = "" OrElse c1Grid(i, ColCopy).ToString = MaskFormatDateShort OrElse c1Grid(i, ColCopy).ToString = MaskFormatDate OrElse (L3IsNumeric(c1Grid(i, ColCopy).ToString) And Val(c1Grid(i, ColCopy).ToString) = 0) Then
                        c1Grid(i, ColCopy) = sValue

                        If CheckDropdownInList(tdbdObjectTypeID, tdbg(i, COL_ObjectTypeID).ToString) = False Then
                            tdbg(i, COL_ObjectTypeID) = ""
                            tdbg(i, COL_ObjectID) = ""
                            tdbg(i, COL_ObjectName) = ""
                            tdbg(i, COL_ObjectName) = ""
                        End If

                        ObjectTypeIDChange(i, tdbg(RowCopy, COL_CurrencyID).ToString)
                        LoadTdbdObjectTypeID(tdbg(i, COL_PRID).ToString, tdbg(i, COL_PRTransactionID).ToString)
                    End If
                Next

            ElseIf Flag = Windows.Forms.DialogResult.Yes Then ' Copy het
                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    c1Grid(i, ColCopy) = sValue
                    If CheckDropdownInList(tdbdObjectTypeID, tdbg(i, COL_ObjectTypeID).ToString) = False Then
                        tdbg(i, COL_ObjectTypeID) = ""
                        tdbg(i, COL_ObjectID) = ""
                        tdbg(i, COL_ObjectName) = ""
                    End If

                    ObjectTypeIDChange(i, tdbg(RowCopy, COL_CurrencyID).ToString)
                    LoadTdbdObjectTypeID(tdbg(i, COL_PRID).ToString, tdbg(i, COL_PRTransactionID).ToString)
                Next
            Else
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub
    Dim bFirstHeadClick As Boolean = True
    Private Sub CopyColumns_ObjectID(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal RowCopy As Int32)
        Dim sValue As String = c1Grid(RowCopy, ColCopy).ToString
        Dim sValueName As String = c1Grid(RowCopy, ColCopy + 1).ToString

        Try
            c1Grid.UpdateData()
            If c1Grid.RowCount < 2 Then Exit Sub

            sValue = c1Grid(RowCopy, ColCopy).ToString
            bFirstHeadClick = True 'ID-141753
            Dim Flag As DialogResult
            Flag = MessageBox.Show(rL3("Copy_cot_du_lieu_cho") & vbCrLf & rL3("____-_Tat_ca_cac_cot_(nhan_Yes)") & vbCrLf & rL3("____-_Nhung_dong_con_trong_(nhan_No)"), MsgAnnouncement, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            If Flag = Windows.Forms.DialogResult.No Then ' Copy nhung dong con trong

                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    If c1Grid(i, ColCopy).ToString = "" OrElse c1Grid(i, ColCopy).ToString = MaskFormatDateShort OrElse c1Grid(i, ColCopy).ToString = MaskFormatDate OrElse (L3IsNumeric(c1Grid(i, ColCopy).ToString) And Val(c1Grid(i, ColCopy).ToString) = 0) Then
                        c1Grid(i, ColCopy) = sValue
                        c1Grid(i, ColCopy + 1) = sValueName
                        If CheckDropdownInList(tdbdObjectID, tdbg(i, COL_ObjectID).ToString) = False Then
                            tdbg(i, COL_ObjectID) = ""
                            tdbg(i, COL_ObjectName) = ""
                        End If

                        LoadDefaultValue_D12P3051(i, tdbg(RowCopy, COL_CurrencyID).ToString)
                        LoadTdbdObjectID(tdbg(i, COL_PRID).ToString, tdbg(i, COL_PRTransactionID).ToString, tdbg(i, COL_ObjectTypeID).ToString)
                    End If
                Next

            ElseIf Flag = Windows.Forms.DialogResult.Yes Then ' Copy het             
                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    c1Grid(i, ColCopy) = sValue
                    c1Grid(i, ColCopy + 1) = sValueName

                    If CheckDropdownInList(tdbdObjectID, tdbg(i, COL_ObjectID).ToString) = False Then
                        tdbg(i, COL_ObjectID) = ""
                        tdbg(i, COL_ObjectName) = ""
                    End If

                    LoadDefaultValue_D12P3051(i, tdbg(RowCopy, COL_CurrencyID).ToString, tdbg(RowCopy, "ExchangeRate").ToString)
                    LoadTdbdObjectID(tdbg(i, COL_PRID).ToString, tdbg(i, COL_PRTransactionID).ToString, tdbg(i, COL_ObjectTypeID).ToString)
                Next
            Else
                Exit Sub
            End If
        Catch ex As Exception

        End Try

    End Sub
    Dim _bChangeUnitPriceHeadClick = False
    Private Sub DefaultSomeCol(ByVal drRow As DataRow, Optional ByVal i As Integer = -1, Optional ByVal sNewCurrency As String = "", Optional ByVal sExchangeRate As String = "")
        Dim dt As DataTable
        With drRow
            If i = -1 Then
                tdbg.Columns(COL_CurrencyID).Text = .Item("CurrencyID").ToString
                tdbg.Columns(COL_ExchangeRate).Text = SQLNumber(.Item("ExchangeRate"), tdbg.Columns(COL_ExchangeRate).NumberFormat)
                '*18/4/2013 theo ID 55529
                tdbg.Columns(COL_OriginalDecimal).Text = .Item("OriginalDecimal").ToString
                tdbg.Columns(COL_PurchasePriceDecimals).Text = .Item("PurchasePriceDecimals").ToString
                If L3Int(tdbg .Columns (COL_UnitPrice).Text) <> 0 
                    If D99C0008.MsgAsk(rL3("Ban_co_muon_thay_doi_don_gia_theo_doi_tuong_da_chon_khong")) = Windows.Forms.DialogResult.Yes Then '119803 - 03 june 2019
                        tdbg.Columns(COL_UnitPrice).Text = SQLNumber(.Item("UnitPRice"), "N" & tdbg.Columns(COL_PurchasePriceDecimals).Text)
                         tdbg.Columns(COL_UnitPrice).Tag = True
                    End If
                End If
                tdbg.Columns(COL_MinQuantity).Text = SQLNumber(.Item("MinQuantity"), tdbg.Columns(COL_MinQuantity).NumberFormat)
                tdbg.Columns(COL_OQuantity).Text = SQLNumber(IIf(Number(tdbg.Columns(COL_OQuantity).Text, tdbg.Columns(COL_OQuantity).NumberFormat) = 0, .Item("OQuantity"), tdbg.Columns(COL_OQuantity).Text).ToString, tdbg.Columns(COL_OQuantity).NumberFormat)
                '*********************************************
                If Number(tdbg.Columns(COL_OQuantity).Text) = 0 Then
                    If Number(tdbg.Columns(COL_ApprovedQuantity).Text, tdbg.Columns(COL_ApprovedQuantity).NumberFormat) >= Number(tdbg.Columns(COL_MinQuantity).Text, tdbg.Columns(COL_MinQuantity).NumberFormat) Then
                        tdbg.Columns(COL_OQuantity).Text = tdbg.Columns(COL_ApprovedQuantity).Text
                    Else
                        tdbg.Columns(COL_OQuantity).Text = tdbg.Columns(COL_MinQuantity).Text
                    End If
                End If

                If tdbg.Columns(COL_UnitPrice).Tag IsNot Nothing andalso L3Bool (tdbg.Columns(COL_UnitPrice).Tag) = True  Then
                    dt = ReturnDataTable(SQLStoreD12P3052)

                    If dt.Rows.Count > 0 Then
                        tdbg.Columns(COL_UnitPrice).Text = SQLNumber(dt.Rows(0)("UnitPrice").ToString, "N" & tdbg.Columns(COL_PurchasePriceDecimals).Text)
                    Else
                        tdbg.Columns(COL_UnitPrice).Text = SQLNumber(0, "N" & tdbg.Columns(COL_PurchasePriceDecimals).Text)
                    End If
                End If
              tdbg.Columns(COL_UnitPrice).Tag = False 

                tdbg.Columns(COL_SupplyUnitID).Text = .Item("SupplyUnitID").ToString
                tdbg.Columns(COL_ConversionFactor).Text = .Item("ConversionFactor").ToString

                CalCQuantity()
                CalSupplyOQuantity()
                CalSupplyCQuantity()
                CalOAmount()
                CalVATOAmount()
            Else
                If bFirstHeadClick = True Then 'ID-141752
                    If L3Int(tdbg.Columns(COL_UnitPrice).Text) <> 0 Then
                        If D99C0008.MsgAsk(rL3("Ban_co_muon_thay_doi_don_gia_theo_doi_tuong_da_chon_khong")) = Windows.Forms.DialogResult.Yes Then '119803 - 03 june 2019  
                            _bChangeUnitPriceHeadClick = True
                        Else
                            _bChangeUnitPriceHeadClick = False
                        End If
                        bFirstHeadClick = False
                    Else
                        _bChangeUnitPriceHeadClick = True
                        bFirstHeadClick = False
                    End If
                End If
                tdbg(i, COL_CurrencyID) = IIf(.Item("CurrencyID").ToString = "", sNewCurrency, .Item("CurrencyID").ToString)
                '*18/4/2013 theo ID 55529
                tdbg(i, COL_OriginalDecimal) = .Item("OriginalDecimal").ToString
                tdbg(i, COL_PurchasePriceDecimals) = .Item("PurchasePriceDecimals").ToString
                '*********************************************
                If Number(.Item("ExchangeRate"), tdbg.Columns(COL_ExchangeRate).NumberFormat) <> 0 Then
                    tdbg(i, COL_ExchangeRate) = Number(.Item("ExchangeRate"), tdbg.Columns(COL_ExchangeRate).NumberFormat)
                Else
                    If Number(sExchangeRate, tdbg.Columns(COL_ExchangeRate).NumberFormat) <> 0 Then
                        tdbg(i, COL_ExchangeRate) = Number(sExchangeRate, tdbg.Columns(COL_ExchangeRate).NumberFormat)
                    Else
                        Dim dt1 As DataTable = CType(tdbdCurrencyID.DataSource, DataTable)
                        Dim dr1() As DataRow = dt1.Select("CurrencyID = " & SQLString(tdbg(i, COL_CurrencyID)))
                        If dr1.Length > 0 Then tdbg(i, COL_ExchangeRate) = Number(dr1(0).Item("ExchangeRate").ToString, tdbg.Columns(COL_ExchangeRate).NumberFormat)
                    End If
                End If
                If _bChangeUnitPriceHeadClick = True Then 'ID-141752
                    tdbg(i, COL_UnitPrice) = Number(.Item("UnitPRice"), "N" & tdbg(i, COL_PurchasePriceDecimals).ToString)
                End If
                'tdbg(i, COL_UnitPrice) = Number(.Item("UnitPRice"), "N" & tdbg(i, COL_PurchasePriceDecimals).ToString)
                tdbg(i, COL_MinQuantity) = Number(.Item("MinQuantity"), tdbg.Columns(COL_MinQuantity).NumberFormat)

                '6/11/2017, id 104646-QV - Lỗi tính năng headclick
                'tdbg(i, COL_OQuantity) = Number(.Item("OQuantity"), tdbg.Columns(COL_OQuantity).NumberFormat)
                tdbg(i, COL_OQuantity) = SQLNumber(IIf(Number(tdbg(i, COL_OQuantity), tdbg.Columns(COL_OQuantity).NumberFormat) = 0, .Item("OQuantity"), tdbg(i, COL_OQuantity)).ToString, tdbg.Columns(COL_OQuantity).NumberFormat)

                If Number(tdbg(i, COL_OQuantity)) = 0 Then
                    If Number(tdbg(i, COL_ApprovedQuantity), tdbg.Columns(COL_ApprovedQuantity).NumberFormat) >= Number(tdbg(i, COL_MinQuantity), tdbg.Columns(COL_MinQuantity).NumberFormat) Then
                        tdbg(i, COL_OQuantity) = Number(tdbg(i, COL_ApprovedQuantity), tdbg.Columns(COL_ApprovedQuantity).NumberFormat)
                    Else
                        tdbg(i, COL_OQuantity) = Number(tdbg(i, COL_MinQuantity), tdbg.Columns(COL_MinQuantity).NumberFormat)
                    End If
                End If

                dt = ReturnDataTable(SQLStoreD12P3052(i))
                If _bChangeUnitPriceHeadClick = True Then 'ID-141752
                    If dt.Rows.Count > 0 Then
                        tdbg(i, COL_UnitPrice) = Number(dt.Rows(0)("UnitPrice"), "N" & tdbg(i, COL_PurchasePriceDecimals).ToString)
                    Else
                        tdbg(i, COL_UnitPrice) = Number(0, "N" & tdbg(i, COL_PurchasePriceDecimals).ToString)
                    End If
                End If

                tdbg(i, COL_SupplyUnitID) = .Item("SupplyUnitID").ToString
                tdbg(i, COL_ConversionFactor) = .Item("ConversionFactor").ToString

                CalCQuantity(i)
                CalSupplyOQuantity(i)
                CalSupplyCQuantity(i)
                CalOAmount(i)
                CalVATOAmount(i)
                End If
        End With
    End Sub

    Private Sub LoadDefaultOnObject1Row(ByVal i As Integer)
        Dim dtObjType As DataTable = GetTableObjectTypeID(tdbg(i, COL_PRID).ToString, tdbg(i, COL_PRTransactionID).ToString)
        'ID 57960: lấy dòng đầu tiên trong dropdown gán mặc định lên lưới.
        If dtObjType.Rows.Count <= 0 Then Exit Sub

        If dtObjType.Rows.Count = 1 OrElse _selectedSupplier = 0 Then
            Dim dr As DataRow = dtObjType.Rows(0)
            tdbg(i, COL_ObjectTypeID) = dr("ObjectTypeID").ToString
            tdbg(i, COL_ObjectID) = dr("ObjectID").ToString
            tdbg(i, COL_ObjectName) = dr("ObjectName").ToString
            DefaultSomeCol(dr, i)
        End If
    End Sub

    Private Sub LoadDefaultValue_D12P3051(Optional ByVal i As Integer = -1, Optional ByVal sNewCurrencyID As String = "", Optional ByVal sExchangeRate As String = "")
        Dim sSQL As String = SQLStoreD12P3051(i)
        Dim dtTemp As DataTable = ReturnDataTable(sSQL)
        If dtTemp.Rows.Count > 0 Then
            Dim dr As DataRow = dtTemp.Rows(0)
            DefaultSomeCol(dr, i, sNewCurrencyID, sExchangeRate)
        End If
        tdbg.UpdateData()
    End Sub

    Private Sub ObjectTypeIDChange(ByVal i As Integer, Optional ByVal sNewCurrencyID As String = "")
        tdbg(i, COL_ObjectID) = ""
        tdbg(i, COL_ObjectName) = ""

        Dim dt As DataTable = GetTableObjectTypeID(tdbg(i, COL_PRID).ToString, tdbg(i, COL_PRTransactionID).ToString)
        dt = ReturnTableFilter(dt, "ObjectTypeID = " & SQLString(tdbg(i, COL_ObjectTypeID)))
        If dt.Rows.Count = 1 Then
            Dim dr As DataRow = dt.Rows(0)
            tdbg(i, COL_ObjectTypeID) = dr("ObjectTypeID").ToString
            tdbg(i, COL_ObjectID) = dr("ObjectID").ToString
            tdbg(i, COL_ObjectName) = dr("ObjectName").ToString
            DefaultSomeCol(dr, i, sNewCurrencyID)
            tdbg.UpdateData()
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function AllowSave() As Boolean
        '23/11/2017, Lê Bảo Trâm: id 104908-Lựa chọn NCC bước 1 theo hạng mục
        ResetFilter(tdbg, sFilter, bRefreshFilter)
        ReLoadTDBGrid()
        tdbg.UpdateData()
        If tdbg.FilterActive Then tdbg.FilterActive = False

        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_ObjectTypeID).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Loai_doi_tuong"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT2
                tdbg.Col = COL_ObjectTypeID
                tdbg.Row = i
                Return False
            End If

            If tdbg(i, COL_ObjectID).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Doi_tuong"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT2
                tdbg.Col = COL_ObjectID
                tdbg.Row = i
                Return False
            End If

            If tdbg(i, COL_CurrencyID).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Loai_tien"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT2
                tdbg.Col = COL_CurrencyID
                tdbg.Row = i
                Return False
            End If

            If tdbg(i, COL_ExchangeRate).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("Ty_gia"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT2
                tdbg.Col = COL_ExchangeRate
                tdbg.Row = i
                Return False
            End If

            If tdbg(i, COL_OQuantity).ToString = "" Then
                D99C0008.MsgNotYetEnter(rL3("So_luong_dat_hang"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT2
                tdbg.Col = COL_OQuantity
                tdbg.Row = i
                Return False
            End If

            If Number(tdbg(i, COL_OQuantity)) <= 0 Then
                D99C0008.MsgL3(rL3("So_luong_dat_hang") & " " & " phải > 0")
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT2
                tdbg.Col = COL_OQuantity
                tdbg.Row = i
                Return False
            End If
        Next i

        Dim SumOQuantity As Double = 0
        For h As Integer = 0 To tdbg.RowCount - 1
            SumOQuantity = 0

            For i As Integer = 0 To tdbg.RowCount - 1
                If tdbg(i, COL_PRTransactionID).ToString = tdbg(h, COL_PRTransactionID).ToString Then
                    SumOQuantity += Number(SQLNumber(tdbg(i, COL_OQuantity), DxxFormat.D07_QuantityDecimals))
                End If
            Next i

            If D12Systems.IsAutoPriceByCQTY = False Then
                If SumOQuantity < Number(SQLNumber(tdbg(h, COL_MinQuantity).ToString, DxxFormat.D07_QuantityDecimals)) Then
                    D99C0008.MsgL3(rL3("So_luong_dat_hang_khong_duoc_phep_be_hon_so_luong_dat_hang_toi_thieu"))
                    tdbg.Focus()
                    tdbg.SplitIndex = 2
                    tdbg.Col = COL_OQuantity
                    tdbg.Row = h
                    Return False
                End If
            End If

            If SumOQuantity > Number(SQLNumber(tdbg(h, COL_POQuantity).ToString, DxxFormat.D07_QuantityDecimals)) Then
                D99C0008.MsgL3(rL3("So_luong_dat_hang_khong_duoc_phep_lon_hon_so_luong_duoc_phep_lap_DDH"))
                tdbg.Focus()
                tdbg.SplitIndex = 2
                tdbg.Col = COL_OQuantity
                tdbg.Row = h
                Return False
            End If
        Next h
        Return True
    End Function

    '2/8/2018, id 110407-AICA - Sửa:" Các trường: Loại đối tượng, Đối tượng, Loại tiền;(màn hình D12F3050) bắt buộc nhập nhưng không hiển thị màu nền bắt buộc nhập"
    Private Sub SetBackColorObligatory()
        tdbg.Splits(SPLIT2).DisplayColumns(COL_ObjectTypeID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT2).DisplayColumns(COL_ObjectID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT2).DisplayColumns(COL_CurrencyID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT2).DisplayColumns(COL_ExchangeRate).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT2).DisplayColumns(COL_OQuantity).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
        btnSave.Focus()
        If btnSave.Focused = False Then Exit Sub
        '************************************
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder("")

        sSQL.Append(SQLDeleteD12T2030().ToString & vbCrLf)
        sSQL.Append(SQLInsertD12T2030s())

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()

            _bSaved = True
            btnClose.Enabled = True
            btnSave.Enabled = True
            btnClose.Focus()

            For i As Integer = 0 To tdbg.RowCount - 1
                'RunAuditLog("AutoSelPurReq", "02", tdbg(i, COL_PRVoucherNo).ToString, tdbg(i, COL_ObjectTypeID).ToString, tdbg(i, COL_ObjectID).ToString, tdbg(i, COL_InventoryID).ToString, tdbg(i, COL_POQuantity).ToString)
                Lemon3.D91.RunAuditLog("12", "AutoSelPurReq", "02", tdbg(i, COL_PRVoucherNo).ToString, tdbg(i, COL_ObjectTypeID).ToString, tdbg(i, COL_ObjectID).ToString, tdbg(i, COL_InventoryID).ToString, tdbg(i, COL_POQuantity).ToString) 'ID 84813 29/02/2016
            Next
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD12P2035
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 22/01/2008 04:46:15
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD12P2035() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load luoi" & vbCrLf)
        sSQL &= "Exec D12P2035 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'PRTransactionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(_autoSelectSupplier) & COMMA 'AutoSelectSupplier, tinyint, NOT NULL
        sSQL &= SQLNumber(_selectedSupplier) & COMMA 'SelectedSupplier, tinyint, NOT NULL
        sSQL &= SQLNumber(_baseOnPrice) & COMMA 'BaseOnPrice, tinyint, NOT NULL
        sSQL &= SQLNumber(_baseONPriority) & COMMA 'BaseOnPriority, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(_FormID) 'FormID, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD12P3051
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 02/02/2016 09:49:34
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD12P3051(Optional ByVal i As Integer = -1) As String
        Dim sSQL As String = ""
        sSQL &= ("-- s" & vbCrLf)
        sSQL &= "Exec D12P3051 "
        If i = -1 Then
            sSQL &= SQLString(tdbg.Columns(COL_PRID).Text) & COMMA 'PRID, varchar[20], NOT NULL
            sSQL &= SQLString(tdbg.Columns(COL_PRTransactionID).Text) & COMMA 'PRTransactionID, varchar[20], NOT NULL
            sSQL &= SQLString(tdbg.Columns(COL_ObjectTypeID).Text) & COMMA 'ObjectTypeID, varchar[20], NOT NULL
            sSQL &= SQLString(tdbg.Columns(COL_ObjectID).Text) & COMMA 'ObjectID, varchar[20], NOT NULL
        Else
            sSQL &= SQLString(tdbg(i, COL_PRID)) & COMMA 'PRID, varchar[20], NOT NULL
            sSQL &= SQLString(tdbg(i, COL_PRTransactionID)) & COMMA 'PRTransactionID, varchar[20], NOT NULL
            sSQL &= SQLString(tdbg(i, COL_ObjectTypeID)) & COMMA 'ObjectTypeID, varchar[20], NOT NULL
            sSQL &= SQLString(tdbg(i, COL_ObjectID)) & COMMA 'ObjectID, varchar[20], NOT NULL
        End If
        sSQL &= SQLNumber(_baseOnPrice) & COMMA 'Priority1, tinyint, NOT NULL
        sSQL &= SQLNumber(_baseONPriority) & COMMA 'Priority2, tinyint, NOT NULL
        sSQL &= SQLNumber(_baseDeliveryDay) & COMMA 'Priority3, tinyint, NOT NULL
        sSQL &= SQLString(_value1) & COMMA 'Values1ID, varchar[20], NOT NULL
        sSQL &= SQLString(_value2) & COMMA 'Values2ID, varchar[20], NOT NULL
        sSQL &= SQLString(_value3) & COMMA 'Values3ID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLString(Me.Name) 'FormID, varchar[50], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD12P3052
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 02/02/2016 09:50:54
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD12P3052(Optional ByVal i As Integer = -1) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D12P3052 "
        If i = -1 Then
            sSQL &= SQLString(tdbg.Columns(COL_PRID).Text) & COMMA 'PRID, varchar[20], NOT NULL
            sSQL &= SQLString(tdbg.Columns(COL_PRTransactionID).Text) & COMMA 'PRTransactionID, varchar[20], NOT NULL
            sSQL &= SQLString(tdbg.Columns(COL_ObjectTypeID).Text) & COMMA 'ObjectTypeID, varchar[20], NOT NULL
            sSQL &= SQLString(tdbg.Columns(COL_ObjectID).Text) & COMMA 'ObjectID, varchar[20], NOT NULL
            sSQL &= SQLMoney(tdbg.Columns(COL_OQuantity).Text, tdbg.Columns(COL_OQuantity).NumberFormat) & COMMA 'OQuantity, decimal, NOT NULL
        Else
            sSQL &= SQLString(tdbg(i, COL_PRID)) & COMMA 'PRID, varchar[20], NOT NULL
            sSQL &= SQLString(tdbg(i, COL_PRTransactionID)) & COMMA 'PRTransactionID, varchar[20], NOT NULL
            sSQL &= SQLString(tdbg(i, COL_ObjectTypeID)) & COMMA 'ObjectTypeID, varchar[20], NOT NULL
            sSQL &= SQLString(tdbg(i, COL_ObjectID)) & COMMA 'ObjectID, varchar[20], NOT NULL
            sSQL &= SQLMoney(tdbg(i, COL_OQuantity), tdbg.Columns(COL_OQuantity).NumberFormat) & COMMA 'OQuantity, decimal, NOT NULL
        End If
        sSQL &= SQLNumber(_baseOnPrice) & COMMA 'Priority1, tinyint, NOT NULL
        sSQL &= SQLNumber(_baseONPriority) & COMMA 'Priority2, tinyint, NOT NULL
        sSQL &= SQLNumber(_baseDeliveryDay) & COMMA 'Priority3, tinyint, NOT NULL
        sSQL &= SQLString(_value1) & COMMA 'Values1ID, varchar[20], NOT NULL
        sSQL &= SQLString(_value2) & COMMA 'Values2ID, varchar[20], NOT NULL
        sSQL &= SQLString(_value3) & COMMA 'Values3ID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLString(Me.Name) 'FormID, varchar[50], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD12T2030
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 21/10/2008 02:27:13
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD12T2030(ByVal sUserID As String) As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D12T2030"
        sSQL &= " Where PRID = " & SQLString(tdbg.Columns(COL_PRID).Text)
        sSQL &= " And UserID = " & SQLString(sUserID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD12T2030
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 10/06/2009 
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD12T2030s() As StringBuilder
        Dim sSQL As New StringBuilder

        Dim iCountIGE As Integer = 0
        Dim SupplierTransID As String = ""
        Dim iFirstIGESupplierTransID As Long

        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_SupplierTransID).ToString = "" Then
                iCountIGE = iCountIGE + 1
            End If
        Next

        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_SupplierTransID).ToString = "" Then
                SupplierTransID = CreateIGENewS("D12T2030", "SupplierTransID", "12", "OB", gsStringKey, SupplierTransID, iCountIGE, iFirstIGESupplierTransID)
                tdbg(i, COL_SupplierTransID) = SupplierTransID
            End If

            sSQL.Append("Insert Into D12T2030(")
            sSQL.Append("UserID, SupplierTransID, PRID, PRTransactionID, DivisionID, " & vbCrLf)
            sSQL.Append("TranMonth, TranYear, ObjectTypeID, ObjectID, InventoryID, " & vbCrLf)
            sSQL.Append("UnitID, OQuantity, OAmount, CurrencyID, ExchangeRate, VATGroupID, SupplyUnitID, SupplyOQuantity, SupplyCQuantity, " & vbCrLf)
            sSQL.Append("Spec01ID, Spec02ID, Spec03ID, Spec04ID, Spec05ID, Spec06ID, Spec07ID, Spec08ID, Spec09ID, Spec10ID, " & vbCrLf)
            sSQL.Append("CreateUserID, LastModifyUserID, CreateDate, LastModifyDate, UnitPrice, " & vbCrLf)
            sSQL.Append("ProjectID, ProjectName, TaskID, TaskName" & vbCrLf)
            sSQL.Append(")" & vbCrLf & " Values(")
            sSQL.Append(SQLString("") & COMMA) 'UserID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_SupplierTransID)) & COMMA) 'SupplierTransID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_PRID)) & COMMA) 'PRID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_PRTransactionID)) & COMMA) 'PRTransactionID, varchar[20], NULL
            sSQL.Append(SQLString(gsDivisionID) & COMMA & vbCrLf) 'DivisionID, varchar[20], NULL
            sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, int, NULL
            sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, int, NULL
            sSQL.Append(SQLString(tdbg(i, COL_ObjectTypeID)) & COMMA) 'ObjectTypeID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_ObjectID)) & COMMA) 'ObjectID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_InventoryID)) & COMMA & vbCrLf) 'InventoryID, varchar[20], NULL
            sSQL.Append(SQLString(tdbg(i, COL_UnitID)) & COMMA) 'UnitID, varchar[10], NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_OQuantity), tdbg.Columns(COL_OQuantity).NumberFormat) & COMMA) 'OQuantity, decimal, NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_OAmount), tdbg.Columns(COL_OAmount).NumberFormat) & COMMA) 'OAmount, decimal, NULL
            sSQL.Append(SQLString(tdbg(i, COL_CurrencyID)) & COMMA) 'CurrencyID, varchar[20], NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_ExchangeRate), tdbg.Columns(COL_ExchangeRate).NumberFormat) & COMMA) 'ExchangeRate, money, NULL
            sSQL.Append(SQLString(tdbg(i, COL_VATGroupID)) & COMMA & vbCrLf)
            sSQL.Append(SQLString(tdbg(i, COL_SupplyUnitID)) & COMMA) 'SupplyUnitID, varchar[10], NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SupplyOQuantity), tdbg.Columns(COL_SupplyOQuantity).NumberFormat) & COMMA) 'SupplyOQuantity, decimal, NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_SupplyCQuantity), tdbg.Columns(COL_SupplyCQuantity).NumberFormat) & COMMA) 'SupplyCQuantity, decimal, NULL
            sSQL.Append(SQLString(tdbg(i, COL_Spec01ID)) & COMMA) 'Spec01ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Spec02ID)) & COMMA) 'Spec02ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Spec03ID)) & COMMA) 'Spec03ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Spec04ID)) & COMMA) 'Spec04ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Spec05ID)) & COMMA) 'Spec05ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Spec06ID)) & COMMA) 'Spec06ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Spec07ID)) & COMMA) 'Spec07ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Spec08ID)) & COMMA) 'Spec08ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Spec09ID)) & COMMA) 'Spec09ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Spec10ID)) & COMMA & vbCrLf) 'Spec10ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NULL
            sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
            sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_UnitPrice), tdbg.Columns(COL_UnitPrice).NumberFormat) & COMMA & vbCrLf) 'UnitPrice, decimal, NULL
            '23/11/2017, Lê Bảo Trâm: id 104908-Lựa chọn NCC bước 1 theo hạng mục
            sSQL.Append(SQLString(tdbg(i, COL_ProjectID)) & COMMA) 'ProjectID, varchar[50], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_ProjectName), gbUnicode, True) & COMMA) 'ProjectName, nvarchar[250], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_TaskID)) & COMMA) 'TaskID, varchar[50], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_TaskName), gbUnicode, True) & vbCrLf) 'TaskName, nvarchar[250], NOT NULL

            sSQL.Append(") " & vbCrLf & vbCrLf)
        Next

        Return sSQL
    End Function

    Private Function SQLDeleteD12T2030() As String
        Dim sSQL As String = ""

        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL &= "Delete From D12T2030"
            sSQL &= " Where PRID = " & SQLString(tdbg(i, COL_PRID))
            sSQL &= " And PRTransactionID = " & SQLString(tdbg(i, COL_PRTransactionID))
            sSQL &= " And SupplierTransID = " & SQLString(tdbg(i, COL_SupplierTransID))
            sSQL &= " And UserID = ''" & vbCrLf
        Next i
        Return sSQL
    End Function

#Region "Hien thi F12"

    Private usrOption As New D99U1111()
    Dim dtF12 As DataTable

    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        If usrOption Is Nothing Then Exit Sub 'TH lưới không có cột
        usrOption.Location = New Point(tdbg.Left, btnF12.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Private Sub CallD99U1111()
        Dim arrColObligatory() As Object = {COL_OrderNum, COL_InventoryID}
        usrOption.AddColVisible(tdbg, dtF12, arrColObligatory)
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D99U1111(Me, tdbg, dtF12)
    End Sub

#End Region

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD12P3054
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 25/01/2016 10:24:18
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD12P3054() As String
        Dim sSQL As String = ""
        sSQL &= "Declare @GetDate DATETIME" & vbCrLf
        sSQL &= "Set @GetDate=GETDATE()" & vbCrLf
        sSQL &= "Exec D12P3054 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLNumber(_baseOnPrice) & COMMA 'Priority1, tinyint, NOT NULL
        sSQL &= SQLNumber(_baseONPriority) & COMMA 'Priority2, tinyint, NOT NULL
        sSQL &= SQLNumber(_baseDeliveryDay) & COMMA 'Priority3, tinyint, NOT NULL
        sSQL &= SQLString(_value1) & COMMA 'Values1ID, varchar[20], NOT NULL
        sSQL &= SQLString(_value2) & COMMA 'Values2ID, varchar[20], NOT NULL
        sSQL &= SQLString(_value3) & COMMA 'Values3ID, varchar[20], NOT NULL
        sSQL &= "@GetDate" & COMMA 'Getdate, datetime, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[2], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD12P3055
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 25/01/2016 09:53:48
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD12P3055(ByVal sPRID As String, ByVal sPRTransactionID As String, ByVal sObjectTypeID As String, ByVal iMode As Byte) As String
        Dim sSQL As String = ""
        If iMode = 0 Then
            sSQL &= ("-- Load Loai doi tuong" & vbCrLf)
        Else
            sSQL &= ("-- Load Doi tuong" & vbCrLf)
        End If
        sSQL &= "Exec D12P3055 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(sPRID) & COMMA 'PRID, varchar[50], NOT NULL
        sSQL &= SQLString(sPRTransactionID) & COMMA 'PRTransactionID, varchar[50], NOT NULL
        sSQL &= SQLString(sObjectTypeID) 'ObjectTypeID, varchar[50], NOT NULL
        Return sSQL
    End Function

#Region "ID 99772 25/09/2017"
    Private Sub btnGroupInventoryID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroupInventoryID.Click
        btnGroupInventoryID.Focus()
        If btnGroupInventoryID.Focused = False Then Exit Sub
        '*************************************
        Dim sSQL As New StringBuilder("")
        sSQL.Append(SQLCreateD12F3056.ToString & vbCrLf)
        sSQL.Append(SQLInsertD12F3056.ToString & vbCrLf)
        sSQL.Append(SQLStoreD12P3056.ToString)
        Dim dt As DataTable = ReturnDataTable(sSQL.ToString)
        If dt IsNot Nothing Then
            Dim frm As New D12F3056
            With frm
                '.FormID = Me.Name
                .dtGrid = dt
                .ShowDialog()
                If .bSaved Then
                    Dim sInventoryID, sUnitID, sSpec01ID, sSpec02ID, sSpec03ID, sSpec04ID, sSpec05ID As String
                    Dim sSpec06ID, sSpec07ID, sSpec08ID, sSpec09ID, sSpec10ID As String

                    For i As Integer = 0 To tdbg.RowCount - 1
                        sInventoryID = "(InventoryID IS NULL OR InventoryID =" & SQLString(tdbg(i, COL_InventoryID)) & ")"
                        sUnitID = "(UnitID IS NULL OR UnitID =" & SQLString(tdbg(i, COL_UnitID)) & ")"
                        sSpec01ID = "(Spec01ID IS NULL OR Spec01ID =" & SQLString(tdbg(i, COL_Spec01ID)) & ")"
                        sSpec02ID = "(Spec02ID IS NULL OR Spec02ID =" & SQLString(tdbg(i, COL_Spec02ID)) & ")"
                        sSpec03ID = "(Spec03ID IS NULL OR Spec03ID =" & SQLString(tdbg(i, COL_Spec03ID)) & ")"
                        sSpec04ID = "(Spec04ID IS NULL OR Spec04ID =" & SQLString(tdbg(i, COL_Spec04ID)) & ")"
                        sSpec05ID = "(Spec05ID IS NULL OR Spec05ID =" & SQLString(tdbg(i, COL_Spec05ID)) & ")"
                        sSpec06ID = "(Spec06ID IS NULL OR Spec06ID =" & SQLString(tdbg(i, COL_Spec06ID)) & ")"
                        sSpec07ID = "(Spec07ID IS NULL OR Spec07ID =" & SQLString(tdbg(i, COL_Spec07ID)) & ")"
                        sSpec08ID = "(Spec08ID IS NULL OR Spec08ID =" & SQLString(tdbg(i, COL_Spec08ID)) & ")"
                        sSpec09ID = "(Spec09ID IS NULL OR Spec09ID =" & SQLString(tdbg(i, COL_Spec09ID)) & ")"
                        sSpec10ID = "(Spec10ID IS NULL OR Spec10ID =" & SQLString(tdbg(i, COL_Spec10ID)) & ")"
                        '******************************
                        Dim dr() As DataRow = .dtGrid.Select(sInventoryID & " AND " & sUnitID & " AND " & sSpec01ID & " AND " & sSpec02ID & " AND " & sSpec03ID & " AND " & sSpec04ID & " AND " & sSpec05ID & _
                                                              " AND " & sSpec06ID & " AND " & sSpec07ID & " AND " & sSpec08ID & " AND " & sSpec09ID & " AND " & sSpec10ID)
                        If dr.Length > 0 Then
                            tdbg(i, COL_ObjectTypeID) = dr(0).Item("ObjectTypeID").ToString
                            tdbg(i, COL_ObjectID) = dr(0).Item("ObjectID").ToString
                            tdbg(i, COL_ObjectName) = dr(0).Item("ObjectName").ToString
                            tdbg(i, COL_CurrencyID) = dr(0).Item("CurrencyID").ToString
                            tdbg(i, COL_ExchangeRate) = dr(0).Item("ExchangeRate").ToString
                            tdbg(i, COL_OriginalDecimal) = dr(0).Item("OriginalDecimal").ToString
                            tdbg(i, COL_PurchasePriceDecimals) = dr(0).Item("PurchasePriceDecimals").ToString
                            tdbg(i, COL_UnitPrice) = Number(dr(0).Item("UnitPrice"), "N" & tdbg(i, COL_PurchasePriceDecimals).ToString)
                            CalOAmount(i)
                            CalVATOAmount(i)
                        End If
                    Next

                    tdbg.UpdateData()
                End If
                .Dispose()
            End With
        End If
    End Sub
    Private Function SQLCreateD12F3056() As StringBuilder
        Dim sFieldID As String
        Dim sSQL As New StringBuilder

        sSQL.Append("CREATE TABLE #D12F3056_" & gsUserID & " (" & vbCrLf)
        For i As Integer = 0 To tdbg.Columns.Count - 1
            sFieldID = tdbg.Columns(i).DataField
            If sFieldID = "" Then Continue For 'Cột OrderNum add sau cùng
            '*******************************
            'If i > 0 Then sSQL.Append(", " & vbCrLf)

            Select Case tdbg.Columns(i).DataType.Name
                Case "Boolean"
                    sSQL.Append("[" & sFieldID & "] Bit" & COMMA)
                Case "Decimal"
                    sSQL.Append("[" & sFieldID & "]  Decimal(28, 8)" & COMMA)
                Case "DateTime"
                    sSQL.Append("[" & sFieldID & "]  DateTime" & COMMA)
                Case "Integer", "Int32", "Int16"
                    sSQL.Append("[" & sFieldID & "]  Int" & COMMA)
                Case "Byte"
                    sSQL.Append("[" & sFieldID & "]  TinyInt" & COMMA)
                Case Else
                    sSQL.Append("[" & sFieldID & "]  NVarchar(500)" & COMMA)
            End Select
        Next
        sSQL.Append("OrderNum Int")
        sSQL.Append(")" & vbCrLf)
        Return sSQL
    End Function
    Private Function SQLInsertD12F3056() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        Dim sFieldID As String

        Try
            For i As Integer = 0 To dtGrid.Rows.Count - 1
                sSQL.Append("Insert Into #D12F3056_" & gsUserID & " (")
                For iCol As Integer = 0 To tdbg.Columns.Count - 1
                    sFieldID = tdbg.Columns(iCol).DataField
                    If sFieldID = "" OrElse sFieldID = "OrderNum" Then Continue For 'Cột OrderNum add sau cùng
                    '***********************************
                    sSQL.Append(sFieldID & COMMA)
                Next
                sSQL.Append("OrderNum")
                sSQL.Append(") Values(" & vbCrLf)
                For iCol As Integer = 0 To tdbg.Columns.Count - 1
                    sFieldID = tdbg.Columns(iCol).DataField
                    If sFieldID = "" OrElse sFieldID = "OrderNum" Then Continue For 'Cột OrderNum add sau cùng
                    '***********************************
                    Select Case tdbg.Columns(iCol).DataType.Name
                        Case "Integer", "Int32", "Int64"
                            sSQL.Append(SQLNumber(dtGrid.Rows(i).Item(sFieldID), tdbg.Columns(iCol).NumberFormat) & COMMA)
                        Case "Boolean", "Byte"
                            sSQL.Append(SQLNumber(dtGrid.Rows(i).Item(sFieldID)) & COMMA)
                        Case "DateTime"
                            sSQL.Append(SQLDateSave(dtGrid.Rows(i).Item(sFieldID)) & COMMA)
                        Case "Decimal"
                            sSQL.Append(SQLMoney(dtGrid.Rows(i).Item(sFieldID), tdbg.Columns(iCol).NumberFormat) & COMMA)
                        Case Else
                            sSQL.Append("N" & SQLString(dtGrid.Rows(i).Item(sFieldID)) & COMMA)
                    End Select
                Next
                sSQL.Append(SQLNumber(i + 1))
                sSQL.Append(")")

                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
            Next
        Catch ex As Exception
            D99C0008.MsgL3(ex.Message)
        End Try

        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD12P3056
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 27/09/2017 02:02:35
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD12P3056() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho luoi D31F3056" & vbCrLf)
        sSQL &= "Exec D12P3056 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLString(Me.Name) 'FormID, varchar[50], NOT NULL
        Return sSQL
    End Function
#End Region

#Region "ID-136134"
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
                tdbg.Splits(SPLIT2).DisplayColumns(COL_NRef1 + i).Width = 80
                tdbg.Splits(SPLIT2).DisplayColumns(COL_NRef1 + i).HeadingStyle.Font = FontUnicode(gbUnicode)
                tdbg.Splits(SPLIT2).DisplayColumns(COL_NRef1 + i).Visible = L3Bool(.Item("DefaultUse"))
                tdbg.Columns(COL_NRef1 + i).Caption = IIf(geLanguage = EnumLanguage.Vietnamese, .Item("Caption84" & UnicodeJoin(gbUnicode)).ToString, .Item("Caption01" & UnicodeJoin(gbUnicode)).ToString).ToString
                tdbg.Columns(COL_NRef1 + i).NumberFormat = "#,##0" & InsertZero(CInt(.Item("DecimalNum")))
            End With
        Next i
        '************************
        dtVRef = ReturnTableFilter(dtSub, "FieldName Like 'V%'")
        For i As Integer = 0 To dtVRef.Rows.Count - 1
            With dtVRef.Rows(i)
                tdbg.Splits(SPLIT2).DisplayColumns(COL_VRef1 + i).Width = 140
                tdbg.Splits(SPLIT2).DisplayColumns(COL_VRef1 + i).HeadingStyle.Font = FontUnicode(gbUnicode)
                tdbg.Splits(SPLIT2).DisplayColumns(COL_VRef1 + i).Visible = L3Bool(.Item("DefaultUse"))
                tdbg.Columns(COL_VRef1 + i).Caption = IIf(geLanguage = EnumLanguage.Vietnamese, .Item("Caption84" & UnicodeJoin(gbUnicode)).ToString, .Item("Caption01" & UnicodeJoin(gbUnicode)).ToString).ToString
            End With
        Next i
        '************************
        dtDRef = ReturnTableFilter(dtSub, "FieldName Like 'D%'")
        For i As Integer = 0 To dtDRef.Rows.Count - 1
            With dtDRef.Rows(i)
                tdbg.Splits(SPLIT2).DisplayColumns(COL_DRef1 + i).Width = 80
                tdbg.Splits(SPLIT2).DisplayColumns(COL_DRef1 + i).HeadingStyle.Font = FontUnicode(gbUnicode)
                tdbg.Splits(SPLIT2).DisplayColumns(COL_DRef1 + i).Visible = L3Bool(.Item("DefaultUse"))
                tdbg.Columns(COL_DRef1 + i).Caption = IIf(geLanguage = EnumLanguage.Vietnamese, .Item("Caption84" & UnicodeJoin(gbUnicode)).ToString, .Item("Caption01" & UnicodeJoin(gbUnicode)).ToString).ToString
            End With
        Next i      

    End Sub
#End Region

    'Private Sub LoadDefault_COL_UnitPrice()
    '    tdbg.UpdateData()
    '    For i As Integer = 0 To tdbg.RowCount - 1

    '        tdbg.Row = i
    '        Dim dt As DataTable = ReturnDataTable(SQLStoreD12P3052)
    '        If dt.Rows.Count > 0 Then
    '            tdbg.Columns(COL_UnitPrice).Text = SQLNumber(dt.Rows(0)("UnitPrice").ToString, "N" & tdbg.Columns(COL_PurchasePriceDecimals).Text)
    '        Else
    '            tdbg.Columns(COL_UnitPrice).Text = SQLNumber(0, "N" & tdbg.Columns(COL_PurchasePriceDecimals).Text)
    '        End If

    '        CalCQuantity()
    '        CalSupplyOQuantity()
    '        CalSupplyCQuantity()
    '        CalOAmount()
    '        CalVATOAmount()
    '        '*******************************
    '        'SumOQuantity lấy từ BeforeColUpdate
    '        'Đẩy dữ liệu mới tính xuống dưới 1 dòng
    '        If Number(SumOQuantity, tdbg.Columns(COL_OQuantity).NumberFormat) < Number(tdbg.Columns(COL_ApprovedQuantity).Text, tdbg.Columns(COL_ApprovedQuantity).NumberFormat) Then
    '            bShiftInsert = True
    '            tdbg.AllowAddNew = True 'ID 95381 23/02/2017
    '            InsertRowBelow(tdbg, SPLIT2, COL_OQuantity)
    '            tdbg.Columns(COL_ObjectTypeID).Text = ""
    '            tdbg.Columns(COL_ObjectID).Text = ""
    '            tdbg.Columns(COL_ObjectName).Text = "" '19/10/2018, id 114044-AICA - Lỗi khi tách số lượng đặt hàng trên màn hình Lựa chọn nhà cung cấp D12F3050
    '            tdbg.Columns(COL_SupplierTransID).Text = ""
    '            tdbg.Columns(COL_OQuantity).Text = SQLNumber(Number(tdbg(tdbg.Row - 1, COL_ApprovedQuantity)) - SumOQuantity, tdbg.Columns(COL_OQuantity).NumberFormat)
    '            '***********************
    '            'Tính lại cho dòng mới tách
    '            CalCQuantity()
    '            CalSupplyOQuantity()
    '            CalSupplyCQuantity()
    '            CalOAmount()
    '            CalVATOAmount()
    '            '************************
    '            tdbg.SplitIndex = SPLIT2
    '            tdbg.Row = tdbg.Row
    '            tdbg.Col = COL_OQuantity
    '            tdbg.Focus()
    '            tdbg.AllowAddNew = False 'ID 95381 23/02/2017
    '        End If
    '    Next
    'End Sub

    'ID-144625
    Private Sub D12F3050_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not _bSaved Then
            If Not AskMsgBeforeClose() Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub ResetGrid()
        FooterSumNew(tdbg, COL_OQuantity, COL_CQuantity, COL_UnitPrice, COL_OAmount, COL_VATOAmount)
    End Sub

End Class