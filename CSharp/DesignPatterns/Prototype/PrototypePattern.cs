using System;

namespace DesignPatterns.Prototype
{
    public static class PrototypePattern
    {
        public static void TestPrototypePattern()
        {
            ClonableClass original = new ClonableClass();
            ClonableClass clone = original.Clone() as ClonableClass;

            Console.WriteLine("Content before editing:");
            Console.WriteLine(original);
            Console.WriteLine(clone);

            original.Name = "New name";
            original.Number = 20;

            Console.WriteLine("Content after editing:");
            Console.WriteLine(original);
            Console.WriteLine(clone);
        }
    }
}
