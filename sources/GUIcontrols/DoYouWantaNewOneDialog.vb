Public Class DoYouWantaNewOneDialog

    Public Sub New(filename As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        If Not filename = "" Then
            Me.Text = "Load [" + filename + "]"
        End If

    End Sub



    Private Sub NewButton_Click(sender As System.Object, e As System.EventArgs) Handles NewButton.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub MergeButton_Click(sender As System.Object, e As System.EventArgs) Handles MergeButton.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Close()
    End Sub

    Private Sub ExitButton_Click(sender As System.Object, e As System.EventArgs) Handles ExitButton.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    
End Class