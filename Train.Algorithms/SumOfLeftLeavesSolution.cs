using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/sum-of-left-leaves/
    /// 
    /// Sum of Left Leaves
    ///
    /// Find the sum of all left leaves in a given binary tree.
    ///  Example:
    ///
    ///    3
    ///   / \
    ///  9  20
    ///    /  \
    ///   15   7
    ///
    ///  There are two left leaves in the binary tree, with values 9 and 15 respectively. Return 24.
    /// </summary>
    public class SumOfLeftLeavesSolution
    {
        [Test][TestCaseSource(nameof(TestData))]
        public int SumOfLeftLeaves(TreeNode root) {
            int rec(TreeNode node, bool left = false)
            {
                if (node == null) return 0;
                if (node.left == null && node.right == null) return left ? node.val : 0;

                return rec(node.left, true) + rec(node.right);
            }

            return rec(root, false);
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(null).Returns(0);
                yield return new TestCaseData(new TreeNode(0)).Returns(0);
                yield return new TestCaseData(new TreeNode(1)).Returns(0);
                yield return new TestCaseData(new TreeNode(3, new TreeNode(1))).Returns(1);
                yield return new TestCaseData(new TreeNode(3, new TreeNode(1, null, new TreeNode(2)))).Returns(0);
                yield return new TestCaseData(
                    new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)))
                    
                    ).Returns(24);
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