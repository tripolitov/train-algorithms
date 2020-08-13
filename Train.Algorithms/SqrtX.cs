using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/sqrtx/
    ///
    /// Implement int sqrt(int x).
    /// Compute and return the square root of x,
    /// where x is guaranteed to be a non-negative
    /// integer.
    /// 
    /// Since the return type is an integer, the decimal
    /// digits are truncated and only the integer part
    /// of the result is returned.
    /// 
    /// Example 1:
    /// Input: 4
    /// Output: 2
    ///
    /// Example 2:
    /// Input: 8
    /// Output: 2
    /// Explanation: The square root of 8 is 2.82842..., and since
    /// the decimal part is truncated, 2 is returned.
    /// </summary>
    class SqrtX
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public int MySqrt(int x)
        {
            if (x <= 1) return x;

            var left = 1;
            var right = x / 2;
            var result = 0;

            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                // NOTE[MT]: avoid overflow
                if (mid <= x / mid
                    && (mid + 1) > x / (mid + 1))
                    return mid;
                else if (mid < x / mid)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return result;
        }

        public static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(1).Returns(1);
                yield return new TestCaseData(2).Returns(1);
                yield return new TestCaseData(4).Returns(2);
                yield return new TestCaseData(8).Returns(2);
                yield return new TestCaseData(9).Returns(3);
                yield return new TestCaseData(10).Returns(3);
                yield return new TestCaseData(16).Returns(4);
                yield return new TestCaseData(17).Returns(4);
                yield return new TestCaseData(2147483647).Returns(46340);
            }
        }
    }
}
