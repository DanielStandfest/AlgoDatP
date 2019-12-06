using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.LinkedList
{
    class MultiSetUnsortedLinkedList : DictionaryLinkedList, IMultiSet
    {
        public override bool Insert(int elem)
        {
            // hinten einketten OHNE Durchlauf bis zum letzten Element
            ListItem item = new ListItem(elem);
            if (root == null)
            {
                root = last = item;
                return true;
            }
            last.next = item;
            last = last.next;
            return true;

        }
    }
}
