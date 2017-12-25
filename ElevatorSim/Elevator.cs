namespace ElevatorSim
{
    class Elevator
    {
        public ElevatorStatus Status { get; set; }
        public decimal Speed { get; set; }
        public decimal OpenDoorsInterval { get; set; }

        public Elevator(decimal speed, decimal openDoorsInterval)
        {
            Status = ElevatorStatus.Idle;
            Speed = speed;
            OpenDoorsInterval = openDoorsInterval;
        }
    }
}
