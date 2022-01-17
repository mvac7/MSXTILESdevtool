Public Class MSXDataFormat

    ''' <summary>
    ''' Provides the last line number used in BASIC, with its increase.
    ''' Proporciona el último número de linea utilizada en BASIC, con su incremento.
    ''' </summary>
    ''' <remarks></remarks>
    Public lastLineNumber As Integer


    ' dec nnn
    ' dec nnnd
    ' hex FF
    ' hex 0xFF
    ' hex FF$
    ' hex FF#
    ' hex 0FFh
    Public Shadows Enum DataFormat As Byte
        DECIMAL_nnn = 0       '255
        DECIMAL_nnnd = 1      '255d

        HEXADECIMAL_nn = 2    'FF
        HEXADECIMAL_0xnn = 3  '0xFF
        HEXADECIMAL_Snn = 4   '$FF
        HEXADECIMAL_4nn = 5   '#FF
        HEXADECIMAL_0nnh = 6  '0FFh
        HEXADECIMAL_yHnn = 7  '&hFF

        BINARY_n = 8   ' 00000000
        BINARY_nb = 9  ' 00000000b
        BINARY_percentn = 10 ' %00000000
    End Enum


    Public Shadows Enum OutputFormat As Byte
        BASIC
        C
        ASM
        ASM_SDCC
    End Enum



    ''' <summary>
    ''' Provides the formatted data to be used in MSX BASIC.
    ''' Proporciona los datos formateados para ser usados en BASIC de MSX.
    ''' </summary>
    ''' <param name="tmpData"></param>
    ''' <param name="itemsPerLine"></param>
    ''' <param name="format"></param>
    ''' <param name="numLine"></param>
    ''' <param name="incLine"></param>
    ''' <param name="comment"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function BasicMSX_codeGen(ByVal tmpData() As Byte, ByVal itemsPerLine As Byte, ByVal format As DataFormat, ByVal removeZeros As Boolean, ByVal numLine As Short, ByVal incLine As Byte, ByVal comment As ArrayList) As String

        Dim outputString As String = ""

        Dim contador As Integer = 0

        'Dim numLine As Short
        'Dim incLine As Byte

        Dim line As String

        Dim i As Integer = 0
        Dim o As Integer = 0

        Dim tmpCalc As Short

        Dim tableSize As Short
        tableSize = tmpData.Length - 1

        If Not comment Is Nothing Then
            For Each commentValue As String In comment
                outputString += CStr(numLine) + " REM " + commentValue + vbNewLine
                numLine += incLine
            Next
        End If

        tmpCalc = -Int(-((tableSize + 1) / itemsPerLine))

        For i = 1 To tmpCalc
            line = CStr(numLine) + " DATA "
            For o = 0 To itemsPerLine - 2
                If (contador < tableSize) Then
                    line += getBasicFormatedValue(tmpData(contador), format, removeZeros) + ","
                    contador += 1
                ElseIf (contador = tableSize) Then  ' ultimo de la linea
                    line += getBasicFormatedValue(tmpData(contador), format, removeZeros)
                    contador += 1
                End If
            Next
            If Not (contador > tableSize) Then ' ultimo de la linea
                line += getBasicFormatedValue(tmpData(contador), format, removeZeros)
                contador += 1
            End If

            outputString += line + vbNewLine
            numLine += incLine
        Next

        Me.lastLineNumber = numLine

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
    Public Function C_codeGen(ByVal tmpData() As Byte, ByVal itemsPerLine As Byte, ByVal format As DataFormat, ByVal fieldName As String, ByVal comment As ArrayList) As String

        Dim outputString As String = ""

        Dim contador As Integer = 0
        Dim line As String

        Dim i As Integer = 0
        Dim o As Integer = 0

        Dim tmpCalc As Short

        Dim tableSize As Short
        tableSize = tmpData.Length - 1

        'If Not commentText = "" Then
        '    outputString += "// " + commentText + vbNewLine
        'End If

        If Not comment Is Nothing Then
            For Each commentValue As String In comment
                outputString += "// " + commentValue + vbNewLine
            Next
        End If


        line = "unsigned char " + fieldName + "[]={"
        outputString += line + vbNewLine

        tmpCalc = -Int(-((tableSize + 1) / itemsPerLine))

        For i = 1 To tmpCalc
            line = ""
            For o = 0 To itemsPerLine - 1
                If (contador < tableSize) Then
                    line += getFormatedValue(tmpData(contador), format) + ","
                    contador += 1
                Else
                    If (contador = tableSize) Then
                        line += getFormatedValue(tmpData(contador), format) + "};"
                        contador += 1
                    End If
                End If
            Next
            outputString += line + vbNewLine
        Next

        Return outputString

    End Function



    'Public Function AsmSDCC_codeGen(ByVal tmpData() As Byte, ByVal itemsPerLine As Byte, ByVal format As DataFormat, ByVal fieldName As String, ByVal comment As ArrayList) As String

    '    Dim outputString As String = ""

    '    Dim contador As Integer = 0
    '    Dim line As String

    '    Dim i As Integer = 0
    '    Dim o As Integer = 0

    '    Dim tmpCalc As Short

    '    Dim tableSize As Short
    '    tableSize = tmpData.Length - 1

    '    If Not comment Is Nothing Then
    '        For Each commentValue As String In comment
    '            outputString += "; " + commentValue + vbNewLine
    '        Next
    '    End If

    '    If Not fieldName = "" Then
    '        outputString += fieldName + ":" + vbNewLine
    '    End If

    '    tmpCalc = -Int(-((tableSize + 1) / itemsPerLine))

    '    For i = 1 To tmpCalc
    '        line = ".db "
    '        For o = 0 To itemsPerLine - 2

    '            If (contador < tableSize) Then
    '                line += getSDCCFormatedValue(tmpData(contador), format) + ","
    '                contador += 1
    '            ElseIf (contador = tableSize) Then
    '                line += getSDCCFormatedValue(tmpData(contador), format)
    '                contador += 1
    '            End If

    '        Next
    '        If Not (contador > tableSize) Then
    '            line += getSDCCFormatedValue(tmpData(contador), format)
    '            contador += 1
    '        End If

    '        outputString += line + vbNewLine
    '    Next

    '    Return outputString

    'End Function


    ''' <summary>
    ''' Provides data formatted for use on Z80 Assembler.
    ''' Proporciona los datos formateados para ser usados en Ensamblador de Z80.
    ''' </summary>
    ''' <param name="tmpData"></param>
    ''' <param name="itemsPerLine"></param>
    ''' <param name="format"></param>
    ''' <param name="fieldName"></param>
    ''' <param name="comment"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Asm_codeGen(ByVal tmpData() As Byte, ByVal itemsPerLine As Byte, ByVal format As DataFormat, ByVal fieldName As String, ByVal comment As ArrayList, ByVal datalabel As String) As String

        Dim outputString As String = ""

        Dim contador As Integer = 0
        Dim line As String

        Dim i As Integer = 0
        Dim o As Integer = 0

        Dim tmpCalc As Short

        Dim tableSize As Short
        tableSize = tmpData.Length - 1

        If Not comment Is Nothing Then
            For Each commentValue As String In comment
                outputString += "; " + commentValue + vbNewLine
            Next
        End If


        If Not fieldName = "" Then
            outputString += fieldName + ":" + vbNewLine
        End If

        tmpCalc = -Int(-((tableSize + 1) / itemsPerLine))

        For i = 1 To tmpCalc
            line = datalabel + " "
            For o = 0 To itemsPerLine - 2

                If (contador < tableSize) Then
                    line += getFormatedValue(tmpData(contador), format) + ","
                    contador += 1
                ElseIf (contador = tableSize) Then
                    line += getFormatedValue(tmpData(contador), format)
                    contador += 1
                End If

            Next
            If Not (contador > tableSize) Then
                line += getFormatedValue(tmpData(contador), format)
                contador += 1
            End If

            outputString += line + vbNewLine
        Next

        Return outputString

    End Function




    ''' <summary>
    ''' Proporciona un valor formateado para BASIC.
    ''' </summary>
    ''' <param name="aValue"></param>
    ''' <param name="format"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getBasicFormatedValue(ByVal aValue As Byte, ByVal format As DataFormat, ByVal removeZeros As Boolean) As String

        Dim outputData As String = ""

        If removeZeros Then
            If aValue = 0 Then
                outputData = ""
            Else
                If format = DataFormat.HEXADECIMAL_nn Then
                    outputData = Hex(aValue)
                Else
                    outputData = getFormatedValue(aValue, format)
                End If
            End If
        Else
            outputData = getFormatedValue(aValue, format)
        End If

        Return outputData

    End Function



    ''' <summary>
    ''' Proporciona un valor formateado para Assembler.
    ''' </summary>
    ''' <param name="aValue"></param>
    ''' <param name="format"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getFormatedValue(ByVal aValue As Byte, ByVal format As DataFormat) As String

        Dim outputData As String = "0"

        Select Case format
            Case DataFormat.DECIMAL_nnn
                outputData = CStr(aValue)

            Case DataFormat.DECIMAL_nnnd
                outputData = CStr(aValue) + "d"

            Case DataFormat.HEXADECIMAL_nn
                outputData = getHexByte(aValue)

            Case DataFormat.HEXADECIMAL_0nnh
                outputData = "0" + getHexByte(aValue) + "h"

            Case DataFormat.HEXADECIMAL_0xnn
                outputData = "0x" + getHexByte(aValue)

            Case DataFormat.HEXADECIMAL_4nn
                outputData = "#" + getHexByte(aValue)

            Case DataFormat.HEXADECIMAL_Snn
                outputData = "$" + getHexByte(aValue)

            Case DataFormat.HEXADECIMAL_yHnn
                outputData = "&H" + getHexByte(aValue)

            Case DataFormat.BINARY_nb
                outputData = "00000000" + "b" ' <<<<<<<<<<<<<<<<<<<<<<<<<<<< FALTA POR IMPLEMENTAR

            Case DataFormat.BINARY_percentn
                outputData = "%" + "00000000" ' <<<<<<<<<<<<<<<<<<<<<<<<<<<< FALTA POR IMPLEMENTAR

        End Select

        Return outputData

    End Function


    ''' <summary>
    ''' Proporciona un valor en hexadecimal de 8 bits.
    ''' </summary>
    ''' <param name="avalue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getHexByte(ByVal avalue As Byte) As String
        Dim hexvalue As String = "00" + Hex(avalue)
        Return hexvalue.Substring(hexvalue.Length - 2, 2)
    End Function



    ''' <summary>
    ''' Proporciona un valor hexadecimal de 16 bits.
    ''' </summary>
    ''' <param name="avalue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getHexShort(ByVal avalue As Short) As String
        Dim hexvalue As String = "0000" + Hex(avalue)
        Return hexvalue.Substring(hexvalue.Length - 4, 4)
    End Function





End Class

