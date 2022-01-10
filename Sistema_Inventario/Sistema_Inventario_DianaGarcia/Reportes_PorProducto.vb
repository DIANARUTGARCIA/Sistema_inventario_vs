Imports System.Data.SqlClient
Public Class Transacciones_Producto
    Public query As String = ""   'Se declaran como variables globales,para no estar repitiendose codigo
    Public comando As SqlCommand
    Public conexion As New SqlConnection("server=AMADOR\SQLEXPRESS01;Initial Catalog =Sistema_Inventario;Integrated Security=true; ")


    Private Sub Btn_GenerarReporte_Click(sender As Object, e As EventArgs) Handles Btn_GenerarReporte.Click
        Try
            Dim respu As Integer = 0
            Dim resultado As Boolean
            If Txt_CodigoProducto.Text <> Nothing Then 'si el texbox de codigo no esta vacio,se correra el codigo

                Buscar(resultado) 'llamado del procedimiento con su variable de retorno
                If resultado = True Then 'si existe se ejecuta lo demas

                    Operacion() 'Llamado al procedimiento que muestra los datos en el datagridview
                Else
                    MsgBox("!Id del producto no existe!", vbExclamation, "Sistema Inventario")
                End If
            Else 'si el texbox esta vacio,no mostrara nada ,los demas texbox se dejaron en modo lectura,para que el usuario no ingrese nada
                MsgBox("!Debe de ingresar el codigo de producto!", vbExclamation, "Reportes")
            End If

        Catch ex As Exception
            MsgBox("Error " & ex.Message)
        End Try


    End Sub

    Private Sub Buscar(ByRef resultado As Boolean) 'Procedimiento para buscar un registro,devolvera true si existe el codigo,si no exite false
        Try
            Dim Datos As SqlDataReader
            conexion.Open()
            query = "select idProducto ,DescripcionProducto,existencia From tblProductos where idProducto = '" & Txt_CodigoProducto.Text & "'"
            comando = New SqlCommand(query, conexion)
            Datos = comando.ExecuteReader()
            If Datos.HasRows Then
                Datos.Read()
                resultado = True
                Txt_Descripcion.Text = Datos.GetValue(1)
                Txt_Existencia.Text = Datos.GetValue(2)
            Else
                resultado = False
            End If
            conexion.Close()
            comando.Dispose()
        Catch ex As Exception
            MsgBox("Error " & ex.Message)
        End Try
    End Sub

    Private Sub Operacion() 'Procedimiento que muestra el reporte por cada articulo
        Try
            Dim Datos As SqlDataReader
            Dim unidad_re As Integer
            Dim tipo_Transaccion As String
            conexion.Open()
            query = "SELECT  fechaTransaccion , tipoTransaccion,unidades from tblTransacciones where  idProducto ='" & Txt_CodigoProducto.Text & "'"
            comando = New SqlCommand(query, conexion)
            Datos = comando.ExecuteReader()
            DataGridView1.Rows.Clear()
            If Datos.HasRows Then
                While Datos.Read()
                    tipo_Transaccion = Datos.GetValue(1)
                    If tipo_Transaccion = "ENTRADA" Then
                        unidad_re += Datos.GetValue(2) 'suma cada transaccion cuando sea entrada
                        DataGridView1.Rows.Add(Datos.GetValue(0), Datos.GetValue(1), Datos.GetValue(2), "", unidad_re)

                    ElseIf tipo_Transaccion = "SALIDA" Then
                        unidad_re -= Datos.GetValue(2) 'resta cada transaccion cuando sea una salida
                        DataGridView1.Rows.Add(Datos.GetValue(0), Datos.GetValue(1), " ", Datos.GetValue(2), unidad_re)
                    End If
                End While
            End If
            conexion.Close()
            comando.Dispose()
        Catch ex As Exception
            MsgBox("Error " & ex.Message)
        End Try
    End Sub

    Private Sub Btn_Limpiar_Click(sender As Object, e As EventArgs) Handles Btn_Limpiar.Click
        Txt_CodigoProducto.Clear()
        Txt_Descripcion.Clear()
        Txt_Existencia.Clear()
        DataGridView1.Rows.Clear()
    End Sub
    'Talvez en examenes no me iba muy bien,pero en este proyecto le puse muchas ganas,talvez no este optimizado en algunas partes
    'pero fue la forma que se me ocurrio hacerlo.

End Class