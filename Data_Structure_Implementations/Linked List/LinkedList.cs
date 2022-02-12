using System;
namespace DataStructureImplementations.MyLinkedList
{
    public class LinkedList
    {
        public Node head;
        private int size;

        public LinkedList()
        {
            head = null;
            size = 0;
        }

        public int getSize()
        {
            return size;
        }

        // Inserts num at the back
        public void insert(int num)
        {
            // create a new node
            Node node = new Node(num);

            // if the list is empty
            if (head == null)
            {
                head = node;
                size++;
            }
            else
            {
                // insert at the end
                Node n = new Node();
                n = head;

                while (n.next != null)
                {
                    n = n.next;
                }
                n.next = node;
                size++;
            }
        }

        // Inserts num at the front
        public void insertAtFront(int num)
        {
            Node node = new Node(num);
            node.next = head;
            head = node;
            size++;
        }

        public void insertAt(int index, int num)
        {
            if (index >= getSize())
            {
                Console.WriteLine("Invalid index.\n");
                return;
            }

            else if (index == 0)
            {
                insertAtFront(num);
            }

            else if (index == getSize()-1)
            {
                insert(num);
            }
            else
            {
                Node node = new Node(num);
                Node n = head;
                for (int i = 0; i < index-1; i++)
                {
                    n = n.next;
                }
                node.next = n.next;
                n.next = node;
                size++;
            }

        }

        public void deleteAtFront()
        {
            head = head.next;
            size--;
        }

        public void deleteAt(int index)
        {
            if (index == 0)
            {
                deleteAtFront();
            }
            else
            {
                Node n = head;
                Node n1 = null;
                for (int i = 0; i < index-1; i++)
                {
                    n = n.next;
                }
                n1 = n.next;
                n.next = n1.next;
                size--;
            }
        }

        public void show()
        {
            Node n = new Node();

            for (n = head; n.next != null; n = n.next)
            {
                Console.WriteLine(n.data);
            }

            Console.WriteLine(n.data);
        }
    }
}
