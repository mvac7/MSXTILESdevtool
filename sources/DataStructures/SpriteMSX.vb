Public Class SpriteMSX

    Public Index As Integer
    Public Name As String
    Public patternData As Byte()

    Public ColorData As Byte()         'Bits 0-3   color value
    Public ICData As Boolean()         'Bit 5      IC  Ignore collisions with other sprites. (1=Ignore)
    Public ORbitData As Boolean()      'Bit 6      CC  Mix color with sprite that has next higher priority.
    Public EarlyClockData As Boolean() 'Bit 7      EC  Early clock (shift this line of the sprite 32 pixels to left)

    Public InkColor As Byte = 15
    Public BackgroundColor As Byte = 0


    Private _size As SPRITE_SIZE ' 1 = 8x8,  2 = 16x16
    Private _mode As SPRITE_MODE ' 1 = mono, 2 = color (MSX2)

    Private _Palette As iPaletteMSX

    'Private aBitmap As Bitmap
    Private aBitmapX2 As Bitmap

    'Private bite_MASKs = New Byte() {1, 2, 4, 8, 16, 32, 64, 128}





    Public Property Size() As SPRITE_SIZE
        Get
            Return Me._size
        End Get
        Set(ByVal value As SPRITE_SIZE)
            Me._size = value
        End Set
    End Property



    Public Property Mode() As SPRITE_MODE
        Get
            Return Me._mode
        End Get
        Set(ByVal value As SPRITE_MODE)
            If Me._mode = SPRITE_MODE.MONO And value = SPRITE_MODE.COLOR Then
                Me._mode = value
                SetDefaultColors()
            ElseIf Me._mode = SPRITE_MODE.COLOR And value = SPRITE_MODE.MONO Then
                Me._mode = value
                Refresh()
            Else
                Me._mode = value
            End If
        End Set
    End Property



    Public WriteOnly Property Palette() As iPaletteMSX
        Set(ByVal value As iPaletteMSX)
            Me._Palette = value
        End Set
    End Property



    Public Shadows Enum SPRITE_SIZE As Integer
        SIZE8 = 1
        SIZE16 = 2
    End Enum



    Public Shadows Enum SPRITE_MODE As Integer
        MONO = 1
        COLOR = 2
    End Enum




    Public Sub New()

    End Sub



    Public Function GetBitmapX1() As Bitmap

        If Me._size = SPRITE_SIZE.SIZE8 Then
            Return getBitmap8()
        Else
            Return getBitmap16()
        End If

    End Function




    Public Function GetBitmapX2() As Bitmap
        Return Me.aBitmapX2.Clone
    End Function






    Public Sub New(ByVal _index As Integer, ByVal _name As String, ByVal _size As SpriteMSX.SPRITE_SIZE, ByVal _mode As SPRITE_MODE, ByVal _inkColor As Integer, ByVal _bgColor As Integer, ByVal _paletteData As iPaletteMSX)

        Me.Index = _index
        Me.Name = _name
        Me.size = _size
        Me._mode = _mode

        Me._Palette = _paletteData
        Me.InkColor = _inkColor
        Me.BackgroundColor = _bgColor

        setDefault()

        Me.refresh()

    End Sub








    ''' <summary>
    ''' for mode 1 MSX1 without bitmap
    ''' </summary>
    ''' <param name="_name"></param>
    ''' <param name="_size"></param>
    ''' <param name="_inkColor"></param>
    ''' <param name="_bgColor"></param>
    ''' <param name="_gfx"></param>
    ''' <param name="_paletteData"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _index As Integer, ByVal _name As String, ByVal _size As SpriteMSX.SPRITE_SIZE, ByVal _inkColor As Integer, ByVal _bgColor As Integer, ByVal _gfx As Byte(), ByVal _paletteData As iPaletteMSX)

        Me.Index = _index

        Me.Name = _name

        Me.size = _size
        Me._mode = SPRITE_MODE.MONO

        Me.InkColor = _inkColor
        Me.BackgroundColor = _bgColor

        Me.patternData = _gfx.Clone

        Me._Palette = _paletteData

        refresh()

    End Sub






    ''' <summary>
    ''' Instancia universal (para todos los tipos) sin bitmap
    ''' </summary>
    ''' <param name="_name"></param>
    ''' <param name="_size"></param>
    ''' <param name="_inkColor"></param>
    ''' <param name="_bgColor"></param>
    ''' <param name="_paletteData"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _index As Integer, ByVal _name As String, ByVal _size As SPRITE_SIZE, ByVal _mode As SPRITE_MODE, ByVal _inkColor As Integer, ByVal _bgColor As Integer, ByVal _gfxData As Byte(), ByVal _colorData As Byte(), ByVal _paletteData As iPaletteMSX)
        Dim newColorData() As Byte
        Dim newORdata() As Boolean
        'Dim aByte As Byte
        'Dim itemssize As Integer = 15
        Dim posi As Integer = 0

        If _mode = SPRITE_MODE.COLOR Then
            ReDim newColorData(15)
            ReDim newORdata(15)

            If _colorData Is Nothing Then
                For i As Integer = 0 To 15
                    newORdata(i) = False
                    newColorData(i) = _inkColor
                Next

            Else
                For Each aByte In _colorData
                    If ((aByte >> 6) And 1) = 1 Then    '(aByte And bite_MASKs(6)) = bite_MASKs(6) Then 'bite_MASKs(6)=64 ---  Or (aByte And bite_MASKs(4)) = 16 >>>> 16 correccion temporal QUITAR en proxima vers.
                        newORdata(posi) = True
                        newColorData(posi) = aByte And 15
                    Else
                        newORdata(posi) = False
                        newColorData(posi) = aByte And 15
                    End If
                    posi += 1
                Next
            End If

            Me.colorData = newColorData
            Me.ORbitData = newORdata

        End If



        Me.Index = _index

        Me.Name = _name

        Me.size = _size
        Me._mode = _mode

        Me.InkColor = _inkColor
        Me.BackgroundColor = _bgColor

        Me.patternData = _gfxData.Clone

        Me._Palette = _paletteData

        Me.refresh()

    End Sub



    ''' <summary>
    ''' Proporciona una copia del objeto con el mismo ID (¿tiene sentido?)???
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Clone() As SpriteMSX
        Dim sprite As New SpriteMSX

        sprite.Index = Me.Index
        sprite.Name = Me.Name
        'sprite.order = Me.order

        sprite.size = Me.size
        sprite._mode = Me._mode
        sprite.InkColor = Me.InkColor
        sprite.BackgroundColor = Me.BackgroundColor

        'sprite.aBitmap = Me.aBitmap.Clone()      'BUG? añadido clone()
        'sprite.aBitmapX2 = Me.aBitmapX2.Clone()  'BUG? añadido clone()

        sprite.patternData = Me.patternData.Clone()
        If Not Me.ColorData Is Nothing Then
            sprite.ColorData = Me.ColorData.Clone()
            sprite.ORbitData = Me.ORbitData.Clone()
        End If

        sprite._Palette = Me._Palette

        sprite.refresh()

        Return sprite
    End Function



    Public Sub Clear()

        'Dim _matrixdataSize As Integer

        'If Me.size = SPRITE_SIZE.SIZE16 Then
        '    _matrixdataSize = 32
        'Else
        '    _matrixdataSize = 8
        'End If

        For i As Integer = 0 To patternData.Length - 1  '_matrixdataSize - 1
            Me.patternData(i) = 0
        Next

        If Me._mode = SPRITE_MODE.COLOR Then
            SetDefaultColors()
        End If

        Me.refresh()

    End Sub



    Private Sub setDefault()

        Dim _matrixdataSize As Integer

        Dim tmpPatternData() As Byte

        If Me.size = SPRITE_SIZE.SIZE16 Then
            _matrixdataSize = 31
        Else
            _matrixdataSize = 7
        End If

        ReDim tmpPatternData(_matrixdataSize)

        For i As Integer = 0 To _matrixdataSize
            tmpPatternData(i) = 0
        Next

        If Me._mode = SPRITE_MODE.COLOR Then
            SetDefaultColors()
        End If

        Me.patternData = tmpPatternData

    End Sub



    ''' <summary>
    ''' Redibuja el bitmap del sprite.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Refresh()

        If Me.Size = SPRITE_SIZE.SIZE8 Then
            Me.aBitmapX2 = Me.getBitmap8_x2()
        Else
            Me.aBitmapX2 = Me.getBitmap16_x2()
        End If

    End Sub



    Public Function isEmpty() As Boolean

        If Me._mode = SPRITE_MODE.COLOR Then
            Return isPatternEmpty() And isColorEmpty()
        Else
            Return isPatternEmpty()
        End If

    End Function



    Public Function isPatternEmpty() As Boolean

        Dim total As Integer = 0

        For Each value As Byte In Me.patternData
            total += value
        Next

        Return (total = 0)

    End Function



    Public Function isColorEmpty() As Boolean

        Dim total As Integer = 0
        Dim isORbit As Boolean = True

        If Me.ColorData Is Nothing Or Me.ORbitData Is Nothing Then
            Return True
        End If

        For Each value As Byte In Me.ColorData
            total += value
        Next

        For Each value As Boolean In Me.ORbitData
            If value = True Then
                isORbit = False
                Exit For
            End If
        Next

        Return (total = 0) And isORbit

    End Function



    Public Sub SetDefaultColors()
        ReDim ColorData(15)
        ReDim ORbitData(15)

        For i As Integer = 0 To 15
            Me.ColorData(i) = Me.InkColor
            Me.ORbitData(i) = False
        Next

    End Sub



    ''' <summary>
    ''' Provides the bitmap of the 8x8 sprite pattern.
    ''' </summary>
    ''' <remarks></remarks>
    Private Function getBitmap8() As Bitmap

        If Me._mode = SPRITE_MODE.MONO Then
            Return GetBitmapPattern8(Me.InkColor)
        Else
            Return GetBitmapPattern8(Me.ColorData)
        End If

    End Function



    ''' <summary>
    ''' genera el bitmap de un sprite de 16x16, a partir de los valores del objeto.
    ''' </summary>
    ''' <remarks></remarks>
    Private Function getBitmap16() As Bitmap

        If Me._mode = SPRITE_MODE.MONO Then
            Return GetBitmapPattern16(Me.InkColor)
        Else
            Return GetBitmapPattern16(Me.ColorData)
        End If

    End Function



    ''' <summary>
    ''' Provides the bitmap of the 8x8 sprite pattern.
    ''' </summary>
    ''' <remarks></remarks>
    Private Function getBitmap8_x2() As Bitmap

        If Me._mode = SPRITE_MODE.MONO Then
            Return GetBitmapPattern8_x2(Me.InkColor)
        Else
            Return GetBitmapPattern8_x2(Me.ColorData)
        End If

    End Function



    ''' <summary>
    ''' genera el bitmap de un sprite de 16x16, a partir de los valores del objeto.
    ''' </summary>
    ''' <remarks></remarks>
    Private Function getBitmap16_x2() As Bitmap

        If Me._mode = SPRITE_MODE.MONO Then
            Return GetBitmapPattern16_x2(Me.InkColor)
        Else
            Return GetBitmapPattern16_x2(Me.ColorData)
        End If

    End Function



    Public Function GetBitmapPattern(_colorData As Byte()) As Bitmap

        If Me._size = SPRITE_SIZE.SIZE8 Then
            Return GetBitmapPattern8(_colorData)
        Else
            Return GetBitmapPattern16(_colorData)
        End If

    End Function



    Public Function GetBitmapPattern(_color As Integer) As Bitmap

        If Me._size = SPRITE_SIZE.SIZE8 Then
            Return GetBitmapPattern8(_color)
        Else
            Return GetBitmapPattern16(_color)
        End If

    End Function



    Public Function GetBitmapPattern_x2(_colorData As Byte()) As Bitmap

        If Me._size = SPRITE_SIZE.SIZE8 Then
            Return GetBitmapPattern8_x2(_colorData)
        Else
            Return GetBitmapPattern16_x2(_colorData)
        End If

    End Function



    Public Function GetBitmapPattern_x2(_color As Integer) As Bitmap

        If Me._size = SPRITE_SIZE.SIZE8 Then
            Return GetBitmapPattern8_x2(_color)
        Else
            Return GetBitmapPattern16_x2(_color)
        End If

    End Function







    ''' <summary>
    ''' Provides the bitmap of the 8x8 sprite pattern, from one color.
    ''' </summary>
    ''' <param name="_color"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetBitmapPattern8(_color As Integer) As Bitmap
        Dim _colorData(7) As Byte
        'ReDim _colorData(15)

        For i As Integer = 0 To 7
            _colorData(i) = _color
        Next

        Return GetBitmapPattern8(_colorData)
    End Function



    ''' <summary>
    ''' Provides the bitmap of the 8x8 sprite pattern, from one color.
    ''' </summary>
    ''' <param name="_colorData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetBitmapPattern8(_colorData As Byte()) As Bitmap

        Dim _inkcolor As Color

        Dim _tmpBitmap As Bitmap = New Bitmap(8, 8)

        If Not patternData Is Nothing Then

            For y As Integer = 0 To 7

                _inkcolor = Me._Palette.GetRGBColor(_colorData(y))

                For x As Integer = 0 To 7

                    If ((patternData(y) >> x) And 1) = 1 Then '(patternData(y) And bite_MASKs(x)) = bite_MASKs(x) Then
                        _tmpBitmap.SetPixel(7 - x, y, _inkcolor)
                    End If

                Next

            Next

        End If

        Return _tmpBitmap

    End Function



    ''' <summary>
    ''' Provides the 2x zoomed bitmap of the 8x8 sprite pattern, from one color.
    ''' </summary>
    ''' <param name="_color"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetBitmapPattern8_x2(_color As Integer) As Bitmap
        Dim _colorData(7) As Byte
        'ReDim _colorData(15)

        For i As Integer = 0 To 7
            _colorData(i) = _color
        Next

        Return GetBitmapPattern8_x2(_colorData)
    End Function



    ''' <summary>
    ''' Provides the 2x zoomed bitmap of the 8x8 sprite pattern, from a list of colors.
    ''' </summary>
    ''' <param name="_colorData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetBitmapPattern8_x2(_colorData As Byte()) As Bitmap

        Dim _inkcolor As Color

        'Me.aBitmap = New Bitmap(8, 8)
        Dim _tmpBitmap As Bitmap = New Bitmap(16, 16)

        If Not patternData Is Nothing Then

            For y As Integer = 0 To 7

                _inkcolor = Me._Palette.GetRGBColor(_colorData(y))

                For x As Integer = 0 To 7

                    If ((patternData(y) >> x) And 1) = 1 Then '(patternData(y) And bite_MASKs(x)) = bite_MASKs(x) Then
                        putPixel_x2(_tmpBitmap, 7 - x, y, _inkcolor)
                    End If

                Next

            Next

        End If

        Return _tmpBitmap

    End Function








    ''' <summary>
    ''' Provides the bitmap of the 16x16 sprite pattern, from one color.
    ''' </summary>
    ''' <param name="_color"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetBitmapPattern16(_color As Integer) As Bitmap

        Dim _colorData(15) As Byte
        'ReDim _colorData(15)

        For i As Integer = 0 To 15
            _colorData(i) = _color
        Next

        Return GetBitmapPattern16(_colorData)

    End Function



    ''' <summary>
    ''' Provides the bitmap of the 16x16 sprite pattern, from a list of colors.
    ''' </summary>
    ''' <param name="_colorData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetBitmapPattern16(_colorData As Byte()) As Bitmap

        'Dim TempValue As Byte = 0

        Dim _inkcolor As Color

        Dim _tmpBitmap As Bitmap = New Bitmap(16, 16)

        If Not patternData Is Nothing Then

            For y As Integer = 0 To 15

                _inkcolor = Me._Palette.GetRGBColor(_colorData(y))

                'TempValue = 0
                For x As Integer = 0 To 7
                    If ((patternData(y) >> x) And 1) = 1 Then '(patternData(y) And bite_MASKs(x)) = bite_MASKs(x) Then
                        'putPixel_x2(_tmpBitmapX2, 7 - x, y, _inkcolor)
                        _tmpBitmap.SetPixel(7 - x, y, _inkcolor)  ' solo pinta los 1; los 0 quedan transparentes
                    End If
                Next


                'TempValue = 0
                For x As Integer = 0 To 7
                    If ((patternData(y + 16) >> x) And 1) = 1 Then '(patternData(y + 16) And bite_MASKs(x)) = bite_MASKs(x) Then
                        'putPixel_x2(_tmpBitmapX2, 15 - x, y, _inkcolor)  
                        _tmpBitmap.SetPixel(15 - x, y, _inkcolor)  ' solo pinta los 1; los 0 quedan transparentes
                    End If
                Next

            Next

        End If

        Return _tmpBitmap

    End Function



    ''' <summary>
    ''' Provides the 2x zoomed bitmap of the 16x16 sprite pattern, from a list of colors.
    ''' </summary>
    ''' <param name="_color"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetBitmapPattern16_x2(_color As Integer) As Bitmap

        Dim _colorData(15) As Byte
        'ReDim _colorData(15)

        For i As Integer = 0 To 15
            _colorData(i) = _color
        Next

        Return GetBitmapPattern16_x2(_colorData)

    End Function



    ''' <summary>
    ''' Provides the 2x zoomed bitmap of the 16x16 sprite pattern, from a list of colors.
    ''' </summary>
    ''' <param name="_colorData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetBitmapPattern16_x2(_colorData As Byte()) As Bitmap

        'Dim TempValue As Byte = 0

        Dim _inkcolor As Color

        Dim _tmpBitmap As Bitmap = New Bitmap(32, 32)  ', System.Drawing.Imaging.PixelFormat.Format4bppIndexed)
        '_tmpBitmapX2.Palette = (System.Drawing.Imaging.ColorPalette)


        If Not patternData Is Nothing Then

            For y As Integer = 0 To 15

                _inkcolor = Me._Palette.GetRGBColor(_colorData(y))

                'TempValue = 0
                For x As Integer = 0 To 7
                    If ((patternData(y) >> x) And 1) = 1 Then '(patternData(y) And bite_MASKs(x)) = bite_MASKs(x) Then
                        putPixel_x2(_tmpBitmap, 7 - x, y, _inkcolor)  ' solo pinta los 1; los 0 quedan transparentes
                    End If
                Next


                'TempValue = 0
                For x As Integer = 0 To 7
                    If ((patternData(y + 16) >> x) And 1) = 1 Then '(patternData(y + 16) And bite_MASKs(x)) = bite_MASKs(x) Then
                        putPixel_x2(_tmpBitmap, 15 - x, y, _inkcolor)  ' solo pinta los 1; los 0 quedan transparentes
                    End If
                Next

            Next

        End If

        Return _tmpBitmap

    End Function







    'Private Sub putPixel(ByVal Xpos As Byte, ByVal Ypos As Byte, ByVal _color As Color)

    '    'Me.aBitmap.SetPixel(Xpos, Ypos, _color)

    '    putPixel_x2(Me.aBitmapX2, Xpos, Ypos, _color)

    'End Sub



    Private Sub putPixel_x2(ByRef _tmpBitmapX2 As Bitmap, ByVal Xpos As Byte, ByVal Ypos As Byte, ByVal _color As Color)

        Xpos *= 2
        Ypos *= 2

        _tmpBitmapX2.SetPixel(Xpos, Ypos, _color)
        _tmpBitmapX2.SetPixel(Xpos + 1, Ypos, _color)
        _tmpBitmapX2.SetPixel(Xpos, Ypos + 1, _color)
        _tmpBitmapX2.SetPixel(Xpos + 1, Ypos + 1, _color)

    End Sub


End Class
