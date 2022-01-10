Imports System.Data.SqlClient
Public Class Transacciones
    Public query As String = ""
    Public comando As SqlCommand
    Public conexion As New SqlConnection("server=AMADOR\SQLEXPRESS01;Initial Catalog =Sistema_Inventario;Integrated Security=true;")
    Private Sub Btn_Agregar_Click(sender As Object, e As EventArgs) Handles Btn_Agregar.Click
        Try
            Dim resultado As Integer = 0
            Dim resul As Double = False
            Dim existencia_unidades As Integer = 0
            Dim seleccion As Integer
            Dim Tipo_Transaccion As String = ""
            seleccion = cb_Transacciones.SelectedIndex
            'Condicion si los texboxs no estan vacios,se ejecutara el siguiente codigo
            If txt_CodPro2.Text <> Nothing And cb_Transacciones.Text <> Nothing And txt_Unidades.Text <> Nothing Then
                Busqueda_CodProducto(resultado) 'Llamado al procedimiento de busqueda de codigo de producto
                If resultado = 1 Then  'Si el resultado es 1 significa que el codigo product existe ,y se ejecutara el siguiente codigo
                    Select Case seleccion
                        Case 0  'ENTRADA
                            Insertar_TblTransaccion() 'llamado de procedimiento que inserta los datos en la tabla transacciones
                            Sumar_Existencia() 'Llamada al procedimiento que actuliza la tabla productos
                        Case 1 'SALIDA
                            Restar_Existencia(resul, existencia_unidades)
                            If resul = True Then
                                Insertar_TblTransaccion() 'Actualiza la tabla tblProductos con la resta de unidades
                                SALIDA_RestarExistencia()

                            Else
                                MsgBox("No hay suficiente existencia,unidades existentes :" & existencia_unidades, vbOKOnly, "Transacciones")
                            End If
                    End Select
                ElseIf resultado = 2 Then 'Si el resultado es 2 significa que no existe y no se hara nda 
                    MsgBox("Código de Producto no Existe", vbExclamation, "Transacciones")
                End If
            Else
                'Si alguno de los texbox esta vacio
                MsgBox("!Faltan datos para la transaccion¡", vbExclamation, "Transacciones")
            End If

        Catch ex As Exception
            MsgBox("Error" & ex.Message)
        End Try
    End Sub

    Private Sub Insertar_TblTransaccion() 'Procedimiento para insertar los datos en la tabla  de tblTransacciones
        Try
            Dim Tipo_Transaccion As String = ""
            Dim seleccion As Integer
            seleccion = cb_Transacciones.SelectedIndex
            Dim unidades As Integer = 0
            Dim fecha As Date
            Dim sesion As String = " "
            sesion = Frm_Menu.usuario
            fecha = DateTime.Now
            Select Case seleccion
                Case 0
                    Tipo_Transaccion = "ENTRADA"
                Case 1
                    Tipo_Transaccion = "SALIDA"
            End Select
            conexion.Open()
            query = "Insert into tblTransacciones values ('" & txt_CodPro2.Text & "'," & txt_Unidades.Text & ",'" & Tipo_Transaccion & "','" & sesion & "','" & fecha & "')"
            comando = New SqlCommand(query, conexion)
            comando.ExecuteNonQuery()
            MsgBox("Producto ingresado exitosamente", vbOKOnly, "Transacciones")
            conexion.Close()
            comando.Dispose()
        Catch ex As Exception
            MsgBox("Error" & ex.Message)
        End Try
    End Sub
    Private Sub Busqueda_CodProducto(ByRef resultado As Integer) 'Procedimiento para buscar el codigo del producto si existe o no
        Try
            Dim Datos As SqlDataReader
            conexion.Open()
            query = "select idProducto  From tblProductos where idProducto = '" & txt_CodPro2.Text & "'"
            comando = New SqlCommand(query, conexion)
            Datos = comando.ExecuteReader()
            If Datos.HasRows Then
                Datos.Read()
                resultado = 1 'Resultado tomara el valor de uno si el codigo de producto existe
            Else
                resultado = 2 'Si el codigo del producto no existe resultado sera igual a 2
            End If
            conexion.Close()
            comando.Dispose()
        Catch ex As Exception
            MsgBox("Error" & ex.Message)
        End Try
    End Sub

    'Procedimiento con valores por referencia donde devuelve en el resultao si la existencia es mayor que las unidades o no
    'tambien devuelve la cantidad de existencia.
    Private Sub Restar_Existencia(ByRef resultado As Boolean, ByRef existencia As Integer)
        Try
            Dim Datos As SqlDataReader
            conexion.Open()
            query = "select existencia  From tblProductos where idProducto = '" & txt_CodPro2.Text & "'"
            comando = New SqlCommand(query, conexion)
            Datos = comando.ExecuteReader()
            If Datos.HasRows Then
                Datos.Read()
                existencia = Datos.GetValue(0)
                If existencia >= txt_Unidades.Text Then
                    resultado = True
                Else
                    resultado = False
                End If
            End If
            conexion.Close()
            comando.Dispose()
        Catch ex As Exception
            MsgBox("Error" & ex.Message)
        End Try
    End Sub


    Private Sub Sumar_Existencia() 'Procedimiento para sumar las unidades en la tabla tblProductos ,cuando sea una entrada
        Try
            conexion.Open()
            query = "Update tblProductos set existencia = existencia + " & txt_Unidades.Text & " Where idProducto ='" & txt_CodPro2.Text & "'"
            comando = New SqlCommand(query, conexion)
            comando.ExecuteReader()
            conexion.Close()
            comando.Dispose()
        Catch ex As Exception
            MsgBox("Error" & ex.Message)
        End Try
    End Sub

    Private Sub SALIDA_RestarExistencia() 'Procedimiento para restar las unidades en la tabla tblProductos ,cuando sea una salida
        Try
            conexion.Open()
            query = "Update tblProductos set existencia = existencia - " & txt_Unidades.Text & " Where idProducto ='" & txt_CodPro2.Text & "'"
            comando = New SqlCommand(query, conexion)
            comando.ExecuteReader()
            conexion.Close()
            comando.Dispose()
        Catch ex As Exception
            MsgBox("Error" & ex.Message)
        End Try
    End Sub

    Private Sub Transacciones_Load(sender As Object, e As EventArgs) Handles Me.Load 'Agrgacion de items en el combobox
        With cb_Transacciones.Items
            .Add("ENTRADA")
            .Add("SALIDA")
        End With
    End Sub

    'Limpia los botones del formulario
    Private Sub Btn_Limpiar_Click(sender As Object, e As EventArgs) Handles Btn_Limpiar.Click
        txt_CodPro2.Clear()
        txt_Unidades.Clear()
        cb_Transacciones.SelectedIndex = -1
    End Sub

    'Evento keypress para que el usuario solo ingrese datos numericos
    Private Sub txt_Unidades_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Unidades.KeyPress
        Try
            If Not IsNumeric(e.KeyChar) And Asc(e.KeyChar) <> 13 And Asc(e.KeyChar) <> 8 Then
                ErrorProvider1.SetError(txt_Unidades, "Ingrese un valor numerico")
                e.Handled = True
            Else
                ErrorProvider1.SetError(txt_Unidades, Nothing)
            End If
        Catch ex As Exception
            MsgBox("Error" & ex.Message)
        End Try
    End Sub

End Class