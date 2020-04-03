<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InitLauncher
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InitLauncher))
        Me.RecentProjectsList = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.PrjImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.ToolTippi = New System.Windows.Forms.ToolTip(Me.components)
        Me.LoadButton = New System.Windows.Forms.Button
        Me.NewButton = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RecentProjectsList
        '
        Me.RecentProjectsList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RecentProjectsList.BackColor = System.Drawing.Color.WhiteSmoke
        Me.RecentProjectsList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.RecentProjectsList.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RecentProjectsList.ForeColor = System.Drawing.Color.Black
        Me.RecentProjectsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.RecentProjectsList.Location = New System.Drawing.Point(15, 222)
        Me.RecentProjectsList.MultiSelect = False
        Me.RecentProjectsList.Name = "RecentProjectsList"
        Me.RecentProjectsList.Size = New System.Drawing.Size(340, 123)
        Me.RecentProjectsList.SmallImageList = Me.PrjImageList
        Me.RecentProjectsList.TabIndex = 2
        Me.RecentProjectsList.UseCompatibleStateImageBehavior = False
        Me.RecentProjectsList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 314
        '
        'PrjImageList
        '
        Me.PrjImageList.ImageStream = CType(resources.GetObject("PrjImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.PrjImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.PrjImageList.Images.SetKeyName(0, "new2_16.png")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 201)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 18)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Recent Projects List"
        '
        'ToolTippi
        '
        Me.ToolTippi.IsBalloon = True
        '
        'LoadButton
        '
        Me.LoadButton.BackColor = System.Drawing.Color.Gainsboro
        Me.LoadButton.Image = MSXdevTools.GUIcontrols.My.Resources.Resources.load_project
        Me.LoadButton.Location = New System.Drawing.Point(195, 14)
        Me.LoadButton.Name = "LoadButton"
        Me.LoadButton.Size = New System.Drawing.Size(160, 160)
        Me.LoadButton.TabIndex = 1
        Me.ToolTippi.SetToolTip(Me.LoadButton, "Load Project")
        Me.LoadButton.UseVisualStyleBackColor = False
        '
        'NewButton
        '
        Me.NewButton.BackColor = System.Drawing.Color.Gainsboro
        Me.NewButton.Image = MSXdevTools.GUIcontrols.My.Resources.Resources.NEW_project128
        Me.NewButton.Location = New System.Drawing.Point(15, 14)
        Me.NewButton.Name = "NewButton"
        Me.NewButton.Size = New System.Drawing.Size(160, 160)
        Me.NewButton.TabIndex = 0
        Me.ToolTippi.SetToolTip(Me.NewButton, "New Project")
        Me.NewButton.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.NewButton)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.LoadButton)
        Me.Panel1.Controls.Add(Me.RecentProjectsList)
        Me.Panel1.Location = New System.Drawing.Point(56, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(372, 358)
        Me.Panel1.TabIndex = 4
        '
        'InitLauncher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.Controls.Add(Me.Panel1)
        Me.Name = "InitLauncher"
        Me.Size = New System.Drawing.Size(482, 364)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NewButton As System.Windows.Forms.Button
    Friend WithEvents LoadButton As System.Windows.Forms.Button
    Friend WithEvents RecentProjectsList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolTippi As System.Windows.Forms.ToolTip
    Friend WithEvents PrjImageList As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel

End Class
