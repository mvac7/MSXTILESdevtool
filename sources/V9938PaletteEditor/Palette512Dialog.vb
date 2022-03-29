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

    'Private Const AppID As String = "paletteSX"
    ''Private Const ConfigFileName As String = "tMSgfX.config"

    'Private helpURL As String = Application.StartupPath + System.IO.Path.DirectorySeparatorChar + "Help" + System.IO.Path.DirectorySeparatorChar + AppID + System.IO.Path.DirectorySeparatorChar + AppID + "_UserGuide.html"


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


    Private Project As tMSgfXProject
    Private Palettes As PaletteProject


    Private paletteEd As paletteEditor

    Private _ProgressController As ProgressController




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



    Public Sub New(ByRef _config As Config, ByRef _palettes As PaletteProject, ByVal paleteID As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Dim editPalettes As PaletteProject

        Me.AppConfig = _config
        Me.ControlBox = False
        Me.Palettes = _palettes

        editPalettes = CopyPaletteProject(Me.Palettes)

        Me.paletteEd = New paletteEditor(_config, editPalettes, paleteID)

    End Sub



    Public Sub New(ByRef _config As Config, ByRef _Project As tMSgfXProject, ByVal paleteID As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim editPalettes As PaletteProject

        Me.AppConfig = _config
        Me.ControlBox = False
        Me.Palettes = _Project.Palettes

        editPalettes = CopyPaletteProject(Me.Palettes)

        Me.paletteEd = New paletteEditor(_config, editPalettes, paleteID)

    End Sub



    Private Sub palette512Dialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me._ProgressController = New ProgressController(Me)

        Me.SuspendLayout()
        Me.paletteEd.Name = "paletteEditor"
        Me.paletteEd.Location = New System.Drawing.Point(0, 0)
        Me.paletteEd.Size = New System.Drawing.Size(480, 330)
        Me.paletteEd.Dock = DockStyle.Fill
        Me.Controls.Add(Me.paletteEd)
        Me.ResumeLayout(False)

        'SetTitle(Path.GetFileName(Me.Project.Path))

        'Me.BackColor = Color.FromArgb(211, 211, 211)

    End Sub



    'Private Sub SetTitle(filename As String)
    '    If Not filename = "" Then
    '        filename = " · [" + filename + "]"
    '    End If

    '    Me.Text = My.Application.Info.Title + " v" + My.Application.Info.Version.ToString + version_type + filename
    'End Sub



    Private Function CopyPaletteProject(ByRef aPaletteProject As PaletteProject) As PaletteProject

        Dim editPalettes As New PaletteProject

        For Each tmpPalette As iPaletteMSX In aPaletteProject.Values
            editPalettes.Add(tmpPalette.Copy)
        Next

        Return editPalettes

    End Function



    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click

        Me.Palettes.Clear()

        For Each tmpPalette As iPaletteMSX In paletteEd.Palettes.Values

            'If Me.Palettes.Contains(tmpPalette.ID) Then
            '    Me.Palettes.Update(tmpPalette.ID, tmpPalette)
            'Else
            Me.Palettes.Add(tmpPalette.Copy)
            'End If

        Next

        Me.DialogResult = DialogResult.OK

        Me.Close()
    End Sub



    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub



End Class
