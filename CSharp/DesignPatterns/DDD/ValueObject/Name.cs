namespace DesignPatterns.DDD.ValueObject
{
    /// <summary>
    /// A class that pretends to create a value object for name.
    /// </summary>
    public sealed class Name
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        // Make the class immutable by removing any property setters
        // and only passing member values through the constructors.
        public string FirstName { get; }

        public string LastName { get; }

        // Override the Object.Equals method to ensure the object is
        // compared using business logic.
        public override bool Equals(object obj)
        {
            var item = obj as Name;

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return FirstName == item.FirstName && LastName == item.LastName;
        }

        // Override the Object.GetHashCode method and ensure that the
        // hash is same for the objects who have same equality.
        public override int GetHashCode()
        {
            int hash = 13;

            hash = (hash * 7) + FirstName.GetHashCode();
            hash = (hash * 7) + LastName.GetHashCode();

            return hash;
        }

        // Operator overload the default behavior of == and != to use
        // the Equals method.
        public static bool operator ==(Name lhs, Name rhs)
        {
            if (object.ReferenceEquals(lhs, null))
            {
                return object.ReferenceEquals(rhs, null);
            }

            return lhs.Equals(rhs);
        }

        public static bool operator !=(Name lhs, Name rhs)
        {
            return !(lhs == rhs);
        }
    }
}
