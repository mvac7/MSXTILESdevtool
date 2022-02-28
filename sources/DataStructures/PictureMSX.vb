Public Class PictureMSX

    Public Shadows Enum GMODE As Byte
        BRUSH
        G1
        G2
        MC
        G3
    End Enum

    Public ID As Integer

    Public Info As ProjectInfo

    Public GraphicMode As GMODE
    Public Width As Short = 256
    Public DataWidth As Short
    Public Height As Short = 192

    Public InkColor As Byte = 15
    Public BGColor As Byte = 4

    Public PatternDataLines As New SortedList()
    'Public ColorDataLines As New SortedList()

    'Public Palette As iPaletteMSX

    Public PaletteID As Integer

    Public Path As String

    Public TilesetA_ID As Integer = -1
    Public TilesetB_ID As Integer = -1
    Public TilesetC_ID As Integer = -1


    Private Const V9938PAL = &H1B80   '&H1B80 VRAM adress for palette for screen2 (Only used by MSX Basic)
    Private Const GRPCOL = &H2000  ' 11 Color_Table_Base_Address
    Private Const GRPCGP = 0       ' 12 Pattern_Generator_Base_Address





    Public Sub New()
        'Me.ID = Me.GetHashCode() 'genera un identificador unico

        'Me.Info = New ProjectInfo
        'Me.Info.Name = "NewPicture"

        'Me.PaletteID = 0

    End Sub



    Public Sub New(ByVal _graphicMode As GMODE, ByVal _InkColor As Byte, ByVal _BGColor As Byte)
        Me.ID = Me.GetHashCode() + CInt(Rnd() * 100000) 'genera un identificador unico

        Me.Info = New ProjectInfo
        Me.Info.Name = "NewPicture"

        Me.PaletteID = 0

        Me.GraphicMode = _graphicMode
        Me.Width = 256
        Me.Height = 192

        If _graphicMode > GMODE.G3 Then
            Me.DataWidth = Me.Width
        Else
            Me.DataWidth = Fix(Me.Width / 8)
        End If

        Me.InkColor = _InkColor
        Me.BGColor = _BGColor

        Clear()
    End Sub



    Public Sub New(ByVal _graphicMode As GMODE, ByVal _width As Short, ByVal _height As Short, ByVal _InkColor As Byte, ByVal _BGColor As Byte)
        Me.ID = Me.GetHashCode() + CInt(Rnd() * 100000) 'genera un identificador unico

        Me.Info = New ProjectInfo
        Me.Info.Name = "NewPicture"

        Me.PaletteID = 0

        Me.GraphicMode = _graphicMode
        Me.Width = _width
        Me.Height = _height

        If _graphicMode > GMODE.G3 Then
            Me.DataWidth = Me.Width
        Else
            Me.DataWidth = Fix(Me.Width / 8)
        End If

        Me.InkColor = _InkColor
        Me.BGColor = _BGColor

        Clear()
    End Sub



    ''' <summary>
    ''' New Brush
    ''' </summary>
    ''' <param name="_width"></param>
    ''' <param name="_height"></param>
    Public Sub New(ByVal _width As Short, ByVal _height As Short)
        Me.ID = Me.GetHashCode() + CInt(Rnd() * 100000) 'genera un identificador unico

        Me.Info = New ProjectInfo
        Me.Info.Name = "NewPicture"

        Me.PaletteID = 0

        Me.GraphicMode = GMODE.BRUSH
        Me.Width = _width * 8
        Me.DataWidth = _width  'Fix(Me.Width / 8)
        Me.Height = _height
        Me.InkColor = 0
        Me.BGColor = 0
        InitData()
    End Sub



    Public Sub Clear()

        Me.Info.Clear()
        Me.Info.Name = "NewPicture"

        Me.PaletteID = 0

        'Me.GraphicMode = GMODE.G2

        'Me.Width = 256
        'Me.Height = 192

        'Me.InkColor = 15
        'Me.BGColor = 4

        InitData()

    End Sub



    Private Sub InitData()

        Dim lineData() As GFXbyte
        'Dim lineColor() As Byte

        'Dim newColor As Byte = (Me.InkColor * 16) + Me.BGColor

        Me.PatternDataLines.Clear()
        'Me.ColorDataLines.Clear()

        ReDim lineData(Me.DataWidth - 1)
        'ReDim lineColor(Me.DataWidth - 1)

        For lineIndex As Short = 0 To Me.Height - 1
            For i = 0 To Me.DataWidth - 1
                lineData(i) = New GFXbyte(0, Me.InkColor, Me.BGColor)
                'lineColor(i) = newColor
            Next
            Me.PatternDataLines.Add(lineIndex, lineData.Clone)
            'Me.ColorDataLines.Add(lineIndex, lineColor.Clone)
        Next

    End Sub



    Public Function Clone() As PictureMSX

        Dim tmpPictureData As PictureMSX
        tmpPictureData = Copy()
        tmpPictureData.ID = Me.GetHashCode() + CInt(Rnd() * 100000) 'genera un identificador unico

        Return tmpPictureData

    End Function



    Public Function Copy() As PictureMSX

        Dim tmpPictureData As New PictureMSX

        Dim lineData(Me.DataWidth - 1) As GFXbyte

        tmpPictureData.ID = Me.ID

        tmpPictureData.Info = Me.Info.Clone

        tmpPictureData.GraphicMode = Me.GraphicMode
        tmpPictureData.Width = Me.Width
        tmpPictureData.DataWidth = Me.DataWidth
        tmpPictureData.Height = Me.Height

        tmpPictureData.InkColor = Me.InkColor
        tmpPictureData.BGColor = Me.BGColor

        tmpPictureData.PaletteID = Me.PaletteID

        tmpPictureData.TilesetA_ID = Me.TilesetA_ID
        tmpPictureData.TilesetB_ID = Me.TilesetB_ID
        tmpPictureData.TilesetC_ID = Me.TilesetC_ID

        For lineIndex As Short = 0 To Me.PatternDataLines.Count - 1
            For column As Short = 0 To Me.DataWidth - 1

                lineData(column) = Me.PatternDataLines.Item(lineIndex)(column).Clone

            Next

            tmpPictureData.PatternDataLines.Add(lineIndex, lineData.Clone)

        Next


        'For lineIndex As Short = 0 To Me.ColorDataLines.Count - 1
        '    tmpPictureData.ColorDataLines.Add(lineIndex, Me.ColorDataLines.Item(lineIndex).clone)
        'Next

        Return tmpPictureData

    End Function



    Public Function Length() As Integer
        Return Me.PatternDataLines.Count
    End Function



    'Public Sub SetPatternValue(ByVal column As Short, ByVal line As Short, ByVal value As Byte)
    '    If line > Me.PatternDataLines.Count Then
    '        Exit Sub
    '    End If
    '    If column > Me.DataWidth Then
    '        Exit Sub
    '    End If

    '    Me.PatternDataLines.Item(line)(column) = value
    'End Sub



    Public Sub SetValue(ByVal column As Short, ByVal line As Short, ByVal value As GFXbyte)
        If line > Me.PatternDataLines.Count Then
            Exit Sub
        End If
        If column > Me.DataWidth Then
            Exit Sub
        End If

        Me.PatternDataLines.Item(line)(column) = value
    End Sub



    Public Sub SetValue(ByVal column As Short, ByVal line As Short, ByVal patternValue As Byte, ByVal colorValue As Byte)
        If line > Me.PatternDataLines.Count Then
            Exit Sub
        End If
        If column > Me.DataWidth Then
            Exit Sub
        End If

        Me.PatternDataLines.Item(line)(column) = New GFXbyte(patternValue, colorValue)
    End Sub



    Public Function GetValue(ByVal column As Short, ByVal line As Short) As GFXbyte
        'Dim tmpData As GFXbyte

        If line > Me.PatternDataLines.Count Then
            Return Nothing
        End If
        If column > Me.DataWidth Then
            Return Nothing
        End If

        'Try
        Return Me.PatternDataLines.Item(line)(column)
        'Catch ex As Exception
        '    Return Nothing
        'End Try

    End Function



    Public Function GetBitmap(ByRef palette As iPaletteMSX) As Bitmap  'ByVal zoomScale As Byte
        'Dim tmpGraphics As Graphics
        Dim tmpBitmap As New Bitmap(Me.Width, Me.Height)
        Dim aColor As Byte
        Dim tmpValue As GFXbyte
        Dim posX As Short
        Dim posY As Short = 0
        Dim bite_MASKs = New Byte() {128, 64, 32, 16, 8, 4, 2, 1}

        'tmpGraphics = Graphics.FromImage(tmpBitmap)

        For lineIndex As Short = 0 To Me.PatternDataLines.Count - 1
            posX = 0
            For column As Short = 0 To Me.DataWidth - 1
                tmpValue = Me.PatternDataLines.Item(lineIndex)(column)
                For i As Byte = 0 To 7
                    If (tmpValue.Pattern And bite_MASKs(i)) = bite_MASKs(i) Then
                        aColor = tmpValue.InkColor
                    Else
                        aColor = tmpValue.BGColor
                    End If
                    tmpBitmap.SetPixel(posX, posY, palette.GetRGBColor(aColor))
                    'tmpGraphics.FillRectangle(New SolidBrush(palette.GetRGBColor(aColor)), posX * zoomScale, posY * zoomScale, zoomScale, zoomScale)
                    posX += 1
                Next
            Next
            posY += 1
        Next

        Return tmpBitmap

    End Function




End Class
