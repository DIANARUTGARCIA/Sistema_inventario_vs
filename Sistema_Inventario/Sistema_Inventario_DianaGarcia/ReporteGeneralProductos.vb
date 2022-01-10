Imports System.Data.SqlClient
Public Class ReporteGeneralProductos
    Private Sub Btn_GenerarProducto_Click(sender As Object, e As EventArgs) Handles Btn_GenerarProducto.Click
        Try
            Dim query As String = ""
            Dim comando As SqlCommand
            Dim conexion As New SqlConnection("server=AMADOR\SQLEXPRESS01;Initial Catalog =Sistema_Inventario;Integrated Security=true; ")
            Dim Datos As SqlDataReader
            conexion.Open()
            query = "select idProducto, DescripcionProducto ,existencia,precioUnitario From tblProductos"
            comando = New SqlCommand(query, conexion)
            Datos = comando.ExecuteReader()
            DataGridView1.Rows.Clear()
            If Datos.HasRows Then
                While Datos.Read()
                    'Mostrara todos los registros que hay en la tabla de tblProductos
                    DataGridView1.Rows.Add(Datos.GetValue(0), Datos.GetValue(1), Datos.GetValue(2), Datos.GetValue(3))
                End While
            Else
                MsgBox("!No hay productos en la base de datos!", vbExclamation, "Reporte General")
            End If
            conexion.Close()
            comando.Dispose()
        Catch ex As Exception
            MsgBox("Error " & ex.Message)
        End Try
    End Sub

    Private Sub Btn_Limpiar_Click(sender As Object, e As EventArgs) Handles Btn_Limpiar.Click
        DataGridView1.Rows.Clear()
    End Sub
End Class