using System;

namespace DesignPatterns.GoF.Structural.Adapter
{
    /// <summary>
    /// Make unrelated classes work together.
    /// 
    /// In this case a new person model was created, NewPerson. The
    /// old person model is Person. The old classes still takes
    /// Person as an argument, so NewPerson has to be adatped to
    /// Person in order to use those methods.
    /// </summary>
    public static class AdapterPattern
    {
        public static void TestAdapterPattern()
        {
            var newPerson = new NewPerson()
            {
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateTime(1990, 05, 20)
            };

            ClassThatTakesPerson.PrintPerson(new PersonAdapter(newPerson));
        }
    }
}
