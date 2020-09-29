using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/ransom-note/
    /// 
    /// Ransom Note
    ///
    /// Given an arbitrary ransom note string and another string containing letters from all the magazines,
    /// write a function that will return true if the ransom note can be constructed from the magazines;
    /// otherwise, it will return false.
    /// 
    /// Each letter in the magazine string can only be used once in your ransom note.
    /// 
    /// Example 1:
    /// 
    /// Input: ransomNote = "a", magazine = "b"
    /// Output: false
    /// 
    /// Example 2:
    /// 
    /// Input: ransomNote = "aa", magazine = "ab"
    /// Output: false
    /// 
    /// Example 3:
    /// 
    /// Input: ransomNote = "aa", magazine = "aab"
    /// Output: true
    /// 
    /// Constraints:
    /// 
    /// You may assume that both strings contain only lowercase letters.
    /// </summary>
    public class RansomNote
    {
        [Test][TestCaseSource(nameof(TestData))]
        public bool CanConstruct(string ransomNote, string magazine) {
            var map = new Dictionary<char, int>();
            foreach(var c in magazine) {
                if(map.ContainsKey(c)) map[c] += 1;
                else map[c] = 1;                
            }
        
            foreach(var c in ransomNote) {
                if(!map.ContainsKey(c)) return false;
            
                map[c] -= 1;
                if(map[c] == 0)
                    map.Remove(c);
            }
        
            return true;
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData("a", "b").Returns(false);
                yield return new TestCaseData("a", "a").Returns(true);
                yield return new TestCaseData("a", "aa").Returns(true);
                yield return new TestCaseData("aa", "a").Returns(false);
                yield return new TestCaseData("aa", "aab").Returns(true);
                yield return new TestCaseData("aa", "aba").Returns(true);
                yield return new TestCaseData("cba", "abc").Returns(true);
            }
        }
    }
}