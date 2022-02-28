

Public Class ConfigPaletteDialog


    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.Name = "New Palette"

    End Sub


    Public Sub New(ByVal _name As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.Name = _name

    End Sub



    Private Sub AddMapDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.NameTextBox.Text = Me.Name
    End Sub



    Private Sub DoitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoitButton.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub



    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub



    Private Sub NameTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NameTextBox.TextChanged
        Me.Name = NameTextBox.Text
    End Sub




End Class