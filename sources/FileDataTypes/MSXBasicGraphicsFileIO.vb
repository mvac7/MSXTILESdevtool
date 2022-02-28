Imports System.IO


Public Class MSXBasicGraphicsFileIO

    ' file extensions
    'Public Shadows Const ALLSCREEN_EXT As String = "sc2"
    'Public Shadows Const SPRITEPATTERNS_EXT As String = "spr"
    Public Shadows Const SPRITECOLORS_EXT As String = "spc"
    Public Shadows Const SPRITEOAM_EXT As String = "oam"

    Public Shadows Const Extension_MSXBASICscreen As String = "SC*"
    Public Shadows Const Extension_MSXBASICscreen0 As String = "SC0"
    Public Shadows Const Extension_MSXBASICscreen1 As String = "SC1"
    Public Shadows Const Extension_MSXBASICscreen4 As String = "SC4"
    Public Shadows Const Extension_MSXBASICscreen2 As String = "SC2"
    Public Shadows Const Extension_MSXBASICsprites As String = "SPR"


    Public ScreenMode As iVDP.SCREEN_MODE = iVDP.SCREEN_MODE.G2
    Public SpriteSize As iVDP.SPRITE_SIZE = iVDP.SPRITE_SIZE.SIZE16

    Public VRAMaddress As Short



    ' Unused areas of VRAM where you can save metadata ------------

    ' screen 0
    Private Const S0_Empty01 = &H3C0  ' size = &H480 (1088 Bytes)

    ' screen 1 and 2
    Private Const S12_Empty01 = &H1B80  ' size = &H440 (1152 Bytes)

    ' screen 4
    Private Const S4_Empty01 = &H1B00  ' size = &H80 (128 Bytes)
    Private Const S4_Empty02 = &H1BA0  ' size = &H60 (96 Bytes)
    Private Const S4_Empty03 = &H1E80  ' size = &H180 (384 Bytes)
    ' --------------------------------------------------------------

    'Class ProjectInfo

    '    Public Name As String        ' (128 Bytes)
    '    Public Version As String     ' ( 84 Bytes)
    '    Public Group As String       ' ( 48 Bytes)
    '    Public Author As String      ' ( 48 Bytes)
    '    Public Description As String ' (300 Bytes)
    '    Public StartDate As Long
    '    Public LastUpdate As Long





    Public Function IsMSXBASICfile(ByVal filePath As String) As Boolean

        Dim aFileData(1) As Byte
        Dim aStream As New System.IO.FileStream(filePath, FileMode.Open)
        aStream.Read(aFileData, 0, 1)
        aStream.Close()

        If aFileData(0) = &HFE Then
            Return True
        End If

        Return False

    End Function



    ''' <summary>
    ''' Load a MSX binary file. VRAM data dump (SC2)
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function BLOAD(ByVal filePath As String) As Byte()

        Dim dataBloq() As Byte  'New ArrayList()

        Dim aStream As New System.IO.FileStream(filePath, FileMode.Open)
        Dim aFile As New System.IO.FileInfo(filePath)
        'Dim ROMdata() As Byte
        Dim aFileData() As Byte

        Dim tmpScreenMode As Byte
        Dim tmpSpriteSize As Byte

        Dim dataPosition As Integer = 7

        Dim tamanyo As Integer = CInt(aFile.Length)
        aFileData = Nothing
        ReDim aFileData(tamanyo)
        ReDim dataBloq(tamanyo - 8)
        aStream.Read(aFileData, 0, tamanyo)
        aStream.Close()


        '
        ' recoger datos del bin:
        ' direccion de inicio
        ' direccion de fin
        ' escribir en el buffer aScreen2

        ' <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        ' cabecera del fichero binario para memoria de video, zona de nombre de patrones.
        'aFileData(0) = &HFE identificador MSX BASIC binary
        'aFileData(1) = &H0  init_addr
        'aFileData(2) = &H0
        'aFileData(3) = &HFF end_addr
        'aFileData(4) = &H3F
        'aFileData(5) = &H0  exec_addr - no se usa
        'aFileData(6) = &H0            - no se usa

        If aFileData(0) = &HFE Then

            Me.VRAMaddress = ((aFileData(2) And 63) * 256) + aFileData(1)
            'Dim dirend As Integer = ((aFileData(4) And 63) * 256) + aFileData(3)

            ' -------------------------------------------------------------------
            ' utiliza los bytes 5 y 6 de la cabecera para info de la pantalla como modo y tamaño de sprites 
            tmpScreenMode = aFileData(5) ' 0 = default; 1 = Screen0; 2 = screen1; 3 = screen2; 4 = screen3; 5 = screen4
            tmpSpriteSize = aFileData(6) ' 1 = 8x8, 2= 16x16 (idea: bit7 for sprite zoom?) 

            If tmpScreenMode = 0 Or tmpScreenMode > 5 Then
                Me.ScreenMode = iVDP.SCREEN_MODE.G2  'default value
            Else
                Me.ScreenMode = tmpScreenMode - 1
            End If

            If tmpSpriteSize = 0 Or tmpSpriteSize > 2 Then
                Me.SpriteSize = SpriteMSX.SPRITE_SIZE.SIZE16  'default value
            Else
                Me.SpriteSize = tmpSpriteSize
            End If
            ' -------------------------------------------------------------------


            'dataBloq.  'CopyTo(fileData, 7)

            Array.ConstrainedCopy(aFileData, 7, dataBloq, 0, tamanyo - 7)

            'For i = address To dirend
            '    dataBloq.add(aFileData(dataPosition))
            '    dataPosition += 1
            'Next

            'If Not Me._palette.VDPtype = PaletteMSX.MSXVDP.TMS9918 Then
            '    SetVRAMPalette() ' for V9938
            'End If

            'RefreshScreen()

            Return dataBloq  'dataBloq.ToArray(GetType(Byte))

        Else
            'The file type is not SC2
            Return Nothing
        End If

    End Function




    'Public Function BSAVE(ByVal filePath As String, ByVal initVRAMAddr As Short, ByRef dataBloq As Byte()) As Boolean  'ByVal endAddr As Short,

    '    Return BSAVE(filePath, initVRAMAddr, dataBloq, 0, 0)

    'End Function





    ''' <summary>
    ''' Save MSX Basic Graphics
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <param name="initVRAMAddr"></param>
    ''' <param name="dataBloq"></param>
    ''' <param name="_screenMode"></param>
    ''' <param name="_spriteSize"></param>
    ''' <returns></returns>
    Public Function BSAVE(ByVal filePath As String, ByVal initVRAMAddr As Short, ByRef dataBloq As Byte(), ByVal _screenMode As iVDP.SCREEN_MODE, ByVal _spriteSize As iVDP.SPRITE_SIZE) As Boolean  'ByVal endAddr As Short,

        'Try

        Dim fileData As Byte()
        'Dim dataLength As Short
        Dim endAddr As Short = initVRAMAddr + (dataBloq.Length)

        Me.VRAMaddress = initVRAMAddr


        ' realizar comprobaciones
        If filePath = "" Then
            Return False
        End If
        If initVRAMAddr > endAddr Then
            Return False
        End If

        'dataLength = endAddr - initAddr

        ReDim fileData(dataBloq.Length + 7)


        ' MSX Basic Graphics header
        fileData(0) = &HFE 'code for graphics 
        fileData(1) = CByte(initVRAMAddr And &HFF)
        fileData(2) = CByte((initVRAMAddr And &HFF00) / &HFF)
        fileData(3) = CByte(endAddr And &HFF)
        fileData(4) = CByte((endAddr And &HFF00) / &HFF)



        'we use two bytes of the header, which are not used, to save the screen mode info
        fileData(5) = _screenMode + 1 ' 0 = default; 1 = Screen0; 2 = screen1; 3 = screen2; 4 = screen3; 5 = screen4
        ' 0 Is the value that we will find in a file that does not use this value (for example when when it is saved from the MSX BASIC).

        fileData(6) = _spriteSize     ' 1 = 8x8, 2= 16x16 (idea: bit7 for sprite zoom?) 
        ' end


        dataBloq.CopyTo(fileData, 7)

        'For i As Integer = 0 To dataBloq.Length - 1
        '    fileData(i + 7) = dataBloq(i)
        '    vaddr += 1
        'Next

        'crea el fichero
        Dim aStream As New System.IO.FileStream(filePath, IO.FileMode.Create)
        aStream.Write(fileData, 0, fileData.Length - 1)
        aStream.Close()

        'Catch ex As Exception

        'End Try

        Return True

    End Function



End Class
