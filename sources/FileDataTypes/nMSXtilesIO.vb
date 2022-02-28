Imports System.IO


''' <summary>
''' Clase para leer ficheros de datos de la aplicacion nMSXtiles de Pentacour.
''' </summary>
''' <remarks></remarks>
Public Class nMSXtilesIO

    'Private Palette As PaletteV9938


    Private bite_MASKs = New Byte() {1, 2, 4, 8, 16, 32, 64, 128}

    Public ProjectData As nMSXtilesProject


    'Public OneBank As Boolean = False

    Public BankA_ID As Integer
    Public BankB_ID As Integer
    Public BankC_ID As Integer


    ' Pentacour's nMSXtiles devtool - file extensions
    Public Shadows Const PROJECT_EXT As String = "PRJ"
    Public Shadows Const TILESET_EXT As String = "TIL"
    Public Shadows Const SCREEN_EXT As String = "SCR"
    Public Shadows Const PALETTE_EXT As String = "PAL"



    Public Sub New() 'ByVal _palette As PaletteV9938
        Me.ProjectData = New nMSXtilesProject
    End Sub



    Public Property OneBank As Boolean
        Get
            Return Me.ProjectData.OneBank
        End Get
        Set(value As Boolean)
            Me.ProjectData.OneBank = value
        End Set
    End Property



    Private Function LoadTextFile(ByVal filePath As String) As ArrayList
        Dim objReader As StreamReader
        Dim dataText As ArrayList
        Dim sLine As String

        Try
            If File.Exists(filePath) Then

                dataText = New ArrayList()
                objReader = New StreamReader(filePath)

                Do
                    sLine = objReader.ReadLine()
                    If Not sLine Is Nothing Then
                        dataText.Add(sLine)
                    End If
                Loop Until sLine Is Nothing
                objReader.Close()

                Return dataText

            End If

        Catch ex As Exception

        End Try

        Return Nothing

    End Function






    ''' <summary>
    ''' Load a nMSXtiles Project
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <remarks></remarks>
    Public Function LoadProject(ByVal filePath As String) As nMSXtilesProject

        Dim tilesets As ArrayList
        Dim maps As ArrayList

        Dim result As Boolean = True



        If InitProject(filePath) = True Then

            maps = LoadMaps(Me.ProjectData.path_SCREEN)
            If maps Is Nothing Then
                result = False
            Else
                Me.ProjectData.Screens = maps
            End If



            tilesets = LoadTileSets(Me.ProjectData.path_TILES)
            If tilesets Is Nothing Then
                result = False
            Else
                Me.ProjectData.Tilesets = tilesets
            End If


        Else
            result = False
            'MsgBox("The selected file is not of nMSXtiles Project type", MsgBoxStyle.Critical, "Error")
        End If



        If result Then
            Return Me.ProjectData
        Else
            Return Nothing
        End If


    End Function




    'nMSXtiles project file:

    'PROJECT
    'SCREEN
    'filename.scr
    'TILES
    'filename.til
    'ALLBANKS/ONEBANK
    'PALETTE
    'filename.pal
    'END

    Public Function InitProject(ByVal filePath As String) As Boolean

        'Dim tilesets As ArrayList
        'Dim maps As ArrayList

        Dim result As Boolean = True

        Dim TilesPath As String = ""
        Dim screenPath As String = ""
        Dim palettePath As String = ""
        Dim projectPath As String

        Dim tmpText As String

        Dim dataText As ArrayList


        Try

            dataText = LoadTextFile(filePath)

            If dataText.Item(0).Equals("PROJECT") Then

                Me.ProjectData.Name = Path.GetFileNameWithoutExtension(filePath)
                Me.ProjectData.path_PROJECT = filePath


                projectPath = Path.GetDirectoryName(filePath) + Path.DirectorySeparatorChar


                ' ------------------------------- SCREEN
                ' MAPs
                screenPath = dataText.Item(2)
                If Not File.Exists(screenPath) Then
                    screenPath = projectPath + screenPath
                End If
                Me.ProjectData.path_SCREEN = screenPath
                '----------------------------------------



                ' ------------------------------- TILES
                ' Load TILESETs
                If dataText.Count > 4 Then
                    tmpText = dataText.Item(5)
                    If tmpText.ToUpper = "ONEBANK" Then
                        Me.ProjectData.OneBank = True
                    Else
                        Me.ProjectData.OneBank = False
                    End If
                Else
                    Me.ProjectData.OneBank = False
                End If


                TilesPath = dataText.Item(4)
                If Not File.Exists(TilesPath) Then
                    TilesPath = projectPath + TilesPath
                End If
                Me.ProjectData.path_TILES = TilesPath
                '----------------------------------------



                ' ------------------------------- PALETTE
                ' filename.pal
                If dataText.Count > 5 Then
                    palettePath = dataText.Item(6)
                    If Not File.Exists(palettePath) Then
                        palettePath = projectPath + palettePath
                    End If
                    Me.ProjectData.path_PALETTE = palettePath
                End If



            Else
                result = False
            End If


        Catch ex As Exception
            result = False
        End Try


        Return result

    End Function




    'SCREEN-0-0
    '0
    '0
    'n
    'SCREEN-1-0
    '
    'SCREEN-2-0
    '
    'SCREEN-0-1
    '
    'SCREEN-1-1
    '
    'SCREEN-2-1
    '
    'MAP WIDTH-HEIGHT
    '3
    '2


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LoadMaps(ByVal filePath As String) As ArrayList

        Dim mapData(768) As Byte
        'ReDim mapData(768) 'dataText.Count)

        Dim tmpMap As MapMSX

        Dim contador As Integer = 0

        Dim maps As New ArrayList

        Dim dataText As New ArrayList()
        'Dim sLine As String = ""
        Dim mapName As String

        'Dim objReader As StreamReader

        Try

            If Not File.Exists(filePath) Then

                'MsgBox("Not found the screen file : " + filePath, MsgBoxStyle.Critical, "")
                Return Nothing

            End If

            'objReader = New StreamReader(filePath)
            'Do
            '    sLine = objReader.ReadLine()
            '    If Not sLine Is Nothing Then
            '        dataText.Add(sLine)
            '    End If
            'Loop Until sLine Is Nothing
            'objReader.Close()

            dataText = LoadTextFile(filePath)

            Dim totalLines As Integer = dataText.Count
            Dim totalScreens As Integer = totalLines / 768


            For nmap As Integer = 0 To totalScreens - 1

                mapName = dataText.Item(contador).ToString

                If mapName.Contains("SCREEN") Then

                    If totalScreens = 1 Then
                        ' if only contains one screen, use the file name
                        mapName = Path.GetFileNameWithoutExtension(filePath)
                    End If


                    contador += 1
                    For i = 0 To 767
                        mapData(i) = CByte(dataText.Item(contador))
                        contador += 1
                    Next


                    If Me.OneBank = True Then

                        tmpMap = New MapMSX(mapName, MapMSX.MAP_TYPE.Custom, mapData)
                        tmpMap.Tileset = Me.BankA_ID   'Me.aProject.Tilesets(0).ID

                    Else

                        tmpMap = New MapMSX(mapName, Me.BankA_ID, Me.BankB_ID, Me.BankC_ID, mapData)
                        'tmpMap = New MapMSX(mapName, Me.aProject.Tilesets(0).ID, Me.aProject.Tilesets(1).ID, Me.aProject.Tilesets(2).ID, mapData)

                    End If

                    maps.Add(tmpMap)
                Else
                    contador += 768
                End If

            Next


        Catch ex As Exception
            Return Nothing
        End Try

        Return maps

    End Function




    Public Function LoadTileSets(ByVal filePath As String) As ArrayList

        'Try

        Dim tilesets As New ArrayList 'TilesetProject(Me.Palette)
        'Dim outputTileset As TilesetMSX

        Dim i As Integer = 0
        Dim o As Integer = 0
        'Dim bank As Integer
        'Dim line As Integer
        'Dim column As Integer

        Dim conta As Integer = 0

        Dim totalLines As Integer
        Dim totalTilesets As Integer

        Dim lowVal As Byte
        Dim higVal As Byte

        Dim aByteString As String

        Dim tilesetName As String

        'Dim _name As String = Path.GetFileNameWithoutExtension(filePath)

        Dim patternData(2047) As Byte
        Dim colorData(2047) As Byte

        Dim patternPos As Integer = 0
        Dim colorPos As Integer = 0

        Dim palettes As New PaletteProject()

        Dim aName As String = Path.GetFileNameWithoutExtension(filePath)



        If Not File.Exists(filePath) Then

            'MsgBox("Not found the tileset file: " + filePath, MsgBoxStyle.Critical, "") 'AcceptButton
            Return Nothing

        End If

        'Me.Path_Tileset = filePath

        'Dim objReader As New StreamReader(filePath)
        Dim dataText As ArrayList
        'Dim sLine As String

        'Do
        '    sLine = objReader.ReadLine()
        '    If Not sLine Is Nothing Then
        '        dataText.Add(sLine)
        '    End If
        'Loop Until sLine Is Nothing
        'objReader.Close()

        dataText = LoadTextFile(filePath)

        If Not dataText.Item(0).Equals("TILES") Then
            Return Nothing
        Else

            totalLines = dataText.Count
            totalTilesets = totalLines / (256 * 80) '16 values for colors + 8*8 values for pattern

            conta = 1
            'For bank = 0 To 2
            For numTileset As Integer = 0 To totalTilesets - 1

                'conta = dataText.IndexOf("BANK" + CStr(bank))
                tilesetName = dataText.Item(conta).ToString
                If tilesetName.Contains("BANK") Then
                    'If dataText.Item(conta).Equals("BANK" + CStr(bank)) Then
                    conta += 1

                    colorPos = 0
                    patternPos = 0

                    For tile = 0 To 255 '7
                        'For column = 0 To 31
                        'colors
                        For i = 0 To 7
                            'the two values of colors are separated in two bytes
                            lowVal = CByte(dataText.Item(conta))
                            higVal = CByte(dataText.Item(conta + 8))
                            conta += 1
                            colorData(colorPos) = (higVal * 16) + lowVal
                            'TMS9918viewer.VPOKE(colorBase, (higVal * 16) + lowVal)
                            colorPos += 1
                        Next
                        conta += 8

                        'pattern data
                        For i = 0 To 7
                            aByteString = ""
                            For o = 0 To 7
                                aByteString += dataText.Item(conta)
                                conta += 1
                            Next
                            'TMS9918viewer.VPOKE(gfxBase, CByte(Convert.ToInt32(aByteString, 2)))
                            patternData(patternPos) = CByte(Convert.ToInt32(aByteString, 2))
                            patternPos += 1
                        Next

                        'Next
                    Next

                    tilesets.Add(New TilesetMSX(palettes.GetPalette(0), aName + "_" + tilesetName, iVDP.SCREEN_MODE.G2, patternData, colorData, 15, 4))

                Else

                    conta += (256 * 24)

                End If

                If tilesets.Count = 3 Then
                    Me.BankA_ID = tilesets.Item(0).ID
                    Me.BankB_ID = tilesets.Item(1).ID
                    Me.BankC_ID = tilesets.Item(2).ID
                Else
                    Me.BankA_ID = tilesets.Item(0).ID
                End If

            Next


        End If


        Return tilesets

        'Catch ex As Exception
        '    Return Nothing
        'End Try

    End Function







    'nMSXtiles project file:

    'PROJECT
    'SCREEN
    'filename.scr
    'TILES
    'filename.til
    'ALLBANKS or ONEBANK
    'PALETTE
    'filename.pal
    'END


    'WriteLine write as carriage return with two chars CR+LF. it works in nMSXtiles but the file increases its size noticeably

    Public Sub SaveProject(ByVal filePath As String, ByVal project As tMSgfXProject) '_mapsProject As MapProject, ByVal _tilesetProject As TilesetProject)

        Try

            Dim firstMap As MapMSX
            Dim _tsets As New ArrayList

            Dim aTmpPath As String = Path.GetDirectoryName(filePath) + Path.DirectorySeparatorChar

            Dim mapFileName As String
            Dim tilesetFileName As String

            mapFileName = project.Info.Name
            'If mapFileName = "" Then
            '    mapFileName = Path.GetFileNameWithoutExtension(filePath)
            'End If
            mapFileName = mapFileName + "." + SCREEN_EXT

            tilesetFileName = project.Info.Name
            'If tilesetFileName = "" Then
            '    tilesetFileName = Path.GetFileNameWithoutExtension(filePath)
            'End If
            tilesetFileName = tilesetFileName + "." + TILESET_EXT

            firstMap = project.Maps.Maps.Item(0)

            Dim objWriter As New StreamWriter(filePath, False, System.Text.Encoding.ASCII)

            objWriter.Write("PROJECT")
            objWriter.Write(vbLf)
            objWriter.Write("SCREEN")
            objWriter.Write(vbLf)
            objWriter.Write(mapFileName)
            objWriter.Write(vbLf)
            objWriter.Write("TILES")
            objWriter.Write(vbLf)
            objWriter.Write(tilesetFileName)
            objWriter.Write(vbLf)
            If firstMap.MapType = MapMSX.MAP_TYPE.ScreenG2 Then
                objWriter.Write("ALLBANKS")
                objWriter.Write(vbLf)
            Else
                objWriter.Write("ONEBANK")
                objWriter.Write(vbLf)
            End If
            'objWriter.Write("PALETTE")
            'objWriter.Write(vbLf)
            'filename.pal
            'objWriter.Write(vbLf)
            objWriter.Write("END")
            objWriter.Write(vbLf)

            'objWriter.WriteLine("PROJECT")
            'objWriter.WriteLine("SCREEN")
            'objWriter.WriteLine(mapFileName)
            'objWriter.WriteLine("TILES")
            'objWriter.WriteLine(tilesetFileName)
            'If firstMap.MapType = MapMSX.MAP_TYPE.ScreenG2 Then
            '    objWriter.WriteLine("ALLBANKS")
            'Else
            '    objWriter.WriteLine("ONEBANK")
            'End If
            ''objWriter.WriteLine("PALETTE")
            ''filename.pal
            'objWriter.WriteLine("END")

            objWriter.Close()

            'save a screen map file
            SaveMap(aTmpPath + mapFileName, project.Maps.Maps)

            'save a tileset file
            '
            _tsets.Add(project.Tilesets.GetTilesetByID(firstMap.Tileset))
            If firstMap.MapType = MapMSX.MAP_TYPE.ScreenG2 Then
                _tsets.Add(project.Tilesets.GetTilesetByID(firstMap.TilesetB))
                _tsets.Add(project.Tilesets.GetTilesetByID(firstMap.TilesetC))
            End If
            SaveTileset(aTmpPath + tilesetFileName, _tsets)

        Catch ex As Exception
            MsgBox("Disk I/O error.", MsgBoxStyle.Critical, "Error")
        End Try

    End Sub



    Public Sub SaveMap(ByVal filePath As String, ByVal maps As ArrayList)

        Dim lineData() As Byte
        Dim data As SortedList
        Dim numscr As Integer = 0

        Dim objWriter As New StreamWriter(filePath, False, System.Text.Encoding.ASCII)

        Try

            For Each aMap As MapMSX In maps

                objWriter.Write("SCREEN-" + CStr(numscr) + "-0")
                objWriter.Write(vbLf)
                'objWriter.WriteLine("SCREEN-" + CStr(numscr) + "-0")
                numscr += 1

                data = aMap.Lines

                For i = 0 To 23
                    If i < aMap.Height Then
                        lineData = data.Item(i)
                        For o = 0 To 31
                            If o < aMap.Width Then
                                objWriter.Write(lineData(o))
                                objWriter.Write(vbLf)
                                'objWriter.WriteLine(lineData(o))
                            Else
                                'complete the line up to 32 tiles
                                objWriter.Write("0")
                                objWriter.Write(vbLf)
                                'objWriter.WriteLine("0")
                            End If
                        Next
                    Else
                        'if the map has less than 24 lines, create lines with tile 0
                        For o = 0 To 31
                            objWriter.Write("0")
                            objWriter.Write(vbLf)
                            'objWriter.WriteLine("0")
                        Next
                    End If
                    
                Next

            Next


            objWriter.Write("MAP WIDTH-HEIGHT")
            objWriter.Write(vbLf)
            objWriter.Write(CStr(maps.Count))
            objWriter.Write(vbLf)
            objWriter.Write("1")
            objWriter.Write(vbLf)
            'objWriter.WriteLine("MAP WIDTH-HEIGHT")
            'objWriter.WriteLine(CStr(maps.Count))
            'objWriter.WriteLine("1")
           

            objWriter.Close()

        Catch ex As Exception
            objWriter.Close()
        End Try

    End Sub





    'TILES
    'BANK0
    'Ink Color Line 0
    'Ink Color Line 1
    'Ink Color Line 2
    'Ink Color Line 3
    'Ink Color Line 4
    'Ink Color Line 5
    'Ink Color Line 6
    'Ink Color Line 7
    'BackGround Color Line 0
    'BackGround Color Line 1
    'BackGround Color Line 2
    'BackGround Color Line 3
    'BackGround Color Line 4
    'BackGround Color Line 5
    'BackGround Color Line 6
    'BackGround Color Line 7
    'Pattern Line 0, Bit 0
    'Pattern Line 0, Bit 1
    '...
    'Pattern Line 0, Bit 7
    'Pattern Line 1, Bit 0
    'Pattern Line 1, Bit 1
    '...
    'Pattern Line 1, Bit 7
    ' bis to Line 7


    Public Sub SaveTileset(ByVal filePath As String, ByVal tsets As ArrayList)

        Dim colorVal As UInteger

        Dim calPosition As Integer

        Dim colorData() As Byte
        Dim patternData() As Byte

        Dim patternValue As Byte

        Dim tmpTileset As TilesetMSX

        Dim objWriter As New StreamWriter(filePath, False, System.Text.Encoding.ASCII)

        Try

            objWriter.Write("TILES")
            objWriter.Write(vbLf)
            'objWriter.WriteLine("TILES")

            If tsets.Count > 3 Then
                Return
            End If

            For i = 0 To tsets.Count - 1
                objWriter.Write("BANK" + CStr(i))
                objWriter.Write(vbLf)
                'objWriter.WriteLine("BANK" + CStr(i))

                tmpTileset = tsets.Item(i)

                colorData = tmpTileset.GetColorData()
                patternData = tmpTileset.GetPatternData()

                For tileNumb As Integer = 0 To 255
                    calPosition = tileNumb * 8
                    For colorLine = 0 To 7
                        'the two values of colors are separated in two bytes
                        colorVal = colorData(calPosition + colorLine) And 15
                        objWriter.Write(CStr(colorVal))
                        objWriter.Write(vbLf)
                        'objWriter.WriteLine(CStr(colorVal))
                    Next
                    For colorLine = 0 To 7
                        'the two values of colors are separated in two bytes
                        colorVal = (colorData(calPosition + colorLine) And 240) / 16
                        objWriter.Write(CStr(colorVal))
                        objWriter.Write(vbLf)
                        'objWriter.WriteLine(CStr(colorVal))
                    Next
                    For patternLine = 0 To 7
                        patternValue = patternData(calPosition + patternLine)
                        For o As Integer = 7 To 0 Step -1
                            If (patternValue And Me.bite_MASKs(o)) = Me.bite_MASKs(o) Then
                                '1
                                objWriter.Write("1")
                                objWriter.Write(vbLf)
                                'objWriter.WriteLine("1")
                            Else
                                '0
                                objWriter.Write("0")
                                objWriter.Write(vbLf)
                                'objWriter.WriteLine("0")
                            End If
                        Next

                    Next

                Next

            Next

            objWriter.Close()

        Catch ex As Exception
            objWriter.Close()
        End Try

    End Sub



    
End Class
