Public Class ColorButton

    Private _msxPalette As iPaletteMSX

    Public WriteOnly Property Palette() As iPaletteMSX
        Set(ByVal value As iPaletteMSX)
            Me._msxPalette = value
        End Set
    End Property

    Private _Color As Byte = 0

    Public ReadOnly Property SelectedColor() As Byte
        Get
            Return _Color
        End Get
    End Property



    ' EVENTs ###########################################################################################################################

    Public Event ColorChanged(ByVal color As Byte)

    ' END EVENTs #######################################################################################################################



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TMScolorButton.Click
        Dim result As DialogResult
        Dim aColorSelector As New ColorSelector
        result = aColorSelector.ShowWinDialog(Me._msxPalette, System.Windows.Forms.Control.MousePosition) 'Me.MousePosition)

        If result = DialogResult.OK Then
            If Not aColorSelector.ColorSelected = Me._Color Then
                SetColor(aColorSelector.ColorSelected)
                RaiseEvent ColorChanged(Me._Color)
            End If
        End If
    End Sub



    Public Sub SetColor(ByVal newcolor As Byte)

        Dim aColor As Color

        Me._Color = newcolor

        aColor = _msxPalette.GetRGBColor(_Color)

        TMScolorButton.BackColor = aColor
        TMScolorButton.Text = _Color
        If aColor.GetBrightness > 0.65 Then
            TMScolorButton.ForeColor = Color.Black
        Else
            TMScolorButton.ForeColor = Color.White
        End If

    End Sub



End Class
