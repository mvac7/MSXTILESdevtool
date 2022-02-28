Public Class PaletteV9938
    Implements iPaletteMSX

    Public _ID As Integer
    Public _Name As String

    Private ZeroColor As Color = Color.Navy

    Private Colors As SortedList

    Property ID() As Integer Implements iPaletteMSX.ID
        Get
            Return Me._ID
        End Get
        Set(ByVal value As Integer)
            Me._ID = value
        End Set
    End Property

    Property Name() As String Implements iPaletteMSX.Name
        Get
            Return Me._Name
        End Get
        Set(ByVal value As String)
            Me._Name = value
        End Set
    End Property


    ReadOnly Property Type() As iPaletteMSX.VDP Implements iPaletteMSX.Type
        Get
            Return iPaletteMSX.VDP.V9938
        End Get
    End Property



    Public Sub New()
        Me.Colors = New SortedList

        Me._ID = Me.GetHashCode() + CInt(Rnd() * 100000)

        Me._Name = "New_pal"

        'Me._VDPtype = MSXVDP.V9938

        SetDefault()

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
    Public Sub SetDefault() Implements iPaletteMSX.SetDefault

        Me.Colors.Clear()

        Me.SetColor(0, 0, 0, 0) ' 0 — transparent
        Me.SetColor(1, 0, 0, 0) ' 1 — black
        Me.SetColor(2, 1, 6, 1) '  2 — medium green
        Me.SetColor(3, 3, 7, 3) ' 3 — light green
        Me.SetColor(4, 1, 1, 7) ' 4 — dark blue
        Me.SetColor(5, 2, 3, 7) '5 — light blue
        Me.SetColor(6, 5, 1, 1) '6 — dark red
        Me.SetColor(7, 2, 6, 7) '7 — cyan
        Me.SetColor(8, 7, 1, 1) '8 — medium red
        Me.SetColor(9, 7, 3, 3) '9 — light red
        Me.SetColor(10, 6, 6, 1) '10 — dark yellow
        Me.SetColor(11, 6, 6, 4) '11 — light yellow
        Me.SetColor(12, 1, 4, 1) '12 — dark green
        Me.SetColor(13, 6, 2, 5) '13 — magenta
        Me.SetColor(14, 5, 5, 5) '14 — gray
        Me.SetColor(15, 7, 7, 7) '15 - white

    End Sub



    Public Sub SetPalette(ByVal _palette As PaletteV9938)

        'Me.ID = _palette.ID
        Me._Name = _palette.Name

        Me.Colors.Clear()
        For Each aColor As ColorMSX In _palette.Colors.Values
            Me.Colors.Item(aColor.Index) = aColor.Clone
        Next

    End Sub



    Public Function Clone() As iPaletteMSX Implements iPaletteMSX.Clone

        Dim tempPalette As New PaletteV9938
        tempPalette._Name = Me._Name

        For Each aColor As ColorMSX In Me.Colors.Values
            tempPalette.Colors.Item(aColor.Index) = aColor.Clone
        Next

        Return tempPalette
    End Function



    Public Function Copy() As iPaletteMSX Implements iPaletteMSX.Copy

        Dim item As PaletteV9938

        item = Me.Clone
        item.ID = Me.ID

        Return item
    End Function



    Public Sub SetZeroColor(ByVal newColor As Color) Implements iPaletteMSX.SetZeroColor
        Me.ZeroColor = newColor
    End Sub


    Public Sub SetColor(ByVal index As Integer, ByVal newColor As ColorMSX) Implements iPaletteMSX.SetColor
        newColor.Index = index
        If Me.Colors.ContainsKey(index) Then
            Me.Colors.Item(index) = newColor
        Else
            Me.Colors.Add(index, newColor)
        End If
    End Sub



    Private Sub SetColor(ByVal index As Integer, ByVal red As Byte, ByVal green As Byte, ByVal blue As Byte)
        If Me.Colors.ContainsKey(index) Then
            Me.Colors.Item(index) = New ColorMSX(index, red, green, blue)
        Else
            Me.Colors.Add(index, New ColorMSX(index, red, green, blue))
        End If
    End Sub



    Public Function GetMSXColor(ByVal index As Integer) As ColorMSX Implements iPaletteMSX.GetMSXColor

        If Me.Colors.ContainsKey(index) Then
            Return Me.Colors.Item(index)
        Else
            Return Nothing
        End If

    End Function



    Public Function GetRGBColor(ByVal index As Integer) As Color Implements iPaletteMSX.GetRGBColor

        Dim aMSXcolor As ColorMSX
        aMSXcolor = Me.Colors.Item(index)

        If index = 0 Then
            ' 0 - transparent. I use a dark grey to contrast with black (1).
            Return Me.ZeroColor
        Else
            Return aMSXcolor.GetRGBColor()
        End If



    End Function



    Public Sub SetData(ByVal data() As Byte) Implements iPaletteMSX.SetData
        'Dim counter As Integer = 2
        Dim red As Byte
        Dim green As Byte
        Dim blue As Byte

        For i As Integer = 1 To 15
            red = (data(i * 2) And 112) / 16
            blue = data(i * 2) And 7
            'counter += 1
            green = data((i * 2) + 1) And 7
            'counter += 1
            Me.Colors.Item(i) = New ColorMSX(i, red, green, blue)
        Next
    End Sub



    ''' <summary>
    ''' Genera un array con los datos de la paleta de colores en formato RB,G
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDataRBG() As Byte() Implements iPaletteMSX.GetDataRBG
        Dim tmpData(31) As Byte
        Dim counter As Integer = 0

        For Each aColor As ColorMSX In Me.Colors.Values
            tmpData(counter) = CByte(aColor.Red * 16 + aColor.Blue)
            counter += 1
            tmpData(counter) = aColor.Green
            counter += 1
        Next

        Return tmpData

    End Function



    ''' <summary>
    ''' Genera un array con los datos de la paleta de colores en formnato R,G,B.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetData() As Byte() Implements iPaletteMSX.GetData
        Dim tmpData(47) As Byte
        Dim counter As Integer = 0
        Dim numColor As Integer = 0

        For Each aColor As ColorMSX In Me.Colors.Values
            tmpData(counter) = aColor.Red
            counter += 1
            tmpData(counter) = aColor.Green
            counter += 1
            tmpData(counter) = aColor.Blue
            counter += 1
        Next

        Return tmpData

    End Function


    Public Shared Function GetRed3(ByVal value As Byte) As Byte
        Dim ColorConversionTable As New List(Of Integer)(New Integer() {0, 36, 73, 109, 146, 182, 219, 255})
        Return ColorConversionTable.IndexOf(value)
    End Function


    Public Shared Function GetGreen3(ByVal value As Byte) As Byte
        Dim ColorConversionTable As New List(Of Integer)(New Integer() {0, 36, 73, 109, 146, 182, 219, 255})
        Return ColorConversionTable.IndexOf(value)
    End Function


    Public Shared Function GetBlue3(ByVal value As Byte) As Byte
        Dim ColorConversionTable As New List(Of Integer)(New Integer() {0, 36, 73, 109, 146, 182, 219, 255})
        Return ColorConversionTable.IndexOf(value)
    End Function


    Public Shared Function GetRed8(ByVal value As Byte) As Byte
        Dim ColorConversionTable As Byte() = New Byte() {0, 36, 73, 109, 146, 182, 219, 255}
        Return ColorConversionTable(value)
    End Function


    Public Shared Function GetGreen8(ByVal value As Byte) As Byte
        Dim ColorConversionTable As Byte() = New Byte() {0, 36, 73, 109, 146, 182, 219, 255}
        Return ColorConversionTable(value)
    End Function


    Public Shared Function GetBlue8(ByVal value As Byte) As Byte
        Dim ColorConversionTable As Byte() = New Byte() {0, 36, 73, 109, 146, 182, 219, 255}
        Return ColorConversionTable(value)
    End Function


End Class
