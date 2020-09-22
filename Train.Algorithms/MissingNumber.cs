using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/missing-number/
    ///
    /// Missing Number
    /// 
    /// Given an array containing n distinct numbers taken from 0, 1, 2, ..., n, find the one that is missing from the array.
    /// 
    /// Example 1:
    /// 
    /// Input: [3,0,1]
    /// Output: 2
    /// Example 2:
    /// 
    /// Input: [9,6,4,2,3,5,7,0,1]
    /// Output: 8
    /// Note:
    /// Your algorithm should run in linear runtime complexity. Could you implement it using only constant extra space complexity?
    /// </summary>
    public class MissingNumber
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public int FindMissingNumber(int[] nums)
        {
            var sum = 0;
            foreach (var num in nums)
            {
                sum += num;
            }

            // arithmetic progression
            var targetSum = nums.Length * (nums.Length + 1) / 2;

            return targetSum - sum;
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(new int[] {0}).Returns(1);
                yield return new TestCaseData(new int[] {0,2}).Returns(1);
                yield return new TestCaseData(new int[] {0,1,3}).Returns(2);
                yield return new TestCaseData(new int[] {3,0,1}).Returns(2);
                yield return new TestCaseData(new int[] {9,6,4,2,3,5,7,0,1}).Returns(8);
            }
        }
    }
}