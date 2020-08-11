using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/maximum-subarray/
    /// 
    /// Given an integer array nums, find the contiguous 
    /// subarray (containing at least one number) which 
    /// has the largest sum and return its sum.
    /// 
    /// Example:
    /// Input: [-2,1,-3,4,-1,2,1,-5,4],
    /// Output: 6
    /// Explanation: [4,-1,2,1] has the largest sum = 6.
    /// 
    /// Follow up:
    /// If you have figured out the O(n) solution, try
    /// coding another solution using the divide and conquer
    /// approach, which is more subtle.
    /// </summary>
    class MaximumSubArray
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public int Iterative(int[] nums)
        {
            if (nums.Length == 0) return 0;

            var result = nums[0];
            var temp = nums[0];

            for (var i = 1; i < nums.Length; i++)
            {
                temp += nums[i];

                if (temp < nums[i])
                    temp = nums[i];
                
                if (temp > result)
                    result = temp;
            }

            return result;
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public int Recursive(int[] nums)
        {
            int f(int i = 0, int result = 0)
            {
                if (i >= nums.Length) return result;

                result = result > 0
                    ? result + nums[i]
                    : nums[i];

                return Math.Max(result, f(i + 1, result));
            }

            return f();
        }

        public static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }).Returns(6);
                yield return new TestCaseData(new int[] { -2, 1, 2, 3, -6, 5, 1, 1, -7 }).Returns(7);
                yield return new TestCaseData(new int[] { -1, -2, -3, 7, -8, 0 }).Returns(7);
                yield return new TestCaseData(new int[] { -1 }).Returns(-1);
                yield return new TestCaseData(new int[] { -2, 1 }).Returns(1);
                yield return new TestCaseData(new int[] { -2, -1 }).Returns(-1);
                yield return new TestCaseData(new int[] {  }).Returns(0);
            }
        }
    }
}
