Public Class piXelGroupBox

    Private tilesetBitmap As Bitmap

    Private charSize As Byte() = {6, 3, 4, 6, 6, 7, 8, 4, 5, 5, 7, 7, 3, 6, 3, 8, 7, 4, 7, 6, 7, 7, 7, 7, 7, 7, 3, 3, 5, 5, 5, 7,
                                  8, 7, 7, 6, 7, 7, 7, 7, 7, 3, 7, 7, 6, 8, 7, 7, 7, 7, 7, 7, 7, 7, 7, 8, 8, 7, 7, 4, 8, 4, 6, 7,
                                  6, 7, 7, 6, 7, 7, 6, 7, 7, 3, 4, 7, 3, 8, 7, 7, 7, 7, 6, 6, 7, 7, 7, 8, 8, 7, 7, 6, 6, 6, 6, 6}
    '                                      c        f  g  h  i  j  k  l  m              r  s 

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.Padding = New System.Windows.Forms.Padding(10)

        Me.tilesetBitmap = piXelS_font.Image
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        'MyBase.OnPaint(e)

        'Agregue su código personalizado de dibujo aquí

        'e.Graphics.DrawImage(this.picture, this.pictureLocation);

        Dim linePen = New Pen(Color.FromArgb(70, 70, 70), 4)
        Dim posX As Integer = 2
        Dim posY As Integer = 8
        Dim boxWidth As Integer = Me.Width - 2
        Dim boxHeight As Integer = Me.Height - 2

        Dim aChar As Integer
        Dim charBitmap As Bitmap

        Dim posChar As Integer = 12

        e.Graphics.FillRectangle(New SolidBrush(Color.LightGray), posX, posY, boxWidth - 2, boxHeight)

        e.Graphics.DrawLine(linePen, posX, posY, 10, posY)
        e.Graphics.DrawLine(linePen, posX, posY, posX, boxHeight)
        e.Graphics.DrawLine(linePen, boxWidth, posY, boxWidth, boxHeight)
        e.Graphics.DrawLine(linePen, posX, boxHeight, boxWidth, boxHeight)

        If Not Me.Text = "" Then
            For i = 0 To Me.Text.Length - 1

                aChar = AscW(Me.Text.Chars(i))
                charBitmap = GetTile(aChar)
                e.Graphics.DrawImage(charBitmap, posChar, 0, 16, 16)
                posChar += (charSize(aChar - 32) * 2)

            Next
        End If

        e.Graphics.DrawLine(linePen, posChar + 4, posY, boxWidth, posY)

    End Sub


    Private Function GetTile(ByVal nchar As Integer) As Bitmap
        ' This function creates a cropped instance of the input bitmap, at coordiates and of the size specified.
        nchar -= 32
        Dim posY As Short = Fix(nchar / 32)
        Dim posX As Short = nchar - (posY * 32)
        Dim rect As New Rectangle(posX * 16, posY * 16, 16, 16)
        Return Me.tilesetBitmap.Clone(rect, Me.tilesetBitmap.PixelFormat) 'New Rectangle(nchar * 16, 16, 16, 16)
    End Function

End Class
