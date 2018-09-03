using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse
{
    public interface ISwitchable
    {
        bool State { get;}

        void TurnOn();
        void TurnOff();
    }
}