using System;

namespace DesignPatterns.GoF.Structural.Adapter
{
    public sealed class PersonAdapter : Person
    {
        public PersonAdapter(NewPerson newPerson)
        {
            Name = $"{newPerson.FirstName} {newPerson.LastName}";
            Age = new DateTime(DateTime.Now.Subtract(newPerson.BirthDate).Ticks).Year - 1;           
        }
    }
}
