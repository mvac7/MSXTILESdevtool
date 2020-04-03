Public Class DataItem

    Public label As String
    Public comment As ArrayList
    Public data As Byte()

    Public Sub New(ByVal _label As String, ByVal _comment As ArrayList, ByVal _data As Byte())
        Me.label = _label
        Me.comment = _comment
        Me.data = _data
    End Sub
End Class
