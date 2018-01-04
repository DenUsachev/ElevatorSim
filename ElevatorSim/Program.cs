using System;
using System.Globalization;

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

            Console.WriteLine("Initial set-up is complete. Hit Enter to run simulation. Hit Q to stop simulation.");
            Console.ReadLine();
            _building.SetElevator(_elevator);
            Console.ReadLine();
        }

        private static decimal? ReadDecimalValueFromConsole(string input)
        {
            if (decimal.TryParse(input.Replace(',', '.'), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture,
                out decimal value))
            {
                return value;
            }
            return null;
        }

        private static int? ReadIntValueFromConsole(string input)
        {
            if (int.TryParse(input, out int value))
            {
                return value;
            }
            return null;
        }
    }
}