Public Class Stock
    Dim descripCat As String
    Private Sub Stock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargaForm()
    End Sub
    Sub CargaForm()
        btnCancelar.Enabled = False
        btnGuardar.Enabled = False

        MProductos.ObtenerTodosProductos(dgvProductos)

        txt(False)

        txtCod.Text = Me.dgvProductos.Rows(0).Cells(0).Value.ToString()
        MProductos.ObtenerDescripCategoria(Me.dgvProductos.Rows(0).Cells(1).Value.ToString(), descripCat)
        cboCategoria.Text = descripCat
        txtDescripcion.Text = Me.dgvProductos.Rows(0).Cells(2).Value.ToString()
        txtMarca.Text = Me.dgvProductos.Rows(0).Cells(3).Value.ToString()
        txtPrecio.Text = Me.dgvProductos.Rows(0).Cells(4).Value.ToString()
        txtExistencias.Text = Me.dgvProductos.Rows(0).Cells(5).Value.ToString()
    End Sub

    Private Sub cboCategoria_MouseClick(sender As Object, e As MouseEventArgs) Handles cboCategoria.MouseClick
        MProductos.ObtenerTodasCategorias(cboCategoria)
    End Sub

    Private Sub dgvProductos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellClick
        txtCod.Text = Me.dgvProductos.Rows(e.RowIndex).Cells(0).Value.ToString()
        MProductos.ObtenerDescripCategoria(Me.dgvProductos.Rows(e.RowIndex).Cells(1).Value.ToString(), descripCat)
        cboCategoria.Text = descripCat
        txtDescripcion.Text = Me.dgvProductos.Rows(e.RowIndex).Cells(2).Value.ToString()
        txtMarca.Text = Me.dgvProductos.Rows(e.RowIndex).Cells(3).Value.ToString()
        txtPrecio.Text = Me.dgvProductos.Rows(e.RowIndex).Cells(4).Value.ToString()
        txtExistencias.Text = Me.dgvProductos.Rows(e.RowIndex).Cells(5).Value.ToString()
    End Sub

    Sub txt(ByVal x As Boolean)
        'txtCod.Enabled = x
        cboCategoria.Enabled = x
        txtDescripcion.Enabled = x
        txtMarca.Enabled = x
        txtPrecio.Enabled = x
        txtExistencias.Enabled = x
    End Sub

    Sub botones(ByVal b As Boolean)
        btnNuevo.Enabled = b
        btnEditar.Enabled = b
        btnGuardar.Enabled = Not b
        btnCancelar.Enabled = Not b
        btnAgregarCategoria.Enabled = b
    End Sub
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        botones(False)
        txt(True)

        txtCod.Text = ""
        cboCategoria.Text = ""
        txtDescripcion.Text = ""
        txtMarca.Text = ""
        txtPrecio.Text = ""
        txtExistencias.Text = ""
        cboCategoria.Select()

        dgvProductos.Enabled = False
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        botones(False)
        txt(True)

        dgvProductos.Enabled = False
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        botones(True)
        txt(False)
        If (cboCategoria.Text <> "" And txtDescripcion.Text <> "" And txtMarca.Text <> "" And txtPrecio.Text <> "" And txtExistencias.Text <> "") Then
            MProductos.GuardarProducto(txtCod.Text, cboCategoria.Text, txtDescripcion.Text, txtMarca.Text, txtPrecio.Text, txtExistencias.Text)
        Else
            MsgBox("Debe de llenar todos los campos para poder registrar el Item", vbCritical, "Error")
        End If

        CargaForm()
        dgvProductos.Enabled = True
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        botones(True)
        txt(False)
        CargaForm()
        dgvProductos.Enabled = True
    End Sub

    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar) ' solo permite números
    End Sub

    Private Sub txtExistencias_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtExistencias.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar) ' solo permite números
    End Sub
End Class