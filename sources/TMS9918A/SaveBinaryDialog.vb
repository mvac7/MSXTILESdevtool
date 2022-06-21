Imports System.Windows.Forms
Imports System.IO


Public Class SaveBinaryDialog

    Private AppConfig As Config

    Public ScreenMode As iVDP.SCREEN_MODE
    Public VDPtype As iPaletteMSX.VDP = iPaletteMSX.VDP.TMS9918
    'Public def_WorkPath As String
    Public FilePath As String
    Public ProjectName As String
    Private FileExtension As String = "BIN"

    'Public Type As DIALOGTYPE = DIALOGTYPE.BINARY



    'Public Shadows Enum DIALOGTYPE As Integer
    '    BINARY
    '    MSXBASIC
    'End Enum



    Public Sub New(ByVal _config As Config, ByVal name As String, ByVal mode As iVDP.SCREEN_MODE, ByVal typeVDP As iPaletteMSX.VDP)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        '' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        'Me.Type = dialogType
        Me.ScreenMode = mode
        Me.VDPtype = typeVDP
        'Me.def_WorkPath = workPath

        Me.AppConfig = _config

        Me.ProjectName = name

        Me.FilePath = ""

    End Sub



    Private Sub BSaveDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim extension As String
        Dim aVRAMmap As New VRAM_MapClass
        VRAM_DataCombobox.Items.AddRange(aVRAMmap.GetMapListFromMode(Me.ScreenMode))
        VRAM_DataCombobox.SelectedIndex = 0

        Me.FileExtension = getExtension()

        Me.ExtensionTextBox.Text = "." + Me.FileExtension

        'If Not Me.FilePath = "" Then
        '    Dim tmpPath As String = Path.GetDirectoryName(Me.FilePath) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(Me.FilePath) + "." + Me.FileExtension
        '    Me.FilePath = tmpPath
        '    FileNameTextBox.Text = Path.GetFileName(Me.FilePath)
        'End If

        Save_Button.Select() 'foco

    End Sub



    Public ReadOnly Property HasHeader() As Boolean
        Get
            Return Me.BasicHeadCheck.Checked
        End Get
    End Property



    Public ReadOnly Property StartAddress() As Integer
        Get
            Return Integer.Parse(VRAM_startTextBox.Text, System.Globalization.NumberStyles.HexNumber)
        End Get
    End Property



    Public ReadOnly Property EndAddress() As Integer
        Get
            Dim starADDR As Integer = Integer.Parse(VRAM_startTextBox.Text, System.Globalization.NumberStyles.HexNumber)
            Dim bloq_size As Integer = Integer.Parse(VRAM_sizeTextBox.Text, System.Globalization.NumberStyles.HexNumber)
            Return starADDR + bloq_size
        End Get
    End Property



    Public ReadOnly Property BloqSize() As Integer
        Get
            Return Integer.Parse(VRAM_sizeTextBox.Text, System.Globalization.NumberStyles.HexNumber)
        End Get
    End Property



    Private Sub VRAM_DataCombobox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VRAM_DataCombobox.SelectedIndexChanged
        Dim aVRAMmap As New VRAM_MapClass
        VRAM_startTextBox.Text = Hex(aVRAMmap.GetVADDRbyIndex(Me.ScreenMode, VRAM_DataCombobox.SelectedIndex))
        VRAM_sizeTextBox.Text = Hex(aVRAMmap.GetSizebyIndex(Me.ScreenMode, VRAM_DataCombobox.SelectedIndex))
    End Sub



    Private Sub VRAM_startTextBox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles VRAM_startTextBox.Validating
        Try
            Dim starADDR As Integer = Integer.Parse(VRAM_startTextBox.Text, System.Globalization.NumberStyles.HexNumber)
            'Dim bloqSize As Integer = Integer.Parse(VRAM_endTextBox.Text, System.Globalization.NumberStyles.HexNumber)

            If starADDR > 16383 Then
                MsgBox("The value can not be higher than h3FFF (VRAM 16K).", MsgBoxStyle.Critical, "Error")
                VRAM_startTextBox.Text = "0000"
                VRAM_startTextBox.Focus()
            End If

            'If starADDR > endADDR Then
            '    MsgBox("The initial value must be lower than the final value..", MsgBoxStyle.Critical, "Error")
            '    VRAM_startTextBox.Text = "0000"
            '    VRAM_startTextBox.Focus()
            'End If

        Catch ex As Exception
            MsgBox("Please, enter a hexadecimal value.", MsgBoxStyle.Critical, "Error")
            VRAM_startTextBox.Text = "0000"
            VRAM_startTextBox.Focus()
        End Try
    End Sub



    Private Sub VRAM_sizeTextBox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles VRAM_sizeTextBox.Validating
        Try

            Dim bloq_size As Integer = Integer.Parse(VRAM_sizeTextBox.Text, System.Globalization.NumberStyles.HexNumber)
            'Dim starADDR As Integer = Integer.Parse(VRAM_startTextBox.Text, System.Globalization.NumberStyles.HexNumber)

            If bloq_size > 16383 Then
                MsgBox("The value can not be higher than h3FFF (VRAM 16K).", MsgBoxStyle.Critical, "Error")
                VRAM_sizeTextBox.Text = "3FFF"
                VRAM_sizeTextBox.Focus()
            End If

            'If endADDR < starADDR Then
            '    MsgBox("The end value has to be higher than the initial value.", MsgBoxStyle.Critical, "Error")
            '    VRAM_endTextBox.Text = "3FFF"
            '    VRAM_endTextBox.Focus()
            'End If

        Catch ex As Exception
            MsgBox("Please, enter a hexadecimal value.", MsgBoxStyle.Critical, "Error")
            VRAM_sizeTextBox.Text = "3FFF"
            VRAM_sizeTextBox.Focus()
        End Try
    End Sub



    Private Sub Save_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save_Button.Click

        'If Me.FilePath = "" Then
        Me.SaveFileDialog1.FileName = Me.ProjectName
        Me.SaveFileDialog1.InitialDirectory = Me.AppConfig.PathItemBinary.Path
        'Else
        '    Me.SaveFileDialog1.FileName = Path.GetFileName(Me.FilePath)
        '    Me.SaveFileDialog1.InitialDirectory = Path.GetDirectoryName(Me.FilePath)
        'End If

        Me.SaveFileDialog1.DefaultExt = Me.FileExtension

        If Me.BasicHeadCheck.Checked Then
            Me.SaveFileDialog1.Filter = "MSX Basic Binary file|*.sc*|MSX Basic Screen 0|*.sc0|MSX Basic Screen 1|*.sc1|MSX Basic Screen 2|*.sc2|MSX Basic Screen 4|*.sc4|Binary file|*.bin"
        Else
            Me.SaveFileDialog1.Filter = "Binary file|*.bin"
        End If

        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.AppConfig.PathItemBinary.UpdateLastPath(Path.GetDirectoryName(SaveFileDialog1.FileName))
            Me.FilePath = SaveFileDialog1.FileName
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If

    End Sub



    Private Sub BasicHeadCheck_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BasicHeadCheck.CheckedChanged
        Me.FileExtension = getExtension()
        Me.ExtensionTextBox.Text = "." + Me.FileExtension
    End Sub



    Private Function getExtension() As String
        Dim tmpExtension As String = ""
        If Me.BasicHeadCheck.Checked Then
            Select Case Me.ScreenMode
                Case iVDP.SCREEN_MODE.T1
                    tmpExtension = "sc0"
                Case iVDP.SCREEN_MODE.G1
                    tmpExtension = "sc1"
                Case Else
                    If Me.VDPtype = iPaletteMSX.VDP.V9938 Then
                        tmpExtension = "sc4"
                    Else
                        tmpExtension = "sc2"
                    End If
            End Select
        Else
            tmpExtension = "bin"
        End If

        Return tmpExtension
    End Function

End Class
