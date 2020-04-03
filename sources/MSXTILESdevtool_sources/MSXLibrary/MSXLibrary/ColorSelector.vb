''' <summary>
''' Context color selector
''' </summary>
''' <remarks></remarks>
Public Class ColorSelector

    Private PaletteData As MSXpalette

    Public ColorSelected As MSXcolor
    Public ColorIndexSelected As Integer

    Private gfxData As New ArrayList


    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().


    End Sub


    ''' <summary>
    ''' Displays the selector.
    ''' </summary>
    ''' <param name="aPaletteData"></param>
    ''' <param name="winPosition"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ShowWinDialog(ByVal aPaletteData As MSXpalette, ByVal winPosition As Point) As DialogResult

        If aPaletteData Is Nothing Then
            ' en el caso de que no exista la paleta
            Return Windows.Forms.DialogResult.Cancel

        End If

        Me.PaletteData = aPaletteData

        If gfxData.Count = 0 Then
            GeneratePalette()
        Else
            RefreshPalette()
        End If

        Me.Location = winPosition

        Return Me.ShowDialog()

    End Function


    ''' <summary>
    ''' display palette in 2x8 table form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GeneratePalette()
        Dim ColorBox As System.Windows.Forms.PictureBox
        Dim contador As Integer = 0
        Dim x As Integer = 0
        Dim y As Integer = 0

        For Each aColor As MSXcolor In PaletteData.Colors.Values
            ColorBox = getColorBox(Str(contador), x, y, PaletteData.getRGB(aColor))

            Me.Controls.Add(ColorBox)
            Me.gfxData.Add(ColorBox)
            AddHandler ColorBox.Click, AddressOf Me.colorPalette_Click

            contador += 1
            x += 16
            If contador = 8 Then
                y = 16
                x = 0
            End If

        Next

    End Sub


    ''' <summary>
    ''' updates the colors of the graphic control.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshPalette()
        Dim ColorBox As System.Windows.Forms.PictureBox

        For Each aColor As MSXcolor In PaletteData.Colors.Values
            'ColorBox = getColorBox(Str(contador), x, y, aColor.RGBColor)

            ColorBox = Me.gfxData.Item(aColor.id)

            ColorBox.BackColor = PaletteData.getRGB(aColor) '.RGBColor

        Next

    End Sub



    ''' <summary>
    ''' creates a box to display a color
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <param name="aColor"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getColorBox(ByVal id As String, ByVal x As Integer, ByVal y As Integer, ByVal aColor As Color) As System.Windows.Forms.Control
        Dim ColorBox As System.Windows.Forms.PictureBox
        ColorBox = New System.Windows.Forms.PictureBox
        Me.SuspendLayout()
        ColorBox.BackColor = aColor
        ColorBox.Location = New System.Drawing.Point(x, y)
        ColorBox.Name = id
        ColorBox.Size = New System.Drawing.Size(16, 16)
        ColorBox.TabIndex = 0
        ColorBox.TabStop = False
        Me.ResumeLayout(False)

        Me.ToolTip1.SetToolTip(ColorBox, "Color " + id)

        Return ColorBox
    End Function


    ''' <summary>
    ''' color selection event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub colorPalette_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim numColor As Integer = CInt(sender.name)
        'Dim aColor As ColorMSX

        If numColor < 16 Then 'numColor > 0 And
            Me.ColorSelected = Me.PaletteData.GetColor(numColor)
            Me.ColorIndexSelected = numColor
            '    aColor = Me.PaletteData.Item(numColor)
            '    Me.SetColor(aColor)
            '    Me.SetColorArrow(numColor)
            '    Me.ColorSelected = numColor
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()

        End If

    End Sub



    ''' <summary>
    ''' cancel button event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitButton.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    ''' <summary>
    ''' Esc key cancel selection
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ColorSelector_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

End Class