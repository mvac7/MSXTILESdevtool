Imports System.Windows.Forms

Public Class MessageDialog


    Private _type As DIALOG_TYPE = DIALOG_TYPE.ALERT

    Private _posX_button As Integer



    Public Enum DIALOG_TYPE As Integer
        ALERT
        ABOUT
        HELP
        YES_NO
        OK_CANCEL
    End Enum



    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me._posX_button = Me.OK_Button.Location.X

    End Sub



    Public Sub New(ByVal tittle As String, ByVal aMessage As String, ByVal msgType As DIALOG_TYPE)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.Text = tittle
        Me.MessageLabel.Text = aMessage
        Me._type = msgType

        Me._posX_button = Me.OK_Button.Location.X

    End Sub



    Private Sub MessageDialog_Load(sender As Object, e As EventArgs) Handles Me.Load

        'TMS9918A Color Palette
        'http://bifi.msxnet.org/msxnet/tech/tms9918a.txt
        Me.BackColor = System.Drawing.Color.FromArgb(204, 204, 204) '14 Gray
        'Me.OK_Button.BackColor = System.Drawing.Color.FromArgb(94, 220, 120) '3 Light green
        'Me.Cancel_Button.BackColor = System.Drawing.Color.FromArgb(255, 121, 120) '9 Light red

        Select Case Me._type
            Case DIALOG_TYPE.ABOUT
                Me.ico64PictureBox.Image = Me.ico64ImageList.Images.Item(1)
                Me.OK_Button.ImageIndex = 0 'Ok

            Case DIALOG_TYPE.HELP
                Me.ico64PictureBox.Image = Me.ico64ImageList.Images.Item(2)
                Me.OK_Button.ImageIndex = 0 'Ok

            Case DIALOG_TYPE.YES_NO
                Me.ico64PictureBox.Image = Me.ico64ImageList.Images.Item(0)
                Me.OK_Button.ImageIndex = 1 'Yes
                Me.Cancel_Button.ImageIndex = 1 'No

            Case DIALOG_TYPE.OK_CANCEL
                Me.ico64PictureBox.Image = Me.ico64ImageList.Images.Item(0)
                Me.OK_Button.ImageIndex = 0 'Ok
                Me.Cancel_Button.ImageIndex = 0 'Cancel

            Case Else
                Me.ico64PictureBox.Image = Me.ico64ImageList.Images.Item(0)
                Me.OK_Button.ImageIndex = 0 'Ok

        End Select

        If Me._type < 3 Then
            'Me.OK_Button.Location = New Point(Me.Width - Me.OK_Button.Width - 16, Me.OK_Button.Location.Y)
            Me.Cancel_Button.Visible = False
        Else
            'Me.OK_Button.Location = New Point(Me._posX_button, Me.OK_Button.Location.Y)
            Me.Cancel_Button.Visible = True
        End If

        Me.ActiveControl = Nothing

    End Sub



    Overloads Function ShowDialog(ByRef owner As IWin32Window, ByVal tittle As String, ByVal aMessage As String, ByVal msgType As DIALOG_TYPE) As DialogResult

        Me.Text = tittle
        Me.MessageLabel.Text = aMessage
        Me._type = msgType

        Me.Select()

        Return Me.ShowDialog(owner)

    End Function



    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Me._type = DIALOG_TYPE.YES_NO Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Yes
        Else
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End If

        Me.Close()
    End Sub



    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        If Me._type = DIALOG_TYPE.YES_NO Then
            Me.DialogResult = System.Windows.Forms.DialogResult.No
        Else
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
        Me.Close()
    End Sub



    Private Sub MessageDialog_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me._type = DIALOG_TYPE.YES_NO Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Yes
            Else
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If

            Me.Close()
        End If

        If e.KeyCode = Keys.Escape Then
            If Me._type = DIALOG_TYPE.YES_NO Then
                Me.DialogResult = System.Windows.Forms.DialogResult.No
            Else
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            End If

            Me.Close()
        End If

    End Sub



End Class
