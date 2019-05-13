namespace AlgDatCSharp.LinkedList
{
    public sealed class Node
    {
        public Node(string data)
        {
            Data = data;
            Next = null;
        }

        public Node(string data, Node next)
        {
            Data = data;
            Next = next;
        }

        public string Data { get; set; }

        public Node Next { get; set; }
    }
}
