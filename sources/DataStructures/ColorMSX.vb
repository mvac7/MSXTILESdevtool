''' <summary>
''' 3 bit RGB MSX color
''' </summary>
''' <remarks></remarks>
Public Class ColorMSX

    Public Index As Integer

    'Public RGBColor As Color

    Public Red As Byte
    Public Green As Byte
    Public Blue As Byte


    ''' <summary>
    ''' 3 bit RGB values
    ''' </summary>
    ''' <param name="anIndex"></param>
    ''' <param name="aRed"></param>
    ''' <param name="aGreen"></param>
    ''' <param name="aBlue"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal anIndex As Integer, ByVal aRed As Byte, ByVal aGreen As Byte, ByVal aBlue As Byte)
        Me.Index = anIndex

        If anIndex = 0 Then
            ' el color 0 siempre es transparente
            Me.Red = 0
            Me.Green = 0
            Me.Blue = 0
            ' uso un tono gris oscuro para diferenciar con el negro
            'Me.RGBColor = get24bitColor(1, 1, 1)
        Else
            Me.Red = aRed
            Me.Green = aGreen
            Me.Blue = aBlue
            'Me.RGBColor = get24bitColor(aRed, aGreen, aBlue)
        End If

    End Sub



    ''' <summary>
    ''' Clone object
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Clone() As ColorMSX
        Return New ColorMSX(Me.Index, Me.Red, Me.Green, Me.Blue)
    End Function



    Public Function GetRGBColor() As Color

        Dim aRed As Byte
        Dim aGreen As Byte
        Dim aBlue As Byte

        If Me.Index = 0 Then
            'aRed = 20
            'aGreen = 20
            'aBlue = 20
            aRed = 33
            aGreen = 33
            aBlue = 44
        Else
            aRed = PaletteV9938.GetRed8(Me.Red)
            aGreen = PaletteV9938.GetGreen8(Me.Green)
            aBlue = PaletteV9938.GetBlue8(Me.Blue)
        End If

        Return Color.FromArgb(aRed, aGreen, aBlue)

    End Function



End Class
