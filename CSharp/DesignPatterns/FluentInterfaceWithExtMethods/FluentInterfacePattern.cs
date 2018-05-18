using System;

namespace DesignPatterns.FluentInterfaceWithExtMethods
{
    public static class FluentInterfacePatternWithExtMethods
    {
        public static void TestFluentInterfacePattern()
        {
            Person myPerson = PersonBuilder.CreatePerson()
                              .SetFirstName("Test")
                              .SetBirthDate(DateTime.Now)
                              .SetLastName("Person")
                              .SetGender(Gender.Male);

            myPerson.PrintPersonInfo();
        }
    }
}
