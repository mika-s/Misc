using System;

namespace DesignPatterns.GoF.Creational.FactoryMethod
{
    public static class FactoryMethodPattern
    {
        public static void TestFactoryMethod()
        {
            Document cv = new Cv();

            foreach (IPage page in cv.Pages)
                Console.WriteLine($"{page.Title}");
        }
    }
}
