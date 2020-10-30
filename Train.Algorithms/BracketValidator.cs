using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// write a braces/brackets/parentheses validator.
    /// 
    /// Let's say:
    /// 
    /// '(', '{', '[' are called "openers."
    /// ')', '}', ']' are called "closers."
    /// Write an efficient method that tells us whether or not an input string's openers and closers are properly nested.
    /// 
    /// Examples:
    /// 
    /// "{ [ ] ( ) }" should return true
    /// "{ [ ( ] ) }" should return false
    /// "{ [ }" should return false
    /// </summary>
    public class BracketValidator
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public static bool IsValid(string code)
        {
            var stack = new Stack<char>();
            foreach (var c in code)
            {
                if (c == '(') stack.Push(')');
                else if (c == '{') stack.Push('}');
                else if (c == '[') stack.Push(']');
                else
                {
                    if (stack.Count == 0) return false;
                    if (c != stack.Pop())
                        return false;
                }
            }

            return stack.Count == 0;
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData("").Returns(true);
                yield return new TestCaseData("()").Returns(true);
                yield return new TestCaseData("([]{[]})[]{{}()}").Returns(true);
                yield return new TestCaseData("([)]").Returns(false);
                yield return new TestCaseData("([][]}").Returns(false);
                yield return new TestCaseData("[[]()").Returns(false);
                yield return new TestCaseData("[[]]())").Returns(false);
            }
        }
    }
}