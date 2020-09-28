using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// input: 2 arrays of ints:
    /// - A [1,5,2,8] 
    /// - Limits [2,5,4]
    /// expected output:
    /// - an array [2, 3, 2] where i-th element is a count of elements from A which are less than or equal to i-th
    /// element of Limits
    /// </summary>
    public class CountByLimit
    {
        [Test][TestCaseSource((nameof(TestData)))]
        public int[] Solution(int[] data, int[] limits)
        {
            var result = new int[limits.Length];

            for (var i = 0; i < limits.Length; i++)
            {
                var count = 0;
                for (var j = 0; j < data.Length; j++)
                {
                    if (data[j] <= limits[i]) count += 1;
                }

                result[i] = count;
            }
            
            return result;
        }
        
        /// <summary>
        /// O(nlogn + mlogm)
        /// </summary>
        [Test] [TestCaseSource((nameof(TestData)))]
        public int[] SolutionSort(int[] data, int[] limits)
        {
            var result = new int[limits.Length];
            var limitsSorted = new int[limits.Length];
            Array.Sort(data); // O(n * log n)
            Array.Copy(limits, limitsSorted, limits.Length);
            Array.Sort(limitsSorted); // O(m * log m)

            var map = new Dictionary<int, int>();
            int count = 0, j = 0;
            for (var i = 0; i < limitsSorted.Length; i++) // O(n)
            {
                while (j < data.Length && data[j] <= limitsSorted[i]) // O(m)
                {
                    count += 1;
                    j += 1;
                }
                map[limitsSorted[i]] = count;
            }

            for (var i = 0; i < limits.Length; i++) // O(m)
            {
                result[i] = map[limits[i]];
            }

            return result;
        }

        int find(int[] data, int value)
        {
            int left = 0, right = data.Length - 1;

            while (left <= right)
            {
                var mid = left + (right - left) / 2;

                if (data[mid] <= value) left = mid + 1;
                else right = mid - 1;
            }

            return right;
        }

        /// <summary>
        /// O(nlogn + mlogn)
        /// </summary>
        [Test]
        [TestCaseSource((nameof(TestData)))]
        public int[] SolutionBinarySearch(int[] data, int[] limits)
        {
            Array.Sort(data); // O(n * log n)
            var result = new int[limits.Length];

            // O(m * log n) - "find" uses binary search
            for (var i = 0; i < limits.Length; i++)
            {
                result[i] = find(data, limits[i]) + 1;  
            }

            return result;
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(new int[0], new int[0]).Returns(new int[0]);
                yield return new TestCaseData(new int[0], new int[]{1}).Returns(new int[]{0});
                yield return new TestCaseData(new int[0], new int[]{1,2}).Returns(new int[]{0,0});
                yield return new TestCaseData(new int[0], new int[]{1,2,3}).Returns(new int[]{0,0,0});
                yield return new TestCaseData(new int[] {0}, new int[0]).Returns(new int[0]);
                yield return new TestCaseData(new int[] {1}, new int[0]).Returns(new int[0]);
                yield return new TestCaseData(new int[] {1,2}, new int[0]).Returns(new int[0]);
                yield return new TestCaseData(new int[] {1,2,3}, new int[0]).Returns(new int[0]);
                yield return new TestCaseData(new int[] {1,2,3}, new int[]{1,2,3}).Returns(new int[]{1,2,3});
                yield return new TestCaseData(new int[] {1,2,3}, new int[]{1,2,1}).Returns(new int[]{1,2,1});
                yield return new TestCaseData(new int[] {1, 2, 3, 4, 5}, new int[] {3, 3, 3, 3})
                    .Returns(new int[] {3, 3, 3, 3});
                yield return new TestCaseData(new int[] {1,2,3, 3, 2, 1}, new int[]{1,2,3})
                    .Returns(new int[]{2,4,6});
                yield return new TestCaseData(new int[] {-1,-2,-3, 3, 2, 1}, new int[]{1,2,3})
                    .Returns(new int[]{4,5,6});
                
            }
        }
    }
}