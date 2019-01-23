Public Class Login

    ' TODO: inserte el código para realizar autenticación personalizada usando el nombre de usuario y la contraseña proporcionada 
    ' (Consulte https://go.microsoft.com/fwlink/?LinkId=35339).  
    ' El objeto principal personalizado se puede adjuntar al objeto principal del subproceso actual como se indica a continuación: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' donde CustomPrincipal es la implementación de IPrincipal utilizada para realizar la autenticación. 
    ' Posteriormente, My.User devolverá la información de identidad encapsulada en el objeto CustomPrincipal
    ' como el nombre de usuario, nombre para mostrar, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim resultado As Int16 = 0
        If (txtUser.Text <> "" And txtPassword.Text <> "") Then
            MDataBase.Login(txtUser.Text, txtPassword.Text, resultado)
            If resultado = 1 Then
                Dim form As New Principal
                Principal.Show()
                Me.Close()
            End If
        Else
            MsgBox("Ingrese los datos requeridos", MsgBoxStyle.Critical, "Atención!!!")
        End If

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

End Class
