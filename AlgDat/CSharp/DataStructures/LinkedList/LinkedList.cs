using System;

namespace AlgDatCSharp.LinkedList
{
    public sealed class LinkedList
    {
        private Node first;

        public LinkedList(Node first)
        {
            this.first = first;
        }

        public void TraversePrint()
        {
            Node current = first;

            Console.Write($"Traversing:\t\t{current.Data}\t");
            while (current.Next != null)
            {
                current = current.Next;
                Console.Write($"{current.Data}\t");
            }
            Console.Write("\n");
        }

        public void Reverse()
        {

        }

        public void InsertAfter(Node node, Node newNode)
        {
            newNode.Next = node.Next;
            node.Next = newNode;
        }

        public void InsertBeginning(Node newNode)
        {
            newNode.Next = first;
            first = newNode;
        }

        public void RemoveAfter(Node node)
        {
            node.Next = node.Next?.Next;
        }

        public void RemoveBeginning()
        {
            first = first.Next;
        }
    }
}
