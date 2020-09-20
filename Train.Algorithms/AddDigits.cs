using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/add-digits/
    /// 
    /// Add Digits
    /// 
    /// Given a non-negative integer num, repeatedly
    /// add all its digits until the result has only one digit.
    /// 
    /// Example:
    /// 
    /// Input: 38
    /// Output: 2 
    /// Explanation: The process is like: 3 + 8 = 11, 1 + 1 = 2. 
    /// Since 2 has only one digit, return it.
    /// Follow up:
    /// Could you do it without any loop/recursion in O(1) runtime?
    /// </summary>
    public class AddDigits
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public int AddDigitsLoop(int num)
        {
            while (num >= 10)
            {
                var temp = 0;
                while (num > 0)
                {
                    temp += num % 10;
                    num /= 10;
                }

                num = temp;
            }

            return num;
        }

        [Test][TestCaseSource(nameof(TestData))]
        public int AddDigitsMath(int num)
        {
            if (num == 0) return 0;
            if (num % 9 == 0) return 9;
            return num % 9;
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return   new TestCaseData(28).Returns(1);
                yield return   new TestCaseData(38).Returns(2);
            }
        }
    }
}