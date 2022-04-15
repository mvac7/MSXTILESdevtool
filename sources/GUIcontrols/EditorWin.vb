Imports System.Windows.Forms
Imports System.IO
''Imports System.Xml

'Imports mSXdevtools.GUIcontrols






Public Class EditorWin



    ' #########################################################################################
    ' #########################################################################################
    '
    Private Const version_type As String = "a" 'a - alpha ; b - beta
    '
    ' #########################################################################################
    ' #########################################################################################



    Private TEST_MODE As Boolean = False   ' <<<------------------------------------------------------------------------ TEST MODE #################


    Private EditorContainer As IEditorContainer

    Private HelpPath As String

    'Private WithEvents screenED As ScreenEditor
    ''Private screenED_MDI As ScreenEditorWin

    'Private WithEvents tilesetED As tilesetEditor.TilesetEditor
    ''Private tilesetED_MDI As TilesetEditorWin

    'Private WithEvents SquaredED As supertilesEditor.SupertilesEditor

    'Private WithEvents mapED As mapEditor.MapEditor
    ''Private mapED_MDI As MapEditorWin

    ''Private WithEvents spriteED As SpriteEditor
    ''Private spriteED_MDI As SpriteEditorWin

    'Private WithEvents OAMed As OAMEditor.OAMEditor
    'Private OAMed_MDI As OAMEditorWin

    Private AppConfig As Config

    'Private AppID As String '= "tmsgfx"
    'Private Const ConfigFileName As String = "tMSgfX.config"

    'Private Const FirstProject As String = "tMSgfX.XSCP"
    Private _tmpFirstProjectPath As String


    'Private Progress As ProgressController


    'Private EditorSelected As EDITOR


    'Private Project As tMSgfXProject

    'Private _mapsProject As MapProject
    'Private _tilesetProject As TilesetProject
    'Private _squaredTilesProject As SquaredsetProject
    'Private _spriteProject As SpriteProject

    Private paletteID As Integer

    Private ProjectPath As String





    Public Sub New(ByRef _config As Config, ByVal _editorContainer As System.Windows.Forms.UserControl, ByVal filePath As String)  ', ByRef _project As tMSgfXProject)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.SuspendLayout()

        Me.Controls.Add(_editorContainer)

        _editorContainer.Location = New Point(0, 40)
        _editorContainer.Size = New System.Drawing.Size(600, 440)
        _editorContainer.Dock = DockStyle.Fill

        Me.ProjectToolStrip.SendToBack()


        'Me.GetDataButton.Enabled = True

        Me.ResumeLayout(False)

        Me.AppConfig = _config

        Me.EditorContainer = _editorContainer
        Me.EditorContainer.IsanApp = True

        Me._tmpFirstProjectPath = filePath
        'Me.Project = _project 'New tMSgfXProject



#If DEBUG Then

        Me.TEST_MODE = True

#Else

        Me.TEST_MODE = False

#End If


    End Sub



    Private Sub EditorWin_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Me.HelpPath = Application.StartupPath + System.IO.Path.DirectorySeparatorChar + "Help" + System.IO.Path.DirectorySeparatorChar + Me.EditorContainer.AppID + System.IO.Path.DirectorySeparatorChar + "UserGuide.html"

        ' si no encuentra el fichero de ayuda, inhabilita el boton 
        If Not File.Exists(Me.HelpPath) Then
            Me.HelpAppButton.Enabled = False
        End If

        If Me.EditorContainer.HaveDataOutput Then
            Me.GetDataButton.Enabled = True
        End If

    End Sub



    Private Sub MainScreen_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

        'ShowProjectData()

        Application.DoEvents()


        If File.Exists(Me._tmpFirstProjectPath) Then
            LoadProject(Me._tmpFirstProjectPath)
        Else
            Me.EditorContainer.NewProject()
        End If


        ShowProjectData()


        Me.BringToFront() 'solucion Bug #246 Win Focus
        Me.TopMost = True
        Me.Activate()
        Me.TopMost = False

    End Sub



    Private Sub MainScreen_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Me.AppConfig.Save()

        Application.DoEvents()

        'If Me.appState = APP_STATE.WORK Then

        Beep()

        'result = MessageBox.Show(Me, "Are you sure you want to close " + My.Application.Info.Title + "?", "Closing Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        Dim messageWin As New MessageDialog("Closing Application", "Are you sure you want to close " + My.Application.Info.Title + "?", MessageDialog.DIALOG_TYPE.YES_NO)
        If messageWin.ShowDialog(Me) = DialogResult.No Then
            e.Cancel = True 'cancela la salida de la aplicacion
        End If
        'End If

    End Sub



    Private Sub SetTitle(ByVal filename As String)

        Dim debuging As String = ""

        If Not filename = "" Then
            filename = " · [" + filename + "]"
        End If

        If Me.TEST_MODE Then
            debuging = " > DEBUG MODE <"
        End If

        Me.Text = My.Application.Info.Title + " v" + My.Application.Info.Version.ToString + version_type + filename + debuging
    End Sub









    ''' <summary>
    ''' Create a New Project
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub NewProject()

        Beep()

        'result = MessageBox.Show(Me, "This option will erase all data." + vbCrLf + "Do you want to continue?", "New Project", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        Dim messageWin As New MessageDialog("New Project", "This option will erase all data." + vbCrLf + "Do you want to continue?", MessageDialog.DIALOG_TYPE.YES_NO)
        If messageWin.ShowDialog(Me) = DialogResult.Yes Then
            Me.EditorContainer.NewProject()
            ShowProjectData()
        End If

    End Sub








    ''' <summary>
    ''' genera y muestra el menu contextual con la lista de proyectos recientes
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub getRecentListContextMenu()
        Dim aProjectItem As ProjectFileItem
        Dim ToolStripMenuItem1 As ToolStripMenuItem

        Me.FilesContextMenuStrip.Items.Clear()

        Dim projectsList As LastProjectsList = Me.AppConfig.GetRecentProjectList(Me.EditorContainer.AppID)

        If Not projectsList Is Nothing Then

            If projectsList.Count > 0 Then

                For i As Integer = 0 To projectsList.Count - 1
                    ToolStripMenuItem1 = New ToolStripMenuItem

                    aProjectItem = projectsList.GetFileItem(i)
                    ToolStripMenuItem1.Name = aProjectItem.Path
                    ToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
                    ToolStripMenuItem1.Text = aProjectItem.Name
                    ToolStripMenuItem1.Image = PrjImageList.Images.Item(0)

                    Me.FilesContextMenuStrip.Items.Add(ToolStripMenuItem1)

                    AddHandler ToolStripMenuItem1.Click, AddressOf Me.ToolStripSelectItem
                Next

                Me.FilesContextMenuStrip.Show(New System.Drawing.Point(Me.Location.X + 70, Me.Location.Y + 60))

            End If

        End If

    End Sub



    ''' <summary>
    ''' evento de pulsación de una opción del menu contextual de la lista de proyectos recientes
    ''' carga un fichero
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolStripSelectItem(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim aSender As ToolStripMenuItem = sender
        LoadProject(aSender.Name)
    End Sub



    ''' <summary>
    ''' Show Project data
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowProjectData()
        SetTitle(Path.GetFileName(Me.ProjectPath)) 'Me.Project.Path))
        Me.ProjectNameText.Text = Me.EditorContainer.ProjectName 'Me.Project.Info.Name
    End Sub



    ''' <summary>
    ''' Show About Screen
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowAbout()
        Dim aboutWinObject As New mSXdevtools.GUI.Controls.AboutWin()
        'aboutWinObject.SetPicture = Me.EditorContainer.AboutImage 'Global.mSXdevtools.tMSgfX.My.Resources.Aboud_tmsgfx
        aboutWinObject.ShowDialog()
    End Sub



    Private Sub ShowHelp()
        Dim helper As HelpWin

        If System.IO.File.Exists(Me.HelpPath) Then
            helper = New HelpWin(Me.Name, Me.HelpPath)
            helper.ShowDialog()
        End If

    End Sub



    Private Sub LoadProject(ByVal filePath As String)

        If Me.EditorContainer.LoadProject(filePath) = True Then 'EditorContainer

            Me.ProjectPath = filePath

            ShowProjectData()

            'Else
            '    MsgBox("Disk I/O error.", MsgBoxStyle.Critical, "Error")
        End If

        Application.DoEvents()
        Activate()

    End Sub



    Private Sub AddProject(ByVal filePath As String)

        If Me.EditorContainer.AddProject(filePath) = True Then

            'ShowProjectData()

            'Else
            '    MsgBox("Disk I/O error.", MsgBoxStyle.Critical, "Error")
        End If

        Application.DoEvents()
        Activate()

    End Sub



    Private Sub SaveAs()

        Me.SaveFileDialog1.Filter = Me.EditorContainer.SaveFileTypes

        If Me.ProjectPath = "" Then  'Me.Project.Path = "" Then
            Me.SaveFileDialog1.InitialDirectory = Me.AppConfig.PathItemProject.Path
            Me.SaveFileDialog1.FileName = Me.EditorContainer.ProjectName  'Me.Project.Info.Name    
        Else
            Me.SaveFileDialog1.InitialDirectory = Path.GetDirectoryName(Me.ProjectPath) 'Me.Project.Path)
            Me.SaveFileDialog1.FileName = Path.GetFileNameWithoutExtension(Me.ProjectPath) 'Me.Project.Path)
            Me.SaveFileDialog1.DefaultExt = Path.GetExtension(Me.ProjectPath)   'MSXOpenDocumentIO.Extension_ProjectDocument
        End If

        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'If Not SaveFileDialog1.FileName = Me.tmpFirstProjectPath Then
            ' controls that the presentation file is not overwritten
            Me.ProjectPath = SaveFileDialog1.FileName
            'Me.Project.Path = SaveFileDialog1.FileName
            SaveProject()
            'End If
        End If

    End Sub



    Private Sub SaveProject()

        'Me.Progress.ShowProgressWin()

        If Me.EditorContainer.SaveProject(Me.ProjectPath) = True Then
            Me.AppConfig.AddRecentProject(Me.ProjectPath, Me.EditorContainer.AppID)
            'Me.AppConfig.PathItemProject.UpdateLastPath(Path.GetDirectoryName(Me.Project.Path))
            SetTitle(Path.GetFileName(Me.ProjectPath))
        End If

        'Me.Progress.CloseProgressWin()

    End Sub



    Private Sub EditConfig()
        Dim aConfig As New ConfigWin(Me.AppConfig, ConfigWin.CONFIG_TYPE.TMSGFX)

        If aConfig.ShowDialog() = DialogResult.OK Then
            Me.AppConfig.Save()
            Me.EditorContainer.UpdateConfig()
        End If

    End Sub









    ' ################################################################################################################################################################################ events


    Private Sub MainScreenMDI_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragDrop

        Dim tmpstr() As String = e.Data.GetData("FileDrop", False)
        Dim filePath As String = tmpstr(0)

        Dim doyouwantanew As DoYouWantaNewOneDialog
        Dim result As DialogResult

        Me.BringToFront()
        Me.Activate()

        If Me.EditorContainer.AcceptType(filePath) Then

            If Me.EditorContainer.HaveAddFile Then
                doyouwantanew = New DoYouWantaNewOneDialog(Path.GetFileName(filePath))
                result = doyouwantanew.ShowDialog(Me)
                If result = Windows.Forms.DialogResult.Yes Then
                    LoadProject(filePath)
                ElseIf result = DialogResult.No Then
                    AddProject(filePath)
                Else
                    ' Cancel
                End If

            Else
                LoadProject(filePath)
            End If

        End If

    End Sub



    Private Sub MainScreenMDI_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub



    Private Sub NewButton_Click(sender As System.Object, e As System.EventArgs) Handles NewButton.Click
        NewProject()
    End Sub



    Private Sub LoadButton_Click(sender As System.Object, e As System.EventArgs) Handles LoadButton.Click

        Me.OpenFileDialog1.Filter = Me.EditorContainer.LoadFileTypes
        '"All files|*." + Config.Extension_ProjectDocument + ";*.sc*;*.png;*.gif;*." + nMSXtilesIO.PROJECT_EXT + "|MSX Open Document Project file|*." + Config.Extension_ProjectDocument + "|MSX Basic Graphics file|*.sc*|nMSXtiles Project file|*." + nMSXtilesIO.PROJECT_EXT + "|PNG documents|*.png|GIF documents|*.gif"

        If Me.ProjectPath = "" Then  'Me.Project.Path 
            Me.OpenFileDialog1.FileName = ""
            Me.OpenFileDialog1.InitialDirectory = Me.AppConfig.PathItemProject.Path
        Else
            Me.OpenFileDialog1.FileName = Path.GetFileName(Me.ProjectPath) 'Me.Project.Path)
            Me.OpenFileDialog1.InitialDirectory = Path.GetDirectoryName(Me.ProjectPath) 'Me.Project.Path)
        End If

        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadProject(OpenFileDialog1.FileName)
        End If
    End Sub



    Private Sub LoadRecentButton_Click(sender As System.Object, e As System.EventArgs) Handles LoadRecentButton.Click
        getRecentListContextMenu()
    End Sub



    Private Sub SaveButton_Click(sender As System.Object, e As System.EventArgs) Handles SaveButton.Click
        If Me.ProjectPath = "" Then 'Me.Project.Path
            SaveAs()
        Else
            SaveProject()
        End If
    End Sub



    Private Sub SaveAsButton_Click(sender As System.Object, e As System.EventArgs) Handles SaveAsButton.Click
        SaveAs()
    End Sub



    Private Sub ProjectDataButton_Click(sender As System.Object, e As System.EventArgs) Handles ProjectDataButton.Click
        Me.EditorContainer.EditProjectInfo()
        Me.ProjectNameText.Text = Me.EditorContainer.ProjectName   'Me.Project.Info.Name
    End Sub



    Private Sub GetDataButton_Click(sender As System.Object, e As System.EventArgs) Handles GetDataButton.Click
        'If Not Me.EditorSelected = EDITOR.SCREEN Then
        Me.EditorContainer.ShowOutputDataWindow()
        'End If
    End Sub

    Private Sub EditColorPaletteButton_Click(sender As System.Object, e As System.EventArgs) Handles EditColorPaletteButton.Click
        Me.EditorContainer.EditPalette()
    End Sub

    Private Sub ConfigAppButton_Click(sender As System.Object, e As System.EventArgs) Handles ConfigAppButton.Click
        EditConfig()
    End Sub

    Private Sub HelpButton_Click(sender As System.Object, e As System.EventArgs) Handles HelpAppButton.Click
        ShowHelp()
    End Sub

    Private Sub AboutButton_Click(sender As System.Object, e As System.EventArgs) Handles AboutButton.Click
        ShowAbout()
    End Sub




End Class
