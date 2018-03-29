namespace Linq
{
    public sealed class Pet
    {
        public string Name;
        public Person Owner;

        public Pet(string name, Person owner)
        {
            Name = name;
            Owner = owner;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
