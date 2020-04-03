''' <summary>
''' Clase con la información basica de un fichero de proyecto.
''' Para el control de la lista de proyectos recientes.
''' </summary>
''' <remarks></remarks>
Public Class ProjectFileItem

    'Private _id As Integer
    Private _name As String
    Private _path As String


    Public Sub New(ByVal name As String, ByVal path As String)
        Me.Name = name
        Me.Path = path
    End Sub


    'Public Sub New(ByVal id As Integer, ByVal name As String, ByVal path As String)
    '    Me._id = id
    '    Me.Name = name
    '    Me.Path = path
    'End Sub


    'Public Property ID() As Integer
    '    Get
    '        Return Me._id
    '    End Get
    '    Set(ByVal value As Integer)
    '        Me._id = value
    '    End Set
    'End Property

    ''' <summary>
    ''' Nombre del proyecto.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Name() As String
        Get
            Return Me._name
        End Get
        Set(ByVal value As String)
            Me._name = value
        End Set
    End Property


    ''' <summary>
    ''' Ruta absoluta del fichero del proyecto.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Path() As String
        Get
            Return Me._path
        End Get
        Set(ByVal value As String)
            Me._path = value
        End Set
    End Property


    ''' <summary>
    ''' Proporciona una nueva instancia del objeto.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function clone() As ProjectFileItem
        Dim tmpFileItem As New ProjectFileItem(Me.Name, Me.Path)
        Return tmpFileItem
    End Function

End Class
