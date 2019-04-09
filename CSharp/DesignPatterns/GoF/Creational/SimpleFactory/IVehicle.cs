namespace DesignPatterns.GoF.Creational.SimpleFactory
{
    public interface IVehicle
    {
        string Maker { get; set; }

        string Model { get; set; }

        string Type { get; set; }
    }
}
