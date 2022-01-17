<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangeTilesForm
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
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.TargetTileText = New System.Windows.Forms.TextBox
        Me.SourceTileText = New System.Windows.Forms.TextBox
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
        'TargetTileText
        '
        Me.TargetTileText.Location = New System.Drawing.Point(205, 69)
        Me.TargetTileText.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TargetTileText.MaxLength = 3
        Me.TargetTileText.Name = "TargetTileText"
        Me.TargetTileText.Size = New System.Drawing.Size(40, 26)
        Me.TargetTileText.TabIndex = 22
        Me.TargetTileText.Text = "0"
        Me.TargetTileText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'SourceTileText
        '
        Me.SourceTileText.Location = New System.Drawing.Point(91, 69)
        Me.SourceTileText.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SourceTileText.MaxLength = 3
        Me.SourceTileText.Name = "SourceTileText"
        Me.SourceTileText.Size = New System.Drawing.Size(40, 26)
        Me.SourceTileText.TabIndex = 21
        Me.SourceTileText.Text = "0"
        Me.SourceTileText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(274, 36)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Set the number of tiles you want to" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "change."
        '
        'ChangeTilesForm
        '
        Me.AcceptButton = Me.toButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(344, 172)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TargetTileText)
        Me.Controls.Add(Me.SourceTileText)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.toButton)
        Me.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ChangeTilesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Change Tiles Tool"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents toButton As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents TargetTileText As System.Windows.Forms.TextBox
    Friend WithEvents SourceTileText As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
