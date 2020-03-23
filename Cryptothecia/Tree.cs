using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptothecia
{
    public class Node<T>
    {
        public T Data;
        public Node<T> _parent;
        public Node<T> _left;
        public Node<T> _right;
        public Node<T> _root;

        public Node()
        {
            _root = this;
        }

        public Node(T data)
        {
            Data = data;
        }

        public Node<T> AddLeft(T data)
        {
            var here = new Node<T>(data);
            this._left = here;
            here._parent = this;
            return here;
        }

        public Node<T> AddLeft(Node<T> there, T data)
        {
            var here = new Node<T>(data);
            there._left = here;
            here._parent = there;
            return here;
        }

        public Node<T> AddRight(T data)
        {
            var here = new Node<T>(data);
            this._right = here;
            here._parent = this;
            return here;
        }

        public Node<T> AddRight(Node<T> there, T data)
        {
            var here = new Node<T>(data);
            there._right = here;
            here._parent = there;
            return here;
        }
    }

    public class Tree<T>
    {
        public Tree<T> Parent;
        public List<Tree<T>> Children;
        public T Data;
        public enum TRAVERSAL { TOPDOWN, BOTTOMUP }

        public Tree()
        {
            Children = new List<Tree<T>>();
        }

        public Tree(T data)
        {
            Children = new List<Tree<T>>();
            Data = data;
        }

        public Tree<T> Add(T data)
        {
            var here = new Tree<T>(data);
            this.Children.Add(here);
            here.Parent = this;
            return here;
        }

        public Tree<T> Add(Tree<T> there, T data)
        {
            var here = new Tree<T>(data);
            there.Children.Add(here);
            here.Parent = there;
            return here;
        }

        public List<Tree<T>> Traverse(Tree<T> root, TRAVERSAL direction)
        {
            List<Tree<T>> result = new List<Tree<T>>();
            RecursiveTraverse(ref result, root, direction);
            return result;
        }

        private void RecursiveTraverse(ref List<Tree<T>> result, Tree<T> trunk, TRAVERSAL direction)
        {
            if (direction == TRAVERSAL.TOPDOWN)
            {
                result.Add(trunk);
            }
            foreach (Tree<T> t in trunk.Children)
            {
                RecursiveTraverse(ref result, t, direction);
            }
            if (direction == TRAVERSAL.BOTTOMUP)
            {
                result.Add(trunk);
            }
        }

        public List<Tree<T>> TraversalTopDown(Tree<T> root)
        {
            List<Tree<T>> result = new List<Tree<T>>();
            RecursiveTraversalTopDown(ref result, root);
            return result;
        }

        private void RecursiveTraversalTopDown(ref List<Tree<T>> result, Tree<T> trunk)
        {
            result.Add(trunk);
            foreach (Tree<T> t in trunk.Children)
            {
                RecursiveTraversalTopDown(ref result, t);
            }
        }

        public List<Tree<T>> TraversalBottomUp(Tree<T> root)
        {
            List<Tree<T>> result = new List<Tree<T>>();
            RecursiveTraversalBottomUp(ref result, root);
            return result;
        }

        private void RecursiveTraversalBottomUp(ref List<Tree<T>> result, Tree<T> trunk)
        {
            foreach (Tree<T> t in trunk.Children)
            {
                RecursiveTraversalBottomUp(ref result, t);
            }
            result.Add(trunk);
        }
    }
}
