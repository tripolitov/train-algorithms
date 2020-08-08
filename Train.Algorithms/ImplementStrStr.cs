using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/implement-strstr/
    /// 
    /// Implement strStr().
    ///
    /// Return the index of the first occurrence of needle
    /// in haystack, or -1 if needle is not part of haystack.
    /// 
    /// Example 1:
    /// Input: haystack = "hello", needle = "ll"
    /// Output: 2
    /// 
    /// Example 2:
    /// Input: haystack = "aaaaa", needle = "bba"
    /// Output: -1
    /// 
    /// Clarification:
    ///
    /// What should we return when needle is an empty string?
    /// This is a great question to ask during an interview.
    /// 
    /// 
    /// For the purpose of this problem, we will return 0 when
    /// needle is an empty string. This is consistent to C's strstr()
    /// and Java's indexOf().
    /// 
    /// Constraints:
    /// haystack and needle consist only of lowercase English characters.
    /// </summary>
    class ImplementStrStr
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public int StrStr(string haystack, string needle)
        {
            if (needle == "") return 0;

            for (var i = 0; i <= haystack.Length - needle.Length; i++)
            {
                if (haystack[i] != needle[0]) continue;

                var c = true;
                for (var j = 1; j < needle.Length; j++)
                {
                    if (haystack[i + j] != needle[j])
                    {
                        c = false;
                        break;
                    }
                }
                if(c) return i;

            }

            return -1;
        }

        public static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData("hello", "ll").Returns(2);
                yield return new TestCaseData("aaaaa", "baa").Returns(-1);
                yield return new TestCaseData("aaaaa", "").Returns(0);
                yield return new TestCaseData("aaaaa", "aab").Returns(-1);
                yield return new TestCaseData("aaaaa", "aaaaa").Returns(0);
                yield return new TestCaseData("abaaaa", "aaaa").Returns(2);
                yield return new TestCaseData("a", "a").Returns(0);
            }
        }
    }
}
