using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/valid-anagram/
    /// 
    /// Valid Anagram
    ///
    /// Given two strings s and t , write a function to determine if t is an anagram of s.
    /// 
    /// Example 1:
    /// 
    /// Input: s = "anagram", t = "nagaram"
    /// Output: true
    /// Example 2:
    /// 
    /// Input: s = "rat", t = "car"
    /// Output: false
    /// Note:
    /// You may assume the string contains only lowercase alphabets.
    /// 
    /// Follow up:
    /// What if the inputs contain unicode characters? How would you adapt your solution to such case?
    /// </summary>
    public class ValidAnagram
    {
        [Test][TestCaseSource(nameof(TestData))]
        public bool IsAnagram(string s, string t)
        {
            var counter = new int[26];
            
            foreach (var c in s) counter[c - 'a'] += 1;
            foreach (var c in t) counter[c - 'a'] -= 1;
            
            foreach (var c in counter) 
                if (c != 0) return false;
            return true;
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData("anagram", "nagaram").Returns(true);
                yield return new TestCaseData("car", "rat").Returns(false);
            }
        }
    }
}