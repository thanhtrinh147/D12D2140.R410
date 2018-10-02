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
        mnuFindLink = New C1.Win.C1Command.C1CommandLink()
        mnuListAllLink = New C1.Win.C1Command.C1CommandLink()
        CType(Me.C1CommandHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbgD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbgM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcPeriodFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcPeriodTo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
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
        Me.btnClose.Location = New System.Drawing.Point(936, 628)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 15
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblPeriod
        '
        Me.lblPeriod.AutoSize = True
        Me.lblPeriod.Location = New System.Drawing.Point(12, 12)
        Me.lblPeriod.Name = "lblPeriod"
        Me.lblPeriod.Size = New System.Drawing.Size(19, 13)
        Me.lblPeriod.TabIndex = 0
        Me.lblPeriod.Text = "Kỳ"
        Me.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkAutoSelectSupplier
        '
        Me.chkAutoSelectSupplier.AutoSize = True
        Me.chkAutoSelectSupplier.Location = New System.Drawing.Point(3, 3)
        Me.chkAutoSelectSupplier.Name = "chkAutoSelectSupplier"
        Me.chkAutoSelectSupplier.Size = New System.Drawing.Size(180, 17)
        Me.chkAutoSelectSupplier.TabIndex = 4
        Me.chkAutoSelectSupplier.Text = "Lựa chọn nhà cung cấp tự động"
        Me.chkAutoSelectSupplier.UseVisualStyleBackColor = True
        '
        'optSupplierReady
        '
        Me.optSupplierReady.AutoSize = True
        Me.optSupplierReady.Location = New System.Drawing.Point(329, 3)
        Me.optSupplierReady.Name = "optSupplierReady"
        Me.optSupplierReady.Size = New System.Drawing.Size(123, 17)
        Me.optSupplierReady.TabIndex = 6
        Me.optSupplierReady.TabStop = True
        Me.optSupplierReady.Text = "Đã có nhà cung cấp"
        Me.optSupplierReady.UseVisualStyleBackColor = True
        '
        'optSupplierAbsent
        '
        Me.optSupplierAbsent.AutoSize = True
        Me.optSupplierAbsent.Checked = True
        Me.optSupplierAbsent.Location = New System.Drawing.Point(189, 3)
        Me.optSupplierAbsent.Name = "optSupplierAbsent"
        Me.optSupplierAbsent.Size = New System.Drawing.Size(134, 17)
        Me.optSupplierAbsent.TabIndex = 5
        Me.optSupplierAbsent.TabStop = True
        Me.optSupplierAbsent.Text = "Chưa có nhà cung cấp"
        Me.optSupplierAbsent.UseVisualStyleBackColor = True
        '
        'btnFilter
        '
        Me.btnFilter.Location = New System.Drawing.Point(936, 7)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(76, 22)
        Me.btnFilter.TabIndex = 7
        Me.btnFilter.Text = "&Lọc"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'btnChoose
        '
        Me.btnChoose.Location = New System.Drawing.Point(847, 628)
        Me.btnChoose.Name = "btnChoose"
        Me.btnChoose.Size = New System.Drawing.Size(83, 22)
        Me.btnChoose.TabIndex = 14
        Me.btnChoose.Text = "&Chọn"
        Me.btnChoose.UseVisualStyleBackColor = True
        '
        'chkShowCheckedRow
        '
        Me.chkShowCheckedRow.AutoSize = True
        Me.chkShowCheckedRow.Location = New System.Drawing.Point(148, 631)
        Me.chkShowCheckedRow.Name = "chkShowCheckedRow"
        Me.chkShowCheckedRow.Size = New System.Drawing.Size(191, 17)
        Me.chkShowCheckedRow.TabIndex = 16
        Me.chkShowCheckedRow.Text = "Chỉ hiển thị những dữ  liệu đã chọn"
        Me.chkShowCheckedRow.UseVisualStyleBackColor = True
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
        Me.tdbgD.AllowColMove = False
        Me.tdbgD.AllowColSelect = False
        Me.tdbgD.AllowFilter = False
        Me.tdbgD.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbgD.AllowSort = False
        Me.tdbgD.AlternatingRows = True
        Me.C1CommandHolder.SetC1ContextMenu(Me.tdbgD, Me.C1ContextMenu)
        Me.tdbgD.CaptionHeight = 17
        Me.tdbgD.ColumnFooters = True
        Me.tdbgD.EmptyRows = True
        Me.tdbgD.ExtendRightColumn = True
        Me.tdbgD.FilterBar = True
        Me.tdbgD.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbgD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbgD.Images.Add(CType(resources.GetObject("tdbgD.Images"), System.Drawing.Image))
        Me.tdbgD.Location = New System.Drawing.Point(3, 297)
        Me.tdbgD.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbgD.Name = "tdbgD"
        Me.tdbgD.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbgD.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbgD.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbgD.PrintInfo.PageSettings = CType(resources.GetObject("tdbgD.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbgD.RowHeight = 15
        Me.tdbgD.Size = New System.Drawing.Size(1009, 324)
        Me.tdbgD.SplitDividerSize = New System.Drawing.Size(1, 1)
        Me.tdbgD.TabAcrossSplits = True
        Me.tdbgD.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbgD.TabIndex = 11
        Me.tdbgD.Tag = "sCOLD"
        Me.tdbgD.PropBag = resources.GetString("tdbgD.PropBag")
        '
        'tdbgM
        '
        Me.tdbgM.AllowColMove = False
        Me.tdbgM.AllowColSelect = False
        Me.tdbgM.AllowFilter = False
        Me.tdbgM.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbgM.AllowSort = False
        Me.tdbgM.AlternatingRows = True
        Me.C1CommandHolder.SetC1ContextMenu(Me.tdbgM, Me.C1ContextMenu)
        Me.tdbgM.CaptionHeight = 17
        Me.tdbgM.ColumnFooters = True
        Me.tdbgM.EmptyRows = True
        Me.tdbgM.ExtendRightColumn = True
        Me.tdbgM.FilterBar = True
        Me.tdbgM.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbgM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbgM.Images.Add(CType(resources.GetObject("tdbgM.Images"), System.Drawing.Image))
        Me.tdbgM.Location = New System.Drawing.Point(3, 37)
        Me.tdbgM.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbgM.Name = "tdbgM"
        Me.tdbgM.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbgM.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbgM.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbgM.PrintInfo.PageSettings = CType(resources.GetObject("tdbgM.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbgM.RowHeight = 15
        Me.tdbgM.Size = New System.Drawing.Size(1009, 228)
        Me.tdbgM.TabAcrossSplits = True
        Me.tdbgM.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbgM.TabIndex = 8
        Me.tdbgM.Tag = "sCOLM"
        Me.tdbgM.PropBag = resources.GetString("tdbgM.PropBag")
        '
        'btnProduction
        '
        Me.btnProduction.Location = New System.Drawing.Point(797, 270)
        Me.btnProduction.Name = "btnProduction"
        Me.btnProduction.Size = New System.Drawing.Size(100, 22)
        Me.btnProduction.TabIndex = 9
        Me.btnProduction.Text = "Sản xuất"
        Me.btnProduction.UseVisualStyleBackColor = True
        '
        'btnSubInfo
        '
        Me.btnSubInfo.Location = New System.Drawing.Point(902, 270)
        Me.btnSubInfo.Name = "btnSubInfo"
        Me.btnSubInfo.Size = New System.Drawing.Size(110, 22)
        Me.btnSubInfo.TabIndex = 10
        Me.btnSubInfo.Text = "Thông tin phụ"
        Me.btnSubInfo.UseVisualStyleBackColor = True
        '
        'tdbcPeriodFrom
        '
        Me.tdbcPeriodFrom.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcPeriodFrom.AllowColMove = False
        Me.tdbcPeriodFrom.AllowSort = False
        Me.tdbcPeriodFrom.AlternatingRows = True
        Me.tdbcPeriodFrom.AutoCompletion = True
        Me.tdbcPeriodFrom.AutoDropDown = True
        Me.tdbcPeriodFrom.Caption = ""
        Me.tdbcPeriodFrom.CaptionHeight = 17
        Me.tdbcPeriodFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcPeriodFrom.ColumnCaptionHeight = 17
        Me.tdbcPeriodFrom.ColumnFooterHeight = 17
        Me.tdbcPeriodFrom.ColumnHeaders = False
        Me.tdbcPeriodFrom.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcPeriodFrom.DisplayMember = "Period"
        Me.tdbcPeriodFrom.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcPeriodFrom.DropDownWidth = 111
        Me.tdbcPeriodFrom.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcPeriodFrom.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcPeriodFrom.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcPeriodFrom.EmptyRows = True
        Me.tdbcPeriodFrom.ExtendRightColumn = True
        Me.tdbcPeriodFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcPeriodFrom.Images.Add(CType(resources.GetObject("tdbcPeriodFrom.Images"), System.Drawing.Image))
        Me.tdbcPeriodFrom.ItemHeight = 15
        Me.tdbcPeriodFrom.Location = New System.Drawing.Point(53, 7)
        Me.tdbcPeriodFrom.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcPeriodFrom.MaxDropDownItems = CType(8, Short)
        Me.tdbcPeriodFrom.MaxLength = 32767
        Me.tdbcPeriodFrom.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcPeriodFrom.Name = "tdbcPeriodFrom"
        Me.tdbcPeriodFrom.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcPeriodFrom.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcPeriodFrom.Size = New System.Drawing.Size(111, 22)
        Me.tdbcPeriodFrom.TabIndex = 1
        Me.tdbcPeriodFrom.ValueMember = "Period"
        Me.tdbcPeriodFrom.PropBag = resources.GetString("tdbcPeriodFrom.PropBag")
        '
        'tdbcPeriodTo
        '
        Me.tdbcPeriodTo.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcPeriodTo.AllowColMove = False
        Me.tdbcPeriodTo.AllowSort = False
        Me.tdbcPeriodTo.AlternatingRows = True
        Me.tdbcPeriodTo.AutoCompletion = True
        Me.tdbcPeriodTo.AutoDropDown = True
        Me.tdbcPeriodTo.Caption = ""
        Me.tdbcPeriodTo.CaptionHeight = 17
        Me.tdbcPeriodTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcPeriodTo.ColumnCaptionHeight = 17
        Me.tdbcPeriodTo.ColumnFooterHeight = 17
        Me.tdbcPeriodTo.ColumnHeaders = False
        Me.tdbcPeriodTo.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcPeriodTo.DisplayMember = "Period"
        Me.tdbcPeriodTo.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcPeriodTo.DropDownWidth = 111
        Me.tdbcPeriodTo.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcPeriodTo.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcPeriodTo.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcPeriodTo.EmptyRows = True
        Me.tdbcPeriodTo.ExtendRightColumn = True
        Me.tdbcPeriodTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcPeriodTo.Images.Add(CType(resources.GetObject("tdbcPeriodTo.Images"), System.Drawing.Image))
        Me.tdbcPeriodTo.ItemHeight = 15
        Me.tdbcPeriodTo.Location = New System.Drawing.Point(198, 7)
        Me.tdbcPeriodTo.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcPeriodTo.MaxDropDownItems = CType(8, Short)
        Me.tdbcPeriodTo.MaxLength = 32767
        Me.tdbcPeriodTo.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcPeriodTo.Name = "tdbcPeriodTo"
        Me.tdbcPeriodTo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcPeriodTo.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcPeriodTo.Size = New System.Drawing.Size(111, 22)
        Me.tdbcPeriodTo.TabIndex = 3
        Me.tdbcPeriodTo.ValueMember = "Period"
        Me.tdbcPeriodTo.PropBag = resources.GetString("tdbcPeriodTo.PropBag")
        '
        'lbl1
        '
        Me.lbl1.AutoSize = True
        Me.lbl1.Location = New System.Drawing.Point(174, 7)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(13, 13)
        Me.lbl1.TabIndex = 2
        Me.lbl1.Text = "_"
        Me.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCompare
        '
        Me.btnCompare.Location = New System.Drawing.Point(758, 628)
        Me.btnCompare.Name = "btnCompare"
        Me.btnCompare.Size = New System.Drawing.Size(83, 22)
        Me.btnCompare.TabIndex = 13
        Me.btnCompare.Text = "So sánh NCC"
        Me.btnCompare.UseVisualStyleBackColor = True
        '
        'btnContinue
        '
        Me.btnContinue.Location = New System.Drawing.Point(669, 628)
        Me.btnContinue.Name = "btnContinue"
        Me.btnContinue.Size = New System.Drawing.Size(83, 22)
        Me.btnContinue.TabIndex = 12
        Me.btnContinue.Text = "&Tiếp tục"
        Me.btnContinue.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.chkAutoSelectSupplier)
        Me.FlowLayoutPanel2.Controls.Add(Me.optSupplierAbsent)
        Me.FlowLayoutPanel2.Controls.Add(Me.optSupplierReady)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(315, 7)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(615, 22)
        Me.FlowLayoutPanel2.TabIndex = 14
        '
        'btnF12
        '
        Me.btnF12.Location = New System.Drawing.Point(3, 628)
        Me.btnF12.Name = "btnF12"
        Me.btnF12.Size = New System.Drawing.Size(100, 22)
        Me.btnF12.TabIndex = 17
        Me.btnF12.Text = "Hiển thị (F12)"
        Me.btnF12.UseVisualStyleBackColor = True
        '
        'D12F3030
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
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
        Me.Controls.Add(Me.btnSubInfo)
        Me.Controls.Add(Me.btnProduction)
        Me.Controls.Add(Me.tdbgD)
        Me.Controls.Add(Me.chkShowCheckedRow)
        Me.Controls.Add(Me.btnFilter)
        Me.Controls.Add(Me.tdbgM)
        Me.Controls.Add(Me.lblPeriod)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D12F3030"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Løa chãn nhª cung cÊp (b§ìc 1) - D12F3030"
        CType(Me.C1CommandHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbgD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbgM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcPeriodFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcPeriodTo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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

End Class