using System;
namespace DataStructureImplementations.MyLinkedList
{
    public class Node
    {
        public int data;
        public Node next;

        public Node()
        {
        }

        public Node(int data)
        {
            this.data = data;
            next = null;
        }
    }
}
