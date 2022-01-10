Imports System.Data.SqlClient
Public Class BuscarProducto
    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim Fila As Integer
        Fila = DataGridView1.CurrentRow.Index 'Saber el numero de filas seleciionado
        Mantenimiento_Producto.Txt_CodProducto.Text = DataGridView1.Rows(Fila).Cells(0).Value 'se manda la informacion de la columna 0 al primer texbox del form mantenimiento
        Mantenimiento_Producto.Txt_DesProducto.Text = DataGridView1.Rows(Fila).Cells(1).Value
        Mantenimiento_Producto.Txt_PrecUnitario.Text = DataGridView1.Rows(Fila).Cells(3).Value
        Mantenimiento_Producto.Btn_Actualizar.Enabled = True
        Mantenimiento_Producto.Txt_CodProducto.Enabled = False
        Me.Close()
    End Sub

    Private Sub txt_BusDesProducto_TextChanged(sender As Object, e As EventArgs) Handles txt_BusDesProducto.TextChanged
        Dim Datos As SqlDataReader
        Dim query As String = " "
        Dim comando As SqlCommand
        Dim conexion As New SqlConnection("server=AMADOR\SQLEXPRESS01;Initial Catalog =Sistema_Inventario;Integrated Security=true; ")
        conexion.Open()
        query = "select idProducto ,DescripcionProducto,existencia, precioUnitario From tblProductos where DescripcionProducto LIKE  '%" & txt_BusDesProducto.Text & "%'"
        comando = New SqlCommand(query, conexion)
        Datos = comando.ExecuteReader()
        DataGridView1.Rows.Clear()
        If Datos.HasRows Then
            While Datos.Read()
                DataGridView1.Rows.Add(Datos.GetValue(0), Datos.GetValue(1), Datos.GetValue(2), Datos.GetValue(3))
            End While
        Else
            DataGridView1.Rows.Clear()
        End If
        If txt_BusDesProducto.Text = Nothing Then
            DataGridView1.Rows.Clear()
        End If
        conexion.Close()

    End Sub

End Class