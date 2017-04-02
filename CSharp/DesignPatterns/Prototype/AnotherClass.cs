using System;

namespace DesignPatterns.Prototype
{
    public sealed class AnotherClass
    {
        public AnotherClass()
        {
            Title = "title 1";
            Years = new Random().Next(9999);
        }

        public string Title { get; set; }

        public int Years { get; set; }
    }
}
