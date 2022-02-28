''' <summary>
''' Lista ordenada de nombres
''' </summary>
''' <remarks></remarks>
Public Class SortedNamesList


    Private itemsSortedIndex As New SortedList

    Public Function Count() As Integer
        Return itemsSortedIndex.Count
    End Function


    Public Sub Clear()
        itemsSortedIndex.Clear()
    End Sub

    Public Function AddName(ByVal ID As Integer, ByVal name As String) As String
        If Not name = "" Then
            name = name.Trim
            If itemsSortedIndex.ContainsKey(name) Then
                ' El nombre esta repetido! 
                name = AddName(ID, name + "B") ' <<---------------------------------------- Numerar?
            Else
                itemsSortedIndex.Add(name, ID)
            End If
        End If
        Return name
    End Function

    Public Function UpdateName(ByVal ID As Integer, ByVal name As String) As String
        RemoveByID(ID)
        Return AddName(ID, name)
    End Function


    Public Function GetIndexByID(ByVal ID As Integer) As Integer
        Dim index As Integer = itemsSortedIndex.IndexOfValue(ID)
        Return index
    End Function


    Public Function GetIDbyIndex(ByVal index As Integer) As Integer
        Return itemsSortedIndex.GetByIndex(index)
    End Function

    Public Function GetNameByIndex(ByVal index As Integer) As String
        Return itemsSortedIndex.GetKey(index)
    End Function

    Public Function GetNameByID(ByVal ID As Integer) As String
        Dim index As Integer = GetIndexByID(ID)
        Return GetNameByIndex(index)
    End Function

    Public Sub Remove(ByVal index As Integer)
        Me.itemsSortedIndex.RemoveAt(index)
    End Sub

    Public Sub RemoveByID(ByVal ID As Integer)
        Dim index As Integer = GetIndexByID(ID)
        Me.itemsSortedIndex.RemoveAt(index)
    End Sub


    Public Function GetNameList() As ArrayList
        Return New ArrayList(itemsSortedIndex.GetKeyList)
    End Function


End Class
