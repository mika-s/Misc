using System;

namespace DesignPatterns.SimpleFactory
{
    public static class VehicleFactory
    {
        public static IVehicle CreateVehicle(string element)
        {
            if (element == "water")
            {
                return new Boat();
            }
            else if (element == "air")
            {
                return new Plane();
            }
            else if (element == "road")
            {
                return new Car();
            }
            else
            {
                throw new ArgumentException("Wrong type of element.");
            }
        }
    }
}
