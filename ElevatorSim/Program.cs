using System;

namespace ElevatorSim
{
    class Program
    {
        private static Building _building;
        private static Elevator _elevator;

        static void Main(string[] args)
        {
            Console.WriteLine("*** Elevator SIM ***");
            Console.WriteLine("Please, set the initial configuration: ");

            Console.WriteLine("Set the qty of floors in the building: ");
            var inputString = Console.ReadLine();
            var floors = ReadIntValueFromConsole(inputString);

            Console.WriteLine("Set the heigth of the floor (m): ");
            inputString = Console.ReadLine();
            var floorHeigth = ReadDecimalValueFromConsole(inputString);

            _building = new Building(floors.Value, floorHeigth.Value);

            Console.WriteLine("Set the elevator speed (m/s): ");
            inputString = Console.ReadLine();
            var elevatorSpeed = ReadDecimalValueFromConsole(inputString);

            Console.WriteLine("Set the door delay (sec): ");
            inputString = Console.ReadLine();
            var doorsDelay = ReadDecimalValueFromConsole(inputString);

            _elevator = new Elevator(elevatorSpeed.Value, doorsDelay.Value);
            _building.SetElevator(_elevator);

            Console.WriteLine("Initial set-up is complete.");
            Console.ReadLine();
        }

        static private decimal? ReadDecimalValueFromConsole(string input)
        {
            if (decimal.TryParse(input, out decimal value))
            {
                return value;
            }
            return null;
        }

        static private int? ReadIntValueFromConsole(string input)
        {
            if (int.TryParse(input, out int value))
            {
                return value;
            }
            return null;
        }
    }
}