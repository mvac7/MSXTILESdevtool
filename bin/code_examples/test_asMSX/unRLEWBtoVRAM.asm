;system vars
MSXVER     EQU $002D

;constants  
VDPVRAM    EQU   $98 ;VRAM Data (Read/Write)
VDPSTATUS  EQU   $99 ;VDP Status Registers

RLECONTROL EQU   $80


;===========================================================================
; unRLEWBtoVRAM v1.1 (26 jun 2014)
; Function : Unpack WB RLE to VRAM
;     
; Input    : HL - source RAM RLE data address
;            DE - target VRAM address
;
; $80 nn dd            ; run of n consecutive identical bytes ($1>$FE), value dd
; $80 $0               ; for one $80 value
; $80 $FF              ; end of data block
; <any other value>    ; raw data             
;=========================================================================== 
unRLEWBtoVRAM:
  ; set VRAM addr 
  in    A,[VDPSTATUS]
  
  di
  ld   A,[MSXVER]
  or   A
  jr   Z,setVADDR  ;if MSX1 -> TMS9918
  ;V9938 or higher
  xor  A
  out  [$99],A
  ld   A,$8E
  out  [$99],A

setVADDR:  
  ld    A,E    
  out   [VDPSTATUS],A
  ld    A,D        
  and   $3F
  or    $40
  out   [VDPSTATUS],A
  ei
  
ANALYZE:
  ld    A,[HL]         ; get byte
  cp    RLECONTROL                      
  jr    NZ,WriteByte   ; if raw
  
  inc   HL             ; get next byte 
  ld    A,[HL]
  or    A              
  jr    Z,WriteCONTROL ;if A=0 then write one $80  ($80 $0)
  cp    $FF            ;if A=$FF ($80 $FF)
  ret   Z              ;then exit
  
  ;$80 nn dd
  inc   A              ;2 to 255
  ld    B,A            
  inc   HL
  ld    A,[HL]         ;get value
  
doRLE:
  out   [VDPVRAM],A    ;write in VRAM     
  nop
  nop
  djnz  doRLE
  
  inc   HL
  jr    ANALYZE

WriteCONTROL:
  ld    A,RLECONTROL  ;write CONTROL value
  
WriteByte:
  out   [VDPVRAM],A   ;write in VRAM
  ;nop
  inc   HL
  jr    ANALYZE