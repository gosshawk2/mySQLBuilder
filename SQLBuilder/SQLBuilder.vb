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

    Sub PopulateForm(DataSetID As Integer)
        Cursor = Cursors.WaitCursor
        Dim myDAL As New SQLBuilderDAL
        Dim dt As DataTable

        Me.TheDataSetID = DataSetID
        dgvFieldSelection.Columns.Clear()
        Dim dgvCheck As New DataGridViewCheckBoxColumn()
        dgvCheck.HeaderText = "Select Field"
        dgvCheck.Name = "SelectField"

        dgvFieldSelection.DataSource = Nothing
        dt = myDAL.GetColumnsMYSQL(DataSetID)
        'dt = myDAL.GetColumns(GlobalSession.ConnectString, DataSetID)
        If dt IsNot Nothing Then
            If dt.Rows.Count > 0 Then
                dgvFieldSelection.DataSource = dt
                dgvFieldSelection.Columns.Add(dgvCheck)
            End If
        End If

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

        PopulateForm(Me.TheDataSetID)
        lstFields.Items.Clear()
        chklstOrderBY.Items.Clear()

    End Sub

    Function IsInList(lstBox As ListBox, CheckItem As String) As Boolean
        Dim ItemName As String

        IsInList = False
        For i As Integer = 0 To lstBox.Items.Count - 1
            ItemName = lstBox.Items(i)
            If UCase(CheckItem) = UCase(ItemName) Then
                Return True
                Exit For
            End If
        Next

    End Function

    Function IsInCHKList(lstBox As CheckedListBox, CheckItem As String) As Boolean
        Dim ItemName As String

        IsInCHKList = False
        For i As Integer = 0 To lstBox.Items.Count - 1
            ItemName = lstBox.Items(i)
            If UCase(CheckItem) = UCase(ItemName) Then
                Return True
                Exit For
            End If
        Next

    End Function

    Sub SelectFields(SelectedList As String)
        Dim ColumnName As String
        Dim ColumnText As String

        For i As Integer = 0 To dgvFieldSelection.Rows.Count - 1
            If dgvFieldSelection.Rows(i).Cells("SelectField").Value = True Then
                ColumnName = dgvFieldSelection.Rows(i).Cells("Column Name").Value
                ColumnText = dgvFieldSelection.Rows(i).Cells("Column Text").Value
                dic_ColumnText(ColumnName) = ColumnText

                Select Case UCase(SelectedList)
                    Case "SELECT FIELDS"
                        If i = 0 Then
                            lstFields.Items.Clear()
                        End If
                        If Not IsInList(lstFields, ColumnName) Then
                            lstFields.Items.Add(ColumnName)
                        End If
                    Case "WHERE FIELDS"
                        If i = 0 Then
                            lstWhereFields.Items.Clear()
                        End If
                        If Not IsInList(lstWhereFields, ColumnName) Then
                            lstWhereFields.Items.Add(ColumnName)
                        End If
                    Case "ORDERBY FIELDS"
                        If i = 0 Then
                            chklstOrderBY.Items.Clear()
                        End If
                        If Not IsInCHKList(chklstOrderBY, ColumnName) Then
                            chklstOrderBY.Items.Add(ColumnName)
                        End If
                    Case Else
                        MsgBox("List not recognised")
                        Exit Sub
                End Select

            End If
        Next
    End Sub

    Sub MoveItemUp()
        Dim CurrentIDX As Integer
        Dim strCurrentItem As String
        Dim NewIDX As Integer


        CurrentIDX = lstFields.SelectedIndex

        If CurrentIDX > 0 Then
            strCurrentItem = lstFields.Items(CurrentIDX)
            NewIDX = CurrentIDX - 1
            lstFields.Items.RemoveAt(CurrentIDX)
            lstFields.Items.Insert(NewIDX, strCurrentItem)
            lstFields.SelectedIndex = NewIDX

        End If

    End Sub

    Sub MoveItemDown()
        Dim CurrentIDX As Integer
        Dim strCurrentItem As String
        Dim NewIDX As Integer

        CurrentIDX = lstFields.SelectedIndex

        If CurrentIDX < lstFields.Items.Count - 1 And CurrentIDX > -1 Then
            strCurrentItem = lstFields.Items(CurrentIDX)
            NewIDX = CurrentIDX + 1
            lstFields.Items.RemoveAt(CurrentIDX)
            lstFields.Items.Insert(NewIDX, strCurrentItem)
            lstFields.SelectedIndex = NewIDX
        End If
    End Sub

    Sub MoveOrderByItemUp()
        Dim CurrentIDX As Integer
        Dim strCurrentItem As String
        Dim NewIDX As Integer
        Dim IsSelected As Boolean

        CurrentIDX = chklstOrderBY.SelectedIndex

        If CurrentIDX > 0 Then
            IsSelected = chklstOrderBY.GetItemChecked(CurrentIDX)
            strCurrentItem = chklstOrderBY.Items(CurrentIDX)
            NewIDX = CurrentIDX - 1
            chklstOrderBY.Items.RemoveAt(CurrentIDX)
            chklstOrderBY.Items.Insert(NewIDX, strCurrentItem)
            chklstOrderBY.SelectedIndex = NewIDX
            chklstOrderBY.SetItemChecked(NewIDX, IsSelected)
        End If

    End Sub

    Sub MoveOrderByItemDown()
        Dim CurrentIDX As Integer
        Dim strCurrentItem As String
        Dim NewIDX As Integer
        Dim IsSelected As Boolean

        CurrentIDX = chklstOrderBY.SelectedIndex

        If CurrentIDX < chklstOrderBY.Items.Count - 1 And CurrentIDX > -1 Then
            IsSelected = chklstOrderBY.GetItemChecked(CurrentIDX)
            strCurrentItem = chklstOrderBY.Items(CurrentIDX)
            NewIDX = CurrentIDX + 1
            chklstOrderBY.Items.RemoveAt(CurrentIDX)
            chklstOrderBY.Items.Insert(NewIDX, strCurrentItem)
            chklstOrderBY.SelectedIndex = NewIDX
            chklstOrderBY.SetItemChecked(NewIDX, IsSelected)
        End If
    End Sub

    Private Sub btnSelectFields_Click(sender As Object, e As EventArgs) Handles btnSelectFields.Click
        SelectFields("SELECT FIELDS")

    End Sub

    Private Sub btnMoveUP_Click(sender As Object, e As EventArgs) Handles btnMoveUP.Click
        MoveItemUp()

    End Sub

    Private Sub btnMoveDOWN_Click(sender As Object, e As EventArgs) Handles btnMoveDOWN.Click
        MoveItemDown()

    End Sub

    Function BuildQueryFromSelection() As String
        Dim ColumnName As String
        Dim ColumnText As String
        Dim TableName As String
        Dim Sequence As String
        Dim FieldID As String
        Dim FieldsSelected As String
        Dim SelectPart As String
        Dim FinalQuery As String
        Dim OrderByFields As String
        Dim IsChecked As Boolean

        BuildQueryFromSelection = ""
        SelectPart = "SELECT "
        FieldsSelected = ""
        OrderByFields = ""
        TableName = txtTablename.Text
        For i As Integer = 0 To lstFields.Items.Count - 1
            ColumnName = lstFields.Items(i)
            ColumnText = dic_ColumnText(ColumnName)
            If FieldsSelected = "" Then
                FieldsSelected += Trim(ColumnName) & " AS """ & ColumnText & """"
            Else
                FieldsSelected += "," & Trim(ColumnName) & " AS """ & ColumnText & """"
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

    Private Sub btnSelectOrderBy_Click(sender As Object, e As EventArgs) Handles btnSelectOrderBy.Click
        SelectFields("ORDERBY FIELDS")
    End Sub

    Private Sub btnMoveOrderByUp_Click(sender As Object, e As EventArgs) Handles btnMoveOrderByUp.Click
        MoveOrderByItemUp()

    End Sub

    Private Sub btnMoveOrderByDown_Click(sender As Object, e As EventArgs) Handles btnMoveOrderByDown.Click
        MoveOrderByItemDown()

    End Sub

    Private Sub SQLQueryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SQLQueryToolStripMenuItem.Click
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
        App.Show()
        'App.Visible = True
        stsQueryBuilderLabel1.Text = ""
        Cursor = Cursors.Default
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

    Private Sub btnAddWhereFields_Click(sender As Object, e As EventArgs) Handles btnAddWhereFields.Click
        SelectFields("WHERE FIELDS")
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()

    End Sub
End Class
