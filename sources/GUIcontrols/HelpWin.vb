Public Class HelpWin

    ' RichTextBox
    ' https://msdn.microsoft.com/es-es/library/aa970779(v=vs.110).aspx




    Public Sub New(title As String, HelpURL As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.TitleLabel.Text = title

        Me.WebBrowser1.Navigate(HelpURL)
        'Me.RichTextBox1.Document

    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub
End Class