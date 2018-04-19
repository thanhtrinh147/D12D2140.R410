<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D12F3100
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D12F3100))
        Me.btnClose = New System.Windows.Forms.Button()
        Me.tdbcObjectTypeID = New C1.Win.C1List.C1Combo()
        Me.lblObjectTypeID = New System.Windows.Forms.Label()
        Me.tdbcObjectID = New C1.Win.C1List.C1Combo()
        Me.txtObjectName = New System.Windows.Forms.TextBox()
        Me.grpSupplier = New System.Windows.Forms.GroupBox()
        Me.optCTCT = New System.Windows.Forms.RadioButton()
        Me.optYCMH = New System.Windows.Forms.RadioButton()
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnsCreateVoucher = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnsCreateAvailableContract = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnsCreateContract = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnsCreateRequisition = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnsCreateContractD06 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator_Find = New System.Windows.Forms.ToolStripSeparator()
        Me.mnsFind = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnsListAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.chkIsAuto = New System.Windows.Forms.CheckBox()
        Me.btnF12 = New System.Windows.Forms.Button()
        Me.chkIsShowVoucherOver = New System.Windows.Forms.CheckBox()
        Me.btnFilter = New System.Windows.Forms.Button()
        CType(Me.tdbcObjectTypeID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcObjectID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSupplier.SuspendLayout()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(934, 628)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
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
        Me.tdbcObjectTypeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcObjectTypeID.ColumnWidth = 100
        Me.tdbcObjectTypeID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcObjectTypeID.DisplayMember = "ObjectTypeID"
        Me.tdbcObjectTypeID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcObjectTypeID.DropDownWidth = 300
        Me.tdbcObjectTypeID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcObjectTypeID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcObjectTypeID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcObjectTypeID.EmptyRows = True
        Me.tdbcObjectTypeID.ExtendRightColumn = True
        Me.tdbcObjectTypeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcObjectTypeID.Images.Add(CType(resources.GetObject("tdbcObjectTypeID.Images"), System.Drawing.Image))
        Me.tdbcObjectTypeID.Location = New System.Drawing.Point(140, 17)
        Me.tdbcObjectTypeID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcObjectTypeID.MaxDropDownItems = CType(8, Short)
        Me.tdbcObjectTypeID.MaxLength = 32767
        Me.tdbcObjectTypeID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcObjectTypeID.Name = "tdbcObjectTypeID"
        Me.tdbcObjectTypeID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcObjectTypeID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcObjectTypeID.Size = New System.Drawing.Size(128, 21)
        Me.tdbcObjectTypeID.TabIndex = 1
        Me.tdbcObjectTypeID.ValueMember = "ObjectTypeID"
        Me.tdbcObjectTypeID.PropBag = resources.GetString("tdbcObjectTypeID.PropBag")
        '
        'lblObjectTypeID
        '
        Me.lblObjectTypeID.AutoSize = True
        Me.lblObjectTypeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObjectTypeID.Location = New System.Drawing.Point(21, 22)
        Me.lblObjectTypeID.Name = "lblObjectTypeID"
        Me.lblObjectTypeID.Size = New System.Drawing.Size(75, 13)
        Me.lblObjectTypeID.TabIndex = 0
        Me.lblObjectTypeID.Text = "Nhà cung cấp"
        Me.lblObjectTypeID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tdbcObjectID
        '
        Me.tdbcObjectID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcObjectID.AllowColMove = False
        Me.tdbcObjectID.AllowSort = False
        Me.tdbcObjectID.AlternatingRows = True
        Me.tdbcObjectID.AutoCompletion = True
        Me.tdbcObjectID.AutoDropDown = True
        Me.tdbcObjectID.Caption = ""
        Me.tdbcObjectID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcObjectID.ColumnWidth = 100
        Me.tdbcObjectID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcObjectID.DisplayMember = "ObjectID"
        Me.tdbcObjectID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcObjectID.DropDownWidth = 300
        Me.tdbcObjectID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcObjectID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcObjectID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcObjectID.EmptyRows = True
        Me.tdbcObjectID.ExtendRightColumn = True
        Me.tdbcObjectID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcObjectID.Images.Add(CType(resources.GetObject("tdbcObjectID.Images"), System.Drawing.Image))
        Me.tdbcObjectID.Location = New System.Drawing.Point(274, 17)
        Me.tdbcObjectID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcObjectID.MaxDropDownItems = CType(8, Short)
        Me.tdbcObjectID.MaxLength = 32767
        Me.tdbcObjectID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcObjectID.Name = "tdbcObjectID"
        Me.tdbcObjectID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcObjectID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcObjectID.Size = New System.Drawing.Size(128, 21)
        Me.tdbcObjectID.TabIndex = 2
        Me.tdbcObjectID.ValueMember = "ObjectID"
        Me.tdbcObjectID.PropBag = resources.GetString("tdbcObjectID.PropBag")
        '
        'txtObjectName
        '
        Me.txtObjectName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtObjectName.Location = New System.Drawing.Point(408, 17)
        Me.txtObjectName.Name = "txtObjectName"
        Me.txtObjectName.ReadOnly = True
        Me.txtObjectName.Size = New System.Drawing.Size(590, 20)
        Me.txtObjectName.TabIndex = 3
        Me.txtObjectName.TabStop = False
        '
        'grpSupplier
        '
        Me.grpSupplier.Controls.Add(Me.txtObjectName)
        Me.grpSupplier.Controls.Add(Me.tdbcObjectID)
        Me.grpSupplier.Controls.Add(Me.lblObjectTypeID)
        Me.grpSupplier.Controls.Add(Me.tdbcObjectTypeID)
        Me.grpSupplier.Location = New System.Drawing.Point(6, 1)
        Me.grpSupplier.Name = "grpSupplier"
        Me.grpSupplier.Size = New System.Drawing.Size(1004, 49)
        Me.grpSupplier.TabIndex = 0
        Me.grpSupplier.TabStop = False
        '
        'optCTCT
        '
        Me.optCTCT.AutoSize = True
        Me.optCTCT.Location = New System.Drawing.Point(414, 59)
        Me.optCTCT.Name = "optCTCT"
        Me.optCTCT.Size = New System.Drawing.Size(131, 17)
        Me.optCTCT.TabIndex = 3
        Me.optCTCT.Text = "Chấp thuận chọn thầu"
        Me.optCTCT.UseVisualStyleBackColor = True
        '
        'optYCMH
        '
        Me.optYCMH.AutoSize = True
        Me.optYCMH.Checked = True
        Me.optYCMH.Location = New System.Drawing.Point(245, 59)
        Me.optYCMH.Name = "optYCMH"
        Me.optYCMH.Size = New System.Drawing.Size(115, 17)
        Me.optYCMH.TabIndex = 2
        Me.optYCMH.TabStop = True
        Me.optYCMH.Text = "Yêu cầu mua hàng"
        Me.optYCMH.UseVisualStyleBackColor = True
        '
        'tdbg
        '
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowFilter = False
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AllowSort = False
        Me.tdbg.AlternatingRows = True
        Me.tdbg.ColumnFooters = True
        Me.tdbg.ContextMenuStrip = Me.ContextMenuStrip1
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FilterBar = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(6, 85)
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.Size = New System.Drawing.Size(1004, 534)
        Me.tdbg.SplitDividerSize = New System.Drawing.Size(1, 1)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 5
        Me.tdbg.Tag = "sCOL"
        Me.tdbg.WrapCellPointer = True
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnsCreateVoucher, Me.mnsCreateAvailableContract, Me.ToolStripSeparator1, Me.mnsCreateContract, Me.ToolStripSeparator2, Me.mnsCreateRequisition, Me.ToolStripSeparator3, Me.mnsCreateContractD06, Me.ToolStripSeparator_Find, Me.mnsFind, Me.mnsListAll})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(294, 204)
        '
        'mnsCreateVoucher
        '
        Me.mnsCreateVoucher.Name = "mnsCreateVoucher"
        Me.mnsCreateVoucher.Size = New System.Drawing.Size(293, 22)
        Me.mnsCreateVoucher.Text = "Lập đơn hàng"
        '
        'mnsCreateAvailableContract
        '
        Me.mnsCreateAvailableContract.Name = "mnsCreateAvailableContract"
        Me.mnsCreateAvailableContract.Size = New System.Drawing.Size(293, 22)
        Me.mnsCreateAvailableContract.Text = "Lập hợp đồng mua hàng"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(290, 6)
        '
        'mnsCreateContract
        '
        Me.mnsCreateContract.Name = "mnsCreateContract"
        Me.mnsCreateContract.Size = New System.Drawing.Size(293, 22)
        Me.mnsCreateContract.Text = "Lập hợp đồng mua hàng (chuyên ngành BĐS)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(290, 6)
        '
        'mnsCreateRequisition
        '
        Me.mnsCreateRequisition.Name = "mnsCreateRequisition"
        Me.mnsCreateRequisition.Size = New System.Drawing.Size(293, 22)
        Me.mnsCreateRequisition.Text = "Lập hợp đồng khung mua hàng"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(290, 6)
        '
        'mnsCreateContractD06
        '
        Me.mnsCreateContractD06.Name = "mnsCreateContractD06"
        Me.mnsCreateContractD06.Size = New System.Drawing.Size(293, 22)
        Me.mnsCreateContractD06.Text = "Lập hợp đồng mua hàng (D06)"
        '
        'ToolStripSeparator_Find
        '
        Me.ToolStripSeparator_Find.Name = "ToolStripSeparator_Find"
        Me.ToolStripSeparator_Find.Size = New System.Drawing.Size(290, 6)
        '
        'mnsFind
        '
        Me.mnsFind.Name = "mnsFind"
        Me.mnsFind.Size = New System.Drawing.Size(293, 22)
        Me.mnsFind.Text = "Tìm &kiếm"
        '
        'mnsListAll
        '
        Me.mnsListAll.Name = "mnsListAll"
        Me.mnsListAll.Size = New System.Drawing.Size(293, 22)
        Me.mnsListAll.Text = "&Liệt kê tất cả"
        '
        'chkIsAuto
        '
        Me.chkIsAuto.AutoSize = True
        Me.chkIsAuto.Location = New System.Drawing.Point(108, 631)
        Me.chkIsAuto.Name = "chkIsAuto"
        Me.chkIsAuto.Size = New System.Drawing.Size(140, 17)
        Me.chkIsAuto.TabIndex = 8
        Me.chkIsAuto.Text = "Lập đơn hàng hàng loạt"
        Me.chkIsAuto.UseVisualStyleBackColor = True
        '
        'btnF12
        '
        Me.btnF12.Location = New System.Drawing.Point(6, 628)
        Me.btnF12.Name = "btnF12"
        Me.btnF12.Size = New System.Drawing.Size(96, 22)
        Me.btnF12.TabIndex = 7
        Me.btnF12.Text = "Hiển thị"
        Me.btnF12.UseVisualStyleBackColor = True
        '
        'chkIsShowVoucherOver
        '
        Me.chkIsShowVoucherOver.AutoSize = True
        Me.chkIsShowVoucherOver.Location = New System.Drawing.Point(6, 59)
        Me.chkIsShowVoucherOver.Name = "chkIsShowVoucherOver"
        Me.chkIsShowVoucherOver.Size = New System.Drawing.Size(172, 17)
        Me.chkIsShowVoucherOver.TabIndex = 1
        Me.chkIsShowVoucherOver.Text = "Hiển thị phiếu đã thực hiện hết"
        Me.chkIsShowVoucherOver.UseVisualStyleBackColor = True
        '
        'btnFilter
        '
        Me.btnFilter.Location = New System.Drawing.Point(934, 56)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(76, 22)
        Me.btnFilter.TabIndex = 4
        Me.btnFilter.Text = "Lọc"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'D12F3100
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 655)
        Me.Controls.Add(Me.btnFilter)
        Me.Controls.Add(Me.chkIsShowVoucherOver)
        Me.Controls.Add(Me.optCTCT)
        Me.Controls.Add(Me.optYCMH)
        Me.Controls.Add(Me.tdbg)
        Me.Controls.Add(Me.btnF12)
        Me.Controls.Add(Me.chkIsAuto)
        Me.Controls.Add(Me.grpSupplier)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D12F3100"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Thøc hiÖn y£u cÇu mua hªng - D12F3100"
        CType(Me.tdbcObjectTypeID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcObjectID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSupplier.ResumeLayout(False)
        Me.grpSupplier.PerformLayout()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents tdbcObjectTypeID As C1.Win.C1List.C1Combo
    Private WithEvents lblObjectTypeID As System.Windows.Forms.Label
    Private WithEvents tdbcObjectID As C1.Win.C1List.C1Combo
    Private WithEvents txtObjectName As System.Windows.Forms.TextBox
    Private WithEvents grpSupplier As System.Windows.Forms.GroupBox
    Private WithEvents chkIsAuto As System.Windows.Forms.CheckBox
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnF12 As System.Windows.Forms.Button
    Private WithEvents optYCMH As System.Windows.Forms.RadioButton
    Private WithEvents optCTCT As System.Windows.Forms.RadioButton
    Private WithEvents chkIsShowVoucherOver As System.Windows.Forms.CheckBox
    Private WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Private WithEvents mnsCreateVoucher As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnsCreateAvailableContract As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnsCreateContract As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnsCreateRequisition As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripSeparator_Find As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnsFind As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnsListAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnsCreateContractD06 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents btnFilter As System.Windows.Forms.Button

End Class