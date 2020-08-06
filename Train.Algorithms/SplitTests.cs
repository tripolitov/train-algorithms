using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    public class SplitTests
    {
        int frequency(string S)
        {
            var result = 0;
            foreach (var s in S)
            {
                if (s == 'a')
                    result++;
            }

            return result;
        }

        [Test]
        [TestCaseSource("Input")]
        public int solution(string S)
        {
            var result = 0;
            for (int i = 1; i < S.Length-1; i++)
            for (int j = i + 1; j < S.Length; j++)
            {
                var c1 = frequency(S.Substring(0, i));
                var c2 = frequency(S.Substring(i, j - i));
                var c3 = frequency(S.Substring(j, S.Length - j));

                if (c1 == c2 && c2 == c3)
                    result++;
            }

            return result;
        }

        public static IEnumerable<TestCaseData> Input
        {
            get
            {
                yield return new TestCaseData("babaa").Returns(2);
                yield return new TestCaseData("ababa").Returns(4);
                yield return new TestCaseData("aba").Returns(0);
                yield return new TestCaseData("bbbbb").Returns(6);
            }
        }
    }
}