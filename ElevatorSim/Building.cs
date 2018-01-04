namespace ElevatorSim
{
    public class Building
    {
        public int FloorQty { get; set; }
        public decimal FloorHeigth { get; set; }
        public Elevator Elevator { get; set; }

        public Building(int floorQty, decimal floorHeigth)
        {
            FloorQty = floorQty;
            FloorHeigth = floorHeigth;
        }

        public void SetElevator(Elevator elevator)
        {
            Elevator = elevator;
        }
    }
}