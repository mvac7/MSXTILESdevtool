Public Class SimpleBitmapConverter


    Private Const TMSWIDTH = 256
    Private Const TMSHEIGHT = 192

    'Private pixelscreen(TMSWIDTH, TMSHEIGHT) As Byte


    'Private _inkColor As Byte = 15
    'Private _backgroundColor As Byte = 4



    ' conversion SC2
    Public Class ColorItem
        Public Sub New(ByVal aColor As Byte, ByVal aCount As Byte)
            Me.Color = aColor
            Me.Count = aCount
        End Sub
        Public Color As Byte
        Public Count As Byte
    End Class





    ''' <summary>
    ''' valor de colores para 8 pixels (tinta y fondo)
    ''' </summary>
    ''' <remarks></remarks>
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






    'Public Property InkColor() As Byte
    '    Get
    '        Return Me._inkColor
    '    End Get
    '    Set(ByVal value As Byte)
    '        Me._inkColor = value
    '    End Set
    'End Property



    'Public Property BackgroundColor() As Byte
    '    Get
    '        Return Me._backgroundColor
    '    End Get
    '    Set(ByVal value As Byte)
    '        Me._backgroundColor = value
    '    End Set
    'End Property






    ''' <summary>
    ''' Convierte un bitmap al modo grafico G2
    ''' </summary>
    ''' <param name="sourceBitmap"></param>
    ''' <remarks></remarks>
    Public Function GetScreenFromBitmap(ByVal sourceBitmap As Bitmap, ByVal backgroundColor As Byte) As Byte() ', ByVal backgroundColor As Byte)
        Dim aColor As Color
        Dim myBitmap4b = New Bitmap(TMSWIDTH, TMSHEIGHT)
        Dim pixelscreen(TMSWIDTH, TMSHEIGHT) As Byte
        Dim posx As Integer
        Dim posy As Integer
        Dim aPixelColor(7) As Byte
        Dim aPixelPattern(7) As Boolean
        Dim i As Integer
        Dim o As Integer
        Dim aMSXColor As New ColorByte
        Dim aBytePattern As Byte

        Dim VRAM(16383) As Byte ' 16k de memoria de video

        Dim VRAMaddr As Integer = 0

        'first, it is reduced to 16 colors from the TMS9918A palette 
        For posy = 0 To 191
            For posx = 0 To 255
                aColor = sourceBitmap.GetPixel(posx, posy)
                pixelscreen(posx, posy) = getMSXColor(aColor)
            Next
        Next

        'second, it is reduced to 2 colors for every 8 pixels (attribute clash)
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
                    aMSXColor = getFGBGColors(aPixelColor, aMSXColor.BackGround, backgroundColor)

                    'generar el patron
                    'recorre los 8 puntos de una linea
                    'si coincide con el color asignado como FG marca el punto a 1
                    'si coincide con el BG, lo marca como 0
                    'si no coincide, determina a que color de los seleccionados se parece
                    For i = 0 To 7
                        If aPixelColor(i) = aMSXColor.BackGround Then
                            aPixelPattern(i) = False
                        ElseIf aPixelColor(i) = aMSXColor.ForeGround Then
                            aPixelPattern(i) = True
                        Else
                            ' convierte a Ink o BG
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

                    'convierte el array a un byte
                    aBytePattern = 0
                    For i = 0 To 7
                        If aPixelPattern(i) Then
                            aBytePattern = aBytePattern + (128 >> i) 'Bit(i)
                        End If
                    Next

                    'escribe los datos en la memoria
                    VRAM(VRAMaddr) = aBytePattern
                    VRAM(iVDP.TableBase.GRPCOL + VRAMaddr) = aMSXColor.GetFGBG()
                    VRAMaddr += 1
                Next
            Next
        Next

        'Optimize()

        Return VRAM

    End Function



    ''' <summary>
    ''' Get the most used color in a picture
    ''' </summary>
    ''' <returns></returns>
    Public Function GetMostUsedColor(ByVal sourceBitmap As Bitmap) As Byte

        Dim resultColor As Byte
        Dim total As Integer

        Dim posx As Integer
        Dim posy As Integer

        Dim aColor As Color

        Dim colorCounters(16) As Integer

        For i As Integer = 0 To 15
            colorCounters(i) = 0
        Next

        For posy = 0 To 191
            For posx = 0 To 255
                aColor = sourceBitmap.GetPixel(posx, posy)
                colorCounters(getMSXColor(aColor)) += 1
            Next
        Next

        For i As Integer = 0 To 15
            If colorCounters(i) > total Then
                resultColor = i
                total = colorCounters(i)
            End If
        Next

        Return resultColor

    End Function



    Private Function getFGBGColors(ByVal a8Pixel() As Byte, ByVal lastColor As Byte, ByVal backgroundColor As Byte) As ColorByte
        Dim aColorByte As New ColorByte
        Dim aColorList As New SortedList()
        Dim aSortedColorList() As ColorItem
        Dim aColor As Byte = 0
        Dim i As Integer

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
            aColorByte.BackGround = lastColor
            aColorByte.ForeGround = aSortedColorList(0).Color
            'If Not aSortedColorList(0).Color = backgroundColor Then
            '    aColorByte.ForeGround = aSortedColorList(0).Color
            'Else
            '    If backgroundColor = 15 Then
            '        aColorByte.ForeGround = 1
            '    Else
            '        aColorByte.ForeGround = 15
            '    End If
            'End If

        Else
            ' mas de un color, se ordenan de mayor a menor
            If aSortedColorList(1).Color = lastColor Then ' 1
                'tiene prioridad el 1 (negro) como fondo
                aColorByte.BackGround = lastColor ' 1
                aColorByte.ForeGround = aSortedColorList(0).Color
            Else
                aColorByte.BackGround = aSortedColorList(0).Color
                aColorByte.ForeGround = aSortedColorList(1).Color
            End If

        End If

        If aColorByte.ForeGround = backgroundColor Then
            aColorByte.ForeGround = aColorByte.BackGround
            aColorByte.BackGround = backgroundColor
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



    ''' <summary>
    ''' Convierte un color RGB a un color de la paleta del TMS9918A
    ''' </summary>
    ''' <param name="aColor"></param>
    ''' <returns></returns>
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


        If aColor.A = 0 Then
            Return 0  ' Transparent
        End If

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
