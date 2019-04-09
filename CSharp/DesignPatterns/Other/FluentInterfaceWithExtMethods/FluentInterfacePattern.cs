using System;

namespace DesignPatterns.Other.FluentInterfaceWithExtMethods
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
