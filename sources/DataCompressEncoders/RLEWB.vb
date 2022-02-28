
''' <summary>
''' Run-Length Encoding (RLE) WB
''' https://github.com/mvac7/Z80_RLEWB
''' 
''' CD = Control Digit = $80
''' 
''' CD +   0       --> When the value to be written to the output is equal to the Control Digit
''' CD + $FF       --> End - Decompressed until it finds this value.
''' CD +  nn + dd  --> Repeat nn+1 ($02 to $FE) value equivalent to 3 up to 255 repetitions. 
'''                    In dd Is the value to repeat.
''' dd (!= CD)     --> Raw data. Values without repetition. 
''' </summary>
Public Class RLEWB
    Implements iCompressEncoder


    Public ReadOnly Property Name As String Implements iCompressEncoder.Name
        Get
            Return "RLEWB"
        End Get
    End Property


    Public Shadows Const Extension As String = "rlewb"


    Private Const RLEWB_CONTROL As Byte = &H80 '128
    Private Const RLEWB_CODE_CDVAL As Byte = &H0
    Private Const RLEWB_CODE_END As Byte = &HFF


    ''' <summary>
    ''' RLEWB encoder
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Compress(ByVal data() As Byte) As Byte() Implements iCompressEncoder.Compress

        Dim RLEtmpData As New ArrayList
        Dim RLEtmpRaw As New ArrayList
        Dim isEnd As Boolean = False

        Dim num_rep As Byte = 0
        Dim num_raw As Byte = 0
        Dim code_pos As Integer = 0

        Dim position As Integer = 0
        Dim position2 As Integer = 0
        Dim value As Byte

        Do
            value = data(position)
            position2 = position + 1


            Do While position2 < data.Length AndAlso value = data(position2) And num_rep < 254
                num_rep += 1
                position2 += 1
            Loop

            If num_rep > 1 Then
                'only when they are more than 2 repetitions
                'two repeats are considered Raw. This way, 3 bytes are not wasted for two values.
                RLEtmpData.Add(RLEWB_CONTROL)
                RLEtmpData.Add(num_rep)
                RLEtmpData.Add(value)

                position = position2

            ElseIf num_rep = 1 And value = RLEWB_CONTROL Then
                ' When it is the case that the value of the Control Digit is repeated twice, we will use the repetition mechanism.
                ' 3 bytes are wasted instead of 4 (because "CD + 0" is executed twice).
                ' Improvement for the future versions: Use the value 1 in the same way as 0, to repeat the value of the Control Digit twice. Requires modifying the decoder.
                RLEtmpData.Add(RLEWB_CONTROL)
                RLEtmpData.Add(num_rep) '=1
                RLEtmpData.Add(RLEWB_CONTROL) 'delete this line for RLEWB v1.1

                position = position2
            Else
                ' write raw value
                If value = RLEWB_CONTROL Then
                    ' $80 , 0
                    RLEtmpData.Add(RLEWB_CONTROL)
                    RLEtmpData.Add(RLEWB_CODE_CDVAL)
                Else
                    ' raw
                    RLEtmpData.Add(value)
                End If
                position += 1
            End If

            num_rep = 0

        Loop While (position < data.Length)

        RLEtmpData.Add(RLEWB_CONTROL)
        RLEtmpData.Add(RLEWB_CODE_END) ' end mark

        Return RLEtmpData.ToArray(GetType(Byte))

    End Function



    ''' <summary>
    ''' RLEWB decoder
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    Public Function Decompress(ByVal data() As Byte) As Byte()

        Dim tmpData As New ArrayList
        Dim value As Byte
        Dim code As Byte
        Dim dataPointer As Integer = 0

        While True
            value = data(dataPointer)
            If value = RLEWB_CONTROL Then
                dataPointer += 1
                code = data(dataPointer)
                If code = RLEWB_CODE_END Then
                    Exit While
                ElseIf code = RLEWB_CODE_CDVAL Then
                    'the data is equal to the value used as Control Digit.
                    tmpData.Add(RLEWB_CONTROL)

                    'RLEWB v1.1
                    'ElseIf code = 1 Then
                    '    tmpData.Add(RLEWB_CONTROL)
                    '    tmpData.Add(RLEWB_CONTROL)

                Else
                    ' repeated value
                    dataPointer += 1
                    value = data(dataPointer)
                    For i = 0 To code
                        tmpData.Add(value)
                    Next
                End If
            Else
                tmpData.Add(value)

            End If

            dataPointer += 1

        End While

        Return tmpData.ToArray(GetType(Byte))

    End Function


End Class
