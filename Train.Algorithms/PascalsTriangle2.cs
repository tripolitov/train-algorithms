using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    ///https://leetcode.com/problems/pascals-triangle-ii/
    /// 
    /// Pascal's Triangle II
    ///
    /// Given an integer rowIndex, return the rowIndexth row of the Pascal's triangle.
    /// Notice that the row index starts from 0.
    ///
    /// Follow up:
    /// Could you optimize your algorithm to use only O(k) extra space?
    /// 
    /// Example 1:
    /// 
    /// Input: rowIndex = 3
    /// Output: [1,3,3,1]
    /// 
    /// Example 2:
    /// 
    /// Input: rowIndex = 0
    /// Output: [1]
    /// Example 3:
    /// 
    /// Input: rowIndex = 1
    /// Output: [1,1]
    /// 
    /// 
    /// Constraints:
    /// 
    /// 0 <= rowIndex <= 40
    /// </summary>
    class PascalsTriangle2
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public IList<int> GetRow(int rowIndex)
        {
            if (rowIndex == 0) return new int[] {1};
            var prev = GetRow(rowIndex - 1);

            var result = new int[rowIndex + 1];
            result[0] = 1;
            result[rowIndex] = 1;

            for (var i = 1; i < rowIndex; i++)
            {
                result[i] = prev[i - 1] + prev[i];
            }

            return result;
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public IList<int> Iterative(int rowIndex)
        {
            IList<int> current = new int[] { 1 };
            for (var i = 1; i <= rowIndex; i++)
            {

                var prev = current;
                current = new int[i + 1];
                current[0] = 1;
                current[i] = 1;

                for (var j = 1; j < i; j++)
                {
                    current[j] = prev[j - 1] + prev[j];
                }
            }

            return current;
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(0)
                    .Returns(new int[] { 1 });
                
                yield return new TestCaseData(1)
                    .Returns(new int[] { 1,1});

                yield return new TestCaseData(2)
                    .Returns(new int[] { 1, 2, 1});

                yield return new TestCaseData(3)
                    .Returns(new int[] { 1,3,3,1});

                yield return new TestCaseData(4)
                    .Returns(new int[] { 1,4,6,4,1});
            }
        }
    }
}
