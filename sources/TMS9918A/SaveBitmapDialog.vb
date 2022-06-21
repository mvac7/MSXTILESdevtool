Imports System.IO


Public Class SaveBitmapDialog

    Private AppConfig As Config
    Private Palette As iPaletteMSX

    Private ProjectName As String = ""
    'Private def_WorkPath As String = ""
    Private filePath As String = ""

    Private multiview As Boolean = True

    Public ScreenMode As iVDP.SCREEN_MODE = iVDP.SCREEN_MODE.G2
    Public SpriteSize As SpriteMSX.SPRITE_SIZE = SpriteMSX.SPRITE_SIZE.SIZE16
    Public SpriteZoom As iVDP.SPRITE_ZOOM = iVDP.SPRITE_ZOOM.X1
    Public InkColor As Byte
    Public BackgroundColor As Byte
    Public BorderColor As Byte
    'Public SpriteZoom As SpriteMSX.SPRITE_MODE


    Public Sub New(ByVal _config As Config, ByVal name As String, ByVal _vram() As Byte, ByVal _Palette As iPaletteMSX, ByVal _multiview As Boolean)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.Palette = _Palette

        Me.TMS9918Aviewer.SetBlock(0, _vram)

        Me.AppConfig = _config

        Me.ProjectName = name

        Me.multiview = _multiview

    End Sub



    Private Sub SaveBitmapForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.TMS9918Aviewer.Palette = Me.Palette
        Me.TMS9918Aviewer.ScreenMode = Me.ScreenMode
        Me.TMS9918Aviewer.SpriteSize = Me.SpriteSize
        Me.TMS9918Aviewer.SpriteZoom = Me.SpriteZoom
        Me.TMS9918Aviewer.InkColor = Me.InkColor
        Me.TMS9918Aviewer.BackgroundColor = Me.BackgroundColor
        Me.TMS9918Aviewer.BorderColor = Me.BorderColor
        'Me.TMS9918Aviewer.ViewMode = TMS9918A.VIEW_MODE.TILESET

        Me.NameTextBox.Text = Me.ProjectName

        Me.TMS9918Aviewer.RefreshScreen()

        If Me.multiview = True Then

            Me.ViewModeComboBox.SelectedIndex = 0

        Else

            Me.ViewLabel.Visible = False
            Me.ViewModeComboBox.Visible = False
            Me.TMS9918Aviewer.SetView(TMS9918A.VIEW_MODE.TILESET)

        End If

    End Sub



    Private Function GetFilePath() As String

        Dim suffix As String = ""

        If Me.multiview = True Then
            Select Case Me.ViewModeComboBox.SelectedIndex
                Case 1
                    suffix = "_map"
                Case 2
                    suffix = "_tset"
                Case 3
                    suffix = "_spriteLayers"
                Case 4
                    suffix = "_spritePatterns"
            End Select
        End If

        Me.SaveFileDialog1.DefaultExt = "png"
        Me.SaveFileDialog1.Filter = "PNG file|*.png"

        Me.SaveFileDialog1.FileName = Me.ProjectName + suffix

        'If Me.filePath = "" Then
        Me.SaveFileDialog1.InitialDirectory = Me.AppConfig.PathItemBitmap.Path
        'Else
        '    Me.SaveFileDialog1.InitialDirectory = Path.GetDirectoryName(Me.filePath)
        'End If

        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Me.AppConfig.PathItemBitmap.UpdateLastPath(Path.GetDirectoryName(SaveFileDialog1.FileName))

            Return SaveFileDialog1.FileName

        Else

            Return ""

        End If
    End Function



    Private Sub Save_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save_Button.Click

        Me.filePath = GetFilePath()

        If Not Me.filePath = "" Then
            '    MsgBox("Select a file path before.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Alert")
            'Else
            SavePNG()
            Me.Close()
        End If

    End Sub



    Private Sub SavePNG()
        If Me.TMS9918Aviewer.ViewMode = TMS9918A.VIEW_MODE.TILESET Then
            Me.TMS9918Aviewer.SaveTilesetPNG(filePath)
        ElseIf Me.TMS9918Aviewer.ViewMode = TMS9918A.VIEW_MODE.SPRITE_PATTERNS Then
            Me.TMS9918Aviewer.SaveSpritePatternsPNG(filePath)
        Else
            Me.TMS9918Aviewer.SaveScreenPNG(filePath)
        End If
    End Sub



    Private Sub ViewModeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewModeComboBox.SelectedIndexChanged
        Me.TMS9918Aviewer.SetView(Me.ViewModeComboBox.SelectedIndex)
    End Sub


End Class