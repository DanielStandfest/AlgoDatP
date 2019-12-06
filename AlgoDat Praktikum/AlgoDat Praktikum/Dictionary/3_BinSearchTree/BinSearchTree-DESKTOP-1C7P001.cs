using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.BinSearchTree
{
    class BinSearchTree : ISetSorted
    {
        protected Node _root; // Wurzel
        protected Node _leaf; // Blatt
        protected Node _currentNode; // derzeitiger Knoten (laufende Variable)
        protected Node _parent; // Vorgängerknoten von _currentNode
        protected string _dir; // Seite auf der _currentNode relativ zum Vorgänger _parent hängt
        protected static int count = 0; // laufende Variable für Methode PrintInorder() (siehe Print Methoden)

        #region Print Methoden
        public void Print()
        {
            if (_root == null)
            {
                Console.WriteLine("Es sind keine Elemente vorhanden."); //Keine Wurzel vorhanden = kein Baum vorhanden
                return;
            }
            PrintInorder(_root);
            count = 0;
        }

        /// <summary>
        /// Inorder Traversierung von rechts
        /// </summary>
        /// <param name="current"></param>
        protected void PrintInorder(Node currentNode)
        {
            if (currentNode._right != null)
            {
                count++;
                PrintInorder(currentNode._right);
            }
            string tmp = "";
            for (int i = 0; i < count; i++)
                tmp += "_ ";
            Console.WriteLine(tmp + currentNode._elem);
            if (currentNode._left != null)
            {
                count++;
                PrintInorder(currentNode._left);
            }
            count--;
        }
        #endregion

        #region Search Methode
        public bool Search(int elem)
        {
            _currentNode = _root;
            while (_currentNode != null)
            {
                if (_currentNode._elem == elem)
                    return true;
                _leaf = _currentNode;
                if (elem < _currentNode._elem)
                    _currentNode = _currentNode._left;
                else
                    _currentNode = _currentNode._right;
            }
            return false; // wenn nicht gefunden => False zurückliefern
        }
        #endregion

        #region Insert Methode
        public virtual bool Insert(int elem)
        {
            if (_root == null)
            {
                _root = new Node(elem);
                return true;
            }
            if (Search(elem)) // Suche Element "elem" in Such-Methode
                return false; // wenn bereits vorhanden => Abbruch

            _currentNode = new Node(elem); // Neues Blatt anlegen
            _currentNode._left = _currentNode._right = null; // Kinderknoten auf null setzen

            if (elem < _leaf._elem) // _leaf wurde in Search(elem) initialisiert
                _leaf._left = _currentNode;
            else
                _leaf._right = _currentNode;
            return true;
        }
        #endregion

        #region Delete Methoden
        public virtual bool Delete(int elem)
        {
            _currentNode = _root;
            SearchDel(elem); // damit man auch den Vorgänger bestimmt

            // Wenn es keinen Knoten mit elem gibt, dann abbrechen.
            if (_currentNode == null)
                return false;

            // Wenn Knoten elem zwei Nachfolger besitzt
            if (_currentNode._right != null && _currentNode._left != null)
            {
                DelSymPred();
                return true;
            }

            // Wenn Knoten ein Blatt ist
            if (_currentNode._left == null)
                _leaf = _currentNode._right;
            else
                _leaf = _currentNode._left;

            // Wenn Knoten gleich der Wurzel ist
            if (_root == _currentNode)
            {
                _root = _leaf;
                return true;
            }

            if (_dir == "left")
                _parent._left = _leaf;
            else
                _parent._right = _leaf;

            return true;
        }

        /// <summary>
        /// Bestimmt u.a. auch Vorgänger
        /// </summary>
        /// <param name="elem"></param>
        protected void SearchDel(int elem)
        {
            while (_currentNode != null)
            {
                if (elem < _currentNode._elem)
                {
                    _parent = _currentNode;
                    _currentNode = _currentNode._left;
                    _dir = "left";
                }
                else if (elem > _currentNode._elem)
                {
                    _parent = _currentNode;
                    _currentNode = _currentNode._right;
                    _dir = "right";
                }
                else
                    break;
            }
        }

        protected void DelSymPred()
        {
            Node temp;
            _leaf = _currentNode; // _leaf kriegt als Knoten das zu löschende Element

            // In der Regel geht man vom löschenden Element EINMAL nach links und dann ganz nach rechts
            // Außer folgende Bedingung stimmt nicht:
            if (_leaf._left._right != null) 
            {
                _leaf = _leaf._left;
                while (_leaf._right._right != null)
                    _leaf = _leaf._right;
            }

            if (_leaf == _currentNode)
            {
                temp = _leaf._left;
                _leaf._left = temp._left;
            }
            else
            {
                temp = _leaf._right;
                _leaf._right = temp._left;
            }
            _currentNode._elem = temp._elem;
        }
        #endregion

        #region LeftRotation, RightRotation
        // bei bf(a) = -- und bf(b) = - (oder 0) um b
        protected Node RightRotation(Node node)
        {
            Node left = node._left;
            Node leftRight = left._right;

            Node parent;
            if (node == _root) // Wenn Knoten = Wurzel
                parent = _root; // Setze Wurzel als Vaterknoten
            else
            {
                _currentNode = _root;
                SearchDel(node._elem);
                parent = _parent; // parent von node
            }

            left._parent = parent; // das zu rotierende Element kriegt den Vorgänger von node
            left._right = node; // node wird "nach unten" rotiert und wird zum rechten Nachfolger vom rotierenden Element
            node._left = leftRight; // node kriegt als linken Nachfolger den rechten Nachfolger vom rotierenden Element
            node._parent = left; // das zu rotierende Element wird Vorgänger von node

            if (leftRight != null)
                leftRight._parent = node;

            if (node == _root)
                _root = left; // wenn Bedingung stimmt, dann gibt es eine neue root
            else if (parent._left == node) // wenn parent als linken Nachfolger die node hatte
                parent._left = left; // parent kriegt als NEUEN linken Nachfolger das rotierende Element
            else
                parent._right = left;

            return left;
        }

        // bei bf(a) = ++ und bf(b) = + (oder 0) um b
        protected Node LeftRotation(Node node)
        {
            Node right = node._right;
            Node rightLeft = right._left;

            Node parent;
            if (node == _root)
                parent = _root;
            else
            {
                _currentNode = _root;
                SearchDel(node._elem);
                parent = _parent;
            }

            right._parent = parent; // das zu rotierende Element kriegt den Vorgänger von node
            right._left = node; // node wird "nach unten" rotiert und wird zum linken Nachfolger vom rotierenden Element
            node._right = rightLeft; // node kriegt als rechten Nachfolger den linken Nachfolger vom rotierenden Element
            node._parent = right; // das zu rotierende Element wird Vorgänger von node

            if (rightLeft != null)
                rightLeft._parent = node;

            if (node == _root)
                _root = right; // wenn Bedingung stimmt, dann gibt es eine neue root
            else if (parent._right == node) // wenn parent als rechten Nachfolger die node hatte
                parent._right = right; // parent kriegt als NEUEN rechten Nachfolger das rotierende Element
            else
                parent._left = right;

            return right;
        }
        #endregion
    }
}
