namespace ElevatorSim
{
    public class Building
    {
        private const int FIRST_FLOOR = 1;
        private readonly ElevatorController _controller;

        public int FloorQty { get; set; }
        public decimal FloorHeigth { get; set; }
        public Elevator Elevator { get; set; }

        public Building(int floorQty, decimal floorHeigth)
        {
            FloorQty = floorQty;
            FloorHeigth = floorHeigth;
            _controller = new ElevatorController();
        }

        public void SetElevator(Elevator elevator)
        {
            elevator.Subscribe(_controller);
            Elevator = elevator;
            Elevator.Set(FIRST_FLOOR);
        }
    }
}