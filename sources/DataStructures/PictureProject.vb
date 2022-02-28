Public Class PictureProject


    Private Items As New Hashtable()
    Private NamesList As New SortedNamesList

    Private Const MAXIMUM = 31 ' <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< maximum number of items


    Public ReadOnly Property Count()
        Get
            Return Items.Count
        End Get
    End Property


    'Public Function GetClearTileset() As TilesetMSX
    '    Return New TilesetMSX(Me._paletteProject.GetPalette(0), "default_Tileset", iVDP.SCREEN_MODE.G2, Me.ForegroundColor, Me.BackgroundColor)
    'End Function


    Public Sub Clear()
        Me.Items.Clear()
        Me.NamesList.Clear()
    End Sub


    Public Function Add(ByRef item As PictureMSX) As Integer
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

            item.Info.Name = Me.NamesList.AddName(ID, item.Info.Name)
            Me.Items.Add(ID, item)

            Return ID
        Else
            Return -1
        End If
    End Function



    Public Sub Update(ByRef item As PictureMSX) 'ByVal ID As Integer,
        If Me.Items.ContainsKey(item.ID) Then
            Me.Items.Item(item.ID) = item
            item.Info.Name = Me.NamesList.UpdateName(item.ID, item.Info.Name)
        End If
    End Sub



    Public Function GetItemByIndex(ByVal index As Integer) As PictureMSX
        Dim ID As Integer = Me.NamesList.GetIDbyIndex(index)
        Return GetItem(ID)
    End Function



    Public Function GetItem(ByVal ID As Integer) As PictureMSX
        Return Me.Items.Item(ID)
    End Function



    Public Function Contains(ByVal ID As Integer) As Boolean
        Return Me.Items.Contains(ID)
    End Function



    Public Sub DeleteByIndex(ByVal index As Integer)
        Dim ID As Integer

        If Me.Items.Count > 0 Then
            ID = Me.NamesList.GetIDbyIndex(index)
            Delete(ID)
        End If

    End Sub



    Public Sub Delete(ByVal ID As Integer)
        If Me.Items.ContainsKey(ID) Then
            Me.Items.Remove(ID)
            Me.NamesList.RemoveByID(ID)
        End If
    End Sub


    Public Function GetNameList() As ArrayList
        Return NamesList.GetNameList()
    End Function



    Public Sub UpdateInfo(ByVal ID As Integer, ByRef Info As ProjectInfo)
        Dim tmpPicture As PictureMSX = Me.Items.Item(ID)
        tmpPicture.Info = Info
        tmpPicture.Info.Name = Me.NamesList.UpdateName(ID, tmpPicture.Info.Name)
    End Sub


    'Public Sub ChangeName(ByVal ID As Integer, ByVal aName As String)
    '    Dim tmpPicture As PictureMSX = Me.Items.Item(ID)
    '    tmpPicture.Info.Name = Me.NamesList.UpdateName(ID, aName)
    'End Sub



    Public Function GetIndexFromID(ByVal ID As Integer) As Integer
        Return Me.NamesList.GetIndexByID(ID)
    End Function



    Public Function GetIDFromIndex(ByVal index As Integer) As Integer
        Return Me.NamesList.GetIDbyIndex(index)
    End Function



    ''' <summary>
    ''' Only for G2 type Pictures
    ''' </summary>
    ''' <param name="aPicture"></param>
    ''' <param name="numBank"></param>
    ''' <returns></returns>
    Public Function GetG2PatternBank(ByRef aPicture As PictureMSX, ByVal numBank As Short) As Byte()
        Dim VRAMbloq(&H7FF) As Byte
        Dim tmpValue As GFXbyte

        Dim bankLine As Short

        Dim vaddr As Integer = 0

        For line = 0 To 7
            bankLine = ((numBank * 8) + line) * 8
            For col = 0 To 31
                For i = 0 To 7
                    tmpValue = aPicture.GetValue(col, bankLine + i)
                    VRAMbloq(vaddr) = tmpValue.Pattern
                    'VRAM(vaddr + GRPCOL) = tmpValue.Colors
                    vaddr += 1
                Next
            Next
        Next

        Return VRAMbloq
    End Function



    ''' <summary>
    ''' Only for G2 type Pictures
    ''' </summary>
    ''' <param name="aPicture"></param>
    ''' <param name="numBank"></param>
    ''' <returns></returns>
    Public Function GetG2ColorBank(ByRef aPicture As PictureMSX, ByVal numBank As Short) As Byte()
        Dim VRAMbloq(&H7FF) As Byte
        Dim tmpValue As GFXbyte

        Dim bankLine As Short

        Dim vaddr As Integer = 0

        For line = 0 To 7
            bankLine = ((numBank * 8) + line) * 8
            For col = 0 To 31
                For i = 0 To 7
                    tmpValue = aPicture.GetValue(col, bankLine + i)
                    VRAMbloq(vaddr) = tmpValue.Colors
                    vaddr += 1
                Next
            Next
        Next

        Return VRAMbloq
    End Function


End Class
