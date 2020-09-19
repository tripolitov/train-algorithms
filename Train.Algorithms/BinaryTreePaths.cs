using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/binary-tree-paths/
    ///
    /// Binary Tree Paths
    ///
    /// Given a binary tree, return all root-to-leaf paths.
    /// 
    /// Note: A leaf is a node with no children.
    /// 
    /// Example:
    /// 
    /// Input:
    /// 
    ///    1
    ///  /   \
    ///  2     3
    ///   \
    ///    5
    /// 
    /// Output: ["1->2->5", "1->3"]
    /// 
    /// Explanation: All root-to-leaf paths are: 1->2->5, 1->3
    /// </summary>
    public class BinaryTreePaths
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public IList<string> BinaryTreePaths_Func(TreeNode root)
        {
            IEnumerable<string> rec(TreeNode node, string path = "")
            {
                if (node == null) return Enumerable.Empty<string>();
                
                if (node.left == null && node.right == null)
                {
                    return new [] {$"{path}{node.val}"};
                }

                return rec(node.left, $"{path}{node.val}->")
                       .Concat(rec(node.right, $"{path}{node.val}->"));
            }

            return rec(root).ToList();
        }

        [Test][TestCaseSource(nameof(TestData))]
        public IList<string> BinaryTreePaths_Recursive(TreeNode root)
        {
            if (root == null) return new string[0];
            
            void rec(TreeNode node, string path, List<string> result)
            {
                if (node.left == null && node.right == null)
                {
                    result.Add($"{path}{node.val}");
                }

                if (node.left != null) rec(node.left, $"{path}{node.val}->", result);
                if (node.right != null) rec(node.right, $"{path}{node.val}->", result);
            }

            var r = new List<string>();
            rec(root, "", r);
            return r;
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(null)
                    .Returns(new string[0]);
                yield return new TestCaseData(new TreeNode(1))
                    .Returns(new [] {"1"});
                yield return new TestCaseData(new TreeNode(1, new TreeNode(2)))
                    .Returns(new [] {"1->2"});
                yield return new TestCaseData(new TreeNode(1, new TreeNode(2), new TreeNode(3)))
                    .Returns(new [] {"1->2", "1->3"});
                yield return new TestCaseData(new TreeNode(1, new TreeNode(2, null,new TreeNode(5)), new TreeNode(3)))
                    .Returns(new [] {"1->2->5", "1->3"});
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