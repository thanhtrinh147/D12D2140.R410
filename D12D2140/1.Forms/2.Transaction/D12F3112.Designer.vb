<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D12F3112
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D12F3112))
        Me.txtInventoryID = New System.Windows.Forms.TextBox
        Me.lblInventoryID = New System.Windows.Forms.Label
        Me.txtTOQuantity = New System.Windows.Forms.TextBox
        Me.lblTOQuantity = New System.Windows.Forms.Label
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.btnSplit = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtInventoryID
        '
        Me.txtInventoryID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!)
        Me.txtInventoryID.Location = New System.Drawing.Point(67, 12)
        Me.txtInventoryID.Name = "txtInventoryID"
        Me.txtInventoryID.ReadOnly = True
        Me.txtInventoryID.Size = New System.Drawing.Size(240, 22)
        Me.txtInventoryID.TabIndex = 1
        '
        'lblInventoryID
        '
        Me.lblInventoryID.AutoSize = True
        Me.lblInventoryID.Location = New System.Drawing.Point(12, 16)
        Me.lblInventoryID.Name = "lblInventoryID"
        Me.lblInventoryID.Size = New System.Drawing.Size(49, 13)
        Me.lblInventoryID.TabIndex = 0
        Me.lblInventoryID.Text = "Mã hàng"
        Me.lblInventoryID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTOQuantity
        '
        Me.txtTOQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!)
        Me.txtTOQuantity.Location = New System.Drawing.Point(67, 40)
        Me.txtTOQuantity.Name = "txtTOQuantity"
        Me.txtTOQuantity.ReadOnly = True
        Me.txtTOQuantity.Size = New System.Drawing.Size(240, 22)
        Me.txtTOQuantity.TabIndex = 3
        '
        'lblTOQuantity
        '
        Me.lblTOQuantity.AutoSize = True
        Me.lblTOQuantity.Location = New System.Drawing.Point(12, 44)
        Me.lblTOQuantity.Name = "lblTOQuantity"
        Me.lblTOQuantity.Size = New System.Drawing.Size(49, 13)
        Me.lblTOQuantity.TabIndex = 2
        Me.lblTOQuantity.Text = "Số lượng"
        Me.lblTOQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tdbg
        '
        Me.tdbg.AllowAddNew = True
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowDelete = True
        Me.tdbg.AllowFilter = False
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AlternatingRows = True
        Me.tdbg.CaptionHeight = 17
        Me.tdbg.ColumnFooters = True
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(3, 68)
        Me.tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(304, 142)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabIndex = 4
        Me.tdbg.Tag = "COL"
        Me.tdbg.WrapCellPointer = True
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'btnSplit
        '
        Me.btnSplit.Location = New System.Drawing.Point(149, 216)
        Me.btnSplit.Name = "btnSplit"
        Me.btnSplit.Size = New System.Drawing.Size(76, 22)
        Me.btnSplit.TabIndex = 5
        Me.btnSplit.Text = "&Tách"
        Me.btnSplit.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(231, 216)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'D12F3112
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(310, 242)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSplit)
        Me.Controls.Add(Me.tdbg)
        Me.Controls.Add(Me.txtTOQuantity)
        Me.Controls.Add(Me.txtInventoryID)
        Me.Controls.Add(Me.lblInventoryID)
        Me.Controls.Add(Me.lblTOQuantity)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D12F3112"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TÀch sç l§íng - D12F3112"
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents txtInventoryID As System.Windows.Forms.TextBox
    Private WithEvents lblInventoryID As System.Windows.Forms.Label
    Private WithEvents txtTOQuantity As System.Windows.Forms.TextBox
    Private WithEvents lblTOQuantity As System.Windows.Forms.Label
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnSplit As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
End Class