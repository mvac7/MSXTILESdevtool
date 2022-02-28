''' <summary>
''' Clase que gestiona los datos de un proyecto de Screens.
''' </summary>
''' <remarks></remarks>
Public Class ScreenProject

    Public Name As String

    Private Items As New Hashtable
    Private NamesList As New SortedNamesList

    Private Const MAXIMUM = 255 ' <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< maximum number of items





    Public ReadOnly Property Count()
        Get
            Return Me.Items.Count
        End Get
    End Property



    Public Sub New()
        'AddScreen(New ScreenItem)
    End Sub



    Public Function Contains(ByVal ID As Integer) As Boolean
        Return Me.Items.ContainsKey(ID)
    End Function




    Public Sub Clear()
        Me.Name = ""
        Me.Items.Clear()
        Me.NamesList.Clear()
    End Sub



    Public Function Add(ByVal item As ScreenMSX) As Integer

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



    Public Sub Update(ByVal ID As Integer, ByVal screen As ScreenMSX)
        'Dim ID As Integer = Me._screensIndex.Item(index)
        'Dim ID As Integer = _screen.ID
        If Me.Items.ContainsKey(ID) Then
            screen.ID = ID
            Me.Items.Item(ID) = screen
            screen.Name = Me.NamesList.UpdateName(ID, screen.Name)
        End If
    End Sub



    Public Function GetScreenByID(ByVal ID As Integer) As ScreenMSX
        If Me.Items.ContainsKey(ID) Then
            Return Me.Items.Item(ID)
        Else
            Return Nothing
        End If
    End Function



    Public Function GetScreenByIndex(ByVal index As Integer) As ScreenMSX
        Dim ID As Integer = Me.NamesList.GetIDbyIndex(index)
        'Dim output As ScreenItem

        'If index < Me.NamesList.Count Then
        '    ID = Me._screensIndex.Item(index)
        '    If Me.Items.ContainsKey(ID) Then
        '        output = Me.Items.Item(ID)
        '    End If
        'End If

        Return Me.Items.Item(ID)
    End Function



    Public Sub DeleteByID(ByVal ID As Integer)
        'Dim index As Integer
        'If Me.Items.ContainsKey(ID) Then
        '    index = Me._screensIndex.IndexOf(ID)
        '    Me.Items.Remove(ID)
        '    Me._screensIndex.Remove(ID)
        'End If
        If Me.Items.ContainsKey(ID) Then
            Me.Items.Remove(ID)
            Me.NamesList.RemoveByID(ID)
        End If
    End Sub



    Public Sub Delete(ByVal index As Integer)
        Dim ID As Integer
        If Me.NamesList.Count > 0 Then
            ID = Me.NamesList.GetIDbyIndex(index)
            DeleteByID(ID)
        End If
        'Dim ID As Integer
        'If index < Me._screensIndex.Count Then
        '    ID = Me._screensIndex.Item(index)
        '    If Me._screens.ContainsKey(ID) Then
        '        Me._screens.Remove(ID)
        '        Me._screensIndex.Remove(ID)
        '    End If
        'End If
    End Sub





    Public Function GetIndexFromID(ByVal ID As Integer) As Integer
        Return Me.NamesList.GetIndexByID(ID)
    End Function



    Public Function GetIDFromIndex(ByVal index As Integer) As Integer
        Return Me.NamesList.GetIDbyIndex(index)
    End Function



    Public Sub ChangeName(ByVal ID As Integer, ByVal aName As String)
        Dim tmpItem As ScreenMSX = Me.Items.Item(ID)
        tmpItem.Name = Me.NamesList.UpdateName(ID, aName)
    End Sub




    Public Function GetNameList() As ArrayList

        Return NamesList.GetNameList

    End Function
    
End Class
