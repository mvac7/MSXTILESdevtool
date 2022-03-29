<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HoriTAB
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HoriTAB))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Tab3Button = New System.Windows.Forms.Button()
        Me.Tab2Button = New System.Windows.Forms.Button()
        Me.Tab1Button = New System.Windows.Forms.Button()
        Me.Tab0Button = New System.Windows.Forms.Button()
        Me.Tab4Button = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "tab0_select.png")
        Me.ImageList1.Images.SetKeyName(1, "tab0_unselect.png")
        Me.ImageList1.Images.SetKeyName(2, "tab1_select.png")
        Me.ImageList1.Images.SetKeyName(3, "tab1_unselect.png")
        Me.ImageList1.Images.SetKeyName(4, "tab2_select.png")
        Me.ImageList1.Images.SetKeyName(5, "tab2_unselect.png")
        Me.ImageList1.Images.SetKeyName(6, "tab3_select.png")
        Me.ImageList1.Images.SetKeyName(7, "tab3_unselect.png")
        Me.ImageList1.Images.SetKeyName(8, "tab4_select.png")
        Me.ImageList1.Images.SetKeyName(9, "tab4_unselect.png")
        '
        'Tab3Button
        '
        Me.Tab3Button.BackColor = System.Drawing.Color.Transparent
        Me.Tab3Button.CausesValidation = False
        Me.Tab3Button.Dock = System.Windows.Forms.DockStyle.Left
        Me.Tab3Button.FlatAppearance.BorderSize = 0
        Me.Tab3Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Tab3Button.ImageIndex = 7
        Me.Tab3Button.ImageList = Me.ImageList1
        Me.Tab3Button.Location = New System.Drawing.Point(378, 0)
        Me.Tab3Button.Margin = New System.Windows.Forms.Padding(0)
        Me.Tab3Button.Name = "Tab3Button"
        Me.Tab3Button.Size = New System.Drawing.Size(126, 33)
        Me.Tab3Button.TabIndex = 3
        Me.Tab3Button.UseVisualStyleBackColor = False
        '
        'Tab2Button
        '
        Me.Tab2Button.BackColor = System.Drawing.Color.Transparent
        Me.Tab2Button.Dock = System.Windows.Forms.DockStyle.Left
        Me.Tab2Button.FlatAppearance.BorderSize = 0
        Me.Tab2Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Tab2Button.ImageIndex = 5
        Me.Tab2Button.ImageList = Me.ImageList1
        Me.Tab2Button.Location = New System.Drawing.Point(252, 0)
        Me.Tab2Button.Margin = New System.Windows.Forms.Padding(0)
        Me.Tab2Button.Name = "Tab2Button"
        Me.Tab2Button.Size = New System.Drawing.Size(126, 33)
        Me.Tab2Button.TabIndex = 2
        Me.Tab2Button.UseVisualStyleBackColor = False
        '
        'Tab1Button
        '
        Me.Tab1Button.BackColor = System.Drawing.Color.Transparent
        Me.Tab1Button.Dock = System.Windows.Forms.DockStyle.Left
        Me.Tab1Button.FlatAppearance.BorderSize = 0
        Me.Tab1Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Tab1Button.ImageIndex = 3
        Me.Tab1Button.ImageList = Me.ImageList1
        Me.Tab1Button.Location = New System.Drawing.Point(126, 0)
        Me.Tab1Button.Margin = New System.Windows.Forms.Padding(0)
        Me.Tab1Button.Name = "Tab1Button"
        Me.Tab1Button.Size = New System.Drawing.Size(126, 33)
        Me.Tab1Button.TabIndex = 1
        Me.Tab1Button.UseVisualStyleBackColor = False
        '
        'Tab0Button
        '
        Me.Tab0Button.BackColor = System.Drawing.Color.Transparent
        Me.Tab0Button.Dock = System.Windows.Forms.DockStyle.Left
        Me.Tab0Button.FlatAppearance.BorderSize = 0
        Me.Tab0Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Tab0Button.ImageIndex = 1
        Me.Tab0Button.ImageList = Me.ImageList1
        Me.Tab0Button.Location = New System.Drawing.Point(0, 0)
        Me.Tab0Button.Margin = New System.Windows.Forms.Padding(0)
        Me.Tab0Button.Name = "Tab0Button"
        Me.Tab0Button.Size = New System.Drawing.Size(126, 33)
        Me.Tab0Button.TabIndex = 0
        Me.Tab0Button.UseVisualStyleBackColor = False
        '
        'Tab4Button
        '
        Me.Tab4Button.BackColor = System.Drawing.Color.Transparent
        Me.Tab4Button.CausesValidation = False
        Me.Tab4Button.Dock = System.Windows.Forms.DockStyle.Left
        Me.Tab4Button.FlatAppearance.BorderSize = 0
        Me.Tab4Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Tab4Button.ImageIndex = 9
        Me.Tab4Button.ImageList = Me.ImageList1
        Me.Tab4Button.Location = New System.Drawing.Point(504, 0)
        Me.Tab4Button.Margin = New System.Windows.Forms.Padding(0)
        Me.Tab4Button.Name = "Tab4Button"
        Me.Tab4Button.Size = New System.Drawing.Size(126, 33)
        Me.Tab4Button.TabIndex = 4
        Me.Tab4Button.UseVisualStyleBackColor = False
        '
        'HoriTAB
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.RoyalBlue
        Me.Controls.Add(Me.Tab4Button)
        Me.Controls.Add(Me.Tab3Button)
        Me.Controls.Add(Me.Tab2Button)
        Me.Controls.Add(Me.Tab1Button)
        Me.Controls.Add(Me.Tab0Button)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "HoriTAB"
        Me.Size = New System.Drawing.Size(640, 33)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ImageList1 As ImageList
    Private WithEvents Tab0Button As Button
    Private WithEvents Tab1Button As Button
    Private WithEvents Tab2Button As Button
    Private WithEvents Tab3Button As Button
    Private WithEvents Tab4Button As Button
End Class
