Public NotInheritable Class AboutWin

    Private Const URL_GPL As String = "http://www.gnu.org/licenses/gpl-3.0-standalone.html"
    Private Const URL_303bcn As String = "http://aorante.blogspot.com.es/"
    'System.Diagnostics.Process.Start(Me.URL_GPL)


    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub AboutWin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Establezca el título del formulario.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("Acerca de {0}", ApplicationTitle)
        ' Inicialice todo el texto mostrado en el cuadro Acerca de.
        ' TODO: personalice la información del ensamblado de la aplicación en el panel "Aplicación" del 
        '    cuadro de diálogo propiedades del proyecto (bajo el menú "Proyecto").
        'Me.LabelProductName.Text = My.Application.Info.Title
        Me.versionLabel.Text = "v " + My.Application.Info.Version.ToString + "b" 'String.Format("Versión {0}", My.Application.Info.Version.ToString)
        Me.copyleftLabel.Text = My.Application.Info.Copyright
        'Me.LabelCompanyName.Text = My.Application.Info.CompanyName
        'Me.TextBoxDescription.Text = My.Application.Info.Description

    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub


    Private Sub GPLButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GPLButton.Click
        System.Diagnostics.Process.Start(URL_GPL)
    End Sub



    Private Sub link303bcnPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles link303bcnPictureBox.Click
        System.Diagnostics.Process.Start(URL_303bcn)
    End Sub


End Class
