''' <summary>
''' Context color selector
''' </summary>
''' <remarks></remarks>
Public Class ColorSelector

    Private PaletteData As iPaletteMSX

    Public ColorSelected As Byte
    'Public ColorIndexSelected As Integer

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
    Public Function ShowWinDialog(ByVal aPaletteData As iPaletteMSX, ByVal winPosition As Point) As DialogResult

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
    ''' display palette in 8x2 table form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GeneratePalette()
        Dim ColorBox As System.Windows.Forms.PictureBox
        Dim index As Byte = 0

        For y As Integer = 0 To 1
            For x As Integer = 0 To 7

                ColorBox = getColorBox(index, x * 16, y * 16, PaletteData.GetRGBColor(index))

                Me.Controls.Add(ColorBox)
                Me.gfxData.Add(ColorBox)
                AddHandler ColorBox.Click, AddressOf Me.colorPalette_Click

                index += 1

            Next
        Next

    End Sub



    ''' <summary>
    ''' updates the colors of the graphic control.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshPalette()
        Dim ColorBox As System.Windows.Forms.PictureBox

        'For Each aColor As ColorMSX In PaletteData.Colors.Values
        For i As Integer = 0 To 15
            'ColorBox = getColorBox(Str(contador), x, y, aColor.RGBColor)

            ColorBox = Me.gfxData.Item(i)

            ColorBox.BackColor = PaletteData.GetRGBColor(i)
        Next

    End Sub



    ''' <summary>
    ''' creates a box to display a color
    ''' </summary>
    ''' <param name="index"></param>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <param name="aColor"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getColorBox(ByVal index As Byte, ByVal x As Integer, ByVal y As Integer, ByVal aColor As Color) As System.Windows.Forms.Control
        Dim ColorBox As System.Windows.Forms.PictureBox
        ColorBox = New System.Windows.Forms.PictureBox
        Me.SuspendLayout()
        ColorBox.BackColor = aColor
        ColorBox.Location = New System.Drawing.Point(x, y)
        ColorBox.Name = Str(index)
        ColorBox.Size = New System.Drawing.Size(16, 16)
        ColorBox.TabIndex = 0
        ColorBox.TabStop = False
        Me.ResumeLayout(False)

        Me.ToolTip1.SetToolTip(ColorBox, "Color " + Str(index))

        Return ColorBox
    End Function



    ''' <summary>
    ''' color selection event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub colorPalette_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim numColor As Byte = CByte(sender.name)

        If numColor < 16 Then 'numColor > 0 And
            Me.ColorSelected = numColor 'Me.PaletteData.GetMSXColor(numColor)
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