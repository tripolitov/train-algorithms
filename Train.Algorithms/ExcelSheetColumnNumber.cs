using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/excel-sheet-column-number/
    /// 
    /// Excel Sheet Column Number
    ///
    /// Given a column title as appear in an Excel sheet, return its corresponding column number.
    ///
    ///   For example:
    ///
    ///   A -> 1
    ///   B -> 2
    ///   C -> 3
    ///   ...
    ///   Z -> 26
    ///   AA -> 27
    ///   AB -> 28 
    ///   ...
    ///   Example 1:
    ///
    ///   Input: "A"
    ///   Output: 1
    ///   Example 2:
    ///
    ///   Input: "AB"
    ///   Output: 28
    ///   Example 3:
    ///
    ///   Input: "ZY"
    ///   Output: 701
    /// </summary>
    class ExcelSheetColumnNumber
    {
        [Test] [TestCaseSource(nameof(TestData))]
        public int TitleToNumber(string s)
        {
            const int BASE = 26;
            var result = 0;
            for (var i = s.Length - 1; i >= 0; i--)
            {
                var v = s[i] - 'A' + 1;
                result += v * (int)Math.Pow(BASE, s.Length - 1 - i);
            }

            return result;
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public int TitleToNumberForward(string s)
        {
            const int BASE = 26;
            var result = 0;
            foreach (var c in s)
            {
                var v = c - 'A' + 1;
                result = result * BASE + v;
            }

            return result;
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public int TitleToNumberLinq(string s)
        {
            const int BASE = 26;

            return s
                .Select(c => c - 'A' + 1)
                .Aggregate((acc, v) => acc * BASE + v);
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData("A").Returns(1);
                yield return new TestCaseData("B").Returns(2);
                yield return new TestCaseData("AB").Returns(28);
                yield return new TestCaseData("ZY").Returns(701);
            }
        }

    }
}