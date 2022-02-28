
''' <summary>
''' Agrupa una lista de mapas y de tilesets(1 o 3 para el modo G2), pensado para ser usado en la clase 
''' de carga de proyectos del nMSXtiles de Pentacour.
''' </summary>
''' <remarks></remarks>
Public Class nMSXtilesProject

    Public Name As String = ""
    Public NameTilesetProject As String = ""
    Public NameMapProject As String = ""

    Public OneBank As Boolean = False

    Public Mode As iVDP.SCREEN_MODE

    Public Tilesets As ArrayList
    Public Screens As ArrayList 'Maps

    Public path_PROJECT As String = ""
    Public path_SCREEN As String = ""
    Public path_TILES As String = ""
    Public path_PALETTE As String = ""

End Class
