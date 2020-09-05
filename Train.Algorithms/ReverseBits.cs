﻿using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/reverse-bits/
    /// 
    /// Reverse Bits
    ///
    /// Reverse bits of a given 32 bits unsigned integer.
    ///
    /// Example 1:
    ///
    /// Input: 00000010100101000001111010011100
    /// Output: 00111001011110000010100101000000
    /// Explanation: The input binary string 00000010100101000001111010011100 represents the unsigned integer 43261596, so return 964176192 which its binary representation is 00111001011110000010100101000000.
    ///
    /// Example 2:
    ///
    /// Input: 11111111111111111111111111111101
    /// Output: 10111111111111111111111111111111
    /// Explanation: The input binary string 11111111111111111111111111111101 represents the unsigned integer 4294967293, so return 3221225471 which its binary representation is 10111111111111111111111111111111.
    ///
    /// Note:
    ///
    /// Note that in some languages such as Java, there is no unsigned integer type.In this case, both input and output will be given as signed integer type and should not affect your implementation, as the internal binary representation of the integer is the same whether it is signed or unsigned.
    /// In Java, the compiler represents the signed integers using 2's complement notation. Therefore, in Example 2 above the input represents the signed integer -3 and the output represents the signed integer -1073741825.
    ///
    /// Follow up:
    ///
    /// If this function is called many times, how would you optimize it?
    /// </summary>
    class ReverseBits
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public uint reverseBits(uint n)
        {
            var r = 0u;
            for (var i = 0; i < 32; i++)
            {
                r = r << 1 | n & 0x1;
                n >>= 1;
            }
            return r;
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData((uint)0b00000010100101000001111010011100).Returns((uint)0b00111001011110000010100101000000);
                yield return new TestCaseData((uint)0b00000000000000000000000000000001).Returns((uint)0b10000000000000000000000000000000);
                yield return new TestCaseData((uint)0b10000000000000000000000000000000).Returns((uint)0b00000000000000000000000000000001);
                yield return new TestCaseData((uint)0b10001000000000000000000000000000).Returns((uint)0b00000000000000000000000000010001);
                yield return new TestCaseData((uint)0b10001000100000000000000000000000).Returns((uint)0b00000000000000000000000100010001);
                yield return new TestCaseData((uint)0b10001000100010000000000000000000).Returns((uint)0b00000000000000000001000100010001);
                yield return new TestCaseData((uint)0b10001000100010001000000000000000).Returns((uint)0b00000000000000010001000100010001);
                yield return new TestCaseData((uint)0b10001000100010001000100000000000).Returns((uint)0b00000000000100010001000100010001);
                yield return new TestCaseData((uint)0b10001000100010001000100010000000).Returns((uint)0b00000001000100010001000100010001);
                yield return new TestCaseData((uint)0b10001000100010001000100010001000).Returns((uint)0b00010001000100010001000100010001);
                yield return new TestCaseData((uint)0b10001000100010001000100010001001).Returns((uint)0b10010001000100010001000100010001);
                yield return new TestCaseData((uint)0b00001000100010001000100010001001).Returns((uint)0b10010001000100010001000100010000);
            }
        }
    }
}
