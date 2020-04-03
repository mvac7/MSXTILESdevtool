<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InvertDialog
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
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.PatternCheckBox = New System.Windows.Forms.CheckBox
        Me.ColorCheckBox = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.BackColor = System.Drawing.Color.PaleGreen
        Me.OK_Button.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK_Button.Location = New System.Drawing.Point(170, 129)
        Me.OK_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(90, 32)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Invert!"
        Me.OK_Button.UseVisualStyleBackColor = False
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.BackColor = System.Drawing.Color.LightSalmon
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_Button.Location = New System.Drawing.Point(268, 135)
        Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(60, 26)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        Me.Cancel_Button.UseVisualStyleBackColor = False
        '
        'PatternCheckBox
        '
        Me.PatternCheckBox.AutoSize = True
        Me.PatternCheckBox.Checked = True
        Me.PatternCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.PatternCheckBox.Location = New System.Drawing.Point(133, 53)
        Me.PatternCheckBox.Margin = New System.Windows.Forms.Padding(4)
        Me.PatternCheckBox.Name = "PatternCheckBox"
        Me.PatternCheckBox.Size = New System.Drawing.Size(81, 22)
        Me.PatternCheckBox.TabIndex = 1
        Me.PatternCheckBox.Text = "Pattern"
        Me.PatternCheckBox.UseVisualStyleBackColor = True
        '
        'ColorCheckBox
        '
        Me.ColorCheckBox.AutoSize = True
        Me.ColorCheckBox.Checked = True
        Me.ColorCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ColorCheckBox.Location = New System.Drawing.Point(133, 83)
        Me.ColorCheckBox.Margin = New System.Windows.Forms.Padding(4)
        Me.ColorCheckBox.Name = "ColorCheckBox"
        Me.ColorCheckBox.Size = New System.Drawing.Size(67, 22)
        Me.ColorCheckBox.TabIndex = 2
        Me.ColorCheckBox.Text = "Color"
        Me.ColorCheckBox.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(178, 18)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "At what types of data?"
        '
        'InvertDialog
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(344, 172)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.ColorCheckBox)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.PatternCheckBox)
        Me.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "InvertDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Invert Tool"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents PatternCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ColorCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
