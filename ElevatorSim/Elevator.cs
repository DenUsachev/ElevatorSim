using System;
using System.Collections.Generic;
using System.Threading;

namespace ElevatorSim
{
    public class Elevator : IObservable<Elevator>
    {
        private readonly List<IObserver<Elevator>> _elevatorObservers;
        private bool _doorsClosed = true;

        public decimal Speed { get; }
        public decimal DoorsDelay { get; }
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

            Speed = speed;
            DoorsDelay = doorsDelay;
        }

        public void Arrive()
        {
            Status = ElevatorStatus.DoorsOpening;
            NotifyObservers();
            _doorsClosed = false;
            Thread.Sleep((int)(DoorsDelay * 1000));
            Status = ElevatorStatus.DoorsClosing;
            _doorsClosed = true;
            NotifyObservers();
        }

        public void SetFloor(int floor)
        {
            Status = ElevatorStatus.OnTheMove;
            CurrentFloor = floor;
            NotifyObservers();
        }

        public void Init(int floor)
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