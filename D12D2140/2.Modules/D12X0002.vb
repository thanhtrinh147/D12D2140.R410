''' <summary>
''' Module này dùng để khai báo các Sub và Function toàn cục
''' </summary>
''' <remarks>Các khai báo Sub và Function ở đây không được trùng với các khai báo
''' ở các module D99Xxxxx
''' </remarks>
Module D12X0002

    Public Enum ButtonForGrid
        Main = 0
        Ana = 1
        Other = 2
        SubInfo = 3
    End Enum

    '''<summary>
    ''' Tinh tong cho 1 cot
    '''  </summary>
    'Public Function MyFooterSum(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal iCol As Integer, Optional ByVal sFormat As String = "") As String
    '    If sFormat = "" Then
    '        sFormat = c1Grid.Columns(iCol).NumberFormat
    '    End If

    '    Dim dblSum As Double = 0
    '    For i As Integer = 0 To c1Grid.RowCount() - 1
    '        dblSum += Number(Format(Number(c1Grid(i, iCol)), sFormat))
    '    Next i
    '    Return Format(dblSum, sFormat)

    'End Function
    Public xCheckAna(9) As Boolean 'Khởi động tại Form_load: Ghi lại việc kiểm tra lần đầu lưu, khi nhấn lưu lần thứ 2 thì không cần kiểm tra nữa

    Public Sub ResetXCheckAna()
        For i As Integer = 0 To 9
            xCheckAna(i) = False
        Next i
    End Sub

    Public Sub MsgNoPermissionAdd()
        D99C0008.MsgL3(rl3("Ban_khong_co_quyen_them_moi"))
    End Sub

    Public Sub LoadTdbcTransTypeID(ByVal tdbcTransTypeID As C1.Win.C1List.C1Combo, ByVal TransactionID As String, Optional ByVal sEditTransTypeID As String = "")
        Dim sSQL As String = ""
        sSQL &= " SELECT TransTypeID, TransTypeName" & UnicodeJoin(gbUnicode) & " as TransTypeName, DAGroupID, Disabled, VoucherTypeID, EmployeeID," & vbCrLf
        sSQL &= "VoucherDesc" & UnicodeJoin(gbUnicode) & " as VoucherDesc, UseSpec01ID, UseSpec02ID, UseSpec03ID, UseSpec04ID, UseSpec05ID, UseSpec06ID, " & vbCrLf
        sSQL &= "UseSpec07ID, UseSpec08ID, UseSpec09ID, UseSpec10ID, DefaultSpec01ID, DefaultSpec02ID, DefaultSpec03ID," & vbCrLf
        sSQL &= "DefaultSpec04ID, DefaultSpec05ID, DefaultSpec06ID, DefaultSpec07ID, DefaultSpec08ID, DefaultSpec09ID, DefaultSpec10ID," & vbCrLf
        sSQL &= "UseAna01ID, UseAna02ID, UseAna03ID, UseAna04ID, UseAna05ID,UseAna06ID, UseAna07ID, UseAna08ID, UseAna09ID, UseAna10ID," & vbCrLf
        sSQL &= "CheckAna01ID, CheckAna02ID, CheckAna03ID, CheckAna04ID, CheckAna05ID, CheckAna06ID, CheckAna07ID, CheckAna08ID, CheckAna09ID, CheckAna10ID, " & vbCrLf
        sSQL &= "DefaultAna01ID, DefaultAna02ID, DefaultAna03ID, DefaultAna04ID, DefaultAna05ID, DefaultAna06ID, DefaultAna07ID, DefaultAna08ID, DefaultAna09ID, DefaultAna10ID," & vbCrLf
        sSQL &= "CreateUserID, CreateDate, LastModifyUserID, LastModifyDate,NotSetQTYZero, NotSetSpcDef, TransactionID, CurrencyID," & vbCrLf
        sSQL &= "ObjectTypeID, ObjectID, ReceiptPersonID, ShipAddressID,PaymentMethodID, PaymentTermID, UseCQuantity, UseCAmount," & vbCrLf
        sSQL &= "LockOAmount, LockCAmount, TypePostedD06, D06VoucherTypeID,Objectname," & vbCrLf
        sSQL &= "DefaultSpec01Name" & UnicodeJoin(gbUnicode) & " as DefaultSpec01Name,DefaultSpec02Name" & UnicodeJoin(gbUnicode) & " as DefaultSpec02Name,DefaultSpec03Name" & UnicodeJoin(gbUnicode) & " as DefaultSpec03Name,DefaultSpec04Name" & UnicodeJoin(gbUnicode) & " as DefaultSpec04Name,DefaultSpec05Name" & UnicodeJoin(gbUnicode) & " as DefaultSpec05Name,DefaultSpec06Name" & UnicodeJoin(gbUnicode) & " as DefaultSpec06Name,DefaultSpec07Name" & UnicodeJoin(gbUnicode) & " as DefaultSpec07Name,DefaultSpec08Name" & UnicodeJoin(gbUnicode) & " as DefaultSpec08Name,DefaultSpec09Name" & UnicodeJoin(gbUnicode) & " as DefaultSpec09Name,DefaultSpec10Name" & UnicodeJoin(gbUnicode) & " as DefaultSpec10Name" & vbCrLf
        sSQL &= ",WHAccordingToINV, WareHouseID, AllowChangeSpecID, UseD54 FROM D12N1010()" & vbCrLf
        sSQL &= " Where Disabled = 0 And TransactionID = " & SQLString(TransactionID) & vbCrLf
        sSQL &= "And (DAGroupID = '' " & vbCrLf
        sSQL &= "Or DAGroupID In (       Select   DAGroupID" & vbCrLf
        sSQL &= " From Lemonsys.DBO.D00V0080" & vbCrLf
        sSQL &= "Where     UserID = " & SQLString(gsUserID) & ")" & vbCrLf
        sSQL &= "Or 'LEMONADMIN' =  " & SQLString(gsUserID) & ")" & vbCrLf
        If sEditTransTypeID <> "" Then
            sSQL &= " OR TransTypeID = " & SQLString(sEditTransTypeID) & vbCrLf
        End If
        sSQL &= "Order By        TransTypeID"
        LoadDataSource(tdbcTransTypeID, sSQL, gbUnicode)
    End Sub

    Public Sub SQLInsertD12T5558(ByVal sVoucherIGE As String, ByVal sOldVoucherNo As String, ByVal sNewVoucherNo As String)
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D12T5558(")
        sSQL.Append("DivisionID, VoucherID, OldVoucherNo, NewVoucherNo, CreateDate, CreateUserID, ")
        sSQL.Append("TranMonth, TranYear")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(gsDivisionID) & COMMA) 'VoucherID, varchar[20], NOT NULL
        sSQL.Append(SQLString(sVoucherIGE) & COMMA) 'VoucherID, varchar[20], NOT NULL
        sSQL.Append(SQLString(sOldVoucherNo) & COMMA) 'OldVoucherNo, varchar[20], NOT NULL
        sSQL.Append(SQLString(sNewVoucherNo) & COMMA) 'NewVoucherNo, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
        sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, int, NOT NULL
        sSQL.Append(SQLNumber(giTranYear)) 'TranYear, int, NOT NULL
        sSQL.Append(")")

        ExecuteSQLNoTransaction(sSQL.ToString)
    End Sub

    Public Function SQLDeleteD91T9009(Optional ByVal sKey03ID As String = "") As String
        Dim ssQL As String = ""
        ssQL &= "Delete From D91T9009 Where HostID=" & SQLString(My.Computer.Name) & " And UserID=" & SQLString(gsUserID) & vbCrLf
        If sKey03ID <> "" Then ssQL &= " And Key03ID = " & SQLString(sKey03ID) & vbCrLf
        Return ssQL
    End Function

    Public Sub InsertRowBelow(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal SplitIndex As Integer, ByVal ColFirst As Integer)
        Dim Col As Integer
        Dim row As Integer
        Dim iBookmark As Int32 = 0

        If Not c1Grid.AllowAddNew Or c1Grid.RowCount < 1 Then Exit Sub
        Try
            'b1: Giữ lại Bookmark tại vị trí hiện tại
            iBookmark = c1Grid.Bookmark
            'b2: Insert 1 dòng mới
            c1Grid.SplitIndex = SplitIndex
            c1Grid.Col = ColFirst
            c1Grid.MoveLast()
            c1Grid.Row = c1Grid.Row + 1
            'c1Grid.Select()

            'For Col = 0 To c1Grid.Columns.Count - 1
            '    If Col = 23 Then
            '        D99C0008.MsgL3(c1Grid.Columns(Col).DataField)
            '    End If
            '    c1Grid.Columns(Col).Value = c1Grid(iBookmark, Col)
            'Next

            'c1Grid.UpdateData()

            ''b3: Đẩy dữ liệu xuống 1dòng so với vị trí hiện tại
            For row = c1Grid.RowCount - 1 To iBookmark + 1 Step -1
                For Col = 0 To c1Grid.Columns.Count - 1
                    c1Grid(row, Col) = c1Grid(row - 1, Col)
                Next
            Next

            c1Grid.UpdateData()
            c1Grid.Row = iBookmark + 1
            c1Grid.Focus()
        Catch ex As Exception
            D99C0008.Msg("Lỗi HotKeyShiftInsert: " & ex.Message)
        End Try
    End Sub

    Public Sub RunExeDxxExx40(ByVal sExeName As String, ByVal sFormActive As String, Optional ByVal sFormPermission As String = "", Optional ByVal sKeyID01 As String = "", Optional ByVal sID01 As String = "")
        Dim exe As New Lemon3.DxxExx40(sExeName, gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        With exe
            .FormActive = sFormActive 'Form cần hiển thị
            .FormPermission = IIf(sFormPermission = "", sFormActive, sFormPermission).ToString 'Mã màn hình phân quyền
            .IDxx("ModuleID") = "12"
            If sKeyID01 <> "" AndAlso sID01 <> "" Then .IDxx(sKeyID01) = sID01 'Lưu thêm các IDxx khác tương tự khi cần
            .Run()
        End With
    End Sub

    '14/12/2017, Lê Thị THu Thảo: id 105328-Hỗ trợ tính năng search tại màn hình lựa chọn nhà cung cấp và thực hiện yêu cầu mua hàng
    Public Sub FindText(tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        If tdbg.RowCount <= 1 Then Exit Sub
        Dim sTmp As String = ""
        Dim iRowFind As Integer = 0

        Dim sFind As String = tdbg.Columns(tdbg.Col).FilterText.Trim

        For i As Integer = 0 To tdbg.RowCount - 1
            If InStr(1, tdbg(i, tdbg.Col).ToString.ToUpper, sFind.ToUpper) > 0 Then
                sTmp = tdbg(i, tdbg.Col).ToString
                iRowFind = i
                Exit For
            End If
        Next

        If sTmp = "" Then ' Nếu không tìm thấy thì tìm 
            D99C0008.MsgL3(rL3("Khong_tim_thay_gia_tri_nao"))
            tdbg.Row = 0
            tdbg.Focus()
        Else
            tdbg.Focus()
            tdbg.Row = iRowFind
            Exit Sub
        End If
    End Sub

End Module
