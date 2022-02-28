Imports System.Xml



''' <summary>
''' Gestiona una lista de varios tilesets.
''' </summary>
''' <remarks></remarks>
Public Class TilesetProject

    'Public Info As ProjectInfo

    Private Items As New Hashtable()
    Private NamesList As New SortedNamesList

    Private _foregroundColor As Byte = 15
    Private _backgroundColor As Byte = 4

    Private _paletteProject As PaletteProject


    Private Const MAXIMUM = 127 ' <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< maximum number of items


    Public ReadOnly Property Count()
        Get
            Return Me.Items.Count
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



    Public Property ForegroundColor() As Byte
        Get
            Return Me._foregroundColor
        End Get
        Set(ByVal value As Byte)
            Me._foregroundColor = value
        End Set
    End Property



    Public Property BackgroundColor() As Byte
        Get
            Return Me._backgroundColor
        End Get
        Set(ByVal value As Byte)
            Me._backgroundColor = value
        End Set
    End Property



    Public Sub New()

        'Me.Info = New ProjectInfo

        Me._paletteProject = New PaletteProject

    End Sub



    Public Sub New(ByVal _palettes As PaletteProject)

        'Me.Info = New ProjectInfo

        Me._paletteProject = _palettes

    End Sub



    'Public Sub SetDefault()
    '    Clear()
    '    AddTileset(GetClearTileset())
    'End Sub
    '    Me.SingleSet = True
    '    Dim tmpPattern() As Byte = {0, 0, 0, 0, 0, 0, 0, 0}

    '    Me._foregroundColor = 15
    '    Me._backgroundColor = 4

    '    For tileNumber As Integer = 0 To 255
    '        Me.Tileset.Add(tileNumber, New TileMSX(tileNumber, Me.screenMode, tmpPattern, Nothing, Me._Palette, Me._foregroundColor, Me._backgroundColor))
    '    Next
    'End Sub



    Public Function GetClearTileset() As TilesetMSX

        Return New TilesetMSX(Me._paletteProject.GetPalette(0), "default_Tileset", iVDP.SCREEN_MODE.G2, Me.ForegroundColor, Me.BackgroundColor)

    End Function



    Public Sub Clear()

        'Me.Info.Clear()

        Me.Items.Clear()
        Me.NamesList.Clear()

    End Sub



    Public Function Add(ByVal item As TilesetMSX) As Integer

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




    Public Sub Update(ByVal ID As Integer, ByVal tileset As TilesetMSX)
        If Me.Items.ContainsKey(ID) Then
            tileset.ID = ID
            Me.Items.Item(ID) = tileset
            tileset.Name = Me.NamesList.UpdateName(ID, tileset.Name)
        End If
    End Sub



    Public Function GetTileset(ByVal index As Integer) As TilesetMSX
        Dim ID As Integer = Me.NamesList.GetIDbyIndex(index)
        Return GetTilesetByID(ID)
    End Function



    Public Function GetTilesetByID(ByVal ID As Integer) As TilesetMSX
        Return Me.Items.Item(ID)
    End Function



    Public Function Contains(ByVal ID As Integer) As Boolean
        Return Me.Items.Contains(ID)
    End Function



    Public Sub Delete(ByVal index As Integer)
        Dim ID As Integer

        If Me.Items.Count > 0 Then
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



    'Private Sub Reorder()
    '    Dim tmp As New SortedList()
    '    Dim order As Integer = 0
    '    For Each tileset As TilesetMSX In Me.Tilesets.Values
    '        tmp.Add(order, tileset)
    '        order += 1
    '    Next
    '    Me.Tilesets = tmp
    'End Sub



    Public Sub SetTile(ByVal tilesetID As Integer, ByVal tileID As Integer, ByVal tile As TileMSX)

        If Me.Items.ContainsKey(tilesetID) Then
            Me.Items.Item(tilesetID).UpdateTile(tileID, tile)
        End If

    End Sub



    Public Function GetTile(ByVal tilesetID As Integer, ByVal tileID As Integer) As TileMSX

        Dim tmpTileset As TilesetMSX = GetTilesetByID(tilesetID)

        Return tmpTileset.GetTile(tileID)

    End Function



    Public Function GetPatternBinaryBloqByIndex(ByVal index As Integer) As Byte()

        Return GetPatternData(GetTileset(index))

    End Function



    Public Function GetPatternBinaryBloqByID(ByVal ID As Integer) As Byte()

        Return GetPatternData(GetTilesetByID(ID))

    End Function




    Public Function GetPatternData(ByRef tileset As TilesetMSX) As Byte()
        Dim data(&H7FF) As Byte
        Dim destinationIndex As Integer = 0
        Dim aTile As TileMSX

        If Not tileset Is Nothing Then
            For i As Integer = 0 To 255
                aTile = tileset.GetTile(i)
                Array.Copy(aTile.Pattern, 0, data, destinationIndex, 8)
                destinationIndex += 8
            Next
        End If

        Return data

    End Function



    'Public Function GetNameListFromNode(ByVal aDataNode As XmlNode) As ArrayList

    '    Dim nameList As New ArrayList

    '    Dim aNodeList As XmlNodeList
    '    Dim aNode As XmlNode

    '    aNodeList = aDataNode.SelectNodes("tileset")
    '    If Not aNodeList Is Nothing Then
    '        For Each anItemNode As XmlNode In aNodeList
    '            aNode = anItemNode.SelectSingleNode("@name")
    '            If Not aNode Is Nothing Then
    '                nameList.Add(aNode.InnerText)
    '            End If
    '        Next
    '    End If

    '    Return nameList

    'End Function




    'Public Function GetColorBinaryBloqByID(ByVal ID As Integer, ByVal _mode As iVDP.SCREEN_MODE) As Byte()

    '    If _mode = iVDP.SCREEN_MODE.G1 Then
    '        Return GetTilesetG1ColorData(ID)
    '    Else
    '        Return GetColorData(GetTilesetByID(ID))
    '    End If

    'End Function



    'Public Function GetColorBinaryBloqByID(ByVal ID As Integer) As Byte()


    'End Function


    Public Function GetColorBinaryBloqByID(ByVal ID As Integer, ByVal mode As iVDP.SCREEN_MODE) As Byte()

        Dim tileset As TilesetMSX = GetTilesetByID(ID)

        If Not tileset Is Nothing Then
            If mode = iVDP.SCREEN_MODE.G1 Then
                Return GetG1ColorData(tileset)
            Else
                Return GetG2ColorData(tileset)
            End If
        Else
            Return Nothing
        End If

    End Function



    'Public Function GetColorBinaryBloqByID(ByVal ID As Integer, ByVal colorMode As iVDP.SCREEN_MODE) As Byte()
    '    Dim tileset As TilesetMSX = GetTilesetByID(ID)
    '    Return GetColorData(tileset, tileset.Mode)
    'End Function



    'Public Function GetColorData(ByRef tileset As TilesetMSX) As Byte()
    '    Return GetColorData(tileset, tileset.Mode)
    'End Function



    Public Function GetG2ColorData(ByRef tileset As TilesetMSX) As Byte()
        Dim data(&H7FF) As Byte
        'Dim _tileset As TilesetMSX
        Dim destinationIndex As Integer = 0

        Dim color As Byte

        Dim o As Integer

        If Not tileset Is Nothing Then
            'If Contains(ID) Then
            '    tileset = GetTilesetByID(ID)

            Select Case tileset.Mode
                Case iVDP.SCREEN_MODE.T1
                    color = (Me._foregroundColor * 16) + Me._backgroundColor
                    For o = 0 To &H7FF
                        data(o) = color
                    Next

                Case iVDP.SCREEN_MODE.G1
                    destinationIndex = 0
                    For i As Integer = 0 To 31
                        For o = 0 To 63  ' (8 tiles * 8 bytes) - 1
                            data(destinationIndex) = tileset.TilesetColorG1(i)
                            destinationIndex += 1
                        Next
                    Next

                Case iVDP.SCREEN_MODE.G2
                    For Each aTile As TileMSX In tileset.Tileset.Values
                        Array.Copy(aTile.Color, 0, data, destinationIndex, 8)
                        destinationIndex += 8
                    Next

            End Select

        End If

        Return data
    End Function



    Public Function GetG1ColorData(ByRef tileset As TilesetMSX) As Byte()
        Dim data(31) As Byte

        Dim color As Byte

        If tileset.Mode = iVDP.SCREEN_MODE.G1 Then
            Return tileset.TilesetColorG1
        Else
            color = (Me._foregroundColor * 16) + Me._backgroundColor
            For i As Integer = 0 To 31
                data(i) = color
            Next

            Return data
        End If

    End Function



    Public Function GetNameList() As ArrayList
        Return NamesList.GetNameList()
    End Function



    Public Sub ChangeName(ByVal ID As Integer, ByVal aName As String)
        Dim tmpTileset As TilesetMSX = Me.Items.Item(ID)
        tmpTileset.Name = Me.NamesList.UpdateName(ID, aName)
    End Sub



    Public Function GetIndexFromID(ByVal ID As Integer) As Integer
        Return Me.NamesList.GetIndexByID(ID)
    End Function



    Public Function GetIDFromIndex(ByVal index As Integer) As Integer
        Return Me.NamesList.GetIDbyIndex(index)
    End Function

  


End Class
