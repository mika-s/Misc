using System;

namespace DesignPatterns.SimpleFactory
{
    public static class SimpleFactoryPattern
    {
        public static void TestSimpleFactory()
        {
            IVehicle audi = VehicleFactory.CreateVehicle("road");
            IVehicle a380 = VehicleFactory.CreateVehicle("air");
            IVehicle psv = VehicleFactory.CreateVehicle("water");

            Console.WriteLine($"{audi.Type}");
            Console.WriteLine($"{a380.Type}");
            Console.WriteLine($"{psv.Type}");
        }
    }
}
