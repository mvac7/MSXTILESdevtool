<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BitmapConverterDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BitmapConverterDialog))
        Me.ToleranceTrackBar = New System.Windows.Forms.TrackBar()
        Me.DetailTrackBar = New System.Windows.Forms.TrackBar()
        Me.ToleranceLabel = New System.Windows.Forms.Label()
        Me.DetailLabel = New System.Windows.Forms.Label()
        Me.ToleranceTextBox = New System.Windows.Forms.TextBox()
        Me.DetailTextBox = New System.Windows.Forms.TextBox()
        Me.PictureNameTextBox = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.AboutLabel = New System.Windows.Forms.Label()
        Me.OkPanel = New System.Windows.Forms.Panel()
        Me.AdvancedPanel = New System.Windows.Forms.Panel()
        Me.TabImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.SimplePanel = New System.Windows.Forms.Panel()
        Me.BGcolorLabel = New System.Windows.Forms.Label()
        Me.BGColorButton = New mSXdevtools.GUI.Controls.ColorButton()
        Me.ConvertButton = New System.Windows.Forms.Button()
        Me.SourceBitmapPanel = New System.Windows.Forms.Panel()
        Me.ViewPictureBox = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.AdvancedTabButton = New System.Windows.Forms.Button()
        Me.info2PictureBox = New System.Windows.Forms.PictureBox()
        Me.info1PictureBox = New System.Windows.Forms.PictureBox()
        Me.SimpleTabButton = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.BorderColorButton = New mSXdevtools.GUI.Controls.ColorButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TMS9918Aviewer = New mSXdevtools.GUI.TMS9918A.TMS9918A()
        CType(Me.ToleranceTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DetailTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.OkPanel.SuspendLayout()
        Me.AdvancedPanel.SuspendLayout()
        Me.SimplePanel.SuspendLayout()
        Me.SourceBitmapPanel.SuspendLayout()
        CType(Me.ViewPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.info2PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.info1PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToleranceTrackBar
        '
        Me.ToleranceTrackBar.AutoSize = False
        Me.ToleranceTrackBar.LargeChange = 10
        Me.ToleranceTrackBar.Location = New System.Drawing.Point(110, 13)
        Me.ToleranceTrackBar.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ToleranceTrackBar.Maximum = 100
        Me.ToleranceTrackBar.Name = "ToleranceTrackBar"
        Me.ToleranceTrackBar.Size = New System.Drawing.Size(320, 33)
        Me.ToleranceTrackBar.TabIndex = 1
        Me.ToleranceTrackBar.TickFrequency = 10
        '
        'DetailTrackBar
        '
        Me.DetailTrackBar.AutoSize = False
        Me.DetailTrackBar.LargeChange = 10
        Me.DetailTrackBar.Location = New System.Drawing.Point(110, 52)
        Me.DetailTrackBar.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.DetailTrackBar.Maximum = 255
        Me.DetailTrackBar.Minimum = 1
        Me.DetailTrackBar.Name = "DetailTrackBar"
        Me.DetailTrackBar.Size = New System.Drawing.Size(320, 33)
        Me.DetailTrackBar.TabIndex = 2
        Me.DetailTrackBar.TickFrequency = 25
        Me.DetailTrackBar.Value = 1
        '
        'ToleranceLabel
        '
        Me.ToleranceLabel.Location = New System.Drawing.Point(9, 13)
        Me.ToleranceLabel.Name = "ToleranceLabel"
        Me.ToleranceLabel.Size = New System.Drawing.Size(94, 24)
        Me.ToleranceLabel.TabIndex = 3
        Me.ToleranceLabel.Text = "Tolerance"
        Me.ToleranceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DetailLabel
        '
        Me.DetailLabel.Location = New System.Drawing.Point(9, 52)
        Me.DetailLabel.Name = "DetailLabel"
        Me.DetailLabel.Size = New System.Drawing.Size(94, 24)
        Me.DetailLabel.TabIndex = 4
        Me.DetailLabel.Text = "Detail level"
        Me.DetailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToleranceTextBox
        '
        Me.ToleranceTextBox.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ToleranceTextBox.ForeColor = System.Drawing.Color.Black
        Me.ToleranceTextBox.Location = New System.Drawing.Point(434, 13)
        Me.ToleranceTextBox.Name = "ToleranceTextBox"
        Me.ToleranceTextBox.Size = New System.Drawing.Size(50, 22)
        Me.ToleranceTextBox.TabIndex = 5
        Me.ToleranceTextBox.Text = "0"
        Me.ToleranceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DetailTextBox
        '
        Me.DetailTextBox.BackColor = System.Drawing.Color.WhiteSmoke
        Me.DetailTextBox.ForeColor = System.Drawing.Color.Black
        Me.DetailTextBox.Location = New System.Drawing.Point(434, 50)
        Me.DetailTextBox.Name = "DetailTextBox"
        Me.DetailTextBox.Size = New System.Drawing.Size(50, 22)
        Me.DetailTextBox.TabIndex = 6
        Me.DetailTextBox.Text = "0"
        Me.DetailTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PictureNameTextBox
        '
        Me.PictureNameTextBox.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PictureNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureNameTextBox.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PictureNameTextBox.ForeColor = System.Drawing.Color.Black
        Me.PictureNameTextBox.Location = New System.Drawing.Point(15, 8)
        Me.PictureNameTextBox.Name = "PictureNameTextBox"
        Me.PictureNameTextBox.ReadOnly = True
        Me.PictureNameTextBox.Size = New System.Drawing.Size(530, 23)
        Me.PictureNameTextBox.TabIndex = 13
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'AboutLabel
        '
        Me.AboutLabel.BackColor = System.Drawing.Color.Transparent
        Me.AboutLabel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.AboutLabel.ForeColor = System.Drawing.Color.DimGray
        Me.AboutLabel.Location = New System.Drawing.Point(0, 90)
        Me.AboutLabel.Name = "AboutLabel"
        Me.AboutLabel.Size = New System.Drawing.Size(530, 30)
        Me.AboutLabel.TabIndex = 14
        Me.AboutLabel.Text = "MSX-GCR 1.0"
        Me.AboutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.AboutLabel, "MSX-GCR 1.0 (MSX Graphic Conversion Routine) by Leandro Correia")
        '
        'OkPanel
        '
        Me.OkPanel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.OkPanel.Controls.Add(Me.OK_Button)
        Me.OkPanel.Controls.Add(Me.Cancel_Button)
        Me.OkPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.OkPanel.Location = New System.Drawing.Point(0, 576)
        Me.OkPanel.Name = "OkPanel"
        Me.OkPanel.Padding = New System.Windows.Forms.Padding(4)
        Me.OkPanel.Size = New System.Drawing.Size(564, 51)
        Me.OkPanel.TabIndex = 28
        '
        'AdvancedPanel
        '
        Me.AdvancedPanel.BackColor = System.Drawing.Color.Silver
        Me.AdvancedPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.AdvancedPanel.Controls.Add(Me.AboutLabel)
        Me.AdvancedPanel.Controls.Add(Me.info2PictureBox)
        Me.AdvancedPanel.Controls.Add(Me.ToleranceLabel)
        Me.AdvancedPanel.Controls.Add(Me.info1PictureBox)
        Me.AdvancedPanel.Controls.Add(Me.DetailLabel)
        Me.AdvancedPanel.Controls.Add(Me.ToleranceTrackBar)
        Me.AdvancedPanel.Controls.Add(Me.ToleranceTextBox)
        Me.AdvancedPanel.Controls.Add(Me.DetailTextBox)
        Me.AdvancedPanel.Controls.Add(Me.DetailTrackBar)
        Me.AdvancedPanel.ForeColor = System.Drawing.Color.Black
        Me.AdvancedPanel.Location = New System.Drawing.Point(15, 386)
        Me.AdvancedPanel.Name = "AdvancedPanel"
        Me.AdvancedPanel.Size = New System.Drawing.Size(530, 120)
        Me.AdvancedPanel.TabIndex = 29
        '
        'TabImageList
        '
        Me.TabImageList.ImageStream = CType(resources.GetObject("TabImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.TabImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.TabImageList.Images.SetKeyName(0, "tab0_select.png")
        Me.TabImageList.Images.SetKeyName(1, "tab0_unselect.png")
        Me.TabImageList.Images.SetKeyName(2, "tab1_select.png")
        Me.TabImageList.Images.SetKeyName(3, "tab1_unselect.png")
        '
        'SimplePanel
        '
        Me.SimplePanel.BackColor = System.Drawing.Color.Silver
        Me.SimplePanel.Controls.Add(Me.PictureBox1)
        Me.SimplePanel.Controls.Add(Me.BGColorButton)
        Me.SimplePanel.Controls.Add(Me.BGcolorLabel)
        Me.SimplePanel.Location = New System.Drawing.Point(15, 280)
        Me.SimplePanel.Name = "SimplePanel"
        Me.SimplePanel.Size = New System.Drawing.Size(530, 100)
        Me.SimplePanel.TabIndex = 32
        '
        'BGcolorLabel
        '
        Me.BGcolorLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BGcolorLabel.ForeColor = System.Drawing.Color.Black
        Me.BGcolorLabel.Location = New System.Drawing.Point(9, 31)
        Me.BGcolorLabel.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.BGcolorLabel.Name = "BGcolorLabel"
        Me.BGcolorLabel.Size = New System.Drawing.Size(146, 22)
        Me.BGcolorLabel.TabIndex = 259
        Me.BGcolorLabel.Text = "Background Color:"
        Me.BGcolorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BGColorButton
        '
        Me.BGColorButton.Location = New System.Drawing.Point(159, 28)
        Me.BGColorButton.Margin = New System.Windows.Forms.Padding(9, 3, 9, 3)
        Me.BGColorButton.Name = "BGColorButton"
        Me.BGColorButton.Size = New System.Drawing.Size(57, 28)
        Me.BGColorButton.TabIndex = 258
        Me.ToolTip1.SetToolTip(Me.BGColorButton, "Color priority to use as a background in the conversion.")
        '
        'ConvertButton
        '
        Me.ConvertButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ConvertButton.BackColor = System.Drawing.Color.Transparent
        Me.ConvertButton.FlatAppearance.BorderSize = 0
        Me.ConvertButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ConvertButton.ForeColor = System.Drawing.Color.LightGray
        Me.ConvertButton.Image = Global.mSXdevtools.GUI.TMS9918A.My.Resources.Resources.button_convert
        Me.ConvertButton.Location = New System.Drawing.Point(413, 515)
        Me.ConvertButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ConvertButton.Name = "ConvertButton"
        Me.ConvertButton.Size = New System.Drawing.Size(132, 43)
        Me.ConvertButton.TabIndex = 11
        Me.ConvertButton.UseVisualStyleBackColor = False
        '
        'SourceBitmapPanel
        '
        Me.SourceBitmapPanel.BackgroundImage = Global.mSXdevtools.GUI.TMS9918A.My.Resources.Resources.transparent8x8_BG
        Me.SourceBitmapPanel.Controls.Add(Me.ViewPictureBox)
        Me.SourceBitmapPanel.Location = New System.Drawing.Point(16, 37)
        Me.SourceBitmapPanel.Name = "SourceBitmapPanel"
        Me.SourceBitmapPanel.Size = New System.Drawing.Size(256, 192)
        Me.SourceBitmapPanel.TabIndex = 33
        '
        'ViewPictureBox
        '
        Me.ViewPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.ViewPictureBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewPictureBox.Location = New System.Drawing.Point(0, 0)
        Me.ViewPictureBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ViewPictureBox.Name = "ViewPictureBox"
        Me.ViewPictureBox.Size = New System.Drawing.Size(256, 192)
        Me.ViewPictureBox.TabIndex = 0
        Me.ViewPictureBox.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.mSXdevtools.GUI.TMS9918A.My.Resources.Resources.info_blue_16
        Me.PictureBox1.Location = New System.Drawing.Point(224, 34)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.TabIndex = 260
        Me.PictureBox1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox1, "Color that will always be assigned as the background color.")
        '
        'AdvancedTabButton
        '
        Me.AdvancedTabButton.BackColor = System.Drawing.Color.Transparent
        Me.AdvancedTabButton.FlatAppearance.BorderSize = 0
        Me.AdvancedTabButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AdvancedTabButton.ImageIndex = 3
        Me.AdvancedTabButton.ImageList = Me.TabImageList
        Me.AdvancedTabButton.Location = New System.Drawing.Point(141, 247)
        Me.AdvancedTabButton.Name = "AdvancedTabButton"
        Me.AdvancedTabButton.Size = New System.Drawing.Size(125, 33)
        Me.AdvancedTabButton.TabIndex = 31
        Me.AdvancedTabButton.UseVisualStyleBackColor = False
        '
        'info2PictureBox
        '
        Me.info2PictureBox.Image = Global.mSXdevtools.GUI.TMS9918A.My.Resources.Resources.info_blue_16
        Me.info2PictureBox.Location = New System.Drawing.Point(490, 52)
        Me.info2PictureBox.Name = "info2PictureBox"
        Me.info2PictureBox.Size = New System.Drawing.Size(16, 16)
        Me.info2PictureBox.TabIndex = 13
        Me.info2PictureBox.TabStop = False
        Me.ToolTip1.SetToolTip(Me.info2PictureBox, "Detail level (1 to 255)")
        '
        'info1PictureBox
        '
        Me.info1PictureBox.Image = Global.mSXdevtools.GUI.TMS9918A.My.Resources.Resources.info_blue_16
        Me.info1PictureBox.Location = New System.Drawing.Point(490, 16)
        Me.info1PictureBox.Name = "info1PictureBox"
        Me.info1PictureBox.Size = New System.Drawing.Size(16, 16)
        Me.info1PictureBox.TabIndex = 12
        Me.info1PictureBox.TabStop = False
        Me.ToolTip1.SetToolTip(Me.info1PictureBox, resources.GetString("info1PictureBox.ToolTip"))
        '
        'SimpleTabButton
        '
        Me.SimpleTabButton.BackColor = System.Drawing.Color.Transparent
        Me.SimpleTabButton.FlatAppearance.BorderSize = 0
        Me.SimpleTabButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SimpleTabButton.ImageIndex = 0
        Me.SimpleTabButton.ImageList = Me.TabImageList
        Me.SimpleTabButton.Location = New System.Drawing.Point(14, 247)
        Me.SimpleTabButton.Name = "SimpleTabButton"
        Me.SimpleTabButton.Size = New System.Drawing.Size(125, 33)
        Me.SimpleTabButton.TabIndex = 30
        Me.SimpleTabButton.UseVisualStyleBackColor = False
        '
        'OK_Button
        '
        Me.OK_Button.BackColor = System.Drawing.Color.Transparent
        Me.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OK_Button.Dock = System.Windows.Forms.DockStyle.Right
        Me.OK_Button.Enabled = False
        Me.OK_Button.FlatAppearance.BorderSize = 0
        Me.OK_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OK_Button.Image = Global.mSXdevtools.GUI.TMS9918A.My.Resources.Resources.button_Ok
        Me.OK_Button.Location = New System.Drawing.Point(318, 4)
        Me.OK_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(132, 43)
        Me.OK_Button.TabIndex = 9
        Me.OK_Button.UseVisualStyleBackColor = False
        '
        'Cancel_Button
        '
        Me.Cancel_Button.BackColor = System.Drawing.Color.Transparent
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Dock = System.Windows.Forms.DockStyle.Right
        Me.Cancel_Button.FlatAppearance.BorderSize = 0
        Me.Cancel_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cancel_Button.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_Button.Image = Global.mSXdevtools.GUI.TMS9918A.My.Resources.Resources.button_Cancel
        Me.Cancel_Button.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Cancel_Button.Location = New System.Drawing.Point(450, 4)
        Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(110, 43)
        Me.Cancel_Button.TabIndex = 280
        Me.Cancel_Button.UseVisualStyleBackColor = False
        '
        'BorderColorButton
        '
        Me.BorderColorButton.Location = New System.Drawing.Point(505, 230)
        Me.BorderColorButton.Margin = New System.Windows.Forms.Padding(12, 3, 12, 3)
        Me.BorderColorButton.Name = "BorderColorButton"
        Me.BorderColorButton.Size = New System.Drawing.Size(40, 24)
        Me.BorderColorButton.TabIndex = 259
        Me.ToolTip1.SetToolTip(Me.BorderColorButton, "Color priority to use as a background in the conversion.")
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(289, 231)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(212, 22)
        Me.Label1.TabIndex = 260
        Me.Label1.Text = "Border Color:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.TMS9918Aviewer.Location = New System.Drawing.Point(289, 36)
        Me.TMS9918Aviewer.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TMS9918Aviewer.Name = "TMS9918Aviewer"
        Me.TMS9918Aviewer.ScreenMode = mSXdevtools.DataStructures.iVDP.SCREEN_MODE.G2
        Me.TMS9918Aviewer.Size = New System.Drawing.Size(256, 192)
        Me.TMS9918Aviewer.SpriteSize = mSXdevtools.DataStructures.SpriteMSX.SPRITE_SIZE.SIZE16
        Me.TMS9918Aviewer.SpriteZoom = mSXdevtools.DataStructures.iVDP.SPRITE_ZOOM.X1
        Me.TMS9918Aviewer.TabIndex = 12
        Me.TMS9918Aviewer.ViewMode = mSXdevtools.GUI.TMS9918A.TMS9918A.VIEW_MODE.ALL
        Me.TMS9918Aviewer.ViewSize = mSXdevtools.GUI.TMS9918A.TMS9918A.VIEW_SIZE.x1
        '
        'BitmapConverterDialog
        '
        Me.AcceptButton = Me.ConvertButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(564, 627)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BorderColorButton)
        Me.Controls.Add(Me.SourceBitmapPanel)
        Me.Controls.Add(Me.SimplePanel)
        Me.Controls.Add(Me.AdvancedTabButton)
        Me.Controls.Add(Me.AdvancedPanel)
        Me.Controls.Add(Me.SimpleTabButton)
        Me.Controls.Add(Me.OkPanel)
        Me.Controls.Add(Me.ConvertButton)
        Me.Controls.Add(Me.PictureNameTextBox)
        Me.Controls.Add(Me.TMS9918Aviewer)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BitmapConverterDialog"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Bitmap to TMS9918A G2 Converter"
        CType(Me.ToleranceTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DetailTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.OkPanel.ResumeLayout(False)
        Me.AdvancedPanel.ResumeLayout(False)
        Me.AdvancedPanel.PerformLayout()
        Me.SimplePanel.ResumeLayout(False)
        Me.SourceBitmapPanel.ResumeLayout(False)
        CType(Me.ViewPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.info2PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.info1PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ViewPictureBox As PictureBox
    Friend WithEvents ToleranceTrackBar As TrackBar
    Friend WithEvents DetailTrackBar As TrackBar
    Friend WithEvents ToleranceLabel As Label
    Friend WithEvents DetailLabel As Label
    Friend WithEvents ToleranceTextBox As TextBox
    Friend WithEvents DetailTextBox As TextBox
    Private WithEvents ConvertButton As Button
    Friend WithEvents TMS9918Aviewer As TMS9918A
    Friend WithEvents PictureNameTextBox As TextBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents info1PictureBox As PictureBox
    Friend WithEvents info2PictureBox As PictureBox
    Friend WithEvents OkPanel As Panel
    Friend WithEvents OK_Button As Button
    Private WithEvents Cancel_Button As Button
    Friend WithEvents AdvancedPanel As Panel
    Friend WithEvents SimpleTabButton As Button
    Friend WithEvents AdvancedTabButton As Button
    Friend WithEvents SimplePanel As Panel
    Friend WithEvents BGColorButton As ColorButton
    Friend WithEvents BGcolorLabel As Label
    Friend WithEvents AboutLabel As Label
    Friend WithEvents TabImageList As ImageList
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents SourceBitmapPanel As Panel
    Friend WithEvents BorderColorButton As ColorButton
    Friend WithEvents Label1 As Label
End Class
