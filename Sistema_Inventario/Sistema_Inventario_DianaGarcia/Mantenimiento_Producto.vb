Imports System.Data.SqlClient
Imports System.DateTime
Public Class Mantenimiento_Producto
    Public query As String = ""   'Se declaran como variables globales,para no estar repitiendose codigo
    Public comando As SqlCommand
    Public conexion As New SqlConnection("server=AMADOR\SQLEXPRESS01;Initial Catalog =Sistema_Inventario;Integrated Security=true; ")
    Public sesion = Frm_Menu.usuario
    Public fecha = DateTime.Now

    Private Sub Btn_Agregar_Click(sender As Object, e As EventArgs) Handles Btn_Agregar.Click
        Try
            Dim llave As Boolean
            If Txt_CodProducto.Text <> Nothing And Txt_DesProducto.Text <> Nothing And Txt_PrecUnitario.Text <> Nothing Then
                LlavePrimaria(llave)
                If llave = True Then
                    MsgBox("El codigo del producto ya existe,ingrese uno diferente", vbExclamation, "Sistema Inventario")
                Else
                    Insertar() 'Llamado al procedimiento que contiene el codigo para insertar registros.
                End If
            Else
                MsgBox("!Falta de datos para ingresar producto!", vbExclamation, "Sistema Inventario")
            End If
        Catch ex As Exception
            MsgBox("Error " & ex.Message)
        End Try
    End Sub
    Private Sub LlavePrimaria(ByRef llave As Boolean) 'No iba en el requerimiento,pero creo que fue util ponerlo,lo que hace es busca si el codigo exite
        'el codigo que se inserta,pues en la base de datos en codigo tiene una primary key,igaul no se podra insertar,pero esto muestra mas a detalle el error
        Try
            Dim Datos As SqlDataReader
            conexion.Open()
            query = "select idProducto From tblProductos where idProducto = '" & Txt_CodProducto.Text & "'"
            comando = New SqlCommand(query, conexion)
            Datos = comando.ExecuteReader()
            If Datos.HasRows Then
                Datos.Read()
                llave = True
            Else
                llave = False
            End If
            conexion.Close()
            comando.Dispose()
        Catch ex As Exception
            MsgBox("Error " & ex.Message)
        End Try
    End Sub
    Private Sub Insertar() 'Procedimiento para insertar los registros
        Try
            Dim existencia As Integer = 0
            conexion.Open()
            query = "Insert into tblProductos values ('" & Txt_CodProducto.Text & "', '" & Txt_DesProducto.Text & "', " & existencia & ", " & Txt_PrecUnitario.Text & ", '" & fecha & "','" & sesion & "')"
            comando = New SqlCommand(query, conexion)
            comando.ExecuteNonQuery()
            MsgBox("Producto ingresado exitosamente", vbOKOnly, "Sistema Inventario")

            conexion.Close()
            comando.Dispose()
        Catch ex As Exception
            MsgBox("Error" & ex.Message)
        End Try
    End Sub

    Private Sub Btn_Limpiar_Click(sender As Object, e As EventArgs) Handles Btn_Limpiar.Click
        Txt_CodProducto.Clear()
        Txt_DesProducto.Clear()
        Txt_PrecUnitario.Clear()
        Txt_CodProducto.Enabled = True
        Btn_Actualizar.Enabled = False
    End Sub

    Private Sub Btn_Buscar_Click(sender As Object, e As EventArgs) Handles Btn_Buscar.Click
        Try
            If Txt_CodProducto.Text <> Nothing Then
                Buscar() 'Llama la procedimiento para buscar un registro
            Else
                MsgBox("!Debe de ingresar el codigo a buscar¡", vbExclamation, "Sistema Inventario")
            End If
        Catch ex As Exception
            MsgBox("Error " & ex.Message)
        End Try
    End Sub


    Private Sub Buscar() 'Procedimiento para buscar un registro
        Try
            Dim Datos As SqlDataReader
            conexion.Open()
            query = "select idProducto ,DescripcionProducto, precioUnitario From tblProductos where idProducto = '" & Txt_CodProducto.Text & "'"
            comando = New SqlCommand(query, conexion)
            Datos = comando.ExecuteReader()
            If Datos.HasRows Then
                Datos.Read()
                Txt_DesProducto.Text = Datos.GetValue(1)
                Txt_PrecUnitario.Text = Datos.GetValue(2)
                Btn_Actualizar.Enabled = True
                Txt_CodProducto.Enabled = False
            Else
                MsgBox("!Producto no encontrado!", vbExclamation, "Sistema Inventario")
            End If
            conexion.Close()
            comando.Dispose()
        Catch ex As Exception
            MsgBox("Error " & ex.Message)
        End Try
    End Sub

    'Evento al tocar la tecla f5 se abra el formulario de buscar por descripcion en el MDI
    Private Sub Txt_CodProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_CodProducto.KeyDown
        If e.KeyValue = Keys.F5 Then
            BuscarProducto.MdiParent = Frm_Menu
            BuscarProducto.Show()
        End If
    End Sub

    Private Sub Btn_Actualizar_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar.Click
        Try
            conexion.Open()
            query = "UPDATE tblProductos SET DescripcionProducto ='" & Txt_DesProducto.Text & "',precioUnitario =" & Txt_PrecUnitario.Text & "where idProducto ='" & Txt_CodProducto.Text & "'"
            comando = New SqlCommand(query, conexion)
            comando.ExecuteReader()
            MsgBox("!Producto Actualizado¡", vbOKOnly, "Sistema Inventario")
            conexion.Close()
            comando.Dispose()
        Catch ex As Exception
            MsgBox("Error " & ex.Message)
        End Try
    End Sub

    'Evento para permitir solo numeros con un punto decimal
    Private Sub Txt_PrecUnitario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_PrecUnitario.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            ErrorProvider1.SetError(Txt_PrecUnitario, Nothing)
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            ErrorProvider1.SetError(Txt_PrecUnitario, Nothing)
            e.Handled = False
        ElseIf e.KeyChar = "." And Not Txt_PrecUnitario.Text.IndexOf(".") Then
            ErrorProvider1.SetError(Txt_PrecUnitario, "Solo se acpeta un .")
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            ErrorProvider1.SetError(Txt_PrecUnitario, Nothing)
            e.Handled = False
        Else
            ErrorProvider1.SetError(Txt_PrecUnitario, "Ingrese un valor numerico")
            e.Handled = True
        End If
    End Sub

End Class