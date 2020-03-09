Imports System
Public Class D12F3111

    Private _pOID As String = ""
    Public Property POID() As String
        Get
            Return _pOID
        End Get
        Set(ByVal Value As String)
            _pOID = value
        End Set
    End Property

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value
            LoadCaptionInfo()

            Select Case _FormState
                Case EnumFormState.FormAdd
                    ' LoadAddNew()
                Case EnumFormState.FormEdit
                    LoadEdit()
            End Select
        End Set
    End Property

    Private _isViewPermission As Boolean
    Public WriteOnly Property IsViewPermission() As Boolean
        Set(ByVal Value As Boolean)
            _isViewPermission = Value
        End Set
    End Property

    Private Sub D12F3111_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub D12F3111_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If bLoadFormState = False Then FormState = _FormState
        Me.Cursor = Cursors.WaitCursor
        Loadlanguage()
        InputbyUnicode(Me, gbUnicode)
        btnSave.Enabled = _isViewPermission = False
        '********************
        Dim c1Numer() As C1.Win.C1Input.C1NumericEdit = {cneMNum01, cneMNum02, cneMNum03, cneMNum04, cneMNum05, cneMNum06, cneMNum07, cneMNum08, cneMNum09, cneMNum10}
        InputNumber(c1Numer, SqlDbType.Decimal, DxxFormat.DefaultNumber2, False, 28, 8)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Thong_tin_bo_sung_-_D12F3111") & UnicodeCaption(gbUnicode) 'Th¤ng tin bå sung - D12F3111
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
    End Sub

    Private Sub LoadCaptionInfo()
        Dim sSQL As String = SQLStoreD06P0110()
        Dim dt As DataTable = ReturnDataTable(sSQL)
        Try
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim sFieldName As String = dt.Rows(i).Item("Field").ToString
                Try
                    Dim lbl As Label = CType(grpMaster.Controls("lbl" & sFieldName), Label)
                    If lbl IsNot Nothing Then 'Bị lỗi tên Field của label
                        lbl.Text = dt.Rows(i).Item("Caption" & gsLanguage).ToString
                        lbl.Font = FontUnicode(gbUnicode, grpMaster.Controls("lbl" & sFieldName).Font.Style)
                    End If
                    Select Case L3Int(dt.Rows(i).Item("DataType"))
                        Case 0 'Số
                            Dim cneNumber As C1.Win.C1Input.C1NumericEdit = CType(grpMaster.Controls("cne" & sFieldName), C1.Win.C1Input.C1NumericEdit)
                            cneNumber.Tag = L3Int(dt.Rows(i).Item("DecimalNum"))
                            cneNumber.Enabled = L3Bool(dt.Rows(i).Item("DefaultUse"))
                            If cneNumber.Enabled Then cneNumber.Value = dt.Rows(i).Item("DefaultValue")
                        Case 1 'Chuỗi
                            Dim txtNumber As TextBox = CType(grpMaster.Controls("txt" & sFieldName), TextBox)
                            txtNumber.MaxLength = L3Int(dt.Rows(i).Item("DecimalNum"))
                            txtNumber.Enabled = L3Bool(dt.Rows(i).Item("DefaultUse"))
                            If txtNumber.MaxLength = 0 And txtNumber.Enabled Then ReadOnlyControl(txtNumber)
                            If txtNumber.Enabled Then txtNumber.Text = dt.Rows(i).Item("DefaultValue").ToString
                        Case 2 'Ngày
                            Dim c1date As C1.Win.C1Input.C1DateEdit = CType(grpMaster.Controls("c1date" & sFieldName), C1.Win.C1Input.C1DateEdit)
                            c1date.Enabled = L3Bool(dt.Rows(i).Item("DefaultUse"))
                            If c1date.Enabled Then c1date.Value = dt.Rows(i).Item("DefaultValue").ToString
                    End Select
                Catch ex As Exception
                    Continue For
                End Try
            Next
            dt.Dispose()
        Catch ex As Exception
            D99C0008.MsgL3(ex.Message)
        End Try
    End Sub

    Private Sub LoadEdit()
        Dim sSQL As String = ""
        sSQL = "Select MStr01" & UnicodeJoin(gbUnicode) & " as MStr01,MStr02" & UnicodeJoin(gbUnicode) & " as MStr02,MStr03" & UnicodeJoin(gbUnicode) & " as MStr03,MStr04" & UnicodeJoin(gbUnicode) & " as MStr04,MStr05" & UnicodeJoin(gbUnicode) & " as MStr05,MStr06" & UnicodeJoin(gbUnicode) & " as MStr06,MStr07" & UnicodeJoin(gbUnicode) & " as MStr07,MStr08" & UnicodeJoin(gbUnicode) & " as MStr08,MStr09" & UnicodeJoin(gbUnicode) & " as MStr09,MStr10" & UnicodeJoin(gbUnicode) & " as MStr10," & vbCrLf
        sSQL &= "MNum01,MNum02,MNum03,MNum04,MNum05,MNum06,MNum07,MNum08,MNum09,MNum10," & vbCrLf
        sSQL &= "MDat01,MDat02,MDat03,MDat04,MDat05,MDat06,MDat07,MDat08,MDat09,MDat10" & vbCrLf
        sSQL &= "From D12T2050 WITH(NOLOCK) Where POID=" & SQLString(_pOID)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            cneMNum01.Value = Number(dt.Rows(0).Item("MNum01"), DxxFormat.DefaultNumber2)
            cneMNum02.Value = Number(dt.Rows(0).Item("MNum02"), DxxFormat.DefaultNumber2)
            cneMNum03.Value = Number(dt.Rows(0).Item("MNum03"), DxxFormat.DefaultNumber2)
            cneMNum04.Value = Number(dt.Rows(0).Item("MNum04"), DxxFormat.DefaultNumber2)
            cneMNum05.Value = Number(dt.Rows(0).Item("MNum05"), DxxFormat.DefaultNumber2)
            cneMNum06.Value = Number(dt.Rows(0).Item("MNum06"), DxxFormat.DefaultNumber2)
            cneMNum07.Value = Number(dt.Rows(0).Item("MNum07"), DxxFormat.DefaultNumber2)
            cneMNum08.Value = Number(dt.Rows(0).Item("MNum08"), DxxFormat.DefaultNumber2)
            cneMNum09.Value = Number(dt.Rows(0).Item("MNum09"), DxxFormat.DefaultNumber2)
            cneMNum10.Value = Number(dt.Rows(0).Item("MNum10"), DxxFormat.DefaultNumber2)

            txtMStr01.Text = dt.Rows(0).Item("MStr01").ToString
            txtMStr02.Text = dt.Rows(0).Item("MStr02").ToString
            txtMStr03.Text = dt.Rows(0).Item("MStr03").ToString
            txtMStr04.Text = dt.Rows(0).Item("MStr04").ToString
            txtMStr05.Text = dt.Rows(0).Item("MStr05").ToString
            txtMStr06.Text = dt.Rows(0).Item("MStr06").ToString
            txtMStr07.Text = dt.Rows(0).Item("MStr07").ToString
            txtMStr08.Text = dt.Rows(0).Item("MStr08").ToString
            txtMStr09.Text = dt.Rows(0).Item("MStr09").ToString
            txtMStr10.Text = dt.Rows(0).Item("MStr10").ToString

            c1dateMDat01.Value = SQLDateShow(dt.Rows(0).Item("MDat01"))
            c1dateMDat02.Value = SQLDateShow(dt.Rows(0).Item("MDat02"))
            c1dateMDat03.Value = SQLDateShow(dt.Rows(0).Item("MDat03"))
            c1dateMDat04.Value = SQLDateShow(dt.Rows(0).Item("MDat04"))
            c1dateMDat05.Value = SQLDateShow(dt.Rows(0).Item("MDat05"))
            c1dateMDat06.Value = SQLDateShow(dt.Rows(0).Item("MDat06"))
            c1dateMDat07.Value = SQLDateShow(dt.Rows(0).Item("MDat07"))
            c1dateMDat08.Value = SQLDateShow(dt.Rows(0).Item("MDat08"))
            c1dateMDat09.Value = SQLDateShow(dt.Rows(0).Item("MDat09"))
            c1dateMDat10.Value = SQLDateShow(dt.Rows(0).Item("MDat10"))
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
        btnSave.Focus()
        If btnSave.Focused = False Then Exit Sub
        '************************************
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        sSQL.Append(SQLUpdateD12T2050.ToString & vbCrLf)
        sSQL.Append(SQLUpdateD06T2410.ToString & vbCrLf)
        sSQL.Append(SQLUpdateD06T2510.ToString & vbCrLf)

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
            btnClose.Focus()
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD06P0110
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 25/04/2008 11:08:49
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD06P0110() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D06P0110 "
        sSQL &= SQLString("D06T2510") & COMMA 'TableName, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD06T2510
    '# Created User: 
    '# Created Date: 25/04/2008 02:25:51
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD12T2050() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D12T2050 Set ")
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("LastModifyDate = GetDate()" & COMMA) 'datetime, NOT NULL
        'sSQL.Append("MStr01 = " & SQLStringUnicode(txtMStr01.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        'sSQL.Append("MStr02 = " & SQLStringUnicode(txtMStr02.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        'sSQL.Append("MStr03 = " & SQLStringUnicode(txtMStr03.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        'sSQL.Append("MStr04 = " & SQLStringUnicode(txtMStr04.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        'sSQL.Append("MStr05 = " & SQLStringUnicode(txtMStr05.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        'sSQL.Append("MStr06 = " & SQLStringUnicode(txtMStr06.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        'sSQL.Append("MStr07 = " & SQLStringUnicode(txtMStr07.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        'sSQL.Append("MStr08 = " & SQLStringUnicode(txtMStr08.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        'sSQL.Append("MStr09 = " & SQLStringUnicode(txtMStr09.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        'sSQL.Append("MStr10 = " & SQLStringUnicode(txtMStr10.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("MStr01U = " & SQLStringUnicode(txtMStr01.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("MStr02U = " & SQLStringUnicode(txtMStr02.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("MStr03U = " & SQLStringUnicode(txtMStr03.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("MStr04U = " & SQLStringUnicode(txtMStr04.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("MStr05U = " & SQLStringUnicode(txtMStr05.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("MStr06U = " & SQLStringUnicode(txtMStr06.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("MStr07U = " & SQLStringUnicode(txtMStr07.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("MStr08U = " & SQLStringUnicode(txtMStr08.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("MStr09U = " & SQLStringUnicode(txtMStr09.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("MStr10U = " & SQLStringUnicode(txtMStr10.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("MNum01 = " & SQLMoney(cneMNum01.Value, DxxFormat.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("MNum02 = " & SQLMoney(cneMNum02.Value, DxxFormat.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("MNum03 = " & SQLMoney(cneMNum03.Value, DxxFormat.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("MNum04 = " & SQLMoney(cneMNum04.Value, DxxFormat.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("MNum05 = " & SQLMoney(cneMNum05.Value, DxxFormat.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("MNum06 = " & SQLMoney(cneMNum06.Value, DxxFormat.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("MNum07 = " & SQLMoney(cneMNum07.Value, DxxFormat.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("MNum08 = " & SQLMoney(cneMNum08.Value, DxxFormat.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("MNum09 = " & SQLMoney(cneMNum09.Value, DxxFormat.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("MNum10 = " & SQLMoney(cneMNum10.Value, DxxFormat.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("MDat01 = " & SQLDateSave(c1dateMDat01.Value) & COMMA) 'datetime, NULL
        sSQL.Append("MDat02 = " & SQLDateSave(c1dateMDat02.Value) & COMMA) 'datetime, NULL
        sSQL.Append("MDat03 = " & SQLDateSave(c1dateMDat03.Value) & COMMA) 'datetime, NULL
        sSQL.Append("MDat04 = " & SQLDateSave(c1dateMDat04.Value) & COMMA) 'datetime, NULL
        sSQL.Append("MDat05 = " & SQLDateSave(c1dateMDat05.Value) & COMMA) 'datetime, NULL
        sSQL.Append("MDat06 = " & SQLDateSave(c1dateMDat06.Value) & COMMA) 'datetime, NULL
        sSQL.Append("MDat07 = " & SQLDateSave(c1dateMDat07.Value) & COMMA) 'datetime, NULL
        sSQL.Append("MDat08 = " & SQLDateSave(c1dateMDat08.Value) & COMMA) 'datetime, NULL
        sSQL.Append("MDat09 = " & SQLDateSave(c1dateMDat09.Value) & COMMA) 'datetime, NULL
        sSQL.Append("MDat10 = " & SQLDateSave(c1dateMDat10.Value)) 'datetime, NULL
        sSQL.Append(" Where ")
        sSQL.Append("POID = " & SQLString(_pOID))

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD06T2510
    '# Created User: 
    '# Created Date: 25/04/2008 02:25:51
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD06T2510() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D06T2510 Set ")
        'sSQL.Append("MStr01 = " & SQLStringUnicode(txtMStr01.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        'sSQL.Append("MStr02 = " & SQLStringUnicode(txtMStr02.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        'sSQL.Append("MStr03 = " & SQLStringUnicode(txtMStr03.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        'sSQL.Append("MStr04 = " & SQLStringUnicode(txtMStr04.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        'sSQL.Append("MStr05 = " & SQLStringUnicode(txtMStr05.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        'sSQL.Append("MStr06 = " & SQLStringUnicode(txtMStr06.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        'sSQL.Append("MStr07 = " & SQLStringUnicode(txtMStr07.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        'sSQL.Append("MStr08 = " & SQLStringUnicode(txtMStr08.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        'sSQL.Append("MStr09 = " & SQLStringUnicode(txtMStr09.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        'sSQL.Append("MStr10 = " & SQLStringUnicode(txtMStr10.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("MStr01U = " & SQLStringUnicode(txtMStr01.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("MStr02U = " & SQLStringUnicode(txtMStr02.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("MStr03U = " & SQLStringUnicode(txtMStr03.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("MStr04U = " & SQLStringUnicode(txtMStr04.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("MStr05U = " & SQLStringUnicode(txtMStr05.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("MStr06U = " & SQLStringUnicode(txtMStr06.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("MStr07U = " & SQLStringUnicode(txtMStr07.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("MStr08U = " & SQLStringUnicode(txtMStr08.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("MStr09U = " & SQLStringUnicode(txtMStr09.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("MStr10U = " & SQLStringUnicode(txtMStr10.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("MNum01 = " & SQLMoney(cneMNum01.Value, DxxFormat.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("MNum02 = " & SQLMoney(cneMNum02.Value, DxxFormat.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("MNum03 = " & SQLMoney(cneMNum03.Value, DxxFormat.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("MNum04 = " & SQLMoney(cneMNum04.Value, DxxFormat.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("MNum05 = " & SQLMoney(cneMNum05.Value, DxxFormat.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("MNum06 = " & SQLMoney(cneMNum06.Value, DxxFormat.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("MNum07 = " & SQLMoney(cneMNum07.Value, DxxFormat.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("MNum08 = " & SQLMoney(cneMNum08.Value, DxxFormat.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("MNum09 = " & SQLMoney(cneMNum09.Value, DxxFormat.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("MNum10 = " & SQLMoney(cneMNum10.Value, DxxFormat.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("MDat01 = " & SQLDateSave(c1dateMDat01.Value) & COMMA) 'datetime, NULL
        sSQL.Append("MDat02 = " & SQLDateSave(c1dateMDat02.Value) & COMMA) 'datetime, NULL
        sSQL.Append("MDat03 = " & SQLDateSave(c1dateMDat03.Value) & COMMA) 'datetime, NULL
        sSQL.Append("MDat04 = " & SQLDateSave(c1dateMDat04.Value) & COMMA) 'datetime, NULL
        sSQL.Append("MDat05 = " & SQLDateSave(c1dateMDat05.Value) & COMMA) 'datetime, NULL
        sSQL.Append("MDat06 = " & SQLDateSave(c1dateMDat06.Value) & COMMA) 'datetime, NULL
        sSQL.Append("MDat07 = " & SQLDateSave(c1dateMDat07.Value) & COMMA) 'datetime, NULL
        sSQL.Append("MDat08 = " & SQLDateSave(c1dateMDat08.Value) & COMMA) 'datetime, NULL
        sSQL.Append("MDat09 = " & SQLDateSave(c1dateMDat09.Value) & COMMA) 'datetime, NULL
        sSQL.Append("MDat10 = " & SQLDateSave(c1dateMDat10.Value)) 'datetime, NULL
        sSQL.Append(" Where ")
        sSQL.Append("POID = " & SQLString(_pOID))

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD06T2510
    '# Created User: 
    '# Created Date: 25/04/2008 02:25:51
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD06T2410() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D06T2410 Set ")
        'sSQL.Append("MStr01 = " & SQLStringUnicode(txtMStr01.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        'sSQL.Append("MStr02 = " & SQLStringUnicode(txtMStr02.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        'sSQL.Append("MStr03 = " & SQLStringUnicode(txtMStr03.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        'sSQL.Append("MStr04 = " & SQLStringUnicode(txtMStr04.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        'sSQL.Append("MStr05 = " & SQLStringUnicode(txtMStr05.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        'sSQL.Append("MStr06 = " & SQLStringUnicode(txtMStr06.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        'sSQL.Append("MStr07 = " & SQLStringUnicode(txtMStr07.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        'sSQL.Append("MStr08 = " & SQLStringUnicode(txtMStr08.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        'sSQL.Append("MStr09 = " & SQLStringUnicode(txtMStr09.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        'sSQL.Append("MStr10 = " & SQLStringUnicode(txtMStr10.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("MStr01U = " & SQLStringUnicode(txtMStr01.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("MStr02U = " & SQLStringUnicode(txtMStr02.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("MStr03U = " & SQLStringUnicode(txtMStr03.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("MStr04U = " & SQLStringUnicode(txtMStr04.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("MStr05U = " & SQLStringUnicode(txtMStr05.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("MStr06U = " & SQLStringUnicode(txtMStr06.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("MStr07U = " & SQLStringUnicode(txtMStr07.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("MStr08U = " & SQLStringUnicode(txtMStr08.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("MStr09U = " & SQLStringUnicode(txtMStr09.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("MStr10U = " & SQLStringUnicode(txtMStr10.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("MNum01 = " & SQLMoney(cneMNum01.Value, DxxFormat.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("MNum02 = " & SQLMoney(cneMNum02.Value, DxxFormat.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("MNum03 = " & SQLMoney(cneMNum03.Value, DxxFormat.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("MNum04 = " & SQLMoney(cneMNum04.Value, DxxFormat.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("MNum05 = " & SQLMoney(cneMNum05.Value, DxxFormat.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("MNum06 = " & SQLMoney(cneMNum06.Value, DxxFormat.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("MNum07 = " & SQLMoney(cneMNum07.Value, DxxFormat.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("MNum08 = " & SQLMoney(cneMNum08.Value, DxxFormat.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("MNum09 = " & SQLMoney(cneMNum09.Value, DxxFormat.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("MNum10 = " & SQLMoney(cneMNum10.Value, DxxFormat.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("MDat01 = " & SQLDateSave(c1dateMDat01.Value) & COMMA) 'datetime, NULL
        sSQL.Append("MDat02 = " & SQLDateSave(c1dateMDat02.Value) & COMMA) 'datetime, NULL
        sSQL.Append("MDat03 = " & SQLDateSave(c1dateMDat03.Value) & COMMA) 'datetime, NULL
        sSQL.Append("MDat04 = " & SQLDateSave(c1dateMDat04.Value) & COMMA) 'datetime, NULL
        sSQL.Append("MDat05 = " & SQLDateSave(c1dateMDat05.Value) & COMMA) 'datetime, NULL
        sSQL.Append("MDat06 = " & SQLDateSave(c1dateMDat06.Value) & COMMA) 'datetime, NULL
        sSQL.Append("MDat07 = " & SQLDateSave(c1dateMDat07.Value) & COMMA) 'datetime, NULL
        sSQL.Append("MDat08 = " & SQLDateSave(c1dateMDat08.Value) & COMMA) 'datetime, NULL
        sSQL.Append("MDat09 = " & SQLDateSave(c1dateMDat09.Value) & COMMA) 'datetime, NULL
        sSQL.Append("MDat10 = " & SQLDateSave(c1dateMDat10.Value)) 'datetime, NULL
        sSQL.Append(" Where ")
        sSQL.Append("ContractVoucherID = " & SQLString(_pOID))

        Return sSQL
    End Function

    

    
End Class