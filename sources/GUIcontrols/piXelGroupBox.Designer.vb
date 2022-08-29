<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class piXelGroupBox
    Inherits System.Windows.Forms.GroupBox

    'Control reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de controles
    Private components As System.ComponentModel.IContainer

    ' NOTA: el Diseñador de componentes requiere el siguiente procedimiento
    ' Se puede modificar usando el Diseñador de componentes.  No lo modifique
    ' usando el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(piXelGroupBox))
        Me.piXelS_font = New System.Windows.Forms.PictureBox()
        CType(Me.piXelS_font, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'piXelS_font
        '
        Me.piXelS_font.BackColor = System.Drawing.Color.Transparent
        Me.piXelS_font.Image = CType(resources.GetObject("piXelS_font.Image"), System.Drawing.Image)
        Me.piXelS_font.Location = New System.Drawing.Point(0, 0)
        Me.piXelS_font.Name = "piXelS_font"
        Me.piXelS_font.Size = New System.Drawing.Size(100, 50)
        Me.piXelS_font.TabIndex = 0
        Me.piXelS_font.TabStop = False
        Me.piXelS_font.Visible = False
        CType(Me.piXelS_font, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents piXelS_font As PictureBox
End Class

