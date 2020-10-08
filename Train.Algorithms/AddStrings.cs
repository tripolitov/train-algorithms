using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/add-strings/
    /// 
    /// Add Strings
    ///
    /// Given two non-negative integers num1 and num2 represented as string, return the sum of num1 and num2.
    /// 
    /// Note:
    /// 
    /// The length of both num1 and num2 is &lt; 5100.
    /// Both num1 and num2 contains only digits 0-9.
    /// Both num1 and num2 does not contain any leading zero.
    /// You must not use any built-in BigInteger library or convert the inputs to integer directly.
    /// </summary>
    public class AddStringsSolution
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public string AddStrings(string num1, string num2)
        {
            int i = num1.Length - 1, j = num2.Length - 1, carry = 0;

            var sb = new StringBuilder();
            while (i >= 0 || j >= 0)
            {
                var n1 = i >= 0 ? num1[i--] - '0' : 0;
                var n2 = j >= 0 ? num2[j--] - '0' : 0;
                var sum = n1 + n2 + carry;
                carry = sum / 10;
                sb.Append((sum % 10).ToString());
            }

            if (carry > 0)
            {
                sb.Append(carry.ToString());
            }

            return new string(sb.ToString().ToCharArray().Reverse().ToArray());
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData("0", "0").Returns("0");
                yield return new TestCaseData("0", "1").Returns("1");
                yield return new TestCaseData("1", "0").Returns("1");
                yield return new TestCaseData("1", "1").Returns("2");
                yield return new TestCaseData("9", "1").Returns("10");
                yield return new TestCaseData("1", "9").Returns("10");
                yield return new TestCaseData("9", "9").Returns("18");
                yield return new TestCaseData("99", "99").Returns("198");
                yield return new TestCaseData("99", "1").Returns("100");
                yield return new TestCaseData("999", "1").Returns("1000");
                yield return new TestCaseData("999", "9").Returns("1008");
            }
        }
    }
}