using System;
using System.Collections.Generic;
using System.Text;

namespace ElevatorSim
{
    struct Elevator
    {
        public ElevatorStatus Status { get; private set; }
        public decimal Speed { get; private set; }
        public decimal DoorsDelay { get; private set; }

        public Elevator(decimal speed, decimal doorsDelay)
        {
            Status = ElevatorStatus.Idle;
            Speed = speed;
            DoorsDelay = doorsDelay;
        }
    }
}
