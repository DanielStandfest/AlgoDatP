using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dictionary.LinkedList;

namespace Dictionary.HashTab
{
    class HashTabSepChain : HashTabSupport, ISet
    {
        private SetUnsortedLinkedList[] HashTable = new SetUnsortedLinkedList[tableSize];

        public bool Insert(int elem)
        {
            int value = HashValue(elem);
            if (HashTable[value] == null)
            {
                HashTable[value] = new SetUnsortedLinkedList();
                HashTable[value].Insert(elem);
                return true;
            }
            else
                return HashTable[value].Insert(elem);
        }

        public bool Search(int elem)
        {
            int value = HashValue(elem);
            if (HashTable[value] != null)
            {
                if (HashTable[value].Search(elem))
                    return true;
            }
            return false;
        }

        public bool Delete(int elem)
        {
            int value = HashValue(elem);
            if (HashTable[value] != null)
            {
                if (HashTable[value].Delete(elem))
                    return true;
            }
            return false;
        }

        public void Print()
        {
            for (int i = 0; i < tableSize; i++)
            {
                Console.Write($"Tabelle[{i}]: ");
                if (HashTable[i] != null)
                {
                    HashTable[i].Print();
                }
                else
                    Console.WriteLine("[ ]");
            }
        }
    }
}
