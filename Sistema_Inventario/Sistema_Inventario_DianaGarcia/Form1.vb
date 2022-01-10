Public Class Frm_Menu
    Public usuario As String = ""
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            MenuStrip1.Items(1).Enabled = False
            MenuStrip1.Items(2).Enabled = False
            MenuStrip1.Items(2).Enabled = False
            MenuStrip1.Items(3).Enabled = False
        Catch ex As Exception

            MsgBox("Error " & ex.Message)
        End Try

    End Sub
    Private Sub ToStMenItem_Login_Click(sender As Object, e As EventArgs) Handles ToStMenItem_Login.Click
        Try
            Frm_Login.MdiParent = Me
            Frm_Login.Show()
        Catch ex As Exception
            MsgBox("Error " & ex.Message)
        End Try
    End Sub

    Private Sub ToStMenItem_Salir_Click(sender As Object, e As EventArgs) Handles ToStMenItem_Salir.Click
        Me.Close()
    End Sub

    Private Sub MantenimientoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientoToolStripMenuItem.Click
        Try
            Mantenimiento_Producto.MdiParent = Me
            Mantenimiento_Producto.Show()
        Catch ex As Exception
            MsgBox("Error " & ex.Message)
        End Try
    End Sub

    Private Sub ENTRADASALIDAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ENTRADASALIDAToolStripMenuItem.Click
        Try
            Transacciones.MdiParent = Me
            Transacciones.Show()
        Catch ex As Exception
            MsgBox("Error " & ex.Message)
        End Try
    End Sub

    Private Sub ReporteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteToolStripMenuItem.Click
        Try
            ReporteGeneralProductos.MdiParent = Me
            ReporteGeneralProductos.Show()
        Catch ex As Exception
            MsgBox("Error " & ex.Message)
        End Try
    End Sub

    Private Sub ReporteDeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeToolStripMenuItem.Click
        Try

            Transacciones_Producto.MdiParent = Me 'Es el formulario Reportes_PorProducto
            Transacciones_Producto.Show()

        Catch ex As Exception

        End Try
    End Sub
End Class
