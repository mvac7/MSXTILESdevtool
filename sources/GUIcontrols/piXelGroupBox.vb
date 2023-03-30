Imports System.Drawing.Imaging

Public Class piXelGroupBox

    Private tilesetBitmap As Bitmap

    Private charSize As Byte() = {6, 3, 4, 6, 6, 7, 8, 4, 5, 5, 7, 7, 3, 6, 3, 8, 7, 4, 7, 6, 7, 7, 7, 7, 7, 7, 3, 3, 5, 5, 5, 7,
                                  8, 7, 7, 6, 7, 7, 7, 7, 7, 3, 7, 7, 6, 8, 7, 7, 7, 7, 7, 7, 7, 7, 7, 8, 8, 7, 7, 4, 8, 4, 6, 7,
                                  6, 7, 7, 6, 7, 7, 6, 7, 7, 3, 4, 7, 3, 8, 7, 7, 7, 7, 6, 6, 7, 7, 7, 8, 8, 7, 7, 6, 6, 6, 6, 6}



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

        Dim lineColor As Color
        Dim charColor As Color

        Dim charAttributes As ImageAttributes

        Dim linePen As Pen
        Dim posX As Integer = 2
        Dim posY As Integer = 8
        Dim boxWidth As Integer = Me.Width - 2
        Dim boxHeight As Integer = Me.Height - 2

        Dim aChar As Integer
        Dim charBitmap As Bitmap

        Dim posChar As Integer = 12

        'Dim imageAttributes = New ImageAttributes()
        'Dim colorMap = New ColorMap()
        'Dim remapTable(0) As ColorMap

        If Me.Enabled Then
            lineColor = Color.FromArgb(70, 70, 70)
            charColor = Color.FromArgb(255, 42, 83, 138)
        Else
            lineColor = Color.LightGray
            charColor = Color.FromArgb(180, 42, 83, 138)
        End If

        linePen = New Pen(lineColor, 4)
        charAttributes = GetAttributeColors(charColor)

        e.Graphics.FillRectangle(New SolidBrush(Color.LightGray), posX, posY, boxWidth - 2, boxHeight)

        If Me.Enabled Then
            e.Graphics.DrawLine(linePen, posX, posY, 10, posY)
        Else
            e.Graphics.DrawLine(linePen, posX, posY, boxWidth, posY)
        End If

        e.Graphics.DrawLine(linePen, posX, posY, posX, boxHeight)
        e.Graphics.DrawLine(linePen, boxWidth, posY, boxWidth, boxHeight)
        e.Graphics.DrawLine(linePen, posX, boxHeight, boxWidth, boxHeight)

        If Not Me.Text = "" Then
            For i = 0 To Me.Text.Length - 1

                aChar = AscW(Me.Text.Chars(i))
                charBitmap = GetTile(aChar)
                'e.Graphics.DrawImage(charBitmap, posChar, 0, 16, 16)
                'e.Graphics.DrawImage(tilesetBitmap, New Rectangle(posX * 16, posY * 16, 16, 16), charX * 16, charY * 16, 16, 16, GraphicsUnit.Pixel, charAttributes)
                e.Graphics.DrawImage(charBitmap, New Rectangle(posChar, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel, charAttributes)
                posChar += (charSize(aChar - 32) * 2)

            Next
        End If

        If Me.Enabled Then
            e.Graphics.DrawLine(linePen, posChar + 4, posY, boxWidth, posY)
        End If

    End Sub



    Private Function GetTile(ByVal nchar As Integer) As Bitmap
        ' This function creates a cropped instance of the input bitmap, at coordiates and of the size specified.
        nchar -= 32
        Dim posY As Short = Fix(nchar / 32)
        Dim posX As Short = nchar - (posY * 32)
        Dim rect As New Rectangle(posX * 16, posY * 16, 16, 16)
        Return Me.tilesetBitmap.Clone(rect, Me.tilesetBitmap.PixelFormat)
    End Function



    Private Function GetAttributeColors(ByVal inkColor As Color) As ImageAttributes

        Dim imageAttributes = New ImageAttributes()
        Dim colorItem = New ColorMap()
        Dim colorBG = New ColorMap()
        Dim remapTable(0) As ColorMap

        colorItem.OldColor = Color.FromArgb(255, 42, 83, 138)
        colorItem.NewColor = inkColor
        remapTable(0) = colorItem

        'colorBG.OldColor = Color.FromArgb(0, 255, 255, 255) 'transparent background color in bitmap
        'colorBG.NewColor = Color.Transparent
        'remapTable(1) = colorBG

        imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap)

        Return imageAttributes

    End Function



End Class
