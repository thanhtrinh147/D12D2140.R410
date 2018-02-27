Public Class D12F3032
    Private _bSaved As Boolean = False
    Public ReadOnly Property bSaved() As Boolean
        Get
            Return _bSaved
        End Get
    End Property

#Region "Const of tdbg - Total of Columns: 10"
    Private Const COL_Choose As String = "Choose"                     ' Chọn
    Private Const COL_InventoryID As String = "InventoryID"           ' Mã hàng
    Private Const COL_InventoryName As String = "InventoryName"       ' Tên hàng
    Private Const COL_UnitID As String = "UnitID"                     ' ĐVT
    Private Const COL_ApprovedQuantity As String = "ApprovedQuantity" ' SL yêu cầu
    Private Const COL_ObjectID As String = "ObjectID"                 ' Mã NCC
    Private Const COL_ObjectName As String = "ObjectName"             ' Tên NCC
    Private Const COL_TotalRatio As String = "TotalRatio"             ' Tổng điểm
    Private Const COL_PRTransactionID As String = "PRTransactionID"   ' PRTransactionID
    Private Const COL_PRID As String = "PRID"                         ' PRID
#End Region

    Private dtGrid As DataTable
    Private Sub D12F3032_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        LoadInfoGeneral() 'Load System/ Option /... in DxxD9940
        ResetFooterGrid(tdbg, 0, tdbg.Splits.Count - 1)
        tdbg_LockedColumns()
        tdbg_NumberFormat()
        LoadTDBGrid()
        LoadLanguage()
        InputbyUnicode(Me, gbUnicode)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub D12F3032_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me, True)
            Case Keys.F11
                HotKeyF11(Me, tdbg)
        End Select
    End Sub
    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rL3("Lua_chon_nha_cung_cap_(buoc_3)") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Løa chãn nhª cung cÊp (b§ìc 3)
        '================================================================ 
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        btnContinue.Text = rL3("_Tiep_tuc") '&Tiếp tục
        '================================================================ 
        tdbg.Columns(COL_Choose).Caption = rL3("Chon") 'Chọn
        tdbg.Columns(COL_InventoryID).Caption = rL3("Ma_hang") 'Mã hàng
        tdbg.Columns(COL_InventoryName).Caption = rL3("Ten_hang_") 'Tên hàng
        tdbg.Columns(COL_UnitID).Caption = rL3("DVT") 'ĐVT
        tdbg.Columns(COL_ApprovedQuantity).Caption = rL3("SL_yeu_cau") 'SL yêu cầu
        tdbg.Columns(COL_ObjectID).Caption = rL3("Ma_NCC") 'Mã NCC
        tdbg.Columns(COL_ObjectName).Caption = rL3("Ten_NCC") 'Tên NCC
        tdbg.Columns(COL_TotalRatio).Caption = rL3("Tong_diem") 'Tổng điểm
    End Sub
    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_InventoryID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_InventoryName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_UnitID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_ApprovedQuantity).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_ObjectID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_ObjectName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_TotalRatio).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub
    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_ApprovedQuantity).NumberFormat = DxxFormat.D07_QuantityDecimals
        tdbg.Columns(COL_TotalRatio).NumberFormat = DxxFormat.DefaultNumber2
    End Sub
    Private Sub LoadTDBGrid()
        LoadTableCaption(tdbg)
        '*****************
        Dim sSQL As String = SQLStoreD12P3031("Do nguon luoi", 1)
        dtGrid = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ResetGrid()
        'CreateExpression() '19/10/2017, Nguyễn Quốc Khương: id 96585-Bổ sung phân luồng dữ liệu khi lựa chọn NCC (bỏ)
    End Sub
    Private Sub CreateExpression()
        Dim sExpression As String = ""
        Try
            Dim dr() As DataRow = dtCol.Select("FieldName Like '%CoefRatio'") 'Tạo công thức = tổng các cột điểm theo hệ số
            For i As Integer = 0 To dr.Length - 1
                sExpression &= "IsNull([" & dr(i).Item("FieldName").ToString & "], 0)" & IIf(i <> dr.Length - 1, " + ", "").ToString
            Next
            '====================================================
            dr = dtCol.Select("Formula not is null And Formula <>''") 'Set Expression cho cot dong
            For i As Integer = 0 To dr.Length - 1
                dtGrid.Columns(dr(i).Item("FieldName").ToString).Expression = dr(i).Item("Formula").ToString
            Next
        Catch ex As Exception

        End Try
        dtGrid.Columns(COL_TotalRatio).Expression = sExpression
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = ""

        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString
        If strFind <> "" Then strFind = "(" & strFind & ") Or " & COL_Choose & "  =1"
        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub
    Private Sub ResetGrid()
        FooterTotalGrid(tdbg, COL_InventoryID)
        FooterSumNew(tdbg, COL_ApprovedQuantity, COL_TotalRatio)
        FooterSumNew(tdbg, sSumFooter.ToArray)
    End Sub

#Region "Add cột động"
    Dim dtCol As DataTable = Nothing
    Dim arrCol() As FormatColumn = Nothing
    Private Sub LoadTableCaption(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        If dtCol IsNot Nothing AndAlso dtCol.Rows.Count > 0 Then   'Xóa các cột động cũ, phải để trước load dtCol
            For i As Integer = 0 To dtCol.Rows.Count - 1
                c1Grid.Columns.RemoveAt(IndexOfColumn(c1Grid, dtCol.Rows(i).Item("FieldName").ToString))
            Next
        End If

        Dim sSQL As String = SQLStoreD12P3031("Do cot dong", 2)
        dtCol = ReturnDataTable(sSQL)
        If dtCol.Rows.Count > 0 Then
            arrCol = Nothing
            sSumFooter.Clear()
            '*********************
            'Add cột
            For i As Integer = 0 To dtCol.Rows.Count - 1
                AddColumns(c1Grid, i, dtCol, False)
            Next

            'Định dạng các cột số trên lưới
            If arrCol IsNot Nothing Then InputNumber(c1Grid, arrCol)
            c1Grid.Refresh()
        End If
    End Sub

    Dim iIndexCol As Integer = 0
    Dim sSumFooter As New List(Of String)
    Private Sub AddColumns(ByRef c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal i As Integer, ByVal dtCol As DataTable, Optional ByVal bChangeDisplayColums As Boolean = False)
        Dim sField As String = dtCol.Rows(i).Item("FieldName").ToString
        Dim dc As New C1.Win.C1TrueDBGrid.C1DataColumn
        dc.Caption = dtCol.Rows(i).Item("Caption").ToString
        dc.DataField = sField
        If bChangeDisplayColums = False Then
            c1Grid.Columns.Add(dc)
        Else
            iIndexCol = L3Int(dtCol.Rows(i).Item("OrderNo")) 'Index insert do store trả ra
            c1Grid.Columns.Insert(iIndexCol, dc)
            '=============================================================================================
            For k As Integer = 0 To c1Grid.Splits.ColCount - 1
                Dim dispColumn As C1.Win.C1TrueDBGrid.C1DisplayColumn = c1Grid.Splits(k).DisplayColumns(dc.DataField)
                tdbg_ChangeDisplayColumns(c1Grid, dispColumn, iIndexCol, k)
            Next k
        End If
        '*******************************
        Try
            If dtCol.Rows(i).Item("Status").ToString = "H" Then
                c1Grid.Splits(0).DisplayColumns(sField).Visible = False
            Else
                c1Grid.Splits(0).DisplayColumns(sField).Visible = True
            End If
            c1Grid.Splits(0).DisplayColumns(sField).Locked = (dtCol.Rows(i).Item("Status").ToString = "R")
            If c1Grid.Splits(0).DisplayColumns(sField).Locked Then c1Grid.Splits(0).DisplayColumns(sField).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            '************************
            c1Grid.Splits(0).DisplayColumns(sField).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            AddDecimalColumns(arrCol, sField, "N2", 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
            sSumFooter.Add(sField)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        c1Grid.Splits(0).DisplayColumns(sField).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        c1Grid.Splits(0).DisplayColumns(sField).HeadingStyle.Font = FontUnicode(gbUnicode)
        c1Grid.Splits(0).DisplayColumns(sField).Style.Font = FontUnicode(gbUnicode)
        c1Grid.Splits(0).DisplayColumns(sField).Width = 140 ' L3Int(dtCol.Rows(i).Item("Length"))
        'c1Grid.Splits(0).DisplayColumns(sField).Frozen = L3Bool(dtCol.Rows(i).Item("IsFixed"))
    End Sub

    Private Sub tdbg_ChangeDisplayColumns(ByRef c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal dispColumnOld As C1.Win.C1TrueDBGrid.C1DisplayColumn, ByVal posNew As Integer, Optional ByVal iSplit As Integer = 0)
        With c1Grid.Splits(iSplit)
            Dim iDisplay As Integer = .DisplayColumns.IndexOf(dispColumnOld.DataColumn)
            If iDisplay = -1 Then Exit Sub

            Dim dispColumn As C1.Win.C1TrueDBGrid.C1DisplayColumn = .DisplayColumns(dispColumnOld.DataColumn)
            dispColumn.Style.HorizontalAlignment = dispColumnOld.Style.HorizontalAlignment
            dispColumn.Style.VerticalAlignment = dispColumnOld.Style.VerticalAlignment
            dispColumn.Style.Font = New Font(dispColumnOld.Style.Font.Name, dispColumnOld.Style.Font.Size, dispColumnOld.Style.Font.Style)
            dispColumn.HeadingStyle.Font = New Font(dispColumnOld.HeadingStyle.Font.Name, dispColumnOld.HeadingStyle.Font.Size, dispColumnOld.HeadingStyle.Font.Style)
            dispColumn.HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            dispColumn.Button = dispColumnOld.Button
            dispColumn.ButtonAlways = dispColumnOld.ButtonAlways
            dispColumn.ButtonText = dispColumnOld.ButtonText
            dispColumn.FetchStyle = dispColumnOld.FetchStyle
            dispColumn.Locked = dispColumnOld.Locked
            dispColumn.Merge = dispColumnOld.Merge
            dispColumn.Visible = dispColumnOld.Visible
            .DisplayColumns.RemoveAt(iDisplay)
            .DisplayColumns.Insert(posNew, dispColumn)
        End With
    End Sub
#End Region

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
    Private Sub tdbg_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles tdbg.FetchRowStyle
        If L3Bool(tdbg(e.Row, COL_Choose)) Then e.CellStyle.ForeColor = Color.Blue
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        Select Case tdbg.Columns(e.ColIndex).DataField
            Case COL_Choose
                If L3Bool(tdbg.Columns(COL_Choose).Value) Then
                    For i As Integer = 0 To tdbg.RowCount - 1
                        If tdbg.Row <> i AndAlso tdbg.Columns(COL_InventoryID).Text = tdbg(i, COL_InventoryID).ToString Then
                            tdbg(i, COL_Choose) = 0
                        End If
                    Next
                End If
                tdbg.UpdateData()
        End Select
    End Sub


#End Region

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
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
        Return True
    End Function
    Private Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        btnContinue.Focus()
        If btnContinue.Focused = False Then Exit Sub
        '************************************
        Dim dr() As DataRow = Nothing
        If AllowSave(dr) = False Then Exit Sub

        Dim sSQL As New StringBuilder
        sSQL.Append(SQLDeleteD12T9009.ToString & vbCrLf)
        sSQL.Append(SQLInsertD12T9009s(dr).ToString & vbCrLf)
        If ExecuteSQL(sSQL.ToString) Then
            Dim frm As New D12F3050
            frm.FormID = Me.Name
            frm.ShowDialog()
            If frm.bSaved Then _bSaved = True
            frm.Dispose()
            Me.Close()
        End If
    End Sub


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD12P3031
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 27/07/2017 03:17:19
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD12P3031(sComment As String, iMode As Byte) As String
        Dim sSQL As String = ""
        sSQL &= ("-- " & sComment & vbCrLf)
        sSQL &= "Exec D12P3031 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'Division, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString("") & COMMA 'VoucherID, varchar[50], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, int, NOT NULL
        sSQL &= SQLNumber(iMode) 'Mode, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD12T9009
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 27/07/2017 03:32:03
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD12T9009() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa bang tam" & vbCrlf)
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
    '# Created Date: 27/07/2017 03:33:06
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD12T9009s(dr() As DataRow) As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder

        For i As Integer = 0 To dr.Length - 1
            If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Luu bang tam" & vbCrlf)
            sSQL.Append("Insert Into D12T9009(")
            sSQL.Append("UserID, HostID, FormID, Key01ID, Key02ID, " & vbCrlf)
            sSQL.Append("Key03ID, Key04ID, Key05ID")
            sSQL.Append(") Values(" & vbCrlf)
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[50], NOT NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[50], NOT NULL
            sSQL.Append(SQLString(Me.Name) & COMMA) 'FormID, varchar[50], NOT NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item(COL_PRTransactionID), gbUnicode, True) & COMMA) 'Key01ID, nvarchar[1000], NOT NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item(COL_PRID), gbUnicode, True) & COMMA & vbCrLf) 'Key02ID, nvarchar[1000], NOT NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item(COL_InventoryID), gbUnicode, True) & COMMA) 'Key03ID, nvarchar[1000], NOT NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item(COL_ObjectID), gbUnicode, True) & COMMA) 'Key04ID, nvarchar[1000], NOT NULL
            sSQL.Append(SQLStringUnicode(dr(i).Item(COL_ObjectName), gbUnicode, gbUnicode)) 'Key05ID, nvarchar[1000], NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.tostring & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function
End Class