using System;

namespace ElevatorSim
{
    public class ElevatorController : IObserver<Elevator>
    {
        private Elevator _elevator;

        public void OnCompleted()
        {
            if (_elevator != null)
            {
                Console.WriteLine("Elevator is on the floor: {0}.", _elevator.CurrentFloor);
            }
            Console.WriteLine("Elevator is Idle.");
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Elevator value)
        {
            if (_elevator == null)
            {
                _elevator = value;
            }
            switch (_elevator.Status)
            {
                case ElevatorStatus.DoorsClosing:
                    Console.WriteLine("Elevator's doors are closing.");
                    break;
                case ElevatorStatus.DoorsOpening:
                    Console.WriteLine("Elevator's doors are opening.");
                    break;
                case ElevatorStatus.OnTheMove:
                    Console.WriteLine("Elevator is moving. Current floor: {0}", _elevator.CurrentFloor);
                    break;
                case ElevatorStatus.Idle:
                    break;
                default:
                    throw new Exception("Error: elevator is in unknown state.");
            }
        }
    }
}