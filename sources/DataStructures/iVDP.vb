Public Interface iVDP



    Shadows Enum SCREEN_MODE As Integer
        T1
        G1
        G2
        G3
    End Enum

    Shadows Enum SPRITE_SIZE As Integer
        SIZE8 = 1
        SIZE16 = 2
    End Enum

    Shadows Enum SPRITE_ZOOM As Integer
        X1
        X2
    End Enum


    Shadows Enum TableBase As Integer
        ' screen 0
        TXTNAM = 0       ' 0 Map
        TXTCGP = &H800   ' 2 Tile Pattern

        ' screen 1
        T32NAM = &H1800  ' 5 Map
        T32COL = &H2000  ' 6 Tile Color
        T32CGP = 0       ' 7 Tile Pattern
        T32ATR = &H1B00  ' 8 Sprite Attribute
        T32PAT = &H3800  ' 9 Sprite Pattern

        ' screen 2
        GRPNAM = &H1800  ' 10 Name_Table_Base_Address
        GRPCOL = &H2000  ' 11 Color_Table_Base_Address
        GRPCGP = 0       ' 12 Pattern_Generator_Base_Address
        GRPATR = &H1B00  ' 13 Sprite_Attribute_Table_Base_Address
        GRPPAT = &H3800  ' 14 Sprite_Pattern_Generator_Base_Address

        ' screen 3
        MLTNAM = &H800   ' 15 Map
        MLTCGP = 0       ' 17 Pattern
        MLTATR = &H1B00  ' 18 Sprite Attribute
        MLTPAT = &H3800  ' 19 Sprite Pattern

        ' screen 4 (V9938)
        SC4NAM = &H1800  ' (300h) Name_Table_Base_Address (Map)
        SC4CGP = 0       ' (800hx3) Pattern_Generator_Base_Address
        SC4COL = &H2000  ' (800hx3) Color_Table_Base_Address
        SC4PAL = &H1B80  ' (20h)  MSX BASIC Graphic format > Palette Data
        SC4SAC = &H1C00  ' (200h) Sprite Atribute Colours table
        SC4ATR = &H1E00  ' (80h) OAM Sprite Attribute Memory
        SC4PAT = &H3800  ' (800h) Sprite_Pattern_Generator_Base_Address

    End Enum



    Shadows Enum TableBaseSize As Integer
        ' screen 0
        TXTNAM = &H3C0  ' 0 Map
        TXTCGP = &H800  ' 2 Tile Pattern

        ' screen 1
        T32NAM = &H300  ' 5 Map
        T32COL = &H20   ' 6 Tile Color
        T32CGP = &H800  ' 7 Tile Pattern
        T32ATR = &H80   ' 8 Sprite Attribute
        T32PAT = &H800  ' 9 Sprite Pattern

        ' screen 2
        GRPNAM = &H300  ' 10 Name_Table_Base_Address
        GRPCOL = &H1800 ' 11 Color_Table_Base_Address
        GRPCGP = &H1800 ' 12 Pattern_Generator_Base_Address
        GRPATR = &H80   ' 13 Sprite_Attribute_Table_Base_Address
        GRPPAT = &H800  ' 14 Sprite_Pattern_Generator_Base_Address

        ' screen 3
        MLTNAM = &H300  ' 15 Map - Size????
        MLTCGP = &H600  ' 17 Pattern
        MLTATR = &H80   ' 18 Sprite Attribute
        MLTPAT = &H800  ' 19 Sprite Pattern

        ' screen 4 (V9938)
        SC4NAM = &H300  ' Name_Table_Base_Address (Map)
        SC4CGP = &H1800 ' Pattern_Generator_Base_Address
        SC4COL = &H1800 ' Color_Table_Base_Address
        SC4PAL = &H20   ' MSX BASIC Graphic format > Palette Data
        SC4SAC = &H200  ' Sprite Atribute Colours table
        SC4ATR = &H80   ' OAM Sprite Attribute Memory
        SC4PAT = &H800  ' Sprite_Pattern_Generator_Base_Address

    End Enum



    Shadows Enum NumberOfBase As Byte
        Name_Table_Base_Address = 10
        Color_Table_Base_Address = 11
        Pattern_Generator_Base_Address = 12
        Sprite_Attribute_Table_Base_Address = 13
        Sprite_Pattern_Generator_Base_Address = 14
    End Enum



End Interface
