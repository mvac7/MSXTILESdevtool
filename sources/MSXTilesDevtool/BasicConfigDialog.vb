Imports System.Windows.Forms

Public Class BasicConfigDialog

    Public Property StartingLine() As Integer
        Get
            Return CInt(StartingLineTextBox.Text)
        End Get
        Set(ByVal value As Integer)
            StartingLineTextBox.Text = CStr(value)
        End Set
    End Property


    Public Property Interval() As Integer
        Get
            Return CInt(IntervalTextBox.Text)
        End Get
        Set(ByVal value As Integer)
            IntervalTextBox.Text = CStr(value)
        End Set
    End Property



    Public Property RemoveZeros() As Boolean
        Get
            Return RZCheckButton.Checked
        End Get
        Set(ByVal value As Boolean)
            RZCheckButton.Checked = value
        End Set
    End Property




    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Exit_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub


End Class
