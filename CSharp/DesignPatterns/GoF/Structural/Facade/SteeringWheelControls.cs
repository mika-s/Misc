using System;

namespace DesignPatterns.GoF.Structural.Facade
{
    public sealed class SteeringWheelControls
    {
        public void SetSteeringWheel(double amount)
        {
            if (!(-1.0 <= amount && amount <= 1.0)) throw new ArgumentOutOfRangeException();

            Console.WriteLine($"Wheel level: {100 * amount}%.");
        }

        public void Stop()
        {
            Console.WriteLine("Setting steering wheel center.");
        }
    }
}
