Imports System.Windows.Forms
Imports System.Xml
Imports System.IO


''' <summary>
''' Herramienta para la creación de paletas del VDP V9938 o superior.
''' </summary>
''' <remarks></remarks>
Public Class palette512Dialog

    Private newColor As MSXcolor

    Private oldColor As MSXcolor

    Private _PaletteColors As New MSXpalette

    Private _ColorSelected As Integer

    Private undo_type As Integer = 0 ' 0=color, 1=palette
    Private undo_Color As MSXcolor
    Private undo_Palette As MSXpalette

    Private defaultPath As String = ""

    'Private ColorConversionTable As Byte() = New Byte() {0, 36, 73, 109, 146, 182, 219, 255}

    Private paletteBitmap As System.Drawing.Bitmap

    Private PaletteGfxData As New ArrayList


    Public Property PaletteColors() As MSXpalette
        Get
            Return Me._PaletteColors
        End Get
        Set(ByVal value As MSXpalette)
            Me._PaletteColors = value
        End Set
    End Property


    Public Property ColorSelected() As Integer
        Get
            Return Me._ColorSelected
        End Get
        Set(ByVal value As Integer)
            Me._ColorSelected = value
        End Set
    End Property


    Public Property PaletteDefaultPath() As String
        Get
            Return defaultPath
        End Get
        Set(ByVal value As String)
            defaultPath = value
        End Set
    End Property


    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        'ColorConversionTable = New Byte() {6, 32, 72, 104, 144, 176, 216, 247}

        Me.paletteBitmap = New Bitmap(128, 256)
        Me.PalettePictureBox.Image = Me.paletteBitmap



        'OldColorPictureBox.BackColor = aColor

        Me.BackColor = Color.FromArgb(211, 211, 211)

        'Me.PaletteColors.name = "Default_Palette"
        'Me.PaletteNameTextBox.Text = Me.PaletteColors.name
        _PaletteColors.setDefault()

        'Me.newColor = PaletteData.Item(1)
        'Me.oldColor = PaletteData.Item(1)

        GeneratePalette()

        GeneratePaletteMap()

        Me.SetColor(_PaletteColors.Colors.Item(1))

        Me._ColorSelected = 1

    End Sub


    'Private Sub palette512Dialog_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    '    If Not Me.DialogResult = System.Windows.Forms.DialogResult.OK Then
    '        Me.PaletteColors = Me.tempPaletteColors.clone
    '    End If
    'End Sub



    Private Sub palette512Dialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.PaletteNameTextBox.Text = Me._PaletteColors.name
        'PaletteViewerRefresh()
        RedrawPalette()

        Me.undoBut.Enabled = False

    End Sub


    Public Function ShowWinDialog() As DialogResult

        'Me.SetColor(aColor)

        Me.SetColorArrow(Me._ColorSelected)

        Me.undo_Palette = Me._PaletteColors.clone 'copia la paleta para undo

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel

        Me.RedrawPalette()

        Return Me.ShowDialog()

    End Function


    Public Function ShowWinDialog(ByRef newPalette As MSXpalette) As DialogResult

        'Me.SetColor(aColor)

        Me.SetColorArrow(Me._ColorSelected)

        Me._PaletteColors = newPalette

        Me.undo_Palette = newPalette.clone

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel

        Return Me.ShowDialog()

    End Function


    'Public Function ShowWinDialog(ByVal aColor As ColorMSX) As DialogResult

    '    Me.SetColor(aColor)

    '    Me.SetColorArrow(Me.ColorSelected)

    '    Return Me.ShowDialog()

    'End Function


    Public Sub SetColor(ByVal aColor As MSXcolor)

        Me.oldColor = aColor.Clone()
        Me.newColor = aColor.Clone()

        Me.OldColorPictureBox.BackColor = _PaletteColors.getRGB(aColor) '.RGBColor
        Me.ColorPictureBox.BackColor = _PaletteColors.getRGB(aColor) '.RGBColor

        Me.RedTrackBar.Value = aColor.Red
        Me.GreenTrackBar.Value = aColor.Green
        Me.BlueTrackBar.Value = aColor.Blue

        Me.RedTextBox.Text = Me.RedTrackBar.Value
        Me.GreenTextBox.Text = Me.GreenTrackBar.Value
        Me.BlueTextBox.Text = Me.BlueTrackBar.Value

        setTone()
    End Sub



    Public Sub setDefaultPalette()
        _PaletteColors.setDefault()
    End Sub


    'Public Sub SetDefaultPalette()

    '    _PaletteColors.clear()

    '    _PaletteColors.name = "Default Palette"

    '    _PaletteColors.SetColor(0, New ColorMSX(0, 0, 0, 0)) ' 0 — transparent
    '    _PaletteColors.SetColor(1, New ColorMSX(1, 0, 0, 0)) ' 1 — black
    '    _PaletteColors.SetColor(2, New ColorMSX(2, 2, 5, 2)) '  2 — medium green
    '    _PaletteColors.SetColor(3, New ColorMSX(3, 3, 6, 3)) ' 3 — light green
    '    _PaletteColors.SetColor(4, New ColorMSX(4, 2, 2, 5)) ' 4 — dark blue
    '    _PaletteColors.SetColor(5, New ColorMSX(5, 3, 3, 7)) '5 — light blue
    '    _PaletteColors.SetColor(6, New ColorMSX(6, 5, 2, 1)) '6 — dark red
    '    _PaletteColors.SetColor(7, New ColorMSX(7, 2, 6, 7)) '7 — cyan
    '    _PaletteColors.SetColor(8, New ColorMSX(8, 6, 2, 2)) '8 — medium red
    '    _PaletteColors.SetColor(9, New ColorMSX(9, 7, 3, 3)) '9 — light red
    '    _PaletteColors.SetColor(10, New ColorMSX(10, 6, 6, 3)) '10 — dark yellow
    '    _PaletteColors.SetColor(11, New ColorMSX(11, 6, 6, 4)) '11 — light yellow
    '    _PaletteColors.SetColor(12, New ColorMSX(12, 1, 4, 1)) '12 — dark green
    '    _PaletteColors.SetColor(13, New ColorMSX(13, 5, 3, 5)) '13 — magenta
    '    _PaletteColors.SetColor(14, New ColorMSX(14, 6, 6, 6)) '14 — gray
    '    _PaletteColors.SetColor(15, New ColorMSX(15, 7, 7, 7)) '15 - white

    '    Me.PaletteNameTextBox.Text = _PaletteColors.name

    'End Sub


    Private Sub SetColorArrow(ByVal numColor As Byte)

        If numColor > 0 And numColor < 16 Then
            Me.ColorArrowPictureBox.Top = 34 + (numColor * 16)
        End If

    End Sub


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub


    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        undoPalette()
        Application.DoEvents()

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub RedTrackBar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedTrackBar.Scroll
        Me.RedTextBox.Text = RedTrackBar.Value
        showcolor()
        setTone()
    End Sub


    Private Sub GreenTrackBar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GreenTrackBar.Scroll
        Me.GreenTextBox.Text = GreenTrackBar.Value
        showcolor()
        setTone()
    End Sub


    Private Sub BlueTrackBar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BlueTrackBar.Scroll
        Me.BlueTextBox.Text = Me.BlueTrackBar.Value
        showcolor()
        setTone()
    End Sub


    Private _lastTone As Integer = 0


    Private Sub ToneTrackBar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToneTrackBar.Scroll
        Dim tmpValue As Integer
        Dim diferencia As Integer
        Dim newValue As Integer = Me.ToneTrackBar.Value

        Me.ToneTextBox.Text = newValue

        diferencia = newValue - _lastTone

        tmpValue = Me.RedTrackBar.Value + diferencia
        If tmpValue < 0 Then
            tmpValue = 0
        ElseIf tmpValue > 7 Then
            tmpValue = 7
        End If
        Me.RedTrackBar.Value = tmpValue
        Me.RedTextBox.Text = tmpValue


        tmpValue = Me.GreenTrackBar.Value + diferencia
        If tmpValue < 0 Then
            tmpValue = 0
        ElseIf tmpValue > 7 Then
            tmpValue = 7
        End If
        Me.GreenTrackBar.Value = tmpValue
        Me.GreenTextBox.Text = tmpValue


        tmpValue = Me.BlueTrackBar.Value + diferencia
        If tmpValue < 0 Then
            tmpValue = 0
        ElseIf tmpValue > 7 Then
            tmpValue = 7
        End If
        Me.BlueTrackBar.Value = tmpValue
        Me.BlueTextBox.Text = tmpValue

        _lastTone = newValue

        showcolor()

    End Sub


    Private Sub showcolor()

        Dim aRed As Byte = Me.RedTrackBar.Value
        Dim aGreen As Byte = Me.GreenTrackBar.Value
        Dim aBlue As Byte = Me.BlueTrackBar.Value

        Me.ColorPictureBox.BackColor = _PaletteColors.getRGB(aRed, aGreen, aBlue)

        'Me.newColor.RGBColor = get24bitColor(aRed, aGreen, aBlue)
        Me.newColor.Red = aRed
        Me.newColor.Green = aGreen
        Me.newColor.Blue = aBlue

    End Sub


    'Private Function get24bitColor(ByVal msxRed As Byte, ByVal msxGreen As Byte, ByVal msxBlue As Byte) As Color

    '    Dim aRed As Byte = ColorConversionTable(msxRed)
    '    Dim aGreen As Byte = ColorConversionTable(msxGreen)
    '    Dim aBlue As Byte = ColorConversionTable(msxBlue)

    '    Return Color.FromArgb(aRed, aGreen, aBlue)

    'End Function


    Private Sub setTone()
        Dim aRed As Byte = RedTrackBar.Value
        Dim aGreen As Byte = GreenTrackBar.Value
        Dim aBlue As Byte = BlueTrackBar.Value

        Dim media As Byte = (aRed + aGreen + aBlue) / 3
        Me.ToneTrackBar.Value = media
        Me.ToneTextBox.Text = media
        Me._lastTone = media
    End Sub



    Private Sub GeneratePaletteMap()

        Dim y As Byte = 0

        For aGreen As Byte = 0 To 7
            For aBlue As Byte = 0 To 7

                For aRed As Byte = 0 To 7
                    setPoint(aRed, y, _PaletteColors.getRGB(aRed, aGreen, aBlue))
                Next
                y += 1
            Next
        Next
    End Sub


    Private Sub setPoint(ByVal x As Integer, ByVal y As Integer, ByVal aColor As System.Drawing.Color)
        Dim posx As Integer = 0
        Dim posy As Integer = 0

        x = x * 16
        posy = y * 4

        For o As Byte = 0 To 3
            posx = x
            For i As Integer = 0 To 15
                Me.paletteBitmap.SetPixel(posx, posy, aColor)
                posx += 1
            Next
            posy += 1
        Next
    End Sub




    Private Sub GeneratePalette()
        Dim ColorBox As System.Windows.Forms.PictureBox
        Dim contador As Integer = 0

        For Each aColor As MSXcolor In _PaletteColors.Colors.Values

            ColorBox = getColorBox(Str(contador), 16, 34 + (contador * 16), _PaletteColors.getRGB(aColor)) '.RGBColor)

            Me.PalettePanel.Controls.Add(ColorBox)
            Me.PaletteGfxData.Add(ColorBox)
            AddHandler ColorBox.Click, AddressOf Me.colorPalette_Click

            contador += 1
        Next

    End Sub


    Private Function getColorBox(ByVal id As String, ByVal x As Integer, ByVal y As Integer, ByVal aColor As Color) As System.Windows.Forms.Control
        Dim ColorBox As System.Windows.Forms.PictureBox
        ColorBox = New System.Windows.Forms.PictureBox
        Me.SuspendLayout()
        ColorBox.BackColor = aColor
        ColorBox.Location = New System.Drawing.Point(x, y)
        ColorBox.Name = id
        ColorBox.Size = New System.Drawing.Size(32, 15)
        ColorBox.TabIndex = 0
        ColorBox.TabStop = False
        Me.ResumeLayout(False)

        Me.ToolTip1.SetToolTip(ColorBox, "Color " + id)

        Return ColorBox
    End Function







    



    '6,32,72,104,144,176,216,247
    'Private Function Get3BitFrom8Bit(ByVal colorValue As Byte) As Byte
    '    Dim output As Byte = 0
    '    For i As Byte = 0 To 7
    '        If colorValue = ColorConversionTable(i) Then
    '            output = i
    '            Exit For
    '        End If
    '    Next

    '    Return output

    'End Function



    Private Sub PalettePictureBox_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PalettePictureBox.MouseClick
        Try
            Dim aColor As Color
            aColor = Me.paletteBitmap.GetPixel(e.X, e.Y)

            Me.RedTrackBar.Value = Me._PaletteColors.RedColorConversionTable.IndexOf(aColor.R)  'Me.Get3BitFrom8Bit(aColor.R)
            Me.GreenTrackBar.Value = Me._PaletteColors.GreenColorConversionTable.IndexOf(aColor.G)   'Me.Get3BitFrom8Bit(aColor.G)
            Me.BlueTrackBar.Value = Me._PaletteColors.BlueColorConversionTable.IndexOf(aColor.B)   'Me.Get3BitFrom8Bit(aColor.B)

            Me.RedTextBox.Text = Me.RedTrackBar.Value
            Me.GreenTextBox.Text = Me.GreenTrackBar.Value
            Me.BlueTextBox.Text = Me.BlueTrackBar.Value

            showcolor()

            Me.Refresh()

        Catch ex As Exception

        End Try
    End Sub



    



    Private Sub colorPalette_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim numColor As Integer = CInt(sender.name)
        Dim aColor As MSXcolor

        If numColor > 0 And numColor < 16 Then
            aColor = Me._PaletteColors.GetColor(numColor)
            Me.SetColor(aColor)
            Me.SetColorArrow(numColor)
            Me._ColorSelected = numColor
        End If

    End Sub



    Private Sub UpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateButton.Click

        Dim ColorBox As System.Windows.Forms.PictureBox

        ColorBox = PaletteGfxData.Item(_ColorSelected)
        ColorBox.BackColor = _PaletteColors.getRGB(newColor) '.RGBColor

        Me.undo_Color = _PaletteColors.GetColor(_ColorSelected).Clone
        Me.undoBut.Enabled = True
        Me.undo_type = 0

        Me._PaletteColors.SetColor(_ColorSelected, newColor)


    End Sub



    Private Sub RestoreButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestoreButton.Click
        SetColor(Me.oldColor)
    End Sub



    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DefaultPaletteButton.Click
        Dim numColor As Integer = 0
        Dim aColor As MSXcolor
        Dim result As DialogResult

        result = MessageBox.Show("This option will delete the information from the current palette." + vbCrLf + " Are you sure?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = Windows.Forms.DialogResult.Yes Then
            Me.undo_Palette = Me._PaletteColors.clone 'copia la paleta para undo
            Me.undoBut.Enabled = True
            Me.undo_type = 1

            _PaletteColors.setDefault()

            'PaletteViewerRefresh()
            RedrawPalette()

            aColor = Me._PaletteColors.GetColor(Me._ColorSelected)
            Me.SetColor(aColor)
            Me.SetColorArrow(Me._ColorSelected)

        End If

    End Sub



    Public Sub SaveFile()
        Dim resultado As System.Windows.Forms.DialogResult

        Me.SaveFileDialog1.FileName = Me._PaletteColors.name
        Me.SaveFileDialog1.DefaultExt = "xpal"
        Me.SaveFileDialog1.Filter = "MSX Palette file|*.xpal"

        If Not Me.defaultPath = "" Then
            Me.SaveFileDialog1.InitialDirectory = Me.defaultPath
        End If

        resultado = SaveFileDialog1.ShowDialog()

        If resultado = Windows.Forms.DialogResult.OK Then

            Me.defaultPath = Path.GetDirectoryName(SaveFileDialog1.FileName)
            'System.IO.Directory.GetParent(SaveFileDialog1.FileName).FullName

            Me.SaveData(SaveFileDialog1.FileName)

        End If

    End Sub


    ''' <summary>
    ''' Guarda los datos de la paleta.
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <remarks></remarks>
    Private Sub SaveData(ByVal filePath As String)
        'Try

        Dim aXmlDoc As New XmlDocument
        Dim rootElement As XmlElement

        ' crea el nodo root
        rootElement = aXmlDoc.CreateElement("msxdevtools")
        aXmlDoc.AppendChild(rootElement)

        'anAttribute = aXmlDoc.CreateAttribute("version")
        'anAttribute.Value = Version
        'rootElement.SetAttributeNode(anAttribute)

        rootElement.AppendChild(getPaletteElement(aXmlDoc))

        aXmlDoc.Save(filePath)

    End Sub


    ''' <summary>
    ''' Proporciona el elemento con toda la información de la paleta para guardar en un fichero de datos.
    ''' </summary>
    ''' <param name="aXmlDoc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getPaletteElement(ByRef aXmlDoc As XmlDocument) As XmlElement

        Dim anElement As XmlElement
        Dim anItemElement As XmlElement
        Dim anAttribute As XmlAttribute

        anElement = aXmlDoc.CreateElement("palette")

        anAttribute = aXmlDoc.CreateAttribute("name")
        anAttribute.Value = Me._PaletteColors.Name
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("group")
        anAttribute.Value = Me._PaletteColors.Group
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("version")
        anAttribute.Value = Me._PaletteColors.Version
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("author")
        anAttribute.Value = Me._PaletteColors.Author
        anElement.SetAttributeNode(anAttribute)


        For Each aColor As MSXcolor In Me._PaletteColors.Colors.Values
            anItemElement = aXmlDoc.CreateElement("color")
            anElement.AppendChild(anItemElement)

            anAttribute = aXmlDoc.CreateAttribute("id")
            anAttribute.Value = aColor.id
            anItemElement.SetAttributeNode(anAttribute)

            anAttribute = aXmlDoc.CreateAttribute("red")
            anAttribute.Value = aColor.Red
            anItemElement.SetAttributeNode(anAttribute)

            anAttribute = aXmlDoc.CreateAttribute("green")
            anAttribute.Value = aColor.Green
            anItemElement.SetAttributeNode(anAttribute)

            anAttribute = aXmlDoc.CreateAttribute("blue")
            anAttribute.Value = aColor.Blue
            anItemElement.SetAttributeNode(anAttribute)
        Next

        Return anElement

    End Function


    ''' <summary>
    ''' Muestra un dialogo para cargar una paleta.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadFile()
        Dim resultado As System.Windows.Forms.DialogResult

        Me.OpenFileDialog1.DefaultExt = "xpal"
        Me.OpenFileDialog1.Filter = "MSX Palette file|*.xpal|Sprite file|*.xspr"

        If Not Me.defaultPath = "" Then
            Me.OpenFileDialog1.InitialDirectory = Me.defaultPath
        End If

        resultado = Me.OpenFileDialog1.ShowDialog

        If resultado = Windows.Forms.DialogResult.OK Then

            Me.undo_Palette = Me._PaletteColors.clone 'copia la paleta para undo

            Me.defaultPath = Path.GetDirectoryName(OpenFileDialog1.FileName)
            'System.IO.Directory.GetParent(OpenFileDialog1.FileName).FullName

            Me.LoadPalette(OpenFileDialog1.FileName)

            Me.PaletteNameTextBox.Text = Me._PaletteColors.name
            RedrawPalette()

            Me.undoBut.Enabled = True
            Me.undo_type = 1

        End If

    End Sub


    ''' <summary>
    ''' Carga una paleta.
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <remarks></remarks>
    Public Sub LoadPalette(ByVal filePath As String)
        Dim aXmlDoc As New XmlDocument

        Dim aDataNode As XmlNode


        aXmlDoc.Load(filePath)


        If aXmlDoc.GetElementsByTagName("msxdevtools").Count > 0 Then

            aDataNode = aXmlDoc.SelectSingleNode("msxdevtools/palette") ' comprueba si contiene datos de la paleta
            If Not aDataNode Is Nothing Then

                SetPaletteFromNode(aDataNode)

            Else
                ' no contiene datos de la paleta
            End If

        Else

            'No es un fichero de tipo msxdevtools

        End If

    End Sub


    ''' <summary>
    ''' Lee los datos de la paleta a partir de un nodo de un docuemento XML.
    ''' </summary>
    ''' <param name="aDataNode"></param>
    ''' <remarks></remarks>
    Public Sub SetPaletteFromNode(ByVal aDataNode As XmlNode)

        Dim aNode As XmlNode
        Dim anAttribute As XmlAttribute
        Dim aNodeList As XmlNodeList

        Dim tmpPalette As New MSXpalette
        Dim id As Integer
        Dim red As Integer
        Dim green As Integer
        Dim blue As Integer

        aNode = aDataNode.SelectSingleNode("@name")
        If aNode Is Nothing Then
            tmpPalette.Name = ""
        Else
            tmpPalette.Name = aNode.InnerText
        End If

        aNode = aDataNode.SelectSingleNode("@version")
        If aNode Is Nothing Then
            tmpPalette.Version = ""
        Else
            tmpPalette.Version = aNode.InnerText
        End If

        aNode = aDataNode.SelectSingleNode("@group")
        If aNode Is Nothing Then
            tmpPalette.Group = ""
        Else
            tmpPalette.Group = aNode.InnerText
        End If

        aNode = aDataNode.SelectSingleNode("@author")
        If aNode Is Nothing Then
            tmpPalette.Author = ""
        Else
            tmpPalette.Author = aNode.InnerText
        End If

        aNodeList = aDataNode.SelectNodes("color")
        For Each anItemElement As XmlElement In aNodeList

            anAttribute = anItemElement.GetAttributeNode("id")
            If anAttribute Is Nothing Then

            Else
                id = anAttribute.InnerText
            End If

            anAttribute = anItemElement.GetAttributeNode("red")
            If anAttribute Is Nothing Then
                red = 0
            Else
                red = anAttribute.InnerText
            End If

            anAttribute = anItemElement.GetAttributeNode("green")
            If anAttribute Is Nothing Then
                green = 0
            Else
                green = anAttribute.InnerText
            End If

            anAttribute = anItemElement.GetAttributeNode("blue")
            If anAttribute Is Nothing Then
                blue = 0
            Else
                blue = anAttribute.InnerText
            End If

            tmpPalette.SetColor(id, red, green, blue)

        Next

        Me._PaletteColors.clear()
        Me._PaletteColors = tmpPalette.clone

    End Sub


    Private Sub LoadPaletteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadPaletteButton.Click
        LoadFile()
    End Sub



    Private Sub SavePaletteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SavePaletteButton.Click
        SaveFile()
    End Sub



    Private Sub PaletteNameTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaletteNameTextBox.TextChanged

        Me._PaletteColors.name = sender.text

    End Sub



    Private Sub copyBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles copyBut.Click
        Dim aColorWinSelector As ColorWinSelector
        Dim result As DialogResult

        Me.undo_Palette = Me._PaletteColors.clone 'copia la paleta para undo

        aColorWinSelector = New ColorWinSelector(0, Me._PaletteColors)

        result = aColorWinSelector.ShowDialog()

        If result = Windows.Forms.DialogResult.OK Then
            Me.undoBut.Enabled = True
            Me.undo_type = 1
            RedrawPalette()
        Else
            undoPalette()
            Me.undoBut.Enabled = False
        End If

    End Sub



    Private Sub changeBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles changeBut.Click
        Dim aColorWinSelector As ColorWinSelector
        Dim result As DialogResult

        Me.undo_Palette = Me._PaletteColors.clone 'copia la paleta para undo

        aColorWinSelector = New ColorWinSelector(1, Me._PaletteColors)

        result = aColorWinSelector.ShowDialog()

        If result = Windows.Forms.DialogResult.OK Then
            Me.undoBut.Enabled = True
            Me.undo_type = 1
            RedrawPalette()
        Else
            undoPalette()
            Me.undoBut.Enabled = False
        End If

    End Sub



    Private Sub undoBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles undoBut.Click

        If Me.undo_type = 0 Then

            undoColor()

        Else

            undoPalette()

        End If

        Me.undoBut.Enabled = False

    End Sub



    Private Sub undoColor()
        Dim ColorBox As System.Windows.Forms.PictureBox

        ColorBox = PaletteGfxData.Item(Me.undo_Color.id)
        ColorBox.BackColor = _PaletteColors.getRGB(Me.undo_Color) '.RGBColor

        Me._PaletteColors.SetColor(Me.undo_Color.id, Me.undo_Color.Clone)
    End Sub


    ''' <summary>
    ''' recupera la ultima paleta
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub undoPalette()
        If Not Me.undo_Palette Is Nothing Then
            Me._PaletteColors = Me.undo_Palette.clone
            Me.PaletteNameTextBox.Text = Me._PaletteColors.name
            RedrawPalette()
        End If
    End Sub


    ''' <summary>
    ''' Actualiza la representacion de la lista de los 16 colores de la paleta 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RedrawPalette()
        For Each ColorBox As PictureBox In PaletteGfxData
            ColorBox.BackColor = _PaletteColors.getRGB(Me._PaletteColors.GetColor(CInt(ColorBox.Name))) '.RGBColor
        Next
    End Sub


    'Private Sub PaletteViewerRefresh()
    '    For Each ColorBox As PictureBox In PaletteGfxData
    '        ColorBox.BackColor = Me.PaletteColors.GetColor(CInt(ColorBox.Name)).RGBColor
    '    Next
    'End Sub

    Private ttipcolor As Color = Color.Black
    Private Sub PalettePictureBox_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PalettePictureBox.MouseMove
        'Dim x As Integer = Fix((e.X) / 8)
        'Dim y As Integer = Fix((e.Y) / 8)
        Try

            Dim aColor As Color = Me.paletteBitmap.GetPixel(e.X, e.Y)

            If Not ttipcolor = aColor Then
                'Dim textValue As String = "Color [R=" & Str(Get3BitFrom8Bit(aColor.R)) & ", G=" & Str(Get3BitFrom8Bit(aColor.G)) & ", B=" & Str(Get3BitFrom8Bit(aColor.B)) & "]"

                Dim textValue As String = "Color [R=" + CStr(Me._PaletteColors.RedColorConversionTable.IndexOf(aColor.R))
                textValue = textValue + ", G=" + CStr(Me._PaletteColors.GreenColorConversionTable.IndexOf(aColor.G))
                textValue = textValue + ", B=" + CStr(Me._PaletteColors.BlueColorConversionTable.IndexOf(aColor.B))
                textValue = textValue + "]"

                Me.ToolTip1.SetToolTip(PalettePictureBox, textValue)
                'Me.ToolTip1.Show(textValue, PalettePictureBox)

                ttipcolor = aColor

            End If
            

        Catch ex As Exception

        End Try

    End Sub



End Class
