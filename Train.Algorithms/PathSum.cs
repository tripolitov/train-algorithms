using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// /https://leetcode.com/problems/path-sum/
    ///
    /// Path Sum
    /// 
    /// Given a binary tree and a sum, determine if the tree
    /// has a root-to-leaf path such that adding up all the
    /// values along the path equals the given sum.
    /// 
    /// Note: A leaf is a node with no children.
    /// 
    /// Example:
    /// 
    /// Given the below binary tree and sum = 22,
    /// 
    ///       5
    ///      / \
    ///     4   8
    ///    /   / \
    ///   11  13  4
    ///  /  \      \
    /// 7    2      1
    /// return true, as there exist a root-to-leaf path 5->4->11->2 which sum is 22.
    /// 
    /// </summary>
    class PathSum
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null) return false;
            if (root.left == null && root.right == null)
                return root.val == sum;

            return HasPathSum(root.left, sum - root.val) || HasPathSum(root.right, sum - root.val);
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(null, 0).Returns(false);
                yield return new TestCaseData(new TreeNode(5), 5).Returns(true);
                yield return new TestCaseData(new TreeNode(5, new TreeNode(1), new TreeNode(2)), 7).Returns(true);
                yield return new TestCaseData(
                    new TreeNode(5,
                        new TreeNode(4,
                            new TreeNode(11,
                                new TreeNode(7),
                                new TreeNode(2)
                            )
                        ),
                        new TreeNode(8,
                            new TreeNode(13),
                            new TreeNode(4,
                                null,
                                new TreeNode(1)
                            )
                        )
                    )
                    , 22
                ).Returns(true);
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
