Imports System.IO
Imports System.Xml
'Imports mSXdevtools.GUIcontrols



Public Class MSXOpenDocumentIO

    Private AppConfig As Config
    Public Project As tMSgfXProject


    ' file extensions
    Public Shadows Const Extension_ProjectDocument As String = "SXSCP"
    Public Shadows Const Extension_ScreenDocument As String = "SXSCR"
    Public Shadows Const Extension_TilesetDocument As String = "SXTIL"
    Public Shadows Const Extension_SupertileDocument As String = "SX2TIL"
    Public Shadows Const Extension_MapDocument As String = "SXMAP"
    Public Shadows Const Extension_SpriteDocument As String = "SXSPR"
    Public Shadows Const Extension_OldSpriteDocument As String = "XSPR"
    Public Shadows Const Extension_SpriteOAMDocument As String = "SXOAM"
    Public Shadows Const Extension_PaletteDocument As String = "SXPAL"
    Public Shadows Const Extension_PictureDocument As String = "SXPIC"


    Public Shadows Const ROOT As String = "msxOpenDocument"
    Public Shadows Const ROOT_APP As String = "app"
    Public Shadows Const ROOT_VER As String = "version"

    Public Shadows Const INFO As String = "info"

    Public Shadows Const TILESETS As String = "gfx" 'tiles?
    Public Shadows Const TILESETS_SET As String = "tileset"
    Public Shadows Const TILESETS_ITEM As String = "tile"

    Public Shadows Const MAPS As String = "maps" 'Maps Collection
    Public Shadows Const MAPS_ITEM As String = "map"
    Public Shadows Const MAPS_LINE As String = "line"

    Public Shadows Const SPRITES As String = "sprites"
    Public Shadows Const SPRITES_SET As String = "spriteset"
    Public Shadows Const SPRITES_ITEM As String = "sprite"

    Public Shadows Const PALETTES As String = "palettes"
    Public Shadows Const PALETTES_PAL As String = "palette"
    Public Shadows Const PALETTES_ITEM As String = "color"

    Public Shadows Const SCREENS As String = "screens"
    Public Shadows Const SCREENS_ITEM As String = "screen"

    Public Shadows Const SUPERTILESETS As String = "supertiles" 'squaredPRJ
    Public Shadows Const SUPERTILESETS_SET As String = "supertileset" 'squaredTileset
    Public Shadows Const SUPERTILESETS_ITEM As String = "tiles" 'item

    Public Shadows Const OAM As String = "OAMs" 'OAMproject
    Public Shadows Const OAM_SET As String = "oamset"
    Public Shadows Const OAM_ITEM As String = "sprite"

    Public Shadows Const ITEM_INDEX As String = "index"


    Public Shadows Const ITEM_PATTERNS As String = "gfxData" ' for Tiles and Sprites
    Public Shadows Const ITEM_COLORS As String = "colorData" ' for Tiles and Sprites



    Public Sub New() 'ByVal _config As Config)
        'Me.AppConfig = _config
    End Sub


    Public Sub New(ByVal _config As Config, ByRef aProject As tMSgfXProject)
        Me.AppConfig = _config
        Me.Project = aProject
    End Sub



    Public Function SaveProject(ByVal filePath As String) As Boolean

        Dim aXmlDoc As New XmlDocument
        Dim rootElement As XmlElement


        Try

            rootElement = GetHeaderDataElement(aXmlDoc)


            ' project data #####################################################
            'If Not Me.Info Is Nothing Then
            rootElement.AppendChild(GetInfoElement(aXmlDoc, Me.Project.Info))
            'End If
            'END project data ##################################################


            ' screens data #####################################################
            If Not Me.Project.Screens Is Nothing Then
                rootElement.AppendChild(GetScreensElement(aXmlDoc))
            End If
            'END project data ##################################################


            ' palette data #####################################################
            'If Not Me.Palettes Is Nothing Then
            If Me.Project.Palettes.Count > 0 Then
                rootElement.AppendChild(GetPalettesElement(aXmlDoc))
            End If
            'End If
            ' END palette data #################################################


            ' tilesets data ####################################################
            If Not Me.Project.Tilesets Is Nothing Then
                rootElement.AppendChild(GetTilesetProjectElement(aXmlDoc))
            End If
            ' end tilesets data ################################################


            ' SquaredTiles data ################################################
            If Not Me.Project.SupertileSets Is Nothing Then
                rootElement.AppendChild(Me.Project.SupertileSets.GetElement(aXmlDoc))
            End If
            ' end SquaredTiles data ############################################


            ' map data #########################################################
            If Not Me.Project.Maps Is Nothing Then
                rootElement.AppendChild(GetMapsElement(aXmlDoc, -1))
            End If
            ' END map data #####################################################


            ' sprites data #####################################################
            ' Sprite Patterns & V9938 colors
            If Not Me.Project.SpriteSets Is Nothing Then
                rootElement.AppendChild(GetSpritesProjectElement(aXmlDoc))
            End If

            ' OAM (Object Attribute Memory)
            If Not Me.Project.OAMs Is Nothing Then
                rootElement.AppendChild(GetElementOAMprj(aXmlDoc, -1))
            End If
            ' END sprites data #################################################



            aXmlDoc.Save(filePath)  ' save file


        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function



    Public Function GetHeaderDataElement(aXmlDoc As XmlDocument) As XmlElement
        Dim rootElement As XmlElement
        Dim anAttribute As XmlAttribute

        rootElement = aXmlDoc.CreateElement(MSXOpenDocumentIO.ROOT)
        aXmlDoc.AppendChild(rootElement)

        anAttribute = aXmlDoc.CreateAttribute(MSXOpenDocumentIO.ROOT_APP)
        anAttribute.Value = My.Application.Info.ProductName
        rootElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute(MSXOpenDocumentIO.ROOT_VER)
        anAttribute.Value = My.Application.Info.Version.ToString
        rootElement.SetAttributeNode(anAttribute)

        Return rootElement

    End Function



    ''' <summary>
    ''' Create a new project and load data
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <returns></returns>
    Public Function LoadProject(ByVal filePath As String) As Boolean ', ByVal addInfo As Boolean

        Dim result As Boolean = True

        Dim aXmlDoc As New XmlDocument
        Dim aDataNode As XmlNode
        Dim aNode As XmlNode


        Try

            aXmlDoc.Load(filePath)

            aDataNode = aXmlDoc.SelectSingleNode(MSXOpenDocumentIO.ROOT)
            If Not aDataNode Is Nothing Then


                Me.Project.Clear()


                ' project data ##############################################
                'If addInfo = True Then
                aNode = aDataNode.SelectSingleNode(MSXOpenDocumentIO.INFO)
                If aNode Is Nothing Then
                    Me.Project.Info = New ProjectInfo()
                    Me.Project.Info.Name = System.IO.Path.GetFileNameWithoutExtension(filePath)
                Else
                    Me.Project.Info = GetInfoFromNode(aNode, Path.GetFileNameWithoutExtension(filePath))
                End If
                'End If
                'END project data ##############################################



                ' get Palette Project ##############################################
                Me.Project.Palettes = New PaletteProject
                aNode = aDataNode.SelectSingleNode(MSXOpenDocumentIO.PALETTES) '<--- change to palettetProject?
                If aNode Is Nothing Then
                    Me.Project.Palettes.Clear()
                Else
                    SetPalettesFromNode(aNode)
                End If
                Me.Project.Palettes.SetZeroColor(Me.AppConfig.Color_Zero)
                ' END Palette Project ##############################################



                ' get Tileset Project ##############################################
                aNode = aDataNode.SelectSingleNode(MSXOpenDocumentIO.TILESETS) '<--- change to tilesetProject?
                If aNode Is Nothing Then
                    Me.Project.Tilesets = Nothing
                Else
                    Me.Project.Tilesets = New TilesetProject
                    Me.Project.Tilesets.Palettes = Me.Project.Palettes
                    SetTileSetFromNode(aNode)
                End If
                ' END Tileset Project ##############################################



                ' get SquaredTiles Project ##############################################
                aNode = aDataNode.SelectSingleNode(MSXOpenDocumentIO.SUPERTILESETS)
                If aNode Is Nothing Then
                    Me.Project.SupertileSets = Nothing
                Else
                    Me.Project.SupertileSets = New SupertilesProject
                    Me.Project.SupertileSets.SetFromNode(aNode)
                End If
                ' END SquaredTiles Project ##############################################



                ' get Maps Project ##############################################
                'Me.Maps.Clear()
                aNode = aDataNode.SelectSingleNode(MSXOpenDocumentIO.MAPS) '<--- change to mapProject?
                If aNode Is Nothing Then
                    Me.Project.Maps = Nothing
                Else
                    Me.Project.Maps = New MapProject
                    SetMapsFromNode(aNode)
                End If
                ' END Map Project ##############################################



                ' get Sprite Project ##############################################
                'Me._spriteProject.Clear()
                aNode = aDataNode.SelectSingleNode(MSXOpenDocumentIO.SPRITES) '<--- change to spriteProject?
                If aNode Is Nothing Then
                    Me.Project.SpriteSets = Nothing
                Else
                    Me.Project.SpriteSets = New SpriteProject
                    Me.Project.SpriteSets.Palettes = Me.Project.Palettes
                    SetSpriteProjectFromNode(aNode)
                    '    aNode = aDataNode.SelectSingleNode("sprites") ' search old format 
                    '    If Not aNode Is Nothing Then
                    '        Me._spriteProject.SetFromNode(aNode)
                    '    End If

                    'Else

                End If
                ' END Sprite Project ##############################################



                ' Sprites OAM Project ##############################################
                'Me._OAMproject.Clear()
                aNode = aDataNode.SelectSingleNode(MSXOpenDocumentIO.OAM) '<--- change to OAMProject?
                If aNode Is Nothing Then
                    Me.Project.OAMs = Nothing
                Else
                    Me.Project.OAMs = New OAMProject
                    SetOAMFromNode(aNode) 'Me.Project.OAMs.SetFromNode(aNode)
                End If
                ' END Sprite OAM Project ###########################################



                ' screen data ##############################################
                'Me._screensProject.Clear()
                aNode = aDataNode.SelectSingleNode(MSXOpenDocumentIO.SCREENS) '<--- change to screensProject?
                If aNode Is Nothing Then
                    Me.Project.Screens = Nothing
                Else
                    Me.Project.Screens = New ScreenProject
                    SetProjectFromNode(aNode)
                End If
                'END screen data ##############################################


            Else

                result = False

            End If

        Catch ex As Exception
            result = False
        End Try


        Return result

    End Function



    ''' <summary>
    ''' Add load data over de project
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <returns></returns>
    Public Function AddProject(ByVal filePath As String) As Boolean

        Dim result As Boolean = True

        Dim aXmlDoc As New XmlDocument
        Dim aDataNode As XmlNode
        Dim aNode As XmlNode


        Try

            aXmlDoc.Load(filePath)

            aDataNode = aXmlDoc.SelectSingleNode(MSXOpenDocumentIO.ROOT)
            If Not aDataNode Is Nothing Then


                '' project data ##############################################
                'If addInfo = True Then
                '    Me.Project.Info = New ProjectInfo()
                '    aNode = aDataNode.SelectSingleNode(MSXOpenDocumentIO.INFO)
                '    If aNode Is Nothing Then
                '        Me.Project.Info.Name = System.IO.Path.GetFileNameWithoutExtension(filePath)
                '    Else
                '        SetInfoFromNode(aNode)
                '    End If
                'End If
                ''END project data ##############################################



                ' get Palette Project ##############################################
                Me.Project.Palettes = New PaletteProject
                aNode = aDataNode.SelectSingleNode(MSXOpenDocumentIO.PALETTES) '<--- change to palettetProject?
                If Not aNode Is Nothing Then
                    SetPalettesFromNode(aNode)
                End If
                ' END Palette Project ##############################################



                ' get Tileset Project ##############################################
                aNode = aDataNode.SelectSingleNode(MSXOpenDocumentIO.TILESETS) '<--- change to tilesetProject?
                If Not aNode Is Nothing Then
                    If Me.Project.Tilesets Is Nothing Then
                        Me.Project.Tilesets = New TilesetProject
                        Me.Project.Tilesets.Palettes = Me.Project.Palettes
                    End If
                    SetTileSetFromNode(aNode)
                End If
                ' END Tileset Project ##############################################



                ' get SquaredTiles Project ##############################################
                aNode = aDataNode.SelectSingleNode(MSXOpenDocumentIO.SUPERTILESETS)
                If Not aNode Is Nothing Then
                    If Me.Project.SupertileSets Is Nothing Then
                        Me.Project.SupertileSets = New SupertilesProject
                    End If
                    Me.Project.SupertileSets.SetFromNode(aNode)
                End If
                ' END SquaredTiles Project ##############################################



                ' get Maps Project ##############################################
                'Me.Maps.Clear()
                aNode = aDataNode.SelectSingleNode(MSXOpenDocumentIO.MAPS) '<--- change to mapProject?
                If Not aNode Is Nothing Then
                    If Me.Project.Maps Is Nothing Then
                        Me.Project.Maps = New MapProject
                    End If
                    SetMapsFromNode(aNode)
                End If
                ' END Map Project ##############################################



                ' get Sprite Project ##############################################
                'Me._spriteProject.Clear()
                aNode = aDataNode.SelectSingleNode(MSXOpenDocumentIO.SPRITES) '<--- change to spriteProject?
                If Not aNode Is Nothing Then
                    If Me.Project.SpriteSets Is Nothing Then
                        Me.Project.SpriteSets = New SpriteProject
                        Me.Project.SpriteSets.Palettes = Me.Project.Palettes
                    End If
                    SetSpriteProjectFromNode(aNode)
                End If
                ' END Sprite Project ##############################################



                ' Sprites OAM Project ##############################################
                'Me._OAMproject.Clear()
                aNode = aDataNode.SelectSingleNode(MSXOpenDocumentIO.OAM) '<--- change to OAMProject?
                If Not aNode Is Nothing Then
                    If Me.Project.OAMs Is Nothing Then
                        Me.Project.OAMs = New OAMProject
                    End If
                    SetOAMFromNode(aNode)  'Me.Project.OAMs.SetFromNode(aNode)
                End If
                ' END Sprite OAM Project ###########################################



                ' screen data ##############################################
                'Me._screensProject.Clear()
                aNode = aDataNode.SelectSingleNode(MSXOpenDocumentIO.SCREENS) '<--- change to screensProject?
                If Not aNode Is Nothing Then
                    If Me.Project.Screens Is Nothing Then
                        Me.Project.Screens = New ScreenProject
                    End If
                    SetProjectFromNode(aNode)
                End If
                'END screen data ##############################################



            Else

                result = False

            End If

        Catch ex As Exception
            result = False
        End Try


        Return result

    End Function







#Region "INFO functions"




    Public Function GetInfoElement(ByRef aXmlDoc As XmlDocument, ByRef infoData As ProjectInfo) As XmlElement

        Dim anElement As XmlElement
        Dim anItemElement As XmlElement
        Dim anAttribute As XmlAttribute
        Dim txtElement As XmlText


        ' project data ##############################################
        anElement = aXmlDoc.CreateElement(MSXOpenDocumentIO.INFO)

        anAttribute = aXmlDoc.CreateAttribute("name")
        anAttribute.Value = infoData.Name
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("group")
        anAttribute.Value = infoData.Group
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("version")
        anAttribute.Value = infoData.Version
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("author")
        anAttribute.Value = infoData.Author
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("startDate")
        anAttribute.Value = CStr(infoData.StartDate)
        anElement.SetAttributeNode(anAttribute)

        infoData.LastUpdate = DateTime.Today.Ticks
        anAttribute = aXmlDoc.CreateAttribute("lastUpdate")
        anAttribute.Value = CStr(infoData.LastUpdate)
        anElement.SetAttributeNode(anAttribute)

        anItemElement = aXmlDoc.CreateElement("description")
        txtElement = aXmlDoc.CreateTextNode(infoData.Description)
        anItemElement.AppendChild(txtElement)
        anElement.AppendChild(anItemElement)
        'END project data ##############################################

        Return anElement

    End Function



    Public Function GetInfoFromNode(ByVal aDataNode As XmlNode, ByVal defName As String) As ProjectInfo

        Dim newInfo As New ProjectInfo
        Dim aNode As XmlNode
        'Dim anAttribute As XmlAttribute



        ' get project info ############################################
        aNode = aDataNode.SelectSingleNode("@name")
        If aNode Is Nothing Then
            newInfo.Name = defName
        Else
            newInfo.Name = aNode.InnerText
        End If

        aNode = aDataNode.SelectSingleNode("@version")
        If aNode Is Nothing Then
            newInfo.Version = ""
        Else
            newInfo.Version = aNode.InnerText
        End If

        aNode = aDataNode.SelectSingleNode("@group")
        If aNode Is Nothing Then
            newInfo.Group = ""
        Else
            newInfo.Group = aNode.InnerText
        End If

        aNode = aDataNode.SelectSingleNode("@author")
        If aNode Is Nothing Then
            newInfo.Author = ""
        Else
            newInfo.Author = aNode.InnerText
        End If

        aNode = aDataNode.SelectSingleNode("@startDate")
        If aNode Is Nothing Then
            newInfo.StartDate = DateTime.Today.Ticks
        Else
            newInfo.StartDate = CLng(aNode.InnerText)
        End If

        aNode = aDataNode.SelectSingleNode("@lastUpdate")
        If aNode Is Nothing Then
            newInfo.LastUpdate = DateTime.Today.Ticks
        Else
            newInfo.LastUpdate = CLng(aNode.InnerText)
        End If

        aNode = aDataNode.SelectSingleNode("description")
        If aNode Is Nothing Then
            newInfo.Description = ""
        Else
            newInfo.Description = aNode.InnerText
        End If

        Return newInfo

    End Function



#End Region







#Region "SquaredSETs functions"



    Public Function SaveSquaredsetsProject(ByVal filePath As String) As Boolean

        Return SaveSquaredset(filePath, -1)

    End Function



    Public Function SaveSquaredset(ByVal filePath As String, ByVal ID As Integer) As Boolean

        Dim aXmlDoc As New XmlDocument
        Dim rootElement As XmlElement

        Try

            rootElement = GetHeaderDataElement(aXmlDoc)

            ' project data #####################################################
            rootElement.AppendChild(GetInfoElement(aXmlDoc, Me.Project.Info))
            ' END project data #################################################


            If ID > 0 Then

                ' tileset data (tileset) ##############################################
                rootElement.AppendChild(Me.Project.SupertileSets.GetElement(aXmlDoc, ID))
                ' end tileset data ##############################################

            Else
                ' tilesets data ####################################################
                If Not Me.Project.SupertileSets Is Nothing Then
                    rootElement.AppendChild(Me.Project.SupertileSets.GetElement(aXmlDoc))
                Else
                    Return False
                End If
                ' end tilesets data ################################################
            End If


            aXmlDoc.Save(filePath)  ' save file


        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function




#End Region






#Region "OAM functions"




    Public Function SaveOAMProject(ByVal filePath As String) As Boolean

        Return SaveOAMset(filePath, -1)

    End Function



    Public Function SaveOAMset(ByVal filePath As String, ByVal ID As Integer) As Boolean

        Dim aXmlDoc As New XmlDocument
        Dim rootElement As XmlElement

        Try

            rootElement = GetHeaderDataElement(aXmlDoc)

            ' project data #####################################################
            rootElement.AppendChild(GetInfoElement(aXmlDoc, Me.Project.Info))
            ' END project data #################################################


            If ID > 0 Then

                ' gfx data (tileset) ##############################################
                rootElement.AppendChild(GetElementOAMprj(aXmlDoc, ID)) 'Me.Project.OAMs.GetElement(aXmlDoc, ID))
                ' end gfx data ##############################################

            Else
                ' tilesets data ####################################################
                If Not Me.Project.OAMs Is Nothing Then
                    rootElement.AppendChild(GetElementOAMprj(aXmlDoc, -1)) 'Me.Project.OAMs.GetElement(aXmlDoc))
                Else
                    Return False
                End If
                ' end tilesets data ################################################
            End If


            aXmlDoc.Save(filePath)  ' save file


        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function





    Private Function GetElementOAMprj(ByRef aXmlDoc As XmlDocument, ByVal ID As Integer) As XmlElement

        Dim anElement As XmlElement
        'Dim anItemElement As XmlElement

        'Dim anAttribute As XmlAttribute
        'Dim txtElement As XmlText
        'Dim subElement As XmlElement

        Dim anOAMset As OAMset


        'Dim genData As New MSXDataFormat

        If ID = -1 Or Me.Project.OAMs.Items.ContainsKey(ID) Then

            anElement = aXmlDoc.CreateElement(MSXOpenDocumentIO.OAM)   '"OAMproject")


            'anItemElement = Me.Info.GetElement(aXmlDoc)
            'anElement.AppendChild(anItemElement)


            If ID = -1 Then
                For i As Integer = 0 To Me.Project.OAMs.Items.Count - 1

                    anOAMset = Me.Project.OAMs.GetOAMset(i) '.NamesList.GetIDbyIndex(i))
                    anElement.AppendChild(GetElementOAMset(aXmlDoc, anOAMset))

                    'If Not anOAMset.itsEmpty Then
                    'End If

                Next
            Else
                anOAMset = Me.Project.OAMs.GetOAMsetByID(ID)
                anElement.AppendChild(GetElementOAMset(aXmlDoc, anOAMset))

                'If Not anOAMset.itsEmpty Then
                'End If
            End If



            Return anElement

        Else

            Return Nothing

        End If

    End Function




    Private Function GetElementOAMset(ByRef aXmlDoc As XmlDocument, ByVal anOAMset As OAMset) As XmlElement

        Dim genData As New DataFormat

        Dim anElement As XmlElement
        Dim anItemElement As XmlElement
        Dim anAttribute As XmlAttribute

        Dim subElement As XmlElement
        Dim txtElement As XmlText

        Dim sprOAM As SpriteOAM

        Dim tmpColorData(15) As Byte


        anElement = aXmlDoc.CreateElement(MSXOpenDocumentIO.OAM_SET)  '"oamSET")

        anAttribute = aXmlDoc.CreateAttribute("id")
        anAttribute.Value = CStr(anOAMset.ID)
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("name")
        anAttribute.Value = anOAMset.Name
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("type")
        anAttribute.Value = CStr(anOAMset.Mode)
        anElement.SetAttributeNode(anAttribute)


        If Not anOAMset.itsEmpty Then
            For i As Integer = 0 To 31
                sprOAM = anOAMset.GetSpriteOAM(i)

                '<sprite layer="0" y="23" x="33" pattern="0" color="1" />
                anItemElement = aXmlDoc.CreateElement(MSXOpenDocumentIO.OAM_ITEM)  '"sprite")
                anElement.AppendChild(anItemElement)

                anAttribute = aXmlDoc.CreateAttribute("layer")
                anAttribute.Value = CStr(i)
                anItemElement.SetAttributeNode(anAttribute)

                anAttribute = aXmlDoc.CreateAttribute("x")
                anAttribute.Value = CStr(sprOAM.X)
                anItemElement.SetAttributeNode(anAttribute)

                anAttribute = aXmlDoc.CreateAttribute("y")
                anAttribute.Value = CStr(sprOAM.Y)
                anItemElement.SetAttributeNode(anAttribute)

                anAttribute = aXmlDoc.CreateAttribute("pattern")
                anAttribute.Value = CStr(sprOAM.PatternNumber)
                anItemElement.SetAttributeNode(anAttribute)

                anAttribute = aXmlDoc.CreateAttribute("color")
                anAttribute.Value = CStr(sprOAM.ColorEC)
                anItemElement.SetAttributeNode(anAttribute)

                'If anOAMset.Mode = SpriteMSX.SPRITE_MODE.COLOR Then
                subElement = aXmlDoc.CreateElement(MSXOpenDocumentIO.ITEM_COLORS)
                tmpColorData = sprOAM.GetMode2ColorLines()
                txtElement = aXmlDoc.CreateTextNode(genData.JoinDataHex(tmpColorData)) 'joinData
                subElement.AppendChild(txtElement)
                anItemElement.AppendChild(subElement)
                'End If

            Next

        End If


        Return anElement

    End Function




    Private Sub SetOAMFromNode(ByVal aDataNode As XmlNode)

        'Dim aNode As XmlNode
        'Dim anAttribute As XmlAttribute
        Dim aNodeList As XmlNodeList
        'Dim subNode As XmlNode


        'Clear()


        ' get project info ############################################
        'aNode = aDataNode.SelectSingleNode("ProjectInfo")
        'If aNode Is Nothing Then
        '    Me.Info = New ProjectInfo()
        'Else
        '    Me.Info.SetFromNode(aNode)
        'End If



        ' get OAM sets ##########################################
        aNodeList = aDataNode.SelectNodes(MSXOpenDocumentIO.OAM_SET) '"oamSET"
        If aNodeList.Count > 0 Then
            For Each anItemElement As XmlElement In aNodeList
                SetOAMsetFromNode(anItemElement)
            Next
            'Else
            '    ' If you can not find data, add a default OAMset
            '    Add(New OAMset("defaultOAM", SpriteMSX.SPRITE_SIZE.SIZE16, SpriteMSX.SPRITE_MODE.MONO))
        End If

    End Sub




    Private Sub SetOAMsetFromNode(ByVal anItemNode As XmlElement)

        Dim genData As New DataFormat

        Dim aNode As XmlNode
        Dim anAttribute As XmlAttribute
        Dim aNodeList As XmlNodeList
        Dim subNode As XmlNode

        Dim tmpOAMset As OAMset

        Dim tmpID As Integer
        Dim tmpName As String
        Dim tmpType As SpriteMSX.SPRITE_MODE

        Dim tmpLayer As Byte
        Dim tmpSpriteName As String
        Dim tmpX As Byte
        Dim tmpY As Byte
        Dim tmpColorEC As Byte
        Dim tmpPatternNumber As Byte

        Dim tmpColorData(15) As Byte

        Dim i As Integer


        aNode = anItemNode.SelectSingleNode("@id") 'type
        If aNode Is Nothing Then
            tmpID = -1
        Else
            tmpID = CInt(aNode.InnerText)
        End If


        aNode = anItemNode.SelectSingleNode("@name") 'type
        If aNode Is Nothing Then
            tmpName = "spriteset00"
        Else
            tmpName = aNode.InnerText
        End If


        aNode = anItemNode.SelectSingleNode("@type") 'type
        If aNode Is Nothing Then
            tmpType = SpriteMSX.SPRITE_MODE.MONO
        Else
            tmpType = CInt(aNode.InnerText)
        End If


        ''
        If tmpID = -1 Then
            tmpOAMset = New OAMset(tmpName, SpriteMSX.SPRITE_SIZE.SIZE16, tmpType)
        Else
            tmpOAMset = New OAMset(tmpID, tmpName, SpriteMSX.SPRITE_SIZE.SIZE16, tmpType)
        End If



        ' get layer data  ##########################################
        aNodeList = anItemNode.SelectNodes(MSXOpenDocumentIO.OAM_ITEM)   '"sprite"
        If aNodeList.Count > 0 Then

            For Each anItemElement As XmlElement In aNodeList

                anAttribute = anItemElement.GetAttributeNode("layer") 'ID changed for index
                If anAttribute Is Nothing Then
                    tmpLayer = 128
                Else
                    tmpLayer = CByte(anAttribute.InnerText)
                End If


                anAttribute = anItemElement.GetAttributeNode("name")
                If anAttribute Is Nothing Then
                    tmpSpriteName = "OAM" + CStr(tmpLayer)
                Else
                    tmpSpriteName = anAttribute.InnerText
                End If


                anAttribute = anItemElement.GetAttributeNode("x")
                If anAttribute Is Nothing Then
                    tmpX = 0
                Else
                    tmpX = CByte(anAttribute.InnerText)
                End If

                anAttribute = anItemElement.GetAttributeNode("y")
                If anAttribute Is Nothing Then
                    tmpY = 211 ' en caso de no encontrar este valor se colocara oculto en el margen inferior
                Else
                    tmpY = CByte(anAttribute.InnerText)
                End If


                anAttribute = anItemElement.GetAttributeNode("pattern")
                If anAttribute Is Nothing Then
                    tmpPatternNumber = 0
                Else
                    tmpPatternNumber = CByte(anAttribute.InnerText)
                End If


                anAttribute = anItemElement.GetAttributeNode("color")
                If anAttribute Is Nothing Then
                    tmpColorEC = 15
                Else
                    tmpColorEC = CByte(anAttribute.InnerText)
                End If


                subNode = anItemElement.SelectSingleNode(MSXOpenDocumentIO.ITEM_COLORS)
                If subNode Is Nothing Then
                    ' default Color Lines Data
                    For i = 0 To 15
                        tmpColorData(i) = tmpColorEC
                    Next
                Else
                    tmpColorData = genData.ByteSpliter(subNode.InnerText, 15, 0)
                End If


                If tmpLayer < 32 Then

                    'If tmpType = SpriteMSX.SPRITE_MODE.MONO Then
                    '    tmpOAMset.SetSpriteOAM(tmpLayer, New SpriteOAM(tmpSpriteName, tmpY, tmpX, tmpPatternNumber, tmpColor))
                    'Else
                    tmpOAMset.SetSpriteOAM(tmpLayer, New SpriteOAM(tmpSpriteName, tmpY, tmpX, tmpPatternNumber, tmpColorEC, tmpColorData)) 'Sprites Mode 2 V9938
                    'End If

                End If

            Next

        Else
            ' has not found data
            ' uses the default values created in NEW

        End If


        Me.Project.OAMs.Add(tmpOAMset)

    End Sub




#End Region







    ' ############################################################################################################################# END SCREENs
#Region "SCREENs functions"




    Public Function SaveScreensProject(ByVal filePath As String) As Boolean

        Dim aXmlDoc As New XmlDocument
        Dim rootElement As XmlElement


        Try

            rootElement = GetHeaderDataElement(aXmlDoc)


            ' project data #####################################################
            'If Not Me.Info Is Nothing Then
            rootElement.AppendChild(GetInfoElement(aXmlDoc, Me.Project.Info))
            'End If
            'END project data ##################################################


            ' screens data #####################################################
            If Not Me.Project.Screens Is Nothing Then
                rootElement.AppendChild(GetScreensElement(aXmlDoc))
            Else
                Return False
            End If
            'END project data ##################################################


            aXmlDoc.Save(filePath)  ' save file

            Return True

        Catch ex As Exception
            Return False
        End Try



    End Function


    Public Function GetScreensElement(ByRef aXmlDoc As XmlDocument) As XmlElement

        Dim anElement As XmlElement
        Dim anAttribute As XmlAttribute

        Dim item As ScreenMSX

        anElement = aXmlDoc.CreateElement("screens")

        anAttribute = aXmlDoc.CreateAttribute("name")
        anAttribute.Value = Me.Project.Screens.Name
        anElement.SetAttributeNode(anAttribute)

        For i = 0 To Me.Project.Screens.Count - 1
            item = Me.Project.Screens.GetScreenByIndex(i)
            anElement.AppendChild(GetScreenElement(aXmlDoc, item))
        Next

        Return anElement

    End Function



    Public Function GetScreenElement(ByRef aXmlDoc As XmlDocument, ByVal item As ScreenMSX) As XmlElement

        Dim anElement As XmlElement
        'Dim anItemElement As XmlElement
        Dim anAttribute As XmlAttribute

        anElement = aXmlDoc.CreateElement("screen")


        If Not item.Info Is Nothing Then
            anElement.AppendChild(GetInfoElement(aXmlDoc, item.Info))
        End If

        'anAttribute = aXmlDoc.CreateAttribute("id")
        'anAttribute.Value = CStr(item.ID)
        'anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("name")
        anAttribute.Value = item.Name
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("ScreenMode")
        anAttribute.Value = CStr(item.ScreenMode)
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("SpriteSize")
        anAttribute.Value = CStr(item.SpriteSize)
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("SpriteZoom")
        anAttribute.Value = CStr(item.SpriteZoom)
        anElement.SetAttributeNode(anAttribute)

        'anAttribute = aXmlDoc.CreateAttribute("PaletteType") ' <<<------------------------------------------ ??? DEPRECATED
        'anAttribute.Value = CStr(item.PaletteType)
        'anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("PaletteID")
        anAttribute.Value = CStr(item.PaletteID)
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("ForegroundColor")
        anAttribute.Value = CStr(item.InkColor)
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("BackgroundColor")
        anAttribute.Value = CStr(item.BackgroundColor)
        anElement.SetAttributeNode(anAttribute)

        'anAttribute = aXmlDoc.CreateAttribute("BorderColor")
        'anAttribute.Value = CStr(item.BorderColor)
        'anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("MapID")
        anAttribute.Value = CStr(item.MapID)
        anElement.SetAttributeNode(anAttribute)


        anAttribute = aXmlDoc.CreateAttribute("TilesetA_ID")
        anAttribute.Value = CStr(item.TilesetA)
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("TilesetB_ID")
        anAttribute.Value = CStr(item.TilesetB)
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("TilesetC_ID")
        anAttribute.Value = CStr(item.TilesetC)
        anElement.SetAttributeNode(anAttribute)


        anAttribute = aXmlDoc.CreateAttribute("SpritesetID")
        anAttribute.Value = CStr(item.SpritesetID)
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("OAMID")
        anAttribute.Value = CStr(item.OAMID)
        anElement.SetAttributeNode(anAttribute)


        Return anElement

    End Function



    ''' <summary>
    ''' Lee los datos de la paleta a partir de un nodo de un docuemento XML.
    ''' </summary>
    ''' <param name="aDataNode"></param>
    ''' <remarks></remarks>
    Public Sub SetProjectFromNode(ByVal aDataNode As XmlNode)

        'Dim aNode As XmlNode
        'Dim anAttribute As XmlAttribute
        Dim aNodeList As XmlNodeList

        'Me.Clear()

        'aNode = aDataNode.SelectSingleNode("@name")
        'If aNode Is Nothing Then
        '    Me.Name = ""
        'Else
        '    Me.Name = aNode.InnerText
        'End If


        aNodeList = aDataNode.SelectNodes("screen")
        If Not aNodeList Is Nothing Then
            For Each anItemElement As XmlElement In aNodeList
                SetItemFromNode(anItemElement)
            Next
        End If


    End Sub



    ''' <summary>
    ''' Lee los datos de la paleta a partir de un nodo de un docuemento XML.
    ''' </summary>
    ''' <param name="aDataNode"></param>
    ''' <remarks></remarks>
    Public Function SetItemFromNode(ByVal aDataNode As XmlNode) As Boolean 'ByVal aPalette As PaletteV9938

        Dim result As Boolean = True

        Dim aNode As XmlNode
        'Dim anAttribute As XmlAttribute
        'Dim aNodeList As XmlNodeList

        Dim tmpScreen As New ScreenMSX

        Try

            'aNode = aDataNode.SelectSingleNode("@id")
            'If aNode Is Nothing Then
            '    tmpScreen.ID = tmpScreen.GetHashCode
            'Else
            '    tmpScreen.ID = CInt(aNode.InnerText)
            'End If

            aNode = aDataNode.SelectSingleNode("@name")
            If aNode Is Nothing Then
                tmpScreen.Name = "NO_NAME"
            Else
                tmpScreen.Name = aNode.InnerText
            End If


            aNode = aDataNode.SelectSingleNode(MSXOpenDocumentIO.INFO)
            If Not aNode Is Nothing Then
                tmpScreen.Info = GetInfoFromNode(aNode, tmpScreen.Name)
            End If


            aNode = aDataNode.SelectSingleNode("@ScreenMode")
            If aNode Is Nothing Then
                tmpScreen.ScreenMode = iVDP.SCREEN_MODE.G2
            Else
                tmpScreen.ScreenMode = CInt(aNode.InnerText)
            End If

            aNode = aDataNode.SelectSingleNode("@SpriteSize")
            If aNode Is Nothing Then
                tmpScreen.SpriteSize = SpriteMSX.SPRITE_SIZE.SIZE16
            Else
                tmpScreen.SpriteSize = CInt(aNode.InnerText)
            End If

            aNode = aDataNode.SelectSingleNode("@SpriteZoom")
            If aNode Is Nothing Then
                tmpScreen.SpriteZoom = iVDP.SPRITE_ZOOM.X1
            Else
                tmpScreen.SpriteZoom = CInt(aNode.InnerText)
            End If

            aNode = aDataNode.SelectSingleNode("@PaletteID")
            If aNode Is Nothing Then
                tmpScreen.PaletteID = 0
            Else
                tmpScreen.PaletteID = CInt(aNode.InnerText)
            End If

            aNode = aDataNode.SelectSingleNode("@ForegroundColor")
            If aNode Is Nothing Then
                tmpScreen.InkColor = 15
            Else
                tmpScreen.InkColor = CInt(aNode.InnerText)
            End If

            aNode = aDataNode.SelectSingleNode("@BackgroundColor")
            If aNode Is Nothing Then
                tmpScreen.BackgroundColor = 4
            Else
                tmpScreen.BackgroundColor = CInt(aNode.InnerText)
            End If

            'aNode = aDataNode.SelectSingleNode("@BorderColor")
            'If aNode Is Nothing Then
            '    tmpScreen.BorderColor = 4
            'Else
            '    tmpScreen.BorderColor = CInt(aNode.InnerText)
            'End If

            aNode = aDataNode.SelectSingleNode("@MapID")
            If aNode Is Nothing Then
                tmpScreen.MapID = 0
            Else
                tmpScreen.MapID = CInt(aNode.InnerText)
            End If


            aNode = aDataNode.SelectSingleNode("@TilesetA_ID")
            If aNode Is Nothing Then
                tmpScreen.TilesetA = 0
            Else
                tmpScreen.TilesetA = CInt(aNode.InnerText)
            End If

            aNode = aDataNode.SelectSingleNode("@TilesetB_ID")
            If aNode Is Nothing Then
                tmpScreen.TilesetB = 0
            Else
                tmpScreen.TilesetB = CInt(aNode.InnerText)
            End If

            aNode = aDataNode.SelectSingleNode("@TilesetC_ID")
            If aNode Is Nothing Then
                tmpScreen.TilesetC = 0
            Else
                tmpScreen.TilesetC = CInt(aNode.InnerText)
            End If


            aNode = aDataNode.SelectSingleNode("@SpritesetID")
            If aNode Is Nothing Then
                tmpScreen.SpritesetID = 0
            Else
                tmpScreen.SpritesetID = CInt(aNode.InnerText)
            End If

            aNode = aDataNode.SelectSingleNode("@OAMID")
            If aNode Is Nothing Then
                tmpScreen.OAMID = 0
            Else
                tmpScreen.OAMID = CInt(aNode.InnerText)
            End If

            Me.Project.Screens.Add(tmpScreen)

        Catch ex As Exception
            result = False
        End Try


        Return result


    End Function




#End Region
    ' ############################################################################################################################# END SCREENs




    ' ############################################################################################################################# MAPS
#Region "MAPS functions"



    Public Function LoadMap(ByVal filePath As String, itemName As String) As Integer

        Dim newID As Integer = -1

        Dim aXmlDoc As New XmlDocument
        Dim aNodeList As XmlNodeList
        Dim aDataNode As XmlNode
        Dim aNode As XmlNode

        'Dim itemName As String = ""
        'Dim nameList As ArrayList
        'Dim allItems As Boolean = False

        Dim tmpMap As MapMSX



        'Try

        aXmlDoc.Load(filePath)


            aDataNode = aXmlDoc.SelectSingleNode(MSXOpenDocumentIO.ROOT)
        If Not aDataNode Is Nothing Then

            aNode = aDataNode.SelectSingleNode(MSXOpenDocumentIO.MAPS)
            If Not aNode Is Nothing Then

                ' Get Map List
                'nameList = GetNameListFromNode(aNode, MSXOpenDocumentIO.MAPS_ITEM)

                '' si solo hay uno, lo carga directamente
                'If nameList.Count = 1 Then
                '    itemName = nameList.Item(0)
                'ElseIf nameList.Count > 1 Then
                '    ' show win with Map selector
                '    Dim aListSelectorDialog As New ListSelectorDialog("Load Map", "Select a Map:", "All Maps", nameList)
                '    If aListSelectorDialog.ShowDialog() = DialogResult.OK Then
                '        itemName = aListSelectorDialog.SelectedItem()
                '        If aListSelectorDialog.SelectedIndex = 0 Then
                '            allItems = True
                '        End If
                '    End If
                'End If



                If itemName = "" Then

                    aNode = aDataNode.SelectSingleNode(MSXOpenDocumentIO.MAPS)
                    If Not aNode Is Nothing Then
                        newID = SetMapsFromNode(aNode)
                    Else
                        newID = -1
                    End If

                Else

                    aNodeList = aXmlDoc.SelectNodes(MSXOpenDocumentIO.ROOT + "/" + MSXOpenDocumentIO.MAPS + "/" + MSXOpenDocumentIO.MAPS_ITEM + "[@name='" + itemName + "']")

                    tmpMap = GetMapFromNode(aNodeList.Item(0))
                    If Not tmpMap Is Nothing Then
                        newID = Me.Project.Maps.Add(tmpMap)
                    Else
                        newID = -1
                    End If


                End If

            End If

        End If

        'Catch ex As Exception
        '    Return = -1
        'End Try


        Return newID

    End Function



    Public Function SetMapsFromNode(ByVal aDataNode As XmlNode) As Integer

        Dim genData As New DataFormat

        Dim lastID As Integer


        Dim aNodeList As XmlNodeList
        Dim tmpMap As MapMSX


        '<map id="0">
        'Try

        aNodeList = aDataNode.SelectNodes(MSXOpenDocumentIO.MAPS_ITEM)
        If Not aNodeList Is Nothing Then
            For Each anItemNode As XmlNode In aNodeList
                tmpMap = GetMapFromNode(anItemNode)
                If Not tmpMap Is Nothing Then
                    lastID = Me.Project.Maps.Add(tmpMap)
                End If
            Next
        End If


        'Catch ex As Exception
        '    lastID = -1
        'End Try

        Return lastID

    End Function



    Public Function GetMapFromNode(ByVal aDataNode As XmlNode) As MapMSX

        Dim aMSXDataFormat As New DataFormat

        'Dim aMap As MapMSX

        Dim aNode As XmlNode
        Dim aNodeList As XmlNodeList
        Dim anAttribute As XmlAttribute

        Dim tmpString As String
        Dim line As Integer

        Dim data As New ArrayList
        Dim dataLine() As Byte

        Dim _ID As Integer
        Dim _name As String
        Dim _MapType As MapMSX.MAP_TYPE
        Dim _TileType As MapMSX.TILE_TYPE
        Dim _Width As Integer
        Dim _Height As Integer
        Dim _Tileset As Integer
        Dim _TilesetB As Integer
        Dim _TilesetC As Integer
        Dim _Squaredset As Integer


        '<map id="0">
        Try

            aNode = aDataNode.SelectSingleNode("@name")
            If aNode Is Nothing Then
                ' default
                _name = "MAP_"
            Else
                _name = aNode.InnerText
            End If

            aNode = aDataNode.SelectSingleNode("@id")
            If aNode Is Nothing Then
                ' default
                _ID = -1
            Else
                _ID = CInt(aNode.InnerText)
            End If

            aNode = aDataNode.SelectSingleNode("@tiletype")
            If aNode Is Nothing Then
                ' default
                _TileType = MapMSX.TILE_TYPE.SimpleTILE
            Else
                _TileType = CInt(aNode.InnerText)
            End If

            aNode = aDataNode.SelectSingleNode("@maptype")
            If aNode Is Nothing Then
                aNode = aDataNode.SelectSingleNode("@screentype")  'OJO DEPRECATED
                If aNode Is Nothing Then
                    ' default
                    _MapType = MapMSX.MAP_TYPE.ScreenG2
                Else
                    _MapType = CInt(aNode.InnerText)

                End If
            Else
                _MapType = CInt(aNode.InnerText)
            End If


            aNode = aDataNode.SelectSingleNode("@width")
            If aNode Is Nothing Then
                ' default
                _Width = 32
            Else
                _Width = CInt(aNode.InnerText)
            End If

            aNode = aDataNode.SelectSingleNode("@height")
            If aNode Is Nothing Then
                ' default
                _Height = 24
            Else
                _Height = CInt(aNode.InnerText)
            End If



            aNode = aDataNode.SelectSingleNode("@tileset")
            If aNode Is Nothing Then
                ' default
                _Tileset = 0
            Else
                _Tileset = CInt(aNode.InnerText)
            End If

            aNode = aDataNode.SelectSingleNode("@tilesetB")
            If aNode Is Nothing Then
                _TilesetB = _Tileset
            Else
                _TilesetB = CInt(aNode.InnerText)
            End If

            aNode = aDataNode.SelectSingleNode("@tilesetC")
            If aNode Is Nothing Then
                _TilesetC = _Tileset
            Else
                _TilesetC = CInt(aNode.InnerText)
            End If

            aNode = aDataNode.SelectSingleNode("@squaredset")
            If aNode Is Nothing Then
                ' default
                _Squaredset = 0
            Else
                _Squaredset = CInt(aNode.InnerText)
            End If



            'If _MapType = MapMSX.MAP_TYPE.ScreenG2 Then
            '    aMap = New MapMSX(_name, _Width, _Height, _Tileset, _TilesetB, _TilesetC)
            'Else
            '    aMap = New MapMSX(_name, _Width, _Height, _TileType, _Tileset)
            'End If

            'OLD
            '<line id="0">0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,0</line>

            '<line index="0">000102030405060708090A0B0C0D0E0F101112131415161718191A1B1C1D1E1F00</line>
            aNodeList = aDataNode.SelectNodes("line")
            For Each anItemElement As XmlElement In aNodeList
                anAttribute = anItemElement.GetAttributeNode(MSXOpenDocumentIO.ITEM_INDEX)
                line = CInt(anAttribute.InnerText)
                If line < _Height Then
                    tmpString = anItemElement.InnerText
                    dataLine = aMSXDataFormat.ByteSpliter(tmpString, _Width - 1, 0)
                    data.Add(dataLine)
                    'aMap.AddLine(line, dataLine)
                End If
            Next


            'Add(New MapMSX(_ID, _name, _MapType, _TileType, _Width, _Tileset, _TilesetB, _TilesetC, _Squaredset, data))
            Return New MapMSX(_ID, _name, _MapType, _TileType, _Width, _Tileset, _TilesetB, _TilesetC, _Squaredset, data)

            'Return True

        Catch ex As Exception
            Return Nothing
        End Try

    End Function




    Public Function SaveMapsProject(ByVal filePath As String) As Boolean

        Return SaveMap(filePath, -1)

    End Function



    Public Function SaveMap(ByVal filePath As String, ByVal ID As Integer) As Boolean

        Dim aXmlDoc As New XmlDocument
        Dim rootElement As XmlElement

        'Try        

        If Not Me.Project.Maps Is Nothing Then

            rootElement = GetHeaderDataElement(aXmlDoc)

            ' project data #####################################################
            rootElement.AppendChild(GetInfoElement(aXmlDoc, Me.Project.Info))
            ' END project data #################################################


            If ID > 0 Then

                ' Maps data (tileset) ##############################################
                rootElement.AppendChild(GetMapsElement(aXmlDoc, ID))
                ' end Maps data ##############################################

            Else
                ' Maps data ####################################################
                'If Not Me.Project.Maps Is Nothing Then
                rootElement.AppendChild(GetMapsElement(aXmlDoc, -1))

                ' end Maps data ################################################
            End If


            aXmlDoc.Save(filePath)  ' save file

        Else
            Return False
        End If

        'Catch ex As Exception
        '    Return False
        'End Try

        Return True

    End Function



    Public Function GetMapsElement(aXmlDoc As XmlDocument, ID As Integer) As XmlElement

        Dim anElement As XmlElement
        'Dim anItemElement As XmlElement


        If ID = -1 Or Me.Project.Maps.Contains(ID) Then


            anElement = aXmlDoc.CreateElement(MSXOpenDocumentIO.MAPS)

            If ID = -1 Then
                For Each aMap As MapMSX In Me.Project.Maps.Maps
                    anElement.AppendChild(GetElementFromMap(aXmlDoc, aMap))
                Next
            Else
                anElement.AppendChild(GetElementFromMap(aXmlDoc, Me.Project.Maps.GetMapByID(ID)))
            End If

            Return anElement

        Else

            Return Nothing

        End If

    End Function



    Private Function GetElementFromMap(ByRef aXmlDoc As XmlDocument, ByVal aMap As MapMSX) As XmlElement
        Dim anElement As XmlElement
        Dim anAttribute As XmlAttribute
        'Dim txtElement As XmlText


        anElement = aXmlDoc.CreateElement(MSXOpenDocumentIO.MAPS_ITEM)
        'aXmlDoc.AppendChild(anElement)

        anAttribute = aXmlDoc.CreateAttribute("id")
        anAttribute.Value = CStr(aMap.ID)
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("name")
        anAttribute.Value = aMap.Name
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("maptype")
        anAttribute.Value = CStr(aMap.MapType)
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("tiletype") 'single or two square tile
        anAttribute.Value = CStr(aMap.TileType)
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("width")
        anAttribute.Value = CStr(aMap.Width)
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("height")
        anAttribute.Value = CStr(aMap.Height)
        anElement.SetAttributeNode(anAttribute)


        anAttribute = aXmlDoc.CreateAttribute(MSXOpenDocumentIO.TILESETS_SET)
        anAttribute.Value = CStr(aMap.Tileset)
        anElement.SetAttributeNode(anAttribute)

        If aMap.MapType = MapMSX.MAP_TYPE.ScreenG2 Then
            anAttribute = aXmlDoc.CreateAttribute("tilesetB")
            anAttribute.Value = CStr(aMap.TilesetB)
            anElement.SetAttributeNode(anAttribute)

            anAttribute = aXmlDoc.CreateAttribute("tilesetC")
            anAttribute.Value = CStr(aMap.TilesetC)
            anElement.SetAttributeNode(anAttribute)
        End If

        If aMap.TileType = MapMSX.TILE_TYPE.SuperTILE Then
            anAttribute = aXmlDoc.CreateAttribute("squaredset")
            anAttribute.Value = CStr(aMap.SupertilesetID)
            anElement.SetAttributeNode(anAttribute)
        End If

        For line = 0 To aMap.Height - 1
            anElement.AppendChild(GetElementLineMap(aXmlDoc, line, aMap.Lines.Item(line)))
        Next

        Return anElement

    End Function



    Private Function GetElementLineMap(ByRef aXmlDoc As XmlDocument, ByVal line As Integer, ByVal lineData() As Byte) As XmlElement

        Dim genData As New DataFormat

        Dim anElement As XmlElement
        Dim anAttribute As XmlAttribute
        Dim txtElement As XmlText

        anElement = aXmlDoc.CreateElement("line")

        anAttribute = aXmlDoc.CreateAttribute(MSXOpenDocumentIO.ITEM_INDEX)
        anAttribute.Value = CStr(line)
        anElement.SetAttributeNode(anAttribute)

        txtElement = aXmlDoc.CreateTextNode(genData.JoinDataHex(lineData))
        anElement.AppendChild(txtElement)

        Return anElement

    End Function





#End Region
    ' ############################################################################################################################# END MAPS





    ' ############################################################################################################################# PALETTES
#Region "PALETTES functions"



    Public Function SavePaletteProject(ByVal filePath As String) As Boolean

        Return SavePalette(filePath, -1)

    End Function



    Public Function SavePalette(ByVal filePath As String, ByVal ID As Integer) As Boolean

        Dim aXmlDoc As New XmlDocument
        Dim rootElement As XmlElement


        Try

            rootElement = GetHeaderDataElement(aXmlDoc)

            ' project data #####################################################
            rootElement.AppendChild(GetInfoElement(aXmlDoc, Me.Project.Info))
            ' END project data #################################################


            If ID > 0 Then

                ' palette data ##############################################
                rootElement.AppendChild(GetPaletteElementByID(aXmlDoc, ID))
                ' end gfx data ##############################################

            Else
                ' palette data #####################################################
                If Me.Project.Palettes.Count > 0 Then
                    rootElement.AppendChild(GetPaletteElementByID(aXmlDoc, -1))
                Else
                    Return False
                End If
                ' END palette data #################################################

            End If


            aXmlDoc.Save(filePath)  ' save file


        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function




    Public Function LoadPalette(ByVal filePath As String, itemName As String) As Integer

        Dim newID As Integer = -1
        'Dim result As Boolean = True

        'Dim paletteName As String = ""
        'Dim nameList As ArrayList
        'Dim allItems As Boolean = False


        Dim aXmlDoc As New XmlDocument
        Dim aDataNode As XmlNode
        Dim aNode As XmlNode
        Dim aNodeList As XmlNodeList




        Dim tmpPalette As New PaletteV9938

        'Me.Enabled = False

        Try
            aXmlDoc.Load(filePath)


            aDataNode = aXmlDoc.SelectSingleNode(MSXOpenDocumentIO.ROOT)
            If Not aDataNode Is Nothing Then 'aXmlDoc.GetElementsByTagName("msxOpenDocument").Count > 0 Then
                'If aXmlDoc.GetElementsByTagName("msxOpenDocument").Count > 0 Then

                aNode = aDataNode.SelectSingleNode(MSXOpenDocumentIO.PALETTES) '"palettes"
                'aNode = aXmlDoc.SelectSingleNode("msxOpenDocument/palettes")
                If aNode Is Nothing Then
                    Return -1
                Else

                    If itemName = "" Then

                        aNode = aDataNode.SelectSingleNode(MSXOpenDocumentIO.PALETTES) '"palettes"
                        If Not aNode Is Nothing Then
                            SetPalettesFromNode(aNode)
                        End If

                    Else
                        ' load selected Map
                        aNodeList = aXmlDoc.SelectNodes(MSXOpenDocumentIO.ROOT + "/" + MSXOpenDocumentIO.PALETTES + "/" + MSXOpenDocumentIO.PALETTES_PAL + "[@name='" + itemName + "']")

                        tmpPalette = GetPaletteFromNode(aNodeList.Item(0))
                        If Not tmpPalette Is Nothing Then
                            Me.Project.Palettes.Add(tmpPalette)
                            newID = tmpPalette.ID
                        Else
                            newID = -1
                        End If

                    End If

                    Return newID

                End If

            Else
                Return -1
            End If

        Catch ex As Exception
            Return -1
        End Try

    End Function



    Public Function LoadOLDpaletteMSXTILESdevtool(ByVal filePath As String) As Boolean
        Dim aXmlDoc As New XmlDocument
        Dim aDataNode As XmlNode
        Dim aNode As XmlNode

        Dim result As Boolean = False

        Dim tmpPalette As New PaletteV9938

        aXmlDoc.Load(filePath)
        aDataNode = aXmlDoc.SelectSingleNode("msxdevtools")

        If Not aDataNode Is Nothing Then
            aNode = aDataNode.SelectSingleNode("palette")
            If Not aNode Is Nothing Then

                tmpPalette = GetPaletteFromNode(aNode)
                If Not tmpPalette Is Nothing Then
                    Me.Project.Palettes.Add(tmpPalette)
                    result = True
                End If

            End If
        End If

        Return result

    End Function



    Private Function SetPalettesFromNode(ByVal aDataNode As XmlNode) As Integer

        Dim lastID As Integer = -1

        Dim aNodeList As XmlNodeList

        Dim tmpPalette As New PaletteV9938


        aNodeList = aDataNode.SelectNodes("palette")
        If Not aNodeList Is Nothing Then
            If aNodeList.Count > 0 Then
                For Each anItemElement As XmlElement In aNodeList
                    tmpPalette = GetPaletteFromNode(anItemElement)
                    If Not tmpPalette Is Nothing Then
                        lastID = Me.Project.Palettes.Add(tmpPalette)
                    End If
                Next
            Else
                ' OLD palette format
                tmpPalette = GetPaletteFromNode(aDataNode)
                If Not tmpPalette Is Nothing Then
                    lastID = Me.Project.Palettes.Add(tmpPalette)
                End If
            End If
        End If


        Return lastID

    End Function



    Public Function GetPaletteFromNodeByID(ByVal aXmlDoc As XmlDocument, ByVal ID As Integer) As iPaletteMSX

        Dim aNodeList As XmlNodeList
        Dim aDataNode As XmlNode

        Dim tmpPalette As PaletteV9938

        aDataNode = aXmlDoc.SelectSingleNode(MSXOpenDocumentIO.ROOT + "/" + MSXOpenDocumentIO.PALETTES) ' comprueba si contiene datos de la paleta msxOpenDocument/palettes
        If Not aDataNode Is Nothing Then
            aNodeList = aDataNode.SelectNodes(MSXOpenDocumentIO.PALETTES_PAL + "[@id='" + CStr(ID) + "']")

            If aNodeList.Count > 0 Then
                tmpPalette = GetPaletteFromNode(aNodeList.Item(0))
            End If

        End If


        Return tmpPalette

    End Function



    ''' <summary>
    ''' Lee los datos de la paleta a partir de un nodo de un docuemento XML.
    ''' </summary>
    ''' <param name="aDataNode"></param>
    ''' <remarks></remarks>
    Public Function GetPaletteFromNode(ByVal aDataNode As XmlNode) As iPaletteMSX   'As Boolean 'ByVal aPalette As PaletteV9938

        Dim result As Boolean = True

        Dim aNode As XmlNode
        Dim anAttribute As XmlAttribute
        Dim aNodeList As XmlNodeList

        Dim tmpPalette As New PaletteV9938

        Dim index As Integer
        Dim red As Integer
        Dim green As Integer
        Dim blue As Integer

        Try

            aNode = aDataNode.SelectSingleNode("@id")
            If aNode Is Nothing Then
                'tmpPalette.ID = 0  ' <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< OJO
            Else
                If aNode.InnerText = "" Then
                    '    tmpPalette.ID = 0
                Else
                    If aNode.InnerText.Length > 3 Then
                        tmpPalette.ID = CInt(aNode.InnerText)
                    End If
                End If
            End If

            aNode = aDataNode.SelectSingleNode("@name")
            If aNode Is Nothing Then
                tmpPalette.Name = "NO_NAME"
            Else
                tmpPalette.Name = aNode.InnerText
            End If


            aNodeList = aDataNode.SelectNodes("color")
            For Each anItemElement As XmlElement In aNodeList

                anAttribute = anItemElement.GetAttributeNode(MSXOpenDocumentIO.ITEM_INDEX)
                If anAttribute Is Nothing Then
                    anAttribute = anItemElement.GetAttributeNode("id") ' OLD BAD format 
                    If anAttribute Is Nothing Then
                        index = 0
                    Else
                        index = anAttribute.InnerText
                    End If
                Else
                    index = anAttribute.InnerText
                End If

                anAttribute = anItemElement.GetAttributeNode("red")
                If anAttribute Is Nothing Then
                    red = 0
                Else
                    red = anAttribute.InnerText
                End If

                anAttribute = anItemElement.GetAttributeNode("green")
                If anAttribute Is Nothing Then
                    green = 0
                Else
                    green = anAttribute.InnerText
                End If

                anAttribute = anItemElement.GetAttributeNode("blue")
                If anAttribute Is Nothing Then
                    blue = 0
                Else
                    blue = anAttribute.InnerText
                End If

                tmpPalette.SetColor(index, New ColorMSX(index, red, green, blue))

            Next

            'Add(tmpPalette)

        Catch ex As Exception
            tmpPalette = Nothing
        End Try


        Return tmpPalette


    End Function



    Public Function GetPalettesElement(ByRef aXmlDoc As XmlDocument) As XmlElement

        Return GetPaletteElementByID(aXmlDoc, -1)

    End Function



    Public Function GetPaletteElementByID(ByRef aXmlDoc As XmlDocument, ByVal ID As Integer) As XmlElement

        Dim anElement As XmlElement

        If ID = -1 Or Me.Project.Palettes.Contains(ID) Then

            anElement = aXmlDoc.CreateElement(MSXOpenDocumentIO.PALETTES) '  "palettes")

            If ID = -1 Then
                For Each item As iPaletteMSX In Me.Project.Palettes.Values
                    If item.Type = iPaletteMSX.VDP.V9938 Then
                        anElement.AppendChild(GetPaletteElementByPalette(aXmlDoc, item))
                    End If
                Next
            Else
                anElement.AppendChild(GetPaletteElementByPalette(aXmlDoc, Me.Project.Palettes.GetPaletteByID(ID)))
            End If


            Return anElement

        Else

            Return Nothing

        End If

    End Function



    Public Function GetPaletteElementByPalette(ByRef aXmlDoc As XmlDocument, ByVal item As iPaletteMSX) As XmlElement

        Dim anElement As XmlElement
        Dim anItemElement As XmlElement
        Dim anAttribute As XmlAttribute

        Dim aColor As ColorMSX

        anElement = aXmlDoc.CreateElement(MSXOpenDocumentIO.PALETTES_PAL) ' "palette"

        anAttribute = aXmlDoc.CreateAttribute("id")
        anAttribute.Value = CStr(item.ID)
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("name")
        anAttribute.Value = item.Name
        anElement.SetAttributeNode(anAttribute)



        For i As Integer = 1 To 15 'Each aColor As ColorMSX In item.Colors.Values
            aColor = item.GetMSXColor(i)

            anItemElement = aXmlDoc.CreateElement(MSXOpenDocumentIO.PALETTES_ITEM) ' "color"
            anElement.AppendChild(anItemElement)

            anAttribute = aXmlDoc.CreateAttribute(MSXOpenDocumentIO.ITEM_INDEX)
            anAttribute.Value = CStr(i) 'aColor.id
            anItemElement.SetAttributeNode(anAttribute)

            anAttribute = aXmlDoc.CreateAttribute("red")
            anAttribute.Value = aColor.Red
            anItemElement.SetAttributeNode(anAttribute)

            anAttribute = aXmlDoc.CreateAttribute("green")
            anAttribute.Value = aColor.Green
            anItemElement.SetAttributeNode(anAttribute)

            anAttribute = aXmlDoc.CreateAttribute("blue")
            anAttribute.Value = aColor.Blue
            anItemElement.SetAttributeNode(anAttribute)
        Next

        Return anElement

    End Function



#End Region
    ' ############################################################################################################################# END PALETTES





    ' ############################################################################################################################# TILESETS
#Region "TILESETS functions"


    Public Function SaveTilesetsProject(ByVal filePath As String) As Boolean

        Return SaveTileset(filePath, -1)

    End Function



    Public Function SaveTileset(ByVal filePath As String, ByVal ID As Integer) As Boolean

        Dim aXmlDoc As New XmlDocument
        Dim rootElement As XmlElement

        Try

            rootElement = GetHeaderDataElement(aXmlDoc)

            ' project data #####################################################
            rootElement.AppendChild(GetInfoElement(aXmlDoc, Me.Project.Info))
            ' END project data #################################################


            If ID > 0 Then

                ' gfx data (tileset) ##############################################
                rootElement.AppendChild(GetTilesetProjectElement(aXmlDoc, ID))
                ' end gfx data ##############################################

            Else
                ' palette data #####################################################
                If Me.Project.Palettes.Count > 0 Then
                    rootElement.AppendChild(GetPalettesElement(aXmlDoc))
                End If
                ' END palette data #################################################


                ' tilesets data ####################################################
                If Not Me.Project.Tilesets Is Nothing Then
                    rootElement.AppendChild(GetTilesetProjectElement(aXmlDoc))
                Else
                    Return False
                End If
                ' end tilesets data ################################################
            End If


            aXmlDoc.Save(filePath)  ' save file


        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function



    Public Function GetTilesetProjectElement(ByRef aXmlDoc As XmlDocument) As XmlElement
        Return GetTilesetProjectElement(aXmlDoc, -1)
    End Function



    Public Function GetTilesetProjectElement(ByRef aXmlDoc As XmlDocument, ByVal ID As Integer) As XmlElement

        Dim anElement As XmlElement

        If ID = -1 Or Me.Project.Tilesets.Contains(ID) Then

            anElement = aXmlDoc.CreateElement(MSXOpenDocumentIO.TILESETS)

            If ID = -1 Then
                For i As Integer = 0 To Me.Project.Tilesets.Count - 1
                    anElement.AppendChild(GetTilesetElement(aXmlDoc, Me.Project.Tilesets.GetIDFromIndex(i)))
                Next
            Else
                anElement.AppendChild(GetTilesetElement(aXmlDoc, ID))
            End If


            Return anElement

        Else

            Return Nothing

        End If

    End Function



    ''' <summary>
    ''' Provides in XML format (Element), the data of tileset.
    ''' </summary>
    ''' <param name="aXmlDoc"></param>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetTilesetElement(ByRef aXmlDoc As XmlDocument, ByVal ID As Integer) As XmlElement

        Dim anElement As XmlElement
        Dim subElement As XmlElement
        Dim anAttribute As XmlAttribute
        Dim txtElement As XmlText

        Dim genData As New DataFormat

        Dim tileset As TilesetMSX = Me.Project.Tilesets.GetTilesetByID(ID)



        anElement = aXmlDoc.CreateElement(MSXOpenDocumentIO.TILESETS_SET)

        anAttribute = aXmlDoc.CreateAttribute("id")
        anAttribute.Value = CStr(tileset.ID)
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("name")
        anAttribute.Value = tileset.Name
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("mode")
        anAttribute.Value = tileset.Mode
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("foregroundColor")
        anAttribute.Value = CStr(tileset.ForegroundColor)
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("backgroundColor")
        anAttribute.Value = CStr(tileset.BackgroundColor)
        anElement.SetAttributeNode(anAttribute)

        If tileset.Mode = iVDP.SCREEN_MODE.G1 Then
            subElement = aXmlDoc.CreateElement("colors")
            txtElement = aXmlDoc.CreateTextNode(genData.JoinDataHex(tileset.TilesetColorG1))
            subElement.AppendChild(txtElement)
            anElement.AppendChild(subElement)
        End If

        For i As Integer = 0 To 255
            anElement.AppendChild(GetTileElement(aXmlDoc, tileset.GetTile(i)))
        Next

        Return anElement

    End Function



    Private Function GetTileElement(ByRef aXmlDoc As XmlDocument, ByVal tile As TileMSX) As XmlElement

        Dim genData As New DataFormat

        Dim anElement As XmlElement
        Dim anAttribute As XmlAttribute

        anElement = aXmlDoc.CreateElement(MSXOpenDocumentIO.TILESETS_ITEM)

        anAttribute = aXmlDoc.CreateAttribute(MSXOpenDocumentIO.ITEM_INDEX)
        anAttribute.Value = CStr(tile.Index)
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute(MSXOpenDocumentIO.ITEM_PATTERNS)
        anAttribute.Value = genData.JoinDataHex(tile.Pattern)
        anElement.SetAttributeNode(anAttribute)

        'colors
        If tile.Mode = iVDP.SCREEN_MODE.G2 Then
            anAttribute = aXmlDoc.CreateAttribute(MSXOpenDocumentIO.ITEM_COLORS)
            anAttribute.Value = genData.JoinDataHex(tile.Color)
            anElement.SetAttributeNode(anAttribute)
        End If


        Return anElement

    End Function





    Public Function SetTileSetFromNode(ByVal aDataNode As XmlNode) As Integer

        Dim lastID As Integer = -1

        Dim aNodeList As XmlNodeList
        Dim tmpsprites As New SortedList

        aNodeList = aDataNode.SelectNodes(MSXOpenDocumentIO.TILESETS_SET)
        If Not aNodeList Is Nothing Then
            For Each anItemElement As XmlElement In aNodeList
                lastID = SetTileSetFromElement(anItemElement)
            Next
        End If

        Return lastID

    End Function



    Public Function SetTileSetFromElement(ByVal anElement As XmlElement) As Integer

        Dim lastID As Integer = -1

        Dim genData As New DataFormat

        Dim aNodeList As XmlNodeList
        Dim subNode As XmlNode
        Dim anAttribute As XmlAttribute
        Dim tmpString As String

        Dim tilesette As TilesetMSX
        Dim tilesetName As String
        Dim tilesetID As Integer
        Dim tilesetMode As iVDP.SCREEN_MODE
        Dim tilesetPaletteID As Integer = 0
        Dim tilesetFGColor As Byte = 15
        Dim tilesetBGColor As Byte = 4

        Dim tileNumber As Integer
        Dim tmpPattern(7) As Byte
        Dim tmpColor(7) As Byte
        Dim tilesetColorG1(31) As Byte

        Dim tmpTile As TileMSX
        Dim tmpTiles As New SortedList(255)

        Dim tmpPalette As iPaletteMSX


        'Try
        '<tileset id="0">
        anAttribute = anElement.GetAttributeNode("id")
        If anAttribute Is Nothing Then
            tilesetID = 0
        Else
            tmpString = anAttribute.InnerText
            If IsNumeric(tmpString) Then
                tilesetID = CInt(tmpString)
            Else
                tilesetID = 0
            End If
        End If


        anAttribute = anElement.GetAttributeNode("name")
        If anAttribute Is Nothing Then
            tilesetName = "tileset_"
        Else
            tilesetName = anAttribute.InnerText
        End If


        anAttribute = anElement.GetAttributeNode("mode")
        If anAttribute Is Nothing Then
            tilesetMode = iVDP.SCREEN_MODE.G2
        Else
            tilesetMode = CInt(anAttribute.InnerText)
        End If

        anAttribute = anElement.GetAttributeNode("paletteID")
        If anAttribute Is Nothing Then
            tilesetPaletteID = 0
            tmpPalette = Me.Project.Palettes.GetPalette(0)
        Else
            tilesetPaletteID = CInt(anAttribute.InnerText)
            tmpPalette = Me.Project.Palettes.GetPaletteByID(tilesetPaletteID)
        End If


        anAttribute = anElement.GetAttributeNode("foregroundColor")
        If anAttribute Is Nothing Then
            tilesetFGColor = PaletteTMS9918.MSX_Palette.White
        Else
            tilesetFGColor = CInt(anAttribute.InnerText)
        End If


        anAttribute = anElement.GetAttributeNode("backgroundColor")
        If anAttribute Is Nothing Then
            tilesetBGColor = PaletteTMS9918.MSX_Palette.Dark_Blue
        Else
            tilesetBGColor = CInt(anAttribute.InnerText)
        End If

        'tileset = New TilesetMSX(Me._paletteProject, tilesetName, tilesetMode, tilesetPaletteID, tilesetFGColor, tilesetBGColor)


        subNode = anElement.SelectSingleNode("colors")
        If subNode Is Nothing Then
            'default G1 colors
            For i As Integer = 0 To 31
                tilesetColorG1(i) = (tilesetFGColor * 16) + tilesetBGColor
            Next
        Else
            'tileset.Mode = TMS9918.SCREEN_MODE.G1
            tmpString = anElement.InnerText()
            If Not tmpString = "" Then
                tilesetColorG1 = genData.ByteSpliterHex(tmpString)
                'Me.TMS9918viewer.SetBlock(TMS9918.TableBase.T32COL, data)
            End If
        End If


        aNodeList = anElement.SelectNodes(MSXOpenDocumentIO.TILESETS_ITEM)
        If aNodeList.Count > 0 Then

            '<tile index="0" gfxData="0000000000000000" colorData="4444444444444444" />
            For Each anItemElement As XmlElement In aNodeList
                anAttribute = anItemElement.GetAttributeNode(MSXOpenDocumentIO.ITEM_INDEX)
                tileNumber = CByte(anAttribute.InnerText)
                If tileNumber < 256 Then
                    anAttribute = anItemElement.GetAttributeNode(MSXOpenDocumentIO.ITEM_PATTERNS)
                    tmpPattern = genData.ByteSpliterHex(anAttribute.InnerText.Substring(0, 16))

                    Select Case tilesetMode
                        Case iVDP.SCREEN_MODE.T1
                            'tileset.SetTileT1(tileNumber, tmpPattern)
                            tmpTile = New TileMSX(tileNumber, tilesetMode, tmpPattern, Nothing, tmpPalette, tilesetFGColor, tilesetBGColor)
                        Case iVDP.SCREEN_MODE.G1
                            'tileset.SetTileG1(tileNumber, tmpPattern, CInt(tileset.TilesetColorG1(Fix(tileNumber / 8)) And 240) / 16, CInt(tileset.TilesetColorG1(Fix(tileNumber / 8)) And 15))
                            tmpTile = New TileMSX(tileNumber, tilesetMode, tmpPattern, Nothing, tmpPalette, CInt(tilesetColorG1(Fix(tileNumber / 8)) And 240) / 16, CInt(tilesetColorG1(Fix(tileNumber / 8)) And 15))
                        Case Else
                            anAttribute = anItemElement.GetAttributeNode(MSXOpenDocumentIO.ITEM_COLORS)
                            If Not anAttribute Is Nothing Then
                                ' si no contiene la información de color, es por que se le ha dado el valor de modo por defecto a screen2
                                ' puede ser modo screen0 o screen1. 
                                'tileset.Mode = TMS9918.SCREEN_MODE.T1  ' lo corregimos poniendolo a screen0
                                'tilesette.SetTileT1(tileNumber, tmpPattern)
                                'tmpTile = New TileMSX(tileNumber, tilesetMode, tmpPattern, Nothing, Me._Palette, tilesetFGColor, tilesetBGColor)
                                'tmpTiles.Add(tileNumber, tmpTile)
                                'Else
                                tmpColor = genData.ByteSpliterHex(anAttribute.InnerText.Substring(0, 16))
                                'tileset.SetTileG2(tileNumber, tmpPattern, tmpColor)
                                tmpTile = New TileMSX(tileNumber, tilesetMode, tmpPattern, tmpColor, tmpPalette, tilesetFGColor, tilesetBGColor)
                            End If

                    End Select
                    tmpTiles.Add(tileNumber, tmpTile)

                End If
            Next

        Else
            ' OLD format suport - MSXTILES devtool
            '<item id="0">
            '  <gfxData>0,0,0,0,0,0,0,0,0</gfxData>
            '  <colorData>17,17,17,17,17,17,17,17,0</colorData>
            '</item>
            aNodeList = anElement.SelectNodes("item")
            For Each anItemElement As XmlElement In aNodeList
                anAttribute = anItemElement.GetAttributeNode("id")
                tileNumber = CByte(anAttribute.InnerText)
                If tileNumber < 256 Then
                    subNode = anItemElement.SelectSingleNode(MSXOpenDocumentIO.ITEM_PATTERNS)

                    tmpString = subNode.InnerText
                    tmpPattern = genData.ByteSpliter(tmpString, 8, 0)

                    Select Case tilesetMode
                        Case iVDP.SCREEN_MODE.T1
                            'tileset.SetTileT1(tileNumber, tmpPattern)
                            tmpTile = New TileMSX(tileNumber, tilesetMode, tmpPattern, Nothing, tmpPalette, tilesetFGColor, tilesetBGColor)

                        Case iVDP.SCREEN_MODE.G1
                            'tileset.SetTileG1(tileNumber, tmpPattern, CInt(tileset.TilesetColorG1(Fix(tileNumber / 8)) And 240) / 16, CInt(tileset.TilesetColorG1(Fix(tileNumber / 8)) And 15))
                            tmpTile = New TileMSX(tileNumber, tilesetMode, tmpPattern, Nothing, tmpPalette, CInt(tilesetColorG1(Fix(tileNumber / 8)) And 240) / 16, CInt(tilesetColorG1(Fix(tileNumber / 8)) And 15))

                        Case Else
                            subNode = anItemElement.SelectSingleNode(MSXOpenDocumentIO.ITEM_COLORS)
                            If Not subNode Is Nothing Then
                                tmpString = subNode.InnerText
                                tmpColor = genData.ByteSpliter(tmpString, 8, 0)
                                'tileset.SetTileG2(tileNumber, tmpPattern, tmpColor)

                                'tmpColor = genData.ByteSpliterHex(anAttribute.InnerText.Substring(0, 16))
                                tmpTile = New TileMSX(tileNumber, tilesetMode, tmpPattern, tmpColor, tmpPalette, tilesetFGColor, tilesetBGColor)
                            End If
                    End Select

                    tmpTiles.Add(tileNumber, tmpTile)
                End If
            Next
        End If

        If tilesetMode = iVDP.SCREEN_MODE.G1 Then
            ' gfx mode 1 (G1)
            tilesette = New TilesetMSX(tilesetID, tmpPalette, tilesetName, tmpTiles, tilesetColorG1, tilesetFGColor, tilesetBGColor)
        Else
            ' gfx modes T1 or G2
            tilesette = New TilesetMSX(tilesetID, tmpPalette, tilesetName, tilesetMode, tmpTiles, tilesetFGColor, tilesetBGColor)
        End If


        lastID = Me.Project.Tilesets.Add(tilesette)

        Return lastID

        'Catch ex As Exception
        '    Return False
        'End Try
    End Function



    Public Function LoadTileset(ByVal filePath As String, itemName As String) As Integer

        Dim newID As Integer = -1

        'Dim result As Boolean = True

        Dim aXmlDoc As New XmlDocument
        Dim aNodeList As XmlNodeList
        Dim aDataNode As XmlNode
        Dim aNode As XmlNode

        'Dim itemName As String = ""
        'Dim nameList As ArrayList
        'Dim allItems As Boolean = False


        Try

            aXmlDoc.Load(filePath)


            aDataNode = aXmlDoc.SelectSingleNode(MSXOpenDocumentIO.ROOT)
            If Not aDataNode Is Nothing Then


                '##################################################################################################
                'leer lista de tilesets y mostrar ventana con un selector
                '
                'aDataNode = aXmlDoc.SelectSingleNode(MSXOpenDocumentIO.ROOT + "/gfx")
                aNode = aDataNode.SelectSingleNode(MSXOpenDocumentIO.TILESETS)
                If Not aNode Is Nothing Then


                    ' Get tileset List
                    'nameList = GetNameListFromNode(aDataNode, MSXOpenDocumentIO.TILESETS_SET)

                    '' si solo hay uno, lo carga directamente
                    'If nameList.Count = 1 Then
                    '    itemName = nameList.Item(0)
                    'ElseIf nameList.Count > 1 Then
                    '    ' show win with Map selector
                    '    Dim aListSelectorDialog As New ListSelectorDialog("Load Tileset", "Select a Tileset:", "All Tilesets", nameList)
                    '    If aListSelectorDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    '        itemName = aListSelectorDialog.SelectedItem()
                    '    End If
                    'End If



                    If itemName = "" Then

                        newID = SetTileSetFromNode(aNode)

                    Else
                        ' load selected Tileset
                        aNodeList = aNode.SelectNodes(MSXOpenDocumentIO.ROOT + "/" + MSXOpenDocumentIO.TILESETS + "/" + MSXOpenDocumentIO.TILESETS_SET + "[@name='" + itemName + "']")
                        newID = SetTileSetFromElement(aNodeList.Item(0))
                    End If

                    'aDataNode = aXmlDoc.SelectSingleNode("msxdevtools/gfx")
                    'If aDataNode Is Nothing Then
                    '    result = False
                    'Else
                    '    'Me._tilesetProject.Clear()
                    '    Me._tilesetProject.SetFromNode(aDataNode)
                    'End If
                    '##################################################################################################


                    '##################################################################################################
                    'Cargar paleta asociada al tileset
                    'o cargar todas las paletas, segun selección

                    '
                    '##################################################################################################



                End If




            End If

        Catch ex As Exception
            newID = -1
        End Try


        Return newID

    End Function




#End Region
    ' ############################################################################################################################# END TILESETS





    ' ############################################################################################################################# SPRITES
#Region "Sprites functions"



    Public Function SaveSpriteProject(ByVal filePath As String) As Boolean

        Return SaveSpriteset(filePath, -1)

    End Function



    Public Function SaveSpriteset(ByVal filePath As String, ID As Integer) As Boolean

        Dim aXmlDoc As New XmlDocument
        Dim rootElement As XmlElement
        Dim anElement As XmlElement

        Try

            rootElement = GetHeaderDataElement(aXmlDoc)

            ' project data #####################################################
            rootElement.AppendChild(GetInfoElement(aXmlDoc, Me.Project.Info))
            ' END project data #################################################


            If ID > 0 Then

                anElement = GetSpritesProjectElement(aXmlDoc, ID)  'aXmlDoc.CreateElement("sprites")
                rootElement.AppendChild(anElement)

            Else
                ' palette data #####################################################
                If Me.Project.Palettes.Count > 0 Then
                    rootElement.AppendChild(GetPalettesElement(aXmlDoc))
                End If
                ' END palette data #################################################


                ' sprites data #####################################################
                ' Sprite Patterns & V9938 colors
                If Not Me.Project.SpriteSets Is Nothing Then
                    rootElement.AppendChild(GetSpritesProjectElement(aXmlDoc))
                Else
                    Return False
                End If
                ' END sprites data #################################################
            End If


            aXmlDoc.Save(filePath)  ' save file


        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function



    Public Function LoadSpriteset(ByVal filePath As String, itemName As String) As Integer

        Dim newID As Integer

        'Dim itemName As String = ""
        'Dim nameList As ArrayList
        'Dim allItems As Boolean = False

        Dim aXmlDoc As New XmlDocument
        Dim aNodeList As XmlNodeList
        Dim aDataNode As XmlNode
        Dim aNode As XmlNode


        Dim gfxData As String = ""
        Dim colorData As String = ""

        Dim tmpSpriteset As SpritesetMSX

        Dim paletteID As Integer

        Dim tmpPalette As PaletteV9938


        aXmlDoc.Load(filePath)


        aDataNode = aXmlDoc.SelectSingleNode(MSXOpenDocumentIO.ROOT)
        If Not aDataNode Is Nothing Then


            aNode = aDataNode.SelectSingleNode(MSXOpenDocumentIO.SPRITES) '"spritePRJ"
            If Not aNode Is Nothing Then





                ' Get Map List
                'nameList = GetNameListFromNode(aNode, MSXOpenDocumentIO.SPRITES_SET)

                '' si solo hay uno, lo carga directamente
                'If nameList.Count = 1 Then
                '    itemName = nameList.Item(0)
                'ElseIf nameList.Count > 1 Then
                '    ' show win with Map selector
                '    Dim aListSelectorDialog As New ListSelectorDialog("Load Spriteset", "Select a Spriteset:", "All Spritesets", nameList)
                '    If aListSelectorDialog.ShowDialog() = DialogResult.OK Then
                '        itemName = aListSelectorDialog.SelectedItem()
                '        If aListSelectorDialog.SelectedIndex = 0 Then
                '            allItems = True
                '        End If
                '    End If
                'End If





                If itemName = "" Then

                        aNode = aDataNode.SelectSingleNode(MSXOpenDocumentIO.PALETTES) ' comprueba si contiene datos de la paleta
                        If Not aNode Is Nothing Then
                            SetPalettesFromNode(aNode)
                        End If

                        aNode = aDataNode.SelectSingleNode(MSXOpenDocumentIO.SPRITES)
                        If Not aNode Is Nothing Then
                            newID = SetSpriteProjectFromNode(aNode)
                        End If

                    Else

                    ' load selected spritesET
                    aNodeList = aXmlDoc.SelectNodes(MSXOpenDocumentIO.ROOT + "/" + MSXOpenDocumentIO.SPRITES + "/" + MSXOpenDocumentIO.SPRITES_SET + "[@name='" + itemName + "']")
                    'newID = Me._spriteProject.SetSpritesetFromNode(aNodeList.Item(0))

                    aNode = aNodeList.Item(0).SelectSingleNode("@paletteID")
                        If aNode Is Nothing Then
                            paletteID = 0 'TMS9918 palette
                        Else
                            paletteID = CInt(aNode.InnerText)
                        End If

                        If paletteID > 0 Then
                            tmpPalette = GetPaletteFromNodeByID(aXmlDoc, paletteID)
                            If Not tmpPalette Is Nothing Then
                                Me.Project.Palettes.Add(tmpPalette)
                            End If
                        End If


                    tmpSpriteset = GetSpritesetFromNode(aNodeList.Item(0))

                    If Not tmpSpriteset Is Nothing Then
                        newID = Me.Project.SpriteSets.Add(tmpSpriteset)
                    Else
                        newID = -1
                    End If
                End If



            End If



        Else
            ' OLD format ----------------------------------------------------

            newID = LoadOLDspriteSXProject(filePath, False)

            ' ---------------------------------------------------- OLD format
        End If



        Return newID

    End Function



    ''' <summary>
    ''' Load spriteSX Project OLD Format (v0.9.3+)
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <returns></returns>
    Public Function LoadOLDspriteSXProject(ByVal filePath As String, ByVal have2Clean As Boolean) As Integer

        Dim aXmlDoc As New XmlDocument
        Dim aDataNode As XmlNode
        Dim aNode As XmlNode

        Dim tmpPalette As PaletteV9938
        Dim tmpSpriteset As SpritesetMSX

        'Dim paletteID As Integer = -1
        Dim spritesetID As Integer = -1


        'Dim prjname As String = Path.GetFileNameWithoutExtension(filePath)

        aXmlDoc.Load(filePath)

        '<msxdevtools app="spriteSX devtool" version="0.9.3.0">
        aDataNode = aXmlDoc.SelectSingleNode("msxdevtools")
        If aDataNode Is Nothing Then
            aDataNode = aXmlDoc.SelectSingleNode("spriteSX")
        End If
        If Not aDataNode Is Nothing Then

            'If have2Clean = True Then
            '    Me.Project.Clear()
            'End If


            '<palette name="Color MSX Palette" group="" version="" author="">
            '   <color id = "0" red="0" green="0" blue="0" />
            '</palette>
            aNode = aDataNode.SelectSingleNode("palette")
            If Not aNode Is Nothing Then
                'Me.Project.Palettes.Info.Name = prjname + "_PAL"
                tmpPalette = GetPaletteFromNode(aNode)
                If Not tmpPalette Is Nothing Then
                    Me.Project.Palettes.Add(tmpPalette)
                End If
            End If
            Me.Project.Palettes.SetZeroColor(Me.AppConfig.Color_Zero)


            '<sprites name="Frutas 16x" version="1" group="303bcn" author="mvac7" startDate="635400288000000000" lastUpdate="635400288000000000" mode="1" type="2">
            '<description></description>
            aNode = aDataNode.SelectSingleNode("sprites")
            If have2Clean = True Then
                Me.Project.Info = GetInfoFromNode(aNode, Path.GetFileNameWithoutExtension(filePath))
            End If
            tmpSpriteset = GetSpritesetFromNode(aNode)
            If Not tmpSpriteset Is Nothing Then
                If Not tmpPalette Is Nothing Then
                    tmpSpriteset.SetPalette(tmpPalette)
                End If
                spritesetID = Me.Project.SpriteSets.Add(tmpSpriteset)
            Else
                spritesetID = -1
            End If

        Else

            Return -1

        End If

        Return spritesetID


    End Function



    'OLD Format (v0.9.4)
    Public Function AddOLDspriteSXProject(ByVal filePath As String) As Integer

        Return LoadOLDspriteSXProject(filePath, False)

    End Function



    Public Function GetSpritesProjectElement(ByRef aXmlDoc As XmlDocument) As XmlElement
        Return GetSpritesProjectElement(aXmlDoc, -1)
    End Function




    Public Function GetSpritesProjectElement(ByRef aXmlDoc As XmlDocument, ByVal ID As Integer) As XmlElement

        Dim anElement As XmlElement
        'Dim anItemElement As XmlElement

        Dim spriteSet As SpritesetMSX


        If ID = -1 Or Me.Project.SpriteSets.Contains(ID) Then

            anElement = aXmlDoc.CreateElement(MSXOpenDocumentIO.SPRITES)


            'anItemElement = Me.Info.GetElement(aXmlDoc)
            'anElement.AppendChild(anItemElement)


            If ID = -1 Then
                For i As Integer = 0 To Me.Project.SpriteSets.Count - 1
                    spriteSet = Me.Project.SpriteSets.GetSpriteset(i)
                    If spriteSet.isModified Then
                        anElement.AppendChild(GetElementSpriteset(aXmlDoc, spriteSet)) 'Me.NamesList.GetIDbyIndex(i)))
                    End If
                Next
            Else
                spriteSet = Me.Project.SpriteSets.GetSpritesetByID(ID)
                If spriteSet.isModified Then
                    anElement.AppendChild(GetElementSpriteset(aXmlDoc, spriteSet))
                End If
            End If

            Return anElement

        Else

            Return Nothing

        End If

    End Function





    Private Function GetElementSpriteset(ByRef aXmlDoc As XmlDocument, ByVal spriteSet As SpritesetMSX) As XmlElement

        Dim anElement As XmlElement
        Dim anItemElement As XmlElement
        Dim anAttribute As XmlAttribute

        Dim tmpSprite As SpriteMSX

        Dim numSprites As Integer = 255

        'Dim spriteSet As SpritesetMSX = GetSpritesetByID(ID)


        If spriteSet.Size = SpriteMSX.SPRITE_SIZE.SIZE16 Then
            numSprites = 63
        End If


        anElement = aXmlDoc.CreateElement(MSXOpenDocumentIO.SPRITES_SET)

        anAttribute = aXmlDoc.CreateAttribute("id")
        anAttribute.Value = CStr(spriteSet.ID)
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("name")
        anAttribute.Value = spriteSet.Name
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("size") 'type
        anAttribute.Value = CStr(spriteSet.Size)
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("mode")
        anAttribute.Value = CStr(spriteSet.Mode)
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("paletteID")
        anAttribute.Value = CStr(spriteSet.Palette.ID)
        anElement.SetAttributeNode(anAttribute)



        For i As Integer = 0 To numSprites

            tmpSprite = spriteSet.GetSprite(i)

            If Not tmpSprite.Name = "" Then
                ' si contiene nombre aunque el sprite este vacio, se entiende que tiene una funcion especifica en el set
                anItemElement = GetSpriteNode(aXmlDoc, tmpSprite)
                anElement.AppendChild(anItemElement)

            ElseIf Not tmpSprite.isEmpty Then
                'solo guarda los sprites con contenido grafico
                anItemElement = GetSpriteNode(aXmlDoc, tmpSprite)
                anElement.AppendChild(anItemElement)

            End If

        Next

        Return anElement

    End Function



    Private Function GetSpriteNode(ByRef aXmlDoc As XmlDocument, tmpSprite As SpriteMSX) As XmlElement

        Dim anElement As XmlElement
        Dim subElement As XmlElement
        'Dim anItemElement As XmlElement
        Dim anAttribute As XmlAttribute
        Dim txtElement As XmlText

        Dim genData As New DataFormat

        Dim tmpColorData(15) As Byte


        anElement = aXmlDoc.CreateElement(MSXOpenDocumentIO.SPRITES_ITEM) 'item


        anAttribute = aXmlDoc.CreateAttribute(MSXOpenDocumentIO.ITEM_INDEX) 'order y id
        anAttribute.Value = CStr(tmpSprite.Index)
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("name")
        anAttribute.Value = tmpSprite.Name
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("InkColor")
        anAttribute.Value = CStr(tmpSprite.InkColor)
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("BGcolor")
        anAttribute.Value = CStr(tmpSprite.BackgroundColor)
        anElement.SetAttributeNode(anAttribute)

        If Not tmpSprite.isPatternEmpty Then
            ' no guarda los datos de los sprites vacios.

            subElement = aXmlDoc.CreateElement(MSXOpenDocumentIO.ITEM_PATTERNS)
            txtElement = aXmlDoc.CreateTextNode(genData.JoinDataHex(tmpSprite.patternData)) 'joinData
            subElement.AppendChild(txtElement)
            anElement.AppendChild(subElement)

        End If


        If Not tmpSprite.isColorEmpty Then 'spriteSet.Mode = SpriteMSX.SPRITE_MODE.COLOR Then
            subElement = aXmlDoc.CreateElement(MSXOpenDocumentIO.ITEM_COLORS)
            tmpColorData = Me.Project.SpriteSets.JoinColorData(tmpSprite.ColorData, tmpSprite.ORbitData)
            txtElement = aXmlDoc.CreateTextNode(genData.JoinDataHex(tmpColorData)) 'joinData
            subElement.AppendChild(txtElement)
            anElement.AppendChild(subElement)
        End If


        Return anElement


    End Function




    'Public Function GetNameListFromNode_DEPRECATED(ByVal aDataNode As XmlNode, typeName As String) As ArrayList

    '    Dim nameList As New ArrayList

    '    Dim aNodeList As XmlNodeList
    '    Dim aNode As XmlNode

    '    aNodeList = aDataNode.SelectNodes(typeName) '"spriteSET"
    '    If Not aNodeList Is Nothing Then
    '        For Each anItemNode As XmlNode In aNodeList
    '            aNode = anItemNode.SelectSingleNode("@name")
    '            If Not aNode Is Nothing Then
    '                nameList.Add(aNode.InnerText)
    '            End If
    '        Next
    '    End If

    '    Return nameList

    'End Function



    Public Function GetNameListByNodeName(ByVal filePath As String, ByVal aNodeName As String, typeName As String) As ArrayList

        Dim nameList As New ArrayList

        Dim aXmlDoc As New XmlDocument
        Dim aNodeList As XmlNodeList
        Dim aRootNode As XmlNode
        Dim aDataNode As XmlNode
        Dim aNode As XmlNode

        aXmlDoc.Load(filePath)


        aRootNode = aXmlDoc.SelectSingleNode(MSXOpenDocumentIO.ROOT)
        If Not aRootNode Is Nothing Then

            aDataNode = aRootNode.SelectSingleNode(aNodeName)
            If aDataNode Is Nothing Then

                Return Nothing

            Else

                aNodeList = aDataNode.SelectNodes(typeName)
                If Not aNodeList Is Nothing Then
                    For Each anItemNode As XmlNode In aNodeList
                        aNode = anItemNode.SelectSingleNode("@name")
                        If Not aNode Is Nothing Then
                            nameList.Add(aNode.InnerText)
                        End If
                    Next
                End If

                Return nameList

            End If

        End If

        Return Nothing

    End Function



    '<msxdevtools app="tMS gfX devtool" version="0.9.9.4">

    '  <spritePRJ>
    '    <ProjectInfo name="sprite project Name" group="" version="" author="" startDate="0" lastUpdate="636271200000000000">
    '       <description></description>
    '    </ProjectInfo>   
    '    <spriteset id="40452378" name="set name" size="2" mode="1" paletteID="0">
    '      <sprite index="0" name="SPR_0" InkColor="15" BGcolor="1">
    '        <gfxData>FC82828482916804020100000000000000000000000080402040800000000000</gfxData>
    '      </sprite>
    '      <sprite index="2" name="SPR_16" InkColor="14" BGcolor="1">   
    '        <gfxData>043CFEFA62010100000000000000000000000000000000000000000000000000</gfxData>
    '        <colorData>0F0F0F0F0E0E0E0E0E0E0E0E0E0E0E0E</colorData>     <!-- mode=2 -->
    '      </sprite>
    '      <sprite index="n" name="SPR_n" InkColor="11" BGcolor="1">
    '      <sprite index="63" name="SPR_63" InkColor="15" BGcolor="1" />
    '    </spriteset>
    '  </spritePRJ>

    '</msxdevtools>

    Public Function SetSpriteProjectFromNode(ByVal aDataNode As XmlNode) As Integer

        'Dim aNode As XmlNode
        Dim aNodeList As XmlNodeList

        Dim tmpSpriteset As SpritesetMSX

        Dim lastID As Integer = -1


        'Clear()


        ' get project info ############################################
        'aNode = aDataNode.SelectSingleNode("ProjectInfo")
        'If aNode Is Nothing Then
        '    Me.Info = New ProjectInfo()
        'Else
        '    Me.Info.SetFromNode(aNode)
        'End If


        ' get sprites ##########################################
        aNodeList = aDataNode.SelectNodes(MSXOpenDocumentIO.SPRITES_SET)
        If aNodeList.Count = 0 Then
            'old format
            tmpSpriteset = GetSpritesetFromNode(aDataNode)
            If Not tmpSpriteset Is Nothing Then
                lastID = Me.Project.SpriteSets.Add(tmpSpriteset)
            End If

        Else
            For Each anItemElement As XmlElement In aNodeList
                tmpSpriteset = GetSpritesetFromNode(anItemElement)
                If Not tmpSpriteset Is Nothing Then
                    lastID = Me.Project.SpriteSets.Add(tmpSpriteset)
                End If
            Next
        End If

        Return lastID

    End Function



    Public Function GetSpritesetFromNode(ByVal aDataNode As XmlNode) As SpritesetMSX

        Dim aNode As XmlNode
        Dim anAttribute As XmlAttribute
        Dim aNodeList As XmlNodeList
        Dim subNode As XmlNode

        Dim tmpSpriteset As SpritesetMSX

        Dim tmpPalette As iPaletteMSX

        Dim tmpSetName As String = ""
        Dim tmpID As Integer
        Dim tmpSize As SpriteMSX.SPRITE_SIZE
        Dim tmpMode As SpriteMSX.SPRITE_MODE
        Dim tmpPaletteID As Integer

        Dim index As Integer = 0
        Dim tmpSpriteName As String
        Dim tmpInkColor As Byte
        Dim tmpBGcolor As Byte
        'Dim gfxData As String = ""
        'Dim colorData As String = ""

        Dim i As Integer

        Dim patternData() As Byte
        Dim colorData() As Byte

        Dim genData As New DataFormat



        aNode = aDataNode.SelectSingleNode("@id")
        If aNode Is Nothing Then
            tmpID = -1
        Else
            tmpID = CInt(aNode.InnerText)
        End If


        aNode = aDataNode.SelectSingleNode("@name")
        If Not aNode Is Nothing Then
            tmpSetName = aNode.InnerText
        End If

        If tmpSetName = "" Then
            tmpSetName = "spriteset00"
        End If


        aNode = aDataNode.SelectSingleNode("@size")
        If aNode Is Nothing Then
            aNode = aDataNode.SelectSingleNode("@type")
            If aNode Is Nothing Then
                tmpSize = SpriteMSX.SPRITE_SIZE.SIZE16
            Else
                tmpSize = CInt(aNode.InnerText)
            End If
        Else
            tmpSize = CInt(aNode.InnerText)
        End If


        aNode = aDataNode.SelectSingleNode("@mode")
        If aNode Is Nothing Then
            tmpMode = SpriteMSX.SPRITE_MODE.MONO
        Else
            tmpMode = CInt(aNode.InnerText)
        End If


        'aNode = aDataNode.SelectSingleNode("@InkColor")
        'If aNode Is Nothing Then
        '    tmpInkColor = 15 ' blanco
        'Else
        '    tmpInkColor = CInt(aNode.InnerText)
        'End If

        'aNode = aDataNode.SelectSingleNode("BGcolor")
        'If aNode Is Nothing Then
        '    tmpBGcolor = 1 ' negro
        'Else
        '    tmpBGcolor = CInt(aNode.InnerText)
        'End If


        aNode = aDataNode.SelectSingleNode("@paletteID")
        If aNode Is Nothing Then
            tmpPaletteID = 0 'TMS9918 palette
        Else
            tmpPaletteID = CInt(aNode.InnerText)
        End If



        If Me.Project.Palettes.Contains(tmpPaletteID) Then
            tmpPalette = Me.Project.Palettes.GetPaletteByID(tmpPaletteID)
        Else
            tmpPalette = Me.Project.Palettes.GetPalette(0)
        End If


        '
        If tmpID = -1 Then
            tmpSpriteset = New SpritesetMSX(tmpSetName, tmpSize, tmpMode, 15, 0, tmpPalette)
        Else
            tmpSpriteset = New SpritesetMSX(tmpID, tmpSetName, tmpSize, tmpMode, tmpPalette)
        End If


        If tmpSize = SpriteMSX.SPRITE_SIZE.SIZE8 Then
            ReDim patternData(7)
            'ReDim colorData(7)
        Else
            ReDim patternData(31)
            'ReDim colorData(15)
        End If
        ReDim colorData(15)


        ' get sprites ##########################################
        aNodeList = aDataNode.SelectNodes(MSXOpenDocumentIO.SPRITES_ITEM)
        If aNodeList.Count = 0 Then
            aNodeList = aDataNode.SelectNodes("item") 'OLD format v0.9b
        End If
        For Each anItemElement As XmlElement In aNodeList

            anAttribute = anItemElement.GetAttributeNode(MSXOpenDocumentIO.ITEM_INDEX)
            If anAttribute Is Nothing Then
                'anAttribute = anItemElement.GetAttributeNode("id") 'DEPRECATED
                'If anAttribute Is Nothing Then
                anAttribute = anItemElement.GetAttributeNode("order") 'OLD format v0.9b
                If anAttribute Is Nothing Then
                    index += 1
                Else
                    index = CInt(anAttribute.InnerText) + 1
                End If

            Else
                index = CInt(anAttribute.InnerText) + 1
            End If


            anAttribute = anItemElement.GetAttributeNode("name")
            If anAttribute Is Nothing Then
                tmpSpriteName = "SPR_" + CStr(index - 1)
            Else
                tmpSpriteName = anAttribute.InnerText
            End If


            anAttribute = anItemElement.GetAttributeNode("InkColor")
            If anAttribute Is Nothing Then
                tmpInkColor = 15 ' blanco
            Else
                tmpInkColor = CInt(anAttribute.InnerText)
            End If

            anAttribute = anItemElement.GetAttributeNode("BGcolor")
            If anAttribute Is Nothing Then
                tmpBGcolor = 0 ' negro
            Else
                tmpBGcolor = CInt(anAttribute.InnerText)
            End If

            subNode = anItemElement.SelectSingleNode(MSXOpenDocumentIO.ITEM_PATTERNS)
            'gfxData = subNode.InnerText
            If subNode Is Nothing Then
                For i = 0 To patternData.Length - 1
                    patternData(i) = 0
                Next
            Else
                patternData = genData.ByteSpliter(subNode.InnerText, tmpSpriteset.DataSize, 0)
            End If


            ' recoge o genera los datos de los colores (uno para cada linea para MSX2)
            If tmpMode = SpriteMSX.SPRITE_MODE.MONO Then
                For i = 0 To colorData.Length - 1
                    colorData(i) = tmpInkColor
                Next
                'colorData = genData.JoinDataHex(tmpByte) 'Me.joinData(tmpByte)
            Else
                subNode = anItemElement.SelectSingleNode(MSXOpenDocumentIO.ITEM_COLORS)
                If subNode Is Nothing Then
                    For i = 0 To colorData.Length - 1
                        colorData(i) = tmpInkColor
                    Next
                    'colorData = genData.JoinDataHex(tmpByte) 'Me.joinData(tmpByte)
                Else
                    'colorData = subNode.InnerText
                    colorData = genData.ByteSpliter(subNode.InnerText, 15, 0)
                End If
            End If



            tmpSpriteset.SetSprite(New SpriteMSX(index - 1, tmpSpriteName, tmpSize, tmpMode, tmpInkColor, tmpBGcolor, patternData, colorData, tmpPalette))


        Next

        Return tmpSpriteset 'Add(tmpSpriteset)

    End Function

#End Region
    ' ############################################################################################################################# END SPRITES









End Class
