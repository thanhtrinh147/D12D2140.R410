Imports System
Public Class D12F3040

    Private _selectedSupplier As Integer
    Public WriteOnly Property SelectedSupplier() As Integer
        Set(ByVal Value As Integer)
            _selectedSupplier = Value
        End Set
    End Property

    Private _autoSelectSupplier As Integer
    Public WriteOnly Property AutoSelectSupplier() As Integer
        Set(ByVal Value As Integer)
            _autoSelectSupplier = Value
        End Set
    End Property


    Private _checkedCount As Integer
    Public WriteOnly Property CheckedCount() As Integer
        Set(ByVal Value As Integer)
            _checkedCount = Value
        End Set
    End Property

    Private _bDiff As boolean
    Public WriteOnly Property bDiff() As boolean
        Set(ByVal Value As boolean)
            _bDiff = Value
        End Set
    End Property

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function AllowNext() As Boolean
        If tdbcValueID.Text.Trim = "" And tdbcValueID.Enabled Then
            D99C0008.MsgNotYetChoose(rl3("Uu_tien") & " 1")
            tdbcValueID.Focus()
            Return False
        End If
        If tdbcValueID2.Text.Trim = "" And tdbcValueID2.Enabled Then
            D99C0008.MsgNotYetChoose(rl3("Uu_tien") & " 2")
            tdbcValueID2.Focus()
            Return False
        End If
        If tdbcValueID3.Text.Trim = "" And tdbcValueID3.Enabled Then
            D99C0008.MsgNotYetChoose(rl3("Uu_tien") & " 3")
            tdbcValueID3.Focus()
            Return False
        End If

        'If _bDiff = True Then
        '    D99C0008.MsgL3(rl3("Chon_nha_cung_cap_tu_dong_chi_ap_dung_cho_mot_mat_hang"))
        '    Return False
        'End If

        Return True
    End Function

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If Not AllowNext() Then
            Exit Sub
        End If

        Dim f As New D12F3050
        f.AutoSelectSupplier = _autoSelectSupplier
        f.SelectedSupplier = _selectedSupplier
        f.BaseOnPrice = CInt(IIf(chkBaseOnPrice.Checked, 1, 0))
        f.BaseONPriority = CInt(IIf(chkBaseOnPriority.Checked, 1, 0))
        f.BaseDeliveryDay = CInt(IIf(chkBaseDeliveryDay.Checked, 1, 0))
        f.Value1 = IIf(tdbcValueID.Enabled, tdbcValueID.Columns(0).Text, "").ToString
        f.Value2 = IIf(tdbcValueID2.Enabled, tdbcValueID2.Columns(0).Text, "").ToString
        f.Value3 = IIf(tdbcValueID3.Enabled, tdbcValueID3.Columns(0).Text, "").ToString

        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcValueID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcValueID2.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcValueID3.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub D12F3040_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub D12F3040_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Loadlanguage()
        SetBackColorObligatory()
        LoadTdbc()
        InputbyUnicode(Me, gbUnicode)
        'Bắt buộc check ưu tiên 1
        chkBaseOnPrice.Checked = True
        chkBaseOnPrice.Enabled = False
        tdbcValueID2.Enabled = False
        tdbcValueID3.Enabled = False

        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Lua_chon_nha_cung_cap_(buoc_2)_-_D12F3040") & UnicodeCaption(gbUnicode)  'Løa chãn nhª cung cÊp (b§ìc 2) - D12F3040
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnNext.Text = rl3("Tiep_tuc") 'Tiếp tục
        '================================================================ 
        chkBaseDeliveryDay.Text = rl3("Uu_tien_3") 'Ưu tiên 3
        chkBaseOnPriority.Text = rl3("Uu_tien_2") 'Ưu tiên 2
        chkBaseOnPrice.Text = rl3("Uu_tien_1") 'Ưu tiên 1
        '================================================================ 
        grp1.Text = rl3("Chon_nha_cung_cap_tu_dong") 'Chọn nhà cung cấp tự động
        '================================================================ 
        tdbcValueID3.Columns("ValuesID").Caption = rl3("Ma") 'Mã
        tdbcValueID3.Columns("ValuesName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcValueID2.Columns("ValuesID").Caption = rl3("Ma") 'Mã
        tdbcValueID2.Columns("ValuesName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbcValueID.Columns("ValuesID").Caption = rl3("Ma") 'Mã
        tdbcValueID.Columns("ValuesName").Caption = rl3("Dien_giai") 'Diễn giải
    End Sub


    Private Sub LoadTdbc()
        Dim sSQL As String = ""
        sSQL = "Select ValuesID, ValuesName" & UnicodeJoin(gbUnicode) & " as ValuesName From D12V3050 Where Language = " & SQLString(gsLanguage) & "Order By No"

        Dim dt As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(tdbcValueID, dt.Copy, gbUnicode)
        LoadDataSource(tdbcValueID2, dt.Copy, gbUnicode)
        LoadDataSource(tdbcValueID3, dt.Copy, gbUnicode)
    End Sub

#Region "Events tdbcValueID"

    Private Sub tdbcValueID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcValueID.Close
        If tdbcValueID.FindStringExact(tdbcValueID.Text) = -1 Then tdbcValueID.Text = ""
    End Sub

    Private Sub tdbcValueID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcValueID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcValueID.Text = ""
    End Sub

#End Region

#Region "Events tdbcValueID2"

    Private Sub tdbcValueID2_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcValueID2.Close
        If tdbcValueID2.FindStringExact(tdbcValueID2.Text) = -1 Then tdbcValueID2.Text = ""
    End Sub

    Private Sub tdbcValueID2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcValueID2.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcValueID2.Text = ""
    End Sub

#End Region

#Region "Events tdbcValueID3"

    Private Sub tdbcValueID3_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcValueID3.Close
        If tdbcValueID3.FindStringExact(tdbcValueID3.Text) = -1 Then tdbcValueID3.Text = ""
    End Sub

    Private Sub tdbcValueID3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcValueID3.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcValueID3.Text = ""
    End Sub

#End Region


    Private Sub chkBaseOnPrice_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBaseOnPrice.CheckedChanged
        tdbcValueID.Enabled = chkBaseOnPrice.Checked
    End Sub

    Private Sub chkBaseOnPriority_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBaseOnPriority.CheckedChanged
        tdbcValueID2.Enabled = chkBaseOnPriority.Checked
    End Sub

    Private Sub chkBaseDeliveryDay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBaseDeliveryDay.CheckedChanged
        tdbcValueID3.Enabled = chkBaseDeliveryDay.Checked
    End Sub
End Class
