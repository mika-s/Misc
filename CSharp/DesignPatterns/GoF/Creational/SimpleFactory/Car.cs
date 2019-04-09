namespace DesignPatterns.GoF.Creational.SimpleFactory
{
    public sealed class Car : IVehicle
    {
        public Car()
        {
            Maker = "Audi";
            Model = "A4";
            Type = "Car";
        }

        public string Maker { get; set; }

        public string Model { get; set; }

        public string Type { get; set; }
    }
}
