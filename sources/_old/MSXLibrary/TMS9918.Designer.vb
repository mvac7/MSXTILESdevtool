<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TMS9918
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
        Me.tilesScreen = New System.Windows.Forms.PictureBox
        Me.ScreenPictureBox = New System.Windows.Forms.PictureBox
        CType(Me.tilesScreen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ScreenPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tilesScreen
        '
        Me.tilesScreen.BackColor = System.Drawing.Color.Black
        Me.tilesScreen.Location = New System.Drawing.Point(0, 0)
        Me.tilesScreen.Name = "tilesScreen"
        Me.tilesScreen.Size = New System.Drawing.Size(256, 192)
        Me.tilesScreen.TabIndex = 1
        Me.tilesScreen.TabStop = False
        Me.tilesScreen.Visible = False
        '
        'ScreenPictureBox
        '
        Me.ScreenPictureBox.BackColor = System.Drawing.Color.Black
        Me.ScreenPictureBox.Location = New System.Drawing.Point(0, 0)
        Me.ScreenPictureBox.Name = "ScreenPictureBox"
        Me.ScreenPictureBox.Size = New System.Drawing.Size(256, 192)
        Me.ScreenPictureBox.TabIndex = 0
        Me.ScreenPictureBox.TabStop = False
        '
        'TMS9918
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tilesScreen)
        Me.Controls.Add(Me.ScreenPictureBox)
        Me.MaximumSize = New System.Drawing.Size(260, 196)
        Me.MinimumSize = New System.Drawing.Size(260, 196)
        Me.Name = "TMS9918"
        Me.Size = New System.Drawing.Size(260, 196)
        CType(Me.tilesScreen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ScreenPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ScreenPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents tilesScreen As System.Windows.Forms.PictureBox

End Class
