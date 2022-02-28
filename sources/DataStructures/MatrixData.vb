Public Class MatrixData

    Public Lines As New ArrayList


    Public ReadOnly Property Count As Integer
        Get
            Return Me.Lines.Count - 1
        End Get
    End Property


    Public Property Item(y As Integer) As Boolean()
        Get
            Return Me.Lines.Item(y)
        End Get
        Set(ByVal value As Boolean())
            Me.Lines.Item(y) = value
        End Set
    End Property


    Public Sub New()

    End Sub


    Public Sub New(size As Integer)
        For y As Integer = 0 To size
            Dim pixelsLine(size) As Boolean
            For x As Integer = 0 To size
                pixelsLine(x) = False
            Next
            Add(pixelsLine)
        Next
    End Sub


    Public Function Clone() As MatrixData
        Dim tmpMatrixData As New MatrixData

        For y As Integer = 0 To Me.Count
            tmpMatrixData.Add(Me.Lines.Item(y).Clone())
        Next

        Return tmpMatrixData
    End Function



    Public Sub Add(ByVal item() As Boolean)
        Me.Lines.Add(item)
    End Sub




    Public Sub Clear()
        For y As Integer = 0 To Me.Count
            For x As Integer = 0 To Me.Count
                Lines.Item(y)(x) = False
            Next
        Next
    End Sub



End Class
