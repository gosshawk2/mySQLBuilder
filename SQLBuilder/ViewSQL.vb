Public Class ViewSQL
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()

    End Sub

    Private Sub ViewSQL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
    End Sub

    Sub PopulateForm(SQLQuery As String)
        txtSQLQuery.Text = SQLQuery
    End Sub
End Class