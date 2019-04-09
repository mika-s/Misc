using System;

namespace DesignPatterns.GoF.Structural.Adapter
{
    /// <summary>
    /// This is the new person model.
    /// </summary>
    public class NewPerson
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
