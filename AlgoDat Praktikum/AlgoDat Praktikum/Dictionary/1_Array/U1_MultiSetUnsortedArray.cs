using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dictionary;

namespace AlgoDat_Praktikum
{
    class MultiSetUnsortedArray : ArraySupportClass, IMultiSet
    {
        protected int pointer = 0; // zeiger für insert methode
        protected int counter = -1; // counter für delete methode

        public bool Search(int elem)
        {
            foreach (int i in Data)
            {
                counter++;
                if (i == elem)
                    return true;
            }
            return false;
        }

        public bool Insert(int elem)
        {
            if (pointer < Data.Length && elem >= 0)
            {
                Data[pointer] = elem;
                pointer++;
                return true;
            }
            else if (elem <= 0)
                Console.WriteLine("Element must be greater than -1");
            else
                Console.WriteLine("Maximum elements");
            return false;
        }

        public bool Delete(int elem)
        {
            counter = -1;
            if (Search(elem)) // wenn element gefunden lösch element und nehme das letzte im Array speicher es dort wo es gefunden wurde ein
            {
                Data[counter] = Data[pointer - 1];
                pointer--;
                Data[pointer] = -1;
                return true;
            }
            return false;
        }

    }
}
