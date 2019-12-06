using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.HashTab
{
    abstract class HashTabSupport
    {
        //keep in mind: choose prim = 4k+3, ex: 11,19,67,103,...
        public static int tableSize = 10;
        protected int HashValue(int elem)
        {
            while (elem < 0)
                elem += tableSize;
            return elem % tableSize;
        }
    }
}
