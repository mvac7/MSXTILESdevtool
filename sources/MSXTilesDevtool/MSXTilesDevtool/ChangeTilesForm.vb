Public Class ChangeTilesForm




    Public ReadOnly Property SourceTile() As Byte
        Get
            Return CByte(SourceTileText.Text)
        End Get
    End Property


    Public ReadOnly Property TargetTile() As Byte
        Get
            Return CByte(TargetTileText.Text)
        End Get
    End Property



    Private Sub ChangeColorForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' set default colors


    End Sub




    Private Sub BlackitizerBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toButton.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub TargetTileText_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TargetTileText.Validating
        Dim value As Integer
        If IsNumeric(TargetTileText.Text) Then
            value = CInt(TargetTileText.Text)
            If value > 255 Then
                TargetTileText.Text = "255"
            End If
        Else
            TargetTileText.Text = "0"
        End If
    End Sub

    Private Sub SourceTileText_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SourceTileText.Validating
        Dim value As Integer
        If IsNumeric(SourceTileText.Text) Then
            value = CInt(SourceTileText.Text)
            If value > 255 Then
                SourceTileText.Text = "255"
            End If
        Else
            SourceTileText.Text = "0"
        End If
    End Sub
End Class