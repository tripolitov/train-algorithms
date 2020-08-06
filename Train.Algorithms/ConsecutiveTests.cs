using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Train.Algorithms
{
    public class ConsecutiveTests
    {
        public List<Tuple<char, int>> compress1(string S)
        {
            var result = new List<Tuple<char, int>>();
            var currentLength = 0;

            for (int i = 1; i < S.Length; i++)
            {
                if (S[i] == S[i - 1])
                {
                    currentLength++;
                }
                else
                {
                    result.Add(Tuple.Create(S[i - 1], currentLength));
                    currentLength = 1;
                }
            }
            result.Add(Tuple.Create(S[S.Length - 1], currentLength));

            return result;
        }
        public string compress(string S)
        {
            var result = new StringBuilder();
            var currentLength = 0;

            for (int i = 1; i < S.Length; i++)
            {
                if (S[i] == S[i - 1])
                {
                    currentLength++;
                }
                else
                {
                    if (currentLength > 1)
                        result.Append(currentLength);

                    result.Append(S[i - 1]);

                    currentLength = 1;
                }
            }
            if (currentLength > 1)
                result.Append(currentLength);
            result.Append(S[S.Length - 1]);

            return result.ToString();
        }

        [Test]
        [TestCaseSource("Input")]
        public int solution(string S, int K)
        {
            var result = compress(S).Length;
            Console.WriteLine(compress(S));
            for (int i = 0; i < S.Length - K - 1; i++)
            {
                var candidate = S.Substring(0, i) + S.Substring(i + K, S.Length - K - i);
                var candidateLength = compress(candidate).Length;
                result = candidateLength < result ? candidateLength : result;
            }
            return result;
        }

        public static IEnumerable<TestCaseData> Input
        {
            get
            {
                yield return new TestCaseData("ABBBCCDDCCC", 3).Returns(5);
                yield return new TestCaseData("AAAAAAAAAAABXXAAAAAAAAAA", 3).Returns(3);
                yield return new TestCaseData("ABCDDDEFG", 2).Returns(6);
                yield return new TestCaseData("ABCDDDEFG", 2).Returns(6);
            }
        }
    }
}