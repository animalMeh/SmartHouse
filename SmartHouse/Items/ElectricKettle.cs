using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*NeedsToChange*/
namespace SmartHouse.Items
{
    class ElectricKettle : IWaterable, ISwitchable
    {      

        private readonly uint BowlTime;

        private double CurrentVolumeWater;

        private const double MinWaterToBoil = 0.5;//litres
        private const double MinWaterToHeat = 0.2;//litres

        public double Temperature { get; private set; } // water inside
        public bool State { get; private set; }

        public double MaxWaterVolume { get; private set; }

        public WaterState WaterState;

        public ElectricKettle(double MaxWaterVolume, uint TimeInSecBowl)
        {
            if (MaxWaterVolume <= 0.9 || TimeInSecBowl <= 10.0)
         
            BowlTime = TimeInSecBowl;
            this.MaxWaterVolume = MaxWaterVolume;
            Temperature = (double)WaterState.Typical;
            WaterState = WaterState.Typical;
        }

        public void FillUp(double Water)
        {

            if (CurrentVolumeWater + Water > MaxWaterVolume)
                throw new Exception("Too much water");
            else
            {
                CurrentVolumeWater += Water;
                if (Water >= CurrentVolumeWater && WaterState >= WaterState.Hot)
                {
                    Temperature = (double)WaterState.Hot;
                    WaterState = WaterState.Hot;
                }
                else
                {
                    Temperature = (double)WaterState.Typical;
                    WaterState = WaterState.Typical;
                }
            }
        }

        public void Boil()
        {
            if (State)
            {
                if (Temperature != 100.0)
                {
                    if (CurrentVolumeWater <= 0.9)
                        throw new Exception("Can't boil little water");
                    Temperature = (double)WaterState.Boiled;
                    WaterState = WaterState.Boiled;
                }
                else Console.WriteLine("Water inside is boiled");
            }
            else throw new Exception("Kettle if OFF");
        }

        public void Heat()
        {

            if (State)
            {
                if (Temperature < 50.0)
                {
                    if (CurrentVolumeWater <= 0.9)
                        throw new Exception("Can't heat little water");
                    Temperature = (double)WaterState.Hot;
                    WaterState = WaterState.Hot;
                }
                else Console.WriteLine("Water inside is hot");
            }
            else throw new Exception("Kettle if OFF");

        }
        
        public void PourOut()
        {
            Temperature =(double)WaterState.Typical;
            WaterState = WaterState.Typical;
            CurrentVolumeWater = 0.0;
        }

        public void TurnOn()
        {
            if (!State)
                State = true;
        }

        public void TurnOff()
        {
            if (State)
                State = false;
        }

        public void ShowSituation()
        {
            Console.WriteLine("Max water volume: {0} \nBowlTime: {1} \nCurrent Water Volume: {2}\nKettleState: {3}\nWater Inside State: {4}\nTemperature: {5}\n", 
                MaxWaterVolume, BowlTime, CurrentVolumeWater, State, WaterState , Temperature);
        }

    }
}
