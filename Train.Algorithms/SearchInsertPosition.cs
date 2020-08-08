using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/search-insert-position/
    ///
    /// Given a sorted array and a target value, return the index
    /// if the target is found. If not, return the index where it
    /// would be if it were inserted in order.
    /// 
    /// You may assume no duplicates in the array.
    /// </summary>
    class SearchInsertPosition
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public int SearchInsert(int[] nums, int target)
        {
            if (nums.Length == 0) return 0;

            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] >= target) return i;
            }

            return nums.Length;
        }

        int recursiveBinarySearch(ref int[] nums, ref int target, int left, int right)
        {
            if (left > right) return left;

            var mid = left + (right - left) / 2;
            if (nums[mid] == target)
            {
                return mid;
            }
            else if (nums[mid] < target)
            {
                return recursiveBinarySearch(ref nums, ref target, mid + 1, right);
            }
            else
            {
                return recursiveBinarySearch(ref nums, ref target, left, mid - 1);
            }
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public int SearchInsertRecursiveBinarySearch(int[] nums, int target)
        {
            return recursiveBinarySearch(ref nums, ref target, 0, nums.Length - 1);

        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public int SearchInsertIterativeBinarySearch(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                var mid = left + (right - left) / 2;

                if (nums[mid] == target) return mid;
                else if (nums[mid] < target) left = mid + 1;
                else right = mid - 1;
            }

            return left;

        }

        public static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(new int[0], 5).Returns(0);
                yield return new TestCaseData(new int[] { 1 }, 5).Returns(1);
                yield return new TestCaseData(new int[] { 3 }, 2).Returns(0);
                yield return new TestCaseData(new int[] {1, 3, 5, 6}, 5).Returns(2);
                yield return new TestCaseData(new int[] {1, 3, 5, 6}, 2).Returns(1);
                yield return new TestCaseData(new int[] {1, 3, 5, 6}, 7).Returns(4);
                yield return new TestCaseData(new int[] {1, 3, 5, 6}, 0).Returns(0);

            }
        }
    }
}
