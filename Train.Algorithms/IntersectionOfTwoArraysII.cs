using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/intersection-of-two-arrays-ii/
    /// 
    /// Intersection of Two Arrays II
    ///
    /// Given two arrays, write a function to compute their intersection.
    ///
    /// Example 1:
    /// 
    /// Input: nums1 = [1,2,2,1], nums2 = [2,2]
    /// Output: [2,2]
    /// 
    /// Example 2:
    /// 
    /// Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
    /// Output: [4,9]
    /// 
    /// Note:
    /// 
    /// Each element in the result should appear as many times as it shows in both arrays.
    /// The result can be in any order.
    /// Follow up:
    /// 
    /// What if the given array is already sorted? How would you optimize your algorithm?
    /// What if nums1's size is small compared to nums2's size? Which algorithm is better?
    /// What if elements of nums2 are stored on disk, and the memory is limited such that you cannot load all elements
    /// into the memory at once?
    /// </summary>
    public class IntersectionOfTwoArraysII
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public void IntersectionSortTest(int[] nums1, int[] nums2, int[] expected)
        {
            var actual = IntersectSort(nums1, nums2);

            CollectionAssert.AreEquivalent(expected, actual);
        }
        
        int[] IntersectSort(int[] nums1, int[] nums2)
        {
            var result = new List<int>();
            Array.Sort(nums1);
            Array.Sort(nums2);
            
            int i = 0, j = 0;
            while(i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] == nums2[j])
                {
                    result.Add(nums1[i]);
                    i += 1;
                    j += 1;
                }
                else if (nums1[i] < nums2[j]) i += 1;
                else if (nums1[i] > nums2[j]) j += 1;
            }

            return result.ToArray();
        }
        
        [Test]
        [TestCaseSource(nameof(TestData))]
        public void IntersectionHashSetTest(int[] nums1, int[] nums2, int[] expected)
        {
            var actual = IntersectionHashSet(nums1, nums2);

            CollectionAssert.AreEquivalent(expected, actual);
        }
        
        int[] IntersectionHashSet(int[] nums1, int[] nums2)
        {
            var result = new List<int>();
            var map = new Dictionary<int, int>();
            
            foreach (var n in nums1)
            {
                if (map.ContainsKey(n)) map[n] += 1;
                else map[n] = 1;
            }

            foreach (var n in nums2)
            {
                if (map.ContainsKey(n) && map[n] > 0)
                {
                    result.Add(n);
                    map[n] -= 1;
                }
            }

            return result.ToArray();
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(new int[0] { }, new int[0] { }, new int[0] { });
                yield return new TestCaseData(new int[] {4, 9, 5}, new int[] {9, 4, 9, 8, 4}, new int[] {4, 9});
                yield return new TestCaseData(new int[] {1, 2, 2, 1}, new int[] {2, 2}, new int[] {2, 2});
                yield return new TestCaseData(new int[] {1, 2, 3}, new int[] {4, 5, 6}, new int[0] { });
            }
        }
    }
}