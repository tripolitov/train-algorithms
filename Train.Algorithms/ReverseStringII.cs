using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/reverse-string-ii/
    /// 
    /// Reverse String II
    ///
    /// Given a string and an integer k, you need to reverse the first k characters for every 2k characters counting from the start of the string. If there are less than k characters left, reverse all of them. If there are less than 2k but greater than or equal to k characters, then reverse the first k characters and left the other as original.
    /// Example:
    /// Input: s = "abcdefg", k = 2
    /// Output: "bacdfeg"
    /// Restrictions:
    /// The string consists of lower English letters only.
    /// Length of the given string and k will in the range [1, 10000]
    /// </summary>
    public class ReverseStringII
    {
        [Test][TestCaseSource(nameof(TestData))]
        public string ReverseStr(string s, int k) {
            var a = s.ToCharArray();
        
            for(var i = 0; i < a.Length; i += 2 * k) {
                int left = i, right = Math.Min(i + k - 1, a.Length - 1);
            
                while(left < right) {
                    var temp = a[left];
                    a[left] = a[right];
                    a[right] = temp;            
                    left += 1;
                    right -= 1;
                }
            }
            return new string(a);
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData("abcdefg", 2).Returns("bacdfeg");
                yield return new TestCaseData("abcd", 4).Returns("dcba");
                yield return new TestCaseData("abcdefg", 8).Returns("gfedcba");
                yield return new TestCaseData("abcdefge", 8).Returns("egfedcba");
            }
        }
    }
}