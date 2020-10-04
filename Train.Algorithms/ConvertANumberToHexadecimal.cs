using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/convert-a-number-to-hexadecimal/
    /// 
    /// Convert a Number to Hexadecimal
    ///
    /// Given an integer, write an algorithm to convert it to hexadecimal. For negative integer, two’s complement
    /// method is used.
    /// 
    /// Note:
    /// 
    /// All letters in hexadecimal (a-f) must be in lowercase.
    /// The hexadecimal string must not contain extra leading 0s. If the number is zero, it is represented by a single
    /// zero character '0'; otherwise, the first character in the hexadecimal string will not be the zero character.
    /// The given number is guaranteed to fit within the range of a 32-bit signed integer.
    /// You must not use any method provided by the library which converts/formats the number to hex directly.
    /// Example 1:
    /// 
    /// Input:
    /// 26
    /// 
    /// Output:
    /// "1a"
    /// Example 2:
    /// 
    /// Input:
    /// -1
    /// 
    /// Output:
    /// "ffffffff"
    /// </summary>
    public class ConvertANumberToHexadecimal
    {
        [Test][TestCaseSource(nameof(TestData))]
        public string ToHex(int num) {
            if(num == 0) return "0";
        
            var digits = new char[] {
                '0', '1', '2', '3', '4', '5',
                '6', '7', '8', '9', 'a', 'b',
                'c', 'd', 'e', 'f'
            };
            var sb = new StringBuilder();
            var bits = 32;
            while(bits > 0 && num != 0) {            
                sb.Insert(0, digits[num & 0xf]);
                num = num >> 4;
                bits -= 4;
            }
            return sb.ToString();
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(1).Returns("1");
                yield return new TestCaseData(10).Returns("a");
                yield return new TestCaseData(15).Returns("f");
                yield return new TestCaseData(26).Returns("1a");
                yield return new TestCaseData(-1).Returns("ffffffff");
            }
        }
    }
}