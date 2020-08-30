using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/excel-sheet-column-title/
    /// 
    /// Excel Sheet Column Title
    ///
    /// Given a positive integer, return its corresponding column title as appear in an Excel sheet.
    ///
    /// For example:
    /// 
    /// 1 -> A
    /// 2 -> B
    /// 3 -> C
    /// ...
    /// 26 -> Z
    /// 27 -> AA
    /// 28 -> AB
    /// ...
    /// Example 1:
    /// 
    /// Input: 1
    /// Output: "A"
    /// Example 2:
    /// 
    /// Input: 28
    /// Output: "AB"
    /// Example 3:
    /// 
    /// Input: 701
    /// Output: "ZY"
    /// </summary>
    class ExcelSheetColumnTitle
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public string ConvertToTitle(int n)
        {
            const int BASE = 26;
            var result = new StringBuilder();
            while (n > 0)
            {
                var value = Convert.ToChar((n - 1) % BASE + 'A');
                result.Insert(0, value);
                n = (n - 1) / BASE;
            }

            return result.ToString();
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(1).Returns("A");
                yield return new TestCaseData(2).Returns("B");
                yield return new TestCaseData(28).Returns("AB");
                yield return new TestCaseData(701).Returns("ZY");
            }
        }
    }
}
