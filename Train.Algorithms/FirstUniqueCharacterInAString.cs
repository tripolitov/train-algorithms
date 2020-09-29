using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/first-unique-character-in-a-string/submissions/
    /// 
    /// First Unique Character in a String
    ///
    /// Given a string, find the first non-repeating character in it and return its index. If it doesn't exist, return -1.
    ///
    /// Examples:
    ///
    /// s = "leetcode"
    /// return 0.
    ///
    /// s = "loveleetcode"
    /// return 2.
    ///
    /// Note: You may assume the string contains only lowercase English letters.
    /// </summary>
    public class FirstUniqueCharacterInAString
    {
        [Test][TestCaseSource(nameof(TestData))]
        public int FirstUniqChar(string s) {
            var map = new Dictionary<char, int>();
        
            foreach(var c in s) {
                if(map.ContainsKey(c)) map[c] += 1;
                else map[c] = 1;
            }
        
            for(var i = 0; i < s.Length; i++) {
                if(map[s[i]] == 1) return i;
            }
        
            return -1;
        }
        
        [Test][TestCaseSource(nameof(TestData))]
        public int FirstUniqCharArray(string s) {
            var map = new int[26];

            foreach (var c in s)
            {
                map[c - 'a'] += 1;
            }
            
            for(var i = 0; i < s.Length; i++) 
            {
                if (map[s[i] - 'a'] == 1)
                {
                    return i;
                }
                
            }
            return -1;
        }

        private static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData("").Returns(-1);
                yield return new TestCaseData("leetcode").Returns(0);
                yield return new TestCaseData("loveleetcode").Returns(2);
                yield return new TestCaseData("aabbccddeeff").Returns(-1);
                yield return new TestCaseData("aabbccddeeffg").Returns(12);
            }
        }
    }
}