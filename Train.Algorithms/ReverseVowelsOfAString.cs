using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/reverse-vowels-of-a-string/
    /// 
    /// Reverse Vowels of a String
    ///
    /// Write a function that takes a string as input and reverse only the vowels of a string.
    ///
    /// Example 1:
    /// 
    /// Input: "hello"
    /// Output: "holle"
    /// 
    /// Example 2:
    /// 
    /// Input: "leetcode"
    /// Output: "leotcede"
    /// Note:
    /// The vowels does not include the letter "y".
    /// </summary>
    public class ReverseVowelsOfAString
    {
        bool isVowel(char c)
        {
            c = char.ToLowerInvariant(c);
            return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
        }
    
        [Test][TestCaseSource(nameof(TestData))]
        public string ReverseVowels(string s)
        {
            var chars = s.ToCharArray();
            int left = 0, right = s.Length - 1;
            while (left < right)
            {
                if (!isVowel(chars[left]))
                {
                    left += 1;
                    continue;
                }
                
                if (!isVowel(chars[right]))
                {
                    right -= 1; 
                    continue;
                }

                var temp = chars[left];
                chars[left] = chars[right];
                chars[right] = temp;
                left += 1;
                right -= 1;
;            }
            
            return new string(chars);
        }
        
        static IEnumerable<TestCaseData> TestData {
            get
            {
                yield return new TestCaseData("a").Returns("a");
                yield return new TestCaseData("aA").Returns("Aa");
                yield return new TestCaseData("ab").Returns("ab");
                yield return new TestCaseData("ba").Returns("ba");
                yield return new TestCaseData("hello").Returns("holle");
                yield return new TestCaseData("leetcode").Returns("leotcede");
            }
        }
    }
}