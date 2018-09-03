using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Items
{
    class Boiler : IWarmingControl , ISwitchable , IWaterable
    {
        private readonly double MaxTemperature;
        private readonly double MinTemperature;

        private double CurrentWaterVolume;

        public double Temperature { get; private set; }        
        public bool State { get; private set; }
        public double MaxWaterVolume { get; private set; }

        public Boiler(double MaxTemp , double MinTemp , double MaxWaterVolume)
        {
            MaxTemperature = MaxTemp;
            MinTemperature = MinTemp;
            this.MaxWaterVolume = MaxWaterVolume;
            CurrentWaterVolume = 0.0;
            Temperature = 5.0;
        }
    
        public void FillUp(double Water)
        {
            if (CurrentWaterVolume + Water > MaxWaterVolume)
                throw new Exception("Too much water");
            else
            {
                CurrentWaterVolume += Water;
            }
        }
        public void PourOut(double Water)
        {
            if (CurrentWaterVolume < Water)
            {
                Temperature = MinTemperature;
                CurrentWaterVolume = 0.0;
            }
            else
            {
                CurrentWaterVolume -= Water;
            }
            if(CurrentWaterVolume == 0.0)
                Temperature = MinTemperature;
        }

        public void Increase(double Temperature)
        {
            if (!State)
                throw new Exception("Devise if Off");
            else
            {
                if (this.Temperature + Temperature > MaxTemperature)
                    throw new Exception("Too high Temperature");
                else
                {
                    this.Temperature += Temperature;
                }
            }
        }
        public void Reduce(double Temperature)
        {
            if (!State)
                throw new Exception("Devise if Off");
            else
            {
                if (this.Temperature - Temperature <= 5.0)
                    throw new Exception("Too high Temperature");
                else
                {
                    this.Temperature -= Temperature;
                }
            }
        }

        public void TurnOff()
        {
            if (State)
                State = false;
        }
        public void TurnOn()
        {
            if (!State)
                State = true;
        }

        public void GetInfo()
        {
            Console.WriteLine("Temperature {0} \n State: {1}\n Max Water Volume {2}\n Current Water Volume {3}\n " , Temperature, State , MaxWaterVolume , CurrentWaterVolume);
        }
    }
}
