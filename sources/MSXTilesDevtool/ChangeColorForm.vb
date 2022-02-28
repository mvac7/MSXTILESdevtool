Public Class ChangeColorForm

    Private _msxPalette As iPaletteMSX

    Private _OldColor As Byte = 0
    Public ReadOnly Property OldColor() As Byte
        Get
            Return _OldColor
        End Get
    End Property


    Private _NewColor As Byte = 0
    Public ReadOnly Property NewColor() As Byte
        Get
            Return _NewColor
        End Get
    End Property


    Public Sub New(ByVal paletteData As iPaletteMSX)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _msxPalette = paletteData

    End Sub


    Private Sub ChangeColorForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' set default colors
        SetOldColor(0)

        SetNewColor(1)

    End Sub


    Private Sub SetOldColor(ByVal _color As Byte)

        _OldColor = _color
        Me.oldcolorButton.BackColor = _msxPalette.GetRGBColor(_color)
        Me.oldcolorButton.Text = _color
        If _msxPalette.GetRGBColor(_color).GetBrightness > 0.5 Then
            Me.oldcolorButton.ForeColor = Color.Black
        Else
            Me.oldcolorButton.ForeColor = Color.White
        End If

    End Sub


    Private Sub SetNewColor(ByVal _color As Byte)
        _NewColor = _color
        Me.newcolorButton.BackColor = _msxPalette.GetRGBColor(_color)
        Me.newcolorButton.Text = _color
        If _msxPalette.GetRGBColor(_color).GetBrightness > 0.5 Then
            Me.newcolorButton.ForeColor = Color.Black
        Else
            Me.newcolorButton.ForeColor = Color.White
        End If
    End Sub

    Private Sub BlackitizerBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toButton.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub oldcolorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles oldcolorButton.Click
        Dim result As DialogResult
        Dim aColorSelector As New ColorSelector
        result = aColorSelector.ShowWinDialog(Me._msxPalette, System.Windows.Forms.Control.MousePosition) 'Me.MousePosition)

        If result = DialogResult.OK Then
            SetOldColor(aColorSelector.ColorSelected)
        End If
    End Sub

    Private Sub newcolorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles newcolorButton.Click
        Dim result As DialogResult
        Dim aColorSelector As New ColorSelector
        result = aColorSelector.ShowWinDialog(Me._msxPalette, System.Windows.Forms.Control.MousePosition) 'Me.MousePosition)

        If result = DialogResult.OK Then
            SetNewColor(aColorSelector.ColorSelected)
        End If
    End Sub
End Class