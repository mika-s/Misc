using System;

namespace DesignPatterns.GoF.Structural.Adapter
{
    public static class ClassThatTakesPerson
    {
        public static void PrintPerson(Person person)
        {
            Console.WriteLine($"Name:\t{person.Name}");
            Console.WriteLine($"Age:\t{person.Age}");
        }
    }
}
