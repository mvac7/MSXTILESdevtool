Public Interface IEditorContainer

    ReadOnly Property AppID() As String

    Property IsanApp As Boolean

    ReadOnly Property HaveDataOutput As Boolean

    ReadOnly Property HaveAddFile As Boolean

    ReadOnly Property ProjectName() As String

    ReadOnly Property AboutImage() As Image

    ReadOnly Property LoadFileTypes() As String

    ReadOnly Property SaveFileTypes() As String



    Sub NewProject()

    Sub RefreshEditor()

    Sub UpdateConfig()

    Sub ShowOutputDataWindow()

    Sub EditProjectInfo()

    Sub EditPalette()

    Sub Close()



    Function AcceptType(ByVal filePath As String) As Boolean

    Function LoadProject(ByVal filePath As String) As Boolean

    Function SaveProject(ByVal filePath As String) As Boolean

    Function AddProject(ByVal filePath As String) As Boolean



End Interface
