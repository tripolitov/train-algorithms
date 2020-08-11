using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/length-of-last-word/
    /// 
    /// Given a string s consists of upper/lower-case alphabets
    /// and empty space characters ' ', return the length of last
    /// word (last word means the last appearing word if we loop
    /// from left to right) in the string. If the last word does
    /// not exist, return 0.
    /// 
    /// Note: A word is defined as a maximal substring consisting
    /// of non-space characters only.
    /// 
    /// Example:
    /// 
    /// Input: "Hello World"
    /// Output: 5
    /// </summary>
    class LengthOfLastWord
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public int Iterative(string s)
        {
            var c = 0;
            for (var i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == ' ')
                {
                    if(c > 0) return c;
                }
                else if (s[i] != ' ')
                {
                    c++;
                }
            }

            return c;
        }

        public static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData("").Returns(0);
                yield return new TestCaseData("Hello World").Returns(5);
                yield return new TestCaseData("HelloWorld").Returns(10);
            }
        }
    }
}