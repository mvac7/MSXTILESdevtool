

Public Class DataFormat

    ''' <summary>
    ''' Provides the last line number used in BASIC, with its increase.
    ''' </summary>
    Public BASIC_Line As Short = 10000

    ''' <summary>
    ''' 
    ''' </summary>
    Public BASIC_increment As Byte = 10



    Public Shadows Enum DataType As Byte
        DECIMAL_n = 0         '1
        DECIMAL_nnn = 1      '001  - 11
        DECIMAL_nnnd = 2      '001d - 1

        HEXADECIMAL_nn = 3    'FF   - 2
        HEXADECIMAL_Snn = 4   '$FF  - 4
        HEXADECIMAL_4nn = 5   '#FF  - 5
        HEXADECIMAL_0nnh = 6  '0FFh - 6
        HEXADECIMAL_C = 7  '0xFF - 3
        HEXADECIMAL_BASIC = 8  '&hFF - 7

        BINARY_n = 9          ' 00000000   - 8
        BINARY_nb = 10        ' 00000000b  - 9
        BINARY_percentn = 11  ' %00000000
        BINARY_C = 12         ' 0B00000000
        BINARY_BASIC = 13     ' &B00000000
    End Enum


    Public Shadows Enum ProgrammingLanguage As Byte
        ASSEMBLER
        BASIC
        C
    End Enum



    ''' <summary>
    ''' Provides the formatted data to be used in MSX BASIC.
    ''' </summary>
    ''' <param name="tmpData"></param>
    ''' <param name="itemsPerLine"></param>
    ''' <param name="format"></param>
    ''' <param name="firstNumLine"></param>
    ''' <param name="incLine"></param>
    ''' <param name="comment"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetBASICcode(ByVal tmpData As Array, ByVal itemsPerLine As Byte, ByVal format As DataType, ByVal removeZeros As Boolean, ByVal firstNumLine As Short, ByVal incLine As Byte, ByVal comment As ArrayList) As String

        Dim outputString As String = ""

        Dim contador As Integer = 0

        Dim line As String

        Dim i As Integer
        Dim o As Integer

        Dim tmpCalc As Short

        Dim tableSize As Short
        tableSize = tmpData.Length - 1

        Me.BASIC_Line = firstNumLine
        Me.BASIC_increment = incLine

        outputString = GetComments(comment, ProgrammingLanguage.BASIC) 'GetBASICComments(comment, firstNumLine, incLine)

        If itemsPerLine = 0 Then
            itemsPerLine = 32 ' maximum data per line
        End If

        tmpCalc = -Int(-((tableSize + 1) / itemsPerLine))

        For i = 1 To tmpCalc
            line = CStr(Me.BASIC_Line) + " DATA "
            For o = 0 To itemsPerLine - 2
                If (contador < tableSize) Then
                    line += GetBasicFormatedValue(tmpData(contador), format, removeZeros) + ","
                    contador += 1
                ElseIf (contador = tableSize) Then  ' ultimo de la linea
                    line += GetBasicFormatedValue(tmpData(contador), format, removeZeros)
                    contador += 1
                End If
            Next
            If Not (contador > tableSize) Then ' ultimo de la linea
                line += GetBasicFormatedValue(tmpData(contador), format, removeZeros)
                contador += 1
            End If

            outputString += line + vbNewLine
            Me.BASIC_Line += incLine
        Next

        Return outputString

    End Function



    ''' <summary>
    ''' Provides data formatted for use in C.
    ''' Proporciona los datos formateados para ser usados en C.
    ''' </summary>
    ''' <param name="tmpData"></param>
    ''' <param name="itemsPerLine"></param>
    ''' <param name="format"></param>
    ''' <param name="fieldName"></param>
    ''' <param name="comment"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCcode(ByVal tmpData As Array, ByVal itemsPerLine As Byte, ByVal format As DataType, ByVal fieldName As String, ByVal comment As ArrayList, ByVal dataCommand As String) As String

        Dim outputString As String = ""

        Dim contador As Integer = 0
        Dim line As String

        Dim i As Integer = 0
        Dim o As Integer = 0

        Dim totalLines As Short

        'Dim tmpValue As Object
        Dim formatedVale As String

        Dim tableSize As Integer
        tableSize = tmpData.Length - 1

        outputString = GetComments(comment, ProgrammingLanguage.C)

        line = dataCommand + " " + GetCFieldFormat(fieldName) + "[]={"
        outputString += line + vbNewLine

        If itemsPerLine = 0 Then
            itemsPerLine = 32 ' maximum data per line
        End If

        totalLines = -Int(-((tableSize + 1) / itemsPerLine))

        For i = 1 To totalLines
            line = ""
            For o = 0 To itemsPerLine - 1

                If Not (contador > tableSize) Then

                    formatedVale = GetFormatedValue(tmpData(contador), format)

                    If (contador < tableSize) Then
                        line += formatedVale + ","
                        contador += 1
                    ElseIf (contador = tableSize) Then
                        line += formatedVale + "};"
                        contador += 1
                    End If

                End If

            Next

            outputString += line + vbNewLine
        Next

        Return outputString

    End Function



    ''' <summary>
    ''' Provides data formatted for use on Assembler.
    ''' </summary>
    ''' <param name="tmpData"></param>
    ''' <param name="itemsPerLine"></param>
    ''' <param name="format"></param>
    ''' <param name="fieldName"></param>
    ''' <param name="comment"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAssemblerCode(ByVal tmpData As Array, ByVal itemsPerLine As Byte, ByVal format As DataType, ByVal fieldName As String, ByVal comment As ArrayList, ByVal dataCommand As String) As String

        Dim outputString As String = ""

        Dim contador As Integer = 0
        Dim line As String

        Dim i As Integer = 0
        Dim o As Integer = 0

        Dim totalLines As Short

        Dim formatedVale As String

        Dim tableSize As Short
        tableSize = tmpData.Length - 1

        outputString = GetComments(comment, ProgrammingLanguage.ASSEMBLER)

        If Not fieldName = "" Then
            outputString += GetAsmFieldFormat(fieldName) + ":" + vbNewLine
        End If

        If itemsPerLine = 0 Then
            itemsPerLine = 32 ' maximum data per line
        End If

        totalLines = -Int(-((tableSize + 1) / itemsPerLine))

        For i = 1 To totalLines

            If dataCommand.ToLower.StartsWith("<tab>") Then
                line = vbTab + dataCommand.Substring(5) + " "
            Else
                line = dataCommand + " "
            End If

            For o = 0 To itemsPerLine - 1

                If Not (contador > tableSize) Then

                    formatedVale = GetFormatedValue(tmpData(contador), format)

                    If (o = itemsPerLine - 1) Or (contador = tableSize) Then
                        line += formatedVale
                    Else
                        line += formatedVale + ","
                    End If
                    contador += 1

                End If
            Next

            outputString += line + vbNewLine
        Next

        Return outputString

    End Function



    ''' <summary>
    ''' Provides a value formatted for BASIC
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="format"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetBasicFormatedValue(ByVal value As Object, ByVal format As DataType, ByVal removeZeros As Boolean) As String

        Dim outputData As String = ""

        If IsNumeric(value) Then
            If removeZeros Then
                If value = 0 Then
                    outputData = ""
                Else
                    If format = DataType.HEXADECIMAL_nn Then
                        outputData = Hex(value)
                    Else
                        outputData = GetFormatedValue(value, format)
                    End If
                End If
            Else
                outputData = GetFormatedValue(value, format)
            End If
        End If

        Return outputData

    End Function



    ''' <summary>
    ''' Provides a value formatted in different types
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="format"></param>
    ''' <returns></returns>
    Public Function GetFormatedValue(ByVal value As Object, ByVal format As DataType) As String

        Dim outputData As String = "0"

        Dim decSize As Integer = 3
        Dim hexSize As Integer = 2
        Dim binSize As Integer = 8


        If TypeOf value Is Short Then
            decSize = 5
            hexSize = 4
            binSize = 16
        End If


        Select Case format

            Case DataType.DECIMAL_n
                outputData = CStr(value)

            Case DataType.DECIMAL_nnn
                outputData = CStr(value).PadLeft(decSize, "0"c)

            Case DataType.DECIMAL_nnnd
                outputData = CStr(value).PadLeft(decSize, "0"c) + "d"

            Case DataType.HEXADECIMAL_nn
                outputData = Hex(value).PadLeft(hexSize, "0"c)

            Case DataType.HEXADECIMAL_0nnh
                outputData = "0" + Hex(value).PadLeft(hexSize, "0"c) + "h"

            Case DataType.HEXADECIMAL_C
                outputData = "0x" + Hex(value).PadLeft(hexSize, "0"c)

            Case DataType.HEXADECIMAL_4nn
                outputData = "#" + Hex(value).PadLeft(hexSize, "0"c)

            Case DataType.HEXADECIMAL_Snn
                outputData = "$" + Hex(value).PadLeft(hexSize, "0"c)

            Case DataType.HEXADECIMAL_BASIC
                outputData = "&H" + Hex(value).PadLeft(hexSize, "0"c)

            Case DataType.BINARY_n
                outputData = Convert.ToString(value, 2).PadLeft(binSize, "0"c)

            Case DataType.BINARY_nb
                outputData = Convert.ToString(value, 2).PadLeft(binSize, "0"c) + "b"

            Case DataType.BINARY_percentn
                outputData = "%" + Convert.ToString(value, 2).PadLeft(binSize, "0"c)

            Case DataType.BINARY_C
                outputData = "0b" + Convert.ToString(value, 2).PadLeft(binSize, "0"c)

            Case DataType.BINARY_BASIC
                outputData = "&B" + Convert.ToString(value, 2).PadLeft(binSize, "0"c)

        End Select

        Return outputData

    End Function




    ''' <summary>
    ''' Provides an 8-bit hexadecimal value
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetHexByte(ByVal value As Byte) As String
        Return Hex(value).PadLeft(2, "0"c)
    End Function



    ''' <summary>
    ''' Provides a 16-bit hexadecimal value
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetHexWord(ByVal value As Short) As String
        Return Hex(value).PadLeft(4, "0"c)
    End Function



    ''' <summary>
    ''' Provides a String formatted from an Array of Bytes, to be used in XML files.
    ''' </summary>
    ''' <param name="aData"></param>
    ''' <returns></returns>
    Public Function JoinDataHex(ByVal aData As Byte()) As String
        Dim anOutput As String = ""
        Dim i As Integer

        For i = 0 To aData.Length - 1
            anOutput += GetHexByte(aData(i))
        Next

        Return anOutput
    End Function



    'Public Function JoinDataHex(ByVal aData As Array) As String
    '    Dim anOutput As String = ""
    '    Dim i As Integer

    '    For i = 0 To aData.Length - 1
    '        anOutput += GetHexByte(aData(i))
    '    Next

    '    Return anOutput
    'End Function



    ''' <summary>
    ''' Provides an Array of Bytes from a String formatted by JoinDataHex(). For reading data from files in XML.
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    Public Function ByteSpliterHex(ByVal data As String) As Byte()
        Dim tmpData As Byte()

        Dim size As Integer = (data.Length / 2) - 1
        ReDim tmpData(size)

        For i As Integer = 0 To size
            tmpData(i) = Byte.Parse((data.Substring(i * 2, 2)), System.Globalization.NumberStyles.HexNumber)
        Next

        Return tmpData
    End Function



    Public Function ByteSpliter(ByVal data As String, ByVal size As Integer, ByVal initpos As Integer) As Byte()
        If data.IndexOf(",") = -1 Then
            Return ByteSpliterHex(data, size, initpos)
        Else
            Return ByteSpliter(data, size, initpos, 0)
        End If
    End Function



    ''' <summary>
    ''' Provides an Array of Bytes from a String formatted by JoinDataHex(). For reading data from files in XML.
    ''' </summary>
    ''' <param name="data"></param>
    ''' <param name="size"></param>
    ''' <param name="initpos"></param>
    ''' <returns></returns>
    Public Function ByteSpliterHex(ByVal data As String, ByVal size As Integer, ByVal initpos As Integer) As Byte()
        Dim tmpData As Byte()
        Dim counter As Integer = 0

        ReDim tmpData(size)

        If (data.Length / 2) < (size + 1) Then
            data += New String("0", 64) 'add 32(*2) hex values
        End If

        For i As Integer = initpos To initpos + size
            tmpData(counter) = Byte.Parse((data.Substring(i * 2, 2)), System.Globalization.NumberStyles.HexNumber)
            counter += 1
        Next

        Return tmpData
    End Function



    ''' <summary>
    ''' DEPRECATED, Para compatibilidad con el formato del MSXtiles devtool.
    ''' </summary>
    ''' <param name="data"></param>
    ''' <param name="size"></param>
    ''' <param name="initpos"></param>
    ''' <param name="defaultvalue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ByteSpliter(ByVal data As String, ByVal size As Integer, ByVal initpos As Integer, ByVal defaultvalue As Byte) As Byte()
        Dim tmpData As Byte()
        Dim numitems As Integer = 0
        Dim counter As Integer = 0

        Dim defaultString As String = "," + CStr(defaultvalue)

        'data += ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        For i As Integer = 0 To 31
            data += defaultString
        Next

        ReDim tmpData(size)

        Dim splitdata As String() = data.Split(",")
        numitems = splitdata.GetLength(0)

        For i As Integer = initpos To initpos + size
            tmpData(counter) = CByte(splitdata(i))
            counter += 1
        Next

        Return tmpData
    End Function



    Public Function GetAsmFieldFormat(ByVal field As String) As String
        Dim formatedField As String

        formatedField = field.Trim
        formatedField = formatedField.Replace(" ", "_")
        formatedField = formatedField.Replace(".", "_")
        formatedField = formatedField.Replace("(", "")
        formatedField = formatedField.Replace(")", "")

        Return formatedField
    End Function



    Public Function GetCFieldFormat(ByVal field As String) As String
        Dim formatedField As String

        formatedField = field.Trim
        formatedField = formatedField.Replace(" ", "_")
        formatedField = formatedField.Replace(".", "_")
        formatedField = formatedField.Replace("(", "")
        formatedField = formatedField.Replace(")", "")

        Return formatedField
    End Function



    ''' <summary>
    ''' Provides a String from a list of texts, in the indicated Programming Language format.
    ''' </summary>
    ''' <param name="comment"></param>
    ''' <param name="format"></param>
    ''' <returns></returns>
    Public Function GetComments(ByVal comment As ArrayList, ByVal format As ProgrammingLanguage) As String
        Dim outputString As String = ""

        If Not comment Is Nothing Then
            For Each commentValue As String In comment

                Select Case format
                    Case ProgrammingLanguage.BASIC
                        outputString += CStr(Me.BASIC_Line) + " REM " + commentValue + vbNewLine
                        Me.BASIC_Line += Me.BASIC_increment

                    Case ProgrammingLanguage.C
                        outputString += "// " + commentValue + vbNewLine

                    Case Else
                        'ProgrammingLanguage.ASSEMBLER
                        outputString += "; " + commentValue + vbNewLine

                End Select

            Next
        End If

        Return outputString

    End Function



    'Public Function GetBASICComments(ByVal comment As ArrayList, ByVal firstNumLine As Short, ByVal incLine As Byte) As String
    '    Dim outputString As String = ""

    '    Me.BASIC_Line = firstNumLine

    '    If Not comment Is Nothing Then
    '        For Each commentValue As String In comment
    '            outputString += CStr(Me.BASIC_Line) + " REM " + commentValue + vbNewLine
    '            Me.BASIC_Line += incLine
    '        Next
    '    End If

    '    Return outputString

    'End Function





End Class

