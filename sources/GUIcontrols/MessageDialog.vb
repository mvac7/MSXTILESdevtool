Imports System.Windows.Forms

Public Class MessageDialog


    Private _type As DIALOG_TYPE = DIALOG_TYPE.ALERT

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

    End Sub


    Public Sub New(ByVal tittle As String, ByVal aMessage As String, ByVal msgType As DIALOG_TYPE)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.Text = tittle
        Me.MessageLabel.Text = aMessage
        Me._type = msgType
    End Sub



    Private Sub MessageDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
        Select Case Me._type
            Case DIALOG_TYPE.ABOUT
                Me.ico64PictureBox.Image = Me.ico64ImageList.Images.Item(1)
            Case DIALOG_TYPE.HELP
                Me.ico64PictureBox.Image = Me.ico64ImageList.Images.Item(2)
            Case DIALOG_TYPE.OK_CANCEL
                Me.ico64PictureBox.Image = Me.ico64ImageList.Images.Item(0)

            Case DIALOG_TYPE.YES_NO
                Me.ico64PictureBox.Image = Me.ico64ImageList.Images.Item(0)
                Me.OK_Button.Text = "YES"
                Me.Cancel_Button.Text = "No"

            Case Else
                Me.ico64PictureBox.Image = Me.ico64ImageList.Images.Item(0)

        End Select

        If Me._type < 3 Then
            Me.OK_Button.Location = New Point(268, Me.OK_Button.Location.Y)
        Else
            Me.Cancel_Button.Visible = True
        End If

    End Sub




    Overloads Function ShowDialog(ByRef owner As IWin32Window, ByVal tittle As String, ByVal aMessage As String, ByVal msgType As DIALOG_TYPE) As DialogResult

        Me.Text = tittle
        Me.MessageLabel.Text = aMessage
        Me._type = msgType

        Return Me.ShowDialog(owner)

    End Function

    'End Sub



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


End Class
