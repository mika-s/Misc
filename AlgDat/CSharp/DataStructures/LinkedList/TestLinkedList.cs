using System;

namespace AlgDatCSharp.LinkedList
{
    public static class TestLinkedList
    {
        public static void Run()
        {
            #region First
            Console.Write("First: insert first, insert second, traverse\n\n");

            var firstNode = new Node("first");
            var linkedList = new LinkedList(firstNode);

            var secondNode = new Node("second");
            linkedList.InsertAfter(firstNode, secondNode);

            linkedList.TraversePrint();

            Console.Write("\n-------------------\n\n");
            #endregion

            #region Second
            Console.Write("Second: insert between-first-and-second\n\n");

            var inbetweenNode = new Node("between-first-and-second");
            linkedList.InsertAfter(firstNode, inbetweenNode);
            linkedList.TraversePrint();

            Console.Write("\n-------------------\n\n");
            #endregion

            #region Third
            Console.Write("Third: insert at beginning new-first-node\n\n");

            var newFirstNode = new Node("new-first-node");
            linkedList.InsertBeginning(newFirstNode);
            linkedList.TraversePrint();

            Console.Write("\n-------------------\n\n");
            #endregion

            #region Fourth
            Console.Write("Fourth: remove between-first-and-second\n\n");

            linkedList.RemoveAfter(firstNode);
            linkedList.TraversePrint();

            Console.Write("\n-------------------\n\n");
            #endregion

            #region Fifth
            Console.Write("Fifth: remove first node new-first-node\n\n");

            linkedList.RemoveBeginning();
            linkedList.TraversePrint();

            Console.Write("\n-------------------\n\n");
            #endregion
        }
    }
}
