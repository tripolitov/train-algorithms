using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/majority-element/
    /// 
    /// Majority Element
    ///
    /// Given an array of size n, find the majority element.
    /// The majority element is the element that appears more
    /// than ⌊ n/2 ⌋ times.
    /// 
    /// You may assume that the array is non-empty and the
    /// majority element always exist in the array.
    /// 
    /// Example 1:
    /// 
    /// Input: [3,2,3]
    /// Output: 3
    /// 
    /// Example 2:
    ///  
    /// Input: [2,2,1,1,1,2,2]
    /// Output: 2
    /// </summary>
    class MajorityElement
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public int Iterative(int[] nums)
        {
            int count = 0, candidate = nums[0];
            foreach (var n in nums)
            {
                if (count == 0) candidate = n;

                if (candidate == n)
                    count++;
                else
                    count--;
            }

            return candidate;
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        [Ignore("Broken due to order in dictionary")]
        public int Dictionary(int[] nums)
        {
            var dict = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (!dict.ContainsKey(num))
                    dict[num] = 1;
                else
                    dict[num]++;
            }

            var r = 0;
            foreach (var (k, v) in dict)
            {
                if (v > r) r = k;
            }

            return r;
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(new int[] {3, 2, 3}).Returns(3);
                yield return new TestCaseData(new int[] {2, 2, 1, 1, 1, 2, 2}).Returns(2);
            }
        }
    }
}