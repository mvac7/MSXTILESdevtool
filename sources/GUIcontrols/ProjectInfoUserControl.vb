Public Class ProjectInfoUserControl


    Public Property ProjectName() As String
        Set(ByVal value As String)
            Me.NameTextBox.Text = value
        End Set
        Get
            Return Me.NameTextBox.Text
        End Get
    End Property


    Public Property ProjectVersion() As String
        Set(ByVal value As String)
            Me.VersionTextBox.Text = value
        End Set
        Get
            Return Me.VersionTextBox.Text
        End Get
    End Property


    Public Property ProjectAuthor() As String
        Set(ByVal value As String)
            Me.AuthorTextBox.Text = value
        End Set
        Get
            Return Me.AuthorTextBox.Text
        End Get
    End Property


    Public Property ProjectGroup() As String
        Set(ByVal value As String)
            Me.GroupTextBox.Text = value
        End Set
        Get
            Return Me.GroupTextBox.Text
        End Get
    End Property


    Public Property ProjectDescription() As String
        Set(ByVal value As String)
            Me.DescriptionTextBox.Text = value
        End Set
        Get
            Return Me.DescriptionTextBox.Text
        End Get
    End Property


    Public WriteOnly Property ProjectStartDate() As String
        Set(ByVal value As String)
            Me.StartDateTextBox.Text = value
        End Set
    End Property


    Public WriteOnly Property ProjectLastUpdate() As String
        Set(ByVal value As String)
            Me.LastUpdateTextBox.Text = value
        End Set
    End Property


End Class
