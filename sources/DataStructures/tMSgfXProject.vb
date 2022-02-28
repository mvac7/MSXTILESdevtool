Imports System.Xml



Public Class tMSgfXProject

    Public Info As ProjectInfo

    Public Tilesets As TilesetProject
    Public SupertileSets As SupertilesProject
    Public Maps As MapProject
    Public OAMs As OAMProject
    Public Palettes As PaletteProject
    'Public Pictures As PictureProject
    Public Screens As ScreenProject
    Public SpriteSets As SpriteProject


    Public Path As String



    Public Sub New()
        Me.Info = New ProjectInfo
        Me.Palettes = New PaletteProject
    End Sub



    Public Sub NewProject()
        Me.Path = ""
        Me.Info.Clear()

        Me.Tilesets = Nothing
        Me.SupertileSets = Nothing
        Me.Maps = Nothing
        Me.SpriteSets = Nothing
        Me.OAMs = Nothing
        Me.Screens = Nothing
        'Me.Pictures = Nothing

        Me.Palettes.Clear()  '= New PaletteProject
    End Sub



    Public Sub Clear()

        Me.Path = ""

        Me.Info.Clear()

        If Not Me.Maps Is Nothing Then
            Me.Maps.Clear()
        End If

        If Not Me.Tilesets Is Nothing Then
            Me.Tilesets.Clear()
        End If

        If Not Me.SupertileSets Is Nothing Then
            Me.SupertileSets.Clear()
        End If

        If Not Me.OAMs Is Nothing Then
            Me.OAMs.Clear()
        End If

        If Not Me.SpriteSets Is Nothing Then
            Me.SpriteSets.Clear()
        End If

        If Not Me.Screens Is Nothing Then
            Me.Screens.Clear()
        End If

        'If Not Me.Pictures Is Nothing Then
        '    Me.Pictures.Clear()
        'End If

        Me.Palettes.Clear()

    End Sub



End Class
