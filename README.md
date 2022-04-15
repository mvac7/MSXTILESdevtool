# MSXTiles·devtool

![MSXTiles devtool logo](https://github.com/mvac7/MSXTILESdevtool/raw/master/GFX/logo_mSXTiles-devtool.png)

```
Short:        Application to work with images in the graphics mode 2 of TMS9918A
Author:       mvac7
Architecture: Microsoft .Net Framework 3.0
Programming language: Visual BASIC .net
License:      GNU General Public License v3   
```

---

## Description

Application to work with images in the graphcis mode 2 of VDP TMS9918A and get a dump in different code formats (ASM, C and Basic).
   
Born from the need to convert nMSXtiles projects to C code, plus some utilities to develop GUI for MSX application PSGed.
   
This application is designed for agile and intuitive handling, but always can be improved. We are working on it. We are waiting your suggestions. 

This software was developed in Microsoft Visual Basic 2008 Express.
   

<br/>

---

## License 

Copyright (C) 2022 mvac7

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.


<br/>

---

## Requirements 
 
PC with Microsoft Windows OS and Framework 3.0


<br/>

---

## How to install 
 
Unpack and Copy MSXTILESdevtool folder somewhere on your hard disk. 

Run MSXTILESdevtool.exe 


<br/>

---

## Features

* Load or Save: project files, screens and tilesets from Pentacour's nMSXtiles tool. [nMSXtiles](https://github.com/pipagerardo/nMSXtiles)
* Load or Save project files in native XML format.  
* Load MSX Basic binary (SC2). Get the palette if it detects that is included.
* Save a MSX Basic binary (SC2). Include V9938 color palette.
* Load Bitmap PNG/GIF format and convert to Graphic 2 TMS9918 mode (screen2).  
* Save a PNG bitmap from display selected (tileset or Map).
* Load PNG, GIF or SC2 using Drag and Drop.   
* Viewer displays screen or tilesets.
* Selector of an area on the map screen.
* Position information (map coordinate, VRAM address and tile) on the display.    
* Tool to fill order screen map.
* Tool to fill the screen map with the specified tile.
* Tool to changing a tile to other.
* Tool to change one color to other.
* Optimize tool. Sort pattern/color data to enhance compression.
* Tool to invert graphic data.  
* Edit the color palette (V9938). Allows reading or save the palette independently.  
* Project info window. Editing project information: name, version, author, group and description.    
* Get the source code of all or part of the screen.
* Get the source code of one or more banks of tiles.
* Get the source code in different programming languages (MSX Basic, C, ASM and ASM SDCC).
* Output can be on Raw, RLE or [RLEWB](https://github.com/mvac7/Z80_RLEWB) compression.  


<br/>

---

## History

* v0.9b - First version.
  

<br/>

---

## Code Examples

The package includes a few examples of sources in C (SDCC) and assembler 
(asMSX), to test the data output and learning.

```                          
File List: (code_examples\)
   
  * test_asMSX
    Test_GFX.asm     <-- source 
    MAKEFILE.BAT     <-- Need asMSX assembler
    Test_GFX.rom     <-- 8k MSX ROM result (included)  

   
  * C (C\)
    src\Test_GFX.c   <-- C source 
    MAKEFILE.BAT     <-- Need SDCC compiler
    dist\TESTGFX.ROM <-- 16k MSX ROM result (included)
``` 