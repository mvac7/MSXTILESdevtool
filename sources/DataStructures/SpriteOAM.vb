Public Class SpriteOAM

    ' http://problemkaputt.de/portar.htm
    ' OBJ Attributes (Sprite attribute):
    ' Defines 'OAM' data for up to 32 foreground sprites. Each entry consists of four bytes:
    '   0: Y-pos, Vertical position (FFh is topmost, 00h is second line, etc.)
    '   1: X-pos, Horizontal position (00h is leftmost)
    '   2: Pattern number
    '   3: Attributes. b0-3:Color, b4-6:unused, b7:EC (Early Clock)
    ' If EC is set to 1, the X-pos is subtracted by 32 (can be used to place sprites particulary offscreen to the left.

    Public Layer As Integer
    Public Name As String   'Opcional. Como etiqueta para ayudar a la identificación.

    'Private _size As SpriteMSX.SPRITE_SIZE = SpriteMSX.SPRITE_SIZE.SIZE16
    'Private _mode As SpriteMSX.SPRITE_MODE = SpriteMSX.SPRITE_MODE.MONO

    Public posY As Byte 'coordinate 208 in TMS9918 and coordinate 216 in V9938 it also hides all sprites on the lower planes.
    Public X As Byte
    Public PatternNumber As Byte

    Public Color As Byte
    Public EarlyClock As Boolean = False  'TMS9918A feature. Place the sprite 32 sprites to the left.

    Public Visible As Boolean   'Si es FALSE, al consultar la posicion Y devuelve un valor fuera del area visible de la pantalla: 217

    Public LineColors As Byte() 'Bits 0-3   color value
    Public LineIC As Boolean()  'Bit 5      IC  Ignore collisions with other sprites. (1=Ignore)
    Public LineOR As Boolean()  'Bit 6      CC  Mix color with sprite that has next higher priority.
    Public LineEC As Boolean()  'Bit 7      EC  Early clock (shift this line of the sprite 32 pixels to left)

    Private Const HIDING_posY = 217

    'Public SpriteOBJ As SpriteMSX

    Public Property Y As Byte
        Get
            If Me.Visible Then
                Return Me.posY
            Else
                Return HIDING_posY
            End If
        End Get
        Set(value As Byte)
            Me.posY = value
        End Set
    End Property


    Public Property ColorEC() As Byte
        Get
            Dim value As Byte = Me.Color
            If Me.EarlyClock = True Then
                value = value Or 128
            End If
            Return value
        End Get
        Set(ByVal value As Byte)
            If (value And 128) = 128 Then
                Me.EarlyClock = True
                Me.Color = value And 15
            Else
                Me.EarlyClock = False
                Me.Color = value And 15
            End If
        End Set
    End Property



    Public Sub New()

        Init("", HIDING_posY, 0, 0, 15, False, Nothing)

    End Sub



    Public Sub New(ByVal _name As String, ByVal Ypos As Byte, ByVal Xpos As Byte, ByVal _patternNum As Byte, ByVal _colorEC As Byte)

        Init(_name, Ypos, Xpos, _patternNum, _colorEC And 15, (_colorEC And 128) = 128, Nothing)

    End Sub




    Public Sub New(ByVal _name As String, ByVal Ypos As Byte, ByVal Xpos As Byte, ByVal _patternNum As Byte, ByVal _color As Byte, ByVal _EC As Boolean)

        Init(_name, Ypos, Xpos, _patternNum, _color, _EC, Nothing)

    End Sub



    Public Sub New(ByVal _name As String, ByVal Ypos As Byte, ByVal Xpos As Byte, ByVal _patternNum As Byte, ByVal line_Colors() As Byte)

        Init(_name, Ypos, Xpos, _patternNum, 15, False, line_Colors)

    End Sub



    Public Sub New(ByVal _name As String, ByVal Ypos As Byte, ByVal Xpos As Byte, ByVal _patternNum As Byte, ByVal _colorEC As Byte, ByVal line_Colors() As Byte)

        Init(_name, Ypos, Xpos, _patternNum, _colorEC And 15, (_colorEC And 128) = 128, line_Colors)

    End Sub



    Private Sub Init(ByVal _name As String, ByVal Ypos As Byte, ByVal Xpos As Byte, ByVal _patternNum As Byte, ByVal _color As Byte, ByVal _EC As Boolean, ByVal line_Colors() As Byte)

        Me.Name = _name
        Me.X = Xpos
        Me.posY = Ypos
        Me.PatternNumber = _patternNum
        Me.Color = _color
        Me.EarlyClock = _EC

        Me.Visible = Not (Ypos = HIDING_posY)

        ReDim LineColors(15)
        ReDim LineIC(15)
        ReDim LineOR(15)
        ReDim LineEC(15)

        If line_Colors Is Nothing Then
            SetDefaultLineColors()
        Else
            SetLineColors(line_Colors)
        End If

    End Sub



    Public Sub SetDefaultLineColors()
        FillColor(Me.Color)
        FillEC(Me.EarlyClock)
        FillOR(False)
        FillIC(False)
    End Sub



    Public Sub SetLineColors(ByVal line_Colors() As Byte)
        For i As Integer = 0 To 15
            Me.LineColors(i) = line_Colors(i) And 15
            Me.LineIC(i) = (line_Colors(i) And 32) = 32
            Me.LineOR(i) = (line_Colors(i) And 64) = 64
            Me.LineEC(i) = (line_Colors(i) And 128) = 128
        Next
    End Sub



    Private Sub FillColor(ByVal color As Byte)
        For i As Integer = 0 To 15
            Me.LineColors(i) = color
        Next
    End Sub


    Private Sub FillOR(ByVal state As Boolean)
        For i As Integer = 0 To 15
            Me.LineOR(i) = state
        Next
    End Sub


    ''' <summary>
    ''' Set Early Clock to 16 lines from V9938 Mode 2 Sprites
    ''' </summary>
    ''' <param name="state"></param>
    Private Sub FillEC(ByVal state As Boolean)
        For i As Integer = 0 To 15
            Me.LineEC(i) = state
        Next
    End Sub



    ''' <summary>
    ''' Ignore collisions with other sprites. (1=Ignore)
    ''' </summary>
    ''' <param name="state"></param>
    Private Sub FillIC(ByVal state As Boolean)
        For i As Integer = 0 To 15
            Me.LineIC(i) = state
        Next
    End Sub




    Public Function Clone() As SpriteOAM

        Dim newItem As New SpriteOAM(Me.Name, Me.posY, Me.X, Me.PatternNumber, Me.Color, Me.EarlyClock)

        newItem.Visible = Me.Visible

        ' V9938 or +
        newItem.LineColors = Me.LineColors.Clone 'Bits 0-3   color value
        newItem.LineIC = Me.LineIC.Clone         'Bit 5      IC  Ignore collisions with other sprites. (1=Ignore)
        newItem.LineOR = Me.LineOR.Clone         'Bit 6      CC  Mix color with sprite that has next higher priority.
        newItem.LineEC = Me.LineEC.Clone         'Bit 7      EC  Early clock (shift this line of the sprite 32 pixels to left)

        Return newItem

    End Function



    Public Function GetMode2ColorLines() As Byte()

        Dim data As Byte()

        data = Me.LineColors.Clone

        For i As Integer = 0 To 15

            If Me.LineIC(i) = True Then
                data(i) = data(i) Or 32
            End If

            If Me.LineOR(i) = True Then
                data(i) = data(i) Or 64
            End If

            If Me.LineEC(i) = True Then
                data(i) = data(i) Or 128
            End If

        Next

        Return data

    End Function


End Class
