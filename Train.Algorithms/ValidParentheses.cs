using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/valid-parentheses/
    /// Given a string containing just the characters '(', ')', '{', '}', '[' and ']',
    /// determine if the input string is valid.
    /// 
    /// An input string is valid if:
    /// 
    /// Open brackets must be closed by the same type of brackets.
    /// Open brackets must be closed in the correct order.
    /// Note that an empty string is also considered valid.
    /// 
    /// Example 1:
    /// Input: "()"
    /// Output: true
    /// 
    /// Example 2:
    /// Input: "()[]{}"
    /// Output: true
    /// 
    /// Example 3:
    /// Input: "(]"
    /// Output: false
    /// 
    /// Example 4:
    /// Input: "([)]"
    /// Output: false
    /// 
    /// Example 5:
    /// Input: "{[]}"
    /// Output: true
    /// </summary>
    class ValidParentheses
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public bool IsValid(string s)
        {
            var stack = new Stack<Char>();
            for (var i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case '[': stack.Push(']'); break;
                    case '(': stack.Push(')'); break;
                    case '{': stack.Push('}'); break;

                    default:
                        if (stack.Count == 0 || stack.Pop() != s[i]) return false;
                       
                        break;
                }
            }

            return stack.Count == 0;
        }

        public static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData("").Returns(true);
                yield return new TestCaseData("[]").Returns(true);
                yield return new TestCaseData("()").Returns(true);
                yield return new TestCaseData("{}").Returns(true);
                yield return new TestCaseData("({})").Returns(true);
                yield return new TestCaseData("[{}]").Returns(true);
                yield return new TestCaseData("[{()}]").Returns(true);
                yield return new TestCaseData("([{}])").Returns(true);
                yield return new TestCaseData("(").Returns(false);
                yield return new TestCaseData("{").Returns(false);
                yield return new TestCaseData("[").Returns(false);
                yield return new TestCaseData(")").Returns(false);
                yield return new TestCaseData("]").Returns(false);
                yield return new TestCaseData("}").Returns(false);
                yield return new TestCaseData("(}").Returns(false);
                yield return new TestCaseData("[}").Returns(false);
                yield return new TestCaseData("[]}").Returns(false);
                yield return new TestCaseData("[(]}").Returns(false);

            }
        }
    }
}
