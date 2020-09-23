using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/range-sum-query-immutable/
    ///
    /// Range Sum Query - Immutable
    ///
    /// Given an integer array nums, find the sum of the elements between indices i and j (i ≤ j), inclusive.
    /// 
    /// Example:
    /// 
    /// Given nums = [-2, 0, 3, -5, 2, -1]
    /// 
    /// sumRange(0, 2) -> 1
    /// sumRange(2, 5) -> -1
    /// sumRange(0, 5) -> -3
    /// 
    /// 
    /// Constraints:
    /// 
    /// You may assume that the array does not change.
    /// - There are many calls to sumRange function.
    /// - 0 <= nums.length <= 10^4
    /// - -10^5 <= nums[i] <= 10^5
    /// - 0 <= i <= j < nums.length
    /// </summary>
    public class RangeSumQueryImmutable
    {
        class NumArray
        {
            private readonly int[] _sums;

            public NumArray(int[] nums)
            {
                _sums = new int[nums.Length];
                if (nums.Length > 0)
                {
                    _sums[0] = nums[0];
                    for (var i = 1; i < nums.Length; i++)
                    {
                        _sums[i] = _sums[i - 1] + nums[i];
                    }
                }
            }

            public int SumRange(int i, int j)
            {
                if (i == 0) return _sums[j];
                return _sums[j] - _sums[i - 1];
            }
        }

        [Test]
        public void Test1()
        {
            var sut = new NumArray(new int[] {-2, 0, 3, -5, 2, -1});
            Assert.AreEqual(1, sut.SumRange(0, 2));
            Assert.AreEqual(-1, sut.SumRange(2, 5));
            Assert.AreEqual(-3, sut.SumRange(0, 5));
        }
    }
}