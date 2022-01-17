Imports System.IO


''' <summary>
''' 
''' </summary>
''' <remarks></remarks>
Public Class TMS9918


    Public Event MouseScreenData(ByVal x As Integer, ByVal y As Integer, ByVal nTile As Integer)

    Public Event MouseSelectedPos(ByVal startx As Integer, ByVal starty As Integer, ByVal endx As Integer, ByVal endy As Integer)


    ' conversion SC2
    Public Class ColorItem
        Public Sub New(ByVal aColor As Byte, ByVal aCount As Byte)
            Me.Color = aColor
            Me.Count = aCount
        End Sub
        Public Color As Byte
        Public Count As Byte
    End Class


    Public Class ColorByte
        Private ForeGroundColor As Byte
        Private BackGroundColor As Byte


        Public Property ForeGround()
            Get
                Return Me.ForeGroundColor
            End Get
            Set(ByVal value)
                Me.ForeGroundColor = value And 15
            End Set
        End Property


        Public Property BackGround()
            Get
                Return Me.BackGroundColor
            End Get
            Set(ByVal value)
                Me.BackGroundColor = value And 15
            End Set
        End Property


        Public Function GetFGBG() As Byte
            Dim aByteColor As Byte
            aByteColor = (Me.ForeGroundColor * 16) + Me.BackGroundColor
            Return aByteColor
        End Function

    End Class

    Private pixelscreen(256, 192) As Byte
    Private Bit() As Byte = {128, 64, 32, 16, 8, 4, 2, 1}
    ' END conversion SC2



    Private _VDPtype As MSXpalette.MSXVDP


    Public _msxPalette As New MSXpalette


    Private VRAM(16383) As Byte ' 16k de memoria de video
    Private screenBitmap As Bitmap
    Private tilesBitmap As Bitmap
    'Private tilesScreenBitmap As System.Drawing.Bitmap

    Private Tile_Bank0(255) As Bitmap ' An array containing the individual Puzzle Tiles
    Private Tile_Bank1(255) As Bitmap
    Private Tile_Bank2(255) As Bitmap

    Public PaletteType As Byte = 0 'default palette

    Private isDrag As Boolean = False
    Private theRectangle As New Rectangle(New Point(0, 0), New Size(0, 0))
    Private startPoint As Point
    Private sposex As Integer
    Private sposey As Integer
    Private endposex As Integer
    Private endposey As Integer


    Private _VisibleTileSets As Boolean = True

    ' tabla de nombre de patrones, base(10) = 6144 (32x24=768B)
    ' tabla de colores, base(11) = 8192(6144B)
    ' tabla generadora de patrones, base(12) = 0 (6144B)



    Public Shadows Enum TableBase As Integer
        ' screen 0
        TXTNAM = 0     ' 0
        TXTCGP = 2048  ' 2

        ' screen 1
        T32NAM = 6144  ' 5
        T32COL = 8192  ' 6
        T32CGP = 0     ' 7
        T32ATR = 6912  ' 8
        T32PAT = 14336 ' 9

        ' screen 2
        GRPNAM = 6144  ' 10 Name_Table_Base_Address
        GRPCOL = 8192  ' 11 Color_Table_Base_Address
        GRPCGP = 0     ' 12 Pattern_Generator_Base_Address
        GRPATR = 6912  ' 13 Sprite_Attribute_Table_Base_Address
        GRPPAT = 14336 ' 14 Sprite_Pattern_Generator_Base_Address

        ' screen 3
        MLTNAM = 2048  ' 15
        MLTCGP = 0     ' 17
        MLTATR = 6912  ' 18
        MLTPAT = 14336 ' 19

    End Enum


    Public Shadows Enum NumberOfBase As Byte
        Name_Table_Base_Address = 10
        Color_Table_Base_Address = 11
        Pattern_Generator_Base_Address = 12
        Sprite_Attribute_Table_Base_Address = 13
        Sprite_Pattern_Generator_Base_Address = 14
    End Enum


    Public Shadows Enum MSX_Palette As Byte
        Transparent = 0
        Black = 1
        Medium_Green = 2
        Light_Green = 3
        Dark_Blue = 4
        Light_Blue = 5
        Dark_Red = 6
        Cyan = 7
        Medium_Red = 8
        Light_Red = 9
        Dark_Yellow = 10
        Light_Yellow = 11
        Dark_Green = 12
        Magenta = 13
        Gray = 14
        White = 15
    End Enum


    Public Property VDPtype() As MSXpalette.MSXVDP
        Get
            Return _VDPtype
        End Get
        Set(ByVal value As MSXpalette.MSXVDP)
            Me._VDPtype = value
            _msxPalette.VDPtype = value
        End Set
    End Property



    Public Property VisibleTileSets() As Boolean
        ' la parte Get es la que devuelve el valor de la propiedad
        Get
            Return Me._VisibleTileSets
        End Get
        ' la parte Set es la que se usa al asignar el nuevo valor
        Set(ByVal state As Boolean)
            Me._VisibleTileSets = state
            If state Then
                Me.tilesScreen.Visible = False
            Else
                Me.tilesScreen.Visible = True
            End If
        End Set
    End Property




    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me.screenBitmap = New Bitmap(256, 192)
        Me.ScreenPictureBox.Image = Me.screenBitmap

        Me.tilesBitmap = New Bitmap(256, 192)
        Me.tilesScreen.Image = Me.tilesBitmap

        _msxPalette.setDefault()

        SetTileSets()

    End Sub

    'Public Enum Palette_Name As Byte
    '    blueMSX = 0
    '    Jannone_ScreenConversor = 1
    'End Enum


    'SCREEN 2 - 256*192 Graphics mode
    '0000-17FF   Charcter patterns
    '1800-1AFF   Name table (tiles map)
    '1B00-1B7F   Sprite attribute table
    '2000-37FF   PixelByte colour table
    '3800-3FFF   Sprite character patterns

    'SCREEN 4 (256*192 Graphics mode with multicolour sprites):
    '0000-17FF   Character patterns
    '1800-1AFF   Name table (tiles map)
    '1C00-1DFF   Sprite colours
    '1E00-1E7F   Sprite attribute table
    '1E80-1E9F   Palette
    '2000-37FF   PixelByte colour table
    '3800-3FFF   Sprite character patterns


    Public Function BASE(ByVal value As NumberOfBase) As Short
        Dim result As Integer = 0
        Select Case value

            ' screen 2
            Case 10 ' tabla de nombre de patrones / Name Table Base Address
                result = 6144
            Case 11 ' tabla de colores / Color Table Base Address
                result = 8192
            Case 12 ' tabla generadora de patrones / pattern generator Base Address
                result = 0
            Case 13 ' tabla atributos de figuras móviles / sprite attribute table Base Address
                result = &H1B00
            Case 14 ' Tabla de patrones de figura móvil / sprite pattern generator Base Address
                result = &H3800


                ' screen 4
            Case 20 ' tabla de nombre de patrones / Name Table Base Address
                result = 6144
            Case 21 ' tabla de colores / Color Table Base Address
                result = 8192
            Case 22 ' tabla generadora de patrones / pattern generator Base Address
                result = 0
            Case 23 ' tabla atributos de figuras móviles / sprite attribute table Base Address
                result = &H1E00
            Case 24 ' Tabla de patrones de figura móvil / sprite pattern generator Base Address
                result = &H3800


                '#define BASE40 0x1800 // base 10 name table (6144)
                '#define BASE41 0x2000 // base 11 color table (8192)
                '#define BASE42 0x0000 // base 12 character pattern table (0)
                '#define BASE43 0x1E00 // base 13 sprite attribute table (6912)
                '#define BASE44 0x3800 // base 14 sprite pattern table (14336)
                '#define BASE45 0x1C00 // base 14 sprite color

        End Select

        Return result

    End Function


    Public Sub SetDefaultPalette()
        Me._msxPalette.setDefault()
    End Sub



    Public Sub SetPalette(ByVal _PaletteData As MSXpalette)

        Dim paletteData() As Byte
        Dim vaddr As Integer = &H1B80  '1E80

        If Not _PaletteData Is Nothing Then

            Me._msxPalette = _PaletteData

            paletteData = Me._msxPalette.GetData()

            If Not Me.VDPtype = MSXpalette.MSXVDP.TMS9918 Then
                ' escribe los valores de la paleta (V9938) a la vram
                For Each value As Byte In paletteData
                    Me.VPOKE(vaddr, value)
                    vaddr += 1
                Next
            End If

        End If

    End Sub



    Public Function GetPalette() As MSXpalette

        Return _msxPalette

    End Function



    ''' <summary>
    ''' MSX2
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetVRAMPalette()
        Dim data As Byte()
        Dim vaddr As Short = &H1B80 'VRAM adress for palette (Only used by MSX Basic)

        Dim checksum As Integer = 0

        ReDim data(31)

        For i As Integer = 0 To 31
            data(i) = Me.VPEEK(vaddr)
            checksum += data(i)
            vaddr += 1
        Next

        If checksum > 0 And checksum < 1900 Then ' solo si hay una paleta. Si todos fueran color blanco el maximo valor seria 2016
            ' si hay ruido puede ser interpretado como una paleta
            ' lo normal en el caso de un sc2 sin paleta, sera que todos los valores sean 0 o FF
            Me._msxPalette.SetData(data)
            If Me._VDPtype = MSXpalette.MSXVDP.AUTO Then
                _msxPalette.VDPtype = MSXpalette.MSXVDP.V9938
            End If

        Else

            _msxPalette.setDefault()
            If Me._VDPtype = MSXpalette.MSXVDP.AUTO Then
                _msxPalette.VDPtype = MSXpalette.MSXVDP.TMS9918
            End If

        End If

    End Sub






    ''' <summary>
    ''' Writes a byte to the video RAM.
    ''' </summary>
    ''' <param name="VAdress"></param>
    ''' <param name="value"></param>
    ''' <remarks></remarks>
    Public Sub VPOKE(ByVal VAdress As Short, ByVal value As Byte)

        If VAdress < 16384 Then
            VRAM(VAdress) = value
        End If

    End Sub


    ''' <summary>
    ''' Write a block of data in the VRAM
    ''' </summary>
    ''' <param name="vaddr"></param>
    ''' <param name="block"></param>
    ''' <remarks></remarks>
    Public Sub VPOKE_block(ByVal vaddr As Integer, ByVal block() As Byte)
        For Each value As Byte In block
            VPOKE(vaddr, value)
            vaddr += 1
        Next
    End Sub


    ''' <summary>
    ''' Reads a byte from the video RAM.
    ''' </summary>
    ''' <param name="VAdress"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function VPEEK(ByVal VAdress As Short) As Byte

        If VAdress < 16384 Then
            'VAdress += 1
            Return VRAM(VAdress)
        Else
            Return 0
        End If

    End Function



    ''' <summary>
    ''' Fill a large area of the VRAM of the same byte.
    ''' </summary>
    ''' <param name="VRAMaddr"></param>
    ''' <param name="length"></param>
    ''' <param name="tile"></param>
    ''' <remarks></remarks>
    Public Sub FillVRAM(ByVal VRAMaddr As Integer, ByVal length As Integer, ByVal tile As Byte)
        For i = 0 To length
            VPOKE(VRAMaddr, tile)
            VRAMaddr += 1
        Next
    End Sub



    Public Sub CopyVRAM(ByVal source As Integer, ByVal target As Integer, ByVal length As Integer)
        For vaddr As Integer = source To source + length
            VPOKE(target, VPEEK(vaddr))
            target += 1
        Next
    End Sub



    Public Sub initialize()

        fillVRAM(0, 16383, 0)
        OrderMap()

    End Sub


    Public Sub clear()

        fillVRAM(0, 16383, 0)

    End Sub


    Public Sub RefreshScreen()
        Me.DrawTileSet()
        Me.SetTileSets()
        Me.ShowTilesMap()
        Me.Refresh()
    End Sub



    ''' <summary>
    ''' draw a byte (8 pixels) in screen
    ''' </summary>
    ''' <param name="VAdress"></param>
    ''' <param name="_pattern"></param>
    ''' <param name="_color"></param>
    ''' <remarks></remarks>
    Private Sub setScreenByte(ByVal VAdress As Short, ByVal _pattern As Byte, ByVal _color As Byte)
        Dim aInkColor As Byte = Me.getInkColor(_color)
        Dim aBGColor As Byte = Me.getBGColor(_color)
        Dim nchar As Short = Fix(VAdress / 8)
        If nchar > 31 Then
            nchar = nchar
        End If
        '(-Int(-(VAdress / 8))) - 1
        '(-(VAdress / 8), MidpointRounding.AwayFromZero)
        Dim nfile As Byte = Fix(nchar / 32)
        Dim ncolumn As Byte = nchar - (nfile * 32)
        Dim Xpos As Short = ncolumn * 8
        Dim Ypos As Short = (nfile * 8) + (VAdress - (nchar * 8))

        Dim aBit As Char

        ' zona de patrones
        Dim aBinary As String = Convert.ToString(_pattern, 2)
        'If gfxValue = 7 Then
        '    aBinary = aBinary.PadLeft(8, "0")
        'End If
        aBinary = aBinary.PadLeft(8, "0")
        For i As Integer = 0 To 7
            aBit = aBinary(i)
            If aBit = "1" Then
                'Me.screenBitmap.SetPixel(Xpos, Ypos, _msxPalette.getRGB(_msxPalette.GetColor(aInkColor))) '.RGBColor) '   _msxPalette(aInkColor)
                Me.screenBitmap.SetPixel(Xpos, Ypos, _msxPalette.getRGB(aInkColor))
            Else
                'Me.screenBitmap.SetPixel(Xpos, Ypos, _msxPalette.getRGB(_msxPalette.GetColor(aBGColor))) '.RGBColor) 'msxPalette(aBGColor)
                Me.screenBitmap.SetPixel(Xpos, Ypos, _msxPalette.getRGB(aBGColor))
            End If
            Xpos += 1
            'gfxValue = Fix(gfxValue / 2)
        Next

        'Me.Refresh()
        'My.Application.DoEvents()

    End Sub



    Private Function getInkColor(ByVal ValueType As Byte) As Integer

        Return (ValueType And 240) / 16

    End Function


    Private Function getBGColor(ByVal ValueType As Byte) As Integer

        Return (ValueType And 15)

    End Function


    Public Sub OrderMap()

        Dim VAddress As Short = BASE(NumberOfBase.Name_Table_Base_Address)
        For i = 0 To 3

            For o As Short = 0 To 255
                Me.VPOKE(VAddress, CByte(o))
                VAddress += 1
            Next

        Next

        Me.ShowTilesMap()

        Me.Refresh()

    End Sub





    ''' <summary>
    ''' Visualiza los patrones (tiles)
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub showTilesMap()
        Dim vadress As Short = Me.BASE(10)

        For i As Short = 0 To 767

            putTile(i, VPEEK(vadress))
            vadress += 1

        Next

    End Sub



    Private Sub putTile(ByVal tilepos As Short, ByVal nTile As Byte)

        Dim tempBitmap As Bitmap

        Dim posY As Integer = Fix(tilepos / 32)
        Dim posX As Integer = (tilepos - (posY * 32)) * 8
        posY = posY * 8

        Select Case tilepos
            Case 0 To 255
                tempBitmap = Tile_Bank0(nTile)
            Case 256 To 511
                tempBitmap = Tile_Bank1(nTile)
            Case 512 To 767
                tempBitmap = Tile_Bank2(nTile)
            Case Else
                Exit Sub
        End Select

        Dim aGraphics As Graphics = Graphics.FromImage(Me.tilesBitmap)
        'Me.tilesScreen.
        aGraphics.DrawImage(tempBitmap, posX, posY, 8, 8)
        aGraphics.Flush()

    End Sub


    ''' <summary>
    ''' Genera los patrones graficos
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetTileSets()

        'http://www.dreamincode.net/forums/showtopic119939.htm

        'Dim m_TileIndex() As Integer ' An array containing an Index to the corrisponding Tile

        Dim i As Integer = 0
        Dim tempBitmap As Bitmap
        For RowIndex As Integer = 0 To 23
            For ColumnIndex As Integer = 0 To 31
                tempBitmap = GetTile(ColumnIndex * 8, RowIndex * 8)
                Select Case RowIndex
                    Case 0 To 7
                        Me.Tile_Bank0(i) = tempBitmap
                    Case 8 To 15
                        Me.Tile_Bank1(i) = tempBitmap
                    Case 16 To 23
                        Me.Tile_Bank2(i) = tempBitmap
                End Select
                i += 1
                If i = 256 Then i = 0
            Next
        Next

    End Sub



    Private Sub drawTileSet()

        For VAdress As Integer = 0 To 6143
            Me.SetScreenByte(VAdress, Me.VPEEK(VAdress), Me.VPEEK(VAdress + 8192))
        Next

    End Sub


    'Private Function PutTile(ByVal cropX As Single, ByVal cropY As Single, ByVal cropWidth As Single, ByVal cropHeight As Single) As Bitmap
    '    ' This function creates a cropped instance of the input bitmap, at coordiates and of the size specified.
    '    Dim aGraphics As Graphics = Graphics.FromImage(Me.tilesScreen.Image)
    '    Dim cropped As Bitmap = aGraphics.
    '    Return cropped
    'End Function


    Private Function getTile(ByVal cropX As Single, ByVal cropY As Single) As Bitmap
        ' ByRef bmp As Bitmap
        ' This function creates a cropped instance of the input bitmap, at coordiates and of the size specified.
        Dim rect As New Rectangle(cropX, cropY, 8, 8)
        Dim cropped As Bitmap = Me.screenBitmap.Clone(rect, Me.screenBitmap.PixelFormat) 'Me.tilesScreen.Image
        Return cropped
    End Function


    Public Function GetVRAM() As Byte()
        Return Me.VRAM.Clone
    End Function


    Public Sub SaveScreenPNG(ByVal filePath As String)

        screenBitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Png)

    End Sub


    Public Sub SaveTilesScreenPNG(ByVal filePath As String)

        tilesBitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Png)

    End Sub



    ''' <summary>
    ''' Load a MSX binary file. VRAM data dump (SC2)
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LoadSC2(ByVal filePath As String) As Boolean
        '
        '
        '
        Dim aStream As New System.IO.FileStream(filePath, FileMode.Open)
        Dim aFile As New System.IO.FileInfo(filePath)
        'Dim ROMdata() As Byte
        Dim aFileData() As Byte

        Dim dataPosition As Integer = 7

        Dim tamanyo As Integer = CInt(aFile.Length)
        aFileData = Nothing
        ReDim aFileData(tamanyo)

        aStream.Read(aFileData, 0, tamanyo)
        aStream.Close()


        '
        ' recoger datos del bin:
        ' direccion de inicio
        ' direccion de fin
        ' escribir en el buffer aScreen2

        ' <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        ' cabecera del fichero binario para memoria de video, zona de nombre de patrones.
        'aFileData(0) = &HFE
        'aFileData(1) = &H0  'init_addr
        'aFileData(2) = &H0
        'aFileData(3) = &HFF 'end_addr
        'aFileData(4) = &H3F
        'aFileData(5) = &H0  'exec_addr - no se usa
        'aFileData(6) = &H0

        If aFileData(0) = &HFE Then

            Dim address As Integer = ((aFileData(2) And 63) * 256) + aFileData(1)
            Dim dirend As Integer = ((aFileData(4) And 63) * 256) + aFileData(3)

            For i = address To dirend
                VPOKE(i, aFileData(dataPosition))
                dataPosition += 1
            Next

            SetVRAMPalette() ' for MSX2

            RefreshScreen()

            Return True

        Else
            'The file type is not SC2
            Return False
        End If

    End Function



    ''' <summary>
    ''' Save a MSX binary file. Full VRAM data dump (SC2)
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <remarks></remarks>
    Public Sub SaveSC2(ByVal filePath As String)

        Me.BSAVE(filePath, 0, &H3FFF)

    End Sub



    ''' <summary>
    ''' Save a MSX binary file.
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <param name="initAddr"></param>
    ''' <param name="endAddr"></param>
    ''' <remarks></remarks>
    Public Sub BSAVE(ByVal filePath As String, ByVal initAddr As Short, ByVal endAddr As Short)

        'Try

        Dim data As Byte()
        Dim dataLength As Short
        Dim vaddr As Short = initAddr

        ' realizar comprobaciones
        If initAddr > endAddr Then
            Exit Sub
        End If

        dataLength = endAddr - initAddr

        ReDim data(dataLength + 7)


        ' cabecera del fichero binario para memoria de video, zona de nombre de patrones.
        data(0) = &HFE
        data(1) = CByte(initAddr And &HFF)
        data(2) = CByte((initAddr And &HFF00) / &HFF)
        data(3) = CByte(endAddr And &HFF)
        data(4) = CByte((endAddr And &HFF00) / &HFF)
        data(5) = &H0
        data(6) = &H0
        ' end

        'carga los datos de la vram

        For i As Integer = 0 To dataLength - 1
            data(i + 7) = VPEEK(vaddr)
            vaddr += 1
        Next

        'crea el fichero
        Dim aStream As New System.IO.FileStream(filePath, IO.FileMode.Create)
        aStream.Write(data, 0, data.Length)
        aStream.Close()

        'Catch ex As Exception

        'End Try

    End Sub



    Private Sub tilesScreen_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tilesScreen.MouseMove
        Dim x As Integer = Fix((e.X) / 8)
        Dim y As Integer = Fix((e.Y) / 8)

        endposex = x
        endposey = y

        If x > 31 Then
            x = 31
        End If

        If y > 23 Then
            y = 23
        End If
        Dim nTile As Byte = Me.VPEEK(BASE(NumberOfBase.Name_Table_Base_Address) + (y * 32) + x)
        RaiseEvent MouseScreenData(x, y, nTile)

        If (isDrag) Then
            'Me.Refresh()

            If endposex > 32 Then
                endposex = 32
            End If

            If endposey > 24 Then
                endposey = 24
            End If


            ' Hide the previous rectangle by calling the DrawReversibleFrame 
            ' method with the same parameters.
            ControlPaint.DrawReversibleFrame(theRectangle, Color.DarkRed, FrameStyle.Thick)

            ' Calculate the endpoint and dimensions for the new rectangle, 
            ' again using the PointToScreen method.
            Dim endPoint As Point = CType(sender, Control).PointToScreen(New Point(endposex * 8, endposey * 8))
            Dim width As Integer = endPoint.X - startPoint.X
            Dim height As Integer = endPoint.Y - startPoint.Y
            theRectangle = New Rectangle(startPoint.X, startPoint.Y, width, height)

            ' Draw the new rectangle by calling DrawReversibleFrame again.  
            ControlPaint.DrawReversibleFrame(theRectangle, Color.DarkRed, FrameStyle.Thick)

        End If

    End Sub



    Private Sub ScreenPictureBox_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ScreenPictureBox.MouseMove
        Dim x As Integer = Fix((e.X) / 8)
        Dim y As Integer = Fix((e.Y) / 8)

        If x > 31 Then
            x = 31
        End If

        If y > 23 Then
            y = 23
        End If

        Dim tile As Integer = (((y * 32) - (256 * Fix(y / 8))) + x)

        RaiseEvent MouseScreenData(x, y, tile)

    End Sub



    Private Sub tilesScreen_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tilesScreen.MouseUp
        isDrag = False

        RaiseEvent MouseSelectedPos(sposex, sposey, endposex - 1, endposey - 1)

        'Reset the rectangle.
        theRectangle = New Rectangle(0, 0, 0, 0)

        'tilesScreen.Refresh()
        'Me.Refresh()

    End Sub



    Private Sub tilesScreen_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tilesScreen.MouseDown
        Dim x As Integer = Fix((e.X) / 8)
        Dim y As Integer = Fix((e.Y) / 8)

        Me.Refresh()

        If (e.Button = MouseButtons.Left) Then
            isDrag = True
            sposex = x
            sposey = y

            ' Calculate the startPoint by using the PointToScreen 
            ' method.
            Dim control As Control = CType(sender, Control)
            startPoint = control.PointToScreen(New Point(x * 8, y * 8))

        End If

    End Sub



    Public Sub Optimize()

        Dim patternBase As Short = TableBase.GRPCGP  '0    BASE(screen2.NumberOfBase.Pattern_Generator_Base_Address)
        Dim colorBase As Short = TableBase.GRPCOL    '8192 BASE(screen2.NumberOfBase.Color_Table_Base_Address)

        Dim colvalue As Byte
        Dim gfxvalue As Byte

        Dim control_color As Byte
        Dim control_colorInk As Byte
        Dim control_colorBG As Byte
        Dim colorInk As Byte
        Dim colorBG As Byte

        'Dim colorVADDR As Integer

        'color byte -> F0h = F -> inkcolor ; 0 -> BGcolor
        control_color = VPEEK(colorBase)
        control_colorInk = (control_color And &HF0) / 16
        control_colorBG = control_color And &HF

        For i = 1 To 6143
            colvalue = VPEEK(colorBase + i)
            gfxvalue = VPEEK(patternBase + i)

            colorInk = (colvalue And &HF0) / 16
            colorBG = colvalue And &HF

            ' (1) si estan invertidos los colores.
            If colorInk = control_colorBG And colorBG = control_colorInk And Not colorInk = colorBG Then '
                'If Not colorInk = colorBG Then
                colvalue = control_color
                gfxvalue = Not gfxvalue 'invierte valor del grafico
            Else

                If gfxvalue = 0 Then
                    ' (2) si el patron es 0 y el fondo coincide con uno de los colores de control
                    If colorBG = control_colorBG Then
                        'colorInk = control_colorInk
                        colvalue = control_color
                    ElseIf colorBG = control_colorInk Then
                        colvalue = control_color
                        gfxvalue = Not gfxvalue
                    End If
                ElseIf gfxvalue = 255 Then
                    ' (3) si el patron es 255 y el color de tinta coincide con uno de los colores de control
                    If colorInk = control_colorInk Then
                        colvalue = control_color
                    ElseIf colorInk = control_colorBG Then
                        colvalue = control_color
                        gfxvalue = Not gfxvalue
                    End If
                End If
            End If

            VPOKE(colorBase + i, colvalue)
            VPOKE(patternBase + i, gfxvalue)

            control_color = colvalue
            control_colorInk = (control_color And &HF0) / 16
            control_colorBG = control_color And &HF
        Next

    End Sub



    Public Sub setScreenFromBitmap(ByVal sourceBitmap As Bitmap)
        Dim aColor As Color
        Dim myBitmap4b = New Bitmap(256, 192)
        Dim posx As Integer
        Dim posy As Integer
        Dim aPixelColor(8) As Byte
        Dim aPixelPattern(8) As Boolean
        Dim i As Integer
        Dim o As Integer
        Dim aMSXColor As New ColorByte
        'Dim aByteColor As Byte
        Dim aBytePattern As Byte

        Dim VRAMaddr As Integer = 0

        For posy = 0 To 191
            For posx = 0 To 255
                aColor = sourceBitmap.GetPixel(posx, posy)
                pixelscreen(posx, posy) = getMSXColor(aColor)
                'myBitmap4b.SetPixel(posx, posy, MSXcolors.Item(pixelscreen(posx, posy)))
            Next
        Next

        For tileY As Integer = 0 To 23
            For tileX As Integer = 0 To 31
                posy = tileY * 8
                posx = tileX * 8
                For o = 0 To 7
                    For i = 0 To 7
                        aPixelColor(i) = pixelscreen(posx + i, posy + o)
                    Next
                    'contar colores y ordenar de mayor a menor
                    'coger los dos colores que más se repiten
                    aMSXColor = getFGBGColors(aPixelColor)
                    'aByteColor = aMSXColor.GetFGBG()
                    'generar el patron
                    For i = 0 To 7
                        If aPixelColor(i) = aMSXColor.BackGround Then
                            aPixelPattern(i) = False
                        ElseIf aPixelColor(i) = aMSXColor.ForeGround Then
                            aPixelPattern(i) = True
                        Else
                            ' convierte a FG o BG
                            If isRed(aMSXColor.ForeGround) And isRed(aPixelColor(i)) Then
                                aPixelPattern(i) = True
                            ElseIf isGreen(aMSXColor.ForeGround) And isGreen(aPixelColor(i)) Then
                                aPixelPattern(i) = True
                            ElseIf isBlue(aMSXColor.ForeGround) And isBlue(aPixelColor(i)) Then
                                aPixelPattern(i) = True
                            ElseIf isYellow(aMSXColor.ForeGround) And isYellow(aPixelColor(i)) Then
                                aPixelPattern(i) = True
                            ElseIf isWhite(aMSXColor.ForeGround) And isWhite(aPixelColor(i)) Then
                                aPixelPattern(i) = True
                            ElseIf isDark(aMSXColor.ForeGround) And isDark(aPixelColor(i)) Then
                                aPixelPattern(i) = True
                            ElseIf isMedium(aMSXColor.ForeGround) And isMedium(aPixelColor(i)) Then
                                aPixelPattern(i) = True
                            ElseIf isLight(aMSXColor.ForeGround) And isLight(aPixelColor(i)) Then
                                aPixelPattern(i) = True
                            Else
                                aPixelPattern(i) = False
                            End If
                        End If
                    Next

                    'convierte el array en un byte
                    aBytePattern = 0
                    For i = 0 To 7
                        If aPixelPattern(i) Then
                            aBytePattern = aBytePattern + Bit(i)
                        End If
                    Next

                    'escribe los datos en la memoria
                    Me.VPOKE(VRAMaddr, aBytePattern)
                    Me.VPOKE(TMS9918.TableBase.GRPCOL + VRAMaddr, aMSXColor.GetFGBG())
                    VRAMaddr = VRAMaddr + 1
                Next
            Next
        Next

        Optimize()

    End Sub



    Private Function getFGBGColors(ByVal a8Pixel() As Byte) As ColorByte
        Dim aColorByte As New ColorByte
        Dim aColorList As New SortedList()
        Dim aSortedColorList() As ColorItem
        'Dim colorOrder(8) As Byte
        Dim aColor As Byte = 0
        Dim i As Integer
        'Dim o As Integer

        'For i As Integer = 0 To 7
        '    colorOrder(i) = 0
        'Next


        ' cuenta colores
        For i = 0 To 7
            aColor = a8Pixel(i)
            If aColorList.ContainsKey(aColor) Then
                aColorList.Item(aColor) = aColorList.Item(aColor) + 1
            Else
                aColorList.Add(aColor, 1)
            End If
        Next

        aSortedColorList = colorSorter(aColorList)

        If aColorList.Count = 1 Then
            ' si solo hay un color
            aColorByte.BackGround = 1
            aColorByte.ForeGround = aSortedColorList(0).Color
        Else
            ' mas de un color, se ordenan de mayor a menor
            If aSortedColorList(1).Color = 1 Then
                'tiene prioridad el 1 (negro) como fondo
                aColorByte.BackGround = 1
                aColorByte.ForeGround = aSortedColorList(0).Color
            Else
                aColorByte.BackGround = aSortedColorList(0).Color
                aColorByte.ForeGround = aSortedColorList(1).Color
            End If

        End If

        Return aColorByte
    End Function



    Private Function colorSorter(ByVal list As SortedList) As ColorItem()

        Dim i As Integer = 0
        Dim o As Integer
        Dim tempValue As ColorItem
        Dim tmpList() As ColorItem
        Dim listLength As Integer = list.Count
        ReDim tmpList(listLength - 1)

        For Each numColor As Byte In list.Keys
            tmpList(i) = New ColorItem(numColor, list.Item(numColor))
            i = i + 1
        Next

        For i = 0 To listLength - 2
            For o = i + 1 To listLength - 1
                If tmpList(i).Count < tmpList(o).Count Then
                    tempValue = tmpList(i)
                    tmpList(i) = tmpList(o)
                    tmpList(o) = tempValue
                End If
            Next
        Next

        Return tmpList
    End Function



    Private Function getMSXColor(ByVal aColor As Color) As Byte
        'Dim newColor As New Color
        Dim red As Byte = aColor.R
        Dim green As Byte = aColor.G
        Dim blue As Byte = aColor.B
        Dim Hue As Integer = aColor.GetHue
        Dim Brightness As Byte = CByte(aColor.GetBrightness * 100)
        Dim Saturation As Byte = CByte(aColor.GetSaturation * 100)
        Dim tmpBrightness As Byte
        'Dim tmpSaturation As Byte


        If Saturation > 25 Then


            'reds
            If Hue > 320 Or Hue < 31 Then
                '255, 121, 120)) ' 9 - light red
                'tmpBrightness = 76
                If Brightness > 68 And Brightness < 80 Then
                    Return 9
                End If
                '252,  85,  84)) ' 8 - medium red 
                'tmpBrightness = 66
                If Brightness > 60 And Brightness < 69 Then
                    Return 8
                End If
                '212,  82,  77)) ' 6 — dark red
                'tmpBrightness = 56
                If Brightness > 20 And Brightness < 61 Then
                    Return 6
                End If
            End If


            'greens
            If Hue > 80 And Hue < 161 Then

                'If Hue = 136 Then '<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< TEST >>>
                '    tmpBrightness = 65
                'End If

                '94, 220, 120)) ' 3 — light green
                tmpBrightness = 63
                If Brightness > 56 And Brightness < 80 Then
                    Return 3
                End If
                '33, 200,  66)) ' 2 — medium green 
                If Brightness > 41 And Brightness < 57 Then
                    Return 2
                End If
                '33, 176,  59)) '12 - dark green
                If Brightness > 20 And Brightness < 42 Then
                    Return 12
                End If
            End If


            'blues
            If Hue > 200 And Hue < 271 Then
                '94, 220, 120)) ' 5 — light blue
                'tmpBrightness = 74 '69
                If Brightness > 64 And Brightness < 80 Then
                    Return 5
                End If

                '33, 176,  59)) '4 - dark blue
                'tmpBrightness = 54 '
                If Brightness > 20 And Brightness < 65 Then
                    Return 4
                End If
            End If


            ' 66, 235, 245)) ' 7 - cyan
            If Hue > 160 And Hue < 201 Then
                'If Hue = 211 Then '189
                '    tmpBrightness = 65
                'End If

                If Brightness > 20 And Brightness < 80 Then
                    Return 7
                End If


            End If


            '201,  91, 186)) '13 - magenta
            If Hue > 270 And Hue < 321 Then
                If Brightness > 20 And Brightness < 80 Then
                    Return 13
                End If
            End If


            'yellows
            If Hue > 30 And Hue < 81 Then
                '230, 206, 128)) '11 - light yellow
                If Brightness > 60 And Brightness < 80 Then
                    Return 11
                End If

                '212, 193, 84))  '10 - dark yellow
                If Brightness > 20 And Brightness < 61 Then
                    Return 10
                End If
            End If
        End If

        'If Saturation < 30 Then
        ' 15 - white
        If Brightness > 90 Then
            Return 15
        End If

        ' 14 - gray 
        If Brightness > 40 And Brightness < 91 Then
            Return 14
        End If

        ' 1 - black
        If Brightness < 41 Then
            Return 1
        End If
        'End If

        ' default color
        Return 1
    End Function

    Private Function isRed(ByVal acolor As Byte) As Boolean
        If acolor = 6 Or acolor = 8 Or acolor = 9 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function isBlue(ByVal acolor As Byte) As Boolean
        If acolor = 4 Or acolor = 5 Or acolor = 7 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function isGreen(ByVal acolor As Byte) As Boolean
        If acolor = 2 Or acolor = 3 Or acolor = 12 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function isYellow(ByVal acolor As Byte) As Boolean
        If acolor = 10 Or acolor = 11 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function isWhite(ByVal acolor As Byte) As Boolean
        If acolor = 14 Or acolor = 15 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function isDark(ByVal acolor As Byte) As Boolean
        Select Case acolor
            Case 0, 1, 4, 6, 12, 13
                Return True
            Case Else
                Return False
        End Select
    End Function

    Private Function isMedium(ByVal acolor As Byte) As Boolean
        Select Case acolor
            Case 2, 5, 8
                Return True
            Case Else
                Return False
        End Select
    End Function

    Private Function isLight(ByVal acolor As Byte) As Boolean
        Select Case acolor
            Case 3, 7, 9, 10, 11, 14, 15
                Return True
            Case Else
                Return False
        End Select
    End Function



End Class
