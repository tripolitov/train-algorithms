using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Train.Algorithms
{
   /// <summary>
   /// https://leetcode.com/problems/word-pattern/
   ///
   /// Word Pattern
   ///
   /// Given a pattern and a string s, find if s follows the same pattern.
   ///
   /// Here follow means a full match, such that there is a bijection between a letter in pattern and a non-empty word in s.
   ///
   ///
   ///
   /// Example 1:
   ///
   /// Input: pattern = "abba", s = "dog cat cat dog"
   /// Output: true
   /// Example 2: 
   ///
   /// Input: pattern = "abba", s = "dog cat cat fish"
   /// Output: false
   /// Example 3:
   ///
   /// Input: pattern = "aaaa", s = "dog cat cat dog"
   /// Output: false
   /// Example 4:
   ///
   /// Input: pattern = "abba", s = "dog dog dog dog"
   /// Output: false
   ///
   ///
   /// Constraints:
   ///
   /// 1 <= pattern.length <= 300
   /// pattern contains only lower-case English letters.
   /// 1 <= s.length <= 3000
   /// s contains only lower-case English letters and spaces ' '.
   /// s does not contain any leading or trailing spaces.
   /// All the words in s are separated by a single space.
   /// </summary>
   public class WordPattern
   {
      [Test][TestCaseSource(nameof(TestData))]
      public bool MatchesWordPattern(string pattern, string s)
      {
         var words = s.Split(" ");

         if (words.Length != pattern.Length) return false;
         
         var wc = new Dictionary<string, char>();
         var cw = new Dictionary<char, string>();

         for(var i = 0; i < pattern.Length; i++)
         {
            if (!wc.ContainsKey(words[i]))
            {
               if (!cw.ContainsKey(pattern[i]))
               {
                  wc[words[i]] = pattern[i];
                  cw[pattern[i]] = words[i];
               }
               else
               {
                  return false;
               }
            }
            else
            {
               if (pattern[i] != wc[words[i]]) return false;
            }
         }

         return true;

      }

      private static IEnumerable<TestCaseData> TestData
      {
         get
         {
            yield return new TestCaseData("aaa","aaa aaa aaa aaa").Returns(false);
            yield return new TestCaseData("aaa","aaa aaa").Returns(false);
            yield return new TestCaseData("abc","dog cat yellow").Returns(true);
            yield return new TestCaseData("abc","dog cat dog").Returns(false);
            yield return new TestCaseData("abba","dog cat cat dog").Returns(true);
            yield return new TestCaseData("abba","dog cat cat fis").Returns(false);
            yield return new TestCaseData("aaaa","dog cat cat dog").Returns(false);
            yield return new TestCaseData("abba","dog dog dog dog").Returns(false);
         }
      }
   }
}