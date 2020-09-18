using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// Power of Two
    /// 
    /// https://leetcode.com/problems/power-of-two/
    ///
    /// Given an integer, write a function to determine if it is a power of two.
    /// 
    /// Example 1:
    /// 
    /// Input: 1
    /// Output: true 
    /// Explanation: 20 = 1
    /// 
    /// Example 2:
    /// 
    /// Input: 16
    /// Output: true
    /// Explanation: 24 = 16
    /// 
    /// Example 3:
    /// 
    /// Input: 218
    /// Output: false
    /// </summary>
    public class PowerOfTwo
    {
        [Test][TestCaseSource(nameof(TestData))]
        public bool IsPowerOfTwo(int n)
        {
            while (n % 2 == 0 && n > 1) 
                n /= 2;

            return n == 1;
        }
        
        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(0).Returns(false);
                yield return new TestCaseData(1).Returns(true);
                yield return new TestCaseData(2).Returns(true);
                yield return new TestCaseData(3).Returns(false);
                yield return new TestCaseData(4).Returns(true);
                yield return new TestCaseData(5).Returns(false);
                yield return new TestCaseData(6).Returns(false);
                yield return new TestCaseData(7).Returns(false);
                yield return new TestCaseData(8).Returns(true);
                yield return new TestCaseData(15).Returns(false);
                yield return new TestCaseData(16).Returns(true);
            }
        }
    }
}