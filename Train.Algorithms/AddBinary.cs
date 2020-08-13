using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/add-binary/
    ///
    /// Given two binary strings, return their sum (also a binary string).
    /// The input strings are both non-empty and contains only characters 1 or 0.
    /// 
    /// Example 1:
    /// 
    /// Input: a = "11", b = "1"
    /// Output: "100"
    /// Example 2:
    /// 
    /// Input: a = "1010", b = "1011"
    /// Output: "10101"
    /// 
    /// 
    /// Constraints:
    /// 
    /// Each string consists only of '0' or '1' characters.
    /// 1 <= a.length, b.length <= 10^4
    /// Each string is either "0" or doesn't contain any leading zero.
    /// </summary>
    class AddBinary
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public string Solution(string a, string b)
        {
            var result = new StringBuilder();
            var carry = '0';

            for (int ai = a.Length - 1, bi = b.Length - 1; ai >= 0 || bi >= 0 || carry == '1'; ai--, bi--)
            {
                var ac = ai >= 0 ? a[ai] : '0';
                var bc = bi >= 0 ? b[bi] : '0';
                switch (new string(new[] {ac, bc, carry}))
                {
                    case "000":
                        result.Insert(0, "0");
                        carry = '0';
                        break;
                    case "001":
                    case "010":
                    case "100":
                        result.Insert(0, "1");
                        carry = '0';
                        break;
                    case "101":
                    case "110":
                    case "011":
                        result.Insert(0, "0");
                        carry = '1';
                        break;
                    case "111":
                        result.Insert(0, "1");
                        carry = '1';
                        break;
                }

            }

            return result.ToString();
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public string Stack(string a, string b)
        {
            var result = new Stack<char>();
            var carry = 0;

            for (var i = 1; i <= (a.Length > b.Length ? a.Length : b.Length); i++)
            {
                var av = i <= a.Length ? a[^i] - '0' : 0;
                var bv = i <= b.Length ? b[^i] - '0' : 0;

                var sum = av + bv + carry;
                result.Push((char) (sum % 2 + '0'));
                carry = sum / 2;
            }

            if(carry == 1) result.Push((char)(carry + '0'));
            return new string(result.ToArray());
        }
        
        public static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData("0", "1").Returns("1");
                yield return new TestCaseData("1", "1").Returns("10");
                yield return new TestCaseData("11", "1").Returns("100");
                yield return new TestCaseData("1010", "1").Returns("1011");
                yield return new TestCaseData("1010", "1011").Returns("10101");
                yield return new TestCaseData("1111", "1111").Returns("11110");
            }
        }
    }
}
