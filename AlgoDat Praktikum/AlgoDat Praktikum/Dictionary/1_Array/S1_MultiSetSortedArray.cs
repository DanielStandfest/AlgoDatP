using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dictionary;

namespace AlgoDat_Praktikum
{
    class MultiSetSortedArray : ArraySupportClass, IMultiSet
    {
        public bool Search(int elem)
        {
            int center;
            int start = 0;
            int end = Data.Length - 1;

            do
            {
                center = (start + end) / 2;
                if (Data[center] == -1) // wenn center -1 ist fokus auf linke seite des arrays
                    end = center - 1;
                else if (Data[center] < elem)
                    start = center + 1;
                else
                    end = center - 1;
            } while (Data[center] != elem && start <= end);

            if (Data[center] == elem)
            {
                pointer = center;
                return true;
            }
            else
            {
                pointer = start;
                return false;
            }
        }

        int pointer; // zeiger für insert methode
        public bool Insert(int elem)
        {
            if (Data[Data.Length - 1] != -1) // Array ist voll, wenn letztes element nicht -1
                Console.WriteLine("Maximum elements");
            else if (elem < 0)
                Console.WriteLine("Element must be greater than -1");
            else
            {
                Search(elem);

                if (Data[0] == -1)
                    Data[0] = elem;
                else
                {
                    for (int i = Data.Length - 2; i >= pointer; i--)
                    {
                        Data[i + 1] = Data[i]; // verschiebe alle elemente nach rechts bis einzufügende Stelle erreicht ist
                    }
                    Data[pointer] = elem;
                }

                return true;
            }
            return false;
        }

        public bool Delete(int elem)
        {
            if (Search(elem))
            {
                for (int i = pointer; i < Data.Length - 1; i++)
                {
                    Data[i] = Data[i + 1];
                    Data[i + 1] = -1;
                }

                return true;
            }
            else
                return false;
        }
    }
}
