''' <summary>
''' Ventana modal (form), para mostrar la lista de los proyectos recientes al pulsar un botón (tipo menú contextual).
''' </summary>
''' <remarks></remarks>
Public Class _RecentListWin_DEPRECATED

    ''' <summary>
    ''' Proporciona el nombre del proyecto seleccionado.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ItemSelected() As String
        Get
            Return RecentProjectsList.SelectedItems(0).Name
        End Get
    End Property


    ''' <summary>
    ''' Constructor.
    ''' </summary>
    ''' <param name="aList"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal aList As RecentProjectsList)
        Dim aProjectItem As ProjectFileItem

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        For i As Integer = 0 To aList.Count - 1
            aProjectItem = aList.GetFileItem(i)
            AddObject(aProjectItem.Name, aProjectItem.Path)
        Next

    End Sub


    ''' <summary>
    ''' Añade un item a la lista de proyectos recientes.
    ''' </summary>
    ''' <param name="name">Nombre del proyecto.</param>
    ''' <param name="path">Ruta absoluta del fichero del proyecto.</param>
    ''' <remarks></remarks>
    Public Sub AddObject(ByVal name As String, ByVal path As String)

        Dim item1 As New ListViewItem()
        item1.ImageIndex = 0
        item1.Text = name
        item1.Name = path
        Me.RecentProjectsList.Items.Add(item1)

    End Sub


    ''' <summary>
    ''' Evento de doble-clic sobre un proyecto reciente
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RecentProjectsList_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecentProjectsList.DoubleClick
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub


    ''' <summary>
    ''' si se pulsa el botón derecho cierra la ventana sin cargar
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RecentProjectsList_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles RecentProjectsList.MouseDown
        'If e.Button = Windows.Forms.MouseButtons.Left Then
        'Else
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub




    'Private Sub RecentListWin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click
    '    If RecentProjectsList.SelectedItems.Count = 0 Then
    '        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    '    End If
    'End Sub
End Class