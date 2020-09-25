using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BInarySearchTree
{
    class BinarySearchTree
    {
        private Node root;
        public BinarySearchTree()
        {
            root = null;
        }
        public bool IsEmpty()
        {
            return (root == null);
        }
        public void Insert(int x)
        {
            root = Insert(root, x);
        }
        private Node Insert(Node p, int x)
        {
            if (p == null)
                p = new Node(x);
            else if (x < p.info)
                p.lchild = Insert(p.lchild, x);
            else if (x > p.info)
                p.rchild = Insert(p.rchild, x);
            else
                Console.WriteLine(x + "already present in tree");
            return p;
        }
        public void Insert1(int x)
        {
            Node p = root;
            Node par = null;
            while (p != null)
            {
                par = p;
                if (x < p.info)
                    p = p.lchild;
                else if (x > p.info)
                    p = p.rchild;
                else
                {
                    Console.WriteLine(x + "already present in the tree");
                    return;
                }

            }
            Node temp = new Node(x);
            if (par == null)
                root = temp;
            else if (x < p.info)
                par.lchild = temp;
            else
                par.rchild = temp;
        }
        public bool Search(int x)
        {
            return (Search(root, x) != null);
        }
        private Node Search(Node p, int x)
        {
            if (p == null)
                return null;
            if (x < p.info)
                return Search(p.lchild, x);
            if (x > p.info)
                return Search(p.rchild, x);
            return p;
        }
        public bool Search1(int x)
        {
            Node p = root;
            while (p != null)
            {
                if (x < p.info)
                    p = p.lchild;
                else if (x > p.info)
                    p = p.rchild;
                else
                    return true;
            }
            return false;
        }
        public void Delete(int x)
        {
            root = Delete(root, x);
        }
        private Node Delete(Node p, int x)
        {
            Node ch, s;
            if (p == null)
            {
                Console.WriteLine(x + " not found");
                return p;
            }
            if (x < p.info)
                p.lchild = Delete(p.lchild, x);
            if (x > p.info)
                p.lchild = Delete(p.rchild, x);
            else
            {
                if (p.lchild != null && p.rchild != null)
                {
                    s = p.rchild;
                    while (s.lchild != null)
                        s = s.lchild;
                    p.info = s.info;
                    p.rchild = Delete(p.rchild, s.info);
                }
                else
                {
                    if (p.lchild != null)
                        ch = p.lchild;
                    else ch = p.rchild;
                    p = ch;

                }
            }
            return p;
        }
        public void Delete1(int x)
        {
            Node p = root;
            Node par = null;
            while (p != null)
            {
                if (x == p.info)
                    break;
                par = p;
                if (x < p.info)
                    p = p.lchild;
                else
                    p = p.rchild;
            }
            if (p == null)
            {
                Console.WriteLine(x + "not found");
                return;
            }
            Node s, ps;
            if (p.lchild != null && p.rchild != null)
            {
                ps = p;
                s = p.rchild;
                while (s.lchild != null)
                {
                    ps = s;
                    s = s.lchild;
                }
                p.info = s.info;
                p = s;
                par = ps;
            }
            Node ch;
            if (p.lchild != null)
                ch = p.lchild;
            else ch = p.rchild;
            if (par == null)
                root = ch;
            else if (p == par.lchild)
                par.lchild = ch;
            else
                par.rchild = ch;

        }
        public int Min()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Tree is empty");
            return Min(root).info;
        }
        private Node Min(Node p)
        {
            if (p.lchild == null)
                return p;
            return Min(p.lchild);
        }

        public int Max()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Tree is empty");
            return Max(root).info;
        }
        private Node Max(Node p)
        {
            if (p.rchild == null)
                return p;
            return Min(p.rchild);
        }
        public int Min1()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Tree is empty");
            Node p = root;
            while (p.lchild != null)
                p = p.lchild;
            return p.info;
        }
        public int Max1()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Tree is empty");
            Node p = root;
            while (p.rchild != null)
                p = p.rchild;
            return p.info;
        }
        public void Display()
        {
            Display(root, 0);
            Console.WriteLine();
        }
        private void Display(Node p, int level)
        {
            int i;
            if (p == null) 
            return;
            Display(p.rchild, level + 1);
            Console.WriteLine();
            for (i = 0; i < level; i++)
                Console.Write("    ");
            Console.Write(p.info);
            Display(p.lchild, level + 1);
        }
        public void PreOrder()
        {
            PreOrder(root);
            Console.WriteLine();
        }
        private void PreOrder(Node p)
        {
            if (p == null)
                return;
            Console.Write(p.info + " ");
            PreOrder(p.lchild);
            PreOrder(p.rchild);
        }
        public void InOrder()
        {
            InOrder(root);
            Console.WriteLine();
        }
        private void InOrder(Node p)
        {
            if (p == null)
                return;

            InOrder(p.lchild);
            Console.Write(p.info + " ");
            InOrder(p.rchild);

        }
        public void PostOrder()
        {
            PostOrder(root);
            Console.WriteLine();
        }
        private void PostOrder(Node p)
        {
            if (p == null)
                return;

            PostOrder(p.lchild);
            PostOrder(p.rchild);
            Console.Write(p.info + " ");


        }

        public int Height()
        {
            return Height(root);
        }
        private int Height(Node p)
        {
            int hL, hR;
            if (p == null)
                return 0;
            hL = Height(p.lchild);
            hR = Height(p.rchild);
            if (hL > hR)
                return 1 + hL;
            else
                return 1 + hR;


        }
    }
}
