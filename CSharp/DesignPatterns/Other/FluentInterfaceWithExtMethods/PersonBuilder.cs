using System;

namespace DesignPatterns.Other.FluentInterfaceWithExtMethods
{
    /// <summary>
    /// Fluent interface with extension methods.
    /// </summary>
    public static class PersonBuilder
    {
        public static Person CreatePerson()
        {
            return new Person();
        }

        public static Person SetFirstName(this Person person, string firstName)
        {
            person.FirstName = firstName;
            return person;
        }

        public static Person SetLastName(this Person person, string lastName)
        {
            person.LastName = lastName;
            return person;
        }

        public static Person SetBirthDate(this Person person, DateTime birthDate)
        {
            person.BirthDate = birthDate;
            return person;
        }

        public static Person SetGender(this Person person, Gender gender)
        {
            person.Gender = gender;
            return person;
        }
    }
}
