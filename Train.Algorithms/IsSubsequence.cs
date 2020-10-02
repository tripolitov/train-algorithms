using System;
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
      
      [Test][TestCaseSource(nameof(TestData))]
      public bool IsSubsequenceBinarySearch(string s, string t)
      {
         var map = new List<int>[26];
         
         for (var i = 0; i < t.Length; i++)
         {
            var index = t[i] - 'a';
            
            if(map[index] == null) 
               map[index] = new List<int>();
            
            map[index].Add(i);
         }

         var prev = -1;
         foreach (var c in s)
         {
            var index = c - 'a';

            if (map[index] == null) return false;

            var candidate = SearchGreaterThen(map[index], prev);
            if (candidate < 0) return false;

            prev = map[index][candidate];
         }

         return true;
      }

      [Test][TestCaseSource(nameof(SearchTestData))]
      public int SearchGreaterThen(IList<int> list, int target)
      {
         int left = 0, right = list.Count - 1, result = -1;
         
         while (left <= right)
         {
            var mid = left + (right - left) / 2;

            if (list[mid] <= target) {
               left = mid + 1;
            } else {
               result = mid;
               right = mid - 1;
            }
         }

         return result;
      }

      [Test]
      [TestCaseSource(nameof(TestData))]
      public bool IsSubsequenceDynamicProgramming(string s, string t)
      {
         if (string.IsNullOrEmpty(s)) return true;

         var matrix = new int[s.Length+1][];

         for (var i = 0; i < matrix.Length; i++)
         {
            matrix[i] = new int[t.Length + 1];
         }
         
         for (var row = 1; row < matrix.Length; row++)
         for (var col = 1; col < matrix[row].Length; col++)
         {
            if (s[row - 1] == t[col - 1])
            {
               matrix[row][col] = matrix[row - 1][col - 1] + 1;
            }
            else
            {
               matrix[row][col] = Math.Max(matrix[row - 1][col], matrix[row][col - 1]);
            }

            if (matrix[row][col] == s.Length) return true;
         }

         return false;
      }

      static IEnumerable<TestCaseData> TestData {
         get
         {
            yield return new TestCaseData("", "").Returns(true);
            yield return new TestCaseData("", "abc").Returns(true);
            yield return new TestCaseData("abc", "ahbgdc").Returns(true);
            yield return new TestCaseData("acb", "ahbgdc").Returns(false);
            yield return new TestCaseData("axc", "ahbgdc").Returns(false);
         }
      }

      static IEnumerable<TestCaseData> SearchTestData {
         get
         {
            yield return new TestCaseData(new int[0], 1).Returns(-1);
            yield return new TestCaseData(new int[]{1}, 1).Returns(-1);
            yield return new TestCaseData(new int[]{1}, 0).Returns(0);
            yield return new TestCaseData(new int[]{2}, 1).Returns(0);
            yield return new TestCaseData(new int[]{1,2}, 1).Returns(1);
            yield return new TestCaseData(new int[]{1,2,3}, 1).Returns(1);
            yield return new TestCaseData(new int[]{1,2,3}, 2).Returns(2);
            yield return new TestCaseData(new int[]{1,2,3,4,5,6,7,8,9}, 8).Returns(8);
            yield return new TestCaseData(new int[]{1,2,3,4,5,6,7,8,9}, 9).Returns(-1);
            yield return new TestCaseData(new int[]{1,2,3,4,5,6,7,8,9}, 10).Returns(-1);
         }
      }
   }
}