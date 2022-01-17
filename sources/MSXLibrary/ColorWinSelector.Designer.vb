<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ColorWinSelector
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
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.MessageLabel = New System.Windows.Forms.Label
        Me.OkButton = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TitleLabel = New System.Windows.Forms.Label
        Me.PalettePanel = New System.Windows.Forms.Panel
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.UndoButton = New System.Windows.Forms.Button
        Me.targetPic = New System.Windows.Forms.PictureBox
        Me.sourcePic = New System.Windows.Forms.PictureBox
        Me.ExitButton = New System.Windows.Forms.Button
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.targetPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sourcePic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel2.Controls.Add(Me.MessageLabel)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 168)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(318, 32)
        Me.Panel2.TabIndex = 10
        '
        'MessageLabel
        '
        Me.MessageLabel.AutoSize = True
        Me.MessageLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MessageLabel.Location = New System.Drawing.Point(9, 9)
        Me.MessageLabel.Name = "MessageLabel"
        Me.MessageLabel.Size = New System.Drawing.Size(120, 13)
        Me.MessageLabel.TabIndex = 2
        Me.MessageLabel.Text = "Select source color."
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OkButton.BackColor = System.Drawing.Color.Gainsboro
        Me.OkButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OkButton.Location = New System.Drawing.Point(179, 133)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(50, 29)
        Me.OkButton.TabIndex = 9
        Me.OkButton.Text = "Ok"
        Me.OkButton.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SkyBlue
        Me.Panel1.Controls.Add(Me.TitleLabel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(318, 32)
        Me.Panel1.TabIndex = 7
        '
        'TitleLabel
        '
        Me.TitleLabel.AutoSize = True
        Me.TitleLabel.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleLabel.Location = New System.Drawing.Point(9, 7)
        Me.TitleLabel.Name = "TitleLabel"
        Me.TitleLabel.Size = New System.Drawing.Size(86, 18)
        Me.TitleLabel.TabIndex = 0
        Me.TitleLabel.Text = "Copy tool"
        '
        'PalettePanel
        '
        Me.PalettePanel.BackColor = System.Drawing.Color.Black
        Me.PalettePanel.Location = New System.Drawing.Point(30, 50)
        Me.PalettePanel.MaximumSize = New System.Drawing.Size(256, 16)
        Me.PalettePanel.MinimumSize = New System.Drawing.Size(256, 16)
        Me.PalettePanel.Name = "PalettePanel"
        Me.PalettePanel.Size = New System.Drawing.Size(256, 16)
        Me.PalettePanel.TabIndex = 6
        '
        'UndoButton
        '
        Me.UndoButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UndoButton.BackColor = System.Drawing.Color.WhiteSmoke
        Me.UndoButton.Enabled = False
        Me.UndoButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UndoButton.Image = Global.MSXdevTools.MSXLibrary.My.Resources.Resources.undo_24
        Me.UndoButton.Location = New System.Drawing.Point(143, 133)
        Me.UndoButton.Name = "UndoButton"
        Me.UndoButton.Size = New System.Drawing.Size(30, 29)
        Me.UndoButton.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.UndoButton, "Undo")
        Me.UndoButton.UseVisualStyleBackColor = False
        '
        'targetPic
        '
        Me.targetPic.Image = Global.MSXdevTools.MSXLibrary.My.Resources.Resources.target_arrow
        Me.targetPic.Location = New System.Drawing.Point(270, 67)
        Me.targetPic.Name = "targetPic"
        Me.targetPic.Size = New System.Drawing.Size(16, 16)
        Me.targetPic.TabIndex = 12
        Me.targetPic.TabStop = False
        '
        'sourcePic
        '
        Me.sourcePic.Image = Global.MSXdevTools.MSXLibrary.My.Resources.Resources.source_arrow
        Me.sourcePic.Location = New System.Drawing.Point(30, 67)
        Me.sourcePic.Name = "sourcePic"
        Me.sourcePic.Size = New System.Drawing.Size(16, 16)
        Me.sourcePic.TabIndex = 11
        Me.sourcePic.TabStop = False
        '
        'ExitButton
        '
        Me.ExitButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExitButton.BackColor = System.Drawing.Color.Gainsboro
        Me.ExitButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExitButton.Location = New System.Drawing.Point(235, 133)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(71, 29)
        Me.ExitButton.TabIndex = 15
        Me.ExitButton.Text = "Cancel"
        Me.ExitButton.UseVisualStyleBackColor = False
        '
        'ColorWinSelector
        '
        Me.AcceptButton = Me.OkButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(318, 200)
        Me.ControlBox = False
        Me.Controls.Add(Me.ExitButton)
        Me.Controls.Add(Me.UndoButton)
        Me.Controls.Add(Me.targetPic)
        Me.Controls.Add(Me.sourcePic)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PalettePanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ColorWinSelector"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Color Win Tool"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.targetPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sourcePic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents MessageLabel As System.Windows.Forms.Label
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TitleLabel As System.Windows.Forms.Label
    Friend WithEvents PalettePanel As System.Windows.Forms.Panel
    Friend WithEvents sourcePic As System.Windows.Forms.PictureBox
    Friend WithEvents targetPic As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents UndoButton As System.Windows.Forms.Button
    Friend WithEvents ExitButton As System.Windows.Forms.Button

End Class
