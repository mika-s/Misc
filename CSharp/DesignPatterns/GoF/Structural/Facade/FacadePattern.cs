using System;

namespace DesignPatterns.GoF.Structural.Facade
{
    /// <summary>
    /// Provides a simplified interface.
    /// 
    /// Will use CarControls rather than its subcomponents:
    ///     - GearShiftControls
    ///     - PedalControls
    ///     - SteeringWheelControls
    /// </summary>
    public static class FacadePattern
    {
        public static void TestFacadePattern()
        {
            var carControls = new CarControls();

            Console.WriteLine("Drive forward:");
            carControls.DriveForward();

            Console.WriteLine("\nTurn left:");
            carControls.TurnLeft();

            Console.WriteLine("\nTurn right:");
            carControls.TurnRight();

            Console.WriteLine("\nStopping the car:");
            carControls.StopCar();
        }
    }
}
