using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//открыть закрыть дверь
namespace SmartHouse
{
    public interface IDoorControl : ILockable
    {
        event Message.MessageTo DoorOpened;
    }
}