using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.HashTab
{
    class HashTabQuadProb : HashTabSupport, ISet
    {
        class ListItem
        {
            public int element;

            public ListItem(int elem)
            {
                element = elem;
            }
        }
        ListItem[] HashTable;

        public HashTabQuadProb()
        {
            HashTable = new ListItem[tableSize];
        }

        public bool Insert(int elem)
        {
            ListItem newElement = new ListItem(elem);
            if (!Search(elem))
            {
                int value = HashValue(elem);
                int k = 0;

                //Collision handling (ab k = 1)
                while (k <= tableSize)
                {
                    value = (elem + k * k) % tableSize;
                    //if free place
                    if (HashTable[value] == null)
                    {
                        HashTable[value] = newElement;
                        return true;
                    }

                    value = (elem - k * k) % tableSize;
                    if (value < 0)
                        value = value + tableSize;
                    // if free place
                    if (HashTable[value] == null)
                    {
                        HashTable[value] = newElement;
                        return true;
                    }
                    k++;
                }
                Console.WriteLine("Full of elements");
                return false;
            }
            else
            {
                return false;
            }
        }

        int marker;  // mark the found place

        public bool Search(int elem)
        {
            int value = HashValue(elem);

            /* if the looking item in first place  */
            int k = 0;
            while (HashTable[value] != null)
            {
                value = (elem + k * k) % tableSize;

                /*Need the condition "HashTable[value] != null" to avoid the popular 
                error "Object reference not set to an instance of an object" */
                if (HashTable[value] != null && HashTable[value].element == elem)
                {
                    //Gefundenes Element wird markiert
                    marker = value;
                    return true;
                }
                value = (elem - k * k) % tableSize;
                if (value < 0)
                    value = value + tableSize;
                if (HashTable[value] != null && HashTable[value].element == elem)
                {
                    marker = value;
                    return true;
                }

                k++;
            }
            return false;
        }

        public bool Delete(int elem)
        {
            if (Search(elem))
            {
                HashTable[marker] = null;
                return true;
            }
            return false;
        }

        public void Print()
        {
            for (int i = 0; i < HashTable.Length; i++)
            {
                if (HashTable[i] == null)
                    Console.Write("[ ]");
                else
                    Console.Write("[{0}]", HashTable[i].element);
            }
        }
    }
}
