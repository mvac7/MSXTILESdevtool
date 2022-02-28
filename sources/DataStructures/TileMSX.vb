
Public Class TileMSX

    'Private bite_MASKs = New Byte() {1, 2, 4, 8, 16, 32, 64, 128}

    Public Index As Integer

    Public InkColor As Integer
    Public BackgroundColor As Integer

    Public Pattern(7) As Byte
    Public Color(7) As Byte  ' new Byte() {0, 0, 0, 0, 0, 0, 0, 0}

    Private tileBitmap As Bitmap

    Private _ColorPalette As iPaletteMSX

    Private screenMode As iVDP.SCREEN_MODE = iVDP.SCREEN_MODE.G2



    Public Property Palette() As iPaletteMSX
        Get
            Return Me._ColorPalette
        End Get
        Set(ByVal value As iPaletteMSX)
            Me._ColorPalette = value
        End Set
    End Property



    Public Property Mode() As iVDP.SCREEN_MODE
        Get
            Return Me.screenMode
        End Get
        Set(ByVal value As iVDP.SCREEN_MODE)
            Me.screenMode = value
        End Set
    End Property



    Public Sub New(ByVal _index As Integer, ByVal _screenMode As iVDP.SCREEN_MODE, ByVal _Pattern As Byte(), ByVal _color As Byte(), ByVal _Palette As iPaletteMSX, ByVal _InkColor As Integer, ByVal _BGcolor As Integer)

        Me.Index = _index
        Me.screenMode = _screenMode
        Me.Pattern = _Pattern
        If Not _color Is Nothing Then
            Me.Color = _color
        End If
        Me.InkColor = _InkColor
        Me.BackgroundColor = _BGcolor
        Me._ColorPalette = _Palette

        Refresh()
    End Sub



    ''' <summary>
    ''' Tile sin lineas de colores para modos T0 y G1 (screen 0 y 1)
    ''' </summary>
    ''' <param name="_index"></param>
    ''' <param name="_screenMode"></param>
    ''' <param name="_Pattern"></param>
    ''' <param name="_Palette"></param>
    ''' <param name="_InkColor"></param>
    ''' <param name="_BGcolor"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _index As Integer, ByVal _screenMode As iVDP.SCREEN_MODE, ByVal _Pattern As Byte(), ByVal _Palette As iPaletteMSX, ByVal _InkColor As Integer, ByVal _BGcolor As Integer)

        Me.Index = _index
        Me.screenMode = _screenMode
        Me.Pattern = _Pattern

        Me.InkColor = _InkColor
        Me.BackgroundColor = _BGcolor
        Me._ColorPalette = _Palette

        Refresh()
    End Sub



    ''' <summary>
    ''' Tile modo G2 sin la información de colores de tinta y fondo. Se genera en base a la información de colores.
    ''' </summary>
    ''' <param name="_index"></param>
    ''' <param name="_screenMode"></param>
    ''' <param name="_Pattern"></param>
    ''' <param name="_color"></param>
    ''' <param name="_Palette"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _index As Integer, ByVal _screenMode As iVDP.SCREEN_MODE, ByVal _Pattern As Byte(), ByVal _color As Byte(), ByVal _Palette As iPaletteMSX)
        'Dim _InkColor As Integer = 15
        'Dim _BGcolor As Integer = 4

        Me.Index = _index
        Me.screenMode = _screenMode
        Me.Pattern = _Pattern

        If Not _color Is Nothing Then
            Me.Color = _color
        End If

        Me.InkColor = getMostUsedColor(Me.Color, False)
        Me.BackgroundColor = getMostUsedColor(Me.Color, True)

        'Me.InkColor = 15
        'Me.BGcolor = 4

        Me._ColorPalette = _Palette

        Refresh()
    End Sub



    Private Function getMostUsedColor(ByVal colorData() As Byte, ByVal isBG As Boolean) As Integer

        Dim i As Integer = 0
        Dim o As Integer
        'Dim tempValue As ColorItem
        Dim tmpList As New SortedList
        'Dim listLength As Integer = list.Count
        'ReDim tmpList(listLength - 1)

        Dim repeticiones As Integer

        Dim tmpColorIndex As Integer = 0
        Dim tmpColor As Integer

        For i = 0 To 15 'total colores paleta TMS9918
            repeticiones = 0
            For o = 0 To 7 'cantidad colores del tile
                If isBG Then
                    tmpColor = colorData(o) And 15 'BG color
                Else
                    tmpColor = colorData(o) >> 4 'And 240) / 16 'INK color
                End If
                If tmpColor = i Then
                    repeticiones += 1
                End If
            Next
            If repeticiones > 0 Then
                tmpList.Add(i, repeticiones)
            End If
        Next

        tmpColor = 0
        For i = 0 To tmpList.Count - 1
            If tmpColor < tmpList.GetByIndex(i) Then
                tmpColor = tmpList.GetByIndex(i)
                tmpColorIndex = i
            End If
        Next

        Return tmpList.GetKey(tmpColorIndex)
    End Function


    ' old Clone function
    Public Function Clone() As TileMSX
        Dim cloneTile As New TileMSX(Me.Index, Me.screenMode, Me.Pattern.Clone, Me.Color.Clone, Me.Palette, Me.InkColor, Me.BackgroundColor)

        cloneTile.tileBitmap = Me.tileBitmap.Clone

        Return cloneTile
    End Function



    'Public Function Copy(ByVal newIndex As Integer) As TileMSX
    '    Dim copyTile As New TileMSX(newIndex, Me.screenMode, Me.Pattern.Clone, Me.Color.Clone, Me.Palette, Me.InkColor, Me.BGcolor)

    '    copyTile.tileBitmap = Me.tileBitmap.Clone

    '    Return copyTile
    'End Function



    Public Sub Refresh()
        If Me.screenMode = iVDP.SCREEN_MODE.G2 Then
            genBitmap8G2()
        Else
            genBitmap8mono()
        End If
    End Sub




    ''' <summary>
    ''' Genera el bitmap de un tile de 8x8, a partir de los valores del objeto.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub genBitmap8mono()
        Dim TempValue As Byte = 0
        Dim tmpColor As Integer

        Me.tileBitmap = New Bitmap(16, 16)

        If Not Me.Pattern Is Nothing Then

            For y As Integer = 0 To 7

                TempValue = Me.Pattern(y) 'And Me.bite_MASKs(x)

                For x As Integer = 0 To 7

                    If ((TempValue >> x) And 1) = 1 Then 'TempValue = Me.bite_MASKs(x) Then
                        tmpColor = Me.InkColor
                    Else
                        tmpColor = Me.BackgroundColor
                    End If

                    putPixel2(7 - x, y, Me._ColorPalette.GetRGBColor(tmpColor))

                Next

            Next

        End If
    End Sub



    Private Sub genBitmap8G2()
        Dim TempValue As Byte = 0
        Dim tmpColor As Integer

        Me.tileBitmap = New Bitmap(16, 16)

        If Not Me.Pattern Is Nothing Then

            For y As Integer = 0 To 7

                TempValue = Me.Pattern(y)

                For x As Integer = 0 To 7

                    'TempValue = Me.Pattern(y) And Me.bite_MASKs(x)

                    If ((TempValue >> x) And 1) = 1 Then
                        tmpColor = Me.Color(y) >> 4 'ForeGround
                    Else
                        tmpColor = Me.Color(y) And 15 'BackGround
                    End If

                    putPixel2(7 - x, y, Me._ColorPalette.GetRGBColor(tmpColor))

                Next

            Next

        End If
    End Sub



    Public Function GetBitmapX2() As Bitmap
        Return tileBitmap
    End Function



    Public Function GetBitmap() As Bitmap

        Dim tmpBitmap As New Bitmap(8, 8)

        If Not Me.Pattern Is Nothing Then

            If Me.screenMode = iVDP.SCREEN_MODE.G2 Then
                tmpBitmap = GetBitmapColor()
            Else
                tmpBitmap = GetBitmapMono()
            End If

        End If

        Return tmpBitmap

    End Function



    Public Function GetBitmapMono() As Bitmap
        Dim tmpBitmap As New Bitmap(8, 8)

        Dim TempValue As Byte = 0
        Dim tmpColor As Integer

        If Not Me.Pattern Is Nothing Then

            For y As Integer = 0 To 7

                TempValue = Me.Pattern(y)
                For x As Integer = 0 To 7

                    If ((TempValue >> x) And 1) = 1 Then '(TempValue And Me.bite_MASKs(x)) = Me.bite_MASKs(x) Then
                        tmpColor = Me.InkColor
                    Else
                        tmpColor = Me.BackgroundColor
                    End If

                    tmpBitmap.SetPixel(7 - x, y, Me._ColorPalette.GetRGBColor(tmpColor))

                Next

            Next

        End If

        Return tmpBitmap

    End Function



    Public Function GetBitmapColor() As Bitmap
        Dim tmpBitmap As New Bitmap(8, 8)

        Dim TempValue As Byte = 0
        Dim tmpColor As Integer

        If Not Me.Pattern Is Nothing Then

            For y As Integer = 0 To 7

                TempValue = Me.Pattern(y)
                For x As Integer = 0 To 7

                    'TempValue = Me.Pattern(y) And Me.bite_MASKs(x)
                    If ((Me.Pattern(y) >> x) And 1) = 1 Then   '(TempValue And Me.bite_MASKs(x)) = Me.bite_MASKs(x) Then
                        tmpColor = Me.Color(y) >> 4 'And 240) / 16
                    Else
                        tmpColor = Me.Color(y) And 15
                    End If

                    tmpBitmap.SetPixel(7 - x, y, Me._ColorPalette.GetRGBColor(tmpColor))

                Next

            Next

        End If

        Return tmpBitmap

    End Function



    Private Sub putPixel2(ByVal Xpos As Byte, ByVal Ypos As Byte, ByVal _color As Color)

        Xpos *= 2
        Ypos *= 2

        Me.tileBitmap.SetPixel(Xpos, Ypos, _color)
        Me.tileBitmap.SetPixel(Xpos + 1, Ypos, _color)
        Me.tileBitmap.SetPixel(Xpos, Ypos + 1, _color)
        Me.tileBitmap.SetPixel(Xpos + 1, Ypos + 1, _color)

    End Sub



End Class
