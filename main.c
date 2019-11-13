/*
 * main.c
 *
 *  Created on: 7 sty 2017
 *      Author: Wojtek
 */

#include "main.h"

volatile uint8_t  IR_recpos = 0;     //Nr aktualnie odbieranego bitu

volatile uint8_t koniec = 0;	//flaga konca poprawnego odbioru
volatile uint32_t dane = 0;		//odbierane dane
volatile uint32_t bufor = 0;	//bufor, gdzie przenoszone sa dane po odbiorze
uint8_t danePC = 0;

volatile enum IR_NEC_States IR_State = IR_NEC_Nothing;

typedef union
{
	uint32_t x;
	struct
	{
		uint8_t dane;
		uint8_t daneN;
		uint8_t adres;
		uint8_t adresN;
	};
} ZamienDane;

int main()
{
	//ustaw porty
	Ports_Init();
	//ustaw USART
	USART0_Init();
	//ustaw timer
	Timer1Init();
	//odblokuj przerwania
	sei();

	while(1)
	{
		//jesli odbior zakonczyl sie sukcesem
		if(koniec)
		{
			//skasuj flage
			koniec = 0;

			ZamienDane x;
			x.x = bufor;
			//sprawdz poprawnosc danych
			if(!(x.dane & x.daneN) && !(x.adres & x.adresN))
			{
				//wyslij dane
				USART0_Transmit(x.dane);
			}
		}
	}
}

/*
 * Ustawienie portów
 */
void Ports_Init()
{
	//wejœcie odbiornika IR
	DDRD &= ~(1 << PD2);
	//pull-up
	PORTD |= (1 << PD2);

	//pull-up nieu¿ywanych portów
	PORTD |= (1 << PD3) | (1 << PD4) | (1 << PD5) | (1 << PD6) | (1 << PD7);
	PORTC |= (1 << PC0) | (1 << PC1) | (1 << PC2) | (1 << PC3) | (1 << PC4) | (1 << PC5);
	PORTB = 0xFF;

	//ustaw przerwania zmiany stanu na pinie PD2 (INT0)
	//wykrycie zbocza opadajacego
	EICRA |= (1 << ISC01);
	EIMSK |= (1 << INT0);
}

/*
 * Przygotowanie interfejsu USART
 */
void USART0_Init()
{
	UCSR0B |= (1 << TXEN0); //w³¹czenie funkcji nadawczej na pinach

	//UCSR0C - automatycznie ustawiona transmisja asynchroniczna, wy³¹czony bit parzystoœci,
	//			jeden bit stopu
	UCSR0C |= (1 << UCSZ01) | (1 << UCSZ00); //przesy³anie 8-bitowej danej
	UBRR0 = 25; //ustawienie 19,2kbps, szybkosc transmisji
}

/*
 * Funkcja wysy³aj¹ca dane prze USART
 */
void USART0_Transmit(unsigned char data)
{
	//czekanie na pusty bufor danych
	while ( !( UCSR0A & (1<<UDRE0)) );
	//za³aduj dane do bufora, rozpocznij transmisjê
	UDR0 = data;
}

void Timer1Init()
{
	TCCR1B |= (1 << CS11) | (1 << CS10); //preskaler 64
	//TIMSK1 |= (1 << TOIE1); //w³¹czenie przerwania wy³owanego przepe³nieniem licznika
}

/*
 * Zamien czas w mikrosekundach na zliczenia timera, preskaler 64
 */
static inline uint16_t IR_CalcTime(uint32_t time)
{
	return time*(F_CPU/1000000UL)/64;
}

ISR(INT0_vect)
{
	//zapisz czas od ostatniego impulsu
	uint16_t czasImpulsu = TCNT1;
	TCNT1 = 0;

	switch(IR_State)
	{
		//wykrywanie rozpoczecia transmisji
		case IR_NEC_Nothing:
			//wykrywanie wszystkich zboczy
			EICRA &= ~(1 << ISC01);
			EICRA |= (1 << ISC00);

			IR_State = IR_NEC_Trailer;
			break;

		//wykrywanie preambulu
		case IR_NEC_Trailer:
			//porownaj czas imuplsu, z czasem preambuly
			if((czasImpulsu > IR_CalcTime((IR_NEC_PULSE - IR_NEC_TOLERANCE) * IR_NEC_TRAILER))  //Koniec odbioru trailera
					&& ((czasImpulsu < IR_CalcTime((IR_NEC_PULSE + IR_NEC_TOLERANCE) * IR_NEC_TRAILER))))
			{
				IR_State = IR_NEC_FirstBit;
			}
			//jesli preambula nie zostala wykryta
			//przygotuj do nastepnego odbioru
			else
			{
				IR_State = IR_NEC_Nothing;
				//wykrywanie tylko zboczy opadajacych
				EICRA |= (1 << ISC01);
				EICRA &= ~(1 << ISC00);
				IR_recpos = 0;
			}
			break;

			//pominiecie przerwy po preambule
		case IR_NEC_FirstBit:
			IR_State = IR_NEC_Receiving;
			//przelaczenia na wykrywanie zboczy opadajacych
			EICRA |= (1 << ISC01);
			EICRA &= ~(1 << ISC00);
			break;

		case IR_NEC_Receiving:
			//wykrywanie przes³ania "0"
			if((czasImpulsu > IR_CalcTime((IR_NEC_PULSE - IR_NEC_TOLERANCE) * IR_NEC_ZERO))
				&& ((czasImpulsu < IR_CalcTime((IR_NEC_PULSE + IR_NEC_TOLERANCE) * IR_NEC_ZERO))))
			{
				//zapisanie odczytanego bitu
				dane = dane << 1;
				dane &= ~0x00000001;
				IR_recpos++;
			}
			//wykrywanie przes³ania "1"
			else if((czasImpulsu > IR_CalcTime((IR_NEC_PULSE - IR_NEC_TOLERANCE) * IR_NEC_ONE))
					&& ((czasImpulsu < IR_CalcTime((IR_NEC_PULSE + IR_NEC_TOLERANCE) * IR_NEC_ONE))))
			{
				//zapisanie odczytanego bitu
				dane = dane << 1;
				dane |= 0x00000001;
				IR_recpos++;
			}
			//wkrywanie sygna³u powtórzenia, czas powtarzania wynosi ok. 108ms
			//zakresy zostaly dobrane eksperymentalnie
			else if(IR_recpos == 0 && (czasImpulsu > IR_CalcTime(95000))
					&& (czasImpulsu < IR_CalcTime(120000)))
			{
				IR_recpos = 0;
				IR_State = IR_NEC_Nothing;
				koniec = 1;

				//USART0_Transmit(0x41);
			}

			//odebranie wszystkich bitow
			if(IR_recpos == IR_BITSNO)
			{
				//przygotowanie do ponownego odbioru
				IR_recpos = 0;
				IR_State = IR_NEC_Nothing;
				bufor = dane;
				dane = 0;
				koniec = 1;

				//USART0_Transmit(0x45);
			}
			break;
	}
}
