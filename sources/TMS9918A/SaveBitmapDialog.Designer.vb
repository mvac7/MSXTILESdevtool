<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SaveBitmapDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SaveBitmapDialog))
        Me.x2CheckBox = New System.Windows.Forms.CheckBox()
        Me.ViewModeComboBox = New System.Windows.Forms.ComboBox()
        Me.ViewLabel = New System.Windows.Forms.Label()
        Me.Save_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.NameTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.TMS9918Aviewer = New mSXdevtools.GUI.TMS9918A.TMS9918A()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'x2CheckBox
        '
        Me.x2CheckBox.AutoSize = True
        Me.x2CheckBox.Location = New System.Drawing.Point(65, 266)
        Me.x2CheckBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.x2CheckBox.Name = "x2CheckBox"
        Me.x2CheckBox.Size = New System.Drawing.Size(110, 18)
        Me.x2CheckBox.TabIndex = 1
        Me.x2CheckBox.Text = "x2 (512x384)"
        Me.x2CheckBox.UseVisualStyleBackColor = True
        Me.x2CheckBox.Visible = False
        '
        'ViewModeComboBox
        '
        Me.ViewModeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ViewModeComboBox.ForeColor = System.Drawing.Color.Black
        Me.ViewModeComboBox.FormattingEnabled = True
        Me.ViewModeComboBox.Items.AddRange(New Object() {"All (map + sprites)", "Map", "Tileset", "Sprites (32 layers)", "Sprites (patterns)"})
        Me.ViewModeComboBox.Location = New System.Drawing.Point(65, 238)
        Me.ViewModeComboBox.Name = "ViewModeComboBox"
        Me.ViewModeComboBox.Size = New System.Drawing.Size(211, 22)
        Me.ViewModeComboBox.TabIndex = 2
        '
        'ViewLabel
        '
        Me.ViewLabel.Location = New System.Drawing.Point(0, 238)
        Me.ViewLabel.Name = "ViewLabel"
        Me.ViewLabel.Size = New System.Drawing.Size(59, 22)
        Me.ViewLabel.TabIndex = 3
        Me.ViewLabel.Text = "View:"
        Me.ViewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Save_Button
        '
        Me.Save_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Save_Button.BackColor = System.Drawing.Color.PaleGreen
        Me.Save_Button.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Save_Button.Location = New System.Drawing.Point(112, 306)
        Me.Save_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.Save_Button.Name = "Save_Button"
        Me.Save_Button.Size = New System.Drawing.Size(100, 40)
        Me.Save_Button.TabIndex = 4
        Me.Save_Button.Text = "Save"
        Me.Save_Button.UseVisualStyleBackColor = False
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel_Button.BackColor = System.Drawing.Color.LightSalmon
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_Button.Location = New System.Drawing.Point(220, 316)
        Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(70, 30)
        Me.Cancel_Button.TabIndex = 5
        Me.Cancel_Button.Text = "Exit"
        Me.Cancel_Button.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NameTextBox})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(294, 25)
        Me.ToolStrip1.TabIndex = 18
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'NameTextBox
        '
        Me.NameTextBox.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.ReadOnly = True
        Me.NameTextBox.Size = New System.Drawing.Size(255, 25)
        '
        'TMS9918Aviewer
        '
        Me.TMS9918Aviewer.BackgroundColor = CType(4, Byte)
        Me.TMS9918Aviewer.BackgroundImage = CType(resources.GetObject("TMS9918Aviewer.BackgroundImage"), System.Drawing.Image)
        Me.TMS9918Aviewer.BorderColor = CType(4, Byte)
        Me.TMS9918Aviewer.ControlType = mSXdevtools.GUI.TMS9918A.TMS9918A.CONTROL_TYPE.VIEWER
        Me.TMS9918Aviewer.InkColor = CType(15, Byte)
        Me.TMS9918Aviewer.IsShowSprites = True
        Me.TMS9918Aviewer.Location = New System.Drawing.Point(20, 40)
        Me.TMS9918Aviewer.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.TMS9918Aviewer.Name = "TMS9918Aviewer"
        Me.TMS9918Aviewer.ScreenMode = mSXdevtools.DataStructures.iVDP.SCREEN_MODE.G2
        Me.TMS9918Aviewer.Size = New System.Drawing.Size(256, 192)
        Me.TMS9918Aviewer.SpriteSize = mSXdevtools.DataStructures.SpriteMSX.SPRITE_SIZE.SIZE16
        Me.TMS9918Aviewer.SpriteZoom = mSXdevtools.DataStructures.iVDP.SPRITE_ZOOM.X1
        Me.TMS9918Aviewer.TabIndex = 0
        Me.TMS9918Aviewer.ViewMode = mSXdevtools.GUI.TMS9918A.TMS9918A.VIEW_MODE.ALL
        Me.TMS9918Aviewer.ViewSize = mSXdevtools.GUI.TMS9918A.TMS9918A.VIEW_SIZE.x1
        '
        'SaveBitmapDialog
        '
        Me.AcceptButton = Me.Save_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(294, 350)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Save_Button)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.ViewLabel)
        Me.Controls.Add(Me.ViewModeComboBox)
        Me.Controls.Add(Me.x2CheckBox)
        Me.Controls.Add(Me.TMS9918Aviewer)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SaveBitmapDialog"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Save Bitmap"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TMS9918Aviewer As mSXdevtools.GUI.TMS9918A.TMS9918A
    Friend WithEvents x2CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ViewModeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ViewLabel As System.Windows.Forms.Label
    Friend WithEvents Save_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents NameTextBox As System.Windows.Forms.ToolStripTextBox
End Class
