using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDat_Praktikum
{
    abstract class ArraySupportClass
    {
        protected int[] Data = new int[11];

        public ArraySupportClass()
        {
            // Array mit "-1" füllen
            for (int i = 0; i < Data.Length; i++)
            {
                Data[i] = -1;
            }
        }

        public void Print()
        {
            foreach (int i in Data)
            {
                Console.Write("[{0}]", i);
            }
        }

    }
}
