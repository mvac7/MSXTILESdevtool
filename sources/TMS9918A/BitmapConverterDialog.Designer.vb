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
        Me.ConversionTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.OkPanel = New System.Windows.Forms.Panel()
        Me.ConvertButton = New System.Windows.Forms.Button()
        Me.AdvancedPanel = New System.Windows.Forms.Panel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.info2PictureBox = New System.Windows.Forms.PictureBox()
        Me.info1PictureBox = New System.Windows.Forms.PictureBox()
        Me.ViewPictureBox = New System.Windows.Forms.PictureBox()
        Me.TMS9918Aviewer = New mSXdevtools.GUI.TMS9918A.TMS9918A()
        CType(Me.ToleranceTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DetailTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.OkPanel.SuspendLayout()
        Me.AdvancedPanel.SuspendLayout()
        CType(Me.info2PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.info1PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ViewPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToleranceTrackBar
        '
        Me.ToleranceTrackBar.LargeChange = 10
        Me.ToleranceTrackBar.Location = New System.Drawing.Point(110, 24)
        Me.ToleranceTrackBar.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ToleranceTrackBar.Maximum = 100
        Me.ToleranceTrackBar.Name = "ToleranceTrackBar"
        Me.ToleranceTrackBar.Size = New System.Drawing.Size(320, 45)
        Me.ToleranceTrackBar.TabIndex = 1
        Me.ToleranceTrackBar.TickFrequency = 10
        '
        'DetailTrackBar
        '
        Me.DetailTrackBar.LargeChange = 10
        Me.DetailTrackBar.Location = New System.Drawing.Point(110, 75)
        Me.DetailTrackBar.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.DetailTrackBar.Maximum = 255
        Me.DetailTrackBar.Minimum = 1
        Me.DetailTrackBar.Name = "DetailTrackBar"
        Me.DetailTrackBar.Size = New System.Drawing.Size(320, 45)
        Me.DetailTrackBar.TabIndex = 2
        Me.DetailTrackBar.TickFrequency = 25
        Me.DetailTrackBar.Value = 1
        '
        'ToleranceLabel
        '
        Me.ToleranceLabel.Location = New System.Drawing.Point(9, 24)
        Me.ToleranceLabel.Name = "ToleranceLabel"
        Me.ToleranceLabel.Size = New System.Drawing.Size(94, 24)
        Me.ToleranceLabel.TabIndex = 3
        Me.ToleranceLabel.Text = "Tolerance"
        Me.ToleranceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DetailLabel
        '
        Me.DetailLabel.Location = New System.Drawing.Point(9, 75)
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
        Me.ToleranceTextBox.Location = New System.Drawing.Point(434, 24)
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
        Me.DetailTextBox.Location = New System.Drawing.Point(434, 73)
        Me.DetailTextBox.Name = "DetailTextBox"
        Me.DetailTextBox.Size = New System.Drawing.Size(50, 22)
        Me.DetailTextBox.TabIndex = 6
        Me.DetailTextBox.Text = "0"
        Me.DetailTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PictureNameTextBox
        '
        Me.PictureNameTextBox.BackColor = System.Drawing.Color.Gainsboro
        Me.PictureNameTextBox.ForeColor = System.Drawing.Color.Black
        Me.PictureNameTextBox.Location = New System.Drawing.Point(15, 8)
        Me.PictureNameTextBox.Name = "PictureNameTextBox"
        Me.PictureNameTextBox.ReadOnly = True
        Me.PictureNameTextBox.Size = New System.Drawing.Size(530, 22)
        Me.PictureNameTextBox.TabIndex = 13
        '
        'ConversionTypeComboBox
        '
        Me.ConversionTypeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ConversionTypeComboBox.FormattingEnabled = True
        Me.ConversionTypeComboBox.Items.AddRange(New Object() {"Simple (Fast)", "Advanced (Slow)"})
        Me.ConversionTypeComboBox.Location = New System.Drawing.Point(289, 248)
        Me.ConversionTypeComboBox.Name = "ConversionTypeComboBox"
        Me.ConversionTypeComboBox.Size = New System.Drawing.Size(256, 22)
        Me.ConversionTypeComboBox.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(139, 246)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 24)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Conversion type"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'OkPanel
        '
        Me.OkPanel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.OkPanel.Controls.Add(Me.OK_Button)
        Me.OkPanel.Controls.Add(Me.Cancel_Button)
        Me.OkPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.OkPanel.Location = New System.Drawing.Point(0, 500)
        Me.OkPanel.Name = "OkPanel"
        Me.OkPanel.Padding = New System.Windows.Forms.Padding(4)
        Me.OkPanel.Size = New System.Drawing.Size(564, 51)
        Me.OkPanel.TabIndex = 28
        '
        'ConvertButton
        '
        Me.ConvertButton.BackColor = System.Drawing.Color.Transparent
        Me.ConvertButton.FlatAppearance.BorderSize = 0
        Me.ConvertButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ConvertButton.ForeColor = System.Drawing.Color.LightGray
        Me.ConvertButton.Image = Global.mSXdevtools.GUI.TMS9918A.My.Resources.Resources.button_convert
        Me.ConvertButton.Location = New System.Drawing.Point(387, 126)
        Me.ConvertButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ConvertButton.Name = "ConvertButton"
        Me.ConvertButton.Size = New System.Drawing.Size(132, 43)
        Me.ConvertButton.TabIndex = 11
        Me.ConvertButton.UseVisualStyleBackColor = False
        '
        'AdvancedPanel
        '
        Me.AdvancedPanel.BackColor = System.Drawing.Color.LightGray
        Me.AdvancedPanel.BackgroundImage = Global.mSXdevtools.GUI.TMS9918A.My.Resources.Resources.panel_Advanced
        Me.AdvancedPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.AdvancedPanel.Controls.Add(Me.info2PictureBox)
        Me.AdvancedPanel.Controls.Add(Me.ToleranceLabel)
        Me.AdvancedPanel.Controls.Add(Me.info1PictureBox)
        Me.AdvancedPanel.Controls.Add(Me.DetailLabel)
        Me.AdvancedPanel.Controls.Add(Me.ConvertButton)
        Me.AdvancedPanel.Controls.Add(Me.ToleranceTrackBar)
        Me.AdvancedPanel.Controls.Add(Me.ToleranceTextBox)
        Me.AdvancedPanel.Controls.Add(Me.DetailTextBox)
        Me.AdvancedPanel.Controls.Add(Me.DetailTrackBar)
        Me.AdvancedPanel.ForeColor = System.Drawing.Color.Black
        Me.AdvancedPanel.Location = New System.Drawing.Point(15, 300)
        Me.AdvancedPanel.Name = "AdvancedPanel"
        Me.AdvancedPanel.Size = New System.Drawing.Size(530, 182)
        Me.AdvancedPanel.TabIndex = 29
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
        'info2PictureBox
        '
        Me.info2PictureBox.Image = Global.mSXdevtools.GUI.TMS9918A.My.Resources.Resources.info_blue_16
        Me.info2PictureBox.Location = New System.Drawing.Point(490, 75)
        Me.info2PictureBox.Name = "info2PictureBox"
        Me.info2PictureBox.Size = New System.Drawing.Size(16, 16)
        Me.info2PictureBox.TabIndex = 13
        Me.info2PictureBox.TabStop = False
        Me.ToolTip1.SetToolTip(Me.info2PictureBox, "Detail level (1 to 255)")
        '
        'info1PictureBox
        '
        Me.info1PictureBox.Image = Global.mSXdevtools.GUI.TMS9918A.My.Resources.Resources.info_blue_16
        Me.info1PictureBox.Location = New System.Drawing.Point(490, 27)
        Me.info1PictureBox.Name = "info1PictureBox"
        Me.info1PictureBox.Size = New System.Drawing.Size(16, 16)
        Me.info1PictureBox.TabIndex = 12
        Me.info1PictureBox.TabStop = False
        Me.ToolTip1.SetToolTip(Me.info1PictureBox, resources.GetString("info1PictureBox.ToolTip"))
        '
        'ViewPictureBox
        '
        Me.ViewPictureBox.BackColor = System.Drawing.Color.Black
        Me.ViewPictureBox.Location = New System.Drawing.Point(15, 36)
        Me.ViewPictureBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ViewPictureBox.Name = "ViewPictureBox"
        Me.ViewPictureBox.Size = New System.Drawing.Size(256, 192)
        Me.ViewPictureBox.TabIndex = 0
        Me.ViewPictureBox.TabStop = False
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
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(564, 551)
        Me.Controls.Add(Me.AdvancedPanel)
        Me.Controls.Add(Me.OkPanel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ConversionTypeComboBox)
        Me.Controls.Add(Me.PictureNameTextBox)
        Me.Controls.Add(Me.TMS9918Aviewer)
        Me.Controls.Add(Me.ViewPictureBox)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BitmapConverterDialog"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Bitmap Converter"
        CType(Me.ToleranceTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DetailTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.OkPanel.ResumeLayout(False)
        Me.AdvancedPanel.ResumeLayout(False)
        Me.AdvancedPanel.PerformLayout()
        CType(Me.info2PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.info1PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ViewPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents ConversionTypeComboBox As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents info1PictureBox As PictureBox
    Friend WithEvents info2PictureBox As PictureBox
    Friend WithEvents OkPanel As Panel
    Friend WithEvents OK_Button As Button
    Private WithEvents Cancel_Button As Button
    Friend WithEvents AdvancedPanel As Panel
End Class
