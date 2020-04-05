Public Class ViewSQL

    Private Sub ViewSQL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
    End Sub

    Sub PopulateForm(SQLQuery As String)
        txtSQLQuery.Text = SQLQuery
    End Sub

    Sub ExecuteQuery(DBName As String)
        'CALL SQL SELECT STATEMENT - passing the query through to get a datatable result.
        Dim myDAL As New SQLBuilderDAL
        Dim dt As DataTable

        If txtSQLQuery.Text <> "" Then
            dt = myDAL.ExecuteQuery(DBName, txtSQLQuery.Text)
            dgvOutput.DataSource = dt
        Else
            MsgBox("Please create a query first")
        End If


    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnExecuteQuery_Click(sender As Object, e As EventArgs) Handles btnExecuteQuery.Click
        ExecuteQuery(txtDBName.Text)
    End Sub
End Class