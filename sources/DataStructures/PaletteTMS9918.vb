Public Class PaletteTMS9918
    Implements iPaletteMSX

    Public _ID As Integer = 0
    Public _Name As String = "TMS9918A_palette"

    Private TMS9918colors As New List(Of Color)


    Property ID() As Integer Implements iPaletteMSX.ID
        Get
            Return Me._ID
        End Get
        Set(ByVal value As Integer)
            'Me._ID = value
        End Set
    End Property


    Property Name() As String Implements iPaletteMSX.Name
        Get
            Return Me._Name
        End Get
        Set(ByVal value As String)
            'Me._Name = value
        End Set
    End Property


    ReadOnly Property Type() As iPaletteMSX.VDP Implements iPaletteMSX.Type
        Get
            Return iPaletteMSX.VDP.TMS9918
        End Get
    End Property



    Public Shadows Enum MSX_Palette As Byte
        Transparent = 0
        Black = 1
        Medium_Green = 2
        Light_Green = 3
        Dark_Blue = 4
        Light_Blue = 5
        Dark_Red = 6
        Cyan = 7
        Medium_Red = 8
        Light_Red = 9
        Dark_Yellow = 10
        Light_Yellow = 11
        Dark_Green = 12
        Magenta = 13
        Gray = 14
        White = 15
    End Enum



    Public Sub New()
        'Me._ID = Me.GetHashCode()
        SetDefault()
    End Sub





    Public Sub SetDefault() Implements iPaletteMSX.SetDefault
        ' set TMS9918A palette based in Sean Young table
        ' http://bifi.msxnet.org/msxnet/tech/tms9918a.txt
        TMS9918colors.Add(Color.FromArgb(33, 33, 44))    ' 0 - transparent. I use a dark grey to contrast with black (1).
        TMS9918colors.Add(Color.FromArgb(0, 0, 0))       ' 1 - dark
        TMS9918colors.Add(Color.FromArgb(33, 200, 66))   ' 2 — medium green
        TMS9918colors.Add(Color.FromArgb(94, 220, 120))  ' 3 — light green
        TMS9918colors.Add(Color.FromArgb(84, 85, 237))   ' 4 — dark blue
        TMS9918colors.Add(Color.FromArgb(125, 118, 252)) ' 5 — light blue
        TMS9918colors.Add(Color.FromArgb(212, 82, 77))   ' 6 — dark red
        TMS9918colors.Add(Color.FromArgb(66, 235, 245))  ' 7 - cyan
        TMS9918colors.Add(Color.FromArgb(252, 85, 84))   ' 8 - medium red
        TMS9918colors.Add(Color.FromArgb(255, 121, 120)) ' 9 - light red
        TMS9918colors.Add(Color.FromArgb(212, 193, 84))  '10 - dark yellow
        TMS9918colors.Add(Color.FromArgb(230, 206, 128)) '11 - light yellow
        TMS9918colors.Add(Color.FromArgb(33, 176, 59))   '12 - dark green
        TMS9918colors.Add(Color.FromArgb(201, 91, 186))  '13 - magenta
        TMS9918colors.Add(Color.FromArgb(204, 204, 204)) '14 - gray
        TMS9918colors.Add(Color.FromArgb(255, 255, 255)) '15 - white
    End Sub



    Public Function Clone() As iPaletteMSX Implements iPaletteMSX.Clone
        Return Nothing
    End Function



    Public Function Copy() As iPaletteMSX Implements iPaletteMSX.Copy
        Return Nothing
    End Function



    Public Sub SetZeroColor(ByVal newColor As Color) Implements iPaletteMSX.SetZeroColor
        TMS9918colors.Item(0) = newColor
    End Sub



    Public Sub SetColor(ByVal index As Integer, ByVal newColor As ColorMSX) Implements iPaletteMSX.SetColor

    End Sub



    Public Function GetMSXColor(ByVal index As Integer) As ColorMSX Implements iPaletteMSX.GetMSXColor
        Return Nothing
    End Function



    ''' <summary>
    ''' Get VB.net Drawing.Color object (RGB) from index in MSX palette
    ''' </summary>
    ''' <param name="colorNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetRGBColor(ByVal colorNumber As Integer) As Color Implements iPaletteMSX.GetRGBColor
        Return Me.TMS9918colors.Item(colorNumber)
    End Function



    Public Sub SetData(ByVal data() As Byte) Implements iPaletteMSX.SetData

    End Sub



    Public Function GetData() As Byte() Implements iPaletteMSX.GetData
        Return Nothing
    End Function



    Public Function GetDataRBG() As Byte() Implements iPaletteMSX.GetDataRBG
        Return Nothing
    End Function



End Class
