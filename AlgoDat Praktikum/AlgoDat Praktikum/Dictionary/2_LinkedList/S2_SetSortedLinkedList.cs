using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.LinkedList
{
    class SetSortedLinkedList : MultiSetSortedLinkedList, ISetSorted
    {
        public override bool Insert(int elem)
        {
            if (Search(elem))
            {
                return false;
            }
            else
            {
                base.Insert(elem);
                return true;
            }
        }
    }
}
