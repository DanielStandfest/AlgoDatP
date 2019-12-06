using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dictionary;

namespace AlgoDat_Praktikum
{
    class SetUnsortedArray : MultiSetUnsortedArray, ISet
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
                Console.WriteLine("Element is already in use.");
                return false;
            }
        }
    }
}
