Imports System.Xml
Imports System.IO

Public Class Config

    Private ConfigFileName As String = "tMSgfX"

    Private ConfigPath As String

    'Public PathTmsgfxPresentation As String = "tMSgfX."

    'Private AppID As String

    'Public _PathProject As String = ""
    'Public lastPathProject As String = ""
    'Public PathProject_Type As PATH_TYPE = 0

    'Public PathMap As String = ""
    'Public PathTileset As String = ""
    'Public PathSprite As String = ""
    'Public PathOAM As String = ""
    'Public PathPalette As String = ""

    'Public Path_MSXBasicBinary As String = ""
    'Public PathBinary As String = ""
    'Public PathBitmap As String = ""
    'Public PathNMSXtiles As String = ""



    ' -----
    Public PathItemProject As New PathItem
    Public PathItemMap As New PathItem
    Public PathItemTileset As New PathItem
    Public PathItemPalette As New PathItem
    Public PathItemSprite As New PathItem
    Public PathItemOAM As New PathItem
    Public PathItemSupertile As New PathItem

    Public PathPicture As New PathItem

    Public PathByteGen As New PathItem

    Public PathItemMSXBASIC As New PathItem
    Public PathItemBinary As New PathItem
    Public PathItemBitmap As New PathItem
    Public PathItemNMSXtiles As New PathItem
    ' -----


    Public defAuthor As String
    Public defCodeOutput As Integer = DataFormat.ProgrammingLanguage.ASSEMBLER
    Public defCodeNumberFormat As Integer = 4
    Public defCodeSizeLine As Integer = 1     ' 0-3 (8,16,24,32)
    Public defCodeCompressType As Integer = 0 ' RAW
    Public defAsmByteCommand As String = "DB"
    Public defAsmWordDataCommand As String = "DW"
    Public defCByteCommand As String = "const char"

    Public defBASICinstruction As String = "DATA"
    Public defBASICinitLine As Integer = 1000
    Public defBASICincLines As Integer = 10
    Public defBASICremove0 As Boolean = False

    Public defDataLabel As String = "DATA"


    Public Shadows Enum FIRST_PROJECT As Integer
        PRESENTATION
        NEWPROJECT
        LASTPROJECT
    End Enum


    Public firstProjectType As FIRST_PROJECT = FIRST_PROJECT.NEWPROJECT

    Public PathLastProject As String = ""

    Public ZeroColor As Color = Color.FromArgb(255, 40, 40, 55) '.ToArgb  'default zero color
    Public GridColor As Color = Color.LightSkyBlue  '.ToArgb


    Public lastCodeOutput As Integer
    Public lastCodeNumberFormat As Integer
    Private _lastCodeSizeLine As Integer
    Public lastCodeCompressType As Integer
    Public lastAsmByteCommand As String
    Public lastAsmWordDataCommand As String
    Public lastCByteCommand As String
    Public lastBASICinstruction As String

    Public lastBASICinitLine As Integer
    Public lastBASICincLines As Integer
    Public lastBASICremove0 As Boolean = False

    Private LastProjects As New Hashtable  'RecentProjectsList



    Public Shadows Const Extension_byteGEN As String = "XBYT"



    Public Shadows Const Extension_BINARY As String = "BIN"



    ' 0-3 (8,16,24,32)
    Public Property lastCodeSizeLine() As Integer
        Get
            Return _lastCodeSizeLine
        End Get
        Set(value As Integer)
            If value < 4 Then
                _lastCodeSizeLine = value
            End If
        End Set
    End Property


    Public Shadows Enum PATH_TYPE As Integer
        APP
        LAST_USED
        USER
    End Enum


    'Public PathTmsgfxPresentation As String = "tMSgfX." ' + MSXOpenDocumentIO.Extension_ProjectDocument
    'Public ReadOnly Property PathTmsgfxTitle As String
    '    Get
    '        Return "tMSgfX." + mSXdevtools.FileDataTypes.MSXOpenDocumentIO.Extension_ProjectDocument
    '    End Get
    'End Property


    'Public Property PathProject() As String
    '    Get
    '        Select Case Me.PathProject_Type
    '            Case PATH_TYPE.LAST_USED
    '                Return Me._PathProject
    '            Case PATH_TYPE.USER
    '                Return Me._PathProject
    '            Case Else
    '                Return Application.StartupPath
    '        End Select
    '    End Get
    '    Set(ByVal value As String)
    '        Me._PathProject = value
    '    End Set
    'End Property


    'Application.StartupPath + Path.DirectorySeparatorChar + ConfigFileName



    Public Sub New() ', ByVal _appID As String
        Me.ConfigPath = Application.StartupPath + Path.DirectorySeparatorChar + ConfigFileName + ".config"
        Me.defAuthor = Environment.UserName   'My.User.Name
    End Sub



    Public Sub New(ByVal _configFileName As String) ', ByVal _appID As String
        Me.ConfigFileName = _configFileName
        Me.ConfigPath = Application.StartupPath + Path.DirectorySeparatorChar + ConfigFileName + ".config"
        Me.defAuthor = Environment.UserName   'My.User.Name
    End Sub



    'Public Sub SetApplicationConfig(ByVal _appID As String)
    '    Me.AppID = _appID
    'End Sub


    Public Sub AddRecentProject(ByVal path As String, ByVal appID As String)

        If Not Me.LastProjects.ContainsKey(appID) Then
            Me.LastProjects.Add(appID, New LastProjectsList)
        End If

        'Dim projectsList As RecentProjectsList = Me.RecentProjects.Item(appID)
        Me.LastProjects.Item(appID).Add(path)

    End Sub



    Public Function GetRecentProjectList(ByVal appID As String) As LastProjectsList

        If Me.LastProjects.ContainsKey(appID) Then
            Return Me.LastProjects.Item(appID)
        Else
            Return Nothing
        End If

    End Function



    Public Function Load() As Boolean

        Dim result As Boolean = False

        Try
            Dim aXmlDoc As New XmlDocument
            Dim rootNode As XmlNode
            Dim groupNode As XmlNode
            Dim aNode As XmlNode
            'Dim subNode As XmlNode
            Dim aNodeList As XmlNodeList
            Dim subnodeList As XmlNodeList
            Dim aValue As String
            'Dim anotherValue As String

            'Dim projectsList As RecentProjectsList

            Dim tmpAppID As String
            Dim tmpRecentList As LastProjectsList

            Dim tmpList As SortedList
            Dim itemIndex As Integer

            'Dim ConfigFileAdress As String = Me.ConfigPath 'System.AppDomain.CurrentDomain.BaseDirectory + Me.ConfigFileName


            If System.IO.File.Exists(Me.ConfigPath) Then

                aXmlDoc.Load(Me.ConfigPath)

                rootNode = aXmlDoc.SelectSingleNode("config")
                If Not rootNode Is Nothing Then

                    Me.LastProjects.Clear()

                    '#####################################
                    groupNode = rootNode.SelectSingleNode("paths")
                    If Not groupNode Is Nothing Then
                        aNode = groupNode.SelectSingleNode("PathProject")
                        Me.PathItemProject = getPathItemFromNode(aNode)

                        aNode = groupNode.SelectSingleNode("PathMap")
                        Me.PathItemMap = getPathItemFromNode(aNode)

                        aNode = groupNode.SelectSingleNode("PathTileset")
                        Me.PathItemTileset = getPathItemFromNode(aNode)

                        aNode = groupNode.SelectSingleNode("PathSprite")
                        Me.PathItemSprite = getPathItemFromNode(aNode)

                        aNode = groupNode.SelectSingleNode("PathOAM")
                        Me.PathItemOAM = getPathItemFromNode(aNode)

                        aNode = groupNode.SelectSingleNode("PathSupertile")
                        Me.PathItemSupertile = getPathItemFromNode(aNode)

                        aNode = groupNode.SelectSingleNode("PathPicture")
                        Me.PathPicture = getPathItemFromNode(aNode)

                        aNode = groupNode.SelectSingleNode("PathByteGen")
                        Me.PathByteGen = getPathItemFromNode(aNode)

                        aNode = groupNode.SelectSingleNode("PathPalette")
                        Me.PathItemPalette = getPathItemFromNode(aNode)

                        aNode = groupNode.SelectSingleNode("PathMSXBasic")
                        Me.PathItemMSXBASIC = getPathItemFromNode(aNode)

                        aNode = groupNode.SelectSingleNode("PathBinary")
                        Me.PathItemBinary = getPathItemFromNode(aNode)

                        aNode = groupNode.SelectSingleNode("PathBitmap")
                        Me.PathItemBitmap = getPathItemFromNode(aNode)

                        aNode = groupNode.SelectSingleNode("PathNMSXtiles")
                        Me.PathItemNMSXtiles = getPathItemFromNode(aNode)
                    End If
                    '#####################################


                    '#####################################
                    groupNode = rootNode.SelectSingleNode("defCode")
                    If Not groupNode Is Nothing Then
                        aNode = groupNode.SelectSingleNode("defCodeOutput")
                        If aNode Is Nothing Then
                            Me.defCodeOutput = 2 'MSXDataFormat.OutputFormat.ASM
                        Else
                            Me.defCodeOutput = CInt(aNode.InnerText)
                        End If

                        aNode = groupNode.SelectSingleNode("defCodeNumberFormat")
                        If aNode Is Nothing Then
                            Me.defCodeNumberFormat = 4
                        Else
                            Me.defCodeNumberFormat = CInt(aNode.InnerText)
                        End If

                        aNode = groupNode.SelectSingleNode("defCodeSizeLine")
                        If aNode Is Nothing Then
                            Me.defCodeSizeLine = 1
                        Else
                            Me.defCodeSizeLine = CInt(aNode.InnerText)
                        End If

                        aNode = groupNode.SelectSingleNode("defCodeCompressType")
                        If aNode Is Nothing Then
                            Me.defCodeCompressType = 0
                        Else
                            Me.defCodeCompressType = CInt(aNode.InnerText)
                        End If

                        aNode = groupNode.SelectSingleNode("defAsmByteCommand")
                        If aNode Is Nothing Then
                            Me.defAsmByteCommand = "DB"
                        Else
                            Me.defAsmByteCommand = aNode.InnerText
                        End If

                        aNode = groupNode.SelectSingleNode("defAsmWordCommand")
                        If aNode Is Nothing Then
                            Me.defAsmWordDataCommand = "DW"
                        Else
                            Me.defAsmWordDataCommand = aNode.InnerText
                        End If

                        aNode = groupNode.SelectSingleNode("defCByteCommand")
                        If aNode Is Nothing Then
                            Me.defCByteCommand = "const char"
                        Else
                            Me.defCByteCommand = aNode.InnerText
                        End If


                        aNode = groupNode.SelectSingleNode("defBASICinstruction")
                        If aNode Is Nothing Then
                            Me.defBASICinstruction = "DATA"
                        Else
                            Me.defBASICinstruction = aNode.InnerText
                        End If

                        aNode = groupNode.SelectSingleNode("defDataLabel")
                        If aNode Is Nothing Then
                            Me.defDataLabel = "DATA"
                        Else
                            Me.defDataLabel = aNode.InnerText
                        End If

                        aNode = groupNode.SelectSingleNode("defBASICinitLine")
                        If aNode Is Nothing Then
                            Me.defBASICinitLine = 1000
                        Else
                            Me.defBASICinitLine = CInt(aNode.InnerText)
                        End If

                        aNode = groupNode.SelectSingleNode("defBASICincLines")
                        If aNode Is Nothing Then
                            Me.defBASICincLines = 10
                        Else
                            Me.defBASICincLines = CInt(aNode.InnerText)
                        End If

                        aNode = groupNode.SelectSingleNode("defBASICremove0")
                        If aNode Is Nothing Then
                            Me.defBASICremove0 = False
                        Else
                            Me.defBASICremove0 = CBool(aNode.InnerText.ToUpper = "TRUE")
                        End If
                    End If
                    '#####################################




                    '#####################################
                    groupNode = rootNode.SelectSingleNode("others")
                    If Not groupNode Is Nothing Then

                        aNode = groupNode.SelectSingleNode("defAuthor")
                        If aNode Is Nothing Then
                            Me.defAuthor = Environment.UserName   'My.User.Name
                        Else
                            Me.defAuthor = aNode.InnerText
                        End If

                        aNode = groupNode.SelectSingleNode("firstProjectType")
                        If aNode Is Nothing Then
                            Me.firstProjectType = 0
                        Else
                            Me.firstProjectType = CInt(aNode.InnerText)
                        End If

                        aNode = groupNode.SelectSingleNode("PathLastProject")
                        If aNode Is Nothing Then
                            Me.PathLastProject = ""
                        Else
                            Me.PathLastProject = aNode.InnerText
                        End If

                        aNode = groupNode.SelectSingleNode("ZeroColor")
                        If aNode Is Nothing Then
                            Me.ZeroColor = Color.DarkGray '.ToArgb
                        Else
                            Me.ZeroColor = Color.FromArgb(CInt(aNode.InnerText))
                        End If

                        aNode = groupNode.SelectSingleNode("GridColor")
                        If aNode Is Nothing Then
                            Me.GridColor = Color.LightSkyBlue '.ToArgb
                        Else
                            Me.GridColor = Color.FromArgb(CInt(aNode.InnerText))
                        End If

                    End If
                    '#####################################



                    '#####################################
                    aNodeList = rootNode.SelectNodes("LastProjects/list")
                    If aNodeList Is Nothing Then
                        'Me.RecentProjects = New RecentProjectsList

                    Else

                        For Each nodeList As XmlNode In aNodeList

                            aNode = nodeList.SelectSingleNode("@id")
                            If Not aNode Is Nothing Then
                                tmpAppID = aNode.InnerText
                                tmpList = New SortedList

                                subnodeList = nodeList.SelectNodes("item")
                                For Each aNodeItem As XmlNode In subnodeList
                                    aNode = aNodeItem.SelectSingleNode("@index")
                                    itemIndex = CInt(aNode.InnerText)
                                    'itemIndex = CInt(aNodeItem.Attributes.GetNamedItem("index").InnerText)

                                    aNode = aNodeItem.SelectSingleNode("@path")
                                    aValue = aNode.InnerText
                                    'aValue = aNodeItem.Attributes.GetNamedItem("path").InnerText

                                    tmpList.Add(itemIndex, aValue)
                                Next

                                tmpRecentList = New LastProjectsList(tmpList)
                                Me.LastProjects.Add(tmpAppID, tmpRecentList)

                            End If

                        Next

                    End If

                    result = True

                Else
                    result = False
                End If

            Else
                result = False
            End If


        Catch ex As Exception
            ' error! No se ha podido cargar la configuración
            result = False
        End Try

        If result = False Then
            Me.PathItemProject = New PathItem  'Application.StartupPath System.AppDomain.CurrentDomain.BaseDirectory
            Me.PathItemMap = New PathItem
            Me.PathItemTileset = New PathItem
            Me.PathItemSprite = New PathItem
            Me.PathItemOAM = New PathItem
            Me.PathItemPalette = New PathItem
            Me.PathItemSupertile = New PathItem

            Me.PathPicture = New PathItem

            Me.PathByteGen = New PathItem

            Me.PathItemMSXBASIC = New PathItem
            Me.PathItemBinary = New PathItem
            Me.PathItemBitmap = New PathItem
            Me.PathItemNMSXtiles = New PathItem
        End If

        InitOutputInfo()

        Return result

    End Function



    Private Function getPathItemFromNode(ByRef aNode As XmlNode) As PathItem

        Dim _pathItem As New PathItem

        Dim subNode As XmlNode

        Try

            If aNode Is Nothing Then
                _pathItem = New PathItem
            Else
                subNode = aNode.SelectSingleNode("@type")
                If subNode Is Nothing Then
                    _pathItem.TypePath = PATH_TYPE.APP
                Else
                    _pathItem.TypePath = CInt(subNode.InnerText)
                    If _pathItem.TypePath > 1 Then
                        _pathItem.TypePath = PATH_TYPE.APP
                    End If
                End If
                'Me.PathItemProject.Path = aNode.InnerText

                subNode = aNode.SelectSingleNode("@pathUser")
                If Not subNode Is Nothing Then
                    '    _pathItem.pathUser = ""
                    'Else
                    _pathItem.pathUser = subNode.InnerText
                End If

                subNode = aNode.SelectSingleNode("@pathLast")
                If subNode Is Nothing Then
                    _pathItem.pathLast = _pathItem.pathUser
                Else
                    _pathItem.pathLast = subNode.InnerText
                End If
            End If

        Catch ex As Exception

        End Try

        Return _pathItem

    End Function



    Public Sub Save()
        Try

            Dim aXmlDoc As New XmlDocument
            'Dim ConfigFileAdress As String = System.AppDomain.CurrentDomain.BaseDirectory + Me.ConfigFileName
            Dim rootElement As XmlElement
            Dim groupElement As XmlElement
            Dim txtElement As XmlText
            Dim anElement As XmlElement

            Dim anAttribute As XmlAttribute

            Dim aListElement As XmlElement
            Dim anItemElement As XmlElement

            Dim tmpList As LastProjectsList

            ' crea el nodo root
            rootElement = aXmlDoc.CreateElement("config")
            aXmlDoc.AppendChild(rootElement)

            anAttribute = aXmlDoc.CreateAttribute("app")
            anAttribute.Value = My.Application.Info.ProductName
            rootElement.SetAttributeNode(anAttribute)

            anAttribute = aXmlDoc.CreateAttribute("version")
            anAttribute.Value = My.Application.Info.Version.ToString + "b"
            rootElement.SetAttributeNode(anAttribute)



            ' ###################################################
            groupElement = aXmlDoc.CreateElement("paths")
            rootElement.AppendChild(groupElement)

            'anElement = aXmlDoc.CreateElement("PathProject")
            'If (Not Me.PathItemProject.TypePath = PathItem.PATH_TYPE.APP) Then
            '    txtElement = aXmlDoc.CreateTextNode(Me.PathItemProject.Path)
            '    anElement.AppendChild(txtElement)
            'End If
            'groupElement.AppendChild(anElement)
            'anAttribute = aXmlDoc.CreateAttribute("type")
            'anAttribute.Value = CStr(Me.PathItemProject.TypePath)
            anElement = getElementPath(aXmlDoc, "PathProject", Me.PathItemProject)
            groupElement.AppendChild(anElement)

            anElement = getElementPath(aXmlDoc, "PathMap", Me.PathItemMap)
            groupElement.AppendChild(anElement)

            anElement = getElementPath(aXmlDoc, "PathTileset", Me.PathItemTileset)
            groupElement.AppendChild(anElement)

            anElement = getElementPath(aXmlDoc, "PathSprite", Me.PathItemSprite)
            groupElement.AppendChild(anElement)

            anElement = getElementPath(aXmlDoc, "PathOAM", Me.PathItemOAM)
            groupElement.AppendChild(anElement)

            anElement = getElementPath(aXmlDoc, "PathSupertile", Me.PathItemSupertile)
            groupElement.AppendChild(anElement)

            anElement = getElementPath(aXmlDoc, "PathPicture", Me.PathPicture)
            groupElement.AppendChild(anElement)

            anElement = getElementPath(aXmlDoc, "PathByteGen", Me.PathByteGen)
            groupElement.AppendChild(anElement)

            anElement = getElementPath(aXmlDoc, "PathPalette", Me.PathItemPalette)
            groupElement.AppendChild(anElement)

            anElement = getElementPath(aXmlDoc, "PathMSXBasic", Me.PathItemMSXBASIC)
            groupElement.AppendChild(anElement)

            anElement = getElementPath(aXmlDoc, "PathBinary", Me.PathItemBinary)
            groupElement.AppendChild(anElement)

            anElement = getElementPath(aXmlDoc, "PathBitmap", Me.PathItemBitmap)
            groupElement.AppendChild(anElement)

            anElement = getElementPath(aXmlDoc, "PathNMSXtiles", Me.PathItemNMSXtiles)
            groupElement.AppendChild(anElement)
            ' ###################################################


            ' ###################################################
            groupElement = aXmlDoc.CreateElement("defCode")
            rootElement.AppendChild(groupElement)

            anElement = aXmlDoc.CreateElement("defCodeOutput")
            txtElement = aXmlDoc.CreateTextNode(CStr(Me.defCodeOutput))
            anElement.AppendChild(txtElement)
            groupElement.AppendChild(anElement)

            anElement = aXmlDoc.CreateElement("defCodeNumberFormat")
            txtElement = aXmlDoc.CreateTextNode(CStr(Me.defCodeNumberFormat))
            anElement.AppendChild(txtElement)
            groupElement.AppendChild(anElement)

            anElement = aXmlDoc.CreateElement("defCodeSizeLine")
            txtElement = aXmlDoc.CreateTextNode(CStr(Me.defCodeSizeLine))
            anElement.AppendChild(txtElement)
            groupElement.AppendChild(anElement)

            anElement = aXmlDoc.CreateElement("defCodeCompressType")
            txtElement = aXmlDoc.CreateTextNode(CStr(Me.defCodeCompressType))
            anElement.AppendChild(txtElement)
            groupElement.AppendChild(anElement)

            anElement = aXmlDoc.CreateElement("defAsmByteCommand")
            txtElement = aXmlDoc.CreateTextNode(Me.defAsmByteCommand)
            anElement.AppendChild(txtElement)
            groupElement.AppendChild(anElement)

            anElement = aXmlDoc.CreateElement("defAsmWordCommand")
            txtElement = aXmlDoc.CreateTextNode(Me.defAsmWordDataCommand)
            anElement.AppendChild(txtElement)
            groupElement.AppendChild(anElement)

            anElement = aXmlDoc.CreateElement("defCByteCommand")
            txtElement = aXmlDoc.CreateTextNode(Me.defCByteCommand)
            anElement.AppendChild(txtElement)
            groupElement.AppendChild(anElement)

            anElement = aXmlDoc.CreateElement("defBASICinstruction")
            txtElement = aXmlDoc.CreateTextNode(Me.defBASICinstruction)
            anElement.AppendChild(txtElement)
            groupElement.AppendChild(anElement)

            anElement = aXmlDoc.CreateElement("defDataLabel")
            txtElement = aXmlDoc.CreateTextNode(Me.defDataLabel)
            anElement.AppendChild(txtElement)
            groupElement.AppendChild(anElement)

            anElement = aXmlDoc.CreateElement("defBASICinitLine")
            txtElement = aXmlDoc.CreateTextNode(CStr(Me.defBASICinitLine))
            anElement.AppendChild(txtElement)
            groupElement.AppendChild(anElement)

            anElement = aXmlDoc.CreateElement("defBASICincLines")
            txtElement = aXmlDoc.CreateTextNode(CStr(Me.defBASICincLines))
            anElement.AppendChild(txtElement)
            groupElement.AppendChild(anElement)

            anElement = aXmlDoc.CreateElement("defBASICremove0")
            txtElement = aXmlDoc.CreateTextNode(CStr(Me.defBASICremove0))
            anElement.AppendChild(txtElement)
            groupElement.AppendChild(anElement)
            ' ###################################################



            ' ###################################################
            groupElement = aXmlDoc.CreateElement("others")
            rootElement.AppendChild(groupElement)

            anElement = aXmlDoc.CreateElement("defAuthor")
            txtElement = aXmlDoc.CreateTextNode(Me.defAuthor)
            anElement.AppendChild(txtElement)
            groupElement.AppendChild(anElement)

            anElement = aXmlDoc.CreateElement("firstProjectType")
            txtElement = aXmlDoc.CreateTextNode(CStr(Me.firstProjectType))
            anElement.AppendChild(txtElement)
            groupElement.AppendChild(anElement)

            anElement = aXmlDoc.CreateElement("PathLastProject")
            txtElement = aXmlDoc.CreateTextNode(Me.PathLastProject)
            anElement.AppendChild(txtElement)
            groupElement.AppendChild(anElement)

            anElement = aXmlDoc.CreateElement("ZeroColor")
            txtElement = aXmlDoc.CreateTextNode(CStr(Me.ZeroColor.ToArgb))
            anElement.AppendChild(txtElement)
            groupElement.AppendChild(anElement)

            anElement = aXmlDoc.CreateElement("GridColor")
            txtElement = aXmlDoc.CreateTextNode(CStr(Me.GridColor.ToArgb))
            anElement.AppendChild(txtElement)
            groupElement.AppendChild(anElement)
            ' ###################################################



            ' ###################################################
            anElement = aXmlDoc.CreateElement("LastProjects")
            rootElement.AppendChild(anElement)


            For Each _appID As String In Me.LastProjects.Keys
                tmpList = Me.LastProjects.Item(_appID)

                aListElement = aXmlDoc.CreateElement("list")
                anElement.AppendChild(aListElement)

                anAttribute = aXmlDoc.CreateAttribute("id")
                anAttribute.Value = _appID
                aListElement.SetAttributeNode(anAttribute)

                For i As Integer = 0 To tmpList.Count - 1
                    anItemElement = aXmlDoc.CreateElement("item")
                    aListElement.AppendChild(anItemElement)

                    anAttribute = aXmlDoc.CreateAttribute("index")
                    anAttribute.Value = CStr(i)
                    anItemElement.SetAttributeNode(anAttribute)

                    anAttribute = aXmlDoc.CreateAttribute("path")
                    anAttribute.Value = tmpList.GetFileItem(i).Path
                    anItemElement.SetAttributeNode(anAttribute)
                Next
            Next

            '
            aXmlDoc.Save(Me.ConfigPath)


        Catch ex As Exception
            ' error! No se ha podido guardar la configuración
        End Try
    End Sub



    Private Function getElementPath(ByRef aXmlDoc As XmlDocument, _name As String, ByVal _pathItem As PathItem) As XmlElement

        'Dim txtElement As XmlText
        Dim anElement As XmlElement
        Dim anAttribute As XmlAttribute

        anElement = aXmlDoc.CreateElement(_name)

        'If (Not _pathItem.TypePath = PathItem.PATH_TYPE.APP) Then
        'txtElement = aXmlDoc.CreateTextNode(_pathItem.Path)
        'anElement.AppendChild(txtElement)

        'If Not _pathItem.pathUser = Application.StartupPath Then
        anAttribute = aXmlDoc.CreateAttribute("pathUser")
        anAttribute.Value = CStr(_pathItem.pathUser)
        anElement.SetAttributeNode(anAttribute)
        'End If

        'If Not _pathItem.pathLast = Application.StartupPath Then
        anAttribute = aXmlDoc.CreateAttribute("pathLast")
        anAttribute.Value = CStr(_pathItem.pathLast)
        anElement.SetAttributeNode(anAttribute)
        'End If

        'End If
        'groupElement.AppendChild(anElement)
        anAttribute = aXmlDoc.CreateAttribute("type")
        anAttribute.Value = CStr(_pathItem.TypePath)
        anElement.SetAttributeNode(anAttribute)

        Return anElement

    End Function



    Public Sub InitOutputInfo()

        Me.lastCodeOutput = Me.defCodeOutput
        Me.lastCodeNumberFormat = Me.defCodeNumberFormat
        Me.lastCodeSizeLine = Me.defCodeSizeLine
        Me.lastCodeCompressType = Me.defCodeCompressType
        Me.lastAsmByteCommand = Me.defAsmByteCommand
        Me.lastAsmWordDataCommand = Me.defAsmWordDataCommand
        Me.lastCByteCommand = Me.defCByteCommand
        Me.lastBASICinstruction = Me.defBASICinstruction

        Me.lastBASICinitLine = Me.defBASICinitLine
        Me.lastBASICincLines = Me.defBASICincLines
        Me.lastBASICremove0 = Me.defBASICremove0

    End Sub



End Class
