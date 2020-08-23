using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/valid-palindrome/
    ///
    /// Valid Palindrome
    ///
    /// Given a string, determine if it is a palindrome,
    /// considering only alphanumeric characters and ignoring cases.
    ///
    /// Note: For the purpose of this problem, we define empty string as valid palindrome.
    /// 
    ///  Example 1:
    /// 
    ///  Input: "A man, a plan, a canal: Panama"
    ///  Output: true
    ///  Example 2:
    /// 
    ///  Input: "race a car"
    ///  Output: false
    /// 
    ///  Constraints:
    /// 
    ///  s consists only of printable ASCII characters.
    /// </summary>
    class ValidPalindrome
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public bool IsPalindrome(string s)
        {
            s = s.ToLowerInvariant();
            int i = 0, j = s.Length - 1;

            while (i < s.Length && j >= 0)
            {
                if (!(('a' <= s[i] && s[i] <= 'z') || ('0' <= s[i] && s[i] <= '9')))
                {
                    i++;
                    continue;
                }

                if (!(('a' <= s[j] && s[j] <= 'z') || ('0' <= s[j] && s[j] <= '9')))
                {
                    j--;
                    continue;
                }

                if (s[i++] != s[j--]) return false;
            }

            return true;
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public bool IsPalindromeAlternative(string s)
        {
            int i = 0, j = s.Length - 1;

            while (i < j)
            {
                while (!char.IsLetterOrDigit(s[i]) && i < j) i++;
                while (!char.IsLetterOrDigit(s[j]) && i < j) j--;
                if (i >= j) break;

                if (char.ToLower(s[i++]) != char.ToLower(s[j--])) return false;
            }

            return true;
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData("0P").Returns(false);
                yield return new TestCaseData("a").Returns(true);
                yield return new TestCaseData("aa").Returns(true);
                yield return new TestCaseData("aba").Returns(true);
                yield return new TestCaseData("abba").Returns(true);
                yield return new TestCaseData("abcba").Returns(true);
                yield return new TestCaseData("abcda").Returns(false);
                yield return new TestCaseData("ab").Returns(false);
                yield return new TestCaseData("A man, a plan, a canal: Panama").Returns(true);
                yield return new TestCaseData("race a car").Returns(false);
            }
        }
    }
}