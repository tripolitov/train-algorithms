using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/number-of-1-bits/
    ///
    /// Number of 1 Bits
    /// 
    /// Write a function that takes an unsigned integer and return the number of '1' bits it has (also known as the Hamming weight).
    /// 
    /// Example 1:
    /// 
    /// Input: 00000000000000000000000000001011
    /// Output: 3
    /// Explanation: The input binary string 00000000000000000000000000001011 has a total of three '1' bits.
    /// Example 2:
    /// 
    /// Input: 00000000000000000000000010000000
    /// Output: 1
    /// Explanation: The input binary string 00000000000000000000000010000000 has a total of one '1' bit.
    /// Example 3:
    /// 
    /// Input: 11111111111111111111111111111101
    /// Output: 31
    /// Explanation: The input binary string 11111111111111111111111111111101 has a total of thirty one '1' bits.
    /// Number of 1 Bits
    /// </summary>
    class NumberOf1Bits
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public int HammingWeight(uint n)
        {
            uint result = 0;
            for(var i = 0 ; i < 32; i++)
            {
                if ((n & 0b1) == 1) result++;
                n >>= 1;
            }
            return (int)result;
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData((uint) 0b00000000000000000000000000000000).Returns(0);
                yield return new TestCaseData((uint) 0b00000000000000000000000000000001).Returns(1);
                yield return new TestCaseData((uint) 0b10000000000000000000000000000000).Returns(1);
                yield return new TestCaseData((uint) 0b00000001000000000000000000000000).Returns(1);
                yield return new TestCaseData((uint) 0b00000000000000000000001000000000).Returns(1);
                yield return new TestCaseData((uint) 0b00000000000000000000000000001011).Returns(3);
                yield return new TestCaseData((uint) 0b11111111111111111111111111111101).Returns(31);
                yield return new TestCaseData((uint) 0b11111111111111111111111111111111).Returns(32);
            }
        }
    }
        }
