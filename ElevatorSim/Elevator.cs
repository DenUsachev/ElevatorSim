using System;
using System.Collections.Generic;
using System.Text;

namespace ElevatorSim
{
    public class Elevator
    {
        public ElevatorStatus Status { get; private set; }
        public decimal Speed { get;  }
        public decimal DoorsDelay { get; }

        public Elevator(decimal speed, decimal doorsDelay)
        {
            Status = ElevatorStatus.Idle;
            Speed = speed;
            DoorsDelay = doorsDelay;
        }

        public void Move(int floor)
        {
            Status = ElevatorStatus.OnTheMove;
        }
    }
}
