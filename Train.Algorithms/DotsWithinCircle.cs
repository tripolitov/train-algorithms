using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    public class DotsWithinCircle
    {
        private int calculateDistance(int x, int y)
        {
            return x * x + y * y;
        }

        public int solution(string S, int[] X, int[] Y)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();
            int radius = Int32.MaxValue;
            for (int i = 0; i < S.Length; i++)
            {
                var tag = new string(new[] { S[i] });
                var x = X[i];
                var y = Y[i];
                var d = calculateDistance(x, y);
                if (map.ContainsKey(tag))
                {
                    if (d >= map[tag])
                    {
                        if (d < radius)
                            radius = d;
                    }
                    else
                    {
                        map[tag] = d;
                    }
                }
                else
                {
                    map[tag] = d;
                }
            }
            var result = 0;
            foreach (var kvp in map)
            {
                if (kvp.Value < radius)
                    result++;
            }
            return result;
        }



        [Test]
        [TestCaseSource("Input")]
        public int Test(string tags, int[] X, int[] Y)
        {
            return solution(tags, X, Y);
        }

        public static IEnumerable<TestCaseData> Input
        {
            get
            {
                yield return new TestCaseData("ABDCA", new int[] {2, -1, -4, -3, 3}, new []{2, -2, 4, 1, -3}).Returns(3);
                yield return new TestCaseData("ABDCAX", new int[] {2, -1, -4, -3, 3,0}, new []{2, -2, 4, 1, -3,0}).Returns(4);
                yield return new TestCaseData("ABB", new int[] {1, -2, -2}, new []{1, -2, 2}).Returns(1);
                yield return new TestCaseData("CCD", new int[] {1, -1, 2}, new []{1, -1, -2}).Returns(0);
                yield return new TestCaseData("CCCD", new int[] {1, -1, 1, 0}, new []{1, -1, -1, 0}).Returns(1);
                yield return new TestCaseData("CCCDD", new int[] {1, -1, 1, 0,0}, new []{1, -1, -1, 0,0}).Returns(0);
                yield return new TestCaseData("", new int[0] {}, new int[0]{}).Returns(0);
            }
        }
    }
}