
''' <summary>
''' OAMset (Object Attribute Memory) set (32 layers)
''' </summary>
''' <remarks></remarks>
Public Class OAMset

    Public Const MAX_SPRITELAYERS As Integer = 32

    Public ID As Integer
    Public Name As String

    Private Const DEF_Y_MODE1 = &HD1 ' TMS9918A 
    Private Const DEF_Y_MODE2 = &HD9 ' V9938

    Private _mode As SpriteMSX.SPRITE_MODE = SpriteMSX.SPRITE_MODE.MONO

    Private _size As SpriteMSX.SPRITE_SIZE = SpriteMSX.SPRITE_SIZE.SIZE8

    Public SpriteLayers As New SortedList()

    Public DEFAULT_oamSET As String = "OAMSET_"
    Public DEFAULT_OAM_ITEM As String = "plane_"



    Public Property Mode() As SpriteMSX.SPRITE_MODE
        Get
            Return Me._mode
        End Get
        Set(ByVal value As SpriteMSX.SPRITE_MODE)
            Me._mode = value
        End Set
    End Property



    Public Sub New(ByVal _name As String, spriteSize As SpriteMSX.SPRITE_SIZE, spriteMode As SpriteMSX.SPRITE_MODE)

        If _name = "" Then
            _name = DEFAULT_oamSET + "00"
        End If

        Me.Name = _name
        Me._mode = spriteMode
        Me._size = spriteSize

        initSpritePlanes()

        Me.ID = Me.GetHashCode() + CInt(Rnd() * 100000) 'genera un identificador

    End Sub



    Public Sub New(_id As Integer, ByVal _name As String, spriteSize As SpriteMSX.SPRITE_SIZE, spriteMode As SpriteMSX.SPRITE_MODE)

        Me.ID = _id

        If _name = "" Then
            _name = DEFAULT_oamSET + "00"
        End If

        Me.Name = _name
        Me._mode = spriteMode
        Me._size = spriteSize

        initSpritePlanes()

    End Sub



    Public Sub New(ByVal _name As String, spriteSize As SpriteMSX.SPRITE_SIZE, spriteMode As SpriteMSX.SPRITE_MODE, OAMdata As Byte(), mode2Colors As Byte())

        Dim spriteOAM(3) As Byte
        Dim spriteColors(15) As Byte

        Dim Xpos As Integer
        Dim Ypos As Integer
        Dim numPattern As Integer
        Dim color As Integer


        If _name = "" Then
            _name = DEFAULT_oamSET + "00"
        End If

        Me.Name = _name
        Me._mode = spriteMode
        Me._size = spriteSize

        'initSpritePlanes()

        For numSpritePlane As Byte = 0 To MAX_SPRITELAYERS - 1
            Array.Copy(OAMdata, numSpritePlane * 4, spriteOAM, 0, 4)

            Ypos = spriteOAM(0)
            Xpos = spriteOAM(1)
            If Me._size = SpriteMSX.SPRITE_SIZE.SIZE16 Then
                numPattern = spriteOAM(2) / 4
            Else
                ' 8x8
                numPattern = spriteOAM(2)
            End If
            color = spriteOAM(3)

            If Not mode2Colors Is Nothing Then
                Array.Copy(mode2Colors, numSpritePlane * 16, spriteColors, 0, 16)
                SetSpriteOAM(numSpritePlane, New SpriteOAM(DEFAULT_OAM_ITEM + CStr(numSpritePlane).PadLeft(2, "0"c), Ypos, Xpos, numPattern, spriteColors))
            Else
                SetSpriteOAM(numSpritePlane, New SpriteOAM(DEFAULT_OAM_ITEM + CStr(numSpritePlane).PadLeft(2, "0"c), Ypos, Xpos, numPattern, color))
            End If

        Next

        Me.ID = Me.GetHashCode() + CInt(Rnd() * 100000) 'genera un identificador

    End Sub



    Public Function itsEmpty() As Boolean

        Dim dataWeight As Integer
        Dim tmptOAM As SpriteOAM
        'Dim result As Boolean = True

        For i As Integer = 0 To MAX_SPRITELAYERS - 1
            tmptOAM = SpriteLayers.Item(i)
            dataWeight += tmptOAM.Y
            dataWeight += tmptOAM.X
            dataWeight += tmptOAM.Color
            dataWeight += tmptOAM.PatternNumber
        Next

        If dataWeight = 0 Or dataWeight > 32639 Then
            Return True
        End If

        Return False

    End Function



    Private Sub initSpritePlanes()

        Dim defY As Byte

        If Me._mode = SpriteMSX.SPRITE_MODE.MONO Then
            defY = DEF_Y_MODE1
        Else
            defY = DEF_Y_MODE2
        End If

        For i As Integer = 0 To MAX_SPRITELAYERS - 1
            ' inicializa el set con planos de sprite ocultos
            Me.SpriteLayers.Add(i, New SpriteOAM(DEFAULT_OAM_ITEM + CStr(i).PadLeft(2, "0"c), defY, 0, 0, &HF))
        Next
    End Sub



    Public Sub Clear()
        Dim i As Integer = 0
        For Each item As SpriteOAM In Me.SpriteLayers.Values
            item.Name = DEFAULT_OAM_ITEM + CStr(i).PadLeft(2, "0"c)
            'If Me._mode = SpriteMSX.SPRITE_MODE.MONO Then
            item.Y = DEF_Y_MODE1
            'Else
            '    item.Y = DEF_Y_MODE2
            'End If
            item.X = 0
            item.Layer = i
            item.PatternNumber = 0
            item.ColorEC = &HF
            i += 1
        Next
    End Sub



    Public Sub SetSpriteOAM(layer As Integer, _spriteOAM As SpriteOAM)
        If layer < MAX_SPRITELAYERS Then
            _spriteOAM.Layer = layer
            Me.SpriteLayers.Item(layer) = _spriteOAM
        End If
    End Sub



    Public Function GetSpriteOAM(layer As Integer) As SpriteOAM
        If layer < MAX_SPRITELAYERS Then
            Return Me.SpriteLayers.Item(layer)
        Else
            Return Nothing
        End If
    End Function



    Public Sub CopySpritePlanes(ByVal sourceIndex As Integer, ByVal targetIndex As Integer)

        Dim tmpOAM As SpriteOAM = GetSpriteOAM(sourceIndex).Clone() 'Copy(targetIndex)

        SetSpriteOAM(targetIndex, tmpOAM)

    End Sub



    Public Sub ExchangeSpritePlanes(ByVal sourceIndex As Integer, ByVal targetIndex As Integer)

        Dim sourceSprite As SpriteOAM '= GetSprite(targetIndex).Copy(sourceIndex)
        Dim targetSprite As SpriteOAM '= GetSprite(sourceIndex).Copy(targetIndex)

        sourceSprite = GetSpriteOAM(sourceIndex).Clone
        'sourceSprite.Layer = sourceIndex

        targetSprite = GetSpriteOAM(targetIndex).Clone
        'targetSprite.Layer = targetIndex

        SetSpriteOAM(targetIndex, sourceSprite)
        SetSpriteOAM(sourceIndex, targetSprite)

    End Sub





    Public Function GetBinaryBloq() As Byte()
        Dim data(127) As Byte '32 * 4

        Dim tmpOAMspr As SpriteOAM

        Dim position As Integer


        For i As Integer = 0 To MAX_SPRITELAYERS - 1
            position = i * 4
            tmpOAMspr = Me.SpriteLayers.Item(i)
            data(position) = tmpOAMspr.Y
            data(position + 1) = tmpOAMspr.X
            If Me._size = SpriteMSX.SPRITE_SIZE.SIZE16 Then
                If tmpOAMspr.PatternNumber > 63 Then
                    tmpOAMspr.PatternNumber = 63   '<<<---------- OJO - en modo sprites de 16x16 solo hay disponibles 64 patrones
                End If
                data(position + 2) = tmpOAMspr.PatternNumber * 4 'En la VRAM el valor de patron se ha de multiplicar por 4.
            Else
                data(position + 2) = tmpOAMspr.PatternNumber
            End If
            data(position + 3) = tmpOAMspr.ColorEC
            'Array.Copy(OAMdata, data * 4, SpriteOAM, 0, 4)
        Next

        Return data

    End Function



    Public Function GetColorsBinaryBloq() As Byte()

        Dim data(511) As Byte '32 * 16

        Dim tmpOAMspr As SpriteOAM

        For i As Integer = 0 To MAX_SPRITELAYERS - 1
            tmpOAMspr = Me.SpriteLayers.Item(i)

            Array.Copy(tmpOAMspr.GetMode2ColorLines, 0, data, i * 16, 16)
        Next

        Return data

    End Function



    Public Function Clone() As OAMset

        Dim i As Integer = 0
        Dim newItem As New OAMset(Me.Name, Me._size, Me._mode)

        'For i As Integer = 0 To MAX_SPRITELAYERS - 1
        '    newItem.SpriteLayers.Item(i) = Me.SpriteLayers.Item(i).Clone()
        'Next

        For Each item As SpriteOAM In Me.SpriteLayers.Values
            newItem.SpriteLayers.Item(i) = item.Clone()
            i += 1
        Next


        Return newItem

    End Function



    Public Function Copy() As OAMset

        Dim i As Integer = 0
        Dim newItem As New OAMset(Me.ID, Me.Name, Me._size, Me._mode)

        For Each item As SpriteOAM In Me.SpriteLayers.Values
            newItem.SpriteLayers.Item(i) = item.Clone()
            i += 1
        Next

        Return newItem

    End Function


End Class
