<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfigWin
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
        Me.NumFormatComboBox = New System.Windows.Forms.ComboBox()
        Me.CompressTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.SizeLineComboBox = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.CodeOutputComboBox = New System.Windows.Forms.ComboBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.AsmByteDataTextBox = New System.Windows.Forms.TextBox()
        Me.DataLabelTextBox = New System.Windows.Forms.TextBox()
        Me.BASICincLineslTextBox = New System.Windows.Forms.TextBox()
        Me.BASICinitLineTextBox = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.AsmWordDataTextBox = New System.Windows.Forms.TextBox()
        Me.CByteDataTextBox = New System.Windows.Forms.TextBox()
        Me.BASICdataTextBox = New System.Windows.Forms.TextBox()
        Me.InfoNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Color0Button = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.BASICcommentComboBox = New System.Windows.Forms.ComboBox()
        Me.OutputINKcolorButton = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.OutputBGcolorButton = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.BASICGroupBox = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.RemoveZerosCheck = New System.Windows.Forms.CheckBox()
        Me.LineNumberLabel = New System.Windows.Forms.Label()
        Me.IntervalLabel = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.PathsPanel = New System.Windows.Forms.Panel()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.OthersTab = New System.Windows.Forms.TabPage()
        Me.OutputdataGroupBox = New System.Windows.Forms.GroupBox()
        Me.ColorConfigsLabel = New System.Windows.Forms.Label()
        Me.ColorConfigsComboBox = New System.Windows.Forms.ComboBox()
        Me.GridColorButton = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PathLastPRJTextBox = New System.Windows.Forms.TextBox()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.DataOutputTab = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.arrow2PictureBox = New System.Windows.Forms.PictureBox()
        Me.arrow1PictureBox = New System.Windows.Forms.PictureBox()
        Me.AsmWordValuesComboBox = New System.Windows.Forms.ComboBox()
        Me.AsmByteValuesComboBox = New System.Windows.Forms.ComboBox()
        Me.PathsTab = New System.Windows.Forms.TabPage()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.BinaryPathControl = New mSXdevtools.GUI.Controls.PathEntryControl()
        Me.BitmapsPathControl = New mSXdevtools.GUI.Controls.PathEntryControl()
        Me.MSXBASICPathControl = New mSXdevtools.GUI.Controls.PathEntryControl()
        Me.PalettesPathControl = New mSXdevtools.GUI.Controls.PathEntryControl()
        Me.OAMPathControl = New mSXdevtools.GUI.Controls.PathEntryControl()
        Me.BytegenPathControl = New mSXdevtools.GUI.Controls.PathEntryControl()
        Me.nMSXtilesPathControl = New mSXdevtools.GUI.Controls.PathEntryControl()
        Me.SquaredsetsPathControl = New mSXdevtools.GUI.Controls.PathEntryControl()
        Me.TilesetsPathControl = New mSXdevtools.GUI.Controls.PathEntryControl()
        Me.MapsPathControl = New mSXdevtools.GUI.Controls.PathEntryControl()
        Me.SpritesPathControl = New mSXdevtools.GUI.Controls.PathEntryControl()
        Me.tMSgfXProjectPathControl = New mSXdevtools.GUI.Controls.PathEntryControl()
        Me.BASICGroupBox.SuspendLayout()
        Me.PathsPanel.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.OthersTab.SuspendLayout()
        Me.OutputdataGroupBox.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.DataOutputTab.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.arrow2PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.arrow1PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PathsTab.SuspendLayout()
        Me.SuspendLayout()
        '
        'NumFormatComboBox
        '
        Me.NumFormatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.NumFormatComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.NumFormatComboBox.FormattingEnabled = True
        Me.NumFormatComboBox.Items.AddRange(New Object() {"dec n", "dec nnn", "dec nnnd", "hex FF", "hex $FF", "hex #FF", "hex 0FFh", "hex 0xFF", "hex &HFF", "binary 00000000", "binary 00000000b", "binary %00000000", "binary 0b00000000", "binary &B00000000"})
        Me.NumFormatComboBox.Location = New System.Drawing.Point(133, 38)
        Me.NumFormatComboBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.NumFormatComboBox.Name = "NumFormatComboBox"
        Me.NumFormatComboBox.Size = New System.Drawing.Size(223, 22)
        Me.NumFormatComboBox.TabIndex = 246
        Me.ToolTip1.SetToolTip(Me.NumFormatComboBox, "Computer number format")
        '
        'CompressTypeComboBox
        '
        Me.CompressTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CompressTypeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CompressTypeComboBox.FormattingEnabled = True
        Me.CompressTypeComboBox.Items.AddRange(New Object() {"RAW", "RLE", "RLEWB", "Pletter5c"})
        Me.CompressTypeComboBox.Location = New System.Drawing.Point(133, 94)
        Me.CompressTypeComboBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CompressTypeComboBox.Name = "CompressTypeComboBox"
        Me.CompressTypeComboBox.Size = New System.Drawing.Size(223, 22)
        Me.CompressTypeComboBox.TabIndex = 243
        '
        'SizeLineComboBox
        '
        Me.SizeLineComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SizeLineComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.SizeLineComboBox.FormattingEnabled = True
        Me.SizeLineComboBox.Items.AddRange(New Object() {"1", "2", "4", "8", "16", "24", "32"})
        Me.SizeLineComboBox.Location = New System.Drawing.Point(133, 66)
        Me.SizeLineComboBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SizeLineComboBox.Name = "SizeLineComboBox"
        Me.SizeLineComboBox.Size = New System.Drawing.Size(223, 22)
        Me.SizeLineComboBox.TabIndex = 242
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(17, 10)
        Me.Label21.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(110, 22)
        Me.Label21.TabIndex = 239
        Me.Label21.Text = "Language:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CodeOutputComboBox
        '
        Me.CodeOutputComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CodeOutputComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CodeOutputComboBox.FormattingEnabled = True
        Me.CodeOutputComboBox.Items.AddRange(New Object() {"Assembler", "BASIC", "C"})
        Me.CodeOutputComboBox.Location = New System.Drawing.Point(133, 10)
        Me.CodeOutputComboBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CodeOutputComboBox.Name = "CodeOutputComboBox"
        Me.CodeOutputComboBox.Size = New System.Drawing.Size(221, 22)
        Me.CodeOutputComboBox.TabIndex = 241
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'AsmByteDataTextBox
        '
        Me.AsmByteDataTextBox.Location = New System.Drawing.Point(117, 21)
        Me.AsmByteDataTextBox.Name = "AsmByteDataTextBox"
        Me.AsmByteDataTextBox.Size = New System.Drawing.Size(220, 22)
        Me.AsmByteDataTextBox.TabIndex = 247
        Me.ToolTip1.SetToolTip(Me.AsmByteDataTextBox, "Byte Data command definition.")
        '
        'DataLabelTextBox
        '
        Me.DataLabelTextBox.Location = New System.Drawing.Point(134, 151)
        Me.DataLabelTextBox.Name = "DataLabelTextBox"
        Me.DataLabelTextBox.Size = New System.Drawing.Size(220, 22)
        Me.DataLabelTextBox.TabIndex = 252
        Me.ToolTip1.SetToolTip(Me.DataLabelTextBox, "Data definition command (DB, BYTE, DEFB, etc.)")
        '
        'BASICincLineslTextBox
        '
        Me.BASICincLineslTextBox.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BASICincLineslTextBox.Location = New System.Drawing.Point(491, 49)
        Me.BASICincLineslTextBox.MaxLength = 3
        Me.BASICincLineslTextBox.Name = "BASICincLineslTextBox"
        Me.BASICincLineslTextBox.Size = New System.Drawing.Size(52, 22)
        Me.BASICincLineslTextBox.TabIndex = 255
        Me.BASICincLineslTextBox.Text = "10"
        Me.BASICincLineslTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.BASICincLineslTextBox, "Interval lines (for BASIC)")
        '
        'BASICinitLineTextBox
        '
        Me.BASICinitLineTextBox.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BASICinitLineTextBox.Location = New System.Drawing.Point(491, 21)
        Me.BASICinitLineTextBox.MaxLength = 5
        Me.BASICinitLineTextBox.Name = "BASICinitLineTextBox"
        Me.BASICinitLineTextBox.Size = New System.Drawing.Size(52, 22)
        Me.BASICinitLineTextBox.TabIndex = 254
        Me.BASICinitLineTextBox.Text = "10000"
        Me.BASICinitLineTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.BASICinitLineTextBox, "Initial number of line (for BASIC)")
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(304, 123)
        Me.TextBox1.MaxLength = 3
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(52, 22)
        Me.TextBox1.TabIndex = 260
        Me.TextBox1.Text = "128"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.TextBox1, "Interval lines (for BASIC)")
        Me.TextBox1.Visible = False
        '
        'AsmWordDataTextBox
        '
        Me.AsmWordDataTextBox.Location = New System.Drawing.Point(117, 49)
        Me.AsmWordDataTextBox.Name = "AsmWordDataTextBox"
        Me.AsmWordDataTextBox.Size = New System.Drawing.Size(220, 22)
        Me.AsmWordDataTextBox.TabIndex = 247
        Me.ToolTip1.SetToolTip(Me.AsmWordDataTextBox, "Word Data command definition (DW, WORD, DEFW...)")
        '
        'CByteDataTextBox
        '
        Me.CByteDataTextBox.Location = New System.Drawing.Point(119, 21)
        Me.CByteDataTextBox.Name = "CByteDataTextBox"
        Me.CByteDataTextBox.Size = New System.Drawing.Size(220, 22)
        Me.CByteDataTextBox.TabIndex = 261
        Me.ToolTip1.SetToolTip(Me.CByteDataTextBox, "Byte Data command definition for C")
        '
        'BASICdataTextBox
        '
        Me.BASICdataTextBox.Location = New System.Drawing.Point(162, 21)
        Me.BASICdataTextBox.Name = "BASICdataTextBox"
        Me.BASICdataTextBox.Size = New System.Drawing.Size(128, 22)
        Me.BASICdataTextBox.TabIndex = 263
        Me.BASICdataTextBox.Text = "DATA"
        Me.ToolTip1.SetToolTip(Me.BASICdataTextBox, "Instruction for datas")
        '
        'InfoNameTextBox
        '
        Me.InfoNameTextBox.Location = New System.Drawing.Point(121, 18)
        Me.InfoNameTextBox.Name = "InfoNameTextBox"
        Me.InfoNameTextBox.Size = New System.Drawing.Size(452, 22)
        Me.InfoNameTextBox.TabIndex = 254
        Me.ToolTip1.SetToolTip(Me.InfoNameTextBox, "Username to assign the author by default in the project information.")
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(7, 18)
        Me.Label10.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(110, 22)
        Me.Label10.TabIndex = 255
        Me.Label10.Text = "Username"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.Label10, "Username to assign the author by default in the project information.")
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(8, 262)
        Me.Label11.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(110, 22)
        Me.Label11.TabIndex = 257
        Me.Label11.Text = "Zero Color"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.Label11, "Username to assign the author by default in the project information.")
        '
        'Color0Button
        '
        Me.Color0Button.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Color0Button.Location = New System.Drawing.Point(126, 260)
        Me.Color0Button.Name = "Color0Button"
        Me.Color0Button.Size = New System.Drawing.Size(110, 26)
        Me.Color0Button.TabIndex = 258
        Me.ToolTip1.SetToolTip(Me.Color0Button, "Define a color for the color zero to differentiate it from black.")
        Me.Color0Button.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(8, 294)
        Me.Label12.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(110, 22)
        Me.Label12.TabIndex = 259
        Me.Label12.Text = "Grid Color"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.Label12, "Username to assign the author by default in the project information.")
        '
        'BASICcommentComboBox
        '
        Me.BASICcommentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.BASICcommentComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BASICcommentComboBox.FormattingEnabled = True
        Me.BASICcommentComboBox.Items.AddRange(New Object() {"REM", "' (apostrophe)"})
        Me.BASICcommentComboBox.Location = New System.Drawing.Point(162, 49)
        Me.BASICcommentComboBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BASICcommentComboBox.Name = "BASICcommentComboBox"
        Me.BASICcommentComboBox.Size = New System.Drawing.Size(128, 22)
        Me.BASICcommentComboBox.TabIndex = 267
        Me.ToolTip1.SetToolTip(Me.BASICcommentComboBox, "Instruction for comments")
        '
        'OutputINKcolorButton
        '
        Me.OutputINKcolorButton.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OutputINKcolorButton.Location = New System.Drawing.Point(232, 49)
        Me.OutputINKcolorButton.Name = "OutputINKcolorButton"
        Me.OutputINKcolorButton.Size = New System.Drawing.Size(110, 26)
        Me.OutputINKcolorButton.TabIndex = 260
        Me.ToolTip1.SetToolTip(Me.OutputINKcolorButton, "Define a color for the color zero to differentiate it from black.")
        Me.OutputINKcolorButton.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(11, 51)
        Me.Label14.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(213, 22)
        Me.Label14.TabIndex = 259
        Me.Label14.Text = "Ink Color"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.Label14, "Username to assign the author by default in the project information.")
        '
        'OutputBGcolorButton
        '
        Me.OutputBGcolorButton.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OutputBGcolorButton.Location = New System.Drawing.Point(232, 81)
        Me.OutputBGcolorButton.Name = "OutputBGcolorButton"
        Me.OutputBGcolorButton.Size = New System.Drawing.Size(110, 26)
        Me.OutputBGcolorButton.TabIndex = 262
        Me.ToolTip1.SetToolTip(Me.OutputBGcolorButton, "Define a color for the color zero to differentiate it from black.")
        Me.OutputBGcolorButton.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(8, 83)
        Me.Label15.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(216, 22)
        Me.Label15.TabIndex = 261
        Me.Label15.Text = "Background Color"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.Label15, "Username to assign the author by default in the project information.")
        '
        'BASICGroupBox
        '
        Me.BASICGroupBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BASICGroupBox.BackColor = System.Drawing.Color.Transparent
        Me.BASICGroupBox.Controls.Add(Me.BASICcommentComboBox)
        Me.BASICGroupBox.Controls.Add(Me.Label13)
        Me.BASICGroupBox.Controls.Add(Me.Label9)
        Me.BASICGroupBox.Controls.Add(Me.BASICdataTextBox)
        Me.BASICGroupBox.Controls.Add(Me.RemoveZerosCheck)
        Me.BASICGroupBox.Controls.Add(Me.LineNumberLabel)
        Me.BASICGroupBox.Controls.Add(Me.BASICincLineslTextBox)
        Me.BASICGroupBox.Controls.Add(Me.BASICinitLineTextBox)
        Me.BASICGroupBox.Controls.Add(Me.IntervalLabel)
        Me.BASICGroupBox.ForeColor = System.Drawing.Color.Black
        Me.BASICGroupBox.Location = New System.Drawing.Point(17, 349)
        Me.BASICGroupBox.Name = "BASICGroupBox"
        Me.BASICGroupBox.Size = New System.Drawing.Size(559, 109)
        Me.BASICGroupBox.TabIndex = 249
        Me.BASICGroupBox.TabStop = False
        Me.BASICGroupBox.Text = "BASIC"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(8, 49)
        Me.Label13.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(150, 22)
        Me.Label13.TabIndex = 266
        Me.Label13.Text = "Comment Instruction:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(11, 21)
        Me.Label9.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(147, 22)
        Me.Label9.TabIndex = 264
        Me.Label9.Text = "Data Instruction:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RemoveZerosCheck
        '
        Me.RemoveZerosCheck.BackColor = System.Drawing.Color.Transparent
        Me.RemoveZerosCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RemoveZerosCheck.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RemoveZerosCheck.Location = New System.Drawing.Point(418, 78)
        Me.RemoveZerosCheck.Name = "RemoveZerosCheck"
        Me.RemoveZerosCheck.Size = New System.Drawing.Size(125, 22)
        Me.RemoveZerosCheck.TabIndex = 258
        Me.RemoveZerosCheck.Text = "Remove zeros:"
        Me.RemoveZerosCheck.UseVisualStyleBackColor = False
        '
        'LineNumberLabel
        '
        Me.LineNumberLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LineNumberLabel.Location = New System.Drawing.Point(380, 21)
        Me.LineNumberLabel.Name = "LineNumberLabel"
        Me.LineNumberLabel.Size = New System.Drawing.Size(110, 22)
        Me.LineNumberLabel.TabIndex = 256
        Me.LineNumberLabel.Text = "Line number:"
        Me.LineNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'IntervalLabel
        '
        Me.IntervalLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IntervalLabel.Location = New System.Drawing.Point(377, 49)
        Me.IntervalLabel.Name = "IntervalLabel"
        Me.IntervalLabel.Size = New System.Drawing.Size(110, 22)
        Me.IntervalLabel.TabIndex = 257
        Me.IntervalLabel.Text = "Interval:"
        Me.IntervalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(5, 21)
        Me.Label8.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(110, 22)
        Me.Label8.TabIndex = 262
        Me.Label8.Text = "C Byte:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Enabled = False
        Me.Label6.Location = New System.Drawing.Point(100, 123)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(196, 22)
        Me.Label6.TabIndex = 259
        Me.Label6.Text = "RLE WB code (decimal)"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label6.Visible = False
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(20, 151)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 22)
        Me.Label5.TabIndex = 253
        Me.Label5.Text = "Label:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(3, 49)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(110, 22)
        Me.Label7.TabIndex = 251
        Me.Label7.Text = "Asm Word:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(3, 21)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 22)
        Me.Label4.TabIndex = 251
        Me.Label4.Text = "Asm Byte:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(17, 94)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 22)
        Me.Label3.TabIndex = 250
        Me.Label3.Text = "Compress:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(17, 66)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 22)
        Me.Label2.TabIndex = 249
        Me.Label2.Text = "Line size:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(17, 38)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 22)
        Me.Label1.TabIndex = 248
        Me.Label1.Text = "Number system:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK_Button.BackColor = System.Drawing.Color.PaleGreen
        Me.OK_Button.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK_Button.Location = New System.Drawing.Point(423, 512)
        Me.OK_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(110, 36)
        Me.OK_Button.TabIndex = 250
        Me.OK_Button.Text = "Ok"
        Me.OK_Button.UseVisualStyleBackColor = False
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel_Button.BackColor = System.Drawing.Color.LightSalmon
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_Button.Location = New System.Drawing.Point(541, 518)
        Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(70, 30)
        Me.Cancel_Button.TabIndex = 251
        Me.Cancel_Button.Text = "Cancel"
        Me.Cancel_Button.UseVisualStyleBackColor = False
        '
        'PathsPanel
        '
        Me.PathsPanel.AutoScroll = True
        Me.PathsPanel.Controls.Add(Me.BinaryPathControl)
        Me.PathsPanel.Controls.Add(Me.BitmapsPathControl)
        Me.PathsPanel.Controls.Add(Me.MSXBASICPathControl)
        Me.PathsPanel.Controls.Add(Me.PalettesPathControl)
        Me.PathsPanel.Controls.Add(Me.OAMPathControl)
        Me.PathsPanel.Controls.Add(Me.BytegenPathControl)
        Me.PathsPanel.Controls.Add(Me.nMSXtilesPathControl)
        Me.PathsPanel.Controls.Add(Me.SquaredsetsPathControl)
        Me.PathsPanel.Controls.Add(Me.TilesetsPathControl)
        Me.PathsPanel.Controls.Add(Me.MapsPathControl)
        Me.PathsPanel.Controls.Add(Me.SpritesPathControl)
        Me.PathsPanel.Controls.Add(Me.tMSgfXProjectPathControl)
        Me.PathsPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PathsPanel.Location = New System.Drawing.Point(3, 3)
        Me.PathsPanel.Name = "PathsPanel"
        Me.PathsPanel.Size = New System.Drawing.Size(586, 461)
        Me.PathsPanel.TabIndex = 256
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.OthersTab)
        Me.TabControl1.Controls.Add(Me.DataOutputTab)
        Me.TabControl1.Controls.Add(Me.PathsTab)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(600, 493)
        Me.TabControl1.TabIndex = 256
        '
        'OthersTab
        '
        Me.OthersTab.BackColor = System.Drawing.Color.WhiteSmoke
        Me.OthersTab.Controls.Add(Me.OutputdataGroupBox)
        Me.OthersTab.Controls.Add(Me.GridColorButton)
        Me.OthersTab.Controls.Add(Me.Label12)
        Me.OthersTab.Controls.Add(Me.Color0Button)
        Me.OthersTab.Controls.Add(Me.Label11)
        Me.OthersTab.Controls.Add(Me.GroupBox1)
        Me.OthersTab.Controls.Add(Me.Label10)
        Me.OthersTab.Controls.Add(Me.InfoNameTextBox)
        Me.OthersTab.Location = New System.Drawing.Point(4, 23)
        Me.OthersTab.Name = "OthersTab"
        Me.OthersTab.Padding = New System.Windows.Forms.Padding(3)
        Me.OthersTab.Size = New System.Drawing.Size(592, 466)
        Me.OthersTab.TabIndex = 2
        Me.OthersTab.Text = "Miscellany"
        '
        'OutputdataGroupBox
        '
        Me.OutputdataGroupBox.Controls.Add(Me.OutputBGcolorButton)
        Me.OutputdataGroupBox.Controls.Add(Me.Label15)
        Me.OutputdataGroupBox.Controls.Add(Me.OutputINKcolorButton)
        Me.OutputdataGroupBox.Controls.Add(Me.Label14)
        Me.OutputdataGroupBox.Controls.Add(Me.ColorConfigsLabel)
        Me.OutputdataGroupBox.Controls.Add(Me.ColorConfigsComboBox)
        Me.OutputdataGroupBox.Location = New System.Drawing.Point(38, 335)
        Me.OutputdataGroupBox.Name = "OutputdataGroupBox"
        Me.OutputdataGroupBox.Size = New System.Drawing.Size(535, 114)
        Me.OutputdataGroupBox.TabIndex = 261
        Me.OutputdataGroupBox.TabStop = False
        Me.OutputdataGroupBox.Text = "Output Data colors"
        '
        'ColorConfigsLabel
        '
        Me.ColorConfigsLabel.Location = New System.Drawing.Point(11, 21)
        Me.ColorConfigsLabel.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.ColorConfigsLabel.Name = "ColorConfigsLabel"
        Me.ColorConfigsLabel.Size = New System.Drawing.Size(104, 22)
        Me.ColorConfigsLabel.TabIndex = 242
        Me.ColorConfigsLabel.Text = "Configs:"
        Me.ColorConfigsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ColorConfigsComboBox
        '
        Me.ColorConfigsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ColorConfigsComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ColorConfigsComboBox.FormattingEnabled = True
        Me.ColorConfigsComboBox.Items.AddRange(New Object() {"Gray (default)", "Blue MSX BASIC", "Green GB", "Green Monitor"})
        Me.ColorConfigsComboBox.Location = New System.Drawing.Point(121, 21)
        Me.ColorConfigsComboBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ColorConfigsComboBox.Name = "ColorConfigsComboBox"
        Me.ColorConfigsComboBox.Size = New System.Drawing.Size(221, 22)
        Me.ColorConfigsComboBox.TabIndex = 243
        '
        'GridColorButton
        '
        Me.GridColorButton.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColorButton.Location = New System.Drawing.Point(126, 292)
        Me.GridColorButton.Name = "GridColorButton"
        Me.GridColorButton.Size = New System.Drawing.Size(110, 26)
        Me.GridColorButton.TabIndex = 260
        Me.GridColorButton.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PathLastPRJTextBox)
        Me.GroupBox1.Controls.Add(Me.RadioButton3)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Location = New System.Drawing.Point(38, 70)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(535, 173)
        Me.GroupBox1.TabIndex = 256
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "tMSgfX Init Project"
        '
        'PathLastPRJTextBox
        '
        Me.PathLastPRJTextBox.Location = New System.Drawing.Point(39, 129)
        Me.PathLastPRJTextBox.Name = "PathLastPRJTextBox"
        Me.PathLastPRJTextBox.ReadOnly = True
        Me.PathLastPRJTextBox.Size = New System.Drawing.Size(490, 22)
        Me.PathLastPRJTextBox.TabIndex = 4
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(19, 105)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(175, 18)
        Me.RadioButton3.TabIndex = 3
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "Load last edited project"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(19, 68)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(185, 18)
        Me.RadioButton2.TabIndex = 2
        Me.RadioButton2.Text = "Start a new blank project"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(19, 33)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(188, 18)
        Me.RadioButton1.TabIndex = 1
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Load tMSgfX Presentation"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'DataOutputTab
        '
        Me.DataOutputTab.BackColor = System.Drawing.Color.WhiteSmoke
        Me.DataOutputTab.Controls.Add(Me.GroupBox3)
        Me.DataOutputTab.Controls.Add(Me.GroupBox2)
        Me.DataOutputTab.Controls.Add(Me.Label21)
        Me.DataOutputTab.Controls.Add(Me.CompressTypeComboBox)
        Me.DataOutputTab.Controls.Add(Me.BASICGroupBox)
        Me.DataOutputTab.Controls.Add(Me.TextBox1)
        Me.DataOutputTab.Controls.Add(Me.Label6)
        Me.DataOutputTab.Controls.Add(Me.SizeLineComboBox)
        Me.DataOutputTab.Controls.Add(Me.NumFormatComboBox)
        Me.DataOutputTab.Controls.Add(Me.CodeOutputComboBox)
        Me.DataOutputTab.Controls.Add(Me.Label5)
        Me.DataOutputTab.Controls.Add(Me.Label1)
        Me.DataOutputTab.Controls.Add(Me.DataLabelTextBox)
        Me.DataOutputTab.Controls.Add(Me.Label2)
        Me.DataOutputTab.Controls.Add(Me.Label3)
        Me.DataOutputTab.Location = New System.Drawing.Point(4, 22)
        Me.DataOutputTab.Name = "DataOutputTab"
        Me.DataOutputTab.Padding = New System.Windows.Forms.Padding(3)
        Me.DataOutputTab.Size = New System.Drawing.Size(592, 467)
        Me.DataOutputTab.TabIndex = 1
        Me.DataOutputTab.Text = "Default Data Output"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CByteDataTextBox)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Location = New System.Drawing.Point(17, 289)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(559, 54)
        Me.GroupBox3.TabIndex = 268
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "C"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.arrow2PictureBox)
        Me.GroupBox2.Controls.Add(Me.AsmByteDataTextBox)
        Me.GroupBox2.Controls.Add(Me.arrow1PictureBox)
        Me.GroupBox2.Controls.Add(Me.AsmWordDataTextBox)
        Me.GroupBox2.Controls.Add(Me.AsmWordValuesComboBox)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.AsmByteValuesComboBox)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 200)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(559, 83)
        Me.GroupBox2.TabIndex = 267
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Assembler"
        '
        'arrow2PictureBox
        '
        Me.arrow2PictureBox.Image = Global.mSXdevtools.GUI.Controls.My.Resources.Resources.arrow_left_24blue
        Me.arrow2PictureBox.Location = New System.Drawing.Point(343, 49)
        Me.arrow2PictureBox.Name = "arrow2PictureBox"
        Me.arrow2PictureBox.Size = New System.Drawing.Size(24, 24)
        Me.arrow2PictureBox.TabIndex = 266
        Me.arrow2PictureBox.TabStop = False
        '
        'arrow1PictureBox
        '
        Me.arrow1PictureBox.Image = Global.mSXdevtools.GUI.Controls.My.Resources.Resources.arrow_left_24blue
        Me.arrow1PictureBox.Location = New System.Drawing.Point(343, 20)
        Me.arrow1PictureBox.Name = "arrow1PictureBox"
        Me.arrow1PictureBox.Size = New System.Drawing.Size(24, 24)
        Me.arrow1PictureBox.TabIndex = 265
        Me.arrow1PictureBox.TabStop = False
        '
        'AsmWordValuesComboBox
        '
        Me.AsmWordValuesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.AsmWordValuesComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.AsmWordValuesComboBox.FormattingEnabled = True
        Me.AsmWordValuesComboBox.Items.AddRange(New Object() {"dw", "DW", "WORD", "DEFW", "<tab>DW", "<tab>WORD", "<tab>DEFW"})
        Me.AsmWordValuesComboBox.Location = New System.Drawing.Point(372, 50)
        Me.AsmWordValuesComboBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.AsmWordValuesComboBox.Name = "AsmWordValuesComboBox"
        Me.AsmWordValuesComboBox.Size = New System.Drawing.Size(171, 22)
        Me.AsmWordValuesComboBox.TabIndex = 264
        '
        'AsmByteValuesComboBox
        '
        Me.AsmByteValuesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.AsmByteValuesComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.AsmByteValuesComboBox.FormattingEnabled = True
        Me.AsmByteValuesComboBox.Items.AddRange(New Object() {"db", "DB", "BYTE", "DEFB", "DEFM", "<tab>DB", "<tab>BYTE", "<tab>DEFB", "<tab>DEFM"})
        Me.AsmByteValuesComboBox.Location = New System.Drawing.Point(372, 21)
        Me.AsmByteValuesComboBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.AsmByteValuesComboBox.Name = "AsmByteValuesComboBox"
        Me.AsmByteValuesComboBox.Size = New System.Drawing.Size(171, 22)
        Me.AsmByteValuesComboBox.TabIndex = 263
        '
        'PathsTab
        '
        Me.PathsTab.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PathsTab.Controls.Add(Me.PathsPanel)
        Me.PathsTab.Location = New System.Drawing.Point(4, 22)
        Me.PathsTab.Name = "PathsTab"
        Me.PathsTab.Padding = New System.Windows.Forms.Padding(3)
        Me.PathsTab.Size = New System.Drawing.Size(592, 467)
        Me.PathsTab.TabIndex = 0
        Me.PathsTab.Text = "Default paths"
        '
        'BinaryPathControl
        '
        Me.BinaryPathControl.Dock = System.Windows.Forms.DockStyle.Top
        Me.BinaryPathControl.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BinaryPathControl.Label = "Binary"
        Me.BinaryPathControl.Location = New System.Drawing.Point(0, 352)
        Me.BinaryPathControl.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BinaryPathControl.Name = "BinaryPathControl"
        Me.BinaryPathControl.Size = New System.Drawing.Size(586, 32)
        Me.BinaryPathControl.TabIndex = 267
        Me.BinaryPathControl.Visible = False
        '
        'BitmapsPathControl
        '
        Me.BitmapsPathControl.Dock = System.Windows.Forms.DockStyle.Top
        Me.BitmapsPathControl.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BitmapsPathControl.Label = "Bitmaps"
        Me.BitmapsPathControl.Location = New System.Drawing.Point(0, 320)
        Me.BitmapsPathControl.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BitmapsPathControl.Name = "BitmapsPathControl"
        Me.BitmapsPathControl.Size = New System.Drawing.Size(586, 32)
        Me.BitmapsPathControl.TabIndex = 264
        Me.BitmapsPathControl.Visible = False
        '
        'MSXBASICPathControl
        '
        Me.MSXBASICPathControl.Dock = System.Windows.Forms.DockStyle.Top
        Me.MSXBASICPathControl.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MSXBASICPathControl.Label = "MSX BASIC"
        Me.MSXBASICPathControl.Location = New System.Drawing.Point(0, 288)
        Me.MSXBASICPathControl.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MSXBASICPathControl.Name = "MSXBASICPathControl"
        Me.MSXBASICPathControl.Size = New System.Drawing.Size(586, 32)
        Me.MSXBASICPathControl.TabIndex = 263
        Me.MSXBASICPathControl.Visible = False
        '
        'PalettesPathControl
        '
        Me.PalettesPathControl.Dock = System.Windows.Forms.DockStyle.Top
        Me.PalettesPathControl.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PalettesPathControl.Label = "Palettes"
        Me.PalettesPathControl.Location = New System.Drawing.Point(0, 256)
        Me.PalettesPathControl.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PalettesPathControl.Name = "PalettesPathControl"
        Me.PalettesPathControl.Size = New System.Drawing.Size(586, 32)
        Me.PalettesPathControl.TabIndex = 265
        Me.PalettesPathControl.Visible = False
        '
        'OAMPathControl
        '
        Me.OAMPathControl.Dock = System.Windows.Forms.DockStyle.Top
        Me.OAMPathControl.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OAMPathControl.Label = "OAM"
        Me.OAMPathControl.Location = New System.Drawing.Point(0, 224)
        Me.OAMPathControl.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.OAMPathControl.Name = "OAMPathControl"
        Me.OAMPathControl.Size = New System.Drawing.Size(586, 32)
        Me.OAMPathControl.TabIndex = 266
        Me.OAMPathControl.Visible = False
        '
        'BytegenPathControl
        '
        Me.BytegenPathControl.Dock = System.Windows.Forms.DockStyle.Top
        Me.BytegenPathControl.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BytegenPathControl.Label = "ByteGen Project"
        Me.BytegenPathControl.Location = New System.Drawing.Point(0, 192)
        Me.BytegenPathControl.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BytegenPathControl.Name = "BytegenPathControl"
        Me.BytegenPathControl.Size = New System.Drawing.Size(586, 32)
        Me.BytegenPathControl.TabIndex = 271
        '
        'nMSXtilesPathControl
        '
        Me.nMSXtilesPathControl.Dock = System.Windows.Forms.DockStyle.Top
        Me.nMSXtilesPathControl.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nMSXtilesPathControl.Label = "Pentacour's nMSXtiles"
        Me.nMSXtilesPathControl.Location = New System.Drawing.Point(0, 160)
        Me.nMSXtilesPathControl.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.nMSXtilesPathControl.Name = "nMSXtilesPathControl"
        Me.nMSXtilesPathControl.Size = New System.Drawing.Size(586, 32)
        Me.nMSXtilesPathControl.TabIndex = 262
        Me.nMSXtilesPathControl.Visible = False
        '
        'SquaredsetsPathControl
        '
        Me.SquaredsetsPathControl.Dock = System.Windows.Forms.DockStyle.Top
        Me.SquaredsetsPathControl.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SquaredsetsPathControl.Label = "Squaredsets Project"
        Me.SquaredsetsPathControl.Location = New System.Drawing.Point(0, 128)
        Me.SquaredsetsPathControl.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SquaredsetsPathControl.Name = "SquaredsetsPathControl"
        Me.SquaredsetsPathControl.Size = New System.Drawing.Size(586, 32)
        Me.SquaredsetsPathControl.TabIndex = 270
        Me.SquaredsetsPathControl.Visible = False
        '
        'TilesetsPathControl
        '
        Me.TilesetsPathControl.Dock = System.Windows.Forms.DockStyle.Top
        Me.TilesetsPathControl.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TilesetsPathControl.Label = "Tilesets Project"
        Me.TilesetsPathControl.Location = New System.Drawing.Point(0, 96)
        Me.TilesetsPathControl.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TilesetsPathControl.Name = "TilesetsPathControl"
        Me.TilesetsPathControl.Size = New System.Drawing.Size(586, 32)
        Me.TilesetsPathControl.TabIndex = 269
        Me.TilesetsPathControl.Visible = False
        '
        'MapsPathControl
        '
        Me.MapsPathControl.Dock = System.Windows.Forms.DockStyle.Top
        Me.MapsPathControl.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MapsPathControl.Label = "Maps Project"
        Me.MapsPathControl.Location = New System.Drawing.Point(0, 64)
        Me.MapsPathControl.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MapsPathControl.Name = "MapsPathControl"
        Me.MapsPathControl.Size = New System.Drawing.Size(586, 32)
        Me.MapsPathControl.TabIndex = 268
        Me.MapsPathControl.Visible = False
        '
        'SpritesPathControl
        '
        Me.SpritesPathControl.Dock = System.Windows.Forms.DockStyle.Top
        Me.SpritesPathControl.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpritesPathControl.Label = "Sprites Project"
        Me.SpritesPathControl.Location = New System.Drawing.Point(0, 32)
        Me.SpritesPathControl.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SpritesPathControl.Name = "SpritesPathControl"
        Me.SpritesPathControl.Size = New System.Drawing.Size(586, 32)
        Me.SpritesPathControl.TabIndex = 260
        Me.SpritesPathControl.Visible = False
        '
        'tMSgfXProjectPathControl
        '
        Me.tMSgfXProjectPathControl.Dock = System.Windows.Forms.DockStyle.Top
        Me.tMSgfXProjectPathControl.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tMSgfXProjectPathControl.Label = "tMSgfX Project"
        Me.tMSgfXProjectPathControl.Location = New System.Drawing.Point(0, 0)
        Me.tMSgfXProjectPathControl.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.tMSgfXProjectPathControl.Name = "tMSgfXProjectPathControl"
        Me.tMSgfXProjectPathControl.Size = New System.Drawing.Size(586, 32)
        Me.tMSgfXProjectPathControl.TabIndex = 261
        Me.tMSgfXProjectPathControl.Visible = False
        '
        'ConfigWin
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(624, 584)
        Me.ControlBox = False
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MinimumSize = New System.Drawing.Size(640, 600)
        Me.Name = "ConfigWin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "devTools Config"
        Me.BASICGroupBox.ResumeLayout(False)
        Me.BASICGroupBox.PerformLayout()
        Me.PathsPanel.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.OthersTab.ResumeLayout(False)
        Me.OthersTab.PerformLayout()
        Me.OutputdataGroupBox.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.DataOutputTab.ResumeLayout(False)
        Me.DataOutputTab.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.arrow2PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.arrow1PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PathsTab.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NumFormatComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents CompressTypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents SizeLineComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents CodeOutputComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents BASICGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Private WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents AsmByteDataTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DataLabelTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SpritesPathControl As PathEntryControl
    Friend WithEvents tMSgfXProjectPathControl As PathEntryControl
    Friend WithEvents nMSXtilesPathControl As PathEntryControl
    Friend WithEvents MSXBASICPathControl As PathEntryControl
    Friend WithEvents BitmapsPathControl As PathEntryControl
    Friend WithEvents PalettesPathControl As PathEntryControl
    Friend WithEvents OAMPathControl As PathEntryControl
    Friend WithEvents PathsPanel As System.Windows.Forms.Panel
    Friend WithEvents BinaryPathControl As PathEntryControl
    Friend WithEvents SquaredsetsPathControl As PathEntryControl
    Friend WithEvents TilesetsPathControl As PathEntryControl
    Friend WithEvents MapsPathControl As PathEntryControl
    Friend WithEvents BytegenPathControl As PathEntryControl
    Friend WithEvents LineNumberLabel As System.Windows.Forms.Label
    Friend WithEvents BASICincLineslTextBox As System.Windows.Forms.TextBox
    Friend WithEvents BASICinitLineTextBox As System.Windows.Forms.TextBox
    Friend WithEvents IntervalLabel As System.Windows.Forms.Label
    Friend WithEvents RemoveZerosCheck As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents AsmWordDataTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CByteDataTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents PathsTab As TabPage
    Friend WithEvents DataOutputTab As TabPage
    Friend WithEvents Label9 As Label
    Friend WithEvents BASICdataTextBox As TextBox
    Friend WithEvents OthersTab As TabPage
    Friend WithEvents Label10 As Label
    Friend WithEvents InfoNameTextBox As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents PathLastPRJTextBox As TextBox
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents GridColorButton As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents Color0Button As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents AsmByteValuesComboBox As ComboBox
    Friend WithEvents AsmWordValuesComboBox As ComboBox
    Friend WithEvents arrow2PictureBox As PictureBox
    Friend WithEvents arrow1PictureBox As PictureBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents BASICcommentComboBox As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents OutputdataGroupBox As GroupBox
    Friend WithEvents OutputBGcolorButton As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents OutputINKcolorButton As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents ColorConfigsLabel As Label
    Friend WithEvents ColorConfigsComboBox As ComboBox
End Class
