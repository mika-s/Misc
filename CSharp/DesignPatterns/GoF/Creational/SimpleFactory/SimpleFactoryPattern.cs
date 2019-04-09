using System;

namespace DesignPatterns.GoF.Creational.SimpleFactory
{
    public static class SimpleFactoryPattern
    {
        public static void TestSimpleFactory()
        {
            Console.Write("Element: ");
            string element = Console.ReadLine();

            IVehicle vehicle = VehicleFactory.CreateVehicle(element);

            Console.WriteLine($"Type: {vehicle.Type}");
        }
    }
}
