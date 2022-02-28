''' <summary>
''' Clase para controlar la lista de proyectos recientes
''' </summary>
''' <remarks></remarks>
Public Class LastProjectsList

    Private _IndexList As New ArrayList
    Private _dataItems As New Hashtable


    Public ReadOnly Property Count()
        Get
            Return _IndexList.Count
        End Get
    End Property


    Public Sub New()

    End Sub


    Public Sub New(ByVal list As SortedList)
        For Each path As String In list.Values
            AddOrdered(path)
        Next
    End Sub


    ''' <summary>
    ''' Añade un item al final de la lista.
    ''' </summary>
    ''' <param name="path"></param>
    ''' <remarks></remarks>
    Private Sub AddOrdered(ByVal path As String)
        Dim name As String
        name = System.IO.Path.GetFileName(path)

        'Dim hashCode As Integer = GetHash()

        If Not name = "" And Not _dataItems.ContainsKey(name) Then
            _IndexList.Add(name)
            _dataItems.Add(name, New ProjectFileItem(name, path))
        End If

    End Sub


    ''' <summary>
    ''' Añade un item al principio de la lista a partir de la ruta absoluta. 
    ''' Utiliza el nombre de fichero con su extensión, como nombre del item.
    ''' </summary>
    ''' <param name="path"></param>
    ''' <remarks></remarks>
    Public Sub Add(ByVal path As String)
        Dim name As String

        If Not path = "" Then
            name = System.IO.Path.GetFileName(path)
            Me.Add(name, path)
        End If

    End Sub


    ''' <summary>
    ''' Añade un item al principio de la lista.
    ''' </summary>
    ''' <param name="name"></param>
    ''' <param name="path"></param>
    ''' <remarks></remarks>
    Public Sub Add(ByVal name As String, ByVal path As String)

        If _dataItems.ContainsKey(name) Then
            ' si ya contiene el fichero, lo elimina de la lista para que aparezca en primera posicion
            _IndexList.Remove(name)
            _dataItems.Remove(name)
        End If

        _IndexList.Insert(0, name)
        _dataItems.Add(name, New ProjectFileItem(name, path))

        If _IndexList.Count > 10 Then
            name = _IndexList(10)
            _IndexList.Remove(name)
            _dataItems.Remove(name)
        End If

    End Sub

    'Public Sub Add(ByVal name As String, ByVal path As String)

    '    Dim hashCode As Integer = GetHash()

    '    _IndexList.Insert(0, hashCode)
    '    _dataItems.Add(hashCode, New ProjectFileItem(hashCode, name, path))

    '    If _IndexList.Count > 10 Then
    '        hashCode = _IndexList(10)
    '        _dataItems.Remove(hashCode)
    '        _IndexList.Remove(hashCode)
    '    End If

    'End Sub

    Private Function GetHash() As Integer
        Dim rnd1 As New Random()
        Dim hashCode As Integer

        Do
            hashCode = rnd1.Next
        Loop While (_IndexList.Contains(hashCode))

        Return hashCode
    End Function


    Public Function GetFileItem(ByVal index As Integer) As ProjectFileItem
        Return _dataItems.Item(_IndexList(index))
    End Function


    Public Sub clear()
        Me._IndexList.Clear()
        Me._dataItems.Clear()
    End Sub


End Class
