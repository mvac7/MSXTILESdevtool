<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class _RecentListWin_DEPRECATED
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
        Me.RecentProjectsList = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ExitButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'RecentProjectsList
        '
        Me.RecentProjectsList.BackColor = System.Drawing.Color.WhiteSmoke
        Me.RecentProjectsList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.RecentProjectsList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RecentProjectsList.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RecentProjectsList.ForeColor = System.Drawing.Color.Black
        Me.RecentProjectsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.RecentProjectsList.Location = New System.Drawing.Point(0, 0)
        Me.RecentProjectsList.MultiSelect = False
        Me.RecentProjectsList.Name = "RecentProjectsList"
        Me.RecentProjectsList.Size = New System.Drawing.Size(200, 202)
        Me.RecentProjectsList.TabIndex = 3
        Me.RecentProjectsList.UseCompatibleStateImageBehavior = False
        Me.RecentProjectsList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 194
        '
        'ExitButton
        '
        Me.ExitButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExitButton.BackColor = System.Drawing.Color.Salmon
        Me.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ExitButton.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExitButton.Location = New System.Drawing.Point(119, 164)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(69, 35)
        Me.ExitButton.TabIndex = 20
        Me.ExitButton.Text = "cancel"
        Me.ExitButton.UseVisualStyleBackColor = False
        '
        'RecentListWin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.CancelButton = Me.ExitButton
        Me.ClientSize = New System.Drawing.Size(200, 202)
        Me.Controls.Add(Me.RecentProjectsList)
        Me.Controls.Add(Me.ExitButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RecentListWin"
        Me.Opacity = 0.9
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "RecentListWin"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RecentProjectsList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ExitButton As System.Windows.Forms.Button
End Class
