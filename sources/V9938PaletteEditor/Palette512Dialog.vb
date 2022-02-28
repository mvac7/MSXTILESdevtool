Imports System.Windows.Forms
Imports System.Xml
Imports System.IO
Imports mSXdevtools.DataStructures
Imports mSXdevtools.GUI.Controls


''' <summary>
''' Herramienta para la creación de paletas del VDP V9938 o superior.
''' </summary>
''' <remarks></remarks>
Public Class Palette512Dialog

    Private AppConfig As Config
    Private Const AppID As String = "paletteSX"
    'Private Const ConfigFileName As String = "tMSgfX.config"

    Private helpURL As String = Application.StartupPath + System.IO.Path.DirectorySeparatorChar + "Help" + System.IO.Path.DirectorySeparatorChar + AppID + System.IO.Path.DirectorySeparatorChar + AppID + "_UserGuide.html"

    Private paletteEd As paletteEditor




    '#########################################################################################
    '#########################################################################################
    '
    '
    Private Const _TEST As Boolean = False
    '
    '
    Private Const version_type As String = "a" 'a - alpha ; b - beta
    '
    '
    '#########################################################################################
    '#########################################################################################




    ' ----------------------------------------
    Private Project As tMSgfXProject

    'Private _paletteProject As PaletteProject
    ' ----------------------------------------

    Private initPaletteID As Integer = 0
    Public edit_Palette As iPaletteMSX


    Private _ProgressController As ProgressController


    Private def_WorkPath As String = ""





    Public ReadOnly Property SelectedPaletteID() As Integer
        Get
            Return Me.paletteEd.SelectedPaletteID
        End Get
    End Property



    'Public ReadOnly Property Palette() As PaletteV9938
    '    Get
    '        Return Me.edit_Palette
    '    End Get
    '    'Set(ByVal value As PaletteMSX)
    '    '    Me._Palette = value
    '    'End Set
    'End Property



    Public Property ColorSelected() As Integer
        Get
            Return Me.paletteEd.ColorSelected
        End Get
        Set(ByVal value As Integer)
            If Not Me.paletteEd Is Nothing Then
                Me.paletteEd.ColorSelected = value
            End If
        End Set
    End Property



    Public Sub New(ByRef _config As Config, ByRef _Project As tMSgfXProject, ByVal paleteID As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.paletteEd = New paletteEditor(_config, _Project, paleteID)
        Me.SuspendLayout()
        Me.paletteEd.Name = "paletteEditor"
        Me.paletteEd.Location = New System.Drawing.Point(0, 0)
        Me.paletteEd.Size = New System.Drawing.Size(480, 330)
        Me.paletteEd.Dock = DockStyle.Fill
        Me.Controls.Add(Me.paletteEd)
        Me.ResumeLayout(False)


        Me.AppConfig = _config

        Me.ControlBox = False
        'Me.AboutButton.Visible = False
        'Me.Cancel_Button.Visible = False

        Me.Project = _Project
        'Me.edit_Palette = aPalette

        Me.def_WorkPath = Me.AppConfig.PathItemPalette.Path

        Me.initPaletteID = paleteID

    End Sub



    Private Sub palette512Dialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me._ProgressController = New ProgressController(Me)



        'If Not System.IO.File.Exists(Me.helpURL) Then
        '    HelpAppButton.Enabled = False
        'End If

        'SetTitle(Path.GetFileName(Me.Project.Path))
        'Me.ProjectNameTextBox.Text = Me.Project.Info.Name

        'Me.BackColor = Color.FromArgb(211, 211, 211)


        'If _ColorSelected < 1 Then
        '    Me._ColorSelected = 1
        'End If

        'SelectPaletteByID(Me.initPaletteID)

    End Sub



    'Private Sub SetTitle(filename As String)
    '    If Not filename = "" Then
    '        filename = " · [" + filename + "]"
    '    End If

    '    Me.Text = My.Application.Info.Title + " v" + My.Application.Info.Version.ToString + version_type + filename
    'End Sub


    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub


End Class
