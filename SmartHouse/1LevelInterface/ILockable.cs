using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse
{
    public interface ILockable
    {
        bool State { get; }
        void Open();
        void Close();
    }
}