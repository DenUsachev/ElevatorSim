using System;
using System.Collections.Generic;

namespace ElevatorSim
{
    class Unsubscriber<T> : IDisposable
    {
        private IList<IObserver<Elevator>> _observers;
        private IObserver<Elevator> _observer;

        public void Dispose()
        {
            if (_observers != null && _observers.Contains(_observer))
            {
                _observers.Remove(_observer);
            }
        }
    }
}
