Imports System.IO
Imports System.Xml
Imports System.Collections

Imports System.Drawing
Imports System.Drawing.Imaging

Imports mSXdevtools.MSXLibrary


Public Class MainScreen

    'Private App_name As String = "MSX tiles Tools"
    'Private App_version As String = "0.9.5.2b (21/8/2013)"
    'last: 0.9.5.1b (11/3/2012) , 0.9.5b (23/2/2012)


    Private screenTilesData As Byte()

    Private Path_Project As String
    Private Path_SC2 As String
    Private Path_Bitmap As String
    Private Path_nMSXtilesProject As String
    'Private Path_Palettes As String

    Private ProjectFileName As String

    Private Path_Screen As String
    Private Path_Tileset As String

    Private MapName As String
    Private TilesetsName As String

    Private _ProjectName As String
    Private ProjectGroup As String
    Private ProjectVersion As String
    Private ProjectAuthor As String
    Private ProjectDescription As String
    Private ProjectStartDate As Long
    Private ProjectLastUpdate As Long

    Private Const ScreenDocumentExtension As String = "xscp"
    Private Const TilesetDocumentExtension As String = "xtil"
    Private Const MapDocumentExtension As String = "xmap"

    Private Property ProjectName() As String
        Get
            Return _ProjectName
        End Get
        Set(ByVal value As String)
            _ProjectName = value
            Me.ProjectNameTextBox.Text = value
        End Set
    End Property


    Private screenViewer As Integer = 0 ' 0 = screen, 1=tileset

    Private bite_MASKs = New Byte() {1, 2, 4, 8, 16, 32, 64, 128}


    Private genData As New MSXDataFormat

    Private BasicConfig As New BasicConfigDialog

    Private ConfigFileName As String = My.Application.Info.AssemblyName + ".config"




    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        Me.screen2.VisibleTileSets = False
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().


    End Sub



    Private Sub MainScreen_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Dim result As System.Windows.Forms.DialogResult

        SaveConfig()

        Application.DoEvents()

        'If Me.appState = APP_STATE.WORK Then

        Beep()

        result = MessageBox.Show(Me, "Are you sure you want to close " + My.Application.Info.Title + "?", "Closing Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        'result = MsgBox("Are you sure you want to close spriteSX?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Alert")

        If result = Windows.Forms.DialogResult.No Then
            e.Cancel = True 'cancela la salida de la aplicacion
        End If
        'End If

    End Sub



    Private Sub MainScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.AllBanksPanel.Location = New Point(619, 148)


        Dim result As Boolean
        result = LoadConfig()
        If Not result Then
            'Dim aLicenseWin As New LicenseWin(False, LicenseWin.LANCODE.ENG, My.Application.Info.Title, App_version + " " + App_versionDate, My.Application.Info.Copyright)
            'aLicenseWin.ShowDialog()
            ShowAbout()
        End If


        Me.Tileset_CodeOutComboB.SelectedIndex = MSXDataFormat.OutputFormat.ASM
        Me.Tileset_SizeLineComboB.SelectedIndex = 0
        'Me.dataComboB.SelectedIndex = 0

        Me.Map_SizeLineComboB.SelectedIndex = 0
        Me.Map_CodeOutComboB.SelectedIndex = MSXDataFormat.OutputFormat.ASM
        Me.Map_compressionScrCB.SelectedIndex = 0

        Me.CompressPat_ALL_CBox.SelectedIndex = 0
        Me.CompressCol_ALL_CBox.SelectedIndex = 0
        Me.Compression_PB0_CBox.SelectedIndex = 0
        Me.Compression_CB0_CBox.SelectedIndex = 0
        Me.Compression_PB1_CBox.SelectedIndex = 0
        Me.Compression_CB1_CBox.SelectedIndex = 0
        Me.Compression_PB2_CBox.SelectedIndex = 0
        Me.Compression_CB2_CBox.SelectedIndex = 0

        Me.Palette_CodeOutComboB.SelectedIndex = MSXDataFormat.OutputFormat.ASM
        Me.Palette_SizeLineComboB.SelectedIndex = 0

        Me.ActiveControl = Me.LoadNMSXTILESprojectBut

        Me.PaleteNameTextB.Text = PaletteDialog.PaletteColors.name


        Me.Text = My.Application.Info.Title + " v" + My.Application.Info.Version.ToString + "b · " + My.Application.Info.Copyright

        SetScreenViewer(0)

        'Dim aLicenseWin As New LicenseWin(True, LicenseWin.LANCODE.ENG, My.Application.Info.Title, App_version, My.Application.Info.Copyright)
        'Dim LicenseResult As Boolean

        'LicenseResult = aLicenseWin.AcceptLicense(My.Application.Info.ProductName)
        'If Not LicenseResult Then
        '    Me.Close()
        'End If



        'Dim licensePath As String = System.Environment.CurrentDirectory + Path.DirectorySeparatorChar + "MSXTilesTools_license.txt"

        'If Not File.Exists(licensePath) Then

        '    result = aLicenseWin.ShowDialog()

        '    If result = Windows.Forms.DialogResult.No Then
        '        Me.Close()
        '    Else
        '        Dim aStreamWriterFile As New System.IO.StreamWriter(licensePath)
        '        aStreamWriterFile.WriteLine(aLicenseWin.license)
        '        aStreamWriterFile.Close()
        '    End If

        'End If

    End Sub



    Public Function LoadConfig() As Boolean
        Try

            Dim aXmlDoc As New XmlDocument

            Dim aNode As XmlNode
            'Dim aNodeList As XmlNodeList
            'Dim aValue As String
            'Dim tmpList As New SortedList
            'Dim itemIndex As Integer

            Dim ConfigFileAdress As String = System.AppDomain.CurrentDomain.BaseDirectory + Me.ConfigFileName


            If System.IO.File.Exists(ConfigFileAdress) Then

                aXmlDoc.Load(ConfigFileAdress)

                '
                aNode = aXmlDoc.SelectSingleNode("config/Path_Project")
                If Not aNode Is Nothing Then
                    '    Me.Path_Project = System.AppDomain.CurrentDomain.BaseDirectory
                    'ElseIf aNode.InnerText = "" Then
                    '    Me.Path_Project = System.AppDomain.CurrentDomain.BaseDirectory
                    'Else
                    Me.Path_Project = aNode.InnerText
                End If

                aNode = aXmlDoc.SelectSingleNode("config/Path_SC2")
                If Not aNode Is Nothing Then
                    Me.Path_SC2 = aNode.InnerText
                End If

                aNode = aXmlDoc.SelectSingleNode("config/Path_Bitmap")
                If Not aNode Is Nothing Then
                    Me.Path_Bitmap = aNode.InnerText
                End If

                aNode = aXmlDoc.SelectSingleNode("config/Path_nMSXtilesProject")
                If Not aNode Is Nothing Then
                    Me.Path_nMSXtilesProject = aNode.InnerText
                End If

                aNode = aXmlDoc.SelectSingleNode("config/Path_Palettes")
                If Not aNode Is Nothing Then
                    'Me.Path_Palettes = aNode.InnerText
                    PaletteDialog.PaletteDefaultPath = aNode.InnerText
                End If

                ''PaletteDefaultPath
                'aNode = aXmlDoc.SelectSingleNode("config/PaletteDefaultPath")
                ''aValue = aNode.InnerText
                'If aNode Is Nothing Then
                '    Me.paletteDialog.PaletteDefaultPath = System.AppDomain.CurrentDomain.BaseDirectory
                'ElseIf aNode.InnerText = "" Then
                '    Me.paletteDialog.PaletteDefaultPath = System.AppDomain.CurrentDomain.BaseDirectory
                'Else
                '    Me.paletteDialog.PaletteDefaultPath = aNode.InnerText
                'End If


                'aNodeList = aXmlDoc.SelectNodes("config/RecentProjects/item")
                'If aNodeList Is Nothing Then
                '    Me.RecentProjects = New RecentProjectsList

                'Else

                '    For Each aNodeItem As XmlNode In aNodeList

                '        itemIndex = CInt(aNodeItem.Attributes.GetNamedItem("index").InnerText)
                '        aValue = aNodeItem.Attributes.GetNamedItem("path").InnerText

                '        tmpList.Add(itemIndex, aValue)

                '    Next

                '    Me.RecentProjects = New RecentProjectsList(tmpList)

                'End If


                Return True

            Else
                'Me.ProjectDefaultPath = System.AppDomain.CurrentDomain.BaseDirectory
                'Me.paletteDialog.PaletteDefaultPath = System.AppDomain.CurrentDomain.BaseDirectory
                'Me.RecentProjects = New RecentProjectsList
                Return False
            End If



        Catch ex As Exception
            ' error! No se ha podido cargar la configuración
            Return False
        End Try

    End Function



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SaveConfig()
        Try

            Dim aXmlDoc As New XmlDocument
            Dim ConfigFileAdress As String = System.AppDomain.CurrentDomain.BaseDirectory + Me.ConfigFileName
            Dim rootElement As XmlElement
            Dim txtElement As XmlText
            Dim anElement As XmlElement
            Dim anAttribute As XmlAttribute
            'Dim anItemElement As XmlElement

            ' crea el nodo root
            rootElement = aXmlDoc.CreateElement("config")
            aXmlDoc.AppendChild(rootElement)

            anAttribute = aXmlDoc.CreateAttribute("app")
            anAttribute.Value = My.Application.Info.ProductName
            rootElement.SetAttributeNode(anAttribute)

            anAttribute = aXmlDoc.CreateAttribute("version")
            anAttribute.Value = My.Application.Info.Version.ToString
            rootElement.SetAttributeNode(anAttribute)

            'debug data
            'anAttribute = aXmlDoc.CreateAttribute("dotnetvers")
            'anAttribute.Value = Environment.Version.ToString()
            'rootElement.SetAttributeNode(anAttribute)


            anElement = aXmlDoc.CreateElement("Path_Project")
            txtElement = aXmlDoc.CreateTextNode(Me.Path_Project)
            anElement.AppendChild(txtElement)
            rootElement.AppendChild(anElement)

            anElement = aXmlDoc.CreateElement("Path_SC2")
            txtElement = aXmlDoc.CreateTextNode(Me.Path_SC2)
            anElement.AppendChild(txtElement)
            rootElement.AppendChild(anElement)

            anElement = aXmlDoc.CreateElement("Path_Bitmap")
            txtElement = aXmlDoc.CreateTextNode(Me.Path_Bitmap)
            anElement.AppendChild(txtElement)
            rootElement.AppendChild(anElement)

            anElement = aXmlDoc.CreateElement("Path_nMSXtilesProject")
            txtElement = aXmlDoc.CreateTextNode(Me.Path_nMSXtilesProject)
            anElement.AppendChild(txtElement)
            rootElement.AppendChild(anElement)

            anElement = aXmlDoc.CreateElement("Path_Palettes")
            txtElement = aXmlDoc.CreateTextNode(Me.PaletteDialog.PaletteDefaultPath)
            anElement.AppendChild(txtElement)
            rootElement.AppendChild(anElement)

            'anElement = aXmlDoc.CreateElement("PaletteDefaultPath")
            'txtElement = aXmlDoc.CreateTextNode(Me.paletteDialog.PaletteDefaultPath)
            'anElement.AppendChild(txtElement)
            'rootElement.AppendChild(anElement)

            'anElement = aXmlDoc.CreateElement("RecentProjects")
            'rootElement.AppendChild(anElement)
            'For i As Integer = 0 To RecentProjects.Count - 1
            '    anItemElement = aXmlDoc.CreateElement("item")
            '    anElement.AppendChild(anItemElement)

            '    anAttribute = aXmlDoc.CreateAttribute("index")
            '    anAttribute.Value = CStr(i)
            '    anItemElement.SetAttributeNode(anAttribute)

            '    anAttribute = aXmlDoc.CreateAttribute("path")
            '    anAttribute.Value = Me.RecentProjects.GetFileItem(i).Path
            '    anItemElement.SetAttributeNode(anAttribute)
            'Next

            '
            aXmlDoc.Save(ConfigFileAdress)


            'Me.StatusBarLabel.Text = ApplicationInfo.GetLiteral("mssge.configsaved", "Settings saved")

        Catch ex As Exception
            ' error! No se ha podido guardar la configuración
        End Try
    End Sub



    ''' <summary>
    ''' Load Project data
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <remarks></remarks>
    Private Sub LoadData(ByVal filePath As String)

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

            aNode = aDataNode.SelectSingleNode("@name")
            If aNode Is Nothing Then
                Me.ProjectName = Path.GetFileNameWithoutExtension(filePath)
            Else
                Me.ProjectName = aNode.InnerText
            End If

            aNode = aDataNode.SelectSingleNode("@version")
            If aNode Is Nothing Then
                Me.ProjectVersion = "0"
            Else
                Me.ProjectVersion = aNode.InnerText
            End If

            aNode = aDataNode.SelectSingleNode("@group")
            If aNode Is Nothing Then
                Me.ProjectGroup = ""
            Else
                Me.ProjectGroup = aNode.InnerText
            End If

            aNode = aDataNode.SelectSingleNode("@author")
            If aNode Is Nothing Then
                Me.ProjectAuthor = ""
            Else
                Me.ProjectAuthor = aNode.InnerText
            End If

            aNode = aDataNode.SelectSingleNode("@startDate")
            If aNode Is Nothing Then
                Me.ProjectStartDate = DateTime.Today.Ticks
            Else
                Me.ProjectStartDate = CLng(aNode.InnerText)
            End If

            aNode = aDataNode.SelectSingleNode("@lastUpdate")
            If aNode Is Nothing Then
                Me.ProjectLastUpdate = DateTime.Today.Ticks
            Else
                Me.ProjectLastUpdate = CLng(aNode.InnerText)
            End If

            aNode = aDataNode.SelectSingleNode("description")
            If aNode Is Nothing Then
                Me.ProjectDescription = ""
            Else
                Me.ProjectDescription = aNode.InnerText
            End If
            'END project data ##############################################




            ' comprueba que el fichero de datos es para este programa, buscando el nombre del nodo principal
            ' MEJORABLE! :P
            If aXmlDoc.GetElementsByTagName("msxdevtools").Count > 0 Then

                ' Paleta de colores ##############################################3
                aDataNode = aXmlDoc.SelectSingleNode("msxdevtools/palette") ' comprueba si contiene datos de la paleta
                If Not aDataNode Is Nothing Then
                    Me.PaletteDialog.SetPaletteFromNode(aDataNode)
                Else
                    Me.PaletteDialog.setDefaultPalette()
                End If
                ' END paleta de colores ##############################################


                '
                aDataNode = aXmlDoc.SelectSingleNode("msxdevtools/gfx")
                If Not aDataNode Is Nothing Then

                    aNode = aDataNode.SelectSingleNode("@name")
                    If aNode Is Nothing Then
                        Me.TilesetsName = Me.ProjectName
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
                        Me.MapName = Me.ProjectName
                    Else
                        Me.MapName = aNode.InnerText
                    End If

                    result = setMapFromElement(aDataNode)
                End If
                '



                'closeProgressWin()
                screen2.RefreshScreen()

                Application.DoEvents()


            End If

        Catch ex As Exception
            result = False
        End Try

        If result Then
            LoadScrText.Text = Me.MapName + ".scr"
            LoadTilText.Text = Me.TilesetsName + ".til"
        Else
            MsgBox("Disk I/O error.", MsgBoxStyle.Critical, "Error")
        End If

    End Sub



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
                        Me.TilesetsName = Me.ProjectName
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
                screen2.RefreshScreen()

                Application.DoEvents()


            End If

        Catch ex As Exception
            result = False
        End Try

        If result Then
            'LoadScrText.Text = Me.MapName + ".scr"
            LoadTilText.Text = Me.TilesetsName + ".til"
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
                        Me.MapName = Me.ProjectName
                    Else
                        Me.MapName = aNode.InnerText
                    End If

                    result = setMapFromElement(aDataNode)
                End If
                '



                'closeProgressWin()
                screen2.RefreshScreen()

                Application.DoEvents()


            End If

        Catch ex As Exception
            result = False
        End Try

        If result Then
            LoadScrText.Text = Me.MapName + ".scr"
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
                If tile < 256 Then
                    subNode = anItemElement.SelectSingleNode("gfxData")
                    tmpString = subNode.InnerText
                    vaddr = (tilebank * 2048) + (tile * 8) + TMS9918.TableBase.GRPCGP
                    aData = ByteSpliter(tmpString, 8, 0, 0)
                    Me.screen2.VPOKE_block(vaddr, aData)

                    subNode = anItemElement.SelectSingleNode("colorData")
                    tmpString = subNode.InnerText
                    vaddr = (tilebank * 2048) + (tile * 8) + TMS9918.TableBase.GRPCOL
                    aData = ByteSpliter(tmpString, 8, 0, 0)
                    Me.screen2.VPOKE_block(vaddr, aData)
                End If
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
                    tmpString = anItemElement.InnerText
                    vaddr = (line * 32) + TMS9918.TableBase.GRPNAM
                    aData = ByteSpliter(tmpString, 32, 0, 0)
                    Me.screen2.VPOKE_block(vaddr, aData)
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
        anElement = aXmlDoc.CreateElement("project")
        rootElement.AppendChild(anElement)

        anAttribute = aXmlDoc.CreateAttribute("name")
        anAttribute.Value = Me.ProjectName
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("version")
        anAttribute.Value = Me.ProjectVersion
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("group")
        anAttribute.Value = Me.ProjectGroup
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("author")
        anAttribute.Value = Me.ProjectAuthor
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("startDate")
        anAttribute.Value = CStr(Me.ProjectStartDate)
        anElement.SetAttributeNode(anAttribute)

        Me.ProjectLastUpdate = DateTime.Today.Ticks
        anAttribute = aXmlDoc.CreateAttribute("lastUpdate")
        anAttribute.Value = CStr(Me.ProjectLastUpdate)
        anElement.SetAttributeNode(anAttribute)

        anItemElement = aXmlDoc.CreateElement("description")
        txtElement = aXmlDoc.CreateTextNode(Me.ProjectDescription)
        anItemElement.AppendChild(txtElement)
        anElement.AppendChild(anItemElement)
        'END project data ##############################################


        ' palette data ##############################################
        rootElement.AppendChild(Me.PaletteDialog.getPaletteElement(aXmlDoc))
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

        anAttribute = aXmlDoc.CreateAttribute("author")
        anAttribute.Value = Me.ProjectAuthor
        anElement.SetAttributeNode(anAttribute)

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

        anAttribute = aXmlDoc.CreateAttribute("author")
        anAttribute.Value = Me.ProjectAuthor
        anItemElement.SetAttributeNode(anAttribute)

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
        vaddr = (tilebank * 2048) + (tile * 8) + TMS9918.TableBase.GRPCGP
        For i = 0 To 7
            data(i) = Me.screen2.VPEEK(vaddr)
            vaddr += 1
        Next
        anItemElement = aXmlDoc.CreateElement("gfxData")
        txtElement = aXmlDoc.CreateTextNode(joinData(data))
        anItemElement.AppendChild(txtElement)
        anElement.AppendChild(anItemElement)

        'colors
        vaddr = (tilebank * 2048) + (tile * 8) + TMS9918.TableBase.GRPCOL
        For i = 0 To 7
            data(i) = Me.screen2.VPEEK(vaddr)
            vaddr += 1
        Next
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
        vaddr = (line * 32) + TMS9918.TableBase.GRPNAM
        For i = 0 To 31
            data(i) = Me.screen2.VPEEK(vaddr)
            vaddr += 1
        Next

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
    Private Sub LoadScrBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadScrBut.Click

        screenTilesData = Nothing

        Me.OpenFileDialog1.DefaultExt = "scr"
        Me.OpenFileDialog1.Filter = "Screen nMSXtiles file|*.scr|All files|*.*"

        Me.OpenFileDialog1.FileName = Me.TilesetsName

        If Not Me.Path_nMSXtilesProject = "" Then
            Me.OpenFileDialog1.InitialDirectory = Me.Path_nMSXtilesProject
        End If

        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If LoadNMSXtilesMAP(OpenFileDialog1.FileName) = True Then

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

            Me.Path_Screen = filePath

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
            Dim address As Short = screen2.BASE(TMS9918.NumberOfBase.Name_Table_Base_Address)

            For i = 1 To 768
                screenTilesData(contador) = CByte(dataText.Item(i))
                'screenTilesData(contador) = CByte(CInt(sLine))
                screen2.VPOKE(address, screenTilesData(contador))
                contador += 1
                address += 1
            Next

            screen2.RefreshScreen()


            SetScreenViewer(0)

            Me.MapName = Path.GetFileNameWithoutExtension(filePath)
            LoadScrText.Text = Me.MapName + ".scr"



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

        Dim linesize As Integer = 0

        Me.Tileset_TxtOutput.AppendText("// tileset " + TilesetsName + vbNewLine)
        'Me.tilesetTxtOutput.AppendText("// tiles: " + CStr(IniTile) + ">" + CStr(EndTile) + vbNewLine)

        linesize = CInt(Me.Tileset_SizeLineComboB.SelectedItem)

        For Each aDataItem As DataItem In dataList
            Me.Tileset_TxtOutput.AppendText(genData.C_codeGen(aDataItem.data, linesize, Tileset_NumSysComboBox.SelectedIndex, aDataItem.label, aDataItem.comment))
            Me.Tileset_TxtOutput.AppendText(vbNewLine) ' salto de linea
        Next

    End Sub


    ''' <summary>
    ''' Displays tileset data in Assembler language.
    ''' </summary>
    ''' <param name="dataList"></param>
    ''' <remarks></remarks>
    Private Sub TileSet_AsmCodeGen(ByVal dataList As ArrayList)

        Dim linesize As Integer = 0

        Me.Tileset_TxtOutput.Clear()

        Me.Tileset_TxtOutput.AppendText("; tileset " + TilesetsName + vbNewLine)
        'Me.tilesetTxtOutput.AppendText("; tiles: " + CStr(IniTile) + ">" + CStr(EndTile) + vbNewLine)

        linesize = CInt(Me.Tileset_SizeLineComboB.SelectedItem)

        For Each aDataItem As DataItem In dataList
            Me.Tileset_TxtOutput.AppendText(genData.Asm_codeGen(aDataItem.data, linesize, Tileset_NumSysComboBox.SelectedIndex, aDataItem.label, aDataItem.comment, "db"))

            Me.Tileset_TxtOutput.AppendText(vbNewLine) ' salto de linea
        Next

    End Sub


    ''' <summary>
    ''' Displays tileset data in Assembler for SDCC.
    ''' </summary>
    ''' <param name="dataList"></param>
    ''' <remarks></remarks>
    Private Sub TileSet_AsmSDCCCodeGen(ByVal dataList As ArrayList)

        Dim linesize As Integer = 0

        Me.Tileset_TxtOutput.Clear()

        Me.Tileset_TxtOutput.AppendText("; tileset " + TilesetsName + vbNewLine)

        linesize = CInt(Me.Tileset_SizeLineComboB.SelectedItem)

        For Each aDataItem As DataItem In dataList
            Me.Tileset_TxtOutput.AppendText(genData.Asm_codeGen(aDataItem.data, linesize, Tileset_NumSysComboBox.SelectedIndex, aDataItem.label, aDataItem.comment, ".db"))

            Me.Tileset_TxtOutput.AppendText(vbNewLine) ' salto de linea
        Next

    End Sub


    ''' <summary>
    ''' Displays tileset data in MSX BASIC language
    ''' </summary>
    ''' <param name="dataList"></param>
    ''' <remarks></remarks>
    ''' , ByVal IniTile As Byte, ByVal EndTile As Byte
    Private Sub TileSet_BasicCodeGen(ByVal dataList As ArrayList)

        Dim linesize As Integer = 0
        Dim linenum As Integer = BasicConfig.StartingLine
        Dim lineinterval As Integer = BasicConfig.Interval

        Me.Tileset_TxtOutput.AppendText(CStr(linenum) + " REM tileset " + TilesetsName + vbNewLine)
        'Me.tilesetTxtOutput.AppendText(CStr(linenum + lineinterval) + " REM tiles: " + CStr(IniTile) + ">" + CStr(EndTile) + vbNewLine)
        linenum += lineinterval * 2

        linesize = CInt(Me.Tileset_SizeLineComboB.SelectedItem)

        For Each aDataItem As DataItem In dataList
            Me.Tileset_TxtOutput.AppendText(genData.BasicMSX_codeGen(aDataItem.data, linesize, Tileset_NumSysComboBox.SelectedIndex, BasicConfig.RemoveZeros, linenum, lineinterval, aDataItem.comment))
            Me.Tileset_TxtOutput.AppendText(vbNewLine) ' salto de linea
            linenum = genData.lastLineNumber
        Next

        'tilscrTxtOutput.AppendText(genData.BasicMSX_codeGen(data, linesize, MSXDataFormat.DataFormat.N_HEXADECIMAL, Me.Tiles_RZCheckB.Checked, CShort(Me.Tiles_LinenumTextB.Text), CByte(Me.Tiles_IntervalTextB.Text), Me.FieldName.Text))

    End Sub




    Private Sub GetScrButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetScrButton.Click
        GenerateScreenData()
    End Sub



    Private Sub GenerateScreenData()

        Dim outputSource As String = ""
        Dim vaddr As String
        Dim linesize As Integer = 0
        'Dim wRLE As Boolean = Me.RLEscrCB.Checked

        Dim startX As Integer = Val(Me.startTileX.Text)
        Dim startY As Integer = Val(Me.startTileY.Text)
        Dim endX As Integer = Val(Me.endTileX.Text)
        Dim endY As Integer = Val(Me.endTileY.Text)

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


        Me.startTileX.Text = startX
        Me.startTileY.Text = startY
        Me.endTileX.Text = endX
        Me.endTileY.Text = endY

        ' generate byte array with screen data
        Dim data As Byte()
        Dim datasize As Integer = (endX - startX + 1) * (endY - startY + 1) - 1
        Dim conta As Integer = 0
        Dim addr As Short = 0
        Dim Base10 As Short = screen2.BASE(TMS9918.NumberOfBase.Name_Table_Base_Address)
        ReDim data(datasize)

        For i = startY To endY
            For o = startX To endX
                addr = Base10 + (i * 32) + o
                data(conta) = screen2.VPEEK(addr)
                conta += 1
            Next
        Next
        ' end

        vaddr = getHexShort(screen2.BASE(TMS9918.NumberOfBase.Name_Table_Base_Address) + (startY * 32) + startX)


        comment.Add("map " + MapName)
        comment.Add("VRAM address= " + vaddr + "h")
        'comment.Add("size=" + getHexShort(data.Length) + "h")
        comment.Add("start x=" + CStr(startX) + " y=" + CStr(startY))
        comment.Add("end   x=" + CStr(endX) + " y=" + CStr(endY))


        Select Case Map_compressionScrCB.SelectedIndex

            Case 1
                tmpData = aRLE.GetRLE(data)
                comment.Add("RLE compressed - Original size= " + CStr(data.Length) + " - Final size= " + CStr(tmpData.Length))
            Case 2
                tmpData = aRLE.GetRLE_WB(data)
                comment.Add("RLE WB compressed - Original size= " + CStr(data.Length) + " - Final size= " + CStr(tmpData.Length))
                'Case 3
                '    tmpData = Me.GetRLE3(data)
                '    comment.Add("RLE3 compressed - Original size:" + CStr(data.Length) + " - RLE size:" + CStr(tmpData.Length))

            Case Else
                tmpData = data
                comment.Add("Size= " + CStr(data.Length))

        End Select


        If Me.Map_SizeLineComboB.SelectedIndex = 0 Then
            linesize = endX - startX + 1
        Else
            linesize = CInt(Me.Map_SizeLineComboB.SelectedItem)
        End If


        Me.Tiles_TxtOutput.Clear()

        ' show data in respective code language
        Select Case Map_CodeOutComboB.SelectedIndex
            Case MSXDataFormat.OutputFormat.C
                outputSource = genData.C_codeGen(tmpData, linesize, Map_NumSysComboBox.SelectedIndex, Me.Map_FieldName.Text, comment)
            Case MSXDataFormat.OutputFormat.ASM
                outputSource = genData.Asm_codeGen(tmpData, linesize, Map_NumSysComboBox.SelectedIndex, Me.Map_FieldName.Text, comment, "db")
            Case MSXDataFormat.OutputFormat.ASM_SDCC
                outputSource = genData.Asm_codeGen(tmpData, linesize, Map_NumSysComboBox.SelectedIndex, Me.Map_FieldName.Text, comment, ".db")
            Case MSXDataFormat.OutputFormat.BASIC
                outputSource = genData.BasicMSX_codeGen(tmpData, linesize, Map_NumSysComboBox.SelectedIndex, BasicConfig.RemoveZeros, BasicConfig.StartingLine, BasicConfig.Interval, comment)
        End Select

        Tiles_TxtOutput.AppendText(outputSource)



    End Sub



    Private Sub TilesetGenButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TilesetGenButton.Click

        GenerateTilesetData()

    End Sub


    ''' <summary>
    ''' Generates data for the graphics of the tiles.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GenerateTilesetData()

        Dim patternBase As Short = screen2.BASE(TMS9918.NumberOfBase.Pattern_Generator_Base_Address)
        Dim colorBase As Short = screen2.BASE(TMS9918.NumberOfBase.Color_Table_Base_Address)

        Dim dataOutputType As Integer = 0

        Dim dataList As New ArrayList

        Me.Tileset_TxtOutput.Clear()

        Dim name As String = Me.Tileset_FieldName.Text.ToUpper

        If AllBanksCheckBox.Checked Then
            'ALL Banks

            If Me.ALLpattern.Checked Then
                dataList.Add(getDataItem("", True, name, getData(patternBase, 0, 767), CompressPat_ALL_CBox.SelectedIndex, "", ""))
            End If

            If Me.ALLcolor.Checked Then
                dataList.Add(getDataItem("", False, name, getData(colorBase, 0, 767), CompressCol_ALL_CBox.SelectedIndex, "", ""))
            End If


        Else
            'selected banks

            If Me.B0Check.Checked And B0pattern.Checked Then
                dataList.Add(getDataItem("0", True, name, getData(patternBase, CByte(Me.B0IniTile.Text), CByte(Me.B0EndTile.Text)), Compression_PB0_CBox.SelectedIndex, Me.B0IniTile.Text, Me.B0EndTile.Text))
                'New DataItem(name + "_B0", comment, tmpData))
            End If

            If Me.Bank1CheckB.Checked And B1Pattern.Checked Then
                dataList.Add(getDataItem("1", True, name, getData(patternBase + 2048, CByte(Me.B1IniTile.Text), CByte(Me.B1EndTile.Text)), Compression_PB1_CBox.SelectedIndex, Me.B1IniTile.Text, Me.B1EndTile.Text))
                'dataList.Add(New DataItem(name + "_B1", "pattern data BANK1", getData(patternBase + 2048, CByte(Me.B1IniTile.Text), CByte(Me.B1EndTile.Text))))
            End If

            If Me.Bank2CheckB.Checked And B2Pattern.Checked Then
                dataList.Add(getDataItem("2", True, name, getData(patternBase + 4096, CByte(Me.B2IniTile.Text), CByte(Me.B2EndTile.Text)), Compression_PB2_CBox.SelectedIndex, Me.B2IniTile.Text, Me.B2EndTile.Text))
                'dataList.Add(New DataItem(name + "_B2", "pattern data BANK2", getData(patternBase + 4096, CByte(Me.B2IniTile.Text), CByte(Me.B2EndTile.Text), B2patternRLE.Checked)))
            End If


            If Me.B0Check.Checked And B0color.Checked Then
                dataList.Add(getDataItem("0", False, name, getData(colorBase, CByte(Me.B0IniTile.Text), CByte(Me.B0EndTile.Text)), Compression_CB0_CBox.SelectedIndex, Me.B0IniTile.Text, Me.B0EndTile.Text))
                'dataList.Add(New DataItem(name + "_col_B0", "color data BANK0", getData(colorBase, CByte(Me.B0IniTile.Text), CByte(Me.B0EndTile.Text), B0colorRLE.Checked)))
            End If

            If Me.Bank1CheckB.Checked And B1color.Checked Then
                dataList.Add(getDataItem("1", False, name, getData(colorBase + 2048, CByte(Me.B1IniTile.Text), CByte(Me.B1EndTile.Text)), Compression_CB1_CBox.SelectedIndex, Me.B1IniTile.Text, Me.B1EndTile.Text))
                'dataList.Add(New DataItem(name + "_col_B1", "color data BANK1", getData(colorBase + 2048, CByte(Me.B1IniTile.Text), CByte(Me.B1EndTile.Text), B1colorRLE.Checked)))
            End If

            If Me.Bank2CheckB.Checked And B2color.Checked Then
                dataList.Add(getDataItem("2", False, name, getData(colorBase + 4096, CByte(Me.B2IniTile.Text), CByte(Me.B2EndTile.Text)), Compression_CB2_CBox.SelectedIndex, Me.B2IniTile.Text, Me.B2EndTile.Text))
                'dataList.Add(New DataItem(name + "_col_B2", "color data BANK2", getData(colorBase + 4096, CByte(Me.B2IniTile.Text), CByte(Me.B2EndTile.Text), B2colorRLE.Checked)))
            End If

        End If



        Select Case Tileset_CodeOutComboB.SelectedIndex
            Case MSXDataFormat.OutputFormat.C
                ' C
                TileSet_CCodeGen(dataList)
            Case MSXDataFormat.OutputFormat.ASM
                ' ASM
                TileSet_AsmCodeGen(dataList)
            Case MSXDataFormat.OutputFormat.ASM_SDCC
                ' ASM SDCC
                TileSet_AsmSDCCCodeGen(dataList)
            Case MSXDataFormat.OutputFormat.BASIC
                ' BASIC
                TileSet_BasicCodeGen(dataList)
        End Select

    End Sub


    Private Function getDataItem(ByVal nbank As String, ByVal isPattern As Boolean, ByVal name As String, ByVal data() As Byte, ByVal nCompression As Integer, ByVal iniTile As String, ByVal endTile As String) As DataItem

        Dim comment As New ArrayList
        Dim tmpData() As Byte
        Dim preName As String

        Dim aRLE As New RLE

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
                tmpData = aRLE.GetRLE(data)
                comment.Add("RLE compressed - Original size= " + CStr(data.Length) + " - Final size= " + CStr(tmpData.Length))
            Case 2
                tmpData = aRLE.GetRLE_WB(data)
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
                data(conta) = screen2.VPEEK(addr)
                addr += 1
                conta += 1
            Next
            'contaTile += 1
        Next

        Return data

    End Function




    Private Sub Load_TileSet_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadTilesBut.Click

        Me.OpenFileDialog1.DefaultExt = "til"
        Me.OpenFileDialog1.Filter = "Tiles nMSXtiles file|*.til"

        Me.OpenFileDialog1.FileName = Me.TilesetsName

        If Not Me.Path_nMSXtilesProject = "" Then
            Me.OpenFileDialog1.InitialDirectory = Me.Path_nMSXtilesProject
        End If

        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadNMSXtilesTileSet(OpenFileDialog1.FileName)

            Me.TilesetsName = Path.GetFileNameWithoutExtension(OpenFileDialog1.FileName)
            LoadTilText.Text = Me.TilesetsName + ".til"
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

            Me.Path_Tileset = filePath

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

                Dim colorBase As Short = screen2.BASE(TMS9918.NumberOfBase.Color_Table_Base_Address)
                Dim gfxBase As Short = screen2.BASE(TMS9918.NumberOfBase.Pattern_Generator_Base_Address)

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
                                    screen2.VPOKE(colorBase, (higVal * 16) + lowVal)
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
                                    screen2.VPOKE(gfxBase, CByte(Convert.ToInt32(aByteString, 2)))
                                    gfxBase += 1
                                Next

                            Next
                        Next
                    End If
                Next

                screen2.RefreshScreen()

                Me.TilesetsName = Path.GetFileNameWithoutExtension(filePath)
                LoadTilText.Text = Me.TilesetsName + ".til"

            End If


            Return True

        Catch ex As Exception
            Return False
        End Try

    End Function


    'Private Sub saveFile()
    '    Try

    '        Dim objReader As New StreamReader(filePath)


    '        If Me.TokenBox.Text.Length < 1 Then
    '            'MessageBox.Show("No hay datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '            aMessageWin.ShowWin(Me, _
    '            ApplicationInfo.GetLiteral("mssge.nodata", "I could not perform the task, because data are not"), _
    '            ApplicationInfo.GetLiteral("mssge.warn", "Warning"), MessageBoxIcon.Error)
    '            Exit Sub
    '        End If


    '        Dim filePath As String
    '        Dim resultado As System.Windows.Forms.DialogResult

    '        resultado = SaveFileDialog1.ShowDialog()


    '        Dim saveData() As Byte
    '        ReDim saveData(Me.TokenBox.Text.Length)

    '        Dim counter As Integer = 0

    '        For Each aChar As Char In Me.TokenBox.Text.ToCharArray
    '            saveData(counter) = CByte(AscW(aChar))
    '            counter += 1
    '        Next

    '        If Not resultado = Windows.Forms.DialogResult.OK Then
    '            Exit Sub
    '        End If

    '        filePath = SaveFileDialog1.FileName

    '        Dim aStream As New System.IO.FileStream(filePath, IO.FileMode.Create)

    '        aStream.Write(saveData, 0, saveData.Length - 1)
    '        aStream.Close()


    '    Catch ex As Exception

    '    End Try
    'End Sub



    ''' <summary>
    ''' Save the screen (tiles) in a binary file with the header to be loaded from MSX-Basic.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SaveBinBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBinBut.Click

        Me.SaveFileDialog1.DefaultExt = "bin"
        Me.SaveFileDialog1.Filter = "VRAM bin file|*.bin|Screen2 bin file|*.sc2|All files|*.*"

        Me.SaveFileDialog1.FileName = Me.ProjectName + "_Map"

        If Not Me.Path_SC2 = "" Then
            Me.SaveFileDialog1.InitialDirectory = Me.Path_SC2
        End If

        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.screen2.BSAVE(SaveFileDialog1.FileName, &H1800, &H1AFF)
        End If

    End Sub


    'Private Sub BSAVE(ByVal filePath As String, ByVal initAddr As Short, ByVal endAddr As Short, ByVal data() As Byte)

    '    'Try

    '    Dim filedata As Byte()
    '    'Dim dataLength As Short = &H1AFF - &H1800 'endAddr - initAddr

    '    ReDim filedata(data.Length + 7)


    '    ' cabecera del fichero binario para memoria de video, zona de nombre de patrones.
    '    filedata(0) = &HFE
    '    filedata(1) = CByte(initAddr And &HFF)
    '    filedata(2) = CByte((initAddr And &HFF00) / &HFF)
    '    filedata(3) = CByte(endAddr And &HFF)
    '    filedata(4) = CByte((endAddr And &HFF00) / &HFF)
    '    filedata(5) = &H0
    '    filedata(6) = &H0
    '    ' end

    '    For i As Integer = 0 To data.Length - 1
    '        filedata(i + 7) = data(i)
    '    Next

    '    Dim aStream As New System.IO.FileStream(filePath, IO.FileMode.Create)
    '    aStream.Write(filedata, 0, filedata.Length)
    '    aStream.Close()

    '    'Catch ex As Exception

    '    'End Try

    'End Sub






    ''' <summary>
    ''' Carga un proyecto de nMSXtiles
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LoadNMSXTILESprojectBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadNMSXTILESprojectBut.Click

        Me.OpenFileDialog1.DefaultExt = "prj"
        Me.OpenFileDialog1.Filter = "nMSXtiles Project file|*.prj"

        Me.OpenFileDialog1.FileName = ProjectFileName

        If Not Me.Path_nMSXtilesProject = "" Then
            Me.OpenFileDialog1.InitialDirectory = Me.Path_nMSXtilesProject
        End If

        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadNMSXtilesProject(OpenFileDialog1.FileName)
            Me.Path_nMSXtilesProject = Path.GetDirectoryName(OpenFileDialog1.FileName)
            Me.ProjectFileName = Path.GetFileNameWithoutExtension(OpenFileDialog1.FileName)
        End If

    End Sub


    ''' <summary>
    ''' Load a nMSXtiles Project
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <remarks></remarks>
    Private Sub LoadNMSXtilesProject(ByVal filePath As String)
        Dim objReader As New StreamReader(filePath)
        Dim dataText As New ArrayList()
        Dim sLine As String
        Dim result As Boolean

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

                screen2.SetDefaultPalette()
                screen2.RefreshScreen()

                Application.DoEvents()

                'Me.ProjectName = Path.GetFileNameWithoutExtension(filePath)
                NewProject(Path.GetFileNameWithoutExtension(filePath))

            End If

        End If
    End Sub



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
            Dim vaddr As Short = screen2.BASE(TMS9918.NumberOfBase.Name_Table_Base_Address)

            For i As Integer = 0 To 767
                objWriter.WriteLine(Str(screen2.VPEEK(vaddr)))
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


            Dim colorBase As Short = screen2.BASE(TMS9918.NumberOfBase.Color_Table_Base_Address)
            Dim gfxBase As Short = screen2.BASE(TMS9918.NumberOfBase.Pattern_Generator_Base_Address)

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
                            lowVal = screen2.VPEEK(colorBase + i) And 15
                            'lowVal = lowVal And 15
                            'higVal = CByte(dataText.Item(conta + 8))
                            'aScreen2.VPOKE(colorBase, (higVal * 16) + lowVal)
                            objWriter.WriteLine(lowVal)
                        Next

                        For i = 0 To 7
                            'the two values of colors are separated in two bytes
                            higVal = screen2.VPEEK(colorBase)
                            higVal = (higVal And 240) / 16
                            colorBase += 1
                            'higVal = CByte(dataText.Item(conta + 8))
                            'aScreen2.VPOKE(colorBase, (higVal * 16) + lowVal)
                            objWriter.WriteLine(higVal)
                        Next


                        'pattern data
                        For i = 0 To 7
                            patternValue = screen2.VPEEK(gfxBase)
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



    Private Sub SavePrjButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SavePrjButton.Click

        Me.SaveFileDialog1.DefaultExt = "prj"
        Me.SaveFileDialog1.Filter = "nMSXtiles Project file|*.prj"

        Me.SaveFileDialog1.FileName = Me.ProjectFileName

        If Not Me.Path_nMSXtilesProject = "" Then
            Me.SaveFileDialog1.InitialDirectory = Me.Path_nMSXtilesProject
        End If

        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            SaveNMSXtilesProject(SaveFileDialog1.FileName)
            Me.Path_nMSXtilesProject = Path.GetDirectoryName(SaveFileDialog1.FileName)
        End If

    End Sub



    Private Sub SaveSC2But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveSC2But.Click

        Me.SaveFileDialog1.DefaultExt = "sc2"
        Me.SaveFileDialog1.Filter = "Screen2 bin file|*.sc2|VRAM bin file|*.bin|All files|*.*"

        Me.SaveFileDialog1.FileName = Me.ProjectFileName

        If Not Me.Path_SC2 = "" Then
            Me.SaveFileDialog1.InitialDirectory = Me.Path_SC2
        End If

        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.Path_SC2 = Path.GetDirectoryName(SaveFileDialog1.FileName)
            Me.screen2.SaveSC2(SaveFileDialog1.FileName)
        End If

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


    Private Sub LoadSC2But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadSC2But.Click

        Me.OpenFileDialog1.DefaultExt = "sc2"
        Me.OpenFileDialog1.Filter = "Screen2 bin file|*.sc2|VRAM bin file|*.bin|All files|*.*"

        Me.OpenFileDialog1.FileName = ProjectFileName

        If Not Me.Path_SC2 = "" Then
            Me.OpenFileDialog1.InitialDirectory = Me.Path_SC2
        End If

        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadSC2(OpenFileDialog1.FileName)
            Me.Path_SC2 = Path.GetDirectoryName(OpenFileDialog1.FileName)
            Me.ProjectFileName = Path.GetFileNameWithoutExtension(OpenFileDialog1.FileName)
        End If

    End Sub



    Private Sub LoadSC2(ByVal filePath As String)
        Dim aName As String
        If Me.screen2.LoadSC2(filePath) = True Then
            aName = Path.GetFileNameWithoutExtension(filePath)
            Me.MapName = aName
            Me.TilesetsName = aName
            'ShowProjectNameData()
            NewProject(aName)
        Else
            MsgBox("The selected file type is not SC2", MsgBoxStyle.Critical, "Error")
        End If
    End Sub


    'Private Function LoadMsxBin(ByVal filePath As String) As Boolean
    '    '
    '    '
    '    '
    '    Dim aStream As New System.IO.FileStream(filePath, FileMode.Open)
    '    Dim aFile As New System.IO.FileInfo(filePath)
    '    'Dim ROMdata() As Byte
    '    Dim aFileData() As Byte

    '    Dim conta As Integer = 7

    '    Dim tamanyo As Integer = CInt(aFile.Length)
    '    aFileData = Nothing
    '    ReDim aFileData(tamanyo)

    '    aStream.Read(aFileData, 0, tamanyo)
    '    aStream.Close()


    '    '
    '    ' recoger datos del bin:
    '    ' direccion de inicio
    '    ' direccion de fin
    '    ' escribir en el buffer aScreen2

    '    ' <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
    '    ' cabecera del fichero binario para memoria de video, zona de nombre de patrones.
    '    'aFileData(0) = &HFE
    '    'aFileData(1) = &H0  'init_addr
    '    'aFileData(2) = &H0
    '    'aFileData(3) = &HFF 'end_addr
    '    'aFileData(4) = &H3F
    '    'aFileData(5) = &H0  'exec_addr - no se usa
    '    'aFileData(6) = &H0

    '    If aFileData(0) = &HFE Then

    '        Dim address As Integer = (aFileData(2) * 256) + aFileData(1)
    '        Dim dirend As Integer = (aFileData(4) * 256) + aFileData(3)

    '        'Dim aVRAMdata(16383) As Byte
    '        'Dim aTmpData() As Byte

    '        For i = address To dirend
    '            aScreen2.VPOKE(i, aFileData(conta))
    '            conta += 1
    '        Next

    '        aScreen2.SetVRAMPalette() ' for MSX2

    '        aScreen2.RefreshScreen()

    '        Return True

    '    Else
    '        'MsgBox("El fichero seleccionado no es tipo SC2", MsgBoxStyle.Critical, "Error")
    '        Return False
    '    End If

    'End Function





    Private Sub SavePNGBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SavePNGBut.Click

        Dim filePath As String

        Me.SaveFileDialog1.DefaultExt = "png"
        Me.SaveFileDialog1.Filter = "PNG file|*.png"

        Me.SaveFileDialog1.FileName = Me.ProjectFileName

        If Not Me.Path_Bitmap = "" Then
            Me.SaveFileDialog1.InitialDirectory = Me.Path_Bitmap
        End If

        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then

            filePath = SaveFileDialog1.FileName

            If Me.screenViewer = 0 Then
                Me.screen2.SaveTilesScreenPNG(filePath)
            Else
                Me.screen2.SaveScreenPNG(filePath)
            End If

            Path_Bitmap = Path.GetDirectoryName(filePath)

        End If

    End Sub



    Private Sub SaveCBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveTxtScrBut.Click

        If Me.Tiles_TxtOutput.Text.Length < 1 Then
            MsgBox("No data to save.", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        Dim filePath As String
        Dim resultado As System.Windows.Forms.DialogResult

        If Map_CodeOutComboB.SelectedIndex = MSXDataFormat.OutputFormat.C Then
            Me.SaveFileDialog1.DefaultExt = "C"
            Me.SaveFileDialog1.Filter = "C Source|*.C"
        ElseIf Map_CodeOutComboB.SelectedIndex = MSXDataFormat.OutputFormat.BASIC Then
            Me.SaveFileDialog1.DefaultExt = "BAS"
            Me.SaveFileDialog1.Filter = "BASIC Source|*.BAS"
        Else
            Me.SaveFileDialog1.DefaultExt = "ASM"
            Me.SaveFileDialog1.Filter = "ASM Source|*.ASM"
        End If

        Me.SaveFileDialog1.FileName = Path.GetFileNameWithoutExtension(Me.Path_Screen)


        resultado = SaveFileDialog1.ShowDialog()

        If Not resultado = Windows.Forms.DialogResult.OK Then
            Exit Sub
        End If

        filePath = SaveFileDialog1.FileName

        Dim aStreamWriterFile As New System.IO.StreamWriter(filePath)
        aStreamWriterFile.WriteLine(Tiles_TxtOutput.Text)
        aStreamWriterFile.Close()

    End Sub


    Private Sub SaveTilesCBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveTilesCBut.Click

        If Me.Tileset_TxtOutput.Text.Length < 1 Then
            MsgBox("No data to save.", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        Dim filePath As String
        Dim resultado As System.Windows.Forms.DialogResult

        If Tileset_CodeOutComboB.SelectedIndex = MSXDataFormat.OutputFormat.C Then
            Me.SaveFileDialog1.DefaultExt = "C"
            Me.SaveFileDialog1.Filter = "C Source|*.C"
        ElseIf Tileset_CodeOutComboB.SelectedIndex = MSXDataFormat.OutputFormat.BASIC Then
            Me.SaveFileDialog1.DefaultExt = "BAS"
            Me.SaveFileDialog1.Filter = "BASIC Source|*.BAS"
        Else
            Me.SaveFileDialog1.DefaultExt = "ASM"
            Me.SaveFileDialog1.Filter = "ASM Source|*.ASM"
        End If

        Me.SaveFileDialog1.FileName = Path.GetFileNameWithoutExtension(Me.Path_Tileset)

        resultado = SaveFileDialog1.ShowDialog()

        If Not resultado = Windows.Forms.DialogResult.OK Then
            Exit Sub
        End If

        filePath = SaveFileDialog1.FileName

        Dim aStreamWriterFile As New System.IO.StreamWriter(filePath)
        aStreamWriterFile.WriteLine(Tileset_TxtOutput.Text)
        aStreamWriterFile.Close()

    End Sub


    Private Sub CodeOutComboB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tileset_CodeOutComboB.SelectedIndexChanged
        Tileset_TxtOutput.Clear()

        If Tileset_CodeOutComboB.SelectedIndex = MSXDataFormat.OutputFormat.BASIC Then
            'Basic
            BasicConfigButton.Enabled = True
        Else
            Me.BasicConfigButton.Enabled = False
        End If

        Select Case Tileset_CodeOutComboB.SelectedIndex
            Case MSXDataFormat.OutputFormat.BASIC
                Tileset_NumSysComboBox.SelectedIndex = MSXDataFormat.DataFormat.DECIMAL_nnn

            Case MSXDataFormat.OutputFormat.C
                Tileset_NumSysComboBox.SelectedIndex = MSXDataFormat.DataFormat.HEXADECIMAL_0xnn

            Case MSXDataFormat.OutputFormat.ASM
                Tileset_NumSysComboBox.SelectedIndex = MSXDataFormat.DataFormat.HEXADECIMAL_0nnh

            Case MSXDataFormat.OutputFormat.ASM_SDCC
                Tileset_NumSysComboBox.SelectedIndex = MSXDataFormat.DataFormat.HEXADECIMAL_0xnn

        End Select

    End Sub


    Private Sub Map_CodeOutComboB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Map_CodeOutComboB.SelectedIndexChanged
        Tiles_TxtOutput.Clear()

        If Map_CodeOutComboB.SelectedIndex = MSXDataFormat.OutputFormat.BASIC Then
            'Basic
            BasicConfigButton2.Enabled = True
        Else
            BasicConfigButton2.Enabled = False
        End If

        Select Case Map_CodeOutComboB.SelectedIndex
            Case MSXDataFormat.OutputFormat.BASIC
                Map_NumSysComboBox.SelectedIndex = MSXDataFormat.DataFormat.DECIMAL_nnn

            Case MSXDataFormat.OutputFormat.C
                Map_NumSysComboBox.SelectedIndex = MSXDataFormat.DataFormat.HEXADECIMAL_0xnn

            Case MSXDataFormat.OutputFormat.ASM
                Map_NumSysComboBox.SelectedIndex = MSXDataFormat.DataFormat.HEXADECIMAL_0nnh

            Case MSXDataFormat.OutputFormat.ASM_SDCC
                Map_NumSysComboBox.SelectedIndex = MSXDataFormat.DataFormat.HEXADECIMAL_0xnn

        End Select

    End Sub


    ' Displays information of the cursor relative to the screen. 
    Private Sub aScreen2_MouseScreenData(ByVal x As Integer, ByVal y As Integer, ByVal nTile As Integer) Handles screen2.MouseScreenData
        PosxTextB.Text = Str(x)
        PosyTextB.Text = Str(y)
        TileTextB.Text = nTile 'Hex(nTile)
        If Me.screenViewer = 0 Then
            vaddrTextB.Text = getHexShort(screen2.BASE(TMS9918.NumberOfBase.Name_Table_Base_Address) + (y * 32) + x)
        Else
            vaddrTextB.Text = ""
        End If

    End Sub



    Private Sub TilesClearBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TilesClearBut.Click
        '
        Dim result As DialogResult

        Dim toolFillMapForm As New FillMapForm()
        result = toolFillMapForm.ShowDialog()

        If result = Windows.Forms.DialogResult.OK Then
            Me.screen2.FillVRAM(TMS9918.TableBase.GRPNAM, 767, toolFillMapForm.Tile)
            Me.screen2.RefreshScreen()
        End If

    End Sub



    Private Sub TilesOrderBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TilesOrderBut.Click

        Dim result As System.Windows.Forms.DialogResult

        '"This option will delete all data." + Chr(13) +
        result = MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Question")

        If result = Windows.Forms.DialogResult.Yes Then
            Me.screen2.OrderMap()
        End If


    End Sub



    Private Sub BlackitizerBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BlackitizerBut.Click

        Try
            Dim result As DialogResult

            Dim toolChangeColor As New ChangeColorForm(PaletteDialog.PaletteColors)
            result = toolChangeColor.ShowDialog()

            If result = Windows.Forms.DialogResult.OK Then
                ChangeColor(toolChangeColor.OldColor, toolChangeColor.NewColor)
            End If

        Catch ex As Exception

        End Try

    End Sub



    Private Sub ChangeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeButton.Click
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



    Private Sub ChangeColor(ByVal OldColor As Byte, ByVal NewColor As Byte)

        If OldColor > 15 Or NewColor > 15 Then
            Exit Sub
        End If

        Dim colorBase As Short = screen2.BASE(TMS9918.NumberOfBase.Color_Table_Base_Address)
        Dim avalue As Byte
        Dim colorInk As Byte
        Dim colorBG As Byte
        Dim i As Integer = 0

        For i = colorBase To colorBase + 6143
            avalue = Me.screen2.VPEEK(i)

            colorInk = (avalue And &HF0) / 16
            colorBG = avalue And &HF

            If colorInk = OldColor Then
                colorInk = NewColor
            End If
            If colorBG = OldColor Then
                colorBG = NewColor
            End If
            avalue = (colorInk * 16) + colorBG

            Me.screen2.VPOKE(i, avalue)
        Next

        screen2.RefreshScreen()

    End Sub



    ''' <summary>
    ''' Cambia todas las tiles con un cierto valor por otro
    ''' </summary>
    ''' <param name="OldNumTile"></param>
    ''' <param name="NewNumTile"></param>
    ''' <remarks></remarks>
    Private Sub ChangeTiles(ByVal OldNumTile As Byte, ByVal NewNumTile As Byte)

        Dim i As Integer = 0

        If OldNumTile > 255 Or NewNumTile > 255 Then
            Exit Sub
        End If

        Dim nameBase As Short = screen2.BASE(TMS9918.NumberOfBase.Name_Table_Base_Address)
        For i = nameBase To nameBase + 6143
            If screen2.VPEEK(i) = OldNumTile Then
                screen2.VPOKE(i, NewNumTile)
            End If
        Next

        screen2.RefreshScreen()

    End Sub


    'Private Sub CopyTilesetBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyTilesetBut.Click
    '    My.Computer.Clipboard.SetText(Me.Tileset_TxtOutput.Text)
    'End Sub


    'Private Sub CopyScrBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyScrBut.Click
    '    My.Computer.Clipboard.SetText(Me.Tiles_TxtOutput.Text)
    'End Sub


    Private Sub SetDefaultMapArea()
        startTileX.Text = 0
        startTileY.Text = 0
        endTileX.Text = 31
        endTileY.Text = 23
    End Sub

    Private Sub Map_areaResetButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Map_areaResetButton.Click
        SetDefaultMapArea()
    End Sub


    Private Sub aScreen2_MouseSelectedPos(ByVal startx As Integer, ByVal starty As Integer, ByVal endx As Integer, ByVal endy As Integer) Handles screen2.MouseSelectedPos
        If endx < startx Then
            'unselect area
            SetDefaultMapArea()
        Else
            startTileX.Text = startx
            startTileY.Text = starty
            endTileX.Text = endx
            endTileY.Text = endy
        End If


    End Sub


    Private Sub SaveTilesBinBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveTilesBinBut.Click

        Dim resultado As System.Windows.Forms.DialogResult

        Me.SaveFileDialog1.DefaultExt = "bin"
        Me.SaveFileDialog1.Filter = "bin file|*.bin"

        Me.SaveFileDialog1.FileName = Path.GetFileNameWithoutExtension(Me.Path_Tileset)

        resultado = SaveFileDialog1.ShowDialog()

        If resultado = Windows.Forms.DialogResult.OK Then

            'SaveTilesScreenBin(SaveFileDialog1.FileName)

        End If

    End Sub


    Private Sub SaveTilesetBin(ByVal filePath As String)



        'Me.BSAVE(filePath, 0, &H3FFF)

    End Sub


    ''' <summary>
    ''' validates the field, the first value range of the tileset 
    ''' valida el campo del primer valor de rango del tileset
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub IniTileTextBox_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles B0IniTile.Validating
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
    Private Sub EndTileTextBox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles B0EndTile.Validating
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


    Private Sub startTileX_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles startTileX.Validating
        validateTileX(sender, 0)
    End Sub


    Private Sub endTileX_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles endTileX.Validating
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


    Private Sub startTileY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles startTileY.Validating
        validateTileY(sender, 0)
    End Sub


    Private Sub endTileY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles endTileY.Validating
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
    Private Sub TabScrLabel_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TabScrLabel.MouseClick
        SetScreenViewer(0)
    End Sub

    Private Sub TabScrLabel_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabScrLabel.MouseEnter
        If screenViewer = 1 Then
            sender.ImageIndex = 1
        End If
    End Sub

    Private Sub TabScrLabel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabScrLabel.MouseLeave
        If screenViewer = 1 Then
            sender.ImageIndex = 0
        End If
    End Sub

    Private Sub TabTilesetLabel_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TabTilesetLabel.MouseClick
        SetScreenViewer(1)
    End Sub

    Private Sub TabTilesetLabel_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabTilesetLabel.MouseEnter
        If screenViewer = 0 Then
            sender.ImageIndex = 1
        End If
    End Sub

    Private Sub TabTilesetLabel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabTilesetLabel.MouseLeave
        If screenViewer = 0 Then
            sender.ImageIndex = 0
        End If
    End Sub



    ''' <summary>
    ''' Displays the selected view: screen or tileset.
    ''' Muestra la vista seleccionada: pantalla o tileset.
    ''' </summary>
    ''' <param name="state"></param>
    ''' <remarks></remarks>
    Private Sub SetScreenViewer(ByVal state As Integer)

        If state = 0 Then
            TabScrLabel.ImageIndex = 2
            TabTilesetLabel.ImageIndex = 0
            screenViewer = 0
            Me.screen2.VisibleTileSets = False
        ElseIf state = 1 Then
            TabScrLabel.ImageIndex = 0
            TabTilesetLabel.ImageIndex = 2
            screenViewer = 1
            Me.screen2.VisibleTileSets = True
        End If
    End Sub



    ''' <summary>
    ''' Show about window.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ShowAbout()
    End Sub



    Private Sub ShowAbout()
        Dim aboutWinObject As New AboutWin()
        aboutWinObject.ShowDialog()
    End Sub



    Private Sub setRepeated(ByRef RLEtmpData As ArrayList, ByVal value As Byte, ByVal numrep As Byte)
        RLEtmpData.Add(numrep)
        RLEtmpData.Add(value)
    End Sub


    Private PaletteDialog As New palette512Dialog


    Private Sub EditPaleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditPaleteButton.Click

        EditPalette()

    End Sub


    Private Sub SaveSC4But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveSC4But.Click

        EditPalette()

    End Sub


    Private Sub EditPalette()

        Dim result As DialogResult
        result = PaletteDialog.ShowWinDialog()

        If result = Windows.Forms.DialogResult.OK Then
            Me.screen2.SetPalette(PaletteDialog.PaletteColors)
            'Me.SpriteListBox1.RefreshPalette(PaletteDialog.PaletteColors)
            Me.screen2.RefreshScreen()

            Me.PaleteNameTextB.Text = PaletteDialog.PaletteColors.name
        End If

    End Sub


    Private Sub GetPaletteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetPaletteButton.Click
        Dim comments As New ArrayList
        'Dim tmpData() As Byte

        Dim outputSource As String = ""
        Dim linesize As Integer = 0

        linesize = CInt(Me.Palette_SizeLineComboB.SelectedItem)

        comments.Add(Me.screen2.GetPalette().name)


        Me.Palette_TxtOutput.Clear()

        ' show data in respective code language
        Select Case Palette_CodeOutComboB.SelectedIndex
            Case MSXDataFormat.OutputFormat.C
                comments.Add("RB,G")
                outputSource = genData.C_codeGen(Me.screen2.GetPalette().getData(), linesize, Me.Palette_NumSysCombo.SelectedIndex, Palette_FieldName.Text, comments)

            Case MSXDataFormat.OutputFormat.ASM
                comments.Add("RB,G")
                outputSource = genData.Asm_codeGen(Me.screen2.GetPalette().getData(), linesize, Me.Palette_NumSysCombo.SelectedIndex, Palette_FieldName.Text, comments, "db")

            Case MSXDataFormat.OutputFormat.ASM_SDCC
                comments.Add("RB,G")
                outputSource = genData.Asm_codeGen(Me.screen2.GetPalette().getData(), linesize, Me.Palette_NumSysCombo.SelectedIndex, Palette_FieldName.Text, comments, ".db")

            Case MSXDataFormat.OutputFormat.BASIC
                comments.Add("Num color, Red, Green, Blue")
                outputSource = genData.BasicMSX_codeGen(Me.screen2.GetPalette().GetDataBasic(), linesize, Me.Palette_NumSysCombo.SelectedIndex, BasicConfig.RemoveZeros, BasicConfig.StartingLine, BasicConfig.Interval, comments)

        End Select


        Me.Palette_TxtOutput.AppendText(outputSource)

    End Sub



    ' realiza cambios en la interfaz segun Lenguage de programacion seleccionado
    Private Sub Palette_CodeOutComboB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Palette_CodeOutComboB.SelectedIndexChanged

        Me.Palette_SizeLineComboB.Items.Clear()
        If Palette_CodeOutComboB.SelectedIndex = MSXDataFormat.OutputFormat.BASIC Then
            ' BASIC
            BasicConfigButton3.Enabled = True
            Me.Palette_SizeLineComboB.Items.AddRange(New Object() {"3", "6", "9", "18", "48"})
        Else
            BasicConfigButton3.Enabled = False
            Me.Palette_SizeLineComboB.Items.AddRange(New Object() {"2", "4", "8", "16", "32"})
        End If
        Me.Palette_SizeLineComboB.SelectedIndex = 0

        Select Case Palette_CodeOutComboB.SelectedIndex
            Case MSXDataFormat.OutputFormat.BASIC
                Palette_NumSysCombo.SelectedIndex = MSXDataFormat.DataFormat.DECIMAL_nnn

            Case MSXDataFormat.OutputFormat.C
                Palette_NumSysCombo.SelectedIndex = MSXDataFormat.DataFormat.HEXADECIMAL_0xnn

            Case MSXDataFormat.OutputFormat.ASM
                Palette_NumSysCombo.SelectedIndex = MSXDataFormat.DataFormat.HEXADECIMAL_0nnh

            Case MSXDataFormat.OutputFormat.ASM_SDCC
                Palette_NumSysCombo.SelectedIndex = MSXDataFormat.DataFormat.HEXADECIMAL_0xnn

        End Select


    End Sub




    Private Sub OptimizeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptimizeButton.Click
        Me.screen2.Optimize()

        'optimization has occurred successfully
        MsgBox("Optimization has occurred successfully.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Optimization")
    End Sub




    Private Sub InvertButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InvertButton.Click
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
            colorBase = screen2.BASE(TMS9918.NumberOfBase.Pattern_Generator_Base_Address)
            For i = colorBase To colorBase + 6143
                avalue = Me.screen2.VPEEK(i)
                Me.screen2.VPOKE(i, Not (avalue))
            Next
        End If


        If toColor Then
            colorBase = screen2.BASE(TMS9918.NumberOfBase.Color_Table_Base_Address)
            For i = colorBase To colorBase + 6143
                avalue = Me.screen2.VPEEK(i)

                colorInk = (avalue And &HF0) / 16
                colorBG = avalue And &HF

                avalue = (colorBG * 16) + colorInk

                Me.screen2.VPOKE(i, avalue)
            Next
        End If


        screen2.RefreshScreen()
    End Sub





    Private Sub LoadPNGBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadPNGBut.Click

        Me.OpenFileDialog1.DefaultExt = "png"
        Me.OpenFileDialog1.Filter = "PNG documents (.PNG)|*.png|GIF documents (.GIF)|*.gif"

        Me.OpenFileDialog1.FileName = ProjectFileName

        If Not Me.Path_Bitmap = "" Then
            Me.OpenFileDialog1.InitialDirectory = Me.Path_Bitmap
        End If

        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadBitmap(OpenFileDialog1.FileName)
            Me.Path_Bitmap = Path.GetDirectoryName(OpenFileDialog1.FileName)
            Me.ProjectFileName = Path.GetFileNameWithoutExtension(OpenFileDialog1.FileName)
        End If

    End Sub


    Private Sub LoadBitmap(ByVal filePath As String)

        Try
            Dim aName As String
            Dim newImage As Image = Image.FromFile(filePath)
            Dim myBitmap As New Bitmap(newImage, 256, 192)

            Me.screen2.OrderMap()
            Me.screen2.setScreenFromBitmap(myBitmap)
            Me.screen2.RefreshScreen()

            aName = Path.GetFileNameWithoutExtension(filePath)
            Me.MapName = aName
            Me.TilesetsName = aName
            'ShowProjectNameData()
            NewProject(aName)

        Catch ex As Exception
            MsgBox("Disk I/O error.", MsgBoxStyle.Critical, "Error")
        End Try

    End Sub



    Private Sub mainWindow_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragDrop
        Dim tmpstr() As String = e.Data.GetData("FileDrop", False)
        Dim tmpFilePath As String = tmpstr(0)
        Dim extension As String = Path.GetExtension(tmpFilePath).ToLower

        If extension = ".gif" Or extension = ".png" Then
            LoadBitmap(tmpFilePath)
        ElseIf extension = ".sc2" Then
            LoadSC2(tmpFilePath)
        End If

    End Sub



    Private Sub mainWindow_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub


    Private Sub AllBanksCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllBanksCheckBox.CheckedChanged
        If AllBanksCheckBox.Checked Then
            BanksTabcontrol.Visible = False
            AllBanksPanel.Visible = True
        Else
            AllBanksPanel.Visible = False
            BanksTabcontrol.Visible = True
        End If
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BasicConfigButton.Click
        BasicConfig.ShowDialog()
    End Sub

    Private Sub BasicConfigButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BasicConfigButton2.Click
        BasicConfig.ShowDialog()
    End Sub

    Private Sub BasicConfigButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BasicConfigButton3.Click
        BasicConfig.ShowDialog()
    End Sub


    Private Sub SaveSCProjectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveSCProjectButton.Click

        Me.SaveFileDialog1.DefaultExt = ScreenDocumentExtension
        Me.SaveFileDialog1.Filter = "Open Document SCreen Project file|*." + ScreenDocumentExtension

        Me.SaveFileDialog1.FileName = Me.ProjectFileName

        If Not Me.Path_Project = "" Then
            Me.SaveFileDialog1.InitialDirectory = Me.Path_Project
        End If

        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then

            SaveData(SaveFileDialog1.FileName)
            Me.Path_Project = Path.GetDirectoryName(SaveFileDialog1.FileName)

        End If

    End Sub



    Private Sub LoadSCProjectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadSCProjectButton.Click

        Me.OpenFileDialog1.DefaultExt = ScreenDocumentExtension
        Me.OpenFileDialog1.Filter = "Open Document SCreen Project file|*." + ScreenDocumentExtension

        Me.OpenFileDialog1.FileName = Me.ProjectFileName

        If Not Me.Path_Project = "" Then
            Me.OpenFileDialog1.InitialDirectory = Me.Path_Project
        End If

        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadData(OpenFileDialog1.FileName)
            Me.Path_Project = Path.GetDirectoryName(OpenFileDialog1.FileName)
            Me.ProjectFileName = Path.GetFileNameWithoutExtension(OpenFileDialog1.FileName)
        End If

    End Sub



    Private Sub ProjectDataButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProjectDataButton.Click
        setProjectInfo()
    End Sub



    ''' <summary>
    ''' Opens the project information editing window.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setProjectInfo()

        Dim ProjectProperties As New ProjectPropertiesWin

        ProjectProperties.ProjectName = Me.ProjectName
        ProjectProperties.ProjectVersion = Me.ProjectVersion
        ProjectProperties.ProjectGroup = Me.ProjectGroup
        ProjectProperties.ProjectAuthor = Me.ProjectAuthor
        ProjectProperties.ProjectDescription = Me.ProjectDescription
        ProjectProperties.ProjectStartDate = Me.ProjectStartDate
        ProjectProperties.ProjectLastUpdate = Me.ProjectLastUpdate

        If ProjectProperties.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.ProjectName = ProjectProperties.ProjectName
            Me.ProjectVersion = ProjectProperties.ProjectVersion
            Me.ProjectGroup = ProjectProperties.ProjectGroup
            Me.ProjectAuthor = ProjectProperties.ProjectAuthor
            Me.ProjectDescription = ProjectProperties.ProjectDescription
        End If

    End Sub


    Private Sub NewProject(ByVal name As String)
        Me.ProjectName = name
        Me.ProjectVersion = "0"
        Me.ProjectGroup = ""
        Me.ProjectAuthor = ""
        Me.ProjectDescription = ""
        Me.ProjectStartDate = DateTime.Today.Ticks

        LoadScrText.Text = Me.MapName + ".scr"
        LoadTilText.Text = Me.TilesetsName + ".til"
    End Sub



    Private Sub LoadTilesetButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadTilesetButton.Click
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



    Private Sub LoadMapButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadMapButton.Click
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



    Private Sub SaveMapButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveMapButton.Click
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



    Private Sub SaveTilesetsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveTilesetsButton.Click
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


   
    Private Sub LoadPaletteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadPaletteButton.Click
        PaletteDialog.LoadFile()
    End Sub

    Private Sub SavePaletteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SavePaletteButton.Click
        PaletteDialog.SaveFile()
    End Sub


    
End Class
