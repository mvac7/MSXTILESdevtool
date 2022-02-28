Imports System.Xml


'Note: (18/10/2017) i'm listening a Thom Yorke's music (Radio Head) while write this code :) https://youtu.be/1KppTrxiaOI
Public Class ProjectInfo

    Public Name As String
    Public Version As String
    Public Group As String
    Public Author As String
    Public Description As String
    Public StartDate As Long
    Public LastUpdate As Long



    Public Sub New()
        Clear()
    End Sub



    Public ReadOnly Property Name_without_Spaces() As String
        Get
            Return Replace(Me.Name, " ", "_")
        End Get
    End Property




    Public Sub Clear()
        Me.Name = "New Project"
        Me.Version = "0"
        Me.Group = ""
        Me.Author = ""
        Me.Description = ""
        Me.StartDate = DateTime.Today.Ticks
        Me.LastUpdate = Me.StartDate
    End Sub



    Public Function Clone() As ProjectInfo
        Dim newProjectInfo As New ProjectInfo

        newProjectInfo.Name = Me.Name
        newProjectInfo.Version = Me.Version
        newProjectInfo.Group = Me.Group
        newProjectInfo.Author = Me.Author
        newProjectInfo.Description = Me.Description
        newProjectInfo.StartDate = Me.StartDate
        newProjectInfo.LastUpdate = Me.LastUpdate

        Return newProjectInfo
    End Function



    'Public Function GetElement(ByRef aXmlDoc As XmlDocument) As XmlElement

    '    Dim anElement As XmlElement
    '    Dim anItemElement As XmlElement
    '    Dim anAttribute As XmlAttribute
    '    Dim txtElement As XmlText


    '    ' project data ##############################################
    '    anElement = aXmlDoc.CreateElement("ProjectInfo")

    '    anAttribute = aXmlDoc.CreateAttribute("name")
    '    anAttribute.Value = Me.Name
    '    anElement.SetAttributeNode(anAttribute)

    '    anAttribute = aXmlDoc.CreateAttribute("group")
    '    anAttribute.Value = Me.Group
    '    anElement.SetAttributeNode(anAttribute)

    '    anAttribute = aXmlDoc.CreateAttribute("version")
    '    anAttribute.Value = Me.Version
    '    anElement.SetAttributeNode(anAttribute)

    '    anAttribute = aXmlDoc.CreateAttribute("author")
    '    anAttribute.Value = Me.Author
    '    anElement.SetAttributeNode(anAttribute)

    '    anAttribute = aXmlDoc.CreateAttribute("startDate")
    '    anAttribute.Value = CStr(Me.StartDate)
    '    anElement.SetAttributeNode(anAttribute)

    '    Me.LastUpdate = DateTime.Today.Ticks
    '    anAttribute = aXmlDoc.CreateAttribute("lastUpdate")
    '    anAttribute.Value = CStr(Me.LastUpdate)
    '    anElement.SetAttributeNode(anAttribute)

    '    anItemElement = aXmlDoc.CreateElement("description")
    '    txtElement = aXmlDoc.CreateTextNode(Me.Description)
    '    anItemElement.AppendChild(txtElement)
    '    anElement.AppendChild(anItemElement)
    '    'END project data ##############################################

    '    Return anElement

    'End Function



    ' <ProjectInfo>
    'Public Sub SetFromNode(ByVal aDataNode As XmlNode)

    '    Dim aNode As XmlNode
    '    'Dim anAttribute As XmlAttribute

    '    ' get project info ############################################
    '    aNode = aDataNode.SelectSingleNode("@name")
    '    If aNode Is Nothing Then
    '        Me.Name = ""
    '    Else
    '        Me.Name = aNode.InnerText
    '    End If

    '    aNode = aDataNode.SelectSingleNode("@version")
    '    If aNode Is Nothing Then
    '        Me.Version = ""
    '    Else
    '        Me.Version = aNode.InnerText
    '    End If

    '    aNode = aDataNode.SelectSingleNode("@group")
    '    If aNode Is Nothing Then
    '        Me.Group = ""
    '    Else
    '        Me.Group = aNode.InnerText
    '    End If

    '    aNode = aDataNode.SelectSingleNode("@author")
    '    If aNode Is Nothing Then
    '        Me.Author = ""
    '    Else
    '        Me.Author = aNode.InnerText
    '    End If

    '    aNode = aDataNode.SelectSingleNode("@startDate")
    '    If aNode Is Nothing Then
    '        Me.StartDate = DateTime.Today.Ticks
    '    Else
    '        Me.StartDate = CLng(aNode.InnerText)
    '    End If

    '    aNode = aDataNode.SelectSingleNode("@lastUpdate")
    '    If aNode Is Nothing Then
    '        Me.LastUpdate = DateTime.Today.Ticks
    '    Else
    '        Me.LastUpdate = CLng(aNode.InnerText)
    '    End If

    '    aNode = aDataNode.SelectSingleNode("description")
    '    If aNode Is Nothing Then
    '        Me.Description = ""
    '    Else
    '        Me.Description = aNode.InnerText
    '    End If

    'End Sub


End Class
