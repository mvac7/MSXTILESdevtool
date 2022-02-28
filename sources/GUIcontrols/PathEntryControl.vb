Public Class PathEntryControl

    Private _pathItem As New PathItem




    'Public Property Item() As PathItem
    '    Get
    '        Return _path
    '    End Get
    '    Set(value As PathItem)
    '        Me._path = value
    '        ShowPath(value)
    '    End Set
    'End Property


    Public Property Label As String
        Set(value As String)
            PathLabel.Text = value
        End Set
        Get
            Return PathLabel.Text
        End Get
    End Property



    Private Sub PathEntryControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ShowPath(Me._pathItem)
        PathTypeComboBox.SelectedIndex = Me._pathItem.TypePath
    End Sub



    Private Sub ShowPath(value As PathItem)
        Me.PathTextBox.Text = value.pathUser
        Me.ToolTip1.SetToolTip(Me.PathTextBox, value.pathUser)
    End Sub



    Private Sub PathButton_Click(sender As System.Object, e As System.EventArgs) Handles PathButton.Click
        FolderBrowserDialog1.SelectedPath = PathTextBox.Text

        If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me._pathItem.pathUser = FolderBrowserDialog1.SelectedPath
            ShowPath(Me._pathItem)
        End If
    End Sub



    Public Function GetItem() As PathItem
        Return Me._pathItem
    End Function



    Public Sub SetItem(value As PathItem)
        Me._pathItem = value
    End Sub



    Private Sub PathTypeComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles PathTypeComboBox.SelectedIndexChanged

        Me._pathItem.TypePath = PathTypeComboBox.SelectedIndex

        Select Case Me._pathItem.TypePath
            Case PathItem.PATH_TYPE.USER
                PathTextBox.ReadOnly = False
                PathButton.Enabled = True
            Case Else
                PathTextBox.ReadOnly = True
                PathButton.Enabled = False
        End Select
    End Sub



    Private Sub PathTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles PathTextBox.TextChanged
        Me._pathItem.pathUser = PathTextBox.Text
    End Sub

End Class
