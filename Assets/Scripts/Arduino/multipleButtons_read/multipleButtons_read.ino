// Richard Ram

// make sure we keep the buttons in correct order
const int buttonPins[] = {2,3,4,5,6,7,8,9,10,11};
const int pinCount = 10;
int buttonStates[pinCount];

void setup() 
{
  for (int i = 0; i < pinCount; i++)
  {
    buttonStates[i] = 0; 
    pinMode(buttonPins[i], INPUT);
  }

  Serial.begin(9600);
}

void loop() 
{ int parseValue = 0;
  for (int i = 0; i < pinCount; i++) 
  {
    buttonStates[i] =  digitalRead(buttonPins[i]);

    // calculate button ID
    int data = ((i+1) * 10);

    // calculate if button is on or off
    data += buttonStates[i] ? 1 : 0;
 
    Serial.println(data);
    Serial.flush();
    delay(20);
  }   
}

/*
  Button

  Turns on and off a light emitting diode(LED) connected to digital pin 13,
  when pressing a pushbutton attached to pin 2.

  The circuit:
  - LED attached from pin 13 to ground
  - pushbutton attached to pin 2 from +5V
  - 10K resistor attached to pin 2 from ground

  - Note: on most Arduinos there is already an LED on the board
    attached to pin 13.

  created 2005
  by DojoDave <http://www.0j0.org>
  modified 30 Aug 2011
  by Tom Igoe

  This example code is in the public domain.

  http://www.arduino.cc/en/Tutorial/Button
*/

// constants won't change. They're used here to set pin numbers:
//const int buttonPin1 = 2;     // the number of the pushbutton pin
//const int buttonPin2 = 3;     // the number of the pushbutton pin
