using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/longest-common-prefix/
    /// 
    /// Write a function to find the longest common prefix string amongst an array of strings.
    /// If there is no common prefix, return an empty string "".
    /// </summary>
    class LongestCommonPrefix
    {
        [Test]
        [TestCaseSource(nameof(InputData))]
        public string Solution(string[] strs)
        {
            if (strs.Length == 0) return "";

            var result = strs[0];
            
            var i = 0;
            for (i = 0; i < result.Length; i++)
            {
                for (var j = 1; j < strs.Length; j++)
                {
                    if (i >= strs[j].Length) return result.Substring(0, i);
                    if (result[i] != strs[j][i]) return result.Substring(0, i);
                }
            }

            return result.Substring(0, i);
        }

        public static IEnumerable<TestCaseData> InputData
        {
            get {
                yield return new TestCaseData((object)new string[] { "", "" }).Returns("");
                yield return new TestCaseData(
                        (object)new string[] {"flower", "flow", "flight"})
                    .Returns("fl");
                yield return new TestCaseData(
                        (object)new string[] { "dog", "racecar", "car" })
                    .Returns("");
                yield return new TestCaseData(
                        (object)new string[] { "abcde", "abcd", "abc" })
                    .Returns("abc");
                yield return new TestCaseData(
                        (object)new string[] { "abc", "abcd", "abcde" })
                    .Returns("abc");
                yield return new TestCaseData(
                        (object)new string[] { "abcde", "", "a" })
                    .Returns("");
                yield return new TestCaseData(
                        (object)new string[] { "abcde", "b", "a" })
                    .Returns("");
                yield return new TestCaseData((object)new string[] { "abcde", "a", "a" }).Returns("a");
                yield return new TestCaseData((object)new string[] { "a", "ab", "abc" }).Returns("a");

                yield return new TestCaseData(
                        (object)new string[0])
                    .Returns("");
            }
        }
    }
}
