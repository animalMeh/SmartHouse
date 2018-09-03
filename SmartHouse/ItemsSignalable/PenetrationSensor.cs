using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse
{
    public class PenetrationSensor : ISignable , ISwitchable
    {
       public bool State { get; protected set; }
        
       public PenetrationSensor(IDoorControl MainDoor)
        {
            State = true;
            MainDoor.DoorOpened += Alarm;        
        }

       public void Alarm()
        {
            if(State == true)
                Console.WriteLine("Robbery!!!");
        }
     
       public void TurnOn()
        {
            State = true;
        }

       public void TurnOff()
        {
            State = false;
        }
    }
}