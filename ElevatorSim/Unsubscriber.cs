using System;
using System.Collections.Generic;

namespace ElevatorSim
{
    class Unsubscriber : IDisposable
    {
        private List<IObserver<Elevator>> _observers;
        private IObserver<Elevator> _observer;

        public Unsubscriber(List<IObserver<Elevator>> observers, IObserver<Elevator> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (!(_observer == null))
                _observers.Remove(_observer);
        }
    }
}
