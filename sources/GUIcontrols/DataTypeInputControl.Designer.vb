<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataTypeInputControl
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
        Me.AsmGroupBox = New System.Windows.Forms.GroupBox()
        Me.WordDataLabel = New System.Windows.Forms.Label()
        Me.AsmWordDataTextBox = New System.Windows.Forms.TextBox()
        Me.AddIndexCheck = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.AsmByteDataTextBox = New System.Windows.Forms.TextBox()
        Me.SizeLineComboBox = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CompressComboBox = New System.Windows.Forms.ComboBox()
        Me.CompressLabel = New System.Windows.Forms.Label()
        Me.BasicGroupBox = New System.Windows.Forms.GroupBox()
        Me.LineNumberLabel = New System.Windows.Forms.Label()
        Me.IntervalText = New System.Windows.Forms.TextBox()
        Me.LineNumberText = New System.Windows.Forms.TextBox()
        Me.IntervalLabel = New System.Windows.Forms.Label()
        Me.RemoveZerosCheck = New System.Windows.Forms.CheckBox()
        Me.NumSysCombo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LanguageComboBox = New System.Windows.Forms.ComboBox()
        Me.CGroupBox = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CdataTypeTextBox = New System.Windows.Forms.TextBox()
        Me.AsmGroupBox.SuspendLayout()
        Me.BasicGroupBox.SuspendLayout()
        Me.CGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'AsmGroupBox
        '
        Me.AsmGroupBox.BackColor = System.Drawing.Color.Transparent
        Me.AsmGroupBox.Controls.Add(Me.WordDataLabel)
        Me.AsmGroupBox.Controls.Add(Me.AsmWordDataTextBox)
        Me.AsmGroupBox.Controls.Add(Me.AddIndexCheck)
        Me.AsmGroupBox.Controls.Add(Me.Label7)
        Me.AsmGroupBox.Controls.Add(Me.AsmByteDataTextBox)
        Me.AsmGroupBox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AsmGroupBox.ForeColor = System.Drawing.Color.Black
        Me.AsmGroupBox.Location = New System.Drawing.Point(233, 108)
        Me.AsmGroupBox.Name = "AsmGroupBox"
        Me.AsmGroupBox.Size = New System.Drawing.Size(170, 100)
        Me.AsmGroupBox.TabIndex = 260
        Me.AsmGroupBox.TabStop = False
        Me.AsmGroupBox.Text = "Assembler"
        Me.AsmGroupBox.Visible = False
        '
        'WordDataLabel
        '
        Me.WordDataLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WordDataLabel.Location = New System.Drawing.Point(6, 52)
        Me.WordDataLabel.Name = "WordDataLabel"
        Me.WordDataLabel.Size = New System.Drawing.Size(80, 13)
        Me.WordDataLabel.TabIndex = 271
        Me.WordDataLabel.Text = "Word data:"
        Me.WordDataLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AsmWordDataTextBox
        '
        Me.AsmWordDataTextBox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AsmWordDataTextBox.Location = New System.Drawing.Point(90, 49)
        Me.AsmWordDataTextBox.MaxLength = 128
        Me.AsmWordDataTextBox.Name = "AsmWordDataTextBox"
        Me.AsmWordDataTextBox.Size = New System.Drawing.Size(66, 21)
        Me.AsmWordDataTextBox.TabIndex = 270
        '
        'AddIndexCheck
        '
        Me.AddIndexCheck.AutoSize = True
        Me.AddIndexCheck.BackColor = System.Drawing.Color.Transparent
        Me.AddIndexCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.AddIndexCheck.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddIndexCheck.Location = New System.Drawing.Point(18, 77)
        Me.AddIndexCheck.Name = "AddIndexCheck"
        Me.AddIndexCheck.Size = New System.Drawing.Size(85, 17)
        Me.AddIndexCheck.TabIndex = 269
        Me.AddIndexCheck.Text = "Add Index"
        Me.AddIndexCheck.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Byte data:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AsmByteDataTextBox
        '
        Me.AsmByteDataTextBox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AsmByteDataTextBox.Location = New System.Drawing.Point(90, 22)
        Me.AsmByteDataTextBox.MaxLength = 128
        Me.AsmByteDataTextBox.Name = "AsmByteDataTextBox"
        Me.AsmByteDataTextBox.Size = New System.Drawing.Size(66, 21)
        Me.AsmByteDataTextBox.TabIndex = 14
        '
        'SizeLineComboBox
        '
        Me.SizeLineComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SizeLineComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.SizeLineComboBox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SizeLineComboBox.ForeColor = System.Drawing.Color.Black
        Me.SizeLineComboBox.FormattingEnabled = True
        Me.SizeLineComboBox.Items.AddRange(New Object() {"1", "2", "4", "8", "16", "24", "32"})
        Me.SizeLineComboBox.Location = New System.Drawing.Point(97, 84)
        Me.SizeLineComboBox.Name = "SizeLineComboBox"
        Me.SizeLineComboBox.Size = New System.Drawing.Size(120, 21)
        Me.SizeLineComboBox.TabIndex = 259
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label17.Location = New System.Drawing.Point(3, 84)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(90, 21)
        Me.Label17.TabIndex = 258
        Me.Label17.Text = "Line size:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(3, 29)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 21)
        Me.Label3.TabIndex = 257
        Me.Label3.Text = "Number sys:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CompressComboBox
        '
        Me.CompressComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CompressComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CompressComboBox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompressComboBox.ForeColor = System.Drawing.Color.Black
        Me.CompressComboBox.FormattingEnabled = True
        Me.CompressComboBox.Items.AddRange(New Object() {"RAW", "RLE", "RLEWB", "Pletter5c"})
        Me.CompressComboBox.Location = New System.Drawing.Point(97, 57)
        Me.CompressComboBox.Name = "CompressComboBox"
        Me.CompressComboBox.Size = New System.Drawing.Size(120, 21)
        Me.CompressComboBox.TabIndex = 256
        '
        'CompressLabel
        '
        Me.CompressLabel.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.CompressLabel.Location = New System.Drawing.Point(3, 56)
        Me.CompressLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CompressLabel.Name = "CompressLabel"
        Me.CompressLabel.Size = New System.Drawing.Size(90, 21)
        Me.CompressLabel.TabIndex = 255
        Me.CompressLabel.Text = "Compress:"
        Me.CompressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BasicGroupBox
        '
        Me.BasicGroupBox.BackColor = System.Drawing.Color.Transparent
        Me.BasicGroupBox.Controls.Add(Me.LineNumberLabel)
        Me.BasicGroupBox.Controls.Add(Me.IntervalText)
        Me.BasicGroupBox.Controls.Add(Me.LineNumberText)
        Me.BasicGroupBox.Controls.Add(Me.IntervalLabel)
        Me.BasicGroupBox.Controls.Add(Me.RemoveZerosCheck)
        Me.BasicGroupBox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BasicGroupBox.ForeColor = System.Drawing.Color.Black
        Me.BasicGroupBox.Location = New System.Drawing.Point(233, 2)
        Me.BasicGroupBox.Name = "BasicGroupBox"
        Me.BasicGroupBox.Size = New System.Drawing.Size(170, 100)
        Me.BasicGroupBox.TabIndex = 254
        Me.BasicGroupBox.TabStop = False
        Me.BasicGroupBox.Text = "Basic"
        Me.BasicGroupBox.Visible = False
        '
        'LineNumberLabel
        '
        Me.LineNumberLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LineNumberLabel.Location = New System.Drawing.Point(12, 25)
        Me.LineNumberLabel.Name = "LineNumberLabel"
        Me.LineNumberLabel.Size = New System.Drawing.Size(90, 13)
        Me.LineNumberLabel.TabIndex = 13
        Me.LineNumberLabel.Text = "Line number:"
        Me.LineNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'IntervalText
        '
        Me.IntervalText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IntervalText.Location = New System.Drawing.Point(104, 49)
        Me.IntervalText.MaxLength = 3
        Me.IntervalText.Name = "IntervalText"
        Me.IntervalText.Size = New System.Drawing.Size(52, 21)
        Me.IntervalText.TabIndex = 4
        Me.IntervalText.Text = "10"
        Me.IntervalText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LineNumberText
        '
        Me.LineNumberText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LineNumberText.Location = New System.Drawing.Point(104, 22)
        Me.LineNumberText.MaxLength = 5
        Me.LineNumberText.Name = "LineNumberText"
        Me.LineNumberText.Size = New System.Drawing.Size(52, 21)
        Me.LineNumberText.TabIndex = 3
        Me.LineNumberText.Text = "10000"
        Me.LineNumberText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'IntervalLabel
        '
        Me.IntervalLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IntervalLabel.Location = New System.Drawing.Point(12, 52)
        Me.IntervalLabel.Name = "IntervalLabel"
        Me.IntervalLabel.Size = New System.Drawing.Size(90, 13)
        Me.IntervalLabel.TabIndex = 14
        Me.IntervalLabel.Text = "Interval:"
        Me.IntervalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RemoveZerosCheck
        '
        Me.RemoveZerosCheck.AutoSize = True
        Me.RemoveZerosCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RemoveZerosCheck.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RemoveZerosCheck.Location = New System.Drawing.Point(11, 77)
        Me.RemoveZerosCheck.Name = "RemoveZerosCheck"
        Me.RemoveZerosCheck.Size = New System.Drawing.Size(108, 17)
        Me.RemoveZerosCheck.TabIndex = 8
        Me.RemoveZerosCheck.Text = "Remove zeros"
        Me.RemoveZerosCheck.UseVisualStyleBackColor = True
        '
        'NumSysCombo
        '
        Me.NumSysCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.NumSysCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NumSysCombo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumSysCombo.FormattingEnabled = True
        Me.NumSysCombo.Items.AddRange(New Object() {"dec n", "dec nnn", "dec nnnd", "hex FF", "hex $FF", "hex #FF", "hex 0FFh", "hex 0xFF", "hex &HFF", "binary 00000000", "binary 00000000b", "binary %00000000", "binary 0b00000000", "binary &B00000000"})
        Me.NumSysCombo.Location = New System.Drawing.Point(97, 30)
        Me.NumSysCombo.Name = "NumSysCombo"
        Me.NumSysCombo.Size = New System.Drawing.Size(120, 21)
        Me.NumSysCombo.TabIndex = 252
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 21)
        Me.Label1.TabIndex = 253
        Me.Label1.Text = "Language:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LanguageComboBox
        '
        Me.LanguageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.LanguageComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LanguageComboBox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LanguageComboBox.FormattingEnabled = True
        Me.LanguageComboBox.Items.AddRange(New Object() {"Assembler", "BASIC", "C"})
        Me.LanguageComboBox.Location = New System.Drawing.Point(97, 3)
        Me.LanguageComboBox.Name = "LanguageComboBox"
        Me.LanguageComboBox.Size = New System.Drawing.Size(120, 21)
        Me.LanguageComboBox.TabIndex = 251
        '
        'CGroupBox
        '
        Me.CGroupBox.BackColor = System.Drawing.Color.Transparent
        Me.CGroupBox.Controls.Add(Me.Label4)
        Me.CGroupBox.Controls.Add(Me.CdataTypeTextBox)
        Me.CGroupBox.ForeColor = System.Drawing.Color.Black
        Me.CGroupBox.Location = New System.Drawing.Point(233, 214)
        Me.CGroupBox.Name = "CGroupBox"
        Me.CGroupBox.Size = New System.Drawing.Size(170, 100)
        Me.CGroupBox.TabIndex = 261
        Me.CGroupBox.TabStop = False
        Me.CGroupBox.Text = "C"
        Me.CGroupBox.Visible = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Type:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CdataTypeTextBox
        '
        Me.CdataTypeTextBox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CdataTypeTextBox.Location = New System.Drawing.Point(60, 22)
        Me.CdataTypeTextBox.MaxLength = 128
        Me.CdataTypeTextBox.Name = "CdataTypeTextBox"
        Me.CdataTypeTextBox.Size = New System.Drawing.Size(96, 21)
        Me.CdataTypeTextBox.TabIndex = 14
        '
        'DataTypeInputControl
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Silver
        Me.Controls.Add(Me.CGroupBox)
        Me.Controls.Add(Me.AsmGroupBox)
        Me.Controls.Add(Me.SizeLineComboBox)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CompressComboBox)
        Me.Controls.Add(Me.CompressLabel)
        Me.Controls.Add(Me.BasicGroupBox)
        Me.Controls.Add(Me.NumSysCombo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LanguageComboBox)
        Me.Name = "DataTypeInputControl"
        Me.Size = New System.Drawing.Size(418, 328)
        Me.AsmGroupBox.ResumeLayout(False)
        Me.AsmGroupBox.PerformLayout()
        Me.BasicGroupBox.ResumeLayout(False)
        Me.BasicGroupBox.PerformLayout()
        Me.CGroupBox.ResumeLayout(False)
        Me.CGroupBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AsmGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents WordDataLabel As System.Windows.Forms.Label
    Friend WithEvents AsmWordDataTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AddIndexCheck As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents AsmByteDataTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SizeLineComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CompressComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents CompressLabel As System.Windows.Forms.Label
    Friend WithEvents BasicGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents LineNumberLabel As System.Windows.Forms.Label
    Friend WithEvents IntervalText As System.Windows.Forms.TextBox
    Friend WithEvents LineNumberText As System.Windows.Forms.TextBox
    Friend WithEvents IntervalLabel As System.Windows.Forms.Label
    Friend WithEvents RemoveZerosCheck As System.Windows.Forms.CheckBox
    Friend WithEvents NumSysCombo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LanguageComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents CGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CdataTypeTextBox As System.Windows.Forms.TextBox

End Class
