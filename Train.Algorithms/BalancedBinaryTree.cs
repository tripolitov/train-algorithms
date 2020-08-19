using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{

    /// <summary>
    /// https://leetcode.com/problems/balanced-binary-tree/
    /// Balanced Binary Tree
    /// 
    /// Given a binary tree, determine if it is height-balanced.
    /// For this problem, a height-balanced binary tree is defined as:
    /// a binary tree in which the left and right subtrees of every
    /// node differ in height by no more than 1.
    /// 
    /// Example 1:
    /// Given the following tree [3,9,20,null,null,15,7]:
    /// 
    ///     3
    ///    / \
    ///   9  20
    ///  / \
    /// 15  7
    /// Return true.
    /// 
    /// 
    /// Example 2:
    /// Given the following tree [1,2,2,3,3,null,null,4,4]:
    /// 
    ///       1
    ///      / \
    ///     2   2
    ///    / \
    ///   3   3
    ///  / \
    /// 4   4
    /// Return false.
    /// </summary>
    class BalancedBinaryTree
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public bool IsBalanced(TreeNode root)
        {
            if (root == null) return true;

            int h(TreeNode node)
            {
                if (node == null) return 0;

                return 1 + Math.Max(h(node.left), h(node.right));
            }

            return Math.Abs(h(root.left) - h(root.right)) <= 1 
                   && IsBalanced(root.left) 
                   && IsBalanced(root.right);
        }

        public static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(null).Returns(true);
                yield return new TestCaseData(new TreeNode(0)).Returns(true);
                yield return new TestCaseData(new TreeNode(0, new TreeNode(1))).Returns(true);
                yield return new TestCaseData(new TreeNode(0, null, new TreeNode(1, null, new TreeNode(2)))).Returns(false);
                yield return new TestCaseData(new TreeNode(0, new TreeNode(1, new TreeNode(2)))).Returns(false);
                yield return new TestCaseData(new TreeNode(1, new TreeNode(2, new TreeNode(3, new TreeNode(4), new TreeNode(4)), new TreeNode(3)), new TreeNode(2))).Returns(false);
                yield return new TestCaseData(new TreeNode(3, new TreeNode(9, new TreeNode(15), new TreeNode(7)), new TreeNode(20))).Returns(true);
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
