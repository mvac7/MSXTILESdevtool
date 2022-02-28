
Public Class ChangeColorForm

    Private _msxPalette As iPaletteMSX

    Public ReadOnly Property FirstColor() As Byte
        Get
            Return Me.FirstColorButton.SelectedColor()
        End Get
    End Property



    Public ReadOnly Property SecondColor() As Byte
        Get
            Return Me.SecondColorButton.SelectedColor()
        End Get
    End Property


    Public Sub New(ByVal paletteData As iPaletteMSX, ByVal isExchange As Boolean)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _msxPalette = paletteData

        Me.FirstColorButton.Palette = _msxPalette
        Me.SecondColorButton.Palette = _msxPalette

        If isExchange Then
            Me.DescriptionLabel.Text = "Set the colors you want to swap:"
            Me.DoitButton.Text = "Swap"
            Me.BetweenLabel.Text = "with"
        End If

    End Sub


    Private Sub ChangeColorForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' set default colors
        SetFirstColor(0)

        SetSecondColor(1)

    End Sub


    Private Sub SetFirstColor(ByVal _color As Byte)

        Me.FirstColorButton.SetColor(_color)

    End Sub


    Private Sub SetSecondColor(ByVal _color As Byte)

        Me.SecondColorButton.SetColor(_color)

    End Sub

    Private Sub BlackitizerBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoitButton.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


End Class