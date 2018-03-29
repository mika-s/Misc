namespace Linq
{
    public sealed class Person
    {
        public string Name;
        
        public Person(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
