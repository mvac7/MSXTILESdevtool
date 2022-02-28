Imports System.Xml



Public Class SupertilesProject


    Private Items As New SortedList()
    Private NamesList As New SortedNamesList


    Private Const MAXIMUM = 127 ' <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< maximum number of items



    Public ReadOnly Property Count()
        Get
            Return Items.Count
        End Get
    End Property


    Public Sub New()

        'Me.Info = New ProjectInfo

    End Sub



    Public Sub Clear()

        Me.Items.Clear()
        Me.NamesList.Clear()

    End Sub



    Public Function Add(ByVal item As SupertilesSET) As Integer

        Dim ID As Integer

        If item Is Nothing Then
            Return -1
        End If

        ID = item.ID

        If Me.Items.Count < MAXIMUM Then

            If Me.Items.ContainsKey(ID) Then
                ID = item.GetHashCode + CInt(Rnd() * 100000)
                item.ID = ID
            End If

            item.Name = Me.NamesList.AddName(ID, item.Name)
            Me.Items.Add(ID, item)

            Return ID
        Else
            Return -1
        End If
    End Function




    Public Sub Update(ByVal ID As Integer, ByVal aSquaredset As SupertilesSET)
        If Me.Items.ContainsKey(ID) Then
            Me.Items.Item(ID) = aSquaredset
            aSquaredset.Name = Me.NamesList.UpdateName(ID, aSquaredset.Name)
        End If
    End Sub



    Public Function GetSquaredset(ByVal index As Integer) As SupertilesSET
        Dim ID As Integer = Me.NamesList.GetIDbyIndex(index)
        Return GetSquaredsetByID(ID)
    End Function



    Public Function GetSquaredsetByID(ByVal ID As Integer) As SupertilesSET
        If Me.Items.Contains(ID) Then
            Return Me.Items.Item(ID)
        Else
            Return Nothing
        End If
    End Function



    Public Sub Delete(ByVal index As Integer)
        Dim ID As Integer

        If Me.Items.Count > 0 Then
            ID = Me.NamesList.GetIDbyIndex(index)
            DeleteByID(ID)
        End If

    End Sub



    Public Sub DeleteByID(ByVal ID As Integer)
        If Me.Items.ContainsKey(ID) Then
            Me.Items.Remove(ID)
            Me.NamesList.RemoveByID(ID)
        End If
    End Sub



    Public Function Contains(ByVal ID As Integer) As Boolean
        Return Me.Items.Contains(ID)
    End Function



    Public Function GetElement(ByRef aXmlDoc As XmlDocument) As XmlElement
        Return GetElement(aXmlDoc, -1)
    End Function



    Public Function GetElement(ByRef aXmlDoc As XmlDocument, ByVal ID As Integer) As XmlElement

        Dim anElement As XmlElement

        anElement = aXmlDoc.CreateElement("squaredProject")


        If ID = -1 Then
            'For tilesetID = 0 To Me.Items.Count - 1
            For Each aSquaredsetID As Integer In Me.Items.Keys
                anElement.AppendChild(GetElementSquaredset(aXmlDoc, aSquaredsetID))
            Next
        Else
            If Me.Items.ContainsKey(ID) Then
                anElement.AppendChild(GetElementSquaredset(aXmlDoc, ID))
            End If
        End If


        Return anElement

    End Function



    ''' <summary>
    ''' Provides in XML format (Element), the data of Squaredset.
    ''' </summary>
    ''' <param name="aXmlDoc"></param>
    ''' <param name="squaredsetID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetElementSquaredset(ByRef aXmlDoc As XmlDocument, ByVal squaredsetID As Integer) As XmlElement

        Dim anElement As XmlElement
        'Dim subElement As XmlElement
        Dim anAttribute As XmlAttribute
        'Dim txtElement As XmlText
        Dim anItemElement As XmlElement

        Dim tmpSquared As SuperTile

        Dim genData As New DataFormat


        'Dim aSquaredTiles As Squaredset = Me.squaredTilesCollections.Item(tilesetNumber)
        Dim aSquaredset As SupertilesSET = Me.Items.Item(squaredsetID)

        anElement = aXmlDoc.CreateElement("squaredTileset")

        anAttribute = aXmlDoc.CreateAttribute("id")
        anAttribute.Value = CStr(aSquaredset.ID)
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("name")
        anAttribute.Value = aSquaredset.Name
        anElement.SetAttributeNode(anAttribute)

        anAttribute = aXmlDoc.CreateAttribute("tilesetID")
        anAttribute.Value = CStr(aSquaredset.TilesetID)
        anElement.SetAttributeNode(anAttribute)


        For i As Integer = 0 To 63
            tmpSquared = aSquaredset.Data.Item(i)
            anItemElement = aXmlDoc.CreateElement("item")

            anAttribute = aXmlDoc.CreateAttribute("index")
            anAttribute.Value = CStr(i)
            anItemElement.SetAttributeNode(anAttribute)

            anAttribute = aXmlDoc.CreateAttribute("data")
            anAttribute.Value = genData.JoinDataHex(tmpSquared.GetData)
            anItemElement.SetAttributeNode(anAttribute)

            'txtElement = aXmlDoc.CreateTextNode(genData.JoinDataHex(tmpSquared.GetData))
            'anItemElement.AppendChild(txtElement)

            anElement.AppendChild(anItemElement)
        Next

        Return anElement

    End Function




    Public Sub SetFromNode(ByVal aDataNode As XmlNode)

        Dim genData As New DataFormat

        'Dim aNode As XmlNode
        'Dim anAttribute As XmlAttribute
        Dim aNodeList As XmlNodeList
        'Dim subNode As XmlNode

        'Dim _mode As TMS9918.SCREEN_MODE

        Dim tmpsprites As New SortedList

        'Dim _datasize As Integer

        'Dim i As Integer

        'Me.Clear()


        ' get project info ############################################
        'aNode = aDataNode.SelectSingleNode("ProjectInfo")
        'If aNode Is Nothing Then
        '    Me.Info = New ProjectInfo()
        'Else
        '    Me.Info.SetFromNode(aNode)
        'End If

        'aNode = aDataNode.SelectSingleNode("@name")
        'If aNode Is Nothing Then
        '    Me.Name = ""
        'Else
        '    Me.Name = aNode.InnerText
        'End If

        'aNode = aDataNode.SelectSingleNode("@version")
        'If aNode Is Nothing Then
        '    Me.Version = ""
        'Else
        '    Me.Version = aNode.InnerText
        'End If

        'aNode = aDataNode.SelectSingleNode("@group")
        'If aNode Is Nothing Then
        '    Me.Group = ""
        'Else
        '    Me.Group = aNode.InnerText
        'End If

        'aNode = aDataNode.SelectSingleNode("@author")
        'If aNode Is Nothing Then
        '    Me.Author = ""
        'Else
        '    Me.Author = aNode.InnerText
        'End If

        'aNode = aDataNode.SelectSingleNode("@startDate")
        'If aNode Is Nothing Then
        '    Me.StartDate = DateTime.Today.Ticks
        'Else
        '    Me.StartDate = CLng(aNode.InnerText)
        'End If

        'aNode = aDataNode.SelectSingleNode("@lastUpdate")
        'If aNode Is Nothing Then
        '    Me.LastUpdate = DateTime.Today.Ticks
        'Else
        '    Me.LastUpdate = CLng(aNode.InnerText)
        'End If

        'aNode = aDataNode.SelectSingleNode("description")
        'If aNode Is Nothing Then
        '    Me.Description = ""
        'Else
        '    Me.Description = aNode.InnerText
        'End If
        ' end get project info #########################################


        aNodeList = aDataNode.SelectNodes("squaredTileset")
        If Not aNodeList Is Nothing Then
            For Each anItemElement As XmlElement In aNodeList
                SetSquaredsetFromElement(anItemElement)
            Next
        End If

    End Sub




    Public Function SetSquaredsetFromElement(ByVal anElement As XmlElement) As Boolean

        Dim genData As New DataFormat

        Dim aNodeList As XmlNodeList
        Dim aNode As XmlNode
        Dim anAttribute As XmlAttribute
        'Dim tmpString As String

        Dim tmpSquaredSet As SupertilesSET

        Dim tmpName As String
        Dim tmpTilesetID As Integer

        Dim index As Integer
        Dim data() As Byte

        'Try

        '<squaredTileset name="kk">
        anAttribute = anElement.GetAttributeNode("name")
        If anAttribute Is Nothing Then
            tmpName = "noname"
        Else
            tmpName = anAttribute.InnerText
        End If


        anAttribute = anElement.GetAttributeNode("tilesetID")
        If anAttribute Is Nothing Then
            tmpTilesetID = 0
        Else
            tmpTilesetID = CInt(anAttribute.InnerText)
        End If

        anAttribute = anElement.GetAttributeNode("id")
        If anAttribute Is Nothing Then
            tmpSquaredSet = New SupertilesSET(tmpName, tmpTilesetID)
        Else
            tmpSquaredSet = New SupertilesSET(CInt(anAttribute.InnerText), tmpName, tmpTilesetID)
        End If

        '<item id="63" data="FFFFFFFF">
        aNodeList = anElement.SelectNodes("item")
        'If Not aNodeList Is Nothing Then
        If aNodeList.Count > 0 Then
            For Each anItemElement As XmlElement In aNodeList
                aNode = anItemElement.SelectSingleNode("@index")
                If aNode Is Nothing Then
                    'index = 0
                Else
                    index = CInt(aNode.InnerText)
                    aNode = anItemElement.SelectSingleNode("@data")
                    If aNode Is Nothing Then
                        data = genData.ByteSpliterHex("00000000") 'no se deberia dar el caso pero por seguridad
                    Else
                        data = genData.ByteSpliterHex(aNode.InnerText)
                    End If

                    tmpSquaredSet.SetSquaredTile(New SuperTile(index, data(0), data(1), data(2), data(3)))
                End If
            Next
        End If

        Me.Add(tmpSquaredSet)

        Return True

        'Catch ex As Exception
        '    Return False
        'End Try
    End Function



    'Public Function GetIndexFromID(ByVal ID As Integer) As Integer

    '    Return Me.squaredsetsIndex.IndexOf(ID)

    'End Function



    'Public Function GetIDFromIndex(ByVal index As Integer) As Integer

    '    Return Me.squaredsetsIndex.Item(index)

    'End Function



    Public Function GetNameList() As ArrayList

        ' genera una lista con los nombres de los tilesets
        'Dim nameList As New ArrayList

        'If Me.Count > 0 Then
        '    For i As Integer = 0 To Me.Count - 1
        '        nameList.Add(Me.squaredsets.Item(Me.squaredsetsIndex.Item(i)).Name)
        '    Next
        'End If

        'Return nameList

        Return Me.NamesList.GetNameList()

    End Function



    Public Sub ChangeName(ByVal ID As Integer, ByVal aName As String)
        Dim tmpSquareset As SupertilesSET = Me.Items.Item(ID)
        tmpSquareset.Name = Me.NamesList.UpdateName(ID, aName)
    End Sub



    Public Function GetIndexFromID(ByVal ID As Integer) As Integer
        Return Me.NamesList.GetIndexByID(ID)
    End Function



    Public Function GetIDFromIndex(ByVal index As Integer) As Integer
        'Return Me.tilesetsIndex.Item(index)
        Return Me.NamesList.GetIDbyIndex(index)
    End Function



    
End Class
