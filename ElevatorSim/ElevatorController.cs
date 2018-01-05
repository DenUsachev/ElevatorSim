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
                ConsoleHelper.FormattedOutputAsync("[{0:T}]Elevator is on the floor: {1}.", DateTime.Now, _elevator.CurrentFloor);
            }
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(Elevator value)
        {
            if (_elevator == null)
            {
                _elevator = value;
            }
            switch (_elevator.Status)
            {
                case ElevatorStatus.DoorsClosed:
                    ConsoleHelper.FormattedOutputAsync("[{0:T}]Elevator's doors are closed.", DateTime.Now);
                    break;
                case ElevatorStatus.DoorsOpen:
                    ConsoleHelper.FormattedOutputAsync("[{0:T}]Elevator's doors are open.", DateTime.Now);
                    break;
                case ElevatorStatus.OnTheMove:
                    ConsoleHelper.FormattedOutputAsync("[{0:T}]Elevator is moving. Current floor: {1}", DateTime.Now, _elevator.CurrentFloor);
                    break;
                case ElevatorStatus.Idle:
                    break;
                default:
                    throw new Exception("Error: elevator is in unknown state.");
            }
        }
    }
}