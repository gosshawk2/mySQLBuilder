<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SQLBuilder
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTablename = New System.Windows.Forms.TextBox()
        Me.dgvFieldSelection = New System.Windows.Forms.DataGridView()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDatasetName = New System.Windows.Forms.TextBox()
        Me.lstFields = New System.Windows.Forms.ListBox()
        Me.btnMoveUP = New System.Windows.Forms.Button()
        Me.btnMoveDOWN = New System.Windows.Forms.Button()
        Me.btnSelectFields = New System.Windows.Forms.Button()
        Me.stsQueryBuilder = New System.Windows.Forms.StatusStrip()
        Me.stsQueryBuilderLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSelectAll = New System.Windows.Forms.Button()
        Me.btnSelectOrderBy = New System.Windows.Forms.Button()
        Me.btnMoveOrderByDown = New System.Windows.Forms.Button()
        Me.btnMoveOrderByUp = New System.Windows.Forms.Button()
        Me.chklstOrderBY = New System.Windows.Forms.CheckedListBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SQLQueryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAddWhereFields = New System.Windows.Forms.Button()
        Me.lstWhereFields = New System.Windows.Forms.ListBox()
        Me.btnAddWhere = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        CType(Me.dgvFieldSelection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stsQueryBuilder.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(204, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Tablename:"
        '
        'txtTablename
        '
        Me.txtTablename.Location = New System.Drawing.Point(269, 46)
        Me.txtTablename.Name = "txtTablename"
        Me.txtTablename.Size = New System.Drawing.Size(100, 20)
        Me.txtTablename.TabIndex = 12
        Me.txtTablename.Text = "ECM4120V20"
        '
        'dgvFieldSelection
        '
        Me.dgvFieldSelection.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvFieldSelection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFieldSelection.Location = New System.Drawing.Point(12, 93)
        Me.dgvFieldSelection.MinimumSize = New System.Drawing.Size(0, 170)
        Me.dgvFieldSelection.Name = "dgvFieldSelection"
        Me.dgvFieldSelection.Size = New System.Drawing.Size(573, 542)
        Me.dgvFieldSelection.TabIndex = 11
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(398, 46)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(80, 23)
        Me.btnRefresh.TabIndex = 14
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Dataset Name:"
        '
        'txtDatasetName
        '
        Me.txtDatasetName.Location = New System.Drawing.Point(89, 46)
        Me.txtDatasetName.Name = "txtDatasetName"
        Me.txtDatasetName.Size = New System.Drawing.Size(100, 20)
        Me.txtDatasetName.TabIndex = 15
        '
        'lstFields
        '
        Me.lstFields.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstFields.FormattingEnabled = True
        Me.lstFields.Location = New System.Drawing.Point(758, 93)
        Me.lstFields.MinimumSize = New System.Drawing.Size(4, 170)
        Me.lstFields.Name = "lstFields"
        Me.lstFields.Size = New System.Drawing.Size(169, 160)
        Me.lstFields.TabIndex = 17
        '
        'btnMoveUP
        '
        Me.btnMoveUP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMoveUP.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveUP.Location = New System.Drawing.Point(953, 94)
        Me.btnMoveUP.Name = "btnMoveUP"
        Me.btnMoveUP.Size = New System.Drawing.Size(39, 33)
        Me.btnMoveUP.TabIndex = 18
        Me.btnMoveUP.Text = "▲"
        Me.btnMoveUP.UseVisualStyleBackColor = True
        '
        'btnMoveDOWN
        '
        Me.btnMoveDOWN.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMoveDOWN.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveDOWN.Location = New System.Drawing.Point(953, 134)
        Me.btnMoveDOWN.Name = "btnMoveDOWN"
        Me.btnMoveDOWN.Size = New System.Drawing.Size(39, 31)
        Me.btnMoveDOWN.TabIndex = 19
        Me.btnMoveDOWN.Text = "▼"
        Me.btnMoveDOWN.UseVisualStyleBackColor = True
        '
        'btnSelectFields
        '
        Me.btnSelectFields.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelectFields.Location = New System.Drawing.Point(614, 93)
        Me.btnSelectFields.Name = "btnSelectFields"
        Me.btnSelectFields.Size = New System.Drawing.Size(110, 23)
        Me.btnSelectFields.TabIndex = 20
        Me.btnSelectFields.Text = "Select Fields ->"
        Me.btnSelectFields.UseVisualStyleBackColor = True
        '
        'stsQueryBuilder
        '
        Me.stsQueryBuilder.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.stsQueryBuilderLabel1})
        Me.stsQueryBuilder.Location = New System.Drawing.Point(0, 680)
        Me.stsQueryBuilder.Name = "stsQueryBuilder"
        Me.stsQueryBuilder.Size = New System.Drawing.Size(1030, 22)
        Me.stsQueryBuilder.TabIndex = 21
        Me.stsQueryBuilder.Text = "StatusStrip1"
        '
        'stsQueryBuilderLabel1
        '
        Me.stsQueryBuilderLabel1.Name = "stsQueryBuilderLabel1"
        Me.stsQueryBuilderLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(615, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(252, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Highlight item in list to move up or down with arrows:"
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Location = New System.Drawing.Point(506, 46)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(80, 23)
        Me.btnSelectAll.TabIndex = 23
        Me.btnSelectAll.Text = "Select All"
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'btnSelectOrderBy
        '
        Me.btnSelectOrderBy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelectOrderBy.Location = New System.Drawing.Point(614, 490)
        Me.btnSelectOrderBy.Name = "btnSelectOrderBy"
        Me.btnSelectOrderBy.Size = New System.Drawing.Size(110, 23)
        Me.btnSelectOrderBy.TabIndex = 27
        Me.btnSelectOrderBy.Text = "Select OrderBy ->"
        Me.btnSelectOrderBy.UseVisualStyleBackColor = True
        '
        'btnMoveOrderByDown
        '
        Me.btnMoveOrderByDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMoveOrderByDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveOrderByDown.Location = New System.Drawing.Point(953, 531)
        Me.btnMoveOrderByDown.Name = "btnMoveOrderByDown"
        Me.btnMoveOrderByDown.Size = New System.Drawing.Size(39, 31)
        Me.btnMoveOrderByDown.TabIndex = 26
        Me.btnMoveOrderByDown.Text = "▼"
        Me.btnMoveOrderByDown.UseVisualStyleBackColor = True
        '
        'btnMoveOrderByUp
        '
        Me.btnMoveOrderByUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMoveOrderByUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveOrderByUp.Location = New System.Drawing.Point(953, 491)
        Me.btnMoveOrderByUp.Name = "btnMoveOrderByUp"
        Me.btnMoveOrderByUp.Size = New System.Drawing.Size(39, 33)
        Me.btnMoveOrderByUp.TabIndex = 25
        Me.btnMoveOrderByUp.Text = "▲"
        Me.btnMoveOrderByUp.UseVisualStyleBackColor = True
        '
        'chklstOrderBY
        '
        Me.chklstOrderBY.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chklstOrderBY.FormattingEnabled = True
        Me.chklstOrderBY.Location = New System.Drawing.Point(758, 490)
        Me.chklstOrderBY.Name = "chklstOrderBY"
        Me.chklstOrderBY.Size = New System.Drawing.Size(169, 169)
        Me.chklstOrderBY.TabIndex = 28
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(615, 471)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(222, 13)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Tick item in list to indicate reversed sort order:"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1030, 24)
        Me.MenuStrip1.TabIndex = 30
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SQLQueryToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(79, 20)
        Me.ViewToolStripMenuItem.Text = "View Query"
        '
        'SQLQueryToolStripMenuItem
        '
        Me.SQLQueryToolStripMenuItem.Name = "SQLQueryToolStripMenuItem"
        Me.SQLQueryToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.SQLQueryToolStripMenuItem.Text = "SQL Query"
        '
        'btnAddWhereFields
        '
        Me.btnAddWhereFields.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddWhereFields.Location = New System.Drawing.Point(618, 283)
        Me.btnAddWhereFields.Name = "btnAddWhereFields"
        Me.btnAddWhereFields.Size = New System.Drawing.Size(119, 23)
        Me.btnAddWhereFields.TabIndex = 31
        Me.btnAddWhereFields.Text = "Add Where Fields ->"
        Me.btnAddWhereFields.UseVisualStyleBackColor = True
        '
        'lstWhereFields
        '
        Me.lstWhereFields.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstWhereFields.FormattingEnabled = True
        Me.lstWhereFields.Location = New System.Drawing.Point(758, 283)
        Me.lstWhereFields.MinimumSize = New System.Drawing.Size(4, 170)
        Me.lstWhereFields.Name = "lstWhereFields"
        Me.lstWhereFields.Size = New System.Drawing.Size(169, 160)
        Me.lstWhereFields.TabIndex = 32
        '
        'btnAddWhere
        '
        Me.btnAddWhere.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddWhere.Location = New System.Drawing.Point(942, 283)
        Me.btnAddWhere.Name = "btnAddWhere"
        Me.btnAddWhere.Size = New System.Drawing.Size(72, 23)
        Me.btnAddWhere.TabIndex = 33
        Me.btnAddWhere.Text = "Add Where"
        Me.btnAddWhere.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(12, 648)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(110, 23)
        Me.btnClose.TabIndex = 34
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'SQLBuilder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1030, 702)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnAddWhere)
        Me.Controls.Add(Me.lstWhereFields)
        Me.Controls.Add(Me.btnAddWhereFields)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.chklstOrderBY)
        Me.Controls.Add(Me.btnSelectOrderBy)
        Me.Controls.Add(Me.btnMoveOrderByDown)
        Me.Controls.Add(Me.btnMoveOrderByUp)
        Me.Controls.Add(Me.btnSelectAll)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.stsQueryBuilder)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.btnSelectFields)
        Me.Controls.Add(Me.btnMoveDOWN)
        Me.Controls.Add(Me.btnMoveUP)
        Me.Controls.Add(Me.lstFields)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDatasetName)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTablename)
        Me.Controls.Add(Me.dgvFieldSelection)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(580, 515)
        Me.Name = "SQLBuilder"
        Me.Text = "SQL Builder"
        CType(Me.dgvFieldSelection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stsQueryBuilder.ResumeLayout(False)
        Me.stsQueryBuilder.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents txtTablename As TextBox
    Friend WithEvents dgvFieldSelection As DataGridView
    Friend WithEvents btnRefresh As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDatasetName As TextBox
    Friend WithEvents lstFields As ListBox
    Friend WithEvents btnMoveUP As Button
    Friend WithEvents btnMoveDOWN As Button
    Friend WithEvents btnSelectFields As Button
    Friend WithEvents stsQueryBuilder As StatusStrip
    Friend WithEvents Label2 As Label
    Friend WithEvents stsQueryBuilderLabel1 As ToolStripStatusLabel
    Friend WithEvents btnSelectAll As Button
    Friend WithEvents btnSelectOrderBy As Button
    Friend WithEvents btnMoveOrderByDown As Button
    Friend WithEvents btnMoveOrderByUp As Button
    Friend WithEvents chklstOrderBY As CheckedListBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SQLQueryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents btnAddWhereFields As Button
    Friend WithEvents lstWhereFields As ListBox
    Friend WithEvents btnAddWhere As Button
    Friend WithEvents btnClose As Button
End Class
