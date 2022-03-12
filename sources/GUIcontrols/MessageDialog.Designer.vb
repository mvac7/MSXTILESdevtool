<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MessageDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MessageDialog))
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.AcceptImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.CancelImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.ico64PictureBox = New System.Windows.Forms.PictureBox()
        Me.MessageLabel = New System.Windows.Forms.Label()
        Me.ico64ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.BottonsPanel = New System.Windows.Forms.Panel()
        CType(Me.ico64PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BottonsPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.BackColor = System.Drawing.Color.Transparent
        Me.OK_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.OK_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OK_Button.Dock = System.Windows.Forms.DockStyle.Right
        Me.OK_Button.FlatAppearance.BorderSize = 0
        Me.OK_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OK_Button.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK_Button.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OK_Button.ImageIndex = 0
        Me.OK_Button.ImageList = Me.AcceptImageList
        Me.OK_Button.Location = New System.Drawing.Point(178, 4)
        Me.OK_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(132, 43)
        Me.OK_Button.TabIndex = 3
        Me.OK_Button.UseVisualStyleBackColor = False
        '
        'AcceptImageList
        '
        Me.AcceptImageList.ImageStream = CType(resources.GetObject("AcceptImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.AcceptImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.AcceptImageList.Images.SetKeyName(0, "mSXdevtools_button_Ok.png")
        Me.AcceptImageList.Images.SetKeyName(1, "mSXdevtools_button_Yes.png")
        '
        'Cancel_Button
        '
        Me.Cancel_Button.BackColor = System.Drawing.Color.Transparent
        Me.Cancel_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Dock = System.Windows.Forms.DockStyle.Right
        Me.Cancel_Button.FlatAppearance.BorderSize = 0
        Me.Cancel_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cancel_Button.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_Button.ForeColor = System.Drawing.Color.Black
        Me.Cancel_Button.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Cancel_Button.ImageIndex = 0
        Me.Cancel_Button.ImageList = Me.CancelImageList
        Me.Cancel_Button.Location = New System.Drawing.Point(310, 4)
        Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(110, 43)
        Me.Cancel_Button.TabIndex = 4
        Me.Cancel_Button.UseVisualStyleBackColor = False
        Me.Cancel_Button.Visible = False
        '
        'CancelImageList
        '
        Me.CancelImageList.ImageStream = CType(resources.GetObject("CancelImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.CancelImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.CancelImageList.Images.SetKeyName(0, "mSXdevtools_button_Cancel.png")
        Me.CancelImageList.Images.SetKeyName(1, "mSXdevtools_button_No.png")
        '
        'ico64PictureBox
        '
        Me.ico64PictureBox.BackColor = System.Drawing.Color.Transparent
        Me.ico64PictureBox.Location = New System.Drawing.Point(12, 22)
        Me.ico64PictureBox.Name = "ico64PictureBox"
        Me.ico64PictureBox.Size = New System.Drawing.Size(64, 64)
        Me.ico64PictureBox.TabIndex = 5
        Me.ico64PictureBox.TabStop = False
        '
        'MessageLabel
        '
        Me.MessageLabel.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MessageLabel.ForeColor = System.Drawing.Color.Black
        Me.MessageLabel.Location = New System.Drawing.Point(92, 16)
        Me.MessageLabel.Name = "MessageLabel"
        Me.MessageLabel.Size = New System.Drawing.Size(320, 110)
        Me.MessageLabel.TabIndex = 6
        Me.MessageLabel.Text = "Message"
        Me.MessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ico64ImageList
        '
        Me.ico64ImageList.ImageStream = CType(resources.GetObject("ico64ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ico64ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ico64ImageList.Images.SetKeyName(0, "ico64_Alert_pixel2.png")
        Me.ico64ImageList.Images.SetKeyName(1, "ico64_About_pixel2.png")
        Me.ico64ImageList.Images.SetKeyName(2, "ico64_Help_pixel2.png")
        '
        'BottonsPanel
        '
        Me.BottonsPanel.Controls.Add(Me.OK_Button)
        Me.BottonsPanel.Controls.Add(Me.Cancel_Button)
        Me.BottonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottonsPanel.Location = New System.Drawing.Point(0, 130)
        Me.BottonsPanel.Name = "BottonsPanel"
        Me.BottonsPanel.Padding = New System.Windows.Forms.Padding(4)
        Me.BottonsPanel.Size = New System.Drawing.Size(424, 51)
        Me.BottonsPanel.TabIndex = 7
        '
        'MessageDialog
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(424, 181)
        Me.ControlBox = False
        Me.Controls.Add(Me.BottonsPanel)
        Me.Controls.Add(Me.MessageLabel)
        Me.Controls.Add(Me.ico64PictureBox)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MessageDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Dialog1"
        CType(Me.ico64PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BottonsPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents OK_Button As Button
    Friend WithEvents Cancel_Button As Button
    Friend WithEvents ico64PictureBox As PictureBox
    Friend WithEvents MessageLabel As Label
    Friend WithEvents ico64ImageList As ImageList
    Friend WithEvents AcceptImageList As ImageList
    Friend WithEvents CancelImageList As ImageList
    Friend WithEvents BottonsPanel As Panel
End Class
