using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/roman-to-integer/
    /// 
    /// </summary>
    public class RomanToInteger
    {
        [Test]
        [TestCaseSource("TestInput")]
        public int RomanToInt(string input)
        {
            var map = new Dictionary<char, int>()
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };

            var temp = input.Select(c => map[c]).ToArray();

            var result = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                if (i + 1 >= temp.Length)
                {
                    result += temp[i];
                }
                else
                {
                    if (temp[i] >= temp[i + 1])
                    {
                        result += temp[i];
                    }
                    else
                    {
                        result -= temp[i];
                    }
                }
            }
        
            return result;
        }

        public static IEnumerable<TestCaseData> TestInput
        {
            get
            {
                yield return new TestCaseData("I").Returns(1);
                yield return new TestCaseData("II").Returns(2);
                yield return new TestCaseData("III").Returns(3);
                yield return new TestCaseData("IV").Returns(4);
                yield return new TestCaseData("V").Returns(5);
                yield return new TestCaseData("X").Returns(10);
                yield return new TestCaseData("IX").Returns(9);
                yield return new TestCaseData("LVIII").Returns(58);
                yield return new TestCaseData("MCMXCIV").Returns(1994);
                

            }
        }
    }
}