using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.BinSearchTree
{
    class AVLTree : BinSearchTree
    {
        // bool-Variable für Insert-Methode
        bool _flagRotation = false;

        #region Insert Methode
        public override bool Insert(int elem)
        {
            if (!base.Insert(elem))
                return false; //Schleifenabbruch, weil Element ist bereits vorhanden.

            Node seed = _root;
            InsertBalance(seed);
            _flagRotation = false; // wird zurückgesetzt auf false für die nächste Runde
            return true;
        }
        private void InsertBalance(Node node)
        {
            if (node == null)
                return;

            InsertBalance(node._left);
            if (_flagRotation)
                return;
            InsertBalance(node._right);
            if (_flagRotation)
                return;

            int bf = GetBalanceFactor(node);

            if (bf <= 1 && bf >= -1) // Wenn Balance-Faktor O.K.
                return; // dann nichts tun
            else if (bf == 2)
            {
                if (GetBalanceFactor(node._right) == 1) // Wenn Balance-Faktor vom rechten Kindknoten = 1
                    LeftRotation(node); // Links-Rotation
                else
                    RightLeftRotation(node); // Rechts-Links-Rotation
            }
            else if (bf == -2)
            {
                if (GetBalanceFactor(node._left) == -1)
                    RightRotation(node);
                else
                    LeftRightRotation(node);
            }
            // Nach der ERSTEN (Doppel-)Rotation wird _flagRotation auf true gesetzt und es wird nicht weiter rotiert
            _flagRotation = true;
        }
        #endregion

        #region Delete Methode
        public override bool Delete(int elem)
        {
            if (!base.Delete(elem))
                return false;

            Node seed = _root;
            DeleteBalance(seed);
            return true;
        }
        private void DeleteBalance(Node node)
        {
            if (node == null)
                return;

            DeleteBalance(node._left);
            DeleteBalance(node._right);

            int bf = GetBalanceFactor(node);

            if (bf <= 1 && bf >= -1)
                return; // Nichts machen, wenn Balancefaktor O.K.
            else if (bf == 2) // Balancefaktor zu groß
            {
                if (GetBalanceFactor(node._right) >= 0) // Rechts zu groß, dann Links-Rotation.
                    LeftRotation(node);                
                else
                    RightLeftRotation(node); // Links zu groß, dann Rechts-Links-Rotation
            }
            else if (bf == -2)
            {
                if (GetBalanceFactor(node._left) <= 0)
                    RightRotation(node);
                else
                    LeftRightRotation(node);
            }
        }
        #endregion

        #region LeftRightRotation & RightLeftRotation
        // bei bf(a) = -- und bf(b) = + um c
        private Node LeftRightRotation(Node node) // node = Knoten a
        {
            Node left = node._left; // Knoten b
            Node leftRight = left._right; // Knoten c

            Node parent;
            if (node == _root)
                parent = _root;
            else
            {
                _currentNode = _root;
                SearchDel(node._elem);
                parent = _parent;
            }

            Node leftRightRight = leftRight._right; // rechter Nachfolger von Knoten c
            Node leftRightLeft = leftRight._left; // linker Nachfolger von Knoten c

            leftRight._parent = parent; // Knoten c erhält als neuen Vorgänger den Vorgänger von Knoten a
            node._left = leftRightRight; // Knoten a erhält als neuen linken Nachfolger den urspr. rechten Nachfolger von Knoten c
            left._right = leftRightLeft; // Knoten b erhält als neuen rechten Nachfolger den urspr. linken Nachfolger von Knoten c
			
            leftRight._left = left; // Knoten c erhält als neuen linken Nachfolger den Knoten b
            leftRight._right = node; // Knoten c erhält als neuen rechten Nachfolger den Knoten a
			
            left._parent = leftRight; // Knoten b erhält als neuen Vorgänger den Knoten c
            node._parent = leftRight; // Knoten a erhält als neuen Vorgänger den Knoten c

            if (leftRightRight != null)
                leftRightRight._parent = node; // ursp. rechter Nachfolger von c erhält als neuen Vorgänger Knoten a 

            if (leftRightLeft != null)
                leftRightLeft._parent = left; // ursp. linker Nachfolger von c erhält als neuen Vorgänger Knoten b

            if (node == _root) // wenn Knoten a die root gewesen ist
                _root = leftRight; // dann ist Knoten c die neue root
            else if (parent._left == node) // wenn parent als linken Nachfolger Knoten a hatte
                parent._left = leftRight; // parent kriegt als NEUEN linken Nachfolger Knoten c
            else
                parent._right = leftRight;

            return leftRight;
        }

        // bei bf(a) = ++ und bf(b) = - um c
        private Node RightLeftRotation(Node node) // node = Knoten a
        {
            Node right = node._right; // Knoten b
            Node rightLeft = right._left; // Knoten c

            Node parent;
            if (node == _root)
                parent = _root;
            else
            {
                _currentNode = _root;
                SearchDel(node._elem);
                parent = _parent;
            }

            Node rightLeftLeft = rightLeft._left; // linker Nachfolger von Knoten c
            Node rightLeftRight = rightLeft._right; // rechter Nachfolger von Knoten c

            rightLeft._parent = parent; // Knoten c erhält als neuen Vorgänger den Vorgänger von Knoten a
            node._right = rightLeftLeft; // Knoten a erhält als neuen rechten Nachfolger den urspr. linken Nachfolger von Knoten c
            right._left = rightLeftRight; // Knoten b erhält als neuen linken Nachfolger den urspr. rechten Nachfolger von Knoten c
            rightLeft._right = right; // Knoten c erhält als neuen rechten Nachfolger den Knoten b
            rightLeft._left = node; // Knoten c erhält als neuen linken Nachfolger den Knoten a
            right._parent = rightLeft; // Knoten b erhält als neuen Vorgänger den Knoten c
            node._parent = rightLeft; // Knoten a erhält als neuen Vorgänger den Knoten c

            if (rightLeftLeft != null)
                rightLeftLeft._parent = node; // ursp. linker Nachfolger von c erhält als neuen Vorgänger Knoten a 

            if (rightLeftRight != null)
                rightLeftRight._parent = right; // ursp. rechter Nachfolger von c erhält als neuen Vorgänger Knoten b

            if (node == _root) // wenn Knoten a die root gewesen ist
                _root = rightLeft; // dann ist Knoten c die neue root
            else if (parent._right == node) // wenn parent als rechten Nachfolger Knoten a hatte
                parent._right = rightLeft; // parent kriegt als NEUEN rechten Nachfolger Knoten c
            else
                parent._left = rightLeft;

            return rightLeft;
        }
        #endregion

        #region GetBalanceFactor & GetHeight
        private int GetBalanceFactor(Node node)
        {
            int leftHeight = GetHeight(node._left);
            int rightHeight = GetHeight(node._right);
            int bf = rightHeight - leftHeight;

            return bf;
        }

        private int GetHeight(Node node)
        {
            if (node == null)
                return -1;
            else
                return Math.Max(GetHeight(node._left), GetHeight(node._right)) + 1;
        }
        #endregion
    }
}
