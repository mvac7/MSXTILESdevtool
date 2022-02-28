Imports System.IO
Imports System.Xml
Imports System.Collections

Imports System.Drawing
Imports System.Drawing.Imaging



Public Class MainScreen

    'Private App_name As String = "MSX tiles Tools"
    'Private App_version As String = "0.9.5.2b (21/8/2013)"
    'last: 0.9.5.1b (11/3/2012) , 0.9.5b (23/2/2012)


    Private AppConfig As Config

    Private Info As ProjectInfo

    'Private _AppID As String = "tmsFXinator"

    Public Shadows Const Extension_Project As String = "SXSCR"

    ' --------------------------------------------------------- OLD
    Private Const ScreenDocumentExtension As String = "xscp"
    Private Const TilesetDocumentExtension As String = "xtil"
    Private Const MapDocumentExtension As String = "xmap"
    ' --------------------------------------------------------- OLD

    Private Const Extension_Binary = "bin"
    Private Const Extension_Assembler = "asm"



    Private Const default_TITLE As String = "New Project"

    Private screenTilesData As Byte()

    Private Path_Project As String
    Private Filename_Project As String

    Private MapName As String
    Private TilesetsName As String

    Private outputCompressData As ArrayList
    Private outputCompressData_Type As DATA_TYPE
    Private outputCompressData_CompressType As iCompressEncoder.COMPRESS_TYPE
    Private outputCompressData_suffix As String

    Private aMSXDataFormat As DataFormat
    'Private genData As New DataFormat

    Private Progress As ProgressController

    Private PaletteDialog As Palette512Dialog

    Private myBitmapImage As Bitmap


    Private Enum DATA_TYPE As Integer
        SCREEN
        MAP
        TILESET
        SPRITESET
        OAM
    End Enum


    Private Enum TILESET_TYPE As Integer
        PATTERN
        COLOR
    End Enum



    Private tilesetBANK_Labels = New String() {"All BANKs", "BANK A", "BANK B", "BANK C"}
    Private tileset_pattern_BANK_Suffix = New String() {"", "_B0", "_B1", "_B2"}
    Private tileset_color_BANK_Suffix = New String() {"", "_B0", "_B1", "_B2"}

    Private DataType_Suffix = New String() {"_SCR", "_MAP", "_TSET", "_SPR", "_OAM"}
    Private Compress_Suffix = New String() {"_RAW", "_RLE", "_RLEWB", "_PLT5"}

    Private bite_MASKs = New Byte() {1, 2, 4, 8, 16, 32, 64, 128}




    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.Info = New ProjectInfo

        Me.AppConfig = New Config()

        Me.outputCompressData = New ArrayList

        Me.aMSXDataFormat = New DataFormat

    End Sub



    Private Sub MainScreen_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Dim result As System.Windows.Forms.DialogResult

        Application.DoEvents()

        Beep()

        result = MessageBox.Show(Me, "Are you sure you want to close " + My.Application.Info.Title + "?", "Closing Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        'result = MsgBox("Are you sure you want to close spriteSX?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Alert")

        If result = Windows.Forms.DialogResult.No Then
            e.Cancel = True 'cancela la salida de la aplicacion
        Else
            Me.AppConfig.Save()
        End If

    End Sub



    Private Sub MainScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Progress = New ProgressController(Me)

        If Me.AppConfig.Load() Then
            'lastProjects = Me.AppConfig.GetRecentProjectList(My.Application.Info.AssemblyName)
            'If Not lastProjects Is Nothing Then
            '    Me.InitLauncher1.SetData(lastProjects) 'AppConfig.RecentProjects)
            'End If
        Else
            ' if not exist config file
            ShowAbout(True)
        End If

        NewProject()

        DataTypeInput.AppConfig = Me.AppConfig
        DataTypeInput.InitControl()

        TilesetComboBox.SelectedIndex = 0
        DataComboBox.SelectedIndex = 0

    End Sub



    Private Sub SetTitle(filename As String)
        If Not filename = "" Then
            filename = " · [" + filename + "]"
        End If

        Me.Text = My.Application.Info.Title + " " + filename  '" v" + My.Application.Info.Version.ToString + "b "
    End Sub



    Private Sub NewProject()

        Dim newData As New DataFormat

        Dim dragNdropPicture() As Byte

        dragNdropPicture = DataDecompress(newData.ByteSpliterHex("ED573D6E833014063178AB2F50E18B20B852C70C089C29D742EA452C75E8584719EA4A08F73D636870690B081252F22D0EC636EFFBDE9FE37977DCD105A194E2A801E7F3CDF3DAE68594720CBFDF402DE63A6F69488B6BDBF15FB075FF6F9DFFD6B175FF2FC93F77FAD81C23726F9E2BA73FAE097D7EF2096538B676F3424C3D7F2EBF2DE57F977F92A54AC1F3C1B7EF954AD3288AA69E7F6BFC916F9630F31DFFA07594A21EA2F861BB5129CADAF8E6EE82B5D72D973FB17ED7553DF2FE6D7E00399264A5D2AFCF7B9C2884542508675EFA81A649AE4B29C41BE4506EF5C4449A6AE7A5FC8F086CFE23276779CB1B428277ED63490EA182358F5112148551A424412DA89567B20E17E0DFE1668CAD8D87EA273FBEF3C6E5A013368F973D9EA34A2898367C78A99E3ADF994B87B901761F4FEF5AF7F914D104EFF9BB00A4606118EAB3FE901BB9306644CF295F001D8C1002FE1C2AB54B87DAB994FF7555AA31F794BC6E0FAA098EDAEB793CF6BB6914C761C8D8D0F5409D187B67FECF3EF69EE6E4857A1CBAD1C15AFA0296673B8EBAE3A1D7A1C4E36FDE5327FF0483048AE36870FCAF0DFA74347163A23F610F30C5391FB617FA2349779847422C68E2A29075F91AE73F3FA0FDDDF3F610DB7A0F151F7BBEA9634E8E10182ACF6730282FD1701DE2B09A5FCDE49BC227"))

        Me.TMS9918Aviewer.Clear()
        Me.TMS9918Aviewer.ScreenMode = iVDP.SCREEN_MODE.G2
        Me.TMS9918Aviewer.SetOrderMap()
        Me.TMS9918Aviewer.BackgroundColor = 4
        Me.TMS9918Aviewer.FillVRAM(iVDP.TableBase.GRPCOL, &H1800, &HF4)
        Me.TMS9918Aviewer.SetBlock(iVDP.TableBase.GRPCGP, dragNdropPicture)
        Me.TMS9918Aviewer.RefreshScreen()

        Info.Clear()
        Info.Name = default_TITLE

        SetTitle(Me.Info.Name)

        SetGUImode(0)

    End Sub



    Private Function DataDecompress(bytes As Byte()) As Byte()
        Dim stream = New MemoryStream()
        Dim zipStream = New Compression.DeflateStream(New MemoryStream(bytes), Compression.CompressionMode.Decompress, True)
        Dim buffer = New Byte(4095) {}
        While True
            Dim size = zipStream.Read(buffer, 0, buffer.Length)
            If size > 0 Then
                stream.Write(buffer, 0, size)
            Else
                Exit While
            End If
        End While
        zipStream.Close()
        Return stream.ToArray()
    End Function



    'Public Function LoadConfig() As Boolean
    '    Try

    '        Dim aXmlDoc As New XmlDocument

    '        Dim aNode As XmlNode
    '        'Dim aNodeList As XmlNodeList
    '        'Dim aValue As String
    '        'Dim tmpList As New SortedList
    '        'Dim itemIndex As Integer

    '        Dim ConfigFileAdress As String = System.AppDomain.CurrentDomain.BaseDirectory + Me.ConfigFileName


    '        If System.IO.File.Exists(ConfigFileAdress) Then

    '            aXmlDoc.Load(ConfigFileAdress)

    '            '
    '            aNode = aXmlDoc.SelectSingleNode("config/Path_Project")
    '            If Not aNode Is Nothing Then
    '                '    Me.Path_Project = System.AppDomain.CurrentDomain.BaseDirectory
    '                'ElseIf aNode.InnerText = "" Then
    '                '    Me.Path_Project = System.AppDomain.CurrentDomain.BaseDirectory
    '                'Else
    '                Me.Path_Project = aNode.InnerText
    '            End If

    '            aNode = aXmlDoc.SelectSingleNode("config/Path_SC2")
    '            If Not aNode Is Nothing Then
    '                Me.Path_SC2 = aNode.InnerText
    '            End If

    '            aNode = aXmlDoc.SelectSingleNode("config/Path_Bitmap")
    '            If Not aNode Is Nothing Then
    '                Me.Path_Bitmap = aNode.InnerText
    '            End If

    '            aNode = aXmlDoc.SelectSingleNode("config/Path_nMSXtilesProject")
    '            If Not aNode Is Nothing Then
    '                Me.Path_nMSXtilesProject = aNode.InnerText
    '            End If

    '            aNode = aXmlDoc.SelectSingleNode("config/Path_Palettes")
    '            If Not aNode Is Nothing Then
    '                'Me.Path_Palettes = aNode.InnerText
    '                'PaletteDialog.PaletteDefaultPath = aNode.InnerText
    '            End If

    '            ''PaletteDefaultPath
    '            'aNode = aXmlDoc.SelectSingleNode("config/PaletteDefaultPath")
    '            ''aValue = aNode.InnerText
    '            'If aNode Is Nothing Then
    '            '    Me.paletteDialog.PaletteDefaultPath = System.AppDomain.CurrentDomain.BaseDirectory
    '            'ElseIf aNode.InnerText = "" Then
    '            '    Me.paletteDialog.PaletteDefaultPath = System.AppDomain.CurrentDomain.BaseDirectory
    '            'Else
    '            '    Me.paletteDialog.PaletteDefaultPath = aNode.InnerText
    '            'End If


    '            'aNodeList = aXmlDoc.SelectNodes("config/RecentProjects/item")
    '            'If aNodeList Is Nothing Then
    '            '    Me.RecentProjects = New RecentProjectsList

    '            'Else

    '            '    For Each aNodeItem As XmlNode In aNodeList

    '            '        itemIndex = CInt(aNodeItem.Attributes.GetNamedItem("index").InnerText)
    '            '        aValue = aNodeItem.Attributes.GetNamedItem("path").InnerText

    '            '        tmpList.Add(itemIndex, aValue)

    '            '    Next

    '            '    Me.RecentProjects = New RecentProjectsList(tmpList)

    '            'End If


    '            Return True

    '        Else
    '            'Me.ProjectDefaultPath = System.AppDomain.CurrentDomain.BaseDirectory
    '            'Me.paletteDialog.PaletteDefaultPath = System.AppDomain.CurrentDomain.BaseDirectory
    '            'Me.RecentProjects = New RecentProjectsList
    '            Return False
    '        End If



    '    Catch ex As Exception
    '        ' error! No se ha podido cargar la configuración
    '        Return False
    '    End Try

    'End Function



    'Private Sub SaveConfig()
    '    Try

    '        Dim aXmlDoc As New XmlDocument
    '        Dim ConfigFileAdress As String = System.AppDomain.CurrentDomain.BaseDirectory + Me.ConfigFileName
    '        Dim rootElement As XmlElement
    '        Dim txtElement As XmlText
    '        Dim anElement As XmlElement
    '        Dim anAttribute As XmlAttribute
    '        'Dim anItemElement As XmlElement

    '        ' crea el nodo root
    '        rootElement = aXmlDoc.CreateElement("config")
    '        aXmlDoc.AppendChild(rootElement)

    '        anAttribute = aXmlDoc.CreateAttribute("app")
    '        anAttribute.Value = My.Application.Info.ProductName
    '        rootElement.SetAttributeNode(anAttribute)

    '        anAttribute = aXmlDoc.CreateAttribute("version")
    '        anAttribute.Value = My.Application.Info.Version.ToString
    '        rootElement.SetAttributeNode(anAttribute)

    '        'debug data
    '        'anAttribute = aXmlDoc.CreateAttribute("dotnetvers")
    '        'anAttribute.Value = Environment.Version.ToString()
    '        'rootElement.SetAttributeNode(anAttribute)


    '        anElement = aXmlDoc.CreateElement("Path_Project")
    '        txtElement = aXmlDoc.CreateTextNode(Me.Path_Project)
    '        anElement.AppendChild(txtElement)
    '        rootElement.AppendChild(anElement)

    '        anElement = aXmlDoc.CreateElement("Path_SC2")
    '        txtElement = aXmlDoc.CreateTextNode(Me.Path_SC2)
    '        anElement.AppendChild(txtElement)
    '        rootElement.AppendChild(anElement)

    '        anElement = aXmlDoc.CreateElement("Path_Bitmap")
    '        txtElement = aXmlDoc.CreateTextNode(Me.Path_Bitmap)
    '        anElement.AppendChild(txtElement)
    '        rootElement.AppendChild(anElement)

    '        anElement = aXmlDoc.CreateElement("Path_nMSXtilesProject")
    '        txtElement = aXmlDoc.CreateTextNode(Me.Path_nMSXtilesProject)
    '        anElement.AppendChild(txtElement)
    '        rootElement.AppendChild(anElement)

    '        'anElement = aXmlDoc.CreateElement("Path_Palettes")
    '        'txtElement = aXmlDoc.CreateTextNode(Me.PaletteDialog.PaletteDefaultPath)
    '        'anElement.AppendChild(txtElement)
    '        'rootElement.AppendChild(anElement)

    '        'anElement = aXmlDoc.CreateElement("PaletteDefaultPath")
    '        'txtElement = aXmlDoc.CreateTextNode(Me.paletteDialog.PaletteDefaultPath)
    '        'anElement.AppendChild(txtElement)
    '        'rootElement.AppendChild(anElement)

    '        'anElement = aXmlDoc.CreateElement("RecentProjects")
    '        'rootElement.AppendChild(anElement)
    '        'For i As Integer = 0 To RecentProjects.Count - 1
    '        '    anItemElement = aXmlDoc.CreateElement("item")
    '        '    anElement.AppendChild(anItemElement)

    '        '    anAttribute = aXmlDoc.CreateAttribute("index")
    '        '    anAttribute.Value = CStr(i)
    '        '    anItemElement.SetAttributeNode(anAttribute)

    '        '    anAttribute = aXmlDoc.CreateAttribute("path")
    '        '    anAttribute.Value = Me.RecentProjects.GetFileItem(i).Path
    '        '    anItemElement.SetAttributeNode(anAttribute)
    '        'Next

    '        '
    '        aXmlDoc.Save(ConfigFileAdress)


    '        'Me.StatusBarLabel.Text = ApplicationInfo.GetLiteral("mssge.configsaved", "Settings saved")

    '    Catch ex As Exception
    '        ' error! No se ha podido guardar la configuración
    '    End Try
    'End Sub



    ''' <summary>
    ''' Load Project data
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <remarks></remarks>
    Private Function LoadData(ByVal filePath As String) As Boolean

        Dim result As Boolean = True

        Try

            Dim aXmlDoc As New XmlDocument
            'Dim rootElement As XmlElement

            Dim aNodeList As XmlNodeList

            Dim aDataNode As XmlNode
            Dim aNode As XmlNode

            'Dim gfxData As String = ""
            'Dim colorData As String = ""

            aXmlDoc.Load(filePath)

            'showProgressWin()

            ' project data ##############################################
            aDataNode = aXmlDoc.SelectSingleNode("msxdevtools/project")

            'aNode = aDataNode.SelectSingleNode("@name")
            'If aNode Is Nothing Then
            '    Me.Info.Name = Path.GetFileNameWithoutExtension(filePath)
            'Else
            '    Me.Info.Name = aNode.InnerText
            'End If

            'aNode = aDataNode.SelectSingleNode("@version")
            'If aNode Is Nothing Then
            '    Me.ProjectVersion = "0"
            'Else
            '    Me.ProjectVersion = aNode.InnerText
            'End If

            'aNode = aDataNode.SelectSingleNode("@group")
            'If aNode Is Nothing Then
            '    Me.ProjectGroup = ""
            'Else
            '    Me.ProjectGroup = aNode.InnerText
            'End If

            'aNode = aDataNode.SelectSingleNode("@author")
            'If aNode Is Nothing Then
            '    Me.ProjectAuthor = ""
            'Else
            '    Me.ProjectAuthor = aNode.InnerText
            'End If

            'aNode = aDataNode.SelectSingleNode("@startDate")
            'If aNode Is Nothing Then
            '    Me.ProjectStartDate = DateTime.Today.Ticks
            'Else
            '    Me.ProjectStartDate = CLng(aNode.InnerText)
            'End If

            'aNode = aDataNode.SelectSingleNode("@lastUpdate")
            'If aNode Is Nothing Then
            '    Me.ProjectLastUpdate = DateTime.Today.Ticks
            'Else
            '    Me.ProjectLastUpdate = CLng(aNode.InnerText)
            'End If

            'aNode = aDataNode.SelectSingleNode("description")
            'If aNode Is Nothing Then
            '    Me.ProjectDescription = ""
            'Else
            '    Me.ProjectDescription = aNode.InnerText
            'End If
            'END project data ##############################################




            ' comprueba que el fichero de datos es para este programa, buscando el nombre del nodo principal
            ' MEJORABLE! :P
            If aXmlDoc.GetElementsByTagName("msxdevtools").Count > 0 Then

                ' Paleta de colores ##############################################3
                aDataNode = aXmlDoc.SelectSingleNode("msxdevtools/palette") ' comprueba si contiene datos de la paleta
                'If Not aDataNode Is Nothing Then
                '    Me.PaletteDialog.SetPaletteFromNode(aDataNode)
                'Else
                '    Me.PaletteDialog.setDefaultPalette()
                'End If
                ' END paleta de colores ##############################################


                '
                aDataNode = aXmlDoc.SelectSingleNode("msxdevtools/gfx")
                If Not aDataNode Is Nothing Then

                    aNode = aDataNode.SelectSingleNode("@name")
                    If aNode Is Nothing Then
                        Me.TilesetsName = Me.Info.Name
                    Else
                        Me.TilesetsName = aNode.InnerText
                    End If

                    aNodeList = aDataNode.SelectNodes("tileset")
                    If Not aNodeList Is Nothing Then
                        For Each anItemElement As XmlElement In aNodeList
                            setTileSetFromElement(anItemElement)
                        Next
                    End If
                End If
                '


                '
                aDataNode = aXmlDoc.SelectSingleNode("msxdevtools/maps/map[@id='0']") 'selecciona el que tiene id=0
                If Not aDataNode Is Nothing Then
                    aNode = aDataNode.SelectSingleNode("@name")
                    If aNode Is Nothing Then
                        Me.MapName = Me.Info.Name
                    Else
                        Me.MapName = aNode.InnerText
                    End If

                    result = setMapFromElement(aDataNode)
                End If
                '



                'closeProgressWin()
                'screen2.RefreshScreen()

                Application.DoEvents()


            End If

        Catch ex As Exception
            result = False
        End Try

        If result Then
            'LoadScrText.Text = Me.MapName + ".scr"
            'LoadTilText.Text = Me.TilesetsName + ".til"
        Else
            MsgBox("Disk I/O error.", MsgBoxStyle.Critical, "Error")
        End If

        Return result

    End Function



    Private Sub LoadTileset(ByVal filePath As String)

        Dim result As Boolean = True

        Try

            Dim aXmlDoc As New XmlDocument
            'Dim rootElement As XmlElement

            Dim aNodeList As XmlNodeList

            Dim aDataNode As XmlNode
            Dim aNode As XmlNode

            'Dim gfxData As String = ""
            'Dim colorData As String = ""

            aXmlDoc.Load(filePath)

            'showProgressWin()


            ' comprueba que el fichero de datos es para este programa, buscando el nombre del nodo principal
            ' MEJORABLE! :P
            If aXmlDoc.GetElementsByTagName("msxdevtools").Count > 0 Then

                '
                aDataNode = aXmlDoc.SelectSingleNode("msxdevtools/gfx")
                If Not aDataNode Is Nothing Then

                    aNode = aDataNode.SelectSingleNode("@name")
                    If aNode Is Nothing Then
                        Me.TilesetsName = Me.Info.Name
                    Else
                        Me.TilesetsName = aNode.InnerText
                    End If

                    aNodeList = aDataNode.SelectNodes("tileset")
                    If Not aNodeList Is Nothing Then
                        For Each anItemElement As XmlElement In aNodeList
                            setTileSetFromElement(anItemElement)
                        Next
                    End If
                End If
                '


                'closeProgressWin()
                'screen2.RefreshScreen()

                Application.DoEvents()


            End If

        Catch ex As Exception
            result = False
        End Try

        If result Then
            'LoadScrText.Text = Me.MapName + ".scr"
            'LoadTilText.Text = Me.TilesetsName + ".til"
        Else
            MsgBox("Disk I/O error.", MsgBoxStyle.Critical, "Error")
        End If

    End Sub


    Private Sub LoadMap(ByVal filePath As String)

        Dim result As Boolean = True

        Try

            Dim aXmlDoc As New XmlDocument
            'Dim rootElement As XmlElement

            'Dim aNodeList As XmlNodeList

            Dim aDataNode As XmlNode
            Dim aNode As XmlNode

            'Dim gfxData As String = ""
            'Dim colorData As String = ""

            aXmlDoc.Load(filePath)

            'showProgressWin()


            ' comprueba que el fichero de datos es para este programa, buscando el nombre del nodo principal
            ' MEJORABLE! :P
            If aXmlDoc.GetElementsByTagName("msxdevtools").Count > 0 Then


                '
                aDataNode = aXmlDoc.SelectSingleNode("msxdevtools/maps/map[@id='0']") 'selecciona el que tiene id=0
                If Not aDataNode Is Nothing Then
                    aNode = aDataNode.SelectSingleNode("@name")
                    If aNode Is Nothing Then
                        Me.MapName = Me.Info.Name
                    Else
                        Me.MapName = aNode.InnerText
                    End If

                    result = setMapFromElement(aDataNode)
                End If
                '



                'closeProgressWin()
                'screen2.RefreshScreen()

                Application.DoEvents()


            End If

        Catch ex As Exception
            result = False
        End Try

        If result Then
            'LoadScrText.Text = Me.MapName + ".scr"
        Else
            MsgBox("Disk I/O error.", MsgBoxStyle.Critical, "Error")
        End If

    End Sub


    Private Function setTileSetFromElement(ByVal anElement As XmlElement) As Boolean

        Dim aNodeList As XmlNodeList
        Dim subNode As XmlNode
        Dim anAttribute As XmlAttribute
        Dim tmpString As String
        Dim tilebank As Integer
        Dim tile As Integer
        Dim vaddr As Integer
        Dim aData(8) As Byte

        Try
            '<tileset id="0">
            anAttribute = anElement.GetAttributeNode("id")
            tmpString = anAttribute.InnerText
            If IsNumeric(tmpString) Then
                tilebank = CInt(tmpString)
                If tilebank > 2 Then
                    Return False
                End If
            Else
                Return False
                'Exit Sub 
            End If

            '<item id="0">
            '  <gfxData>0,0,0,0,0,0,0,0,0</gfxData>
            '  <colorData>17,17,17,17,17,17,17,17,0</colorData>
            '</item>
            aNodeList = anElement.SelectNodes("item")
            For Each anItemElement As XmlElement In aNodeList
                anAttribute = anItemElement.GetAttributeNode("id")
                tile = CInt(anAttribute.InnerText)
                'If tile < 256 Then
                '    subNode = anItemElement.SelectSingleNode("gfxData")
                '    tmpString = subNode.InnerText
                '    vaddr = (tilebank * 2048) + (tile * 8) + TMS9918.TableBase.GRPCGP
                '    aData = ByteSpliter(tmpString, 8, 0, 0)
                '    Me.screen2.VPOKE_block(vaddr, aData)

                '    subNode = anItemElement.SelectSingleNode("colorData")
                '    tmpString = subNode.InnerText
                '    vaddr = (tilebank * 2048) + (tile * 8) + TMS9918.TableBase.GRPCOL
                '    aData = ByteSpliter(tmpString, 8, 0, 0)
                '    Me.screen2.VPOKE_block(vaddr, aData)
                'End If
            Next

            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function



    Private Function setMapFromElement(ByVal anElement As XmlElement) As Boolean

        Dim aNodeList As XmlNodeList
        Dim anAttribute As XmlAttribute

        Dim tmpString As String
        Dim line As Integer
        Dim vaddr As Integer
        Dim aData(32) As Byte

        '<map id="0">
        Try

            '<line id="0">0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,0</line>

            aNodeList = anElement.SelectNodes("line")
            For Each anItemElement As XmlElement In aNodeList
                anAttribute = anItemElement.GetAttributeNode("id")
                line = CInt(anAttribute.InnerText)
                If line < 24 Then
                    'tmpString = anItemElement.InnerText
                    'vaddr = (line * 32) + TMS9918.TableBase.GRPNAM
                    'aData = ByteSpliter(tmpString, 32, 0, 0)
                    'Me.screen2.VPOKE_block(vaddr, aData)
                End If
            Next


            Return True

        Catch ex As Exception
            Return False
        End Try

    End Function



    ''' <summary>
    ''' Guarda en un fichero todos los datos del proyecto (lista de sprites + paleta de colores).
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <remarks></remarks>
    Private Sub SaveData(ByVal filePath As String)
        'Try

        Dim aXmlDoc As New XmlDocument
        Dim rootElement As XmlElement
        Dim txtElement As XmlText
        Dim anElement As XmlElement
        Dim anItemElement As XmlElement
        Dim anAttribute As XmlAttribute

        Dim tilebank As Integer
        Dim tile As Integer
        Dim line As Integer


        'showProgressWin()

        'AddRecentProject(filePath) ' lo añade a la lista de proyectos recientes


        ' crea el nodo root
        rootElement = aXmlDoc.CreateElement("msxdevtools")
        aXmlDoc.AppendChild(rootElement)

        anAttribute = aXmlDoc.CreateAttribute("app")
        anAttribute.Value = My.Application.Info.ProductName
        rootElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("version")
        anAttribute.Value = My.Application.Info.Version.ToString
        rootElement.SetAttributeNode(anAttribute)


        ' project data ##############################################
        'anElement = aXmlDoc.CreateElement("project")
        'rootElement.AppendChild(anElement)

        'anAttribute = aXmlDoc.CreateAttribute("name")
        'anAttribute.Value = Me.Info.Name
        'anElement.SetAttributeNode(anAttribute)

        'anAttribute = aXmlDoc.CreateAttribute("version")
        'anAttribute.Value = Me.ProjectVersion
        'anElement.SetAttributeNode(anAttribute)

        'anAttribute = aXmlDoc.CreateAttribute("group")
        'anAttribute.Value = Me.ProjectGroup
        'anElement.SetAttributeNode(anAttribute)

        'anAttribute = aXmlDoc.CreateAttribute("author")
        'anAttribute.Value = Me.ProjectAuthor
        'anElement.SetAttributeNode(anAttribute)

        'anAttribute = aXmlDoc.CreateAttribute("startDate")
        'anAttribute.Value = CStr(Me.ProjectStartDate)
        'anElement.SetAttributeNode(anAttribute)

        'Me.ProjectLastUpdate = DateTime.Today.Ticks
        'anAttribute = aXmlDoc.CreateAttribute("lastUpdate")
        'anAttribute.Value = CStr(Me.ProjectLastUpdate)
        'anElement.SetAttributeNode(anAttribute)

        'anItemElement = aXmlDoc.CreateElement("description")
        'txtElement = aXmlDoc.CreateTextNode(Me.ProjectDescription)
        'anItemElement.AppendChild(txtElement)
        'anElement.AppendChild(anItemElement)
        'END project data ##############################################


        ' palette data ##############################################
        'rootElement.AppendChild(Me.PaletteDialog.getPaletteElement(aXmlDoc))
        ' END palette data ##############################################


        ' gfx data (tilesets) ##############################################
        anElement = aXmlDoc.CreateElement("gfx")
        rootElement.AppendChild(anElement)

        anAttribute = aXmlDoc.CreateAttribute("name")
        anAttribute.Value = Me.TilesetsName
        anElement.SetAttributeNode(anAttribute)

        For tilebank = 0 To 2
            anItemElement = aXmlDoc.CreateElement("tileset")
            anElement.AppendChild(anItemElement)

            anAttribute = aXmlDoc.CreateAttribute("id")
            anAttribute.Value = CStr(tilebank)
            anItemElement.SetAttributeNode(anAttribute)

            'anAttribute = aXmlDoc.CreateAttribute("name")
            'anAttribute.Value = ""
            'anItemElement.SetAttributeNode(anAttribute)

            For tile = 0 To 255
                anItemElement.AppendChild(getTileElement(aXmlDoc, tilebank, tile))
            Next

        Next
        ' end gfx data ##############################################


        ' map data ##############################################
        anElement = aXmlDoc.CreateElement("maps")
        rootElement.AppendChild(anElement)

        'For tilebank = 0 To 3
        anItemElement = aXmlDoc.CreateElement("map")
        anElement.AppendChild(anItemElement)

        anAttribute = aXmlDoc.CreateAttribute("id")
        anAttribute.Value = "0"
        'anAttribute.Value = CStr(tilebank)
        anItemElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("name")
        anAttribute.Value = Me.MapName
        anItemElement.SetAttributeNode(anAttribute)

        For line = 0 To 23
            anItemElement.AppendChild(getLineElement(aXmlDoc, line))
        Next

        'Next
        ' END map data ##############################################

        ' save file
        aXmlDoc.Save(filePath)

        'closeProgressWin()
        Application.DoEvents()

    End Sub



    Private Sub SaveTilesets(ByVal filePath As String)
        'Try

        Dim aXmlDoc As New XmlDocument
        Dim rootElement As XmlElement
        'Dim txtElement As XmlText
        Dim anElement As XmlElement
        Dim anItemElement As XmlElement
        Dim anAttribute As XmlAttribute

        Dim tilebank As Integer
        Dim tile As Integer
        'Dim line As Integer


        'showProgressWin()

        'AddRecentProject(filePath) ' lo añade a la lista de proyectos recientes


        ' crea el nodo root
        rootElement = aXmlDoc.CreateElement("msxdevtools")
        aXmlDoc.AppendChild(rootElement)

        anAttribute = aXmlDoc.CreateAttribute("app")
        anAttribute.Value = My.Application.Info.ProductName
        rootElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("version")
        anAttribute.Value = My.Application.Info.Version.ToString
        rootElement.SetAttributeNode(anAttribute)


        ' gfx data (tilesets) ##############################################
        anElement = aXmlDoc.CreateElement("gfx")
        rootElement.AppendChild(anElement)

        anAttribute = aXmlDoc.CreateAttribute("name")
        anAttribute.Value = Me.TilesetsName
        anElement.SetAttributeNode(anAttribute)

        'anAttribute = aXmlDoc.CreateAttribute("author")
        'anAttribute.Value = Me.ProjectAuthor
        'anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("lastUpdate")
        anAttribute.Value = CStr(DateTime.Today.Ticks)
        anElement.SetAttributeNode(anAttribute)

        For tilebank = 0 To 2
            anItemElement = aXmlDoc.CreateElement("tileset")
            anElement.AppendChild(anItemElement)

            anAttribute = aXmlDoc.CreateAttribute("id")
            anAttribute.Value = CStr(tilebank)
            anItemElement.SetAttributeNode(anAttribute)

            'anAttribute = aXmlDoc.CreateAttribute("name")
            'anAttribute.Value = ""
            'anItemElement.SetAttributeNode(anAttribute)

            For tile = 0 To 255
                anItemElement.AppendChild(getTileElement(aXmlDoc, tilebank, tile))
            Next

        Next
        ' end gfx data ##############################################


        ' save file
        aXmlDoc.Save(filePath)

        'closeProgressWin()
        Application.DoEvents()

    End Sub



    Private Sub SaveMap(ByVal filePath As String)
        'Try

        Dim aXmlDoc As New XmlDocument
        Dim rootElement As XmlElement
        'Dim txtElement As XmlText
        Dim anElement As XmlElement
        Dim anItemElement As XmlElement
        Dim anAttribute As XmlAttribute

        Dim line As Integer


        'showProgressWin()

        'AddRecentProject(filePath) ' lo añade a la lista de proyectos recientes


        ' crea el nodo root
        rootElement = aXmlDoc.CreateElement("msxdevtools")
        aXmlDoc.AppendChild(rootElement)

        anAttribute = aXmlDoc.CreateAttribute("app")
        anAttribute.Value = My.Application.Info.ProductName
        rootElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("version")
        anAttribute.Value = My.Application.Info.Version.ToString
        rootElement.SetAttributeNode(anAttribute)


        ' map data ##############################################
        anElement = aXmlDoc.CreateElement("maps")
        rootElement.AppendChild(anElement)

        'For tilebank = 0 To 3
        anItemElement = aXmlDoc.CreateElement("map")
        anElement.AppendChild(anItemElement)

        anAttribute = aXmlDoc.CreateAttribute("id")
        anAttribute.Value = "0"
        'anAttribute.Value = CStr(tilebank)
        anItemElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("name")
        anAttribute.Value = Me.MapName
        anItemElement.SetAttributeNode(anAttribute)

        'anAttribute = aXmlDoc.CreateAttribute("author")
        'anAttribute.Value = Me.ProjectAuthor
        'anItemElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("lastUpdate")
        anAttribute.Value = CStr(DateTime.Today.Ticks)
        anItemElement.SetAttributeNode(anAttribute)

        For line = 0 To 23
            anItemElement.AppendChild(getLineElement(aXmlDoc, line))
        Next

        'Next
        ' END map data ##############################################

        ' save file
        aXmlDoc.Save(filePath)

        'closeProgressWin()
        Application.DoEvents()

    End Sub



    Public Function getTileElement(ByRef aXmlDoc As XmlDocument, ByVal tilebank As Integer, ByVal tile As Integer) As XmlElement

        Dim anElement As XmlElement
        Dim anItemElement As XmlElement
        Dim anAttribute As XmlAttribute
        Dim txtElement As XmlText

        Dim i As Integer
        Dim vaddr As Integer
        Dim data(8) As Byte

        anElement = aXmlDoc.CreateElement("item")

        anAttribute = aXmlDoc.CreateAttribute("id")
        anAttribute.Value = CStr(tile)
        anElement.SetAttributeNode(anAttribute)

        'patterns
        'vaddr = (tilebank * 2048) + (tile * 8) + TMS9918.TableBase.GRPCGP
        'For i = 0 To 7
        '    data(i) = Me.screen2.VPEEK(vaddr)
        '    vaddr += 1
        'Next
        anItemElement = aXmlDoc.CreateElement("gfxData")
        txtElement = aXmlDoc.CreateTextNode(joinData(data))
        anItemElement.AppendChild(txtElement)
        anElement.AppendChild(anItemElement)

        'colors
        'vaddr = (tilebank * 2048) + (tile * 8) + TMS9918.TableBase.GRPCOL
        'For i = 0 To 7
        '    data(i) = Me.screen2.VPEEK(vaddr)
        '    vaddr += 1
        'Next
        anItemElement = aXmlDoc.CreateElement("colorData")
        txtElement = aXmlDoc.CreateTextNode(joinData(data))
        anItemElement.AppendChild(txtElement)
        anElement.AppendChild(anItemElement)


        Return anElement

    End Function



    Public Function getLineElement(ByRef aXmlDoc As XmlDocument, ByVal line As Integer) As XmlElement

        Dim anElement As XmlElement
        'Dim anItemElement As XmlElement
        Dim anAttribute As XmlAttribute
        Dim txtElement As XmlText

        Dim i As Integer
        Dim vaddr As Integer
        Dim data(32) As Byte

        anElement = aXmlDoc.CreateElement("line")

        anAttribute = aXmlDoc.CreateAttribute("id")
        anAttribute.Value = CStr(line)
        anElement.SetAttributeNode(anAttribute)

        'patterns
        'vaddr = (line * 32) + TMS9918.TableBase.GRPNAM
        'For i = 0 To 31
        '    data(i) = Me.screen2.VPEEK(vaddr)
        '    vaddr += 1
        'Next

        txtElement = aXmlDoc.CreateTextNode(joinData(data))
        anElement.AppendChild(txtElement)


        Return anElement

    End Function



    ''' <summary>
    ''' Proporciona una cadena con una serie de datos separados por comas, extraidos de un array.
    ''' </summary>
    ''' <param name="aData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function joinData(ByVal aData As Byte()) As String
        Dim anOutput As String = ""
        Dim i As Integer
        'Dim dataLength As Integer = aData.Length

        'If Me.ProjectSize = SpriteMSX.SPRITE_SIZE8 Then
        '    dataLength = 7
        'End If

        For i = 0 To aData.Length - 2
            anOutput += aData(i).ToString + ","
        Next
        anOutput += aData(i).ToString

        Return anOutput

    End Function



    ''' <summary>
    ''' Proporciona un array a partir de una cadena con datos separados por comas.
    ''' </summary>
    ''' <param name="data"></param>
    ''' <param name="size"></param>
    ''' <param name="initpos"></param>
    ''' <param name="defaultvalue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ByteSpliter(ByVal data As String, ByVal size As Integer, ByVal initpos As Integer, ByVal defaultvalue As Byte) As Byte()
        Dim tmpData As Byte()
        Dim numitems As Integer = 0
        Dim counter As Integer = 0

        Dim defaultString As String = "," + CStr(defaultvalue)

        'data += ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        For i As Integer = 0 To 31
            data += defaultString
        Next

        ReDim tmpData(size)

        Dim splitdata As String() = data.Split(",")
        numitems = splitdata.GetLength(0)

        For i As Integer = initpos To initpos + size
            tmpData(counter) = CByte(splitdata(i))
            counter += 1
        Next

        Return tmpData
    End Function



    ''' <summary>
    ''' Muestra una ventana que avisa y pide confirmación, ya que la accion ejecutada borrará todos los datos del proyecto.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function AreYouSure() As Boolean
        Dim result As System.Windows.Forms.DialogResult

        result = MsgBox("This option will delete all data." + Chr(13) + "Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Question")

        If result = Windows.Forms.DialogResult.Yes Then
            Return True
        End If

        Return False

    End Function



    ''' <summary>
    ''' Lee el fichero de datos de nombres de patrones de la herramienta nMSXtiles de Pentacour
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LoadScrBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        screenTilesData = Nothing

        Me.OpenFileDialog1.DefaultExt = "scr"
        Me.OpenFileDialog1.Filter = "Screen nMSXtiles file|*.scr|All files|*.*"

        Me.OpenFileDialog1.FileName = Me.TilesetsName

        If Me.Path_Project = "" Then
            Me.Path_Project = Application.StartupPath
        End If
        Me.OpenFileDialog1.InitialDirectory = Me.Path_Project

        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If LoadNMSXtilesMAP(OpenFileDialog1.FileName) = True Then
                Me.Path_Project = Path.GetDirectoryName(OpenFileDialog1.FileName)
                'LoadScrText.Text = Me.MapName + ".scr"
            End If
        End If

    End Sub



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <remarks></remarks>
    Private Function LoadNMSXtilesMAP(ByVal filePath As String) As Boolean

        Try


            If Not System.IO.File.Exists(filePath) Then

                MsgBox("Not found the screen file : " + filePath, MsgBoxStyle.Critical, AcceptButton)
                Return False

            End If

            Dim dataText As New ArrayList()
            Dim sLine As String = ""
            Dim header As String

            Dim objReader As New StreamReader(filePath)

            'Me.Path_Screen = filePath

            Do
                sLine = objReader.ReadLine()
                If Not sLine Is Nothing Then
                    dataText.Add(sLine)
                End If
            Loop Until sLine Is Nothing
            objReader.Close()

            Dim totalLines As Integer = dataText.Count

            header = dataText.Item(0).ToString
            If Not header.Contains("SCREEN") Then
                '    dataText.RemoveAt(0)
                'Else
                Return False
            End If


            ReDim screenTilesData(dataText.Count)


            ' anyade la info en el buffer de pantalla
            Dim contador As Integer = 0
            Dim address As Short '= screen2.BASE(TMS9918.NumberOfBase.Name_Table_Base_Address)

            'For i = 1 To 768
            '    screenTilesData(contador) = CByte(dataText.Item(i))
            '    'screenTilesData(contador) = CByte(CInt(sLine))
            '    screen2.VPOKE(address, screenTilesData(contador))
            '    contador += 1
            '    address += 1
            'Next

            'screen2.RefreshScreen()


            'SetScreenViewer(0)

            Me.MapName = Path.GetFileNameWithoutExtension(filePath)
            'LoadScrText.Text = Me.MapName + ".scr"



        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function




    ''' <summary>
    ''' Displays tileset data in C language.
    ''' Muestra los datos del tileset, en lenguaje
    ''' </summary>
    ''' <param name="dataList"></param>
    ''' <remarks></remarks>
    Private Sub TileSet_CCodeGen(ByVal dataList As ArrayList)

        'Dim linesize As Integer = 0

        'Me.Tileset_TxtOutput.AppendText("// tileset " + TilesetsName + vbNewLine)

        'linesize = CInt(Me.Tileset_SizeLineComboB.SelectedItem)

        'For Each aDataItem As DataItem In dataList
        '    Me.Tileset_TxtOutput.AppendText(genData.C_codeGen(aDataItem.data, linesize, Tileset_NumSysComboBox.SelectedIndex, aDataItem.label, aDataItem.comment))
        '    Me.Tileset_TxtOutput.AppendText(vbNewLine) ' salto de linea
        'Next

    End Sub


    ''' <summary>
    ''' Displays tileset data in Assembler language.
    ''' </summary>
    ''' <param name="dataList"></param>
    ''' <remarks></remarks>
    Private Sub TileSet_AsmCodeGen(ByVal dataList As ArrayList)

        'Dim linesize As Integer = 0

        'Me.Tileset_TxtOutput.Clear()

        'Me.Tileset_TxtOutput.AppendText("; tileset " + TilesetsName + vbNewLine)

        'linesize = CInt(Me.Tileset_SizeLineComboB.SelectedItem)

        'For Each aDataItem As DataItem In dataList
        '    Me.Tileset_TxtOutput.AppendText(genData.Asm_codeGen(aDataItem.data, linesize, Tileset_NumSysComboBox.SelectedIndex, aDataItem.label, aDataItem.comment, "db"))

        '    Me.Tileset_TxtOutput.AppendText(vbNewLine) ' salto de linea
        'Next

    End Sub


    ''' <summary>
    ''' Displays tileset data in Assembler for SDCC.
    ''' </summary>
    ''' <param name="dataList"></param>
    ''' <remarks></remarks>
    Private Sub TileSet_AsmSDCCCodeGen(ByVal dataList As ArrayList)

        'Dim linesize As Integer = 0

        'Me.Tileset_TxtOutput.Clear()

        'Me.Tileset_TxtOutput.AppendText("; tileset " + TilesetsName + vbNewLine)

        'linesize = CInt(Me.Tileset_SizeLineComboB.SelectedItem)

        'For Each aDataItem As DataItem In dataList
        '    Me.Tileset_TxtOutput.AppendText(genData.Asm_codeGen(aDataItem.data, linesize, Tileset_NumSysComboBox.SelectedIndex, aDataItem.label, aDataItem.comment, ".db"))

        '    Me.Tileset_TxtOutput.AppendText(vbNewLine) ' salto de linea
        'Next

    End Sub


    ''' <summary>
    ''' Displays tileset data in MSX BASIC language
    ''' </summary>
    ''' <param name="dataList"></param>
    ''' <remarks></remarks>
    ''' , ByVal IniTile As Byte, ByVal EndTile As Byte
    Private Sub TileSet_BasicCodeGen(ByVal dataList As ArrayList)

        'Dim linesize As Integer = 0
        'Dim linenum As Integer = BasicConfig.StartingLine
        'Dim lineinterval As Integer = BasicConfig.Interval

        'Me.Tileset_TxtOutput.AppendText(CStr(linenum) + " REM tileset " + TilesetsName + vbNewLine)

        'linenum += lineinterval * 2

        'linesize = CInt(Me.Tileset_SizeLineComboB.SelectedItem)

        'For Each aDataItem As DataItem In dataList
        '    Me.Tileset_TxtOutput.AppendText(genData.BasicMSX_codeGen(aDataItem.data, linesize, Tileset_NumSysComboBox.SelectedIndex, BasicConfig.RemoveZeros, linenum, lineinterval, aDataItem.comment))
        '    Me.Tileset_TxtOutput.AppendText(vbNewLine) ' salto de linea
        '    linenum = genData.lastLineNumber
        'Next

    End Sub




    Private Sub GetScrButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GenerateScreenData()
    End Sub



    Private Sub GenerateScreenData()

        Dim outputSource As String = ""
        Dim vaddr As String
        Dim linesize As Integer = 0

        Dim startX As Integer = Val(Me.AreaStartX_TextBox.Text)
        Dim startY As Integer = Val(Me.AreaStartY_TextBox.Text)
        Dim endX As Integer = Val(Me.AreaEndX_TextBox.Text)
        Dim endY As Integer = Val(Me.AreaEndY_TextBox.Text)

        Dim comment As New ArrayList
        Dim tmpData() As Byte

        Dim aRLE As New RLE


        ' validate input data
        If startX < 0 Then
            startX = 0
        End If

        If startX > 31 Then
            startX = 0
        End If


        If startY < 0 Then
            startY = 0
        End If

        If startY > 23 Then
            startY = 0
        End If


        If endX < 0 Then
            endX = 31
        End If

        If endX > 31 Then
            endX = 31
        End If


        If endY < 0 Then
            endY = 23
        End If

        If endY > 23 Then
            endY = 23
        End If


        If startX > endX Then
            startX = 0
            endX = 31
        End If

        If startY > endY Then
            startY = 0
            endY = 23
        End If
        ' end validate


        Me.AreaStartX_TextBox.Text = startX
        Me.AreaStartY_TextBox.Text = startY
        Me.AreaEndX_TextBox.Text = endX
        Me.AreaEndY_TextBox.Text = endY

        ' generate byte array with screen data
        Dim data As Byte()
        Dim datasize As Integer = (endX - startX + 1) * (endY - startY + 1) - 1
        Dim conta As Integer = 0
        Dim addr As Short = 0
        Dim Base10 As Short '= screen2.BASE(TMS9918.NumberOfBase.Name_Table_Base_Address)
        ReDim data(datasize)

        'For i = startY To endY
        '    For o = startX To endX
        '        addr = Base10 + (i * 32) + o
        '        data(conta) = screen2.VPEEK(addr)
        '        conta += 1
        '    Next
        'Next
        ' end

        'vaddr = getHexShort(screen2.BASE(TMS9918.NumberOfBase.Name_Table_Base_Address) + (startY * 32) + startX)


        comment.Add("map " + MapName)
        comment.Add("VRAM address= " + vaddr + "h")
        comment.Add("start x=" + CStr(startX) + " y=" + CStr(startY))
        comment.Add("end   x=" + CStr(endX) + " y=" + CStr(endY))


        'Select Case Map_compressionScrCB.SelectedIndex

        '    Case 1
        '        tmpData = aRLE.GetRLE(data)
        '        comment.Add("RLE compressed - Original size= " + CStr(data.Length) + " - Final size= " + CStr(tmpData.Length))
        '    Case 2
        '        tmpData = aRLE.GetRLE_WB(data)
        '        comment.Add("RLE WB compressed - Original size= " + CStr(data.Length) + " - Final size= " + CStr(tmpData.Length))
        '        'Case 3
        '        '    tmpData = Me.GetRLE3(data)
        '        '    comment.Add("RLE3 compressed - Original size:" + CStr(data.Length) + " - RLE size:" + CStr(tmpData.Length))

        '    Case Else
        '        tmpData = data
        '        comment.Add("Size= " + CStr(data.Length))

        'End Select


        'If Me.Map_SizeLineComboB.SelectedIndex = 0 Then
        '    linesize = endX - startX + 1
        'Else
        '    linesize = CInt(Me.Map_SizeLineComboB.SelectedItem)
        'End If

        'Me.Tiles_TxtOutput.Clear()

        '' show data in respective code language
        'Select Case Map_CodeOutComboB.SelectedIndex
        '    Case MSXDataFormat.OutputFormat.C
        '        outputSource = genData.C_codeGen(tmpData, linesize, Map_NumSysComboBox.SelectedIndex, Me.Map_FieldName.Text, comment)
        '    Case MSXDataFormat.OutputFormat.ASM
        '        outputSource = genData.Asm_codeGen(tmpData, linesize, Map_NumSysComboBox.SelectedIndex, Me.Map_FieldName.Text, comment, "db")
        '    Case MSXDataFormat.OutputFormat.ASM_SDCC
        '        outputSource = genData.Asm_codeGen(tmpData, linesize, Map_NumSysComboBox.SelectedIndex, Me.Map_FieldName.Text, comment, ".db")
        '    Case MSXDataFormat.OutputFormat.BASIC
        '        outputSource = genData.BasicMSX_codeGen(tmpData, linesize, Map_NumSysComboBox.SelectedIndex, BasicConfig.RemoveZeros, BasicConfig.StartingLine, BasicConfig.Interval, comment)
        'End Select

        'Tiles_TxtOutput.AppendText(outputSource)

    End Sub



    Private Sub TilesetGenButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        GenerateTilesetData()

    End Sub



    ''' <summary>
    ''' Generates data for the graphics of the tiles.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GenerateTilesetData()

        Dim patternBase As Short '= screen2.BASE(TMS9918.NumberOfBase.Pattern_Generator_Base_Address)
        Dim colorBase As Short '= screen2.BASE(TMS9918.NumberOfBase.Color_Table_Base_Address)

        Dim dataOutputType As Integer = 0

        Dim dataList As New ArrayList

        'Me.Tileset_TxtOutput.Clear()

        'Dim name As String = Me.Tileset_FieldName.Text.ToUpper

        'If AllBanksCheckBox.Checked Then
        '    'ALL Banks

        '    If Me.ALLpattern.Checked Then
        '        dataList.Add(getDataItem("", True, name, getData(patternBase, 0, 767), CompressPat_ALL_CBox.SelectedIndex, "", ""))
        '    End If

        '    If Me.ALLcolor.Checked Then
        '        dataList.Add(getDataItem("", False, name, getData(colorBase, 0, 767), CompressCol_ALL_CBox.SelectedIndex, "", ""))
        '    End If


        'Else
        '    'selected banks

        '    If Me.B0Check.Checked And B0pattern.Checked Then
        '        dataList.Add(getDataItem("0", True, name, getData(patternBase, CByte(Me.B0IniTile.Text), CByte(Me.B0EndTile.Text)), Compression_PB0_CBox.SelectedIndex, Me.B0IniTile.Text, Me.B0EndTile.Text))
        '    End If

        '    If Me.Bank1CheckB.Checked And B1Pattern.Checked Then
        '        dataList.Add(getDataItem("1", True, name, getData(patternBase + 2048, CByte(Me.B1IniTile.Text), CByte(Me.B1EndTile.Text)), Compression_PB1_CBox.SelectedIndex, Me.B1IniTile.Text, Me.B1EndTile.Text))
        '    End If

        '    If Me.Bank2CheckB.Checked And B2Pattern.Checked Then
        '        dataList.Add(getDataItem("2", True, name, getData(patternBase + 4096, CByte(Me.B2IniTile.Text), CByte(Me.B2EndTile.Text)), Compression_PB2_CBox.SelectedIndex, Me.B2IniTile.Text, Me.B2EndTile.Text))
        '    End If


        '    If Me.B0Check.Checked And B0color.Checked Then
        '        dataList.Add(getDataItem("0", False, name, getData(colorBase, CByte(Me.B0IniTile.Text), CByte(Me.B0EndTile.Text)), Compression_CB0_CBox.SelectedIndex, Me.B0IniTile.Text, Me.B0EndTile.Text))
        '    End If

        '    If Me.Bank1CheckB.Checked And B1color.Checked Then
        '        dataList.Add(getDataItem("1", False, name, getData(colorBase + 2048, CByte(Me.B1IniTile.Text), CByte(Me.B1EndTile.Text)), Compression_CB1_CBox.SelectedIndex, Me.B1IniTile.Text, Me.B1EndTile.Text))
        '    End If

        '    If Me.Bank2CheckB.Checked And B2color.Checked Then
        '        dataList.Add(getDataItem("2", False, name, getData(colorBase + 4096, CByte(Me.B2IniTile.Text), CByte(Me.B2EndTile.Text)), Compression_CB2_CBox.SelectedIndex, Me.B2IniTile.Text, Me.B2EndTile.Text))
        '    End If

        'End If



        'Select Case Tileset_CodeOutComboB.SelectedIndex
        '    Case MSXDataFormat.OutputFormat.C
        '        ' C
        '        TileSet_CCodeGen(dataList)
        '    Case MSXDataFormat.OutputFormat.ASM
        '        ' ASM
        '        TileSet_AsmCodeGen(dataList)
        '    Case MSXDataFormat.OutputFormat.ASM_SDCC
        '        ' ASM SDCC
        '        TileSet_AsmSDCCCodeGen(dataList)
        '    Case MSXDataFormat.OutputFormat.BASIC
        '        ' BASIC
        '        TileSet_BasicCodeGen(dataList)
        'End Select

    End Sub


    Private Function getDataItem(ByVal nbank As String, ByVal isPattern As Boolean, ByVal name As String, ByVal data() As Byte, ByVal nCompression As Integer, ByVal iniTile As String, ByVal endTile As String) As DataItem

        Dim comment As New ArrayList
        Dim tmpData() As Byte
        Dim preName As String

        Dim aRLE As New RLE
        Dim aRLEWB As New RLEWB

        If nbank = "" Then
            If isPattern Then
                comment.Add("pattern data")
                preName = "_pat"
            Else
                comment.Add("color data")
                preName = "_col"
            End If

        Else
            If isPattern Then
                comment.Add("pattern data BANK " + nbank)
                preName = "_pat_BANK" + nbank
            Else
                comment.Add("color data BANK " + nbank)
                preName = "_col_BANK" + nbank
            End If

            comment.Add("tiles: " + iniTile + ">" + endTile)

        End If


        Select Case nCompression

            Case 1
                tmpData = aRLE.Compress(data)
                comment.Add("RLE compressed - Original size= " + CStr(data.Length) + " - Final size= " + CStr(tmpData.Length))
            Case 2
                tmpData = aRLEWB.Compress(data)
                comment.Add("RLE WB compressed - Original size= " + CStr(data.Length) + " - Final size= " + CStr(tmpData.Length))
                'Case 3
                '    tmpData = Me.GetRLE3(data)
                '    comment.Add("RLE3 compressed - Original size:" + CStr(data.Length) + " - RLE size:" + CStr(tmpData.Length))

            Case Else
                tmpData = data
                comment.Add("Size= " + CStr(data.Length))

        End Select

        Return New DataItem(name + preName, comment, tmpData)

    End Function



    Private Function getData(ByVal vramAddress As Short, ByVal IniTile As Byte, ByVal EndTile As Short) As Byte()

        Dim data As Byte()
        Dim contaTile As Integer = IniTile
        Dim i As Integer = 0
        Dim o As Integer = 0
        Dim datasize As Integer = (EndTile - IniTile + 1) * 8
        Dim conta As Integer = 0
        Dim addr As Short = 0

        ReDim data(datasize - 1)

        addr = vramAddress + (IniTile * 8)

        For i = IniTile To EndTile
            For o = 0 To 7
                'data(conta) = screen2.VPEEK(addr)
                addr += 1
                conta += 1
            Next
            'contaTile += 1
        Next

        Return data

    End Function




    Private Sub Load_TileSet_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.OpenFileDialog1.DefaultExt = "til"
        Me.OpenFileDialog1.Filter = "Tiles nMSXtiles file|*.til"

        Me.OpenFileDialog1.FileName = Me.TilesetsName

        If Me.Path_Project = "" Then
            Me.Path_Project = Application.StartupPath
        End If
        Me.OpenFileDialog1.InitialDirectory = Me.Path_Project

        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If LoadNMSXtilesTileSet(OpenFileDialog1.FileName) = True Then
                Me.Path_Project = Path.GetDirectoryName(OpenFileDialog1.FileName)
                'Me.TilesetsName = Path.GetFileNameWithoutExtension(OpenFileDialog1.FileName)
            End If
        End If

    End Sub




    Private Function LoadNMSXtilesTileSet(ByVal filePath As String) As Boolean

        Try

            Dim i As Integer = 0
            Dim o As Integer = 0
            Dim bank As Integer
            Dim line As Integer
            Dim column As Integer

            If Not System.IO.File.Exists(filePath) Then

                MsgBox("Not found the tileset file: " + filePath, MsgBoxStyle.Critical, AcceptButton)
                Return False

            End If

            'Me.Path_Tileset = filePath

            Dim objReader As New StreamReader(filePath)
            Dim dataText As New ArrayList()

            Dim sLine As String

            Do
                sLine = objReader.ReadLine()
                If Not sLine Is Nothing Then
                    dataText.Add(sLine)
                End If
            Loop Until sLine Is Nothing
            objReader.Close()

            Dim totalLines As Integer = dataText.Count

            If Not dataText.Item(0).Equals("TILES") Then
                Return False
            Else

                Dim colorBase As Short '= screen2.BASE(TMS9918.NumberOfBase.Color_Table_Base_Address)
                Dim gfxBase As Short '= screen2.BASE(TMS9918.NumberOfBase.Pattern_Generator_Base_Address)

                Dim conta As Integer = 0

                Dim lowVal As Byte
                Dim higVal As Byte

                Dim aByteString As String

                For bank = 0 To 2
                    conta = dataText.IndexOf("BANK" + CStr(bank))
                    If dataText.Item(conta).Equals("BANK" + CStr(bank)) Then
                        conta += 1

                        For line = 0 To 7
                            For column = 0 To 31
                                'colors
                                For i = 0 To 7
                                    'the two values of colors are separated in two bytes
                                    lowVal = CByte(dataText.Item(conta))
                                    higVal = CByte(dataText.Item(conta + 8))
                                    conta += 1
                                    'screen2.VPOKE(colorBase, (higVal * 16) + lowVal)
                                    colorBase += 1
                                Next
                                conta += 8

                                'pattern data
                                For i = 0 To 7
                                    aByteString = ""
                                    For o = 0 To 7
                                        aByteString += dataText.Item(conta)
                                        conta += 1
                                    Next
                                    'screen2.VPOKE(gfxBase, CByte(Convert.ToInt32(aByteString, 2)))
                                    gfxBase += 1
                                Next

                            Next
                        Next
                    End If
                Next

                'screen2.RefreshScreen()

                Me.TilesetsName = Path.GetFileNameWithoutExtension(filePath)
                'LoadTilText.Text = Me.TilesetsName + ".til"

            End If


            Return True

        Catch ex As Exception
            Return False
        End Try

    End Function





    ''' <summary>
    ''' Load a nMSXtiles Project
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <remarks></remarks>
    Private Function LoadNMSXtilesProject(ByVal filePath As String) As Boolean
        Dim objReader As New StreamReader(filePath)
        Dim dataText As New ArrayList()
        Dim sLine As String
        Dim result As Boolean = True

        Dim aTmpPath As String = Path.GetDirectoryName(filePath) + Path.DirectorySeparatorChar

        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                dataText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()

        If Not dataText.Item(0).Equals("PROJECT") Then
            MsgBox("The selected file is not of nMSXtiles Project type", MsgBoxStyle.Critical, "Error")
        Else
            Dim TilesPath As String = dataText.Item(4)

            If Not File.Exists(TilesPath) Then
                TilesPath = aTmpPath + TilesPath
            End If

            result = LoadNMSXtilesTileSet(TilesPath)

            If result Then
                Application.DoEvents()
                Dim MapPath As String = dataText.Item(2)
                If Not File.Exists(MapPath) Then
                    MapPath = aTmpPath + MapPath
                End If

                LoadNMSXtilesMAP(MapPath)

                'screen2.SetDefaultPalette()
                'screen2.RefreshScreen()

                Application.DoEvents()

                'NewProject(Path.GetFileNameWithoutExtension(filePath))

            End If

        End If

        Return result

    End Function



    Private Sub SaveNMSXtilesProject(ByVal filePath As String)

        Try

            Dim aTmpPath As String = Path.GetDirectoryName(filePath) + Path.DirectorySeparatorChar

            ' save a project file
            'PROJECT
            'SCREEN
            'scorchedtanks_msx.scr
            'TILES
            'scorschedtanks_msx.til
            Dim objWriter As New StreamWriter(filePath)

            objWriter.WriteLine("PROJECT")
            objWriter.WriteLine("SCREEN")
            objWriter.WriteLine(Me.MapName + ".scr")
            objWriter.WriteLine("TILES")
            objWriter.WriteLine(Me.TilesetsName + ".til")

            objWriter.Close()

            'save a screen map file
            SaveNMSXtilesMAP(aTmpPath + Me.MapName + ".scr")

            'save a tileset file
            SaveNMSXtilesTileset(aTmpPath + Me.TilesetsName + ".til")

        Catch ex As Exception
            MsgBox("Disk I/O error.", MsgBoxStyle.Critical, "Error")
        End Try

    End Sub



    Private Sub SaveNMSXtilesMAP(ByVal filePath As String)

        Dim objWriter As New StreamWriter(filePath)
        objWriter.WriteLine("SCREEN")

        Try
            Dim vaddr As Short '= screen2.BASE(TMS9918.NumberOfBase.Name_Table_Base_Address)

            For i As Integer = 0 To 767
                'objWriter.WriteLine(Str(screen2.VPEEK(vaddr)))
                vaddr += 1
            Next

            objWriter.Close()

        Catch ex As Exception
            objWriter.Close()
        End Try

    End Sub



    Private Sub SaveNMSXtilesTileset(ByVal filePath As String)

        Dim objWriter As New StreamWriter(filePath)
        objWriter.WriteLine("TILES")

        'objWriter.WriteLine("BANK0")
        'objWriter.WriteLine("BANK1")
        'objWriter.WriteLine("BANK2")
        Try
            'Dim vaddr As Short = aScreen2.BASE(screen2.NumberOfBase.Name_Table_Base_Address)

            'For i As Integer = 0 To 767
            '    objWriter.WriteLine(Str(aScreen2.VPEEK(vaddr)))
            '    vaddr += 1
            'Next


            Dim colorBase As Short '= screen2.BASE(TMS9918.NumberOfBase.Color_Table_Base_Address)
            Dim gfxBase As Short '= screen2.BASE(TMS9918.NumberOfBase.Pattern_Generator_Base_Address)

            'Dim conta As Integer = 0

            Dim lowVal As UInteger
            Dim higVal As UInteger
            Dim patternValue As Byte

            'Dim BitString As String

            For bank = 0 To 2
                'conta = dataText.IndexOf("BANK" + CStr(bank))
                objWriter.WriteLine("BANK" + CStr(bank))
                'If dataText.Item(conta).Equals("BANK" + CStr(bank)) Then
                '    conta += 1

                For line = 0 To 7
                    For column = 0 To 31
                        'colors
                        For i = 0 To 7
                            'the two values of colors are separated in two bytes
                            'lowVal = screen2.VPEEK(colorBase + i) And 15
                            'objWriter.WriteLine(lowVal)
                        Next

                        For i = 0 To 7
                            'the two values of colors are separated in two bytes
                            'higVal = screen2.VPEEK(colorBase)
                            'higVal = (higVal And 240) / 16
                            'colorBase += 1
                            'objWriter.WriteLine(higVal)
                        Next


                        'pattern data
                        For i = 0 To 7
                            'patternValue = screen2.VPEEK(gfxBase)
                            gfxBase += 1

                            For o As Integer = 7 To 0 Step -1
                                If (patternValue And Me.bite_MASKs(o)) = Me.bite_MASKs(o) Then
                                    '1
                                    objWriter.WriteLine("1")
                                Else
                                    '0
                                    objWriter.WriteLine("0")
                                End If
                            Next

                        Next

                    Next
                Next
                'End If
            Next

            objWriter.Close()

        Catch ex As Exception
            objWriter.Close()
        End Try

    End Sub







    ''' <summary>
    ''' Proporciona un valor en hexadecimal con la forma del lenguaje C
    ''' </summary>
    ''' <param name="avalue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getHexByte(ByVal avalue As Byte) As String
        Dim hexvalue As String = "00" + Hex(avalue)
        Return "0x" + hexvalue.Substring(hexvalue.Length - 2, 2)
    End Function



    ''' <summary>
    ''' Proporciona un valor hexadecimal de 16bits
    ''' </summary>
    ''' <param name="avalue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getHexShort(ByVal avalue As Short) As String
        Dim hexvalue As String = "0000" + Hex(avalue)
        Return hexvalue.Substring(hexvalue.Length - 4, 4)
    End Function


    ''' <summary>
    ''' Proporciona un valor en hexadecimal con la forma del lenguaje ASM
    ''' </summary>
    ''' <param name="avalue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getAsmHexByte(ByVal avalue As Byte) As String
        Dim hexvalue As String = "000" + Hex(avalue)
        Return hexvalue.Substring(hexvalue.Length - 3, 3) + "h"
    End Function


    'Private Sub LoadSC2But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadSC2But.Click

    '    Me.OpenFileDialog1.DefaultExt = "sc2"
    '    Me.OpenFileDialog1.Filter = "Screen2 bin file|*.sc2|VRAM bin file|*.bin|All files|*.*"

    '    Me.OpenFileDialog1.FileName = ProjectFileName

    '    If Not Me.Path_SC2 = "" Then
    '        Me.OpenFileDialog1.InitialDirectory = Me.Path_SC2
    '    End If

    '    If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '        LoadSC2(OpenFileDialog1.FileName)
    '        Me.Path_SC2 = Path.GetDirectoryName(OpenFileDialog1.FileName)
    '        Me.ProjectFileName = Path.GetFileNameWithoutExtension(OpenFileDialog1.FileName)
    '    End If

    'End Sub



    'Private Sub LoadSC2(ByVal filePath As String)
    '    Dim aName As String
    '    If Me.screen2.LoadSC2(filePath) = True Then
    '        aName = Path.GetFileNameWithoutExtension(filePath)
    '        Me.MapName = aName
    '        Me.TilesetsName = aName
    '        'ShowProjectNameData()
    '        NewProject(aName)
    '    Else
    '        MsgBox("The selected file type is not SC2", MsgBoxStyle.Critical, "Error")
    '    End If
    'End Sub







    Private Sub SaveCBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'If Me.Tiles_TxtOutput.Text.Length < 1 Then
        '    MsgBox("No data to save.", MsgBoxStyle.Critical, "Error")
        '    Exit Sub
        'End If

        'Dim filePath As String
        'Dim resultado As System.Windows.Forms.DialogResult

        'If Map_CodeOutComboB.SelectedIndex = MSXDataFormat.OutputFormat.C Then
        '    Me.SaveFileDialog1.DefaultExt = "C"
        '    Me.SaveFileDialog1.Filter = "C Source|*.C"
        'ElseIf Map_CodeOutComboB.SelectedIndex = MSXDataFormat.OutputFormat.BASIC Then
        '    Me.SaveFileDialog1.DefaultExt = "BAS"
        '    Me.SaveFileDialog1.Filter = "BASIC Source|*.BAS"
        'Else
        '    Me.SaveFileDialog1.DefaultExt = "ASM"
        '    Me.SaveFileDialog1.Filter = "ASM Source|*.ASM"
        'End If

        'Me.SaveFileDialog1.FileName = Path.GetFileNameWithoutExtension(Me.Path_Screen)


        'resultado = SaveFileDialog1.ShowDialog()

        'If Not resultado = Windows.Forms.DialogResult.OK Then
        '    Exit Sub
        'End If

        'filePath = SaveFileDialog1.FileName

        'Dim aStreamWriterFile As New System.IO.StreamWriter(filePath)
        'aStreamWriterFile.WriteLine(Tiles_TxtOutput.Text)
        'aStreamWriterFile.Close()

    End Sub


    Private Sub SaveTilesCBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'If Me.Tileset_TxtOutput.Text.Length < 1 Then
        '    MsgBox("No data to save.", MsgBoxStyle.Critical, "Error")
        '    Exit Sub
        'End If

        'Dim filePath As String
        'Dim resultado As System.Windows.Forms.DialogResult

        'If Tileset_CodeOutComboB.SelectedIndex = MSXDataFormat.OutputFormat.C Then
        '    Me.SaveFileDialog1.DefaultExt = "C"
        '    Me.SaveFileDialog1.Filter = "C Source|*.C"
        'ElseIf Tileset_CodeOutComboB.SelectedIndex = MSXDataFormat.OutputFormat.BASIC Then
        '    Me.SaveFileDialog1.DefaultExt = "BAS"
        '    Me.SaveFileDialog1.Filter = "BASIC Source|*.BAS"
        'Else
        '    Me.SaveFileDialog1.DefaultExt = "ASM"
        '    Me.SaveFileDialog1.Filter = "ASM Source|*.ASM"
        'End If

        'Me.SaveFileDialog1.FileName = Path.GetFileNameWithoutExtension(Me.Path_Tileset)

        'resultado = SaveFileDialog1.ShowDialog()

        'If Not resultado = Windows.Forms.DialogResult.OK Then
        '    Exit Sub
        'End If

        'filePath = SaveFileDialog1.FileName

        'Dim aStreamWriterFile As New System.IO.StreamWriter(filePath)
        'aStreamWriterFile.WriteLine(Tileset_TxtOutput.Text)
        'aStreamWriterFile.Close()

    End Sub


    Private Sub CodeOutComboB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Tileset_TxtOutput.Clear()

        'If Tileset_CodeOutComboB.SelectedIndex = MSXDataFormat.OutputFormat.BASIC Then
        '    'Basic
        '    BasicConfigButton.Enabled = True
        'Else
        '    Me.BasicConfigButton.Enabled = False
        'End If

        'Select Case Tileset_CodeOutComboB.SelectedIndex
        '    Case MSXDataFormat.OutputFormat.BASIC
        '        Tileset_NumSysComboBox.SelectedIndex = MSXDataFormat.DataFormat.DECIMAL_nnn

        '    Case MSXDataFormat.OutputFormat.C
        '        Tileset_NumSysComboBox.SelectedIndex = MSXDataFormat.DataFormat.HEXADECIMAL_0xnn

        '    Case MSXDataFormat.OutputFormat.ASM
        '        Tileset_NumSysComboBox.SelectedIndex = MSXDataFormat.DataFormat.HEXADECIMAL_0nnh

        '    Case MSXDataFormat.OutputFormat.ASM_SDCC
        '        Tileset_NumSysComboBox.SelectedIndex = MSXDataFormat.DataFormat.HEXADECIMAL_0xnn

        'End Select

    End Sub



    Private Sub Map_CodeOutComboB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Tiles_TxtOutput.Clear()

        'If Map_CodeOutComboB.SelectedIndex = MSXDataFormat.OutputFormat.BASIC Then
        '    'Basic
        '    BasicConfigButton2.Enabled = True
        'Else
        '    BasicConfigButton2.Enabled = False
        'End If

        'Select Case Map_CodeOutComboB.SelectedIndex
        '    Case MSXDataFormat.OutputFormat.BASIC
        '        Map_NumSysComboBox.SelectedIndex = MSXDataFormat.DataFormat.DECIMAL_nnn

        '    Case MSXDataFormat.OutputFormat.C
        '        Map_NumSysComboBox.SelectedIndex = MSXDataFormat.DataFormat.HEXADECIMAL_0xnn

        '    Case MSXDataFormat.OutputFormat.ASM
        '        Map_NumSysComboBox.SelectedIndex = MSXDataFormat.DataFormat.HEXADECIMAL_0nnh

        '    Case MSXDataFormat.OutputFormat.ASM_SDCC
        '        Map_NumSysComboBox.SelectedIndex = MSXDataFormat.DataFormat.HEXADECIMAL_0xnn

        'End Select

    End Sub



    Private Sub TilesClearBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '
        Dim result As DialogResult

        Dim toolFillMapForm As New FillMapForm()
        result = toolFillMapForm.ShowDialog()

        If result = Windows.Forms.DialogResult.OK Then
            Me.TMS9918Aviewer.FillVRAM(iVDP.TableBase.GRPNAM, 767, toolFillMapForm.Tile)
            Me.TMS9918Aviewer.RefreshScreen()
        End If

    End Sub





    Private Sub ChangeColor(ByVal OldColor As Byte, ByVal NewColor As Byte)

        If OldColor > 15 Or NewColor > 15 Then
            Exit Sub
        End If

        Dim colorBase As Short = iVDP.TableBase.GRPCOL   'screen2.BASE(TMS9918.NumberOfBase.Color_Table_Base_Address)
        Dim avalue As Byte
        Dim colorInk As Byte
        Dim colorBG As Byte
        Dim i As Integer = 0

        For i = colorBase To colorBase + 6143
            avalue = Me.TMS9918Aviewer.VPEEK(i)

            colorInk = (avalue And &HF0) / 16
            colorBG = avalue And &HF

            If colorInk = OldColor Then
                colorInk = NewColor
            End If
            If colorBG = OldColor Then
                colorBG = NewColor
            End If
            avalue = (colorInk * 16) + colorBG

            Me.TMS9918Aviewer.VPOKE(i, avalue)
        Next

        Me.TMS9918Aviewer.RefreshScreen()

    End Sub




    Private Sub ChangeTiles(ByVal OldNumTile As Byte, ByVal NewNumTile As Byte)

        Dim nameBase As Short = iVDP.TableBase.GRPNAM  'screen2.BASE(TMS9918.NumberOfBase.Name_Table_Base_Address)
        Dim i As Integer = 0

        If OldNumTile > 255 Or NewNumTile > 255 Then
            Exit Sub
        End If

        For i = nameBase To nameBase + 6143
            If Me.TMS9918Aviewer.VPEEK(i) = OldNumTile Then
                Me.TMS9918Aviewer.VPOKE(i, NewNumTile)
            End If
        Next

        Me.TMS9918Aviewer.RefreshScreen()

    End Sub



    Private Sub SetDefaultMapArea()
        AreaStartX_TextBox.Text = 0
        AreaStartY_TextBox.Text = 0
        AreaEndX_TextBox.Text = 31
        AreaEndY_TextBox.Text = 23
    End Sub



    Private Sub Map_areaResetButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Map_areaResetButton.Click
        SetDefaultMapArea()
    End Sub



    Private Sub aScreen2_MouseSelectedPos(ByVal startx As Integer, ByVal starty As Integer, ByVal endx As Integer, ByVal endy As Integer) ' Handles screen2.MouseSelectedPos

        If endx < startx Then
            'unselect area
            SetDefaultMapArea()
        Else
            AreaStartX_TextBox.Text = startx
            AreaStartY_TextBox.Text = starty
            AreaEndX_TextBox.Text = endx
            AreaEndY_TextBox.Text = endy
        End If

    End Sub




    ''' <summary>
    ''' validates the field, the first value range of the tileset 
    ''' valida el campo del primer valor de rango del tileset
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub IniTileTextBox_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim value As String = sender.text
        If IsNumeric(value) Then
            If value < 0 Or value > 255 Then
                sender.text = 0
            End If
        Else
            sender.text = 0
        End If
    End Sub



    ''' <summary>
    ''' validates the field, the last value range of the tileset 
    ''' valida el campo del ultimo valor de rango del tileset
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub EndTileTextBox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim value As String = sender.text
        If IsNumeric(value) Then
            If value < 0 Or value > 255 Then
                sender.text = 255
            End If
        Else
            sender.text = 255
        End If
    End Sub



    Private Sub Tileset_LinenumTextB_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        validateLineNum(sender)
    End Sub



    Private Sub Tiles_LinenumTextB_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        validateLineNum(sender)
    End Sub



    ''' <summary>
    ''' validates the value of the initial line number
    ''' valida el valor del numero de linea inicial
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <remarks></remarks>
    Private Sub validateLineNum(ByVal sender As TextBox)
        Dim value As String = sender.Text
        If IsNumeric(value) Then
            If value < 1 Or value > 60000 Then
                sender.Text = 1
            End If
        Else
            sender.Text = 1
        End If
    End Sub



    Private Sub Tileset_IntervalTextB_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        validateInterval(sender)
    End Sub



    Private Sub Tiles_IntervalTextB_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        validateInterval(sender)
    End Sub



    ''' <summary>
    ''' Valid value range between the lines (for MSX-BASIC).
    ''' Valida el valor de intervalo entre lineas (para MSX-BASIC).
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <remarks></remarks>
    Private Sub validateInterval(ByVal sender As TextBox)
        Dim value As String = sender.Text
        If IsNumeric(value) Then
            If value < 1 Or value > 100 Then
                sender.Text = 10
            End If
        Else
            sender.Text = 10
        End If
    End Sub


    Private Sub startTileX_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles AreaStartX_TextBox.Validating
        validateTileX(sender, 0)
    End Sub


    Private Sub endTileX_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles AreaEndX_TextBox.Validating
        validateTileX(sender, 31)
    End Sub



    ''' <summary>
    ''' Validates the value of position x.
    ''' Valida el valor de posicion x.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="defaultValue"></param>
    ''' <remarks></remarks>
    Private Sub validateTileX(ByVal sender As TextBox, ByVal defaultValue As Integer)
        Dim value As String = sender.Text
        If IsNumeric(value) Then
            If value < 0 Or value > 31 Then
                sender.Text = defaultValue
            End If
        Else
            sender.Text = defaultValue
        End If
    End Sub


    Private Sub startTileY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles AreaStartY_TextBox.Validating
        validateTileY(sender, 0)
    End Sub


    Private Sub endTileY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles AreaEndY_TextBox.Validating
        validateTileY(sender, 23)
    End Sub


    ''' <summary>
    ''' Validates the value of position y.
    ''' Valida el valor de posicion y.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="defaultValue"></param>
    ''' <remarks></remarks>
    Private Sub validateTileY(ByVal sender As TextBox, ByVal defaultValue As Integer)
        Dim value As String = sender.Text
        If IsNumeric(value) Then
            If value < 0 Or value > 23 Then
                sender.Text = defaultValue
            End If
        Else
            sender.Text = defaultValue
        End If
    End Sub

    Private Sub TileOldText_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        validateTileEntry(sender)
    End Sub

    Private Sub TileNewText_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        validateTileEntry(sender)
    End Sub

    Private Sub ColorOldText_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        validateColorEntry(sender)
    End Sub

    Private Sub ColorNewText_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        validateColorEntry(sender)
    End Sub

    ''' <summary>
    ''' Validates a entry color number
    ''' Valida una entrada de numero de color.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <remarks></remarks>
    Private Sub validateColorEntry(ByVal sender As TextBox)
        Dim value As String = sender.Text
        If IsNumeric(value) Then
            If value < 0 Then
                sender.Text = 0
            ElseIf value > 15 Then
                sender.Text = 15
            End If
        Else
            sender.Text = 0
        End If
    End Sub

    ''' <summary>
    ''' Validates a value of number of tile.
    ''' Valida un valor de numero de tile.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <remarks></remarks>
    Private Sub validateTileEntry(ByVal sender As TextBox)
        Dim value As String = sender.Text
        If IsNumeric(value) Then
            If value < 0 Then
                sender.Text = 0
            ElseIf value > 255 Then
                sender.Text = 255
            End If
        Else
            sender.Text = 0
        End If
    End Sub

    ' END validatings <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<


    ' eventos del selector del visualizador




    Private Sub ShowAbout(isOnInitialization As Boolean)
        Dim newAboutWin As New AboutWin
        newAboutWin.SetPicture = Global.MSXTILESdevtool.My.Resources.Aboud_win_msxTiles
        If isOnInitialization = True Then
            newAboutWin.StartPosition = FormStartPosition.CenterScreen
        End If
        newAboutWin.ShowDialog()
    End Sub



    Private Sub setRepeated(ByRef RLEtmpData As ArrayList, ByVal value As Byte, ByVal numrep As Byte)
        RLEtmpData.Add(numrep)
        RLEtmpData.Add(value)
    End Sub






    Private Sub EditPalette()

        Dim result As DialogResult
        'result = PaletteDialog.ShowWinDialog()

        'If result = Windows.Forms.DialogResult.OK Then
        '    Me.screen2.SetPalette(PaletteDialog.PaletteColors)
        '    Me.screen2.RefreshScreen()
        'End If

    End Sub



    Private Sub GetPaletteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim comments As New ArrayList
        'Dim tmpData() As Byte

        Dim outputSource As String = ""
        Dim linesize As Integer = 0

        'linesize = CInt(Me.Palette_SizeLineComboB.SelectedItem)

        'comments.Add(Me.screen2.GetPalette().Name)


        'Me.Palette_TxtOutput.Clear()

        '' show data in respective code language
        'Select Case Palette_CodeOutComboB.SelectedIndex
        '    Case MSXDataFormat.OutputFormat.C
        '        comments.Add("RB,G")
        '        outputSource = genData.C_codeGen(Me.screen2.GetPalette().GetData(), linesize, Me.Palette_NumSysCombo.SelectedIndex, Palette_FieldName.Text, comments)

        '    Case MSXDataFormat.OutputFormat.ASM
        '        comments.Add("RB,G")
        '        outputSource = genData.Asm_codeGen(Me.screen2.GetPalette().GetData(), linesize, Me.Palette_NumSysCombo.SelectedIndex, Palette_FieldName.Text, comments, "db")

        '    Case MSXDataFormat.OutputFormat.ASM_SDCC
        '        comments.Add("RB,G")
        '        outputSource = genData.Asm_codeGen(Me.screen2.GetPalette().GetData(), linesize, Me.Palette_NumSysCombo.SelectedIndex, Palette_FieldName.Text, comments, ".db")

        '    Case MSXDataFormat.OutputFormat.BASIC
        '        comments.Add("Num color, Red, Green, Blue")
        '        outputSource = genData.BasicMSX_codeGen(Me.screen2.GetPalette().GetDataBasic(), linesize, Me.Palette_NumSysCombo.SelectedIndex, BasicConfig.RemoveZeros, BasicConfig.StartingLine, BasicConfig.Interval, comments)

        'End Select


        'Me.Palette_TxtOutput.AppendText(outputSource)

    End Sub



    ' realiza cambios en la interfaz segun Lenguage de programacion seleccionado
    Private Sub Palette_CodeOutComboB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Me.Palette_SizeLineComboB.Items.Clear()
        'If Palette_CodeOutComboB.SelectedIndex = MSXDataFormat.OutputFormat.BASIC Then
        '    ' BASIC
        '    BasicConfigButton3.Enabled = True
        '    Me.Palette_SizeLineComboB.Items.AddRange(New Object() {"3", "6", "9", "18", "48"})
        'Else
        '    BasicConfigButton3.Enabled = False
        '    Me.Palette_SizeLineComboB.Items.AddRange(New Object() {"2", "4", "8", "16", "32"})
        'End If
        'Me.Palette_SizeLineComboB.SelectedIndex = 0

        'Select Case Palette_CodeOutComboB.SelectedIndex
        '    Case MSXDataFormat.OutputFormat.BASIC
        '        Palette_NumSysCombo.SelectedIndex = MSXDataFormat.DataFormat.DECIMAL_nnn

        '    Case MSXDataFormat.OutputFormat.C
        '        Palette_NumSysCombo.SelectedIndex = MSXDataFormat.DataFormat.HEXADECIMAL_0xnn

        '    Case MSXDataFormat.OutputFormat.ASM
        '        Palette_NumSysCombo.SelectedIndex = MSXDataFormat.DataFormat.HEXADECIMAL_0nnh

        '    Case MSXDataFormat.OutputFormat.ASM_SDCC
        '        Palette_NumSysCombo.SelectedIndex = MSXDataFormat.DataFormat.HEXADECIMAL_0xnn

        'End Select

    End Sub





    Private Sub InvertButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim aInvertDialog As New InvertDialog
        Dim result As DialogResult
        result = aInvertDialog.ShowDialog
        If result = Windows.Forms.DialogResult.OK Then
            InvertTool(aInvertDialog.PatternCheckBox.Checked, aInvertDialog.ColorCheckBox.Checked)
        End If
    End Sub



    Private Sub InvertTool(ByVal toPattern As Boolean, ByVal toColor As Boolean)
        Dim colorBase As Short
        Dim avalue As Byte
        Dim colorInk As Byte
        Dim colorBG As Byte
        Dim i As Integer = 0

        If toPattern Then
            colorBase = iVDP.TableBase.GRPCGP     'Me.TMS9918Aviewer.BASE(iVDP.NumberOfBase.Pattern_Generator_Base_Address)
            For i = colorBase To colorBase + 6143
                avalue = Me.TMS9918Aviewer.VPEEK(i)
                Me.TMS9918Aviewer.VPOKE(i, Not (avalue))
            Next
        End If


        If toColor Then
            colorBase = iVDP.TableBase.GRPCOL 'screen2.BASE(TMS9918.NumberOfBase.Color_Table_Base_Address)
            For i = colorBase To colorBase + 6143
                avalue = Me.TMS9918Aviewer.VPEEK(i)

                colorInk = (avalue And &HF0) / 16
                colorBG = avalue And &HF

                avalue = (colorBG * 16) + colorInk

                Me.TMS9918Aviewer.VPOKE(i, avalue)
            Next
        End If

        Me.TMS9918Aviewer.RefreshScreen()

    End Sub








    ''' <summary>
    ''' Opens the project information editing window.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetProjectInfo()

        'Dim ProjectProperties As New ProjectPropertiesWin

        'ProjectProperties.ProjectName = Me.ProjectName
        'ProjectProperties.ProjectVersion = Me.ProjectVersion
        'ProjectProperties.ProjectGroup = Me.ProjectGroup
        'ProjectProperties.ProjectAuthor = Me.ProjectAuthor
        'ProjectProperties.ProjectDescription = Me.ProjectDescription
        'ProjectProperties.ProjectStartDate = Me.ProjectStartDate
        'ProjectProperties.ProjectLastUpdate = Me.ProjectLastUpdate

        'If ProjectProperties.ShowDialog = Windows.Forms.DialogResult.OK Then
        '    Me.ProjectName = ProjectProperties.ProjectName
        '    Me.ProjectVersion = ProjectProperties.ProjectVersion
        '    Me.ProjectGroup = ProjectProperties.ProjectGroup
        '    Me.ProjectAuthor = ProjectProperties.ProjectAuthor
        '    Me.ProjectDescription = ProjectProperties.ProjectDescription
        'End If

    End Sub



    'Private Sub NewProject(ByVal name As String)
    '    Me.Info.Name = name
    '    Me.ProjectVersion = "0"
    '    Me.ProjectGroup = ""
    '    Me.ProjectAuthor = ""
    '    Me.ProjectDescription = ""
    '    Me.ProjectStartDate = DateTime.Today.Ticks

    '    'LoadScrText.Text = Me.MapName + ".scr"
    '    'LoadTilText.Text = Me.TilesetsName + ".til"
    'End Sub



    Private Sub LoadTilesetButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.OpenFileDialog1.DefaultExt = TilesetDocumentExtension
        Me.OpenFileDialog1.Filter = "Open Document Tileset file|*." + TilesetDocumentExtension + "|Open Document SCreen Project file|*." + ScreenDocumentExtension + "|All files|*.*"

        Me.OpenFileDialog1.FileName = Me.TilesetsName

        If Not Me.Path_Project = "" Then
            Me.OpenFileDialog1.InitialDirectory = Me.Path_Project
        End If

        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadTileset(OpenFileDialog1.FileName)
        End If
    End Sub



    Private Sub LoadMapButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.OpenFileDialog1.DefaultExt = MapDocumentExtension
        Me.OpenFileDialog1.Filter = "Open Document Map file|*." + MapDocumentExtension + "|Open Document SCreen Project file|*." + ScreenDocumentExtension + "|All files|*.*"

        Me.OpenFileDialog1.FileName = Me.MapName

        If Not Me.Path_Project = "" Then
            Me.OpenFileDialog1.InitialDirectory = Me.Path_Project
        End If

        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadMap(OpenFileDialog1.FileName)
        End If

    End Sub



    Private Sub SaveMapButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.SaveFileDialog1.DefaultExt = MapDocumentExtension
        Me.SaveFileDialog1.Filter = "Open Document Map file|*." + MapDocumentExtension + "|Open Document SCreen Project file|*." + ScreenDocumentExtension + "|All files|*.*"

        Me.SaveFileDialog1.FileName = Me.MapName

        If Not Me.Path_Project = "" Then
            Me.SaveFileDialog1.InitialDirectory = Me.Path_Project
        End If

        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            SaveMap(SaveFileDialog1.FileName)
            Me.Path_Project = Path.GetDirectoryName(SaveFileDialog1.FileName)
        End If
    End Sub



    Private Sub SaveTilesetsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.SaveFileDialog1.DefaultExt = TilesetDocumentExtension
        Me.SaveFileDialog1.Filter = "Open Document Map file|*." + TilesetDocumentExtension + "|Open Document SCreen Project file|*." + ScreenDocumentExtension + "|All files|*.*"

        Me.SaveFileDialog1.FileName = Me.TilesetsName

        If Not Me.Path_Project = "" Then
            Me.SaveFileDialog1.InitialDirectory = Me.Path_Project
        End If

        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            SaveTilesets(SaveFileDialog1.FileName)
            Me.Path_Project = Path.GetDirectoryName(SaveFileDialog1.FileName)
        End If
    End Sub



    Private Sub ProjectInfoButton_Click(sender As Object, e As EventArgs) Handles ProjectInfoButton.Click
        SetProjectInfo()
    End Sub



    Private Sub AboutButton_Click(sender As Object, e As EventArgs) Handles AboutButton.Click
        ShowAbout(False)
    End Sub



    Private Sub LoadProjectButton_Click(sender As Object, e As EventArgs) Handles LoadProjectButton.Click
        LoadProjectDialog()
    End Sub



    Private Sub mainWindow_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragDrop
        Dim tmpstr() As String = e.Data.GetData("FileDrop", False)
        Dim filePath As String = tmpstr(0)
        Dim extension As String = Path.GetExtension(filePath).ToLower

        Dim result As Boolean = False

        If extension = ".png" Then 'extension = ".gif" Or
            result = LoadBitmap(filePath)
        ElseIf extension = ".sc2" Then
            result = LoadMSXBasicGraphics(filePath)

        ElseIf extension = "." + RLEWB.Extension Then

            result = LoadRLEWB(0, filePath) ' <<<<------------------------------------------------------ TEST!

        End If

        If result = True Then

            InitInfoData(filePath)

        End If

    End Sub



    Private Function LoadRLEWB(filepath As String, VRAMaddr As Short) As Boolean

        Dim packer = New RLEWB

        Dim aStream As System.IO.FileStream
        Dim aFile = New System.IO.FileInfo(filepath)

        Dim aFileData() As Byte
        Dim newData() As Byte

        Dim tamanyo As Integer = CInt(aFile.Length)

        ReDim aFileData(tamanyo - 1)

        aStream = New System.IO.FileStream(filepath, FileMode.Open)
        aStream.Read(aFileData, 0, tamanyo)
        aStream.Close()

        newData = packer.Decompress(aFileData)

        Me.TMS9918Aviewer.SetBlock(VRAMaddr, newData)
        Me.TMS9918Aviewer.RefreshScreen()

        Return True

    End Function



    Private Sub mainWindow_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub



    Private Sub LoadProjectDialog()

        Me.OpenFileDialog1.Filter = "All files|*." + Extension_Project + ";*.prj;*.sc*;*.png;|" + My.Application.Info.Title + " Project file|*." + Extension_Project + "|nMSXtiles Project file|*.prj" + "|MSX Basic Graphics file|*.sc*" + "|PNG documents|*.png"

        Me.OpenFileDialog1.FileName = ""

        If Me.Path_Project = "" Then
            Me.OpenFileDialog1.InitialDirectory = Application.StartupPath
            'If PicturePath = "" Then
            '    Me.OpenFileDialog1.InitialDirectory = Application.StartupPath
            'Else
            '    Me.OpenFileDialog1.InitialDirectory = Path.GetDirectoryName(Me.PicturePath)
            'End If
        Else
            Me.OpenFileDialog1.InitialDirectory = Path.GetDirectoryName(Me.Path_Project)
        End If

        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadFile(OpenFileDialog1.FileName)
            'If LoadProject(OpenFileDialog1.FileName) Then
            '    Me.Path_Project = OpenFileDialog1.FileName
            '    SetTitle(Path.GetFileName(Me.Path_Project))
            '    'EnableGUI(True)
            'End If
        End If

    End Sub




    Private Function LoadFile(ByVal filePath As String) As Boolean

        Dim result As Boolean = True

        Dim anExtension As String = Path.GetExtension(filePath).ToUpper

        If File.Exists(filePath) Then

            Select Case anExtension
                Case ".PNG"  'Bitmap
                    result = LoadBitmap(filePath)

                Case ".SC2", ".SC4" ' MSX Basic Binary ".SC0", ".SC1",
                    result = LoadMSXBasicGraphics(filePath)

                Case "." + Extension_Project

                    result = LoadData(filePath)


                    'If LoadProject(filePath) Then
                    '    Me.ProjectPath = filePath
                    '    SetTitle(Path.GetFileName(Me.ProjectPath))
                    '    EnableGUI(True)
                    'End If

                Case ".PRJ"
                    result = LoadNMSXtilesProject(filePath)



                Case Else
                    result = False

            End Select

        End If


        If result = True Then

            InitInfoData(filePath)

        End If


        Return result

    End Function



    Private Sub InitInfoData(filePath As String)
        Me.Info.Clear()
        Me.Info.Name = Path.GetFileNameWithoutExtension(filePath)
        Me.ProjectNameTextBox.Text = Me.Info.Name
        Me.Filename_Project = Path.GetFileName(filePath)
        SetTitle(Me.Filename_Project)
        Me.Path_Project = Path.GetDirectoryName(filePath)
    End Sub



    ''' <summary>
    ''' Load a MSX Basic binary file and convert to a tMSgfX project
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function LoadMSXBasicGraphics(ByVal filePath As String) As Boolean

        Dim result As Boolean = True
        'Dim prjname As String = Path.GetFileNameWithoutExtension(filePath)

        Dim vramdata As Byte()

        Dim BASICbinaryIO As New MSXBasicGraphicsFileIO

        Me.Progress.ShowProgressWin()

        Try

            Me.TMS9918Aviewer.Clear()

            vramdata = BASICbinaryIO.BLOAD(filePath)

            Me.TMS9918Aviewer.SetBlock(0, vramdata)
            Me.TMS9918Aviewer.Optimize()
            Me.TMS9918Aviewer.RefreshScreen()

        Catch ex As Exception
            result = False
        End Try

        Me.Progress.CloseProgressWin()

        Return result

    End Function



    Private Function LoadBitmap(ByVal filePath As String) As Boolean

        Dim result As Boolean = True
        'Dim prjname As String = Path.GetFileNameWithoutExtension(filePath)

        'Dim _bitmapConverterDialog = New BitmapConverterDialog

        Me.Progress.ShowProgressWin()

        Try

            Dim newImage As Image = Image.FromFile(filePath)
            Me.myBitmapImage = New Bitmap(newImage, 256, 192)
            newImage.Dispose() 'para que no bloquee el fichero

            ConvertBitmap()

        Catch ex As Exception
            result = False
            'MsgBox("Disk I/O error.", MsgBoxStyle.Critical, "Error")
        End Try

        Me.Progress.CloseProgressWin()

        Return result

    End Function


    'Private Sub LoadNMSXTILESprojectBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadNMSXTILESprojectBut.Click

    '    Me.OpenFileDialog1.DefaultExt = "prj"
    '    Me.OpenFileDialog1.Filter = "nMSXtiles Project file|*.prj"

    '    Me.OpenFileDialog1.FileName = ProjectFileName

    '    If Not Me.Path_nMSXtilesProject = "" Then
    '        Me.OpenFileDialog1.InitialDirectory = Me.Path_nMSXtilesProject
    '    End If

    '    If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '        LoadNMSXtilesProject(OpenFileDialog1.FileName)
    '        Me.Path_nMSXtilesProject = Path.GetDirectoryName(OpenFileDialog1.FileName)
    '        Me.ProjectFileName = Path.GetFileNameWithoutExtension(OpenFileDialog1.FileName)
    '    End If

    'End Sub


    Private Sub ConvertBitmap()

        Dim screenVRAM(16383) As Byte

        Dim BitmapConverter As New SimpleBitmapConverter

        screenVRAM = BitmapConverter.GetScreenFromBitmap(Me.myBitmapImage) ', Me.PictureBGColorButton.SelectedColor)

        'Me.TMS9918Aviewer.Clear() 'Initialize()
        Me.TMS9918Aviewer.ScreenMode = iVDP.SCREEN_MODE.G2
        'Me.TMS9918Aviewer.PaletteType = TMS9918A.MSXVDP.TMS9918
        'Me.TMS9918Aviewer.BackgroundColor = Me.PictureBGColorButton.SelectedColor
        Me.TMS9918Aviewer.SetBlock(0, screenVRAM)
        Me.TMS9918Aviewer.Optimize()
        Me.TMS9918Aviewer.SetOrderMap()
        Me.TMS9918Aviewer.RefreshScreen()

    End Sub



    Private Sub HoriTAB1_TabChanged(index As HoriTAB.TAB_NAME) Handles HoriTAB1.TabChanged

        SetGUImode(index)

    End Sub


    Private Sub SetGUImode(index As HoriTAB.TAB_NAME)

        Dim OptimizeButton_enabled As Boolean = False
        Dim TilesOrderButton_enabled As Boolean = False
        Dim FillMapButton_enabled As Boolean = False
        Dim SelectAreaButton_enabled As Boolean = True
        Dim SwitchButton_enabled As Boolean = True
        Dim SwapButton_enabled As Boolean = True

        Dim DataInput_enabled As Boolean = False

        Dim AreaPanel_Visible As Boolean = False
        Dim DataDefinitionPanel_Visible As Boolean = False

        Dim spriteModes As Boolean = False

        AreaStartX_TextBox.Text = "0"
        AreaStartY_TextBox.Text = "0"
        AreaEndX_TextBox.Text = "31"
        AreaEndY_TextBox.Text = "23"

        Bloq_Label.Text = "Tile"
        Bloq_Label.Visible = True
        BloqValue_Label.Visible = True

        Select Case index
            Case HoriTAB.TAB_NAME.SCREEN
                Me.TMS9918Aviewer.SetView(TMS9918A.VIEW_MODE.ALL)
                SelectAreaButton_enabled = False
                'OptimizeButton_enabled = True
                TilesOrderButton_enabled = True
                FillMapButton_enabled = True

            Case HoriTAB.TAB_NAME.MAP
                Me.TMS9918Aviewer.SetView(TMS9918A.VIEW_MODE.MAP)
                TilesOrderButton_enabled = True
                FillMapButton_enabled = True
                'AreaEndX_TextBox.Text = "31"
                'AreaEndY_TextBox.Text = "23"
                AreaPanel_Visible = True

                SwitchButton.ToolTipText = "Switch Tiles"
                SwapButton.ToolTipText = "Swap Tiles"

            Case HoriTAB.TAB_NAME.TILESET
                Me.TMS9918Aviewer.SetView(TMS9918A.VIEW_MODE.TILESET)
                'AreaEndX_TextBox.Text = "255"
                'AreaEndY_TextBox.Text = "191"
                OptimizeButton_enabled = True
                AreaPanel_Visible = True
                DataDefinitionPanel_Visible = True
                'TileRangeStart_TextBox.Text = "0"
                'TileRangeEnd_TextBox.Text = "255"
                SwitchButton.ToolTipText = "Switch Colors"
                SwapButton.ToolTipText = "Swap Colors"

                DataInput_enabled = True

            Case HoriTAB.TAB_NAME.SPRITESET
                Me.TMS9918Aviewer.SetView(TMS9918A.VIEW_MODE.SPRITE_PATTERNS)
                SelectAreaButton_enabled = False
                SwapButton_enabled = False
                SwitchButton_enabled = False

                DataDefinitionPanel_Visible = True

                spriteModes = True

                'DataInput_enabled = True
                Bloq_Label.Text = "Sprite"

            Case HoriTAB.TAB_NAME.OAM
                Me.TMS9918Aviewer.SetView(TMS9918A.VIEW_MODE.SPRITE_LAYERS)
                SelectAreaButton_enabled = False
                SwapButton_enabled = False
                SwitchButton_enabled = False

                spriteModes = True

                Bloq_Label.Visible = False
                BloqValue_Label.Visible = False

        End Select

        SelectAreaGroupBox.Visible = AreaPanel_Visible
        'TileRangePanel.Visible = TileRangePanel_Visible
        DataDefinitionPanel.Visible = DataDefinitionPanel_Visible

        DataLabel.Visible = DataInput_enabled
        DataComboBox.Visible = DataInput_enabled

        OptimizeButton.Enabled = OptimizeButton_enabled
        TilesOrderButton.Enabled = TilesOrderButton_enabled
        FillMapButton.Enabled = FillMapButton_enabled
        SwitchButton.Enabled = SwitchButton_enabled
        SwapButton.Enabled = SwapButton_enabled
        SelectAreaButton.Enabled = SelectAreaButton_enabled

        If spriteModes = True Then
            Colors_Label.Text = ""
            ColorInkLabel.Text = ""
            ColorBGLabel.Text = ""
            ColorInkLabel.BackColor = Color.Transparent
            ColorBGLabel.BackColor = Color.Transparent
        Else
            Colors_Label.Text = "Colors"
        End If

    End Sub



    Private Sub TMS9918Aviewer_MouseScreenData(x As Integer, y As Integer) Handles TMS9918Aviewer.MouseScreenData

        Dim vaddr As Integer

        Dim column As Integer
        Dim line As Integer

        Dim color As Byte
        Dim colorInk As Byte
        Dim colorBG As Byte

        Dim nTile As Byte

        Dim charWidth As Integer = 8

        If Me.TMS9918Aviewer.ScreenMode = iVDP.SCREEN_MODE.T1 Then
            charWidth = 6
        Else
            charWidth = 8
        End If

        PosX_Label.Text = CStr(x)
        PosY_Label.Text = CStr(y)

        column = Fix(x / charWidth)
        line = Fix(y / 8)

        If Me.TMS9918Aviewer.ScreenMode = iVDP.SCREEN_MODE.T1 Then
            If column > 39 Then
                column = 39
            End If
        Else
            If column > 31 Then
                column = 31
            End If
        End If

        If line > 23 Then
            line = 23
        End If

        ColumnLabel.Text = CStr(column)
        LineLabel.Text = CStr(line)




        If Me.TMS9918Aviewer.ViewMode = TMS9918A.VIEW_MODE.SPRITE_PATTERNS Then


            If Me.TMS9918Aviewer.SpriteSize = 8 Then

                If line < 8 Then

                    nTile = (line * 32) + column
                    BloqValue_Label.Text = CStr(nTile)

                Else
                    BloqValue_Label.Text = ""
                End If

            Else

                If line < 8 Then

                    nTile = (Fix(line / 2) * 16) + Fix(column / 2)
                    BloqValue_Label.Text = CStr(nTile)
                Else
                    BloqValue_Label.Text = ""
                End If

            End If



        ElseIf Not Me.TMS9918Aviewer.ViewMode = TMS9918A.VIEW_MODE.SPRITE_LAYERS Then

            If Me.TMS9918Aviewer.ViewMode = TMS9918A.VIEW_MODE.TILESET Then
                Dim bankline As Integer = line - (Fix(line / 8) * 8)
                nTile = (bankline * 32) + column

            Else
                vaddr = iVDP.TableBase.GRPNAM + (line * 32) + column
                nTile = TMS9918Aviewer.VPEEK(vaddr)
            End If

            BloqValue_Label.Text = CStr(nTile)

            vaddr = (nTile * 8) + (Fix(y / 64) * &H800) + (y - (Fix(y / 8) * 8))
            color = TMS9918Aviewer.VPEEK(vaddr + iVDP.TableBase.GRPCOL)
            colorInk = (color And 240) / 16
            colorBG = color And 15

            ColorInkLabel.BackColor = TMS9918Aviewer.Palette.GetRGBColor(colorInk)
            If ColorInkLabel.BackColor.GetBrightness > 0.65 Then
                ColorInkLabel.ForeColor = Drawing.Color.Black
            Else
                ColorInkLabel.ForeColor = Drawing.Color.White
            End If
            ColorInkLabel.Text = CStr(colorInk)

            ColorBGLabel.BackColor = TMS9918Aviewer.Palette.GetRGBColor(colorBG)
            If ColorBGLabel.BackColor.GetBrightness > 0.65 Then
                ColorBGLabel.ForeColor = Drawing.Color.Black
            Else
                ColorBGLabel.ForeColor = Drawing.Color.White
            End If
            ColorBGLabel.Text = CStr(colorBG)

        End If


    End Sub



    Private Sub OptimizeButton_Click(sender As Object, e As EventArgs) Handles OptimizeButton.Click
        'Me.screen2.Optimize()

        'optimization has occurred successfully
        MsgBox("Optimization has occurred successfully.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Optimization")
    End Sub

    Private Sub TilesOrderButton_Click(sender As Object, e As EventArgs) Handles TilesOrderButton.Click
        Dim result As DialogResult

        '"This option will delete all data." + Chr(13) +
        result = MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Question")

        If result = Windows.Forms.DialogResult.Yes Then
            Me.TMS9918Aviewer.SetOrderMap()
            Me.TMS9918Aviewer.RefreshScreen()
        End If
    End Sub

    Private Sub FillMapButton_Click(sender As Object, e As EventArgs) Handles FillMapButton.Click

    End Sub

    Private Sub SwitchTilesButton_Click(sender As Object, e As EventArgs) Handles SwitchButton.Click

    End Sub

    Private Sub SwapTilesButton_Click(sender As Object, e As EventArgs) Handles SwapButton.Click
        Try
            '
            Dim result As DialogResult

            Dim toolChangeTiles As New ChangeTilesForm()
            result = toolChangeTiles.ShowDialog()

            If result = Windows.Forms.DialogResult.OK Then
                ChangeTiles(toolChangeTiles.SourceTile, toolChangeTiles.TargetTile)
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub SwitchColorsButton_Click(sender As Object, e As EventArgs)
        Try
            Dim result As DialogResult

            Dim toolChangeColor As New ChangeColorForm(Me.TMS9918Aviewer.Palette)
            result = toolChangeColor.ShowDialog()

            If result = Windows.Forms.DialogResult.OK Then
                ChangeColor(toolChangeColor.OldColor, toolChangeColor.NewColor)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SwapColorsButton_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SelectAreaButton_Click(sender As Object, e As EventArgs) Handles SelectAreaButton.Click
        If TMS9918Aviewer.ViewMode = TMS9918A.VIEW_MODE.MAP Or TMS9918Aviewer.ViewMode = TMS9918A.VIEW_MODE.TILESET Then
            TMS9918Aviewer.ControlType = TMS9918A.CONTROL_TYPE.SELECTER
        End If
    End Sub

    Private Sub EditPaleteButton_Click(sender As Object, e As EventArgs) Handles EditPaleteButton.Click
        EditPalette()
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click

    End Sub

    Private Sub UndoButton_Click(sender As Object, e As EventArgs) Handles UndoButton.Click

    End Sub


    Private Sub GivemeTheCodeButton_Click(sender As Object, e As EventArgs) Handles GivemeTheCodeButton.Click
        genData()
    End Sub


    Private Sub genData()

        Dim _outputText As String = ""

        Dim comments As New ArrayList

        comments.Add(My.Application.Info.ProductName + " v" + My.Application.Info.Version.ToString)
        comments.Add("File: " + Me.Filename_Project)

        _outputText = Me.aMSXDataFormat.GetComments(comments, Me.DataTypeInput.CodeLanguage)  ' <<<----------------------  NO TIENE PARA BASIC!!!

        Select Case HoriTAB1.SelectTab
            Case HoriTAB.TAB_NAME.SCREEN
                _outputText += GetScreenData()
                _outputText += vbNewLine

            Case HoriTAB.TAB_NAME.MAP
                _outputText += GetMapData()
                _outputText += vbNewLine

            Case HoriTAB.TAB_NAME.TILESET
                ' tileset
                _outputText += GetTilesetData()
                _outputText += vbNewLine

            Case HoriTAB.TAB_NAME.SPRITESET
                _outputText += GetSpritesetData()
                _outputText += vbNewLine

            Case HoriTAB.TAB_NAME.OAM
                _outputText += GetOAMData()
                _outputText += vbNewLine

        End Select


        OutputText.Text = _outputText

    End Sub




    Private Function GetScreenData() As String

        Dim _outputText As String

        Dim data As Byte()
        Dim newData As Byte()

        data = Me.TMS9918Aviewer.GetVRAM

        newData = GetCompressData(data)
        _outputText = GetFormatData(Me.Info.Name_without_Spaces + "_SCR", newData, "All VRAM data", data.Length)

        Me.outputCompressData.Clear()
        Me.outputCompressData.AddRange(newData)
        Me.outputCompressData_Type = DATA_TYPE.SCREEN
        Me.outputCompressData_CompressType = Me.DataTypeInput.Compress
        Me.outputCompressData_suffix = DataType_Suffix(Me.outputCompressData_Type) + Compress_Suffix(Me.DataTypeInput.Compress)

        Return _outputText

    End Function


    Private Function GetMapData() As String

        Dim _outputText As String = ""

        Dim data As Byte()
        Dim newData As Byte()

        data = Me.TMS9918Aviewer.GetBlock(iVDP.TableBase.GRPNAM, iVDP.TableBaseSize.GRPNAM)

        newData = GetCompressData(data)
        _outputText = GetFormatData(Me.Info.Name_without_Spaces + "_MAP", newData, "Map data", data.Length)

        Me.outputCompressData.Clear()
        Me.outputCompressData.AddRange(newData)
        Me.outputCompressData_Type = DATA_TYPE.MAP
        Me.outputCompressData_CompressType = Me.DataTypeInput.Compress
        Me.outputCompressData_suffix = DataType_Suffix(Me.outputCompressData_Type) + Compress_Suffix(Me.DataTypeInput.Compress)

        Return _outputText

    End Function



    Private Function GetTilesetData() As String

        Dim _outputText As String = ""

        Dim area_startX As Integer = CInt(AreaStartX_TextBox.Text)
        Dim area_startY As Integer = CInt(AreaStartY_TextBox.Text)

        Dim area_endX As Integer = CInt(AreaEndX_TextBox.Text)
        Dim area_endY As Integer = CInt(AreaEndY_TextBox.Text)

        Dim fullScreen As Integer = ((area_endY + 1) - area_startY) * ((area_endX + 1) - area_startX)

        If fullScreen < (32 * 24) Then
            ' area

            If DataComboBox.SelectedIndex = 0 Then
                _outputText = GetGFXareaData(TILESET_TYPE.PATTERN, area_startX, area_startY, area_endX, area_endY)
            Else
                _outputText = GetGFXareaData(TILESET_TYPE.COLOR, area_startX, area_startY, area_endX, area_endY)
            End If

        Else
            'full screen

            If DataComboBox.SelectedIndex = 0 Then
                _outputText = GetTilesetData(TILESET_TYPE.PATTERN, TilesetComboBox.SelectedIndex)
            Else
                _outputText = GetTilesetData(TILESET_TYPE.COLOR, TilesetComboBox.SelectedIndex)
            End If

        End If

        Return _outputText

    End Function



    Private Function GetGFXareaData(datatype As TILESET_TYPE, area_startX As Integer, area_startY As Integer, area_endX As Integer, area_endY As Integer) As String

        Dim _outputText As String = ""

        Dim comment1 As String
        Dim label_suffix As String

        Dim data As Byte()
        Dim newData As Byte()

        Dim VRAMaddr As Integer
        Dim VRAMtable As Integer

        Dim bloqsize As Integer = (area_endX - area_startX) * 8

        If datatype = TILESET_TYPE.PATTERN Then
            VRAMtable = iVDP.TableBase.GRPCGP
            comment1 += " Pattern data"
            label_suffix = "_PAT"
        Else
            VRAMtable = iVDP.TableBase.GRPCOL
            comment1 = " Color data"
            label_suffix = "_COL"
        End If

        For line As Integer = area_startY To area_endY

            VRAMaddr = line * 256 + (area_startX * 8)

            data = Me.TMS9918Aviewer.GetBlock(VRAMtable + VRAMaddr, bloqsize)

            newData = GetCompressData(data)
            _outputText += GetFormatData(Me.Info.Name_without_Spaces + label_suffix + CStr(line).PadLeft(2, "0"c), newData, "Line " + CStr(line).PadLeft(2, "0"c) + comment1, data.Length)
        Next

        Return _outputText

    End Function



    Private Function GetTilesetData(datatype As TILESET_TYPE, tilesetBANK As Integer) As String

        Dim _outputText As String = ""

        Dim comment1 As String

        Dim label_suffix As String

        Dim data As Byte()
        Dim newData As Byte()

        Dim VRAMaddr As Integer
        Dim bloqsize As Integer


        If datatype = TILESET_TYPE.PATTERN Then
            VRAMaddr = iVDP.TableBase.GRPCGP
            comment1 = "Tileset Pattern data " + tilesetBANK_Labels(tilesetBANK)
            label_suffix = "_PAT" + tileset_pattern_BANK_Suffix(tilesetBANK)
        Else
            VRAMaddr = iVDP.TableBase.GRPCOL
            comment1 = "Tileset Color data " + tilesetBANK_Labels(tilesetBANK)
            label_suffix = "_COL" + tileset_color_BANK_Suffix(tilesetBANK)
        End If


        If tilesetBANK = 0 Then
            ' All Banks
            bloqsize = &H1800
        Else
            ' One Bank
            VRAMaddr += ((tilesetBANK - 1) * &H800)
            bloqsize = &H800
        End If

        data = Me.TMS9918Aviewer.GetBlock(VRAMaddr, bloqsize)

        newData = GetCompressData(data)

        Me.outputCompressData.Clear()
        Me.outputCompressData.AddRange(newData)
        Me.outputCompressData_Type = DATA_TYPE.TILESET
        Me.outputCompressData_CompressType = Me.DataTypeInput.Compress
        Me.outputCompressData_suffix = DataType_Suffix(Me.outputCompressData_Type) + label_suffix + Compress_Suffix(Me.DataTypeInput.Compress)

        _outputText = GetFormatData(Me.Info.Name_without_Spaces + label_suffix, newData, comment1, data.Length)

        Return _outputText

    End Function



    'Private Function GetColorData() As String

    '    Dim comment1 As String
    '    Dim comment2 As String = ""

    '    Dim _outputText As String = ""

    '    Dim data As Byte()
    '    Dim newData As Byte()

    '    data = Me.TMS9918Aviewer.GetBlock(iVDP.TableBase.GRPCOL, &H1800)

    '    comment1 = "Tileset Color data"

    '    newData = GetCompressData(data)
    '    _outputText = GetFormatData(Me.Info.Name_without_Spaces + "_COL", newData, comment1, comment2, data.Length)

    '    Me.outputColorData.Clear()
    '    Me.outputColorData.AddRange(newData)

    '    Return _outputText

    'End Function



    Private Function GetSpritesetData() As String

        Dim _outputText As String = ""

        Dim data As Byte()
        Dim newData As Byte()

        data = Me.TMS9918Aviewer.GetBlock(iVDP.TableBase.GRPPAT, iVDP.TableBaseSize.GRPPAT)

        newData = GetCompressData(data)
        _outputText = GetFormatData(Me.Info.Name_without_Spaces + "_SPR", newData, "Spriteset Patterns data", data.Length)

        Me.outputCompressData.Clear()
        Me.outputCompressData.AddRange(newData)
        Me.outputCompressData_Type = DATA_TYPE.SPRITESET
        Me.outputCompressData_CompressType = Me.DataTypeInput.Compress
        Me.outputCompressData_suffix = DataType_Suffix(Me.outputCompressData_Type) + Compress_Suffix(Me.DataTypeInput.Compress)

        Return _outputText

    End Function



    Private Function GetOAMData() As String

        Dim _outputText As String = ""

        Dim data As Byte()
        Dim newData As Byte()

        data = Me.TMS9918Aviewer.GetBlock(iVDP.TableBase.GRPATR, iVDP.TableBaseSize.GRPATR)

        newData = GetCompressData(data)
        _outputText = GetFormatData(Me.Info.Name_without_Spaces + "_OAM", newData, "OAM data", data.Length)

        Me.outputCompressData.Clear()
        Me.outputCompressData.AddRange(newData)
        Me.outputCompressData_Type = DATA_TYPE.OAM
        Me.outputCompressData_CompressType = Me.DataTypeInput.Compress
        Me.outputCompressData_suffix = DataType_Suffix(Me.outputCompressData_Type) + Compress_Suffix(Me.DataTypeInput.Compress)

        Return _outputText

    End Function



    Private Function GetFormatData(ByVal dataname As String, ByVal data As Byte(), ByVal aComment As String, ByVal originalLength As Integer) As String

        Dim outputSource As String = ""
        Dim comments As New ArrayList

        'comments.Add(My.Application.Info.ProductName + " v" + My.Application.Info.Version.ToString)
        'comments.Add("File: " + Me.Filename_Project)

        If Not aComment = "" Then
            comments.Add(aComment)
        End If


        Select Case Me.DataTypeInput.Compress

            Case iCompressEncoder.COMPRESS_TYPE.RLE
                comments.Add("RLE compressed - Original size= " + CStr(originalLength) + " - Compress size= " + CStr(data.Length))

            Case iCompressEncoder.COMPRESS_TYPE.RLEWB
                comments.Add("RLE WB compressed - Original size= " + CStr(originalLength) + " - Compress size= " + CStr(data.Length))

            Case iCompressEncoder.COMPRESS_TYPE.PLETTER
                comments.Add("Pletter compressed - Original size:" + CStr(originalLength) + " - Compress size:" + CStr(data.Length))

            Case Else
                comments.Add("Size= " + CStr(data.Length))

        End Select

        'comments.Add("RLE WB compressed - Original size= " + CStr(originalLength) + " - Compress size= " + CStr(data.Length) + " (" + CStr(Math.Round((data.Length / (originalLength / 100)), 2, MidpointRounding.ToEven)) + "%)")


        ' show data in respective code language
        Select Case Me.DataTypeInput.CodeLanguage
            Case DataFormat.ProgrammingLanguage.C
                outputSource = Me.aMSXDataFormat.GetCcode(data, Me.DataTypeInput.SizeLine, Me.DataTypeInput.NumeralSystem, dataname, comments, Me.AppConfig.lastCByteCommand)

            Case DataFormat.ProgrammingLanguage.ASSEMBLER
                outputSource = Me.aMSXDataFormat.GetAssemblerCode(data, Me.DataTypeInput.SizeLine, Me.DataTypeInput.NumeralSystem, dataname, comments, "<tab>DB") 'Me.AppConfig.lastAsmByteCommand)

            Case DataFormat.ProgrammingLanguage.BASIC
                outputSource = Me.aMSXDataFormat.GetBASICcode(data, Me.DataTypeInput.SizeLine, Me.DataTypeInput.NumeralSystem, Me.DataTypeInput.BASICremoveZeros, Me.DataTypeInput.BASIClineNumber, Me.DataTypeInput.BASICInterval, comments)
        End Select


        Return outputSource

    End Function



    Private Function GetCompressData(ByVal data As Byte()) As Byte()

        Dim outputSource As String = ""

        Dim outputData As Byte()

        Dim packer As iCompressEncoder


        If Me.DataTypeInput.Compress = iCompressEncoder.COMPRESS_TYPE.RAW Then

            outputData = data

        Else

            Select Case Me.DataTypeInput.Compress

                Case iCompressEncoder.COMPRESS_TYPE.RLEWB
                    packer = New RLEWB

                Case iCompressEncoder.COMPRESS_TYPE.PLETTER
                    packer = New Pletter

                Case Else
                    packer = New RLE

            End Select

            outputData = packer.Compress(data)

        End If

        Return outputData

    End Function



    Public Sub SaveBinary(ByVal filePath As String)

        Dim aStream As System.IO.FileStream

        'Try

        If Me.outputCompressData.Count > 0 Then

            Dim patternData() As Byte = CType(Me.outputCompressData.ToArray(GetType(Byte)), Byte())

            aStream = New System.IO.FileStream(filePath, IO.FileMode.Create)
            aStream.Write(patternData, 0, patternData.Length)
            aStream.Close()

        Else

            ' Nothing que grabar!

        End If

        'Catch ex As Exception

        'End Try

    End Sub



    Public Sub SaveMSXBASICbinary(ByVal filepath As String)

        Dim saveMSXBbin As New MSXBasicGraphicsFileIO

        Dim VRAMaddr As Integer
        Dim bloqsize As Integer

        Dim new_filepath As String = Path.GetFileNameWithoutExtension(filepath)
        Dim new_suffix As String = ""
        Dim new_filepath_extension As String = Path.GetExtension(filepath)
        Dim new_screenmode As iVDP.SCREEN_MODE = 0
        Dim new_spritesize As iVDP.SPRITE_SIZE = 0


        Dim data As Byte()

        Select Case HoriTAB1.SelectTab

            Case HoriTAB.TAB_NAME.MAP
                VRAMaddr = iVDP.TableBase.GRPNAM
                bloqsize = iVDP.TableBaseSize.GRPNAM
                new_suffix = "_MAP"
                'data = Me.TMS9918Aviewer.GetBlock(VRAMaddr, iVDP.TableBaseSize.GRPNAM)
                'saveMSXBbin.BSAVE(filepath, iVDP.TableBase.GRPNAM, data, 0, 0)

            Case HoriTAB.TAB_NAME.TILESET
                ' tileset

                Dim tilesetBANK As Integer = TilesetComboBox.SelectedIndex

                new_screenmode = iVDP.SCREEN_MODE.G2

                If tilesetBANK = 0 Then
                    ' All Banks
                    bloqsize = &H1800
                Else
                    ' One Bank
                    bloqsize = &H800
                End If

                If DataComboBox.SelectedIndex = 0 Then
                    'patterns
                    VRAMaddr = iVDP.TableBase.GRPCGP + ((tilesetBANK - 1) * &H800)
                    new_suffix = "_PAT" + tileset_pattern_BANK_Suffix(tilesetBANK)

                    'data = Me.TMS9918Aviewer.GetBlock(VRAMaddr, bloqsize)
                    'saveMSXBbin.BSAVE(filepath, VRAMaddr, data, iVDP.SCREEN_MODE.G2, 0)

                Else
                    'colors
                    VRAMaddr = iVDP.TableBase.GRPCOL + ((tilesetBANK - 1) * &H800)
                    new_suffix = "_COL" + tileset_color_BANK_Suffix(tilesetBANK)

                    'data = Me.TMS9918Aviewer.GetBlock(VRAMaddr, bloqsize)
                    'saveMSXBbin.BSAVE(filepath, VRAMaddr, data, iVDP.SCREEN_MODE.G2, 0)

                End If

            Case HoriTAB.TAB_NAME.SPRITESET
                VRAMaddr = iVDP.TableBase.GRPPAT
                bloqsize = iVDP.TableBaseSize.GRPPAT
                new_suffix = "_SPR"

                'data = Me.TMS9918Aviewer.GetBlock(iVDP.TableBase.GRPPAT, iVDP.TableBaseSize.GRPPAT)
                'saveMSXBbin.BSAVE(filepath, iVDP.TableBase.GRPPAT, data, 0, iVDP.SPRITE_SIZE.SIZE16)

            Case HoriTAB.TAB_NAME.OAM
                VRAMaddr = iVDP.TableBase.GRPATR
                bloqsize = iVDP.TableBaseSize.GRPATR
                new_suffix = "_OAM"
                'data = Me.TMS9918Aviewer.GetBlock(VRAMaddr, iVDP.TableBaseSize.GRPATR)
                'saveMSXBbin.BSAVE(filepath, iVDP.TableBase.GRPATR, data, new_screenmode, 0)

            Case Else 'HoriTAB.TAB_NAME.SCREEN
                VRAMaddr = 0
                bloqsize = &H4000
                new_screenmode = iVDP.SCREEN_MODE.G2
                new_spritesize = iVDP.SPRITE_SIZE.SIZE16
                'data = Me.TMS9918Aviewer.GetVRAM
                'saveMSXBbin.BSAVE(filepath, 0, data, 0, 0)

        End Select

        data = Me.TMS9918Aviewer.GetBlock(VRAMaddr, bloqsize)
        saveMSXBbin.BSAVE(new_filepath + new_suffix + new_filepath_extension, VRAMaddr, data, new_screenmode, new_spritesize)

    End Sub


    Private Sub CopyAllButton_Click(sender As Object, e As EventArgs) Handles CopyAllButton.Click

    End Sub

    Private Sub SaveSourceButton_Click(sender As Object, e As EventArgs) Handles SaveSourceButton.Click

    End Sub

    Private Sub SaveBinaryButton_Click(sender As Object, e As EventArgs) Handles SaveBinaryButton.Click
        SaveBinaryDialog()
    End Sub

    Private Sub SaveSCProjectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveSCProjectButton.Click
        SaveProjectDialog()
    End Sub

    Private Sub SaveNMSXprj_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveNMSXprj_Button.Click
        SaveNMSXprj_Dialog()
    End Sub

    Private Sub SaveSC2But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveSC2But.Click
        SaveMSXBASICbinaryDialog()
    End Sub

    Private Sub SavePNGBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SavePNGBut.Click
        SavePNG_Dialog()
    End Sub



    Private Sub SaveProjectDialog()
        Me.SaveFileDialog1.DefaultExt = ScreenDocumentExtension
        Me.SaveFileDialog1.Filter = "Open Document SCreen Project file|*." + ScreenDocumentExtension

        Me.SaveFileDialog1.FileName = Me.Info.Name_without_Spaces

        If Me.Path_Project = "" Then
            Me.Path_Project = Application.StartupPath
        End If
        Me.SaveFileDialog1.InitialDirectory = Me.Path_Project

        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then

            SaveData(SaveFileDialog1.FileName)
            Me.Path_Project = Path.GetDirectoryName(SaveFileDialog1.FileName)
        End If

    End Sub


    Private Sub SaveMSXBASICbinaryDialog()
        Me.SaveFileDialog1.DefaultExt = "sc2"
        Me.SaveFileDialog1.Filter = "Screen2 bin file|*.sc2|VRAM bin file|*.bin|All files|*.*"

        Me.SaveFileDialog1.FileName = Me.Info.Name_without_Spaces

        If Me.Path_Project = "" Then
            Me.Path_Project = Application.StartupPath
        End If
        Me.SaveFileDialog1.InitialDirectory = Me.Path_Project

        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'Me.Path_SC2 = Path.GetDirectoryName(SaveFileDialog1.FileName)
            SaveMSXBASICbinary(SaveFileDialog1.FileName)
        End If
    End Sub



    Private Sub SaveBinaryDialog()


        Select Case Me.outputCompressData_CompressType

            Case iCompressEncoder.COMPRESS_TYPE.RLE
                Me.SaveFileDialog1.Filter = "RLE file|*." + RLE.Extension + "|All files|*.*"
                Me.SaveFileDialog1.DefaultExt = RLE.Extension

            Case iCompressEncoder.COMPRESS_TYPE.RLEWB
                Me.SaveFileDialog1.Filter = "RLEWB file|*." + RLEWB.Extension + "|All files|*.*"
                Me.SaveFileDialog1.DefaultExt = RLEWB.Extension

            Case iCompressEncoder.COMPRESS_TYPE.PLETTER
                Me.SaveFileDialog1.Filter = "Pletter file|*." + Pletter.Extension + "|All files|*.*"
                Me.SaveFileDialog1.DefaultExt = Pletter.Extension

            Case Else
                Me.SaveFileDialog1.Filter = "Binary file|*.bin" + "|All files|*.*"
                Me.SaveFileDialog1.DefaultExt = Extension_Binary

        End Select


        Me.SaveFileDialog1.FileName = Me.Info.Name_without_Spaces + Me.outputCompressData_suffix  '+ "." + Extension_Binary

        If Me.Path_Project = "" Then
            Me.Path_Project = Application.StartupPath
        End If
        Me.SaveFileDialog1.InitialDirectory = Me.Path_Project

        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            SaveBinary(SaveFileDialog1.FileName)
        End If

    End Sub


    Private Sub SaveNMSXprj_Dialog()
        Me.SaveFileDialog1.DefaultExt = "prj"
        Me.SaveFileDialog1.Filter = "nMSXtiles Project file|*.prj"

        Me.SaveFileDialog1.FileName = Me.Info.Name_without_Spaces

        If Me.Path_Project = "" Then
            Me.Path_Project = Application.StartupPath
        End If
        Me.SaveFileDialog1.InitialDirectory = Me.Path_Project

        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'SaveNMSXtilesProject(SaveFileDialog1.FileName)
            'Me.Path_nMSXtilesProject = Path.GetDirectoryName(SaveFileDialog1.FileName)
        End If
    End Sub


    Private Sub SavePNG_Dialog()

        Me.SaveFileDialog1.DefaultExt = "png"
        Me.SaveFileDialog1.Filter = "PNG file|*.png"

        Me.SaveFileDialog1.FileName = Me.Info.Name_without_Spaces + DataType_Suffix(HoriTAB1.SelectTab)

        If Me.Path_Project = "" Then
            Me.Path_Project = Application.StartupPath
        End If
        Me.SaveFileDialog1.InitialDirectory = Me.Path_Project

        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then

            SavePNG(SaveFileDialog1.FileName)

        End If

    End Sub


    Private Sub SaveSource_Dialog()

        If Me.OutputText.Text = "" Then
            MsgBox("There is nothing to save.", MsgBoxStyle.Exclamation, "Alert")
        Else

            Select Case DataTypeInput.CodeLanguage
                Case DataTypeInputControl.Language_CODE.BASIC
                    Me.SaveFileDialog1.DefaultExt = "BAS"
                    Me.SaveFileDialog1.Filter = "BASIC file|*.BAS"

                Case DataTypeInputControl.Language_CODE.C
                    Me.SaveFileDialog1.DefaultExt = "c"
                    Me.SaveFileDialog1.Filter = "C file|*.c|Header file|*.h"

                Case Else 'ASSEMBLER
                    Me.SaveFileDialog1.DefaultExt = "asm"
                    Me.SaveFileDialog1.Filter = "ASM file|*.asm|ASM file|*.s"
            End Select

            If Me.Path_Project = "" Then
                Me.Path_Project = Application.StartupPath
            End If
            Me.SaveFileDialog1.InitialDirectory = Me.Path_Project

            SaveFileDialog1.FileName = Replace(Me.Info.Name, " ", "_")

            If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then

                SaveSourceCode(SaveFileDialog1.FileName)

            End If

        End If

    End Sub


    Private Sub SaveSourceCode(ByVal filePath As String)

        Dim aStreamWriterFile As New System.IO.StreamWriter(filePath)
        aStreamWriterFile.WriteLine(Me.OutputText.Text)
        aStreamWriterFile.Close()

    End Sub



    Private Sub SavePNG(ByVal filePath As String)

        Select Case Me.TMS9918Aviewer.ViewMode
            Case TMS9918A.VIEW_MODE.TILESET
                Me.TMS9918Aviewer.SaveTilesetPNG(filePath)

            Case TMS9918A.VIEW_MODE.SPRITE_PATTERNS
                Me.TMS9918Aviewer.SaveSpritePatternsPNG(filePath)

            Case Else
                Me.TMS9918Aviewer.SaveScreenPNG(filePath)

        End Select

    End Sub



    Private Sub TMS9918Aviewer_MouseSelectedArea(start_X As Integer, start_Y As Integer, end_X As Integer, end_Y As Integer) Handles TMS9918Aviewer.MouseSelectedArea

        If TMS9918Aviewer.ViewMode = TMS9918A.VIEW_MODE.TILESET Or TMS9918Aviewer.ViewMode = TMS9918A.VIEW_MODE.MAP Then

            AreaStartX_TextBox.Text = CStr(start_X)
            AreaStartY_TextBox.Text = CStr(start_Y)
            AreaEndX_TextBox.Text = CStr(end_X)
            AreaEndY_TextBox.Text = CStr(end_Y)

        End If

    End Sub


End Class
