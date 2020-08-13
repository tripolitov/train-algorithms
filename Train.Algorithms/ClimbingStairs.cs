using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/climbing-stairs/
    ///
    /// You are climbing a stair case. It takes n steps to reach to the top.
    /// Each time you can either climb 1 or 2 steps.In how many distinct
    /// ways can you climb to the top?
    /// 
    /// Example 1:
    ///  Input: 2
    /// Output: 2
    /// Explanation: There are two ways to climb to the top.
    /// 1. 1 step + 1 step
    /// 2. 2 steps
    /// 
    /// Example 2: 
    /// Input: 3
    /// Output: 3
    /// Explanation: There are three ways to climb to the top.
    /// 1. 1 step + 1 step + 1 step
    /// 2. 1 step + 2 steps
    /// 3. 2 steps + 1 step
    /// 
    /// 
    /// Constraints:
    /// 
    /// 1 <= n <= 45
    /// </summary>
    class ClimbingStairs
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public int TopDownRecursive(int n)
        {
            int f(int k, int[] memory)
            {
                if (k == 0 || k == 1) return 1;
                if (memory[k] != 0) return memory[k];
                
                memory[k] = f(k - 1, memory) + f(k - 2, memory);

                return memory[k];
            }

            int[] memory = new int[n+1];
            return f(n, memory);
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public int BottomUp(int n)
        {
            var memory = new int[n + 1];

            memory[0] = 1;
            memory[1] = 1;
            for (var i = 2; i <= n; i++)
            {
                memory[i] = memory[i - 1] + memory[i - 2];
            }

            return memory[n];
        }

        [Test]
        [TestCaseSource(nameof(TestData))]
        public int BottomUpNoArray(int n)
        {
            int a = 1, b = 1;

            for (var i = 2; i <= n; i++) 
                (a, b) = (b, a + b);

            return b;
        }

        public static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(1).Returns(1);
                yield return new TestCaseData(2).Returns(2);
                yield return new TestCaseData(3).Returns(3);
                yield return new TestCaseData(4).Returns(5);
                yield return new TestCaseData(5).Returns(8);
                yield return new TestCaseData(10).Returns(89);
                yield return new TestCaseData(45).Returns(1836311903);
            }
        }

    }
}
