''' <summary>
''' Colección de 64 configuraciones de un bloque de tiles de 2x2
''' </summary>
''' <remarks></remarks>
Public Class SupertilesSET

    Public ID As Integer
    Public Name As String
    Public TilesetID As Integer

    Public Data As New ArrayList(63)



    'Public Sub New()

    '    initData()

    '    'Me.ID = Me.GetHashCode() 'genera un identificador
    '    'Me.Name = "squaredset00"

    'End Sub


    Public Sub New(ByVal _ID As Integer, ByVal _name As String, ByVal _tilesetID As Integer)

        initData()

        Me.ID = _ID
        Me.Name = _name
        Me.TilesetID = _tilesetID

    End Sub



    Public Sub New(ByVal _name As String, ByVal _tilesetID As Integer)

        initData()

        Me.ID = Me.GetHashCode() + CInt(Rnd() * 100000) 'genera un identificador
        Me.Name = _name
        Me.TilesetID = _tilesetID

        'Fill(0)

    End Sub


    Public Sub New(ByVal _name As String, ByVal _tilesetID As Integer, ByVal _order As Integer)

        initData()

        Me.ID = Me.GetHashCode() + CInt(Rnd() * 100000) 'genera un identificador
        Me.Name = _name
        Me.TilesetID = _tilesetID

        Order(_order)

    End Sub



    Public Sub New(ByVal _name As String, ByVal _tilesetID As Integer, ByVal _data As ArrayList)

        Me.ID = Me.GetHashCode() + CInt(Rnd() * 100000)
        Me.Name = _name
        Me.TilesetID = _tilesetID

        Me.Data = _data

    End Sub



    ''' <summary>
    ''' Para cuando se obtienen los datos de un fichero
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="_name"></param>
    ''' <param name="_tilesetID"></param>
    ''' <param name="_data"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _ID As Integer, ByVal _name As String, ByVal _tilesetID As Integer, ByVal _data As Byte())

        'initData()

        Me.ID = _ID
        Me.Name = _name
        Me.TilesetID = _tilesetID

        Me.Data.AddRange(_data)

    End Sub



    Private Sub initData()
        For i As Integer = 0 To 63
            Data.Add(New SuperTile(i, 0, 0, 0, 0))
        Next
    End Sub



    Public Function Clone() As SupertilesSET

        Dim cloneObject As New SupertilesSET(Me.Name, Me.TilesetID)

        Dim item As SuperTile


        'cloneObject.ID = cloneObject.GetHashCode()
        'cloneObject.Name = Me.Name
        'cloneObject.TilesetID = Me.TilesetID
        'cloneObject.Data = Me.Data.Clone

        For i As Integer = 0 To 63
            item = Me.Data.Item(i)
            cloneObject.Data.Item(i) = item.Clone
        Next

        Return cloneObject
    End Function




    'Public Sub SetDefault()
    '    Dim numPos As Byte = 0
    '    Dim numTile As Byte = 0
    '    'For Each item As SquaredTile In Data
    '    '    numTile = numPos
    '    '    item.SetData(numTile, numTile + 1, numTile + 32, numTile + 33)
    '    '    numPos += 1
    '    'Next
    '    For i As Integer = 0 To 3
    '        For o As Integer = 0 To 15
    '            numTile = (o * 2) + (i * 64)
    '            Data.Item(numPos) = New SquaredTile(numTile, numTile + 1, numTile + 32, numTile + 33)
    '            numPos += 1
    '        Next
    '    Next
    'End Sub



    Public Sub Clear()
        Me.Name = "squaredset00"

        Order(0)
    End Sub



    Public Sub Order(ByVal order As Integer)

        Select Case order
            Case 1
                FillTilesetOrder()

            Case 2
                FillLinealOrder()

            Case 3
                FillSpriteOrder()

            Case Else
                Fill(0)

        End Select

    End Sub



    Public Sub Fill(ByVal ntile)
        For Each item As SuperTile In Data
            item.SetData(ntile, ntile, ntile, ntile)
        Next
    End Sub


    '  1, 2
    ' 33,34
    Public Sub FillTilesetOrder()

        Dim item As SuperTile
        Dim numSquaredTile As Integer = 0
        Dim numTile As Integer = 0

        For o As Integer = 0 To 3
            numTile = o * 64
            For i As Integer = 0 To 15
                item = Data.Item(numSquaredTile)
                item.SetData(numTile, numTile + 1, numTile + 32, numTile + 33)
                numSquaredTile += 1
                numTile += 2
            Next
        Next
    End Sub


    ' 1,2
    ' 3,4
    Public Sub FillLinealOrder()

        Dim item As SuperTile
        Dim numSquaredTile As Integer = 0
        Dim numTile As Integer = 0

        For o As Integer = 0 To 3
            For i As Integer = 0 To 15
                item = Data.Item(numSquaredTile)
                item.SetData(numTile, numTile + 1, numTile + 2, numTile + 3)
                numSquaredTile += 1
                numTile += 4
            Next
        Next
    End Sub


    ' same as sprite 16x16 VRAM data
    ' 1,3
    ' 2,4
    Public Sub FillSpriteOrder()

        Dim item As SuperTile
        Dim numSquaredTile As Integer = 0
        Dim numTile As Integer = 0

        For o As Integer = 0 To 3
            For i As Integer = 0 To 15
                item = Data.Item(numSquaredTile)
                item.SetData(numTile, numTile + 2, numTile + 1, numTile + 3)
                numSquaredTile += 1
                numTile += 4
            Next
        Next
    End Sub



    Public Sub SetSquaredTile(ByVal item As SuperTile)
        If item.Index < 64 Then
            Me.Data.Item(item.Index) = item
        End If
    End Sub



    Public Sub UpdateSquaredTile(ByVal index As Integer, ByVal item As SuperTile)
        If index < 64 Then
            item.Index = index
            Me.Data.Item(item.Index) = item
        End If
    End Sub



    Public Function GetSquaredTile(ByVal index As Integer) As SuperTile
        If index < 64 Then
            Return Me.Data.Item(index)
        End If
        Return Nothing
    End Function



    Public Function GetSquaredTileBitmapX2(ByVal index As Integer, ByVal _tileset As TilesetMSX) As Bitmap
        Dim _squaredTile As SuperTile = GetSquaredTile(index)
        Return GetSquaredTileBitmapX2(_squaredTile, _tileset)
    End Function



    Public Function GetSquaredTileBitmapX2(ByVal _squaredTile As SuperTile, ByVal _tileset As TilesetMSX) As Bitmap

        Try
            Dim tile As TileMSX

            Dim aBitmap As New Bitmap(32, 32, Imaging.PixelFormat.Format24bppRgb)
            Dim aGraphics As Graphics = Graphics.FromImage(aBitmap)

            'value = (value - (Fix(value / 16) * 16)) * 2 + (Fix(value / 16) * 64)
            ''value = value * 4

            tile = _tileset.GetTile(_squaredTile.UpLeftTile)
            aGraphics.DrawImage(tile.GetBitmapX2, 0, 0, 16, 16)

            tile = _tileset.GetTile(_squaredTile.UpRightTile)
            aGraphics.DrawImage(tile.GetBitmapX2, 16, 0, 16, 16)

            tile = _tileset.GetTile(_squaredTile.DownLeftTile)
            aGraphics.DrawImage(tile.GetBitmapX2, 0, 16, 16, 16)

            tile = _tileset.GetTile(_squaredTile.DownRightTile)
            aGraphics.DrawImage(tile.GetBitmapX2, 16, 16, 16, 16)

            aGraphics.Flush()

            Return aBitmap

        Catch ex As Exception
            Return Nothing
        End Try

    End Function



    Public Function GetData() As Byte()
        Dim data As Byte()
        Dim item As SuperTile

        ReDim data(255)

        For i As Integer = 0 To 63
            item = Me.Data(i)
            item.GetData().CopyTo(data, i * 4)
        Next

        Return data
    End Function



End Class
