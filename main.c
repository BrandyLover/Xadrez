#include <18F4550.h>
#device ADC=10

#FUSES NOWDT                    //No Watch Dog Timer
#FUSES WDT128                   //Watch Dog Timer uses 1:128 Postscale
#FUSES NOBROWNOUT               //No brownout reset
#FUSES NOLVP                    //No low voltage prgming, B3(PIC16) or B5(PIC18) used for I/O
#FUSES NOXINST                  //Extended set extension and Indexed Addressing mode disabled (Legacy mode)

#use delay(clock=48MHz,crystal=20MHz)

//Bluetooth
#use rs232(baud=9600,parity=N,xmit=PIN_c6,rcv=PIN_c7,bits=8,stream=BT)
int8        cont=0xff;
signed int8 sdata[3];
int1        sDataAvailable=0;

//Steep Motors
#define  fimDeCursoX    PIN_B0      //normalmente em nivel alto,
#define  fimDeCursoY    PIN_B1      //mas vai a nivel baixo quando precionado
signed int8    cX=0,cY=0;           //posição do motor
signed int16   passosX=0,passosY=0; //numero de passos a andar
unsigned int16 t=0,ta=0;            //tempo do timer 0
unsigned int8  outX,outY,out;       //saida para o driver
int1           movX=0,movY=0;       //motor em moimento

//Servo Motor
#define  servo PIN_C2
unsigned int8  servoContador=0;             //conta até 200 (20 ms)
unsigned int8  servoContador2=0;           //conta até 200 (20 ms)
unsigned int8  servoPos,servoPosNew;      //= n*0,1 ms

//cursor
struct pos{
    signed int    x;
    signed int    y;
    unsigned int  z;
};
struct pos destino;
struct pos origem;

#INT_RDA
void  RDA_isr(void) {
   int8 dado; 
   dado=getc(BT);
   if(cont==0xff){
      if(dado==0)
      cont=0;
   }
   else{
      sdata[cont]=dado;
      cont++;
      if(cont>2){
         putc(0x03,BT);
         putc(sdata[0],BT);
         putc(sdata[1],BT);
         putc(sdata[2],BT);
         destino.x=sdata[0];
         destino.y=sdata[1];
         destino.z=sdata[2];
         sDataAvailable=1;
         cont=0xff;
      }
   }
}

#INT_TIMER0
void  TIMER0_isr(void) {
   set_timer0(t);
   if(ta>0){                                     //acelerador
      t+=ta;       //substituir t por 35000 caso retido for a aceleração
      ta--;                                     //end_acelerador
   }
   
   if(input(fimDeCursoX)){                       //motorX
      origem.x=1;
      passosX=97; //53+44;
      t=0;
      ta=300;
      movX=1;
   }
   if(movX){
      if(passosX>0){
         cX--;
         passosX--;
         if(cX<0)
            cX=7;
      }else{
         if(passosX<0){
            cX++;
            passosX++;
            if(cX>7)
               cX=0;
         }else{
            movX=0;}
      }
      switch (cX){
         case 0:  //08
            outX=0x08;break;
         case 1:  //0A
            outX=0x0A;break;
         case 2:  //02
            outX=0x02;break;
         case 3:  //06
            outX=0x06;break;
         case 4:  //04
            outX=0x04;break;
         case 5:  //05
            outX=0x05;break;
         case 6:  //01
            outX=0x01;break;
         case 7:  //09
            outX=0x09;break;
      }
   }else
      outX=0x00;                                //end_motorX

   if(input(fimDeCursoY)){                      //motorY
      origem.y=1;
      passosY=62; //18+44;
      t=0;
      ta=300;
      movY=1;
   }
   if(movY){
      if(passosY>0){
         cY--;
         passosY--;
         if(cY<0)
            cY=7;
      }else{
         if(passosY<0){
            cY++;
            passosY++;
            if(cY>7)
               cY=0;
         }else{
            movY=0;}
      }
      switch (cY){
         case 0:  //08
            outY=0x80;break;
         case 1:  //0A
            outY=0xA0;break;
         case 2:  //02
            outY=0x20;break;
         case 3:  //06
            outY=0x60;break;
         case 4:  //04
            outY=0x40;break;
         case 5:  //05
            outY=0x50;break;
         case 6:  //01
            outY=0x10;break;
         case 7:  //09
            outY=0x90;break;
      }
   }else
      outY=0x00;                               //end_motorY

   out=outX+outY;
   output_d (out);
}

#INT_TIMER3
void  TIMER3_isr(void){
   set_timer3(65236);
   servoContador++;
   if(servoContador==servoPos){
      output_low(servo);
   }
   else{
      if(servoContador==200){
         servoContador=0;
         servoPos=servoPosNew;
         output_high(servo);
         servoContador2++;
         if(servoContador2==100){
            output_low(servo);
            setup_timer_3(T1_DISABLED);       //0.1 ms p/int
            servoContador2=0;
         }
      }
   }
}

#INT_EXT                   //sensivel à borda de subida
void  EXT_isr(void) {
   putc(0x01,BT);
   putc(passosX,BT);
}
#INT_EXT1                  //sensivel à borda de subida
void  EXT1_isr(void) {
   putc(0x01,BT);
   putc(passosY,BT);
}

void main(){
   setup_timer_0(RTCC_INTERNAL|RTCC_DIV_2);        //699 ms overflow /16

   clear_interrupt(int_rda); // Limpa interrupção de recebimento pendente
   enable_interrupts(INT_RDA);
   enable_interrupts(INT_TIMER0);
   enable_interrupts(INT_TIMER3);
   enable_interrupts(GLOBAL);
   enable_interrupts(INT_EXT);
   enable_interrupts(INT_EXT1);
   
   //<ini>
   servoPosNew=12;
   setup_timer_3(T3_INTERNAL | T3_DIV_BY_4);       //0.1 ms p/int
   delay_ms(300);
   origem.z=12;
   passosX=-1000;
   passosY=-1000;
   t=0;
   ta=300;
   movX=1;
   movY=1;
   //<!ini>
   
   servoPos=12;
   servoPosNew=12;
   origem.x=1;
   origem.y=1;
   
   /*while (movX||movY);
   delay_ms(100);   servoPosNew=18;
   setup_timer_3(T3_INTERNAL | T3_DIV_BY_4);       //0.1 ms p/int
   delay_ms(300);   origem.z=18;

   passosX=44;    passosY=44;
   t=0;           ta=300;
   movX=1;        movY=1;
   while (movX||movY);
   passosX=0;     passosY=88;
   t=0;           ta=300;
   movX=0;        movY=1; 
   while (movX||movY);
   passosX=44;    passosY=44;
   t=0;           ta=300;
   movX=1;        movY=1;
   */
   
   
   /*while(TRUE){
      if(sDataAvailable && !(movX||movY)){
         sDataAvailable=0;
         //passosX=(signed int16)(destino.X-origem.x)*88;
         //passosY=(signed int16)(destino.Y-origem.x)*88;
         passosX=(signed int16)(destino.X)*44;
         passosY=(signed int16)(destino.Y)*44;
         if(origem.z!=destino.z){
            servoPosNew=destino.z;
            setup_timer_3(T3_INTERNAL | T3_DIV_BY_4);       //0.1 ms p/int
            delay_ms(300);
            origem.z=destino.z;
         }
         t=0;
         ta=300;
         if (passosX != 0)
            movX=1;
         if (passosY != 0)
            movY=1;
         //origem.x=destino.x;
         //origem.y=destino.y;
      }
   }*/
   
   while(TRUE){
      if(sDataAvailable && !(movX||movY)){
         sDataAvailable=0;
            if(destino.z<14){
            servoPosNew=12;
            setup_timer_3(T3_INTERNAL | T3_DIV_BY_4);       //0.1 ms p/int
            origem.z=12;
            passosX=((signed int16)destino.x-origem.x)*88;
            passosY=((signed int16)destino.y-origem.y)*88;
            t=0;
            ta=300;
            if(passosX!=0)
               movX=1;
            if(passosY!=0)
               movY=1;
            origem.x=destino.x;
            origem.y=destino.y;
         }
         else{
            if(destino.z<20){
               servoPosNew=destino.z;
               setup_timer_3(T3_INTERNAL | T3_DIV_BY_4);       //0.1 ms p/int
               delay_ms(300);
               signed int dx,dy;
               signed int primeiro, segundo, terceiro, quarto, quinto, sexto;
               dx=destino.x-origem.x;
               dy=destino.y-origem.y;
               primeiro=1;  quinto=1;
               segundo=1;    sexto=1;
               if(dx==0){
                  primeiro=0;
                  quinto=0;
                  sexto*=-1;
               }else{
                  if(dx<0){
                     segundo*=-1;
                     sexto*=-1;
                  }
               }
               if(dy==0){
                  segundo=0;
                  sexto=0;
                  quinto*=-1;
               }else{
                  if(dy<0){
                     primeiro*=-1;
                     quinto*=-1;
                  }
               }
               terceiro = (dx*2) - (primeiro+quinto);
               quarto = (dy*2) - (segundo+sexto);
               passosX = ((signed int16)segundo)*44;
               passosY = ((signed int16)primeiro)*44;
               t=0;
               ta=300;
               if (passosX != 0)
                  movX=1;
               if (passosY != 0)
                  movY=1;  
               while (movX||movY);     //primeiro e segundo
               passosX = ((signed int16)terceiro)*44;
               if(passosX != 0){
                  t = 0;
                  ta = 300;
                  movX = 1;
               }  
               while (movX);     //terceiro
               passosY = ((signed int16)quarto)*44;
               if (passosY != 0){
                  t = 0;
                  ta = 300;
                  movY = 1;
               } 
               while (movY);     //quarto
               passosX = ((signed int16) sexto)*44;
               passosY = ((signed int16)quinto)*44;
               t = 0;
               ta = 300;
               if (passosX != 0)
                  movX=1;
               if (passosY != 0)
                  movY=1;
            }                          //quinto e sexto
         }
         origem.x=destino.x;
         origem.y=destino.y;
         origem.z=12;
         while (movX||movY);
            servoPosNew=12;
            setup_timer_3(T3_INTERNAL | T3_DIV_BY_4);       //0.1 ms p/int
      }
   }
}


/*
A = 97
B = 97 + 88
C = 97 + 88 * 2
D = 97 + 88 * 3
E = 97 + 88 * 4
F = 97 + 88 * 5
G = 97 + 88 * 6
H = 97 + 88 * 7
I = 2
J = 97 + 88 * 7 + 105
*/
