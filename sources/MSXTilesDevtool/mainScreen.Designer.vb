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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.AreaEndY_TextBox = New System.Windows.Forms.TextBox()
        Me.AreaEndX_TextBox = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.AreaStartY_TextBox = New System.Windows.Forms.TextBox()
        Me.AreaStartX_TextBox = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CopyAllButton = New System.Windows.Forms.Button()
        Me.DataComboBox = New System.Windows.Forms.ComboBox()
        Me.RangeResetButton = New System.Windows.Forms.Button()
        Me.RangeEndTextBox = New System.Windows.Forms.TextBox()
        Me.RangeStartTextBox = New System.Windows.Forms.TextBox()
        Me.Map_areaResetButton = New System.Windows.Forms.Button()
        Me.SavePNGBut = New System.Windows.Forms.Button()
        Me.SaveSC2But = New System.Windows.Forms.Button()
        Me.SaveNMSXprj_Button = New System.Windows.Forms.Button()
        Me.SaveSCProjectButton = New System.Windows.Forms.Button()
        Me.SaveBinaryButton = New System.Windows.Forms.Button()
        Me.SaveSourceButton = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.NewProjectButton = New System.Windows.Forms.ToolStripButton()
        Me.LoadProjectButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveProjectButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveasButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ProjectNameTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.ProjectInfoButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
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
        Me.SaveButsPanel = New System.Windows.Forms.Panel()
        Me.GivemeTheCodeButton = New System.Windows.Forms.Button()
        Me.DataDefinitionPanel = New System.Windows.Forms.Panel()
        Me.DataLabel = New System.Windows.Forms.Label()
        Me.RangeLabel = New System.Windows.Forms.Label()
        Me.RangeToLabel = New System.Windows.Forms.Label()
        Me.TilesetLabel = New System.Windows.Forms.Label()
        Me.TilesetComboBox = New System.Windows.Forms.ComboBox()
        Me.SelectAreaGroupBox = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.HoriTAB1 = New MSXTILESdevtool.HoriTAB()
        Me.RangeGroupBox = New System.Windows.Forms.GroupBox()
        Me.ToolStrip1.SuspendLayout()
        Me.ScreenContainer_Panel.SuspendLayout()
        Me.PaintToolStrip.SuspendLayout()
        CType(Me.V_Rules_PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ScreenStatusStrip.SuspendLayout()
        CType(Me.H_Rules_PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SaveButsPanel.SuspendLayout()
        Me.DataDefinitionPanel.SuspendLayout()
        Me.SelectAreaGroupBox.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.RangeGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 49)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 14)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "End (x,y)"
        '
        'AreaEndY_TextBox
        '
        Me.AreaEndY_TextBox.Location = New System.Drawing.Point(114, 46)
        Me.AreaEndY_TextBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.AreaEndY_TextBox.MaxLength = 3
        Me.AreaEndY_TextBox.Name = "AreaEndY_TextBox"
        Me.AreaEndY_TextBox.Size = New System.Drawing.Size(33, 22)
        Me.AreaEndY_TextBox.TabIndex = 113
        Me.AreaEndY_TextBox.Text = "23"
        Me.AreaEndY_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'AreaEndX_TextBox
        '
        Me.AreaEndX_TextBox.Location = New System.Drawing.Point(80, 46)
        Me.AreaEndX_TextBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.AreaEndX_TextBox.MaxLength = 3
        Me.AreaEndX_TextBox.Name = "AreaEndX_TextBox"
        Me.AreaEndX_TextBox.Size = New System.Drawing.Size(33, 22)
        Me.AreaEndX_TextBox.TabIndex = 112
        Me.AreaEndX_TextBox.Text = "31"
        Me.AreaEndX_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 22)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 14)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Start (x,y)"
        '
        'AreaStartY_TextBox
        '
        Me.AreaStartY_TextBox.Location = New System.Drawing.Point(114, 19)
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
        Me.AreaStartX_TextBox.Location = New System.Drawing.Point(80, 19)
        Me.AreaStartX_TextBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.AreaStartX_TextBox.MaxLength = 3
        Me.AreaStartX_TextBox.Name = "AreaStartX_TextBox"
        Me.AreaStartX_TextBox.Size = New System.Drawing.Size(33, 22)
        Me.AreaStartX_TextBox.TabIndex = 110
        Me.AreaStartX_TextBox.Text = "0"
        Me.AreaStartX_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'CopyAllButton
        '
        Me.CopyAllButton.BackColor = System.Drawing.Color.Gainsboro
        Me.CopyAllButton.Dock = System.Windows.Forms.DockStyle.Left
        Me.CopyAllButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CopyAllButton.Location = New System.Drawing.Point(0, 0)
        Me.CopyAllButton.Name = "CopyAllButton"
        Me.CopyAllButton.Size = New System.Drawing.Size(100, 31)
        Me.CopyAllButton.TabIndex = 269
        Me.CopyAllButton.Text = "Copy All"
        Me.ToolTip1.SetToolTip(Me.CopyAllButton, "Copy output to clipboard")
        Me.CopyAllButton.UseVisualStyleBackColor = False
        '
        'DataComboBox
        '
        Me.DataComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DataComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DataComboBox.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataComboBox.FormattingEnabled = True
        Me.DataComboBox.Items.AddRange(New Object() {"Pattern", "Color"})
        Me.DataComboBox.Location = New System.Drawing.Point(100, 31)
        Me.DataComboBox.Name = "DataComboBox"
        Me.DataComboBox.Size = New System.Drawing.Size(153, 22)
        Me.DataComboBox.TabIndex = 259
        Me.ToolTip1.SetToolTip(Me.DataComboBox, "Type of data to generate.")
        '
        'RangeResetButton
        '
        Me.RangeResetButton.BackColor = System.Drawing.Color.Gainsboro
        Me.RangeResetButton.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RangeResetButton.Location = New System.Drawing.Point(192, 21)
        Me.RangeResetButton.Name = "RangeResetButton"
        Me.RangeResetButton.Size = New System.Drawing.Size(36, 24)
        Me.RangeResetButton.TabIndex = 254
        Me.RangeResetButton.Text = "All"
        Me.ToolTip1.SetToolTip(Me.RangeResetButton, "Default values (0-255)")
        Me.RangeResetButton.UseVisualStyleBackColor = False
        '
        'RangeEndTextBox
        '
        Me.RangeEndTextBox.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RangeEndTextBox.Location = New System.Drawing.Point(157, 22)
        Me.RangeEndTextBox.MaxLength = 3
        Me.RangeEndTextBox.Name = "RangeEndTextBox"
        Me.RangeEndTextBox.Size = New System.Drawing.Size(33, 22)
        Me.RangeEndTextBox.TabIndex = 252
        Me.RangeEndTextBox.Text = "255"
        Me.RangeEndTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.RangeEndTextBox, "End tile number.")
        '
        'RangeStartTextBox
        '
        Me.RangeStartTextBox.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RangeStartTextBox.Location = New System.Drawing.Point(79, 22)
        Me.RangeStartTextBox.MaxLength = 3
        Me.RangeStartTextBox.Name = "RangeStartTextBox"
        Me.RangeStartTextBox.Size = New System.Drawing.Size(33, 22)
        Me.RangeStartTextBox.TabIndex = 251
        Me.RangeStartTextBox.Text = "0"
        Me.RangeStartTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.RangeStartTextBox, "Start tile number.")
        '
        'Map_areaResetButton
        '
        Me.Map_areaResetButton.BackColor = System.Drawing.Color.Gainsboro
        Me.Map_areaResetButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.auto_16x16
        Me.Map_areaResetButton.Location = New System.Drawing.Point(148, 45)
        Me.Map_areaResetButton.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Map_areaResetButton.Name = "Map_areaResetButton"
        Me.Map_areaResetButton.Size = New System.Drawing.Size(24, 24)
        Me.Map_areaResetButton.TabIndex = 114
        Me.ToolTip1.SetToolTip(Me.Map_areaResetButton, "Initialize values.")
        Me.Map_areaResetButton.UseVisualStyleBackColor = False
        '
        'SavePNGBut
        '
        Me.SavePNGBut.BackColor = System.Drawing.Color.Gainsboro
        Me.SavePNGBut.Dock = System.Windows.Forms.DockStyle.Right
        Me.SavePNGBut.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SavePNGBut.Image = Global.MSXTILESdevtool.My.Resources.Resources.save_bitmap3_x24
        Me.SavePNGBut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SavePNGBut.Location = New System.Drawing.Point(375, 0)
        Me.SavePNGBut.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SavePNGBut.Name = "SavePNGBut"
        Me.SavePNGBut.Size = New System.Drawing.Size(120, 31)
        Me.SavePNGBut.TabIndex = 17
        Me.SavePNGBut.Text = "Save PNG"
        Me.SavePNGBut.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.SavePNGBut, "Save PNG picture")
        Me.SavePNGBut.UseVisualStyleBackColor = False
        '
        'SaveSC2But
        '
        Me.SaveSC2But.BackColor = System.Drawing.Color.Gainsboro
        Me.SaveSC2But.Dock = System.Windows.Forms.DockStyle.Right
        Me.SaveSC2But.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveSC2But.Image = Global.MSXTILESdevtool.My.Resources.Resources.saveSC_x24
        Me.SaveSC2But.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SaveSC2But.Location = New System.Drawing.Point(255, 0)
        Me.SaveSC2But.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SaveSC2But.Name = "SaveSC2But"
        Me.SaveSC2But.Size = New System.Drawing.Size(120, 31)
        Me.SaveSC2But.TabIndex = 8
        Me.SaveSC2But.Text = "Save SC2"
        Me.SaveSC2But.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.SaveSC2But, "Save SC2 picture")
        Me.SaveSC2But.UseVisualStyleBackColor = False
        '
        'SaveNMSXprj_Button
        '
        Me.SaveNMSXprj_Button.BackColor = System.Drawing.Color.Gainsboro
        Me.SaveNMSXprj_Button.Dock = System.Windows.Forms.DockStyle.Right
        Me.SaveNMSXprj_Button.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveNMSXprj_Button.Image = Global.MSXTILESdevtool.My.Resources.Resources.saveNM_x24
        Me.SaveNMSXprj_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SaveNMSXprj_Button.Location = New System.Drawing.Point(135, 0)
        Me.SaveNMSXprj_Button.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SaveNMSXprj_Button.Name = "SaveNMSXprj_Button"
        Me.SaveNMSXprj_Button.Size = New System.Drawing.Size(120, 31)
        Me.SaveNMSXprj_Button.TabIndex = 33
        Me.SaveNMSXprj_Button.Text = "Save nMSX"
        Me.SaveNMSXprj_Button.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.SaveNMSXprj_Button, "Save nMSXtiles Project")
        Me.SaveNMSXprj_Button.UseVisualStyleBackColor = False
        '
        'SaveSCProjectButton
        '
        Me.SaveSCProjectButton.BackColor = System.Drawing.Color.Gainsboro
        Me.SaveSCProjectButton.Dock = System.Windows.Forms.DockStyle.Right
        Me.SaveSCProjectButton.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveSCProjectButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.save3_x24
        Me.SaveSCProjectButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SaveSCProjectButton.Location = New System.Drawing.Point(15, 0)
        Me.SaveSCProjectButton.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SaveSCProjectButton.Name = "SaveSCProjectButton"
        Me.SaveSCProjectButton.Size = New System.Drawing.Size(120, 31)
        Me.SaveSCProjectButton.TabIndex = 35
        Me.SaveSCProjectButton.Text = "Save PRJ"
        Me.SaveSCProjectButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.SaveSCProjectButton, "Save Open Document Screen Project")
        Me.SaveSCProjectButton.UseVisualStyleBackColor = False
        '
        'SaveBinaryButton
        '
        Me.SaveBinaryButton.BackColor = System.Drawing.Color.LightGray
        Me.SaveBinaryButton.Dock = System.Windows.Forms.DockStyle.Left
        Me.SaveBinaryButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveBinaryButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.save3_x24
        Me.SaveBinaryButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.SaveBinaryButton.Location = New System.Drawing.Point(200, 0)
        Me.SaveBinaryButton.Name = "SaveBinaryButton"
        Me.SaveBinaryButton.Size = New System.Drawing.Size(100, 31)
        Me.SaveBinaryButton.TabIndex = 271
        Me.SaveBinaryButton.Text = "Binary"
        Me.SaveBinaryButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.SaveBinaryButton, "Save output to Binary file")
        Me.SaveBinaryButton.UseVisualStyleBackColor = False
        '
        'SaveSourceButton
        '
        Me.SaveSourceButton.BackColor = System.Drawing.Color.LightGray
        Me.SaveSourceButton.Dock = System.Windows.Forms.DockStyle.Left
        Me.SaveSourceButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveSourceButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.save3_x24
        Me.SaveSourceButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.SaveSourceButton.Location = New System.Drawing.Point(100, 0)
        Me.SaveSourceButton.Name = "SaveSourceButton"
        Me.SaveSourceButton.Size = New System.Drawing.Size(100, 31)
        Me.SaveSourceButton.TabIndex = 270
        Me.SaveSourceButton.Text = "Source"
        Me.SaveSourceButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.SaveSourceButton, "Save output to TXT file")
        Me.SaveSourceButton.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.Gainsboro
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewProjectButton, Me.LoadProjectButton, Me.SaveProjectButton, Me.SaveasButton, Me.ToolStripSeparator1, Me.ProjectNameTextBox, Me.ProjectInfoButton, Me.ToolStripSeparator2, Me.AboutButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(854, 32)
        Me.ToolStrip1.TabIndex = 38
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'NewProjectButton
        '
        Me.NewProjectButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.new_24
        Me.NewProjectButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.NewProjectButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewProjectButton.Name = "NewProjectButton"
        Me.NewProjectButton.Size = New System.Drawing.Size(28, 29)
        Me.NewProjectButton.ToolTipText = "New Project"
        '
        'LoadProjectButton
        '
        Me.LoadProjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.LoadProjectButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.Load_file2_x24
        Me.LoadProjectButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.LoadProjectButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LoadProjectButton.Name = "LoadProjectButton"
        Me.LoadProjectButton.Size = New System.Drawing.Size(28, 29)
        Me.LoadProjectButton.Text = "LoadProject"
        Me.LoadProjectButton.ToolTipText = "Load Project"
        '
        'SaveProjectButton
        '
        Me.SaveProjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveProjectButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.save3_x24
        Me.SaveProjectButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveProjectButton.Name = "SaveProjectButton"
        Me.SaveProjectButton.Size = New System.Drawing.Size(28, 29)
        Me.SaveProjectButton.Text = "ToolStripButton1"
        Me.SaveProjectButton.ToolTipText = "Save Project"
        '
        'SaveasButton
        '
        Me.SaveasButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveasButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.save_as3_x24
        Me.SaveasButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveasButton.Name = "SaveasButton"
        Me.SaveasButton.Size = New System.Drawing.Size(28, 29)
        Me.SaveasButton.Text = "SaveasButton"
        Me.SaveasButton.ToolTipText = "Save As"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 32)
        '
        'ProjectNameTextBox
        '
        Me.ProjectNameTextBox.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ProjectNameTextBox.Name = "ProjectNameTextBox"
        Me.ProjectNameTextBox.ReadOnly = True
        Me.ProjectNameTextBox.Size = New System.Drawing.Size(220, 32)
        Me.ProjectNameTextBox.ToolTipText = "Project Name"
        '
        'ProjectInfoButton
        '
        Me.ProjectInfoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ProjectInfoButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.project_properties_24p
        Me.ProjectInfoButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ProjectInfoButton.Name = "ProjectInfoButton"
        Me.ProjectInfoButton.Size = New System.Drawing.Size(28, 29)
        Me.ProjectInfoButton.Text = "ToolStripButton1"
        Me.ProjectInfoButton.ToolTipText = "Edit Project Info"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 32)
        '
        'AboutButton
        '
        Me.AboutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AboutButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.about_24
        Me.AboutButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AboutButton.Name = "AboutButton"
        Me.AboutButton.Size = New System.Drawing.Size(28, 29)
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
        Me.ScreenContainer_Panel.Location = New System.Drawing.Point(1, 78)
        Me.ScreenContainer_Panel.Name = "ScreenContainer_Panel"
        Me.ScreenContainer_Panel.Size = New System.Drawing.Size(562, 422)
        Me.ScreenContainer_Panel.TabIndex = 117
        '
        'PaintToolStrip
        '
        Me.PaintToolStrip.AutoSize = False
        Me.PaintToolStrip.BackColor = System.Drawing.Color.Gainsboro
        Me.PaintToolStrip.Dock = System.Windows.Forms.DockStyle.Left
        Me.PaintToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.PaintToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptimizeButton, Me.TilesOrderButton, Me.FillMapButton, Me.SwitchButton, Me.SwapButton, Me.SelectAreaButton, Me.EditPaleteButton, Me.ClearButton, Me.UndoButton})
        Me.PaintToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.PaintToolStrip.Name = "PaintToolStrip"
        Me.PaintToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.PaintToolStrip.Size = New System.Drawing.Size(32, 400)
        Me.PaintToolStrip.TabIndex = 274
        Me.PaintToolStrip.Text = "ToolStrip1"
        '
        'OptimizeButton
        '
        Me.OptimizeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OptimizeButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.reload_24x24_02
        Me.OptimizeButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OptimizeButton.Name = "OptimizeButton"
        Me.OptimizeButton.Size = New System.Drawing.Size(30, 28)
        Me.OptimizeButton.Text = "ToolStripButton3"
        Me.OptimizeButton.ToolTipText = "Optimize pattern and color data"
        '
        'TilesOrderButton
        '
        Me.TilesOrderButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TilesOrderButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.gradient_up_24
        Me.TilesOrderButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TilesOrderButton.Name = "TilesOrderButton"
        Me.TilesOrderButton.Size = New System.Drawing.Size(30, 28)
        Me.TilesOrderButton.ToolTipText = "Generates an ordered map"
        '
        'FillMapButton
        '
        Me.FillMapButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.FillMapButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.fill_x24_02
        Me.FillMapButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FillMapButton.Name = "FillMapButton"
        Me.FillMapButton.Size = New System.Drawing.Size(30, 28)
        Me.FillMapButton.Text = "ToolStripButton1"
        Me.FillMapButton.ToolTipText = "Fill an area with the same tile"
        '
        'SwitchButton
        '
        Me.SwitchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SwitchButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.change_x24_02
        Me.SwitchButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SwitchButton.Name = "SwitchButton"
        Me.SwitchButton.Size = New System.Drawing.Size(30, 28)
        Me.SwitchButton.Text = "ToolStripButton1"
        Me.SwitchButton.ToolTipText = "Write text"
        '
        'SwapButton
        '
        Me.SwapButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SwapButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.exchange2_x24
        Me.SwapButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SwapButton.Name = "SwapButton"
        Me.SwapButton.Size = New System.Drawing.Size(30, 28)
        '
        'SelectAreaButton
        '
        Me.SelectAreaButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SelectAreaButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.select_24
        Me.SelectAreaButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SelectAreaButton.Name = "SelectAreaButton"
        Me.SelectAreaButton.Size = New System.Drawing.Size(30, 28)
        Me.SelectAreaButton.Text = "ToolStripButton3"
        Me.SelectAreaButton.ToolTipText = "Select area"
        '
        'EditPaleteButton
        '
        Me.EditPaleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.EditPaleteButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.palette3_x24
        Me.EditPaleteButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EditPaleteButton.Name = "EditPaleteButton"
        Me.EditPaleteButton.Size = New System.Drawing.Size(30, 28)
        Me.EditPaleteButton.ToolTipText = "Draw the clipboard area"
        '
        'ClearButton
        '
        Me.ClearButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ClearButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.trashcan01_24p
        Me.ClearButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ClearButton.Name = "ClearButton"
        Me.ClearButton.Size = New System.Drawing.Size(30, 28)
        Me.ClearButton.Text = "ToolStripButton4"
        Me.ClearButton.ToolTipText = "Clear Map"
        '
        'UndoButton
        '
        Me.UndoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.UndoButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.undo_clear
        Me.UndoButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.UndoButton.Name = "UndoButton"
        Me.UndoButton.Size = New System.Drawing.Size(30, 28)
        Me.UndoButton.Text = "ToolStripButton3"
        Me.UndoButton.ToolTipText = "Undo/Redo"
        '
        'V_Rules_PictureBox
        '
        Me.V_Rules_PictureBox.BackColor = System.Drawing.Color.Gainsboro
        Me.V_Rules_PictureBox.BackgroundImage = Global.MSXTILESdevtool.My.Resources.Resources.V_ruler_16p
        Me.V_Rules_PictureBox.Location = New System.Drawing.Point(33, 15)
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
        Me.ScreenStatusStrip.Size = New System.Drawing.Size(562, 22)
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
        Me.Bloq_Label.Text = "Tile:"
        Me.Bloq_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        '
        'H_Rules_PictureBox
        '
        Me.H_Rules_PictureBox.BackColor = System.Drawing.Color.Gainsboro
        Me.H_Rules_PictureBox.BackgroundImage = Global.MSXTILESdevtool.My.Resources.Resources.H_ruler_16p
        Me.H_Rules_PictureBox.Location = New System.Drawing.Point(50, 0)
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
        Me.TMS9918Aviewer.Location = New System.Drawing.Point(49, 16)
        Me.TMS9918Aviewer.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TMS9918Aviewer.Name = "TMS9918Aviewer"
        Me.TMS9918Aviewer.ScreenMode = mSXdevtools.DataStructures.iVDP.SCREEN_MODE.G2
        Me.TMS9918Aviewer.Size = New System.Drawing.Size(512, 384)
        Me.TMS9918Aviewer.SpriteSize = mSXdevtools.DataStructures.SpriteMSX.SPRITE_SIZE.SIZE16
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
        Me.OutputText.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OutputText.Location = New System.Drawing.Point(10, 620)
        Me.OutputText.Multiline = True
        Me.OutputText.Name = "OutputText"
        Me.OutputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.OutputText.Size = New System.Drawing.Size(832, 61)
        Me.OutputText.TabIndex = 118
        '
        'DataTypeInput
        '
        Me.DataTypeInput.BackColor = System.Drawing.Color.Transparent
        Me.DataTypeInput.EnableDataSizeLine = True
        Me.DataTypeInput.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataTypeInput.Location = New System.Drawing.Point(10, 506)
        Me.DataTypeInput.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.DataTypeInput.Name = "DataTypeInput"
        Me.DataTypeInput.Size = New System.Drawing.Size(528, 110)
        Me.DataTypeInput.SizesForColors = False
        Me.DataTypeInput.TabIndex = 254
        '
        'SaveButsPanel
        '
        Me.SaveButsPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SaveButsPanel.Controls.Add(Me.SaveSCProjectButton)
        Me.SaveButsPanel.Controls.Add(Me.SaveNMSXprj_Button)
        Me.SaveButsPanel.Controls.Add(Me.SaveSC2But)
        Me.SaveButsPanel.Controls.Add(Me.SavePNGBut)
        Me.SaveButsPanel.Location = New System.Drawing.Point(347, 687)
        Me.SaveButsPanel.Name = "SaveButsPanel"
        Me.SaveButsPanel.Size = New System.Drawing.Size(495, 31)
        Me.SaveButsPanel.TabIndex = 273
        '
        'GivemeTheCodeButton
        '
        Me.GivemeTheCodeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GivemeTheCodeButton.BackColor = System.Drawing.Color.Yellow
        Me.GivemeTheCodeButton.Font = New System.Drawing.Font("Comic Sans MS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GivemeTheCodeButton.Location = New System.Drawing.Point(573, 575)
        Me.GivemeTheCodeButton.Name = "GivemeTheCodeButton"
        Me.GivemeTheCodeButton.Size = New System.Drawing.Size(269, 41)
        Me.GivemeTheCodeButton.TabIndex = 281
        Me.GivemeTheCodeButton.Text = "Give me the code!"
        Me.GivemeTheCodeButton.UseVisualStyleBackColor = False
        '
        'DataDefinitionPanel
        '
        Me.DataDefinitionPanel.Controls.Add(Me.DataComboBox)
        Me.DataDefinitionPanel.Controls.Add(Me.DataLabel)
        Me.DataDefinitionPanel.Controls.Add(Me.TilesetLabel)
        Me.DataDefinitionPanel.Controls.Add(Me.TilesetComboBox)
        Me.DataDefinitionPanel.Location = New System.Drawing.Point(573, 94)
        Me.DataDefinitionPanel.Name = "DataDefinitionPanel"
        Me.DataDefinitionPanel.Size = New System.Drawing.Size(263, 67)
        Me.DataDefinitionPanel.TabIndex = 283
        '
        'DataLabel
        '
        Me.DataLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataLabel.Location = New System.Drawing.Point(6, 31)
        Me.DataLabel.Name = "DataLabel"
        Me.DataLabel.Size = New System.Drawing.Size(90, 21)
        Me.DataLabel.TabIndex = 258
        Me.DataLabel.Text = "Data:"
        Me.DataLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RangeLabel
        '
        Me.RangeLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RangeLabel.Location = New System.Drawing.Point(8, 22)
        Me.RangeLabel.Name = "RangeLabel"
        Me.RangeLabel.Size = New System.Drawing.Size(67, 20)
        Me.RangeLabel.TabIndex = 257
        Me.RangeLabel.Text = "First:"
        Me.RangeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RangeToLabel
        '
        Me.RangeToLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RangeToLabel.Location = New System.Drawing.Point(118, 22)
        Me.RangeToLabel.Name = "RangeToLabel"
        Me.RangeToLabel.Size = New System.Drawing.Size(33, 20)
        Me.RangeToLabel.TabIndex = 253
        Me.RangeToLabel.Text = "to"
        Me.RangeToLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TilesetLabel
        '
        Me.TilesetLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TilesetLabel.Location = New System.Drawing.Point(5, 3)
        Me.TilesetLabel.Name = "TilesetLabel"
        Me.TilesetLabel.Size = New System.Drawing.Size(90, 21)
        Me.TilesetLabel.TabIndex = 256
        Me.TilesetLabel.Text = "Tileset:"
        Me.TilesetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TilesetComboBox
        '
        Me.TilesetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TilesetComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.TilesetComboBox.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TilesetComboBox.FormattingEnabled = True
        Me.TilesetComboBox.Items.AddRange(New Object() {"All Banks", "Bank A", "Bank B", "Bank C", "Selected Area"})
        Me.TilesetComboBox.Location = New System.Drawing.Point(99, 3)
        Me.TilesetComboBox.Name = "TilesetComboBox"
        Me.TilesetComboBox.Size = New System.Drawing.Size(154, 22)
        Me.TilesetComboBox.TabIndex = 255
        '
        'SelectAreaGroupBox
        '
        Me.SelectAreaGroupBox.Controls.Add(Me.Label9)
        Me.SelectAreaGroupBox.Controls.Add(Me.Map_areaResetButton)
        Me.SelectAreaGroupBox.Controls.Add(Me.Label5)
        Me.SelectAreaGroupBox.Controls.Add(Me.AreaStartX_TextBox)
        Me.SelectAreaGroupBox.Controls.Add(Me.AreaEndY_TextBox)
        Me.SelectAreaGroupBox.Controls.Add(Me.AreaStartY_TextBox)
        Me.SelectAreaGroupBox.Controls.Add(Me.AreaEndX_TextBox)
        Me.SelectAreaGroupBox.Location = New System.Drawing.Point(584, 252)
        Me.SelectAreaGroupBox.Name = "SelectAreaGroupBox"
        Me.SelectAreaGroupBox.Size = New System.Drawing.Size(242, 81)
        Me.SelectAreaGroupBox.TabIndex = 285
        Me.SelectAreaGroupBox.TabStop = False
        Me.SelectAreaGroupBox.Text = "Select area"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.SaveBinaryButton)
        Me.Panel2.Controls.Add(Me.SaveSourceButton)
        Me.Panel2.Controls.Add(Me.CopyAllButton)
        Me.Panel2.Location = New System.Drawing.Point(10, 687)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(330, 31)
        Me.Panel2.TabIndex = 286
        '
        'HoriTAB1
        '
        Me.HoriTAB1.BackColor = System.Drawing.Color.RoyalBlue
        Me.HoriTAB1.Dock = System.Windows.Forms.DockStyle.Top
        Me.HoriTAB1.Location = New System.Drawing.Point(0, 32)
        Me.HoriTAB1.Margin = New System.Windows.Forms.Padding(0)
        Me.HoriTAB1.Name = "HoriTAB1"
        Me.HoriTAB1.Size = New System.Drawing.Size(854, 34)
        Me.HoriTAB1.TabIndex = 272
        '
        'RangeGroupBox
        '
        Me.RangeGroupBox.Controls.Add(Me.RangeResetButton)
        Me.RangeGroupBox.Controls.Add(Me.RangeStartTextBox)
        Me.RangeGroupBox.Controls.Add(Me.RangeToLabel)
        Me.RangeGroupBox.Controls.Add(Me.RangeLabel)
        Me.RangeGroupBox.Controls.Add(Me.RangeEndTextBox)
        Me.RangeGroupBox.Location = New System.Drawing.Point(584, 176)
        Me.RangeGroupBox.Name = "RangeGroupBox"
        Me.RangeGroupBox.Size = New System.Drawing.Size(241, 60)
        Me.RangeGroupBox.TabIndex = 287
        Me.RangeGroupBox.TabStop = False
        Me.RangeGroupBox.Text = "Range"
        '
        'MainScreen
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(854, 721)
        Me.Controls.Add(Me.RangeGroupBox)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.SelectAreaGroupBox)
        Me.Controls.Add(Me.DataDefinitionPanel)
        Me.Controls.Add(Me.GivemeTheCodeButton)
        Me.Controls.Add(Me.SaveButsPanel)
        Me.Controls.Add(Me.HoriTAB1)
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
        Me.SaveButsPanel.ResumeLayout(False)
        Me.DataDefinitionPanel.ResumeLayout(False)
        Me.SelectAreaGroupBox.ResumeLayout(False)
        Me.SelectAreaGroupBox.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.RangeGroupBox.ResumeLayout(False)
        Me.RangeGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    'Friend WithEvents screen2 As TMS9918
    Friend WithEvents SaveSC2But As System.Windows.Forms.Button
    Friend WithEvents SavePNGBut As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents AreaStartY_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents AreaStartX_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents AreaEndY_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents AreaEndX_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Map_areaResetButton As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents SaveNMSXprj_Button As System.Windows.Forms.Button
    Friend WithEvents SaveSCProjectButton As System.Windows.Forms.Button
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
    Friend WithEvents SaveBinaryButton As Button
    Friend WithEvents SaveSourceButton As Button
    Friend WithEvents CopyAllButton As Button
    Friend WithEvents H_Rules_PictureBox As PictureBox
    Friend WithEvents V_Rules_PictureBox As PictureBox
    Friend WithEvents HoriTAB1 As HoriTAB
    Friend WithEvents Col_Label As ToolStripStatusLabel
    Friend WithEvents ColumnLabel As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents LineLabel As ToolStripStatusLabel
    Friend WithEvents Colors_Label As ToolStripStatusLabel
    Friend WithEvents ColorInkLabel As ToolStripStatusLabel
    Friend WithEvents ColorBGLabel As ToolStripStatusLabel
    Friend WithEvents Bloq_Label As ToolStripStatusLabel
    Friend WithEvents BloqValue_Label As ToolStripStatusLabel
    Friend WithEvents SaveButsPanel As Panel
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
    Friend WithEvents GivemeTheCodeButton As Button
    Friend WithEvents DataDefinitionPanel As Panel
    Friend WithEvents DataComboBox As ComboBox
    Friend WithEvents DataLabel As Label
    Friend WithEvents RangeResetButton As Button
    Friend WithEvents RangeLabel As Label
    Friend WithEvents RangeEndTextBox As TextBox
    Friend WithEvents RangeToLabel As Label
    Friend WithEvents TilesetLabel As Label
    Friend WithEvents RangeStartTextBox As TextBox
    Friend WithEvents TilesetComboBox As ComboBox
    Friend WithEvents SelectAreaGroupBox As GroupBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents RangeGroupBox As GroupBox
End Class
