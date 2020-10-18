using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{

    /// <summary>
    /// https://leetcode.com/problems/number-complement/
    ///
    /// Number Complement
    /// 
    /// Given a positive integer num, output its complement number.
    /// The complement strategy is to flip the bits of its binary representation.
    /// 
    /// Example 1:
    /// 
    /// Input: num = 5
    /// Output: 2
    /// Explanation: The binary representation of 5 is 101 (no leading zero bits),
    /// and its complement is 010. So you need to output 2.
    ///
    /// Example 2:
    /// 
    /// Input: num = 1
    /// Output: 0
    /// Explanation: The binary representation of 1 is 1 (no leading zero bits),
    /// and its complement is 0. So you need to output 0.
    /// 
    /// Constraints:
    /// 
    /// The given integer num is guaranteed to fit within the range of a 32-bit signed integer.
    /// num >= 1
    /// You could assume no leading zero bit in the integer’s binary representation. 
    /// </summary>
    public class NumberComplement
    {
        [Test][TestCaseSource(nameof(TestData))]
        public int FindComplement(int num) {
            uint n = (uint) num;
            uint mask = ~(0u);
            while((n & mask) != 0) mask <<= 1;
            return (int)(~mask & ~n);
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(5).Returns(2);
                yield return new TestCaseData(1).Returns(0);
                yield return new TestCaseData(2).Returns(1);
                yield return new TestCaseData(4).Returns(3);
                yield return new TestCaseData(6543).Returns(1648);
            }
        }
    }
}