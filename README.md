# Codingan IoT Untuk membuat Aplikasi pendeteksi detak jantung

int PulseSensorPurplePin0 = 0;       
int LED13 = D7;  

int Signal_In;               
int PulseIR;
int Threshold = 2400;           
int PulseCounter = 0;   
int PulseState = 0;         
int lastPulseState = 0;     
int LastPulseCounter=0;
//int alert_state = OFF;
float SetFlowRate = 0;
int state = 1013;
int lastState = 1013;
unsigned long timelatest = 0;
double FlowRate = 0;
unsigned long timeoldest = 0;
unsigned long period = 0;
int i;
int touch_state = 0;
int touch_lastState = 0;
unsigned long touch_timelatest = 0;
unsigned long touch_timeoldest = 0;



void setup() {
  Particle.variable("rate", FlowRate);
}

void loop() {

 Signal_In = analogRead(PulseSensorPurplePin0);  

 CalculateFlowRate();
   
   if(Signal_In > Threshold){                          
     digitalWrite(LED13,HIGH);         
     PulseIR = 1;
   } else {
     digitalWrite(LED13,LOW);                
     PulseIR = 0;
   }
   

 PulseState = PulseIR;

  if (PulseState != lastPulseState) {
    if (PulseState == 1) {
      PulseCounter++;
      
    } 
    else {

    }
  }
 
  lastPulseState = PulseState;

//--------------------------------  

delay(10);
 
   
}


 void CalculateFlowRate(void) { 
   
 if (PulseCounter != LastPulseCounter)
  {
    timelatest = micros();
    period = timelatest - timeoldest;

      FlowRate = (float)(1000*1000%60)  / (timelatest - timeoldest);
      
      timeoldest = timelatest;
 
  }
 timeoldest = timelatest;
LastPulseCounter = PulseCounter;
   
 }
