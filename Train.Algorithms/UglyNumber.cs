using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/ugly-number/
    /// 
    /// Ugly Number
    ///
    /// Write a program to check whether a given number is an ugly number.

    /// Ugly numbers are positive numbers whose prime factors only include 2, 3, 5.
    /// 
    /// Example 1:
    /// 
    /// Input: 6
    /// Output: true
    /// Explanation: 6 = 2 × 3
    /// Example 2:
    /// 
    /// Input: 8
    /// Output: true
    /// Explanation: 8 = 2 × 2 × 2
    /// Example 3:
    /// 
    /// Input: 14
    /// Output: false 
    /// Explanation: 14 is not ugly since it includes another prime factor 7.
    /// Note:
    /// 
    /// 1 is typically treated as an ugly number.
    /// Input is within the 32-bit signed integer range: [−231,  231 − 1].
    /// </summary>
    public class UglyNumber
    {
        [Test][TestCaseSource(nameof(TestData))]
        public bool IsUgly(int num)
        {
            var factors = new[] {2, 3, 5};
            var i = 0;
            while(i < factors.Length && num > 0)
            {
                if (num % factors[i] == 0)
                {
                    num /= factors[i];
                    i = 0;
                    continue;
                }
                i++;
            }

            return num == 1;
        }
        
        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(1).Returns(true);
                yield return new TestCaseData(2).Returns(true);
                yield return new TestCaseData(6).Returns(true);
                yield return new TestCaseData(8).Returns(true);
                yield return new TestCaseData(14).Returns(false);
            }
        }
    }
}