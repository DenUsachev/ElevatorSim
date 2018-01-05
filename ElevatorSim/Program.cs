using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace ElevatorSim
{
    class Program
    {
        private static Building _building;
        private static Elevator _elevator;
        private static bool _runningSimulation = false;

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

            Console.WriteLine("Initial set-up is complete. Hit Enter to run simulation.");
            Console.ReadLine();
            RunSimulator();
        }

        private static void RunSimulator()
        {
            Console.WriteLine("Simulator is running. Hit Q or q and then press Enter to stop simulation.");
            _building.SetElevator(_elevator);
            _runningSimulation = true;
            var inputRegex = new Regex(@"^(?<innerCall>\d{1,2}$)|^(?<control>q)$|^(?<control>Q)$|^(?<floorCall>L\d{1,2})$", RegexOptions.Compiled);
            while (_runningSimulation)
            {
                var userInput = Console.ReadLine();
                var regexMatch = inputRegex.Match(userInput);
                if (regexMatch.Success)
                {
                    if (regexMatch.Groups["control"].Success)
                    {
                        _runningSimulation = false;
                    }
                    else if (regexMatch.Groups["innerCall"].Success)
                    {
                        var floor = int.Parse(regexMatch.Groups["innerCall"].Value);
                        _building.MoveElevator(floor);
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input.");
                }
            }
            Console.WriteLine("\n\n*** Simulation terminated. Press any key to exit. ***");
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