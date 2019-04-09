using System;

namespace DesignPatterns.GoF.Structural.Facade
{
    /// <summary>
    /// A facade that serves as a front-facing interface for the sub parts.
    /// </summary>
    public sealed class CarControls
    {
        private PedalControls pedals = new PedalControls();
        private SteeringWheelControls steeringWheel = new SteeringWheelControls();
        private GearShiftControls gearShift = new GearShiftControls();

        public void DriveForward()
        {
            Console.WriteLine("Starting slow.");
            pedals.SetGasPedal(0.3);
            steeringWheel.SetSteeringWheel(0.0);

            Console.WriteLine("More gas, increase gear.");
            pedals.SetGasPedal(0.5);
            gearShift.IncreaseGear();

            Console.WriteLine("Even more gas, increase gear.");
            pedals.SetGasPedal(0.7);
            gearShift.IncreaseGear();
        }

        public void TurnLeft()
        {
            double gasPedalLevel = pedals.GasPedalLevel;

            pedals.SetGasPedal(0.5 * gasPedalLevel);
            steeringWheel.SetSteeringWheel(-0.5);
            gearShift.ReduceGear();

            Console.WriteLine("Turn finished.");

            steeringWheel.SetSteeringWheel(0.0);
            pedals.SetGasPedal(gasPedalLevel);
            gearShift.IncreaseGear();
        }

        public void TurnRight()
        {
            double gasPedalLevel = pedals.GasPedalLevel;

            pedals.SetGasPedal(0.5 * gasPedalLevel);
            steeringWheel.SetSteeringWheel(0.5);
            gearShift.ReduceGear();

            Console.WriteLine("Turn finished.");

            steeringWheel.SetSteeringWheel(0.0);
            pedals.SetGasPedal(gasPedalLevel);
            gearShift.IncreaseGear();
        }

        public void StopCar()
        {
            pedals.Stop();
            steeringWheel.Stop();
            gearShift.Stop();
        }
    }
}
