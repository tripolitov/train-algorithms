using System.Collections.Generic;
using NUnit.Framework;

namespace Train.Algorithms
{
    /// <summary>
    /// https://leetcode.com/problems/count-primes/
    /// 
    /// Count Primes
    ///
    /// Count the number of prime numbers less than a non-negative number, n.
    /// 
    /// Example:
    /// 
    /// Input: 10
    /// Output: 4
    /// Explanation: There are 4 prime numbers less than 10, they are 2, 3, 5, 7.
    /// </summary>
    public class CountPrimes
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public int SieveOfEratosthenes(int n)
        {
            var map = new bool[n];

            for (var i = 2; i < n; i++)
                map[i] = true;

            for (var i = 2; i * i < n; i++)
            {
                if(!map[i]) continue;
                for (var j = i * i; j < n; j+=i)
                {
                    map[j] = false;
                }
            }

            var result = 0;
            for (var i = 0; i < n; i++)
            {
                if (map[i] == true) result++;
            }
            return result;
        }

        static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(10).Returns(4);
                yield return new TestCaseData(20).Returns(8);
            }
        }

    }
}