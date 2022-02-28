Imports System.IO
Imports System.Xml


Public Class SpritesetMSX


    Public Const MAX_8xSPRITES As Integer = 255
    Public Const MAX_16xSPRITES As Integer = 63


    Public ID As Integer
    Public Name As String

    'Public PaletteID As Integer

    Private _size As SpriteMSX.SPRITE_SIZE = SpriteMSX.SPRITE_SIZE.SIZE16
    Private _mode As SpriteMSX.SPRITE_MODE = SpriteMSX.SPRITE_MODE.MONO

    Private _palette As iPaletteMSX

    Public InkColor As Byte = 15
    Public BackgroundColor As Byte = 0

    Private _sprites As New SortedList()

    Private Const def_SpriteName = "Sprite_"


    Public Shared SizeLabel() As String = {"", "8x8", "16x16"}


    Public Property Size() As SpriteMSX.SPRITE_SIZE
        Get
            Return Me._size
        End Get
        Set(ByVal value As SpriteMSX.SPRITE_SIZE)
            Me._size = value
        End Set
    End Property



    ''' <summary>
    ''' Color Mode
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Mode() As SpriteMSX.SPRITE_MODE
        Get
            Return Me._mode
        End Get
        Set(ByVal value As SpriteMSX.SPRITE_MODE)
            Me._mode = value
        End Set
    End Property



    Public ReadOnly Property TotalSprites() As Integer
        Get
            If Me._size = SpriteMSX.SPRITE_SIZE.SIZE16 Then
                Return MAX_16xSPRITES
            Else
                Return MAX_8xSPRITES
            End If
        End Get
    End Property



    Public ReadOnly Property DataSize() As Integer
        Get
            If Me._size = SpriteMSX.SPRITE_SIZE.SIZE8 Then
                Return 7
            Else
                Return 31
            End If
        End Get
    End Property



    Public Property Palette() As iPaletteMSX
        Get
            Return Me._palette
        End Get
        Set(ByVal value As iPaletteMSX)
            Me._palette = value
        End Set
    End Property




    Public Sub New(ByVal _name As String, ByVal _ProjectSize As SpriteMSX.SPRITE_SIZE, ByVal _ProjectMode As SpriteMSX.SPRITE_MODE, ByVal _inkColor As Integer, ByVal _bgColor As Integer, ByVal aPalette As iPaletteMSX)

        Me.Name = _name

        If Me.Name = "" Then
            Me.Name = "spriteset00"
        End If

        Me._size = _ProjectSize
        Me._mode = _ProjectMode

        Me.InkColor = _inkColor
        Me.BackgroundColor = _bgColor

        Me._palette = aPalette

        initSprites()


        Me.ID = Me.GetHashCode() + CInt(Rnd() * 100000) 'genera un identificador

    End Sub



    Public Sub New(ByVal _name As String, ByVal _ProjectSize As SpriteMSX.SPRITE_SIZE, ByVal _ProjectMode As SpriteMSX.SPRITE_MODE, ByVal _inkColor As Integer, ByVal _bgColor As Integer, ByVal aPalette As iPaletteMSX, ByVal patternData As Byte(), ByVal colorData As Byte())

        Me.Name = _name

        If Me.Name = "" Then
            Me.Name = "spriteset00"
        End If

        Me._size = _ProjectSize
        Me._mode = _ProjectMode

        Me.InkColor = _inkColor
        Me.BackgroundColor = _bgColor

        Me._palette = aPalette

        SetFromBloq(patternData, colorData)


        Me.ID = Me.GetHashCode() + CInt(Rnd() * 100000) 'genera un identificador

    End Sub



    ''' <summary>
    ''' Para cuando se carga desde un fichero que contiene el ID
    ''' </summary>
    ''' <param name="_id"></param>
    ''' <param name="_name"></param>
    ''' <param name="_ProjectSize"></param>
    ''' <param name="_ProjectMode"></param>
    ''' <param name="aPalette"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _id As Integer, ByVal _name As String, ByVal _ProjectSize As SpriteMSX.SPRITE_SIZE, ByVal _ProjectMode As SpriteMSX.SPRITE_MODE, ByVal aPalette As iPaletteMSX)

        Me.ID = _id

        Me.Name = _name

        If Me.Name = "" Then
            Me.Name = "spriteSET0"
        End If

        Me._size = _ProjectSize
        Me._mode = _ProjectMode

        Me._palette = aPalette

        initSprites()

    End Sub



    Public Function isModified() As Boolean

        Dim result As Boolean = False

         For Each aSprite As SpriteMSX In Me._sprites.Values
            If Not aSprite.isEmpty() Then
                result = True
                Exit For
            End If
        Next

        Return result

    End Function



    Private Sub initSprites()
        For index As Integer = 0 To Me.TotalSprites
            ' inicializa el set con sprites vacios
            Me._sprites.Add(index, New SpriteMSX(index, "", Me._size, Me._mode, Me.InkColor, Me.BackgroundColor, Me._palette))  'def_SpriteName + CStr(index)
        Next
    End Sub



    Public Function Clone() As SpritesetMSX

        Dim newSpriteset As New SpritesetMSX(Me.Name, Me.Size, Me.Mode, Me.InkColor, Me.BackgroundColor, Me._palette)

        For Each aSprite As SpriteMSX In Me._sprites.Values
            newSpriteset.SetSprite(aSprite.Clone)
        Next

        Return newSpriteset
    End Function



    Public Sub Clear()

        Me.Name = ""

        For Each aSprite As SpriteMSX In Me._sprites.Values
            aSprite.Clear()
        Next

    End Sub



    Public Sub Refresh()
        For Each aSprite As SpriteMSX In Me._sprites.Values
            aSprite.refresh()
        Next
    End Sub



    Public Sub SetDefaultColor()
        For Each aSprite As SpriteMSX In Me._sprites.Values
            aSprite.InkColor = Me.InkColor
            aSprite.BackgroundColor = Me.BackgroundColor
            If aSprite.Mode = SpriteMSX.SPRITE_MODE.COLOR Then
                aSprite.SetDefaultColors()
            End If
            aSprite.Refresh()
        Next
    End Sub




    ''' <summary>
    ''' Cambia la paleta y regenera el bitmap de los sprites
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetPalette(ByVal palette As iPaletteMSX)
        Me._palette = palette
        For Each aSprite As SpriteMSX In Me._sprites.Values
            aSprite.Palette = Me._palette
            aSprite.Refresh()
        Next
    End Sub



    Public Function GetValues() As System.Collections.ICollection
        Return Me._sprites.Values
    End Function



    Public Sub SetSprite(ByVal sprite As SpriteMSX)
        Me._sprites.Item(sprite.Index) = sprite
    End Sub



    Public Function GetSprite(ByVal index As Integer) As SpriteMSX
        Return Me._sprites.Item(index)
    End Function



    Public Sub CopySprites(ByVal sourceIndex As Integer, ByVal targetIndex As Integer)

        Dim tmpSprite As SpriteMSX = GetSprite(sourceIndex).Clone() 'Copy(targetIndex)
        tmpSprite.Index = targetIndex

        SetSprite(tmpSprite)

    End Sub



    Public Sub ExchangeSprites(ByVal sourceIndex As Integer, ByVal targetIndex As Integer)

        Dim sourceSprite As SpriteMSX '= GetSprite(targetIndex).Copy(sourceIndex)
        Dim targetSprite As SpriteMSX '= GetSprite(sourceIndex).Copy(targetIndex)

        sourceSprite = GetSprite(targetIndex).Clone
        sourceSprite.Index = sourceIndex

        targetSprite = GetSprite(sourceIndex).Clone
        targetSprite.Index = targetIndex

        SetSprite(sourceSprite)
        SetSprite(targetSprite)

    End Sub





    Private Sub SetFromBloq(ByVal patternData As Byte(), ByVal colorData As Byte())

        Dim spritePattern As Byte()
        Dim spriteColors As Byte()

        Dim numtotalSprites As Integer

        Dim patternPosition As Integer = 0
        Dim colorPosition As Integer = 0

        numtotalSprites = patternData.Length / (Me.DataSize + 1)

        ReDim spritePattern(Me.DataSize)
        ReDim spriteColors(15)


        For index As Integer = 0 To numtotalSprites - 1

            For i = 0 To Me.DataSize
                If patternPosition > patternData.Length Then
                    ' si el tamaño del bloque de datos no cuadra
                    spritePattern(i) = 0
                    patternPosition += 1
                Else
                    spritePattern(i) = patternData(patternPosition)
                    patternPosition += 1
                End If
            Next

            If Me._mode = SpriteMSX.SPRITE_MODE.COLOR Then

                If colorData Is Nothing Then
                    For i = 0 To 15
                        spriteColors(i) = Me.InkColor
                        colorPosition += 1
                    Next
                Else
                    For i = 0 To 15
                        If colorPosition > colorData.Length Then
                            ' si el tamaño del bloque de datos no cuadra
                            spriteColors(i) = Me.InkColor
                            colorPosition += 1
                        Else
                            spriteColors(i) = colorData(colorPosition)
                            colorPosition += 1
                        End If
                    Next
                End If
                SetSprite(New SpriteMSX(index, "", Me._size, Me._mode, Me.InkColor, Me.BackgroundColor, spritePattern, spriteColors, Me._palette)) 'def_SpriteName + CStr(index)
            Else
                SetSprite(New SpriteMSX(index, "", Me._size, Me._mode, Me.InkColor, Me.BackgroundColor, spritePattern, Nothing, Me._palette)) 'def_SpriteName + CStr(index)
            End If

        Next

        If numtotalSprites < (Me.TotalSprites + 1) Then
            For index = numtotalSprites To Me.TotalSprites
                ' inicializa el set con sprites vacios
                Me._sprites.Add(index, New SpriteMSX(index, "", Me._size, Me._mode, Me.InkColor, Me.BackgroundColor, Me._palette)) 'def_SpriteName + CStr(index)
            Next
        End If

    End Sub



    Public Function GetPatternData(ByVal firstSprite As Integer, ByVal toSprite As Integer) As Byte()
        Dim data() As Byte
        Dim bloqPosition As Integer = 0

        Dim bloqSize As Integer

        If toSprite < firstSprite Then
            Return Nothing
        End If

        If toSprite > Me.TotalSprites Then
            toSprite = Me.TotalSprites
        End If

        bloqSize = ((toSprite - firstSprite) + 1) * (Me.DataSize + 1)
        ReDim data(bloqSize - 1)

        For _order As Integer = firstSprite To toSprite
            For Each value As Integer In GetSprite(_order).patternData
                data(bloqPosition) = value
                bloqPosition += 1
            Next
        Next

        Return data
    End Function




    Public Function GetColorData(ByVal firstSprite As Integer, ByVal toSprite As Integer) As Byte()
        Dim data() As Byte
        Dim bloqPosition As Integer = 0

        Dim aSprite As SpriteMSX

        Dim totalSprites As Integer = (toSprite - firstSprite) + 1
        Dim bloqSize As Integer

        Dim dataLength As Integer

        If Me.Size = SpriteMSX.SPRITE_SIZE.SIZE8 Then
            dataLength = 7
        Else
            dataLength = 15
        End If



        If totalSprites < 0 Then 'toSprite < firstSprite Then
            Return Nothing
        End If

        If toSprite > Me.TotalSprites Then
            Return Nothing
        End If

        bloqSize = totalSprites * (dataLength + 1)
        ReDim data(bloqSize - 1)

        For _order As Integer = firstSprite To toSprite
            aSprite = GetSprite(_order)
            For i As Integer = 0 To dataLength
                data(bloqPosition) = aSprite.colorData(i) + getORBitToDecimalValue(aSprite.ORbitData(i))
                bloqPosition += 1
            Next
        Next

        Return data
    End Function



    Public Function GetPatternBinaryBloq() As Byte()
        Return GetPatternData(0, Me.TotalSprites)
    End Function



    Public Function GetColorBinaryBloq() As Byte()
        Return GetColorData(0, Me.TotalSprites)
    End Function



    Private Function getORBitToDecimalValue(ByVal value As Boolean) As Byte
        Dim result As Byte = 0
        If value = True Then
            result = 64
        End If
        Return result
    End Function



    Public Sub ConvertSpriteType(ByVal newSize As SpriteMSX.SPRITE_SIZE, ByVal newMode As SpriteMSX.SPRITE_MODE)

        Dim tmpSpriteset As SpritesetMSX = Me.Clone 'hago una copia para poder trabajar sobre la instancia inicial
        Dim tmpSprite As SpriteMSX

        Dim tmpSpriteName As String

        Dim nSprite As Integer = 0
        Dim nc As Byte

        Dim patternData() As Byte
        Dim colorData() As Byte

        Dim tmpInkColor As Byte
        Dim tmpBGColor As Byte

        Dim oldMode As SpriteMSX.SPRITE_MODE = Me.Mode

        If newSize = SpriteMSX.SPRITE_SIZE.SIZE8 Then
            ReDim patternData(7)
            'ReDim colorData(7)
        Else
            ReDim patternData(31)
            'ReDim colorData(15)
        End If
        ReDim colorData(15)


        If Not newSize = Me.Size Then
            ' si es diferente realiza la conversion de tamaño

            '
            Me._sprites.Clear()

            Me.Size = newSize
            Me.Mode = newMode

            initSprites()

            If newSize = SpriteMSX.SPRITE_SIZE.SIZE16 Then
                '8x8 to 16x16 - 64 patterns
                For i As Integer = 0 To 63
                    tmpSprite = tmpSpriteset.GetSprite(nSprite)
                    tmpInkColor = tmpSprite.InkColor
                    tmpBGColor = tmpSprite.BackgroundColor
                    Array.ConstrainedCopy(tmpSprite.patternData, 0, patternData, 0, 8)
                    If oldMode = SpriteMSX.SPRITE_MODE.COLOR And newMode = SpriteMSX.SPRITE_MODE.COLOR Then
                        Array.ConstrainedCopy(tmpSprite.colorData, 0, colorData, 0, 8)
                    Else
                        For nc = 0 To 15
                            colorData(nc) = tmpInkColor  'calculo del color en base a los datos de ink y BG colors <<<----------------------------------------------------------------- OJO
                        Next
                    End If
                    nSprite += 1
                    tmpSpriteName = tmpSprite.Name

                    tmpSprite = tmpSpriteset.GetSprite(nSprite)
                    Array.ConstrainedCopy(tmpSprite.patternData, 0, patternData, 8, 8)
                    If oldMode = SpriteMSX.SPRITE_MODE.COLOR And newMode = SpriteMSX.SPRITE_MODE.COLOR Then
                        Array.ConstrainedCopy(tmpSprite.ColorData, 0, colorData, 8, 8)
                    End If
                    nSprite += 1

                    tmpSprite = tmpSpriteset.GetSprite(nSprite)
                    Array.ConstrainedCopy(tmpSprite.patternData, 0, patternData, 16, 8)
                    nSprite += 1

                    tmpSprite = tmpSpriteset.GetSprite(nSprite)
                    Array.ConstrainedCopy(tmpSprite.patternData, 0, patternData, 24, 8)
                    nSprite += 1

                    Me.SetSprite(New SpriteMSX(i, tmpSpriteName, newSize, newMode, tmpInkColor, tmpBGColor, patternData, colorData, Me.Palette))
                Next
            Else
                '16x16 to 8x8 - 256 patterns
                For i As Integer = 0 To 63
                    tmpSprite = tmpSpriteset.GetSprite(i)
                    Array.ConstrainedCopy(tmpSprite.patternData, 0, patternData, 0, 8)
                    If oldMode = SpriteMSX.SPRITE_MODE.COLOR And newMode = SpriteMSX.SPRITE_MODE.COLOR Then
                        Array.ConstrainedCopy(tmpSprite.colorData, 0, colorData, 0, 8)
                    Else
                        For nc = 0 To 15
                            colorData(nc) = tmpSprite.InkColor  'calculo del color en base a los datos de ink y BG colors <<<----------------------------------------------------------------- OJO
                        Next
                    End If
                    Me.SetSprite(New SpriteMSX(nSprite, tmpSprite.Name, newSize, newMode, tmpSprite.InkColor, tmpSprite.BackgroundColor, patternData, colorData, Me.Palette))
                    nSprite += 1
                    Array.ConstrainedCopy(tmpSprite.patternData, 8, patternData, 0, 8)
                    If oldMode = SpriteMSX.SPRITE_MODE.COLOR And newMode = SpriteMSX.SPRITE_MODE.COLOR Then
                        Array.ConstrainedCopy(tmpSprite.colorData, 8, colorData, 0, 8)
                    End If
                    Me.SetSprite(New SpriteMSX(nSprite, tmpSprite.Name, newSize, newMode, tmpSprite.InkColor, tmpSprite.BackgroundColor, patternData, colorData, Me.Palette))
                    nSprite += 1
                    Array.ConstrainedCopy(tmpSprite.patternData, 16, patternData, 0, 8)
                    If oldMode = SpriteMSX.SPRITE_MODE.COLOR And newMode = SpriteMSX.SPRITE_MODE.COLOR Then
                        Array.ConstrainedCopy(tmpSprite.colorData, 0, colorData, 0, 8)
                    End If
                    Me.SetSprite(New SpriteMSX(nSprite, tmpSprite.Name, newSize, newMode, tmpSprite.InkColor, tmpSprite.BackgroundColor, patternData, colorData, Me.Palette))
                    nSprite += 1
                    Array.ConstrainedCopy(tmpSprite.patternData, 24, patternData, 0, 8)
                    If oldMode = SpriteMSX.SPRITE_MODE.COLOR And newMode = SpriteMSX.SPRITE_MODE.COLOR Then
                        Array.ConstrainedCopy(tmpSprite.colorData, 8, colorData, 0, 8)
                    End If
                    Me.SetSprite(New SpriteMSX(nSprite, tmpSprite.Name, newSize, newMode, tmpSprite.InkColor, tmpSprite.BackgroundColor, patternData, colorData, Me.Palette))
                    nSprite += 1
                Next
            End If


        ElseIf Not newMode = Me.Mode Then
            Me.Mode = newMode

            'el mismo tamaño pero diferente modo de color
            For Each tmpSprite In Me._sprites.Values
                tmpSprite.Mode = newMode
            Next

        End If


    End Sub

End Class
