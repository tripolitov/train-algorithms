using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/intersection-of-two-arrays/
    /// 
    /// Intersection of Two Arrays
    ///
    /// Given two arrays, write a function to compute their intersection.
    /// 
    /// Example 1:
    /// 
    /// Input: nums1 = [1,2,2,1], nums2 = [2,2]
    /// Output: [2]
    /// 
    /// Example 2:
    /// 
    /// Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
    /// Output: [9,4]
    /// 
    /// Note:
    /// 
    /// Each element in the result must be unique.
    /// The result can be in any order.
    /// </summary>
    public class IntersectionOfTwoArrays
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public void IntersectionHashSetTest(int[] nums1, int[] nums2, int[] expected)
        {
            var actual = IntersectionHashSet(nums1, nums2);

            CollectionAssert.AreEquivalent(expected, actual);
        }

        private int[] IntersectionHashSet(int[] nums1, int[] nums2)
        {
            var h1 = new HashSet<int>(nums1);
            var h2 = new HashSet<int>(nums2);

            var (a, b) = h1.Count < h2.Count ? (h1, h2) : (h2, h1);

            var result = new List<int>();

            foreach (var n in a)
            {
                if (b.Contains(n))
                    result.Add(n);
            }

            return result.ToArray();
        }


        [Test]
        [TestCaseSource(nameof(TestData))]
        public void IntersectionSortTest(int[] nums1, int[] nums2, int[] expected)
        {
            var actual = IntersectionSort(nums1, nums2);

            CollectionAssert.AreEquivalent(expected, actual);
        }

        private int[] IntersectionSort(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1);
            Array.Sort(nums2);

            var result = new List<int>();
            int i = 0, j = 0;

            while (i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] < nums2[j]) i += 1;
                else if (nums1[i] > nums2[j]) j += 1;
                else
                {
                    result.Add(nums1[i]);
                    do i += 1;
                    while (i < nums1.Length && nums1[i] == nums1[i - 1]);
                    do j += 1;
                    while (j < nums2.Length && nums2[j] == nums2[j - 1]);
                }
            }

            return result.ToArray();
        }
        
        [Test]
        [TestCaseSource(nameof(TestData))]
        public void IntersectionBinarySearchTest(int[] nums1, int[] nums2, int[] expected)
        {
            var actual = IntersectionBinarySearch(nums1, nums2);

            CollectionAssert.AreEquivalent(expected, actual);
        }

        bool Contains(int[] nums, int n)
        {
            int left = 0, right = nums.Length - 1;

            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                if (nums[mid] == n) return true;
                
                if (nums[mid] < n) left = mid + 1;
                if (nums[mid] > n) right = mid - 1;
            }

            return false;
        }

        private int[] IntersectionBinarySearch(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1);
            Array.Sort(nums2);
            var result = new List<int>();
            var i = 0;
            while (i < nums1.Length)
            {
                if(Contains(nums2, nums1[i]))
                    result.Add(nums1[i]);

                do i += 1;
                while (i < nums1.Length && nums1[i] == nums1[i - 1]);
            }

            return result.ToArray();
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(new int[0] { }, new int[0] { }, new int[0] { });
                yield return new TestCaseData(new int[] {4, 9, 5}, new int[] {9, 4, 9, 8, 4}, new int[] {9, 4});
                yield return new TestCaseData(new int[] {1, 2, 2, 1}, new int[] {2, 2}, new int[] {2});
                yield return new TestCaseData(new int[] {1, 2, 3}, new int[] {4, 5, 6}, new int[0] { });
            }
        }
    }
}