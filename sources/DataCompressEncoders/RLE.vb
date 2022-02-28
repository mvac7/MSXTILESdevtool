Public Class RLE
    Implements iCompressEncoder


    Public ReadOnly Property Name As String Implements iCompressEncoder.Name
        Get
            Return "RLE"
        End Get
    End Property


    Public Shadows Const Extension As String = "rle"


    Private Const RLE_END As Byte = 0



    ''' <summary>
    ''' Run-Length Encoding (RLE) BASIC
    ''' 
    ''' https://en.wikipedia.org/wiki/Run-length_encoding
    ''' 
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Compress(ByVal data() As Byte) As Byte() Implements iCompressEncoder.Compress
        Dim RLEtmpData As New ArrayList
        Dim RLEoutputData() As Byte
        Dim repetition As Byte = 0
        Dim position As Integer = 0
        Dim value As Byte

        Do
            value = data(position)
            If value = data(position + 1) Then
                repetition += 1 ' cuento las repeticiones
                If repetition = 255 Then ' control del valor maximo de repeticiones
                    RLEtmpData.Add(255)
                    RLEtmpData.Add(value)
                    repetition = 0
                End If
            Else
                ' no se repite mas, 
                RLEtmpData.Add(repetition + 1) ' escribo num repeticiones 
                RLEtmpData.Add(value) ' + valor
                repetition = 0 ' y pongo el contador de repeticiones a cero
                If position = data.Length - 2 Then ' si falta el ultimo valor
                    RLEtmpData.Add(1)
                    RLEtmpData.Add(data(data.Length - 1))
                End If
            End If
            position += 1
        Loop While (position < data.Length - 1)

        If repetition > 0 Then 'hay un valor que no se ha escrito
            RLEtmpData.Add(repetition + 1)
            RLEtmpData.Add(value)
        End If

        RLEtmpData.Add(RLE_END) ' marca de final (0)

        ReDim RLEoutputData(RLEtmpData.Count - 1)

        For i As Integer = 0 To RLEtmpData.Count - 1
            RLEoutputData(i) = RLEtmpData.Item(i)
        Next

        Return RLEoutputData

    End Function


End Class
