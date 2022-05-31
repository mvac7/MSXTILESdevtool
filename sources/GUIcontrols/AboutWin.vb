Imports System.Drawing

Public NotInheritable Class AboutWin

    Private Const URL_GPL As String = "http://www.gnu.org/licenses/gpl-3.0-standalone.html"


    Public WriteOnly Property SetLogo() As Image
        Set(value As Image)
            Me.LogoPictureBox.Image = value
        End Set
    End Property



    Public WriteOnly Property SetIcon() As Image
        Set(value As Image)
            Me.iconPictureBox.Image = value
        End Set
    End Property



    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub



    Private Sub AboutWin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Establezca el título del formulario.
        Dim LicenseText As String
        Dim ApplicationTitle As String
        If Not My.Application.Info.Title = "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)
        ' Inicialice todo el texto mostrado en el cuadro Acerca de.
        ' TODO: personalice la información del ensamblado de la aplicación en el panel "Aplicación" del 
        '    cuadro de diálogo propiedades del proyecto (bajo el menú "Proyecto").
        'Me.LabelProductName.Text = My.Application.Info.Title
        Me.versionLabel.Text = My.Application.Info.Version.ToString + "b" 'String.Format("Versión {0}", My.Application.Info.Version.ToString)
        Me.copyleftLabel.Text = My.Application.Info.Copyright
        'Me.LabelCompanyName.Text = My.Application.Info.CompanyName

        Me.DescriptionLabel.Text = My.Application.Info.Description

        LicenseText = "License:"
        LicenseText += vbNewLine + "This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version."
        LicenseText += vbNewLine + vbNewLine + "This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details."
        LicenseText += vbNewLine + vbNewLine + "You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>."

        Me.LicenseTextBox.Text = LicenseText

        If Not LogoPictureBox.Image Is Nothing Then
            LogoPictureBox.Width = LogoPictureBox.Image.Width + 14
        End If

        ' draw gradient in window-form background
        Dim gradientBG As New Bitmap(Me.Width, Me.Height)
        Dim newBrush As New Drawing.Drawing2D.LinearGradientBrush(New PointF(0, 0), New PointF(0, gradientBG.Height), Color.Gainsboro, Color.DarkGray)
        Dim oneGraphic As Graphics = Graphics.FromImage(gradientBG)
        oneGraphic.FillRectangle(newBrush, New RectangleF(0, 0, gradientBG.Width, gradientBG.Height))
        Me.BackgroundImage = gradientBG

    End Sub


    Private Sub GPLButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LicenseButton.Click
        System.Diagnostics.Process.Start(URL_GPL)
    End Sub


End Class
