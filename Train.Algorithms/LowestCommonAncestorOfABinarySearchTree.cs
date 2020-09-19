using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/
    /// 
    /// Lowest Common Ancestor of a Binary Search Tree
    ///
    /// Given a binary search tree (BST), find the lowest common ancestor (LCA)
    /// of two given nodes in the BST.

    /// According to the definition of LCA on Wikipedia: “The lowest common a
    /// ncestor is defined between two nodes p and q as the lowest node in T
    /// that has both p and q as descendants (where we allow a node to be a
    /// descendant of itself).”
    /// 
    /// Given binary search tree:  root = [6,2,8,0,4,7,9,null,null,3,5]
    /// 
    /// Example 1:
    /// 
    /// Input: root = [6,2,8,0,4,7,9,null,null,3,5], p = 2, q = 8
    /// Output: 6
    ///
    /// Explanation: The LCA of nodes 2 and 8 is 6.
    ///
    /// Example 2:
    /// 
    /// Input: root = [6,2,8,0,4,7,9,null,null,3,5], p = 2, q = 4
    /// Output: 2
    ///
    /// Explanation: The LCA of nodes 2 and 4 is 2, since a node can be a descendant
    /// of itself according to the LCA definition.
    /// 
    /// Constraints:
    /// 
    /// All of the nodes' values will be unique.
    /// p and q are different and both values will exist in the BST.
    /// </summary>
    public class LowestCommonAncestorOfABinarySearchTree
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root.val > q.val && root.val > p.val)
                return LowestCommonAncestor(root.left, p, q); 
            
            if (root.val < q.val && root.val < p.val)
                return LowestCommonAncestor(root.right, p, q);

            return root;
        }
        
        [Test]
        [TestCaseSource(nameof(TestData))]
        public TreeNode LowestCommonAncestor_Iterative(TreeNode root, TreeNode p, TreeNode q)
        {
            while (true)
            {
                if (root.val > q.val && root.val > p.val)
                {
                    root = root.left;
                    continue;
                }

                if (root.val < q.val && root.val < p.val)
                {
                    root = root.right;
                    continue;
                }

                return root;
            }
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                var p = new TreeNode(2);
                var q = new TreeNode(3);
                var lca = new TreeNode(1, p, q);
                var root = lca;
                
                yield return new TestCaseData(root).Returns(lca);
                
                p = new TreeNode(2);
                q = new TreeNode(3, p);
                lca = q;
                root = new TreeNode(1, new TreeNode(4), lca);
                
                yield return new TestCaseData(root).Returns(lca);
                
                p = new TreeNode(2);
                q = new TreeNode(3);
                lca = new TreeNode(5, new TreeNode(6, q), new TreeNode(7, p));
                root = new TreeNode(1, new TreeNode(4), lca);
                
                yield return new TestCaseData(root).Returns(lca);
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