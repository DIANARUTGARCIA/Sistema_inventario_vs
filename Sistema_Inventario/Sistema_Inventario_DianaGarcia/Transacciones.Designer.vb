<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Transacciones
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cb_Transacciones = New System.Windows.Forms.ComboBox()
        Me.txt_CodPro2 = New System.Windows.Forms.TextBox()
        Me.Btn_Agregar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Btn_Limpiar = New System.Windows.Forms.Button()
        Me.txt_Unidades = New System.Windows.Forms.TextBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Código Producto"
        '
        'cb_Transacciones
        '
        Me.cb_Transacciones.FormattingEnabled = True
        Me.cb_Transacciones.Location = New System.Drawing.Point(153, 90)
        Me.cb_Transacciones.Name = "cb_Transacciones"
        Me.cb_Transacciones.Size = New System.Drawing.Size(121, 21)
        Me.cb_Transacciones.TabIndex = 1
        '
        'txt_CodPro2
        '
        Me.txt_CodPro2.Location = New System.Drawing.Point(153, 46)
        Me.txt_CodPro2.Name = "txt_CodPro2"
        Me.txt_CodPro2.Size = New System.Drawing.Size(100, 20)
        Me.txt_CodPro2.TabIndex = 2
        '
        'Btn_Agregar
        '
        Me.Btn_Agregar.Location = New System.Drawing.Point(60, 187)
        Me.Btn_Agregar.Name = "Btn_Agregar"
        Me.Btn_Agregar.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Agregar.TabIndex = 3
        Me.Btn_Agregar.Text = "Agregar"
        Me.Btn_Agregar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Transacción"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(33, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Unidades"
        '
        'Btn_Limpiar
        '
        Me.Btn_Limpiar.Location = New System.Drawing.Point(222, 187)
        Me.Btn_Limpiar.Name = "Btn_Limpiar"
        Me.Btn_Limpiar.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Limpiar.TabIndex = 6
        Me.Btn_Limpiar.Text = "Limpiar"
        Me.Btn_Limpiar.UseVisualStyleBackColor = True
        '
        'txt_Unidades
        '
        Me.txt_Unidades.Location = New System.Drawing.Point(153, 122)
        Me.txt_Unidades.Name = "txt_Unidades"
        Me.txt_Unidades.Size = New System.Drawing.Size(100, 20)
        Me.txt_Unidades.TabIndex = 7
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Transacciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(409, 241)
        Me.Controls.Add(Me.txt_Unidades)
        Me.Controls.Add(Me.Btn_Limpiar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Btn_Agregar)
        Me.Controls.Add(Me.txt_CodPro2)
        Me.Controls.Add(Me.cb_Transacciones)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Transacciones"
        Me.Text = "Restriccion"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cb_Transacciones As ComboBox
    Friend WithEvents txt_CodPro2 As TextBox
    Friend WithEvents Btn_Agregar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Btn_Limpiar As Button
    Friend WithEvents txt_Unidades As TextBox
    Friend WithEvents ErrorProvider1 As ErrorProvider
End Class
