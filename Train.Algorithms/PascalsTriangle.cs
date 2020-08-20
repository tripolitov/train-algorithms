using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// Pascal's Triangle
    ///
    /// https://leetcode.com/problems/pascals-triangle/
    ///
    /// Given a non-negative integer numRows, generate the first numRows of Pascal's triangle.
    ///
    /// Example:
    ///     Input: 5
    ///     Output:
    /// [
    ///     [1],
    ///    [1,1],
    ///   [1,2,1],
    ///  [1,3,3,1],
    /// [1,4,6,4,1]
    /// ]
    /// </summary>
    class PascalsTriangle
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public IList<IList<int>> Generate(int numRows)
        {
            var result = new IList<int>[numRows];

            for (var i = 0; i < numRows; i++)
            {
                result[i] = new int[i + 1];
                result[i][0] = 1;
                result[i][i] = 1;

                for (var j = 1; j < i; j++)
                {
                    result[i][j] = result[i - 1][j - 1] + result[i - 1][j];
                }
            }

            return result;
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(1)
                    .Returns(
                        new List<IList<int>>()
                        {
                            new List<int>() {1}
                        });
                
                yield return new TestCaseData(2)
                    .Returns(
                        new List<IList<int>>()
                        {
                            new List<int>() {1},
                            new List<int>() {1,1}
                        });

                yield return new TestCaseData(3)
                    .Returns(
                        new List<IList<int>>()
                        {
                            new List<int>() {1},
                            new List<int>() {1,1},
                            new List<int>() {1,2,1},
                        });

                yield return new TestCaseData(4)
                    .Returns(
                        new List<IList<int>>()
                        {
                            new List<int>() {1},
                            new List<int>() {1,1},
                            new List<int>() {1,2,1},
                            new List<int>() {1,3,3,1},
                        });

                yield return new TestCaseData(5)
                    .Returns(
                        new List<IList<int>>()
                        {
                            new List<int>() {1},
                            new List<int>() {1,1},
                            new List<int>() {1,2,1},
                            new List<int>() {1,3,3,1},
                            new List<int>() {1,4,6,4,1},
                        });
            }
        }
    }
}
