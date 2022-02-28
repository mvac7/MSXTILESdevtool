<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OutputDataWin
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
        Me.OutputText = New System.Windows.Forms.TextBox()
        Me.GetDataButton = New System.Windows.Forms.Button()
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.CopyAllButton = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SaveBinaryButton = New System.Windows.Forms.Button()
        Me.SaveDataButton = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PaletteComboBox = New System.Windows.Forms.ComboBox()
        Me.DataTypeInput = New mSXdevtools.GUI.Controls.DataTypeInputControl()
        Me.RGBformatLabel = New System.Windows.Forms.Label()
        Me.RGBformatComboBox = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'OutputText
        '
        Me.OutputText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OutputText.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OutputText.Location = New System.Drawing.Point(12, 206)
        Me.OutputText.Multiline = True
        Me.OutputText.Name = "OutputText"
        Me.OutputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.OutputText.Size = New System.Drawing.Size(600, 214)
        Me.OutputText.TabIndex = 0
        '
        'GetDataButton
        '
        Me.GetDataButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GetDataButton.BackColor = System.Drawing.Color.PaleGreen
        Me.GetDataButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GetDataButton.Location = New System.Drawing.Point(502, 168)
        Me.GetDataButton.Name = "GetDataButton"
        Me.GetDataButton.Size = New System.Drawing.Size(110, 32)
        Me.GetDataButton.TabIndex = 19
        Me.GetDataButton.Text = "Get Data!"
        Me.ToolTip1.SetToolTip(Me.GetDataButton, "Generate data")
        Me.GetDataButton.UseVisualStyleBackColor = False
        '
        'ExitButton
        '
        Me.ExitButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExitButton.BackColor = System.Drawing.Color.LightSalmon
        Me.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ExitButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExitButton.ForeColor = System.Drawing.Color.Black
        Me.ExitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ExitButton.Location = New System.Drawing.Point(542, 426)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(70, 30)
        Me.ExitButton.TabIndex = 22
        Me.ExitButton.Text = "Exit"
        Me.ExitButton.UseVisualStyleBackColor = False
        '
        'CopyAllButton
        '
        Me.CopyAllButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CopyAllButton.BackColor = System.Drawing.Color.Gainsboro
        Me.CopyAllButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CopyAllButton.Location = New System.Drawing.Point(12, 426)
        Me.CopyAllButton.Name = "CopyAllButton"
        Me.CopyAllButton.Size = New System.Drawing.Size(80, 30)
        Me.CopyAllButton.TabIndex = 20
        Me.CopyAllButton.Text = "Copy All"
        Me.ToolTip1.SetToolTip(Me.CopyAllButton, "Copy output to clipboard")
        Me.CopyAllButton.UseVisualStyleBackColor = False
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'SaveBinaryButton
        '
        Me.SaveBinaryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SaveBinaryButton.BackColor = System.Drawing.Color.LightGray
        Me.SaveBinaryButton.Enabled = False
        Me.SaveBinaryButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveBinaryButton.Image = Global.mSXdevtools.V9938PaletteEditor.My.Resources.Resources.save
        Me.SaveBinaryButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.SaveBinaryButton.Location = New System.Drawing.Point(194, 426)
        Me.SaveBinaryButton.Name = "SaveBinaryButton"
        Me.SaveBinaryButton.Size = New System.Drawing.Size(90, 30)
        Me.SaveBinaryButton.TabIndex = 267
        Me.SaveBinaryButton.Text = "Binary"
        Me.SaveBinaryButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.SaveBinaryButton, "Save output to Binary file")
        Me.SaveBinaryButton.UseVisualStyleBackColor = False
        '
        'SaveDataButton
        '
        Me.SaveDataButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SaveDataButton.BackColor = System.Drawing.Color.LightGray
        Me.SaveDataButton.Enabled = False
        Me.SaveDataButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveDataButton.Image = Global.mSXdevtools.V9938PaletteEditor.My.Resources.Resources.save
        Me.SaveDataButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.SaveDataButton.Location = New System.Drawing.Point(98, 426)
        Me.SaveDataButton.Name = "SaveDataButton"
        Me.SaveDataButton.Size = New System.Drawing.Size(90, 30)
        Me.SaveDataButton.TabIndex = 268
        Me.SaveDataButton.Text = "Source"
        Me.SaveDataButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.SaveDataButton, "Save output to TXT file")
        Me.SaveDataButton.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 21)
        Me.Label2.TabIndex = 252
        Me.Label2.Text = "Palette:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PaletteComboBox
        '
        Me.PaletteComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PaletteComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PaletteComboBox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaletteComboBox.FormattingEnabled = True
        Me.PaletteComboBox.Items.AddRange(New Object() {"All Maps"})
        Me.PaletteComboBox.Location = New System.Drawing.Point(97, 7)
        Me.PaletteComboBox.Name = "PaletteComboBox"
        Me.PaletteComboBox.Size = New System.Drawing.Size(305, 21)
        Me.PaletteComboBox.TabIndex = 251
        '
        'DataTypeInput
        '
        Me.DataTypeInput.BackColor = System.Drawing.Color.Transparent
        Me.DataTypeInput.EnableDataSizeLine = False
        Me.DataTypeInput.Location = New System.Drawing.Point(0, 32)
        Me.DataTypeInput.Name = "DataTypeInput"
        Me.DataTypeInput.Size = New System.Drawing.Size(419, 110)
        Me.DataTypeInput.SizesForColors = True
        Me.DataTypeInput.TabIndex = 254
        '
        'RGBformatLabel
        '
        Me.RGBformatLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RGBformatLabel.Location = New System.Drawing.Point(0, 143)
        Me.RGBformatLabel.Name = "RGBformatLabel"
        Me.RGBformatLabel.Size = New System.Drawing.Size(90, 21)
        Me.RGBformatLabel.TabIndex = 270
        Me.RGBformatLabel.Text = "Color data:"
        Me.RGBformatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RGBformatComboBox
        '
        Me.RGBformatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.RGBformatComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RGBformatComboBox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RGBformatComboBox.FormattingEnabled = True
        Me.RGBformatComboBox.Items.AddRange(New Object() {"RB,G", "R,G,B"})
        Me.RGBformatComboBox.Location = New System.Drawing.Point(97, 143)
        Me.RGBformatComboBox.Name = "RGBformatComboBox"
        Me.RGBformatComboBox.Size = New System.Drawing.Size(121, 21)
        Me.RGBformatComboBox.TabIndex = 269
        '
        'OutputDataWin
        '
        Me.AcceptButton = Me.GetDataButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.ExitButton
        Me.ClientSize = New System.Drawing.Size(624, 461)
        Me.Controls.Add(Me.RGBformatLabel)
        Me.Controls.Add(Me.RGBformatComboBox)
        Me.Controls.Add(Me.SaveDataButton)
        Me.Controls.Add(Me.SaveBinaryButton)
        Me.Controls.Add(Me.DataTypeInput)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PaletteComboBox)
        Me.Controls.Add(Me.CopyAllButton)
        Me.Controls.Add(Me.ExitButton)
        Me.Controls.Add(Me.GetDataButton)
        Me.Controls.Add(Me.OutputText)
        Me.MinimumSize = New System.Drawing.Size(600, 440)
        Me.Name = "OutputDataWin"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Output Data"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OutputText As System.Windows.Forms.TextBox
    Friend WithEvents GetDataButton As System.Windows.Forms.Button
    Friend WithEvents ExitButton As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents CopyAllButton As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PaletteComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents DataTypeInput As mSXdevtools.GUI.Controls.DataTypeInputControl
    Friend WithEvents SaveBinaryButton As System.Windows.Forms.Button
    Friend WithEvents SaveDataButton As System.Windows.Forms.Button
    Friend WithEvents RGBformatLabel As Label
    Friend WithEvents RGBformatComboBox As ComboBox
End Class
