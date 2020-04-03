Public Class MSXpalette

    Public Name As String
    Public Version As String
    Public Group As String
    Public Author As String
    Public Description As String

    Public Colors As SortedList

    Private _VDPtype As MSXVDP

    Private TMS9918colors As New List(Of Color)


    ' pendiente de ajustar
    'Public RedColorConversionTable As Byte() = New Byte() {0, 36, 73, 109, 146, 182, 219, 255}
    'Public GreenColorConversionTable As Byte() = New Byte() {0, 36, 73, 109, 146, 182, 219, 255}
    'Public BlueColorConversionTable As Byte() = New Byte() {0, 36, 73, 109, 146, 182, 219, 255}
    Public RedColorConversionTable As New List(Of Integer)
    Public GreenColorConversionTable As New List(Of Integer)
    Public BlueColorConversionTable As New List(Of Integer)


    Public Shadows Enum MSXVDP As Integer
        AUTO = 0
        TMS9918 = 1
        V9938 = 2
    End Enum



    Public Property VDPtype() As MSXpalette.MSXVDP
        Get
            Return _VDPtype
        End Get
        Set(ByVal value As MSXpalette.MSXVDP)
            Me._VDPtype = value
        End Set
    End Property


    Public Sub New()
        Me.Colors = New SortedList
        Me.name = ""
        Me._VDPtype = MSXVDP.V9938

        init()

    End Sub


    Public Sub New(ByVal value As MSXVDP)
        Me.Colors = New SortedList
        Me.name = ""
        Me._VDPtype = value

        init()

    End Sub


    Public Sub init()

        RedColorConversionTable.AddRange(New Integer() {0, 36, 73, 109, 146, 182, 219, 255})
        GreenColorConversionTable.AddRange(New Integer() {0, 36, 73, 109, 146, 182, 219, 255})
        BlueColorConversionTable.AddRange(New Integer() {0, 36, 73, 109, 146, 182, 219, 255})

        ' set TMS9918 palette
        TMS9918colors.Add(Color.FromArgb(15, 15, 15))
        TMS9918colors.Add(Color.FromArgb(0, 0, 0))       ' 1 - dark
        TMS9918colors.Add(Color.FromArgb(33, 200, 66)) ' 2 — medium green
        TMS9918colors.Add(Color.FromArgb(94, 220, 120)) ' 3 — light green
        TMS9918colors.Add(Color.FromArgb(84, 85, 237)) ' 4 — dark blue
        TMS9918colors.Add(Color.FromArgb(125, 118, 252)) ' 5 — light blue
        TMS9918colors.Add(Color.FromArgb(212, 82, 77)) ' 6 — dark red
        TMS9918colors.Add(Color.FromArgb(66, 235, 245)) ' 7 - cyan
        TMS9918colors.Add(Color.FromArgb(252, 85, 84)) ' 8 - medium red
        TMS9918colors.Add(Color.FromArgb(255, 121, 120)) ' 9 - light red
        TMS9918colors.Add(Color.FromArgb(212, 193, 84))  '10 - dark yellow
        TMS9918colors.Add(Color.FromArgb(230, 206, 128)) '11 - light yellow
        TMS9918colors.Add(Color.FromArgb(33, 176, 59)) '12 - dark green
        TMS9918colors.Add(Color.FromArgb(201, 91, 186)) '13 - magenta
        TMS9918colors.Add(Color.FromArgb(204, 204, 204)) '14 - gray
        TMS9918colors.Add(Color.FromArgb(255, 255, 255)) '15 - white

        setDefault()

    End Sub


    Public Sub clear()
        Me.Colors.Clear()
        Me.name = ""
        'Me.Colors.Item(0) = New ColorMSX(0, 0, 0, 0)
    End Sub



    '| number | 		      |  of red    |   of blue  |  of green  |
    '------------------------------------------------------------------
    '|    0	  | transparent   |	0          |     0	    |	  0	 |
    '|    1	  | black	      |	0          |     0	    |	  0	 |
    '|    2	  | bright green  |	1          |     1	    |	  6	 |
    '|    3	  | light green   |	3          |     3	    |	  7	 |
    '|    4	  | deep blue	  |	1          |     7	    |	  1	 |
    '|    5	  | bright blue   |	2          |     7	    |	  3	 |
    '|    6	  | deep red	  |	5          |     1	    |	  1	 |
    '|    7	  | light blue	  |	2          |     7	    |	  6	 |
    '|    8	  | bright red	  |	7          |     1	    |	  1	 |
    '|    9	  | light red	  |	7          |     3	    |	  3	 |
    '|   10	  | bright yellow |	6          |     1	    |	  6	 |
    '|   11	  | pale yellow   |	6          |     3	    |	  6	 |
    '|   12	  | deep green	  |	1          |     1	    |	  4	 |
    '|   13	  | purple	      |	6          |     5	    |	  2	 |
    '|   14	  | grey	      |	5          |     5	    |	  5	 |
    '|   15	  | white	      |	7          |     7	    |	  7	 |
    Public Sub setDefault()

        Me.clear()

        Me.name = "Default Palette"

        Me.SetColor(0, 0, 0, 0) ' 0 — transparent
        Me.SetColor(1, 0, 0, 0) ' 1 — black
        Me.SetColor(2, 2, 5, 2) '  2 — medium green
        Me.SetColor(3, 3, 6, 3) ' 3 — light green
        Me.SetColor(4, 2, 2, 5) ' 4 — dark blue
        Me.SetColor(5, 3, 3, 7) '5 — light blue
        Me.SetColor(6, 5, 2, 1) '6 — dark red
        Me.SetColor(7, 2, 6, 7) '7 — cyan
        Me.SetColor(8, 6, 2, 2) '8 — medium red
        Me.SetColor(9, 7, 3, 3) '9 — light red
        Me.SetColor(10, 6, 6, 3) '10 — dark yellow
        Me.SetColor(11, 6, 6, 4) '11 — light yellow
        Me.SetColor(12, 1, 4, 1) '12 — dark green
        Me.SetColor(13, 5, 3, 5) '13 — magenta
        Me.SetColor(14, 6, 6, 6) '14 — gray
        Me.SetColor(15, 7, 7, 7) '15 - white

        'If Me.PaletteType = 0 Then
        '    ' blueMSX
        '    msxPalette(0) = Color.FromArgb(0, 0, 0) ' 0 — transparent
        '    msxPalette(1) = Color.FromArgb(0, 0, 0) ' 1 — black
        '    msxPalette(2) = Color.FromArgb(33, 200, 66) ' 2 — medium green
        '    msxPalette(3) = Color.FromArgb(94, 220, 120) ' 3 — light green
        '    msxPalette(4) = Color.FromArgb(84, 85, 237) ' 4 — dark blue
        '    msxPalette(5) = Color.FromArgb(125, 118, 252) ' 5 — light blue
        '    msxPalette(6) = Color.FromArgb(212, 82, 77) ' 6 — dark red
        '    msxPalette(7) = Color.FromArgb(66, 235, 245) ' 7 — cyan
        '    msxPalette(8) = Color.FromArgb(252, 85, 84) ' 8 — medium red
        '    msxPalette(9) = Color.FromArgb(255, 121, 120) ' 9 — light red
        '    msxPalette(10) = Color.FromArgb(212, 193, 84) ' 10 — dark yellow
        '    msxPalette(11) = Color.FromArgb(230, 206, 128) ' 11 — light yellow
        '    msxPalette(12) = Color.FromArgb(33, 176, 59) ' 12 — dark green
        '    msxPalette(13) = Color.FromArgb(201, 91, 186) ' 13 — magenta
        '    msxPalette(14) = Color.FromArgb(204, 204, 204) ' 14 — gray
        '    msxPalette(15) = Color.FromArgb(255, 255, 255) ' 15 - white

        'Else
        '    'Jannone_ScreenConversor
        '    msxPalette(0) = Color.FromArgb(0, 0, 0) ' 0 — transparent
        '    msxPalette(1) = Color.FromArgb(0, 0, 0) ' 1 — black
        '    msxPalette(2) = Color.FromArgb(33, 200, 66) ' 2 — medium green
        '    msxPalette(3) = Color.FromArgb(94, 220, 120) ' 3 — light green
        '    msxPalette(4) = Color.FromArgb(84, 85, 237) ' 4 — dark blue
        '    msxPalette(5) = Color.FromArgb(125, 118, 252) ' 5 — light blue
        '    msxPalette(6) = Color.FromArgb(212, 82, 77) ' 6 — dark red
        '    msxPalette(7) = Color.FromArgb(66, 235, 245) ' 7 — cyan
        '    msxPalette(8) = Color.FromArgb(252, 85, 84) ' 8 — medium red
        '    msxPalette(9) = Color.FromArgb(255, 121, 120) ' 9 — light red
        '    msxPalette(10) = Color.FromArgb(212, 193, 84) ' 10 — dark yellow
        '    msxPalette(11) = Color.FromArgb(230, 206, 128) ' 11 — light yellow
        '    msxPalette(12) = Color.FromArgb(33, 176, 59) ' 12 — dark green
        '    msxPalette(13) = Color.FromArgb(201, 91, 186) ' 13 — magenta
        '    msxPalette(14) = Color.FromArgb(204, 204, 204) ' 14 — gray
        '    msxPalette(15) = Color.FromArgb(255, 255, 255) ' 15 - white

        'End If

    End Sub


    Public Function clone() As MSXpalette

        Dim tempPalette As New MSXpalette
        tempPalette.name = Me.name

        For Each aColor As MSXcolor In Me.Colors.Values
            tempPalette.Colors.Item(aColor.id) = aColor.Clone
        Next

        Return tempPalette
    End Function


    Public Sub SetColor(ByVal key As Integer, ByVal color As MSXcolor)
        If Me.Colors.ContainsKey(key) Then
            Me.Colors.Item(key) = color
        Else
            Me.Colors.Add(key, color)
        End If
    End Sub


    Public Sub SetColor(ByVal key As Integer, ByVal red As Byte, ByVal green As Byte, ByVal blue As Byte)
        If Me.Colors.ContainsKey(key) Then
            Me.Colors.Item(key) = New MSXcolor(key, red, green, blue)
        Else
            Me.Colors.Add(key, New MSXcolor(key, red, green, blue))
        End If
    End Sub


    Public Function GetColor(ByVal key As Integer) As MSXcolor

        If Me.Colors.ContainsKey(key) Then
            Return Me.Colors.Item(key)
        Else
            Return Nothing
        End If

    End Function



    Public Sub SetData(ByVal data() As Byte)
        Dim counter As Integer = 0
        Dim red As Byte
        Dim green As Byte
        Dim blue As Byte

        For i As Integer = 0 To 15
            red = (data(counter) And 112) / 16
            blue = data(counter) And 7
            counter += 1
            green = data(counter) And 7
            counter += 1
            Me.Colors.Item(i) = New MSXcolor(i, red, green, blue)
        Next
    End Sub



    ''' <summary>
    ''' Genera un array con los datos de la paleta de colores
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetData() As Byte()
        Dim tmpData(31) As Byte
        Dim counter As Integer = 0

        For Each aColor As MSXcolor In Me.Colors.Values
            tmpData(counter) = CByte(aColor.Red * 16 + aColor.Blue)
            counter += 1
            tmpData(counter) = aColor.Green
            counter += 1
        Next

        Return tmpData

    End Function


    ''' <summary>
    ''' Genera un array con los datos de la paleta de colores, para sacar un listado de datas para Basic.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDataBasic() As Byte()
        Dim tmpData(47) As Byte
        Dim counter As Integer = 0
        Dim numColor As Integer = 0

        For Each aColor As MSXcolor In Me.Colors.Values
            tmpData(counter) = aColor.Red
            counter += 1
            tmpData(counter) = aColor.Green
            counter += 1
            tmpData(counter) = aColor.Blue
            counter += 1
        Next

        Return tmpData

    End Function


    ''' <summary>
    ''' get 24 bit color (Drawing.Color) from 3 bit RGB values
    ''' </summary>
    ''' <param name="msxRed"></param>
    ''' <param name="msxGreen"></param>
    ''' <param name="msxBlue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getRGB(ByVal msxRed As Byte, ByVal msxGreen As Byte, ByVal msxBlue As Byte) As Color

        If msxRed > 7 Then
            msxRed = 7
        End If
        If msxGreen > 7 Then
            msxGreen = 7
        End If
        If msxBlue > 7 Then
            msxBlue = 7
        End If

        'Return Me.getRGB(New MSXcolor(0, msxRed, msxGreen, msxBlue))

        Dim aRed As Byte = RedColorConversionTable(msxRed)
        Dim aGreen As Byte = GreenColorConversionTable(msxGreen)
        Dim aBlue As Byte = BlueColorConversionTable(msxBlue)

        Return Color.FromArgb(aRed, aGreen, aBlue)

    End Function


    Public Function getRGB(ByVal _color As MSXcolor) As Color

        If _VDPtype = MSXVDP.TMS9918 Then
            Return getRGB(_color.id)
        Else
            'Dim aRed As Byte = RedColorConversionTable(_color.Red)
            'Dim aGreen As Byte = GreenColorConversionTable(_color.Green)
            'Dim aBlue As Byte = BlueColorConversionTable(_color.Blue)

            Return getRGB(_color.Red, _color.Green, _color.Blue)
        End If

    End Function


    Public Function getRGB(ByVal _id As Integer) As Color
        Dim _color As MSXcolor

        If _VDPtype = MSXVDP.TMS9918 Then
            Return TMS9918colors.Item(_id)
        Else
            _color = Me.Colors.Item(_id)
            Return getRGB(_color.Red, _color.Green, _color.Blue)
        End If

    End Function




End Class
