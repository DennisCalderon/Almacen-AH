﻿Public Class Principal
    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub IngresarNuevoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresarNuevoToolStripMenuItem.Click
        Dim form As New Usuarios
        form.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim form As New Stock
        form.ShowDialog()
    End Sub
End Class