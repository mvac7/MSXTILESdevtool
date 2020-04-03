Public Class FillMapForm

    Public ReadOnly Property Tile() As Byte
        Get
            Return CByte(TileText.Text)
        End Get
    End Property



    Private Sub FillButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FillButton.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub TileText_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TileText.Validating
        Dim value As Integer
        If IsNumeric(TileText.Text) Then
            value = CInt(TileText.Text)
            If value > 255 Then
                TileText.Text = "255"
            End If
        Else
            TileText.Text = "0"
        End If
    End Sub


End Class