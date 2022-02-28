Public Class ScreenMSX

    Public ID As Integer

    Private _name As String = "screen"

    Public ScreenMode As iVDP.SCREEN_MODE = iVDP.SCREEN_MODE.G2
    Public SpriteSize As SpriteMSX.SPRITE_SIZE = SpriteMSX.SPRITE_SIZE.SIZE16
    Public SpriteZoom As iVDP.SPRITE_ZOOM = iVDP.SPRITE_ZOOM.X1

    Public Info As ProjectInfo


    Public InkColor As Byte = 15
    Public BackgroundColor As Byte = 4
    Public BorderColor As Byte = 4

    Public MapID As Integer = 0

    Public OAMID As Integer = 0

    Public SpritesetID As Integer = 0

    Public PaletteID As Integer = 0
    'Public PaletteType As TMS9918A.MSXVDP = TMS9918A.MSXVDP.TMS9918  '<<<--------------------------------- ??? DEPRECATED

    Public TilesetA As Integer = 0
    Public TilesetB As Integer = 0
    Public TilesetC As Integer = 0


    Public Property Name As String
        Get
            Return Me._name
        End Get
        Set(value As String)
            Me._name = value
            If Not Me.Info Is Nothing Then
                Me.Info.Name = value
            End If
        End Set
    End Property



    Public Sub New()
        Me.ID = Me.GetHashCode() + CInt(Rnd() * 100000)
    End Sub



    Public Sub New(ByVal _name As String, ByVal _screenMode As iVDP.SCREEN_MODE, ByVal _spriteSize As SpriteMSX.SPRITE_SIZE, ByVal _mapID As Integer, ByVal tileset_ID As Integer, ByVal tilesetB_ID As Integer, ByVal tilesetC_ID As Integer, ByVal _spritesetID As Integer, ByVal _oamID As Integer, ByVal _paletteID As Integer)
        Me.Name = _name
        Me.ScreenMode = _screenMode
        Me.SpriteSize = _spriteSize

        Me.MapID = _mapID
        Me.SpritesetID = _spritesetID
        Me.OAMID = _oamID
        Me.PaletteID = _paletteID

        Me.TilesetA = tileset_ID
        Me.TilesetB = tilesetB_ID
        Me.TilesetC = tilesetC_ID

        Me.ID = Me.GetHashCode() + CInt(Rnd() * 100000)
    End Sub



    Public Function Clone() As ScreenMSX
        Dim newScreen As New ScreenMSX

        newScreen.Name = Me.Name
        newScreen.ScreenMode = Me.ScreenMode
        newScreen.SpriteSize = Me.SpriteSize
        newScreen.SpriteZoom = Me.SpriteZoom

        newScreen.InkColor = Me.InkColor
        newScreen.BackgroundColor = Me.BackgroundColor
        newScreen.BorderColor = Me.BorderColor
        newScreen.MapID = Me.MapID
        newScreen.SpritesetID = Me.SpritesetID
        newScreen.OAMID = Me.OAMID
        newScreen.PaletteID = Me.PaletteID
        'newScreen.ID = newScreen.GetHashCode()

        newScreen.TilesetA = Me.TilesetA
        newScreen.TilesetB = Me.TilesetB
        newScreen.TilesetC = Me.TilesetC

        If Not Me.Info Is Nothing Then
            newScreen.Info = Me.Info.Clone
        End If

        Return newScreen
    End Function


    Public Function Copy() As ScreenMSX

        Dim newScreen As ScreenMSX

        newScreen = Me.Clone
        newScreen.ID = Me.ID

        Return newScreen
    End Function


End Class
