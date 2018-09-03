using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    class Program
    {

        static void Main(string[] args)
        {
            MainDoor MainDoor = new MainDoor();
            PenetrationSensor Alarm = new PenetrationSensor(MainDoor);
            MainDoor.Open(false);
            Items.ElectricKettle Kettle = new Items.ElectricKettle(5.0, 10);
            Items.Boiler Boiler = new Items.Boiler(40.0, 5.0, 10.0);
            Boiler.GetInfo();
            Boiler.TurnOn();
            Boiler.FillUp(6.5);
            Boiler.Increase(10.0);
            Boiler.FillUp(3.2);
            Boiler.Increase(15.2);
            Boiler.GetInfo();
            Boiler.PourOut(Boiler.MaxWaterVolume);
            Boiler.GetInfo();
            Boiler.FillUp(10.0);
            Boiler.Increase(25.0);
            Boiler.PourOut(5.0);
            Boiler.GetInfo();
        }
    }
}
