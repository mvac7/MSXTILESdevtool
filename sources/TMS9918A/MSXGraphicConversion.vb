
''' <summary>
''' MSX-GCR 1.0 (MSX Graphic Conversion Routine) by Leandro Correia (2019)
''' Many thanks to Rogerio Penchel, Rafael Jannone and Weber Kai for valuable information and support.
''' Feel free to use this algorithm in any program you want (well, crediting me would be nice).
''' BlitzBasic version: https://pastebin.com/1nThpe7j
''' https://www.leandrocorreia.com/
''' https://www.msx.org/forum/msx-talk/development/graphic-conversion-for-any-256x192-into-msx1-graphics-source-code-in-blit
''' ------------------------------------------------------------------------------------------------------------------------
''' Adapted to python 2.7 by MsxKun (uses PIL library): https://pastebin.com/40WL354r
''' ------------------------------------------------------------------------------------------------------------------------ 
''' Adapted to VB.net by mvac7
''' </summary>
Public Class MSXGraphicConversion

    'Public tolerance As Byte = 100

    'Public DetailLevel As Double = 32.0


    Public Sub New()

    End Sub



    ''' <summary>
    ''' Convert Bitmap to TMS9918A G2 mode
    ''' </summary>
    ''' <param name="sourceBitmap"></param>
    ''' <param name="tolerance">Color tolerance for dithering (from 0 to 100). Higher values mean dithering between colors that are not similar, which results in better color accuracy but ugly squares On degradees. 0 means no dithering</param>
    ''' <param name="DetailLevel">Detail level (1 to 255)
    ''' Lower values gives priority in areas with strong luminosity changes (usually good when tolerance value Is high, Or in photo conversions).
    ''' Higher values makes the conversion ignore these luminosity changes (usually good when tolerance value Is low Or in simple art conversions).
    ''' But you should test it. Usually 32.0 Is a good value. 255 will make the routine completely ignore luminosity variations.
    ''' At best, this value can give subtle (but still welcome) improvements in conversion quality.
    ''' </param>
    ''' <returns></returns>
    Public Function GetScreenFromBitmap(ByVal sourceBitmap As Bitmap, ByVal tolerance As Byte, ByVal DetailLevel As Double) As Byte()

        Dim aColor As Color

        Dim ColorRed As Short
        Dim ColorGreen As Short
        Dim ColorBlue As Short


        'TMS9918A palette
        'Dim msxR = New Short() {0, 0, 36, 109, 36, 73, 182, 73, 255, 255, 219, 219, 36, 219, 182, 255}
        'Dim msxG = New Short() {0, 0, 219, 255, 36, 109, 36, 219, 36, 109, 219, 219, 146, 73, 182, 255}
        'Dim msxB = New Short() {0, 0, 36, 109, 255, 255, 36, 255, 36, 109, 36, 146, 36, 182, 182, 255}

        ' set TMS9918A palette based in Sean Young table
        ' http://bifi.msxnet.org/msxnet/tech/tms9918a.txt
        Dim msxR = New Short() {0, 0, 33, 94, 84, 125, 212, 66, 252, 255, 212, 230, 33, 201, 204, 255}
        Dim msxG = New Short() {0, 0, 200, 220, 85, 118, 82, 235, 85, 121, 193, 206, 176, 91, 204, 255}
        Dim msxB = New Short() {0, 0, 66, 120, 237, 252, 77, 245, 84, 120, 84, 128, 59, 186, 204, 255}


        Dim octetr(8), octetg(8), octetb(8) As Double
        Dim octetdetail(8) As Double
        Dim octetfinal(8), octetvalue(8) As Double
        Dim toner(5), toneg(5), toneb(5) As Double
        Dim distcolor(5) As Double
        Dim detail(256, 192) As Double   'Detail map
        Dim imagedata(255, 192) As Short 'Luminosity data Of original image
        Dim msxdumpdata(&H3FFF) As Byte  'Data For the MSX screen save file

        Dim cor, cor2, cor3 As Double
        Dim dif1, dif2 As Double
        Dim corfinal, corfinal2 As Double

        'Reads all luminosity values
        For j = 0 To 191
            For i = 0 To 255
                aColor = sourceBitmap.GetPixel(i, j)

                'GetColor(i, j)
                ColorRed = aColor.R
                ColorGreen = aColor.G
                ColorBlue = aColor.B
                imagedata(i, j) = (ColorRed + ColorGreen + ColorBlue) / 3
            Next
        Next

        'colorSorter(aColorList)

        'Calculates detail map

        If DetailLevel < 255 Then
            For j = 1 To 191
                For i = 1 To 254
                    cor = imagedata(i - 1, j)
                    cor2 = imagedata(i, j)
                    cor3 = imagedata(i + 1, j)
                    dif1 = Math.Abs(cor - cor2)
                    dif2 = Math.Abs(cor2 - cor3)
                    If dif1 > dif2 Then corfinal = dif1 Else corfinal = dif2
                    cor = imagedata(i, j - 1)
                    cor3 = imagedata(i, j + 1)
                    dif1 = Math.Abs(cor - cor2)
                    dif2 = Math.Abs(cor2 - cor3)
                    If dif1 > dif2 Then corfinal2 = dif1 Else corfinal2 = dif2
                    corfinal = (corfinal + corfinal2) >> 1 'SHR (Blitz basic) binary SHift Right
                    corfinal = corfinal
                    detail(i, j) = corfinal
                Next
            Next

            For i = 0 To 255
                detail(i, 0) = 0
                detail(i, 191) = 0
            Next
            For i = 0 To 191
                detail(0, i) = 0
                detail(255, i) = 0
            Next

            For j = 0 To 191
                For i = 0 To 255
                    If detail(i, j) < 1 Then detail(i, j) = 1
                    detail(i, j) = (detail(i, j) / DetailLevel) + 1
                Next
            Next
        Else
            For j = 0 To 191
                For i = 0 To 255
                    detail(i, j) = 1
                Next
            Next
        End If


        Dim y As Short = 0
        Dim x As Short = 0

        Dim bestdistance As Double
        Dim finaldist As Double
        Dim finaldista As Double
        Dim finaldistb As Double
        Dim dist As Double
        Dim bestcor1 As Short
        Dim bestcor2 As Short

        Dim aByte As Byte

        Dim bytepos As Short = 0


        While y < 192
            bestdistance = 99999999
            For i = 0 To 7
                ' Get the RGB values of 8 pixels of the original image
                aColor = sourceBitmap.GetPixel(x + i, y)
                octetr(i) = aColor.R 'ColorRed()
                octetg(i) = aColor.G 'ColorGreen()
                octetb(i) = aColor.B 'ColorBlue()
                octetdetail(i) = detail(x + i, y)
            Next

            ' Brute force starts. Programs tests all 15 x 15 MSX color combinations. For each pixel octet it'll have to compare the original pixel colors with three different colors:
            ' two MSX colors and a mixed RGB of both. If this RGB mixed is chosen it'll later be substituted by dithering.
            For cor1 = 1 To 15
                For cor2 = cor1 To 15

                    dist = 0

                    'If KeyHit(1) Then End

                    ' First MSX color of the octet
                    toner(0) = msxR(cor1)
                    toneg(0) = msxG(cor1)
                    toneb(0) = msxB(cor1)

                    ' Second MSX color of the octet
                    toner(2) = msxR(cor2)
                    toneg(2) = msxG(cor2)
                    toneb(2) = msxB(cor2)


                    ' A mix of both MSX colors RGB values. Since MSX cannot mix colors, later if this color is chosen it'll be substituted by a 2x2 dithering pattern.
                    toner(1) = (msxR(cor1) + msxR(cor2)) / 2
                    toneg(1) = (msxG(cor1) + msxG(cor2)) / 2
                    toneb(1) = (msxB(cor1) + msxB(cor2)) / 2

                    If calcdist2000(msxR(cor1), msxG(cor1), msxB(cor1), msxR(cor2), msxG(cor2), msxB(cor2)) <= tolerance Then ' if colors are not too distant according to the tolerance parameter, octect will be dithered.

                        ' dithered
                        For i = 0 To 7
                            For j = 0 To 2
                                distcolor(j) = (calcdist2000(toner(j), toneg(j), toneb(j), octetr(i), octetg(i), octetb(i))) * octetdetail(i)
                            Next

                            finaldist = distcolor(0)
                            octetvalue(i) = 0

                            For j = 1 To 2
                                If distcolor(j) < finaldist Then
                                    finaldist = distcolor(j)
                                    octetvalue(i) = j
                                End If
                            Next

                            dist = dist + finaldist

                            If dist > bestdistance Then Exit For
                        Next

                    Else
                        ' not dithered
                        For i = 0 To 7
                            finaldista = (calcdist2000(toner(0), toneg(0), toneb(0), octetr(i), octetg(i), octetb(i))) * octetdetail(i)
                            finaldistb = (calcdist2000(toner(2), toneg(2), toneb(2), octetr(i), octetg(i), octetb(i))) * octetdetail(i)

                            If finaldista < finaldistb Then
                                octetvalue(i) = 0
                                finaldist = finaldista
                            Else
                                octetvalue(i) = 2
                                finaldist = finaldistb
                            End If
                            dist = dist + finaldist
                            If dist > bestdistance Then Exit For
                        Next
                    End If

                    If dist < bestdistance Then
                        bestdistance = dist
                        bestcor1 = cor1
                        bestcor2 = cor2
                        For i = 0 To 7
                            octetfinal(i) = octetvalue(i)
                        Next
                    End If
                    If bestdistance = 0 Then Exit For
                Next
                If bestdistance = 0 Then Exit For
            Next
            aByte = 0
            For i = 0 To 7
                Select Case octetfinal(i)
                    Case 0
                        'Color msxr(bestcor1), msxg(bestcor1), msxb(bestcor1)

                    Case 1
                        If y Mod 2 = i Mod 2 Then
                            'Color msxr(bestcor2), msxg(bestcor2), msxb(bestcor2)
                            aByte = aByte + 2 ^ (7 - i)

                            'Else
                            'Color msxr(bestcor1), msxg(bestcor1), msxb(bestcor1)
                        End If

                    Case 2
                        'Color msxr(bestcor2), msxg(bestcor2), msxb(bestcor2)
                        aByte = aByte + 2 ^ (7 - i)

                End Select

                'If ColorRed() = msxr(bestcor2) And ColorGreen() = msxg(bestcor2) And ColorBlue() = msxb(bestcor2) Then aByte = aByte + 2 ^ (7 - i)
                'Plot 256 + x + i, y
            Next

            y = y + 1
            If y Mod 8 = 0 Then
                y = y - 8
                x = x + 8

                If x > 255 Then
                    x = 0
                    y = y + 8
                End If
            End If


            ' Bytes to be written in the final MSX screen dump file.
            msxdumpdata(bytepos) = aByte                                'pattern
            msxdumpdata(bytepos + &H2000) = (bestcor2 * 16) + bestcor1  'color
            bytepos = bytepos + 1

        End While


        Return msxdumpdata

    End Function




    Private Function calcdist2000(ByVal r1 As Double, ByVal g1 As Double, ByVal b1 As Double, ByVal r2 As Double, ByVal g2 As Double, ByVal b2 As Double) As Integer

        Dim r As Double
        Dim g As Double
        Dim b As Double

        Dim x As Double
        Dim y As Double
        Dim z As Double

        Dim l1 As Double
        Dim l2 As Double
        Dim a1 As Double
        Dim a2 As Double

        Dim dl As Double
        Dim hl As Double

        Dim sqb1 As Double
        Dim sqb2 As Double

        Dim c1 As Double
        Dim c2 As Double

        Dim hc7 As Double
        Dim trc As Double

        Dim t2 As Double

        Dim ap1 As Double
        Dim ap2 As Double

        Dim dc As Double

        Dim hc As Double
        Dim hh As Double
        Dim h1 As Double
        Dim h2 As Double
        Dim hdiff As Double

        Dim dh As Double
        Dim sqhl As Double

        Dim fl As Double
        Dim fc As Double
        Dim fh As Double

        Dim dt As Double


        If r1 = r2 And g1 = g2 And b1 = b2 Then Return 3

        ' Convert two RGB color values into Lab And uses the CIEDE2000 formula to calculate the distance between them.
        ' This function first converts RGBs to XYZ And then to Lab.

        ' This Is Not optimized, but I did my best to make it readable. In some rare cases there are some weird colors, so MAYBE there's a small bug in the implementation.
        ' The RGB to Lab conversion in here could easily be substituted by a giant RGB to Lab lookup table, consuming much more memory, but gaining A LOT in speed.

        '   Converting RGB values into XYZ

        r = r1 / 255.0
        g = g1 / 255.0
        b = b1 / 255.0

        If r > 0.04045 Then r = ((r + 0.055) / 1.055) ^ 2.4 Else r = r / 12.92
        If g > 0.04045 Then g = ((g + 0.055) / 1.055) ^ 2.4 Else g = g / 12.92
        If b > 0.04045 Then b = ((b + 0.055) / 1.055) ^ 2.4 Else b = b / 12.92

        r = r * 100.0
        g = g * 100.0
        b = b * 100.0

        'Observer. = 2°, Illuminant = D65
        x = r * 0.4124 + g * 0.3576 + b * 0.1805
        y = r * 0.2126 + g * 0.7152 + b * 0.0722
        z = r * 0.0193 + g * 0.1192 + b * 0.9505

        x = x / 95.047   'Observer= 2°, Illuminant= D65
        y = y / 100.0
        z = z / 108.883

        If x > 0.008856 Then x = x ^ (1.0 / 3.0) Else x = (7.787 * x) + (16.0 / 116.0)
        If y > 0.008856 Then y = y ^ (1.0 / 3.0) Else y = (7.787 * y) + (16.0 / 116.0)
        If z > 0.008856 Then z = z ^ (1.0 / 3.0) Else z = (7.787 * z) + (16.0 / 116.0)

        l1 = (116.0 * y) - 16.0
        a1 = 500.0 * (x - y)
        b1 = 200.0 * (y - z)


        r = r2 / 255.0
        g = g2 / 255.0
        b = b2 / 255.0

        If r > 0.04045 Then r = ((r + 0.055) / 1.055) ^ 2.4 Else r = r / 12.92
        If g > 0.04045 Then g = ((g + 0.055) / 1.055) ^ 2.4 Else g = g / 12.92
        If b > 0.04045 Then b = ((b + 0.055) / 1.055) ^ 2.4 Else b = b / 12.92

        r = r * 100.0
        g = g * 100.0
        b = b * 100.0

        'Observer. = 2°, Illuminant = D65
        x = r * 0.4124 + g * 0.3576 + b * 0.1805
        y = r * 0.2126 + g * 0.7152 + b * 0.0722
        z = r * 0.0193 + g * 0.1192 + b * 0.9505


        x = x / 95.047   'Observer= 2°, Illuminant= D65
        y = y / 100.0
        z = z / 108.883

        If x > 0.008856 Then x = x ^ (1 / 3.0) Else x = (7.787 * x) + (16.0 / 116.0)
        If y > 0.008856 Then y = y ^ (1 / 3.0) Else y = (7.787 * y) + (16.0 / 116.0)
        If z > 0.008856 Then z = z ^ (1 / 3.0) Else z = (7.787 * z) + (16.0 / 116.0)

        '   Converts XYZ to Lab... 

        l2 = (116.0 * y) - 16.0
        a2 = 500.0 * (x - y)
        b2 = 200.0 * (y - z)

        ' ...And then calculates distance between Lab colors, using the CIEDE2000 formula.

        dl = l2 - l1
        hl = l1 + dl * 0.5
        sqb1 = (b1 * b1) 'Float
        sqb2 = (b2 * b2)
        c1 = Math.Sqrt((a1 * a1 + sqb1)) 'Sqr
        c2 = Math.Sqrt((a2 * a2 + sqb2))
        hc7 = CDbl((c1 + c2) * 0.5) ^ 7 'Float
        trc = Math.Sqrt(hc7 / (hc7 + 6103515625.0))
        t2 = 1.5 - trc * 0.5
        ap1 = a1 * t2
        ap2 = a2 * t2
        c1 = Math.Sqrt(ap1 * ap1 + sqb1)
        c2 = Math.Sqrt(ap2 * ap2 + sqb2)
        dc = c2 - c1
        hc = c1 + dc * 0.5
        hc7 = hc ^ 7.0
        trc = Math.Sqrt(hc7 / (hc7 + 6103515625.0))
        h1 = Math.Atan2(b1, ap1)

        If h1 < 0 Then h1 = h1 + Math.PI * 2.0
        h2 = Math.Atan2(b2, ap2)
        If h2 < 0 Then h2 = h2 + Math.PI * 2.0
        hdiff = h2 - h1
        hh = h1 + h2
        If Math.Abs(hdiff) > Math.PI Then
            hh = hh + Math.PI * 2
            If h2 <= h1 Then hdiff = hdiff + Math.PI * 2.0
        Else
            hdiff = hdiff - Math.PI * 2.0
        End If

        hh = hh * 0.5
        t2 = 1 - 0.17 * Math.Cos(hh - Math.PI / 6) + 0.24 * Math.Cos(hh * 2)
        t2 = t2 + 0.32 * Math.Cos(hh * 3 + Math.PI / 30.0)
        t2 = t2 - 0.2 * Math.Cos(hh * 4 - Math.PI * 63 / 180.0)
        dh = 2 * Math.Sqrt(c1 * c2) * Math.Sin(hdiff * 0.5)
        sqhl = (hl - 50.0) * (hl - 50.0)
        fl = dl / (1 + (0.015 * sqhl / Math.Sqrt(20.0 + sqhl)))
        fc = dc / (hc * 0.045 + 1.0)
        fh = dh / (t2 * hc * 0.015 + 1.0)
        dt = 30 * Math.Exp(-(36.0 * hh - 55.0 * Math.PI ^ 2.0) / (25.0 * Math.PI * Math.PI))
        r = 0 - 2 * trc * Math.Sin(2.0 * dt * Math.PI / 180.0)

        Return Math.Sqrt(fl * fl + fc * fc + fh * fh + r * fc * fh)

    End Function



End Class
