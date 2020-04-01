Public Class SQLBuilder
    Private _DataSetID As Integer
    Dim GlobalParms As New ESPOParms.Framework
    Dim GlobalSession As New ESPOParms.Session
    Public Sub GetParms(Session As ESPOParms.Session, Parms As ESPOParms.Framework)
        GlobalParms = Parms
        GlobalSession = Session
    End Sub

    Private Sub SQLBuilder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        Me.KeyPreview = True
        Me.MdiParent = FromHandle(GlobalSession.MDIParentHandle)
        dgvFieldSelection.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgvFieldSelection.AllowUserToOrderColumns = True
        dgvFieldSelection.AllowUserToResizeColumns = True
        dgvFieldSelection.AllowUserToAddRows = False
        dgvFieldSelection.AllowUserToDeleteRows = False
    End Sub

    Public Property TheDataSetID As Integer
        Get
            Return _DataSetID
        End Get
        Set(value As Integer)
            _DataSetID = value
        End Set
    End Property

    Sub PopulateForm(DataSetID As Integer)
        Cursor = Cursors.WaitCursor
        Dim myDAL As New SQLBuilderDAL
        Dim dt As DataTable
        Dim Tablename As String

        Me.TheDataSetID = DataSetID
        dgvFieldSelection.Columns.Clear()
        Dim dgvCheck As New DataGridViewCheckBoxColumn()
        dgvCheck.HeaderText = "Select Field"
        dgvCheck.Name = "SelectField"

        dgvFieldSelection.DataSource = Nothing
        'dt = myDAL.GetColumnsMYSQL(DataSetID)
        dt = myDAL.GetColumns(GlobalSession.ConnectString, DataSetID)
        If dt IsNot Nothing Then
            If dt.Rows.Count > 0 Then
                dgvFieldSelection.DataSource = dt
                dgvFieldSelection.Columns.Add(dgvCheck)
            End If
        End If

        Cursor = Cursors.Default
    End Sub

    Sub BuildQueryFromSelection()
        Dim ColumnName As String
        Dim TableName As String
        Dim Sequence As String
        Dim FieldID As String
        Dim FieldsSelected As String
        Dim SelectPart As String
        Dim FinalQuery As String

        SelectPart = "SELECT "
        FieldsSelected = ""
        TableName = txtTablename.Text
        For i As Integer = 0 To dgvFieldSelection.Rows.Count - 1
            If dgvFieldSelection.Rows(i).Cells("SelectField").Value = True Then
                ColumnName = dgvFieldSelection.Rows(i).Cells("Column Name").Value
                'SelectedTableName = dgvFieldSelection.Rows(i).Cells("TableName").Value
                If FieldsSelected = "" Then
                    FieldsSelected += Trim(ColumnName)
                Else
                    FieldsSelected += "," & Trim(ColumnName)
                End If
            End If
        Next
        SelectPart += FieldsSelected & " FROM " & TableName
        FinalQuery = SelectPart
        txtSQLQuery.Text = FinalQuery
        Cursor = Cursors.Default
    End Sub


    Private Sub btnSelectionToQuery_Click(sender As Object, e As EventArgs) Handles btnSelectionToQuery.Click
        '
        BuildQueryFromSelection()

    End Sub

    Private Sub UndockChild()
        If Me.MdiParent Is Nothing Then
            Me.MdiParent = FromHandle(GlobalSession.MDIParentHandle)
        Else
            Me.MdiParent = Nothing
        End If
    End Sub

    Private Sub SQLBuilder_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.F5 Then
            'btnRefresh.PerformClick()
        ElseIf e.KeyValue = 27 Then 'ESC pressed
            'Clear certain fields
        ElseIf e.KeyValue = Keys.F7 Then
            UndockChild()
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click

        PopulateForm(Me.TheDataSetID)
        txtSQLQuery.Text = ""
    End Sub
End Class
