using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3_038
{
    class Node
    {
        public int rollNumber;
        public string name;
        public Node next;

        public Node(int i)
        {
            rollNumber = i;
            next = null;
        }
    }
    class CircularList
    {
        Node LAST;
        public CircularList()
        {
            LAST = null;
        }
        public bool Search (int rollNo, ref Node previous, ref Node current)
        {
            for (previous = current = LAST.next; current != LAST; previous = current, current = current.next)
            {
                if (rollNo == current.rollNumber)
                    return (true);
            }
            if (rollNo == LAST.rollNumber)
                return true;
            else
                return (false);
        }
        public bool listEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecords in the list are: \n");
                Node currentNode;
                currentNode = LAST.next;
                while (currentNode != LAST)
                {
                    Console.Write(currentNode.rollNumber + "  " + currentNode.name + "\n");
                    currentNode = currentNode.next;
                }
                Console.Write(LAST.rollNumber + "  " + LAST.name + "\n");
            }
        }
        public void InsertInBeginning(int data)
        {
            Node temp = new Node(data);
            temp.next = LAST.next;
            LAST.next = temp;
        }

        public void InsertInEmptyList(int data)
        {
            Node temp = new Node(data);
            LAST = temp;
            LAST.next = LAST;
        }

        public void InsertAtEnd(int data)
        {
            Node temp = new Node(data);
            temp.next = LAST.next;
            LAST.next = temp;
            LAST = temp;
        }

        public void CreateList()
        {
            int i, n, data;

            Console.WriteLine("Enter the number of nodes: ");
            n = Convert.ToInt32(Console.ReadLine());

            if (n == 0)
                return;
            Console.Write("Enter the element to be inserted: ");
            data = Convert.ToInt32(Console.ReadLine());
            InsertInEmptyList(data);

            for (i = 2; i <= n; i++)
            {
                Console.Write("Enter the element to be inserted: ");
                data = Convert.ToInt32(Console.ReadLine());
                InsertAtEnd(data);
            }
        }
        public void InsertAfter(int data, int x)
        {
            Node p = LAST.next;
            do
            {
                if (p.rollNumber == x)
                    break;
                p = p.next;
            } while (p != LAST.next);

            if (p == LAST.next && p.rollNumber != x)
                Console.WriteLine(x + " not present in the list.");
            else
            {
                Node temp = new Node(data);
                temp.next = p.next;
                if (p == LAST)
                    LAST = temp;
            }
        }
        public void DeleteNode(int x)
        {
            Node p = LAST.next;
            while (p.next != LAST.next)
            {
                if (p.next.rollNumber == x)
                    break;
                p = p.next;
            }

            if (p.next == LAST.next)
                Console.WriteLine(x + " not found in the list.");
            else
            {
                p.next = p.next.next;
                if (LAST.rollNumber == x)
                    LAST = p;
            }
        }

        static void Main (string[] args)
        {
            int data;
            CircularList obj = new CircularList();
            obj.CreateList();
            while (true)
            {
                Console.WriteLine("\nMenu");
                Console.WriteLine("1. View all the records in the list");
                Console.WriteLine("2. Search for a record in the list");
                Console.WriteLine("3. Insert in the beginning of the list");
                Console.WriteLine("4. Insert in an empty list");
                Console.WriteLine("5. Insert at end of the list");
                Console.WriteLine("6. Delete node");
                Console.WriteLine("7. Exit");
                Console.WriteLine("\nEnter your choice (1-7): ");
                char ch = Convert.ToChar(Console.ReadLine());

                if (ch == 7)
                    break;

                switch (ch)
                {
                    case '1':
                        {
                            obj.traverse();
                        }
                        break;
                    case '2':
                        {
                            if(obj.listEmpty() == true)
                            {
                                Console.WriteLine("\nList is empty");
                                break;
                            }
                            Node prev, curr;
                            prev = curr = null;
                            Console.Write("\nEnter the roll number of the student whose record is to be searched: ");
                            int num = Convert.ToInt32(Console.ReadLine());
                            if (obj.Search(num, ref prev, ref curr) == false)
                                Console.WriteLine("\nRecord not found");
                            else
                            {
                                Console.WriteLine("\nRecord found");
                                Console.WriteLine("\nrollNumber: " + curr.rollNumber);
                                Console.WriteLine("\nName: " + curr.name);
                            }
                        }
                        break;
                    case '3':
                        {
                            Console.WriteLine("Enter the element to be inserted : ");
                            data = Convert.ToInt32(Console.ReadLine());
                            obj.InsertInBeginning(data);
                            break;
                        }
                    case '4':
                        {
                            Console.WriteLine("Enter the element to be insterted : ");
                            data = Convert.ToInt32(Console.ReadLine());
                            obj.InsertInEmptyList(data);
                            break;
                        }
                    case '5':
                        {
                            Console.WriteLine("Enter the element to be inserted : ");
                            data = Convert.ToInt32(Console.ReadLine());
                            obj.InsertAtEnd(data);
                            break;
                        }
                    case '6':
                        {
                            Console.WriteLine("Enter the element to be deleted : ");
                            data = Convert.ToInt32(Console.ReadLine());
                            obj.DeleteNode(data);
                            break;
                        }
                    case '7':
                        return;
                    default:
                        {
                            Console.WriteLine("Invalid option");
                            break;
                        }
                }
            }
            /*catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }*/
        }
    }
}
