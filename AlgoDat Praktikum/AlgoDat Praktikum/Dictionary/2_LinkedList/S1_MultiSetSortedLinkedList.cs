using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.LinkedList
{
    class MultiSetSortedLinkedList : DictionaryLinkedList, IMultiSetSorted
    {
        public override bool Insert(int elem)
        {
            ListItem item = new ListItem(elem);
            ListItem current = root;

            if (root == null)
                root = item;

            else if (root._elem > elem)
            {
                item.next = root;
                root = item;
            }
            else
            {
                while (current.next != null)
                {
                    if (current.next._elem > elem)
                    {
                        item.next = current.next;
                        current.next = item;
                        return true;
                    }
                    current = current.next;
                }
                current.next = item;
            }
            return true;
        }
    }
}
