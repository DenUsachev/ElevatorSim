using System;

namespace ElevatorSim
{
    public class CallCommand : IElevatorCommand
    {
        public Elevator _elevator { get; }
        
        public void Execute()
        {
            Console.WriteLine("Elevator has been called.");
            _elevator.Status = ElevatorStatus.OnTheMove;
        }
    }
}