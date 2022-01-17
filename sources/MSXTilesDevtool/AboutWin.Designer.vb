<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutWin
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

    Friend WithEvents TextBoxDescription As System.Windows.Forms.TextBox
    Friend WithEvents OKButton As System.Windows.Forms.Button

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutWin))
        Me.TextBoxDescription = New System.Windows.Forms.TextBox
        Me.OKButton = New System.Windows.Forms.Button
        Me.iconcolumnPictureBox = New System.Windows.Forms.PictureBox
        Me.logoPictureBox = New System.Windows.Forms.PictureBox
        Me.copyleftLabel = New System.Windows.Forms.Label
        Me.versionLabel = New System.Windows.Forms.Label
        Me.GPLButton = New System.Windows.Forms.Button
        Me.link303bcnPictureBox = New System.Windows.Forms.PictureBox
        CType(Me.iconcolumnPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.logoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.link303bcnPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBoxDescription
        '
        Me.TextBoxDescription.BackColor = System.Drawing.Color.LightGray
        Me.TextBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxDescription.Location = New System.Drawing.Point(154, 150)
        Me.TextBoxDescription.Margin = New System.Windows.Forms.Padding(7, 3, 3, 3)
        Me.TextBoxDescription.Multiline = True
        Me.TextBoxDescription.Name = "TextBoxDescription"
        Me.TextBoxDescription.ReadOnly = True
        Me.TextBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxDescription.Size = New System.Drawing.Size(400, 154)
        Me.TextBoxDescription.TabIndex = 0
        Me.TextBoxDescription.TabStop = False
        Me.TextBoxDescription.Text = resources.GetString("TextBoxDescription.Text")
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.BackColor = System.Drawing.Color.PaleGreen
        Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OKButton.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OKButton.Location = New System.Drawing.Point(460, 320)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(80, 32)
        Me.OKButton.TabIndex = 0
        Me.OKButton.Text = "Ok"
        Me.OKButton.UseVisualStyleBackColor = False
        '
        'iconcolumnPictureBox
        '
        Me.iconcolumnPictureBox.BackgroundImage = Global.MSXTILESdevtool.My.Resources.Resources.aboutleftcolumn_128
        Me.iconcolumnPictureBox.Location = New System.Drawing.Point(4, 4)
        Me.iconcolumnPictureBox.Name = "iconcolumnPictureBox"
        Me.iconcolumnPictureBox.Size = New System.Drawing.Size(128, 360)
        Me.iconcolumnPictureBox.TabIndex = 1
        Me.iconcolumnPictureBox.TabStop = False
        '
        'logoPictureBox
        '
        Me.logoPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.logoPictureBox.Image = Global.MSXTILESdevtool.My.Resources.Resources.MSXTILESdevtool_logo
        Me.logoPictureBox.Location = New System.Drawing.Point(154, 22)
        Me.logoPictureBox.Name = "logoPictureBox"
        Me.logoPictureBox.Size = New System.Drawing.Size(390, 50)
        Me.logoPictureBox.TabIndex = 2
        Me.logoPictureBox.TabStop = False
        '
        'copyleftLabel
        '
        Me.copyleftLabel.BackColor = System.Drawing.Color.Transparent
        Me.copyleftLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.copyleftLabel.Location = New System.Drawing.Point(152, 120)
        Me.copyleftLabel.Name = "copyleftLabel"
        Me.copyleftLabel.Size = New System.Drawing.Size(380, 18)
        Me.copyleftLabel.TabIndex = 3
        Me.copyleftLabel.Text = "copyleft"
        '
        'versionLabel
        '
        Me.versionLabel.BackColor = System.Drawing.Color.Transparent
        Me.versionLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.versionLabel.Location = New System.Drawing.Point(152, 80)
        Me.versionLabel.Name = "versionLabel"
        Me.versionLabel.Size = New System.Drawing.Size(380, 18)
        Me.versionLabel.TabIndex = 4
        Me.versionLabel.Text = "version"
        Me.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GPLButton
        '
        Me.GPLButton.BackColor = System.Drawing.Color.Transparent
        Me.GPLButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.GPLButton.FlatAppearance.BorderSize = 0
        Me.GPLButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GPLButton.Image = Global.MSXTILESdevtool.My.Resources.Resources.gplv3_88x31
        Me.GPLButton.Location = New System.Drawing.Point(144, 314)
        Me.GPLButton.Name = "GPLButton"
        Me.GPLButton.Size = New System.Drawing.Size(100, 40)
        Me.GPLButton.TabIndex = 5
        Me.GPLButton.UseVisualStyleBackColor = False
        '
        'link303bcnPictureBox
        '
        Me.link303bcnPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.link303bcnPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.link303bcnPictureBox.Location = New System.Drawing.Point(476, 368)
        Me.link303bcnPictureBox.Name = "link303bcnPictureBox"
        Me.link303bcnPictureBox.Size = New System.Drawing.Size(71, 16)
        Me.link303bcnPictureBox.TabIndex = 7
        Me.link303bcnPictureBox.TabStop = False
        '
        'AboutWin
        '
        Me.AcceptButton = Me.OKButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Thistle
        Me.BackgroundImage = Global.MSXTILESdevtool.My.Resources.Resources.aboutwin_BGH
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CancelButton = Me.OKButton
        Me.ClientSize = New System.Drawing.Size(558, 384)
        Me.ControlBox = False
        Me.Controls.Add(Me.link303bcnPictureBox)
        Me.Controls.Add(Me.GPLButton)
        Me.Controls.Add(Me.versionLabel)
        Me.Controls.Add(Me.copyleftLabel)
        Me.Controls.Add(Me.logoPictureBox)
        Me.Controls.Add(Me.iconcolumnPictureBox)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.TextBoxDescription)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AboutWin"
        Me.Padding = New System.Windows.Forms.Padding(10, 9, 10, 9)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About"
        Me.TransparencyKey = System.Drawing.Color.Thistle
        CType(Me.iconcolumnPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.logoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.link303bcnPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents iconcolumnPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents logoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents copyleftLabel As System.Windows.Forms.Label
    Friend WithEvents versionLabel As System.Windows.Forms.Label
    Friend WithEvents GPLButton As System.Windows.Forms.Button
    Friend WithEvents link303bcnPictureBox As System.Windows.Forms.PictureBox

End Class
