Imports MySql.Data.MySqlClient
Module MDataBase
    Const cadena_conexion As String = "Server=localhost;Port=3306;Database=almacen;Uid=root;"

    Public Sub Login(ByVal user As String, ByVal password As String, ByRef result As Integer)

        Using objCon As New MySqlConnection(cadena_conexion)
            Dim objCommand As New MySqlCommand
            Dim objReader As MySqlDataReader

            Try
                objCon.Open()
                objCommand = objCon.CreateCommand()
                objCommand.CommandText = "SELECT * FROM usuarios WHERE Cuentausuario = '" & user & "' AND PasswordUsuario= '" & password & "'"
                objReader = objCommand.ExecuteReader()

                If objReader.Read() Then
                    MsgBox("Bienvenido!", vbInformation, "Login Succeeded")
                    result = 1
                Else
                    MsgBox("Falla de autentificación", vbCritical, "Invalid Login")

                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                'objCommand.Dispose()
                'objReader.Close()
                objCon.Close()
            End Try
        End Using
    End Sub

    Public Sub ObtenerTodosTiposUser(ByRef cbo As ComboBox)
        Dim sql = "SELECT * from tiposusuario"
        Using con As New MySqlConnection(cadena_conexion)

            Dim command As New MySqlCommand(sql, con)
            Dim da As New MySqlDataAdapter
            da.SelectCommand = command
            Dim ds As New DataSet
            ds.Tables.Add("tiposusuario")
            da.Fill(ds.Tables("tiposusuario"))
            cbo.DataSource = ds.Tables("tiposusuario")
            cbo.DisplayMember = "DescripcionTipoUser"
        End Using
    End Sub
    Public Sub ObtenerUsuarios(ByRef dgvUsuarios As DataGridView)

        Using con As New MySqlConnection(cadena_conexion)
            Dim sql = "SELECT * from usuarios"
            Dim command As New MySqlCommand(sql, con)
            Dim da As New MySqlDataAdapter
            da.SelectCommand = command
            Dim dt As New DataTable
            da.Fill(dt)
            dgvUsuarios.DataSource = dt

            With dgvUsuarios
                .Columns(0).HeaderText = "ID"
                .Columns(1).HeaderText = "Tipo de Cuenta"
                .Columns(2).HeaderText = "Cuenta"
                .Columns(3).HeaderText = "Contraseña "
                .Columns(3).Visible = False
                .Columns(4).HeaderText = "DNI"
                .Columns(5).HeaderText = "Nombres"
                .Columns(6).HeaderText = "Apellidos"
                .Columns(7).HeaderText = "Teléfono"
                .Columns(8).HeaderText = "Correo"
                .Columns(9).HeaderText = "Dirección"
                .Columns(10).HeaderText = "Observaciones"
            End With
        End Using
    End Sub
    Public Sub ObtenerDescripTipo(ByVal IdTipo As Integer, ByRef descripTipo As String)

        Using objCon As New MySqlConnection(cadena_conexion)
            Dim objCommand As New MySqlCommand
            Dim objReader As MySqlDataReader

            Try
                objCon.Open()
                objCommand = objCon.CreateCommand()
                objCommand.CommandText = "SELECT * FROM tiposusuario WHERE IdTipoUser = '" & IdTipo & "'"
                objReader = objCommand.ExecuteReader()

                If objReader.Read() Then
                    descripTipo = objReader.Item("DescripcionTipoUser").ToString
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                'objCommand.Dispose()
                'objReader.Close()
                objCon.Close()
            End Try
        End Using
    End Sub
    Public Sub ObtenerIdTipo(ByVal descripTipo As String, ByRef IdTipo As Integer)

        Using objCon As New MySqlConnection(cadena_conexion)
            Dim objCommand As New MySqlCommand
            Dim objReader As MySqlDataReader

            Try
                objCon.Open()
                objCommand = objCon.CreateCommand()
                objCommand.CommandText = "SELECT * FROM tiposusuario WHERE DescripcionTipoUser = '" & descripTipo & "'"
                objReader = objCommand.ExecuteReader()

                If objReader.Read() Then
                    IdTipo = objReader.Item("IdTipoUser").ToString
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                'objCommand.Dispose()
                'objReader.Close()
                objCon.Close()
            End Try
        End Using
    End Sub
    Public Sub ObtenerUltimoIdUser(ByRef id As Integer)

        Using objCon As New MySqlConnection(cadena_conexion)
            Dim objCommand As New MySqlCommand
            Dim objReader As MySqlDataReader

            Try
                objCon.Open()
                objCommand = objCon.CreateCommand()
                objCommand.CommandText = "SELECT Max(IdUsuario) FROM usuarios"
                objReader = objCommand.ExecuteReader()

                If objReader.Read() Then
                    id = objReader.Item("Max(IdUsuario)").ToString
                    id = Val(id) + 1
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                'objCommand.Dispose()
                'objReader.Close()
                objCon.Close()
            End Try
        End Using
    End Sub
    Public Sub ConsultarNameUser(ByRef cuenta As String, ByRef verCuenta As Integer)

        Using objCon As New MySqlConnection(cadena_conexion)
            Dim objCommand As New MySqlCommand
            Dim objReader As MySqlDataReader

            Try
                objCon.Open()
                objCommand = objCon.CreateCommand()
                objCommand.CommandText = "SELECT CuentaUsuario FROM usuarios where CuentaUsuario= """ & cuenta & """ "
                objReader = objCommand.ExecuteReader()

                If objReader.Read() Then
                    verCuenta = 10 ' para ver si ya existe una cuenta con ese nombre
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                'objCommand.Dispose()
                'objReader.Close()
                objCon.Close()
            End Try
        End Using
    End Sub


    Public Sub Guardarusuario(ByVal id As Integer, ByVal tipoUser As String, ByVal cuenta As String, ByVal pass As String, ByVal dni As Integer, ByVal nombres As String, ByVal apellidos As String, ByVal telefono As String, ByVal correo As String, ByVal direccion As String, ByVal obs As String, ByVal tipoGuardado As Integer)
        Dim Idtipo As Integer, iden As Integer
        MDataBase.ObtenerIdTipo(tipoUser, Idtipo)
        Dim sql As String = ""
        If tipoGuardado = 2 Then
            sql = "UPDATE usuarios SET IdTipoUser= """ & Idtipo & """, CuentaUsuario= """ & cuenta & """, PasswordUsuario= """ & pass & """, DNIUsuario= """ & dni & """, NombreUsuario= """ & nombres & """, ApellidoUsuario= """ & apellidos & """, TelefonoUsuario= """ & telefono & """, CorreoUsuario= """ & correo & """, DireccionUsuario= """ & direccion & """, ComentarioUsuario= """ & obs & """ WHERE IdUsuario= """ & id & """ "
            Using objCon As New MySqlConnection(cadena_conexion)
                Dim objCommand As New MySqlCommand
                Dim objReader As MySqlDataReader

                Try
                    objCon.Open()
                    objCommand = objCon.CreateCommand()
                    objCommand.CommandText = sql
                    objReader = objCommand.ExecuteReader()

                Catch ex As Exception
                    MsgBox(ex.ToString)
                Finally
                    'objCommand.Dispose()
                    'objReader.Close()
                    objCon.Close()
                End Try
            End Using
            MsgBox("Datos Actualizados", vbInformation, "Exito")
        Else
            Dim verCuenta As Integer
            MDataBase.ConsultarNameUser(cuenta, verCuenta)
            If verCuenta = 10 Then
                MsgBox("El nombre ya esta siendo usado", vbCritical, "Atención!!!")
            Else
                MDataBase.ObtenerUltimoIdUser(iden)
                sql = "INSERT INTO usuarios (IdUsuario, IdTipoUser, CuentaUsuario, PasswordUsuario, DNIUsuario, NombreUsuario, ApellidoUsuario, TelefonoUsuario, CorreoUsuario, DireccionUsuario, ComentarioUsuario) VALUES (""" & iden & """, """ & Idtipo & """, """ & cuenta & """, """ & pass & """, """ & dni & """, """ & nombres & """, """ & apellidos & """, """ & telefono & """, """ & correo & """, """ & direccion & """, """ & obs & """)"
                Using objCon As New MySqlConnection(cadena_conexion)
                    Dim objCommand As New MySqlCommand
                    Dim objReader As MySqlDataReader

                    Try
                        objCon.Open()
                        objCommand = objCon.CreateCommand()
                        objCommand.CommandText = sql
                        objCommand.ExecuteNonQuery()

                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    Finally
                        'objCommand.Dispose()
                        'objReader.Close()
                        objCon.Close()
                    End Try
                End Using
                MsgBox("Usuario Registrado", vbInformation, "Exito")
            End If
        End If


    End Sub
End Module
