using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/array-partition-i/
    /// 
    /// Array Partition I
    ///
    /// Given an array of 2n integers, your task is to group these integers
    /// into n pairs of integer, say (a1, b1), (a2, b2), ..., (an, bn) which
    /// makes sum of min(ai, bi) for all i from 1 to n as large as possible.
    /// 
    /// Example 1:
    /// Input: [1,4,3,2]
    /// 
    /// Output: 4
    /// Explanation: n is 2, and the maximum sum of pairs is 4 = min(1, 2) + min(3, 4).
    /// Note:
    /// n is a positive integer, which is in the range of [1, 10000].
    /// All the integers in the array will be in the range of [-10000, 10000].
    /// </summary>
    public class ArrayPartitionI
    {
        [Test][TestCaseSource(nameof(TestData))]
        public int ArrayPairSum(int[] nums)
        {
            Array.Sort(nums);
            var result = 0;
            for (var i = 0; i < nums.Length; i += 2)
                result += nums[i];

            return result;
        }

        [Test][TestCaseSource(nameof(TestData))]
        public int ArrayPairSumOn(int[] nums)
        {
            // use counting sort as input is limited to [-10000, 10000] range
            var count = new int[20001];
            foreach (var num in nums)
                count[num + 10000] += 1;
            
            var result = 0;

            var isOdd = true; // starting from first
            for (var i = 0; i < count.Length; i++)
            {
                while (count[i] > 0) // handle duplicates
                {
                    if (isOdd)
                    {
                        result += i - 10000;
                    }

                    isOdd = !isOdd;
                    count[i] -= 1;
                }
            }

            return result;
        }
        
        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(new int[]{}).Returns(0);
                yield return new TestCaseData(new int[]{1,2}).Returns(1);
                yield return new TestCaseData(new int[]{1,2,2,3}).Returns(3);
                yield return new TestCaseData(new int[]{1,3,4,2}).Returns(4);
                yield return new TestCaseData(new int[]{-10000, -1, 1, 10000}).Returns(-9999);
            }
        }
    }
}