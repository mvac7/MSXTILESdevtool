Imports System.IO


Public Class paletteEditor
    Implements IEditorContainer

    Private TEST_MODE As Boolean = False   ' <<<------------------------------------------------------------------------ TEST MODE #################

    Public _isanApp As Boolean = False


    Private AppConfig As Config
    Private _AppID As String = "paletteSX"

    Private Project As tMSgfXProject

    Private HelpPath As String

    Private initPaletteID As Integer = 0
    Public edit_Palette As iPaletteMSX


    Private newColor As ColorMSX
    Private oldColor As ColorMSX
    Private clipboardColor As ColorMSX

    Private _ColorSelected As Integer = -1


    Private _ProgressController As ProgressController

    Private Const COLOR_BOX_HEIGHT = 17


    'Private defaultPath As String = ""
    Private def_WorkPath As String = ""
    'Private projectPath As String = ""

    'Private ColorConversionTable As Byte() = New Byte() {0, 36, 73, 109, 146, 182, 219, 255}

    Private paletteBitmap As System.Drawing.Bitmap

    Private PaletteGfxData As New ArrayList

    Private ttipcolor As Color = Color.Black

    Private _lastTone As Integer = 0

    Private undo As New SizedStack(16)
    Private redo As New SizedStack(16)


    Private Const PALETTE_INITYPOS As Integer = 16 ' 34



    Public Shadows Const LoadTypes As String = "All files|*." + MSXOpenDocumentIO.Extension_ProjectDocument + ";*." + MSXOpenDocumentIO.Extension_PaletteDocument + ";*." + MSXOpenDocumentIO.Extension_TilesetDocument + ";*." + MSXOpenDocumentIO.Extension_PictureDocument + "|MSX Open Document Project|*." + MSXOpenDocumentIO.Extension_ProjectDocument + "|MSX Color Palette Open Document|*." + MSXOpenDocumentIO.Extension_PaletteDocument + "|MSX Picture Open Document Project|*." + MSXOpenDocumentIO.Extension_PictureDocument + "|MSX Tileset Open Document|*." + MSXOpenDocumentIO.Extension_TilesetDocument
    Public Shadows Const SaveTypes As String = "MSX Open Document Project|*." + MSXOpenDocumentIO.Extension_ProjectDocument + "|MSX Color Palette Open Document|*." + MSXOpenDocumentIO.Extension_PaletteDocument




    Public ReadOnly Property AppID As String Implements IEditorContainer.AppID
        Get
            Return Me._AppID
        End Get
    End Property

    Public Property IsanApp As Boolean Implements IEditorContainer.IsanApp
        Get
            Return Me._isanApp
        End Get
        Set(value As Boolean)
            Me._isanApp = value
        End Set
    End Property

    Public ReadOnly Property HaveDataOutput As Boolean Implements IEditorContainer.HaveDataOutput
        Get
            Return True
        End Get
    End Property

    Public ReadOnly Property HaveAddFile As Boolean Implements IEditorContainer.HaveAddFile
        Get
            Return True
        End Get
    End Property

    Public ReadOnly Property ProjectName As String Implements IEditorContainer.ProjectName
        Get
            If Me.Project Is Nothing Then
                Return ""
            Else
                Return Me.Project.Info.Name
            End If
        End Get
    End Property

    Public ReadOnly Property AboutImage As Image Implements IEditorContainer.AboutImage
        Get
            Return Global.mSXdevtools.V9938PaletteEditor.My.Resources.Aboud_win_paletteSX
        End Get
    End Property

    Public ReadOnly Property LoadFileTypes As String Implements IEditorContainer.LoadFileTypes
        Get
            Return LoadTypes
        End Get
    End Property

    Public ReadOnly Property SaveFileTypes As String Implements IEditorContainer.SaveFileTypes
        Get
            Return SaveTypes
        End Get
    End Property







    Public ReadOnly Property SelectedPaletteID() As Integer
        Get
            Return Me.edit_Palette.ID
        End Get
    End Property



    Public Property ColorSelected() As Integer
        Get
            Return Me._ColorSelected
        End Get
        Set(ByVal value As Integer)
            Me._ColorSelected = value
        End Set
    End Property





    Public Sub New(ByRef _config As Config)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.AppConfig = _config

        Me.Project = New tMSgfXProject

    End Sub



    Public Sub New(ByRef _config As Config, ByRef aProject As tMSgfXProject)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.AppConfig = _config

        Me.Project = aProject

    End Sub



    Public Sub New(ByRef _config As Config, ByRef _Project As tMSgfXProject, ByVal paleteID As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.AppConfig = _config

        Me.Project = _Project

        Me.HelpPath = Application.StartupPath + System.IO.Path.DirectorySeparatorChar + "Help" + System.IO.Path.DirectorySeparatorChar + Me.AppID + System.IO.Path.DirectorySeparatorChar + "UserGuide.html"


        Me.def_WorkPath = Me.AppConfig.PathItemPalette.Path

        Me.initPaletteID = paleteID

    End Sub






    Private Sub paletteEditor_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

#If DEBUG Then

        Me.TEST_MODE = True

#Else

        Me.TEST_MODE = False

#End If

        Me._ProgressController = New ProgressController(Me.ParentForm)

        Me.Project.Palettes.SetZeroColor(Me.AppConfig.Color_Zero)

        If Me._isanApp = False Then
            Me.GetDataButton.Visible = True
            If System.IO.File.Exists(HelpPath) Then
                Me.HelpButton.Visible = True
            End If
        End If

        Me.paletteBitmap = New Bitmap(128, 256)
        Me.ColorPickerPictureBox.Image = Me.paletteBitmap

        Me.BackColor = Color.FromArgb(211, 211, 211)

        Me.ColorPickerComboBox.SelectedIndex = 0

        DrawPalette()

        RefreshPaletteSelector()

        If _ColorSelected < 1 Then
            Me._ColorSelected = 1
        End If

        SelectPaletteByID(Me.initPaletteID)

        Me.edit_Palette = Me.Project.Palettes.GetPaletteByID(Me.initPaletteID)
        RefreshPalette()


        AddHandler Me.ParentForm.KeyDown, AddressOf Me.mainWin_KeyDown   ' solution for when keyboard events are not collected in the usercontrol 
        AddHandler Me.PaletteComboBox.SelectedIndexChanged, AddressOf Me.PaletteComboBox_SelectedIndexChanged

    End Sub




    Public Sub NewProject() Implements IEditorContainer.NewProject

        Clear()

        'Me.ProjectNameTextBox.Text = Me.Project.Info.Name

        RefreshPaletteSelector()
        Me.initPaletteID = 0
        Me._ColorSelected = 1

        SelectPaletteByID(Me.initPaletteID)
    End Sub



    Public Sub RefreshEditor() Implements IEditorContainer.RefreshEditor

    End Sub



    Public Sub UpdateConfig() Implements IEditorContainer.UpdateConfig
        Me.Project.Palettes.SetZeroColor(Me.AppConfig.Color_Zero)
        RefreshEditor()
    End Sub



    Public Sub ShowOutputDataWindow() Implements IEditorContainer.ShowOutputDataWindow
        Dim codeWin As New OutputDataWin(Me.AppConfig, Me.Project.Info, Me.Project.Palettes, Me.edit_Palette.ID)
        codeWin.ShowDialog()
    End Sub



    Public Sub EditProjectInfo() Implements IEditorContainer.EditProjectInfo
        Dim ProjectProperties As New ProjectPropertiesDialog(Me.AppConfig, Me.Project.Info)

        If ProjectProperties.ShowDialog = DialogResult.OK Then
            Me.Project.Info = ProjectProperties.GetProjectInfo()
        End If
    End Sub



    Public Sub EditPalette() Implements IEditorContainer.EditPalette
        Throw New NotImplementedException()
    End Sub



    Public Sub Close() Implements IEditorContainer.Close
        RemoveHandler Me.ParentForm.KeyDown, AddressOf mainWin_KeyDown
        Me.Dispose()
    End Sub



    Public Function AcceptType(filePath As String) As Boolean Implements IEditorContainer.AcceptType
        Dim extension As String = Path.GetExtension(filePath).ToUpper

        Select Case extension

            Case "." + MSXOpenDocumentIO.Extension_PaletteDocument
                Return True

            Case "." + MSXOpenDocumentIO.Extension_ProjectDocument
                Return True

                'Case ".PNG" 'Bitmap
                '    Return True

            Case ".PAL"  ' Binario con 32 valores, 2B por color en formato RB,G

                'Case "." + MSXBasicGraphicsFileIO.Extension_MSXBASICscreen2, "." + MSXBasicGraphicsFileIO.Extension_MSXBASICscreen4 ' .SPR", ".SC1",  MSX Basic Binary
                '    Return True

            Case Else
                Return False

        End Select
    End Function



    Public Function LoadProject(filePath As String) As Boolean Implements IEditorContainer.LoadProject
        Throw New NotImplementedException()
    End Function



    Public Function SaveProject(filePath As String) As Boolean Implements IEditorContainer.SaveProject
        Dim result As Boolean = False
        Dim extension As String

        Dim _tmsgfxIO As New MSXOpenDocumentIO(Me.AppConfig, Me.Project)

        Me._ProgressController.ShowProgressWin()


        extension = Path.GetExtension(filePath).ToUpper
        If extension = "." + MSXOpenDocumentIO.Extension_PaletteDocument Then
            result = _tmsgfxIO.SavePaletteProject(filePath)
            If result = True And Me._isanApp = True Then
                Me.Project.Path = filePath
            End If
        Else
            result = _tmsgfxIO.SaveProject(filePath)
            If result = True Then
                Me.Project.Path = filePath
            End If
        End If

        Me._ProgressController.CloseProgressWin()


        If result = True Then
            Me.AppConfig.AddRecentProject(filePath, AppID)
        End If
    End Function



    Public Function AddProject(filePath As String) As Boolean Implements IEditorContainer.AddProject
        Throw New NotImplementedException()
    End Function



    ''' <summary>
    ''' Borra todos los datos de un proyecto
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Clear()

        If Me._isanApp = True Then

            Me.Project = New tMSgfXProject

        Else
            'tMSgfX project
            Me.Project.Info.Clear()
            Me.Project.Palettes.Clear()

        End If

    End Sub


    ''' <summary>
    ''' Initializes the current color palette with the default colors (similar to those of the TMS9918A). 
    ''' </summary>
    Private Sub ClearPalette()
        AddUndo()
        Me.edit_Palette.SetDefault()
        RefreshPalette()
    End Sub



    Private Sub RefreshPaletteSelector()

        Dim counter As Integer = 1

        Me.PaletteComboBox.Items.Clear()
        Me.PaletteComboBox.Items.Add("0 - " + Me.Project.Palettes.GetPaletteByID(0).Name)

        If Me.Project.Palettes.Count > 0 Then
            For Each aName As String In Me.Project.Palettes.GetNameList()
                Me.PaletteComboBox.Items.Add(CStr(counter) + " - " + aName)
                counter += 1
            Next
        End If

    End Sub




    Private Sub SelectPalette(ByVal index As Integer)
        Me.PaletteComboBox.SelectedIndex = index
    End Sub



    Private Sub SelectPaletteByID(ByVal ID As Integer)

        Dim indexPalette As Integer = Me.Project.Palettes.GetIndexFromID(ID)

        If indexPalette < 0 Then
            ' si ya no existe ese ID, se proporciona el valor de la paleta por defecto (0-TMS9918)
            indexPalette = 0
        End If

        Me.PaletteComboBox.SelectedIndex = indexPalette

    End Sub





    Private Sub DrawPalette()
        Dim ColorBox As PictureBox
        Dim contador As Integer = 0

        'Dim aColorMSX As ColorMSX

        For i As Integer = 0 To 15 'Each aColorMSX As ColorMSX In Me.edit_Palette.Colors.Values
            'aColorMSX = Me.edit_Palette.GetMSXColor(i)
            ColorBox = getColorBox(Str(contador), 16, PALETTE_INITYPOS + (contador * COLOR_BOX_HEIGHT), Color.Black) 'Me.edit_Palette.GetRGBColor(i)  .RGBColor)

            Me.PalettePanel.Controls.Add(ColorBox)
            Me.PaletteGfxData.Add(ColorBox)
            AddHandler ColorBox.Click, AddressOf Me.colorPalette_Click

            contador += 1
        Next

    End Sub


    Private Function getColorBox(ByVal id As String, ByVal x As Integer, ByVal y As Integer, ByVal aColor As Color) As System.Windows.Forms.Control
        Dim ColorBox As PictureBox
        ColorBox = New PictureBox
        Me.SuspendLayout()
        ColorBox.BackColor = aColor
        ColorBox.Location = New System.Drawing.Point(x, y)
        ColorBox.Name = id
        ColorBox.Size = New System.Drawing.Size(32, COLOR_BOX_HEIGHT - 1)
        ColorBox.TabIndex = 0
        ColorBox.TabStop = False
        Me.ResumeLayout(False)

        Me.ToolTip1.SetToolTip(ColorBox, "Color " + id)

        Return ColorBox
    End Function


    Private Sub colorPalette_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim numColor As Integer = CInt(sender.name)

        If numColor > 0 And numColor < 16 Then
            Me._ColorSelected = numColor
            SelectColor(Me._ColorSelected)
            'SetColorArrow(Me._ColorSelected)
        End If

    End Sub


    Private Sub SelectColor(ByVal numColor As Integer)

        If numColor > 0 And numColor < 16 Then

            Me.ColorArrowPictureBox.Top = PALETTE_INITYPOS + (numColor * COLOR_BOX_HEIGHT)

            If Me.edit_Palette.Type = iPaletteMSX.VDP.V9938 Then

                Dim aColorMSX As ColorMSX = Me.edit_Palette.GetMSXColor(numColor)
                Dim TMSColorMSX As Color = Me.Project.Palettes.GetPalette(0).GetRGBColor(numColor)
                'Dim SumOfColors As Short = CShort(TMSColorMSX.R) + CShort(TMSColorMSX.G) + CShort(TMSColorMSX.B)

                Me.oldColor = aColorMSX.Clone()
                Me.newColor = aColorMSX.Clone()

                'setEditColor(aColorMSX)
                Me.RestoreOldColorPictureBox.BackColor = oldColor.GetRGBColor()

                Me.NumColorLabel.Text = numColor
                Me.NumColorLabel.BackColor = TMSColorMSX
                'If SumOfColors > 410 Then
                '    Me.NumColorLabel.ForeColor = Color.Black
                'Else
                '    Me.NumColorLabel.ForeColor = Color.White
                'End If

                If NumColorLabel.BackColor.GetBrightness > 0.65 Then
                    NumColorLabel.ForeColor = Drawing.Color.Black
                Else
                    NumColorLabel.ForeColor = Drawing.Color.White
                End If


                SetColorParameters()


            End If

        End If

    End Sub



    Private Sub SetColorParameters()
        Me.RedTrackBar.Value = Me.newColor.Red
        Me.GreenTrackBar.Value = Me.newColor.Green
        Me.BlueTrackBar.Value = Me.newColor.Blue

        Me.RedTextBox.Text = CStr(Me.RedTrackBar.Value)
        Me.GreenTextBox.Text = CStr(Me.GreenTrackBar.Value)
        Me.BlueTextBox.Text = CStr(Me.BlueTrackBar.Value)

        Me.showColor()
        Me.setTone()
    End Sub



    Private Sub showColor()

        Dim aRed As Byte = Me.RedTrackBar.Value
        Dim aGreen As Byte = Me.GreenTrackBar.Value
        Dim aBlue As Byte = Me.BlueTrackBar.Value

        Dim tmpMSXcolor As New ColorMSX(1, aRed, aGreen, aBlue)

        'Me.ColorPictureBox.BackColor = Me.edit_Palette.getRGB(aRed, aGreen, aBlue)

        setEditColor(tmpMSXcolor)

        'Me.newColor.RGBColor = get24bitColor(aRed, aGreen, aBlue)
        Me.newColor.Red = aRed
        Me.newColor.Green = aGreen
        Me.newColor.Blue = aBlue

    End Sub


    Private Sub setEditColor(ByVal aColorMSX As ColorMSX)

        Dim dataTools As New DataFormat

        Dim tmpcolor As Color = aColorMSX.GetRGBColor()

        Me.UpdateButton.BackColor = tmpcolor
        If UpdateButton.BackColor.GetBrightness > 0.65 Then
            UpdateButton.ForeColor = Drawing.Color.Black
        Else
            UpdateButton.ForeColor = Drawing.Color.White
        End If


        'muestra el valor RGB en hex
        RGB24TextBox.Text = dataTools.GetHexByte(tmpcolor.R) + dataTools.GetHexByte(tmpcolor.G) + dataTools.GetHexByte(tmpcolor.B)

        RBGTextBox.Text = Hex(aColorMSX.Red) + Hex(aColorMSX.Blue) + dataTools.GetHexByte(aColorMSX.Green)
    End Sub


    Private Sub setTone()
        Dim aRed As Byte = RedTrackBar.Value
        Dim aGreen As Byte = GreenTrackBar.Value
        Dim aBlue As Byte = BlueTrackBar.Value

        Dim media As Byte = (aRed + aGreen + aBlue) / 3
        Me.ToneTrackBar.Value = media
        Me.ToneTextBox.Text = media
        Me._lastTone = media
    End Sub






    Private Sub ShowColorPickerRedBlue()

        For x As Byte = 0 To 7
            For y As Byte = 0 To 7
                setPoint(x, y, PaletteProject.GetColor(x, 0, y))
            Next
        Next
        ColorPickerPictureBox.Refresh()

    End Sub



    Private Sub ShowColorPickerRedGreen()

        For x As Byte = 0 To 7
            For y As Byte = 0 To 7
                setPoint(x, y, PaletteProject.GetColor(x, y, 0))
            Next
        Next
        ColorPickerPictureBox.Refresh()

    End Sub



    Private Sub ShowColorPickerGreenBlue()

        For x As Byte = 0 To 7
            For y As Byte = 0 To 7
                setPoint(x, y, PaletteProject.GetColor(0, x, y))
            Next
        Next
        ColorPickerPictureBox.Refresh()

    End Sub



    Private Sub setPoint(ByVal x As Integer, ByVal y As Integer, ByVal aColor As System.Drawing.Color)
        Dim posx As Integer = 0
        Dim posy As Integer = 0

        posx = x * 16
        posy = y * 16 '4

        For o As Byte = 0 To 15 '3
            For i As Integer = 0 To 15
                Me.paletteBitmap.SetPixel(posx + i, posy + o, aColor)
            Next
        Next
    End Sub



    Public Sub AddUndo()
        undo.Push(Me.edit_Palette.Clone())
    End Sub



    Public Sub AddRedo()
        redo.Push(Me.edit_Palette.Clone())
    End Sub



    Public Sub SetUndo()
        'Dim tmpUndoItem As UndoItem
        If undo.Count > 0 Then
            AddRedo()
            Me.edit_Palette = undo.Pop
            RefreshPalette()
        End If
    End Sub



    Public Sub SetRedo()
        'Dim tmpUndoItem As UndoItem
        If redo.Count > 0 Then
            AddUndo()
            Me.edit_Palette = redo.Pop
            RefreshPalette()
        End If
    End Sub



    Private Sub RefreshPalette()
        'Me.ProjectNameTextBox.Text = Me.edit_Palette.Name
        RedrawPalette()

        If edit_Palette.Type = iPaletteMSX.VDP.TMS9918 Then
            EditPalettePanel.Visible = False
            DuplicatePaletteButton.Enabled = False
            ConfigPaletteButton.Enabled = False
            DeletePaletteButton.Enabled = False
            CopyButton.Enabled = False
            ChangeButton.Enabled = False
            ClearButton.Enabled = False
            UndoButton.Enabled = False
        Else
            ' V9938
            EditPalettePanel.Visible = True
            DuplicatePaletteButton.Enabled = True
            ConfigPaletteButton.Enabled = True
            DeletePaletteButton.Enabled = True
            CopyButton.Enabled = True
            ChangeButton.Enabled = True
            ClearButton.Enabled = True
            UndoButton.Enabled = True

            SelectColor(Me._ColorSelected)
        End If

    End Sub



    ''' <summary>
    ''' Actualiza la representacion de la lista de los 16 colores de la paleta 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RedrawPalette()
        For Each ColorBox As PictureBox In PaletteGfxData
            ColorBox.BackColor = Me.edit_Palette.GetRGBColor(CInt(ColorBox.Name)) '.RGBColor
        Next
    End Sub



    Private Sub CopyColorTool()
        Dim aColorWinSelector As ColorWinSelector
        Dim result As DialogResult

        AddUndo()
        'Me.undo_Palette = Me.edit_Palette.Clone 'copia la paleta para undo

        aColorWinSelector = New ColorWinSelector(0, Me.edit_Palette)

        result = aColorWinSelector.ShowDialog()

        If result = DialogResult.OK Then
            'Me.UndoButton.Enabled = True
            'Me.undo_type = 1
            RedrawPalette()
            'Else
            'undoPalette()
            'Me.UndoButton.Enabled = False
        End If
    End Sub



    Private Sub ChangeColorTool()
        Dim aColorWinSelector As ColorWinSelector
        Dim result As DialogResult

        AddUndo()

        aColorWinSelector = New ColorWinSelector(1, Me.edit_Palette)

        result = aColorWinSelector.ShowDialog()

        If result = DialogResult.OK Then
            RedrawPalette()
        End If

    End Sub



    Private Sub NewPalette()

        NewPalette(New PaletteV9938)

    End Sub



    Private Sub DuplicateSelectedPalette()

        If Not Me.edit_Palette.ID = 0 Then

            NewPalette(Me.edit_Palette.Clone)

        End If

    End Sub



    Private Sub NewPalette(newPalette As PaletteV9938)

        Dim _configPalette As New ConfigPaletteDialog
        Dim newName As String
        Dim aCommonFunctions As New CommonFunctions

        newName = aCommonFunctions.GetNameWithNumberByRepetition(newPalette.Name, Me.Project.Palettes.GetNameList())

        _configPalette.Name = newName

        If _configPalette.ShowDialog = DialogResult.OK Then
            newPalette.Name = _configPalette.Name
            If Not Me.Project.Palettes.Add(newPalette) < -1 Then
                RefreshPaletteSelector()
                SelectPaletteByID(newPalette.ID)
            End If
        End If
    End Sub



    Private Sub deletteSelectedPalette()

        Dim msgDialog = New MessageDialog("Delete Palette", "This option deletes the current palette." + Environment.NewLine + "Are you sure?", MessageDialog.DIALOG_TYPE.YES_NO)
        If msgDialog.ShowDialog(Me) = DialogResult.Yes Then
            DeletePalette(Me.edit_Palette.ID)
        End If

    End Sub




    Private Sub DeletePalette(ID As Integer)
        If ID = 0 Then
            'esta paleta no se puede borrar. Es la TMS9918
        Else
            Me.Project.Palettes.DeleteByID(ID)
            RefreshPaletteSelector()
            SelectPalette(0)
        End If
    End Sub




    Private Sub ConfigPalette()
        Dim _configPalette As New ConfigPaletteDialog(Me.edit_Palette.Name)

        If Me.edit_Palette.Type = iPaletteMSX.VDP.V9938 Then

            If _configPalette.ShowDialog = DialogResult.OK Then
                Me.Project.Palettes.ChangeName(Me.edit_Palette.ID, _configPalette.Name)
                'Me.edit_Palette.Name = _configPalette.Name
                RefreshPaletteSelector()
                SelectPaletteByID(Me.edit_Palette.ID)
            End If

        End If

    End Sub


    Private Sub Copy()
        If Not edit_Palette.Type = iPaletteMSX.VDP.TMS9918 Then
            Me.clipboardColor = Me.newColor.Clone()
        End If
    End Sub



    Private Sub Paste()
        If Not edit_Palette.Type = iPaletteMSX.VDP.TMS9918 Then

            If Not Me.clipboardColor Is Nothing Then
                Me.newColor = Me.clipboardColor

                SetColorParameters()

            End If

        End If
    End Sub










    ' -------------------------------------------------------------------------------------------------------------------------------- EVENTs 


    Private Sub mainWin_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim _key As Integer = e.KeyValue


        If e.KeyCode = Keys.F1 Then
            'If HelpAppButton.Enabled = True Then
            '    ShowHelp()
            'End If
        End If


        If e.Control Then

            If e.KeyCode = Keys.Z Then
                'Me.SpriteContainer.SetUndo()
            End If
            If e.KeyCode = Keys.Y Then
                'Me.SpriteContainer.SetRedo()
            End If

            If e.KeyCode = Keys.Enter Then
                'UpdateAction()
            End If

            If e.KeyCode = Keys.S Then
                'Save()
            End If


            If e.KeyCode = Keys.C Then
                Copy()
            End If

            If e.KeyCode = Keys.V Then
                Paste()
            End If

        End If

    End Sub



    Private Sub PaletteComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles PaletteComboBox.SelectedIndexChanged
        Me.edit_Palette = Me.Project.Palettes.GetPalette(Me.PaletteComboBox.SelectedIndex)
        RefreshPalette()
        undo.Clear()
    End Sub



    Private Sub RedTrackBar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedTrackBar.Scroll
        Me.RedTextBox.Text = RedTrackBar.Value
        showColor()
        setTone()
    End Sub



    Private Sub GreenTrackBar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GreenTrackBar.Scroll
        Me.GreenTextBox.Text = GreenTrackBar.Value
        showColor()
        setTone()
    End Sub



    Private Sub BlueTrackBar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BlueTrackBar.Scroll
        Me.BlueTextBox.Text = Me.BlueTrackBar.Value
        showColor()
        setTone()
    End Sub


    Private Sub ToneTrackBar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToneTrackBar.Scroll
        Dim tmpValue As Integer
        Dim diferencia As Integer
        Dim newValue As Integer = Me.ToneTrackBar.Value

        Me.ToneTextBox.Text = newValue

        diferencia = newValue - _lastTone

        tmpValue = Me.RedTrackBar.Value + diferencia
        If tmpValue < 0 Then
            tmpValue = 0
        ElseIf tmpValue > 7 Then
            tmpValue = 7
        End If
        Me.RedTrackBar.Value = tmpValue
        Me.RedTextBox.Text = tmpValue


        tmpValue = Me.GreenTrackBar.Value + diferencia
        If tmpValue < 0 Then
            tmpValue = 0
        ElseIf tmpValue > 7 Then
            tmpValue = 7
        End If
        Me.GreenTrackBar.Value = tmpValue
        Me.GreenTextBox.Text = tmpValue


        tmpValue = Me.BlueTrackBar.Value + diferencia
        If tmpValue < 0 Then
            tmpValue = 0
        ElseIf tmpValue > 7 Then
            tmpValue = 7
        End If
        Me.BlueTrackBar.Value = tmpValue
        Me.BlueTextBox.Text = tmpValue

        _lastTone = newValue

        showColor()

    End Sub


    Private Sub ColorPickerComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorPickerComboBox.SelectedIndexChanged
        Select Case ColorPickerComboBox.SelectedIndex
            Case 1
                ShowColorPickerRedGreen()
            Case 2
                ShowColorPickerGreenBlue()
            Case Else
                ShowColorPickerRedBlue()
        End Select
    End Sub


    Private Sub PalettePictureBox_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ColorPickerPictureBox.MouseClick
        Try
            Dim aColor As Color
            aColor = Me.paletteBitmap.GetPixel(e.X, e.Y)

            Me.RedTrackBar.Value = PaletteV9938.GetRed3(aColor.R)  'Me.Get3BitFrom8Bit(aColor.R)
            Me.GreenTrackBar.Value = PaletteV9938.GetGreen3(aColor.G)   'Me.Get3BitFrom8Bit(aColor.G)
            Me.BlueTrackBar.Value = PaletteV9938.GetBlue3(aColor.B)   'Me.Get3BitFrom8Bit(aColor.B)

            Me.RedTextBox.Text = Me.RedTrackBar.Value
            Me.GreenTextBox.Text = Me.GreenTrackBar.Value
            Me.BlueTextBox.Text = Me.BlueTrackBar.Value

            showColor()

            'Me.Refresh()

        Catch ex As Exception

        End Try
    End Sub


    Private Sub PalettePictureBox_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ColorPickerPictureBox.MouseMove
        'Dim x As Integer = Fix((e.X) / 8)
        'Dim y As Integer = Fix((e.Y) / 8)
        Try

            Dim aColor As Color = Me.paletteBitmap.GetPixel(e.X, e.Y)

            If Not ttipcolor = aColor Then
                'Dim textValue As String = "Color [R=" & Str(Get3BitFrom8Bit(aColor.R)) & ", G=" & Str(Get3BitFrom8Bit(aColor.G)) & ", B=" & Str(Get3BitFrom8Bit(aColor.B)) & "]"

                'Me.edit_Palette.RedColorConversionTable.IndexOf(aColor.R)
                Dim textValue As String = "Color [R=" + CStr(PaletteV9938.GetRed3(aColor.R))
                textValue = textValue + ", G=" + CStr(PaletteV9938.GetGreen3(aColor.G))
                textValue = textValue + ", B=" + CStr(PaletteV9938.GetBlue3(aColor.B))
                textValue = textValue + "]"

                Me.ToolTip1.SetToolTip(ColorPickerPictureBox, textValue)
                'Me.ToolTip1.Show(textValue, PalettePictureBox)

                ttipcolor = aColor

            End If


        Catch ex As Exception

        End Try

    End Sub



    Private Sub UpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateButton.Click

        Dim ColorBox As PictureBox

        ColorBox = PaletteGfxData.Item(_ColorSelected)
        ColorBox.BackColor = newColor.GetRGBColor() '.RGBColor 

        AddUndo()
        'Me.undo_Color = Me.edit_Palette.GetColor(_ColorSelected).Clone
        'Me.UndoButton.Enabled = True
        'Me.undo_type = 0

        Me.edit_Palette.SetColor(_ColorSelected, newColor)

    End Sub



    Private Sub NewPaletteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewPaletteButton.Click
        NewPalette()
    End Sub


    Private Sub DuplicatePaletteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DuplicatePaletteButton.Click
        DuplicateSelectedPalette()
    End Sub


    Private Sub ConfigPaletteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigPaletteButton.Click
        ConfigPalette()
    End Sub


    Private Sub DeletePaletteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeletePaletteButton.Click
        deletteSelectedPalette()
    End Sub




    Private Sub CopyButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyButton.Click
        CopyColorTool()
    End Sub



    Private Sub ChangeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeButton.Click
        ChangeColorTool()
    End Sub



    Private Sub UndoButton_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles UndoButton.MouseDown
        If e.Button = MouseButtons.Right Then
            SetRedo()
        Else
            SetUndo()
        End If
    End Sub



    Private Sub ClearButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearButton.Click

        Dim msgDialog = New MessageDialog("Clear Palette", "This option will lose the information about the current color palette." + Environment.NewLine + "Are you sure?", MessageDialog.DIALOG_TYPE.YES_NO)
        If msgDialog.ShowDialog(Me) = DialogResult.Yes Then
            ClearPalette()
        End If

    End Sub



    Private Sub OldColorPictureBox_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles RestoreOldColorPictureBox.MouseDoubleClick
        Me.newColor = Me.oldColor
        SetColorParameters()
    End Sub



    ' RB 0G
    Private Sub RBGTextBox_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles RBGTextBox.Validating

        Dim hexvalue As String = "0000" + RBGTextBox.Text
        Dim RedStr As String
        Dim BlueStr As String
        Dim GreenStr As String

        hexvalue = hexvalue.Substring(hexvalue.Length - 4)

        RedStr = hexvalue.Substring(0, 1)
        BlueStr = hexvalue.Substring(1, 1)
        GreenStr = hexvalue.Substring(3, 1)

        If Not IsNumeric(RedStr) Then
            RedStr = "0"
        ElseIf CInt(RedStr) > 7 Then
            RedStr = "7"
        End If

        If Not IsNumeric(BlueStr) Then
            BlueStr = "0"
        ElseIf CInt(BlueStr) > 7 Then
            BlueStr = "7"
        End If

        If Not IsNumeric(GreenStr) Then
            GreenStr = "0"
        ElseIf CInt(GreenStr) > 7 Then
            GreenStr = "7"
        End If

        'RBGTextBox.Text = RedStr + BlueStr + "0" + GreenStr
        RedTextBox.Text = RedStr
        GreenTextBox.Text = GreenStr
        BlueTextBox.Text = BlueStr

        Me.RedTrackBar.Value = CInt(RedStr)
        Me.GreenTrackBar.Value = CInt(GreenStr)
        Me.BlueTrackBar.Value = CInt(BlueStr)

        showColor()
        setTone()

    End Sub







    Private Sub RedTextBox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles RedTextBox.Validating
        Dim outputValue As Byte = 0
        If IsNumeric(RedTextBox.Text) Then
            Dim aValue As Byte = CByte(RedTextBox.Text)
            If aValue > 7 Then
                outputValue = 7
            ElseIf aValue < 0 Then
                outputValue = 0
            Else
                outputValue = aValue
            End If
        Else
            outputValue = 0
        End If

        RedTextBox.Text = CStr(outputValue)

        Me.RedTrackBar.Value = outputValue
        showColor()
        setTone()
    End Sub



    Private Sub GreenTextBox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles GreenTextBox.Validating
        Dim outputValue As Byte = 0
        If IsNumeric(GreenTextBox.Text) Then
            Dim aValue As Byte = CByte(GreenTextBox.Text)
            If aValue > 7 Then
                outputValue = 7
            ElseIf aValue < 0 Then
                outputValue = 0
            Else
                outputValue = aValue
            End If
        Else
            outputValue = 0
        End If

        GreenTextBox.Text = CStr(outputValue)

        Me.GreenTrackBar.Value = outputValue
        showColor()
        setTone()
    End Sub



    Private Sub BlueTextBox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles BlueTextBox.Validating
        Dim outputValue As Byte = 0
        If IsNumeric(BlueTextBox.Text) Then
            Dim aValue As Byte = CByte(BlueTextBox.Text)
            If aValue > 7 Then
                outputValue = 7
            ElseIf aValue < 0 Then
                outputValue = 0
            Else
                outputValue = aValue
            End If
        Else
            outputValue = 0
        End If

        BlueTextBox.Text = CStr(outputValue)

        Me.BlueTrackBar.Value = outputValue
        showColor()
        setTone()
    End Sub



    Private Sub LoadPaletteButton_Click(sender As Object, e As EventArgs) Handles LoadPaletteButton.Click
        Dim filePath As String = LoadPaletteDialog()

        If Not filePath = "" Then
            Me.LoadPalette(filePath)
        End If
    End Sub



    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        'If Me._isanApp = True Then

        SaveProjectDialog()

    End Sub



    'Private Sub SaveMSXOpenDocumentProject(ByVal filePath As String)
    '    Dim _tmsgfxIO As New MSXOpenDocumentIO(Me.AppConfig, Me.Project)
    '    _tmsgfxIO.SaveProject(filePath)
    'End Sub





    Private Function LoadPalette(ByVal filePath As String) As Boolean

        Dim result As Boolean = True

        Dim _tmsgfxIO As New MSXOpenDocumentIO(Me.AppConfig, Me.Project)

        Dim paletteName As String = ""
        Dim nameList As ArrayList

        Dim newID As Integer


        ' Get Map List
        nameList = _tmsgfxIO.GetNameListByNodeName(filePath, MSXOpenDocumentIO.PALETTES, MSXOpenDocumentIO.PALETTES_PAL)

        ' si solo hay uno, lo carga directamente
        If nameList.Count = 1 Then
            paletteName = nameList.Item(0)
        ElseIf nameList.Count > 1 Then
            ' show win with Map selector
            Dim aListSelectorDialog As New ListSelectorDialog("Load Palette", "Select a Palette:", "All Palettes", nameList)
            If aListSelectorDialog.ShowDialog() = DialogResult.OK Then

                If aListSelectorDialog.SelectedIndex > 0 Then
                    paletteName = aListSelectorDialog.SelectedItem()
                Else
                    paletteName = ""
                End If
            End If
        End If


        newID = _tmsgfxIO.LoadPalette(filePath, paletteName)

        If newID > 0 Then
            RefreshPaletteSelector()
            SelectPaletteByID(newID)
            Return True
        End If

        Return False

    End Function



    Public Function LoadPaletteDialog() As String

        'Me.OpenFileDialog1.DefaultExt = MSXOpenDocumentIO.Extension_PictureDocument
        Me.OpenFileDialog1.Filter = LoadTypes '"MSX Color Palette Open Document|*." + MSXOpenDocumentIO.Extension_PaletteDocument

        If Me.Project.Path = "" Then
            Me.OpenFileDialog1.FileName = ""
            Me.OpenFileDialog1.InitialDirectory = Me.AppConfig.PathPicture.Path
        Else
            Me.OpenFileDialog1.FileName = Path.GetFileNameWithoutExtension(Me.Project.Path)
            Me.OpenFileDialog1.InitialDirectory = Path.GetDirectoryName(Me.Project.Path)
        End If

        If Me.OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Return Me.OpenFileDialog1.FileName
        Else
            Return ""
        End If

    End Function



    'Private Sub Save()
    '    If Me.Project.Path = "" Then
    '        ' si no se ha cargado un proyecto, pide que se indique el nombre y ruta del fichero
    '        SaveProjectDialog()
    '    Else
    '        ' guarda directamente
    '        SaveProject(Me.Project.Path)
    '    End If
    'End Sub



    Public Sub SaveProjectDialog()
        Dim resultado As DialogResult


        'Me.SaveFileDialog1.DefaultExt = MSXOpenDocumentIO.Extension_PaletteDocument
        Me.SaveFileDialog1.Filter = "MSX Color Palette Open Document|*." + MSXOpenDocumentIO.Extension_PaletteDocument


        'If Not Me.defaultPath = "" Then
        '    Me.SaveFileDialog1.InitialDirectory = Me.defaultPath
        'End If

        If Me.Project.Path = "" Then
            Me.SaveFileDialog1.FileName = "" 'Me._mapsProject.Name
            Me.SaveFileDialog1.InitialDirectory = Me.AppConfig.PathItemPalette.Path
        Else
            Me.SaveFileDialog1.FileName = Path.GetFileNameWithoutExtension(Me.Project.Path)
            Me.SaveFileDialog1.InitialDirectory = Path.GetDirectoryName(Me.Project.Path)
        End If

        resultado = SaveFileDialog1.ShowDialog()

        If resultado = DialogResult.OK Then

            SaveProject(SaveFileDialog1.FileName)

        End If

    End Sub



    Private Sub GetDataButton_Click(sender As Object, e As EventArgs) Handles GetDataButton.Click
        ShowOutputDataWindow()
    End Sub



    Private Sub HelpButton_Click(sender As Object, e As EventArgs) Handles HelpButton.Click

        Dim helper As HelpWin

        'If System.IO.File.Exists(Me.HelpPath) Then
        helper = New HelpWin(Me.Name, Me.HelpPath)
        helper.ShowDialog()
        'End If

    End Sub


End Class
