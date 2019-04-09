using System;

namespace DesignPatterns.Other.FluentInterfaceWithExtMethods
{
    public enum Gender { Male, Female };

    public sealed class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }

        public void PrintPersonInfo()
        {
            Console.WriteLine($"First name: {FirstName}");
            Console.WriteLine($"Last name: {LastName}");
            Console.WriteLine($"Birth date: {BirthDate}");
            Console.WriteLine($"Gender: {Gender.ToString()}");
        }
    }
}
