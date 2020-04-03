/* ==========================================================================
                                                                           
unRLEWBtoVRAM.h                                                                                                                                

 WB RLE  v1.1

 $80 nn dd            ; run of n consecutive identical bytes ($1>$FE), value dd
 $80 $0               ; for one $80 value
 $80 $FF              ; end of data block
 <any other value>    ; raw data                                                               

========================================================================== */
#ifndef  __UNWBRLE2VRAM_H__
#define  __UNWBRLE2VRAM_H__

#include "../include/newTypes.h"


/* ===========================================================================
Function : RLE to VRAM unpacker
Input    : address of Data               
           address of VRAM
                       
=========================================================================== */
extern void unRLEWBtoVRAM (uint, uint);





#endif