using System;

namespace BInarySearchTree
{
    class Node
    {
        public Node lchild;
        public int info;
        public Node rchild;
        public Node(int i)
        {
            info = i;
            lchild = null;
            rchild = null;
        }
    }
}
