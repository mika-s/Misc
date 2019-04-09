using System;

namespace DesignPatterns.Other.FluentInterfaceWithContext
{
    public sealed class CarContext
    {
        public int NumberOfWheels { get; set; }
        public string Maker { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }

    /// <summary>
    /// Fluent interface with context object and methods wrapping it.
    /// </summary>
    public sealed class Car
    {
        private CarContext context = new CarContext();

        public Car SetNumberOfWheels(int numberOfWheels)
        {
            context.NumberOfWheels = numberOfWheels;
            return this;
        }

        public Car SetMaker(string maker)
        {
            context.Maker = maker;
            return this;
        }

        public Car SetModel(string model)
        {
            context.Model = model;
            return this;
        }

        public Car SetYear(int year)
        {
            context.Year = year;
            return this;
        }

        public void PrintCarInfo()
        {
            Console.WriteLine($"Maker: {context.Maker}");
            Console.WriteLine($"Model: {context.Model}");
            Console.WriteLine($"Year: {context.Year}");
            Console.WriteLine($"Number of wheels: {context.NumberOfWheels}");
        }
    }
}
