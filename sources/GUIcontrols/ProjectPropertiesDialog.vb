Imports System.IO


Public Class ProjectPropertiesDialog


    Private projectInfo As ProjectInfo



    Public Sub New(ByVal _config As Config, ByVal projectInfoData As ProjectInfo)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.projectInfo = projectInfoData.Clone()

        Me.Text = "Project Info (" + Me.projectInfo.Name + ")"


        Me.ProjectInfoUserControl1.ProjectName = Me.projectInfo.Name
        Me.ProjectInfoUserControl1.ProjectVersion = Me.projectInfo.Version
        Me.ProjectInfoUserControl1.ProjectGroup = Me.projectInfo.Group

        If Me.projectInfo.Author = "" Then
            'Me.AuthorTextBox.Text = My.User.Name
            Me.ProjectInfoUserControl1.ProjectAuthor = _config.defAuthor   'Environment.UserName
        Else
            Me.ProjectInfoUserControl1.ProjectAuthor = Me.projectInfo.Author
        End If

        Me.ProjectInfoUserControl1.ProjectDescription = Me.projectInfo.Description
        Me.ProjectInfoUserControl1.ProjectStartDate = New DateTime(Me.projectInfo.StartDate).ToShortDateString
        Me.ProjectInfoUserControl1.ProjectLastUpdate = New DateTime(Me.projectInfo.LastUpdate).ToShortDateString

    End Sub



    Public Function GetProjectInfo() As ProjectInfo

        Me.projectInfo.Name = Me.ProjectInfoUserControl1.ProjectName
        Me.projectInfo.Version = Me.ProjectInfoUserControl1.ProjectVersion
        Me.projectInfo.Group = Me.ProjectInfoUserControl1.ProjectGroup
        Me.projectInfo.Author = Me.ProjectInfoUserControl1.ProjectAuthor
        Me.projectInfo.Description = Me.ProjectInfoUserControl1.ProjectDescription

        Return Me.projectInfo

    End Function



End Class