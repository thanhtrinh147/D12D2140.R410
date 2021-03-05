<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D12F3030
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim mnuFindLink As C1.Win.C1Command.C1CommandLink
        Dim mnuListAllLink As C1.Win.C1Command.C1CommandLink
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D12F3030))
        Me.mnuFind = New C1.Win.C1Command.C1Command()
        Me.mnuListAll = New C1.Win.C1Command.C1Command()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblPeriod = New System.Windows.Forms.Label()
        Me.chkAutoSelectSupplier = New System.Windows.Forms.CheckBox()
        Me.optSupplierReady = New System.Windows.Forms.RadioButton()
        Me.optSupplierAbsent = New System.Windows.Forms.RadioButton()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.btnChoose = New System.Windows.Forms.Button()
        Me.chkShowCheckedRow = New System.Windows.Forms.CheckBox()
        Me.C1ContextMenu = New C1.Win.C1Command.C1ContextMenu()
        Me.C1CommandHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.tdbgD = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tdbgM = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnProduction = New System.Windows.Forms.Button()
        Me.btnSubInfo = New System.Windows.Forms.Button()
        Me.tdbcPeriodFrom = New C1.Win.C1List.C1Combo()
        Me.tdbcPeriodTo = New C1.Win.C1List.C1Combo()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.btnCompare = New System.Windows.Forms.Button()
        Me.btnContinue = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnF12 = New System.Windows.Forms.Button()
        Me.C1SplitContainer1 = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.C1SplitterPanel1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.C1SplitterPanel2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        mnuFindLink = New C1.Win.C1Command.C1CommandLink()
        mnuListAllLink = New C1.Win.C1Command.C1CommandLink()
        CType(Me.C1CommandHolder,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tdbgD,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tdbgM,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tdbcPeriodFrom,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tdbcPeriodTo,System.ComponentModel.ISupportInitialize).BeginInit
        Me.FlowLayoutPanel2.SuspendLayout
        CType(Me.C1SplitContainer1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.C1SplitContainer1.SuspendLayout
        Me.C1SplitterPanel1.SuspendLayout
        Me.C1SplitterPanel2.SuspendLayout
        Me.SuspendLayout
        '
        'mnuFindLink
        '
        mnuFindLink.Command = Me.mnuFind
        '
        'mnuFind
        '
        Me.mnuFind.Name = "mnuFind"
        Me.mnuFind.ShortcutText = ""
        Me.mnuFind.Text = "Tìm &kiếm"
        '
        'mnuListAllLink
        '
        mnuListAllLink.Command = Me.mnuListAll
        '
        'mnuListAll
        '
        Me.mnuListAll.Name = "mnuListAll"
        Me.mnuListAll.ShortcutText = ""
        Me.mnuListAll.Text = "&Liệt kê tất cả"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(937, 628)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 15
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = true
        '
        'lblPeriod
        '
        Me.lblPeriod.AutoSize = true
        Me.lblPeriod.Location = New System.Drawing.Point(6, 13)
        Me.lblPeriod.Name = "lblPeriod"
        Me.lblPeriod.Size = New System.Drawing.Size(19, 13)
        Me.lblPeriod.TabIndex = 0
        Me.lblPeriod.Text = "Kỳ"
        Me.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkAutoSelectSupplier
        '
        Me.chkAutoSelectSupplier.AutoSize = true
        Me.chkAutoSelectSupplier.Location = New System.Drawing.Point(3, 3)
        Me.chkAutoSelectSupplier.Name = "chkAutoSelectSupplier"
        Me.chkAutoSelectSupplier.Size = New System.Drawing.Size(180, 17)
        Me.chkAutoSelectSupplier.TabIndex = 4
        Me.chkAutoSelectSupplier.Text = "Lựa chọn nhà cung cấp tự động"
        Me.chkAutoSelectSupplier.UseVisualStyleBackColor = true
        '
        'optSupplierReady
        '
        Me.optSupplierReady.AutoSize = true
        Me.optSupplierReady.Location = New System.Drawing.Point(329, 3)
        Me.optSupplierReady.Name = "optSupplierReady"
        Me.optSupplierReady.Size = New System.Drawing.Size(123, 17)
        Me.optSupplierReady.TabIndex = 6
        Me.optSupplierReady.TabStop = true
        Me.optSupplierReady.Text = "Đã có nhà cung cấp"
        Me.optSupplierReady.UseVisualStyleBackColor = true
        '
        'optSupplierAbsent
        '
        Me.optSupplierAbsent.AutoSize = true
        Me.optSupplierAbsent.Checked = true
        Me.optSupplierAbsent.Location = New System.Drawing.Point(189, 3)
        Me.optSupplierAbsent.Name = "optSupplierAbsent"
        Me.optSupplierAbsent.Size = New System.Drawing.Size(134, 17)
        Me.optSupplierAbsent.TabIndex = 5
        Me.optSupplierAbsent.TabStop = true
        Me.optSupplierAbsent.Text = "Chưa có nhà cung cấp"
        Me.optSupplierAbsent.UseVisualStyleBackColor = true
        '
        'btnFilter
        '
        Me.btnFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnFilter.Location = New System.Drawing.Point(937, 8)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(76, 22)
        Me.btnFilter.TabIndex = 7
        Me.btnFilter.Text = "&Lọc"
        Me.btnFilter.UseVisualStyleBackColor = true
        '
        'btnChoose
        '
        Me.btnChoose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnChoose.Location = New System.Drawing.Point(848, 628)
        Me.btnChoose.Name = "btnChoose"
        Me.btnChoose.Size = New System.Drawing.Size(83, 22)
        Me.btnChoose.TabIndex = 14
        Me.btnChoose.Text = "&Chọn"
        Me.btnChoose.UseVisualStyleBackColor = true
        '
        'chkShowCheckedRow
        '
        Me.chkShowCheckedRow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.chkShowCheckedRow.AutoSize = true
        Me.chkShowCheckedRow.Location = New System.Drawing.Point(148, 631)
        Me.chkShowCheckedRow.Name = "chkShowCheckedRow"
        Me.chkShowCheckedRow.Size = New System.Drawing.Size(191, 17)
        Me.chkShowCheckedRow.TabIndex = 16
        Me.chkShowCheckedRow.Text = "Chỉ hiển thị những dữ  liệu đã chọn"
        Me.chkShowCheckedRow.UseVisualStyleBackColor = true
        '
        'C1ContextMenu
        '
        Me.C1ContextMenu.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {mnuFindLink, mnuListAllLink})
        Me.C1ContextMenu.Name = "C1ContextMenu"
        Me.C1ContextMenu.ShortcutText = ""
        Me.C1ContextMenu.VisualStyleBase = C1.Win.C1Command.VisualStyle.OfficeXP
        '
        'C1CommandHolder
        '
        Me.C1CommandHolder.Commands.Add(Me.C1ContextMenu)
        Me.C1CommandHolder.Commands.Add(Me.mnuFind)
        Me.C1CommandHolder.Commands.Add(Me.mnuListAll)
        Me.C1CommandHolder.Owner = Me
        '
        'tdbgD
        '
        Me.tdbgD.AllowColMove = false
        Me.tdbgD.AllowColSelect = false
        Me.tdbgD.AllowFilter = false
        Me.tdbgD.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbgD.AllowSort = false
        Me.tdbgD.AlternatingRows = true
        Me.tdbgD.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.C1CommandHolder.SetC1ContextMenu(Me.tdbgD, Me.C1ContextMenu)
        Me.tdbgD.ColumnFooters = true
        Me.tdbgD.EmptyRows = true
        Me.tdbgD.ExtendRightColumn = true
        Me.tdbgD.FilterBar = true
        Me.tdbgD.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbgD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbgD.Images.Add(CType(resources.GetObject("tdbgD.Images"),System.Drawing.Image))
        Me.tdbgD.Location = New System.Drawing.Point(2, 32)
        Me.tdbgD.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbgD.Name = "tdbgD"
        Me.tdbgD.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbgD.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbgD.PreviewInfo.ZoomFactor = 75R
        Me.tdbgD.PrintInfo.PageSettings = CType(resources.GetObject("tdbgD.PrintInfo.PageSettings"),System.Drawing.Printing.PageSettings)
        Me.tdbgD.Size = New System.Drawing.Size(1005, 310)
        Me.tdbgD.SplitDividerSize = New System.Drawing.Size(1, 1)
        Me.tdbgD.TabAcrossSplits = true
        Me.tdbgD.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbgD.TabIndex = 11
        Me.tdbgD.Tag = "sCOLD"
        Me.tdbgD.PropBag = resources.GetString("tdbgD.PropBag")
        '
        'tdbgM
        '
        Me.tdbgM.AllowColMove = false
        Me.tdbgM.AllowColSelect = false
        Me.tdbgM.AllowFilter = false
        Me.tdbgM.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbgM.AllowSort = false
        Me.tdbgM.AlternatingRows = true
        Me.tdbgM.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.C1CommandHolder.SetC1ContextMenu(Me.tdbgM, Me.C1ContextMenu)
        Me.tdbgM.ColumnFooters = true
        Me.tdbgM.EmptyRows = true
        Me.tdbgM.ExtendRightColumn = true
        Me.tdbgM.FilterBar = true
        Me.tdbgM.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbgM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbgM.Images.Add(CType(resources.GetObject("tdbgM.Images"),System.Drawing.Image))
        Me.tdbgM.Location = New System.Drawing.Point(2, 2)
        Me.tdbgM.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbgM.Name = "tdbgM"
        Me.tdbgM.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbgM.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbgM.PreviewInfo.ZoomFactor = 75R
        Me.tdbgM.PrintInfo.PageSettings = CType(resources.GetObject("tdbgM.PrintInfo.PageSettings"),System.Drawing.Printing.PageSettings)
        Me.tdbgM.Size = New System.Drawing.Size(1005, 228)
        Me.tdbgM.TabAcrossSplits = true
        Me.tdbgM.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbgM.TabIndex = 8
        Me.tdbgM.Tag = "COLM"
        Me.tdbgM.PropBag = resources.GetString("tdbgM.PropBag")
        '
        'btnProduction
        '
        Me.btnProduction.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnProduction.Location = New System.Drawing.Point(781, 4)
        Me.btnProduction.Name = "btnProduction"
        Me.btnProduction.Size = New System.Drawing.Size(100, 22)
        Me.btnProduction.TabIndex = 9
        Me.btnProduction.Text = "Sản xuất"
        Me.btnProduction.UseVisualStyleBackColor = true
        '
        'btnSubInfo
        '
        Me.btnSubInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnSubInfo.Location = New System.Drawing.Point(887, 4)
        Me.btnSubInfo.Name = "btnSubInfo"
        Me.btnSubInfo.Size = New System.Drawing.Size(120, 22)
        Me.btnSubInfo.TabIndex = 10
        Me.btnSubInfo.Text = "Thông tin phụ"
        Me.btnSubInfo.UseVisualStyleBackColor = true
        '
        'tdbcPeriodFrom
        '
        Me.tdbcPeriodFrom.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcPeriodFrom.AllowColMove = false
        Me.tdbcPeriodFrom.AllowSort = false
        Me.tdbcPeriodFrom.AlternatingRows = true
        Me.tdbcPeriodFrom.AutoCompletion = true
        Me.tdbcPeriodFrom.AutoDropDown = true
        Me.tdbcPeriodFrom.Caption = ""
        Me.tdbcPeriodFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcPeriodFrom.ColumnHeaders = false
        Me.tdbcPeriodFrom.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcPeriodFrom.DisplayMember = "Period"
        Me.tdbcPeriodFrom.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcPeriodFrom.DropDownWidth = 111
        Me.tdbcPeriodFrom.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcPeriodFrom.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcPeriodFrom.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcPeriodFrom.EmptyRows = true
        Me.tdbcPeriodFrom.ExtendRightColumn = true
        Me.tdbcPeriodFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcPeriodFrom.Images.Add(CType(resources.GetObject("tdbcPeriodFrom.Images"),System.Drawing.Image))
        Me.tdbcPeriodFrom.Location = New System.Drawing.Point(53, 8)
        Me.tdbcPeriodFrom.MatchEntryTimeout = CType(2000,Long)
        Me.tdbcPeriodFrom.MaxDropDownItems = CType(8,Short)
        Me.tdbcPeriodFrom.MaxLength = 32767
        Me.tdbcPeriodFrom.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcPeriodFrom.Name = "tdbcPeriodFrom"
        Me.tdbcPeriodFrom.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcPeriodFrom.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcPeriodFrom.Size = New System.Drawing.Size(111, 21)
        Me.tdbcPeriodFrom.TabIndex = 1
        Me.tdbcPeriodFrom.ValueMember = "Period"
        Me.tdbcPeriodFrom.PropBag = resources.GetString("tdbcPeriodFrom.PropBag")
        '
        'tdbcPeriodTo
        '
        Me.tdbcPeriodTo.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcPeriodTo.AllowColMove = false
        Me.tdbcPeriodTo.AllowSort = false
        Me.tdbcPeriodTo.AlternatingRows = true
        Me.tdbcPeriodTo.AutoCompletion = true
        Me.tdbcPeriodTo.AutoDropDown = true
        Me.tdbcPeriodTo.Caption = ""
        Me.tdbcPeriodTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcPeriodTo.ColumnHeaders = false
        Me.tdbcPeriodTo.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcPeriodTo.DisplayMember = "Period"
        Me.tdbcPeriodTo.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcPeriodTo.DropDownWidth = 111
        Me.tdbcPeriodTo.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcPeriodTo.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcPeriodTo.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcPeriodTo.EmptyRows = true
        Me.tdbcPeriodTo.ExtendRightColumn = true
        Me.tdbcPeriodTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcPeriodTo.Images.Add(CType(resources.GetObject("tdbcPeriodTo.Images"),System.Drawing.Image))
        Me.tdbcPeriodTo.Location = New System.Drawing.Point(198, 8)
        Me.tdbcPeriodTo.MatchEntryTimeout = CType(2000,Long)
        Me.tdbcPeriodTo.MaxDropDownItems = CType(8,Short)
        Me.tdbcPeriodTo.MaxLength = 32767
        Me.tdbcPeriodTo.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcPeriodTo.Name = "tdbcPeriodTo"
        Me.tdbcPeriodTo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcPeriodTo.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcPeriodTo.Size = New System.Drawing.Size(111, 21)
        Me.tdbcPeriodTo.TabIndex = 3
        Me.tdbcPeriodTo.ValueMember = "Period"
        Me.tdbcPeriodTo.PropBag = resources.GetString("tdbcPeriodTo.PropBag")
        '
        'lbl1
        '
        Me.lbl1.AutoSize = true
        Me.lbl1.Location = New System.Drawing.Point(174, 13)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(13, 13)
        Me.lbl1.TabIndex = 2
        Me.lbl1.Text = "_"
        Me.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCompare
        '
        Me.btnCompare.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnCompare.Location = New System.Drawing.Point(747, 628)
        Me.btnCompare.Name = "btnCompare"
        Me.btnCompare.Size = New System.Drawing.Size(95, 22)
        Me.btnCompare.TabIndex = 13
        Me.btnCompare.Text = "So sánh NCC"
        Me.btnCompare.UseVisualStyleBackColor = true
        '
        'btnContinue
        '
        Me.btnContinue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnContinue.Location = New System.Drawing.Point(658, 628)
        Me.btnContinue.Name = "btnContinue"
        Me.btnContinue.Size = New System.Drawing.Size(83, 22)
        Me.btnContinue.TabIndex = 12
        Me.btnContinue.Text = "&Tiếp tục"
        Me.btnContinue.UseVisualStyleBackColor = true
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.chkAutoSelectSupplier)
        Me.FlowLayoutPanel2.Controls.Add(Me.optSupplierAbsent)
        Me.FlowLayoutPanel2.Controls.Add(Me.optSupplierReady)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(315, 9)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(615, 22)
        Me.FlowLayoutPanel2.TabIndex = 14
        '
        'btnF12
        '
        Me.btnF12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.btnF12.Location = New System.Drawing.Point(5, 628)
        Me.btnF12.Name = "btnF12"
        Me.btnF12.Size = New System.Drawing.Size(100, 22)
        Me.btnF12.TabIndex = 17
        Me.btnF12.Text = "Hiển thị (F12)"
        Me.btnF12.UseVisualStyleBackColor = true
        '
        'C1SplitContainer1
        '
        Me.C1SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.C1SplitContainer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(240,Byte),Integer), CType(CType(240,Byte),Integer), CType(CType(240,Byte),Integer))
        Me.C1SplitContainer1.CollapsingCueColor = System.Drawing.Color.FromArgb(CType(CType(133,Byte),Integer), CType(CType(133,Byte),Integer), CType(CType(150,Byte),Integer))
        Me.C1SplitContainer1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer))
        Me.C1SplitContainer1.Location = New System.Drawing.Point(5, 40)
        Me.C1SplitContainer1.Name = "C1SplitContainer1"
        Me.C1SplitContainer1.Panels.Add(Me.C1SplitterPanel1)
        Me.C1SplitContainer1.Panels.Add(Me.C1SplitterPanel2)
        Me.C1SplitContainer1.Size = New System.Drawing.Size(1008, 582)
        Me.C1SplitContainer1.SplitterWidth = 1
        Me.C1SplitContainer1.TabIndex = 18
        '
        'C1SplitterPanel1
        '
        Me.C1SplitterPanel1.Collapsible = true
        Me.C1SplitterPanel1.Controls.Add(Me.tdbgM)
        Me.C1SplitterPanel1.Height = 238
        Me.C1SplitterPanel1.Location = New System.Drawing.Point(0, 0)
        Me.C1SplitterPanel1.Name = "C1SplitterPanel1"
        Me.C1SplitterPanel1.Size = New System.Drawing.Size(1008, 231)
        Me.C1SplitterPanel1.SizeRatio = 40.964R
        Me.C1SplitterPanel1.TabIndex = 0
        '
        'C1SplitterPanel2
        '
        Me.C1SplitterPanel2.Collapsible = true
        Me.C1SplitterPanel2.Controls.Add(Me.btnProduction)
        Me.C1SplitterPanel2.Controls.Add(Me.btnSubInfo)
        Me.C1SplitterPanel2.Controls.Add(Me.tdbgD)
        Me.C1SplitterPanel2.Height = 100
        Me.C1SplitterPanel2.Location = New System.Drawing.Point(0, 239)
        Me.C1SplitterPanel2.Name = "C1SplitterPanel2"
        Me.C1SplitterPanel2.Size = New System.Drawing.Size(1008, 343)
        Me.C1SplitterPanel2.TabIndex = 1
        '
        'D12F3030
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 655)
        Me.Controls.Add(Me.btnF12)
        Me.Controls.Add(Me.btnContinue)
        Me.Controls.Add(Me.btnCompare)
        Me.Controls.Add(Me.FlowLayoutPanel2)
        Me.Controls.Add(Me.btnChoose)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lbl1)
        Me.Controls.Add(Me.tdbcPeriodTo)
        Me.Controls.Add(Me.tdbcPeriodFrom)
        Me.Controls.Add(Me.chkShowCheckedRow)
        Me.Controls.Add(Me.btnFilter)
        Me.Controls.Add(Me.lblPeriod)
        Me.Controls.Add(Me.C1SplitContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "D12F3030"
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Løa chãn nhª cung cÊp (b§ìc 1) - D12F3030"
        CType(Me.C1CommandHolder,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tdbgD,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tdbgM,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tdbcPeriodFrom,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tdbcPeriodTo,System.ComponentModel.ISupportInitialize).EndInit
        Me.FlowLayoutPanel2.ResumeLayout(false)
        Me.FlowLayoutPanel2.PerformLayout
        CType(Me.C1SplitContainer1,System.ComponentModel.ISupportInitialize).EndInit
        Me.C1SplitContainer1.ResumeLayout(false)
        Me.C1SplitterPanel1.ResumeLayout(false)
        Me.C1SplitterPanel2.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents lblPeriod As System.Windows.Forms.Label
    Private WithEvents chkAutoSelectSupplier As System.Windows.Forms.CheckBox
    Private WithEvents optSupplierReady As System.Windows.Forms.RadioButton
    Private WithEvents optSupplierAbsent As System.Windows.Forms.RadioButton
    Private WithEvents tdbgM As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnFilter As System.Windows.Forms.Button
    Private WithEvents btnChoose As System.Windows.Forms.Button
    Private WithEvents chkShowCheckedRow As System.Windows.Forms.CheckBox
    Private WithEvents C1CommandHolder As C1.Win.C1Command.C1CommandHolder
    Private WithEvents C1ContextMenu As C1.Win.C1Command.C1ContextMenu
    Private WithEvents mnuFind As C1.Win.C1Command.C1Command
    Private WithEvents mnuListAll As C1.Win.C1Command.C1Command
    Private WithEvents tdbgD As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnSubInfo As System.Windows.Forms.Button
    Private WithEvents btnProduction As System.Windows.Forms.Button
    Private WithEvents lbl1 As System.Windows.Forms.Label
    Private WithEvents tdbcPeriodTo As C1.Win.C1List.C1Combo
    Private WithEvents tdbcPeriodFrom As C1.Win.C1List.C1Combo
    Private WithEvents btnCompare As System.Windows.Forms.Button
    Private WithEvents btnContinue As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents btnF12 As System.Windows.Forms.Button
    Friend WithEvents C1SplitContainer1 As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents C1SplitterPanel1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents C1SplitterPanel2 As C1.Win.C1SplitContainer.C1SplitterPanel

End Class