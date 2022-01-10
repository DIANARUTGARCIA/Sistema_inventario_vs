Imports System.Data.SqlClient
Public Class Frm_Login
    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click
        Try
            Dim comando As SqlCommand
            Dim datos As SqlDataReader
            Dim conexion As New SqlConnection("server=AMADOR\SQLEXPRESS01;Initial Catalog= Sistema_Inventario;Integrated Security=true;")
            Dim strsql As String = ""

            conexion.Open()

            strsql = "select * from tblUsuarios where username = '" & Txt_Username.Text & "' and clave = '" & Txt_Password.Text & "'"

            comando = New SqlCommand(strsql, conexion)
            datos = comando.ExecuteReader
            If datos.HasRows Then
                habilitarOpcionesMenuPrincipal()
                MsgBox("Bienvenido al sistema", vbOKOnly, "Login")

                Frm_Menu.usuario = Txt_Username.Text
                Me.Close()
            Else
                MsgBox("Usuario/Password incorrecto", 64, "Login")
            End If

            conexion.Close()
            datos.Close()
            comando.Dispose()

        Catch ex As Exception
            MsgBox("Error " & ex.Message)

        End Try
    End Sub
    Private Sub habilitarOpcionesMenuPrincipal()
        Frm_Menu.MenuStrip1.Items(1).Enabled = True
        Frm_Menu.MenuStrip1.Items(2).Enabled = True
        Frm_Menu.MenuStrip1.Items(3).Enabled = True
    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        Me.Close()
    End Sub
End Class
