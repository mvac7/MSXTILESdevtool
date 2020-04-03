<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangeColorForm
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
        Me.toButton = New System.Windows.Forms.Button
        Me.oldcolorButton = New System.Windows.Forms.Button
        Me.newcolorButton = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'toButton
        '
        Me.toButton.BackColor = System.Drawing.Color.PaleGreen
        Me.toButton.Location = New System.Drawing.Point(141, 67)
        Me.toButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.toButton.Name = "toButton"
        Me.toButton.Size = New System.Drawing.Size(54, 30)
        Me.toButton.TabIndex = 17
        Me.toButton.Text = "to"
        Me.toButton.UseVisualStyleBackColor = False
        '
        'oldcolorButton
        '
        Me.oldcolorButton.BackColor = System.Drawing.Color.White
        Me.oldcolorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.oldcolorButton.Location = New System.Drawing.Point(81, 67)
        Me.oldcolorButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.oldcolorButton.Name = "oldcolorButton"
        Me.oldcolorButton.Size = New System.Drawing.Size(54, 30)
        Me.oldcolorButton.TabIndex = 18
        Me.oldcolorButton.Text = "old"
        Me.oldcolorButton.UseVisualStyleBackColor = False
        '
        'newcolorButton
        '
        Me.newcolorButton.BackColor = System.Drawing.Color.White
        Me.newcolorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.newcolorButton.Location = New System.Drawing.Point(201, 67)
        Me.newcolorButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.newcolorButton.Name = "newcolorButton"
        Me.newcolorButton.Size = New System.Drawing.Size(54, 30)
        Me.newcolorButton.TabIndex = 19
        Me.newcolorButton.Text = "new"
        Me.newcolorButton.UseVisualStyleBackColor = False
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
        Me.Cancel_Button.TabIndex = 20
        Me.Cancel_Button.Text = "Cancel"
        Me.Cancel_Button.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(271, 18)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Set the colors you want to change."
        '
        'ChangeColorForm
        '
        Me.AcceptButton = Me.toButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(344, 172)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.newcolorButton)
        Me.Controls.Add(Me.oldcolorButton)
        Me.Controls.Add(Me.toButton)
        Me.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ChangeColorForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Change Color Tool"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents toButton As System.Windows.Forms.Button
    Friend WithEvents oldcolorButton As System.Windows.Forms.Button
    Friend WithEvents newcolorButton As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
