using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/detect-capital/
    /// 
    /// Detect Capital
    ///
    /// Given a word, you need to judge whether the usage of capitals in it is right or not.
    /// We define the usage of capitals in a word to be right when one of the following cases holds:
    /// 
    /// All letters in this word are capitals, like "USA".
    /// All letters in this word are not capitals, like "leetcode".
    /// Only the first letter in this word is capital, like "Google".
    /// Otherwise, we define that this word doesn't use capitals in a right way.
    /// 
    /// Example 1:
    /// 
    /// Input: "USA"
    /// Output: True
    /// 
    /// Example 2:
    /// 
    /// Input: "FlaG"
    /// Output: False
    /// 
    /// Note: The input will be a non-empty word consisting of uppercase and lowercase latin letters.
    /// </summary>
    public class DetectCapital
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public bool DetectCapitalUseFlags(string word)
        {
            bool allUpper = true
                , allLower = true
                , firstUpper = Char.IsUpper(word[0]);

            for (var i = 1; i < word.Length; i++)
            {
                var isUpper = Char.IsUpper(word[i]);

                allUpper &= isUpper;
                allLower &= !isUpper;
            }

            return (firstUpper && allUpper) || allLower;
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public bool DetectCapitalUseCount(string word)
        {
            if (word.Length == 0) return false;
            if (word.Length == 1) return true;

            var count = word.Count(Char.IsUpper);
            
            if (count == 0) return true;
            if (count == word.Length) return true;
            if (count == 1 && Char.IsUpper(word[0])) return true;

            return false;
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData("a").Returns(true);
                yield return new TestCaseData("A").Returns(true);
                yield return new TestCaseData("USA").Returns(true);
                yield return new TestCaseData("Google").Returns(true);
                yield return new TestCaseData("leetcode").Returns(true);
                yield return new TestCaseData("FlaG").Returns(false);
                yield return new TestCaseData("aLag").Returns(false);
                yield return new TestCaseData("aB").Returns(false);
            }
        }
    }
}