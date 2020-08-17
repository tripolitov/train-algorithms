using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// Given a target number and an integer array A sorted
    /// in ascending order, find the indexi in A such that A[i]
    /// is closest to the given target.
    /// Return -1 if there is no element in the array.
    /// 
    /// Notice
    /// There can be duplicate elements in the array, and we can return any of the indices with same value.
    /// 
    /// Example
    /// 
    /// Given[1, 2, 3] and target = 2, return 1.
    /// Given[1, 4, 6] and target = 3, return 1.
    /// Given[1, 4, 6] and target = 5, return 1 or 2.
    /// Given[1, 3, 3, 4] and target = 2, return 0 or 1 or 2.
    /// </summary>
    class ClosestNumberInSortedArray
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public int Test(int[] a, int x)
        {
            if (a.Length == 0) return -1;

            var left = 0;
            var right = a.Length - 1;

            while (left + 1 < right)
            {
                var mid = left + (right - left) / 2;

                if (a[mid] <= x)
                    left = mid;
                else
                    right = mid;
            }

            return Math.Abs(a[left] - x) <= Math.Abs(a[right] - x) 
                ? left 
                : right;

        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(new int[0], 1).Returns(-1);
                yield return new TestCaseData(new[] {1, 2, 3}, 2).Returns(1);
                yield return new TestCaseData(new[] {1, 4, 6}, 3).Returns(1);
                yield return new TestCaseData(new[] {1, 4, 6}, 5).Returns(1);
                yield return new TestCaseData(new[] {1, 3, 3, 4}, 2).Returns(0);
                yield return new TestCaseData(new[] {1, 2, 3, 3, 4, 5, 6, 7, 8}, 4).Returns(4);
                yield return new TestCaseData(new[] {1, 7, 8, 13, 22, 66, 33}, 10).Returns(2);
            }
        }
    }
}
