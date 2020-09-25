using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
   /// <summary>
   /// https://leetcode.com/problems/reverse-string/
   ///
   /// Reverse String
   ///
   /// Write a function that reverses a string. The input string is given as an array of characters char[].
   /// 
   ///  Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.
   /// 
   ///  You may assume all the characters consist of printable ascii characters.
   /// 
   /// 
   /// 
   ///  Example 1:
   /// 
   ///  Input: ["h","e","l","l","o"]
   ///  Output: ["o","l","l","e","h"]
   /// 
   ///  Example 2:
   /// 
   ///  Input: ["H","a","n","n","a","h"]
   ///  Output: ["h","a","n","n","a","H"]
   /// </summary>
   public class ReverseString
   {
      void Solution(char[] s)
      {
         int left = 0, right = s.Length - 1;
         while (left < right)
         {
            var temp = s[left];
            s[left] = s[right];
            s[right] = temp;
            
            left += 1;
            right -= 1;
         }
      }

      [Test][TestCaseSource(nameof(TestData))]
      public string Test(string input)
      {
         var chars = input.ToCharArray();
         
         Solution(chars);
         
         return new string(chars);
      }

      static IEnumerable<TestCaseData> TestData
      {
         get
         {
            yield return new TestCaseData("").Returns("");
            yield return new TestCaseData("a").Returns("a");
            yield return new TestCaseData("ab").Returns("ba");
            yield return new TestCaseData("abcdef").Returns("fedcba");
            yield return new TestCaseData("hello").Returns("olleh");
            yield return new TestCaseData("Hannah").Returns("hannaH");
         }
      }
   }
}