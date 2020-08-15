using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/maximum-depth-of-binary-tree/
    ///
    /// Given a binary tree, find its maximum depth.
    /// The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.
    /// Note: A leaf is a node with no children.
    ///
    /// Example:
    ///
    /// Given binary tree[3, 9, 20, null, null, 15, 7],
    ///
    ///     3
    ///    / \
    ///   9  20
    ///     /  \
    ///    15   7
    /// return its depth = 3.
    /// </summary>
    class MaximumDepthOfBinaryTree
    {
        [Test]
        [MaxTime(1000)]
        [TestCaseSource(nameof(TestData))]
        public int Recursive(TreeNode root)
        {
            if (root == null) return 0;

            return 1 + Math.Max(Recursive(root.left), Recursive(root.right));
        }

        [Test]
        [MaxTime(1000)]
        [TestCaseSource(nameof(TestData))]
        public int Iterative(TreeNode root)
        {
            if (root == null) return 0;

            var q = new Queue<TreeNode>();
            q.Enqueue(root);

            var result = 0;
            while (q.Count > 0)
            {
                result++;

                for (int i = 0, n = q.Count; i < n; i++)
                {
                    var node = q.Dequeue();

                    if(node.left != null) q.Enqueue(node.left);
                    if (node.right != null) q.Enqueue(node.right);
                }
            }

            return result;
        }

        public static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(null).Returns(0);

                yield return new TestCaseData(
                    new TreeNode(1)
                ).Returns(1);

                yield return new TestCaseData(
                    new TreeNode(1,
                        new TreeNode(2))
                ).Returns(2);

                yield return new TestCaseData(
                    new TreeNode(1,
                        new TreeNode(2),
                        new TreeNode(2))
                ).Returns(2);

                yield return new TestCaseData(
                    new TreeNode(1, new TreeNode(2), new TreeNode(3))
                ).Returns(2);

                yield return new TestCaseData(
                    new TreeNode(1,
                        new TreeNode(2, new TreeNode(3), new TreeNode(4)),
                        new TreeNode(2, new TreeNode(4), new TreeNode(3)))
                ).Returns(3);

                yield return new TestCaseData(
                    new TreeNode(1,
                        new TreeNode(2, null, new TreeNode(3)),
                        new TreeNode(2, null, new TreeNode(3)))
                ).Returns(3);
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