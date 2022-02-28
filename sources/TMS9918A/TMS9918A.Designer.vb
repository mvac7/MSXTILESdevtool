<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TMS9918A
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.outputPictureBox = New System.Windows.Forms.PictureBox()
        Me.tilesetPictureBox = New System.Windows.Forms.PictureBox()
        Me.spritePatternsPictureBox = New System.Windows.Forms.PictureBox()
        Me.spritesLayerPictureBox = New System.Windows.Forms.PictureBox()
        CType(Me.outputPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tilesetPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spritePatternsPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spritesLayerPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'outputPictureBox
        '
        Me.outputPictureBox.BackColor = System.Drawing.Color.Black
        Me.outputPictureBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.outputPictureBox.Location = New System.Drawing.Point(0, 0)
        Me.outputPictureBox.Name = "outputPictureBox"
        Me.outputPictureBox.Size = New System.Drawing.Size(256, 192)
        Me.outputPictureBox.TabIndex = 1
        Me.outputPictureBox.TabStop = False
        Me.outputPictureBox.Visible = False
        '
        'tilesetPictureBox
        '
        Me.tilesetPictureBox.BackColor = System.Drawing.Color.Black
        Me.tilesetPictureBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tilesetPictureBox.Location = New System.Drawing.Point(0, 0)
        Me.tilesetPictureBox.Name = "tilesetPictureBox"
        Me.tilesetPictureBox.Size = New System.Drawing.Size(256, 192)
        Me.tilesetPictureBox.TabIndex = 0
        Me.tilesetPictureBox.TabStop = False
        '
        'spritePatternsPictureBox
        '
        Me.spritePatternsPictureBox.BackColor = System.Drawing.Color.Black
        Me.spritePatternsPictureBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spritePatternsPictureBox.Location = New System.Drawing.Point(0, 0)
        Me.spritePatternsPictureBox.Name = "spritePatternsPictureBox"
        Me.spritePatternsPictureBox.Size = New System.Drawing.Size(256, 192)
        Me.spritePatternsPictureBox.TabIndex = 2
        Me.spritePatternsPictureBox.TabStop = False
        Me.spritePatternsPictureBox.Visible = False
        '
        'spritesLayerPictureBox
        '
        Me.spritesLayerPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.spritesLayerPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.spritesLayerPictureBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spritesLayerPictureBox.Location = New System.Drawing.Point(0, 0)
        Me.spritesLayerPictureBox.Name = "spritesLayerPictureBox"
        Me.spritesLayerPictureBox.Size = New System.Drawing.Size(256, 192)
        Me.spritesLayerPictureBox.TabIndex = 3
        Me.spritesLayerPictureBox.TabStop = False
        '
        'TMS9918A
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.spritesLayerPictureBox)
        Me.Controls.Add(Me.spritePatternsPictureBox)
        Me.Controls.Add(Me.outputPictureBox)
        Me.Controls.Add(Me.tilesetPictureBox)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.DoubleBuffered = True
        Me.Name = "TMS9918A"
        Me.Size = New System.Drawing.Size(256, 192)
        CType(Me.outputPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tilesetPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spritePatternsPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spritesLayerPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tilesetPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents outputPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents spritePatternsPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents spritesLayerPictureBox As System.Windows.Forms.PictureBox

End Class
