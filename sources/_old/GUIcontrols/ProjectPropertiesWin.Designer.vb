<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProjectPropertiesWin
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
        Me.Label4 = New System.Windows.Forms.Label
        Me.NameTextBox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.VersionTextBox = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.AuthorTextBox = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.DescriptionTextBox = New System.Windows.Forms.TextBox
        Me.ExitButton = New System.Windows.Forms.Button
        Me.OkButton = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupTextBox = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.ProjectStartDateTextBox = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.ProjectLastUpdateTextBox = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(11, 9)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 28)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Name"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'NameTextBox
        '
        Me.NameTextBox.Location = New System.Drawing.Point(110, 13)
        Me.NameTextBox.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.NameTextBox.MaxLength = 32
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(362, 23)
        Me.NameTextBox.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(11, 40)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 28)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Version"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'VersionTextBox
        '
        Me.VersionTextBox.Location = New System.Drawing.Point(110, 44)
        Me.VersionTextBox.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.VersionTextBox.MaxLength = 32
        Me.VersionTextBox.Name = "VersionTextBox"
        Me.VersionTextBox.Size = New System.Drawing.Size(110, 23)
        Me.VersionTextBox.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(222, 39)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 28)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Author"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AuthorTextBox
        '
        Me.AuthorTextBox.Location = New System.Drawing.Point(305, 43)
        Me.AuthorTextBox.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.AuthorTextBox.MaxLength = 32
        Me.AuthorTextBox.Name = "AuthorTextBox"
        Me.AuthorTextBox.Size = New System.Drawing.Size(167, 23)
        Me.AuthorTextBox.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 134)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 28)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Description"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DescriptionTextBox
        '
        Me.DescriptionTextBox.Location = New System.Drawing.Point(110, 137)
        Me.DescriptionTextBox.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.DescriptionTextBox.MaxLength = 1024
        Me.DescriptionTextBox.Multiline = True
        Me.DescriptionTextBox.Name = "DescriptionTextBox"
        Me.DescriptionTextBox.Size = New System.Drawing.Size(362, 126)
        Me.DescriptionTextBox.TabIndex = 7
        '
        'ExitButton
        '
        Me.ExitButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExitButton.BackColor = System.Drawing.Color.Salmon
        Me.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ExitButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExitButton.Location = New System.Drawing.Point(405, 277)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(69, 32)
        Me.ExitButton.TabIndex = 9
        Me.ExitButton.Text = "Exit"
        Me.ExitButton.UseVisualStyleBackColor = False
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OkButton.BackColor = System.Drawing.Color.LightGreen
        Me.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OkButton.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OkButton.Location = New System.Drawing.Point(258, 277)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(141, 32)
        Me.OkButton.TabIndex = 8
        Me.OkButton.Text = "Ok"
        Me.OkButton.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(11, 71)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 28)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Group"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupTextBox
        '
        Me.GroupTextBox.Location = New System.Drawing.Point(110, 75)
        Me.GroupTextBox.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupTextBox.MaxLength = 32
        Me.GroupTextBox.Name = "GroupTextBox"
        Me.GroupTextBox.Size = New System.Drawing.Size(362, 23)
        Me.GroupTextBox.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(11, 102)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 28)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Start project"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ProjectStartDateTextBox
        '
        Me.ProjectStartDateTextBox.Location = New System.Drawing.Point(110, 106)
        Me.ProjectStartDateTextBox.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.ProjectStartDateTextBox.MaxLength = 32
        Me.ProjectStartDateTextBox.Name = "ProjectStartDateTextBox"
        Me.ProjectStartDateTextBox.ReadOnly = True
        Me.ProjectStartDateTextBox.Size = New System.Drawing.Size(110, 23)
        Me.ProjectStartDateTextBox.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(263, 101)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 28)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Last update"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ProjectLastUpdateTextBox
        '
        Me.ProjectLastUpdateTextBox.Location = New System.Drawing.Point(362, 105)
        Me.ProjectLastUpdateTextBox.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.ProjectLastUpdateTextBox.MaxLength = 32
        Me.ProjectLastUpdateTextBox.Name = "ProjectLastUpdateTextBox"
        Me.ProjectLastUpdateTextBox.ReadOnly = True
        Me.ProjectLastUpdateTextBox.Size = New System.Drawing.Size(110, 23)
        Me.ProjectLastUpdateTextBox.TabIndex = 6
        '
        'ProjectPropertiesWin
        '
        Me.AcceptButton = Me.OkButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.ExitButton
        Me.ClientSize = New System.Drawing.Size(494, 322)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ProjectLastUpdateTextBox)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ProjectStartDateTextBox)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupTextBox)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.ExitButton)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DescriptionTextBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.AuthorTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.VersionTextBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.NameTextBox)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ProjectPropertiesWin"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Project info"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents NameTextBox As System.Windows.Forms.TextBox
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents VersionTextBox As System.Windows.Forms.TextBox
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents AuthorTextBox As System.Windows.Forms.TextBox
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents DescriptionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ExitButton As System.Windows.Forms.Button
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Private WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents GroupTextBox As System.Windows.Forms.TextBox
    Private WithEvents Label6 As System.Windows.Forms.Label
    Private WithEvents ProjectStartDateTextBox As System.Windows.Forms.TextBox
    Private WithEvents Label7 As System.Windows.Forms.Label
    Private WithEvents ProjectLastUpdateTextBox As System.Windows.Forms.TextBox
End Class
