Public Class D12F3031
    Private _bSaved As Boolean = False
    Public ReadOnly Property bSaved() As Boolean
        Get
            Return _bSaved
        End Get
    End Property

#Region "Const of tdbg - Total of Columns: 11"
    Private Const COL_PRVoucherNo As String = "PRVoucherNo"         ' Số phiếu
    Private Const COL_ObjectID As String = "ObjectID"               ' Mã NCC
    Private Const COL_ObjectName As String = "ObjectName"           ' Tên NCC
    Private Const COL_InventoryID As String = "InventoryID"         ' Mã hàng
    Private Const COL_InventoryName As String = "InventoryName"     ' Tên hàng
    Private Const COL_UnitID As String = "UnitID"                   ' ĐVT
    Private Const COL_OQuantity As String = "OQuantity"             ' Số lượng
    Private Const COL_MExpectDate As String = "MExpectDate"         ' Ngày nhận hàng
    Private Const COL_Description As String = "Description"         ' Diễn giải
    Private Const COL_PRTransactionID As String = "PRTransactionID" ' PRTransactionID
    Private Const COL_PRID As String = "PRID"                       ' PRID
#End Region

#Region "Const of tdbg1 - Total of Columns: 9"
    Private Const COL1_PRVoucherNo As String = "PRVoucherNo"         ' Số phiếu
    Private Const COL1_InventoryID As String = "InventoryID"         ' Mã hàng
    Private Const COL1_InventoryName As String = "InventoryName"     ' Tên hàng
    Private Const COL1_UnitID As String = "UnitID"                   ' ĐVT
    Private Const COL1_OQuantity As String = "OQuantity"             ' Số lượng
    Private Const COL1_MExpectDate As String = "MExpectDate"         ' Ngày nhận hàng
    Private Const COL1_Description As String = "Description"         ' Diễn giải
    Private Const COL1_PRTransactionID As String = "PRTransactionID" ' PRTransactionID
    Private Const COL1_PRID As String = "PRID"                       ' PRID
#End Region

    Private dtGrid, dtGrid1 As DataTable

    Private Sub D12F3031_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        LoadInfoGeneral() 'Load System/ Option /... in DxxD9940
        ResetFooterGrid(tdbg, 0, tdbg.Splits.Count - 1)
        tdbg_NumberFormat()
        tdbg1_NumberFormat()
        LoadTDBGrid()
        LoadLanguage()
        InputbyUnicode(Me, gbUnicode)
        InputDateInTrueDBGrid(tdbg, COL_MExpectDate)
        InputDateInTrueDBGrid(tdbg1, COL1_MExpectDate)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub D12F3031_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me, True)
            Case Keys.F11
                HotKeyF11(Me, tdbg)
        End Select
    End Sub
    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Bo_sung_phan_luong_chung_tu") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Bå sung ph¡n luäng ch÷ng tô
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        grp1.Text = rl3("Da_co_nha_cung_cap_da_duoc_lua_chon") 'Đã có nhà cung cấp đã được lựa chọn
        grp2.Text = rl3("Chua_co_nha_cung_cap") 'Chưa có nhà cung cấp
        '================================================================ 
        tdbg.Columns(COL_PRVoucherNo).Caption = rl3("So_phieu") 'Số phiếu
        tdbg.Columns(COL_ObjectID).Caption = rl3("Ma_NCC") 'Mã NCC
        tdbg.Columns(COL_ObjectName).Caption = rl3("Ten_NCC") 'Tên NCC
        tdbg.Columns(COL_InventoryID).Caption = rl3("Ma_hang") 'Mã hàng
        tdbg.Columns(COL_InventoryName).Caption = rl3("Ten_hang_") 'Tên hàng
        tdbg.Columns(COL_UnitID).Caption = rl3("DVT") 'ĐVT
        tdbg.Columns(COL_OQuantity).Caption = rl3("So_luong") 'Số lượng
        tdbg.Columns(COL_MExpectDate).Caption = rl3("Ngay_nhan_hang") 'Ngày nhận hàng
        tdbg.Columns(COL_Description).Caption = rL3("Dien_giai") 'Diễn giải
        '================================================================ 
        tdbg1.Columns(COL1_PRVoucherNo).Caption = rl3("So_phieu") 'Số phiếu
        tdbg1.Columns(COL1_InventoryID).Caption = rl3("Ma_hang") 'Mã hàng
        tdbg1.Columns(COL1_InventoryName).Caption = rl3("Ten_hang_") 'Tên hàng
        tdbg1.Columns(COL1_UnitID).Caption = rl3("DVT") 'ĐVT
        tdbg1.Columns(COL1_OQuantity).Caption = rl3("So_luong") 'Số lượng
        tdbg1.Columns(COL1_MExpectDate).Caption = rl3("Ngay_nhan_hang") 'Ngày nhận hàng
        tdbg1.Columns(COL1_Description).Caption = rl3("Dien_giai") 'Diễn giải
        '================================================================ 
        mnsContinue.Text = rl3("Tiep_tuc") 'Tiếp tục
        mnsContinue1.Text = rl3("Tiep_tuc") 'Tiếp tục
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_OQuantity).NumberFormat = DxxFormat.D07_QuantityDecimals
    End Sub
    Private Sub tdbg1_NumberFormat()
        tdbg1.Columns(COL1_OQuantity).NumberFormat = DxxFormat.D07_QuantityDecimals
    End Sub
    Private Sub LoadTDBGrid()
        Dim sSQL As String = SQLStoreD12P3031()
        Dim ds As DataSet = ReturnDataSet(sSQL)
        '***************
        dtGrid = ds.Tables(0) 'ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ResetGrid()
        mnsContinue.Enabled = tdbg.RowCount > 0
        '*******************
        dtGrid1 = ds.Tables(1) ' dtGrid.DefaultView.ToTable
        LoadDataSource(tdbg1, dtGrid1, gbUnicode)
        ResetGrid1()
        mnsContinue1.Enabled = tdbg1.RowCount > 0
    End Sub
    Private Sub ReLoadTDBGrid()
        Dim strFind As String = ""
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString

        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub
    Private Sub ResetGrid()
        FooterTotalGrid(tdbg, COL_PRVoucherNo)
        FooterSumNew(tdbg, COL_OQuantity)
    End Sub
    Private Sub ReLoadTDBGrid1()
        Dim strFind As String = ""
        If sFilter1.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter1.ToString

        dtGrid1.DefaultView.RowFilter = strFind
        ResetGrid1()
    End Sub
    Private Sub ResetGrid1()
        FooterTotalGrid(tdbg1, COL1_PRVoucherNo)
        FooterSumNew(tdbg1, COL1_OQuantity)
    End Sub
    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

#Region "tdbg"
    Dim sFilter As New System.Text.StringBuilder()
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
        Me.Cursor = Cursors.WaitCursor
        HotKeyCtrlVOnGrid(tdbg, e)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        If tdbg.Columns(tdbg.Col).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox Then
            e.Handled = CheckKeyPress(e.KeyChar)
        ElseIf tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far Then
            e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End If
    End Sub
#End Region

#Region "tdbg1"
    Dim sFilter1 As New System.Text.StringBuilder()
    Private Sub tdbg1_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg1.FilterChange
        Try
            If (dtGrid1 Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub
            FilterChangeGrid(tdbg1, sFilter1) 'Nếu có Lọc khi In
            ReLoadTDBGrid1()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Private Sub tdbg1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg1.KeyDown
        Me.Cursor = Cursors.WaitCursor
        HotKeyCtrlVOnGrid(tdbg1, e)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg1.KeyPress
        If tdbg1.Columns(tdbg1.Col).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox Then
            e.Handled = CheckKeyPress(e.KeyChar)
        ElseIf tdbg1.Splits(tdbg1.SplitIndex).DisplayColumns(tdbg1.Col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far Then
            e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End If
    End Sub
#End Region
    Private Sub mnsContinue_Click(sender As Object, e As EventArgs) Handles mnsContinue.Click
        Dim sSQL As New StringBuilder
        sSQL.Append(SQLDeleteD12T9009_Continue("Grid1").ToString & vbCrLf)
        sSQL.Append(SQLInsertD12T9009s_Continue(tdbg, "Grid1").ToString & vbCrLf)
        If ExecuteSQL(sSQL.ToString) Then
            Dim frm As New D12F3050
            frm.FormID = Me.Name
            frm.ShowDialog()
            If frm.bSaved Then mnsContinue.Enabled = False
            frm.Dispose()
        End If
    End Sub
    Private Sub mnsContinue1_Click(sender As Object, e As EventArgs) Handles mnsContinue1.Click
        Dim sSQL As New StringBuilder
        sSQL.Append(SQLDeleteD12T9009_Continue("Grid2").ToString & vbCrLf)
        sSQL.Append(SQLInsertD12T9009s_Continue(tdbg1, "Grid2").ToString & vbCrLf)
        If ExecuteSQL(sSQL.ToString) Then
            Dim frm As New D12F3032
            frm.ShowDialog()
            If frm.bSaved Then mnsContinue1.Enabled = False
            frm.Dispose()
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD12P3031
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 25/07/2017 04:04:28
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD12P3031() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load luoi" & vbCrlf)
        sSQL &= "Exec D12P3031 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'Division, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString("") & COMMA 'VoucherID, varchar[50], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, int, NOT NULL
        sSQL &= SQLNumber(0) 'Mode, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD12T9009
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 25/07/2017 04:31:38
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD12T9009_Continue(sKey01ID As String) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa bang tam" & vbCrLf)
        sSQL &= "Delete From D12T9009"
        sSQL &= " Where "
        sSQL &= "UserID = " & SQLString(gsUserID) & " And "
        sSQL &= "HostID = " & SQLString(My.Computer.Name) & " And "
        sSQL &= "FormID = " & SQLString(Me.Name) & " AND Key01ID=" & SQLString(sKey01ID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD12T9009s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 25/07/2017 04:33:26
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD12T9009s_Continue(c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, sKey01ID As String) As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder

        For i As Integer = 0 To c1Grid.RowCount - 1
            If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Luu bang tam" & vbCrLf)
            sSQL.Append("Insert Into D12T9009(")
            sSQL.Append("UserID, HostID, FormID, Key01ID, Key02ID, " & vbCrLf)
            sSQL.Append("Key03ID")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[50], NOT NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[50], NOT NULL
            sSQL.Append(SQLString(Me.Name) & COMMA) 'FormID, varchar[50], NOT NULL
            sSQL.Append(SQLStringUnicode(sKey01ID, gbUnicode, True) & COMMA) 'Key01ID, nvarchar[1000], NOT NULL
            sSQL.Append(SQLStringUnicode(c1Grid(i, COL_PRTransactionID), gbUnicode, True) & COMMA & vbCrLf) 'Key02ID, nvarchar[1000], NOT NULL
            sSQL.Append(SQLStringUnicode(c1Grid(i, COL_PRID), gbUnicode, True)) 'Key03ID, nvarchar[1000], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function


End Class