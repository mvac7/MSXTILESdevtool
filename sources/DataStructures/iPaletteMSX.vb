


Public Interface iPaletteMSX

    Shadows Enum VDP As Integer
        'AUTO = 0
        TMS9918 = 1
        V9938 = 2
    End Enum


    Property ID() As Integer
    Property Name() As String
    ReadOnly Property Type() As VDP

    Sub SetDefault()
    Sub SetZeroColor(ByVal newColor As Color)
    Sub SetColor(ByVal index As Integer, ByVal newColor As ColorMSX)
    Sub SetData(ByVal data() As Byte)

    Function Copy() As iPaletteMSX
    Function Clone() As iPaletteMSX
    'Function GetColor(ByVal colorNumber As Integer) As Color 'RGB
    Function GetMSXColor(ByVal index As Integer) As ColorMSX
    Function GetRGBColor(ByVal index As Integer) As Color
    Function GetData() As Byte()
    Function GetDataRBG() As Byte()

End Interface
