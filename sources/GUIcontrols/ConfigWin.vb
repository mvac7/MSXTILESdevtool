Imports System.IO




Public Class ConfigWin

    Private AppConfig As Config

    Private _type As CONFIG_TYPE



    Public Shadows Enum CONFIG_TYPE As Integer
        TMSGFX
        SPRITESX
        MAPSX
        TILESETSX
        PALETTESX
        SQUAREDSX
        BYTEGEN
        OAMSX
        PAINTSX
    End Enum



    Public Sub New(ByRef _config As Config, ByVal aType As CONFIG_TYPE) 'ByVal _workPathType As Integer, ByVal _workPath As String, ByVal _codeOutput As Integer, ByVal _codeNumberFormat As Integer, ByVal _codeSizeLine As Integer, ByVal _codeCompressType As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.AppConfig = _config
        Me._type = aType

        Select Case Me._type
            Case CONFIG_TYPE.BYTEGEN
                Me.BytegenPathControl.Visible = True
                Me.MSXBASICPathControl.Visible = True
                Me.BinaryPathControl.Visible = True

            Case CONFIG_TYPE.PAINTSX
                '
                Me.MSXBASICPathControl.Visible = True
                Me.BitmapsPathControl.Visible = True
                Me.PalettesPathControl.Visible = True

            Case CONFIG_TYPE.PALETTESX
                Me.PalettesPathControl.Visible = True

            Case CONFIG_TYPE.SPRITESX
                Me.SpritesPathControl.Visible = True
                Me.MSXBASICPathControl.Visible = True
                Me.BitmapsPathControl.Visible = True
                Me.PalettesPathControl.Visible = True

            Case CONFIG_TYPE.MAPSX
                Me.MapsPathControl.Visible = True
                Me.TilesetsPathControl.Visible = True

                Me.nMSXtilesPathControl.Visible = True
                Me.MSXBASICPathControl.Visible = True
                Me.PalettesPathControl.Visible = True

            Case CONFIG_TYPE.TILESETSX
                Me.TilesetsPathControl.Visible = True

                Me.nMSXtilesPathControl.Visible = True
                Me.MSXBASICPathControl.Visible = True
                Me.BitmapsPathControl.Visible = True
                Me.PalettesPathControl.Visible = True

            Case CONFIG_TYPE.SQUAREDSX
                Me.SquaredsetsPathControl.Visible = True
                Me.TilesetsPathControl.Visible = True
                Me.PalettesPathControl.Visible = True

            Case CONFIG_TYPE.OAMSX
                Me.OAMPathControl.Visible = True
                Me.SpritesPathControl.Visible = True
                Me.PalettesPathControl.Visible = True

            Case Else
                Me.tMSgfXProjectPathControl.Visible = True
                Me.SpritesPathControl.Visible = True
                Me.MapsPathControl.Visible = True
                Me.TilesetsPathControl.Visible = True
                Me.SquaredsetsPathControl.Visible = True
                Me.PalettesPathControl.Visible = True
                Me.OAMPathControl.Visible = True

                Me.nMSXtilesPathControl.Visible = True
                Me.MSXBASICPathControl.Visible = True
                Me.BitmapsPathControl.Visible = True
                Me.BinaryPathControl.Visible = True

        End Select

        'Me.WorkpathComboBox.SelectedIndex = Me.AppConfig.PathProject_Type '_workPathType
        'Me.UserpathTextBox.Text = Me.AppConfig.PathProject '_workPath
        'Me.nmsxtilesTextBox.Text = Me.AppConfig.PathNMSXtiles
        'Me.BinaryTextBox.Text = Me.AppConfig.PathBinary
        'Me.BitmapTextBox.Text = Me.AppConfig.PathBitmap
        'Me.PaletteTextBox.Text = Me.AppConfig.PathPalette
        'Me.SpritesTextBox.Text = Me.AppConfig.PathSprite

        tMSgfXProjectPathControl.SetItem(Me.AppConfig.PathItemProject)
        SpritesPathControl.SetItem(Me.AppConfig.PathItemSprite)
        MapsPathControl.SetItem(Me.AppConfig.PathItemMap)
        TilesetsPathControl.SetItem(Me.AppConfig.PathItemTileset)
        SquaredsetsPathControl.SetItem(Me.AppConfig.PathItemSupertile)
        PalettesPathControl.SetItem(Me.AppConfig.PathItemPalette)
        OAMPathControl.SetItem(Me.AppConfig.PathItemOAM)
        BytegenPathControl.SetItem(Me.AppConfig.PathByteGen)

        nMSXtilesPathControl.SetItem(Me.AppConfig.PathItemNMSXtiles)
        MSXBASICPathControl.SetItem(Me.AppConfig.PathItemMSXBASIC)
        BitmapsPathControl.SetItem(Me.AppConfig.PathItemBitmap)
        BinaryPathControl.SetItem(Me.AppConfig.PathItemBinary)


        Me.CodeOutputComboBox.SelectedIndex = Me.AppConfig.defCodeOutput '_codeOutput
        Me.NumFormatComboBox.SelectedIndex = Me.AppConfig.defCodeNumberFormat '_codeNumberFormat
        Me.SizeLineComboBox.SelectedIndex = Me.AppConfig.defCodeSizeLine '_codeSizeLine
        Me.CompressTypeComboBox.SelectedIndex = Me.AppConfig.defCodeCompressType '_codeCompressType
        Me.AsmByteDataTextBox.Text = Me.AppConfig.defAsmByteCommand
        Me.AsmWordDataTextBox.Text = Me.AppConfig.defAsmWordDataCommand
        Me.CByteDataTextBox.Text = Me.AppConfig.defCByteCommand
        Me.BASICinitLineTextBox.Text = CStr(Me.AppConfig.defBASICinitLine)
        Me.BASICincLineslTextBox.Text = CStr(Me.AppConfig.defBASICincLines)
        Me.RemoveZerosCheck.Checked = Me.AppConfig.defBASICremove0
        Me.DataLabelTextBox.Text = Me.AppConfig.defDataLabel

        Me.InfoNameTextBox.Text = Me.AppConfig.defAuthor

        If Not Me.AppConfig.PathLastProject = "" Then
            Me.PathLastPRJTextBox.Text = Path.GetFileName(Me.AppConfig.PathLastProject)
            Me.ToolTip1.SetToolTip(Me.PathLastPRJTextBox, Me.AppConfig.PathLastProject)
        End If


        SetZeroColor(Me.AppConfig.ZeroColor)
        SetGridColor(Me.AppConfig.GridColor)


        Select Case Me.AppConfig.firstProjectType
            Case Config.FIRST_PROJECT.NEWPROJECT
                Me.RadioButton2.Checked = True

            Case Config.FIRST_PROJECT.LASTPROJECT
                Me.RadioButton3.Checked = True

            Case Else
                Me.RadioButton1.Checked = True
        End Select



    End Sub



    'Private Sub WorkpathComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Select Case Me.WorkpathComboBox.SelectedIndex
    '        Case 2
    '            'UserpathLabel.Enabled = True
    '            UserpathTextBox.Enabled = True
    '            UserpathButton.Enabled = True
    '        Case Else
    '            'UserpathLabel.Enabled = False
    '            UserpathTextBox.Enabled = False
    '            UserpathButton.Enabled = False
    '    End Select
    'End Sub



    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        ' ######################################################################
        ' update config data        
        Me.AppConfig.PathItemProject = tMSgfXProjectPathControl.GetItem()
        Me.AppConfig.PathItemSprite = SpritesPathControl.GetItem()
        Me.AppConfig.PathItemMap = MapsPathControl.GetItem()
        Me.AppConfig.PathItemTileset = TilesetsPathControl.GetItem()
        Me.AppConfig.PathItemPalette = PalettesPathControl.GetItem()
        Me.AppConfig.PathItemOAM = OAMPathControl.GetItem()
        Me.AppConfig.PathItemSupertile = SquaredsetsPathControl.GetItem()
        Me.AppConfig.PathByteGen = BytegenPathControl.GetItem()


        Me.AppConfig.PathItemNMSXtiles = nMSXtilesPathControl.GetItem()
        Me.AppConfig.PathItemMSXBASIC = MSXBASICPathControl.GetItem()
        Me.AppConfig.PathItemBitmap = BitmapsPathControl.GetItem()
        Me.AppConfig.PathItemBinary = BinaryPathControl.GetItem()

        Me.AppConfig.defCodeOutput = Me.CodeOutputComboBox.SelectedIndex
        Me.AppConfig.defCodeNumberFormat = Me.NumFormatComboBox.SelectedIndex
        Me.AppConfig.defCodeSizeLine = Me.SizeLineComboBox.SelectedIndex
        Me.AppConfig.defCodeCompressType = Me.CompressTypeComboBox.SelectedIndex
        Me.AppConfig.defAsmByteCommand = Me.AsmByteDataTextBox.Text
        Me.AppConfig.defAsmWordDataCommand = Me.AsmWordDataTextBox.Text
        Me.AppConfig.defCByteCommand = Me.CByteDataTextBox.Text
        Me.AppConfig.defBASICinitLine = CInt(Me.BASICinitLineTextBox.Text)
        Me.AppConfig.defBASICincLines = CInt(Me.BASICincLineslTextBox.Text)
        Me.AppConfig.defBASICremove0 = Me.RemoveZerosCheck.Checked
        Me.AppConfig.defDataLabel = Me.DataLabelTextBox.Text

        Me.AppConfig.defAuthor = Me.InfoNameTextBox.Text

        If Me.RadioButton2.Checked = True Then
            Me.AppConfig.firstProjectType = Config.FIRST_PROJECT.NEWPROJECT
        ElseIf Me.RadioButton3.Checked = True Then
            Me.AppConfig.firstProjectType = Config.FIRST_PROJECT.LASTPROJECT
        Else
            Me.AppConfig.firstProjectType = Config.FIRST_PROJECT.PRESENTATION
        End If


        Me.AppConfig.ZeroColor = Me.Color0Button.BackColor
        Me.AppConfig.GridColor = Me.GridColorButton.BackColor


        Me.AppConfig.InitOutputInfo()
        ' ######################################################################

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub



    'Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
    '    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    '    Me.Close()
    'End Sub



    'Private Sub UserpathButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FolderBrowserDialog1.SelectedPath = Me.UserpathTextBox.Text

    '    If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '        Me.UserpathTextBox.Text = FolderBrowserDialog1.SelectedPath
    '    End If
    'End Sub



    'Private Sub nmsxtilesButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Me.nmsxtilesTextBox.Text = "" Then
    '        FolderBrowserDialog1.SelectedPath = Me.AppConfig.PathProject
    '    Else
    '        FolderBrowserDialog1.SelectedPath = Me.nmsxtilesTextBox.Text
    '    End If

    '    If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '        Me.nmsxtilesTextBox.Text = FolderBrowserDialog1.SelectedPath
    '    End If
    'End Sub



    'Private Sub BinaryButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Me.BinaryTextBox.Text = "" Then
    '        FolderBrowserDialog1.SelectedPath = Me.AppConfig.PathProject
    '    Else
    '        FolderBrowserDialog1.SelectedPath = Me.BinaryTextBox.Text
    '    End If

    '    If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '        Me.BinaryTextBox.Text = FolderBrowserDialog1.SelectedPath
    '    End If
    'End Sub



    'Private Sub BitmapButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Me.BitmapTextBox.Text = "" Then
    '        FolderBrowserDialog1.SelectedPath = Me.AppConfig.PathProject
    '    Else
    '        FolderBrowserDialog1.SelectedPath = Me.BitmapTextBox.Text
    '    End If

    '    If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '        Me.BitmapTextBox.Text = FolderBrowserDialog1.SelectedPath
    '    End If
    'End Sub


    'Private Sub PaletteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaletteButton.Click
    '    If Me.PaletteTextBox.Text = "" Then
    '        FolderBrowserDialog1.SelectedPath = Me.AppConfig.PathProject
    '    Else
    '        FolderBrowserDialog1.SelectedPath = Me.PaletteTextBox.Text
    '    End If

    '    If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '        Me.PaletteTextBox.Text = FolderBrowserDialog1.SelectedPath
    '    End If
    'End Sub

    'Private Sub SpritesButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Me.SpritesTextBox.Text = "" Then
    '        FolderBrowserDialog1.SelectedPath = Me.AppConfig.PathProject
    '    Else
    '        FolderBrowserDialog1.SelectedPath = Me.SpritesTextBox.Text
    '    End If

    '    If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '        Me.SpritesTextBox.Text = FolderBrowserDialog1.SelectedPath
    '    End If
    'End Sub



    Private Sub BASICinitLineText_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles BASICinitLineTextBox.Validating
        Dim value As Integer

        If Not IsNumeric(Me.BASICinitLineTextBox.Text) Then
            value = 1000
        Else
            value = CInt(Me.BASICinitLineTextBox.Text)

            If value > 30000 Then
                value = 1000
            ElseIf value < 1 Then
                value = 1
            End If
        End If

        Me.BASICinitLineTextBox.Text = CStr(value)
    End Sub



    Private Sub BASICincLineslTextBox_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles BASICincLineslTextBox.Validating
        Dim value As Integer

        If Not IsNumeric(Me.BASICincLineslTextBox.Text) Then
            value = 10
        Else
            value = CInt(Me.BASICincLineslTextBox.Text)

            If value > 255 Then
                value = 255
            ElseIf value < 1 Then
                value = 1
            End If
        End If

        Me.BASICincLineslTextBox.Text = CStr(value)
    End Sub



    Private Sub Color0Button_Click(sender As Object, e As EventArgs) Handles Color0Button.Click
        Me.ColorDialog1.Color = Me.Color0Button.BackColor
        Me.ColorDialog1.ShowDialog()
        SetZeroColor(Me.ColorDialog1.Color)

    End Sub



    Private Sub GridColorButton_Click(sender As Object, e As EventArgs) Handles GridColorButton.Click
        Me.ColorDialog1.Color = Me.GridColorButton.BackColor
        Me.ColorDialog1.ShowDialog()
        SetGridColor(Me.ColorDialog1.Color)
    End Sub



    Private Sub SetZeroColor(ByVal newColor As Color)
        Me.Color0Button.BackColor = newColor
        Me.Color0Button.Text = newColor.Name
        If newColor.GetBrightness > 0.7 Then
            Me.Color0Button.ForeColor = Color.Black
        Else
            Me.Color0Button.ForeColor = Color.White
        End If
    End Sub



    Private Sub SetGridColor(ByVal newColor As Color)
        Me.GridColorButton.BackColor = newColor
        Me.GridColorButton.Text = newColor.Name
        If newColor.GetBrightness > 0.7 Then
            Me.GridColorButton.ForeColor = Color.Black
        Else
            Me.GridColorButton.ForeColor = Color.White
        End If
    End Sub



End Class