<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D12F3130
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
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D12F3130))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.tdbcInventoryID = New C1.Win.C1List.C1Combo
        Me.lblInventoryID = New System.Windows.Forms.Label
        Me.txtInventoryName = New System.Windows.Forms.TextBox
        Me.txtUnitID = New System.Windows.Forms.TextBox
        Me.lblUnitID = New System.Windows.Forms.Label
        Me.txtCQuantity = New System.Windows.Forms.TextBox
        Me.lblCQuantity = New System.Windows.Forms.Label
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        CType(Me.tdbcInventoryID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(937, 628)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 10
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(855, 628)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'tdbcInventoryID
        '
        Me.tdbcInventoryID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcInventoryID.AllowColMove = False
        Me.tdbcInventoryID.AllowSort = False
        Me.tdbcInventoryID.AlternatingRows = True
        Me.tdbcInventoryID.AutoCompletion = True
        Me.tdbcInventoryID.AutoDropDown = True
        Me.tdbcInventoryID.Caption = ""
        Me.tdbcInventoryID.CaptionHeight = 17
        Me.tdbcInventoryID.CaptionStyle = Style1
        Me.tdbcInventoryID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcInventoryID.ColumnCaptionHeight = 17
        Me.tdbcInventoryID.ColumnFooterHeight = 17
        Me.tdbcInventoryID.ColumnWidth = 100
        Me.tdbcInventoryID.ContentHeight = 17
        Me.tdbcInventoryID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcInventoryID.DisplayMember = "InventoryID"
        Me.tdbcInventoryID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcInventoryID.DropDownWidth = 300
        Me.tdbcInventoryID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcInventoryID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcInventoryID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcInventoryID.EditorHeight = 17
        Me.tdbcInventoryID.EmptyRows = True
        Me.tdbcInventoryID.EvenRowStyle = Style2
        Me.tdbcInventoryID.ExtendRightColumn = True
        Me.tdbcInventoryID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcInventoryID.FooterStyle = Style3
        Me.tdbcInventoryID.HeadingStyle = Style4
        Me.tdbcInventoryID.HighLightRowStyle = Style5
        Me.tdbcInventoryID.Images.Add(CType(resources.GetObject("tdbcInventoryID.Images"), System.Drawing.Image))
        Me.tdbcInventoryID.ItemHeight = 15
        Me.tdbcInventoryID.Location = New System.Drawing.Point(67, 9)
        Me.tdbcInventoryID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcInventoryID.MaxDropDownItems = CType(8, Short)
        Me.tdbcInventoryID.MaxLength = 32767
        Me.tdbcInventoryID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcInventoryID.Name = "tdbcInventoryID"
        Me.tdbcInventoryID.OddRowStyle = Style6
        Me.tdbcInventoryID.ReadOnly = True
        Me.tdbcInventoryID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcInventoryID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcInventoryID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcInventoryID.SelectedStyle = Style7
        Me.tdbcInventoryID.Size = New System.Drawing.Size(203, 23)
        Me.tdbcInventoryID.Style = Style8
        Me.tdbcInventoryID.TabIndex = 1
        Me.tdbcInventoryID.TabStop = False
        Me.tdbcInventoryID.ValueMember = "InventoryID"
        Me.tdbcInventoryID.PropBag = resources.GetString("tdbcInventoryID.PropBag")
        '
        'lblInventoryID
        '
        Me.lblInventoryID.AutoSize = True
        Me.lblInventoryID.Location = New System.Drawing.Point(8, 14)
        Me.lblInventoryID.Name = "lblInventoryID"
        Me.lblInventoryID.Size = New System.Drawing.Size(49, 13)
        Me.lblInventoryID.TabIndex = 0
        Me.lblInventoryID.Text = "Mã hàng"
        Me.lblInventoryID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtInventoryName
        '
        Me.txtInventoryName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtInventoryName.Location = New System.Drawing.Point(276, 9)
        Me.txtInventoryName.Name = "txtInventoryName"
        Me.txtInventoryName.ReadOnly = True
        Me.txtInventoryName.Size = New System.Drawing.Size(365, 22)
        Me.txtInventoryName.TabIndex = 2
        Me.txtInventoryName.TabStop = False
        '
        'txtUnitID
        '
        Me.txtUnitID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!)
        Me.txtUnitID.Location = New System.Drawing.Point(705, 9)
        Me.txtUnitID.Name = "txtUnitID"
        Me.txtUnitID.ReadOnly = True
        Me.txtUnitID.Size = New System.Drawing.Size(74, 22)
        Me.txtUnitID.TabIndex = 4
        Me.txtUnitID.TabStop = False
        '
        'lblUnitID
        '
        Me.lblUnitID.AutoSize = True
        Me.lblUnitID.Location = New System.Drawing.Point(662, 14)
        Me.lblUnitID.Name = "lblUnitID"
        Me.lblUnitID.Size = New System.Drawing.Size(29, 13)
        Me.lblUnitID.TabIndex = 3
        Me.lblUnitID.Text = "ĐVT"
        Me.lblUnitID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCQuantity
        '
        Me.txtCQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!)
        Me.txtCQuantity.Location = New System.Drawing.Point(872, 9)
        Me.txtCQuantity.Name = "txtCQuantity"
        Me.txtCQuantity.ReadOnly = True
        Me.txtCQuantity.Size = New System.Drawing.Size(141, 22)
        Me.txtCQuantity.TabIndex = 6
        Me.txtCQuantity.TabStop = False
        Me.txtCQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCQuantity
        '
        Me.lblCQuantity.AutoSize = True
        Me.lblCQuantity.Location = New System.Drawing.Point(795, 14)
        Me.lblCQuantity.Name = "lblCQuantity"
        Me.lblCQuantity.Size = New System.Drawing.Size(49, 13)
        Me.lblCQuantity.TabIndex = 5
        Me.lblCQuantity.Text = "Số lượng"
        Me.lblCQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tdbg
        '
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AllowSort = False
        Me.tdbg.AlternatingRows = True
        Me.tdbg.CaptionHeight = 17
        Me.tdbg.ColumnFooters = True
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(6, 43)
        Me.tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(1007, 576)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 7
        Me.tdbg.Tag = "COL"
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'D12F3130
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 655)
        Me.Controls.Add(Me.tdbg)
        Me.Controls.Add(Me.txtCQuantity)
        Me.Controls.Add(Me.txtUnitID)
        Me.Controls.Add(Me.tdbcInventoryID)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblInventoryID)
        Me.Controls.Add(Me.txtInventoryName)
        Me.Controls.Add(Me.lblUnitID)
        Me.Controls.Add(Me.lblCQuantity)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D12F3130"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chi tiÕt Kit - D12F3130"
        CType(Me.tdbcInventoryID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents tdbcInventoryID As C1.Win.C1List.C1Combo
    Private WithEvents lblInventoryID As System.Windows.Forms.Label
    Private WithEvents txtInventoryName As System.Windows.Forms.TextBox
    Private WithEvents txtUnitID As System.Windows.Forms.TextBox
    Private WithEvents lblUnitID As System.Windows.Forms.Label
    Private WithEvents txtCQuantity As System.Windows.Forms.TextBox
    Private WithEvents lblCQuantity As System.Windows.Forms.Label
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid

End Class