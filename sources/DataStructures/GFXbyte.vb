Public Class GFXbyte

    Public Pattern As Byte
    Public InkColor As Byte
    Public BGColor As Byte

    Public Property Colors As Byte
        Set(value As Byte)
            Me.InkColor = value >> 4 'And 240) / 16
            Me.BGColor = (value And 15)
        End Set
        Get
            Return (Me.InkColor * 16) + Me.BGColor
        End Get
    End Property



    Public Sub New(ByVal patternValue As Byte, ByVal colorValue As Byte)
        Me.Pattern = patternValue
        Me.Colors = colorValue
    End Sub



    Public Sub New(ByVal patternValue As Byte, ByVal inkValue As Byte, ByVal BGvalue As Byte)
        Me.Pattern = patternValue
        Me.InkColor = inkValue
        Me.BGColor = BGvalue
    End Sub



    Public Function Clone() As GFXbyte
        Return New GFXbyte(Me.Pattern, Me.InkColor, Me.BGColor)
    End Function

End Class
