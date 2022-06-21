<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Palette512Dialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Palette512Dialog))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FilesContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PrjImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.OkPanel = New System.Windows.Forms.Panel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OkPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 5000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 600
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'FilesContextMenuStrip
        '
        Me.FilesContextMenuStrip.Name = "FilesContextMenuStrip"
        Me.FilesContextMenuStrip.Size = New System.Drawing.Size(61, 4)
        '
        'PrjImageList
        '
        Me.PrjImageList.ImageStream = CType(resources.GetObject("PrjImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.PrjImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.PrjImageList.Images.SetKeyName(0, "new2_16.png")
        '
        'OkPanel
        '
        Me.OkPanel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.OkPanel.Controls.Add(Me.OK_Button)
        Me.OkPanel.Controls.Add(Me.Cancel_Button)
        Me.OkPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.OkPanel.Location = New System.Drawing.Point(0, 330)
        Me.OkPanel.Name = "OkPanel"
        Me.OkPanel.Padding = New System.Windows.Forms.Padding(4)
        Me.OkPanel.Size = New System.Drawing.Size(474, 51)
        Me.OkPanel.TabIndex = 27
        '
        'OK_Button
        '
        Me.OK_Button.BackColor = System.Drawing.Color.Transparent
        Me.OK_Button.Dock = System.Windows.Forms.DockStyle.Right
        Me.OK_Button.FlatAppearance.BorderSize = 0
        Me.OK_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OK_Button.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK_Button.Image = Global.mSXdevtools.V9938PaletteEditor.My.Resources.Resources.button_Ok
        Me.OK_Button.Location = New System.Drawing.Point(228, 4)
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
        Me.Cancel_Button.Image = Global.mSXdevtools.V9938PaletteEditor.My.Resources.Resources.button_Cancel
        Me.Cancel_Button.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Cancel_Button.Location = New System.Drawing.Point(360, 4)
        Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(110, 43)
        Me.Cancel_Button.TabIndex = 280
        Me.Cancel_Button.UseVisualStyleBackColor = False
        '
        'Palette512Dialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(474, 381)
        Me.ControlBox = False
        Me.Controls.Add(Me.OkPanel)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Palette512Dialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "V9938 Color Palette Editor"
        Me.OkPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents FilesContextMenuStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents PrjImageList As System.Windows.Forms.ImageList
    Friend WithEvents OkPanel As Panel
    Private WithEvents Cancel_Button As Button
    Friend WithEvents OK_Button As Button
End Class
