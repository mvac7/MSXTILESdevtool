<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class paletteEditor
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
        Me.components = New System.ComponentModel.Container()
        Me.PaletteToolStrip = New System.Windows.Forms.ToolStrip()
        Me.NewPaletteButton = New System.Windows.Forms.ToolStripButton()
        Me.LoadPaletteButton = New System.Windows.Forms.ToolStripButton()
        Me.DuplicatePaletteButton = New System.Windows.Forms.ToolStripButton()
        Me.PaletteComboBox = New System.Windows.Forms.ToolStripComboBox()
        Me.ConfigPaletteButton = New System.Windows.Forms.ToolStripButton()
        Me.DeletePaletteButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.GetDataButton = New System.Windows.Forms.ToolStripButton()
        Me.HelpButton = New System.Windows.Forms.ToolStripButton()
        Me.PalettePanel = New System.Windows.Forms.Panel()
        Me.ColorArrowPictureBox = New System.Windows.Forms.PictureBox()
        Me.EditPalettePanel = New System.Windows.Forms.Panel()
        Me.ToolboxStrip = New System.Windows.Forms.ToolStrip()
        Me.CopyButton = New System.Windows.Forms.ToolStripButton()
        Me.ChangeButton = New System.Windows.Forms.ToolStripButton()
        Me.ClearButton = New System.Windows.Forms.ToolStripButton()
        Me.UndoButton = New System.Windows.Forms.ToolStripButton()
        Me.RBGTextBox = New System.Windows.Forms.TextBox()
        Me.NumColorLabel = New System.Windows.Forms.Label()
        Me.RGB24TextBox = New System.Windows.Forms.TextBox()
        Me.ColorPickerComboBox = New System.Windows.Forms.ComboBox()
        Me.RedTrackBar = New System.Windows.Forms.TrackBar()
        Me.UpdateButton = New System.Windows.Forms.Button()
        Me.GreenTrackBar = New System.Windows.Forms.TrackBar()
        Me.BlueTrackBar = New System.Windows.Forms.TrackBar()
        Me.RedTextBox = New System.Windows.Forms.TextBox()
        Me.RestoreOldColorPictureBox = New System.Windows.Forms.PictureBox()
        Me.GreenTextBox = New System.Windows.Forms.TextBox()
        Me.ColorPickerPictureBox = New System.Windows.Forms.PictureBox()
        Me.BlueTextBox = New System.Windows.Forms.TextBox()
        Me.ToneTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ToneTrackBar = New System.Windows.Forms.TrackBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.PaletteToolStrip.SuspendLayout()
        Me.PalettePanel.SuspendLayout()
        CType(Me.ColorArrowPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EditPalettePanel.SuspendLayout()
        Me.ToolboxStrip.SuspendLayout()
        CType(Me.RedTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GreenTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BlueTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RestoreOldColorPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ColorPickerPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToneTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PaletteToolStrip
        '
        Me.PaletteToolStrip.BackColor = System.Drawing.Color.Gainsboro
        Me.PaletteToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.PaletteToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewPaletteButton, Me.LoadPaletteButton, Me.DuplicatePaletteButton, Me.PaletteComboBox, Me.ConfigPaletteButton, Me.DeletePaletteButton, Me.ToolStripSeparator3, Me.SaveButton, Me.ToolStripSeparator1, Me.GetDataButton, Me.HelpButton})
        Me.PaletteToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.PaletteToolStrip.Name = "PaletteToolStrip"
        Me.PaletteToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.PaletteToolStrip.Size = New System.Drawing.Size(490, 31)
        Me.PaletteToolStrip.TabIndex = 26
        Me.PaletteToolStrip.Text = "PaletteToolStrip"
        '
        'NewPaletteButton
        '
        Me.NewPaletteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NewPaletteButton.Image = Global.mSXdevtools.V9938PaletteEditor.My.Resources.Resources.new_24
        Me.NewPaletteButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewPaletteButton.Name = "NewPaletteButton"
        Me.NewPaletteButton.Size = New System.Drawing.Size(28, 28)
        Me.NewPaletteButton.ToolTipText = "New Palette"
        '
        'LoadPaletteButton
        '
        Me.LoadPaletteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.LoadPaletteButton.Image = Global.mSXdevtools.V9938PaletteEditor.My.Resources.Resources.merge_x24
        Me.LoadPaletteButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LoadPaletteButton.Name = "LoadPaletteButton"
        Me.LoadPaletteButton.Size = New System.Drawing.Size(28, 28)
        Me.LoadPaletteButton.Text = "LoadButton"
        Me.LoadPaletteButton.ToolTipText = "Load Palette"
        '
        'DuplicatePaletteButton
        '
        Me.DuplicatePaletteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.DuplicatePaletteButton.Image = Global.mSXdevtools.V9938PaletteEditor.My.Resources.Resources.CopyPaste2_24
        Me.DuplicatePaletteButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.DuplicatePaletteButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DuplicatePaletteButton.Name = "DuplicatePaletteButton"
        Me.DuplicatePaletteButton.Size = New System.Drawing.Size(28, 28)
        Me.DuplicatePaletteButton.Text = "ToolStripButton1"
        Me.DuplicatePaletteButton.ToolTipText = "Duplicate Palette"
        '
        'PaletteComboBox
        '
        Me.PaletteComboBox.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PaletteComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.PaletteComboBox.Name = "PaletteComboBox"
        Me.PaletteComboBox.Size = New System.Drawing.Size(220, 31)
        '
        'ConfigPaletteButton
        '
        Me.ConfigPaletteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ConfigPaletteButton.Image = Global.mSXdevtools.V9938PaletteEditor.My.Resources.Resources.project_properties_24p
        Me.ConfigPaletteButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ConfigPaletteButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ConfigPaletteButton.Name = "ConfigPaletteButton"
        Me.ConfigPaletteButton.Size = New System.Drawing.Size(28, 28)
        Me.ConfigPaletteButton.Text = "Edit project information"
        Me.ConfigPaletteButton.ToolTipText = "Edit Palette Name"
        '
        'DeletePaletteButton
        '
        Me.DeletePaletteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.DeletePaletteButton.Image = Global.mSXdevtools.V9938PaletteEditor.My.Resources.Resources.trashcan01R_24
        Me.DeletePaletteButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.DeletePaletteButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DeletePaletteButton.Name = "DeletePaletteButton"
        Me.DeletePaletteButton.Size = New System.Drawing.Size(28, 28)
        Me.DeletePaletteButton.ToolTipText = "Delete Palette"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'SaveButton
        '
        Me.SaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveButton.Image = Global.mSXdevtools.V9938PaletteEditor.My.Resources.Resources.save
        Me.SaveButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(28, 28)
        Me.SaveButton.ToolTipText = "Save Color Palette"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'GetDataButton
        '
        Me.GetDataButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.GetDataButton.Image = Global.mSXdevtools.V9938PaletteEditor.My.Resources.Resources.dataOutput_24green
        Me.GetDataButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GetDataButton.Name = "GetDataButton"
        Me.GetDataButton.Size = New System.Drawing.Size(28, 28)
        Me.GetDataButton.Text = "ToolStripButton1"
        Me.GetDataButton.ToolTipText = "Generates source code data."
        Me.GetDataButton.Visible = False
        '
        'HelpButton
        '
        Me.HelpButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.HelpButton.Image = Global.mSXdevtools.V9938PaletteEditor.My.Resources.Resources.help_x24
        Me.HelpButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.HelpButton.Name = "HelpButton"
        Me.HelpButton.Size = New System.Drawing.Size(28, 28)
        Me.HelpButton.Text = "ToolStripButton1"
        Me.HelpButton.ToolTipText = "Help"
        Me.HelpButton.Visible = False
        '
        'PalettePanel
        '
        Me.PalettePanel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PalettePanel.Controls.Add(Me.ColorArrowPictureBox)
        Me.PalettePanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.PalettePanel.Location = New System.Drawing.Point(0, 31)
        Me.PalettePanel.Name = "PalettePanel"
        Me.PalettePanel.Size = New System.Drawing.Size(64, 299)
        Me.PalettePanel.TabIndex = 28
        '
        'ColorArrowPictureBox
        '
        Me.ColorArrowPictureBox.Image = Global.mSXdevtools.V9938PaletteEditor.My.Resources.Resources.flecha8x16
        Me.ColorArrowPictureBox.Location = New System.Drawing.Point(56, 33)
        Me.ColorArrowPictureBox.Name = "ColorArrowPictureBox"
        Me.ColorArrowPictureBox.Size = New System.Drawing.Size(8, 16)
        Me.ColorArrowPictureBox.TabIndex = 20
        Me.ColorArrowPictureBox.TabStop = False
        '
        'EditPalettePanel
        '
        Me.EditPalettePanel.BackColor = System.Drawing.Color.LightGray
        Me.EditPalettePanel.Controls.Add(Me.ToolboxStrip)
        Me.EditPalettePanel.Controls.Add(Me.RBGTextBox)
        Me.EditPalettePanel.Controls.Add(Me.NumColorLabel)
        Me.EditPalettePanel.Controls.Add(Me.RGB24TextBox)
        Me.EditPalettePanel.Controls.Add(Me.ColorPickerComboBox)
        Me.EditPalettePanel.Controls.Add(Me.RedTrackBar)
        Me.EditPalettePanel.Controls.Add(Me.UpdateButton)
        Me.EditPalettePanel.Controls.Add(Me.GreenTrackBar)
        Me.EditPalettePanel.Controls.Add(Me.BlueTrackBar)
        Me.EditPalettePanel.Controls.Add(Me.RedTextBox)
        Me.EditPalettePanel.Controls.Add(Me.RestoreOldColorPictureBox)
        Me.EditPalettePanel.Controls.Add(Me.GreenTextBox)
        Me.EditPalettePanel.Controls.Add(Me.ColorPickerPictureBox)
        Me.EditPalettePanel.Controls.Add(Me.BlueTextBox)
        Me.EditPalettePanel.Controls.Add(Me.ToneTextBox)
        Me.EditPalettePanel.Controls.Add(Me.Label4)
        Me.EditPalettePanel.Controls.Add(Me.ToneTrackBar)
        Me.EditPalettePanel.Controls.Add(Me.Label3)
        Me.EditPalettePanel.Controls.Add(Me.Label1)
        Me.EditPalettePanel.Controls.Add(Me.Label2)
        Me.EditPalettePanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EditPalettePanel.Location = New System.Drawing.Point(64, 31)
        Me.EditPalettePanel.Name = "EditPalettePanel"
        Me.EditPalettePanel.Size = New System.Drawing.Size(426, 299)
        Me.EditPalettePanel.TabIndex = 29
        '
        'ToolboxStrip
        '
        Me.ToolboxStrip.BackColor = System.Drawing.Color.Gainsboro
        Me.ToolboxStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolboxStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyButton, Me.ChangeButton, Me.ClearButton, Me.UndoButton})
        Me.ToolboxStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolboxStrip.Name = "ToolboxStrip"
        Me.ToolboxStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolboxStrip.Size = New System.Drawing.Size(426, 31)
        Me.ToolboxStrip.TabIndex = 260
        Me.ToolboxStrip.Text = "ToolStrip1"
        '
        'CopyButton
        '
        Me.CopyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CopyButton.Image = Global.mSXdevtools.V9938PaletteEditor.My.Resources.Resources.copy_24
        Me.CopyButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopyButton.Name = "CopyButton"
        Me.CopyButton.Size = New System.Drawing.Size(28, 28)
        Me.CopyButton.Text = "ToolStripButton1"
        Me.CopyButton.ToolTipText = "Copy color"
        '
        'ChangeButton
        '
        Me.ChangeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ChangeButton.Image = Global.mSXdevtools.V9938PaletteEditor.My.Resources.Resources.exchange_24
        Me.ChangeButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ChangeButton.Name = "ChangeButton"
        Me.ChangeButton.Size = New System.Drawing.Size(28, 28)
        Me.ChangeButton.Text = "ToolStripButton1"
        Me.ChangeButton.ToolTipText = "Change colors"
        '
        'ClearButton
        '
        Me.ClearButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ClearButton.Image = Global.mSXdevtools.V9938PaletteEditor.My.Resources.Resources.clear_24
        Me.ClearButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ClearButton.Name = "ClearButton"
        Me.ClearButton.Size = New System.Drawing.Size(28, 28)
        Me.ClearButton.Text = "ToolStripButton1"
        Me.ClearButton.ToolTipText = "Initialize palette."
        '
        'UndoButton
        '
        Me.UndoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.UndoButton.Image = Global.mSXdevtools.V9938PaletteEditor.My.Resources.Resources.undo_24
        Me.UndoButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.UndoButton.Name = "UndoButton"
        Me.UndoButton.Size = New System.Drawing.Size(28, 28)
        Me.UndoButton.Text = "ToolStripButton1"
        Me.UndoButton.ToolTipText = "Undo/Redo"
        '
        'RBGTextBox
        '
        Me.RBGTextBox.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBGTextBox.Location = New System.Drawing.Point(99, 198)
        Me.RBGTextBox.MaxLength = 4
        Me.RBGTextBox.Name = "RBGTextBox"
        Me.RBGTextBox.Size = New System.Drawing.Size(44, 21)
        Me.RBGTextBox.TabIndex = 259
        Me.RBGTextBox.Text = "0"
        Me.RBGTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.RBGTextBox, "RB0G color value")
        '
        'NumColorLabel
        '
        Me.NumColorLabel.BackColor = System.Drawing.Color.Silver
        Me.NumColorLabel.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumColorLabel.Location = New System.Drawing.Point(150, 243)
        Me.NumColorLabel.Name = "NumColorLabel"
        Me.NumColorLabel.Size = New System.Drawing.Size(64, 34)
        Me.NumColorLabel.TabIndex = 258
        Me.NumColorLabel.Text = "0"
        Me.NumColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RGB24TextBox
        '
        Me.RGB24TextBox.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RGB24TextBox.Location = New System.Drawing.Point(15, 198)
        Me.RGB24TextBox.MaxLength = 1
        Me.RGB24TextBox.Name = "RGB24TextBox"
        Me.RGB24TextBox.ReadOnly = True
        Me.RGB24TextBox.Size = New System.Drawing.Size(60, 21)
        Me.RGB24TextBox.TabIndex = 257
        Me.RGB24TextBox.Text = "0"
        Me.RGB24TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.RGB24TextBox, "RGB color value")
        '
        'ColorPickerComboBox
        '
        Me.ColorPickerComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ColorPickerComboBox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ColorPickerComboBox.FormattingEnabled = True
        Me.ColorPickerComboBox.Items.AddRange(New Object() {"Red > Blue", "Red > Green", "Green > Blue"})
        Me.ColorPickerComboBox.Location = New System.Drawing.Point(15, 45)
        Me.ColorPickerComboBox.Name = "ColorPickerComboBox"
        Me.ColorPickerComboBox.Size = New System.Drawing.Size(128, 21)
        Me.ColorPickerComboBox.TabIndex = 256
        Me.ColorPickerComboBox.TabStop = False
        '
        'RedTrackBar
        '
        Me.RedTrackBar.LargeChange = 1
        Me.RedTrackBar.Location = New System.Drawing.Point(215, 64)
        Me.RedTrackBar.Maximum = 7
        Me.RedTrackBar.Name = "RedTrackBar"
        Me.RedTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.RedTrackBar.Size = New System.Drawing.Size(45, 133)
        Me.RedTrackBar.TabIndex = 1
        '
        'UpdateButton
        '
        Me.UpdateButton.BackColor = System.Drawing.Color.Gainsboro
        Me.UpdateButton.FlatAppearance.BorderSize = 0
        Me.UpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.UpdateButton.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UpdateButton.Image = Global.mSXdevtools.V9938PaletteEditor.My.Resources.Resources.tick_24
        Me.UpdateButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UpdateButton.Location = New System.Drawing.Point(279, 243)
        Me.UpdateButton.Name = "UpdateButton"
        Me.UpdateButton.Size = New System.Drawing.Size(79, 34)
        Me.UpdateButton.TabIndex = 8
        Me.UpdateButton.Text = "Set "
        Me.UpdateButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.UpdateButton, "Set New Color")
        Me.UpdateButton.UseVisualStyleBackColor = False
        '
        'GreenTrackBar
        '
        Me.GreenTrackBar.LargeChange = 1
        Me.GreenTrackBar.Location = New System.Drawing.Point(266, 64)
        Me.GreenTrackBar.Maximum = 7
        Me.GreenTrackBar.Name = "GreenTrackBar"
        Me.GreenTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.GreenTrackBar.Size = New System.Drawing.Size(45, 133)
        Me.GreenTrackBar.TabIndex = 2
        '
        'BlueTrackBar
        '
        Me.BlueTrackBar.LargeChange = 1
        Me.BlueTrackBar.Location = New System.Drawing.Point(313, 64)
        Me.BlueTrackBar.Maximum = 7
        Me.BlueTrackBar.Name = "BlueTrackBar"
        Me.BlueTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.BlueTrackBar.Size = New System.Drawing.Size(45, 133)
        Me.BlueTrackBar.TabIndex = 3
        '
        'RedTextBox
        '
        Me.RedTextBox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RedTextBox.Location = New System.Drawing.Point(216, 198)
        Me.RedTextBox.MaxLength = 1
        Me.RedTextBox.Name = "RedTextBox"
        Me.RedTextBox.Size = New System.Drawing.Size(24, 21)
        Me.RedTextBox.TabIndex = 5
        Me.RedTextBox.Text = "0"
        Me.RedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'RestoreOldColorPictureBox
        '
        Me.RestoreOldColorPictureBox.BackColor = System.Drawing.Color.Black
        Me.RestoreOldColorPictureBox.Location = New System.Drawing.Point(214, 243)
        Me.RestoreOldColorPictureBox.Name = "RestoreOldColorPictureBox"
        Me.RestoreOldColorPictureBox.Size = New System.Drawing.Size(64, 34)
        Me.RestoreOldColorPictureBox.TabIndex = 15
        Me.RestoreOldColorPictureBox.TabStop = False
        Me.ToolTip1.SetToolTip(Me.RestoreOldColorPictureBox, "Restore Old Color")
        '
        'GreenTextBox
        '
        Me.GreenTextBox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GreenTextBox.Location = New System.Drawing.Point(267, 198)
        Me.GreenTextBox.MaxLength = 1
        Me.GreenTextBox.Name = "GreenTextBox"
        Me.GreenTextBox.Size = New System.Drawing.Size(24, 21)
        Me.GreenTextBox.TabIndex = 6
        Me.GreenTextBox.Text = "0"
        Me.GreenTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ColorPickerPictureBox
        '
        Me.ColorPickerPictureBox.BackColor = System.Drawing.Color.Black
        Me.ColorPickerPictureBox.Location = New System.Drawing.Point(15, 67)
        Me.ColorPickerPictureBox.Name = "ColorPickerPictureBox"
        Me.ColorPickerPictureBox.Size = New System.Drawing.Size(128, 128)
        Me.ColorPickerPictureBox.TabIndex = 14
        Me.ColorPickerPictureBox.TabStop = False
        '
        'BlueTextBox
        '
        Me.BlueTextBox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlueTextBox.Location = New System.Drawing.Point(314, 198)
        Me.BlueTextBox.MaxLength = 1
        Me.BlueTextBox.Name = "BlueTextBox"
        Me.BlueTextBox.Size = New System.Drawing.Size(24, 21)
        Me.BlueTextBox.TabIndex = 7
        Me.BlueTextBox.Text = "0"
        Me.BlueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ToneTextBox
        '
        Me.ToneTextBox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToneTextBox.Location = New System.Drawing.Point(165, 198)
        Me.ToneTextBox.MaxLength = 1
        Me.ToneTextBox.Name = "ToneTextBox"
        Me.ToneTextBox.ReadOnly = True
        Me.ToneTextBox.Size = New System.Drawing.Size(24, 21)
        Me.ToneTextBox.TabIndex = 4
        Me.ToneTextBox.Text = "0"
        Me.ToneTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(308, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Blue"
        '
        'ToneTrackBar
        '
        Me.ToneTrackBar.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.ToneTrackBar.LargeChange = 1
        Me.ToneTrackBar.Location = New System.Drawing.Point(164, 64)
        Me.ToneTrackBar.Maximum = 7
        Me.ToneTrackBar.Name = "ToneTrackBar"
        Me.ToneTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.ToneTrackBar.Size = New System.Drawing.Size(45, 133)
        Me.ToneTrackBar.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(256, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Green"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(157, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Tone"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(211, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Red"
        '
        'ToolTip1
        '
        Me.ToolTip1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ToolTip1.ForeColor = System.Drawing.Color.Black
        Me.ToolTip1.IsBalloon = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'paletteEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.EditPalettePanel)
        Me.Controls.Add(Me.PalettePanel)
        Me.Controls.Add(Me.PaletteToolStrip)
        Me.Name = "paletteEditor"
        Me.Size = New System.Drawing.Size(490, 330)
        Me.PaletteToolStrip.ResumeLayout(False)
        Me.PaletteToolStrip.PerformLayout()
        Me.PalettePanel.ResumeLayout(False)
        CType(Me.ColorArrowPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EditPalettePanel.ResumeLayout(False)
        Me.EditPalettePanel.PerformLayout()
        Me.ToolboxStrip.ResumeLayout(False)
        Me.ToolboxStrip.PerformLayout()
        CType(Me.RedTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GreenTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BlueTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RestoreOldColorPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ColorPickerPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToneTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PaletteToolStrip As ToolStrip
    Friend WithEvents NewPaletteButton As ToolStripButton
    Friend WithEvents LoadPaletteButton As ToolStripButton
    Friend WithEvents DuplicatePaletteButton As ToolStripButton
    Friend WithEvents PaletteComboBox As ToolStripComboBox
    Friend WithEvents ConfigPaletteButton As ToolStripButton
    Friend WithEvents DeletePaletteButton As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents PalettePanel As Panel
    Friend WithEvents ColorArrowPictureBox As PictureBox
    Friend WithEvents EditPalettePanel As Panel
    Friend WithEvents RBGTextBox As TextBox
    Friend WithEvents NumColorLabel As Label
    Friend WithEvents RGB24TextBox As TextBox
    Friend WithEvents ColorPickerComboBox As ComboBox
    Friend WithEvents RedTrackBar As TrackBar
    Friend WithEvents UpdateButton As Button
    Friend WithEvents GreenTrackBar As TrackBar
    Friend WithEvents BlueTrackBar As TrackBar
    Friend WithEvents RedTextBox As TextBox
    Friend WithEvents RestoreOldColorPictureBox As PictureBox
    Friend WithEvents GreenTextBox As TextBox
    Friend WithEvents ColorPickerPictureBox As PictureBox
    Friend WithEvents BlueTextBox As TextBox
    Friend WithEvents ToneTextBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ToneTrackBar As TrackBar
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents ToolboxStrip As ToolStrip
    Friend WithEvents CopyButton As ToolStripButton
    Friend WithEvents ChangeButton As ToolStripButton
    Friend WithEvents ClearButton As ToolStripButton
    Friend WithEvents UndoButton As ToolStripButton
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents SaveButton As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents GetDataButton As ToolStripButton
    Friend WithEvents HelpButton As ToolStripButton
End Class
