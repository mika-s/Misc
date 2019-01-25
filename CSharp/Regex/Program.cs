using System;
using System.Text.RegularExpressions;

/*
 * Hierarchy:
 * 
 *      Match
 *       |-> Group
 *            |-> Capture
 * */

namespace RegexTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFromConsole = Console.ReadLine();

            // Testing if variable matches a regular expression: Regex.IsMatch(input:string, pattern:string).
            if (Regex.IsMatch(inputFromConsole, @"^[a-zA-Z0-9]+$") == true)
                Console.WriteLine("[Regex.IsMatch()]: Input containing small letters, capital letters and numbers.");
            else
                Console.WriteLine("[Regex.IsMatch()]: Not match.");

            // Using Regex object initialized first and then the Match class.
            Regex regex = new Regex(@"^[a-zA-Z0-9]+$");
            Match match = regex.Match(inputFromConsole);

            if (match.Success)
                Console.WriteLine("[regex.Match()]: Input containing small letters, capital letters and numbers.");
            else
                Console.WriteLine("[regex.Match()]: Not match.");

            // Capturing values using captures without going through groups.
            string inputFromConsole2 = Console.ReadLine();
            Regex captureRegex = new Regex(@"^test-(\d{2})-test$");
            Match captureMatch = captureRegex.Match(inputFromConsole2);

            if (captureMatch.Success)
                foreach (Capture capture in captureMatch.Captures)
                    Console.WriteLine($"[captures]: Captured {capture.Value}");
            else
                Console.WriteLine("[captures]: Not match.");

            // Capturing values using groups.
            string inputFromConsole3 = Console.ReadLine();
            Regex groupRegex = new Regex(@"^test-(\d{2})-test$");
            Match groupMatch = groupRegex.Match(inputFromConsole3);

            if (groupMatch.Success)
                foreach (Group group in groupMatch.Groups)
                    Console.WriteLine($"[groups]: Grouped {group.Value}");
            else
                Console.WriteLine("[groups]: Not match.");
        }
    }
}
