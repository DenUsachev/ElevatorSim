using System;
using System.Collections.Generic;

namespace ElevatorSim
{
    class ElevatorHandler : IObservable<Elevator>
    {
        private List<IObserver<Elevator>> _observers;

        public ElevatorHandler()
        {
            _observers = new List<IObserver<Elevator>>();
        }

        public IDisposable Subscribe(IObserver<Elevator> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);

            return new Unsubscriber(_observers, observer);
        }
    }
}
