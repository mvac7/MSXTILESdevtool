Public Class VRAM_MapClass

    Private Mode0VRAMaddr() As Integer = {0, 0, &H800}
    Private Mode1VRAMaddr() As Integer = {0, &H1800, 0, &H2000, &H1B00, &H3800}
    Private Mode2VRAMaddr() As Integer = {0, &H1800, 0, 0, &H800, &H1000, &H2000, &H2000, &H2800, &H3000, &H1B00, &H3800, &H1B80}

    Private Mode0Size() As Integer = {&HFFF, &H3BF, &H7FF}
    Private Mode1Size() As Integer = {&H3FFF, &H2FF, &H7FF, &H20, &H7F, &H7FF}
    Private Mode2Size() As Integer = {&H3FFF, &H2FF, &H17FF, &H7FF, &H7FF, &H7FF, &H17FF, &H7FF, &H7FF, &H7FF, &H7F, &H7FF, &H1F}


    Public Function GetMapListFromMode(ByVal mode As Integer) As String()
        Select Case mode
            Case 0
                Return New String() {"Screen (1000h)", "Map", "Tiles Patterns"}

            Case 1
                Return New String() {"All VRAM (16k)", "Map", "Tiles Patterns", "Tiles Colors", "Sprite Attributes OAM", "Sprite Patterns"}

            Case Else
                Return New String() {"All VRAM (16k)", "Map", "Tiles Patterns · All", "Tiles Patterns · Bank0", "Tiles Patterns · Bank1", "Tiles Patterns · Bank2", "Tiles Colors · All", "Tiles Colors · Bank0", "Tiles Colors · Bank1", "Tiles Colors · Bank2", "Sprite Attributes OAM", "Sprite Patterns", "Palette (MSX2)"}

        End Select

    End Function


    Public Function GetVADDRbyIndex(ByVal mode As Integer, ByVal index As Integer) As Integer
        Select Case mode
            Case 0
                Return Mode0VRAMaddr(index)

            Case 1
                Return Mode1VRAMaddr(index)

            Case Else
                Return Mode2VRAMaddr(index)

        End Select
    End Function


    Public Function GetSizebyIndex(ByVal mode As Integer, ByVal index As Integer) As Integer
        Select Case mode
            Case 0
                Return Mode0Size(index)

            Case 1
                Return Mode1Size(index)

            Case Else
                Return Mode2Size(index)

        End Select
    End Function


End Class
