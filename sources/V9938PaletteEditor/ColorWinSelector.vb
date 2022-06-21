Imports System.Windows.Forms
Imports mSXdevtools.DataStructures



Public Class ColorWinSelector

    Private workPalette As PaletteV9938

    Public palette As PaletteV9938

    Private _step As Integer = 0
    Private _type As DIALOG_MODE = DIALOG_MODE.COPY

    Public SourceValue As Integer = 0
    Public TargetValue As Integer = 0

    Private PaletteGfxData As New ArrayList

    'Private undo_lastOperation As Integer
    Private undo_SourceColor As ColorMSX
    Private undo_TargetColor As ColorMSX



    Public Shadows Enum DIALOG_MODE As Integer
        COPY
        CHANGE
    End Enum



    Public Sub New(ByVal type As DIALOG_MODE, ByVal _PaletteColors As PaletteV9938)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        Me.palette = _PaletteColors
        Me.workPalette = _PaletteColors.Clone

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        GeneratePalette()

        setMode(type)
        'setStep(0)

    End Sub



    Private Sub setMode(ByVal value As DIALOG_MODE)
        Me._type = value
        If value = DIALOG_MODE.COPY Then
            ' copy
            TitleLabel.Text = "Copy"



        Else
            ' change
            TitleLabel.Text = "Change"


        End If

    End Sub


    'Private Sub setStep(ByVal value As Integer)
    '    Me._step = value
    '    If value = 0 Then
    '        Me.MessageLabel.Text = "Select source color."
    '        Me.targetPic.Visible = False

    '    ElseIf value = 1 Then
    '        Me.MessageLabel.Text = "Select target color."
    '        Me.targetPic.Visible = True

    '    Else
    '        If Me._type = DIALOG_MODE.COPY Then
    '            'copy
    '            CopyColor(Me.SourceValue, Me.TargetValue)

    '        Else
    '            'change
    '            ChangeColor(Me.SourceValue, Me.TargetValue)
    '        End If

    '    End If
    'End Sub




    Public Sub CopyColor(ByVal _sourceValue As Integer, ByVal _targetValue As Integer)

        Dim sourceColor As ColorMSX = Me.workPalette.GetMSXColor(_sourceValue)
        Dim targetColor As ColorMSX = Me.workPalette.GetMSXColor(_targetValue)

        Dim targetColorBox As Button = Me.PaletteGfxData(_targetValue - 1)

        Me.undo_SourceColor = sourceColor.Clone
        Me.undo_TargetColor = targetColor.Clone
        UndoButton.Enabled = True

        'copy
        Me.workPalette.SetColor(_targetValue, sourceColor.Clone)

        targetColorBox.BackColor = Me.workPalette.GetRGBColor(_targetValue)

        'Me.setStep(0)

        'RedrawPalette()

    End Sub



    Public Sub ChangeColor(ByVal _sourceValue As Integer, ByVal _targetValue As Integer)

        Dim sourceColor As ColorMSX = Me.workPalette.GetMSXColor(_sourceValue)
        Dim targetColor As ColorMSX = Me.workPalette.GetMSXColor(_targetValue)
        Dim tmpColor As ColorMSX = Me.workPalette.GetMSXColor(_targetValue).Clone

        Dim sourceColorBox As Button = Me.PaletteGfxData(_sourceValue - 1)
        Dim targetColorBox As Button = Me.PaletteGfxData(_targetValue - 1)

        Me.undo_SourceColor = sourceColor.Clone
        Me.undo_TargetColor = targetColor.Clone
        UndoButton.Enabled = True

        Me.workPalette.SetColor(_targetValue, sourceColor.Clone)
        Me.workPalette.SetColor(_sourceValue, tmpColor.Clone)

        sourceColorBox.BackColor = workPalette.GetRGBColor(_sourceValue)
        targetColorBox.BackColor = workPalette.GetRGBColor(_targetValue)

        'Me.setStep(0)

        'RedrawPalette()

    End Sub



  


    'Private Function getColorBox(ByVal id As Integer, ByVal x As Integer, ByVal y As Integer, ByVal aColor As Color) As System.Windows.Forms.Control
    '    Dim ColorBox As New PictureBox

    '    Me.SuspendLayout()
    '    ColorBox.BackColor = aColor
    '    ColorBox.Location = New System.Drawing.Point(x, y)
    '    ColorBox.Name = CStr(id)
    '    ColorBox.Size = New System.Drawing.Size(15, 15)
    '    ColorBox.TabIndex = id
    '    ColorBox.TabStop = False
    '    Me.ResumeLayout(False)

    '    Me.ToolTip1.SetToolTip(ColorBox, "Color " + CStr(id))

    '    Return ColorBox
    'End Function





    Private Sub GeneratePalette()
        Dim ColorBox As Button

        Me.SuspendLayout()

        For i As Integer = 1 To 15

            ColorBox = GetNewColorBox(i)

            Me.PaletteNPanel.Controls.Add(ColorBox)
            Me.PaletteGfxData.Add(ColorBox)

            AddHandler ColorBox.MouseDown, AddressOf Me.ColorBox_MouseDown
            AddHandler ColorBox.DragDrop, AddressOf Me.ColorBox_DragDrop
            AddHandler ColorBox.DragEnter, AddressOf Me.ColorBox_DragEnter

        Next

        Me.ResumeLayout(False)

    End Sub


    Private Function GetNewColorBox(ByVal colorIndex As Integer) As System.Windows.Forms.Control
        Dim ColorButton As New Button

        Dim x As Integer = (colorIndex - 1) * 28

        ColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        ColorButton.BackColor = Me.workPalette.GetRGBColor(colorIndex)
        ColorButton.Location = New System.Drawing.Point(x, 0)
        ColorButton.Name = "CBUTT_" + CStr(colorIndex)
        ColorButton.Size = New System.Drawing.Size(28, 28)
        ColorButton.TabIndex = colorIndex
        ColorButton.TabStop = False
        ColorButton.AllowDrop = True

        Me.ToolTip1.SetToolTip(ColorButton, "Color " + CStr(colorIndex))

        Return ColorButton
    End Function

    'Private Sub GeneratePalette()
    '    Dim ColorBox As System.Windows.Forms.PictureBox
    '    Dim contador As Integer = 0
    '    'Dim aColor As ColorMSX

    '    For i As Integer = 0 To 15 'Each aColor As ColorMSX In PaletteColors.Colors.Values
    '        'aColor = PaletteColors.GetMSXColor(i)
    '        ColorBox = getColorBox(contador, contador * 16, 0, PaletteColors.GetRGBColor(i)) '.RGBColor)

    '        Me.PalettePanel.Controls.Add(ColorBox)
    '        Me.PaletteGfxData.Add(ColorBox)
    '        AddHandler ColorBox.Click, AddressOf Me.PalettePanel_Click
    '        AddHandler ColorBox.MouseEnter, AddressOf Me.PalettePanel_MouseEnter

    '        contador += 1
    '    Next

    'End Sub


    Private Sub RedrawPalette()
        Dim ColorBox As Button
        Dim contador As Integer = 0

        'For Each aColor As ColorMSX In PaletteColors.Colors.Values
        For i As Integer = 1 To 15

            ColorBox = Me.PaletteGfxData.Item(i - 1)

            ColorBox.BackColor = Me.workPalette.GetRGBColor(i)

        Next

        Me.Refresh()

    End Sub



    'Private Sub PalettePanel_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    'Handles PalettePanel.MouseEnter
    '    Dim aColorBox As PictureBox = CType(sender, PictureBox)

    '    If Me._step = 0 Then
    '        Me.sourcePic.Left = 30 + (aColorBox.TabIndex * 16)
    '    ElseIf Me._step = 1 Then
    '        If Not aColorBox.TabIndex = Me.SourceValue Then
    '            Me.targetPic.Left = 30 + (aColorBox.TabIndex * 16)
    '        End If
    '    End If

    'End Sub


    'Private Sub PalettePanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    'Handles sourcePic.Click
    '    Dim aColorBox As PictureBox = CType(sender, PictureBox)

    '    Dim value As Integer = aColorBox.TabIndex

    '    If value = 0 Then
    '        Exit Sub
    '    End If

    '    If Me._step = 0 Then
    '        Me.SourceValue = value
    '        'Me.sourcePic.Left = 30 + (aColorBox.TabIndex * 16)
    '        Me.setStep(1)
    '    Else
    '        If Not aColorBox.TabIndex = Me.SourceValue Then
    '            Me.TargetValue = value
    '            Me.setStep(2)
    '        End If
    '        'Me.targetPic.Left = 30 + (aColorBox.TabIndex * 16)
    '    End If

    'End Sub

    
    
    Private Sub UndoButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoButton.Click
        'Me.undo_SorceColor = sourceColor.Clone
        'Me.undo_TargetColor = targetColor.Clone

        If Me._type = DIALOG_MODE.COPY Then
            'copy
            'Me.PaletteColors.Colors.Item(Me.undo_TargetColor.id) = Me.undo_TargetColor.Clone
            Me.workPalette.SetColor(Me.undo_TargetColor.Index, Me.undo_TargetColor.Clone)

        Else
            'change
            Me.workPalette.SetColor(Me.undo_SourceColor.Index, Me.undo_SourceColor.Clone)
            Me.workPalette.SetColor(Me.undo_TargetColor.Index, Me.undo_TargetColor.Clone)

            'Me.PaletteColors.Colors.Item(Me.undo_SourceColor.id) = Me.undo_SourceColor.Clone
            'Me.PaletteColors.Colors.Item(Me.undo_TargetColor.id) = Me.undo_TargetColor.Clone

        End If

        'Me.setStep(0)

        RedrawPalette()
        UndoButton.Enabled = False

    End Sub



    Private Sub ColorBox_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        Dim aButton As Button = sender
        aButton.DoDragDrop(CStr(aButton.TabIndex), DragDropEffects.Copy) ', DragDropEffects.Move)
    End Sub



    Private Sub ColorBox_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs)
        Dim aButton As Button = sender

        Dim targetColor As Integer = CInt(aButton.TabIndex)
        Dim sourceColor As Integer = CInt(e.Data.GetData(DataFormats.Text).ToString)

        If Me._type = DIALOG_MODE.COPY Then
            CopyColor(sourceColor, targetColor)
        Else
            ' change
            ChangeColor(sourceColor, targetColor)
        End If

    End Sub



    Private Sub ColorBox_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs)
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub


    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.palette.SetPalette(Me.workPalette)
        Me.Close()
    End Sub


End Class
