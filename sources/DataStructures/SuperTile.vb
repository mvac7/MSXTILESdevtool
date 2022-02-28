''' <summary>
''' Configuración de 2x2 tiles
''' </summary>
''' <remarks></remarks>
Public Class SuperTile

    Public Index As Byte

    Public UpLeftTile As Byte = 0
    Public UpRightTile As Byte = 0
    Public DownLeftTile As Byte = 0
    Public DownRightTile As Byte = 0



    Public Sub New(_index As Byte, ByVal upLeft As Byte, ByVal upRight As Byte, ByVal downLeft As Byte, ByVal downRight As Byte)
        SetData(upLeft, upRight, downLeft, downRight)
    End Sub



    Public Sub SetData(ByVal upLeft As Byte, ByVal upRight As Byte, ByVal downLeft As Byte, ByVal downRight As Byte)
        Me.UpLeftTile = upLeft
        Me.UpRightTile = upRight
        Me.DownLeftTile = downLeft
        Me.DownRightTile = downRight
    End Sub



    Public Function Clone() As SuperTile
        Return New SuperTile(Me.Index, Me.UpLeftTile, Me.UpRightTile, Me.DownLeftTile, Me.DownRightTile)
    End Function


    Public Function GetData() As Array
        Dim data(3) As Byte

        data(0) = Me.UpLeftTile
        data(1) = Me.UpRightTile
        data(2) = Me.DownLeftTile
        data(3) = Me.DownRightTile

        Return data
    End Function


End Class
