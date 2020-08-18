using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/binary-tree-level-order-traversal-ii/
    ///
    /// Given a binary tree, return the bottom-up level order
    /// traversal of its nodes' values. (ie, from left to right,
    /// level by level from leaf to root).
    /// 
    /// For example:
    /// Given binary tree[3, 9, 20, null, null, 15, 7],
    ///      3
    ///     / \
    ///     9  20
    ///       /  \
    ///      15   7
    /// return its bottom-up level order traversal as:
    /// [
    ///     [15,7],
    ///     [9,20],
    ///     [3]
    /// ]
    /// </summary>
    class BinaryTreeLevelOrderTraversal
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            var result = new List<IList<int>>();

            if (root == null) return result;

            var q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                var list = new List<int>();
                for (var i = q.Count - 1; i >=0; i--)
                {
                    var node = q.Dequeue();

                    if (node.left != null) q.Enqueue(node.left);
                    if (node.right != null) q.Enqueue(node.right);

                    list.Add(node.val);
                }

                result.Insert(0, list);
            }

            return result;
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(null).Returns(new List<IList<int>>());

                yield return new TestCaseData(
                        new TreeNode(3))
                    .Returns(new List<IList<int>> {new List<int>() {3}});

                yield return new TestCaseData(
                        new TreeNode(3, 
                            new TreeNode(9),
                            new TreeNode(20, new TreeNode(15), new TreeNode(7))))
                    .Returns(new List<IList<int>>
                    {
                        new List<int>() {15, 7},
                        new List<int>() {9, 20},
                        new List<int>() {3},
                    });

                yield return new TestCaseData(
                        new TreeNode(3,
                            new TreeNode(9),
                            new TreeNode(20, new TreeNode(15), new TreeNode(7, new TreeNode(1)))))
                    .Returns(new List<IList<int>>
                    {
                        new List<int>() {1},
                        new List<int>() {15, 7},
                        new List<int>() {9, 20},
                        new List<int>() {3},
                    });

                yield return new TestCaseData(
                        new TreeNode(3,
                            new TreeNode(9, new TreeNode(15), new TreeNode(7)), 
                            new TreeNode(20,new TreeNode(15), new TreeNode(7))))
                    .Returns(new List<IList<int>>
                    {
                        new List<int>() {15, 7, 15, 7},
                        new List<int>() {9, 20},
                        new List<int>() {3},
                    });
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
