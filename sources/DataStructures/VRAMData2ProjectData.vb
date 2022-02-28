Public Class VRAMData2ProjectData



    Private Const VRAMaddr_PALETTE = &H1B80   '&H1B80 VRAM adress for palette for screen2 (Only used by MSX Basic)


    Private ForegroundColor As Byte = 15
    Private BackgroundColor As Byte = 4



    Private VRAM As Byte() ' 16k = 16383 Bytes


    Public Sub New(vramData As Byte())
        Me.VRAM = vramData
    End Sub





    ''' <summary>
    ''' Create a Project (Tilesets, Map, Sprites, V9938 Palette and Screen), from VRAM data
    ''' </summary>
    ''' <param name="prjname"></param>
    ''' <param name="screenMode"></param>
    ''' <param name="spriteSize"></param>
    ''' <param name="spriteMode"></param>
    ''' <param name="InkColor"></param>
    ''' <param name="BGColor"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetProjectFromVRAM(prjname As String, screenMode As iVDP.SCREEN_MODE, spriteSize As SpriteMSX.SPRITE_SIZE, spriteMode As SpriteMSX.SPRITE_MODE, InkColor As Byte, BGColor As Byte) As tMSgfXProject


        Dim tmpProject As New tMSgfXProject

        Dim aNewScreen As ScreenMSX

        'Dim colorData As Byte()
        'Dim tmpPaletteID As Integer

        Dim map0 As MapMSX
        Dim mapID As Integer

        Dim tempOAM As OAMset
        Dim oamData As Byte()
        Dim oamID As Integer = 0

        Dim tempSpriteset As SpritesetMSX
        Dim patternData As Byte()
        Dim spritesetID As Integer = 0

        Dim palette As iPaletteMSX
        Dim paletteData As Byte()

        Dim checkData As Integer = 0

        Me.ForegroundColor = InkColor
        Me.BackgroundColor = BGColor


        ' Palette -------------------------------------------------------------------------------------
        paletteData = GetPaletteDataFromVRAM()

        If paletteData Is Nothing Then
            'tmpPaletteID = 0
            palette = tmpProject.Palettes.GetPalette(0)
            'vramPalette.SetDefault()
        Else
            'Me.TMS9918viewer.PaletteType = TMS9918.MSXVDP.V9938
            palette = New PaletteV9938
            palette.SetData(paletteData)
            palette.Name = prjname + "_PAL"

            tmpProject.Palettes.Add(palette) 'tmpPaletteID = 

            'Me.TMS9918viewer.Palette = tmpProject.Palettes.GetPaletteByID(tmpPaletteID)
        End If
        ' ------------------------------------------------------------------------------------- END palette

        tmpProject.Tilesets = New TilesetProject(tmpProject.Palettes)
        tmpProject.Maps = New MapProject

        Select Case screenMode

            Case iVDP.SCREEN_MODE.T1
                'tileset
                Dim tileset As New TilesetMSX(palette, prjname + "_TSET", iVDP.SCREEN_MODE.T1, GetBlock(iVDP.TableBase.TXTCGP, iVDP.TableBaseSize.TXTCGP), Nothing, ForegroundColor, BackgroundColor)
                tmpProject.Tilesets.Add(tileset)

                'map/screen
                map0 = New MapMSX(prjname + "_MAP", iVDP.SCREEN_MODE.T1, GetBlock(iVDP.TableBase.TXTNAM, iVDP.TableBaseSize.TXTNAM))
                mapID = tmpProject.Maps.Add(map0)


            Case iVDP.SCREEN_MODE.G1
                'tileset
                Dim tileset As New TilesetMSX(palette, prjname + "_TSET", iVDP.SCREEN_MODE.G1, GetBlock(iVDP.TableBase.T32CGP, iVDP.TableBaseSize.T32CGP), GetBlock(iVDP.TableBase.T32COL, iVDP.TableBaseSize.T32COL), ForegroundColor, BackgroundColor)
                mapID = tmpProject.Tilesets.Add(tileset)

                'map/screen
                map0 = New MapMSX(prjname + "_MAP", iVDP.SCREEN_MODE.G1, GetBlock(iVDP.TableBase.T32NAM, iVDP.TableBaseSize.T32NAM))
                tmpProject.Maps.Add(map0)

            Case Else 'iVDP.SCREEN_MODE.G2
                'tileset
                Dim tileset0 As New TilesetMSX(palette, prjname + "_BANK0", iVDP.SCREEN_MODE.G2, GetBlock(iVDP.TableBase.GRPCGP, &H800), GetBlock(iVDP.TableBase.GRPCOL, &H800), ForegroundColor, BackgroundColor)
                Dim tileset1 As New TilesetMSX(palette, prjname + "_BANK1", iVDP.SCREEN_MODE.G2, GetBlock(iVDP.TableBase.GRPCGP + &H800, &H800), GetBlock(iVDP.TableBase.GRPCOL + &H800, &H800), ForegroundColor, BackgroundColor)
                Dim tileset2 As New TilesetMSX(palette, prjname + "_BANK2", iVDP.SCREEN_MODE.G2, GetBlock(iVDP.TableBase.GRPCGP + &H1000, &H800), GetBlock(iVDP.TableBase.GRPCOL + &H1000, &H800), ForegroundColor, BackgroundColor)
                tmpProject.Tilesets.Add(tileset0)
                tmpProject.Tilesets.Add(tileset1)
                tmpProject.Tilesets.Add(tileset2)

                'map/screen
                map0 = New MapMSX(prjname + "_MAP", iVDP.SCREEN_MODE.G2, GetBlock(iVDP.TableBase.GRPNAM, iVDP.TableBaseSize.GRPNAM))
                map0.Tileset = tileset0.ID
                map0.TilesetB = tileset1.ID
                map0.TilesetC = tileset2.ID
                mapID = tmpProject.Maps.Add(map0)

        End Select



        If Not screenMode = iVDP.SCREEN_MODE.T1 Then
            'SPRITES

            'patterns
            patternData = GetBlock(iVDP.TableBase.GRPPAT, iVDP.TableBaseSize.GRPPAT)
            For i = 0 To 2047
                checkData += patternData(i)
            Next

            If checkData > 0 And checkData < 521985 Then  '2047*255
                tmpProject.SpriteSets = New SpriteProject(tmpProject.Palettes)
                tmpProject.OAMs = New OAMProject

                'if it does not detect content, Sprites and OAM sets are not created
                tempSpriteset = New SpritesetMSX(prjname + "_SPRSET", spriteSize, spriteMode, 15, 0, palette, patternData, Nothing)
                spritesetID = tmpProject.SpriteSets.Add(tempSpriteset)

                'OAM----
                ' G1 & G2 --> VRAM addr = &H1B00
                ' en el modo G3 (screen4) la OAM se encuentra en la dirección &h1E00
                oamData = GetBlock(iVDP.TableBase.GRPATR, iVDP.TableBaseSize.GRPATR)
                tempOAM = New OAMset(prjname + "_OAMSET", spriteSize, spriteMode, oamData, Nothing)
                oamID = tmpProject.OAMs.Add(tempOAM)
                'end OAM
            End If

        End If






        'SCREEN
        tmpProject.Screens = New ScreenProject
        aNewScreen = New ScreenMSX(prjname, screenMode, spriteSize, mapID, map0.Tileset, map0.TilesetB, map0.TilesetC, spritesetID, oamID, palette.ID)
        tmpProject.Screens.Add(aNewScreen)
        'END SCREEN

        'RefreshScreenSelector()
        'Me.ScreensComboBox.SelectedIndex = Me._screensProject.GetIndexFromID(aNewScreen.ID)


        'ShowScreenData()

        Return tmpProject

    End Function



    Private Function GetBlock(ByVal vaddr As Integer, ByVal size As Integer) As Byte()
        Dim tmpBloq(size) As Byte
        Array.Copy(Me.VRAM, vaddr, tmpBloq, 0, size)
        Return tmpBloq
    End Function



    Private Function GetPaletteDataFromVRAM() As Byte()
        Dim data As Byte()
        Dim vaddr As Short = VRAMaddr_PALETTE

        Dim checksum As Integer = 0

        ReDim data(31)

        For i As Integer = 0 To 31
            data(i) = Me.VRAM(vaddr)
            checksum += data(i)
            vaddr += 1
        Next

        If checksum > 0 And checksum < 4000 Then ' solo si hay una paleta. Si todos fueran color blanco el maximo valor seria 2016
            ' si hay ruido puede ser interpretado como una paleta
            ' lo normal en el caso de un sc2 sin paleta, sera que todos los valores sean 0 o FF

            Return data

        Else

            Return Nothing

        End If

    End Function


  
End Class
