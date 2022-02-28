
Public Class MapProject

    Private Const MAXIMUM = 255 ' <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< maximum number of items


    Private MapsList As New Hashtable()
    Private NamesList As New SortedNamesList



    Public ReadOnly Property Count()
        Get
            Return MapsList.Count
        End Get
    End Property



    Public ReadOnly Property Maps() As ArrayList
        Get

            Dim _maps As New ArrayList
            For Each _map As MapMSX In Me.MapsList.Values
                _maps.Add(_map)
            Next


            Return _maps

        End Get
    End Property



    Public Sub New()

        'Me.Info = New ProjectInfo

        'add default map
        'Add(GetClearMap())
    End Sub



    'Public Sub SetDefault()
    '    Clear()
    '    Dim aMap As New MapMSX("blank", 32, 24, MapMSX.TILE_TYPE.SingleTILE, 0)
    '    AddMap(aMap)
    'End Sub



    Public Sub Clear()

        Me.MapsList.Clear()
        Me.NamesList.Clear()

    End Sub



    Public Function Contains(ByVal ID As Integer) As Boolean
        Return Me.MapsList.ContainsKey(ID)
    End Function



    Public Function Add(ByRef item As MapMSX) As Integer
        Dim ID As Integer

        If item Is Nothing Then
            Return -1
        End If

        ID = item.ID

        If Me.MapsList.Count < MAXIMUM Then

            If Me.MapsList.ContainsKey(ID) Then
                ID = item.GetHashCode + CInt(Rnd() * 100000)
                item.ID = ID
            End If

            item.Name = Me.NamesList.AddName(ID, item.Name)
            Me.MapsList.Add(ID, item)

            Return ID

        Else
            Return -1
        End If
    End Function



    Public Sub Update(ByVal ID As Integer, ByRef aMap As MapMSX)
        If Me.MapsList.ContainsKey(ID) Then
            aMap.ID = ID
            Me.MapsList.Item(ID) = aMap
            aMap.Name = Me.NamesList.UpdateName(ID, aMap.Name)
        End If
    End Sub



    Public Function GetMap(ByVal index As Integer) As MapMSX
        Dim ID As Integer = Me.NamesList.GetIDbyIndex(index)

        'If Me.MapsIndex.Count > 0 Then
        '    ID = Me.MapsIndex.Item(index)
        'End If

        Return GetMapByID(ID)
    End Function



    Public Function GetMapByID(ByVal ID As Integer) As MapMSX
        If Me.MapsList.Contains(ID) Then
            Return Me.MapsList.Item(ID)
        Else
            Return Nothing
        End If
    End Function



    Public Function GetClearMap() As MapMSX
        Return New MapMSX("blank", 32, 24, MapMSX.TILE_TYPE.SimpleTILE, 0)
    End Function



    ''' <summary>
    ''' Get a ordered screen 2 Map
    ''' </summary>
    ''' <returns></returns>
    Public Function GetOrdererMap() As MapMSX
        Dim tmpMap = New MapMSX("blank", 32, 24, MapMSX.TILE_TYPE.SimpleTILE, 0)
        tmpMap.MapType = MapMSX.MAP_TYPE.ScreenG2

        Dim tileValue As Short
        Dim numLine As Integer = 0
        Dim lineData() As Byte

        ReDim lineData(31)
        For i As Short = 0 To 2
            tileValue = 0
            For bloqLine As Short = 0 To 7
                For colum As Short = 0 To 31
                    lineData(colum) = CByte(tileValue)
                    tileValue += 1
                Next
                tmpMap.AddLine(numLine, lineData.Clone)
                numLine += 1
            Next
        Next

        Return tmpMap
    End Function



    Public Sub Delete(ByVal index As Integer)
        Dim ID As Integer

        If Me.MapsList.Count > 0 Then
            ID = Me.NamesList.GetIDbyIndex(index)
            DeleteByID(ID)
        End If

    End Sub



    Public Sub DeleteByID(ByVal ID As Integer)
        If Me.MapsList.ContainsKey(ID) Then
            Me.MapsList.Remove(ID)
            Me.NamesList.RemoveByID(ID)
        End If
    End Sub



    Public Sub AddMapFromBinary(ByVal _name As String, ByVal _mode As iVDP.SCREEN_MODE, ByVal data As Byte())

        Dim aMap As New MapMSX(_name, _mode, data)

        Add(aMap)

    End Sub




    Public Function GetScreenBloq(ByVal aMap As MapMSX, ByVal _x As Integer, ByVal _y As Integer, ByVal _width As Integer) As Byte()
        Dim data() As Byte
        Dim posx As Integer
        Dim nline As Integer
        Dim lineData() As Byte

        Dim dataPos As Integer = 0

        Dim datasize As Integer = (_width * 24) - 1
        ReDim data(datasize)

        'Dim aMap As MapMSX = GetMapByID(numMap)

        If Not aMap Is Nothing Then
            If aMap.TileType = MapMSX.TILE_TYPE.SimpleTILE Then
                For nline = _y To _y + 23
                    If nline < aMap.Height Then
                        lineData = aMap.GetLine(nline)
                        For posx = _x To _x + _width - 1
                            If posx < aMap.Width Then
                                data(dataPos) = lineData(posx)
                            Else
                                data(dataPos) = 0
                            End If
                            dataPos += 1
                        Next
                    End If
                Next

            Else
                ' 2x2 tiles
                Dim tile As Byte

                For nline = _y To _y + 11
                    If nline < aMap.Height Then
                        lineData = aMap.GetLine(nline)
                        For posx = _x To _x + (_width / 2) - 1
                            If posx < aMap.Width Then
                                tile = lineData(posx)
                                tile = (tile - (Fix(tile / 16) * 16)) * 2 + (Fix(tile / 16) * 64)
                                data(dataPos) = tile
                                data(dataPos + 1) = tile + 1
                                data(dataPos + 32) = tile + 32
                                data(dataPos + 33) = tile + 33
                            Else
                                data(dataPos) = 0
                                data(dataPos + 1) = 0
                                data(dataPos + 32) = 0
                                data(dataPos + 33) = 0
                            End If
                            dataPos += 2
                        Next
                        dataPos += _width
                    Else
                        For posx = 0 To (_width / 2) - 1
                            data(dataPos) = 0
                            data(dataPos + 1) = 0
                            data(dataPos + 32) = 0
                            data(dataPos + 33) = 0
                            dataPos += 2
                        Next
                        dataPos += _width
                    End If
                Next

            End If

        End If

        Return data
    End Function



    Public Function GetNameList() As ArrayList

        Return NamesList.GetNameList()

    End Function



    Public Sub ChangeName(ByVal ID As Integer, ByVal aName As String)
        Dim tmpMap As MapMSX = Me.MapsList.Item(ID)
        tmpMap.Name = Me.NamesList.UpdateName(ID, aName)
    End Sub



    Public Function GetIndexFromID(ByVal ID As Integer) As Integer
        'Return Me.spritesetsIndex.IndexOf(ID)
        Return Me.NamesList.GetIndexByID(ID)
    End Function



    Public Function GetIDFromIndex(ByVal index As Integer) As Integer
        'Return Me.spritesetsIndex.Item(index)
        Return Me.NamesList.GetIDbyIndex(index)
    End Function



End Class
