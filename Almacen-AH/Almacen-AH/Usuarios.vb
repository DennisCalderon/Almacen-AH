Public Class Usuarios
    Dim descripTipo As String
    Dim tipoguardado As Integer
    Private Sub Usuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarForm()
    End Sub
    Sub CargarForm()
        MDataBase.ObtenerUsuarios(dgvUsuarios)

        txtID.Text = Me.dgvUsuarios.Rows(0).Cells(0).Value.ToString()
        MDataBase.ObtenerDescripTipo(CInt(Me.dgvUsuarios.Rows(0).Cells(1).Value.ToString()), descripTipo)
        cboTiposUser.Text = descripTipo
        txtCuenta.Text = Me.dgvUsuarios.Rows(0).Cells(2).Value.ToString()
        txtPass.Text = Me.dgvUsuarios.Rows(0).Cells(3).Value.ToString()
        txtDNI.Text = Me.dgvUsuarios.Rows(0).Cells(4).Value.ToString()
        txtNombres.Text = Me.dgvUsuarios.Rows(0).Cells(5).Value.ToString()
        txtApellidos.Text = Me.dgvUsuarios.Rows(0).Cells(6).Value.ToString()
        txtTelefono.Text = Me.dgvUsuarios.Rows(0).Cells(7).Value.ToString()
        txtCorreo.Text = Me.dgvUsuarios.Rows(0).Cells(8).Value.ToString()
        txtDirecc.Text = Me.dgvUsuarios.Rows(0).Cells(9).Value.ToString()
        txtObs.Text = Me.dgvUsuarios.Rows(0).Cells(10).Value.ToString()

        btnEditar.Select()
        btnCancelar.Enabled = False
        btnGuardar.Enabled = False
    End Sub

    Private Sub dvgUsuarios_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsuarios.CellClick
        'MsgBox(Me.dvgUsuarios.Rows(e.RowIndex).Cells(0).Value.ToString())
        txtID.Text = Me.dgvUsuarios.Rows(e.RowIndex).Cells(0).Value.ToString()
        MDataBase.ObtenerDescripTipo(CInt(Me.dgvUsuarios.Rows(e.RowIndex).Cells(1).Value.ToString()), descripTipo)
        'MsgBox(Me.dvgUsuarios.Rows(0).Cells(1).Value.ToString())
        cboTiposUser.Text = descripTipo
        txtCuenta.Text = Me.dgvUsuarios.Rows(e.RowIndex).Cells(2).Value.ToString()
        txtPass.Text = Me.dgvUsuarios.Rows(e.RowIndex).Cells(3).Value.ToString()
        txtDNI.Text = Me.dgvUsuarios.Rows(e.RowIndex).Cells(4).Value.ToString()
        txtNombres.Text = Me.dgvUsuarios.Rows(e.RowIndex).Cells(5).Value.ToString()
        txtApellidos.Text = Me.dgvUsuarios.Rows(e.RowIndex).Cells(6).Value.ToString()
        txtTelefono.Text = Me.dgvUsuarios.Rows(e.RowIndex).Cells(7).Value.ToString()
        txtCorreo.Text = Me.dgvUsuarios.Rows(e.RowIndex).Cells(8).Value.ToString()
        txtDirecc.Text = Me.dgvUsuarios.Rows(e.RowIndex).Cells(9).Value.ToString()
        txtObs.Text = Me.dgvUsuarios.Rows(e.RowIndex).Cells(10).Value.ToString()
    End Sub

    Sub botones(ByVal x As Boolean)
        'txtID.Enabled = x
        cboTiposUser.Enabled = x
        txtCuenta.Enabled = x
        txtPass.Enabled = x
        txtDNI.Enabled = x
        txtNombres.Enabled = x
        txtApellidos.Enabled = x
        txtTelefono.Enabled = x
        txtCorreo.Enabled = x
        txtDirecc.Enabled = x
        txtObs.Enabled = x

    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        tipoguardado = 2
        botones(True)
        dgvUsuarios.Enabled = False

        btnNuevo.Enabled = False
        btnPermisosEsp.Enabled = False
        btnGuardar.Enabled = True
        btnCancelar.Enabled = True
    End Sub

    Private Sub cboTiposUser_MouseClick(sender As Object, e As MouseEventArgs) Handles cboTiposUser.MouseClick
        MDataBase.ObtenerTodosTiposUser(cboTiposUser)
        cboTiposUser.SelectedIndex = 2
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        CargarForm()
        botones(False)
        dgvUsuarios.Enabled = True

        btnGuardar.Enabled = False
        btnCancelar.Enabled = False
        btnNuevo.Enabled = True
        btnEditar.Enabled = True
        btnPermisosEsp.Enabled = True
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        tipoguardado = 1
        txtID.Text = ""

        txtCuenta.Text = ""
        txtPass.Text = ""
        txtDNI.Text = ""
        txtNombres.Text = ""
        txtApellidos.Text = ""
        txtTelefono.Text = ""
        txtCorreo.Text = ""
        txtDirecc.Text = ""
        txtObs.Text = ""
        botones(True)

        btnEditar.Enabled = False
        btnPermisosEsp.Enabled = False
        btnGuardar.Enabled = True
        btnCancelar.Enabled = True
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        MDataBase.Guardarusuario(IIf(txtID.Text = "", 0, txtID.Text), cboTiposUser.Text, txtCuenta.Text, txtPass.Text, txtDNI.Text, txtNombres.Text, txtApellidos.Text, txtTelefono.Text, txtCorreo.Text, txtDirecc.Text, txtObs.Text, tipoguardado)
        botones(False)
        dgvUsuarios.Enabled = True

        CargarForm()
    End Sub

End Class