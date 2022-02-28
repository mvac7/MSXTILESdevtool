Public Class MapMSX

    Public ID As Integer

    Public Name As String = ""

    Public TileType As TILE_TYPE = TILE_TYPE.SimpleTILE
    Public MapType As MAP_TYPE = MAP_TYPE.Custom

    Public Tileset As Integer = 0
    Public TilesetB As Integer = 0
    Public TilesetC As Integer = 0

    Public SupertilesetID As Integer = 0

    Public Width As Integer = 31
    Public Height As Integer = 23

    Public Shadows Const MAX_width = 1023
    Public Shadows Const MAX_height = 1023

    Public Lines As New SortedList()



    Public Shadows Enum TILE_TYPE As Integer
        SimpleTILE
        SuperTILE
    End Enum



    Public Shadows Enum MAP_TYPE As Integer
        ScreenG2
        Custom
    End Enum



    ''' <summary>
    ''' Custom type
    ''' </summary>
    ''' <param name="_name"></param>
    ''' <param name="_width"></param>
    ''' <param name="_height"></param>
    ''' <param name="_tileType"></param>
    ''' <param name="_tileset"></param>
    Public Sub New(ByVal _name As String, ByVal _width As Integer, ByVal _height As Integer, ByVal _tileType As TILE_TYPE, ByVal _tileset As Integer)

        Me.ID = Me.GetHashCode() + CInt(Rnd() * 100000) 'genera un identificador

        Me.Name = _name
        Me.MapType = MAP_TYPE.Custom
        Me.TileType = _tileType
        Me.Width = _width
        Me.Height = _height

        If _tileType = TILE_TYPE.SimpleTILE Then
            Me.Tileset = _tileset
            Me.TilesetB = _tileset
            Me.TilesetC = _tileset
        Else
            'Supertiles 2x2
            Me.SupertilesetID = _tileset
        End If

        InitMap(Nothing)

    End Sub


    ''' <summary>
    ''' Custom type width data
    ''' </summary>
    ''' <param name="_name"></param>
    ''' <param name="_width"></param>
    ''' <param name="_height"></param>
    ''' <param name="_tileType"></param>
    ''' <param name="_tileset"></param>
    ''' <param name="data"></param>
    Public Sub New(ByVal _name As String, ByVal _width As Integer, ByVal _height As Integer, ByVal _tileType As TILE_TYPE, ByVal _tileset As Integer, ByVal data As Byte())

        Me.ID = Me.GetHashCode() + CInt(Rnd() * 100000) 'genera un identificador

        Me.Name = _name
        Me.MapType = MAP_TYPE.Custom
        Me.TileType = _tileType
        Me.Width = _width
        Me.Height = _height

        If _tileType = TILE_TYPE.SimpleTILE Then
            Me.Tileset = _tileset
            Me.TilesetB = _tileset
            Me.TilesetC = _tileset
        Else
            'Supertiles 2x2
            Me.SupertilesetID = _tileset
        End If

        InitMap(data)

    End Sub




    ' Screen 2 G2 type (32 x 24 x 3 tilesets)
    Public Sub New(ByVal _name As String, ByVal _tilesetA As Integer, ByVal _tilesetB As Integer, ByVal _tilesetC As Integer, ByVal data As Byte())

        Me.ID = Me.GetHashCode() + CInt(Rnd() * 100000)

        Me.Name = _name
        Me.MapType = MAP_TYPE.ScreenG2
        Me.TileType = TILE_TYPE.SimpleTILE
        Me.Width = 32
        Me.Height = 24

        Me.Tileset = _tilesetA
        Me.TilesetB = _tilesetB
        Me.TilesetC = _tilesetC

        InitMap(data)

    End Sub



    ''' <summary>
    ''' -------------------------------------------------------------->>> ???
    ''' </summary>
    ''' <param name="_id"></param>
    ''' <param name="_name"></param>
    ''' <param name="_MapType"></param>
    ''' <param name="_tileType"></param>
    ''' <param name="_width"></param>
    ''' <param name="_tilesetA"></param>
    ''' <param name="_tilesetB"></param>
    ''' <param name="_tilesetC"></param>
    ''' <param name="_supertilesetID"></param>
    ''' <param name="data"></param>
    Public Sub New(ByVal _id As Integer, ByVal _name As String, ByVal _MapType As MapMSX.MAP_TYPE, ByVal _tileType As TILE_TYPE, ByVal _width As Integer, ByVal _tilesetA As Integer, ByVal _tilesetB As Integer, ByVal _tilesetC As Integer, ByVal _supertilesetID As Integer, ByVal data As ArrayList)

        Me.Name = _name
        Me.MapType = _MapType
        Me.TileType = _tileType
        Me.Width = _width
        Me.Height = data.Count

        Me.Tileset = _tilesetA
        Me.TilesetB = _tilesetB
        Me.TilesetC = _tilesetC

        Me.SupertilesetID = _supertilesetID

        If data Is Nothing Then
            InitMap(Nothing)
        Else
            For i As Integer = 0 To Me.Height - 1
                Me.Lines.Add(i, data.Item(i))
            Next
        End If

        If _id < 16 Then
            Me.ID = Me.GetHashCode() + CInt(Rnd() * 100000) 'genera un identificador
        Else
            Me.ID = _id
        End If

    End Sub



    ''' <summary>
    ''' classics MSx screen modes 
    ''' </summary>
    ''' <param name="_name"></param>
    ''' <param name="_mode"></param>
    ''' <param name="data"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _name As String, ByVal _mode As iVDP.SCREEN_MODE, ByVal data As Byte())

        Me.ID = Me.GetHashCode() + CInt(Rnd() * 100000)

        Me.Name = _name
        Me.Height = 24
        Me.Tileset = 0
        Me.TileType = TILE_TYPE.SimpleTILE
        If _mode = iVDP.SCREEN_MODE.G2 Then
            Me.MapType = MapMSX.MAP_TYPE.ScreenG2
            Me.TilesetB = 1
            Me.TilesetC = 2
        Else
            Me.MapType = MapMSX.MAP_TYPE.Custom
            Me.TilesetB = 0
            Me.TilesetC = 0
        End If

        If _mode = iVDP.SCREEN_MODE.T1 Then
            Me.Width = 40
        Else
            Me.Width = 32
        End If

        InitMap(data)

    End Sub


    'Public Sub AddMapFromBinary(ByVal _name As String, ByVal _mode As TMS9918.SCREEN_MODE, ByVal data As Byte())

    '    Dim aMap As New MapMSX

    '    Dim lineData() As Byte
    '    Dim _lines As New SortedList()

    '    Dim dataPos As Integer = 0

    '    aMap.Name = _name
    '    aMap.Height = 24
    '    aMap.Tileset = 0
    '    aMap.TileType = MapMSX.TILE_TYPE.SingleTILE
    '    If _mode = TMS9918.SCREEN_MODE.G2 Then
    '        aMap.ScreenType = MapMSX.MAP_TYPE.ScreenG2
    '        aMap.TilesetB = 1
    '        aMap.TilesetC = 2
    '    Else
    '        aMap.ScreenType = MapMSX.MAP_TYPE.Custom
    '    End If

    '    If _mode = TMS9918.SCREEN_MODE.T1 Then
    '        aMap.Width = 40
    '    Else
    '        aMap.Width = 32
    '    End If

    '    ReDim lineData(aMap.Width - 1)

    '    For numLine As Integer = 0 To 23
    '        For numColumn As Integer = 0 To aMap.Width - 1
    '            lineData(numColumn) = data(dataPos)
    '            dataPos += 1
    '        Next
    '        _lines.Add(numLine, lineData.Clone)
    '    Next

    '    aMap.Lines = _lines

    'End Sub



    Public Function Clone() As MapMSX

        Dim lineData() As Byte

        Dim newMap As New MapMSX(Me.Name, Me.Width, Me.Height, Me.TileType, Me.Tileset)

        newMap.MapType = Me.MapType

        newMap.TilesetB = Me.TilesetB
        newMap.TilesetC = Me.TilesetC

        newMap.SupertilesetID = Me.SupertilesetID

        newMap.Lines = New SortedList()

        For numLine As Integer = 0 To Me.Height - 1
            lineData = Me.Lines.Item(numLine).Clone
            newMap.Lines.Add(numLine, lineData)
        Next

        'BUG #249 ?
        'hay casos en el que el HashCode devuelve el mismo valor.
        'If newMap.ID = Me.ID Then
        '    newMap.ID = newMap.GetHashCode()+ CInt(Rnd())
        'End If

        Return newMap
    End Function



    Public Sub ChangeMapSize(ByVal _width As Integer, ByVal _height As Integer, ByVal _tileType As TILE_TYPE)
        'Me.Name = _name
        'Me.ScreenType = _screenType
        Me.TileType = _tileType
        Me.Width = _width
        Me.Height = _height

        'Me.Tileset = _tileset
        'Me.TilesetB = _tileset
        'Me.TilesetC = _tileset

        Dim tmpLines As SortedList = Me.Lines.Clone
        Me.Lines.Clear()

        For numLine As Integer = 0 To Me.Height - 1
            Dim lineData(Me.Width - 1) As Byte
            If numLine < tmpLines.Count Then
                Dim data() As Byte = tmpLines.Item(numLine)
                For i = 0 To Me.Width - 1
                    If i < data.Length Then
                        If Me.TileType = TILE_TYPE.SimpleTILE Then
                            lineData(i) = data(i)
                        Else
                            lineData(i) = data(i) And 63
                        End If
                    Else
                        lineData(i) = 0
                    End If
                Next
            Else
                For i = 0 To Me.Width - 1
                    lineData(i) = 0
                Next
            End If

            Me.Lines.Add(numLine, lineData.Clone)
        Next

    End Sub




    Private Sub InitMap(ByVal data As Byte())

        Dim lineData() As Byte
        Dim dataPos As Integer = 0

        Me.Lines.Clear()

        ReDim lineData(Me.Width - 1)

        If data Is Nothing Then
            ' crea una linea 

            For i As Integer = 0 To Me.Width - 1
                lineData(i) = 0
            Next

            'clona la lina a todas las lineas del mapa
            For numLine As Integer = 0 To Me.Height - 1
                Me.Lines.Add(numLine, lineData.Clone)
            Next
        Else
            For numLine As Integer = 0 To Me.Height - 1
                For numColumn As Integer = 0 To Me.Width - 1
                    lineData(numColumn) = data(dataPos)
                    dataPos += 1
                Next
                Me.Lines.Add(numLine, lineData.Clone)
            Next
        End If

    End Sub



    Public Sub AddLine(ByVal numLine As Integer, ByVal lineData() As Byte)
        If Me.Lines.ContainsKey(numLine) Then
            Me.Lines.Item(numLine) = lineData
        Else
            Me.Lines.Add(numLine, lineData)
        End If
    End Sub



    Public Function GetData() As Byte()
        Dim data As Byte()
        Dim line As Byte()
        ReDim data((Me.Width * Me.Height) - 1)

        For i As Integer = 0 To Me.Height - 1 'Me.Lines.Count - 1
            line = Me.Lines.Item(i)
            line.CopyTo(data, i * Me.Width)
        Next

        Return data
    End Function



    Public Function GetLine(ByVal numLine As Integer) As Byte()
        If numLine < Me.Height Then
            Return Me.Lines.Item(numLine)
        Else
            Return Nothing
        End If
    End Function



    Public Sub SetTile(ByVal x As Integer, ByVal y As Integer, ByVal value As Byte)
        If x > -1 And x < Me.Width Then
            If y > -1 And y < Me.Height Then
                Me.Lines.Item(y)(x) = value
            End If
        End If
    End Sub



    Public Function GetTile(ByVal x As Integer, ByVal y As Integer) As Byte
        Dim value As Byte
        Dim line() As Byte

        If x > -1 And x < Me.Width Then
            If y > -1 And y < Me.Height Then
                line = Me.Lines.Item(y)
                value = line(x)
            End If
        End If

        Return value
    End Function



    'Public Function GetStringMapType() As String
    '    Dim output As String
    '    Select Case Me.MapType
    '        Case MAP_TYPE.ScreenG2
    '            output = "G2 (3 tilesets)"
    '        Case Else
    '            output = "Custom (1 tileset)"
    '    End Select
    '    Return output
    'End Function

End Class
