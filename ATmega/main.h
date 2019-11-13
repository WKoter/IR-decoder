/*
 * main.h
 *
 *  Created on: 7 sty 2017
 *      Author: Wojtek
 */

#ifndef MAIN_H_
#define MAIN_H_

//define F_CPU = 8000000UL

#include <avr/io.h>
#include <avr/interrupt.h>
#include <avr/pgmspace.h>


#define IR_NEC_PULSE        560  //Czas w us podstawowego interwa³u
#define IR_NEC_TOLERANCE    100  //Tolerancja czasu w us
#define IR_NEC_TRAILER      16   //Start ramki - 16 interwa³ów
#define IR_NEC_ZERO         2    //Czas trwania bitu 0
#define IR_NEC_ONE          4    //Czas trwania bitu 1
#define IR_BITSNO           32   //Liczba bitów kodu
#define IR_NEC_RPTLASTCMD   -1   //Kod powtórzenia ostatniego polecenia

enum IR_NEC_States {IR_NEC_Nothing, IR_NEC_Trailer, IR_NEC_FirstBit, IR_NEC_Receiving};

//kody wysylane do PC
//#define SLEEP_PC		0x5F
//#define MUTE_PC			0xAD
//#define VOLUME_DOWN_PC	0xAE
//#define VOLUME_UP_PC	0xAF
//#define NEXT_TRACK_PC	0xB0
//#define PREV_TRACK_PC	0xB1
//#define STOP_PC			0xB2
//#define PLAY_PAUSE_PC	0xB3

//const __flash uint8_t play_pause = 0xB3;

//kody odczytywane przez IR
//#define SLEEP			0xAD
//#define MUTE			0x9D
//#define VOLUME_DOWN		0x1F
//#define VOLUME_UP		0x57
//#define NEXT_TRACK		0xFD
//#define PREV_TRACK		0xDD
//#define STOP			0x1D
//#define PLAY_PAUSE		0x3D


void Ports_Init();
void USART0_Init();
void USART0_Transmit(unsigned char data);

void Timer1Init();

#endif /* MAIN_H_ */
