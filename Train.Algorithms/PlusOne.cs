using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/plus-one
    /// 
    /// Given a non-empty array of digits representing
    /// a non-negative integer, increment one to the integer.
    /// 
    /// The digits are stored such that the most significant
    /// digit is at the head of the list, and each element
    /// in the array contains a single digit.
    /// 
    /// You may assume the integer does not contain any leading
    /// zero, except the number 0 itself.
    /// 
    /// Example 1:
    /// Input: [1,2,3]
    /// Output: [1,2,4]
    /// Explanation: The array represents the integer 123.
    /// 
    /// Example 2:
    /// Input: [4,3,2,1]
    /// Output: [4,3,2,2]
    /// Explanation: The array represents the integer 4321.
    /// </summary>
    class PlusOne
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public int[] Iterative(int[] digits)
        {
            var curry = 1;
            for (var i = digits.Length - 1; i >= 0; i--)
            {
                digits[i] = (digits[i] + curry) % 10;
                if (digits[i] != 0) return digits;
            }

            var result = new int[digits.Length + 1];
            result[0] = curry;
            return result;
        }

        public static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(new[] {0}).Returns(new int[] {1});
                yield return new TestCaseData(new[] {1, 2, 3}).Returns(new int[] {1, 2, 4});
                yield return new TestCaseData(new[] {1, 2, 9}).Returns(new int[] {1, 3, 0});
                yield return new TestCaseData(new[] {9, 9, 9}).Returns(new int[] {1, 0, 0, 0});
            }
        }
    }
}
