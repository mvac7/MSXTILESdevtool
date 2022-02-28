''' <summary>
''' Pletter v0.5c1
''' 
''' XL2S Entertainment
''' http://www.xl2s.tk/
''' 
''' This is a LZ77-style compressor, the compression as bits can be slow
''' in comparison with RLE (more if you're uncompressing direct to VRAM
''' because it has to read VRAM) but always wins in space reduction.
''' 
''' Revision date: Apr/19/2011. Converted from C++ to C language by Oscar Toledo G.
''' https://github.com/nanochess/Pletter
''' Visual Vasic .net: (Jan/27/2022) Translate to Visual Basic .net by A0rante
''' </summary>
Public Class Pletter
    Implements iCompressEncoder


    Public ReadOnly Property Name As String Implements iCompressEncoder.Name
        Get
            Return "Pletter 0.5c1"
        End Get
    End Property


    Public Shadows Const Extension As String = "plet5"


 Private data() As Byte

    Private maxlen() As UShort = {128, 128 + 128, 512 + 128, 1024 + 128, 2048 + 128, 4096 + 128, 8192 + 128}

    'unsigned varcost[65536];
    Private varcost(65535) As UShort

    Private length As Integer

    Private buf() As Byte
    Private ep As Integer
    Private dp As Integer
    Private p As Integer
    Private e As Integer



    Private Class metadata
        Public reeks As UShort           ' Total times that byte is repeated
        Public cpos(7) As UShort
        Public clen(7) As UShort
    End Class



    Private Class pakdata
        Public cost As UShort
        Public mode As UShort
        Public mlen As UShort
    End Class



    Private metaDatos() As metadata



    Public Sub New()


    End Sub



    Public Function Compress(ByVal dataBloq() As Byte) As Byte()  Implements iCompressEncoder.Compress

        'struct pakdata{} *p[7];
        Dim workPakDatos(6) As Array

        Dim i As Integer
        Dim l As Integer
        Dim minlen As Integer
        Dim minbl As Integer

        ReDim Me.data(dataBloq.Length)
        Array.Copy(dataBloq, Me.data, dataBloq.Length)

        length = Me.data.Length - 1

        Me.data(length) = 0

        ReDim metaDatos(length + 1)
        For i = 0 To length + 1
            metaDatos(i) = New metadata
        Next

        initvarcost()
        createmetadata()

        minlen = length * 1000
        minbl = 0

        'for(i=1;i!=7;++i)
        For i = 1 To 6
            'p[i] = malloc(sizeof(struct pakdata) * (length + 1));
            Dim aPakdata(length + 1) As pakdata

            For o As Integer = 0 To length + 1
                aPakdata(o) = New pakdata
            Next
            workPakDatos(i) = aPakdata.Clone

            l = getlen(workPakDatos(i), i)
            'if (l<minlen && i) <<<<---------------------------------- ???
            If (l < minlen) Then
                minlen = l
                minbl = i
            End If
        Next

        Return getPletterData(workPakDatos(minbl), minbl)

    End Function



    ''' <summary>
    ''' Take note of cost of using a variable number
    ''' </summary>
    Private Sub initvarcost()
        Dim v As Integer = 1
        Dim b As Integer = 1
        Dim r As Integer = 1
        Dim j As Integer

        'Depict a one costs one bit        (0)
        '2-3 costs three bits            (1x0)
        '4-7 costs five bits.          (1x1x0)

        'while (r!=65536)
        While r < 65536

            'for (int j=0;j!=r;++j)
            For j = 0 To r - 1
                varcost(v) = b
                v += 1
            Next

            b += 2
            r *= 2
        End While

    End Sub



    ''' <summary>
    ''' Pre-compresses the source file
    ''' </summary>
    Private Sub createmetadata()

        Dim i As Integer  'Short
        Dim j As UShort
        Dim last() As Integer 'UShort 
        Dim prev() As Integer 'UShort
        Dim r As Integer 'UShort
        Dim t As UShort
        Dim bl As Integer

        Dim value16 As UShort

        Dim md_l As UShort
        Dim md_p As UShort

        'malloc(65536 * sizeof(unsigned int));
        ReDim last(65535)

        'malloc((source_size + 1) * sizeof(unsigned int));
        ReDim prev(length) '+ 1

        'memset(last,-1,65536*sizeof(unsigned));
        For i = 0 To 65535 '65536
            last(i) = -1 '65535 
        Next


        '** For speeding up the search for pairing strings:
        '**
        '** as it advances, prev[byte] points to the string immediately previous
        '** that starts with the same two current bytes, it doesn't matter to link
        '** by individual bytes as each offset needs at least one byte.
        '**
        '** last Is a kind of hash table pointing to each two-byte string found.

        'for (i=0;i!=length;++i)
        For i = 0 To length - 1
            metaDatos(i).cpos(0) = 0
            metaDatos(i).clen(0) = 0
            value16 = data(i) + (data(i + 1) * 256)
            prev(i) = last(value16) 'last(data(i) + (data(i + 1) * 256))
            'last(data(i) + (data(i + 1) * 256)) = i
            last(value16) = i
        Next

        'Counts the bytes repeated from each starting position
        r = -1  '65535 
        t = 0
        'for (i = length - 1; i != -1; --i)
        For i = length - 1 To 0 Step -1 ' 
            If (data(i) = r) Then
                'm[i].reeks = ++t;
                t += 1
                metaDatos(i).reeks = t
            Else
                r = data(i)
                t = 1
                metaDatos(i).reeks = 1
            End If
        Next

        'Now for each possible mode
        'For (Int() bl= 0;bl!=7;++bl)
        For bl = 0 To 6
            'Process the input file
            'for (i=0;i<length;++i)
            For i = 0 To length - 1
                'Dim l As UShort
                'Dim p As UShort

                md_p = i
                If (bl) Then
                    metaDatos(i).clen(bl) = metaDatos(i).clen(bl - 1)
                    metaDatos(i).cpos(bl) = metaDatos(i).cpos(bl - 1)
                    md_p = i - metaDatos(i).cpos(bl)
                End If

                'For each repeated string
                'while ((p = prev[p]) != -1)  ' <<< ------------------------------------------------ ???
                While prev(md_p) >= 0
                    md_p = prev(md_p)
                    If (i - md_p) > maxlen(bl) Then 'Exceeded possible offset?
                        Exit While 'Yes, finish
                    End If
                    md_l = 0
                    'While (data[p + l] == data[i + l] && (i + l) < length)
                    While (i + md_l) < length AndAlso data(md_p + md_l) = data(i + md_l)

                        If (metaDatos(i + md_l).reeks > 1) Then

                            ' if ((j = m[i + l].reeks) > m[p + l].reeks)
                            j = metaDatos(i + md_l).reeks
                            If (j > metaDatos(md_p + md_l).reeks) Then
                                j = metaDatos(md_p + md_l).reeks
                            End If
                            md_l += j
                        Else
                            md_l += 1
                        End If

                    End While

                    If (md_l > metaDatos(i).clen(bl)) Then 'Look for the longest string
                        metaDatos(i).clen(bl) = md_l       'Longitude
                        metaDatos(i).cpos(bl) = i - md_p   'Position (offset)
                    End If

                End While

            Next

        Next

    End Sub



    ''' <summary>
    ''' Get the final size of file with a mode
    ''' </summary>
    ''' <param name="pdata"></param>
    ''' <param name="mode"></param>
    ''' <returns></returns>
    Private Function getlen(ByRef pdata() As pakdata, ByVal mode As Short) As Integer

        Dim i As Integer
        Dim j As UShort
        Dim cc As UShort
        Dim ccc As UShort
        Dim kc As UShort
        Dim kmode As UShort
        Dim kl As UShort

        pdata(length).cost = 0

        'Trick: goes from onwards to backwards, this way can know all
        'possible combinations for compressing.


        'for (i=length-1;i!=-1;--i)
        For i = (length - 1) To 0 Step -1
            kmode = 0
            kl = 0
            kc = 9 + pdata(i + 1).cost

            'Test every size until getting the most short
            j = metaDatos(i).clen(0)
            While (j > 1)
                cc = 9 + varcost(j - 1) + pdata(i + j).cost
                If (cc < kc) Then
                    kc = cc
                    kmode = 1 ' Short offset
                    kl = j
                End If
                j -= 1
            End While

            'Test all sizes until getting the most short
            j = metaDatos(i).clen(mode)
            If (mode = 1) Then
                ccc = 9
            Else
                ccc = 9 + mode
            End If

            While (j > 1)
                cc = ccc + varcost(j - 1) + pdata(i + j).cost
                If (cc < kc) Then
                    kc = cc
                    kmode = 2   ' Long offset
                    kl = j
                End If
                j -= 1
            End While

            pdata(i).cost = kc
            pdata(i).mode = kmode
            pdata(i).mlen = kl

        Next

        Return pdata(0).cost

    End Function



    Private Function getPletterData(ByRef pdata() As pakdata, mode As Short) As Byte()

        Dim i As Integer
        Dim j As UShort

        's.init();
        ' Inits output buffer
        Me.ep = 0
        Me.dp = 0
        Me.p = 0
        Me.e = 0
        ReDim Me.buf(length * 2)
        'END --- s.init();

        'If (savelength) Then {
        '   adddata(length & 255);
        '   adddata(length >> 8);
        '}

        add3(mode - 1)
        adddata(data(0))

        i = 1
        While (i < length)
            Select Case (pdata(i).mode)
                Case 0 ' Literal
                    add0()
                    adddata(data(i))
                    i += 1

                Case 1 ' Short offset
                    add1()
                    addvar(pdata(i).mlen - 1)
                    j = metaDatos(i).cpos(0) - 1
                    'If (j > 127) Then printf("-j>128-");
                    adddata(j)
                    i += pdata(i).mlen

                Case 2 ' Long offset
                    add1()
                    addvar(pdata(i).mlen - 1)
                    j = metaDatos(i).cpos(mode) - 1
                    'If (j < 128) Then printf("-j<128-");
                    j -= 128

                    'https://docs.microsoft.com/es-es/cpp/cpp/cpp-built-in-operators-precedence-and-associativity?view=msvc-170
                    adddata(128 Or (j And 127))  ' 128|j&127 Precedencia operadores logicos 

                    'Select Case mode
                    '    Case 6
                    If mode > 5 Then
                        addbit(j And 4096)
                    End If

                    '    Case 5
                    If mode > 4 Then
                        addbit(j And 2048)
                    End If

                    '    Case 4
                    If mode > 3 Then
                        addbit(j And 1024)
                    End If

                    '    Case 3
                    If mode > 2 Then
                        addbit(j And 512)
                    End If

                    '    Case 2
                    If mode > 1 Then
                        addbit(j And 256)
                        addbit(j And 128)
                    End If

                    '    Case 1
                    '        ' 

                    '    Case Else
                    '        'printf("-2-");

                    'End Select
                    i += pdata(i).mlen

                Case Else
                    'printf("-?-");

            End Select

        End While

        'for (i = 0; i != 34; ++i) add1()
        For i = 0 To 33
            add1()
        Next

        'Fill to zeros
        If (Not Me.p = 0) Then
            While (Me.p < 8)
                Me.e *= 2
                Me.p += 1
            End While
            addevent()
        End If

        Dim outputData() As Byte
        ReDim outputData(Me.dp - 1)

        Array.Copy(Me.buf, outputData, Me.dp)

        Return outputData

    End Function



    ''' <summary>
    ''' Adds a zero bit to output
    ''' </summary>
    Private Sub add0()
        If (Me.p = 0) Then claimevent()
        Me.e *= 2
        Me.p += 1
        If (Me.p = 8) Then addevent()
    End Sub



    ''' <summary>
    ''' Adds an one bit to output
    ''' </summary>
    Private Sub add1()
        If (Me.p = 0) Then claimevent()
        Me.e *= 2
        Me.p += 1
        Me.e += 1
        If (Me.p = 8) Then addevent()
    End Sub



    ''' <summary>
    ''' Add a X bit to output
    ''' </summary>
    ''' <param name="b"></param>
    Private Sub addbit(b As Integer)
        If (b) Then
            add1()
        Else
            add0()
        End If
    End Sub



    ''' <summary>
    ''' Add three bits to output
    ''' </summary>
    ''' <param name="b"></param>
    Private Sub add3(b As Integer)
        addbit(b And 4)
        addbit(b And 2)
        addbit(b And 1)
    End Sub



    ''' <summary>
    ''' Add a variable number to output
    ''' </summary>
    ''' <param name="i"></param>
    Private Sub addvar(i As Integer)
        Dim j As Integer = &H8000

        'Looks for the first bit set at one
        While (i And j) = 0  ' not i and j
            j >>= 1  'j >>= 1  j /= 2
        End While

        'Like in floating point, the uncompressed adds an extra one
        'While Not j = 1
        '    j >>= 1
        '    add1()
        '    If i And j Then
        '        add1()
        '    Else
        '        add0()
        '    End If
        'End While
        'add0()   ' Ending signal

        While (1)
            If (j = 1) Then
                add0()
                Exit While
            End If

            j >>= 1  'j /= 2
            add1()

            'addbit(i And j)
            If (i And j) Then
                add1()
            Else
                add0()
            End If

        End While

    End Sub



    ''' <summary>
    ''' Add a data to output
    ''' </summary>
    ''' <param name="value"></param>
    Private Sub adddata(value As Byte)
        Me.buf(Me.dp) = value
        Me.dp += 1
    End Sub



    ''' <summary>
    ''' Dump bits buffer
    ''' </summary>
    Private Sub addevent()
        Me.buf(Me.ep) = Me.e
        Me.e = 0
        Me.p = 0
    End Sub



    ''' <summary>
    ''' Take note where it will save the following 8 bits
    ''' </summary>
    Private Sub claimevent()
        Me.ep = Me.dp
        Me.dp += 1
    End Sub



End Class
