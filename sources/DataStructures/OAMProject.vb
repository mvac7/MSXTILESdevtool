Public Class OAMProject

    Public Const MAX_OAMset As Integer = 127 ' <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< maximum number of items


    Public Items As New Hashtable()

    Private NamesList As New SortedNamesList



    Public ReadOnly Property Count()
        Get
            Return NamesList.Count
        End Get
    End Property



    Public Sub New()
        'Me.Info = New ProjectInfo
    End Sub


    Public Sub Clear()

        'Me.Info.Clear()
        Me.Items.Clear()
        Me.NamesList.Clear()

    End Sub




    Public Function Add(ByVal item As OAMset) As Integer

        Dim ID As Integer

        If item Is Nothing Then
            Return -1
        End If

        ID = item.ID

        If Me.Items.Count < MAX_OAMset Then

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



    Public Function GetOAMset(ByVal index As Integer) As OAMset
        Dim ID As Integer = Me.NamesList.GetIDbyIndex(index)
        Return GetOAMsetByID(ID)
    End Function



    Public Function GetOAMsetByID(ByVal ID As Integer) As OAMset
        If Not Me.Items.Contains(ID) Then
            ID = Me.NamesList.GetIDbyIndex(0)  ' <<< ------------------------------------------------------------- OJO medida de seguridad que se deberia de controlar desde donde se hace la llamada a esta funcion (reaaccion ante un nothing)
        End If

        Return Me.Items.Item(ID)
    End Function



    Public Sub Update(ByVal ID As Integer, ByVal _OAMset As OAMset)
        If Me.Items.ContainsKey(ID) Then
            Me.Items.Item(ID) = _OAMset
            _OAMset.Name = Me.NamesList.UpdateName(ID, _OAMset.Name)
        End If
    End Sub



    Public Sub Delete(ByVal index As Integer)
        Dim ID As Integer

        If Me.NamesList.Count > 0 Then
            ID = GetIDFromIndex(index)
            DeleteByID(ID)
        End If

    End Sub



    Public Sub DeleteByID(ByVal ID As Integer)
        If Me.Items.ContainsKey(ID) Then
            Me.Items.Remove(ID)
            Me.NamesList.RemoveByID(ID)
        End If
    End Sub



    Public Function GetIndexFromID(ByVal ID As Integer) As Integer
        Return Me.NamesList.GetIndexByID(ID)
    End Function



    Public Function GetIDFromIndex(ByVal index As Integer) As Integer
        Return Me.NamesList.GetIDbyIndex(index)
    End Function



    Public Sub ChangeName(ByVal ID As Integer, ByVal aName As String)
        Dim tmpOAMset As OAMset = Me.Items.Item(ID)
        tmpOAMset.Name = Me.NamesList.UpdateName(ID, aName)
    End Sub



    Public Function GetNameList() As ArrayList
        Return NamesList.GetNameList
    End Function


    Public Function Contains(ByVal ID As Integer) As Boolean
        Return Me.Items.Contains(ID)
    End Function


End Class
