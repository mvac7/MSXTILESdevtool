Imports System.IO
Imports mSXdevtools.GUI.Controls



Public Class OutputDataWin

    Private AppConfig As Config
    Private Info As ProjectInfo
    Private Project As PaletteProject

    Private aMSXDataFormat As New DataFormat

    Private _selectedID As Integer

    Private outputData As ArrayList
    Private outputName As String = ""

    Private ProjectPath As String = ""



    Public Sub New(ByVal _config As Config, ByVal _projectInfo As ProjectInfo, ByVal paletteProject As PaletteProject, ByVal selectedID As Integer) 'ByVal _projectName As String, ByVal _sprites As SortedList, ByVal _PaletteColors As PaletteMSX, ByVal _projectMode As Integer, ByVal _projectType As Integer

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.AppConfig = _config
        Me.Info = _projectInfo
        Me.Project = paletteProject
        Me._selectedID = selectedID

        Me.outputData = New ArrayList

    End Sub



    Private Sub OutputDataForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim counter As Integer = 1

        Me.PaletteComboBox.Items.Clear()
        If Me.Project.Count > 0 Then
            Me.PaletteComboBox.Items.Add("All Palettes")
            For i As Integer = 1 To Me.Project.Count
                Me.PaletteComboBox.Items.Add(CStr(i) + " - " + Me.Project.GetPalette(i).Name)
            Next
            Me.PaletteComboBox.SelectedIndex = Me.Project.GetIndexFromID(Me._selectedID)
        End If


        Me.DataTypeInput.AppConfig = Me.AppConfig
        Me.DataTypeInput.EnableDataSizeLine = True
        Me.DataTypeInput.InitControl()

        Me.RGBformatComboBox.SelectedIndex = 0

        AddHandler RGBformatComboBox.SelectedIndexChanged, AddressOf Me.RGBformatComboBox_SelectedIndexChanged
        AddHandler DataTypeInput.DataChanged, AddressOf Me.DataTypeInput_DataChanged
        AddHandler PaletteComboBox.SelectedIndexChanged, AddressOf Me.PaletteComboBox_SelectedIndexChanged

    End Sub



    'Public Sub reset()
    '    'me.LineNumberText.Text = "10000"
    '    'Me.IntervalText.Text = "10"
    'End Sub



    Private Sub ExitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitButton.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub



    Private Sub GetDataButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetDataButton.Click
        genData()
    End Sub



    Private Sub DataTypeInput_DataChanged() 'Handles DataTypeInput.DataChanged
        GenData()
    End Sub



    Private Sub RGBformatComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) 'Handles RGBformatComboBox.SelectedIndexChanged
        genData()
    End Sub



    Private Sub PaletteComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) 'Handles PaletteComboBox.SelectedIndexChanged
        If PaletteComboBox.SelectedIndex = 0 Then
            Me.DataTypeInput.AsmEnableIndex = True
        Else
            Me.DataTypeInput.AsmEnableIndex = False
        End If
        genData()
    End Sub



    Private Sub genData()

        Dim outputSource As String = ""
        Dim _outputText As String = ""

        Dim LineNumber As Integer = Me.DataTypeInput.BASIClineNumber
        'Dim Interval As Integer = CInt(Me.IntervalText.Text)

        Dim CommentDataFormat As String

        Dim _palette As PaletteV9938

        Dim comments As New ArrayList

        Dim tmpData As Byte()

        Dim paletteFirst As Integer = 0
        Dim paletteLast As Integer = 0

        Dim paletteNumber As Integer

        'Dim aRLE As New RLE

        Dim sizeline As Integer


        Me.SaveDataButton.Enabled = True

        Me.outputData.Clear()



        ' first comment
        'Select Case Me.DataTypeInput.CodeLanguage
        '    Case MSXDataFormat.OutputFormat.C
        '        _outputText = "// Project: " + Me.Info.Name + vbNewLine
        '        _outputText += "// " + CommentDataFormat + vbNewLine

        '        'Case MSXDataFormat.OutputFormat.ASM
        '        '    _outputText = "; " + Me._paletteProject.Name + vbNewLine

        '        'Case MSXDataFormat.OutputFormat.ASM_SDCC


        '    Case MSXDataFormat.OutputFormat.BASIC
        '        _outputText = CStr(LineNumber) + " REM " + Me.Info.Name + vbNewLine
        '        LineNumber += Me.DataTypeInput.BASICInterval
        '        _outputText += CStr(LineNumber) + " REM " + CommentDataFormat + vbNewLine
        '        LineNumber += Me.DataTypeInput.BASICInterval
        '        Me.aMSXDataFormat.lastLineNumber = LineNumber

        '    Case Else
        '        _outputText = "; Project: " + Me.Info.Name + vbNewLine
        '        _outputText += "; " + CommentDataFormat + vbNewLine

        'End Select



        If Me.RGBformatComboBox.SelectedIndex = 0 Then
            CommentDataFormat = "RB,G"
        Else
            CommentDataFormat = "R,G,B"
        End If



        comments.Add("Project: " + Me.Info.Name)
        comments.Add(CommentDataFormat)

        If Me.DataTypeInput.CodeLanguage = DataFormat.ProgrammingLanguage.BASIC Then
            _outputText = Me.aMSXDataFormat.GetBASICComments(comments, Me.DataTypeInput.BASIClineNumber, Me.DataTypeInput.BASICInterval)
        Else
            _outputText = Me.aMSXDataFormat.GetComments(comments, Me.DataTypeInput.CodeLanguage)
        End If


        ' range of palettes
        If PaletteComboBox.SelectedIndex = 0 Then
            paletteFirst = 1
            paletteLast = Me.Project.Count
        Else
            paletteFirst = PaletteComboBox.SelectedIndex
            paletteLast = paletteFirst
        End If



        ' Assembler Index Labels
        If PaletteComboBox.SelectedIndex = 0 And Me.DataTypeInput.CodeLanguage = DataFormat.ProgrammingLanguage.ASSEMBLER And Me.DataTypeInput.ASMaddIndex Then
            _outputText += "PALETTE_INDEX:" + vbNewLine
            _outputText += Me.AppConfig.lastAsmWordDataCommand + " "
            For paletteNumber = paletteFirst To paletteLast - 1
                _outputText += Me.aMSXDataFormat.GetAsmFieldFormat(Me.Project.GetPalette(paletteNumber).Name) + ","
            Next
            _outputText += Me.aMSXDataFormat.GetAsmFieldFormat(Me.Project.GetPalette(paletteNumber).Name) + vbNewLine
            _outputText += vbNewLine
        End If



        If Me.DataTypeInput.SizeLineIndex = 0 Then
            ' item
            If RGBformatComboBox.SelectedIndex = 0 Then
                sizeline = 2
            Else
                sizeline = 3
            End If

        Else
            ' one line
            If RGBformatComboBox.SelectedIndex = 0 Then
                sizeline = 32
            Else
                sizeline = 48
            End If
        End If


        For paletteNumber = paletteFirst To paletteLast

            comments.Clear()

            ' Collect the data
            _palette = Me.Project.GetPalette(paletteNumber)
            If Me.RGBformatComboBox.SelectedIndex = 0 Then
                tmpData = _palette.GetDataRBG() ' RB,G 
            Else
                tmpData = _palette.GetData() 'R,G,B
            End If

            ' show data in respective code language
            Select Case Me.DataTypeInput.CodeLanguage
                Case DataFormat.ProgrammingLanguage.C
                    outputSource = Me.aMSXDataFormat.GetCcode(tmpData, sizeline, Me.DataTypeInput.NumeralSystem, _palette.Name, comments, Me.AppConfig.lastCByteCommand)
                Case DataFormat.ProgrammingLanguage.ASSEMBLER
                    outputSource = Me.aMSXDataFormat.GetAssemblerCode(tmpData, sizeline, Me.DataTypeInput.NumeralSystem, _palette.Name, comments, Me.AppConfig.lastAsmByteCommand)
                Case DataFormat.ProgrammingLanguage.BASIC
                    outputSource = Me.aMSXDataFormat.GetBASICcode(tmpData, sizeline, Me.DataTypeInput.NumeralSystem, Me.DataTypeInput.BASICremoveZeros, Me.aMSXDataFormat.BASIClineNumber, Me.DataTypeInput.BASICInterval, comments)
            End Select

            Me.outputData.Add(tmpData) 'addrange

            _outputText += outputSource + vbNewLine

        Next

        OutputText.Text = _outputText

    End Sub



    Private Sub CopyAllButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyAllButton.Click

        If Me.OutputText.Text = "" Then
            MsgBox("Nothing to copy for you.", MsgBoxStyle.Exclamation, "Alert")
        Else
            My.Computer.Clipboard.SetText(Me.OutputText.Text)
        End If

    End Sub



    ''' <summary>
    ''' Muestra el dialogo para guardar un fichero. Lo prepara para el lenguaje seleccionado.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SaveDataButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveDataButton.Click
        Dim resultado As System.Windows.Forms.DialogResult

        If Me.OutputText.Text = "" Then
            MsgBox("Nothing to save for you.", MsgBoxStyle.Exclamation, "Alert")

        Else

            Me.SaveFileDialog1.FileName = Me.Info.Name
            Me.SaveFileDialog1.InitialDirectory = Me.AppConfig.PathItemProject.pathLast

            Select Case Me.DataTypeInput.CodeLanguage
                Case DataFormat.ProgrammingLanguage.BASIC
                    Me.SaveFileDialog1.DefaultExt = "BAS"
                    Me.SaveFileDialog1.Filter = "BASIC file|*.BAS"
                Case DataFormat.ProgrammingLanguage.C
                    Me.SaveFileDialog1.DefaultExt = "c"
                    Me.SaveFileDialog1.Filter = "C file|*.c"
                Case DataFormat.ProgrammingLanguage.ASSEMBLER
                    Me.SaveFileDialog1.DefaultExt = "asm"
                    Me.SaveFileDialog1.Filter = "ASM file|*.asm"

            End Select

            'Me.SaveFileDialog1.Filter = "ASM file|*.asm|C file|*.c|BASIC file|*.bas"

            resultado = SaveFileDialog1.ShowDialog()

            If resultado = Windows.Forms.DialogResult.OK Then

                'Me.ProjectFilePath = SaveFileDialog1.FileName

                Me.saveCode(SaveFileDialog1.FileName)

            End If

        End If

    End Sub



    Private Sub saveCode(ByVal filePath As String)
        Dim aStreamWriterFile As New System.IO.StreamWriter(filePath)
        aStreamWriterFile.WriteLine(Me.OutputText.Text)
        aStreamWriterFile.Close()
    End Sub



    Private Sub SaveBinaryDialog()
        Dim result As System.Windows.Forms.DialogResult

        If Me.outputData.Count = 0 Then

            Dim msgDialog = New MessageDialog("Save Binary File", "Nothing to save for you." + Environment.NewLine + "Generate the data", MessageDialog.DIALOG_TYPE.ALERT)
            msgDialog.ShowDialog(Me)

        Else
            'This option saves two binary files with the data of the Patterns and the colors separated.

            Me.SaveFileDialog1.FileName = Me.outputName
            Me.SaveFileDialog1.InitialDirectory = System.IO.Path.GetDirectoryName(Me.ProjectPath)

            Me.SaveFileDialog1.DefaultExt = "bin"
            Me.SaveFileDialog1.Filter = "Binary file|*.bin"


            result = SaveFileDialog1.ShowDialog()

            If result = Windows.Forms.DialogResult.OK Then

                Me.SaveBinary(SaveFileDialog1.FileName)

                Me.ProjectPath = SaveFileDialog1.FileName

            End If

        End If
    End Sub



    Public Sub SaveBinary(ByVal filePath As String)

        Dim aStream As FileStream

        Dim dataBin As Byte()
        'Try

        Dim newFilePath As String

        For i = 0 To outputData.Count - 1
            ' save a palette Binary File

            dataBin = outputData.Item(i)
            If outputData.Count > 1 Then
                newFilePath = Path.GetDirectoryName(filePath) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(filePath) + "_PAL" + CStr(i) + ".bin"
            Else
                newFilePath = filePath
            End If

            aStream = New FileStream(newFilePath, IO.FileMode.Create)
            aStream.Write(dataBin, 0, dataBin.Length)
            aStream.Close()
        Next

        'Catch ex As Exception

        'End Try

    End Sub



End Class