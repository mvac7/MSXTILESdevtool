sdcc -mz80 -o build\ --code-loc 0x4020 --data-loc 0xC000 --use-stdout --no-std-crt0 libs\crt0msx.16k.4000.rel libs\VDP_TMS9918_MSXBIOS.rel libs\unRLEWBtoVRAM.rel src\Test_GFX.c
hex2bin -e bin -l 4000 build\Test_GFX.ihx
copy build\Test_GFX.bin dist\TESTGFX.ROM
pause
