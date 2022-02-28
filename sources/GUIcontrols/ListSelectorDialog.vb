Imports System.Windows.Forms

Public Class ListSelectorDialog

    Private isAllOption As Boolean

    Public ReadOnly Property SelectedItem() As String
        Get
            Return Me.ListSelectorComboBox.SelectedItem
        End Get
    End Property


    Public ReadOnly Property SelectedIndex() As Integer
        Get
            Return Me.ListSelectorComboBox.SelectedIndex
        End Get
    End Property



    Public Sub New(ByVal title As String, ByVal label As String, ByVal list As ArrayList)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        If Not title = "" Then
            Me.Text = title
        End If
        Me.EntryLabel.Text = label

        If list.Count > 0 Then
            For Each mapName As String In list
                Me.ListSelectorComboBox.Items.Add(mapName) 'CStr(i) + " - " + Me._MapsProject.GetMap(i - 1).Name)
            Next
            Me.ListSelectorComboBox.SelectedIndex = 0
        End If

    End Sub



    Public Sub New(ByVal title As String, ByVal label As String, ByVal FirstItem As String, ByVal list As ArrayList)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        If Not title = "" Then
            Me.Text = title
        End If
        Me.EntryLabel.Text = label

        Me.ListSelectorComboBox.Items.Add(FirstItem)
        If list.Count > 0 Then
            For Each mapName As String In list
                Me.ListSelectorComboBox.Items.Add(mapName) 'CStr(i) + " - " + Me._MapsProject.GetMap(i - 1).Name)
            Next
        End If
        Me.ListSelectorComboBox.SelectedIndex = 0

    End Sub


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub


    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


End Class
