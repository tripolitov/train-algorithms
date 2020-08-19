using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/
    ///
    /// Convert Sorted Array to Binary Search Tree
    /// Given an array where elements are sorted in ascending order,
    /// convert it to a height balanced BST.
    /// 
    /// For this problem, a height-balanced binary tree is defined
    /// as a binary tree in which the depth of the two subtrees of
    /// every node never differ by more than 1.
    /// 
    /// Example:
    /// 
    /// Given the sorted array: [-10,-3,0,5,9],
    /// 
    /// One possible answer is: [0,-3,9,-10,null,5], which represents the following height balanced BST:
    /// 
    ///      0
    ///     / \
    ///   -3   9
    ///   /   /
    /// -10  5
    /// </summary>
    class ConvertSortedArrayToBinarySearchTree
    {
        [Test][TestCaseSource(nameof(TestData))]
        public TreeNode SortedArrayToBST(int[] nums)
        {
            TreeNode f(int[] ns, int l, int r)
            {
                if (r < l) return null;

                var mid = l + (r - l) / 2;
                var left = f(ns, l, mid-1);
                var right = f(ns, mid + 1, r);
                return new TreeNode(ns[mid], left, right);
            }

            return f(nums, 0, nums.Length - 1);
        }
        public static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(new int[0])
                    .Returns(null);

                yield return new TestCaseData(new int[] { -1, 0, 1})
                    .Returns(new TreeNode(0, new TreeNode(-1), new TreeNode(1)));

                yield return new TestCaseData(new int[] { -10, -3, 0, 5, 9 })
                    .Returns(new TreeNode(0, new TreeNode(-10, null, new TreeNode(-3)), new TreeNode(5, null, new TreeNode(9))));
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
                unchecked
                {
                    var hashCode = val;
                    hashCode = (hashCode * 397) ^ (left != null ? left.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (right != null ? right.GetHashCode() : 0);
                    return hashCode;
                }
            }
        }

    }
}