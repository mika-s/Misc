using System;

namespace DesignPatterns.Adapter
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
