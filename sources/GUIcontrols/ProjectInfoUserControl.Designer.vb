<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProjectInfoUserControl
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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LastUpdateTextBox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.StartDateTextBox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DescriptionTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.AuthorTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.VersionTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NameTextBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(280, 105)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 28)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "Last update"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LastUpdateTextBox
        '
        Me.LastUpdateTextBox.Location = New System.Drawing.Point(379, 108)
        Me.LastUpdateTextBox.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.LastUpdateTextBox.MaxLength = 32
        Me.LastUpdateTextBox.Name = "LastUpdateTextBox"
        Me.LastUpdateTextBox.ReadOnly = True
        Me.LastUpdateTextBox.Size = New System.Drawing.Size(110, 23)
        Me.LastUpdateTextBox.TabIndex = 30
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(18, 106)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 28)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "Start project"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'StartDateTextBox
        '
        Me.StartDateTextBox.Location = New System.Drawing.Point(117, 109)
        Me.StartDateTextBox.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.StartDateTextBox.MaxLength = 32
        Me.StartDateTextBox.Name = "StartDateTextBox"
        Me.StartDateTextBox.ReadOnly = True
        Me.StartDateTextBox.Size = New System.Drawing.Size(110, 23)
        Me.StartDateTextBox.TabIndex = 29
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(18, 74)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 28)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Group"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupTextBox
        '
        Me.GroupTextBox.Location = New System.Drawing.Point(117, 78)
        Me.GroupTextBox.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupTextBox.MaxLength = 32
        Me.GroupTextBox.Name = "GroupTextBox"
        Me.GroupTextBox.Size = New System.Drawing.Size(372, 23)
        Me.GroupTextBox.TabIndex = 28
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(15, 137)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 28)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Description"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DescriptionTextBox
        '
        Me.DescriptionTextBox.Location = New System.Drawing.Point(117, 140)
        Me.DescriptionTextBox.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.DescriptionTextBox.MaxLength = 1024
        Me.DescriptionTextBox.Multiline = True
        Me.DescriptionTextBox.Name = "DescriptionTextBox"
        Me.DescriptionTextBox.Size = New System.Drawing.Size(372, 126)
        Me.DescriptionTextBox.TabIndex = 31
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(229, 42)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 28)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Author"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AuthorTextBox
        '
        Me.AuthorTextBox.Location = New System.Drawing.Point(312, 46)
        Me.AuthorTextBox.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.AuthorTextBox.MaxLength = 32
        Me.AuthorTextBox.Name = "AuthorTextBox"
        Me.AuthorTextBox.Size = New System.Drawing.Size(177, 23)
        Me.AuthorTextBox.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(18, 43)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 28)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Version"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'VersionTextBox
        '
        Me.VersionTextBox.Location = New System.Drawing.Point(117, 47)
        Me.VersionTextBox.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.VersionTextBox.MaxLength = 32
        Me.VersionTextBox.Name = "VersionTextBox"
        Me.VersionTextBox.Size = New System.Drawing.Size(110, 23)
        Me.VersionTextBox.TabIndex = 26
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(18, 12)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 28)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Name"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'NameTextBox
        '
        Me.NameTextBox.Location = New System.Drawing.Point(117, 16)
        Me.NameTextBox.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.NameTextBox.MaxLength = 32
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(372, 23)
        Me.NameTextBox.TabIndex = 25
        '
        'ProjectInfoUserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LastUpdateTextBox)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.StartDateTextBox)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupTextBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DescriptionTextBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.AuthorTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.VersionTextBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.NameTextBox)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "ProjectInfoUserControl"
        Me.Size = New System.Drawing.Size(510, 280)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents Label7 As Label
    Private WithEvents LastUpdateTextBox As TextBox
    Private WithEvents Label6 As Label
    Private WithEvents StartDateTextBox As TextBox
    Private WithEvents Label5 As Label
    Private WithEvents GroupTextBox As TextBox
    Private WithEvents Label3 As Label
    Private WithEvents DescriptionTextBox As TextBox
    Private WithEvents Label2 As Label
    Private WithEvents AuthorTextBox As TextBox
    Private WithEvents Label1 As Label
    Private WithEvents VersionTextBox As TextBox
    Private WithEvents Label4 As Label
    Private WithEvents NameTextBox As TextBox
End Class
