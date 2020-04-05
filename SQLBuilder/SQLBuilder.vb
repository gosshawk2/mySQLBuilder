Public Class SQLBuilder
    Private _DataSetID As Integer
    Private _WhereConditions As String
    Dim GlobalParms As New ESPOParms.Framework
    Dim GlobalSession As New ESPOParms.Session
    Dim dic_ColumnText As Object
    Public Shared myWhereConditions As New myGlobals
    Public Sub GetParms(Session As ESPOParms.Session, Parms As ESPOParms.Framework)
        GlobalParms = Parms
        GlobalSession = Session
    End Sub

    Sub BuildDatabaseCombo(csvFilename As String)
        Dim myDAL As New SQLBuilderDAL
        Dim csvArray As String(,)
        Dim TotalFields As Long
        Dim Message As String
        Dim TotalRows As Long

        If csvFilename <> "" Then
            TotalRows = myDAL.CSVFileToArray(csvArray, csvFilename, TotalFields, Message)
            For i As Long = 1 To TotalRows - 1
                cboDatabases.Items.Add(csvArray(1, i))
            Next
        Else
            MsgBox("No CSV FILENAME passed")
        End If

    End Sub

    Sub BuildTableCombo(DatabaseName As String)
        Dim myDAL As New SQLBuilderDAL
        Dim dt As DataTable

        dt = myDAL.GetTablesFromDB(DatabaseName)
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                cboTables.Items.Add(dt.Rows(i)(0))
            Next

        End If

    End Sub

    'GetFieldsFromTable

    Private Sub SQLBuilder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        Me.KeyPreview = True
        Me.MdiParent = FromHandle(GlobalSession.MDIParentHandle)
        dgvFieldSelection.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgvFieldSelection.AllowUserToOrderColumns = True
        dgvFieldSelection.AllowUserToResizeColumns = True
        dgvFieldSelection.AllowUserToAddRows = False
        dgvFieldSelection.AllowUserToDeleteRows = False
        dic_ColumnText = CreateObject("Scripting.Dictionary")
        dic_ColumnText.CompareMode = vbTextCompare

    End Sub

    Public Property TheDataSetID As Integer
        Get
            Return _DataSetID
        End Get
        Set(value As Integer)
            _DataSetID = value
        End Set
    End Property

    Public Property WhereConditions As String
        Get
            Return _WhereConditions
        End Get
        Set(value As String)
            _WhereConditions = value
        End Set
    End Property

    Sub PopulateForm(DataSetID As Integer, myDT As DataTable)
        Cursor = Cursors.WaitCursor
        Dim myDAL As New SQLBuilderDAL
        Dim dt As DataTable

        Try
            Me.Text = "SQL Builder"
            Me.TheDataSetID = DataSetID
            dgvFieldSelection.Columns.Clear()
            BuildDatabaseCombo("Databases.csv")

            Dim dgvCheck As New DataGridViewCheckBoxColumn()
            Dim dgvCheckSum As New DataGridViewCheckBoxColumn()
            dgvCheck.HeaderText = "Select Field"
            dgvCheck.Name = "SelectField"
            dgvCheckSum.HeaderText = "SUM()"
            dgvCheckSum.Name = "SUM"

            dgvFieldSelection.DataSource = Nothing
            If myDT IsNot Nothing Then
                dt = myDAL.GetFieldsFromTable(cboTables.Text)
            Else
                dt = myDAL.GetColumnsMYSQL(DataSetID)
            End If

            'dt = myDAL.GetColumns(GlobalSession.ConnectString, DataSetID)
            If dt IsNot Nothing Then
                If dt.Rows.Count > 0 Then
                    dgvFieldSelection.DataSource = dt
                    dgvFieldSelection.Columns.Add(dgvCheck)
                    dgvFieldSelection.Columns.Add(dgvCheckSum)
                End If
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            MsgBox("Populate Error: " & ex.Message)
        End Try
        Cursor = Cursors.Default
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
        Dim dt As DataTable
        Dim myDAL As New SQLBuilderDAL

        If cboTables.Text <> "" Then
            dt = myDAL.GetFieldsFromTable(cboTables.Text)
            PopulateForm(0, dt)
        Else
            PopulateForm(Me.TheDataSetID, Nothing)
        End If


        lstFields.Items.Clear()
        lstWhereFields.Items.Clear()
        lstGroupByFields.Items.Clear()
        chklstOrderBY.Items.Clear()

    End Sub

    Function IsInList(lstBox As ListBox, CheckItem As String, ByRef ReturnIDX As Integer) As Boolean
        Dim ItemName As String

        IsInList = False
        ReturnIDX = -1
        For i As Integer = 0 To lstBox.Items.Count - 1
            ItemName = lstBox.Items(i)
            If UCase(CheckItem) = UCase(ItemName) Then
                ReturnIDX = i
                Return True
                Exit For
            End If
        Next

    End Function

    Function IsInCHKList(lstBox As CheckedListBox, CheckItem As String, ByRef ReturnIDX As Integer) As Boolean
        Dim ItemName As String

        IsInCHKList = False
        ReturnIDX = -1
        For i As Integer = 0 To lstBox.Items.Count - 1
            ItemName = lstBox.Items(i)
            If UCase(CheckItem) = UCase(ItemName) Then
                ReturnIDX = i
                Return True
                Exit For
            End If
        Next

    End Function

    Sub SelectFields(SelectedList As String)
        Dim ColumnName As String
        Dim ColumnText As String
        Dim SumItem As String
        Dim ItemIDX As Integer

        Select Case UCase(SelectedList)
            Case "SELECT FIELDS"
                lstFields.Items.Clear()
            Case "WHERE FIELDS"
                lstWhereFields.Items.Clear()
            Case "GROUPBY FIELDS"
                lstGroupByFields.Items.Clear()
            Case "ORDERBY FIELDS"
                chklstOrderBY.Items.Clear()
            Case Else
                MsgBox("List not recognised")
                Exit Sub
        End Select
        For i As Integer = 0 To dgvFieldSelection.Rows.Count - 1
            If dgvFieldSelection.Rows(i).Cells("SelectField").Value = True Then
                ColumnName = dgvFieldSelection.Rows(i).Cells("Column_Name").Value
                ColumnText = ColumnName
                For h As Integer = 0 To dgvFieldSelection.Columns.Count - 1
                    If UCase(dgvFieldSelection.Columns(h).Name) = "COLUMN TEXT" Then
                        ColumnText = dgvFieldSelection.Rows(i).Cells("Column Text").Value
                    End If
                Next

                Select Case UCase(SelectedList)
                    Case "SELECT FIELDS"
                        If Not IsInList(lstFields, ColumnName, ItemIDX) Then
                            dic_ColumnText(ColumnName) = ColumnText 'stored for the AS part.
                            lstFields.Items.Add(ColumnName)
                        End If
                    Case "WHERE FIELDS"
                        If Not IsInList(lstWhereFields, ColumnName, ItemIDX) Then
                            lstWhereFields.Items.Add(ColumnName)
                        End If
                    Case "GROUPBY FIELDS"
                        If Not IsInList(lstGroupByFields, ColumnName, ItemIDX) Then
                            lstGroupByFields.Items.Add(ColumnName)
                        End If
                    Case "ORDERBY FIELDS"
                        If Not IsInCHKList(chklstOrderBY, ColumnName, ItemIDX) Then
                            chklstOrderBY.Items.Add(ColumnName)
                        End If
                    Case Else
                        MsgBox("List not recognised")
                        Exit Sub
                End Select

            End If
            If dgvFieldSelection.Rows(i).Cells("SUM").Value = True Then
                Select Case UCase(SelectedList)
                    Case "SELECT FIELDS"
                        ColumnName = dgvFieldSelection.Rows(i).Cells("Column Name").Value
                        ColumnText = ColumnName
                        For h As Integer = 0 To dgvFieldSelection.Columns.Count - 1
                            If UCase(dgvFieldSelection.Columns(h).Name) = "COLUMN TEXT" Then
                                ColumnText = dgvFieldSelection.Rows(i).Cells("Column Text").Value
                            End If
                        Next
                        SumItem = "SUM(" & ColumnName & ")"
                        If IsInList(lstFields, ColumnName, ItemIDX) Then
                            lstFields.Items.RemoveAt(ItemIDX)
                        End If
                        'Insert fieldname with SUM() around it:

                        If Not IsInList(lstFields, SumItem, ItemIDX) Then
                            lstFields.Items.Add(SumItem)
                            dic_ColumnText(SumItem) = ColumnText 'stored for the AS part.
                        End If
                End Select
            End If
        Next
    End Sub

    Private Sub btnSelectFields_Click(sender As Object, e As EventArgs) Handles btnSelectFields.Click
        SelectFields("SELECT FIELDS")
    End Sub

    Private Sub btnAddWhereFields_Click(sender As Object, e As EventArgs) Handles btnAddWhereFields.Click
        SelectFields("WHERE FIELDS")
    End Sub

    Private Sub btnAddGroupByFields_Click(sender As Object, e As EventArgs) Handles btnAddGroupByFields.Click
        SelectFields("GROUPBY FIELDS")
    End Sub

    Private Sub btnSelectOrderBy_Click(sender As Object, e As EventArgs) Handles btnSelectOrderBy.Click
        SelectFields("ORDERBY FIELDS")
    End Sub

    Sub MoveItemUp(ByRef lstBox As ListBox)
        Dim CurrentIDX As Integer
        Dim strCurrentItem As String
        Dim NewIDX As Integer


        CurrentIDX = lstBox.SelectedIndex

        If CurrentIDX > 0 Then
            strCurrentItem = lstBox.Items(CurrentIDX)
            NewIDX = CurrentIDX - 1
            lstBox.Items.RemoveAt(CurrentIDX)
            lstBox.Items.Insert(NewIDX, strCurrentItem)
            lstBox.SelectedIndex = NewIDX

        End If

    End Sub

    Sub MoveItemDown(ByRef lstBox As ListBox)
        Dim CurrentIDX As Integer
        Dim strCurrentItem As String
        Dim NewIDX As Integer

        CurrentIDX = lstBox.SelectedIndex

        If CurrentIDX < lstBox.Items.Count - 1 And CurrentIDX > -1 Then
            strCurrentItem = lstBox.Items(CurrentIDX)
            NewIDX = CurrentIDX + 1
            lstBox.Items.RemoveAt(CurrentIDX)
            lstBox.Items.Insert(NewIDX, strCurrentItem)
            lstBox.SelectedIndex = NewIDX
        End If
    End Sub

    Sub MoveCheckedListItemUp(chklstBox As CheckedListBox)
        Dim CurrentIDX As Integer
        Dim strCurrentItem As String
        Dim NewIDX As Integer
        Dim IsSelected As Boolean

        CurrentIDX = chklstBox.SelectedIndex

        If CurrentIDX > 0 Then
            IsSelected = chklstBox.GetItemChecked(CurrentIDX)
            strCurrentItem = chklstBox.Items(CurrentIDX)
            NewIDX = CurrentIDX - 1
            chklstBox.Items.RemoveAt(CurrentIDX)
            chklstBox.Items.Insert(NewIDX, strCurrentItem)
            chklstBox.SelectedIndex = NewIDX
            chklstBox.SetItemChecked(NewIDX, IsSelected)
        End If

    End Sub

    Sub MoveCheckedListItemDown(chklstBox As CheckedListBox)
        Dim CurrentIDX As Integer
        Dim strCurrentItem As String
        Dim NewIDX As Integer
        Dim IsSelected As Boolean

        CurrentIDX = chklstBox.SelectedIndex

        If CurrentIDX < chklstBox.Items.Count - 1 And CurrentIDX > -1 Then
            IsSelected = chklstBox.GetItemChecked(CurrentIDX)
            strCurrentItem = chklstBox.Items(CurrentIDX)
            NewIDX = CurrentIDX + 1
            chklstBox.Items.RemoveAt(CurrentIDX)
            chklstBox.Items.Insert(NewIDX, strCurrentItem)
            chklstBox.SelectedIndex = NewIDX
            chklstBox.SetItemChecked(NewIDX, IsSelected)
        End If
    End Sub

    Function BuildQueryFromSelection() As String
        Dim ColumnName As String
        Dim ColumnText As String
        Dim TableName As String
        Dim Sequence As String
        Dim FieldID As String
        Dim FieldsSelected As String
        Dim SelectPart As String
        Dim GroupByFields As String
        Dim OrderByFields As String
        Dim IsChecked As Boolean
        Dim FinalQuery As String

        BuildQueryFromSelection = ""
        SelectPart = "SELECT "
        FieldsSelected = ""
        OrderByFields = ""
        TableName = cboTables.Text
        For i As Integer = 0 To lstFields.Items.Count - 1
            ColumnName = lstFields.Items(i)
            ColumnText = dic_ColumnText(ColumnName)
            If FieldsSelected = "" Then
                FieldsSelected += Trim(ColumnName) & " AS """ & ColumnText & """"
            Else
                FieldsSelected += "," & Trim(ColumnName) & " AS """ & ColumnText & """"
            End If
        Next
        For i As Integer = 0 To lstGroupByFields.Items.Count - 1
            ColumnName = lstGroupByFields.Items(i)
            If GroupByFields = "" Then
                GroupByFields += Trim(ColumnName)
            Else
                GroupByFields += "," & Trim(ColumnName)
            End If
        Next
        For i As Integer = 0 To chklstOrderBY.Items.Count - 1
            ColumnName = chklstOrderBY.Items(i)
            IsChecked = chklstOrderBY.GetItemChecked(i)
            If OrderByFields = "" Then
                OrderByFields += Trim(ColumnName)
            Else
                OrderByFields += "," & Trim(ColumnName)
            End If
            If IsChecked Then
                OrderByFields += " DESC"
            End If
        Next
        SelectPart += FieldsSelected & " FROM " & TableName
        If myWhereConditions.GetMyWhereCondtions <> "" Then
            SelectPart += " WHERE " & myWhereConditions.GetMyWhereCondtions
        End If
        'GROUPBY:
        If GroupByFields <> "" Then
            SelectPart += " GROUP BY " & GroupByFields
        End If
        'ORDERBY:
        If OrderByFields <> "" Then
            SelectPart += " ORDER BY " & OrderByFields
        End If
        FinalQuery = SelectPart
        Cursor = Cursors.Default
        Return FinalQuery

    End Function

    Private Sub btnSelectionToQuery_Click(sender As Object, e As EventArgs)
        '
        BuildQueryFromSelection()

    End Sub

    Private Sub SQLBuilder_ClientSizeChanged(sender As Object, e As EventArgs) Handles MyBase.ClientSizeChanged

    End Sub

    Private Sub btnSelectAll_Click(sender As Object, e As EventArgs) Handles btnSelectAll.Click
        Dim Selected As Boolean = False

        If btnSelectAll.Text = "Select All" Then
            btnSelectAll.Text = "Unselect All"
            btnSelectAll.Refresh()
            Selected = True
        Else
            'If btnSelectAll.Text = "Unselect All" Then
            btnSelectAll.Text = "Select All"
            btnSelectAll.Refresh()

            Selected = False
        End If
        For i As Integer = 0 To dgvFieldSelection.Rows.Count - 1
            dgvFieldSelection.Rows(i).Cells("SelectField").Value = Selected
        Next
    End Sub

    Sub ShowQueryForm()
        Dim FinalQuery As String
        Dim App As New ViewSQL

        Cursor = Cursors.Default
        FinalQuery = BuildQueryFromSelection()
        stsQueryBuilderLabel1.Text = "Building Query ..."
        Cursor = Cursors.WaitCursor
        Refresh()

        App.Visible = False
        'App.GetParms(GlobalSession, GlobalParms)
        App.PopulateForm(FinalQuery)
        App.txtDBName.Text = cboDatabases.Text
        App.Show()
        'App.Visible = True
        stsQueryBuilderLabel1.Text = ""
        Cursor = Cursors.Default
    End Sub

    Private Sub SQLQueryToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ShowQueryForm()

    End Sub

    Private Sub btnAddWhere_Click(sender As Object, e As EventArgs) Handles btnAddWhere.Click
        Dim App As New WherePart
        Dim arrWhereFields As String()
        Dim strField As String

        ReDim arrWhereFields(lstWhereFields.Items.Count - 1)
        For i As Integer = 0 To lstWhereFields.Items.Count - 1
            strField = lstWhereFields.Items(i)
            'arrWhereFields(i) = strField
            arrWhereFields(i) = lstWhereFields.Items(i)
        Next

        Cursor = Cursors.Default
        stsQueryBuilderLabel1.Text = "Building WHERE Clause ..."
        Cursor = Cursors.WaitCursor
        Refresh()

        App.Visible = False
        'App.GetParms(GlobalSession, GlobalParms)
        App.PopulateForm(arrWhereFields)
        'App.PopulateForm(lstWhereFields)
        App.Show()
        'App.Visible = True
        stsQueryBuilderLabel1.Text = ""
        Cursor = Cursors.Default
    End Sub

    Private Sub btnMoveOrderByFieldsDown_Click(sender As Object, e As EventArgs) Handles btnMoveOrderByFieldsDown.Click
        MoveCheckedListItemDown(chklstOrderBY)
    End Sub

    Private Sub btnMoveOrderByFieldsUp_Click(sender As Object, e As EventArgs) Handles btnMoveOrderByFieldsUp.Click
        MoveCheckedListItemUp(chklstOrderBY)
    End Sub

    Private Sub btnMoveGroupByFieldsUp_Click(sender As Object, e As EventArgs) Handles btnMoveGroupByFieldsUp.Click
        MoveItemUp(lstGroupByFields)
    End Sub

    Private Sub btnMoveGroupByFieldsDown_Click(sender As Object, e As EventArgs) Handles btnMoveGroupByFieldsDown.Click
        MoveItemDown(lstGroupByFields)
    End Sub

    Private Sub btnMoveSelectFieldsUP_Click(sender As Object, e As EventArgs) Handles btnMoveSelectFieldsUP.Click
        MoveItemUp(lstFields)
    End Sub

    Private Sub btnMoveSelectFieldsDOWN_Click(sender As Object, e As EventArgs) Handles btnMoveSelectFieldsDOWN.Click
        MoveItemDown(lstFields)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()

    End Sub

    Private Sub btnShowQuery_Click(sender As Object, e As EventArgs) Handles btnShowQuery.Click
        ShowQueryForm()

    End Sub

    Private Sub lstFields_MouseDown(sender As Object, e As MouseEventArgs) Handles lstFields.MouseDown
        'Right-click to remove field:
        Dim IDX As Integer

        If e.Button = MouseButtons.Right Then

            IDX = lstFields.SelectedIndex
            If IDX > -1 Then
                lstFields.Items.RemoveAt(IDX)
            End If
        End If

    End Sub

    Private Sub btnRemoveSelectedFields_Click(sender As Object, e As EventArgs) Handles btnRemoveSelectedFields.Click
        Dim IDX As Integer

        IDX = lstFields.SelectedIndex
        If IDX > -1 Then
            lstFields.Items.RemoveAt(IDX)
        End If
    End Sub

    Private Sub btnRemoveSelectedWHEREFields_Click(sender As Object, e As EventArgs) Handles btnRemoveSelectedWHEREFields.Click
        Dim IDX As Integer

        IDX = lstWhereFields.SelectedIndex
        If IDX > -1 Then
            lstWhereFields.Items.RemoveAt(IDX)
        End If
    End Sub

    Private Sub btnRemoveSelectedGroupByFields_Click(sender As Object, e As EventArgs) Handles btnRemoveSelectedGroupByFields.Click
        Dim IDX As Integer

        IDX = lstGroupByFields.SelectedIndex
        If IDX > -1 Then
            lstGroupByFields.Items.RemoveAt(IDX)
        End If
    End Sub

    Private Sub btnRemoveOrderByFields_Click(sender As Object, e As EventArgs) Handles btnRemoveOrderByFields.Click
        Dim IDX As Integer

        IDX = chklstOrderBY.SelectedIndex
        If IDX > -1 Then
            chklstOrderBY.Items.RemoveAt(IDX)
        End If
    End Sub

    Private Sub cboDatabases_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDatabases.SelectedIndexChanged
        '
        Dim IDX As Integer
        Dim DBName As String

        IDX = cboDatabases.SelectedIndex
        DBName = cboDatabases.Items(IDX)
        BuildTableCombo(DBName)

    End Sub

    Private Sub cboTables_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTables.SelectedIndexChanged
        Dim myDAL As New SQLBuilderDAL
        Dim dt As DataTable

        dt = myDAL.GetFieldsFromTable(cboTables.Text)
        PopulateForm(0, dt)
    End Sub
End Class
