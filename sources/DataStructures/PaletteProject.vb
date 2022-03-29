''' <summary>
''' Clase que gestiona los datos de un proyecto de Palettes. 
''' </summary>
''' <remarks></remarks>
Public Class PaletteProject


    Private Items As New Hashtable

    Private NamesList As New SortedNamesList

    Private Const MAXIMUM = 255 ' <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< maximum number of items


    Private ZeroColor As Color = Color.Navy



    Public ReadOnly Property Count()
        Get
            Return NamesList.Count
        End Get
    End Property




    Public ReadOnly Property Values() As ICollection
        Get
            Return Items.Values
        End Get
    End Property



    Public Sub New()

        'Me.Info = New ProjectInfo

        Clear()

        'Me.AddPalette(tms9918Palette)

        'SelectPalette(0)
        'defaultPalette = New PaletteV9938()

        'AddPalette(New PaletteV9938(PaletteV9938.MSXVDP.TMS9918))
    End Sub



    Public Sub Clear()

        Me.Items.Clear()
        Me.NamesList.Clear()

        'Add(New PaletteTMS9918)
        Me.Items.Add(0, New PaletteTMS9918)

    End Sub



    Public Function Add(ByVal item As iPaletteMSX) As Integer

        Dim newID As Integer = -1

        If item Is Nothing Then
            Return -1
        End If

        If Me.Items.Count < MAXIMUM Then

            If item.GetType.Name = "PaletteV9938" Then 'Type = iPaletteMSX.VDP.V9938

                newID = item.ID

                'If Me.Items.ContainsKey(newID) Then
                '    newID = item.GetHashCode + CInt(Rnd() * 100000)
                '    item.ID = newID
                'End If

                item.Name = Me.NamesList.AddName(newID, item.Name)
                item.SetZeroColor(Me.ZeroColor)

                Me.Items.Add(newID, item)
            End If

            'Else
            '    Return -1
        End If

        Return newID

    End Function



    ''' <summary>
    ''' Add a list of palettes included in a PaletteProject
    ''' </summary>
    ''' <param name="tmpPaletteProject"></param>
    ''' <returns></returns>
    Public Function AddPalettes(ByRef tmpPaletteProject) As Integer
        Dim tmpID As Integer
        Dim newID As Integer = -1

        If Not tmpPaletteProject Is Nothing Then

            For Each tmpPalette As iPaletteMSX In tmpPaletteProject.Values
                tmpID = Add(tmpPalette)
                If tmpID > 0 Then newID = tmpID
            Next

        End If

        Return newID

    End Function



    Public Function GetPalette(ByVal index As Integer) As iPaletteMSX
        'Dim ID As Integer = 0
        'If Me._palettesIndex.Count > 0 Then
        '    ID = Me._palettesIndex.Item(index)
        'End If
        Dim ID As Integer

        If index = 0 Then
            ID = 0
        Else
            ID = GetIDFromIndex(index)
        End If

        Return GetPaletteByID(ID)
    End Function



    Public Sub SetZeroColor(ByVal newColor As Color)

        Me.ZeroColor = newColor

        For Each aPalette As iPaletteMSX In Me.Items.Values
            aPalette.SetZeroColor(newColor)
        Next

    End Sub



    Public Function GetPaletteByID(ByVal ID As Integer) As iPaletteMSX
        If Me.Items.ContainsKey(ID) Then
            Return Me.Items.Item(ID)
        Else
            Return Me.Items.Item(0) 'TMS9918 palette
        End If
    End Function



    Public Sub Update(ByVal ID As Integer, ByVal _palette As iPaletteMSX)
        If _palette.GetType.Name = "PaletteV9938" Then
            If Me.Items.ContainsKey(ID) Then
                Me.Items.Item(ID) = _palette
                _palette.Name = Me.NamesList.UpdateName(ID, _palette.Name)
            End If
        End If
    End Sub



    Public Sub Delete(ByVal index As Integer)
        Dim ID As Integer

        If Me.NamesList.Count > 0 And index > 0 Then
            ID = GetIDFromIndex(index)
            DeleteByID(ID)
        End If

    End Sub



    Public Sub DeleteByID(ByVal ID As Integer)
        If Me.Items.ContainsKey(ID) And ID > 0 Then
            Me.Items.Remove(ID)
            Me.NamesList.RemoveByID(ID)
        End If
    End Sub



    Public Function Contains(ByVal ID As Integer) As Boolean
        Return Me.Items.ContainsKey(ID)
    End Function



    'Public Function GetColor(ByVal index As Integer) As Color
    '    If Me._VDPtype = TMS9918.MSXVDP.TMS9918 Then
    '        Return Me.tms9918Palette.GetColor(index)
    '    Else
    '        Return Me.selectedPalette.GetColorMSX(index).GetColor
    '    End If
    'End Function



    ''' <summary>
    ''' Get VB.net Drawing.Color object (RGB) from 3 bit RGB values (V9938 palette)
    ''' </summary>
    ''' <param name="red3"></param>
    ''' <param name="green3"></param>
    ''' <param name="blue3"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetColor(ByVal red3 As Byte, ByVal green3 As Byte, ByVal blue3 As Byte) As Color

        Dim aRed As Byte
        Dim aGreen As Byte
        Dim aBlue As Byte

        If red3 > 7 Then
            red3 = 7
        End If
        If green3 > 7 Then
            green3 = 7
        End If
        If blue3 > 7 Then
            blue3 = 7
        End If

        aRed = PaletteV9938.GetRed8(red3)
        aGreen = PaletteV9938.GetGreen8(green3)
        aBlue = PaletteV9938.GetBlue8(blue3)

        Return Color.FromArgb(aRed, aGreen, aBlue)

    End Function




    Public Function GetIndexFromID(ByVal ID As Integer) As Integer
        If ID = 0 Then
            Return 0  'TMS9918A Palette
        Else
            Return Me.NamesList.GetIndexByID(ID) + 1
        End If
    End Function



    Public Function GetIDFromIndex(ByVal index As Integer) As Integer
        If index = 0 Then
            Return 0  'TMS9918A Palette
        Else
            Return Me.NamesList.GetIDbyIndex(index - 1)
        End If
    End Function



    Public Sub ChangeName(ByVal ID As Integer, ByVal aName As String)
        If Not ID = 0 Then
            Dim tmpPalette As iPaletteMSX = Me.Items.Item(ID)
            tmpPalette.Name = Me.NamesList.UpdateName(ID, aName)
        End If
    End Sub



    Public Function GetNameList() As ArrayList
        Return NamesList.GetNameList
    End Function


End Class
