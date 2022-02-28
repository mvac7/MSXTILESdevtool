<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class palette512Dialog
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
        Me.components = New System.ComponentModel.Container
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.OK_Button = New System.Windows.Forms.Button
        Me.RedTrackBar = New System.Windows.Forms.TrackBar
        Me.GreenTrackBar = New System.Windows.Forms.TrackBar
        Me.BlueTrackBar = New System.Windows.Forms.TrackBar
        Me.RedTextBox = New System.Windows.Forms.TextBox
        Me.GreenTextBox = New System.Windows.Forms.TextBox
        Me.BlueTextBox = New System.Windows.Forms.TextBox
        Me.ToneTrackBar = New System.Windows.Forms.TrackBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.ToneTextBox = New System.Windows.Forms.TextBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.RestoreButton = New System.Windows.Forms.Button
        Me.OldColorPictureBox = New System.Windows.Forms.PictureBox
        Me.ColorPictureBox = New System.Windows.Forms.PictureBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.PalettePanel = New System.Windows.Forms.Panel
        Me.ColorArrowPictureBox = New System.Windows.Forms.PictureBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.UpdateButton = New System.Windows.Forms.Button
        Me.PalettePictureBox = New System.Windows.Forms.PictureBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.DefaultPaletteButton = New System.Windows.Forms.ToolStripButton
        Me.LoadPaletteButton = New System.Windows.Forms.ToolStripButton
        Me.SavePaletteButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.PaletteNameTextBox = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.copyBut = New System.Windows.Forms.ToolStripButton
        Me.changeBut = New System.Windows.Forms.ToolStripButton
        Me.undoBut = New System.Windows.Forms.ToolStripButton
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.RedTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GreenTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BlueTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToneTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OldColorPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ColorPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PalettePanel.SuspendLayout()
        CType(Me.ColorArrowPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PalettePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.71429!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.28571!))
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(234, 6)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(175, 42)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.BackColor = System.Drawing.Color.Salmon
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_Button.Location = New System.Drawing.Point(99, 7)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(70, 28)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        Me.Cancel_Button.UseVisualStyleBackColor = False
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.BackColor = System.Drawing.Color.PaleGreen
        Me.OK_Button.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK_Button.Location = New System.Drawing.Point(7, 5)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(80, 32)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Acept"
        Me.OK_Button.UseVisualStyleBackColor = False
        '
        'RedTrackBar
        '
        Me.RedTrackBar.LargeChange = 1
        Me.RedTrackBar.Location = New System.Drawing.Point(217, 31)
        Me.RedTrackBar.Maximum = 7
        Me.RedTrackBar.Name = "RedTrackBar"
        Me.RedTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.RedTrackBar.Size = New System.Drawing.Size(45, 152)
        Me.RedTrackBar.TabIndex = 1
        '
        'GreenTrackBar
        '
        Me.GreenTrackBar.LargeChange = 1
        Me.GreenTrackBar.Location = New System.Drawing.Point(268, 31)
        Me.GreenTrackBar.Maximum = 7
        Me.GreenTrackBar.Name = "GreenTrackBar"
        Me.GreenTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.GreenTrackBar.Size = New System.Drawing.Size(45, 152)
        Me.GreenTrackBar.TabIndex = 2
        '
        'BlueTrackBar
        '
        Me.BlueTrackBar.LargeChange = 1
        Me.BlueTrackBar.Location = New System.Drawing.Point(315, 31)
        Me.BlueTrackBar.Maximum = 7
        Me.BlueTrackBar.Name = "BlueTrackBar"
        Me.BlueTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.BlueTrackBar.Size = New System.Drawing.Size(45, 152)
        Me.BlueTrackBar.TabIndex = 3
        '
        'RedTextBox
        '
        Me.RedTextBox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RedTextBox.Location = New System.Drawing.Point(218, 184)
        Me.RedTextBox.MaxLength = 1
        Me.RedTextBox.Name = "RedTextBox"
        Me.RedTextBox.ReadOnly = True
        Me.RedTextBox.Size = New System.Drawing.Size(24, 21)
        Me.RedTextBox.TabIndex = 4
        Me.RedTextBox.Text = "0"
        Me.RedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GreenTextBox
        '
        Me.GreenTextBox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GreenTextBox.Location = New System.Drawing.Point(269, 184)
        Me.GreenTextBox.MaxLength = 1
        Me.GreenTextBox.Name = "GreenTextBox"
        Me.GreenTextBox.ReadOnly = True
        Me.GreenTextBox.Size = New System.Drawing.Size(24, 21)
        Me.GreenTextBox.TabIndex = 5
        Me.GreenTextBox.Text = "0"
        Me.GreenTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BlueTextBox
        '
        Me.BlueTextBox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlueTextBox.Location = New System.Drawing.Point(316, 184)
        Me.BlueTextBox.MaxLength = 1
        Me.BlueTextBox.Name = "BlueTextBox"
        Me.BlueTextBox.ReadOnly = True
        Me.BlueTextBox.Size = New System.Drawing.Size(24, 21)
        Me.BlueTextBox.TabIndex = 6
        Me.BlueTextBox.Text = "0"
        Me.BlueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ToneTrackBar
        '
        Me.ToneTrackBar.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.ToneTrackBar.LargeChange = 1
        Me.ToneTrackBar.Location = New System.Drawing.Point(166, 31)
        Me.ToneTrackBar.Maximum = 7
        Me.ToneTrackBar.Name = "ToneTrackBar"
        Me.ToneTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.ToneTrackBar.Size = New System.Drawing.Size(45, 152)
        Me.ToneTrackBar.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(159, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Tone"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(213, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Red"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(258, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Green"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(310, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Blue"
        '
        'ToneTextBox
        '
        Me.ToneTextBox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToneTextBox.Location = New System.Drawing.Point(167, 184)
        Me.ToneTextBox.MaxLength = 1
        Me.ToneTextBox.Name = "ToneTextBox"
        Me.ToneTextBox.ReadOnly = True
        Me.ToneTextBox.Size = New System.Drawing.Size(24, 21)
        Me.ToneTextBox.TabIndex = 13
        Me.ToneTextBox.Text = "0"
        Me.ToneTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 5000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 600
        '
        'RestoreButton
        '
        Me.RestoreButton.BackColor = System.Drawing.Color.Gainsboro
        Me.RestoreButton.Font = New System.Drawing.Font("Webdings", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.RestoreButton.Location = New System.Drawing.Point(239, 215)
        Me.RestoreButton.Name = "RestoreButton"
        Me.RestoreButton.Size = New System.Drawing.Size(28, 28)
        Me.RestoreButton.TabIndex = 22
        Me.RestoreButton.Text = "4"
        Me.ToolTip1.SetToolTip(Me.RestoreButton, "Restore Color")
        Me.RestoreButton.UseVisualStyleBackColor = False
        '
        'OldColorPictureBox
        '
        Me.OldColorPictureBox.BackColor = System.Drawing.Color.Black
        Me.OldColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.OldColorPictureBox.Location = New System.Drawing.Point(165, 215)
        Me.OldColorPictureBox.Name = "OldColorPictureBox"
        Me.OldColorPictureBox.Size = New System.Drawing.Size(70, 28)
        Me.OldColorPictureBox.TabIndex = 15
        Me.OldColorPictureBox.TabStop = False
        Me.ToolTip1.SetToolTip(Me.OldColorPictureBox, "Previous color")
        '
        'ColorPictureBox
        '
        Me.ColorPictureBox.BackColor = System.Drawing.Color.Black
        Me.ColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ColorPictureBox.Location = New System.Drawing.Point(270, 215)
        Me.ColorPictureBox.Name = "ColorPictureBox"
        Me.ColorPictureBox.Size = New System.Drawing.Size(70, 28)
        Me.ColorPictureBox.TabIndex = 7
        Me.ColorPictureBox.TabStop = False
        Me.ToolTip1.SetToolTip(Me.ColorPictureBox, "New color")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Palette Map"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Palette"
        '
        'PalettePanel
        '
        Me.PalettePanel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PalettePanel.Controls.Add(Me.ColorArrowPictureBox)
        Me.PalettePanel.Controls.Add(Me.Label6)
        Me.PalettePanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.PalettePanel.Location = New System.Drawing.Point(0, 31)
        Me.PalettePanel.Name = "PalettePanel"
        Me.PalettePanel.Size = New System.Drawing.Size(64, 307)
        Me.PalettePanel.TabIndex = 19
        '
        'ColorArrowPictureBox
        '
        Me.ColorArrowPictureBox.Image = Global.mSXdevtools.MSXLibrary.My.Resources.Resources.flecha8x16
        Me.ColorArrowPictureBox.Location = New System.Drawing.Point(56, 33)
        Me.ColorArrowPictureBox.Name = "ColorArrowPictureBox"
        Me.ColorArrowPictureBox.Size = New System.Drawing.Size(8, 16)
        Me.ColorArrowPictureBox.TabIndex = 20
        Me.ColorArrowPictureBox.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 338)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(422, 51)
        Me.Panel1.TabIndex = 20
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.RestoreButton)
        Me.Panel2.Controls.Add(Me.RedTrackBar)
        Me.Panel2.Controls.Add(Me.UpdateButton)
        Me.Panel2.Controls.Add(Me.GreenTrackBar)
        Me.Panel2.Controls.Add(Me.BlueTrackBar)
        Me.Panel2.Controls.Add(Me.RedTextBox)
        Me.Panel2.Controls.Add(Me.OldColorPictureBox)
        Me.Panel2.Controls.Add(Me.GreenTextBox)
        Me.Panel2.Controls.Add(Me.PalettePictureBox)
        Me.Panel2.Controls.Add(Me.BlueTextBox)
        Me.Panel2.Controls.Add(Me.ToneTextBox)
        Me.Panel2.Controls.Add(Me.ColorPictureBox)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.ToneTrackBar)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(64, 31)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(358, 307)
        Me.Panel2.TabIndex = 23
        '
        'UpdateButton
        '
        Me.UpdateButton.BackColor = System.Drawing.Color.Gainsboro
        Me.UpdateButton.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UpdateButton.Image = Global.mSXdevtools.MSXLibrary.My.Resources.Resources.tick_24
        Me.UpdateButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UpdateButton.Location = New System.Drawing.Point(270, 262)
        Me.UpdateButton.Name = "UpdateButton"
        Me.UpdateButton.Size = New System.Drawing.Size(70, 28)
        Me.UpdateButton.TabIndex = 21
        Me.UpdateButton.Text = "Set "
        Me.UpdateButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.UpdateButton.UseVisualStyleBackColor = False
        '
        'PalettePictureBox
        '
        Me.PalettePictureBox.BackColor = System.Drawing.Color.Black
        Me.PalettePictureBox.Location = New System.Drawing.Point(16, 31)
        Me.PalettePictureBox.Name = "PalettePictureBox"
        Me.PalettePictureBox.Size = New System.Drawing.Size(128, 256)
        Me.PalettePictureBox.TabIndex = 14
        Me.PalettePictureBox.TabStop = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DefaultPaletteButton, Me.LoadPaletteButton, Me.SavePaletteButton, Me.ToolStripSeparator1, Me.PaletteNameTextBox, Me.ToolStripSeparator2, Me.copyBut, Me.changeBut, Me.undoBut})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(422, 31)
        Me.ToolStrip1.TabIndex = 24
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'DefaultPaletteButton
        '
        Me.DefaultPaletteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.DefaultPaletteButton.Image = Global.mSXdevtools.MSXLibrary.My.Resources.Resources._new
        Me.DefaultPaletteButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DefaultPaletteButton.Name = "DefaultPaletteButton"
        Me.DefaultPaletteButton.Size = New System.Drawing.Size(28, 28)
        Me.DefaultPaletteButton.ToolTipText = "Default Palette"
        '
        'LoadPaletteButton
        '
        Me.LoadPaletteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.LoadPaletteButton.Image = Global.mSXdevtools.MSXLibrary.My.Resources.Resources.load_24x24
        Me.LoadPaletteButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LoadPaletteButton.Name = "LoadPaletteButton"
        Me.LoadPaletteButton.Size = New System.Drawing.Size(28, 28)
        Me.LoadPaletteButton.Text = "LoadButton"
        Me.LoadPaletteButton.ToolTipText = "Load Palette"
        '
        'SavePaletteButton
        '
        Me.SavePaletteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SavePaletteButton.Image = Global.mSXdevtools.MSXLibrary.My.Resources.Resources.save
        Me.SavePaletteButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SavePaletteButton.Name = "SavePaletteButton"
        Me.SavePaletteButton.Size = New System.Drawing.Size(28, 28)
        Me.SavePaletteButton.Text = "SaveButton"
        Me.SavePaletteButton.ToolTipText = "Save Palette"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'PaletteNameTextBox
        '
        Me.PaletteNameTextBox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaletteNameTextBox.Name = "PaletteNameTextBox"
        Me.PaletteNameTextBox.Size = New System.Drawing.Size(120, 31)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'copyBut
        '
        Me.copyBut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.copyBut.Image = Global.mSXdevtools.MSXLibrary.My.Resources.Resources.copy_24
        Me.copyBut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.copyBut.Name = "copyBut"
        Me.copyBut.Size = New System.Drawing.Size(28, 28)
        Me.copyBut.Text = "ToolStripButton1"
        Me.copyBut.ToolTipText = "Copy color"
        '
        'changeBut
        '
        Me.changeBut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.changeBut.Image = Global.mSXdevtools.MSXLibrary.My.Resources.Resources.exchange_24
        Me.changeBut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.changeBut.Name = "changeBut"
        Me.changeBut.Size = New System.Drawing.Size(28, 28)
        Me.changeBut.Text = "ToolStripButton1"
        Me.changeBut.ToolTipText = "Change colors"
        '
        'undoBut
        '
        Me.undoBut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.undoBut.Enabled = False
        Me.undoBut.Image = Global.mSXdevtools.MSXLibrary.My.Resources.Resources.undo_24
        Me.undoBut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.undoBut.Name = "undoBut"
        Me.undoBut.Size = New System.Drawing.Size(28, 28)
        Me.undoBut.Text = "ToolStripButton1"
        Me.undoBut.ToolTipText = "Undo"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'palette512Dialog
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(422, 389)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.PalettePanel)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "palette512Dialog"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "V9938 Color Palette Editor"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.RedTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GreenTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BlueTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToneTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OldColorPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ColorPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PalettePanel.ResumeLayout(False)
        Me.PalettePanel.PerformLayout()
        CType(Me.ColorArrowPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PalettePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents RedTrackBar As System.Windows.Forms.TrackBar
    Friend WithEvents GreenTrackBar As System.Windows.Forms.TrackBar
    Friend WithEvents BlueTrackBar As System.Windows.Forms.TrackBar
    Friend WithEvents RedTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GreenTextBox As System.Windows.Forms.TextBox
    Friend WithEvents BlueTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ColorPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents ToneTrackBar As System.Windows.Forms.TrackBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ToneTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PalettePictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents OldColorPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PalettePanel As System.Windows.Forms.Panel
    Friend WithEvents ColorArrowPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents UpdateButton As System.Windows.Forms.Button
    Friend WithEvents RestoreButton As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents DefaultPaletteButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents LoadPaletteButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SavePaletteButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PaletteNameTextBox As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents copyBut As System.Windows.Forms.ToolStripButton
    Friend WithEvents changeBut As System.Windows.Forms.ToolStripButton
    Friend WithEvents undoBut As System.Windows.Forms.ToolStripButton

End Class
