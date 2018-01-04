namespace ElevatorSim
{
    public class Elevator
    {
        public ElevatorStatus Status { get; set; }
        public decimal Speed { get; set; }
        public decimal DoorsDelay { get; set; }

        public Elevator(decimal speed, decimal doorsDelay)
        {
            Status = ElevatorStatus.Idle;
            Speed = speed;
            DoorsDelay = doorsDelay;
        }
    }
}