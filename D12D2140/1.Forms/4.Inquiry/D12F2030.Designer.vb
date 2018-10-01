<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D12F2030
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D12F2030))
        Me.tdbcPeriodIDFrom = New C1.Win.C1List.C1Combo()
        Me.tdbcPeriodIDTo = New C1.Win.C1List.C1Combo()
        Me.c1dateFrom = New C1.Win.C1Input.C1DateEdit()
        Me.c1dateTo = New C1.Win.C1Input.C1DateEdit()
        Me.optPeriod = New System.Windows.Forms.RadioButton()
        Me.optDate = New System.Windows.Forms.RadioButton()
        Me.lblDash1 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tdbcObjectTypeID = New C1.Win.C1List.C1Combo()
        Me.tdbcObjectID = New C1.Win.C1List.C1Combo()
        Me.lblObjectID = New System.Windows.Forms.Label()
        Me.txtObjectName = New System.Windows.Forms.TextBox()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnsDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator_Find = New System.Windows.Forms.ToolStripSeparator()
        Me.mnsFind = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnsListAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator_SysInfo = New System.Windows.Forms.ToolStripSeparator()
        Me.mnsSysInfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.grp1 = New System.Windows.Forms.GroupBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbFind = New System.Windows.Forms.ToolStripButton()
        Me.tsbListAll = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSysInfo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbClose = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsdActive = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator_DFind = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmFind = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmListAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator_DSysInfo = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmSysInfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnF12 = New System.Windows.Forms.Button()
        Me.lblTaskbar = New System.Windows.Forms.Label()
        CType(Me.tdbcPeriodIDFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcPeriodIDTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.c1dateFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.c1dateTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcObjectTypeID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcObjectID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.grp1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tdbcPeriodIDFrom
        '
        Me.tdbcPeriodIDFrom.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcPeriodIDFrom.AllowColMove = False
        Me.tdbcPeriodIDFrom.AllowSort = False
        Me.tdbcPeriodIDFrom.AlternatingRows = True
        Me.tdbcPeriodIDFrom.AutoCompletion = True
        Me.tdbcPeriodIDFrom.AutoDropDown = True
        Me.tdbcPeriodIDFrom.Caption = ""
        Me.tdbcPeriodIDFrom.CaptionHeight = 17
        Me.tdbcPeriodIDFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcPeriodIDFrom.ColumnCaptionHeight = 17
        Me.tdbcPeriodIDFrom.ColumnFooterHeight = 17
        Me.tdbcPeriodIDFrom.ColumnHeaders = False
        Me.tdbcPeriodIDFrom.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcPeriodIDFrom.DisplayMember = "Period"
        Me.tdbcPeriodIDFrom.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcPeriodIDFrom.DropDownWidth = 124
        Me.tdbcPeriodIDFrom.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcPeriodIDFrom.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcPeriodIDFrom.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcPeriodIDFrom.EmptyRows = True
        Me.tdbcPeriodIDFrom.ExtendRightColumn = True
        Me.tdbcPeriodIDFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcPeriodIDFrom.Images.Add(CType(resources.GetObject("tdbcPeriodIDFrom.Images"), System.Drawing.Image))
        Me.tdbcPeriodIDFrom.ItemHeight = 15
        Me.tdbcPeriodIDFrom.Location = New System.Drawing.Point(77, 16)
        Me.tdbcPeriodIDFrom.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcPeriodIDFrom.MaxDropDownItems = CType(8, Short)
        Me.tdbcPeriodIDFrom.MaxLength = 32767
        Me.tdbcPeriodIDFrom.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcPeriodIDFrom.Name = "tdbcPeriodIDFrom"
        Me.tdbcPeriodIDFrom.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcPeriodIDFrom.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcPeriodIDFrom.Size = New System.Drawing.Size(124, 22)
        Me.tdbcPeriodIDFrom.TabIndex = 1
        Me.tdbcPeriodIDFrom.ValueMember = "Period"
        Me.tdbcPeriodIDFrom.PropBag = resources.GetString("tdbcPeriodIDFrom.PropBag")
        '
        'tdbcPeriodIDTo
        '
        Me.tdbcPeriodIDTo.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcPeriodIDTo.AllowColMove = False
        Me.tdbcPeriodIDTo.AllowSort = False
        Me.tdbcPeriodIDTo.AlternatingRows = True
        Me.tdbcPeriodIDTo.AutoCompletion = True
        Me.tdbcPeriodIDTo.AutoDropDown = True
        Me.tdbcPeriodIDTo.Caption = ""
        Me.tdbcPeriodIDTo.CaptionHeight = 17
        Me.tdbcPeriodIDTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcPeriodIDTo.ColumnCaptionHeight = 17
        Me.tdbcPeriodIDTo.ColumnFooterHeight = 17
        Me.tdbcPeriodIDTo.ColumnHeaders = False
        Me.tdbcPeriodIDTo.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcPeriodIDTo.DisplayMember = "Period"
        Me.tdbcPeriodIDTo.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcPeriodIDTo.DropDownWidth = 124
        Me.tdbcPeriodIDTo.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcPeriodIDTo.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcPeriodIDTo.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcPeriodIDTo.EmptyRows = True
        Me.tdbcPeriodIDTo.ExtendRightColumn = True
        Me.tdbcPeriodIDTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcPeriodIDTo.Images.Add(CType(resources.GetObject("tdbcPeriodIDTo.Images"), System.Drawing.Image))
        Me.tdbcPeriodIDTo.ItemHeight = 15
        Me.tdbcPeriodIDTo.Location = New System.Drawing.Point(222, 16)
        Me.tdbcPeriodIDTo.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcPeriodIDTo.MaxDropDownItems = CType(8, Short)
        Me.tdbcPeriodIDTo.MaxLength = 32767
        Me.tdbcPeriodIDTo.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcPeriodIDTo.Name = "tdbcPeriodIDTo"
        Me.tdbcPeriodIDTo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcPeriodIDTo.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcPeriodIDTo.Size = New System.Drawing.Size(124, 22)
        Me.tdbcPeriodIDTo.TabIndex = 3
        Me.tdbcPeriodIDTo.ValueMember = "Period"
        Me.tdbcPeriodIDTo.PropBag = resources.GetString("tdbcPeriodIDTo.PropBag")
        '
        'c1dateFrom
        '
        Me.c1dateFrom.AutoSize = False
        Me.c1dateFrom.CustomFormat = "dd/MM/yyyy"
        Me.c1dateFrom.EmptyAsNull = True
        Me.c1dateFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.c1dateFrom.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.c1dateFrom.Location = New System.Drawing.Point(78, 45)
        Me.c1dateFrom.Name = "c1dateFrom"
        Me.c1dateFrom.Size = New System.Drawing.Size(123, 22)
        Me.c1dateFrom.TabIndex = 5
        Me.c1dateFrom.Tag = Nothing
        Me.c1dateFrom.TrimStart = True
        Me.c1dateFrom.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'c1dateTo
        '
        Me.c1dateTo.AutoSize = False
        Me.c1dateTo.CustomFormat = "dd/MM/yyyy"
        Me.c1dateTo.EmptyAsNull = True
        Me.c1dateTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.c1dateTo.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.c1dateTo.Location = New System.Drawing.Point(222, 45)
        Me.c1dateTo.Name = "c1dateTo"
        Me.c1dateTo.Size = New System.Drawing.Size(124, 22)
        Me.c1dateTo.TabIndex = 7
        Me.c1dateTo.Tag = Nothing
        Me.c1dateTo.TrimStart = True
        Me.c1dateTo.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'optPeriod
        '
        Me.optPeriod.AutoSize = True
        Me.optPeriod.Location = New System.Drawing.Point(9, 18)
        Me.optPeriod.Name = "optPeriod"
        Me.optPeriod.Size = New System.Drawing.Size(37, 17)
        Me.optPeriod.TabIndex = 0
        Me.optPeriod.TabStop = True
        Me.optPeriod.Text = "Kỳ"
        Me.optPeriod.UseVisualStyleBackColor = True
        '
        'optDate
        '
        Me.optDate.AutoSize = True
        Me.optDate.Location = New System.Drawing.Point(8, 49)
        Me.optDate.Name = "optDate"
        Me.optDate.Size = New System.Drawing.Size(50, 17)
        Me.optDate.TabIndex = 4
        Me.optDate.TabStop = True
        Me.optDate.Text = "Ngày"
        Me.optDate.UseVisualStyleBackColor = True
        '
        'lblDash1
        '
        Me.lblDash1.AutoSize = True
        Me.lblDash1.Location = New System.Drawing.Point(205, 16)
        Me.lblDash1.Name = "lblDash1"
        Me.lblDash1.Size = New System.Drawing.Size(13, 13)
        Me.lblDash1.TabIndex = 2
        Me.lblDash1.Text = "_"
        Me.lblDash1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(205, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(13, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "_"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tdbcObjectTypeID
        '
        Me.tdbcObjectTypeID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcObjectTypeID.AllowColMove = False
        Me.tdbcObjectTypeID.AllowSort = False
        Me.tdbcObjectTypeID.AlternatingRows = True
        Me.tdbcObjectTypeID.AutoCompletion = True
        Me.tdbcObjectTypeID.AutoDropDown = True
        Me.tdbcObjectTypeID.Caption = ""
        Me.tdbcObjectTypeID.CaptionHeight = 17
        Me.tdbcObjectTypeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcObjectTypeID.ColumnCaptionHeight = 17
        Me.tdbcObjectTypeID.ColumnFooterHeight = 17
        Me.tdbcObjectTypeID.ColumnWidth = 100
        Me.tdbcObjectTypeID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcObjectTypeID.DisplayMember = "ObjectTypeID"
        Me.tdbcObjectTypeID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcObjectTypeID.DropDownWidth = 400
        Me.tdbcObjectTypeID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcObjectTypeID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcObjectTypeID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcObjectTypeID.EmptyRows = True
        Me.tdbcObjectTypeID.ExtendRightColumn = True
        Me.tdbcObjectTypeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcObjectTypeID.Images.Add(CType(resources.GetObject("tdbcObjectTypeID.Images"), System.Drawing.Image))
        Me.tdbcObjectTypeID.ItemHeight = 15
        Me.tdbcObjectTypeID.Location = New System.Drawing.Point(435, 16)
        Me.tdbcObjectTypeID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcObjectTypeID.MaxDropDownItems = CType(8, Short)
        Me.tdbcObjectTypeID.MaxLength = 32767
        Me.tdbcObjectTypeID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcObjectTypeID.Name = "tdbcObjectTypeID"
        Me.tdbcObjectTypeID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcObjectTypeID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcObjectTypeID.Size = New System.Drawing.Size(94, 22)
        Me.tdbcObjectTypeID.TabIndex = 9
        Me.tdbcObjectTypeID.ValueMember = "ObjectTypeID"
        Me.tdbcObjectTypeID.PropBag = resources.GetString("tdbcObjectTypeID.PropBag")
        '
        'tdbcObjectID
        '
        Me.tdbcObjectID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcObjectID.AllowColMove = False
        Me.tdbcObjectID.AllowColSelect = True
        Me.tdbcObjectID.AllowSort = False
        Me.tdbcObjectID.AlternatingRows = True
        Me.tdbcObjectID.AutoCompletion = True
        Me.tdbcObjectID.AutoDropDown = True
        Me.tdbcObjectID.Caption = ""
        Me.tdbcObjectID.CaptionHeight = 17
        Me.tdbcObjectID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcObjectID.ColumnCaptionHeight = 17
        Me.tdbcObjectID.ColumnFooterHeight = 17
        Me.tdbcObjectID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcObjectID.DisplayMember = "ObjectID"
        Me.tdbcObjectID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcObjectID.DropDownWidth = 600
        Me.tdbcObjectID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcObjectID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcObjectID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcObjectID.EmptyRows = True
        Me.tdbcObjectID.ExtendRightColumn = True
        Me.tdbcObjectID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcObjectID.Images.Add(CType(resources.GetObject("tdbcObjectID.Images"), System.Drawing.Image))
        Me.tdbcObjectID.ItemHeight = 15
        Me.tdbcObjectID.Location = New System.Drawing.Point(533, 16)
        Me.tdbcObjectID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcObjectID.MaxDropDownItems = CType(8, Short)
        Me.tdbcObjectID.MaxLength = 32767
        Me.tdbcObjectID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcObjectID.Name = "tdbcObjectID"
        Me.tdbcObjectID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcObjectID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcObjectID.Size = New System.Drawing.Size(143, 22)
        Me.tdbcObjectID.TabIndex = 10
        Me.tdbcObjectID.ValueMember = "ObjectID"
        Me.tdbcObjectID.PropBag = resources.GetString("tdbcObjectID.PropBag")
        '
        'lblObjectID
        '
        Me.lblObjectID.AutoSize = True
        Me.lblObjectID.Location = New System.Drawing.Point(356, 20)
        Me.lblObjectID.Name = "lblObjectID"
        Me.lblObjectID.Size = New System.Drawing.Size(53, 13)
        Me.lblObjectID.TabIndex = 8
        Me.lblObjectID.Text = "Đối tượng"
        Me.lblObjectID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtObjectName
        '
        Me.txtObjectName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtObjectName.Location = New System.Drawing.Point(680, 16)
        Me.txtObjectName.Name = "txtObjectName"
        Me.txtObjectName.ReadOnly = True
        Me.txtObjectName.Size = New System.Drawing.Size(316, 21)
        Me.txtObjectName.TabIndex = 11
        Me.txtObjectName.TabStop = False
        '
        'btnFilter
        '
        Me.btnFilter.Location = New System.Drawing.Point(923, 44)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(73, 22)
        Me.btnFilter.TabIndex = 12
        Me.btnFilter.Text = "Lọc"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'tdbg
        '
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowDelete = True
        Me.tdbg.AllowFilter = False
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AlternatingRows = True
        Me.tdbg.CaptionHeight = 17
        Me.tdbg.ColumnFooters = True
        Me.tdbg.ContextMenuStrip = Me.ContextMenuStrip1
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FilterBar = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(3, 110)
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(1012, 516)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 2
        Me.tdbg.Tag = "COL"
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(18, 18)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnsDelete, Me.ToolStripSeparator_Find, Me.mnsFind, Me.mnsListAll, Me.ToolStripSeparator_SysInfo, Me.mnsSysInfo})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(188, 104)
        '
        'mnsDelete
        '
        Me.mnsDelete.Name = "mnsDelete"
        Me.mnsDelete.Size = New System.Drawing.Size(187, 22)
        Me.mnsDelete.Text = "&Xóa"
        '
        'ToolStripSeparator_Find
        '
        Me.ToolStripSeparator_Find.Name = "ToolStripSeparator_Find"
        Me.ToolStripSeparator_Find.Size = New System.Drawing.Size(184, 6)
        '
        'mnsFind
        '
        Me.mnsFind.Name = "mnsFind"
        Me.mnsFind.Size = New System.Drawing.Size(187, 22)
        Me.mnsFind.Text = "Tìm &kiếm"
        '
        'mnsListAll
        '
        Me.mnsListAll.Name = "mnsListAll"
        Me.mnsListAll.Size = New System.Drawing.Size(187, 22)
        Me.mnsListAll.Text = "&Liệt kê tất cả"
        '
        'ToolStripSeparator_SysInfo
        '
        Me.ToolStripSeparator_SysInfo.Name = "ToolStripSeparator_SysInfo"
        Me.ToolStripSeparator_SysInfo.Size = New System.Drawing.Size(184, 6)
        '
        'mnsSysInfo
        '
        Me.mnsSysInfo.Name = "mnsSysInfo"
        Me.mnsSysInfo.Size = New System.Drawing.Size(187, 22)
        Me.mnsSysInfo.Text = "Thông tin &hệ thống"
        '
        'grp1
        '
        Me.grp1.Controls.Add(Me.tdbcObjectTypeID)
        Me.grp1.Controls.Add(Me.txtObjectName)
        Me.grp1.Controls.Add(Me.lblObjectID)
        Me.grp1.Controls.Add(Me.btnFilter)
        Me.grp1.Controls.Add(Me.tdbcObjectID)
        Me.grp1.Controls.Add(Me.tdbcPeriodIDFrom)
        Me.grp1.Controls.Add(Me.tdbcPeriodIDTo)
        Me.grp1.Controls.Add(Me.Label1)
        Me.grp1.Controls.Add(Me.c1dateFrom)
        Me.grp1.Controls.Add(Me.lblDash1)
        Me.grp1.Controls.Add(Me.c1dateTo)
        Me.grp1.Controls.Add(Me.optDate)
        Me.grp1.Controls.Add(Me.optPeriod)
        Me.grp1.Location = New System.Drawing.Point(7, 26)
        Me.grp1.Name = "grp1"
        Me.grp1.Size = New System.Drawing.Size(1004, 76)
        Me.grp1.TabIndex = 1
        Me.grp1.TabStop = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(18, 18)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbDelete, Me.ToolStripSeparator1, Me.tsbFind, Me.tsbListAll, Me.ToolStripSeparator4, Me.tsbSysInfo, Me.ToolStripSeparator9, Me.tsbClose, Me.ToolStripSeparator10, Me.tsdActive})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1018, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'tsbDelete
        '
        Me.tsbDelete.Name = "tsbDelete"
        Me.tsbDelete.Size = New System.Drawing.Size(35, 22)
        Me.tsbDelete.Text = "&Xóa"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbFind
        '
        Me.tsbFind.Name = "tsbFind"
        Me.tsbFind.Size = New System.Drawing.Size(64, 22)
        Me.tsbFind.Text = "Tìm &kiếm"
        '
        'tsbListAll
        '
        Me.tsbListAll.Name = "tsbListAll"
        Me.tsbListAll.Size = New System.Drawing.Size(85, 22)
        Me.tsbListAll.Text = "&Liệt kê tất cả"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'tsbSysInfo
        '
        Me.tsbSysInfo.Name = "tsbSysInfo"
        Me.tsbSysInfo.Size = New System.Drawing.Size(123, 22)
        Me.tsbSysInfo.Text = "Thông tin &hệ thống"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'tsbClose
        '
        Me.tsbClose.Name = "tsbClose"
        Me.tsbClose.Size = New System.Drawing.Size(44, 22)
        Me.tsbClose.Text = "Đón&g"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
        '
        'tsdActive
        '
        Me.tsdActive.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmDelete, Me.ToolStripSeparator_DFind, Me.tsmFind, Me.tsmListAll, Me.ToolStripSeparator_DSysInfo, Me.tsmSysInfo})
        Me.tsdActive.Name = "tsdActive"
        Me.tsdActive.Size = New System.Drawing.Size(78, 22)
        Me.tsdActive.Text = "&Thực hiện"
        '
        'tsmDelete
        '
        Me.tsmDelete.Name = "tsmDelete"
        Me.tsmDelete.Size = New System.Drawing.Size(190, 24)
        Me.tsmDelete.Text = "&Xóa"
        '
        'ToolStripSeparator_DFind
        '
        Me.ToolStripSeparator_DFind.Name = "ToolStripSeparator_DFind"
        Me.ToolStripSeparator_DFind.Size = New System.Drawing.Size(187, 6)
        '
        'tsmFind
        '
        Me.tsmFind.Name = "tsmFind"
        Me.tsmFind.Size = New System.Drawing.Size(190, 24)
        Me.tsmFind.Text = "Tìm &kiếm"
        '
        'tsmListAll
        '
        Me.tsmListAll.Name = "tsmListAll"
        Me.tsmListAll.Size = New System.Drawing.Size(190, 24)
        Me.tsmListAll.Text = "&Liệt kê tất cả"
        '
        'ToolStripSeparator_DSysInfo
        '
        Me.ToolStripSeparator_DSysInfo.Name = "ToolStripSeparator_DSysInfo"
        Me.ToolStripSeparator_DSysInfo.Size = New System.Drawing.Size(187, 6)
        '
        'tsmSysInfo
        '
        Me.tsmSysInfo.Name = "tsmSysInfo"
        Me.tsmSysInfo.Size = New System.Drawing.Size(190, 24)
        Me.tsmSysInfo.Text = "Thông tin &hệ thống"
        '
        'btnF12
        '
        Me.btnF12.AutoSize = True
        Me.btnF12.BackColor = System.Drawing.SystemColors.Control
        Me.btnF12.FlatAppearance.BorderSize = 0
        Me.btnF12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnF12.ForeColor = System.Drawing.Color.Blue
        Me.btnF12.Location = New System.Drawing.Point(1, 634)
        Me.btnF12.Name = "btnF12"
        Me.btnF12.Size = New System.Drawing.Size(39, 23)
        Me.btnF12.TabIndex = 3
        Me.btnF12.Text = "F12"
        Me.btnF12.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnF12.UseVisualStyleBackColor = False
        '
        'lblTaskbar
        '
        Me.lblTaskbar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTaskbar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblTaskbar.ForeColor = System.Drawing.Color.Blue
        Me.lblTaskbar.Location = New System.Drawing.Point(0, 633)
        Me.lblTaskbar.Name = "lblTaskbar"
        Me.lblTaskbar.Size = New System.Drawing.Size(1018, 22)
        Me.lblTaskbar.TabIndex = 4
        Me.lblTaskbar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'D12F2030
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 655)
        Me.Controls.Add(Me.btnF12)
        Me.Controls.Add(Me.lblTaskbar)
        Me.Controls.Add(Me.tdbg)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.grp1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D12F2030"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Løa chãn nhª cung cÊp - D12F2030"
        CType(Me.tdbcPeriodIDFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcPeriodIDTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.c1dateFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.c1dateTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcObjectTypeID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcObjectID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.grp1.ResumeLayout(False)
        Me.grp1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents tdbcPeriodIDFrom As C1.Win.C1List.C1Combo
    Private WithEvents tdbcPeriodIDTo As C1.Win.C1List.C1Combo
    Private WithEvents c1dateFrom As C1.Win.C1Input.C1DateEdit
    Private WithEvents c1dateTo As C1.Win.C1Input.C1DateEdit
    Private WithEvents optPeriod As System.Windows.Forms.RadioButton
    Private WithEvents optDate As System.Windows.Forms.RadioButton
    Private WithEvents lblDash1 As System.Windows.Forms.Label
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents tdbcObjectTypeID As C1.Win.C1List.C1Combo
    Private WithEvents tdbcObjectID As C1.Win.C1List.C1Combo
    Private WithEvents lblObjectID As System.Windows.Forms.Label
    Private WithEvents txtObjectName As System.Windows.Forms.TextBox
    Private WithEvents btnFilter As System.Windows.Forms.Button
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents grp1 As System.Windows.Forms.GroupBox
    Private WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Private WithEvents mnsDelete As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripSeparator_Find As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnsFind As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnsListAll As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripSeparator_SysInfo As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnsSysInfo As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents tsbDelete As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents tsbFind As System.Windows.Forms.ToolStripButton
    Private WithEvents tsbListAll As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents tsbSysInfo As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents tsbClose As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents tsdActive As System.Windows.Forms.ToolStripDropDownButton
    Private WithEvents tsmDelete As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripSeparator_DFind As System.Windows.Forms.ToolStripSeparator
    Private WithEvents tsmFind As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents tsmListAll As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripSeparator_DSysInfo As System.Windows.Forms.ToolStripSeparator
    Private WithEvents tsmSysInfo As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents btnF12 As System.Windows.Forms.Button
    Private WithEvents lblTaskbar As System.Windows.Forms.Label

End Class