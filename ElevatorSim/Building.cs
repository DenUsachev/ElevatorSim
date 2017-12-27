﻿namespace ElevatorSim
{
    class Building
    {
        public int FloorQty { get; private set; }
        public decimal FloorHeigth { get; private set; }
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