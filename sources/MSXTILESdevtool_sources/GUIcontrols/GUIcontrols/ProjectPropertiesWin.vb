Public Class ProjectPropertiesWin

    Public Property ProjectName() As String
        Get
            Return Me.NameTextBox.Text
        End Get
        Set(ByVal value As String)
            Me.NameTextBox.Text = value
        End Set
    End Property

    Public Property ProjectVersion() As String
        Get
            Return Me.VersionTextBox.Text
        End Get
        Set(ByVal value As String)
            Me.VersionTextBox.Text = value
        End Set
    End Property

    Public Property ProjectGroup() As String
        Get
            Return Me.GroupTextBox.Text
        End Get
        Set(ByVal value As String)
            Me.GroupTextBox.Text = value
        End Set
    End Property


    Public Property ProjectAuthor() As String
        Get
            Return Me.AuthorTextBox.Text
        End Get
        Set(ByVal value As String)
            Me.AuthorTextBox.Text = value
        End Set
    End Property

    Public Property ProjectDescription() As String
        Get
            Return Me.DescriptionTextBox.Text
        End Get
        Set(ByVal value As String)
            Me.DescriptionTextBox.Text = value
        End Set
    End Property

    Public WriteOnly Property ProjectStartDate() As Long
        Set(ByVal value As Long)
            'Dim tmpDateTime As New DateTime(value)
            Me.ProjectStartDateTextBox.Text = New DateTime(value).ToShortDateString
        End Set
    End Property

    Public WriteOnly Property ProjectLastUpdate() As Long
        Set(ByVal value As Long)
            Me.ProjectLastUpdateTextBox.Text = New DateTime(value).ToShortDateString
        End Set
    End Property


End Class