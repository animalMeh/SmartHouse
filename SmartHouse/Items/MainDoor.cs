using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    class MainDoor : IDoorControl
    {
        private const bool CLOSED = false;
        private const bool OPENED = true;

        public event Message.MessageTo DoorOpened;

        public bool State { get; protected set; }

        bool Changed;

        public MainDoor()
        {
            State = CLOSED;
        }

        public void Close()
        {
            if (State)
            {
                Changed = true;
                State = CLOSED;
            }
        }

        public void Open(bool legal)
        {
            Open();
            if (legal == false  && Changed == true)
                DoorOpened?.Invoke();
        }

        public void Open()
        {
            if (!State)
            {
                State = OPENED;
                Changed = true;
            }
            else Changed = false;
        }

    }
}
