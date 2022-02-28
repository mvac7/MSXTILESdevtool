Imports System.Windows.Forms

Public Class EntryTextDialog


    Public Property TextValue() As String
        Get
            Return Me.NameText.Text
        End Get
        Set(ByVal value As String)
            Me.NameText.Text = value
        End Set
    End Property


    Public Sub New(ByVal value As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.NameText.Text = value

    End Sub


    Public Sub New(ByVal label As String, ByVal value As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.EntryLabel.Text = label
        Me.NameText.Text = value

    End Sub


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub


    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

   
End Class
