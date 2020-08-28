using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/
    /// 
    /// Two Sum II - Input array is sorted
    ///
    /// Given an array of integers that is already sorted in ascending order,
    /// find two numbers such that they add up to a specific target number.
    /// 
    /// The function twoSum should return indices of the two numbers such that
    /// they add up to the target, where index1 must be less than index2.
    /// 
    /// Note:
    /// 
    /// Your returned answers(both index1 and index2) are not zero-based.
    /// You may assume that each input would have exactly one solution and you
    /// may not use the same element twice.
    ///
    /// Example:
    /// 
    /// Input: numbers = [2, 7, 11, 15], target = 9
    /// Output: [1,2]
    ///
    /// Explanation: The sum of 2 and 7 is 9. Therefore index1 = 1, index2 = 2.
    /// </summary>
    class TwoSum2InputArrayIsSorted
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public int[] TwoSumTwoLoops(int[] numbers, int target)
        {
            if (numbers.Length < 2) return null;
            for (int i = 0; i < numbers.Length; i++)
            for (int j = i + 1; j < numbers.Length; j++)
            {
                var c = target - numbers[i] - numbers[j];
                if (c < 0) break;

                if (c == 0)
                {
                    return new int[] { i + 1, j + 1 };
                }
            }
            return null;
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public int[] TwoSumTwoPointers(int[] numbers, int target)
        {
            int l = 0, r = numbers.Length - 1;
            while (l < r)
            {
                var s = numbers[l] + numbers[r];
                if (s == target) return new[] {l + 1, r + 1};

                if (s < target) l++;
                else r--;
            }
            return null;
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public int[] TwoSumBinarySearch(int[] numbers, int target)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                int l = i + 1, r = numbers.Length - 1;
                while (l <= r)
                {
                    int mid = l + (r - l) / 2;
                    var s = numbers[i] + numbers[mid];

                    if (s == target) return new int[] {i + 1, mid + 1};

                    if (s < target) l = mid + 1;
                    else r = mid - 1;
                }
            }
            return null;
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public int[] TwoSumDictionary(int[] numbers, int target)
        {
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (dict.ContainsKey(numbers[i]))
                    return new int[] {dict[numbers[i]] + 1, i + 1};

                
                dict[target - numbers[i]] = i;
            }

            return null;
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(new int[] {2, 7, 13, 15}, 9).Returns(new int[] {1, 2});
                yield return new TestCaseData(new int[] { 2, 3, 5, 7, 13, 15 }, 9).Returns(new int[] { 1, 4 });
            }
        }
    }
}
