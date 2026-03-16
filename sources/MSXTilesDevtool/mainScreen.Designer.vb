<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainScreen
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainScreen))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.RangeResetButton = New System.Windows.Forms.Button()
        Me.RangeStartTextBox = New System.Windows.Forms.TextBox()
        Me.RangeEndTextBox = New System.Windows.Forms.TextBox()
        Me.TilesetDataComboBox = New System.Windows.Forms.ComboBox()
        Me.GivemeTheCodeButton = New mSXdevtools.GUI.Controls.piXelST_Button()
        Me.SaveBinaryButton = New mSXdevtools.GUI.Controls.piXelST_Button()
        Me.SaveSourceButton = New mSXdevtools.GUI.Controls.piXelST_Button()
        Me.CopyAllButton = New mSXdevtools.GUI.Controls.piXelST_Button()
        Me.Map_areaResetButton = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.NewProjectButton = New System.Windows.Forms.ToolStripButton()
        Me.LoadProjectButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ProjectNameTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.ProjectInfoButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveProjectButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveasButton = New System.Windows.Forms.ToolStripButton()
        Me.Save_nMSXProjectButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveMSXBASICGButton1 = New System.Windows.Forms.ToolStripButton()
        Me.SaveBitmapButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ConfigButton = New System.Windows.Forms.ToolStripButton()
        Me.Help_Button = New System.Windows.Forms.ToolStripButton()
        Me.AboutButton = New System.Windows.Forms.ToolStripButton()
        Me.ScreenContainer_Panel = New System.Windows.Forms.Panel()
        Me.PaintToolStrip = New System.Windows.Forms.ToolStrip()
        Me.OptimizeButton = New System.Windows.Forms.ToolStripButton()
        Me.TilesOrderButton = New System.Windows.Forms.ToolStripButton()
        Me.FillMapButton = New System.Windows.Forms.ToolStripButton()
        Me.SwitchButton = New System.Windows.Forms.ToolStripButton()
        Me.SwapButton = New System.Windows.Forms.ToolStripButton()
        Me.SelectAreaButton = New System.Windows.Forms.ToolStripButton()
        Me.EditPaleteButton = New System.Windows.Forms.ToolStripButton()
        Me.ClearButton = New System.Windows.Forms.ToolStripButton()
        Me.UndoButton = New System.Windows.Forms.ToolStripButton()
        Me.BorderColorButton = New System.Windows.Forms.ToolStripButton()
        Me.V_Rules_PictureBox = New System.Windows.Forms.PictureBox()
        Me.ScreenStatusStrip = New System.Windows.Forms.StatusStrip()
        Me.CursorXLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PosX_Label = New System.Windows.Forms.ToolStripStatusLabel()
        Me.CursorYLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PosY_Label = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Col_Label = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ColumnLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LineLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Colors_Label = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ColorInkLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ColorBGLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Bloq_Label = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BloqValue_Label = New System.Windows.Forms.ToolStripStatusLabel()
        Me.H_Rules_PictureBox = New System.Windows.Forms.PictureBox()
        Me.TMS9918Aviewer = New mSXdevtools.GUI.TMS9918A.TMS9918A()
        Me.OutputText = New System.Windows.Forms.TextBox()
        Me.DataTypeInput = New mSXdevtools.GUI.Controls.DataTypeInputControl()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.AreaEndX_TextBox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.AreaStartY_TextBox = New System.Windows.Forms.TextBox()
        Me.AreaStartX_TextBox = New System.Windows.Forms.TextBox()
        Me.AreaEndY_TextBox = New System.Windows.Forms.TextBox()
        Me.RangeLabel = New System.Windows.Forms.Label()
        Me.RangeToLabel = New System.Windows.Forms.Label()
        Me.SelectDataLabel = New System.Windows.Forms.Label()
        Me.SelectDataComboBox = New System.Windows.Forms.ComboBox()
        Me.TilesetDataLabel = New System.Windows.Forms.Label()
        Me.ZoomLabel = New System.Windows.Forms.Label()
        Me.Tilenumber_TextBox = New System.Windows.Forms.TextBox()
        Me.ZoomPanel = New mSXdevtools.GUI.Controls.piXelST_GroupBox()
        Me.TileColorsPictureBox = New System.Windows.Forms.PictureBox()
        Me.TileViewerPictureBox = New System.Windows.Forms.PictureBox()
        Me.AreaPanel = New mSXdevtools.GUI.Controls.piXelST_GroupBox()
        Me.RangePanel = New mSXdevtools.GUI.Controls.piXelST_GroupBox()
        Me.DataPanel = New mSXdevtools.GUI.Controls.piXelST_GroupBox()
        Me.HorizontalTab = New mSXdevtools.GUI.Controls.piXelST_HorizontalTab()
        Me.BottonsPanel = New System.Windows.Forms.Panel()
        Me.ToolStrip1.SuspendLayout()
        Me.ScreenContainer_Panel.SuspendLayout()
        Me.PaintToolStrip.SuspendLayout()
        CType(Me.V_Rules_PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ScreenStatusStrip.SuspendLayout()
        CType(Me.H_Rules_PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ZoomPanel.SuspendLayout()
        CType(Me.TileColorsPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TileViewerPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AreaPanel.SuspendLayout()
        Me.RangePanel.SuspendLayout()
        Me.DataPanel.SuspendLayout()
        Me.BottonsPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'RangeResetButton
        '
        Me.RangeResetButton.BackColor = System.Drawing.Color.Gainsboro
        Me.RangeResetButton.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RangeResetButton.Location = New System.Drawing.Point(202, 20)
        Me.RangeResetButton.Name = "RangeResetButton"
        Me.RangeResetButton.Size = New System.Drawing.Size(36, 24)
        Me.RangeResetButton.TabIndex = 254
        Me.RangeResetButton.Text = "All"
        Me.ToolTip1.SetToolTip(Me.RangeResetButton, "Default Range values")
        Me.RangeResetButton.UseVisualStyleBackColor = False
        '
        'RangeStartTextBox
        '
        Me.RangeStartTextBox.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RangeStartTextBox.Location = New System.Drawing.Point(89, 21)
        Me.RangeStartTextBox.MaxLength = 3
        Me.RangeStartTextBox.Name = "RangeStartTextBox"
        Me.RangeStartTextBox.Size = New System.Drawing.Size(33, 22)
        Me.RangeStartTextBox.TabIndex = 251
        Me.RangeStartTextBox.Text = "0"
        Me.RangeStartTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.RangeStartTextBox, "Start tile number.")
        '
        'RangeEndTextBox
        '
        Me.RangeEndTextBox.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RangeEndTextBox.Location = New System.Drawing.Point(167, 21)
        Me.RangeEndTextBox.MaxLength = 3
        Me.RangeEndTextBox.Name = "RangeEndTextBox"
        Me.RangeEndTextBox.Size = New System.Drawing.Size(33, 22)
        Me.RangeEndTextBox.TabIndex = 252
        Me.RangeEndTextBox.Text = "255"
        Me.RangeEndTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.RangeEndTextBox, "End tile number.")
        '
        'TilesetDataComboBox
        '
        Me.TilesetDataComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TilesetDataComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.TilesetDataComboBox.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TilesetDataComboBox.FormattingEnabled = True
        Me.TilesetDataComboBox.Items.AddRange(New Object() {"Pattern", "Color", "Pattern + Color"})
        Me.TilesetDataComboBox.Location = New System.Drawing.Point(89, 49)
        Me.TilesetDataComboBox.Name = "TilesetDataComboBox"
        Me.TilesetDataComboBox.Size = New System.Drawing.Size(153, 22)
        Me.TilesetDataComboBox.TabIndex = 259
        Me.ToolTip1.SetToolTip(Me.TilesetDataComboBox, "Type of data to generate.")
        '
        'GivemeTheCodeButton
        '
        Me.GivemeTheCodeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GivemeTheCodeButton.BackColor = System.Drawing.Color.Silver
        Me.GivemeTheCodeButton.ButtonColor = System.Drawing.Color.Gray
        Me.GivemeTheCodeButton.ButtonType = mSXdevtools.GUI.Controls.piXelST_Button.Button_TYPES.Action
        Me.GivemeTheCodeButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.GivemeTheCodeButton.FlatAppearance.BorderSize = 0
        Me.GivemeTheCodeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GivemeTheCodeButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.GivemeTheCodeButton.Location = New System.Drawing.Point(582, 589)
        Me.GivemeTheCodeButton.Name = "GivemeTheCodeButton"
        Me.GivemeTheCodeButton.Size = New System.Drawing.Size(262, 29)
        Me.GivemeTheCodeButton.TabIndex = 281
        Me.GivemeTheCodeButton.Text = "Generate Source"
        Me.ToolTip1.SetToolTip(Me.GivemeTheCodeButton, "Press this button, if you want all the little blue elves " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to get to work and wri" &
        "te the data in the output box.")
        Me.GivemeTheCodeButton.UseVisualStyleBackColor = False
        '
        'SaveBinaryButton
        '
        Me.SaveBinaryButton.ButtonColor = System.Drawing.Color.Gray
        Me.SaveBinaryButton.ButtonType = mSXdevtools.GUI.Controls.piXelST_Button.Button_TYPES.Save
        Me.SaveBinaryButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SaveBinaryButton.Dock = System.Windows.Forms.DockStyle.Left
        Me.SaveBinaryButton.ForeColor = System.Drawing.Color.Black
        Me.SaveBinaryButton.Image = CType(resources.GetObject("SaveBinaryButton.Image"), System.Drawing.Image)
        Me.SaveBinaryButton.Location = New System.Drawing.Point(368, 4)
        Me.SaveBinaryButton.Name = "SaveBinaryButton"
        Me.SaveBinaryButton.Padding = New System.Windows.Forms.Padding(4)
        Me.SaveBinaryButton.Size = New System.Drawing.Size(208, 36)
        Me.SaveBinaryButton.TabIndex = 129
        Me.SaveBinaryButton.TabStop = False
        Me.SaveBinaryButton.Text = "Save Binary"
        Me.ToolTip1.SetToolTip(Me.SaveBinaryButton, "Save output to Binary file")
        Me.SaveBinaryButton.UseVisualStyleBackColor = False
        '
        'SaveSourceButton
        '
        Me.SaveSourceButton.ButtonColor = System.Drawing.Color.Gray
        Me.SaveSourceButton.ButtonType = mSXdevtools.GUI.Controls.piXelST_Button.Button_TYPES.Save
        Me.SaveSourceButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SaveSourceButton.Dock = System.Windows.Forms.DockStyle.Left
        Me.SaveSourceButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveSourceButton.ForeColor = System.Drawing.Color.Black
        Me.SaveSourceButton.Image = CType(resources.GetObject("SaveSourceButton.Image"), System.Drawing.Image)
        Me.SaveSourceButton.Location = New System.Drawing.Point(161, 4)
        Me.SaveSourceButton.Name = "SaveSourceButton"
        Me.SaveSourceButton.Padding = New System.Windows.Forms.Padding(4)
        Me.SaveSourceButton.Size = New System.Drawing.Size(207, 36)
        Me.SaveSourceButton.TabIndex = 128
        Me.SaveSourceButton.TabStop = False
        Me.SaveSourceButton.Text = "Save Source"
        Me.ToolTip1.SetToolTip(Me.SaveSourceButton, "Save output to TXT file")
        Me.SaveSourceButton.UseVisualStyleBackColor = False
        '
        'CopyAllButton
        '
        Me.CopyAllButton.ButtonColor = System.Drawing.Color.Gray
        Me.CopyAllButton.ButtonType = mSXdevtools.GUI.Controls.piXelST_Button.Button_TYPES.Confirmation
        Me.CopyAllButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CopyAllButton.Dock = System.Windows.Forms.DockStyle.Left
        Me.CopyAllButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.CopyAllButton.Image = CType(resources.GetObject("CopyAllButton.Image"), System.Drawing.Image)
        Me.CopyAllButton.Location = New System.Drawing.Point(4, 4)
        Me.CopyAllButton.Name = "CopyAllButton"
        Me.CopyAllButton.Padding = New System.Windows.Forms.Padding(4)
        Me.CopyAllButton.Size = New System.Drawing.Size(157, 36)
        Me.CopyAllButton.TabIndex = 127
        Me.CopyAllButton.TabStop = False
        Me.CopyAllButton.Text = "Copy All"
        Me.ToolTip1.SetToolTip(Me.CopyAllButton, "Copy output source code to clipboard")
        Me.CopyAllButton.UseVisualStyleBackColor = False
        '
        'Map_areaResetButton
        '
        Me.Map_areaResetButton.BackColor = System.Drawing.Color.Gainsboro
        Me.Map_areaResetButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.auto_16x16
        Me.Map_areaResetButton.Location = New System.Drawing.Point(203, 47)
        Me.Map_areaResetButton.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Map_areaResetButton.Name = "Map_areaResetButton"
        Me.Map_areaResetButton.Size = New System.Drawing.Size(24, 24)
        Me.Map_areaResetButton.TabIndex = 114
        Me.ToolTip1.SetToolTip(Me.Map_areaResetButton, "Initialize values.")
        Me.Map_areaResetButton.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.Gainsboro
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewProjectButton, Me.LoadProjectButton, Me.ToolStripSeparator1, Me.ProjectNameTextBox, Me.ProjectInfoButton, Me.ToolStripSeparator2, Me.SaveProjectButton, Me.SaveasButton, Me.Save_nMSXProjectButton, Me.SaveMSXBASICGButton1, Me.SaveBitmapButton1, Me.ToolStripSeparator3, Me.ConfigButton, Me.Help_Button, Me.AboutButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(854, 39)
        Me.ToolStrip1.TabIndex = 38
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'NewProjectButton
        '
        Me.NewProjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NewProjectButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.ico_new_32px
        Me.NewProjectButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.NewProjectButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewProjectButton.Name = "NewProjectButton"
        Me.NewProjectButton.Size = New System.Drawing.Size(36, 36)
        Me.NewProjectButton.ToolTipText = "New Project"
        '
        'LoadProjectButton
        '
        Me.LoadProjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.LoadProjectButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.ico_load_32px
        Me.LoadProjectButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.LoadProjectButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LoadProjectButton.Name = "LoadProjectButton"
        Me.LoadProjectButton.Size = New System.Drawing.Size(36, 36)
        Me.LoadProjectButton.Text = "LoadProject"
        Me.LoadProjectButton.ToolTipText = "Load Project"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'ProjectNameTextBox
        '
        Me.ProjectNameTextBox.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ProjectNameTextBox.Name = "ProjectNameTextBox"
        Me.ProjectNameTextBox.ReadOnly = True
        Me.ProjectNameTextBox.Size = New System.Drawing.Size(220, 39)
        Me.ProjectNameTextBox.ToolTipText = "Project Name"
        '
        'ProjectInfoButton
        '
        Me.ProjectInfoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ProjectInfoButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.ico_config_prj_32px
        Me.ProjectInfoButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ProjectInfoButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ProjectInfoButton.Name = "ProjectInfoButton"
        Me.ProjectInfoButton.Size = New System.Drawing.Size(36, 36)
        Me.ProjectInfoButton.ToolTipText = "Edit Project Info"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'SaveProjectButton
        '
        Me.SaveProjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveProjectButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.ico_save_32px
        Me.SaveProjectButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SaveProjectButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveProjectButton.Name = "SaveProjectButton"
        Me.SaveProjectButton.Size = New System.Drawing.Size(36, 36)
        Me.SaveProjectButton.Text = "ToolStripButton1"
        Me.SaveProjectButton.ToolTipText = "Save Project"
        '
        'SaveasButton
        '
        Me.SaveasButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveasButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.ico_save_as_32px
        Me.SaveasButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SaveasButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveasButton.Name = "SaveasButton"
        Me.SaveasButton.Size = New System.Drawing.Size(36, 36)
        Me.SaveasButton.Text = "SaveasButton"
        Me.SaveasButton.ToolTipText = "Save As"
        '
        'Save_nMSXProjectButton
        '
        Me.Save_nMSXProjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Save_nMSXProjectButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.ico_save_NMsx_32px
        Me.Save_nMSXProjectButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Save_nMSXProjectButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Save_nMSXProjectButton.Name = "Save_nMSXProjectButton"
        Me.Save_nMSXProjectButton.Size = New System.Drawing.Size(36, 36)
        Me.Save_nMSXProjectButton.Text = "ToolStripButton1"
        Me.Save_nMSXProjectButton.ToolTipText = "Save nMSXtiles Project"
        '
        'SaveMSXBASICGButton1
        '
        Me.SaveMSXBASICGButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveMSXBASICGButton1.Image = Global.MSXTILESdevtool.My.Resources.Resources.saveSC_x24
        Me.SaveMSXBASICGButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveMSXBASICGButton1.Name = "SaveMSXBASICGButton1"
        Me.SaveMSXBASICGButton1.Size = New System.Drawing.Size(36, 36)
        Me.SaveMSXBASICGButton1.ToolTipText = "Save MSX BASIC Binary Graphics (SC2)"
        '
        'SaveBitmapButton1
        '
        Me.SaveBitmapButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveBitmapButton1.Image = Global.MSXTILESdevtool.My.Resources.Resources.ico_save_bitmap_32px
        Me.SaveBitmapButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SaveBitmapButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveBitmapButton1.Name = "SaveBitmapButton1"
        Me.SaveBitmapButton1.Size = New System.Drawing.Size(36, 36)
        Me.SaveBitmapButton1.ToolTipText = "Save bitmap picture"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 39)
        '
        'ConfigButton
        '
        Me.ConfigButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ConfigButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.ico_config_app_32px
        Me.ConfigButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ConfigButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ConfigButton.Name = "ConfigButton"
        Me.ConfigButton.Size = New System.Drawing.Size(36, 36)
        Me.ConfigButton.ToolTipText = "Config devtools"
        '
        'Help_Button
        '
        Me.Help_Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Help_Button.Enabled = False
        Me.Help_Button.Image = Global.MSXTILESdevtool.My.Resources.Resources.ico_help_32px
        Me.Help_Button.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Help_Button.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Help_Button.Name = "Help_Button"
        Me.Help_Button.Size = New System.Drawing.Size(36, 36)
        Me.Help_Button.ToolTipText = "Help!"
        '
        'AboutButton
        '
        Me.AboutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AboutButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.ico_about_32px
        Me.AboutButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AboutButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AboutButton.Name = "AboutButton"
        Me.AboutButton.Size = New System.Drawing.Size(36, 36)
        Me.AboutButton.Text = "ToolStripButton1"
        Me.AboutButton.ToolTipText = "About this devtool"
        '
        'ScreenContainer_Panel
        '
        Me.ScreenContainer_Panel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ScreenContainer_Panel.Controls.Add(Me.PaintToolStrip)
        Me.ScreenContainer_Panel.Controls.Add(Me.V_Rules_PictureBox)
        Me.ScreenContainer_Panel.Controls.Add(Me.ScreenStatusStrip)
        Me.ScreenContainer_Panel.Controls.Add(Me.H_Rules_PictureBox)
        Me.ScreenContainer_Panel.Controls.Add(Me.TMS9918Aviewer)
        Me.ScreenContainer_Panel.Location = New System.Drawing.Point(0, 73)
        Me.ScreenContainer_Panel.Margin = New System.Windows.Forms.Padding(0)
        Me.ScreenContainer_Panel.Name = "ScreenContainer_Panel"
        Me.ScreenContainer_Panel.Size = New System.Drawing.Size(567, 422)
        Me.ScreenContainer_Panel.TabIndex = 117
        '
        'PaintToolStrip
        '
        Me.PaintToolStrip.AutoSize = False
        Me.PaintToolStrip.BackColor = System.Drawing.Color.Gainsboro
        Me.PaintToolStrip.Dock = System.Windows.Forms.DockStyle.Left
        Me.PaintToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.PaintToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptimizeButton, Me.TilesOrderButton, Me.FillMapButton, Me.SwitchButton, Me.SwapButton, Me.SelectAreaButton, Me.EditPaleteButton, Me.ClearButton, Me.UndoButton, Me.BorderColorButton})
        Me.PaintToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.PaintToolStrip.Name = "PaintToolStrip"
        Me.PaintToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.PaintToolStrip.Size = New System.Drawing.Size(38, 400)
        Me.PaintToolStrip.TabIndex = 274
        Me.PaintToolStrip.Text = "ToolStrip1"
        '
        'OptimizeButton
        '
        Me.OptimizeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OptimizeButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.ico_reload_32px
        Me.OptimizeButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.OptimizeButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OptimizeButton.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.OptimizeButton.Name = "OptimizeButton"
        Me.OptimizeButton.Size = New System.Drawing.Size(36, 36)
        Me.OptimizeButton.Text = "ToolStripButton3"
        Me.OptimizeButton.ToolTipText = "Optimize Tiles and Map Tool"
        '
        'TilesOrderButton
        '
        Me.TilesOrderButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TilesOrderButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.ico_sort_32px
        Me.TilesOrderButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TilesOrderButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TilesOrderButton.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.TilesOrderButton.Name = "TilesOrderButton"
        Me.TilesOrderButton.Size = New System.Drawing.Size(36, 36)
        Me.TilesOrderButton.ToolTipText = "Generates an ordered map"
        '
        'FillMapButton
        '
        Me.FillMapButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.FillMapButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.ico_paint_32px
        Me.FillMapButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.FillMapButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FillMapButton.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.FillMapButton.Name = "FillMapButton"
        Me.FillMapButton.Size = New System.Drawing.Size(36, 36)
        Me.FillMapButton.Text = "ToolStripButton1"
        Me.FillMapButton.ToolTipText = "Fill an area with the same tile"
        '
        'SwitchButton
        '
        Me.SwitchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SwitchButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.ico_copy_32px
        Me.SwitchButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SwitchButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SwitchButton.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.SwitchButton.Name = "SwitchButton"
        Me.SwitchButton.Size = New System.Drawing.Size(36, 36)
        Me.SwitchButton.Text = "ToolStripButton1"
        Me.SwitchButton.ToolTipText = "Write text"
        '
        'SwapButton
        '
        Me.SwapButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SwapButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.ico_exchange_32px
        Me.SwapButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SwapButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SwapButton.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.SwapButton.Name = "SwapButton"
        Me.SwapButton.Size = New System.Drawing.Size(36, 36)
        '
        'SelectAreaButton
        '
        Me.SelectAreaButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SelectAreaButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.ico_select_32px
        Me.SelectAreaButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SelectAreaButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SelectAreaButton.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.SelectAreaButton.Name = "SelectAreaButton"
        Me.SelectAreaButton.Size = New System.Drawing.Size(36, 36)
        Me.SelectAreaButton.Text = "ToolStripButton3"
        Me.SelectAreaButton.ToolTipText = "Select area"
        '
        'EditPaleteButton
        '
        Me.EditPaleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.EditPaleteButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.ico_palette_32px
        Me.EditPaleteButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.EditPaleteButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EditPaleteButton.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.EditPaleteButton.Name = "EditPaleteButton"
        Me.EditPaleteButton.Size = New System.Drawing.Size(36, 36)
        Me.EditPaleteButton.ToolTipText = "Draw the clipboard area"
        '
        'ClearButton
        '
        Me.ClearButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ClearButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.ico_clear_32px
        Me.ClearButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ClearButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ClearButton.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.ClearButton.Name = "ClearButton"
        Me.ClearButton.Size = New System.Drawing.Size(36, 36)
        Me.ClearButton.Text = "ToolStripButton4"
        Me.ClearButton.ToolTipText = "Clear Map"
        '
        'UndoButton
        '
        Me.UndoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.UndoButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.ico_undo_32px
        Me.UndoButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.UndoButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.UndoButton.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.UndoButton.Name = "UndoButton"
        Me.UndoButton.Size = New System.Drawing.Size(36, 36)
        Me.UndoButton.Text = "ToolStripButton3"
        Me.UndoButton.ToolTipText = "Undo/Redo"
        '
        'BorderColorButton
        '
        Me.BorderColorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BorderColorButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.screen02_24px
        Me.BorderColorButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BorderColorButton.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.BorderColorButton.Name = "BorderColorButton"
        Me.BorderColorButton.Size = New System.Drawing.Size(36, 28)
        Me.BorderColorButton.Text = "ToolStripButton1"
        Me.BorderColorButton.ToolTipText = "Select screen border color." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "It is used to display the color 0."
        Me.BorderColorButton.Visible = False
        '
        'V_Rules_PictureBox
        '
        Me.V_Rules_PictureBox.BackColor = System.Drawing.Color.Gainsboro
        Me.V_Rules_PictureBox.BackgroundImage = Global.MSXTILESdevtool.My.Resources.Resources.V_ruler_16p
        Me.V_Rules_PictureBox.Location = New System.Drawing.Point(39, 15)
        Me.V_Rules_PictureBox.Name = "V_Rules_PictureBox"
        Me.V_Rules_PictureBox.Size = New System.Drawing.Size(16, 384)
        Me.V_Rules_PictureBox.TabIndex = 273
        Me.V_Rules_PictureBox.TabStop = False
        '
        'ScreenStatusStrip
        '
        Me.ScreenStatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CursorXLabel, Me.PosX_Label, Me.CursorYLabel, Me.PosY_Label, Me.Col_Label, Me.ColumnLabel, Me.ToolStripStatusLabel1, Me.LineLabel, Me.Colors_Label, Me.ColorInkLabel, Me.ColorBGLabel, Me.Bloq_Label, Me.BloqValue_Label})
        Me.ScreenStatusStrip.Location = New System.Drawing.Point(0, 400)
        Me.ScreenStatusStrip.Name = "ScreenStatusStrip"
        Me.ScreenStatusStrip.Size = New System.Drawing.Size(567, 22)
        Me.ScreenStatusStrip.TabIndex = 0
        Me.ScreenStatusStrip.Text = "StatusStrip1"
        '
        'CursorXLabel
        '
        Me.CursorXLabel.AutoSize = False
        Me.CursorXLabel.BackColor = System.Drawing.Color.Transparent
        Me.CursorXLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CursorXLabel.ForeColor = System.Drawing.Color.Navy
        Me.CursorXLabel.Name = "CursorXLabel"
        Me.CursorXLabel.Size = New System.Drawing.Size(66, 17)
        Me.CursorXLabel.Text = "X:"
        Me.CursorXLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PosX_Label
        '
        Me.PosX_Label.AutoSize = False
        Me.PosX_Label.BackColor = System.Drawing.Color.Gainsboro
        Me.PosX_Label.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PosX_Label.ForeColor = System.Drawing.Color.Black
        Me.PosX_Label.Name = "PosX_Label"
        Me.PosX_Label.Size = New System.Drawing.Size(33, 17)
        Me.PosX_Label.Text = "000"
        Me.PosX_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CursorYLabel
        '
        Me.CursorYLabel.AutoSize = False
        Me.CursorYLabel.BackColor = System.Drawing.Color.Transparent
        Me.CursorYLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CursorYLabel.ForeColor = System.Drawing.Color.Navy
        Me.CursorYLabel.Name = "CursorYLabel"
        Me.CursorYLabel.Size = New System.Drawing.Size(40, 17)
        Me.CursorYLabel.Text = "Y:"
        Me.CursorYLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PosY_Label
        '
        Me.PosY_Label.ActiveLinkColor = System.Drawing.Color.Red
        Me.PosY_Label.AutoSize = False
        Me.PosY_Label.BackColor = System.Drawing.Color.Gainsboro
        Me.PosY_Label.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PosY_Label.ForeColor = System.Drawing.Color.Black
        Me.PosY_Label.Name = "PosY_Label"
        Me.PosY_Label.Size = New System.Drawing.Size(33, 17)
        Me.PosY_Label.Text = "000"
        Me.PosY_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Col_Label
        '
        Me.Col_Label.AutoSize = False
        Me.Col_Label.BackColor = System.Drawing.Color.Transparent
        Me.Col_Label.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Col_Label.ForeColor = System.Drawing.Color.Navy
        Me.Col_Label.Name = "Col_Label"
        Me.Col_Label.Size = New System.Drawing.Size(50, 17)
        Me.Col_Label.Text = "Col:"
        Me.Col_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Col_Label.ToolTipText = "Column"
        '
        'ColumnLabel
        '
        Me.ColumnLabel.AutoSize = False
        Me.ColumnLabel.BackColor = System.Drawing.Color.Gainsboro
        Me.ColumnLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ColumnLabel.ForeColor = System.Drawing.Color.Black
        Me.ColumnLabel.Name = "ColumnLabel"
        Me.ColumnLabel.Size = New System.Drawing.Size(30, 17)
        Me.ColumnLabel.Text = "00"
        Me.ColumnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Navy
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(50, 17)
        Me.ToolStripStatusLabel1.Text = "Line:"
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripStatusLabel1.ToolTipText = "Column"
        '
        'LineLabel
        '
        Me.LineLabel.AutoSize = False
        Me.LineLabel.BackColor = System.Drawing.Color.Gainsboro
        Me.LineLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LineLabel.ForeColor = System.Drawing.Color.Black
        Me.LineLabel.Name = "LineLabel"
        Me.LineLabel.Size = New System.Drawing.Size(30, 17)
        Me.LineLabel.Text = "00"
        Me.LineLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LineLabel.ToolTipText = "Line"
        '
        'Colors_Label
        '
        Me.Colors_Label.AutoSize = False
        Me.Colors_Label.BackColor = System.Drawing.Color.Transparent
        Me.Colors_Label.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Colors_Label.ForeColor = System.Drawing.Color.Navy
        Me.Colors_Label.Name = "Colors_Label"
        Me.Colors_Label.Size = New System.Drawing.Size(64, 17)
        Me.Colors_Label.Text = "Colors:"
        Me.Colors_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Colors_Label.ToolTipText = "Colors"
        '
        'ColorInkLabel
        '
        Me.ColorInkLabel.AutoSize = False
        Me.ColorInkLabel.BackColor = System.Drawing.Color.Gainsboro
        Me.ColorInkLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ColorInkLabel.ForeColor = System.Drawing.Color.Black
        Me.ColorInkLabel.Name = "ColorInkLabel"
        Me.ColorInkLabel.Size = New System.Drawing.Size(30, 17)
        Me.ColorInkLabel.Text = "00"
        Me.ColorInkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ColorInkLabel.ToolTipText = "Ink color"
        '
        'ColorBGLabel
        '
        Me.ColorBGLabel.AutoSize = False
        Me.ColorBGLabel.BackColor = System.Drawing.Color.Gainsboro
        Me.ColorBGLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ColorBGLabel.ForeColor = System.Drawing.Color.Black
        Me.ColorBGLabel.Name = "ColorBGLabel"
        Me.ColorBGLabel.Size = New System.Drawing.Size(30, 17)
        Me.ColorBGLabel.Text = "00"
        Me.ColorBGLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ColorBGLabel.ToolTipText = "Background Color"
        '
        'Bloq_Label
        '
        Me.Bloq_Label.AutoSize = False
        Me.Bloq_Label.BackColor = System.Drawing.Color.Transparent
        Me.Bloq_Label.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bloq_Label.ForeColor = System.Drawing.Color.Navy
        Me.Bloq_Label.Name = "Bloq_Label"
        Me.Bloq_Label.Size = New System.Drawing.Size(50, 17)
        Me.Bloq_Label.Text = "Sprite:"
        Me.Bloq_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Bloq_Label.Visible = False
        '
        'BloqValue_Label
        '
        Me.BloqValue_Label.ActiveLinkColor = System.Drawing.Color.Red
        Me.BloqValue_Label.AutoSize = False
        Me.BloqValue_Label.BackColor = System.Drawing.Color.Gainsboro
        Me.BloqValue_Label.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BloqValue_Label.ForeColor = System.Drawing.Color.Black
        Me.BloqValue_Label.Name = "BloqValue_Label"
        Me.BloqValue_Label.Size = New System.Drawing.Size(33, 17)
        Me.BloqValue_Label.Text = "000"
        Me.BloqValue_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BloqValue_Label.Visible = False
        '
        'H_Rules_PictureBox
        '
        Me.H_Rules_PictureBox.BackColor = System.Drawing.Color.Gainsboro
        Me.H_Rules_PictureBox.BackgroundImage = Global.MSXTILESdevtool.My.Resources.Resources.H_ruler_16p
        Me.H_Rules_PictureBox.Location = New System.Drawing.Point(55, 0)
        Me.H_Rules_PictureBox.Name = "H_Rules_PictureBox"
        Me.H_Rules_PictureBox.Size = New System.Drawing.Size(512, 16)
        Me.H_Rules_PictureBox.TabIndex = 272
        Me.H_Rules_PictureBox.TabStop = False
        '
        'TMS9918Aviewer
        '
        Me.TMS9918Aviewer.BackgroundColor = CType(4, Byte)
        Me.TMS9918Aviewer.BackgroundImage = CType(resources.GetObject("TMS9918Aviewer.BackgroundImage"), System.Drawing.Image)
        Me.TMS9918Aviewer.BorderColor = CType(4, Byte)
        Me.TMS9918Aviewer.ControlType = mSXdevtools.GUI.TMS9918A.TMS9918A.CONTROL_TYPE.VIEWER
        Me.TMS9918Aviewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.TMS9918Aviewer.InkColor = CType(15, Byte)
        Me.TMS9918Aviewer.IsShowSprites = True
        Me.TMS9918Aviewer.Location = New System.Drawing.Point(55, 16)
        Me.TMS9918Aviewer.Margin = New System.Windows.Forms.Padding(1160091, 3, 1160091, 3)
        Me.TMS9918Aviewer.Name = "TMS9918Aviewer"
        Me.TMS9918Aviewer.ScreenMode = mSXdevtools.DataStructures.iVDP.SCREEN_MODE.G2
        Me.TMS9918Aviewer.Size = New System.Drawing.Size(512, 384)
        Me.TMS9918Aviewer.SpriteSize = mSXdevtools.DataStructures.iVDP.SPRITE_SIZE.SIZE16
        Me.TMS9918Aviewer.SpriteZoom = mSXdevtools.DataStructures.iVDP.SPRITE_ZOOM.X1
        Me.TMS9918Aviewer.TabIndex = 116
        Me.TMS9918Aviewer.ViewMode = mSXdevtools.GUI.TMS9918A.TMS9918A.VIEW_MODE.ALL
        Me.TMS9918Aviewer.ViewSize = mSXdevtools.GUI.TMS9918A.TMS9918A.VIEW_SIZE.x2
        '
        'OutputText
        '
        Me.OutputText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OutputText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.OutputText.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OutputText.Location = New System.Drawing.Point(10, 623)
        Me.OutputText.Multiline = True
        Me.OutputText.Name = "OutputText"
        Me.OutputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.OutputText.Size = New System.Drawing.Size(834, 72)
        Me.OutputText.TabIndex = 118
        '
        'DataTypeInput
        '
        Me.DataTypeInput.AsmDataByteCommand = ""
        Me.DataTypeInput.AsmDataWordCommand = ""
        Me.DataTypeInput.BackColor = System.Drawing.Color.Transparent
        Me.DataTypeInput.BASIClineInterval = 10
        Me.DataTypeInput.BASIClineNumber = 10000
        Me.DataTypeInput.BASICremoveZeros = False
        Me.DataTypeInput.CompressType = mSXdevtools.GUI.Controls.DataTypeInputControl.COMPRESS_TYPE.RAW
        Me.DataTypeInput.EnableAssemblerIndex = False
        Me.DataTypeInput.EnableCompress = True
        Me.DataTypeInput.EnableDataLineSize = False
        Me.DataTypeInput.FieldName = "DATA"
        Me.DataTypeInput.LanguageCode = mSXdevtools.DataStructures.SourceCodeInfo.LANGUAGE_CODE.BASIC
        Me.DataTypeInput.LineSizeIndex = 6
        Me.DataTypeInput.Location = New System.Drawing.Point(5, 504)
        Me.DataTypeInput.Name = "DataTypeInput"
        Me.DataTypeInput.NumeralSystem = -1
        Me.DataTypeInput.Size = New System.Drawing.Size(562, 117)
        Me.DataTypeInput.TabIndex = 254
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(40, 24)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 14)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Start (x,y)"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AreaEndX_TextBox
        '
        Me.AreaEndX_TextBox.Location = New System.Drawing.Point(135, 48)
        Me.AreaEndX_TextBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.AreaEndX_TextBox.MaxLength = 3
        Me.AreaEndX_TextBox.Name = "AreaEndX_TextBox"
        Me.AreaEndX_TextBox.Size = New System.Drawing.Size(33, 22)
        Me.AreaEndX_TextBox.TabIndex = 112
        Me.AreaEndX_TextBox.Text = "31"
        Me.AreaEndX_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(40, 52)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 14)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "End (x,y)"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AreaStartY_TextBox
        '
        Me.AreaStartY_TextBox.Location = New System.Drawing.Point(169, 21)
        Me.AreaStartY_TextBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.AreaStartY_TextBox.MaxLength = 3
        Me.AreaStartY_TextBox.Name = "AreaStartY_TextBox"
        Me.AreaStartY_TextBox.Size = New System.Drawing.Size(33, 22)
        Me.AreaStartY_TextBox.TabIndex = 111
        Me.AreaStartY_TextBox.Text = "0"
        Me.AreaStartY_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'AreaStartX_TextBox
        '
        Me.AreaStartX_TextBox.Location = New System.Drawing.Point(135, 21)
        Me.AreaStartX_TextBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.AreaStartX_TextBox.MaxLength = 3
        Me.AreaStartX_TextBox.Name = "AreaStartX_TextBox"
        Me.AreaStartX_TextBox.Size = New System.Drawing.Size(33, 22)
        Me.AreaStartX_TextBox.TabIndex = 110
        Me.AreaStartX_TextBox.Text = "0"
        Me.AreaStartX_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'AreaEndY_TextBox
        '
        Me.AreaEndY_TextBox.Location = New System.Drawing.Point(169, 48)
        Me.AreaEndY_TextBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.AreaEndY_TextBox.MaxLength = 3
        Me.AreaEndY_TextBox.Name = "AreaEndY_TextBox"
        Me.AreaEndY_TextBox.Size = New System.Drawing.Size(33, 22)
        Me.AreaEndY_TextBox.TabIndex = 113
        Me.AreaEndY_TextBox.Text = "23"
        Me.AreaEndY_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'RangeLabel
        '
        Me.RangeLabel.BackColor = System.Drawing.Color.Transparent
        Me.RangeLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RangeLabel.Location = New System.Drawing.Point(18, 21)
        Me.RangeLabel.Name = "RangeLabel"
        Me.RangeLabel.Size = New System.Drawing.Size(67, 20)
        Me.RangeLabel.TabIndex = 257
        Me.RangeLabel.Text = "First:"
        Me.RangeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RangeToLabel
        '
        Me.RangeToLabel.BackColor = System.Drawing.Color.Transparent
        Me.RangeToLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RangeToLabel.Location = New System.Drawing.Point(128, 21)
        Me.RangeToLabel.Name = "RangeToLabel"
        Me.RangeToLabel.Size = New System.Drawing.Size(33, 20)
        Me.RangeToLabel.TabIndex = 253
        Me.RangeToLabel.Text = "to"
        Me.RangeToLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SelectDataLabel
        '
        Me.SelectDataLabel.BackColor = System.Drawing.Color.Transparent
        Me.SelectDataLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SelectDataLabel.Location = New System.Drawing.Point(12, 21)
        Me.SelectDataLabel.Name = "SelectDataLabel"
        Me.SelectDataLabel.Size = New System.Drawing.Size(70, 21)
        Me.SelectDataLabel.TabIndex = 256
        Me.SelectDataLabel.Text = "Tileset:"
        Me.SelectDataLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SelectDataComboBox
        '
        Me.SelectDataComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SelectDataComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SelectDataComboBox.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SelectDataComboBox.FormattingEnabled = True
        Me.SelectDataComboBox.Items.AddRange(New Object() {"All Banks", "Bank A", "Bank B", "Bank C", "Selected Area"})
        Me.SelectDataComboBox.Location = New System.Drawing.Point(88, 21)
        Me.SelectDataComboBox.Name = "SelectDataComboBox"
        Me.SelectDataComboBox.Size = New System.Drawing.Size(154, 22)
        Me.SelectDataComboBox.TabIndex = 255
        '
        'TilesetDataLabel
        '
        Me.TilesetDataLabel.BackColor = System.Drawing.Color.Transparent
        Me.TilesetDataLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TilesetDataLabel.Location = New System.Drawing.Point(12, 49)
        Me.TilesetDataLabel.Name = "TilesetDataLabel"
        Me.TilesetDataLabel.Size = New System.Drawing.Size(70, 21)
        Me.TilesetDataLabel.TabIndex = 258
        Me.TilesetDataLabel.Text = "Type:"
        Me.TilesetDataLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ZoomLabel
        '
        Me.ZoomLabel.BackColor = System.Drawing.Color.Transparent
        Me.ZoomLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ZoomLabel.Location = New System.Drawing.Point(14, 24)
        Me.ZoomLabel.Name = "ZoomLabel"
        Me.ZoomLabel.Size = New System.Drawing.Size(50, 20)
        Me.ZoomLabel.TabIndex = 291
        Me.ZoomLabel.Text = "Tile"
        Me.ZoomLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Tilenumber_TextBox
        '
        Me.Tilenumber_TextBox.BackColor = System.Drawing.Color.Gainsboro
        Me.Tilenumber_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Tilenumber_TextBox.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tilenumber_TextBox.ForeColor = System.Drawing.Color.Black
        Me.Tilenumber_TextBox.Location = New System.Drawing.Point(18, 48)
        Me.Tilenumber_TextBox.MaxLength = 3
        Me.Tilenumber_TextBox.Name = "Tilenumber_TextBox"
        Me.Tilenumber_TextBox.ReadOnly = True
        Me.Tilenumber_TextBox.Size = New System.Drawing.Size(33, 15)
        Me.Tilenumber_TextBox.TabIndex = 290
        Me.Tilenumber_TextBox.Text = "0"
        Me.Tilenumber_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ZoomPanel
        '
        Me.ZoomPanel.BackColor = System.Drawing.Color.Transparent
        Me.ZoomPanel.BGColor = System.Drawing.Color.LightGray
        Me.ZoomPanel.Controls.Add(Me.TileColorsPictureBox)
        Me.ZoomPanel.Controls.Add(Me.TileViewerPictureBox)
        Me.ZoomPanel.Controls.Add(Me.ZoomLabel)
        Me.ZoomPanel.Controls.Add(Me.Tilenumber_TextBox)
        Me.ZoomPanel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.ZoomPanel.LineColor = System.Drawing.Color.DimGray
        Me.ZoomPanel.Location = New System.Drawing.Point(580, 326)
        Me.ZoomPanel.Name = "ZoomPanel"
        Me.ZoomPanel.Padding = New System.Windows.Forms.Padding(0)
        Me.ZoomPanel.Size = New System.Drawing.Size(259, 172)
        Me.ZoomPanel.TabIndex = 295
        Me.ZoomPanel.TabStop = False
        Me.ZoomPanel.Text = "Zoom"
        '
        'TileColorsPictureBox
        '
        Me.TileColorsPictureBox.BackColor = System.Drawing.Color.Black
        Me.TileColorsPictureBox.Location = New System.Drawing.Point(208, 22)
        Me.TileColorsPictureBox.Name = "TileColorsPictureBox"
        Me.TileColorsPictureBox.Size = New System.Drawing.Size(35, 137)
        Me.TileColorsPictureBox.TabIndex = 292
        Me.TileColorsPictureBox.TabStop = False
        '
        'TileViewerPictureBox
        '
        Me.TileViewerPictureBox.BackColor = System.Drawing.Color.Black
        Me.TileViewerPictureBox.Location = New System.Drawing.Point(68, 22)
        Me.TileViewerPictureBox.Name = "TileViewerPictureBox"
        Me.TileViewerPictureBox.Size = New System.Drawing.Size(137, 137)
        Me.TileViewerPictureBox.TabIndex = 289
        Me.TileViewerPictureBox.TabStop = False
        '
        'AreaPanel
        '
        Me.AreaPanel.BackColor = System.Drawing.Color.Transparent
        Me.AreaPanel.BGColor = System.Drawing.Color.LightGray
        Me.AreaPanel.Controls.Add(Me.Label9)
        Me.AreaPanel.Controls.Add(Me.Map_areaResetButton)
        Me.AreaPanel.Controls.Add(Me.AreaEndY_TextBox)
        Me.AreaPanel.Controls.Add(Me.AreaEndX_TextBox)
        Me.AreaPanel.Controls.Add(Me.AreaStartX_TextBox)
        Me.AreaPanel.Controls.Add(Me.Label5)
        Me.AreaPanel.Controls.Add(Me.AreaStartY_TextBox)
        Me.AreaPanel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.AreaPanel.LineColor = System.Drawing.Color.DimGray
        Me.AreaPanel.Location = New System.Drawing.Point(580, 235)
        Me.AreaPanel.Name = "AreaPanel"
        Me.AreaPanel.Padding = New System.Windows.Forms.Padding(0)
        Me.AreaPanel.Size = New System.Drawing.Size(259, 82)
        Me.AreaPanel.TabIndex = 296
        Me.AreaPanel.TabStop = False
        Me.AreaPanel.Text = "Area"
        '
        'RangePanel
        '
        Me.RangePanel.BackColor = System.Drawing.Color.Transparent
        Me.RangePanel.BGColor = System.Drawing.Color.LightGray
        Me.RangePanel.Controls.Add(Me.RangeResetButton)
        Me.RangePanel.Controls.Add(Me.RangeLabel)
        Me.RangePanel.Controls.Add(Me.RangeToLabel)
        Me.RangePanel.Controls.Add(Me.RangeStartTextBox)
        Me.RangePanel.Controls.Add(Me.RangeEndTextBox)
        Me.RangePanel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.RangePanel.LineColor = System.Drawing.Color.DimGray
        Me.RangePanel.Location = New System.Drawing.Point(580, 172)
        Me.RangePanel.Name = "RangePanel"
        Me.RangePanel.Padding = New System.Windows.Forms.Padding(0)
        Me.RangePanel.Size = New System.Drawing.Size(259, 54)
        Me.RangePanel.TabIndex = 297
        Me.RangePanel.TabStop = False
        Me.RangePanel.Text = "Range"
        '
        'DataPanel
        '
        Me.DataPanel.BackColor = System.Drawing.Color.Transparent
        Me.DataPanel.BGColor = System.Drawing.Color.LightGray
        Me.DataPanel.Controls.Add(Me.TilesetDataComboBox)
        Me.DataPanel.Controls.Add(Me.SelectDataLabel)
        Me.DataPanel.Controls.Add(Me.TilesetDataLabel)
        Me.DataPanel.Controls.Add(Me.SelectDataComboBox)
        Me.DataPanel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.DataPanel.LineColor = System.Drawing.Color.DimGray
        Me.DataPanel.Location = New System.Drawing.Point(580, 78)
        Me.DataPanel.Name = "DataPanel"
        Me.DataPanel.Padding = New System.Windows.Forms.Padding(0)
        Me.DataPanel.Size = New System.Drawing.Size(259, 82)
        Me.DataPanel.TabIndex = 298
        Me.DataPanel.TabStop = False
        Me.DataPanel.Text = "Data"
        '
        'HorizontalTab
        '
        Me.HorizontalTab.BackColor = System.Drawing.Color.RoyalBlue
        Me.HorizontalTab.Dock = System.Windows.Forms.DockStyle.Top
        Me.HorizontalTab.ForeColor = System.Drawing.Color.Gainsboro
        Me.HorizontalTab.Items = New String() {"Screen", "Tiles", "Map", "Sprites", "OAM"}
        Me.HorizontalTab.Location = New System.Drawing.Point(0, 39)
        Me.HorizontalTab.Margin = New System.Windows.Forms.Padding(0)
        Me.HorizontalTab.MinimumSize = New System.Drawing.Size(256, 32)
        Me.HorizontalTab.Name = "HorizontalTab"
        Me.HorizontalTab.Padding = New System.Windows.Forms.Padding(4, 4, 0, 0)
        Me.HorizontalTab.Size = New System.Drawing.Size(854, 34)
        Me.HorizontalTab.TabIndex = 299
        '
        'BottonsPanel
        '
        Me.BottonsPanel.BackColor = System.Drawing.Color.Silver
        Me.BottonsPanel.Controls.Add(Me.SaveBinaryButton)
        Me.BottonsPanel.Controls.Add(Me.SaveSourceButton)
        Me.BottonsPanel.Controls.Add(Me.CopyAllButton)
        Me.BottonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottonsPanel.Location = New System.Drawing.Point(0, 697)
        Me.BottonsPanel.Name = "BottonsPanel"
        Me.BottonsPanel.Padding = New System.Windows.Forms.Padding(4)
        Me.BottonsPanel.Size = New System.Drawing.Size(854, 44)
        Me.BottonsPanel.TabIndex = 300
        '
        'MainScreen
        '
        Me.AllowDrop = True
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(854, 741)
        Me.Controls.Add(Me.BottonsPanel)
        Me.Controls.Add(Me.HorizontalTab)
        Me.Controls.Add(Me.DataPanel)
        Me.Controls.Add(Me.RangePanel)
        Me.Controls.Add(Me.AreaPanel)
        Me.Controls.Add(Me.ZoomPanel)
        Me.Controls.Add(Me.GivemeTheCodeButton)
        Me.Controls.Add(Me.DataTypeInput)
        Me.Controls.Add(Me.OutputText)
        Me.Controls.Add(Me.ScreenContainer_Panel)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MinimumSize = New System.Drawing.Size(870, 760)
        Me.Name = "MainScreen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MSXtiles devtool"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ScreenContainer_Panel.ResumeLayout(False)
        Me.ScreenContainer_Panel.PerformLayout()
        Me.PaintToolStrip.ResumeLayout(False)
        Me.PaintToolStrip.PerformLayout()
        CType(Me.V_Rules_PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ScreenStatusStrip.ResumeLayout(False)
        Me.ScreenStatusStrip.PerformLayout()
        CType(Me.H_Rules_PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ZoomPanel.ResumeLayout(False)
        Me.ZoomPanel.PerformLayout()
        CType(Me.TileColorsPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TileViewerPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AreaPanel.ResumeLayout(False)
        Me.AreaPanel.PerformLayout()
        Me.RangePanel.ResumeLayout(False)
        Me.RangePanel.PerformLayout()
        Me.DataPanel.ResumeLayout(False)
        Me.BottonsPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents AreaStartY_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents AreaStartX_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents AreaEndY_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents AreaEndX_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Map_areaResetButton As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents NewProjectButton As ToolStripButton
    Friend WithEvents LoadProjectButton As ToolStripButton
    Friend WithEvents SaveProjectButton As ToolStripButton
    Friend WithEvents SaveasButton As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ProjectNameTextBox As ToolStripTextBox
    Friend WithEvents ProjectInfoButton As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents AboutButton As ToolStripButton
    Friend WithEvents TMS9918Aviewer As TMS9918A
    Friend WithEvents ScreenContainer_Panel As Panel
    Friend WithEvents ScreenStatusStrip As StatusStrip
    Friend WithEvents CursorXLabel As ToolStripStatusLabel
    Friend WithEvents PosX_Label As ToolStripStatusLabel
    Friend WithEvents CursorYLabel As ToolStripStatusLabel
    Friend WithEvents PosY_Label As ToolStripStatusLabel
    Friend WithEvents OutputText As TextBox
    Friend WithEvents DataTypeInput As DataTypeInputControl
    Friend WithEvents H_Rules_PictureBox As PictureBox
    Friend WithEvents V_Rules_PictureBox As PictureBox
    Friend WithEvents Col_Label As ToolStripStatusLabel
    Friend WithEvents ColumnLabel As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents LineLabel As ToolStripStatusLabel
    Friend WithEvents Colors_Label As ToolStripStatusLabel
    Friend WithEvents ColorInkLabel As ToolStripStatusLabel
    Friend WithEvents ColorBGLabel As ToolStripStatusLabel
    Friend WithEvents Bloq_Label As ToolStripStatusLabel
    Friend WithEvents BloqValue_Label As ToolStripStatusLabel
    Private WithEvents PaintToolStrip As ToolStrip
    Friend WithEvents OptimizeButton As ToolStripButton
    Friend WithEvents TilesOrderButton As ToolStripButton
    Friend WithEvents FillMapButton As ToolStripButton
    Friend WithEvents SwitchButton As ToolStripButton
    Friend WithEvents SelectAreaButton As ToolStripButton
    Friend WithEvents EditPaleteButton As ToolStripButton
    Friend WithEvents ClearButton As ToolStripButton
    Friend WithEvents UndoButton As ToolStripButton
    Friend WithEvents SwapButton As ToolStripButton
    Friend WithEvents GivemeTheCodeButton As piXelST_Button
    Friend WithEvents TilesetDataComboBox As ComboBox
    Friend WithEvents TilesetDataLabel As Label
    Friend WithEvents RangeResetButton As Button
    Friend WithEvents RangeLabel As Label
    Friend WithEvents RangeEndTextBox As TextBox
    Friend WithEvents RangeToLabel As Label
    Friend WithEvents SelectDataLabel As Label
    Friend WithEvents RangeStartTextBox As TextBox
    Friend WithEvents SelectDataComboBox As ComboBox
    Friend WithEvents TileViewerPictureBox As PictureBox
    Friend WithEvents ZoomLabel As Label
    Friend WithEvents Tilenumber_TextBox As TextBox
    Friend WithEvents ConfigButton As ToolStripButton
    Friend WithEvents Help_Button As ToolStripButton
    Friend WithEvents Save_nMSXProjectButton As ToolStripButton
    Friend WithEvents SaveMSXBASICGButton1 As ToolStripButton
    Friend WithEvents SaveBitmapButton1 As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents TileColorsPictureBox As PictureBox
    Friend WithEvents BorderColorButton As ToolStripButton
    Friend WithEvents ZoomPanel As piXelST_GroupBox
    Friend WithEvents AreaPanel As piXelST_GroupBox
    Friend WithEvents RangePanel As piXelST_GroupBox
    Friend WithEvents DataPanel As piXelST_GroupBox
    Friend WithEvents HorizontalTab As piXelST_HorizontalTab
    Friend WithEvents BottonsPanel As Panel
    Public WithEvents SaveBinaryButton As piXelST_Button
    Public WithEvents SaveSourceButton As piXelST_Button
    Friend WithEvents CopyAllButton As piXelST_Button
End Class
