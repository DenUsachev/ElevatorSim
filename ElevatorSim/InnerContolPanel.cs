using System;
using System.Collections.Generic;

namespace ElevatorSim
{
    public class InnerContolPanel : IObservable<Elevator>
    {
        private readonly List<IObserver<Elevator>> _elevatorObservers;
        
        public InnerContolPanel()
        {
            _elevatorObservers = new List<IObserver<Elevator>>();
        }

        public IDisposable Subscribe(IObserver<Elevator> observer)
        {
            if (!_elevatorObservers.Contains(observer))
            {
                _elevatorObservers.Add(observer);
            }
            return new Unsubscriber(_elevatorObservers, observer);
        }

        public void ExecuteCommand(ElevatorCommand command)
        {
            
        }
    }
}