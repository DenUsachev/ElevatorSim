using System;

namespace ElevatorSim
{
    internal static class ConsoleHelper
    {
        internal static async void FormattedOutputAsync(string value, params object[] args)
        {
            var formattedString = string.Format(value, args);
            await Console.Out.WriteLineAsync(formattedString);
        }
    }
}
