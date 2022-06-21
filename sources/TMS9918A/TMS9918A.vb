''' <summary>
''' TMS9918A User Control
''' </summary>
''' <remarks></remarks>
Public Class TMS9918A

    Private bite_MASKs = New Byte() {1, 2, 4, 8, 16, 32, 64, 128}

    Private _screenMode As iVDP.SCREEN_MODE = iVDP.SCREEN_MODE.G2
    Private _SpriteZoom As iVDP.SPRITE_ZOOM = iVDP.SPRITE_ZOOM.X1

    Private _SpriteSize As SpriteMSX.SPRITE_SIZE = SpriteMSX.SPRITE_SIZE.SIZE16
    Private _SpriteMode As SpriteMSX.SPRITE_MODE = SpriteMSX.SPRITE_MODE.MONO

    Private _inkColor As Byte = 15
    Private _backgroundColor As Byte = 4
    Private _borderColor As Byte = 1

    Private _IsShowSprites As Boolean = True

    Private _viewMode As VIEW_MODE = VIEW_MODE.ALL
    Private _viewSize As VIEW_SIZE = VIEW_SIZE.x1

    Private _columns As Integer = 32
    Private _tileWidth As Integer = 8
    Private _tileHeight As Integer = 8

    Private Const TMSWIDTH = 256
    Private Const TMSHEIGHT = 192

    Private _controlType As CONTROL_TYPE = CONTROL_TYPE.VIEWER

    Private Const VRAMaddr_PALETTE = &H1B80   '&H1B80 VRAM adress for palette for screen2 (Only used by MSX Basic)

    Public Palette As iPaletteMSX

    Public GridColor As Color = Color.LightSkyBlue

    Private VRAM(16383) As Byte ' 16k de memoria de video
    Private tilesetBitmap As Bitmap
    Private outputBitmap As Bitmap
    Private spritePatternsBitmap As Bitmap
    Private spritesLayerBitmap As Bitmap

    Private spritePatterns As ArrayList

    Private isDrag As Boolean = False
    Private theRectangle As New Rectangle(0, 0, 0, 0)
    Private startPoint As Point
    Private start_posX As Integer
    Private start_posY As Integer
    Private end_posX As Integer
    Private end_posY As Integer

    Private Default_Cursor As Cursor
    Private Selecter_Cursor As Cursor




    ' EVENTs ###########################################################################################################################

    Public Event MouseScreenData(ByVal x As Integer, ByVal y As Integer) ', ByVal nTile As Integer)

    Public Event MouseScreenPress(ByVal x As Integer, ByVal y As Integer)
    Public Event MouseScreenDown(ByVal x As Integer, ByVal y As Integer)

    Public Event MouseSelectedArea(ByVal start_X As Integer, ByVal start_Y As Integer, ByVal end_X As Integer, ByVal end_Y As Integer)

    Public Event PaletteChanged(ByVal data() As Byte)

    ' END EVENTs #######################################################################################################################




    Public VIEW_MODE_Text() As String = {"All (map + sprites)", "Map", "Tileset", "Sprites (32 layers)", "Sprites (patterns)"}


    Public Shadows Enum VIEW_MODE As Integer
        ALL
        MAP
        TILESET
        SPRITE_LAYERS
        SPRITE_PATTERNS
    End Enum


    'VIEW_SIZE
    Public Shadows Enum VIEW_SIZE As Integer
        x1 = 1
        x2 = 2
    End Enum



    Public Shadows Enum CONTROL_TYPE As Integer
        VIEWER
        SELECTER
        SPRITEOAM
    End Enum


    'Public Shadows Enum TableBase As Integer
    '    ' screen 0
    '    TXTNAM = 0       ' 0 Map
    '    TXTCGP = &H800   ' 2 Tile Pattern

    '    ' screen 1
    '    T32NAM = &H1800  ' 5 Map
    '    T32COL = &H2000  ' 6 Tile Color
    '    T32CGP = 0       ' 7 Tile Pattern
    '    T32ATR = &H1B00  ' 8 Sprite Attribute
    '    T32PAT = &H3800  ' 9 Sprite Pattern

    '    ' screen 2
    '    GRPNAM = &H1800  ' 10 Name_Table_Base_Address
    '    GRPCOL = &H2000  ' 11 Color_Table_Base_Address
    '    GRPCGP = 0       ' 12 Pattern_Generator_Base_Address
    '    GRPATR = &H1B00  ' 13 Sprite_Attribute_Table_Base_Address
    '    GRPPAT = &H3800  ' 14 Sprite_Pattern_Generator_Base_Address

    '    ' screen 3
    '    MLTNAM = &H800   ' 15 Map
    '    MLTCGP = 0       ' 17 Pattern
    '    MLTATR = &H1B00  ' 18 Sprite Attribute
    '    MLTPAT = &H3800  ' 19 Sprite Pattern

    '    ' screen 4 (V9938)
    '    SP2COL = &H1C00 '-1DFF  Sprite colours table 
    '    SC4PAL = &H1B80 '-1E9F  MSX BASIC Graphic format > Palette Data


    'End Enum



    ' --------------------------------------------------------
    'https://www.msx.org/wiki/BASE()
    '
    'Sprite Color Table
    '
    'size = 32 planes * 16 = 512 = &H200 
    '
    'SCREEN	Decimal	Hexadecimal
    '--------------------------
    '4	    7168	1C00
    '5-6	29696	7400
    '7-8	63488	F800
    '10-12	63488	F800
    ' --------------------------------------------------------




    'Public Shadows Enum TableBaseSize As Integer
    '    ' screen 0
    '    TXTNAM = &H3C0  ' 0 Map
    '    TXTCGP = &H800  ' 2 Tile Pattern

    '    ' screen 1
    '    T32NAM = &H300  ' 5 Map
    '    T32COL = &H20   ' 6 Tile Color
    '    T32CGP = &H800  ' 7 Tile Pattern
    '    T32ATR = &H80   ' 8 Sprite Attribute
    '    T32PAT = &H800  ' 9 Sprite Pattern

    '    ' screen 2
    '    GRPNAM = &H300  ' 10 Name_Table_Base_Address
    '    GRPCOL = &H1800 ' 11 Color_Table_Base_Address
    '    GRPCGP = &H1800 ' 12 Pattern_Generator_Base_Address
    '    GRPATR = &H80   ' 13 Sprite_Attribute_Table_Base_Address
    '    GRPPAT = &H800  ' 14 Sprite_Pattern_Generator_Base_Address

    '    ' screen 3
    '    MLTNAM = &H300    ' 15 Map - Size????
    '    MLTCGP = &H600  ' 17 Pattern
    '    MLTATR = &H80   ' 18 Sprite Attribute
    '    MLTPAT = &H800  ' 19 Sprite Pattern



    'End Enum




    'Public Shadows Enum NumberOfBase As Byte
    '    Name_Table_Base_Address = 10
    '    Color_Table_Base_Address = 11
    '    Pattern_Generator_Base_Address = 12
    '    Sprite_Attribute_Table_Base_Address = 13
    '    Sprite_Pattern_Generator_Base_Address = 14
    'End Enum






    Public Property ScreenMode() As iVDP.SCREEN_MODE
        Get
            Return Me._screenMode
        End Get
        Set(ByVal value As iVDP.SCREEN_MODE)
            Me._screenMode = value
            If value = iVDP.SCREEN_MODE.T1 Then
                Me._columns = 40
                Me._tileWidth = 6 * Me._viewSize
                Me._tileHeight = 8 * Me._viewSize
            Else
                Me._columns = 32
                Me._tileWidth = 8 * Me._viewSize
                Me._tileHeight = 8 * Me._viewSize
                If value = iVDP.SCREEN_MODE.G3 Then
                    Me._SpriteMode = SpriteMSX.SPRITE_MODE.COLOR
                Else
                    Me._SpriteMode = SpriteMSX.SPRITE_MODE.MONO
                End If
            End If
        End Set
    End Property



    Public Property IsShowSprites() As Boolean
        Get
            Return Me._IsShowSprites
        End Get
        Set(ByVal value As Boolean)
            _IsShowSprites = value
        End Set
    End Property



    Public Property SpriteSize() As SpriteMSX.SPRITE_SIZE
        Get
            Return Me._SpriteSize
        End Get
        Set(ByVal value As SpriteMSX.SPRITE_SIZE)
            Me._SpriteSize = value
        End Set
    End Property


    Public Property SpriteZoom() As iVDP.SPRITE_ZOOM
        Get
            Return Me._SpriteZoom
        End Get
        Set(ByVal value As iVDP.SPRITE_ZOOM)
            Me._SpriteZoom = value
        End Set
    End Property



    ''' <summary>
    ''' color mode for sprites (G3 V9938 mode)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SpriteMode() As SpriteMSX.SPRITE_MODE
        Get
            Return Me._SpriteMode
        End Get
        'Set(ByVal value As SpriteMSX.SPRITE_MODE)
        '    Me._SpriteMode = value
        'End Set
    End Property



    Public Property ControlType() As CONTROL_TYPE
        Get
            Return Me._controlType
        End Get
        Set(ByVal value As CONTROL_TYPE)
            Me._controlType = value
        End Set
    End Property



    Public Property InkColor() As Byte
        Get
            Return Me._inkColor
        End Get
        Set(ByVal value As Byte)
            Me._inkColor = value
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



    Public Property BorderColor() As Byte
        Get
            Return Me._borderColor
        End Get
        Set(ByVal value As Byte)
            Me._borderColor = value
        End Set
    End Property



    Public Property ViewMode() As VIEW_MODE
        Get
            Return Me._viewMode
        End Get
        Set(ByVal value As VIEW_MODE)
            Me._viewMode = value
        End Set
    End Property



    Public Property ViewSize() As VIEW_SIZE
        Get
            Return Me._viewSize
        End Get
        Set(ByVal value As VIEW_SIZE)
            Me._viewSize = value
        End Set
    End Property



    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        'Me.Palette = New PaletteMSX
        'initTMS9918Palette()

    End Sub



    Private Sub TMS9918_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Me.Size = New Size(TMSWIDTH * Me._viewSize, TMSHEIGHT * Me._viewSize)
    End Sub



    Private Sub TMS9918_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim screen_width As Integer = TMSWIDTH * Me._viewSize
        Dim screen_height As Integer = TMSHEIGHT * Me._viewSize

        'Me.Size = New Point(screen_width, screen_height)
        Me.Palette = New PaletteTMS9918

        Me.tilesetBitmap = New Bitmap(screen_width, screen_height)
        Me.tilesetPictureBox.Image = Me.tilesetBitmap

        Me.outputBitmap = New Bitmap(screen_width, screen_height)

        Me.BackgroundImage = Me.outputBitmap
        Dim aGraphics As Graphics = Graphics.FromImage(Me.outputBitmap)
        aGraphics.Clear(Me.Palette.GetRGBColor(Me._borderColor))

        Me.spritePatternsBitmap = New Bitmap(screen_width, screen_height)
        Me.spritePatternsPictureBox.Image = Me.spritePatternsBitmap

        Me.spritesLayerBitmap = New Bitmap(screen_width, screen_height)
        Me.spritesLayerPictureBox.Image = Me.spritesLayerBitmap

        Me.Default_Cursor = New Cursor(New System.IO.MemoryStream(My.Resources.cursor_draw01))
        Me.Selecter_Cursor = New Cursor(New System.IO.MemoryStream(My.Resources.cursor_draw02))

        SetView(Me.ViewMode)

    End Sub



    Public Sub SetView(ByVal mode As VIEW_MODE)

        Me.ViewMode = mode

        Select Case mode
            Case VIEW_MODE.MAP
                Me.BackgroundImage = Me.outputBitmap
                Me.tilesetPictureBox.Visible = False
                Me.spritePatternsPictureBox.Visible = False
                Me.spritesLayerPictureBox.Visible = False

            Case VIEW_MODE.TILESET
                Me.tilesetPictureBox.Visible = True
                Me.spritePatternsPictureBox.Visible = False
                Me.spritesLayerPictureBox.Visible = False

            Case VIEW_MODE.SPRITE_LAYERS
                'clear output screen
                Dim clearBitmap As Bitmap
                clearBitmap = New Bitmap(outputBitmap.Width, outputBitmap.Height)
                Dim aGraphics As Graphics = Graphics.FromImage(clearBitmap)
                aGraphics.Clear(Me.Palette.GetRGBColor(Me._borderColor))
                Me.BackgroundImage = clearBitmap

                Me.tilesetPictureBox.Visible = False
                Me.spritePatternsPictureBox.Visible = False
                Me.spritesLayerPictureBox.Visible = True

            Case VIEW_MODE.SPRITE_PATTERNS
                Me.tilesetPictureBox.Visible = False
                Me.spritePatternsPictureBox.Visible = True
                Me.spritesLayerPictureBox.Visible = False

            Case Else  'all
                Me.BackgroundImage = Me.outputBitmap
                Me.tilesetPictureBox.Visible = False
                Me.spritePatternsPictureBox.Visible = False
                Me.spritesLayerPictureBox.Visible = True

        End Select

    End Sub



    Public Sub RefreshScreen()

        Dim aGraphics As Graphics = Graphics.FromImage(Me.outputBitmap)

        If Me.Palette.Type = iPaletteMSX.VDP.V9938 Then
            If isColorPalette() = True Then RestoreColorPalette()
        End If

        aGraphics.Clear(Me.Palette.GetRGBColor(Me._borderColor))

        'If Not Me.ViewMode = VIEW_MODE.SPRITES_LAYERS And Not Me.ViewMode = VIEW_MODE.SPRITES_PATTERNS Then
        drawTileSet()

        drawSpritePatterns()
        'setTileSets()

        If Me.ViewMode = VIEW_MODE.ALL Or Me.ViewMode = VIEW_MODE.MAP Then
            showMap()
        End If



        If Me._controlType = CONTROL_TYPE.SPRITEOAM Then   ' ADD GRID <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< OJO TEST
            'ControlPaint.DrawGrid(aGraphics, New Rectangle(0, 0, outputBitmap.Size.Width, outputBitmap.Size.Height), New System.Drawing.Size(8 * Me.ViewSize, 8 * Me.ViewSize), Color.YellowGreen)

            'DrawGrid genera una matriz de puntos con el color opuesto al indicado en el ultimo parametro, por eso no utilizo el definido en el config Me.GridColor
            ControlPaint.DrawGrid(aGraphics, Me.ClientRectangle, New Size(8 * Me.ViewSize, 8 * Me.ViewSize), Me.Palette.GetRGBColor(Me._backgroundColor))

            Me.Cursor = Me.Selecter_Cursor

        Else
            Me.Cursor = Me.Default_Cursor 'System.Windows.Forms.Cursors.Default
        End If



        If Me._IsShowSprites And Not Me.ScreenMode = iVDP.SCREEN_MODE.T1 Then
            RefreshSprites()
        Else
            Me.Refresh()
        End If

    End Sub



    Public Sub RefreshSprites()

        Dim aGraphics As Graphics = Graphics.FromImage(Me.spritesLayerBitmap)
        aGraphics.Clear(Color.Transparent)
        spritePatternsBitmap.MakeTransparent()

        'If Me.ViewMode = VIEW_MODE.ALL Or Me.ViewMode = VIEW_MODE.MAP Then
        '    showMap()
        'End If

        'If Me._IsShowSprites And Not Me.ScreenMode = SCREEN_MODE.T1 Then
        ShowSprites()
        'End If


        Me.Refresh()

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
    '1B80   Palette
    '2000-37FF   PixelByte colour table
    '3800-3FFF   Sprite character patterns



    ''' <summary>
    ''' Proporciona la dirección VRAM de la tabla del VDP indicada (MSX BASIC)
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function BASE(ByVal value As Integer) As Short
        Dim result As Integer = 0
        Select Case value

            ' screen 0 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            Case 0 ' tabla de nombre de patrones / Name Table Base Address
                result = 0
            Case 2 ' tabla generadora de patrones / pattern generator Base Address
                result = &H800


                ' screen 1 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            Case 5 ' tabla de nombre de patrones / Name Table Base Address
                result = &H1800
            Case 6 ' tabla de colores / Color Table Base Address
                result = &H2000
            Case 7 ' tabla generadora de patrones / pattern generator Base Address
                result = 0
            Case 8 ' tabla atributos de figuras móviles / sprite attribute table Base Address (OAM)
                result = &H1B00
            Case 9 ' Tabla de patrones de figura móvil / sprite pattern generator Base Address
                result = &H3800


                ' screen 2 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            Case 10 ' tabla de nombre de patrones / Name Table Base Address
                result = &H1800
            Case 11 ' tabla de colores / Color Table Base Address
                result = &H2000
            Case 12 ' tabla generadora de patrones / pattern generator Base Address
                result = 0
            Case 13 ' tabla atributos de figuras móviles / sprite attribute table Base Address (OAM)
                result = &H1B00
            Case 14 ' Tabla de patrones de figura móvil / sprite pattern generator Base Address
                result = &H3800


                ' screen 3 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            Case 15 ' tabla de nombre de patrones / Name Table Base Address
                result = &H800

            Case 17 ' tabla generadora de patrones / pattern generator Base Address
                result = 0
            Case 18 ' tabla atributos de figuras móviles / sprite attribute table Base Address (OAM)
                result = &H1B00
            Case 19 ' Tabla de patrones de figura móvil / sprite pattern generator Base Address
                result = &H3800


                ' screen 4
            Case 20 ' tabla de nombre de patrones / Name Table Base Address
                result = 6144
            Case 21 ' tabla de colores / Color Table Base Address
                result = 8192
            Case 22 ' tabla generadora de patrones / pattern generator Base Address
                result = 0
            Case 23 ' tabla atributos de figuras móviles / sprite attribute table Base Address (OAM)
                result = &H1E00
            Case 24 ' Tabla de patrones de figura móvil / sprite pattern generator Base Address
                result = &H3800


                '#define BASE40 0x1800 // base 10 name table (6144)
                '#define BASE41 0x2000 // base 11 color table (8192)
                '#define BASE42 0x0000 // base 12 character pattern table (0)
                '#define BASE43 0x1E00 // base 13 sprite attribute table (6912)
                '#define BASE44 0x3800 // base 14 sprite pattern table (14336)
                '#define BASE45 0x1C00 // base 14 sprite color

            Case Else
                result = 0

        End Select

        Return result

    End Function



    Public Sub SetDefaultPalette()
        Me.Palette.SetDefault()
    End Sub



    Public Sub SetPalette(ByVal newPalette As iPaletteMSX)
        Me.Palette = newPalette
        'Me.PaletteType = newPalette.PaletteType
        'If 

        SetPaletteVRAM()
        'Me.RefreshScreen()
    End Sub



    ''' <summary>
    ''' writes to VRAM the values of a V9938 color palette
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetPaletteVRAM()

        Dim paletteData() As Byte
        Dim VRAMaddr As Integer = VRAMaddr_PALETTE
        Dim value As Byte
        Dim valueIndex As Integer = 0

        Dim colorRed As Byte
        Dim colorGreen As Byte
        Dim colorBlue As Byte


        If Not Me.Palette Is Nothing Then

            'if you use the TMS9918A palette it does not update the palette
            If Me.Palette.Type = iPaletteMSX.VDP.V9938 Then

                paletteData = Me.Palette.GetData()

                ' escribe los valores de la paleta (V9938) a la vram
                For i As Integer = 0 To 15

                    colorRed = paletteData(valueIndex)
                    colorGreen = paletteData(valueIndex + 1)
                    colorBlue = paletteData(valueIndex + 2)

                    value = (colorRed * 16) + colorBlue

                    VRAM(VRAMaddr) = value  'RB
                    VRAMaddr += 1

                    VRAM(VRAMaddr) = colorGreen 'G
                    VRAMaddr += 1
                    valueIndex += 3
                Next

            End If

        End If

    End Sub



    Public Function isColorPalette() As Boolean

        Dim checksum As Integer = 0

        For i As Integer = 0 To 31
            checksum += Me.VRAM(VRAMaddr_PALETTE + i)
        Next

        If checksum > 0 And checksum < 4000 Then
            ' the usual thing in the case of a sc2 without palette, will be that all the values are 0 or FF

            Return True

        Else

            Return False

        End If

    End Function




    ''' <summary>
    ''' Restore the color palette from the VRAM Color Table. For G2 and G3 graphics modes on the VDP V9938.
    ''' Same as MSX BASIC v2 "COLOR = RESTORE"
    ''' </summary>
    ''' <returns></returns>
    Public Function RestoreColorPalette() As Boolean
        Dim data As Byte()

        data = GetPaletteDataFromVRAM()

        If Not data Is Nothing Then
            Me.Palette.SetData(data)

            RaiseEvent PaletteChanged(data)

            Return True

        Else
            ' The VRAM no contains a color palette data
            Return False
        End If

    End Function



    ''' <summary>
    ''' Provides the color palette in an Array from data stored in the VRAM color table.
    ''' color = 2 Bytes = RB,0G
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPaletteDataFromVRAM() As Byte()
        Dim data(31) As Byte

        Dim value As Byte
        Dim dataPos As Integer = 0

        Dim total As Integer = 0

        For i As Integer = 0 To 15
            ' RB
            value = Me.VRAM(VRAMaddr_PALETTE + dataPos)
            data(dataPos) = value
            total += value
            dataPos += 1

            ' 0G
            value = Me.VRAM(VRAMaddr_PALETTE + dataPos)
            value = value And 7
            data(dataPos) = value
            total += value
            dataPos += 1
        Next

        If total < 50 Or total > 4049 Then
            ' The found data is not considered a palette
            ' (FF+0F) * 15 = 
            Return Nothing
        Else
            Return data
        End If

    End Function




    ''' <summary>
    ''' Writes a byte to the video RAM.
    ''' </summary>
    ''' <param name="VRAMaddr"></param>
    ''' <param name="value"></param>
    ''' <remarks></remarks>
    Public Sub VPOKE(ByVal VRAMaddr As Short, ByVal value As Byte)

        If VRAMaddr < 16384 Then
            VRAM(VRAMaddr) = value
        End If

    End Sub



    ''' <summary>
    ''' Write a block of data in the VRAM
    ''' </summary>
    ''' <param name="VRAMaddr"></param>
    ''' <param name="block"></param>
    ''' <remarks></remarks>
    Public Sub SetBlock(ByVal VRAMaddr As Integer, ByVal block() As Byte)

        Try
            For Each value As Byte In block
                VRAM(VRAMaddr) = value
                VRAMaddr += 1
            Next

        Catch ex As Exception

        End Try

        'Array.Copy(block, 0, Me.VRAM, vaddr, block.Length)  'block.Length-1

    End Sub



    ''' <summary>
    ''' Get a block from VRAM
    ''' </summary>
    ''' <param name="vaddr">VRAM address</param>
    ''' <param name="size">Size</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetBlock(ByVal vaddr As Integer, ByVal size As Integer) As Byte()
        Dim tmpBloq(size - 1) As Byte
        Array.Copy(Me.VRAM, vaddr, tmpBloq, 0, size)
        Return tmpBloq
    End Function



    ''' <summary>
    ''' Reads a byte from the video RAM.
    ''' </summary>
    ''' <param name="VRAMaddr"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function VPEEK(ByVal VRAMaddr As Short) As Byte

        If VRAMaddr < 16384 Then
            Return VRAM(VRAMaddr)
        Else
            Return 0
        End If

    End Function



    ''' <summary>
    ''' Fill a large area of the VRAM of the same byte.
    ''' </summary>
    ''' <param name="VRAMaddr"></param>
    ''' <param name="length"></param>
    ''' <param name="value"></param>
    ''' <remarks></remarks>
    Public Sub FillVRAM(ByVal VRAMaddr As Integer, ByVal length As Integer, ByVal value As Byte)

        If length < 1 Then Return

        For i = 0 To length - 1
            If VRAMaddr < &H4000 Then
                VRAM(VRAMaddr) = value
                VRAMaddr += 1
            End If
        Next
    End Sub



    Public Sub CopyVRAM(ByVal source As Integer, ByVal target As Integer, ByVal length As Integer)
        For VRAMaddr As Integer = source To source + length
            If target < &H4000 And VRAMaddr < &H4000 Then
                VRAM(target) = VRAM(VRAMaddr)
                target += 1
            End If
        Next
    End Sub



    Public Sub Initialize()
        Clear()
        SetOrderMap()
    End Sub



    Public Sub Clear()
        FillVRAM(0, &H3FFF, 0)
    End Sub



    ''' <summary>
    ''' draw a byte (8 pixels) in screen
    ''' </summary>
    ''' <param name="VAdress"></param>
    ''' <param name="_pattern"></param>
    ''' <param name="_color"></param>
    ''' <remarks></remarks>
    Private Sub setScreenByte(ByVal VAdress As Short, ByVal _pattern As Byte, ByVal _color As Byte)

        Dim aInkColor As Byte = _color >> 4  'And 240) / 16
        Dim aBGColor As Byte = _color And 15

        Dim nchar As Short = Fix(VAdress / 8)

        Dim nfile As Byte = Fix(nchar / 32)
        Dim ncolumn As Byte = nchar - (nfile * 32)
        Dim Xpos As Short = (ncolumn * 8) + 7
        Dim Ypos As Short = (nfile * 8) + (VAdress - (nchar * 8))

        For i As Integer = 0 To 7
            If (_pattern And bite_MASKs(i)) = bite_MASKs(i) Then
                If aInkColor > 0 Then
                    SetPoint(Me.tilesetBitmap, Xpos - i, Ypos, Me.Palette.GetRGBColor(aInkColor))
                End If
            ElseIf aBGColor > 0 Then
                SetPoint(Me.tilesetBitmap, Xpos - i, Ypos, Me.Palette.GetRGBColor(aBGColor))
            End If
        Next

        'Me.Refresh()
        'My.Application.DoEvents()

    End Sub



    Private Sub SetPoint(ByRef tmpBitmap As Bitmap, ByVal x As Integer, ByVal y As Integer, ByVal pointColor As Color)
        If Me._viewSize = VIEW_SIZE.x1 Then
            tmpBitmap.SetPixel(x, y, pointColor)
        Else
            x = x * Me._viewSize
            y = y * Me._viewSize
            tmpBitmap.SetPixel(x, y, pointColor)
            tmpBitmap.SetPixel(x + 1, y, pointColor)
            tmpBitmap.SetPixel(x, y + 1, pointColor)
            tmpBitmap.SetPixel(x + 1, y + 1, pointColor)
        End If
    End Sub



    ''' <summary>
    ''' Writes in the Name Table, correlative values from 0 to 255. 
    ''' Needed to display images in G2/G3 mode, which are not based on repeated tiles.
    ''' </summary>
    Public Sub SetOrderMap()

        Dim VRAMaddr As Short = BASE(iVDP.NumberOfBase.Name_Table_Base_Address)

        If _screenMode = iVDP.SCREEN_MODE.G2 Or _screenMode = iVDP.SCREEN_MODE.G3 Then
            For i = 0 To 2

                For o As Short = 0 To 255
                    VRAM(VRAMaddr) = CByte(o)
                    VRAMaddr += 1
                Next

            Next

            showMapG2()

        End If

    End Sub



    ''' <summary>
    ''' Build a screen from tiles.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub showMap()

        If _screenMode = iVDP.SCREEN_MODE.T1 Then
            showMapT1()
        ElseIf _screenMode = iVDP.SCREEN_MODE.G1 Then
            showMapG1()
        Else
            showMapG2()
        End If

    End Sub



    Private Sub showMapT1()
        Dim vadress As Short = iVDP.TableBase.TXTNAM

        For posY As Integer = 0 To 23
            For posX As Integer = 0 To 39
                putTileT1(posX, posY, VRAM(vadress))
                vadress += 1
            Next
        Next

    End Sub



    Private Sub showMapG1()
        Dim vadress As Short = Me.BASE(10)

        For posY As Integer = 0 To 23
            For posX As Integer = 0 To 31

                putTileG1(posX, posY, VRAM(vadress))
                vadress += 1
            Next
        Next
    End Sub



    Private Sub showMapG2()
        Dim vadress As Short = Me.BASE(10)

        For i As Integer = 0 To &H2FF
            putTileG2(i, VRAM(vadress))
            vadress += 1
        Next

    End Sub



    Private Sub ShowSprites()

        Dim vadress As Short

        Dim npattern As Byte
        Dim color As Byte
        Dim x As Integer
        Dim y As Integer

        Dim i As Integer

        Dim lastPlane As Integer = 31

        For i = 0 To 31
            vadress = iVDP.TableBase.GRPATR + (i * 4)
            y = VRAM(vadress)
            If y = 208 Then
                'si la coordenada y es igual a 208, ocultar sprites de planos posteriores
                lastPlane = i - 1
                Exit For
            End If
        Next

        If Not lastPlane < 0 Then
            For i = lastPlane To 0 Step -1 ' sprite planes

                If Me._screenMode = iVDP.SCREEN_MODE.G3 Then
                    vadress = iVDP.TableBase.SC4ATR + (i * 4) 'for V9938 G3 graphic mode (SC4)
                Else
                    vadress = iVDP.TableBase.GRPATR + (i * 4)
                End If

                y = VRAM(vadress)
                x = VRAM(vadress + 1)
                npattern = VRAM(vadress + 2)
                color = VRAM(vadress + 3)

                If (color And 128) = 128 Then
                    'EarlyClock
                    x = x - 32
                    color = color And 15
                End If

                PutSprite(i, x, y, color, npattern)
            Next
        End If

    End Sub



    ''' <summary>
    ''' Show all sprite patterns in a output bitmap.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub drawSpritePatterns()

        Dim aGraphics As Graphics = Graphics.FromImage(Me.spritePatternsBitmap)
        aGraphics.Clear(Color.FromArgb(255, 0, 0, 0))
        'aGraphics.Clear(Color.Transparent)

        If Me._SpriteSize = SpriteMSX.SPRITE_SIZE.SIZE8 Then
            drawSprites8Patterns()
        Else
            drawSprites16Patterns()
        End If
    End Sub



    Private Sub drawSprites8Patterns()

        Dim npattern As Integer = 0
        Dim spriteBitmap As Bitmap

        Dim aGraphics As Graphics = Graphics.FromImage(Me.spritePatternsBitmap)

        Dim x As Integer
        Dim y As Integer

        For y = 0 To 7
            For x = 0 To 31 ' sprite patterns
                spriteBitmap = GetSpritePattern8(npattern, 15)
                aGraphics.DrawImage(spriteBitmap, (x * 8) * Me._viewSize, (y * 8) * Me._viewSize)
                aGraphics.Flush()
                npattern += 1
            Next
        Next

    End Sub



    Private Sub drawSprites16Patterns()

        Dim npattern As Integer = 0
        Dim aSprite As Bitmap

        Dim aGraphics As Graphics = Graphics.FromImage(Me.spritePatternsBitmap)

        Dim x As Integer
        Dim y As Integer

        For y = 0 To 3
            For x = 0 To 15 ' sprite patterns
                aSprite = GetSpritePattern16(npattern, 15)
                aGraphics.DrawImage(aSprite, (x * 16) * Me._viewSize, (y * 16) * Me._viewSize)
                aGraphics.Flush()
                npattern += 4
            Next
        Next

    End Sub



    Public Sub PutSprite(ByVal plane As Byte, ByVal x As Integer, ByVal y As Integer, ByVal color As Byte, ByVal npattern As Integer)

        Dim spriteBitmap As Bitmap
        'Dim offset As Integer

        color = color And &HF  'elimina el bit de EC (Early Clock)

        ' en caso de estar en modo multicolor escribir en el area de la VRAM el mismo color para todas las lineas (igual que el MSX Basic)
        If Me._SpriteMode = SpriteMSX.SPRITE_MODE.COLOR Then
            color = plane ' in V9938 G4 (screen 5), collects the data of the sprite colors according to the plane where it is
        End If

        If Me._SpriteSize = SpriteMSX.SPRITE_SIZE.SIZE8 Then
            spriteBitmap = GetSpritePlayer8(npattern, color)
        Else
            spriteBitmap = GetSpriteLayer16(npattern, color)
        End If


        If y < 192 Or y = 255 Then
            ' solo dibuja los sprites que se encuentren dentro de la pantalla
            x = x * Me._viewSize

            If y = 255 Then
                'offset = 0
                y = 0  'para dibujar los sprites en la linea 0 la coordenada y ha de valer 255
            Else
                'offset = 1 * Me._viewSize
                y = (y + 1) * Me._viewSize 'los sprites se empiezan a escribir en la linea 1
            End If

            Dim aGraphics As Graphics = Graphics.FromImage(Me.spritesLayerBitmap) 'Me.outputBitmap)
            aGraphics.DrawImage(spriteBitmap, x, y)
            aGraphics.Flush()

        End If

    End Sub



    Private Function GetSpritePattern8(ByVal npattern As Integer, ByVal colorIndex As Byte) As Bitmap
        Dim tempBitmap As New Bitmap(8 * Me._viewSize, 8 * Me._viewSize)
        Dim tempValue As Byte
        Dim vadress As Short

        vadress = iVDP.TableBase.GRPPAT + (npattern * 8)

        Dim rgbColor As Color = Me.Palette.GetRGBColor(colorIndex)

        For y As Integer = 0 To 7

            tempValue = VRAM(vadress)
            vadress += 1
            For x As Integer = 0 To 7
                If (tempValue And Me.bite_MASKs(x)) = Me.bite_MASKs(x) Then
                    SetPoint(tempBitmap, 7 - x, y, rgbColor)
                End If
            Next

        Next

        Return tempBitmap
    End Function



    Private Function GetSpritePattern16(ByVal npattern As Integer, ByVal colorIndex As Byte) As Bitmap
        Dim tempBitmap As New Bitmap(16 * Me._viewSize, 16 * Me._viewSize)
        Dim tempValue As Byte = 0
        Dim vadress As Short
        'Dim colorVaddr As Short

        Dim rgbColor As Color = Me.Palette.GetRGBColor(colorIndex)

        vadress = iVDP.TableBase.GRPPAT + (npattern * 8)

        For y As Integer = 0 To 15

            tempValue = VRAM(vadress)
            For x As Integer = 0 To 7
                If (tempValue And Me.bite_MASKs(x)) = Me.bite_MASKs(x) Then
                    SetPoint(tempBitmap, 7 - x, y, rgbColor)
                End If
            Next


            tempValue = VRAM(vadress + 16)
            vadress += 1
            For x As Integer = 0 To 7
                If (tempValue And Me.bite_MASKs(x)) = Me.bite_MASKs(x) Then
                    SetPoint(tempBitmap, 15 - x, y, rgbColor)
                End If
            Next

        Next

        Return tempBitmap
    End Function



    Private Function GetSpritePlayer8(ByVal npattern As Integer, ByVal colorIndex As Byte) As Bitmap
        Dim tempBitmap As New Bitmap(8 * Me._viewSize, 8 * Me._viewSize)
        Dim tempValue As Byte
        Dim patternVaddr As Short
        Dim colorVaddr As Short

        Dim rgbColor As Color

        patternVaddr = iVDP.TableBase.GRPPAT + (npattern * 8)
        colorVaddr = iVDP.TableBase.SC4SAC + (npattern * 16) 'for V9938 G3 graphic mode (SC4)

        For y As Integer = 0 To 7

            If Me._SpriteMode = SpriteMSX.SPRITE_MODE.COLOR Then
                colorIndex = VRAM(colorVaddr) And &HF 'Multicolor Sprites - V9938 G3 graphic mode (SC4)
                colorVaddr += 1
            End If

            rgbColor = Me.Palette.GetRGBColor(colorIndex)

            tempValue = VRAM(patternVaddr)
            patternVaddr += 1
            For x As Integer = 0 To 7
                If (tempValue And Me.bite_MASKs(x)) = Me.bite_MASKs(x) Then
                    SetPoint(tempBitmap, 7 - x, y, rgbColor)
                End If
            Next

        Next

        Return tempBitmap
    End Function



    Private Function GetSpriteLayer16(ByVal npattern As Integer, ByVal colorIndex As Byte) As Bitmap
        Dim tempBitmap As New Bitmap(16 * Me._viewSize, 16 * Me._viewSize)
        Dim tempValue As Byte = 0
        Dim patternVaddr As Short
        Dim colorVaddr As Short

        Dim rgbColor As Color

        patternVaddr = iVDP.TableBase.GRPPAT + (npattern * 8)
        colorVaddr = iVDP.TableBase.SC4SAC + (colorIndex * 16) 'for V9938 G3 graphic mode (SC4)

        For y As Integer = 0 To 15

            If Me._SpriteMode = SpriteMSX.SPRITE_MODE.COLOR Then
                colorIndex = VRAM(colorVaddr) And &HF 'Multicolor Sprites - V9938 G3 graphic mode (SC4)
                colorVaddr += 1
            End If

            rgbColor = Me.Palette.GetRGBColor(colorIndex)

            tempValue = VRAM(patternVaddr)
            For x As Integer = 0 To 7
                If (tempValue And Me.bite_MASKs(x)) = Me.bite_MASKs(x) Then
                    SetPoint(tempBitmap, 7 - x, y, rgbColor)
                End If
            Next


            tempValue = VRAM(patternVaddr + 16)
            patternVaddr += 1
            For x As Integer = 0 To 7
                If (tempValue And Me.bite_MASKs(x)) = Me.bite_MASKs(x) Then
                    SetPoint(tempBitmap, 15 - x, y, rgbColor)
                End If
            Next

        Next

        Return tempBitmap
    End Function




    Private Sub putTileT1(ByVal posX As Integer, ByVal posY As Integer, ByVal nTile As Byte)

        Dim tempBitmap As Bitmap

        posX = (posX * 6) * Me._viewSize
        posY = (posY * 8) * Me._viewSize

        Dim RowIndex As Integer = Fix(nTile / 32)
        Dim ColumnIndex As Integer = (nTile - (RowIndex * 32)) '* 8


        tempBitmap = getTile((ColumnIndex * 8), (RowIndex * 8), 6)

        Dim aGraphics As Graphics = Graphics.FromImage(Me.outputBitmap)
        aGraphics.DrawImage(tempBitmap, posX, posY, 6 * Me._viewSize, 8 * Me._viewSize)
        aGraphics.Flush()

    End Sub



    Private Sub putTileG1(ByVal posX As Integer, ByVal posY As Integer, ByVal nTile As Byte)

        Dim tempBitmap As Bitmap

        posX = (posX * 8) * Me._viewSize
        posY = (posY * 8) * Me._viewSize

        Dim RowIndex As Integer = Fix(nTile / 32)
        Dim ColumnIndex As Integer = (nTile - (RowIndex * 32)) '* 8

        'screen1
        tempBitmap = getTile((ColumnIndex * 8), (RowIndex * 8), 8)

        Dim aGraphics As Graphics = Graphics.FromImage(Me.outputBitmap)
        aGraphics.DrawImage(tempBitmap, posX, posY, 8 * Me._viewSize, 8 * Me._viewSize)
        aGraphics.Flush()

    End Sub



    Private Sub putTileG2(ByVal tilepos As Integer, ByVal nTile As Byte)

        Dim tempBitmap As Bitmap

        Dim posY As Integer = Fix(tilepos / 32)
        Dim posX As Integer = (tilepos - (posY * 32)) * 8
        posY = (posY * 8) * Me._viewSize
        posX = posX * Me._viewSize

        Dim RowIndex As Integer = Fix(nTile / 32)
        Dim ColumnIndex As Integer = (nTile - (RowIndex * 32)) '* 8


        'screen2
        Select Case tilepos
            Case 0 To 255
                'tempBitmap = Tile_Bank0(nTile)
                tempBitmap = getTile(ColumnIndex * 8, RowIndex * 8, 8)
            Case 256 To 511
                'tempBitmap = Tile_Bank1(nTile)
                tempBitmap = getTile(ColumnIndex * 8, (RowIndex + 8) * 8, 8)
            Case 512 To 767
                'tempBitmap = Tile_Bank2(nTile)
                tempBitmap = getTile(ColumnIndex * 8, (RowIndex + 16) * 8, 8)
            Case Else
                Exit Sub
        End Select

        Dim aGraphics As Graphics = Graphics.FromImage(Me.outputBitmap)
        aGraphics.DrawImage(tempBitmap, posX, posY, 8 * Me._viewSize, 8 * Me._viewSize)
        aGraphics.Flush()

    End Sub



    Private Sub drawTileSet()

        Dim color As Byte
        Dim VAdress As Integer

        Dim aGraphics As Graphics = Graphics.FromImage(Me.tilesetBitmap)
        aGraphics.Clear(Me.Palette.GetRGBColor(Me._borderColor))

        If _screenMode = iVDP.SCREEN_MODE.T1 Then
            ' screen1
            Dim Vpos As Integer = 0
            For VAdress = iVDP.TableBase.TXTCGP To iVDP.TableBase.TXTCGP + &H7FF
                color = (Me._inkColor * 16) + Me.BackgroundColor
                setScreenByte(Vpos, Me.VRAM(VAdress), color)
                Vpos += 1
            Next

        ElseIf _screenMode = iVDP.SCREEN_MODE.G1 Then
            ' screen1
            For VAdress = 0 To &H7FF
                color = VRAM(iVDP.TableBase.T32COL + Fix(Fix(VAdress / 8) / 8))
                setScreenByte(VAdress, Me.VRAM(VAdress), color)
            Next

        Else
            ' screen2
            For VAdress = 0 To &H17FF
                setScreenByte(VAdress, Me.VRAM(VAdress), Me.VRAM(VAdress + &H2000))
            Next

        End If

    End Sub



    Private Function getTile(ByVal cropX As Single, ByVal cropY As Single, ByVal hsize As Integer) As Bitmap
        ' ByRef bmp As Bitmap
        ' This function creates a cropped instance of the input bitmap, at coordiates and of the size specified.
        Dim rect As New Rectangle(cropX * Me._viewSize, cropY * Me._viewSize, hsize * Me._viewSize, 8 * Me._viewSize)
        Dim cropped As Bitmap = Me.tilesetBitmap.Clone(rect, Me.tilesetBitmap.PixelFormat) 'Me.tilesScreen.Image
        Return cropped
    End Function



    Public Function GetVRAM() As Byte()
        Return Me.VRAM.Clone
    End Function



    Public Sub SaveTilesetPNG(ByVal filePath As String)
        tilesetBitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Png)
    End Sub



    Public Sub SaveScreenPNG(ByVal filePath As String)

        Dim img As Image = New Bitmap(Me.Size.Width, Me.Size.Height)
        Dim aGraphics As Graphics = Graphics.FromImage(img)

        If Me.ViewMode = VIEW_MODE.SPRITE_LAYERS Then
            aGraphics.DrawImage(spritesLayerBitmap, 0, 0)

        Else
            aGraphics.DrawImage(outputBitmap, 0, 0)

            If Me.ViewMode = VIEW_MODE.ALL Then

                aGraphics.DrawImage(spritesLayerBitmap, 0, 0)

            End If
        End If


        img.Save(filePath, System.Drawing.Imaging.ImageFormat.Png)

        'outputBitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Png)
    End Sub



    Public Sub SaveSpritePatternsPNG(ByVal filePath As String)
        spritePatternsBitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Png)
    End Sub



    ''' <summary>
    ''' Align the colors of the three banks of tilesets in G2 (screen2) mode to improve the compression ratio of RLE-type compressors. It affects the pattern and color tables.
    ''' </summary>
    ''' <remarks></remarks>
    Public Function Optimize() As Integer

        Dim modifiedValues As Integer = 0

        Dim patternBase As Short = iVDP.TableBase.GRPCGP  '0    BASE(screen2.NumberOfBase.Pattern_Generator_Base_Address)
        Dim colorBase As Short = iVDP.TableBase.GRPCOL    '8192 BASE(screen2.NumberOfBase.Color_Table_Base_Address)

        Dim colvalue As Byte
        Dim gfxvalue As Byte

        Dim control_color As Byte
        Dim control_colorInk As Byte
        Dim control_colorBG As Byte
        Dim colorInk As Byte
        Dim colorBG As Byte

        'color byte -> F0h = F -> inkcolor ; 0 -> BGcolor
        control_color = VRAM(colorBase)
        control_colorInk = (control_color And &HF0) / 16
        control_colorBG = control_color And &HF

        For i = 1 To 6143
            colvalue = VRAM(colorBase + i)
            gfxvalue = VRAM(patternBase + i)

            colorInk = (colvalue And &HF0) / 16
            colorBG = colvalue And &HF

            ' (1) if the colors are the same but are inverted with respect to the control color..
            If colorInk = control_colorBG And colorBG = control_colorInk And Not colorInk = colorBG Then '
                'If Not colorInk = colorBG Then
                colvalue = control_color
                gfxvalue = Not gfxvalue 'invert the value of the pattern
                modifiedValues += 1
            Else

                If gfxvalue = 0 Then
                    ' (2) if the pattern is 0 and the background matches one of the control colors
                    If colorBG = control_colorBG Then
                        If Not colvalue = control_color Then
                            modifiedValues += 1
                        End If
                        colvalue = control_color
                    ElseIf colorBG = control_colorInk Then
                        colvalue = control_color
                        gfxvalue = Not gfxvalue
                        modifiedValues += 1
                    End If
                ElseIf gfxvalue = 255 Then
                    ' (3) if the pattern is 255 and the ink color matches one of the control colors
                    If colorInk = control_colorInk Then
                        If Not colvalue = control_color Then
                            modifiedValues += 1
                        End If
                        colvalue = control_color
                    ElseIf colorInk = control_colorBG Then
                        colvalue = control_color
                        gfxvalue = Not gfxvalue
                        modifiedValues += 1
                    End If
                End If
            End If

            VRAM(colorBase + i) = colvalue
            VRAM(patternBase + i) = gfxvalue

            control_color = colvalue
            control_colorInk = (control_color And &HF0) / 16
            control_colorBG = control_color And &HF
        Next

        Return modifiedValues

    End Function










    ' eventos ###################################################################################################



    Private Sub TMS9918_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown, spritesLayerPictureBox.MouseDown, tilesetPictureBox.MouseDown

        Dim x As Integer
        Dim y As Integer

        If Me._controlType = CONTROL_TYPE.SELECTER Then
            If _viewMode = VIEW_MODE.MAP Or _viewMode = VIEW_MODE.ALL Or _viewMode = VIEW_MODE.TILESET Then

                x = Fix((e.X) / Me._tileWidth)
                y = Fix((e.Y) / Me._tileHeight)

                Me.Refresh()

                If (e.Button = MouseButtons.Left) Then
                    Me.isDrag = True
                    Me.start_posX = x
                    Me.start_posY = y

                    ' Calculate the startPoint by using the PointToScreen 
                    ' method.
                    Dim acontrol As Control = CType(sender, Control)
                    Me.startPoint = acontrol.PointToScreen(New Point(x * Me._tileWidth, y * Me._tileHeight))

                End If

            End If


        ElseIf Me._controlType = CONTROL_TYPE.SPRITEOAM Then

            If (e.Button = MouseButtons.Left) Then

                Cursor.Hide()

                isDrag = True

                x = Fix((e.X) / Me._viewSize)
                y = Fix((e.Y) / Me._viewSize)

                If x > 255 Then
                    x = 255
                ElseIf x < 0 Then
                    x = 0
                End If

                If y > 191 Then
                    y = 191
                End If

                ' line 0 is 255 value in TMS9918, V9938 and V9958
                If y < 1 Then
                    y = 255
                Else
                    y -= 1
                End If

                RaiseEvent MouseScreenPress(x, y)

            End If

        End If


    End Sub



    Private Sub TMS9918_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove, spritesLayerPictureBox.MouseMove, tilesetPictureBox.MouseMove, spritePatternsPictureBox.MouseMove
        Dim x As Integer
        Dim y As Integer

        x = Fix((e.X) / Me._viewSize)
        y = Fix((e.Y) / Me._viewSize)

        If x > 255 Then
            x = 255
        ElseIf x < 0 Then
            x = 0
        End If

        If y > 191 Then
            y = 191
        ElseIf y < 0 Then
            y = 0
        End If

        RaiseEvent MouseScreenData(x, y)


        If Me._controlType = CONTROL_TYPE.SELECTER Then
            If _viewMode = VIEW_MODE.MAP Or _viewMode = VIEW_MODE.ALL Or _viewMode = VIEW_MODE.TILESET Then

                If Me.isDrag = True Then
                    'Me.Refresh()

                    end_posX = CInt(x / 8)
                    end_posY = CInt(y / 8) 'Fix


                    If end_posX > Me._columns Then
                        end_posX = Me._columns
                    End If

                    If end_posY > 24 Then
                        end_posY = 24
                    End If


                    ' Hide the previous rectangle by calling the DrawReversibleFrame 
                    ' method with the same parameters.
                    ControlPaint.DrawReversibleFrame(theRectangle, Color.DarkRed, FrameStyle.Thick)

                    ' Calculate the endpoint and dimensions for the new rectangle, 
                    ' again using the PointToScreen method.
                    Dim endPoint As Point = CType(sender, Control).PointToScreen(New Point(end_posX * Me._tileWidth, end_posY * Me._tileHeight))
                    Dim areaWidth As Integer = endPoint.X - startPoint.X
                    Dim areaHeight As Integer = endPoint.Y - startPoint.Y
                    theRectangle = New Rectangle(startPoint.X, startPoint.Y, areaWidth, areaHeight)

                    ' Draw the new rectangle by calling DrawReversibleFrame again.  
                    ControlPaint.DrawReversibleFrame(theRectangle, Color.DarkRed, FrameStyle.Thick)

                End If

            End If

        ElseIf Me._controlType = CONTROL_TYPE.SPRITEOAM Then

            If Me.isDrag = True Then

                'If y = 0 Then
                '    y = 255
                'Else
                '    y -= 1
                'End If
                RaiseEvent MouseScreenPress(x, y)

                'ControlPaint.DrawReversibleFrame(theRectangle, Color.DarkRed, FrameStyle.Thick)

                '' Calculate the endpoint and dimensions for the new rectangle, 
                '' again using the PointToScreen method.
                'Dim endPoint As Point = CType(sender, Control).PointToScreen(New Point(x * Me.ViewSize, y * Me.ViewSize))
                'Dim squaredSize As Integer = 16 * Me.ViewSize
                'theRectangle = New Rectangle(endPoint.X, endPoint.Y, squaredSize, squaredSize)

                '' Draw the new rectangle by calling DrawReversibleFrame again.  
                'ControlPaint.DrawReversibleFrame(theRectangle, Color.DarkRed, FrameStyle.Thick)
            End If

        End If

    End Sub



    Private Sub TMS9918_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp, spritesLayerPictureBox.MouseUp, tilesetPictureBox.MouseUp

        Dim x As Integer
        Dim y As Integer

        x = Fix((e.X) / Me._viewSize)
        y = Fix((e.Y) / Me._viewSize)

        If x > 255 Then
            x = 255
        ElseIf x < 0 Then
            x = 0
        End If

        If y > 191 Then
            y = 191
        ElseIf y < 0 Then
            y = 0
        End If


        isDrag = False
        'Me.Cursor = Cursors.Default

        If Not Me._controlType = CONTROL_TYPE.VIEWER Then
            If _viewMode = VIEW_MODE.MAP Or _viewMode = VIEW_MODE.ALL Or _viewMode = VIEW_MODE.TILESET Then
                RaiseEvent MouseSelectedArea(start_posX, start_posY, end_posX - 1, end_posY - 1)

                'ControlPaint.DrawReversibleFrame(theRectangle, Color.DarkRed, FrameStyle.Thick)

                'Reset the rectangle.
                theRectangle = New Rectangle(0, 0, 0, 0)
            End If
            'If Me._controlType = CONTROL_TYPE.SPRITEOAM Then
            '    Cursor.Show()

            '    'Me.Cursor = Me.Cursor_Draw
            '    'ControlPaint.DrawReversibleFrame(theRectangle, Color.DarkRed, FrameStyle.Thick)
            '    'Me.Refresh()
            'End If
        End If

        If Me._controlType = CONTROL_TYPE.SPRITEOAM Then
            'If y = 0 Then
            '    y = 255
            'Else
            '    y -= 1
            'End If
            Cursor.Show()
            RaiseEvent MouseScreenDown(x, y)
        End If

    End Sub



    'Private Sub TMS9918A_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove, tilesetPictureBox.MouseMove, spritePatternsPictureBox.MouseMove

    '    Dim x As Integer
    '    Dim y As Integer

    '    x = Fix((e.X) / Me._viewSize)
    '    y = Fix((e.Y) / Me._viewSize)

    '    If x > 255 Then
    '        x = 255
    '    ElseIf x < 0 Then
    '        x = 0
    '    End If

    '    If y > 191 Then
    '        y = 191
    '    ElseIf y < 0 Then
    '        y = 0
    '    End If

    '    RaiseEvent MouseScreenData(x, y)

    'End Sub






    ' END eventos ###################################################################################################





End Class
