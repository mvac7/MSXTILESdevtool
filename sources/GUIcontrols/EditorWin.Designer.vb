<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditorWin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditorWin))
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ProjectToolStrip = New System.Windows.Forms.ToolStrip()
        Me.NewButton = New System.Windows.Forms.ToolStripButton()
        Me.LoadButton = New System.Windows.Forms.ToolStripButton()
        Me.LoadRecentButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveAsButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ProjectNameText = New System.Windows.Forms.ToolStripTextBox()
        Me.ProjectDataButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.GetDataButton = New System.Windows.Forms.ToolStripButton()
        Me.EditColorPaletteButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.ConfigAppButton = New System.Windows.Forms.ToolStripButton()
        Me.HelpAppButton = New System.Windows.Forms.ToolStripButton()
        Me.AboutButton = New System.Windows.Forms.ToolStripButton()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.PrjImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.FilesContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ProjectToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'ProjectToolStrip
        '
        Me.ProjectToolStrip.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ProjectToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ProjectToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewButton, Me.LoadButton, Me.LoadRecentButton, Me.SaveButton, Me.SaveAsButton, Me.ToolStripSeparator1, Me.ProjectNameText, Me.ProjectDataButton, Me.ToolStripSeparator2, Me.GetDataButton, Me.EditColorPaletteButton, Me.ToolStripSeparator9, Me.ConfigAppButton, Me.HelpAppButton, Me.AboutButton})
        Me.ProjectToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ProjectToolStrip.Name = "ProjectToolStrip"
        Me.ProjectToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ProjectToolStrip.Size = New System.Drawing.Size(624, 31)
        Me.ProjectToolStrip.TabIndex = 9
        Me.ProjectToolStrip.Text = "ProjectToolStrip"
        '
        'NewButton
        '
        Me.NewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NewButton.Image = Global.mSXdevtools.GUI.Controls.My.Resources.Resources.new_24
        Me.NewButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewButton.Name = "NewButton"
        Me.NewButton.Size = New System.Drawing.Size(28, 28)
        Me.NewButton.ToolTipText = "New Project. (Clear all data)"
        '
        'LoadButton
        '
        Me.LoadButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.LoadButton.Image = Global.mSXdevtools.GUI.Controls.My.Resources.Resources.Load_file_x24
        Me.LoadButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LoadButton.Name = "LoadButton"
        Me.LoadButton.Size = New System.Drawing.Size(28, 28)
        Me.LoadButton.ToolTipText = "Load a project or screen (XSCP, PRJ, SCn, PNG or GIF)"
        '
        'LoadRecentButton
        '
        Me.LoadRecentButton.AutoSize = False
        Me.LoadRecentButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.LoadRecentButton.Image = Global.mSXdevtools.GUI.Controls.My.Resources.Resources.more_9x24
        Me.LoadRecentButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LoadRecentButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.LoadRecentButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LoadRecentButton.Name = "LoadRecentButton"
        Me.LoadRecentButton.Size = New System.Drawing.Size(14, 28)
        Me.LoadRecentButton.ToolTipText = "Load recent Project"
        '
        'SaveButton
        '
        Me.SaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveButton.Image = Global.mSXdevtools.GUI.Controls.My.Resources.Resources.save2_x24
        Me.SaveButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(28, 28)
        Me.SaveButton.ToolTipText = "Save Project"
        '
        'SaveAsButton
        '
        Me.SaveAsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveAsButton.Image = Global.mSXdevtools.GUI.Controls.My.Resources.Resources.save_as_x24
        Me.SaveAsButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveAsButton.Name = "SaveAsButton"
        Me.SaveAsButton.Size = New System.Drawing.Size(28, 28)
        Me.SaveAsButton.ToolTipText = "Save as Project"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'ProjectNameText
        '
        Me.ProjectNameText.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProjectNameText.Name = "ProjectNameText"
        Me.ProjectNameText.ReadOnly = True
        Me.ProjectNameText.Size = New System.Drawing.Size(220, 31)
        '
        'ProjectDataButton
        '
        Me.ProjectDataButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ProjectDataButton.Image = Global.mSXdevtools.GUI.Controls.My.Resources.Resources.project_properties_24
        Me.ProjectDataButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ProjectDataButton.Name = "ProjectDataButton"
        Me.ProjectDataButton.Size = New System.Drawing.Size(28, 28)
        Me.ProjectDataButton.ToolTipText = "Edit project information"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'GetDataButton
        '
        Me.GetDataButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.GetDataButton.Enabled = False
        Me.GetDataButton.Image = Global.mSXdevtools.GUI.Controls.My.Resources.Resources.ico_dataOutput_24x24
        Me.GetDataButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GetDataButton.Name = "GetDataButton"
        Me.GetDataButton.Size = New System.Drawing.Size(28, 28)
        Me.GetDataButton.ToolTipText = "Tool that generates data in source format."
        '
        'EditColorPaletteButton
        '
        Me.EditColorPaletteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.EditColorPaletteButton.Image = Global.mSXdevtools.GUI.Controls.My.Resources.Resources.palette3_x24
        Me.EditColorPaletteButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EditColorPaletteButton.Name = "EditColorPaletteButton"
        Me.EditColorPaletteButton.Size = New System.Drawing.Size(28, 28)
        Me.EditColorPaletteButton.ToolTipText = "Edit palette"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 31)
        '
        'ConfigAppButton
        '
        Me.ConfigAppButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ConfigAppButton.Image = Global.mSXdevtools.GUI.Controls.My.Resources.Resources.config_x24
        Me.ConfigAppButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ConfigAppButton.Name = "ConfigAppButton"
        Me.ConfigAppButton.Size = New System.Drawing.Size(28, 28)
        Me.ConfigAppButton.ToolTipText = "Config application data"
        '
        'HelpAppButton
        '
        Me.HelpAppButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.HelpAppButton.Image = Global.mSXdevtools.GUI.Controls.My.Resources.Resources.help_x24
        Me.HelpAppButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.HelpAppButton.Name = "HelpAppButton"
        Me.HelpAppButton.Size = New System.Drawing.Size(28, 28)
        Me.HelpAppButton.ToolTipText = "Help"
        '
        'AboutButton
        '
        Me.AboutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AboutButton.Image = Global.mSXdevtools.GUI.Controls.My.Resources.Resources.about_24
        Me.AboutButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AboutButton.Name = "AboutButton"
        Me.AboutButton.Size = New System.Drawing.Size(28, 28)
        Me.AboutButton.ToolTipText = "About MSXtiles devtool"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'PrjImageList
        '
        Me.PrjImageList.ImageStream = CType(resources.GetObject("PrjImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.PrjImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.PrjImageList.Images.SetKeyName(0, "new2_16.png")
        '
        'FilesContextMenuStrip
        '
        Me.FilesContextMenuStrip.Name = "FilesContextMenuStrip"
        Me.FilesContextMenuStrip.Size = New System.Drawing.Size(61, 4)
        '
        'EditorWin
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkGray
        Me.ClientSize = New System.Drawing.Size(624, 461)
        Me.Controls.Add(Me.ProjectToolStrip)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "EditorWin"
        Me.Text = "Editor"
        Me.ProjectToolStrip.ResumeLayout(False)
        Me.ProjectToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ProjectToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents NewButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents LoadButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents LoadRecentButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveAsButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ProjectNameText As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ProjectDataButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EditColorPaletteButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ConfigAppButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents HelpAppButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents AboutButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents PrjImageList As System.Windows.Forms.ImageList
    Friend WithEvents FilesContextMenuStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents GetDataButton As System.Windows.Forms.ToolStripButton

End Class
