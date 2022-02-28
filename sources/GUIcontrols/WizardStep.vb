Public Class WizardStep

    Public Position As Integer

    Public Type As STEP_TYPE

    Public Title As String = ""

    Public TextValue As String = ""
    Public defTextValue As String = ""

    Public Selected As Integer
    Public defSelected As Integer

    Public ItemsList As SortedList

    Public Checked As New SortedList
    Public defChecked As Boolean



    Public Shadows Enum STEP_TYPE As Integer
        TEXT
        FILEPATH
        FOLDERPATH
        RADIOLIST
        COMBOLIST
        CHECKLIST
    End Enum



    ''' <summary>
    ''' for Text, Path, folder
    ''' </summary>
    ''' <param name="_Type"></param>
    ''' <param name="_Title"></param>
    ''' <param name="_textValue"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _position As Integer, ByVal _Type As STEP_TYPE, ByVal _Title As String, ByVal _textValue As String)
        Me.Position = _position
        Me.Type = _Type
        Me.Title = _Title
        Me.defTextValue = _textValue
        Me.TextValue = Me.defTextValue
    End Sub



    ''' <summary>
    ''' for Lists
    ''' </summary>
    ''' <param name="_Type"></param>
    ''' <param name="_Title"></param>
    ''' <param name="_itemsList"></param>
    ''' <param name="_selected"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _position As Integer, ByVal _Type As STEP_TYPE, ByVal _Title As String, ByVal _itemsList As SortedList, ByVal _selected As Integer)
        Me.Position = _position
        Me.Type = _Type
        Me.Title = _Title

        Me.ItemsList = _itemsList
        Me.Selected = _selected
        Me.defSelected = Me.Selected

    End Sub



    ''' <summary>
    ''' for checkbox list
    ''' </summary>
    ''' <param name="_position"></param>
    ''' <param name="_Type"></param>
    ''' <param name="_Title"></param>
    ''' <param name="_itemsList"></param>
    ''' <param name="_defChecked"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _position As Integer, ByVal _Type As STEP_TYPE, ByVal _Title As String, ByVal _itemsList As SortedList, ByVal _defChecked As Boolean)
        Me.Position = _position
        Me.Type = _Type
        Me.Title = _Title

        Me.ItemsList = _itemsList
        Me.defChecked = _defChecked

        If Me.Type = STEP_TYPE.CHECKLIST Then

            For i As Integer = 0 To Me.ItemsList.Count
                Me.Checked.Add(i, Me.defChecked)
            Next

            'Else

        End If

    End Sub

End Class
