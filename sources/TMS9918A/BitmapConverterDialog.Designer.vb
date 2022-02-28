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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BitmapConverterDialog))
        Me.ViewPictureBox = New System.Windows.Forms.PictureBox()
        Me.ToleranceTrackBar = New System.Windows.Forms.TrackBar()
        Me.DetailTrackBar = New System.Windows.Forms.TrackBar()
        Me.ToleranceLabel = New System.Windows.Forms.Label()
        Me.DetailLabel = New System.Windows.Forms.Label()
        Me.ToleranceTextBox = New System.Windows.Forms.TextBox()
        Me.DetailTextBox = New System.Windows.Forms.TextBox()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.DoitButton = New System.Windows.Forms.Button()
        Me.ConvertButton = New System.Windows.Forms.Button()
        Me.PictureNameTextBox = New System.Windows.Forms.TextBox()
        Me.TMS9918Aviewer = New mSXdevtools.GUI.TMS9918A.TMS9918A()
        Me.ConversionTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.AdvancedGroupBox = New System.Windows.Forms.GroupBox()
        CType(Me.ViewPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToleranceTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DetailTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AdvancedGroupBox.SuspendLayout()
        Me.SuspendLayout()
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
        'ToleranceTrackBar
        '
        Me.ToleranceTrackBar.LargeChange = 10
        Me.ToleranceTrackBar.Location = New System.Drawing.Point(107, 29)
        Me.ToleranceTrackBar.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ToleranceTrackBar.Maximum = 100
        Me.ToleranceTrackBar.Name = "ToleranceTrackBar"
        Me.ToleranceTrackBar.Size = New System.Drawing.Size(360, 45)
        Me.ToleranceTrackBar.TabIndex = 1
        Me.ToleranceTrackBar.TickFrequency = 10
        '
        'DetailTrackBar
        '
        Me.DetailTrackBar.LargeChange = 10
        Me.DetailTrackBar.Location = New System.Drawing.Point(107, 80)
        Me.DetailTrackBar.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.DetailTrackBar.Maximum = 255
        Me.DetailTrackBar.Minimum = 1
        Me.DetailTrackBar.Name = "DetailTrackBar"
        Me.DetailTrackBar.Size = New System.Drawing.Size(360, 45)
        Me.DetailTrackBar.TabIndex = 2
        Me.DetailTrackBar.TickFrequency = 25
        Me.DetailTrackBar.Value = 1
        '
        'ToleranceLabel
        '
        Me.ToleranceLabel.Location = New System.Drawing.Point(6, 29)
        Me.ToleranceLabel.Name = "ToleranceLabel"
        Me.ToleranceLabel.Size = New System.Drawing.Size(94, 24)
        Me.ToleranceLabel.TabIndex = 3
        Me.ToleranceLabel.Text = "Tolerance"
        Me.ToleranceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DetailLabel
        '
        Me.DetailLabel.Location = New System.Drawing.Point(6, 80)
        Me.DetailLabel.Name = "DetailLabel"
        Me.DetailLabel.Size = New System.Drawing.Size(94, 24)
        Me.DetailLabel.TabIndex = 4
        Me.DetailLabel.Text = "Detail level"
        Me.DetailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToleranceTextBox
        '
        Me.ToleranceTextBox.Location = New System.Drawing.Point(471, 31)
        Me.ToleranceTextBox.Name = "ToleranceTextBox"
        Me.ToleranceTextBox.Size = New System.Drawing.Size(50, 22)
        Me.ToleranceTextBox.TabIndex = 5
        Me.ToleranceTextBox.Text = "0"
        Me.ToleranceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DetailTextBox
        '
        Me.DetailTextBox.Location = New System.Drawing.Point(471, 80)
        Me.DetailTextBox.Name = "DetailTextBox"
        Me.DetailTextBox.Size = New System.Drawing.Size(50, 22)
        Me.DetailTextBox.TabIndex = 6
        Me.DetailTextBox.Text = "0"
        Me.DetailTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel_Button.BackColor = System.Drawing.Color.LightSalmon
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_Button.Location = New System.Drawing.Point(487, 515)
        Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(70, 30)
        Me.Cancel_Button.TabIndex = 10
        Me.Cancel_Button.Text = "Cancel"
        Me.Cancel_Button.UseVisualStyleBackColor = False
        '
        'DoitButton
        '
        Me.DoitButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DoitButton.BackColor = System.Drawing.Color.PaleGreen
        Me.DoitButton.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.DoitButton.Enabled = False
        Me.DoitButton.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DoitButton.Location = New System.Drawing.Point(370, 509)
        Me.DoitButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DoitButton.Name = "DoitButton"
        Me.DoitButton.Size = New System.Drawing.Size(110, 36)
        Me.DoitButton.TabIndex = 9
        Me.DoitButton.Text = "Ok"
        Me.DoitButton.UseVisualStyleBackColor = False
        '
        'ConvertButton
        '
        Me.ConvertButton.BackColor = System.Drawing.Color.LightBlue
        Me.ConvertButton.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConvertButton.Location = New System.Drawing.Point(393, 139)
        Me.ConvertButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ConvertButton.Name = "ConvertButton"
        Me.ConvertButton.Size = New System.Drawing.Size(128, 32)
        Me.ConvertButton.TabIndex = 11
        Me.ConvertButton.Text = "Convert"
        Me.ConvertButton.UseVisualStyleBackColor = False
        '
        'PictureNameTextBox
        '
        Me.PictureNameTextBox.BackColor = System.Drawing.Color.Gainsboro
        Me.PictureNameTextBox.Location = New System.Drawing.Point(15, 8)
        Me.PictureNameTextBox.Name = "PictureNameTextBox"
        Me.PictureNameTextBox.Size = New System.Drawing.Size(530, 22)
        Me.PictureNameTextBox.TabIndex = 13
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
        'AdvancedGroupBox
        '
        Me.AdvancedGroupBox.Controls.Add(Me.ToleranceLabel)
        Me.AdvancedGroupBox.Controls.Add(Me.ToleranceTrackBar)
        Me.AdvancedGroupBox.Controls.Add(Me.DetailTextBox)
        Me.AdvancedGroupBox.Controls.Add(Me.DetailTrackBar)
        Me.AdvancedGroupBox.Controls.Add(Me.ToleranceTextBox)
        Me.AdvancedGroupBox.Controls.Add(Me.ConvertButton)
        Me.AdvancedGroupBox.Controls.Add(Me.DetailLabel)
        Me.AdvancedGroupBox.Location = New System.Drawing.Point(15, 299)
        Me.AdvancedGroupBox.Name = "AdvancedGroupBox"
        Me.AdvancedGroupBox.Size = New System.Drawing.Size(530, 184)
        Me.AdvancedGroupBox.TabIndex = 17
        Me.AdvancedGroupBox.TabStop = False
        Me.AdvancedGroupBox.Text = "Advanced"
        '
        'BitmapConverterDialog
        '
        Me.AcceptButton = Me.ConvertButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(564, 551)
        Me.Controls.Add(Me.AdvancedGroupBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ConversionTypeComboBox)
        Me.Controls.Add(Me.PictureNameTextBox)
        Me.Controls.Add(Me.TMS9918Aviewer)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.DoitButton)
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
        CType(Me.ViewPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToleranceTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DetailTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AdvancedGroupBox.ResumeLayout(False)
        Me.AdvancedGroupBox.PerformLayout()
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
    Private WithEvents Cancel_Button As Button
    Private WithEvents DoitButton As Button
    Private WithEvents ConvertButton As Button
    Friend WithEvents TMS9918Aviewer As TMS9918A
    Friend WithEvents PictureNameTextBox As TextBox
    Friend WithEvents ConversionTypeComboBox As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents AdvancedGroupBox As GroupBox
End Class
