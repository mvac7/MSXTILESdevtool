Public Class CommonFunctions


    ''' <summary>
    ''' This function provides a name with a number by repetition.
    ''' </summary>
    ''' <param name="oldName"></param>
    ''' <param name="nameList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetNameWithNumberByRepetition(ByVal oldName As String, ByVal nameList As ArrayList) As String
        Dim newName As String

        Dim indexList As New SortedList


        Dim posNum As Integer

        'Dim textValue As String
        Dim searchValue As String = ""
        Dim indexValue As String = "0"

        Dim newIndex As Integer = 0

        If oldName.EndsWith(")") Then
            posNum = oldName.LastIndexOf("(")
            If posNum > 0 Then
                searchValue = oldName.Substring(0, posNum)
                'indexValue = oldName.Substring(posNum + 1, (oldName.Length - posNum) - 2)
            End If
        Else
            searchValue = oldName
        End If

        'repet = CInt(indexValue)

        ' buscar searchValue y crear una lista indexada ordenada
        ' determinar el ultimo valor o un valor intermedio vacio
        'For i As Integer = 0 To nameList.Count

        'Next
        For Each tmpName As String In nameList
            If tmpName.IndexOf(searchValue) = 0 Then
                'If tmpName.EndsWith(")") Then

                'Else

                'End If
                posNum = tmpName.LastIndexOf("(")
                If posNum > 0 Then
                    'searchValue = oldName.Substring(0, posNum)
                    indexValue = tmpName.Substring(posNum + 1, (tmpName.Length - posNum) - 2)
                    indexList.Add(CInt(indexValue), searchValue)
                Else
                    If Not indexList.ContainsKey(0) Then
                        indexList.Add(0, searchValue)
                    End If
                End If
                ' guardar los indices en una lista para buscar items borrados (huecos) o el ultimo valor de la lista

                'repet += 1
            End If
        Next

        newIndex = indexList.Count
        For i As Integer = 0 To indexList.Count - 1
            If Not indexList.GetKey(i) = i Then
                newIndex = i
                Exit For
            End If
        Next
        'For Each index As Integer In indexList.GetKeyList

        'Next




        ' añadir al final de searchValue -> "(n)"
        If newIndex > 0 Then
            newName = searchValue + "(" + CStr(newIndex) + ")"
        Else
            newName = searchValue
        End If


        Return newName

    End Function


End Class
