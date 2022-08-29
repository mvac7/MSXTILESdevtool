Public Class BitmapConverterDialog

    Private aBitmap As Bitmap

    Private tmpVRAM(&H3FFF) As Byte

    Private _ProgressController As ProgressController

    Public ToleranceDefaultValue As Short = 0
    Public DetailDefaultValue As Short = 32

    Private _ConversionType As CONVERSION_TYPE


    Private Enum CONVERSION_TYPE As Integer
        SIMPLE
        ADVANCED
    End Enum




    Public ReadOnly Property VRAM As Byte()
        Get
            Return tmpVRAM
        End Get
    End Property




    Public Sub New(ByVal pictureName As String, ByRef newImage As Image)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me.TMS9918Aviewer.Palette = New PaletteTMS9918
        Me.TMS9918Aviewer.ViewMode = TMS9918A.VIEW_MODE.TILESET

        Me.BGColorButton.Palette = Me.TMS9918Aviewer.Palette
        Me.BorderColorButton.Palette = Me.TMS9918Aviewer.Palette

        Me.BorderColorButton.SetColor(4)

        Me.PictureNameTextBox.Text = pictureName

        Me.aBitmap = New Bitmap(newImage.Clone, 256, 192)
        Me.ViewPictureBox.Image = Me.aBitmap

        InitBitmap()

    End Sub




    Public Sub New(ByVal pictureName As String, ByRef newBitmap As Bitmap)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me.TMS9918Aviewer.Palette = New PaletteTMS9918
        Me.TMS9918Aviewer.ViewMode = TMS9918A.VIEW_MODE.TILESET

        Me.BGColorButton.Palette = Me.TMS9918Aviewer.Palette
        Me.BorderColorButton.Palette = Me.TMS9918Aviewer.Palette

        Me.BorderColorButton.SetColor(4)

        Me.PictureNameTextBox.Text = pictureName

        Me.aBitmap = newBitmap.Clone
        Me.ViewPictureBox.Image = Me.aBitmap

        InitBitmap()

    End Sub




    Private Sub LoadBitmapDialog_Load(sender As Object, e As EventArgs) Handles Me.Load

        SetConverter(CONVERSION_TYPE.SIMPLE)

        AdvancedPanel.Location = SimplePanel.Location
        SimplePanel.Size = AdvancedPanel.Size

        Me.Size = New Size(Me.Size.Width, 570)


        Me.ToleranceTrackBar.Value = Me.ToleranceDefaultValue
        Me.DetailTrackBar.Value = Me.DetailDefaultValue

        Me.ToleranceTextBox.Text = CStr(Me.ToleranceTrackBar.Value)
        Me.DetailTextBox.Text = CStr(Me.DetailTrackBar.Value)


        'Me.BGColorButton.SetColor(4)

        Me.TMS9918Aviewer.BorderColor = Me.BorderColorButton.SelectedColor
        Me.TMS9918Aviewer.Initialize()

    End Sub



    Private Sub BitmapConverterDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me._ProgressController = New ProgressController(Me)
    End Sub



    Private Sub SetConverter(ByVal type As CONVERSION_TYPE)

        Me.TMS9918Aviewer.Clear()
        Me.TMS9918Aviewer.BorderColor = Me.BorderColorButton.SelectedColor
        'Me.TMS9918Aviewer.FillVRAM(iVDP.TableBase.GRPCOL, &H1800, &HF4)
        Me.TMS9918Aviewer.RefreshScreen()

        If type = CONVERSION_TYPE.ADVANCED Then
            Me._ConversionType = CONVERSION_TYPE.ADVANCED

            SimpleTabButton.ImageIndex = 1
            AdvancedTabButton.ImageIndex = 2

            AdvancedPanel.Visible = True
            SimplePanel.Visible = False

            AddHandler SimpleTabButton.Click, AddressOf SimpleTabButton_Click
            RemoveHandler AdvancedTabButton.Click, AddressOf AdvancedTabButton_Click

        Else

            Me._ConversionType = CONVERSION_TYPE.SIMPLE

            SimpleTabButton.ImageIndex = 0
            AdvancedTabButton.ImageIndex = 3

            SimplePanel.Visible = True
            AdvancedPanel.Visible = False

            RemoveHandler SimpleTabButton.Click, AddressOf SimpleTabButton_Click
            AddHandler AdvancedTabButton.Click, AddressOf AdvancedTabButton_Click
        End If

    End Sub



    'Public Sub InitDialog(ByVal pictureName As String, ByVal newImage As Image)

    '    Me.PictureNameTextBox.Text = pictureName

    '    Me.aBitmap = New Bitmap(newImage.Clone, 256, 192)
    '    Me.ViewPictureBox.Image = Me.aBitmap

    '    InitBitmap()

    'End Sub



    'Public Sub InitDialog(ByVal pictureName As String, ByVal newBitmap As Bitmap)

    '    Me.PictureNameTextBox.Text = pictureName

    '    Me.aBitmap = newBitmap
    '    Me.ViewPictureBox.Image = newBitmap

    '    InitBitmap()

    'End Sub



    Public Sub InitBitmap()

        Dim BGcolor As Byte

        Dim TMSG2converter As New SimpleBitmapConverter
        BGcolor = TMSG2converter.GetMostUsedColor(Me.aBitmap)
        Me.BGColorButton.SetColor(BGcolor)

        Me.ConvertButton.Enabled = True

    End Sub



    Private Sub ToleranceTrackBar_Scroll(sender As Object, e As EventArgs) Handles ToleranceTrackBar.Scroll
        Me.ToleranceTextBox.Text = CStr(Me.ToleranceTrackBar.Value)
    End Sub

    Private Sub DetailTrackBar_Scroll(sender As Object, e As EventArgs) Handles DetailTrackBar.Scroll
        Me.DetailTextBox.Text = CStr(Me.DetailTrackBar.Value)
    End Sub

    Private Sub ConvertButton_Click(sender As Object, e As EventArgs) Handles ConvertButton.Click
        Convert()
    End Sub



    Private Sub Convert()

        If Me._ConversionType = CONVERSION_TYPE.SIMPLE Then
            ConvertSimple()
        Else
            ConvertAdvanced()
        End If

    End Sub



    Private Sub ConvertSimple()
        Dim TMSG2converter As New SimpleBitmapConverter

        Me._ProgressController.ShowProgressWin()

        Me.tmpVRAM = TMSG2converter.GetScreenFromBitmap(Me.aBitmap, Me.BGColorButton.SelectedColor)
        Me.TMS9918Aviewer.SetBlock(0, Me.tmpVRAM)
        Me.TMS9918Aviewer.RefreshScreen()

        Application.DoEvents()
        Me._ProgressController.CloseProgressWin()

        Me.OK_Button.Enabled = True
    End Sub



    Private Sub ConvertAdvanced()
        Dim TMSG2converter As New MSXGraphicConversion

        Me._ProgressController.ShowProgressWin()

        Me.tmpVRAM = TMSG2converter.GetScreenFromBitmap(Me.aBitmap, Me.ToleranceTrackBar.Value, Me.DetailTrackBar.Value)
        Me.TMS9918Aviewer.SetBlock(0, Me.tmpVRAM)
        Me.TMS9918Aviewer.RefreshScreen()

        Application.DoEvents()
        Me._ProgressController.CloseProgressWin()

        Me.OK_Button.Enabled = True
    End Sub



    Private Sub ToleranceTextBox_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ToleranceTextBox.Validating
        Dim value As Short
        If IsNumeric(Me.ToleranceTextBox.Text) Then
            value = CShort(Me.ToleranceTextBox.Text)
            If value < 0 Or value > 100 Then
                value = ToleranceDefaultValue
            End If
        Else
            value = ToleranceDefaultValue
        End If

        Me.ToleranceTextBox.Text = CStr(value)
        Me.ToleranceTrackBar.Value = value

    End Sub



    Private Sub DetailTextBox_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DetailTextBox.Validating
        Dim value As Short
        If IsNumeric(Me.DetailTextBox.Text) Then
            value = CShort(Me.DetailTextBox.Text)
            If value < 1 Or value > 255 Then
                value = DetailDefaultValue
            End If
        Else
            value = DetailDefaultValue
        End If

        Me.DetailTextBox.Text = CStr(value)
        Me.DetailTrackBar.Value = value

    End Sub



    Private Sub SimpleTabButton_Click(sender As Object, e As EventArgs) 'Handles SimpleTabButton.Click
        SetConverter(CONVERSION_TYPE.SIMPLE)
    End Sub



    Private Sub AdvancedTabButton_Click(sender As Object, e As EventArgs) 'Handles AdvancedTabButton.Click
        SetConverter(CONVERSION_TYPE.ADVANCED)
    End Sub



    Private Sub BorderColorButton_ColorChanged(color As Byte) Handles BorderColorButton.ColorChanged
        Me.TMS9918Aviewer.BorderColor = color
        Me.TMS9918Aviewer.RefreshScreen()
    End Sub



End Class