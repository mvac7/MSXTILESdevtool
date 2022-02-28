<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PathEntryControl
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
        Me.components = New System.ComponentModel.Container()
        Me.PathLabel = New System.Windows.Forms.Label()
        Me.PathButton = New System.Windows.Forms.Button()
        Me.PathTextBox = New System.Windows.Forms.TextBox()
        Me.PathTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'PathLabel
        '
        Me.PathLabel.Location = New System.Drawing.Point(0, 5)
        Me.PathLabel.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.PathLabel.Name = "PathLabel"
        Me.PathLabel.Size = New System.Drawing.Size(148, 22)
        Me.PathLabel.TabIndex = 256
        Me.PathLabel.Text = ":"
        Me.PathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PathButton
        '
        Me.PathButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PathButton.BackColor = System.Drawing.Color.Gainsboro
        Me.PathButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PathButton.Image = Global.mSXdevtools.GUI.Controls.My.Resources.Resources.folder2_x16
        Me.PathButton.Location = New System.Drawing.Point(530, 4)
        Me.PathButton.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PathButton.Name = "PathButton"
        Me.PathButton.Size = New System.Drawing.Size(26, 23)
        Me.PathButton.TabIndex = 258
        Me.PathButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.PathButton.UseVisualStyleBackColor = False
        '
        'PathTextBox
        '
        Me.PathTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PathTextBox.Location = New System.Drawing.Point(267, 5)
        Me.PathTextBox.Name = "PathTextBox"
        Me.PathTextBox.Size = New System.Drawing.Size(260, 22)
        Me.PathTextBox.TabIndex = 257
        '
        'PathTypeComboBox
        '
        Me.PathTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PathTypeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.PathTypeComboBox.FormattingEnabled = True
        Me.PathTypeComboBox.Items.AddRange(New Object() {"User", "Last used"})
        Me.PathTypeComboBox.Location = New System.Drawing.Point(152, 5)
        Me.PathTypeComboBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PathTypeComboBox.Name = "PathTypeComboBox"
        Me.PathTypeComboBox.Size = New System.Drawing.Size(110, 22)
        Me.PathTypeComboBox.TabIndex = 255
        '
        'PathEntryControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PathLabel)
        Me.Controls.Add(Me.PathButton)
        Me.Controls.Add(Me.PathTextBox)
        Me.Controls.Add(Me.PathTypeComboBox)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "PathEntryControl"
        Me.Size = New System.Drawing.Size(560, 32)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PathLabel As System.Windows.Forms.Label
    Friend WithEvents PathButton As System.Windows.Forms.Button
    Friend WithEvents PathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PathTypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

End Class
