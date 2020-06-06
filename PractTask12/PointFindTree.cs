using System;
using System.Collections.Generic;
using System.Text;

namespace PractTask12
{
    class PointFindTree<T> where T: IComparable
    {
        public T data;
        public PointFindTree<T> left;
        public PointFindTree<T> right;

        public PointFindTree(T d)
        {
            data = d;
            left = null;
            right = null;
        }

        public PointFindTree()
        {
            data = default(T);
            left = null;
            right = null;
        }

        public override string ToString()
        {
            return data.ToString() + " ";
        }

    }
}
