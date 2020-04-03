Public Class RLE

    Private Const RLEWB_CONTROL As Byte = 128

    ''' <summary>
    ''' Run-Length Encoding (RLE) BASIC
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetRLE(ByVal data() As Byte) As Byte()
        Dim RLEtmpData As New ArrayList
        Dim RLEoutputData() As Byte
        Dim isEnd As Boolean = False
        Dim repetition As Byte = 0
        Dim position As Integer = 0
        Dim value As Byte
        'Dim nextValue As Byte

        Do
            'If position > data.Length Then
            '    RLEtmpData.Add(0) ' marca el final con un 0
            '    Exit Do
            'End If
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

        RLEtmpData.Add(0) ' marca de final (0)

        ReDim RLEoutputData(RLEtmpData.Count - 1)

        For i As Integer = 0 To RLEtmpData.Count - 1
            RLEoutputData(i) = RLEtmpData.Item(i)
        Next

        Return RLEoutputData


    End Function


    ''' <summary>
    ''' Run-Length Encoding (RLE)
    ''' similar to WonderBoy (SMS)
    ''' http://www.smspower.org/Development/Compression#WonderBoyRLE
    ''' $80 nn dd            ; run of n consecutive identical bytes ($1>$FE), value dd
    ''' $80 $80              ; zero value
    ''' $80 $FF              ; end of data block
    ''' any other value      ; raw data  
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetRLE_WB(ByVal data() As Byte) As Byte()
        Dim RLEtmpData As New ArrayList
        Dim RLEtmpRaw As New ArrayList
        Dim RLEoutputData() As Byte
        Dim isEnd As Boolean = False

        Dim num_rep As Byte = 0
        Dim num_raw As Byte = 0
        Dim code_pos As Integer = 0

        Dim position As Integer = 0
        Dim position2 As Integer = 0
        Dim value As Byte
        'Dim nextValue As Byte
        Dim valueRAW As Boolean

        Do
            value = data(position)
            position2 = position + 1


            Do While position2 < data.Length AndAlso value = data(position2) And num_rep < 254
                'Do While position2 < data.Length AndAlso value = data(position2) And num_rep < 253
                num_rep += 1
                position2 += 1
                'If position2 >= data.Length Then
                '    Exit Do
                'End If
            Loop

            If num_rep > 1 Then
                'solo a partir de 2 repeticiones
                RLEtmpData.Add(RLEWB_CONTROL)
                RLEtmpData.Add(num_rep) '1 repetición no se usa. asi se consigue ir de 2 a 255
                'RLEtmpData.Add(num_rep + 1)
                RLEtmpData.Add(value)

                position = position2
                valueRAW = False

            Else
                ' write raw value

                If value = 128 Then
                    ' $80 , 0
                    RLEtmpData.Add(RLEWB_CONTROL)
                    RLEtmpData.Add(0)
                Else
                    ' raw
                    RLEtmpData.Add(value)
                End If
                position += 1
                valueRAW = True
            End If

            num_rep = 0

        Loop While (position < data.Length)

        RLEtmpData.Add(128)
        RLEtmpData.Add(255) ' marca de final

        ReDim RLEoutputData(RLEtmpData.Count - 1)

        For i As Integer = 0 To RLEtmpData.Count - 1
            RLEoutputData(i) = RLEtmpData.Item(i)
        Next

        Return RLEoutputData

    End Function



    'Public Function GetRLE_WB(ByVal data() As Byte) As Byte()
    '    Dim RLEtmpData As New ArrayList
    '    Dim RLEtmpRaw As New ArrayList
    '    Dim RLEoutputData() As Byte
    '    Dim isEnd As Boolean = False

    '    Dim num_rep As Byte = 0
    '    Dim num_raw As Byte = 0
    '    Dim code_pos As Integer = 0

    '    Dim position As Integer = 0
    '    Dim position2 As Integer = 0
    '    Dim value As Byte
    '    'Dim nextValue As Byte
    '    Dim valueRAW As Boolean

    '    Do
    '        value = data(position)
    '        position2 = position + 1


    '        Do While position2 < data.Length AndAlso value = data(position2) And num_rep < 253
    '            'Do While position2 < data.Length AndAlso value = data(position2) And num_rep < 253
    '            num_rep += 1
    '            position2 += 1
    '            'If position2 >= data.Length Then
    '            '    Exit Do
    '            'End If
    '        Loop

    '        If num_rep > 1 Then
    '            'solo a partir de 2 repeticiones
    '            RLEtmpData.Add(RLEWB_CONTROL)
    '            RLEtmpData.Add(num_rep + 1) '1 repetición no se usa. asi se consigue ir de 2 a 255
    '            'RLEtmpData.Add(num_rep + 1)
    '            RLEtmpData.Add(value)

    '            position = position2
    '            valueRAW = False

    '        ElseIf num_rep = 1 Then
    '            RLEtmpData.Add(127)
    '            'RLEtmpData.Add(num_rep) '1 repetición no se usa. asi se consigue ir de 2 a 255
    '            RLEtmpData.Add(value)

    '            position = position2
    '            valueRAW = False
    '        Else
    '            ' write raw value

    '            If value = 128 Then
    '                ' $80 , 0
    '                RLEtmpData.Add(RLEWB_CONTROL)
    '                RLEtmpData.Add(0)
    '            ElseIf value = 127 Then
    '                ' $80 , 0
    '                RLEtmpData.Add(RLEWB_CONTROL)
    '                RLEtmpData.Add(1)
    '            Else
    '                ' raw
    '                RLEtmpData.Add(value)
    '            End If
    '            position += 1
    '            valueRAW = True
    '        End If

    '        num_rep = 0

    '    Loop While (position < data.Length)

    '    RLEtmpData.Add(128)
    '    RLEtmpData.Add(255) ' marca de final

    '    ReDim RLEoutputData(RLEtmpData.Count - 1)

    '    For i As Integer = 0 To RLEtmpData.Count - 1
    '        RLEoutputData(i) = RLEtmpData.Item(i)
    '    Next

    '    Return RLEoutputData

    'End Function




    


    'Public Function GetRLE_WBOLD(ByVal data() As Byte) As Byte()
    '    Dim RLEtmpData As New ArrayList
    '    Dim RLEtmpRaw As New ArrayList
    '    Dim RLEoutputData() As Byte
    '    Dim isEnd As Boolean = False

    '    Dim num_rep As Byte = 0
    '    Dim num_raw As Byte = 0
    '    Dim code_pos As Integer = 0

    '    Dim position As Integer = 0
    '    Dim position2 As Integer = 0
    '    Dim value As Byte
    '    'Dim nextValue As Byte
    '    Dim valueRAW As Boolean

    '    Do
    '        value = data(position)
    '        position2 = position + 1


    '        Do While position2 < data.Length AndAlso value = data(position2) And num_rep < 253
    '            num_rep += 1
    '            position2 += 1
    '            'If position2 >= data.Length Then
    '            '    Exit Do
    '            'End If
    '        Loop

    '        If num_rep > 1 Then
    '            'solo a partir de 2 repeticiones
    '            RLEtmpData.Add(0)
    '            RLEtmpData.Add(num_rep + 1)
    '            RLEtmpData.Add(value)

    '            'If num_rep + 1 = 255 Then '########################################################## TEST
    '            '    num_rep = num_rep
    '            'End If

    '            position = position2
    '            valueRAW = False

    '        Else
    '            ' write raw value

    '            If value = 0 Then
    '                ' 2 bytes = 0 , 0
    '                RLEtmpData.Add(0)
    '            End If
    '            RLEtmpData.Add(value)
    '            position += 1
    '            valueRAW = True
    '        End If

    '        num_rep = 0

    '    Loop While (position < data.Length)

    '    'If position < data.Length Then
    '    '    value = data(position)
    '    '    If value = 0 Then
    '    '        RLEtmpData.Add(0)
    '    '    End If
    '    '    RLEtmpData.Add(value)
    '    'End If

    '    ' ultimo valor
    '    'If valueRAW Then
    '    '    value = data(position)
    '    '    If value = 0 Then
    '    '        RLEtmpData.Add(0)
    '    '    End If
    '    '    RLEtmpData.Add(value)
    '    'End If

    '    RLEtmpData.Add(0)
    '    RLEtmpData.Add(255) ' marca de final (0)

    '    ReDim RLEoutputData(RLEtmpData.Count - 1)

    '    For i As Integer = 0 To RLEtmpData.Count - 1
    '        RLEoutputData(i) = RLEtmpData.Item(i)
    '    Next

    '    Return RLEoutputData

    'End Function




    'Private Function GetRLE3(ByVal data() As Byte) As Byte()
    '    Dim RLEtmpData As New ArrayList
    '    Dim RLEtmpRaw As New ArrayList
    '    Dim RLEoutputData() As Byte
    '    Dim isEnd As Boolean = False

    '    Dim num_rep As Byte = 0
    '    Dim num_raw As Byte = 0
    '    Dim code_pos As Integer = 0

    '    Dim position As Integer = 0
    '    Dim value As Byte
    '    'Dim nextValue As Byte

    '    Do
    '        'If position > data.Length Then
    '        '    RLEtmpData.Add(0) ' marca el final con un 0
    '        '    Exit Do
    '        'End If
    '        value = data(position)
    '        If value = data(position + 1) Then
    '            If num_raw = 1 Then
    '                num_raw = 0
    '                RLEtmpRaw.Clear()
    '            ElseIf num_raw > 1 Then
    '                'RLEtmpRaw.Add(value)
    '                RLEtmpData.Add(num_raw + 127)
    '                RLEtmpData.AddRange(RLEtmpRaw)
    '                num_raw = 0
    '                RLEtmpRaw.Clear()
    '            End If
    '            num_rep += 1 ' cuento las repeticiones
    '            If num_rep = 126 Then ' control del valor maximo de repeticiones
    '                RLEtmpData.Add(num_rep)
    '                RLEtmpData.Add(value)
    '                num_rep = 0
    '            End If
    '        Else
    '            ' es raw
    '            If num_rep > 0 Then
    '                RLEtmpData.Add(num_rep + 1) ' escribo num repeticiones 
    '                RLEtmpData.Add(value) ' + valor
    '                num_rep = 0 ' y pongo el contador de repeticiones a cero
    '            End If
    '            num_raw += 1 ' cuento las repeticiones
    '            RLEtmpRaw.Add(value)
    '            If num_raw = 127 Then ' control del valor maximo de repeticiones
    '                RLEtmpData.Add(num_raw + 127)
    '                RLEtmpData.AddRange(RLEtmpRaw)
    '                num_raw = 0
    '                RLEtmpRaw.Clear()
    '            End If
    '        End If
    '        position += 1
    '    Loop While (position < data.Length - 1)

    '    ' comprueba el ultimo valor
    '    value = data(position)
    '    If value = data(position - 1) Then

    '        If num_raw = 1 Then
    '            num_raw = 0
    '            RLEtmpRaw.Clear()
    '        ElseIf num_raw > 1 Then
    '            'RLEtmpRaw.Add(value)
    '            RLEtmpData.Add(num_raw + 127)
    '            RLEtmpData.AddRange(RLEtmpRaw)
    '        End If
    '        num_rep += 1 ' cuento las repeticiones

    '        RLEtmpData.Add(num_rep)
    '        RLEtmpData.Add(value)
    '        num_rep = 0
    '    Else
    '        ' es raw
    '        If num_rep > 0 Then
    '            RLEtmpData.Add(num_rep + 1) ' escribo num repeticiones 
    '            RLEtmpData.Add(value) ' + valor
    '            num_rep = 0 ' y pongo el contador de repeticiones a cero
    '        End If
    '        num_raw += 1 ' cuento las repeticiones
    '        RLEtmpRaw.Add(value)

    '        RLEtmpData.Add(num_raw + 127)
    '        RLEtmpData.AddRange(RLEtmpRaw)

    '    End If

    '    RLEtmpData.Add(0) ' marca de final (0)

    '    ReDim RLEoutputData(RLEtmpData.Count - 1)

    '    For i As Integer = 0 To RLEtmpData.Count - 1
    '        RLEoutputData(i) = RLEtmpData.Item(i)
    '    Next

    '    Return RLEoutputData

    'End Function


End Class
