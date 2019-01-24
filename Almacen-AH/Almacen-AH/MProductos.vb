Imports MySql.Data.MySqlClient
Module MProductos
    Const cadena_conexion As String = "Server=localhost;Port=3306;Database=almacen;Uid=root;"
    Public Sub ObtenerTodosProductos(ByRef dgvproductos As DataGridView)

        Using con As New MySqlConnection(cadena_conexion)
            Dim sql = "SELECT * from productos"
            Dim command As New MySqlCommand(sql, con)
            Dim da As New MySqlDataAdapter
            da.SelectCommand = command
            Dim dt As New DataTable
            da.Fill(dt)
            dgvproductos.DataSource = dt

            With dgvproductos
                .Columns(0).HeaderText = "Código"           ' "CodProd"
                .Columns(0).Width = 45
                .Columns(1).HeaderText = "Cat."         ' "IdCatProd"
                .Columns(1).Width = 45
                .Columns(2).HeaderText = "Descripcion"   ' "DescripcionProd"
                .Columns(2).Width = 78
                .Columns(3).HeaderText = "Marca "        ' "MarcaProd "
                .Columns(3).Width = 45
                .Columns(4).HeaderText = "Precio"        ' "PrecioProd"
                .Columns(4).Width = 50
                .Columns(5).HeaderText = "Stock"         ' "StockProd"
                .Columns(5).Width = 40
            End With
        End Using
    End Sub
    Public Sub ObtenerTodasCategorias(ByRef cbo As ComboBox)
        Dim sql = "SELECT * from categoriaproducto"
        Using con As New MySqlConnection(cadena_conexion)

            Dim command As New MySqlCommand(sql, con)
            Dim da As New MySqlDataAdapter
            da.SelectCommand = command
            Dim ds As New DataSet
            ds.Tables.Add("categoriaproducto")
            da.Fill(ds.Tables("categoriaproducto"))
            cbo.DataSource = ds.Tables("categoriaproducto")
            cbo.DisplayMember = "NombreCatProd"
        End Using
    End Sub
    Public Sub ObtenerDescripCategoria(ByVal IdTipo As String, ByRef descripCat As String)

        Using objCon As New MySqlConnection(cadena_conexion)
            Dim objCommand As New MySqlCommand
            Dim objReader As MySqlDataReader

            Try
                objCon.Open()
                objCommand = objCon.CreateCommand()
                objCommand.CommandText = "SELECT * FROM categoriaproducto WHERE IdCatProd = '" & IdTipo & "'"
                objReader = objCommand.ExecuteReader()

                If objReader.Read() Then
                    descripCat = objReader.Item("NombreCatProd").ToString
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
    Public Sub ObtenerIdCatProd(ByVal nombreCatProd As String, ByRef IdCatProd As String)

        Using objCon As New MySqlConnection(cadena_conexion)
            Dim objCommand As New MySqlCommand
            Dim objReader As MySqlDataReader

            Try
                objCon.Open()
                objCommand = objCon.CreateCommand()
                objCommand.CommandText = "SELECT * FROM categoriaproducto WHERE NombreCatProd = '" & nombreCatProd & "'"
                objReader = objCommand.ExecuteReader()

                If objReader.Read() Then
                    IdCatProd = objReader.Item("IdCatProd").ToString
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
    Public Sub ObtenerIdTipo(ByVal nombreCatProd As String, ByRef IdCatProd As String)

        Using objCon As New MySqlConnection(cadena_conexion)
            Dim objCommand As New MySqlCommand
            Dim objReader As MySqlDataReader

            Try
                objCon.Open()
                objCommand = objCon.CreateCommand()
                objCommand.CommandText = "SELECT * FROM categoriaproducto WHERE NombreCatProd = '" & nombreCatProd & "'"
                objReader = objCommand.ExecuteReader()

                If objReader.Read() Then
                    IdCatProd = objReader.Item("IdCatProd").ToString
                    'MsgBox(IdCatProd)
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
    Public Sub ObtenerCodProd(ByRef cod As String)

        Using objCon As New MySqlConnection(cadena_conexion)
            Dim objCommand As New MySqlCommand
            Dim objReader As MySqlDataReader

            Try
                objCon.Open()
                objCommand = objCon.CreateCommand()
                objCommand.CommandText = "SELECT Max(CodProd) FROM productos"
                objReader = objCommand.ExecuteReader()

                If objReader.Read() Then
                    cod = objReader.Item("Max(CodProd)").ToString
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
    Public Sub GuardarProducto(ByVal CodProd As String, ByVal nombreCatProd As String, ByVal DescripcionProd As String, ByVal MarcaProd As String, ByVal PrecioProd As Double, ByVal StockProd As Integer)

        Dim IdCatProd As String
        MProductos.ObtenerIdTipo(nombreCatProd, IdCatProd)

        Dim sql As String = ""
        If CodProd <> "" Then
            sql = "UPDATE productos SET IdCatProd= """ & IdCatProd & """, DescripcionProd= """ & DescripcionProd & """, MarcaProd= """ & MarcaProd & """, PrecioProd= """ & PrecioProd & """, StockProd= """ & StockProd & """  WHERE CodProd= """ & CodProd & """ "
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
            MProductos.ObtenerCodProd(cod)
            sql = "INSERT INTO productos (CodProd, IdCatProd, DescripcionProd, MarcaProd, PrecioProd, StockProd) VALUES (""" & cod & """, """ & IdCatProd & """, """ & DescripcionProd & """, """ & MarcaProd & """, """ & PrecioProd & """, """ & StockProd & """ )"

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
End Module
