<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DoYouWantaNewOneDialog
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.NewButton = New System.Windows.Forms.Button()
        Me.MergeButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(37, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(345, 46)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Do you want to create a new project or add it to the existing one?"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(35, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 32)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Warning:"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(101, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(288, 32)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "If you choose a new one, the current data will be lost."
        '
        'ExitButton
        '
        Me.ExitButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExitButton.BackColor = System.Drawing.Color.LightSalmon
        Me.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ExitButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExitButton.ForeColor = System.Drawing.Color.Black
        Me.ExitButton.Location = New System.Drawing.Point(332, 280)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(70, 30)
        Me.ExitButton.TabIndex = 10
        Me.ExitButton.Text = "Cancel"
        Me.ExitButton.UseVisualStyleBackColor = False
        '
        'NewButton
        '
        Me.NewButton.BackColor = System.Drawing.Color.Gainsboro
        Me.NewButton.ForeColor = System.Drawing.Color.Black
        Me.NewButton.Image = Global.mSXdevtools.GUI.Controls.My.Resources.Resources.New_64
        Me.NewButton.Location = New System.Drawing.Point(40, 126)
        Me.NewButton.Name = "NewButton"
        Me.NewButton.Size = New System.Drawing.Size(128, 128)
        Me.NewButton.TabIndex = 0
        Me.NewButton.Text = "New"
        Me.NewButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.NewButton.UseVisualStyleBackColor = False
        '
        'MergeButton
        '
        Me.MergeButton.BackColor = System.Drawing.Color.Gainsboro
        Me.MergeButton.ForeColor = System.Drawing.Color.Black
        Me.MergeButton.Image = Global.mSXdevtools.GUI.Controls.My.Resources.Resources.merge_64
        Me.MergeButton.Location = New System.Drawing.Point(244, 126)
        Me.MergeButton.Name = "MergeButton"
        Me.MergeButton.Size = New System.Drawing.Size(128, 128)
        Me.MergeButton.TabIndex = 1
        Me.MergeButton.Text = "Add"
        Me.MergeButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.MergeButton.UseVisualStyleBackColor = False
        '
        'DoYouWantaNewOneDialog
        '
        Me.AcceptButton = Me.NewButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.CancelButton = Me.ExitButton
        Me.ClientSize = New System.Drawing.Size(414, 322)
        Me.ControlBox = False
        Me.Controls.Add(Me.ExitButton)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MergeButton)
        Me.Controls.Add(Me.NewButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "DoYouWantaNewOneDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Load"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NewButton As System.Windows.Forms.Button
    Friend WithEvents MergeButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents ExitButton As System.Windows.Forms.Button
End Class
