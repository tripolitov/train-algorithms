using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/arranging-coins/
    ///
    /// Arranging Coins
    ///
    /// You have a total of n coins that you want to form in a staircase shape, where every k-th row must have exactly k coins.
    ///
    /// Given n, find the total number of full staircase rows that can be formed.
    ///
    /// n is a non-negative integer and fits within the range of a 32-bit signed integer.
    ///
    /// Example 1:
    ///
    /// n = 5
    ///
    /// The coins can form the following rows:
    /// ¤
    /// ¤ ¤
    /// ¤ ¤
    ///
    /// Because the 3rd row is incomplete, we return 2.
    ///
    /// Example 2:
    ///
    /// n = 8
    ///
    /// The coins can form the following rows:
    /// ¤
    /// ¤ ¤
    /// ¤ ¤ ¤
    /// ¤ ¤
    /// 
    /// Because the 4th row is incomplete, we return 3.
    /// </summary>
    public class ArrangingCoins
    {
        [Test][TestCaseSource(nameof(TestData))]
        public int ArrangeCoins(int n)
        {
            var rows = 0;
            for (var i = 1; i <= n; i++)
            {
                n -= i;
                if (n >= 0) rows += 1;
                else break;
            }

            return rows;
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(0).Returns(0);
                yield return new TestCaseData(1).Returns(1);
                yield return new TestCaseData(2).Returns(1);
                yield return new TestCaseData(3).Returns(2);
                yield return new TestCaseData(5).Returns(2);
                yield return new TestCaseData(6).Returns(3);
                yield return new TestCaseData(8).Returns(3);
            }
        }
    }
}