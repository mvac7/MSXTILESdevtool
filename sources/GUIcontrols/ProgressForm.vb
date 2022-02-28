Public Class ProgressForm

    Private myposx As Integer
    Private myposy As Integer

    Public Sub New(ByVal winpos As System.Drawing.Point, ByVal winsize As System.Drawing.Size)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        myposx = ((winsize.Width - Me.Size.Width) / 2) + winpos.X
        myposy = ((winsize.Height - Me.Size.Height) / 2) + winpos.Y

        Me.Show()

    End Sub


    Private Sub ProgressForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Location = New System.Drawing.Point(myposx, myposy)
    End Sub

End Class