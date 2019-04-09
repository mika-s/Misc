namespace DesignPatterns.GoF.Creational.SimpleFactory
{
    public sealed class Plane : IVehicle
    {
        public Plane()
        {
            Maker = "Airbus";
            Model = "A380";
            Type = "Plane";
        }

        public string Maker { get; set; }

        public string Model { get; set; }

        public string Type { get; set; }
    }
}
