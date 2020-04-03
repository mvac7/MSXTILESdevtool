Imports System.Windows.Forms


Public Class ColorWinSelector

    Private PaletteColors As New MSXpalette

    Private tempPaletteColors As MSXpalette

    Private _step As Integer = 0
    Private _type As Integer = 0

    Public SourceValue As Integer = 0
    Public TargetValue As Integer = 0

    Private PaletteGfxData As New ArrayList

    'Private undo_lastOperation As Integer
    Private undo_SourceColor As MSXcolor
    Private undo_TargetColor As MSXcolor



    'Private _type As Integer = 0 ' 0=copy, 1=change

    'Public Property type() As Integer
    '    Get
    '        Return _type
    '    End Get
    '    Set(ByVal value As Integer)
    '        Me._type = value
    '    End Set
    'End Property


    Public Sub New(ByVal type As Integer, ByVal _PaletteColors As MSXpalette)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        Me.PaletteColors = _PaletteColors

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        GeneratePalette()

        setMode(type)
        setStep(0)

    End Sub


    Private Sub setMode(ByVal value As Integer)
        Me._type = value
        If value = 0 Then
            ' copy
            TitleLabel.Text = "Copy"



        Else
            ' change
            TitleLabel.Text = "Change"


        End If

    End Sub


    Private Sub setStep(ByVal value As Integer)
        Me._step = value
        If value = 0 Then
            Me.MessageLabel.Text = "Select source color."
            Me.targetPic.Visible = False

        ElseIf value = 1 Then
            Me.MessageLabel.Text = "Select target color."
            Me.targetPic.Visible = True

        Else
            If Me._type = 0 Then
                'copy
                CopyColor(Me.SourceValue, Me.TargetValue)

            Else
                'change
                ChangeColor(Me.SourceValue, Me.TargetValue)
            End If

            'If Me._type = 0 Then
            '    Me.MessageLabel.Text = "Press Ok to copy."
            'Else
            '    Me.MessageLabel.Text = "Press Ok to change."
            'End If

        End If
    End Sub


    'Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.DialogResult = System.Windows.Forms.DialogResult.OK
    '    Me.Close()
    'End Sub

    Public Sub CopyColor(ByVal _sourceValue As Integer, ByVal _targetValue As Integer)

        Dim sourceColor As MSXcolor = Me.PaletteColors.Colors.Item(_sourceValue)
        Dim targetColor As MSXcolor = Me.PaletteColors.Colors.Item(_targetValue)

        Me.undo_SourceColor = sourceColor.Clone
        Me.undo_TargetColor = targetColor.Clone
        UndoButton.Enabled = True


        'copy
        targetColor = sourceColor.Clone
        'targetColor.Red = sourceColor.Red
        'targetColor.Green = sourceColor.Green
        'targetColor.Blue = sourceColor.Blue
        'targetColor.RGBColor = sourceColor.RGBColor



        Me.setStep(0)

        RedrawPalette()
        'Me.DialogResult = System.Windows.Forms.DialogResult.OK
        'Me.Close()
    End Sub


    Public Sub ChangeColor(ByVal _sourceValue As Integer, ByVal _targetValue As Integer)

        Dim sourceColor As MSXcolor = Me.PaletteColors.Colors.Item(_sourceValue)
        Dim targetColor As MSXcolor = Me.PaletteColors.Colors.Item(_targetValue)
        Dim tmpColor As MSXcolor = Me.PaletteColors.Colors.Item(_targetValue).clone

        Me.undo_SourceColor = sourceColor.Clone
        Me.undo_TargetColor = targetColor.Clone
        UndoButton.Enabled = True


        targetColor = sourceColor.Clone
        'targetColor.Red = sourceColor.Red
        'targetColor.Green = sourceColor.Green
        'targetColor.Blue = sourceColor.Blue
        'targetColor.RGBColor = sourceColor.RGBColor

        sourceColor = tmpColor.Clone
        'sourceColor.Red = tmpColor.Red
        'sourceColor.Green = tmpColor.Green
        'sourceColor.Blue = tmpColor.Blue
        'sourceColor.RGBColor = tmpColor.RGBColor


        Me.setStep(0)

        RedrawPalette()
        'Me.DialogResult = System.Windows.Forms.DialogResult.OK
        'Me.Close()
    End Sub



    Private Sub OkButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OkButton.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub


    Private Sub CancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitButton.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Function getColorBox(ByVal id As Integer, ByVal x As Integer, ByVal y As Integer, ByVal aColor As Color) As System.Windows.Forms.Control
        Dim ColorBox As New PictureBox

        Me.SuspendLayout()
        ColorBox.BackColor = aColor
        ColorBox.Location = New System.Drawing.Point(x, y)
        ColorBox.Name = CStr(id)
        ColorBox.Size = New System.Drawing.Size(15, 15)
        ColorBox.TabIndex = id
        ColorBox.TabStop = False
        Me.ResumeLayout(False)

        Me.ToolTip1.SetToolTip(ColorBox, "Color " + CStr(id))

        Return ColorBox
    End Function


    Private Sub GeneratePalette()
        Dim ColorBox As System.Windows.Forms.PictureBox
        Dim contador As Integer = 0

        For Each aColor As MSXcolor In PaletteColors.Colors.Values

            ColorBox = getColorBox(contador, contador * 16, 0, PaletteColors.getRGB(aColor)) '.RGBColor)

            Me.PalettePanel.Controls.Add(ColorBox)
            Me.PaletteGfxData.Add(ColorBox)
            AddHandler ColorBox.Click, AddressOf Me.PalettePanel_Click
            AddHandler ColorBox.MouseEnter, AddressOf Me.PalettePanel_MouseEnter

            contador += 1
        Next

    End Sub


    Private Sub RedrawPalette()
        Dim ColorBox As System.Windows.Forms.PictureBox
        Dim contador As Integer = 0

        For Each aColor As MSXcolor In PaletteColors.Colors.Values

            ColorBox = Me.PaletteGfxData.Item(aColor.id)

            ColorBox.BackColor = PaletteColors.getRGB(aColor) '.RGBColor

        Next

        Me.Refresh()

    End Sub



    Private Sub PalettePanel_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Handles PalettePanel.MouseEnter
        Dim aColorBox As PictureBox = CType(sender, PictureBox)

        If Me._step = 0 Then
            Me.sourcePic.Left = 30 + (aColorBox.TabIndex * 16)
        ElseIf Me._step = 1 Then
            If Not aColorBox.TabIndex = Me.SourceValue Then
                Me.targetPic.Left = 30 + (aColorBox.TabIndex * 16)
            End If
        End If

    End Sub


    Private Sub PalettePanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Handles sourcePic.Click
        Dim aColorBox As PictureBox = CType(sender, PictureBox)

        Dim value As Integer = aColorBox.TabIndex

        If value = 0 Then
            Exit Sub
        End If

        If Me._step = 0 Then
            Me.SourceValue = value
            'Me.sourcePic.Left = 30 + (aColorBox.TabIndex * 16)
            Me.setStep(1)
        Else
            If Not aColorBox.TabIndex = Me.SourceValue Then
                Me.TargetValue = value
                Me.setStep(2)
            End If
            'Me.targetPic.Left = 30 + (aColorBox.TabIndex * 16)
        End If

    End Sub

    
    
    Private Sub UndoButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoButton.Click
        'Me.undo_SorceColor = sourceColor.Clone
        'Me.undo_TargetColor = targetColor.Clone

        If Me._type = 0 Then
            'copy
            Me.PaletteColors.Colors.Item(Me.undo_TargetColor.id) = Me.undo_TargetColor.Clone

        Else
            'change
            Me.PaletteColors.Colors.Item(Me.undo_SourceColor.id) = Me.undo_SourceColor.Clone
            Me.PaletteColors.Colors.Item(Me.undo_TargetColor.id) = Me.undo_TargetColor.Clone

        End If

        'Me.setStep(0)

        RedrawPalette()
        UndoButton.Enabled = False

    End Sub


    
End Class
