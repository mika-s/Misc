using System;

namespace DesignPatterns.GoF.Creational.Prototype
{
    public sealed class ClonableClass : ICloneable
    {
        private Random random = new Random();
        public ClonableClass()
        {
            Number = random.Next(10);
            Name = $"{DateTime.Now.ToLongDateString()}";
            AnotherClass = new AnotherClass();
        }

        public int Number { get; set; }

        public string Name { get; set; }

        public AnotherClass AnotherClass { get; set; }

        public object Clone()
        {
            ClonableClass clone = new ClonableClass();
            clone.Name = Name;
            clone.Number = Number;
            clone.AnotherClass = new AnotherClass();
            clone.AnotherClass.Title = AnotherClass.Title;
            clone.AnotherClass.Years = AnotherClass.Years;

            return clone;
        }

        public override string ToString()
        {
            return $"Name: {Name}\nNumber: {Number}\nAnother class title: {AnotherClass.Title}\nAnother class years: {AnotherClass.Years}\n";
        }
    }
}
