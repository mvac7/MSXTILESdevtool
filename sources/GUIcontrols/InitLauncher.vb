''' <summary>
''' Control de pantalla, para el estado incial de una aplicación.
''' Permite empezar un proyecto o cargarlo mediante un dialogo o desde la lista de proyectos recientes (10).
''' </summary>
''' <remarks></remarks>
Public Class InitLauncher

    Public Event SetNew()
    Public Event SetLoad()
    Public Event SetFile(ByVal path As String)



    Public Sub New(ByVal aList As RecentProjectsList)
        Dim aProjectItem As ProjectFileItem

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        'If Not aList Is Nothing Then
        ' añade los items a la lista de proyectos recientes
        For i As Integer = 0 To aList.Count - 1
            aProjectItem = aList.GetFileItem(i)
            AddObject(aProjectItem.Name, aProjectItem.Path)
        Next
        'End If

    End Sub


    ''' <summary>
    ''' Añade un item a la lista de proyectos recientes
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
    Private Sub RecentProjectsList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles RecentProjectsList.DoubleClick
        Dim path As String
        path = RecentProjectsList.SelectedItems(0).Name

        If Not path = "" Then
            'MsgBox(path)
            RaiseEvent SetFile(RecentProjectsList.SelectedItems(0).Name)
        End If

    End Sub

    ''' <summary>
    ''' Evento de pulsación sobre el botón de Nuevo Proyecto
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub NewButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewButton.Click
        RaiseEvent SetNew()
    End Sub


    ''' <summary>
    ''' Evento de pulsación sobre el botón para la carga de un proyecto
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LoadButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadButton.Click
        RaiseEvent SetLoad()
    End Sub

End Class
