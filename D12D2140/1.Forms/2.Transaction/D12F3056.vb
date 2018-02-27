Imports System
Imports System.Text
Imports System.Windows.Forms
Public Class D12F3056
    Dim clsFilterDropdown As Lemon3.Controls.FilterDropdown

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

    Private _dtGrid As DataTable = Nothing
    Public Property dtGrid() As DataTable
        Get
            Return _dtGrid
        End Get
        Set(ByVal Value As DataTable)
            _dtGrid = Value
        End Set
    End Property

#Region "Const of tdbg - Total of Columns: 22"
    Private Const COL_InventoryID As String = "InventoryID"                     ' Mã hàng
    Private Const COL_InventoryName As String = "InventoryName"                 ' Tên hàng
    Private Const COL_UnitID As String = "UnitID"                               ' ĐVT
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
    Private Const COL_ExchangeRateDecimals As String = "ExchangeRateDecimals"   ' ExchangeRateDecimals
    Private Const COL_ObjectTypeID As String = "ObjectTypeID"                   ' Loại đối tượng
    Private Const COL_ObjectID As String = "ObjectID"                           ' Đối tượng
    Private Const COL_ObjectName As String = "ObjectName"                       ' Tên đối tượng
    Private Const COL_CurrencyID As String = "CurrencyID"                       ' Loại tiền
    Private Const COL_ExchangeRate As String = "ExchangeRate"                   ' Tỷ giá
    Private Const COL_UnitPrice As String = "UnitPrice"                         ' Đơn giá
    Private Const COL_OriginalDecimal As String = "OriginalDecimal"             ' OriginalDecimal
    Private Const COL_PurchasePriceDecimals As String = "PurchasePriceDecimals" ' PurchasePriceDecimals
#End Region

    Dim dtObjectID As DataTable
    Dim bUseSpec As Boolean

    Private Sub D12F3050_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Dim sSQL As String = ""
        sSQL = "IF EXISTS (SELECT TOP 1 1 FROM 	DBO.SYSOBJECTS WITH(NOLOCK) "
        sSQL &= "WHERE ID = OBJECT_ID(N'[DBO].[#D12F30566_" & gsUserID & "') AND OBJECTPROPERTY(ID, N'IsTable') = 1)" & vbCrLf
        sSQL &= "DROP TABLE #D12F3056_" & gsUserID
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
        clsFilterDropdown.UseFilterDropdown(tdbg, COL_ObjectID)
        '*************************
        bUseSpec = LoadTDBGridSpecificationCaption(tdbg, IndexOfColumn(tdbg, COL_Spec01ID), 0, True, gbUnicode)
        LoadLanguage()
        ResetFooterGrid(tdbg)
        tdbg_LockedColumns()
        tdbg_NumberFormat()
        LoadTDBDropDown()
        '***********************
        LoadTDBGrid()
        CallD99U1111()
        InputbyUnicode(Me, gbUnicode)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rL3("Nhom_ma_hang") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Nhâm mº hªng
        '================================================================ 
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        btnSelect.Text = rL3("_Chon") '&Chọn
        btnF12.Text = "F12 ( " & rL3("Hien_thi") & " )" 'Hiển thị (F12)
        '================================================================ 
        tdbdCurrencyID.Columns("CurrencyID").Caption = rL3("Ma") 'Mã
        tdbdCurrencyID.Columns("CurrencyName").Caption = rL3("Ten") 'Tên
        tdbdCurrencyID.Columns("ExchangeRate").Caption = rL3("Ty_gia") 'Tỷ giá
        tdbdObjectID.Columns("ObjectTypeID").Caption = rL3("Loai_DT") 'Loại ĐT
        tdbdObjectID.Columns("ObjectID").Caption = rL3("Ma") 'Mã
        tdbdObjectID.Columns("ObjectName").Caption = rL3("Ten") 'Tên
        tdbdObjectID.Columns("UnitPrice").Caption = rL3("Don_gia") 'Đơn giá
        tdbdObjectTypeID.Columns("ObjectTypeID").Caption = rL3("Ma") 'Mã
        tdbdObjectTypeID.Columns("ObjectTypeName").Caption = rL3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns(COL_InventoryID).Caption = rL3("Ma_hang") 'Mã hàng
        tdbg.Columns(COL_InventoryName).Caption = rL3("Ten_hang_") 'Tên hàng
        tdbg.Columns(COL_UnitID).Caption = rL3("DVT") 'ĐVT
        tdbg.Columns(COL_ObjectTypeID).Caption = rL3("Loai_doi_tuong") 'Loại đối tượng
        tdbg.Columns(COL_ObjectID).Caption = rL3("Doi_tuong") 'Đối tượng
        tdbg.Columns(COL_ObjectName).Caption = rL3("Ten_doi_tuong") 'Tên đối tượng
        tdbg.Columns(COL_CurrencyID).Caption = rL3("Loai_tien") 'Loại tiền
        tdbg.Columns(COL_ExchangeRate).Caption = rL3("Ty_gia") 'Tỷ giá
        tdbg.Columns(COL_UnitPrice).Caption = rL3("Don_gia") 'Đơn giá
    End Sub
    Private Sub LoadTdbdObjectID(ByVal sObjectTypeID As String)
        If dtObjectID Is Nothing Then
            Dim sSQL As String = ""
            sSQL = "-- Load Doi tuong" & vbCrLf
            sSQL &= "Select ObjectID, ObjectName" & UnicodeJoin(gbUnicode) & " as ObjectName, ObjectTypeID" & vbCrLf
            sSQL &= "From Object WITH(NOLOCK) Where Disabled=0  " & vbCrLf
            sSQL &= "Order by ObjectTypeID, ObjectID" & vbCrLf
            dtObjectID = ReturnDataTable(sSQL)
        End If
        '***************************
        Dim dt As DataTable
        If clsFilterDropdown.IsNewFilter Then
            tdbdObjectID.DisplayColumns("ObjectTypeID").Visible = (sObjectTypeID = "" Or sObjectTypeID = "-1")
            If sObjectTypeID = "" Then
                dt = ReturnTableFilter(dtObjectID, "ObjectID <> '+' ", True)
            Else
                dt = ReturnTableFilter(dtObjectID, "ObjectTypeID=" & SQLString(sObjectTypeID), True)
            End If
        Else
            tdbdObjectID.DisplayColumns("ObjectTypeID").Visible = False
            dt = ReturnTableFilter(dtObjectID, "ObjectTypeID = " & SQLString(sObjectTypeID), True)
        End If
        LoadDataSource(tdbdObjectID, dt, gbUnicode)
    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""

        'Load tdbdCurrencyID
        'LoadCurrencyID(tdbdCurrencyID, gbUnicode)
        sSQL = "--Do nguon dropdown Loai tien" & vbCrLf
        sSQL &= "SELECT CurrencyID, CurrencyName" & UnicodeJoin(gbUnicode) & " As CurrencyName, ExchangeRate, "
        sSQL &= "Operator, OriginalDecimal, ExchangeRateDecimal, UnitPriceDecimals, PurchasePriceDecimals" & vbCrLf
        sSQL &= "FROM D91V0010 WHERE Disabled =0 ORDER BY CurrencyID "
        LoadDataSource(tdbdCurrencyID, sSQL, gbUnicode)

        'Load tdbdObjectTypeID
        LoadObjectTypeID(tdbdObjectTypeID, gbUnicode)
    End Sub
    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_InventoryID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_InventoryName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_UnitID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
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
        tdbg.Splits(SPLIT1).DisplayColumns(COL_ObjectName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub
    Private Sub tdbg_NumberFormat()
        Dim arr() As FormatColumn = Nothing
        AddDecimalColumns(arr, tdbg.Columns(COL_ExchangeRate).DataField, DxxFormat.ExchangeRateDecimals, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_UnitPrice).DataField, DxxFormat.UnitPriceDecimalPlaces, 28, 8)
        InputNumber(tdbg, arr)
    End Sub
    Private Sub LoadTDBGrid()
        'Dim sSQL As String = SQLStoreD12P3056()
        '_dtGrid = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, _dtGrid, gbUnicode)
        ResetGrid()
    End Sub
    Private Sub ResetGrid()
        FooterTotalGrid(tdbg, COL_InventoryID)
    End Sub

#Region "tdbg"
    Private Sub tdbg_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case tdbg.Columns(e.ColIndex).DataField
            Case COL_ObjectTypeID, COL_CurrencyID
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                End If
            Case COL_ObjectID
                If clsFilterDropdown.IsNewFilter Then Exit Sub
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                End If
        End Select
    End Sub
    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        tdbg.UpdateData()
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        Select Case tdbg.Columns(e.ColIndex).DataField
            Case COL_ObjectTypeID, COL_CurrencyID
                Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = tdbg.Columns(e.ColIndex).DropDown ' clsFilterDropdown.GetDropdown(tdbg, e.Column.DataColumn.DataField)
                If tdbd Is Nothing Then Exit Select
                'Dim row As DataRow = ReturnDataRow(tdbd, tdbd.DisplayMember & "=" & SQLString(tdbg.Columns(e.ColIndex).Text))
                Dim row As DataRow = Nothing
                If tdbg.Columns(e.ColIndex).Text <> "" Then row = CType(tdbd.DataSource, DataTable).Rows(tdbd.Row) 'Sửa lỗi bị khi chọn Mã trùng 82152
                AfterColUpdate(e.ColIndex, row)
            Case COL_ObjectID
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
        End Select
        '******************
        tdbg.UpdateData()
    End Sub

    Private Sub tdbg_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ButtonClick
        If clsFilterDropdown.IsNewFilter = False Then Exit Sub
        If tdbg.AllowUpdate = False Then Exit Sub
        If tdbg.Splits(tdbg.SplitIndex).DisplayColumns(tdbg.Col).Locked Then Exit Sub
        Select Case tdbg.Columns(tdbg.Col).DataField
            Case COL_ObjectID
                Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = clsFilterDropdown.GetDropdown(tdbg, tdbg.Columns(tdbg.Col).DataField)
                If tdbd Is Nothing Then Exit Select
                Dim dr() As DataRow = clsFilterDropdown.FilterDropdown(tdbg, e, tdbd)
                If dr Is Nothing Then Exit Sub
                AfterColUpdate(tdbg.Col, dr)
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If clsFilterDropdown.CheckKeydownFilterDropdown(tdbg, e) Then
            Select Case tdbg.Columns(tdbg.Col).DataField
                Case COL_ObjectID
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
            Case Keys.F7
                Select Case tdbg.Columns(tdbg.Col).DataField
                    Case COL_ObjectTypeID, COL_ObjectID, COL_CurrencyID
                        HotKeyF7(tdbg)
                        Dim tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = tdbg.Columns(tdbg.Col).DropDown
                        If tdbd Is Nothing Then Exit Select
                        Dim row As DataRow = ReturnDataRow(tdbd, tdbd.DisplayMember & "=" & SQLString(tdbg.Columns(tdbg.Col).Text))
                        AfterColUpdate(tdbg.Col, row)
                End Select
            Case Keys.S
                If e.Control Then HeadClickTask(tdbg.Col)
            Case Keys.Enter
                If tdbg.Col = IndexOfColumn(tdbg, COL_UnitPrice) Then HotKeyEnterGrid(tdbg, IndexOfColumn(tdbg, COL_ObjectTypeID), e, 1)
        End Select
        HotKeyDownGrid(e, tdbg, IndexOfColumn(tdbg, COL_ObjectTypeID), 0, 1, True, True, True)
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        If e IsNot Nothing AndAlso e.LastRow = -1 Then Exit Sub
        Select Case tdbg.Columns(tdbg.Col).DataField
            Case COL_ObjectID
                LoadTdbdObjectID(tdbg(tdbg.Row, COL_ObjectTypeID).ToString)
        End Select
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClickTask(e.ColIndex)
    End Sub

    Private Sub HeadClickTask(ByVal iCol As Integer)
        Select Case tdbg.Columns(iCol).DataField
            Case COL_ObjectTypeID, COL_ObjectID
                Dim arr() As Integer = {IndexOfColumn(tdbg, COL_ObjectTypeID), IndexOfColumn(tdbg, COL_ObjectID), IndexOfColumn(tdbg, COL_ObjectName)}
                CopyColumnArr(tdbg, iCol, arr)
            Case COL_CurrencyID
                Dim arr() As Integer = {IndexOfColumn(tdbg, COL_ExchangeRate), IndexOfColumn(tdbg, COL_ExchangeRateDecimals)}
                CopyColumnArr(tdbg, iCol, arr)
                For i As Integer = tdbg.Row To tdbg.RowCount - 1
                    ReFormatCol(i)
                Next
                tdbg.UpdateData()
        End Select
    End Sub
#End Region
    Private Sub ReFormatCol()  'Hàm format lại khi thay đổi loại tiền
        tdbg.Columns(COL_ExchangeRate).Value = Number(tdbg.Columns(COL_ExchangeRate).Text, "N" & tdbg.Columns(COL_ExchangeRateDecimals).Text)
        tdbg.Columns(COL_UnitPrice).Value = Number(tdbg.Columns(COL_UnitPrice).Text, "N" & tdbg.Columns(COL_PurchasePriceDecimals).Text)
    End Sub
    Private Sub ReFormatCol(ByVal i As Integer) 'Dùng cho HeadClick
        tdbg(i, COL_ExchangeRate) = Number(tdbg(i, COL_ExchangeRate), "N" & tdbg(i, COL_ExchangeRateDecimals).ToString)
        tdbg(i, COL_UnitPrice) = Number(tdbg(i, COL_UnitPrice), "N" & tdbg(i, COL_PurchasePriceDecimals).ToString)
    End Sub

    Private Sub AfterColUpdate(ByVal iCol As Integer, ByVal dr() As DataRow)
        Dim iRow As Integer = tdbg.Row
        If dr Is Nothing OrElse dr.Length = 0 Then
            Dim row As DataRow = Nothing
            AfterColUpdate(iCol, row)
        ElseIf dr.Length = 1 Then
            If tdbg.Bookmark <> tdbg.Row AndAlso tdbg.RowCount = tdbg.Row Then 'Đang đứng dòng mới
                Dim dr1 As DataRow = _dtGrid.NewRow
                ' dtGrid.Rows.InsertAt(dr1, tdbg.Row)'Bỏ 09/06/2017 vì dtGrid.DefaultView.RowFilter <>"" thì tdbg.Row luôn luôn = 0 nên gắn dữ liệu sai
                _dtGrid.Rows.Add(dr1) 'Luôn luôn add dưới table
                SetDefaultValues(tdbg, dr1) 'Bổ sung set giá trị mặc định 19/08/2015
                tdbg.Bookmark = tdbg.Row
            End If
            AfterColUpdate(iCol, dr(0))
        Else
            For Each row As DataRow In dr
                If tdbg.Bookmark <> tdbg.Row AndAlso tdbg.RowCount = tdbg.Row Then 'Đang đứng dòng mới
                    Dim dr1 As DataRow = _dtGrid.NewRow
                    ' dtGrid.Rows.InsertAt(dr1, tdbg.Row)'Ánh Bỏ 09/06/2017 vì dtGrid.DefaultView.RowFilter <>"" thì tdbg.Row luôn luôn = 0 nên gắn dữ liệu sai
                    _dtGrid.Rows.Add(dr1) 'Luôn luôn add dưới table
                    SetDefaultValues(tdbg, dr1) 'Bổ sung set giá trị mặc định 19/08/2015
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
        Select Case tdbg.Columns(iCol).DataField
            Case COL_ObjectTypeID
                tdbg.Columns(COL_ObjectID).Text = ""
                tdbg.Columns(COL_ObjectName).Text = ""
                '**********************
                If dr Is Nothing OrElse dr.Item("ObjectTypeID").ToString = "" Then
                    tdbg.Columns(COL_ObjectTypeID).Text = ""
                Else
                    tdbg.Columns(COL_ObjectTypeID).Text = dr.Item("ObjectTypeID").ToString
                End If
            Case COL_ObjectID
                If dr Is Nothing OrElse dr.Item("ObjectID").ToString = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_ObjectID).Text = ""
                    tdbg.Columns(COL_ObjectName).Text = ""
                End If
                If tdbg.Columns(COL_ObjectTypeID).Text = "" Then
                    tdbg(tdbg.Row, COL_ObjectTypeID) = dr.Item("ObjectTypeID").ToString
                    LoadTdbdObjectID(tdbg.Columns(COL_ObjectTypeID).Text)
                End If
                tdbg.Columns(COL_ObjectID).Text = dr.Item("ObjectID").ToString
                tdbg.Columns(COL_ObjectName).Text = dr.Item("ObjectName").ToString

            Case COL_CurrencyID
                If dr Is Nothing OrElse dr.Item("CurrencyID").ToString = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_CurrencyID).Text = ""
                    tdbg.Columns(COL_ExchangeRate).Text = "0"
                    tdbg.Columns(COL_ExchangeRateDecimals).Text = "0"
                    tdbg.Columns(COL_PurchasePriceDecimals).Text = "0"
                Else
                    tdbg.Columns(COL_CurrencyID).Text = dr.Item("CurrencyID").ToString
                    tdbg.Columns(COL_ExchangeRate).Text = dr.Item("ExchangeRate").ToString
                    tdbg.Columns(COL_ExchangeRateDecimals).Text = dr.Item("ExchangeRateDecimal").ToString
                    tdbg.Columns(COL_PurchasePriceDecimals).Text = dr.Item("PurchasePriceDecimals").ToString
                End If
                ReFormatCol()
        End Select
    End Sub

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
        Dim arrColObligatory() As Object = {COL_InventoryID}
        usrOption.AddColVisible(tdbg, dtF12, arrColObligatory)
        If usrOption IsNot Nothing Then usrOption.Dispose()
        usrOption = New D99U1111(Me, tdbg, dtF12)
    End Sub

#End Region
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    'Private Function AllowSave() As Boolean
    '    For i As Integer = 0 To tdbg.RowCount - 1
    '        If tdbg(i, COL_ObjectTypeID).ToString = "" Then
    '            D99C0008.MsgNotYetEnter(tdbg.Columns(COL_ObjectTypeID).Caption)
    '            tdbg.SplitIndex = 1
    '            tdbg.Col = IndexOfColumn(tdbg, COL_ObjectTypeID)
    '            tdbg.Row = i
    '            tdbg.Focus()
    '            Return False
    '        End If

    '        If tdbg(i, COL_ObjectID).ToString = "" Then
    '            D99C0008.MsgNotYetEnter(tdbg.Columns(COL_ObjectID).Caption)
    '            tdbg.SplitIndex = 1
    '            tdbg.Col = IndexOfColumn(tdbg, COL_ObjectID)
    '            tdbg.Row = i
    '            tdbg.Focus()
    '            Return False
    '        End If

    '        If tdbg(i, COL_CurrencyID).ToString = "" Then
    '            D99C0008.MsgNotYetEnter(tdbg.Columns(COL_CurrencyID).Caption)
    '            tdbg.SplitIndex = 1
    '            tdbg.Col = IndexOfColumn(tdbg, COL_CurrencyID)
    '            tdbg.Row = i
    '            tdbg.Focus()
    '            Return False
    '        End If

    '        If tdbg(i, COL_ExchangeRate).ToString = "" Then
    '            D99C0008.MsgNotYetEnter(tdbg.Columns(COL_ExchangeRate).Caption)
    '            tdbg.SplitIndex = 1
    '            tdbg.Col = IndexOfColumn(tdbg, COL_ExchangeRate)
    '            tdbg.Row = i
    '            tdbg.Focus()
    '            Return False
    '        End If
    '    Next i

    '    Return True
    'End Function

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
        btnSelect.Focus()
        If btnSelect.Focused = False Then Exit Sub
        '************************************
        tdbg.UpdateData()
        _dtGrid.AcceptChanges()
        ' If Not AllowSave() Then Exit Sub

        _bSaved = True
        Me.Close()
    End Sub

  





End Class