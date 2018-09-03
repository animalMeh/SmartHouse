using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse
{
    public interface IWarmingControl : ITemperature
    {
        void Increase(double Temperature);
        void Reduce(double Temperature);
   
    }
}