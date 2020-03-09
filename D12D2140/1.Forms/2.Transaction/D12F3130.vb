Imports System
Public Class D12F3130
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

#Region "Const of tdbg"
    Private Const COL_TransID As Integer = 0       ' TransID
    Private Const COL_BatchID As Integer = 1       ' BatchID
    Private Const COL_ComponentID As Integer = 2   ' Mã thành phần
    Private Const COL_ComponentName As Integer = 3 ' Tên thành phần
    Private Const COL_Spec01ID As Integer = 4      ' Spec01ID
    Private Const COL_Spec02ID As Integer = 5      ' Spec02ID
    Private Const COL_Spec03ID As Integer = 6      ' Spec03ID
    Private Const COL_Spec04ID As Integer = 7      ' Spec04ID
    Private Const COL_Spec05ID As Integer = 8      ' Spec05ID
    Private Const COL_Spec06ID As Integer = 9      ' Spec06ID
    Private Const COL_Spec07ID As Integer = 10     ' Spec07ID
    Private Const COL_Spec08ID As Integer = 11     ' Spec08ID
    Private Const COL_Spec09ID As Integer = 12     ' Spec09ID
    Private Const COL_Spec10ID As Integer = 13     ' Spec10ID
    Private Const COL_CUnitID As Integer = 14      ' ĐVT
    Private Const COL_COQuantity As Integer = 15   ' Số lượng
    Private Const COL_CCQuantity As Integer = 16   ' Số lượng QĐ
    Private Const COL_Description As Integer = 17  ' Diễn giải
#End Region

    Private _POItemID As String
    Public WriteOnly Property POItemID() As String
        Set(ByVal Value As String)
            _POItemID = Value
        End Set
    End Property

    Private _disableSaveButton As Boolean = True
    Public WriteOnly Property DisableSaveButton() As Boolean
        Set(ByVal Value As Boolean)
            _disableSaveButton = Value
        End Set
    End Property

    Private Sub D12F3130_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadInfoGeneral()
        LoadTDBGridSpecificationCaption(tdbg, COL_Spec01ID, 0, True, gbUnicode)
        Loadlanguage()
        tdbg_NumberFormat()
        tdbg_LockedColumns()
        ResetFooterGrid(tdbg, 0, tdbg.Splits.Count - 1)
        LoadData()
        If _disableSaveButton Then btnSave.Enabled = False
        InputbyUnicode(Me, gbUnicode)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_ComponentID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_ComponentName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
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
        tdbg.Splits(SPLIT0).DisplayColumns(COL_CUnitID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_COQuantity).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_CCQuantity).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Dim dtGrid As DataTable
    Private Sub LoadData()
        dtGrid = ReturnDataTable(SQLStoreD12P3150)
        If dtGrid.Rows.Count > 0 Then
            Dim dr As DataRow = dtGrid.Rows(0)
            tdbcInventoryID.Text = dr("InventoryID").ToString
            txtInventoryName.Text = dr("InventoryName").ToString
            txtUnitID.Text = dr("UnitID").ToString
            txtCQuantity.Text = SQLNumber(dr("CQuantity"), DxxFormat.D07_QuantityDecimals)
        End If
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        FooterTotalGrid(tdbg, COL_ComponentID)
        FooterSumNew(tdbg, COL_COQuantity, COL_CCQuantity)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rL3("Chi_tiet_Kit_-_D12F3130") & UnicodeCaption(gbUnicode) 'Chi tiÕt Kit - D12F3130
        '================================================================ 
        lblInventoryID.Text = rL3("_Ma_hang") 'Mã hàng
        lblUnitID.Text = rL3("DVT") 'ĐVT
        lblCQuantity.Text = rL3("So_luong") 'Số lượng
        '================================================================ 
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        btnSave.Text = rL3("_Luu") '&Lưu
        '================================================================ 
        tdbcInventoryID.Columns("InventoryID").Caption = rL3("_Ma_hang") 'Mã hàng
        tdbcInventoryID.Columns("InventoryName").Caption = rL3("Ten_hang") 'Tên hàng
        '================================================================ 
        tdbg.Columns("ComponentID").Caption = rL3("Ma_thanh_phan") 'Mã thành phần
        tdbg.Columns("ComponentName").Caption = rL3("Ten_thanh_phan") 'Tên thành phần
        tdbg.Columns("CUnitID").Caption = rL3("DVT") 'ĐVT
        tdbg.Columns("COQuantity").Caption = rL3("So_luong") 'Số lượng
        tdbg.Columns("CCQuantity").Caption = rL3("So_luong_QD") 'Số lượng QĐ
        tdbg.Columns("Description").Caption = rL3("Dien_giai") 'Diễn giải
    End Sub

    Private Sub tdbg_NumberFormat()
        Dim arr() As FormatColumn = Nothing
        AddDecimalColumns(arr, tdbg.Columns(COL_COQuantity).DataField, DxxFormat.D07_QuantityDecimals, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_CCQuantity).DataField, DxxFormat.D07_QuantityDecimals, 28, 8)
        InputNumber(tdbg, arr)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
        btnSave.Focus()
        If btnSave.Focused = False Then Exit Sub
        '************************************
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        sSQL.Append(SQLDeleteD12T3100.ToString)
        sSQL.Append(SQLInsertD12T3100s)

        _bSaved = False
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            _bSaved = True
            SaveOK()
            btnClose.Focus()
        Else
            SaveNotOK()
            btnSave.Focus()
        End If
    End Sub

    Private Function AllowSave() As Boolean
        tdbg.UpdateData()
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If tdbg.Col = COL_Description Then HotKeyEnterGrid(tdbg, COL_Description, e, 0)
            Case Keys.F7
                If tdbg.Col = COL_Description Then HotKeyF7(tdbg)
            Case Keys.S
                If e.Control Then HeadClick(tdbg.Col)
        End Select
    End Sub

    Private Sub HeadClick(ByVal iCol As Integer)
        Select Case iCol
            Case COL_Description
                CopyColumns(tdbg, iCol, tdbg.Columns(iCol).Text, tdbg.Row)
        End Select
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD12P3150
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 04/07/2016 10:30:15
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD12P3150() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load luoi" & vbCrlf)
        sSQL &= "Exec D12P3150 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(_POItemID) & COMMA 'POItemID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD12T3100
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 29/12/2008 11:06:54
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD12T3100() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D12T3100"
        sSQL &= " Where POItemID = " & SQLString(_POItemID)
        Return sSQL & vbCrLf
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD12T3100s
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 29/12/2008 11:08:15
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD12T3100s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        Dim sTransID As String = ""
        Dim iCountIGE As Integer = 0
        Dim iFirstIGETransID As Long

        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_TransID).ToString = "" Then
                iCountIGE = iCountIGE + 1
            End If
        Next

        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_TransID).ToString = "" Then
                sTransID = CreateIGENewS("D12T3100", "TransID", "12", "KI", gsStringKey, sTransID, iCountIGE, iFirstIGETransID)
                tdbg(i, COL_TransID) = sTransID
            End If

            sSQL.Append("Insert Into D12T3100(")
            sSQL.Append("TransID, POItemID, ComponentID, ComponentNameU, Spec01ID, ")
            sSQL.Append("Spec02ID, Spec03ID, Spec04ID, Spec05ID, Spec06ID, ")
            sSQL.Append("Spec07ID, Spec08ID, Spec09ID, Spec10ID, UnitID, ")
            sSQL.Append("OQuantity, CQuantity, DescriptionU")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(tdbg(i, COL_TransID)) & COMMA) 'TransID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(_POItemID) & COMMA) 'POItemID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_ComponentID)) & COMMA) 'ComponentID, varchar[20], NOT NULL
            'sSQL.Append(SQLStringUnicode(tdbg(i, COL_ComponentName), gbUnicode, False) & COMMA) 'ComponentName, varchar[500], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_ComponentName), gbUnicode, True) & COMMA) 'ComponentNameU, varchar[500], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Spec01ID)) & COMMA) 'Spec01ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Spec02ID)) & COMMA) 'Spec02ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Spec03ID)) & COMMA) 'Spec03ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Spec04ID)) & COMMA) 'Spec04ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Spec05ID)) & COMMA) 'Spec05ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Spec06ID)) & COMMA) 'Spec06ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Spec07ID)) & COMMA) 'Spec07ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Spec08ID)) & COMMA) 'Spec08ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Spec09ID)) & COMMA) 'Spec09ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Spec10ID)) & COMMA) 'Spec10ID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_CUnitID)) & COMMA) 'UnitID, varchar[20], NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_COQuantity).ToString) & COMMA) 'OQuantity, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbg(i, COL_CCQuantity).ToString) & COMMA) 'CQuantity, decimal, NOT NULL
            'sSQL.Append(SQLStringUnicode(tdbg(i, COL_Description), gbUnicode, False) & COMMA) 'Description, decimal, NOT NULL
            sSQL.Append(SQLStringUnicode(tdbg(i, COL_Description), gbUnicode, True)) 'Description, decimal, NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function
End Class
