using System;

namespace DesignPatterns.DDD.ValueObject
{
    /// <summary>
    /// https://en.wikipedia.org/wiki/Value_object
    /// 
    /// Use a Name class that has Value Object-like properties.
    /// Structs are needed for real value objects, as they are value types.
    /// </summary>
    public static class ValueObjectPattern
    {
        public static void TestValueObjectPattern()
        {
            var n1 = new Name("John", "Smith");
            var n2 = new Name("John", "Smith");

            Console.WriteLine("Two names:");
            Console.WriteLine($"n1: FirstName: {n1.FirstName},\tLastName: {n1.LastName}.");
            Console.WriteLine($"n2: FirstName: {n2.FirstName},\tLastName: {n2.LastName}.\n");
            Console.WriteLine($"Is n1 == n2: {n1 == n2}");

            var n3 = new Name("Mary", "Stevens");
            var n4 = new Name("Peter", "Adams");

            Console.WriteLine("\n\nTwo new names:");
            Console.WriteLine($"n3: FirstName: {n3.FirstName},\tLastName: {n3.LastName}.");
            Console.WriteLine($"n4: FirstName: {n4.FirstName},\tLastName: {n4.LastName}.\n");
            Console.WriteLine($"Is n3 == n4: {n3 == n4}");
        }
    }
}
