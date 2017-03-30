using System;
using System.Text.RegularExpressions;

namespace RegexTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFromConsole = Console.ReadLine();

            // Testing if variable matches a regular expression: Regex.IsMath(string, regex).
            if (Regex.IsMatch(inputFromConsole, @"^[a-zA-Z0-9]+$") == true)
                Console.WriteLine("Input containing small letters, capital letters and numbers.");
            else
                Console.WriteLine("Not match.");
        }
    }
}
