<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BasicConfigDialog
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
        Me.Exit_Button = New System.Windows.Forms.Button
        Me.Label21 = New System.Windows.Forms.Label
        Me.StartingLineTextBox = New System.Windows.Forms.TextBox
        Me.IntervalTextBox = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.RZCheckButton = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'Exit_Button
        '
        Me.Exit_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Exit_Button.BackColor = System.Drawing.Color.LightGray
        Me.Exit_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Exit_Button.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Exit_Button.Location = New System.Drawing.Point(261, 139)
        Me.Exit_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.Exit_Button.Name = "Exit_Button"
        Me.Exit_Button.Size = New System.Drawing.Size(70, 32)
        Me.Exit_Button.TabIndex = 1
        Me.Exit_Button.Text = "Exit"
        Me.Exit_Button.UseVisualStyleBackColor = False
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(75, 27)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(102, 18)
        Me.Label21.TabIndex = 34
        Me.Label21.Text = "Starting line:"
        '
        'StartingLineTextBox
        '
        Me.StartingLineTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StartingLineTextBox.Location = New System.Drawing.Point(196, 24)
        Me.StartingLineTextBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.StartingLineTextBox.MaxLength = 5
        Me.StartingLineTextBox.Name = "StartingLineTextBox"
        Me.StartingLineTextBox.Size = New System.Drawing.Size(65, 26)
        Me.StartingLineTextBox.TabIndex = 107
        Me.StartingLineTextBox.Text = "10000"
        Me.StartingLineTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'IntervalTextBox
        '
        Me.IntervalTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IntervalTextBox.Location = New System.Drawing.Point(195, 59)
        Me.IntervalTextBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.IntervalTextBox.MaxLength = 3
        Me.IntervalTextBox.Name = "IntervalTextBox"
        Me.IntervalTextBox.Size = New System.Drawing.Size(66, 26)
        Me.IntervalTextBox.TabIndex = 108
        Me.IntervalTextBox.Text = "10"
        Me.IntervalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label29
        '
        Me.Label29.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(75, 62)
        Me.Label29.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(71, 18)
        Me.Label29.TabIndex = 36
        Me.Label29.Text = "Interval:"
        '
        'RZCheckButton
        '
        Me.RZCheckButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RZCheckButton.AutoSize = True
        Me.RZCheckButton.Location = New System.Drawing.Point(73, 92)
        Me.RZCheckButton.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.RZCheckButton.Name = "RZCheckButton"
        Me.RZCheckButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RZCheckButton.Size = New System.Drawing.Size(136, 22)
        Me.RZCheckButton.TabIndex = 109
        Me.RZCheckButton.Text = "Remove zeros"
        Me.RZCheckButton.UseVisualStyleBackColor = True
        '
        'BasicConfigDialog
        '
        Me.AcceptButton = Me.Exit_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Exit_Button
        Me.ClientSize = New System.Drawing.Size(344, 182)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.StartingLineTextBox)
        Me.Controls.Add(Me.IntervalTextBox)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Exit_Button)
        Me.Controls.Add(Me.RZCheckButton)
        Me.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BasicConfigDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Basic Config"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Exit_Button As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents StartingLineTextBox As System.Windows.Forms.TextBox
    Friend WithEvents IntervalTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents RZCheckButton As System.Windows.Forms.CheckBox

End Class
