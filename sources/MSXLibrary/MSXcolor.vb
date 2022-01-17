''' <summary>
''' 3 bit RGB MSX color
''' </summary>
''' <remarks></remarks>
Public Class MSXcolor

    Public id As Integer

    'Public RGBColor As Color

    Public Red As Byte
    Public Green As Byte
    Public Blue As Byte


    ''' <summary>
    ''' 3 bit RGB values
    ''' </summary>
    ''' <param name="anID"></param>
    ''' <param name="aRed"></param>
    ''' <param name="aGreen"></param>
    ''' <param name="aBlue"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal anID As Integer, ByVal aRed As Byte, ByVal aGreen As Byte, ByVal aBlue As Byte)
        Me.id = anID

        If anID = 0 Then
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
    Public Function Clone() As MSXcolor
        Return New MSXcolor(Me.id, Me.Red, Me.Green, Me.Blue)
    End Function


End Class
