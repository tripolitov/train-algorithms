using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    ///https://leetcode.com/problems/single-number/
    /// 
    /// Single Number
    /// 
    /// Given a non-empty array of integers, every element appears twice except for one. Find that single one.
    /// 
    /// Note:
    /// 
    /// Your algorithm should have a linear runtime complexity.Could you implement it without using extra memory?
    /// 
    /// Example 1:
    /// 
    /// Input: [2,2,1]
    /// Output: 1
    /// Example 2:
    /// 
    /// Input: [4,1,2,1,2]
    /// Output: 4
    /// </summary>
    class SingleNumber
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public int HashSet(int[] nums)
        {
            ICollection<int> m = new HashSet<int>();

            foreach (var num in nums)
            {
                if (m.Contains(num)) m.Remove(num);
                else m.Add(num);
            }

            return m.FirstOrDefault();
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public int Xor(int[] nums)
        {
            // NOTE[MT]: 
            // this approach utilizes 2 options of XOR
            // 1. A XOR A = 0
            // 2. XOR is commutative

            int result = 0;

            for (var i = 0; i < nums.Length; i++)
            {
                var num = nums[i];
                result ^= num;
            }

            return result;
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public int On(int[] nums)
        {
            ICollection<int> m = new HashSet<int>();

            foreach (var num in nums)
            {
                if (m.Contains(num)) m.Remove(num);
                else m.Add(num);
            }

            return m.FirstOrDefault();
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(new int []{ 2, 2, 1 }).Returns(1);
                yield return new TestCaseData(new int []{ 4, 1, 2, 1, 2 }).Returns(4);
                yield return new TestCaseData(new int []{ 2, 1, 5, 1, 2 }).Returns(5);
                yield return new TestCaseData(new int []{ -2, 1, 5, 1, -2 }).Returns(5);
            }
        }
    }
}
