namespace DesignPatterns.Other.FluentInterfaceWithContext
{
    public static class FluentInterfacePatternWithContext
    {
        public static void TestFluentInterfacePattern()
        {
            Car car = new Car().SetMaker("Audi").SetModel("A6").SetYear(2000).SetNumberOfWheels(4);
            car.PrintCarInfo();
        }
    }
}
