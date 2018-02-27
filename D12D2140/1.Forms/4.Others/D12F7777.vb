Public Class D12F7777
    Private iWidthForm As Integer
    Private iHeightForm As Integer

    Dim iMaxID As Integer
    Dim sLabelDetailName As String 'Tên của lablel diễn giải
    Dim sLabelName As String 'tên của label Title

    Dim iLeftAlign As Integer 'Lề trái của label title
    Dim iLabelDistance As Integer ' khoảng cách giữa tên và diễn giải của label
    Dim iTopAlign As Integer
    Dim iDescLeftAlign As Integer 'Lề trái của label diễn giải
    Dim iSpace As Integer ' khoảng cách giữa 2 dòng
    Dim iHeight As Integer
    Dim iCaptionHeight As Integer ' chiều cao của label: 19

    Dim iMaxIndex As Integer  ' chỉ số của label có độ dài lớn nhất
    Dim iMaxWidth As Integer ' độ dài của label dài nhất: Left + Width
    Dim iLabelMaxWidth As Integer 'độ dài của label dài nhất: Width

    Dim OnForm As String
    Dim CtrlF1 As String
    Dim F11 As String
    Dim OnGrid As String
    Dim F7 As String
    Dim F8 As String
    Dim CtrlD As String
    Dim CtrlAltC As String
    Dim CtrlS As String
    Dim CtrlHome As String
    Dim CtrlEnd As String
    Dim CtrlPageUp As String
    Dim CtrlPageDown As String
    Dim CtrlArrowR As String
    Dim CtrlArrowL As String
    Dim CtrlDelete As String
    Dim CtrlInsert As String
    Dim ShiftInsert As String
    Dim F4 As String
    Dim F9 As String
    Dim F6 As String
    Dim F3 As String
    Dim ShiftF3 As String
    Dim sClose As String

    Private Sub FillCaption()
        If geLanguage = EnumLanguage.Vietnamese Then
            Me.Text = "Danh sÀch phÛm nâng "
            OnForm = "Trên form"
            CtrlF1 = "Hiển thị các phím nóng"
            F11 = "Di chuyển con trỏ tới lưới"
            F4 = "Thông tin tham khảo"

            OnGrid = "Trên lưới"
            F7 = "Copy ô trên xuống ô dưới"
            F8 = "Copy dòng trên xuống dòng dưới"
            CtrlD = "Copy diễn giải trên master xuống detail"
            CtrlS = "Copy cột đang đứng"
            CtrlAltC = "Copy cột đang đứng"
            CtrlHome = "Di chuyển tới cột đầu tiên"
            CtrlEnd = "Di chuyển tới cột cuối cùng"
            CtrlPageUp = "Di chuyển tới dòng đầu tiên"
            CtrlPageDown = "Di chuyển tới dòng cuối cùng"
            CtrlArrowR = "Di chuyển tới split tiếp theo"
            CtrlArrowL = "Trở về split trước đó"
            CtrlDelete = "Xóa dòng hiện tại"
            CtrlInsert = "Thêm dòng mới"
            ShiftInsert = "Chèn dòng mới"
            F3 = "Xem số dư tồn kho"
            ShiftF3 = "Xem số dư hàng tồn kho mở rộng"
            F6 = "Chi tiết KIT"

            sClose = "Đóng Form phím nóng"
        Else
            Me.Text = "List of HotKeys "
            OnForm = "On The Form"
            CtrlF1 = "Show HotKeys' List"
            F11 = "Moving cursor to grid"

            OnGrid = "On The Grid"
            F7 = "Copy upper cell to lower cell"
            F8 = "Copy upper row to lower row"
            CtrlD = "Copy Description from master to detail"
            CtrlS = "Copy current column (Press HeadClick)"
            CtrlAltC = "Copy current column (Press HeadClick)"
            CtrlHome = "Moving currsor to first column"
            CtrlEnd = "Moving currsor to last column"
            CtrlPageUp = "Moving currsor to first row"
            CtrlPageDown = "Moving currsor to last row"
            CtrlArrowR = "Moving currsor to next split"
            CtrlArrowL = "Moving currsor to previous split"
            CtrlDelete = "Delete current row"
            CtrlInsert = "Add new row"
            ShiftInsert = "Insert new row"
            F3 = "Inventory Balance"
            ShiftF3 = "Stock Balance"
            F4 = "Reference Information"
            F6 = "Kit's Component"

            F9 = "Copy all columns from current position currsor"
            sClose = "Close this form"
        End If
    End Sub

    Public Sub CallShowForm(ByVal sForm As String)
        FillCaption()
        sLabelName = "lblObj"
        sLabelDetailName = "lbl"
        iLeftAlign = 2
        iDescLeftAlign = 100
        iTopAlign = 3
        iLabelDistance = iDescLeftAlign - iLeftAlign

        iSpace = 0
        iHeight = 19
        iMaxWidth = 0
        iMaxIndex = 0

        iCaptionHeight = 0
        iMaxID = 0
        CreateLabelS(OnForm, "", Color.Blue, 9.75!)

        CreateLabelS("Ctrl+F1", CtrlF1, Color.Black)
        CreateLabelS("F11", F11, Color.Black)

        'End Select
        CreateLabelS("Esc", sClose, Color.Black)
        CreateLabelS(OnGrid, "", Color.Blue, 9.75!)
        'CreateLabelS("F7", F7, Color.Black)
        'CreateLabelS("Ctrl+Alt+C", CtrlAltC, Color.Black)


        'Dùng cho form đặc biệt
        Select Case sForm
            Case "D12F3110"
                CreateLabelS("F3", F3, Color.Black)
                CreateLabelS("Shift + F3", ShiftF3, Color.Black)
                CreateLabelS("F4", F4, Color.Black)
                CreateLabelS("F6", F6, Color.Black)
                CreateLabelS("Ctrl + S", CtrlS, Color.Black)

            Case Else
                CreateLabelS("F7", F7, Color.Black)
                CreateLabelS("F8", F8, Color.Black)
                CreateLabelS("Ctrl+S", CtrlS, Color.Black)
                CreateLabelS("Ctrl+D", CtrlD, Color.Black)

                CreateLabelS("Ctrl+Insert", CtrlInsert, Color.Black)
                CreateLabelS("Ctrl+Delete", CtrlDelete, Color.Black)
                CreateLabelS("Shift+Insert", ShiftInsert, Color.Black)

        End Select

        CreateLabelS("Ctrl+Home", CtrlHome, Color.Black)
        CreateLabelS("Ctrl+End", CtrlEnd, Color.Black)
        CreateLabelS("Ctrl+PageUp", CtrlPageUp, Color.Black)
        CreateLabelS("Ctrl+PageDown", CtrlPageDown, Color.Black)
        CreateLabelS("Ctrl+ -->", CtrlArrowR, Color.Black)
        CreateLabelS("Ctrl+ <--", CtrlArrowL, Color.Black)



        AdjustLabelDistance()
        iWidthForm = iDescLeftAlign + iLabelMaxWidth
        iHeightForm = iTopAlign + 25

        Me.Size = New System.Drawing.Size(iWidthForm, iHeightForm)
        'Me.Location = New System.Drawing.Point(My.Forms.D27F0000.Width - Me.Width - 10, 0)
        Me.Location = New System.Drawing.Point(My.Computer.Screen.WorkingArea.Width - Me.Width + 1, 0)

    End Sub

    Private Sub CreateLabelS(ByVal sName As String, ByVal sDesc As String, ByVal clForeColor As System.Drawing.Color, Optional ByVal sglFontSize As Single = 8.25!, Optional ByVal Bold As Boolean = True, Optional ByVal DescBold As Boolean = False)
        iMaxID = iMaxID + 1
        Dim ldbName As New Label
        Dim lblDetailName As New Label

        With ldbName
            .Name = sLabelName & iMaxID
            .AutoSize = True
            .Height = iHeight
            .Left = iLeftAlign
            .Top = iTopAlign
            .Visible = True
            .ForeColor = clForeColor
            .BackColor = Me.BackColor

            .Text = sName

            If Bold Then
                .Font = New System.Drawing.Font("Microsoft Sans Serif", sglFontSize, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Else
                .Font = New System.Drawing.Font("Microsoft Sans Serif", sglFontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            End If

        End With
        Me.Controls.Add(ldbName)
        If ldbName.Width > iLabelDistance Then iLabelDistance = ldbName.Width

        With lblDetailName
            .Name = sLabelDetailName & iMaxID
            .AutoSize = True
            .Height = iHeight
            .Left = iDescLeftAlign
            .Top = iTopAlign
            .Visible = True

            .ForeColor = clForeColor
            .BackColor = Me.BackColor
            .Text = sDesc

            If DescBold Then
                .Font = New System.Drawing.Font("Microsoft Sans Serif", sglFontSize, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Else
                .Font = New System.Drawing.Font("Microsoft Sans Serif", sglFontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            End If

            iCaptionHeight = .Height
        End With
        Me.Controls.Add(lblDetailName)
        If lblDetailName.Left + lblDetailName.Width > iMaxWidth Then
            iMaxWidth = lblDetailName.Left + lblDetailName.Width
            iMaxIndex = iMaxID
            iLabelMaxWidth = lblDetailName.Width
        End If

        iTopAlign = iTopAlign + iCaptionHeight + iSpace
    End Sub

    'Điều chỉnh khoảng cách giữa tên và diễn giải của label
    Private Sub AdjustLabelDistance()
        Dim Index As Integer
        If iLabelDistance > 66 Then
            For Index = 1 To iMaxID
                Me.Controls(sLabelDetailName & Index).Left = iLeftAlign + iLabelDistance + 15
            Next
            iDescLeftAlign = Me.Controls(sLabelDetailName & "1").Left
        End If
    End Sub

    
End Class