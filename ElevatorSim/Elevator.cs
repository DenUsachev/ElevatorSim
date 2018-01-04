using System;
using System.Collections.Generic;

namespace ElevatorSim
{
    public class Elevator : IObservable<Elevator>
    {
        private readonly List<IObserver<Elevator>> _elevatorObservers;
        private decimal _speed;
        private decimal _doorsDelay;
        private bool _doorsClosed = true;

        public ElevatorStatus Status { get; private set; }
        public int CurrentFloor { get; private set; }

        private void NotifyObservers()
        {
            foreach (var observer in _elevatorObservers)
            {
                observer.OnNext(this);
                if (_doorsClosed && Status == ElevatorStatus.Idle)
                {
                    observer.OnCompleted();
                }
            }
        }

        public Elevator(decimal speed, decimal doorsDelay)
        {
            _elevatorObservers = new List<IObserver<Elevator>>();

            _speed = speed;
            _doorsDelay = doorsDelay;
        }

        private void Move(int floor)
        {

        }

        public void Set(int floor)
        {
            Status = ElevatorStatus.Idle;
            CurrentFloor = 1;
            NotifyObservers();
        }

        public IDisposable Subscribe(IObserver<Elevator> observer)
        {
            if (!_elevatorObservers.Contains(observer))
            {
                _elevatorObservers.Add(observer);
            }
            return new Unsubscriber(_elevatorObservers, observer);
        }
    }
}