Public Class SpriteProject

    Private Const MAXIMUM = 127 ' <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< maximum number of items

    Public Items As New Hashtable()
    Private NamesList As New SortedNamesList


    Private _paletteProject As PaletteProject





    Public ReadOnly Property Count()
        Get
            Return NamesList.Count
        End Get
    End Property



    Public Property Palettes() As PaletteProject
        Get
            Return Me._paletteProject
        End Get
        Set(ByVal value As PaletteProject)
            Me._paletteProject = value
        End Set
    End Property




    Public Sub New()

        Me._paletteProject = New PaletteProject

        'Clear()

    End Sub



    Public Sub New(ByVal _palettes As PaletteProject)

        Me._paletteProject = _palettes

    End Sub



    Public Sub Clear()

        Me.Items.Clear()
        Me.NamesList.Clear()

    End Sub



    Public Function GetIndexFromID(ByVal ID As Integer) As Integer
        Return Me.NamesList.GetIndexByID(ID)
    End Function



    Public Function GetIDFromIndex(ByVal index As Integer) As Integer
        Return Me.NamesList.GetIDbyIndex(index)
    End Function



    Public Function Add(ByVal item As SpritesetMSX) As Integer

        Dim ID As Integer

        If item Is Nothing Then
            Return -1
        End If

        ID = item.ID

        If Me.Items.Count < MAXIMUM Then

            If Me.Items.ContainsKey(ID) Then
                ID = item.GetHashCode + CInt(Rnd() * 100000)
                item.ID = ID
            End If

            item.Name = Me.NamesList.AddName(ID, item.Name)
            Me.Items.Add(ID, item)

            Return ID
        Else
            Return -1
        End If

    End Function



    Public Function GetSpriteset(ByVal index As Integer) As SpritesetMSX
        Dim ID As Integer = Me.NamesList.GetIDbyIndex(index)
        Return GetSpritesetByID(ID)
    End Function



    Public Function GetSpritesetByID(ByVal ID As Integer) As SpritesetMSX
        If Not Me.Items.Contains(ID) Then
            ID = Me.NamesList.GetIDbyIndex(0)  ' <<< ------------------------------------------------------------- OJO medida de seguridad que se deberia de controlar desde donde se hace la llamada a esta funcion (reaaccion ante un nothing)
        End If

        Return Me.Items.Item(ID)
    End Function



    Public Function Contains(ByVal ID As Integer) As Boolean
        Return Me.Items.Contains(ID)
    End Function



    Public Sub Delete(ByVal index As Integer)
        Dim ID As Integer

        If Me.NamesList.Count > 0 Then
            ID = Me.NamesList.GetIDbyIndex(index)
            DeleteByID(ID)
        End If

    End Sub



    Public Sub DeleteByID(ByVal ID As Integer)
        If Me.Items.ContainsKey(ID) Then
            Me.Items.Remove(ID)
            Me.NamesList.RemoveByID(ID)
        End If
    End Sub



    Public Sub Update(ByVal ID As Integer, ByVal spriteset As SpritesetMSX)
        If Me.Items.ContainsKey(ID) Then
            Me.Items.Item(ID) = spriteset
            spriteset.Name = Me.NamesList.UpdateName(ID, spriteset.Name)
        End If
    End Sub



    Public Sub ChangeName(ByVal ID As Integer, ByVal aName As String)
        Dim tmpSpriteset As SpritesetMSX = Me.Items.Item(ID)
        tmpSpriteset.Name = Me.NamesList.UpdateName(ID, aName)
    End Sub



    Public Function GetNameList() As ArrayList

        ' genera una lista con los nombres de los tilesets
        'Dim nameList As New ArrayList

        'If Me.Count > 0 Then
        '    For i As Integer = 0 To Me.Count - 1
        '        nameList.Add(Me.Spritesets.Item(Me.spritesetsIndex.Item(i)).Name)
        '        'SpritesetsList
        '    Next
        'End If

        Return NamesList.GetNameList

    End Function



    ''' <summary>
    ''' Fusiona los datos de color + bit de OR en un solo array.
    ''' </summary>
    ''' <param name="colorData"></param>
    ''' <param name="orData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function JoinColorData(ByVal colorData As Byte(), ByVal orData As Boolean()) As Byte()
        Dim anOutput As Byte()
        Dim i As Integer

        ReDim anOutput(colorData.Length - 1)

        For i = 0 To colorData.Length - 1
            If orData(i) = True Then
                anOutput(i) = colorData(i) + 64
            Else
                anOutput(i) = colorData(i)
            End If
        Next

        Return anOutput
    End Function




End Class
