Public Interface iCompressEncoder

    Shadows Enum COMPRESS_TYPE As Integer
        RAW
        RLE
        RLEWB
        PLETTER
    End Enum


    ReadOnly Property Name As String


    Function Compress(ByVal data() As Byte) As Byte()

End Interface
