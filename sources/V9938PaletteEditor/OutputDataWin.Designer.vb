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
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PaletteComboBox = New System.Windows.Forms.ComboBox()
        Me.RGBformatLabel = New System.Windows.Forms.Label()
        Me.RGBformatComboBox = New System.Windows.Forms.ComboBox()
        Me.DataTypeInput = New mSXdevtools.GUI.Controls.DataTypeInputControl()
        Me.SaveDataButton = New System.Windows.Forms.Button()
        Me.SaveBinaryButton = New System.Windows.Forms.Button()
        Me.CopyAllButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'OutputText
        '
        Me.OutputText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OutputText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.OutputText.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OutputText.Location = New System.Drawing.Point(12, 177)
        Me.OutputText.Multiline = True
        Me.OutputText.Name = "OutputText"
        Me.OutputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.OutputText.Size = New System.Drawing.Size(600, 228)
        Me.OutputText.TabIndex = 0
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 21)
        Me.Label2.TabIndex = 252
        Me.Label2.Text = "Palette:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PaletteComboBox
        '
        Me.PaletteComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PaletteComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PaletteComboBox.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaletteComboBox.FormattingEnabled = True
        Me.PaletteComboBox.Items.AddRange(New Object() {"All Maps"})
        Me.PaletteComboBox.Location = New System.Drawing.Point(97, 7)
        Me.PaletteComboBox.Name = "PaletteComboBox"
        Me.PaletteComboBox.Size = New System.Drawing.Size(305, 22)
        Me.PaletteComboBox.TabIndex = 251
        '
        'RGBformatLabel
        '
        Me.RGBformatLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RGBformatLabel.Location = New System.Drawing.Point(0, 144)
        Me.RGBformatLabel.Name = "RGBformatLabel"
        Me.RGBformatLabel.Size = New System.Drawing.Size(92, 21)
        Me.RGBformatLabel.TabIndex = 270
        Me.RGBformatLabel.Text = "Color data:"
        Me.RGBformatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RGBformatComboBox
        '
        Me.RGBformatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.RGBformatComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RGBformatComboBox.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RGBformatComboBox.FormattingEnabled = True
        Me.RGBformatComboBox.Items.AddRange(New Object() {"RB,G", "R,G,B"})
        Me.RGBformatComboBox.Location = New System.Drawing.Point(97, 144)
        Me.RGBformatComboBox.Name = "RGBformatComboBox"
        Me.RGBformatComboBox.Size = New System.Drawing.Size(121, 22)
        Me.RGBformatComboBox.TabIndex = 269
        '
        'DataTypeInput
        '
        Me.DataTypeInput.BackColor = System.Drawing.Color.Transparent
        Me.DataTypeInput.EnableAssemblerIndex = False
        Me.DataTypeInput.EnableCompress = False
        Me.DataTypeInput.EnableDataSizeLine = True
        Me.DataTypeInput.FieldName = "DATA"
        Me.DataTypeInput.Location = New System.Drawing.Point(0, 32)
        Me.DataTypeInput.Name = "DataTypeInput"
        Me.DataTypeInput.Size = New System.Drawing.Size(474, 117)
        Me.DataTypeInput.SizeLineIndex = 6
        Me.DataTypeInput.TabIndex = 254
        '
        'SaveDataButton
        '
        Me.SaveDataButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SaveDataButton.BackColor = System.Drawing.Color.Transparent
        Me.SaveDataButton.Enabled = False
        Me.SaveDataButton.FlatAppearance.BorderSize = 0
        Me.SaveDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SaveDataButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveDataButton.Image = Global.mSXdevtools.V9938PaletteEditor.My.Resources.Resources.button_savesource
        Me.SaveDataButton.Location = New System.Drawing.Point(170, 411)
        Me.SaveDataButton.Name = "SaveDataButton"
        Me.SaveDataButton.Size = New System.Drawing.Size(207, 42)
        Me.SaveDataButton.TabIndex = 268
        Me.SaveDataButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.SaveDataButton, "Save output to TXT file")
        Me.SaveDataButton.UseVisualStyleBackColor = False
        '
        'SaveBinaryButton
        '
        Me.SaveBinaryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SaveBinaryButton.BackColor = System.Drawing.Color.Transparent
        Me.SaveBinaryButton.Enabled = False
        Me.SaveBinaryButton.FlatAppearance.BorderSize = 0
        Me.SaveBinaryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SaveBinaryButton.Image = Global.mSXdevtools.V9938PaletteEditor.My.Resources.Resources.button_savebinary
        Me.SaveBinaryButton.Location = New System.Drawing.Point(382, 411)
        Me.SaveBinaryButton.Name = "SaveBinaryButton"
        Me.SaveBinaryButton.Size = New System.Drawing.Size(208, 42)
        Me.SaveBinaryButton.TabIndex = 267
        Me.SaveBinaryButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.SaveBinaryButton, "Save output to Binary file")
        Me.SaveBinaryButton.UseVisualStyleBackColor = False
        '
        'CopyAllButton
        '
        Me.CopyAllButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CopyAllButton.BackColor = System.Drawing.Color.Transparent
        Me.CopyAllButton.FlatAppearance.BorderSize = 0
        Me.CopyAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CopyAllButton.Image = Global.mSXdevtools.V9938PaletteEditor.My.Resources.Resources.button_CopyAll
        Me.CopyAllButton.Location = New System.Drawing.Point(9, 411)
        Me.CopyAllButton.Name = "CopyAllButton"
        Me.CopyAllButton.Size = New System.Drawing.Size(157, 42)
        Me.CopyAllButton.TabIndex = 20
        Me.ToolTip1.SetToolTip(Me.CopyAllButton, "Copy output to clipboard")
        Me.CopyAllButton.UseVisualStyleBackColor = False
        '
        'OutputDataWin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(624, 461)
        Me.Controls.Add(Me.RGBformatLabel)
        Me.Controls.Add(Me.RGBformatComboBox)
        Me.Controls.Add(Me.SaveDataButton)
        Me.Controls.Add(Me.SaveBinaryButton)
        Me.Controls.Add(Me.DataTypeInput)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PaletteComboBox)
        Me.Controls.Add(Me.CopyAllButton)
        Me.Controls.Add(Me.OutputText)
        Me.KeyPreview = True
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
