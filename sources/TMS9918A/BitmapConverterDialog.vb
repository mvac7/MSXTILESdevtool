Public Class BitmapConverterDialog

    Private aBitmap As Bitmap

    Private tmpVRAM(&H3FFF) As Byte

    Private _ProgressController As ProgressController

    Public ToleranceDefaultValue As Short = 0
    Public DetailDefaultValue As Short = 32



    Private Enum CONVERSION_TYPE As Integer
        SIMPLE
        ADVANCED
    End Enum




    Public ReadOnly Property VRAM As Byte()
        Get
            Return tmpVRAM
        End Get
    End Property




    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me.TMS9918Aviewer.Palette = New PaletteTMS9918
        Me.TMS9918Aviewer.ViewMode = TMS9918A.VIEW_MODE.TILESET

    End Sub



    Private Sub LoadBitmapDialog_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.ToleranceTrackBar.Value = Me.ToleranceDefaultValue
        Me.DetailTrackBar.Value = Me.DetailDefaultValue

        Me.ToleranceTextBox.Text = CStr(Me.ToleranceTrackBar.Value)
        Me.DetailTextBox.Text = CStr(Me.DetailTrackBar.Value)

        Me.TMS9918Aviewer.Initialize()

        ConversionTypeComboBox.SelectedIndex = 0

    End Sub



    Private Sub BitmapConverterDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me._ProgressController = New ProgressController(Me)
    End Sub



    Public Sub InitDialog(ByVal pictureName As String, ByVal newImage As Image)
        Me.PictureNameTextBox.Text = pictureName

        Me.aBitmap = New Bitmap(newImage, 256, 192)
        Me.ViewPictureBox.Image = Me.aBitmap

        Me.ConvertButton.Enabled = True
    End Sub



    Public Sub InitDialog(ByVal pictureName As String, ByVal newBitmap As Bitmap)

        Me.PictureNameTextBox.Text = pictureName

        Me.aBitmap = newBitmap

        Me.ViewPictureBox.Image = newBitmap

        Me.ConvertButton.Enabled = True
    End Sub



    Private Sub ToleranceTrackBar_Scroll(sender As Object, e As EventArgs) Handles ToleranceTrackBar.Scroll
        Me.ToleranceTextBox.Text = CStr(Me.ToleranceTrackBar.Value)
    End Sub

    Private Sub DetailTrackBar_Scroll(sender As Object, e As EventArgs) Handles DetailTrackBar.Scroll
        Me.DetailTextBox.Text = CStr(Me.DetailTrackBar.Value)
    End Sub

    Private Sub ConvertButton_Click(sender As Object, e As EventArgs) Handles ConvertButton.Click
        ConvertAdvanced()
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



    Private Sub ConvertSimple()
        Dim TMSG2converter As New SimpleBitmapConverter

        'Me._ProgressController.ShowProgressWin()

        Me.tmpVRAM = TMSG2converter.GetScreenFromBitmap(Me.aBitmap)
        Me.TMS9918Aviewer.SetBlock(0, Me.tmpVRAM)
        Me.TMS9918Aviewer.RefreshScreen()

        Application.DoEvents()
        'Me._ProgressController.CloseProgressWin()

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



    Private Sub ConversionTypeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ConversionTypeComboBox.SelectedIndexChanged
        If ConversionTypeComboBox.SelectedIndex = CONVERSION_TYPE.SIMPLE Then
            AdvancedPanel.Enabled = False
            ConvertSimple()
        Else
            AdvancedPanel.Enabled = True
            Me.TMS9918Aviewer.Clear()
            Me.TMS9918Aviewer.BackgroundColor = 4
            Me.TMS9918Aviewer.FillVRAM(iVDP.TableBase.GRPCOL, &H1800, &HF4)
            Me.TMS9918Aviewer.RefreshScreen()
        End If

    End Sub

End Class