<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListSelectorDialog
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
        Me.EntryLabel = New System.Windows.Forms.Label()
        Me.ListSelectorComboBox = New System.Windows.Forms.ComboBox()
        Me.BottonsPanel = New System.Windows.Forms.Panel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.BottonsPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'EntryLabel
        '
        Me.EntryLabel.ForeColor = System.Drawing.Color.Black
        Me.EntryLabel.Location = New System.Drawing.Point(11, 38)
        Me.EntryLabel.Name = "EntryLabel"
        Me.EntryLabel.Size = New System.Drawing.Size(340, 32)
        Me.EntryLabel.TabIndex = 23
        Me.EntryLabel.Text = "Select a item:"
        '
        'ListSelectorComboBox
        '
        Me.ListSelectorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ListSelectorComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ListSelectorComboBox.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListSelectorComboBox.FormattingEnabled = True
        Me.ListSelectorComboBox.Location = New System.Drawing.Point(62, 74)
        Me.ListSelectorComboBox.Name = "ListSelectorComboBox"
        Me.ListSelectorComboBox.Size = New System.Drawing.Size(300, 26)
        Me.ListSelectorComboBox.TabIndex = 0
        '
        'BottonsPanel
        '
        Me.BottonsPanel.Controls.Add(Me.OK_Button)
        Me.BottonsPanel.Controls.Add(Me.Cancel_Button)
        Me.BottonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottonsPanel.Location = New System.Drawing.Point(0, 150)
        Me.BottonsPanel.Name = "BottonsPanel"
        Me.BottonsPanel.Padding = New System.Windows.Forms.Padding(4)
        Me.BottonsPanel.Size = New System.Drawing.Size(384, 51)
        Me.BottonsPanel.TabIndex = 27
        '
        'OK_Button
        '
        Me.OK_Button.BackColor = System.Drawing.Color.Transparent
        Me.OK_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OK_Button.Dock = System.Windows.Forms.DockStyle.Right
        Me.OK_Button.FlatAppearance.BorderSize = 0
        Me.OK_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OK_Button.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK_Button.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OK_Button.Image = Global.mSXdevtools.GUI.Controls.My.Resources.Resources.button_Ok
        Me.OK_Button.Location = New System.Drawing.Point(138, 4)
        Me.OK_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(132, 43)
        Me.OK_Button.TabIndex = 3
        Me.OK_Button.UseVisualStyleBackColor = False
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
        Me.Cancel_Button.Image = Global.mSXdevtools.GUI.Controls.My.Resources.Resources.button_Cancel
        Me.Cancel_Button.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Cancel_Button.Location = New System.Drawing.Point(270, 4)
        Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(110, 43)
        Me.Cancel_Button.TabIndex = 4
        Me.Cancel_Button.UseVisualStyleBackColor = False
        '
        'ListSelectorDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(384, 201)
        Me.ControlBox = False
        Me.Controls.Add(Me.BottonsPanel)
        Me.Controls.Add(Me.ListSelectorComboBox)
        Me.Controls.Add(Me.EntryLabel)
        Me.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ListSelectorDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select item dialog"
        Me.BottonsPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EntryLabel As System.Windows.Forms.Label
    Friend WithEvents ListSelectorComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents BottonsPanel As Panel
    Friend WithEvents OK_Button As Button
    Friend WithEvents Cancel_Button As Button
End Class
