Public Class SpritesetControl


    Private _workmode As CONTROL_MODE = CONTROL_MODE.SELECTER

    Private _LASTworkmode As CONTROL_MODE = CONTROL_MODE.NONE


    Private Sprites As SpritesetMSX

    Private spritePictures As New Hashtable


    Private _spriteSelected As Integer = 0

    Private _lastSelectedTilePicture As PictureBox ' <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< cambiar a _lastSelectedSpritePicture


    'Private _MouseIsDown As Boolean = False

    Private _spriteType As Integer = 0 ' se utiliza para controlar el cambio del tipo de sprite

    Public Event SelectedSpriteChanged(ByVal index As Integer, ByVal sprite As SpriteMSX)



    Public Shadows Enum CONTROL_MODE As Integer
        SELECTER
        MULTISELECTER
        DRAWER
        EXCHANGER
        COPY
        NONE
    End Enum



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

    End Sub




    ' SetSpriteProject <------------------------------------- OJO (cambiar nombre?)
    Public Sub SetSpriteset(ByVal _sprites As SpritesetMSX)
        Me._spriteSelected = 0
        Me.Sprites = _sprites
        setMode(CONTROL_MODE.SELECTER)
        GenerateSpriteset()
    End Sub




    Public Sub Clear()

        If Not Me.Sprites Is Nothing Then
            Me.Sprites.Clear()
        End If

    End Sub




    'Public Function BLOAD(ByVal filePath As String) As Boolean
    '    Dim result As Boolean
    '    result = Me.sprites.BLOAD(filePath)
    '    'GenerateListOfItems()
    '    GenerateSpriteset()

    '    Return result
    'End Function



    'Public Sub BSAVE(ByVal filePath As String)
    '    Me.sprites.BSAVE(filePath)
    'End Sub





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



    ''' <summary>
    ''' Actualiza un sprite ya existente
    ''' </summary>
    ''' <param name="aSprite"></param>
    ''' <remarks></remarks>
    Public Sub UpdateSprite(ByVal aSprite As SpriteMSX)
        Dim spritePicture As PictureBox

        aSprite.Refresh() ' genera el bitmap (aunque lo proporciona el control del editor, se utiliza para corregir el problema de centrado en la lista en el caso de los sprites de 8x8)

        Me.Sprites.SetSprite(aSprite)

        spritePicture = Me.spritePictures.Item(aSprite.Index)
        'spritePicture.BackColor = Sprites.Palette.GetRGBColor(aSprite.BGcolor)
        spritePicture.BackgroundImage = aSprite.GetBitmapX2()

        spritePicture.BackColor = Color.Gainsboro

    End Sub




    Public Sub SetWorkMode(ByVal newWorkMode As CONTROL_MODE)

        setMode(newWorkMode)

        'GenerateSpriteset()
        RefreshSpriteset()

    End Sub



    Private Sub setMode(ByVal newWorkMode As CONTROL_MODE)

        Dim aSprite As SpriteMSX
        Me._workmode = newWorkMode

        'eliminar controles de pantalla <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        'DisposePictures()
        If Not _lastSelectedTilePicture Is Nothing Then
            'Me._lastSelectedTilePicture.BackColor = Color.Gray
            aSprite = Me.Sprites.GetSprite(Me._spriteSelected)
            Me._lastSelectedTilePicture.BackColor = Sprites.Palette.GetRGBColor(aSprite.BackgroundColor)
        End If
        Me._lastSelectedTilePicture = Nothing
        ' <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

    End Sub


    Public Sub GenerateSpriteset()

        If Me.Sprites.Size = SpriteMSX.SPRITE_SIZE.SIZE16 Then

            If Not Me._spriteType = (Me.Sprites.Size * 2) + Me.Sprites.Mode Or Me._LASTworkmode = CONTROL_MODE.NONE Or Me._LASTworkmode = CONTROL_MODE.DRAWER Then
                GenerateSpriteset16()
            Else
                RefreshSpriteset16()
            End If

           
        Else
            If Not Me._spriteType = (Me.Sprites.Size * 2) + Me.Sprites.Mode Or Me._LASTworkmode = CONTROL_MODE.NONE Then
                GenerateSpriteset8()
            Else
                RefreshSpriteset8()
            End If

        End If

        'Me._LASTtilemode = Me._tilemode
        Me._LASTworkmode = Me._workmode

        Me._spriteType = (Me.Sprites.Size * 2) + Me.Sprites.Mode

        'If Me._workmode = CONTROL_MODE.SELECTER Then
        '    Me._spriteSelected = 0
        '    SelectSprite(Me._spriteSelected)
        'End If

    End Sub



    Public Sub RefreshSpriteset()

        If Me.Sprites.Size = SpriteMSX.SPRITE_SIZE.SIZE16 Then

            RefreshSpriteset16()

        Else

            RefreshSpriteset8()

        End If

        If Me._workmode = CONTROL_MODE.SELECTER Then
            'Me._spriteSelected = 0
            SelectSprite(0)
        End If

    End Sub



    Private Sub GenerateSpriteset8()

        Dim spriteNumber As Integer = 0

        If Me.spritePictures.Count > 0 Then
            DisposePictures()
        End If

        Me.SuspendLayout()
        For y As Integer = 0 To 7
            For x As Integer = 0 To 31
                putSpriteItem8(x, y, spriteNumber)
                spriteNumber += 1
            Next
        Next
        Me.ResumeLayout(False)

    End Sub



    Private Sub RefreshSpriteset8()

        Dim spriteNumber As Integer = 0

        'If Me.spritePictures.Count > 0 Then
        '    DisposePictures()
        'End If

        Me.SuspendLayout()
        For y As Integer = 0 To 7
            For x As Integer = 0 To 31
                refreshSpriteItem(spriteNumber)
                spriteNumber += 1
            Next
        Next
        Me.ResumeLayout(False)

    End Sub



    Private Sub GenerateSpriteset16()

        Dim spriteNumber As Integer = 0

        If Me.spritePictures.Count > 0 Then
            DisposePictures()
        End If

        Me.SuspendLayout()
        For y As Integer = 0 To 3
            For x As Integer = 0 To 15
                putSpriteItem16(x, y, spriteNumber)
                spriteNumber += 1
            Next
        Next
        Me.ResumeLayout(False)

    End Sub



    Private Sub RefreshSpriteset16()

        Dim tileNumber As Integer = 0

        'Me.TilePictureIndex.Clear()

        Me.SuspendLayout()
        For y As Integer = 0 To 3
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

        Dim aSprite As SpriteMSX = Me.Sprites.GetSprite(index)

        ' calcula posicionamiento del tile            
        posX = (x * 17)
        posY = (y * 17)

        'Me.SuspendLayout()

        'spritePicture.BackColor = System.Drawing.Color.Gray
        spritePicture.BackColor = Sprites.Palette.GetRGBColor(aSprite.BackgroundColor)
        spritePicture.BackgroundImageLayout = ImageLayout.Center
        spritePicture.BackgroundImage = aSprite.GetBitmapX2()
        spritePicture.Location = New System.Drawing.Point(posX, posY)

        spritePicture.Name = CStr(index) 'para identificar la posicion en la lista desde los eventos

        spritePicture.Size = New System.Drawing.Size(16, 16)

        spritePicture.TabIndex = index
        spritePicture.TabStop = False

        Me.Controls.Add(spritePicture)

        Me.ToolTip1.SetToolTip(spritePicture, index)

        spritePicture.AllowDrop = True

        If Me._workmode = CONTROL_MODE.EXCHANGER Or Me._workmode = CONTROL_MODE.COPY Then

            'AddHandler spritePicture.MouseDown, AddressOf Me.Sprite_MouseDown
            AddHandler spritePicture.MouseMove, AddressOf Me.Sprite_MouseMove

            'Else 'If Me.Mode = TilesetMapSTATE.SELECTER Then

        End If

        'AddHandler spritePicture.MouseDown, AddressOf Me.Sprite_MouseDown
        AddHandler spritePicture.MouseUp, AddressOf Me.Sprite_MouseUp
        AddHandler spritePicture.DragEnter, AddressOf Me.Sprite_DragEnter
        AddHandler spritePicture.DragDrop, AddressOf Me.Sprite_DragDrop

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

        Dim aSprite As SpriteMSX = Me.Sprites.GetSprite(index)

        ' calcula posicionamiento del tile
        posX = (x * 34)
        posY = (y * 34)

        'CType(tilePicture, System.ComponentModel.ISupportInitialize).BeginInit()
        'Me.SuspendLayout()

        'spritePicture.BackColor = System.Drawing.Color.Gray
        spritePicture.BackColor = Sprites.Palette.GetRGBColor(aSprite.BackgroundColor)
        spritePicture.BackgroundImageLayout = ImageLayout.Center
        spritePicture.BackgroundImage = aSprite.GetBitmapX2()
        spritePicture.Location = New System.Drawing.Point(posX, posY)

        spritePicture.Size = New System.Drawing.Size(32, 32)

        spritePicture.Name = CStr(index) 'para identificar la posicion, desde los eventos

        spritePicture.TabIndex = index
        spritePicture.TabStop = False

        Me.Controls.Add(spritePicture)

        Me.ToolTip1.SetToolTip(spritePicture, index)

        spritePicture.AllowDrop = True

        If Me._workmode = CONTROL_MODE.EXCHANGER Or Me._workmode = CONTROL_MODE.COPY Then

            'AddHandler spritePicture.MouseDown, AddressOf Me.Sprite_MouseDown
            AddHandler spritePicture.MouseMove, AddressOf Me.Sprite_MouseMove
            'AddHandler spritePicture.DragEnter, AddressOf Me.Sprite_DragEnter
            'AddHandler spritePicture.DragDrop, AddressOf Me.Sprite_DragDrop
            'Else 'If Me.Mode = TilesetMapSTATE.SELECTER Then
            '    AddHandler spritePicture.MouseDown, AddressOf Me.Sprite_MouseDown
        End If


        'AddHandler spritePicture.MouseDown, AddressOf Me.Sprite_MouseDown
        AddHandler spritePicture.MouseUp, AddressOf Me.Sprite_MouseUp
        AddHandler spritePicture.DragEnter, AddressOf Me.Sprite_DragEnter
        AddHandler spritePicture.DragDrop, AddressOf Me.Sprite_DragDrop

        'CType(tilePicture, System.ComponentModel.ISupportInitialize).EndInit()
        'Me.ResumeLayout(False)

        'Me._tilePosValues(_id) = _id
        Me.spritePictures.Add(index, spritePicture)

        'Catch ex As Exception

        'End Try

    End Sub



    'Private Sub refreshSpriteItem(ByVal tileID As Integer)
    '    Dim tilePicture As System.Windows.Forms.PictureBox = Me.spritePictures(tileID)
    '    tilePicture.BackgroundImage = Me.Sprites.GetSprite(tileID).GetBitmap()
    'End Sub



    Private Sub refreshSpriteItem(ByVal index As Integer)
        Dim spritePicture As PictureBox
        Dim aSprite As SpriteMSX = Me.Sprites.GetSprite(index)

        spritePicture = Me.spritePictures.Item(index)
        spritePicture.BackColor = Sprites.Palette.GetRGBColor(aSprite.BackgroundColor)
        spritePicture.BackgroundImage = aSprite.GetBitmapX2()
        'spritePicture.BackgroundImage = Me.Sprites.GetSprite(index).GetBitmapX2()

        If Me._workmode = CONTROL_MODE.EXCHANGER Or Me._workmode = CONTROL_MODE.COPY Then
            'spritePicture.AllowDrop = True
            'AddHandler tilePicture.MouseDown, AddressOf Me.Tile_MouseDown
            AddHandler spritePicture.MouseMove, AddressOf Me.Sprite_MouseMove
            'AddHandler spritePicture.DragEnter, AddressOf Me.Sprite_DragEnter
            'AddHandler spritePicture.DragDrop, AddressOf Me.Sprite_DragDrop
        Else 'If Me.Mode = TilesetMapSTATE.SELECTER Then
            'spritePicture.AllowDrop = False
            'AddHandler tilePicture.MouseDown, AddressOf Me.Tile_MouseDown
            RemoveHandler spritePicture.MouseMove, AddressOf Me.Sprite_MouseMove
            'RemoveHandler spritePicture.DragEnter, AddressOf Me.Sprite_DragEnter
            'RemoveHandler spritePicture.DragDrop, AddressOf Me.Sprite_DragDrop
        End If
    End Sub



    Public Sub SelectSprite(ByVal index As Integer)

        Dim aSprite As SpriteMSX
        Dim spritePicture As PictureBox

        If Not _lastSelectedTilePicture Is Nothing Then
            'Me._lastSelectedTilePicture.BackColor = Color.Gray
            aSprite = Me.Sprites.GetSprite(Me._spriteSelected)
            Me._lastSelectedTilePicture.BackColor = Sprites.Palette.GetRGBColor(aSprite.BackgroundColor)
        End If

        Me._spriteSelected = index
        spritePicture = Me.spritePictures.Item(Me._spriteSelected)
        spritePicture.BackColor = Color.Gainsboro
        spritePicture.BringToFront()
        Me._lastSelectedTilePicture = spritePicture

        RaiseEvent SelectedSpriteChanged(index, Me.Sprites.GetSprite(Me._spriteSelected))
    End Sub



    Public Sub CopySprites(ByVal sourceIndex As Integer, ByVal targetIndex As Integer)

        Dim spritePicture1 As PictureBox = Me.spritePictures.Item(sourceIndex)
        Dim spritePicture2 As PictureBox = Me.spritePictures.Item(targetIndex)
        spritePicture2.BackgroundImage = spritePicture1.BackgroundImage.Clone

        Me.Sprites.CopySprites(sourceIndex, targetIndex)

    End Sub



    Private Sub ExchangeSprites(ByVal sourceIndex As Integer, ByVal targetIndex As Integer)

        Dim spritePicture1 As PictureBox = Me.spritePictures.Item(sourceIndex)
        Dim spritePicture2 As PictureBox = Me.spritePictures.Item(targetIndex)

        Dim tmpImage As System.Drawing.Image = spritePicture2.BackgroundImage

        spritePicture2.BackgroundImage = spritePicture1.BackgroundImage.Clone
        spritePicture1.BackgroundImage = tmpImage

        Me.Sprites.ExchangeSprites(sourceIndex, targetIndex)

    End Sub



    Private Sub AddSprite(ByVal index As Integer, ByVal sprite As SpriteMSX)
        Dim spritePicture1 As PictureBox

        If sprite Is Nothing Then Exit Sub

        spritePicture1 = Me.spritePictures.Item(index)
        spritePicture1.BackgroundImage = sprite.GetBitmapX2
        sprite.Index = index
        Me.Sprites.SetSprite(sprite)

    End Sub



    Private Sub Sprite_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim spritePicture As PictureBox = sender

        If Me._workmode = CONTROL_MODE.SELECTER Then
            SelectSprite(spritePicture.TabIndex)
        End If
    End Sub



    Private Sub Sprite_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim spritePicture As PictureBox = sender
        'If Not _tile.Image Is Nothing Then
        ' Set a flag to show that the mouse is down.


        'If Me._workmode = CONTROL_MODE.SELECTER Then
        '    SelectSprite(spritePicture.TabIndex)
        'End If

        'Select Case Me._workmode
        '    'Case CONTROL_MODE.DRAWER
        '    '    DrawTile(tilePicture.TabIndex, Me._tile2draw)

        '    Case CONTROL_MODE.EXCHANGER
        '        Me._MouseIsDown = True

        '    Case CONTROL_MODE.COPY
        '        Me._MouseIsDown = True

        '    Case Else 'TilesetMapSTATE.SELECTER

        '        SelectSprite(spritePicture.TabIndex)

        '        'If e.Button = Windows.Forms.MouseButtons.Left Then
        '        '    SelectTile(tilePicture.TabIndex)
        '        'ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
        '        '    SelectSecondTile(tilePicture.TabIndex)
        '        'End If

        'End Select

        'End If
    End Sub



    Private Sub Sprite_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim spritePicture As PictureBox = sender
        If e.Button = 0 Then Exit Sub
        'If _MouseIsDown Then
        ' Initiate dragging and allow either copy or move.
        spritePicture.DoDragDrop(spritePicture.Name, DragDropEffects.Move)
        'End If
        '_MouseIsDown = False
    End Sub



    Private Sub Sprite_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)
        'e.Effect = DragDropEffects.Move
        If e.Data.GetDataPresent(DataFormats.Text) Then
            e.Effect = DragDropEffects.Move
        ElseIf Me._workmode = CONTROL_MODE.SELECTER And e.Data.GetDataPresent("SpriteMSX") Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub



    Private Sub Sprite_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)
        Dim spritePicture As PictureBox = sender
        '_tile.Image = e.Data.GetData(DataFormats.Bitmap)

        Select Case Me._workmode
            'Case CONTROL_MODE.DRAWER
            '    DrawTile(tilePicture.TabIndex, Me._tile2draw)

            Case CONTROL_MODE.EXCHANGER
                ExchangeSprites(CInt(e.Data.GetData(DataFormats.Text)), CInt(spritePicture.Name))

            Case CONTROL_MODE.COPY
                CopySprites(CInt(e.Data.GetData(DataFormats.Text)), CInt(spritePicture.Name))

            Case CONTROL_MODE.SELECTER
                AddSprite(CInt(spritePicture.Name), e.Data.GetData("SpriteMSX"))

        End Select


        'If _MouseIsDown Then
        'If Me._workmode = CONTROL_MODE.COPY Then
        '        CopySprites(CInt(e.Data.GetData(DataFormats.Text)), CInt(spritePicture.Name))
        '    Else
        '        ExchangeSprites(CInt(e.Data.GetData(DataFormats.Text)), CInt(spritePicture.Name))
        '    End If

        '    _MouseIsDown = False
        'End If

    End Sub





    ''' <summary>
    ''' Actualiza las imagenes de los sprites, con los colores de una nueva paleta.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RefreshPalette()

        Dim spritePicture As PictureBox


        'Me._palette = _MSXpalette
        For Each aSprite As SpriteMSX In Me.Sprites.GetValues()
            'aSprite.Palette = Me.Sprites.Palette
            aSprite.refresh()
            'Me.sprites.RefreshPicture(aSprite.ID)
            spritePicture = Me.spritePictures.Item(aSprite.Index)
            spritePicture.BackColor = Sprites.Palette.GetRGBColor(aSprite.BackgroundColor)
            spritePicture.BackgroundImage = aSprite.GetBitmapX2()
        Next

        'Me.SpriteListPanel.Refresh()

    End Sub

  
End Class
