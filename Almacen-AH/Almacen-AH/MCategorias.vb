Imports MySql.Data.MySqlClient
Module MCategorias
    Const cadena_conexion As String = "Server=localhost;Port=3306;Database=almacen;Uid=root;"
    Public Sub ObtenerTodasCategorias(ByRef dgvproductos As DataGridView)

        Using con As New MySqlConnection(cadena_conexion)
            Dim sql = "SELECT * from categoriaproducto"
            Dim command As New MySqlCommand(sql, con)
            Dim da As New MySqlDataAdapter
            da.SelectCommand = command
            Dim dt As New DataTable
            da.Fill(dt)
            dgvproductos.DataSource = dt

            With dgvproductos
                .Columns(0).HeaderText = "Código"        ' "IdCatProd"
                .Columns(0).Width = 45
                .Columns(1).HeaderText = "Nombre"        ' "NombreCatProd"
                .Columns(1).Width = 100
                .Columns(2).HeaderText = "Descripcion"   ' "DescripciónCatProd"
                .Columns(2).Width = 86
            End With
        End Using
    End Sub
    Public Sub ObtenerCodCatProd(ByRef cod As String)

        Using objCon As New MySqlConnection(cadena_conexion)
            Dim objCommand As New MySqlCommand
            Dim objReader As MySqlDataReader

            Try
                objCon.Open()
                objCommand = objCon.CreateCommand()
                objCommand.CommandText = "SELECT Max(IdCatProd) FROM categoriaproducto"
                objReader = objCommand.ExecuteReader()

                If objReader.Read() Then
                    cod = objReader.Item("Max(IdCatProd)").ToString
                    'MsgBox(cod)
                    cod = Val(cod) + 1
                    For i As Integer = 1 To (5 - cod.Length)
                        cod = "0" & cod
                    Next
                    'MsgBox(cod)
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
    Public Sub GuardarCategoria(ByVal IdCatProd As String, ByVal NombreCatProd As String, ByVal DescripciónCatProd As String)


        Dim sql As String = ""
        If IdCatProd <> "" Then
            sql = "UPDATE categoriaproducto SET NombreCatProd= """ & NombreCatProd & """, DescripciónCatProd= """ & DescripciónCatProd & """   WHERE IdCatProd= """ & IdCatProd & """ "
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
            Dim cod As String
            MCategorias.ObtenerCodCatProd(cod)
            sql = "INSERT INTO categoriaproducto (IdCatProd, NombreCatProd, DescripciónCatProd) VALUES (""" & cod & """, """ & NombreCatProd & """, """ & DescripciónCatProd & """ )"

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
    End Sub
    Public Sub ObtenerTodasCategoriasLB(ByRef lbCat As ListBox)
        Dim sql = "SELECT * from categoriaproducto"
        Using con As New MySqlConnection(cadena_conexion)

            Dim command As New MySqlCommand(sql, con)
            Dim da As New MySqlDataAdapter
            da.SelectCommand = command
            Dim ds As New DataSet
            ds.Tables.Add("categoriaproducto")
            da.Fill(ds.Tables("categoriaproducto"))
            lbCat.DataSource = ds.Tables("categoriaproducto")
            lbCat.DisplayMember = "NombreCatProd"
        End Using
    End Sub
End Module
