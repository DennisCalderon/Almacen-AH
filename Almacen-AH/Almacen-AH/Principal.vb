Public Class Principal
    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub IngresarNuevoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresarNuevoToolStripMenuItem.Click
        Dim form As New Usuarios
        form.ShowDialog()
    End Sub
End Class