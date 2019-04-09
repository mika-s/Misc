namespace DesignPatterns.GoF.Creational.SimpleFactory
{
    public sealed class Boat : IVehicle
    {
        public Boat()
        {
            Maker = "Vard";
            Model = "PSV123";
            Type = "Boat";
        }

        public string Maker { get; set; }

        public string Model { get; set; }

        public string Type { get; set; }
    }
}
