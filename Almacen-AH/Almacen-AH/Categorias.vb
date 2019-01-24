Public Class Categorias
    Private Sub Categorias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        formload()
    End Sub
    Sub formload()
        txtNombre.Enabled = False
        txtDescripcion.Enabled = False

        MCategorias.ObtenerTodasCategorias(dgvCategorias)
        txtCod.Text = Me.dgvCategorias.Rows(0).Cells(0).Value.ToString()
        txtNombre.Text = Me.dgvCategorias.Rows(0).Cells(1).Value.ToString()
        txtDescripcion.Text = Me.dgvCategorias.Rows(0).Cells(2).Value.ToString()

        btnNuevo.Enabled = True
        btnEditar.Enabled = True
        btnGuardar.Enabled = False
        btnCancelar.Enabled = False
    End Sub

    Private Sub dgvCategorias_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCategorias.CellClick
        txtCod.Text = Me.dgvCategorias.Rows(e.RowIndex).Cells(0).Value.ToString()
        txtNombre.Text = Me.dgvCategorias.Rows(e.RowIndex).Cells(1).Value.ToString()
        txtDescripcion.Text = Me.dgvCategorias.Rows(e.RowIndex).Cells(2).Value.ToString()
    End Sub
    Sub botones(ByVal b As Boolean)
        btnNuevo.Enabled = b
        btnEditar.Enabled = b
        btnGuardar.Enabled = Not b
        btnCancelar.Enabled = Not b
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        botones(False)
        txtCod.Text = ""
        txtNombre.Text = ""
        txtDescripcion.Text = ""
        txtNombre.Enabled = True
        txtDescripcion.Enabled = True
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        botones(False)
        txtNombre.Enabled = True
        txtDescripcion.Enabled = True
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        botones(True)

        If (txtNombre.Text <> "" And txtDescripcion.Text <> "") Then
            MCategorias.GuardarCategoria(txtCod.Text, txtNombre.Text, txtDescripcion.Text)
        End If

        formload()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        botones(True)
        formload()
    End Sub
End Class