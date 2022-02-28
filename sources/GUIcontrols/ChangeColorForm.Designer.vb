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
        Me.DoitButton = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.DescriptionLabel = New System.Windows.Forms.Label()
        Me.BetweenLabel = New System.Windows.Forms.Label()
        Me.FirstColorButton = New mSXdevtools.GUI.Controls.ColorButton()
        Me.SecondColorButton = New mSXdevtools.GUI.Controls.ColorButton()
        Me.SuspendLayout()
        '
        'DoitButton
        '
        Me.DoitButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DoitButton.BackColor = System.Drawing.Color.PaleGreen
        Me.DoitButton.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DoitButton.Location = New System.Drawing.Point(172, 151)
        Me.DoitButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DoitButton.Name = "DoitButton"
        Me.DoitButton.Size = New System.Drawing.Size(110, 36)
        Me.DoitButton.TabIndex = 17
        Me.DoitButton.Text = "Switch"
        Me.DoitButton.UseVisualStyleBackColor = False
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel_Button.BackColor = System.Drawing.Color.LightSalmon
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_Button.Location = New System.Drawing.Point(290, 157)
        Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(70, 30)
        Me.Cancel_Button.TabIndex = 20
        Me.Cancel_Button.Text = "Cancel"
        Me.Cancel_Button.UseVisualStyleBackColor = False
        '
        'DescriptionLabel
        '
        Me.DescriptionLabel.AutoSize = True
        Me.DescriptionLabel.Location = New System.Drawing.Point(12, 13)
        Me.DescriptionLabel.Name = "DescriptionLabel"
        Me.DescriptionLabel.Size = New System.Drawing.Size(267, 18)
        Me.DescriptionLabel.TabIndex = 25
        Me.DescriptionLabel.Text = "Set the colors you want to switch:"
        '
        'BetweenLabel
        '
        Me.BetweenLabel.Location = New System.Drawing.Point(169, 56)
        Me.BetweenLabel.Name = "BetweenLabel"
        Me.BetweenLabel.Size = New System.Drawing.Size(53, 30)
        Me.BetweenLabel.TabIndex = 26
        Me.BetweenLabel.Text = "for"
        Me.BetweenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FirstColorButton
        '
        Me.FirstColorButton.Location = New System.Drawing.Point(111, 56)
        Me.FirstColorButton.Margin = New System.Windows.Forms.Padding(4)
        Me.FirstColorButton.Name = "FirstColorButton"
        Me.FirstColorButton.Size = New System.Drawing.Size(54, 30)
        Me.FirstColorButton.TabIndex = 27
        '
        'SecondColorButton
        '
        Me.SecondColorButton.Location = New System.Drawing.Point(231, 56)
        Me.SecondColorButton.Margin = New System.Windows.Forms.Padding(6)
        Me.SecondColorButton.Name = "SecondColorButton"
        Me.SecondColorButton.Size = New System.Drawing.Size(54, 30)
        Me.SecondColorButton.TabIndex = 28
        '
        'ChangeColorForm
        '
        Me.AcceptButton = Me.DoitButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(364, 191)
        Me.ControlBox = False
        Me.Controls.Add(Me.SecondColorButton)
        Me.Controls.Add(Me.FirstColorButton)
        Me.Controls.Add(Me.BetweenLabel)
        Me.Controls.Add(Me.DescriptionLabel)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.DoitButton)
        Me.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ChangeColorForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Change Colors Tool"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents DescriptionLabel As System.Windows.Forms.Label
    Friend WithEvents BetweenLabel As System.Windows.Forms.Label
    Friend WithEvents DoitButton As System.Windows.Forms.Button
    Friend WithEvents FirstColorButton As ColorButton
    Friend WithEvents SecondColorButton As ColorButton
End Class
