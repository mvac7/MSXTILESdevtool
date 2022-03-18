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
        Me.NumFormatComboBox.SelectedIndex = Me.AppConfig.defCodeNumberSystem '_codeNumberFormat
        Me.SizeLineComboBox.SelectedIndex = Me.AppConfig.defCodeLineSize '_codeSizeLine
        Me.CompressTypeComboBox.SelectedIndex = Me.AppConfig.defCodeCompressType '_codeCompressType
        Me.AsmByteDataTextBox.Text = Me.AppConfig.defAsmByteCommand
        Me.AsmWordDataTextBox.Text = Me.AppConfig.defAsmWordDataCommand
        Me.CByteDataTextBox.Text = Me.AppConfig.defCByteCommand

        Me.BASICdataTextBox.Text = Me.AppConfig.defBASIC_DataInstruction
        Me.BASICcommentComboBox.SelectedIndex = GetBASIC_CommentInstruction_Index(Me.AppConfig.defBASIC_CommentInstruction)
        Me.BASICinitLineTextBox.Text = CStr(Me.AppConfig.defBASIC_initLine)
        Me.BASICincLineslTextBox.Text = CStr(Me.AppConfig.defBASIC_incLines)
        Me.RemoveZerosCheck.Checked = Me.AppConfig.defBASIC_remove0

        Me.DataLabelTextBox.Text = Me.AppConfig.defDataLabel

        Me.InfoNameTextBox.Text = Me.AppConfig.defAuthor

        If Not Me.AppConfig.PathLastProject = "" Then
            Me.PathLastPRJTextBox.Text = Path.GetFileName(Me.AppConfig.PathLastProject)
            Me.ToolTip1.SetToolTip(Me.PathLastPRJTextBox, Me.AppConfig.PathLastProject)
        End If

        SetColor(Me.Color0Button, Me.AppConfig.Color_Zero)
        SetColor(Me.GridColorButton, Me.AppConfig.Color_Grid)

        SetColor(Me.OutputINKcolorButton, Me.AppConfig.Color_OUTPUT_INK)
        SetColor(Me.OutputBGcolorButton, Me.AppConfig.Color_OUTPUT_BG)

        Select Case Me.AppConfig.firstProjectType
            Case Config.FIRST_PROJECT.NEWPROJECT
                Me.RadioButton2.Checked = True

            Case Config.FIRST_PROJECT.LASTPROJECT
                Me.RadioButton3.Checked = True

            Case Else
                Me.RadioButton1.Checked = True
        End Select

    End Sub



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
        Me.AppConfig.defCodeNumberSystem = Me.NumFormatComboBox.SelectedIndex
        Me.AppConfig.defCodeLineSize = Me.SizeLineComboBox.SelectedIndex
        Me.AppConfig.defCodeCompressType = Me.CompressTypeComboBox.SelectedIndex
        Me.AppConfig.defAsmByteCommand = Me.AsmByteDataTextBox.Text
        Me.AppConfig.defAsmWordDataCommand = Me.AsmWordDataTextBox.Text
        Me.AppConfig.defCByteCommand = Me.CByteDataTextBox.Text
        Me.AppConfig.defBASIC_initLine = CInt(Me.BASICinitLineTextBox.Text)
        Me.AppConfig.defBASIC_incLines = CInt(Me.BASICincLineslTextBox.Text)
        Me.AppConfig.defBASIC_remove0 = Me.RemoveZerosCheck.Checked
        Me.AppConfig.defBASIC_DataInstruction = Me.BASICdataTextBox.Text

        If Me.BASICcommentComboBox.SelectedIndex = 1 Then
            Me.AppConfig.defBASIC_CommentInstruction = "'"
        Else
            Me.AppConfig.defBASIC_CommentInstruction = "REM"
        End If

        Me.AppConfig.defDataLabel = Me.DataLabelTextBox.Text

        Me.AppConfig.defAuthor = Me.InfoNameTextBox.Text

        If Me.RadioButton2.Checked = True Then
            Me.AppConfig.firstProjectType = Config.FIRST_PROJECT.NEWPROJECT
        ElseIf Me.RadioButton3.Checked = True Then
            Me.AppConfig.firstProjectType = Config.FIRST_PROJECT.LASTPROJECT
        Else
            Me.AppConfig.firstProjectType = Config.FIRST_PROJECT.PRESENTATION
        End If


        Me.AppConfig.Color_Zero = Me.Color0Button.BackColor
        Me.AppConfig.Color_Grid = Me.GridColorButton.BackColor
        Me.AppConfig.Color_OUTPUT_INK = Me.OutputINKcolorButton.BackColor
        Me.AppConfig.Color_OUTPUT_BG = Me.OutputBGcolorButton.BackColor


        Me.AppConfig.InitOutputInfo()
        ' ######################################################################

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub



    Public Function GetBASIC_CommentInstruction_Index(value As String) As Integer
        If value.ToUpper = "REM" Then
            Return 0
        Else
            Return 1
        End If
    End Function



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



    Private Sub Color0Button_Click(sender As Object, e As EventArgs) Handles Color0Button.Click, GridColorButton.Click, OutputINKcolorButton.Click, OutputBGcolorButton.Click
        Dim aButtom As Button = CType(sender, Button)
        Me.ColorDialog1.Color = aButtom.BackColor
        Me.ColorDialog1.ShowDialog()
        SetColor(aButtom, Me.ColorDialog1.Color)
    End Sub



    'Private Sub GridColorButton_Click(sender As Object, e As EventArgs) Handles GridColorButton.Click
    '    Me.ColorDialog1.Color = Me.GridColorButton.BackColor
    '    Me.ColorDialog1.ShowDialog()
    '    SetColor(Me.GridColorButton, Me.ColorDialog1.Color)
    'End Sub


    'Private Sub OutputINKcolorButton_Click(sender As Object, e As EventArgs) Handles OutputINKcolorButton.Click

    'End Sub

    'Private Sub OutputBGcolorButton_Click(sender As Object, e As EventArgs) Handles OutputBGcolorButton.Click

    'End Sub



    Private Sub SetColor(ByRef aButton As Button, ByVal newColor As Color)
        aButton.BackColor = newColor
        aButton.Text = newColor.Name
        If newColor.GetBrightness > 0.7 Then
            aButton.ForeColor = Color.Black
        Else
            aButton.ForeColor = Color.White
        End If
    End Sub



    'Private Sub SetZeroColor(ByVal newColor As Color)
    '    Me.Color0Button.BackColor = newColor
    '    Me.Color0Button.Text = newColor.Name
    '    If newColor.GetBrightness > 0.7 Then
    '        Me.Color0Button.ForeColor = Color.Black
    '    Else
    '        Me.Color0Button.ForeColor = Color.White
    '    End If
    'End Sub



    'Private Sub SetGridColor(ByVal newColor As Color)
    '    Me.GridColorButton.BackColor = newColor
    '    Me.GridColorButton.Text = newColor.Name
    '    If newColor.GetBrightness > 0.7 Then
    '        Me.GridColorButton.ForeColor = Color.Black
    '    Else
    '        Me.GridColorButton.ForeColor = Color.White
    '    End If
    'End Sub



    Private Sub AsmByteValuesComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AsmByteValuesComboBox.SelectedIndexChanged
        AsmByteDataTextBox.Text = AsmByteValuesComboBox.SelectedItem
    End Sub



    Private Sub AsmWordComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AsmWordValuesComboBox.SelectedIndexChanged
        AsmWordDataTextBox.Text = AsmWordValuesComboBox.SelectedItem
    End Sub



    Private Sub ColorConfigsComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ColorConfigsComboBox.SelectedIndexChanged

        Select Case ColorConfigsComboBox.SelectedIndex
            Case 1
                ' blue MSX BASIC
                SetColor(Me.OutputINKcolorButton, Color.FromArgb(255, 255, 255, 255))   'White
                SetColor(Me.OutputBGcolorButton, Color.FromArgb(255, 84, 85, 237))      'TMS9918A Dark Blue

            Case 2
                ' green GB
                SetColor(Me.OutputINKcolorButton, Color.FromArgb(255, 15, 56, 15))    ' light green
                SetColor(Me.OutputBGcolorButton, Color.FromArgb(255, 202, 220, 159))  ' dark green

            Case Else
                ' default
                SetColor(Me.OutputINKcolorButton, Me.AppConfig.def_Color_OUTPUT_INK)
                SetColor(Me.OutputBGcolorButton, Me.AppConfig.def_Color_OUTPUT_BG)

        End Select

    End Sub



End Class