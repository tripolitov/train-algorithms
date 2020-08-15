using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/same-tree/
    ///
    /// Given two binary trees, write a function to check if they are the same or not.
    /// Two binary trees are considered the same if they are structurally identical
    /// and the nodes have the same value.
    /// 
    /// Example 1:
    /// 
    /// Input:     1         1
    ///           / \       / \
    ///           2   3     2   3
    /// 
    /// [1,2,3],   [1,2,3]
    /// 
    /// Output: true
    /// 
    /// Example 2:
    /// 
    /// Input:     1         1
    ///           /           \
    ///           2             2
    /// 
    /// [1,2],     [1,null,2]
    /// 
    /// Output: false
    /// 
    /// Example 3:
    /// 
    /// Input:     1         1
    ///           / \       / \
    ///           2   1     1   2
    /// 
    /// [1,2,1],   [1,1,2]
    /// 
    /// Output: false
    /// </summary>
    class SameTree
    {
        [Test, MaxTime(1000)]
        [TestCaseSource(nameof(TestData))]
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            if (p == null || q == null) return false;

            return p.val == q.val && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }

        public static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(
                    new TreeNode(1),
                    new TreeNode(1)
                ).Returns(true);

                yield return new TestCaseData(
                    new TreeNode(1),
                    new TreeNode(2)
                ).Returns(false);

                yield return new TestCaseData(
                    new TreeNode(1, new TreeNode(2), new TreeNode(3)),
                    new TreeNode(1, new TreeNode(2), new TreeNode(3))
                ).Returns(true);

                yield return new TestCaseData(
                    new TreeNode(1, new TreeNode(2),null),
                    new TreeNode(1, null, new TreeNode(2))
                ).Returns(false);

                yield return new TestCaseData(
                    new TreeNode(1, new TreeNode(2), new TreeNode(1)),
                    new TreeNode(1, new TreeNode(1), new TreeNode(2))
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
                
                return $"[{val}->{left}|{right  }]";
            }
        }

    }
}