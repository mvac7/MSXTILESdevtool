Public Class TilesetMSX

    Public ID As Integer
    Public Name As String = "tileset"

    Private tilesetMode As iVDP.SCREEN_MODE

    Public Tileset As New SortedList(255)

    'Private TilesetG1Color(31) As Byte

    Private _foregroundColor As Byte = 15
    Private _backgroundColor As Byte = 4

    'Private _PaletteID As Integer = 0
    Private _Palette As iPaletteMSX
    'Private _paletteProject As PaletteProject

    Public TilesetColorG1(31) As Byte



    Public Property Mode() As iVDP.SCREEN_MODE
        Get
            Return Me.tilesetMode
        End Get
        Set(ByVal value As iVDP.SCREEN_MODE)
            Me.tilesetMode = value
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



    'Public Property PaletteID() As Integer
    '    Get
    '        Return Me._PaletteID
    '    End Get
    '    Set(ByVal value As Integer)
    '        setPalette(value)
    '    End Set
    'End Property



    Public Property Palette() As iPaletteMSX
        Get
            Return Me._Palette
        End Get
        Set(ByVal value As iPaletteMSX)
            Me._Palette = value
            'Refresh()
        End Set
    End Property



    Public Sub ChangePalette(ByVal palette As iPaletteMSX)
        Me._Palette = palette
        Refresh()
    End Sub

    'Public Sub New(ByVal palettes As PaletteProject)

    '    Me.ID = Me.GetHashCode() 'genera un identificador

    '    'Me.tilesetMode = _mode
    '    Me._paletteProject = palettes
    '    setPalette(0)
    '    'SetDefaultG1colors()

    'End Sub



    Public Sub New(ByVal aPalette As iPaletteMSX, ByVal _name As String, ByVal _mode As iVDP.SCREEN_MODE, ByVal FGColor As Byte, ByVal BGColor As Byte)

        Me.ID = Me.GetHashCode() + CInt(Rnd() * 100000) 'genera un identificador unico

        Me.Name = _name
        Me.tilesetMode = _mode
        'Me._paletteProject = palettes
        Me._foregroundColor = FGColor
        Me._backgroundColor = BGColor

        'setPalette(_paletteID)
        Me._Palette = aPalette

        SetDefaultData()
        SetDefaultG1colors()

    End Sub



    ''' <summary>
    ''' Create a new tileset (T1, G1 or G2 mode)
    ''' </summary>
    ''' <param name="aPalette"></param>
    ''' <param name="_name"></param>
    ''' <param name="_mode"></param>
    ''' <param name="patternData"></param>
    ''' <param name="colorData"></param>
    ''' <param name="FGColor"></param>
    ''' <param name="BGColor"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal aPalette As iPaletteMSX, ByVal _name As String, ByVal _mode As iVDP.SCREEN_MODE, ByVal patternData As Byte(), ByVal colorData As Byte(), ByVal FGColor As Byte, ByVal BGColor As Byte)

        Dim tmpTile As TileMSX

        Dim tilePattern(7) As Byte
        Dim tileColor(7) As Byte

        Dim sourceIndex As Integer = 0

        Me.Name = _name
        Me.tilesetMode = _mode
        Me._Palette = aPalette
        Me._foregroundColor = FGColor
        Me._backgroundColor = BGColor


        If Me.tilesetMode = iVDP.SCREEN_MODE.G1 Then
            TilesetColorG1 = colorData
        Else
            SetDefaultG1colors()
        End If

        For tileNumber As Integer = 0 To 255
            Array.Copy(patternData, sourceIndex, tilePattern, 0, 8)

            Select Case Me.tilesetMode
                Case iVDP.SCREEN_MODE.T1
                    tmpTile = New TileMSX(tileNumber, Me.tilesetMode, tilePattern.Clone, Me._Palette, Me._foregroundColor, Me._backgroundColor)
                Case iVDP.SCREEN_MODE.G1
                    tmpTile = New TileMSX(tileNumber, Me.tilesetMode, tilePattern.Clone, Me._Palette, CInt(Me.TilesetColorG1(Fix(tileNumber / 8)) And 240) / 16, CInt(Me.TilesetColorG1(Fix(tileNumber / 8)) And 15))
                Case Else
                    'ScreenProject.SCREEN_MODE.G2
                    Array.Copy(colorData, sourceIndex, tileColor, 0, 8)
                    tmpTile = New TileMSX(tileNumber, Me.tilesetMode, tilePattern.Clone, tileColor.Clone, Me._Palette)
            End Select

            'If Me.tilesetMode = TMS9918.SCREEN_MODE.G1 Then
            '    tmpTile = New TileMSX(tileNumber, Me.tilesetMode, tilePattern.Clone, Me._Palette, CInt(Me.TilesetColorG1(Fix(tileNumber / 8)) And 240) / 16, CInt(Me.TilesetColorG1(Fix(tileNumber / 8)) And 15))
            'Else
            '    Array.Copy(colorData, sourceIndex, tileColor, 0, 8)
            '    tmpTile = New TileMSX(tileNumber, Me.tilesetMode, tilePattern.Clone, tileColor.Clone, Me._Palette)
            'End If

            sourceIndex += 8

            Me.Tileset.Add(tileNumber, tmpTile) ', Me._foregroundColor, Me._backgroundColor
        Next

        Me.ID = Me.GetHashCode() + CInt(Rnd() * 100000) 'genera un identificador

    End Sub




    ' T1 mode
    'Public Sub New(ByVal _ID As Integer, ByVal aPalette As iPaletteMSX, ByVal _name As String, ByVal patternData As Byte(), ByVal FGColor As Byte, ByVal BGColor As Byte)

    '    Dim tmpTile As TileMSX

    '    Dim tilePattern(7) As Byte
    '    Dim tileColor(7) As Byte

    '    Dim sourceIndex As Integer = 0

    '    Me.Name = _name
    '    Me.tilesetMode = TMS9918.SCREEN_MODE.T1
    '    Me._Palette = aPalette
    '    Me._foregroundColor = FGColor
    '    Me._backgroundColor = BGColor


    '    'SetDefaultG1colors()  ' <<<<<<<<<<<<<<<<<<<<<<< OJO (no es necesario?)

    '    For tileNumber As Integer = 0 To 255
    '        Array.Copy(patternData, sourceIndex, tilePattern, 0, 8) 'aTile.Pattern, 0, data, destinationIndex, 8)

    '        tmpTile = New TileMSX(tileNumber, Me.tilesetMode, tilePattern.Clone, Me._Palette, Me._foregroundColor, Me._backgroundColor)

    '        sourceIndex += 8

    '        Me.Tileset.Add(tileNumber, tmpTile) ', Me._foregroundColor, Me._backgroundColor
    '    Next

    '    If _ID < 16 Then
    '        Me.ID = Me.GetHashCode() 'genera un identificador
    '    Else
    '        Me.ID = _ID
    '    End If

    'End Sub



    Public Sub New(ByVal _ID As Integer, ByVal aPalette As iPaletteMSX, ByVal _name As String, ByVal _mode As iVDP.SCREEN_MODE, ByVal _tiles As SortedList, ByVal FGColor As Byte, ByVal BGColor As Byte)

        Dim sourceIndex As Integer = 0

        Me.Name = _name
        Me.tilesetMode = _mode
        Me._Palette = aPalette
        'Me._paletteProject = palettes
        Me._foregroundColor = FGColor
        Me._backgroundColor = BGColor

        'setPalette(_paletteID)

        SetDefaultG1colors()

        If _tiles Is Nothing Then
            SetDefaultData()
        Else
            Me.Tileset = _tiles
        End If

        If _ID < 16 Then
            Me.ID = Me.GetHashCode() + CInt(Rnd() * 100000) 'genera un identificador
        Else
            Me.ID = _ID
        End If

    End Sub



    Public Sub New(ByVal _ID As Integer, ByVal aPalette As iPaletteMSX, ByVal _name As String, ByVal _tiles As SortedList, ByVal G1colorData As Byte(), ByVal FGColor As Byte, ByVal BGColor As Byte)

        Dim sourceIndex As Integer = 0

        Me.Name = _name
        Me.tilesetMode = iVDP.SCREEN_MODE.G1
        Me._Palette = aPalette
        'Me._paletteProject = palettes
        Me._foregroundColor = FGColor
        Me._backgroundColor = BGColor

        'setPalette(_paletteID)


        If G1colorData Is Nothing Then
            SetDefaultG1colors()
        Else
            Me.TilesetColorG1 = G1colorData
        End If


        If _tiles Is Nothing Then
            SetDefaultData()
        Else
            Me.Tileset = _tiles
        End If

        If _ID < 16 Then
            Me.ID = Me.GetHashCode() + CInt(Rnd() * 100000) 'genera un identificador
        Else
            Me.ID = _ID
        End If

    End Sub




    Public Function Clone() As TilesetMSX

        Dim newTileset As New TilesetMSX(Me._Palette, Me.Name, Me.tilesetMode, Me._foregroundColor, Me._backgroundColor)

        'newTileset.Name = Me.Name
        'newTileset.tilesetMode = Me.tilesetMode
        'newTileset._foregroundColor = Me._foregroundColor
        'newTileset._backgroundColor = Me._backgroundColor

        newTileset.TilesetColorG1 = Me.TilesetColorG1.Clone()

        ' correccion BUG #172
        For i As Integer = 0 To 255
            newTileset.Tileset.Item(i) = Me.Tileset.Item(i).clone
        Next
        'newTileset.Tileset = Me.Tileset.Clone() 
        ' END BUG #172

        Return newTileset
    End Function



    Public Function Copy() As TilesetMSX

        Dim newTileset As TilesetMSX

        newTileset = Me.Clone
        newTileset.ID = Me.ID

        Return newTileset
    End Function




    Private Sub SetDefaultData()
        'Dim defPattern() As Byte = {0, 0, 0, 0, 0, 0, 0, 0}
        'Dim defColor() As Byte = {&HF4, &HF4, &HF4, &HF4, &HF4, &HF4, &HF4, &HF4}

        Dim defPattern(7) As Byte
        Dim defColor(7) As Byte

        For i As Integer = 0 To 7
            defPattern(i) = 0
            defColor(i) = (Me._foregroundColor * 16) + Me._backgroundColor
        Next


        'Me.Name = "default_Tileset"
        'Me.tilesetMode = TMS9918.SCREEN_MODE.G2
        'Me._foregroundColor = 15
        'Me._backgroundColor = 4

        For tileNumber As Integer = 0 To 255
            Me.Tileset.Add(tileNumber, New TileMSX(tileNumber, Me.tilesetMode, defPattern.Clone, defColor.Clone, Me._Palette, Me._foregroundColor, Me._backgroundColor))
        Next

        'SetDefaultG1colors()

    End Sub



    Public Sub Clear()
        Me.Name = ""
        'Me.Version = "0"
        'Me.Group = ""
        'Me.Author = ""
        'Me.Description = ""
        'Me.StartDate = DateTime.Today.Ticks
        'Me.LastUpdate = Me.StartDate

        Me.Tileset.Clear()

        SetDefaultG1colors()

    End Sub



    Private Sub SetDefaultG1colors()
        For i As Integer = 0 To 31
            Me.TilesetColorG1(i) = (Me._foregroundColor * 16) + Me._backgroundColor
        Next
    End Sub



    Public Sub Refresh()
        Dim tile As TileMSX
        Dim i As Integer

        If Me.Mode = iVDP.SCREEN_MODE.G1 Then
            Dim checksum As Integer
            For i = 0 To 31
                checksum += Me.TilesetColorG1(i)
            Next
            If checksum = 0 Then
                SetDefaultG1colors()
            End If
        End If

        For i = 0 To 255
            tile = Me.Tileset.Item(i)
            tile.Palette = Me._Palette
            tile.Mode = Me.Mode
            If Me.Mode = iVDP.SCREEN_MODE.G1 Then
                tile.InkColor = CInt(Me.TilesetColorG1(Fix(i / 8)) And 240) / 16
                tile.BackgroundColor = CInt(Me.TilesetColorG1(Fix(i / 8)) And 15)
            ElseIf Me.Mode = iVDP.SCREEN_MODE.T1 Then
                tile.InkColor = Me.ForegroundColor
                tile.BackgroundColor = Me.BackgroundColor
            End If
            tile.Refresh()
        Next
    End Sub



    Public Sub ChangeMode(ByVal newMode As iVDP.SCREEN_MODE)

        Dim tile As TileMSX
        Dim i As Integer
        Dim ncolor As Integer
        Dim tileColor(7) As Byte

        If Me.tilesetMode = newMode Then
            Exit Sub
        End If

        If Not Me.Mode = iVDP.SCREEN_MODE.G2 And newMode = iVDP.SCREEN_MODE.G2 Then
            ' si cambia de T1 o G1 a G2
            For i = 0 To 255
                tile = Me.Tileset.Item(i)
                tile.Mode = newMode

                If Me.Mode = iVDP.SCREEN_MODE.G1 Then
                    tile.InkColor = CInt(Me.TilesetColorG1(Fix(i / 8)) And 240) / 16
                    tile.BackgroundColor = CInt(Me.TilesetColorG1(Fix(i / 8)) And 15)
                    For ncolor = 0 To 7
                        tileColor(ncolor) = (tile.InkColor * 16) + tile.BackgroundColor
                    Next
                Else
                    For ncolor = 0 To 7
                        tileColor(ncolor) = (Me._foregroundColor * 16) + Me._backgroundColor
                    Next
                End If
                tile.Color = tileColor.Clone
                tile.Refresh()
            Next
            'ElseIf Me.Mode = TMS9918.SCREEN_MODE.G2 And Not newMode = TMS9918.SCREEN_MODE.G2 Then
            '    ' si cambia de G2 --> T1 o G1
            '    For i = 0 To 255
            '        tile = Me.Tileset.Item(i)
            '        tile.Mode = newMode
            '        If Me.Mode = TMS9918.SCREEN_MODE.G1 Then
            '            tile.InkColor = CInt(Me.TilesetColorG1(Fix(i / 8)) And 240) / 16
            '            tile.BGcolor = CInt(Me.TilesetColorG1(Fix(i / 8)) And 15)
            '        Else
            '            tile.InkColor = Me.ForegroundColor
            '            tile.BGcolor = Me.BackgroundColor
            '        End If

            '        tile.Refresh()
            '    Next
        Else

            For i = 0 To 255
                tile = Me.Tileset.Item(i)
                tile.Mode = newMode

                tile.InkColor = Me.ForegroundColor
                tile.BackgroundColor = Me.BackgroundColor

                tile.Refresh()
            Next


            ' G2 to G1
            ' <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< programar una conversion de G2 a G1 <<<
            ' END G2 to G1
            If newMode = iVDP.SCREEN_MODE.G1 Then
                SetG1ColorsFromG2()
                'SetDefaultG1colors()
            End If

        End If

        Me.Mode = newMode

        'Me.Refresh()


    End Sub




    Private Sub SetG1ColorsFromG2()

        Dim InkColorRepeatsList As New SortedList()
        Dim BGColorRepeatsList As New SortedList()
        'Dim moreRepeatedInkColors() As Byte
        'Dim moreRepeatedBGColors() As Byte
        Dim aColor As Byte = 0
        Dim index As Integer
        Dim i As Integer
        Dim o As Integer
        Dim nLine As Integer

        Dim Inkcolor As Byte = 0
        Dim BGcolor As Byte = 0


        Dim tile As TileMSX

        ' cuenta colores
        For i = 0 To 31
            InkColorRepeatsList.Clear()
            BGColorRepeatsList.Clear()
            For o = 0 To 7
                tile = Me.Tileset.Item(index)
                index += 1

                For nLine = 0 To 7

                    If Not tile.Pattern(nLine) = 0 Then
                        Inkcolor = (tile.Color(nLine) And 240) / 16

                        If InkColorRepeatsList.ContainsKey(Inkcolor) Then
                            InkColorRepeatsList.Item(Inkcolor) += 1
                        Else
                            InkColorRepeatsList.Add(Inkcolor, 1)
                        End If
                    End If

                    BGcolor = tile.Color(nLine) And 15

                    If BGColorRepeatsList.ContainsKey(BGcolor) Then
                        BGColorRepeatsList.Item(BGcolor) += 1
                    Else
                        BGColorRepeatsList.Add(BGcolor, 1)
                    End If

                Next

            Next

            Inkcolor = colorSorter(InkColorRepeatsList)
            BGcolor = colorSorter(BGColorRepeatsList)

            Me.TilesetColorG1(i) = (Inkcolor * 16) + BGcolor
            
        Next

    End Sub



    Private Function colorSorter(ByVal list As SortedList) As Byte

        Dim value As Integer = 0
        Dim aColor As Byte

        For Each itemKey As Byte In list.Keys
            If list.Item(itemKey) > value Then
                value = list.Item(itemKey)
                aColor = itemKey
            End If
        Next

        Return aColor
    End Function


    'Private Sub setPalette(ByVal ID As Integer)
    '    Me._PaletteID = ID
    '    Me._Palette = Me._paletteProject.GetPalette(ID)
    'End Sub



    Public Sub SetTileG2(ByVal index As Integer, ByVal _Pattern As Byte(), ByVal _color As Byte())
        Dim tmpTile As New TileMSX(index, iVDP.SCREEN_MODE.G2, _Pattern, _color, Me._Palette, Me.ForegroundColor, Me.BackgroundColor)
        Me.Tileset.Item(index) = tmpTile
    End Sub



    Public Sub SetTileT1(ByVal index As Integer, ByVal _Pattern As Byte())
        Dim tmpTile As New TileMSX(index, iVDP.SCREEN_MODE.T1, _Pattern, Nothing, Me._Palette, Me.ForegroundColor, Me.BackgroundColor)
        Me.Tileset.Item(index) = tmpTile
    End Sub



    Public Sub SetTileG1(ByVal index As Integer, ByVal _Pattern As Byte(), ByVal _InkColor As Integer, ByVal _BGcolor As Integer)
        Dim tmpTile As New TileMSX(index, iVDP.SCREEN_MODE.G1, _Pattern, Nothing, Me._Palette, Me.ForegroundColor, Me.BackgroundColor)
        Me.Tileset.Item(index) = tmpTile
    End Sub



    Public Sub SetTile(ByVal index As Integer, ByVal tile As TileMSX)
        Me.Tileset.Item(index) = tile
    End Sub



    Public Function GetTile(ByVal index As Integer) As TileMSX
        Return Me.Tileset.Item(index)
    End Function



    Public Sub UpdateTile(ByVal _index As Integer, ByVal tile As TileMSX)
        Dim G1tileGroup As Integer = 0
        Dim tmpTile As TileMSX

        tile.Index = _index
        Me.Tileset.Item(_index) = tile

        If Me.Mode = iVDP.SCREEN_MODE.G1 Then
            ' Si corresponde a un tileset en formato G1 (screen1)
            ' actualiza los colores del grupo de tiles al que corresponda el tile
            G1tileGroup = Fix(_index / 8)
            TilesetColorG1(G1tileGroup) = (tile.InkColor * 16) + tile.BackgroundColor
            G1tileGroup *= 8
            For i As Integer = G1tileGroup To G1tileGroup + 7
                tmpTile = Me.Tileset.Item(i)
                tmpTile.InkColor = tile.InkColor
                tmpTile.BackgroundColor = tile.BackgroundColor
                tmpTile.Refresh()
            Next
        Else
            tile.Refresh()
        End If

    End Sub



    Public Function GetPatternData() As Byte()
        Return GetPatternData(0, 255)
    End Function



    Public Function GetPatternData(ByVal startTile As Integer, ByVal endTile As Integer) As Byte()
        Dim data As Byte()
        Dim tmpTile As TileMSX

        Dim destinationIndex As Integer = 0

        If startTile < 0 Then
            startTile = 0
        End If

        If startTile > endTile Then
            Return Nothing
        End If

        If endTile > 255 Then
            endTile = 255
        End If

        ReDim data((((endTile - startTile) + 1) * 8) - 1)

        For ID As Integer = startTile To endTile
            tmpTile = Me.Tileset.Item(ID)
            Array.Copy(tmpTile.Pattern, 0, data, destinationIndex, 8)
            destinationIndex += 8
        Next

        Return data
    End Function



    Public Function GetColorData() As Byte()
        Return GetColorData(0, 255)
    End Function



    Public Function GetG2ColorData() As Byte()
        Dim data(2047) As Byte
        Dim count As Integer = 0
        Dim i As Integer
        Dim tmpTile As TileMSX
        'Dim destinationIndex As Integer = 0

        Select Case Me.Mode

            Case iVDP.SCREEN_MODE.T1

                For i = 0 To 2047
                    data(i) = (Me._foregroundColor * 16) + Me._backgroundColor
                Next

            Case iVDP.SCREEN_MODE.G1

                For i = 0 To 31
                    For o As Integer = 0 To 63
                        data(count) = TilesetColorG1(i)
                        count += 1
                    Next
                Next


            Case Else

                For i = 0 To 255
                    tmpTile = Me.Tileset.Item(i)
                    Array.Copy(tmpTile.Color, 0, data, i * 8, 8)
                    'destinationIndex += 8
                Next


        End Select

        Return data
    End Function



    Public Function GetColorData(ByVal startTile As Integer, ByVal endTile As Integer) As Byte()

        Dim data As Byte()
        Dim tmpTile As TileMSX
        Dim dataSize As Integer
        Dim destinationIndex As Integer = 0

        If startTile < 0 Then
            startTile = 0
        End If

        If startTile > endTile Then
            Return Nothing
        End If

        If endTile > 255 Then
            endTile = 255
        End If

        Select Case Me.Mode

            Case iVDP.SCREEN_MODE.G1

                'startTile = CInt(startTile / 8)
                'endTile = CInt(endTile / 8)

                'dataSize = (endTile - startTile) - 1
                dataSize = 31
                ReDim data(dataSize)
                Array.Copy(TilesetColorG1, 0, data, 0, dataSize + 1)


            Case iVDP.SCREEN_MODE.G2

                dataSize = (((endTile - startTile) + 1) * 8) - 1

                ReDim data(dataSize)

                For ID As Integer = startTile To endTile
                    tmpTile = Me.Tileset.Item(ID)
                    Array.Copy(tmpTile.Color, 0, data, destinationIndex, 8)
                    destinationIndex += 8
                Next

            Case Else


        End Select


        Return data

    End Function



    Public Function GetStringMode() As String
        Dim output As String
        Select Case Me.Mode
            Case iVDP.SCREEN_MODE.G1
                output = "G1"
            Case iVDP.SCREEN_MODE.G2
                output = "G2"
            Case Else
                output = "T1"
        End Select
        Return output
    End Function


End Class
