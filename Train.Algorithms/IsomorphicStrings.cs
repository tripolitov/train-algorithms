using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/isomorphic-strings/
    /// 
    /// Isomorphic Strings
    ///
    /// Given two strings s and t, determine if they are isomorphic.
    /// 
    /// Two strings are isomorphic if the characters in s can be replaced to get t.
    /// 
    /// All occurrences of a character must be replaced with another character while preserving the order of characters. No two characters may map to the same character but a character may map to itself.
    /// 
    /// Example 1:
    /// 
    /// Input: s = "egg", t = "add"
    /// Output: true
    /// 
    /// Example 2:
    /// 
    /// Input: s = "foo", t = "bar"
    /// Output: false
    /// 
    /// Example 3:
    /// 
    /// Input: s = "paper", t = "title"
    /// Output: true
    /// Note:
    /// You may assume both s and t have the same length.
    /// </summary>
    public class IsomorphicStrings
    {
        [Test][TestCaseSource(nameof(TestData))]
        public bool IsIsomorphic(string s, string t)
        {
            var map = new Dictionary<char, char>();

            for (var i = 0; i < s.Length; i++)
            {
                var a = s[i];
                var b = t[i];

                if (!map.ContainsKey(a))
                {
                    if (!map.ContainsValue(b))
                    {
                        map[a] = b;
                    }
                    else
                    {
                        return false;
                    }
                }

                if (map[a] != b) return false;
            }

            return true;
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public bool IsIsomorphicArrayMap(string s, string t)
        {
            var smap = new int[256];
            var tmap = new int[256];

            for (var i = 0; i < s.Length; i++)
            {
                if (smap[s[i]] != tmap[t[i]]) return false;

                smap[s[i]] = i + 1;
                tmap[t[i]] = i + 1;
            }

            return true;
        }

        private static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData("ab", "aa").Returns(false);
                yield return new TestCaseData("egg", "add").Returns(true);
                yield return new TestCaseData("paper", "title").Returns(true);
                yield return new TestCaseData("foo", "bar").Returns(false);
            }
        }
    }
}