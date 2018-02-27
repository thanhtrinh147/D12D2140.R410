Imports System
Imports System.Text


Public Class D12F3101
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


    Private _supplierCount As Integer
    Public WriteOnly Property SupplierCount() As Integer
        Set(ByVal Value As Integer)
            _supplierCount = Value
        End Set
    End Property

    Dim iPerD12F5812 As Integer = 0

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If tdbcTransTypeID.Text = "" Then tdbcTransTypeID.Focus() : Exit Sub
        Me.Close()
    End Sub

    Private Sub LoadTdbc()
        Dim sSQL As String = ""
        LoadTdbcTransTypeID(tdbcTransTypeID, "1")

        'tdbcVoucherTypeID
        LoadVoucherTypeID(tdbcVoucherTypeID, tdbcD06VoucherTypeID, D12, , gbUnicode)

        'tdbcPOStatusID
        sSQL = " Select StatusID, StatusName" & UnicodeJoin(gbUnicode) & " as StatusName " & vbCrLf
        sSQL &= " From D06V0002 " & vbCrLf
        sSQL &= " Where UsedD12 = 1" & vbCrLf
        sSQL &= " AND Language = " & SQLString(gsLanguage)
        sSQL &= "  ORDER BY NO"
        LoadDataSource(tdbcPOStatus, sSQL, gbUnicode)

        'TdbcEmployeeID
        Dim dt As DataTable = ReturnTableCreateBy(gbUnicode)
        LoadCboCreateBy(tdbcEmployeeID, dt, gbUnicode)
        'TdbcReceiptPersonID
        LoadDataSource(tdbcReceiptPersonID, dt.Copy, gbUnicode)

        'Load tdbcShipAddressID
        sSQL = " Select  ObjectID as ShipAddressID, ObjectName" & UnicodeJoin(gbUnicode) & " as ShipAddressName, ObjectAddress" & UnicodeJoin(gbUnicode) & " As ShipAddress" & vbCrLf
        sSQL &= " From Object WITH(NOLOCK) " & vbCrLf
        sSQL &= " Where ObjectTypeID ='DV' And Disabled=0" & vbCrLf
        sSQL &= " Order By ObjectID" & vbCrLf
        LoadDataSource(tdbcShipAddressID, sSQL, gbUnicode)

        'Load tdbcPaymentMethodID
        sSQL = " Select 	PaymentTermID, PaymentTermName" & UnicodeJoin(gbUnicode) & " as PaymentTermName" & vbCrLf
        sSQL &= " 	From	D91T0082 WITH(NOLOCK) " & vbCrLf
        sSQL &= " 	Where	Disabled = 0" & vbCrLf
        sSQL &= " 	Order by	PaymentTermID" & vbCrLf
        LoadDataSource(tdbcPaymentTermID, sSQL, gbUnicode)

        'Load tdbcPaymentTermID
        sSQL = " Select 	PaymentMethodID, PaymentMethodName" & UnicodeJoin(gbUnicode) & " as PaymentMethodName" & vbCrLf
        sSQL &= " 	From	D91T0080 WITH(NOLOCK) " & vbCrLf
        sSQL &= " 	Where	Disabled = 0" & vbCrLf
        sSQL &= " 	Order by	PaymentMethodID" & vbCrLf
        LoadDataSource(tdbcPaymentMethodID, sSQL, gbUnicode)

        'Load tdbcDeliveryID
        sSQL = "Select DeliveryID, Description" & UnicodeJoin(gbUnicode) & " as DeliveryName " & vbCrLf
        sSQL &= "From D91T0081 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled = 0" & vbCrLf
        sSQL &= "Order by DeliveryID" & vbCrLf
        LoadDataSource(tdbcDeliveryID, sSQL, gbUnicode)
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcTransTypeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcVoucherTypeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtVoucherNo.BackColor = COLOR_BACKCOLOROBLIGATORY
        'c1datePaymentDate.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcEmployeeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPOStatus.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub


    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Lap_don_hang_tu_dong_-_D12F3101") & UnicodeCaption(gbUnicode) 'LËp ¢¥n hªng tø ¢èng - D12F3101
        '================================================================ 
        lblVoucherNo.Text = rl3("So_phieu") 'Số phiếu
        lblVoucherTypeID.Text = rl3("Loai_phieu") 'Loại phiếu
        lblteVoucherDate.Text = rl3("Ngay_phieu") 'Ngày phiếu
        lblteExpectDate.Text = rl3("Ngay_nhan_hang") 'Ngày nhận hàng
        lblReceiptPersonID.Text = rl3("Nguoi_nhan") 'Người nhận 
        lblEmployeeID.Text = rl3("Nguoi_lap") 'Người lập
        lblShipAddressID.Text = rl3("Noi_nhan_hang") 'Nơi nhận hàng
        lbltePaymentDate.Text = rl3("Ngay_thanh_toan") 'Ngày thanh toán
        lblPOStatus.Text = rl3("Trang_thai") 'Trạng thái
        lblPaymentMethodID.Text = rl3("PTTT") 'PTTT
        lblPaymentTermID.Text = rl3("DKTM") 'ĐKTM
        lblTransTypeID.Text = rl3("Loai_nghiep_vu") 'Loại nghiệp vụ
        lblDeliveryID.Text = rl3("PT_giao_hang")
        lblD06VourcherTypeID.Text = rl3("Loai_phieu") 'Loại phiếu chuyển
        lblD06VoucherNo.Text = rl3("So_phieu") 'Số phiếu chuyển
        lblVoucherDesc.Text = rl3("Dien_giai") 'Diễn giải
        lblNote.Text = rl3("Ghi_chu")
        lblteValidDateFrom.Text = rl3("Hieu_luc")
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnMakeOrder.Text = rl3("_Lap_don_hang") '&Lập đơn hàng
        '================================================================ 
        tdbcVoucherTypeID.Columns("VoucherTypeID").Caption = rl3("Ma") 'Mã
        tdbcVoucherTypeID.Columns("VoucherTypeName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcReceiptPersonID.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbcReceiptPersonID.Columns("EmployeeName").Caption = rl3("Ten") 'Tên
        tdbcEmployeeID.Columns("EmployeeID").Caption = rl3("Ma") 'Mã
        tdbcEmployeeID.Columns("EmployeeName").Caption = rl3("Ten") 'Tên
        tdbcShipAddressID.Columns("ShipAddressID").Caption = rl3("Ma") 'Mã
        tdbcShipAddressID.Columns("ShipAddressName").Caption = rl3("Ten") 'Diễn giải
        tdbcShipAddressID.Columns("ShipAddress").Caption = rl3("Dia_chi")
        tdbcPOStatus.Columns("StatusID").Caption = rl3("Ma") 'Mã
        tdbcPOStatus.Columns("StatusName").Caption = rl3("Ten") 'Tên
        tdbcPaymentMethodID.Columns("PaymentMethodID").Caption = rl3("Ma") 'Mã
        tdbcPaymentMethodID.Columns("PaymentMethodName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcPaymentTermID.Columns("PaymentTermID").Caption = rl3("Ma") 'Mã
        tdbcPaymentTermID.Columns("PaymentTermName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcTransTypeID.Columns("TransTypeID").Caption = rl3("Ma") 'Mã
        tdbcTransTypeID.Columns("TransTypeName").Caption = rl3("Ten") 'Tên
        tdbcD06VoucherTypeID.Columns("VoucherTypeID").Caption = rl3("Ma") 'Mã
        tdbcD06VoucherTypeID.Columns("VoucherTypeName").Caption = rl3("Dien_giai") 'Diễn giải

        chkPick.Text = rl3("Giu_cho") 'Giữ chỗ
        chkPostedD06.Text = rl3("Chuyen_Module_mua_hang") 'Chuyển module mua hàng
        chkIsLC.Text = rl3("Bat_buoc_mo_LC")

        optTypePostedD06_0.Text = rl3("Don_dat_hang")
        optTypePostedD06_1.Text = rl3("Hop_dong")
    End Sub


    Private Sub D12F3101_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not _bSaved Then
            If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
        End If
    End Sub

    Private Sub D12F3101_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Dim iPerD12F3120 As Integer = -1
    Private Sub D12F3101_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        iPerD12F5812 = ReturnPermission("D12F5812")
        iPerD12F3120 = ReturnPermission("D12F3120")
        If ReturnPermission("D12F3110") < 2 Then tdbcPOStatus.ReadOnly = True
        Loadlanguage()
        LoadTdbc()
        InputbyUnicode(Me, gbUnicode)
        tdbcPOStatus.SelectedIndex = 0
        EnableCheck()
        chkPostedD06_CheckedChanged(Nothing, Nothing)
        SetBackColorObligatory()

        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub EnableCheck()
        chkPostedD06.Enabled = iPerD12F5812 > 1 And ReturnValueC1Combo(tdbcPOStatus).ToString = "0"
        If chkPostedD06.Enabled = False Then chkPostedD06.Checked = False
    End Sub


#Region "Events tdbcVoucherTypeID"

    Private Sub tdbcVoucherTypeID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.Close
        If tdbcVoucherTypeID.FindStringExact(tdbcVoucherTypeID.Text) = -1 Then tdbcVoucherTypeID.Text = ""
    End Sub

    Private Sub tdbcVoucherTypeID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcVoucherTypeID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcVoucherTypeID.Text = ""
    End Sub

    Private Sub tdbcVoucherTypeID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.SelectedValueChanged
        If tdbcVoucherTypeID.Text <> "" Then
            If tdbcVoucherTypeID.Columns("Auto").Text = "0" Then 'Không tạo mã tự động
                txtVoucherNo.ReadOnly = False
                txtVoucherNo.TabStop = True
                txtVoucherNo.Text = ""
            Else
                gnNewLastKey = 0
                txtVoucherNo.ReadOnly = True
                txtVoucherNo.TabStop = False
                txtVoucherNo.Text = CreateIGEVoucherNo(tdbcVoucherTypeID, False)
            End If
        End If
    End Sub

#End Region

#Region "Events tdbcReceiptPersonID"

    Private Sub tdbcReceiptPersonID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcReceiptPersonID.Close
        If tdbcReceiptPersonID.FindStringExact(tdbcReceiptPersonID.Text) = -1 Then tdbcReceiptPersonID.Text = ""
    End Sub

    Private Sub tdbcReceiptPersonID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcReceiptPersonID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcReceiptPersonID.Text = ""
    End Sub

#End Region

#Region "Events tdbcEmployeeID with txtEmployeeName"

    Private Sub tdbcEmployeeID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEmployeeID.Close
        If tdbcEmployeeID.FindStringExact(tdbcEmployeeID.Text) = -1 Then
            tdbcEmployeeID.Text = ""
            txtEmployeeName.Text = ""
        End If
    End Sub

    Private Sub tdbcEmployeeID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcEmployeeID.SelectedValueChanged
        txtEmployeeName.Text = tdbcEmployeeID.Columns(1).Value.ToString
    End Sub

    Private Sub tdbcEmployeeID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcEmployeeID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcEmployeeID.Text = ""
            txtEmployeeName.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcShipAddressID"

    Private Sub tdbcShipAddressID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcShipAddressID.Close
        If tdbcShipAddressID.FindStringExact(tdbcShipAddressID.Text) = -1 Then tdbcShipAddressID.Text = ""
    End Sub

    Private Sub tdbcShipAddressID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcShipAddressID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcShipAddressID.Text = ""
    End Sub

#End Region

#Region "Events tdbcPOStatus"

    Private Sub tdbcPOStatus_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPOStatus.Close
        If tdbcPOStatus.FindStringExact(tdbcPOStatus.Text) = -1 Then tdbcPOStatus.Text = ""
    End Sub

    Private Sub tdbcPOStatus_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcPOStatus.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcPOStatus.Text = ""
    End Sub

    Private Sub tdbcPOStatus_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPOStatus.SelectedValueChanged
        If tdbcPOStatus.Columns("StatusID").Text = "0" Then
            chkPostedD06.Enabled = True
            chkIsLC.Enabled = True
        Else
            chkPostedD06.Enabled = False
            chkPostedD06.Checked = False
            chkIsLC.Enabled = False
            chkIsLC.Checked = False
        End If
        EnableCheck()
        chkPostedD06_CheckedChanged(Nothing, Nothing)
    End Sub
#End Region

    Private Function AllowSave() As Boolean
        If tdbcVoucherTypeID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Loai_phieu"))
            tdbcVoucherTypeID.Focus()
            Return False
        End If
        If txtVoucherNo.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("So_phieu"))
            txtVoucherNo.Focus()
            Return False
        End If

        If tdbcEmployeeID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Nguoi_lap"))
            tdbcEmployeeID.Focus()
            Return False
        End If

        If tdbcPOStatus.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Trang_thai"))
            tdbcPOStatus.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub btnMakeOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMakeOrder.Click
        If tdbcTransTypeID.Text = "" Then tdbcTransTypeID.Focus() : Exit Sub

        If Not AllowSave() Then Exit Sub

        'Kiểm tra Ngày phiếu có phù hợp với kỳ kế toán hiện tại không (gọi hàm CheckVoucherDateInPeriod)
        If CheckVoucherDateInPeriod(c1dateVoucherDate.Value.ToString) = False Then c1dateVoucherDate.Focus() : Exit Sub

        'Kiểm tra có quyền nhập Ngày phiếu lớn hơn Ngày GetDate không?
        If CheckVoucherDateWithGetDate(c1dateVoucherDate.Value.ToString, "D12F5704") = False Then c1dateVoucherDate.Focus() : Exit Sub

        _bSaved = False
        Dim sSQL As String = ""

        sSQL &= SQLDeleteD12T3101() & vbCrLf
        sSQL &= SQLInsertD12T3101().ToString & vbCrLf
        sSQL &= SQLStoreD12P3101()

        If ExecuteSQL(sSQL) = True Then
            _bSaved = True
            D99C0008.MsgL3(rL3("Da_lap_thanh_cong_cho_") & " " & _supplierCount & " " & rL3("_Don_hang"))
            Me.Close()

        Else
            D99C0008.MsgL3(rL3("Lap_don_hang_khong_thanh_cong"))
        End If
    End Sub


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD12T3101
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 18/02/2008 10:04:59
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD12T3101() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D12T3101"
        sSQL &= " Where UserID = " & SQLString(gsUserID)
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD12T3101
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 18/02/2008 10:04:17
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD12T3101() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D12T3101(")
        sSQL.Append("UserID, DivisionID, TranMonth, TranYear, VoucherTypeID, ")
        sSQL.Append("PRVoucherNo, VoucherDate, ExpectDate, PaymentDate, ShipAddressID, ")
        sSQL.Append("ReceiptPersonID, EmployeeID, POStatus, CreateUserID, CreateDate, LastModifyUserID, LastModifyDate, ")
        sSQL.Append("TransTypeID, PaymentMethodID, PaymentTermID, DeliveryID, IsLC, ")
        sSQL.Append("ValidDateFrom, ValidDateTo, Pick, TypePostedD06, D06VoucherTypeID, VoucherDesc, VoucherDescU, Notes, NotesU, D06VoucherNo, PostedD06")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
        sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
        sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NULL
        sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, int, NULL
        sSQL.Append(SQLString(tdbcVoucherTypeID.Text) & COMMA) 'VoucherTypeID, varchar[20], NULL
        sSQL.Append(SQLString(txtVoucherNo.Text) & COMMA) 'PRVoucherNo, varchar[20], NULL
        sSQL.Append(SQLDateSave(c1dateVoucherDate.Text) & COMMA) 'VoucherDate, datetime, NULL
        sSQL.Append(SQLDateSave(c1dateExpectDate.Text) & COMMA) 'ExpectDate, datetime, NULL
        sSQL.Append(SQLDateSave(c1datePaymentDate.Text) & COMMA) 'PaymentDate, datetime, NULL
        sSQL.Append(SQLString(tdbcShipAddressID.Text) & COMMA) 'ShipAddressID, varchar[20], NULL
        sSQL.Append(SQLString(tdbcReceiptPersonID.Text) & COMMA) 'ReceiptPersonID, varchar[20], NULL
        sSQL.Append(SQLString(tdbcEmployeeID.Text) & COMMA) 'EmployeeID, varchar[20], NULL
        sSQL.Append(SQLString(tdbcPOStatus.Columns(0).Text) & COMMA) 'POStatus, varchar[20], NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NULL
        sSQL.Append("GetDate()" & COMMA) 'LastModifyDate, datetime, NULL

        sSQL.Append(SQLString(tdbcTransTypeID.Text) & COMMA)
        sSQL.Append(SQLString(tdbcPaymentMethodID.Text) & COMMA)
        sSQL.Append(SQLString(tdbcPaymentTermID.Text) & COMMA)
        sSQL.Append(SQLString(tdbcDeliveryID.Text) & COMMA)
        sSQL.Append(SQLNumber(chkIsLC.Checked) & COMMA)
        sSQL.Append(SQLDateSave(c1dateValidDateFrom.Text) & COMMA)
        sSQL.Append(SQLDateSave(c1dateValidDateTo.Text) & COMMA)
        sSQL.Append(SQLNumber(chkPick.Checked) & COMMA) 'Pick, tinyint, NOT NULL
        sSQL.Append(SQLNumber(IIf(optTypePostedD06_0.Checked, 0, 1)) & COMMA)
        sSQL.Append(SQLString(tdbcD06VoucherTypeID.Text) & COMMA) 'D06VoucherTypeID, varchar[20], NOT NULL
        sSQL.Append(SQLStringUnicode(txtVoucherDesc.Text, gbUnicode, False) & COMMA)
        sSQL.Append(SQLStringUnicode(txtVoucherDesc.Text, gbUnicode, True) & COMMA)
        sSQL.Append(SQLStringUnicode(txtNote.Text, gbUnicode, False) & COMMA)
        sSQL.Append(SQLStringUnicode(txtNote.Text, gbUnicode, True) & COMMA)
        sSQL.Append(SQLString(txtD06VoucherNo.Text) & COMMA) 'D06VoucherNo, varchar[20], NOT NULL
        sSQL.Append(SQLNumber(chkPostedD06.Checked)) 'PostedD06, tinyint, NOT NULL
        sSQL.Append(")")


        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD12P3101
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 18/02/2008 08:46:38
    '# Modified User: 
    '# Modified Date: 21/08/2008 08:26:11
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD12P3101() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D12P3101 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLNumber(D12Systems.UseWorkflow) 'UseWorkflow, int, NOT NULL
        Return sSQL
    End Function


    'Private Sub btnSetNewKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    GetNewVoucherNo(tdbcVoucherTypeID, txtVoucherNo)
    'End Sub

    

#Region "Events tdbcPaymentMethodID"

    Private Sub tdbcPaymentMethodID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPaymentMethodID.Close
        If tdbcPaymentMethodID.FindStringExact(tdbcPaymentMethodID.Text) = -1 Then tdbcPaymentMethodID.Text = ""
    End Sub

    Private Sub tdbcPaymentMethodID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcPaymentMethodID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcPaymentMethodID.Text = ""
    End Sub

#End Region

#Region "Events tdbcPaymentTermID"

    Private Sub tdbcPaymentTermID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPaymentTermID.Close
        If tdbcPaymentTermID.FindStringExact(tdbcPaymentTermID.Text) = -1 Then tdbcPaymentTermID.Text = ""
    End Sub

    Private Sub tdbcPaymentTermID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcPaymentTermID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcPaymentTermID.Text = ""
    End Sub

#End Region

#Region "Events tdbcTransTypeID"

    Private Sub tdbcTransTypeID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTransTypeID.Close
        If tdbcTransTypeID.FindStringExact(tdbcTransTypeID.Text) = -1 Then tdbcTransTypeID.Text = ""

        tdbcVoucherTypeID.Focus()
    End Sub

    Private Sub tdbcTransTypeID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcTransTypeID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcTransTypeID.Text = ""
    End Sub

    Private Sub tdbcTransTypeID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTransTypeID.LostFocus
        If tdbcTransTypeID.Text = "" Then
            tdbcTransTypeID.Focus()
            Exit Sub
        End If

        tdbcTransTypeID.Enabled = False
        TransTypeID_LostFocus()
    End Sub
#End Region

    Private Sub TransTypeID_LostFocus()

        If tdbcTransTypeID.Text = "" Then
          
        Else
            With tdbcTransTypeID
                tdbcVoucherTypeID.SelectedValue = .Columns("VoucherTypeID").Text
                'tdbcD06VoucherTypeID.SelectedValue = .Columns("D06VoucherTypeID").Text
                tdbcReceiptPersonID.SelectedValue = .Columns("ReceiptPersonID").Text
                GetTextCreateBy(tdbcEmployeeID)
                tdbcShipAddressID.SelectedValue = .Columns("ShipAddressID").Text
                tdbcPaymentMethodID.SelectedValue = .Columns("PaymentMethodID").Text
                tdbcPaymentTermID.SelectedValue = .Columns("PaymentTermID").Text

                c1dateExpectDate.Value = Now.Date
                c1dateVoucherDate.Value = Now.Date
                c1datePaymentDate.Value = Now.Date
                tdbcPOStatus.SelectedValue = 4
                chkPostedD06.Enabled = False

                Select Case Number(.Columns("TypePostedD06").Text)
                    Case 0
                        optTypePostedD06_0.Checked = True
                    Case 1
                        optTypePostedD06_1.Checked = True
                End Select
            End With


        End If

    End Sub

    Private Sub chkPostedD06_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPostedD06.CheckedChanged
        'optTypePostedD06_0.Enabled = chkPostedD06.Checked
        'optTypePostedD06_1.Enabled = chkPostedD06.Checked
        grpPostedD06.Enabled = chkPostedD06.Checked

        If chkPostedD06.Checked Then
            'Lấy theo lo nghiệp vu
            If tdbcTransTypeID.Columns("D06VoucherTypeID").Text <> "" Then
                tdbcD06VoucherTypeID.SelectedValue = tdbcTransTypeID.Columns("D06VoucherTypeID").Text
            Else
                'Mặc định giá trị, lấy từ số phiếu chung xuống
                If tdbcD06VoucherTypeID.Text = "" Then
                    tdbcD06VoucherTypeID.Text = tdbcVoucherTypeID.Text 'luu y phai dung .Text
                    txtD06VoucherNo.Text = txtVoucherNo.Text
                End If
            End If
            Panel1.Enabled = False
        Else
            tdbcD06VoucherTypeID.Text = ""
            txtD06VoucherNo.Text = ""
            Panel1.Enabled = True
        End If
    End Sub

#Region "Events tdbcDeliveryID with txtDeliveryName"

    Private Sub tdbcDeliveryID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDeliveryID.Close
        If tdbcDeliveryID.FindStringExact(tdbcDeliveryID.Text) = -1 Then
            tdbcDeliveryID.Text = ""
        End If
    End Sub

    Private Sub tdbcDeliveryID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcDeliveryID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcDeliveryID.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcD06VoucherTypeID with txtD06VoucherNo"

    Private Sub tdbcD06VoucherTypeID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcD06VoucherTypeID.Close
        If tdbcD06VoucherTypeID.FindStringExact(tdbcD06VoucherTypeID.Text) = -1 Then
            tdbcD06VoucherTypeID.Text = ""
            txtD06VoucherNo.Text = ""
            btnD06SetNewKey.Enabled = False
        End If
    End Sub

    Private Sub tdbcD06VoucherTypeID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcD06VoucherTypeID.SelectedValueChanged

        'If _FormState = EnumFormState.FormAdd Then
        If Not (tdbcD06VoucherTypeID.Tag Is Nothing OrElse tdbcD06VoucherTypeID.Tag.ToString = "") Then
            tdbcD06VoucherTypeID.Tag = ""
            Exit Sub
        End If
        If tdbcD06VoucherTypeID.Text <> "" Then
            If tdbcD06VoucherTypeID.Columns("Auto").Text = "0" Then 'không tạo mã tự động
                txtD06VoucherNo.ReadOnly = False
                txtD06VoucherNo.TabStop = True
                btnD06SetNewKey.Enabled = False
                txtD06VoucherNo.Text = ""
            Else
                gnNewLastKey = 0
                txtD06VoucherNo.ReadOnly = True
                txtD06VoucherNo.TabStop = False
                btnD06SetNewKey.TabStop = False
                btnD06SetNewKey.Enabled = True
                txtD06VoucherNo.Text = CreateIGEVoucherNo(tdbcD06VoucherTypeID, False)
                btnD06SetNewKey.Enabled = True
            End If
        End If
        'End If

    End Sub

    Private Sub tdbcD06VoucherTypeID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcD06VoucherTypeID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcD06VoucherTypeID.Text = ""
            txtD06VoucherNo.Text = ""
            btnD06SetNewKey.Enabled = False
        End If
    End Sub

#End Region

    Private Sub btnD06SetNewKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnD06SetNewKey.Click
        GetNewVoucherNo(tdbcD06VoucherTypeID, txtD06VoucherNo)

    End Sub

    Private Sub D12F3101_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If tdbcTransTypeID.GetItemText(0, "TransTypeID") <> "" And tdbcTransTypeID.GetItemText(1, "TransTypeID") = "" Then
            tdbcTransTypeID.SelectedIndex = 0
            tdbcVoucherTypeID.Focus()
        End If
    End Sub
End Class
