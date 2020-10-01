using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
   /// <summary>
   /// https://leetcode.com/problems/is-subsequence/
   /// 
   /// Is Subsequence
   ///
   /// Given a string s and a string t, check if s is subsequence of t.
   ///
   /// A subsequence of a string is a new string which is formed from the original string by deleting some
   /// (can be none) of the characters without disturbing the relative positions of the remaining characters.
   /// (ie, "ace" is a subsequence of "abcde" while "aec" is not).
   ///
   /// Follow up:
   /// If there are lots of incoming S, say S1, S2, ... , Sk where k >= 1B, and you want to check one by one to see
   /// if T has its subsequence. In this scenario, how would you change your code?
   ///
   /// Credits:
   /// Special thanks to @pbrother for adding this problem and creating all test cases.
   ///
   /// Example 1:
   ///
   /// Input: s = "abc", t = "ahbgdc"
   /// Output: true
   /// 
   /// Example 2:
   ///
   /// Input: s = "axc", t = "ahbgdc"
   /// Output: false
   ///
   ///
   /// Constraints:
   ///
   /// 0 <= s.length <= 100
   /// 0 <= t.length <= 10^4
   /// Both strings consists only of lowercase characters.
   /// </summary>
   public class IsSubsequence
   {
      [Test][TestCaseSource(nameof(TestData))]
      public bool IsSubsequenceBrutForce(string s, string t) {
         int j = 0, count = 0;
         for(var i = 0; i < s.Length; i++) {
            while(j < t.Length) {
               if(s[i] == t[j++])
               {
                  count += 1;
                  break;
               }                
            }
         }  
         return count == s.Length;
      }
      
      static IEnumerable<TestCaseData> TestData {
         get
         {
            yield return new TestCaseData("", "").Returns(true);
            yield return new TestCaseData("", "abc").Returns(true);
            yield return new TestCaseData("abc", "ahbgdc").Returns(true);
            yield return new TestCaseData("axc", "ahbgdc").Returns(false);
         }
      }
   }
}