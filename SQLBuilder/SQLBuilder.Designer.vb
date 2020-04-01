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
        Me.gbTOP = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTablename = New System.Windows.Forms.TextBox()
        Me.dgvFieldSelection = New System.Windows.Forms.DataGridView()
        Me.btnSelectionToQuery = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSQLQuery = New System.Windows.Forms.TextBox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDatasetName = New System.Windows.Forms.TextBox()
        CType(Me.dgvFieldSelection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbTOP
        '
        Me.gbTOP.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbTOP.Location = New System.Drawing.Point(1, 0)
        Me.gbTOP.Name = "gbTOP"
        Me.gbTOP.Size = New System.Drawing.Size(565, 52)
        Me.gbTOP.TabIndex = 0
        Me.gbTOP.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(204, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Tablename:"
        '
        'txtTablename
        '
        Me.txtTablename.Location = New System.Drawing.Point(269, 51)
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
        Me.dgvFieldSelection.Location = New System.Drawing.Point(12, 94)
        Me.dgvFieldSelection.Name = "dgvFieldSelection"
        Me.dgvFieldSelection.Size = New System.Drawing.Size(456, 585)
        Me.dgvFieldSelection.TabIndex = 11
        '
        'btnSelectionToQuery
        '
        Me.btnSelectionToQuery.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSelectionToQuery.Location = New System.Drawing.Point(12, 691)
        Me.btnSelectionToQuery.Name = "btnSelectionToQuery"
        Me.btnSelectionToQuery.Size = New System.Drawing.Size(227, 23)
        Me.btnSelectionToQuery.TabIndex = 10
        Me.btnSelectionToQuery.Text = "Add Selection to Query"
        Me.btnSelectionToQuery.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 729)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "SQL Query:"
        '
        'txtSQLQuery
        '
        Me.txtSQLQuery.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSQLQuery.Location = New System.Drawing.Point(94, 729)
        Me.txtSQLQuery.Multiline = True
        Me.txtSQLQuery.Name = "txtSQLQuery"
        Me.txtSQLQuery.Size = New System.Drawing.Size(374, 45)
        Me.txtSQLQuery.TabIndex = 8
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(388, 50)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(80, 23)
        Me.btnRefresh.TabIndex = 14
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Dataset Name:"
        '
        'txtDatasetName
        '
        Me.txtDatasetName.Location = New System.Drawing.Point(89, 51)
        Me.txtDatasetName.Name = "txtDatasetName"
        Me.txtDatasetName.Size = New System.Drawing.Size(100, 20)
        Me.txtDatasetName.TabIndex = 15
        '
        'SQLBuilder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(567, 783)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDatasetName)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTablename)
        Me.Controls.Add(Me.dgvFieldSelection)
        Me.Controls.Add(Me.btnSelectionToQuery)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtSQLQuery)
        Me.Controls.Add(Me.gbTOP)
        Me.MinimumSize = New System.Drawing.Size(580, 325)
        Me.Name = "SQLBuilder"
        Me.Text = "SQL Builder"
        CType(Me.dgvFieldSelection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gbTOP As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtTablename As TextBox
    Friend WithEvents dgvFieldSelection As DataGridView
    Friend WithEvents btnSelectionToQuery As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents txtSQLQuery As TextBox
    Friend WithEvents btnRefresh As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDatasetName As TextBox
End Class
