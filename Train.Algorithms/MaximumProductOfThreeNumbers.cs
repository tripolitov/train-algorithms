using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/maximum-product-of-three-numbers/
    /// 
    /// Maximum Product of Three Numbers
    ///
    /// Given an integer array nums, find three numbers whose product is maximum and return the maximum product.
    ///
    /// Example 1:
    /// 
    /// Input: nums = [1,2,3]
    /// Output: 6
    /// 
    /// Example 2:
    /// 
    /// Input: nums = [1,2,3,4]
    /// Output: 24
    /// 
    /// Example 3:
    /// 
    /// Input: nums = [-1,-2,-3]
    /// Output: -6
    ///  
    /// Constraints:
    /// 
    /// 3 <= nums.length <= 104
    /// -1000 <= nums[i] <= 1000
    /// </summary>
    public class MaximumProductOfThreeNumbers
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public int MaximumProduct(int[] nums)
        {
            if (nums.Length < 3) return 0;
            if (nums.Length == 3) return nums[0] * nums[1] * nums[2];

            int[] max = new int[3] {Int32.MinValue, Int32.MinValue, Int32.MinValue};
            int[] min = new int[2] {Int32.MaxValue, Int32.MaxValue};

            foreach (var n in nums)
            {
                if (n > max[0])
                {
                    max[2] = max[1];
                    max[1] = max[0];
                    max[0] = n;
                }
                else if (n > max[1])
                {
                    max[2] = max[1];
                    max[1] = n;
                }
                else if (n > max[2])
                {
                    max[2] = n;
                }

                if (n < min[0])
                {
                    min[1] = min[0];
                    min[0] = n;
                }
                else if (n < min[1])
                {
                    min[1] = n;
                }
            }

            return Math.Max(max[0] * max[1] * max[2], max[0] * min[0] * min[1]);
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(new int[] {1, 2, 3}).Returns(6);
                yield return new TestCaseData(new int[] {1, 2, 3, 4}).Returns(24);
                yield return new TestCaseData(new int[] {-1, -2, -3}).Returns(-6);
                yield return new TestCaseData(new int[] {-1, -2, -3, -4}).Returns(-6);
                yield return new TestCaseData(new int[] {-1, -2, -3, 4}).Returns(24);
                yield return new TestCaseData(new int[] {-100, -98, -1, 2, 3, 4}).Returns(39200);
            }
        }
    }
}