using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/reverse-integer/
    ///
    /// Given a 32-bit signed integer, reverse digits of an integer.
    /// Example 1:
    /// Input: 123
    /// Output: 321
    /// 
    /// Example 2:
    /// Input: -123
    /// Output: -321
    /// 
    /// Example 3:
    /// Input: 120
    /// Output: 21
    /// 
    /// Note: Assume we are dealing with an environment
    /// which could only store integers within the 32-bit
    /// signed integer range: [−231,  231 − 1].
    /// For the purpose of this problem, assume that your
    /// function returns 0 when the reversed integer overflows.
    /// </summary>
    class ReverseInteger
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public int Reverse(int x)
        {
            var s = 1;
            if (x < 0)
            {
                s = -1;
                x *= s;
            }

            var rev = 0;
            while (x > 0)
            {
                if (rev > Int32.MaxValue / 10 || rev < Int32.MinValue / 10)
                {
                    return 0;
                }

                rev = rev * 10 + x % 10;
                x /= 10;
            }
            return rev * s;
        }

        public static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(123).Returns(321);
                yield return new TestCaseData(0).Returns(0);
                yield return new TestCaseData(-123).Returns(-321);
                yield return new TestCaseData(1534236469).Returns(0);
                yield return new TestCaseData(-1534236469).Returns(0);
                yield return new TestCaseData(int.MaxValue).Returns(0);
                yield return new TestCaseData(int.MinValue).Returns(0);
            }
        }
    }
}