using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/merge-sorted-array/
    ///
    /// Given two sorted integer arrays nums1 and nums2,
    /// merge nums2 into nums1 as one sorted array.
    /// Note:
    /// 
    /// The number of elements initialized in nums1 and
    /// nums2 are m and n respectively.  You may assume that
    /// nums1 has enough space (size that is equal to m + n)
    /// to hold additional elements from nums2.
    /// 
    /// Example:
    /// 
    /// Input:
    /// nums1 = [1, 2, 3, 0, 0, 0], m = 3
    /// nums2 = [2, 5, 6], n = 3
    /// 
    /// Output: [1,2,2,3,5,6]
    /// 
    /// 
    /// Constraints:
    /// 
    /// -10^9 <= nums1[i], nums2[i] <= 10^9
    /// nums1.length == m + n
    /// nums2.length == n
    /// Accepted
    /// </summary>
    class MergeSortedArray
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int index = m + n - 1, i = m - 1, j = n - 1;

            while (i >= 0 && j >= 0)
            {
                nums1[index--] = nums1[i] > nums2[j] ? nums1[i--] : nums2[j--];
            }

            while (i >= 0)
            {
                nums1[index--] = nums1[i--];
            }

            while(j >= 0)
            {
                nums1[index--] = nums2[j--];
            }
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public int[] Test(int[] nums1, int m, int[] nums2, int n)
        {
            Merge(nums1, m, nums2, n);
            return nums1;
        }

        public static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(
                        new[] {2, 3, 4, 5, 6, 0}, 5,
                        new[] {1}, 1)
                    .Returns(new[] {1, 2, 3, 4, 5, 6});


                yield return new TestCaseData(
                        new[] {1, 2, 2, 3, 5, 0}, 5,
                        new[] {6}, 1)
                    .Returns(new[] {1, 2, 2, 3, 5, 6});

                yield return new TestCaseData(
                        new[] {1, 2, 3, 0, 0, 0}, 3,
                        new[] {2, 5, 6}, 3)
                    .Returns(new[] {1, 2, 2, 3, 5, 6});
            }
        }
    }
}
