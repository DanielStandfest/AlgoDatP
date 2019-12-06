using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dictionary;
using Dictionary.LinkedList;
using Dictionary.BinSearchTree;
using Dictionary.HashTab;

namespace AlgoDat_Praktikum
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                IDictionary dictionary = null;
                string dataType = "";
                while (dataType != "1" && dataType != "2" && dataType != "3" && dataType != "4")
                {
                    Console.WriteLine("1. Array\n2. LinkedList\n3. BinSeachTree\n4. Hash");
                    Console.Write("Wähle einen abstrakten Datentyp aus: ");
                    dataType = Console.ReadLine();
                }
                Console.WriteLine();
                switch (dataType)
                {
                    case "1":
                        {
                            string inputArray = "";
                            while (inputArray != "1" && inputArray != "2" && inputArray != "3" && inputArray != "4")
                            {
                                Console.WriteLine("1. MultiSetUnsortedArray\n2. SetUnsortedArray\n3. MultiSetSortedArray\n4. SetSortedArray");
                                Console.Write("Wähle einen konkreten Datentyp aus: ");
                                inputArray = Console.ReadLine();
                            }

                            switch (inputArray)
                            {
                                case "1": dictionary = new MultiSetUnsortedArray(); break;
                                case "2": dictionary = new SetUnsortedArray(); break;
                                case "3": dictionary = new MultiSetSortedArray(); break;
                                case "4": dictionary = new SetSortedArray(); break;
                            }
                            break;
                        }
                    case "2":
                        {
                            string inputLinkedList = "";
                            while (inputLinkedList != "1" && inputLinkedList != "2" && inputLinkedList != "3" && inputLinkedList != "4")
                            {
                                Console.WriteLine("1. MultiSetUnsortedLinkedList\n2. SetUnsortedLinkedList\n3. MultiSetSortedLinkedList\n" +
                                "4. SetSortedLinkedList");
                                Console.Write("Wähle einen konkreten Datentyp aus: ");
                                inputLinkedList = Console.ReadLine();
                            }

                            switch (inputLinkedList)
                            {
                                case "1": dictionary = new MultiSetUnsortedLinkedList(); break;
                                case "2": dictionary = new SetUnsortedLinkedList(); break;
                                case "3": dictionary = new MultiSetSortedLinkedList(); break;
                                case "4": dictionary = new SetSortedLinkedList(); break;
                            }
                            break;
                        }
                    case "3":
                        {
                            string inputTree = "";
                            while (inputTree != "1" && inputTree != "2")
                            {
                                Console.WriteLine("1. BinSearchTree\n2. AVLTree");
                                Console.Write("Wähle einen konkreten Datentyp aus: ");
                                inputTree = Console.ReadLine();
                            }

                            switch (inputTree)
                            {
                                case "1": dictionary = new BinSearchTree(); break;
                                case "2": dictionary = new AVLTree(); break;
                            }
                            break;
                        }
                    case "4":
                        {
                            string inputHash = "";
                            while (inputHash != "1" && inputHash != "2")
                            {
                                Console.WriteLine("1. HashTabQuadProb\n2. HashTabSepChain");
                                Console.Write("Wähle einen konkreten Datentyp aus: ");
                                inputHash = Console.ReadLine();
                            }

                            switch (inputHash)
                            {
                                case "1": dictionary = new HashTabQuadProb(); break;
                                case "2": dictionary = new HashTabSepChain(); break;
                            }
                            break;
                        }
                }
                Console.WriteLine();
                Process(dictionary);
                Console.WriteLine();
            }
        }

        #region Method Process
        static private void Process(IDictionary dictionary)
        {
            bool flag = true;
            while (flag)
            {
                try {
                    Console.WriteLine("Wähle eine Funktion:\n" +
                        "1. Insert\n" +
                        "2. Search\n" +
                        "3. Delete\n" +
                        "4. Print\n" +
                        "99. Menu");
                    string input = Console.ReadLine();
                    if (input == "1")
                    {
                        Console.Write("Gib eine Zahl ein, die du einfügen möchtest: ");
                        int digit = Convert.ToInt32(Console.ReadLine());

                        if (dictionary.Insert(digit))
                            Console.WriteLine($"Die Zahl {digit} wurde eingefügt.");
                        else
                            Console.WriteLine($"Die Zahl {digit} konnte nicht eingefügt werden.");
                    }
                    else if (input == "2")
                    {
                        Console.Write("Gib eine Zahl ein, die du suchen möchtest: ");
                        int digit = Convert.ToInt32(Console.ReadLine());

                        if (dictionary.Search(digit))
                            Console.WriteLine($"Die Zahl {digit} wurde gefunden.");
                        else
                            Console.WriteLine($"Die Zahl {digit} wurde nicht gefunden.");
                    }
                    else if (input == "3")
                    {
                        Console.Write("Gib eine Zahl ein, die du löschen möchtest: ");
                        int digit = Convert.ToInt32(Console.ReadLine());

                        if (dictionary.Delete(digit))
                            Console.WriteLine($"Die Zahl {digit} wurde gelöscht.");
                        else
                            Console.WriteLine($"Die Zahl {digit} ist nicht enthalten und konnte nicht gelöscht werden.");
                    }

                    else if (input == "4")
                    {
                        dictionary.Print();
                    }
                    else if (input == "99")
                        flag = false;
                    else
                        continue;
                    Console.WriteLine();
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Unzulässige Eingabe!\n");
                }
            }
        }
        #endregion
    }
}
