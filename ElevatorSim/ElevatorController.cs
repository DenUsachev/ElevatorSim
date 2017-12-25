using System;
using System.Collections.Generic;
using System.Text;

namespace ElevatorSim
{
    class ElevatorHandler : IObservable<Elevator>
    {
        private IObserver<Elevator> _elevatorController;
        private readonly Elevator _elevator;

        public ElevatorHandler(Elevator elevator)
        {
            _elevator = elevator;
        }

        public IDisposable Subscribe(IObserver<Elevator> observer)
        {
            if (_elevatorController == null)
            {
                _elevatorController = observer;
                _elevator.Status = ElevatorStatus.Idle;
                observer.OnNext(_elevator);
            }
            return new Unsubscriber<Elevator>();
        }
    }


}
