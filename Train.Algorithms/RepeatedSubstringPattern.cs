using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/repeated-substring-pattern/
    /// 
    /// Repeated Substring Pattern
    ///
    /// Given a non-empty string check if it can be constructed by
    /// taking a substring of it and appending multiple copies of
    /// the substring together. You may assume the given string
    /// consists of lowercase English letters only and its length
    /// will not exceed 10000.
    ///
    /// Example 1:
    /// 
    /// Input: "abab"
    /// Output: True
    /// Explanation: It's the substring "ab" twice.
    /// 
    /// Example 2:
    /// 
    /// Input: "aba"
    /// Output: False
    /// Example 3:
    /// 
    /// Input: "abcabcabcabc"
    /// Output: True
    /// Explanation: It's the substring "abc" four times. (And the substring "abcabc" twice.)
    /// </summary>
    public class RepeatedSubstringPatternSolution
    {
        private bool checkCandidate(string s, int parts) {
            if(s.Length % parts != 0) return false;
            var length = s.Length / parts;

            for(var j = 0; j < length; j++) {
                var c = s[j];
                for(var k = 1; k < parts; k++) {
                    if(c != s[j + k*length]) 
                        return false;
                }
            }
            return true;
        }
    
        
        [Test][TestCaseSource(nameof(TestData))]
        public bool RepeatedSubstringPattern(string s) {
            for(var parts = 2; parts <= s.Length; parts += 1) {            
                if(checkCandidate(s, parts)) return true;
            }
        
            return false;
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public bool RepeatedSubstringPatternDub(string s)
        {
            return (s + s)[1..^1].Contains(s);
        }

        [Test][TestCaseSource(nameof(TestData))]
        public bool RepeatedSubstringPatternKMP(string s)
        {
            int i = 1, j = 0;
            var list = new List<int>() {0};
            
            while (i < s.Length)
            {
                if (s[i] == s[j])
                {
                    i += 1;
                    j += 1;
                    
                    list.Add(j);
                }
                else if (j > 0)
                {
                    j = list[j - 1];    
                }
                else
                {
                    i++;
                    list.Add(0);
                }
            }

            if (list[^1] == 0) return false;
            var prefixLength = s.Length - list[^1];
            
            return s.Length % prefixLength == 0;
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData("a").Returns(false);
                yield return new TestCaseData("aa").Returns(true);
                yield return new TestCaseData("aaa").Returns(true);
                yield return new TestCaseData("aaaa").Returns(true);
                yield return new TestCaseData("abab").Returns(true);
                yield return new TestCaseData("ababab").Returns(true);
                yield return new TestCaseData("abababab").Returns(true);
                yield return new TestCaseData("abcabc").Returns(true);
                yield return new TestCaseData("abcabcabcabc").Returns(true);
                yield return new TestCaseData("aba").Returns(false);
                yield return new TestCaseData("abc").Returns(false);
                yield return new TestCaseData("abcd").Returns(false);
            }
        }
    }
}