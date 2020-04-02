<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WherePart
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbOR = New System.Windows.Forms.RadioButton()
        Me.rbAND = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lbConditions = New System.Windows.Forms.ListBox()
        Me.lbSelectedWHEREFields = New System.Windows.Forms.ListBox()
        Me.txtOperator = New System.Windows.Forms.TextBox()
        Me.btnRemoveCondition = New System.Windows.Forms.Button()
        Me.btnAddCondition = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cboOperators = New System.Windows.Forms.ComboBox()
        Me.txtValue = New System.Windows.Forms.TextBox()
        Me.cbIncludeSingleQuote = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAddWhere = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbOR)
        Me.GroupBox1.Controls.Add(Me.rbAND)
        Me.GroupBox1.Location = New System.Drawing.Point(774, 110)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(125, 54)
        Me.GroupBox1.TabIndex = 50
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Join Condition with:"
        '
        'rbOR
        '
        Me.rbOR.AutoSize = True
        Me.rbOR.Location = New System.Drawing.Point(68, 19)
        Me.rbOR.Name = "rbOR"
        Me.rbOR.Size = New System.Drawing.Size(41, 17)
        Me.rbOR.TabIndex = 1
        Me.rbOR.Text = "OR"
        Me.rbOR.UseVisualStyleBackColor = True
        '
        'rbAND
        '
        Me.rbAND.AutoSize = True
        Me.rbAND.Checked = True
        Me.rbAND.Location = New System.Drawing.Point(14, 19)
        Me.rbAND.Name = "rbAND"
        Me.rbAND.Size = New System.Drawing.Size(48, 17)
        Me.rbAND.TabIndex = 0
        Me.rbAND.TabStop = True
        Me.rbAND.Text = "AND"
        Me.rbAND.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(231, 151)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "CONDITIONS:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(14, 29)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(150, 13)
        Me.Label11.TabIndex = 48
        Me.Label11.Text = "SELECTED WHERE FIELDS:"
        '
        'lbConditions
        '
        Me.lbConditions.FormattingEnabled = True
        Me.lbConditions.Location = New System.Drawing.Point(234, 169)
        Me.lbConditions.Name = "lbConditions"
        Me.lbConditions.Size = New System.Drawing.Size(665, 82)
        Me.lbConditions.TabIndex = 47
        '
        'lbSelectedWHEREFields
        '
        Me.lbSelectedWHEREFields.FormattingEnabled = True
        Me.lbSelectedWHEREFields.Location = New System.Drawing.Point(11, 52)
        Me.lbSelectedWHEREFields.Name = "lbSelectedWHEREFields"
        Me.lbSelectedWHEREFields.Size = New System.Drawing.Size(201, 199)
        Me.lbSelectedWHEREFields.TabIndex = 46
        '
        'txtOperator
        '
        Me.txtOperator.Location = New System.Drawing.Point(234, 79)
        Me.txtOperator.Name = "txtOperator"
        Me.txtOperator.Size = New System.Drawing.Size(114, 20)
        Me.txtOperator.TabIndex = 45
        '
        'btnRemoveCondition
        '
        Me.btnRemoveCondition.Location = New System.Drawing.Point(566, 140)
        Me.btnRemoveCondition.Name = "btnRemoveCondition"
        Me.btnRemoveCondition.Size = New System.Drawing.Size(108, 23)
        Me.btnRemoveCondition.TabIndex = 44
        Me.btnRemoveCondition.Text = "Remove Condition"
        Me.btnRemoveCondition.UseVisualStyleBackColor = True
        '
        'btnAddCondition
        '
        Me.btnAddCondition.Location = New System.Drawing.Point(388, 140)
        Me.btnAddCondition.Name = "btnAddCondition"
        Me.btnAddCondition.Size = New System.Drawing.Size(121, 23)
        Me.btnAddCondition.TabIndex = 43
        Me.btnAddCondition.Text = "Add Condition"
        Me.btnAddCondition.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(231, 29)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(117, 13)
        Me.Label14.TabIndex = 42
        Me.Label14.Text = "SELECT OPERATION:"
        '
        'cboOperators
        '
        Me.cboOperators.FormattingEnabled = True
        Me.cboOperators.Items.AddRange(New Object() {"=", ">", "<", "<>", ">=", "<=", "*", "+", "-", "!", "!=", "BETWEEN"})
        Me.cboOperators.Location = New System.Drawing.Point(234, 52)
        Me.cboOperators.Name = "cboOperators"
        Me.cboOperators.Size = New System.Drawing.Size(114, 21)
        Me.cboOperators.TabIndex = 41
        '
        'txtValue
        '
        Me.txtValue.Location = New System.Drawing.Point(388, 79)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(511, 20)
        Me.txtValue.TabIndex = 52
        '
        'cbIncludeSingleQuote
        '
        Me.cbIncludeSingleQuote.AutoSize = True
        Me.cbIncludeSingleQuote.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbIncludeSingleQuote.Checked = True
        Me.cbIncludeSingleQuote.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbIncludeSingleQuote.Location = New System.Drawing.Point(447, 59)
        Me.cbIncludeSingleQuote.Name = "cbIncludeSingleQuote"
        Me.cbIncludeSingleQuote.Size = New System.Drawing.Size(128, 17)
        Me.cbIncludeSingleQuote.TabIndex = 54
        Me.cbIncludeSingleQuote.Text = "Include Single Quote:"
        Me.cbIncludeSingleQuote.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(385, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "ENTER VALUE:"
        '
        'btnAddWhere
        '
        Me.btnAddWhere.Location = New System.Drawing.Point(12, 278)
        Me.btnAddWhere.Name = "btnAddWhere"
        Me.btnAddWhere.Size = New System.Drawing.Size(121, 23)
        Me.btnAddWhere.TabIndex = 56
        Me.btnAddWhere.Text = "Add Where"
        Me.btnAddWhere.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(171, 278)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(121, 23)
        Me.btnCancel.TabIndex = 57
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'WherePart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(925, 313)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnAddWhere)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbIncludeSingleQuote)
        Me.Controls.Add(Me.txtValue)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lbConditions)
        Me.Controls.Add(Me.lbSelectedWHEREFields)
        Me.Controls.Add(Me.txtOperator)
        Me.Controls.Add(Me.btnRemoveCondition)
        Me.Controls.Add(Me.btnAddCondition)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.cboOperators)
        Me.Name = "WherePart"
        Me.Text = "Enter Where Clause"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbOR As RadioButton
    Friend WithEvents rbAND As RadioButton
    Friend WithEvents Label5 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents lbConditions As ListBox
    Friend WithEvents lbSelectedWHEREFields As ListBox
    Friend WithEvents txtOperator As TextBox
    Friend WithEvents btnRemoveCondition As Button
    Friend WithEvents btnAddCondition As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents cboOperators As ComboBox
    Friend WithEvents txtValue As TextBox
    Friend WithEvents cbIncludeSingleQuote As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnAddWhere As Button
    Friend WithEvents btnCancel As Button
End Class
