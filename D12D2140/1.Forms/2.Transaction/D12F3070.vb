Imports System
Imports System.Windows.Forms
Public Class D12F3070
    Private _formIDPermission As String = "D12F3070"
    Public WriteOnly Property FormIDPermission() As String
        Set(ByVal Value As String)
            _formIDPermission = Value
        End Set
    End Property

    Private _sQLD12P3070 As String = ""
    Public ReadOnly Property SQLD12P3070() As String
        Get
            Return _sQLD12P3070
        End Get
    End Property

#Region "Const of tdbg - Total of Columns: 7"
    Private Const COL_PRTransactionID As Integer = 0 ' PRTransactionID
    Private Const COL_PRID As Integer = 1            ' PRID
    Private Const COL_PRVoucherNo As Integer = 2     ' Số chứng từ
    Private Const COL_InventoryID As Integer = 3     ' Mã hàng
    Private Const COL_InventoryName As Integer = 4   ' Tên hàng
    Private Const COL_UnitID As Integer = 5          ' ĐVT
    Private Const COL_OTotalQuantity As Integer = 6  ' Số lượng 
#End Region

    'DS cột động theo đối tượng
    Private Const COLD_ObjectTypeID As String = "ObjectTypeID"
    Private Const COLD_ObjectID As String = "ObjectID"
    Private Const COLD_DeliveryTime As String = "DeliveryTime"
    Private Const COLD_OQuantity As String = "OQuantity"
    Private Const COLD_UnitPrice As String = "UnitPrice"
    Private Const COLD_IsSelected As String = "IsSelected"

    Private dtGrid As DataTable
    Dim COL_Total As Integer
    Dim dSetResolutionForm As Double = 0
    Private usrOption As New D99U1111()
    Dim dtF12 As DataTable

    Private Sub D12F3070_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If usrOption IsNot Nothing Then usrOption.Dispose()
    End Sub

    Private Sub D12F3070_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me, True)
            Case Keys.F12
                btnF12_Click(Nothing, Nothing)
            Case Keys.Escape
                usrOption.picClose_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub D12F3070_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        ' gbEnabledUseFind = False
        LoadInfoGeneral() 'Load System/ Option /... in DxxD9940
        SetShortcutPopupMenuNew(Me, Nothing, ContextMenuStrip1)
        COL_Total = tdbg.Columns.Count
        tdbg_NumberFormat()
        AddField()
        If tdbg.Splits.Count = 1 Then
            ResetColorGrid(tdbg)
        Else
            ResetFooterGrid(tdbg, 0, tdbg.Splits.Count - 1)
        End If
        LoadTDBGrid()
        LoadLanguage()
        CallD99U1111()
        dSetResolutionForm = SetResolutionForm(Me, ContextMenuStrip1)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("So_sanh_gia_giua_cac_nha_cung_cap_cua_yeu_cau_mua_hang") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'So sÀnh giÀ giöa cÀc nhª cung cÊp cïa y£u cÇu mua hªng
        '================================================================ 
        btnNext.Text = rl3("_Tiep_tuc") '&Tiếp tục
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        btnF12.Text = rL3("Hien_thi") & " (F12)" 'Hiển thị
        '================================================================ 
        grpList.Text = rl3("Danh_sach_mat_hang_va_nha_cung_cap") 'Danh sách mặt hàng và nhà cung cấp
        '================================================================ 
        tdbg.Columns(COL_PRVoucherNo).Caption = rl3("So_chung_tu") 'Số chứng từ
        tdbg.Columns(COL_InventoryID).Caption = rl3("Ma_hang") 'Mã hàng
        tdbg.Columns(COL_InventoryName).Caption = rl3("Ten_hang_") 'Tên hàng
        tdbg.Columns(COL_UnitID).Caption = rl3("DVT") 'ĐVT
        tdbg.Columns(COL_OTotalQuantity).Caption = rl3("So_luong") 'Số lượng 
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_OTotalQuantity).NumberFormat = DxxFormat.D08_QuantityDecimals
    End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As String = SQLStoreD12P3070("Load luoi", 1)
        dtGrid = ReturnDataTable(sSQL)
        'Cách mới theo chuẩn: Tìm kiếm và Liệt kê tất cả luôn luôn sáng Khi(dt.Rows.Count > 0)
        gbEnabledUseFind = dtGrid.Rows.Count > 0
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ResetGrid()
        CreateExpression() 'ID 90238 22/08/2016
    End Sub

    Private Sub ResetGrid()
        FooterTotalGrid(tdbg, COL_PRVoucherNo)
        FooterSumNew(tdbg, COL_OTotalQuantity) 'không dùng chung vì còn sử dụng
        FooterSumNew(tdbg, sSumFooter.ToArray)
    End Sub

    Private Sub CreateExpression() 'ID 90238 22/08/2016
        Try
            Dim dr() As DataRow = dtCol.Select("Formula not is null And Formula <>''") 'Set Expression cho cot dong
            For i As Integer = 0 To dr.Length - 1
                dtGrid.Columns(dr(i).Item("FieldName").ToString).Expression = dr(i).Item("Formula").ToString
            Next
        Catch ex As Exception

        End Try
    End Sub

    Dim dtObject, dtCol As DataTable
    Dim iCaptionHeight, iColumnCaptionHeight As Integer
    Dim arrCol() As FormatColumn = Nothing
    Private Sub AddField()
        'Xóa cột thêm mới và Split
        Dim i As Integer = tdbg.Columns.Count - 1
        While i > COL_Total
            tdbg.Columns.RemoveAt(i)
        End While
        i = tdbg.Splits.Count - 1
        While i > 1
            tdbg.RemoveHorizontalSplit(i)
        End While

        dtCol = ReturnDataTable(SQLStoreD12P3070("Load cot dong", 0))
        If dtCol.Rows.Count = 0 Then Exit Sub
        dtObject = dtCol.DefaultView.ToTable(True, "ObjectID", "CaptionSplit", "No")

        For split As Integer = 0 To dtObject.Rows.Count - 1
            AddSplit(dtObject.Rows(split))
        Next
        For row As Integer = 0 To dtCol.Rows.Count - 1
            AddColumn(dtCol.Rows(row))
        Next
        '**************************
        ' tdbg.Splits(0).Caption = " "
        tdbg.Splits(0).SplitSize = 15
        If tdbg.Splits.Count > 1 Then
            tdbg.Splits(0).HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.Always
            tdbg.Splits(0).ColumnCaptionHeight = (iColumnCaptionHeight + iCaptionHeight) * L3Int(IIf(dSetResolutionForm <> 0, dSetResolutionForm, 1))
        Else
            tdbg.Splits(0).HScrollBar.Style = C1.Win.C1TrueDBGrid.ScrollBarStyleEnum.Automatic
            If iColumnCaptionHeight <> 0 Then tdbg.Splits(0).ColumnCaptionHeight = iColumnCaptionHeight
        End If
        '**************************
        'Định dạng các cột số trên lưới
        If arrCol IsNot Nothing Then InputNumber(tdbg, arrCol)
    End Sub

    Private Sub AddSplit(ByVal drSplit As DataRow)
        Dim split As Integer = L3Int(drSplit.Item("No"))
        If tdbg.Splits.Count > split Then Exit Sub
        tdbg.InsertHorizontalSplit(tdbg.Splits.Count)
        tdbg.Splits(split).Caption = L3String(drSplit.Item("CaptionSplit"))
        tdbg.Splits(split).CaptionStyle.Font = FontUnicode(True, FontStyle.Bold)
        tdbg.Splits(split).CaptionStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        tdbg.Splits(split).HeadingStyle.Font = FontUnicode(True)
        tdbg.Splits(split).RecordSelectors = False
        '******************************
        tdbg.Splits(split).ColumnCaptionHeight = 28 * L3Int(IIf(dSetResolutionForm <> 0, dSetResolutionForm, 1))
        iColumnCaptionHeight = tdbg.Splits(split).ColumnCaptionHeight
        iCaptionHeight = tdbg.Splits(split).CaptionHeight
        '******************************
        tdbg.Splits(split).SplitSize = 10
        tdbg.Splits(split).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Scalable

        For i As Integer = 0 To tdbg.Columns.Count - 1
            tdbg.Splits(split).DisplayColumns(i).Visible = False
        Next
    End Sub

    Dim sSumFooter As New List(Of String)
    Private Sub AddColumn(ByVal dr As DataRow)
        Dim dc As New C1.Win.C1TrueDBGrid.C1DataColumn(L3String(dr.Item("Caption")), L3String(dr.Item("FieldName")), Type.GetType("System.String"))
        tdbg.Columns.Add(dc)
        'Format cột trên lưới
        Dim split As Integer = L3Int(dr.Item("No"))
        tdbg.Splits(split).DisplayColumns(dc.DataField).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        tdbg.Splits(split).DisplayColumns(dc.DataField).HeadingStyle.Font = FontUnicode(True)
        tdbg.Splits(split).DisplayColumns(dc.DataField).Visible = True
        '*********************
        Select Case L3String(dr.Item("DataType")).ToUpper
            Case "S"
                If dc.DataField.EndsWith("CurrencyID") Then
                    tdbg.Splits(split).DisplayColumns(dc.DataField).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                End If
            Case "N"
                tdbg.Splits(split).DisplayColumns(dc.DataField).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                '*********************
                If dc.DataField.EndsWith("Quantity") Then
                    AddDecimalColumns(arrCol, dc.DataField, DxxFormat.D08_QuantityDecimals, 28, 8)
                    sSumFooter.Add(dc.DataField)
                ElseIf dc.DataField.EndsWith("UnitPrice") Then
                    AddDecimalColumns(arrCol, dc.DataField, DxxFormat.D07_UnitCostDecimals, 28, 8) 'NGOCHUY - 110764 - 8/8/2018
                ElseIf dc.DataField.EndsWith("OAmount") Then
                    AddDecimalColumns(arrCol, dc.DataField, DxxFormat.DecimalPlaces, 28, 8)
                    sSumFooter.Add(dc.DataField)
                ElseIf dc.DataField.EndsWith("CAmount") Then
                    AddDecimalColumns(arrCol, dc.DataField, DxxFormat.D90_ConvertedDecimals, 28, 8)
                    sSumFooter.Add(dc.DataField)
                Else
                    AddDecimalColumns(arrCol, dc.DataField, DxxFormat.DefaultNumber2, 28, 8)
                End If
            Case "D"
                tdbg.Splits(split).DisplayColumns(dc.DataField).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                InputDateInTrueDBGrid(tdbg, dc.DataField)
        End Select
        '*********************
        Select Case L3String(dr.Item("Status")).ToUpper
            Case "H"
                tdbg.Splits(split).DisplayColumns(dc.DataField).Visible = False
            Case "R"
                LockColums(tdbg, split, dc.DataField)
            Case "O"
                tdbg.Splits(split).DisplayColumns(dc.DataField).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
                arrColObligatory.Add(dc.DataField)
            Case "CHECKBOX"
                tdbg.Columns(dc.DataField).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
                tdbg.Splits(split).DisplayColumns(dc.DataField).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                tdbg.Splits(split).DisplayColumns(dc.DataField).Width = 50
        End Select
        '*********************
        tdbg.Splits(split).DisplayColumns(dc.DataField).Width = 50 + (30 * (L3Int(dr.Item("Width")) - 1))
        tdbg.Splits(split).DisplayColumns(dc.DataField).Style.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
    End Sub

#Region "tdbg"
    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        If e.Column.DataColumn.DataField.EndsWith(COLD_IsSelected) Then
            If L3Bool(tdbg.Columns(e.ColIndex).Text) = False Then
                Dim OQuantity As String = e.Column.DataColumn.DataField.Substring(0, e.Column.DataColumn.DataField.LastIndexOf("_") + 1) & COLD_OQuantity
                tdbg.Columns(OQuantity).Text = "0"
            End If
        Else
            Dim sIsSelected As String = e.Column.DataColumn.DataField.Substring(0, e.Column.DataColumn.DataField.LastIndexOf("_") + 1) & COLD_IsSelected
            Try
                tdbg.Columns(sIsSelected).Text = "1"
            Catch ex As Exception

            End Try

        End If
        tdbg.UpdateData()
        ResetGrid()
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.S Then HeadClick(tdbg.Col)

        HotKeyDownGrid(e, tdbg, COL_PRVoucherNo, 0, tdbg.Splits.Count - 1)
    End Sub
#End Region

    Dim bSelect As Boolean = False
    Private Sub HeadClick(ByVal iCol As Integer)
        If tdbg.Splits(tdbg.SplitIndex).DisplayColumns(iCol).Locked Then Exit Sub
        tdbg.UpdateData()
        '***********************
        If tdbg.Columns(iCol).DataField.EndsWith(COLD_IsSelected) Then
            L3HeadClick(tdbg, iCol, bSelect)
            If bSelect = False Then
                Dim OQuantity As String = tdbg.Columns(iCol).DataField.Substring(0, tdbg.Columns(iCol).DataField.LastIndexOf("_") + 1) & COLD_OQuantity
                For i As Integer = 0 To tdbg.RowCount - 1
                    tdbg(i, OQuantity) = "0"
                Next
            End If
        Else
            CopyColumns(tdbg, iCol, tdbg.Columns(iCol).Text, tdbg.Row)
            Dim sIsSelected As String = tdbg.Columns(iCol).DataField.Substring(0, tdbg.Columns(iCol).DataField.LastIndexOf("_") + 1) & COLD_IsSelected
            Try
                For i As Integer = tdbg.Row + 1 To tdbg.RowCount - 1
                    tdbg(i, sIsSelected) = "1"
                Next
            Catch ex As Exception

            End Try
        End If
        '***********************
        tdbg.UpdateData()
    End Sub

    Private Function AllowSave(ByVal Key01ID As String, ByRef sRet() As StringBuilder) As Boolean
        tdbg.UpdateData()
        If dtObject Is Nothing OrElse dtObject.Rows.Count <= 0 Then Return False
        '*****************************
        Dim iCountSQL As Integer = 0 'Đếm số câu SQL để thực thi
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            'SUM (X_OQuantity) <= Số lượng (OTotalQuantity)Nếu không thỏa xuất thông báo “Số lượng thực hiện phải nhỏ hơn số lượng yêu cầu”
            Dim Total As Double = CalSumOQuantitySelect(i)
            If Total > 0 AndAlso Number(tdbg(i, COL_OTotalQuantity)) < Total Then
                D99C0008.MsgL3(rL3("So_luong_thuc_hien_phai_nho_hon_hoac_bang_so_luong_yeu_cau"))
                tdbg.Focus()
                If sSumFooter.Count > 0 Then tdbg.SplitIndex = 1 : tdbg.Col = IndexOfColumn(tdbg, sSumFooter(0))
                tdbg.Row = i
                Return False
            End If
            For obj As Integer = 0 To dtObject.Rows.Count - 1 'Số đối tượng
                Dim sRefix As String = L3String(dtObject.Rows(obj).Item("ObjectID")) & "_"
                If L3Bool(tdbg(i, sRefix & COLD_IsSelected)) = False Then Continue For 'Đối tượng không chọn
                'Kiểm tra bắt buộc nhập
                If tdbg.Splits(obj + 1).DisplayColumns(sRefix & COLD_OQuantity).Style.BackColor = COLOR_BACKCOLOROBLIGATORY Then
                    If Number(tdbg(i, sRefix & COLD_OQuantity)) = 0 Then
                        D99C0008.MsgNotYetEnter(tdbg.Columns(sRefix & COLD_OQuantity).Caption)
                        tdbg.Focus()
                        tdbg.SplitIndex = 0
                        tdbg.Col = IndexOfColumn(tdbg, sRefix & COLD_OQuantity)
                        tdbg.Row = i
                        Return False
                    End If
                End If
                '*************************
                sSQL.Append(SQLInsertD12T9009(Key01ID, i, sRefix & COLD_ObjectTypeID, sRefix & COLD_ObjectID, sRefix & COLD_DeliveryTime, sRefix & COLD_OQuantity, sRefix & COLD_UnitPrice, sRefix & COLD_IsSelected).ToString & vbCrLf)
            Next

            iCountSQL += 1
            sRet = ReturnSQL(sRet, sSQL, iCountSQL, 30) 'Mặc định là 30 dòng Insert
        Next
        sRet = AddValueInArrStringBuilder(sRet, sSQL, True) 'Mặc định là thêm vào cuối mảng SQL
        If sRet Is Nothing Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function CalSumOQuantitySelect(ByVal row As Integer) As Double
        Dim sTotal As Double = 0
        For i As Integer = 0 To dtObject.Rows.Count - 1 'sSumFooter.Count - 1
            Try
                Dim sRefix As String = dtObject.Rows(i).Item("ObjectID").ToString & "_" 'sSumFooter(i).Substring(0, sSumFooter(i).LastIndexOf("_") + 1)
                If L3Bool(tdbg(row, sRefix & COLD_IsSelected)) = False Then Continue For
                sTotal += Number(tdbg(row, sRefix & COLD_OQuantity), tdbg.Columns(sRefix & COLD_OQuantity).NumberFormat)
            Catch ex As Exception

            End Try
        Next
        Return sTotal
    End Function

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        btnNext.Focus()
        If btnNext.Focused = False Then Exit Sub
        '************************
        Dim sSQL() As StringBuilder = Nothing
        Dim Key01ID As String = "SelectSupplier"
        If Not AllowSave(Key01ID, sSQL) Then Exit Sub
        If sSQL Is Nothing Then Exit Sub
        sSQL = AddValueInArrStringBuilder(sSQL, SQLDeleteD12T9009(Key01ID) & vbCrLf, False)
        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            _sQLD12P3070 = SQLStoreD12P3070("Do nguon Lua chon NCC", 2)
            Me.Close()
            Dim f As New D12F3050
            With f
                .SQLLoadData = _sQLD12P3070
                .ShowDialog()
                .Dispose()
            End With
            ExecuteSQLNoTransaction(SQLDeleteD91T9009)
        Else
            SaveNotOK()
        End If
    End Sub

    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        If usrOption Is Nothing Then Exit Sub 'TH lưới không có cột
        usrOption.Location = New Point(tdbg.Left, btnF12.Top - (usrOption.Height + 7))
        Me.Controls.Add(usrOption)
        usrOption.BringToFront()
        usrOption.Visible = True
    End Sub

    Dim arrColObligatory As New List(Of String)
    Private Sub CallD99U1111()
        ' Dim arrColObligatory() As Object = {}
        usrOption.AddColVisible(tdbg, dtF12, arrColObligatory.ToArray)
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D99U1111(Me, tdbg, dtF12)
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD12P3070
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 20/06/2016 10:09:40
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD12P3070(ByVal sComment As String, ByVal Mode As Integer) As String
        Dim sSQL As String = ""
        sSQL &= ("-- " & sComment & vbCrLf)
        sSQL &= "Exec D12P3070 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        If Mode = 1 Then
            sSQL &= SQLString("D12F3030") & COMMA 'FormID, varchar[50], NOT NULL
        Else
            sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        End If
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[50], NOT NULL
        sSQL &= SQLNumber(Mode) 'Mode, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD12T9009
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 20/06/2016 01:24:14
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD12T9009(ByVal Key01ID As String) As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D12T9009"
        sSQL &= " Where "
        sSQL &= "UserID = " & SQLString(gsUserID) & " And "
        sSQL &= "HostID = " & SQLString(My.Computer.Name) & " And "
        sSQL &= "FormID = " & SQLString(Me.Name) & " And "
        sSQL &= "Key01ID= " & SQLString(Key01ID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD12T9009
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 20/06/2016 01:25:55
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD12T9009(ByVal Key01ID As String, ByVal row As Integer, ByVal COL_ObjectTypeID As String, ByVal COL_ObjectID As String, _
                ByVal COL_DeliveryTime As String, ByVal COL_OQuantity As String, ByVal COL_UnitPrice As String, ByVal COL_IsSelected As String _
        ) As StringBuilder

        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D12T9009(")
        sSQL.Append("UserID, HostID, FormID, Key01ID, Key02ID, " & vbCrLf)
        sSQL.Append("Key03ID, Key04ID, Key05ID, Key06ID, Key07ID, " & vbCrLf)
        sSQL.Append("Key08ID, Key09ID, Key10ID, Num01, Num02, " & vbCrLf)
        sSQL.Append("Num03, Num09")
        sSQL.Append(") Values(" & vbCrLf)
        sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[50], NOT NULL
        sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[50], NOT NULL
        sSQL.Append(SQLString(Me.Name) & COMMA) 'FormID, varchar[50], NOT NULL
        sSQL.Append(SQLString(Key01ID) & COMMA) 'Key01ID, nvarchar[1000], NOT NULL
        sSQL.Append("N" & SQLString(tdbg(row, COL_PRID)) & COMMA & vbCrLf) 'Key02ID, nvarchar[1000], NOT NULL
        sSQL.Append("N" & SQLString(tdbg(row, COL_PRTransactionID)) & COMMA) 'Key03ID, nvarchar[1000], NOT NULL
        sSQL.Append("N" & SQLString(tdbg(row, COL_InventoryID)) & COMMA) 'Key04ID, nvarchar[1000], NOT NULL
        sSQL.Append("N" & SQLString(tdbg(row, COL_InventoryName)) & COMMA) 'Key05ID, nvarchar[1000], NOT NULL
        sSQL.Append("N" & SQLString(tdbg(row, COL_UnitID)) & COMMA) 'Key06ID, nvarchar[1000], NOT NULL
        sSQL.Append("N" & SQLString(tdbg(row, COL_ObjectTypeID)) & COMMA & vbCrLf) 'Key07ID, nvarchar[1000], NOT NULL
        sSQL.Append("N" & SQLString(tdbg(row, COL_ObjectID)) & COMMA) 'Key08ID, nvarchar[1000], NOT NULL
        sSQL.Append("N" & SQLString(tdbg(row, COL_PRVoucherNo)) & COMMA) 'Key09ID, nvarchar[1000], NOT NULL
        sSQL.Append("N" & SQLString(tdbg(row, COL_DeliveryTime)) & COMMA) 'Key10ID, nvarchar[1000], NOT NULL
        sSQL.Append(SQLMoney(tdbg(row, COL_OTotalQuantity), tdbg.Columns(COL_OTotalQuantity).NumberFormat) & COMMA) 'Num01, decimal, NOT NULL
        sSQL.Append(SQLMoney(tdbg(row, COL_OQuantity), tdbg.Columns(COL_OQuantity).NumberFormat) & COMMA & vbCrLf) 'Num02, decimal, NOT NULL
        sSQL.Append(SQLMoney(tdbg(row, COL_UnitPrice), tdbg.Columns(COL_UnitPrice).NumberFormat) & COMMA) 'Num03, decimal, NOT NULL
        sSQL.Append(SQLNumber(tdbg(row, COL_IsSelected)) & vbCrLf) 'Num09, decimal, NOT NULL
        sSQL.Append(")")

        Return sSQL
    End Function

    Private dtCaptionCols As DataTable
    Private Sub mnsExportToExcel_Click(sender As Object, e As EventArgs) Handles mnsExportToExcel.Click
        '18/7/2018, 	LEANHVU: id 107302-BỔ SUNG TÍNH NĂNG XUẤT EXCEL TẠI MÀN HÌNH SO SÁNH NHÀ CUNG CẤP
        Dim arrColObligatory() As Integer = {}
        Dim Arr As New ArrayList
        For i As Integer = 0 To tdbg.Splits.Count - 1
            AddColVisible(tdbg, i, Arr, arrColObligatory, , , gbUnicode)
        Next

        'Tạo tableCaption: đưa tất cả các cột trên lưới có Visible = True vào table 
        dtCaptionCols = CreateTableForExcelOnly(tdbg, Arr)

        Dim frm As New D99F2222
        frm.UseUnicode = gbUnicode
        frm.dtLoadGrid = dtCaptionCols
        frm.dtExportTable = dtGrid
        frm.GroupColumns = gsGroupColumns
        frm.FormID = Me.Name
        frm.tdbgFr = tdbg
        frm.ShowDialog()
    End Sub


End Class