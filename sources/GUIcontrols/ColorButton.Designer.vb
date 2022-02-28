<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ColorButton
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.TMScolorButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TMScolorButton
        '
        Me.TMScolorButton.BackColor = System.Drawing.Color.Black
        Me.TMScolorButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TMScolorButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.TMScolorButton.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMScolorButton.ForeColor = System.Drawing.Color.White
        Me.TMScolorButton.Location = New System.Drawing.Point(0, 0)
        Me.TMScolorButton.Name = "TMScolorButton"
        Me.TMScolorButton.Size = New System.Drawing.Size(24, 22)
        Me.TMScolorButton.TabIndex = 0
        Me.TMScolorButton.Text = "0"
        Me.TMScolorButton.UseVisualStyleBackColor = False
        '
        'ColorButton
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TMScolorButton)
        Me.Name = "ColorButton"
        Me.Size = New System.Drawing.Size(24, 22)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TMScolorButton As System.Windows.Forms.Button

End Class
