Public Interface iVDP



    Shadows Enum SCREEN_MODE As Integer
        T1
        G1
        G2
        MC
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
        ' screen 0 (T1) 40 columns ----------------------------------------------------------------------------------------
        TXTNAM = 0       '  0 Name Table                     (40 x  24) = 360h 
        TXTCGP = &H800   '  2 Pattern Generator              ( 8 x 256 tiles) = 800h

        TXTPAL = &H400   ' MSX BASIC v2 (V9938) > Palette table      ( 2 x  16 colors) = 20h


        ' screen 0 (T1) 80 columns (V9938) --------------------------------------------------------------------------------
        T80NAM = 0      ' (80 x  24)
        T80BLK = &H800  ' Blink table (-08EFH)
        T80CGP = &H1000 ' Pattern generator table (-17FFH)

        T80PAL = &HF00  ' MSX BASIC v2 > Palette table (-0F2FH)


        ' screen 1 (G1) ---------------------------------------------------------------------------------------------------
        T32NAM = &H1800  '  5 Name Table                     (32 x  24) = 300h
        T32COL = &H2000  '  6 Color Table                    ( 1 x  32) = 20h
        T32CGP = 0       '  7 Pattern Generator Table        ( 8 x 256 tiles) = 800h
        T32ATR = &H1B00  '  8 Sprite Attribute Table (OAM)   ( 4 x  32 sprite planes) = 80h
        T32PAT = &H3800  '  9 Sprite Pattern Table           ( 8 x 256 sprite patterns) or (32 x 64 sprite patterns) = 800h

        T32PAL = &H2020  ' MSX BASIC v2 (V9938) > Palette table      ( 2 x  16 colors) = 20h


        ' screen 2 (G2) ---------------------------------------------------------------------------------------------------
        GRPNAM = &H1800  ' 10 Name Table                     (32 x  24) = 300h
        GRPCGP = 0       ' 12 Pattern Generator Table        ( 8 x 256 tiles) x 3 banks = 800h * 3 = 1800h
        GRPCOL = &H2000  ' 11 Color Table                    ( 8 x 256 tiles) x 3 banks = 800h * 3 = 1800h
        GRPATR = &H1B00  ' 13 Sprite Attribute Table (OAM)   ( 4 x  32 sprite planes) = 80h
        GRPPAT = &H3800  ' 14 Sprite Pattern Generator       ( 8 x 256 sprite patterns) or (32 x 64 sprite patterns) = 800h

        GRPPAL = &H1B80  ' MSX BASIC v2 (V9938) > Palette table      ( 2 x  16 colors) = 20h


        ' screen 3 (MC) ---------------------------------------------------------------------------------------------------
        MLTNAM = &H800   ' 15 Name Table
        MLTCGP = 0       ' 17 Pattern
        MLTATR = &H1B00  ' 18 Sprite Attribute
        MLTPAT = &H3800  ' 19 Sprite Pattern

        MLTPAL = &H2020  ' MSX BASIC v2 (V9938) > Palette table      ( 2 x  16 colors) = 20h


        ' screen 4 (G3) V9938 ---------------------------------------------------------------------------------------------
        SC4NAM = &H1800  ' Name Table                        (32 x  24) = 300h
        SC4CGP = 0       ' Pattern Generator                 ( 8 x 256 tiles) x 3 banks = 800h * 3 = 1800h
        SC4COL = &H2000  ' Color Table                       ( 8 x 256 tiles) x 3 banks = 800h * 3 = 1800h
        SC4SAC = &H1C00  ' Sprite Atribute Colours table     (16 x  32 sprite planes) = 200h
        SC4ATR = &H1E00  ' Sprite Attribute Memory (OAM)     ( 4 x  32 sprite planes) = 80h
        SC4PAT = &H3800  ' Sprite Pattern Generator          ( 8 x 256 sprite patterns) or (32 x 64 sprite patterns) = 800h

        SC4PAL = &H1B80  ' MSX BASIC v2 > Palette table      ( 2 x  16 colors) = 20h

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
