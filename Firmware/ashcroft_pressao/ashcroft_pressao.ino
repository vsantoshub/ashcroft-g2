#include <stdlib.h>
#include <stdio.h>
//ARDUINO NANO

//const int BUZZER = 8;
const uint16_t N_AMOSTRAS = 10;
const uint16_t UART_COM_INTERVAL = 10;//ms <-> 1kHz
uint32_t leitura_ad = 0;
uint16_t media = 0;
byte tx_data[4];
byte msb, lsb = 0;
//temporizacoes
uint64_t send_data_interval = 0; //ms
uint64_t tempo_ms = 0;
byte i = 0;

void setup() {
//  pinMode(BUZZER, OUTPUT); //buzzer nao utilizado neste prototipo
//  digitalWrite(BUZZER, HIGH);
  Serial.begin(115200); 
}

void loop() {
  tempo_ms = millis();
   if ((tempo_ms - send_data_interval) >= UART_COM_INTERVAL) {
      
      for (i=0; i< N_AMOSTRAS; i++) {
        leitura_ad += analogRead(A0);
       }
       media = (uint16_t) leitura_ad/N_AMOSTRAS;
       msb = (byte) ((media >> 8) & 0xFF);
       lsb = (byte)(media & 0xFF);
       leitura_ad = analogRead(A0);
       tx_data[0] = 0x1F;
       tx_data[1] = msb;
       tx_data[2] = lsb;
       tx_data[3] = 0xAA;
       Serial.write(tx_data, sizeof(tx_data));
       tx_data[0]=tx_data[1]=tx_data[2]=tx_data[3] = 0;
       msb = lsb = media = leitura_ad = 0; 

   
      send_data_interval = tempo_ms;
    }
}
