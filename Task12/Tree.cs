using System;
using System.Collections.Generic;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ArrangeThisQualifier

namespace Task12
{
    public class Tree
    {
        public Tree Left;
        public Tree Right;
        public readonly int Key;

        public int CountComparison = 0;

        public Tree(int key)
        {
            this.Key = key;
        }
        
        public void Add(Tree tree)
        {
            if (tree == null) throw new NullReferenceException();

            CountComparison++;
            if (tree.Key < this.Key)
            {
                if (this.Left != null) this.Left.Add(tree);
                else this.Left = tree;
            }
            else
            {
                if (this.Right != null) this.Right.Add(tree);
                else this.Right = tree;
            }
        }

        public List<int> ToList()
        {
            var result = new List<int>();
            
            if (this.Left != null) result.AddRange(this.Left.ToList());
            result.Add(this.Key);
            if (this.Right != null) result.AddRange(this.Right.ToList());

            return result;
        }
    }
}