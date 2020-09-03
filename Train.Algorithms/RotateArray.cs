using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/rotate-array/
    /// 
    /// Rotate Array
    ///
    /// Given an array, rotate the array to the right by k steps, where k is non-negative.
    ///
    /// Follow up:
    ///
    /// Try to come up as many solutions as you can, there are at least 3 different ways to solve this problem.
    /// Could you do it in-place with O(1) extra space?
    ///
    /// Example 1:
    ///
    /// Input: nums = [1,2,3,4,5,6,7], k = 3
    /// Output: [5,6,7,1,2,3,4]
    /// 
    /// Explanation:
    /// rotate 1 steps to the right: [7,1,2,3,4,5,6]
    /// rotate 2 steps to the right: [6,7,1,2,3,4,5]
    /// rotate 3 steps to the right: [5,6,7,1,2,3,4]
    /// 
    /// Example 2:
    ///
    /// Input: nums = [-1,-100,3,99], k = 2
    /// Output: [3,99,-1,-100]
    /// 
    /// Explanation: 
    /// rotate 1 steps to the right: [99,-1,-100,3]
    /// rotate 2 steps to the right: [3,99,-1,-100]
    /// </summary>
    class RotateArray
    {
        public void Rotate(int[] nums, int k)
        {
            if (nums.Length <= 1 || k % nums.Length == 0) return;

            k = k % nums.Length;

            var temp = new int[nums.Length];

            for (var i = 0; i < nums.Length; i++)
            {
                var j = (i + k) % nums.Length;
                temp[j] = nums[i];
            }

            for (var i = 0; i < nums.Length; i++)
            {
                nums[i] = temp[i];
            }
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public int[] TestRotate(int[] nums, int k)
        {
            Rotate(nums, k);
            return nums;
        }

        /// <summary>
        /// The basic idea is to reverse left and right parts of the array
        /// separately and then revers the whole array
        ///
        /// Example:
        ///
        /// For array [1,2,3,4,5,6,7,8,9] and k = 4
        ///
        /// Step 1 - [1,2,3,4,5] [6,7,8,9] ---> [5,4,3,2,1] [6,7,8,9]
        /// 
        /// Step 2 - [5,4,3,2,1] [6,7,8,9] ---> [5,4,3,2,1] [9,8,7,6]
        /// 
        /// Step 3 - [5,4,3,2,1, 9,8,7,6] ---> [6,7,8,9,1,2,3,4,5]
        /// </summary>
        public void RotateInPlace(int[] nums, int k)
        {
            if (nums.Length <= 1 || k % nums.Length == 0) return;

            k %= nums.Length;

            void reverse(int[] a, int i, int j)
            {
                while (i < j)
                {
                    (a[i], a[j]) = (a[j], a[i]);
                    i++;
                    j--;
                }
            }

            reverse(nums, 0, nums.Length - k - 1);
            reverse(nums, nums.Length - k, nums.Length - 1);
            reverse(nums, 0, nums.Length - 1);
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public int[] TestRotateInPlace(int[] nums, int k)
        {
            RotateInPlace(nums, k);
            return nums;
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(new int[0], 3).Returns(new int[0]);
                yield return new TestCaseData(new int[] { 1 }, 3).Returns(new int[] { 1 });
                yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5 }, 1).Returns(new int[] { 5, 1, 2, 3, 4 });
                yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5 }, 6).Returns(new int[] { 5, 1, 2, 3, 4 });
                yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5 }, 5).Returns(new int[] { 1, 2, 3, 4, 5 });
                yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3).Returns(new int[] { 5, 6, 7, 1, 2, 3, 4 });
                yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 4).Returns(new int[] { 6, 7, 8, 9, 1, 2, 3, 4, 5 });
                yield return new TestCaseData(new int[] { -1, -100, 3, 99 }, 2).Returns(new int[] { 3, 99, -1, -100 });
            }
        }
    }
}
