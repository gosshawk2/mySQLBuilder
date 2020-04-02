Public Class WherePart
    Private _WhereField As String
    Dim WhereConditions As String

    Public Property WhereField As String
        Get
            Return _WhereField
        End Get
        Set(value As String)
            _WhereField = value
        End Set
    End Property

    Private Sub WherePart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
    End Sub

    Sub PopulateForm(ByRef FieldList As String())
        'Populate Field List from previous form:
        'lbSelectedWHEREFields.Items.AddRange(FieldList)
        lbSelectedWHEREFields.Items.AddRange(FieldList)
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

    Function AddCondition() As String
        '****************************************************** Add Condition to list: *****************************************************
        Dim strCondition As String
        Dim strWhereField1 As String
        Dim strWhereField2 As String
        Dim intSelectedFieldIDX As Integer
        Dim strOperator As String
        Dim strValue As String
        Dim strJoin As String
        Dim Position As Integer
        Dim Message As String

        'Perhaps we need the db field type here to validate the value entered by the user ???
        strValue = ""
        AddCondition = ""
        strCondition = ""
        intSelectedFieldIDX = lbSelectedWHEREFields.SelectedIndex
        If intSelectedFieldIDX = -1 Then
            MsgBox("Please select a field first")
            Exit Function
        End If
        If lbSelectedWHEREFields.Items.Count > 0 Then
            'grab selected field:
            strWhereField1 = lbSelectedWHEREFields.Items(intSelectedFieldIDX)
        Else
            MsgBox("Dont forget to press the Add Field button.")
            Exit Function
        End If

        If lbSelectedWHEREFields.Items.Count > 1 Then
            'just an idea at the moment:
            strWhereField2 = lbSelectedWHEREFields.Items(1)
        End If
        strOperator = ""
        strJoin = ""
        If strWhereField1 <> "" Then
            If txtOperator.Text <> "" Then
                strOperator = txtOperator.Text
                strValue = txtValue.Text
                If UCase(strOperator) = "LIKE" Then
                    'Test if any wildcard used ??
                    strValue = "Like " & "'" & strValue & "'"
                    'Need to wrap chars around the value: if user wants wildcards then will have to insert themselves.
                End If
                'Check if any other conditions exist:
                If lbConditions.Items.Count > 0 Then
                    If rbAND.Checked Then
                        strJoin = " AND "
                    End If
                    If rbOR.Checked Then
                        strJoin = " OR "
                    End If
                End If
                If cbIncludeSingleQuote.Checked Then
                    strValue = "'" & strValue & "'"
                End If
                If strValue = "" Then
                    MsgBox("Please enter a value")
                    Exit Function
                End If
                strCondition += strJoin & strWhereField1 & " " & strOperator & " " & strValue
                If Not IsInList(lbConditions, strCondition) Then
                    lbConditions.Items.Add(strCondition)
                End If
                WhereConditions += strCondition
                Return strCondition
            Else
                MsgBox("No operator or value entered.")
                Exit Function
            End If
        End If

    End Function

    Private Sub lbSelectedWHEREFields_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbSelectedWHEREFields.SelectedIndexChanged
        Dim IDX As Integer

        IDX = lbSelectedWHEREFields.SelectedIndex
        Me.WhereField = lbSelectedWHEREFields.Items(IDX)

    End Sub

    Private Sub btnAddWhere_Click(sender As Object, e As EventArgs) Handles btnAddWhere.Click
        'pass list back
        If lbConditions.Items.Count > 0 Then
            SQLBuilder.myWhereConditions.GetMyWhereCondtions = ""
            For i As Integer = 0 To lbConditions.Items.Count - 1
                SQLBuilder.myWhereConditions.GetMyWhereCondtions += lbConditions.Items(i)
            Next
        Else
            MsgBox("No conditions were entered")
        End If

        Close()

    End Sub

    Private Sub btnAddCondition_Click(sender As Object, e As EventArgs) Handles btnAddCondition.Click
        AddCondition()

    End Sub

    Private Sub btnRemoveCondition_Click(sender As Object, e As EventArgs) Handles btnRemoveCondition.Click
        Dim IDX As Integer

        IDX = lbConditions.SelectedIndex
        If IDX > -1 Then
            lbConditions.Items.RemoveAt(IDX)
        End If

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()

    End Sub

    Private Sub cboOperators_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboOperators.SelectedIndexChanged
        Dim IDX As Integer
        Dim ItemName As String

        IDX = cboOperators.SelectedIndex
        If IDX > -1 Then
            ItemName = cboOperators.Items(IDX)
            If ItemName <> "" Then
                txtOperator.Text = ItemName
            End If
        End If

    End Sub
End Class