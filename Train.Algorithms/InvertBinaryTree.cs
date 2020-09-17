using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// Invert Binary Tree
    ///
    /// https://leetcode.com/problems/invert-binary-tree/
    ///
    /// Invert a binary tree.
    ///
    /// Example:
    /// 
    /// Input:
    /// 
    ///      4
    ///    /   \
    ///   2     7
    ///  / \   / \
    /// 1   3 6   9
    /// Output:
    /// 
    ///      4
    ///    /   \
    ///   7     2
    ///  / \   / \
    /// 9   6 3   1
    /// Trivia:
    /// This problem was inspired by this original tweet by Max Howell:
    /// 
    /// Google: 90% of our engineers use the software you wrote (Homebrew),
    /// but you can’t invert a binary tree on a whiteboard so f*** off.
    /// </summary>
    public class InvertBinaryTree
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public TreeNode InvertTree_Recursive(TreeNode root)
        {
            if (root == null) return null;
            
            var (left, right) = (root.left, root.right);
            root.right = InvertTree_Recursive(left);
            root.left = InvertTree_Recursive(right);
            return root;
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public TreeNode InvertTree_Iterative(TreeNode root)
        {
            if (root == null) return null;
            
            var stack = new Stack<TreeNode>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                
                if(node.left != null) stack.Push(node.left);
                if(node.right != null) stack.Push(node.right);

                var left = node.left;
                node.left = node.right;
                node.right = left;
            }

            return root;
        }

        public static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(null).Returns(null);
                yield return new TestCaseData(new TreeNode(1)).Returns(new TreeNode(1));
                yield return new TestCaseData(
                    new TreeNode(1
                    , new TreeNode(2)
                    , new TreeNode(3)))
                    .Returns(
                        new TreeNode(1
                            , new TreeNode(3)
                            , new TreeNode(2)));

                yield return new TestCaseData(
                        new TreeNode(4
                            , new TreeNode(2, new TreeNode(1), new TreeNode(3))
                            , new TreeNode(7, new TreeNode(6), new TreeNode(9))))
                    .Returns(
                        new TreeNode(4
                            , new TreeNode(7, new TreeNode(9), new TreeNode(6))
                            , new TreeNode(2, new TreeNode(3), new TreeNode(1))));
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

            protected bool Equals(TreeNode other)
            {
                return val == other.val && Equals(left, other.left) && Equals(right, other.right);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((TreeNode) obj);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(val, left, right);
            }
        }

    }
}