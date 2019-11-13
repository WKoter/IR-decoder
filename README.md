# IR-decoder
IR decoder to control multimedia programs on Windows.

Device based on microcontroller ATmega168A-PU (also match other uC from ATmega family in DIP28) which use IR detector to receive IR signals. The signal is transmitted with NEC IR protocol. ATmega send decoded signal to PC using converter UART-USB. On PC background application receives data and simulates multimedia key on Windows.


ATmega168A-PU settings:
F_CPU = 8000000UL
