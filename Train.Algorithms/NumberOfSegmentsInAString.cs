using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/number-of-segments-in-a-string/
    /// 
    /// Number of Segments in a String
    ///
    /// ou are given a string s, return the number of segments in the string. 

    /// A segment is defined to be a contiguous sequence of non-space characters.
    ///


    /// Example 1:
    ///
    /// Input: s = "Hello, my name is John"
    /// Output: 5
    /// Explanation: The five segments are ["Hello,", "my", "name", "is", "John"]
    ///
    /// Example 2:
    ///
    /// Input: s = "Hello"
    /// Output: 1
    /// Example 3:
    ///
    /// Input: s = "love live! mu'sic forever"
    /// Output: 4
    /// 
    /// Example 4:
    ///
    /// Input: s = ""
    /// Output: 0
    /// </summary>
    public class NumberOfSegmentsInAString
    {
        [Test][TestCaseSource(nameof(TestData))]
        public int CountSegments(string s)
        {
            int count = 0;
            bool isSpace = true;
            foreach (var c in s)
            {
                if (c != ' ' && isSpace)
                {
                    isSpace = false;
                    count += 1;
                }
                else if (c == ' ')
                {
                    isSpace = true;
                }
            }

            return count;
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData("").Returns(0);
                yield return new TestCaseData("Hello, my name is John").Returns(5);
                yield return new TestCaseData(" Hello, my name is John").Returns(5);
                yield return new TestCaseData("Hello, my name is John ").Returns(5);
                yield return new TestCaseData(" Hello, my name is John ").Returns(5);
                yield return new TestCaseData("   Hello, my name is John").Returns(5);
                yield return new TestCaseData("   Hello,  my  name   is    John    ").Returns(5);
                yield return new TestCaseData("Hello,  my  name   is    John   ").Returns(5);
                yield return new TestCaseData("Hello").Returns(1);
                yield return new TestCaseData("love live! mu'sic forever").Returns(4);
            }
        }
    }
}