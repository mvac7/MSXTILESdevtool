<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SaveBinaryDialog
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
        Me.Label30 = New System.Windows.Forms.Label()
        Me.VRAM_DataCombobox = New System.Windows.Forms.ComboBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.VRAM_sizeTextBox = New System.Windows.Forms.TextBox()
        Me.VRAM_startTextBox = New System.Windows.Forms.TextBox()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.BasicHeadCheck = New System.Windows.Forms.CheckBox()
        Me.ExtensionTextBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(10, 46)
        Me.Label30.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(119, 21)
        Me.Label30.TabIndex = 250
        Me.Label30.Text = "Data:"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'VRAM_DataCombobox
        '
        Me.VRAM_DataCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.VRAM_DataCombobox.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.VRAM_DataCombobox.ForeColor = System.Drawing.Color.Black
        Me.VRAM_DataCombobox.FormattingEnabled = True
        Me.VRAM_DataCombobox.Location = New System.Drawing.Point(136, 44)
        Me.VRAM_DataCombobox.Name = "VRAM_DataCombobox"
        Me.VRAM_DataCombobox.Size = New System.Drawing.Size(196, 26)
        Me.VRAM_DataCombobox.TabIndex = 3
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(10, 111)
        Me.Label29.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(121, 21)
        Me.Label29.TabIndex = 262
        Me.Label29.Text = "Size:"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label37
        '
        Me.Label37.Location = New System.Drawing.Point(10, 79)
        Me.Label37.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(121, 21)
        Me.Label37.TabIndex = 261
        Me.Label37.Text = "Start addr.:"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(196, 111)
        Me.Label32.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(35, 18)
        Me.Label32.TabIndex = 260
        Me.Label32.Text = "hex"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(196, 79)
        Me.Label31.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(35, 18)
        Me.Label31.TabIndex = 259
        Me.Label31.Text = "hex"
        '
        'VRAM_sizeTextBox
        '
        Me.VRAM_sizeTextBox.ForeColor = System.Drawing.Color.Black
        Me.VRAM_sizeTextBox.Location = New System.Drawing.Point(135, 108)
        Me.VRAM_sizeTextBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.VRAM_sizeTextBox.MaxLength = 4
        Me.VRAM_sizeTextBox.Name = "VRAM_sizeTextBox"
        Me.VRAM_sizeTextBox.Size = New System.Drawing.Size(56, 26)
        Me.VRAM_sizeTextBox.TabIndex = 5
        Me.VRAM_sizeTextBox.Text = "1"
        Me.VRAM_sizeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'VRAM_startTextBox
        '
        Me.VRAM_startTextBox.ForeColor = System.Drawing.Color.Black
        Me.VRAM_startTextBox.Location = New System.Drawing.Point(135, 76)
        Me.VRAM_startTextBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.VRAM_startTextBox.MaxLength = 4
        Me.VRAM_startTextBox.Name = "VRAM_startTextBox"
        Me.VRAM_startTextBox.Size = New System.Drawing.Size(56, 26)
        Me.VRAM_startTextBox.TabIndex = 4
        Me.VRAM_startTextBox.Text = "0"
        Me.VRAM_startTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel_Button.BackColor = System.Drawing.Color.LightSalmon
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_Button.Location = New System.Drawing.Point(337, 183)
        Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(70, 30)
        Me.Cancel_Button.TabIndex = 7
        Me.Cancel_Button.Text = "Exit"
        Me.Cancel_Button.UseVisualStyleBackColor = False
        '
        'SaveButton
        '
        Me.SaveButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SaveButton.BackColor = System.Drawing.Color.PaleGreen
        Me.SaveButton.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveButton.Location = New System.Drawing.Point(232, 173)
        Me.SaveButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(100, 40)
        Me.SaveButton.TabIndex = 6
        Me.SaveButton.Text = "Save"
        Me.SaveButton.UseVisualStyleBackColor = False
        '
        'BasicHeadCheck
        '
        Me.BasicHeadCheck.BackColor = System.Drawing.Color.Transparent
        Me.BasicHeadCheck.Checked = True
        Me.BasicHeadCheck.CheckState = System.Windows.Forms.CheckState.Checked
        Me.BasicHeadCheck.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.BasicHeadCheck.FlatAppearance.BorderSize = 2
        Me.BasicHeadCheck.FlatAppearance.CheckedBackColor = System.Drawing.Color.Aqua
        Me.BasicHeadCheck.ForeColor = System.Drawing.Color.Black
        Me.BasicHeadCheck.Location = New System.Drawing.Point(-1, 17)
        Me.BasicHeadCheck.Name = "BasicHeadCheck"
        Me.BasicHeadCheck.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.BasicHeadCheck.Size = New System.Drawing.Size(152, 21)
        Me.BasicHeadCheck.TabIndex = 266
        Me.BasicHeadCheck.Text = "MSX Basic head"
        Me.BasicHeadCheck.UseVisualStyleBackColor = False
        '
        'ExtensionTextBox
        '
        Me.ExtensionTextBox.Location = New System.Drawing.Point(262, 12)
        Me.ExtensionTextBox.Name = "ExtensionTextBox"
        Me.ExtensionTextBox.ReadOnly = True
        Me.ExtensionTextBox.Size = New System.Drawing.Size(70, 26)
        Me.ExtensionTextBox.TabIndex = 267
        Me.ExtensionTextBox.Text = ".bin"
        '
        'SaveBinaryDialog
        '
        Me.AcceptButton = Me.SaveButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(414, 222)
        Me.ControlBox = False
        Me.Controls.Add(Me.ExtensionTextBox)
        Me.Controls.Add(Me.BasicHeadCheck)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.SaveButton)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.VRAM_sizeTextBox)
        Me.Controls.Add(Me.VRAM_startTextBox)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.VRAM_DataCombobox)
        Me.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SaveBinaryDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Save Binary"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents VRAM_DataCombobox As System.Windows.Forms.ComboBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents VRAM_sizeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents VRAM_startTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents SaveButton As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents BasicHeadCheck As System.Windows.Forms.CheckBox
    Friend WithEvents ExtensionTextBox As TextBox
End Class
