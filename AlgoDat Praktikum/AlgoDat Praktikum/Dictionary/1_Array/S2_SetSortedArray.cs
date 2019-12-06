using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dictionary;

namespace AlgoDat_Praktikum
{
    class SetSortedArray : MultiSetSortedArray, ISetSorted
    {
        public new bool Insert(int elem)
        {
            if (!Search(elem))
            {
                base.Insert(elem);
                return true;
            }
            else
            {
                Console.WriteLine("Element is alreay in use");
                return false;
            }
        }
    }
}
