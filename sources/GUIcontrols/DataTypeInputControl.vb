Public Class DataTypeInputControl

    Private AppConfig As Config

    'Private _sizesForColors As Boolean = False

    Private _enableAsmIndex As Boolean = False
    Private _enableCompress As Boolean = True
    Private _enableDataSizeLine As Boolean = False



    Public Event DataChanged()





    Public Shadows Enum Language_CODE As Integer
        ASSEMBLER
        BASIC
        C
    End Enum



    Public ReadOnly Property CodeLanguage As Language_CODE
        Get
            Return Me.LanguageComboBox.SelectedIndex
        End Get
    End Property



    Public ReadOnly Property NumeralSystem As Integer
        Get
            Return Me.NumSysCombo.SelectedIndex
        End Get
    End Property



    ''' <summary>
    ''' number of items to output data line: 8,16,24,32
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SizeLine As Integer
        Get
            If IsNumeric(Me.SizeLineComboBox.SelectedItem) Then
                Return CInt(Me.SizeLineComboBox.SelectedItem)
            Else
                Return -1 'line length
            End If
        End Get
    End Property



    Public ReadOnly Property SizeLineIndex As Integer
        Get
            Return Me.SizeLineComboBox.SelectedIndex
        End Get
    End Property



    Public ReadOnly Property Compress As Integer
        Get
            If _enableCompress = False Then
                Return 0
            Else
                Return Me.CompressComboBox.SelectedIndex
            End If
        End Get
    End Property



    'Public Property SizesForColors As Boolean
    '    Get
    '        Return Me._sizesForColors
    '    End Get
    '    Set(value As Boolean)
    '        Me._sizesForColors = value
    '    End Set
    'End Property



    Public Property EnableCompress As Boolean
        Get
            Return Me._enableCompress
        End Get
        Set(value As Boolean)
            Me._enableCompress = value
        End Set
    End Property



    Public Property EnableDataSizeLine As Boolean
        Get
            Return Me._enableDataSizeLine
        End Get
        Set(value As Boolean)
            Me._enableDataSizeLine = value
        End Set
    End Property



    ''' <summary>
    ''' Activa el checkbuttom en el menu de assembler para la generación de un indice de los datos
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property EnableAssemblerIndex As Boolean
        Set(value As Boolean)
            Me._enableAsmIndex = value
            showIndex()
        End Set
    End Property



    ''' <summary>
    ''' proporciona el estado del checkbuttom para indicar si se quiere que se genere un indice de la lista de datos en assembler
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ASMaddIndex As Boolean
        Get
            If Me.AddIndexCheck.Enabled = True Then
                Return Me.AddIndexCheck.Checked
            Else
                Return False
            End If

        End Get
    End Property



    Public ReadOnly Property AsmByteCommand As String
        Get
            Return Me.AsmByteDataTextBox.Text
        End Get
    End Property



    Public ReadOnly Property AsmWordDataCommand As String
        Get
            Return Me.AsmWordDataTextBox.Text
        End Get
    End Property



    Public ReadOnly Property BASIClineNumber As Integer
        Get
            Return GetValidateLineNum(Me.LineNumberText.Text)
        End Get
    End Property



    Public ReadOnly Property BASICInterval As Integer
        Get
            Return GetValidateInterval(Me.IntervalText.Text)
        End Get
    End Property



    Public ReadOnly Property BASICremoveZeros As Boolean
        Get
            Return Me.RemoveZerosCheck.Checked
        End Get
    End Property





    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub



    Private Sub DataTypeInputControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        ' posiciona la caja con campos especificos para la salida en assembler
        Me.AsmGroupBox.Location = Me.BasicGroupBox.Location
        Me.CGroupBox.Location = Me.BasicGroupBox.Location

        Me.LanguageComboBox.SelectedIndex = 0

        If _enableCompress = False Then
            CompressLabel.Enabled = False
            CompressComboBox.Enabled = False
        End If

    End Sub




    ''' <summary>
    ''' Se ha de ejecutar despues de proporcionar el Config, para que se inicialice el control con los datos adecuados.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InitControl(ByRef _config As Config)

        Me.AppConfig = _config

        'If Me._sizesForColors = True Then
        '    'pensado para los datos de una paleta
        '    Me.SizeLineComboBox.Items.Clear()
        '    Me.SizeLineComboBox.Items.Add("item")
        '    Me.SizeLineComboBox.Items.Add("line")
        '    Me.SizeLineComboBox.SelectedIndex = 0
        'Else
        If Me._enableDataSizeLine = True Then
            ' pensado para mapas que tienen un ancho especifico
            Me.SizeLineComboBox.Items.Add("line")
            Me.SizeLineComboBox.SelectedIndex = Me.SizeLineComboBox.Items.Count - 1
        Else
            Me.SizeLineComboBox.SelectedIndex = Me.AppConfig.defCodeLineSize

        End If
        'End If

        AddHandlers()

        RefreshControl()

    End Sub



    Public Sub RefreshControl()

        RemoveHandlers()

        Me.LanguageComboBox.SelectedIndex = Me.AppConfig.lastCodeOutput

        If _enableCompress = True Then
            Me.CompressComboBox.SelectedIndex = Me.AppConfig.lastCodeCompressType
        Else
            Me.CompressComboBox.SelectedIndex = 0
        End If

        Me.AsmByteDataTextBox.Text = Me.AppConfig.lastAsmByteCommand
        Me.AsmWordDataTextBox.Text = Me.AppConfig.lastAsmWordDataCommand

        Me.CdataTypeTextBox.Text = Me.AppConfig.lastCByteCommand

        Me.LineNumberText.Text = CStr(Me.AppConfig.lastBASIC_initLine)
        Me.IntervalText.Text = CStr(Me.AppConfig.lastBASIC_incLines)
        Me.RemoveZerosCheck.Checked = Me.AppConfig.lastBASIC_remove0

        showIndex()

        Me.AppConfig.lastCodeSizeLine = Me.SizeLineComboBox.SelectedIndex

        ShowLanguageStatus()

        AddHandlers()

    End Sub



    Private Sub AddHandlers()
        AddHandler Me.LanguageComboBox.SelectedIndexChanged, AddressOf LanguageComboBox_SelectedIndexChanged
        AddHandler Me.NumSysCombo.SelectedIndexChanged, AddressOf NumSysCombo_SelectedIndexChanged
        AddHandler Me.SizeLineComboBox.SelectedIndexChanged, AddressOf SizeLineComboBox_SelectedIndexChanged
        AddHandler Me.CompressComboBox.SelectedIndexChanged, AddressOf CompressComboBox_SelectedIndexChanged

        AddHandler Me.CdataTypeTextBox.TextChanged, AddressOf CdataTypeTextBox_TextChanged
        AddHandler Me.AsmByteDataTextBox.TextChanged, AddressOf AsmCommandTextBox_TextChanged
        AddHandler Me.AsmWordDataTextBox.TextChanged, AddressOf AsmWordDataTextBox_TextChanged

        AddHandler Me.RemoveZerosCheck.CheckedChanged, AddressOf RemoveZerosCheck_CheckedChanged
        AddHandler Me.AddIndexCheck.CheckedChanged, AddressOf AddIndexCheck_CheckedChanged

        AddHandler Me.LineNumberText.TextChanged, AddressOf Text_TextChanged
        AddHandler Me.IntervalText.TextChanged, AddressOf Text_TextChanged
        AddHandler Me.AsmByteDataTextBox.TextChanged, AddressOf Text_TextChanged
        AddHandler Me.AsmWordDataTextBox.TextChanged, AddressOf Text_TextChanged

        AddHandler Me.CdataTypeTextBox.TextChanged, AddressOf Text_TextChanged
    End Sub



    Private Sub RemoveHandlers()
        RemoveHandler Me.LanguageComboBox.SelectedIndexChanged, AddressOf LanguageComboBox_SelectedIndexChanged
        RemoveHandler Me.NumSysCombo.SelectedIndexChanged, AddressOf NumSysCombo_SelectedIndexChanged
        RemoveHandler Me.SizeLineComboBox.SelectedIndexChanged, AddressOf SizeLineComboBox_SelectedIndexChanged
        RemoveHandler Me.CompressComboBox.SelectedIndexChanged, AddressOf CompressComboBox_SelectedIndexChanged

        RemoveHandler Me.CdataTypeTextBox.TextChanged, AddressOf CdataTypeTextBox_TextChanged
        RemoveHandler Me.AsmByteDataTextBox.TextChanged, AddressOf AsmCommandTextBox_TextChanged
        RemoveHandler Me.AsmWordDataTextBox.TextChanged, AddressOf AsmWordDataTextBox_TextChanged

        RemoveHandler Me.RemoveZerosCheck.CheckedChanged, AddressOf RemoveZerosCheck_CheckedChanged
        RemoveHandler Me.AddIndexCheck.CheckedChanged, AddressOf AddIndexCheck_CheckedChanged

        RemoveHandler Me.LineNumberText.TextChanged, AddressOf Text_TextChanged
        RemoveHandler Me.IntervalText.TextChanged, AddressOf Text_TextChanged
        RemoveHandler Me.AsmByteDataTextBox.TextChanged, AddressOf Text_TextChanged
        RemoveHandler Me.AsmWordDataTextBox.TextChanged, AddressOf Text_TextChanged

        RemoveHandler Me.CdataTypeTextBox.TextChanged, AddressOf Text_TextChanged
    End Sub



    Private Sub showIndex()
        Try

            Me.AddIndexCheck.Visible = Me._enableAsmIndex
            WordDataLabel.Visible = Me._enableAsmIndex
            AsmWordDataTextBox.Visible = Me._enableAsmIndex

            If Me._enableAsmIndex = True Then
                ShowWordAsmCommand()
            End If

        Catch ex As Exception

        End Try
    End Sub



    Private Sub DataTypeInputControl_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Me.Size = New System.Drawing.Size(Me.Size.Width, 110)
    End Sub



    Private Sub LanguageComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) 'Handles LanguageComboBox.SelectedIndexChanged
        RemoveHandlers()
        Me.AppConfig.lastCodeOutput = Me.LanguageComboBox.SelectedIndex
        ShowLanguageStatus()
        AddHandlers()

        RaiseEvent DataChanged()
    End Sub



    Private Sub ShowLanguageStatus()

        Select Case Me.LanguageComboBox.SelectedIndex
            Case DataFormat.ProgrammingLanguage.BASIC  'basic
                Me.BasicGroupBox.Visible = True
                Me.AsmGroupBox.Visible = False
                Me.CGroupBox.Visible = False

                'Me.RemoveZerosCheck.Enabled = True
                Select Case Me.NumSysCombo.SelectedIndex
                    Case DataFormat.DataType.DECIMAL_n To DataFormat.DataType.DECIMAL_nnnd
                        Me.NumSysCombo.SelectedIndex = DataFormat.DataType.DECIMAL_n
                    Case DataFormat.DataType.BINARY_n To DataFormat.DataType.BINARY_BASIC
                        Me.NumSysCombo.SelectedIndex = DataFormat.DataType.BINARY_BASIC
                    Case Else
                        Me.NumSysCombo.SelectedIndex = DataFormat.DataType.HEXADECIMAL_BASIC
                End Select

            Case DataFormat.ProgrammingLanguage.C
                Me.BasicGroupBox.Visible = False
                Me.AsmGroupBox.Visible = False
                Me.CGroupBox.Visible = True

                Select Case Me.NumSysCombo.SelectedIndex
                    Case DataFormat.DataType.DECIMAL_n To DataFormat.DataType.DECIMAL_nnnd
                        Me.NumSysCombo.SelectedIndex = DataFormat.DataType.DECIMAL_n
                    Case DataFormat.DataType.BINARY_n To DataFormat.DataType.BINARY_BASIC
                        Me.NumSysCombo.SelectedIndex = DataFormat.DataType.BINARY_C
                    Case Else
                        Me.NumSysCombo.SelectedIndex = DataFormat.DataType.HEXADECIMAL_C
                End Select

            Case DataFormat.ProgrammingLanguage.ASSEMBLER
                Me.BasicGroupBox.Visible = False
                Me.AsmGroupBox.Visible = True
                Me.CGroupBox.Visible = False

                Select Case Me.NumSysCombo.SelectedIndex
                    Case DataFormat.DataType.DECIMAL_n To DataFormat.DataType.DECIMAL_nnnd
                        Me.NumSysCombo.SelectedIndex = DataFormat.DataType.DECIMAL_nnnd      '?? default
                    Case DataFormat.DataType.BINARY_n To DataFormat.DataType.BINARY_BASIC
                        Me.NumSysCombo.SelectedIndex = DataFormat.DataType.BINARY_nb         '?? default
                    Case Else
                        Me.NumSysCombo.SelectedIndex = DataFormat.DataType.HEXADECIMAL_Snn   '?? default
                End Select

        End Select

        If Me.NumSysCombo.SelectedIndex >= DataFormat.DataType.BINARY_n Then
            Me.SizeLineComboBox.SelectedIndex = 0
        Else
            Me.SizeLineComboBox.SelectedIndex = Me.AppConfig.lastCodeSizeLine
        End If

    End Sub



    Private Sub NumSysCombo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        Me.AppConfig.lastCodeNumberFormat = NumSysCombo.SelectedIndex
        RaiseEvent DataChanged()
    End Sub



    Private Sub SizeLineComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        Me.AppConfig.lastCodeSizeLine = SizeLineComboBox.SelectedIndex
        RaiseEvent DataChanged()
    End Sub



    Private Sub CompressComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        Me.AppConfig.lastCodeCompressType = CompressComboBox.SelectedIndex
        RaiseEvent DataChanged()
    End Sub



    Private Sub CdataTypeTextBox_TextChanged(sender As System.Object, e As System.EventArgs) 'Handles CdataTypeTextBox.TextChanged
        Me.AppConfig.lastCByteCommand = Me.CdataTypeTextBox.Text
    End Sub



    Private Sub AsmCommandTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.AppConfig.lastAsmByteCommand = Me.AsmByteDataTextBox.Text
        RaiseEvent DataChanged()
    End Sub



    Private Sub AsmWordDataTextBox_TextChanged(sender As System.Object, e As System.EventArgs)
        Me.AppConfig.lastAsmWordDataCommand = Me.AsmWordDataTextBox.Text
        RaiseEvent DataChanged()
    End Sub



    Private Sub RemoveZerosCheck_CheckedChanged(sender As System.Object, e As System.EventArgs) ' Handles RemoveZerosCheck.CheckedChanged
        RaiseEvent DataChanged()
    End Sub



    Private Sub Text_TextChanged(sender As Object, e As EventArgs)
        RaiseEvent DataChanged()
    End Sub



    Private Sub AddIndexCheck_CheckedChanged(sender As System.Object, e As System.EventArgs) 'Handles AddIndexCheck.CheckedChanged
        ShowWordAsmCommand()
    End Sub



    Private Sub ShowWordAsmCommand()
        WordDataLabel.Enabled = AddIndexCheck.Checked
        AsmWordDataTextBox.Enabled = AddIndexCheck.Checked
    End Sub



    Private Sub LineNumberText_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles LineNumberText.Validating
        Me.LineNumberText.Text = CStr(GetValidateLineNum(Me.LineNumberText.Text))
    End Sub



    Private Sub IntervalText_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles IntervalText.Validating
        Me.IntervalText.Text = GetValidateInterval(Me.IntervalText.Text)
    End Sub



    ''' <summary>
    ''' validates the value of the initial line number
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetValidateLineNum(ByVal value As String) As Integer
        Dim aNumber As Integer
        If IsNumeric(value) Then
            aNumber = CInt(value)
            If aNumber < 1 Or aNumber > 60000 Then
                aNumber = 10000
            End If
        Else
            aNumber = 10000
        End If

        Return aNumber
    End Function



    Private Function GetValidateInterval(ByVal value As String) As Integer
        Dim aNumber As Integer
        If IsNumeric(value) Then
            aNumber = CInt(value)
            If aNumber < 1 Or aNumber > 100 Then
                aNumber = 10
            End If
        Else
            aNumber = 10
        End If
        Return aNumber
    End Function



    Public Function GetInfoName(name As String) As String

        Select Case Me.CompressComboBox.SelectedIndex

            Case 1
                name += "_RLE"

            Case 2
                name += "_RLEWB"

                'Case 3


            Case Else


        End Select

        Return name
    End Function



End Class
