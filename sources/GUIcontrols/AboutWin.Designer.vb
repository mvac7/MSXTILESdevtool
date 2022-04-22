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

    Friend WithEvents LicenseTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OKButton As System.Windows.Forms.Button

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutWin))
        Me.LicenseTextBox = New System.Windows.Forms.TextBox()
        Me.copyleftLabel = New System.Windows.Forms.Label()
        Me.versionLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DescriptionLabel = New System.Windows.Forms.Label()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.LicenseButton = New System.Windows.Forms.Button()
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.iconPictureBox = New System.Windows.Forms.PictureBox()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.iconPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LicenseTextBox
        '
        Me.LicenseTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LicenseTextBox.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LicenseTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LicenseTextBox.Location = New System.Drawing.Point(150, 211)
        Me.LicenseTextBox.Margin = New System.Windows.Forms.Padding(7, 3, 3, 3)
        Me.LicenseTextBox.Multiline = True
        Me.LicenseTextBox.Name = "LicenseTextBox"
        Me.LicenseTextBox.ReadOnly = True
        Me.LicenseTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.LicenseTextBox.Size = New System.Drawing.Size(449, 140)
        Me.LicenseTextBox.TabIndex = 0
        Me.LicenseTextBox.TabStop = False
        Me.LicenseTextBox.Text = "License...."
        '
        'copyleftLabel
        '
        Me.copyleftLabel.BackColor = System.Drawing.Color.Transparent
        Me.copyleftLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.copyleftLabel.Location = New System.Drawing.Point(156, 120)
        Me.copyleftLabel.Name = "copyleftLabel"
        Me.copyleftLabel.Size = New System.Drawing.Size(408, 18)
        Me.copyleftLabel.TabIndex = 3
        Me.copyleftLabel.Text = "copyleft"
        '
        'versionLabel
        '
        Me.versionLabel.BackColor = System.Drawing.Color.Transparent
        Me.versionLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.versionLabel.Location = New System.Drawing.Point(230, 98)
        Me.versionLabel.Name = "versionLabel"
        Me.versionLabel.Size = New System.Drawing.Size(334, 18)
        Me.versionLabel.TabIndex = 4
        Me.versionLabel.Text = "version"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(156, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 18)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Version:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(156, 147)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 18)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Description:"
        '
        'DescriptionLabel
        '
        Me.DescriptionLabel.BackColor = System.Drawing.Color.Transparent
        Me.DescriptionLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DescriptionLabel.Location = New System.Drawing.Point(156, 165)
        Me.DescriptionLabel.Name = "DescriptionLabel"
        Me.DescriptionLabel.Size = New System.Drawing.Size(408, 43)
        Me.DescriptionLabel.TabIndex = 11
        Me.DescriptionLabel.Text = "description..."
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.BackColor = System.Drawing.Color.Transparent
        Me.OKButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.OKButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OKButton.FlatAppearance.BorderSize = 0
        Me.OKButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OKButton.Image = CType(resources.GetObject("OKButton.Image"), System.Drawing.Image)
        Me.OKButton.Location = New System.Drawing.Point(460, 370)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(133, 42)
        Me.OKButton.TabIndex = 1
        Me.OKButton.TabStop = False
        Me.OKButton.UseVisualStyleBackColor = False
        '
        'LicenseButton
        '
        Me.LicenseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LicenseButton.BackColor = System.Drawing.Color.Transparent
        Me.LicenseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.LicenseButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LicenseButton.FlatAppearance.BorderSize = 0
        Me.LicenseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LicenseButton.Image = CType(resources.GetObject("LicenseButton.Image"), System.Drawing.Image)
        Me.LicenseButton.Location = New System.Drawing.Point(0, 357)
        Me.LicenseButton.Name = "LicenseButton"
        Me.LicenseButton.Size = New System.Drawing.Size(144, 62)
        Me.LicenseButton.TabIndex = 5
        Me.LicenseButton.UseVisualStyleBackColor = False
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LogoPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.LogoPictureBox.Location = New System.Drawing.Point(159, 12)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(440, 70)
        Me.LogoPictureBox.TabIndex = 12
        Me.LogoPictureBox.TabStop = False
        '
        'iconPictureBox
        '
        Me.iconPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.iconPictureBox.Location = New System.Drawing.Point(12, 12)
        Me.iconPictureBox.Name = "iconPictureBox"
        Me.iconPictureBox.Size = New System.Drawing.Size(128, 128)
        Me.iconPictureBox.TabIndex = 13
        Me.iconPictureBox.TabStop = False
        '
        'AboutWin
        '
        Me.AcceptButton = Me.OKButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CancelButton = Me.OKButton
        Me.ClientSize = New System.Drawing.Size(604, 421)
        Me.ControlBox = False
        Me.Controls.Add(Me.iconPictureBox)
        Me.Controls.Add(Me.LogoPictureBox)
        Me.Controls.Add(Me.LicenseButton)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.DescriptionLabel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.versionLabel)
        Me.Controls.Add(Me.copyleftLabel)
        Me.Controls.Add(Me.LicenseTextBox)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AboutWin"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "About"
        Me.TransparencyKey = System.Drawing.Color.LightCoral
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.iconPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents copyleftLabel As System.Windows.Forms.Label
    Friend WithEvents versionLabel As System.Windows.Forms.Label
    Friend WithEvents LicenseButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As Label
    Friend WithEvents DescriptionLabel As Label
    Friend WithEvents LogoPictureBox As PictureBox
    Friend WithEvents iconPictureBox As PictureBox
End Class
