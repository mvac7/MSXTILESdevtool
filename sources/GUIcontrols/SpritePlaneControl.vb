Public Class SpritePlaneControl


    Private _SpriteMode As SpriteMSX.SPRITE_MODE = SpriteMSX.SPRITE_MODE.MONO

    Public Mode As CONTROL_MODE = CONTROL_MODE.SELECTER

    Private _LASTworkmode As CONTROL_MODE = CONTROL_MODE.NONE


    Private SpriteOAMs As OAMset
    Private SpritePatterns As SpritesetMSX

    Private spritePictures As New Hashtable


    Private _spriteSelected As Integer = 0

    Private _lastSelectedTilePicture As PictureBox ' <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< cambiar a _lastSelectedSpritePicture


    Private _MouseIsDown As Boolean = False

    Private _spriteType As Integer = 0 ' se utiliza para controlar el cambio del tipo de sprite



    Public Event SelectedSpriteChanged(ByVal index As Integer)

    Public Event OAMsetChanged()



    Public Shadows Enum CONTROL_MODE As Integer
        SELECTER
        MULTISELECTER
        DRAWER
        EXCHANGER
        COPY
        NONE
    End Enum




    ''' <summary>
    ''' color mode for sprites (G3 V9938 mode)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SpriteMode() As SpriteMSX.SPRITE_MODE
        Get
            Return Me._SpriteMode
        End Get
        Set(ByVal value As SpriteMSX.SPRITE_MODE)
            Me._SpriteMode = value
        End Set
    End Property




    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub



    'Public Sub New(ByVal _sprites As SpriteProject)

    '    ' Llamada necesaria para el Diseñador de Windows Forms.
    '    InitializeComponent()

    '    ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    '    Me.Sprites = _sprites

    'End Sub



    Private Sub SpritesetControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        GenerateSpriteset16()

    End Sub



    Public Sub InitControlData(ByRef OAMsprites As OAMset, ByRef PatternSprites As SpritesetMSX)
        Me._spriteSelected = 0
        Me.SpriteOAMs = OAMsprites
        Me.SpritePatterns = PatternSprites
        RefreshControl()
    End Sub


    Public Sub SetOAMset(ByRef OAMsprites As OAMset)
        Me._spriteSelected = 0
        Me.SpriteOAMs = OAMsprites
        'setMode(CONTROL_MODE.SELECTER)
        RefreshControl()
    End Sub


    Public Sub SetSpriteset(ByRef PatternSprites As SpritesetMSX)
        Me._spriteSelected = 0
        Me.SpritePatterns = PatternSprites
        'setMode(CONTROL_MODE.SELECTER)
        RefreshControl()
    End Sub




    Public Sub Clear()

        If Not Me.SpritePatterns Is Nothing Then
            Me.SpritePatterns.Clear()
        End If

    End Sub




    Private Sub DisposePictures()
        For Each item As PictureBox In Me.spritePictures.Values
            item.Dispose()
        Next
        Me.spritePictures.Clear()
    End Sub



    ' Añade un nuevo sprite al control
    'Public Function AddSprite(ByVal aSprite As SpriteMSX) As Boolean
    '    'Dim spriteOrder As Integer

    '    If Me.Sprites.AddSprite(aSprite) Then
    '        insertSprite(aSprite)
    '        'aSprite.order = Me.sprites.IndexOf(aSprite.ID)
    '    End If

    '    'Me.SpriteListPanel.Refresh()

    '    Return True

    'End Function





    Public Sub UpdateSprite(ByVal index As Integer, ByVal spritePlane As SpriteOAM) 'ByVal aSprite As SpriteMSX)

        Dim aSprite As SpriteMSX
        Dim spritePicture As PictureBox

        aSprite = Me.SpritePatterns.GetSprite(spritePlane.PatternNumber)

        'aSprite.Refresh() ' genera el bitmap (aunque lo proporciona el control del editor, se utiliza para corregir el problema de centrado en la lista en el caso de los sprites de 8x8)

        'Me.SpritePatterns.SetSprite(aSprite)
        Me.SpriteOAMs.SetSpriteOAM(index, spritePlane)

        spritePicture = Me.spritePictures.Item(index)
        'spritePicture.BackColor = Me.SpritePatterns.Palette.GetRGBColor(aSprite.BGcolor)

        If Me._SpriteMode = SpriteMSX.SPRITE_MODE.MONO Then
            spritePicture.BackgroundImage = aSprite.GetBitmapPattern_x2(spritePlane.Color)
        Else
            spritePicture.BackgroundImage = aSprite.GetBitmapPattern_x2(spritePlane.GetMode2ColorLines)
        End If

    End Sub



    Public Sub SetWorkMode(ByVal newWorkMode As CONTROL_MODE)

        Me.Mode = newWorkMode
        'setMode(newWorkMode)

        'GenerateSpriteset()
        RefreshControl()

    End Sub



    'Private Sub setMode(ByVal newWorkMode As CONTROL_MODE)

    '    'Dim aSprite As SpriteOAM
    '    Me.Mode = newWorkMode

    '    'eliminar controles de pantalla <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
    '    'DisposePictures()
    '    If Not _lastSelectedTilePicture Is Nothing Then
    '        'aSprite = Me.SpriteOAMs.GetSpriteOAM(Me._spriteSelected) 'Me.SpritePatterns.GetSprite(Me._spriteSelected)
    '        Me._lastSelectedTilePicture.BackColor = Me.SpritePatterns.Palette.GetRGBColor(0) 'aSprite.Color)
    '    End If
    '    Me._lastSelectedTilePicture = Nothing
    '    ' <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

    'End Sub



    Public Sub GenerateControl()


        GenerateSpriteset16()


        'If Me.SpritePatterns.Size = SpriteMSX.SPRITE_SIZE.SIZE16 Then

        '    If Not Me._spriteType = (Me.SpritePatterns.Size * 2) + Me.SpritePatterns.Mode Or Me._LASTworkmode = CONTROL_MODE.NONE Or Me._LASTworkmode = CONTROL_MODE.DRAWER Then
        '        GenerateSpriteset16()
        '    Else
        '        RefreshSpriteset16()
        '    End If


        'Else
        '    If Not Me._spriteType = (Me.SpritePatterns.Size * 2) + Me.SpritePatterns.Mode Or Me._LASTworkmode = CONTROL_MODE.NONE Then
        '        GenerateSpriteset8()
        '    Else
        '        RefreshSpriteset8()
        '    End If

        'End If

        'Me._LASTtilemode = Me._tilemode
        Me._LASTworkmode = Me.Mode

        Me._spriteType = (Me.SpritePatterns.Size * 2) + Me.SpritePatterns.Mode

        'If Me._workmode = CONTROL_MODE.SELECTER Then
        '    Me._spriteSelected = 0
        '    SelectSprite(Me._spriteSelected)
        'End If

    End Sub



    Public Sub RefreshControl()

        RefreshSpriteset16()

        'If Me.SpritePatterns.Size = SpriteMSX.SPRITE_SIZE.SIZE16 Then
        '    RefreshSpriteset16()
        'Else
        '    RefreshSpriteset8()
        'End If

        If Me.Mode = CONTROL_MODE.SELECTER Then
            'Me._spriteSelected = 0
            SelectSprite(Me._spriteSelected)
        End If

    End Sub



    Private Sub GenerateSpriteset8()

        Dim spriteNumber As Integer = 0

        If Me.spritePictures.Count > 0 Then
            DisposePictures()
        End If

        Me.SuspendLayout()
        For y As Integer = 0 To 1
            For x As Integer = 0 To 15
                putSpriteItem8(x, y, spriteNumber)
                spriteNumber += 1
            Next
        Next
        Me.ResumeLayout(False)

    End Sub



    Private Sub RefreshSpriteset8()

        Dim spriteNumber As Integer = 0

        Me.SuspendLayout()
        For y As Integer = 0 To 1
            For x As Integer = 0 To 15
                refreshSpriteItem(spriteNumber)
                spriteNumber += 1
            Next
        Next
        Me.ResumeLayout(False)

    End Sub



    Private Sub GenerateSpriteset16()

        Dim planeNumber As Integer = 0

        If Me.spritePictures.Count > 0 Then
            DisposePictures()
        End If

        Me.SuspendLayout()
        For y As Integer = 0 To 1
            For x As Integer = 0 To 15
                putSpriteItem16(x, y, planeNumber)
                planeNumber += 1
            Next
        Next
        Me.ResumeLayout(False)

    End Sub



    Private Sub RefreshSpriteset16()

        Dim tileNumber As Integer = 0

        'Me.TilePictureIndex.Clear()

        Me.SuspendLayout()
        For y As Integer = 0 To 1
            For x As Integer = 0 To 15
                refreshSpriteItem(tileNumber)
                tileNumber += 1
            Next
        Next
        Me.ResumeLayout(False)

    End Sub



    Private Sub putSpriteItem8(ByVal x As Integer, ByVal y As Integer, ByVal index As Integer)
        'Try
        Dim spritePicture As New System.Windows.Forms.PictureBox

        Dim posX As Integer
        Dim posY As Integer

        Dim spritePlane As SpriteOAM = Me.SpriteOAMs.GetSpriteOAM(index)
        Dim aSprite As SpriteMSX = Me.SpritePatterns.GetSprite(spritePlane.PatternNumber)

        ' calcula posicionamiento del tile            
        posX = (x * 17)
        posY = (y * 17)

        'Me.SuspendLayout()

        'spritePicture.BackColor = System.Drawing.Color.Gray
        spritePicture.BackColor = Me.SpritePatterns.Palette.GetRGBColor(0) 'aSprite.BGcolor
        spritePicture.BackgroundImageLayout = ImageLayout.Center
        'spritePicture.BackgroundImage = aSprite.GetBitmapPattern_x2(spritePlane.Color)
        spritePicture.Location = New System.Drawing.Point(posX, posY)

        spritePicture.Name = CStr(index) 'para identificar la posicion en la lista desde los eventos

        spritePicture.Size = New System.Drawing.Size(16, 16)

        spritePicture.TabIndex = index
        spritePicture.TabStop = False

        Me.Controls.Add(spritePicture)

        Me.ToolTip1.SetToolTip(spritePicture, index)

        AddHandler spritePicture.MouseDown, AddressOf Me.Sprite_MouseDown
        If Me.Mode = CONTROL_MODE.EXCHANGER Or Me.Mode = CONTROL_MODE.COPY Then
            spritePicture.AllowDrop = True
            AddHandler spritePicture.MouseDoubleClick, AddressOf Me.Spriteplane_MouseDoubleClick
            AddHandler spritePicture.MouseMove, AddressOf Me.Sprite_MouseMove
            AddHandler spritePicture.DragEnter, AddressOf Me.Sprite_DragEnter
            AddHandler spritePicture.DragDrop, AddressOf Me.Sprite_DragDrop
            'Else 'If Me.Mode = TilesetMapSTATE.SELECTER Then
            '    AddHandler spritePicture.MouseDown, AddressOf Me.Sprite_MouseDown
        End If

        'Me.ResumeLayout(False)

        'Me._tilePosValues(_id) = _id
        Me.spritePictures.Add(index, spritePicture)

        'Catch ex As Exception

        'End Try

    End Sub



    Private Sub putSpriteItem16(ByVal x As Integer, ByVal y As Integer, ByVal index As Integer)
        'Try
        Dim spritePicture As New System.Windows.Forms.PictureBox

        Dim posX As Integer
        Dim posY As Integer

        'Dim spritePlane As SpriteOAM = Me.SpriteOAMs.GetSpriteOAM(index)
        'Dim aSprite As SpriteMSX = Me.SpritePatterns.GetSprite(spritePlane.PatternNumber)

        ' calcula posicionamiento del tile
        posX = (x * 33)
        posY = (y * 33)

        'CType(tilePicture, System.ComponentModel.ISupportInitialize).BeginInit()
        'Me.SuspendLayout()

        spritePicture.BackColor = System.Drawing.Color.Gray
        'spritePicture.BackColor = Me.SpritePatterns.Palette.GetRGBColor(0) 'aSprite.BGcolor
        spritePicture.BackgroundImageLayout = ImageLayout.Center
        'spritePicture.BackgroundImage = aSprite.GetBitmapPattern(spritePlane.Color)
        spritePicture.Location = New System.Drawing.Point(posX, posY)

        spritePicture.Size = New System.Drawing.Size(32, 32)

        spritePicture.Name = CStr(index) 'para identificar la posicion, desde los eventos

        spritePicture.TabIndex = index
        spritePicture.TabStop = False

        Me.Controls.Add(spritePicture)

        Me.ToolTip1.SetToolTip(spritePicture, index)

        AddHandler spritePicture.MouseDown, AddressOf Me.Sprite_MouseDown

        If Me.Mode = CONTROL_MODE.EXCHANGER Or Me.Mode = CONTROL_MODE.COPY Then
            spritePicture.AllowDrop = True
            AddHandler spritePicture.MouseDoubleClick, AddressOf Me.Spriteplane_MouseDoubleClick
            AddHandler spritePicture.MouseMove, AddressOf Me.Sprite_MouseMove
            AddHandler spritePicture.DragEnter, AddressOf Me.Sprite_DragEnter
            AddHandler spritePicture.DragDrop, AddressOf Me.Sprite_DragDrop
            'Else 'If Me.Mode = TilesetMapSTATE.SELECTER Then
            '    AddHandler spritePicture.MouseDown, AddressOf Me.Sprite_MouseDown
        End If


        'CType(tilePicture, System.ComponentModel.ISupportInitialize).EndInit()
        'Me.ResumeLayout(False)

        'Me._tilePosValues(_id) = _id
        Me.spritePictures.Add(index, spritePicture)

        'Catch ex As Exception

        'End Try

    End Sub



    Private Sub refreshSpriteItem(ByVal index As Integer)

        Dim spritePicture As PictureBox = Me.spritePictures.Item(index)
        Dim spritePlane As SpriteOAM = Me.SpriteOAMs.GetSpriteOAM(index)
        Dim aSprite As SpriteMSX = Me.SpritePatterns.GetSprite(spritePlane.PatternNumber)

        spritePicture.BackColor = Me.SpritePatterns.Palette.GetRGBColor(0) 'aSprite.BGcolor

        If Me._SpriteMode = SpriteMSX.SPRITE_MODE.MONO Then
            spritePicture.BackgroundImage = aSprite.GetBitmapPattern_x2(spritePlane.Color)
        Else
            spritePicture.BackgroundImage = aSprite.GetBitmapPattern_x2(spritePlane.GetMode2ColorLines)
        End If


        If Me.Mode = CONTROL_MODE.EXCHANGER Or Me.Mode = CONTROL_MODE.COPY Then
            spritePicture.AllowDrop = True
            'AddHandler tilePicture.MouseDown, AddressOf Me.Tile_MouseDown
            AddHandler spritePicture.MouseDoubleClick, AddressOf Me.Spriteplane_MouseDoubleClick
            AddHandler spritePicture.MouseMove, AddressOf Me.Sprite_MouseMove
            AddHandler spritePicture.DragEnter, AddressOf Me.Sprite_DragEnter
            AddHandler spritePicture.DragDrop, AddressOf Me.Sprite_DragDrop
        Else 'If Me.Mode = TilesetMapSTATE.SELECTER Then
            spritePicture.AllowDrop = False
            'AddHandler tilePicture.MouseDown, AddressOf Me.Tile_MouseDown
            RemoveHandler spritePicture.MouseDoubleClick, AddressOf Me.Spriteplane_MouseDoubleClick
            RemoveHandler spritePicture.MouseMove, AddressOf Me.Sprite_MouseMove
            RemoveHandler spritePicture.DragEnter, AddressOf Me.Sprite_DragEnter
            RemoveHandler spritePicture.DragDrop, AddressOf Me.Sprite_DragDrop
        End If

    End Sub



    Public Sub SelectSprite(ByVal index As Integer)

        'Dim aSprite As SpriteMSX
        Dim spritePicture As PictureBox

        If Not _lastSelectedTilePicture Is Nothing Then
            'Me._lastSelectedTilePicture.BackColor = Color.Gray
            'aSprite = Me.SpritePatterns.GetSprite(Me._spriteSelected)
            Me._lastSelectedTilePicture.BackColor = Me.SpritePatterns.Palette.GetRGBColor(0) 'aSprite.BGcolor)
        End If

        Me._spriteSelected = index
        spritePicture = Me.spritePictures.Item(Me._spriteSelected)
        spritePicture.BackColor = Color.Lime
        spritePicture.BringToFront()
        Me._lastSelectedTilePicture = spritePicture

        RaiseEvent SelectedSpriteChanged(index)
    End Sub



    Public Sub CopySprites(ByVal sourceIndex As Integer, ByVal targetIndex As Integer)

        Dim spritePicture1 As PictureBox = Me.spritePictures.Item(sourceIndex)
        Dim spritePicture2 As PictureBox = Me.spritePictures.Item(targetIndex)
        spritePicture2.BackgroundImage = spritePicture1.BackgroundImage.Clone

        Me.SpriteOAMs.CopySpritePlanes(sourceIndex, targetIndex)

        RaiseEvent OAMsetChanged()

    End Sub



    Private Sub ExchangeSprites(ByVal sourceIndex As Integer, ByVal targetIndex As Integer)

        Dim spritePicture1 As PictureBox = Me.spritePictures.Item(sourceIndex)
        Dim spritePicture2 As PictureBox = Me.spritePictures.Item(targetIndex)

        Dim tmpImage As System.Drawing.Image = spritePicture2.BackgroundImage

        spritePicture2.BackgroundImage = spritePicture1.BackgroundImage.Clone
        spritePicture1.BackgroundImage = tmpImage

        Me.SpriteOAMs.ExchangeSpritePlanes(sourceIndex, targetIndex)

        RaiseEvent OAMsetChanged()

    End Sub



    Private Sub Sprite_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim spritePicture As PictureBox = sender
        'If Not _tile.Image Is Nothing Then
        ' Set a flag to show that the mouse is down.

        Select Case Me.Mode
            'Case CONTROL_MODE.DRAWER
            '    DrawTile(tilePicture.TabIndex, Me._tile2draw)

            Case CONTROL_MODE.EXCHANGER
                Me._MouseIsDown = True

            Case CONTROL_MODE.COPY
                Me._MouseIsDown = True

            Case Else 'TilesetMapSTATE.SELECTER

                SelectSprite(spritePicture.TabIndex)

                'If e.Button = Windows.Forms.MouseButtons.Left Then
                '    SelectTile(tilePicture.TabIndex)
                'ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
                '    SelectSecondTile(tilePicture.TabIndex)
                'End If

        End Select

        'End If
    End Sub



    'Private Sub Spriteplane_DoubleClick(sender As Object, e As EventArgs)

    'End Sub

    Private Sub Spriteplane_MouseDoubleClick(sender As Object, e As MouseEventArgs) ' Handles planePattern_PictureBox.MouseDoubleClick
        Dim spritePicture As PictureBox = sender
        SelectSprite(spritePicture.TabIndex)
    End Sub



    Private Sub Sprite_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim spritePicture As PictureBox = sender
        If _MouseIsDown Then
            ' Initiate dragging and allow either copy or move.
            spritePicture.DoDragDrop(spritePicture.Name, DragDropEffects.Move)
        End If
        '_MouseIsDown = False
    End Sub



    Private Sub Sprite_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)
        'e.Effect = DragDropEffects.Move
        If e.Data.GetDataPresent(DataFormats.Text) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub



    Private Sub Sprite_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)
        Dim spritePicture As PictureBox = sender
        '_tile.Image = e.Data.GetData(DataFormats.Bitmap)
        If _MouseIsDown Then
            If Me.Mode = CONTROL_MODE.COPY Then
                CopySprites(CInt(e.Data.GetData(DataFormats.Text)), CInt(spritePicture.Name))
            ElseIf Me.Mode = CONTROL_MODE.EXCHANGER Then
                ExchangeSprites(CInt(e.Data.GetData(DataFormats.Text)), CInt(spritePicture.Name))
            End If

            _MouseIsDown = False
        End If

    End Sub





    ''' <summary>
    ''' Actualiza las imagenes de los sprites, con los colores de una nueva paleta.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RefreshPalette()

        Dim spritePicture As PictureBox

        Dim spritePlane As SpriteOAM
        Dim aSprite As SpriteMSX

        'Me._palette = _MSXpalette
        For index As Integer = 0 To 31
            spritePlane = Me.SpriteOAMs.GetSpriteOAM(index)
            aSprite = Me.SpritePatterns.GetSprite(spritePlane.PatternNumber)

            'aSprite.Palette = Me.Sprites.Palette
            'aSprite.refresh()
            spritePicture = Me.spritePictures.Item(index)

            'spritePicture.BackColor = Me.SpritePatterns.Palette.GetRGBColor(aSprite.BGcolor)
            'spritePicture.BackgroundImage = aSprite.GetBitmapPattern_x2(spritePlane.Color)

            If Me._SpriteMode = SpriteMSX.SPRITE_MODE.MONO Then
                spritePicture.BackgroundImage = aSprite.GetBitmapPattern_x2(spritePlane.Color)
            Else
                spritePicture.BackgroundImage = aSprite.GetBitmapPattern_x2(spritePlane.GetMode2ColorLines)
            End If

        Next

        'Me.SpriteListPanel.Refresh()

    End Sub


End Class
