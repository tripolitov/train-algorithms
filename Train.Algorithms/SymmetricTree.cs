using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/symmetric-tree/
    ///
    /// Given a binary tree, check whether it is a mirror
    /// of itself (ie, symmetric around its center).
    /// 
    /// For example, this binary tree [1,2,2,3,4,4,3] is symmetric:
    /// 
    ///    1
    ///   / \
    ///  2   2
    /// / \ / \
    /// 3  4 4  3
    /// 
    /// 
    /// 
    /// But the following[1, 2, 2, null, 3, null, 3] is not:
    /// 
    ///    1
    ///   / \
    ///  2   2
    ///   \   \
    ///    3    3
    /// 
    /// 
    /// 
    /// Follow up: Solve it both recursively and iteratively.
    /// </summary>
    class SymmetricTree
    {

        [Test, MaxTime(1000)]
        [TestCaseSource(nameof(TestData))]
        public bool Iterative(TreeNode root)
        {
            if (root == null) return true;

            var q = new Queue<TreeNode>();

            q.Enqueue(root.left);
            q.Enqueue(root.right);
            while (q.Count > 0)
            {
                TreeNode left = q.Dequeue(), right = q.Dequeue();

                if(left == null && right == null) continue;
                if (left == null || right == null) return false;
                if (left.val != right.val) return false;

                q.Enqueue(left.left); q.Enqueue(right.right);
                q.Enqueue(left.right); q.Enqueue(right.left);
            }
            return true;
        }

        [Test, MaxTime(1000)]
        [TestCaseSource(nameof(TestData))]
        public bool Recursive(TreeNode root)
        {
            if (root == null) return true;

            bool f(TreeNode a, TreeNode b)
            {
                if (a == null && b == null) return true;
                if (a == null || b == null) return false;

                return a.val == b.val && f(a.left, b.right) && f(a.right, b.left);
            }

            return f(root.left, root.right);
        }

        public static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(null).Returns(true);

                yield return new TestCaseData(
                    new TreeNode(1)
                ).Returns(true);

                yield return new TestCaseData(
                    new TreeNode(1,
                    new TreeNode(2))
                ).Returns(false);

                yield return new TestCaseData(
                    new TreeNode(1,
                        new TreeNode(2),
                        new TreeNode(2))
                ).Returns(true);

                yield return new TestCaseData(
                    new TreeNode(1, new TreeNode(2), new TreeNode(3))
                ).Returns(false);

                yield return new TestCaseData(
                    new TreeNode(1,
                    new TreeNode(2, new TreeNode(3), new TreeNode(4)), 
                    new TreeNode(2, new TreeNode(4), new TreeNode(3)))
                ).Returns(true);

                yield return new TestCaseData(
                    new TreeNode(1,
                        new TreeNode(2, null, new TreeNode(3)),
                        new TreeNode(2, null, new TreeNode(3)))
                ).Returns(false);
            }
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }

            public override string ToString()
            {

                return $"[{val}->{left}|{right}]";
            }
        }

    }
}