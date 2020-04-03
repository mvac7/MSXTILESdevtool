<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainScreen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainScreen))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.LoadScrText = New System.Windows.Forms.TextBox
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.LoadTilText = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.InvertButton = New System.Windows.Forms.Button
        Me.TilesClearBut = New System.Windows.Forms.Button
        Me.BlackitizerBut = New System.Windows.Forms.Button
        Me.TilesOrderBut = New System.Windows.Forms.Button
        Me.ChangeButton = New System.Windows.Forms.Button
        Me.OptimizeButton = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.SaveTilesetsButton = New System.Windows.Forms.Button
        Me.LoadTilesetButton = New System.Windows.Forms.Button
        Me.AllBanksPanel = New System.Windows.Forms.Panel
        Me.CompressCol_ALL_CBox = New System.Windows.Forms.ComboBox
        Me.CompressPat_ALL_CBox = New System.Windows.Forms.ComboBox
        Me.ALLcolor = New System.Windows.Forms.CheckBox
        Me.ALLpattern = New System.Windows.Forms.CheckBox
        Me.BasicConfigButton = New System.Windows.Forms.Button
        Me.BanksTabcontrol = New System.Windows.Forms.TabControl
        Me.TabB0 = New System.Windows.Forms.TabPage
        Me.Compression_CB0_CBox = New System.Windows.Forms.ComboBox
        Me.Compression_PB0_CBox = New System.Windows.Forms.ComboBox
        Me.B0color = New System.Windows.Forms.CheckBox
        Me.B0pattern = New System.Windows.Forms.CheckBox
        Me.B0IniTile = New System.Windows.Forms.TextBox
        Me.B0EndTile = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.B0Check = New System.Windows.Forms.CheckBox
        Me.TabB1 = New System.Windows.Forms.TabPage
        Me.Compression_CB1_CBox = New System.Windows.Forms.ComboBox
        Me.Compression_PB1_CBox = New System.Windows.Forms.ComboBox
        Me.B1color = New System.Windows.Forms.CheckBox
        Me.B1Pattern = New System.Windows.Forms.CheckBox
        Me.B1IniTile = New System.Windows.Forms.TextBox
        Me.B1EndTile = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Bank1CheckB = New System.Windows.Forms.CheckBox
        Me.TabB2 = New System.Windows.Forms.TabPage
        Me.Compression_CB2_CBox = New System.Windows.Forms.ComboBox
        Me.Compression_PB2_CBox = New System.Windows.Forms.ComboBox
        Me.B2color = New System.Windows.Forms.CheckBox
        Me.B2Pattern = New System.Windows.Forms.CheckBox
        Me.B2IniTile = New System.Windows.Forms.TextBox
        Me.B2EndTile = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Bank2CheckB = New System.Windows.Forms.CheckBox
        Me.AllBanksCheckBox = New System.Windows.Forms.CheckBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Tileset_NumSysComboBox = New System.Windows.Forms.ComboBox
        Me.Tileset_SizeLineComboB = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Tileset_CodeOutComboB = New System.Windows.Forms.ComboBox
        Me.TilesetGenButton = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Tileset_FieldName = New System.Windows.Forms.TextBox
        Me.Tileset_TxtOutput = New System.Windows.Forms.TextBox
        Me.SaveTilesCBut = New System.Windows.Forms.Button
        Me.LoadTilesBut = New System.Windows.Forms.Button
        Me.SaveTilesBinBut = New System.Windows.Forms.Button
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.SaveMapButton = New System.Windows.Forms.Button
        Me.LoadMapButton = New System.Windows.Forms.Button
        Me.BasicConfigButton2 = New System.Windows.Forms.Button
        Me.Label26 = New System.Windows.Forms.Label
        Me.Map_NumSysComboBox = New System.Windows.Forms.ComboBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Map_compressionScrCB = New System.Windows.Forms.ComboBox
        Me.Map_SizeLineComboB = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.endTileY = New System.Windows.Forms.TextBox
        Me.endTileX = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.startTileY = New System.Windows.Forms.TextBox
        Me.startTileX = New System.Windows.Forms.TextBox
        Me.Map_CodeOutComboB = New System.Windows.Forms.ComboBox
        Me.GetScrButton = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Map_FieldName = New System.Windows.Forms.TextBox
        Me.Tiles_TxtOutput = New System.Windows.Forms.TextBox
        Me.Map_areaResetButton = New System.Windows.Forms.Button
        Me.SaveTxtScrBut = New System.Windows.Forms.Button
        Me.SaveBinBut = New System.Windows.Forms.Button
        Me.LoadScrBut = New System.Windows.Forms.Button
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.BasicConfigButton3 = New System.Windows.Forms.Button
        Me.Label25 = New System.Windows.Forms.Label
        Me.Palette_NumSysCombo = New System.Windows.Forms.ComboBox
        Me.Palette_SizeLineComboB = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Palette_CodeOutComboB = New System.Windows.Forms.ComboBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Palette_FieldName = New System.Windows.Forms.TextBox
        Me.Palette_TxtOutput = New System.Windows.Forms.TextBox
        Me.GetPaletteButton = New System.Windows.Forms.Button
        Me.PaleteNameTextB = New System.Windows.Forms.TextBox
        Me.EditPaleteButton = New System.Windows.Forms.Button
        Me.SavePaletteButton = New System.Windows.Forms.Button
        Me.SaveTxtPalBut = New System.Windows.Forms.Button
        Me.LoadPaletteButton = New System.Windows.Forms.Button
        Me.PosxTextB = New System.Windows.Forms.TextBox
        Me.TileTextB = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.vaddrTextB = New System.Windows.Forms.TextBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ProjectDataButton = New System.Windows.Forms.Button
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.SaveSCProjectButton = New System.Windows.Forms.Button
        Me.LoadSCProjectButton = New System.Windows.Forms.Button
        Me.SavePrjButton = New System.Windows.Forms.Button
        Me.SaveSC4But = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.LoadPNGBut = New System.Windows.Forms.Button
        Me.SavePNGBut = New System.Windows.Forms.Button
        Me.LoadNMSXTILESprojectBut = New System.Windows.Forms.Button
        Me.SaveSC2But = New System.Windows.Forms.Button
        Me.LoadSC2But = New System.Windows.Forms.Button
        Me.TabImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.Label14 = New System.Windows.Forms.Label
        Me.PosyTextB = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ProjectNameTextBox = New System.Windows.Forms.TextBox
        Me.TabTilesetLabel = New System.Windows.Forms.Label
        Me.TabScrLabel = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.screen2 = New mSXdevtools.MSXLibrary.TMS9918
        Me.GroupBox4.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.AllBanksPanel.SuspendLayout()
        Me.BanksTabcontrol.SuspendLayout()
        Me.TabB0.SuspendLayout()
        Me.TabB1.SuspendLayout()
        Me.TabB2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LoadScrText
        '
        Me.LoadScrText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LoadScrText.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoadScrText.Location = New System.Drawing.Point(95, 11)
        Me.LoadScrText.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.LoadScrText.Name = "LoadScrText"
        Me.LoadScrText.ReadOnly = True
        Me.LoadScrText.Size = New System.Drawing.Size(240, 22)
        Me.LoadScrText.TabIndex = 1
        '
        'LoadTilText
        '
        Me.LoadTilText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LoadTilText.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoadTilText.Location = New System.Drawing.Point(95, 11)
        Me.LoadTilText.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.LoadTilText.Name = "LoadTilText"
        Me.LoadTilText.ReadOnly = True
        Me.LoadTilText.Size = New System.Drawing.Size(240, 22)
        Me.LoadTilText.TabIndex = 4
        '
        'GroupBox4
        '
        Me.GroupBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GroupBox4.Controls.Add(Me.InvertButton)
        Me.GroupBox4.Controls.Add(Me.TilesClearBut)
        Me.GroupBox4.Controls.Add(Me.BlackitizerBut)
        Me.GroupBox4.Controls.Add(Me.TilesOrderBut)
        Me.GroupBox4.Controls.Add(Me.ChangeButton)
        Me.GroupBox4.Controls.Add(Me.OptimizeButton)
        Me.GroupBox4.Location = New System.Drawing.Point(188, 110)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox4.Size = New System.Drawing.Size(251, 112)
        Me.GroupBox4.TabIndex = 11
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Tools"
        '
        'InvertButton
        '
        Me.InvertButton.BackColor = System.Drawing.Color.Gainsboro
        Me.InvertButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.invert_x24_02
        Me.InvertButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.InvertButton.Location = New System.Drawing.Point(128, 77)
        Me.InvertButton.Name = "InvertButton"
        Me.InvertButton.Size = New System.Drawing.Size(110, 28)
        Me.InvertButton.TabIndex = 16
        Me.InvertButton.Text = "Invert!"
        Me.InvertButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.InvertButton, "Invert patter data " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "and/or color.")
        Me.InvertButton.UseVisualStyleBackColor = False
        '
        'TilesClearBut
        '
        Me.TilesClearBut.BackColor = System.Drawing.Color.Gainsboro
        Me.TilesClearBut.Image = Global.MSXTILESdevtool.My.Resources.Resources.fill_x24_02
        Me.TilesClearBut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.TilesClearBut.Location = New System.Drawing.Point(11, 47)
        Me.TilesClearBut.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TilesClearBut.Name = "TilesClearBut"
        Me.TilesClearBut.Size = New System.Drawing.Size(110, 28)
        Me.TilesClearBut.TabIndex = 10
        Me.TilesClearBut.Text = "Fill Map"
        Me.TilesClearBut.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.TilesClearBut, "Fill the map with a tile.")
        Me.TilesClearBut.UseVisualStyleBackColor = False
        '
        'BlackitizerBut
        '
        Me.BlackitizerBut.BackColor = System.Drawing.Color.Gainsboro
        Me.BlackitizerBut.Image = Global.MSXTILESdevtool.My.Resources.Resources.change_x24_02
        Me.BlackitizerBut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BlackitizerBut.Location = New System.Drawing.Point(128, 17)
        Me.BlackitizerBut.Name = "BlackitizerBut"
        Me.BlackitizerBut.Size = New System.Drawing.Size(110, 28)
        Me.BlackitizerBut.TabIndex = 14
        Me.BlackitizerBut.Text = "Color"
        Me.BlackitizerBut.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.BlackitizerBut, "Change color.")
        Me.BlackitizerBut.UseVisualStyleBackColor = False
        '
        'TilesOrderBut
        '
        Me.TilesOrderBut.BackColor = System.Drawing.Color.Gainsboro
        Me.TilesOrderBut.Image = Global.MSXTILESdevtool.My.Resources.Resources.gradient_up_24
        Me.TilesOrderBut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.TilesOrderBut.Location = New System.Drawing.Point(11, 17)
        Me.TilesOrderBut.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TilesOrderBut.Name = "TilesOrderBut"
        Me.TilesOrderBut.Size = New System.Drawing.Size(110, 28)
        Me.TilesOrderBut.TabIndex = 12
        Me.TilesOrderBut.Text = "Fill Order"
        Me.TilesOrderBut.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.TilesOrderBut, "Fill in order the Map.")
        Me.TilesOrderBut.UseVisualStyleBackColor = False
        '
        'ChangeButton
        '
        Me.ChangeButton.BackColor = System.Drawing.Color.Gainsboro
        Me.ChangeButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.copy_24
        Me.ChangeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ChangeButton.Location = New System.Drawing.Point(128, 47)
        Me.ChangeButton.Name = "ChangeButton"
        Me.ChangeButton.Size = New System.Drawing.Size(110, 28)
        Me.ChangeButton.TabIndex = 0
        Me.ChangeButton.Text = "Tile"
        Me.ChangeButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.ChangeButton, "Change Tile")
        Me.ChangeButton.UseVisualStyleBackColor = False
        '
        'OptimizeButton
        '
        Me.OptimizeButton.BackColor = System.Drawing.Color.Gainsboro
        Me.OptimizeButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.reload_24x24_02
        Me.OptimizeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.OptimizeButton.Location = New System.Drawing.Point(11, 77)
        Me.OptimizeButton.Name = "OptimizeButton"
        Me.OptimizeButton.Size = New System.Drawing.Size(110, 28)
        Me.OptimizeButton.TabIndex = 15
        Me.OptimizeButton.Text = "Optimize!"
        Me.OptimizeButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.OptimizeButton, "Sort gfx data to optimize compression.")
        Me.OptimizeButton.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(12, 226)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(821, 323)
        Me.TabControl1.TabIndex = 9
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage3.Controls.Add(Me.SaveTilesetsButton)
        Me.TabPage3.Controls.Add(Me.LoadTilesetButton)
        Me.TabPage3.Controls.Add(Me.AllBanksPanel)
        Me.TabPage3.Controls.Add(Me.BasicConfigButton)
        Me.TabPage3.Controls.Add(Me.BanksTabcontrol)
        Me.TabPage3.Controls.Add(Me.AllBanksCheckBox)
        Me.TabPage3.Controls.Add(Me.Label20)
        Me.TabPage3.Controls.Add(Me.Tileset_NumSysComboBox)
        Me.TabPage3.Controls.Add(Me.Tileset_SizeLineComboB)
        Me.TabPage3.Controls.Add(Me.Label11)
        Me.TabPage3.Controls.Add(Me.Label7)
        Me.TabPage3.Controls.Add(Me.Tileset_CodeOutComboB)
        Me.TabPage3.Controls.Add(Me.TilesetGenButton)
        Me.TabPage3.Controls.Add(Me.Label2)
        Me.TabPage3.Controls.Add(Me.Tileset_FieldName)
        Me.TabPage3.Controls.Add(Me.Tileset_TxtOutput)
        Me.TabPage3.Controls.Add(Me.SaveTilesCBut)
        Me.TabPage3.Controls.Add(Me.LoadTilesBut)
        Me.TabPage3.Controls.Add(Me.SaveTilesBinBut)
        Me.TabPage3.Controls.Add(Me.LoadTilText)
        Me.TabPage3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage3.Location = New System.Drawing.Point(4, 23)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(813, 296)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Tileset"
        '
        'SaveTilesetsButton
        '
        Me.SaveTilesetsButton.BackColor = System.Drawing.Color.LightGreen
        Me.SaveTilesetsButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.save
        Me.SaveTilesetsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SaveTilesetsButton.Location = New System.Drawing.Point(343, 8)
        Me.SaveTilesetsButton.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SaveTilesetsButton.Name = "SaveTilesetsButton"
        Me.SaveTilesetsButton.Size = New System.Drawing.Size(86, 28)
        Me.SaveTilesetsButton.TabIndex = 229
        Me.SaveTilesetsButton.Text = "Tilesets"
        Me.SaveTilesetsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.SaveTilesetsButton, "Save Open Document Tilesets")
        Me.SaveTilesetsButton.UseVisualStyleBackColor = False
        '
        'LoadTilesetButton
        '
        Me.LoadTilesetButton.BackColor = System.Drawing.Color.LightGreen
        Me.LoadTilesetButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoadTilesetButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.folder
        Me.LoadTilesetButton.Location = New System.Drawing.Point(12, 8)
        Me.LoadTilesetButton.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.LoadTilesetButton.Name = "LoadTilesetButton"
        Me.LoadTilesetButton.Size = New System.Drawing.Size(34, 28)
        Me.LoadTilesetButton.TabIndex = 228
        Me.LoadTilesetButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.LoadTilesetButton, "Load Open Document Tilesets")
        Me.LoadTilesetButton.UseVisualStyleBackColor = False
        '
        'AllBanksPanel
        '
        Me.AllBanksPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AllBanksPanel.Controls.Add(Me.CompressCol_ALL_CBox)
        Me.AllBanksPanel.Controls.Add(Me.CompressPat_ALL_CBox)
        Me.AllBanksPanel.Controls.Add(Me.ALLcolor)
        Me.AllBanksPanel.Controls.Add(Me.ALLpattern)
        Me.AllBanksPanel.Location = New System.Drawing.Point(565, 28)
        Me.AllBanksPanel.Name = "AllBanksPanel"
        Me.AllBanksPanel.Size = New System.Drawing.Size(188, 110)
        Me.AllBanksPanel.TabIndex = 227
        '
        'CompressCol_ALL_CBox
        '
        Me.CompressCol_ALL_CBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CompressCol_ALL_CBox.FormattingEnabled = True
        Me.CompressCol_ALL_CBox.Items.AddRange(New Object() {"RAW", "RLE", "RLE WB"})
        Me.CompressCol_ALL_CBox.Location = New System.Drawing.Point(105, 32)
        Me.CompressCol_ALL_CBox.Name = "CompressCol_ALL_CBox"
        Me.CompressCol_ALL_CBox.Size = New System.Drawing.Size(70, 21)
        Me.CompressCol_ALL_CBox.TabIndex = 224
        '
        'CompressPat_ALL_CBox
        '
        Me.CompressPat_ALL_CBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CompressPat_ALL_CBox.FormattingEnabled = True
        Me.CompressPat_ALL_CBox.Items.AddRange(New Object() {"RAW", "RLE", "RLE WB"})
        Me.CompressPat_ALL_CBox.Location = New System.Drawing.Point(105, 7)
        Me.CompressPat_ALL_CBox.Name = "CompressPat_ALL_CBox"
        Me.CompressPat_ALL_CBox.Size = New System.Drawing.Size(70, 21)
        Me.CompressPat_ALL_CBox.TabIndex = 223
        '
        'ALLcolor
        '
        Me.ALLcolor.AutoSize = True
        Me.ALLcolor.Checked = True
        Me.ALLcolor.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ALLcolor.Location = New System.Drawing.Point(11, 36)
        Me.ALLcolor.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ALLcolor.Name = "ALLcolor"
        Me.ALLcolor.Size = New System.Drawing.Size(57, 17)
        Me.ALLcolor.TabIndex = 222
        Me.ALLcolor.Text = "Color"
        Me.ALLcolor.UseVisualStyleBackColor = True
        '
        'ALLpattern
        '
        Me.ALLpattern.AutoSize = True
        Me.ALLpattern.Checked = True
        Me.ALLpattern.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ALLpattern.Location = New System.Drawing.Point(11, 11)
        Me.ALLpattern.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ALLpattern.Name = "ALLpattern"
        Me.ALLpattern.Size = New System.Drawing.Size(67, 17)
        Me.ALLpattern.TabIndex = 221
        Me.ALLpattern.Text = "Pattern"
        Me.ALLpattern.UseVisualStyleBackColor = True
        '
        'BasicConfigButton
        '
        Me.BasicConfigButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BasicConfigButton.BackColor = System.Drawing.Color.Gainsboro
        Me.BasicConfigButton.Location = New System.Drawing.Point(782, 8)
        Me.BasicConfigButton.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BasicConfigButton.Name = "BasicConfigButton"
        Me.BasicConfigButton.Size = New System.Drawing.Size(23, 22)
        Me.BasicConfigButton.TabIndex = 226
        Me.BasicConfigButton.Text = "+"
        Me.ToolTip1.SetToolTip(Me.BasicConfigButton, "Basic config.")
        Me.BasicConfigButton.UseVisualStyleBackColor = False
        '
        'BanksTabcontrol
        '
        Me.BanksTabcontrol.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BanksTabcontrol.Controls.Add(Me.TabB0)
        Me.BanksTabcontrol.Controls.Add(Me.TabB1)
        Me.BanksTabcontrol.Controls.Add(Me.TabB2)
        Me.BanksTabcontrol.ItemSize = New System.Drawing.Size(40, 18)
        Me.BanksTabcontrol.Location = New System.Drawing.Point(619, 148)
        Me.BanksTabcontrol.Name = "BanksTabcontrol"
        Me.BanksTabcontrol.SelectedIndex = 0
        Me.BanksTabcontrol.Size = New System.Drawing.Size(188, 110)
        Me.BanksTabcontrol.TabIndex = 217
        Me.BanksTabcontrol.Visible = False
        '
        'TabB0
        '
        Me.TabB0.Controls.Add(Me.Compression_CB0_CBox)
        Me.TabB0.Controls.Add(Me.Compression_PB0_CBox)
        Me.TabB0.Controls.Add(Me.B0color)
        Me.TabB0.Controls.Add(Me.B0pattern)
        Me.TabB0.Controls.Add(Me.B0IniTile)
        Me.TabB0.Controls.Add(Me.B0EndTile)
        Me.TabB0.Controls.Add(Me.Label4)
        Me.TabB0.Controls.Add(Me.B0Check)
        Me.TabB0.Location = New System.Drawing.Point(4, 22)
        Me.TabB0.Name = "TabB0"
        Me.TabB0.Padding = New System.Windows.Forms.Padding(3)
        Me.TabB0.Size = New System.Drawing.Size(180, 84)
        Me.TabB0.TabIndex = 0
        Me.TabB0.Text = "Bank0"
        Me.TabB0.UseVisualStyleBackColor = True
        '
        'Compression_CB0_CBox
        '
        Me.Compression_CB0_CBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Compression_CB0_CBox.FormattingEnabled = True
        Me.Compression_CB0_CBox.Items.AddRange(New Object() {"RAW", "RLE", "RLE WB"})
        Me.Compression_CB0_CBox.Location = New System.Drawing.Point(103, 54)
        Me.Compression_CB0_CBox.Name = "Compression_CB0_CBox"
        Me.Compression_CB0_CBox.Size = New System.Drawing.Size(70, 21)
        Me.Compression_CB0_CBox.TabIndex = 220
        '
        'Compression_PB0_CBox
        '
        Me.Compression_PB0_CBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Compression_PB0_CBox.FormattingEnabled = True
        Me.Compression_PB0_CBox.Items.AddRange(New Object() {"RAW", "RLE", "RLE WB"})
        Me.Compression_PB0_CBox.Location = New System.Drawing.Point(103, 29)
        Me.Compression_PB0_CBox.Name = "Compression_PB0_CBox"
        Me.Compression_PB0_CBox.Size = New System.Drawing.Size(70, 21)
        Me.Compression_PB0_CBox.TabIndex = 219
        '
        'B0color
        '
        Me.B0color.AutoSize = True
        Me.B0color.Checked = True
        Me.B0color.CheckState = System.Windows.Forms.CheckState.Checked
        Me.B0color.Location = New System.Drawing.Point(9, 58)
        Me.B0color.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.B0color.Name = "B0color"
        Me.B0color.Size = New System.Drawing.Size(57, 17)
        Me.B0color.TabIndex = 215
        Me.B0color.Text = "Color"
        Me.B0color.UseVisualStyleBackColor = True
        '
        'B0pattern
        '
        Me.B0pattern.AutoSize = True
        Me.B0pattern.Checked = True
        Me.B0pattern.CheckState = System.Windows.Forms.CheckState.Checked
        Me.B0pattern.Location = New System.Drawing.Point(9, 33)
        Me.B0pattern.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.B0pattern.Name = "B0pattern"
        Me.B0pattern.Size = New System.Drawing.Size(67, 17)
        Me.B0pattern.TabIndex = 214
        Me.B0pattern.Text = "Pattern"
        Me.B0pattern.UseVisualStyleBackColor = True
        '
        'B0IniTile
        '
        Me.B0IniTile.Location = New System.Drawing.Point(79, 4)
        Me.B0IniTile.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.B0IniTile.MaxLength = 256
        Me.B0IniTile.Name = "B0IniTile"
        Me.B0IniTile.Size = New System.Drawing.Size(35, 21)
        Me.B0IniTile.TabIndex = 206
        Me.B0IniTile.Text = "0"
        Me.B0IniTile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'B0EndTile
        '
        Me.B0EndTile.Location = New System.Drawing.Point(138, 4)
        Me.B0EndTile.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.B0EndTile.MaxLength = 255
        Me.B0EndTile.Name = "B0EndTile"
        Me.B0EndTile.Size = New System.Drawing.Size(35, 21)
        Me.B0EndTile.TabIndex = 207
        Me.B0EndTile.Text = "255"
        Me.B0EndTile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(117, 7)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "to"
        '
        'B0Check
        '
        Me.B0Check.AutoSize = True
        Me.B0Check.Checked = True
        Me.B0Check.CheckState = System.Windows.Forms.CheckState.Checked
        Me.B0Check.Location = New System.Drawing.Point(9, 7)
        Me.B0Check.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.B0Check.Name = "B0Check"
        Me.B0Check.Size = New System.Drawing.Size(62, 17)
        Me.B0Check.TabIndex = 213
        Me.B0Check.Text = "Bank0"
        Me.B0Check.UseVisualStyleBackColor = True
        '
        'TabB1
        '
        Me.TabB1.Controls.Add(Me.Compression_CB1_CBox)
        Me.TabB1.Controls.Add(Me.Compression_PB1_CBox)
        Me.TabB1.Controls.Add(Me.B1color)
        Me.TabB1.Controls.Add(Me.B1Pattern)
        Me.TabB1.Controls.Add(Me.B1IniTile)
        Me.TabB1.Controls.Add(Me.B1EndTile)
        Me.TabB1.Controls.Add(Me.Label16)
        Me.TabB1.Controls.Add(Me.Bank1CheckB)
        Me.TabB1.Location = New System.Drawing.Point(4, 22)
        Me.TabB1.Name = "TabB1"
        Me.TabB1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabB1.Size = New System.Drawing.Size(180, 84)
        Me.TabB1.TabIndex = 1
        Me.TabB1.Text = "Bank1"
        Me.TabB1.UseVisualStyleBackColor = True
        '
        'Compression_CB1_CBox
        '
        Me.Compression_CB1_CBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Compression_CB1_CBox.FormattingEnabled = True
        Me.Compression_CB1_CBox.Items.AddRange(New Object() {"RAW", "RLE", "RLE WB"})
        Me.Compression_CB1_CBox.Location = New System.Drawing.Point(103, 54)
        Me.Compression_CB1_CBox.Name = "Compression_CB1_CBox"
        Me.Compression_CB1_CBox.Size = New System.Drawing.Size(70, 21)
        Me.Compression_CB1_CBox.TabIndex = 227
        '
        'Compression_PB1_CBox
        '
        Me.Compression_PB1_CBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Compression_PB1_CBox.FormattingEnabled = True
        Me.Compression_PB1_CBox.Items.AddRange(New Object() {"RAW", "RLE", "RLE WB"})
        Me.Compression_PB1_CBox.Location = New System.Drawing.Point(103, 29)
        Me.Compression_PB1_CBox.Name = "Compression_PB1_CBox"
        Me.Compression_PB1_CBox.Size = New System.Drawing.Size(70, 21)
        Me.Compression_PB1_CBox.TabIndex = 226
        '
        'B1color
        '
        Me.B1color.AutoSize = True
        Me.B1color.Checked = True
        Me.B1color.CheckState = System.Windows.Forms.CheckState.Checked
        Me.B1color.Location = New System.Drawing.Point(9, 58)
        Me.B1color.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.B1color.Name = "B1color"
        Me.B1color.Size = New System.Drawing.Size(57, 17)
        Me.B1color.TabIndex = 223
        Me.B1color.Text = "Color"
        Me.B1color.UseVisualStyleBackColor = True
        '
        'B1Pattern
        '
        Me.B1Pattern.AutoSize = True
        Me.B1Pattern.Checked = True
        Me.B1Pattern.CheckState = System.Windows.Forms.CheckState.Checked
        Me.B1Pattern.Location = New System.Drawing.Point(9, 33)
        Me.B1Pattern.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.B1Pattern.Name = "B1Pattern"
        Me.B1Pattern.Size = New System.Drawing.Size(67, 17)
        Me.B1Pattern.TabIndex = 222
        Me.B1Pattern.Text = "Pattern"
        Me.B1Pattern.UseVisualStyleBackColor = True
        '
        'B1IniTile
        '
        Me.B1IniTile.Location = New System.Drawing.Point(79, 4)
        Me.B1IniTile.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.B1IniTile.MaxLength = 256
        Me.B1IniTile.Name = "B1IniTile"
        Me.B1IniTile.Size = New System.Drawing.Size(35, 21)
        Me.B1IniTile.TabIndex = 220
        Me.B1IniTile.Text = "0"
        Me.B1IniTile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'B1EndTile
        '
        Me.B1EndTile.Location = New System.Drawing.Point(138, 4)
        Me.B1EndTile.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.B1EndTile.MaxLength = 255
        Me.B1EndTile.Name = "B1EndTile"
        Me.B1EndTile.Size = New System.Drawing.Size(35, 21)
        Me.B1EndTile.TabIndex = 221
        Me.B1EndTile.Text = "255"
        Me.B1EndTile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(117, 7)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(18, 13)
        Me.Label16.TabIndex = 219
        Me.Label16.Text = "to"
        '
        'Bank1CheckB
        '
        Me.Bank1CheckB.AutoSize = True
        Me.Bank1CheckB.Location = New System.Drawing.Point(9, 7)
        Me.Bank1CheckB.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Bank1CheckB.Name = "Bank1CheckB"
        Me.Bank1CheckB.Size = New System.Drawing.Size(62, 17)
        Me.Bank1CheckB.TabIndex = 214
        Me.Bank1CheckB.Text = "Bank1"
        Me.Bank1CheckB.UseVisualStyleBackColor = True
        '
        'TabB2
        '
        Me.TabB2.Controls.Add(Me.Compression_CB2_CBox)
        Me.TabB2.Controls.Add(Me.Compression_PB2_CBox)
        Me.TabB2.Controls.Add(Me.B2color)
        Me.TabB2.Controls.Add(Me.B2Pattern)
        Me.TabB2.Controls.Add(Me.B2IniTile)
        Me.TabB2.Controls.Add(Me.B2EndTile)
        Me.TabB2.Controls.Add(Me.Label18)
        Me.TabB2.Controls.Add(Me.Bank2CheckB)
        Me.TabB2.Location = New System.Drawing.Point(4, 22)
        Me.TabB2.Name = "TabB2"
        Me.TabB2.Size = New System.Drawing.Size(180, 84)
        Me.TabB2.TabIndex = 2
        Me.TabB2.Text = "Bank2"
        Me.TabB2.UseVisualStyleBackColor = True
        '
        'Compression_CB2_CBox
        '
        Me.Compression_CB2_CBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Compression_CB2_CBox.FormattingEnabled = True
        Me.Compression_CB2_CBox.Items.AddRange(New Object() {"RAW", "RLE", "RLE WB"})
        Me.Compression_CB2_CBox.Location = New System.Drawing.Point(103, 54)
        Me.Compression_CB2_CBox.Name = "Compression_CB2_CBox"
        Me.Compression_CB2_CBox.Size = New System.Drawing.Size(70, 21)
        Me.Compression_CB2_CBox.TabIndex = 229
        '
        'Compression_PB2_CBox
        '
        Me.Compression_PB2_CBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Compression_PB2_CBox.FormattingEnabled = True
        Me.Compression_PB2_CBox.Items.AddRange(New Object() {"RAW", "RLE", "RLE WB"})
        Me.Compression_PB2_CBox.Location = New System.Drawing.Point(103, 29)
        Me.Compression_PB2_CBox.Name = "Compression_PB2_CBox"
        Me.Compression_PB2_CBox.Size = New System.Drawing.Size(70, 21)
        Me.Compression_PB2_CBox.TabIndex = 228
        '
        'B2color
        '
        Me.B2color.AutoSize = True
        Me.B2color.Checked = True
        Me.B2color.CheckState = System.Windows.Forms.CheckState.Checked
        Me.B2color.Location = New System.Drawing.Point(9, 58)
        Me.B2color.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.B2color.Name = "B2color"
        Me.B2color.Size = New System.Drawing.Size(57, 17)
        Me.B2color.TabIndex = 223
        Me.B2color.Text = "Color"
        Me.B2color.UseVisualStyleBackColor = True
        '
        'B2Pattern
        '
        Me.B2Pattern.AutoSize = True
        Me.B2Pattern.Checked = True
        Me.B2Pattern.CheckState = System.Windows.Forms.CheckState.Checked
        Me.B2Pattern.Location = New System.Drawing.Point(9, 33)
        Me.B2Pattern.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.B2Pattern.Name = "B2Pattern"
        Me.B2Pattern.Size = New System.Drawing.Size(67, 17)
        Me.B2Pattern.TabIndex = 222
        Me.B2Pattern.Text = "Pattern"
        Me.B2Pattern.UseVisualStyleBackColor = True
        '
        'B2IniTile
        '
        Me.B2IniTile.Location = New System.Drawing.Point(79, 4)
        Me.B2IniTile.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.B2IniTile.MaxLength = 256
        Me.B2IniTile.Name = "B2IniTile"
        Me.B2IniTile.Size = New System.Drawing.Size(35, 21)
        Me.B2IniTile.TabIndex = 220
        Me.B2IniTile.Text = "0"
        Me.B2IniTile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'B2EndTile
        '
        Me.B2EndTile.Location = New System.Drawing.Point(138, 4)
        Me.B2EndTile.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.B2EndTile.MaxLength = 255
        Me.B2EndTile.Name = "B2EndTile"
        Me.B2EndTile.Size = New System.Drawing.Size(35, 21)
        Me.B2EndTile.TabIndex = 221
        Me.B2EndTile.Text = "255"
        Me.B2EndTile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(117, 7)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(18, 13)
        Me.Label18.TabIndex = 219
        Me.Label18.Text = "to"
        '
        'Bank2CheckB
        '
        Me.Bank2CheckB.AutoSize = True
        Me.Bank2CheckB.Location = New System.Drawing.Point(9, 7)
        Me.Bank2CheckB.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Bank2CheckB.Name = "Bank2CheckB"
        Me.Bank2CheckB.Size = New System.Drawing.Size(62, 17)
        Me.Bank2CheckB.TabIndex = 215
        Me.Bank2CheckB.Text = "Bank2"
        Me.Bank2CheckB.UseVisualStyleBackColor = True
        '
        'AllBanksCheckBox
        '
        Me.AllBanksCheckBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AllBanksCheckBox.AutoSize = True
        Me.AllBanksCheckBox.Checked = True
        Me.AllBanksCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AllBanksCheckBox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AllBanksCheckBox.Location = New System.Drawing.Point(621, 125)
        Me.AllBanksCheckBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.AllBanksCheckBox.Name = "AllBanksCheckBox"
        Me.AllBanksCheckBox.Size = New System.Drawing.Size(86, 17)
        Me.AllBanksCheckBox.TabIndex = 225
        Me.AllBanksCheckBox.Text = "All Banks"
        Me.AllBanksCheckBox.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(618, 38)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(65, 13)
        Me.Label20.TabIndex = 222
        Me.Label20.Text = "Num sys.:"
        '
        'Tileset_NumSysComboBox
        '
        Me.Tileset_NumSysComboBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tileset_NumSysComboBox.FormattingEnabled = True
        Me.Tileset_NumSysComboBox.Items.AddRange(New Object() {"dec nnn", "dec nnnd", "hex FF", "hex 0xFF", "hex $FF", "hex #FF", "hex 0FFh", "hex &HFF"})
        Me.Tileset_NumSysComboBox.Location = New System.Drawing.Point(695, 35)
        Me.Tileset_NumSysComboBox.Name = "Tileset_NumSysComboBox"
        Me.Tileset_NumSysComboBox.Size = New System.Drawing.Size(110, 21)
        Me.Tileset_NumSysComboBox.TabIndex = 223
        '
        'Tileset_SizeLineComboB
        '
        Me.Tileset_SizeLineComboB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tileset_SizeLineComboB.FormattingEnabled = True
        Me.Tileset_SizeLineComboB.Items.AddRange(New Object() {"8", "16", "24", "32"})
        Me.Tileset_SizeLineComboB.Location = New System.Drawing.Point(695, 87)
        Me.Tileset_SizeLineComboB.Name = "Tileset_SizeLineComboB"
        Me.Tileset_SizeLineComboB.Size = New System.Drawing.Size(110, 21)
        Me.Tileset_SizeLineComboB.TabIndex = 209
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(619, 90)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 13)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "Size Line:"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(618, 12)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 13)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Language:"
        '
        'Tileset_CodeOutComboB
        '
        Me.Tileset_CodeOutComboB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tileset_CodeOutComboB.FormattingEnabled = True
        Me.Tileset_CodeOutComboB.Items.AddRange(New Object() {"BASIC", "C", "ASM", "ASM SDCC"})
        Me.Tileset_CodeOutComboB.Location = New System.Drawing.Point(695, 9)
        Me.Tileset_CodeOutComboB.Name = "Tileset_CodeOutComboB"
        Me.Tileset_CodeOutComboB.Size = New System.Drawing.Size(84, 21)
        Me.Tileset_CodeOutComboB.TabIndex = 204
        '
        'TilesetGenButton
        '
        Me.TilesetGenButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TilesetGenButton.BackColor = System.Drawing.Color.PaleTurquoise
        Me.TilesetGenButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TilesetGenButton.Location = New System.Drawing.Point(719, 265)
        Me.TilesetGenButton.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TilesetGenButton.Name = "TilesetGenButton"
        Me.TilesetGenButton.Size = New System.Drawing.Size(86, 28)
        Me.TilesetGenButton.TabIndex = 216
        Me.TilesetGenButton.Text = "Do it!"
        Me.TilesetGenButton.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(619, 64)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Field name:"
        '
        'Tileset_FieldName
        '
        Me.Tileset_FieldName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tileset_FieldName.Location = New System.Drawing.Point(695, 61)
        Me.Tileset_FieldName.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Tileset_FieldName.MaxLength = 32
        Me.Tileset_FieldName.Name = "Tileset_FieldName"
        Me.Tileset_FieldName.Size = New System.Drawing.Size(110, 21)
        Me.Tileset_FieldName.TabIndex = 205
        Me.Tileset_FieldName.Text = "TILESET"
        '
        'Tileset_TxtOutput
        '
        Me.Tileset_TxtOutput.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tileset_TxtOutput.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tileset_TxtOutput.Location = New System.Drawing.Point(12, 42)
        Me.Tileset_TxtOutput.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Tileset_TxtOutput.Multiline = True
        Me.Tileset_TxtOutput.Name = "Tileset_TxtOutput"
        Me.Tileset_TxtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Tileset_TxtOutput.Size = New System.Drawing.Size(600, 250)
        Me.Tileset_TxtOutput.TabIndex = 8
        '
        'SaveTilesCBut
        '
        Me.SaveTilesCBut.BackColor = System.Drawing.Color.Gainsboro
        Me.SaveTilesCBut.Image = Global.MSXTILESdevtool.My.Resources.Resources.save
        Me.SaveTilesCBut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SaveTilesCBut.Location = New System.Drawing.Point(527, 8)
        Me.SaveTilesCBut.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SaveTilesCBut.Name = "SaveTilesCBut"
        Me.SaveTilesCBut.Size = New System.Drawing.Size(86, 28)
        Me.SaveTilesCBut.TabIndex = 202
        Me.SaveTilesCBut.Text = "TXT"
        Me.SaveTilesCBut.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.SaveTilesCBut, "Save output in text file")
        Me.SaveTilesCBut.UseVisualStyleBackColor = False
        '
        'LoadTilesBut
        '
        Me.LoadTilesBut.BackColor = System.Drawing.Color.Gainsboro
        Me.LoadTilesBut.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoadTilesBut.Image = Global.MSXTILESdevtool.My.Resources.Resources.folder
        Me.LoadTilesBut.Location = New System.Drawing.Point(53, 8)
        Me.LoadTilesBut.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.LoadTilesBut.Name = "LoadTilesBut"
        Me.LoadTilesBut.Size = New System.Drawing.Size(34, 28)
        Me.LoadTilesBut.TabIndex = 200
        Me.LoadTilesBut.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.LoadTilesBut, "Load nMSXtiles Tileset")
        Me.LoadTilesBut.UseVisualStyleBackColor = False
        '
        'SaveTilesBinBut
        '
        Me.SaveTilesBinBut.BackColor = System.Drawing.Color.Gainsboro
        Me.SaveTilesBinBut.Enabled = False
        Me.SaveTilesBinBut.Image = Global.MSXTILESdevtool.My.Resources.Resources.save
        Me.SaveTilesBinBut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SaveTilesBinBut.Location = New System.Drawing.Point(436, 8)
        Me.SaveTilesBinBut.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SaveTilesBinBut.Name = "SaveTilesBinBut"
        Me.SaveTilesBinBut.Size = New System.Drawing.Size(86, 28)
        Me.SaveTilesBinBut.TabIndex = 201
        Me.SaveTilesBinBut.Text = "Binary"
        Me.SaveTilesBinBut.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SaveTilesBinBut.UseVisualStyleBackColor = False
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage2.Controls.Add(Me.SaveMapButton)
        Me.TabPage2.Controls.Add(Me.LoadMapButton)
        Me.TabPage2.Controls.Add(Me.BasicConfigButton2)
        Me.TabPage2.Controls.Add(Me.Label26)
        Me.TabPage2.Controls.Add(Me.Map_NumSysComboBox)
        Me.TabPage2.Controls.Add(Me.Label19)
        Me.TabPage2.Controls.Add(Me.Map_compressionScrCB)
        Me.TabPage2.Controls.Add(Me.Map_SizeLineComboB)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.endTileY)
        Me.TabPage2.Controls.Add(Me.endTileX)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.startTileY)
        Me.TabPage2.Controls.Add(Me.startTileX)
        Me.TabPage2.Controls.Add(Me.Map_CodeOutComboB)
        Me.TabPage2.Controls.Add(Me.GetScrButton)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.Map_FieldName)
        Me.TabPage2.Controls.Add(Me.Tiles_TxtOutput)
        Me.TabPage2.Controls.Add(Me.LoadScrText)
        Me.TabPage2.Controls.Add(Me.Map_areaResetButton)
        Me.TabPage2.Controls.Add(Me.SaveTxtScrBut)
        Me.TabPage2.Controls.Add(Me.SaveBinBut)
        Me.TabPage2.Controls.Add(Me.LoadScrBut)
        Me.TabPage2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TabPage2.Size = New System.Drawing.Size(813, 296)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Screen map"
        '
        'SaveMapButton
        '
        Me.SaveMapButton.BackColor = System.Drawing.Color.LightGreen
        Me.SaveMapButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.save
        Me.SaveMapButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SaveMapButton.Location = New System.Drawing.Point(343, 8)
        Me.SaveMapButton.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SaveMapButton.Name = "SaveMapButton"
        Me.SaveMapButton.Size = New System.Drawing.Size(86, 28)
        Me.SaveMapButton.TabIndex = 229
        Me.SaveMapButton.Text = "Map"
        Me.SaveMapButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.SaveMapButton, "Save Open Document Map")
        Me.SaveMapButton.UseVisualStyleBackColor = False
        '
        'LoadMapButton
        '
        Me.LoadMapButton.BackColor = System.Drawing.Color.LightGreen
        Me.LoadMapButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.folder
        Me.LoadMapButton.Location = New System.Drawing.Point(12, 8)
        Me.LoadMapButton.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.LoadMapButton.Name = "LoadMapButton"
        Me.LoadMapButton.Size = New System.Drawing.Size(34, 28)
        Me.LoadMapButton.TabIndex = 228
        Me.LoadMapButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.LoadMapButton, "Load Open Document Map")
        Me.LoadMapButton.UseVisualStyleBackColor = False
        '
        'BasicConfigButton2
        '
        Me.BasicConfigButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BasicConfigButton2.BackColor = System.Drawing.Color.Gainsboro
        Me.BasicConfigButton2.Location = New System.Drawing.Point(782, 42)
        Me.BasicConfigButton2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BasicConfigButton2.Name = "BasicConfigButton2"
        Me.BasicConfigButton2.Size = New System.Drawing.Size(23, 22)
        Me.BasicConfigButton2.TabIndex = 227
        Me.BasicConfigButton2.Text = "+"
        Me.ToolTip1.SetToolTip(Me.BasicConfigButton2, "Basic config.")
        Me.BasicConfigButton2.UseVisualStyleBackColor = False
        '
        'Label26
        '
        Me.Label26.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(618, 72)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(65, 13)
        Me.Label26.TabIndex = 220
        Me.Label26.Text = "Num sys.:"
        '
        'Map_NumSysComboBox
        '
        Me.Map_NumSysComboBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Map_NumSysComboBox.FormattingEnabled = True
        Me.Map_NumSysComboBox.Items.AddRange(New Object() {"dec nnn", "dec nnnd", "hex FF", "hex 0xFF", "hex $FF", "hex #FF", "hex 0FFh", "hex &HFF"})
        Me.Map_NumSysComboBox.Location = New System.Drawing.Point(695, 69)
        Me.Map_NumSysComboBox.Name = "Map_NumSysComboBox"
        Me.Map_NumSysComboBox.Size = New System.Drawing.Size(110, 21)
        Me.Map_NumSysComboBox.TabIndex = 221
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(619, 150)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(70, 13)
        Me.Label19.TabIndex = 219
        Me.Label19.Text = "Compress:"
        '
        'Map_compressionScrCB
        '
        Me.Map_compressionScrCB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Map_compressionScrCB.FormattingEnabled = True
        Me.Map_compressionScrCB.Items.AddRange(New Object() {"RAW", "RLE", "RLE WB"})
        Me.Map_compressionScrCB.Location = New System.Drawing.Point(695, 147)
        Me.Map_compressionScrCB.Name = "Map_compressionScrCB"
        Me.Map_compressionScrCB.Size = New System.Drawing.Size(110, 21)
        Me.Map_compressionScrCB.TabIndex = 218
        '
        'Map_SizeLineComboB
        '
        Me.Map_SizeLineComboB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Map_SizeLineComboB.FormattingEnabled = True
        Me.Map_SizeLineComboB.Items.AddRange(New Object() {"line", "8", "16", "24", "32"})
        Me.Map_SizeLineComboB.Location = New System.Drawing.Point(695, 121)
        Me.Map_SizeLineComboB.Name = "Map_SizeLineComboB"
        Me.Map_SizeLineComboB.Size = New System.Drawing.Size(110, 21)
        Me.Map_SizeLineComboB.TabIndex = 106
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(619, 124)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 13)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "Size Line:"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(618, 46)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 13)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "Language:"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(621, 219)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "EndTile (x,y)"
        '
        'endTileY
        '
        Me.endTileY.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.endTileY.Location = New System.Drawing.Point(746, 216)
        Me.endTileY.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.endTileY.MaxLength = 2
        Me.endTileY.Name = "endTileY"
        Me.endTileY.Size = New System.Drawing.Size(30, 21)
        Me.endTileY.TabIndex = 113
        Me.endTileY.Text = "23"
        Me.endTileY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'endTileX
        '
        Me.endTileX.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.endTileX.Location = New System.Drawing.Point(712, 216)
        Me.endTileX.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.endTileX.MaxLength = 2
        Me.endTileX.Name = "endTileX"
        Me.endTileX.Size = New System.Drawing.Size(30, 21)
        Me.endTileX.TabIndex = 112
        Me.endTileX.Text = "31"
        Me.endTileX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(621, 192)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(87, 13)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "StartTile (x,y)"
        '
        'startTileY
        '
        Me.startTileY.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.startTileY.Location = New System.Drawing.Point(746, 189)
        Me.startTileY.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.startTileY.MaxLength = 2
        Me.startTileY.Name = "startTileY"
        Me.startTileY.Size = New System.Drawing.Size(30, 21)
        Me.startTileY.TabIndex = 111
        Me.startTileY.Text = "0"
        Me.startTileY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'startTileX
        '
        Me.startTileX.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.startTileX.Location = New System.Drawing.Point(712, 189)
        Me.startTileX.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.startTileX.MaxLength = 2
        Me.startTileX.Name = "startTileX"
        Me.startTileX.Size = New System.Drawing.Size(30, 21)
        Me.startTileX.TabIndex = 110
        Me.startTileX.Text = "0"
        Me.startTileX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Map_CodeOutComboB
        '
        Me.Map_CodeOutComboB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Map_CodeOutComboB.FormattingEnabled = True
        Me.Map_CodeOutComboB.Items.AddRange(New Object() {"BASIC", "C", "ASM", "ASM SDCC"})
        Me.Map_CodeOutComboB.Location = New System.Drawing.Point(695, 43)
        Me.Map_CodeOutComboB.Name = "Map_CodeOutComboB"
        Me.Map_CodeOutComboB.Size = New System.Drawing.Size(84, 21)
        Me.Map_CodeOutComboB.TabIndex = 104
        '
        'GetScrButton
        '
        Me.GetScrButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GetScrButton.BackColor = System.Drawing.Color.PaleTurquoise
        Me.GetScrButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GetScrButton.Location = New System.Drawing.Point(719, 265)
        Me.GetScrButton.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GetScrButton.Name = "GetScrButton"
        Me.GetScrButton.Size = New System.Drawing.Size(86, 28)
        Me.GetScrButton.TabIndex = 115
        Me.GetScrButton.Text = "Do it!"
        Me.GetScrButton.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(619, 98)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Field name:"
        '
        'Map_FieldName
        '
        Me.Map_FieldName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Map_FieldName.Location = New System.Drawing.Point(695, 95)
        Me.Map_FieldName.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Map_FieldName.MaxLength = 32
        Me.Map_FieldName.Name = "Map_FieldName"
        Me.Map_FieldName.Size = New System.Drawing.Size(110, 21)
        Me.Map_FieldName.TabIndex = 105
        Me.Map_FieldName.Text = "SCR00"
        '
        'Tiles_TxtOutput
        '
        Me.Tiles_TxtOutput.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tiles_TxtOutput.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tiles_TxtOutput.Location = New System.Drawing.Point(12, 42)
        Me.Tiles_TxtOutput.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Tiles_TxtOutput.Multiline = True
        Me.Tiles_TxtOutput.Name = "Tiles_TxtOutput"
        Me.Tiles_TxtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Tiles_TxtOutput.Size = New System.Drawing.Size(600, 250)
        Me.Tiles_TxtOutput.TabIndex = 2
        '
        'Map_areaResetButton
        '
        Me.Map_areaResetButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Map_areaResetButton.BackColor = System.Drawing.Color.Gainsboro
        Me.Map_areaResetButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.auto_16x16
        Me.Map_areaResetButton.Location = New System.Drawing.Point(780, 215)
        Me.Map_areaResetButton.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Map_areaResetButton.Name = "Map_areaResetButton"
        Me.Map_areaResetButton.Size = New System.Drawing.Size(24, 22)
        Me.Map_areaResetButton.TabIndex = 114
        Me.ToolTip1.SetToolTip(Me.Map_areaResetButton, "Initialize values.")
        Me.Map_areaResetButton.UseVisualStyleBackColor = False
        '
        'SaveTxtScrBut
        '
        Me.SaveTxtScrBut.BackColor = System.Drawing.Color.Gainsboro
        Me.SaveTxtScrBut.Image = Global.MSXTILESdevtool.My.Resources.Resources.save
        Me.SaveTxtScrBut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SaveTxtScrBut.Location = New System.Drawing.Point(527, 8)
        Me.SaveTxtScrBut.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SaveTxtScrBut.Name = "SaveTxtScrBut"
        Me.SaveTxtScrBut.Size = New System.Drawing.Size(86, 28)
        Me.SaveTxtScrBut.TabIndex = 102
        Me.SaveTxtScrBut.Text = "TXT"
        Me.SaveTxtScrBut.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.SaveTxtScrBut, "Save output in text file")
        Me.SaveTxtScrBut.UseVisualStyleBackColor = False
        '
        'SaveBinBut
        '
        Me.SaveBinBut.BackColor = System.Drawing.Color.Gainsboro
        Me.SaveBinBut.Image = Global.MSXTILESdevtool.My.Resources.Resources.save
        Me.SaveBinBut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SaveBinBut.Location = New System.Drawing.Point(436, 8)
        Me.SaveBinBut.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SaveBinBut.Name = "SaveBinBut"
        Me.SaveBinBut.Size = New System.Drawing.Size(86, 28)
        Me.SaveBinBut.TabIndex = 101
        Me.SaveBinBut.Text = "Binary"
        Me.SaveBinBut.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.SaveBinBut, "Save name table in binary SC2" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(&H1800 - &H1AFF)")
        Me.SaveBinBut.UseVisualStyleBackColor = False
        '
        'LoadScrBut
        '
        Me.LoadScrBut.BackColor = System.Drawing.Color.Gainsboro
        Me.LoadScrBut.Image = Global.MSXTILESdevtool.My.Resources.Resources.folder
        Me.LoadScrBut.Location = New System.Drawing.Point(53, 8)
        Me.LoadScrBut.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.LoadScrBut.Name = "LoadScrBut"
        Me.LoadScrBut.Size = New System.Drawing.Size(34, 28)
        Me.LoadScrBut.TabIndex = 100
        Me.LoadScrBut.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.LoadScrBut, "Load nMSXtiles screen")
        Me.LoadScrBut.UseVisualStyleBackColor = False
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage1.Controls.Add(Me.BasicConfigButton3)
        Me.TabPage1.Controls.Add(Me.Label25)
        Me.TabPage1.Controls.Add(Me.Palette_NumSysCombo)
        Me.TabPage1.Controls.Add(Me.Palette_SizeLineComboB)
        Me.TabPage1.Controls.Add(Me.Label22)
        Me.TabPage1.Controls.Add(Me.Label23)
        Me.TabPage1.Controls.Add(Me.Palette_CodeOutComboB)
        Me.TabPage1.Controls.Add(Me.Label24)
        Me.TabPage1.Controls.Add(Me.Palette_FieldName)
        Me.TabPage1.Controls.Add(Me.Palette_TxtOutput)
        Me.TabPage1.Controls.Add(Me.GetPaletteButton)
        Me.TabPage1.Controls.Add(Me.PaleteNameTextB)
        Me.TabPage1.Controls.Add(Me.EditPaleteButton)
        Me.TabPage1.Controls.Add(Me.SavePaletteButton)
        Me.TabPage1.Controls.Add(Me.SaveTxtPalBut)
        Me.TabPage1.Controls.Add(Me.LoadPaletteButton)
        Me.TabPage1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(813, 296)
        Me.TabPage1.TabIndex = 3
        Me.TabPage1.Text = "Palette"
        '
        'BasicConfigButton3
        '
        Me.BasicConfigButton3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BasicConfigButton3.BackColor = System.Drawing.Color.Gainsboro
        Me.BasicConfigButton3.Location = New System.Drawing.Point(782, 42)
        Me.BasicConfigButton3.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BasicConfigButton3.Name = "BasicConfigButton3"
        Me.BasicConfigButton3.Size = New System.Drawing.Size(23, 22)
        Me.BasicConfigButton3.TabIndex = 238
        Me.BasicConfigButton3.Text = "+"
        Me.ToolTip1.SetToolTip(Me.BasicConfigButton3, "Basic config.")
        Me.BasicConfigButton3.UseVisualStyleBackColor = False
        '
        'Label25
        '
        Me.Label25.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(618, 72)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(65, 13)
        Me.Label25.TabIndex = 237
        Me.Label25.Text = "Num sys.:"
        '
        'Palette_NumSysCombo
        '
        Me.Palette_NumSysCombo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Palette_NumSysCombo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Palette_NumSysCombo.FormattingEnabled = True
        Me.Palette_NumSysCombo.Items.AddRange(New Object() {"dec nnn", "dec nnnd", "hex FF", "hex 0xFF", "hex $FF", "hex #FF", "hex 0FFh", "hex &HFF"})
        Me.Palette_NumSysCombo.Location = New System.Drawing.Point(695, 69)
        Me.Palette_NumSysCombo.Name = "Palette_NumSysCombo"
        Me.Palette_NumSysCombo.Size = New System.Drawing.Size(110, 21)
        Me.Palette_NumSysCombo.TabIndex = 236
        Me.ToolTip1.SetToolTip(Me.Palette_NumSysCombo, "Numeral system.")
        '
        'Palette_SizeLineComboB
        '
        Me.Palette_SizeLineComboB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Palette_SizeLineComboB.FormattingEnabled = True
        Me.Palette_SizeLineComboB.Items.AddRange(New Object() {"2", "4", "8", "16", "32"})
        Me.Palette_SizeLineComboB.Location = New System.Drawing.Point(695, 121)
        Me.Palette_SizeLineComboB.Name = "Palette_SizeLineComboB"
        Me.Palette_SizeLineComboB.Size = New System.Drawing.Size(110, 21)
        Me.Palette_SizeLineComboB.TabIndex = 232
        '
        'Label22
        '
        Me.Label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(619, 124)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(63, 13)
        Me.Label22.TabIndex = 227
        Me.Label22.Text = "Size Line:"
        '
        'Label23
        '
        Me.Label23.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(618, 46)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(67, 13)
        Me.Label23.TabIndex = 226
        Me.Label23.Text = "Language:"
        '
        'Palette_CodeOutComboB
        '
        Me.Palette_CodeOutComboB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Palette_CodeOutComboB.FormattingEnabled = True
        Me.Palette_CodeOutComboB.Items.AddRange(New Object() {"BASIC", "C", "ASM", "ASM SDCC"})
        Me.Palette_CodeOutComboB.Location = New System.Drawing.Point(695, 43)
        Me.Palette_CodeOutComboB.Name = "Palette_CodeOutComboB"
        Me.Palette_CodeOutComboB.Size = New System.Drawing.Size(84, 21)
        Me.Palette_CodeOutComboB.TabIndex = 230
        '
        'Label24
        '
        Me.Label24.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(619, 98)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(74, 13)
        Me.Label24.TabIndex = 225
        Me.Label24.Text = "Field name:"
        '
        'Palette_FieldName
        '
        Me.Palette_FieldName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Palette_FieldName.Location = New System.Drawing.Point(695, 95)
        Me.Palette_FieldName.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Palette_FieldName.MaxLength = 32
        Me.Palette_FieldName.Name = "Palette_FieldName"
        Me.Palette_FieldName.Size = New System.Drawing.Size(110, 21)
        Me.Palette_FieldName.TabIndex = 231
        Me.Palette_FieldName.Text = "PALETTE00"
        '
        'Palette_TxtOutput
        '
        Me.Palette_TxtOutput.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Palette_TxtOutput.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Palette_TxtOutput.Location = New System.Drawing.Point(12, 42)
        Me.Palette_TxtOutput.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Palette_TxtOutput.Multiline = True
        Me.Palette_TxtOutput.Name = "Palette_TxtOutput"
        Me.Palette_TxtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Palette_TxtOutput.Size = New System.Drawing.Size(600, 250)
        Me.Palette_TxtOutput.TabIndex = 222
        '
        'GetPaletteButton
        '
        Me.GetPaletteButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GetPaletteButton.BackColor = System.Drawing.Color.PaleTurquoise
        Me.GetPaletteButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GetPaletteButton.Location = New System.Drawing.Point(719, 265)
        Me.GetPaletteButton.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GetPaletteButton.Name = "GetPaletteButton"
        Me.GetPaletteButton.Size = New System.Drawing.Size(86, 28)
        Me.GetPaletteButton.TabIndex = 221
        Me.GetPaletteButton.Text = "Do it!"
        Me.GetPaletteButton.UseVisualStyleBackColor = False
        '
        'PaleteNameTextB
        '
        Me.PaleteNameTextB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PaleteNameTextB.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaleteNameTextB.Location = New System.Drawing.Point(95, 11)
        Me.PaleteNameTextB.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PaleteNameTextB.Name = "PaleteNameTextB"
        Me.PaleteNameTextB.ReadOnly = True
        Me.PaleteNameTextB.Size = New System.Drawing.Size(240, 22)
        Me.PaleteNameTextB.TabIndex = 217
        '
        'EditPaleteButton
        '
        Me.EditPaleteButton.BackColor = System.Drawing.Color.Gainsboro
        Me.EditPaleteButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditPaleteButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.palette3_x24
        Me.EditPaleteButton.Location = New System.Drawing.Point(12, 8)
        Me.EditPaleteButton.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.EditPaleteButton.Name = "EditPaleteButton"
        Me.EditPaleteButton.Size = New System.Drawing.Size(34, 28)
        Me.EditPaleteButton.TabIndex = 224
        Me.EditPaleteButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.EditPaleteButton, "Edit palette")
        Me.EditPaleteButton.UseVisualStyleBackColor = False
        '
        'SavePaletteButton
        '
        Me.SavePaletteButton.BackColor = System.Drawing.Color.Gainsboro
        Me.SavePaletteButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.save
        Me.SavePaletteButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SavePaletteButton.Location = New System.Drawing.Point(344, 8)
        Me.SavePaletteButton.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SavePaletteButton.Name = "SavePaletteButton"
        Me.SavePaletteButton.Size = New System.Drawing.Size(86, 28)
        Me.SavePaletteButton.TabIndex = 223
        Me.SavePaletteButton.Text = "Project"
        Me.SavePaletteButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.SavePaletteButton, "Save palette")
        Me.SavePaletteButton.UseVisualStyleBackColor = False
        '
        'SaveTxtPalBut
        '
        Me.SaveTxtPalBut.BackColor = System.Drawing.Color.Gainsboro
        Me.SaveTxtPalBut.Image = Global.MSXTILESdevtool.My.Resources.Resources.save
        Me.SaveTxtPalBut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SaveTxtPalBut.Location = New System.Drawing.Point(435, 8)
        Me.SaveTxtPalBut.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SaveTxtPalBut.Name = "SaveTxtPalBut"
        Me.SaveTxtPalBut.Size = New System.Drawing.Size(86, 28)
        Me.SaveTxtPalBut.TabIndex = 219
        Me.SaveTxtPalBut.Text = "TXT"
        Me.SaveTxtPalBut.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.SaveTxtPalBut, "Save output in text file")
        Me.SaveTxtPalBut.UseVisualStyleBackColor = False
        '
        'LoadPaletteButton
        '
        Me.LoadPaletteButton.BackColor = System.Drawing.Color.Gainsboro
        Me.LoadPaletteButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoadPaletteButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.folder
        Me.LoadPaletteButton.Location = New System.Drawing.Point(53, 8)
        Me.LoadPaletteButton.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.LoadPaletteButton.Name = "LoadPaletteButton"
        Me.LoadPaletteButton.Size = New System.Drawing.Size(34, 28)
        Me.LoadPaletteButton.TabIndex = 218
        Me.LoadPaletteButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.LoadPaletteButton, "Load palette")
        Me.LoadPaletteButton.UseVisualStyleBackColor = False
        '
        'PosxTextB
        '
        Me.PosxTextB.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PosxTextB.Location = New System.Drawing.Point(590, 209)
        Me.PosxTextB.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PosxTextB.MaxLength = 7
        Me.PosxTextB.Name = "PosxTextB"
        Me.PosxTextB.ReadOnly = True
        Me.PosxTextB.Size = New System.Drawing.Size(30, 21)
        Me.PosxTextB.TabIndex = 18
        Me.PosxTextB.Text = "0"
        Me.PosxTextB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TileTextB
        '
        Me.TileTextB.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TileTextB.Location = New System.Drawing.Point(802, 209)
        Me.TileTextB.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TileTextB.MaxLength = 255
        Me.TileTextB.Name = "TileTextB"
        Me.TileTextB.ReadOnly = True
        Me.TileTextB.Size = New System.Drawing.Size(30, 21)
        Me.TileTextB.TabIndex = 19
        Me.TileTextB.Text = "0"
        Me.TileTextB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(571, 212)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(20, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "X:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(770, 212)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 13)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Tile:"
        '
        'vaddrTextB
        '
        Me.vaddrTextB.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vaddrTextB.Location = New System.Drawing.Point(724, 209)
        Me.vaddrTextB.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.vaddrTextB.MaxLength = 7
        Me.vaddrTextB.Name = "vaddrTextB"
        Me.vaddrTextB.ReadOnly = True
        Me.vaddrTextB.Size = New System.Drawing.Size(40, 21)
        Me.vaddrTextB.TabIndex = 24
        Me.vaddrTextB.Text = "0"
        Me.vaddrTextB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.vaddrTextB, "VRAM address")
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'ProjectDataButton
        '
        Me.ProjectDataButton.BackColor = System.Drawing.Color.Gainsboro
        Me.ProjectDataButton.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProjectDataButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.project_properties_24
        Me.ProjectDataButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ProjectDataButton.Location = New System.Drawing.Point(206, 12)
        Me.ProjectDataButton.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ProjectDataButton.Name = "ProjectDataButton"
        Me.ProjectDataButton.Size = New System.Drawing.Size(32, 30)
        Me.ProjectDataButton.TabIndex = 33
        Me.ProjectDataButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.ProjectDataButton, "Edit project info")
        Me.ProjectDataButton.UseVisualStyleBackColor = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.MSXTILESdevtool.My.Resources.Resources.dragdrop_48_06Y
        Me.PictureBox2.Location = New System.Drawing.Point(3, 168)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox2.TabIndex = 36
        Me.PictureBox2.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox2, "Drag & Drop your picture files " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PNG, GIF or SC2")
        '
        'SaveSCProjectButton
        '
        Me.SaveSCProjectButton.BackColor = System.Drawing.Color.LightGreen
        Me.SaveSCProjectButton.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveSCProjectButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.save
        Me.SaveSCProjectButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SaveSCProjectButton.Location = New System.Drawing.Point(452, 99)
        Me.SaveSCProjectButton.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SaveSCProjectButton.Name = "SaveSCProjectButton"
        Me.SaveSCProjectButton.Size = New System.Drawing.Size(113, 28)
        Me.SaveSCProjectButton.TabIndex = 35
        Me.SaveSCProjectButton.Text = "Save PRJ"
        Me.SaveSCProjectButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.SaveSCProjectButton, "Save Open Document Screen Project")
        Me.SaveSCProjectButton.UseVisualStyleBackColor = False
        '
        'LoadSCProjectButton
        '
        Me.LoadSCProjectButton.BackColor = System.Drawing.Color.LightGreen
        Me.LoadSCProjectButton.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoadSCProjectButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.folder
        Me.LoadSCProjectButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LoadSCProjectButton.Location = New System.Drawing.Point(56, 99)
        Me.LoadSCProjectButton.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.LoadSCProjectButton.Name = "LoadSCProjectButton"
        Me.LoadSCProjectButton.Size = New System.Drawing.Size(118, 28)
        Me.LoadSCProjectButton.TabIndex = 34
        Me.LoadSCProjectButton.Text = "Load PRJ"
        Me.LoadSCProjectButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.LoadSCProjectButton, "Load Open Document Screen Project")
        Me.LoadSCProjectButton.UseVisualStyleBackColor = False
        '
        'SavePrjButton
        '
        Me.SavePrjButton.BackColor = System.Drawing.Color.Gainsboro
        Me.SavePrjButton.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SavePrjButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.save
        Me.SavePrjButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SavePrjButton.Location = New System.Drawing.Point(452, 128)
        Me.SavePrjButton.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SavePrjButton.Name = "SavePrjButton"
        Me.SavePrjButton.Size = New System.Drawing.Size(113, 28)
        Me.SavePrjButton.TabIndex = 33
        Me.SavePrjButton.Text = "Save nMSX"
        Me.SavePrjButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.SavePrjButton, "Save nMSXtiles Project")
        Me.SavePrjButton.UseVisualStyleBackColor = False
        '
        'SaveSC4But
        '
        Me.SaveSC4But.BackColor = System.Drawing.Color.Gainsboro
        Me.SaveSC4But.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveSC4But.Image = Global.MSXTILESdevtool.My.Resources.Resources.palette3_x24
        Me.SaveSC4But.Location = New System.Drawing.Point(512, 62)
        Me.SaveSC4But.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SaveSC4But.Name = "SaveSC4But"
        Me.SaveSC4But.Size = New System.Drawing.Size(53, 27)
        Me.SaveSC4But.TabIndex = 32
        Me.SaveSC4But.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.SaveSC4But, "Edit Palette")
        Me.SaveSC4But.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.MSXTILESdevtool.My.Resources.Resources.about_24
        Me.Button1.Location = New System.Drawing.Point(393, 4)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(26, 26)
        Me.Button1.TabIndex = 31
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.Button1, "About!")
        Me.Button1.UseVisualStyleBackColor = False
        '
        'LoadPNGBut
        '
        Me.LoadPNGBut.BackColor = System.Drawing.Color.Gainsboro
        Me.LoadPNGBut.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoadPNGBut.Image = Global.MSXTILESdevtool.My.Resources.Resources.folder
        Me.LoadPNGBut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LoadPNGBut.Location = New System.Drawing.Point(56, 188)
        Me.LoadPNGBut.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.LoadPNGBut.Name = "LoadPNGBut"
        Me.LoadPNGBut.Size = New System.Drawing.Size(118, 28)
        Me.LoadPNGBut.TabIndex = 25
        Me.LoadPNGBut.Text = "Load bitmap"
        Me.LoadPNGBut.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.LoadPNGBut, "Load PNG/GIF picture " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "& convert to MSX screen.")
        Me.LoadPNGBut.UseVisualStyleBackColor = False
        '
        'SavePNGBut
        '
        Me.SavePNGBut.BackColor = System.Drawing.Color.Gainsboro
        Me.SavePNGBut.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SavePNGBut.Image = Global.MSXTILESdevtool.My.Resources.Resources.save
        Me.SavePNGBut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SavePNGBut.Location = New System.Drawing.Point(452, 188)
        Me.SavePNGBut.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SavePNGBut.Name = "SavePNGBut"
        Me.SavePNGBut.Size = New System.Drawing.Size(113, 28)
        Me.SavePNGBut.TabIndex = 17
        Me.SavePNGBut.Text = "Save PNG"
        Me.SavePNGBut.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.SavePNGBut, "Save PNG picture")
        Me.SavePNGBut.UseVisualStyleBackColor = False
        '
        'LoadNMSXTILESprojectBut
        '
        Me.LoadNMSXTILESprojectBut.BackColor = System.Drawing.Color.Gainsboro
        Me.LoadNMSXTILESprojectBut.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoadNMSXTILESprojectBut.Image = Global.MSXTILESdevtool.My.Resources.Resources.folder
        Me.LoadNMSXTILESprojectBut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LoadNMSXTILESprojectBut.Location = New System.Drawing.Point(56, 128)
        Me.LoadNMSXTILESprojectBut.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.LoadNMSXTILESprojectBut.Name = "LoadNMSXTILESprojectBut"
        Me.LoadNMSXTILESprojectBut.Size = New System.Drawing.Size(118, 28)
        Me.LoadNMSXTILESprojectBut.TabIndex = 15
        Me.LoadNMSXTILESprojectBut.Text = "Load nMSX"
        Me.LoadNMSXTILESprojectBut.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.LoadNMSXTILESprojectBut, "Load nMSXtiles Project")
        Me.LoadNMSXTILESprojectBut.UseVisualStyleBackColor = False
        '
        'SaveSC2But
        '
        Me.SaveSC2But.BackColor = System.Drawing.Color.Gainsboro
        Me.SaveSC2But.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveSC2But.Image = Global.MSXTILESdevtool.My.Resources.Resources.save
        Me.SaveSC2But.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SaveSC2But.Location = New System.Drawing.Point(452, 158)
        Me.SaveSC2But.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SaveSC2But.Name = "SaveSC2But"
        Me.SaveSC2But.Size = New System.Drawing.Size(113, 28)
        Me.SaveSC2But.TabIndex = 8
        Me.SaveSC2But.Text = "Save SC2"
        Me.SaveSC2But.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.SaveSC2But, "Save SC2 picture")
        Me.SaveSC2But.UseVisualStyleBackColor = False
        '
        'LoadSC2But
        '
        Me.LoadSC2But.BackColor = System.Drawing.Color.Gainsboro
        Me.LoadSC2But.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoadSC2But.Image = Global.MSXTILESdevtool.My.Resources.Resources.folder
        Me.LoadSC2But.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LoadSC2But.Location = New System.Drawing.Point(56, 158)
        Me.LoadSC2But.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.LoadSC2But.Name = "LoadSC2But"
        Me.LoadSC2But.Size = New System.Drawing.Size(118, 28)
        Me.LoadSC2But.TabIndex = 13
        Me.LoadSC2But.Text = "Load SC2"
        Me.LoadSC2But.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.LoadSC2But, "Load SC2 picture")
        Me.LoadSC2But.UseVisualStyleBackColor = False
        '
        'TabImageList
        '
        Me.TabImageList.ImageStream = CType(resources.GetObject("TabImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.TabImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.TabImageList.Images.SetKeyName(0, "tab_buttom.png")
        Me.TabImageList.Images.SetKeyName(1, "tab_buttom_over.png")
        Me.TabImageList.Images.SetKeyName(2, "tab_buttom_select.png")
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(622, 212)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(19, 13)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "Y:"
        '
        'PosyTextB
        '
        Me.PosyTextB.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PosyTextB.Location = New System.Drawing.Point(640, 209)
        Me.PosyTextB.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PosyTextB.MaxLength = 7
        Me.PosyTextB.Name = "PosyTextB"
        Me.PosyTextB.ReadOnly = True
        Me.PosyTextB.Size = New System.Drawing.Size(30, 21)
        Me.PosyTextB.TabIndex = 29
        Me.PosyTextB.Text = "0"
        Me.PosyTextB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(680, 212)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(45, 13)
        Me.Label15.TabIndex = 30
        Me.Label15.Text = "VRAM:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ProjectNameTextBox)
        Me.GroupBox1.Controls.Add(Me.ProjectDataButton)
        Me.GroupBox1.Location = New System.Drawing.Point(188, 62)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(251, 44)
        Me.GroupBox1.TabIndex = 37
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Project"
        '
        'ProjectNameTextBox
        '
        Me.ProjectNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ProjectNameTextBox.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProjectNameTextBox.Location = New System.Drawing.Point(11, 16)
        Me.ProjectNameTextBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ProjectNameTextBox.Name = "ProjectNameTextBox"
        Me.ProjectNameTextBox.ReadOnly = True
        Me.ProjectNameTextBox.Size = New System.Drawing.Size(187, 22)
        Me.ProjectNameTextBox.TabIndex = 34
        '
        'TabTilesetLabel
        '
        Me.TabTilesetLabel.ImageKey = "tab_buttom.png"
        Me.TabTilesetLabel.ImageList = Me.TabImageList
        Me.TabTilesetLabel.Location = New System.Drawing.Point(513, 37)
        Me.TabTilesetLabel.Name = "TabTilesetLabel"
        Me.TabTilesetLabel.Size = New System.Drawing.Size(60, 23)
        Me.TabTilesetLabel.TabIndex = 27
        Me.TabTilesetLabel.Text = "TileSet"
        Me.TabTilesetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabScrLabel
        '
        Me.TabScrLabel.ImageKey = "tab_buttom.png"
        Me.TabScrLabel.ImageList = Me.TabImageList
        Me.TabScrLabel.Location = New System.Drawing.Point(513, 12)
        Me.TabScrLabel.Name = "TabScrLabel"
        Me.TabScrLabel.Size = New System.Drawing.Size(60, 23)
        Me.TabScrLabel.TabIndex = 26
        Me.TabScrLabel.Text = "Screen"
        Me.TabScrLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.MSXTILESdevtool.My.Resources.Resources.MSXTILESdevtool_logo
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(380, 50)
        Me.PictureBox1.TabIndex = 16
        Me.PictureBox1.TabStop = False
        '
        'screen2
        '
        Me.screen2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.screen2.Location = New System.Drawing.Point(573, 10)
        Me.screen2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.screen2.MaximumSize = New System.Drawing.Size(260, 196)
        Me.screen2.MinimumSize = New System.Drawing.Size(260, 196)
        Me.screen2.Name = "screen2"
        Me.screen2.Size = New System.Drawing.Size(260, 196)
        Me.screen2.TabIndex = 12
        Me.screen2.VDPtype = mSXdevtools.MSXLibrary.MSXpalette.MSXVDP.TMS9918
        Me.screen2.VisibleTileSets = True
        '
        'MainScreen
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(848, 562)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.TileTextB)
        Me.Controls.Add(Me.PosxTextB)
        Me.Controls.Add(Me.PosyTextB)
        Me.Controls.Add(Me.vaddrTextB)
        Me.Controls.Add(Me.SaveSCProjectButton)
        Me.Controls.Add(Me.LoadSCProjectButton)
        Me.Controls.Add(Me.SavePrjButton)
        Me.Controls.Add(Me.SaveSC4But)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TabTilesetLabel)
        Me.Controls.Add(Me.TabScrLabel)
        Me.Controls.Add(Me.LoadPNGBut)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.SavePNGBut)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.LoadNMSXTILESprojectBut)
        Me.Controls.Add(Me.SaveSC2But)
        Me.Controls.Add(Me.LoadSC2But)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.screen2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MinimumSize = New System.Drawing.Size(864, 600)
        Me.Name = "MainScreen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MSX tiles Tools"
        Me.GroupBox4.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.AllBanksPanel.ResumeLayout(False)
        Me.AllBanksPanel.PerformLayout()
        Me.BanksTabcontrol.ResumeLayout(False)
        Me.TabB0.ResumeLayout(False)
        Me.TabB0.PerformLayout()
        Me.TabB1.ResumeLayout(False)
        Me.TabB1.PerformLayout()
        Me.TabB2.ResumeLayout(False)
        Me.TabB2.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents LoadScrBut As System.Windows.Forms.Button
    Friend WithEvents LoadScrText As System.Windows.Forms.TextBox
    Friend WithEvents SaveBinBut As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents SaveTxtScrBut As System.Windows.Forms.Button
    Friend WithEvents LoadTilText As System.Windows.Forms.TextBox
    Friend WithEvents LoadTilesBut As System.Windows.Forms.Button
    Friend WithEvents SaveTilesCBut As System.Windows.Forms.Button
    Friend WithEvents SaveTilesBinBut As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TilesClearBut As System.Windows.Forms.Button
    Friend WithEvents TilesOrderBut As System.Windows.Forms.Button
    Friend WithEvents screen2 As TMS9918
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Tiles_TxtOutput As System.Windows.Forms.TextBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents SaveSC2But As System.Windows.Forms.Button
    Friend WithEvents Tileset_TxtOutput As System.Windows.Forms.TextBox
    Friend WithEvents LoadSC2But As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Map_FieldName As System.Windows.Forms.TextBox
    Friend WithEvents GetScrButton As System.Windows.Forms.Button
    Friend WithEvents Bank1CheckB As System.Windows.Forms.CheckBox
    Friend WithEvents B0Check As System.Windows.Forms.CheckBox
    Friend WithEvents Bank2CheckB As System.Windows.Forms.CheckBox
    Friend WithEvents TilesetGenButton As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Tileset_FieldName As System.Windows.Forms.TextBox
    Friend WithEvents B0EndTile As System.Windows.Forms.TextBox
    Friend WithEvents B0IniTile As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LoadNMSXTILESprojectBut As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ChangeButton As System.Windows.Forms.Button
    Friend WithEvents SavePNGBut As System.Windows.Forms.Button
    Friend WithEvents Tileset_CodeOutComboB As System.Windows.Forms.ComboBox
    Friend WithEvents Map_CodeOutComboB As System.Windows.Forms.ComboBox
    Friend WithEvents PosxTextB As System.Windows.Forms.TextBox
    Friend WithEvents TileTextB As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents BlackitizerBut As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents startTileY As System.Windows.Forms.TextBox
    Friend WithEvents startTileX As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents endTileY As System.Windows.Forms.TextBox
    Friend WithEvents endTileX As System.Windows.Forms.TextBox
    Friend WithEvents Map_areaResetButton As System.Windows.Forms.Button
    Friend WithEvents vaddrTextB As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents LoadPNGBut As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Tileset_SizeLineComboB As System.Windows.Forms.ComboBox
    Friend WithEvents Map_SizeLineComboB As System.Windows.Forms.ComboBox
    Friend WithEvents TabScrLabel As System.Windows.Forms.Label
    Friend WithEvents TabImageList As System.Windows.Forms.ImageList
    Friend WithEvents TabTilesetLabel As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents PosyTextB As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents BanksTabcontrol As System.Windows.Forms.TabControl
    Friend WithEvents TabB0 As System.Windows.Forms.TabPage
    Friend WithEvents TabB1 As System.Windows.Forms.TabPage
    Friend WithEvents TabB2 As System.Windows.Forms.TabPage
    Friend WithEvents B0color As System.Windows.Forms.CheckBox
    Friend WithEvents B0pattern As System.Windows.Forms.CheckBox
    Friend WithEvents B1color As System.Windows.Forms.CheckBox
    Friend WithEvents B1Pattern As System.Windows.Forms.CheckBox
    Friend WithEvents B1IniTile As System.Windows.Forms.TextBox
    Friend WithEvents B1EndTile As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents B2color As System.Windows.Forms.CheckBox
    Friend WithEvents B2Pattern As System.Windows.Forms.CheckBox
    Friend WithEvents B2IniTile As System.Windows.Forms.TextBox
    Friend WithEvents B2EndTile As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GetPaletteButton As System.Windows.Forms.Button
    Friend WithEvents SaveTxtPalBut As System.Windows.Forms.Button
    Friend WithEvents LoadPaletteButton As System.Windows.Forms.Button
    Friend WithEvents PaleteNameTextB As System.Windows.Forms.TextBox
    Friend WithEvents Palette_TxtOutput As System.Windows.Forms.TextBox
    Friend WithEvents EditPaleteButton As System.Windows.Forms.Button
    Friend WithEvents SavePaletteButton As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Map_compressionScrCB As System.Windows.Forms.ComboBox
    Friend WithEvents SaveSC4But As System.Windows.Forms.Button
    Friend WithEvents Palette_SizeLineComboB As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Palette_CodeOutComboB As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Palette_FieldName As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Palette_NumSysCombo As System.Windows.Forms.ComboBox
    Friend WithEvents SavePrjButton As System.Windows.Forms.Button
    Friend WithEvents OptimizeButton As System.Windows.Forms.Button
    Friend WithEvents Compression_PB0_CBox As System.Windows.Forms.ComboBox
    Friend WithEvents Compression_CB0_CBox As System.Windows.Forms.ComboBox
    Friend WithEvents Compression_PB1_CBox As System.Windows.Forms.ComboBox
    Friend WithEvents Compression_CB1_CBox As System.Windows.Forms.ComboBox
    Friend WithEvents Compression_CB2_CBox As System.Windows.Forms.ComboBox
    Friend WithEvents Compression_PB2_CBox As System.Windows.Forms.ComboBox
    Friend WithEvents InvertButton As System.Windows.Forms.Button
    Friend WithEvents LoadSCProjectButton As System.Windows.Forms.Button
    Friend WithEvents SaveSCProjectButton As System.Windows.Forms.Button
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Map_NumSysComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Tileset_NumSysComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents AllBanksCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents BasicConfigButton As System.Windows.Forms.Button
    Friend WithEvents BasicConfigButton2 As System.Windows.Forms.Button
    Friend WithEvents BasicConfigButton3 As System.Windows.Forms.Button
    Friend WithEvents AllBanksPanel As System.Windows.Forms.Panel
    Friend WithEvents CompressCol_ALL_CBox As System.Windows.Forms.ComboBox
    Friend WithEvents CompressPat_ALL_CBox As System.Windows.Forms.ComboBox
    Friend WithEvents ALLcolor As System.Windows.Forms.CheckBox
    Friend WithEvents ALLpattern As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ProjectNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ProjectDataButton As System.Windows.Forms.Button
    Friend WithEvents LoadTilesetButton As System.Windows.Forms.Button
    Friend WithEvents LoadMapButton As System.Windows.Forms.Button
    Friend WithEvents SaveMapButton As System.Windows.Forms.Button
    Friend WithEvents SaveTilesetsButton As System.Windows.Forms.Button

End Class
