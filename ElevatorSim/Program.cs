using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;

namespace ElevatorSim
{
    class Program
    {
        private static readonly CancellationTokenSource TokenSource = new CancellationTokenSource();
        private static readonly CancellationToken Token = TokenSource.Token;

        private static Building _building;
        private static Elevator _elevator;
        private static bool _runningSimulation = false;

        private const int MIN_FLOOR_QTY = 5;
        private const int MAX_FLOOR_QTY = 20;

        static void Main(string[] args)
        {
            Console.WriteLine("*** Elevator SIM ***");
            Console.WriteLine("Please, set the initial configuration: ");

            var floors = 0;
            do
            {
                ReadParamFromConsole($"Set the qty of floors in the building (from {MIN_FLOOR_QTY} to {MAX_FLOOR_QTY}): ", ReadIntValuePackedFromConsole,
                    out floors);
            } while (floors < MIN_FLOOR_QTY || floors > MAX_FLOOR_QTY);

            ReadParamFromConsole("Set the heigth of the floor (m): ", ReadDecimalValuePackedFromConsole, out decimal floorHeigth);
            ReadParamFromConsole("Set the elevator speed (m/s): ", ReadDecimalValuePackedFromConsole, out decimal elevatorSpeed);
            ReadParamFromConsole("Set the door delay (sec): ", ReadDecimalValuePackedFromConsole, out decimal doorsDelay);

            _building = new Building(floors, floorHeigth);
            _elevator = new Elevator(elevatorSpeed, doorsDelay);

            Console.WriteLine("Initial set-up is complete. ");
            PrintHelp();
            Console.ReadLine();
            RunSimulator();
        }

        private static void PrintHelp()
        {
            Console.WriteLine("*** HELP ***");
            Console.WriteLine("[Enter]: run simulation.");
            Console.WriteLine("N[Enter]: where N is between min and max floor number: elevator activation from the inside.");
            Console.WriteLine("LN[Enter]: where N between min and max floor number: elevator activation from the outside (from the floor N).");
            Console.WriteLine("q[Enter] or Q[Enter]: Terminate the simulation.");
            Console.WriteLine(Environment.NewLine);
        }

        private static void ReadParamFromConsole<T>(string caption, Func<string, object> validator, out T result)
        {
            object res;
            do
            {
                Console.WriteLine(caption);
                var inputString = Console.ReadLine();
                res = validator(inputString);
                if (res == null)
                    Console.WriteLine("Incorrect input. Try again.");

            } while (!(res is T));
            result = (T)res;
        }

        private static void RunSimulator()
        {
            Console.WriteLine("Simulator is running.");
            _building.InitElevator(_elevator);
            _runningSimulation = true;
            var inputRegex = new Regex(@"^(?<innerCall>\d{1,2}$)|^(?<control>q)$|^(?<control>Q)$|^(?<floorCall>L\d{1,2})$", RegexOptions.Compiled);

            while (_runningSimulation)
            {
                var userInput = Console.ReadLine();
                var regexMatch = inputRegex.Match(userInput);
                if (regexMatch.Success)
                {
                    try
                    {
                        if (regexMatch.Groups["control"].Success)
                        {
                            _runningSimulation = false;
                        }
                        else
                        {
                            int floor;
                            if (regexMatch.Groups["innerCall"].Success)
                            {
                                floor = int.Parse(regexMatch.Groups["innerCall"].Value);
                                _building.MoveElevator(floor);
                            }
                            else if (regexMatch.Groups["floorCall"].Success)
                            {
                                floor = int.Parse(regexMatch.Groups["floorCall"].Value.Substring(1));
                                _building.CallElevator(floor);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        ConsoleHelper.FormattedOutputAsync("Incorrect action: {0}", e.Message);
                    }
                }
                else
                {
                    ConsoleHelper.FormattedOutputAsync("Incorrect input.");
                }
            }
            _building.Dispose();
            Console.WriteLine($"{Environment.NewLine}*** Simulation terminated. ***");
            Environment.Exit(0);
        }

        private static object ReadDecimalValuePackedFromConsole(string input)
        {
            if (decimal.TryParse(input.Replace(',', '.'), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal value))
            {
                return value;
            }
            return null;
        }

        private static object ReadIntValuePackedFromConsole(string input)
        {
            if (int.TryParse(input, out int value))
            {
                return value;
            }
            return null;
        }
    }
}