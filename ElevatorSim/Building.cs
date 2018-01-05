﻿using System;
using System.Threading;

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
            Elevator.Init(FIRST_FLOOR);
        }

        public void CallElevator(int floor)
        {
            WaitElevator();
            if (floor == Elevator.CurrentFloor)
            {
                Elevator.Arrive();
            }
            else
            {
                MoveElevator(floor);
            }
        }

        public void MoveElevator(int floor)
        {
            if (floor > FloorQty || floor < FIRST_FLOOR)
            {
                throw new ArgumentException("Incorrect floor number", floor.ToString());
            }
            var movementModifier = floor > Elevator.CurrentFloor ? 1 : -1;
            while (Elevator.CurrentFloor != floor)
            {
                Thread.Sleep((int)Math.Round(FloorHeigth / Elevator.Speed * 1000));
                Elevator.SetFloor(Elevator.CurrentFloor + movementModifier);
            }
            Elevator.Arrive();
        }

        private void WaitElevator()
        {
            while (Elevator.Status != ElevatorStatus.Idle)
            {
                Thread.Sleep(100);
            }
        }
    }
}