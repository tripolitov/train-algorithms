using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/count-and-say/
    ///
    /// The count-and-say sequence is the sequence of integers with the first five terms as following:
    ///
    /// 1.     1
    /// 2.     11
    /// 3.     21
    /// 4.     1211
    /// 5.     111221
    /// 1 is read off as "one 1" or 11.
    /// 11 is read off as "two 1s" or 21.
    /// 21 is read off as "one 2, then one 1" or 1211.
    /// 
    /// Given an integer n where 1 ≤ n ≤ 30, generate the nth term of
    /// the count-and-say sequence.You can do so recursively, in other
    /// words from the previous member read off the digits, counting
    /// the number of digits in groups of the same digit.
    ///
    /// Note: Each term of the sequence of integers will be represented as a string.
    /// </summary>
    class CountAndSay
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public string RecursiveSolution(int n)
        {
            if (n == 1)
                return "1";

            var said = RecursiveSolution(n - 1);

            var say = new StringBuilder();
            var i = 0;
            for (var j = 1; j < said.Length; j++)
            {
                if (said[i] != said[j])
                {
                    say.Append(j - i).Append(said[i]);
                    i = j;
                }
            }

            return say.Append(said.Length - i).Append(said[i])
                .ToString();
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public string IterativeSolution(int n)
        {
            var say = new StringBuilder("1");

            for (var k = 1; k < n; k++)
            {
                var said = say;

                say = new StringBuilder();
                var i = 0;
                for (var j = 1; j < said.Length; j++)
                {
                    if (said[i] == said[j]) continue;

                    say.Append(j - i).Append(said[i]);
                    i = j;
                }

                say.Append(said.Length - i).Append(said[i]);
            }

            return say.ToString();
        }

        public static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(1).Returns("1");
                yield return new TestCaseData(2).Returns("11");
                yield return new TestCaseData(3).Returns("21");
                yield return new TestCaseData(4).Returns("1211");
                yield return new TestCaseData(5).Returns("111221");
                yield return new TestCaseData(6).Returns("312211");
            }
        }
    }
}
