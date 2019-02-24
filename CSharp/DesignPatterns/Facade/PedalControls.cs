using System;

namespace DesignPatterns.Facade
{
    public sealed class PedalControls
    {
        public double GasPedalLevel { get; private set; } = 0.0;

        public void SetGasPedal(double amount)
        {
            if (!(0.0 <= amount && amount <= 1.0)) throw new ArgumentOutOfRangeException();

            GasPedalLevel = amount;

            Console.WriteLine($"Gas pedal level: {100 * amount}%.");
        }

        public void Stop()
        {
            GasPedalLevel = 0.0;

            Console.WriteLine("Braking with brake pedal.");
        }
    }
}
