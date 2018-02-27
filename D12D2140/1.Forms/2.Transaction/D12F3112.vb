Imports System.Data
Imports System
Public Class D12F3112


#Region "Const of tdbg"
    Private Const COL_OQuantity As Integer = 0 ' Số lượng
    Private Const COL_CQuantity As Integer = 1 ' Số lượng QĐ
#End Region

    Private _bIsSplit As Boolean = False
    Public ReadOnly Property bIsSplit() As Boolean 
        Get
            Return _bIsSplit
        End Get
    End Property

    Private _inventoryID As String
    Public WriteOnly Property InventoryID() As String
        Set(ByVal Value As String)
            _inventoryID = Value
        End Set
    End Property

    Private _tOQuantity As Double
    Public WriteOnly Property TOQuantity() As Double
        Set(ByVal Value As Double)
            _tOQuantity = Value
        End Set
    End Property

    Private _conversionFactor As Double
    Public WriteOnly Property ConversionFactor() As Double
        Set(ByVal Value As Double)
            _conversionFactor = Value
        End Set
    End Property

    Private _dtGrid As DataTable
    Public Property dtGrid() As DataTable
        Get
            Return _dtGrid
        End Get
        Set(ByVal Value As DataTable)
            _dtGrid = Value
        End Set
    End Property

    Private Sub D12F3112_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        End If
    End Sub


    Private Sub D12F3112_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        SetBackColorObligatory()
        LoadLanguage()
        tdbg_LockedColumns()
        tdbg_NumberFormat()
        LoadData()
        InputbyUnicode(Me, gbUnicode)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Tach_so_luong") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'TÀch sç l§íng
        '================================================================ 
        lblInventoryID.Text = rl3("Ma_hang") 'Mã hàng
        lblTOQuantity.Text = rl3("So_luong") 'Số lượng
        '================================================================ 
        btnSplit.Text = rl3("_Tach") '&Tách
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbg.Columns(COL_OQuantity).Caption = rl3("So_luong") 'Số lượng
        tdbg.Columns(COL_CQuantity).Caption = rl3("So_luong_QD") 'Số lượng QĐ
    End Sub

    Private Sub SetBackColorObligatory()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_CQuantity).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(0).DisplayColumns(COL_CQuantity).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(0).DisplayColumns(COL_CQuantity).Locked = True
        tdbg.Splits(0).DisplayColumns(COL_CQuantity).AllowFocus = False
    End Sub

    Private Sub tdbg_NumberFormat()
        Dim arr() As FormatColumn = Nothing
        AddDecimalColumns(arr, tdbg.Columns(COL_OQuantity).DataField, DxxFormat.D07_QuantityDecimals, 28, 8)
        AddDecimalColumns(arr, tdbg.Columns(COL_CQuantity).DataField, DxxFormat.D07_QuantityDecimals, 28, 8)
        InputNumber(tdbg, arr)
    End Sub

    Private Sub LoadData()
        txtInventoryID.Text = _inventoryID
        txtTOQuantity.Text = _tOQuantity.ToString
        '***********************
        LoadDataSource(tdbg, _dtGrid, gbUnicode)
        FooterSumNew(tdbg, COL_OQuantity)
    End Sub

    Private Sub CalCQuantity(Optional ByVal row As Integer = -1)
        If row = -1 Then
            tdbg.Columns(COL_CQuantity).Text = SQLNumber(Number(tdbg.Columns(COL_OQuantity).Text) * _conversionFactor, tdbg.Columns(COL_CQuantity).NumberFormat)
        Else
            tdbg(row, COL_CQuantity) = SQLNumber(Number(tdbg(row, COL_OQuantity), tdbg.Columns(COL_OQuantity).NumberFormat) * _conversionFactor, tdbg.Columns(COL_CQuantity).NumberFormat)
        End If
    End Sub


#Region "tdbg"
    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán và giá trị phụ thuộc từ Dropdown
        Select Case e.ColIndex
            Case COL_OQuantity
                CalCQuantity()
        End Select
        tdbg.UpdateData()
        FooterSumNew(tdbg, COL_OQuantity)
    End Sub

    Private Sub tdbg_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.AfterDelete
        FooterSumNew(tdbg, COL_OQuantity)
    End Sub

    Private Sub tdbg_BeforeDelete(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles tdbg.BeforeDelete
        If tdbg.RowCount = 1 Then e.Cancel = True 'Nếu lưới có 1 dòng thì không cho xóa
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Select Case tdbg.Col
            Case COL_OQuantity
                If e.KeyCode = Keys.Enter Then
                    tdbg.UpdateData()
                    If Number(txtTOQuantity.Text, DxxFormat.D07_QuantityDecimals) > Number(tdbg.Columns(COL_OQuantity).FooterText, tdbg.Columns(COL_OQuantity).NumberFormat) Then
                        InsertRow()
                    End If
                End If
        End Select
    End Sub

#End Region

    Private Sub btnSplit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSplit.Click
        Dim iTotal As Double
        For i As Integer = 0 To tdbg.RowCount - 1
            If Number(tdbg(i, COL_OQuantity).ToString) <= 0 Then
                D99C0008.MsgL3(rL3("Ban_phai_nhap_so_lon_hon_0"))
                tdbg.Focus()
                tdbg.Row = i
                tdbg.Col = COL_OQuantity
                Exit Sub
            End If
            iTotal += Number(tdbg(i, COL_OQuantity).ToString)
        Next

        If iTotal <> _tOQuantity Then
            D99C0008.MsgL3(rL3("Tong_so_luong_tren_luoi_phai_bang") & " " & _tOQuantity.ToString)
            Exit Sub
        End If

        _bIsSplit = True
        Me.Close()
    End Sub

    Private Sub InsertRow()
        'Them dong moi va gan gia tri mac dinh
        If tdbg.Row = tdbg.RowCount - 1 Then
            Dim dr As DataRow = _dtGrid.NewRow
            _dtGrid.Rows.InsertAt(dr, tdbg.Row + 1)

            tdbg(tdbg.RowCount - 1, COL_OQuantity) = Number(Number(txtTOQuantity.Text, DxxFormat.D07_QuantityDecimals) - Number(tdbg.Columns(COL_OQuantity).FooterText, tdbg.Columns(COL_OQuantity).NumberFormat), tdbg.Columns(COL_OQuantity).NumberFormat)
            CalCQuantity(tdbg.RowCount - 1)
            tdbg.UpdateData()
            FooterSumNew(tdbg, COL_OQuantity)

            tdbg.Focus()
            tdbg.SplitIndex = 0
            tdbg.Focus()
            tdbg.Col = COL_OQuantity
            tdbg.Row = tdbg.RowCount - 1
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub





End Class