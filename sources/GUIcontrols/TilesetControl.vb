Imports mSXdevtools.GUI.Controls
Imports System.Windows.Forms
Imports System.Drawing


Public Class TilesetControl


    Private _tileset As TilesetMSX
    Private _squaredset As SupertilesSET
    Private _tilePosValues As New SortedList(256)
    Private TilePictureIndex As New SortedList(256) ' para el acceso a los items graficos del control

    Private _MouseIsDown As Boolean = False

    Private _workmode As CONTROL_MODE = CONTROL_MODE.SELECTER
    Private _tilemode As TILE_TYPE = TILE_TYPE.SingleTILE

    Private _LASTworkmode As CONTROL_MODE = CONTROL_MODE.NONE
    Private _LASTtilemode As TILE_TYPE = TILE_TYPE.NONE

    Private _lastSelectedTilePicture As PictureBox


    Private _tileSelected As Integer = 0
    Private _tile2draw As Integer = 0


    Private _undo As New SizedStack(8)
    Private _redo As New SizedStack(8)

    Private _lastTilesModified As New ArrayList


    Public Event SelectedTileChanged(ByVal id As Integer)
    Public Event SelectedSecondTileChanged(ByVal id As Integer)



    Public Shadows Enum TILE_TYPE As Integer
        SingleTILE
        SuperTILE
        NONE
    End Enum


    Public Shadows Enum CONTROL_MODE As Integer
        SELECTER
        MULTISELECTER
        DRAWER
        EXCHANGER
        COPY
        NONE
    End Enum






    Public Property WorkMode() As CONTROL_MODE
        Get
            Return Me._workmode
        End Get
        Set(ByVal value As CONTROL_MODE)
            Me._workmode = value
        End Set
    End Property


    Public Property TileMode() As TILE_TYPE
        Get
            Return Me._tilemode
        End Get
        Set(ByVal value As TILE_TYPE)
            Me._tilemode = value
        End Set
    End Property


    'Public Property IsSquaredTile() As Boolean
    '    Get
    '        Return Me.squaredTile
    '    End Get
    '    Set(ByVal value As Boolean)
    '        Me.squaredTile = value
    '    End Set
    'End Property



    Public Property TileSelected() As Integer
        Get
            Return Me._tileSelected
        End Get
        Set(ByVal value As Integer)
            Me._tileSelected = value
        End Set
    End Property



    Public Property Tile2Draw() As Integer
        Get
            Return Me._tile2draw
        End Get
        Set(ByVal value As Integer)
            Me._tile2draw = value
        End Set
    End Property



    'Public Property Tileset() As TilesetMSX
    '    Get
    '        Return Me._tileset
    '    End Get
    '    Set(ByVal value As TilesetMSX)
    '        Me._tileset = value
    '    End Set
    'End Property



    'Public Property Squaredset() As Squaredset
    '    Get
    '        Return Me._squaredset
    '    End Get
    '    Set(ByVal value As Squaredset)
    '        Me._squaredset = value
    '    End Set
    'End Property



    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub



    Private Sub TilesetSquaredControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub



    Public Sub SetTileset(ByVal atileset As TilesetMSX)
        Me._tileset = atileset

        Me._undo.Clear()
        Me._redo.Clear()

        'If Me.TilePictureIndex.Count > 0 Then
        '    DisposePictures()
        'End If

        'GenerateTilesetMap()
        'RefreshTilesetMap()

    End Sub



    'Public Sub SetTileset(ByVal aTileset As TilesetMSX, ByVal aSquaredData As Squaredset)

    '    Me._tileset = aTileset

    '    'If Me.TilePictureIndex.Count > 0 Then
    '    '    DisposePictures()
    '    'End If

    '    Me._squaredset = aSquaredData

    '    'GenerateTilesetMap()
    '    'RefreshTilesetMap()

    'End Sub



    Public Sub SetSquaredset(ByVal aSquaredData As SupertilesSET)
        Me._squaredset = aSquaredData

        Me._undo.Clear()
        Me._redo.Clear()

        'If Not Me._tileset Is Nothing Then
        '    GenerateTilesetMap()
        'End If

        'RefreshTilesetMap()

    End Sub



    Private Sub DisposePictures()
        For Each item As PictureBox In Me.TilePictureIndex.Values
            item.Dispose()
        Next
        Me.TilePictureIndex.Clear()
    End Sub



    Public Sub SetMode(ByVal newWorkMode As CONTROL_MODE, ByVal newTileMode As TILE_TYPE)

        Me._workmode = newWorkMode
        Me._tilemode = newTileMode

        'eliminar controles de pantalla <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        'DisposePictures()
        If Not _lastSelectedTilePicture Is Nothing Then
            Me._lastSelectedTilePicture.BackColor = Color.Gray
        End If
        Me._lastSelectedTilePicture = Nothing
        ' <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        GenerateTilesetMap()

    End Sub



    Public Sub GenerateTilesetMap()

        Me._lastTilesModified.Clear()

        If Me._tilemode = TILE_TYPE.SuperTILE Then

            If Me._LASTtilemode = TILE_TYPE.SingleTILE Then
                GenerateSupertileMap()
            Else


                If Me._workmode = CONTROL_MODE.DRAWER Then

                    If Not Me._LASTworkmode = CONTROL_MODE.DRAWER Then
                        GenerateSupertileMapSingleEdit()
                    Else
                        RefreshSupertileMapSingleEdit()
                    End If

                Else

                    If Me._LASTworkmode = CONTROL_MODE.NONE Or Me._LASTworkmode = CONTROL_MODE.DRAWER Then
                        GenerateSupertileMap()
                    Else
                        RefreshSupertileMap()
                    End If

                End If


            End If


        Else
            If Me._LASTworkmode = CONTROL_MODE.NONE Or Me._LASTtilemode = TILE_TYPE.SuperTILE Then
                GenerateSingleTileMap()
            Else
                RefreshSingleTileMap()
            End If

        End If

        Me._LASTtilemode = Me._tilemode
        Me._LASTworkmode = Me._workmode

        If Me._workmode = CONTROL_MODE.SELECTER Then
            'Me._tileSelected = 0
            SelectTile(Me._tileSelected)
        End If

    End Sub



    Public Sub RefreshTilesetMap()
        If Me._tilemode = TILE_TYPE.SuperTILE Then

            Select Case Me._workmode

                Case CONTROL_MODE.DRAWER
                    RefreshSupertileMapSingleEdit()

                    'Case CONTROL_MODE.EXCHANGER
                    '    RefreshSquaredTileMap()

                    'Case CONTROL_MODE.MULTISELECTER
                    '    RefreshSquaredTileMap()

                Case Else
                    RefreshSupertileMap()

            End Select

        Else
            RefreshSingleTileMap()
        End If

        'If Me._workmode = CONTROL_MODE.SELECTER Then
        '    SelectTile(Me._tileSelected)
        'End If

    End Sub



    Private Sub GenerateSingleTileMap()

        Dim tileNumber As Integer = 0

        If Me.TilePictureIndex.Count > 0 Then
            DisposePictures()
        End If

        Me.SuspendLayout()
        For y As Integer = 0 To 7
            For x As Integer = 0 To 31
                putTile(x, y, Me._tileset.GetTile(tileNumber), tileNumber)
                tileNumber += 1
            Next
        Next
        Me.ResumeLayout(False)

    End Sub



    Private Sub RefreshSingleTileMap()

        Dim tileNumber As Integer = 0

        'Me.TilePictureIndex.Clear()

        Me.SuspendLayout()
        For y As Integer = 0 To 7
            For x As Integer = 0 To 31
                refreshTile(Me._tileset.GetTile(tileNumber), tileNumber)
                tileNumber += 1
            Next
        Next
        Me.ResumeLayout(False)

    End Sub




    Private Sub GenerateSupertileMap()

        Dim tileNumber As Integer = 0

        If Me.TilePictureIndex.Count > 0 Then
            DisposePictures()
        End If

        Me.SuspendLayout()
        For y As Integer = 0 To 3
            For x As Integer = 0 To 15
                PutSupertile(x, y, tileNumber)
                tileNumber += 1
            Next
        Next
        Me.ResumeLayout(False)

    End Sub




    Private Sub RefreshSupertileMap()

        Dim tileNumber As Integer = 0

        'Me.TilePictureIndex.Clear()

        Me.SuspendLayout()
        For y As Integer = 0 To 3
            For x As Integer = 0 To 15
                RefreshSupertile(tileNumber)
                tileNumber += 1
            Next
        Next
        Me.ResumeLayout(False)

    End Sub




    Private Sub GenerateSupertileMapSingleEdit()

        Dim tileNumber As Integer = 0

        Dim posX As Integer = 0
        Dim posY As Integer = 0
        Dim posiTile As Integer = 0

        Dim aSquaredTile As SuperTile


        If Me.TilePictureIndex.Count > 0 Then
            DisposePictures()
        End If


        Me.SuspendLayout()
        For y As Integer = 0 To 3
            For x As Integer = 0 To 15
                aSquaredTile = Me._squaredset.GetSquaredTile(tileNumber)
                posX = x * 2
                posY = y * 2
                posiTile = (y * 64) + (x * 2)
                PutSupertile(posX, posY, Me._tileset.GetTile(aSquaredTile.UpLeftTile), posiTile)
                PutSupertile(posX + 1, posY, Me._tileset.GetTile(aSquaredTile.UpRightTile), posiTile + 1)
                PutSupertile(posX, posY + 1, Me._tileset.GetTile(aSquaredTile.DownLeftTile), posiTile + 32)
                PutSupertile(posX + 1, posY + 1, Me._tileset.GetTile(aSquaredTile.DownRightTile), posiTile + 33)
                tileNumber += 1
            Next
        Next
        Me.ResumeLayout(False)

    End Sub




    Private Sub RefreshSupertileMapSingleEdit()

        Dim tileNumber As Integer = 0

        Dim posX As Integer = 0
        Dim posY As Integer = 0
        Dim posiTile As Integer = 0

        Dim aSquaredTile As SuperTile

        'Me.TilePictureIndex.Clear()

        Me.SuspendLayout()
        For y As Integer = 0 To 3
            For x As Integer = 0 To 15
                aSquaredTile = Me._squaredset.GetSquaredTile(tileNumber)
                posiTile = (y * 64) + (x * 2)
                refreshTile(Me._tileset.GetTile(aSquaredTile.UpLeftTile), posiTile)
                refreshTile(Me._tileset.GetTile(aSquaredTile.UpRightTile), posiTile + 1)
                refreshTile(Me._tileset.GetTile(aSquaredTile.DownLeftTile), posiTile + 32)
                refreshTile(Me._tileset.GetTile(aSquaredTile.DownRightTile), posiTile + 33)
                tileNumber += 1
            Next
        Next
        Me.ResumeLayout(False)

    End Sub




    Private Sub putTile(ByVal x As Integer, ByVal y As Integer, ByVal aTile As TileMSX, ByVal tileIndex As Integer)
        'Try
        Dim tilePicture As New System.Windows.Forms.PictureBox

        Dim posX As Integer
        Dim posY As Integer


        ' calcula posicionamiento del tile            
        posX = (x * 17)
        posY = (y * 17)

        'Me.SuspendLayout()

        tilePicture.BackColor = System.Drawing.Color.Gray
        tilePicture.BackgroundImageLayout = ImageLayout.Center
        tilePicture.BackgroundImage = aTile.GetBitmapX2()
        tilePicture.Location = New System.Drawing.Point(posX, posY)

        tilePicture.Name = CStr(tileIndex) 'para identificar la posicion en la lista desde los eventos

        tilePicture.Size = New System.Drawing.Size(18, 18)

        tilePicture.TabIndex = tileIndex
        tilePicture.TabStop = False

        Me.Controls.Add(tilePicture)

        Me.ToolTip1.SetToolTip(tilePicture, tileIndex)



        If Me._workmode = CONTROL_MODE.EXCHANGER Or Me._workmode = CONTROL_MODE.COPY Then
            tilePicture.AllowDrop = True
            AddHandler tilePicture.MouseDown, AddressOf Me.Tile_MouseDown
            AddHandler tilePicture.DoubleClick, AddressOf Me.Tile_DoubleClick
            AddHandler tilePicture.MouseMove, AddressOf Me.Tile_MouseMove
            AddHandler tilePicture.DragEnter, AddressOf Me.Tile_DragEnter
            AddHandler tilePicture.DragDrop, AddressOf Me.Tile_DragDrop
        Else 'If Me.Mode = TilesetMapSTATE.SELECTER Then
            AddHandler tilePicture.MouseDown, AddressOf Me.Tile_MouseDown
        End If

        'Me.ResumeLayout(False)

        Me._tilePosValues(tileIndex) = tileIndex
        Me.TilePictureIndex(tileIndex) = tilePicture



        'Catch ex As Exception

        'End Try

    End Sub



    Private Sub PutSupertile(ByVal x As Integer, ByVal y As Integer, ByVal aTile As TileMSX, ByVal tileIndex As Integer)
        'Try
        Dim tilePicture As New System.Windows.Forms.PictureBox

        Dim posX As Integer
        Dim posY As Integer


        ' calcula posicionamiento del tile
        If esPar(x) Then
            posX = (x * 17)
        Else
            posX = 1 + (x * 17)
        End If

        If esPar(y) Then
            posY = (y * 17)
        Else
            posY = 1 + (y * 17)
        End If

        'Me.SuspendLayout()

        tilePicture.BackColor = System.Drawing.Color.Gray
        tilePicture.BackgroundImageLayout = ImageLayout.Center
        tilePicture.BackgroundImage = aTile.GetBitmapX2()
        tilePicture.Location = New System.Drawing.Point(posX, posY)

        tilePicture.Name = CStr(tileIndex) 'para identificar la posicion, desde los eventos

        tilePicture.Size = New System.Drawing.Size(16, 16)

        tilePicture.TabIndex = tileIndex
        tilePicture.TabStop = False

        Me.Controls.Add(tilePicture)

        Me.ToolTip1.SetToolTip(tilePicture, tileIndex)

        AddHandler tilePicture.MouseDown, AddressOf Me.Tile_MouseDown

        'Me.ResumeLayout(False)

        Me._tilePosValues(tileIndex) = tileIndex
        Me.TilePictureIndex(tileIndex) = tilePicture

        'Catch ex As Exception

        'End Try

    End Sub






    Private Sub PutSupertile(ByVal x As Integer, ByVal y As Integer, ByVal tileID As Integer)
        'Try
        Dim tilePicture As New System.Windows.Forms.PictureBox

        Dim posX As Integer
        Dim posY As Integer

        ' calcula posicionamiento del tile

        posX = (x * 34)
        posY = (y * 34)

        'CType(tilePicture, System.ComponentModel.ISupportInitialize).BeginInit()
        'Me.SuspendLayout()

        tilePicture.BackColor = System.Drawing.Color.Gray
        tilePicture.BackgroundImageLayout = ImageLayout.Center
        tilePicture.BackgroundImage = Me._squaredset.GetSquaredTileBitmapX2(tileID, Me._tileset)  'getSquaredTileBitmap(_squaredset.GetSquaredTile(tileID))
        tilePicture.Location = New System.Drawing.Point(posX, posY)

        tilePicture.Size = New System.Drawing.Size(34, 34)

        tilePicture.Name = CStr(tileID) 'para identificar la posicion, desde los eventos

        tilePicture.TabIndex = tileID
        tilePicture.TabStop = False

        Me.Controls.Add(tilePicture)


        If Me._workmode = CONTROL_MODE.EXCHANGER Or Me._workmode = CONTROL_MODE.COPY Then
            tilePicture.AllowDrop = True
            AddHandler tilePicture.MouseDown, AddressOf Me.Tile_MouseDown
            AddHandler tilePicture.MouseMove, AddressOf Me.Tile_MouseMove
            AddHandler tilePicture.DragEnter, AddressOf Me.Tile_DragEnter
            AddHandler tilePicture.DragDrop, AddressOf Me.Tile_DragDrop
        Else 'If Me.Mode = TilesetMapSTATE.SELECTER Then
            AddHandler tilePicture.MouseDown, AddressOf Me.Tile_MouseDown
        End If


        'CType(tilePicture, System.ComponentModel.ISupportInitialize).EndInit()
        'Me.ResumeLayout(False)

        Me._tilePosValues(tileID) = tileID
        Me.TilePictureIndex(tileID) = tilePicture

        'Catch ex As Exception

        'End Try

    End Sub



    Private Sub refreshTile(ByVal aTile As TileMSX, ByVal tileID As Integer)
        Dim tilePicture As System.Windows.Forms.PictureBox = Me.TilePictureIndex(tileID)
        tilePicture.BackgroundImage = aTile.GetBitmapX2()

        Me._tilePosValues(tileID) = aTile.Index

        If Me._workmode = CONTROL_MODE.EXCHANGER Or Me._workmode = CONTROL_MODE.COPY Then
            tilePicture.AllowDrop = True
            'AddHandler tilePicture.MouseDown, AddressOf Me.Tile_MouseDown
            AddHandler tilePicture.DoubleClick, AddressOf Me.Tile_DoubleClick
            AddHandler tilePicture.MouseMove, AddressOf Me.Tile_MouseMove
            AddHandler tilePicture.DragEnter, AddressOf Me.Tile_DragEnter
            AddHandler tilePicture.DragDrop, AddressOf Me.Tile_DragDrop
        Else 'If Me.Mode = TilesetMapSTATE.SELECTER Then
            tilePicture.AllowDrop = False
            'AddHandler tilePicture.MouseDown, AddressOf Me.Tile_MouseDown
            RemoveHandler tilePicture.DoubleClick, AddressOf Me.Tile_DoubleClick
            RemoveHandler tilePicture.MouseMove, AddressOf Me.Tile_MouseMove
            RemoveHandler tilePicture.DragEnter, AddressOf Me.Tile_DragEnter
            RemoveHandler tilePicture.DragDrop, AddressOf Me.Tile_DragDrop
        End If
    End Sub



    Private Sub RefreshSupertile(ByVal tileID As Integer)
        Dim tilePicture As System.Windows.Forms.PictureBox = Me.TilePictureIndex(tileID)
        tilePicture.BackgroundImage = Me._squaredset.GetSquaredTileBitmapX2(tileID, Me._tileset)
    End Sub



    'Private Function getSquaredTileBitmap(ByVal _squaredTile As SquaredTile) As Bitmap

    '    Try
    '        Dim tile As TileMSX

    '        'x = (x * (TILE_TS_SIZE + TILE_TS_PAD))
    '        'y = (y * (TILE_TS_SIZE + TILE_TS_PAD))

    '        Dim aBitmap As New Bitmap(32, 32, Imaging.PixelFormat.Format24bppRgb)
    '        Dim aGraphics As Graphics = Graphics.FromImage(aBitmap)

    '        'value = (value - (Fix(value / 16) * 16)) * 2 + (Fix(value / 16) * 64)
    '        ''value = value * 4

    '        tile = Me._tileset.GetTile(_squaredTile.UpLeftTile)
    '        aGraphics.DrawImage(tile.GetBitmapX2, 0, 0, 16, 16)

    '        tile = Me._tileset.GetTile(_squaredTile.UpRightTile)
    '        aGraphics.DrawImage(tile.GetBitmapX2, 16, 0, 16, 16)

    '        tile = Me._tileset.GetTile(_squaredTile.DownLeftTile)
    '        aGraphics.DrawImage(tile.GetBitmapX2, 0, 16, 16, 16)

    '        tile = Me._tileset.GetTile(_squaredTile.DownRightTile)
    '        aGraphics.DrawImage(tile.GetBitmapX2, 16, 16, 16, 16)

    '        aGraphics.Flush()

    '        Return aBitmap

    '    Catch ex As Exception
    '        Return Nothing
    '    End Try


    'End Function



    Private Function esPar(ByVal value As Integer) As Boolean
        If (value Mod 2) <> 0 Then
            Return True
        Else
            Return False
        End If
    End Function






    Private Sub Tile_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim tilePicture As PictureBox = sender
        'If Not _tile.Image Is Nothing Then
        ' Set a flag to show that the mouse is down.

        Select Case Me._workmode
            Case CONTROL_MODE.DRAWER
                DrawTile(tilePicture.TabIndex, Me._tile2draw)

            Case CONTROL_MODE.EXCHANGER
                Me._MouseIsDown = True

            Case CONTROL_MODE.COPY
                Me._MouseIsDown = True

            Case Else 'TilesetMapSTATE.SELECTER

                If e.Button = Windows.Forms.MouseButtons.Left Then
                    SelectTile(tilePicture.TabIndex)
                ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
                    SelectSecondTile(tilePicture.TabIndex)
                End If

        End Select

        'End If
    End Sub



    Private Sub Tile_DoubleClick(sender As Object, e As EventArgs) 'Handles .DoubleClick
        Dim tilePicture As PictureBox = sender
        Me._tileSelected = tilePicture.TabIndex
        RaiseEvent SelectedTileChanged(Me._tileSelected)
    End Sub



    Private Sub Tile_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim tilePicture As PictureBox = sender
        If _MouseIsDown Then
            ' Initiate dragging and allow either copy or move.
            tilePicture.DoDragDrop(tilePicture.Name, DragDropEffects.Move)
        End If
        '_MouseIsDown = False
    End Sub



    Private Sub Tile_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)
        'e.Effect = DragDropEffects.Move
        If e.Data.GetDataPresent(DataFormats.Text) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub Tile_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)
        Dim tilePicture As PictureBox = sender
        '_tile.Image = e.Data.GetData(DataFormats.Bitmap)
        If _MouseIsDown Then
            If Me._workmode = CONTROL_MODE.COPY Then
                copyTiles(CInt(e.Data.GetData(DataFormats.Text)), CInt(tilePicture.Name))
            Else
                exChangeTiles(CInt(e.Data.GetData(DataFormats.Text)), CInt(tilePicture.Name))
            End If

            _MouseIsDown = False
        End If

    End Sub



    Public Sub SelectTile(ByVal id As Integer)
        Me._tileSelected = id

        If Not _lastSelectedTilePicture Is Nothing Then
            Me._lastSelectedTilePicture.BackColor = Color.Gray
        End If

        Dim tilePicture1 As PictureBox = Me.TilePictureIndex.Item(id)
        tilePicture1.BackColor = Color.Yellow
        tilePicture1.BringToFront()
        Me._lastSelectedTilePicture = tilePicture1

        RaiseEvent SelectedTileChanged(id)
    End Sub



    ''' <summary>
    ''' Selección de un segundo tile desde el boton alterno del ratón
    ''' para uso como tile de borrado (BG)
    ''' </summary>
    ''' <param name="id"></param>
    ''' <remarks></remarks>
    Private Sub SelectSecondTile(ByVal id As Integer)
        'Me._tileSelected = id

        RaiseEvent SelectedSecondTileChanged(id)
    End Sub



    Private Sub DrawTile(ByVal index As Integer, ByVal newTileID As Integer)

        Dim tile As TileMSX = Me._tileset.GetTile(newTileID) ' tilesetID
        Dim tilePicture1 As PictureBox = Me.TilePictureIndex.Item(index)

        tilePicture1.BackgroundImage = tile.GetBitmapX2()

        Me.Refresh()

        Dim posy As Integer = Math.Floor(index / 32) ' - 1
        Dim posx As Integer = index - (posy * 32)

        Me._tilePosValues.Item(index) = newTileID

        ' guardar el cambio
        If Me._tilemode = TILE_TYPE.SuperTILE Then
            'identificar posicion del squared tile

            Dim posy2 As Integer = Math.Floor(posy / 2)
            Dim posx2 As Integer = Math.Floor(posx / 2)

            Dim squaredTileIndex As Integer = (posy2 * 16) + posx2
            Dim tileID As Integer = (posy2 * 64) + (posx2 * 2)

            Me._squaredset.SetSquaredTile(New SuperTile(squaredTileIndex, Me._tilePosValues(tileID), Me._tilePosValues(tileID + 1), Me._tilePosValues(tileID + 32), Me._tilePosValues(tileID + 33)))
        Else
            ' only in SquaredTILE mode


        End If

    End Sub



    Private Sub copyTiles(ByVal tileIndex1 As Integer, ByVal tileIndex2 As Integer)

        'Dim tmpTile As TileMSX

        Dim tilePicture1 As PictureBox = Me.TilePictureIndex.Item(tileIndex1)
        Dim tilePicture2 As PictureBox = Me.TilePictureIndex.Item(tileIndex2)

        tilePicture2.BackgroundImage = tilePicture1.BackgroundImage.Clone

        Me._lastTilesModified.Clear()
        Me._lastTilesModified.Add(tileIndex2)
        AddUndo()

        'set data
        If Me._tilemode = TILE_TYPE.SingleTILE Then

            'Me._lastTilesModified.Add(Me._tileset.GetTile(tileIndex2).Clone())
            'AddUndo()

            'tmpTile = Me._tileset.GetTile(tileIndex1)
            Me._tileset.UpdateTile(tileIndex2, Me._tileset.GetTile(tileIndex1).Clone())

        Else
            'squared tile
            'Set data
            'Me._lastTilesModified.Add(Me._squaredset.GetSquaredTile(tileIndex2).Clone())
            'AddUndo()

            Me._squaredset.UpdateSquaredTile(tileIndex2, Me._squaredset.GetSquaredTile(tileIndex1).Clone())
        End If

    End Sub



    Private Sub exChangeTiles(ByVal tileIndex1 As Integer, ByVal tileIndex2 As Integer)

        Dim tmpTile1 As TileMSX
        Dim tmpTile2 As TileMSX
        Dim tmpSquaredTile1 As SuperTile
        Dim tmpSquaredTile2 As SuperTile

        Dim tilePicture1 As PictureBox = Me.TilePictureIndex.Item(tileIndex1)
        Dim tilePicture2 As PictureBox = Me.TilePictureIndex.Item(tileIndex2)

        Me._lastTilesModified.Clear()
        Me._lastTilesModified.Add(tileIndex1)
        Me._lastTilesModified.Add(tileIndex2)
        AddUndo()

        If Me._tilemode = TILE_TYPE.SingleTILE Then
            'set data
            tmpTile1 = Me._tileset.GetTile(tileIndex1).Clone()
            tmpTile2 = Me._tileset.GetTile(tileIndex2).Clone()

            'Me._lastTilesModified.Add(tmpTile1.Clone())
            'Me._lastTilesModified.Add(tmpTile2.Clone())
            'AddUndo()

            Me._tileset.UpdateTile(tileIndex1, tmpTile2)
            Me._tileset.UpdateTile(tileIndex2, tmpTile1)

            tilePicture2.BackgroundImage = tmpTile1.GetBitmapX2()
            tilePicture1.BackgroundImage = tmpTile2.GetBitmapX2()

        Else
            'squared tile
            tmpSquaredTile1 = Me._squaredset.GetSquaredTile(tileIndex1).Clone()
            tmpSquaredTile2 = Me._squaredset.GetSquaredTile(tileIndex2).Clone()

            'Me._lastTilesModified.Add(tmpSquaredTile1.Clone())
            'Me._lastTilesModified.Add(tmpSquaredTile2.Clone())
            'AddUndo()

            tilePicture1.BackgroundImage = Me._squaredset.GetSquaredTileBitmapX2(tmpSquaredTile2, Me._tileset) 'getSquaredTileBitmap(tmpSquaredTile2)
            tilePicture1.TabIndex = tileIndex2

            tilePicture2.BackgroundImage = Me._squaredset.GetSquaredTileBitmapX2(tmpSquaredTile1, Me._tileset) 'getSquaredTileBitmap(tmpSquaredTile1)
            tilePicture2.TabIndex = tileIndex1

            'Set data
            Me._squaredset.UpdateSquaredTile(tileIndex1, tmpSquaredTile2)
            Me._squaredset.UpdateSquaredTile(tileIndex2, tmpSquaredTile1)

        End If

    End Sub



    'Private Sub exChangeTiles(ByVal tileIndex1 As Integer, ByVal tileIndex2 As Integer)

    '    Dim tilePicture1 As PictureBox = Me.TilePictureIndex.Item(tileIndex1)
    '    Dim tilePicture2 As PictureBox = Me.TilePictureIndex.Item(tileIndex2)

    '    'Dim tileID1 As Integer = tilePicture1.TabIndex
    '    'Dim tileID2 As Integer = tilePicture2.TabIndex

    '    'Dim tile As TileMSX = Me._tilesetProject.GetTile(0, tileID2)
    '    'tilePicture1.Image = tile.GetBitmapX2()
    '    'tilePicture1.TabIndex = tileID2

    '    'tile = Me._tilesetProject.GetTile(0, tileID1)
    '    'tilePicture2.Image = tile.GetBitmapX2()
    '    'tilePicture2.TabIndex = tileID1

    'End Sub





    'Private Sub DrawSelectedArea()

    'Dim aGraphics As Graphics = Graphics.FromImage(Me.outputBitmap)

    ''clear old selected rectangle
    'If Not Me.SelectAreaRectangle.IsEmpty Then
    '    aGraphics.DrawRectangle(New System.Drawing.Pen(BGmapControlColor, 1), Me.SelectAreaRectangle)
    'End If

    'Me.SelectAreaRectangle = New System.Drawing.Rectangle(New System.Drawing.Point(Me.select_x * (TILE_WSIZE + TILE_PAD), Me.select_y * (TILE_WSIZE + TILE_PAD)), New System.Drawing.Size((select_width + 1) * (TILE_WSIZE + TILE_PAD), (select_height + 1) * (TILE_WSIZE + TILE_PAD)))
    'aGraphics.DrawRectangle(New System.Drawing.Pen(SelectMapControlColor, 1), Me.SelectAreaRectangle)
    ''aGraphics.Flush()

    'workbenchPictureBox.Refresh()

    'End Sub





    Public Sub UpdateTile(ByVal aTile As TileMSX)

        Dim tilePicture1 As PictureBox = Me.TilePictureIndex.Item(aTile.Index)

        Me._lastTilesModified.Clear()
        Me._lastTilesModified.Add(aTile.Index)
        AddUndo()

        Me._tileset.UpdateTile(aTile.Index, aTile)

        tilePicture1.BackgroundImage = aTile.GetBitmapX2()

        If Me._tilemode = TILE_TYPE.SingleTILE And Me._tileset.Mode = iVDP.SCREEN_MODE.G1 Then
            RefreshTilesetMap()
        End If

    End Sub




    ' ######################################################################################################

    Public Sub AddUndo()

        If Me._lastTilesModified.Count > 0 Then
            Me._undo.Push(getTilesArray())
        End If

        'If Me._tilemode = TILE_TYPE.SingleTILE Then
        '    'SingleTILE
        '    Me._undo.Push(Me._tileset.Clone())
        '    'Me._undo.Push(New UndoItem(Me._tileset.Clone()))
        'Else
        '    ' SquaredTILE
        '    Me._undo.Push(Me._squaredset.Clone())
        'End If
    End Sub



    Public Sub AddRedo() 'lista As ArrayList

        If Me._lastTilesModified.Count > 0 Then
            'RefreshLastTilesModified()
            'Me._redo.Push(Me._lastTilesModified.Clone())
            Me._redo.Push(getTilesArray())
        End If

    End Sub


    Private Function getTilesArray() As ArrayList

        Dim tmpArray As New ArrayList

        For Each index As Integer In Me._lastTilesModified
            'If TypeOf Me._lastTilesModified.Item(i) Is TileMSX Then
            If Me._tilemode = TILE_TYPE.SingleTILE Then
                tmpArray.Add(Me._tileset.GetTile(index).Clone())
            Else
                tmpArray.Add(Me._squaredset.GetSquaredTile(index).Clone())
            End If
        Next

        Return tmpArray
    End Function


    'Private Sub RefreshLastTilesModified()
    '    Dim tmpTile As TileMSX
    '    Dim tmpSquaredTile As SquaredTile

    '    If Me._lastTilesModified.Count > 0 Then

    '        For i As Integer = 0 To Me._lastTilesModified.Count - 1
    '            'If TypeOf Me._lastTilesModified.Item(i) Is TileMSX Then
    '            If Me._tilemode = TILE_TYPE.SingleTILE Then
    '                tmpTile = Me._lastTilesModified.Item(i)
    '                Me._lastTilesModified.Item(i) = Me._tileset.GetTile(tmpTile.Index).Clone()
    '            Else
    '                tmpSquaredTile = Me._lastTilesModified.Item(i)
    '                Me._lastTilesModified.Item(i) = Me._squaredset.GetSquaredTile(tmpSquaredTile.Index).Clone()
    '            End If
    '        Next

    '    End If

    'End Sub




    Public Sub Undo()

        Dim tmpArray As ArrayList

        If Me._undo.Count > 0 Then
            tmpArray = CType(Me._undo.Pop, ArrayList)

            If Me._tilemode = TILE_TYPE.SingleTILE Then

                AddRedo()
                'Me._tileset = CType(Me._undo.Pop, TilesetMSX)
                For Each item As TileMSX In tmpArray
                    Me._tileset.UpdateTile(item.Index, item)
                Next
                RefreshTilesetMap()

            Else
                ' SquaredTILE

                AddRedo()
                'Me._squaredset = CType(Me._undo.Pop, Squaredset)
                For Each item As SuperTile In tmpArray
                    Me._squaredset.SetSquaredTile(item)
                Next
                RefreshTilesetMap()

            End If
        End If

    End Sub



    Public Sub Redo()

        Dim tmpArray As ArrayList

        If Me._redo.Count > 0 Then
            tmpArray = CType(Me._redo.Pop, ArrayList)

            If Me._tilemode = TILE_TYPE.SingleTILE Then

                'RefreshLastTilesModified()
                AddUndo()
                'Me._tileset = CType(Me._redo.Pop, TilesetMSX)
                For Each item As TileMSX In tmpArray
                    Me._tileset.UpdateTile(item.Index, item)
                Next
                RefreshTilesetMap()

            Else
                ' SquaredTILE
                'RefreshLastTilesModified()
                AddUndo()
                'Me._squaredset = CType(Me._redo.Pop, Squaredset)
                For Each item As SuperTile In tmpArray
                    Me._squaredset.SetSquaredTile(item)
                Next
                RefreshTilesetMap()

            End If
        End If

    End Sub
    ' ######################################################################################################



End Class
