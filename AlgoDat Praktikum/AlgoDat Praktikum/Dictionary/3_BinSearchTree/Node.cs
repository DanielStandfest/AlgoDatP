using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.BinSearchTree
{ 
    class Node
    {
        public Node _left;
        public Node _right;
        public Node _parent;
        public int _elem;

        public Node(int elem)
        {
            _elem = elem;
        }
    }
}
