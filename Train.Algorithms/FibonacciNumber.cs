using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/fibonacci-number/
    ///
    /// Fibonacci Number
    /// 
    /// The Fibonacci numbers, commonly denoted F(n) form a sequence, called the Fibonacci sequence, such that each number is the sum of the two preceding ones, starting from 0 and 1. That is,
    /// 
    /// F(0) = 0,   F(1) = 1
    /// F(N) = F(N - 1) + F(N - 2), for N > 1.
    /// Given N, calculate F(N).
    /// 
    /// Example 1:
    /// 
    /// Input: 2
    /// Output: 1
    /// Explanation: F(2) = F(1) + F(0) = 1 + 0 = 1.
    /// 
    /// Example 2:
    /// 
    /// Input: 3
    /// Output: 2
    /// Explanation: F(3) = F(2) + F(1) = 1 + 1 = 2.
    /// 
    /// Example 3:
    /// 
    /// Input: 4
    /// Output: 3
    /// Explanation: F(4) = F(3) + F(2) = 2 + 1 = 3.
    /// 
    /// Note:
    /// 
    /// 0 ≤ N ≤ 30.
    /// </summary>
    public class FibonacciNumber
    {
        [Test][TestCaseSource(nameof(TestData))]
        public int Fib(int N)
        {
            int a = 0, b = 1;

            if (N == 0) return a;
            if (N == 1) return b;

            for (var i = 2; i <= N; i++)
            {
                int next = a + b;
                a = b;
                b = next;
            }

            return b;
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(0).Returns(0);
                yield return new TestCaseData(1).Returns(1);
                yield return new TestCaseData(2).Returns(1);
                yield return new TestCaseData(3).Returns(2);
                yield return new TestCaseData(4).Returns(3);
                yield return new TestCaseData(5).Returns(5);
                yield return new TestCaseData(6).Returns(8);
                yield return new TestCaseData(7).Returns(13);
                yield return new TestCaseData(8).Returns(21);
                yield return new TestCaseData(9).Returns(34);
                yield return new TestCaseData(10).Returns(55);
                yield return new TestCaseData(11).Returns(89);
                yield return new TestCaseData(12).Returns(144);
                yield return new TestCaseData(13).Returns(233);
                yield return new TestCaseData(14).Returns(377);
                yield return new TestCaseData(15).Returns(610);
                yield return new TestCaseData(16).Returns(987);
                yield return new TestCaseData(17).Returns(1597);
                yield return new TestCaseData(18).Returns(2584);
                yield return new TestCaseData(19).Returns(4181);
                yield return new TestCaseData(20).Returns(6765);
                yield return new TestCaseData(21).Returns(10946);
                yield return new TestCaseData(22).Returns(17711);
                yield return new TestCaseData(23).Returns(28657);
                yield return new TestCaseData(24).Returns(46368);
                yield return new TestCaseData(25).Returns(75025);
                yield return new TestCaseData(26).Returns(121393);
                yield return new TestCaseData(27).Returns(196418);
                yield return new TestCaseData(28).Returns(317811);
                yield return new TestCaseData(29).Returns(514229);
                yield return new TestCaseData(30).Returns(832040);
            }
        }
    }
}