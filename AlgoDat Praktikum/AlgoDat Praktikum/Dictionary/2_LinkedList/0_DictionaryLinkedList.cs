using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.LinkedList
{
    abstract class DictionaryLinkedList
    {
        public class ListItem
        {
            public int _elem;
            public ListItem next;
            public ListItem(int elem)
            {
                _elem = elem;
            }
        }

        public ListItem root, last;

        public void Print()
        {
            ListItem current = root;
            while (current != null)
            {
                Console.Write($"[{current._elem}] --> ");
                current = current.next;
            }
            Console.WriteLine("DONE");
        }

        public bool Search(int elem)
        {
            ListItem current = root;
            while (current != null)
            {
                if (current._elem == elem)
                    return true;
                current = current.next;
            }
            return false;
        }

        public bool Delete(int elem)
        {
            if (root._elem == elem)
            {
                root = root.next;
                return true;
            }
            ListItem current = root;
            while (current.next != null)
            {
                if (current.next._elem == elem)
                {
                    current.next = current.next.next;
                    return true;
                }
                current = current.next;
            }
            return false;
        }
        public abstract bool Insert(int elem);
    }
}

