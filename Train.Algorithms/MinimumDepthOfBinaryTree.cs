using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/minimum-depth-of-binary-tree/
    ///
    /// Minimum Depth of Binary Tree
    /// 
    /// Given a binary tree, find its minimum depth.
    /// The minimum depth is the number of nodes along
    /// the shortest path from the root node down to the nearest leaf node.
    /// Note: A leaf is a node with no children.
    /// 
    /// Example:
    /// Given binary tree[3, 9, 20, null, null, 15, 7],
    ///        3
    ///       / \
    ///      9  20
    ///        /  \
    ///       15   7
    /// return its minimum depth = 2.
    /// </summary>
    class MinimumDepthOfBinaryTree
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public int MinDepth(TreeNode root)
        {
            if (root == null) return 0;

            var l = MinDepth(root.left);
            var r = MinDepth(root.right);

            var result = l != 0 && r != 0
                ? Math.Min(l, r)
                : Math.Max(l, r);

            return 1 + result;
        }


        [Test]
        [TestCaseSource(nameof(TestData))]
        public int Iterative(TreeNode root)
        {
            if (root == null) return 0;

            var q = new Queue<TreeNode>();
            q.Enqueue(root);

            var depth = 0;
            while (q.Count > 0)
            {
                depth++;
                for (var n = q.Count - 1; n >= 0; n--)
                {
                    var node = q.Dequeue();
                    if (node.left == null && node.right == null) return depth;

                    if (node.left != null) q.Enqueue(node.left);
                    if (node.right != null) q.Enqueue(node.right);
                }
            }

            return depth;
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(null).Returns(0);
                yield return new TestCaseData(new TreeNode(10)).Returns(1);
                yield return new TestCaseData(new TreeNode(1, new TreeNode(2))).Returns(2);
                yield return new TestCaseData(new TreeNode(1, new TreeNode(2),
                    new TreeNode(3, new TreeNode(4), new TreeNode(5)))).Returns(2);
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