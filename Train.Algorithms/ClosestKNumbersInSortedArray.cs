using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// Given a target number, a non-negative integer k
    /// and an integer array A sorted in ascending order,
    /// find the k closest numbers to target in A, sorted
    /// in ascending order by the difference between the
    /// number and target. Otherwise, sorted in ascending
    /// order by number if the difference is same.
    /// 
    /// Example
    /// 
    /// Given A = [1, 2, 3], target =2and k = 3, return[2, 1, 3].
    /// 
    /// Given A = [1, 4, 6, 8], target = 3and k = 3, return[4, 1, 6].
    /// </summary>
    class ClosestKNumbersInSortedArray
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public int[] Test(int[] a, int k, int x)
        {
            if (a.Length == 0 || a.Length < k || k <= 0) return new int[0];
            if (a.Length == k) return a;

            var start = Find(a, x);

            int r = 0;
            int[] result = new int[k];
            
            int i = start - 1;
            int j = start + 1;
            result[r++] = a[start];
            while (i > 0 && j < a.Length && r < k) {
                var c1 = Math.Abs(a[i] - x);
                var c2 = Math.Abs(a[j] - x);

                if (c1 <= c2) {
                    result[r++] = a[i--];
                }
                else {
                    result[r++] = a[j++];
                }
            }

            while (i > 0 && r < k) { result[r++] = a[i--]; }
            while (j < a.Length && r < k) { result[r++] = a[j++]; }

            return result;
        }

        [Test]
        [TestCaseSource(nameof(TestData_Find))]
        public int Find(int[] a, int x)
        {
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

            return left;
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(new[] {1, 2, 3, 3, 4, 5, 6, 7, 8}, 3, 4).Returns(new int[3] {4, 3, 3});
                yield return new TestCaseData(new[] {1, 7, 8, 13, 22, 66, 33}, 3, 10).Returns(new int[3] {8, 7, 13});
            }
        }

        static IEnumerable<TestCaseData> TestData_Find
        {
            get
            {
                yield return new TestCaseData(new[] { 1 }, 4).Returns(0);
                yield return new TestCaseData(new[] { 1 }, 1).Returns(0);
                yield return new TestCaseData(new[] { 1, 2 }, 1).Returns(0);
                yield return new TestCaseData(new[] { 1, 2, 3, 3, 4, 5, 6, 7, 8 }, 4).Returns(4);
                yield return new TestCaseData(new[] { 1, 7, 8, 13, 22, 66, 33 }, 10).Returns(2);
            }
        }
    }
}
