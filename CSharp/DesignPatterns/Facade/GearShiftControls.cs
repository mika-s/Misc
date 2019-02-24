using System;

namespace DesignPatterns.Facade
{
    public sealed class GearShiftControls
    {
        private int gear = 1;

        public void IncreaseGear()
        {
            gear = Math.Min(5, gear + 1);
            PrintGear();
        }

        public void ReduceGear()
        {
            gear = Math.Max(1, gear - 1);
            PrintGear();
        }

        public void Stop()
        {
            gear = 1;
            PrintGear();
        }

        private void PrintGear()
        {
            string[] postfix = { "st", "nd", "rd", "th", "th" };
            Console.WriteLine($"The gear is in {gear}{postfix[gear - 1]}.");
        }
    }
}
