Public Class MDIQueryBuilder
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()

    End Sub

    Private Sub QueryBuilderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QueryBuilderToolStripMenuItem.Click
        'Call Query Builder Form:
        Cursor = Cursors.WaitCursor
        Dim Det As New SimpleQueryBuilder.SQLBuilder
        Dim SelectedID As Integer

        Det.Visible = False
        'Det.GetParms(GlobalSession, GlobalParms)
        SelectedID = 0
        Det.PopulateForm()
        Det.Width = 580
        Det.Height = 810
        Det.Show()
        Det.Visible = True

        Cursor = Cursors.Default
    End Sub
End Class